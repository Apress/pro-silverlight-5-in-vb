Imports System.Windows.Media.Imaging

Partial Public Class PrintPreview
    Inherits ChildWindow

    Private originalSize As New Point()

    Public Sub New(ByVal printPreviewBitmap As WriteableBitmap)
        InitializeComponent()

        imgPreview.Source = printPreviewBitmap
        imgPreview.Height = printPreviewBitmap.PixelHeight
        imgPreview.Width = printPreviewBitmap.PixelWidth

        originalSize.X = imgPreview.Width
        originalSize.Y = imgPreview.Height
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub sliderZoom_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
        If sliderZoom Is Nothing Then
            Return
        End If

        imgPreview.Height = originalSize.Y * sliderZoom.Value
        imgPreview.Width = originalSize.X * sliderZoom.Value
    End Sub

    Private Sub ChildWindow_LayoutUpdated(ByVal sender As Object, ByVal e As EventArgs)
        ' Make sure window won't collapse below its original bounds
        ' when the slider is used.
        scrollContainer.Width = scrollContainer.ActualWidth
        scrollContainer.Height = scrollContainer.ActualHeight
    End Sub

End Class
