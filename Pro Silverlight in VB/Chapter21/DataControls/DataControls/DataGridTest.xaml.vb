Imports System.ServiceModel
Imports DataControls.DataService
Imports StoreDbDataClasses
Imports System.Windows.Browser

Partial Public Class DataGridTest
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

    ' Reuse brush objects for efficiency in large data displays.
    Private highlightBrush As New SolidColorBrush(Colors.Orange)
    Private normalBrush As New SolidColorBrush(Colors.White)

    Private Sub gridProducts_LoadingRow(ByVal sender As Object, ByVal e As DataGridRowEventArgs)
        Dim product As Product = CType(e.Row.DataContext, Product)
        If product.UnitCost > 100 Then
            e.Row.Background = highlightBrush
        Else
            e.Row.Background = normalBrush
        End If

    End Sub

    Private Sub FormatRow(ByVal row As DataGridRow)
        Dim product As Product = CType(row.DataContext, Product)
        If product.UnitCost > 100 Then
            row.Background = highlightBrush
        Else
            row.Background = normalBrush
        End If
    End Sub

End Class
