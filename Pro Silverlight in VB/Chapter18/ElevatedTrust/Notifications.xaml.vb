Partial Public Class Notifications
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private window As New NotificationWindow()
    Private Sub cmdNotify_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Application.Current.HasElevatedPermissions Then
            Dim notification As New CustomNotification()
            notification.Message = "You have just been notified. The time is " & DateTime.Now.ToLongTimeString() & "."
            window.Content = notification

            window.Close()
            window.Show(5000)
        Else
            MessageBox.Show("This feature is not available while you are running in the browser with low trust.")
            ' (Implement a different notification strategy here.)
        End If
    End Sub

End Class
