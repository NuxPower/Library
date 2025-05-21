Imports MySql.Data.MySqlClient

Public Class update_book

    ' Public properties to receive data from the caller
    Public Property BookId As Integer
    Public Property BookTitle As String
    Public Property BookISBN As String
    Public Property AuthorId As Integer

    ' List to keep authors
    Private authorsList As New List(Of Tuple(Of Integer, String))

    Private Sub update_book_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load authors to ComboBox and select the current one
        Try
            dbConn()
            Dim cmd As New MySqlCommand("SELECT author_id, name FROM authors ORDER BY name ASC", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            authorsList.Clear()
            Combo_Authors.Items.Clear()
            While reader.Read()
                Dim id As Integer = reader.GetInt32("author_id")
                Dim name As String = reader.GetString("name")
                authorsList.Add(Tuple.Create(id, name))
                Combo_Authors.Items.Add(name)
            End While
            reader.Close()
            dbDisconn()

            ' Set field values from properties
            Title_box.Text = BookTitle
            isbn_box.Text = BookISBN

            ' Set selected author in ComboBox
            Dim selectedIndex As Integer = authorsList.FindIndex(Function(x) x.Item1 = AuthorId)
            If selectedIndex >= 0 Then
                Combo_Authors.SelectedIndex = selectedIndex
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading authors: " & ex.Message)
            dbDisconn()
        End Try
    End Sub

    Private Sub save_button_Click(sender As Object, e As EventArgs) Handles save_button.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(Title_box.Text) OrElse Combo_Authors.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all fields.")
            Exit Sub
        End If

        Dim selectedAuthorId As Integer = authorsList(Combo_Authors.SelectedIndex).Item1

        Try
            dbConn()
            Dim cmd As New MySqlCommand("UPDATE books SET title = @title, author_id = @aid, isbn = @isbn WHERE book_id = @bid", conn)
            cmd.Parameters.AddWithValue("@title", Title_box.Text.Trim())
            cmd.Parameters.AddWithValue("@aid", selectedAuthorId)
            cmd.Parameters.AddWithValue("@isbn", isbn_box.Text.Trim())
            cmd.Parameters.AddWithValue("@bid", BookId)

            Dim result = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Book updated successfully.")
                Me.Close()
            Else
                MessageBox.Show("Update failed. No record updated.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating book: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub cancel_button_Click(sender As Object, e As EventArgs) Handles cancel_button.Click
        Me.Close()
    End Sub

    Private Sub delete_button_Click(sender As Object, e As EventArgs) Handles delete_button.Click
        ' Confirm first
        Dim confirmResult As DialogResult = MessageBox.Show(
        "Are you sure you want to delete this book? This action cannot be undone.",
        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirmResult = DialogResult.Yes Then
            Try
                dbConn()
                Dim cmd As New MySqlCommand("DELETE FROM books WHERE book_id = @bid", conn)
                cmd.Parameters.AddWithValue("@bid", BookId)
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Book deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("Delete failed. Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbDisconn()
            End Try
        End If
    End Sub

    ' Other controls' event handlers as needed...

End Class
