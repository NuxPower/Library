Imports MySql.Data.MySqlClient

Public Class ADDING_BORROWER_CONTROL
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Optional: Any logic for label click
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Optional: Custom panel drawing logic
    End Sub

    ' Save button click event to save borrower info
    Private Sub save_but_Click(sender As Object, e As EventArgs) Handles save_but.Click
        ' Retrieve the values from the TextBoxes
        Dim borrowerFirstName As String = fname.Text.Trim()
        Dim borrowerLastName As String = lname.Text.Trim()
        Dim borrowerEmail As String = email_box.Text.Trim()
        Dim borrowerPhone As String = num_box.Text.Trim()

        ' Validate the inputs
        If String.IsNullOrEmpty(borrowerFirstName) Then
            MessageBox.Show("Please enter the borrower's first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrEmpty(borrowerLastName) Then
            MessageBox.Show("Please enter the borrower's last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrEmpty(borrowerEmail) OrElse Not borrowerEmail.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrEmpty(borrowerPhone) OrElse borrowerPhone.Length < 10 Then
            MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert the borrower information into the database
        Try
            dbConn()

            ' SQL query to insert the borrower data
            Dim query As String = "INSERT INTO borrowers (name, email, mobile_no) VALUES (@name, @email, @mobile)"
            Dim cmd As New MySqlCommand(query, conn)

            ' Add parameters to prevent SQL injection
            cmd.Parameters.AddWithValue("@name", borrowerFirstName & " " & borrowerLastName)
            cmd.Parameters.AddWithValue("@email", borrowerEmail)
            cmd.Parameters.AddWithValue("@mobile", borrowerPhone)

            ' Execute the command
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Borrower added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear the fields after successful insertion
                fname.Clear()
                lname.Clear()
                email_box.Clear()
                num_box.Clear()
            Else
                MessageBox.Show("Failed to add borrower.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Cancel button click event to clear the form
    Private Sub cancel_but_Click(sender As Object, e As EventArgs) Handles cancel_but.Click
        ' Clear the form fields
        fname.Clear()
        lname.Clear()
        email_box.Clear()
        num_box.Clear()
    End Sub

    ' Method to connect to the database
    Private Sub dbConn()
        ' Assuming you have a global method for the DB connection
        Global_Module.dbConn()
    End Sub

    ' Method to disconnect from the database
    Private Sub dbDisconn()
        ' Assuming you have a global method to disconnect from the DB
        Global_Module.dbDisconn()
    End Sub
End Class
