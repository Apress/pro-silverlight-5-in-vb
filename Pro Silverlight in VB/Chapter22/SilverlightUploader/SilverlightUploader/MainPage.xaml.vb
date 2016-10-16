Imports SilverlightUploader.Services
Imports System.ServiceModel
Imports System.IO
Imports System.Windows.Browser

Partial Public Class MainPage
    Inherits UserControl

    Dim client As New FileServiceClient()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Make sure the dyanmic URL is set (for testing).
        Dim address As EndpointAddress = New EndpointAddress("http://localhost:" & _
          HtmlPage.Document.DocumentUri.Port & _
          "/SilverlightUploader.Web/FileService.svc")
        client.Endpoint.Address = address

        ' Attach these event handlers for uploads and downloads.
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadFileCompleted
        AddHandler client.UploadFileCompleted, AddressOf client_UploadFileCompleted

        ' Get the initial file list.
        AddHandler client.GetFileListCompleted, AddressOf client_GetFileListCompleted
        client.GetFileListAsync()
    End Sub

    Private Sub client_GetFileListCompleted(ByVal sender As Object, _
      ByVal e As GetFileListCompletedEventArgs)
        Try
            lstFiles.ItemsSource = e.Result
        Catch
            lblStatus.Text = "Error contacting web service."
        End Try
    End Sub

    Private Sub cmdDownload_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If lstFiles.SelectedIndex <> -1 Then
            Dim saveDialog As New SaveFileDialog()
            If saveDialog.ShowDialog() = True Then
                client.DownloadFileAsync(lstFiles.SelectedItem.ToString(), saveDialog)
                lblStatus.Text = "Download started."
            End If
        End If
    End Sub

    Private Sub client_DownloadFileCompleted(ByVal sender As Object, _
      ByVal e As DownloadFileCompletedEventArgs)
        If e.Error Is Nothing Then
            lblStatus.Text = "Download completed."

            ' Get the SaveFileDialog that was passed in with the call.
            Dim saveDialog As SaveFileDialog = CType(e.UserState, SaveFileDialog)

            Using stream As Stream = saveDialog.OpenFile()
                stream.Write(e.Result, 0, e.Result.Length)
            End Using
            lblStatus.Text = "File saved to " & saveDialog.SafeFileName
        Else
            lblStatus.Text = "Download failed."
        End If
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim openDialog As New OpenFileDialog()

        If openDialog.ShowDialog() = True Then
            Try
                Using stream As Stream = openDialog.File.OpenRead()
                    ' Don't allow really big files (more than 5 MB).
                    If stream.Length < 5120000 Then
                        Dim data(stream.Length - 1) As Byte
                        stream.Read(data, 0, stream.Length)

                        client.UploadFileAsync(openDialog.File.Name, data)
                        lblStatus.Text = "Upload started."
                    Else
                        lblStatus.Text = "Files must be less than 5 MB."
                    End If
                End Using
            Catch
                lblStatus.Text = "Error reading file."
            End Try
        End If
    End Sub

    Private Sub client_UploadFileCompleted(ByVal sender As Object, _
      ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Error Is Nothing Then
            lblStatus.Text = "Upload succeeded."

            ' Refresh the file list.
            client.GetFileListAsync()
        Else
            lblStatus.Text = "Upload failed."
        End If
    End Sub

End Class