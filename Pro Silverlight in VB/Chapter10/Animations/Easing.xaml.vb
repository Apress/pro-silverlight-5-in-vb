Partial Public Class Easing
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdGrow_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
        growStoryboard.Begin()
    End Sub

    Private Sub cmdGrow_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
        revertStoryboard.Begin()
    End Sub
End Class
