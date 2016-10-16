Imports System.IO

Partial Public Class SaveFile
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdSaveFile_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Text Files (*.txt)|*.txt"
        saveDialog.DefaultExt = "txt"

        If saveDialog.ShowDialog() = True Then
            Using stream As Stream = saveDialog.OpenFile()
                Using writer As New StreamWriter(stream)
                    writer.Write(txtData.Text)
                End Using
            End Using
            lblFileName.Text = "Saved " & saveDialog.SafeFileName
        End If
    End Sub
End Class
