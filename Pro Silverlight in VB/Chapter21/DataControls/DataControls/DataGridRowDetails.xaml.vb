Imports System.ServiceModel
Imports System.Windows.Browser
Imports DataControls.DataService

Partial Public Class DataGridRowDetails
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim address As New EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/DataControls.Web/StoreDb.svc")
        Dim client As New StoreDbClient()
        client.Endpoint.Address = address

        AddHandler client.GetProductsCompleted, AddressOf client_GetProductsCompleted
        client.GetProductsAsync()
    End Sub

    Private Sub client_GetProductsCompleted(ByVal sender As Object, ByVal e As GetProductsCompletedEventArgs)
        Try
            gridProducts.ItemsSource = e.Result
        Catch err As Exception
            lblInfo.Text = "Failed to contact service."
        End Try
    End Sub

End Class
