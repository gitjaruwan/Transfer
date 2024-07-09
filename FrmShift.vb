Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmShift
    Dim IsFindEmp As Boolean = False
    Private bindingSource1 As New BindingSource()
    Dim table As New DataTable()
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim da As SqlDataAdapter
    Dim da2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim MFact As String
    Dim nCurRecFact As CurrencyManager


    Private Sub FrmShift_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With
        Dim sqlFact As String
        sqlFact = "SELECT * FROM tblShift where Factory = '" & MFactory & "' Order By Shift_Id"
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Shift1")

        Clear_Shift()
        Up_DataGrid()
        txtShift_Id.Text = ""

    End Sub

    Private Sub Up_DataGrid()
        table.Clear()
        'ds.Tables("Fac2").Clear()
        GetData_Update("SELECT * FROM tblShift Where Factory = '" & MFactory & "' ")
        GetData("SELECT * FROM tblShift where Factory = '" & MFactory & "' ")
        DataGridView1.Refresh()
        SumGrid1()
    End Sub


    Private Sub GetData_Update(ByVal selectCommand As String)
        '=============Data For UpDate=================
        'เพราะ SqlCommandBuilder Update ได้ table เดียว ไม่สามารถ Update หลาย table join กันได้
        'แก้ไขโดย แยก DataAdapter Same Dataset
        da2 = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder1 As New SqlCommandBuilder(da2)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        da2.Fill(table)
        Me.bindingSource1.DataSource = table
        'Me.bindingSource1.AllowNew = False
    End Sub

    Private Sub GetData(ByVal selectCommand As String)
        da = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder As New SqlCommandBuilder(da)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        'da.Fill(table)
        Me.bindingSource1.DataSource = table
        'Me.bindingSource1.AllowNew = True
        With DataGridView1
            .DataSource = Me.bindingSource1
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            '.EditMode = DataGridViewEditMode.EditOnEnter

            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next

            '=============================================================================================
            Dim ColShift_Id As New DataGridViewTextBoxColumn
            With ColShift_Id
                .DataPropertyName = "Shift_Id"
                .HeaderText = "รหัสกะ"
                .Width = 65
                .ReadOnly = True
            End With
            .Columns.Add(ColShift_Id)

            Dim ColShift_Nm As New DataGridViewTextBoxColumn
            With ColShift_Nm
                .DataPropertyName = "Shift_Nm"
                .HeaderText = "ชื่อกะ"
                .Width = 100
                .ReadOnly = True
            End With
            .Columns.Add(ColShift_Nm)

            Dim ColShift_In As New DataGridViewTextBoxColumn
            With ColShift_In
                .DataPropertyName = "Shift_In"
                .DefaultCellStyle.Format = "HH:mm"
                .HeaderText = "เข้า"
                .Width = 75
                .ReadOnly = True
            End With
            .Columns.Add(ColShift_In)

            Dim ColShift_Out As New DataGridViewTextBoxColumn
            With ColShift_Out
                .DataPropertyName = "Shift_Out"
                .DefaultCellStyle.Format = "HH:mm"
                .HeaderText = "ออก"
                .Width = 75
                .ReadOnly = True
            End With
            .Columns.Add(ColShift_Out)


            Dim ColShift_Hr As New DataGridViewTextBoxColumn
            With ColShift_Hr
                .DataPropertyName = "Shift_Hr"
                .HeaderText = "ชม.ทำงาน"
                .Width = 85
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.0"
            End With
            .Columns.Add(ColShift_Hr)


            

            'Dim ColOtRate As New DataGridViewTextBoxColumn
            'With ColOtRate
            ' .DataPropertyName = "OtRate"
            ' .HeaderText = "โอที"
            ' .Width = 75
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "#,###.00"
            'End With
            '.Columns.Add(ColOtRate)

            'Dim ColOtOrg As New DataGridViewTextBoxColumn
            'With ColOtOrg
            ' .DataPropertyName = "OtOrg"
            ' .HeaderText = "ค่าจัดการ OT"
            ' .Width = 75
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "#,###.00"
            'End With
            '.Columns.Add(ColOtOrg)

            'Dim ColWhiteHat As New DataGridViewTextBoxColumn
            'With ColWhiteHat
            ' .DataPropertyName = "WhiteHat"
            ' .HeaderText = "ค่าหมวกขาว"
            ' .Width = 75
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "#,###.00"
            'End With
            '.Columns.Add(ColWhiteHat)

            'Dim ColInductRate As New DataGridViewTextBoxColumn
            'With ColInductRate
            ' .DataPropertyName = "InductRate"
            ' .HeaderText = "ค่าเบี้ยขยัน"
            ' .Width = 75
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "#,###.00"
            'End With
            'Columns.Add(ColInductRate)

        End With

    End Sub



    Private Sub Clear_Shift()
        ds.Tables("Shift1").Clear()
        Dim sqlFact As String
        sqlFact = "SELECT * FROM tblShift Order By Shift_Id"
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Shift1")
        If ds.Tables("Shift1").Rows.Count > 0 Then
            'txtShift_Id.Text = "A4"
            'txtShift_Id.Text = "A" & Val(Microsoft.VisualBasic.Right((ds.Tables("Shift1").Rows(ds.Tables("Shift1").Rows.Count - 1).Item("Shift_Id")), 1)) + 1
            'If txtShift_Id.Text = "A10" Then
            'txtShift_Id.Text = "B1"
            'End If
        End If
        TxtShift_Nm.Text = ""
        If CultureInfo.CurrentCulture.Name = "en-GB" Or CultureInfo.CurrentCulture.Name = "en-US" Then
            DTPShift_In.Value = #1/1/1900 7:00:00 AM#
            DTPShift_Out.Value = #1/1/1900 5:00:00 PM#
            DTPShift_relx1.Value = #1/1/1900 12:00:00 PM#
            DTPShift_relx2.Value = #1/1/1900 1:00:00 PM#
        Else
            If CultureInfo.CurrentCulture.Name = "th-TH" Then
                DTPShift_In.Value = #1/1/2443 7:00:00 AM#
                DTPShift_Out.Value = #1/1/2443 5:00:00 PM#
                DTPShift_relx1.Value = #1/1/2443 12:00:00 PM#
                DTPShift_relx2.Value = #1/1/2443 1:00:00 PM#
            End If
        End If
        'DTPShift_In.Format = DateTimePickerFormat.Custom
        'DTPShift_In.CustomFormat = "h:mm:ss"
        'DTPShift_Out.Format = DateTimePickerFormat.Custom
        'DTPShift_Out.CustomFormat = "h:mm:ss"
        'DTPShift_relx1.Format = DateTimePickerFormat.Custom
        'DTPShift_relx1.CustomFormat = "h:mm:ss"
        'DTPShift_relx2.Format = DateTimePickerFormat.Custom
        'DTPShift_relx2.CustomFormat = "h:mm:ss"

        'MsgBox(CultureInfo.CurrentCulture.Name)
        'CurrentCulture is en-US.
        'CurrentCulture is now th-TH.
        'CurrentUICulture is en-US.
        'CurrentUICulture is now ja-JP.

        TxtShift_Hr.Text = CDbl(DateDiff(DateInterval.Hour, DTPShift_In.Value, DTPShift_Out.Value)) - CDbl(DateDiff(DateInterval.Hour, DTPShift_relx1.Value, DTPShift_relx2.Value)) '"8"
        TxtShift_Ot.Text = "36.38"
        TxtShift_Ka.Text = "0"
        cmdSave.Enabled = False
        'cmdDel.Enabled = False
        txtShift_Id.Focus()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Clear_Shift()
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        ds.Tables("Shift1").Clear()
        Dim sqlfact As String
        sqlfact = "SELECT * FROM tblShift Order By Shift_Id"
        da = New SqlDataAdapter(sqlfact, Conn)
        da.Fill(ds, "Shift1")

        nCurRecFact = CType(Me.BindingContext(ds, "Shift1"), CurrencyManager)
        If ds.Tables("Shift1").Rows.Count > 0 Then
            nCurRecFact.Position = 0
        End If
        txtSearchFact.Text = ""
        Panel2.Show()
        Panel2.Left = TxtShift_Nm.Left
        dgLookUpFact.DataSource = Nothing
        OrderGridFact()
        txtSearchFact.Focus()
    End Sub

    Private Sub OrderGridFact()
        Dim SupTS As New DataGridTableStyle
        With SupTS
            .MappingName = "Shift1"
            .AllowSorting = False
            .AlternatingBackColor = Color.AliceBlue
        End With

        Dim Col1 As New DataGridTextBoxColumn
        With Col1
            .HeaderText = "รหัสกะ"
            .MappingName = "Shift_Id"
            .ReadOnly = True
            .Width = 70
        End With
        SupTS.GridColumnStyles.Add(Col1)

        Dim Col2 As New DataGridTextBoxColumn
        With Col2
            .HeaderText = "ชื่อกะ"
            .MappingName = "Shift_Nm"
            .ReadOnly = True
            .Width = 200
        End With
        SupTS.GridColumnStyles.Add(Col2)

        With dgLookUpFact
            .TableStyles.Clear()
            .CaptionText = "Shift Code"
            .TableStyles.Add(SupTS)
            .ReadOnly = True
            '.FlatMode = True
            .DataSource = ds.Tables("Shift1")
            .AllowSorting = False
            .AllowNavigation = True
        End With
    End Sub

    Private Sub txtSearchFact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFact.KeyDown
        If e.KeyCode = Keys.Escape Then
            Panel2.Hide()
            txtShift_Id.Focus()
        Else
            If e.KeyCode = Keys.Enter Then
                txtShift_Id.Text = CStr(ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("Shift_Id"))
                If ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("Shift_Nm") Is System.DBNull.Value = False Then
                    TxtShift_Nm.Text = CStr(ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("Shift_Nm"))
                End If
                'If ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("LastName") Is System.DBNull.Value = False Then
                'TxtLastName.Text = CStr(ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("LastName"))
                'End If
                Panel2.Hide()
                ChkAddEdit()
                TxtShift_Nm.Focus()
            End If
        End If
    End Sub

    Private Sub ChkAddEdit()
        Dim sqlFact As String
        sqlFact = "SELECT * FROM tblShift WHERE Shift_Id='" & txtShift_Id.Text & "' and Factory = '" & MFactory & "'"
        If IsFindEmp = True Then
            ds.Tables("Shift").Clear()
        End If
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Shift")
        If ds.Tables("Shift").Rows.Count <> 0 Then
            IsFindEmp = True
            txtShift_Id.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Id"))
            If ds.Tables("Shift").Rows(0).Item("Shift_Nm") Is System.DBNull.Value = False Then
                TxtShift_Nm.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Nm"))
            Else
                TxtShift_Nm.Text = ""
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_In") Is System.DBNull.Value = False Then
                DTPShift_In.Value = CStr(ds.Tables("Shift").Rows(0).Item("Shift_In"))
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_Out") Is System.DBNull.Value = False Then
                DTPShift_Out.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Out"))
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_relx1") Is System.DBNull.Value = False Then
                DTPShift_relx1.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_relx1"))
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_relx2") Is System.DBNull.Value = False Then
                DTPShift_relx2.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_relx2"))
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_Hr") Is System.DBNull.Value = False Then
                TxtShift_Hr.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Hr"))
            Else
                TxtShift_Hr.Text = "0"
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_Ot") Is System.DBNull.Value = False Then
                TxtShift_Ot.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Ot"))
                TxtShift_Ot.Text = Format(CDbl(TxtShift_Ot.Text), "#,##0.00")
            Else
                TxtShift_Ot.Text = "0"
            End If
            If ds.Tables("Shift").Rows(0).Item("Shift_Ka") Is System.DBNull.Value = False Then
                TxtShift_Ka.Text = CStr(ds.Tables("Shift").Rows(0).Item("Shift_Ka"))
                TxtShift_Ka.Text = Format(CDbl(TxtShift_Ka.Text), "#,##0.00")
            Else
                TxtShift_Ka.Text = "0"
            End If
           

            cmdSave.Enabled = True
            'cmdDel.Enabled = True
            TxtShift_Nm.Focus()
        Else
            IsFindEmp = False
            Clear_Shift()
            CmdSave.Enabled = True

            TxtShift_Nm.Focus()
        End If
    End Sub

    Private Sub txtSearchFact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFact.KeyUp
        Dim i As Integer = 0
        Dim lFound As Boolean = False
        For i = 0 To ds.Tables("Shift1").Rows.Count - 1
            If UCase(txtSearchFact.Text) = UCase(Mid(CStr(ds.Tables("Shift1").Rows(i).Item(0)), 1, Len(Trim(txtSearchFact.Text)))) Then
                nCurRecFact.Position = i
                dgLookUpFact.CurrentRowIndex = i
                lFound = True
                Exit For
            End If
            nCurRecFact.Position += 1
        Next

        If lFound = False Then
            For i = 0 To ds.Tables("Shift1").Rows.Count - 1
                Try
                    If UCase(txtSearchFact.Text) = UCase(Mid(CStr(ds.Tables("Shift1").Rows(i).Item(1)), 1, Len(Trim(txtSearchFact.Text)))) Then
                        nCurRecFact.Position = i
                        dgLookUpFact.CurrentRowIndex = i
                        lFound = True
                        Exit For
                    End If
                    nCurRecFact.Position += 1
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

    Private Sub dgLookUpFact_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLookUpFact.DoubleClick
        txtShift_Id.Text = CStr(ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("Shift_Id"))
        Panel2.Hide()
        ChkAddEdit()
        TxtShift_Nm.Enabled = True
        TxtShift_Nm.Focus()
    End Sub

    Private Sub dgLookUpFact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgLookUpFact.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtShift_Id.Text = CStr(ds.Tables("Shift1").Rows(dgLookUpFact.CurrentRowIndex).Item("Shift_Id"))
            Panel2.Hide()
            ChkAddEdit()
            TxtShift_Nm.Enabled = True
            TxtShift_Nm.Focus()
        End If
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Panel2.Hide()
        txtShift_Id.Focus()
    End Sub

    Private Sub txtShift_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShift_Id.KeyDown
        If txtShift_Id.Text = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            If Len(txtShift_Id.Text) <> 3 Then
                MessageBox.Show("ป้อนรหัสกะ 3 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtShift_Id.Focus()
            Else
                TxtShift_Nm.Enabled = True
                TxtShift_Nm.Focus()
            End If
        End If
    End Sub

    Private Sub TxtShift_Nm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShift_Nm.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtShift_Nm.Text = "" Then
                MessageBox.Show("ป้อนชื่อกะ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtShift_Nm.Focus()
            Else
                DTPShift_In.Focus()
            End If

        End If
    End Sub

    Private Sub TxtShift_Nm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShift_Nm.KeyUp
        If e.KeyCode = Keys.Escape Then
            Clear_Shift()
        End If
    End Sub

    Private Sub DTPShift_In_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPShift_In.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPShift_Out.Focus()
        End If
    End Sub

    Private Sub DTPShift_Out_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPShift_Out.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPShift_relx1.Focus()
        End If
    End Sub

    Private Sub DTPShift_relx1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPShift_relx1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPShift_relx2.Focus()
        End If
    End Sub

    Private Sub DTPShift_relx2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPShift_relx2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtShift_Hr.Focus()
        End If
    End Sub

    Private Sub TxtShift_Hr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShift_Hr.GotFocus
        'If IsFindEmp = False Then
        TxtShift_Hr.Text = CDbl(DateDiff(DateInterval.Hour, DTPShift_In.Value, DTPShift_Out.Value)) - CDbl(DateDiff(DateInterval.Hour, DTPShift_relx1.Value, DTPShift_relx2.Value)) '"8"
        'End If
    End Sub

    Private Sub txtShift_Hr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShift_Hr.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtShift_Hr.Text = Format(CDbl(TxtShift_Hr.Text), "#,##0.00")
            TxtShift_Ot.Focus()
        End If
    End Sub

    Private Sub TxtShift_Ot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShift_Ot.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtShift_Ot.Text = Format(CDbl(TxtShift_Ot.Text), "#,##0.00")
            TxtShift_Ka.Focus()
        End If
    End Sub

    Private Sub TxtShift_Ka_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShift_Ka.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtShift_Ka.Text = Format(CDbl(TxtShift_Ka.Text), "#,##0.00")
            cmdSave.Focus()
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

    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqlDel As String
        Dim sqlLog As String
        If txtShift_Id.Text = "" Then
            MessageBox.Show("ป้อนข้อมูลไม่ครบถ้วน", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtShift_Id.Focus()
            Exit Sub
        End If
        If MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ ?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If IsFindEmp = True Then
            sqlDel = "DELETE FROM tblShift WHERE Shift_Id = '" & txtShift_Id.Text & "' And Factory = '" & MFactory & "'"
            With ComDel
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = sqlDel
                .ExecuteNonQuery()
            End With
            sqlLog = "ลบ กะ " & txtShift_Id.Text & " " & TxtShift_Nm.Text
            SaveLog(sqlLog)

            MessageBox.Show("ลบรายการ " & txtShift_Id.Text & " " & TxtShift_Nm.Text & " เรียบร้อยแล้ว..", "ลบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Up_DataGrid()
        Clear_Shift()
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim RpTDep As New PrtShift
        Dim MParamFactName, MParamFactAddr, MFormula As String
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTDep.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
                And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTDep.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTDep.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)
        MParamFactName = MFactName
        MParamFactAddr = MFactAddr
        MFormula = "{tblShift.Factory} = '" & MFactory & "'"

        With CRVDep
            .ReportSource = RpTDep
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamFactName)
            '.ParameterFieldInfo(1).CurrentValues.AddValue(MParamFactAddr)
            .SelectionFormula = MFormula
            .DisplayGroupTree = False
            .Zoom(150)
            .Width = FrmMain.Width - 10 '800
            .Height = FrmMain.Height - 30 '525
            .Left = 0
            .Top = 0
        End With
        With FrmPrTDep
            .MdiParent = FrmMain
            .Controls.Add(CRVDep)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        If DataGridView1.CurrentRow.Cells("Shift_Id").Value Is System.DBNull.Value = False Then
            txtShift_Id.Text = DataGridView1.CurrentRow.Cells("Shift_Id").Value
            ChkAddEdit()
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub txtShift_Id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShift_Id.Validated
        txtShift_Id.Text = UCase(txtShift_Id.Text)
        ChkAddEdit()
    End Sub

    Private Sub CmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRefresh.Click
        Clear_Dat()
        txtShift_Id.Focus()
    End Sub

    Private Sub Clear_Dat()
        TxtShift_Hr.Text = ""
        txtShift_Id.Text = ""
        TxtShift_Ka.Text = ""
        TxtShift_Nm.Text = ""
        TxtShift_Ot.Text = ""
        DTPShift_In.Text = ""
        DTPShift_Out.Text = ""
        DTPShift_relx1.Text = ""
        DTPShift_relx2.Text = ""
        Clear_Shift()


    End Sub
    Private Sub SumGrid1()
        Label2.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " รายการ"
    End Sub

    Private Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Dim sqlSave As String
        Dim SqlLog As String

        'Check Data Before Save
        If Len(txtShift_Id.Text) <> 3 Then
            MessageBox.Show("ป้อนรหัสกะ 3 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtShift_Id.Focus()
            Exit Sub
        End If
        If TxtShift_Nm.Text = "" Then
            MessageBox.Show("ป้อนชื่อกะ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtShift_Nm.Focus()
            Exit Sub
        End If

        'MsgBox(CbSex.Text)
        If TxtShift_Hr.Text = "" Then
            TxtShift_Hr.Text = "0.00"
        End If
        If TxtShift_Ot.Text = "" Then
            TxtShift_Ot.Text = "0.00"
        End If
        If TxtShift_Ka.Text = "" Then
            TxtShift_Ka.Text = "0.00"
        End If
        '=== Save Data
        If IsFindEmp = True Then
            sqlSave = "UPDATE tblShift SET "
            sqlSave &= "Factory = '" & MFactory & "',"
            sqlSave &= "Shift_Nm = '" & TxtShift_Nm.Text & "',"
            sqlSave &= "Shift_In = '" & DTPShift_In.Value & "',"
            sqlSave &= "Shift_Out = '" & DTPShift_Out.Value & "',"
            sqlSave &= "Shift_relx1 = '" & DTPShift_relx1.Value & "',"
            sqlSave &= "Shift_relx2 = '" & DTPShift_relx2.Value & "',"
            sqlSave &= "Shift_Hr = '" & CStr(CDbl(TxtShift_Hr.Text)) & "',"
            sqlSave &= "Shift_Ot = '" & CStr(CDbl(TxtShift_Ot.Text)) & "',"
            sqlSave &= "Shift_Ka = '" & CStr(CDbl(TxtShift_Ka.Text)) & "',"
            sqlSave &= "' WHERE Shift_Id = '" & txtShift_Id.Text & "' And Factory = '" & MFactory & "' "
            SqlLog = "แก้ไข กะ " & txtShift_Id.Text & " " & TxtShift_Nm.Text
        Else
            sqlSave = "INSERT INTO tblShift (Factory,Shift_Id,Shift_Nm,Shift_In,Shift_Out,Shift_relx1,Shift_relx2,Shift_Hr,Shift_Ot,Shift_Ka)"
            sqlSave &= " VALUES('" & MFactory & "','" & txtShift_Id.Text & "','"
            sqlSave &= TxtShift_Nm.Text & "','" & DTPShift_In.Value & "','"
            sqlSave &= DTPShift_Out.Value & "','" & DTPShift_relx1.Value
            sqlSave &= "','" & DTPShift_relx2.Value & "','"
            sqlSave &= CStr(CDbl(TxtShift_Hr.Text)) & "','"
            sqlSave &= CStr(CDbl(TxtShift_Ot.Text)) & "','"
            sqlSave &= CStr(CDbl(TxtShift_Ka.Text)) & "')"
            SqlLog = "เพิ่ม กะ " & txtShift_Id.Text & " " & TxtShift_Nm.Text
        End If
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = sqlSave
            .ExecuteNonQuery()
        End With
        SaveLog(SqlLog)

        Up_DataGrid()
        Clear_Shift()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "รหัสกะ"
        xlWorkSheet.Cells(1, 2).Value = "ชื่อกะ"
        xlWorkSheet.Cells(1, 3).Value = "เวลาเข้า"
        xlWorkSheet.Cells(1, 4).Value = "เวลาออก"
        xlWorkSheet.Cells(1, 5).Value = "เริ่มพัก"
        xlWorkSheet.Cells(1, 6).Value = "เวลาทำงานต่อ"
        xlWorkSheet.Cells(1, 7).Value = "ชั่วโมงทำงาน"
        xlWorkSheet.Cells(1, 8).Value = "ค่าล่วงเวลา"
        xlWorkSheet.Cells(1, 9).Value = "ค่ากะ"

        Dim SqlString As String
        SqlString = "SELECT Shift_id,Shift_Nm,Shift_In,Shift_Out,Shift_Relx1,Shift_Relx2,Shift_Hr,Shift_Ot,Shift_Ka" & _
       " FROM TblShift where Factory = '" & MFactory & "'" '& MFilter

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 0 Then
                        xlWorkSheet.Cells(i + 2, j + 1) = "'" & ds.Tables("DataSet1").Rows(i).Item(j)
                    Else
                        xlWorkSheet.Cells(i + 2, j + 1) = ds.Tables("DataSet1").Rows(i).Item(j)
                    End If
                Next
            Next
        End If
        ds.Tables("DataSet1").Clear()
        xlWorkSheet.Columns.AutoFit()

        xlApp.DisplayAlerts = False
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TblShift.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TblShift.xls")
    End Sub
End Class