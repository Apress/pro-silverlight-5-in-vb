Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.Runtime.Serialization

<ServiceContract(Namespace:="")> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class ProductAutoComplete

    <OperationContract()> _
    Public Function GetProductMatches(ByVal inputText As String) As String()
        ' Get the products (for example, from a server-side database).
        Dim products As Product() = GetProducts()

        ' Create a collection of matches.
        Dim productMatches As New List(Of String)()
        For Each product As Product In products
            ' See if this is a match.
            If product.ProductName.StartsWith(inputText) OrElse _
             product.ProductCode.Contains(inputText) Then
                productMatches.Add(product.ProductName)
            End If
        Next

        Return productMatches.ToArray()
    End Function

    Private Function GetProducts() As Product()
        Return New Product() {New Product("Peanut Butter Applicator", "C_PBA-01"), New Product("Pelvic Strengthener", "C_PVS-309")}
    End Function

End Class

<DataContract()> _
Public Class Product
    Private _productName As String
    Public Property ProductName() As String
        Get
            Return _productName
        End Get
        Set(ByVal value As String)
            _productName = value
        End Set
    End Property

    Private _productCode As String
    Public Property ProductCode() As String
        Get
            Return _productCode
        End Get
        Set(ByVal value As String)
            _productCode = value
        End Set
    End Property

    Public Sub New(ByVal productName As String, ByVal productCode As String)
        Me.ProductName = productName
        Me.ProductCode = productCode
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return ProductName
    End Function
End Class
