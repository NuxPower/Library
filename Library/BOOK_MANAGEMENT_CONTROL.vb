Imports MySql.Data.MySqlClient

Public Class BOOK_MANAGEMENT_CONTROL

    ' Property to receive BookId from the caller
    Public Property BookId As Integer

    Private Sub BOOK_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        If BookId > 0 Then
            PopulateBookLabels() ' Populates labels for book info
            LoadLoanList()       ' Populates ListView with loans for this book
        Else
            MessageBox.Show("Invalid Book ID")
        End If
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
            .Columns.Add("STATUS", 120, HorizontalAlignment.Center) ' Derived

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawLoanSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
        End With
    End Sub

    Private Sub PopulateBookLabels()
        Try
            dbConn()
            ' Get Book and Author Info
            Dim query As String = "
                SELECT b.book_id, b.title, b.isbn, a.name AS author_name
                FROM books b
                JOIN authors a ON b.author_id = a.author_id
                WHERE b.book_id = @bid
            "
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@bid", BookId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                book_id.Text = reader("book_id").ToString()
                title_label.Text = reader("title").ToString()
                isbn_label.Text = reader("isbn").ToString()
                authorlabel.Text = reader("author_name").ToString()
            Else
                book_id.Text = "-"
                title_label.Text = "-"
                isbn_label.Text = "-"
                authorlabel.Text = "-"
            End If
            reader.Close()

            ' Count ON LOAN books (those not yet returned)
            Dim statusCmd As New MySqlCommand("
                SELECT COUNT(*) FROM loans 
                WHERE book_id = @bid AND return_date IS NULL
            ", conn)
            statusCmd.Parameters.AddWithValue("@bid", BookId)
            Dim onLoanCount As Integer = Convert.ToInt32(statusCmd.ExecuteScalar())

            If onLoanCount = 0 Then
                Status_label.Text = "All Returned"
            ElseIf onLoanCount = 1 Then
                Status_label.Text = "1 Copy On Loan"
            Else
                Status_label.Text = $"{onLoanCount} Copies On Loan"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading book details: " & ex.Message)
            book_id.Text = "-"
            title_label.Text = "-"
            isbn_label.Text = "-"
            authorlabel.Text = "-"
            Status_label.Text = "-"
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub LoadLoanList()
        ListView1.Items.Clear()

        Try
            dbConn()
            Dim query As String = "
                SELECT l.loan_id, br.name AS borrower_name, l.loan_date, l.due_date, l.return_date
                FROM loans l
                JOIN borrowers br ON l.borrower_id = br.borrower_id
                WHERE l.book_id = @bookId
                ORDER BY l.loan_date DESC
            "
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@bookId", BookId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If Not reader.HasRows Then
                ' Show "No loans found"
                Dim item As New ListViewItem("–")
                item.SubItems.Add("No loans found")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                ListView1.Items.Add(item)
            Else
                While reader.Read()
                    Dim item As New ListViewItem(reader("loan_id").ToString())
                    item.SubItems.Add(reader("borrower_name").ToString())
                    item.SubItems.Add(Convert.ToDateTime(reader("loan_date")).ToShortDateString())
                    item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToShortDateString())
                    Dim returnDateText As String
                    Dim statusText As String

                    If IsDBNull(reader("return_date")) Then
                        returnDateText = "Not Returned"
                        statusText = "ON LOAN"
                    Else
                        returnDateText = Convert.ToDateTime(reader("return_date")).ToShortDateString()
                        statusText = "RETURNED"
                    End If

                    item.SubItems.Add(returnDateText)
                    item.SubItems.Add(statusText)
                    ListView1.Items.Add(item)
                End While
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading loan records: " & ex.Message)
        Finally
            dbDisconn()
        End Try
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
        Dim col5Width As Integer = 120   ' STATUS

        Dim remainingWidth As Integer = totalWidth - col0Width - col5Width
        If remainingWidth < 0 Then remainingWidth = 0

        Dim dynamicColWidth As Integer = remainingWidth \ 4

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = dynamicColWidth
        ListView1.Columns(2).Width = dynamicColWidth
        ListView1.Columns(3).Width = dynamicColWidth
        ListView1.Columns(4).Width = dynamicColWidth
        ListView1.Columns(5).Width = col5Width
    End Sub

    ' (Optional events for UI interactions)
    Private Sub YourForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.White
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub
End Class
