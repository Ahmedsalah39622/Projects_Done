'Imports System.Data.OleDb
'Imports System.Data.SqlClient
'Imports System.Data.OracleClient
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Frm_GenralData




    Sub last_Data()


        On Error Resume Next
        sql = "SELECT        MAX(code) AS MaxmamNo FROM  " & vartable & "   HAVING(MAX(code) Is Not NULL)  "

        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            Com_Code.Text = rs2("MaxmamNo").Value + 1
        Else
            Com_Code.Text = 1


        End If
    End Sub

    Sub clear()
        txt_name.Text = ""

    End Sub


    Private Sub Frm_Genarl_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        last_Data()
        clear()
        TabControl1.SelectedTabIndex = 0
        'find()
        Search()

        TabControl1.SelectedTabIndex = 1
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
        last_Data()
        clear()
    End Sub



    Sub Search()
        'On Error Resume Next

       

        If varCodeConnaction = 1 Then '======Sql
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            sql = "SELECT  code,name FROM  " & vartable & "    "
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(0).Width = "50"
            GridView1.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        'If varCodeConnaction = 2 Then '======Oracle
        '    Dim ss As String
        '    Dim con As New OleDb.OleDbConnection
        '    ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
        '    con.ConnectionString = ss
        '    con.Open()
        '    sql = "SELECT  code,name FROM  " & vartable & "   "
        '    rs = Cnn.Execute(sql)
        '    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        '    'create a new dataset
        '    Dim ds As New DataSet()
        '    'fill the datset
        '    da.Fill(ds)
        '    GridControl1.DataSource = ds.Tables(0)
        '    'GridColumn1.Caption = "d"
        '    GridView1.Columns(0).Caption = "الكود"
        '    GridView1.Columns(1).Caption = "الاسم"
        '    GridView1.Columns(0).Width = "50"
        '    GridView1.Columns(1).Width = "150"
        '    ds = Nothing
        '    da = Nothing
        '    con.Close()
        '    con.Dispose()
        'End If
    End Sub



    Private Sub GridControl1_ControlAdded1(sender As Object, e As ControlEventArgs) Handles GridControl1.ControlAdded
        'Dim con As New SqlConnection("Data Source= test ; Initial Catalog= hr ; user id=hr ; password= hr")
        'Dim com As SqlCommand
        'Dim datatable As New DataTable
        ''con.Open()
        ''com = New SqlCommand("SELECT  Code,Name FROM  " & vartable & "", con)
        ''datatable.Load(com.ExecuteReader)
        ' ''GridControl1.DataSource = datatable
        ' ''GridControl1.DataMember = datatable.TableName
        ''con.Close()




        'Dim oradb As String = "Data Source=test;User Id=hr;Password=hr;"
        'Dim conn As New OracleConnection(oradb)
        'conn.Open()
        'Dim cmd As New OracleCommand
        'cmd.Connection = conn

        'cmd.CommandText = "SELECT  Code,Name FROM  " & vartable & " "
        'cmd.CommandType = CommandType.Text
        'Dim dr As OracleDataReader = cmd.ExecuteReader()


        'datatable.Load(cmd.ExecuteReader)
        ''conn.Close()
        ''Dim cmd As New OracleCommand
        ''cmd.Connection = conn
        ''cmd.CommandText = "SELECT  Code,Name FROM  " & vartable & " "
        ''cmd.CommandType = CommandType.Text
        ''Dim dr As OracleDataReader = cmd.ExecuteReader()
        ''dr.Read()

        ''conn.Dispose()

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'If NoSerailcolume = 1 Then
        'On Error Resume Next

        '      int focusedRow = _grvPregled.FocusedRowHandle;
        '_grcPregled.DataSource = listOfData;
        '_grvPregled.FocusedRowHandle = focusedRow;
        '_grvPregled.SelectRow(focusedRow);
        '_grvPregled.Focus();
        '  sql = "SELECT     * " & _
        '" FROM         " & vartable & "  "
        '  Cnn.Execute(sql)
        '  rs = Cnn.Execute(sql)
        'Dim value2 As String = GridView1.GetFocusedRowCellValue("1").ToString()

        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        'Dim value As String = GridView1.GetFocusedRowCellValue("code").ToString()
        'Dim value2 As String = GridView1.GetFocusedRowCellValue("name").ToString
        Com_Code.Text = value
        txt_name.Text = value2
        '' ''cmd_update.Enabled = True
        '' ''Cmd_Delete.Enabled = True
        TabControl1.SelectedTabIndex = 0
        ''End If
        ''Me.txt_name.Text = GridView1.GetFocusedDisplayText(1)

        'Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        'For Each rowHandle As Integer In selectedRows
        '    If rowHandle >= 0 Then
        '        Dim cellValue = GridControl1.GridView1.GetRowCellValue(rowHandle, 1)
        '    End If
        'Next rowHandle

        'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "1", 2)
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        '===========================================================
        sql = "SELECT     * " & _
        " FROM         " & vartable & "  WHERE     (Code = " & Com_Code.Text & ") "
        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox(" الرقم تكرر", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub
        '==========================================
        sql = "SELECT     * " & _
          " FROM         " & vartable & "  WHERE     (Name = '" & txt_name.Text & "') "
        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox(" الاسم تكرار", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub
        '===============================================
        last_Data()
        If Me.Text = " مركات السيارات " Then

            If Len(Frm_Car.txt_car_brand_btn.Text) = 0 Then
                MsgBox(" من فضلك اختار ماركة المركبة", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module")
            Else
                sql = "INSERT INTO   " & vartable & "  (Code, Name,car_brand) " &
       " values  (" & Com_Code.Text & " ,N'" & txt_name.Text & "','" & Frm_Car.txt_car_brand_btn.Text & "')"
                Cnn.Execute(sql)
                MsgBox("تم الحفظ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

            End If

        ElseIf Me.Text = " الشركات الفرعية " Then
            If Len(Frm_Cust.txt_btn_main_customer_company.Text) = 0 Then
                MsgBox(" من فضلك اختار الشركة الرئيسية", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module")
            Else
                sql = "INSERT INTO   " & vartable & "  (Code, Name,main_company) " &
       " values  (" & Com_Code.Text & " ,N'" & txt_name.Text & "','" & Frm_Cust.txt_btn_main_customer_company.Text & "')"
                Cnn.Execute(sql)
                MsgBox("تم الحفظ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

            End If
        Else

            sql = "INSERT INTO   " & vartable & "  (Code, Name,Compny_Code) " &
        " values  (" & Com_Code.Text & " ,N'" & txt_name.Text & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)
            MsgBox("تم الحفظ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        End If
        'MsgBox("تم الحفظ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        clear()
        Search()
        'find()

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        last_Data()
        clear()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim x As String
        x = MsgBox("هل تريد الحذف ؟", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete  " & vartable & "   WHERE code = " & Com_Code.Text & "  "
                rs = Cnn.Execute(sql)
                MsgBox("تم الحذف", MsgBoxStyle.Information, "ERP Solution Software Module")
                last_Data()
                clear()
                'find()
                Search()
        End Select
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click

        sql = "SELECT     * " & _
          " FROM         " & vartable & "  WHERE     (Name = '" & txt_name.Text & "') "
        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox(" الاسم تكرار", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub



        sql = "UPDATE   " & vartable & "   SET Name = '" & txt_name.Text & "' WHERE code = " & Com_Code.Text & "  "
        rs = Cnn.Execute(sql)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "ERP Solution Software Module")
        Search()

        'find()
    End Sub




    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class