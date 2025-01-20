Imports System.Globalization
Imports System.Data.OleDb

Public Class Frm_newMune2

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        ''Frm_DataCustomer2.Show()
        'Frm_DataCustomer2.Close()
        'Frm_DataCustomer2.Show()
        ''Frm_DataCustomer2.MdiParent = Me

        Frm_Cust.Close()
        Frm_Cust.MdiParent = Mainmune
        Frm_Cust.Show()
    End Sub

    Private Sub Frm_newMune2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_cash()
        find_salse()
        find_Exp()
        find_Dof()
        '========================
        All_invoice()
        All_Exp()
        All_Deposit()
        All_Salase_data()
    End Sub
    Sub All_invoice()
       
        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()




        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

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
               " WHERE        (dbo.Vw_DetilsInvoice.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_InvoiceSal.InvoiceDate = CONVERT(DATETIME, '" & vardateoder & "', 102)) AND (dbo.TB_Header_InvoiceSal.Invoice_Status = 1) " & _
               " GROUP BY dbo.Vw_DetilsInvoice.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.FindCustomer.Name, dbo.Vw_DetilsInvoice.No_Item, dbo.Vw_DetilsInvoice.Name, dbo.Vw_DetilsInvoice.Quntity,  " & _
               "        dbo.Vw_DetilsInvoice.Unit, dbo.Vw_DetilsInvoice.Price_Item, dbo.Vw_DetilsInvoice.Value_Discount, dbo.Vw_DetilsInvoice.Total_Item, dbo.Vw_DetilsInvoice.Name_Cru, dbo.TB_Header_InvoiceSal.tax_n "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
       
        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns(0).Caption = "رقم الفاتورة"
        GridView3.Columns(1).Caption = "تاريخ الفاتورة "
        GridView3.Columns(2).Caption = "أسم العميل"
        GridView3.Columns(3).Caption = "رقم الصنف"
        GridView3.Columns(4).Caption = "أسم الصنف"
        GridView3.Columns(5).Caption = "الوحدة"
        GridView3.Columns(6).Caption = "الكمية"
        GridView3.Columns(7).Caption = "السعر"
        GridView3.Columns(8).Caption = "العملة"
        GridView3.Columns(9).Caption = "الخصم"
        GridView3.Columns(10).Caption = "الاجمالى"
        GridView3.Columns(11).Caption = "الضريبة"
        GridView3.Columns(12).Caption = "الصافى"

        GridView3.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView3.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub


    Sub All_Exp()

        GridControl6.DataSource = Nothing
        GridView11.Columns.Clear()


        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "SELECT        dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.MovmentStatement.AccountNo, rtrim(dbo.ST_CHARTOFACCOUNT.AccountName) as Acc, SUM(dbo.MovmentStatement.Debit) AS Debit2,  " & _
            "                         dbo.MovmentStatement.Discription  " & _
            " FROM            dbo.MovmentStatement INNER JOIN  " & _
            "                         dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No  " & _
            " WHERE        (dbo.MovmentStatement.Compny_Code = '" & VarCodeCompny & "') AND (dbo.MovmentStatement.TypeBill = 4) AND (dbo.MovmentStatement.DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102))  " & _
            " GROUP BY dbo.MovmentStatement.AccountNo, dbo.MovmentStatement.Discription, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM  " & _
            "        HAVING(SUM(dbo.MovmentStatement.Debit) <> 0) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)

        GridView11.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView11.Appearance.Row.Options.UseFont = True
        GridView11.Columns(0).Caption = "رقم السند"
        GridView11.Columns(1).Caption = "تاريخ السند "
        GridView11.Columns(2).Caption = "رقم الحساب"
        GridView11.Columns(3).Caption = "أسم الحساب"
        GridView11.Columns(4).Caption = "المبلغ"
        GridView11.Columns(5).Caption = "البيان"
    

        GridView11.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView11.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub All_Deposit()

        GridControl5.DataSource = Nothing
        GridView9.Columns.Clear()


        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = " SELECT        dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.MovmentStatement.AccountNo, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS aa, dbo.MovmentStatement.Cridit,  " & _
 "                         dbo.MovmentStatement.Discription, dbo.Emp_employees.Emp_Name " & _
 " FROM            dbo.MovmentStatement INNER JOIN " & _
 "                         dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
 "                         dbo.TB_Receipt ON dbo.MovmentStatement.Compny_Code = dbo.TB_Receipt.Compny_Code AND dbo.MovmentStatement.NumberBill = dbo.TB_Receipt.Receipt_No INNER JOIN " & _
 "                         dbo.Emp_employees ON dbo.TB_Receipt.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code " & _
 " WHERE        (dbo.MovmentStatement.Compny_Code = '" & VarCodeCompny & "') AND (dbo.MovmentStatement.TypeBill = 3) AND (dbo.MovmentStatement.DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102)) " & _
 " GROUP BY dbo.MovmentStatement.AccountNo, dbo.MovmentStatement.Discription, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM,  " & _
 "        dbo.Emp_employees.Emp_Name, dbo.MovmentStatement.Cridit " & _
 "        HAVING(dbo.MovmentStatement.Cridit <> 0) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True
        GridView9.Columns(0).Caption = "رقم السند"
        GridView9.Columns(1).Caption = "تاريخ السند "
        GridView9.Columns(2).Caption = "رقم الحساب"
        GridView9.Columns(3).Caption = "أسم الحساب"
        GridView9.Columns(4).Caption = "المبلغ"
        GridView9.Columns(5).Caption = "البيان"
        GridView9.Columns(6).Caption = "القائم بالتحصيل"


        GridView9.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView9.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub All_Salase_data()

        GridControl7.DataSource = Nothing
        GridView13.Columns.Clear()


        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "  SELECT        dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Code_Salse, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Receipt_Value, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName)  " & _
        "                   AS accname, iif(dbo.TB_Receipt.TypePay=0 ,'دفعة مقدمة','فاتورة') as aa, dbo.TB_Receipt.Invoice_No, dbo.BD_REGION.Name " & _
          " FROM            dbo.TB_Receipt INNER JOIN " & _
          "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
          "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
          "                         dbo.St_CustomerData ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
          "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.St_CustomerData.Customer_AccountNo LEFT OUTER JOIN " & _
          "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
          "        WHERE(dbo.TB_Receipt.Compny_Code =  '" & VarCodeCompny & "')   AND (dbo.TB_Receipt.Receipt_Date = CONVERT(DATETIME, '" & vardateoder & "', 102))"





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl7.DataSource = ds.Tables(0)

        GridView13.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView13.Appearance.Row.Options.UseFont = True
        GridView13.Columns(0).Caption = "رقم السند"
        GridView13.Columns(1).Caption = "تاريخ السند "
        GridView13.Columns(2).Caption = "رقم المندوب"
        GridView13.Columns(3).Caption = "أسم المندوب"
        GridView13.Columns(4).Caption = "مبلغ التحصيل"
        GridView13.Columns(5).Caption = "اسم العميل"
        GridView13.Columns(6).Caption = "نوع التحصيل"
        GridView13.Columns(7).Caption = "رقم الفاتورة"
        GridView13.Columns(8).Caption = "المنطقة"


        GridView13.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView13.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub find_cash()
        On Error Resume Next
        Lab_Cash.Text = "0"

        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")


        sql = "  SELECT        dbo.St_SetupBox.Account_No, SUM(dbo.MovmentStatement.Debit) AS SumD, SUM(dbo.MovmentStatement.Cridit) AS SumC, SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit) AS Balance,  " & _
        "                         dbo.ST_CHARTOFACCOUNT.AccountName " & _
        " FROM            dbo.St_SetupBox INNER JOIN " & _
        "                         dbo.MovmentStatement ON dbo.St_SetupBox.Account_No = dbo.MovmentStatement.AccountNo AND dbo.St_SetupBox.Compny_Code = dbo.MovmentStatement.Compny_Code INNER JOIN " & _
        "                         dbo.ST_CHARTOFACCOUNT ON dbo.St_SetupBox.Account_No = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.St_SetupBox.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
        " WHERE        (dbo.MovmentStatement.DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102)) AND (dbo.St_SetupBox.Compny_Code = '" & VarCodeCompny & "') " & _
        " GROUP BY dbo.St_SetupBox.Account_No, dbo.ST_CHARTOFACCOUNT.AccountName "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Lab_Cash.Text = FormatCurrency(rs("Balance").Value) Else Lab_Cash.Text = "0"

    End Sub
    Sub find_salse()
        On Error Resume Next
        Lab_Sal.Text = "0"
        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "  SELECT        SUM(Debit) AS SumSal       FROM dbo.MovmentStatement " & _
                " WHERE        (TypeBill = 2) AND (Compny_Code = '" & VarCodeCompny & "') AND (DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102))"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Lab_Sal.Text = FormatCurrency(rs("SumSal").Value) Else Lab_Sal.Text = "0"


    End Sub
    Sub find_Exp()
        On Error Resume Next
        Lab_Exp.Text = "0"

        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = " SELECT        SUM(Cridit_EGP) AS SumExp FROM            dbo.MovmentStatement " & _
                " WHERE        (TypeBill = 4) AND (Compny_Code = '" & VarCodeCompny & "') AND (DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102))"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Lab_Exp.Text = FormatCurrency(rs("SumExp").Value) Else Lab_Exp.Text = "0"


    End Sub
    Sub find_Dof()
        On Error Resume Next
        Lab_Dof.Text = "0"

        Dim dd As DateTime = DateTime.Now.ToString("yyyy/MM/dd")
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = " SELECT        SUM(Debit_EGP) AS SumDof FROM            dbo.MovmentStatement " & _
                " WHERE        (TypeBill = 3) AND (Compny_Code = '" & VarCodeCompny & "') AND (DateMoveM = CONVERT(DATETIME, '" & vardateoder & "', 102))"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Lab_Dof.Text = FormatCurrency(rs("SumDof").Value) Else Lab_Dof.Text = "0"


    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Frm_dataitem2.Close()
        Frm_dataitem2.MdiParent = Mainmune
        Frm_dataitem2.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Frm_suppliersInfo.Close()
        Frm_suppliersInfo.MdiParent = Mainmune
        Frm_suppliersInfo.Show()

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        vartable = "BD_Stores"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.MdiParent = Mainmune
        Frm_GenralData.Text = "أكواد المخازن"
        Frm_GenralData.Show()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Frm_ChartOfAccount.Close()
        Frm_ChartOfAccount.MdiParent = Mainmune
        Frm_ChartOfAccount.Show()


    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Frm_delegatesInfo.Close()
        Frm_delegatesInfo.MdiParent = Mainmune
        Frm_delegatesInfo.Show()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Frm_SalseInvoice.Close()
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()

    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Frm_Prcheses_Invoice.Close()
        Frm_Prcheses_Invoice.MdiParent = Mainmune
        Frm_Prcheses_Invoice.Show()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        Frm_ReportCustomer.Close()

        Frm_ReportCustomer.MdiParent = Mainmune
        Frm_ReportCustomer.LabelX1.Text = "مديونية العملاء خلال فترة"
        Frm_ReportCustomer.Find_CustomerFill()
        vardisplayReport = 0
        Frm_ReportCustomer.Show()
        Mainmune.NavBarControl2.Visible = False
    End Sub

   
    Private Sub Cmd_Stores_Click(sender As Object, e As EventArgs) Handles Cmd_Stores.Click
        Frm_AccountStatement.Close()
        Frm_AccountStatement.MdiParent = Mainmune
        Frm_AccountStatement.Show()
      

    End Sub

   
    Private Sub Cmd_Print1_Click(sender As Object, e As EventArgs) Handles Cmd_Print1.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView3.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle

            sql2 = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name" & _
                " ,code_Item,NameItem,Unit,Qty,Price,TotalInvoice,Txt_invoice,TotalAll_Invoice) " & _
                " values ('" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(0))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(1))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(2))) & "' " & _
                " ,'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(3))) & "', '" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(4))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(5))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(6))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(7))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(10))) & "' ,'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(11))) & "' ,'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(12))) & "'    ) "

            rs2 = Cnn.Execute(sql2)


        Next rowHandle
        vardisplayReport2 = 0
        Frm_Report_StatusAcc.Show()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView9.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle

            sql2 = "insert into TB_TempReport1  (Invoice_No,Date_Invoice,Customer_Name" & _
                " ,TotalInvoice,Discrption,NameEmp) " & _
                " values ('" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(0))) & "','" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(1))) & "','" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(3))) & "' " & _
                " ,'" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(4))) & "', '" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(5))) & "','" & Trim(GridView9.GetRowCellValue(rowHandle, GridView9.Columns(6))) & "') "

            rs2 = Cnn.Execute(sql2)


        Next rowHandle
        vardisplayReport2 = 1
        Frm_Report_StatusAcc.Show()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
   
        frm_SaleReport.Close()
        frm_SaleReport.MdiParent = Mainmune
        frm_SaleReport.Show()
    End Sub
End Class