<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VIEW_BORROWER_MANAGEMENT_CONTROL
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.labelName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 167)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.labelName)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(0, 49)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(970, 66)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(350, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "johnsmith@gmail.com"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(282, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "EMAIL:"
        '
        'labelName
        '
        Me.labelName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelName.AutoSize = True
        Me.labelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelName.Location = New System.Drawing.Point(183, 25)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(43, 20)
        Me.labelName.TabIndex = 1
        Me.labelName.Text = "ASD"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NAME:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 167)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 490)
        Me.Panel2.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(970, 490)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(569, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "PHONE NUMBER:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(718, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "+63 912 345 6789"
        '
        'VIEW_BORROWER_MANAGEMENT_CONTROL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "VIEW_BORROWER_MANAGEMENT_CONTROL"
        Me.Size = New System.Drawing.Size(970, 657)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents labelName As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
