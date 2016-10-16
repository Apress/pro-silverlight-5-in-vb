Partial Public Class MouseWheelZoom
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub Page_MouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
        ' The Delta is in units of 120, so dividing by 120 gives
        ' a scale factor of 1.09 (120/110). In other words, one
        ' mouse wheel notch expands or shrinks the Viewbox by about 9%.
        Dim scalingFactor As Double = CDbl(e.Delta) / 110

        ' Check which way the wheel was turned.
        If scalingFactor > 0 Then
            ' Expand the viewbox.
            viewbox.Width *= scalingFactor
            viewbox.Height *= scalingFactor
        Else
            ' Shrink the viewbox.
            viewbox.Width /= -scalingFactor
            viewbox.Height /= -scalingFactor
        End If
    End Sub

End Class
