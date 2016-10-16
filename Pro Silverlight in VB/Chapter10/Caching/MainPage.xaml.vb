Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        storyboard.Begin()
    End Sub

    Private Sub chkCache_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If chkCache.IsChecked = True Then
            Dim bitmapCache As New BitmapCache()
            bitmapCache.RenderAtScale = 5
            cmd.CacheMode = bitmapCache
            'img.CacheMode = New BitmapCache()
        Else
            cmd.CacheMode = Nothing
            'img.CacheMode = Nothing
        End If
    End Sub

End Class