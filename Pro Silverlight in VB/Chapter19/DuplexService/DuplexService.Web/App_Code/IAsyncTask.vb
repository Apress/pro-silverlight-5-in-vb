Imports System.ServiceModel
Imports System.Runtime.Serialization


<ServiceContract(CallbackContract := GetType(IAsyncTaskClient))> _
Public Interface IAsyncTaskService
    <OperationContract(IsOneWay := True)> _
    Sub SubmitTask(ByVal task As TaskDescription)
End Interface

<ServiceContract> _
Public Interface IAsyncTaskClient
    <OperationContract(IsOneWay := True)> _
    Sub ReturnResult(ByVal result As TaskResult)
End Interface

<DataContract()> _
Public Class TaskDescription

    Private _dataToProcess As String
    <DataMember()> _
    Public Property DataToProcess() As String
        Get
            Return _dataToProcess
        End Get
        Set(ByVal value As String)
            _dataToProcess = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class TaskResult

    Private _processedData As String
    <DataMember()> _
    Public Property ProcessedData() As String
        Get
            Return _processedData
        End Get
        Set(ByVal value As String)
            _processedData = value
        End Set
    End Property
End Class