Public Class Author_Management
    Private managementType As String
    Private parentDashboard As Dashboard




    Public Sub New(type As String)
        InitializeComponent()
        managementType = type
    End Sub

    Private Sub Author_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As Control In panelD.Controls
            AddHandler ctrl.Click, AddressOf panelD_Clicked
        Next
        For Each ctrl As Control In panelA.Controls
            AddHandler ctrl.Click, AddressOf panelA_Clicked
        Next
        fragment2.Dock = DockStyle.Fill

        ' Optionally update Label1's text for feedback (remove if not needed)
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
            Case "UPDATE_BORROWER"
                dashboardLoad(New UPDATING_BORROWER_CONTROL())
            Case Else
                MessageBox.Show("Unknown management type: " & managementType)
        End Select
    End Sub

    Private Sub panelD_Clicked(sender As Object, e As EventArgs) Handles panelD.Click
        ' Get parent form (Dashboard)
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "LIBRARY MANAGEMENT SYSTEM"
            parentDash.dashboardLoad(New Main_Dashboard())
        End If
    End Sub

    Private Sub panelB_Clicked(sender As Object, e As EventArgs) Handles panelB.Click
        ' Get parent form (Dashboard)
        Dashboard.FragmentTitle.Text = "MANAGE BORROWERS"
        dashboardLoad(New BORROWER_MANAGEMENT_TABLE)
    End Sub
    Private Sub panelBk_Clicked(sender As Object, e As EventArgs) Handles panelBK.Click
        ' Get parent form (Dashboard)
        Dashboard.FragmentTitle.Text = "MANAGE BOOKS"
        dashboardLoad(New BOOK_MANAGEMENT_TABLE)
    End Sub
    Private Sub panelA_Clicked(sender As Object, e As EventArgs) Handles panelA.Click
        ' Get parent form (Dashboard)
        Dashboard.FragmentTitle.Text = "MANAGE AUTHORS"
        dashboardLoad(New AUTHOR_MANAGEMENT_TABLE)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ShowAddPanel()
    End Sub

    Private Sub ShowAddPanel()
        Dim addControl As UserControl = Nothing

        Select Case managementType.ToUpper()
            Case "AUTHORS"
                addControl = New ADDING_AUTHOR_CONTROL()
            Case "BOOKS"
                addControl = New ADD_BOOK_CONTROL()
            Case "BORROWERS"
                addControl = New ADDING_BORROWER_CONTROL()
            Case "UPDATE_BORROWER"
                addControl = New UPDATING_BORROWER_CONTROL()
            Case Else
                MessageBox.Show("Unknown management type.")
                Exit Sub
        End Select

        If addControl IsNot Nothing Then
            Dim addPanel As New Panel With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.FromArgb(220, 220, 220)
            }
            addControl.Dock = DockStyle.Fill
            addPanel.Controls.Add(addControl)

            ' Optional close button
            Dim closeBtn As New Button With {
                .Text = "X",
                .Width = 32,
                .Height = 32,
                .Top = 8,
                .Left = addPanel.Width - 40,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
            AddHandler closeBtn.Click, Sub() fragment2.Controls.Remove(addPanel)
            addPanel.Controls.Add(closeBtn)
            closeBtn.BringToFront()

            fragment2.Controls.Add(addPanel)
            addPanel.BringToFront()
        End If
    End Sub

    Public Sub dashboardLoad(board As UserControl)
        LoadUserControl(board)
    End Sub

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

    Private Sub panelL_Clicked(sender As Object, e As EventArgs) Handles panelL.Click
        Dim mainForm = TryCast(Me.FindForm(), Dashboard)  ' get Dashboard form reference
        If mainForm IsNot Nothing Then
            Dim loanForm As New LOAN_MANAGEMENT("LOAN", mainForm) ' pass Dashboard reference
            loanForm.Show()
            mainForm.Hide() ' optionally hide the dashboard form when loanForm shows
        Else
            MessageBox.Show("Dashboard form not found.")
        End If
    End Sub
    Private Sub fragment2_Paint(sender As Object, e As PaintEventArgs) Handles fragment2.Paint
        ' Custom painting if needed
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint
        ' Custom painting if needed
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim currentControl = GetCurrentControl()
        If currentControl IsNot Nothing Then
            Dim searchable = TryCast(currentControl, ISearchable)
            If searchable IsNot Nothing Then
                searchable.PerformSearch(txtSearch.Text)
            End If
        End If
    End Sub

    Private Function GetCurrentControl() As Control
        If fragment2.Controls.Count = 0 Then Return Nothing

        Dim scrollablePanel As Panel = TryCast(fragment2.Controls(0), Panel)
        If scrollablePanel Is Nothing OrElse scrollablePanel.Controls.Count = 0 Then Return Nothing

        Return scrollablePanel.Controls(0)
    End Function



End Class