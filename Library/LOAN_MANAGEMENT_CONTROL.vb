Public Class LOAN_MANAGEMENT_CONTROL

    Private Sub LOAN_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadLoanList()
        ListView1_Resize(ListView1, EventArgs.Empty)
    End Sub

    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("ID", 50, HorizontalAlignment.Center)
            .Columns.Add("BOOK TITLE", 200, HorizontalAlignment.Center)
            .Columns.Add("BORROWER", 150, HorizontalAlignment.Center)
            .Columns.Add("LOAN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("DUE DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("RETURN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 240, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawLoanSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
            AddHandler .MouseClick, AddressOf ListView1_MouseClick
        End With
    End Sub

    Private Sub LoadLoanList()
        ListView1.Items.Clear()

        For i As Integer = 1 To 10
            Dim item As New ListViewItem(i.ToString())
            item.SubItems.Add("Sample Book " & i)
            item.SubItems.Add("Borrower " & i)
            item.SubItems.Add(DateTime.Today.AddDays(-i).ToShortDateString())
            item.SubItems.Add(DateTime.Today.AddDays(7 - i).ToShortDateString())
            item.SubItems.Add(DateTime.Today.AddDays(3 - i).ToShortDateString())
            item.SubItems.Add("") ' Placeholder for buttons
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawLoanSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 6 ' ACTIONS
                Dim spacing As Integer = 10
                Dim btnCount As Integer = 3
                Dim btnWidth As Integer = (e.Bounds.Width - (spacing * (btnCount + 1))) \ btnCount
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim btns() As Rectangle = {
                    New Rectangle(e.Bounds.X + spacing, e.Bounds.Y + 2, btnWidth, btnHeight),
                    New Rectangle(e.Bounds.X + spacing * 2 + btnWidth, e.Bounds.Y + 2, btnWidth, btnHeight),
                    New Rectangle(e.Bounds.X + spacing * 3 + btnWidth * 2, e.Bounds.Y + 2, btnWidth, btnHeight)
                }

                ButtonRenderer.DrawButton(e.Graphics, btns(0), "View", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, btns(1), "Delete", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, btns(2), "Update", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 6 Then ' ACTIONS column
            Dim itemBounds = hitInfo.SubItem.Bounds
            Dim spacing As Integer = 10
            Dim btnCount As Integer = 3
            Dim btnWidth As Integer = (itemBounds.Width - (spacing * (btnCount + 1))) \ btnCount
            Dim btnHeight As Integer = itemBounds.Height - 4

            Dim viewBtn = New Rectangle(itemBounds.X + spacing, itemBounds.Y + 2, btnWidth, btnHeight)
            Dim deleteBtn = New Rectangle(itemBounds.X + spacing * 2 + btnWidth, itemBounds.Y + 2, btnWidth, btnHeight)
            Dim updateBtn = New Rectangle(itemBounds.X + spacing * 3 + btnWidth * 2, itemBounds.Y + 2, btnWidth, btnHeight)

            Dim bookTitle = hitInfo.Item.SubItems(1).Text

            If viewBtn.Contains(e.Location) Then
                MessageBox.Show("View clicked on " & bookTitle)
            ElseIf deleteBtn.Contains(e.Location) Then
                MessageBox.Show("Delete clicked on " & bookTitle)
            ElseIf updateBtn.Contains(e.Location) Then
                MessageBox.Show("Update clicked on " & bookTitle)
            End If
        End If
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50    ' ID
        Dim col6Width As Integer = 240   ' ACTIONS

        ' Remaining space for dynamic columns
        Dim remainingWidth As Integer = totalWidth - col0Width - col6Width
        If remainingWidth < 0 Then remainingWidth = 0

        ' 5 dynamic columns
        Dim dynamicColWidth As Integer = remainingWidth \ 5

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = dynamicColWidth ' BOOK TITLE
        ListView1.Columns(2).Width = dynamicColWidth ' BORROWER
        ListView1.Columns(3).Width = dynamicColWidth ' LOAN DATE
        ListView1.Columns(4).Width = dynamicColWidth ' DUE DATE
        ListView1.Columns(5).Width = dynamicColWidth ' RETURN DATE
        ListView1.Columns(6).Width = col6Width
    End Sub

End Class
