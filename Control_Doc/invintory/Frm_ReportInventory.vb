Imports System.Data.OleDb

Public Class Frm_ReportInventory
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub Cmd_CustomerFill_Click(sender As Object, e As EventArgs) Handles Cmd_CustomerFill.Click
        find_Gard()
        Lab_Name.Text = "تقرير تقييم المخزون"
        Panel1.Visible = True
        Panel3.Visible = False
    End Sub


    Sub find_Gard()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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

            sql2 = "SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
    "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem,  " & _
    "                         round(avg(dbo.Statement_OfItem.Price_Unit),2) AS PriceUnit, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * round(avg(dbo.Statement_OfItem.Price_Unit),2)  " & _
    "                         AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
    " FROM            dbo.Statement_OfItem INNER JOIN " & _
    "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
    "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
    "                        dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
    "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
    " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
    "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
    " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name "


        End If

        If OP2.Checked = True Then ' اقل

            sql2 = "SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
            "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem,  " & _
            "                         Min(dbo.Statement_OfItem.Price_Unit) AS PriceUnit, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * min(dbo.Statement_OfItem.Price_Unit)  " & _
            "                         AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                        dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
            " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
            "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name "


        End If




        If OP1.Checked = True Then ' اعلى


            sql2 = "SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
            "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem,  " & _
            "                         MAX(dbo.Statement_OfItem.Price_Unit) AS PriceUnit, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) * MAX(dbo.Statement_OfItem.Price_Unit)  " & _
            "                         AS valueStores, dbo.BD_GROUPITEMMAIN.Name AS NG " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                        dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
            " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
            "                         (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name "

        End If





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Width = "150"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "250"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "وارد"
        GridView1.Columns(5).Caption = "منصرف"
        GridView1.Columns(6).Caption = "رصيد"
        GridView1.Columns(7).Caption = "سعر الوحدة"
        GridView1.Columns(8).Caption = "قيمة المخزون"
        GridView1.Columns(9).Caption = "مجموعة الصنف"


        GridView1.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub
    Sub ward_Item()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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


        sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, Type_Bill " & _
               " FROM            dbo.vw_DetilesInvintoryAll " & _
               " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))  AND (Import = 0) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "70"
        'GridView1.Columns(5).Width = "70"
        'GridView1.Columns(6).Width = "250"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"



        GridView1.Columns(0).Caption = "اسم المخزن"
        GridView1.Columns(1).Caption = "رقم السند"
        GridView1.Columns(2).Caption = "تاريخ السند"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "مجموعة رئيسية"
        GridView1.Columns(6).Caption = "مجموعة 1"
        GridView1.Columns(7).Caption = "الوحدة"
        GridView1.Columns(8).Caption = "الكمية الواردة"
        GridView1.Columns(9).Caption = "نوع السند"


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        find_Gard()
        Lab_Name.Text = "تقرير تقييم المخزون"
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub Cmd_TotalInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_TotalInvoice.Click
        Find_DetilesInvintorey()
        Lab_Name.Text = "تفصيلى حركة المخازن والاصناف"
        Panel1.Visible = False
        Panel3.Visible = False
    End Sub


    Sub Find_DetilesInvintorey()
        'On Error Resume Next
        'If value = "" Then Exit Sub


        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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



        sql2 = "   SELECT        Name, NumberBill, DateMoveM, RTRIM(Ex_Item) AS Ex_Item, NameItem, MG, G1, UnitName, Export, PriceItem, ValueWared, Import, PriceItem2, ValueMnsrf, Type_Bill " & _
               " FROM            dbo.vw_DetilesInvintoryAll " & _
               " WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))   "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "70"
        'GridView1.Columns(5).Width = "70"
        'GridView1.Columns(6).Width = "250"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"
        'GridView1.Columns(11).Width = "100"
        'GridView1.Columns(12).Width = "100"
        'GridView1.Columns(13).Width = "100"
        'GridView1.Columns(14).Width = "100"
        'GridView3.Columns(15).Width = "100"
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "اسم المخزن"
        GridView1.Columns(1).Caption = "رقم السند"
        GridView1.Columns(2).Caption = "تاريخ السند"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "مجموعة رئيسية"
        GridView1.Columns(6).Caption = "مجموعة 1"
        GridView1.Columns(7).Caption = "الوحدة"
        GridView1.Columns(8).Caption = "الكمية الواردة"
        GridView1.Columns(9).Caption = "سعر الوارد"
        GridView1.Columns(10).Caption = "قيمة الوارد"
        GridView1.Columns(11).Caption = "الكمية المنصرفة"
        GridView1.Columns(12).Caption = "سعر المنصرف"
        GridView1.Columns(13).Caption = "قيمة المنصرف"
        GridView1.Columns(14).Caption = "نوع السند"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(13).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        ward_Item()
        Lab_Name.Text = "تقرير الاصناف المضافة الى المخازن"
        Panel1.Visible = False
        Panel3.Visible = False

    End Sub

    Private Sub Cmd_Crdit_Click(sender As Object, e As EventArgs) Handles Cmd_Crdit.Click
        Panel1.Visible = False
        Panel3.Visible = True
        Item_sarfAll2()
        Lab_Name.Text = "تقرير الاصناف المنصرفة الى المخازن"
    End Sub


    Sub Item_sarfAll2()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
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
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "70"
        'GridView1.Columns(5).Width = "70"
        'GridView1.Columns(6).Width = "250"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "150"
        'GridView1.Columns(11).Width = "100"
        'GridView1.Columns(12).Width = "100"

        GridView1.Columns(0).Caption = "رقم الطلبية"
        GridView1.Columns(1).Caption = "رقم طلب الصرف"
        GridView1.Columns(2).Caption = "رقم اذن الصرف"
        GridView1.Columns(3).Caption = "رقم الفاتورة"
        GridView1.Columns(4).Caption = "التاريخ"
        GridView1.Columns(5).Caption = "رقم الصنف"
        GridView1.Columns(6).Caption = "أسم الصنف"
        GridView1.Columns(7).Caption = "مجموعة رئيسية"
        GridView1.Columns(8).Caption = "مجموعة 1"
        GridView1.Columns(9).Caption = "الكمية"
        GridView1.Columns(10).Caption = "أسم العميل"
        GridView1.Columns(11).Caption = "القيمة"
        GridView1.Columns(12).Caption = "أسم المخزن"


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        Item_sarfAll2()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Item_sarfAll2()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Item_sarfAll2()
    End Sub

    Private Sub Cmd_SalCustomer_Click(sender As Object, e As EventArgs) Handles Cmd_SalCustomer.Click

        Lab_Name.Text = "تقرير جرد مجمع المخازن المخازن"
        Panel1.Visible = False
        Panel3.Visible = False
        find_Stores_All()
    End Sub


    Sub find_Stores_All()
        'On Error Resume Next
        'If value = "" Then Exit Sub
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

  
        sql2 = "   SELECT        dbo.BD_Stores.Name AS NameStores, dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1,  " & _
    "                         SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance " & _
    " FROM            dbo.Statement_OfItem INNER JOIN " & _
    "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
    "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
    "                         dbo.BD_GroupItem1 ON dbo.BD_ITEM.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_ITEM.Compny_Code = dbo.BD_GroupItem1.Compny_Code " & _
    " GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.Statement_OfItem.Compny_Code, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name " & _
    " HAVING        (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "70"
        'GridView1.Columns(5).Width = "70"
        'GridView1.Columns(6).Width = "250"


        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "رقم التوصيفى"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "المجموعة الرئيسية"
        GridView1.Columns(5).Caption = "مجموعة 1"
        GridView1.Columns(6).Caption = "الرصيد"

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        find_ItemLimeted()
        Lab_Name.Text = "تقرير الاصناف تعدت حد الطلب"
        Panel1.Visible = False
        Panel3.Visible = False
    End Sub



    Sub find_ItemLimeted()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
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
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "200"
        'GridView1.Columns(4).Width = "200"
        'GridView1.Columns(5).Width = "200"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"


        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "رقم التوصيفى"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "المجموعة الرئيسية"
        GridView1.Columns(5).Caption = "مجموعة 1"
        GridView1.Columns(6).Caption = "الرصيد"
        GridView1.Columns(7).Caption = "حد الطلب"
        GridView1.Columns(8).Caption = "الوحدة"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    End Sub

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        sal_item_All()
        Lab_Name.Text = "تقرير مبيعات الاصناف فى المخازن"
        Panel1.Visible = False
        Panel3.Visible = False
    End Sub
    Sub sal_item_All()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
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
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "70"
        'GridView1.Columns(3).Width = "70"
        'GridView1.Columns(4).Width = "70"
        'GridView1.Columns(5).Width = "70"
        'GridView1.Columns(6).Width = "70"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"
        'GridView1.Columns(11).Width = "100"



        GridView1.Columns(0).Caption = "رقم الفاتورة"
        GridView1.Columns(1).Caption = "التاريخ"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "مجموعة رئيسية"
        GridView1.Columns(5).Caption = "مجموعة 1"
        GridView1.Columns(6).Caption = "الكمية"
        GridView1.Columns(7).Caption = "سعر الوحدة"
        GridView1.Columns(8).Caption = "الوحدة"
        GridView1.Columns(9).Caption = "القيمة"
        GridView1.Columns(10).Caption = "أسم العميل"
        GridView1.Columns(11).Caption = "أسم المخزن"


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub

    Private Sub Frm_ReportInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class