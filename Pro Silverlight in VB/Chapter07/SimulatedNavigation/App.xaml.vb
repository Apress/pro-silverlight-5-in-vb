Public Enum Pages
    Page
    Page2
End Enum

Public Partial Class App
    Inherits Application

    Public Sub New()
        
        InitializeComponent()
    End Sub

    ' This Grid will host your pages.
    Private rootGrid As New Grid()

    Private Shared pageCache As New Dictionary(Of Pages, UserControl)()

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs) _
      Handles Me.Startup

        ' Load the first page.
        Me.RootVisual = rootGrid
        Navigate(Pages.Page)
    End Sub

    Public Shared Sub Navigate(ByVal newPage As Pages)
        ' Get the current application object and cast it to
        ' an instance of the custom (derived) App class.
        Dim currentApp As App = CType(Application.Current, App)

        ' Check if the page has been created before.
        If Not pageCache.ContainsKey(newPage) Then
            ' Create the first instance of the page,
            ' and cache it for future use.
            Dim type As Type = currentApp.GetType()
            Dim [assembly] As System.Reflection.Assembly = type.Assembly
            pageCache(newPage) = CType([assembly].CreateInstance(type.Namespace & "." & newPage.ToString()), UserControl)
        End If

        ' Change the currently displayed page.
        currentApp.rootGrid.Children.Clear()
        currentApp.rootGrid.Children.Add(pageCache(newPage))
    End Sub

    Private Sub Application_Exit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Exit

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
