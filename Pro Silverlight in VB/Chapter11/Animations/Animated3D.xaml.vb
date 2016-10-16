Partial Public Class Animated3D
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        spinStoryboard.Begin()
    End Sub
End Class
