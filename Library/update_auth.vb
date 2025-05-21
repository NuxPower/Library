Imports MySql.Data.MySqlClient

Public Class update_auth
    Public Property AuthorId As Integer
    Public Property AuthorName As String
    Public Property AuthorId As Integer

    Private Sub update_auth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Text = AuthorName ' Assuming you have a TextBox named TextBoxName
    Private Sub update_auth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAuthorData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newName As String = TextBox4.Text.Trim()
        If String.IsNullOrEmpty(newName) Then
            MessageBox.Show("Author name cannot be empty.")
            Exit Sub
        End If
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

                Try
                    dbConn()
                    Dim query As String = "UPDATE Authors SET name = @name WHERE author_id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@name", newName)
                        cmd.Parameters.AddWithValue("@id", AuthorId)
                        Dim rowsAffected = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("Author updated successfully.")
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        Else
                            MessageBox.Show("Update failed or no changes made.")
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error updating author: " & ex.Message)
                Finally
                    dbDisconn()
                End Try
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
