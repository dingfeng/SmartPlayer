﻿namespace SmartPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_Monitor = new System.Windows.Forms.PictureBox();
            this.fastSpeedBtn = new System.Windows.Forms.Button();
            this.normalSpeedBtn = new System.Windows.Forms.Button();
            this.slowSpeedBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.normalBtn = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.coverPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.Button();
            this.videoVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.videoProgressLabel = new System.Windows.Forms.Label();
            this.videoProgressTrackBar = new System.Windows.Forms.TrackBar();
            this.videoListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.videoProgressTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).BeginInit();
            this.videoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Monitor
            // 
            this.pb_Monitor.Location = new System.Drawing.Point(22, 38);
            this.pb_Monitor.Name = "pb_Monitor";
            this.pb_Monitor.Size = new System.Drawing.Size(198, 177);
            this.pb_Monitor.TabIndex = 0;
            this.pb_Monitor.TabStop = false;
            this.pb_Monitor.Click += new System.EventHandler(this.pb_Monitor_Click);
            // 
            // fastSpeedBtn
            // 
            this.fastSpeedBtn.Location = new System.Drawing.Point(378, 32);
            this.fastSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.fastSpeedBtn.Name = "fastSpeedBtn";
            this.fastSpeedBtn.Size = new System.Drawing.Size(61, 44);
            this.fastSpeedBtn.TabIndex = 3;
            this.fastSpeedBtn.Text = "快速播放";
            this.fastSpeedBtn.UseVisualStyleBackColor = true;
            this.fastSpeedBtn.Click += new System.EventHandler(this.fastSpeedBtn_Click);
            // 
            // normalSpeedBtn
            // 
            this.normalSpeedBtn.Location = new System.Drawing.Point(306, 32);
            this.normalSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.normalSpeedBtn.Name = "normalSpeedBtn";
            this.normalSpeedBtn.Size = new System.Drawing.Size(68, 44);
            this.normalSpeedBtn.TabIndex = 4;
            this.normalSpeedBtn.Text = "常速播放";
            this.normalSpeedBtn.UseVisualStyleBackColor = true;
            this.normalSpeedBtn.Click += new System.EventHandler(this.normalSpeedBtn_Click);
            // 
            // slowSpeedBtn
            // 
            this.slowSpeedBtn.Location = new System.Drawing.Point(241, 32);
            this.slowSpeedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.slowSpeedBtn.Name = "slowSpeedBtn";
            this.slowSpeedBtn.Size = new System.Drawing.Size(61, 44);
            this.slowSpeedBtn.TabIndex = 5;
            this.slowSpeedBtn.Text = "慢速播放";
            this.slowSpeedBtn.UseVisualStyleBackColor = true;
            this.slowSpeedBtn.Click += new System.EventHandler(this.slowSpeedBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Location = new System.Drawing.Point(176, 33);
            this.forwardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(61, 43);
            this.forwardBtn.TabIndex = 6;
            this.forwardBtn.Text = "快进播放";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.forwardBtn_MouseDown);
            this.forwardBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.forwardBtn_MouseUp);
            // 
            // normalBtn
            // 
            this.normalBtn.Location = new System.Drawing.Point(2, 33);
            this.normalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(63, 43);
            this.normalBtn.TabIndex = 7;
            this.normalBtn.Text = "正常播放";
            this.normalBtn.UseVisualStyleBackColor = true;
            this.normalBtn.Click += new System.EventHandler(this.normalBtn_Click);
            // 
            // reverseBtn
            // 
            this.reverseBtn.Location = new System.Drawing.Point(111, 33);
            this.reverseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(61, 43);
            this.reverseBtn.TabIndex = 8;
            this.reverseBtn.Text = "倒退播放";
            this.reverseBtn.UseVisualStyleBackColor = true;
            this.reverseBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reverseBtn_MouseDown);
            this.reverseBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.reverseBtn_MouseUp);
            // 
            // videoPanel
            // 
            this.videoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanel.BackColor = System.Drawing.Color.Black;
            this.videoPanel.Controls.Add(this.coverPanel);
            this.videoPanel.Location = new System.Drawing.Point(235, 12);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(665, 360);
            this.videoPanel.TabIndex = 9;
            // 
            // coverPanel
            // 
            this.coverPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coverPanel.BackColor = System.Drawing.Color.Transparent;
            this.coverPanel.Location = new System.Drawing.Point(1, 0);
            this.coverPanel.Name = "coverPanel";
            this.coverPanel.Size = new System.Drawing.Size(664, 361);
            this.coverPanel.TabIndex = 0;
            this.coverPanel.DoubleClick += new System.EventHandler(this.coverPanel_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.stopBtn);
            this.panel2.Controls.Add(this.videoVolumeTrackBar);
            this.panel2.Controls.Add(this.videoProgressLabel);
            this.panel2.Controls.Add(this.normalBtn);
            this.panel2.Controls.Add(this.reverseBtn);
            this.panel2.Controls.Add(this.fastSpeedBtn);
            this.panel2.Controls.Add(this.normalSpeedBtn);
            this.panel2.Controls.Add(this.slowSpeedBtn);
            this.panel2.Controls.Add(this.forwardBtn);
            this.panel2.Controls.Add(this.videoProgressTrackBar);
            this.panel2.Location = new System.Drawing.Point(235, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 78);
            this.panel2.TabIndex = 10;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(68, 33);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(40, 43);
            this.stopBtn.TabIndex = 14;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // videoVolumeTrackBar
            // 
            this.videoVolumeTrackBar.Location = new System.Drawing.Point(444, 34);
            this.videoVolumeTrackBar.Name = "videoVolumeTrackBar";
            this.videoVolumeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.videoVolumeTrackBar.TabIndex = 10;
            this.videoVolumeTrackBar.Scroll += new System.EventHandler(this.videoVolumeTrackBar_Scroll);
            // 
            // videoProgressLabel
            // 
            this.videoProgressLabel.AutoSize = true;
            this.videoProgressLabel.Location = new System.Drawing.Point(554, 48);
            this.videoProgressLabel.Name = "videoProgressLabel";
            this.videoProgressLabel.Size = new System.Drawing.Size(107, 12);
            this.videoProgressLabel.TabIndex = 9;
            this.videoProgressLabel.Text = "00:00:00/00:00:00";
            // 
            // videoProgressTrackBar
            // 
            this.videoProgressTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoProgressTrackBar.LargeChange = 1;
            this.videoProgressTrackBar.Location = new System.Drawing.Point(0, 0);
            this.videoProgressTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.videoProgressTrackBar.Name = "videoProgressTrackBar";
            this.videoProgressTrackBar.Size = new System.Drawing.Size(665, 45);
            this.videoProgressTrackBar.TabIndex = 0;
            this.videoProgressTrackBar.Scroll += new System.EventHandler(this.videoProgressTrackBar_Scroll);
            this.videoProgressTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoProgressTrackBar_MouseDown);
            this.videoProgressTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoProgressTrackBar_MouseUp);
            // 
            // videoListBox
            // 
            this.videoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.videoListBox.FormattingEnabled = true;
            this.videoListBox.ItemHeight = 12;
            this.videoListBox.Location = new System.Drawing.Point(22, 267);
            this.videoListBox.Name = "videoListBox";
            this.videoListBox.Size = new System.Drawing.Size(198, 184);
            this.videoListBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "实时画面";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "播放列表";
            // 
            // videoProgressTimer
            // 
            this.videoProgressTimer.Interval = 500;
            this.videoProgressTimer.Tick += new System.EventHandler(this.videoProgressTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 468);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.videoListBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.pb_Monitor);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Monitor)).EndInit();
            this.videoPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoProgressTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Monitor;
        private System.Windows.Forms.Button fastSpeedBtn;
        private System.Windows.Forms.Button normalSpeedBtn;
        private System.Windows.Forms.Button slowSpeedBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button normalBtn;
        private System.Windows.Forms.Button reverseBtn;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar videoVolumeTrackBar;
        private System.Windows.Forms.Label videoProgressLabel;
        private System.Windows.Forms.ListBox videoListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar videoProgressTrackBar;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Timer videoProgressTimer;
        private System.Windows.Forms.Panel coverPanel;
    }
}

