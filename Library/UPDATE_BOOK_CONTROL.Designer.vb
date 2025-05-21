<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UPDATE_BOOK_CONTROL
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(946, 613)
        Me.Panel1.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Crimson
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(307, 332)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(306, 37)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "DELETE BOOK"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Location = New System.Drawing.Point(206, 226)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(515, 21)
        Me.Panel2.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(148, 21)
        Me.Panel3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "TITLE"
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.TextBox3.Location = New System.Drawing.Point(148, 0)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(367, 20)
        Me.TextBox3.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(307, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 37)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(463, 289)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 37)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(387, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UPDATE BOOK"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(388, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Select Existing Author"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(261, 143)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(414, 30)
        Me.ListBox1.TabIndex = 14
        '
        'UPDATE_BOOK_CONTROL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UPDATE_BOOK_CONTROL"
        Me.Size = New System.Drawing.Size(952, 619)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ListBox1 As ListBox
End Class
