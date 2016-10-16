Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.ServiceModel.Activation
Imports System.Threading


<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class AsyncTask
    Implements IAsyncTaskService

    Public Sub SubmitTask(ByVal taskDescription As TaskDescription) Implements IAsyncTaskService.SubmitTask
        ' Simulate some work with a delay.
        Thread.Sleep(TimeSpan.FromSeconds(15))

        ' Reverse the letters in string.
        Dim data As Char() = taskDescription.DataToProcess.ToCharArray()
        Array.Reverse(data)

        ' Prepare the response.
        Dim result As New TaskResult()
        result.ProcessedData = New String(data)

        ' Send the response to the client.
        Try
            Dim client As IAsyncTaskClient = OperationContext.Current.GetCallbackChannel(Of IAsyncTaskClient)()
            client.ReturnResult(result)
        Catch
            ' The client could not be contacted.
            ' Clean up any resources here before the thread ends.
        End Try
        ' Incidentally, you can call the client.ReturnResult() method mulitple times to
        ' return different pieces of data at different times.
        ' The connection remains available until the reference is released (when the method 
        ' ends and the variable goes out of scope).
    End Sub
End Class
