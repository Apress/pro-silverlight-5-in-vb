Imports StoreDbDataClasses

Partial Public Class Validation
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim product As New Product("AEFS100", "Portable Defibrillator", 77.99, "Analyzes the electrical activity of a person's heart and applies an electric shock if necessary.")
        gridProductDetails.DataContext = product
    End Sub
End Class
