Imports MySql.Data.MySqlClient

Public Class delete_conf
    ' BookId must be set by the caller before showing this form
    Public Property BookId As Integer
    ' Optional: For better UI, show book title and ISBN in the dialog
    Public Property BookTitle As String
    Public Property BookISBN As String

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Confirmation with details (optional, remove if you don't want)
        Dim confirmationMsg As String = "Are you sure you want to delete this book?" & vbCrLf &
                                        If(Not String.IsNullOrEmpty(BookTitle), "Title: " & BookTitle & vbCrLf, "") &
                                        If(Not String.IsNullOrEmpty(BookISBN), "ISBN: " & BookISBN & vbCrLf, "") &
                                        vbCrLf & "This action cannot be undone."
        Dim result = MessageBox.Show(confirmationMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> DialogResult.Yes Then Exit Sub

        dbConn()

        ' Check for active/unreturned loans ONLY
        Dim checkLoanQuery As String = "SELECT COUNT(*) FROM loans WHERE book_id = @id AND return_date IS NULL"
        Using cmdCheck As New MySqlCommand(checkLoanQuery, conn)
            cmdCheck.Parameters.AddWithValue("@id", BookId)
            Dim loanCount As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

            If loanCount > 0 Then
                MessageBox.Show("This book cannot be deleted because it is currently borrowed." & vbCrLf &
                                "Please ensure all copies are returned before deleting.",
                                "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dbDisconn()
                Exit Sub
            End If
        End Using

        ' Proceed to delete book if no active loans
        Dim query As String = "DELETE FROM books WHERE book_id = @id"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", BookId)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Book deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to delete the book.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        dbDisconn()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub delete_conf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optionally, set label text here if you want to show book info on the form
        ' e.g., BookTitleLabel.Text = BookTitle
        '       BookISBNLabel.Text = BookISBN
    End Sub
End Class
