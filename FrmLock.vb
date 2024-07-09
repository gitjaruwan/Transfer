Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmLock
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
            CmdPrt.Focus()
        End If
    End Sub

  
    Private Sub FrmLock_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        DateTimePicker1.Focus()
    End Sub

    Private Sub FrmLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = SqlConn()
            .Open()
        End With
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        DateTimePicker1.Value = Now

        Dim sqlDep_Id As String
        sqlDep_Id = "SELECT * FROM tblLock WHERE Factory = '" & MFactory & "'"
        '"' And LockDate = Convert(datetime,'" & DateTimePicker1.Text & "',103) "
        da = New SqlDataAdapter(sqlDep_Id, Conn)
        da.Fill(ds, "Dep1")
        If ds.Tables("Dep1").Rows.Count <> 0 Then
            DateTimePicker1.Value = CStr(ds.Tables("Dep1").Rows(0).Item("LockDate"))
        End If
        ds.Tables("Dep1").Clear()
        Me.CenterToScreen()

    End Sub

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrt.Click
        Dim sqlSave As String

        sqlSave = "UPDATE tblLock SET "
        sqlSave &= "LockDate = convert(datetime,'" & DateTimePicker1.Text & "',103) "
        sqlSave &= " WHERE Factory = '" & MFactory & "'"


        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = sqlSave
            .ExecuteNonQuery()
        End With
        Me.Close()
    End Sub


End Class