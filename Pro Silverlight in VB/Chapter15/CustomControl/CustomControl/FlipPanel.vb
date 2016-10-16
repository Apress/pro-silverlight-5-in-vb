Imports System.Windows.Controls.Primitives

<TemplateVisualState(Name:="Normal", GroupName:="ViewStates"), _
 TemplateVisualState(Name:="Flipped", GroupName:="ViewStates"), _
 TemplatePart(Name:="FlipButton", Type:=GetType(ToggleButton)), _
 TemplatePart(Name:="FlipButtonAlternate", Type:=GetType(ToggleButton))> _
Public Class FlipPanel
    Inherits Control

    Public Sub New()
        DefaultStyleKey = GetType(FlipPanel)
    End Sub

    Public Shared ReadOnly FrontContentProperty As DependencyProperty = _
  DependencyProperty.Register("FrontContent", GetType(Object), _
  GetType(FlipPanel), Nothing)

    Public Property FrontContent() As Object
        Get
            Return MyBase.GetValue(FrontContentProperty)
        End Get
        Set(ByVal value As Object)
            MyBase.SetValue(FrontContentProperty, value)
        End Set
    End Property

    Public Shared ReadOnly BackContentProperty As DependencyProperty = _
  DependencyProperty.Register("BackContent", GetType(Object), _
  GetType(FlipPanel), Nothing)

    Public Property BackContent() As Object
        Get
            Return MyBase.GetValue(BackContentProperty)
        End Get
        Set(ByVal value As Object)
            MyBase.SetValue(BackContentProperty, value)
        End Set
    End Property

    Public Shared ReadOnly IsFlippedProperty As DependencyProperty = _
  DependencyProperty.Register("IsFlipped", GetType(Boolean), _
  GetType(FlipPanel), Nothing)

    Public Property IsFlipped() As Boolean
        Get
            Return CBool(MyBase.GetValue(IsFlippedProperty))
        End Get
        Set(ByVal value As Boolean)
            MyBase.SetValue(IsFlippedProperty, value)
            ChangeVisualState(True)
        End Set
    End Property

    Public Shared ReadOnly CornerRadiusProperty As DependencyProperty = _
  DependencyProperty.Register("CornerRadius", GetType(CornerRadius), _
  GetType(FlipPanel), Nothing)

    Public Property CornerRadius() As CornerRadius
        Get
            Return CType(GetValue(CornerRadiusProperty), CornerRadius)
        End Get
        Set(ByVal value As CornerRadius)
            SetValue(CornerRadiusProperty, value)
        End Set
    End Property

    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()

        ' Wire up the ToggleButton.Click event.
        Dim flipButton As ToggleButton = TryCast( _
          MyBase.GetTemplateChild("FlipButton"), ToggleButton)
        If flipButton IsNot Nothing Then
            AddHandler flipButton.Click, AddressOf flipButton_Click
        End If

        ' Allow for two flip buttons if needed (one for each side of the panel).
        Dim flipButtonAlternate As ToggleButton = TryCast( _
          MyBase.GetTemplateChild("FlipButtonAlternate"), ToggleButton)
        If flipButtonAlternate IsNot Nothing Then
            AddHandler flipButtonAlternate.Click, AddressOf flipButton_Click
        End If

        ' Make sure the visuals match the current state.
        ChangeVisualState(False)
    End Sub

    Private Sub flipButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        IsFlipped = Not IsFlipped
        ChangeVisualState(True)
    End Sub

    Private Sub ChangeVisualState(ByVal useTransitions As Boolean)
        If Not IsFlipped Then
            VisualStateManager.GoToState(Me, "Normal", useTransitions)
        Else
            VisualStateManager.GoToState(Me, "Flipped", useTransitions)
        End If
    End Sub

End Class
