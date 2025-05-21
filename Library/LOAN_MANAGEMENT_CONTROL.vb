Imports MySql.Data.MySqlClient

Public Class LOAN_MANAGEMENT_CONTROL

    Private Sub LOAN_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadLoanList()
        LoadBooksToComboBox()
        LoadBorrowersToComboBox()

        ' Optional to enforce DropDownList behavior
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList

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

        Try
            dbConn()
            Dim query As String = "
            SELECT 
                loans.loan_id,
                books.title AS book_title,
                borrowers.name AS borrower_name,
                loans.loan_date,
                loans.due_date,
                loans.return_date
            FROM loans
            JOIN books ON loans.book_id = books.book_id
            JOIN borrowers ON loans.borrower_id = borrowers.borrower_id
            ORDER BY loans.loan_id ASC
        "

            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim item As New ListViewItem(reader("loan_id").ToString())
                item.SubItems.Add(reader("book_title").ToString())
                item.SubItems.Add(reader("borrower_name").ToString())
                item.SubItems.Add(Convert.ToDateTime(reader("loan_date")).ToShortDateString())
                item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToShortDateString())
                item.SubItems.Add(If(IsDBNull(reader("return_date")), "", Convert.ToDateTime(reader("return_date")).ToShortDateString()))
                item.SubItems.Add("") ' Placeholder for View/Delete/Update buttons
                ListView1.Items.Add(item)
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading loans: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub


    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
    Private Sub LoadBooksToComboBox()
        ComboBox1.Items.Clear()

        Try
            dbConn()
            Dim query As String = "SELECT book_id, title FROM books ORDER BY title ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim item As New KeyValuePair(Of Integer, String)(reader("book_id"), reader("title").ToString())
                ComboBox1.Items.Add(item)
            End While

            ComboBox1.DisplayMember = "Value"
            ComboBox1.ValueMember = "Key"

        Catch ex As Exception
            MessageBox.Show("Error loading books: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    Private Sub LoadBorrowersToComboBox()
        ComboBox2.Items.Clear()

        Try
            dbConn()
            Dim query As String = "SELECT borrower_id, name FROM borrowers ORDER BY name ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim item As New KeyValuePair(Of Integer, String)(reader("borrower_id"), reader("name").ToString())
                ComboBox2.Items.Add(item)
            End While

            ComboBox2.DisplayMember = "Value"
            ComboBox2.ValueMember = "Key"

        Catch ex As Exception
            MessageBox.Show("Error loading borrowers: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
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
                Dim parentForm = Me.FindForm()
                If parentForm IsNot Nothing AndAlso TypeOf parentForm Is LOAN_MANAGEMENT Then
                    Dim loanId As Integer = Convert.ToInt32(hitInfo.Item.SubItems(0).Text)
                    CType(parentForm, LOAN_MANAGEMENT).dashboardLoad(New VIEW_LOAN_MANAGEMENT_TABLE(loanId))
                Else
                    MessageBox.Show("LOAN_MANAGEMENT form not found.")
                End If
            ElseIf deleteBtn.Contains(e.Location) Then
                Dim loanId As Integer = Convert.ToInt32(hitInfo.Item.SubItems(0).Text)
                Dim confirm = MessageBox.Show($"Are you sure you want to delete the loan for '{bookTitle}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If confirm = DialogResult.Yes Then
                    Try
                        dbConn()
                        Dim deleteQuery As String = "DELETE FROM loans WHERE loan_id = @loanId"
                        Dim cmd As New MySqlCommand(deleteQuery, conn)
                        cmd.Parameters.AddWithValue("@loanId", loanId)

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Loan deleted successfully.")
                            LoadLoanList() ' Refresh the ListView
                        Else
                            MessageBox.Show("No loan was deleted. Please try again.")
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error deleting loan: " & ex.Message)
                    Finally
                        dbDisconn()
                    End Try
                End If

            ElseIf updateBtn.Contains(e.Location) Then
                Dim loanId As Integer = Convert.ToInt32(hitInfo.Item.SubItems(0).Text)
                Dim currentReturnDate As String = hitInfo.Item.SubItems(5).Text

                Dim parsedDate As Date
                If Not Date.TryParse(currentReturnDate, parsedDate) Then
                    parsedDate = Date.Today
                End If

                Dim parentForm = Me.FindForm()
                If parentForm IsNot Nothing AndAlso TypeOf parentForm Is LOAN_MANAGEMENT Then
                    Dim returnForm As New return_book(loanId, parsedDate)
                    returnForm.ShowDialog()

                Else
                    MessageBox.Show("LOAN_MANAGEMENT form not found.")
                End If
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

        ' Allocate more width to BOOK TITLE (e.g., 2x share)
        Dim totalShares As Integer = 6 ' 2 (book) + 1 (borrower) + 1 (loan) + 1 (due) + 1 (return)
        Dim shareWidth As Integer = remainingWidth \ totalShares

        ListView1.Columns(0).Width = col0Width                          ' ID
        ListView1.Columns(1).Width = shareWidth * 2                    ' BOOK TITLE
        ListView1.Columns(2).Width = shareWidth                        ' BORROWER
        ListView1.Columns(3).Width = shareWidth                        ' LOAN DATE
        ListView1.Columns(4).Width = shareWidth                        ' DUE DATE
        ListView1.Columns(5).Width = shareWidth                        ' RETURN DATE
        ListView1.Columns(6).Width = col6Width                         ' ACTIONS
    End Sub

    ' Handles the CANCEL button click
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        DateTimePicker1.Value = Date.Today
        DateTimePicker2.Value = Date.Today
        DateTimePicker3.Value = Date.Today
    End Sub

    ' Handles the LOAN button click
    Private Sub BtnLoan_Click(sender As Object, e As EventArgs) Handles BtnLoan.Click
        If ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please select both a book and a borrower.")
            Return
        End If

        Dim selectedBook As KeyValuePair(Of Integer, String) = CType(ComboBox1.SelectedItem, KeyValuePair(Of Integer, String))
        Dim selectedBorrower As KeyValuePair(Of Integer, String) = CType(ComboBox2.SelectedItem, KeyValuePair(Of Integer, String))

        Dim loanDate As Date = DateTimePicker1.Value
        Dim dueDate As Date = DateTimePicker2.Value
        Dim returnDate As Date = DateTimePicker3.Value

        Try
            dbConn()

            Dim query As String = "
            INSERT INTO loans (book_id, borrower_id, loan_date, due_date, return_date)
            VALUES (@book_id, @borrower_id, @loan_date, @due_date, @return_date)
        "

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@book_id", selectedBook.Key)
                cmd.Parameters.AddWithValue("@borrower_id", selectedBorrower.Key)
                cmd.Parameters.AddWithValue("@loan_date", loanDate)
                cmd.Parameters.AddWithValue("@due_date", dueDate)
                cmd.Parameters.AddWithValue("@return_date", returnDate)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Loan successfully recorded.")
            LoadLoanList() ' Refresh the list after loan
            BtnCancel_Click(Nothing, Nothing) ' Clear the form

        Catch ex As Exception
            MessageBox.Show("Error inserting loan: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
