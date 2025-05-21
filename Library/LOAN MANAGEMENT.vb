Public Class LOAN_MANAGEMENT
    Private managementType As String
    Private dashboardRef As Dashboard ' Holds the reference to Dashboard

    Public Sub New(type As String, parentDashboard As Dashboard)
        InitializeComponent()
        managementType = type
        dashboardRef = parentDashboard
    End Sub

    Private Sub LOAN_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Dock = DockStyle.Fill

        Select Case managementType.ToUpper()
            Case "LOAN"
                dashboardLoad(New LOAN_MANAGEMENT_CONTROL())
            Case "BOOKS"
                dashboardLoad(New BOOK_MANAGEMENT_CONTROL())
            Case "VIEW_BORROWER"
                dashboardLoad(New VIEW_BORROWER_MANAGEMENT_CONTROL())
            Case "UPDATE_BORROWER"
                dashboardLoad(New UPDATING_BORROWER_CONTROL())
            Case Else
                MessageBox.Show("Unknown management type: " & managementType)
        End Select

    End Sub

    ' Loads the given UserControl into Panel1
    Public Sub dashboardLoad(board As UserControl)
        LoadUserControl(board)
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        Panel1.Controls.Clear()
        Panel1.BringToFront()

        Dim scrollablePanel As New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True ' Add scrollbars if the control is large
        }

        uc.Dock = DockStyle.Fill
        scrollablePanel.Controls.Add(uc)
        Panel1.Controls.Add(scrollablePanel)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If dashboardRef IsNot Nothing Then
            dashboardRef.Show()
        End If
        Me.Close()
    End Sub



    ' Optional: If you want to handle custom painting in the panel
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Optional custom drawing code here
    End Sub
End Class
