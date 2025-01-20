Imports System.Data.OleDb


Public Class Frm_DataItem


    Private Sub Frm_ScanData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_ERP2.DataItem' table. You can move, or remove it, as needed.
        Me.DataItemTableAdapter.Fill(Me.DB_ERP2.DataItem)
        'TODO: This line of code loads data into the 'DB_ERP_CssDataSet.DataItem' table. You can move, or remove it, as needed.
        'Me.DataItemTableAdapter.Fill(Me.DB_ERP_CssDataSet.DataItem)
        Search()
        Search2()
    End Sub
    Sub Search()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql = "SELECT  code,name FROM  " & vartable & "   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else
        'sql = "SELECT  code,name FROM  " & vartable & "   "

        sql = "SELECT dbo.GroupItemMain.Name AS NameGroup, dbo.GroupItem1.Name AS Model, dbo.DataItem.Name AS NameItem " & _
        " FROM     dbo.GroupItemMain INNER JOIN " & _
        "                  dbo.GroupItem1 ON dbo.GroupItemMain.Code = dbo.GroupItem1.CodeMainGroup INNER JOIN " & _
        "                  dbo.DataItem ON dbo.GroupItemMain.Code = dbo.DataItem.CodeGroupItemMain AND dbo.GroupItem1.Code = dbo.DataItem.CodeGroupItem1 "



        'End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl1.DataSource = ds.Tables(0)



        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "المجموعة الرئيسية"
        GridView1.Columns(1).Caption = "الموديل"
        GridView1.Columns(2).Caption = "أسم الصنف"

        GridView1.Columns(0).Width = "50"
        GridView1.Columns(1).Width = "150"
        GridView1.Columns(2).Width = "150"




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub



    Sub Search2()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql = "SELECT  code,name FROM  " & vartable & "   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else
        'sql = "SELECT  code,name FROM  " & vartable & "   "

        sql = " SELECT NoItem, DateMoveM, Export, Import     FROM dbo.Statement_OfItem  WHERE(NoItem = 3)"

        'End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl2.DataSource = ds.Tables(0)



        'GridColumn1.Caption = "d"
        GridView3.Columns(0).Caption = "رقم الصنف"
        GridView3.Columns(1).Caption = "التاريخ"
        GridView3.Columns(2).Caption = "وارد"
        GridView3.Columns(3).Caption = "منصرف"

        GridView3.Columns(0).Width = "50"
        GridView3.Columns(1).Width = "150"
        GridView3.Columns(2).Width = "150"
        GridView3.Columns(3).Width = "150"




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
End Class