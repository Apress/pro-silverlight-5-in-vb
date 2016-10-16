Partial Public Class CustomNotification
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Public Property Message() As String
        Get
            Return lblMessage.Text
        End Get
        Set(ByVal value As String)
            lblMessage.Text = value
        End Set
    End Property

End Class
