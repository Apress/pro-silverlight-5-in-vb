Partial Public Class WebBrowserTest
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            browser.Navigate(New Uri(txtUrl.Text))
        Catch err As Exception
            MessageBox.Show(err.Message, err.GetType().Name, MessageBoxButton.OK)
        End Try
    End Sub

End Class
