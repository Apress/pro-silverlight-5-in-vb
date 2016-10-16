Imports System.Runtime.Serialization

<DataContract(Name:="Customer", _
 Namespace:="http://www.prosetech.com/DataClasses/Customer")> _
Public Class Customer
    Private _firstName As String
    Private _lastName As String

    <DataMember()> _
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    <DataMember()> _
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    ' Ordinarily, this method would not be available on the client.
    Public Function GetFullName() As String
        Return FirstName & " " & LastName
    End Function
End Class
