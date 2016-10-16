Imports System.IO

Partial Public Class DirectoryTree
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        Dim rootDir As New DirectoryInfo("c:\")
        AddItem(rootDir, treeFileSystem.Items)
    End Sub

    Private Sub AddItem(ByVal dir As DirectoryInfo, ByVal collection As ItemCollection)
        Dim item As New TreeViewItem()
        item.Tag = dir
        item.Header = dir.Name

        ' This placeholder string is never shown,
        ' because the node begins in collapsed state.
        item.Items.Add("*")
        AddHandler item.Expanded, AddressOf item_Expanded
        AddHandler item.Selected, AddressOf item_Selected

        collection.Add(item)
    End Sub

    Private Sub item_Expanded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim item As TreeViewItem = CType(sender, TreeViewItem)

        ' Perform a refresh every time item is expanded.
        ' Optionally, you could perform this only the first
        ' time, when the placeholder is found (less refreshes),
        ' or every time an item is selected (more refreshes).
        item.Items.Clear()

        Dim dir As DirectoryInfo = CType(item.Tag, DirectoryInfo)

        Try
            For Each subDir As DirectoryInfo In dir.EnumerateDirectories()
                AddItem(subDir, item.Items)
            Next
        Catch
            ' An exception could be thrown in this code if you don't
            ' have sufficient security permissions for a file or directory.
            ' You can catch and then ignore this exception.
        End Try
    End Sub

    Private Sub item_Selected(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim item As TreeViewItem = CType(sender, TreeViewItem)
        Dim dir As DirectoryInfo = CType(item.Tag, DirectoryInfo)

        Try
            ' Convert this directly to an array to get an exception to be thrown immediately,
            ' if there is an access problem.
            lstFiles.ItemsSource = dir.EnumerateFiles().ToArray()
        Catch
            ' An exception could be thrown in this code if you don't
            ' have sufficient security permissions for a file or directory.
            ' You can catch and then ignore this exception.
        End Try
    End Sub

End Class
