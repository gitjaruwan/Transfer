Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Prt_Trn_A3_1
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim CommImp As New SqlCommand
    Dim ComSave As New SqlCommand
    Dim Date1 As DateTime
    Dim Date2 As DateTime

    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker2.Focus()
        End If
    End Sub

    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        'DateTimePicker2.Value = DateAdd(DateInterval.Day, 14, DateTimePicker1.Value)
        DateTimePicker2.Value = DateTimePicker1.Value
    End Sub

    Private Sub Prt_Pay_N1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DateTimePicker1.Focus()
    End Sub

    Private Sub Prt_Pay_N1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = SqlConn()
            .Open()
        End With
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = DateTimePicker1.Value

        CbNation.Items.Clear()
        CbNation.Items.Add("ไทย")
        CbNation.Items.Add("ต่างด้าว")


        Me.CenterToScreen()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        MakeTable1()

        Dim CRVA1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTA1 As New Form
        Dim RpTA1 As New Prt_Trn_A_3_1
        Dim MParamDate As String
        Dim MParamFactName, MParamFactAddr, MParamDep As String 'MParamDep, MFormula' As String
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTA1.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
                And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTA1.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTA1.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)

        MParamDate = "วันที่ " & DateTimePicker1.Text & "      ถึง         " & DateTimePicker2.Text & " "
        'MFormula = "{tblTransFer.TrfDate} =  Date('" & DateTimePicker1.Text & _
        '"') To Date('" & DateTimePicker2.Text & "') And {tblTransFer.Factory} = '" & MFactory & "' And {tblTransFer.FConfirm} = True"

        MParamFactName = MFactName
        MParamFactAddr = MFactAddr

        If Len(CbNation.Text) <> 0 Then
            MParamDep = CbNation.Text
        Else
            MParamDep = ""
        End If


        With CRVA1
            .ReportSource = RpTA1
            '.SelectionFormula = MFormula
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamDate)
            .ParameterFieldInfo(1).CurrentValues.AddValue(MFactName)
            .ParameterFieldInfo(2).CurrentValues.AddValue(MFactAddr)
            .ParameterFieldInfo(3).CurrentValues.AddValue(MParamDep)
            .DisplayGroupTree = False
            .Zoom(100)
            .Width = FrmMain.Width - 10 '1000
            .Height = FrmMain.Height - 30 '700
            .Left = 0
            .Top = 0
        End With

        With FrmPrTA1
            .MdiParent = FrmMain
            .Controls.Add(CRVA1)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Close()

    End Sub

    Private Sub MakeTable1()
        Dim SqlStr As String
        Dim SqlStr2 As String = " "
        Dim SqlSave As String = " "
        Dim xCount As Integer = 1

        SqlStr = "Delete from TmpTran2"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        'Loop1 = Sal_Debit'
        If Len(CbNation.Text) <> 0 Then
            SqlStr = "select TblTransfer.dep_id,TblDepartment.dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Sal_Credit," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Ot_Credit," & _
            "Sum(Incentive) as In_Credit," & _
            "Sum(TblTransfer.Pos_All) As Pos_Credit " & _
            "from tblTransfer LEFT OUTER JOIN tblDepartment on tblTransfer.Dep_id = tblDepartment.Dep_id " & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
            " where Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103)" & _
            " And tblStaff.Nationality = '" & CbNation.Text & "'" & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " group by TblTransfer.dep_id,TblDepartment.Dep_Th"
        Else
            SqlStr = "select TblTransfer.dep_id,TblDepartment.dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Sal_Credit," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Ot_Credit," & _
            "Sum(Incentive) as In_CreDit," & _
            "Sum(TblTransfer.Pos_All) As Pos_Credit " & _
            "from tblTransfer LEFT OUTER JOIN tblDepartment on tblTransfer.Dep_id = tblDepartment.Dep_id " & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
            " where Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103) " & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " group by TblTransfer.dep_id,TblDepartment.Dep_Th"
        End If

        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Trn1")
        If ds.Tables("Trn1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("Trn1").Rows.Count - 1
                SqlStr2 = "Select Dep_Id From TmpTran2 Where dep_id = '" & ds.Tables("Trn1").Rows(i).Item("dep_id") & "'"
                da = New SqlDataAdapter(SqlStr2, Conn)
                da.Fill(ds, "Trn2")
                If ds.Tables("Trn2").Rows.Count <> 0 Then
                    SqlSave = "UPDATE TmpTran2 SET "
                    SqlSave &= "Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Dep_Id") & "',"
                    SqlSave &= "Dep_Th = '" & ds.Tables("Trn1").Rows(i).Item("Dep_Th") & "',"
                    SqlSave &= "Sal_Credit = '" & ds.Tables("Trn1").Rows(i).Item("Sal_Credit") & "',"
                    SqlSave &= "Ot_Credit = '" & ds.Tables("Trn1").Rows(i).Item("Ot_Credit") & "',"
                    SqlSave &= "In_Credit = '" & ds.Tables("Trn1").Rows(i).Item("In_Credit") & "',"
                    SqlSave &= "Pos_Credit = '" & ds.Tables("Trn1").Rows(i).Item("Pos_Credit") & "'"
                    SqlSave &= " WHERE dep_id = '" & ds.Tables("Trn1").Rows(i).Item("dep_id") & "'"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                Else
                    SqlSave = "INSERT INTO TmpTran2(Dep_Id,Dep_Th,Sal_Credit,Ot_Credit,In_Credit,Pos_Credit)"
                    SqlSave &= " VALUES('" & ds.Tables("Trn1").Rows(i).Item("Dep_Id") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Dep_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Sal_Credit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Ot_Credit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("In_Credit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Pos_Credit") & "')"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                End If
                ds.Tables("Trn2").Clear()
            Next
        End If
        ds.Tables("Trn1").Clear()
        'loop2 = sal_Debit'
        If Len(CbNation.Text) <> 0 Then
            SqlStr = "select TblTransfer.dep_id2,TblDepartment.dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Sal_Debit," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Ot_Debit," & _
            "Sum(Incentive) as In_Debit," & _
            "Sum(TblTransfer.Pos_All) As Pos_Debit " & _
            " from tblTransfer LEFT OUTER JOIN tblDepartment on tblTransfer.Dep_id2 = tblDepartment.Dep_id " & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
            " where Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103)" & _
            " And tblStaff.Nationality = '" & CbNation.Text & "'" & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " group by TblTransfer.dep_id2,TblDepartment.Dep_Th"
        Else
            SqlStr = "select TblTransfer.dep_id2,TblDepartment.dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Sal_Debit," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Ot_Debit," & _
            "Sum(Incentive) as In_Debit," & _
            "Sum(TblTransfer.Pos_All) As Pos_Debit " & _
             "from tblTransfer LEFT OUTER JOIN tblDepartment on tblTransfer.Dep_id2 = tblDepartment.Dep_id " & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
             "where Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103)" & _
             " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
             "group by TblTransfer.dep_id2,TblDepartment.Dep_Th"
        End If
        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Trn1")
        If ds.Tables("Trn1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("Trn1").Rows.Count - 1
                SqlStr2 = "Select Dep_Id From TmpTran2 Where dep_id = '" & ds.Tables("Trn1").Rows(i).Item("dep_id2") & "'"
                da = New SqlDataAdapter(SqlStr2, Conn)
                da.Fill(ds, "Trn2")
                If ds.Tables("Trn2").Rows.Count <> 0 Then
                    SqlSave = "UPDATE TmpTran2 SET "
                    SqlSave &= "Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Dep_Id2") & "',"
                    SqlSave &= "Dep_Th = '" & ds.Tables("Trn1").Rows(i).Item("Dep_Th") & "',"
                    SqlSave &= "Sal_Debit = '" & ds.Tables("Trn1").Rows(i).Item("Sal_Debit") & "',"
                    SqlSave &= "Ot_Debit = '" & ds.Tables("Trn1").Rows(i).Item("Ot_Debit") & "',"
                    SqlSave &= "In_Debit = '" & ds.Tables("Trn1").Rows(i).Item("In_Debit") & "',"
                    SqlSave &= "Pos_Debit = '" & ds.Tables("Trn1").Rows(i).Item("Pos_Debit") & "'"
                    SqlSave &= " WHERE dep_id = '" & ds.Tables("Trn1").Rows(i).Item("dep_id2") & "'"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                Else
                    SqlSave = "INSERT INTO TmpTran2(Dep_Id,Dep_Th,Sal_Debit,Ot_Debit,In_Debit,Pos_Debit)"
                    SqlSave &= " VALUES('" & ds.Tables("Trn1").Rows(i).Item("Dep_Id2") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Dep_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Sal_Debit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Ot_Debit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("In_Debit") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Pos_Debit") & "')"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                End If
                ds.Tables("Trn2").Clear()
            Next
        End If
        ds.Tables("Trn1").Clear()

        SqlSave = "UPDATE TmpTran2 SET "
        SqlSave &= "Sal_Total = Sal_Debit-Sal_Credit,"
        SqlSave &= "Ot_Total = Ot_Debit-Ot_Credit,"
        SqlSave &= "In_Total = In_Debit-In_Credit,"
        SqlSave &= "Pos_Total = Pos_Debit-Pos_Credit"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub DateTimePicker2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbNation.Focus()
        End If
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        MakeTable1()

        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "แผนก"
        xlWorkSheet.Cells(1, 2).Value = "COST CENTER"
        xlWorkSheet.Cells(1, 3).Value = "ค่าแรง หัก"
        xlWorkSheet.Cells(1, 4).Value = "โอที หัก"
        xlWorkSheet.Cells(1, 5).Value = "ค่าตำแหน่ง หัก"
        xlWorkSheet.Cells(1, 6).Value = "Incentive หัก"

        xlWorkSheet.Cells(1, 7).Value = "ค่าแรง รับ"
        xlWorkSheet.Cells(1, 8).Value = "โอที รับ"
        xlWorkSheet.Cells(1, 9).Value = "ค่าตำแหน่ง รับ"
        xlWorkSheet.Cells(1, 10).Value = "Incentive รับ"

        xlWorkSheet.Cells(1, 11).Value = "ค่าแรง คงเหลือ"
        xlWorkSheet.Cells(1, 12).Value = "โอที คงเหลือ"
        xlWorkSheet.Cells(1, 13).Value = "ค่าตำแหน่ง คงเหลือ"
        xlWorkSheet.Cells(1, 14).Value = "Incentive คงเหลือ"


        Dim SqlString As String
        SqlString = "SELECT Dep_Id,Dep_Th,Sal_Credit,Ot_Credit,Pos_Credit,In_Credit," & _
        "Sal_Debit,Ot_Debit,Pos_Debit,In_Debit,Sal_Total,Ot_Total,Pos_Total,In_Total " & _
        " FROM TmpTran2 Order By Dep_Id"
        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 0 Or j = 1 Then
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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TmpTran2.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TmpTran2.xls")
    End Sub

    Private Sub CbDep_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbNation.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdPrt.Focus()
        End If
    End Sub

End Class