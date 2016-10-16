Imports System.IO

Partial Public Class ManageDirectories
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdCreate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' (Of course, a real-world version of this method needs error handling to catch directories that can't be created.)

        Dim dir As String = txtDir.Text

        Directory.CreateDirectory(dir)
        Dim newFile As String = txtFile.Text

        ' Use the System.IO.Path class to safely combine file paths, without worrying about
        ' extra backslashes. You must fully qualify the path name to avoid referring to 
        ' System.Windows.Shapes.Path.            
        Dim filePath As String = System.IO.Path.Combine(dir, newFile)
        File.WriteAllText(filePath, "This is a test file in a new directory!")

        MessageBox.Show("Successfully created.")
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' (Of course, a real-world version of this method needs error handling to catch directories that can't be deleted.)

        Dim dir As String = txtDir.Text
        If (Not Directory.Exists(dir)) Then
            MessageBox.Show("There is no such directory.")
        Else
            Directory.Delete(dir, True)
            MessageBox.Show("Successfully deleted.")
        End If
    End Sub

End Class
