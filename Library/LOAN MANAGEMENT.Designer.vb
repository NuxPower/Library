<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOAN_MANAGEMENT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LOAN_MANAGEMENT))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FragmentTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.FragmentTitle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 95)
        Me.Panel2.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'FragmentTitle
        '
        Me.FragmentTitle.AutoSize = True
        Me.FragmentTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FragmentTitle.ForeColor = System.Drawing.SystemColors.Control
        Me.FragmentTitle.Location = New System.Drawing.Point(76, 18)
        Me.FragmentTitle.Name = "FragmentTitle"
        Me.FragmentTitle.Size = New System.Drawing.Size(427, 46)
        Me.FragmentTitle.TabIndex = 0
        Me.FragmentTitle.Text = "LOAN MANAGEMENT"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 355)
        Me.Panel1.TabIndex = 6
        '
        'LOAN_MANAGEMENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "LOAN_MANAGEMENT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LOAN_MANAGEMENT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Public WithEvents FragmentTitle As Label
    Friend WithEvents Panel1 As Panel
End Class
