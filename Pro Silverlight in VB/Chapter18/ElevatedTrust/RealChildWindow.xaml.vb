Partial Public Class RealChildWindow
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private winSimple As Window
    Private winFancy As Window

    Private Sub cmdCreateBasic_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If (Not Application.Current.IsRunningOutOfBrowser) Or (Not Application.Current.HasElevatedPermissions) Then
            MessageBox.Show("This feature is only available out-of-browser with elevated trust.")
            'return;
        End If

        If winSimple Is Nothing Then
            winSimple = New Window()
            Dim textContent As New TextBlock()
            textContent.Text = "Here's some content!"
            Dim grid As New Grid()
            grid.Background = New SolidColorBrush(Colors.White)
            grid.Children.Add(textContent)
            winSimple.Content = grid
            winSimple.Width = 300
            winSimple.Height = 100
            winSimple.Title = "Simple Window"
            AddHandler winSimple.Closing, AddressOf simpleWindow_Closing
            winSimple.Visibility = Visibility.Visible
        Else
            winSimple.Activate()
        End If
    End Sub

    Private Sub simpleWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.ClosingEventArgs)
        winSimple = Nothing
    End Sub

    Private Sub cmdCreateFancy_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If (Not Application.Current.IsRunningOutOfBrowser) Or (Not Application.Current.HasElevatedPermissions) Then
            MessageBox.Show("This feature is only available out-of-browser with elevated trust.")
            Return
        End If

        If winFancy Is Nothing Then
            winFancy = New Window()
            winFancy.WindowStyle = WindowStyle.None
            Dim windowContent As New CustomWindow()
            windowContent.CurrentWindow = winFancy
            winFancy.Content = windowContent
            winFancy.Width = 300
            winFancy.Height = 200
            winFancy.Title = "Fancy Window"
            AddHandler winFancy.Closing, AddressOf fancyWindow_Closing
            winFancy.Visibility = Visibility.Visible
        Else
            winFancy.Activate()
        End If
    End Sub

    Private Sub fancyWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.ClosingEventArgs)
        winFancy = Nothing
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not winSimple Is Nothing Then
            winSimple.Close()
        End If
        If Not winFancy Is Nothing Then
            winFancy.Close()
        End If
    End Sub

End Class
