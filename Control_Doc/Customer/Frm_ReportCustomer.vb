Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class Frm_ReportCustomer
    Dim oldDate As Date
    Dim oldDay As Integer

    Sub All_invoice()

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


        sql2 = "   SELECT        dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name AS NameItem, dbo.Vw_DetilsInvoice.Unit,  " & _
               "                         dbo.Vw_DetilsInvoice.Quntity, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item,  " & _
               "                         dbo.Vw_DetilsInvoice.Total_Item * dbo.TB_Header_InvoiceSal.tax_n / 100 AS Tax, dbo.Vw_DetilsInvoice.Total_Item + dbo.Vw_DetilsInvoice.Total_Item * dbo.TB_Header_InvoiceSal.tax_n / 100 AS TotalAll " & _
               " FROM            dbo.Vw_DetilsInvoice INNER JOIN " & _
               "                         dbo.TB_Header_InvoiceSal ON dbo.Vw_DetilsInvoice.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.Vw_DetilsInvoice.Ext_InvoiceNo = dbo.TB_Header_InvoiceSal.Ext_InvoiceNo INNER JOIN " & _
               "                         dbo.FindCustomer ON dbo.TB_Header_InvoiceSal.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.FindCustomer.Compny_Code " & _
               " WHERE        (dbo.Vw_DetilsInvoice.Compny_Code = '" & VarCodeCompny & "') AND  (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) AND (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
               " GROUP BY dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name, dbo.Vw_DetilsInvoice.Quntity,  " & _
               "        dbo.Vw_DetilsInvoice.Unit, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.TB_Header_InvoiceSal.tax_n "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة "
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "الكمية"
        GridView1.Columns(7).Caption = "السعر"
        GridView1.Columns(8).Caption = "العملة"
        GridView1.Columns(9).Caption = "الخصم"
        GridView1.Columns(10).Caption = "الاجمالى"
        GridView1.Columns(11).Caption = "الضريبة"
        GridView1.Columns(12).Caption = "الصافى"

        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub Find_CustomerFill()

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


        sql2 = " SELECT        RTRIM(ST_CHARTOFACCOUNT_1.AccountName) AS AccountName2, dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, SUM(dbo.MovmentStatement.Debit) AS SumDebit, " & _
             "                         SUM(dbo.MovmentStatement.Cridit) AS SumCridit, round(SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit),2) AS Resalt " & _
             " FROM            dbo.MovmentStatement INNER JOIN " & _
             "                         dbo.FindCustomer ON dbo.MovmentStatement.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.FindCustomer.code INNER JOIN " & _
             "                         dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
             "                         dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.ST_CHARTOFACCOUNT.Level_No2 = ST_CHARTOFACCOUNT_1.Account_No AND  " & _
             "        dbo.ST_CHARTOFACCOUNT.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code " & _
             " WHERE        (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME,'" & vardate2 & "', 102)) AND  " & _
             "                         (dbo.MovmentStatement.Compny_Code = '" & VarCodeCompny & "') " & _
             " GROUP BY dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, ST_CHARTOFACCOUNT_1.AccountName "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "150"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "350"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "الحساب الرئيسى"
        GridView1.Columns(1).Caption = "رقم الحساب  "
        GridView1.Columns(2).Caption = "أسم الحساب"
        GridView1.Columns(3).Caption = "مدين"
        GridView1.Columns(4).Caption = "دائن"
        GridView1.Columns(5).Caption = "رصيد"

        GridView1.BestFitColumns()

        GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



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



        sql2 = "  SELECT        dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAccount, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
  "                         AS TotalInvoice, dbo.TB_Header_InvoiceSal.tax_n, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * dbo.TB_Header_InvoiceSal.tax_n / 100 AS Tax, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
  "                         + SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * dbo.TB_Header_InvoiceSal.tax_n / 100 AS totalInv, RTRIM(dbo.St_CustomerData.Customer_NoReg_Tax) AS Reg_customer, dbo.Emp_employees.Emp_Name,  " & _
  "                         dbo.BD_REGION.Name AS Region " & _
  " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
  "                         dbo.TB_Header_InvoiceSal ON dbo.ST_CHARTOFACCOUNT.Account_No = dbo.TB_Header_InvoiceSal.Customer_No AND  " & _
  "                         dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code INNER JOIN " & _
  "                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ser_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo AND  " & _
  "                         dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
  "                         dbo.St_CustomerData ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
  "                         dbo.TB_Header_InvoiceSal.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
  "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
  "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
  " WHERE        (dbo.TB_Header_InvoiceSal.Compny_Code ='" & VarCodeCompny & "') AND (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) AND (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
  "                         (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
  " GROUP BY dbo.ST_CHARTOFACCOUNT.AccountName, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.tax_n, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_NoReg_Tax, " & _
   " dbo.Emp_employees.Emp_Name, dbo.BD_REGION.Name"




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "250"
        'GridView1.Columns(3).Width = "150"
        'GridView1.Columns(4).Width = "150"
        'GridView1.Columns(5).Width = "150"
        'GridView1.Columns(6).Width = "150"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "إجمالى الفاتورة"
        GridView1.Columns(4).Caption = "نسبة الضريبة"
        GridView1.Columns(5).Caption = "قيمة الضريبة"
        GridView1.Columns(6).Caption = "صافى الفاتورة"
        GridView1.Columns(7).Caption = "رقم التسجيل الضريبى"
        GridView1.Columns(8).Caption = "مندوب البيع"
        GridView1.Columns(9).Caption = "المنطقة"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



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



        'sql2 = "SELECT        dbo.FindCustomer.code, dbo.FindCustomer.Name, ROUND(SUM(dbo.MovmentStatement.Cridit), 2) AS SumCridit " & _
        '" FROM            dbo.FindCustomer INNER JOIN " & _
        '"                       dbo.MovmentStatement ON dbo.FindCustomer.code = dbo.MovmentStatement.AccountNo AND dbo.FindCustomer.Compny_Code = dbo.MovmentStatement.Compny_Code " & _
        '" WHERE        (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
        '"                         (dbo.FindCustomer.Compny_Code = '" & VarCodeCompny & "') " & _
        '" GROUP BY dbo.FindCustomer.code, dbo.FindCustomer.Name " & _
        '"        HAVING(SUM(dbo.MovmentStatement.Cridit) <> 0) "


        sql2 = " SELECT        dbo.FindCustomer.code, dbo.FindCustomer.Name, ROUND(SUM(dbo.MovmentStatement.Cridit), 2) AS SumCridit, dbo.TB_Receipt.Receipt_Date, iif(dbo.TB_Receipt.Type_Invoice =0 ,'دفعة مقدمة','فاتورة') as type,  " & _
 "                         dbo.TB_Type_Pay.Name AS Type_Pay, dbo.TB_Receipt.Invoice_No, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.Emp_employees.Emp_Name AS SalseSal, " & _
 "                         Emp_employees_1.Emp_Name AS SalseColected,DATEDIFF(day, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.TB_Receipt.Receipt_Date) AS DateDiff " & _
 " FROM            dbo.FindCustomer INNER JOIN " & _
 "                         dbo.MovmentStatement ON dbo.FindCustomer.code = dbo.MovmentStatement.AccountNo AND dbo.FindCustomer.Compny_Code = dbo.MovmentStatement.Compny_Code INNER JOIN " & _
 "                         dbo.TB_Receipt ON dbo.MovmentStatement.Compny_Code = dbo.TB_Receipt.Compny_Code AND dbo.MovmentStatement.NumberBill = dbo.TB_Receipt.Receipt_No INNER JOIN " & _
 "                         dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code LEFT OUTER JOIN " & _
 "                         dbo.Emp_employees AS Emp_employees_1 ON dbo.TB_Receipt.Compny_Code = Emp_employees_1.Compny_Code AND dbo.TB_Receipt.Code_Salse = Emp_employees_1.Emp_Code LEFT OUTER JOIN " & _
 "                         dbo.Emp_employees INNER JOIN " & _
 "                         dbo.TB_Header_InvoiceSal ON dbo.Emp_employees.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.Emp_employees.Emp_Code = dbo.TB_Header_InvoiceSal.Salse_No ON  " & _
 "        dbo.TB_Receipt.Invoice_No = dbo.TB_Header_InvoiceSal.Ext_InvoiceNo And dbo.TB_Receipt.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code " & _
 " WHERE        (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
 "                         (dbo.FindCustomer.Compny_Code = '2') AND (dbo.MovmentStatement.TypeBill = 3) " & _
 " GROUP BY dbo.FindCustomer.code, dbo.FindCustomer.Name, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Type_Invoice, dbo.TB_Receipt.Invoice_No, dbo.TB_Header_InvoiceSal.InvoiceDate,  " & _
 "        dbo.Emp_employees.Emp_Name, Emp_employees_1.Emp_Name, dbo.TB_Type_Pay.Name " & _
 "        HAVING(SUM(dbo.MovmentStatement.Cridit) <> 0) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "350"
        'GridView1.Columns(2).Width = "150"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "أسم الحساب"
        GridView1.Columns(2).Caption = "قيمة التحصيل"
        GridView1.Columns(3).Caption = "تاريخ التحصيل"
        GridView1.Columns(4).Caption = "نوع الدفعة"
        GridView1.Columns(5).Caption = "طريقة الدفع"
        GridView1.Columns(6).Caption = "رقم الفاتورة"
        GridView1.Columns(7).Caption = "تاريخ الفاتورة"
        GridView1.Columns(8).Caption = "مندوب البيع"
        GridView1.Columns(9).Caption = "مندوب التحصيل"
        GridView1.Columns(10).Caption = "مدة التجاوز"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




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

        sql2 = "SELECT        RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAccount, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.TB_Detalis_InvoiceSal.No_Item, " & _
            "                         dbo.BD_ITEM.Name, dbo.BD_Unit.Name AS Unit, dbo.TB_Detalis_InvoiceSal.Quntity, dbo.TB_Detalis_InvoiceSal.Price_Item, dbo.TB_Detalis_InvoiceSal.Total_Item AS TotalInvoice " & _
            " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
            "                         dbo.TB_Header_InvoiceSal ON dbo.ST_CHARTOFACCOUNT.Account_No = dbo.TB_Header_InvoiceSal.Customer_No AND  " & _
            "                         dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code INNER JOIN " & _
            "                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ser_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo AND  " & _
            "                         dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Detalis_InvoiceSal.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoiceSal.Code_Unit  = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_Unit.Compny_Code " & _
            " WHERE        (dbo.TB_Header_InvoiceSal.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) and  (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME,'" & vardate2 & "', 102)) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "200"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "100"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "150"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "120"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "أسم العميل"
        GridView1.Columns(1).Caption = "رقم الفاتورة"
        GridView1.Columns(2).Caption = "تاريخ الفاتورة"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "الكمية"
        GridView1.Columns(7).Caption = "السعر"
        GridView1.Columns(8).Caption = "الاجمالى"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub Custome_Date()

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


        sql2 = "SELECT        Ser_InvoiceNo, InvoiceDate, Customer_Name, TotalInvoice, totalall_invoice, countt, DateEsthkak, value_cash,'0' as return_value, valueThwel, valueCheck, Receipt_Date, DateDiff, rem, esh3arDis, remes3ar, esh3ar2, " &
         "  SalseColected, Salse_Sal " &
         "   FROM dbo.vw_Date_Customer " &
         " WHERE        (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "قيمة قبل الضريبة"
        GridView1.Columns(4).Caption = "القيمة بعد الضريبة"
        GridView1.Columns(5).Caption = "الائتمان"
        GridView1.Columns(6).Caption = "تاريخ الاستحقاق"
        GridView1.Columns(7).Caption = "النقدى"
        GridView1.Columns(8).Caption = "المرتجع"
        GridView1.Columns(9).Caption = "التحويل البنكى"
        GridView1.Columns(10).Caption = "الشيك"
        GridView1.Columns(11).Caption = "تاريخ التحصيل"
        GridView1.Columns(12).Caption = "مدة التجاوز"
        GridView1.Columns(13).Caption = "اجمالى المتبقى"
        GridView1.Columns(14).Caption = "المتبقى مبالغ"
        GridView1.Columns(15).Caption = "اشعار خصم"
        GridView1.Columns(16).Caption = "اشعارات متبقية"
        GridView1.Columns(17).Caption = "مندوب التحصيل"
        GridView1.Columns(18).Caption = "مندوب البيع"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        GridView1.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(13).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(14).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


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

        sql2 = " select * from Vw_AllAznSarfReport where Compny_Code  = '" & VarCodeCompny & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()
        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "مجموعة الصنف"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "الكمية"
        GridView1.Columns(7).Caption = "المخزن"
        GridView1.Columns(8).Caption = "رقم التوريد"
        GridView1.Columns(9).Caption = "أسم العميل"

        GridView1.Columns(10).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






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
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "200"
        'GridView1.Columns(3).Width = "200"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()
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
        vardisplayReport = 0
        LabelX1.Text = "مديونية العملاء خلال فترة"
        Find_CustomerFill()
        GridView1.BestFitColumns()
    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub

    Private Sub Frm_ReportCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
    End Sub

    Private Sub Cmd_TotalInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_TotalInvoice.Click
        'Cmd_CustomerFill.FontBold = False
        'Cmd_TotalInvoice.FontBold = True
        vardisplayReport = 9
        LabelX1.Text = "تقرير إجمالى الفواتير للعملاء - خلال فترة"
        All_invoice()
        GridView1.BestFitColumns()
    End Sub

    Private Sub Cmd_SalCustomer_Click(sender As Object, e As EventArgs) Handles Cmd_SalCustomer.Click
        'Cmd_CustomerFill.FontBold = False
        'Cmd_SalCustomer.FontBold = True
        LabelX1.Text = "تقرير يومية المبيعات للعملاء خلال فترة"
        vardisplayReport = 5
        Find_SalCustomer()
        GridView1.BestFitColumns()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)
       
    End Sub

    
    Private Sub Cmd_Crdit_Click(sender As Object, e As EventArgs) Handles Cmd_Crdit.Click
        'Cmd_CustomerFill.FontBold = False
        'Cmd_Crdit.FontBold = True
        vardisplayReport = 3
        LabelX1.Text = "تقرير متحصلات العملاء خلال فترة"
        Find_SumCrdit()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
      


    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs) Handles ButtonItem9.Click
        vardisplayReport = 6
        LabelX1.Text = "تقرير بأذون أستلام البضاعة للعملاء"
        vardisplayReport = 6
        Find_EstlamCustomer()
        GridView1.BestFitColumns()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        LabelX1.Text = "تقرير أعمار المديونية للعملاء - خلال فترة"
        vardisplayReport = 7
        Custome_Date()
        GridView1.BestFitColumns()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        vardisplayReport = 1
        LabelX1.Text = "تقرير يومية المبيعات للعملاء - بدون الاصناف خلال فترة"
        Find_TotalInvoice()
        GridView1.BestFitColumns()
    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Dim var5, var6, var7, var8, var9, var10, var15, var11, var12, var13, var14, var16, var17, var18 As String

            var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
            var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))


            If vardisplayReport = 0 Then ' المديونية
                sql = "insert into TB_TempReport1  (Account_Main,Account_No,Account_Name" & _
                " ,Debit,Crdit,Balance,Compny_Code) " & _
                " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "','" & VarCodeCompny & "'  ) "
                Cnn.Execute(sql)
            End If


            If vardisplayReport = 1 Then 'الفواتير المجمعة
                sql = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name" & _
                " ,TotalInvoice,Txt_invoice,Tax_Value,TotalAll_Invoice,Compny_Code,No_regCustomer,NameEmp,Region) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & VarCodeCompny & "',N'" & var8 & "','" & var9 & "',N'" & var10 & "'  ) "
                Cnn.Execute(sql)
            End If


            If vardisplayReport = 5 Then 'مبيعات العملاء من الاصناف
                sql = "insert into TB_TempReport1  (Customer_Name,Invoice_No,Date_Invoice" & _
                " ,code_Item,NameItem,Unit,Qty,Price,TotalItem,Compny_Code) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "','" & VarCodeCompny & "'  ) "
                Cnn.Execute(sql)
            End If


            If vardisplayReport = 3 Then 'متحصلات العملاء  

                var5 = ""
                var6 = ""
                var7 = ""
                var8 = ""
                var9 = ""
                var15 = ""

                var5 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))))
                var6 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))))
                var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
                var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
                var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
                var15 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))


                sql = "insert into TB_TempReport1  (Account_No,Account_Name,Balance,Date_Collect,TypeMove,NameDeprt,Invoice_No,Date_Invoice,NameEmp,NameDir,DateAtt,Compny_Code ) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & var5 & "',N'" & var6 & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "',N'" & var15 & "' ,'" & VarCodeCompny & "' ) "
                Cnn.Execute(sql)
            End If


            If vardisplayReport = 7 Then 'العملاء تعدت حد الائتمان
                'sql = "insert into TB_TempReport1  (Account_No,Customer_Name,Balance,LimitedCustomer" & _
                '" ,Phon1_Customer,Phon2_Customer,Email_Customer,Region_Customer,Compny_Code) " & _
                '" values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                '" ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "','" & VarCodeCompny & "'  ) "
                'Cnn.Execute(sql)

                var5 = ""
                var6 = ""
                var7 = ""
                var8 = ""
                var9 = ""
                var10 = ""
                var11 = ""
                var12 = ""
                var13 = ""
                var14 = ""
                var15 = ""
                var16 = ""
                var17 = ""
                var18 = ""

                var5 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))))
                var6 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))))
                var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
                var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
                var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
                var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))
                var11 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))))
                var12 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))))
                var13 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))))
                var14 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(14))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(14))))
                var15 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(15))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(15))))
                var16 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(16))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(16))))
                var17 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(17))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(17))))
                var18 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(18))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(18))))


                sql = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name,TotalInvoice,TotalAll_Invoice,dayatt,DateAtt,Value_cash,Crdit,Debit,Balance,Date_Collect,TimeOut,TotalItem,OpenDeipt,OprnCridit,NameEmp,NameDir ) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & var5 & "',N'" & var6 & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "',N'" & var10 & "' ,N'" & var11 & "',N'" & var12 & "',N'" & var13 & "',N'" & var14 & "',N'" & var16 & "',N'" & var17 & "',N'" & var18 & "' ) "
                Cnn.Execute(sql)






            End If

            If vardisplayReport = 6 Then 'تقرير اذون الاستلام


                sql = "insert into TB_TempReport1  (No_azn,Date_Invoice,Group_Item,code_Item,NameItem" & _
                " ,Unit,Qty,NameStores,NO_Order,Customer_Name) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "'  ) "
                Cnn.Execute(sql)
            End If



            If vardisplayReport = 9 Then 'تقرير اجمالى الفواتير

                sql2 = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name" & _
        " ,code_Item,NameItem,Unit,Qty,Price,TotalInvoice,Txt_invoice,TotalAll_Invoice) " & _
        " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) & "'    ) "

                rs2 = Cnn.Execute(sql2)

            End If



        Next rowHandle
        Frm_Report_all.Show()
        'Rpt_Customer3.Show()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If vardisplayReport = 0 Then Find_CustomerFill() 'المديونية
        If vardisplayReport = 1 Then Find_TotalInvoice() 'مبيعات العملاء بدون اصناف
        'If vardisplayReport = 2 Then Find_CustomerFill()
        If vardisplayReport = 3 Then Find_SumCrdit() 'التحصيلات العملاء
        'If vardisplayReport = 4 Then Find_SumCrdit()
        If vardisplayReport = 5 Then Find_SalCustomer() 'مبيعات العملاء من الاصناف
        If vardisplayReport = 6 Then Find_EstlamCustomer() 'اذون استلام البضاعة
        If vardisplayReport = 9 Then All_invoice() 'اجمالى الفواتير
        If vardisplayReport = 7 Then Custome_Date()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick

      
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click

    End Sub
End Class