Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmLogFiles
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
    Dim nCurRecFact As CurrencyManager
    Dim MFilter As String = ""
    Dim MIsDoe As Boolean = False
    Dim MIsTrDate As Boolean = False
    Dim ColMisType As New DataGridViewComboBoxColumn
    Dim dvMisType = New DataView(ds.Tables("MisType1"))
    Dim dvMisTypeFiltered = New DataView(ds.Tables("MisType1"))
    Dim ColMisDetail As New DataGridViewComboBoxColumn
    Dim dvMisDetail = New DataView(ds.Tables("MisDetail1"))
    Dim dvMisDetailFiltered = New DataView(ds.Tables("MisDetail1"))

    Private Sub FrmLogFiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With

        Dim sqlDoc As String
        sqlDoc = "SELECT * FROM tblPassword"
        da = New SqlDataAdapter(sqlDoc, Conn)
        da.Fill(ds, "User1")
        If ds.Tables("User1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("User1").Rows.Count - 1
                CbFcode.Items.Add(ds.Tables("User1").Rows(i).Item("FCode"))
            Next
        End If
        'CbShift.Text = ds.Tables("Shift1").Rows(0).Item("Shift_Id")
        ds.Tables("User1").Clear()
        CbFcode.Text = ""

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        DateTimePicker1.Value = Now.Date
        DateTimePicker2.Value = Now.Date

        MIsTrDate = False
        MIsDoe = False
        Clear_Tab()
    End Sub

    Private Sub GetData_Update(ByVal selectCommand As String)
        '=============Data For UpDate=================
        'เพราะ SqlCommandBuilder Update ได้ table เดียว ไม่สามารถ Update หลาย table join กันได้
        'แก้ไขโดย แยก DataAdapter Same Dataset
        da2 = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder As New SqlCommandBuilder(da2)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        da2.Fill(table)
        Me.bindingSource1.DataSource = table
        Me.bindingSource1.AllowNew = False
    End Sub

    Private Sub Clear_Tab()
        MFilter = " Where Log_date >= Convert(datetime,'" & DateTimePicker1.Text & _
          "',103) and Log_date <= Convert(datetime,'" & DateAdd(DateInterval.Day, 1, DateTimePicker2.Value) & "',103) And Factory = '" & MFactory & "'"

        If CbFcode.Text <> "" Then
            MFilter = MFilter + " And Log_Id = '" & Microsoft.VisualBasic.Left(CbFcode.Text, 20) & "'"
        End If
        MFilter = MFilter + " Order By Log_Date" 'DESC  ASC

        table.Clear()
        'ds.Tables("User1").Clear()

        GetData_Update("SELECT * FROM tblLog  " & MFilter)
        '============Data To DisPlay =================
        GetData("SELECT * FROM tblLog " & MFilter)
        bindingSource1.Position = table.Rows.Count - 1
        DataGridView1.Refresh()
        DataGridView1.Focus()
        Label15.Text = "รวม   " & Format(DataGridView1.RowCount, "#,#") & " รายการ"
    End Sub

    Private Sub GetData(ByVal selectCommand As String)
        '============Data To DisPlay =================
        da = New SqlDataAdapter(selectCommand, Conn)
        Dim commandBuilder As New SqlCommandBuilder(da)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        'da.Fill(table)
        Me.bindingSource1.DataSource = table
        Me.bindingSource1.AllowNew = False

        With DataGridView1
            If .DataSource IsNot DBNull.Value Then
                .DataSource = ""
                .Columns.Clear()
            End If

            .DataSource = Me.bindingSource1
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .EditMode = DataGridViewEditMode.EditOnEnter

            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next

            Dim ColLog_Date As New CalendarColumn2
            With ColLog_Date
                .DataPropertyName = "Log_Date"
                .DefaultCellStyle.Format = "d"
                .HeaderText = "วันที่"
                .Width = 85
                .ReadOnly = True
            End With
            .Columns.Add(ColLog_Date)
            'FreezeBand(ColMis_Date)

            Dim ColLog_Time As New DataGridViewTextBoxColumn
            With ColLog_Time
                .DataPropertyName = "Log_Date"
                .DefaultCellStyle.Format = "t"
                .HeaderText = "เวลา"
                .Width = 60
                .ReadOnly = True
            End With
            .Columns.Add(ColLog_Time)


            Dim ColLog_Id As New DataGridViewTextBoxColumn
            With ColLog_Id
                .DataPropertyName = "Log_Id"
                .HeaderText = "ผู้ใช้โปรแกรม"
                .Width = 100
                .ReadOnly = True
            End With
            .Columns.Add(ColLog_Id)

            Dim ColLog_Detail As New DataGridViewTextBoxColumn
            With ColLog_Detail
                .DataPropertyName = "Log_Detail"
                .HeaderText = "รายละเอียด"
                .Width = 750
                .ReadOnly = True
            End With
            .Columns.Add(ColLog_Detail)

        End With
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        'MsgBox(DataGridView1.CurrentCell.ColumnIndex)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Enter Or keyData = Keys.Return Then
            keyData = (Keys.Shift And Keys.Enter)
            'DataGridView1.CurrentCell.Value += Environment.NewLine
            'SendKeys.Send("{End}")
            SendKeys.Send("{Right}")
            With msg
                .WParam = (Keys.Shift And Keys.Enter)
            End With
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub FrmLogFiles_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'cmdPrt.Location = New Point(cmdPrt.Location.X, Me.Height - 65)
        'CmdExit.Location = New Point(CmdExit.Location.X, Me.Height - 65)
        Label15.Location = New Point(Label15.Location.X, Me.Height - 65)
    End Sub


    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
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

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        'saveData()
    End Sub


    Private Sub CbFcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbFcode.TextChanged
        Dim sqlDoc As String
        sqlDoc = "SELECT * FROM tblPassword Where FCode = '" & CbFcode.Text & "'"
        da = New SqlDataAdapter(sqlDoc, Conn)
        da.Fill(ds, "User2")
        If ds.Tables("User2").Rows.Count <> 0 Then
            Label1.Text = ds.Tables("User2").Rows(0).Item("FName")
        End If
        ds.Tables("User2").Clear()
        MIsDoe = False
        MIsTrDate = True
        Clear_Tab()
    End Sub

    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        MIsDoe = False
        MIsTrDate = True
        Clear_Tab()
    End Sub

    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged
        MIsDoe = False
        MIsTrDate = True
        Clear_Tab()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim RpTDep As New PrtDep
        Dim MFormula, MParamFil As String
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTDep.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
                And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTDep.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTDep.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)

        MFormula = ""
        MParamFil = ""
        MFormula = "{tblLog.Log_date} in Date ('" & DateTimePicker1.Text & "') to Date ('" & DateTimePicker2.Text & "')"

        If CbFcode.Text <> "" Then
            MFormula = MFormula + " And {tblLog.Log_Id} = '" & Microsoft.VisualBasic.Left(CbFcode.Text, 20) & "'"
            MParamFil = MParamFil + " ผู้ใช้โปรแกรม " & CbFcode.Text
        End If

        With CRVDep
            .ReportSource = RpTDep
            .SelectionFormula = MFormula
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamFil)
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

    Private Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        MIsDoe = False
        MIsTrDate = True
        Clear_Tab()
    End Sub
End Class