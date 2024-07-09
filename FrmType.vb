Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmType
    Inherits System.Windows.Forms.Form
    Private bindingSource1 As New BindingSource()
    Dim StrSql As String
    Dim TrnStr As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim da2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim table As New DataTable()
    Dim MFact As String
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim IsFindEmp As Boolean = False

    Private Sub FrmTypet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With

        Up_DataGrid()
        TxtType_Id.Text = ""
    End Sub

    Private Sub Clear_Dat()
        TxtType_En.Text = ""
        TxtType_Th.Text = ""
    End Sub

    Private Sub Up_DataGrid()
        table.Clear()
        'ds.Tables("Fac2").Clear()
        GetData_Update("SELECT * FROM TblType WHERE Factory = '" & MFactory & "'")
        GetData("SELECT * FROM TblType WHERE Factory = '" & MFactory & "'")
        DataGridView1.Refresh()
        SumGrid1()
    End Sub

    Private Sub SumGrid1()
        Label4.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " รายการ"
    End Sub

    Private Sub ChkAddEdit()
        Dim sqlFact As String
        'IsFindEmp = True
        sqlFact = "SELECT * FROM TblType WHERE Type_Id = '" & TxtType_Id.Text & "' And Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Fact1")
        If ds.Tables("Fact1").Rows.Count <> 0 Then
            IsFindEmp = True
            If ds.Tables("Fact1").Rows(0).Item("Type_Id") Is System.DBNull.Value = False Then
                TxtType_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_Id"))
            Else
                TxtType_Id.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Type_Th") Is System.DBNull.Value = False Then
                TxtType_Th.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_Th"))
            Else
                TxtType_Th.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Type_En") Is System.DBNull.Value = False Then
                TxtType_En.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_En"))
            Else
                TxtType_En.Text = ""
            End If
        Else
            IsFindEmp = False
            Clear_Dat()
        End If
        ds.Tables("Fact1").Clear()
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
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14.25F, GraphicsUnit.Pixel)
            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next
            '=============================================================================================
            Dim ColType_Id As New DataGridViewTextBoxColumn
            With ColType_Id
                .DataPropertyName = "Type_Id"
                .HeaderText = "รหัส"
                .Width = 100
                .MaxInputLength = 2
                .ReadOnly = True
            End With
            .Columns.Add(ColType_Id)

            Dim ColType_Th As New DataGridViewTextBoxColumn
            With ColType_Th
                .DataPropertyName = "Type_Th"
                .HeaderText = "ชื่อประเภทพนักงาน(ไทย)"
                .Width = 400
                .MaxInputLength = 100
                .ReadOnly = True
            End With
            .Columns.Add(ColType_Th)

            Dim ColType_En As New DataGridViewTextBoxColumn
            With ColType_En
                .DataPropertyName = "Type_En"
                .HeaderText = "ชื่อประเภทพนักงาน(อังกฤษ)"
                .Width = 400
                .MaxInputLength = 100
                .ReadOnly = True
            End With
            .Columns.Add(ColType_En)
        End With
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim RpTDep As New PrtType
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
        MFormula = "{tblType.Factory} = '" & MFactory & "'"

        With CRVDep
            .ReportSource = RpTDep
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamFactName)
            '.ParameterFieldInfo(1).CurrentValues.AddValue(MParamFactAddr)
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
        If DataGridView1.CurrentRow.Cells("Type_Id").Value Is System.DBNull.Value = False Then
            TxtType_Id.Text = DataGridView1.CurrentRow.Cells("Type_Id").Value
            ChkAddEdit()
        End If
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        With e.Row
            '.Cells("Type_Id").Value = ""
            If .Index <> 0 Then
                '.Cells("Type_Id").Value = IIf(DataGridView1.Rows(.Index - 1).Cells("Type_Id").Value <= 9, "0" & Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Type_Id").Value + 1)), Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Type_Id").Value + 1)))
                .Cells("Type_Id").Value = ""
                'Else
                '.Cells("Type_Id").Value = "A100001"
            End If
            .Cells("Type_Th").Value = ""
        End With
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub txtType_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtType_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtType_Th.Focus()
        End If
    End Sub

    Private Sub txtType_Id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType_Id.Validated
        TxtType_Id.Text = UCase(TxtType_Id.Text)
        ChkAddEdit()
    End Sub

    Private Sub TxtType_En_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtType_En.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdSave.Focus()
        End If
    End Sub

    Private Sub TxtType_Th_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtType_Th.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtType_En.Focus()
        End If
    End Sub


    Private Sub CmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdDel.Click
        Dim sqlDel, SqlLog As String
        If Len(TxtType_Id.Text) <> 2 Then
            MessageBox.Show("ป้อนรหัสประเภทพนักงาน 2 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtType_Id.Focus()
            Exit Sub
        End If

        If MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ ?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If IsFindEmp = True Then
            sqlDel = "DELETE FROM TblType WHERE Type_Id = '" & TxtType_Id.Text & "' And Factory = '" & MFactory = "'"
            With ComDel
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = sqlDel
                .ExecuteNonQuery()
            End With
            SqlLog = "Delete ประเภทพนักงาน " & TxtType_Id.Text & " " & TxtType_Th.Text
            SaveLog(SqlLog)
            'MessageBox.Show("ลบรายการ  ของ " & txtType_Id.Text & " " & TxtFact__Nm.Text & " เรียบร้อยแล้ว..", "ลบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Up_DataGrid()
        Clear_Dat()
        TxtType_Id.Text = ""
        TxtType_Id.Focus()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        If Len(TxtType_Id.Text) <> 2 Then
            MessageBox.Show("ป้อนรหัสประเภทพนักงาน 2 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtType_Id.Focus()
            Exit Sub
        End If
        If TxtType_Th.Text = "" Then
            MessageBox.Show("ป้อนชื่อประเภทพนักงาน ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtType_Th.Focus()
            Exit Sub
        End If

        Save_Dat()
        'MessageBox.Show("บันทึกรายการ  ของ " & txtType_Id.Text & " " & TxtType_Th.Text & " เรียบร้อยแล้ว..", "บันทึกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Up_DataGrid()
        Clear_Dat()
        TxtType_Id.Text = ""
        TxtType_Id.Focus()
    End Sub

    Private Sub Save_Dat()
        Dim sqlSave, SqlLog As String
        If IsFindEmp = True Then
            sqlSave = "UPDATE TblType SET "
            sqlSave &= "Factory = '" & MFactory & "',"
            sqlSave &= "Type_Id = '" & TxtType_Id.Text & "',"
            sqlSave &= "Type_Th = '" & TxtType_Th.Text & "',"
            sqlSave &= "Type_En = '" & TxtType_En.Text & "'"
            sqlSave &= " WHERE Type_Id = '" & TxtType_Id.Text & "'"
            SqlLog = "Edit ประเภทพนักงาน " & TxtType_Id.Text & " " & TxtType_Th.Text
        Else
            sqlSave = "INSERT INTO TblType (Factory,Type_Id,Type_Th,Type_En)"
            sqlSave &= "VALUES('" & MFactory & "','" & TxtType_Id.Text & "','" & TxtType_Th.Text & "','"
            sqlSave &= TxtType_En.Text & "')"
            SqlLog = "Add ประเภทพนักงาน " & TxtType_Id.Text & " " & TxtType_Th.Text
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

    Private Sub TxtType_En_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType_En.Validated
        TxtType_En.Text = UCase(TxtType_En.Text)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub CmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "รหัสประเภทพนักงาน"
        xlWorkSheet.Cells(1, 2).Value = "ชื่อประเภทพนักงาน(ไทย)"
        xlWorkSheet.Cells(1, 3).Value = "ชื่อประเภทพนักงาน (อังกฤษ)"

        Dim SqlString As String
        SqlString = "SELECT Type_Id,Type_Th,Type_En" & _
       " FROM TblType Where Factory = '" & MFactory & "'"  '& MFilter

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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TblType.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TblType.xls")

    End Sub

    Private Sub CmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRefresh.Click
        Clear_Dat()
        TxtType_Id.Focus()

    End Sub

    Private Sub FrmType_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Label4.Location = New Point(Label4.Location.X, Me.Height - 65)
    End Sub
End Class