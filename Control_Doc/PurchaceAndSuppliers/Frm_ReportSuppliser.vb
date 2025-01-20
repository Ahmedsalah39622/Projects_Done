Imports System.Data.OleDb

Public Class Frm_ReportSuppliser
    Dim oldDate As Date
    Dim oldDay As Integer



    Sub Find_SuplisserFill()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        sql2 = "    SELECT        dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Header_InvoicePrcheses.InvoiceDate, SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) AS Total_Ivoice, " & _
    "                         SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) * tax_n / 100 AS tax, SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) + SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) * 14 / 100 AS totalpr, " & _
            "dbo.St_SuppliserData.Supliser_FileNoTax, dbo.TB_Header_InvoicePrcheses.tax_n " & _
" FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
"                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo INNER JOIN " & _
"                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo " & _
"        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) " & _
" GROUP BY dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.St_SuppliserData.Supliser_FileNoTax, dbo.TB_Header_InvoicePrcheses.tax_n " & _
" HAVING        (dbo.TB_Header_InvoicePrcheses.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoicePrcheses.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "اسم المورد"
        GridView1.Columns(2).Caption = "تاريخ الفاتورة"
        GridView1.Columns(3).Caption = "اجمالى الفاتورة"
        GridView1.Columns(4).Caption = "الضريبة"
        GridView1.Columns(5).Caption = "صافى الفاتورة"
        GridView1.Columns(6).Caption = "التسجيل الضريبى"

        GridView1.Columns(7).Visible = False

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Find_TotalInvoice()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "   SELECT        dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, " & _
   "                         dbo.TB_Detalis_InvoicePrcheses.Quntity, dbo.BD_Unit.Name AS unit, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.TB_Detalis_InvoicePrcheses.Total_Item, dbo.BD_GROUPITEMMAIN.Name AS GM " & _
   " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
   "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo AND " & _
   "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.TB_Detalis_InvoicePrcheses.Compny_Code INNER JOIN " & _
   "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND  " & _
   "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.St_SuppliserData.Compny_Code INNER JOIN " & _
   "                         dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
   "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code " & _
   "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) " & _
   " GROUP BY dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name,  " & _
   "        dbo.TB_Detalis_InvoicePrcheses.Quntity, dbo.BD_Unit.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.TB_Detalis_InvoicePrcheses.Total_Item " & _
   " HAVING        (dbo.TB_Header_InvoicePrcheses.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoicePrcheses.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "أسم المورد"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "اسم الصنف"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "السعر"
        GridView1.Columns(8).Caption = "الاجمالى"
        GridView1.Columns(9).Caption = "مجموعة الصنف"





        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub Find_SumCrdit()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "  SELECT        dbo.vw_suppliser_invoice.Customer_No, dbo.St_SuppliserData.Supliser_Name, dbo.vw_suppliser_invoice.aa, iif(dbo.TB_Expenses.Expenses_Value_EGP is null,'0',dbo.TB_Expenses.Expenses_Value_EGP ) as value,dbo.vw_suppliser_invoice.aa -  iif(dbo.TB_Expenses.Expenses_Value_EGP is null,'0',dbo.TB_Expenses.Expenses_Value_EGP )  as rem " & _
  " FROM            dbo.vw_suppliser_invoice INNER JOIN " & _
  "                         dbo.St_SuppliserData ON dbo.vw_suppliser_invoice.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND  " & _
  "                         dbo.vw_suppliser_invoice.Compny_Code = dbo.St_SuppliserData.Compny_Code LEFT OUTER JOIN " & _
  "                         dbo.TB_Expenses ON dbo.St_SuppliserData.Supliser_AccountNo = dbo.TB_Expenses.AccountNo1 "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "أسم الحساب"
        GridView1.Columns(2).Caption = "اجمال الفواتير"
        GridView1.Columns(3).Caption = "اجمالى المسدد"
        GridView1.Columns(4).Caption = "المتبقى"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum





    End Sub
    Sub Find_SalCustomer()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "    SELECT        dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, dbo.BD_Unit.Name AS unit, dbo.TB_Detalis_InvoicePrcheses.Price_Item, MAX(dbo.TB_Header_InvoicePrcheses.InvoiceDate) AS Dateprcheses, " & _
    "                         dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.St_SuppliserData.Supliser_Name " & _
    " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
    "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo AND  " & _
    "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.TB_Detalis_InvoicePrcheses.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
    "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
    "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND " & _
    "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.St_SuppliserData.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Unit.Compny_Code " & _
    "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) and (dbo.St_SuppliserData.Compny_Code = '" & VarCodeCompny & "') " & _
    " GROUP BY dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.St_SuppliserData.Supliser_Name, dbo.BD_Unit.Name "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.BestFitColumns()

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "اسم الصنف"
        GridView1.Columns(2).Caption = "الوحدة"
        GridView1.Columns(3).Caption = "اخر سعر شراء"
        GridView1.Columns(4).Caption = "تاريخ اخر سعر"
        GridView1.Columns(5).Caption = "مجموعة الصنف"
        GridView1.Columns(6).Caption = "اسم المورد"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Sub Find_EstlamCustomer()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "   SELECT        TOP (100) PERCENT dbo.TB_Detils_AznItem_Stores.Order_Stores_NO, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.FindCustomer.Name, dbo.BD_ITEM.Name AS NameItem, " & _
   "                         dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_AznItem_Stores.Quntity, dbo.TB_Detils_AznItem_Stores.Price_Unit, ROUND(dbo.TB_Detils_AznItem_Stores.Quntity * dbo.TB_Detils_AznItem_Stores.Price_Unit, 2) " & _
   "                         AS TotalAll, dbo.BD_Stores.Name AS NameStores " & _
   "FROM            dbo.TB_Detils_AznItem_Stores INNER JOIN " & _
   "                         dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Detils_AznItem_Stores.Order_NO = dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO AND  " & _
   "                         dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code AND dbo.TB_Detils_AznItem_Stores.No_Item = dbo.TB_Detils_OrderItem_Stores.No_Item INNER JOIN " & _
   "                         dbo.TB_Detils_OrderItem ON dbo.TB_Detils_OrderItem_Stores.Order_NO = dbo.TB_Detils_OrderItem.Order_NO AND dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_OrderItem.No_Item AND  " & _
   "                         dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code INNER JOIN " & _
   "                         dbo.TB_Header_OrderItem ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code AND dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Header_OrderItem.Order_NO INNER JOIN " & _
   "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code INNER JOIN " & _
   "                         dbo.BD_Stores ON dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_Stores.Compny_Code AND dbo.TB_Detils_AznItem_Stores.Code_Stores = dbo.BD_Stores.Code INNER JOIN " & _
   "                         dbo.BD_ITEM ON dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_AznItem_Stores.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
   "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                         dbo.TB_Header_AznItem_Stores ON dbo.TB_Detils_AznItem_Stores.Order_Stores_NO = dbo.TB_Header_AznItem_Stores.Order_Stores_NO AND  " & _
   "        dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.TB_Header_AznItem_Stores.Compny_Code where (dbo.TB_Detils_AznItem_Stores.Compny_Code = '" & VarCodeCompny & "')  and (dbo.TB_Header_AznItem_Stores.Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) and   (dbo.TB_Header_AznItem_Stores.Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
   " ORDER BY dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "200"
        GridView1.Columns(3).Width = "200"
        GridView1.Columns(4).Width = "100"
        GridView1.Columns(5).Width = "100"
        GridView1.Columns(6).Width = "100"
        GridView1.Columns(7).Width = "100"
        GridView1.Columns(8).Width = "150"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "السعر"
        GridView1.Columns(7).Caption = "الاجمالى"
        GridView1.Columns(8).Caption = "المخزن"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Find_LimitedCustomer()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()





        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "  SELECT        dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, ROUND(SUM(dbo.MovmentStatement.Debit_EGP) - SUM(dbo.MovmentStatement.Cridit_EGP), 2) AS Balance, " & _
  "                         dbo.St_CustomerData.Customer_Creditlimit, dbo.St_CustomerData.Customer_Phon1, dbo.St_CustomerData.Customer_Phon2, dbo.St_CustomerData.Customer_Email, " & _
  "                         dbo.BD_REGION.Name AS NameRegion " & _
  " FROM            dbo.St_CustomerData INNER JOIN " & _
  "                         dbo.FindCustomer ON dbo.St_CustomerData.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.St_CustomerData.Customer_Code = dbo.FindCustomer.Customer_Code INNER JOIN " & _
  "                        dbo.MovmentStatement ON dbo.FindCustomer.code = dbo.MovmentStatement.AccountNo AND dbo.FindCustomer.Compny_Code = dbo.MovmentStatement.Compny_Code LEFT OUTER JOIN " & _
  "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
  " GROUP BY dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, dbo.MovmentStatement.Compny_Code, dbo.St_CustomerData.Customer_Creditlimit, dbo.St_CustomerData.Customer_Phon1,  " & _
  "        dbo.St_CustomerData.Customer_Phon2, dbo.St_CustomerData.Customer_Email, dbo.BD_REGION.Name " & _
  " HAVING        (dbo.MovmentStatement.Compny_Code =  '" & VarCodeCompny & "') AND (ROUND(SUM(dbo.MovmentStatement.Debit_EGP) - SUM(dbo.MovmentStatement.Cridit_EGP), 2) > dbo.St_CustomerData.Customer_Creditlimit) "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "200"
        GridView1.Columns(3).Width = "200"
        GridView1.Columns(4).Width = "100"
        GridView1.Columns(5).Width = "100"
        GridView1.Columns(6).Width = "100"
        GridView1.Columns(7).Width = "100"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "أسم الحساب"
        GridView1.Columns(2).Caption = "المديونية الحالية"
        GridView1.Columns(3).Caption = "حد الائتمان"
        GridView1.Columns(4).Caption = "رقم التليفون 1"
        GridView1.Columns(5).Caption = "رقم تليفون 2"
        GridView1.Columns(6).Caption = "الاميل"
        GridView1.Columns(7).Caption = "المنطقة"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Private Sub Cmd_CustomerFill_Click(sender As Object, e As EventArgs) Handles Cmd_CustomerFill.Click
        'Cmd_CustomerFill.FontBold = True
        vardisplayReport3 = 0
        LabelX1.Text = "تقرير يومية المشتريات خلال فترة"
        Find_SuplisserFill()
        GridView1.BestFitColumns()
    End Sub
   

    Private Sub Frm_ReportCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

 

    Private Sub Cmd_TotalInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_TotalInvoice.Click
        'Cmd_CustomerFill.FontBold = False
        'Cmd_TotalInvoice.FontBold = True
        vardisplayReport3 = 1
        LabelX1.Text = "تقرير يومية المشتريات للموردين  الاصناف - خلال فترة"
        Find_TotalInvoice()
        GridView1.BestFitColumns()
    End Sub



    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'On Error Resume Next
        'sql = "Delete TB_TempReport1   "
        'rs = Cnn.Execute(sql)

        'Dim result As Integer = 0
        'For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle




        '    If vardisplayReport = 0 Then ' المديونية



        '        Dim var5, var6, var7 As String
        '        var5 = ""
        '        var6 = ""
        '        var7 = ""
        '        var5 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))))
        '        var6 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))))
        '        var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))


        '        sql = "insert into TB_TempReport1  (Account_Main,Account_No,Account_Name" & _
        '        " ,Debit,Crdit,Balance,Compny_Code,Region_Customer,Group_Item) " & _
        '        " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '        " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & var5 & "','" & VarCodeCompny & "'  ,'" & var6 & "' ,'" & var7 & "') "
        '        Cnn.Execute(sql)
        '    End If


        '    If vardisplayReport = 1 Then 'مبيعات الفواتير

        '        Dim var5, var6, var7 As String
        '        var5 = ""
        '        var6 = ""
        '        var7 = ""

        '        var5 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))))
        '        var6 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))))
        '        var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))



        '        sql = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name,NameEmp" & _
        '        " ,Region_Customer,TypeMove,NameDeprt,TotalInvoice,Tax_Value,Discount,TotalAll_Invoice) " & _
        '        " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '        " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & var5 & "','" & var6 & "','" & var7 & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "'  ) "
        '        Cnn.Execute(sql)
        '    End If


        '    If vardisplayReport = 5 Then 'مبيعات العملاء من الاصناف
        '        sql = "insert into TB_TempReport1  (Customer_Name,Invoice_No,Date_Invoice" & _
        '        " ,code_Item,NameItem,Unit,Qty,Price,TotalItem,unit2,Convert_Qyt,Qyt_All) " & _
        '        " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '        " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "' )"
        '        Cnn.Execute(sql)
        '    End If


        '    If vardisplayReport = 3 Then 'متحصلات العملاء  



        '        sql = "insert into TB_TempReport1  (Account_No,Account_Name,Date_Collect,TypeMove,NameEmp,Value_cash,Discrption ) " & _
        '        " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "' ) "
        '        Cnn.Execute(sql)
        '    End If


        '    'If vardisplayReport = 7 Then 'العملاء تعدت حد الائتمان
        '    '    sql = "insert into TB_TempReport1  (Account_No,Customer_Name,Balance,LimitedCustomer" & _
        '    '    " ,Phon1_Customer,Phon2_Customer,Email_Customer,Region_Customer,Compny_Code) " & _
        '    '    " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '    '    " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "','" & VarCodeCompny & "'  ) "
        '    '    Cnn.Execute(sql)
        '    'End If

        '    'If vardisplayReport = 6 Then 'تقرير اذون الاستلام
        '    '    sql = "insert into TB_TempReport1  (Account_No,Customer_Name,Balance,LimitedCustomer" & _
        '    '    " ,Phon1_Customer,Phon2_Customer,Email_Customer,Region_Customer,Compny_Code) " & _
        '    '    " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '    '    " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "','" & VarCodeCompny & "'  ) "
        '    '    Cnn.Execute(sql)
        '    'End If

        'Next rowHandle
        'Frm_Report_all.Show()

        'GridView1.ShowPrintPreview()
    End Sub


    Private Sub Cmd_Crdit_Click(sender As Object, e As EventArgs) Handles Cmd_Crdit.Click

        'Cmd_CustomerFill.FontBold = False
        'Cmd_SalCustomer.FontBold = True
        LabelX1.Text = "تقرير اخر سعر شراء من الاصناف للموردين"
        vardisplayReport3 = 5
        Find_SalCustomer()
        GridView1.BestFitColumns()



    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If vardisplayReport3 = 0 Then Find_SuplisserFill()
        If vardisplayReport3 = 1 Then Find_TotalInvoice()
        If vardisplayReport = 3 Then Find_SumCrdit()
        If vardisplayReport = 5 Then Find_SalCustomer()


    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs)
        vardisplayReport = 6
        LabelX1.Text = "تقرير بأذون أستلام البضاعة للعملاء"
        vardisplayReport = 6
        Find_EstlamCustomer()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs)
        LabelX1.Text = "تقرير العملاء تعدت حد الائتمان"
        vardisplayReport = 7
        Find_LimitedCustomer()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        'Cmd_CustomerFill.FontBold = False
        'Cmd_Crdit.FontBold = True
        vardisplayReport3 = 3
        LabelX1.Text = "تقرير دفعات الموردين خلال فترة"
        Find_SumCrdit()
        GridView1.BestFitColumns()
    End Sub

    Private Sub Cmd_SalCustomer_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click


    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick

        'Dim VarNoMove As String

        If vardisplayReport3 = 1 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_Prcheses_Invoice.find_hedar()
            Frm_Prcheses_Invoice.find_detalis()
            Frm_Prcheses_Invoice.Total_Sum()
            Frm_Prcheses_Invoice.sum_tax()
            Frm_Prcheses_Invoice.TabPane1.SelectedPageIndex = 0
            Frm_Prcheses_Invoice.MdiParent = Mainmune
            Frm_Prcheses_Invoice.Show()
        End If


        If vardisplayReport3 = 3 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Frm_AccountStatement.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_AccountStatement.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))

            Frm_AccountStatement.MdiParent = Mainmune
            Frm_AccountStatement.find_Acc2()
            Frm_AccountStatement.Show()


        End If


        If vardisplayReport3 = 0 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_Prcheses_Invoice.find_hedar()
            Frm_Prcheses_Invoice.find_detalis()
            Frm_Prcheses_Invoice.Total_Sum()
            Frm_Prcheses_Invoice.sum_tax()
            Frm_Prcheses_Invoice.TabPane1.SelectedPageIndex = 0
            Frm_Prcheses_Invoice.MdiParent = Mainmune
            Frm_Prcheses_Invoice.Show()
        End If
    End Sub

    Private Sub GridControl1_DragDrop(sender As Object, e As DragEventArgs) Handles GridControl1.DragDrop

    End Sub
End Class