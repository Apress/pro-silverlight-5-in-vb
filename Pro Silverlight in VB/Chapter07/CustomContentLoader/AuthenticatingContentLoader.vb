Imports System.Windows.Navigation

Public Class AuthenticatingContentLoader
    Implements INavigationContentLoader

    Private _pageResourceContentLoader As New PageResourceContentLoader()

    Public Property LoginPage As String
    Public Property SecuredFolder As String

    Public Function BeginLoad(ByVal targetUri As Uri, ByVal currentUri As Uri, _
      ByVal userCallback As AsyncCallback, ByVal asyncState As Object) As IAsyncResult _
      Implements INavigationContentLoader.BeginLoad

        If Not App.UserIsAuthenticated Then
            If (System.IO.Path.GetDirectoryName(targetUri.ToString()).Trim("\") = SecuredFolder) And (targetUri.ToString() <> LoginPage) Then
                ' Redirect the request to the login page.
                targetUri = New Uri(LoginPage, UriKind.Relative)
            End If
        End If

        Return _pageResourceContentLoader.BeginLoad(targetUri, currentUri, userCallback, asyncState)
    End Function

    Public Sub CancelLoad(ByVal asyncResult As IAsyncResult) _
        Implements INavigationContentLoader.CancelLoad

        _pageResourceContentLoader.CancelLoad(asyncResult)
    End Sub

    Public Function CanLoad(ByVal targetUri As Uri, ByVal currentUri As System.Uri) As Boolean _
        Implements INavigationContentLoader.CanLoad

        Return _pageResourceContentLoader.CanLoad(targetUri, currentUri)
    End Function

    Public Function EndLoad(ByVal asyncResult As IAsyncResult) As LoadResult _
        Implements INavigationContentLoader.EndLoad

        Return _pageResourceContentLoader.EndLoad(asyncResult)
    End Function
End Class
