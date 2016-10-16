Partial Public Class DynamicStyles
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub chkAlternate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If chkAlternate.IsChecked = True Then
            Dim resourceDictionary As New ResourceDictionary()
            resourceDictionary.Source = New Uri("/Styles/AlternateStyles.xaml", UriKind.Relative)
            Dim newStyle As Style = CType(resourceDictionary("BigButtonStyle"), Style)
            cmd1.Style = newStyle
        Else
            cmd1.Style = CType(Me.Resources("BigButtonStyle"), Style)
        End If
        cmd2.Style = cmd1.Style
    End Sub
End Class
