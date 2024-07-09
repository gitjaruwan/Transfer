<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransFer
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.CbShift = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.CbDep_Id = New System.Windows.Forms.ComboBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label13 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CbHead_Id = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmdFind = New System.Windows.Forms.Button
        Me.txtTrfNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CbTrfNo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CbSup_Id = New System.Windows.Forms.ComboBox
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.Cmd_Update = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgLookUpFact = New System.Windows.Forms.DataGrid
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSearchFact = New System.Windows.Forms.TextBox
        Me.CmdTransfer = New System.Windows.Forms.Button
        Me.CmdReturn = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmdCosCen = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.CbRelax = New System.Windows.Forms.ComboBox
        Me.Cmd_Save = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.DTTime_Start = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmdExit = New System.Windows.Forms.Button
        Me.DTTime_End = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.txtIncentive = New System.Windows.Forms.TextBox
        Me.txtHoliday_Ot = New System.Windows.Forms.TextBox
        Me.txtNormal_Ot = New System.Windows.Forms.TextBox
        Me.TxtNormal_Hr = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CbDep_Id2 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(1351, 14)
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
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(600, 418)
        Me.DataGridView1.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.CbShift)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.CmdFind)
        Me.GroupBox1.Controls.Add(Me.txtTrfNo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.CbTrfNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CbSup_Id)
        Me.GroupBox1.Controls.Add(Me.CmdAdd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 627)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ต้นสังกัด"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(468, 85)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(19, 13)
        Me.Label28.TabIndex = 138
        Me.Label28.Text = "กะ"
        '
        'CbShift
        '
        Me.CbShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbShift.FormattingEnabled = True
        Me.CbShift.Location = New System.Drawing.Point(493, 80)
        Me.CbShift.Name = "CbShift"
        Me.CbShift.Size = New System.Drawing.Size(131, 21)
        Me.CbShift.TabIndex = 137
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Linen
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.CbDep_Id)
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CbHead_Id)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(612, 487)
        Me.GroupBox3.TabIndex = 136
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "เลือกพนักงาน"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(113, 56)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(45, 13)
        Me.Label27.TabIndex = 135
        Me.Label27.Text = "Lable27"
        Me.Label27.Visible = False
        '
        'CbDep_Id
        '
        Me.CbDep_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbDep_Id.FormattingEnabled = True
        Me.CbDep_Id.Location = New System.Drawing.Point(339, 10)
        Me.CbDep_Id.Name = "CbDep_Id"
        Me.CbDep_Id.Size = New System.Drawing.Size(267, 21)
        Me.CbDep_Id.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(95, 37)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(134, 16)
        Me.ProgressBar1.TabIndex = 122
        Me.ProgressBar1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(242, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "กรอง หัวหน้าหน่วย"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(9, 41)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 118
        Me.CheckBox1.Text = "Select All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "กรองแผนก"
        '
        'CbHead_Id
        '
        Me.CbHead_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbHead_Id.FormattingEnabled = True
        Me.CbHead_Id.Location = New System.Drawing.Point(339, 37)
        Me.CbHead_Id.Name = "CbHead_Id"
        Me.CbHead_Id.Size = New System.Drawing.Size(267, 21)
        Me.CbHead_Id.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 16)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "4.เลือกพนักงานที่จะไป"
        '
        'CmdFind
        '
        Me.CmdFind.ForeColor = System.Drawing.Color.Black
        Me.CmdFind.Image = Global.Transfer.My.Resources.Resources.if_Search_132289
        Me.CmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdFind.Location = New System.Drawing.Point(346, 8)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(85, 41)
        Me.CmdFind.TabIndex = 121
        Me.CmdFind.Text = "ค้นหา"
        Me.CmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFind.UseVisualStyleBackColor = True
        '
        'txtTrfNo
        '
        Me.txtTrfNo.Location = New System.Drawing.Point(345, 54)
        Me.txtTrfNo.Name = "txtTrfNo"
        Me.txtTrfNo.Size = New System.Drawing.Size(38, 20)
        Me.txtTrfNo.TabIndex = 3
        Me.txtTrfNo.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(204, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "*ชุด"
        '
        'CbTrfNo
        '
        Me.CbTrfNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbTrfNo.FormattingEnabled = True
        Me.CbTrfNo.Location = New System.Drawing.Point(240, 54)
        Me.CbTrfNo.Name = "CbTrfNo"
        Me.CbTrfNo.Size = New System.Drawing.Size(56, 21)
        Me.CbTrfNo.TabIndex = 119
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(178, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Supervisor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "1.ป้อนวันที่โอน แผนก หัวหน้า"
        '
        'CbSup_Id
        '
        Me.CbSup_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbSup_Id.FormattingEnabled = True
        Me.CbSup_Id.Location = New System.Drawing.Point(240, 82)
        Me.CbSup_Id.Name = "CbSup_Id"
        Me.CbSup_Id.Size = New System.Drawing.Size(222, 21)
        Me.CbSup_Id.TabIndex = 1
        '
        'CmdAdd
        '
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.Location = New System.Drawing.Point(539, 14)
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
        Me.Label16.Location = New System.Drawing.Point(6, 599)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "รวม รายการ"
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(267, 133)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(85, 38)
        Me.CmdExcel.TabIndex = 120
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        '
        'cmdPrt
        '
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(176, 134)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(85, 41)
        Me.cmdPrt.TabIndex = 7
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        '
        'Cmd_Update
        '
        Me.Cmd_Update.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Update.Location = New System.Drawing.Point(573, 95)
        Me.Cmd_Update.Name = "Cmd_Update"
        Me.Cmd_Update.Size = New System.Drawing.Size(68, 25)
        Me.Cmd_Update.TabIndex = 107
        Me.Cmd_Update.Text = "Update All"
        Me.Cmd_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Update.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(292, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "ชม.ปกติ"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(11, 583)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "รวม รายการ"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgLookUpFact)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtSearchFact)
        Me.Panel2.Location = New System.Drawing.Point(1351, 242)
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
        Me.Label17.ForeColor = System.Drawing.Color.Snow
        Me.Label17.Location = New System.Drawing.Point(8, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(377, 22)
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
        'CmdTransfer
        '
        Me.CmdTransfer.ForeColor = System.Drawing.Color.Black
        Me.CmdTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdTransfer.Location = New System.Drawing.Point(639, 251)
        Me.CmdTransfer.Name = "CmdTransfer"
        Me.CmdTransfer.Size = New System.Drawing.Size(36, 36)
        Me.CmdTransfer.TabIndex = 7
        Me.CmdTransfer.Text = ">"
        Me.CmdTransfer.UseVisualStyleBackColor = True
        '
        'CmdReturn
        '
        Me.CmdReturn.ForeColor = System.Drawing.Color.Black
        Me.CmdReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdReturn.Location = New System.Drawing.Point(639, 306)
        Me.CmdReturn.Name = "CmdReturn"
        Me.CmdReturn.Size = New System.Drawing.Size(36, 32)
        Me.CmdReturn.TabIndex = 12
        Me.CmdReturn.Text = "<"
        Me.CmdReturn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Honeydew
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CmdCosCen)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.CbRelax)
        Me.GroupBox2.Controls.Add(Me.Cmd_Save)
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Controls.Add(Me.CmdExcel)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.cmdPrt)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.DTTime_Start)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.CmdExit)
        Me.GroupBox2.Controls.Add(Me.DTTime_End)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.txtIncentive)
        Me.GroupBox2.Controls.Add(Me.txtHoliday_Ot)
        Me.GroupBox2.Controls.Add(Me.txtNormal_Ot)
        Me.GroupBox2.Controls.Add(Me.TxtNormal_Hr)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Cmd_Update)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.CbDep_Id2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(681, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 627)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ที่รับโอน"
        '
        'CmdCosCen
        '
        Me.CmdCosCen.ForeColor = System.Drawing.Color.Black
        Me.CmdCosCen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCosCen.Location = New System.Drawing.Point(380, 50)
        Me.CmdCosCen.Name = "CmdCosCen"
        Me.CmdCosCen.Size = New System.Drawing.Size(96, 25)
        Me.CmdCosCen.TabIndex = 252
        Me.CmdCosCen.Text = "Update CosCen"
        Me.CmdCosCen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCosCen.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(241, 83)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(45, 13)
        Me.Label26.TabIndex = 251
        Me.Label26.Text = "พัก นาที"
        '
        'CbRelax
        '
        Me.CbRelax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbRelax.FormattingEnabled = True
        Me.CbRelax.Location = New System.Drawing.Point(244, 99)
        Me.CbRelax.Name = "CbRelax"
        Me.CbRelax.Size = New System.Drawing.Size(38, 21)
        Me.CbRelax.TabIndex = 250
        '
        'Cmd_Save
        '
        Me.Cmd_Save.ForeColor = System.Drawing.Color.Red
        Me.Cmd_Save.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g
        Me.Cmd_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Save.Location = New System.Drawing.Point(91, 137)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(75, 36)
        Me.Cmd_Save.TabIndex = 249
        Me.Cmd_Save.Text = "บันทึก"
        Me.Cmd_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(11, 177)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.Size = New System.Drawing.Size(640, 403)
        Me.DataGridView2.TabIndex = 128
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(504, 583)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 127
        Me.Label24.Text = "รวม Incentive"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(369, 583)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 13)
        Me.Label23.TabIndex = 126
        Me.Label23.Text = "รวม Ot นักขัตถ์"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(257, 583)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 125
        Me.Label22.Text = "รวม OT ปกติ"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(144, 583)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 124
        Me.Label21.Text = "รวม ชม.ปกติ"
        '
        'DTTime_Start
        '
        Me.DTTime_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock
        Me.DTTime_Start.CustomFormat = "HH:mm"
        Me.DTTime_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTTime_Start.Location = New System.Drawing.Point(110, 99)
        Me.DTTime_Start.MaxDate = New Date(4998, 12, 31, 0, 0, 0, 0)
        Me.DTTime_Start.Name = "DTTime_Start"
        Me.DTTime_Start.ShowUpDown = True
        Me.DTTime_Start.Size = New System.Drawing.Size(60, 20)
        Me.DTTime_Start.TabIndex = 120
        Me.DTTime_Start.Value = New Date(2009, 2, 18, 7, 0, 0, 0)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(123, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "จากเวลา"
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(520, 22)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(85, 39)
        Me.CmdExit.TabIndex = 16
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'DTTime_End
        '
        Me.DTTime_End.CustomFormat = "HH:mm"
        Me.DTTime_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTTime_End.Location = New System.Drawing.Point(176, 99)
        Me.DTTime_End.Name = "DTTime_End"
        Me.DTTime_End.ShowUpDown = True
        Me.DTTime_End.Size = New System.Drawing.Size(62, 20)
        Me.DTTime_End.TabIndex = 121
        Me.DTTime_End.Value = New Date(2009, 2, 18, 17, 0, 0, 0)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(187, 83)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 13)
        Me.Label20.TabIndex = 123
        Me.Label20.Text = "ถึงเวลา"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(6, 154)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox2.TabIndex = 119
        Me.CheckBox2.Text = "Select All"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtIncentive
        '
        Me.txtIncentive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtIncentive.Location = New System.Drawing.Point(461, 99)
        Me.txtIncentive.MaxLength = 20
        Me.txtIncentive.Name = "txtIncentive"
        Me.txtIncentive.Size = New System.Drawing.Size(46, 20)
        Me.txtIncentive.TabIndex = 11
        Me.txtIncentive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHoliday_Ot
        '
        Me.txtHoliday_Ot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtHoliday_Ot.Location = New System.Drawing.Point(395, 99)
        Me.txtHoliday_Ot.MaxLength = 20
        Me.txtHoliday_Ot.Name = "txtHoliday_Ot"
        Me.txtHoliday_Ot.Size = New System.Drawing.Size(53, 20)
        Me.txtHoliday_Ot.TabIndex = 10
        Me.txtHoliday_Ot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNormal_Ot
        '
        Me.txtNormal_Ot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtNormal_Ot.Location = New System.Drawing.Point(346, 100)
        Me.txtNormal_Ot.MaxLength = 20
        Me.txtNormal_Ot.Name = "txtNormal_Ot"
        Me.txtNormal_Ot.Size = New System.Drawing.Size(43, 20)
        Me.txtNormal_Ot.TabIndex = 9
        Me.txtNormal_Ot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNormal_Hr
        '
        Me.TxtNormal_Hr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtNormal_Hr.Location = New System.Drawing.Point(298, 100)
        Me.TxtNormal_Hr.MaxLength = 20
        Me.TxtNormal_Hr.Name = "TxtNormal_Hr"
        Me.TxtNormal_Hr.Size = New System.Drawing.Size(42, 20)
        Me.TxtNormal_Hr.TabIndex = 8
        Me.TxtNormal_Hr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(458, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Incentive"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(392, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "โอทีนักขัตถ์"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(343, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "โอทีปกติ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(21, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "3.ป้อน จำนวน"
        '
        'CbDep_Id2
        '
        Me.CbDep_Id2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbDep_Id2.FormattingEnabled = True
        Me.CbDep_Id2.Location = New System.Drawing.Point(106, 52)
        Me.CbDep_Id2.Name = "CbDep_Id2"
        Me.CbDep_Id2.Size = New System.Drawing.Size(267, 21)
        Me.CbDep_Id2.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(63, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "*แผนก"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(8, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 16)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "2.เลือกแผนก CostCenter ที่รับโอน"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(627, 223)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 16)
        Me.Label25.TabIndex = 113
        Me.Label25.Text = "5.Move"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(513, 100)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox3.TabIndex = 253
        Me.CheckBox3.Text = "2 แรง"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'FrmTransFer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 661)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CmdReturn)
        Me.Controls.Add(Me.CmdTransfer)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmTransFer"
        Me.Text = "ระบบการโอนคน/ค่าแรง"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
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
    Friend WithEvents CmdTransfer As System.Windows.Forms.Button
    Friend WithEvents CmdReturn As System.Windows.Forms.Button
    Friend WithEvents CbDep_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbDep_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNormal_Ot As System.Windows.Forms.TextBox
    Friend WithEvents TxtNormal_Hr As System.Windows.Forms.TextBox
    Friend WithEvents txtIncentive As System.Windows.Forms.TextBox
    Friend WithEvents txtHoliday_Ot As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTrfNo As System.Windows.Forms.TextBox
    Friend WithEvents CbHead_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents DTTime_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DTTime_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbTrfNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents CbRelax As System.Windows.Forms.ComboBox
    Friend WithEvents CmdFind As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CbShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CmdCosCen As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
End Class
