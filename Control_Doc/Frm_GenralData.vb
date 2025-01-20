Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Frm_GenralData
  
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
        last_Data()
        clear()
    End Sub


    Sub last_Data()


        On Error Resume Next
        sql = "SELECT        MAX(code) AS MaxmamNo FROM  " & vartable & "  HAVING(MAX(code) Is Not NULL) "

        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            Com_Code.Text = rs2("MaxmamNo").Value + 1
        Else
            Com_Code.Text = 1
            clear()

        End If
    End Sub

    Sub clear()
        txt_Name.Text = ""


    End Sub


    Private Sub Frm_Genarl_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        

        last_Data()
        clear()
        TabControl1.SelectedTabIndex = 0
            'find()
        Search()

        TabControl1.SelectedTabIndex = 1
    End Sub



    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear()
    End Sub


    Private Sub cmd_Save_Click_1(sender As Object, e As EventArgs) Handles cmd_Save.Click
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "MP Solution Software Module") : Exit Sub


        sql = "SELECT     * " & _
        " FROM         " & vartable & "  WHERE     (Code = " & Com_Code.Text & ")"
        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox(" الاسم تكرار", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "MP Solution Software Module")
        Else

            sql = "INSERT INTO   " & vartable & "  (Code, Name) " & _
            " values  (" & Com_Code.Text & " ,'" & txt_name.Text & "')"
            Cnn.Execute(sql)

            MsgBox("تم الحفظ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "MP Solution Software Module")
            last_Data()
            clear()
            Search()
            'find()
        End If
    End Sub

    Private Sub cmd_update_Click_1(sender As Object, e As EventArgs) Handles cmd_update.Click
        sql = "UPDATE   " & vartable & "   SET Name = '" & txt_name.Text & "' WHERE code = " & Com_Code.Text & ""
        rs = Cnn.Execute(sql)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "ERP Solution Software Module")
        Search()
        'find()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim x As String
        x = MsgBox("هل تريد الحذف ؟", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete  " & vartable & "   WHERE code = " & Com_Code.Text & " "
                rs = Cnn.Execute(sql)
                MsgBox("تم الحذف", MsgBoxStyle.Information, "ERP Solution Software Module")
                last_Data()
                clear()
                'find()
                Search()
        End Select
    End Sub


    Sub Search()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "SELECT  code,name FROM  " & vartable & "   "
        rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else
        '    sql = "SELECT  code,name FROM  " & vartable & "   "

        'End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


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
    End Sub

    

    Private Sub GridControl1_ControlAdded1(sender As Object, e As ControlEventArgs) Handles GridControl1.ControlAdded
        Dim con As New SqlConnection("Data Source= osama\omar ; Initial Catalog= DB_ERP_Css ; user id=css ; password= omar2007")
        Dim com As SqlCommand
        Dim datatable As New DataTable
        con.Open()
        com = New SqlCommand("SELECT  Code,Name FROM  " & vartable & "", con)
        datatable.Load(com.ExecuteReader)
        'GridControl1.DataSource = datatable
        'GridControl1.DataMember = datatable.TableName
        con.Close()


        'Com_Code.DataBindings.Clear()
        'txt_name.DataBindings.Clear()
        ''txt_Description.DataBindings.Clear()
        ''Com_Code.DataBindings.Add(New Binding("text", datatable, "Code"))
        'txt_name.DataBindings.Add(New Binding("text", datatable, "name"))
        ''txt_Description.DataBindings.Add(New Binding("text", datatable, "Name"))

        'cmd_update.Enabled = True
        'Cmd_Delete.Enabled = True
    End Sub

    
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'If NoSerailcolume = 1 Then
        On Error Resume Next

        '      int focusedRow = _grvPregled.FocusedRowHandle;
        '_grcPregled.DataSource = listOfData;
        '_grvPregled.FocusedRowHandle = focusedRow;
        '_grvPregled.SelectRow(focusedRow);
        '_grvPregled.Focus();
       
        Dim value As String = GridView1.GetFocusedRowCellValue("code").ToString()
        Dim value2 As String = GridView1.GetFocusedRowCellValue("name").ToString
        Com_Code.Text = value
        txt_name.Text = value2
        cmd_update.Enabled = True
        Cmd_Delete.Enabled = True
        TabControl1.SelectedTabIndex = 0
        'End If
    End Sub
End Class