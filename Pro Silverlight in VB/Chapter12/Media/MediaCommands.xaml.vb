Partial Public Class MediaCommands
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdFullScreen_Click(ByVal sender As Object, _
  ByVal e As RoutedEventArgs)
        Application.Current.Host.Content.IsFullScreen = _
          Not Application.Current.Host.Content.IsFullScreen
    End Sub

    Private Sub media_MediaCommand(ByVal sender As Object, ByVal e As MediaCommandEventArgs)
        If e.MediaCommand = System.Windows.Media.MediaCommand.Play Then
            media.Play()
        ElseIf e.MediaCommand = System.Windows.Media.MediaCommand.Pause Then
            media.Pause()
        ElseIf e.MediaCommand = System.Windows.Media.MediaCommand.TogglePlayPause Then
            If media.CurrentState = MediaElementState.Paused OrElse media.CurrentState = MediaElementState.Stopped Then
                media.Play()
            ElseIf media.CurrentState = MediaElementState.Playing Then
                media.Pause()
            End If
        ElseIf e.MediaCommand = System.Windows.Media.MediaCommand.IncreaseVolume Then
            media.Volume += 0.1
        ElseIf e.MediaCommand = System.Windows.Media.MediaCommand.DecreaseVolume Then
            media.Volume -= 0.1
        End If
    End Sub

    Private Sub media_MediaEnded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.Position = TimeSpan.FromSeconds(0)
        media.Play()
    End Sub

End Class
