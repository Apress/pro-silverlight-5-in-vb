Imports AutoCompleteTest.AutoCompleteService

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub acbProducts_Populating(ByVal sender As Object, ByVal e As PopulatingEventArgs)
        ' Signal that the task is being performed asynchronously.
        e.Cancel = True

        ' Create the web service object.
        Dim service As New ProductAutoCompleteClient()

        ' Attach an event handler to the completion event.
        AddHandler service.GetProductMatchesCompleted, AddressOf GetProductMatchesCompleted

        ' Call the web service (asynchronously).
        service.GetProductMatchesAsync(e.Parameter)
    End Sub

    Private Sub GetProductMatchesCompleted(ByVal sender As Object, _
      ByVal e As GetProductMatchesCompletedEventArgs)
        ' Check for a web service error.
        If e.Error IsNot Nothing Then
            lblStatus.Text = e.Error.Message
            Return
        End If

        ' Set the suggestions.
        acbProducts.ItemsSource = e.Result

        ' Notify the control that the data has arrived.
        acbProducts.PopulateComplete()
    End Sub

End Class