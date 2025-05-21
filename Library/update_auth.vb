Imports MySql.Data.MySqlClient

Public Class update_auth
    Public Property AuthorId As Integer

    Private Sub update_auth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAuthorData()
    End Sub

    Private Sub LoadAuthorData()
        Try
            dbConn()
            Dim query As String = "SELECT name FROM Authors WHERE author_id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", AuthorId)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtAuthorName.Text = reader("name").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load author data: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newName As String = txtAuthorName.Text.Trim()

        If String.IsNullOrWhiteSpace(newName) Then
            MessageBox.Show("Name cannot be empty.")
            Return
        End If

        Try
            dbConn()
            Dim query As String = "UPDATE Authors SET name = @name WHERE author_id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", newName)
                cmd.Parameters.AddWithValue("@id", AuthorId)

                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Author updated successfully.")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("No changes were made.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to update author: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
