Public Class AUTHOR_MANAGEMENT_TABLE
    Private Sub AUTHOR_MANAGEMENT_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadAuthorList()
        ListView1_Resize(ListView1, EventArgs.Empty) ' ✅ Force initial resize
    End Sub


    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("NO", 50, HorizontalAlignment.Center)
            .Columns.Add("NAME", 100, HorizontalAlignment.Left)
            .Columns.Add("DATE ADDED", 120, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 160, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawAuthorSubItem
            AddHandler .Resize, AddressOf ListView1_Resize ' ✅ Attach here
        End With
    End Sub


    Private Sub LoadAuthorList()
        ListView1.Items.Clear()

        For i As Integer = 1 To 10
            Dim item As New ListViewItem(i.ToString())
            item.SubItems.Add("Author " & i.ToString())
            item.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd")) ' <-- Date Added
            item.SubItems.Add("") ' Placeholder for action buttons
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter)
    End Sub

    Private Sub DrawAuthorSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 3 ' ACTIONS
                Dim spacing As Integer = 12
                Dim btnWidth As Integer = (e.Bounds.Width - spacing - 10) \ 2
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim editRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim deleteRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, editRect, "Edit", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "Delete", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case 1 ' NAME
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 3 Then ' ACTIONS column
            Dim itemBounds = hitInfo.SubItem.Bounds
            Dim btnWidth As Integer = (itemBounds.Width - 10) \ 2

            Dim editBtn = New Rectangle(itemBounds.X + 5, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)
            Dim deleteBtn = New Rectangle(itemBounds.X + btnWidth + 10, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)

            If editBtn.Contains(e.Location) Then
                MessageBox.Show("Edit clicked on " & hitInfo.Item.SubItems(1).Text)
            ElseIf deleteBtn.Contains(e.Location) Then
                MessageBox.Show("Delete clicked on " & hitInfo.Item.SubItems(1).Text)
            End If
        End If
    End Sub
    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50 ' NO
        Dim col3Width As Integer = 160 ' ACTIONS
        Dim col2Width As Integer = 120 ' DATE ADDED

        Dim remainingWidth As Integer = totalWidth - col0Width - col2Width - col3Width
        If remainingWidth < 0 Then remainingWidth = 0

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = remainingWidth ' NAME
        ListView1.Columns(2).Width = col2Width
        ListView1.Columns(3).Width = col3Width
    End Sub

End Class
