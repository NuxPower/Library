<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AUTHOR_MANAGEMENT_TABLE
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AUTHOR_MANAGEMENT_TABLE))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panelA = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panelBK = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panelB = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.panelL = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.panelD = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.fragment2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBooks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colISBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUpdate = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelA.SuspendLayout()
        Me.panelBK.SuspendLayout()
        Me.panelB.SuspendLayout()
        Me.panelL.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.panelD.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.fragment2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(986, 592)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 31)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "DASHBOARD"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "AUTHORS"
        '
        'panelA
        '
        Me.panelA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelA.BackColor = System.Drawing.Color.SteelBlue
        Me.panelA.Controls.Add(Me.Label5)
        Me.panelA.Location = New System.Drawing.Point(0, 84)
        Me.panelA.Name = "panelA"
        Me.panelA.Size = New System.Drawing.Size(211, 66)
        Me.panelA.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 31)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "BOOKS"
        '
        'panelBK
        '
        Me.panelBK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelBK.BackColor = System.Drawing.Color.SteelBlue
        Me.panelBK.Controls.Add(Me.Label6)
        Me.panelBK.Location = New System.Drawing.Point(0, 168)
        Me.panelBK.Name = "panelBK"
        Me.panelBK.Size = New System.Drawing.Size(211, 66)
        Me.panelBK.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 31)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "BORROWERS"
        '
        'panelB
        '
        Me.panelB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelB.BackColor = System.Drawing.Color.SteelBlue
        Me.panelB.Controls.Add(Me.Label7)
        Me.panelB.Location = New System.Drawing.Point(0, 251)
        Me.panelB.Name = "panelB"
        Me.panelB.Size = New System.Drawing.Size(211, 66)
        Me.panelB.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(52, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 31)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "LOANS"
        '
        'panelL
        '
        Me.panelL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelL.BackColor = System.Drawing.Color.SteelBlue
        Me.panelL.Controls.Add(Me.Label8)
        Me.panelL.Location = New System.Drawing.Point(0, 333)
        Me.panelL.Name = "panelL"
        Me.panelL.Size = New System.Drawing.Size(211, 66)
        Me.panelL.TabIndex = 4
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.panelL)
        Me.Panel10.Controls.Add(Me.panelB)
        Me.Panel10.Controls.Add(Me.panelBK)
        Me.Panel10.Controls.Add(Me.panelA)
        Me.Panel10.Controls.Add(Me.panelD)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 88)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(211, 504)
        Me.Panel10.TabIndex = 1
        '
        'panelD
        '
        Me.panelD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelD.BackColor = System.Drawing.Color.SteelBlue
        Me.panelD.Controls.Add(Me.Label4)
        Me.panelD.Location = New System.Drawing.Point(0, 0)
        Me.panelD.Name = "panelD"
        Me.panelD.Size = New System.Drawing.Size(211, 66)
        Me.panelD.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(211, 592)
        Me.Panel2.TabIndex = 3
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(211, 88)
        Me.Panel9.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.LightBlue
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(225, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(225, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(507, 17)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(242, 21)
        Me.Panel4.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SORT BY DATE"
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(104, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(104, 22)
        Me.Panel6.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel5.Controls.Add(Me.PictureBox3)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.ForeColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(507, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(118, 22)
        Me.Panel5.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "SORT BY NAME"
        '
        'PictureBox4
        '
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(104, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 22)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 2
        Me.PictureBox4.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(104, 22)
        Me.Panel8.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel7.Controls.Add(Me.PictureBox4)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.ForeColor = System.Drawing.Color.Black
        Me.Panel7.Location = New System.Drawing.Point(631, 48)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(118, 22)
        Me.Panel7.TabIndex = 4
        '
        'fragment2
        '
        Me.fragment2.Controls.Add(Me.DataGridView1)
        Me.fragment2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fragment2.Location = New System.Drawing.Point(211, 88)
        Me.fragment2.Name = "fragment2"
        Me.fragment2.Size = New System.Drawing.Size(775, 504)
        Me.fragment2.TabIndex = 6
        '
        'DataGridView1
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colBooks, Me.colISBN, Me.colUpdate, Me.colDelete})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.LightBlue
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Size = New System.Drawing.Size(772, 635)
        Me.DataGridView1.TabIndex = 0
        '
        'colNo
        '
        Me.colNo.HeaderText = "No."
        Me.colNo.Name = "colNo"
        '
        'colBooks
        '
        Me.colBooks.HeaderText = "Books"
        Me.colBooks.Name = "colBooks"
        '
        'colISBN
        '
        Me.colISBN.HeaderText = "ISBN"
        Me.colISBN.Name = "colISBN"
        '
        'colUpdate
        '
        Me.colUpdate.HeaderText = "Update"
        Me.colUpdate.Name = "colUpdate"
        Me.colUpdate.Text = "Update"
        Me.colUpdate.UseColumnTextForButtonValue = True
        '
        'colDelete
        '
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Text = "Delete"
        Me.colDelete.UseColumnTextForButtonValue = True
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.Controls.Add(Me.Panel7)
        Me.Panel16.Controls.Add(Me.Panel5)
        Me.Panel16.Controls.Add(Me.Panel4)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(211, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(775, 88)
        Me.Panel16.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.fragment2)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 592)
        Me.Panel1.TabIndex = 1
        '
        'AUTHOR_MANAGEMENT_TABLE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "AUTHOR_MANAGEMENT_TABLE"
        Me.Size = New System.Drawing.Size(986, 592)
        Me.panelA.ResumeLayout(False)
        Me.panelA.PerformLayout()
        Me.panelBK.ResumeLayout(False)
        Me.panelBK.PerformLayout()
        Me.panelB.ResumeLayout(False)
        Me.panelB.PerformLayout()
        Me.panelL.ResumeLayout(False)
        Me.panelL.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.panelD.ResumeLayout(False)
        Me.panelD.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.fragment2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents colNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBooks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colISBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUpdate As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents panelA As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents panelBK As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents panelB As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents panelL As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents panelD As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents fragment2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel1 As Panel

End Class
