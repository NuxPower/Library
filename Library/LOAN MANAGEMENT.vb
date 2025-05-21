Public Class LOAN_MANAGEMENT
    Private managementType As String
    Private dashboardRef As Dashboard

    ' Overloaded constructor for direct control display
    Public Sub New(type As String, parentDashboard As Dashboard, Optional initialControl As UserControl = Nothing)
        InitializeComponent()
        managementType = type
        dashboardRef = parentDashboard

        ' Set a context-appropriate window title and FragmentTitle label
        SetTitles(type, initialControl)

        If initialControl IsNot Nothing Then
            dashboardLoad(initialControl)
        End If
    End Sub

    Private Sub LOAN_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Dock = DockStyle.Fill

        ' Only load if not already loaded by constructor
        If Panel1.Controls.Count = 0 Then
            Select Case managementType.ToUpper()
                Case "LOAN"
                    dashboardLoad(New LOAN_MANAGEMENT_CONTROL())
                Case "BOOKS"
                    dashboardLoad(New BOOK_MANAGEMENT_CONTROL())
                Case "VIEW_BORROWER"
                    dashboardLoad(New VIEW_BORROWER_MANAGEMENT_CONTROL())
                Case "UPDATE_BORROWER"
                    dashboardLoad(New UPDATING_BORROWER_CONTROL())
                Case "AUTHORS"
                    dashboardLoad(New ADDING_AUTHOR_CONTROL())
                Case "BOOKS"
                    dashboardLoad(New ADD_BOOK_CONTROL())
                Case "BORROWERS"
                    dashboardLoad(New ADDING_BORROWER_CONTROL())
                Case Else
                    MessageBox.Show("Unknown management type: " & managementType)
            End Select
        End If
    End Sub

    ' Loads the given UserControl into Panel1 and sets FragmentTitle
    Public Sub dashboardLoad(board As UserControl)
        ' Set FragmentTitle dynamically depending on what UserControl is loaded
        If TypeOf board Is ADDING_AUTHOR_CONTROL Then
            FragmentTitle.Text = "Add Author"
            Me.Text = "Add Author"
        ElseIf TypeOf board Is ADD_BOOK_CONTROL Then
            FragmentTitle.Text = "Add Book"
            Me.Text = "Add Book"
        ElseIf TypeOf board Is ADDING_BORROWER_CONTROL Then
            FragmentTitle.Text = "Add Borrower"
            Me.Text = "Add Borrower"
        ElseIf TypeOf board Is LOAN_MANAGEMENT_CONTROL Then
            FragmentTitle.Text = "Loan Management"
            Me.Text = "Loan Management"
        ElseIf TypeOf board Is BOOK_MANAGEMENT_CONTROL Then
            FragmentTitle.Text = "Book Management"
            Me.Text = "Book Management"
        ElseIf TypeOf board Is VIEW_BORROWER_MANAGEMENT_CONTROL Then
            FragmentTitle.Text = "View Borrower"
            Me.Text = "View Borrower"
        ElseIf TypeOf board Is UPDATING_BORROWER_CONTROL Then
            FragmentTitle.Text = "Update Borrower"
            Me.Text = "Update Borrower"
        Else
            FragmentTitle.Text = "Library Management"
            Me.Text = "Library Management"
        End If

        LoadUserControl(board)
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        Panel1.Controls.Clear()
        Panel1.Dock = DockStyle.Fill

        Dim scrollablePanel As New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True
        }
        uc.Dock = DockStyle.Fill
        scrollablePanel.Controls.Add(uc)
        Panel1.Controls.Add(scrollablePanel)
    End Sub

    Private Sub SetTitles(type As String, initialControl As UserControl)
        ' This runs in the constructor only.
        Select Case type.ToUpper()
            Case "AUTHORS"
                FragmentTitle.Text = "Add Author"
                Me.Text = "Add Author"
            Case "BOOKS"
                FragmentTitle.Text = "Add Book"
                Me.Text = "Add Book"
            Case "BORROWERS"
                FragmentTitle.Text = "Add Borrower"
                Me.Text = "Add Borrower"
            Case "LOAN"
                FragmentTitle.Text = "Loan Management"
                Me.Text = "Loan Management"
            Case "UPDATE_BORROWER"
                FragmentTitle.Text = "Update Borrower"
                Me.Text = "Update Borrower"
            Case "VIEW_BORROWER"
                FragmentTitle.Text = "View Borrower"
                Me.Text = "View Borrower"
            Case Else
                FragmentTitle.Text = "Library Management"
                Me.Text = "Library Management"
        End Select

        ' If a specific UserControl is provided, let dashboardLoad handle the exact text
        If initialControl IsNot Nothing Then
            dashboardLoad(initialControl)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If dashboardRef IsNot Nothing Then
            dashboardRef.Show()
        End If
        Me.Close()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If dashboardRef IsNot Nothing Then
            dashboardRef.Show()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Optional custom drawing code here
    End Sub
End Class
