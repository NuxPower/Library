Imports MySql.Data.MySqlClient

Public Class VIEW_AUTHOR_TABLE
    Inherits UserControl

    Private selectedAuthor As String
    Private _authorId As Integer
    Private bookList As List(Of Book)

    Public Sub New(Optional authorName As String = "")
        InitializeComponent()
        selectedAuthor = authorName
    End Sub


    ' Allow external class to set the author ID
    Public Sub SetAuthorId(authorId As Integer)
        _authorId = authorId
        LoadBooksByAuthor()
    End Sub

    Private Sub VIEW_AUTHOR_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        ListView1_Resize(ListView1, EventArgs.Empty)

        RemoveHandler ListView1.MouseClick, AddressOf ListView1_MouseClick
        AddHandler ListView1.MouseClick, AddressOf ListView1_MouseClick
    End Sub

    Private Class Book
        Public Property BookId As Integer
        Public Property Title As String
        Public Property ISBN As String
    End Class

    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("NO", 50, HorizontalAlignment.Center)
            .Columns.Add("BOOK", 200, HorizontalAlignment.Left)
            .Columns.Add("ISBN", 150, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 160, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawBookSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
        End With
    End Sub

    Private Sub LoadBooksByAuthor()
        If _authorId <= 0 Then
            MessageBox.Show("Invalid author ID.")
            Return
        End If

        bookList = New List(Of Book)

        Try
            dbConn()
            Dim query As String = "SELECT book_id, title, isbn FROM Books WHERE author_id = @author"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@author", _authorId)

            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim book As New Book With {
                    .BookId = reader.GetInt32("book_id"),
                    .Title = reader("title").ToString(),
                    .ISBN = reader("isbn").ToString()
                }
                bookList.Add(book)
            End While

            reader.Close()
            dbDisconn()

            DisplayBooks(bookList)

        Catch ex As Exception
            MessageBox.Show("Error loading books: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    Private Sub DisplayBooks(books As List(Of Book))
        ListView1.Items.Clear()
        Dim index As Integer = 1
        For Each b In books
            Dim item As New ListViewItem(index.ToString())
            item.SubItems.Add(b.Title)
            item.SubItems.Add(b.ISBN)
            item.SubItems.Add("") ' Action buttons placeholder
            ListView1.Items.Add(item)
            index += 1
        Next
    End Sub

    Private Sub DrawBookSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 3 ' ACTIONS
                Dim spacing As Integer = 12
                Dim btnWidth As Integer = (e.Bounds.Width - spacing - 10) \ 2
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim updateRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim deleteRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, updateRect, "Update", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "Delete", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 3 Then ' ACTIONS column
            Dim itemBounds = hitInfo.SubItem.Bounds
            Dim btnWidth As Integer = (itemBounds.Width - 10) \ 2

            Dim updateBtn = New Rectangle(itemBounds.X + 5, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)
            Dim deleteBtn = New Rectangle(itemBounds.X + btnWidth + 10, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)

            Dim bookTitle As String = hitInfo.Item.SubItems(1).Text
            Dim bookISBN As String = hitInfo.Item.SubItems(2).Text

            If updateBtn.Contains(e.Location) Then
                Dim updateForm As New VIEW_AUTHOR_TABLE_UPDATE
                ' updateForm.BookTitle = bookTitle
                If updateForm.ShowDialog() = DialogResult.OK Then
                    LoadBooksByAuthor()
                End If
            ElseIf deleteBtn.Contains(e.Location) Then
                Dim deleteForm As New delete_conf()
                ' deleteForm.BookTitle = bookTitle
                If deleteForm.ShowDialog() = DialogResult.OK Then
                    LoadBooksByAuthor()
                End If
            End If
        End If
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50 ' NO
        Dim col3Width As Integer = 160 ' ACTIONS
        Dim col2Width As Integer = 150 ' ISBN

        Dim remainingWidth As Integer = totalWidth - col0Width - col2Width - col3Width
        If remainingWidth < 0 Then remainingWidth = 0

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = remainingWidth ' BOOK
        ListView1.Columns(2).Width = col2Width
        ListView1.Columns(3).Width = col3Width
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class