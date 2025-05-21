<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BOOK_MANAGEMENT_CONTROL
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
        Me.authorlabel = New System.Windows.Forms.Label()
        Me.isbn_label = New System.Windows.Forms.Label()
        Me.title_label = New System.Windows.Forms.Label()
        Me.book_id = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Status_label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.authorlabel)
        Me.Panel1.Controls.Add(Me.isbn_label)
        Me.Panel1.Controls.Add(Me.title_label)
        Me.Panel1.Controls.Add(Me.book_id)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 179)
        Me.Panel1.TabIndex = 0
        '
        'authorlabel
        '
        Me.authorlabel.AutoSize = True
        Me.authorlabel.BackColor = System.Drawing.SystemColors.Control
        Me.authorlabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.authorlabel.ForeColor = System.Drawing.SystemColors.Desktop
        Me.authorlabel.Location = New System.Drawing.Point(748, 126)
        Me.authorlabel.Name = "authorlabel"
        Me.authorlabel.Size = New System.Drawing.Size(133, 20)
        Me.authorlabel.TabIndex = 9
        Me.authorlabel.Text = "Data goes here"
        '
        'isbn_label
        '
        Me.isbn_label.AutoSize = True
        Me.isbn_label.BackColor = System.Drawing.SystemColors.Control
        Me.isbn_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.isbn_label.ForeColor = System.Drawing.SystemColors.Desktop
        Me.isbn_label.Location = New System.Drawing.Point(716, 87)
        Me.isbn_label.Name = "isbn_label"
        Me.isbn_label.Size = New System.Drawing.Size(133, 20)
        Me.isbn_label.TabIndex = 8
        Me.isbn_label.Text = "Data goes here"
        '
        'title_label
        '
        Me.title_label.AutoSize = True
        Me.title_label.BackColor = System.Drawing.SystemColors.Control
        Me.title_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_label.ForeColor = System.Drawing.SystemColors.Desktop
        Me.title_label.Location = New System.Drawing.Point(414, 126)
        Me.title_label.Name = "title_label"
        Me.title_label.Size = New System.Drawing.Size(133, 20)
        Me.title_label.TabIndex = 7
        Me.title_label.Text = "Data goes here"
        '
        'book_id
        '
        Me.book_id.AutoSize = True
        Me.book_id.BackColor = System.Drawing.SystemColors.Control
        Me.book_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.book_id.ForeColor = System.Drawing.SystemColors.Desktop
        Me.book_id.Location = New System.Drawing.Point(439, 87)
        Me.book_id.Name = "book_id"
        Me.book_id.Size = New System.Drawing.Size(133, 20)
        Me.book_id.TabIndex = 6
        Me.book_id.Text = "Data goes here"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Location = New System.Drawing.Point(654, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "AUTHOR:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(654, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "ISBN:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(346, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "TITLE:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(346, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "BOOK ID:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Status_label)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(57, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 103)
        Me.Panel2.TabIndex = 1
        '
        'Status_label
        '
        Me.Status_label.AutoSize = True
        Me.Status_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_label.Location = New System.Drawing.Point(16, 40)
        Me.Status_label.Name = "Status_label"
        Me.Status_label.Size = New System.Drawing.Size(133, 20)
        Me.Status_label.TabIndex = 10
        Me.Status_label.Text = "Data goes here"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "STATUS:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(382, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LOAN RECORDS"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 179)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(991, 318)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'BOOK_MANAGEMENT_CONTROL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "BOOK_MANAGEMENT_CONTROL"
        Me.Size = New System.Drawing.Size(991, 497)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents authorlabel As Label
    Friend WithEvents isbn_label As Label
    Friend WithEvents title_label As Label
    Friend WithEvents book_id As Label
    Friend WithEvents Status_label As Label
End Class
