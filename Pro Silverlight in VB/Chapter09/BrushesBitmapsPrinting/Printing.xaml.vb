Imports System.Windows.Printing
Imports System.Windows.Media.Imaging

Partial Public Class Printing
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        For i As Integer = 0 To 49
            lst.Items.Add("This is line number " & i.ToString())
        Next
    End Sub

    Private Sub cmdPrintImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim document As New PrintDocument()
        AddHandler document.PrintPage, AddressOf documentImage_PrintPage
        document.Print("Image Document")
    End Sub

    Private Sub documentImage_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Stretch the image to the size of the printed page.
        Dim imgToPrint As New Image()
        imgToPrint.Source = imgInWindow.Source
        imgToPrint.Width = e.PrintableArea.Width
        imgToPrint.Height = e.PrintableArea.Height

        ' Choose to print the image.
        e.PageVisual = imgToPrint

        ' Do not fire this event again.
        e.HasMorePages = False
    End Sub

    ' Keep track of the position in the list.
    Private listPrintIndex As Integer

    Private Sub cmdPrintList_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Reset the position, in case a previous printout has changed it.
        listPrintIndex = 0

        Dim document As New PrintDocument()
        AddHandler document.PrintPage, AddressOf documentList_PrintPage
        document.Print("List Document")
    End Sub


    ' Add some extra margin space.
    Private extraMargin As Integer = 50

    Private Sub documentList_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Use a Canvas for the printing surface.
        Dim printSurface As New Canvas()
        e.PageVisual = printSurface

        e.HasMorePages = GeneratePage(printSurface, e.PageMargins, e.PrintableArea)
    End Sub

    Private Function GeneratePage(ByVal printSurface As Canvas, ByVal pageMargins As Thickness, ByVal pageSize As Size) As Boolean
        ' Find the starting coordinate.
        Dim topPosition As Double = pageMargins.Top + extraMargin

        ' Begin looping through the list.
        Do While listPrintIndex < lst.Items.Count
            ' Create a TextBlock for each line, with a 30-pixel font.
            Dim txt As New TextBlock()
            txt.FontSize = 30
            txt.Text = lst.Items(listPrintIndex).ToString()

            ' If the new line doesn't fit, stop printing this page,
            ' but request another page.
            Dim measuredHeight As Double = txt.ActualHeight
            If measuredHeight > (pageSize.Height - topPosition - extraMargin) Then
                Return True
            End If

            ' Place the TextBlock on the Canvas.
            txt.SetValue(Canvas.TopProperty, topPosition)
            txt.SetValue(Canvas.LeftProperty, pageMargins.Left + extraMargin)
            printSurface.Children.Add(txt)

            ' Move to the next line.
            listPrintIndex += 1
            topPosition = topPosition + measuredHeight
        Loop

        ' The printing code has reached the end of the list.
        ' No more pages are needed.
        Return False
    End Function

    Private Sub cmdPreviewPrintList_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Reset the position, in case a previous printout has changed it.
        listPrintIndex = 0

        Dim printSurface As New Canvas()
        ' The page information isn't available without starting a real printout,
        ' so we hard-code a typical page size.
        Dim width As Integer = 816
        Dim height As Integer = 1056
        printSurface.Width = width
        printSurface.Height = height
        GeneratePage(printSurface, New Thickness(0), New Size(width, height))

        Dim printPreviewBitmap As New WriteableBitmap(printSurface, Nothing)

        Dim preview As New PrintPreview(printPreviewBitmap)
        preview.Show()
    End Sub

End Class