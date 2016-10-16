Imports System.ComponentModel.DataAnnotations

Public Class ProductValidation
    Public Shared Function ValidateUnitCost(ByVal value As Double, ByVal context As ValidationContext) As ValidationResult
        Dim valueString As String = value.ToString()
        Dim cents As String = ""
        Dim decimalPosition As Integer = valueString.IndexOf(".")
        If decimalPosition <> -1 Then
            cents = valueString.Substring(decimalPosition)
        End If

        If (cents <> ".75") AndAlso (cents <> ".99") AndAlso (cents <> ".95") Then
            Return New ValidationResult("Retail prices must end with .75, .95, or .99 to be valid.")
        Else
            Return ValidationResult.Success
        End If

    End Function

    Public Shared Function ValidateProduct(ByVal product As Product, ByVal context As ValidationContext) As ValidationResult
        If product.ModelName = product.ModelNumber Then
            Return New ValidationResult("You can't use the same model number as the model name.")
        Else
            Return ValidationResult.Success
        End If
    End Function
End Class
