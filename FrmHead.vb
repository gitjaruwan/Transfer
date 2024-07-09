Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmHead
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

    Private Sub FrmHeadt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With

        CbSup_Id.Items.Clear()
        Dim sqlSupCode As String
        sqlSupCode = "SELECT * FROM tblSupervisor WHERE Factory = '" & MFactory & "' Order By Sup_Id "
        da = New SqlDataAdapter(sqlSupCode, Conn)
        da.Fill(ds, "Sup1")
        If ds.Tables("Sup1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Sup1").Rows.Count - 1
                CbSup_Id.Items.Add(ds.Tables("Sup1").Rows(i).Item("Sup_Id") & " " & _
                            ds.Tables("Sup1").Rows(i).Item("Sup_Name"))
            Next
        End If
        CbSup_Id.Text = ""
        ds.Tables("Sup1").Clear()

        Up_DataGrid()
        TxtHead_Id.Text = ""

    End Sub

    Private Sub Clear_Dat()
        TxtHead_Name.Text = ""
        CbSup_Id.Text = ""
    End Sub

    Private Sub Up_DataGrid()
        table.Clear()
        'ds.Tables("Fac2").Clear()
        GetData_Update("SELECT * FROM TblHead WHERE Factory = '" & MFactory & "' Order By Sup_Id,Head_Id")
        GetData("SELECT * FROM TblHead WHERE Factory = '" & MFactory & "' Order By Sup_Id,Head_Id")
        DataGridView1.Refresh()
        SumGrid1()
    End Sub


    Private Sub SumGrid1()
        Label4.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " รายการ"
    End Sub

    Private Sub ChkAddEdit()
        Dim sqlFact As String
        'IsFindEmp = True
        sqlFact = "SELECT * FROM TblHead WHERE Head_Id = '" & TxtHead_Id.Text & "' and Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Fact1")
        If ds.Tables("Fact1").Rows.Count <> 0 Then
            IsFindEmp = True
            If ds.Tables("Fact1").Rows(0).Item("Head_Id") Is System.DBNull.Value = False Then
                TxtHead_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Head_Id"))
            Else
                TxtHead_Id.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Head_Name") Is System.DBNull.Value = False Then
                TxtHead_Name.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Head_Name"))
            Else
                TxtHead_Name.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Sup_Id") Is System.DBNull.Value = False Then
                'CbSup_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Sup_Id") Is System.DBNull.Value = False Then
                    CbSup_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id"))
                    Dim SqlSup As String
                    SqlSup = "Select * from TblSupervisor where Sup_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id")) & "' and Factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlSup, Conn)
                    da.Fill(ds, "Pos1")
                    If ds.Tables("Pos1").Rows.Count <> 0 Then
                        If ds.Tables("Pos1").Rows(0).Item("Sup_Name") Is System.DBNull.Value = False Then

                            CbSup_Id.Text = CStr(ds.Tables("Pos1").Rows(0).Item("Sup_Id")) & " " & _
                        CStr(ds.Tables("Pos1").Rows(0).Item("Sup_Name"))

                        End If
                    End If
                    ds.Tables("Pos1").Clear()
                Else
                    CbSup_Id.Text = ""
                End If
            Else
                CbSup_Id.Text = ""
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
            Dim ColHead_Id As New DataGridViewTextBoxColumn
            With ColHead_Id
                .DataPropertyName = "Head_Id"
                .HeaderText = "รหัสหัวหน้าหน่วย"
                .Width = 100
                .MaxInputLength = 8
                .ReadOnly = True
            End With
            .Columns.Add(ColHead_Id)

            Dim ColHead_Name As New DataGridViewTextBoxColumn
            With ColHead_Name
                .DataPropertyName = "Head_Name"
                .HeaderText = "ชื่อหัวหน้าหน่วย"
                .Width = 450
                .MaxInputLength = 100
                .ReadOnly = True
            End With
            .Columns.Add(ColHead_Name)

            Dim sqlSup As String
            sqlSup = "SELECT * FROM tblSupervisor where Factory = '" & MFactory & "' Order By Sup_Id"
            da = New SqlDataAdapter(sqlSup, Conn)
            da.Fill(ds, "Sup2")
            Dim ColSup As New DataGridViewComboBoxColumn
            With ColSup
                .DataPropertyName = "Sup_Id"
                .HeaderText = "Supervisor"
                .Width = 300
                .DataSource = ds.Tables("Sup2")
                .ValueMember = "Sup_Id"
                .DisplayMember = "Sup_Name"
                .DropDownWidth = 300
                .ReadOnly = True
            End With
            .Columns.Add(ColSup)


        End With
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim RpTDep As New PrtHead
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
        MFormula = "{tblHead.Factory} = '" & MFactory & "'"

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
        Try
            If DataGridView1.CurrentRow.Cells("Head_Id").Value Is System.DBNull.Value = False Then
                TxtHead_Id.Text = DataGridView1.CurrentRow.Cells("Head_Id").Value
                ChkAddEdit()
            End If
        Catch

        End Try
        Return
    End Sub

    ' Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
    'With e.Row
    '.Cells("Head_Id").Value = ""
    'If .Index <> 0 Then
    '.Cells("Head_Id").Value = IIf(DataGridView1.Rows(.Index - 1).Cells("Head_Id").Value <= 9, "0" & Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Head_Id").Value + 1)), Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Head_Id").Value + 1)))
    '.Cells("Head_Id").Value = ""
    'Else
    '.Cells("Head_Id").Value = "A100001"
    'End If
    '.Cells("Head_Name").Value = ""
    'End With
    'End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub txtHead_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHead_Id.KeyDown, TxtHead_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtHead_Name.Focus()
        End If
    End Sub

    Private Sub txtHead_Id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHead_Id.Validated, TxtHead_Id.Validated
        TxtHead_Id.Text = UCase(TxtHead_Id.Text)
        ChkAddEdit()
    End Sub


    Private Sub CmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdDel.Click
        Dim sqlDel, SqlLog As String
        If Len(TxtHead_Id.Text) <> 8 Then
            MessageBox.Show("ป้อนรหัสหัวหน้าหน่วย 8 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtHead_Id.Focus()
            Exit Sub
        End If

        If MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ ?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If IsFindEmp = True Then
            sqlDel = "DELETE FROM TblHead WHERE Head_Id = '" & TxtHead_Id.Text & "' And Factory = '" & MFactory & "'"
            With ComDel
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = sqlDel
                .ExecuteNonQuery()
            End With
            SqlLog = "Delete หัวหน้า " & TxtHead_Id.Text & " " & TxtHead_Name.Text
            SaveLog(SqlLog)
            'MessageBox.Show("ลบรายการ  ของ " & TxtHead_Id.Text & " " & Cb.Text & " เรียบร้อยแล้ว..", "ลบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Up_DataGrid()
        Clear_Dat()
        TxtHead_Id.Text = ""
        TxtHead_Id.Focus()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        If Len(TxtHead_Id.Text) <> 8 Then
            MessageBox.Show("ป้อนรหัสหัวหน้าหน่วย 8 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtHead_Id.Focus()
            Exit Sub
        End If
        If TxtHead_Name.Text = "" Then
            MessageBox.Show("ป้อนชื่อหัวหน้าหน่วย ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtHead_Name.Focus()
            Exit Sub
        End If

        Save_Dat()
        MessageBox.Show("บันทึกรายการ  ของ " & TxtHead_Id.Text & " " & TxtHead_Name.Text & " เรียบร้อยแล้ว..", "บันทึกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Up_DataGrid()
        Clear_Dat()
        TxtHead_Id.Text = ""
        TxtHead_Id.Focus()
    End Sub

    Private Sub Save_Dat()
        Dim sqlSave, SqlLog As String
        If IsFindEmp = True Then
            sqlSave = "UPDATE TblHead SET "
            sqlSave &= "Factory = '" & MFactory & "',"
            sqlSave &= "Head_Id = '" & TxtHead_Id.Text & "',"
            sqlSave &= "Head_Name = '" & TxtHead_Name.Text & "',"
            sqlSave &= "Sup_Id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
            sqlSave &= " WHERE Head_Id = '" & TxtHead_Id.Text & "'"
            SqlLog = "Edit หัวหน้า " & TxtHead_Id.Text & " " & TxtHead_Name.Text
        Else
            sqlSave = "INSERT INTO TblHead (Factory,Head_Id,Head_Name,Sup_Id)"
            sqlSave &= " VALUES('" & MFactory & "','" & TxtHead_Id.Text & "','"
            sqlSave &= TxtHead_Name.Text & "','" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "')"
            SqlLog = "Add หัวหน้า " & TxtHead_Id.Text & " " & TxtHead_Name.Text
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

    Private Sub CmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "รหัสหัวหน้าหน่วย"
        xlWorkSheet.Cells(1, 2).Value = "ชื่อหัวหน้าน่วย "
        xlWorkSheet.Cells(1, 3).Value = "รหัสSupervisor"
        xlWorkSheet.Cells(1, 4).Value = "ชื่อSupervisor "


        Dim SqlString As String
        SqlString = "SELECT TblHead.Head_Id,TblHead.Head_Name,TblHead.Sup_Id,tblSupervisor.Sup_Name " & _
       " FROM TblHead Left Outer Join tblSupervisor On tblHead.Sup_Id = tblSupervisor.Sup_Id Where TblHead.Factory = '" & MFactory & "'" '& MFilter

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 0 Or j = 2 Then
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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TblHead.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TblHead.xls")

    End Sub

    Private Sub CbSup_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbSup_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdSave.Focus()
        End If
    End Sub

    Private Sub CbSup_Id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbSup_Id.SelectedIndexChanged

    End Sub

    Private Sub CmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRefresh.Click
        Clear_Dat()
        TxtHead_Id.Focus()

    End Sub

    Private Sub TxtHead_Name_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHead_Name.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbSup_Id.Focus()
        End If
    End Sub

    Private Sub FrmHead_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Label4.Location = New Point(Label4.Location.X, Me.Height - 65)
    End Sub
End Class