<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLock
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.Transfer.My.Resources.Resources.door3
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.Location = New System.Drawing.Point(155, 76)
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
        Me.Label1.Location = New System.Drawing.Point(138, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(36, 119)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(258, 23)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'CmdPrt
        '
        Me.CmdPrt.Image = Global.Transfer.My.Resources.Resources.Save_Blue_32_h_g1
        Me.CmdPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrt.Location = New System.Drawing.Point(69, 76)
        Me.CmdPrt.Name = "CmdPrt"
        Me.CmdPrt.Size = New System.Drawing.Size(80, 37)
        Me.CmdPrt.TabIndex = 11
        Me.CmdPrt.Text = "Lock"
        Me.CmdPrt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Lock ก่อนวันที่"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(110, 33)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker1.TabIndex = 111
        Me.DateTimePicker1.Value = New Date(2009, 3, 23, 0, 0, 0, 0)
        '
        'FrmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 149)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CmdPrt)
        Me.Name = "FrmLock"
        Me.Text = " 5.Lock งวดวันที่"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdPrt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
