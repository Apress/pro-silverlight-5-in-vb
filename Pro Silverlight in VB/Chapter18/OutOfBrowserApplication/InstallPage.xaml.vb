Partial Public Class InstallPage
    Inherits UserControl

    Public Sub New 
        InitializeComponent()

        If Application.Current.InstallState = InstallState.Installed Then
            lblMessage.Text = "This application is already installed. " & _
                "You cannot use the browser to run it. " & _
                    "Instead, use the shortcut on your computer."
            cmdInstall.IsEnabled = False
        End If
    End Sub

    Private Sub cmdInstall_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Make sure that the application is not already installed.
        If Application.Current.InstallState <> InstallState.Installed Then
            ' Attempt to install it.
            Dim installAccepted As Boolean = Application.Current.Install()

            If Not installAccepted Then
                lblMessage.Text = "You declined the install. " & _
                  "Click Install to try again."
            Else
                cmdInstall.IsEnabled = False
                lblMessage.Text = "The application is installing... "
            End If
        End If
    End Sub

    Public Sub DisplayInstalled()
        lblMessage.Text = _
          "The application installed and launched. You can close this page."
    End Sub

    Public Sub DisplayFailed()
        lblMessage.Text = "The application failed to install."
        cmdInstall.IsEnabled = True
    End Sub

End Class
