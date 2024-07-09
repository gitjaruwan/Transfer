Imports Microsoft.VisualBasic.Strings
Imports System.Math

Module Module1
    Public ConStr As String = SqlConn()
    Dim cStrConnSql As String
    Public sw1 As Integer
    Public CnnStr As String
    Public MyPath As String
    Public DataPath As String
    Public ActTxt As String
    Public DBath As String
    Public CBath As String
    Public BBath As String
    Public Stang As String
    Public LastItem As Integer
    Public StrHd As String
    Public MServer As String
    Public MOldServer As String
    Public MUserID As String
    Public MPassWord As String
    Public MDataBase As String
    Public MFactory As String
    Public MFactName As String
    Public MFactAddr As String
    Public XShud As String
    Public IstxtId1 As Boolean = True
    Public XShudA As Boolean = False
    Public XShudB As Boolean = False
    Public XShudC As Boolean = False
    Public XShudD As Boolean = False
    Public XShudE As Boolean = False
    Public MTimePath, MTimePath2, MTimePath3, MPicPath As String

    Public SelTab, MDoc_Type, MDoc_No, BalTab, BalTab2 As String
    Public MFact, MFact_Sub, MFact_Num, MFact_Addr, MFact_Month, MFact_Year, _
    MFact_In, MFact_Out, MFact_Aj, MFact_Car, MFact_Cod, MFact_C1, _
    MFact_Tax, MFCODE As String
    Public MFact_Ctrl As Date

    Public File_Nm1, File_Nm2, SelFlex, TimePath1 As String

    Public Function SqlConn() As String
        Try
            'MessageBox.Show(My.Application.Info.DirectoryPath & "\SERVER.TXT", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'If Dir(My.Application.Info.DirectoryPath & "\SERVER.TXT") <> "" Then
            'Dim aFile1 As New System.IO.FileInfo(My.Application.Info.DirectoryPath & "\SERVER.TXT")
            'Dim aStream1 As System.IO.Stream
            ' aStream1 = aFile1.OpenRead()
            ' Dim aStreamRead As New System.IO.StreamReader(aStream1)
            ' If aFile1.Exists Then
            'The First Line is Sql Connection
            'MServer = aStreamRead.ReadLine
            'MOldServer = aStreamRead.ReadLine
            'MUserID = aStreamRead.ReadLine
            'MPassWord = aStreamRead.ReadLine
            'MDataBase = aStreamRead.ReadLine
            'MFactory = aStreamRead.ReadLine
            'MFactName = aStreamRead.ReadLine
            'MFactAddr = aStreamRead.ReadLine
            'MTimePath = aStreamRead.ReadLine
            'MTimePath2 = aStreamRead.ReadLine
            'MTimePath3 = aStreamRead.ReadLine
            'End If
            'Else
            If Dir("C:\DbConnect\SERVER.TXT") <> "" Then
                Dim aFile2 As New System.IO.FileInfo("C:\DbConnect\SERVER.TXT")
                Dim aStream2 As System.IO.Stream
                aStream2 = aFile2.OpenRead()
                Dim aStreamRead2 As New System.IO.StreamReader(aStream2)
                MServer = aStreamRead2.ReadLine
                MOldServer = aStreamRead2.ReadLine
                MUserID = aStreamRead2.ReadLine
                MPassWord = aStreamRead2.ReadLine
                MDataBase = aStreamRead2.ReadLine
                MFactory = aStreamRead2.ReadLine
                MFactName = aStreamRead2.ReadLine
                MFactAddr = aStreamRead2.ReadLine
                MTimePath = aStreamRead2.ReadLine
                MTimePath2 = aStreamRead2.ReadLine
                MTimePath3 = aStreamRead2.ReadLine
            End If
            'End If

            Select Case MFactory
                Case "OKF"
                    MFactName = "บริษัท โอคินอสฟู้ด จำกัด"
                    MFactAddr = "85 หมู่4 ตำบลนาดี อำเภอเมือง จังหวัดสมุทรสาคร 74000"
                Case "AS"
                    MFactName = "บริษัท แพ็คฟู้ด จำกัด (5)"
                    MFactAddr = "57/4 หมู่4 ต.โคกขาม อ.เมือง จ.สมุทรสาคร 74000"
            End Select
            cStrConnSql = "Data Source=" & MServer & ";Initial Catalog=" & MDataBase & ";User ID=" & MUserID & ";Password=" & MPassWord
            'MsgBox(MFactory)
        Catch
            MessageBox.Show("Can not access database")
        End Try
        Return cStrConnSql
    End Function

    Public Function TextMonth(ByVal T$)
        Dim TxtMonth As String = ""
        Select Case T$
            Case "01"
                TxtMonth = "มกราคม"
            Case "02"
                TxtMonth = "กุมภาพันธ์"
            Case "03"
                TxtMonth = "มีนาคม"
            Case "04"
                TxtMonth = "เมษายน"
            Case "05"
                TxtMonth = "พฤษภาคม"
            Case "06"
                TxtMonth = "มิถุนายน"
            Case "07"
                TxtMonth = "กรกฎาคม"
            Case "08"
                TxtMonth = "สิงหาคม"
            Case "09"
                TxtMonth = "กันยายน"
            Case "10"
                TxtMonth = "ตุลาคม"
            Case "11"
                TxtMonth = "พฤศจิกายน"
            Case "12"
                TxtMonth = "ธันวาคม"
        End Select
        TextMonth = TxtMonth
    End Function

    Public Function BahtText1(ByVal tbath)
        Dim BahtTxt As String = ""
        BBath = ""
        DBath = ""
        Stang = ""
        CBath = LTrim(Str(Int(tbath)))
        DBath = LTrim(Str(Int(Round((Round(tbath, 2) - Int(tbath)), 2) * 100)))

        Dim n As Integer = 1
        sw1 = 1
        If tbath = 0 Then
            BahtTxt = "ศูนย์บาท"
        End If
        If tbath = Int(tbath) Then
            Cal_Bath()
            BahtTxt = LTrim(BBath) + "บาทถ้วน"
        End If
        If tbath < 1 Then
            Cal_Stang()
            BahtTxt = LTrim(Stang) + "สตางค์"
        End If
        If tbath - Int(tbath) <> 0 Then
            Cal_Bath()
            Cal_Stang()
            BahtTxt = LTrim(BBath) + "บาท" + LTrim(Stang) + "สตางค์"
        End If
        BahtText1 = BahtTxt
    End Function

    Public Sub Cal_Bath()
        Dim lak As String = ""
        Dim n As Integer = 1
        For n = 1 To Len(CBath)
            Dim buff As String = Mid(CBath, n, 1)
            Select Case Len(CBath) - n
                Case 0
                    lak = ""
                Case 1
                    lak = "สิบ"
                Case 2
                    lak = "ร้อย"
                Case 3
                    lak = "พัน"
                Case 4
                    lak = "หมื่น"
                Case 5
                    lak = "แสน"
                Case 6
                    lak = ""
                Case 7
                    lak = "สิบ"
                Case 8
                    lak = "ร้อย"
                Case 9
                    lak = "พัน"
                Case 10
                    lak = "หมื่น"
                Case 11
                    lak = "แสน"
            End Select
            If Len(CBath) - n = 6 Then
                lak = lak + "ล้าน"
            End If

            Select Case buff
                Case "0"
                    If Len(CBath) - n = 6 Then
                        BBath = BBath + "" + lak
                    End If
                    sw1 = 1
                Case "1"
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        BBath = BBath + lak
                        sw1 = 0
                    Else
                        If sw1 = 0 Then
                            BBath = BBath + "เอ็ด" + lak
                            sw1 = 1
                        Else
                            BBath = BBath + "หนึ่ง" + lak
                        End If
                    End If
                Case "2"
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        BBath = BBath + "ยี่" + lak
                        sw1 = 0
                    Else
                        BBath = BBath + "สอง" + lak
                        sw1 = 1
                    End If
                Case "3"
                    BBath = BBath + "สาม" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "4"
                    BBath = BBath + "สี่" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "5"
                    BBath = BBath + "ห้า" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "6"
                    BBath = BBath + "หก" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "7"
                    BBath = BBath + "เจ็ด" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "8"
                    BBath = BBath + "แปด" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
                Case "9"
                    BBath = BBath + "เก้า" + lak
                    If Len(CBath) - n = 1 Or Len(CBath) - n = 7 Then
                        sw1 = 0
                    Else
                        sw1 = 1
                    End If
            End Select
        Next n
    End Sub

    Public Sub Cal_Stang()
        Dim n As Integer = 1
        sw1 = 1
        Dim div As String = ""
        For n = 1 To Len(DBath)
            Dim buff1 As String = Mid(DBath, n, 1)
            Select Case Len(DBath) - n
                Case 0
                    div = ""
                Case 1
                    div = "สิบ"
            End Select
            Select Case buff1
                Case "0"
                    sw1 = 1
                Case "1"
                    If Len(DBath) - n = 1 Then
                        Stang = Stang + div
                        sw1 = 0
                    Else
                        If sw1 = 0 Then
                            Stang = Stang + "เอ็ด" + div
                            sw1 = 1
                        Else
                            Stang = Stang + "หนึ่ง" + div
                        End If
                    End If
                Case "2"
                    If Len(DBath) - n = 1 Then
                        Stang = Stang + "ยี่" + div
                        sw1 = 0
                    Else
                        Stang = Stang + "สอง" + div
                    End If
                Case "3"
                    Stang = Stang + "สาม" + div
                    sw1 = 0
                Case "4"
                    Stang = Stang + "สี่" + div
                    sw1 = 0
                Case "5"
                    Stang = Stang + "ห้า" + div
                    sw1 = 0
                Case "6"
                    Stang = Stang + "หก" + div
                    sw1 = 0
                Case "7"
                    Stang = Stang + "เจ็ด" + div
                    sw1 = 0
                Case "8"
                    Stang = Stang + "แปด" + div
                    sw1 = 0
                Case "9"
                    Stang = Stang + "เก้า" + div
                    sw1 = 0
            End Select
        Next n
    End Sub

    Public Sub FreezeBand(ByVal band As DataGridViewBand)
        '=========For Freeze Column=============
        band.Frozen = True
        Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
        style.BackColor = Color.WhiteSmoke
        band.DefaultCellStyle = style
    End Sub

    Public Function DateToStringTH(ByVal _Date As DateTime) As String
        Dim result As String = ""
        Try
            If Not IsDBNull(_Date) Then
                Dim yyyy As String = _Date.ToString("yyyy")
                If Val(yyyy) < 2500 Then
                    result = _Date.ToString("dd/MM") & "/" & Val(yyyy) + 543
                Else
                    result = _Date.ToString("dd/MM/yyyy")
                End If
            End If
        Catch
            result = ""
        End Try
        Return result
    End Function


    Public Function getDeptIDFomrCBB(ByVal val As String) As String
        Dim dept_id As String = ""

        If val.Trim.Length > 0 Then
            Dim strArr() As String = val.Split(" "c)
            If strArr.Length > 0 Then
                If IsNumeric(strArr(0)) Then
                    dept_id = strArr(0)
                End If
            End If
        End If

        Return dept_id
    End Function

End Module
