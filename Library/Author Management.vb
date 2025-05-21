Public Class Author_Management
    Private managementType As String

    Public Sub New(type As String)
        InitializeComponent()
        managementType = type
    End Sub

    Private Sub Author_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Only dock if needed, DO NOT clear/add dynamic controls!
        Panel1.Dock = DockStyle.Fill

        ' The panel and controls you designed in the Designer will show up.
        ' No need to clear Panel1 or add anything else.
        ' If you want to pre-load data, do it here (but do not clear/add controls).
    End Sub

    ' Example: Handler for the "ADD AUTHOR" button (set this in the Designer!)

    ' Example: Sort buttons


    ' Optionally, if you want to show the table dynamically, you can add:
    Public Sub ShowAuthorTable()
        Panel1.Controls.Clear()
        Dim tableUC As New AUTHOR_MANAGEMENT_TABLE()
        tableUC.Dock = DockStyle.Fill
        Panel1.Controls.Add(tableUC)
    End Sub

    ' If you need navigation to other forms (e.g., Loans)
    Private Sub panelL_Clicked(sender As Object, e As EventArgs) Handles panelL.Click
        Dim loanForm As New LOAN_MANAGEMENT("LOAN")
        loanForm.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ShowAuthorTable()
    End Sub

    ' Other event handlers as needed...


End Class
