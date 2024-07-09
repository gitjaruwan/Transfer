<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfirm
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
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdFind = New System.Windows.Forms.Button
        Me.Cmd_Save = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.CbHead_Id = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.CbTrfNo = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTrfNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CbDep_Id = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CbSup_Id = New System.Windows.Forms.ComboBox
        Me.Cmd_Update = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.CbDep_Id2 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgLookUpFact = New System.Windows.Forms.DataGrid
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSearchFact = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(1168, 63)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(85, 39)
        Me.CmdExit.TabIndex = 16
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrt
        '
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(638, 15)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(85, 35)
        Me.cmdPrt.TabIndex = 7
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        Me.cmdPrt.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(1280, 42)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(212, 150)
        Me.CrystalReportViewer1.TabIndex = 28
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 151)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1246, 394)
        Me.DataGridView1.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LavenderBlush
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmdFind)
        Me.GroupBox1.Controls.Add(Me.Cmd_Save)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.CmdExcel)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.CbHead_Id)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.CbTrfNo)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtTrfNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdPrt)
        Me.GroupBox1.Controls.Add(Me.CbDep_Id)
        Me.GroupBox1.Controls.Add(Me.CmdExit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CbSup_Id)
        Me.GroupBox1.Controls.Add(Me.Cmd_Update)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CmdAdd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.CbDep_Id2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1271, 601)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "แผนกที่รับโอน"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(1023, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 16)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "3.บันทึกยืนยันการรับโอน"
        '
        'CmdFind
        '
        Me.CmdFind.ForeColor = System.Drawing.Color.Black
        Me.CmdFind.Image = Global.Transfer.My.Resources.Resources.if_Search_132289
        Me.CmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdFind.Location = New System.Drawing.Point(346, 12)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(85, 41)
        Me.CmdFind.TabIndex = 250
        Me.CmdFind.Text = "ค้นหา"
        Me.CmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFind.UseVisualStyleBackColor = True
        '
        'Cmd_Save
        '
        Me.Cmd_Save.ForeColor = System.Drawing.Color.Red
        Me.Cmd_Save.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g
        Me.Cmd_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Save.Location = New System.Drawing.Point(1167, 108)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(85, 36)
        Me.Cmd_Save.TabIndex = 249
        Me.Cmd_Save.Text = "บันทึก"
        Me.Cmd_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(907, 562)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 127
        Me.Label24.Text = "รวม Incentive"
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(728, 14)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(85, 36)
        Me.CmdExcel.TabIndex = 120
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        Me.CmdExcel.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(772, 562)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 13)
        Me.Label23.TabIndex = 126
        Me.Label23.Text = "รวม Ot นักขัตถ์"
        '
        'CbHead_Id
        '
        Me.CbHead_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbHead_Id.FormattingEnabled = True
        Me.CbHead_Id.Location = New System.Drawing.Point(716, 54)
        Me.CbHead_Id.Name = "CbHead_Id"
        Me.CbHead_Id.Size = New System.Drawing.Size(39, 21)
        Me.CbHead_Id.TabIndex = 2
        Me.CbHead_Id.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(660, 562)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 125
        Me.Label22.Text = "รวม OT ปกติ"
        '
        'CbTrfNo
        '
        Me.CbTrfNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbTrfNo.FormattingEnabled = True
        Me.CbTrfNo.Location = New System.Drawing.Point(699, 82)
        Me.CbTrfNo.Name = "CbTrfNo"
        Me.CbTrfNo.Size = New System.Drawing.Size(67, 21)
        Me.CbTrfNo.TabIndex = 119
        Me.CbTrfNo.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(547, 562)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 124
        Me.Label21.Text = "รวม ชม.ปกติ"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 109)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 118
        Me.CheckBox1.Text = "Select All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(642, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "*หัวหน้าหน่วย"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(665, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "*ชุด"
        Me.Label12.Visible = False
        '
        'txtTrfNo
        '
        Me.txtTrfNo.Location = New System.Drawing.Point(772, 83)
        Me.txtTrfNo.Name = "txtTrfNo"
        Me.txtTrfNo.Size = New System.Drawing.Size(27, 20)
        Me.txtTrfNo.TabIndex = 3
        Me.txtTrfNo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(10, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 16)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "2.เลือกพนักงานที่จะยืนยันการรับโอน"
        '
        'CbDep_Id
        '
        Me.CbDep_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbDep_Id.FormattingEnabled = True
        Me.CbDep_Id.Location = New System.Drawing.Point(590, 21)
        Me.CbDep_Id.Name = "CbDep_Id"
        Me.CbDep_Id.Size = New System.Drawing.Size(39, 21)
        Me.CbDep_Id.TabIndex = 4
        Me.CbDep_Id.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(547, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "แผนก"
        Me.Label5.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "1.ป้อนวันที่ แผนกที่รับโอน"
        '
        'CbSup_Id
        '
        Me.CbSup_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbSup_Id.FormattingEnabled = True
        Me.CbSup_Id.Location = New System.Drawing.Point(597, 51)
        Me.CbSup_Id.Name = "CbSup_Id"
        Me.CbSup_Id.Size = New System.Drawing.Size(39, 21)
        Me.CbSup_Id.TabIndex = 1
        Me.CbSup_Id.Visible = False
        '
        'Cmd_Update
        '
        Me.Cmd_Update.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Update.Location = New System.Drawing.Point(499, 25)
        Me.Cmd_Update.Name = "Cmd_Update"
        Me.Cmd_Update.Size = New System.Drawing.Size(42, 25)
        Me.Cmd_Update.TabIndex = 107
        Me.Cmd_Update.Text = "Update All"
        Me.Cmd_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Update.UseVisualStyleBackColor = True
        Me.Cmd_Update.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(523, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "*Supervisor"
        Me.Label10.Visible = False
        '
        'CmdAdd
        '
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.Location = New System.Drawing.Point(1167, 16)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(85, 41)
        Me.CmdAdd.TabIndex = 6
        Me.CmdAdd.Text = "เริ่มใหม่"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(187, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "*วันที่โอน"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(240, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.Value = New Date(2018, 2, 28, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(9, 562)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "รวม รายการ"
        '
        'CbDep_Id2
        '
        Me.CbDep_Id2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbDep_Id2.FormattingEnabled = True
        Me.CbDep_Id2.Location = New System.Drawing.Point(240, 54)
        Me.CbDep_Id2.Name = "CbDep_Id2"
        Me.CbDep_Id2.Size = New System.Drawing.Size(267, 21)
        Me.CbDep_Id2.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(154, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "*แผนกที่รับโอน"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgLookUpFact)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtSearchFact)
        Me.Panel2.Location = New System.Drawing.Point(1289, 214)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(473, 266)
        Me.Panel2.TabIndex = 99
        Me.Panel2.Visible = False
        '
        'dgLookUpFact
        '
        Me.dgLookUpFact.DataMember = ""
        Me.dgLookUpFact.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLookUpFact.Location = New System.Drawing.Point(8, 32)
        Me.dgLookUpFact.Name = "dgLookUpFact"
        Me.dgLookUpFact.PreferredColumnWidth = 100
        Me.dgLookUpFact.Size = New System.Drawing.Size(449, 192)
        Me.dgLookUpFact.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(8, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(240, 16)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "ดับเบิลคลิกที่หัวแถว เพื่อเลือกข้อมูล"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(8, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "ค้นหาข้อมูล:"
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
        'FrmConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 606)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmConfirm"
        Me.Text = "ระบบการยืนยันการรับโอนคน/ค่าแรง"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgLookUpFact As System.Windows.Forms.DataGrid
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFact As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Update As System.Windows.Forms.Button
    Friend WithEvents CbSup_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbDep_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbDep_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTrfNo As System.Windows.Forms.TextBox
    Friend WithEvents CbHead_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbTrfNo As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents CmdFind As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
