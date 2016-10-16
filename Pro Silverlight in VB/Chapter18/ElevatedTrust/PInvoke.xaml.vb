Imports System.Runtime.InteropServices

Partial Public Class PInvoke
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    ' This is the API function for exiting Windows.
    <DllImport("user32.dll")>
    Shared Function ExitWindowsEx(ByVal uFlags As ExitWindowsFlags, ByVal dwReason As Long) As Long
    End Function

    Public Enum ExitWindowsFlags
        ' Use this constant to log the user off without a reboot.
        Logoff = 0

        ' Use this constant to cause a system reboot.
        Restart = 2

        ' Use this constant to cause a system shutdown
        ' (and turn off the computer, if the hardware supports it).
        Shutdown = 1

        ' Add this constant to any of the other three to force the
        ' shutdown or reboot even if the user tries to cancel it.
        Force = 4
    End Enum

    Private Sub cmdShutdown_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        ExitWindowsEx(ExitWindowsFlags.Logoff, 0)
    End Sub
End Class
