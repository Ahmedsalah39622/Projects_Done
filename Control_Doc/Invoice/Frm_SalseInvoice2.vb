Imports System.Data.OleDb

Public Class Frm_SalseInvoice2
    Dim varcodeitem As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim xx As String
    Dim VarItem_EX, VarStutas As String
    Dim x As String
    Dim vartaxinvoice, vartaxitem As Single
    Dim var_ExtItem, varbarcodetext As String
    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs)
        'If Op3.Checked = True Then
        '    typeInvoice = 1
        '    Frm_Lookup_AznSarf.Close()
        '    Frm_Lookup_AznSarf.MdiParent = Mainmune
        '    Frm_Lookup_AznSarf.Search()
        '    Frm_Lookup_AznSarf.Show()
        'End If

        'If Op4.Checked = True Then
        '    typeInvoice = 2
        '    Frm_Lookup_AznSarf.Close()
        '    Frm_Lookup_AznSarf.MdiParent = Mainmune
        '    Frm_Lookup_AznSarf.Search2()
        '    Frm_Lookup_AznSarf.Show()
        'End If
        VARTBNAME = "vw_AllItemBalance"
        varcode_form = 1999
        Lookupitem.Text = "بحث"
        Lookupitem.ShowDialog()

    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs)
        sql = "  SELECT        Name, Code      FROM dbo.FindCustomer WHERE        (Name = '" & txt_nameaccount.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_AccountNo.Text = rs("code").Value
    End Sub

    Private Sub txt_NameSalse_TextChanged(sender As Object, e As EventArgs)
        sql = "    SELECT        Emp_Name, Emp_Code   FROM dbo.Emp_employees WHERE        (Emp_Name = '" & txt_NameSalse.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_CodeSalse.Text = rs("Emp_Code").Value

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
        last_Data()

        clear_detils()
        txt_AvQty.Text = ""
        find_hedar()
        find_detalis()

        Fill_BoxAcc()
        txt_CodeSalse.Text = varcode_User
        txt_NameSalse.Text = varnameuser
        txt_Barcode.Select()
    End Sub

    Sub Fill_BoxAcc()
        'sql2 = "select * from vw_BoxAcc"
        'rs2 = Cnn.Execute(sql2)
        'If rs2.EOF = False Then txt_AccountNo.Text = rs2("codeAcc").Value : txt_nameaccount.Text = rs2("Name").Value



        'txt_Barcode.Select()
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code FROM            TB_Header_InvoiceSal    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
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
        find_tax()
        Dim total As String = 0
        For i As Integer = 0 To GridView6.RowCount - 1
            total += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(6)))
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
        txt_Barcode.Text = ""
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
        txt_deposit.Text = ""
        txt_rem.Text = ""
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs)
        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        If Val(txt_Qty.Text) > Val(txt_AvQty.Text) Then MsgBox("من فضلك  ادخل كمية اقل او تساوى  الكمية المتاحة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "css Solution Software Module") : Exit Sub


        save_Invoice()


    End Sub
    Sub save_Invoice()
        sql2 = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من  فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Invoice_H()

    End Sub

    Sub find_tax()
        'sql = "select * from Tb_TaxInvoice where  Compny_Code ='" & VarCodeCompny & "'   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then VarAccountTax_Invoice = rs("Account_Tax").Value : vartaxinvoice = rs("Tax_Sal").Value : txt_Ntax.Text = rs("Tax_Sal").Value Else vartaxinvoice = "0" : txt_Ntax.Text = 0
    End Sub
    Sub save_Invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = " & Com_InvoiceNo.Text & "   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_InvoiceSal (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        'save_oderDetils()
        save_InvoiceDetils()
        save_itemStores()
        clear_detils()
        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub
    Sub save_itemStores()
        On Error Resume Next
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        'If txt_CodeItem.Text = "" Then MsgBox("الصنف غير موجود", MsgBoxStyle.Critical, "Css") : Exit Sub
        'var_ExtItem = rs("Ex_Item").Value
        'If txt_CodeItem.Text <> "" Then
        '    sql = "   SELECT Unit1, Ex_Item,code    FROM dbo.BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then var_ExtItem = rs("Ex_Item").Value
        'End If
        '=========================================================================
        'sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodStores = Trim(rs("code").Value)
        '==================================================================================
        varcodStores = 1
        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Barcode_No,Code_Sub,Price_Unit,Ex_No,AccountNo_Stores,Ex_Item,Compny_Code) " & _
            " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & txt_CodeItem.Text & " ', '" & 1 & "','" & varcodStores & "','" & 2 & "' " & _
            " ,'" & vardateinvoice & "','" & "فاتورة مبيعات" + Com_InvoiceNo.Text & "','" & txt_Qty.Text & "','" & txt_Barcode.Text & "','" & 1 & "','" & txt_Price.Text & " ','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & var_ExtItem & "','" & VarCodeCompny & "') "
        Cnn.Execute(sql)

    End Sub
    Sub find_barcode()

        '=========================================================================
        'sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodStores = Trim(rs("code").Value)
        '============================================================
        On Error Resume Next

        sql = "   SELECT        TOP (100) PERCENT SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Qty, dbo.BD_ITEM.Name, dbo.Statement_OfItem.NoItem " & _
   " FROM            dbo.Statement_OfItem INNER JOIN " & _
   "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code " & _
   " WHERE        (dbo.Statement_OfItem.Code_Stores =  '" & 1 & "') " & _
   " GROUP BY dbo.BD_ITEM.Name, dbo.Statement_OfItem.NoItem " & _
   "        HAVING(dbo.Statement_OfItem.NoItem = '" & txt_CodeItem.Text & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            txt_CodeItem.Text = rs("NoItem").Value
            txt_NameItem.Text = rs("Name").Value
            txt_AvQty.Text = Math.Round(rs("Qty").Value, 2) : txt_Qty.Enabled = True
            'If com_typeBill.Text = "جملة" Then txt_QtyAvalabil.Text = Math.Round(rs("Qty").Value, 2) : txt_Qty.Select() : txt_Qty.Enabled = True

        Else
            txt_AvQty.Text = "0"
        End If
    End Sub
    Sub save_InvoiceDetils()
        On Error Resume Next
        find_varcode()

        sql = "INSERT INTO TB_Detalis_InvoiceSal (Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & 1 & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & 1 & "','" & 1 & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub txt_Price_TextChanged(sender As Object, e As EventArgs)
        calcalator_invoice()
    End Sub
    Sub calcalator_invoice()
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single
        varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_Price.Text), 2)
        varDiscount = varTotalInvoice * Val(Txt_Discount) / 100

        Txt_Total.Text = varTotalInvoice - varDiscount
    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs)
        vartable = "Vw_LookupInvoiceSal"
        VarOpenlookup = 270
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub

    Sub find_hedar()
        On Error Resume Next

        sql = "   SELECT     dbo.TB_Header_InvoiceSal.Rem,  dbo.TB_Header_InvoiceSal.Deposit,  dbo.TB_Header_InvoiceSal.Invoice_Status,dbo.TB_Header_InvoiceSal.Ser_InvoiceNo, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.TB_Header_InvoiceSal.Customer_No, dbo.TB_Header_InvoiceSal.PayStatus,  " & _
   "                         dbo.TB_Header_InvoiceSal.Salse_No, dbo.Emp_employees.Emp_Name, dbo.TB_Header_InvoiceSal.Notes, dbo.ST_CHARTOFACCOUNT.AccountName, iif(dbo.TB_Header_InvoiceSal.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') " & _
   " FROM            dbo.TB_Header_InvoiceSal INNER JOIN " & _
   "                         dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
   "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
   "        dbo.TB_Header_InvoiceSal.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No " & _
   " WHERE        (dbo.TB_Header_InvoiceSal.Ext_InvoiceNo =  '" & Com_InvoiceNo2.Text & "') "


        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs3("Ser_InvoiceNo").Value)
            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            txt_date.Text = Trim(rs3("InvoiceDate").Value)
            txt_Notes.Text = Trim(rs3("Notes").Value)
            txt_CodeSalse.Text = Trim(rs3("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs3("Emp_Name").Value)
            txt_AccountNo.Text = Trim(rs3("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs3("AccountName").Value)

            txt_deposit.Text = Trim(rs3("Deposit").Value)
            txt_rem.Text = Trim(rs3("rem").Value)

            If Trim(rs3("Invoice_Status").Value) = 1 Then txt_Typeinv.Text = "مرحل" : txt_Typeinv.BackColor = Color.Green : Cmd_CloseInvoice.Enabled = False : Cmd_RtInvoice.Enabled = True
            If Trim(rs3("Invoice_Status").Value) = 0 Then txt_Typeinv.Text = "فاتورة مبدئية" : txt_Typeinv.BackColor = Color.Gray : Cmd_CloseInvoice.Enabled = True : Cmd_RtInvoice.Enabled = False




        End If

    End Sub


    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        No_Item, Name, Unit, Quntity, Price_Item, Discount_Item, Total_Item,NameStores FROM dbo.Vw_DetilsInvoice" & _
            " where  (dbo.Vw_DetilsInvoice.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "')  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)



        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True
        GridView6.BestFitColumns()
        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الصنف"
        GridView6.Columns(2).Caption = "الوحدة"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "سعر الوحدة"
        GridView6.Columns(5).Caption = "قيمة الخصم"
        GridView6.Columns(6).Caption = "الاجمالى"
        GridView6.Columns(7).Caption = "المخزن"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        'Mainmune.finwatinoderItem()
    End Sub

   


    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs)
        'If Len(Com_Group_Item.Text) = 0 Then MsgBox("من فضلك اختار نوع فاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD =2  "
        rs = Cnn.Execute(sql)
        '==============================================================================================================
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView6.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

            Dim varcodunit2 As Integer


            sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(7))) & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodStores = Trim(rs("code").Value)
            '=======================================================
            sql = "   SELECT Unit1, Ex_Item,code    FROM dbo.BD_ITEM    WHERE(code = '" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(0))) & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit2 = rs("Unit1").Value : var_codeItem = rs("code").Value
            '===========================================================
            'var_codeItem = Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(11)))

            sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Code_Sub,Price_Unit,TypeItem,Ex_No) " & _
            " values (N'" & Com_InvoiceNo.Text & "',N'" & 1 & "',N'" & 1 & " ' " & _
            " ,N'" & var_codeItem & "', N'" & varcodunit2 & "',N'" & varcodStores & "',N'" & 2 & "' " & _
            " ,N'" & vardateinvoice & "',N'" & "فاتورة مبيعات" + Com_InvoiceNo.Text & "',N'" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(3))) & "',N'" & 1 & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(4))) & " ',N'" & 1 & "',N'" & Com_InvoiceNo2.Text & "') "
            Cnn.Execute(sql)


        Next rowHandle





        saveGl()

        sql2 = "UPDATE  TB_Header_InvoiceSal  SET Deposit='" & txt_deposit.Text & "',Rem='" & txt_rem.Text & "', Invoice_Status='" & 1 & "',PayStatus='" & VarStutas & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)

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
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================

        varcodeCostCenter2 = "401001"
        varcodeCostCenter1 = "401001"
        '=======================================================المدين  من ح العملاء - او ح النقدية
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & txt_AccountNo.Text & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Txt_TotalAll.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & txt_AccountNo.Text & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Txt_TotalAll.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & Txt_TotalAll.Text & "','" & 0 & "','" & VarCodeCompny & "' )"
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

        Com_Group_Item.Text = "فاتورة ضريبية"

        sql = " SELECT        dbo.Setup_Acc_Group.Code_Group, dbo.TB_InvoiceType.Name, dbo.Setup_Acc_Group.AccountNo_Sal, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.ST_CHARTOFACCOUNT.Compny_Code,  " & _
                "                         dbo.Setup_Acc_Group.AccountNo_Discount2 " & _
                " FROM            dbo.Setup_Acc_Group INNER JOIN " & _
                "                         dbo.TB_InvoiceType ON dbo.Setup_Acc_Group.Code_Group = dbo.TB_InvoiceType.Code AND dbo.Setup_Acc_Group.Compny_Code = dbo.TB_InvoiceType.Compny_Code INNER JOIN " & _
                "                         dbo.ST_CHARTOFACCOUNT ON dbo.Setup_Acc_Group.AccountNo_Sal = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.Setup_Acc_Group.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
                " WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_InvoiceType.Name = '" & Com_Group_Item.Text & "') "

        rs = Cnn.Execute(sql)



        If Val(txt_OtherDiscount.Text) > 0 Then
            '=================================الخصم
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
            " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Discount2").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & 0 & "' ,'" & 1 & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
             " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Discount2").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & txt_OtherDiscount.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & 0 & "' ,'" & 1 & "','" & txt_OtherDiscount.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

        End If




        '=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & rs("AccountNo_Sal").Value & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================

        varcodeCostCenter2 = "401001"
        'VarAccountTax_Invoice

        '========================================================================== الدائن
        'vartaxitem = rs("TotalAll").Value * (txt_Ntax.Text) / 100

        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
            " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNo_Sal").Value & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "','" & 1 & "')"
        Cnn.Execute(sql)

        ''========================الضريبة
        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '  " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & VarAccountTax_Invoice & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "','" & 1 & "')"
        'Cnn.Execute(sql)





        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
         " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNo_Sal").Value & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_totalPrice.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalPrice.Text & "','" & VarCodeCompny & "' )"
        Cnn.Execute(sql)


        '================================الضريبة
        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        ' " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & VarAccountTax_Invoice & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_Tax.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_Tax.Text & "','" & VarCodeCompny & "' )"
        'Cnn.Execute(sql)



        'rs.MoveNext()
        'Loop



        '========================================خصم عام




        'End If

        'gl_discountall()
        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



    End Sub



    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs)
        'Report_Invoice.Show()
        'Frm_Rest.Show()
    End Sub

    Private Sub Frm_SalseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  fill_cru()

        'Com_Condation.Items.Add("دفع 100 % عن الاستلام نقدا")
        'Com_Condation.Items.Add("100 % بعد شهر")
        'Com_Condation.Items.Add("100 % بعد شهرين")
        'Com_Condation.Items.Add("100 % بعد 3 شهور")
        'Com_Condation.Items.Add("50 % نقدا 50 % بعد شهر")

        '   fill_TypeInvoice()

        '  last_Data()
        '   clear_detils()
        '   find_hedar()
        '   find_detalis()
        ' Fill_BoxAcc()
        '   txt_CodeSalse.Text = varcode_User
        '   txt_NameSalse.Text = varnameuser
        '   txt_Barcode.Select()
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


    Private Sub com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub Com_NoAzn_TextChanged(sender As Object, e As EventArgs)
        'If txt_SalseOrder.Text <> "" Then SimpleButton2.Enabled = True Else SimpleButton2.Enabled = False
        'If Com_NoAzn.Text <> "" Then SimpleButton5.Enabled = True Else SimpleButton5.Enabled = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        VarOpenlookup2 = 24
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs)

        If txt_Typeinv.Text = "مرحل" Then MsgBox("لايمكن التعديل الفاتورة مرحلة", MsgBoxStyle.Critical, "Creative Smart soft")
        If txt_Typeinv.Text = "فاتورة مبدئية" Then

            find_varcode()

            sql = "UPDATE  TB_Detalis_InvoiceSal  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Code_Stores ='" & varcodStores & "',Price_Item ='" & txt_Price.Text & "',Discount_Item ='" & Txt_Discount.Text & "',Value_Discount ='" & txt_valuediscount.Text & "',Total_Item ='" & Txt_Total.Text & "',Code_cur ='" & 1 & "',Rat_Invoice ='" & 1 & "' WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)

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
        'If Op3.Checked = True Then
        '    sql = "  SELECT        Order_Stores_NO, Code_Stores      FROM dbo.Vw_Lookup_AznSarf WHERE        (Order_Stores_NO = '" & Com_NoAzn.Text & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then varcodStores = Trim(rs("Code_Stores").Value)
        'Else
        sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & txt_Stores.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = Trim(rs("code").Value) Else varcodStores = 1

        'End If
        '========================================================

        '========================================================رقم العملة
        'sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_Cru = rs("code").Value
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detalis_InvoiceSal  WHERE No_Item = '" & varcodeitem & "' and Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                Total_Sum()
        End Select
    End Sub

    Private Sub Cmd_RtInvoice_Click(sender As Object, e As EventArgs)
        Dim x As String
        x = MsgBox("هل تريد ارجاع الفاتورة", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "UPDATE  TB_Header_InvoiceSal  SET Invoice_Status = '" & 0 & "'  WHERE Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "'   and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete Genralledger  WHERE Typebill ='" & 2 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 2 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                MsgBox("تم ارجاع الفاتورة  ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End Select

        find_hedar()
        find_detalis()
        'find_Invoice_Condation()
        Total_Sum()
        'sum_tax()

    End Sub

    Private Sub Com_Condation_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If Com_Condation.Text = "دفع 100 % عن الاستلام نقدا" Then VarStutas = 0
        'If Com_Condation.Text = "100 % بعد شهر" Then VarStutas = 1
        'If Com_Condation.Text = "100 % بعد شهرين" Then VarStutas = 2
        'If Com_Condation.Text = "100 % بعد 3 شهور" Then VarStutas = 3
        'If Com_Condation.Text = "50 % نقدا 50 % بعد شهر" Then VarStutas = 4

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_Barcode_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then

            find_item()
            find_barcode()
            calcalator_invoice()
            save_Invoice()
            find_detalis()
            Total_Sum()
            txt_Barcode.Text = ""
            txt_Barcode.Select()
        End If
    End Sub

    Sub find_item()
        On Error Resume Next
        varbarcodetext = Trim(txt_Barcode.Text)
        sql2 = "   SELECT        dbo.BD_ITEM.Code, dbo.BD_ITEM.Name, dbo.BD_Unit.Name AS Unit, dbo.BD_ITEM.PriceSal, '1' AS Qyt " & _
        " FROM            dbo.BD_ITEM INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.BD_ITEM.Unit1 = dbo.BD_Unit.Code  " & _
        " WHERE        (dbo.BD_ITEM.Barcode_No = '" & Trim(varbarcodetext) & "') "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
            txt_CodeItem.Text = Trim(rs2("code").Value) : txt_NameItem.Text = rs2("Name").Value : txt_Qty.Text = rs2("Qyt").Value : txt_Price.Text = rs2("PriceSal").Value : txt_unit.Text = rs2("unit").Value

        Else
            txt_CodeItem.Text = "" : txt_NameItem.Text = "" : txt_Qty.Text = "" : txt_Price.Text = "" : txt_unit.Text = ""
        End If
    End Sub

    Private Sub txt_deposit_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        txt_rem.Text = Math.Round(Val(Txt_TotalAll.Text) - Val(txt_deposit.Text), 2)
    End Sub

    Private Sub Txt_TotalAll_TextChanged(sender As Object, e As EventArgs)
        'On Error Resume Next
        'txt_deposit.Text = Math.Round(Val(Txt_TotalAll.Text) - Val(txt_deposit.Text), 2)
    End Sub

  
    Private Sub cmd_Del_Invoice_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        If txt_Typeinv.Text = "فاتورة مبدئية" Then
            x = MsgBox("هل تريد حذف الفاتورة", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            Select Case x
                Case vbNo

                Case vbYes
                    sql = "Delete TB_Detalis_InvoiceSal  WHERE  Ser_InvoiceNo  ='" & Com_InvoiceNo.Text & "' "
                    rs = Cnn.Execute(sql)

                    sql = "Delete TB_Header_InvoiceSal  WHERE  Ser_InvoiceNo ='" & Com_InvoiceNo.Text & "' "
                    rs = Cnn.Execute(sql)


                    sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD =2  "
                    rs = Cnn.Execute(sql)

                    MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")


            End Select
        Else
            MsgBox("يجب ان تكون فاتورة مبدئية ", MsgBoxStyle.Information, "Css Solution Software Module") : Exit Sub



        End If

        last_Data()
        clear_detils()
        find_hedar()
        find_detalis()
        Fill_BoxAcc()
        txt_CodeSalse.Text = varcode_User
        txt_NameSalse.Text = varnameuser
    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs)
        calcalator_invoice()
    End Sub

    Private Sub Txt_Discount_TextChanged(sender As Object, e As EventArgs)
        calcalator_invoice()
    End Sub

    Private Sub GridControl3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_Price.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        Txt_Discount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_valuediscount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        Txt_Total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))


        find_barcode()
    End Sub

    Private Sub txt_Barcode_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_OtherDiscount_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        Txt_TotalAll.Text = Val(txt_totalPrice) - Val(txt_Dis.Text)
    End Sub

    Private Sub txt_totalPrice_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        Txt_TotalAll.Text = Val(txt_totalPrice) - Val(txt_Dis.Text)
    End Sub
End Class