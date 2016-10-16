Imports System.IO
Imports System.Windows.Media.Imaging

Partial Public Class DropTarget
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub rectDropSurface_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        lblResults.Text = "You are dragging an object over the drop area."
    End Sub

    Private Sub rectDropSurface_DragLeave(ByVal sender As Object, ByVal e As DragEventArgs)
        lblResults.Text = ""
    End Sub

    Private Sub rectDropSurface_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
        ' Check if data is present and in the correct format.
        If (e.Data IsNot Nothing) AndAlso (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            ' Get all the files that were dropped.                
            Dim files As FileInfo() = CType(e.Data.GetData(DataFormats.FileDrop), FileInfo())

            For Each file As FileInfo In files
                ' If you aren't running in an eleveated trust, you can't access
                ' the full path information exposed by the properties of FileInfo.
                ' However, the no-path file name (the Name property) is accessible.
                Dim ext As String = System.IO.Path.GetExtension(file.Name)

                ' Check if it's an image.
                Select Case ext.ToLower()
                    Case ".jpg", ".gif", ".png", ".bmp"
                        Try
                            ' Read the image, wrap it in a BitmapImage, and
                            ' add it to the list.
                            Using fs As FileStream = file.OpenRead()
                                Dim source As New BitmapImage()
                                source.SetSource(fs)
                                lstImages.Items.Add(source)
                            End Using
                        Catch err As Exception
                            lblResults.Text = "Error reading file: " & err.Message
                        End Try

                    Case Else
                        lblResults.Text = "The dropped file was not recognized as a supported image type."
                End Select

                lblResults.Text = files.Count().ToString() & " files successfully dropped."
            Next
        End If
    End Sub

End Class
