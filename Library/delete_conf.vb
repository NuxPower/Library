Imports MySql.Data.MySqlClient

Public Class delete_conf
    Public Property BookId As Integer ' <- This stores the book ID

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            dbConn()
            Dim query As String = "DELETE FROM Books WHERE book_id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", BookId)

                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Book deleted successfully.")
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("Failed to delete the book.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting book: " & ex.Message)
        Finally
            dbDisconn()
            Me.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub delete_conf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
