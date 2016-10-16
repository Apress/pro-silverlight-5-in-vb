Imports System.Windows.Data
Imports System.Globalization

Public Class DateOnlyConverter
    Implements IValueConverter

    Private _shortDate As Boolean
    Public Property ShortDate() As Boolean
        Get
            Return _shortDate
        End Get
        Set(ByVal value As Boolean)
            _shortDate = value
        End Set
    End Property

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object _
      Implements IValueConverter.Convert
        Dim dateValiue As DateTime = CDate(value)
        If ShortDate Then
            Return dateValiue.ToShortDateString()
        Else
            Return dateValiue.ToLongDateString()
        End If
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object _
      Implements IValueConverter.ConvertBack
        Dim dateValue As String = value.ToString()

        Dim result As DateTime
        If DateTime.TryParse(dateValue, result) Then
            Return result
        End If
        Return value
    End Function

End Class

