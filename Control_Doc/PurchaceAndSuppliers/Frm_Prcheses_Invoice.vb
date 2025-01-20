Imports System.Data.OleDb

Public Class Frm_Prcheses_Invoice
    Dim varcodeitem, varID, varindex As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim xx As String
    Dim VarItem_EX, VarStutas, vartaxinvoice2 As String
    Dim x As String
    Dim vartaxinvoice, vartaxitem As Single
    Dim vardiscount2 As String
    Dim varNoitem, varthiknis, varwidth As Single

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs) Handles cmd_FindItem.Click
        If IsDate(txt_date.Value) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If txt_Typeinv.Text = "مرحل" Then
            MsgBox("لايمكن اضافة اصناف الفاتورة مرحلة", MsgBoxStyle.Critical, "Css Solution Software Module")

        Else

            'If Op3.Checked = True Then
            '    typeInvoice = 1
            '    Frm_Lookup_AddItemInvoice.Close()
            '    Frm_Lookup_AddItemInvoice.MdiParent = Mainmune
            '    Frm_Lookup_AddItemInvoice.Search()
            '    Frm_Lookup_AddItemInvoice.Show()
            'End If

            'If Op4.Checked = True Then
            '    typeInvoice = 2
            '    Frm_Lookup_AddItemInvoice.Close()
            '    Frm_Lookup_AddItemInvoice.MdiParent = Mainmune
            '    Frm_Lookup_AddItemInvoice.Search2()
            '    Frm_Lookup_AddItemInvoice.Show()
            'End If

            If Com_InvoiceNo.Text = "" Then
                MsgBox("من فضلك أدخل رقم الفاتورة", MsgBoxStyle.Critical, "Css Solution Software Module")
                Exit Sub
            Else
                varNoInvoice = Com_InvoiceNo.Text
                varNoInvoice3 = Com_InvoiceNo2.Text
                varopenItemSuppliser = 1
                Frm_LookupItemPrcheses.ShowDialog()
                'Frm_Lookup_AddItemInvoice.find_detalis()
                'vw_itemprcheses()
            End If
        End If

        'varNoInvoice = Com_InvoiceNo.Text
        'varNoInvoice3 = Com_InvoiceNo2.Text
        'Frm_Lookup_AddItemInvoice.find_detalis()
    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs) Handles txt_nameaccount.TextChanged
        sql = "  SELECT        Name, Code      FROM dbo.Find_Suppliser2 WHERE        (Name = '" & txt_nameaccount.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_AccountNo.Text = rs("code").Value Else txt_AccountNo.Text = ""
    End Sub

    Private Sub txt_NameSalse_TextChanged(sender As Object, e As EventArgs)
        'sql = "    SELECT        Emp_Name, Emp_Code   FROM dbo.Emp_employees WHERE        (Emp_Name = '" & txt_NameSalse.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_CodeSalse.Text = rs("Emp_Code").Value Else txt_CodeSalse.Text = ""

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear_detils()
        fill_TypeInvoice()
        find_hedar()
        find_detalis()
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code FROM            TB_Header_InvoicePrcheses    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "INV000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "INV000" + "1"


        End If



    End Sub


    Sub Total_Sum()
        'find_tax()
        Dim total, total_dis As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(8))
            total_dis += GridView6.GetRowCellValue(i, GridView6.Columns(7))
        Next
        txt_Dis.Text = Math.Round(total_dis, 2)
        txt_totalPrice.Text = Math.Round(total, 2)
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * vartaxinvoice / 100, 2)
        Txt_TotalAll.Text = Math.Round(total + Val(txt_Tax.Text) - Val(txt_Dis.Text), 2)
    End Sub
   

    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        'Com_NoAzn.Text = ""
        Txt_Discount.Text = ""
        txt_valuediscount.Text = ""
        Txt_Total.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""

        txt_AccountNo2.Text = ""
        txt_nameaccount2.Text = ""
        'txt_CodeSalse.Text = ""
        'txt_NameSalse.Text = ""
        com_Cru.Text = ""
        txt_rat.Text = ""
        'txt_AvQty.Text = ""
        'txt_SalseOrder.Text = ""
        txt_Typeinv.Text = ""
        txt_Typeinv.BackColor = Color.Gray
        txt_Price.Text = ""
        txt_Stores.Text = ""
        Txt_TotalAll.Text = ""
        txt_totalPrice.Text = ""
        txt_Ntax.Text = ""
        txt_Tax.Text = ""
        txt_Ntax2.Text = ""
        txt_Dis2.Text = ""
        txt_OtherDiscount.Text = ""
        txt_ExItem.Text = ""
        'txt_date.Text = ""

        'txt_date.Text = Format(Now, "DD/mm/yyyy")
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        'If varcode_User = 1 Then
        'Else
        '    Dim dd4 As DateTime = txt_date.Text
        '    Dim vardate4 As String
        '    vardate4 = dd4.ToString("dd/MM/yyyy")
        '    '=======================================================
        '    Dim dd3 As DateTime = var_GetDateLive
        '    Dim vardate3 As String
        '    vardate3 = dd3.ToString("MM/dd/yyyy")
        '    If vardate3 <> vardate4 Then MsgBox("الفاتورة فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '    '=========================================================

        'End If



        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن اضافة اى عنصر جديد الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart software")
        If Com_Group_Item.Text = "" Then MsgBox("يجب تحديد نوع الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 And CheckBox1.Checked = True Then MsgBox("من  فضلك ادخل أسم المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_CodeItem.Text = "" And CheckBox1.Checked = True Then MsgBox("من فضلك اختار الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_unit.Text = "" And CheckBox1.Checked = True Then MsgBox("من فضلك اختار الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 And CheckBox1.Checked = True Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Price.Text) = 0 And CheckBox1.Checked = True Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_Cru.Text) = 0 And CheckBox1.Checked = True Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_nameaccount2.Text = "" Then MsgBox("من فضلك اختار حساب المشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_nameaccount.Text = "" Then MsgBox("من فضلك اختار الحساب  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        If CheckBox1.Checked = True Then
            Dim dd As DateTime = txt_date.Value
            Dim vardateoder As String
            vardateoder = dd.ToString("MM-d-yyyy")


            sql = "select * from TB_Header_InvoicePrcheses where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
            Else

                If Com_Group_Item.Text = "غير شامل ضريبة" Then vartypeinvoice = 0
                If Com_Group_Item.Text = "شامل ضريبة" Then vartypeinvoice = 1


                sql = "INSERT INTO TB_Header_InvoicePrcheses (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
                          " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & 1 & "','" & vartypeinvoice & "','" & 0 & "','" & txt_Notes.Text & "')"
                Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

            End If

            '===============================================المخزن
            sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Stores.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodestores = rs("Code").Value
            '==============================================================

            sql = "INSERT INTO TB_Detalis_InvoicePrcheses (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice,AccountNo2) " & _
           " values  ('" & Com_NoAzn.Text & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & 2 & "','" & 0 & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & 1 & "','" & txt_rat.Text & "','" & txt_AccountNo2.Text & "')"
            Cnn.Execute(sql)

            find_detalis()
        Else
            save_invoice()

        End If
        Total_Sum()
    End Sub
    Sub save_invoice()

        sql2 = "select * from TB_Header_InvoicePrcheses where Ser_InvoiceNo  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            'last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Invoice_H()

    End Sub

    Sub find_tax()
        sql2 = "select * from Tb_TaxInvoice where  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then VarAccountTax_Invoice = rs("Account_Tax").Value Else vartaxinvoice = "0"
    End Sub
    Sub save_Invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoicePrcheses where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else

            If Com_Group_Item.Text = "غير شامل ضريبة" Then vartypeinvoice = 0
            If Com_Group_Item.Text = "شامل ضريبة" Then vartypeinvoice = 1


            sql = "INSERT INTO TB_Header_InvoicePrcheses (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & 1 & "','" & vartypeinvoice & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
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


        'sql = "select * from TB_Detalis_InvoicePrcheses Where  Order_Stores_No ='" & Com_NoAzn.Text & "' and No_Invoice ='" & 0 & "'"
        'rs3 = Cnn.Execute(sql)
        'If rs3.EOF = False Then MsgBox("رقم الاذن مضاف من قبل لايمكن اضافتة مرة اخرى", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub

        SQL4 = "select * from vw_itemprcheses22 where Ser_NO_StoresAdd ='" & varNo_Azn & "' and No_Invoice ='" & 0 & "' "
        rs2 = Cnn.Execute(SQL4)
        Do While Not rs2.EOF


            sql = "INSERT INTO TB_Detalis_InvoicePrcheses (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice,AccountNo2) " & _
                  " values  ('" & Com_NoAzn.Text & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & rs2("No_item").Value & "','" & rs2("Qyt").Value & "','" & rs2("Code_Unit").Value & "','" & 0 & "','" & rs2("Code_Stores").Value & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & 1 & "','" & txt_rat.Text & "','" & txt_AccountNo2.Text & "')"
            Cnn.Execute(sql)


            Dim sql3 As String
            sql3 = "UPDATE  TB_Detils_AznAddItem  SET No_Invoice ='" & Com_InvoiceNo2.Text & "'   WHERE   Ser_NO_StoresAdd ='" & Com_NoAzn.Text & "' and No_item ='" & rs2("No_item").Value & "'    "
            rs = Cnn.Execute(sql3)

            rs2.MoveNext()
        Loop
    End Sub

    Private Sub txt_Price_TextChanged(sender As Object, e As EventArgs) Handles txt_Price.TextChanged
        calcalator_invoice()
    End Sub
    Sub calcalator_invoice()
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single
        varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_Price.Text) * Val(1), 2)
        varDiscount = varTotalInvoice * Val(Txt_Discount.Text) / 100
        txt_valuediscount.Text = varTotalInvoice * Val(Txt_Discount.Text) / 100
        Txt_Total.Text = varTotalInvoice - varDiscount
    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        find_invoice()
    End Sub
    Sub find_invoice()
        vartable = "Vw_LookupInvoiceSal2"
        VarOpenlookup = 2727
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        find_hedar()
        find_detalis()
        'find_Invoice_Condation()
        Total_Sum()
        sum_tax()
    End Sub

    Sub find_hedar()
        On Error Resume Next


        sql2 = "SELECT     dbo.TB_Header_InvoicePrcheses.N_Discount,dbo.TB_Header_InvoicePrcheses.Value_Discount,dbo.TB_Header_InvoicePrcheses.Dis_Other,  dbo.TB_Header_InvoicePrcheses.Invoice_Type, dbo.TB_Header_InvoicePrcheses.tax_n, dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo, dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, " & _
        "                         dbo.TB_Header_InvoicePrcheses.Customer_No, dbo.TB_Header_InvoicePrcheses.PayStatus, dbo.Find_Suppliser2.Name, dbo.TB_Header_InvoicePrcheses.Salse_No,  " & _
        "        dbo.TB_Header_InvoicePrcheses.Notes, iif(dbo.TB_Header_InvoicePrcheses.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status " & _
        " FROM            dbo.TB_Header_InvoicePrcheses LEFT OUTER JOIN " & _
        "                         dbo.Find_Suppliser2 ON dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.Find_Suppliser2.Compny_Code AND dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.Find_Suppliser2.Code " & _
        " WHERE        (dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_InvoicePrcheses.Compny_Code = '" & VarCodeCompny & "') "



        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs3("Ser_InvoiceNo").Value)
            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            'Com_InvoiceNo3.Text = Trim(rs3("Ext_InvoiceNo").Value)
            txt_date.Value = Trim(rs3("InvoiceDate").Value)
            txt_Ntax2.Text = Trim(rs3("N_Discount").Value)
            txt_Dis2.Text = Trim(rs3("Value_Discount").Value)
            txt_OtherDiscount.Text = Trim(rs3("Dis_Other").Value)
            txt_AccountNo.Text = Trim(rs3("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs3("Name").Value)
            txt_Typeinv.Text = Trim(rs3("Invoice_Status").Value)
            If txt_Typeinv.Text = "مرحل" Then Cmd_RtInvoice.Enabled = True : Cmd_CloseInvoice.Enabled = False : txt_Typeinv.BackColor = Color.Green
            If txt_Typeinv.Text = "فاتورة مبدئية" Then Cmd_RtInvoice.Enabled = False : Cmd_CloseInvoice.Enabled = True : txt_Typeinv.BackColor = Color.Gray
            txt_Ntax.Text = Trim(rs3("Tax_N").Value)

            If Trim(rs3("Invoice_Type").Value) = 0 Then Com_Group_Item.Text = "غير شامل ضريبة"
            If Trim(rs3("Invoice_Type").Value) = 1 Then Com_Group_Item.Text = "شامل ضريبة"


            If Trim(rs3("Invoice_Status").Value) = 1 Then
                cmd_OpenGl.Enabled = True
                sql2 = " Select IDGenral               FROM dbo.Genralledger WHERE  (Typebill = 6) AND (Compny_Code = '" & VarCodeCompny & "') AND (RTRIM(No_Sand) = '" & Trim(Com_InvoiceNo2.Text) & "') and flgcancle=0 GROUP BY IDGenral"
                rs2 = Cnn.Execute(sql2)
                If rs2.EOF = False Then txt_OpenGl.Text = rs2("IDGenral").Value Else txt_OpenGl.Text = ""
            Else
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




        sql2 = " SELECT dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, dbo.BD_Unit.Name AS unit, dbo.BD_Item.Ex_Item AS CountItem, dbo.TB_Detalis_InvoicePrcheses.Quntity AS Quntity2, " & _
 "                  dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.TB_Detalis_InvoicePrcheses.Discount_Item, dbo.TB_Detalis_InvoicePrcheses.Value_Discount, ROUND(SUM(dbo.TB_Detalis_InvoicePrcheses.Quntity)  " & _
 "                  * dbo.TB_Detalis_InvoicePrcheses.Price_Item, 2) AS Total_Item2, dbo.BD_Stores.Name AS Stores, dbo.TB_Detalis_InvoicePrcheses.Order_Stores_No, dbo.TB_Detalis_InvoicePrcheses.AccountNo2,  " & _
 "                  RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName2, dbo.TB_Detalis_InvoicePrcheses.indx " & _
 " FROM     dbo.TB_Detalis_InvoicePrcheses INNER JOIN " & _
 "                  dbo.TB_Detils_AznAddItem ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.TB_Detils_AznAddItem.No_item AND dbo.TB_Detalis_InvoicePrcheses.Code_Stores = dbo.TB_Detils_AznAddItem.Code_Stores AND  " & _
 "                  dbo.TB_Detalis_InvoicePrcheses.Order_Stores_No = dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd LEFT OUTER JOIN " & _
 "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Detalis_InvoicePrcheses.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No_Update LEFT OUTER JOIN " & _
 "                  dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code LEFT OUTER JOIN " & _
 "                  dbo.BD_Stores ON dbo.TB_Detalis_InvoicePrcheses.Code_Stores = dbo.BD_Stores.Code LEFT OUTER JOIN " & _
 "                  dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code " & _
 " GROUP BY dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.BD_Stores.Name, dbo.TB_Detalis_InvoicePrcheses.Order_Stores_No,  " & _
 "        dbo.BD_Unit.Name, dbo.TB_Detalis_InvoicePrcheses.Discount_Item, dbo.TB_Detalis_InvoicePrcheses.Value_Discount, dbo.TB_Detalis_InvoicePrcheses.Order_Stores_No, dbo.TB_Detalis_InvoicePrcheses.Ex_Item, " & _
 "        dbo.TB_Detalis_InvoicePrcheses.Quntity, dbo.TB_Detalis_InvoicePrcheses.AccountNo2, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.TB_Detalis_InvoicePrcheses.indx, dbo.BD_Item.Ex_Item " & _
" HAVING (dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "')"


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الصنف"
        GridView6.Columns(2).Caption = "الوحدة"
        GridView6.Columns(3).Caption = "رقم التوصيف"
        GridView6.Columns(4).Caption = "الكمية"
        GridView6.Columns(5).Caption = "سعر الوحدة"
        GridView6.Columns(6).Caption = "نسبة الخصم"
        GridView6.Columns(7).Caption = "قيمة الخصم"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "المخزن"
        GridView6.Columns(10).Caption = "الاذن"
        GridView6.Columns(11).Caption = "رقم الحساب"
        GridView6.Columns(12).Caption = "اسم الحساب"

        GridView6.Columns(13).Visible = False
        'GridView6.Columns(5).Visible = False
        'GridView6.Columns(6).Visible = False

        Com_NoAzn.Text = rs("Order_Stores_No").Value

        'GridView6.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        'On Error Resume Next
        sum_tax()
        GridView6.BestFitColumns()
        'Mainmune.finwatinoderItem()
    End Sub
    Sub sum_tax()
        On Error Resume Next
        Dim vartax As Single
        vartax = txt_Ntax.Text
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_OtherDiscount.Text) - Val(txt_Dis2.Text) - Val(txt_Dis.Text), 2)
    End Sub
    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        'GridView6.Columns(0).Caption = "كود الصنف"
        'GridView6.Columns(1).Caption = "الصنف"
        'GridView6.Columns(2).Caption = "الوحدة"
        'GridView6.Columns(3).Caption = "رقم التوصيف"
        'GridView6.Columns(4).Caption = "الكمية"
        'GridView6.Columns(5).Caption = "سعر الوحدة"
        'GridView6.Columns(6).Caption = "نسبة الخصم"
        'GridView6.Columns(7).Caption = "قيمة الخصم"
        'GridView6.Columns(8).Caption = "الاجمالى"
        'GridView6.Columns(9).Caption = "المخزن"
        'GridView6.Columns(10).Caption = "الاذن"
        'GridView6.Columns(11).Caption = "رقم الحساب"
        'GridView6.Columns(12).Caption = "اسم الحساب"


        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        'txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        'varthiknis = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        'varwidth = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))

        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        com_Cru.Text = "جنية مصرى"
        txt_rat.Text = 1
        txt_Price.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Txt_Discount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        txt_valuediscount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        Txt_Total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        'txt_SalseOrder.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(14))
        Com_NoAzn.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))

        txt_AccountNo2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        txt_nameaccount2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))
        varindex = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(13))



        If txt_CodeItem.Text <> "" Then cmd_Edit.Enabled = True
        If txt_CodeItem.Text <> "" Then Cmd_Delete.Enabled = True


    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs)
        'Frm_AznSarf_old.Com_InvoiceNo2.Text = Com_NoAzn.Text
        'Frm_AznSarf_old.find_hedar()
        'Frm_AznSarf_old.find_detalis()
        'Frm_AznSarf_old.MdiParent = Mainmune
        'Frm_AznSarf_old.Show()



    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        'Frm_OrderSal.Com_InvoiceNo2.Text = txt_SalseOrder.Text
        Frm_OrderSal.find_hedar()
        Frm_OrderSal.find_detalis()
        Frm_OrderSal.MdiParent = Mainmune
        Frm_OrderSal.Show()
    End Sub


    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_CloseInvoice.Click
        If Len(Com_Group_Item.Text) = 0 Then MsgBox("من فضلك اختار نوع فاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Com_Group_Item.Text = "" Then MsgBox("يجب تحديد نوع الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView6.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

            If Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(11))) = "" Then MsgBox("من فضلك أختار حساب الايراد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        Next rowHandle


        sum_tax()
        saveGl()
        If Com_Group_Item.Text = "غير شامل ضريبة" Then vartypeinvoice = 0
        If Com_Group_Item.Text = "شامل ضريبة" Then vartypeinvoice = 1

        sql2 = "UPDATE  TB_Header_InvoicePrcheses  SET  Invoice_Type ='" & vartypeinvoice & "', N_Discount='" & txt_Ntax2.Text & "',Value_Discount='" & txt_Dis2.Text & "',Dis_Other='" & txt_OtherDiscount.Text & "',Tax_N='" & txt_Ntax.Text & "', Invoice_Status='" & 1 & "',PayStatus='" & VarStutas & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)

        '============================== TransactionHistoryCode 
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','8','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        find_hedar()
        find_detalis()
        Total_Sum()
        sum_tax()
        Cmd_CloseInvoice.Enabled = False
        Cmd_RtInvoice.Enabled = True
        Cmd_PrintInvoice.Enabled = True
    End Sub
    Sub saveGl()
        On Error Resume Next
        If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd3 As DateTime = txt_date.Value
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")

        lastgl()

        'If txt_Type.Text = "أجل" Then
        'find_tax()

        ''=============رقم مركز التكلفة
        'sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================
        find_tax()

        '=============رقم مركز التكلفة1
        sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================

        'If VarCodeCompny = 3 Then varcodeCostCenter2 = "401001"
        'If VarCodeCompny = 2 Then varcodeCostCenter1 = "102002"


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value


        '=======================================================المدين  من ح العملاء - او ح النقدية
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & txt_AccountNo.Text & "','" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & 6 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & varcode_Cru & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '================================================================

        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "'  ,N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & "6" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & varcode_Cru & "' ,'" & Txt_TotalAll.Text & "','" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)




        '        sql = "SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
        '"                         dbo.Setup_Acc_Group.AccountNo_Discount2,, dbo.Setup_Acc_Group.AccountNo_Prcheses " & _
        '" FROM            dbo.Setup_Acc_Group INNER JOIN " & _
        '"                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
        '" WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "

        sql = "     SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
     "                         dbo.Setup_Acc_Group.AccountNo_Discount2, dbo.Setup_Acc_Group.AccountNo_Prcheses " & _
     " FROM            dbo.Setup_Acc_Group LEFT OUTER JOIN " & _
     "                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND  " & _
     "                         dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code LEFT OUTER JOIN " & _
     "                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code " & _
     " WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "



        rs = Cnn.Execute(sql)



        'If Val(txt_OtherDiscount.Text) > 0 Then
        '    '=================================الخصم
        '    sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        '    " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Discount2").Value & "','" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & 1 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & 0 & "' ,'" & varcode_Cru & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        '    Cnn.Execute(sql)

        '    sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '     " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "'  ,N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & txt_OtherDiscount.Text & "',N'" & 0 & "',N'" & "1" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & 0 & "' ,'" & varcode_Cru & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        '    Cnn.Execute(sql)

        'End If




        '=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & rs("AccountNo_Sal").Value & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================

        'varcodeCostCenter2 = "401001"
        'VarAccountTax_Invoice

        '========================================================================== الدائن
        'vartaxitem = rs("TotalAll").Value * (txt_Ntax.Text) / 100

        sql2 = "SELECT Account_Tax, Compny_Code,Account_Tax2        FROM dbo.Tb_TaxInvoice"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then vartaxinvoice2 = rs2("Account_Tax").Value : vardiscount2 = rs2("Account_Tax2").Value


        If Val(txt_Dis2.Text) + Val(txt_OtherDiscount.Text) > 0 Then
            '=================================الخصم
            sql2 = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & vardiscount2 & "','" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & Val(txt_Dis2.Text) + Val(txt_OtherDiscount.Text) & "','" & 6 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & 0 & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Val(txt_Dis2.Text) + Val(txt_OtherDiscount.Text) & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql2)

            sql2 = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & vardiscount2 & "'  ,N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & Val(txt_Dis2.Text) + Val(txt_OtherDiscount.Text) & "',N'" & "6" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & 0 & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Val(txt_Dis2.Text) + Val(txt_OtherDiscount.Text) & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql2)

        End If




        Dim sql3 As String

        '==========================================================================
        Dim result2 As Integer = 0
        For rowHandle2 As Integer = 0 To GridView6.DataRowCount - 1

            sql3 = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
                " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & Trim(GridView6.GetRowCellValue(rowHandle2, GridView6.Columns(11))) & "','" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & Trim(GridView6.GetRowCellValue(rowHandle2, GridView6.Columns(8))) & "','" & 6 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Trim(GridView6.GetRowCellValue(rowHandle2, GridView6.Columns(8))) & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql3)
        Next rowHandle2
        '=====================================================================


        If Val(txt_Tax.Text) > 0 Then
            ''========================الضريبة
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
              " values  (N'" & varNoGL & "' ,N'" & vardate3 & "',N'" & vartaxinvoice2 & "',N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "' ,N'" & txt_Tax.Text & "',N'" & 6 & "',N'" & Com_InvoiceNo2.Text & "',N'" & 2 & "',N'" & 1 & "',N'" & varcodeCostCenter2 & "' ,N'" & varcode_Cru & "',N'" & 0 & "' ,N'" & txt_Tax.Text & "',N'" & VarCodeCompny & "',N'" & 1 & "',N'" & varcode_User & "')"
            Cnn.Execute(sql)

        End If


        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView6.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
            sql3 = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(11))) & "'  ,N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(8))) & "',N'" & "6" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(8))) & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql3)
        Next rowHandle



        If Val(txt_Tax.Text) > 0 Then

            ''================================الضريبة
            sql3 = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & vartaxinvoice2 & "'  ,N'" & "فاتورة مشتريات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_Tax.Text & "',N'" & "6" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql3)
        End If






        'rs.MoveNext()
        'Loop



        '========================================خصم عام




        'End If

        'gl_discountall()
        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        sum_tax()

    End Sub



    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_PrintInvoice.Click
        Frm_InvoicePrintPrchesess.Show()

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
        fill_cru()
        fill_Unit()
        'Com_Condation.Items.Add("دفع 100 % عن الاستلام نقدا")
        'Com_Condation.Items.Add("100 % بعد شهر")
        'Com_Condation.Items.Add("100 % بعد شهرين")
        'Com_Condation.Items.Add("100 % بعد 3 شهور")
        'Com_Condation.Items.Add("50 % نقدا 50 % بعد شهر")

        fill_TypeInvoice()
        txt_DateIN.Text = DateTime.Now.ToString("yyyy/MM/dd")
        txt_DateOut.Text = DateTime.Now.ToString("yyyy/MM/dd")
        TabPane1.SelectedPageIndex = 0
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
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102))  and Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"


        calcalator_invoice()
    End Sub

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs)
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        'If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True

    End Sub

    Private Sub Op4_CheckedChanged(sender As Object, e As EventArgs)
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        'If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True
    End Sub

    Private Sub Cmd_LookupSalse_Click(sender As Object, e As EventArgs)
        VarOpenlookup3 = 27
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub txt_SalseOrder_TextChanged(sender As Object, e As EventArgs)
        'If txt_SalseOrder.Text <> "" Then SimpleButton2.Enabled = True Else SimpleButton2.Enabled = False
        'If Com_NoAzn.Text <> "" Then SimpleButton5.Enabled = True Else SimpleButton5.Enabled = False
    End Sub

    Private Sub Com_NoAzn_TextChanged(sender As Object, e As EventArgs) Handles Com_NoAzn.TextChanged
        'If txt_SalseOrder.Text <> "" Then SimpleButton2.Enabled = True Else SimpleButton2.Enabled = False
        'If Com_NoAzn.Text <> "" Then SimpleButton5.Enabled = True Else SimpleButton5.Enabled = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        VarOpenlookup2 = 2424
        Frm_LookUpCustomer.Find_Suppliser()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click

        'If varcode_User = 1 Then
        'Else
        '    Dim dd4 As DateTime = txt_date.Text
        '    Dim vardate4 As String
        '    vardate4 = dd4.ToString("dd/MM/yyyy")
        '    '=======================================================
        '    Dim dd3 As DateTime = var_GetDateLive
        '    Dim vardate3 As String
        '    vardate3 = dd3.ToString("MM/dd/yyyy")
        '    If vardate3 <> vardate4 Then MsgBox("الفاتورة فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '    '=========================================================

        'End If


        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن التعديل الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart software")
        If txt_Typeinv.Text = "فاتورة مبدئية" Then

            find_varcode()

            Dim dd As DateTime = txt_date.Value
            Dim vardateoder As String
            vardateoder = dd.ToString("MM-d-yyyy")

            If Com_Group_Item.Text = "غير شامل ضريبة" Then vartypeinvoice = 0
            If Com_Group_Item.Text = "شامل ضريبة" Then vartypeinvoice = 1



            sql2 = "UPDATE  TB_Header_InvoicePrcheses  SET Invoice_Type ='" & vartypeinvoice & "', Customer_No ='" & txt_AccountNo.Text & "', InvoiceDate ='" & vardateoder & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
            rs = Cnn.Execute(sql2)


            find_varcode()


            sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodStores = Trim(rs("code").Value)

            If CheckBox1.Checked = True Then
                sql = "UPDATE  TB_Detalis_InvoicePrcheses  SET   AccountNo2 ='" & txt_AccountNo2.Text & "', Quntity ='" & txt_Qty.Text & "', Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Code_cur ='" & 1 & "',Rat_Invoice ='" & txt_rat.Text & "' WHERE   No_Item = '" & varcodeitem & "'  and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' and indx='" & varindex & "' "
                rs = Cnn.Execute(sql)

            Else
                sql = "UPDATE  TB_Detalis_InvoicePrcheses  SET AccountNo2 ='" & txt_AccountNo2.Text & "', Quntity ='" & txt_Qty.Text & "', Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Code_cur ='" & varcode_Cru & "',Rat_Invoice ='" & txt_rat.Text & "' WHERE  No_Item = '" & varcodeitem & "'  and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' and indx='" & varindex & "' "
                rs = Cnn.Execute(sql)

            End If

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

            MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        End If
        'find_invoice()
        find_hedar()
        find_detalis()
        find_tax()

        Total_Sum()
        sum_tax()
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
        sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = Trim(rs("code").Value)

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
        'If varcode_User = 1 Then
        'Else
        '    Dim dd4 As DateTime = txt_date.Text
        '    Dim vardate4 As String
        '    vardate4 = dd4.ToString("dd/MM/yyyy")
        '    '=======================================================
        '    Dim dd3 As DateTime = var_GetDateLive
        '    Dim vardate3 As String
        '    vardate3 = dd3.ToString("MM/dd/yyyy")
        '    If vardate3 <> vardate4 Then MsgBox("الفاتورة فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '    '=========================================================

        'End If


        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن حذف الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart software")

        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detalis_InvoicePrcheses  WHERE  No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' and indx ='" & varindex & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                Dim sql3 As String
                sql3 = "UPDATE  TB_Detils_AznAddItem  SET No_Invoice ='" & 0 & "'   WHERE   Ser_NO_StoresAdd ='" & Com_NoAzn.Text & "' and No_item = '" & varcodeitem & "'     "
                rs = Cnn.Execute(sql3)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                Total_Sum()
        End Select
    End Sub

    Private Sub Cmd_RtInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_RtInvoice.Click
        If Com_Group_Item.Text = "" Then MsgBox("يجب تحديد نوع الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        Dim x As String
        x = MsgBox("هل تريد ارجاع الفاتورة", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "UPDATE  TB_Header_InvoicePrcheses  SET Invoice_Status = '" & 0 & "'  WHERE Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "'   and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                'sql = "Delete Genralledger  WHERE Typebill ='" & 6 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                'rs = Cnn.Execute(sql)

                sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & Com_InvoiceNo2.Text & "'  and Typebill ='" & 6 & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)




                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 6 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','9','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم ارجاع الفاتورة  ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End Select

        find_hedar()
        find_detalis()
        find_Invoice_Condation()
        Total_Sum()
        sum_tax()
    End Sub


    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        vartable = "BD_CondationOrder"
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
        '        sql = "Delete Tb_CondationInvoice  WHERE Invoice_No = '" & Com_InvoiceNo3.Text & "' and ID ='" & varID & "' and Compny_Code ='" & VarCodeCompny & "' "
        '        rs = Cnn.Execute(sql)


        '        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        'End Select
        'find_Invoice_Condation()
    End Sub

    Private Sub cmd_saveCondationInvoice_Click(sender As Object, e As EventArgs)
        'If Len(Com_InvoiceNo3.Text) = 0 Then MsgBox("من فضلك أختار رقم الفاتورة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        'sql = "INSERT INTO Tb_CondationInvoice (Invoice_No, Compny_Code,Code_Codation) " & _
        '  " values  ('" & Com_InvoiceNo3.Text & "' ,'" & VarCodeCompny & "','" & varcode_Condation & "')"
        'Cnn.Execute(sql)
        'MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        'txt_Discrption2.Text = ""
        'find_Invoice_Condation()

    End Sub
    Sub find_Invoice_Condation()
        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()




        ''sql2 = "   SELECT         ID ,Order_NO, Discrption     FROM dbo.Tb_CondationOrder WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & Com_InvoiceNo3.Text & "')"


        'sql2 = " SELECT        dbo.Tb_CondationInvoice.ID, dbo.Tb_CondationInvoice.Invoice_No, dbo.BD_CondationOrder.Name " & _
        '         " FROM            dbo.Tb_CondationInvoice INNER JOIN " & _
        '         "                         dbo.BD_CondationOrder ON dbo.Tb_CondationInvoice.Code_Codation = dbo.BD_CondationOrder.Code AND dbo.Tb_CondationInvoice.Compny_Code = dbo.BD_CondationOrder.Compny_Code " & _
        '         " WHERE        (dbo.Tb_CondationInvoice.Invoice_No ='" & Com_InvoiceNo3.Text & "') AND (dbo.Tb_CondationInvoice.Compny_Code = '" & VarCodeCompny & "') "

        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "350"
        ''GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        ''GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True
        'GridView1.Columns(0).Caption = "م"
        'GridView1.Columns(1).Caption = "فاتورة رقم"
        'GridView1.Columns(2).Caption = "شروط الدفع"


        ''If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()



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

    Private Sub txt_Ntax_TextChanged(sender As Object, e As EventArgs) Handles txt_Ntax.TextChanged
        'calcalator_invoice()
        On Error Resume Next
        Dim vartax As Single
        vartax = txt_Ntax.Text
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_OtherDiscount.Text) - Val(txt_Dis2.Text), 2)
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

                    '===================================================
                    SQL4 = "select * from TB_Detalis_InvoicePrcheses where Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "'"
                    rs3 = Cnn.Execute(SQL4)
                    Do While Not rs3.EOF

                        sql = "UPDATE TB_Detils_AznAddItem set No_Invoice ='" & 0 & "'  WHERE  No_item ='" & rs3("No_Item").Value & "' and  Ser_NO_StoresAdd ='" & Com_NoAzn.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                        rs = Cnn.Execute(sql)
                        rs3.MoveNext()
                    Loop



                    sql = "Delete TB_Detalis_InvoicePrcheses  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    '===================================حذف من المخزن
                    sql = "Delete TB_Header_InvoicePrcheses  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'   "
                    rs = Cnn.Execute(sql)


                    sql = "Delete MovmentStatement  WHERE TypeBill ='" & 6 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)


                    sql = "Delete Genralledger  WHERE Typebill ='" & 6 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)



                    '============================== TransactionHistoryCode 
                    sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','6','10','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                    rs2 = Cnn.Execute(sql2)
                    '==============================

                    MsgBox("تم حذف الفاتورة", MsgBoxStyle.Information, "Css Solution Software Module")
                    find_detalis()
                    find_hedar()
            End Select
        End If
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
    End Sub

    Private Sub txt_AccountNo_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNo.TextChanged

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
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

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
     
        If Com_NoAzn.Text = "" Then MsgBox("من فضلك أختار رقم الاذن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Frm_Azn_AddItem.Com_InvoiceNo2.Text = Com_NoAzn.Text
        Frm_Azn_AddItem.find_hedar()
        Frm_Azn_AddItem.find_detalis()
        Frm_Azn_AddItem.MdiParent = Mainmune
        Frm_Azn_AddItem.Show()


    End Sub

    Private Sub txt_Ntax2_TextChanged(sender As Object, e As EventArgs) Handles txt_Ntax2.TextChanged
        On Error Resume Next
        Dim vardis As Single
        vardis = txt_Ntax2.Text
        txt_Dis2.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vardis / 100), 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_OtherDiscount.Text) - Val(txt_Dis2.Text), 2)

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If CheckBox1.Checked = True Then
            varcode_form = 100100
            VARTBNAME = " Vw_AllDataItem"
            Lookupitem.Fill_Alldata()
            Lookupitem.ShowDialog()
        Else
            MsgBox("من فضلك اختار فروق الموازين اولا لفتح الاختيار", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        End If
    End Sub

    Private Sub Txt_Discount_TextChanged(sender As Object, e As EventArgs) Handles Txt_Discount.TextChanged
        calcalator_invoice()
    End Sub

   
    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        varcode_form = 410410
        Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()
        Frm_LookUpAccount.Show()

    End Sub

    Private Sub cmd_Find_Click(sender As Object, e As EventArgs) Handles cmd_Find.Click
        find_Prcheses()
    End Sub
    Sub find_Prcheses()
        'On Error Resume Next



        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_DateIN.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_DateIN.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_DateOut.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_DateOut.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay




        sql2 = "  SELECT Customer_No, Supliser_Name, Ext_InvoiceNo, InvoiceDate, Total_Ivoice, tax, Discount, Dis_Other, alldiscount, Total_BeforTax - alldiscount AS alltotal, Supliser_FileNoTax " & _
  " FROM     dbo.Vw_AllPrchesess " & _
  " WHERE  (InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)


        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "رقم الحساب"
        GridView3.Columns(1).Caption = "أسم الحساب"
        GridView3.Columns(2).Caption = "رقم الفاتورة"
        GridView3.Columns(3).Caption = "تاريخ الفاتورة"
        GridView3.Columns(4).Caption = "اجمالى قبل الضريبة"
        GridView3.Columns(5).Caption = "الضريبة"
        GridView3.Columns(6).Caption = "خصم ارياح تجارية"
        GridView3.Columns(7).Caption = "خصومات اخرى"
        GridView3.Columns(8).Caption = "اجمالى الخصومات"
        GridView3.Columns(9).Caption = "الصافى"
        GridView3.Columns(10).Caption = "رقم التسجيل الضريبى"

        GridView3.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub Cmd_PrintScrren_Click(sender As Object, e As EventArgs) Handles Cmd_PrintScrren.Click
        GridView3.ShowRibbonPrintPreview()

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle

        Com_InvoiceNo2.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))


        find_hedar()
        find_detalis()
        find_Invoice_Condation()
        Total_Sum()
        sum_tax()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then SimpleButton2.Enabled = True
        If CheckBox1.Checked = False Then SimpleButton2.Enabled = False

        If CheckBox1.Checked = False Then cmd_FindItem.Enabled = True
        If CheckBox1.Checked = True Then cmd_FindItem.Enabled = False

    End Sub
End Class