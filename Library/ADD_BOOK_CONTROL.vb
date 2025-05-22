Imports MySql.Data.MySqlClient

Public Class ADD_BOOK_CONTROL

    Private Sub ADD_BOOK_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load authors into the combo box
        LoadAuthorsToComboBox()
    End Sub

    Private Sub LoadAuthorsToComboBox()
        author_combo_box.Items.Clear()

        Try
            dbConn()
            Dim query As String = "SELECT author_id, name FROM authors ORDER BY name ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            ' Add authors to the combo box
            While reader.Read()
                Dim item As New KeyValuePair(Of Integer, String)(reader("author_id"), reader("name").ToString())
                author_combo_box.Items.Add(item)
            End While

            author_combo_box.DisplayMember = "Value"
            author_combo_box.ValueMember = "Key"
        Catch ex As Exception
            MessageBox.Show("Error loading authors: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        ' Validate inputs
        If title_box.Text.Trim() = "" Or isbn_box.Text.Trim() = "" Or author_combo_box.SelectedItem Is Nothing Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        Try
            dbConn()

            ' Query to insert the new book
            Dim query As String = "INSERT INTO books (title, isbn, author_id) VALUES (@title, @isbn, @author_id)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@title", title_box.Text.Trim())
            cmd.Parameters.AddWithValue("@isbn", isbn_box.Text.Trim())

            ' Get the selected author's ID from the combo box
            Dim selectedAuthor = CType(author_combo_box.SelectedItem, KeyValuePair(Of Integer, String))
            cmd.Parameters.AddWithValue("@author_id", selectedAuthor.Key)

            ' Execute the query and check if the insertion was successful
            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Book added successfully.")
                ClearFields()
            Else
                MessageBox.Show("Failed to add book.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ' Close or hide the form/control
        Dim parentForm = TryCast(Me.FindForm(), LOAN_MANAGEMENT)
        If parentForm IsNot Nothing Then
            parentForm.Close() ' Close the control or form
        End If
    End Sub

    ' Clear the input fields
    Private Sub ClearFields()
        title_box.Clear()
        isbn_box.Clear()
        author_combo_box.SelectedIndex = -1
    End Sub

    ' Optional code for handling painting events (not essential for functionality)
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
    End Sub
End Class
