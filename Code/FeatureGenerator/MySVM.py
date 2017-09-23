import os

train_exe_path = "F:\libsvm-3.22\windows\svm-train.exe"
predict_exe_path = "F:\libsvm-3.22\windows\svm-predict.exe"
dataSetDir = "E:\Datas\wholeSet"

class MyParam(object):
    def __init__(self, c, g):
        self.c = c
        self.g = g

paramDict = {'dataset_interactionWithWindowSize10':MyParam(128, 0.03125),
             'dataset_interactionWithWindowSize5':MyParam(8.0, 8.0),
             'dataset_appearance':MyParam(8.0, 0.000030517578125),
             'dataset_mergedWithWindowSize5':MyParam(8.0, 0.000030517578125),
             'dataset_mergedWithWindowSize10':MyParam(128.0, 0.000030517578125) }

def SvmTrainProcess(dataSetFile, modelFilePath):
    print '-------------- SVM Train Start --------------'
    dataSetFilePath = dataSetDir + '/' + dataSetFile + '_train'
    command = train_exe_path
    command += ' -d 3 -h 0 -t 1 -b 1 -c %s -g %s % s %s'%(str(paramDict[dataSetFile].c), str(paramDict[dataSetFile].g), dataSetFilePath, modelFilePath)
    print command
    os.system(command)

def SvmPredictProcess(testSetFile, modelFilePath):
    print '-------------- SVM Predict Start --------------'
    testSetFilePath = dataSetDir + '/' + testSetFile + '_test'
    predictResultFilePath = dataSetDir + '/' + testSetFile + '.result'
    command = predict_exe_path
    command += ' -b 1 %s %s %s'%(testSetFilePath, modelFilePath, predictResultFilePath)
    print command
    os.system(command)

if __name__ == '__main__':
    for keys in paramDict.keys():
        modelFilePath = dataSetDir + '/' + keys + '.model'
        SvmTrainProcess(keys, modelFilePath)
        SvmPredictProcess(keys, modelFilePath)
