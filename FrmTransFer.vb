Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmTransFer
    Inherits System.Windows.Forms.Form
    Private bindingSource1, bindingSource2 As New BindingSource()
    Dim StrSql As String
    Dim TrnStr As String
    Dim Conn As New SqlConnection
    Dim da, da3, da4 As SqlDataAdapter
    Dim da2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim table, table2 As New DataTable()
    Dim MFact As String
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim CommImp As New SqlCommand
    Dim IsFindHd As Boolean = False
    Dim IsFindDt As Boolean = False
    Dim kgs As Double = 0
    Dim Amount As Double = 0
    Dim XNormal_Hr, XNormal_Ot, XHoliday_Ot, XIncentive As Double
    Dim nCurRecFact As CurrencyManager
    Dim SelTab As String
    Dim MFilter As String = ""
    Dim MXCON, MXCON2, MXCON_NM2 As String
    Dim MIsCh As Boolean = False
    Dim MTime_Start, MTime_End As Date
    Dim Date1 As DateTime
    Dim Date2 As DateTime
    Dim FileNm1 As String
    Dim FileNm2 As String
    Dim FileNm3 As String
    Dim FileNm4 As String
    Dim TOvwr As Boolean = True
    Dim MNight As Boolean = False
    Dim MShift_ID As String
    Dim MShift_In, MShift_Out As DateTime
    Dim MOTMorning, MOTEvening, MNormalHr, MRelxN, MRelxO As Double


    Private Sub FrmRTran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"



        CbSup_Id.Items.Clear()
        Dim sqlSupCode As String
        sqlSupCode = "SELECT * FROM tblSupervisor WHERE Factory = '" & MFactory & "' Order By Sup_Id"
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

        CbHead_Id.Items.Clear()
        Dim sqlHead As String
        sqlHead = "SELECT * FROM tblHead WHERE Factory = '" & MFactory & "' Order By Head_Id"
        da = New SqlDataAdapter(sqlHead, Conn)
        da.Fill(ds, "Head1")
        If ds.Tables("Head1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Head1").Rows.Count - 1
                CbHead_Id.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                            ds.Tables("Head1").Rows(i).Item("Head_Name"))
            Next
        End If
        CbHead_Id.Text = ""
        ds.Tables("Head1").Clear()


        CbDep_Id.Items.Clear()
        Dim sqlDep_Id As String
        sqlDep_Id = "SELECT * FROM tblDepartment Order By Dep_Id"
        da = New SqlDataAdapter(sqlDep_Id, Conn)
        da.Fill(ds, "Dep1")
        If ds.Tables("Dep1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Dep1").Rows.Count - 1
                '====Filter Department Only My Factory ===== 
                If ds.Tables("Dep1").Rows(i).Item("Factory") = MFactory Then
                    CbDep_Id.Items.Add(ds.Tables("Dep1").Rows(i).Item("Dep_Id") & " " & _
                                ds.Tables("Dep1").Rows(i).Item("Dep_Th"))
                End If
                '=====  All Department All Factory ======
                CbDep_Id2.Items.Add(ds.Tables("Dep1").Rows(i).Item("Dep_Id") & " " & _
                ds.Tables("Dep1").Rows(i).Item("Dep_Th"))
            Next
        End If
        CbDep_Id.Text = ""
        ds.Tables("Dep1").Clear()

        'For Each c In "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
        'If XShud = c Then
        'For i = 1 To 9
        'CbTrfNo.Items.Add(c & "0" & CStr(i))
        'Next
        'For i = 10 To 99
        'CbTrfNo.Items.Add(c & CStr(i))
        'Next
        'End If
        'Next

        'XShudA = True
        If XShudA = True Then
            For i = 1 To 9
                CbTrfNo.Items.Add("A0" & CStr(i))
            Next
            For i = 10 To 99
                CbTrfNo.Items.Add("A" & CStr(i))
            Next
        End If
        If XShudB = True Then
            For i = 1 To 9
                CbTrfNo.Items.Add("B0" & CStr(i))
            Next
            For i = 10 To 99
                CbTrfNo.Items.Add("B" & CStr(i))
            Next
        End If
        If XShudC = True Then
            For i = 1 To 9
                CbTrfNo.Items.Add("C0" & CStr(i))
            Next
            For i = 10 To 99
                CbTrfNo.Items.Add("C" & CStr(i))
            Next
        End If
        If XShudD = True Then
            For i = 1 To 9
                CbTrfNo.Items.Add("D0" & CStr(i))
            Next
            For i = 10 To 99
                CbTrfNo.Items.Add("D" & CStr(i))
            Next
        End If
        If XShudE = True Then
            For i = 1 To 9
                CbTrfNo.Items.Add("E0" & CStr(i))
            Next
            For i = 10 To 99
                CbTrfNo.Items.Add("E" & CStr(i))
            Next
        End If
        CbRelax.Items.Add("0")
        CbRelax.Items.Add("20")
        CbRelax.Items.Add("30")
        CbRelax.Items.Add("60")
        CbRelax.Items.Add("80")
        CbRelax.Items.Add("90")

        Clear_Hd()
        Clear_Det()
    End Sub

    Private Sub Clear_Hd()
        DateTimePicker1.Value = Now.Date
        CbSup_Id.Text = ""
        CbDep_Id.Text = ""
        CbDep_Id2.Text = ""
        CbHead_Id.Text = ""
        'txtTrfNo.Text = ""
        CbTrfNo.Text = ""
        MNight = False

        'Clear_Det()
        'Up_DataGrid()
        'Up_DataGrid2()
        DateTimePicker1.Focus()
    End Sub

    Private Sub Clear_Det()
        DTTime_Start.Text = "08:00"
        DTTime_End.Text = "17:00"
        CbRelax.Text = "60"
        TxtNormal_Hr.Text = "8"
        txtNormal_Ot.Text = "0"
        txtHoliday_Ot.Text = "0"
        txtIncentive.Text = "0"
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        'CmdReturn.Enabled = False
        'CmdTransfer.Enabled = False
    End Sub

    Private Sub Up_DataGrid()


        MFilter = " Where tblStaff.StId COLLATE Thai_Ci_AS Not In (Select tblTransfer.StId from tblTransfer where tblTransfer.Trfdate = Convert(datetime,'" & _
        DateTimePicker1.Text & "',103) And tblTransfer.TrfNo = '" & CbTrfNo.Text & "') "

        If CbHead_Id.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        End If
        'If CbSup_Id.Text <> "" Then
        MFilter = MFilter + " And tblStaff.SUP_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        'End If

        If CbDep_Id.Text <> "" Then
            Dim Dept_id2 = getDeptIDFomrCBB(CbDep_Id.Text)
            'MFilter = MFilter + " And tblStaff.Dep_id = '" & Microsoft.VisualBasic.Left(CbDep_Id.Text, 10) & "'"
            MFilter = MFilter + " And tblStaff.Dep_id = '" & Dept_id2 & "'"
        End If

        MFilter = MFilter + " And tblStaff.Factory = '" & MFactory & "'"
        'MsgBox(MFilter)

        table.Clear()
        GetData_Update("SELECT * FROM tblStaff " & MFilter & " Order by tblStaff.Stid")
        GetData("SELECT * FROM tblStaff " & MFilter & " Order by tblStaff.Stid")
        DataGridView1.Refresh()
        SumGrid1()

        CbShift.Items.Clear()
        Dim SqlShift As String
        SqlShift = "select Distinct tblStaff.Shift_id," & _
        "left(Convert(varchar,tblShift.Shift_In,8),5) As Shift_In1," & _
        "left(Convert(varchar,tblShift.Shift_Out,8),5) As Shift_Out1" & _
        " from tblStaff left join tblShift on tblStaff.Shift_id = tblShift.Shift_id" & MFilter
        da = New SqlDataAdapter(SqlShift, Conn)
        da.Fill(ds, "Shift1")
        If ds.Tables("Shift1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Shift1").Rows.Count - 1
                CbShift.Items.Add(ds.Tables("Shift1").Rows(i).Item("Shift_Id") & " " & _
                            ds.Tables("Shift1").Rows(i).Item("Shift_in1") & "-" & ds.Tables("Shift1").Rows(i).Item("Shift_Out1"))
            Next
        End If
        ds.Tables("Shift1").Clear()


    End Sub

    Private Sub Up_DataGrid2()
        MIsCh = False

        MFilter = " Where tblTransfer.Trfdate = Convert(datetime,'" & DateTimePicker1.Text & _
          "',103) And tblTransfer.TrfNo = '" & CbTrfNo.Text & "'"

        If CbSup_Id.Text <> "" Then
            MFilter = MFilter + " And tblTransfer.SUP_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        End If

        'If CbHead_Id.Text <> "" Then
        'MFilter = MFilter + " And tblTransfer.Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        'End If
        MFilter = MFilter + " And tblTransfer.Factory = '" & MFactory & "'"


        table2.Clear()
        GetData_Update2("SELECT * FROM tblTransfer " & MFilter & " Order by tblTransfer.StId")
        GetData2("SELECT  * FROM tblTransfer " & MFilter & " Order by tblTransfer.StId")
        'Conf,StId,Fname_Th,Lname_Th,Time_Start,Time_End,Normal_Hr,Normal_Ot,Holiday_Ot,Incentive
        DataGridView2.Refresh()
        SumGrid2()
    End Sub

    Private Sub ChkHead()
        Dim sqlFact As String
        sqlFact = "SELECT * FROM tblTransfer  Where Trfdate = Convert(datetime,'" & DateTimePicker1.Text & "',103) " & _
        "and TrfNo = '" & CbTrfNo.Text & "'"

        If CbSup_Id.Text <> "" Then
            sqlFact = sqlFact + " And SUP_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        End If

        'If CbHead_Id.Text <> "" Then
        'sqlFact = sqlFact + " And Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        'End If
        sqlFact = sqlFact + " And Factory = '" & MFactory & "'"

        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Tran2")
        If ds.Tables("Tran2").Rows.Count <> 0 Then
            If ds.Tables("Tran2").Rows(0).Item("Dep_Id2") Is System.DBNull.Value = False Then
                'CbDep_Id2.Text = CStr(ds.Tables("Tran2").Rows(0).Item("Dep_Id2"))
                Dim SqlDiv As String
                SqlDiv = "Select * from tblDepartment where Dep_Id = '" & _
                              CStr(ds.Tables("Tran2").Rows(0).Item("Dep_Id2")) & "' And Factory = '" & MFactory & "'"
                da = New SqlDataAdapter(SqlDiv, Conn)
                da.Fill(ds, "Dep1")
                If ds.Tables("Dep1").Rows.Count <> 0 Then
                    CbDep_Id2.Text = CStr(ds.Tables("Dep1").Rows(0).Item("Dep_Id")) & " " & _
                    CStr(ds.Tables("Dep1").Rows(0).Item("Dep_Th"))
                End If
                ds.Tables("Dep1").Clear()
            Else
                CbDep_Id2.Text = ""
            End If


            If ds.Tables("Tran2").Rows(0).Item("Sup_Id") Is System.DBNull.Value = False Then
                Dim SqlDiv As String
                SqlDiv = "Select * from tblSupervisor where Sup_Id = '" & _
                              CStr(ds.Tables("Tran2").Rows(0).Item("Sup_Id")) & "' And Factory = '" & MFactory & "'"
                da = New SqlDataAdapter(SqlDiv, Conn)
                da.Fill(ds, "Dep1")
                If ds.Tables("Dep1").Rows.Count <> 0 Then
                    CbSup_Id.Text = CStr(ds.Tables("Dep1").Rows(0).Item("Sup_Id")) & " " & _
                    CStr(ds.Tables("Dep1").Rows(0).Item("Sup_Name"))
                End If
                ds.Tables("Dep1").Clear()
            Else
                CbSup_Id.Text = ""
            End If
        Else
            CbDep_Id2.Text = ""
            CbSup_Id.Text = ""
            CbHead_Id.Text = ""
            CbDep_Id.Text = ""
        End If
        ds.Tables("Tran2").Clear()
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
            '.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 14.25F, GraphicsUnit.Pixel)
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11.0F, GraphicsUnit.Pixel)
            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next
            '=============================================================================================
            Dim ColConf As New DataGridViewCheckBoxColumn
            With ColConf
                .DataPropertyName = "Conf"
                .HeaderText = "X"
                .Width = 30
            End With
            .Columns.Add(ColConf)

            Dim ColStId As New DataGridViewTextBoxColumn
            With ColStId
                .DataPropertyName = "StId"
                .HeaderText = "รหัส"
                .Width = 60
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColStId)

            'Dim ColTitle_Th As New DataGridViewTextBoxColumn
            'With ColTitle_Th
            '.DataPropertyName = "Title_Th"
            '.HeaderText = "คำนำหน้าชื่อ"
            '.Width = 75
            '.MaxInputLength = 10
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColTitle_Th)


            'Dim ColTitle_Th As New DataGridViewComboBoxColumn
            'With ColTitle_Th
            '.DataPropertyName = "Title_Th"
            '.HeaderText = "คำนำหน้าชื่อ"
            '.Width = 75
            '.Items.Add("NA")
            '.Items.Add("นาย")
            '.Items.Add("นาง")
            ''.Items.Add("นางสาว")
            '.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            '' .DropDownWidth = 95
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColTitle_Th)

            Dim ColFname_Th As New DataGridViewTextBoxColumn
            With ColFname_Th
                .DataPropertyName = "Fname_Th"
                .HeaderText = "ชื่อ"
                .Width = 80
                .MaxInputLength = 50
                .ReadOnly = True
            End With
            .Columns.Add(ColFname_Th)

            Dim ColLname_Th As New DataGridViewTextBoxColumn
            With ColLname_Th
                .DataPropertyName = "Lname_Th"
                .HeaderText = "นามสกุล"
                .Width = 100
                .MaxInputLength = 50
                .ReadOnly = True
            End With
            .Columns.Add(ColLname_Th)

            'Dim sqlHead As String
            'sqlHead = "SELECT * FROM tblHead Order By Head_Id"
            'da = New SqlDataAdapter(sqlHead, Conn)
            'da.Fill(ds, "Head2")
            'Dim ColHead As New DataGridViewComboBoxColumn
            'With ColHead
            '.DataPropertyName = "Head_Id"
            '.HeaderText = "หัวหน้าหน่วย"
            '.Width = 100
            '.DataSource = ds.Tables("Head2")
            '.ValueMember = "Head_Id"
            '.DisplayMember = "Head_Name"
            '.DropDownWidth = 100
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColHead)

            'Dim sqlSup As String
            'sqlSup = "SELECT * FROM tblSupervisor Order By Sup_Id"
            'da = New SqlDataAdapter(sqlSup, Conn)
            'da.Fill(ds, "Sup2")
            'Dim ColSup As New DataGridViewComboBoxColumn
            'With ColSup
            '.DataPropertyName = "Sup_Id"
            '.HeaderText = "Supervisor"
            '.Width = 100
            '.DataSource = ds.Tables("Sup2")
            '.ValueMember = "Sup_Id"
            '.DisplayMember = "Sup_Name"
            '.DropDownWidth = 100
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColSup)

            Dim ColCostCen As New DataGridViewTextBoxColumn
            With ColCostCen
                .DataPropertyName = "Dep_Id"
                .HeaderText = "CostCen"
                .Width = 60
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColCostCen)

            Dim sqlDep As String
            sqlDep = "SELECT * FROM tblDepartment WHERE Factory = '" & MFactory & "' Order By Dep_Id"
            da = New SqlDataAdapter(sqlDep, Conn)
            da.Fill(ds, "Dep2")
            Dim ColDep As New DataGridViewComboBoxColumn
            With ColDep
                .DataPropertyName = "Dep_Id"
                .HeaderText = "แผนกต้นสังกัด"
                .Width = 200
                .DataSource = ds.Tables("Dep2")
                .ValueMember = "Dep_Id"
                .DisplayMember = "Dep_th"
                .DropDownWidth = 200
                .ReadOnly = True
            End With
            .Columns.Add(ColDep)

            'Dim ColWDate As New DataGridViewTextBoxColumn
            'With ColWDate
            '.DataPropertyName = "WDate"
            '.HeaderText = "วันที่"
            '.DefaultCellStyle.Format = "d"
            '.Width = 100
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColWDate)

            'Dim ColSmQuan As New DataGridViewTextBoxColumn
            'With ColSmQuan
            '.DataPropertyName = "TrQuan"
            '.HeaderText = "KGS."
            '.Width = 80
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Format = "#,##0.00"
            '.ReadOnly = True
            'End With
            '.Columns.Add(ColSmQuan)



        End With
    End Sub

    Private Sub GetData_Update2(ByVal selectCommand As String)
        da4 = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder1 As New SqlCommandBuilder(da4)
        table2.Locale = System.Globalization.CultureInfo.InvariantCulture
        da4.Fill(table2)
        Me.bindingSource2.DataSource = table2
    End Sub

    Private Sub GetData2(ByVal selectCommand As String)
        da3 = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder As New SqlCommandBuilder(da3)
        table2.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.bindingSource2.DataSource = table2
        With DataGridView2
            If .DataSource IsNot DBNull.Value Then
                .DataSource = ""
                .Columns.Clear()
            End If

            .DataSource = Me.bindingSource2
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11.0F, GraphicsUnit.Pixel)

            .EditMode = DataGridViewEditMode.EditOnEnter

            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next


            Dim ColConf As New DataGridViewCheckBoxColumn
            With ColConf
                .DataPropertyName = "Conf"
                .HeaderText = "X"
                .Width = 30
            End With
            .Columns.Add(ColConf)

            Dim ColStId As New DataGridViewTextBoxColumn
            With ColStId
                .DataPropertyName = "StId"
                .HeaderText = "รหัส"
                .Width = 60
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColStId)
            FreezeBand(ColStId)

            Dim ColFname_Th As New DataGridViewTextBoxColumn
            With ColFname_Th
                .DataPropertyName = "Fname_Th"
                .HeaderText = "ชื่อ"
                .Width = 80
                .MaxInputLength = 50
                .ReadOnly = True
            End With
            .Columns.Add(ColFname_Th)
            FreezeBand(ColFname_Th)

            Dim ColLname_Th As New DataGridViewTextBoxColumn
            With ColLname_Th
                .DataPropertyName = "Lname_Th"
                .HeaderText = "นามสกุล"
                .Width = 80
                .MaxInputLength = 50
                .ReadOnly = True
            End With
            .Columns.Add(ColLname_Th)
            FreezeBand(ColLname_Th)

            Dim ColConfirm As New DataGridViewCheckBoxColumn
            With ColConfirm
                .DataPropertyName = "FConfirm"
                .HeaderText = "รับโอน"
                .Width = 40
                .ReadOnly = True
            End With
            .Columns.Add(ColConfirm)

            Dim ColDouble_Pay As New DataGridViewCheckBoxColumn
            With ColDouble_Pay
                .DataPropertyName = "Double_Pay"
                .HeaderText = "2 แรง"
                .Width = 40
            End With
            .Columns.Add(ColDouble_Pay)

            Dim ColTime_Start As New CalendarColumn
            With ColTime_Start
                .DataPropertyName = "Time_Start"
                .HeaderText = "เริ่ม"
                .DefaultCellStyle.Format = "t"
                .Width = 50
                '.ReadOnly = False
            End With
            .Columns.Add(ColTime_Start)


            Dim ColTime_End As New CalendarColumn
            With ColTime_End
                .DataPropertyName = "Time_End"
                .HeaderText = "จบ"
                .DefaultCellStyle.Format = "t"
                .Width = 50
                '.ReadOnly = True
            End With
            .Columns.Add(ColTime_End)

            Dim ColRelax1 As New DataGridViewComboBoxColumn
            With ColRelax1
                .DataPropertyName = "Relax"
                .HeaderText = "พัก"
                .Width = 50
                .Items.Add("0")
                .Items.Add("20")
                .Items.Add("60")
                .Items.Add("80")
                .DropDownWidth = 50
                .ReadOnly = False
            End With
            .Columns.Add(ColRelax1)

            Dim ColNormal_Hr As New DataGridViewTextBoxColumn
            With ColNormal_Hr
                .DataPropertyName = "Normal_Hr"
                .HeaderText = "ชม.ปกติ"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColNormal_Hr)

            Dim ColNormal_Ot As New DataGridViewTextBoxColumn
            With ColNormal_Ot
                .DataPropertyName = "Normal_Ot"
                .HeaderText = "Ot.ปกติ"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColNormal_Ot)

            Dim ColHoliday_Ot As New DataGridViewTextBoxColumn
            With ColHoliday_Ot
                .DataPropertyName = "Holiday_Ot"
                .HeaderText = "Otนข"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColHoliday_Ot)

            Dim ColIncentive As New DataGridViewTextBoxColumn
            With ColIncentive
                .DataPropertyName = "Incentive"
                .HeaderText = "Incent"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColIncentive)

            Dim ColPos_All As New DataGridViewTextBoxColumn
            With ColPos_All
                .DataPropertyName = "Pos_All"
                .HeaderText = "ค่าตำแหน่ง"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColPos_All)

            Dim sqlShift As String
            sqlShift = "SELECT Shift_Id,Shift_In,Shift_Out FROM tblShift WHERE Factory = '" & MFactory & "' Order By Shift_Id"
            da = New SqlDataAdapter(sqlShift, Conn)
            da.Fill(ds, "Shift2")
            Dim ColShift As New DataGridViewComboBoxColumn
            With ColShift
                .DataPropertyName = "Shift_Id"
                .HeaderText = "กะ"
                .Width = 50
                .DataSource = ds.Tables("Shift2")
                .ValueMember = "Shift_Id"
                .DisplayMember = "Shift_Id"
                .DropDownWidth = 50
                .ReadOnly = False
            End With
            .Columns.Add(ColShift)

            Dim ColCostCen As New DataGridViewTextBoxColumn
            With ColCostCen
                .DataPropertyName = "Dep_Id"
                .HeaderText = "CostCen"
                .Width = 60
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColCostCen)

            Dim sqlDep As String
            sqlDep = "SELECT * FROM tblDepartment WHERE Factory = '" & MFactory & "' Order By Dep_Id"
            da = New SqlDataAdapter(sqlDep, Conn)
            da.Fill(ds, "Dep2")
            Dim ColDep As New DataGridViewComboBoxColumn
            With ColDep
                .DataPropertyName = "Dep_Id"
                .HeaderText = "แผนกต้นสังกัด"
                .Width = 200
                .DataSource = ds.Tables("Dep2")
                .ValueMember = "Dep_Id"
                .DisplayMember = "Dep_th"
                .DropDownWidth = 200
                .ReadOnly = True
            End With
            .Columns.Add(ColDep)




        End With
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        If MIsCh = True Then
            Dim Message As String = "ข้อมูลมีการเปลี่ยนแปลง คุณต้องการบันทึกก่อนออก ?"
            Dim Caption As String = "ยืนยัน"
            Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNoCancel
            Dim Result As DialogResult
            Result = MessageBox.Show(Message, Caption, Buttons)
            If Result = System.Windows.Forms.DialogResult.Yes Then

                '==== Lock ปิดงวด
                Dim sqlLock As String
                sqlLock = "SELECT * FROM tblLock WHERE Factory = '" & MFactory & "'"
                da = New SqlDataAdapter(sqlLock, Conn)
                da.Fill(ds, "Lock1")
                If ds.Tables("Lock1").Rows.Count <> 0 Then
                    If DateTimePicker1.Value <= CStr(ds.Tables("Lock1").Rows(0).Item("LockDate")) Then
                        MessageBox.Show("วันที่ " & DateTimePicker1.Text & " ปิดงวดไปแล้ว ไม่สามารถแก้ไขได้ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ds.Tables("Lock1").Clear()
                        Exit Sub
                    End If
                End If
                ds.Tables("Lock1").Clear()

                saveData()
            End If
            If Result = System.Windows.Forms.DialogResult.No Then
                Me.Close()
                Exit Sub
            End If
            If Result = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'DelTab()
        'MakeTable1()

        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim MParamFactName, MParamFactAddr, MFormula As String
        Dim RpTDep As New PrtTransfer
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTDep.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
               And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTDep.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTDep.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)
        MFormula = "{tblTransFer.TrfDate} =  Date('" & DateTimePicker1.Text & "')"

        If CbSup_Id.Text <> "" Then
            MFormula = MFormula + " And {tblTransFer.Sup_id} = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        End If
        'If CbHead_Id.Text <> "" Then
        'MFormula = MFormula + " And {tblTransFer.Head_id} = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        'End If
        If CbTrfNo.Text <> "" Then
            MFormula = MFormula + " And {tblTransFer.TrfNo} = '" & CbTrfNo.Text & "'"
        End If
        MFormula = MFormula + " And {tblTransFer.Factory} = '" & MFactory & "'"
        MParamFactName = MFactName
        MParamFactAddr = MFactAddr

        With CRVDep
            .ReportSource = RpTDep
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamFactName)
            .ParameterFieldInfo(1).CurrentValues.AddValue(MParamFactAddr)
            .SelectionFormula = MFormula
            .DisplayGroupTree = False
            .Zoom(100)
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

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        DataGridView1.BindingContext(DataGridView1.DataSource).EndCurrentEdit()
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        Try
            'ChkDetail()
        Catch ex As Exception
            'แจ้งรายงานปัญหาที่เกิดขึ้น
        End Try
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbTrfNo.Focus()
        End If
    End Sub

    Private Sub SumGrid1()
        Label16.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " คน"
    End Sub

    Private Sub SumGrid2()
        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer
        XNormal_Hr = 0
        XNormal_Ot = 0
        XHoliday_Ot = 0
        XIncentive = 0

        ' Iterate through all the rows and sum up the appropriate columns.
        For counter = 0 To (DataGridView2.Rows.Count - 1)
            If Not DataGridView2.Rows(counter).Cells("Normal_Hr").Value Is Nothing Then
                If Not DataGridView2.Rows(counter).Cells("Normal_Hr").Value.ToString().Length = 0 Then
                    XNormal_Hr += DataGridView2.Rows(counter).Cells("Normal_Hr").Value
                End If
            End If
        Next
        Label21.Text = "รวมชม.ปกติ = " & Format(XNormal_Hr, "N")

        For counter = 0 To (DataGridView2.Rows.Count - 1)
            If Not DataGridView2.Rows(counter).Cells("Normal_Ot").Value Is Nothing Then
                If Not DataGridView2.Rows(counter).Cells("Normal_Ot").Value.ToString().Length = 0 Then
                    XNormal_Ot += DataGridView2.Rows(counter).Cells("Normal_Ot").Value
                End If
            End If
        Next
        Label22.Text = "รวมOt.ปกติ = " & Format(XNormal_Ot, "N")

        For counter = 0 To (DataGridView2.Rows.Count - 1)
            If Not DataGridView2.Rows(counter).Cells("Holiday_Ot").Value Is Nothing Then
                If Not DataGridView2.Rows(counter).Cells("Holiday_Ot").Value.ToString().Length = 0 Then
                    XHoliday_Ot += DataGridView2.Rows(counter).Cells("Holiday_Ot").Value
                End If
            End If
        Next
        Label23.Text = "รวมOt.นักขัตถ์ = " & Format(XHoliday_Ot, "N")

        For counter = 0 To (DataGridView2.Rows.Count - 1)
            If Not DataGridView2.Rows(counter).Cells("Incentive").Value Is Nothing Then
                If Not DataGridView2.Rows(counter).Cells("Incentive").Value.ToString().Length = 0 Then
                    XIncentive += DataGridView2.Rows(counter).Cells("Incentive").Value
                End If
            End If
        Next
        Label24.Text = "รวมIncentive = " & Format(XIncentive, "N")

        Label15.Text = "รวม   " & Format(DataGridView2.RowCount, "#,#") & " คน"

        'If DataGridView2.RowCount > 0 Then
        'CmdDel.Enabled = True
        'Else
        'CmdDel.Enabled = False
        'End If
    End Sub

    Private Sub FrmRTran_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Label12.Location = New Point(Label12.Location.X, Me.Height - 75)
        'Label19.Location = New Point(Label19.Location.X, Me.Height - 75)
        'Label20.Location = New Point(Label20.Location.X, Me.Height - 75)
    End Sub

    Private Sub CmdTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdTransfer.Click
        Dim SqlLog As String

        If CbDep_Id2.Text = "" Then
            MessageBox.Show("กรุณาป้อนแผนกที่จะไป...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbDep_Id2.Focus()
            Exit Sub
        End If
        If CbTrfNo.Text = "" Then
            MessageBox.Show("กรุณาป้อนชุด  ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbTrfNo.Focus()
            Exit Sub
        End If

        'LoadTimeData()

        '===Check Conf
        'Dim sqlFact As String
        'sqlFact = "SELECT * FROM tblStaff  Where Conf = -1"
        'da = New SqlDataAdapter(sqlFact, Conn)
        'da.Fill(ds, "Staff3")
        'If ds.Tables("Staff3").Rows.Count = 0 Then
        'MessageBox.Show("กรุณาเลือกคนที่จะไป...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'DataGridView1.Focus()
        'Exit Sub
        'End If
        'ds.Tables("Staff3").Clear()

        'MTime_Start = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_Start.Text
        'MTime_End = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_End.Text

        Dim counter As Integer
        Dim dept_id2 As String = getDeptIDFomrCBB(CbDep_Id2.Text)
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            'Store_Det(counter)
            If DataGridView1.Rows(counter).Cells("Conf").Value = True Then
                'Save_Dt()
                Dim sqlSave As String
                sqlSave = "INSERT INTO tblTransfer(Factory,Trfdate,TrfNo,StId,Title_Th,FName_Th,LName_Th,Field_Id,Div_Id,"
                sqlSave &= "Sup_Id,Head_id,Dep_Id,Dep_Id2,Unit_Id,Type_Id,Pos_Id,Emp_th,Sal,Pos_All,Time_Start,Time_End,Relax,"
                sqlSave &= "Normal_Hr,Normal_Ot,Holiday_Ot,Incentive,Double_Pay,Shift_Id) "
                sqlSave &= "VALUES('" & MFactory & "',convert(datetime,'" & DateTimePicker1.Value.Date & "',103),'"
                sqlSave &= CbTrfNo.Text & "','" & DataGridView1.Rows(counter).Cells("StId").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Title_Th").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("FName_Th").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("LName_Th").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Field_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Div_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Sup_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Head_id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Dep_Id").Value & "','"
                'sqlSave &= Microsoft.VisualBasic.Left(CbDep_Id2.Text, 10) & "','"
                sqlSave &= dept_id2 & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Unit_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Type_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Pos_Id").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Emp_th").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Sal").Value & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Pos_All").Value & "',"
                sqlSave &= "convert(datetime,'" & MTime_Start & "',103),"
                sqlSave &= "convert(datetime,'" & MTime_End & "',103),'"
                sqlSave &= CStr(CDbl(CbRelax.Text)) & "','"
                sqlSave &= CStr(CDbl(TxtNormal_Hr.Text)) & "','" & CStr(CDbl(txtNormal_Ot.Text)) & "','"
                sqlSave &= CStr(CDbl(txtHoliday_Ot.Text)) & "','" & CStr(CDbl(txtIncentive.Text)) & "','"
                sqlSave &= CheckBox3.Checked & "','"
                sqlSave &= DataGridView1.Rows(counter).Cells("Shift_Id").Value & "')"
                With ComSave
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandText = "Set DateFormat 'DMY'"
                    .ExecuteNonQuery()
                    .CommandText = sqlSave
                    .ExecuteNonQuery()
                End With

            End If
        Next
        SqlLog = "โอนคนชุด " & CbTrfNo.Text & " วันที่ " & DateTimePicker1.Text & " ไป CostCenter " & CbDep_Id2.Text
        SaveLog(SqlLog)

        Up_DataGrid()
        Up_DataGrid2()
        Clear_Det()
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

    Private Sub CmdReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdReturn.Click
        Dim SqlLog As String
        Dim counter As Integer
        For counter = 0 To (DataGridView2.Rows.Count - 1)
            'Store_Det(counter)
            If DataGridView2.Rows(counter).Cells("Conf").Value = True Then
                Dim sqlDel As String
                sqlDel = "DELETE FROM tblTransfer WHERE Trfdate = Convert(Datetime,'" & _
                          DateTimePicker1.Value.Date & "',103)" & _
                         " And TrfNo = '" & CbTrfNo.Text & "'" & _
                         " And Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'" & _
                       " And StId = '" & DataGridView2.Rows(counter).Cells("StId").Value & "' And Factory = '" & MFactory & "'"

                With ComDel
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandText = sqlDel
                    .ExecuteNonQuery()
                End With

            End If
        Next
        SqlLog = "เรียกกลับคนชุด " & CbTrfNo.Text & " วันที่ " & DateTimePicker1.Text
        SaveLog(SqlLog)

        Up_DataGrid()
        Up_DataGrid2()
        Clear_Det()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Clear_Hd()
        Clear_Det()
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub dgLookUpFact_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLookUpFact.DoubleClick
        DateTimePicker1.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfDate"))
        CbSup_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Id") & " " & _
        ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Name"))
        'CbHead_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Id") & " " & _
        'ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Name"))
        CbTrfNo.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfNo"))
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        'ChkHead()
        'Up_DataGrid()
        'Up_DataGrid2()
    End Sub

    Private Sub CbSup_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbSup_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id2.Focus()
        End If
    End Sub


    Private Sub CbSup_Id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbSup_Id.TextChanged
        Up_DataGrid()
        Up_DataGrid2()

        If CbShift.Items.Count > 0 Then
            CbShift.SelectedIndex = 0    ' The first item has index 0 '
        End If

    End Sub


    Private Sub Cmd_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Update.Click
        Dim SqlSave As String
        Dim MTime_Start, MTime_End As Date
        Dim dep_id2 As String = getDeptIDFomrCBB(CbDep_Id2.Text)
        '==== Lock ปิดงวด
        Dim sqlLock As String
        sqlLock = "SELECT * FROM tblLock WHERE Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlLock, Conn)
        da.Fill(ds, "Lock1")
        If ds.Tables("Lock1").Rows.Count <> 0 Then
            If DateTimePicker1.Value <= CStr(ds.Tables("Lock1").Rows(0).Item("LockDate")) Then
                MessageBox.Show("วันที่ " & DateTimePicker1.Text & " ปิดงวดไปแล้ว ไม่สามารถแก้ไขได้ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ds.Tables("Lock1").Clear()
                Exit Sub
            End If
        End If
        ds.Tables("Lock1").Clear()


        MTime_Start = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_Start.Text
        MTime_End = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_End.Text

        SqlSave = "UPDATE tblTransfer SET "
        'SqlSave &= "Dep_Id2 = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 10) & "',"
        SqlSave &= "Dep_Id2 = '" & dep_id2 & "',"
        SqlSave &= "Time_Start = convert(datetime,'" & MTime_Start & "',103),"
        SqlSave &= "Time_End = convert(datetime,'" & MTime_End & "',103),"
        SqlSave &= "Relax = '" & CStr(CDbl(CbRelax.Text)) & "',"
        SqlSave &= "Normal_Hr = '" & CStr(CDbl(TxtNormal_Hr.Text)) & "',"
        SqlSave &= "Normal_Ot = '" & CStr(CDbl(txtNormal_Ot.Text)) & "',"
        SqlSave &= "Holiday_Ot = '" & CStr(CDbl(txtHoliday_Ot.Text)) & "',"
        SqlSave &= "Incentive = '" & CStr(CDbl(txtIncentive.Text)) & "',"
        SqlSave &= "Double_Pay = '" & CheckBox3.Checked & "'"
        SqlSave &= " WHERE Trfdate = Convert(datetime,'" & DateTimePicker1.Text & "',103)"
        SqlSave &= " And Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        SqlSave &= " And TrfNo = '" & CbTrfNo.Text & "' And Factory = '" & MFactory & "'"

        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

        Up_DataGrid2()
    End Sub

    Private Sub CbDep_Id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDep_Id.TextChanged
        Up_DataGrid()
        Up_DataGrid2()
    End Sub

    Private Sub CbHead_Id_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbHead_Id.GotFocus
        If CbSup_Id.Text <> "" Then
            CbHead_Id.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead where Sup_Id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "' And Factory = '" & MFactory & "' Order By Head_Id"
            da = New SqlDataAdapter(sqlHead, Conn)
            da.Fill(ds, "Head1")
            If ds.Tables("Head1").Rows.Count <> 0 Then
                Dim i As Integer
                For i = 0 To ds.Tables("Head1").Rows.Count - 1
                    CbHead_Id.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                                ds.Tables("Head1").Rows(i).Item("Head_Name"))
                Next
            End If
            'CbHead_Id.Text = ""
            ds.Tables("Head1").Clear()
        Else
            CbHead_Id.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead  Where Factory = '" & MFactory & "' Order By Head_Id"
            da = New SqlDataAdapter(sqlHead, Conn)
            da.Fill(ds, "Head1")
            If ds.Tables("Head1").Rows.Count <> 0 Then
                Dim i As Integer
                For i = 0 To ds.Tables("Head1").Rows.Count - 1
                    CbHead_Id.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                                ds.Tables("Head1").Rows(i).Item("Head_Name"))
                Next
            End If
            'CbHead_Id.Text = ""
            ds.Tables("Head1").Clear()
        End If
    End Sub


    Private Sub txtTrfNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrfNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbSup_Id.Focus()
        End If
    End Sub

    Private Sub CbDep_Id2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDep_Id2.KeyDown
        If e.KeyCode = Keys.Enter Then
            'CmdTransfer.Enabled = True
            DTTime_Start.Focus()
        End If
    End Sub

    Private Sub CbHead_Id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbHead_Id.TextChanged
        Up_DataGrid()
        Up_DataGrid2()
    End Sub

    Private Sub txtTrfNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrfNo.TextChanged
        ChkHead()
        Up_DataGrid()
        Up_DataGrid2()
    End Sub

    Private Sub txtTrfNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrfNo.Validated
        txtTrfNo.Text = UCase(txtTrfNo.Text)
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            For counter = 0 To (DataGridView1.Rows.Count - 1)
                DataGridView1.Rows(counter).Cells("Conf").Value = -1
            Next
            DataGridView1.Refresh()
        Else
            For counter = 0 To (DataGridView1.Rows.Count - 1)
                DataGridView1.Rows(counter).Cells("Conf").Value = 0
            Next
            DataGridView1.Refresh()
        End If
        DataGridView1.BindingContext(DataGridView1.DataSource).EndCurrentEdit()
    End Sub

    Private Sub DateTimePicker1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Validated
        Dim SqlSave As String
        SqlSave = "UPDATE tblStaff SET Conf = 0  where Factory = '" & MFactory & "'"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

        SqlSave = "UPDATE tblTransfer SET Conf = 0 where Trfdate = Convert(datetime,'" & DateTimePicker1.Text & "',103)  And Factory = '" & MFactory & "' "
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With
    End Sub

    Private Sub DTTime_Start_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTTime_Start.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTTime_End.Focus()
        End If
    End Sub

    Private Sub DTTime_Start_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTTime_Start.TextChanged
        MTime_Start = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_Start.Text
        Cal_Hour()
    End Sub

    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then
            For counter = 0 To (DataGridView2.Rows.Count - 1)
                DataGridView2.Rows(counter).Cells("Conf").Value = -1
            Next
            DataGridView2.Refresh()
        Else
            For counter = 0 To (DataGridView2.Rows.Count - 1)
                DataGridView2.Rows(counter).Cells("Conf").Value = 0
            Next
            DataGridView2.Refresh()
        End If
        DataGridView2.BindingContext(DataGridView2.DataSource).EndCurrentEdit()
    End Sub

    Private Sub DTTime_End_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTTime_End.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtNormal_Hr.Focus()
        End If
    End Sub

    Private Sub TxtNormal_Hr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNormal_Hr.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNormal_Ot.Focus()
        End If
    End Sub

    Private Sub txtNormal_Ot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNormal_Ot.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHoliday_Ot.Focus()
        End If
    End Sub

    Private Sub txtHoliday_Ot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHoliday_Ot.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIncentive.Focus()
        End If
    End Sub

    Private Sub txtIncentive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIncentive.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdTransfer.Focus()
        End If
    End Sub

    Private Sub saveData()
        Dim commandBuilder1 As New SqlCommandBuilder(da4)
        Try
            'Update to GetData2
            da4.Update(CType(Me.bindingSource2.DataSource, DataTable))
            'da.Update(ds, "Trans1")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'MIsKey = False
            Up_DataGrid2()
        End Try
    End Sub

    Private Sub DataGridView2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        MIsCh = True

        With DataGridView2
            '===Time_Start=====
            If e.ColumnIndex = 34 Then
                If RTrim(.Rows(e.RowIndex).Cells("Time_Start").Value) <> "" Then
                    .Rows(e.RowIndex).Cells("Time_Start").Value = Format(.Rows(e.RowIndex).Cells("TrfDate").Value, "d") _
                    + " " + Format(.Rows(e.RowIndex).Cells("Time_Start").Value, "t")
                    .Refresh()
                End If
            End If
            '===Time_End=====
            If e.ColumnIndex = 35 Then
                If RTrim(.Rows(e.RowIndex).Cells("Time_End").Value) <> "" Then
                    .Rows(e.RowIndex).Cells("Time_End").Value = Format(.Rows(e.RowIndex).Cells("TrfDate").Value, "d") _
                     + " " + Format(.Rows(e.RowIndex).Cells("Time_End").Value, "t")
                    .Refresh()
                End If
            End If

            If e.ColumnIndex = 34 Or e.ColumnIndex = 35 Or e.ColumnIndex = 36 Then
                Dim SqlStr As String
                SqlStr = "SELECT * FROM tblShift Where Shift_id = '" & .Rows(e.RowIndex).Cells("Shift_id").Value & "' And Factory = '" & MFactory & "'"
                da = New SqlDataAdapter(SqlStr, Conn)
                da.Fill(ds, "Shift1")
                If ds.Tables("Shift1").Rows.Count <> 0 Then
                    MShift_In = Format(DateTimePicker1.Value.Date, "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_In"), "t")
                    MShift_Out = Format(DateTimePicker1.Value.Date, "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_Out"), "t")
                    If MShift_In >= "#" & DateTimePicker1.Text & " 3:00:00 PM#" And MShift_Out <= "#" & DateTimePicker1.Text & " 9:00:00 AM#" Then
                        MShift_Out = Format(DateAdd(DateInterval.Day, 1, MShift_Out), "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_Out"), "t")
                        MNight = True
                    Else
                        MNight = False
                    End If
                End If
                ds.Tables("Shift1").Clear()

                If MNight = True Then
                    '====คำนวนกะที่ข้ามวัน
                    If .Rows(e.RowIndex).Cells("Time_Start").Value >= "#" & DateTimePicker1.Text & " 3:00:00 PM#" And .Rows(e.RowIndex).Cells("Time_End").Value <= "#" & DateTimePicker1.Text & " 9:00:00 AM#" Then
                        'MTime_End = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), "d") + " " + DTTime_End.Text
                        .Rows(e.RowIndex).Cells("Time_End").Value = Format(DateTimePicker1.Value.Date, "d") + " " + Format(.Rows(e.RowIndex).Cells("Time_End").Value, "t")
                        .Rows(e.RowIndex).Cells("Time_End").Value = DateAdd(DateInterval.Hour, 24, .Rows(e.RowIndex).Cells("Time_End").Value)
                    End If
                    If MTime_Start <= "#" & DateTimePicker1.Text & " 6:00:00 AM#" And MTime_End <= "#" & DateTimePicker1.Text & " 11:59:00 AM#" Then
                        'MTime_Start = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), "d") + " " + DTTime_Start.Text
                        .Rows(e.RowIndex).Cells("Time_Start").Value = Format(DateTimePicker1.Value.Date, "d") + " " + Format(.Rows(e.RowIndex).Cells("Time_Start").Value, "t")
                        .Rows(e.RowIndex).Cells("Time_Start").Value = DateAdd(DateInterval.Hour, 24, .Rows(e.RowIndex).Cells("Time_Start").Value)
                    End If
                End If

                Select Case .Rows(e.RowIndex).Cells("Relax").Value
                    Case 0
                        MRelxN = 0
                        MRelxO = 0
                    Case 20
                        MRelxN = 0
                        MRelxO = 20
                    Case 60
                        MRelxN = 60
                        MRelxO = 0
                    Case 80
                        MRelxN = 60
                        MRelxO = 20
                End Select

                If .Rows(e.RowIndex).Cells("Time_Start").Value < MShift_In Then
                    MOTMorning = Math.Round(DateDiff(DateInterval.Minute, .Rows(e.RowIndex).Cells("Time_Start").Value, MShift_In) / 60, 2)
                    If .Rows(e.RowIndex).Cells("Time_End").Value > MShift_Out Then
                        MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MShift_In, MShift_Out) / 60) - MRelxN / 60, 2)
                        MOTEvening = Math.Round((DateDiff(DateInterval.Minute, MShift_Out, .Rows(e.RowIndex).Cells("Time_End").Value) / 60) - MRelxO / 60, 2)
                    Else
                        MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MShift_In, .Rows(e.RowIndex).Cells("Time_End").Value) / 60) - MRelxN / 60, 2)
                        MOTEvening = 0
                    End If
                Else
                    MOTMorning = 0
                    If .Rows(e.RowIndex).Cells("Time_End").Value > MShift_Out Then
                        '=== กรณี เริ่มนอกกะ All OT
                        If .Rows(e.RowIndex).Cells("Time_Start").Value > MShift_Out Then
                            MNormalHr = 0
                            MOTEvening = Math.Round((DateDiff(DateInterval.Minute, .Rows(e.RowIndex).Cells("Time_Start").Value, .Rows(e.RowIndex).Cells("Time_End").Value) / 60) - MRelxO / 60, 2)
                        Else
                            MNormalHr = Math.Round((DateDiff(DateInterval.Minute, .Rows(e.RowIndex).Cells("Time_Start").Value, MShift_Out) / 60) - MRelxN / 60, 2)
                            MOTEvening = Math.Round((DateDiff(DateInterval.Minute, MShift_Out, .Rows(e.RowIndex).Cells("Time_End").Value) / 60) - MRelxO / 60, 2)
                        End If
                    Else
                        MNormalHr = Math.Round((DateDiff(DateInterval.Minute, .Rows(e.RowIndex).Cells("Time_Start").Value, .Rows(e.RowIndex).Cells("Time_End").Value) / 60) - MRelxN / 60, 2)
                        MOTEvening = 0
                    End If
                End If
                .Rows(e.RowIndex).Cells("Normal_Hr").Value = CStr(MNormalHr)
                .Rows(e.RowIndex).Cells("Normal_Ot").Value = CStr(MOTMorning + MOTEvening)
                .Refresh()
            End If
            .BindingContext(.DataSource).EndCurrentEdit()
        End With
    End Sub

    Private Sub DataGridView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.Click
        'MsgBox(DataGridView2.CurrentCell.ColumnIndex)
    End Sub

    Private Sub DataGridView2_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        'MessageBox.Show("Error happened " _
        ' & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Sub

    Private Sub DataGridView2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView2.EditingControlShowing
        'CType(e.Control, TextBox).SelectionStart = 0
        'CType(e.Control, TextBox).SelectionLength = Len(CType(e.Control, TextBox).Text)
        'MsgBox(CType(e.Control, TextBox).SelectedText)
        If TypeOf e.Control Is TextBox Then
            'DirectCast(e.Control, TextBox).SelectionStart = 0
            'DirectCast(e.Control, TextBox).SelectionLength = Len(CType(e.Control, TextBox).Text)
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            'SendKeys.Send("{LEFT}")
        End If
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        '==== Lock ปิดงวด
        Dim sqlLock As String
        sqlLock = "SELECT * FROM tblLock WHERE Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlLock, Conn)
        da.Fill(ds, "Lock1")
        If ds.Tables("Lock1").Rows.Count <> 0 Then
            If DateTimePicker1.Value <= CStr(ds.Tables("Lock1").Rows(0).Item("LockDate")) Then
                MessageBox.Show("วันที่ " & DateTimePicker1.Text & " ปิดงวดไปแล้ว ไม่สามารถแก้ไขได้ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ds.Tables("Lock1").Clear()
                Exit Sub
            End If
        End If
        ds.Tables("Lock1").Clear()


        saveData()
        Up_DataGrid2()
    End Sub

    Private Sub CmdExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "วันที่"
        xlWorkSheet.Cells(1, 2).Value = "รหัสพนักงาน"
        xlWorkSheet.Cells(1, 3).Value = "คำนำหน้าชื่อ"
        xlWorkSheet.Cells(1, 4).Value = "ชื่อ"
        xlWorkSheet.Cells(1, 5).Value = "นามสกุล"
        xlWorkSheet.Cells(1, 6).Value = "ค่าแรง/วัน"
        xlWorkSheet.Cells(1, 7).Value = "ค่าตำแหน่ง"
        xlWorkSheet.Cells(1, 8).Value = "รหัสหัวหน้า"
        xlWorkSheet.Cells(1, 9).Value = "ชื่อหัวหน้า"
        xlWorkSheet.Cells(1, 10).Value = "รหัสต้นสังกัด"
        xlWorkSheet.Cells(1, 11).Value = "ชื่อต้นสังกัด"
        xlWorkSheet.Cells(1, 12).Value = "รหัสที่รับโอน"
        xlWorkSheet.Cells(1, 13).Value = "ชื่อที่รับโอน"
        xlWorkSheet.Cells(1, 14).Value = "ชุด"
        xlWorkSheet.Cells(1, 15).Value = "จากเวลา"
        xlWorkSheet.Cells(1, 16).Value = "ถึงเวลา"
        xlWorkSheet.Cells(1, 17).Value = "ชั่วโมงทำงาน"
        xlWorkSheet.Cells(1, 18).Value = "ชั่วโมงโอที"
        xlWorkSheet.Cells(1, 19).Value = "ชั่วโมงโอทีนักขัตถ์"
        xlWorkSheet.Cells(1, 20).Value = "ค่าแรงปกติ"
        xlWorkSheet.Cells(1, 21).Value = "ค่าโอที"
        xlWorkSheet.Cells(1, 22).Value = "Incentive"
        xlWorkSheet.Cells(1, 23).Value = "รวมค่าแรง"

        Dim SqlString As String
        SqlString = "SELECT tblTransFer.TrfDate,tblTransFer.StId,tblTransFer.Title_Th,tblTransFer.FName_Th," & _
        "tblTransFer.LName_Th,tblTransFer.Sal,tblTransFer.Pos_All,tblTransFer.Head_Id,tblHead.Head_Name,tblTransfer.Dep_Id," & _
        "tblDepartment.Dep_th,tblTransfer.Dep_Id2,tblDepartment_1.Dep_th,tblTransfer.TrfNo," & _
        "tblTransfer.Time_Start,tblTransfer.Time_End,tblTransfer.Normal_Hr,tblTransfer.Normal_Ot," & _
        "tblTransfer.Holiday_Ot,tblTransfer.Normal_Hr*tblTransfer.sal/8," & _
        "(tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*tblTransfer.sal/8*1.5,tblTransfer.Incentive," & _
        "(tblTransfer.Normal_Hr*tblTransfer.sal/8)+((tblTransfer.Normal_Ot+tblTransfer.Holiday_Ot)*" & _
        "tblTransfer.sal/8*1.5)+tblTransfer.Incentive" & _
        " FROM tblTransfer LEFT OUTER JOIN" & _
        " TblStaff ON tblTransfer.StId = TblStaff.Stid LEFT OUTER JOIN" & _
        " TblHead ON tblTransfer.Head_id = TblHead.Head_Id LEFT OUTER JOIN" & _
        " TblDepartment AS TblDepartment_1 ON tblTransfer.Dep_Id2 = TblDepartment_1.Dep_Id LEFT OUTER JOIN" & _
        " TblDepartment ON tblTransfer.Dep_Id = TblDepartment.Dep_Id " & _
        " where tblTransFer.TrfDate = convert(datetime,'" & DateTimePicker1.Text & "',103)" & _
        " And tblTransfer.Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'" & _
        " And tblTransFer.TrfNo = '" & CbTrfNo.Text & "'" & _
        " And tblTransFer.Factory = '" & MFactory & "'" '& MFilter

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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\Transfer_Paper.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\Transfer_Paper.xls")
    End Sub

    Private Sub DTTime_End_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTTime_End.TextChanged
        MTime_End = Format(DateTimePicker1.Value.Date, "d") + " " + DTTime_End.Text
        Cal_Hour()
    End Sub

    Private Sub Cal_Hour()

        Dim SqlStr As String
        SqlStr = "SELECT * FROM tblShift Where Shift_id = '" & MShift_ID & "' And Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Shift1")
        If ds.Tables("Shift1").Rows.Count <> 0 Then
            MShift_In = Format(DateTimePicker1.Value.Date, "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_In"), "t")
            MShift_Out = Format(DateTimePicker1.Value.Date, "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_Out"), "t")
            If MShift_In >= "#" & DateTimePicker1.Text & " 3:00:00 PM#" And MShift_Out <= "#" & DateTimePicker1.Text & " 9:00:00 AM#" Then
                MShift_Out = Format(DateAdd(DateInterval.Day, 1, MShift_Out), "d") & " " & Format(ds.Tables("Shift1").Rows(0).Item("Shift_Out"), "t")
                MNight = True
            Else
                MNight = False
            End If
        End If
        ds.Tables("Shift1").Clear()

        If MNight = True Then
            '====คำนวนกะที่ข้ามวัน
            If MTime_Start >= "#" & DateTimePicker1.Text & " 3:00:00 PM#" And MTime_End <= "#" & DateTimePicker1.Text & " 9:00:00 AM#" Then
                MTime_End = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), "d") + " " + DTTime_End.Text
            End If
            If MTime_Start <= "#" & DateTimePicker1.Text & " 6:00:00 AM#" And MTime_End <= "#" & DateTimePicker1.Text & " 11:59:00 AM#" Then
                MTime_Start = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), "d") + " " + DTTime_Start.Text
            End If
        End If

        Select Case Val(CbRelax.Text)
            Case 0
                MRelxN = 0
                MRelxO = 0
            Case 20
                MRelxN = 0
                MRelxO = 20
            Case 30
                MRelxN = 0
                MRelxO = 30
            Case 60
                MRelxN = 60
                MRelxO = 0
            Case 80
                MRelxN = 60
                MRelxO = 20
            Case 90
                MRelxN = 60
                MRelxO = 30
        End Select


        If MTime_Start < MShift_In Then
            MOTMorning = Math.Round(DateDiff(DateInterval.Minute, MTime_Start, MShift_In) / 60, 2)
            If MTime_End > MShift_Out Then
                MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MShift_In, MShift_Out) / 60) - MRelxN / 60, 2)
                MOTEvening = Math.Round((DateDiff(DateInterval.Minute, MShift_Out, MTime_End) / 60) - MRelxO / 60, 2)
            Else
                MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MShift_In, MTime_End) / 60) - MRelxN / 60, 2)
                MOTEvening = 0
            End If
        Else
            MOTMorning = 0
            If MTime_End > MShift_Out Then
                '=== กรณี เริ่มนอกกะ All OT
                If MTime_Start > MShift_Out Then
                    MNormalHr = 0
                    MOTEvening = Math.Round((DateDiff(DateInterval.Minute, MTime_Start, MTime_End) / 60) - MRelxO / 60, 2)
                Else
                    MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MTime_Start, MShift_Out) / 60) - MRelxN / 60, 2)
                    MOTEvening = Math.Round((DateDiff(DateInterval.Minute, MShift_Out, MTime_End) / 60) - MRelxO / 60, 2)
                End If
            Else
                MNormalHr = Math.Round((DateDiff(DateInterval.Minute, MTime_Start, MTime_End) / 60) - MRelxN / 60, 2)
                MOTEvening = 0
            End If
        End If
        TxtNormal_Hr.Text = CStr(MNormalHr)
        txtNormal_Ot.Text = CStr(MOTMorning + MOTEvening)
    End Sub
  
    Private Sub CbRelax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbRelax.TextChanged
        If CbRelax.Text = "" Then
            CbRelax.Text = "0"
        End If
        Cal_Hour()
    End Sub

    Private Sub CmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFind.Click
        da.Fill(ds, "Trans1")
        ds.Tables("Trans1").Clear()

        Dim sqlfact As String

        sqlfact = "select distinct tbltransfer.TrfDate,tbltransfer.Sup_Id,tblSupervisor.Sup_Name,tbltransfer.Head_Id,tblHead.Head_Name,tbltransfer.TrfNo " & _
        "from tbltransfer left outer join tblHead on tbltransfer.Head_Id = tblHead.Head_Id left outer join tblSupervisor on tbltransfer.Sup_Id = tblSupervisor.Sup_Id " & _
        "where tbltransfer.Factory = '" & MFactory & _
        "' Order By tbltransfer.TrfDate DESC,tbltransfer.Head_Id,tbltransfer.TrfNo"

        'tbltransfer.Trfdate = Convert(datetime,'" & _
        'DateTimePicker1.Text & "',103)  And 

        da = New SqlDataAdapter(sqlfact, Conn)
        da.Fill(ds, "Trans1")

        nCurRecFact = CType(Me.BindingContext(ds, "Trans1"), CurrencyManager)
        If ds.Tables("Trans1").Rows.Count > 0 Then
            nCurRecFact.Position = 0
        End If
        txtSearchFact.Text = ""
        Panel2.Show()
        Panel2.Left = CmdFind.Right
        Panel2.Top = CmdFind.Bottom
        dgLookUpFact.DataSource = Nothing
        OrderGridFact()
        txtSearchFact.Focus()
    End Sub

    Private Sub OrderGridFact()
        Dim SupTS As New DataGridTableStyle
        With SupTS
            .MappingName = "Trans1"
            .AllowSorting = False
            .AlternatingBackColor = Color.AliceBlue
        End With

        Dim ColTrfDate As New DataGridTextBoxColumn
        With ColTrfDate
            .MappingName = "TrfDate"
            .Format = "d"
            .HeaderText = "วันที่"
            .Width = 75
            .ReadOnly = True
        End With
        SupTS.GridColumnStyles.Add(ColTrfDate)

        Dim ColSup_Id As New DataGridTextBoxColumn
        With ColSup_Id
            .HeaderText = "รหัสSup"
            .MappingName = "Sup_Id"
            .ReadOnly = True
            .Width = 65
            .ReadOnly = True
        End With
        SupTS.GridColumnStyles.Add(ColSup_Id)

        Dim ColSup_Name As New DataGridTextBoxColumn
        With ColSup_Name
            .HeaderText = "ชื่อSup"
            .MappingName = "Sup_Name"
            .ReadOnly = True
            .Width = 150
        End With
        SupTS.GridColumnStyles.Add(ColSup_Name)

        Dim ColTrfNo As New DataGridTextBoxColumn
        With ColTrfNo
            .HeaderText = "ชุด"
            .MappingName = "TrfNo"
            .ReadOnly = True
            .Width = 50
        End With
        SupTS.GridColumnStyles.Add(ColTrfNo)

        With dgLookUpFact
            .TableStyles.Clear()
            .CaptionText = "Transfer List"
            .TableStyles.Add(SupTS)
            .ReadOnly = True
            '.FlatMode = True
            .DataSource = ds.Tables("Trans1")
            .AllowSorting = False
            .AllowNavigation = True
        End With
    End Sub

    Private Sub txtSearchFact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFact.KeyDown
        If e.KeyCode = Keys.Escape Then
            Panel2.Hide()
            DateTimePicker1.Focus()
        Else
            If e.KeyCode = Keys.Enter Then
                DateTimePicker1.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfDate"))
                CbSup_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Id") & " " & _
                ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Name"))
                'CbHead_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Id") & " " & _
                'ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Name"))
                CbTrfNo.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfNo"))
                Panel2.Hide()
            End If
        End If
    End Sub

    Private Sub txtSearchFact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFact.KeyUp
        Dim i As Integer = 0
        Dim lFound As Boolean = False
        For i = 0 To ds.Tables("Trans1").Rows.Count - 1
            If UCase(txtSearchFact.Text) = UCase(Mid(CStr(ds.Tables("Trans1").Rows(i).Item(0)), 1, Len(Trim(txtSearchFact.Text)))) Then
                nCurRecFact.Position = i
                dgLookUpFact.CurrentRowIndex = i
                lFound = True
                Exit For
            End If
            nCurRecFact.Position += 1
        Next
        If lFound = False Then
            For i = 0 To ds.Tables("Trans1").Rows.Count - 1
                Try
                    If UCase(txtSearchFact.Text) = UCase(Mid(CStr(ds.Tables("Trans1").Rows(i).Item(1)), 1, Len(Trim(txtSearchFact.Text)))) Then
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

    Private Sub dgLookUpFact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgLookUpFact.KeyDown
        DateTimePicker1.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfDate"))
        CbSup_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Id") & " " & _
        ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Sup_Name"))
        'CbHead_Id.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Id") & " " & _
        'ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Head_Name"))
        CbTrfNo.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfNo"))
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub Panel2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.LostFocus
        ds.Tables("Trans1").Clear()
    End Sub

    Private Sub LoadTimeData()
        'Check Old Exist Data
        Dim SqlTime2 As String
        Dim SqlLog As String
        SqlTime2 = "Select * From tblHome where t_date = Convert(datetime,'" & DateTimePicker1.Text & "',103) "
        da = New SqlDataAdapter(SqlTime2, Conn)
        da.Fill(ds, "Time2")
        If ds.Tables("Time2").Rows.Count <> 0 Then
            ds.Tables("Time2").Clear()
            Exit Sub
        Else
            ds.Tables("Time2").Clear()
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.Refresh()

        Date1 = DateTimePicker1.Value
        Date2 = DateAdd(DateInterval.Day, 1, Date1)
        FileNm1 = IIf(Len(Date1.Day.ToString) = 1, "0" + Date1.Day.ToString, Date1.Day) & _
                  MonthName(Date1.Month, True) & Microsoft.VisualBasic.Right(Date1.Year, 2)
        FileNm2 = IIf(Len(Date2.Day.ToString) = 1, "0" + Date2.Day.ToString, Date2.Day) & _
                  MonthName(Date2.Month, True) & Microsoft.VisualBasic.Right(Date2.Year, 2)
        FileNm3 = Microsoft.VisualBasic.Right(Date1, 2) & _
                  Microsoft.VisualBasic.Mid(Date1, 4, 2) & Microsoft.VisualBasic.Left(Date1, 2)
        FileNm4 = Microsoft.VisualBasic.Right(Date2, 2) & _
              Microsoft.VisualBasic.Mid(Date2, 4, 2) & Microsoft.VisualBasic.Left(Date2, 2)
        Label4.Text = "Loading.." & Date1
        Label4.Refresh()
        LoadData1()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        SqlLog = "สร้างข้อมูลเวลา วันที่ " & DateTimePicker1.Text
        SaveLog(SqlLog)

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

    Private Sub CbTrfNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbTrfNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbSup_Id.Focus()
        End If
    End Sub

    Private Sub CbTrfNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbTrfNo.TextChanged
        ChkHead()
        Up_DataGrid()
        Up_DataGrid2()
    End Sub

    Private Sub CbTrfNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbTrfNo.Validated
        CbTrfNo.Text = UCase(CbTrfNo.Text)
    End Sub

    Private Sub CbShift_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbShift.TextChanged
        Dim SqlStr As String
        SqlStr = "SELECT tblStaff.Shift_Id,tblShift.Shift_In,tblShift.Shift_Out FROM tblStaff " & _
        "Left Outer Join tblShift On tblStaff.Shift_Id = tblShift.Shift_Id Where tblShift.Shift_Id = '" & Microsoft.VisualBasic.Left(CbShift.Text, 3) & "' Order by tblStaff.Stid"
        da = New SqlDataAdapter(SqlStr, Conn)
        da.Fill(ds, "Staff5")
        If ds.Tables("Staff5").Rows.Count <> 0 Then
            MShift_ID = ds.Tables("Staff5").Rows(0).Item("Shift_ID")
            DTTime_Start.Text = ds.Tables("Staff5").Rows(0).Item("Shift_In")
            DTTime_End.Text = ds.Tables("Staff5").Rows(0).Item("Shift_Out")
        End If
        ds.Tables("Staff5").Clear()
    End Sub

    Private Sub CmdCosCen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCosCen.Click
        Dim SqlSave As String
        Dim dept_id2 = getDeptIDFomrCBB(CbDep_Id2.Text)
        '==== Lock ปิดงวด
        Dim sqlLock As String
        sqlLock = "SELECT * FROM tblLock WHERE Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlLock, Conn)
        da.Fill(ds, "Lock1")
        If ds.Tables("Lock1").Rows.Count <> 0 Then
            If DateTimePicker1.Value <= CStr(ds.Tables("Lock1").Rows(0).Item("LockDate")) Then
                MessageBox.Show("วันที่ " & DateTimePicker1.Text & " ปิดงวดไปแล้ว ไม่สามารถแก้ไขได้ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ds.Tables("Lock1").Clear()
                Exit Sub
            End If
        End If
        ds.Tables("Lock1").Clear()

        SqlSave = "UPDATE tblTransfer SET "
        ' SqlSave &= "Dep_Id2 = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 10) & "'"
        SqlSave &= "Dep_Id2 = '" & dept_id2 & "'"
        SqlSave &= " WHERE Trfdate = Convert(datetime,'" & DateTimePicker1.Text & "',103)"
        SqlSave &= " And Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        SqlSave &= " And TrfNo = '" & CbTrfNo.Text & "' And Factory = '" & MFactory & "'"

        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlSave
            .ExecuteNonQuery()
        End With

        Up_DataGrid2()
    End Sub
End Class