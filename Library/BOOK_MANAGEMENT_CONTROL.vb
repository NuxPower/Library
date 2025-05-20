Public Class BOOK_MANAGEMENT_CONTROL

    Private Sub BOOK_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            .Columns.Add("BORROWER", 150, HorizontalAlignment.Center)
            .Columns.Add("LOAN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("DUE DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("RETURN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("STATUS", 240, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawLoanSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
        End With
    End Sub

    Private Sub LoadLoanList()
        ListView1.Items.Clear()

        For i As Integer = 1 To 10
            Dim item As New ListViewItem(i.ToString())
            item.SubItems.Add("Borrower " & i)
            item.SubItems.Add(DateTime.Today.AddDays(-i).ToShortDateString())
            item.SubItems.Add(DateTime.Today.AddDays(7 - i).ToShortDateString())
            item.SubItems.Add(DateTime.Today.AddDays(3 - i).ToShortDateString())
            item.SubItems.Add("RETURNED")
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawLoanSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50    ' ID
        Dim col5Width As Integer = 240   ' STATUS

        ' Remaining space for dynamic columns
        Dim remainingWidth As Integer = totalWidth - col0Width - col5Width
        If remainingWidth < 0 Then remainingWidth = 0

        ' 4 dynamic columns: BORROWER, LOAN DATE, DUE DATE, RETURN DATE
        Dim dynamicColWidth As Integer = remainingWidth \ 4

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = dynamicColWidth
        ListView1.Columns(2).Width = dynamicColWidth
        ListView1.Columns(3).Width = dynamicColWidth
        ListView1.Columns(4).Width = dynamicColWidth
        ListView1.Columns(5).Width = col5Width
    End Sub

End Class
