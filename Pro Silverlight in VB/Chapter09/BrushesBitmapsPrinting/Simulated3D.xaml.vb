Partial Public Class Simulated3D
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub plusGlobalX_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        projection.GlobalOffsetX += 1
    End Sub

    Private Sub minusGlobalX_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        projection.GlobalOffsetX -= 1
    End Sub

    Private Sub plusLocalX_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        projection.LocalOffsetX += 1
    End Sub

    Private Sub minusLocalX_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        projection.LocalOffsetX -= 1
    End Sub
End Class
