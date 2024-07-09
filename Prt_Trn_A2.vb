Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Prt_Trn_A2
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim CommImp As New SqlCommand
    Dim ComSave As New SqlCommand
    Dim Date1 As DateTime
    Dim Date2 As DateTime
    Dim XDep_Id(25) As String
    Dim XLast As Integer = 1
    Dim FileNm1 As String
    Dim FileNm2 As String
    Dim FileNm3 As String
    Dim FileNm4 As String
    Dim TOvwr As Boolean = True

    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePicker2.Focus()
        End If
    End Sub

    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        DateTimePicker2.Value = DateTimePicker1.Value
    End Sub

    Private Sub Prt_Pay_N1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DateTimePicker1.Focus()
    End Sub

    Private Sub Prt_Trn_A2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub MakeTable1()
        Dim SqlStr As String
        Dim SqlStr2 As String = " "
        Dim SqlSave As String = " "
        Dim xCount As Integer = 1

        SqlStr = "Delete from TmpTran1"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "select StId,title_th,FName_th,LName_Th,Dep_Id,Sal,sum(H_Normal) as Nm_Hr,Sum(H_Ot) As Nm_Ot" & _
        " from tblHome " & _
        " where T_Date >= Convert(datetime,'" & DateTimePicker1.Text & "',103) and " & _
        " T_Date <= Convert(datetime,'" & DateTimePicker2.Text & "',103) And " & _
        " dep_id='" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "' and Factory = '" & MFactory & "'" & _
        " Group By StId,title_th,FName_th,LName_Th,Dep_Id,Sal"

        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Trn1")
        If ds.Tables("Trn1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("Trn1").Rows.Count - 1
                SqlStr2 = "Select StId From TmpTran1 Where StId = '" & ds.Tables("Trn1").Rows(i).Item("StId") & "'"
                da = New SqlDataAdapter(SqlStr2, Conn)
                da.Fill(ds, "Trn2")
                If ds.Tables("Trn2").Rows.Count <> 0 Then
                    SqlSave = "UPDATE TmpTran1 SET "
                    SqlSave &= "Nm_H0 = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Hr") & "',"
                    SqlSave &= "Ot_H0 = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Ot") & "',"
                    SqlSave &= "Ot_E0 = '0',"
                    SqlSave &= "Nm_M0 = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) & "',"
                    SqlSave &= "Ot_M0 = '" & (ds.Tables("Trn1").Rows(i).Item("Nm_Ot")) * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) * 1.5 & "',"
                    SqlSave &= "In_M0 = '0',"
                    SqlSave &= "To_M0 = '" & (ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8)) + ((ds.Tables("Trn1").Rows(i).Item("Nm_Ot")) * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) * 1.5) & "'"
                    SqlSave &= " WHERE Stid = '" & ds.Tables("Trn1").Rows(i).Item("StId") & "'"
                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                Else
                    SqlSave = "INSERT INTO TmpTran1(StId,Title_Th,FName_Th,LName_Th,Sal,Nm_H0,Ot_H0,Ot_E0,Nm_M0,Ot_M0,In_M0,To_M0)"
                    SqlSave &= " VALUES('" & ds.Tables("Trn1").Rows(i).Item("StId") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Title_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("FName_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("LName_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Sal") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Hr") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Ot") & "','"
                    SqlSave &= "0','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) & "','"
                    SqlSave &= (ds.Tables("Trn1").Rows(i).Item("Nm_Ot")) * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) * 1.5 & "','"
                    SqlSave &= "0','"
                    SqlSave &= (ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8)) + ((ds.Tables("Trn1").Rows(i).Item("Nm_Ot")) * (ds.Tables("Trn1").Rows(i).Item("Sal") / 8) * 1.5) & "')"

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
    End Sub

    Private Sub MakeTable2()
        Dim SqlStr As String
        Dim SqlStr2 As String = " "
        Dim SqlSave As String = " "
        Dim xCount As Integer = 1


        SqlStr = "select StId,title_th,FName_th,LName_Th," & _
                 "Dep_Id2,sal,sum(Normal_Hr) as Nm_Hr,Sum(Normal_Ot) As Nm_Ot,Sum(Holiday_Ot) As Ex_Ot," & _
                 "Sum(Incentive) As In_m " & _
                 " from tblTransFer " & _
                 " where TrfDate >= Convert(datetime,'" & DateTimePicker1.Text & "',103) " & _
                 "and TrfDate <= Convert(datetime,'" & DateTimePicker2.Text & "',103)" & _
                 " And Dep_Id = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "'" & _
                 " And Factory = '" & MFactory & "' And FConfirm = 1" & _
                 " Group By StId,title_th,FName_th,LName_Th,Dep_Id2,Sal"
        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Trn1")
        If ds.Tables("Trn1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("Trn1").Rows.Count - 1

                If ds.Tables("Trn1").Rows(i).Item("Dep_Id2") <> XDep_Id(xCount) Then
                    xCount = xCount + 1
                    XDep_Id(xCount) = ds.Tables("Trn1").Rows(i).Item("Dep_Id2")
                End If

                'MsgBox(ds.Tables("Trn1").Rows(i).Item("StId"))
                SqlStr2 = "Select StId From TmpTran1 Where StId = '" & ds.Tables("Trn1").Rows(i).Item("StId") & "'"
                da = New SqlDataAdapter(SqlStr2, Conn)
                da.Fill(ds, "Trn2")
                If ds.Tables("Trn2").Rows.Count <> 0 Then
                    SqlSave = "UPDATE TmpTran1 SET "
                    SqlSave &= "Nm_H" & CStr(xCount) & " = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Hr") & "',"
                    SqlSave &= "Ot_H" & CStr(xCount) & " = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Ot") & "',"
                    SqlSave &= "Ot_E" & CStr(xCount) & " = '" & ds.Tables("Trn1").Rows(i).Item("Ex_Ot") & "',"
                    SqlSave &= "Nm_M" & CStr(xCount) & " = '" & ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) & "',"
                    SqlSave &= "Ot_M" & CStr(xCount) & " = '" & (ds.Tables("Trn1").Rows(i).Item("Nm_Ot") + ds.Tables("Trn1").Rows(i).Item("Ex_Ot")) * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) * 1.5 & "',"
                    SqlSave &= "In_M" & CStr(xCount) & " = '" & ds.Tables("Trn1").Rows(i).Item("In_m") & "',"
                    SqlSave &= "To_M" & CStr(xCount) & " = '" & (ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2)) + ((ds.Tables("Trn1").Rows(i).Item("Nm_Ot") + ds.Tables("Trn1").Rows(i).Item("Ex_Ot")) * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) * 1.5) + ds.Tables("Trn1").Rows(i).Item("In_m") & "'"
                    SqlSave &= " WHERE Stid = '" & ds.Tables("Trn1").Rows(i).Item("StId") & "'"

                    With ComSave
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "Set DateFormat 'DMY'"
                        .ExecuteNonQuery()
                        .CommandText = SqlSave
                        .ExecuteNonQuery()
                    End With
                Else
                    xCount = 1
                    XDep_Id(xCount) = ds.Tables("Trn1").Rows(i).Item("Dep_Id2")
                    SqlSave = "INSERT INTO TmpTran1(StId,Title_Th,FName_Th,LName_Th,Sal,Nm_H1,Ot_H1,Ot_E1,Nm_M1,Ot_M1,In_M1,To_M1)"
                    SqlSave &= " VALUES('" & ds.Tables("Trn1").Rows(i).Item("StId") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Title_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("FName_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("LName_Th") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Sal") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Hr") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Ot") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Ex_Ot") & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) & "','"
                    SqlSave &= (ds.Tables("Trn1").Rows(i).Item("Nm_Ot") + ds.Tables("Trn1").Rows(i).Item("Ex_Ot")) * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) * 1.5 & "','"
                    SqlSave &= ds.Tables("Trn1").Rows(i).Item("In_m") & "','"
                    SqlSave &= (ds.Tables("Trn1").Rows(i).Item("Nm_Hr") * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) + (ds.Tables("Trn1").Rows(i).Item("Nm_Ot") + ds.Tables("Trn1").Rows(i).Item("Ex_Ot")) * Math.Round(ds.Tables("Trn1").Rows(i).Item("Sal") / 8, 2) * 1.5) + ds.Tables("Trn1").Rows(i).Item("In_m")
                    SqlSave &= "')"

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
                If xCount > XLast Then
                    XLast = xCount
                End If
            Next
        End If
        ds.Tables("Trn1").Clear()
    End Sub

    Private Sub CalHome_Hour()
        'Dim SqlStr As String
        'SqlStr = "Update TmpTran1 Set "
        'SqlStr &= "Nm_H0=Nm_H0-Nm_H1-Nm_H2-Nm_H3-Nm_H4-Nm_H5-Nm_H6-Nm_H7-Nm_H8-Nm_H9-Nm_H10-Nm_H11-Nm_H12-Nm_H13-Nm_H14-Nm_H15-Nm_H16-Nm_H17-Nm_H18-Nm_H19-Nm_H20-Nm_H21-Nm_H22-Nm_H23-Nm_H24-Nm_H25,"
        'SqlStr &= "Ot_H0=Ot_H0-Ot_H1-Ot_H2-Ot_H3-Ot_H4-Ot_H5-Ot_H6-Ot_H7-Ot_H8-Ot_H9-Ot_H10-Ot_H11-Ot_H12-Ot_H13-Ot_H14-Ot_H15-Ot_H16-Ot_H17-Ot_H18-Ot_H19-Ot_H20-Ot_H21-Ot_H22-Ot_H23-Ot_H24-Ot_H25,"
        'SqlStr &= "Ot_E0=Ot_E0-Ot_E1-Ot_E2-Ot_E3-Ot_E4-Ot_E5-Ot_E6-Ot_E7-Ot_E8-Ot_E9-Ot_E10-Ot_E11-Ot_E12-Ot_E13-Ot_E14-Ot_E15-Ot_E16-Ot_E17-Ot_E18-Ot_E19-Ot_E20-Ot_E21-Ot_E22-Ot_E23-Ot_E24-Ot_E25,"
        'SqlStr &= "Nm_M0=Nm_M0-Nm_M1-Nm_M2-Nm_M3-Nm_M4-Nm_M5-Nm_M6-Nm_M7-Nm_M8-Nm_M9-Nm_M10-Nm_M11-Nm_M12-Nm_M13-Nm_M14-Nm_M15-Nm_M16-Nm_M17-Nm_M18-Nm_M19-Nm_M20-Nm_M21-Nm_M22-Nm_M23-Nm_M24-Nm_M25,"
        'SqlStr &= "Ot_M0=Ot_M0-Ot_M1-Ot_M2-Ot_M3-Ot_M4-Ot_M5-Ot_M6-Ot_M7-Ot_M8-Ot_M9-Ot_M10-Ot_M11-Ot_M12-Ot_M13-Ot_M14-Ot_M15-Ot_M16-Ot_M17-Ot_M18-Ot_M19-Ot_M20-Ot_M21-Ot_M22-Ot_M23-Ot_M24-Ot_M25,"
        'SqlStr &= "In_M0=In_M0-In_M1-In_M2-In_M3-In_M4-In_M5-In_M6-In_M7-In_M8-In_M9-In_M10-In_M11-In_M12-In_M13-In_M14-In_M15-In_M16-In_M17-In_M18-In_M19-In_M20-In_M21-In_M22-In_M23-In_M24-In_M25,"
        'SqlStr &= "To_M0=To_M0-To_M1-To_M2-To_M3-To_M4-To_M5-To_M6-To_M7-To_M8-To_M9-To_M10-To_M11-To_M12-To_M13-To_M14-To_M15-To_M16-To_M17-To_M18-To_M19-To_M20-To_M21-To_M22-To_M23-To_M24-To_M25"
        'With ComSave
        '.CommandType = CommandType.Text
        '.Connection = Conn
        '.CommandText = "Set DateFormat 'DMY'"
        '.ExecuteNonQuery()
        '.CommandText = SqlStr
        '.ExecuteNonQuery()
        'End With


    End Sub

    Private Sub DateTimePicker2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id.Focus()
        End If
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim SqlStr As String
        SqlStr = "Delete from TmpTran1"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        'MakeTable1()
        MakeTable2()
        'CalHome_Hour()

        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Transfer1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "ค่าแรง Cost Center No. " & CbDep_Id.Text
        xlWorkSheet.Cells(2, 1).Value = "ระหว่างวันที่ " & DateTimePicker1.Text & " - " & DateTimePicker2.Text

        xlWorkSheet.Cells(3, 1).Value = "รหัส"
        xlWorkSheet.Cells(3, 2).Value = "คำนำหน้าชื่อ"
        xlWorkSheet.Cells(3, 3).Value = "ชื่อ"
        xlWorkSheet.Cells(3, 4).Value = "นามสกุล"
        xlWorkSheet.Cells(3, 5).Value = "ค่าแรง/วัน"
        xlWorkSheet.Cells(3, 6).Value = "ค่าแรง/ชม."


        'xlWorkSheet.Cells(3, 7).Value = Microsoft.VisualBasic.Left(CbDep_Id.Text, 6)
        'xlWorkSheet.Cells(3, 8).Value = Microsoft.VisualBasic.Mid(CbDep_Id.Text, 7, 70)

        'xlWorkSheet.Cells(4, 7).Value = "ชั่วโมงทำงาน"
        'xlWorkSheet.Cells(4, 8).Value = "ชม.OT ปกติ"
        'xlWorkSheet.Cells(4, 9).Value = "ชม.OT พิเศษ"
        'xlWorkSheet.Cells(4, 10).Value = "ค่าแรง"
        'xlWorkSheet.Cells(4, 11).Value = "OT"
        'xlWorkSheet.Cells(4, 12).Value = "Incentive"
        'xlWorkSheet.Cells(4, 13).Value = "รวม"

        Dim j As Integer = 7 '14
        For i = 1 To XLast
            Dim sqlFact As String
            'IsFindEmp = True
            sqlFact = "SELECT * FROM TblDepartment WHERE Dep_Id = '" & XDep_Id(i) & "' And Factory = '" & MFactory & "'"
            da = New SqlDataAdapter(sqlFact, Conn)
            da.Fill(ds, "Fact1")
            If ds.Tables("Fact1").Rows.Count <> 0 Then
                xlWorkSheet.Cells(3, j).Value = XDep_Id(i)
                xlWorkSheet.Cells(3, j + 1).Value = CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Th"))
            End If
            ds.Tables("Fact1").Clear()
            j = j + 7
        Next



        j = 7 '14
        For i = 1 To XLast
            xlWorkSheet.Cells(4, j).Value = "ชั่วโมงทำงาน"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ชม.OT ปกติ"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ชม.OT พิเศษ"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ค่าแรง"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "OT"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "Incentive"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "รวม"
            j = j + 1
        Next

        Dim SqlString As String
        SqlString = "SELECT StId, Title_Th, FName_Th, LName_Th, Sal, round(Sal / 8,2) AS PerDay,"
        For i = 1 To XLast
            SqlString = SqlString + "Nm_H" & CStr(i) & ","
            SqlString = SqlString + "Ot_H" & CStr(i) & ","
            SqlString = SqlString + "Ot_E" & CStr(i) & ","
            SqlString = SqlString + "Nm_M" & CStr(i) & ","
            SqlString = SqlString + "Ot_M" & CStr(i) & ","
            SqlString = SqlString + "In_M" & CStr(i) & ","
            If i = XLast Then
                SqlString = SqlString + "To_M" & CStr(i)
            Else
                SqlString = SqlString + "To_M" & CStr(i) & ","
            End If
        Next

        SqlString = SqlString + " FROM dbo.TmpTran1"

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 0 Then
                        xlWorkSheet.Cells(i + 5, j + 1) = "'" & ds.Tables("DataSet1").Rows(i).Item(j)
                    Else
                        xlWorkSheet.Cells(i + 5, j + 1) = ds.Tables("DataSet1").Rows(i).Item(j)
                    End If
                Next
            Next
        End If
        ds.Tables("DataSet1").Clear()
        xlWorkSheet.Columns.AutoFit()

        xlApp.DisplayAlerts = False
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TransFer1.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TransFer1.xls")
        Me.Close()
    End Sub

    Private Sub CbDep_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDep_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdExcel.Focus()
        End If
    End Sub


    Private Sub CmdPrt_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'MakeTable1()

        'Dim CRVA1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        'Dim FrmPrTA1 As New Form
        'Dim RpTA1 As New Prt_Trn_A_1
        'Dim MParamDate, MFormula As String
        'Dim connection1 As IConnectionInfo
        'For Each connection1 In RpTA1.DataSourceConnections
        'If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
        '    And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
        'RpTA1.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
        'MServer, MDataBase, MUserID, MPassWord)
        'End If
        'Next
        'RpTA1.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)
        'MParamDate = "วันที่ " & DateTimePicker1.Text & " ถึง " & DateTimePicker2.Text & " "
        'MFormula = "{tblTransFer.TrfDate} =  Date('" & DateTimePicker1.Text & _
        '"') To Date('" & DateTimePicker2.Text & "')"

        'With CRVA1
        '.ReportSource = RpTA1
        '.SelectionFormula = MFormula
        '.ParameterFieldInfo(0).CurrentValues.AddValue(MParamDate)
        '.DisplayGroupTree = False
        '.Zoom(100)
        '.Width = FrmMain.Width - 10 '1000
        '.Height = FrmMain.Height - 30 '700
        '.Left = 0
        '.Top = 0
        'End With

        'With FrmPrTA1
        '.MdiParent = FrmMain
        '.Controls.Add(CRVA1)
        '.WindowState = FormWindowState.Maximized
        '.Show()
        'End With
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Close()
    End Sub


    Private Sub CmdExcel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel2.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim SqlStr As String
        SqlStr = "Delete from TmpTran1"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        MakeTable1()
        MakeTable2()
        'CalHome_Hour()

        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Transfer1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "ค่าแรง Cost Center No. " & CbDep_Id.Text
        xlWorkSheet.Cells(2, 1).Value = "ระหว่างวันที่ " & DateTimePicker1.Text & " - " & DateTimePicker2.Text

        xlWorkSheet.Cells(3, 1).Value = "รหัส"
        xlWorkSheet.Cells(3, 2).Value = "คำนำหน้าชื่อ"
        xlWorkSheet.Cells(3, 3).Value = "ชื่อ"
        xlWorkSheet.Cells(3, 4).Value = "นามสกุล"
        xlWorkSheet.Cells(3, 5).Value = "ค่าแรง/วัน"
        xlWorkSheet.Cells(3, 6).Value = "ค่าแรง/ชม."


        xlWorkSheet.Cells(3, 7).Value = Microsoft.VisualBasic.Left(CbDep_Id.Text, 6)
        xlWorkSheet.Cells(3, 8).Value = Microsoft.VisualBasic.Mid(CbDep_Id.Text, 7, 70)

        xlWorkSheet.Cells(4, 7).Value = "ชั่วโมงทำงาน"
        xlWorkSheet.Cells(4, 8).Value = "ชม.OT ปกติ"
        xlWorkSheet.Cells(4, 9).Value = "ชม.OT พิเศษ"
        xlWorkSheet.Cells(4, 10).Value = "ค่าแรง"
        xlWorkSheet.Cells(4, 11).Value = "OT"
        xlWorkSheet.Cells(4, 12).Value = "Incentive"
        xlWorkSheet.Cells(4, 13).Value = "รวม"

        Dim j As Integer = 14
        For i = 1 To XLast
            Dim sqlFact As String
            'IsFindEmp = True
            sqlFact = "SELECT * FROM TblDepartment WHERE Dep_Id = '" & XDep_Id(i) & "' And Factory = '" & MFactory & "'"
            da = New SqlDataAdapter(sqlFact, Conn)
            da.Fill(ds, "Fact1")
            If ds.Tables("Fact1").Rows.Count <> 0 Then
                xlWorkSheet.Cells(3, j).Value = XDep_Id(i)
                xlWorkSheet.Cells(3, j + 1).Value = CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Th"))
            End If
            ds.Tables("Fact1").Clear()
            j = j + 7
        Next



        j = 14
        For i = 1 To XLast
            xlWorkSheet.Cells(4, j).Value = "ชั่วโมงทำงาน"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ชม.OT ปกติ"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ชม.OT พิเศษ"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "ค่าแรง"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "OT"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "Incentive"
            j = j + 1
            xlWorkSheet.Cells(4, j).Value = "รวม"
            j = j + 1
        Next

        Dim SqlString As String
        SqlString = "SELECT StId, Title_Th, FName_Th, LName_Th, Sal, round(Sal / 8,2) AS PerDay,"
        For i = 0 To XLast
            SqlString = SqlString + "Nm_H" & CStr(i) & ","
            SqlString = SqlString + "Ot_H" & CStr(i) & ","
            SqlString = SqlString + "Ot_E" & CStr(i) & ","
            SqlString = SqlString + "Nm_M" & CStr(i) & ","
            SqlString = SqlString + "Ot_M" & CStr(i) & ","
            SqlString = SqlString + "In_M" & CStr(i) & ","
            If i = XLast Then
                SqlString = SqlString + "To_M" & CStr(i)
            Else
                SqlString = SqlString + "To_M" & CStr(i) & ","
            End If
        Next

        SqlString = SqlString + " FROM dbo.TmpTran1"

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 0 Then
                        xlWorkSheet.Cells(i + 5, j + 1) = "'" & ds.Tables("DataSet1").Rows(i).Item(j)
                    Else
                        xlWorkSheet.Cells(i + 5, j + 1) = ds.Tables("DataSet1").Rows(i).Item(j)
                    End If
                Next
            Next
        End If
        ds.Tables("DataSet1").Clear()
        xlWorkSheet.Columns.AutoFit()

        xlApp.DisplayAlerts = False
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TransFer1.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TransFer1.xls")
        Me.Close()
    End Sub
End Class