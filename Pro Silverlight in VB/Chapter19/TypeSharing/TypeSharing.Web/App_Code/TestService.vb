Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports DataClasses.ServerSide

<ServiceContract(Namespace:="")>
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class TestService

    <OperationContract()>
    Public Function GetCustomer(ByVal customerID As Integer) As Customer
        Dim newCustomer As New Customer()

        newCustomer.FirstName = "Joe"
        newCustomer.LastName = "Tester"
        Return newCustomer
    End Function
End Class
