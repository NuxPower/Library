Imports MySql.Data.MySqlClient

Public Class BORROWER_MANAGEMENT_TABLE

    Private Sub BORROWER_MANAGEMENT_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadBorrowerList()
        ListView1_Resize(ListView1, EventArgs.Empty)
    End Sub

    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("NO", 50, HorizontalAlignment.Center)
            .Columns.Add("NAME", 200, HorizontalAlignment.Center)
            .Columns.Add("EMAIL", 200, HorizontalAlignment.Center)
            .Columns.Add("MOBILE NO.", 150, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 160, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawBorrowerSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
            AddHandler .MouseClick, AddressOf ListView1_MouseClick
        End With
    End Sub

    Private Sub LoadBorrowerList()
        ListView1.Items.Clear()

        Try
            dbConn()
            Dim query As String = "SELECT borrower_id, name, email, mobile_no FROM Borrowers ORDER BY borrower_id ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            Dim index As Integer = 1
            While reader.Read()
                Dim item As New ListViewItem(index.ToString())
                item.SubItems.Add(reader("name").ToString())
                item.SubItems.Add(reader("email").ToString())
                item.SubItems.Add(reader("mobile_no").ToString())
                item.SubItems.Add("") ' Placeholder for Edit/Delete buttons
                ListView1.Items.Add(item)
                index += 1
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading borrowers: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub


    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawBorrowerSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 4 ' ACTIONS
                Dim spacing As Integer = 12
                Dim btnWidth As Integer = (e.Bounds.Width - spacing - 10) \ 2
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim editRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim deleteRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, editRect, "Edit", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "Delete", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case 1, 2, 3 ' NAME, EMAIL, MOBILE NO.
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds,
                                      e.Item.ListView.ForeColor,
                                      TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds,
                                      e.Item.ListView.ForeColor,
                                      TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 4 Then ' ACTIONS column
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
        Dim col0Width As Integer = 50    ' NO
        Dim col4Width As Integer = 160   ' ACTIONS

        Dim remainingWidth As Integer = totalWidth - col0Width - col4Width
        If remainingWidth < 0 Then remainingWidth = 0

        Dim dynamicColWidth As Integer = remainingWidth \ 3

        ListView1.Columns(0).Width = col0Width        ' NO
        ListView1.Columns(1).Width = dynamicColWidth  ' NAME
        ListView1.Columns(2).Width = dynamicColWidth  ' EMAIL
        ListView1.Columns(3).Width = dynamicColWidth  ' MOBILE NO.
        ListView1.Columns(4).Width = col4Width        ' ACTIONS
    End Sub

End Class
