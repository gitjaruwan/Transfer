<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFRePass = New System.Windows.Forms.TextBox
        Me.txtFname = New System.Windows.Forms.TextBox
        Me.txtFPassword = New System.Windows.Forms.TextBox
        Me.txtFcode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbFSub_Level = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmdExit = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgLookUpUser = New System.Windows.Forms.DataGrid
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSearchUser = New System.Windows.Forms.TextBox
        Me.cmdDel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CbShud = New System.Windows.Forms.ComboBox
        Me.CheckBox11 = New System.Windows.Forms.CheckBox
        Me.CheckBox10 = New System.Windows.Forms.CheckBox
        Me.CheckBox9 = New System.Windows.Forms.CheckBox
        Me.CheckBox8 = New System.Windows.Forms.CheckBox
        Me.CheckBox7 = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgLookUpUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdBrowse)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFRePass)
        Me.GroupBox1.Controls.Add(Me.txtFname)
        Me.GroupBox1.Controls.Add(Me.txtFPassword)
        Me.GroupBox1.Controls.Add(Me.txtFcode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ป้อนผู้เข้าใช้โปรแกรม"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(234, 38)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(24, 23)
        Me.cmdBrowse.TabIndex = 53
        Me.cmdBrowse.Text = "..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "ReType"
        '
        'txtFRePass
        '
        Me.txtFRePass.Location = New System.Drawing.Point(108, 105)
        Me.txtFRePass.Name = "txtFRePass"
        Me.txtFRePass.Size = New System.Drawing.Size(120, 20)
        Me.txtFRePass.TabIndex = 49
        '
        'txtFname
        '
        Me.txtFname.Location = New System.Drawing.Point(108, 139)
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(293, 20)
        Me.txtFname.TabIndex = 49
        '
        'txtFPassword
        '
        Me.txtFPassword.Location = New System.Drawing.Point(108, 72)
        Me.txtFPassword.Name = "txtFPassword"
        Me.txtFPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtFPassword.TabIndex = 48
        '
        'txtFcode
        '
        Me.txtFcode.Location = New System.Drawing.Point(108, 38)
        Me.txtFcode.Name = "txtFcode"
        Me.txtFcode.Size = New System.Drawing.Size(120, 20)
        Me.txtFcode.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "ชื่อ-นามสกุล"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "UserName"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(315, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "ผู้มีสิทธิป้อนข้อมูล"
        Me.Label5.Visible = False
        '
        'cbFSub_Level
        '
        Me.cbFSub_Level.FormattingEnabled = True
        Me.cbFSub_Level.Location = New System.Drawing.Point(238, 5)
        Me.cbFSub_Level.Name = "cbFSub_Level"
        Me.cbFSub_Level.Size = New System.Drawing.Size(46, 21)
        Me.cbFSub_Level.TabIndex = 50
        Me.cbFSub_Level.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "ระดับสิทธิ"
        Me.Label3.Visible = False
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(256, 446)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(72, 46)
        Me.CmdExit.TabIndex = 23
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(85, 29)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 54
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(85, 53)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox2.TabIndex = 55
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(85, 77)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox3.TabIndex = 56
        Me.CheckBox3.Text = "CheckBox3"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(277, 29)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox4.TabIndex = 57
        Me.CheckBox4.Text = "CheckBox4"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(277, 54)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox5.TabIndex = 58
        Me.CheckBox5.Text = "CheckBox5"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(277, 77)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox6.TabIndex = 59
        Me.CheckBox6.Text = "CheckBox6"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox4)
        Me.GroupBox2.Controls.Add(Me.CheckBox5)
        Me.GroupBox2.Controls.Add(Me.CheckBox6)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 228)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 104)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "สิทธิการเข้าเมนู"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgLookUpUser)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtSearchUser)
        Me.Panel2.Location = New System.Drawing.Point(672, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(340, 266)
        Me.Panel2.TabIndex = 63
        Me.Panel2.Visible = False
        '
        'dgLookUpUser
        '
        Me.dgLookUpUser.DataMember = ""
        Me.dgLookUpUser.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLookUpUser.Location = New System.Drawing.Point(8, 32)
        Me.dgLookUpUser.Name = "dgLookUpUser"
        Me.dgLookUpUser.PreferredColumnWidth = 100
        Me.dgLookUpUser.Size = New System.Drawing.Size(289, 192)
        Me.dgLookUpUser.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(8, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(240, 16)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "ดับเบิลคลิก หรือ กดปุ่ม Enter  เพื่อเลือกข้อมูล"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(8, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "ค้นหาข้อมูล:"
        '
        'txtSearchUser
        '
        Me.txtSearchUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearchUser.Location = New System.Drawing.Point(88, 8)
        Me.txtSearchUser.Name = "txtSearchUser"
        Me.txtSearchUser.Size = New System.Drawing.Size(136, 20)
        Me.txtSearchUser.TabIndex = 0
        '
        'cmdDel
        '
        Me.cmdDel.Image = Global.Transfer.My.Resources.Resources._erase
        Me.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDel.Location = New System.Drawing.Point(137, 446)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(75, 46)
        Me.cmdDel.TabIndex = 21
        Me.cmdDel.Text = "ลบ"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.Location = New System.Drawing.Point(29, 446)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 46)
        Me.cmdSave.TabIndex = 20
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CbShud)
        Me.GroupBox3.Controls.Add(Me.CheckBox11)
        Me.GroupBox3.Controls.Add(Me.CheckBox10)
        Me.GroupBox3.Controls.Add(Me.CheckBox9)
        Me.GroupBox3.Controls.Add(Me.CheckBox8)
        Me.GroupBox3.Controls.Add(Me.CheckBox7)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 337)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(636, 90)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "คีย์ชุด"
        '
        'CbShud
        '
        Me.CbShud.FormattingEnabled = True
        Me.CbShud.Location = New System.Drawing.Point(6, 19)
        Me.CbShud.Name = "CbShud"
        Me.CbShud.Size = New System.Drawing.Size(46, 21)
        Me.CbShud.TabIndex = 65
        Me.CbShud.Visible = False
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(277, 42)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox11.TabIndex = 64
        Me.CheckBox11.Text = "CheckBox11"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(277, 19)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox10.TabIndex = 63
        Me.CheckBox10.Text = "CheckBox10"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(85, 67)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox9.TabIndex = 62
        Me.CheckBox9.Text = "CheckBox9"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(85, 42)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox8.TabIndex = 61
        Me.CheckBox8.Text = "CheckBox8"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(85, 19)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox7.TabIndex = 60
        Me.CheckBox7.Text = "CheckBox7"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'FrmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 504)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cbFSub_Level)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmUser"
        Me.Text = "บันทึกประวัติผู้เข้าใช้โปรแกรม"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgLookUpUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents txtFPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtFcode As System.Windows.Forms.TextBox
    Friend WithEvents cbFSub_Level As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFRePass As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgLookUpUser As System.Windows.Forms.DataGrid
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchUser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CbShud As System.Windows.Forms.ComboBox
End Class
