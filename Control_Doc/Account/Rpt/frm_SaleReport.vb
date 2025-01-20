Imports System.Data.OleDb

Public Class frm_SaleReport
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Private Sub frm_SaleReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_InterpakDataSet5.Vw_All_SalseChart' table. You can move, or remove it, as needed.
        'Me.Vw_All_SalseChartTableAdapter.Fill(Me.DB_InterpakDataSet5.Vw_All_SalseChart)
        All_Salase_data()
        find_salse1()
        find_salse2()
        find_salse3()
    End Sub
    Sub find_salse1()
        On Error Resume Next
        'Lab_Thsel1.Text = "0"
        'Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        'Dim vardateoder As String
        'vardateoder = dd.ToString("MM-d-yyyy")

        'sql = "  SELECT        SUM(Debit) AS SumSal       FROM dbo.MovmentStatement " & _
        '        " WHERE        (TypeBill = 2) AND (Compny_Code = '" & VarCodeCompny & "') AND (DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102))"

        'sql = " SELECT        SUM(dbo.TB_Receipt.Receipt_Value) AS Value " & _
        '     " FROM            dbo.TB_Receipt INNER JOIN " & _
        '     "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
        '     "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '     "                         dbo.St_CustomerData ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
        '     "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.St_CustomerData.Customer_AccountNo LEFT OUTER JOIN " & _
        '     "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
        '     " WHERE        (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '2020-01-01 00:00:00', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME,'2020-01-31 00:00:00', 102)) "

        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then Lab_Thsel1.Text = FormatCurrency(rs("Value").Value) Else Lab_Thsel1.Text = "0"


    End Sub
    Sub find_salse2()
        'On Error Resume Next
        'Lab_Thsel2.Text = "0"

        'sql = " SELECT        SUM(dbo.TB_Receipt.Receipt_Value) AS Value " & _
        '     " FROM            dbo.TB_Receipt INNER JOIN " & _
        '     "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
        '     "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '     "                         dbo.St_CustomerData ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
        '     "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.St_CustomerData.Customer_AccountNo LEFT OUTER JOIN " & _
        '     "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
        '     " WHERE        (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '2019-12-01 00:00:00', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME,'2019-12-31 00:00:00', 102)) "

        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then Lab_Thsel2.Text = FormatCurrency(rs("Value").Value) Else Lab_Thsel2.Text = "0"


    End Sub
    Sub find_salse3()
        'On Error Resume Next
        'Lab_Thsel3.Text = "0"

        'sql = " SELECT        SUM(dbo.TB_Receipt.Receipt_Value) AS Value " & _
        '     " FROM            dbo.TB_Receipt INNER JOIN " & _
        '     "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
        '     "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '     "                         dbo.St_CustomerData ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
        '     "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.St_CustomerData.Customer_AccountNo LEFT OUTER JOIN " & _
        '     "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
        '     " WHERE        (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '2019-11-01 00:00:00', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME,'2019-11-30 00:00:00', 102)) "

        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then Lab_Thsel3.Text = FormatCurrency(rs("Value").Value) Else Lab_Thsel3.Text = "0"


    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        All_Salase_data()
    End Sub


    Sub All_Salase_data()

        GridControl5.DataSource = Nothing
        GridView9.Columns.Clear()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
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
   "        WHERE(dbo.TB_Detalis_InvoiceSal.Compny_Code = '" & VarCodeCompny & "') " & _
   " GROUP BY dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Receipt_Value_EGP,  " & _
   "        Emp_employees_1.Emp_Name " & _
   " HAVING        (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True
        GridView9.Columns(0).Caption = "رقم الفاتورة"
        GridView9.Columns(1).Caption = "تاريخ الفاتورة"
        GridView9.Columns(2).Caption = "اسم العميل"
        GridView9.Columns(3).Caption = "مندوب البيع"
        GridView9.Columns(4).Caption = "اجمالى قبل الضريبة"
        GridView9.Columns(5).Caption = "اجمالى بعد الضريبة"
        GridView9.Columns(6).Caption = "مبلغ التحصيل"
        GridView9.Columns(7).Caption = "اجمالى المتبقى"
        GridView9.Columns(8).Caption = "مندوب التحصيل"


        GridView9.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView9.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub All_Salase_Invoice()

        GridControl4.DataSource = Nothing
        GridView7.Columns.Clear()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
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
    "FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
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
        GridControl4.DataSource = ds.Tables(0)

        GridView7.Appearance.Row.Font = New Font(GridView7.Appearance.Row.Font, FontStyle.Bold)
        GridView7.Appearance.Row.Options.UseFont = True
        GridView7.Columns(0).Caption = "رقم الفاتورة"
        GridView7.Columns(1).Caption = "تاريخ الفاتورة "
        GridView7.Columns(2).Caption = "أسم المندوب"
        GridView7.Columns(3).Caption = "أسم العميل"
        GridView7.Columns(4).Caption = "رقم الصنف"
        GridView7.Columns(5).Caption = "أسم الصنف"
        GridView7.Columns(6).Caption = "مجموعة الصنف"
        GridView7.Columns(7).Caption = "الكمية المباعة"
        GridView7.Columns(8).Caption = "الوحدة"
        GridView7.Columns(9).Caption = "السعر"
        GridView7.Columns(10).Caption = "الاجمالى"


        GridView7.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView7.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

  
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        All_Salase_Invoice()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Colected_data()
    End Sub

    Sub Colected_data()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date3.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date4.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT         Receipt_Date, Emp_Name, Compny_Name, Customer_Name, Name, valueThwel, valueCheck, Check_No,  iif( value_cash=0,Date_Asthkak,Date_Asthkak2) as dd, Bank_IN, value_cash, valueThwel+valueCheck+value_cash as Total_A " & _
   " FROM            dbo.vw_all_ColectedData " & _
   "        WHERE (Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_all_ColectedData.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_all_ColectedData.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
   " ORDER BY Receipt_Date "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView7.Appearance.Row.Font, FontStyle.Bold)
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

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


            Dim var7, var8, var9, var10, var11 As String
            var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
            var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
            var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))
            var11 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))))


            sql2 = "insert into TB_TempReport1  (Date_Collect,NameEmp,Customer_Name" & _
                " ,NameDir,NameStores,Crdit,TotalInvoice,No_Check,DateAtt,BankMshob,Value_cash,TotalAll_Invoice) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "',N'" & var10 & "',N'" & var11 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Recipt = 5




        Frm_RptColected2.Show()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView9.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle


            Dim var7, var8, var6 As String
            var6 = ""
            var7 = ""
            var8 = ""

            var6 = IIf(Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(6))) Is Nothing, "", Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(6))))
            var7 = IIf(Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(7))) Is Nothing, "", Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(7))))
            var8 = IIf(Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(8))) Is Nothing, "", Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(8))))


            sql2 = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name" & _
                " ,NameEmp,TotalInvoice,TotalAll_Invoice,Value_cash,TotalItem,NameDir) " & _
                " values (N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(0))) & "',N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(1))) & "',N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(3))) & "',N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(4))) & "',N'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(5))) & "',N'" & var6 & "',N'" & var7 & "',N'" & var8 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Recipt = 6




        Frm_RptColected2.Show()
    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.Click

    End Sub

    Private Sub GridControl5_DoubleClick(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick
        Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle
        Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(0))
        Frm_SalseInvoice.find_hedar()
        Frm_SalseInvoice.find_detalis()
        Frm_SalseInvoice.Total_Sum()
        Frm_SalseInvoice.sum_tax()
        Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView7.FocusedRowHandle
        Frm_SalseInvoice.Com_InvoiceNo2.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(0))
        Frm_SalseInvoice.find_hedar()
        Frm_SalseInvoice.find_detalis()
        Frm_SalseInvoice.Total_Sum()
        Frm_SalseInvoice.sum_tax()
        Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()
    End Sub
End Class