Partial Public Class RichText
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdGenerate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the first part of the sentence.
        Dim runFirst As New Run()
        runFirst.Text = "Hello world of "

        ' Create bolded text.
        Dim bold As New Bold()
        Dim runBold As New Run()
        runBold.Text = "dynamically generated"
        bold.Inlines.Add(runBold)

        ' Create last part of sentence.
        Dim runLast As New Run()
        runLast.Text = " documents"

        ' Add three parts of sentence to a paragraph, in order.
        Dim paragraph As New Paragraph()
        paragraph.Inlines.Add(runFirst)
        paragraph.Inlines.Add(bold)
        paragraph.Inlines.Add(runLast)

        ' Add this paragraph to the RichTextBox.
        richText.Blocks.Clear()
        richText.Blocks.Add(paragraph)
    End Sub

    Private Sub chkReadOnly_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        richText.IsReadOnly = chkReadOnly.IsChecked.Value
    End Sub

End Class
