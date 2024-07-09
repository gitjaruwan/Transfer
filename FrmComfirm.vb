Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmConfirm
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
        sqlDep_Id = "SELECT * FROM tblDepartment WHERE Factory = '" & MFactory & "' Order By Dep_Id"
        da = New SqlDataAdapter(sqlDep_Id, Conn)
        da.Fill(ds, "Dep1")
        If ds.Tables("Dep1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Dep1").Rows.Count - 1
                CbDep_Id.Items.Add(ds.Tables("Dep1").Rows(i).Item("Dep_Id") & " " & _
                            ds.Tables("Dep1").Rows(i).Item("Dep_Th"))

                CbDep_Id2.Items.Add(ds.Tables("Dep1").Rows(i).Item("Dep_Id") & " " & _
            ds.Tables("Dep1").Rows(i).Item("Dep_Th"))

            Next
        End If
        CbDep_Id.Text = ""
        ds.Tables("Dep1").Clear()


        CbTrfNo.Items.Add("A")
        CbTrfNo.Items.Add("B")
        CbTrfNo.Items.Add("C")
        CbTrfNo.Items.Add("D")
        CbTrfNo.Items.Add("E")
        CbTrfNo.Items.Add("F")
        CbTrfNo.Items.Add("G")
        CbTrfNo.Items.Add("H")
        CbTrfNo.Items.Add("I")
        CbTrfNo.Items.Add("J")
        CbTrfNo.Items.Add("K")
        CbTrfNo.Items.Add("L")
        CbTrfNo.Items.Add("M")
        CbTrfNo.Items.Add("N")
        CbTrfNo.Items.Add("O")
        CbTrfNo.Items.Add("P")
        CbTrfNo.Items.Add("Q")
        CbTrfNo.Items.Add("R")
        CbTrfNo.Items.Add("S")
        CbTrfNo.Items.Add("T")
        CbTrfNo.Items.Add("U")
        CbTrfNo.Items.Add("V")
        CbTrfNo.Items.Add("W")
        CbTrfNo.Items.Add("X")
        CbTrfNo.Items.Add("Y")
        CbTrfNo.Items.Add("Z")

        Clear_Hd()
        Clear_Det()
    End Sub

    Private Sub Clear_Hd()
        DateTimePicker1.Value = Now.Date
        CbSup_Id.Text = ""
        CbDep_Id.Text = ""
        CbDep_Id2.Text = ""
        CbHead_Id.Text = ""
        txtTrfNo.Text = ""
        CbTrfNo.Text = ""
        'CmdTransfer.Enabled = False
        'CmdReturn.Enabled = False
        'CmdSave.Enabled = False
        'DataGridView1.Enabled = False
        'CheckBox1.Enabled = False
        'CheckBox2.Enabled = False

        'Clear_Det()
        'Up_DataGrid()
        'Up_DataGrid2()
        DateTimePicker1.Focus()
    End Sub

    Private Sub Clear_Det()
        CheckBox1.Checked = False
        'CmdReturn.Enabled = False
        'CmdTransfer.Enabled = False
    End Sub

    Private Sub Up_DataGrid()
        Dim dept_id2 As String = getDeptIDFomrCBB(CbDep_Id2.Text)
        MIsCh = False
        MFilter = " Where Trfdate = Convert(datetime,'" & DateTimePicker1.Text & _
        "',103) And Dep_Id2 = '" & dept_id2 & "'"
        '  "',103) And Dep_Id2 = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 10) & "'"


        'If CbSup_Id.Text <> "" Then
        'MFilter = MFilter + " And SUP_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        'End If

        'If CbHead_Id.Text <> "" Then
        'MFilter = MFilter + " And Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        'End If
        MFilter = MFilter + " And Factory = '" & MFactory & "'"

        table.Clear()
        GetData_Update("SELECT * FROM tblTransfer " & MFilter & " Order by StId")
        GetData("SELECT  * FROM tblTransfer " & MFilter & " Order by StId")
        DataGridView1.Refresh()
        SumGrid1()
    End Sub


    Private Sub ChkHead()
        Dim sqlFact As String
        sqlFact = "SELECT * FROM tblTransfer  Where Trfdate = Convert(datetime,'" & DateTimePicker1.Text & "',103) " & _
        "and TrfNo = '" & CbTrfNo.Text & "'"

        If CbSup_Id.Text <> "" Then
            sqlFact = sqlFact + " And SUP_id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "'"
        End If

        If CbHead_Id.Text <> "" Then
            sqlFact = sqlFact + " And Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        End If
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
        Else
            CbDep_Id2.Text = ""
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
            Dim ColConfirm As New DataGridViewCheckBoxColumn
            With ColConfirm
                .DataPropertyName = "FConfirm"
                .HeaderText = "รับโอน"
                .Width = 50
            End With
            .Columns.Add(ColConfirm)

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
                .Width = 100
                .MaxInputLength = 50
                .ReadOnly = True
            End With
            .Columns.Add(ColLname_Th)
            FreezeBand(ColLname_Th)

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

            Dim ColHead_Id As New DataGridViewTextBoxColumn
            With ColHead_Id
                .DataPropertyName = "Head_Id"
                .HeaderText = "รหัส"
                .Width = 60
                .MaxInputLength = 8
                .ReadOnly = True
            End With
            .Columns.Add(ColHead_Id)

            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead WHERE Factory = '" & MFactory & "' Order By Head_Id"
            da = New SqlDataAdapter(sqlHead, Conn)
            da.Fill(ds, "Head2")
            Dim ColHead As New DataGridViewComboBoxColumn
            With ColHead
                .DataPropertyName = "Head_Id"
                .HeaderText = "ชื่อหัวหน้า"
                .Width = 200
                .DataSource = ds.Tables("Head2")
                .ValueMember = "Head_Id"
                .DisplayMember = "Head_Name"
                .DropDownWidth = 200
                .ReadOnly = True
            End With
            .Columns.Add(ColHead)

            Dim ColTrfNo As New DataGridViewTextBoxColumn
            With ColTrfNo
                .DataPropertyName = "TrfNo"
                .HeaderText = "ชุด"
                .Width = 35
                .MaxInputLength = 3
                .ReadOnly = True
            End With
            .Columns.Add(ColTrfNo)


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
        If CbHead_Id.Text <> "" Then
            MFormula = MFormula + " And {tblTransFer.Head_id} = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "'"
        End If
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

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        MIsCh = True
        DataGridView1.BindingContext(DataGridView1.DataSource).EndCurrentEdit()
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        'Try
        ''ChkDetail()
        'Catch ex As Exception
        ''แจ้งรายงานปัญหาที่เกิดขึ้น
        'End Try
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

        'If e.Control.GetType Is GetType(DataGridViewCheckBoxCell) Then
        'DataGridView1.EndEdit()
        'End If

    End Sub

    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id2.Focus()
        End If
    End Sub

    Private Sub SumGrid1()

        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer
        XNormal_Hr = 0
        XNormal_Ot = 0
        XHoliday_Ot = 0
        XIncentive = 0

        ' Iterate through all the rows and sum up the appropriate columns.
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter).Cells("Normal_Hr").Value Is Nothing Then
                If Not DataGridView1.Rows(counter).Cells("Normal_Hr").Value.ToString().Length = 0 Then
                    XNormal_Hr += DataGridView1.Rows(counter).Cells("Normal_Hr").Value
                End If
            End If
        Next
        Label21.Text = "รวมชม.ปกติ = " & Format(XNormal_Hr, "N")

        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter).Cells("Normal_Ot").Value Is Nothing Then
                If Not DataGridView1.Rows(counter).Cells("Normal_Ot").Value.ToString().Length = 0 Then
                    XNormal_Ot += DataGridView1.Rows(counter).Cells("Normal_Ot").Value
                End If
            End If
        Next
        Label22.Text = "รวมOt.ปกติ = " & Format(XNormal_Ot, "N")

        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter).Cells("Holiday_Ot").Value Is Nothing Then
                If Not DataGridView1.Rows(counter).Cells("Holiday_Ot").Value.ToString().Length = 0 Then
                    XHoliday_Ot += DataGridView1.Rows(counter).Cells("Holiday_Ot").Value
                End If
            End If
        Next
        Label23.Text = "รวมOt.นักขัตถ์ = " & Format(XHoliday_Ot, "N")

        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter).Cells("Incentive").Value Is Nothing Then
                If Not DataGridView1.Rows(counter).Cells("Incentive").Value.ToString().Length = 0 Then
                    XIncentive += DataGridView1.Rows(counter).Cells("Incentive").Value
                End If
            End If
        Next
        Label24.Text = "รวมIncentive = " & Format(XIncentive, "N")

        Label16.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " คน"

        'If DataGridView1.RowCount > 0 Then
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

    Private Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Clear_Hd()
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub dgLookUpFact_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLookUpFact.DoubleClick
        DateTimePicker1.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("TrfDate"))
        CbDep_Id2.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Id2") & " " & _
        ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Th"))
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub CbSup_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbSup_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbHead_Id.Focus()
        End If
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

    Private Sub CbHead_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbHead_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbTrfNo.Focus()
        End If
    End Sub

    Private Sub txtTrfNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrfNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id2.Focus()
        End If
    End Sub

    Private Sub CbDep_Id2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDep_Id2.KeyDown
        If e.KeyCode = Keys.Enter Then
            'CmdTransfer.Enabled = True
            Cmd_Save.Focus()
        End If
    End Sub

    Private Sub txtTrfNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrfNo.Validated
        txtTrfNo.Text = UCase(txtTrfNo.Text)
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            For counter = 0 To (DataGridView1.Rows.Count - 1)
                DataGridView1.Rows(counter).Cells("FConfirm").Value = -1
            Next
            'DataGridView1.Refresh()
        Else
            For counter = 0 To (DataGridView1.Rows.Count - 1)
                DataGridView1.Rows(counter).Cells("FConfirm").Value = 0
            Next
            'DataGridView1.Refresh()
        End If
        DataGridView1.BindingContext(DataGridView1.DataSource).EndCurrentEdit()
    End Sub

    Private Sub CbDep_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDep_Id2.TextChanged
        'ChkHead()
        Up_DataGrid()
    End Sub

    Private Sub CbTrfNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbTrfNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id2.Focus()
        End If
    End Sub

    Private Sub CbTrfNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbTrfNo.Validated
        CbTrfNo.Text = UCase(CbTrfNo.Text)
    End Sub

    Private Sub saveData()
        Dim commandBuilder1 As New SqlCommandBuilder(da2)
        Try
            'Update to GetData2
            da2.Update(CType(Me.bindingSource1.DataSource, DataTable))
            'da.Update(ds, "Staff1")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'MIsKey = False
            Up_DataGrid()
        End Try
    End Sub

    Private Sub DataGridView2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'MsgBox(DataGridView2.CurrentCell.ColumnIndex)
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        Dim SqlLog As String
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
        Up_DataGrid()
        SqlLog = "Comfirm การรับโอนคน แผนกที่รับ " & CbDep_Id2.Text & " วันที่  " & DateTimePicker1.Text
        SaveLog(SqlLog)
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
        xlWorkSheet.Cells(1, 6).Value = "หัวหน้า"
        xlWorkSheet.Cells(1, 7).Value = "รหัสต้นสังกัด"
        xlWorkSheet.Cells(1, 8).Value = "ชื่อต้นสังกัด"
        xlWorkSheet.Cells(1, 9).Value = "รหัสที่รับโอน"
        xlWorkSheet.Cells(1, 10).Value = "ชื่อที่รับโอน"
        xlWorkSheet.Cells(1, 11).Value = "ชุด"
        xlWorkSheet.Cells(1, 12).Value = "จากเวลา"
        xlWorkSheet.Cells(1, 13).Value = "ถึงเวลา"
        xlWorkSheet.Cells(1, 14).Value = "ชั่วโมงทำงาน"
        xlWorkSheet.Cells(1, 15).Value = "ชั่วโมงโอที"
        xlWorkSheet.Cells(1, 16).Value = "ชั่วโมงโอทีนักขัตถ์"
        xlWorkSheet.Cells(1, 17).Value = "ค่าแรงปกติ"
        xlWorkSheet.Cells(1, 18).Value = "ค่าโอที"
        xlWorkSheet.Cells(1, 19).Value = "Incentive"
        xlWorkSheet.Cells(1, 20).Value = "รวมค่าแรง"

        xlApp.DisplayAlerts = False
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TblStaff.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TblStaff.xls")
    End Sub

    Private Sub CmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFind.Click
        da.Fill(ds, "Trans1")
        ds.Tables("Trans1").Clear()

        Dim sqlfact As String

        sqlfact = "select distinct tbltransfer.TrfDate,tbltransfer.Dep_Id2,tblDepartment.Dep_Th,tbltransfer.FConfirm" & _
        " from tbltransfer left outer join tblDepartment on tbltransfer.Dep_Id2 = tblDepartment.Dep_Id" & _
        " where tbltransfer.Factory = '" & MFactory & _
        "' Order By tbltransfer.TrfDate DESC,tbltransfer.Dep_Id2"

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


        Dim ColConfirm As New DataGridBoolColumn
        With ColConfirm
            .MappingName = "FConfirm"
            .HeaderText = "รับโอน"
            .Width = 50
            .ReadOnly = True
        End With
        SupTS.GridColumnStyles.Add(ColConfirm)


        Dim ColTrfDate As New DataGridTextBoxColumn
        With ColTrfDate
            .MappingName = "TrfDate"
            .Format = "d"
            .HeaderText = "วันที่"
            .Width = 75
            .ReadOnly = True
        End With
        SupTS.GridColumnStyles.Add(ColTrfDate)

        Dim ColDep_Id2 As New DataGridTextBoxColumn
        With ColDep_Id2
            .HeaderText = "รหัส"
            .MappingName = "Dep_Id2"
            .ReadOnly = True
            .Width = 65
            .ReadOnly = True
        End With
        SupTS.GridColumnStyles.Add(ColDep_Id2)

        Dim ColDep_Th As New DataGridTextBoxColumn
        With ColDep_Th
            .HeaderText = "แผนกที่รับโอน"
            .MappingName = "Dep_Th"
            .ReadOnly = True
            .Width = 150
        End With
        SupTS.GridColumnStyles.Add(ColDep_Th)

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
                CbDep_Id2.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Id2") & " " & _
                ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Th"))
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
        CbDep_Id2.Text = CStr(ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Id2") & " " & _
        ds.Tables("Trans1").Rows(dgLookUpFact.CurrentRowIndex).Item("Dep_Th"))
        Panel2.Hide()
        DateTimePicker1.Focus()
    End Sub

    Private Sub Panel2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.LostFocus
        ds.Tables("Trans1").Clear()
    End Sub
End Class