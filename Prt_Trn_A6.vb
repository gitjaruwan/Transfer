Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Prt_Trn_A6
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
        Dim RpTA1 As New Prt_Trn_A_6
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

        MParamDate = "งวด วันที่ " & DateTimePicker1.Text & " ถึง " & DateTimePicker2.Text & " รอบการตัดค่า INCENTIVE วันที่ " & _
        DateTimePicker3.Text & " ถึง " & DateTimePicker4.Text
        'MFormula = "{tblTransFer.TrfDate} =  Date('" & DateTimePicker1.Text & _
        '"') To Date('" & DateTimePicker2.Text & "') And {tblTransFer.Factory} = '" & MFactory & "' And {tblTransFer.FConfirm} = True"

        MParamFactName = MFactName
        MParamFactAddr = MFactAddr

        If Len(CbNation.Text) <> 0 Then
            MParamDep = "รายการสรุปค่าแรงโอนย้ายประจำวัน พนักงาน " & CbNation.Text
        Else
            MParamDep = "รายการสรุปค่าแรงโอนย้ายประจำวัน พนักงาน รายวัน-ต่างด้าว"
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

        SqlStr = "Delete from TmpTran3"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        If Len(CbNation.Text) <> 0 Then
            '"sum(Normal_Hr*tblTransfer.sal/8) As Debit_Sal," & _
            '"Sum((Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5) As Debit_Ot," & _
            '"Sum(tblTransfer.Pos_All) As Debit_Pos," & _
            '"Sum(Incentive) As Debit_Inc," & _
            '"Sum(Normal_Hr*tblTransfer.sal/8)+sum((Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5)+" & _
            '"sum(tblTransfer.Pos_All)+sum(Incentive) As Debit_Total," & _
            '"tblTransfer.Dep_Id,tblDepartment.Dep_Th," & _
            '"sum(Normal_Hr*tblTransfer.sal/8) As Credit_Sal," & _
            '"Sum((Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5) As Credit_Ot," & _
            '"Sum(tblTransfer.Pos_All) As Credit_Pos," & _
            '"Sum(Incentive) As Credit_Inc," & _
            '"Sum(Normal_Hr*tblTransfer.sal/8)+sum((Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5)+" & _
            '"sum(tblTransfer.Pos_All)+sum(Incentive) As Credit_Total" & _



            SqlSave = "insert into [TmpTran3]([Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos]," & _
            "[Debit_Inc],[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th]," & _
            "[Credit_Sal],[Credit_Ot],[Credit_Pos],[Credit_Inc],[Credit_Total]) " & _
            "select tblTransfer.Dep_Id2,tblDepartment_1.Dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 else Normal_Hr*tblTransfer.sal/8 End) As Debit_Sal," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Debit_Ot," & _
            "Sum(tblTransfer.Pos_All) As Debit_Pos," & _
            "Sum(Incentive) As Debit_Inc," & _
            "Sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End)" & _
            "+sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End)+" & _
            "sum(tblTransfer.Pos_All)+sum(Incentive) As Debit_Total," & _
            "tblTransfer.Dep_Id,tblDepartment.Dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Credit_Sal," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Credit_Ot," & _
            "Sum(tblTransfer.Pos_All) As Credit_Pos," & _
            "Sum(Incentive) As Credit_Inc," & _
            "Sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End)" & _
            "+sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End)+" & _
            "sum(tblTransfer.Pos_All)+sum(Incentive) As Credit_Total" & _
            " from tblTransfer " & _
            " left outer join tblDepartment on tblTransfer.Dep_Id = tblDepartment.Dep_Id" & _
            " left outer join tblDepartment As tblDepartment_1 on tblTransfer.Dep_Id2 = tblDepartment_1.Dep_Id" & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
            " where tblTransfer.Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and tblTransfer.Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103) " & _
            " And tblStaff.Nationality = '" & CbNation.Text & "'" & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " Group by tblTransfer.Dep_Id,tblDepartment.Dep_Th,tblTransfer.Dep_Id2, tblDepartment_1.Dep_Th"
        Else
            SqlSave = "insert into [TmpTran3]([Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos]," & _
            "[Debit_Inc],[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th]," & _
            "[Credit_Sal],[Credit_Ot],[Credit_Pos],[Credit_Inc],[Credit_Total]) " & _
            "select tblTransfer.Dep_Id2,tblDepartment_1.Dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 else Normal_Hr*tblTransfer.sal/8 End) As Debit_Sal," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Debit_Ot," & _
            "Sum(tblTransfer.Pos_All) As Debit_Pos," & _
            "Sum(Incentive) As Debit_Inc," & _
            "Sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End)" & _
            "+sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End)+" & _
            "sum(tblTransfer.Pos_All)+sum(Incentive) As Debit_Total," & _
            "tblTransfer.Dep_Id,tblDepartment.Dep_Th," & _
            "sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End) As Credit_Sal," & _
            "Sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End) As Credit_Ot," & _
            "Sum(tblTransfer.Pos_All) As Credit_Pos," & _
            "Sum(Incentive) As Credit_Inc," & _
            "Sum(case when Double_Pay = 1 then 2*Normal_Hr*tblTransfer.sal/8 Else Normal_Hr*tblTransfer.sal/8 End)" & _
            "+sum(case when Double_Pay = 1 then 2*(Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 Else (Normal_Ot+Holiday_Ot)*tblTransfer.sal/8*1.5 End)+" & _
            "sum(tblTransfer.Pos_All)+sum(Incentive) As Credit_Total" & _
            " from tblTransfer " & _
            " left outer join tblDepartment on tblTransfer.Dep_Id = tblDepartment.Dep_Id" & _
            " left outer join tblDepartment As tblDepartment_1 on tblTransfer.Dep_Id2 = tblDepartment_1.Dep_Id" & _
            " where tblTransfer.Trfdate >= convert (datetime,'" & DateTimePicker1.Text & "',103) and tblTransfer.Trfdate <= convert (datetime,'" & DateTimePicker2.Text & "',103) " & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " Group by tblTransfer.Dep_Id,tblDepartment.Dep_Th,tblTransfer.Dep_Id2, tblDepartment_1.Dep_Th"
        End If
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With


        SqlStr = "Delete from TmpTran31"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        If Len(CbNation.Text) <> 0 Then
            SqlSave = "insert into [TmpTran31]([Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos]," & _
            "[Debit_Inc],[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th]," & _
            "[Credit_Sal],[Credit_Ot],[Credit_Pos],[Credit_Inc],[Credit_Total]) " & _
            "select tblTransfer.Dep_Id2,tblDepartment_1.Dep_Th," & _
            "0," & _
            "0," & _
            "0," & _
            "Sum(Incentive) As Debit_Inc," & _
            "0," & _
            "tblTransfer.Dep_Id,tblDepartment.Dep_Th," & _
            "0," & _
            "0," & _
            "0," & _
            "Sum(Incentive) As Credit_Inc," & _
            "0" & _
            " from tblTransfer " & _
            " left outer join tblDepartment on tblTransfer.Dep_Id = tblDepartment.Dep_Id" & _
            " left outer join tblDepartment As tblDepartment_1 on tblTransfer.Dep_Id2 = tblDepartment_1.Dep_Id" & _
            " LEFT OUTER JOIN tblStaff on tblTransfer.Stid = tblStaff.Stid " & _
            " where tblTransfer.Trfdate >= convert (datetime,'" & DateTimePicker3.Text & "',103) and tblTransfer.Trfdate <= convert (datetime,'" & DateTimePicker4.Text & "',103) " & _
            " And tblStaff.Nationality = '" & CbNation.Text & "'" & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " Group by tblTransfer.Dep_Id,tblDepartment.Dep_Th,tblTransfer.Dep_Id2, tblDepartment_1.Dep_Th"
        Else
            SqlSave = "insert into [TmpTran31]([Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos]," & _
            "[Debit_Inc],[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th]," & _
            "[Credit_Sal],[Credit_Ot],[Credit_Pos],[Credit_Inc],[Credit_Total]) " & _
            "select tblTransfer.Dep_Id2,tblDepartment_1.Dep_Th," & _
            "0," & _
            "0," & _
            "0," & _
            "Sum(Incentive) As Debit_Inc," & _
            "0," & _
            "tblTransfer.Dep_Id,tblDepartment.Dep_Th," & _
            "0," & _
            "0," & _
            "0," & _
            "Sum(Incentive) As Credit_Inc," & _
            "0" & _
            " from tblTransfer " & _
            " left outer join tblDepartment on tblTransfer.Dep_Id = tblDepartment.Dep_Id" & _
            " left outer join tblDepartment As tblDepartment_1 on tblTransfer.Dep_Id2 = tblDepartment_1.Dep_Id" & _
            " where tblTransfer.Trfdate >= convert (datetime,'" & DateTimePicker3.Text & "',103) and tblTransfer.Trfdate <= convert (datetime,'" & DateTimePicker4.Text & "',103) " & _
            " And tblTransfer.Factory = '" & MFactory & "' And FConfirm = 1" & _
            " Group by tblTransfer.Dep_Id,tblDepartment.Dep_Th,tblTransfer.Dep_Id2, tblDepartment_1.Dep_Th"
        End If
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

        SqlSave = "UPDATE TmpTran3 SET "
        SqlSave &= "Debit_Inc = 0,"
        SqlSave &= "Credit_Inc = 0"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With


        SqlStr = "Select * from TmpTran31"
        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Trn1")
        If ds.Tables("Trn1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("Trn1").Rows.Count - 1

                SqlStr2 = "Select Debit_Dep_Id From TmpTran3 Where Debit_Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Debit_Dep_Id") & _
                           "' And Credit_Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Credit_Dep_Id") & "'"
                da = New SqlDataAdapter(SqlStr2, Conn)
                da.Fill(ds, "Trn2")
                If ds.Tables("Trn2").Rows.Count <> 0 Then
                    SqlSave = "UPDATE TmpTran3 SET "
                    SqlSave &= "Debit_Inc = '" & ds.Tables("Trn1").Rows(i).Item("Debit_Inc") & "',"
                    SqlSave &= "Credit_Inc = '" & ds.Tables("Trn1").Rows(i).Item("Credit_Inc") & "'"
                    SqlSave &= " WHERE Debit_Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Debit_Dep_Id") & _
                           "' And Credit_Dep_Id = '" & ds.Tables("Trn1").Rows(i).Item("Credit_Dep_Id") & "'"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                Else
                    SqlSave = "insert into [TmpTran3]([Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos],"
                    SqlSave &= "[Debit_Inc],[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th],"
                    SqlSave &= "[Credit_Sal],[Credit_Ot],[Credit_Pos],[Credit_Inc],[Credit_Total]) "
                    SqlSave &= " VALUES('" & ds.Tables("Trn1").Rows(i).Item("Debit_Dep_Id") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Dep_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Sal") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Ot") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Pos") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Inc") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Debit_Total") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Dep_Id") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Dep_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Sal") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Ot") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Pos") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Inc") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Credit_Total") & "')"
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
        'Round OT 2 digit
        SqlSave = "UPDATE TmpTran3 SET "
        SqlSave &= "[Debit_Ot] = Round([Debit_Ot],2),"
        SqlSave &= "[Credit_Ot] = Round([Credit_Ot],2)"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

        'Resum Debit_Total,ComSave
        SqlSave = "UPDATE TmpTran3 SET "
        SqlSave &= "[Debit_Total] =[Debit_Sal]+[Debit_Ot]+[Debit_Pos]+[Debit_Inc],"
        SqlSave &= "[Credit_Total] = [Credit_Sal]+[Credit_Ot]+[Credit_Pos]+[Credit_Inc]"
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
            DateTimePicker3.Focus()
        End If
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        MakeTable1()

        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "TmpTran3"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "รหัสส่วนงานรับโอนย้าย"
        xlWorkSheet.Cells(1, 2).Value = "ชื่อส่วนงานรับโอนย้าย"
        xlWorkSheet.Cells(1, 3).Value = "ค่าแรง"
        xlWorkSheet.Cells(1, 4).Value = "OT"
        xlWorkSheet.Cells(1, 5).Value = "ค่าตำแหน่ง"
        xlWorkSheet.Cells(1, 6).Value = "INC."
        xlWorkSheet.Cells(1, 7).Value = "TOTAL"
        xlWorkSheet.Cells(1, 8).Value = "รหัสส่วนงานโอนย้าย"
        xlWorkSheet.Cells(1, 9).Value = "ชื่อส่วนงานโอนย้าย"
        xlWorkSheet.Cells(1, 10).Value = "ค่าแรง"
        xlWorkSheet.Cells(1, 11).Value = "OT"
        xlWorkSheet.Cells(1, 12).Value = "ค่าตำแหน่ง"
        xlWorkSheet.Cells(1, 13).Value = "INC."
        xlWorkSheet.Cells(1, 14).Value = "TOTAL"


        Dim SqlString As String
        SqlString = "select [Debit_Dep_Id],[Debit_Dep_Th],[Debit_Sal],[Debit_Ot],[Debit_Pos],[Debit_Inc]," & _
        "[Debit_Total],[Credit_Dep_Id],[Credit_Dep_Th],[Credit_Sal],[Credit_Ot]," & _
        "[Credit_Pos], [Credit_Inc], [Credit_Total]" & _
        " from [TmpTran3] Order By Debit_Dep_Id,Credit_Dep_Id"
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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TmpTran3.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TmpTran3.xls")
    End Sub

    Private Sub CbDep_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbNation.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdPrt.Focus()
        End If
    End Sub

    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged
        DateTimePicker4.Value = DateTimePicker2.Value
    End Sub

    Private Sub DateTimePicker3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker3.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker4.Focus()
        End If
    End Sub

    Private Sub DateTimePicker4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker4.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbNation.Focus()
        End If
    End Sub
End Class