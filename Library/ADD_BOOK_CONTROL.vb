Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class ADD_BOOK_CONTROL

    Private Sub ADD_BOOK_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAuthorsToComboBox()
    End Sub

    Private Sub LoadAuthorsToComboBox()
        ComboBox1.Items.Clear()

        Try
            dbConn()
            Dim query As String = "SELECT author_id, name FROM authors ORDER BY name ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim item As New KeyValuePair(Of Integer, String)(reader("author_id"), reader("name").ToString())
                ComboBox1.Items.Add(item)
            End While

            ComboBox1.DisplayMember = "Value"
            ComboBox1.ValueMember = "Key"

        Catch ex As Exception
            MessageBox.Show("Error loading authors: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        ' Validate inputs
        If TextBox1.Text.Trim() = "" Or TextBox2.Text.Trim() = "" Or ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        Try
            dbConn()
            Dim query As String = "INSERT INTO books (title, isbn, author_id) VALUES (@title, @isbn, @author_id)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@title", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@isbn", TextBox2.Text.Trim())

            Dim selectedAuthor = CType(ComboBox1.SelectedItem, KeyValuePair(Of Integer, String))
            cmd.Parameters.AddWithValue("@author_id", selectedAuthor.Key)

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
        ParentForm.Close() ' or Me.Hide() if inside a user control
    End Sub

    Private Sub ClearFields()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = -1
    End Sub

End Class
