Imports System.ServiceModel
Imports DuplexService.Service
Imports System.Windows.Browser

Partial Public Class MainPage
    Inherits UserControl

    Private client As AsyncTaskServiceClient

    Public Sub New()
        InitializeComponent()

        Dim address As New EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/DuplexService.Web/AsyncTask.svc")
        Dim binding As New PollingDuplexHttpBinding()

        client = New AsyncTaskServiceClient(binding, address)
        AddHandler client.ReturnResultReceived, AddressOf client_ReturnResultReceived
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim taskDescription As New TaskDescription()
        taskDescription.DataToProcess = txtTextToProcess.Text
        client.SubmitTaskAsync(taskDescription)
        lblStatus.Text = "Asynchronous request sent to server."
    End Sub

    Private Sub client_ReturnResultReceived(ByVal sender As Object, ByVal e As ReturnResultReceivedEventArgs)
        lblStatus.Text = "Response received: " & e.result.ProcessedData
    End Sub

End Class