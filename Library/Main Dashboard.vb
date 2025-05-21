
Public Class Main_Dashboard

    Private Sub Main_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hook click event to child controls of panelMA
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
    End Sub


    ' Main_Dashboard (panel click event)
    Private Sub panelMA_Clicked(sender As Object, e As EventArgs) Handles panelMA.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "AUTHOR MANAGEMENT"
            parentDash.dashboardLoad(New Author_Management("AUTHORS")) ' <<== THIS, not the table
        End If
    End Sub

    Private Sub panelMBk_Clicked(sender As Object, e As EventArgs) Handles panelMBk.Click
        Dim parentDash = TryCast(Me.ParentForm, Dashboard)
        If parentDash IsNot Nothing Then
            parentDash.FragmentTitle.Text = "MANAGE BOOKS"
            parentDash.dashboardLoad(New BOOK_MANAGEMENT_TABLE()) ' ✅ load actual book table
        End If
    End Sub

    Private Sub panelMB_Clicked(sender As Object, e As EventArgs) Handles panelMB.Click
        Dashboard.FragmentTitle.Text = "MANAGE BORROWERS"
        Dashboard.dashboardLoad(New Author_Management("BORROWERS"))
    End Sub
    Private Sub panelML_Clicked(sender As Object, e As EventArgs) Handles panelML.Click
        Dim loanForm As New LOAN_MANAGEMENT("LOAN")
        loanForm.Show()
    End Sub



End Class
