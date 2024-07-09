Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Transfer
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim CommImp As New SqlCommand
    Dim ComSave As New SqlCommand
    Dim Date1 As DateTime
    Dim Date2 As DateTime
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
        DateTimePicker1.Value = Now.Date
        DateTimePicker2.Value = DateTimePicker1.Value

        Me.CenterToScreen()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        'Check Old Exist Data
        Dim SqlTime2 As String
        Dim SqlLog As String
        SqlTime2 = "Select * From tblHome where t_date = Convert(datetime,'" & DateTimePicker1.Value & "',103) "
        da = New SqlDataAdapter(SqlTime2, Conn)
        da.Fill(ds, "Time2")
        If ds.Tables("Time2").Rows.Count <> 0 Then
            ds.Tables("Time2").Clear()
            'If MessageBox.Show("มีข้อมูลเวลาเก่าวันที่ " & DateTimePicker1.Text & " อยู่แล้ว จะสร้างทับหรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Dim Message As String = "มีข้อมูลเวลาเก่าวันที่ " & DateTimePicker1.Text & " อยู่แล้ว จะสร้างใหม่ทับหรือไม่ ?"
            Dim Caption As String = "ยืนยัน"
            Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNoCancel
            Dim Result As DialogResult
            Result = MessageBox.Show(Message, Caption, Buttons)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                TOvwr = True
            End If
            If Result = System.Windows.Forms.DialogResult.No Then
                TOvwr = False
            End If
            If Result = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            ds.Tables("Time2").Clear()
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.Refresh()

        'Loop Day
        Date1 = DateTimePicker1.Value
        Do While Date1 <= DateTimePicker2.Value
            Date2 = DateAdd(DateInterval.Day, 1, Date1)
            FileNm1 = IIf(Len(Date1.Day.ToString) = 1, "0" + Date1.Day.ToString, Date1.Day) & _
                      MonthName(Date1.Month, True) & Microsoft.VisualBasic.Right(Date1.Year, 2)
            FileNm2 = IIf(Len(Date2.Day.ToString) = 1, "0" + Date2.Day.ToString, Date2.Day) & _
                      MonthName(Date2.Month, True) & Microsoft.VisualBasic.Right(Date2.Year, 2)
            FileNm3 = Microsoft.VisualBasic.Right(Date1, 2) & _
                      Microsoft.VisualBasic.Mid(Date1, 4, 2) & Microsoft.VisualBasic.Left(Date1, 2)
            FileNm4 = Microsoft.VisualBasic.Right(Date2, 2) & _
                  Microsoft.VisualBasic.Mid(Date2, 4, 2) & Microsoft.VisualBasic.Left(Date2, 2)
            'MsgBox(XId)
            Label4.Text = "Loading.." & Date1
            Label4.Refresh()
            LoadData1()
            Date1 = DateAdd(DateInterval.Day, 1, Date1)
            Me.Refresh()
        Loop
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        SqlLog = "สร้างข้อมูลเวลา วันที่ " & DateTimePicker1.Text & " ถึง " & DateTimePicker2.Text
        SaveLog(SqlLog)

    End Sub

    Private Sub DateTimePicker2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdOk.Focus()
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

    Private Sub LoadData1()
        'MTimePath = "\\192.168.103.220\TimeFle\trtime\140401.dat"
        Dim SqlStr As String
        SqlStr = "Delete from Data"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandTimeout = 0
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        SqlStr = "Delete from Data2"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        With CommImp
            .CommandText = "Drop_Table"
            .Parameters.Clear()
            .Parameters.Add("@TableNm", SqlDbType.VarChar)
            .Parameters("@TableNm").Value = "data1"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With
        With CommImp
            .CommandText = "Drop_Table"
            .Parameters.Clear()
            .Parameters.Add("@TableNm", SqlDbType.VarChar)
            .Parameters("@TableNm").Value = "data3"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With

        SqlStr = "Delete from tblTime"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        ProgressBar1.Visible = True
        If Dir(MTimePath3 & FileNm1 & ".TAF") <> "" Then
            File.Copy(MTimePath3 & FileNm1 & ".TAF", MTimePath & FileNm1 & ".TAF", True)
            Label4.Text = MTimePath & FileNm1 & ".TAF"
            ProgressBar1.Value = 0
            ImportD1()
        End If
        If Dir(MTimePath3 & FileNm2 & ".TAF") <> "" Then
            File.Copy(MTimePath3 & FileNm2 & ".TAF", MTimePath & FileNm2 & ".TAF", True)
            Label4.Text = MTimePath & FileNm2 & ".TAF"
            ProgressBar1.Value = 12
            ImportD2()
        End If
        If Dir(MTimePath3 & FileNm3 & ".DAT") <> "" Then
            File.Copy(MTimePath3 & "TrTime\" & FileNm3 & ".DAT", MTimePath2 & FileNm3 & ".DAT", True)
            Label4.Text = MTimePath2 & FileNm3 & ".DAT"
            ProgressBar1.Value = 24
            ImportD3()
        End If
        If Dir(MTimePath3 & FileNm4 & ".DAT") <> "" Then
            File.Copy(MTimePath3 & "TrTime\" & FileNm4 & ".DAT", MTimePath2 & FileNm4 & ".DAT", True)
            Label4.Text = MTimePath2 & FileNm4 & ".DAT"
            ProgressBar1.Value = 36
            ImportD4()
        End If
        If Dir(MTimePath & FileNm1 & ".TAF") <> "" Or Dir(MTimePath2 & FileNm3 & ".DAT") <> "" Or Dir(MTimePath & FileNm2 & ".TAF") <> "" Or Dir(MTimePath2 & FileNm4 & ".DAT") <> "" Then
            ProgressBar1.Value = 50
            Label4.Text = "Prepare Time Data...."
            Label4.Refresh()
            ImportData()
            ProgressBar1.Value = 75
            Label4.Text = "Calculating...."
            Label4.Refresh()
            'ImportData2()
            ProgressBar1.Value = 100
        Else
            Label4.Text = "No Have Time Data " & Date1
            Label4.Refresh()
        End If
        ProgressBar1.Visible = False
    End Sub

    Private Sub ImportD1()
        Dim SqlStr As String
        With CommImp
            .CommandText = "Trns_Text1"
            .Parameters.Clear()
            .Parameters.Add("@PathFileName", SqlDbType.VarChar)
            .Parameters("@PathFileName").Value = MTimePath & FileNm1 & ".TAF"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With

        SqlStr = "insert into dbo.Data(fcode,fdate,ftime,fid) " & _
         "SELECT left(dbo.Data2.fdata,8),Convert(datetime,substring(dbo.Data2.fdata,10,8),103)," & _
         "Convert(datetime,substring(dbo.Data2.fdata,10,8),103)+" & _
         "Convert(datetime,substring(dbo.Data2.fdata,19,2) + ':'+substring(dbo.Data2.fdata,21,2),103)," & _
         "substring(dbo.Data2.fdata, 24, 2) from dbo.Data2 inner JOIN dbo.tblStaff ON left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid " & _
         "Where left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "delete from dbo.data2"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub ImportD2()
        Dim SqlStr As String
        With CommImp
            .CommandText = "Trns_Text1"
            .Parameters.Clear()
            .Parameters.Add("@PathFileName", SqlDbType.VarChar)
            .Parameters("@PathFileName").Value = MTimePath & FileNm2 & ".TAF"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With

        SqlStr = "insert into dbo.Data(fcode,fdate,ftime,fid) " & _
         "SELECT left(dbo.Data2.fdata,8),Convert(datetime,substring(dbo.Data2.fdata,10,8),103)," & _
         "Convert(datetime,substring(dbo.Data2.fdata,10,8),103)+" & _
         "Convert(datetime,substring(dbo.Data2.fdata,19,2) + ':'+substring(dbo.Data2.fdata,21,2),103)," & _
         "substring(dbo.Data2.fdata, 24, 2) from dbo.Data2 inner JOIN dbo.tblStaff ON left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid " & _
         "Where left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "delete from dbo.data2"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub ImportD3()
        '======For *.DAT
        Dim SqlStr As String
        With CommImp
            .CommandText = "Trns_Text1"
            .Parameters.Clear()
            .Parameters.Add("@PathFileName", SqlDbType.VarChar)
            .Parameters("@PathFileName").Value = MTimePath2 & FileNm3 & ".DAT"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With

        SqlStr = "insert into dbo.Data(fcode,fdate,ftime,fid) " & _
         "SELECT left(dbo.Data2.fdata,8),Convert(datetime,substring(dbo.Data2.fdata,11,8),103)," & _
         "Convert(datetime,substring(dbo.Data2.fdata,11,8),103)+" & _
         "Convert(datetime,substring(dbo.Data2.fdata,19,2) + ':'+substring(dbo.Data2.fdata,21,2),103)," & _
         "substring(dbo.Data2.fdata, 24, 2) from dbo.Data2 inner JOIN dbo.tblStaff ON left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid " & _
         "Where left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "delete from dbo.data2"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub ImportD4()
        '======For *.DAT
        Dim SqlStr As String
        With CommImp
            .CommandText = "Trns_Text1"
            .Parameters.Clear()
            .Parameters.Add("@PathFileName", SqlDbType.VarChar)
            .Parameters("@PathFileName").Value = MTimePath2 & FileNm4 & ".DAT"
            .CommandType = CommandType.StoredProcedure
            .ExecuteScalar()
        End With

        SqlStr = "insert into dbo.Data(fcode,fdate,ftime,fid) " & _
         "SELECT left(dbo.Data2.fdata,8),Convert(datetime,substring(dbo.Data2.fdata,11,8),103)," & _
         "Convert(datetime,substring(dbo.Data2.fdata,11,8),103)+" & _
         "Convert(datetime,substring(dbo.Data2.fdata,19,2) + ':'+substring(dbo.Data2.fdata,21,2),103)," & _
         "substring(dbo.Data2.fdata, 24, 2) from dbo.Data2 inner JOIN dbo.tblStaff ON left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid " & _
         "Where left(dbo.Data2.fdata,8) = dbo.tblStaff.Stid"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "delete from dbo.data2"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

    End Sub

    Private Sub ImportData()
        Dim SqlStr As String
        SqlStr = "Update Data Set Data.Shift = tblStaff.Shift_id FROM Data " & _
        "INNER JOIN tblStaff ON (Data.FCode = tblStaff.StId)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Update Data Set Data.Shift_in = Data.fdate+tblShift.Shift_in," & _
        "Data.Shift_Out = Data.fdate+tblShift.Shift_Out," & _
        "Data.Shift_relx1 = Data.fdate+tblShift.Shift_relx1," & _
        "Data.Shift_relx2 = Data.fdate+tblShift.Shift_relx2," & _
        "Data.Shift_hr = tblShift.Shift_hr " & _
        " FROM Data INNER JOIN tblShift ON (Data.Shift = tblShift.Shift_Id) "
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandTimeout = 0
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        'บวก 1 วัน กะบ่าย
        SqlStr = "Update Data Set Data.Shift_in = Convert(datetime,Data.fdate,103)+tblShift.Shift_in," & _
        "Data.Shift_Out = DateAdd(Day,1,Convert(datetime,Data.fdate,103))+tblShift.Shift_Out," & _
        "Data.Shift_relx1 = DateAdd(Day,1,Convert(datetime,Data.fdate,103))+tblShift.Shift_relx1," & _
        "Data.Shift_relx2 = DateAdd(Day,1,Convert(datetime,Data.fdate,103))+tblShift.Shift_relx2" & _
        " FROM Data INNER JOIN tblShift ON (Data.Shift = tblShift.Shift_Id) " & _
        "where Data.Shift_in > Convert(datetime,Data.fdate,103)+' 3:00:00 PM'"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        '====ลบ Record ที่ข้ามวัน พรุ่งนี้
        'กะเช้า
        SqlStr = "Delete from Data Where Data.fdate = Convert(datetime,'" & Date2 & _
        "',103) And Shift_in < Convert(datetime,'" & Date2 & " " & #3:00:00 PM# & "',103) And " & _
        "FTime > Convert(datetime,'" & Date2 & " " & #4:00:00 AM# & "',103)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        'กะบ่าย
        SqlStr = "Delete from Data Where Data.fdate = Convert(datetime,'" & Date2 & _
        "',103) And  Shift_in >= Convert(datetime,'" & Date2 & " " & #3:00:00 PM# & "',103) And " & _
        "FTime > Convert(datetime,'" & Date2 & " " & #1:00:00 PM# & "',103)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        '====ลบ Record ที่ข้ามวัน เมื่อวาน
        SqlStr = "Delete from Data Where Data.fdate = Convert(datetime,'" & Date1 & _
        "',103) And  Shift_in >= Convert(datetime,'" & Date1 & " " & #3:00:00 PM# & "',103) And " & _
        "FTime < Convert(datetime,'" & Date1 & " " & #1:00:00 PM# & "',103)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
        SqlStr = "Delete from Data Where Data.fdate = Convert(datetime,'" & Date1 & _
        "',103) And  Shift_in < Convert(datetime,'" & Date1 & " " & #3:00:00 PM# & "',103) And " & _
        "FTime < Convert(datetime,'" & Date1 & " " & #3:00:00 AM# & "',103)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Select * into data1 from  data order by fdate,ftime"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Delete from tblTime"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "INSERT INTO tblTIME(StId,t_date,T_IN1,T_OUT1)" & _
        "SELECT fcode,Min(fdate)," & _
        "Min(ftime),Max(ftime) FROM Data1 GROUP BY fcode " & _
        "HAVING (((Count(fcode)) >= 1))"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Update tblTime Set tblTime.Shift = tblStaff.Shift_id" & _
               " FROM tblTime INNER JOIN tblStaff ON (tblTime.StId = tblStaff.StId) "
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandTimeout = 0
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Update tblTime Set tblTime.Shift_in = tblTime.t_date+tblShift.Shift_in," & _
               "tblTime.Shift_Out = tblTime.t_date+tblShift.Shift_Out," & _
               "tblTime.Shift_relx1 = tblTime.t_date+tblShift.Shift_relx1," & _
               "tblTime.Shift_relx2 = tblTime.t_date+tblShift.Shift_relx2," & _
               "tblTime.Shift_hr = tblShift.Shift_hr " & _
               " FROM tblTime INNER JOIN tblShift ON (tblTime.Shift = tblShift.Shift_Id) "
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandTimeout = 0
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        'บวก 1 วัน กะบ่าย
        SqlStr = "Update tblTime Set tblTime.Shift_in = Convert(datetime,tblTime.t_date,103)+tblShift.Shift_in," & _
        "tblTime.Shift_Out = DateAdd(Day,1,Convert(datetime,tblTime.t_date,103))+tblShift.Shift_Out," & _
        "tblTime.Shift_relx1 = DateAdd(Day,1,Convert(datetime,tblTime.t_date,103))+tblShift.Shift_relx1," & _
        "tblTime.Shift_relx2 = DateAdd(Day,1,Convert(datetime,tblTime.t_date,103))+tblShift.Shift_relx2" & _
        " FROM tblTime INNER JOIN tblShift ON (tblTime.Shift = tblShift.Shift_Id) " & _
        "where tblTime.Shift_in > Convert(datetime,tblTime.t_date,103)+' 3:00:00 PM'"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        'Clear record other date
        SqlStr = "Delete from tblTime Where t_date = Convert(datetime,'" & Date2 & "',103) " & _
        "And Convert(datetime,t_in1,103) <> Convert(datetime,'" & Date1 & "',103) " & _
        " And dbo.tblTime.Shift_in < convert(datetime,dbo.tblTime.t_date,103) + '15:00:00.000'"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        'Update record tomorow to today
        SqlStr = "Update tblTime set t_date = Convert(datetime,'" & Date1 & _
        "',103) Where t_date = Convert(datetime,'" & Date2 & "',103)"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        '===Clear Date Before Insert
        SqlStr = "Delete from tblHome Where t_date = Convert(datetime,'" & Date1 & "',103) And Factory = '" & MFactory & "'"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        SqlStr = "Insert  INTO tblHome(Factory,T_date,StId,Title_Th,Fname_Th,Lname_Th,Field_Id,Shift_Id," & _
        "Div_Id,Dep_Id,Unit_Id,Type_Id,Emp_Th,Pos_Id,Sup_Id,Head_id,Sal,Shift_Start,Shift_End,H_Normal) " & _
        " Select distinct '" & MFactory & "',tblTIME.t_date,tblstaff.StId,tblstaff.Title_Th," & _
        "tblstaff.Fname_Th,tblstaff.Lname_Th,tblstaff.Field_Id,tblstaff.Shift_Id," & _
        "tblstaff.Div_Id,tblstaff.Dep_Id,tblstaff.Unit_Id,tblstaff.Type_Id,tblstaff.Emp_Th," & _
        "tblstaff.Pos_Id, tblstaff.Sup_Id, tblstaff.Head_id, tblstaff.Sal,tblTime.Shift_IN,tblTime.Shift_OUT,tblTime.Shift_Hr " & _
        " From tblTIME,tblStaff Where tblstaff.Stid = tblTIME.Stid " & _
        " And tblTIME.Stid NOT IN (SELECT StId FROM tblHome " & _
        " Where t_date = Convert(datetime,'" & Date1 & "',103))"

        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With

        '=== Clear Data
        SqlStr = "Delete from Data"
        With CommImp
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
    End Sub
End Class