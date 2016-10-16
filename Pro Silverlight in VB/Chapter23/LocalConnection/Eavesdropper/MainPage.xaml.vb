Imports System.Windows.Messaging

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private receiver As New LocalMessageReceiver("EavesdropperReceiver")

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        AddHandler receiver.MessageReceived, AddressOf receiver_MessageReceived
        receiver.Listen()
    End Sub

    Private Sub receiver_MessageReceived(ByVal sender As Object, ByVal e As MessageReceivedEventArgs)
        lblDisplay.Text = "The user of Main Application typed: """ & e.Message & """"
    End Sub
End Class