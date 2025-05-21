Imports MySql.Data.MySqlClient

Public Class VIEW_LOAN_MANAGEMENT_TABLE
    Private loanId As Integer

    Public Sub New(id As Integer)
        InitializeComponent()
        loanId = id
    End Sub

    Private Sub VIEW_LOAN_MANAGEMENT_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoanDetails(loanId)
    End Sub
    Private Sub LoadLoanDetails(loanId As Integer)
        Try
            dbConn()

            Dim query As String = "
            SELECT 
                books.title AS book_title,
                authors.name AS author_name,
                borrowers.name AS borrower_name,
                loans.loan_date,
                loans.due_date,
                loans.return_date,
                CASE
                    WHEN loans.return_date IS NOT NULL THEN 'Returned'
                    WHEN CURDATE() > loans.due_date THEN 'Overdue'
                    ELSE 'Borrowed'
                END AS status
            FROM loans
            JOIN books ON loans.book_id = books.book_id
            JOIN authors ON books.author_id = authors.author_id
            JOIN borrowers ON loans.borrower_id = borrowers.borrower_id
            WHERE loans.loan_id = @loanId
        "

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@loanId", loanId)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                labelBT.Text = reader("book_title").ToString()
                labelA.Text = reader("author_name").ToString()
                labelBBy.Text = reader("borrower_name").ToString()
                labelLD.Text = Convert.ToDateTime(reader("loan_date")).ToShortDateString()
                labelDD.Text = Convert.ToDateTime(reader("due_date")).ToShortDateString()
                labelRD.Text = If(IsDBNull(reader("return_date")), "Not Returned", Convert.ToDateTime(reader("return_date")).ToShortDateString())
                labelS.Text = reader("status").ToString()
            Else
                MessageBox.Show("Loan record not found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading loan details: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

End Class
