Imports MySql.Data.MySqlClient

Public Class add_auth
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim firstName As String = txtFirst.Text.Trim()
        Dim lastName As String = txtLast.Text.Trim()
        Dim fullName As String = firstName & " " & lastName

        If String.IsNullOrWhiteSpace(firstName) OrElse String.IsNullOrWhiteSpace(lastName) Then
            MessageBox.Show("Please enter both first and last name.")
            Return
        End If

        Dim books As New List(Of String) From {
            txtBook1.Text.Trim(),
            txtBook2.Text.Trim(),
            txtBook3.Text.Trim(),
            txtBook4.Text.Trim()
        }

        books.RemoveAll(Function(b) String.IsNullOrWhiteSpace(b))

        If books.Count = 0 Then
            MessageBox.Show("Please enter at least one book.")
            Return
        End If

        Try
            dbConn()

            ' Insert author and get ID
            Dim cmdAuthor As New MySqlCommand("INSERT INTO authors (name) VALUES (@name); SELECT LAST_INSERT_ID();", conn)
            cmdAuthor.Parameters.AddWithValue("@name", fullName)
            Dim authorId As Integer = Convert.ToInt32(cmdAuthor.ExecuteScalar())

            ' Insert books
            For Each book In books
                Dim cmdBook As New MySqlCommand("INSERT INTO books (title, author_id) VALUES (@title, @authid)", conn)
                cmdBook.Parameters.AddWithValue("@title", book)
                cmdBook.Parameters.AddWithValue("@authid", authorId)
                cmdBook.ExecuteNonQuery()
            Next

            MessageBox.Show("Author and books added successfully.")

            ' Optional: Clear fields
            txtFirst.Clear()
            txtLast.Clear()
            txtBook1.Clear()
            txtBook2.Clear()
            txtBook3.Clear()
            txtBook4.Clear()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
