Imports System.IO

Partial Public Class RichTextEditor
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdBold_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim selection As TextSelection = richTextBox.Selection

        ' You could check for no selection, but here the code simply applies the bold formatting
        ' to the empty selection (the insertion point), so that when the user starts typing the
        ' new text will be bold.

        ' GetPropertyValue() returns null if the selection has mixed font bolding.
        ' It's up to you what to do in this case, but here the application simply bolds
        ' the entire selection.
        Dim currentState As FontWeight = FontWeights.Normal
        If selection.GetPropertyValue(Run.FontWeightProperty) IsNot DependencyProperty.UnsetValue Then
            currentState = CType(selection.GetPropertyValue(Run.FontWeightProperty), FontWeight)
        End If

        If currentState = FontWeights.Normal Then
            selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold)
        Else
            selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Normal)
        End If

        ' A nice detail is to bring the focus back to the text box, so the user can resume typing.
        richTextBox.Focus()
    End Sub

    Private Sub cmdItalic_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim selection As TextSelection = richTextBox.Selection

        Dim currentState As FontStyle = FontStyles.Normal
        If selection.GetPropertyValue(Run.FontStyleProperty) IsNot DependencyProperty.UnsetValue Then
            currentState = CType(selection.GetPropertyValue(Run.FontStyleProperty), FontStyle)
        End If

        If currentState = FontStyles.Italic Then
            selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Normal)
        Else
            selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic)
        End If

        richTextBox.Focus()
    End Sub

    Private Sub cmdUnderline_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim selection As TextSelection = richTextBox.Selection

        Dim currentState As TextDecorationCollection = Nothing
        If selection.GetPropertyValue(Run.TextDecorationsProperty) IsNot DependencyProperty.UnsetValue Then
            currentState = CType(selection.GetPropertyValue(Run.TextDecorationsProperty), TextDecorationCollection)
        End If

        If currentState IsNot TextDecorations.Underline Then
            selection.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline)
        Else
            selection.ApplyPropertyValue(Run.TextDecorationsProperty, Nothing)
        End If

        richTextBox.Focus()
    End Sub

    Private Sub cmdShowXAML_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        txtFlowDocumentMarkup.Text = richTextBox.Xaml
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "XAML Files (*.xaml)|*.xaml"

        Dim content As String = ""
        If openFile.ShowDialog() = True Then
            Using reader As StreamReader = openFile.File.OpenText()
                content = reader.ReadToEnd()
            End Using

            richTextBox.Xaml = content
            txtFlowDocumentMarkup.Text = ""
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim saveFile As New SaveFileDialog()
        saveFile.Filter = "XAML Files (*.xaml)|*.xaml"

        If saveFile.ShowDialog() = True Then
            Using fs As FileStream = CType(saveFile.OpenFile(), FileStream)
                Dim enc As New System.Text.UTF8Encoding()
                Dim buffer As Byte() = enc.GetBytes(richTextBox.Xaml)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        End If
    End Sub

    Private Sub cmdNew_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        richTextBox.Blocks.Clear()
        txtFlowDocumentMarkup.Text = ""
    End Sub



End Class
