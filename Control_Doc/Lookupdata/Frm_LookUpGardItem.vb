Imports System.Data.OleDb

Public Class Frm_LookUpGardItem

    Private Sub Frm_LookUpGardItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub
    Sub Search()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT        dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Name AS NameItem, SUM(dbo.Statement_OfItem.Export) AS Wared, ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, " & _
"                         ROUND(SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import), 2) AS Balance, dbo.BD_Stores.Name  " & _
" FROM            dbo.Statement_OfItem INNER JOIN  " & _
"                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN  " & _
"                         dbo.BD_ITEM ON dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code  " & _
" GROUP BY dbo.Statement_OfItem.NoItem, dbo.BD_Stores.Name, dbo.BD_ITEM.Name  " & _
"            HAVING(dbo.Statement_OfItem.NoItem = '" & varcodeitem & "') "

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "أسم الصنف"
        GridView1.Columns(2).Caption = "الوارد"
        GridView1.Columns(3).Caption = "المنصرف"
        GridView1.Columns(4).Caption = "رصيد"
        GridView1.Columns(5).Caption = "المخزن"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "250"
        GridView1.Columns(2).Width = "100"
        GridView1.Columns(3).Width = "100"
        GridView1.Columns(4).Width = "120"
        GridView1.Columns(5).Width = "200"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub


    Private Sub Frm_LookUpGardItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Me.Close()


    End Sub


End Class