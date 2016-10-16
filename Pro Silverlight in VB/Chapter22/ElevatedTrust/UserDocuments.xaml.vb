Imports System.IO

Partial Public Class UserDocuments
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdWrite_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Directory.CreateDirectory("c:\testetsets")
        If Application.Current.HasElevatedPermissions Then
            Dim documentPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim fileName As String = System.IO.Path.Combine(documentPath, "TestFile.txt")

            Using fs As New FileStream(fileName, FileMode.Create)
                Dim writer As New StreamWriter(fs)
                writer.Write("This is a test with FileStream.")
                writer.Close()
            End Using

            'Or:
            'File.WriteAllText(file, "This is a test.")
            lblResults.Text = ""
            MessageBox.Show("Finished successfully.")
        Else
            MessageBox.Show("Not allowed.")
        End If
    End Sub

    Private Sub cmdRead_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Application.Current.HasElevatedPermissions Then
            Dim documentPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim fileName As String = System.IO.Path.Combine(documentPath, "TestFile.txt")

            If File.Exists(fileName) Then
                Dim contents As String = File.ReadAllText(fileName)
                lblResults.Text = contents
            Else
                MessageBox.Show("No file.")
            End If
        Else
            MessageBox.Show("Not allowed.")
        End If
    End Sub

End Class
