Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmUser
    Dim IsFindUser As Boolean = False
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim MFact As String
    Dim nCurRecUser As CurrencyManager
    Private Sub FrmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = SqlConn()
            .Open()
        End With

        Dim sqlDoc As String
        sqlDoc = "SELECT * FROM TblPassword"
        da = New SqlDataAdapter(sqlDoc, Conn)
        da.Fill(ds, "User1")

        cbFSub_Level.Items.Add("1")
        cbFSub_Level.Items.Add("2")
        cbFSub_Level.Items.Add("3")
        cbFSub_Level.Text = "3"
        SelectRightMean()

        For Each c In "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
            CbShud.Items.Add(c)
        Next

        txtFPassword.UseSystemPasswordChar = True
        txtFRePass.UseSystemPasswordChar = True

        CheckBox1.Text = FrmMain.ต้นสังกัดToolStripMenuItem.Text
        CheckBox2.Text = FrmMain.รายการคางชำระโอนToolStripMenuItem.Text
        CheckBox3.Text = FrmMain.รายงานอนๆToolStripMenuItem.Text
        CheckBox4.Text = FrmMain.SETUPToolStripMenuItem.Text
        CheckBox5.Text = FrmMain.เครองมอToolStripMenuItem.Text
        CheckBox6.Text = FrmMain.รายการตราคาวตถดบToolStripMenuItem.Text

        If MFactory = "OKF" Then
            CheckBox7.Text = "ชุด A01-A99 แปรรูป สาย 1"
            CheckBox8.Text = "ชุด B01-B99 IQF แช่สาร สาย 2"
            CheckBox9.Text = "ชุด C01-C99 NOBASHI"
            CheckBox10.Text = "ชุด D01-D99 BREADED"
            CheckBox11.Text = "ชุด E01-E99 COOKED"
        End If

        If MFactory = "AS" Then
            CheckBox7.Text = "ชุด A01-A99 "
            CheckBox8.Text = "ชุด B01-B99 "
            CheckBox9.Text = "ชุด C01-C99 "
            CheckBox10.Text = "ชุด D01-D99 "
            CheckBox11.Text = "ชุด E01-E99 "
        End If


        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False

        Panel2.Width = 431
        Panel2.Left = 149
        Panel2.Top = 18
        txtFPassword.Enabled = False
        txtFRePass.Enabled = False
        txtFname.Enabled = False
        cbFSub_Level.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False

        txtFcode.Focus()
        Me.CenterToScreen()

    End Sub

    Private Sub SelectRightMean()
        Select Case cbFSub_Level.Text
            Case "1"
                Label5.Text = "ผู้จัดการระบบ Admin"
            Case "2"
                Label5.Text = "ผู้มีสิทธิป้อนข้อมูล"
            Case "3"
                Label5.Text = "ผู้มีสิทธิดูรายงาน"
        End Select
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub txtFcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFcode.Text = "" Then
                MessageBox.Show("UserName ไม่ควรว่าง...!!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFcode.Focus()
            Else
                If Len(txtFcode.Text) > 20 Then
                    MessageBox.Show("UserNamer เกิน 20 ตัวอักษร", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFcode.Focus()
                Else
                    txtFcode.Text = UCase(txtFcode.Text)
                    txtFPassword.Enabled = True
                    ChkAddEdit()
                End If
            End If
        End If
    End Sub

    Private Sub ChkAddEdit()
        Dim sqlChem As String
        sqlChem = "SELECT * FROM TblPassword WHERE Fcode = '" & txtFcode.Text & "' and Factory = '" & MFactory & "'"
        If IsFindUser = True Then
            ds.Tables("User").Clear()
        End If
        da = New SqlDataAdapter(sqlChem, Conn)
        da.Fill(ds, "User")
        If ds.Tables("User").Rows().Count <> 0 Then
            IsFindUser = True
            txtFcode.Text = CStr(ds.Tables("User").Rows(0).Item("FCode"))
            txtFPassword.Text = CStr(ds.Tables("User").Rows(0).Item("FPassword"))
            txtFRePass.Text = CStr(ds.Tables("User").Rows(0).Item("FPassword"))
            txtFname.Text = CStr(ds.Tables("User").Rows(0).Item("FName"))
            CheckBox1.Checked = ds.Tables("User").Rows(0).Item("PMenu1")
            CheckBox2.Checked = ds.Tables("User").Rows(0).Item("PMenu2")
            CheckBox3.Checked = ds.Tables("User").Rows(0).Item("PMenu3")
            CheckBox4.Checked = ds.Tables("User").Rows(0).Item("PMenu4")
            CheckBox5.Checked = ds.Tables("User").Rows(0).Item("PMenu5")
            CheckBox6.Checked = ds.Tables("User").Rows(0).Item("PMenu6")
            CheckBox7.Checked = ds.Tables("User").Rows(0).Item("ShudA")
            CheckBox8.Checked = ds.Tables("User").Rows(0).Item("ShudB")
            CheckBox9.Checked = ds.Tables("User").Rows(0).Item("ShudC")
            CheckBox10.Checked = ds.Tables("User").Rows(0).Item("ShudD")
            CheckBox11.Checked = ds.Tables("User").Rows(0).Item("ShudE")

            cbFSub_Level.Text = CStr(ds.Tables("User").Rows(0).Item("FSub_Level"))

            If ds.Tables("User").Rows(0).Item("Shud") Is System.DBNull.Value = False Then
                CbShud.Text = CStr(ds.Tables("User").Rows(0).Item("Shud"))
            End If

            SelectRightMean()
            If txtFcode.Text = "kamol" Then
                MessageBox.Show("ไม่สามารถกำหนดสิทธิ kamol ได้", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearPass()
            Else
                txtFRePass.Enabled = True
                txtFname.Enabled = True
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
                CbShud.Enabled = True
                txtFPassword.Enabled = True
                txtFPassword.Focus()
            End If
        Else
            IsFindUser = False
            txtFPassword.Text = ""
            txtFRePass.Text = ""
            txtFname.Text = ""
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False

            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            txtFPassword.Focus()
        End If
    End Sub

    Private Sub txtFPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFPassword.Text = "" Then
                MessageBox.Show("PassWord ไม่ควรว่าง...!!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFPassword.Focus()
            Else
                If Len(txtFPassword.Text) > 20 Then
                    MessageBox.Show("PassWord เกิน 20 ตัวอักษร", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFPassword.Focus()
                Else
                    txtFRePass.Enabled = True
                    txtFRePass.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtFPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPassword.KeyUp
        If e.KeyCode = Keys.Escape Then
            ClearPass()
        End If
    End Sub

    Private Sub txtFRePass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFRePass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFRePass.Text = "" Then
                MessageBox.Show("PassWord ไม่ควรว่าง...!!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFRePass.Focus()
            Else
                If Len(txtFRePass.Text) > 20 Then
                    MessageBox.Show("PassWord เกิน 20 ตัวอักษร", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFRePass.Focus()
                Else
                    If txtFPassword.Text <> txtFRePass.Text Then
                        MessageBox.Show("PassWord 2 ครั้งไม่เหมือนกัน", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFRePass.Focus()
                    Else
                        txtFname.Enabled = True
                        txtFname.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ClearPass()
        txtFPassword.Text = ""
        txtFRePass.Text = ""
        txtFname.Text = ""
        'cbFSub_Level.Text = ""
        txtFPassword.Enabled = False
        txtFRePass.Enabled = False
        txtFname.Enabled = False
        cbFSub_Level.Enabled = False
        CbShud.Enabled = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False

        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        txtFcode.Text = ""
        txtFcode.Focus()
    End Sub

    Private Sub txtFRePass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFRePass.KeyUp
        If e.KeyCode = Keys.Escape Then
            ClearPass()
        End If
    End Sub

    Private Sub txtFname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFname.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFname.Text = "" Then
                MessageBox.Show("ชื่อ-นามสกุล ไม่ควรว่าง...!!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFname.Focus()
            Else
                If Len(txtFname.Text) > 45 Then
                    MessageBox.Show("ชื่อ-นามสกุล เกิน 45 ตัวอักษร", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFname.Focus()
                Else
                    GroupBox2.Enabled = True
                    GroupBox3.Enabled = True
                    CheckBox1.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtFname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFname.KeyUp
        If e.KeyCode = Keys.Escape Then
            ClearPass()
        End If
    End Sub


    Private Sub cbFSub_Level_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbFSub_Level.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbFSub_Level.Text = "1" Or cbFSub_Level.Text = "2" Or _
            cbFSub_Level.Text = "3" Then
                cmdSave.Focus()
            Else
                MessageBox.Show("ป้อน 1-3 เท่านั้น...!!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbFSub_Level.Focus()
            End If
        End If
    End Sub

    Private Sub cbFSub_Level_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbFSub_Level.KeyUp
        If e.KeyCode = Keys.Escape Then
            ClearPass()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim sqlSave As String
        Dim SqlLog As String

        If txtFcode.Text = "" Or txtFPassword.Text = "" Or txtFRePass.Text = "" Or txtFname.Text = "" Or cbFSub_Level.Text = "" Then
            MessageBox.Show("ป้อนข้อมูลไม่ครบถ้วน", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFcode.Focus()
            Exit Sub
        End If

        If IsFindUser = True Then
            sqlSave = "UPDATE TblPassword SET "
            sqlSave &= "Factory = '" & MFactory & "',"
            sqlSave &= "FPassWord = '" & txtFPassword.Text & "',"
            sqlSave &= "FName = '" & txtFname.Text & "',"
            sqlSave &= "FSub_Level = '" & cbFSub_Level.Text & "',"
            sqlSave &= "Shud = '" & CbShud.Text & "',"
            sqlSave &= "PMenu1 = '" & CheckBox1.Checked & "',"
            sqlSave &= "PMenu2 = '" & CheckBox2.Checked & "',"
            sqlSave &= "PMenu3 = '" & CheckBox3.Checked & "',"
            sqlSave &= "PMenu4 = '" & CheckBox4.Checked & "',"
            sqlSave &= "PMenu5 = '" & CheckBox5.Checked & "',"
            sqlSave &= "PMenu6 = '" & CheckBox6.Checked & "',"
            sqlSave &= "ShudA = '" & CheckBox7.Checked & "',"
            sqlSave &= "ShudB = '" & CheckBox8.Checked & "',"
            sqlSave &= "ShudC = '" & CheckBox9.Checked & "',"
            sqlSave &= "ShudD = '" & CheckBox10.Checked & "',"
            sqlSave &= "ShudE = '" & CheckBox11.Checked
            sqlSave &= "' WHERE Fcode = '" & txtFcode.Text & "'"
            SqlLog = "Update Password " & txtFcode.Text & " " & txtFname.Text
        Else
            sqlSave = "INSERT INTO TblPassword (Factory,FCode,FPassword,FName,FSub_Level,Shud,PMenu1,PMenu2,PMenu3,PMenu4,PMenu5,PMenu6,ShudA,ShudB,ShudC,ShudD,ShudE)"
            sqlSave &= " VALUES('" & MFactory & "','" & txtFcode.Text & "','" & txtFPassword.Text & "','"
            sqlSave &= txtFname.Text & "','" & cbFSub_Level.Text & "','" & CbShud.Text & "','"
            sqlSave &= CheckBox1.Checked & "','" & CheckBox2.Checked & "','"
            sqlSave &= CheckBox3.Checked & "','" & CheckBox4.Checked & "','"
            sqlSave &= CheckBox5.Checked & "','" & CheckBox6.Checked & "','"
            sqlSave &= CheckBox7.Checked & "','" & CheckBox8.Checked & "','"
            sqlSave &= CheckBox9.Checked & "','" & CheckBox10.Checked & "','"
            sqlSave &= CheckBox11.Checked & "')"
            SqlLog = "Insert Password " & txtFcode.Text & " " & txtFname.Text
        End If
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = sqlSave
            .ExecuteNonQuery()
        End With

        SaveLog(SqlLog)
        ClearPass()
    End Sub

    Private Sub SaveLog(ByVal LogStr1 As String)
        Dim SqlStr As String
        SqlStr = "Insert  into TblLog(Factory,Log_Id,Log_Date,Log_Detail) Values('" & MFactory & "','" & MFCODE & "',convert(datetime,'" & _
            Now & "',103),'" & LogStr1 & "')"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
    End Sub

    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim sqlDel As String
        Dim SqlLog As String
        If txtFcode.Text = "" Or txtFPassword.Text = "" Or txtFRePass.Text = "" Or txtFname.Text = "" Or cbFSub_Level.Text = "" Then
            MessageBox.Show("ป้อนข้อมูลไม่ครบถ้วน", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFcode.Focus()
            Exit Sub
        End If
        If MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ ?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If IsFindUser = True Then
            sqlDel = "DELETE FROM TblPassword WHERE Fcode = '" & txtFcode.Text & "' And Factory = '" & MFactory & "'"
            With ComDel
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = sqlDel
                .ExecuteNonQuery()
            End With
            SqlLog = "Delete Password " & txtFcode.Text & " " & txtFname.Text
            SaveLog(SqlLog)
            MessageBox.Show("ลบรายการ " & txtFname.Text & " เรียบร้อยแล้ว..", "ลบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        ClearPass()
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        ds.Tables("User1").Clear()
        Dim sqlUser As String
        sqlUser = "SELECT * FROM TblPassword Where Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlUser, Conn)
        da.Fill(ds, "User1")
        nCurRecUser = CType(Me.BindingContext(ds, "User1"), CurrencyManager)
        If ds.Tables("User1").Rows.Count > 0 Then
            nCurRecUser.Position = 0
        End If
        txtSearchUser.Text = ""
        Panel2.Show()
        dgLookUpUser.DataSource = Nothing
        OrderGridUser()
        txtSearchUser.Focus()
    End Sub

    Private Sub OrderGridUser()
        Dim GrdTS As New DataGridTableStyle
        With GrdTS
            .MappingName = "User1"
            .AllowSorting = False
            .AlternatingBackColor = Color.AliceBlue
        End With

        Dim Col1 As New DataGridTextBoxColumn
        With Col1
            .HeaderText = "UserName"
            .MappingName = "Fcode"
            .ReadOnly = True
            .Width = 100
        End With
        GrdTS.GridColumnStyles.Add(Col1)

        Dim Col2 As New DataGridTextBoxColumn
        With Col2
            .HeaderText = "ชื่อ-นามสกุล"
            .MappingName = "Fname"
            .ReadOnly = True
            .Width = 150
        End With
        GrdTS.GridColumnStyles.Add(Col2)

        'Dim Col3 As New DataGridTextBoxColumn
        'With Col3
        '.HeaderText = "ระดับสิทธิ"
        '.MappingName = "FSub_Level"
        '.ReadOnly = True
        '.Width = 50
        'End With
        'GrdTS.GridColumnStyles.Add(Col3)


        With dgLookUpUser
            .TableStyles.Clear()
            .CaptionText = "User Code"
            .TableStyles.Add(GrdTS)
            .ReadOnly = True
            .FlatMode = True
            .DataSource = ds.Tables("User1")
            .AllowSorting = False
            .AllowNavigation = True
        End With
    End Sub


    Private Sub cbFSub_Level_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFSub_Level.TextChanged
        SelectRightMean()
    End Sub

    Private Sub CheckBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox2.Focus()
        End If
    End Sub

    Private Sub CheckBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox3.Focus()
        End If
    End Sub

    Private Sub CheckBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox4.Focus()
        End If
    End Sub

    Private Sub CheckBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox5.Focus()
        End If
    End Sub

    Private Sub CheckBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox6.Focus()
        End If
    End Sub

    Private Sub CheckBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdSave.Focus()
        End If
    End Sub

    Private Sub dgLookUpUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLookUpUser.DoubleClick
        txtFcode.Text = CStr(ds.Tables("User1").Rows(dgLookUpUser.CurrentRowIndex).Item("FCode"))
        Panel2.Hide()
        ChkAddEdit()
    End Sub

    Private Sub dgLookUpUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgLookUpUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFcode.Text = CStr(ds.Tables("User1").Rows(dgLookUpUser.CurrentRowIndex).Item("FCode"))
            Panel2.Hide()
            ChkAddEdit()
        End If
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Panel2.Hide()
    End Sub

    Private Sub txtSearchUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchUser.KeyDown
        If e.KeyCode = Keys.Escape Then
            Panel2.Hide()
            txtFcode.Focus()
        Else
            If e.KeyCode = Keys.Enter Then
                txtFcode.Text = CStr(ds.Tables("User1").Rows(dgLookUpUser.CurrentRowIndex).Item("FCode"))
                Panel2.Hide()
                ChkAddEdit()
            End If
        End If
    End Sub

    Private Sub txtSearchUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchUser.KeyUp
        Dim i As Integer = 0
        Dim lFound As Boolean = False
        For i = 0 To ds.Tables("User1").Rows.Count - 1
            If UCase(txtSearchUser.Text) = UCase(Mid(CStr(ds.Tables("User1").Rows(i).Item(0)), 1, Len(Trim(txtSearchUser.Text)))) Then
                nCurRecUser.Position = i
                dgLookUpUser.CurrentRowIndex = i
                lFound = True
                Exit For
            End If
            nCurRecUser.Position += 1
        Next

        If lFound = False Then
            For i = 0 To ds.Tables("User1").Rows.Count - 1
                Try
                    If UCase(txtSearchUser.Text) = UCase(Mid(CStr(ds.Tables("User1").Rows(i).Item(1)), 1, Len(Trim(txtSearchUser.Text)))) Then
                        nCurRecUser.Position = i
                        dgLookUpUser.CurrentRowIndex = i
                        lFound = True
                        Exit For
                    End If
                    nCurRecUser.Position += 1
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

End Class