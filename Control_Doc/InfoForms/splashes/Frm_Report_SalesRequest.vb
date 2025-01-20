Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Report_SalesRequest
    

    Sub find_StutasOrderItem_New()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "  SELECT        dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, RTRIM(dbo.FindCustomer.Name) AS Name, dbo.Emp_employees.Emp_Name, dbo.Tb_TypeItemList.Name AS NameItemGroup,  " & _
       "                         dbo.TB_Detils_OrderItem.Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_StatusSalseOrder.Name AS StatusOrder " & _
       " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
       "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
       "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.Code INNER JOIN " & _
       "                         dbo.TB_StatusSalseOrder ON dbo.TB_Header_OrderItem.Status_Order = dbo.TB_StatusSalseOrder.Code INNER JOIN " & _
       "                         dbo.TB_Detils_OrderItem ON dbo.TB_Header_OrderItem.Order_Ser = dbo.TB_Detils_OrderItem.Order_Ser AND dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Detils_OrderItem.Order_NO INNER JOIN " & _
       "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Ex_Item = dbo.BD_ITEM.Ex_Item INNER JOIN " & _
       "                         dbo.Tb_TypeItemList ON dbo.TB_Detils_OrderItem.Flag_Item = dbo.Tb_TypeItemList.Code " & _
       "        WHERE(dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "')  AND (dbo.TB_Header_OrderItem.Status_Order = 0) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "75"
        GridView6.Columns(2).Width = "200"
        GridView6.Columns(3).Width = "200"
        GridView6.Columns(4).Width = "150"
        GridView6.Columns(5).Width = "150"
        GridView6.Columns(6).Width = "250"
        GridView6.Columns(7).Width = "150"


        GridView6.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        GridView6.Columns(7).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الطلبية"
        GridView6.Columns(1).Caption = "تاريخ الطلبية "
        GridView6.Columns(2).Caption = "أسم العميل"
        GridView6.Columns(3).Caption = "أسم المندوب"
        GridView6.Columns(4).Caption = "نوع الصنف"
        GridView6.Columns(5).Caption = "رقم الصنف"
        GridView6.Columns(6).Caption = "أسم الصنف"
        GridView6.Columns(7).Caption = "حالة الطلبية"




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
   
End Class