<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogFiles
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgLookUpFact = New System.Windows.Forms.DataGrid
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSearchFact = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CbFcode = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.CmdExit = New System.Windows.Forms.Button
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmdAdd = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(893, 17)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(212, 150)
        Me.CrystalReportViewer1.TabIndex = 60
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 70)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(879, 544)
        Me.DataGridView1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.dgLookUpFact)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtSearchFact)
        Me.Panel2.Location = New System.Drawing.Point(893, 193)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 266)
        Me.Panel2.TabIndex = 166
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
        Me.Label10.Text = "ดับเบิลคลิก เพื่อเลือกข้อมูล"
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
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(788, 633)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 196
        Me.Label15.Text = "รวม X,XXX รายการ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(143, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "ถึง"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "วันที่"
        '
        'CbFcode
        '
        Me.CbFcode.FormattingEnabled = True
        Me.CbFcode.Location = New System.Drawing.Point(44, 42)
        Me.CbFcode.Name = "CbFcode"
        Me.CbFcode.Size = New System.Drawing.Size(98, 21)
        Me.CbFcode.TabIndex = 232
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "User"
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(649, 16)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(75, 38)
        Me.CmdExcel.TabIndex = 235
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        Me.CmdExcel.Visible = False
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(811, 16)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 38)
        Me.CmdExit.TabIndex = 237
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrt
        '
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(730, 16)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(75, 38)
        Me.cmdPrt.TabIndex = 236
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        Me.cmdPrt.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(168, 17)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker2.TabIndex = 239
        Me.DateTimePicker2.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(44, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker1.TabIndex = 238
        Me.DateTimePicker1.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(164, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 24)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "User"
        '
        'CmdAdd
        '
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.Location = New System.Drawing.Point(558, 16)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(85, 41)
        Me.CmdAdd.TabIndex = 240
        Me.CmdAdd.Text = "Refrsh"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'FrmLogFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(934, 655)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CmdExcel)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.cmdPrt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbFcode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmLogFiles"
        Me.Text = "ตรวจสอบการใช้โปรแกรม เริ่ม 19/11/2014"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgLookUpFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgLookUpFact As System.Windows.Forms.DataGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFact As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbFcode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
End Class
