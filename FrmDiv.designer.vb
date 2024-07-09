<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiv
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdRefresh = New System.Windows.Forms.Button
        Me.CmdExcel = New System.Windows.Forms.Button
        Me.CmdDel = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.TxtDiv_Th = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDiv_En = New System.Windows.Forms.TextBox
        Me.cmdPrt = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDiv_Id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(491, 172)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 38)
        Me.CmdExit.TabIndex = 6
        Me.CmdExit.Text = "ออก"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(612, 12)
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
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 256)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(594, 413)
        Me.DataGridView1.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Honeydew
        Me.GroupBox1.Controls.Add(Me.CmdRefresh)
        Me.GroupBox1.Controls.Add(Me.CmdExcel)
        Me.GroupBox1.Controls.Add(Me.CmdDel)
        Me.GroupBox1.Controls.Add(Me.CmdSave)
        Me.GroupBox1.Controls.Add(Me.TxtDiv_Th)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmdExit)
        Me.GroupBox1.Controls.Add(Me.TxtDiv_En)
        Me.GroupBox1.Controls.Add(Me.cmdPrt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtDiv_Id)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 238)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ฝ่าย"
        '
        'CmdRefresh
        '
        Me.CmdRefresh.ForeColor = System.Drawing.Color.Red
        Me.CmdRefresh.Image = Global.Transfer.My.Resources.Resources.ic_cached_black_24dp
        Me.CmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdRefresh.Location = New System.Drawing.Point(167, 172)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(75, 38)
        Me.CmdRefresh.TabIndex = 5
        Me.CmdRefresh.Text = "เริ่มใหม่"
        Me.CmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRefresh.UseVisualStyleBackColor = True
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.Transfer.My.Resources.Resources.excel
        Me.CmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExcel.Location = New System.Drawing.Point(329, 172)
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.Size = New System.Drawing.Size(75, 38)
        Me.CmdExcel.TabIndex = 7
        Me.CmdExcel.Text = "Excel"
        Me.CmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExcel.UseVisualStyleBackColor = True
        '
        'CmdDel
        '
        Me.CmdDel.ForeColor = System.Drawing.Color.Red
        Me.CmdDel.Image = Global.Transfer.My.Resources.Resources._erase
        Me.CmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdDel.Location = New System.Drawing.Point(24, 172)
        Me.CmdDel.Name = "CmdDel"
        Me.CmdDel.Size = New System.Drawing.Size(75, 38)
        Me.CmdDel.TabIndex = 19
        Me.CmdDel.Text = "ลบ"
        Me.CmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdDel.UseVisualStyleBackColor = True
        Me.CmdDel.Visible = False
        '
        'CmdSave
        '
        Me.CmdSave.ForeColor = System.Drawing.Color.Red
        Me.CmdSave.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g1
        Me.CmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.Location = New System.Drawing.Point(248, 172)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 38)
        Me.CmdSave.TabIndex = 4
        Me.CmdSave.Text = "บันทึก"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'TxtDiv_Th
        '
        Me.TxtDiv_Th.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtDiv_Th.Location = New System.Drawing.Point(174, 77)
        Me.TxtDiv_Th.MaxLength = 100
        Me.TxtDiv_Th.Name = "TxtDiv_Th"
        Me.TxtDiv_Th.Size = New System.Drawing.Size(391, 29)
        Me.TxtDiv_Th.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 24)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "ชื่อฝ่าย(อังกฤษ)"
        '
        'TxtDiv_En
        '
        Me.TxtDiv_En.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtDiv_En.Location = New System.Drawing.Point(174, 112)
        Me.TxtDiv_En.MaxLength = 100
        Me.TxtDiv_En.Name = "TxtDiv_En"
        Me.TxtDiv_En.Size = New System.Drawing.Size(391, 29)
        Me.TxtDiv_En.TabIndex = 3
        '
        'cmdPrt
        '
        Me.cmdPrt.Image = Global.Transfer.My.Resources.Resources.printer1
        Me.cmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrt.Location = New System.Drawing.Point(410, 172)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.Size = New System.Drawing.Size(75, 38)
        Me.cmdPrt.TabIndex = 8
        Me.cmdPrt.Text = "พิมพ์"
        Me.cmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ชื่อฝ่าย(ไทย)"
        '
        'TxtDiv_Id
        '
        Me.TxtDiv_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtDiv_Id.Location = New System.Drawing.Point(174, 39)
        Me.TxtDiv_Id.MaxLength = 2
        Me.TxtDiv_Id.Name = "TxtDiv_Id"
        Me.TxtDiv_Id.Size = New System.Drawing.Size(79, 29)
        Me.TxtDiv_Id.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "รหัสฝ่าย"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 673)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Label4"
        '
        'FrmDiv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(610, 695)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmDiv"
        Me.Text = "ฝ่าย"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrt As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdDel As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents TxtDiv_Th As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDiv_En As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDiv_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdExcel As System.Windows.Forms.Button
    Friend WithEvents CmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
