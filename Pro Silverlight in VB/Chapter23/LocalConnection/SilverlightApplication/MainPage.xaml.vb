Imports System.Windows.Messaging

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private messageSender As New LocalMessageSender("EavesdropperReceiver")

    Private Sub txt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        messageSender.SendAsync(txt.Text)
    End Sub
End Class