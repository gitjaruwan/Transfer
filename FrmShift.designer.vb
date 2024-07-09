<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShift
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdRefresh = New System.Windows.Forms.Button
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.Label36 = New System.Windows.Forms.Label
        Me.CmdSave = New System.Windows.Forms.Button
        Me.DTPShift_Out = New System.Windows.Forms.DateTimePicker
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.CmdExit = New System.Windows.Forms.Button
        Me.TxtShift_Ka = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtShift_Ot = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtShift_Hr = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.DTPShift_In = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTPShift_relx2 = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.DTPShift_relx1 = New System.Windows.Forms.DateTimePicker
        Me.TxtShift_Nm = New System.Windows.Forms.TextBox
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.txtShift_Id = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgLookUpFact = New System.Windows.Forms.DataGrid
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSearchFact = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdRefresh)
        Me.GroupBox1.Controls.Add(Me.CmdExcel)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.CmdSave)
        Me.GroupBox1.Controls.Add(Me.DTPShift_Out)
        Me.GroupBox1.Controls.Add(Me.cmdPrt)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.CmdExit)
        Me.GroupBox1.Controls.Add(Me.TxtShift_Ka)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TxtShift_Ot)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.TxtShift_Hr)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.DTPShift_In)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.DTPShift_relx2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.DTPShift_relx1)
        Me.GroupBox1.Controls.Add(Me.TxtShift_Nm)
        Me.GroupBox1.Controls.Add(Me.cmdBrowse)
        Me.GroupBox1.Controls.Add(Me.txtShift_Id)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(662, 225)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ตารางทำงาน"
        '
        'CmdRefresh
        '
        Me.CmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdRefresh.ForeColor = System.Drawing.Color.Red
        Me.CmdRefresh.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdRefresh.Location = New System.Drawing.Point(254, 175)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(75, 38)
        Me.CmdRefresh.TabIndex = 68
        Me.CmdRefresh.Text = "เริ่มใหม่"
        Me.CmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'CmdExcel
        '
        Me.CmdExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(416, 175)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(75, 38)
        Me.CmdExcel.TabIndex = 71
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(268, 68)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(68, 24)
        Me.Label36.TabIndex = 86
        Me.Label36.Text = "เวลาออก"
        '
        'CmdSave
        '
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdSave.ForeColor = System.Drawing.Color.Red
        Me.CmdSave.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g1
        Me.CmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.Location = New System.Drawing.Point(335, 175)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 38)
        Me.CmdSave.TabIndex = 67
        Me.CmdSave.Text = "บันทึก"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'DTPShift_Out
        '
        Me.DTPShift_Out.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPShift_Out.Location = New System.Drawing.Point(349, 64)
        Me.DTPShift_Out.Name = "DTPShift_Out"
        Me.DTPShift_Out.ShowUpDown = True
        Me.DTPShift_Out.Size = New System.Drawing.Size(92, 29)
        Me.DTPShift_Out.TabIndex = 85
        Me.DTPShift_Out.Value = New Date(2009, 2, 18, 17, 0, 0, 0)
        '
        'cmdPrt
        '
        Me.cmdPrt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(497, 175)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(75, 38)
        Me.cmdPrt.TabIndex = 70
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(58, 175)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 24)
        Me.Label26.TabIndex = 84
        Me.Label26.Text = "ค่ากะ"
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(578, 175)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 38)
        Me.CmdExit.TabIndex = 69
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'TxtShift_Ka
        '
        Me.TxtShift_Ka.Location = New System.Drawing.Point(125, 172)
        Me.TxtShift_Ka.Name = "TxtShift_Ka"
        Me.TxtShift_Ka.Size = New System.Drawing.Size(71, 29)
        Me.TxtShift_Ka.TabIndex = 83
        Me.TxtShift_Ka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(268, 139)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 24)
        Me.Label25.TabIndex = 82
        Me.Label25.Text = "Ot/ชม."
        '
        'TxtShift_Ot
        '
        Me.TxtShift_Ot.Location = New System.Drawing.Point(351, 137)
        Me.TxtShift_Ot.Name = "TxtShift_Ot"
        Me.TxtShift_Ot.Size = New System.Drawing.Size(71, 29)
        Me.TxtShift_Ot.TabIndex = 81
        Me.TxtShift_Ot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(2, 143)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(111, 24)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "ชม.ทำงาน/วัน"
        '
        'TxtShift_Hr
        '
        Me.TxtShift_Hr.Location = New System.Drawing.Point(125, 136)
        Me.TxtShift_Hr.Name = "TxtShift_Hr"
        Me.TxtShift_Hr.Size = New System.Drawing.Size(72, 29)
        Me.TxtShift_Hr.TabIndex = 79
        Me.TxtShift_Hr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(458, 140)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 24)
        Me.Label22.TabIndex = 77
        Me.Label22.Text = "บาท"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(202, 175)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 24)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "บาท"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(203, 143)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 24)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "ชม."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(43, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 24)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "เวลาเข้า"
        '
        'DTPShift_In
        '
        Me.DTPShift_In.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPShift_In.Location = New System.Drawing.Point(126, 64)
        Me.DTPShift_In.MaxDate = New Date(4998, 12, 31, 0, 0, 0, 0)
        Me.DTPShift_In.Name = "DTPShift_In"
        Me.DTPShift_In.ShowUpDown = True
        Me.DTPShift_In.Size = New System.Drawing.Size(91, 29)
        Me.DTPShift_In.TabIndex = 64
        Me.DTPShift_In.Value = New Date(2009, 2, 18, 7, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(271, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 24)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "หยุดพัก"
        '
        'DTPShift_relx2
        '
        Me.DTPShift_relx2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPShift_relx2.Location = New System.Drawing.Point(350, 98)
        Me.DTPShift_relx2.Name = "DTPShift_relx2"
        Me.DTPShift_relx2.ShowUpDown = True
        Me.DTPShift_relx2.Size = New System.Drawing.Size(91, 29)
        Me.DTPShift_relx2.TabIndex = 62
        Me.DTPShift_relx2.Value = New Date(2009, 2, 18, 13, 0, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(50, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 24)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "เริ่มพัก"
        '
        'DTPShift_relx1
        '
        Me.DTPShift_relx1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPShift_relx1.Location = New System.Drawing.Point(126, 99)
        Me.DTPShift_relx1.Name = "DTPShift_relx1"
        Me.DTPShift_relx1.ShowUpDown = True
        Me.DTPShift_relx1.Size = New System.Drawing.Size(92, 29)
        Me.DTPShift_relx1.TabIndex = 60
        Me.DTPShift_relx1.Value = New Date(2009, 2, 18, 12, 0, 0, 0)
        '
        'TxtShift_Nm
        '
        Me.TxtShift_Nm.Location = New System.Drawing.Point(326, 26)
        Me.TxtShift_Nm.Name = "TxtShift_Nm"
        Me.TxtShift_Nm.Size = New System.Drawing.Size(269, 29)
        Me.TxtShift_Nm.TabIndex = 22
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(225, 26)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(33, 41)
        Me.cmdBrowse.TabIndex = 12
        Me.cmdBrowse.Text = "..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtShift_Id
        '
        Me.txtShift_Id.Location = New System.Drawing.Point(126, 26)
        Me.txtShift_Id.MaxLength = 3
        Me.txtShift_Id.Name = "txtShift_Id"
        Me.txtShift_Id.Size = New System.Drawing.Size(91, 29)
        Me.txtShift_Id.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(271, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ชื่อกะ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสกะ"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.dgLookUpFact)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtSearchFact)
        Me.Panel2.Location = New System.Drawing.Point(682, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 266)
        Me.Panel2.TabIndex = 48
        Me.Panel2.Visible = False
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
        'dgLookUpFact
        '
        Me.dgLookUpFact.DataMember = ""
        Me.dgLookUpFact.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLookUpFact.Location = New System.Drawing.Point(8, 32)
        Me.dgLookUpFact.Name = "dgLookUpFact"
        Me.dgLookUpFact.PreferredColumnWidth = 100
        Me.dgLookUpFact.Size = New System.Drawing.Size(339, 192)
        Me.dgLookUpFact.TabIndex = 2
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
        'txtSearchFact
        '
        Me.txtSearchFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearchFact.Location = New System.Drawing.Point(88, 8)
        Me.txtSearchFact.Name = "txtSearchFact"
        Me.txtSearchFact.Size = New System.Drawing.Size(136, 20)
        Me.txtSearchFact.TabIndex = 0
        Me.txtSearchFact.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(682, 275)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(212, 150)
        Me.CrystalReportViewer1.TabIndex = 52
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(637, 321)
        Me.DataGridView1.TabIndex = 65
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(662, 374)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "เลือกรายการ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 352)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Label2"
        '
        'FrmShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 664)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmShift"
        Me.Text = "ประวัติตารางทำงาน กะ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgLookUpFact As System.Windows.Forms.DataGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFact As System.Windows.Forms.TextBox
    Friend WithEvents TxtShift_Nm As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtShift_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTPShift_relx2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DTPShift_relx1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DTPShift_In As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtShift_Ot As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtShift_Hr As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtShift_Ka As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DTPShift_Out As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
