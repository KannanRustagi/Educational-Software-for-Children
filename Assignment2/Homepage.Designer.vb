<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Homepage
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
        Me.Abacus = New System.Windows.Forms.Button()
        Me.Basicmath = New System.Windows.Forms.Button()
        Me.Videos = New System.Windows.Forms.Button()
        Me.Puzzlequiz = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Abacus
        '
        Me.Abacus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Abacus.Font = New System.Drawing.Font("Trebuchet MS", 10.8!, System.Drawing.FontStyle.Bold)
        Me.Abacus.Location = New System.Drawing.Point(243, 147)
        Me.Abacus.Name = "Abacus"
        Me.Abacus.Size = New System.Drawing.Size(184, 93)
        Me.Abacus.TabIndex = 0
        Me.Abacus.Text = "Abacus"
        Me.Abacus.UseVisualStyleBackColor = False
        '
        'Basicmath
        '
        Me.Basicmath.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Basicmath.Font = New System.Drawing.Font("Trebuchet MS", 10.8!, System.Drawing.FontStyle.Bold)
        Me.Basicmath.Location = New System.Drawing.Point(243, 259)
        Me.Basicmath.Name = "Basicmath"
        Me.Basicmath.Size = New System.Drawing.Size(184, 93)
        Me.Basicmath.TabIndex = 1
        Me.Basicmath.Text = "Basic Math"
        Me.Basicmath.UseVisualStyleBackColor = False
        '
        'Videos
        '
        Me.Videos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Videos.Font = New System.Drawing.Font("Trebuchet MS", 10.8!, System.Drawing.FontStyle.Bold)
        Me.Videos.Location = New System.Drawing.Point(243, 373)
        Me.Videos.Name = "Videos"
        Me.Videos.Size = New System.Drawing.Size(184, 93)
        Me.Videos.TabIndex = 2
        Me.Videos.Text = "Videos"
        Me.Videos.UseVisualStyleBackColor = False
        '
        'Puzzlequiz
        '
        Me.Puzzlequiz.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Puzzlequiz.Font = New System.Drawing.Font("Trebuchet MS", 10.8!, System.Drawing.FontStyle.Bold)
        Me.Puzzlequiz.Location = New System.Drawing.Point(243, 493)
        Me.Puzzlequiz.Name = "Puzzlequiz"
        Me.Puzzlequiz.Size = New System.Drawing.Size(184, 93)
        Me.Puzzlequiz.TabIndex = 3
        Me.Puzzlequiz.Text = "Puzzles and Quizes"
        Me.Puzzlequiz.UseVisualStyleBackColor = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.LightBlue
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RichTextBox1.Location = New System.Drawing.Point(124, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(517, 108)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = ""
        '
        'Homepage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 622)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Puzzlequiz)
        Me.Controls.Add(Me.Videos)
        Me.Controls.Add(Me.Basicmath)
        Me.Controls.Add(Me.Abacus)
        Me.Name = "Homepage"
        Me.Text = "Homepage"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Abacus As System.Windows.Forms.Button
    Friend WithEvents Basicmath As System.Windows.Forms.Button
    Friend WithEvents Videos As System.Windows.Forms.Button
    Friend WithEvents Puzzlequiz As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
