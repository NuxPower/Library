<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDING_AUTHOR_CONTROL
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.isbny = New System.Windows.Forms.TextBox()
        Me.isbnx = New System.Windows.Forms.TextBox()
        Me.book2 = New System.Windows.Forms.TextBox()
        Me.book1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lastname = New System.Windows.Forms.TextBox()
        Me.firstname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cancel_but = New System.Windows.Forms.Button()
        Me.save_but = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.isbny)
        Me.Panel1.Controls.Add(Me.isbnx)
        Me.Panel1.Controls.Add(Me.book2)
        Me.Panel1.Controls.Add(Me.book1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lastname)
        Me.Panel1.Controls.Add(Me.firstname)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cancel_but)
        Me.Panel1.Controls.Add(Me.save_but)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(985, 621)
        Me.Panel1.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(634, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Enter Book ISBN"
        '
        'isbny
        '
        Me.isbny.Location = New System.Drawing.Point(638, 325)
        Me.isbny.Name = "isbny"
        Me.isbny.Size = New System.Drawing.Size(308, 20)
        Me.isbny.TabIndex = 15
        '
        'isbnx
        '
        Me.isbnx.Location = New System.Drawing.Point(638, 283)
        Me.isbnx.Name = "isbnx"
        Me.isbnx.Size = New System.Drawing.Size(308, 20)
        Me.isbnx.TabIndex = 14
        '
        'book2
        '
        Me.book2.Location = New System.Drawing.Point(253, 325)
        Me.book2.Name = "book2"
        Me.book2.Size = New System.Drawing.Size(336, 20)
        Me.book2.TabIndex = 13
        '
        'book1
        '
        Me.book1.Location = New System.Drawing.Point(253, 283)
        Me.book1.Name = "book1"
        Me.book1.Size = New System.Drawing.Size(336, 20)
        Me.book1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(248, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "ADD THEIR BOOKS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(612, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Lastname"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(415, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Firstname"
        '
        'lastname
        '
        Me.lastname.Location = New System.Drawing.Point(617, 142)
        Me.lastname.Name = "lastname"
        Me.lastname.Size = New System.Drawing.Size(191, 20)
        Me.lastname.TabIndex = 8
        '
        'firstname
        '
        Me.firstname.Location = New System.Drawing.Point(420, 142)
        Me.firstname.Name = "firstname"
        Me.firstname.Size = New System.Drawing.Size(191, 20)
        Me.firstname.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(406, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NAME"
        '
        'cancel_but
        '
        Me.cancel_but.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel_but.BackColor = System.Drawing.Color.DarkTurquoise
        Me.cancel_but.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel_but.ForeColor = System.Drawing.Color.White
        Me.cancel_but.Location = New System.Drawing.Point(400, 417)
        Me.cancel_but.Name = "cancel_but"
        Me.cancel_but.Size = New System.Drawing.Size(189, 37)
        Me.cancel_but.TabIndex = 5
        Me.cancel_but.Text = "CANCEL"
        Me.cancel_but.UseVisualStyleBackColor = False
        '
        'save_but
        '
        Me.save_but.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.save_but.BackColor = System.Drawing.Color.DarkTurquoise
        Me.save_but.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_but.ForeColor = System.Drawing.Color.White
        Me.save_but.Location = New System.Drawing.Point(595, 417)
        Me.save_but.Name = "save_but"
        Me.save_but.Size = New System.Drawing.Size(189, 37)
        Me.save_but.TabIndex = 4
        Me.save_but.Text = "SAVE"
        Me.save_but.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(520, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADDING AUTHOR"
        '
        'ADDING_AUTHOR_CONTROL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ADDING_AUTHOR_CONTROL"
        Me.Size = New System.Drawing.Size(991, 627)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lastname As TextBox
    Friend WithEvents firstname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cancel_but As Button
    Friend WithEvents save_but As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents book2 As TextBox
    Friend WithEvents book1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents isbny As TextBox
    Friend WithEvents isbnx As TextBox
    Friend WithEvents Label6 As Label
End Class
