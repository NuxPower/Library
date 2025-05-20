Public Class LOAN_MANAGEMENT
    Private managementType As String

    Public Sub New(type As String)
        InitializeComponent()
        managementType = type
    End Sub
    Private Sub LOAN_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Dock = DockStyle.Fill

        Select Case managementType.ToUpper()
            Case "LOAN"
                dashboardLoad(New LOAN_MANAGEMENT_CONTROL())
                'Case "BOOKS"
                '    dashboardLoad(New ) ' If you have one
                'Case "BORROWERS"
                '    dashboardLoad(New ) ' If you have one
            Case Else
                MessageBox.Show("Unknown management type: " & managementType)
        End Select
    End Sub

    Public Sub dashboardLoad(board As UserControl)
        LoadUserControl(board)
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        Panel1.Controls.Clear()
        Panel1.BringToFront()

        Dim scrollablePanel As New Panel With {
            .Dock = DockStyle.Fill
        }

        uc.Dock = DockStyle.Fill
        scrollablePanel.Controls.Add(uc)
        Panel1.Controls.Add(scrollablePanel)
    End Sub

End Class