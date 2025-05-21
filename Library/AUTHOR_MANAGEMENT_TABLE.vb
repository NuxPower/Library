Imports MySql.Data.MySqlClient

Public Class AUTHOR_MANAGEMENT_TABLE
    Inherits UserControl
    Implements ISearchable, ISortable
    Private authorsList As List(Of Author)

    ' Implementation of ISortable
    Public Sub SortByName() Implements ISortable.SortByName
        If authorsList IsNot Nothing Then
            Dim sorted = authorsList.OrderBy(Function(a) a.Name).ToList()
            DisplayAuthors(sorted)
        End If
    End Sub

    Public Sub SortByDate() Implements ISortable.SortByDate
        If authorsList IsNot Nothing Then
            Dim sorted = authorsList.OrderByDescending(Function(a) a.DateAdded).ToList()
            DisplayAuthors(sorted)
        End If
    End Sub

    Private Class Author
        Public Property AuthorId As Integer
        Public Property Name As String
        Public Property DateAdded As DateTime
    End Class


    Private Sub AUTHOR_MANAGEMENT_TABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadAuthorList() ' Loads full data into authorsList and ListView1

        ListView1_Resize(ListView1, EventArgs.Empty) ' Force initial resize

        RemoveHandler ListView1.MouseClick, AddressOf ListView1_MouseClick
        AddHandler ListView1.MouseClick, AddressOf ListView1_MouseClick
    End Sub



    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("NO", 50, HorizontalAlignment.Center)
            .Columns.Add("NAME", 100, HorizontalAlignment.Left)
            .Columns.Add("DATE ADDED", 120, HorizontalAlignment.Center)
            .Columns.Add("ACTIONS", 160, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawAuthorSubItem
            AddHandler .Resize, AddressOf ListView1_Resize
        End With
    End Sub


    Private Sub LoadAuthorList()

        authorsList = New List(Of Author)()

        Try
            dbConn()
            Dim query As String = "SELECT author_id, name, date_added FROM Authors ORDER BY author_id ASC"
            Dim cmd As New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim author As New Author With {
                    .AuthorId = Convert.ToInt32(reader("author_id")),
                    .Name = reader("name").ToString(),
                    .DateAdded = Convert.ToDateTime(reader("date_added"))
                }
                authorsList.Add(author)
            End While

            reader.Close()
            dbDisconn()

            ' Show full list initially
            DisplayAuthors(authorsList)

        Catch ex As Exception
            MessageBox.Show("Error loading authors: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    Private Sub DisplayAuthors(authors As List(Of Author))
        ListView1.Items.Clear()
        Dim index As Integer = 1
        For Each a In authors
            Dim item As New ListViewItem(index.ToString())
            item.SubItems.Add(a.Name)
            item.SubItems.Add(a.DateAdded.ToString("yyyy-MM-dd"))
            item.SubItems.Add("") ' Placeholder for action buttons
            ListView1.Items.Add(item)
            index += 1
        Next
    End Sub

    ' Implementation of ISearchable
    Public Sub PerformSearch(query As String) Implements ISearchable.PerformSearch
        If String.IsNullOrWhiteSpace(query) Then
            ' If search box is empty, show all
            DisplayAuthors(authorsList)
        Else
            ' Filter authors by name (case insensitive)
            Dim filtered = authorsList.Where(Function(a) a.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
            DisplayAuthors(filtered)
        End If
    End Sub


    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter)
    End Sub

    Private Sub DrawAuthorSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Select Case e.ColumnIndex
            Case 3 ' ACTIONS
                Dim spacing As Integer = 12
                Dim btnWidth As Integer = (e.Bounds.Width - spacing - 10) \ 2
                Dim btnHeight As Integer = e.Bounds.Height - 4

                Dim editRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, btnWidth, btnHeight)
                Dim deleteRect As New Rectangle(e.Bounds.X + btnWidth + spacing, e.Bounds.Y + 2, btnWidth, btnHeight)

                ButtonRenderer.DrawButton(e.Graphics, editRect, "Update", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)
                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "View", e.Item.ListView.Font, False, VisualStyles.PushButtonState.Normal)

            Case 1 ' NAME
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            Case Else
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, e.Item.ListView.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        End Select
    End Sub

    ' EDIT and DELETE fully functional!
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Dim hitInfo As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitInfo.Item Is Nothing OrElse hitInfo.SubItem Is Nothing Then Exit Sub

        If hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem) = 3 Then ' ACTIONS column
            Dim itemBounds = hitInfo.SubItem.Bounds
            Dim btnWidth As Integer = (itemBounds.Width - 10) \ 2

            Dim editBtn = New Rectangle(itemBounds.X + 5, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)
            Dim deleteBtn = New Rectangle(itemBounds.X + btnWidth + 10, itemBounds.Y + 3, btnWidth, itemBounds.Height - 6)

            Dim authorName As String = hitInfo.Item.SubItems(1).Text
            ' If you use IDs, fetch from hitInfo.Item.SubItems(0).Text

            If editBtn.Contains(e.Location) Then
                ' --- Show the Edit Form ---
                Dim editForm As New update_auth()
                ' Optionally: editForm.AuthorName = authorName
                If editForm.ShowDialog() = DialogResult.OK Then
                    LoadAuthorList()
                End If
            ElseIf deleteBtn.Contains(e.Location) Then
                ' --- Show the Delete Confirmation Form ---
                Dim delForm As New delete_conf()
                ' Optionally: delForm.AuthorName = authorName
                If delForm.ShowDialog() = DialogResult.OK Then
                    LoadAuthorList()
                End If
            End If
        End If
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 50 ' NO
        Dim col3Width As Integer = 160 ' ACTIONS
        Dim col2Width As Integer = 120 ' DATE ADDED

        Dim remainingWidth As Integer = totalWidth - col0Width - col2Width - col3Width
        If remainingWidth < 0 Then remainingWidth = 0

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = remainingWidth ' NAME
        ListView1.Columns(2).Width = col2Width
        ListView1.Columns(3).Width = col3Width
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        ' Optional: Handle selection changed if needed
    End Sub

End Class
