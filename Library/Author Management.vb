Public Class Author_Management
    Private managementType As String

    Public Sub New(type As String)
        InitializeComponent()
        managementType = type
    End Sub

    Private Sub Author_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fragment2.Dock = DockStyle.Fill

        Select Case managementType.ToUpper()
            Case "AUTHORS"
                dashboardLoad(New AUTHOR_MANAGEMENT_TABLE())
            Case "BOOKS"
                dashboardLoad(New BOOK_MANAGEMENT_TABLE()) ' If you have one
            Case "BORROWERS"
                dashboardLoad(New BORROWER_MANAGEMENT_TABLE()) ' If you have one
            Case Else
                MessageBox.Show("Unknown management type: " & managementType)
        End Select
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
        Dim loanForm As New LOAN_MANAGEMENT("LOAN")
        loanForm.Show()
    End Sub

End Class
