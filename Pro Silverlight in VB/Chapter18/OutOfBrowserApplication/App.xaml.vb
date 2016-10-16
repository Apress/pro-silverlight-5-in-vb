Imports System.IO.IsolatedStorage
Imports System.IO

Partial Public Class App
    Inherits Application

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Application_Startup(ByVal o As Object, ByVal e As StartupEventArgs) _
      Handles Me.Startup

        If Application.Current.IsRunningOutOfBrowser Then
            ' Check for updates.
            Application.Current.CheckAndDownloadUpdateAsync()

            ' Restore the window state.
            Try
                Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()

                If store.FileExists("window.Settings") Then
                    Using fs As IsolatedStorageFileStream = store.OpenFile("window.Settings", FileMode.Open)
                        Dim r As New BinaryReader(fs)
                        Application.Current.MainWindow.Top = r.ReadDouble()
                        Application.Current.MainWindow.Left = r.ReadDouble()
                        Application.Current.MainWindow.Width = r.ReadDouble()
                        Application.Current.MainWindow.Height = r.ReadDouble()
                        r.Close()
                    End Using
                End If
            Catch err As Exception
                ' Can't restore the window details. No need to report the error.
            End Try

            ' Show the full user interface.
            Me.RootVisual = New MainPage()
        Else
            ' Show a window with an installation message and an Install button.
            Me.RootVisual = New InstallPage()
        End If
    End Sub

    Private Sub Application_CheckAndDownloadUpdateCompleted(ByVal o As Object, _
      ByVal e As CheckAndDownloadUpdateCompletedEventArgs) Handles Me.CheckAndDownloadUpdateCompleted

        If e.UpdateAvailable Then
            MessageBox.Show("A new version has been installed. " & _
              "Please restart the application.")
            ' (You could add code here to call a custom method in MainPage
            '  that disables the user interface.)
        ElseIf e.Error IsNot Nothing Then
            If TypeOf e.Error Is PlatformNotSupportedException Then
                MessageBox.Show("An application update is available, " & _
                  "but it requires a new version of Silverlight. " & _
                  "Visit http://silverlight.net to upgrade.")
            Else
                MessageBox.Show("An application update is available, " & _
                  "but it cannot be installed. Please remove the current version " & _
                  "before installing the new version.")
            End If
        End If
    End Sub


    Private Sub Application_InstallStateChanged(ByVal o As Object, ByVal e As EventArgs) _
      Handles Me.InstallStateChanged

        Dim page As InstallPage = TryCast(Me.RootVisual, InstallPage)
        If page IsNot Nothing Then
            ' Tell the root visual to show a message by calling a method
            ' in InstallPage that updates the display.
            Select Case Me.InstallState
                Case InstallState.InstallFailed
                    page.DisplayFailed()
                Case InstallState.Installed
                    page.DisplayInstalled()
            End Select
        End If
    End Sub

    Private Sub Application_Exit(ByVal o As Object, ByVal e As EventArgs) Handles Me.Exit
        If Application.Current.IsRunningOutOfBrowser Then
            ' Store window state.            
            Try
                Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()

                Using fs As IsolatedStorageFileStream = store.CreateFile("window.Settings")
                    Dim w As New BinaryWriter(fs)
                    w.Write(Application.Current.MainWindow.Top)
                    w.Write(Application.Current.MainWindow.Left)
                    w.Write(Application.Current.MainWindow.Width)
                    w.Write(Application.Current.MainWindow.Height)
                    w.Close()
                End Using
            Catch err As Exception
                ' Can't save the window details. No need to report the error.
            End Try
        End If

    End Sub

    Private Sub Application_UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs) Handles Me.UnhandledException

        ' If the app is running outside of the debugger then report the exception using
        ' the browser's exception mechanism. On IE this will display it a yellow alert 
        ' icon in the status bar and Firefox will display a script error.
        If Not System.Diagnostics.Debugger.IsAttached Then

            ' NOTE: This will allow the application to continue running after an exception has been thrown
            ' but not handled. 
            ' For production applications this error handling should be replaced with something that will 
            ' report the error to the website and stop the application.
            e.Handled = True
            Deployment.Current.Dispatcher.BeginInvoke(New Action(Of ApplicationUnhandledExceptionEventArgs)(AddressOf ReportErrorToDOM), e)
        End If
    End Sub

    Private Sub ReportErrorToDOM(ByVal e As ApplicationUnhandledExceptionEventArgs)

        Try
            Dim errorMsg As String = e.ExceptionObject.Message + e.ExceptionObject.StackTrace
            errorMsg = errorMsg.Replace(""""c, "'"c).Replace(ChrW(13) & ChrW(10), "\n")

            System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(""Unhandled Error in Silverlight Application " + errorMsg + """);")
        Catch

        End Try
    End Sub

End Class
