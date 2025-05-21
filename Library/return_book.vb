Imports MySql.Data.MySqlClient

Public Class return_book
    Private loanId As Integer

    ' Constructor accepts loan ID and return date
    Public Sub New(id As Integer, returnDate As Date)
        InitializeComponent()
        loanId = id
        DateTimePicker1.Value = returnDate
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newReturnDate As Date = DateTimePicker1.Value

        Try
            dbConn()
            Dim query As String = "UPDATE loans SET return_date = @returnDate WHERE loan_id = @loanId"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@returnDate", newReturnDate)
            cmd.Parameters.AddWithValue("@loanId", loanId)

            Dim rowsAffected = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Return date updated successfully.")
                Me.Close()
            Else
                MessageBox.Show("No update performed.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating return date: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub
End Class
