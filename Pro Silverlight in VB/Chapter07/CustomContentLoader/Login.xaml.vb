Partial Public Class Login
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Use a hard-coded password. A more realistic application would call a remote
        ' authentication service that runs on an ASP.NET website.
        If txtPassword.Text = "secret" Then
            App.UserIsAuthenticated = True
            navigationService.Refresh()
        End If
    End Sub


End Class
