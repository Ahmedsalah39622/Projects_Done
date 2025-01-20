Imports System.Data.OleDb

Public Class Frm_InvoiceCasherRented

    Dim varInvSerial, var_No_Invoice_ser, var_No_Invoice_EXT As String
    Dim varcodStores, varcodWallet, varAccNo As Integer
    Dim salAcc, DiscAcc, visaAcc, Ser_InvoiceNo As String
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim varCodeUnit, varNameUnit As String
    Dim varAbility As String

    Sub clear_details()
        DataGridView2.DataSource = Nothing
        'txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        txt_Barcode.Text = ""
        txt_cashValue.Text = "0.0"
        txt_discountPOS.Text = "0.0"
        txt_visaValue.Text = "0.0"
        txt_rest.Text = "0.0"
        lb_totalInv.Text = "0.0 الاجمالى "
        txt_NameSalse.Text = varnameuser
        lb_branchName.Text = varNameBranch
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
    Sub get_invSerial()
        sql2 = "   SELECT       inv_serial         FROM BD_POS_Setting WHERE        (branch_Code = '" & varCodeBranch & "') AND (company_code = '" & VarCodeCompny & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then varInvSerial = rs2("inv_serial").Value
    End Sub
    Sub last_Data()


        get_invSerial()
        sql = "     SELECT        MAX(Ser_InvoiceNo) AS MaxMaim, Compny_Code       FROM dbo.TB_Header_InvoiceRented GROUP BY Compny_Code,Branch_No HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) AND (Compny_Code = '" & VarCodeCompny & "') and (Branch_No = '" & varCodeBranch & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Ser_InvoiceNo = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = varInvSerial + Ser_InvoiceNo

        Else
            'If VarCodeCompny = 3 Then Com_InvoiceNo.Text = 1

            'If VarCodeCompny = 2 Then Com_InvoiceNo.Text = "1"
            If VarCodeCompny = 1 Then Ser_InvoiceNo = "1"

            'If VarCodeCompny = 2 Then Com_InvoiceNo2.Text = "INV" + "1"
            If VarCodeCompny = 1 Then Com_InvoiceNo2.Text = varInvSerial + "R" + "1"
        End If

    End Sub
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        clear_details()
        txt_Barcode.Select()
        get_accountVal()
        get_Disc_Sal_Acc()
        get_Store()
        get_wallet()

        last_Data()
    End Sub

    Private Sub Frm_InvoiceCasherRented_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmd_New_Click(Nothing, Nothing)
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txt_date.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub

    Private Sub txt_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Barcode.KeyDown
        If txt_Barcode.Text.Trim = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then save_invoice() : add_itemstores() : txt_Barcode.Text = ""
    End Sub
    Sub save_invoice()

        sql2 = "select * from TB_Header_InvoiceRented where Ser_InvoiceNo  = '" & Ser_InvoiceNo & "' and Compny_Code =  '" & VarCodeCompny & "'  and Branch_No =  '" & varCodeBranch & "' "
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
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoiceRented where Ser_InvoiceNo  = " & Ser_InvoiceNo & "  and Compny_Code ='" & VarCodeCompny & "' and Branch_No =  '" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_InvoiceRented (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Branch_No,wallet_Code) " & _
                      " values  ('" & Ser_InvoiceNo & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & varAccNo & "','" & varcode_User & "','" & 0 & "','" & 0 & "','" & varCodeBranch & "','" & varcodWallet & "')"
            Cnn.Execute(sql)



        End If

        save_InvoiceDetils()
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
        'txt_rest.Text = Math.Round(total - Val(txt_cashValue.Text) - Val(txt_visaValue.Text) - Val(txt_discountPOS.Text), 2)
    End Sub
    Sub find_hedar()
        On Error Resume Next

        sql2 = "SELECT        dbo.TB_Header_InvoiceRented.Ser_InvoiceNo, dbo.TB_Header_InvoiceRented.Ext_InvoiceNo, dbo.TB_Header_InvoiceRented.InvoiceDate, dbo.TB_Header_InvoiceRented.Customer_No, " & _
         "                dbo.TB_Header_InvoiceRented.PayStatus, dbo.TB_Header_InvoiceRented.Salse_No, dbo.Emp_employees.Emp_Name,  iif(dbo.TB_Header_InvoiceRented.Invoice_Type='1', 'مغلق', 'جديد') AS Type, iif(dbo.TB_Header_InvoiceRented.Invoice_Status='0', 'فاتورة مبدئية', 'مرحل') as Invoice_Status, dbo.TB_Header_InvoiceRented.Invoice_Type, dbo.ST_CHARTOFACCOUNT.Account_No, " & _
      "  dbo.ST_CHARTOFACCOUNT.AccountName" & _
"FROM            dbo.Emp_employees INNER JOIN" & _
    "                     dbo.TB_Header_InvoiceRented ON dbo.Emp_employees.Compny_Code = dbo.TB_Header_InvoiceRented.Compny_Code AND dbo.Emp_employees.Emp_Code = dbo.TB_Header_InvoiceRented.Salse_No INNER JOIN " & _
     "                    dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_InvoiceRented.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Header_InvoiceRented.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No  " & _
    " WHERE        (dbo.TB_Header_InvoiceRented.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') and dbo.TB_Header_InvoiceRented.Compny_Code = '" & VarCodeCompny & "' "


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

            MsgBox(Trim(rs3("Invoice_Status").Value))

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



        sql2 = "SELECT        dbo.Vw_DetilsInvoice_rented.Ext_InvoiceNo, dbo.Vw_DetilsInvoice_rented.No_Item, dbo.Vw_DetilsInvoice_rented.Ex_Item, dbo.BD_Item.Name, dbo.Vw_DetilsInvoice_rented.Quntity, dbo.Vw_DetilsInvoice_rented.Unit, " & _
       " dbo.Vw_DetilsInvoice_rented.NameStores, dbo.Vw_DetilsInvoice_rented.Price_Item, dbo.Vw_DetilsInvoice_rented.Total_Item, dbo.Vw_DetilsInvoice_rented.Name_Cru, dbo.Vw_DetilsInvoice_rented.Rat_Invoice," & _
       " dbo.Vw_DetilsInvoice_rented.Discount_Item, dbo.Vw_DetilsInvoice_rented.Value_Discount, dbo.Vw_DetilsInvoice_rented.Order_Stores_No, dbo.Vw_DetilsInvoice_rented.Seril_No " & _
"FROM            dbo.Vw_DetilsInvoice_rented INNER JOIN" & _
  "                       dbo.BD_Item ON dbo.Vw_DetilsInvoice_rented.No_Item = dbo.BD_Item.Code" & _
            " where  (dbo.Vw_DetilsInvoice_rented.Ext_InvoiceNo = '" & Com_InvoiceNo2.Text & "') AND (dbo.Vw_DetilsInvoice_rented.Compny_Code = '" & VarCodeCompny & "') "

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
    End Sub

    Sub get_unitName()
        sql2 = "SELECT        Code, Name FROM            dbo.BD_Unit WHERE        (code = N'" & varCodeUnit & "') and  Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            varNameUnit = rs("Name").Value
        End If

    End Sub
    Sub find_itemData()
        sql2 = "SELECT        dbo.BD_Item.Code, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.TB_Detalis_InvoiceSal.Price_Item, dbo.TB_Detalis_InvoiceSal.Item_Barcode, dbo.TB_Detalis_InvoiceSal.Code_Unit FROM            dbo.BD_Item INNER JOIN dbo.TB_Detalis_InvoiceSal ON dbo.BD_Item.Code = dbo.TB_Detalis_InvoiceSal.No_Item AND dbo.BD_Item.Compny_Code = dbo.TB_Detalis_InvoiceSal.Compny_Code WHERE        (TB_Detalis_InvoiceSal.Item_Barcode = N'" & txt_Barcode.Text & "') and  TB_Detalis_InvoiceSal.Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            varItCode = rs("Code").Value
            varItExCode = rs("Ex_Item").Value
            varprice = rs("Price_Item").Value
            varItemName = rs("Name").Value
            varCodeUnit = rs("Code_Unit").Value
            get_unitName()
        End If
    End Sub
    Sub save_InvoiceDetils()
        sql2 = "SELECT        dbo.TB_Detalis_InvoiceSal.Item_Barcode, dbo.TB_Header_InvoiceSal.InvoiceDate + 14 AS LastDate, GETDATE() AS CurrentDate , iif (GETDATE() > dbo.TB_Header_InvoiceSal.InvoiceDate + 14, 'هذا الصنف تخطى المدة المسموحة','يمكن استرجاعه') as ability" & _
" FROM            dbo.TB_Detalis_InvoiceSal LEFT OUTER JOIN " & _
  "                       dbo.TB_Header_InvoiceSal ON dbo.TB_Detalis_InvoiceSal.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.TB_Detalis_InvoiceSal.Ser_InvoiceNo = dbo.TB_Header_InvoiceSal.Ser_InvoiceNo" & _
"  WHERE        (Item_Barcode = N'" & txt_Barcode.Text & "')    "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            'varItCode = rs("Code").Value
            'varItExCode = rs("Ex_Item").Value
            'varprice = rs("PriceSal").Value
            'varItemName = rs("Name").Value
            'varCodeUnit = rs("unit1").Value
            'get_unitName()
            varAbility = rs("ability").Value

            If varAbility = "هذا الصنف تخطى المدة المسموحة" Then MsgBox("هذا الصنف تخطى المدة المسموحة", MsgBoxStyle.Critical, "") : Exit Sub
        End If

        find_itemData()

        sql = "INSERT INTO TB_Detalis_InvoiceRented (Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Item_Discription) " & _
              " values  ('" & Ser_InvoiceNo & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & varItCode & "','" & varItExCode & "','" & 1 & "','" & varCodeUnit & "','" & 0 & "','" & varcodStores & "','" & varprice & "','" & varItemName & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub txt_Barcode_TextChanged(sender As Object, e As EventArgs) Handles txt_Barcode.TextChanged

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
        " ,NoItem,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,Price_Unit,Ex_No,Compny_Code) " & _
        " values (N'" & var_No_Invoice_ser & "',N'" & 1 & "',N'" & 1 & " ' " & _
        " ,N'" & varItCode & "', N'" & varcodStores & "',N'" & 2 & "' " & _
        " ,N'" & vardateinvoice & "',N'" & "فاتورة استرجاع" + var_No_Invoice_ser & "',N'" & 1 & "',N'" & varCodeBranch & "',N'" & varprice & " ',N'" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "') "
        Cnn.Execute(sql)


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
        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & salAcc & "','" & "فاتورة استرجاع رقم " + Com_InvoiceNo2.Text & "','" & lb_totalInv.Text & "' ,'" & 0 & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & lb_totalInv.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & salAcc & "'  ,N'" & "فاتورة استرجاع رقم " + Com_InvoiceNo2.Text & "',N'" & lb_totalInv.Text & "',N'" & 0 & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & lb_totalInv.Text & "','" & 0 & "','" & VarCodeCompny & "')"
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
" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & varcodWallet & "','" & "فاتورة استرجاع رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & lb_totalInv.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_cashValue.Text & "','" & VarCodeCompny & "','" & 1 & "')"
            Cnn.Execute(sql)

            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
            " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & varcodWallet & "'  ,N'" & "فاتورة استرجاع رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & lb_totalInv.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_cashValue.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

        End If

        '        If txt_visaValue.Text > 0 Then
        '            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg) " & _
        '" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & visaAcc & "','" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & 2 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & VarCodeCompny & "','" & 1 & "')"
        '            Cnn.Execute(sql)

        '            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '            " values  (N'" & var_No_Invoice_ser & "' ,N'" & vardate3 & "',N'" & visaAcc & "'  ,N'" & "فاتورة مبيعات رقم " + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & txt_visaValue.Text & "',N'" & "2" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_visaValue.Text & "','" & VarCodeCompny & "' )"
        '            Cnn.Execute(sql)

        '        End If

    End Sub


    Private Sub Cmd_CloseInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_CloseInvoice.Click

        saveGl()

        sql2 = "UPDATE  TB_Header_InvoiceRented  SET Invoice_Status='" & 1 & "'    WHERE Compny_Code = " & VarCodeCompny & "  and Ext_InvoiceNo ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)
        find_hedar()
        find_detalis()
        Total_Sum()

        Cmd_New_Click(Nothing, Nothing)

    End Sub
End Class