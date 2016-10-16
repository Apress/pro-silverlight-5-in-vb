Imports TypeSharingClient.ServiceReference1
Imports System.Windows.Browser

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdCallService_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim address As New System.ServiceModel.EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/TypeSharing.Web/TestService.svc")
        Dim proxy As New TestServiceClient()
        proxy.Endpoint.Address = address

        AddHandler proxy.GetCustomerCompleted, AddressOf GetCustomerCompleted
        proxy.GetCustomerAsync(0)
    End Sub

    Private Sub GetCustomerCompleted(ByVal sender As Object, ByVal e As GetCustomerCompletedEventArgs)
        Dim customer As DataClasses.Customer = e.Result
        MessageBox.Show(customer.GetFullName())
    End Sub

End Class