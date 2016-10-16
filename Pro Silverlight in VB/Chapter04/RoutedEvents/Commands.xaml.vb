Partial Public Class Commands
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

End Class

Public Class PrintTextCommand
    Implements ICommand

    Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
      Implements ICommand.CanExecuteChanged

    Private _canExecute As Boolean

    Public Function CanExecute(ByVal parameter As Object) As Boolean _
      Implements ICommand.CanExecute
        ' Check if the command can execute.
        ' In order to be executable, it must have non-blank text in the command parameter.
        Dim canExecuteNow As Boolean = (parameter IsNot Nothing) AndAlso (parameter.ToString() <> "")

        ' Determine if the CanExecuteChanged event should be raised.
        If _canExecute <> canExecuteNow Then
            _canExecute = canExecuteNow
            RaiseEvent CanExecuteChanged(Me, New EventArgs())
        End If

        Return _canExecute
    End Function

    Public Sub Execute(ByVal parameter As Object) _
      Implements ICommand.Execute
        MessageBox.Show("Printing: " & parameter)
    End Sub
End Class

