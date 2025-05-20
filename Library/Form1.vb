Public Class Dashboard

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FragmentTitle.Text = "LIBRARY MANAGAMENT SYSTEM" ' Link to actual Label control
        Me.Controls.Add(fragment)
        dashboardLoad(New Main_Dashboard())
    End Sub

    Public Sub dashboardLoad(board As UserControl)
        LoadUserControl(board)
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        fragment.Controls.Clear()
        fragment.BringToFront()

        Dim scrollablePanel As New Panel With {
            .Dock = DockStyle.Fill
        }

        uc.Dock = DockStyle.Fill
        scrollablePanel.Controls.Add(uc)
        fragment.Controls.Add(scrollablePanel)
    End Sub


End Class
