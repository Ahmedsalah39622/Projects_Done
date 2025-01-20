Imports System.Data.OleDb

Public Class Frm_RequestOrderNoAvilabel

    Private Sub Frm_RequestOrderNoAvilabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_data_request()
    End Sub
    Sub find_data_request()
        sql2 = "   SELECT TOP (100) PERCENT dbo.TB_Header_OrderItem.Order_Ser, dbo.TB_Header_OrderItem.Order_NO AS OrderRequest, dbo.TB_Header_OrderItem.Order_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS namecustomer, " & _
"        dbo.Emp_employees.Emp_Name " & _
" FROM     dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
"                  dbo.TB_Header_OrderItem ON dbo.ST_CHARTOFACCOUNT.Account_No = dbo.TB_Header_OrderItem.Customer_No INNER JOIN " & _
"                  dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
"                  dbo.TB_Header_AznItem_Stores ON dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Header_AznItem_Stores.Order_NO " & _
"        WHERE(dbo.TB_Header_AznItem_Stores.Order_NO Is NULL) " & _
" ORDER BY dbo.TB_Header_OrderItem.Order_Ser "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم"
        GridView1.Columns(1).Caption = "رقم التوريد"
        GridView1.Columns(2).Caption = "التاريخ"
        GridView1.Columns(3).Caption = "العميل"
        GridView1.Columns(4).Caption = "المندوب"
  



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Frm_AznSarf2.MdiParent = Mainmune
        Frm_AznSarf2.Show()

    End Sub
End Class