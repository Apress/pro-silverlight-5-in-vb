Imports System.Windows.Navigation

Partial Public Class CachedPage
    Inherits Page
    Public Sub New()
        InitializeComponent()
        MessageBox.Show("Created for the first time.")
    End Sub

    ' Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)

    End Sub

End Class
