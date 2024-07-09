Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading

Public Class FrmLogin
    Dim StrSql As String
    Dim TrnStr As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim ComSave As New SqlCommand

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim SqlLog As String = ""
        If PasswordTextBox.Text <> "" Then
            Dim sqlBuyer As String
            sqlBuyer = "SELECT * FROM TblPassword Where fcode = '" & UsernameTextBox.Text & "' And FPassword = '" & _
            PasswordTextBox.Text & "' and Factory = '" & MFactory & "'"
            da = New SqlDataAdapter(sqlBuyer, Conn)
            da.Fill(ds, "Pass1")
            If ds.Tables("Pass1").Rows.Count <> 0 Then
                If ds.Tables("Pass1").Rows(0).Item("PMenu1") = False Then
                    FrmMain.ต้นสังกัดToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("PMenu2") = False Then
                    FrmMain.รายการคางชำระโอนToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("PMenu3") = False Then
                    FrmMain.รายงานอนๆToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("PMenu4") = False Then
                    FrmMain.SETUPToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("PMenu5") = False Then
                    FrmMain.เครองมอToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("PMenu6") = False Then
                    FrmMain.รายการตราคาวตถดบToolStripMenuItem.Visible = False
                End If
                If ds.Tables("Pass1").Rows(0).Item("ShudA") = True Then
                    XShudA = True
                End If
                If ds.Tables("Pass1").Rows(0).Item("ShudB") = True Then
                    XShudB = True
                End If
                If ds.Tables("Pass1").Rows(0).Item("ShudC") = True Then
                    XShudC = True
                End If
                If ds.Tables("Pass1").Rows(0).Item("ShudD") = True Then
                    XShudD = True
                End If
                If ds.Tables("Pass1").Rows(0).Item("ShudE") = True Then
                    XShudE = True
                End If

                XShud = ds.Tables("Pass1").Rows(0).Item("Shud")

                MFCODE = UsernameTextBox.Text
                Me.Hide()
                With FrmMain
                    '.MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With
                SqlLog = UsernameTextBox.Text & " เข้าระบบสำเร็จ"
            Else
                MFCODE = UsernameTextBox.Text
                MessageBox.Show("รหัส " & UsernameTextBox.Text & " ไม่ผ่าน...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PasswordTextBox.Focus()
                PasswordTextBox.SelectionStart = 0
                PasswordTextBox.SelectionLength = Len(PasswordTextBox.Text)
                SqlLog = UsernameTextBox.Text & " เข้าระบบไม่สำเร็จ"
            End If
            ds.Tables("Pass1").Clear()

            'SaveLog(SqlLog)
        End If

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

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'MsgBox(CalAge("#22/11/1971#"))
        Me.Close()
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Year(Now.Date) > 2500 Then
            MsgBox("โปรดเปลี่ยนรูปแบบวันที่เป็น คริตส์ศักราช เช่น 31/03/2010 : start=>Setting=>ControlPanel=>Region And Language=>Format To English (United KingDom)")
            Me.Close()
            Exit Sub
        End If

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
        'CurrentCulture is en-US.
        'CurrentCulture is now th-TH.
        'CurrentUICulture is en-US.
        'CurrentUICulture is now ja-JP.

        'MsgBox(Thread.CurrentThread.CurrentCulture.ToString)
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = SqlConn()
            .Open()
        End With
        Me.CenterToScreen()
    End Sub

    Private Sub UsernameTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.Enter
        'PasswordTextBox.Focus()
    End Sub


    Private Sub UsernameTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            PasswordTextBox.Enabled = True
            PasswordTextBox.Focus()
        End If
    End Sub
End Class
