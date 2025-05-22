Imports MySql.Data.MySqlClient

Public Class UPDATING_BORROWER_CONTROL
    Private borrowerId As Integer

    ' Constructor that accepts borrowerId
    Public Sub New(borrowerIdParam As Integer)
        InitializeComponent()
        borrowerId = borrowerIdParam

        ' Ensure borrowerId is valid
        If borrowerId <= 0 Then
            MessageBox.Show("Invalid Borrower ID.")
            ' Disable controls or provide an alternative behavior when invalid borrowerId
            DisableControls() ' A method to disable controls if needed
        End If
    End Sub

    Private Sub UPDATING_BORROWER_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load borrower details when the control is loaded
        If borrowerId > 0 Then
            LoadBorrowerDetails(borrowerId)
        Else
            MessageBox.Show("Invalid Borrower ID.")
        End If
    End Sub

    Private Sub LoadBorrowerDetails(borrowerId As Integer)
        Try
            dbConn()

            ' Query to get borrower details based on borrowerId
            Dim query As String = "SELECT name, email, mobile_no FROM borrowers WHERE borrower_id = @borrowerId"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@borrowerId", borrowerId)

            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    ' Populate the fields with the retrieved data
                    Dim fullName As String = reader("name").ToString()
                    Dim nameParts As String() = fullName.Split(" "c)
                    If nameParts.Length > 1 Then
                        ' Assuming first name and last name are separated by space
                        fname.Text = nameParts(0) ' First name
                        lname.Text = nameParts(1) ' Last name
                    End If

                    email_box.Text = reader("email").ToString()
                    num_box.Text = reader("mobile_no").ToString()
                Else
                    MessageBox.Show("Borrower not found.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading borrower details: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Save the updated details back to the database
    Private Sub save_but_Click(sender As Object, e As EventArgs) Handles save_but.Click
        ' Validate input fields
        Dim fnameText As String = fname.Text.Trim()
        Dim lnameText As String = lname.Text.Trim()
        Dim emailText As String = email_box.Text.Trim()
        Dim numText As String = num_box.Text.Trim()

        If String.IsNullOrWhiteSpace(fnameText) OrElse String.IsNullOrWhiteSpace(lnameText) OrElse String.IsNullOrWhiteSpace(emailText) OrElse String.IsNullOrWhiteSpace(numText) Then
            MessageBox.Show("All fields must be filled in.")
            Exit Sub
        End If

        Try
            dbConn()

            ' Query to update borrower details
            Dim updateQuery As String = "UPDATE borrowers SET name = @name, email = @email, mobile_no = @mobile WHERE borrower_id = @borrowerId"
            Using cmd As New MySqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@borrowerId", borrowerId)
                cmd.Parameters.AddWithValue("@name", fnameText & " " & lnameText) ' Combine first and last name
                cmd.Parameters.AddWithValue("@email", emailText)
                cmd.Parameters.AddWithValue("@mobile", numText)

                cmd.ExecuteNonQuery()
            End Using

            dbDisconn()

            ' Confirmation message after updating
            MessageBox.Show("Borrower details updated successfully!", "Success")

            ' Optionally, close or navigate to another form
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing Then
                parentForm.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating borrower details: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Optional method to disable controls if borrowerId is invalid
    Private Sub DisableControls()
        fname.Enabled = False
        lname.Enabled = False
        email_box.Enabled = False
        num_box.Enabled = False
    End Sub

    Private Sub cancel_but_Click(sender As Object, e As EventArgs) Handles cancel_but.Click
        ' Close the form without saving
        Dim parentForm = Me.FindForm()
        If parentForm IsNot Nothing Then
            parentForm.Close()
        End If
    End Sub

End Class
