Partial Public Class TrickPlay
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub media_MediaEnded(sender As System.Object, e As System.Windows.RoutedEventArgs)
        media.Position = TimeSpan.FromSeconds(0)
        media.Play()
    End Sub
End Class
