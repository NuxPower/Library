Public Class VIEW_BORROWER_MANAGEMENT_CONTROL

    Private Sub VIEW_BORROWER_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            .Columns.Add("LOAN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("DUE DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("STATUS", 120, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawSubItemCustom
            AddHandler .Resize, AddressOf ListView1_Resize
        End With
    End Sub

    Private Sub LoadLoanList()
        ListView1.Items.Clear()

        ' Sample data
        For i As Integer = 1 To 10
            Dim item As New ListViewItem(i.ToString())
            item.SubItems.Add("Book Title " & i)
            item.SubItems.Add(DateTime.Now.AddDays(-i).ToShortDateString())
            item.SubItems.Add(DateTime.Now.AddDays(7 - i).ToShortDateString())
            item.SubItems.Add(If(i Mod 2 = 0, "Returned", "Overdue"))

            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawSubItemCustom(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Dim alignFlags As TextFormatFlags = TextFormatFlags.VerticalCenter
        If e.Header.Text = "ID" OrElse e.Header.Text = "STATUS" Then
            alignFlags = alignFlags Or TextFormatFlags.HorizontalCenter
        Else
            alignFlags = alignFlags Or TextFormatFlags.Left
        End If

        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, alignFlags)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50   ' ID
        Dim col2Width As Integer = 120  ' LOAN DATE
        Dim col3Width As Integer = 120  ' DUE DATE
        Dim col4Width As Integer = 120  ' STATUS

        ' Remaining space after fixed columns
        Dim remainingWidth As Integer = totalWidth - col0Width - col2Width - col3Width - col4Width
        If remainingWidth < 0 Then remainingWidth = 0

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = remainingWidth ' BOOK TITLE
        ListView1.Columns(2).Width = col2Width
        ListView1.Columns(3).Width = col3Width
        ListView1.Columns(4).Width = col4Width
    End Sub

End Class
