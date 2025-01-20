Imports System.Data.OleDb

Public Class Frm_AznSarf
    Dim varcodeitem As Integer
    Dim varcodunit, varcodStores, varcode_customer As Integer
    Dim varcodeExitem As String
    Dim varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim varAccountStores As String
    Dim varcode_TypeStores As Integer
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

    Sub fin_qyt_avalible()
        On Error Resume Next
        sql2 = "SELECT        Name, Code        FROM dbo.BD_Stores WHERE        (Name = '" & Trim(Com_Stores.Text) & "') and Compny_Code ='" & VarCodeCompny & "' "
        'sql = "select * from BD_Stores Name ='" & Trim(Com_Stores.Text) & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodestores = rs("code").Value
        '=========================================================================

        ''====Unit 1
        'sql = "select * from Vw_ItemUnit where  (dbo.Vw_ItemUnit.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_ItemUnit.NoItem = '" & txt_CodeItem.Text & "') AND (dbo.Vw_ItemUnit.Name = '" & txt_unit.Text & "') AND (dbo.Vw_ItemUnit.Code_Stores = '" & varcodestores & "') "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance").Value, 2) Else txt_Qyt_avalible.Text = "0"
        ''=======unit2

        'sql = "      SELECT        NoItem, Code_Stores, SUM(Export) - SUM(Import) AS Balance    FROM dbo.Statement_OfItem GROUP BY NoItem, Code_Stores HAVING        (Code_Stores = '" & varcodestores & "') AND (NoItem = '" & txt_CodeItem.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance").Value, 2) Else txt_Qyt_avalible.Text = "0"


        '      sql = "  SELECT NameItem, Unit_2, SUM(ward2) AS Wa, SUM(Mnsr2) AS Mn, SUM(ward2) - SUM(Mnsr2) AS Balance1, (SUM(ward2) - SUM(Mnsr2)) / ValueUnit1 AS balnce2, Ex_Item " & _
        '" FROM     dbo.vw_all_gard_detils2 " & _
        '" GROUP BY NameItem, Unit_2, ValueUnit1, Ex_Item " & _
        '" HAVING (Ex_Item = '" & txt_CodeItem.Text & "') "
        txt_Qyt_avalible.Text = "0"
        '========================================================== unit2
        sql = " SELECT dbo.vw_all_gard_detils2.NameItem, dbo.vw_all_gard_detils2.Unit_2 AS Unit1, SUM(dbo.vw_all_gard_detils2.ward2) - SUM(dbo.vw_all_gard_detils2.Mnsr2) AS Balance1, dbo.BD_Unit.Name AS Unit2, (SUM(dbo.vw_all_gard_detils2.ward2)  " & _
             "                  - SUM(dbo.vw_all_gard_detils2.Mnsr2)) / dbo.vw_all_gard_detils2.ValueUnit1 AS balnce2, dbo.vw_all_gard_detils2.Code_Stores " & _
             " FROM     dbo.vw_all_gard_detils2 INNER JOIN " & _
             "                  dbo.BD_Item ON dbo.vw_all_gard_detils2.Ex_Item = dbo.BD_Item.Code INNER JOIN " & _
             "                  dbo.BD_Unit ON dbo.BD_Item.Unit1 = dbo.BD_Unit.Code " & _
             " GROUP BY dbo.vw_all_gard_detils2.NameItem, dbo.vw_all_gard_detils2.Unit_2, dbo.vw_all_gard_detils2.ValueUnit1, dbo.vw_all_gard_detils2.Ex_Item, dbo.BD_Unit.Name, dbo.vw_all_gard_detils2.Code_Stores " & _
             " HAVING (dbo.vw_all_gard_detils2.Ex_Item ='" & txt_CodeItem.Text & "') AND (dbo.vw_all_gard_detils2.Unit_2 = '" & txt_unit.Text & "') and Code_Stores ='" & varcodestores & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance1").Value, 2)
        '============================================= unit 1
        sql = " SELECT dbo.vw_all_gard_detils2.NameItem, dbo.vw_all_gard_detils2.Unit_2 AS Unit1, SUM(dbo.vw_all_gard_detils2.ward2) - SUM(dbo.vw_all_gard_detils2.Mnsr2) AS Balance1, dbo.BD_Unit.Name AS Unit2, (SUM(dbo.vw_all_gard_detils2.ward2)  " & _
     "                  - SUM(dbo.vw_all_gard_detils2.Mnsr2)) / dbo.vw_all_gard_detils2.ValueUnit1 AS balnce2, dbo.vw_all_gard_detils2.Code_Stores " & _
     " FROM     dbo.vw_all_gard_detils2 INNER JOIN " & _
     "                  dbo.BD_Item ON dbo.vw_all_gard_detils2.Ex_Item = dbo.BD_Item.Code INNER JOIN " & _
     "                  dbo.BD_Unit ON dbo.BD_Item.Unit1 = dbo.BD_Unit.Code " & _
     " GROUP BY dbo.vw_all_gard_detils2.NameItem, dbo.vw_all_gard_detils2.Unit_2, dbo.vw_all_gard_detils2.ValueUnit1, dbo.vw_all_gard_detils2.Ex_Item, dbo.BD_Unit.Name, dbo.vw_all_gard_detils2.Code_Stores " & _
     " HAVING (dbo.vw_all_gard_detils2.Ex_Item ='" & txt_CodeItem.Text & "') AND (dbo.BD_Unit.Name = '" & txt_unit.Text & "') and Code_Stores ='" & varcodestores & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("balnce2").Value, 2)


    End Sub



    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_AznItem_Stores     GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "1"


        End If
    End Sub


   
    Sub save_Order_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")
        '========================رقم العميل
        sql = "select * from Vw_AllCustomerAndSuppliser where Name  = '" & Txt_Customer.Text & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_customer = rs("code").Value


        '========================================= نوع الصرف 
        sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & txt_type.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_TypeStores = rs("code").Value

        sql = "select * from TB_Header_AznItem_Stores where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then




        Else


            sql = "INSERT INTO TB_Header_AznItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,Notes,Code_Sub,Code_Customer) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderSal.Text & "','" & 0 & "','" & txt_Notes.Text & "','" & varCodeBranch & "','" & varcode_customer & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','10','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        End If
        'Next
        save_oderDetils()
        save_itemStores()
        clear_detils()
        find_hedar()
        find_detalis()

    End Sub
    Sub save_itemStores()
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        'sql = "   SELECT Unit1    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit = rs("Unit1").Value

        sql = "select * from BD_Unit where Name = '" & txt_unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value

        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================


        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Code_Sub,Compny_Code,Order_Stores_NO) " & _
            " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & txt_CodeItem.Text & " ', '" & varcodunit & "','" & varcodStores & "','" & 1 & "' " & _
            " ,'" & vardateinvoice & "','" & "أذن صرف من المخزن" + Com_InvoiceNo.Text & "','" & txt_Qty.Text & "','" & varCodeBranch & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "') "
        Cnn.Execute(sql)

    End Sub
    Sub find_hedar()
        On Error Resume Next
        '       sql = "  SELECT        dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO, dbo.TB_Header_AznItem_Stores.Order_NO,  " & _
        '     "  dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Header_AznItem_Stores.Notes, dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores, dbo.BD_TypeSarfStores.Name " & _
        '" FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
        ' "                       dbo.TB_Header_AznItem_Stores ON dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Header_AznItem_Stores.Compny_Code AND  " & _
        '  "                      dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Header_AznItem_Stores.Order_Stores_NO INNER JOIN " & _
        '   "                     dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code" & _
        '  " WHERE        (dbo.TB_Header_AznItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_AznItem_Stores.Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "') "

        'sql = " SELECT        dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO, dbo.TB_Header_AznItem_Stores.Order_NO, dbo.TB_Header_AznItem_Stores.Order_Date_stores, " & _
        '     "                         dbo.TB_Header_AznItem_Stores.Notes, dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores, dbo.BD_TypeSarfStores.Name, dbo.TB_Header_AznItem_Stores.Code_Sub, dbo.BD_SUBMAIN.Name AS NameSub " & _
        '     " FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
        '     "                         dbo.TB_Header_AznItem_Stores ON dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Header_AznItem_Stores.Compny_Code AND  " & _
        '     "                         dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Header_AznItem_Stores.Order_Stores_NO INNER JOIN " & _
        '     "                         dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND  " & _
        '     "                         dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code LEFT OUTER JOIN " & _
        '     "                         dbo.BD_SUBMAIN ON dbo.TB_Header_AznItem_Stores.Code_Sub = dbo.BD_SUBMAIN.Code WHERE        (dbo.TB_Header_AznItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_AznItem_Stores.Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "') "

        sql = "SELECT        dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO, dbo.TB_Header_AznItem_Stores.Order_NO, dbo.TB_Header_AznItem_Stores.Order_Date_stores, " & _
"                         dbo.TB_Header_AznItem_Stores.Notes, dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores, dbo.BD_TypeSarfStores.Name, dbo.TB_Header_AznItem_Stores.Code_sub, dbo.BD_SUBMAIN.Name AS NameSub, " & _
"                         dbo.Vw_AllCustomerAndSuppliser.Name AS NameCustomer " & _
" FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
"                         dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code INNER JOIN " & _
"                         dbo.TB_Header_AznItem_Stores ON dbo.TB_Header_OrderItem_Stores.Order_Stores_NO = dbo.TB_Header_AznItem_Stores.Order_NO LEFT OUTER JOIN " & _
"                         dbo.Vw_AllCustomerAndSuppliser ON dbo.TB_Header_AznItem_Stores.Code_Customer = dbo.Vw_AllCustomerAndSuppliser.code LEFT OUTER JOIN " & _
"                         dbo.BD_SUBMAIN ON dbo.TB_Header_AznItem_Stores.Code_sub = dbo.BD_SUBMAIN.Code " & _
" WHERE        (dbo.TB_Header_AznItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_AznItem_Stores.Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
            txt_type.Text = Trim(rs("Name").Value)
            txt_CodeSub.Text = Trim(rs("Code_Sub").Value)
            txt_NameSub.Text = Trim(rs("NameSub").Value)
            Txt_Customer.Text = Trim(rs("NameCustomer").Value)

        End If

        sql = " SELECT dbo.Vw_LookupInvoiceSal2_Rented.Ser_InvoiceNo AS Ser_InvoiceNo, dbo.Vw_LookupInvoiceSal2_Rented.NameSu AS NameSu, dbo.Vw_DetilsInvoice2_Rented.Order_Stores_No FROM            dbo.Vw_DetilsInvoice2_Rented INNER JOIN dbo.Vw_LookupInvoiceSal2_Rented ON dbo.Vw_DetilsInvoice2_Rented.Ext_InvoiceNo = dbo.Vw_LookupInvoiceSal2_Rented.Code AND dbo.Vw_DetilsInvoice2_Rented.Compny_Code = dbo.Vw_LookupInvoiceSal2_Rented.Compny_Code WHERE(dbo.Vw_DetilsInvoice2_Rented.Order_Stores_No = '" & Com_InvoiceNo2.Text & "') AND (dbo.Vw_DetilsInvoice2_Rented.Compny_Code = '" & VarCodeCompny & "') Order By dbo.Vw_LookupInvoiceSal2_Rented.Ser_InvoiceNo DESC "
        rs = Cnn.Execute(sql)

        If IsNothing(rs("Ser_InvoiceNo").Value) Then
            'TypeBillRented = ""
        Else
            txt_InvoiceNo.Text = rs("Ser_InvoiceNo").Value
            Txt_Customer.Text = rs("NameSu").Value
            'TypeBillRented = "فاتورة مرتد مشتريات"
        End If


    End Sub
    Sub save_oderDetils()

        sql = "select * from BD_Unit where Name = '" & txt_unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value





        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        Dim Var_TotalItem As Single
        Var_TotalItem = Math.Round((0) * (txt_Qty.Text), 2)
        sql = "INSERT INTO TB_Detils_AznItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item,Code_Stores,Rat,Code_Cru,TotalItem,code_sub) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "','0','" & varcodStores & "' ,'" & 1 & "','" & 1 & "' ,'" & Var_TotalItem & "','" & varCodeBranch & "')"
        Cnn.Execute(sql)



    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.SelectedIndex = -1
        txt_Notes.Text = ""
        txt_OrderSal.Text = ""
        txt_Qyt_avalible.Text = ""
        Com_Stores.Text = ""
        txt_type.Text = ""
        Txt_Customer.Text = ""
        txt_InvoiceNo.Text = ""
        'txt_TypeItem.Text = ""
        txt_totalAzn.Text = ""
        cmd_DeleteLine.Enabled = False
        cmd_update.Enabled = False


    End Sub



    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_AznItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete TB_Header_AznItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '===================================حذف من المخزن
                sql = "Delete Statement_OfItem  WHERE NoItem = '" & varcodeitem & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo.Text & "'  "
                rs = Cnn.Execute(sql)

                find_hedar()
                find_detalis()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub





    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Frm_Gard2.ShowDialog()
    End Sub


    Sub Total_Sum()
        On Error Resume Next
        'Dim total As String = 0
        'For i As Integer = 0 To GridView6.RowCount - 1
        '    total += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(6)))
        'Next
        'txt_totalAzn.Text = total

        On Error Resume Next
        Dim total As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(9))
        Next
        txt_totalAzn.Text = Math.Round(total, 2)


    End Sub

    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select No_Item,Name,Ex_Item,Quntity,Unit,Price_Unit,TotalItem,Order_NO,Stores,AVr_Price from Vw_FindAznSarf where Compny_Code = '" & VarCodeCompny & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "اسم الصنف"
        GridView6.Columns(2).Caption = "RefNO"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "سعر الوحدة"
        GridView6.Columns(6).Caption = "الاجمالى"
        GridView6.Columns(7).Caption = "رقم طلب الصرف"
        GridView6.Columns(8).Caption = "أسم المخزن"
        GridView6.Columns(9).Caption = "سعر الوحدة"

        GridView6.Columns(2).Visible = False
        GridView6.Columns(5).Visible = False
        GridView6.Columns(6).Visible = False


        GridView6.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        Mainmune.finwatinoderItem()
    End Sub

    Sub find_Azn()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



 
        sql2 = "SELECT        TOP (100) PERCENT dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_NO, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Detils_AznItem_Stores.No_Item, " & _
 "                      BD_Item.Ex_Item,  dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_AznItem_Stores.Quntity, dbo.BD_Unit.Name AS Unit, dbo.BD_TypeSarfStores.Name, dbo.FindCustomer.Name AS NameCustomer,TB_Detils_AznItem_Stores.No_Invoice,TB_Header_OrderItem_Stores.PAO " & _
" FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
"                         dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code INNER JOIN " & _
"                         dbo.TB_Header_AznItem_Stores ON dbo.TB_Header_OrderItem_Stores.Order_Stores_NO = dbo.TB_Header_AznItem_Stores.Order_NO INNER JOIN " & _
"                         dbo.TB_Detils_AznItem_Stores ON dbo.TB_Header_AznItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AND  " & _
"                         dbo.TB_Header_AznItem_Stores.Compny_Code = dbo.TB_Detils_AznItem_Stores.Compny_Code AND dbo.TB_Header_AznItem_Stores.Code_sub = dbo.TB_Detils_AznItem_Stores.Code_Sub INNER JOIN " & _
"                         dbo.BD_Item ON dbo.TB_Detils_AznItem_Stores.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_AznItem_Stores.Code_Customer = dbo.FindCustomer.code AND dbo.TB_Header_AznItem_Stores.Compny_Code = dbo.FindCustomer.Compny_Code LEFT OUTER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_Unit.Compny_Code AND dbo.TB_Detils_AznItem_Stores.Code_Unit = dbo.BD_Unit.Code " & _
 " WHERE        (dbo.TB_Detils_AznItem_Stores.Compny_Code = '" & VarCodeCompny & "') " & _
" ORDER BY dbo.TB_Header_AznItem_Stores.Order_Date_stores "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)




        'GridView2.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        'GridView2.Columns(7).AppearanceCell.ForeColor = Color.Red

        GridView2.Appearance.Row.Font = New Font(GridView2.Appearance.Row.Font, FontStyle.Bold)
        GridView2.Appearance.Row.Options.UseFont = True

        GridView2.Columns(0).Caption = "رقم اذن الصرف"
        GridView2.Columns(1).Caption = "رقم طلب الصرف"
        GridView2.Columns(2).Caption = "التاريخ"
        GridView2.Columns(3).Caption = "كود الصنف"
        GridView2.Columns(4).Caption = "RefNo"
        GridView2.Columns(5).Caption = "اسم الصنف"
        GridView2.Columns(6).Caption = "الكمية"
        GridView2.Columns(7).Caption = "الوحدة"
        GridView2.Columns(8).Caption = "نوع طلب الصرف"
        GridView2.Columns(9).Caption = "اسم الحساب"
        GridView2.Columns(10).Caption = "الفاتورة"


        GridView2.BestFitColumns()



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        'GridView6.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        'Mainmune.finwatinoderItem()
    End Sub



    Private Sub Frm_AznSarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Stores()
        'last_Data()
        find_Azn()
        txt_CodeSub.Text = varCodeBranch
        txt_NameSub.Text = varNameBranch
        fill_Unit()
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
    Sub fill_Stores()
        Com_Stores.Items.Clear()

        sql = " SELECT Name FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Stores.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_Stores_SelectedIndexChanged(sender As Object, e As EventArgs)

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من ادخل  الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Price.Text) = 0 Then MsgBox("من ادخل  السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        fin_qyt_avalible()
    End Sub



    Private Sub Cmd_RtInvoice_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_FindOrder_Click(sender As Object, e As EventArgs)
        vartable = "Vw_Lookup_AznItem"
        VarOpenlookup = 260
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub



    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        'txt_NameItem2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        'txt_PriceUnit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Cmd_deleteAll.Enabled = True
    End Sub


    Private Sub cmd_Find_Click(sender As Object, e As EventArgs)
        Frm_LookupAznStores.Close()
        Frm_LookupAznStores.MdiParent = Mainmune
        Frm_LookupAznStores.Show()
    End Sub


    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        clear_detils()
        last_Data()
        find_hedar()
        find_detalis()
        find_Azn()
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        'If TypeBillRented = "فاتورة مرتد مشتريات" Then MsgBox("لا يمكن تعديل أذن الصرف الخاص بفاتورة مرتد مشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '==========================CheckInvoice
        sql = "   SELECT        Code, Ser_InvoiceNo        FROM dbo.Vw_Lookup_AznItem2 WHERE        (Code = '" & Com_InvoiceNo2.Text & "') AND (Ser_InvoiceNo IS NOT NULL)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحفظ الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub
        '=============================

        fin_qyt_avalible()
        If Val(txt_Qyt_avalible.Text) <= 0 Then MsgBox("لا يمكن صرف هذا العنصر لان كميته غير صالحه ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub


        sql2 = "select * from TB_Header_AznItem_Stores where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Order_NO ='" & txt_OrderSal.Text & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        fin_qyt_avalible()

        'If Val(txt_Qyt_avalible.Text) < Val(txt_Qty.Text) Then MsgBox("من فضلك الكمية المنصرفة اكبر من الكمية المتاحة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        save_Order_H()
        Total_Sum()
        find_Azn()

    End Sub
    Sub Save_GL()
        'If Len(Com_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        If Com_Stores.Text <> "" Then
            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "',flg = '" & 0 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & Com_InvoiceNo2.Text & "'  and Typebill ='" & 21 & "'  and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)



            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 21 & "' and No_Sand = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)


            If txt_totalAzn.Text = 0 Then Exit Sub

            FillAccountNo_Setting()
            lastgl()
            Dim dd As DateTime = txt_date.Value
            Dim vardateinvoice As String
            vardateinvoice = dd.ToString("MM-d-yyyy")
            '=======================================================المدين  
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varNoGL & "' ,'" & vardateinvoice & "','" & varAccountNo_Invintory & "','" & "اذن صرف من المخازن" + Com_InvoiceNo.Text & "','" & txt_totalAzn.Text & "' ,'" & 0 & "','" & 21 & "','" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & "' ,'" & 1 & "','" & txt_totalAzn.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)

            '================================================================
            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
            " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardateinvoice & "',N'" & varAccountNo_Invintory & "'  ,N'" & "اذن صرف من المخازن " + Com_InvoiceNo.Text & "',N'" & txt_totalAzn.Text & "',N'" & 0 & "',N'" & "21" & "',N'" & Com_InvoiceNo.Text & "','" & 1 & "' ,'" & 1 & "' ,'" & txt_totalAzn.Text & "','" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)




            '=======================================================المدين  
            sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Cridit,Debit,Typebill,No_Sand,No_serail,Code_Sub,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varNoGL & "' ,'" & vardateinvoice & "','" & varAccountNo_CostInvintory & "','" & "اذن صرف من المخازن" + Com_InvoiceNo.Text & "','" & 0 & "' ,'" & txt_totalAzn.Text & "','" & 0 & "','" & "21" & "','" & 1 & "','" & 1 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_totalAzn.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)

            '================================================================
            sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Cridit,Debit,TypeBill,No_Sand,Code_Sub,CruunceyNo,Cridit_EGP,Debit_EGP,Compny_Code) " & _
            " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardateinvoice & "',N'" & varAccountNo_CostInvintory & "'  ,N'" & "اذن صرف من المخازن " + Com_InvoiceNo.Text & "',N'" & 0 & "',N'" & txt_totalAzn.Text & "',N'" & "0" & "',N'" & "21" & "','" & 1 & "' ,'" & 1 & "' ,'" & 0 & "','" & txt_totalAzn.Text & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

            MsgBox("تم انشاء القيد", MsgBoxStyle.Information, "Css Solution Software Module") : Exit Sub

        End If
    End Sub
    Sub FillAccountNo_Setting()

        sql = "select * from BD_Stores where name ='" & Com_Stores.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            sql2 = "SELECT AccountNoGroup, AccountNoGroup2 FROM     dbo.TB_SettingGroup1 WHERE  (Code_Stores = '" & rs("code").Value & "')"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varAccountNo_Invintory = rs2("AccountNoGroup").Value : varAccountNo_CostInvintory = rs2("AccountNoGroup2").Value



        End If
    End Sub

    Private Sub Com_Stores_Click(sender As Object, e As EventArgs)
        fin_qyt_avalible()
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Frm_GardItem2.txt_codeItem.Text = txt_CodeItem.Text
        Frm_GardItem2.txt_NameItem.Text = txt_NameItem.Text
        Frm_GardItem2.Com_Stores.Text = Com_Stores.Text
        Frm_GardItem2.FindBalance()
        'Frm_GardItem2.Com_Stores.Text = txt_namestores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        Com_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        txt_OrderSal.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        cmd_DeleteLine.Enabled = True
        cmd_update.Enabled = True
        fin_qyt_avalible()
    End Sub

    Private Sub Cmd_FindOrder_Click_1(sender As Object, e As EventArgs) Handles Cmd_FindOrder.Click
        txt_InvoiceNo.Text = ""
        vartable = "Vw_Lookup_AznItem2"
        VarOpenlookup = 260
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.SelectedIndex = -1
        txt_Notes.Text = ""
        txt_OrderSal.Text = ""
        txt_Qyt_avalible.Text = ""
        Com_Stores.Text = ""
        txt_type.Text = ""
        Txt_Customer.Text = ""

        'txt_TypeItem.Text = ""
        txt_totalAzn.Text = ""
        cmd_DeleteLine.Enabled = False
        cmd_update.Enabled = False
        find_hedar()
        find_detalis()
        Total_Sum()

    End Sub

  

   

   
    
    Private Sub Cmd_deleteAll_Click(sender As Object, e As EventArgs) Handles Cmd_deleteAll.Click
        On Error Resume Next
        'If TypeBillRented = "فاتورة مرتد مشتريات" Then MsgBox("لا يمكن تعديل أذن الصرف الخاص بفاتورة مرتد مشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If varstatus = "منصرف" Then MsgBox("هذا الاذن تم صرفة ولا يمكن حذفه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        'sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_Stores_NO = '" & Com_InvoiceNo.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=====================================================

        '==========================CheckInvoice
        sql = "   SELECT        Code, Ser_InvoiceNo        FROM dbo.Vw_Lookup_AznItem2 WHERE        (Code = '" & Com_InvoiceNo2.Text & "') AND (Ser_InvoiceNo IS NOT NULL)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحفظ الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub
        '=============================


        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاذن", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                sql = "Delete TB_Detils_AznItem_Stores  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete TB_Header_AznItem_Stores  WHERE Order_Stores_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','10','11','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                clear_detils()
                find_Azn()
        End Select
    End Sub

    Private Sub cmd_DeleteLine_Click(sender As Object, e As EventArgs) Handles cmd_DeleteLine.Click
        On Error Resume Next
        'If TypeBillRented = "فاتورة مرتد مشتريات" Then MsgBox("لا يمكن تعديل أذن الصرف الخاص بفاتورة مرتد مشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '====================================

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        '==========================CheckInvoice
        sql = "   SELECT        Code, Ser_InvoiceNo        FROM dbo.Vw_Lookup_AznItem2 WHERE        (Code = '" & Com_InvoiceNo2.Text & "') AND (Ser_InvoiceNo IS NOT NULL)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحفظ الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub
        '=============================


        'sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_Stores_NO = '" & Com_InvoiceNo.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=====================================================



        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "Delete TB_Detils_AznItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete Statement_OfItem  WHERE NoItem = '" & varcodeitem & "' and NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','10','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                find_Azn()
        End Select
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click
        'If TypeBillRented = "فاتورة مرتد مشتريات" Then MsgBox("لا يمكن تعديل أذن الصرف الخاص بفاتورة مرتد مشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        '==========================CheckInvoice
        sql = "   SELECT        Code, Ser_InvoiceNo        FROM dbo.Vw_Lookup_AznItem2 WHERE        (Code = '" & Com_InvoiceNo2.Text & "') AND (Ser_InvoiceNo IS NOT NULL) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحفظ الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub
        '=============================



        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================

        '======================================No Unit
        sql = "   SELECT Code   FROM BD_Unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value
        ''=================================================
        ''============================================================== نوع الصرف
        'sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & txt_type.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_TypeStores = rs("code").Value
        ''================================================================== كود العميل
        sql = "select * from FindCustomer where Name  = '" & Txt_Customer.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_customer = rs("code").Value





        sql = "UPDATE  TB_Header_AznItem_Stores  SET Code_Customer = '" & varcode_customer & "' , Notes = '" & txt_Notes.Text & "'   WHERE   Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        sql = "UPDATE  TB_Detils_AznItem_Stores  SET Quntity = '" & txt_Qty.Text & "',Code_Unit = '" & varcodunit & "', Code_Stores ='" & varcodStores & "'  WHERE  No_Item = '" & txt_CodeItem.Text & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        sql = "UPDATE  Statement_OfItem  SET Import = '" & txt_Qty.Text & "',Code_Unit = '" & varcodunit & "', Code_Stores ='" & varcodStores & "'  WHERE  NoItem = '" & txt_CodeItem.Text & "' and NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)

        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','10','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        MsgBox("تم التعديل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "CSS Solution Software Module")
        find_hedar()
        find_detalis()

    End Sub

    Private Sub Com_Stores_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        fin_qyt_avalible()
    End Sub

    Private Sub txt_OrderSal_TextChanged(sender As Object, e As EventArgs) Handles txt_OrderSal.TextChanged

    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        frm_AznSarfPrinting.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView2.ShowRibbonPrintPreview()

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        clear_detils()
        fill_Stores()

        Com_InvoiceNo2.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        Com_InvoiceNo.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        txt_OrderSal.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(1))
        txt_type.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(7))
        txt_InvoiceNo.Text = Mid(GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(10)), 4, 5)
        find_hedar()
        find_detalis()
       
        find_Gl()
        Total_Sum()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Sub find_Gl()
        '====================================
        sql = " Select IDGenral      FROM dbo.Genralledger GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 21) AND (Code_Sub = '" & varcode_Branch & "') AND (No_Sand = '" & Com_InvoiceNo2.Text & "') and flgcancle = '" & 0 & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_GL.Text = (rs("IDGenral").Value)
        Else
            Com_GL.Text = ""
        End If
        '=========================================================
    End Sub


    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txt_InvoiceNo.Text = "" Then MsgBox("من فضلك اختار رقم الفاتورة", MsgBoxStyle.Critical, "css") : Exit Sub


        If txt_type.Text = "" Then
            Frm_SalseInvoice.Com_InvoiceNo.Text = txt_InvoiceNo.Text
            Frm_SalseInvoice.Com_InvoiceNo2.Text = "INV" + txt_InvoiceNo.Text
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.find_Invoice_Condation()
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Show()
        Else
            Frm_Prcheses_Invoice_Rented.Com_InvoiceNo.Text = txt_InvoiceNo.Text
            Frm_Prcheses_Invoice_Rented.Com_InvoiceNo2.Text = "INV000" + txt_InvoiceNo.Text
            Frm_Prcheses_Invoice_Rented.find_hedar()
            Frm_Prcheses_Invoice_Rented.find_detalis()
            Frm_Prcheses_Invoice_Rented.find_Invoice_Condation()
            Frm_Prcheses_Invoice_Rented.Total_Sum()
            Frm_Prcheses_Invoice_Rented.sum_tax()
            Frm_Prcheses_Invoice_Rented.MdiParent = Mainmune
            Frm_Prcheses_Invoice_Rented.Show()
        End If

        'Frm_SalseInvoice.Com_InvoiceNo2.Text = "INV" + txt_InvoiceNo.Text
        'Frm_SalseInvoice.find_hedar()
        'Frm_SalseInvoice.find_detalis()
        'Frm_SalseInvoice.find_Invoice_Condation()
        'Frm_SalseInvoice.Total_Sum()
        'Frm_SalseInvoice.sum_tax()
        'Frm_SalseInvoice.MdiParent = Mainmune
        'Frm_SalseInvoice.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        VarOpenlookup2 = 2400
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        If txt_CodeItem.Text = "" Then MsgBox("من فضلك اختار الصنف", MsgBoxStyle.Critical, "Css") : Exit Sub
        varcode_item = txt_CodeItem.Text : varnamestores = Com_Stores.Text
        'Frm_GardDetils.Close()
        Frm_GardDetils.txt_stores.Text = Com_Stores.Text
        Frm_GardDetils.txt_NameItem.Text = txt_NameItem.Text

        Frm_GardDetils.find_Gard_detils()
        Frm_GardDetils.find_balance()
        Frm_GardDetils.MdiParent = Mainmune
        Frm_GardDetils.Show()
    End Sub

    Private Sub txt_unit_TextChanged(sender As Object, e As EventArgs)

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

    Private Sub cmd_Find_Click_1(sender As Object, e As EventArgs) Handles cmd_Find.Click
        Frm_LookupAznStores.Close()
        Frm_LookupAznStores.MdiParent = Mainmune
        Frm_LookupAznStores.Show()
    End Sub

    Private Sub Com_Stores_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles Com_Stores.SelectedIndexChanged
        fin_qyt_avalible()
    End Sub

    Private Sub Com_Stores_Click_1(sender As Object, e As EventArgs) Handles Com_Stores.Click
        fin_qyt_avalible()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Frm_GardItem2.txt_codeItem.Text = txt_CodeItem.Text
        Frm_GardItem2.txt_NameItem.Text = txt_NameItem.Text
        Frm_GardItem2.Com_Stores.Text = Com_Stores.Text
        Frm_GardItem2.FindBalance()
        'Frm_GardItem2.Com_Stores.Text = txt_namestores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If txt_CodeItem.Text = "" Then MsgBox("من فضلك اختار الصنف", MsgBoxStyle.Critical, "Css") : Exit Sub
        varcode_item = txt_CodeItem.Text : varnamestores = Com_Stores.Text
        'Frm_GardDetils.Close()
        Frm_GardDetils.txt_stores.Text = Com_Stores.Text
        Frm_GardDetils.txt_NameItem.Text = txt_NameItem.Text

        Frm_GardDetils.find_Gard_detils()
        Frm_GardDetils.find_balance()
        Frm_GardDetils.MdiParent = Mainmune
        Frm_GardDetils.Show()
    End Sub

   
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        'Frm_Cust.MdiParent = Mainmune
        'Frm_Cust.Show()

        ''On Error Resume Next
        'If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'Dim dd3 As DateTime = txt_date.Text
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM-d-yyyy")

        'lastgl()

        ''If txt_Type.Text = "أجل" Then
        ''find_tax()

        ''============================= رقم حساب البضاعة المباعة تكلفة الخام
        'If txt_TypeItem.Text = "مادة خام" Then
        '    sql = "    SELECT        dbo.Tb_TaxInvoice.Account_Stores_Matril, dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameStores " & _
        '" FROM            dbo.Tb_TaxInvoice LEFT OUTER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.Tb_TaxInvoice.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.Tb_TaxInvoice.Account_Stores_Matril = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        '" WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') "

        'Else

        '    sql = "    SELECT        dbo.Tb_TaxInvoice.Account_Stores, dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameStores " & _
        '" FROM            dbo.Tb_TaxInvoice LEFT OUTER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.Tb_TaxInvoice.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.Tb_TaxInvoice.Account_Stores = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        '" WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') "
        'End If

        'rs3 = Cnn.Execute(sql)
        'If txt_TypeItem.Text = "مادة خام" Then
        '    If rs3.EOF = False Then varAccountStores = rs3("Account_Stores_Matril").Value
        'End If

        'If txt_TypeItem.Text <> "مادة خام" Then
        '    If rs3.EOF = False Then varAccountStores = rs3("Account_Stores").Value
        'End If




        ''=============رقم مركز التكلفة
        'sql = "  SELECT        *      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & varAccountStores & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value

        ''======================================================= تكلفة بضاعة مباعة  قيد مدين
        'sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '" values  ('" & varNoGL & "' ,'" & vardate3 & "','" & varAccountStores & "','" & "  اذن صرف رقم " + Com_InvoiceNo2.Text & "','" & txt_totalAzn.Text & "' ,'" & 0 & "','" & 10 & "','" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & txt_totalAzn.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        'Cnn.Execute(sql)
        ''================================================================
        'sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '" values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & varAccountStores & "'  ,N'" & "اذن صرف رقم " + Com_InvoiceNo2.Text & "',N'" & txt_totalAzn.Text & "',N'" & 0 & "',N'" & "10" & "',N'" & Com_InvoiceNo2.Text & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "' ,'" & txt_totalAzn.Text & "','" & 0 & "','" & VarCodeCompny & "' )"
        'Cnn.Execute(sql)


        ''==========================================حساب المخزون
        'If txt_TypeItem.Text = "مادة خام" Then
        '    sql = "select * from Vw_AznSarf_Matril where Order_Stores_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        'Else
        '    sql = "select * from Vw_AznSarf_Item where Order_Stores_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        'End If

        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF

        '    '=============رقم مركز التكلفة
        '    sql = "  SELECT        *     FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & rs("AccountNoGroup").Value & "') and Compny_Code ='" & VarCodeCompny & "'"
        '    rs2 = Cnn.Execute(sql)
        '    If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '    '=============================


        '    '========================================================================== حساب المخزون 

        '    sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '        " values  ('" & varNoGL & "' ,'" & vardate3 & "','" & rs("AccountNoGroup").Value & "','" & "اذن صرف رقم " + Com_InvoiceNo2.Text & "','" & 0 & "' ,'" & rs("TotalGroup").Value & "','" & 10 & "','" & Com_InvoiceNo2.Text & "','" & 2 & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & rs("TotalGroup").Value & "','" & VarCodeCompny & "')"
        '    Cnn.Execute(sql)



        '    sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        '     " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardate3 & "',N'" & rs("AccountNoGroup").Value & "'  ,N'" & "اذن صرف رقم" + Com_InvoiceNo2.Text & "',N'" & 0 & "',N'" & rs("TotalGroup").Value & "',N'" & "10" & "',N'" & Com_InvoiceNo2.Text & "','" & varcodesub & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & rs("TotalGroup").Value & "','" & VarCodeCompny & "' )"
        '    Cnn.Execute(sql)



        '    rs.MoveNext()
        'Loop


        'MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Save_GL()
        find_Gl()
    End Sub

    Private Sub Cmd_OpenGL_Click(sender As Object, e As EventArgs) Handles Cmd_OpenGL.Click
        Com_GL.Text = ""
        Com_GL.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 21) AND (Code_Sub = '" & varcode_Branch & "') AND (No_Sand = '" & Com_InvoiceNo2.Text & "') and flgcancle = '" & 0 & "'  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_GL.Items.Add(rs("IDGenral").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_GL_Click(sender As Object, e As EventArgs) Handles Com_GL.Click

    End Sub

    Private Sub Com_GL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_GL.SelectedIndexChanged
        Frm_Gl4.Com_GL_No.Text = Com_GL.Text
        'varcodegl = Com_InvoiceNo.Text
        statusopen = 1
        Frm_Gl4.find_hedar()
        Frm_Gl4.find_detalis()
        Frm_Gl4.Total_Sum()
        Frm_Gl4.MdiParent = Mainmune
        Frm_Gl4.Show()
    End Sub
End Class