<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FragmentTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.fragment = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 655)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 46)
        Me.Panel2.TabIndex = 4
        '
        'FragmentTitle
        '
        Me.FragmentTitle.AutoSize = True
        Me.FragmentTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FragmentTitle.ForeColor = System.Drawing.SystemColors.Control
        Me.FragmentTitle.Location = New System.Drawing.Point(12, 23)
        Me.FragmentTitle.Name = "FragmentTitle"
        Me.FragmentTitle.Size = New System.Drawing.Size(127, 46)
        Me.FragmentTitle.TabIndex = 0
        Me.FragmentTitle.Text = "TITLE"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Panel1.Controls.Add(Me.FragmentTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1284, 95)
        Me.Panel1.TabIndex = 3
        '
        'fragment
        '
        Me.fragment.BackColor = System.Drawing.Color.Transparent
        Me.fragment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fragment.Location = New System.Drawing.Point(0, 95)
        Me.fragment.Name = "fragment"
        Me.fragment.Size = New System.Drawing.Size(1284, 560)
        Me.fragment.TabIndex = 5
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.BackgroundImage = Global.Library.My.Resources.Resources.premium_photo_1677567996070_68fa4181775a_2
        Me.ClientSize = New System.Drawing.Size(1284, 701)
        Me.Controls.Add(Me.fragment)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "Dashboard"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frame 1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Public WithEvents FragmentTitle As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents fragment As Panel
End Class
