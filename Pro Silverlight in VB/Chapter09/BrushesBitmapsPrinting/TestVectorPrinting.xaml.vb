Imports System.Windows.Printing

Partial Public Class TestVectorPrinting
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdPrintBitmap_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim document As New PrintDocument()
        AddHandler document.PrintPage, AddressOf document_PrintPage

        ' The PrintBitmap() method always uses bitmap printing.
        document.PrintBitmap("My Document - Bitmap Version")
    End Sub

    Private Sub cmdPrintVector_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim document As New PrintDocument()
        AddHandler document.PrintPage, AddressOf document_PrintPage

        ' The Print() method may or may not use vector printing, depending on the
        ' document and printer driver.
        document.Print("My Document")
    End Sub

    Private Sub document_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Use a Canvas for the printing surface.
        Dim printSurface As New Canvas()
        e.PageVisual = printSurface

        Dim topPosition As Double = e.PageMargins.Top + extraMargin
        For i As Integer = 0 To 19
            ' Create a TextBlock.
            Dim txt As New TextBlock()
            txt.FontSize = 30
            txt.Text = "This is a test of vector printing."

            Dim measuredHeight As Double = txt.ActualHeight

            ' Place the TextBlock on the Canvas.
            txt.SetValue(Canvas.TopProperty, topPosition)
            txt.SetValue(Canvas.LeftProperty, e.PageMargins.Left + extraMargin)
            printSurface.Children.Add(txt)

            topPosition += measuredHeight
        Next
        e.HasMorePages = False
    End Sub

    ' Add some extra margin space.
    Private extraMargin As Integer = 50


End Class
