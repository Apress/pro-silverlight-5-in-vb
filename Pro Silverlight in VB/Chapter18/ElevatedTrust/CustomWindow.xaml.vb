Partial Public Class CustomWindow
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Property CurrentWindow() As Window

    Private Sub titleBar_MouseLeftButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        CurrentWindow.DragMove()
    End Sub

    Private Sub cmdMinimize_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        CurrentWindow.WindowState = WindowState.Minimized
    End Sub

    Private Sub cmdMaximize_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If CurrentWindow.WindowState = WindowState.Normal Then
            CurrentWindow.WindowState = WindowState.Maximized
        Else
            CurrentWindow.WindowState = WindowState.Normal
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        CurrentWindow.Close()
    End Sub

    Private Sub rect_Resize(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        If sender Is rect_TopLeftCorner Then
            CurrentWindow.DragResize(WindowResizeEdge.TopLeft)
        ElseIf sender Is rect_TopEdge Then
            CurrentWindow.DragResize(WindowResizeEdge.Top)
        ElseIf sender Is rect_TopRightCorner Then
            CurrentWindow.DragResize(WindowResizeEdge.TopRight)
        ElseIf sender Is rect_LeftEdge Then
            CurrentWindow.DragResize(WindowResizeEdge.Left)
        ElseIf sender Is rect_RightEdge Then
            CurrentWindow.DragResize(WindowResizeEdge.Right)
        ElseIf sender Is rect_BottomLeftCorner Then
            CurrentWindow.DragResize(WindowResizeEdge.BottomLeft)
        ElseIf sender Is rect_BottomEdge Then
            CurrentWindow.DragResize(WindowResizeEdge.Bottom)
        ElseIf sender Is rect_BottomRightCorner Then
            CurrentWindow.DragResize(WindowResizeEdge.BottomRight)
        End If
    End Sub
End Class
