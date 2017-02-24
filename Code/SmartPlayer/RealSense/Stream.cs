﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SampleDX;
using RealSense.RealSenseData;
using System.Windows.Forms;

namespace RealSense
{
    public class Stream
    {
        // 全局RealSense的管理
        private static PXCMSession session = PXCMSession.CreateInstance();
        private PXCMSenseManager manager;
        private PXCMCapture.Sample sample;

        //面部数据，支持单人检测
        private PXCMFaceData.Face face;
        private PXCMFaceData faceData;
        private PXCMFaceModule faceModule;
        private const int NUM_PERSONS = 1;

        // 用于display
        private static D2D1Render render=new D2D1Render();
        private event EventHandler<RenderFrameEventArgs> RenderFrame = null;
        
        // 状态机的维护
        private bool m_stopped = true;
        private bool m_display = false;
        private bool m_display_once = false;

        public bool Stopped
        {
            get
            {
                return m_stopped;
            }

            set
            {
                m_stopped = value;
            }
        }

        public enum AlgoOption
        {
            Face,
            Hand,
            FaceAndHand
        };

        public enum StreamOption
        {
            None,
            Color,
            Depth,
            ColorAndDepth,
            IR
        };

        public enum RecordOption
        {
            Live,
            Record,
            Playback
        };

        private AlgoOption m_algoOption;
        private StreamOption m_streamOption;
        private RecordOption m_recordOption;

        /// <summary>
        /// 本函数为Form添加FormClosingEvent,关闭窗口时关闭rs实例。构造函数依据Stream.***Option来使用
        /// </summary>
        /// <param name="so"></param>
        public Stream(Form f,StreamOption so = StreamOption.None, AlgoOption ao = AlgoOption.Face, RecordOption ro = RecordOption.Record)
        {
            m_algoOption = ao;
            m_streamOption = so;
            m_recordOption = ro;

            f.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormClosingHandler);

            InitPowerState();
        }


        /// <summary>
        /// 构造函数依据Stream.***Option来使用
        /// </summary>
        /// <param name="so"></param>
        public Stream(StreamOption so = StreamOption.None, AlgoOption ao=AlgoOption.Face, RecordOption ro= RecordOption.Record)
        {
            m_algoOption = ao;
            m_streamOption = so;
            m_recordOption = ro;
            
            InitPowerState();
        }

        /// <summary>
        /// 后台开始摄像头Stream
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            if (!this.m_stopped)
            {
                System.Windows.Forms.MessageBox.Show("Already Start");
                return false;
            }
            System.Threading.Thread thread = new System.Threading.Thread(DoStreaming);
            thread.Start();
            System.Threading.Thread.Sleep(5);
            return true;
        }

        /// <summary>
        /// 后台停止摄像头Stream
        /// </summary>
        public void Stop()
        {
            this.m_stopped = true;

           
        }

        /// <summary>
        /// 将流显示在窗口中，显示的流种类与初始化传入种类对应.仅支持单独的PictureBox
        /// </summary>
        /// <param name="pb"></param>
        /// <returns></returns>
        public bool OpenDisplay(System.Windows.Forms.PictureBox pb)
        {
            if (this.m_display)
            {
                System.Windows.Forms.MessageBox.Show("Already Display");
                return false;
            }

            if(!this.m_display_once)
            {
                this.RenderFrame += new EventHandler<RenderFrameEventArgs>(RenderFrameHandler);
                render.SetHWND(pb);
                pb.Paint += new System.Windows.Forms.PaintEventHandler(PaintHandler);
                pb.Resize += new EventHandler(ResizeHandler);

                this.m_display_once = true;
            }

            this.m_display = true;
            return true;
        }

        /// <summary>
        /// 关闭显示流功能，后台流获取不停止
        /// </summary>
        public void CloseDisplay()
        {
            this.m_display = false;
            
        }

        /// <summary>
        /// 获取实时面部特征数据
        /// </summary>
        /// <returns></returns>
        public FacialLandmarks GetFaceLandmarks()
        {
            int nFace = faceData.QueryNumberOfDetectedFaces();
            if (nFace == 0)
            {
#if DEBUG
                Console.WriteLine("No face in current frame");
#endif
                return null;
            }
            this.face = this.faceData.QueryFaceByIndex(0);

            FacialLandmarks flm = new FacialLandmarks();
            flm.updateData(face);
            return flm;
        }

        /// <summary>
        /// 获取实时面部表情
        /// </summary>
        /// <returns></returns>
        public FacialExpression GetExpression()
        {
            int nFace = faceData.QueryNumberOfDetectedFaces();
            if (nFace == 0)
            {
#if DEBUG
                Console.WriteLine("No face in current frame");
#endif
                return null;
            }
            this.face = this.faceData.QueryFaceByIndex(0);

            FacialExpression fe = new FacialExpression();
            PXCMFaceData.ExpressionsData edata = face.QueryExpressions();
            if (edata == null)
            {
#if DEBUG
                Console.WriteLine("no expression this frame");
#endif
                return null;
            }
#if DEBUG
            else
            {
                Console.WriteLine("catch expression");
            }
#endif
            for (int i = 0; i < 22; i++)
            {
                PXCMFaceData.ExpressionsData.FaceExpressionResult score;
                edata.QueryExpression((PXCMFaceData.ExpressionsData.FaceExpression)i, out score);
                fe.facialExpressionIndensity[i] = score.intensity;
            }

            return fe;
        }
        

        //*********************************私有函数*******************************************************************

        // 循环执行流的主体程序
        private void DoStreaming()
        {
            this.m_stopped = false;
            InitStreamState();

            
            switch (m_algoOption)
            {
                // 面部算法
                case AlgoOption.Face:
                    this.faceModule = manager.QueryFace();
                    if (faceModule == null) { MessageBox.Show("QueryFace failed"); return; }

                    InitFaceState();

                    this.faceData = this.faceModule.CreateOutput();
                    if (faceData == null) { MessageBox.Show("CreateOutput failed"); return; }

                    break;
            }

            if (manager.Init() < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show("init failed");
#endif
                return;
            }

            while (!m_stopped)
            {
                if (manager.AcquireFrame(false).IsError()) { break; }

                this.sample = manager.QuerySample();
                //if (sample == null) { manager.ReleaseFrame(); continue; }

                // 原生算法调用处理，并缓存实时数据
                faceData.Update();

                // 用于显示视频流功能
                if (m_display) { this.DoRender(); }
                
                manager.ReleaseFrame();
            }
            faceData.Dispose();
            manager.Dispose();
        }


        //*********************************初始化函数(初始化各种杂乱的参数)*******************************************************************

        // Init all crappy parameters RealSense needs
        private void InitStreamState()
        {
            manager = session.CreateSenseManager();

            //算法模块
            switch (m_algoOption)
            {
                case AlgoOption.Face:
                    manager.EnableFace();
                    break;
                case AlgoOption.Hand:
                    manager.EnableHand();
                    break;
                case AlgoOption.FaceAndHand:
                    manager.EnableFace();
                    manager.EnableHand();
                    break;
                default:
                    break;
            }

            //视频显示流模块
            switch (m_streamOption)
            {
                case StreamOption.Color:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 640, 360);
                    break;
                case StreamOption.Depth:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_DEPTH, 640, 480);
                    break;
                case StreamOption.IR:
                    manager.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_IR, 640, 480);
                    break;
                default:
                    break;
            }

            //控制录像模块
            var recordPath = System.Configuration.ConfigurationManager.AppSettings["RecordPath"];
            switch (m_recordOption)
            {
                case RecordOption.Live:
                    break;
                case RecordOption.Record:
                    if (recordPath == null)
                    {
#if DEBUG
                        System.Windows.Forms.MessageBox.Show("RecordPath Error");
#endif
                    }
                    manager.captureManager.SetFileName(recordPath, true);
                    break;
                case RecordOption.Playback:
                    manager.captureManager.SetFileName(recordPath, true);
                    break;
            }
        }

        // Set RealSense To Performance Model, to provide most accurate algorithm
        private void InitPowerState()
        {
            PXCMPowerState ps = session.CreatePowerManager();
            ps.SetState(PXCMPowerState.State.STATE_PERFORMANCE);
        }

        // 设置面部的许多参数，打开Landmark、Expression，未打开pulse、面部识别模块
        private void InitFaceState()
        {
            PXCMFaceConfiguration faceCfg = faceModule.CreateActiveConfiguration();
            if (faceCfg == null)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show("faceCfg failed");
#endif
                return;
            }

            faceCfg.SetTrackingMode(PXCMFaceConfiguration.TrackingModeType.FACE_MODE_COLOR_PLUS_DEPTH);
            faceCfg.strategy = PXCMFaceConfiguration.TrackingStrategyType.STRATEGY_CLOSEST_TO_FARTHEST;
            // 单个人追踪
            faceCfg.detection.maxTrackedFaces = NUM_PERSONS;
            faceCfg.landmarks.maxTrackedFaces = NUM_PERSONS;
            faceCfg.pose.maxTrackedFaces = NUM_PERSONS;

            // 表情初始化
            PXCMFaceConfiguration.ExpressionsConfiguration expressionCfg = faceCfg.QueryExpressions();
            if (expressionCfg == null)
            {
                throw new Exception("ExpressionsConfiguration null");
            }
            expressionCfg.properties.maxTrackedFaces = NUM_PERSONS;

            expressionCfg.EnableAllExpressions();
            faceCfg.detection.isEnabled = true;
            faceCfg.landmarks.isEnabled = true;
            faceCfg.pose.isEnabled = true;
            if (expressionCfg != null)
            {
                expressionCfg.Enable();
            }

            //脉搏初始化
            if (false)
            {
                PXCMFaceConfiguration.PulseConfiguration pulseConfiguration = faceCfg.QueryPulse();
                if (pulseConfiguration == null)
                {
                    throw new Exception("pulseConfiguration null");
                }

                pulseConfiguration.properties.maxTrackedFaces = NUM_PERSONS;
                if (pulseConfiguration != null)
                {
                    pulseConfiguration.Enable();
                }
            }

            // 面部识别功能初始化
            if (false)
            {
                PXCMFaceConfiguration.RecognitionConfiguration qrecognition = faceCfg.QueryRecognition();
                if (qrecognition == null)
                {
                    throw new Exception("PXCMFaceConfiguration.RecognitionConfiguration null");
                }
                else
                {
                    qrecognition.Enable();
                }
            }

            faceCfg.ApplyChanges();
        }

        //*********************************回调函数（图像渲染、窗口关闭）*******************************************************************

        /* Redirect to DirectX Update */
        private void PaintHandler(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            render.UpdatePanel();
        }

        /* Redirect to DirectX Resize */
        private void ResizeHandler(object sender, EventArgs e)
        {
            render.ResizePanel();
        }

        // 用于显示视频流功能，即将对应的流存到image中
        private void DoRender()
        {
            EventHandler<RenderFrameEventArgs> renderLocal = RenderFrame;
            PXCMImage image = null;
            switch (m_streamOption)
            {
                case StreamOption.Color:
                    image = sample.color;
                    break;
                case StreamOption.Depth:
                    image = sample.depth;
                    break;
                case StreamOption.IR:
                    image = sample.ir;
                    break;
            }
            renderLocal(this, new RenderFrameEventArgs(0, image));
        }

        // Render Frame Handler, just update from e.image
        private void RenderFrameHandler(Object sender, RenderFrameEventArgs e)
        {
            if (e.image == null) return;
            render.UpdatePanel(e.image);
        }

        private void FormClosingHandler(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Stopped = true;
        }
    }
}