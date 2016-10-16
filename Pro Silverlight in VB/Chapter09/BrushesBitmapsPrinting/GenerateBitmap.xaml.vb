Imports System.Windows.Media.Imaging

Partial Public Class GenerateBitmap
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdGenerate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the bitmap, with the dimensions of the image placeholder.
        Dim wb As New WriteableBitmap(CInt(img.Width), CInt(img.Height))

        Dim rand As New Random()
        For x As Integer = 0 To wb.PixelWidth - 1
            For y As Integer = 0 To wb.PixelHeight - 1
                Dim alpha As Integer = 255
                Dim red As Integer = 0
                Dim green As Integer = 0
                Dim blue As Integer = 0

                ' Determine the pixel's color.
                If (x Mod 5 = 0) OrElse (y Mod 7 = 0) Then
                    red = CInt(y / wb.PixelHeight * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(x / wb.PixelWidth * 255)
                Else
                    red = CInt(x / wb.PixelWidth * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(y / wb.PixelHeight * 255)
                End If

                ' Set the pixel value.
                Dim pixelColorValue As Integer = (alpha << 24) Or (red << 16) Or (green << 8) Or (blue << 0)

                wb.Pixels(y * wb.PixelWidth + x) = pixelColorValue
            Next
        Next

        ' Show the bitmap in an Image element.
        img.Source = wb
    End Sub

End Class
