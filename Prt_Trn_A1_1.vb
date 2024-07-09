Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Prt_Trn_A1_1
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
        DateTimePicker3.Value = DateTimePicker1.Value
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

        CbDep_Id.Items.Clear()
        Dim sqlDep_Id As String
        sqlDep_Id = "SELECT * FROM tblDepartment WHERE Factory = '" & MFactory & "' Order By Dep_Id"
        da = New SqlDataAdapter(sqlDep_Id, Conn)
        da.Fill(ds, "Dep1")
        If ds.Tables("Dep1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Dep1").Rows.Count - 1
                CbDep_Id.Items.Add(ds.Tables("Dep1").Rows(i).Item("Dep_Id") & " " & _
                            ds.Tables("Dep1").Rows(i).Item("Dep_Th"))
            Next
        End If
        CbDep_Id.Text = ""
        ds.Tables("Dep1").Clear()
        Me.CenterToScreen()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'MakeTable1()

        Dim CRVA1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTA1 As New Form
        Dim RpTA1 As New Prt_Trn_A_1
        Dim MParamDate As String
        Dim MParamFactName, MParamFactAddr, MParamDep, MFormula As String
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTA1.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
                And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTA1.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTA1.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)

        MParamDate = "วันที่ " & DateTimePicker1.Text & " ถึง " & DateTimePicker2.Text & " "
        MFormula = "{tblTransFer.TrfDate} =  Date('" & DateTimePicker1.Text & _
        "') To Date('" & DateTimePicker2.Text & "') " & _
        " And {tblTransFer.Factory} = '" & MFactory & "' And {tblTransFer.FConfirm} = True"
        If CbDep_Id.Text <> "" Then
            MFormula = MFormula + " And {tblTransFer.Dep_Id} = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "'"
        End If

        'MsgBox(MFactory)


        MParamFactName = MFactName
        MParamFactAddr = MFactAddr
        MParamDep = CbDep_Id.Text

        With CRVA1
            .ReportSource = RpTA1
            .SelectionFormula = MFormula
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
        Dim SqlSave As String = " "

        SqlStr = "delete from TmpTran4"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With


        SqlStr = "insert into [TmpTran4]([Trfdate],[StId],[Title_th],[Fname_Th],[Lname_Th],[Sal],[Head_Id],[Head_Name],[Dep_Id],[Dep_Th]," & _
        "[Dep_Id2],[Recv],[TrfNo],[Time_Start],[Time_End],[Normal_Hr],[Normal_Ot],[Holiday_Ot],[Nm_M]," & _
        "[Ot_M],[Incentive],[Pos_All],[Tot_m]) " & _
        " SELECT tblTransfer.Trfdate,tblTransfer.StId,tblStaff.Title_th,tblTransfer.Fname_Th,tblTransfer.Lname_Th," & _
        "tblTransFer.Sal,tblTransFer.Head_Id,tblHead.Head_Name,tblTransfer.Dep_Id,TblDepartment.Dep_Th," & _
        "tblTransfer.Dep_Id2,TblDepartment_1.Dep_Th AS Recv,tblTransfer.TrfNo,tblTransfer.Time_Start," & _
        "tblTransfer.Time_End,tblTransfer.Normal_Hr,tblTransfer.Normal_Ot," & _
        "tblTransfer.Holiday_Ot," & _
        "case when Double_Pay = 1 then 2*tblTransfer.Normal_Hr*tblTransfer.sal/8 Else tblTransfer.Normal_Hr*tblTransfer.sal/8 End As Nm_M," & _
        "case when Double_Pay = 1 then 2*(tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5 Else (tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5 End As Ot_M," & _
        "0 As Incentive,tblTransfer.Pos_All," & _
        "case when Double_Pay = 1 then 2*(tblTransfer.Normal_Hr*tblTransfer.sal/8)+2*((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5)+tblTransfer.Pos_All Else (tblTransfer.Normal_Hr*tblTransfer.sal/8)+" & _
        "((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5)+tblTransfer.Pos_All End As Tot_m " & _
        " FROM tblTransfer LEFT OUTER JOIN" & _
        " TblStaff ON tblTransfer.StId = TblStaff.Stid LEFT OUTER JOIN" & _
        " TblHead ON tblTransfer.Head_id = TblHead.Head_Id LEFT OUTER JOIN " & _
        " TblDepartment AS TblDepartment_1 ON tblTransfer.Dep_Id2 = TblDepartment_1.Dep_Id LEFT OUTER JOIN " & _
        " TblDepartment ON tblTransfer.Dep_Id = TblDepartment.Dep_Id  " & _
        " where tblTransfer.Trfdate >= Convert(datetime,'" & DateTimePicker1.Text & "',103)" & _
        " And tblTransfer.Trfdate <= Convert(datetime,'" & DateTimePicker2.Text & "',103) " & _
        " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1"
        If CbDep_Id.Text <> "" Then
            SqlStr = SqlStr + " And tblTransfer.Dep_Id = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "'"
        End If
        SqlStr = SqlStr + " Order by tblTransfer.Trfdate,tblTransfer.Head_id,tblTransfer.TrfNo"

        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "delete from TmpTran41"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "insert into [TmpTran41]([Trfdate],[StId],[Title_th],[Fname_Th],[Lname_Th],[Sal],[Head_Id],[Head_Name],[Dep_Id],[Dep_Th]," & _
        "[Dep_Id2],[Recv],[TrfNo],[Time_Start],[Time_End],[Normal_Hr],[Normal_Ot],[Holiday_Ot],[Nm_M]," & _
        "[Ot_M],[Incentive],[Pos_All],[Tot_m])" & _
        " SELECT tblTransfer.Trfdate,tblTransfer.StId,tblStaff.Title_th,tblTransfer.Fname_Th,tblTransfer.Lname_Th," & _
        "tblTransFer.Sal,tblTransFer.Head_Id,tblHead.Head_Name,tblTransfer.Dep_Id,TblDepartment.Dep_Th," & _
        "tblTransfer.Dep_Id2,TblDepartment_1.Dep_Th AS Recv,tblTransfer.TrfNo,tblTransfer.Time_Start," & _
        "tblTransfer.Time_End,0 As Normal_Hr,0 As Normal_Ot," & _
        "0 As Holiday_Ot," & _
        "0 As Nm_M," & _
        "0 As Ot_M," & _
        "tblTransfer.Incentive As Incentive," & _
        "0 As Pos_All," & _
        "tblTransfer.Incentive As Tot_m " & _
        " FROM tblTransfer LEFT OUTER JOIN" & _
        " TblStaff ON tblTransfer.StId = TblStaff.Stid LEFT OUTER JOIN" & _
        " TblHead ON tblTransfer.Head_id = TblHead.Head_Id LEFT OUTER JOIN" & _
        " TblDepartment AS TblDepartment_1 ON tblTransfer.Dep_Id2 = TblDepartment_1.Dep_Id LEFT OUTER JOIN" & _
        " TblDepartment ON tblTransfer.Dep_Id = TblDepartment.Dep_Id " & _
        " where tblTransfer.Trfdate >= Convert(datetime,'" & DateTimePicker3.Text & "',103)" & _
        " And tblTransfer.Trfdate <= Convert(datetime,'" & DateTimePicker4.Text & "',103)" & _
        " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1"
        If CbDep_Id.Text <> "" Then
            SqlStr = SqlStr + " And tblTransfer.Dep_Id = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "'"
        End If
        SqlStr = SqlStr + " Order by tblTransfer.Trfdate,tblTransfer.Head_id,tblTransfer.TrfNo"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Update TmpTran4 set " & _
        "TmpTran4.Incentive = TmpTran41.Incentive," & _
        "TmpTran4.Tot_m = TmpTran4.Tot_m + TmpTran41.Incentive" & _
        " FROM TmpTran4 inner join TmpTran41" & _
        " On TmpTran4.StId = TmpTran41.StId and TmpTran4.TrfDate = TmpTran41.TrfDate"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "insert into [TmpTran4]([Trfdate],[StId],[Title_th],[Fname_Th],[Lname_Th],[Sal],[Head_Id],[Head_Name],[Dep_Id],[Dep_Th]," & _
         "[Dep_Id2],[Recv],[TrfNo],[Time_Start],[Time_End],[Normal_Hr],[Normal_Ot],[Holiday_Ot],[Nm_M]," & _
         "[Ot_M],[Incentive],[Pos_All],[Tot_m]) " & _
         " select * from TmpTran41 " & _
         " where TmpTran41.TrfDate  not in  (Select TrfDate from TmpTran4) "
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub DateTimePicker2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker3.Focus()
        End If
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        MakeTable1()

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "วันที่"
        xlWorkSheet.Cells(1, 2).Value = "รหัสพนักงาน"
        xlWorkSheet.Cells(1, 3).Value = "คำนำหน้าชื่อ"
        xlWorkSheet.Cells(1, 4).Value = "ชื่อ"
        xlWorkSheet.Cells(1, 5).Value = "นามสกุล"
        xlWorkSheet.Cells(1, 6).Value = "ค่าแรง/วัน"
        xlWorkSheet.Cells(1, 7).Value = "รหัสหัวหน้า"
        xlWorkSheet.Cells(1, 8).Value = "ชื่อหัวหน้า"
        xlWorkSheet.Cells(1, 9).Value = "รหัสต้นสังกัด"
        xlWorkSheet.Cells(1, 10).Value = "ชื่อต้นสังกัด"
        xlWorkSheet.Cells(1, 11).Value = "รหัสที่รับโอน"
        xlWorkSheet.Cells(1, 12).Value = "ชื่อที่รับโอน"
        xlWorkSheet.Cells(1, 13).Value = "ชุด"
        xlWorkSheet.Cells(1, 14).Value = "จากเวลา"
        xlWorkSheet.Cells(1, 15).Value = "ถึงเวลา"
        xlWorkSheet.Cells(1, 16).Value = "ชั่วโมงทำงาน"
        xlWorkSheet.Cells(1, 17).Value = "ชั่วโมงโอที"
        xlWorkSheet.Cells(1, 18).Value = "ชั่วโมงโอทีนักขัตถ์"
        xlWorkSheet.Cells(1, 19).Value = "ค่าแรงปกติ"
        xlWorkSheet.Cells(1, 20).Value = "ค่าโอที"
        xlWorkSheet.Cells(1, 21).Value = "Incentive"
        xlWorkSheet.Cells(1, 22).Value = "ค่าตำแหน่ง"
        xlWorkSheet.Cells(1, 23).Value = "รวมค่าแรง"

        '"tblTransfer.Normal_Hr*tblTransfer.sal/8 As Nm_M,(tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5 As Ot_M," & _
        '"tblTransfer.Incentive,(tblTransfer.Normal_Hr*tblTransfer.sal/8)+((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5)+tblTransfer.Incentive As Tot_m " & _

        Dim SqlString As String
        'SqlString = "SELECT tblTransfer.Trfdate,tblTransfer.StId,tblStaff.Title_th,tblTransfer.Fname_Th,tblTransfer.Lname_Th,tblTransFer.Sal,tblTransFer.Head_Id,tblHead.Head_Name,tblTransfer.Dep_Id,TblDepartment.Dep_Th," & _
        '"tblTransfer.Dep_Id2,TblDepartment_1.Dep_Th AS Recv,tblTransfer.TrfNo,tblTransfer.Time_Start,tblTransfer.Time_End,tblTransfer.Normal_Hr,tblTransfer.Normal_Ot," & _
        '"tblTransfer.Holiday_Ot," & _
        '"case when Double_Pay = 1 then 2*tblTransfer.Normal_Hr*tblTransfer.sal/8 Else tblTransfer.Normal_Hr*tblTransfer.sal/8 End As Nm_M," & _
        '"case when Double_Pay = 1 then 2*(tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5 Else (tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5 End As Ot_M,tblTransfer.Incentive,tblTransfer.Pos_All," & _
        '"case when Double_Pay = 1 then 2*(tblTransfer.Normal_Hr*tblTransfer.sal/8)+2*((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5)+tblTransfer.Incentive+tblTransfer.Pos_All Else (tblTransfer.Normal_Hr*tblTransfer.sal/8)+" & _
        ' "((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5)+tblTransfer.Incentive+tblTransfer.Pos_All End As Tot_m " & _
        ' " FROM tblTransfer LEFT OUTER JOIN" & _
        '" TblStaff ON tblTransfer.StId = TblStaff.Stid LEFT OUTER JOIN" & _
        '" TblHead ON tblTransfer.Head_id = TblHead.Head_Id LEFT OUTER JOIN" & _
        '" TblDepartment AS TblDepartment_1 ON tblTransfer.Dep_Id2 = TblDepartment_1.Dep_Id LEFT OUTER JOIN" & _
        '" TblDepartment ON tblTransfer.Dep_Id = TblDepartment.Dep_Id " & _
        '" where tblTransfer.Trfdate >= Convert(datetime,'" & DateTimePicker1.Text & "',103)" & _
        '" And tblTransfer.Trfdate <= Convert(datetime,'" & DateTimePicker2.Text & "',103)" & _
        '" And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1"

        'If CbDep_Id.Text <> "" Then
        'SqlString = SqlString + " And tblTransfer.Dep_Id = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "'"
        'End If
        'SqlString = SqlString + " Order by tblTransfer.Trfdate,tblTransfer.Head_id,tblTransfer.TrfNo"

        SqlString = "select [Trfdate],[StId],[Title_th],[Fname_Th],[Lname_Th],[Sal],[Head_Id],[Head_Name],[Dep_Id],[Dep_Th]," & _
        "[Dep_Id2],[Recv],[TrfNo],[Time_Start],[Time_End],[Normal_Hr],[Normal_Ot],[Holiday_Ot],[Nm_M]," & _
        "[Ot_M],[Incentive],[Pos_All],[Tot_m] from TmpTran4 Order by [TrfDate],[StId]"

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 1 Or j = 6 Or j = 8 Or j = 10 Then
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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\tblTransfer1.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\tblTransfer1.xls")
    End Sub

    Private Sub CbDep_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDep_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdPrt.Focus()
        End If
    End Sub

    Private Sub DateTimePicker3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker3.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker4.Focus()
        End If
    End Sub

    Private Sub DateTimePicker4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker4.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id.Focus()
        End If
    End Sub

    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged
        DateTimePicker4.Value = DateTimePicker2.Value
    End Sub
End Class