Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmMain
    Dim Conn As New SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim MFact As String
    Dim ComDrop As New SqlCommand
    Dim ComSave As New SqlCommand
    Dim SqlStr As String
    Dim SelePath As String
    'Dim currentculture As String = My.Application.Culture.Name
    'Dim currentUiculture As String = My.Application.UICulture.Name

    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'My.Application.ChangeCulture(currentculture)
        'My.Application.ChangeUICulture(currentUiculture)
        FrmLogin.Close()
    End Sub


    Private Sub TestChangeCulture()
        ' Store the current culture.
        Dim currentculture As String = My.Application.Culture.Name
        MsgBox("Current culture is " & currentculture)
        Dim jan1 As New Date(2005, 1, 1, 15, 15, 15)
        My.Application.ChangeCulture("en-US")
        MsgBox("Date represented in en-US culture: " & jan1)
        ' 1/1/2005 3:15:15 PM
        My.Application.ChangeCulture("th-TH")
        MsgBox("Date represented in invariant culture" & jan1)
        ' 01/01/2005 15:15:15
        ' Restore the culture.
        My.Application.ChangeCulture(currentculture)
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'My.Application.ChangeCulture("en-GB")
        'My.Application.ChangeUICulture("en-GB")
        'My.Application.Culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"

        Me.IsMdiContainer = True
        'Dim sqlCtrl As String
        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = SqlConn()
            .Open()
        End With

        'sqlCtrl = "SELECT * FROM FactCont"
        'da = New SqlDataAdapter(sqlCtrl, Conn)
        'da.Fill(ds, "FactCont")
        'MFact = CStr(ds.Tables("FactCont").Rows(0).Item("Fact"))
        'MFact_Sub = CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Sub"))
        'MFact_Num = CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Num"))
        'MFact_Cod = CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Cod"))
        'MFact_Ctrl = ds.Tables("FactCont").Rows(0).Item("Fact_Ctrl")
        'MFact_C1 = "01/" + Mid(CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Ctrl")), 4, 2) _
        '+ Microsoft.VisualBasic.Right(CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Ctrl")), 5)
        'MFact_Month = CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Month"))
        'MFact_Year = CStr(ds.Tables("FactCont").Rows(0).Item("Fact_Year"))
        'BalTab = Microsoft.VisualBasic.Right(MFact_Ctrl, 2) + Mid(MFact_Ctrl, 4, 2) + Microsoft.VisualBasic.Left(MFact_Ctrl, 2)
        'Dim MFCtrl As String = CStr(DateSerial(Year(MFact_Ctrl), Month(MFact_Ctrl), Microsoft.VisualBasic.Day(MFact_Ctrl) - 1))
        'BalTab2 = Microsoft.VisualBasic.Right(MFCtrl, 2) + Mid(MFCtrl, 4, 2) + Microsoft.VisualBasic.Left(MFCtrl, 2)
        'ds.Tables("FactCont").Clear()
        Me.Text = "√–∫∫§«∫§ÿ¡°“√‚Õπ§π (USER = " & MFCODE & ")"
        ProgressBar1.Visible = False
        Label1.Visible = False
        'DropBalan()
        ''=======Check Stock Temp Table
        'SqlStr = "Select sysobjects.name from sysobjects where sysobjects.name = '" & BalTab & "'"
        'da = New SqlDataAdapter(SqlStr, Conn)
        'da.Fill(ds, "SysDs")
        'If ds.Tables("SysDs").Rows.Count = 0 Then
        ' DoBalan()
        ' ds.Tables("SysDs").Clear()
        'End If

    End Sub


    Public Sub ClearAllChildOpen()
        Dim cForm As Form
        For Each cForm In Me.MdiChildren
            cForm.Close()
        Next
    End Sub


    Private Sub ‡°¬«°∫‚ª√·°√¡ToolStripMenuItem_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ‡°¬«°∫‚ª√·°√¡ToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub


    Private Sub ÕÕ°ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ÕÕ°ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ª√–«—µ‘æπßToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ª√–«—µ‘æπßToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmStaff
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub  “¬ß“πToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  “¬ß“πToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmField
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ΩË“¬ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ΩË“¬ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmDiv
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ·ºπ°ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ·ºπ°ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmDep
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ÀπË«¬ß“πToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ÀπË«¬ß“πToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmUnit
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub


    Private Sub PostTransferToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ∑”°“√‚Õπæπ—°ß“πToolStripMenuItem1.Click
        ClearAllChildOpen()
        With FrmTransFer
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub √“¬°“√µ√“§“«µ∂¥∫ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ClearAllChildOpen()
        'With FrmRPrice
        '.MdiParent = Me
        '.WindowState = FormWindowState.Maximized
        '.Show()
        'End With

    End Sub

    Private Sub √“¬°“√µ√«®‡™¥∫≈ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ClearAllChildOpen()
        'With FrmRGetChr
        '.MdiParent = Me
        '.WindowState = FormWindowState.Maximized
        '.Show()
        'End With
    End Sub

    Private Sub °”Àπ¥ ∑∏º„™‚ª√·°√¡ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles °”Àπ¥ ∑∏º„™‚ª√·°√¡ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmUser
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ª√–‡¿∑æπßToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ª√–‡¿∑æπßToolStripMenuItem3.Click
        ClearAllChildOpen()
        With FrmType
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub µ”·ÀπßToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles µ”·ÀπßToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmPos
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub SupervisorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SupervisorToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmSup
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub À«Àπ“Àπ«¬ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles À«Àπ“Àπ«¬ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmHead
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub √“¬ß“π∫≠™«µ∂¥∫ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles √“¬ß“π∫≠™«µ∂¥∫ToolStripMenuItem.Click
        ClearAllChildOpen()
        Select Case MFactory
            Case "OKF"
                With Prt_Trn_A1
                    .MdiParent = Me
                    .Show()
                End With
            Case "AS"
                With Prt_Trn_A1_1
                    .MdiParent = Me
                    .Show()
                End With
        End Select

    End Sub

    Private Sub §“·√ßToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles §“·√ßToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A2
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub µ√«® Õ∫°“√„™‚ª√·°√¡ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles µ√«® Õ∫°“√„™‚ª√·°√¡ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmLogFiles
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub √“¬°“√§“ß™”√–ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles √“¬°“√§“ß™”√–ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmConfirm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub °–ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles °–ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmShift
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub  √ª¢Õ¡≈°“√‚Õπæπ°ß“πToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  √ª¢Õ¡≈°“√‚Õπæπ°ß“πToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A3
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π∫≠™ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π∫≠™ToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A4
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“πµ“ß¥“«ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“πµ“ß¥“«ToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A5
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ¥ß¢Õ¡≈°“√¡“∑”ß“πToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ¥ß¢Õ¡≈°“√¡“∑”ß“πToolStripMenuItem.Click
        ClearAllChildOpen()
        With Transfer
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub  √ª¬Õ¬¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π∫≠™·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  √ª¬Õ¬¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π∫≠™·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A3_1
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π‰∑¬·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“π‰∑¬·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A4_1
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“πµ“ß¥“«·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  √ª√«¡¢Õ¡≈°“√‚Õπ¬“¬æπ°ß“πµ“ß¥“«·¬°§“·√ß‚Õ∑IncentiveToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A5_1
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub π”‡¢“¢Õ¡≈ª√∫ª√ß°–¢Õßæπ°ß“πToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles π”‡¢“¢Õ¡≈ª√∫ª√ß°–¢Õßæπ°ß“πToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmUpdStaf1
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub √“¬°“√ √ª§“·√ß‚Õπ¬“¬ª√–®”«πæπ°ß“π√“¬«πµ“ß¥“«ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles √“¬°“√ √ª§“·√ß‚Õπ¬“¬ª√–®”«πæπ°ß“π√“¬«πµ“ß¥“«ToolStripMenuItem.Click
        ClearAllChildOpen()
        With Prt_Trn_A6
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub Lockß«¥«π∑ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lockß«¥«π∑ToolStripMenuItem.Click
        ClearAllChildOpen()
        With FrmLock
            .MdiParent = Me
            .Show()
        End With
    End Sub
End Class


Public Class CalendarColumn
    Inherits DataGridViewColumn
    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class CalendarColumn2
    Inherits DataGridViewColumn
    Public Sub New()
        MyBase.New(New CalendarCell2())
    End Sub
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell
    Public Sub New()
        ' Use the short date format.
        'Me.Style.Format = DateTimePickerFormat.Custom
        Me.Style.Format = "t"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)
        If Me.Value Is DBNull.Value Then
            Me.Value = ctl.Value
        End If
        ctl.Value = CType(Me.Value, DateTime)
        ctl.Format = DateTimePickerFormat.Custom
        ctl.CustomFormat = "HH:mm"
        ctl.ShowUpDown = True
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl
    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        'Me.Format = DateTimePickerFormat.Time
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "HH:mm"
        Me.ShowUpDown = True
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToShortTimeString
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Value.ToShortTimeString
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp, Keys.Decimal
                Return True
            Case Else
                Return False
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
    Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True 
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class

Public Class CalendarCell2
    Inherits DataGridViewTextBoxCell
    Public Sub New()
        ' Use the short date format.
        'Me.Style.Format = DateTimePickerFormat.Custom
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle2 As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle2)

        Dim ctl As CalendarEditingControl2 = _
            CType(DataGridView.EditingControl, CalendarEditingControl2)
        If Me.Value Is DBNull.Value Then
            Me.Value = ctl.Value
        End If
        ctl.Value = CType(Me.Value, DateTime)
        ctl.Format = DateTimePickerFormat.Custom
        ctl.CustomFormat = "dd/MM/yyyy"
        ctl.ShowUpDown = False
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl2)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl2
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl
    Private dataGridViewControl As DataGridView
    Private valueIsChanged1 As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        'Me.Format = DateTimePickerFormat.Time
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "dd/MM/yyyy"
        Me.ShowUpDown = False
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToShortDateString
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Value.ToShortDateString
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp, Keys.Decimal
                Return True
            Case Else
                Return False
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged1
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged1 = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
    Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged1 = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class