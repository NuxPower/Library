Imports MySql.Data.MySqlClient

Public Class BORROWER_MANAGEMENT_TABLE
    Implements ISearchable
    Private borrowersList As List(Of Borrower)

    Private Class Borrower
        Public Property BorrowerId As Integer
        Public Property Name As String
        Public Property Email As String
        Public Property MobileNo As String
    End Class

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

    Private Sub LoadBorrowerList(Optional sortBy As String = "id")
        ListView1.Items.Clear()

        Try
            dbConn()
            Dim orderByClause As String = "borrower_id ASC"
            If sortBy = "name" Then
                orderByClause = "name ASC"
            ElseIf sortBy = "date" Then
                orderByClause = "borrower_id DESC" ' assuming newer entries have higher IDs
            End If

            Dim query As String = $"SELECT borrower_id, name, email, mobile_no FROM Borrowers ORDER BY {orderByClause}"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            Dim index As Integer = 1
            While reader.Read()
                Dim item As New ListViewItem(index.ToString())
                item.SubItems.Add(reader("name").ToString())
                item.SubItems.Add(reader("email").ToString())
                item.SubItems.Add(reader("mobile_no").ToString())
                item.SubItems.Add("")
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


    Private Sub DisplayBorrowers(borrowers As List(Of Borrower))
        ListView1.Items.Clear()
        Dim index As Integer = 1

        For Each b In borrowers
            Dim item As New ListViewItem(index.ToString())
            item.SubItems.Add(b.Name)
            item.SubItems.Add(b.Email)
            item.SubItems.Add(b.MobileNo)
            item.SubItems.Add("") ' Placeholder for buttons
            ListView1.Items.Add(item)
            index += 1
        Next
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

                Dim viewRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim updateRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, viewRect, "View", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, updateRect, "Update", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

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

            Dim viewBtn = New Rectangle(itemBounds.X + 5, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)
            Dim updateBtn = New Rectangle(itemBounds.X + btnWidth + 10, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)

            If viewBtn.Contains(e.Location) Then
                ' Show the VIEW_BORROWER_MANAGEMENT_CONTROL in a dynamic form
                Dim mainForm = TryCast(Me.FindForm(), Dashboard)  ' get Dashboard form reference
                If mainForm IsNot Nothing Then
                    Dim loanForm As New LOAN_MANAGEMENT("VIEW_BORROWER", mainForm) ' pass Dashboard reference
                    loanForm.Show()
                    mainForm.Hide() ' optionally hide the dashboard form when loanForm shows
                Else
                    MessageBox.Show("Dashboard form not found.")
                End If
            ElseIf updateBtn.Contains(e.Location) Then
                ' Show the UPDATING_BORROWER_CONTROL in a dynamic form
                Dim mainForm = TryCast(Me.FindForm(), Dashboard)  ' get Dashboard form reference
                If mainForm IsNot Nothing Then
                    Dim loanForm As New LOAN_MANAGEMENT("UPDATE_BORROWER", mainForm) ' pass Dashboard reference
                    loanForm.Show()
                    mainForm.Hide() ' optionally hide the dashboard form when loanForm shows
                Else
                    MessageBox.Show("Dashboard form not found.")
                End If
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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Public Sub PerformSearch(query As String) Implements ISearchable.PerformSearch
        If String.IsNullOrWhiteSpace(query) Then
            DisplayBorrowers(borrowersList)
        Else
            ' Filter by name, email, or mobile (case-insensitive)
            Dim filtered = borrowersList.Where(Function(b) b.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 _
                                            OrElse b.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 _
                                            OrElse b.MobileNo.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
            DisplayBorrowers(filtered)
        End If
    End Sub

End Class
