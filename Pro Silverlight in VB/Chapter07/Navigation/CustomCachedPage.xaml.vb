Imports System.Windows.Navigation

Partial Public Class CustomCachedPage
    Inherits Page
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedFrom(ByVal e As NavigationEventArgs)
        ' Store the text box data.
        CustomCachedPage.TextBoxState = txtCached.Text
        MyBase.OnNavigatedFrom(e)
    End Sub
    Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
        ' Retrieve the text box data.
        If CustomCachedPage.TextBoxState IsNot Nothing Then
            txtCached.Text = CustomCachedPage.TextBoxState
        End If
        MyBase.OnNavigatedTo(e)
    End Sub

    Private Shared _textBoxState As String
    Public Shared Property TextBoxState() As String
        Get
            Return _textBoxState
        End Get
        Set(ByVal value As String)
            _textBoxState = value
        End Set
    End Property

End Class
