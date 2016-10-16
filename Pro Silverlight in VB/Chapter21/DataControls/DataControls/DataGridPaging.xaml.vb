Imports System.ServiceModel
Imports DataControls.DataService
Imports System.Windows.Browser
Imports System.Windows.Data
Imports System.ComponentModel
Imports StoreDbDataClasses


Partial Public Class DataGridPaging
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
            Dim view As New PagedCollectionView(e.Result)
            ' Sort by category and price.
            view.SortDescriptions.Add(New SortDescription("CategoryName", ListSortDirection.Ascending))
            view.SortDescriptions.Add(New SortDescription("UnitCost", ListSortDirection.Ascending))

            gridProducts.ItemsSource = view

            pager.Source = view
        Catch err As Exception
            lblInfo.Text = "Failed to contact service."
        End Try
    End Sub
End Class
