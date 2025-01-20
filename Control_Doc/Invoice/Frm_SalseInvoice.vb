Imports ADODB
Imports System.Data.OleDb

Public Class Frm_SalseInvoice
    Dim varOrder_Stores As Integer
    Dim varcodeitem, varID As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim xx As String
    Dim VarItem_EX, VarStutas, var_No_Invoice_ser, var_No_Invoice_EXT As String
    Dim x As String
    Dim vartaxinvoice, vartaxitem As Single


    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs) Handles cmd_FindItem.Click
        If IsDate(txt_date.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If txt_Typeinv.Text = "مرحل" Then
            MsgBox("لايمكن اضافة اصناف الفاتورة مرحلة", MsgBoxStyle.Critical, "Css")

        Else

            If CheckBox5.Checked = True Then


                If Op3.Checked = True Then
                    typeInvoice = 1
                    Frm_Lookup_AznSarf.Close()
                    Frm_Lookup_AznSarf.MdiParent = Mainmune
                    Frm_Lookup_AznSarf.Search()
                    Frm_Lookup_AznSarf.Show()
                End If

                If Op4.Checked = True Then
                    typeInvoice = 2
                    Frm_Lookup_AznSarf.Close()
                    Frm_Lookup_AznSarf.MdiParent = Mainmune
                    Frm_Lookup_AznSarf.Search2()
                    Frm_Lookup_AznSarf.Show()
                End If

                If Com_InvoiceNo.Text = "" Then
                    MsgBox("من فضلك أدخل رقم الفاتورة", MsgBoxStyle.Critical, "Css")
                    Exit Sub
                Else
                    varNoInvoice = Com_InvoiceNo.Text
                    varNoInvoice2 = Com_InvoiceNo2.Text
                    Frm_Lookup_AznSarf.find_detalis()
                End If


            


            Else
                Frm_LookupAzn20.Close()
                Frm_LookupAzn20.MdiParent = Mainmune
                Frm_LookupAzn20.Show()
               

            End If
        End If
    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs) Handles txt_nameaccount.TextChanged
        'sql = "  SELECT        Name, Code      FROM dbo.FindCustomer WHERE        (Name = '" & txt_nameaccount.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_AccountNo.Text = rs("code").Value Else txt_AccountNo.Text = ""
    End Sub

    Private Sub txt_NameSalse_TextChanged(sender As Object, e As EventArgs) Handles txt_NameSalse.TextChanged
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
        'fill_TypeInvoice()
        find_hedar()
        find_detalis()
    End Sub

    Sub last_Data()

        'sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code           TB_Header_InvoiceSal    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "

        sql = "     SELECT        MAX(Ser_InvoiceNo) AS MaxMaim, Compny_Code       FROM dbo.TB_Header_InvoiceSal GROUP BY Compny_Code HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) AND (Compny_Code = '" & VarCodeCompny & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "INV" + Com_InvoiceNo.Text

        Else
            'If VarCodeCompny = 3 Then Com_InvoiceNo.Text = 1

            'If VarCodeCompny = 2 Then Com_InvoiceNo.Text = "1"
            If VarCodeCompny = 1 Then Com_InvoiceNo.Text = "1"

            'If VarCodeCompny = 2 Then Com_InvoiceNo2.Text = "INV" + "1"
            If VarCodeCompny = 1 Then Com_InvoiceNo2.Text = "INV" + "1"


        End If



    End Sub


    Sub Total_Sum()
        'find_tax()
        Dim total, total_discount As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(11))
            total_discount += GridView6.GetRowCellValue(i, GridView6.Columns(10))
        Next
        txt_totalPrice.Text = Math.Round(total, 3)
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * vartaxinvoice / 100, 3)
        txt_Dis.Text = Math.Round(total_discount, 3)
        Txt_TotalAll.Text = Math.Round(total + Val(txt_Tax.Text) - total_discount, 1)

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
        Com_NoAzn.Text = ""
        txt_Dis.Text = ""
        Txt_TotalAll.Text = ""
        txt_OpenGl.Text = ""
        Com_Group_Item.Text = ""
        txt_Ntax2.Text = "0"
        txt_Ntax3.Text = "0"

        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click

        If Com_Group_Item.Text = "فاتورة ضريبية" Then vartypeinvoice = 1
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then vartypeinvoice = 0

        save_invoice()

    End Sub
    Sub save_invoice()

        sql2 = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            'last_Data()

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
        sql2 = "select * from Tb_TaxInvoice where  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then VarAccountTax_Invoice = rs("Account_Tax").Value Else vartaxinvoice = "0"
    End Sub
    Sub save_Invoice_H()
        'On Error Resume Next
        'DateTime.Now.ToString("yyyy/MM/dd")
        Dim dd As DateTime = txt_date.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_InvoiceSal (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & vartypeinvoice & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
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

        sql = "INSERT INTO TB_Detalis_InvoiceSal (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice) " & _
              " values  ('" & varNo_Azn & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & varcodStores & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & varcode_Cru & "','" & txt_rat.Text & "')"
        Cnn.Execute(sql)

        Dim sql3 As String
        sql3 = "UPDATE  TB_Detils_AznItem_Stores  SET No_Invoice ='" & Com_InvoiceNo2.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Order_Stores_NO ='" & varNo_Azn & "'    "
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
        find_invoice()
        GridView6.BestFitColumns()
    End Sub
    Sub find_invoice()
        vartable = "Vw_LookupInvoiceSal"
        VarOpenlookup = 27
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        Com_NoAzn.Text = ""
        find_hedar()
        find_detalis()
        find_Invoice_Condation()
        Total_Sum()
        sum_tax()
    End Sub

    Sub find_hedar()
        On Error Resume Next
        sql2 = " SELECT     dbo.TB_Header_InvoiceSal.Tax_N,dbo.TB_Header_InvoiceSal.Ser_InvoiceNo, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.TB_Header_InvoiceSal.Customer_No,dbo.TB_Header_InvoiceSal.PayStatus, dbo.FindCustomer.Name,  " & _
 "                         dbo.TB_Header_InvoiceSal.Salse_No, dbo.Emp_employees.Emp_Name, iif(dbo.TB_Header_InvoiceSal.Invoice_Type='1', 'مغلق', 'جديد') AS Type, iif(dbo.TB_Header_InvoiceSal.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status,  " & _
 "        dbo.TB_Header_InvoiceSal.Notes,dbo.TB_Header_InvoiceSal.NS_2,dbo.TB_Header_InvoiceSal.NS_Other,dbo.TB_Header_InvoiceSal.Dis_Item,dbo.TB_Header_InvoiceSal.Dis_2,dbo.TB_Header_InvoiceSal.Dis_Other,dbo.TB_Header_InvoiceSal.Invoice_Type " & _
" FROM            dbo.TB_Header_InvoiceSal INNER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_InvoiceSal.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_InvoiceSal.Compny_Code = dbo.FindCustomer.Compny_Code INNER JOIN  " & _
"                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code  " & _
 " WHERE        (dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') and dbo.TB_Header_InvoiceSal.Compny_Code = '" & VarCodeCompny & "' "

        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then

            var_No_Invoice_ser = Trim(rs3("Ser_InvoiceNo").Value)
            var_No_Invoice_EXT = Trim(rs3("Ext_InvoiceNo").Value)

            Com_InvoiceNo.Text = Trim(rs3("Ser_InvoiceNo").Value)
            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            Com_InvoiceNo3.Text = Trim(rs3("Ext_InvoiceNo").Value)
            txt_AccountNo.Text = Trim(rs3("Customer_No").Value)
            txt_date.Text = Trim(rs3("InvoiceDate").Value)
            txt_Notes.Text = Trim(rs3("Notes").Value)
            txt_CodeSalse.Text = Trim(rs3("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs3("Emp_Name").Value)

            txt_nameaccount.Text = Trim(rs3("Name").Value)
            txt_Typeinv.Text = Trim(rs3("Invoice_Status").Value)
            If txt_Typeinv.Text = "مرحل" Then Cmd_RtInvoice.Enabled = True : Cmd_CloseInvoice.Enabled = False : txt_Typeinv.BackColor = Color.Green : txt_Ntax2.Enabled = False : txt_Ntax3.Enabled = False
            If txt_Typeinv.Text = "فاتورة مبدئية" Then Cmd_RtInvoice.Enabled = False : Cmd_CloseInvoice.Enabled = True : txt_Typeinv.BackColor = Color.Gray : txt_Ntax2.Enabled = True : txt_Ntax3.Enabled = True
            txt_Ntax.Text = Trim(rs3("Tax_N").Value)

            txt_Ntax2.Text = Trim(rs3("NS_2").Value)
            txt_Ntax3.Text = Trim(rs3("NS_Other").Value)
            txt_Dis.Text = Trim(rs3("Dis_Item").Value)
            txt_Dis2.Text = Trim(rs3("Dis_2").Value)
            txt_OtherDiscount.Text = Trim(rs3("Dis_Other").Value)

            If Trim(rs3("Invoice_Type").Value) = 0 Then Com_Group_Item.Text = "فاتورة غير ضريبية"
            If Trim(rs3("Invoice_Type").Value) = 1 Then Com_Group_Item.Text = "فاتورة ضريبية"


            If Trim(rs3("Invoice_Status").Value) = 1 Then
                cmd_OpenGl.Enabled = True
                sql2 = " Select IDGenral               FROM dbo.Genralledger WHERE  (Typebill = 2) AND (Compny_Code = '" & VarCodeCompny & "') AND (RTRIM(No_Sand) = '" & Trim(Com_InvoiceNo2.Text) & "') and flgcancle=0 GROUP BY IDGenral"
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



        sql2 = "SELECT        No_Item, Ex_Item, Name, Quntity, Unit, NameStores, Price_Item,Name_Cru,Rat_Invoice, Discount_Item, Value_Discount, Total_Item, Order_Stores_No,Seril_No     FROM dbo.Vw_DetilsInvoice" & _
            " where  (dbo.Vw_DetilsInvoice.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') AND (dbo.Vw_DetilsInvoice.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        'GridView6.Columns(0).Width = "75"
        'GridView6.Columns(1).Width = "100"
        'GridView6.Columns(2).Width = "200"
        'GridView6.Columns(3).Width = "50"
        'GridView6.Columns(4).Width = "100"
        'GridView6.Columns(5).Width = "120"
        'GridView6.Columns(6).Width = "70"
        'GridView6.Columns(7).Width = "70"
        'GridView6.Columns(8).Width = "60"
        'GridView6.Columns(9).Width = "50"
        'GridView6.Columns(10).Width = "50"
        'GridView6.Columns(11).Width = "100"
        'GridView6.Columns(12).Width = "70"


        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

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
        'GridView6.Columns(12).Caption = "نوع الصنف"
        GridView6.Columns(12).Caption = "رقم الاذن"
        GridView6.Columns(13).Caption = "م"
        'GridView6.Columns(14).Caption = "م"


        'GridView6.Columns(14).Visible = False
        GridView6.Columns(13).Visible = False
        'GridView6.Columns(12).Visible = False
        GridView6.Columns(9).Visible = False
        'GridView6.Columns(10).Visible = False
        'GridView6.Columns(15).Visible = False
        GridView6.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView6.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        'On Error Resume Next
        sum_tax()
        'Mainmune.finwatinoderItem()
    End Sub
    Sub sum_tax()
        On Error Resume Next
        Dim vartax As Single
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then vartax = 0 : txt_Ntax.Text = 0
        If Com_Group_Item.Text = "فاتورة ضريبية" Then vartax = txt_Ntax.Text

        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then txt_Tax.Text = 0 : txt_Ntax.Text = 0
        If Com_Group_Item.Text = "فاتورة ضريبية" Then txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)

        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_Dis.Text) - Val(txt_Dis2.Text) - Val(txt_OtherDiscount.Text), 2)
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
        txt_SalseOrder.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(14))
        Com_NoAzn.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))
        var_serilNO_inv = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(13))

        'If txt_CodeItem.Text <> "" Then cmd_Edit.Enabled = True
        'If txt_CodeItem.Text <> "" Then Cmd_Delete.Enabled = True




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
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click

        sql = " select * from Vw_Lookup_AznItem where Ser_Order_Stores ='" & Com_NoAzn.Text & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then



            Frm_AznSarf2.Com_InvoiceNo2.Text = Com_NoAzn.Text
            Frm_AznSarf2.find_hedar()
            Frm_AznSarf2.find_detalis2()
            Frm_AznSarf2.MdiParent = Mainmune
            Frm_AznSarf2.Show()
        Else


            Frm_AznSarf.Com_InvoiceNo2.Text = Com_NoAzn.Text
            Frm_AznSarf.find_hedar()
            Frm_AznSarf.find_detalis()
            Frm_AznSarf.MdiParent = Mainmune
            Frm_AznSarf.Show()

        End If


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Frm_OrderData.Com_InvoiceNo2.Text = txt_SalseOrder.Text
        Frm_OrderData.find_hedar()
        Frm_OrderData.find_detalis()
        Frm_OrderData.MdiParent = Mainmune
        Frm_OrderData.Show()
    End Sub


    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_CloseInvoice.Click
        Dim varinvoicetype As Integer
        If Len(Com_Group_Item.Text) = 0 Then MsgBox("من فضلك اختار نوع فاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        sum_tax()

        saveGl()

        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then varinvoicetype = 0
        If Com_Group_Item.Text = "فاتورة ضريبية" Then varinvoicetype = 1

        sql2 = "UPDATE  TB_Header_InvoiceSal  SET Tax_N='" & txt_Ntax.Text & "',Invoice_Type ='" & varinvoicetype & "' , Invoice_Status='" & 1 & "',PayStatus='" & VarStutas & "',NS_2='" & txt_Ntax2.Text & "',NS_Other='" & txt_Ntax3.Text & "',Dis_Item='" & txt_Dis.Text & "' ,Dis_2 ='" & txt_Dis2.Text & "' ,Dis_Other ='" & txt_OtherDiscount.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)

        '============================== TransactionHistoryCode 
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','8','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        find_hedar()
        find_detalis()
        find_Invoice_Condation()
        Total_Sum()
        sum_tax()
        Cmd_CloseInvoice.Enabled = False
        Cmd_RtInvoice.Enabled = True
        Cmd_PrintInvoice.Enabled = True
    End Sub
    Sub saveGl()
        'On Error Resume Next
        'If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'Dim dd3 As DateTime = txt_date.Text
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM-d-yyyy")

        'lastgl()
        'On Error Resume Next
        ''If txt_Type.Text = "أجل" Then
        ''find_tax()

        ' ''=============رقم مركز التكلفة
        ''sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        ''rs2 = Cnn.Execute(sql)
        ''If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ' ''=============================
        'find_tax()

        ''=============رقم مركز التكلفة1
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================



        ''=======================================================المدين  من ح العملاء - او ح النقدية
        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & txt_AccountNo.Text & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        'Cnn.Execute(sql)

        ''================================================================
        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '" values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & Txt_TotalAll.Text & "','" & 0 & "','" & VarCodeCompny & "')"
        'Cnn.Execute(sql)



        ''sql = "SELECT        dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) AS TotalAll, dbo.Setup_Acc_Group.AccountNo_Sal, " & _
        ''"                         dbo.Setup_Acc_Group.AccountNo_Discount2, dbo.TB_Detalis_InvoiceSal.Discount_Item " & _
        ''" FROM            dbo.BD_ITEM INNER JOIN " & _
        ''"                         dbo.TB_Detalis_InvoiceSal ON dbo.BD_ITEM.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code AND dbo.BD_ITEM.Ex_Item = dbo.TB_Detalis_InvoiceSal.Ex_Item INNER JOIN " & _
        ''"                         dbo.Tb_TypeItemList ON dbo.BD_ITEM.TypeItemList2 = dbo.Tb_TypeItemList.Code INNER JOIN " & _
        ''"                         dbo.Setup_Acc_Group ON dbo.Tb_TypeItemList.Code = dbo.Setup_Acc_Group.Code_Group " & _
        ''" GROUP BY dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.Setup_Acc_Group.AccountNo_Discount2, " & _
        ''"        dbo.TB_Detalis_InvoiceSal.Discount_Item " & _
        ''" HAVING        (dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') "

        ''rs = Cnn.Execute(sql)
        ''Do While Not rs.EOF


        'sql = " SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
        '        "                         dbo.Setup_Acc_Group.AccountNo_Discount2 " & _
        '        " FROM            dbo.Setup_Acc_Group INNER JOIN " & _
        '        "                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code INNER JOIN " & _
        '        "                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
        '        " WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "

        'rs = Cnn.Execute(sql)



        'If Val(txt_OtherDiscount.Text) > 0 Then
        '    '=================================الخصم
        '    sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '    " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Discount2").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & 0 & "' ,'" & 1 & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        '    Cnn.Execute(sql)

        '    sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '     " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & txt_OtherDiscount.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & 0 & "' ,'" & 1 & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        '    Cnn.Execute(sql)

        'End If




        ''=============رقم مركز التكلفة2
        ''sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & rs("AccountNo_Sal").Value & "')  and Compny_Code ='" & VarCodeCompny & "'"
        ''rs2 = Cnn.Execute(sql)
        ''If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        ''=============================

        'If VarCodeCompny = 3 Then varcodeCostCenter2 = "401001"
        'If VarCodeCompny = 2 Then varcodeCostCenter2 = "102002"
        ''VarAccountTax_Invoice

        ''========================================================================== الدائن
        ''vartaxitem = rs("TotalAll").Value * (txt_Ntax.Text) / 100

        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '    " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Sal").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "','" & 1 & "')"
        'Cnn.Execute(sql)


        ''========================الضريبة
        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '  " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & VarAccountTax_Invoice & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "','" & 1 & "')"
        'Cnn.Execute(sql)





        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        ' " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Sal").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_totalPrice.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "' )"
        'Cnn.Execute(sql)


        ''================================الضريبة
        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        ' " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & VarAccountTax_Invoice & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_Tax.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "' )"
        'Cnn.Execute(sql)



        ''rs.MoveNext()
        ''Loop



        ''========================================خصم عام




        ''End If

        ''gl_discountall()
        'MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'sum_tax()
        'On Error Resume Next
        'On Error Resume Next
        If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd3 As DateTime = txt_date.Text
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

        ''=============رقم مركز التكلفة1
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================

        varcodeCostCenter1 = "102001"

        '=======================================================المدين  من ح العملاء - او ح النقدية
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & txt_AccountNo.Text & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & Txt_TotalAll.Text & "','" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)



        'sql = "SELECT        dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, SUM(dbo.TB_Detalis_InvoiceSal.Total_Item) AS TotalAll, dbo.Setup_Acc_Group.AccountNo_Sal, " & _
        '"                         dbo.Setup_Acc_Group.AccountNo_Discount2, dbo.TB_Detalis_InvoiceSal.Discount_Item " & _
        '" FROM            dbo.BD_ITEM INNER JOIN " & _
        '"                         dbo.TB_Detalis_InvoiceSal ON dbo.BD_ITEM.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code AND dbo.BD_ITEM.Ex_Item = dbo.TB_Detalis_InvoiceSal.Ex_Item INNER JOIN " & _
        '"                         dbo.Tb_TypeItemList ON dbo.BD_ITEM.TypeItemList2 = dbo.Tb_TypeItemList.Code INNER JOIN " & _
        '"                         dbo.Setup_Acc_Group ON dbo.Tb_TypeItemList.Code = dbo.Setup_Acc_Group.Code_Group " & _
        '" GROUP BY dbo.BD_ITEM.TypeItemList2, dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo, dbo.Tb_TypeItemList.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.Setup_Acc_Group.AccountNo_Discount2, " & _
        '"        dbo.TB_Detalis_InvoiceSal.Discount_Item " & _
        '" HAVING        (dbo.TB_Detalis_InvoiceSal.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') "

        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF


        sql = "SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
"                         dbo.Setup_Acc_Group.AccountNo_Discount2, dbo.Setup_Acc_Group.AccountNo_Discount1 " & _
" FROM            dbo.Setup_Acc_Group INNER JOIN " & _
"                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code INNER JOIN " & _
"                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
" WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "

        rs = Cnn.Execute(sql)



        If Val(txt_Dis.Text) > 0 Or Val(txt_OtherDiscount.Text) > 0 Then
            '=================================الخصم
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Discount1").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Val(txt_Dis.Text) + Val(txt_OtherDiscount.Text) & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Val(txt_Dis.Text) + Val(txt_OtherDiscount.Text) & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount1").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Val(txt_Dis.Text) + Val(txt_OtherDiscount.Text) & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Val(txt_Dis.Text) + Val(txt_OtherDiscount.Text) & "' ,'" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

        End If


        If Val(txt_Dis2.Text) > 0 Then
            '=================================الخصم
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Discount2").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Val(txt_Dis2.Text) & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & txt_Dis2.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & txt_Dis2.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & varcodeCostCenter1 & "' ,'" & 1 & "','" & txt_Dis2.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

        End If


        '=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & rs("AccountNo_Sal").Value & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================

        varcodeCostCenter2 = "102001"
        'VarAccountTax_Invoice

        '========================================================================== الدائن
        'vartaxitem = rs("TotalAll").Value * (txt_Ntax.Text) / 100
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
                " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Sal").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)


        '========================الضريبة
        If txt_Tax.Text > 0 Then
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
              " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & VarAccountTax_Invoice & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
        End If



        If txt_Tax.Text > 0 Then
            '================================الضريبة
            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & VarAccountTax_Invoice & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_Tax.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

        End If

        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
          " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Sal").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_totalPrice.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "' )"
        Cnn.Execute(sql)

        'rs.MoveNext()
        'Loop



        '========================================خصم عام




        'End If

        'gl_discountall()
        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        sum_tax()
        Total_Sum()
    End Sub



    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_PrintInvoice.Click
    

        If CheckEng.Checked = True Then
            vardisplayReport = 255
            Report_InvoiceEng.Show()



        ElseIf CheckNewArbLogo.Checked = True Then
            varcondation1 = ""
            varcondation2 = ""
            '============================================ condation 1
            sql2 = "   SELECT        Name, Compny_Code, Invoice_No          FROM dbo.Vw_Condation1 WHERE        (Invoice_No = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varcondation1 = rs2("name").Value
            '============================================================== condation 2
            sql2 = "   SELECT        Name, Compny_Code, Invoice_No          FROM dbo.Vw_Condation2 WHERE        (Invoice_No = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varcondation2 = rs2("name").Value


            vardisplayReport = 260
            Report_InvoiceEng.Show()

        ElseIf CheckNewwithoutlogo.Checked = True Then
            varcondation1 = ""
            varcondation2 = ""
            '============================================ condation 1
            sql2 = "   SELECT        Name, Compny_Code, Invoice_No          FROM dbo.Vw_Condation1 WHERE        (Invoice_No = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varcondation1 = rs2("name").Value
            '============================================================== condation 2
            sql2 = "   SELECT        Name, Compny_Code, Invoice_No          FROM dbo.Vw_Condation2 WHERE        (Invoice_No = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varcondation2 = rs2("name").Value


            vardisplayReport = 261
            Report_InvoiceEng.Show()
        End If
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

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True

    End Sub

    Private Sub Op4_CheckedChanged(sender As Object, e As EventArgs) Handles Op4.CheckedChanged
        'If Op3.Checked = True Then Cmd_LookupSalse.Enabled = False
        If Op4.Checked = True Then Cmd_LookupSalse.Enabled = True
    End Sub

    Private Sub Cmd_LookupSalse_Click(sender As Object, e As EventArgs) Handles Cmd_LookupSalse.Click
        VarOpenlookup3 = 27
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
        VarOpenlookup2 = 24
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click

        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن التعديل الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart software")
        If txt_Typeinv.Text = "فاتورة مبدئية" Then

            find_varcode()

            Dim dd As DateTime = txt_date.Text
            Dim vardateoder As String
            vardateoder = dd.ToString("MM-d-yyyy")

            'var_No_Invoice_ser = Trim(rs3("Ser_InvoiceNo").Value)
            'var_No_Invoice_EXT = Trim(rs3("Ext_InvoiceNo").Value)


            sql2 = "UPDATE  TB_Header_InvoiceSal  SET Notes='" & txt_Notes.Text & "', flag ='" & 1 & "', Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "',Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "', InvoiceDate ='" & vardateoder & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & var_No_Invoice_EXT & "'  "
            rs = Cnn.Execute(sql2)


            sql = "UPDATE  TB_Detalis_InvoiceSal  SET  Quntity ='" & txt_Qty.Text & "', Code_Unit ='" & varcodunit & "',Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Total_Item ='" & Txt_Total.Text & "',Code_cur ='" & varcode_Cru & "',Rat_Invoice ='" & txt_rat.Text & "' WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & var_No_Invoice_ser & "'  and Seril_No ='" & var_serilNO_inv & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)

            '============================== TransactionHistoryCode 
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

            MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        End If
        'find_invoice()
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
        If Op3.Checked = True Then
            sql = "  SELECT        Order_Stores_NO, Code_Stores      FROM dbo.Vw_Lookup_AznSarf WHERE        (Order_Stores_NO = '" & Com_NoAzn.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodStores = Trim(rs("Code_Stores").Value)
        Else
            sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodStores = Trim(rs("code").Value)

        End If
        '========================================================
        sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = Trim(rs("code").Value)
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "' and Compny_Code ='" & VarCodeCompny & "'"
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
                sql = "Delete TB_Detalis_InvoiceSal  WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                '====================================================================تعديل اذن الصرف
                Dim sql3 As String
                sql3 = "UPDATE  TB_Detils_AznItem_Stores  SET No_Invoice ='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Order_Stores_NO ='" & Com_NoAzn.Text & "' "
                rs = Cnn.Execute(sql3)
                '=========================================================================

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
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



                sql = "UPDATE  TB_Header_InvoiceSal  SET Invoice_Status = '" & 0 & "'  WHERE Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "'   and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                'sql = "Delete Genralledger  WHERE Typebill ='" & 2 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                'rs = Cnn.Execute(sql)

                sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & Com_InvoiceNo2.Text & "'  and Typebill ='" & 2 & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 2 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode 
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','9','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
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


   

    Sub find_Invoice_Condation()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        'sql2 = "   SELECT         ID ,Order_NO, Discrption     FROM dbo.Tb_CondationOrder WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & Com_InvoiceNo3.Text & "')"


        sql2 = " SELECT        dbo.Tb_CondationInvoice.ID, dbo.Tb_CondationInvoice.Invoice_No, dbo.BD_CondationOrder.Name,dbo.Tb_CondationInvoice.CountDay " & _
                 " FROM            dbo.Tb_CondationInvoice INNER JOIN " & _
                 "                         dbo.BD_CondationOrder ON dbo.Tb_CondationInvoice.Code_Codation = dbo.BD_CondationOrder.Code AND dbo.Tb_CondationInvoice.Compny_Code = dbo.BD_CondationOrder.Compny_Code " & _
                 " WHERE        (dbo.Tb_CondationInvoice.Invoice_No ='" & Com_InvoiceNo3.Text & "') AND (dbo.Tb_CondationInvoice.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "350"
        GridView1.Columns(3).Width = "100"
        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "م"
        GridView1.Columns(1).Caption = "فاتورة رقم"
        GridView1.Columns(2).Caption = "شروط الدفع"
        GridView1.Columns(3).Caption = "الائتمان الممنوح"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo3.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_Discrption2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        varID = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_CountDay.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
    End Sub

    Private Sub txt_Ntax_TextChanged(sender As Object, e As EventArgs) Handles txt_Ntax.TextChanged
        'calcalator_invoice()
        On Error Resume Next
        Dim vartax As Single
        vartax = txt_Ntax.Text
        txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * Val(vartax / 100), 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_Dis.Text) - Val(txt_Dis2.Text) - Val(txt_OtherDiscount.Text), 2)
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
                    sql2 = "  SELECT        Ext_InvoiceNo, Compny_Code, Order_Stores_No          FROM dbo.TB_Detalis_InvoiceSal WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "')"
                    rs = Cnn.Execute(sql2)
                    If rs.EOF = False Then varOrder_Stores = rs("Order_Stores_No").Value
                    '===================================================
                    sql = "UPDATE TB_Detils_AznItem_Stores set No_Invoice ='" & 0 & "'  WHERE  Order_Stores_NO ='" & varOrder_Stores & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    '==================================================================================

                    sql = "Delete TB_Detalis_InvoiceSal  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    '===================================حذف من المخزن
                    sql = "Delete TB_Header_InvoiceSal  WHERE Ser_InvoiceNo = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'   "
                    rs = Cnn.Execute(sql)

                    '============================== TransactionHistoryCode 
                    sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','2','10','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo.Text & "')"
                    rs2 = Cnn.Execute(sql2)
                    '==============================

                    MsgBox("تم حذف الفاتورة", MsgBoxStyle.Information, "Css Solution Software Module")
                    find_detalis()
                    find_hedar()
                    clear_detils()
            End Select
        End If
    End Sub


    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs) Handles txt_Qty.TextChanged
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

    Private Sub txt_AccountNo_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNo.TextChanged

    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        vartable = "BD_CondationOrder"
        VarOpenlookup = 56
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Cmd_DeleteCondationInvoice_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteCondationInvoice.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_CondationInvoice  WHERE Invoice_No = '" & Com_InvoiceNo3.Text & "' and ID ='" & varID & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        End Select
        find_Invoice_Condation()
    End Sub

    Private Sub cmd_saveCondationInvoice_Click_1(sender As Object, e As EventArgs) Handles cmd_saveCondationInvoice.Click
        Dim varserilflag As Integer
        If Len(Com_InvoiceNo3.Text) = 0 Then MsgBox("من فضلك أختار رقم الفاتورة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub
        '=====================================
        sql2 = "  SELECT        MAX(flag) AS Maxseril, Invoice_No, Compny_Code        FROM dbo.Tb_CondationInvoice GROUP BY Invoice_No, Compny_Code " & _
            " HAVING        (Invoice_No = '" & Com_InvoiceNo3.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varserilflag = rs("Maxseril").Value + 1
        '===============================================================



        sql = "INSERT INTO Tb_CondationInvoice (Invoice_No, Compny_Code,Code_Codation,CountDay,flag) " & _
          " values  ('" & Com_InvoiceNo3.Text & "' ,'" & VarCodeCompny & "','" & varcode_Condation & "','" & txt_CountDay.Text & "','" & varserilflag & "')"
        Cnn.Execute(sql)
        MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        txt_Discrption2.Text = ""
        find_Invoice_Condation()
    End Sub

    Private Sub Com_InvoiceNo3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_InvoiceNo3.SelectedIndexChanged

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

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        varaccountNo_Customer = txt_AccountNo.Text
        Frm_LookupReciptCustomer.txt_CustomerName.Text = txt_nameaccount.Text
        Frm_LookupReciptCustomer.MdiParent = Mainmune
        Frm_LookupReciptCustomer.find_all_Detils()
        Frm_LookupReciptCustomer.Show()
    End Sub

    Private Sub CheckEng_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEng.CheckedChanged

    End Sub

    Private Sub Txt_TotalAll_TextChanged(sender As Object, e As EventArgs) Handles Txt_TotalAll.TextChanged

    End Sub

    Private Sub CheckNewArbLogo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckNewArbLogo.CheckedChanged

    End Sub

    Private Sub CheckNewArbLogo_Click(sender As Object, e As EventArgs) Handles CheckNewArbLogo.Click
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckNewwithoutlogo.Checked = False
        CheckEng.Checked = False

    End Sub

    Private Sub CheckEng_Click(sender As Object, e As EventArgs) Handles CheckEng.Click
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckNewwithoutlogo.Checked = False
        CheckNewArbLogo.Checked = False
    End Sub

    Private Sub CheckNewwithoutlogo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckNewwithoutlogo.CheckedChanged

    End Sub

    Private Sub CheckNewwithoutlogo_Click(sender As Object, e As EventArgs) Handles CheckNewwithoutlogo.Click
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckNewArbLogo.Checked = False
        CheckEng.Checked = False
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
  
        CheckNewwithoutlogo.Checked = False
        CheckEng.Checked = False
        CheckNewArbLogo.Checked = False
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

    End Sub

    Private Sub CheckBox4_Click(sender As Object, e As EventArgs) Handles CheckBox4.Click
        CheckNewwithoutlogo.Checked = False
        CheckEng.Checked = False
        CheckNewArbLogo.Checked = False
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

    Private Sub txt_Ntax2_TextChanged(sender As Object, e As EventArgs) Handles txt_Ntax2.TextChanged
        On Error Resume Next
        txt_Dis2.Text = Math.Round(Val(txt_totalPrice.Text) * Val(txt_Ntax2.Text) / 100, 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_Dis.Text) - Val(txt_Dis2.Text) - Val(txt_OtherDiscount.Text), 2)

    End Sub

    Private Sub txt_Ntax3_TextChanged(sender As Object, e As EventArgs) Handles txt_Ntax3.TextChanged
        On Error Resume Next
        txt_OtherDiscount.Text = Math.Round(Val(txt_totalPrice.Text) * Val(txt_Ntax3.Text) / 100, 2)
        Txt_TotalAll.Text = Math.Round(Val(txt_Tax.Text) + Val(txt_totalPrice.Text) - Val(txt_Dis.Text) - Val(txt_Dis2.Text) - Val(txt_OtherDiscount.Text), 2)

    End Sub

    Private Sub txt_Dis_TextChanged(sender As Object, e As EventArgs) Handles txt_Dis.TextChanged

    End Sub

    Private Sub Com_Group_Item_Click(sender As Object, e As EventArgs) Handles Com_Group_Item.Click
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then txt_Ntax.Text = "0"
        If Com_Group_Item.Text = "فاتورة ضريبية" Then txt_Ntax.Text = "14"

    End Sub

    Private Sub Com_Group_Item_GotFocus(sender As Object, e As EventArgs) Handles Com_Group_Item.GotFocus
        fill_TypeInvoice()
    End Sub

    Private Sub Com_Group_Item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Group_Item.SelectedIndexChanged
        If Com_Group_Item.Text = "فاتورة غير ضريبية" Then txt_Ntax.Text = "0"
        If Com_Group_Item.Text = "فاتورة ضريبية" Then txt_Ntax.Text = "14"

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If Len(Com_NoAzn.Text) = 0 Then MsgBox("من فضلك اختار رقم  الاذن", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        var_recived_Stores = 3
        Rpt_ResivedStores_Print.Show()

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As EventArgs) Handles CheckBox5.Click
        If CheckBox5.Checked = True Then Cmd_save.Enabled = False Else Cmd_save.Enabled = True
    End Sub
End Class