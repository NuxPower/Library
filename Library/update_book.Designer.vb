<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class update_book
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Title_box = New System.Windows.Forms.TextBox()
        Me.save_button = New System.Windows.Forms.Button()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.Combo_Authors = New System.Windows.Forms.ComboBox()
        Me.delete_button = New System.Windows.Forms.Button()
        Me.isbn_box = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 55)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "UPDATE BOOK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(195, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Author"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(158, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 29)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TITLE"
        '
        'Title_box
        '
        Me.Title_box.Location = New System.Drawing.Point(234, 194)
        Me.Title_box.MinimumSize = New System.Drawing.Size(4, 30)
        Me.Title_box.Name = "Title_box"
        Me.Title_box.Size = New System.Drawing.Size(325, 20)
        Me.Title_box.TabIndex = 8
        '
        'save_button
        '
        Me.save_button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.save_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.save_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.save_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.save_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.save_button.Location = New System.Drawing.Point(194, 312)
        Me.save_button.Name = "save_button"
        Me.save_button.Size = New System.Drawing.Size(125, 35)
        Me.save_button.TabIndex = 15
        Me.save_button.Text = "SAVE"
        Me.save_button.UseVisualStyleBackColor = False
        '
        'cancel_button
        '
        Me.cancel_button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cancel_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cancel_button.Location = New System.Drawing.Point(434, 312)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.Size = New System.Drawing.Size(125, 35)
        Me.cancel_button.TabIndex = 16
        Me.cancel_button.Text = "CANCEL"
        Me.cancel_button.UseVisualStyleBackColor = False
        '
        'Combo_Authors
        '
        Me.Combo_Authors.FormattingEnabled = True
        Me.Combo_Authors.Location = New System.Drawing.Point(283, 134)
        Me.Combo_Authors.MinimumSize = New System.Drawing.Size(121, 0)
        Me.Combo_Authors.Name = "Combo_Authors"
        Me.Combo_Authors.Size = New System.Drawing.Size(174, 21)
        Me.Combo_Authors.TabIndex = 17
        Me.Combo_Authors.Text = "Select EXISTING AUTHORS"
        '
        'delete_button
        '
        Me.delete_button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.delete_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.delete_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.delete_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.delete_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.delete_button.Location = New System.Drawing.Point(307, 383)
        Me.delete_button.Name = "delete_button"
        Me.delete_button.Size = New System.Drawing.Size(125, 35)
        Me.delete_button.TabIndex = 18
        Me.delete_button.Text = "DELETE"
        Me.delete_button.UseVisualStyleBackColor = False
        '
        'isbn_box
        '
        Me.isbn_box.Location = New System.Drawing.Point(234, 243)
        Me.isbn_box.MinimumSize = New System.Drawing.Size(4, 30)
        Me.isbn_box.Name = "isbn_box"
        Me.isbn_box.Size = New System.Drawing.Size(325, 20)
        Me.isbn_box.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(169, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 29)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "ISBN"
        '
        'update_book
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.isbn_box)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.delete_button)
        Me.Controls.Add(Me.Combo_Authors)
        Me.Controls.Add(Me.cancel_button)
        Me.Controls.Add(Me.save_button)
        Me.Controls.Add(Me.Title_box)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "update_book"
        Me.Text = "add_book"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Title_box As TextBox
    Friend WithEvents save_button As Button
    Friend WithEvents cancel_button As Button
    Friend WithEvents Combo_Authors As ComboBox
    Friend WithEvents delete_button As Button
    Friend WithEvents isbn_box As TextBox
    Friend WithEvents Label4 As Label
End Class
