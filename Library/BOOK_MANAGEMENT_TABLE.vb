Imports MySql.Data.MySqlClient

Public Class BOOK_MANAGEMENT_TABLE
    Implements ISearchable
    Private bookList As List(Of Book)

    Private Class Book
        Public Property BookId As Integer
        Public Property Title As String
        Public Property Author As String
        Public Property ISBN As String
    End Class

    Private Sub BOOK_MANAGEMENT_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadBookList()
        ListView1_Resize(ListView1, EventArgs.Empty)
    End Sub

    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("NO", 50, HorizontalAlignment.Center)
            .Columns.Add("TITLE", 200, HorizontalAlignment.Center)
            .Columns.Add("AUTHOR", 150, HorizontalAlignment.Center)
            .Columns.Add("ISBN", 150, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 160, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawBookSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
            RemoveHandler .MouseClick, AddressOf ListView1_MouseClick
            AddHandler .MouseClick, AddressOf ListView1_MouseClick
        End With
    End Sub

    Private Sub LoadBookList()
        bookList = New List(Of Book)()
        Try
            dbConn()
            Dim query As String = "
            SELECT b.book_id, b.title, a.name AS author_name, b.isbn
            FROM Books b
            JOIN Authors a ON b.author_id = a.author_id
            ORDER BY b.book_id ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim book As New Book With {
                    .BookId = Convert.ToInt32(reader("book_id")),
                    .Title = reader("title").ToString(),
                    .Author = reader("author_name").ToString(),
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
            Dim item As New ListViewItem(b.BookId.ToString()) ' Shows actual BookId from database
            item.SubItems.Add(b.Title)
            item.SubItems.Add(b.Author)
            item.SubItems.Add(b.ISBN)
            item.SubItems.Add("") ' Placeholder for ACTIONS
            ListView1.Items.Add(item)
            index += 1
        Next
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawBookSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 4 ' ACTIONS
                Dim spacing As Integer = 12
                Dim btnWidth As Integer = (e.Bounds.Width - spacing - 10) \ 2
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim viewRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim updateRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, viewRect, "View", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, updateRect, "Update", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case 1, 2, 3 ' TITLE, AUTHOR, ISBN
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds,
                                  e.Item.ListView.ForeColor,
                                  TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds,
                                  e.Item.ListView.ForeColor,
                                  TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 4 Then ' ACTIONS column
            Dim itemBounds = hitInfo.SubItem.Bounds
            Dim btnWidth As Integer = (itemBounds.Width - 10) \ 2

            Dim viewBtn = New Rectangle(itemBounds.X + 5, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)
            Dim updateBtn = New Rectangle(itemBounds.X + btnWidth + 10, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)

            If viewBtn.Contains(e.Location) Then
                ' Show BOOK_MANAGEMENT_CONTROL (UserControl) in fragment2 or desired panel
                Dim selectedBookId As Integer = Integer.Parse(hitInfo.Item.SubItems(0).Text)
                Dim bookView As New BOOK_MANAGEMENT_CONTROL()
                bookView.BookId = selectedBookId
                ShowInParentPanel(bookView)
            ElseIf updateBtn.Contains(e.Location) Then
                ' --- UPDATE: Pass selected book details to update_book dialog ---
                Dim selectedBookId As Integer = Integer.Parse(hitInfo.Item.SubItems(0).Text)
                Dim selectedBook = bookList.FirstOrDefault(Function(b) b.BookId = selectedBookId)
                If selectedBook Is Nothing Then
                    MessageBox.Show("Selected book not found.")
                    Exit Sub
                End If

                ' Get author_id from DB for selected book
                Dim authorId As Integer = 0
                Try
                    dbConn()
                    Dim cmd As New MySqlCommand("SELECT author_id FROM books WHERE book_id = @bid", conn)
                    cmd.Parameters.AddWithValue("@bid", selectedBookId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        authorId = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error fetching author: " & ex.Message)
                Finally
                    dbDisconn()
                End Try

                ' Pass details to update_book
                Dim upd As New update_book()
                upd.BookId = selectedBook.BookId
                upd.BookTitle = selectedBook.Title
                upd.BookISBN = selectedBook.ISBN
                upd.AuthorId = authorId
                upd.ShowDialog()
                ' Refresh list after update
                LoadBookList()
            End If
        End If
    End Sub

    ' Helper function to add a control to your parent container, e.g., fragment2
    Private Sub ShowInParentPanel(ctrl As UserControl)
        ' This assumes your UserControl sits inside a parent with a known panel (like fragment2)
        Dim parentForm = Me.FindForm()
        If parentForm IsNot Nothing Then
            ' Try to find a Panel called fragment2 in the parent form
            Dim fragmentPanel = parentForm.Controls.Find("fragment2", True).FirstOrDefault()
            If fragmentPanel IsNot Nothing AndAlso TypeOf fragmentPanel Is Panel Then
                Dim frag As Panel = DirectCast(fragmentPanel, Panel)
                frag.Controls.Clear()
                ctrl.Dock = DockStyle.Fill
                frag.Controls.Add(ctrl)
                ctrl.BringToFront()
            Else
                MessageBox.Show("fragment2 panel not found.")
            End If
        Else
            MessageBox.Show("Parent form not found.")
        End If
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50    ' NO
        Dim col4Width As Integer = 160   ' ACTIONS for 2 buttons

        ' Remaining space after fixed columns
        Dim remainingWidth As Integer = totalWidth - col0Width - col4Width
        If remainingWidth < 0 Then remainingWidth = 0

        ' Divide remaining space among TITLE, AUTHOR, ISBN
        Dim dynamicColWidth As Integer = remainingWidth \ 3

        ListView1.Columns(0).Width = col0Width        ' NO
        ListView1.Columns(1).Width = dynamicColWidth  ' TITLE
        ListView1.Columns(2).Width = dynamicColWidth  ' AUTHOR
        ListView1.Columns(3).Width = dynamicColWidth  ' ISBN
        ListView1.Columns(4).Width = col4Width        ' ACTIONS
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        ' Optional: Add code if needed for selection
    End Sub

    Public Sub PerformSearch(query As String) Implements ISearchable.PerformSearch
        If String.IsNullOrWhiteSpace(query) Then
            DisplayBooks(bookList)
        Else
            Dim filtered = bookList.Where(Function(b) b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 _
                                       OrElse b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 _
                                       OrElse b.ISBN.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
            DisplayBooks(filtered)
        End If
    End Sub

End Class
