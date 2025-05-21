Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class ADDING_AUTHOR_CONTROL

    Private Sub save_but_Click(sender As Object, e As EventArgs) Handles save_but.Click
        Dim fname As String = firstname.Text.Trim()
        Dim lname As String = lastname.Text.Trim()
        Dim fullName As String = (fname & " " & lname).Trim()

        Dim title1 As String = book1.Text.Trim()
        Dim title2 As String = book2.Text.Trim()
        Dim isbnVal1 As String = isbnx.Text.Trim()
        Dim isbnVal2 As String = isbny.Text.Trim()

        ' Validate ISBNs (allow empty, but if filled must be numeric)
        If (isbnVal1 <> "" AndAlso Not IsNumericISBN(isbnVal1)) OrElse (isbnVal2 <> "" AndAlso Not IsNumericISBN(isbnVal2)) Then
            MessageBox.Show("ISBN must be numbers only.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(fullName) Then
            MessageBox.Show("Name cannot be empty.")
            Exit Sub
        End If

        ' Show confirmation with details
        Dim detailMsg As String = $"Author: {fullName}{vbCrLf}Book 1: {title1} (ISBN: {isbnVal1}){vbCrLf}Book 2: {title2} (ISBN: {isbnVal2}){vbCrLf}{vbCrLf}Continue and save?"
        If MessageBox.Show(detailMsg, "Confirm Details", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Try
            dbConn()

            ' Check for duplicate author (by full name, case-insensitive)
            Dim checkAuthorQuery As String = "SELECT author_id FROM authors WHERE LOWER(name) = @name"
            Dim authorId As Integer = -1
            Using checkCmd As New MySqlCommand(checkAuthorQuery, conn)
                checkCmd.Parameters.AddWithValue("@name", fullName.ToLower())
                Dim result = checkCmd.ExecuteScalar()
                If result IsNot Nothing Then
                    MessageBox.Show("Author already exists!")
                    dbDisconn()
                    Exit Sub
                End If
            End Using

            ' Insert new author
            Dim insertAuthorQuery As String = "INSERT INTO authors (name, date_added) VALUES (@name, NOW())"
            Using cmd As New MySqlCommand(insertAuthorQuery, conn)
                cmd.Parameters.AddWithValue("@name", fullName)
                cmd.ExecuteNonQuery()
            End Using

            ' Get author_id
            Dim getIdCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
            authorId = Convert.ToInt32(getIdCmd.ExecuteScalar())

            ' Insert first book if not duplicate and not empty
            If Not String.IsNullOrWhiteSpace(title1) Then
                If Not BookExists(authorId, title1, isbnVal1) Then
                    InsertBook(authorId, title1, isbnVal1)
                End If
            End If

            ' Insert second book if not duplicate and not empty
            If Not String.IsNullOrWhiteSpace(title2) Then
                If Not BookExists(authorId, title2, isbnVal2) Then
                    InsertBook(authorId, title2, isbnVal2)
                End If
            End If

            dbDisconn()

            MessageBox.Show("Author and books added successfully!", "Success")

            ' Close the parent add form and let parent logic refresh the list (best practice)
            Dim parentLoanForm = Me.FindForm()
            If parentLoanForm IsNot Nothing Then
                parentLoanForm.Close()
            End If

            ' --- OPTIONAL (advanced pattern for refresh): ---
            ' If you want to signal refresh to the dashboard, raise an event here and handle it in the parent
            ' RaiseEvent AuthorAdded(Me, EventArgs.Empty)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Helper to check if the book already exists for the author (by title and ISBN)
    Private Function BookExists(authorId As Integer, title As String, isbn As String) As Boolean
        Dim exists As Boolean = False
        Dim sql As String = "SELECT COUNT(*) FROM books WHERE author_id=@aid AND LOWER(title)=@title AND isbn=@isbn"
        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@aid", authorId)
            cmd.Parameters.AddWithValue("@title", title.ToLower())
            cmd.Parameters.AddWithValue("@isbn", isbn)
            exists = (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
        End Using
        Return exists
    End Function

    ' Helper to insert book
    Private Sub InsertBook(authorId As Integer, title As String, isbn As String)
        Dim sql As String = "INSERT INTO books (title, author_id, isbn) VALUES (@title, @aid, @isbn)"
        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@title", title)
            cmd.Parameters.AddWithValue("@aid", authorId)
            cmd.Parameters.AddWithValue("@isbn", isbn)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Numeric ISBN validator
    Private Function IsNumericISBN(isbn As String) As Boolean
        Dim regex As New Regex("^\d+$")
        Return regex.IsMatch(isbn)
    End Function

    Private Sub cancel_but_Click(sender As Object, e As EventArgs) Handles cancel_but.Click
        Dim parentLoanForm = Me.FindForm()
        If parentLoanForm IsNot Nothing Then
            parentLoanForm.Close()
        End If

        ' --- Do NOT try to access Author_Management from Application.OpenForms ---
        ' Just close and let the dashboard logic handle reload/refresh
    End Sub

End Class
