Imports DataBinding.Local

Partial Public Class ValidateProductObject
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim product As New Product("AEFS100", "Portable Defibrillator", 77, "Analyzes the electrical activity of a person's heart and applies an electric shock if necessary.")
        gridProductDetails.DataContext = product
    End Sub

    Private Sub Grid_BindingValidationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
        If Not e.Error.Exception Is Nothing Then
            ' Validation failed due to an exception.
            lblInfo.Text = e.Error.Exception.Message
            lblInfo.Text += Constants.vbLf & "The stored UnitCost is still: " & (CType(gridProductDetails.DataContext, Product)).UnitCost.ToString()
            txtUnitCost.Focus()
        Else
            ' Validation error reported through an interface.
            Dim product As Product = CType(gridProductDetails.DataContext, Product)
            If product.HasErrors Then
                lblInfo.Text = e.Error.ErrorContent.ToString()
                lblInfo.Text += Constants.vbLf & "However, the stored ModelNumber is now: " & (CType(gridProductDetails.DataContext, Product)).ModelNumber
                txtModelNumber.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        lblInfo.Text = ""
    End Sub
End Class
