Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmd_SetSmall(ByVal sender As Object, ByVal e As RoutedEventArgs)
        sliderFontSize.Value = 2
    End Sub

    Private Sub cmd_SetNormal(ByVal sender As Object, ByVal e As RoutedEventArgs)
        sliderFontSize.Value = Me.FontSize
    End Sub

    Private Sub cmd_SetLarge(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Only works in two-way mode.
        lblSampleText.FontSize = 30
        ' With a one-way binding use:
        'sliderFontSize.Value = 30
    End Sub
End Class