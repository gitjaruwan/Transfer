<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prt_Trn_A1_1
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
        Me.CmdExit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.CmdPrt = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.CbDep_Id = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(204, 124)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 37)
        Me.CmdExit.TabIndex = 13
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(37, 167)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(258, 23)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'CmdPrt
        '
        Me.CmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.CmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrt.Location = New System.Drawing.Point(37, 124)
        Me.CmdPrt.Name = "CmdPrt"
        Me.CmdPrt.Size = New System.Drawing.Size(80, 37)
        Me.CmdPrt.TabIndex = 11
        Me.CmdPrt.Text = "Print"
        Me.CmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrt.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "ถึง"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(90, 37)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker2.TabIndex = 112
        Me.DateTimePicker2.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "วันที่"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(90, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker1.TabIndex = 111
        Me.DateTimePicker1.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(123, 124)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(75, 38)
        Me.CmdExcel.TabIndex = 115
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        '
        'CbDep_Id
        '
        Me.CbDep_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbDep_Id.FormattingEnabled = True
        Me.CbDep_Id.Location = New System.Drawing.Point(90, 95)
        Me.CbDep_Id.Name = "CbDep_Id"
        Me.CbDep_Id.Size = New System.Drawing.Size(234, 21)
        Me.CbDep_Id.TabIndex = 118
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "แผนกต้นสังกัด"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox1.Location = New System.Drawing.Point(204, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 77)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รอบการตัดค่า INCENTIVE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "ถึง"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(40, 19)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker3.TabIndex = 116
        Me.DateTimePicker3.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "วันที่"
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker4.Location = New System.Drawing.Point(40, 46)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker4.TabIndex = 115
        Me.DateTimePicker4.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'Prt_Trn_A1_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 204)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CbDep_Id)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmdExcel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CmdPrt)
        Me.Name = "Prt_Trn_A1_1"
        Me.Text = " สรุปการโอนพนักงาน แยกตามต้นสังกัด"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdPrt As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents CbDep_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
End Class
