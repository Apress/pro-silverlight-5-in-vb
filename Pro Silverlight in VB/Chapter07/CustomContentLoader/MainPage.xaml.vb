Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdNavigate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mainFrame.Navigate(New Uri("/SecurePages/Page1.xaml", UriKind.Relative))
    End Sub

End Class