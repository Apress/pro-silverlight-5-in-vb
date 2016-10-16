Partial Public Class CaptureVideo
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private capture As New CaptureSource()

    Private Sub cmdStartCapture_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If CaptureDeviceConfiguration.AllowedDeviceAccess OrElse CaptureDeviceConfiguration.RequestDeviceAccess() Then
            ' Permission has been granted.

            ' It's always safe to call this Stop(), even if no capture is running.
            ' However, calling Start() while a capture is already running causes an error.
            capture.Stop()

            ' Get the default webcam.                
            capture.VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice()
            If capture.VideoCaptureDevice Is Nothing Then
                MessageBox.Show("Your computer does not have a video capture device.")
            Else
                ' Start a new capture.
                capture.Start()

                ' Map the live video to a VideoBrush.
                Dim videoBrush As New VideoBrush()
                videoBrush.Stretch = Stretch.Uniform
                videoBrush.SetSource(capture)

                ' Use the VideoBrush to paint the fill of a Rectangle.
                rectWebcamDisplay.Fill = videoBrush
            End If
        End If
    End Sub

    Private Sub cmdStopCapture_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        capture.Stop()
    End Sub

    Private Sub cmdSnapshot_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If capture.State = CaptureState.Started Then
            AddHandler capture.CaptureImageCompleted, AddressOf capture_CaptureImageCompleted
            capture.CaptureImageAsync()
        End If
    End Sub

    Private Sub capture_CaptureImageCompleted(ByVal sender As Object, ByVal e As CaptureImageCompletedEventArgs)
        imgSnapshot.Source = e.Result
    End Sub

End Class
