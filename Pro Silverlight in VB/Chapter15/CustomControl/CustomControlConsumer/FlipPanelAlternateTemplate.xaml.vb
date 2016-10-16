Partial Public Class FlipPanelAlternateTemplate
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdFlip_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        panel.IsFlipped = Not panel.IsFlipped
    End Sub

End Class
