Partial Public Class ShowChildWindow
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        AddHandler childWindow.Closed, AddressOf childWindow_Closed
    End Sub

    Private childWindow As New UserInformation()

    Private Sub cmdEnterInfo_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        childWindow.Show()
    End Sub

    Private Sub childWindow_Closed(ByVal sender As Object, ByVal e As EventArgs)
        If childWindow.DialogResult = True Then
            lblInfo.Text = "Welcome to this application, " & childWindow.UserName & "."
        End If
    End Sub

End Class
