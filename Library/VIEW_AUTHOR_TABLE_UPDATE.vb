Imports MySql.Data.MySqlClient

Public Class VIEW_AUTHOR_TABLE_UPDATE
    ' Must be set BEFORE showing this form
    Public Property BookId As Integer

    ' When the form loads, fetch the book data
    Private Sub VIEW_AUTHOR_TABLE_UPDATE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub

    ' Fetch book info from the database
    Private Sub LoadBookData()
        Try
            dbConn()
            Dim query As String = "SELECT title, isbn FROM books WHERE book_id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", BookId)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtBookTitle.Text = reader("title").ToString()   ' Set textbox with title
                        txtBookISBN.Text = reader("isbn").ToString()     ' Set textbox with ISBN
                    Else
                        MessageBox.Show("Book not found.")
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load book data: " & ex.Message)
            Me.Close()
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Save updated data to the database
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newTitle As String = txtBookTitle.Text.Trim()
        Dim newISBN As String = txtBookISBN.Text.Trim()

        If String.IsNullOrWhiteSpace(newTitle) OrElse String.IsNullOrWhiteSpace(newISBN) Then
            MessageBox.Show("Both title and ISBN are required.")
            Return
        End If

        Try
            dbConn()
            Dim query As String = "UPDATE Books SET title = @title, isbn = @isbn WHERE book_id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@title", newTitle)
                cmd.Parameters.AddWithValue("@isbn", newISBN)
                cmd.Parameters.AddWithValue("@id", BookId)

                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Book updated successfully.")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("No changes were made.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to update book: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Cancel button just closes the form
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
