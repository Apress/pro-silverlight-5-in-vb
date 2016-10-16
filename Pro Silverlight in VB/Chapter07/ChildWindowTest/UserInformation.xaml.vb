Partial Public Class UserInformation
    Inherits ChildWindow
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.DialogResult = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.DialogResult = False
    End Sub

    Public ReadOnly Property UserName() As String
        Get
            Return txtFirstName.Text & " " & txtLastName.Text
        End Get
    End Property
End Class
