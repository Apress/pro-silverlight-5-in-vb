Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations


<DataContract(Name:="Product", Namespace:="http://www.prosetech.com/StoreDb/Product"), CustomValidation(GetType(ProductValidation), "ValidateProduct")> _
Public Class Product
    Implements INotifyPropertyChanged

    Private _hasChanges As Boolean = False
    Public Property HasChanges() As Boolean
        Get
            Return _hasChanges
        End Get
        Set(ByVal value As Boolean)
            _hasChanges = value
        End Set
    End Property

    Private _modelNumber As String
    <DataMember(), StringLength(25), Display(Name:="Model Number", Description:="This is the alphanumeric product tag used in the warehouse."), Required()> _
    Public Property ModelNumber() As String
        Get
            Return _modelNumber
        End Get
        Set(ByVal value As String)
            ' Explicitly raise an exception if a data annotation attribute
            ' fails validation.
            Dim context As ValidationContext = New ValidationContext(Me, Nothing, Nothing)
            context.MemberName = "ModelNumber"
            Validator.ValidateProperty(value, context)

            _modelNumber = value
            OnPropertyChanged(New PropertyChangedEventArgs("ModelNumber"))
        End Set
    End Property

    Private _modelName As String
    <DataMember(), Display(Name:="Model Name", Description:="This is the retail product name."), Required(), StringLength(Int32.MaxValue, MinimumLength:=5)> _
    Public Property ModelName() As String
        Get
            Return _modelName
        End Get
        Set(ByVal value As String)
            Dim context As ValidationContext = New ValidationContext(Me, Nothing, Nothing)
            context.MemberName = "ModelName"
            Validator.ValidateProperty(value, context)

            _modelName = value
            OnPropertyChanged(New PropertyChangedEventArgs("ModelName"))
        End Set
    End Property

    Private _unitCost As Double
    <DataMember(), Display(Name:="Unit Cost", Description:="This is retail price."), CustomValidation(GetType(ProductValidation), "ValidateUnitCost")> _
    Public Property UnitCost() As Double
        Get
            Return _unitCost
        End Get
        Set(ByVal value As Double)
            If value < 0 Then
                Throw New ArgumentException("Can't be less than 0.")
            End If
            Dim context As ValidationContext = New ValidationContext(Me, Nothing, Nothing)
            context.MemberName = "UnitCost"
            'Validator.ValidateProperty(value, context)

            _unitCost = value
            OnPropertyChanged(New PropertyChangedEventArgs("UnitCost"))
        End Set
    End Property

    Private _description As String
    <DataMember(), Display(Name:="Description", Description:="This is the catalog text for the item.")> _
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
    <DataMember(), Display(Name:="Category Name", Description:="The product belongs to the category with this name.")> _
    Public Property CategoryName() As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
        End Set
    End Property

    Private _productImagePath As String
    <DataMember()> _
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

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        If Not PropertyChangedEvent Is Nothing Then
            RaiseEvent PropertyChanged(Me, e)
        End If
    End Sub

    ' Added for DateAdded editing example in DataGridEditing.xaml and PivotViewerTest.xaml.
    Private _dateAdded As DateTime
    <DataMember()> _
    Public Property DateAdded() As DateTime
        Get
            Return _dateAdded
        End Get
        Set(ByVal value As DateTime)
            _dateAdded = value
        End Set
    End Property

    ' Added for CategoryName editing example in DataGridEditing.xaml.
    Public ReadOnly Property CategoryChoices() As String()
        Get
            Return New String() {"Deception", "Travel", "General", "Communications", "Tools", "Munitions", "Protection"}
        End Get
    End Property
End Class
