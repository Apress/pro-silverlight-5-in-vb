Imports StoreDbDataClasses
Imports DataControls.DataService
Imports System.ServiceModel
Imports System.Windows.Browser

Partial Public Class PivotViewerTest
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
            pivotViewer.ItemsSource = e.Result
        Catch err As Exception
            MessageBox.Show("Failed to contact service.")
        End Try
    End Sub

    Private Sub pivotViewer_ItemDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Controls.Pivot.PivotViewerItemDoubleClickEventArgs)
        Dim product As Product = (CType(e.Item, Product))
        MessageBox.Show("You clicked " & product.ModelName & ".")
    End Sub

End Class
