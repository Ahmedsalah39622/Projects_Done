﻿Imports System.Data.OleDb

Public Class Frm_InvoiceRented
    Dim varcodeitem As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim xx As String
    Dim VarItem_EX, VarStutas As String
    Dim x As String
    Dim vartaxinvoice, vartaxitem As Single

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs) Handles cmd_FindItem.Click
      
        'Frm_LookupRented.Close()
        'Frm_LookupRented.MdiParent = Mainmune
        Frm_LookupRented.ShowDialog()
       

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
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code FROM            TB_Header_InvoiceRented    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "" + "1"


        End If



    End Sub


    Sub Total_Sum()
        find_tax()
        Dim total As String = 0
        For i As Integer = 0 To GridView6.RowCount - 1
            total += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(11)))
        Next
        txt_totalPrice.Text = total
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * vartaxinvoice / 100, 2)
        Txt_TotalAll.Text = total + Val(txt_Tax.Text)
    End Sub


    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        Com_NoAzn.Text = ""
        Txt_Discount.Text = ""
        txt_valuediscount.Text = ""
        Txt_Total.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_CodeSalse.Text = ""
        txt_NameSalse.Text = ""
        com_Cru.Text = ""
        txt_rat.Text = ""
        txt_AvQty.Text = ""
        txt_SalseOrder.Text = ""
        txt_Typeinv.Text = ""
        txt_Typeinv.BackColor = Color.Gray
        txt_Price.Text = ""
        txt_Stores.Text = ""
        Txt_TotalAll.Text = ""
        txt_totalPrice.Text = ""
        txt_Ntax.Text = ""
        txt_Tax.Text = ""
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click


        sql2 = "select * from TB_Header_InvoiceRented where Ser_InvoiceNo  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Invoice_H()



    End Sub

    Sub find_tax()
        'sql = "select * from Tb_TaxInvoice where  Compny_Code ='" & VarCodeCompny & "'   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then VarAccountTax_Invoice = rs("Account_Tax").Value : vartaxinvoice = rs("Tax_Sal").Value : txt_Ntax.Text = rs("Tax_Sal").Value Else vartaxinvoice = "0" : txt_Ntax.Text = 0
    End Sub
    Sub save_Invoice_H()
        'On Error Resume Next
        If Com_Group_Item.Text = "فاتورة ضريبية" Then vartypeinvoice = 1
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then vartypeinvoice = 0

        Dim dd As DateTime = txt_date.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoiceRented where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_InvoiceRented (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
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

        sql = "INSERT INTO TB_Detalis_InvoiceRented (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice) " & _
              " values  ('" & Com_NoAzn.Text & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & varcodStores & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & varcode_Cru & "','" & txt_rat.Text & "')"
        Cnn.Execute(sql)

        Dim sql3 As String
        sql3 = "UPDATE  TB_Detils_AznAddItem  SET No_Invoice ='" & Com_InvoiceNo2.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Ser_NO_StoresAdd ='" & Com_NoAzn.Text & "'    "
        rs = Cnn.Execute(sql3)


    End Sub

    Private Sub txt_Price_TextChanged(sender As Object, e As EventArgs) Handles txt_Price.TextChanged
        calcalator_invoice()
    End Sub
    Sub calcalator_invoice()
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single
        varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_Price.Text) * Val(txt_rat.Text), 2)
        varDiscount = varTotalInvoice * Val(Txt_Discount) / 100

        Txt_Total.Text = varTotalInvoice - varDiscount
    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        vartable = "Vw_LookupInvoiceRented"
        VarOpenlookup = 272700
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub

    Sub find_hedar()
        On Error Resume Next
        sql = " SELECT        dbo.TB_Header_InvoiceRented.Ser_InvoiceNo, dbo.TB_Header_InvoiceRented.Ext_InvoiceNo, dbo.TB_Header_InvoiceRented.InvoiceDate, dbo.TB_Header_InvoiceRented.Customer_No,dbo.TB_Header_InvoiceRented.PayStatus, dbo.FindCustomer.Name,  " & _
 "                         dbo.TB_Header_InvoiceRented.Salse_No, dbo.Emp_employees.Emp_Name, iif(dbo.TB_Header_InvoiceRented.Invoice_Type='1', 'مغلق', 'جديد') AS Type, iif(dbo.TB_Header_InvoiceRented.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status,  " & _
 "        dbo.TB_Header_InvoiceRented.Notes " & _
" fROM            dbo.TB_Header_InvoiceRented INNER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_InvoiceRented.Customer_No = dbo.FindCustomer.code INNER JOIN " & _
"                         dbo.Emp_employees ON dbo.TB_Header_InvoiceRented.Salse_No = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_InvoiceRented.Compny_Code = dbo.Emp_employees.Compny_Code " & _
 " WHERE        (dbo.TB_Header_InvoiceRented.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') and dbo.TB_Header_InvoiceRented.Compny_Code = '" & VarCodeCompny & "' "


        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs3("Ser_InvoiceNo").Value)
            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            txt_date.Text = Trim(rs3("InvoiceDate").Value)
            txt_Notes.Text = Trim(rs3("Notes").Value)
            txt_CodeSalse.Text = Trim(rs3("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs3("Emp_Name").Value)
            txt_AccountNo.Text = Trim(rs3("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs3("Name").Value)
            txt_Typeinv.Text = Trim(rs3("Invoice_Status").Value)
            If txt_Typeinv.Text = "مرحل" Then txt_Typeinv.BackColor = Color.Green
            If txt_Typeinv.Text = "فاتورة مبدئية" Then txt_Typeinv.BackColor = Color.Gray

            'If rs3("PayStatus").Value = 0 Then Com_Condation.Text = "دفع 100 % عن الاستلام نقدا"
            'If rs3("PayStatus").Value = 1 Then Com_Condation.Text = "100 % بعد شهر"
            'If rs3("PayStatus").Value = 2 Then Com_Condation.Text = "100 % بعد شهرين"
            'If rs3("PayStatus").Value = 3 Then Com_Condation.Text = "100 % بعد 3 شهور"
            'If rs3("PayStatus").Value = 4 Then Com_Condation.Text = "50 % نقدا 50 % بعد شهر"
            Com_Group_Item.Text = "فاتورة غير ضريبية"
            'If Trim(rs3("Invoice_Type").Value) = 1 Then Com_Group_Item.Text = "فاتورة ضريبية"


            If Trim(rs3("Invoice_Status").Value) = "مرحل" Then
                cmd_OpenGl.Enabled = True
                sql2 = " Select IDGenral               FROM dbo.Genralledger WHERE  (Typebill = 5) AND (Compny_Code = '" & VarCodeCompny & "')  and flgcancle=0 AND (RTRIM(No_Sand) = '" & Trim(Com_InvoiceNo2.Text) & "') GROUP BY IDGenral"
                rs2 = Cnn.Execute(sql2)
                If rs2.EOF = False Then txt_OpenGl.Text = rs2("IDGenral").Value Else txt_OpenGl.Text = ""
            Else
                txt_OpenGl.Text = ""
                cmd_OpenGl.Enabled = False
            End If


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



        sql2 = "SELECT        No_Item, Ex_Item, Name, Quntity, Unit, NameStores, Price_Item,Name_Cru,Rat_Invoice, Discount_Item, Value_Discount, Total_Item, Order_Stores_No     FROM dbo.Vw_DetilsInvoice_rented" & _
            " where  (dbo.Vw_DetilsInvoice_rented.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') AND (dbo.Vw_DetilsInvoice_rented.Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then Com_NoAzn.Text = rs("Order_Stores_No").Value
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True
        GridView6.BestFitColumns()
        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "المخزن"
        GridView6.Columns(6).Caption = "سعر الوحدة"
        GridView6.Columns(7).Caption = "العملة"
        GridView6.Columns(8).Caption = "م التحويل"
        GridView6.Columns(9).Caption = "نسبة الخصم"
        GridView6.Columns(10).Caption = "قيمة الخصم"
        GridView6.Columns(11).Caption = "الاجمالى"
        GridView6.Columns(12).Caption = "رقم الاذن"
        'GridView6.Columns(13).Caption = "رقم الاذن"
        'GridView6.Columns(14).Caption = "رقم الطلبية"

        GridView6.BestFitColumns()



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        'Mainmune.finwatinoderItem()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        com_Cru.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        txt_Price.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        Txt_Discount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        txt_valuediscount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))
        Txt_Total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        'txt_SalseOrder.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(14))
        Com_NoAzn.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))




    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        'Frm_AznSarf_old.Com_InvoiceNo2.Text = Com_NoAzn.Text
        'Frm_AznSarf_old.find_hedar()
        'Frm_AznSarf_old.find_detalis()
        'Frm_AznSarf_old.MdiParent = Mainmune
        'Frm_AznSarf_old.Show()



    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Frm_OrderSal.Com_InvoiceNo2.Text = txt_SalseOrder.Text
        'Frm_OrderSal.find_hedar()
        'Frm_OrderSal.find_detalis()
        'Frm_OrderSal.MdiParent = Mainmune
        'Frm_OrderSal.Show()
    End Sub

    Sub sum_tax()
        On Error Resume Next
        Dim vartax As Single
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then vartax = 0 : txt_Ntax.Text = 0
        'If Com_Group_Item.Text = "فاتورة ضريبية" Then vartax = txt_Ntax.Text

        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then txt_Tax.Text = 0 : txt_Ntax.Text = 0
        'If Com_Group_Item.Text = "فاتورة ضريبية" Then txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)

        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_Dis.Text) - Val(txt_OtherDiscount.Text), 2)
    End Sub
    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_CloseInvoice.Click
        Dim varinvoicetype As Integer
        If Len(Com_Group_Item.Text) = 0 Then MsgBox("من فضلك اختار نوع فاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then varinvoicetype = 0
        If Com_Group_Item.Text = "فاتورة ضريبية" Then varinvoicetype = 1

        sum_tax()
        saveGl()

        'sql2 = "UPDATE  TB_Header_InvoiceSal  SET Tax_N='" & txt_Ntax.Text & "',Invoice_Type ='" & varinvoicetype & "' , Invoice_Status='" & 1 & "',PayStatus='" & VarStutas & "',NS_2='" & txt_Ntax2.Text & "',NS_Other='" & txt_Ntax3.Text & "',Dis_Item='" & txt_Dis.Text & "' ,Dis_2 ='" & txt_Dis2.Text & "' ,Dis_Other ='" & txt_OtherDiscount.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        'rs = Cnn.Execute(sql2)


        sql2 = "UPDATE  TB_Header_InvoiceRented  SET Invoice_Status='" & 1 & "',PayStatus='" & VarStutas & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)

        '============================== TransactionHistoryCode 
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','8','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================


        find_hedar()
        find_detalis()
        Total_Sum()
        Cmd_CloseInvoice.Enabled = False
        Cmd_RtInvoice.Enabled = True
        Cmd_PrintInvoice.Enabled = True
    End Sub
    Sub saveGl()
        'On Error Resume Next
        If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd3 As DateTime = txt_date.Text
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")

        lastgl()

        'If txt_Type.Text = "أجل" Then
        find_tax()

        ''=============رقم مركز التكلفة
        'sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================


        '=============رقم مركز التكلفة1
        sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================
        If VarCodeCompny = 2 Then varcodeCostCenter1 = "401001"
        If VarCodeCompny = 1 Then varcodeCostCenter1 = "102002"
        If VarCodeCompny = 3 Then varcodeCostCenter1 = "102002"

        '=======================================================المدين  من ح العملاء - او ح النقدية
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
        " values  (N'" & varNoGL & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "',N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "' ,N'" & 0 & "','" & 5 & "',N'" & Com_InvoiceNo2.Text & "',N'" & 1 & "',N'" & 1 & "',N'" & varcodeCostCenter1 & "' ,N'" & 1 & "',N'" & Txt_TotalAll.Text & "' ,N'" & 0 & "',N'" & VarCodeCompny & "',N'" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "'  ,N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & "5" & "',N'" & Com_InvoiceNo2.Text & "',N'" & 1 & "',N'" & varcodeCostCenter1 & "' ,N'" & 1 & "' ,N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & VarCodeCompny & "' )"
        Cnn.Execute(sql)



        'sql = "SELECT        dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceRented.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, SUM(dbo.TB_Detalis_InvoiceRented.Total_Item) AS TotalAll, dbo.Setup_Acc_Group.AccountNo_Sal, " & _
        '"                         dbo.Setup_Acc_Group.AccountNo_Discount2, dbo.TB_Detalis_InvoiceRented.Discount_Item " & _
        '" FROM            dbo.BD_ITEM INNER JOIN " & _
        '"                         dbo.TB_Detalis_InvoiceRented ON dbo.BD_ITEM.Compny_Code = dbo.TB_Detalis_InvoiceRented.Compny_Code AND dbo.BD_ITEM.Ex_Item = dbo.TB_Detalis_InvoiceRented.Ex_Item INNER JOIN " & _
        '"                         dbo.Tb_TypeItemList ON dbo.BD_ITEM.TypeItemList2 = dbo.Tb_TypeItemList.Code INNER JOIN " & _
        '"                         dbo.Setup_Acc_Group ON dbo.Tb_TypeItemList.Code = dbo.Setup_Acc_Group.Code_Group " & _
        '" GROUP BY dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceRented.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.Setup_Acc_Group.AccountNo_Discount2, " & _
        '"        dbo.TB_Detalis_InvoiceRented.Discount_Item " & _
        '" HAVING        (dbo.TB_Detalis_InvoiceRented.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') "

        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF


        sql = "SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
"                         dbo.Setup_Acc_Group.AccountNo_Discount2 " & _
" FROM            dbo.Setup_Acc_Group INNER JOIN " & _
"                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code INNER JOIN " & _
"                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
" WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "

        rs = Cnn.Execute(sql)



        If Val(txt_OtherDiscount.Text) > 0 Then
            '=================================الخصم
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  (N'" & varNoGL & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "',N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "','" & txt_OtherDiscount.Text & "' ,N'" & 0 & "',N'" & 5 & "',N'" & Com_InvoiceNo2.Text & "',N'" & 1 & "',N'" & 1 & "','" & 0 & "' ,N'" & 1 & "',N'" & txt_OtherDiscount.Text & "' ,N'" & 0 & "',N'" & VarCodeCompny & "',N'" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "'  ,N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & txt_OtherDiscount.Text & "',N'" & 0 & "',N'" & "5" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & 0 & "' ,'" & 1 & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

        End If




        '=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & rs("AccountNo_Sal").Value & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================

        If VarCodeCompny = 2 Then varcodeCostCenter2 = "401001"
        If VarCodeCompny = 1 Then varcodeCostCenter2 = "102002"
        If VarCodeCompny = 3 Then varcodeCostCenter2 = "102002"

        'VarAccountTax_Invoice
        '========================================================================== الدائن
        'vartaxitem = rs("TotalAll").Value * (txt_Ntax.Text) / 100

        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
            " values  (N'" & varNoGL & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Sal").Value & "',N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "' ,'" & txt_totalPrice.Text & "',N'" & 5 & "',N'" & Com_InvoiceNo2.Text & "',N'" & 2 & "',N'" & varcodesub & "',N'" & varcodeCostCenter2 & "' ,N'" & 1 & "','" & 0 & "' ,N'" & txt_totalPrice.Text & "',N'" & VarCodeCompny & "',N'" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '========================الضريبة
        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
        '  " values  (N'" & varNoGL & "' ,N'" & vardate3 & "',N'" & VarAccountTax_Invoice & "',N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "' ,'" & txt_Tax.Text & "',N'" & 5 & "',N'" & Com_InvoiceNo2.Text & "',N'" & 2 & "',N'" & varcodesub & "',N'" & varcodeCostCenter2 & "' ,N'" & 1 & "',N'" & 0 & "' ,N'" & txt_Tax.Text & "',N'" & VarCodeCompny & "',N'" & 1 & "','" & varcode_User & "')"
        'Cnn.Execute(sql)





        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
         " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Sal").Value & "'  ,N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_totalPrice.Text & "',N'" & "5" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "' )"
        Cnn.Execute(sql)


        '================================الضريبة
        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
        ' " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & VarAccountTax_Invoice & "'  ,N'" & "فاتورة مرتجع مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_Tax.Text & "',N'" & "5" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "' )"
        'Cnn.Execute(sql)



        'rs.MoveNext()
        'Loop



        '========================================خصم عام




        'End If

        'gl_discountall()
        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



    End Sub



    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_PrintInvoice.Click
        vardisplayReport = 250
        Print_Rented.Show()

    End Sub

    Private Sub Frm_SalseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_cru()

        'Com_Condation.Items.Add("دفع 100 % عن الاستلام نقدا")
        'Com_Condation.Items.Add("100 % بعد شهر")
        'Com_Condation.Items.Add("100 % بعد شهرين")
        'Com_Condation.Items.Add("100 % بعد 3 شهور")
        'Com_Condation.Items.Add("50 % نقدا 50 % بعد شهر")

        fill_TypeInvoice()
    End Sub
    Sub fill_TypeInvoice()
        Com_Group_Item.Items.Clear()
        sql = "SELECT        Name FROM            dbo.TB_InvoiceType  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Group_Item.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
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


    Private Sub com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Cru.SelectedIndexChanged
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_date.Text
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Text, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102))  and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"


        calcalator_invoice()
    End Sub

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        'If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True

    End Sub

    Private Sub Op4_CheckedChanged(sender As Object, e As EventArgs) Handles Op4.CheckedChanged
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        'If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True
    End Sub

    Private Sub Cmd_LookupSalse_Click(sender As Object, e As EventArgs) Handles Cmd_LookupSalse.Click
        VarOpenlookup3 = 270
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub txt_SalseOrder_TextChanged(sender As Object, e As EventArgs) Handles txt_SalseOrder.TextChanged
        If txt_SalseOrder.Text <> "" Then SimpleButton2.Enabled = True Else SimpleButton2.Enabled = False
        If Com_NoAzn.Text <> "" Then SimpleButton5.Enabled = True Else SimpleButton5.Enabled = False
    End Sub

    Private Sub Com_NoAzn_TextChanged(sender As Object, e As EventArgs) Handles Com_NoAzn.TextChanged
        If txt_SalseOrder.Text <> "" Then SimpleButton2.Enabled = True Else SimpleButton2.Enabled = False
        If Com_NoAzn.Text <> "" Then SimpleButton5.Enabled = True Else SimpleButton5.Enabled = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        VarOpenlookup2 = 2400
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click

        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن التعديل الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart soft")
        If txt_Typeinv.Text = "فاتورة مبدئية" Then

            find_varcode()

            sql = "UPDATE  TB_Detalis_InvoiceRented  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Code_Stores ='" & varcodStores & "',Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Total_Item ='" & Txt_Total.Text & "',Code_cur ='" & varcode_Cru & "',Rat_Invoice ='" & txt_rat.Text & "' WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

            MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        End If
        find_detalis()
        Total_Sum()
    End Sub
    Sub find_varcode()
        On Error Resume Next
        sql = "   SELECT Unit1, Ex_Item    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '=====================================المخزن
        'sql = "  SELECT        Order_Stores_NO, Code_Stores      FROM dbo.Vw_Lookup_AznSarf WHERE        (Order_Stores_NO = '" & Com_NoAzn.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodStores = Trim(rs("Code_Stores").Value)

        sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = Trim(rs("code").Value)


        '========================================================

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detalis_InvoiceRented  WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                Total_Sum()
        End Select
    End Sub

    Private Sub Cmd_RtInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_RtInvoice.Click
        Dim x As String
        x = MsgBox("هل تريد ارجاع الفاتورة", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "UPDATE  TB_Header_InvoiceRented  SET Invoice_Status = '" & 0 & "'  WHERE Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "'   and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                'sql = "Delete Genralledger  WHERE Typebill ='" & 5 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                'rs = Cnn.Execute(sql)

                sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "',UserID= '" & varcode_User & "'  WHERE No_Sand = '" & Com_InvoiceNo2.Text & "' and Typebill ='" & 5 & "'   and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)




                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 5 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','9','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم ارجاع الفاتورة  ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End Select

        find_hedar()
        find_detalis()
        'find_Invoice_Condation()
        Total_Sum()
        Cmd_CloseInvoice.Enabled = True
        'sum_tax()
    End Sub

    Private Sub Cmd_DeleteInv_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteInv.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        If txt_Typeinv.Text = "مرحل" Then
            MsgBox("لايمكن حذف الفاتورة الفاتورة مرحلة", MsgBoxStyle.Critical, "Css Solution Software Module")

        Else
            x = MsgBox("هل تريد حذف الفاتورة نهائى", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            Select Case x
                Case vbNo

                Case vbYes

                    '========================تعديل الاذن
                    'sql2 = "  SELECT        Ext_InvoiceNo, Compny_Code, Order_Stores_No          FROM dbo.TB_Detalis_InvoiceRented WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "')"
                    'rs = Cnn.Execute(sql2)
                    'If rs.EOF = False Then varOrder_Stores = rs("Order_Stores_No").Value
                    ''===================================================
                    'sql = "UPDATE TB_Detils_AznItem_Stores set No_Invoice ='" & 0 & "'  WHERE  Order_Stores_NO ='" & varOrder_Stores & "' and Compny_Code ='" & VarCodeCompny & "' "
                    'rs = Cnn.Execute(sql)

                    '==================================================================================

                    sql = "Delete TB_Header_InvoiceRented  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    '===================================حذف من المخزن
                    sql = "Delete TB_Detalis_InvoiceRented  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'   "
                    rs = Cnn.Execute(sql)

                    sql = "UPDATE TB_Detils_AznAddItem set No_Invoice ='" & 0 & "'  WHERE  Ser_NO_StoresAdd ='" & Com_NoAzn.Text & "'  "
                    rs = Cnn.Execute(sql)

                    '============================== TransactionHistoryCode 
                    sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','5','10','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                    rs2 = Cnn.Execute(sql2)
                    '==============================

                    MsgBox("تم حذف الفاتورة", MsgBoxStyle.Information, "Css Solution Software Module")
                    find_detalis()
                    find_hedar()
            End Select
        End If
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Frm_AccountStatement.Close()
        Frm_AccountStatement.txt_codeAcc.Text = txt_AccountNo.Text
        Frm_AccountStatement.txt_NameAcc.Text = txt_nameaccount.Text
        Frm_AccountStatement.MdiParent = Mainmune
        Frm_AccountStatement.find_Acc2()
        Frm_AccountStatement.Show()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        varaccountNo_Customer = txt_AccountNo.Text
        Frm_LookupReciptCustomer.txt_CustomerName.Text = txt_nameaccount.Text
        Frm_LookupReciptCustomer.MdiParent = Mainmune
        Frm_LookupReciptCustomer.find_all_Detils()
        Frm_LookupReciptCustomer.Show()
    End Sub

    Private Sub Com_Group_Item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Group_Item.SelectedIndexChanged
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then txt_Ntax.Text = "0"
        If Com_Group_Item.Text = "فاتورة ضريبية" Then txt_Ntax.Text = "14"
        Total_Sum()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmd_OpenGl_Click(sender As Object, e As EventArgs) Handles cmd_OpenGl.Click
        If Len(txt_OpenGl.Text) = 0 Then MsgBox("رقم القيد غير موجود", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        Frm_Gl4.Com_GL_No.Text = txt_OpenGl.Text
        statusopen = 1
        Frm_Gl4.find_hedar()
        Frm_Gl4.find_detalis()
        Frm_Gl4.GridView6.BestFitColumns()
        Frm_Gl4.MdiParent = Mainmune

        Frm_Gl4.Show()
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
End Class