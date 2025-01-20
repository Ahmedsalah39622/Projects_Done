Imports System.Data.OleDb

Public Class Frm_LookupInvoiceRecipt

    Private Sub Frm_LookupInvoiceRecipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_CustomerName.Text = ""
        txt_InvoiceNo.Text = ""
    End Sub

    Sub Find_Invoice()

        sql2 = "   SELECT        dbo.TB_Header_InvoiceSal.Ext_InvoiceNo AS Code, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) AS TotalInvoice, " & _
"                         SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * 14 / 100 AS Tax, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) + SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * 14 / 100 AS totalInv, " & _
"        dbo.Emp_employees.Emp_Name " & _
" FROM            dbo.TB_Header_InvoiceSal INNER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_InvoiceSal.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.FindCustomer.Compny_Code INNER JOIN " & _
"                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ser_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo AND  " & _
"                         dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
"                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code " & _
" GROUP BY dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.TB_Header_InvoiceSal.Compny_Code, dbo.TB_Header_InvoiceSal.Customer_No,  " & _
"        dbo.Emp_employees.Emp_Name " & _
" HAVING        (dbo.TB_Header_InvoiceSal.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_InvoiceSal.Customer_No = '" & varaccountCustomer & "') "


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "اسم العميل"
        GridView1.Columns(3).Caption = "قيمة الفاتورة"
        GridView1.Columns(4).Caption = "الضريبة"
        GridView1.Columns(5).Caption = "القيمة بعد الضريبة"
        GridView1.Columns(6).Caption = "اسم مندوب البيع"



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_CustomerName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        txt_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Cmd_OpenInvoice.Enabled = True
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Frm_ReciptCash2.Com_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Me.Close()
    End Sub

    Private Sub Cmd_OpenInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_OpenInvoice.Click
        Frm_SalseInvoice.Close()
        Frm_SalseInvoice.Com_InvoiceNo2.Text = txt_InvoiceNo.Text
        Frm_SalseInvoice.find_hedar()
        Frm_SalseInvoice.find_detalis()
        Frm_SalseInvoice.Total_Sum()
        Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()
    End Sub
End Class