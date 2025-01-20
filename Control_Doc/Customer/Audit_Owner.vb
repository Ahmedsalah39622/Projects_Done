Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTreeList

Public Class Frm_Audit_Owner2
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub Frm_Audit_Owner2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Find_CustomerFill()

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


        sql2 = "SELECT dbo.St_CompnyInfo.Compny_Name, dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, SUM(dbo.MovmentStatement.Debit) AS SumDebit, SUM(dbo.MovmentStatement.Cridit) AS SumCridit, " & _
"                  ROUND(SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit), 2) AS Resalt " & _
" FROM     dbo.MovmentStatement INNER JOIN " & _
"                  dbo.FindCustomer ON dbo.MovmentStatement.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.FindCustomer.code INNER JOIN " & _
"                  dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
"                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.ST_CHARTOFACCOUNT.Level_No2 = ST_CHARTOFACCOUNT_1.Account_No AND  " & _
"                  dbo.ST_CHARTOFACCOUNT.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code LEFT OUTER JOIN " & _
"                  dbo.St_CompnyInfo ON dbo.MovmentStatement.Compny_Code = dbo.St_CompnyInfo.Compny_Code " & _
" WHERE  (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME,  '" & vardate2 & "', 102))  " & _
" GROUP BY dbo.MovmentStatement.AccountNo, dbo.FindCustomer.Name, ST_CHARTOFACCOUNT_1.AccountName, dbo.St_CompnyInfo.Compny_Name "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)
        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True
        GridView9.Columns(0).Caption = "الشركة"
        GridView9.Columns(1).Caption = "رقم الحساب  "
        GridView9.Columns(2).Caption = "أسم الحساب"
        GridView9.Columns(3).Caption = "مدين"
        GridView9.Columns(4).Caption = "دائن"
        GridView9.Columns(5).Caption = "رصيد"

        GridView9.BestFitColumns()
        GridView9.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView9.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView9.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView9.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


   

    Sub Find_TotalInvoice()

        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()

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



        sql2 = "  SELECT         dbo.St_CompnyInfo.Compny_Name, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAccount, round(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item),2)  " & _
  "                         AS TotalInvoice, dbo.TB_Header_InvoiceSal.tax_n, round(SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * dbo.TB_Header_InvoiceSal.tax_n / 100,2) AS Tax,round( SUM(dbo.TB_Detalis_InvoiceSal.Total_Item)  " & _
  "                         + SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) * dbo.TB_Header_InvoiceSal.tax_n / 100,2) AS totalInv, RTRIM(dbo.St_CustomerData.Customer_NoReg_Tax) AS Reg_customer, dbo.Emp_employees.Emp_Name,  " & _
  "                         dbo.BD_REGION.Name AS Region " & _
  " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
  "                         dbo.TB_Header_InvoiceSal ON dbo.ST_CHARTOFACCOUNT.Account_No = dbo.TB_Header_InvoiceSal.Customer_No AND  " & _
  "                         dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code INNER JOIN " & _
  "                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ser_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo AND  " & _
  "                         dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
  "                         dbo.St_CustomerData ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
  "                         dbo.TB_Header_InvoiceSal.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
  "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
  "                       dbo.St_CompnyInfo ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CompnyInfo.Compny_Code  LEFT OUTER JOIN   dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
  " WHERE       (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) AND (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
  "                         (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
  " GROUP BY  dbo.St_CompnyInfo.Compny_Name, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.tax_n, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.St_CustomerData.Customer_NoReg_Tax, " & _
  " dbo.Emp_employees.Emp_Name, dbo.BD_REGION.Name  "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)



        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.BestFitColumns()
        GridView3.Columns(0).Caption = "اسم الشركة"
        GridView3.Columns(1).Caption = "رقم الفاتورة"
        GridView3.Columns(2).Caption = "تاريخ الفاتورة"
        GridView3.Columns(3).Caption = "أسم العميل"
        GridView3.Columns(4).Caption = "إجمالى الفاتورة"
        GridView3.Columns(5).Caption = "نسبة الضريبة"
        GridView3.Columns(6).Caption = "قيمة الضريبة"
        GridView3.Columns(7).Caption = "صافى الفاتورة"
        GridView3.Columns(8).Caption = "رقم التسجيل الضريبى"
        GridView3.Columns(9).Caption = "مندوب البيع"
        GridView3.Columns(10).Caption = "المنطقة"

        GridView3.Columns(8).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView3.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Find_BlackList()




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " select * from Vw_BlackList"




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl_BlackList.DataSource = ds.Tables(0)

        GridView_BlackList.BestFitColumns()
        GridView_BlackList.Columns(0).Caption = "اسم الشركة"
        GridView_BlackList.Columns(1).Caption = "العميل"
        GridView_BlackList.Columns(2).Caption = "الرصيد"
        GridView_BlackList.Columns(3).Caption = "حالة العميل"
       



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView_BlackList.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
      


    End Sub

    Sub Find_limeiedCustomer()




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " select * from vw_LimetedCustomer"




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl_limited.DataSource = ds.Tables(0)

        GridView_limited.BestFitColumns()
        GridView_limited.Columns(0).Caption = "اسم الشركة"
        GridView_limited.Columns(1).Caption = "العميل"
        GridView_limited.Columns(2).Caption = "حد الائتمان"
        GridView_limited.Columns(3).Caption = "رصيد العميل"

        GridView_limited.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView_limited.Appearance.Row.Options.UseFont = True



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView_limited.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



    End Sub
    Sub All_Salase_data()
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



        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "     SELECT        Compny_Name, Order_NO, Order_Date, Emp_Name, Name, CountDay, Type, NameItem, item2, Unit, Quntity, ROUND(Price_Unit, 2) AS Price_Unit, status_stores, status_out, st,Order_Date_stores " & _
     " FROM            dbo.vw_all_salStatus2 " & _
     " WHERE        (Order_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) and   (Order_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "اسم الشركة"
        GridView1.Columns(1).Caption = "رقم الطلبية"
        GridView1.Columns(2).Caption = "تاريخ الطلبية"
        GridView1.Columns(3).Caption = "أسم المندوب"
        GridView1.Columns(4).Caption = "أسم العميل"
        GridView1.Columns(5).Caption = "مدة التوريد"
        GridView1.Columns(6).Caption = "نوع التوريد"
        GridView1.Columns(7).Caption = "اسم الصنف"
        GridView1.Columns(8).Caption = "اسم الصنف البديل"
        GridView1.Columns(9).Caption = "الوحدة"
        GridView1.Columns(10).Caption = "الكمية"
        GridView1.Columns(11).Caption = "السعر"
        GridView1.Columns(12).Caption = "حالة المخزن"
        GridView1.Columns(13).Caption = "حالة الامن"
        GridView1.Columns(14).Caption = "حالة الفاتورة"
        GridView1.Columns(15).Caption = "تاريخ الاستلام"


        GridView1.Columns(8).Visible = False
        GridView1.Columns(5).Visible = False
        GridView1.Columns(6).Visible = False

        GridView1.BestFitColumns()


  

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub


    Sub All_group_Item()
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



        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " SELECT        dbo.St_CompnyInfo.Compny_Name, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.BD_Item.Code, " & _
"                         RTRIM(dbo.TB_Detils_AznItem_Stores.Item_Discription) AS Item, dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.BD_Unit.Name AS Unit, dbo.TB_Detalis_InvoiceSal.Quntity, dbo.TB_Detalis_InvoiceSal.Price_Item,  " & _
"        dbo.TB_Detalis_InvoiceSal.Total_Item" & _
" FROM            dbo.TB_Header_InvoiceSal INNER JOIN " & _
"                         dbo.TB_Detalis_InvoiceSal ON dbo.TB_Header_InvoiceSal.Ser_InvoiceNo = dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo AND  " & _
"                         dbo.TB_Header_InvoiceSal.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code INNER JOIN " & _
"                         dbo.St_CompnyInfo ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.St_CompnyInfo.Compny_Code INNER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_InvoiceSal.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.FindCustomer.Compny_Code INNER JOIN " & _
"                         dbo.BD_Item ON dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
"                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detalis_InvoiceSal.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
"                         dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detalis_InvoiceSal.Order_Stores_No = dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AND  " & _
"        dbo.TB_Detalis_InvoiceSal.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item And dbo.BD_Item.Code = dbo.TB_Detils_AznItem_Stores.No_Item " & _
" WHERE        (dbo.TB_Header_InvoiceSal.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoiceSal.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView13.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView13.Appearance.Row.Options.UseFont = True


        GridView13.Columns(0).Caption = "اسم الشركة"
        GridView13.Columns(1).Caption = "رقم الفاتورة"
        GridView13.Columns(2).Caption = "تاريخ الفاتورة"
        GridView13.Columns(3).Caption = "أسم العميل"
        GridView13.Columns(4).Caption = "كود الصنف"
        GridView13.Columns(5).Caption = "اسم الصنف"
        GridView13.Columns(6).Caption = "المجموعة"
        GridView13.Columns(7).Caption = "الوحدة"
        GridView13.Columns(8).Caption = "الكمية"
        GridView13.Columns(9).Caption = "السعر"
        GridView13.Columns(10).Caption = "الاجمالى"



        GridView13.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView13.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub


    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        For x As Integer = 0 To GridView1.RowCount



            Dim ststus_Stores As String
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            'حركة البيع
            '=======================================================================
            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(12))
            If ststus_Stores = "مستلم" Then
                If e.Column.AbsoluteIndex = 12 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.SkyBlue
                End If
            Else
                If e.Column.AbsoluteIndex = 12 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Gray
                End If
            End If
            '======================================================================================

            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(13))
            If ststus_Stores = "تم الخروج" Then
                If e.Column.AbsoluteIndex = 13 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.GreenYellow
                End If
            Else
                If e.Column.AbsoluteIndex = 13 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.White
                End If
            End If
            '==============================================================

            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(14))
            If ststus_Stores = "تم الحفظ" Then
                If e.Column.AbsoluteIndex = 14 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Green
                End If
            Else
                If e.Column.AbsoluteIndex = 14 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        Next x





    End Sub

    Private Sub NavBarItem1_LinkClicked1(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        'Find_Customer_sal()
        All_Salase_data() 'متابعة حركة البيع
        All_group_Item() 'مبيعات الاصناف
        Find_TotalInvoice() 'مبيعات اليوم
        Find_BlackList() 'المتوقفين
        Find_limeiedCustomer() 'حد الائتمان
        Find_CustomerFill()
        GridView1.BestFitColumns()
        GridView13.BestFitColumns()
        GridView3.BestFitColumns()
        GridView9.BestFitColumns()
        GridView_BlackList.BestFitColumns()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub GridView13_RowCellStyle(sender As Object, e As RowCellStyleEventArgs)

        '===============================================================مبيعات الاصناف

        For y As Integer = 0 To GridView13.RowCount



            Dim nameCompny As String
            Dim visibleRowHandle As Integer = GridView13.FocusedRowHandle

            'مبيعات الاصناف
            '=======================================================================
            nameCompny = GridView13.GetRowCellValue(y, GridView13.Columns(0))
            If nameCompny = "ماستر باك للتوكيلات التجارية " Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.SkyBlue
                End If

            ElseIf nameCompny = "انترناشيونال باك لانظمة التغليف والتجارة الدولية" Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.SkyBlue
                End If


            Else
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.Silver
                End If
            End If

        Next y
    End Sub

   

    Private Sub GridView_BlackList_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView_BlackList.RowCellStyle
        '===============================================================مبيعات الاصناف

        For y As Integer = 0 To GridView13.RowCount



            Dim nameCompny, Status_Customer As String
            Dim visibleRowHandle As Integer = GridView_BlackList.FocusedRowHandle

            'متوقف
            '=======================================================================
            nameCompny = GridView_BlackList.GetRowCellValue(y, GridView_BlackList.Columns(0))
            If nameCompny = "ماستر باك للتوكيلات التجارية " Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.SkyBlue
                End If

            ElseIf nameCompny = "انترناشيونال باك لانظمة التغليف والتجارة الدولية" Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.LightBlue
                End If


            Else
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.Silver
                End If
            End If



            'الحالة
            '=======================================================================

            Status_Customer = GridView_BlackList.GetRowCellValue(y, GridView_BlackList.Columns(3))
            If Status_Customer = "سارى" Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.Gold
                End If

            ElseIf Status_Customer = "متوقف" Then
                If e.Column.AbsoluteIndex = 0 AndAlso e.RowHandle = y Then
                    e.Appearance.BackColor = Color.LightBlue
                End If


            Else
               
            End If



        Next y
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class