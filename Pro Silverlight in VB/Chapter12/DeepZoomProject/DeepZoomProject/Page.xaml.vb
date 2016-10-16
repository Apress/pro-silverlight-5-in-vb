Partial Public Class Page
    Inherits UserControl
    '
    ' Based on prior work done by Lutz Gerhard, Peter Blois, and Scott Hanselman
    '

    Private _zoom As Double = 1
    Private duringDrag As Boolean = False
    Private mouseDown As Boolean = False
    Private lastMouseDownPos As Point = New Point()
    Private lastMousePos As Point = New Point()
    Private lastMouseViewPort As Point = New Point()


    Public Property ZoomFactor() As Double
        Get
            Return _zoom
        End Get
        Set(ByVal value As Double)
            _zoom = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        AddHandler Loaded, AddressOf Page_Loaded

        '
        ' Firing an event when the MultiScaleImage is Loaded
        '
        AddHandler msi.Loaded, AddressOf msi_Loaded

        '
        ' Firing an event when all of the images have been Loaded
        '
        AddHandler msi.ImageOpenSucceeded, AddressOf msi_ImageOpenSucceeded

        '
        ' Handling all of the mouse and keyboard functionality
        '
        AddHandler Me.MouseMove, AddressOf Page_MouseMove

        AddHandler Me.MouseLeftButtonDown, AddressOf Page_MouseLeftButtonDown

        AddHandler Me.MouseLeftButtonUp, AddressOf Page_MouseLeftButtonUp

        AddHandler CType(New MouseWheelHelper(Me), MouseWheelHelper).Moved, AddressOf MouseWheelHelper_Moved
    End Sub

    Private Sub Page_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        lastMousePos = e.GetPosition(msi)

        If mouseDown AndAlso (Not duringDrag) Then
            duringDrag = True
            Dim w As Double = msi.ViewportWidth
            Dim o As Point = New Point(msi.ViewportOrigin.X, msi.ViewportOrigin.Y)
            msi.UseSprings = False
            msi.ViewportOrigin = New Point(o.X, o.Y)
            msi.ViewportWidth = w
            _zoom = 1 / w
            msi.UseSprings = True
        End If
        If duringDrag Then
            Dim newPoint As Point = lastMouseViewPort
            newPoint.X += (lastMouseDownPos.X - lastMousePos.X) / msi.ActualWidth * msi.ViewportWidth
            newPoint.Y += (lastMouseDownPos.Y - lastMousePos.Y) / msi.ActualWidth * msi.ViewportWidth
            msi.ViewportOrigin = newPoint
        End If
    End Sub

    Private Sub Page_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        lastMouseDownPos = e.GetPosition(msi)
        lastMouseViewPort = msi.ViewportOrigin
        mouseDown = True
        msi.CaptureMouse()
    End Sub

    Private Sub Page_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        If (Not duringDrag) Then
            Dim shiftDown As Boolean = (Keyboard.Modifiers And ModifierKeys.Shift) = ModifierKeys.Shift
            Dim newzoom As Double = _zoom
            If shiftDown Then
                newzoom /= 2
            Else
                newzoom *= 2
            End If
            Zoom(newzoom, msi.ElementToLogicalPoint(Me.lastMousePos))
        End If
        duringDrag = False
        mouseDown = False
        msi.ReleaseMouseCapture()
    End Sub


    Private Sub MouseWheelHelper_Moved(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
        e.Handled = True
        Dim newzoom As Double = _zoom
        If e.Delta < 0 Then
            newzoom /= 1.3
        Else
            newzoom *= 1.3
        End If
        Zoom(newzoom, msi.ElementToLogicalPoint(Me.lastMousePos))
        msi.CaptureMouse()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim path As String = App.Current.Resources("path").ToString()
        Dim zoomIn As String = App.Current.Resources("zoomIn").ToString()

        Me.msi.Source = New DeepZoomImageTileSource(New Uri(path, UriKind.Relative))
        _zoom = Int32.Parse(zoomIn)
    End Sub

    Private Sub msi_ImageOpenSucceeded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        msi.ViewportWidth = 1
    End Sub

    Private Sub msi_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

    End Sub

    Private Sub Zoom(ByVal newzoom As Double, ByVal p As Point)
        If newzoom < 0.5 Then
            newzoom = 0.5
        End If

        msi.ZoomAboutLogicalPoint(newzoom / _zoom, p.X, p.Y)
        _zoom = newzoom
    End Sub

    Private Sub ZoomInClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Zoom(_zoom * 1.3, msi.ElementToLogicalPoint(New Point(0.5 * msi.ActualWidth, 0.5 * msi.ActualHeight)))
    End Sub

    Private Sub ZoomOutClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Zoom(_zoom / 1.3, msi.ElementToLogicalPoint(New Point(0.5 * msi.ActualWidth, 0.5 * msi.ActualHeight)))
    End Sub

    Private Sub GoHomeClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.msi.ViewportWidth = 1
        Me.msi.ViewportOrigin = New Point(0, 0)
        ZoomFactor = 1
    End Sub

    Private Sub GoFullScreenClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        If (Not Application.Current.Host.Content.IsFullScreen) Then
            Application.Current.Host.Content.IsFullScreen = True
        Else
            Application.Current.Host.Content.IsFullScreen = False
        End If
    End Sub

    ' Handling the VSM states
    Private Sub LeaveMovie(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        VisualStateManager.GoToState(Me, "FadeOut", True)
    End Sub

    Private Sub EnterMovie(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        VisualStateManager.GoToState(Me, "FadeIn", True)
    End Sub


    ' unused functions that show the inner math of Deep Zoom
    Public Function getImageRect() As Rect
        Return New Rect(-msi.ViewportOrigin.X / msi.ViewportWidth, -msi.ViewportOrigin.Y / msi.ViewportWidth, 1 / msi.ViewportWidth, 1 / msi.ViewportWidth * msi.AspectRatio)
    End Function

    Public Function ZoomAboutPoint(ByVal img As Rect, ByVal zAmount As Double, ByVal pt As Point) As Rect
        Return New Rect(pt.X + (img.X - pt.X) / zAmount, pt.Y + (img.Y - pt.Y) / zAmount, img.Width / zAmount, img.Height / zAmount)
    End Function

    Public Sub LayoutDZI(ByVal rect As Rect)
        Dim ar As Double = msi.AspectRatio
        msi.ViewportWidth = 1 / rect.Width
        msi.ViewportOrigin = New Point(-rect.Left / rect.Width, -rect.Top / rect.Width)
    End Sub
End Class
