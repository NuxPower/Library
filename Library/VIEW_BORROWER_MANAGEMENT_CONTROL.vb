Imports MySql.Data.MySqlClient

Public Class VIEW_BORROWER_MANAGEMENT_CONTROL

    Private borrowerId As Integer = -1 ' Store the borrower ID

    ' Default constructor (for backward compatibility)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor that accepts borrower ID
    Public Sub New(borrowerIdParam As Integer)
        InitializeComponent()
        borrowerId = borrowerIdParam
    End Sub

    Private Sub VIEW_BORROWER_MANAGEMENT_CONTROL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Dock = DockStyle.Fill
        ConfigureListView()
        LoadLoanList()
        ListView1_Resize(ListView1, EventArgs.Empty)
    End Sub

    Private Sub ConfigureListView()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Columns.Clear()

            .Columns.Add("LOAN ID", 80, HorizontalAlignment.Center)
            .Columns.Add("BORROWER NAME", 150, HorizontalAlignment.Left)
            .Columns.Add("BOOK TITLE", 200, HorizontalAlignment.Left)
            .Columns.Add("LOAN DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("DUE DATE", 120, HorizontalAlignment.Center)
            .Columns.Add("STATUS", 120, HorizontalAlignment.Center)

            AddHandler .DrawColumnHeader, AddressOf DrawHeader
            AddHandler .DrawSubItem, AddressOf DrawSubItemCustom
            AddHandler .Resize, AddressOf ListView1_Resize
            AddHandler .SelectedIndexChanged, AddressOf ListView1_SelectedIndexChanged ' Add event handler
        End With
    End Sub

    Private Sub LoadLoanList()
        ListView1.Items.Clear()

        Try
            ' Initialize and open your DB connection here
            dbConn()

            Dim query As String
            Dim cmd As MySqlCommand

            If borrowerId > 0 Then
                ' Filter loans for specific borrower
                query = "SELECT l.loan_id, b.name as borrower_name, bk.title as book_title, " &
                       "l.loan_date, l.due_date, l.return_date " &
                       "FROM loans l " &
                       "INNER JOIN borrowers b ON l.borrower_id = b.borrower_id " &
                       "INNER JOIN books bk ON l.book_id = bk.book_id " &
                       "WHERE l.borrower_id = @borrowerId " &
                       "ORDER BY l.loan_date DESC"

                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@borrowerId", borrowerId)
            Else
                ' Show all loans (original behavior)
                query = "SELECT l.loan_id, b.name as borrower_name, bk.title as book_title, " &
                       "l.loan_date, l.due_date, l.return_date " &
                       "FROM loans l " &
                       "INNER JOIN borrowers b ON l.borrower_id = b.borrower_id " &
                       "INNER JOIN books bk ON l.book_id = bk.book_id " &
                       "ORDER BY l.loan_date DESC"

                cmd = New MySqlCommand(query, conn)
            End If

            Using cmd
                Using reader = cmd.ExecuteReader()
                    If Not reader.HasRows And borrowerId > 0 Then
                        ' No loans found for this borrower - show a message
                        Dim noLoansItem As New ListViewItem("No loans found")
                        noLoansItem.SubItems.Add("")
                        noLoansItem.SubItems.Add("This borrower has no loan history")
                        noLoansItem.SubItems.Add("")
                        noLoansItem.SubItems.Add("")
                        noLoansItem.SubItems.Add("")
                        ListView1.Items.Add(noLoansItem)
                    Else
                        While reader.Read()
                            Dim item As New ListViewItem(reader("loan_id").ToString())
                            item.SubItems.Add(reader("borrower_name").ToString())
                            item.SubItems.Add(reader("book_title").ToString())
                            item.SubItems.Add(Convert.ToDateTime(reader("loan_date")).ToShortDateString())
                            item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToShortDateString())

                            ' Determine status based on return_date
                            Dim status As String
                            If IsDBNull(reader("return_date")) Then
                                ' Book not returned yet - check if overdue
                                If DateTime.Now.Date > Convert.ToDateTime(reader("due_date")).Date Then
                                    status = "OVERDUE"
                                Else
                                    status = "ACTIVE"
                                End If
                            Else
                                status = "RETURNED"
                            End If
                            item.SubItems.Add(status)

                            ListView1.Items.Add(item)
                        End While
                    End If
                End Using
            End Using

            dbDisconn()
        Catch ex As Exception
            MessageBox.Show("Error loading borrower data: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            dbDisconn()
        End Try
    End Sub

    ' Handle ListView selection change
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedLoanId As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(0).Text)
            LoadBorrowerDetails(selectedLoanId)
        End If
    End Sub

    ' Load borrower details based on selected loan ID
    Private Sub LoadBorrowerDetails(loanId As Integer)
        Try
            dbConn()

            ' Query to get borrower details based on loan ID
            Dim query As String = "SELECT b.name, b.email, b.mobile_no " &
                                  "FROM borrowers b " &
                                  "INNER JOIN loans l ON b.borrower_id = l.borrower_id " &
                                  "WHERE l.loan_id = @loanId"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@loanId", loanId)

            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    labelName.Text = reader("name").ToString()
                    labelEmail.Text = reader("email").ToString()
                    labelNum.Text = reader("mobile_no").ToString()
                End If
            End Using

            dbDisconn()

        Catch ex As Exception
            MessageBox.Show("Error loading borrower details: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dbDisconn()
        End Try
    End Sub

    Private Sub DrawHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        e.DrawBackground()
        TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub DrawSubItemCustom(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawBackground()

        Dim alignFlags As TextFormatFlags = TextFormatFlags.VerticalCenter
        If e.Header.Text = "LOAN ID" OrElse e.Header.Text = "LOAN DATE" OrElse e.Header.Text = "DUE DATE" OrElse e.Header.Text = "STATUS" Then
            alignFlags = alignFlags Or TextFormatFlags.HorizontalCenter
        Else
            alignFlags = alignFlags Or TextFormatFlags.Left
        End If

        ' Color coding for status
        Dim textColor As Color = e.Item.ListView.ForeColor
        If e.Header.Text = "STATUS" Then
            Select Case e.SubItem.Text.ToUpper()
                Case "OVERDUE"
                    textColor = Color.Red
                Case "ACTIVE"
                    textColor = Color.Blue
                Case "RETURNED"
                    textColor = Color.Green
            End Select
        End If

        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, e.Bounds, textColor, alignFlags)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Dim totalWidth As Integer = ListView1.ClientSize.Width
        Dim col0Width As Integer = 80    ' LOAN ID
        Dim col1Width As Integer = 150   ' BORROWER NAME
        Dim col3Width As Integer = 120   ' LOAN DATE
        Dim col4Width As Integer = 120   ' DUE DATE
        Dim col5Width As Integer = 120   ' STATUS

        Dim remainingWidth As Integer = totalWidth - col0Width - col1Width - col3Width - col4Width - col5Width
        If remainingWidth < 100 Then remainingWidth = 100 ' minimum width for BOOK TITLE

        ListView1.Columns(0).Width = col0Width
        ListView1.Columns(1).Width = col1Width
        ListView1.Columns(2).Width = remainingWidth ' BOOK TITLE
        ListView1.Columns(3).Width = col3Width
        ListView1.Columns(4).Width = col4Width
        ListView1.Columns(5).Width = col5Width
    End Sub

    ' Use the global connection methods from Global_Module
    Private Sub dbConn()
        Global_Module.dbConn()
    End Sub

    Private Sub dbDisconn()
        Global_Module.dbDisconn()
    End Sub

    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
