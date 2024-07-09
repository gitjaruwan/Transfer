'=== Program Convert To Taff And Dat
'=== By Kamol Srisomphan
'=== 23/11/2017

'11370001 Microsoft.VisualBasic.Mid(objReader.ReadLine(), 3, 8)
'YYYY Microsoft.VisualBasic.Mid(objReader.ReadLine(), 12, 4)
'YY Microsoft.VisualBasic.Mid(objReader.ReadLine(), 14, 2)
'MM Microsoft.VisualBasic.Mid(objReader.ReadLine(), 16, 2)
'DD Microsoft.VisualBasic.Mid(objReader.ReadLine(), 18, 2)
'HH Microsoft.VisualBasic.Mid(objReader.ReadLine(), 20, 2)
'MM Microsoft.VisualBasic.Mid(objReader.ReadLine(), 22, 2)
'DDMMMYY.TAFF 34604463 20171025 0406 08
'YYMMDD.DAT   23600002  201711070559 09

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmUpdStaf1
    Dim IsDat As Boolean = True
    Dim StrSql As String
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim da2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim table As New DataTable()
    Dim MFact As String
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim IsFindEmp As Boolean = False
    Dim MFilter As String = ""


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        IsDat = False
        OpenFileDialog1.Filter = "Text File|*.TXT|All File|*.*"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim FILE_NAME As String = TextBox1.Text

        If TextBox1.Text = "" Then
            MsgBox("Please Select Import File.. ")
            TextBox1.Focus()
            Exit Sub
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'If System.IO.Directory.Exists("C:\TEMP\") Then
        'System.IO.Directory.CreateDirectory("C:\TEMP\")
        'End If

        File.Copy(FILE_NAME, "\\210.1.56.25\hrokf\TransFerPub\TmpShift.TXT", True)

        'MsgBox("01/" & returnMonthNum(ComboBox1.Text) & "/" & ComboBox2.Text)
        If System.IO.File.Exists("\\210.1.56.25\hrokf\TransFerPub\TmpShift.TXT") = True Then
            Dim sqlSave As String
            sqlSave = "Delete From TmpShift "
            With ComSave
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = "Set DateFormat 'DMY'"
                .ExecuteNonQuery()
                .CommandText = sqlSave
                .ExecuteNonQuery()
            End With

            sqlSave = "BULK INSERT dbo.TmpShift FROM '" & "\\210.1.56.25\hrokf\TransFerPub\TmpShift.TXT" & "'" & _
            "WITH (FIRSTROW = 2,FIELDTERMINATOR = '\t' ,ROWTERMINATOR = '\n',KEEPNULLS);"
            With ComSave
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = "Set DateFormat 'DMY'"
                .ExecuteNonQuery()
                .CommandText = sqlSave
                .ExecuteNonQuery()
            End With

            sqlSave = "update tblStaff set" & _
                      " tblStaff.Shift_Id = tmpShift.Shift_Id," & _
                      "tblStaff.Pos_All = tmpShift.Pos_All" & _
                      " from tblStaff inner join TmpShift on tblStaff.StId = tmpShift.StId" & _
                      " where tblStaff.factory = '" & MFactory & "'"
            With ComSave
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = "Set DateFormat 'DMY'"
                .ExecuteNonQuery()
                .CommandText = sqlSave
                .ExecuteNonQuery()
            End With
        Else
            MessageBox.Show("File Does Not Exist")
        End If
        'ProgressBar1.Visible = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Close()
    End Sub

    Private Sub SaveLog(ByVal LogStr1 As String)
        Dim SqlStr As String
        SqlStr = "Insert  into TblLog(Log_Id,Log_Date,Log_Detail) Values('" & MFCODE & "',convert(datetime,'" & _
            Now & "',103),'" & LogStr1 & "')"
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = SqlStr
            .ExecuteNonQuery()
        End With
    End Sub

    Public Function ReadALine(ByVal File_Path As String, ByVal TotalLine As Integer, ByVal Line2Read As Integer) As String
        Dim Buffer As Array
        Dim Line As String
        If TotalLine <= Line2Read Then
            Return "No Such Line"
        End If
        Buffer = File.ReadAllLines(File_Path)
        Line = Buffer(Line2Read)
        Return Line
    End Function

    Public Function GetNumberOfLines(ByVal file_path As String) As Integer
        Dim sr As New StreamReader(file_path)
        Dim NumberOfLines As Integer
        Do While sr.Peek >= 0
            sr.ReadLine()
            NumberOfLines += 1
        Loop
        Return NumberOfLines
        sr.Close()
        sr.Dispose()
    End Function

    Private Sub FrmUpdStaf1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With
        Me.CenterToScreen()
    End Sub

    Public Function returnMonthNumber(ByVal monthName As String) As String
        Select Case monthName.ToLower
            Case Is = "jan"
                Return "01"
            Case Is = "feb"
                Return "02"
            Case Is = "mar"
                Return "03"
            Case Is = "apr"
                Return "04"
            Case Is = "may"
                Return "05"
            Case Is = "jun"
                Return "06"
            Case Is = "jul"
                Return "07"
            Case Is = "aug"
                Return "08"
            Case Is = "sep"
                Return "09"
            Case Is = "oct"
                Return "10"
            Case Is = "nov"
                Return "11"
            Case Is = "dec"
                Return "12"
            Case Else
                Return "00"
        End Select
    End Function

    Public Function returnMonthName(ByVal monthNum As String) As String
        Select Case monthNum
            Case Is = "1"
                Return "January"
            Case Is = "2"
                Return "February"
            Case Is = "3"
                Return "March"
            Case Is = "4"
                Return "April"
            Case Is = "5"
                Return "May"
            Case Is = "6"
                Return "June"
            Case Is = "7"
                Return "July"
            Case Is = "8"
                Return "August"
            Case Is = "9"
                Return "September"
            Case Is = "10"
                Return "October"
            Case Is = "11"
                Return "November"
            Case Is = "12"
                Return "December"
            Case Else
                Return " "
        End Select
    End Function

    Public Function returnMonthNum(ByVal monthName As String) As String
        Select Case monthName
            Case Is = "January"
                Return "01"
            Case Is = "February"
                Return "02"
            Case Is = "March"
                Return "03"
            Case Is = "April"
                Return "04"
            Case Is = "May"
                Return "05"
            Case Is = "June"
                Return "06"
            Case Is = "July"
                Return "07"
            Case Is = "August"
                Return "08"
            Case Is = "September"
                Return "09"
            Case Is = "October"
                Return "10"
            Case Is = "November"
                Return "11"
            Case Is = "December"
                Return "12"
            Case Else
                Return "00"
        End Select
    End Function

    Private Sub CmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
End Class
