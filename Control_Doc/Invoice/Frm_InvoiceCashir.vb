Imports System.Data.OleDb

Public Class Frm_InvoiceCashir

    Dim varInvSerial, var_No_Invoice_ser, var_No_Invoice_EXT As String
    Dim varcodStores, varcodWallet, varAccNo As Integer
    Dim salAcc, DiscAcc, visaAcc, Ser_InvoiceNo As String
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim varCodeUnit, varNameUnit As String


    Sub get_invSerial()
        sql2 = "   SELECT       inv_serial         FROM BD_POS_Setting WHERE        (branch_Code = '" & varCodeBranch & "') AND (company_code = '" & VarCodeCompny & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then varInvSerial = rs2("inv_serial").Value
    End Sub

    Sub last_Data()


        get_invSerial()
        sql = "     SELECT        MAX(Ser_InvoiceNo) AS MaxMaim, Compny_Code       FROM dbo.TB_Header_InvoiceSal GROUP BY Compny_Code,Branch_No HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) AND (Compny_Code = '" & VarCodeCompny & "') and (Branch_No = '" & varCodeBranch & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Ser_InvoiceNo = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = varInvSerial + Ser_InvoiceNo

        Else
            'If VarCodeCompny = 3 Then Com_InvoiceNo.Text = 1

            'If VarCodeCompny = 2 Then Com_InvoiceNo.Text = "1"
            If VarCodeCompny = 1 Then Ser_InvoiceNo = "1"

            'If VarCodeCompny = 2 Then Com_InvoiceNo2.Text = "INV" + "1"
            If VarCodeCompny = 1 Then Com_InvoiceNo2.Text = varInvSerial + "1"
        End If

    End Sub

    Sub clear_details()
        DataGridView2.DataSource = Nothing
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        txt_Barcode.Text = ""
        txt_cashValue.Text = "0.0"
        txt_discountPOS.Text = "0.0"
        txt_visaValue.Text = "0.0"
        txt_rest.Text = "0.0"
        lb_totalInv.Text = "0.0 الاجمالى "
        txt_NameSalse.Text = varnameuser
        lb_branchName.Text = varNameBranch
    End Sub

    Sub get_Store()
        'Com_Stores.Items.Clear()
        sql = " SELECT    dbo.BD_Stores.Code, dbo.BD_Stores.Name, dbo.BD_Stores.Compny_Code " & _
" FROM    dbo.vw_setting_Pos INNER JOIN dbo.BD_Stores ON dbo.vw_setting_Pos.Expr3 = dbo.BD_Stores.Name where dbo.BD_Stores.Compny_Code ='" & VarCodeCompny & "' and dbo.vw_setting_Pos.Name =N'" & varNameBranch & "' "
        rs = Cnn.Execute(sql)

        If rs2.EOF = False Then
            'Com_Stores.Text = rs("Name").Value.ToString
            Com_Stores.Text = rs("Name").Value.ToString
            varcodStores = (rs("Code").Value)
        End If


    End Sub
    Sub get_wallet()

        sql = " SELECT        dbo.vw_setting_Pos.Expr4, dbo.ST_CHARTOFACCOUNT.Account_No, dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
" FROM            dbo.vw_setting_Pos INNER JOIN" & _
                "         dbo.ST_CHARTOFACCOUNT ON dbo.vw_setting_Pos.Expr4 = dbo.ST_CHARTOFACCOUNT.AccountName where Compny_Code ='" & VarCodeCompny & "'  and (dbo.vw_setting_Pos.Name = N'" & varNameBranch & "')  "
        rs = Cnn.Execute(sql)

        If rs2.EOF = False Then
            'Com_Stores.SelectedItem(rs("Name").Value)
            txt_walletName.Text = (rs("Expr4").Value)
            varcodWallet = (rs("Account_No").Value)
        End If

    End Sub
    Sub get_accountVal()

        sql = " SELECT        dbo.ST_CHARTOFACCOUNT.Account_No, dbo.ST_CHARTOFACCOUNT.Compny_Code, dbo.vw_setting_Pos.Name, dbo.vw_setting_Pos.Expr1 " & _
" FROM            dbo.vw_setting_Pos INNER JOIN " & _
  "                       dbo.ST_CHARTOFACCOUNT ON dbo.vw_setting_Pos.Expr1 = dbo.ST_CHARTOFACCOUNT.AccountName " & _
"where Compny_Code ='" & VarCodeCompny & "'  and (dbo.vw_setting_Pos.Name = N'" & varNameBranch & "')  "
        rs = Cnn.Execute(sql)
        If rs2.EOF = False Then
            'Com_Stores.SelectedItem(rs("Name").Value)
            txt_nameaccount.Text = (rs("Expr1").Value)
            varAccNo = (rs("Account_No").Value)
        End If

    End Sub
    Sub get_Disc_Sal_Acc()

        sql = " SELECT        dbo.ST_CHARTOFACCOUNT.Account_No, dbo.ST_CHARTOFACCOUNT.Compny_Code, dbo.vw_setting_Pos.Name, dbo.vw_setting_Pos.Expr1, dbo.vw_setting_Pos.AccountName, dbo.vw_setting_Pos.Expr5, " & _
           "              ST_CHARTOFACCOUNT_1.Account_No AS Expr2, ST_CHARTOFACCOUNT_2.Account_No AS Expr3, dbo.vw_setting_Pos.Expr2 AS Expr4 " & _
" FROM            dbo.vw_setting_Pos INNER JOIN " & _
  "                       dbo.ST_CHARTOFACCOUNT ON dbo.vw_setting_Pos.AccountName = dbo.ST_CHARTOFACCOUNT.AccountName INNER JOIN " & _
   "                      dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.vw_setting_Pos.Expr5 = ST_CHARTOFACCOUNT_1.AccountName INNER JOIN " & _
    "                     dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_2 ON dbo.vw_setting_Pos.Expr2 = ST_CHARTOFACCOUNT_2.AccountName" & _
"        where dbo.ST_CHARTOFACCOUNT.Compny_Code ='" & VarCodeCompny & "'  and (dbo.vw_setting_Pos.Name = N'" & varNameBranch & "')   "
        rs = Cnn.Execute(sql)
        If rs2.EOF = False Then
            'Com_Stores.SelectedItem(rs("Name").Value)
            salAcc = (rs("Account_No").Value)
            DiscAcc = (rs("Expr2").Value)
            visaAcc = (rs("Expr3").Value)

        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click

        last_Data()
        clear_details()
        txt_Barcode.Select()

        get_accountVal()
        get_Disc_Sal_Acc()
        get_invSerial()
        get_Store()
        get_wallet()

        find_hedar()
        find_detalis()
    End Sub

    Sub save_invoice()

        sql2 = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = '" & Ser_InvoiceNo & "' and Compny_Code =  '" & VarCodeCompny & "'  and Branch_No =  '" & varCodeBranch & "'   "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If

        save_Invoice_H()

    End Sub

    Sub save_Invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-dd-yyyy")

        sql = "select * from TB_Header_InvoiceSal where Ser_InvoiceNo  = " & Ser_InvoiceNo & "  and Compny_Code ='" & VarCodeCompny & "' and Branch_No ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else

            sql2 = "INSERT INTO TB_Header_InvoiceSal (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Branch_No,wallet_Code) " & _
                      " values  ('" & Ser_InvoiceNo & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & varAccNo & "','" & varcode_User & "','" & 0 & "','" & 0 & "','" & varCodeBranch & "','" & varcodWallet & "')"
            Cnn.Execute(sql2)

        End If
        'Next
        'save_oderDetils()
        save_InvoiceDetils()
        'save_itemStores()
        clear_details()

        find_hedar()
        find_detalis()

        Total_Sum()
    End Sub
    Sub Total_Sum()
        Dim total As Double
        For i As Integer = 0 To DataGridView2.Rows.Count - 1

            total += DataGridView2.Rows(i).Cells(4).Value

            'total += DataGridView2.getrow(i, DataGridView2.Columns(4))
            'total_discount += GridView6.GetRowCellValue(i, GridView6.Columns(10))
        Next
        lb_totalInv.Text = Math.Round(total, 2)
        txt_rest.Text = Math.Round(total - Val(txt_cashValue.Text) - Val(txt_visaValue.Text) - Val(txt_discountPOS.Text), 2)
    End Sub
    Sub get_unitName()
        sql2 = "SELECT        Code, Name FROM            dbo.BD_Unit WHERE        (code = N'" & varCodeUnit & "') and  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            varNameUnit = rs("Name").Value
        End If

    End Sub
    Sub find_itemData()
        sql2 = "SELECT        Code, Ex_Item, PriceSal, Name, unit1 FROM            dbo.BD_Item WHERE        (Barcode_No = N'" & txt_Barcode.Text & "') and  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            varItCode = rs("Code").Value
            varItExCode = rs("Ex_Item").Value
            varprice = rs("PriceSal").Value
            varItemName = rs("Name").Value
            varCodeUnit = rs("unit1").Value
            get_unitName()
        End If
    End Sub

    Sub save_InvoiceDetils()

        find_itemData()
        sql = "INSERT INTO TB_Detalis_InvoiceSal (Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Flag_Item,Code_Stores,Price_Item,Item_Discription,Code_Unit,Item_Barcode) " & _
         " values  ('" & Ser_InvoiceNo & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & varItCode & "','" & varItExCode & "','" & 1 & "','" & 0 & "','" & varcodStores & "','" & varprice & "', '" & varItemName & "', '" & varCodeUnit & "','" & txt_Barcode.Text & "')"

        Cnn.Execute(sql)

    End Sub
    Sub find_hedar()
        On Error Resume Next

        sql2 = "SELECT        dbo.TB_Header_InvoiceSal.tax_n, dbo.TB_Header_InvoiceSal.Ser_InvoiceNo, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo, dbo.TB_Header_InvoiceSal.InvoiceDate, dbo.TB_Header_InvoiceSal.Customer_No, " & _
                  "       dbo.TB_Header_InvoiceSal.PayStatus, dbo.TB_Header_InvoiceSal.Salse_No, dbo.Emp_employees.Emp_Name, iif(dbo.TB_Header_InvoiceSal.Invoice_Type='1', 'مغلق', 'جديد') AS Type, iif(dbo.TB_Header_InvoiceSal.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status, dbo.TB_Header_InvoiceSal.Notes, dbo.TB_Header_InvoiceSal.NS_2, dbo.TB_Header_InvoiceSal.NS_Other, " & _
            " dbo.TB_Header_InvoiceSal.Dis_Item, dbo.TB_Header_InvoiceSal.Dis_2, dbo.TB_Header_InvoiceSal.Dis_Other, dbo.TB_Header_InvoiceSal.Invoice_Type, dbo.TB_Header_InvoiceSal.cash_value," & _
          "  dbo.TB_Header_InvoiceSal.visa_value, dbo.ST_CHARTOFACCOUNT.Account_No, dbo.ST_CHARTOFACCOUNT.AccountName " & _
" FROM            dbo.TB_Header_InvoiceSal INNER JOIN  " & _
  "                       dbo.Emp_employees ON dbo.TB_Header_InvoiceSal.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
   "                      dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_InvoiceSal.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Header_InvoiceSal.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No" & _
    " WHERE        (dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') and dbo.TB_Header_InvoiceSal.Compny_Code = '" & VarCodeCompny & "' "


        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then

            var_No_Invoice_ser = Trim(rs3("Ser_InvoiceNo").Value)
            var_No_Invoice_EXT = Trim(rs3("Ext_InvoiceNo").Value)

            Com_InvoiceNo2.Text = Trim(rs3("Ext_InvoiceNo").Value)
            varAccNo = Trim(rs3("Customer_No").Value)
            'txt_date.Text = Trim(rs3("InvoiceDate").Value)
            'txt_CodeSalse.Text = Trim(rs3("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs3("Emp_Name").Value)

            txt_nameaccount.Text = Trim(rs3("AccountName").Value)
            'txt_Typeinv.Text = Trim(rs3("Invoice_Status").Value)
            'If txt_Typeinv.Text = "مرحل" Then Cmd_RtInvoice.Enabled = True : Cmd_CloseInvoice.Enabled = False : txt_Typeinv.BackColor = Color.Green : txt_Ntax2.Enabled = False : txt_Ntax3.Enabled = False
            'If txt_Typeinv.Text = "فاتورة مبدئية" Then Cmd_RtInvoice.Enabled = False : Cmd_CloseInvoice.Enabled = True : txt_Typeinv.BackColor = Color.Gray : txt_Ntax2.Enabled = True : txt_Ntax3.Enabled = True

            txt_discountPOS.Text = Trim(rs3("Dis_Item").Value)
            txt_cashValue.Text = Trim(rs3("cash_value").Value)
            txt_visaValue.Text = Trim(rs3("visa_value").Value)


            If Trim(rs3("Invoice_Status").Value) = "مرحل" Then
                Cmd_CloseInvoice.Enabled = False
                txt_Barcode.Enabled = False

            Else
                Cmd_CloseInvoice.Enabled = True
                txt_Barcode.Enabled = True
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

        Dim dt = ds.Tables(0)

        If dt.Rows.Count <> 0 Then
            DataGridView2.AutoGenerateColumns = False
            DataGridView2.DataSource = ds.Tables(0)
            'DataGridView2.DataSource = dt.DefaultView

        Else
            DataGridView2.DataSource = Nothing
        End If
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

        'GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        'GridView6.Appearance.Row.Options.UseFont = True

        'DataGridView2.Columns(0).HeaderText = "كود الصنف"
        'DataGridView2.Columns(1).HeaderText = "الرقم التوصيفى "
        'DataGridView2.Columns(2).HeaderText = "الصنف"
        'DataGridView2.Columns(3).HeaderText = "الكمية"
        'DataGridView2.Columns(4).HeaderText = "الوحدة"
        'DataGridView2.Columns(5).HeaderText = "المخزن"
        'DataGridView2.Columns(6).HeaderText = "سعر الوحدة"
        'DataGridView2.Columns(7).HeaderText = "العملة"
        'DataGridView2.Columns(8).HeaderText = "م التحويل"
        'DataGridView2.Columns(9).HeaderText = "نسبة الخصم"
        'DataGridView2.Columns(10).HeaderText = "قيمة الخصم"
        'DataGridView2.Columns(11).HeaderText = "الاجمالى"
        ''GridView6.Columns(12).Caption = "نوع الصنف"
        'DataGridView2.Columns(12).HeaderText = "رقم الاذن"
        'DataGridView2.Columns(13).HeaderText = "م"

        ''Dim btn As New DevExpress.XtraGrid.Columns.GridColumn
        ''btn.Caption = "-"
        '' ''devExpress.XtraGrid.Columns.GridColumn
        ''GridView6.Columns.Insert(15, btn)
        ' ''GridView6.Columns.Add(btn)
        '' ''GridView6.Columns(14).ColumnType = btn
        '' ''Dim btn As New DataGridViewButtonColumn




        ''GridView6.Columns(14).Visible = False
        'GridView6.Columns(13).Visible = False

        ''GridView6.Columns(12).Visible = False
        'GridView6.Columns(9).Visible = False
        ''GridView6.Columns(10).Visible = False
        ''GridView6.Columns(15).Visible = False
        'DataGridView2.
        'DataGridView2.BestFitColumns()

        ''If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()


        ''GridView6.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        ''GridView6.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        ''GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        ''On Error Resume Next
        ''sum_tax()
        ''Mainmune.finwatinoderItem()
    End Sub
    Sub add_itemstores()

        sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & var_No_Invoice_ser & "' and TypeD =2  "
        rs = Cnn.Execute(sql)
        '==============================================================================================================
        Dim dd As DateTime = txt_date.Text
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        Dim result As Integer = 0


        'Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        'Dim varcodunit2 As Integer
        '=======================================================
        sql = "   SELECT Unit1, Ex_Item,code    FROM dbo.BD_ITEM    WHERE(Barcode_No = '" & txt_Barcode.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then var_codeItem = rs("code").Value
        '===========================================================
        'var_codeItem = Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(11)))
        sql = "  SELECT *     FROM BD_Stores WHERE        (Name = '" & Com_Stores.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = Trim(rs("code").Value)
        '===============================================================================
        'sql = "   SELECT *    FROM BD_Unit    WHERE(name =  '" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(4))) & "' ) and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit2 = rs("Code").Value

        '==========================================

        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
        " ,NoItem,Code_Stores,TypeD,DateMoveM,Dis,Import,Code_Sub,Price_Unit,Ex_No,Compny_Code) " & _
        " values (N'" & var_No_Invoice_ser & "',N'" & 1 & "',N'" & 1 & " ' " & _
        " ,N'" & varItCode & "', N'" & varcodStores & "',N'" & 2 & "' " & _
        " ,N'" & vardateinvoice & "',N'" & "فاتورة مبيعات" + var_No_Invoice_ser & "',N'" & 1 & "',N'" & varCodeBranch & "',N'" & varprice & " ',N'" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "') "
        Cnn.Execute(sql)


    End Sub

    Private Sub txt_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Barcode.KeyDown
        If txt_Barcode.Text.Trim = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then save_invoice() : add_itemstores() : txt_Barcode.Text = ""
        
    End Sub

    Private Sub Frm_InvoiceCashir_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then SimpleButton4_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F7 Then Cmd_CloseInvoice_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F1 Then SimpleButton11_Click(Nothing, Nothing)

    End Sub

    Private Sub Frm_InvoiceCashir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleButton4_Click(Nothing, Nothing)
        Timer1.Enabled = True
    End Sub


    Private Sub txt_cashValue_TextChanged(sender As Object, e As EventArgs) Handles txt_cashValue.TextChanged
        Total_Sum()
    End Sub

    Private Sub txt_visaValue_TextChanged(sender As Object, e As EventArgs) Handles txt_visaValue.TextChanged
        Total_Sum()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex = -1 Or DataGridView2.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim columnName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
        If columnName = "Column6" Then
            DataGridView2.Rows.Remove(DataGridView2.CurrentRow)

        End If

        Total_Sum()
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For i = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(i).Cells(6).Value = "-"

        Next
    End Sub

    Sub lastgl()
        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM  dbo.Genralledger where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(IDGenral) Is Not Null) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub

    Sub saveGl()
        Dim dd3 As DateTime = txt_date.Text
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-dd -yyyy")
        lastgl()


        '============================================================================== 
        '======================================================== فاتورة الكاشير
        varcodeCostCenter1 = "102001"


        '=======================================================المدين  من ح العملاء - او ح النقدية
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & varcodWallet & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & lb_totalInv.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & lb_totalInv.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & varcodWallet & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & lb_totalInv.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & lb_totalInv.Text & "','" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)

        ''=================================================================== خصم الكاشير
        'If Val(txt_discountPOS.Text) > 0 Then
        '    '=================================الخصم
        '    sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '    " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & DiscAcc & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & Val(txt_discountPOS.Text) & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Val(txt_discountPOS.Text) & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        '    Cnn.Execute(sql)

        '    sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '     " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & DiscAcc & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & Val(txt_discountPOS.Text) & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "' ,'" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Val(txt_discountPOS.Text) & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        '    Cnn.Execute(sql)

        'End If
        varcodeCostCenter2 = "102001"
        '==================================================================== الدائن
        If txt_cashValue.Text > 0 Then
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & salAcc & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_cashValue.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_cashValue.Text & "','" & VarCodeCompny & "','" & 1 & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
            " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & salAcc & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_cashValue.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_cashValue.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

        End If

        If txt_visaValue.Text > 0 Then
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & visaAcc & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & VarCodeCompny & "','" & 1 & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
            " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & visaAcc & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_visaValue.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

        End If

    End Sub
    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_CloseInvoice.Click
        If txt_rest.Text <> 0 Then MsgBox("برجاء التاكد من سداد المبلغ كاملا للاغلاق", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub

        saveGl()

        sql2 = "UPDATE  TB_Header_InvoiceSal  SET  cash_value='" & txt_cashValue.Text & "',visa_value= '" & txt_visaValue.Text & "', Invoice_Status='" & 1 & "',Dis_Item='" & txt_discountPOS.Text & "'   WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)
        find_hedar()
        find_detalis()
        Total_Sum()

        SimpleButton4_Click(Nothing, Nothing)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Shell("c:\Windows\System32\calc.exe")
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Frm_dataitem2.Close()

        Frm_dataitem2.MdiParent = Me
        Frm_dataitem2.Show()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        Frm_Rest.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        txt_date.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub

    Private Sub txt_Barcode_TextChanged(sender As Object, e As EventArgs) Handles txt_Barcode.TextChanged

    End Sub
End Class