Public Class Author_Management
    Private managementType As String
    Private parentDashboard As Dashboard
    Private borrowerId As Integer = -1 ' Store the borrower ID (ensure it's set correctly elsewhere)

    ' Constructor to initialize managementType
    Public Sub New(type As String)
        InitializeComponent()
        managementType = type
    End Sub

    Private Sub Author_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Adding handlers for click events on panels
        For Each ctrl As Control In panelD.Controls
            AddHandler ctrl.Click, AddressOf panelD_Clicked
        Next

        For Each ctrl As Control In panelA.Controls
            AddHandler ctrl.Click, AddressOf panelA_Clicked
        Next

        AddHandler Panel3.Click, AddressOf panel3_Click
        For Each ctrl As Control In Panel3.Controls
            RemoveHandler ctrl.Click, AddressOf panel3_Click ' prevent double firing
            AddHandler ctrl.Click, Sub(s, eArgs) panel3_Click(Panel3, eArgs)
        Next

        ' Set label text according to management type
        Select Case managementType.ToUpper()
            Case "AUTHORS"
                Label1.Text = "ADD AUTHOR"
                Label1.Cursor = Cursors.Hand
            Case "BOOKS"
                Label1.Text = "ADD BOOK"
                Label1.Cursor = Cursors.Hand
            Case "BORROWERS"
                Label1.Text = "ADD BORROWER"
                Label1.Cursor = Cursors.Hand
            Case "UPDATE_BORROWER"
                Label1.Text = "UPDATE BORROWER"
                Label1.Cursor = Cursors.Hand
            Case Else
                Label1.Text = "ADD"
                Label1.Cursor = Cursors.Default
        End Select

        ' Load the relevant management table or control
        Select Case managementType.ToUpper()
            Case "AUTHORS"
                dashboardLoad(New AUTHOR_MANAGEMENT_TABLE())
            Case "BOOKS"
                dashboardLoad(New BOOK_MANAGEMENT_TABLE())
            Case "BORROWERS"
                dashboardLoad(New BORROWER_MANAGEMENT_TABLE())
            Case Else
                MessageBox.Show("Unknown management type: " & managementType)
        End Select
    End Sub

    ' Navigate back to the main dashboard
    Private Sub panelD_Clicked(sender As Object, e As EventArgs) Handles panelD.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "LIBRARY MANAGEMENT SYSTEM"
            parentDash.dashboardLoad(New Main_Dashboard())
        End If
    End Sub

    ' Handle panel A click (manage authors)
    Private Sub panelA_Clicked(sender As Object, e As EventArgs) Handles panelA.Click
        managementType = "AUTHORS"
        Dashboard.FragmentTitle.Text = "MANAGE AUTHORS"
        Label1.Text = "ADD AUTHOR"
        Label1.Cursor = Cursors.Hand
        dashboardLoad(New AUTHOR_MANAGEMENT_TABLE)
    End Sub

    ' Handle panel B click (manage borrowers)
    Private Sub panelB_Clicked(sender As Object, e As EventArgs) Handles panelB.Click
        managementType = "BORROWERS"
        Dashboard.FragmentTitle.Text = "MANAGE BORROWERS"
        Label1.Text = "ADD BORROWER"
        Label1.Cursor = Cursors.Hand
        dashboardLoad(New BORROWER_MANAGEMENT_TABLE)
    End Sub

    ' Handle panel BK click (manage books)
    Private Sub panelBk_Clicked(sender As Object, e As EventArgs) Handles panelBK.Click
        managementType = "BOOKS"
        Dashboard.FragmentTitle.Text = "MANAGE BOOKS"
        Label1.Text = "ADD BOOK"
        Label1.Cursor = Cursors.Hand
        dashboardLoad(New BOOK_MANAGEMENT_TABLE)
    End Sub

    ' Panel3 now handles the Add functionality
    Private Sub panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Dim addControl As UserControl = Nothing
        Dim mgmtType As String = managementType.ToUpper()

        ' Determine which control to add based on the management type
        Select Case mgmtType
            Case "AUTHORS"
                addControl = New ADDING_AUTHOR_CONTROL()
            Case "BOOKS"
                addControl = New ADD_BOOK_CONTROL()
            Case "BORROWERS"
                addControl = New ADDING_BORROWER_CONTROL()
            Case Else
                MessageBox.Show("Unknown management type.")
                Exit Sub
        End Select

        ' Load the appropriate form for adding the entity
        Dim mainForm = TryCast(Me.FindForm(), Dashboard)
        If mainForm IsNot Nothing Then
            ' Check if borrowerId is needed for UPDATE_BORROWER or VIEW_BORROWER
            If managementType.ToUpper() = "UPDATE_BORROWER" OrElse managementType.ToUpper() = "VIEW_BORROWER" Then
                ' Ensure borrowerId is valid before passing it
                If borrowerId <> -1 Then
                    ' Pass borrowerId to UPDATING_BORROWER_CONTROL constructor
                    Dim updateBorrowerControl As New UPDATING_BORROWER_CONTROL(borrowerId) ' Pass borrowerId
                    updateBorrowerControl.Show() ' Display the form
                    mainForm.Hide() ' Optionally hide the dashboard form
                Else
                    MessageBox.Show("Invalid Borrower ID.")
                End If
            Else
                ' For other management types, no borrowerId is required
                Dim loanForm As New LOAN_MANAGEMENT(mgmtType, mainForm)
                loanForm.Show()
                loanForm.dashboardLoad(addControl)
                mainForm.Hide()
            End If
        Else
            MessageBox.Show("Dashboard form not found.")
        End If
    End Sub


    ' This function loads the user control into the dashboard fragment
    Public Sub dashboardLoad(board As UserControl)
        LoadUserControl(board)
    End Sub

    ' Helper function to load the user control dynamically into the fragment2 panel
    Private Sub LoadUserControl(uc As UserControl)
        fragment2.Controls.Clear()
        fragment2.BringToFront()

        Dim scrollablePanel As New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True
        }

        uc.Dock = DockStyle.Fill
        scrollablePanel.Controls.Add(uc)
        fragment2.Controls.Add(scrollablePanel)
    End Sub

    ' Panel 5 click to sort by date
    Private Sub panel5_Click(sender As Object, e As EventArgs)
        Dim currentControl = GetCurrentControl()
        Dim sortable = TryCast(currentControl, ISortable)
        If sortable IsNot Nothing Then
            sortable.SortByDate()
        End If
    End Sub

    ' Panel 7 click to sort by name
    Private Sub panel7_Click(sender As Object, e As EventArgs)
        Dim currentControl = GetCurrentControl()
        Dim sortable = TryCast(currentControl, ISortable)
        If sortable IsNot Nothing Then
            sortable.SortByName()
        End If
    End Sub

    ' Search functionality based on text change
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim currentControl = GetCurrentControl()
        If currentControl IsNot Nothing Then
            Dim searchable = TryCast(currentControl, ISearchable)
            If searchable IsNot Nothing Then
                searchable.PerformSearch(txtSearch.Text)
            End If
        End If
    End Sub

    ' Function to get the current control being displayed
    Private Function GetCurrentControl() As Control
        If fragment2.Controls.Count = 0 Then Return Nothing

        Dim scrollablePanel As Panel = TryCast(fragment2.Controls(0), Panel)
        If scrollablePanel Is Nothing OrElse scrollablePanel.Controls.Count = 0 Then Return Nothing

        Return scrollablePanel.Controls(0)
    End Function

    ' Paint event for fragment2 (can be customized as needed)
    Private Sub fragment2_Paint(sender As Object, e As PaintEventArgs) Handles fragment2.Paint
        ' Optional custom drawing code here
    End Sub
End Class
