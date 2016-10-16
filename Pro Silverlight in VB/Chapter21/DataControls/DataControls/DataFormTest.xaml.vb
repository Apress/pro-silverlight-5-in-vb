Imports StoreDbDataClasses
Imports System.ComponentModel.DataAnnotations

Partial Public Class DataFormTest
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private product As New Product("AEFS100", "Portable Defibrillator", 77.99, "Analyzes the electrical activity of a person's heart and applies an electric shock if necessary.")
    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim products As List(Of Product) = New List(Of Product)()
        products.Add(product)
        products.Add(product)
        'formProductDetails.CurrentItem = product;
        formProductDetails.ItemsSource = products
    End Sub

    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim context As New ValidationContext(product, Nothing, Nothing)
        Dim r As ICollection(Of ValidationResult) = New List(Of ValidationResult)()
        Validator.TryValidateObject(product, context, r)
    End Sub
End Class
