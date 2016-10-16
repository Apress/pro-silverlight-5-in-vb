Partial Public Class BlurringButtons
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmd_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
        blurStoryboard.Stop()
        Storyboard.SetTarget(blurStoryboard, (CType(sender, Button)).Effect)
        blurStoryboard.Begin()
    End Sub

    Private Sub cmd_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
        unblurStoryboard.Stop()
        Storyboard.SetTarget(unblurStoryboard, (CType(sender, Button)).Effect)
        unblurStoryboard.Begin()
    End Sub
End Class
