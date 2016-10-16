Imports System.ServiceModel.Description
Imports DataControls.DataService
Imports System.ServiceModel
Imports System.Windows.Browser

Partial Public Class BoundTreeView
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim client As New StoreDbClient()
        Dim address As New EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/DataControls.Web/StoreDb.svc")
        client.Endpoint.Address = address

        AddHandler client.GetCategoriesWithProductsCompleted, AddressOf client_GetCategoriesWithProductsCompleted
        client.GetCategoriesWithProductsAsync()

        lblStatus.Text = "Contacting service ..."
    End Sub

    Private Sub client_GetCategoriesWithProductsCompleted(ByVal sender As Object, ByVal e As GetCategoriesWithProductsCompletedEventArgs)
        Try
            treeCategories.ItemsSource = e.Result
            lblStatus.Text = "Received results from web service."
        Catch err As Exception
            lblStatus.Text = "An error occured: " & err.Message
        End Try
    End Sub
End Class
