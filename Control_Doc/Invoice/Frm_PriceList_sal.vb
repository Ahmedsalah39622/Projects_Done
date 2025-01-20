Imports System.Data.OleDb

Public Class Frm_PriceList_sal
    Public sizeItem As Double

    Dim varcodeitem, varID As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim oldDate As Date
    Dim oldDay, VarTax As Integer
    Dim xx As String
    Dim VarItem_EX, VarStutas As String
    Dim x As String
    Dim vartaxinvoice, vartaxitem As Single

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs) Handles cmd_FindItem.Click
        If IsDate(txt_date.Value) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم عرض السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Type.Text) = 0 Then MsgBox("من  فضلك ادخل نوع العرض ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_salesNo.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_nameaccount.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub





        If Com_InvoiceNo.Text = "" Then
            MsgBox("من فضلك أدخل رقم عرض السعر", MsgBoxStyle.Critical, "Css")
            Exit Sub
        Else
            varNoInvoice = Com_InvoiceNo.Text
            varNoInvoice3 = Com_InvoiceNo2.Text
            'varopenItemSuppliser = 2
            'Frm_LookupItemPrcheses.ShowDialog()


            varcode_form = 25702
            'VARTBNAME = " Vw_AllDataItem"
            Lookupitem.Fill_Alldata()
            Lookupitem.ShowDialog()
        End If


    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs) Handles txt_nameaccount.TextChanged
        sql = "  SELECT        Name, Code      FROM dbo.FindCustomer WHERE        (Name = '" & txt_nameaccount.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_AccountNo.Text = rs("code").Value Else txt_AccountNo.Text = ""
    End Sub

    Private Sub txt_NameSalse_TextChanged(sender As Object, e As EventArgs) Handles txt_NameSalse.TextChanged
        sql = "    SELECT        Emp_Name, Emp_Code   FROM dbo.Emp_employees WHERE        (Emp_Name = '" & txt_NameSalse.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_CodeSalse.Text = rs("Emp_Code").Value Else txt_CodeSalse.Text = ""

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear_detils()
        find_hedar()
        find_detalis()
        find_PriceList()
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code FROM            TB_Header_PriceListCustomer    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "PL000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "PL000" + "1"


        End If



    End Sub


    Sub Total_Sum()
        'find_tax()
        Dim total, total_dis, total_reusalt As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(8))
            total_dis += GridView6.GetRowCellValue(i, GridView6.Columns(9))
            total_reusalt += GridView6.GetRowCellValue(i, GridView6.Columns(11))

        Next
        txt_totalPrice.Text = Format(Math.Round(total, 2), "##,##0.00")
        txt_total_Dis.Text = Format(Math.Round(total_dis, 2), "##,##0.00")
        txt_total_Resualt.Text = Format(Math.Round(total_reusalt, 2), "##,##0.00")
    End Sub


    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_total_Dis.Text = ""
        txt_total_Resualt.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        'Com_NoAzn.Text = ""
        Txt_Discount.Text = ""
        txt_valuediscount.Text = ""
        Txt_Total.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_CodeSalse.Text = ""
        txt_NameSalse.Text = ""
        com_Cru.Text = ""
        txt_rat.Text = ""
        Com_Type.Text = ""
        'txt_SalseOrder.Text = ""
        txt_salesNo.Text = ""
        txt_sales.Text = ""
        varcode_project = 0
        chekPrice.Enabled = True

        txt_Price.Text = ""

        'Txt_TotalAll.Text = ""
        txt_totalPrice.Text = ""
        'txt_Ntax.Text = ""
        'txt_Tax.Text = ""
        'txt_date.Text = ""
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        'txt_date.Text = Format(Now, "DD/mm/yyyy")
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click


        save_invoice()

        chekPrice.Enabled = False

    End Sub
    Sub save_invoice()

        If Trim(Com_InvoiceNo.Text) = "" Then Exit Sub
        sql2 = "select * from TB_Header_PriceListCustomer where Ser_InvoiceNo  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            'last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم عرض السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Type.Text) = 0 Then MsgBox("من  فضلك ادخل نوع الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_salesNo.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_sales.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_nameaccount.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Invoice_H()
        find_PriceList()
    End Sub


    Sub find_size()
        sql2 = "SELECT        Code, Kilo_Item FROM            dbo.BD_Item WHERE        (Code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then sizeItem = rs("Kilo_Item").Value Else sizeItem = 0.0

    End Sub

    Sub find_tax()
        sql2 = "select * from Tb_TaxInvoice where  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then VarAccountTax_Invoice = rs("Account_Tax").Value Else vartaxinvoice = "0"
    End Sub
    Sub save_Invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_PriceListCustomer where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else

            If op1.Checked = True Then VarTypePriceList = 0
            If op2.Checked = True Then VarTypePriceList = 1

            If chekPrice.Checked = True Then varflagTax = 0
            If chekPrice.Checked = False Then varflagTax = 1

            sql = "INSERT INTO TB_Header_PriceListCustomer (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes,type,flagtax,Code_Project) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_salesNo.Text & "','" & VarTypePriceList & "','" & 0 & "','" & txt_Notes.Text & "','" & Com_Type.Text & "','" & varflagTax & "','" & varcode_project & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        End If
        'Next
        'save_oderDetils()
        save_InvoiceDetils()
        'save_itemStores()
        clear_detils()
        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub


    Sub save_InvoiceDetils()

        find_varcode()


        sql = "  SELECT *    FROM TB_Detalis_PriceListCustomer where   No_Item ='" & txt_CodeItem.Text & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف مكرر على نفس عرض السعر من فضلك تاكد", MsgBoxStyle.Critical, "Css") : Exit Sub




        sql = "INSERT INTO TB_Detalis_PriceListCustomer (Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice,Code_Project,Sub_Project) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & varcodStores & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & varcode_Cru & "','" & txt_rat.Text & "','" & varcode_project & "','" & varcodeaccountSubProject & "')"
        Cnn.Execute(sql)



    End Sub

    
    Private Sub txt_Price_TextChanged(sender As Object, e As EventArgs) Handles txt_Price.TextChanged

        calcalator_invoice()
        If Txt_Discount.Text.Trim <> "" Or Txt_Discount.Text.Trim <> "0" Then
            Txt_Discount_TextChanged(Nothing, Nothing)
        End If

    End Sub
    Sub calcalator_invoice()
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single


        If sizeItem <> 0 Then
            varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_Price.Text) * Val(txt_rat.Text) * sizeItem, 2)
        Else
            varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_Price.Text) * Val(txt_rat.Text), 2)

        End If
        varDiscount = varTotalInvoice * Val(Txt_Discount) / 100

        Txt_Total.Text = varTotalInvoice - varDiscount
    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        find_invoice()
        chekPrice.Enabled = False
    End Sub
    Sub find_invoice()
        vartable = "Vw_LookupInvoiceSal4"
        VarOpenlookup = 2727002
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        find_hedar()
        find_detalis()
        find_Invoice_Condation()
        Total_Sum()
        sum_tax()
    End Sub

    Sub find_hedar()
        On Error Resume Next

        'sql2 = " SELECT dbo.TB_Header_PriceListCustomer.tax_n,dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo,dbo.TB_Header_PriceListCustomer.Ext_InvoiceNo,dbo.TB_Header_PriceListCustomer.InvoiceDate, " & _
        '" dbo.TB_Header_PriceListCustomer.Customer_No,dbo.TB_Header_PriceListCustomer.PayStatus,dbo.FindCustomer.Name,dbo.TB_Header_PriceListCustomer.Salse_No,  " & _
        '" dbo.TB_Header_PriceListCustomer.Notes,iif(dbo.TB_Header_PriceListCustomer.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status,dbo.TB_Header_PriceListCustomer.Invoice_Type,dbo.TB_Header_PriceListCustomer.type,dbo.TB_Header_PriceListCustomer.flagtax " & _
        '" FROM  dbo.TB_Header_PriceListCustomer LEFT OUTER JOIN " & _
        '"  dbo.FindCustomer ON dbo.TB_Header_PriceListCustomer.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.TB_Header_PriceListCustomer.Customer_No = dbo.FindCustomer.Code " & _
        '" WHERE (dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "') AND (dbo.TB_Header_PriceListCustomer.Compny_Code = '" & VarCodeCompny & "') "


        sql2 = " SELECT dbo.TB_Header_PriceListCustomer.tax_n, dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo, dbo.TB_Header_PriceListCustomer.Ext_InvoiceNo, dbo.TB_Header_PriceListCustomer.InvoiceDate, " & _
 "                  dbo.TB_Header_PriceListCustomer.Customer_No, dbo.TB_Header_PriceListCustomer.PayStatus, dbo.FindCustomer.Name, dbo.TB_Header_PriceListCustomer.Salse_No, dbo.TB_Header_PriceListCustomer.Notes, " & _
 "                  dbo.TB_Header_PriceListCustomer.Invoice_Type, dbo.TB_Header_PriceListCustomer.Type, dbo.TB_Header_PriceListCustomer.flagtax, dbo.ST_CHARTCOSTCENTER.AccountName AS NameProject " & _
 " FROM     dbo.TB_Header_PriceListCustomer LEFT OUTER JOIN " & _
 "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Header_PriceListCustomer.Code_Project = dbo.ST_CHARTCOSTCENTER.Account_No LEFT OUTER JOIN " & _
 "                  dbo.FindCustomer ON dbo.TB_Header_PriceListCustomer.Compny_Code = dbo.FindCustomer.Compny_Code AND dbo.TB_Header_PriceListCustomer.Customer_No = dbo.FindCustomer.code " & _
 " WHERE  (dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "') AND (dbo.TB_Header_PriceListCustomer.Compny_Code = '" & VarCodeCompny & "') "



        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs3("Ser_InvoiceNo").Value)
            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            Com_InvoiceNo3.Text = Trim(rs3("Ext_InvoiceNo").Value)
            'Com_InvoiceNo3.Text = Trim(rs3("Ext_InvoiceNo").Value)
            txt_date.Value = Trim(rs3("InvoiceDate").Value)
            'txt_Notes.Text = Trim(rs3("Notes").Value)
            'txt_CodeSalse.Text = Trim(rs3("Salse_No").Value)
            'txt_NameSalse.Text = Trim(rs3("Emp_Name").Value)
            txt_AccountNo.Text = Trim(rs3("Customer_No").Value)
            txt_salesNo.Text = Trim(rs3("Salse_No").Value)
            find_salseBySalCode(txt_salesNo.Text)
            txt_Notes.Text = Trim(rs3("Notes").Value)
            Com_Project.Text = Trim(rs3("NameProject").Value)

            txt_nameaccount.Text = Trim(rs3("Name").Value)
            Com_Type.Text = Trim(rs3("type").Value)

            If Trim(rs3("Invoice_Type").Value) = 0 Then op1.Checked = True
            If Trim(rs3("Invoice_Type").Value) = 1 Then op2.Checked = True



            If Trim(rs3("flagtax").Value) = 1 Then chekPrice.Checked = False
            If Trim(rs3("flagtax").Value) = 0 Then chekPrice.Checked = True

            'If txt_Typeinv.Text = "مرحل" Then Cmd_RtInvoice.Enabled = True : Cmd_CloseInvoice.Enabled = False : txt_Typeinv.BackColor = Color.Green
            'If txt_Typeinv.Text = "فاتورة مبدئية" Then Cmd_RtInvoice.Enabled = False : Cmd_CloseInvoice.Enabled = True : txt_Typeinv.BackColor = Color.Gray
            'txt_Ntax.Text = Trim(rs3("Tax_N").Value)
            'If rs3("PayStatus").Value = 0 Then Com_Condation.Text = "دفع 100 % عن الاستلام نقدا"
            'If rs3("PayStatus").Value = 1 Then Com_Condation.Text = "100 % بعد شهر"
            'If rs3("PayStatus").Value = 2 Then Com_Condation.Text = "100 % بعد شهرين"
            'If rs3("PayStatus").Value = 3 Then Com_Condation.Text = "100 % بعد 3 شهور"
            'If rs3("PayStatus").Value = 4 Then Com_Condation.Text = "50 % نقدا 50 % بعد شهر"
            find_project()

        End If

    End Sub


    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        No_Item, Ex_Item, Name, Quntity, Unit, price_u,Name_Cru,Rat_Invoice, TotalFinal,Discount_Item, Value_Discount, Total_Item,NameSubProject     FROM dbo.Vw_DetilsInvoice4" & _
            " where  (dbo.Vw_DetilsInvoice4.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') AND (dbo.Vw_DetilsInvoice4.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)



        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        'GridView6.Columns(5).Caption = "المخزن"
        GridView6.Columns(5).Caption = "سعر الوحدة"
        GridView6.Columns(6).Caption = "العملة"
        GridView6.Columns(7).Caption = "م التحويل"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "نسبة الخصم"
        GridView6.Columns(10).Caption = "قيمة الخصم"
        GridView6.Columns(11).Caption = "الاجمالى"
        GridView6.Columns(12).Caption = "فرع المشروع"
        'GridView6.Columns(13).Caption = "رقم الاذن"
        'GridView6.Columns(14).Caption = "رقم الطلبية"


        'GridView6.Columns(14).Visible = False
        'GridView6.Columns(13).Visible = False
        'GridView6.Columns(12).Visible = False
        'GridView6.Columns(5).Visible = False
        'GridView6.Columns(9).Visible = False
        'GridView6.Columns(10).Visible = False

        GridView6.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        'On Error Resume Next


    End Sub
    Sub sum_tax()
        'On Error Resume Next
        'Dim vartax As Single
        ''vartax = txt_Ntax.Text
        'txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)
        'Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text), 2)
    End Sub
    Sub find_salseBySalCode(code)
        sql = " SELECT        Emp_Name, Emp_Code " & _
            "   FROM dbo.Emp_employees " & _
        " WHERE        (Emp_Code = " & code & ")"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_salesNo.Text = rs("Emp_Code").Value : txt_sales.Text = rs("Emp_Name").Value

    End Sub


    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        com_Cru.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_Price.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Txt_Discount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        txt_valuediscount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))
        Txt_Total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        'txt_SalseOrder.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(14))
        'Com_NoAzn.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(13))

        If txt_CodeItem.Text <> "" Then cmd_Edit.Enabled = True
        If txt_CodeItem.Text <> "" Then Cmd_Delete.Enabled = True
        find_size()

    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Frm_OrderSal.Com_InvoiceNo2.Text = txt_SalseOrder.Text
        'Frm_OrderSal.find_hedar()
        'Frm_OrderSal.find_detalis()
        'Frm_OrderSal.MdiParent = Mainmune
        'Frm_OrderSal.Show()
    End Sub



    Sub saveGl()


    End Sub



    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_PrintInvoice.Click
        'Report_Invoice.Show()

        If chekPrice.Checked = True Then
            vartaxinvoice2 = Math.Round(Val(txt_totalPrice.Text) * 14 / 100, 2)
        Else
            vartaxinvoice2 = 0
        End If

        If CheckBox2.Checked = True Then vardisplayReport = 251
        If CheckBox1.Checked = True Then vardisplayReport = 2510
        If CheckEng.Checked = True Then vardisplayReport = 25100
        vartalinvoice = vartaxinvoice + Val(txt_totalPrice.Text)
        Print_Rented.Show()
    End Sub

    Private Sub Frm_SalseInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 1 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 0 'الصفحة التالية
        If e.KeyCode = Keys.F5 Then save_invoice() 'حفظ


        If e.KeyCode = Keys.F12 Then  'بحث
            find_invoice()
        End If

    End Sub

    Private Sub Frm_SalseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        last_Data()
        clear_detils()
        fill_cru()
        fill_Unit()
        fill_TypeInvoice()

        Com_Type.Items.Add("عام")
        'Com_Type.Items.Add("مواسير")
        find_PriceList()
    End Sub
    Sub find_PriceList()
        On Error Resume Next

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If Op5.Checked = True Then
            sql2 = "  SELECT        dbo.vw_PriceList_Activation.Ser_InvoiceNo, dbo.vw_PriceList_Activation.InvoiceDate, dbo.vw_PriceList_Activation.Customer_Name,  dbo.vw_PriceList_Activation.TotalPricelist, " & _
                       "   iif(dbo.vw_PriceList_Activation.flagtax = 0, 'شامل ضريبة', 'غير شامل ضريبة') AS tax, iif(dbo.Vw_FllowUp_OrderCustomer.Order_NO IS NULL, 'غير منفذة', 'منفذة') AS Activation " & _
"FROM            dbo.vw_PriceList_Activation LEFT OUTER JOIN" & _
                       "  dbo.Vw_FllowUp_OrderCustomer ON dbo.vw_PriceList_Activation.Ser_InvoiceNo = dbo.Vw_FllowUp_OrderCustomer.Ser_InvoiceNo  WHERE        (dbo.vw_PriceList_Activation.Agrement = 'موافق عليه')"
        End If

        If Op6.Checked = True Then
            sql2 = "  SELECT        dbo.vw_PriceList_Activation.Ser_InvoiceNo, dbo.vw_PriceList_Activation.InvoiceDate, dbo.vw_PriceList_Activation.Customer_Name, dbo.vw_PriceList_Activation.TotalPricelist, " & _
                       "   iif(dbo.vw_PriceList_Activation.flagtax = 0, 'شامل ضريبة', 'غير شامل ضريبة') AS tax, iif(dbo.Vw_FllowUp_OrderCustomer.Order_NO IS NULL, 'غير منفذة', 'منفذة') AS Activation " & _
"FROM            dbo.vw_PriceList_Activation LEFT OUTER JOIN" & _
                       "  dbo.Vw_FllowUp_OrderCustomer ON dbo.vw_PriceList_Activation.Ser_InvoiceNo = dbo.Vw_FllowUp_OrderCustomer.Ser_InvoiceNo  WHERE        (dbo.vw_PriceList_Activation.Agrement = 'غير موافق عليه')"
        End If

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم العرض"
        GridView1.Columns(1).Caption = "التاريخ"
        GridView1.Columns(2).Caption = "اسم العميل"
        GridView1.Columns(3).Caption = "اجمالى عرض السعر"
        GridView1.Columns(4).Caption = "الموقف الضريبي"
        GridView1.Columns(5).Caption = "حالة عرض السعر"


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        Total_Sum()
        sum_tax()
    End Sub
    Sub fill_TypeInvoice()
        'Com_Group_Item.Items.Clear()
        'sql = "SELECT        Name FROM            dbo.TB_InvoiceType  where Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    Com_Group_Item.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop
    End Sub
    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Unit()
        txt_unit.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Cru.SelectedIndexChanged
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date2.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102))  and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"


        calcalator_invoice()
    End Sub

   
    Private Sub Cmd_LookupSalse_Click(sender As Object, e As EventArgs)
        VarOpenlookup3 = 27
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        VarOpenlookup2 = 500
        varcode_form = 500 ' عشان السيرش بالاسم باستخدام اللايك و دى ممكن تكون مشكلة فى كل الباقي
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        find_salseByCustomer()
        fill_Project()
    End Sub
    Sub fill_Project()
        Com_Project.Items.Clear()
        sql = "  SELECT dbo.St_CustomerData.Customer_AccountNo, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS NameProject FROM     dbo.tb_CustomerProjects INNER JOIN  dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
       "           dbo.ST_CHARTCOSTCENTER ON dbo.tb_CustomerProjects.CostCenter_MainCode = dbo.ST_CHARTCOSTCENTER.Account_No " & _
" GROUP BY dbo.St_CustomerData.Customer_AccountNo, dbo.ST_CHARTCOSTCENTER.AccountName " & _
"        HAVING(dbo.St_CustomerData.Customer_AccountNo = '" & txt_AccountNo.Text & "') "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Project.Items.Add(rs("NameProject").Value)
            rs.MoveNext()
        Loop

    End Sub
    Sub find_salseByCustomer()
        If txt_AccountNo.Text = "" Then Exit Sub
        sql = "      SELECT        dbo.St_CustomerData.Customer_AccountNo, dbo.St_CustomerData.Salse_No, dbo.Emp_employees.Emp_Name " & _
      "FROM            dbo.St_CustomerData INNER JOIN " & _
      "                         dbo.Emp_employees ON dbo.St_CustomerData.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.St_CustomerData.Salse_No = dbo.Emp_employees.Emp_Code " & _
      "        WHERE(dbo.St_CustomerData.Customer_AccountNo = '" & txt_AccountNo.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_salesNo.Text = rs("Salse_No").Value : txt_sales.Text = rs("Emp_Name").Value

    End Sub
    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click
        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()
        'If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

        'Dim sql = "select * from TB_Header_OrderItem where No_PriceList = '" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'Dim dt = ds.Tables(0)
        ''MsgBox(" عدد النتائج : " & dt.Rows.Count, MsgBoxStyle.Critical, "خطا")

        'If dt.Rows.Count <> 0 Then
        '    MsgBox("لا يمكن تعديل عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
        '    Exit Sub
        'End If

        sql = "select * from TB_Header_OrderItem where No_PriceList = '" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن تعديل عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا") : Exit Sub

        find_varcode()

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        If op1.Checked = True Then VarTypePriceList = 0
        If op2.Checked = True Then VarTypePriceList = 1

        If chekPrice.Checked = True Then varflagTax = 1
        If chekPrice.Checked = True Then varflagTax = 0

        sql2 = "UPDATE  TB_Header_PriceListCustomer  SET Invoice_Type ='" & VarTypePriceList & "',  Customer_No ='" & txt_AccountNo.Text & "', InvoiceDate ='" & vardateoder & "',type='" & Com_Type.Text & "' ,flagtax='" & varflagTax & "'  ,Notes = '" & txt_Notes.Text & "',Salse_No= '" & txt_salesNo.Text & "'    WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'"
        rs = Cnn.Execute(sql2)


        find_varcode()


        sql = "UPDATE  TB_Detalis_PriceListCustomer  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Code_Stores ='" & varcodStores & "',Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Total_Item ='" & Txt_Total.Text & "',Code_cur ='" & varcode_Cru & "',Rat_Invoice ='" & txt_rat.Text & "' WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

        'find_invoice()
        find_hedar()
        find_detalis()
        find_tax()

        Total_Sum()
        sum_tax()
        find_PriceList()
    End Sub
    Sub find_varcode()
        On Error Resume Next
        sql = "   SELECT *    FROM BD_Unit    WHERE(name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '=====================================المخزن
        'If Op3.Checked = True Then
        '    sql = "  SELECT        Order_Stores_NO, Code_Stores      FROM dbo.Vw_Lookup_AznSarf WHERE        (Order_Stores_NO = '" & Com_NoAzn.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then varcodStores = Trim(rs("Code_Stores").Value)
        'Else

        'End If
        '========================================================

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "' and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()

        'Dim sql = "select * from TB_Header_OrderItem where No_PriceList = " & Com_InvoiceNo.Text & ""
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'Dim dt = ds.Tables(0)

        'If dt.Rows.Count <> 0 Then
        '    MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
        '    Exit Sub
        'End If


        sql = "select * from TB_Header_OrderItem where No_PriceList = '" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا") : Exit Sub



        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detalis_PriceListCustomer  WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                Total_Sum()
        End Select
        find_PriceList()
    End Sub



    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        vartable = "BD_Condation_PriceList"
        VarOpenlookup = 56
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub Cmd_DeleteCondationInvoice_Click(sender As Object, e As EventArgs)
        'On Error Resume Next
        'Dim x As String
        ''Dim varcount As Integer
        'x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'Select Case x
        '    Case vbNo

        '    Case vbYes
        '        sql = "Delete Tb_CondationPriceList  WHERE Invoice_No = '" & Com_InvoiceNo3.Text & "' and ID ='" & varID & "' and Compny_Code ='" & VarCodeCompny & "' "
        '        rs = Cnn.Execute(sql)


        '        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        'End Select
        'find_Invoice_Condation()
    End Sub

    Private Sub cmd_saveCondationInvoice_Click(sender As Object, e As EventArgs)
        'If Len(Com_InvoiceNo3.Text) = 0 Then MsgBox("من فضلك أختار رقم عرض السعر  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        'sql = "INSERT INTO Tb_CondationPriceList (Invoice_No, Compny_Code,Code_Codation) " & _
        '  " values  ('" & Com_InvoiceNo3.Text & "' ,'" & VarCodeCompny & "','" & varcode_Condation & "')"
        'Cnn.Execute(sql)
        'MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        'txt_Discrption2.Text = ""
        'find_Invoice_Condation()

    End Sub
    Sub find_Invoice_Condation()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        'sql2 = "   SELECT         ID ,Order_NO, Discrption     FROM dbo.Tb_CondationOrder WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & Com_InvoiceNo3.Text & "')"


        sql2 = " SELECT        dbo.Tb_CondationPriceList.ID, dbo.Tb_CondationPriceList.PriceList_No, dbo.BD_Condation_PriceList.Name " & _
                 " FROM            dbo.Tb_CondationPriceList INNER JOIN " & _
                 "                         dbo.BD_Condation_PriceList ON dbo.Tb_CondationPriceList.Code_Codation = dbo.BD_Condation_PriceList.Code AND dbo.Tb_CondationPriceList.Compny_Code = dbo.BD_Condation_PriceList.Compny_Code " & _
                 " WHERE        (dbo.Tb_CondationPriceList.PriceList_No ='" & Com_InvoiceNo3.Text & "') AND (dbo.Tb_CondationPriceList.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "100"
        GridView3.Columns(2).Width = "350"
        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns(0).Caption = "م"
        GridView3.Columns(1).Caption = "عرض رقم"
        GridView3.Columns(2).Caption = "شروط الدفع"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub


    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
        On Error Resume Next

        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'Com_InvoiceNo3.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        'txt_Discrption2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        'varID = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
    End Sub

    Private Sub txt_Ntax_TextChanged(sender As Object, e As EventArgs)
        ''calcalator_invoice()
        'On Error Resume Next
        'Dim vartax As Single
        'vartax = txt_Ntax.Text
        'txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)
        'Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text), 2)
    End Sub




    Private Sub Cmd_DeleteInv_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteInv.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

            x = MsgBox("هل تريد حذف عرض السعر نهائى", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()

        'Dim sql = "select * from TB_Header_OrderItem where No_PriceList = " & Com_InvoiceNo.Text & ""
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'Dim dt = ds.Tables(0)
        'MsgBox("عدد النتائج هو :" & dt.Rows.Count, MsgBoxStyle.Critical, "خطا")

        'If dt.Rows.Count <> 0 Then
        '    MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
        '    Exit Sub
        'End If


        sql = "select * from TB_Header_OrderItem where No_PriceList = '" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا") : Exit Sub


            Select Case x
                Case vbNo

                Case vbYes
                    sql = "Delete TB_Detalis_PriceListCustomer  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    '===================================حذف من المخزن
                    sql = "Delete TB_Header_PriceListCustomer  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'   "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','12','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                    MsgBox("تم حذف عرض السعر", MsgBoxStyle.Information, "Css Solution Software Module")
                    find_detalis()
                    find_hedar()
            End Select
        find_PriceList()
    End Sub

    Private Sub txt_unit_GotFocus(sender As Object, e As EventArgs) Handles txt_unit.GotFocus
        fill_Unit2()
    End Sub
    Sub fill_Unit2()
        'If Com_NameItem.Text = "" Then MsgBox("أختار الصنف من فضلك", MsgBoxStyle.Critical) : Exit Sub
        sql = "   SELECT *    FROM BD_Item   WHERE(Name = '" & txt_NameItem.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '==================================================

        txt_unit.Items.Clear()

        sql = " SELECT Name FROM     vw_AllUnit where  code ='" & varcodeitem & "'   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Private Sub txt_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_unit.SelectedIndexChanged

    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs) Handles txt_Qty.TextChanged
        calcalator_invoice()
        If Txt_Discount.Text.Trim <> "" Or Txt_Discount.Text.Trim <> "0" Then
            Txt_Discount_TextChanged(Nothing, Nothing)
        End If
    End Sub



    Private Sub Op5_Click(sender As Object, e As EventArgs) Handles Op5.Click
        find_PriceList()
    End Sub

    Private Sub Op6_CheckedChanged(sender As Object, e As EventArgs) Handles Op6.CheckedChanged

    End Sub

    Private Sub Op6_Click(sender As Object, e As EventArgs) Handles Op6.Click
        find_PriceList()
    End Sub


    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub


    Private Sub Txt_Discount_TextChanged(sender As Object, e As EventArgs) Handles Txt_Discount.TextChanged

        On Error Resume Next
        If sizeItem <> 0 Then
            txt_valuediscount.Text = Math.Round(Val((txt_Price.Text) * Val(txt_Qty.Text) * sizeItem * Val(txt_rat.Text)) * Val(Txt_Discount.Text) / 100, 2)
            Txt_Total.Text = Math.Round(Val(txt_Price.Text) * Val(txt_Qty.Text) * sizeItem * Val(txt_rat.Text) - Val(txt_valuediscount.Text), 2)

        Else
            txt_valuediscount.Text = Math.Round(Val((txt_Price.Text) * Val(txt_Qty.Text) * Val(txt_rat.Text)) * Val(Txt_Discount.Text) / 100, 2)
            Txt_Total.Text = Math.Round(Val(txt_Price.Text) * Val(txt_Qty.Text) * Val(txt_rat.Text) - Val(txt_valuediscount.Text), 2)

        End If

    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        vartable = "BD_Condation_PriceList"
        VarOpenlookup = 561
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub cmd_saveCondationInvoice_Click_1(sender As Object, e As EventArgs) Handles cmd_saveCondationInvoice.Click
        Dim varserilflag As Integer
        If Len(Com_InvoiceNo3.Text) = 0 Then MsgBox("من فضلك أختار رقم عرض السعر  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub
        '=====================================
        sql2 = "  SELECT        MAX(flag) AS Maxseril, PriceList_No, Compny_Code        FROM dbo.Tb_CondationPriceList GROUP BY PriceList_No, Compny_Code " & _
            " HAVING        (PriceList_No = '" & Com_InvoiceNo3.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varserilflag = rs("Maxseril").Value + 1
        '===============================================================



        sql = "INSERT INTO Tb_CondationPriceList (PriceList_No, Compny_Code,Code_Codation,flag) " & _
          " values  ('" & Com_InvoiceNo3.Text & "' ,'" & VarCodeCompny & "','" & varcode_Condation2 & "','" & varserilflag & "')"
        Cnn.Execute(sql)
        MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        txt_Discrption2.Text = ""
        find_Invoice_Condation()
    End Sub

    Private Sub Cmd_DeleteCondationInvoice_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteCondationInvoice.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_CondationPriceList  WHERE PriceList_No = '" & Com_InvoiceNo3.Text & "' and ID ='" & varID & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        End Select
        find_Invoice_Condation()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Com_InvoiceNo3.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_Discrption2.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        varID = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If txt_AccountNo.Text.Trim = "" Then
            MsgBox("برجاء اختيار اسم العميل", MsgBoxStyle.Information, "اسم العميل فارغ")
            Exit Sub
        End If
        If txt_nameaccount.Text.Trim = "" Then
            MsgBox("برجاء اختيار اسم العميل", MsgBoxStyle.Information, "اسم العميل فارغ")
            Exit Sub
        End If
        Frm_AccountStatement2.Close()
        Frm_AccountStatement2.txt_codeAcc.Text = txt_AccountNo.Text
        Frm_AccountStatement2.txt_NameAcc.Text = txt_nameaccount.Text
        Frm_AccountStatement2.MdiParent = Mainmune
        Frm_AccountStatement2.FindBalance()
        Frm_AccountStatement2.find_data()
        Frm_AccountStatement2.count_colume()
        Frm_AccountStatement2.count_colume2()
        Frm_AccountStatement2.final_sum()
        Frm_AccountStatement2.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click

        If txt_AccountNo.Text.Trim = "" Then
            MsgBox("برجاء اختيار اسم العميل", MsgBoxStyle.Information, "اسم العميل فارغ")
            Exit Sub
        End If
        If txt_nameaccount.Text.Trim = "" Then
            MsgBox("برجاء اختيار اسم العميل", MsgBoxStyle.Information, "اسم العميل فارغ")
            Exit Sub
        End If
        varaccountNo_Customer = txt_AccountNo.Text
        Frm_LookupReciptCustomer.txt_CustomerName.Text = txt_nameaccount.Text
        Frm_LookupReciptCustomer.MdiParent = Mainmune
        Frm_LookupReciptCustomer.find_all_Detils()
        Frm_LookupReciptCustomer.Show()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VarOpenlookup3 = 2020
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub Op5_CheckedChanged(sender As Object, e As EventArgs) Handles Op5.CheckedChanged

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        Dim sql = "select * from TB_Header_OrderItem where No_PriceList = N'" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dt = ds.Tables(0)

        If dt.Rows.Count <> 0 Then
            MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
            Exit Sub
        End If

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

        Dim sql = "select * from TB_Header_OrderItem where No_PriceList = '" & Com_InvoiceNo.Text & "' and Compny_Code = " & VarCodeCompny & ""
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dt = ds.Tables(0)

        If dt.Rows.Count <> 0 Then
            MsgBox("لا يمكن تعديل بيانات  عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
            Exit Sub
        End If

        find_varcode()

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        If op1.Checked = True Then VarTypePriceList = 0
        If op2.Checked = True Then VarTypePriceList = 1

        If chekPrice.Checked = True Then varflagTax = 1
        If chekPrice.Checked = True Then varflagTax = 0

        sql2 = "UPDATE  TB_Header_PriceListCustomer  SET Invoice_Type ='" & VarTypePriceList & "',  Customer_No ='" & txt_AccountNo.Text & "', InvoiceDate ='" & vardateoder & "',type='" & Com_Type.Text & "' ,flagtax='" & varflagTax & "'  ,Notes = '" & txt_Notes.Text & "',Salse_No= '" & txt_salesNo.Text & "'    WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'"
        rs = Cnn.Execute(sql2)

        find_PriceList()

    End Sub

    Private Sub chekPrice_CheckedChanged(sender As Object, e As EventArgs) Handles chekPrice.CheckedChanged

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub op2_CheckedChanged(sender As Object, e As EventArgs) Handles op2.CheckedChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then CheckBox2.Checked = False : CheckEng.Checked = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then CheckBox1.Checked = False : CheckEng.Checked = False
    End Sub

    Private Sub CheckEng_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEng.CheckedChanged
        If CheckEng.Checked = True Then CheckBox2.Checked = False : CheckBox2.Checked = False
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        vartable = "BD_Condation_PriceList"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "شروط عرض السعر"
        Frm_GenralData.Show()
    End Sub

    Private Sub Com_Project_Click(sender As Object, e As EventArgs) Handles Com_Project.Click
    find_project

    End Sub

    Private Sub Com_Project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Project.SelectedIndexChanged
        find_project()

    End Sub
    Sub find_project()
        On Error Resume Next
        sql = "select * from ST_CHARTCOSTCENTER where AccountName ='" & Com_Project.Text & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_project = rs("Account_No").Value
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        vardisplayReport = 2700
        Print_Rented.Show()
        'FrmPrintOffer.Show()
    End Sub
End Class