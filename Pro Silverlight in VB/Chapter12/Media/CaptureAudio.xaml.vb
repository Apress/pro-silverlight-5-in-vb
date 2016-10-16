Imports System.IO

Partial Public Class CaptureAudio
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private audioSink As MemoryStreamAudioSink

    ' You must hold a separate reference to the CaptureSource to prevent
    ' exceptions when calling CaptureSource.Stop() on long clips.
    Private capture As CaptureSource

    Private Sub cmdStartRecord_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If CaptureDeviceConfiguration.AllowedDeviceAccess OrElse CaptureDeviceConfiguration.RequestDeviceAccess() Then
            If audioSink Is Nothing Then
                capture = New CaptureSource()
                capture.AudioCaptureDevice = CaptureDeviceConfiguration.GetDefaultAudioCaptureDevice()

                audioSink = New MemoryStreamAudioSink()
                audioSink.CaptureSource = capture
            Else
                audioSink.CaptureSource.Stop()
            End If

            audioSink.CaptureSource.Start()
            cmdStartRecord.IsEnabled = False

            ' Add a delay to make sure the recording is initialized.
            ' (Otherwise, a user may cause an error by attempting to stop it immediately.)
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.5))
            cmdStopRecord.IsEnabled = True

            lblStatus.Text = "Now recording ..."
        End If
    End Sub

    Private Sub cmdStopRecord_Click(ByVal sender As Object, ByVal args As RoutedEventArgs)
        audioSink.CaptureSource.Stop()

        cmdPlayClip.IsEnabled = True
        cmdStopRecord.IsEnabled = False
        cmdStartRecord.IsEnabled = True
        lblStatus.Text = "Finished recording. A clip is available to play."
    End Sub

    Private Sub cmdPlayClip_Click(ByVal sender As Object, ByVal args As RoutedEventArgs)
        ' Play the audio.
        Dim wavMss As New WaveMSS.WaveMediaStreamSource(audioSink.AudioData)
        media.SetSource(wavMss)
    End Sub

End Class
