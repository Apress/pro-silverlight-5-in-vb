Public Class UniformGrid
    Inherits Panel

    Private _columns As Integer
    Public Property Columns() As Integer
        Get
            Return _columns
        End Get
        Set(ByVal value As Integer)
            _columns = value
        End Set
    End Property

    Private _rows As Integer
    Public Property Rows() As Integer
        Get
            Return _rows
        End Get
        Set(ByVal value As Integer)
            _rows = value
        End Set
    End Property

    Private realColumns As Integer
    Private realRows As Integer

    Private Sub CalculateColumns()
        ' Count the elements, and don't do anything
        ' if the panel is empty.
        Dim elementCount As Double = Me.Children.Count
        If elementCount = 0 Then Return

        realRows = Rows
        realColumns = Columns

        ' If the Rows and Columns properties were set, use them.
        If (realRows <> 0) AndAlso (realColumns <> 0) Then
            Return
        End If
        ' If neither property was set, start by calculating the columns.
        If (realColumns = 0) AndAlso realRows = 0 Then
            realColumns = CInt(Fix(Math.Ceiling(Math.Sqrt(elementCount))))
        End If
        ' If only Rows is set, calculate Columns.
        If realColumns = 0 Then
            realColumns = CInt(Fix(Math.Ceiling(elementCount / realRows)))
        End If
        ' If only Columns is set, calculate Rows.
        If realRows = 0 Then
            realRows = CInt(Fix(Math.Ceiling(elementCount / realColumns)))
        End If

    End Sub

    Protected Overrides Function MeasureOverride(ByVal constraint As Size) As Size
        ' Determine the dimensions of the grid.
        CalculateColumns()

        ' Share out the available space equally.
        Dim childConstraint As New Size(constraint.Width / realColumns, constraint.Height / realRows)

        ' Keep track of the largest requested dimensions for any element.
        Dim largestCell As New Size()

        ' Examine all the elements in this panel.
        For Each child As UIElement In Me.Children
            ' Get the desired size of the child.
            child.Measure(childConstraint)

            ' Record the largest requested dimensions.
            largestCell.Height = Math.Max(largestCell.Height, child.DesiredSize.Height)
            largestCell.Width = Math.Max(largestCell.Width, child.DesiredSize.Width)
        Next

        ' Take the largest requested element width and height, and use
        ' those to calculate the maximum size of the grid.
        ' If there are more elements than cells, extra elements are ignored.
        Return New Size(largestCell.Width * realColumns, largestCell.Height * realRows)
    End Function

    Protected Overrides Function ArrangeOverride(ByVal arrangeSize As Size) As Size
        ' Calculate the size of each cell.
        Dim cellWidth As Double = arrangeSize.Width / realColumns
        Dim cellHeight As Double = arrangeSize.Height / realRows

        ' Determine the placement for each child.
        Dim childBounds As New Rect(0, 0, cellWidth, cellHeight)

        ' Examine all the elements in this panel.
        For Each child As UIElement In Me.Children
            ' Position the child.
            child.Arrange(childBounds)

            ' Move the bounds to the next position.                
            childBounds.X += cellWidth
            If childBounds.X >= cellWidth * realColumns Then
                ' Move to the next row.
                childBounds.Y += cellHeight
                childBounds.X = 0

                ' If there are more elements than cells,
                ' hide extra elements.
                If childBounds.Y >= cellHeight * realRows Then
                    childBounds = New Rect(0, 0, 0, 0)
                End If
            End If
        Next

        ' Return the size this panel actually occupies.                        
        Return arrangeSize
    End Function
End Class