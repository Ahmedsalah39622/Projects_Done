Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

Public Class Frm_ReportCustomer2
    Dim oldDate As Date
    Dim oldDay As Integer
  
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

        sql2 = " select * from Vw_AllAznSarfReport where Compny_Code  = '" & VarCodeCompny & "' and CustomeName like '%" & txt_NameCustomer.Text & "%' and NameItem like '%" & txt_nameitem.Text & "%' "

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




    Sub Find_PriceListActive()

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

        sql2 = " select * from vw_PriceList_Activation_Working where  (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND Compny_Code  = '" & VarCodeCompny & "' and Customer_Name like '%" & txt_NameCustomer.Text & "%'  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم العرض"
        GridView1.Columns(1).Caption = "تاريخ العرض"
        GridView1.Columns(2).Caption = "اسم العميل"
        GridView1.Columns(3).Caption = "حالة العرض"
        GridView1.Columns(4).Caption = "قيمة العرض"
        GridView1.Columns(5).Caption = "نوع العرض"
        GridView1.Columns(6).Caption = "نوع الضريبة"
        GridView1.Columns(7).Caption = "مستخدم / غير مستخدم"
      

        GridView1.Columns(8).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Sub Find_RequestOrder() 'أوامر التوريد المنفذة والغير منفذة

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

        sql2 = " select * from Vw_Order_Wating where  (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND Compny_Code  = '" & VarCodeCompny & "' and Name like '%" & txt_NameCustomer.Text & "%'  and Emp_Name like '%" & txt_NameSalse.Text & "%' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم امر التوريد"
        GridView1.Columns(1).Caption = "تاريخ امر التوريد"
        GridView1.Columns(2).Caption = "اسم العميل"
        GridView1.Columns(3).Caption = "اسم المندوب"
        GridView1.Columns(4).Caption = "قيمة امر التوريد"
        GridView1.Columns(5).Caption = "رقم عرض السعر"
        GridView1.Columns(6).Caption = "حالة امر التوريد"
        GridView1.Columns(7).Caption = "نوع الضريبة"


        GridView1.Columns(8).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub
    Sub Custome_Date_Amar()

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
         " WHERE        (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Compny_Code = '" & VarCodeCompny & "') and Customer_Name like '%" & txt_NameCustomer.Text & "%' and Salse_Sal like '%" & txt_NameSalse.Text & "%' "

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

    Private Sub gridView1_RowCellStyle(ByVal sender As Object, _
   ByVal e As RowCellStyleEventArgs)
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle <> view.FocusedRowHandle And _
        '    ((e.RowHandle Mod 2 = 0 And e.Column.VisibleIndex Mod 2 = 1) Or _
        '    (e.Column.VisibleIndex Mod 2 = 0 And e.RowHandle Mod 2 = 1)) Then _
        '        e.Appearance.BackColor = Color.SkyBlue

        'If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = 3 Then
        '    e.Appearance.BackColor = Color.Red
        'End If


        'Dim intRow, strQuantity As Integer

        'e.Appearance.BackColor = Color.Gray



        'For x As Integer = 0 To GridView1.RowCount


        '    Dim quantity As Single
        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        '    If vardisplayReport = 0 Then 'المديونية
        '        quantity = GridView1.GetRowCellValue(x, GridView1.Columns(5))
        '        If quantity > 2000 Then
        '            If e.Column.AbsoluteIndex = 5 AndAlso e.RowHandle = x Then
        '                e.Appearance.BackColor = Color.Green
        '            End If
        '        Else
        '        End If
        '    End If

        'If vardisplayReport = 1 Then 'المديونية
        '    quantity = GridView1.GetRowCellValue(x, GridView1.Columns(6))
        '    If quantity > 2000 Then
        '        If e.Column.AbsoluteIndex = 6 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.Yellow
        '        End If
        '    Else
        '    End If
        'End If

        'Next x



        'e.HighPriority = True   'override any other formatting  
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
 "                         (dbo.FindCustomer.Compny_Code = '" & VarCodeCompny & "') AND (dbo.MovmentStatement.TypeBill = 3) " & _
 " GROUP BY dbo.FindCustomer.code, dbo.FindCustomer.Name, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Type_Invoice, dbo.TB_Receipt.Invoice_No, dbo.TB_Header_InvoiceSal.InvoiceDate,  " & _
 "        dbo.Emp_employees.Emp_Name, Emp_employees_1.Emp_Name, dbo.TB_Type_Pay.Name " & _
 "        HAVING(SUM(dbo.MovmentStatement.Cridit) <> 0)  AND (dbo.FindCustomer.Name LIKE '%" & txt_NameCustomer.Text & "%')  "



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


    Sub Find_rentedInvoice()

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


        sql2 = " select Ext_InvoiceNo,InvoiceDate,No_Item,name,Unit,Quntity,Price_Item,Total_Item,NameStores,NameCustomer,Emp_Name from Rpt_RentedInvoice where Compny_Code = '" & VarCodeCompny & "' and (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) and (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and NameCustomer like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%' "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
  


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "السعر"
        GridView1.Columns(7).Caption = "الاجمالى"
        GridView1.Columns(8).Caption = "المخزن"
        GridView1.Columns(9).Caption = "العميل"
        GridView1.Columns(10).Caption = "المندوب"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




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
  " dbo.Emp_employees.Emp_Name, dbo.BD_REGION.Name having dbo.ST_CHARTOFACCOUNT.AccountName like '%" & txt_NameCustomer.Text & "%' and  dbo.Emp_employees.Emp_Name like '%" & txt_NameSalse.Text & "%' "




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
        GridView1.Columns(3).Caption = "إجمالى الفاتورة"
        GridView1.Columns(4).Caption = "نسبة الضريبة"
        GridView1.Columns(5).Caption = "قيمة الضريبة"
        GridView1.Columns(6).Caption = "صافى الفاتورة"
        GridView1.Columns(7).Caption = "رقم التسجيل الضريبى"
        GridView1.Columns(8).Caption = "مندوب البيع"
        GridView1.Columns(9).Caption = "المنطقة"
        GridView1.Columns(4).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



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


        sql2 = "select * from vw_AllCustomer2  where Compny_Code = '" & VarCodeCompny & "' and Name like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
   

        GridView1.Columns(0).Caption = "رقم الحساب  "
        GridView1.Columns(1).Caption = "أسم العميل"
        GridView1.Columns(2).Caption = "الرصيد السابق"
        GridView1.Columns(3).Caption = "مدين"
        GridView1.Columns(4).Caption = "دائن"
        GridView1.Columns(5).Caption = "رصيد"
        GridView1.Columns(6).Caption = "المنطقة"
        GridView1.Columns(7).Caption = "اخر سداد"
        GridView1.Columns(8).Caption = "تاريخ اخر سداد"
        GridView1.Columns(9).Caption = "المندوب"
        GridView1.Columns(1).Caption = "التصنيف"

        GridView1.Columns(10).Visible = False

        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


       




        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub Cerate_FillCustomer()
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



        '=============================================openbalnce
        sql = " DROP VIEW dbo.vw_OpenBalance"
        rs = Cnn.Execute(sql)
        '====================================================

        sql2 = "  CREATE VIEW vw_OpenBalance AS   SELECT dbo.MovmentStatement.AccountNo, ROUND(SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit), 2) AS OpenBalance " & _
            " FROM     dbo.MovmentStatement INNER JOIN " & _
            "                  dbo.FindCustomer ON dbo.MovmentStatement.AccountNo = dbo.FindCustomer.code " & _
            " WHERE  (dbo.MovmentStatement.DateMoveM < CONVERT(DATETIME, '" & vardate & "', 102)) " & _
            " GROUP BY dbo.MovmentStatement.AccountNo "
        rs = Cnn.Execute(sql2)

        '=============================================
        sql = " DROP VIEW dbo.vw_AllCustomer1"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = " CREATE VIEW vw_AllCustomer1 AS   SELECT dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, iif(dbo.Vw_OpenBalance.OpenBalance IS NULL, 0, dbo.Vw_OpenBalance.OpenBalance) AS OpenBalance, SUM(dbo.MovmentStatement.Debit) " & _
   "                  AS SumDebit, SUM(dbo.MovmentStatement.Cridit) AS SumCridit, ROUND(ROUND(iif(dbo.Vw_OpenBalance.OpenBalance IS NULL, 0, dbo.Vw_OpenBalance.OpenBalance), 2)  " & _
   "                 + ROUND(SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit), 2), 2) AS Resalt, dbo.BD_REGION.Name AS Region, dbo.vw_lastpaid.sumReceipt_Value, dbo.vw_lastpaid.LastDate,  " & _
   "        dbo.Emp_employees.Emp_Name,MovmentStatement.Compny_Code " & _
   " FROM     dbo.MovmentStatement INNER JOIN " & _
   "                  dbo.FindCustomer ON dbo.MovmentStatement.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.FindCustomer.code INNER JOIN " & _
   "                  dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
   "                  dbo.St_CustomerData ON dbo.FindCustomer.code = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
   "                  dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code INNER JOIN " & _
   "                  dbo.Emp_employees ON dbo.St_CustomerData.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
   "                  dbo.vw_OpenBalance ON dbo.MovmentStatement.AccountNo = dbo.vw_OpenBalance.AccountNo LEFT OUTER JOIN " & _
   "                  dbo.vw_lastpaid ON dbo.MovmentStatement.AccountNo = dbo.vw_lastpaid.accno " & _
   " WHERE  (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
   " GROUP BY dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, dbo.BD_REGION.Name, dbo.vw_lastpaid.sumReceipt_Value, dbo.vw_lastpaid.LastDate, dbo.vw_OpenBalance.OpenBalance,  " & _
   "        dbo.Emp_employees.Emp_Name,MovmentStatement.Compny_Code "

        rs = Cnn.Execute(sql2)


    End Sub


    Sub Cerate_InvoiceAll()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_AllInvoice_Report"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = "  CREATE VIEW vw_AllInvoice_Report AS  SELECT        dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name AS NameItem, dbo.Vw_DetilsInvoice.Unit,  " & _
               "                         dbo.Vw_DetilsInvoice.Quntity, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item,  " & _
               "                         dbo.Vw_DetilsInvoice.Total_Item * dbo.TB_Header_InvoiceSal.tax_n / 100 AS Tax, dbo.Vw_DetilsInvoice.Total_Item + dbo.Vw_DetilsInvoice.Total_Item * dbo.TB_Header_InvoiceSal.tax_n / 100 AS TotalAll " & _
               " FROM            dbo.Vw_DetilsInvoice INNER JOIN " & _
               "                         dbo.TB_Header_InvoiceSal ON dbo.Vw_DetilsInvoice.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.Vw_DetilsInvoice.Ext_InvoiceNo = dbo.TB_Header_InvoiceSal.Ext_InvoiceNo INNER JOIN " & _
               "                         dbo.FindCustomer ON dbo.TB_Header_InvoiceSal.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.FindCustomer.Compny_Code " & _
               " WHERE        (dbo.Vw_DetilsInvoice.Compny_Code = '" & VarCodeCompny & "') AND  (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) AND (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
               " GROUP BY dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name, dbo.Vw_DetilsInvoice.Quntity,  " & _
               "        dbo.Vw_DetilsInvoice.Unit, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.TB_Header_InvoiceSal.tax_n "

        rs = Cnn.Execute(sql2)


    End Sub


    Sub Cerate_InvoiceAll_Tax()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_AllInvoice_Report2"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = "  CREATE VIEW vw_AllInvoice_Report2 AS  SELECT        dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAccount, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
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



        rs = Cnn.Execute(sql2)


    End Sub
    Sub run_report()
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim vardate As String
        Dim vardate2, vardatetest1, vardatetest2 As String
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



        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"
        If vardisplayReport = 0 Then
            Dim report As New Customer1   'مديونية العملاء
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel1.Text = txt_NameCustomer.Text
            'report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%' and [Emp_Name] Like '%" & txt_NameSalse.Text & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport = 1 Then
            'Cerate_InvoiceAll()
            Dim report As New Report_RentedInvoice ' اجمالى الفواتير
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel5.Text = txt_NameCustomer.Text
            report.XrLabel32.Text = txt_nameitem.Text
            report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%' and [NameItem] Like '%" & Trim(txt_nameitem.Text) & "%' and [InvoiceDate] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport = 2 Then
            Cerate_InvoiceAll_Tax()
            Dim report As New Rpt_TotalInvoice
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel10.Text = txt_NameCustomer.Text

            report.FilterString = "[NameAccount] Like '%" & txt_NameCustomer.Text & "%' and [Emp_Name] Like '%" & Trim(txt_NameSalse.Text) & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 3 Then
            Cerate_SumCridt()
            Dim report As New CustomerMthslat
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel10.Text = txt_NameCustomer.Text
            report.XrLabel29.Text = txt_NameSalse.Text
            report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%'   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 4 Then
            'Cerate_SumCridt()
            Dim report As New AmarDuon
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel10.Text = txt_NameCustomer.Text
            report.XrLabel29.Text = txt_NameSalse.Text
            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and salse_sal Like '%" & txt_NameSalse.Text & "%' and Compny_Code ='" & VarCodeCompny & "'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 6 Then
            Dim report As New Rpt_Azn_Estlam_Customer
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel10.Text = txt_NameCustomer.Text
            report.XrLabel29.Text = txt_nameitem.Text
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[CustomeName] Like '%" & txt_NameCustomer.Text & "%'  and NameItem Like '%" & txt_nameitem.Text & "%' and Compny_Code ='" & VarCodeCompny & "'  "


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 5 Then
            Dim report As New report_rented
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel5.Text = txt_NameCustomer.Text
            report.XrLabel32.Text = txt_NameSalse.Text
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[NameCustomer] Like '%" & txt_NameCustomer.Text & "%'  and Emp_Name Like '%" & txt_nameitem.Text & "%' and Compny_Code ='" & VarCodeCompny & "'  "


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport = 8 Then
            Dim report As New Colected_Salse_sal ' مبيعات المندوبين من الاصناف بالمناطق
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text
            'report.XrLabel11.Text = txt_NameSalse.Text
            report.FilterString = "[ee] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' and [GM] Like '%" & Com_GM.Text & "%' and [Name] Like '%" & txt_nameitem.Text & "%' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 9 Then
            Dim report As New PriceListReport ' تقرير متابعة عروض الاسعار المنفذة
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text
            'report.XrLabel11.Text = txt_NameSalse.Text
            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and [InvoiceDate] Between(" & vardatetest1 & ", " & vardatetest2 & ")   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If






        If vardisplayReport = 11 Then   'اذون صرف بفاتورة وبدون فاتورة
            Dim report As New AznSarfReport
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")


            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value

            If OP1.Checked = True Then report.labStatus.Text = "بدون فاتورة"
            If OP2.Checked = True Then report.labStatus.Text = " فاتورة"
            If OP3.Checked = True Then report.labStatus.Text = " الكل"

            vardatetest1 = "#" + vardate + "#"
            vardatetest2 = "#" + vardate2 + "#"

            If OP1.Checked = True Then report.FilterString = "[No_Invoice] = '" & 0 & "'   and [Compny_Code] = '" & VarCodeCompny & "'  and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") and [NameCustomer] like '%" & txt_NameCustomer.Text & "%' "
            If OP2.Checked = True Then report.FilterString = "[No_Invoice] <> '" & 0 & "'   and [Compny_Code] = '" & VarCodeCompny & "' and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") and [NameCustomer] like '%" & txt_NameCustomer.Text & "%' "
            If OP3.Checked = True Then report.FilterString = " [Compny_Code] = '" & VarCodeCompny & "' and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") and [NameCustomer] like '%" & txt_NameCustomer.Text & "%' "

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport = 12 Then
            Dim report As New OrderWaiting ' أوامر التوريد المنفذة والغير منفذة
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel1.Text = txt_NameCustomer.Text
            'report.XrLabel11.Text = txt_NameSalse.Text
            report.FilterString = "[name] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' and [Compny_Code] = '" & VarCodeCompny & "' and [Order_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ")   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If





        If vardisplayReport = 14 Then 'تقرير مبيعات الفواتير  بالمناطق بدون اصناف
            Dim report As New SalesSal
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text

            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and Emp_Name Like '%" & txt_NameSalse.Text & "%' and Compny_Code ='" & VarCodeCompny & "'   "


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If




        If vardisplayReport = 16 Then
            Dim report As New Daily_production2
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel11.Text = txt_NameCustomer.Text
            report.XrLabel10.Text = txt_NameSalse.Text
            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' and Compny_Code ='" & VarCodeCompny & "' and [Receipt_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 17 Then
            Dim report As New CustomerActiveReport
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel1.Text = txt_NameCustomer.Text

            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 18 Then
            Dim report As New InvoicePaid
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel1.Text = txt_NameCustomer.Text

            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 19 Then
            Dim report As New FollowUpOrders
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text

            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%'  and Emp_Name Like '%" & txt_NameSalse.Text & "%' and Compny_Code ='" & VarCodeCompny & "' and [Date_Invoice] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If



        If vardisplayReport = 20 Then
            Dim report As New InvoicePaid
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel1.Text = txt_NameCustomer.Text

            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and Emp_Name Like '%" & txt_NameSalse.Text & "%'  and [InvoiceDate] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub

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
               "  " & _
               " GROUP BY dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name, dbo.Vw_DetilsInvoice.Quntity,  " & _
               "        dbo.Vw_DetilsInvoice.Unit, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.TB_Header_InvoiceSal.tax_n  having (dbo.Vw_DetilsInvoice.NAME LIKE '%" & txt_nameitem.Text & "%') AND (dbo.FindCustomer.Name LIKE '%" & txt_NameCustomer.Text & "%') "



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







    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Sub Cerate_StatmentAcc()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_StatmentAcc"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_StatmentAcc AS   SELECT        dbo.vw_over.No_Sand, dbo.vw_over.DateMoveM, dbo.vw_over.Discription, ROUND(dbo.vw_over.Debit_EGP, 2) AS DE, ROUND(dbo.vw_over.Cridit_EGP, 2) AS Cr, ROUND(dbo.vw_over.Balance_Cur_EGP, 2) " & _
                "                         AS R, dbo.TB_TypeBill.Type_Bill, dbo.TB_TypeBill.Code " & _
                " FROM            dbo.vw_over INNER JOIN " & _
                "                         dbo.BD_Currency ON dbo.vw_over.CruunceyNo = dbo.BD_Currency.Code AND dbo.vw_over.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
                "                         dbo.Vw_CostcenterAll ON dbo.vw_over.CostCenterNo = dbo.Vw_CostcenterAll.Code AND dbo.vw_over.Compny_Code = dbo.Vw_CostcenterAll.Compny_Code LEFT OUTER JOIN " & _
                "                         dbo.TB_TypeBill ON dbo.vw_over.TypeBill = dbo.TB_TypeBill.Code " & _
                " WHERE        (dbo.vw_over.Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_over.AccountNo ='" & varcodecustomer & "') AND (dbo.vw_over.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
                "                         (dbo.vw_over.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        rs = Cnn.Execute(sql2)


    End Sub


    Sub Cerate_SumCridt()
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
        '=============================================
        sql = " DROP VIEW dbo.Vw_SumCrdit"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = " CREATE VIEW Vw_SumCrdit AS  SELECT        dbo.FindCustomer.code, dbo.FindCustomer.Name, ROUND(SUM(dbo.MovmentStatement.Cridit), 2) AS SumCridit, dbo.TB_Receipt.Receipt_Date, iif(dbo.TB_Receipt.Type_Invoice =0 ,'دفعة مقدمة','فاتورة') as type,  " & _
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
"                         (dbo.FindCustomer.Compny_Code = '" & VarCodeCompny & "') AND (dbo.MovmentStatement.TypeBill = 3) " & _
" GROUP BY dbo.FindCustomer.code, dbo.FindCustomer.Name, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Type_Invoice, dbo.TB_Receipt.Invoice_No, dbo.TB_Header_InvoiceSal.InvoiceDate,  " & _
"        dbo.Emp_employees.Emp_Name, Emp_employees_1.Emp_Name, dbo.TB_Type_Pay.Name " & _
"        HAVING(SUM(dbo.MovmentStatement.Cridit) <> 0) "


        rs = Cnn.Execute(sql2)


    End Sub



    Private Sub GridView1_RowCellStyle1(sender As Object, e As RowCellStyleEventArgs)
        For x As Integer = 0 To GridView1.RowCount


            'Dim quantity As Single
            Dim ststus_type As String
            'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            'If vardisplayReport = 0 Then 'المديونية
            '    quantity = GridView1.GetRowCellValue(x, GridView1.Columns(5))
            '    If quantity > 2000 Then
            '        If e.Column.AbsoluteIndex = 5 AndAlso e.RowHandle = x Then
            '            e.Appearance.BackColor = Color.SkyBlue
            '        End If
            '    Else
            '    End If
            'End If

            If vardisplayReport = 3 Then 'المتحصلات
                ststus_type = GridView1.GetRowCellValue(x, GridView1.Columns(5))
                If ststus_type = "نقدى" Then
                    If e.Column.AbsoluteIndex = 5 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Yellow

                    End If

                ElseIf ststus_type = "شيك" Then
                    If e.Column.AbsoluteIndex = 5 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.LimeGreen
                    End If
                Else
                End If
            End If

        Next x
    End Sub




    Private Sub GridControl1_DoubleClick2(sender As Object, e As EventArgs)
        If vardisplayReport = 9 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If


        If vardisplayReport = 1 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If


        If vardisplayReport = 5 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If



        If vardisplayReport = 0 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Frm_AccountStatement2.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_AccountStatement2.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))

            Frm_AccountStatement2.MdiParent = Mainmune
            Frm_AccountStatement2.FindBalance()
            Frm_AccountStatement2.find_data()

            Frm_AccountStatement2.count_colume()
            Frm_AccountStatement2.count_colume2()
            Frm_AccountStatement2.final_sum()
            Frm_AccountStatement2.Show()


        End If
    End Sub

    Private Sub GridControl1_Click_4(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick3(sender As Object, e As EventArgs)
        If vardisplayReport = 0 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Frm_AccountStatement2.txt_date1.Value = txt_date.Value
            Frm_AccountStatement2.txt_date2.Value = txt_date2.Value
            Frm_AccountStatement2.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_AccountStatement2.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))

            Frm_AccountStatement2.MdiParent = Mainmune
            Frm_AccountStatement2.FindBalance()
            Frm_AccountStatement2.find_data()
            Frm_AccountStatement2.count_colume()
            Frm_AccountStatement2.count_colume2()
            Frm_AccountStatement2.final_sum()
            Frm_AccountStatement2.Show()


        End If


        If vardisplayReport = 9 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If

        If vardisplayReport = 1 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If


        If vardisplayReport = 3 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Frm_AccountStatement.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_AccountStatement.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))

            Frm_AccountStatement.MdiParent = Mainmune
            Frm_AccountStatement.find_Acc2()
            Frm_AccountStatement.Show()


        End If
    End Sub

    Private Sub txt_NameCustomer_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameCustomer.ButtonClick
        varcode_form = 2500
        VarOpenlookup2 = 2500
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_NameCustomer_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_NameCustomer.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txt_NameCustomer.Text = ""
        If vardisplayReport = 0 Then Find_CustomerFill()
        If vardisplayReport = 9 Then All_invoice()
        If vardisplayReport = 7 Then Custome_Date_Amar()
        If vardisplayReport = 1 Then Find_TotalInvoice()
        If vardisplayReport = 3 Then Find_SumCrdit()
        If vardisplayReport = 6 Then Find_EstlamCustomer()
        If vardisplayReport = 8 Then Find_rentedInvoice()

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        '===========================================
        sql2 = "select * from FindCustomer where Name ='" & txt_NameCustomer.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then varcodecustomer = rs3("code").Value
        '============================================================
        Cerate_StatmentAcc()
        Dim report As New CartItemRpt
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        report.X_Date1.Text = txt_date.Value
        report.X_Date2.Text = txt_date2.Value
        report.XrLabel29.Text = txt_NameCustomer.Text
        'report.XrLabel11.Text = txt_nameitem.Text
        report.FilterString = "[AccountNo] = '" & varcodecustomer & "'  and [Compny_Code] = '" & VarCodeCompny & "'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub

    Private Sub txt_NameSalse_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameSalse.ButtonClick
        VarOpenlookup3 = 25250
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

   

    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        txt_NameSalse.Text = ""
        Find_TotalInvoice()
        Custome_Date_Amar()
        All_invoice()
        Find_rentedInvoice()

        run_report()

    End Sub

    Private Sub SimpleButton8_Click_1(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        Action_RetraveData()
    End Sub
    Sub Action_RetraveData()
        OP1.Visible = False
        OP2.Visible = False
        OP3.Visible = False
        If vardisplayReport = 0 Then

            Cerate_FillCustomer()
            Find_CustomerFill()
            run_report()
            TabPane1.SelectedPageIndex = 0
            GridView1.BestFitColumns()
        End If

        If vardisplayReport = 1 Then


            All_invoice()
            'Cerate_InvoiceAll()
            run_report()

            TabPane1.SelectedPageIndex = 0
            GridView1.BestFitColumns()
        End If



        If vardisplayReport = 2 Then
            run_report()
            Find_TotalInvoice()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If

        If vardisplayReport = 3 Then

            run_report()
            Find_SumCrdit()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 4 Then

            run_report()
            Custome_Date_Amar()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If

        If vardisplayReport = 5 Then
            Find_rentedInvoice()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 6 Then
            Find_EstlamCustomer()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If



        If vardisplayReport = 8 Then
            All_Salase_Invoice()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 9 Then
            Find_PriceListActive()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If



        If vardisplayReport = 11 Then
            OP1.Visible = True
            OP2.Visible = True
            OP3.Visible = True
            Search_Sarf_invoice()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 12 Then
           
            Find_RequestOrder()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If

        If vardisplayReport = 14 Then
            Find_ReportNetSalse()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If



        If vardisplayReport = 16 Then
            Colected_data()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If




        If vardisplayReport = 17 Then   'العملاء المتوقفين 
            'Find_rentedInvoice()
            Customer_Activity()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If



        If vardisplayReport = 18 Then   'الفواتير المسددة 
            'Find_rentedInvoice()
            'Customer_Activity()
            Paid_Invoice()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 16 Then
            Colected_data()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If




        If vardisplayReport = 19 Then   'متابعة الطلبات 
            'Find_rentedInvoice()
            Find_FllowUpOrder()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


        If vardisplayReport = 20 Then   'الفواتير المسددة 
            'Find_rentedInvoice()
            Paid_Invoice()
            run_report()
            GridView1.BestFitColumns()
            TabPane1.SelectedPageIndex = 0
        End If


    End Sub


    Sub Find_ReportNetSalse() 'مبيعات المناطق للمناديب

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

        sql2 = " select * from vw_ReportNetSalse where Compny_Code  = '" & VarCodeCompny & "' and Customer_Name like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "اسم العميل"
        GridView1.Columns(1).Caption = "المنطقة"
        GridView1.Columns(2).Caption = "اسم المندوب"
        GridView1.Columns(3).Caption = "قيمة المبيعات"
        GridView1.Columns(4).Caption = "قيمة المرتجع"
        GridView1.Columns(5).Caption = "صافى المبيعات"
        GridView1.Columns(6).Caption = "المحصل"
        GridView1.Columns(7).Caption = "المتبقى "
        GridView1.Columns(8).Caption = "نسبة التحصيل"
        GridView1.Columns(9).Visible = False



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Find_FllowUpOrder()

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


        sql2 = " select * from Vw_FllowUp_OrderCustomer where Compny_Code = '" & VarCodeCompny & "' and (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) and (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and Name like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%' "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "اسم العميل"
        GridView1.Columns(1).Caption = "رقم عرض السعر"
        GridView1.Columns(2).Caption = "تاريخ العرض"
        GridView1.Columns(3).Caption = "قيمة عرض السعر"
        GridView1.Columns(4).Caption = "رقم التوريد"
        GridView1.Columns(5).Caption = "رقم اذن الاستلام"
        GridView1.Columns(6).Caption = "تاريخ الاذن"
        GridView1.Columns(7).Caption = "قيمة الاذن"
        GridView1.Columns(8).Caption = "رقم الفاتورة"
        GridView1.Columns(9).Caption = "تاريخ الفاتورة"
        GridView1.Columns(10).Caption = "قيمة الفاتورة"
        GridView1.Columns(11).Caption = "اسم المندوب"

        GridView1.Columns(12).Visible = False
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub
   
    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_nameitem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 2555
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

  

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        Lab_NameReport.Text = NavBarItem1.Caption
        vardisplayReport = 0
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        Lab_NameReport.Text = NavBarItem2.Caption
        vardisplayReport = 1
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        Lab_NameReport.Text = NavBarItem3.Caption
        vardisplayReport = 2
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem4_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        Lab_NameReport.Text = NavBarItem4.Caption
        vardisplayReport = 3
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem5_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        Lab_NameReport.Text = NavBarItem5.Caption
        vardisplayReport = 4
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem6_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem6.LinkClicked
        Lab_NameReport.Text = NavBarItem6.Caption
        vardisplayReport = 5
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem7_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem7.LinkClicked
        Lab_NameReport.Text = NavBarItem7.Caption
        vardisplayReport = 6
        Action_RetraveData()
    End Sub

   

    Private Sub NavBarItem9_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem9.LinkClicked
        Lab_NameReport.Text = NavBarItem9.Caption
        vardisplayReport = 8
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem10_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem10.LinkClicked
        Lab_NameReport.Text = NavBarItem10.Caption
        vardisplayReport = 9
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem11_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem11.LinkClicked
        Lab_NameReport.Text = NavBarItem11.Caption
        vardisplayReport = 10
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem12_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem12.LinkClicked
        Lab_NameReport.Text = NavBarItem12.Caption
       

        vardisplayReport = 11
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem13_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem13.LinkClicked
        Lab_NameReport.Text = NavBarItem13.Caption
        vardisplayReport = 12
        Action_RetraveData()
    End Sub

   

    Private Sub NavBarItem15_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem15.LinkClicked
        Lab_NameReport.Text = NavBarItem15.Caption
        vardisplayReport = 14
        Action_RetraveData()
    End Sub

   

    Private Sub NavBarItem17_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem17.LinkClicked
        Lab_NameReport.Text = NavBarItem17.Caption
        vardisplayReport = 16
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem18_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem18.LinkClicked
        Lab_NameReport.Text = NavBarItem18.Caption
        vardisplayReport = 17
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem19_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem19.LinkClicked
        Lab_NameReport.Text = NavBarItem19.Caption
        vardisplayReport = 18
        Action_RetraveData()
    End Sub

    Private Sub NavBarItem20_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem20.LinkClicked
        Lab_NameReport.Text = NavBarItem20.Caption
        vardisplayReport = 19
        Action_RetraveData()
    End Sub

   

    Private Sub cmd_all_Click(sender As Object, e As EventArgs) Handles cmd_all.Click
        txt_nameitem.Text = ""
        All_invoice()
        Find_TotalInvoice()
        Find_EstlamCustomer()
        run_report()
    End Sub

    Private Sub Com_GM_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM.ButtonClick
        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 10101
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_GM_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM.EditValueChanged

    End Sub

    Private Sub Com_GM1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM1.ButtonClick
        vartable = "BD_GroupItem1"
        VarOpenlookup = 20201
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_GM1_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM1.EditValueChanged

    End Sub

    Private Sub cmd_All1_Click(sender As Object, e As EventArgs) Handles cmd_All1.Click
        Com_GM.Text = ""
    End Sub

    Private Sub cmd_All2_Click(sender As Object, e As EventArgs) Handles cmd_All2.Click
        Com_GM1.Text = ""
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub Cmd_Close_Click_1(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If vardisplayReport = 9 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If


        If vardisplayReport = 1 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If


        If vardisplayReport = 5 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        End If



        If vardisplayReport = 0 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Frm_AccountStatement2.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_AccountStatement2.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))

            Frm_AccountStatement2.MdiParent = Mainmune
            Frm_AccountStatement2.FindBalance()
            Frm_AccountStatement2.find_data()

            Frm_AccountStatement2.count_colume()
            Frm_AccountStatement2.count_colume2()
            Frm_AccountStatement2.final_sum()
            Frm_AccountStatement2.Show()


        End If
    End Sub

    
    Private Sub Frm_ReportCustomer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub Colected_data()

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



        sql2 = "   SELECT         Receipt_Date, Emp_Name,compny_name, Customer_Name, Name, valueThwel, valueCheck, Check_No,  iif( value_cash=0,Date_Asthkak,Date_Asthkak2) as dd, Bank_IN, value_cash, valueThwel+valueCheck+value_cash as Total_A " & _
   " FROM            dbo.vw_all_ColectedData " & _
   "        WHERE (Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_all_ColectedData.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_all_ColectedData.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
" and Customer_Name like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%'    ORDER BY Receipt_Date "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True



        GridView1.Columns(0).Caption = "تاريخ التحصيل"
        GridView1.Columns(1).Caption = "أسم المندوب "
        GridView1.Columns(2).Caption = "الشركة"
        GridView1.Columns(3).Caption = "العميل"
        GridView1.Columns(4).Caption = "المنطقة"
        GridView1.Columns(5).Caption = "تحويل بنكى"
        GridView1.Columns(6).Caption = "قيمة الشيك"
        GridView1.Columns(7).Caption = "رقم الشيك"
        GridView1.Columns(8).Caption = "تاريخ الاستحقاق"
        GridView1.Columns(9).Caption = "البنك"
        GridView1.Columns(10).Caption = "النقدية  بالخزينة"
        GridView1.Columns(11).Caption = "اجمالى  الكلى"

        GridView1.Columns(2).Visible = False

        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub Customer_Activity()

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



        sql2 = "   SELECT         * " & _
   " FROM            dbo.vw_Customer_Activity " & _
   "        WHERE  " & _
"  Customer_Name like '%" & txt_NameCustomer.Text & "%'  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True



        GridView1.Columns(0).Caption = "رقم العميل"
        GridView1.Columns(1).Caption = "اسم العميل"
        GridView1.Columns(2).Caption = "التليفون"
        GridView1.Columns(3).Caption = "تليفون 2"
        GridView1.Columns(4).Caption = "الاميل"
        GridView1.Columns(5).Caption = "المنطقة"
        GridView1.Columns(6).Caption = "ملاحظات"
        'GridView1.Columns(7).Caption = "نوع الدفع"


        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub Paid_Invoice()

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



        sql2 = "   SELECT         * " & _
   " FROM            dbo.view_invoice_Paid_Rested " & _
   "        WHERE  (dbo.view_invoice_Paid_Rested.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.view_invoice_Paid_Rested.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
" and Customer_Name like '%" & txt_NameCustomer.Text & "%' and Emp_Name like '%" & txt_NameSalse.Text & "%'  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True



        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة "
        GridView1.Columns(2).Caption = "العميل"
        GridView1.Columns(3).Caption = "قيمة الفاتورة"
        GridView1.Columns(4).Caption = "المحصل"
        GridView1.Columns(5).Caption = "المتبقى"
        GridView1.Columns(6).Caption = "المنطقة المندوب"
        GridView1.Columns(7).Caption = "نوع الدفع"


        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Search_Sarf_invoice() 'تقرير اذون الصرف بفاتورة ومن غير
        'On Error Resume Next

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


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If OP1.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' and dbo.Vw_All_AZN_Sarf3.No_Invoice = '0'  and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102))  and NameCustomer like '%" & txt_NameCustomer.Text & "%'  "

        End If

        If OP2.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' AND  dbo.Vw_All_AZN_Sarf3.No_Invoice <> '0'  and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and NameCustomer like '%" & txt_NameCustomer.Text & "%' "

        End If

        If OP3.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102))  and NameCustomer like '%" & txt_NameCustomer.Text & "%' "

        End If
        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        'GridView1.Columns(0).ColumnEdit = CheckBox.CheckBoxAccessibleObject
        GridView1.Columns(0).Caption = " اذن الصرف"
        GridView1.Columns(1).Caption = "رقم الطلبية"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "أسم العميل"
        GridView1.Columns(7).Caption = "أسم المندوب"

        GridView1.Columns(8).Caption = "سعر الوحدة"
        GridView1.Columns(9).Caption = "الاجمالى"
        GridView1.Columns(10).Caption = "المخزن"

        GridView1.Columns(11).Caption = "رقم الفاتورة"


        '================================================================
        GridView1.Columns(12).Visible = False 'Code Compny
        GridView1.Columns(13).Visible = False 'CodeCustomer
        GridView1.Columns(14).Visible = False 'Codesalse
        GridView1.Columns(15).Visible = False 'codeUnit
        GridView1.Columns(16).Visible = False 'Codestores
        GridView1.Columns(17).Visible = False 'code Cur
        GridView1.Columns(18).Visible = False 'ExtItem
        GridView1.Columns(19).Visible = False 'Rat
        GridView1.Columns(20).Visible = False
        GridView1.Columns(1).Visible = False
        GridView1.Columns(2).Visible = False


        '=================================================================
        'GridView1.Columns(20).Caption = "نوع الاذن"
        GridView1.Columns(20).Caption = "م"
        GridView1.Columns(21).Visible = False

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()
        'GridView1.Columns(16).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(16).AppearanceCell.ForeColor = Color.Red




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.BestFitColumns()



    End Sub
    Sub All_Salase_Invoice() '=مبيعات المناديب المناطق من الاصناف

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



        sql2 = "    SELECT        dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.Emp_employees.Emp_Name, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS ee,  " & _
    "                         dbo.TB_Detalis_InvoiceSal.No_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.TB_Detalis_InvoiceSal.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Detalis_InvoiceSal.Price_Item,  " & _
    "        dbo.TB_Detalis_InvoiceSal.Total_Item " & _
    " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
    "                         dbo.TB_Header_InvoiceSal ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND  " & _
    "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.TB_Header_InvoiceSal.Customer_No INNER JOIN " & _
    "                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo AND " & _
    "                         dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Item ON dbo.TB_Detalis_InvoiceSal.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
    "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
    "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoiceSal.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_Unit.Compny_Code " & _
    " WHERE        (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
    "                         (dbo.Emp_employees.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة "
        GridView1.Columns(2).Caption = "أسم المندوب"
        GridView1.Columns(3).Caption = "أسم العميل"
        GridView1.Columns(4).Caption = "رقم الصنف"
        GridView1.Columns(5).Caption = "أسم الصنف"
        GridView1.Columns(6).Caption = "مجموعة الصنف"
        GridView1.Columns(7).Caption = "الكمية المباعة"
        GridView1.Columns(8).Caption = "الوحدة"
        GridView1.Columns(9).Caption = "السعر"
        GridView1.Columns(10).Caption = "الاجمالى"


        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Private Sub NavBarItem22_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem22.LinkClicked
        FrmPavitTable.Show()
    End Sub

    Private Sub NavBarItem23_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem23.LinkClicked
        'FrmPavitTable_Salse.Close()
        FrmPavitTable_Salse.MdiParent = Mainmune
        FrmPavitTable_Salse.Show()
    End Sub

    Private Sub GridControl1_DragDrop(sender As Object, e As DragEventArgs) Handles GridControl1.DragDrop

    End Sub
End Class