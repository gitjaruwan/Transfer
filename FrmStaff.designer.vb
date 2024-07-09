<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStaff
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
        Me.GroupBoxStaff = New System.Windows.Forms.GroupBox
        Me.CbWorkStatus = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.CbShift = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CbField_Id = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.CbDiv_Id = New System.Windows.Forms.ComboBox
        Me.CbDep_Id = New System.Windows.Forms.ComboBox
        Me.CbUnit_Id = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CbSup_Id = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CbHead_Id = New System.Windows.Forms.ComboBox
        Me.CmdExit = New System.Windows.Forms.Button
        Me.CbNation = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CmdRefresh = New System.Windows.Forms.Button
        Me.TxtSal = New System.Windows.Forms.TextBox
        Me.CbEmp_Th = New System.Windows.Forms.ComboBox
        Me.CbPos_Id = New System.Windows.Forms.ComboBox
        Me.CbType_Id = New System.Windows.Forms.ComboBox
        Me.CbTitle_En = New System.Windows.Forms.ComboBox
        Me.CbTitle_Th = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtLName_En = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtFName_En = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtLName_Th = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdDel = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtFName_Th = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtStid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.CbNation2 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.CbHead_Id2 = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.CbDep_Id2 = New System.Windows.Forms.ComboBox
        Me.CbSup_Id2 = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CmdImport = New System.Windows.Forms.Button
        Me.CbShift2 = New System.Windows.Forms.ComboBox
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.CbUnit_Id2 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.CbDiv_Id2 = New System.Windows.Forms.ComboBox
        Me.TxtPos_All = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxStaff.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(367, 571)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(212, 150)
        Me.CrystalReportViewer1.TabIndex = 23
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 100)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(765, 399)
        Me.DataGridView1.TabIndex = 22
        '
        'GroupBoxStaff
        '
        Me.GroupBoxStaff.BackColor = System.Drawing.Color.Honeydew
        Me.GroupBoxStaff.Controls.Add(Me.TxtPos_All)
        Me.GroupBoxStaff.Controls.Add(Me.Label31)
        Me.GroupBoxStaff.Controls.Add(Me.CbWorkStatus)
        Me.GroupBoxStaff.Controls.Add(Me.Label30)
        Me.GroupBoxStaff.Controls.Add(Me.CbShift)
        Me.GroupBoxStaff.Controls.Add(Me.Label25)
        Me.GroupBoxStaff.Controls.Add(Me.GroupBox2)
        Me.GroupBoxStaff.Controls.Add(Me.GroupBox1)
        Me.GroupBoxStaff.Controls.Add(Me.CmdExit)
        Me.GroupBoxStaff.Controls.Add(Me.CbNation)
        Me.GroupBoxStaff.Controls.Add(Me.Label11)
        Me.GroupBoxStaff.Controls.Add(Me.CmdRefresh)
        Me.GroupBoxStaff.Controls.Add(Me.TxtSal)
        Me.GroupBoxStaff.Controls.Add(Me.CbEmp_Th)
        Me.GroupBoxStaff.Controls.Add(Me.CbPos_Id)
        Me.GroupBoxStaff.Controls.Add(Me.CbType_Id)
        Me.GroupBoxStaff.Controls.Add(Me.CbTitle_En)
        Me.GroupBoxStaff.Controls.Add(Me.CbTitle_Th)
        Me.GroupBoxStaff.Controls.Add(Me.Label27)
        Me.GroupBoxStaff.Controls.Add(Me.Label28)
        Me.GroupBoxStaff.Controls.Add(Me.Label24)
        Me.GroupBoxStaff.Controls.Add(Me.Label21)
        Me.GroupBoxStaff.Controls.Add(Me.TxtLName_En)
        Me.GroupBoxStaff.Controls.Add(Me.Label5)
        Me.GroupBoxStaff.Controls.Add(Me.Label6)
        Me.GroupBoxStaff.Controls.Add(Me.TxtFName_En)
        Me.GroupBoxStaff.Controls.Add(Me.Label7)
        Me.GroupBoxStaff.Controls.Add(Me.TxtLName_Th)
        Me.GroupBoxStaff.Controls.Add(Me.Label4)
        Me.GroupBoxStaff.Controls.Add(Me.CmdDel)
        Me.GroupBoxStaff.Controls.Add(Me.CmdSave)
        Me.GroupBoxStaff.Controls.Add(Me.Label3)
        Me.GroupBoxStaff.Controls.Add(Me.TxtFName_Th)
        Me.GroupBoxStaff.Controls.Add(Me.Label2)
        Me.GroupBoxStaff.Controls.Add(Me.TxtStid)
        Me.GroupBoxStaff.Controls.Add(Me.Label1)
        Me.GroupBoxStaff.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxStaff.Name = "GroupBoxStaff"
        Me.GroupBoxStaff.Size = New System.Drawing.Size(469, 553)
        Me.GroupBoxStaff.TabIndex = 0
        Me.GroupBoxStaff.TabStop = False
        Me.GroupBoxStaff.Text = "เพิ่ม แก้ไข ลบ ประวัติพนักงาน"
        '
        'CbWorkStatus
        '
        Me.CbWorkStatus.FormattingEnabled = True
        Me.CbWorkStatus.Location = New System.Drawing.Point(322, 471)
        Me.CbWorkStatus.Name = "CbWorkStatus"
        Me.CbWorkStatus.Size = New System.Drawing.Size(135, 21)
        Me.CbWorkStatus.TabIndex = 96
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label30.Location = New System.Drawing.Point(274, 473)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(39, 16)
        Me.Label30.TabIndex = 97
        Me.Label30.Text = "สถานะ"
        '
        'CbShift
        '
        Me.CbShift.FormattingEnabled = True
        Me.CbShift.Location = New System.Drawing.Point(322, 440)
        Me.CbShift.Name = "CbShift"
        Me.CbShift.Size = New System.Drawing.Size(135, 21)
        Me.CbShift.TabIndex = 95
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label25.Location = New System.Drawing.Point(298, 442)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(20, 16)
        Me.Label25.TabIndex = 94
        Me.Label25.Text = "กะ"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LemonChiffon
        Me.GroupBox2.Controls.Add(Me.CbField_Id)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.CbDiv_Id)
        Me.GroupBox2.Controls.Add(Me.CbDep_Id)
        Me.GroupBox2.Controls.Add(Me.CbUnit_Id)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 277)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(445, 128)
        Me.GroupBox2.TabIndex = 93
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ต้นสังกัด"
        '
        'CbField_Id
        '
        Me.CbField_Id.FormattingEnabled = True
        Me.CbField_Id.Location = New System.Drawing.Point(88, 19)
        Me.CbField_Id.Name = "CbField_Id"
        Me.CbField_Id.Size = New System.Drawing.Size(313, 21)
        Me.CbField_Id.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 16)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "สายงาน"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(48, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "ฝ่าย"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(40, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 16)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "แผนก"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 16)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "หน่วยงาน"
        '
        'CbDiv_Id
        '
        Me.CbDiv_Id.FormattingEnabled = True
        Me.CbDiv_Id.Location = New System.Drawing.Point(88, 46)
        Me.CbDiv_Id.Name = "CbDiv_Id"
        Me.CbDiv_Id.Size = New System.Drawing.Size(313, 21)
        Me.CbDiv_Id.TabIndex = 12
        '
        'CbDep_Id
        '
        Me.CbDep_Id.FormattingEnabled = True
        Me.CbDep_Id.Location = New System.Drawing.Point(88, 73)
        Me.CbDep_Id.Name = "CbDep_Id"
        Me.CbDep_Id.Size = New System.Drawing.Size(313, 21)
        Me.CbDep_Id.TabIndex = 13
        '
        'CbUnit_Id
        '
        Me.CbUnit_Id.FormattingEnabled = True
        Me.CbUnit_Id.Location = New System.Drawing.Point(87, 100)
        Me.CbUnit_Id.Name = "CbUnit_Id"
        Me.CbUnit_Id.Size = New System.Drawing.Size(314, 21)
        Me.CbUnit_Id.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox1.Controls.Add(Me.CbSup_Id)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.CbHead_Id)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 87)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ผู้บังคับบัญชา"
        '
        'CbSup_Id
        '
        Me.CbSup_Id.FormattingEnabled = True
        Me.CbSup_Id.Location = New System.Drawing.Point(88, 26)
        Me.CbSup_Id.Name = "CbSup_Id"
        Me.CbSup_Id.Size = New System.Drawing.Size(313, 21)
        Me.CbSup_Id.TabIndex = 10
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label29.Location = New System.Drawing.Point(1, 27)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 16)
        Me.Label29.TabIndex = 76
        Me.Label29.Text = "Supervisor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 16)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "หัวหน้าหน่วย"
        '
        'CbHead_Id
        '
        Me.CbHead_Id.FormattingEnabled = True
        Me.CbHead_Id.Location = New System.Drawing.Point(88, 53)
        Me.CbHead_Id.Name = "CbHead_Id"
        Me.CbHead_Id.Size = New System.Drawing.Size(313, 21)
        Me.CbHead_Id.TabIndex = 9
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(381, 504)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 38)
        Me.CmdExit.TabIndex = 21
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CbNation
        '
        Me.CbNation.FormattingEnabled = True
        Me.CbNation.Location = New System.Drawing.Point(368, 413)
        Me.CbNation.Name = "CbNation"
        Me.CbNation.Size = New System.Drawing.Size(89, 21)
        Me.CbNation.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(319, 414)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 16)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "สัญชาติ"
        '
        'CmdRefresh
        '
        Me.CmdRefresh.ForeColor = System.Drawing.Color.Red
        Me.CmdRefresh.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdRefresh.Location = New System.Drawing.Point(136, 504)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(75, 38)
        Me.CmdRefresh.TabIndex = 22
        Me.CmdRefresh.Text = "เริ่มใหม่"
        Me.CmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'TxtSal
        '
        Me.TxtSal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtSal.Location = New System.Drawing.Point(106, 468)
        Me.TxtSal.MaxLength = 100
        Me.TxtSal.Name = "TxtSal"
        Me.TxtSal.Size = New System.Drawing.Size(78, 24)
        Me.TxtSal.TabIndex = 18
        Me.TxtSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CbEmp_Th
        '
        Me.CbEmp_Th.FormattingEnabled = True
        Me.CbEmp_Th.Location = New System.Drawing.Point(106, 441)
        Me.CbEmp_Th.Name = "CbEmp_Th"
        Me.CbEmp_Th.Size = New System.Drawing.Size(78, 21)
        Me.CbEmp_Th.TabIndex = 17
        '
        'CbPos_Id
        '
        Me.CbPos_Id.FormattingEnabled = True
        Me.CbPos_Id.Location = New System.Drawing.Point(106, 154)
        Me.CbPos_Id.Name = "CbPos_Id"
        Me.CbPos_Id.Size = New System.Drawing.Size(178, 21)
        Me.CbPos_Id.TabIndex = 8
        '
        'CbType_Id
        '
        Me.CbType_Id.FormattingEnabled = True
        Me.CbType_Id.Location = New System.Drawing.Point(106, 414)
        Me.CbType_Id.Name = "CbType_Id"
        Me.CbType_Id.Size = New System.Drawing.Size(207, 21)
        Me.CbType_Id.TabIndex = 15
        '
        'CbTitle_En
        '
        Me.CbTitle_En.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbTitle_En.FormattingEnabled = True
        Me.CbTitle_En.Location = New System.Drawing.Point(21, 124)
        Me.CbTitle_En.Name = "CbTitle_En"
        Me.CbTitle_En.Size = New System.Drawing.Size(70, 24)
        Me.CbTitle_En.TabIndex = 5
        '
        'CbTitle_Th
        '
        Me.CbTitle_Th.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CbTitle_Th.FormattingEnabled = True
        Me.CbTitle_Th.Location = New System.Drawing.Point(21, 78)
        Me.CbTitle_Th.Name = "CbTitle_Th"
        Me.CbTitle_Th.Size = New System.Drawing.Size(70, 24)
        Me.CbTitle_Th.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label27.Location = New System.Drawing.Point(54, 473)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 16)
        Me.Label27.TabIndex = 70
        Me.Label27.Text = "ค่าแรง"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label28.Location = New System.Drawing.Point(17, 442)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(75, 16)
        Me.Label28.TabIndex = 69
        Me.Label28.Text = "ประเภทค่าแรง"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(46, 154)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 16)
        Me.Label24.TabIndex = 64
        Me.Label24.Text = "ตำแหน่ง"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 415)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 16)
        Me.Label21.TabIndex = 58
        Me.Label21.Text = "ประเภทพนักงาน"
        '
        'TxtLName_En
        '
        Me.TxtLName_En.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtLName_En.Location = New System.Drawing.Point(289, 124)
        Me.TxtLName_En.MaxLength = 100
        Me.TxtLName_En.Name = "TxtLName_En"
        Me.TxtLName_En.Size = New System.Drawing.Size(174, 24)
        Me.TxtLName_En.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(352, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Lastname"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 16)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Title"
        '
        'TxtFName_En
        '
        Me.TxtFName_En.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtFName_En.Location = New System.Drawing.Point(106, 124)
        Me.TxtFName_En.MaxLength = 100
        Me.TxtFName_En.Name = "TxtFName_En"
        Me.TxtFName_En.Size = New System.Drawing.Size(178, 24)
        Me.TxtFName_En.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(173, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 16)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Name"
        '
        'TxtLName_Th
        '
        Me.TxtLName_Th.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtLName_Th.Location = New System.Drawing.Point(289, 78)
        Me.TxtLName_Th.MaxLength = 100
        Me.TxtLName_Th.Name = "TxtLName_Th"
        Me.TxtLName_Th.Size = New System.Drawing.Size(174, 24)
        Me.TxtLName_Th.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(359, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "นามสกุล"
        '
        'CmdDel
        '
        Me.CmdDel.ForeColor = System.Drawing.Color.Red
        Me.CmdDel.Image = Global.Transfer.My.Resources.Resources._erase
        Me.CmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdDel.Location = New System.Drawing.Point(300, 504)
        Me.CmdDel.Name = "CmdDel"
        Me.CmdDel.Size = New System.Drawing.Size(75, 38)
        Me.CmdDel.TabIndex = 20
        Me.CmdDel.Text = "ลบ"
        Me.CmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdDel.UseVisualStyleBackColor = True
        '
        'CmdSave
        '
        Me.CmdSave.ForeColor = System.Drawing.Color.Red
        Me.CmdSave.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g1
        Me.CmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.Location = New System.Drawing.Point(219, 504)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 38)
        Me.CmdSave.TabIndex = 19
        Me.CmdSave.Text = "บันทึก"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "คำนำหน้าชื่อ"
        '
        'TxtFName_Th
        '
        Me.TxtFName_Th.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtFName_Th.Location = New System.Drawing.Point(106, 78)
        Me.TxtFName_Th.MaxLength = 100
        Me.TxtFName_Th.Name = "TxtFName_Th"
        Me.TxtFName_Th.Size = New System.Drawing.Size(178, 24)
        Me.TxtFName_Th.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(182, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ชื่อ"
        '
        'TxtStid
        '
        Me.TxtStid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtStid.Location = New System.Drawing.Point(21, 35)
        Me.TxtStid.MaxLength = 8
        Me.TxtStid.Name = "TxtStid"
        Me.TxtStid.Size = New System.Drawing.Size(110, 24)
        Me.TxtStid.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "รหัสพนักงาน"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 512)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Label10"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(229, 512)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Label13"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(413, 512)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Label14"
        '
        'CbNation2
        '
        Me.CbNation2.FormattingEnabled = True
        Me.CbNation2.Location = New System.Drawing.Point(103, 16)
        Me.CbNation2.Name = "CbNation2"
        Me.CbNation2.Size = New System.Drawing.Size(102, 21)
        Me.CbNation2.TabIndex = 92
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(22, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "กรองสัญชาติ"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.Location = New System.Drawing.Point(346, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 16)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "กรองหัวหน้าหน่วย"
        '
        'CbHead_Id2
        '
        Me.CbHead_Id2.FormattingEnabled = True
        Me.CbHead_Id2.Location = New System.Drawing.Point(445, 39)
        Me.CbHead_Id2.Name = "CbHead_Id2"
        Me.CbHead_Id2.Size = New System.Drawing.Size(256, 21)
        Me.CbHead_Id2.TabIndex = 94
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(31, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 16)
        Me.Label19.TabIndex = 97
        Me.Label19.Text = "กรองแผนก"
        '
        'CbDep_Id2
        '
        Me.CbDep_Id2.FormattingEnabled = True
        Me.CbDep_Id2.Location = New System.Drawing.Point(103, 38)
        Me.CbDep_Id2.Name = "CbDep_Id2"
        Me.CbDep_Id2.Size = New System.Drawing.Size(235, 21)
        Me.CbDep_Id2.TabIndex = 96
        '
        'CbSup_Id2
        '
        Me.CbSup_Id2.FormattingEnabled = True
        Me.CbSup_Id2.Location = New System.Drawing.Point(445, 16)
        Me.CbSup_Id2.Name = "CbSup_Id2"
        Me.CbSup_Id2.Size = New System.Drawing.Size(256, 21)
        Me.CbSup_Id2.TabIndex = 98
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label20.Location = New System.Drawing.Point(360, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 16)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "Supervisor"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdImport)
        Me.GroupBox3.Controls.Add(Me.CbShift2)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.CmdExcel)
        Me.GroupBox3.Controls.Add(Me.cmdPrt)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.CbUnit_Id2)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.CbDiv_Id2)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.CbHead_Id2)
        Me.GroupBox3.Controls.Add(Me.CbSup_Id2)
        Me.GroupBox3.Controls.Add(Me.CbNation2)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.CbDep_Id2)
        Me.GroupBox3.Location = New System.Drawing.Point(506, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 548)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Staff List"
        '
        'CmdImport
        '
        Me.CmdImport.ForeColor = System.Drawing.Color.Red
        Me.CmdImport.Image = Global.Transfer.My.Resources.Resources.if_Left_132177
        Me.CmdImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdImport.Location = New System.Drawing.Point(519, 505)
        Me.CmdImport.Name = "CmdImport"
        Me.CmdImport.Size = New System.Drawing.Size(75, 38)
        Me.CmdImport.TabIndex = 106
        Me.CmdImport.Text = "Import"
        Me.CmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImport.UseVisualStyleBackColor = True
        Me.CmdImport.Visible = False
        '
        'CbShift2
        '
        Me.CbShift2.FormattingEnabled = True
        Me.CbShift2.Location = New System.Drawing.Point(230, 16)
        Me.CbShift2.Name = "CbShift2"
        Me.CbShift2.Size = New System.Drawing.Size(108, 21)
        Me.CbShift2.TabIndex = 105
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(600, 504)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(75, 38)
        Me.CmdExcel.TabIndex = 23
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        '
        'cmdPrt
        '
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(682, 504)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(75, 38)
        Me.cmdPrt.TabIndex = 24
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label26.Location = New System.Drawing.Point(206, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(20, 16)
        Me.Label26.TabIndex = 104
        Me.Label26.Text = "กะ"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label23.Location = New System.Drawing.Point(362, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 16)
        Me.Label23.TabIndex = 103
        Me.Label23.Text = "กรองหน่วยงาน"
        '
        'CbUnit_Id2
        '
        Me.CbUnit_Id2.FormattingEnabled = True
        Me.CbUnit_Id2.Location = New System.Drawing.Point(445, 65)
        Me.CbUnit_Id2.Name = "CbUnit_Id2"
        Me.CbUnit_Id2.Size = New System.Drawing.Size(256, 21)
        Me.CbUnit_Id2.TabIndex = 102
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label22.Location = New System.Drawing.Point(39, 66)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 16)
        Me.Label22.TabIndex = 101
        Me.Label22.Text = "กรองฝ่าย"
        '
        'CbDiv_Id2
        '
        Me.CbDiv_Id2.FormattingEnabled = True
        Me.CbDiv_Id2.Location = New System.Drawing.Point(103, 65)
        Me.CbDiv_Id2.Name = "CbDiv_Id2"
        Me.CbDiv_Id2.Size = New System.Drawing.Size(235, 21)
        Me.CbDiv_Id2.TabIndex = 100
        '
        'TxtPos_All
        '
        Me.TxtPos_All.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtPos_All.Location = New System.Drawing.Point(203, 468)
        Me.TxtPos_All.MaxLength = 100
        Me.TxtPos_All.Name = "TxtPos_All"
        Me.TxtPos_All.Size = New System.Drawing.Size(65, 24)
        Me.TxtPos_All.TabIndex = 98
        Me.TxtPos_All.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label31.Location = New System.Drawing.Point(200, 449)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(59, 16)
        Me.Label31.TabIndex = 99
        Me.Label31.Text = "ค่าตำแหน่ง"
        '
        'FrmStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1289, 573)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBoxStaff)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrmStaff"
        Me.Text = "ประวัติพนักงาน"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxStaff.ResumeLayout(False)
        Me.GroupBoxStaff.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBoxStaff As System.Windows.Forms.GroupBox
    Friend WithEvents CmdDel As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFName_Th As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents TxtLName_Th As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtLName_En As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFName_En As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CbTitle_Th As System.Windows.Forms.ComboBox
    Friend WithEvents CbEmp_Th As System.Windows.Forms.ComboBox
    Friend WithEvents CbPos_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbType_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbUnit_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbDep_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbDiv_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbField_Id As System.Windows.Forms.ComboBox
    Friend WithEvents CbTitle_En As System.Windows.Forms.ComboBox
    Friend WithEvents CbSup_Id As System.Windows.Forms.ComboBox
    Friend WithEvents TxtSal As System.Windows.Forms.TextBox
    Friend WithEvents CbHead_Id As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CbNation As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CbNation2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CbHead_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CbDep_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents CbSup_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CbUnit_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbDiv_Id2 As System.Windows.Forms.ComboBox
    Friend WithEvents CbShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CbShift2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents CbWorkStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CmdImport As System.Windows.Forms.Button
    Friend WithEvents TxtPos_All As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
End Class
