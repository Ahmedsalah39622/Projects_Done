Imports System.Data.OleDb

Public Class frm_ReportProduction
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        Find_Jop_Fill()
    End Sub


    Sub Find_Jop_Fill()

        GridControl3.DataSource = Nothing
        GridView6.Columns.Clear()

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


        sql2 = "    SELECT        TOP (100) PERCENT dbo.TB_Header_JOB_Order.Order_NO, dbo.vw_AllJopOrderDatastatus.JOB_Order, dbo.vw_AllJopOrderDatastatus.JOBOrder_Date, dbo.TB_Header_OrderItem.NameCustomer_Compny, " & _
    "                         dbo.BD_Item.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid2, dbo.BD_Unit.Name AS Unit1, dbo.TB_Header_JOB_Order.Qyt_Requrid, BD_Unit_1.Name AS Unit2, dbo.vw_AllJopOrderDatastatus.Machin, " & _
    "                         dbo.vw_AllJopOrderDatastatus.NameItemFirst, dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_2.Name AS Unit3, dbo.vw_AllJopOrderDatastatus.statusJopOrder, " & _
    "        dbo.vw_AllJopOrderDatastatus.status, dbo.vw_AllJopOrderDatastatus.StoresStatus, dbo.vw_AllJopOrderDatastatus.PhasesName " & _
    " FROM            dbo.vw_AllJopOrderDatastatus INNER JOIN " & _
    "                         dbo.TB_Header_JOB_Order ON dbo.vw_AllJopOrderDatastatus.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order INNER JOIN " & _
    "                         dbo.BD_Item ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code INNER JOIN " & _
    "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_JOB_Order.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
    "                         dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit2 = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code INNER JOIN " & _
    "                         dbo.BD_Unit AS BD_Unit_2 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_2.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_2.Compny_Code " & _
    " GROUP BY dbo.TB_Header_JOB_Order.Order_NO, dbo.vw_AllJopOrderDatastatus.JOB_Order, dbo.vw_AllJopOrderDatastatus.JOBOrder_Date, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.BD_Item.Name,  " & _
    "        dbo.TB_Header_JOB_Order.Qyt_Requrid2, dbo.BD_Unit.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid, BD_Unit_1.Name, dbo.vw_AllJopOrderDatastatus.Machin, dbo.vw_AllJopOrderDatastatus.NameItemFirst, " & _
    "        dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_2.Name, dbo.vw_AllJopOrderDatastatus.statusJopOrder, dbo.vw_AllJopOrderDatastatus.status, " & _
    "        dbo.vw_AllJopOrderDatastatus.StoresStatus, dbo.vw_AllJopOrderDatastatus.PhasesName " & _
    " HAVING        (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
    " ORDER BY dbo.vw_AllJopOrderDatastatus.JOBOrder_Date "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "أمر التوريد"
        GridView6.Columns(1).Caption = "أمر الشغل "
        GridView6.Columns(2).Caption = "تاريخ امر الشغل"
        GridView6.Columns(3).Caption = "العميل"
        GridView6.Columns(4).Caption = "اسم الصنف المطلوب"
        GridView6.Columns(5).Caption = "الكمية المطلوبة"
        GridView6.Columns(6).Caption = "الوحدة"
        GridView6.Columns(7).Caption = "الكمية المنتجة"
        GridView6.Columns(8).Caption = "الوحدة"
        GridView6.Columns(9).Caption = "الماكينة"
        GridView6.Columns(10).Caption = "اسم الصنف المنتج"
        GridView6.Columns(11).Caption = "الكمية "

        GridView6.Columns(14).Caption = "حالة امر الشغل"
        GridView6.Columns(15).Caption = "الفحص "
        GridView6.Columns(16).Caption = "المخزن "
        GridView6.Columns(17).Caption = "مرحلة الانتاج"


        GridView6.Columns(11).Visible = False
        GridView6.Columns(12).Visible = False


        GridView6.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        'GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub Find_Machin()

        GridControl5.DataSource = Nothing
        GridView9.Columns.Clear()

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


        sql2 = "SELECT        TOP (100) PERCENT dbo.vw_AllJopOrderDatastatus.Machin, dbo.BD_Item.Name, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_2.Name AS Unit3, dbo.vw_AllJopOrderDatastatus.PhasesName, " & _
        "                         dbo.Emp_employees.Emp_Name, dbo.Vw_Shift.Name AS Expr1 " & _
        "FROM            dbo.vw_AllJopOrderDatastatus INNER JOIN " & _
        "                         dbo.TB_Header_JOB_Order ON dbo.vw_AllJopOrderDatastatus.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order INNER JOIN " & _
        "                         dbo.BD_Item ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code INNER JOIN " & _
        "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_JOB_Order.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
        "                         dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit2 = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code INNER JOIN " & _
        "                         dbo.BD_Unit AS BD_Unit_2 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_2.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 = BD_Unit_2.Code INNER JOIN " & _
        "                         dbo.Emp_employees ON dbo.TB_Header_JOB_Order.Code_Emp = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.Emp_employees.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.Vw_Shift ON dbo.TB_Header_JOB_Order.Shift_No = dbo.Vw_Shift.code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.Vw_Shift.Compny_Code " & _
        " WHERE        (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date >= CONVERT(DATETIME,'" & vardate & "', 102)) AND (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
        " GROUP BY dbo.BD_Item.Name, dbo.vw_AllJopOrderDatastatus.Machin, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_2.Name, dbo.vw_AllJopOrderDatastatus.PhasesName, dbo.Emp_employees.Emp_Name, " & _
        "        dbo.Vw_Shift.Name "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "الماكينة"
        GridView9.Columns(1).Caption = "الصنف"
        GridView9.Columns(2).Caption = "الكمية المنتجة"
        GridView9.Columns(3).Caption = "الوحدة"
        GridView9.Columns(4).Caption = "المرحلة"
        GridView9.Columns(5).Caption = "اسم العامل"
        GridView9.Columns(6).Caption = "الورية"

        GridView9.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView9.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub Find_Day()

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

        sql2 = "  SELECT        dbo.TB_Header_JOB_Order.JOBOrder_Date, dbo.TB_MachineName.Name AS Machine, dbo.Vw_Shift.Name AS Shift, dbo.Emp_employees.Emp_Name, Emp_employees_1.Emp_Name AS Emp_Name2,  " & _
    "                         dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_HalekData.Qty_H, ROUND(dbo.TB_HalekData.Qty_H * 100 / dbo.TB_Header_JOB_Order.Qyt_FristItem2, 2) AS n_Halek,dbo.TB_HalekData.Notes " & _
    " FROM            dbo.TB_MachineName INNER JOIN " & _
   "                      dbo.TB_Detils_JOB_Order INNER JOIN " & _
   "                      dbo.TB_Header_JOB_Order ON dbo.TB_Detils_JOB_Order.JOB_Order_Ser = dbo.TB_Header_JOB_Order.JOB_Order_Ser AND  " & _
   "                      dbo.TB_Detils_JOB_Order.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
   "                      dbo.Emp_employees ON dbo.TB_Header_JOB_Order.Code_Emp = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
   "                      dbo.Vw_Shift ON dbo.TB_Header_JOB_Order.Shift_No = dbo.Vw_Shift.code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.Vw_Shift.Compny_Code INNER JOIN " & _
   "                      dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 = dbo.BD_Unit.Code ON  " & _
   "                      dbo.TB_MachineName.Code = dbo.TB_Header_JOB_Order.Machine_No AND dbo.TB_MachineName.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code LEFT OUTER JOIN " & _
    "                     dbo.BD_Unit AS BD_Unit_1 INNER JOIN " & _
    "                     dbo.TB_HalekData ON BD_Unit_1.Code = dbo.TB_HalekData.Code_Unit AND BD_Unit_1.Compny_Code = dbo.TB_HalekData.Compny_Code ON  " & _
    "    dbo.TB_Header_JOB_Order.JOBOrder_Date = dbo.TB_HalekData.Date_Halek And dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_HalekData.Compny_Code And " & _
    "                     dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_HalekData.Machine_No AND dbo.Vw_Shift.code = dbo.TB_HalekData.Shift_No LEFT OUTER JOIN " & _
    "                     dbo.Emp_employees AS Emp_employees_1 ON dbo.TB_Header_JOB_Order.Code_Emp2 = Emp_employees_1.Emp_Code AND  " & _
   "     dbo.TB_Header_JOB_Order.Compny_Code = Emp_employees_1.Compny_Code " & _
" GROUP BY dbo.TB_Header_JOB_Order.JOBOrder_Date, dbo.TB_MachineName.Name, dbo.Vw_Shift.Name, dbo.Emp_employees.Emp_Name, Emp_employees_1.Emp_Name, dbo.TB_Header_JOB_Order.Qyt_FristItem2, " & _
"        dbo.TB_HalekData.Qty_H, dbo.TB_HalekData.Qty_H * 100 / dbo.TB_Header_JOB_Order.Qyt_FristItem2,dbo.TB_HalekData.Notes " & _
" HAVING        (dbo.TB_Header_JOB_Order.JOBOrder_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) and  (dbo.TB_Header_JOB_Order.JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "التاريخ"
        GridView1.Columns(1).Caption = "الماكينة"
        GridView1.Columns(2).Caption = "الوردية"
        GridView1.Columns(3).Caption = "الفنى"
        GridView1.Columns(4).Caption = "العامل"
        GridView1.Columns(5).Caption = "الكمية المنتجة"
        GridView1.Columns(6).Caption = "الهالك"
        GridView1.Columns(7).Caption = "نسبة الهالك %"
        GridView1.Columns(8).Caption = "ملاحظات"

        GridView1.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub Find_Halak()

        GridControl8.DataSource = Nothing
        GridView15.Columns.Clear()

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


        sql2 = "   SELECT        TOP (100) PERCENT dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_MachineName.Name, SUM(dbo.TB_Detils_AznAddItem.Qyt2) AS Tot, dbo.BD_Unit.Name AS Unit, dbo.BD_Item.Name AS Nameitem,  " & _
"                         dbo.TB_Detils_AznAddItem.No_item " & _
" FROM            dbo.TB_Header_AznAddItem INNER JOIN " & _
"                         dbo.TB_MachineName ON dbo.TB_Header_AznAddItem.Code_Machin = dbo.TB_MachineName.Code AND dbo.TB_Header_AznAddItem.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN " & _
"                         dbo.TB_Detils_AznAddItem ON dbo.TB_Header_AznAddItem.Compny_Code = dbo.TB_Detils_AznAddItem.Compny_Code AND  " & _
"                         dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd = dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit2 = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
"                         dbo.BD_Item ON dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code " & _
" GROUP BY dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_MachineName.Name, dbo.BD_Unit.Name, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.No_item " & _
" HAVING        (dbo.TB_Header_AznAddItem.Date_StoresAdd >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_AznAddItem.Date_StoresAdd <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "






        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl8.DataSource = ds.Tables(0)

        GridView15.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView15.Appearance.Row.Options.UseFont = True

        GridView15.Columns(0).Caption = "التاريخ"
        GridView15.Columns(1).Caption = "الماكينة"
        GridView15.Columns(2).Caption = "الكمية الهالك"
        GridView15.Columns(3).Caption = "الوحدة"
        GridView15.Columns(4).Caption = "اسم الصنف"
        GridView15.Columns(5).Caption = "رقم الصنف"

        GridView15.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView15.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


    End Sub

    Private Sub frm_ReportProduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Jop_Fill()
        GridView6.BestFitColumns()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Find_Machin()
        GridView9.BestFitColumns()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Find_Day()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        Find_Halak()
        GridView15.BestFitColumns()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Dim var4, var5, var6, var7, var8 As String

            var4 = ""
            var5 = ""
            var6 = ""
            var7 = ""
            var8 = ""

            var4 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))))

            var5 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))))
            var6 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))))
            var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))


            sql = "insert into TB_TempReport1  (Date_M,MachineName,Cur" & _
                " ,NameEmp,NameDeprt,Qty,Qty2_halk,N_halk,Discrption) " & _
                " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', '" & var4 & "','" & var5 & "','" & var6 & "' ,'" & var7 & "' ,'" & var8 & "' ) "
            Cnn.Execute(sql)


        Next rowHandle
        Frm_ReportProdact.Show()
    End Sub
End Class