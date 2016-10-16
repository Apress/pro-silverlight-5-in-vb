Imports System.Windows.Media.Imaging

Partial Public Class FluidMoveTest
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        AddImage("arch.jpg")
        AddImage("birdinrain.jpg")
        AddImage("boatinstorm.jpg")
        AddImage("cactus.jpg")
        AddImage("dunes.jpg")
        AddImage("egyptsea.jpg")
        AddImage("gloomylightpost.jpg")
        AddImage("graybluesky.jpg")
        AddImage("greydesert.jpg")
        AddImage("greylighthouse.jpg")
    End Sub

    Private Sub AddImage(ByVal imageFileName As String)
        Dim img As New Image()
        img.Margin = New Thickness(3)
        img.Source = New BitmapImage(New Uri("Backgrounds/" & imageFileName, UriKind.Relative))
        panel.Children.Add(img)
    End Sub
End Class
