Imports System.Windows.Media.Imaging

Partial Public Class ScreenCapture
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdCapture_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Find the top-level page.
        Dim mainPage As UserControl = CType(Application.Current.RootVisual, UserControl)

        ' Create the bitmap.
        Dim wb As New WriteableBitmap( _
          CInt(mainPage.ActualWidth), CInt(mainPage.ActualHeight))

        ' Copy the content into the bitmap.
        wb.Render(mainPage, Nothing)
        wb.Invalidate()

        ' Show the bitmap. 
        img.Source = wb
    End Sub
End Class
