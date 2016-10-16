Partial Public Class LayoutStates
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        lst.Items.Add("New Item (added " & DateTime.Now.ToLongTimeString() & ")")
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        lst.Items.RemoveAt(lst.Items.Count - 1)
    End Sub

End Class
