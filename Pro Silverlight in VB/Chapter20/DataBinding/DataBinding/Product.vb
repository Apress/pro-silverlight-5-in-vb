Imports System.ComponentModel

Namespace Local
    Public Class Product
        Implements INotifyPropertyChanged, INotifyDataErrorInfo

        Private _modelNumber As String
        Public Property ModelNumber() As String
            Get
                Return _modelNumber
            End Get
            Set(ByVal value As String)
                _modelNumber = value

                Dim valid As Boolean = True
                For Each c As Char In _modelNumber
                    If (Not Char.IsLetterOrDigit(c)) Then
                        valid = False
                        Exit For
                    End If
                Next
                If (Not valid) Then
                    Dim errors As List(Of String) = New List(Of String)()
                    errors.Add("The ModelNumber can only contain letters and numbers.")
                    SetErrors("ModelNumber", errors)
                Else
                    ClearErrors("ModelNumber")
                End If

                OnPropertyChanged(New PropertyChangedEventArgs("ModelNumber"))
            End Set
        End Property

        Private _modelName As String
        Public Property ModelName() As String
            Get
                Return _modelName
            End Get
            Set(ByVal value As String)
                _modelName = value
                OnPropertyChanged(New PropertyChangedEventArgs("ModelName"))
            End Set
        End Property

        Private unitCost_ As Double
        Public Property UnitCost() As Double
            Get
                Return unitCost_
            End Get
            Set(ByVal value As Double)
                If value < 0 Then
                    Throw New ArgumentException("Can't be less than 0.")
                End If

                unitCost_ = value
                OnPropertyChanged(New PropertyChangedEventArgs("UnitCost"))
            End Set
        End Property

        Private _description As String
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
                OnPropertyChanged(New PropertyChangedEventArgs("Description"))
            End Set
        End Property

        Private _categoryName As String
        Public Property CategoryName() As String
            Get
                Return _categoryName
            End Get
            Set(ByVal value As String)
                _categoryName = value
            End Set
        End Property

        Private _productImagePath As String
        Public Property ProductImagePath() As String
            Get
                Return _productImagePath
            End Get
            Set(ByVal value As String)
                _productImagePath = value
            End Set
        End Property

        Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Double, ByVal description As String)
            Me.ModelNumber = modelNumber
            Me.ModelName = modelName
            Me.UnitCost = unitCost
            Me.Description = description
        End Sub

        Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Double, ByVal description As String, ByVal productImagePath As String)
            Me.New(modelNumber, modelName, unitCost, description)
            Me.ProductImagePath = productImagePath
        End Sub

        Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Double, ByVal description As String, ByVal categoryName As String, ByVal productImagePath As String)
            Me.New(modelNumber, modelName, unitCost, description)
            Me.CategoryName = categoryName
            Me.ProductImagePath = productImagePath
        End Sub

        Public Sub New()
        End Sub

        Public Overrides Function ToString() As String
            Return ModelName & " (" & ModelNumber & ")"
        End Function


        ' Track all errors. This collection is indexed by property name.
        ' Each property can have a colleciton of multiple errors.
        Private errors As New Dictionary(Of String, List(Of String))()

        Private Sub SetErrors(ByVal propertyName As String, ByVal propertyErrors As List(Of String))
            ' Add the error collection for a property.
            errors.Remove(propertyName)
            errors.Add(propertyName, propertyErrors)

            ' Raise the error-notification event.
            RaiseEvent ErrorsChanged(Me, New DataErrorsChangedEventArgs(propertyName))
        End Sub

        Private Sub ClearErrors(ByVal propertyName As String)
            errors.Remove(propertyName)

            ' Raise the error-notification event.
            RaiseEvent ErrorsChanged(Me, New DataErrorsChangedEventArgs(propertyName))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
            If Not PropertyChangedEvent Is Nothing Then
                RaiseEvent PropertyChanged(Me, e)
            End If
        End Sub

        Public Event ErrorsChanged(ByVal sender As Object, ByVal e As System.ComponentModel.DataErrorsChangedEventArgs) _
            Implements INotifyDataErrorInfo.ErrorsChanged

        Public Function GetErrors(ByVal propertyName As String) As System.Collections.IEnumerable _
            Implements System.ComponentModel.INotifyDataErrorInfo.GetErrors

            If propertyName = "" Then
                ' Provide all the error collections.
                Return (errors.Values)
            Else
                ' Provice the error collection for the requested property (if it has errors).
                If errors.ContainsKey(propertyName) Then
                    Return (errors(propertyName))
                Else
                    Return Nothing
                End If
            End If
        End Function

        Public ReadOnly Property HasErrors As Boolean Implements INotifyDataErrorInfo.HasErrors
            Get
                ' Indicate whether this entire object is error-free.
                Return (errors.Count > 0)
            End Get
        End Property
    End Class

End Namespace
