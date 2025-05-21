Public Class return_book
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub return_book_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim picBox As New PictureBox()
        picBox.Image = Image.FromFile("C:\Users\huerv\Downloads\vecteezy_appointment-date-icon_.jpg") ' Or PNG etc.
        picBox.SizeMode = PictureBoxSizeMode.Zoom
        picBox.Size = New Size(120, 120) ' Change as needed
        picBox.Location = New Point(10, 10) ' Change as needed
        Me.Controls.Add(picBox)
    End Sub
End Class