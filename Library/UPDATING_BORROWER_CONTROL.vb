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

    ' Optional method to disable controls if borrowerId is invalid
    Private Sub DisableControls()
        fname.Enabled = False
        lname.Enabled = False
        email_box.Enabled = False
        num_box.Enabled = False
        ' Optionally, you could hide the controls instead of disabling them:
        ' fname.Visible = False
        ' lname.Visible = False
        ' email_box.Visible = False
        ' num_box.Visible = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Optional custom painting code can go here
    End Sub
End Class
