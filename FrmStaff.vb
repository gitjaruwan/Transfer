Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class FrmStaff
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
    Dim ComSave As New SqlCommand
    Dim ComDel As New SqlCommand
    Dim IsFindEmp As Boolean = False
    Dim MFilter As String = ""

    Private Sub FrmStafft_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StrSql = SqlConn()
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = StrSql
            .Open()
        End With

        CbTitle_Th.Items.Clear()
        CbTitle_Th.Items.Add("นาย")
        CbTitle_Th.Items.Add("นาง")
        CbTitle_Th.Items.Add("นางสาว")

        CbTitle_En.Items.Clear()
        CbTitle_En.Items.Add("Mr.")
        CbTitle_En.Items.Add("Mrs.")
        CbTitle_En.Items.Add("Miss")


        CbNation.Items.Clear()
        CbNation.Items.Add("ไทย")
        CbNation.Items.Add("ต่างด้าว")

        CbNation2.Items.Clear()
        CbNation2.Items.Add("ไทย")
        CbNation2.Items.Add("ต่างด้าว")

        CbEmp_Th.Items.Clear()
        CbEmp_Th.Items.Add("รายวัน")
        CbEmp_Th.Items.Add("รายเดือน")

        CbWorkStatus.Items.Clear()
        CbWorkStatus.Items.Add("เป็นพนักงาน")
        CbWorkStatus.Items.Add("พ้นสภาพพนักงาน")

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
                CbSup_Id2.Items.Add(ds.Tables("Sup1").Rows(i).Item("Sup_Id") & " " & _
                           ds.Tables("Sup1").Rows(i).Item("Sup_Name"))
            Next
        End If
        CbSup_Id.Text = ""
        ds.Tables("Sup1").Clear()

        CbField_Id.Items.Clear()
        Dim sqlFieldCode As String
        sqlFieldCode = "SELECT * FROM tblField WHERE Factory = '" & MFactory & "' Order By Field_Id"
        da = New SqlDataAdapter(sqlFieldCode, Conn)
        da.Fill(ds, "Field1")
        If ds.Tables("Field1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Field1").Rows.Count - 1
                CbField_Id.Items.Add(ds.Tables("Field1").Rows(i).Item("Field_Id") & " " & _
                            ds.Tables("Field1").Rows(i).Item("Field_Th"))
            Next
        End If
        CbField_Id.Text = ""
        ds.Tables("Field1").Clear()


        CbDiv_Id.Items.Clear()
        Dim sqlDivCode As String
        sqlDivCode = "SELECT * FROM tblDivision WHERE Factory = '" & MFactory & "' Order By Div_Id"
        da = New SqlDataAdapter(sqlDivCode, Conn)
        da.Fill(ds, "Div1")
        If ds.Tables("Div1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Div1").Rows.Count - 1
                CbDiv_Id.Items.Add(ds.Tables("Div1").Rows(i).Item("Div_Id") & " " & _
                            ds.Tables("Div1").Rows(i).Item("Div_Th"))
                CbDiv_Id2.Items.Add(ds.Tables("Div1").Rows(i).Item("Div_Id") & " " & _
            ds.Tables("Div1").Rows(i).Item("Div_Th"))
            Next
        End If
        CbDiv_Id.Text = ""
        ds.Tables("Div1").Clear()


        CbDep_Id.Items.Clear()
        Dim sqlDepCode As String
        sqlDepCode = "SELECT * FROM TblDepartment WHERE Factory = '" & MFactory & "' Order By Dep_Id"
        da = New SqlDataAdapter(sqlDepCode, Conn)
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



        CbUnit_Id.Items.Clear()
        Dim sqlUnitCode As String
        sqlUnitCode = "SELECT * FROM tblUnit WHERE Factory = '" & MFactory & "' Order By Unit_Id"
        da = New SqlDataAdapter(sqlUnitCode, Conn)
        da.Fill(ds, "Unit1")
        If ds.Tables("Unit1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Unit1").Rows.Count - 1
                CbUnit_Id.Items.Add(ds.Tables("Unit1").Rows(i).Item("Unit_Id") & " " & _
                            ds.Tables("Unit1").Rows(i).Item("Unit_Th"))
                CbUnit_Id2.Items.Add(ds.Tables("Unit1").Rows(i).Item("Unit_Id") & " " & _
                            ds.Tables("Unit1").Rows(i).Item("Unit_Th"))
            Next
        End If
        CbUnit_Id.Text = ""
        ds.Tables("Unit1").Clear()



        CbType_Id.Items.Clear()
        Dim sqlTypeCode As String
        sqlTypeCode = "SELECT * FROM tblType WHERE Factory = '" & MFactory & "' Order By Type_Id"
        da = New SqlDataAdapter(sqlTypeCode, Conn)
        da.Fill(ds, "Type1")
        If ds.Tables("Type1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Type1").Rows.Count - 1
                CbType_Id.Items.Add(ds.Tables("Type1").Rows(i).Item("Type_Id") & " " & _
                            ds.Tables("Type1").Rows(i).Item("Type_Th"))
            Next
        End If
        CbType_Id.Text = ""
        ds.Tables("Type1").Clear()

        CbShift.Items.Clear()
        Dim sqlShiftCode As String
        sqlShiftCode = "SELECT * FROM tblShift WHERE Factory = '" & MFactory & "' Order By Shift_Id"
        da = New SqlDataAdapter(sqlShiftCode, Conn)
        da.Fill(ds, "Shift1")
        If ds.Tables("Shift1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Shift1").Rows.Count - 1
                CbShift.Items.Add(ds.Tables("Shift1").Rows(i).Item("Shift_Id") & "       " & _
                            Microsoft.VisualBasic.Mid(ds.Tables("Shift1").Rows(i).Item("Shift_In"), 12, 5) & " - " & Microsoft.VisualBasic.Mid(ds.Tables("Shift1").Rows(i).Item("Shift_Out"), 12, 5))
                CbShift2.Items.Add(ds.Tables("Shift1").Rows(i).Item("Shift_Id") & " " & _
                            Microsoft.VisualBasic.Mid(ds.Tables("Shift1").Rows(i).Item("Shift_In"), 12, 5) & " - " & Microsoft.VisualBasic.Mid(ds.Tables("Shift1").Rows(i).Item("Shift_Out"), 12, 5))
            Next
        End If
        CbShift.Text = ""
        ds.Tables("Shift1").Clear()


        CbPos_Id.Items.Clear()
        Dim sqlPosCode As String
        sqlPosCode = "SELECT * FROM tblPosition WHERE Factory = '" & MFactory & "' Order By Pos_Id"
        da = New SqlDataAdapter(sqlPosCode, Conn)
        da.Fill(ds, "Pos1")
        If ds.Tables("Pos1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Pos1").Rows.Count - 1
                CbPos_Id.Items.Add(ds.Tables("Pos1").Rows(i).Item("Pos_Id") & " " & _
                            ds.Tables("Pos1").Rows(i).Item("Pos_Th"))
            Next
        End If
        CbPos_Id.Text = ""
        ds.Tables("Pos1").Clear()


        CbHead_Id.Items.Clear()
        Dim sqlHeadCode As String
        sqlHeadCode = "SELECT * FROM tblHead WHERE Factory = '" & MFactory & "' Order By Head_Id"
        da = New SqlDataAdapter(sqlHeadCode, Conn)
        da.Fill(ds, "Head1")
        If ds.Tables("Head1").Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("Head1").Rows.Count - 1
                CbHead_Id.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                            ds.Tables("Head1").Rows(i).Item("Head_Name"))
                CbHead_Id2.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                           ds.Tables("Head1").Rows(i).Item("Head_Name"))
            Next
        End If
        CbHead_Id.Text = ""
        ds.Tables("Head1").Clear()


        Up_DataGrid()
        TxtStid.Text = ""
    End Sub

    Private Sub Clear_Dat()
        CbTitle_Th.Text = ""
        CbTitle_En.Text = ""
        TxtFName_Th.Text = ""
        TxtFName_En.Text = ""
        TxtLName_Th.Text = ""
        TxtLName_En.Text = ""
        CbField_Id.Text = ""
        CbDiv_Id.Text = ""
        CbDep_Id.Text = ""
        CbUnit_Id.Text = ""
        CbType_Id.Text = ""
        CbPos_Id.Text = ""
        CbEmp_Th.Text = ""
        TxtSal.Text = ""
        TxtPos_All.Text = ""
        CbSup_Id.Text = ""
        CbHead_Id.Text = ""
        CbNation.Text = ""
        CbDep_Id2.Text = ""
        CbDiv_Id2.Text = ""
        CbHead_Id2.Text = ""
        CbNation2.Text = ""
        CbSup_Id2.Text = ""
        CbUnit_Id2.Text = ""
        CbShift.Text = ""
        CbShift2.Text = ""
        CbWorkStatus.Text = ""
    End Sub

    Private Sub Up_DataGrid()
        MFilter = " "
        If CbSup_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id2.Text, 8) & "'"
        End If
        If CbHead_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id2.Text, 8) & "'"
        End If
        If CbNation2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Nationality = '" & CbNation2.Text & "'"
        End If

        If CbShift2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Shift_Id = '" & Microsoft.VisualBasic.Left(CbShift2.Text, 3) & "'"
        End If

        If CbDep_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Dep_id = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 6) & "'"
        End If
        If CbDiv_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Div_id = '" & Microsoft.VisualBasic.Left(CbDiv_Id2.Text, 2) & "'"
        End If
        If CbUnit_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Unit_id = '" & Microsoft.VisualBasic.Left(CbUnit_Id2.Text, 3) & "'"
        End If

        table.Clear()
        'ds.Tables("Fac2").Clear()
        GetData_Update("SELECT * FROM TblStaff WHERE Factory = '" & MFactory & "'" & MFilter)
        GetData("SELECT * FROM TblStaff WHERE Factory = '" & MFactory & "'" & MFilter)
        DataGridView1.Refresh()

        SumGrid1()
    End Sub

    Private Sub SumGrid1()
        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer
        Dim XThai, XMyanmar As Integer

        XThai = 0
        XMyanmar = 0

        ' Iterate through all the rows and sum up the appropriate columns.
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter).Cells("Nationality").Value Is Nothing Then
                If DataGridView1.Rows(counter).Cells("Nationality").Value.ToString() = "ไทย" Then
                    XThai += 1
                Else
                    XMyanmar += 1
                End If
            End If
        Next
        Label13.Text = "รวมไทย = " & Format(XThai, "#,#") & " คน"
        Label14.Text = "รวมพม่า = " & Format(XMyanmar, "#,#") & " คน"
        Label10.Text = "รวม = " & Format(DataGridView1.RowCount, "#,#") & " คน"

        'If DataGridView1.RowCount > 0 Then
        'CmdDel.Enabled = True
        'Else
        'CmdDel.Enabled = False
        'End If
    End Sub

    Private Sub ChkAddEdit()
        Dim sqlFact As String
        IsFindEmp = True
        sqlFact = "SELECT * FROM TblStaff WHERE Stid = '" & TxtStid.Text & "' and Factory = '" & MFactory & "'"
        da = New SqlDataAdapter(sqlFact, Conn)
        da.Fill(ds, "Fact1")
        If ds.Tables("Fact1").Rows.Count <> 0 Then
            IsFindEmp = True
            If ds.Tables("Fact1").Rows(0).Item("Stid") Is System.DBNull.Value = False Then
                TxtStid.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Stid"))
            Else
                TxtStid.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Title_Th") Is System.DBNull.Value = False Then
                CbTitle_Th.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Title_Th"))
            Else
                CbTitle_Th.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Title_En") Is System.DBNull.Value = False Then
                CbTitle_En.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Title_En"))
            Else
                CbTitle_En.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("FName_Th") Is System.DBNull.Value = False Then
                TxtFName_Th.Text = CStr(ds.Tables("Fact1").Rows(0).Item("FName_Th"))
            Else
                TxtFName_Th.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("FName_En") Is System.DBNull.Value = False Then
                TxtFName_En.Text = CStr(ds.Tables("Fact1").Rows(0).Item("FName_En"))
            Else
                TxtFName_En.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("LName_Th") Is System.DBNull.Value = False Then
                TxtLName_Th.Text = CStr(ds.Tables("Fact1").Rows(0).Item("LName_Th"))
            Else
                TxtLName_Th.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("LName_En") Is System.DBNull.Value = False Then
                TxtLName_En.Text = CStr(ds.Tables("Fact1").Rows(0).Item("LName_En"))
            Else
                TxtLName_En.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Field_Id") Is System.DBNull.Value = False Then
                'CbField_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Field_Id")) & CbField_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Field_Th"))

                If ds.Tables("Fact1").Rows(0).Item("Field_Id") Is System.DBNull.Value = False Then
                    CbField_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Field_Id"))
                    Dim SqlField As String
                    SqlField = "Select * from TblField where Field_Id = '" & _
                                  CStr(ds.Tables("Fact1").Rows(0).Item("Field_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlField, Conn)
                    da.Fill(ds, "Field1")
                    If ds.Tables("Field1").Rows.Count <> 0 Then
                        If ds.Tables("Field1").Rows(0).Item("Field_Th") Is System.DBNull.Value = False Then

                            CbField_Id.Text = CStr(ds.Tables("Field1").Rows(0).Item("Field_Id")) & " " & _
                        CStr(ds.Tables("Field1").Rows(0).Item("Field_Th"))

                        End If
                    End If
                    ds.Tables("Field1").Clear()
                Else
                    CbField_Id.Text = ""
                End If

            Else
                CbField_Id.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Div_Id") Is System.DBNull.Value = False Then
                'CbDiv_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Div_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Div_Id") Is System.DBNull.Value = False Then
                    CbDiv_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Div_Id"))
                    Dim SqlDiv As String
                    SqlDiv = "Select * from TblDivision where Div_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Div_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlDiv, Conn)
                    da.Fill(ds, "Div1")
                    If ds.Tables("Div1").Rows.Count <> 0 Then
                        If ds.Tables("Div1").Rows(0).Item("Div_Th") Is System.DBNull.Value = False Then

                            CbDiv_Id.Text = CStr(ds.Tables("Div1").Rows(0).Item("Div_Id")) & " " & _
                        CStr(ds.Tables("Div1").Rows(0).Item("Div_Th"))

                        End If
                    End If
                    ds.Tables("Div1").Clear()
                Else
                    CbField_Id.Text = ""
                End If
            Else
                CbDiv_Id.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Dep_Id") Is System.DBNull.Value = False Then
                'CbDep_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Dep_Id") Is System.DBNull.Value = False Then
                    CbDep_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Id"))
                    Dim SqlDep As String
                    SqlDep = "Select * from TblDepartment where Dep_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlDep, Conn)
                    da.Fill(ds, "Dep1")
                    If ds.Tables("Dep1").Rows.Count <> 0 Then
                        If ds.Tables("Dep1").Rows(0).Item("Dep_Th") Is System.DBNull.Value = False Then

                            CbDep_Id.Text = CStr(ds.Tables("Dep1").Rows(0).Item("Dep_Id")) & " " & _
                        CStr(ds.Tables("Dep1").Rows(0).Item("Dep_Th"))

                        End If
                    End If
                    ds.Tables("Dep1").Clear()
                Else
                    CbField_Id.Text = ""
                End If
            Else
                CbDep_Id.Text = ""
            End If



            If ds.Tables("Fact1").Rows(0).Item("Head_Id") Is System.DBNull.Value = False Then
                'CbDep_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Dep_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Head_Id") Is System.DBNull.Value = False Then
                    CbHead_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Head_Id"))
                    Dim SqlHead As String
                    SqlHead = "Select * from TblHead where Head_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Head_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlHead, Conn)
                    da.Fill(ds, "Head1")
                    If ds.Tables("Head1").Rows.Count <> 0 Then
                        If ds.Tables("Head1").Rows(0).Item("Head_Name") Is System.DBNull.Value = False Then

                            CbHead_Id.Text = CStr(ds.Tables("Head1").Rows(0).Item("Head_Id")) & " " & _
                        CStr(ds.Tables("Head1").Rows(0).Item("Head_Name"))

                        End If
                    End If
                    ds.Tables("Head1").Clear()
                Else
                    CbHead_Id.Text = ""
                End If
            Else
                CbHead_Id.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Unit_Id") Is System.DBNull.Value = False Then
                'CbUnit_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Unit_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Unit_Id") Is System.DBNull.Value = False Then
                    CbUnit_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Unit_Id"))
                    Dim SqlUnit As String
                    SqlUnit = "Select * from TblUnit where Unit_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Unit_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlUnit, Conn)
                    da.Fill(ds, "Unit1")
                    If ds.Tables("Unit1").Rows.Count <> 0 Then
                        If ds.Tables("Unit1").Rows(0).Item("Unit_Th") Is System.DBNull.Value = False Then

                            CbUnit_Id.Text = CStr(ds.Tables("Unit1").Rows(0).Item("Unit_Id")) & " " & _
                        CStr(ds.Tables("Unit1").Rows(0).Item("Unit_Th"))

                        End If
                    End If
                    ds.Tables("Unit1").Clear()
                Else
                    CbField_Id.Text = ""
                End If
            Else
                CbUnit_Id.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Type_Id") Is System.DBNull.Value = False Then
                'CbType_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Type_Id") Is System.DBNull.Value = False Then
                    CbType_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_Id"))
                    Dim SqlType As String
                    SqlType = "Select * from TblType where Type_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Type_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlType, Conn)
                    da.Fill(ds, "Type1")
                    If ds.Tables("Type1").Rows.Count <> 0 Then
                        If ds.Tables("Type1").Rows(0).Item("Type_Th") Is System.DBNull.Value = False Then

                            CbType_Id.Text = CStr(ds.Tables("Type1").Rows(0).Item("Type_Id")) & " " & _
                        CStr(ds.Tables("Type1").Rows(0).Item("Type_Th"))

                        End If
                    End If
                    ds.Tables("Type1").Clear()
                Else
                    CbField_Id.Text = ""
                End If
            Else
                CbType_Id.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Shift_Id") Is System.DBNull.Value = False Then
                'CbType_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Type_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Shift_Id") Is System.DBNull.Value = False Then
                    CbShift.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Shift_Id"))
                    Dim SqlShift As String
                    SqlShift = "Select * from TblShift where Shift_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Shift_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlShift, Conn)
                    da.Fill(ds, "Shift1")
                    If ds.Tables("Shift1").Rows.Count <> 0 Then
                        If ds.Tables("Shift1").Rows(0).Item("Shift_In") Is System.DBNull.Value = False Then

                            CbShift.Text = CStr(ds.Tables("Shift1").Rows(0).Item("Shift_Id")) & "       " & _
                        Microsoft.VisualBasic.Mid(CStr(ds.Tables("Shift1").Rows(0).Item("Shift_In")), 12, 5) & " - " & Microsoft.VisualBasic.Mid(CStr(ds.Tables("Shift1").Rows(0).Item("Shift_Out")), 12, 5)

                        End If
                    End If
                    ds.Tables("Shift1").Clear()
                Else
                    CbField_Id.Text = ""
                End If
            Else
                CbShift.Text = ""
            End If



            If ds.Tables("Fact1").Rows(0).Item("Pos_Id") Is System.DBNull.Value = False Then
                'CbPos_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Pos_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Pos_Id") Is System.DBNull.Value = False Then
                    CbPos_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Pos_Id"))
                    Dim SqlPos As String
                    SqlPos = "Select * from TblPosition where Pos_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Pos_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlPos, Conn)
                    da.Fill(ds, "Pos1")
                    If ds.Tables("Pos1").Rows.Count <> 0 Then
                        If ds.Tables("Pos1").Rows(0).Item("Pos_Th") Is System.DBNull.Value = False Then

                            CbPos_Id.Text = CStr(ds.Tables("Pos1").Rows(0).Item("Pos_Id")) & " " & _
                        CStr(ds.Tables("Pos1").Rows(0).Item("Pos_Th"))

                        End If
                    End If
                    ds.Tables("Pos1").Clear()
                Else
                    CbPos_Id.Text = ""
                End If
            Else
                CbPos_Id.Text = ""
            End If



            If ds.Tables("Fact1").Rows(0).Item("Emp_Th") Is System.DBNull.Value = False Then
                CbEmp_Th.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Emp_Th"))
            Else
                CbEmp_Th.Text = ""
            End If


            If ds.Tables("Fact1").Rows(0).Item("Work_Status") Is System.DBNull.Value = False Then
                CbWorkStatus.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Work_Status"))
            Else
                CbWorkStatus.Text = ""
            End If

            If ds.Tables("Fact1").Rows(0).Item("Nationality") Is System.DBNull.Value = False Then
                CbNation.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Nationality"))
            Else
                CbNation.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Sal") Is System.DBNull.Value = False Then
                TxtSal.Text = CStr(Format(ds.Tables("Fact1").Rows(0).Item("Sal"), "#,##0.00"))
            Else
                TxtSal.Text = ""
            End If
            If ds.Tables("Fact1").Rows(0).Item("Pos_All") Is System.DBNull.Value = False Then
                TxtPos_All.Text = CStr(Format(ds.Tables("Fact1").Rows(0).Item("Pos_All"), "#,##0.00"))
            Else
                TxtPos_All.Text = ""
            End If

            If ds.Tables("Fact1").Rows(0).Item("Sup_Id") Is System.DBNull.Value = False Then
                'CbSup_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id"))
                If ds.Tables("Fact1").Rows(0).Item("Sup_Id") Is System.DBNull.Value = False Then
                    CbSup_Id.Text = CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id"))
                    Dim SqlSup As String
                    SqlSup = "Select * from TblSupervisor where Sup_Id = '" & _
                                CStr(ds.Tables("Fact1").Rows(0).Item("Sup_Id")) & "' and factory = '" & MFactory & "'"
                    da = New SqlDataAdapter(SqlSup, Conn)
                    da.Fill(ds, "Pos1")
                    If ds.Tables("Pos1").Rows.Count <> 0 Then
                        If ds.Tables("Pos1").Rows(0).Item("Sup_Name") Is System.DBNull.Value = False Then

                            CbSup_Id.Text = CStr(ds.Tables("Pos1").Rows(0).Item("Sup_Id")) & " " & _
                        CStr(ds.Tables("Pos1").Rows(0).Item("Sup_Name"))

                        End If
                    End If
                    ds.Tables("Pos1").Clear()
                Else
                    CbSup_Id.Text = ""
                End If
            Else
                CbSup_Id.Text = ""
            End If
        Else
            IsFindEmp = False
            Clear_Dat()
        End If
        ds.Tables("Fact1").Clear()
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
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 12.25F, GraphicsUnit.Pixel)
            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
                FreezeBand(.Columns(i))
            Next
            '=============================================================================================
            Dim ColStid As New DataGridViewTextBoxColumn
            With ColStid
                .DataPropertyName = "Stid"
                .HeaderText = "รหัสพนักงาน"
                .Width = 100
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColStid)

            Dim ColTitle_Th As New DataGridViewTextBoxColumn
            With ColTitle_Th
                .DataPropertyName = "Title_Th"
                .HeaderText = "คำนำหน้าชื่อ(ไทย)"
                .Width = 120
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColTitle_Th)

            Dim ColFName_Th As New DataGridViewTextBoxColumn
            With ColFName_Th
                .DataPropertyName = "FName_Th"
                .HeaderText = "ชื่อ(ไทย)"
                .Width = 200
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColFName_Th)

            Dim ColLName_Th As New DataGridViewTextBoxColumn
            With ColLName_Th
                .DataPropertyName = "LName_Th"
                .HeaderText = "นามสกุล(ไทย)"
                .Width = 200
                .MaxInputLength = 10
                .ReadOnly = True
            End With
            .Columns.Add(ColLName_Th)

            Dim ColSal As New DataGridViewTextBoxColumn
            With ColSal
                .DataPropertyName = "Sal"
                .HeaderText = "ค่าแรง/วัน"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColSal)

            Dim ColPos_All As New DataGridViewTextBoxColumn
            With ColPos_All
                .DataPropertyName = "Pos_All"
                .HeaderText = "ค่าตำแหน่ง"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,##0.00"
                '.ReadOnly = True
            End With
            .Columns.Add(ColPos_All)

        End With
    End Sub

    Private Sub cmdPrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrt.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim CRVDep As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim FrmPrTDep As New Form
        Dim RpTDep As New PrtStaff
        Dim MParamFactName, MParamFactAddr, MParamFilter1, MFormula As String
        Dim connection1 As IConnectionInfo
        For Each connection1 In RpTDep.DataSourceConnections
            If (String.Compare(connection1.ServerName, MOldServer, True) = 0 _
                And String.Compare(connection1.DatabaseName, MDataBase, True) = 0) Then
                RpTDep.DataSourceConnections(MOldServer, MDataBase).SetConnection( _
                MServer, MDataBase, MUserID, MPassWord)
            End If
        Next
        RpTDep.SetDatabaseLogon(MUserID, MPassWord, MServer, MDataBase)
        MParamFactName = MFactName
        MParamFactAddr = MFactAddr
        MFormula = "{tblStaff.Factory} = '" & MFactory & "'"
        MParamFilter1 = ""

        If CbSup_Id2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Sup_id} = '" & Microsoft.VisualBasic.Left(CbSup_Id2.Text, 8) & "'"
            MParamFilter1 = MParamFilter1 & " Sup " & CbSup_Id2.Text
        End If
        If CbHead_Id2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Head_id} = '" & Microsoft.VisualBasic.Left(CbHead_Id2.Text, 8) & "'"
            MParamFilter1 = MParamFilter1 & " หัวหน้า " & CbHead_Id2.Text
        End If
        If CbNation2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Nationality} = '" & CbNation2.Text & "'"
            MParamFilter1 = MParamFilter1 & " สัญชาติ " & CbNation2.Text
        End If
        If CbShift2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Shift_Id} = '" & Microsoft.VisualBasic.Left(CbShift2.Text, 3) & "'"
            MParamFilter1 = MParamFilter1 & " กะ " & CbShift2.Text
        End If
        If CbDep_Id2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Dep_id} = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 6) & "'"
            MParamFilter1 = MParamFilter1 & " แผนก " & CbDep_Id2.Text
        End If
        If CbDiv_Id2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Div_id} = '" & Microsoft.VisualBasic.Left(CbDiv_Id2.Text, 2) & "'"
            MParamFilter1 = MParamFilter1 & " ฝ่าย " & CbDiv_Id2.Text
        End If
        If CbUnit_Id2.Text <> "" Then
            MFormula = MFormula + " And {tblStaff.Unit_id} = '" & Microsoft.VisualBasic.Left(CbUnit_Id2.Text, 3) & "'"
            MParamFilter1 = MParamFilter1 & " หน่วยงาน " & CbUnit_Id2.Text
        End If

        With CRVDep
            .ReportSource = RpTDep
            .ParameterFieldInfo(0).CurrentValues.AddValue(MParamFactName)
            .ParameterFieldInfo(1).CurrentValues.AddValue(MParamFactAddr)
            .ParameterFieldInfo(2).CurrentValues.AddValue(MParamFilter1)
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

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        If DataGridView1.CurrentRow.Cells("Stid").Value Is System.DBNull.Value = False Then
            TxtStid.Text = DataGridView1.CurrentRow.Cells("Stid").Value
            ChkAddEdit()
        End If
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        With e.Row
            '.Cells("Dep_Id").Value = ""
            If .Index <> 0 Then
                '.Cells("Dep_Id").Value = IIf(DataGridView1.Rows(.Index - 1).Cells("Dep_Id").Value <= 9, "0" & Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Dep_Id").Value + 1)), Trim(Str(DataGridView1.Rows(.Index - 1).Cells("Dep_Id").Value + 1)))
                .Cells("Dep_Id").Value = ""
                'Else
                '.Cells("Dep_Id").Value = "A100001"
            End If
            '.Cells("Dep_Th").Value = ""
        End With
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            If cb IsNot Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub txtStid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStid.KeyDown
        If e.KeyCode = Keys.Enter Then
            '            ChkAddEdit()

            CbTitle_Th.Focus()
        End If
    End Sub
    Private Sub CbTitle_Th_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbTitle_Th.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFName_Th.Focus()
        End If
    End Sub

    Private Sub CmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdDel.Click
        Dim sqlDel, SqlLog As String
        If Len(TxtStid.Text) <> 8 Then
            MessageBox.Show("ป้อนรหัสฝ่าย 8 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtStid.Focus()
            Exit Sub
        End If

        If MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ ?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If IsFindEmp = True Then
            sqlDel = "DELETE FROM TblStaff WHERE Stid = '" & TxtStid.Text & "' And Factory = '" & MFactory & "'"
            With ComDel
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandText = sqlDel
                .ExecuteNonQuery()
            End With
            SqlLog = "Delete พนักงาน " & TxtStid.Text & " " & TxtFName_Th.Text & " " & TxtLName_Th.Text
            SaveLog(SqlLog)
            'MessageBox.Show("ลบรายการ  ของ " & txtDep_Id.Text & " " & TxtFact__Nm.Text & " เรียบร้อยแล้ว..", "ลบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Up_DataGrid()
        Clear_Dat()
        TxtStid.Text = ""
        TxtStid.Focus()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        If Len(TxtStid.Text) <> 8 Then
            MessageBox.Show("ป้อนรหัสพนักงาน 8 ตัวอักษรเท่านั้น...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtStid.Focus()
            Exit Sub
        End If
        If CbTitle_Th.Text = "" Then
            MessageBox.Show("เลือกคำนำหน้าชื่อ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbTitle_Th.Focus()
            Exit Sub
        End If
        If TxtFName_Th.Text = "" Then
            MessageBox.Show("ป้อนชื่อ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtFName_Th.Focus()
            Exit Sub
        End If
        If TxtLName_Th.Text = "" Then
            MessageBox.Show("ป้อนนามสกุล ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtLName_Th.Focus()
            Exit Sub
        End If
        If CbTitle_En.Text = "" Then
            MessageBox.Show("เลือกคำนำหน้าชื่อ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbTitle_En.Focus()
            Exit Sub
        End If
        If TxtFName_En.Text = "" Then
            MessageBox.Show("ป้อนชื่อ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtFName_En.Focus()
            Exit Sub
        End If
        If TxtLName_En.Text = "" Then
            MessageBox.Show("ป้อนนามสกุล ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtLName_En.Focus()
            Exit Sub
        End If
        If CbField_Id.Text = "" Then
            MessageBox.Show("เลือกสายงาน ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbField_Id.Focus()
            Exit Sub
        End If
        If CbDiv_Id.Text = "" Then
            MessageBox.Show("เลือกฝ่าย ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbDiv_Id.Focus()
            Exit Sub
        End If
        If CbDep_Id.Text = "" Then
            MessageBox.Show("เลือกแผนก ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbDep_Id.Focus()
            Exit Sub
        End If
        If CbUnit_Id.Text = "" Then
            MessageBox.Show("เลือกหน่วยงาน ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbUnit_Id.Focus()
            Exit Sub
        End If
        If CbType_Id.Text = "" Then
            MessageBox.Show("เลือกประเภท ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbType_Id.Focus()
            Exit Sub
        End If
        If CbPos_Id.Text = "" Then
            MessageBox.Show("เลือกตำแหน่ง ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbPos_Id.Focus()
            Exit Sub
        End If
        If Not (CbEmp_Th.Text = "รายวัน" Or CbEmp_Th.Text = "รายเดือน") Then
            MessageBox.Show("เลือกประเภทค่าแรงไม่ถูกต้อง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbEmp_Th.Focus()
            Exit Sub
        End If
        If CbShift.Text = "" Then
            MessageBox.Show("เลือกกะ ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbShift.Focus()
            Exit Sub
        End If
        If Not (CbNation.Text = "ไทย" Or CbNation.Text = "ต่างด้าว") Then
            MessageBox.Show("เลือกสัญชาติไม่ถูกต้อง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbNation.Focus()
            Exit Sub
        End If
        If CbSup_Id.Text = "" Then
            MessageBox.Show("เลือกหัวหน้า ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbSup_Id.Focus()
            Exit Sub
        End If
        If TxtSal.Text = "" Then
            MessageBox.Show("ป้อนค่าแรง ว่าง...", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtSal.Focus()
            Exit Sub
        End If
        If Not (CbWorkStatus.Text = "เป็นพนักงาน" Or CbWorkStatus.Text = "พ้นสภาพพนักงาน") Then
            MessageBox.Show("เลือกสถานะพนักงานไม่ถูกต้อง... ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbWorkStatus.Focus()
            Exit Sub
        End If


        Save_Dat()
        MessageBox.Show("บันทึกรายการ  ของ " & TxtStid.Text & " " & TxtFName_Th.Text & " เรียบร้อยแล้ว..", "บันทึกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Up_DataGrid()
        Clear_Dat()
        TxtStid.Text = ""
        TxtStid.Focus()
    End Sub

  


    Private Sub Save_Dat()
        Dim sqlSave, SqlLog As String

        Dim dept_Id = getDeptIDFomrCBB(CbDep_Id.Text)
        If IsFindEmp = True Then
            sqlSave = "UPDATE TblStaff SET "
            sqlSave &= "Factory = '" & MFactory & "',"
            sqlSave &= "Stid = '" & TxtStid.Text & "',"
            sqlSave &= "Title_Th = '" & CbTitle_Th.Text & "',"
            sqlSave &= "Fname_Th = '" & TxtFName_Th.Text & "',"
            sqlSave &= "LName_Th = '" & TxtLName_Th.Text & "',"
            sqlSave &= "Title_En = '" & CbTitle_En.Text & "',"
            sqlSave &= "FName_En = '" & TxtFName_En.Text & "',"
            sqlSave &= "LName_En = '" & TxtLName_En.Text & "',"
            sqlSave &= "Field_Id = '" & Microsoft.VisualBasic.Left(CbField_Id.Text, 2) & "',"
            sqlSave &= "Div_Id = '" & Microsoft.VisualBasic.Left(CbDiv_Id.Text, 2) & "',"
            sqlSave &= "Dep_Id = '" & dept_Id & "'," 'Microsoft.VisualBasic.Left(CbDep_Id.Text, 6) & "',"
            sqlSave &= "Unit_Id = '" & Microsoft.VisualBasic.Left(CbUnit_Id.Text, 3) & "',"
            sqlSave &= "Type_Id = '" & Microsoft.VisualBasic.Left(CbType_Id.Text, 2) & "',"
            sqlSave &= "Pos_Id = '" & Microsoft.VisualBasic.Left(CbPos_Id.Text, 3) & "',"
            sqlSave &= "Emp_Th = '" & CbEmp_Th.Text & "',"
            sqlSave &= "Shift_Id = '" & Microsoft.VisualBasic.Left(CbShift.Text, 3) & "',"
            sqlSave &= "Nationality = '" & CbNation.Text & "',"
            sqlSave &= "Sup_Id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "',"
            sqlSave &= "Head_Id = '" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "',"
            sqlSave &= "Sal = '" & TxtSal.Text & "',"
            sqlSave &= "Pos_All = '" & TxtPos_All.Text & "',"
            sqlSave &= "Work_Status = '" & CbWorkStatus.Text & "'"
            sqlSave &= " WHERE Stid = '" & TxtStid.Text & "'"
            SqlLog = "Edit พนักงาน " & TxtStid.Text & " " & TxtFName_Th.Text & " " & TxtLName_Th.Text
        Else
            sqlSave = "INSERT INTO TblStaff (Factory,Stid,Title_Th,Fname_Th,Lname_Th,Title_En,Fname_En,Lname_En,Field_Id,Div_Id,Dep_Id,Unit_Id,Type_Id,Pos_Id,Emp_Th,Shift_Id,Nationality,Head_Id,Sup_Id,Sal,Pos_All,Work_Status)"
            sqlSave &= " VALUES('" & MFactory & "','" & TxtStid.Text & "','" & CbTitle_Th.Text & "','" & TxtFName_Th.Text & "','" & TxtLName_Th.Text & "','" & CbTitle_En.Text & "','" & TxtFName_En.Text & "','"
            sqlSave &= TxtLName_En.Text & "','" & Microsoft.VisualBasic.Left(CbField_Id.Text, 2) & "','" & Microsoft.VisualBasic.Left(CbDiv_Id.Text, 2) & "','" & dept_Id & "','" & Microsoft.VisualBasic.Left(CbUnit_Id.Text, 3) & "','" & Microsoft.VisualBasic.Left(CbType_Id.Text, 2) & "','"
            sqlSave &= Microsoft.VisualBasic.Left(CbPos_Id.Text, 3) & "','" & CbEmp_Th.Text & "','" & Microsoft.VisualBasic.Left(CbShift.Text, 3) & "','" & CbNation.Text & "','" & Microsoft.VisualBasic.Left(CbHead_Id.Text, 8) & "','" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "','"
            sqlSave &= TxtSal.Text & "','" & TxtPos_All.Text & "','" & CbWorkStatus.Text & "')"
            SqlLog = "Add พนักงาน " & TxtStid.Text & " " & TxtFName_Th.Text & " " & TxtLName_Th.Text
        End If
        With ComSave
            .CommandType = CommandType.Text
            .Connection = Conn
            .CommandText = "Set DateFormat 'DMY'"
            .ExecuteNonQuery()
            .CommandText = sqlSave
            .ExecuteNonQuery()
        End With
        SaveLog(SqlLog)
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

    Private Sub CmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExcel.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        xlApp.SheetsInNewWorkbook = 1
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

        xlWorkSheet.Name = "Sheet1"
        '===Header Text
        xlWorkSheet.Cells(1, 1).Value = "Factory"
        xlWorkSheet.Cells(1, 2).Value = "รหัสพนักงาน"
        xlWorkSheet.Cells(1, 3).Value = "คำนำหน้าชื่อ(ไทย)"
        xlWorkSheet.Cells(1, 4).Value = "คำนำหน้าชื่อ(อังกฤษ)"
        xlWorkSheet.Cells(1, 5).Value = "ชื่อ(ไทย)"
        xlWorkSheet.Cells(1, 6).Value = "สกุล(ไทย)"
        xlWorkSheet.Cells(1, 7).Value = "ชื่อ(อังกฤษ)"
        xlWorkSheet.Cells(1, 8).Value = "สกุล(อังกฤษ)"
        xlWorkSheet.Cells(1, 9).Value = "กะ"
        xlWorkSheet.Cells(1, 10).Value = "รหัสสายงาน"
        xlWorkSheet.Cells(1, 11).Value = "ชื่อสายงาน"
        xlWorkSheet.Cells(1, 12).Value = "รหัสฝ่าย"
        xlWorkSheet.Cells(1, 13).Value = " ชื่อฝ่าย"
        xlWorkSheet.Cells(1, 14).Value = "รหัสแผนก"
        xlWorkSheet.Cells(1, 15).Value = "ชื่อแผนก"
        xlWorkSheet.Cells(1, 16).Value = "รหัสหน่วยงาน"
        xlWorkSheet.Cells(1, 17).Value = "ชื่อหน่วยงาน"
        xlWorkSheet.Cells(1, 18).Value = "รหัสประเภทพนักงาน"
        xlWorkSheet.Cells(1, 19).Value = "ชื่อประเภทพนักงาน"
        xlWorkSheet.Cells(1, 20).Value = "รหัสตำแหน่ง"
        xlWorkSheet.Cells(1, 21).Value = "ชื่อตำแหน่ง"
        xlWorkSheet.Cells(1, 22).Value = "ประเภทพนักงาน"
        xlWorkSheet.Cells(1, 23).Value = "สัญชาติ"
        xlWorkSheet.Cells(1, 24).Value = "ค่าแรง"
        xlWorkSheet.Cells(1, 25).Value = "ค่าตำแหน่ง"
        xlWorkSheet.Cells(1, 26).Value = "รหัส Supervisor"
        xlWorkSheet.Cells(1, 27).Value = "ชื่อ Supervisor"
        xlWorkSheet.Cells(1, 28).Value = "รหัสหัวหน้าหน่วย"
        xlWorkSheet.Cells(1, 29).Value = "ชื่อหัวหน้าหน่วย"
        xlWorkSheet.Cells(1, 30).Value = "ทีม"
        xlWorkSheet.Cells(1, 31).Value = "สถานะ"
        xlWorkSheet.Cells(1, 32).Value = "หมายเหตุ"


        MFilter = " "
        If CbSup_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Sup_id = '" & Microsoft.VisualBasic.Left(CbSup_Id2.Text, 8) & "'"
        End If
        If CbHead_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Head_id = '" & Microsoft.VisualBasic.Left(CbHead_Id2.Text, 8) & "'"
        End If
        If CbNation2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Nationality = '" & CbNation2.Text & "'"
        End If

        If CbShift2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Shift_Id = '" & Microsoft.VisualBasic.Left(CbShift2.Text, 3) & "'"
        End If

        If CbDep_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Dep_id = '" & Microsoft.VisualBasic.Left(CbDep_Id2.Text, 6) & "'"
        End If

        If CbDiv_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Div_id = '" & Microsoft.VisualBasic.Left(CbDiv_Id2.Text, 2) & "'"
        End If

        If CbUnit_Id2.Text <> "" Then
            MFilter = MFilter + " And tblStaff.Unit_id = '" & Microsoft.VisualBasic.Left(CbUnit_Id2.Text, 3) & "'"
        End If

        Dim SqlString As String
        SqlString = "SELECT distinct TblStaff.Factory, TblStaff.Stid, TblStaff.Title_Th, TblStaff.Title_En, TblStaff.Fname_Th, TblStaff.Lname_Th, TblStaff.Fname_En, " & _
                      "TblStaff.Lname_En, TblStaff.Shift_Id, TblStaff.Field_Id, TblField.Field_Th, TblStaff.Div_Id, TblDivision.Div_Th, TblStaff.Dep_Id, TblDepartment.Dep_Th, " & _
                      "TblStaff.Unit_Id, TblUnit.Unit_Th, TblStaff.Type_Id, TblType.Type_Th, TblStaff.Pos_Id, TblPosition.Pos_Th, TblStaff.Emp_Th, " & _
        "TblStaff.Nationality, TblStaff.Sal, TblStaff.Pos_All, TblStaff.Sup_Id, TblSupervisor.Sup_Name, TblStaff.Head_id, TblHead.Head_Name, TblStaff.Team, TblStaff.Work_Status, " & _
        "TblStaff.Memo " & _
        "FROM TblStaff LEFT OUTER JOIN " & _
                      "TblField ON TblStaff.Field_Id = TblField.Field_Id LEFT OUTER JOIN " & _
                      "TblDivision ON TblStaff.Div_Id = TblDivision.Div_id LEFT OUTER JOIN " & _
                      "TblType ON TblStaff.Type_Id = TblType.Type_Id LEFT OUTER JOIN " & _
                      "TblShift ON TblStaff.Shift_Id = TblShift.Shift_Id LEFT OUTER JOIN " & _
                      "TblHead ON TblStaff.Head_id = TblHead.Head_Id LEFT OUTER JOIN " & _
                      "TblSupervisor ON TblStaff.Sup_Id = TblSupervisor.Sup_Id LEFT OUTER JOIN " & _
                      "TblPosition ON TblStaff.Pos_Id = TblPosition.Pos_Id LEFT OUTER JOIN " & _
                      "TblUnit ON TblStaff.Unit_Id = TblUnit.Unit_Id LEFT OUTER JOIN " & _
                      "TblDepartment ON TblStaff.Dep_Id = TblDepartment.Dep_Id where TblStaff.Factory = '" & MFactory & "' " & MFilter

        da = New SqlDataAdapter(SqlString, Conn)
        da.Fill(ds, "DataSet1")
        If ds.Tables("DataSet1").Rows.Count <> 0 Then
            For i = 0 To ds.Tables("DataSet1").Rows.Count - 1
                For j = 0 To ds.Tables("DataSet1").Columns.Count - 1
                    If j = 1 Or j = 8 Or j = 10 Or j = 12 Or j = 14 Or j = 16 Or j = 18 Or j = 24 Or j = 26 Then
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
        xlWorkBook.SaveAs(My.Application.Info.DirectoryPath & "\TblStaff.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                           Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges)
        xlWorkBook.Close()
        xlApp.Quit()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Process.Start("EXCEL.EXE", "" & My.Application.Info.DirectoryPath & "\TblStaff.xls")
    End Sub

    Private Sub TxtFName_Th_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFName_Th.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLName_Th.Focus()
        End If
    End Sub

    Private Sub TxtLName_Th_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLName_Th.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbTitle_En.Focus()
        End If
    End Sub

    Private Sub CbTitle_En_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbTitle_En.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFName_En.Focus()
        End If
    End Sub

    Private Sub TxtFName_En_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFName_En.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLName_En.Focus()
        End If
    End Sub

    Private Sub TxtLName_En_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLName_En.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbPos_Id.Focus()
        End If
    End Sub

    Private Sub CbField_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbField_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDiv_Id.Focus()
        End If
    End Sub

    Private Sub CbDiv_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDiv_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbDep_Id.Focus()
        End If
    End Sub

    Private Sub CbDep_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbDep_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbUnit_Id.Focus()
        End If
    End Sub

    Private Sub CbUnit_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbUnit_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbType_Id.Focus()
        End If
    End Sub

    Private Sub CbType_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbType_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbNation.Focus()
        End If
    End Sub

    Private Sub CbPos_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbPos_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbSup_Id.Focus()
        End If
    End Sub

    Private Sub CbEmp_Th_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEmp_Th.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbShift.Focus()
        End If
    End Sub

    Private Sub TxtSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSal.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPos_All.Focus()
        End If
    End Sub

    Private Sub CbHead_Id_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbHead_Id.GotFocus
        If CbSup_Id.Text <> "" Then
            CbHead_Id.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead where Sup_Id = '" & Microsoft.VisualBasic.Left(CbSup_Id.Text, 8) & "' and Factory = '" & MFactory & "' Order By Head_Id"
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
        Else
            CbHead_Id.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead where Factory = '" & MFactory & "' Order By Head_Id"
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
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRefresh.Click
        Clear_Dat()
        TxtStid.Focus()
    End Sub

    Private Sub TxtStid_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStid.Validated
        ChkAddEdit()

    End Sub

    Private Sub FrmStaff_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Label10.Location = New Point(Label10.Location.X, Me.Height - 140)
        'Label13.Location = New Point(Label13.Location.X, Me.Height - 140)
        'Label14.Location = New Point(Label14.Location.X, Me.Height - 140)
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        'MsgBox(Microsoft.VisualBasic.Left(CbSup_Id.Text, 10))
        Me.Close()
    End Sub

    Private Sub CbHead_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbHead_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbField_Id.Focus()
        End If
    End Sub

    Private Sub CbSup_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbSup_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbHead_Id.Focus()
        End If
    End Sub

    Private Sub CbNation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbNation.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbEmp_Th.Focus()
        End If
    End Sub

    Private Sub CbDep_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDep_Id2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbHead_Id2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbHead_Id2.GotFocus
        If CbSup_Id2.Text <> "" Then
            CbHead_Id2.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead where Sup_Id = '" & Microsoft.VisualBasic.Left(CbSup_Id2.Text, 8) & "' and Factory = '" & MFactory & "' Order By Head_Id"
            da = New SqlDataAdapter(sqlHead, Conn)
            da.Fill(ds, "Head1")
            If ds.Tables("Head1").Rows.Count <> 0 Then
                Dim i As Integer
                For i = 0 To ds.Tables("Head1").Rows.Count - 1
                    CbHead_Id2.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                                ds.Tables("Head1").Rows(i).Item("Head_Name"))
                Next
            End If
            CbHead_Id2.Text = ""
            ds.Tables("Head1").Clear()
        Else
            CbHead_Id2.Items.Clear()
            Dim sqlHead As String
            sqlHead = "SELECT * FROM tblHead where Factory = '" & MFactory & "' Order By Head_Id"
            da = New SqlDataAdapter(sqlHead, Conn)
            da.Fill(ds, "Head1")
            If ds.Tables("Head1").Rows.Count <> 0 Then
                Dim i As Integer
                For i = 0 To ds.Tables("Head1").Rows.Count - 1
                    CbHead_Id2.Items.Add(ds.Tables("Head1").Rows(i).Item("Head_Id") & " " & _
                                ds.Tables("Head1").Rows(i).Item("Head_Name"))
                Next
            End If
            CbHead_Id2.Text = ""
            ds.Tables("Head1").Clear()
        End If
    End Sub

    Private Sub CbHead_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbHead_Id2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbNation2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbNation2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbSup_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbSup_Id2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbDiv_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDiv_Id2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbUnit_Id2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbUnit_Id2.TextChanged
        Up_DataGrid()
    End Sub
    Private Sub CbShift2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbShift2.TextChanged
        Up_DataGrid()
    End Sub

    Private Sub CbShift_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbShift.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtSal.Focus()
        End If
    End Sub

    
    Private Sub CbWorkStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbWorkStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdSave.Focus()
        End If
    End Sub

    Private Sub CmdImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdImport.Click

        'Dim strConnString As String = "Server=localhost;UID=sa;PASSWORD=;database=mydatabase"
        'Dim objConn = New SqlConnection(strConnString)
        'objConn.Open()
        'Using stream As FileStream = File.Open(Server.MapPath("Xls/myExcel.xlsx"), FileMode.Open, FileAccess.Read)
        'Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(Stream)
        'excelReader.IsFirstRowAsColumnNames = False
        'Dim i As Integer = 0
        'While excelReader.Read()
        'If i > 0 Then
        ' Dim strSQL As String
        'strSQL = "INSERT INTO myTable (Column1,Column2,Column3,Column4,Column5) " & _
        '" VALUES  (" & " '" & excelReader.GetString(0) & "', " & _
        '" '" & excelReader.GetString(1) & "', " & _
        '" '" & excelReader.GetString(2) & "', " & _
        '" '" & excelReader.GetString(3) & "', " & _
        '" '" & excelReader.GetString(4) & "' " & ")"
        'Dim objCmd = New SqlCommand(strSQL, objConn)
        'objCmd.ExecuteNonQuery()
        'End If
        'i += 1
        'End While
        'End Using
        'objConn.Close()

    End Sub

    Private Sub TxtPos_All_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPos_All.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbWorkStatus.Focus()
        End If
    End Sub
End Class