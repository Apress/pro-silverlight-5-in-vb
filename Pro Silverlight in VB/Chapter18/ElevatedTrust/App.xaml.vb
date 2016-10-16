 Partial Public Class App
    Inherits Application

    public Sub New()
        InitializeComponent()
    End Sub
    
    Private Sub Application_Startup(ByVal o As Object, ByVal e As StartupEventArgs) Handles Me.Startup
        If Application.Current.IsRunningOutOfBrowser Then
            ' Check for updates.
            AddHandler Application.Current.CheckAndDownloadUpdateCompleted, AddressOf Application_CheckAndDownloadUpdateCompleted
            Application.Current.CheckAndDownloadUpdateAsync()
        End If

        Me.RootVisual = New MenuPage()

        ' Use this line to show the custom window.
        ' Make sure you first change the window state to "No Border" or "Borderless Round Corners" in the Out-of-Browser Settings window.
        'Me.RootVisual = New CustomWindow()
    End Sub

    Private Sub Application_CheckAndDownloadUpdateCompleted(ByVal sender As Object, ByVal e As CheckAndDownloadUpdateCompletedEventArgs)
        If e.UpdateAvailable Then
            MessageBox.Show("A new version has been installed. Please restart the application.")
            Application.Current.MainWindow.Close()
        ElseIf Not e.Error Is Nothing Then
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

    
    Private Sub Application_Exit(ByVal o As Object, ByVal e As EventArgs) Handles Me.Exit

    End Sub
    
    Private Sub Application_UnhandledException(ByVal sender As object, ByVal e As ApplicationUnhandledExceptionEventArgs) Handles Me.UnhandledException

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
