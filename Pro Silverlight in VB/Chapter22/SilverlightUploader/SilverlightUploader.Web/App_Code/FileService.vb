Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.IO

<ServiceContract(Namespace:="")> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class FileService

    Private filePath As String

    Public Sub New()
        filePath = HttpContext.Current.Server.MapPath("Files")
    End Sub

    <OperationContract()> _
    Public Function GetFileList() As String()
        ' Scan the folder for files.
        Dim files As String() = Directory.GetFiles(filePath)

        ' Trim out path information.
        For i As Integer = 0 To files.Count() - 1
            files(i) = Path.GetFileName(files(i))
        Next i

        ' Return the file list.
        Return files
    End Function

    <OperationContract()> _
    Public Function DownloadFile(ByVal fileName As String) As Byte()
        ' Make sure the filename has no path information.
        Dim file As String = Path.Combine(filePath, Path.GetFileName(fileName))

        ' Open the file, copy its raw data into a byte array, and return that.
        Using fs As New FileStream(file, FileMode.Open)
            Dim data(fs.Length - 1) As Byte
            fs.Read(data, 0, fs.Length)
            Return data
        End Using
    End Function

    <OperationContract()> _
    Public Sub UploadFile(ByVal fileName As String, ByVal data As Byte())
        ' Make sure the filename has no path information.
        Dim file As String = Path.Combine(filePath, Path.GetFileName(fileName))

        Using fs As New FileStream(file, FileMode.Create)
            fs.Write(data, 0, data.Length)
        End Using
    End Sub

End Class
