Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Report_Salse
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim vardate As String
    Dim vardate2, vardatetest1, vardatetest2 As String
    Sub run_report()
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
        If vardisplayReport = 10 Then
            Dim report As New Daily_production2
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel11.Text = txt_NameCustomer.Text
            report.XrLabel10.Text = txt_NameSalse.Text
            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' and Compny_Code ='" & VarCodeCompny & "' and [Receipt_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport = 11 Then
            Dim report As New Colected_Salse3
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text
            report.XrLabel11.Text = txt_NameSalse.Text
            report.FilterString = "[Customer_Name] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If




        If vardisplayReport = 12 Then
            Dim report As New Colected_Salse_sal
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameCustomer.Text
            'report.XrLabel11.Text = txt_NameSalse.Text
            report.FilterString = "[ee] Like '%" & txt_NameCustomer.Text & "%'  and [Emp_Name] Like '%" & txt_NameSalse.Text & "%' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

    End Sub

   
    Sub Cerate_ComitionSalse()
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

        sql = " DROP VIEW dbo.vw_CommintionSalse"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_CommintionSalse AS  SELECT        dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
                "                         AS Total_Item2, ROUND(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) + SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * 14 / 100, 2) AS Total_tax, dbo.TB_Receipt.Receipt_Value_EGP,  " & _
                "                         ROUND(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) - dbo.TB_Receipt.Receipt_Value_EGP, 2) AS rem, Emp_employees_1.Emp_Name AS salse2 " & _
                " FROM            dbo.Emp_employees AS Emp_employees_1 RIGHT OUTER JOIN " & _
                "                         dbo.TB_Receipt ON Emp_employees_1.Emp_Code = dbo.TB_Receipt.Code_Salse AND Emp_employees_1.Compny_Code = dbo.TB_Receipt.Compny_Code RIGHT OUTER JOIN " & _
                "                         dbo.TB_Detalis_InvoiceSal INNER JOIN " & _
                "                         dbo.TB_Header_InvoiceSal ON dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo = dbo.TB_Header_InvoiceSal.Ser_InvoiceNo AND  " & _
                "                         dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code INNER JOIN " & _
                "                         dbo.St_CustomerData ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
                "                         dbo.TB_Header_InvoiceSal.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
                "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code ON " & _
                "        dbo.TB_Receipt.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code And dbo.TB_Receipt.Invoice_No = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo " & _
                "        WHERE(dbo.TB_Detalis_InvoiceSal.Compny_Code = '" & VarCodeCompny & "') " & _
                " GROUP BY dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Receipt_Value_EGP,  " & _
                "        Emp_employees_1.Emp_Name " & _
                " HAVING        (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "
        rs = Cnn.Execute(sql2)
    End Sub



    Sub Colected_data()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()



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

    Sub Cerate_Invoice_salse()
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

        sql = " DROP VIEW dbo.vw_invoiceSalse"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = "  CREATE VIEW vw_invoiceSalse AS  SELECT        dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.Emp_employees.Emp_Name, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS ee,  " & _
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
        rs = Cnn.Execute(sql2)
    End Sub
    Sub All_Salase_Invoice()

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
    Sub All_Salase_data()

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


        sql2 = "   SELECT        dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
   "                         AS Total_Item2, ROUND(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) + SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * 14 / 100, 2) AS Total_tax, dbo.TB_Receipt.Receipt_Value_EGP,  " & _
   "                         ROUND(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) - dbo.TB_Receipt.Receipt_Value_EGP, 2) AS rem, Emp_employees_1.Emp_Name AS salse2 " & _
   " FROM            dbo.Emp_employees AS Emp_employees_1 RIGHT OUTER JOIN " & _
   "                         dbo.TB_Receipt ON Emp_employees_1.Emp_Code = dbo.TB_Receipt.Code_Salse AND Emp_employees_1.Compny_Code = dbo.TB_Receipt.Compny_Code RIGHT OUTER JOIN " & _
   "                         dbo.TB_Detalis_InvoiceSal INNER JOIN " & _
   "                         dbo.TB_Header_InvoiceSal ON dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo = dbo.TB_Header_InvoiceSal.Ser_InvoiceNo AND  " & _
   "                         dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code INNER JOIN " & _
   "                         dbo.St_CustomerData ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
   "                         dbo.TB_Header_InvoiceSal.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
   "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code ON " & _
   "        dbo.TB_Receipt.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code And dbo.TB_Receipt.Invoice_No = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo " & _
   "        WHERE(dbo.TB_Detalis_InvoiceSal.Compny_Code = '" & VarCodeCompny & "') and dbo.St_CustomerData.Customer_Name like '%" & txt_NameCustomer.Text & "%' and dbo.Emp_employees.Emp_Name like '%" & txt_NameSalse.Text & "%' " & _
   " GROUP BY dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Receipt_Value_EGP,  " & _
   "        Emp_employees_1.Emp_Name " & _
   " HAVING        (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "تاريخ الفاتورة"
        GridView1.Columns(2).Caption = "اسم العميل"
        GridView1.Columns(3).Caption = "مندوب البيع"
        GridView1.Columns(4).Caption = "اجمالى قبل الضريبة"
        GridView1.Columns(5).Caption = "اجمالى بعد الضريبة"
        GridView1.Columns(6).Caption = "مبلغ التحصيل"
        GridView1.Columns(7).Caption = "اجمالى المتبقى"
        GridView1.Columns(8).Caption = "مندوب التحصيل"


        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        LabelX2.Enabled = False
        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        vardisplayReport = 10
        Colected_data()
        run_report()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If vardisplayReport = 10 Then
            Colected_data()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If

        If vardisplayReport = 11 Then
            Cerate_ComitionSalse()
            All_Salase_data()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If


        If vardisplayReport = 12 Then
            Cerate_Invoice_salse()
            All_Salase_Invoice()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If
    End Sub

    Private Sub txt_NameCustomer_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameCustomer.ButtonClick
        varcode_form = 2505
        VarOpenlookup2 = 2505
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_NameCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameCustomer.EditValueChanged

    End Sub

    Private Sub txt_nameitem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 2556
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub txt_nameitem_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameitem.EditValueChanged

    End Sub

    Private Sub txt_NameSalse_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameSalse.ButtonClick
        VarOpenlookup3 = 25251
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub txt_NameSalse_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameSalse.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txt_NameCustomer.Text = ""
        If vardisplayReport = 10 Then Colected_data() : run_report()
        If vardisplayReport = 11 Then All_Salase_data() : run_report()
        If vardisplayReport = 12 Then All_Salase_Invoice() : run_report()


    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        txt_nameitem.Text = ""
        If vardisplayReport = 10 Then Colected_data() : run_report()
        If vardisplayReport = 11 Then All_Salase_data() : run_report()
        If vardisplayReport = 12 Then All_Salase_Invoice() : run_report()
        run_report()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        txt_NameSalse.Text = ""
        If vardisplayReport = 10 Then Colected_data() : run_report()
        If vardisplayReport = 11 Then All_Salase_data() : run_report()
        If vardisplayReport = 12 Then All_Salase_Invoice() : run_report()
        run_report()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        LabelX2.Enabled = False
        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        vardisplayReport = 11
        Cerate_ComitionSalse()
        All_Salase_data()
        run_report()


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If vardisplayReport = 11 Then
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
    End Sub



    Private Sub GridView1_RowCellStyle1(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        For x As Integer = 0 To GridView1.RowCount


            'Dim quantity As Single
            Dim value_sal As Single


            If vardisplayReport = 10 Then 'التحويلات
                value_sal = GridView1.GetRowCellValue(x, GridView1.Columns(5))
                If value_sal > 0 Then
                    If e.Column.AbsoluteIndex = 5 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Yellow

                    End If
                Else
                End If
            End If



            If vardisplayReport = 10 Then 'الشيك
                value_sal = GridView1.GetRowCellValue(x, GridView1.Columns(6))
                If value_sal > 0 Then
                    If e.Column.AbsoluteIndex = 6 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.SteelBlue

                    End If
                Else
                End If
            End If



            If vardisplayReport = 10 Then 'الشيك
                value_sal = GridView1.GetRowCellValue(x, GridView1.Columns(10))
                If value_sal > 0 Then
                    If e.Column.AbsoluteIndex = 10 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Silver

                    End If
                Else
                End If
            End If






        Next x



    End Sub

    Private Sub Frm_Report_Salse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        LabelX2.Enabled = False
        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        vardisplayReport = 12
        Cerate_Invoice_salse()
        All_Salase_Invoice()
        run_report()
    End Sub
End Class