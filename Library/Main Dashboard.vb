Imports MySql.Data.MySqlClient

Public Class Main_Dashboard

    Private Sub Main_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hook click events for panels
        For Each ctrl As Control In panelMA.Controls
            AddHandler ctrl.Click, AddressOf panelMA_Clicked
        Next
        For Each ctrl As Control In panelMBk.Controls
            AddHandler ctrl.Click, AddressOf panelMBk_Clicked
        Next
        For Each ctrl As Control In panelMB.Controls
            AddHandler ctrl.Click, AddressOf panelMB_Clicked
        Next
        For Each ctrl As Control In panelML.Controls
            AddHandler ctrl.Click, AddressOf panelML_Clicked
        Next

        ' Load real-time database counts
        LoadDatabaseCounts()
    End Sub

    Private Sub LoadDatabaseCounts()
        Try
            dbConn()

            ' Query total authors
            Dim cmdAuthors As New MySqlCommand("SELECT COUNT(*) FROM authors", conn)
            Label13.Text = Convert.ToString(cmdAuthors.ExecuteScalar())

            ' Query total borrowers
            Dim cmdBorrowers As New MySqlCommand("SELECT COUNT(*) FROM borrowers", conn)
            Label14.Text = Convert.ToString(cmdBorrowers.ExecuteScalar())

            ' Query total loans
            Dim cmdLoans As New MySqlCommand("SELECT COUNT(*) FROM loans", conn)
            Label15.Text = Convert.ToString(cmdLoans.ExecuteScalar())

            ' Query total books
            Dim cmdBooks As New MySqlCommand("SELECT COUNT(*) FROM books", conn)
            Label16.Text = Convert.ToString(cmdBooks.ExecuteScalar())

        Catch ex As Exception
            MessageBox.Show("Error retrieving dashboard counts: " & ex.Message)
        Finally
            dbDisconn()
        End Try
    End Sub

    ' Panel click handlers
    Private Sub panelMA_Clicked(sender As Object, e As EventArgs) Handles panelMA.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "AUTHOR MANAGEMENT"
            parentDash.dashboardLoad(New Author_Management("AUTHORS"))
        End If
    End Sub

    Private Sub panelMBk_Clicked(sender As Object, e As EventArgs) Handles panelMBk.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "MANAGE BOOKS"
            parentDash.dashboardLoad(New Author_Management("BOOKS"))
        End If
    End Sub

    Private Sub panelMB_Clicked(sender As Object, e As EventArgs) Handles panelMB.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "MANAGE BORROWERS"
            parentDash.dashboardLoad(New Author_Management("BORROWERS"))
        End If
    End Sub

    Private Sub panelML_Clicked(sender As Object, e As EventArgs) Handles panelML.Click
        Dim mainForm = TryCast(Me.FindForm(), Dashboard)
        If mainForm IsNot Nothing Then
            Dim loanForm As New LOAN_MANAGEMENT("LOAN", mainForm)
            loanForm.Show()
            mainForm.Hide()
        Else
            MessageBox.Show("Dashboard form not found.")
        End If
    End Sub

End Class
