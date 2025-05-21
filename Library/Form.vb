Public Class Dashboard
    Inherits System.Windows.Forms.Form

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FragmentTitle.Text = "LIBRARY MANAGEMENT SYSTEM"
        dashboardLoad(New Main_Dashboard())
    End Sub

    Public Sub dashboardLoad(board As UserControl)
        fragment.Controls.Clear()           ' Clear out the old page!
        board.Dock = DockStyle.Fill
        fragment.Controls.Add(board)        ' Add the new page
        fragment.BringToFront()             ' Make sure it's on top
    End Sub

    Private Sub fragment_Paint(sender As Object, e As PaintEventArgs) Handles fragment.Paint
        ' Optional: For custom drawing, else leave empty
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Optional: For custom drawing, else leave empty
    End Sub
End Class
