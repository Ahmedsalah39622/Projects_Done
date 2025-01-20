Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.Utils

Public Class frm_gard
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Dim value, value2 As String

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        find_Gard()
        'find_rented()
        'add_stores()
        'Sarf_stores()
        'sal_InvoiceItem()
    End Sub

    Sub add_stores() 'الكيات المضافة الى المخازن

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

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


        sql2 = "SELECT        dbo.Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.GroupItemMain.Name AS NameG, SUM(dbo.Statement_OfItem.Export) AS QytTotal " & _
        "FROM            dbo.Statement_OfItem INNER JOIN " & _
"                         dbo.Stores ON dbo.Statement_OfItem.Code_Stores = dbo.Stores.Code INNER JOIN " & _
"                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code INNER JOIN " & _
"                         dbo.GroupItemMain ON dbo.BD_ITEM.CodeGroupItemMain = dbo.GroupItemMain.Code " & _
" WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
" GROUP BY dbo.Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.GroupItemMain.Name " & _
"        HAVING(SUM(dbo.Statement_OfItem.Export) <> 0) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "300"
        GridView5.Columns(3).Width = "200"
        GridView5.Columns(4).Width = "100"



        GridView5.Columns(0).Caption = "أسم المخزن"
        GridView5.Columns(1).Caption = "رقم الصنف"
        GridView5.Columns(2).Caption = "أسم الصنف"
        GridView5.Columns(3).Caption = "المجموعة الرئيسية"
        GridView5.Columns(4).Caption = "الكميات المضافة"







        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub sal_InvoiceItem() 'مبيعات الاصناف

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

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

        sql2 = "     SELECT        Ex_No, DateBill, AccountName, Quntity, Price, DiscountItem, TotalInvoice, NameItem, NameNG, NameStores " & _
     " FROM            dbo.vw_allinvoice_Item " & _
     " WHERE        (DateBill >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateBill <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)

        GridView11.Columns(0).Width = "100"
        GridView11.Columns(1).Width = "100"
        GridView11.Columns(2).Width = "300"
        GridView11.Columns(3).Width = "200"
        GridView11.Columns(4).Width = "100"
        GridView11.Columns(5).Width = "100"
        GridView11.Columns(6).Width = "100"
        GridView11.Columns(7).Width = "200"
        GridView11.Columns(8).Width = "100"
        GridView11.Columns(9).Width = "100"



        GridView11.Columns(0).Caption = "رقم الفاتورة"
        GridView11.Columns(1).Caption = "تاريخ الفاتورة"
        GridView11.Columns(2).Caption = "أسم العميل"
        GridView11.Columns(3).Caption = "الكمية"
        GridView11.Columns(4).Caption = "السعر"
        GridView11.Columns(5).Caption = "الخصم"
        GridView11.Columns(6).Caption = "الاجمالى"
        GridView11.Columns(7).Caption = "أسم الصنف"
        GridView11.Columns(8).Caption = "أسم المجموعة"
        GridView11.Columns(9).Caption = "أسم المخزن"







        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub Sarf_stores() 'الكيات المضافة الى المخازن

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

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


        sql2 = "SELECT        dbo.Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.GroupItemMain.Name AS NameG, SUM(dbo.Statement_OfItem.Import) AS QytTotal " & _
        "FROM            dbo.Statement_OfItem INNER JOIN " & _
"                         dbo.Stores ON dbo.Statement_OfItem.Code_Stores = dbo.Stores.Code INNER JOIN " & _
"                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code INNER JOIN " & _
"                         dbo.GroupItemMain ON dbo.BD_ITEM.CodeGroupItemMain = dbo.GroupItemMain.Code " & _
" WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
" GROUP BY dbo.Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.GroupItemMain.Name " & _
"        HAVING(SUM(dbo.Statement_OfItem.Export) <> 0) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Columns(0).Width = "100"
        GridView9.Columns(1).Width = "100"
        GridView9.Columns(2).Width = "300"
        GridView9.Columns(3).Width = "200"
        GridView9.Columns(4).Width = "100"



        GridView9.Columns(0).Caption = "أسم المخزن"
        GridView9.Columns(1).Caption = "رقم الصنف"
        GridView9.Columns(2).Caption = "أسم الصنف"
        GridView9.Columns(3).Caption = "المجموعة الرئيسية"
        GridView9.Columns(4).Caption = "الكميات المنصرفة"







        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub


    Sub find_rented()


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

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

        sql2 = "     SELECT        TOP (100) PERCENT dbo.BillSalRuternHeder.NumberBill, dbo.BillSalRuternHeder.DateBill, dbo.BillSalseReturnItem.Quntity, dbo.BillSalseReturnItem.Price, dbo.BillSalseReturnItem.TotallItem, " & _
     "                         dbo.BillSalseReturnItem.Ex_NumberBill, dbo.TB_ChartOfAccount.AccountName, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name " & _
     " FROM            dbo.BillSalRuternHeder INNER JOIN " & _
     "                         dbo.BillSalseReturnItem ON dbo.BillSalRuternHeder.NumberBill = dbo.BillSalseReturnItem.NumberBill INNER JOIN " & _
     "                        dbo.BD_ITEM ON dbo.BillSalseReturnItem.NoItem = dbo.BD_ITEM.Code INNER JOIN " & _
     "                        dbo.TB_ChartOfAccount ON dbo.BillSalRuternHeder.AccountNumberSu = dbo.TB_ChartOfAccount.Account_No " & _
     " WHERE        (dbo.BillSalRuternHeder.DateBill >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.BillSalRuternHeder.DateBill <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
     " ORDER BY dbo.BillSalRuternHeder.NumberBill "





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "100"
        GridView3.Columns(2).Width = "100"
        GridView3.Columns(3).Width = "100"
        GridView3.Columns(4).Width = "100"
        GridView3.Columns(5).Width = "200"
        GridView3.Columns(6).Width = "200"
        GridView3.Columns(7).Width = "100"
        GridView3.Columns(8).Width = "200"


        GridView3.Columns(0).Caption = "رقم الفاتورة"
        GridView3.Columns(1).Caption = "تاريخ الفاتورة"
        GridView3.Columns(2).Caption = "الكمية"
        GridView3.Columns(3).Caption = "السعر"
        GridView3.Columns(4).Caption = "الاجمالى"
        GridView3.Columns(5).Caption = "رقم الفاتورة"
        GridView3.Columns(6).Caption = "أسم العميل"
        GridView3.Columns(7).Caption = "رقم الصنف"
        GridView3.Columns(8).Caption = "أسم الصنف"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Sub find_Gard()
        'On Error Resume Next




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

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


        If OP3.Checked = True Then 'متوسط

            sql2 = "SELECT        dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, rtrim(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward,  " & _
            "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem, " & _
             "             AVR(dbo.Statement_OfItem.Price_Unit) AS PriceUnit,  " & _
             "                        ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * dbo.Statement_OfItem.Price_Unit AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
            " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
            "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.Statement_OfItem.Price_Unit " & _
            "      "

        End If

        If OP2.Checked = True Then ' اقل

            sql2 = "SELECT        dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, rtrim(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward,  " & _
            "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem, " & _
             "               MIN(dbo.Statement_OfItem.Price_Unit) AS PriceUnit,  " & _
             "                        ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * dbo.Statement_OfItem.Price_Unit AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
            " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
            "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.Statement_OfItem.Price_Unit " & _
            "            "

        End If




        If OP1.Checked = True Then ' اعلى



            sql2 = "SELECT        dbo.BD_Stores.Name, rtrim(dbo.BD_ITEM.Ex_Item) as Ex_Item , rtrim(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward,  " & _
            "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem, " & _
             "                        MAX(dbo.Statement_OfItem.Price_Unit) AS PriceUnit,  " & _
             "                        ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * dbo.Statement_OfItem.Price_Unit AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
            " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
            "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.Statement_OfItem.Price_Unit " & _
            "      "


        End If





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "150"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "250"
        GridView6.Columns(3).Width = "100"
        GridView6.Columns(4).Width = "100"
        GridView6.Columns(5).Width = "100"
        GridView6.Columns(6).Width = "100"
        GridView6.Columns(7).Width = "100"
        GridView6.Columns(8).Width = "100"
        GridView6.Columns(9).Width = "100"

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "أسم المخزن"
        GridView6.Columns(1).Caption = "رقم الصنف"
        GridView6.Columns(2).Caption = "أسم الصنف"
        GridView6.Columns(3).Caption = "الوحدة"
        GridView6.Columns(4).Caption = "وارد"
        GridView6.Columns(5).Caption = "منصرف"
        GridView6.Columns(6).Caption = "رصيد"
        GridView6.Columns(7).Caption = "سعر الوحدة"
        GridView6.Columns(8).Caption = "قيمة المخزون"
        GridView6.Columns(9).Caption = "مجموعة الصنف"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Private Sub GridView6_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView6.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
        'GridView1.GroupRowHeight = 1


        GridView6.RowHeight = 20
        GridView6.GroupRowHeight = 1
        GridView6.RowSeparatorHeight = 1
        'End If
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        GridView6.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridView3.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GridView5.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        GridView9.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        GridView11.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        GridView13.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        GridView15.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        GridView17.ShowPrintPreview()
    End Sub



    Sub find_Stores_All()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If txt_nameStores3.Text = "" Then
            sql2 = "   SELECT        dbo.BD_Stores.Name AS NameStores, dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1,  " & _
                "                         SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance " & _
                " FROM            dbo.Statement_OfItem INNER JOIN " & _
                "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
                "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
                "                         dbo.BD_GroupItem1 ON dbo.BD_ITEM.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_ITEM.Compny_Code = dbo.BD_GroupItem1.Compny_Code " & _
                " GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.Statement_OfItem.Compny_Code, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name " & _
                " HAVING        (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "')  "

        Else
            sql2 = "   SELECT        dbo.BD_Stores.Name AS NameStores, dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1,  " & _
        "                         SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance " & _
        " FROM            dbo.Statement_OfItem INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
        "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
        "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
        "                         dbo.BD_GroupItem1 ON dbo.BD_ITEM.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_ITEM.Compny_Code = dbo.BD_GroupItem1.Compny_Code " & _
        " GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.Statement_OfItem.Compny_Code, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name " & _
        " HAVING        (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.BD_ITEM.Ex_Item = '" & value2 & "') AND (dbo.BD_Stores.Name = '" & value & "') "

        End If



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl7.DataSource = ds.Tables(0)
        GridView13.Columns(0).Width = "100"
        GridView13.Columns(1).Width = "70"
        GridView13.Columns(2).Width = "70"
        GridView13.Columns(3).Width = "70"
        GridView13.Columns(4).Width = "70"
        GridView13.Columns(5).Width = "70"
        GridView13.Columns(6).Width = "250"


        GridView13.Columns(0).Caption = "أسم المخزن"
        GridView13.Columns(1).Caption = "رقم الصنف"
        GridView13.Columns(2).Caption = "رقم التوصيفى"
        GridView13.Columns(3).Caption = "أسم الصنف"
        GridView13.Columns(4).Caption = "المجموعة الرئيسية"
        GridView13.Columns(5).Caption = "مجموعة 1"
        GridView13.Columns(6).Caption = "الرصيد"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView13.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub
    Sub Item_sarfAll()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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


        If RadioButton3.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE     (NameStores = '" & value & "') and  (RTRIM(Ex_Item) = '" & Trim(value2) & "') and  (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
            " ORDER BY Order_Date "
        End If

        If RadioButton1.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE      (NameStores = '" & value & "') and  (RTRIM(Ex_Item) = '" & Trim(value2) & "') and  (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NULL) " & _
            " ORDER BY Order_Date "
        End If

        If RadioButton2.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE        (NameStores = '" & value & "') and (RTRIM(Ex_Item) = '" & Trim(value2) & "') and (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NOT NULL) " & _
            " ORDER BY Order_Date "
        End If





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)
        GridView9.Columns(0).Width = "100"
        GridView9.Columns(1).Width = "70"
        GridView9.Columns(2).Width = "70"
        GridView9.Columns(3).Width = "70"
        GridView9.Columns(4).Width = "70"
        GridView9.Columns(5).Width = "70"
        GridView9.Columns(6).Width = "250"
        GridView9.Columns(7).Width = "100"
        GridView9.Columns(8).Width = "100"
        GridView9.Columns(9).Width = "100"
        GridView9.Columns(10).Width = "100"
        GridView9.Columns(11).Width = "100"
        GridView9.Columns(12).Width = "100"

        GridView9.Columns(0).Caption = "رقم الطلبية"
        GridView9.Columns(1).Caption = "رقم طلب الصرف"
        GridView9.Columns(2).Caption = "رقم اذن الصرف"
        GridView9.Columns(3).Caption = "رقم الفاتورة"
        GridView9.Columns(4).Caption = "التاريخ"
        GridView9.Columns(5).Caption = "رقم الصنف"
        GridView9.Columns(6).Caption = "أسم الصنف"
        GridView9.Columns(7).Caption = "مجموعة رئيسية"
        GridView9.Columns(8).Caption = "مجموعة 1"
        GridView9.Columns(9).Caption = "الكمية"
        GridView9.Columns(10).Caption = "أسم العميل"
        GridView9.Columns(11).Caption = "القيمة"
        GridView9.Columns(12).Caption = "أسم المخزن"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView9.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Sub Find_DetilesInvintorey()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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

        If Txt_NameItem4.Text = "" And txt_NameStores4.Text = "" Then
            sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, PriceItem, ValueWared, Import, PriceItem2, ValueMnsrf, Type_Bill " & _
       " FROM            dbo.vw_DetilesInvintoryAll " & _
       " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "


        Else
            sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, PriceItem, ValueWared, Import, PriceItem2, ValueMnsrf, Type_Bill " & _
                   " FROM            dbo.vw_DetilesInvintoryAll " & _
                   " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Name ='" & Trim(txt_NameStores4.Text) & "') AND  (Ex_Item = '" & value2 & "') "
        End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "70"
        GridView3.Columns(2).Width = "70"
        GridView3.Columns(3).Width = "70"
        GridView3.Columns(4).Width = "70"
        GridView3.Columns(5).Width = "70"
        GridView3.Columns(6).Width = "250"
        GridView3.Columns(7).Width = "100"
        GridView3.Columns(8).Width = "100"
        GridView3.Columns(9).Width = "100"
        GridView3.Columns(10).Width = "100"
        GridView3.Columns(11).Width = "100"
        GridView3.Columns(12).Width = "100"
        GridView3.Columns(13).Width = "100"
        GridView3.Columns(14).Width = "100"
        'GridView3.Columns(15).Width = "100"


        GridView3.Columns(0).Caption = "اسم المخزن"
        GridView3.Columns(1).Caption = "رقم السند"
        GridView3.Columns(2).Caption = "تاريخ السند"
        GridView3.Columns(3).Caption = "رقم الصنف"
        GridView3.Columns(4).Caption = "أسم الصنف"
        GridView3.Columns(5).Caption = "مجموعة رئيسية"
        GridView3.Columns(6).Caption = "مجموعة 1"
        GridView3.Columns(7).Caption = "الوحدة"
        GridView3.Columns(8).Caption = "الكمية الواردة"
        GridView3.Columns(9).Caption = "سعر الوارد"
        GridView3.Columns(10).Caption = "قيمة الوارد"
        GridView3.Columns(11).Caption = "الكمية المنصرفة"
        GridView3.Columns(12).Caption = "سعر المنصرف"
        GridView3.Columns(13).Caption = "قيمة المنصرف"
        GridView3.Columns(14).Caption = "نوع السند"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView3.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(13).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub

    Sub ward_Item()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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

        If Txt_NameItem5.Text = "" Then
            sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, Type_Bill " & _
       " FROM            dbo.vw_DetilesInvintoryAll " & _
       " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Import = 0) "


        Else
            sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, Type_Bill " & _
                   " FROM            dbo.vw_DetilesInvintoryAll " & _
                   " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (RTRIM(Ex_Item) ='" & Trim(value2) & "') AND (Import = 0) "

        End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)
        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "70"
        GridView5.Columns(2).Width = "70"
        GridView5.Columns(3).Width = "70"
        GridView5.Columns(4).Width = "70"
        GridView5.Columns(5).Width = "70"
        GridView5.Columns(6).Width = "250"
        GridView5.Columns(7).Width = "100"
        GridView5.Columns(8).Width = "100"
        GridView5.Columns(9).Width = "100"



        GridView5.Columns(0).Caption = "اسم المخزن"
        GridView5.Columns(1).Caption = "رقم السند"
        GridView5.Columns(2).Caption = "تاريخ السند"
        GridView5.Columns(3).Caption = "رقم الصنف"
        GridView5.Columns(4).Caption = "أسم الصنف"
        GridView5.Columns(5).Caption = "مجموعة رئيسية"
        GridView5.Columns(6).Caption = "مجموعة 1"
        GridView5.Columns(7).Caption = "الوحدة"
        GridView5.Columns(8).Caption = "الكمية الواردة"
        GridView5.Columns(9).Caption = "نوع السند"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView5.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub
    Sub Item_sarfAll2()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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


        If RadioButton3.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE       (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
            " ORDER BY Order_Date "
        End If

        If RadioButton1.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE       (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NULL) " & _
            " ORDER BY Order_Date "
        End If

        If RadioButton2.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT R_order, Order_NO, Order_Stores_NO, Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity, AccountName, TotalItem,NameStores " & _
            " FROM            dbo.Vw_InvintoryAllItem " & _
            " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NOT NULL)  " & _
            " ORDER BY Order_Date "
        End If





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)
        GridView9.Columns(0).Width = "100"
        GridView9.Columns(1).Width = "70"
        GridView9.Columns(2).Width = "70"
        GridView9.Columns(3).Width = "70"
        GridView9.Columns(4).Width = "70"
        GridView9.Columns(5).Width = "70"
        GridView9.Columns(6).Width = "250"
        GridView9.Columns(7).Width = "100"
        GridView9.Columns(8).Width = "100"
        GridView9.Columns(9).Width = "100"
        GridView9.Columns(10).Width = "100"
        GridView9.Columns(11).Width = "100"
        GridView9.Columns(12).Width = "100"

        GridView9.Columns(0).Caption = "رقم الطلبية"
        GridView9.Columns(1).Caption = "رقم طلب الصرف"
        GridView9.Columns(2).Caption = "رقم اذن الصرف"
        GridView9.Columns(3).Caption = "رقم الفاتورة"
        GridView9.Columns(4).Caption = "التاريخ"
        GridView9.Columns(5).Caption = "رقم الصنف"
        GridView9.Columns(6).Caption = "أسم الصنف"
        GridView9.Columns(7).Caption = "مجموعة رئيسية"
        GridView9.Columns(8).Caption = "مجموعة 1"
        GridView9.Columns(9).Caption = "الكمية"
        GridView9.Columns(10).Caption = "أسم العميل"
        GridView9.Columns(11).Caption = "القيمة"
        GridView9.Columns(12).Caption = "أسم المخزن"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView9.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Sub sal_item()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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



        sql2 = "SELECT         Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1, Quntity,Price_Unit,UnitName,TotalItem, rtrim(AccountName) as AccountName,NameStores " & _
        " FROM            dbo.Vw_InvintoryAllItem " & _
        " WHERE        (NameStores = '" & value & "') and (RTRIM(Ex_Item) = '" & Trim(value2) & "') and (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NOT NULL) " & _
        " ORDER BY Order_Date "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)
        GridView11.Columns(0).Width = "100"
        GridView11.Columns(1).Width = "70"
        GridView11.Columns(2).Width = "70"
        GridView11.Columns(3).Width = "70"
        GridView11.Columns(4).Width = "70"
        GridView11.Columns(5).Width = "70"
        GridView11.Columns(6).Width = "70"
        GridView11.Columns(7).Width = "100"
        GridView11.Columns(8).Width = "100"
        GridView11.Columns(9).Width = "100"
        GridView11.Columns(10).Width = "100"
        GridView11.Columns(11).Width = "100"



        GridView11.Columns(0).Caption = "رقم الفاتورة"
        GridView11.Columns(1).Caption = "التاريخ"
        GridView11.Columns(2).Caption = "رقم الصنف"
        GridView11.Columns(3).Caption = "أسم الصنف"
        GridView11.Columns(4).Caption = "مجموعة رئيسية"
        GridView11.Columns(5).Caption = "مجموعة 1"
        GridView11.Columns(6).Caption = "الكمية"
        GridView11.Columns(7).Caption = "سعر الوحدة"
        GridView11.Columns(8).Caption = "الوحدة"
        GridView11.Columns(9).Caption = "القيمة"
        GridView11.Columns(10).Caption = "أسم العميل"
        GridView11.Columns(11).Caption = "أسم المخزن"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView11.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub

    Sub sal_item_All()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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



        sql2 = "SELECT         Ext_InvoiceNo, Order_Date, RTRIM(Ex_Item) AS Ex_Item, Name, MG, G1,Quntity,Price_Unit,UnitName,TotalItem, rtrim(AccountName) as AccountName,NameStores " & _
        " FROM            dbo.Vw_InvintoryAllItem " & _
        " WHERE         (Compny_Code = '" & VarCodeCompny & "') AND (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ext_InvoiceNo IS NOT NULL) " & _
        " ORDER BY Order_Date "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)
        GridView11.Columns(0).Width = "100"
        GridView11.Columns(1).Width = "70"
        GridView11.Columns(2).Width = "70"
        GridView11.Columns(3).Width = "70"
        GridView11.Columns(4).Width = "70"
        GridView11.Columns(5).Width = "70"
        GridView11.Columns(6).Width = "70"
        GridView11.Columns(7).Width = "100"
        GridView11.Columns(8).Width = "100"
        GridView11.Columns(9).Width = "100"
        GridView11.Columns(10).Width = "100"
        GridView11.Columns(11).Width = "100"



        GridView11.Columns(0).Caption = "رقم الفاتورة"
        GridView11.Columns(1).Caption = "التاريخ"
        GridView11.Columns(2).Caption = "رقم الصنف"
        GridView11.Columns(3).Caption = "أسم الصنف"
        GridView11.Columns(4).Caption = "مجموعة رئيسية"
        GridView11.Columns(5).Caption = "مجموعة 1"
        GridView11.Columns(6).Caption = "الكمية"
        GridView11.Columns(7).Caption = "سعر الوحدة"
        GridView11.Columns(8).Caption = "الوحدة"
        GridView11.Columns(9).Caption = "القيمة"
        GridView11.Columns(10).Caption = "أسم العميل"
        GridView11.Columns(11).Caption = "أسم المخزن"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView11.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Sub Card_Item()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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


        sql2 = " SELECT        TOP (100) PERCENT dbo.vw_overItem.NumberBill, dbo.vw_overItem.DateMoveM, dbo.vw_overItem.Discription, dbo.vw_overItem.Export, dbo.vw_overItem.Import, dbo.vw_overItem.Balance " & _
              " FROM            dbo.vw_overItem INNER JOIN " & _
              "           dbo.BD_Stores ON dbo.vw_overItem.Code_Stores = dbo.BD_Stores.Code AND dbo.vw_overItem.Compny_Code = dbo.BD_Stores.Compny_Code LEFT OUTER JOIN  " & _
              "           dbo.BD_ITEM ON dbo.vw_overItem.NoItem = dbo.BD_ITEM.Code AND dbo.vw_overItem.Compny_Code = dbo.BD_ITEM.Compny_Code  " & _
                " WHERE        (dbo.BD_ITEM.Ex_Item = '" & Trim(value2) & "') AND (dbo.vw_overItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_overItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
                "                          (dbo.BD_Stores.Name = '" & value & "') and vw_overItem.Compny_Code ='" & VarCodeCompny & "' "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "250"
        GridView1.Columns(3).Width = "100"
        GridView1.Columns(4).Width = "100"
        GridView1.Columns(5).Width = "100"

        GridView1.Columns(0).Caption = "رقم الحركة"
        GridView1.Columns(1).Caption = "تاريخ الحركة"
        GridView1.Columns(2).Caption = "البيان"
        GridView1.Columns(3).Caption = "وارد"
        GridView1.Columns(4).Caption = "منصرف"
        GridView1.Columns(5).Caption = "رصيد"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub






    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        Item_sarfAll()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        Item_sarfAll()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        Item_sarfAll()
    End Sub

    Private Sub SimpleButton17_Click(sender As Object, e As EventArgs) Handles SimpleButton17.Click
        Item_sarfAll2()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        Txt_NameItem2.Text = ""
        txt_nameStores2.Text = ""
        sal_item_All()
    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        txt_nameStores3.Text = ""
        find_Stores_All()
    End Sub


    Private Sub Frm_LimetedItem_Click(sender As Object, e As EventArgs) Handles Frm_LimetedItem.Click
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "     SELECT        dbo.BD_Stores.Name AS NameStores, dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1, " & _
                "                         SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance, dbo.BD_ITEM.MinOrderItem, dbo.BD_Unit.Name AS Unit " & _
                "   FROM            dbo.Statement_OfItem INNER JOIN " & _
                "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
                "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
                "                         dbo.BD_GroupItem1 ON dbo.BD_ITEM.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_ITEM.Compny_Code = dbo.BD_GroupItem1.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
                "   GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.Statement_OfItem.Compny_Code, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name,  " & _
                "        dbo.BD_ITEM.MinOrderItem, dbo.BD_Unit.Name " & _
                "   HAVING        (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') AND (SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) < dbo.BD_ITEM.MinOrderItem) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl9.DataSource = ds.Tables(0)
        GridView17.Columns(0).Width = "100"
        GridView17.Columns(1).Width = "70"
        GridView17.Columns(2).Width = "70"
        GridView17.Columns(3).Width = "200"
        GridView17.Columns(4).Width = "200"
        GridView17.Columns(5).Width = "200"
        GridView17.Columns(6).Width = "100"
        GridView17.Columns(7).Width = "100"
        GridView17.Columns(8).Width = "100"


        GridView17.Columns(0).Caption = "أسم المخزن"
        GridView17.Columns(1).Caption = "رقم الصنف"
        GridView17.Columns(2).Caption = "رقم التوصيفى"
        GridView17.Columns(3).Caption = "أسم الصنف"
        GridView17.Columns(4).Caption = "المجموعة الرئيسية"
        GridView17.Columns(5).Caption = "مجموعة 1"
        GridView17.Columns(6).Caption = "الرصيد"
        GridView17.Columns(7).Caption = "حد الطلب"
        GridView17.Columns(8).Caption = "الوحدة"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView17.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Txt_NameItem4.Text = ""
        Find_DetilesInvintorey()

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Txt_NameItem5.Text = ""
        ward_Item()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click

        Rpt_CartItem.Show()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        txt_NamestoresCart.Text = ""

    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Rpt_InvintoryValue.Show()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        txt_NameStores4.Text = ""
        Txt_NameItem4.Text = ""
        Find_DetilesInvintorey()
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

    Private Sub frm_gard_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 0 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 1 'الصفحة التالية
        If e.KeyCode = Keys.F3 Then TabPane1.SelectedPageIndex = 2 'الصفحة التالية
        If e.KeyCode = Keys.F4 Then TabPane1.SelectedPageIndex = 3 'الصفحة التالية
        If e.KeyCode = Keys.F5 Then TabPane1.SelectedPageIndex = 4 'الصفحة التالية
        If e.KeyCode = Keys.F6 Then TabPane1.SelectedPageIndex = 5 'الصفحة التالية


    End Sub

    Private Sub frm_gard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        value2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))

        txt_nameStores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NamestoresCart.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameStores4.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_nameStores2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_nameStores3.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))

        Txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        Txt_NameItem2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        Txt_NameItem4.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        Txt_NameItem5.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_NameItemCart.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))

        Card_Item()
        Item_sarfAll()
        sal_item()
        find_Stores_All()
        Find_DetilesInvintorey()
        ward_Item()
    End Sub
End Class