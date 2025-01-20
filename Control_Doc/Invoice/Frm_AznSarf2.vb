Imports System.Data.OleDb

Public Class Frm_AznSarf2
    Dim varcodeitem, varflagItem, VarcodeGroupItem As Integer
    Dim varcodunit, VarMove1, var_serilNO2, varserial_Update As Integer
    Dim varcodeExitem As String
    Dim varcodeCostCenter1, varcodeCostCenter2, VarAccountTax_Invoice As String
    Dim varAccountStores As String
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

        Frm_LookupAznStores.Close()
        Frm_LookupAznStores.MdiParent = Mainmune
        Frm_LookupAznStores.Show()
    End Sub
    Sub fin_qyt_avalible()
        'On Error Resume Next

        'If Com_Stores.Text <> "" And txt_unit.Text <> "" Then
        '    sql = "select * from BD_Stores Name ='" & Com_Stores.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then varcodestores = rs("code").Value
        '    '=========================================================================

        '    ''====Unit 1
        '    'sql = "select * from Vw_ItemUnit where  (dbo.Vw_ItemUnit.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_ItemUnit.NoItem = '" & txt_CodeItem.Text & "') AND (dbo.Vw_ItemUnit.Name = '" & txt_unit.Text & "') AND (dbo.Vw_ItemUnit.Code_Stores = '" & varcodestores & "') "
        '    'rs = Cnn.Execute(sql)
        '    'If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance").Value, 2) Else txt_Qyt_avalible.Text = "0"
        '    ''=======unit2
        '    'sql = "select * from Vw_ItemUnit where  (dbo.Vw_ItemUnit.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_ItemUnit.NoItem = '" & txt_CodeItem.Text & "') AND (dbo.Vw_ItemUnit.Unit2 = '" & txt_unit.Text & "') AND (dbo.Vw_ItemUnit.Code_Stores = '" & varcodestores & "') "
        '    'rs = Cnn.Execute(sql)
        '    'If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance2").Value, 2) Else txt_Qyt_avalible.Text = "0"

        'End If



    End Sub



    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_AznItem_Stores     GROUP BY Compny_Code  HAVING        (MAX(Order_Stores_NO) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "1"


        End If
    End Sub

    Sub last_Data_serilNo()

        sql = "  SELECT        MAX(Seril_No) AS MaxMaim, Compny_Code FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "')" & _
    " GROUP BY Compny_Code HAVING        (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            var_serilNO = rs("MaxMaim").Value + 1


        Else
            var_serilNO = 1



        End If
    End Sub


    

    Sub save_Order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_AznItem_Stores where Order_Stores_NO  = " & Com_InvoiceNo2.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            Dim varstatus2 As Integer
            If OP1.Checked = True Then varstatus2 = 0
            If Op2.Checked = True Then varstatus2 = 1

            Dim varTypeAzn As Integer
            If Com_TypeAzn.Text = "أمر توريد" Then varTypeAzn = 0
            If Com_TypeAzn.Text = "مرتد" Then varTypeAzn = 1


            sql = "INSERT INTO TB_Header_AznItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Status_Order_Stores,Notes,Type_Azn,Order_NO,Notes2) " & _
                      " values  ('" & Com_InvoiceNo2.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & varstatus2 & "','" & txt_Notes.Text & "','" & varTypeAzn & "','" & txt_OrderSal.Text & "','" & txt_Notes2.Text & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','23','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        End If
        'Next
        save_oderDetils()
        save_itemStores()
        clear_detils()

        'find_detalis()
    End Sub
   
    Sub save_itemStores()
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        'sql = "   SELECT Unit1    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit = rs("Unit1").Value
        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================

   
        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
       " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Code_Sub,Compny_Code) " & _
       " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
       " ,'" & txt_CodeItem.Text & " ', '" & varcodunit & "','" & varcodStores & "','" & 1 & "' " & _
       " ,'" & vardateinvoice & "','" & "أذن صرف من المخزن" + Com_InvoiceNo.Text & "','" & txt_Qty.Text & "','" & 1 & "','" & VarCodeCompny & "') "
        Cnn.Execute(sql)

       

    End Sub
    Sub find_hedar()

        On Error Resume Next
        sql = "  SELECT        dbo.TB_Header_AznItem_Stores.Type_Azn, dbo.TB_Header_AznItem_Stores.Status_Order_Stores, dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO,  " & _
  "                         dbo.TB_Header_AznItem_Stores.Compny_Code, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Header_AznItem_Stores.Notes, dbo.FindCustomer.Name,  dbo.TB_Header_AznItem_Stores.Order_NO,dbo.TB_Header_AznItem_Stores.Notes2 " & _
  " FROM            dbo.TB_Header_AznItem_Stores INNER JOIN " & _
  "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_AznItem_Stores.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
  "                         dbo.TB_Header_AznItem_Stores.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code LEFT OUTER JOIN " & _
  "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code " & _
  " GROUP BY dbo.TB_Header_AznItem_Stores.Type_Azn, dbo.TB_Header_AznItem_Stores.Status_Order_Stores, dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO,  " & _
  "        dbo.TB_Header_AznItem_Stores.Compny_Code, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Header_AznItem_Stores.Notes, dbo.FindCustomer.Name,  dbo.TB_Header_AznItem_Stores.Order_NO,dbo.TB_Header_AznItem_Stores.Notes2 " & _
  " HAVING        (dbo.TB_Header_AznItem_Stores.Compny_Code =  '" & VarCodeCompny & "') AND (dbo.TB_Header_AznItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            txt_Notes2.Text = Trim(rs("Notes2").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
            'txt_TypeItem.Text = Trim(rs("Type_item").Value)
            txt_NameCustomer.Text = Trim(rs("Name").Value)
            'txt_Tax.Text = Trim(rs("StatusTax").Value)

            If Trim(rs("Status_Order_Stores").Value) = 0 Then OP1.Checked = True
            If Trim(rs("Status_Order_Stores").Value) = 1 Then Op2.Checked = True


            If Trim(rs("Type_Azn").Value) = 0 Then Com_TypeAzn.Text = "أمر توريد"
            If Trim(rs("Type_Azn").Value) = 1 Then Com_TypeAzn.Text = "مرتد"
        End If

    End Sub
    Sub find_hedar2()

        On Error Resume Next
        sql = "  SELECT        dbo.TB_Header_AznItem_Stores.Type_Azn, dbo.TB_Header_AznItem_Stores.Status_Order_Stores, dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO,  " & _
  "                         dbo.TB_Header_AznItem_Stores.Compny_Code, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Header_AznItem_Stores.Notes, dbo.FindCustomer.Name,  dbo.TB_Header_AznItem_Stores.Order_NO,dbo.TB_Header_AznItem_Stores.Notes2 " & _
  " FROM            dbo.TB_Header_AznItem_Stores INNER JOIN " & _
  "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_AznItem_Stores.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
  "                         dbo.TB_Header_AznItem_Stores.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code LEFT OUTER JOIN " & _
  "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code " & _
  " GROUP BY dbo.TB_Header_AznItem_Stores.Type_Azn, dbo.TB_Header_AznItem_Stores.Status_Order_Stores, dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Header_AznItem_Stores.Order_Stores_NO,  " & _
  "        dbo.TB_Header_AznItem_Stores.Compny_Code, dbo.TB_Header_AznItem_Stores.Order_Date_stores, dbo.TB_Header_AznItem_Stores.Notes, dbo.FindCustomer.Name,  dbo.TB_Header_AznItem_Stores.Order_NO,dbo.TB_Header_AznItem_Stores.Notes2 " & _
  " HAVING        (dbo.TB_Header_AznItem_Stores.Compny_Code =  '" & VarCodeCompny & "') AND (dbo.TB_Header_AznItem_Stores.Ser_Order_Stores = '" & Com_InvoiceNo.Text & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            txt_Notes2.Text = Trim(rs("Notes2").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
            'txt_TypeItem.Text = Trim(rs("Type_item").Value)
            txt_NameCustomer.Text = Trim(rs("Name").Value)
            'txt_Tax.Text = Trim(rs("StatusTax").Value)

            If Trim(rs("Status_Order_Stores").Value) = 0 Then OP1.Checked = True
            If Trim(rs("Status_Order_Stores").Value) = 1 Then Op2.Checked = True


            If Trim(rs("Type_Azn").Value) = 0 Then Com_TypeAzn.Text = "أمر توريد"
            If Trim(rs("Type_Azn").Value) = 1 Then Com_TypeAzn.Text = "مرتد"
        End If

    End Sub
    Sub save_oderDetils()

        sql = "select * from BD_Unit where Name = '" & txt_unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value

        ''============================EXitem
        'sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        'Dim Var_TotalItem As Single
        'Var_TotalItem = Math.Round((txt_PriceUnit.Text) * (txt_Qty.Text), 2)


        '==================================نفس رقم السريال فى حالة تكرار رقم صنف التوريد
        sql = "     SELECT Ser_Order_Stores, Seril_No, Code_ItemOrder, Compny_Code      FROM dbo.TB_Detils_AznItem_Stores" & _
        " WHERE(Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            var_serilNO = rs("Seril_No").Value

        Else
            last_Data_serilNo()
        End If

        '==================================================

        'GridView6.Columns(0).Caption = "كود الصنف"
        'GridView6.Columns(1).Caption = "الرقم التوصيفى "
        'GridView6.Columns(2).Caption = "الصنف"
        'GridView6.Columns(3).Caption = "الكمية"
        'GridView6.Columns(4).Caption = "الوحدة"
        'GridView6.Columns(5).Caption = "السعر الحالى"
        'GridView6.Columns(6).Caption = "العملة"
        'GridView6.Columns(7).Caption = "معامل التحويل"
        'GridView6.Columns(8).Caption = "الاجمالى"
        'GridView6.Columns(9).Caption = "ملاحظات"





        'For i = 0 To GridView6.RowCount - 1
        'Dim value1 = GridView6.GetRowCellValue(i, GridView6.Columns(0)) 'كود الصنف
        'Dim value2 = GridView6.GetRowCellValue(i, GridView6.Columns(1)) 'الرقم التوصيفي
        'Dim value3 = GridView6.GetRowCellValue(i, GridView6.Columns(2)) 'الصنف
        'Dim value4 = GridView6.GetRowCellValue(i, GridView6.Columns(3)) 'الكمية
        'Dim value5 = GridView6.GetRowCellValue(i, GridView6.Columns(4)) 'الوحدة
        'Dim value6 = GridView6.GetRowCellValue(i, GridView6.Columns(5)) 'السعر الحالى
        'Dim value7 = GridView6.GetRowCellValue(i, GridView6.Columns(6)) 'العملة
        'Dim value8 = GridView6.GetRowCellValue(i, GridView6.Columns(7)) 'معامل التحويل
        'Dim value9 = GridView6.GetRowCellValue(i, GridView6.Columns(8)) 'الاجمالى
        'Dim value10 = GridView6.GetRowCellValue(i, GridView6.Columns(9)) 'ملاحظات

        sql = "INSERT INTO TB_Detils_AznItem_Stores (Ser_Order_Stores,Order_Stores_NO,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Code_Stores,Item_Discription,Price_Unit,Seril_No,Code_ItemOrder) " & _
         " values  ('" & Com_InvoiceNo2.Text & "','" & Com_InvoiceNo2.Text & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "','" & varcodStores & "','" & txt_NameItem.Text & "','" & txt_price.Text & "','" & var_serilNO & "','" & txt_CodeItem.Text & "' )"
        Cnn.Execute(sql)
        'Next






        '=========================================تعديل رقم اذن الصرف على امر التوريد
        'Dim sql2 As String
        'If varflagItem = 1 Then '===============================فى حالة أمر التوريد
        '    sql2 = "UPDATE  TB_Detils_OrderItem  SET Quntity2='" & txt_Qty.Text & "', No_Azn='" & Com_InvoiceNo2.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Order_NO ='" & txt_NoOredr.Text & "' "
        '    rs = Cnn.Execute(sql2)
        'End If

        'If varflagItem = 3 Then '========================================فى حالة أمر شغل الانتاج
        '    sql2 = "UPDATE  TB_Detils_JOB_Order  SET No_Azn='" & Com_InvoiceNo2.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Matril ='" & txt_CodeItem.Text & "'  and JOB_Order ='" & txt_NoOredr.Text & "' "
        '    rs = Cnn.Execute(sql2)
        'End If

    End Sub
    Sub clear_detils()
        'txt_CodeItem.Text = ""
        'txt_NameItem.Text = ""
        'txt_Qty.Text = ""
        'txt_unit.Text = ""
        txt_Notes.Text = ""
        txt_Notes2.Text = ""
        txt_NameCustomer.Text = ""

        'txt_OrderSal.Text = ""
        'txt_NameNewItem.Text = ""
        'txt_Qyt_avalible.Text = ""
        txt_price.Text = ""

        Com_TypeAzn.Text = "أمر توريد"
        'txt_Count.Text = ""
        'txt_PriceUnit.Text = ""
        'txt_TypeItem.Text = ""
        'txt_totalAzn.Text = ""

        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        'txt_Qyt_rem.Text = "0"

        txt_Qty.Text = ""
        txt_unit.Text = ""
        'Txt_QytStores1.Text = ""
        Txt_QytStores2.Text = ""
        'Txt_UnitQyt1.Text = ""
        'Txt_UnitQyt2.Text = ""
    End Sub




    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)

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
            total += GridView6.GetRowCellValue(i, GridView6.Columns(6))
        Next
        'txt_totalAzn.Text = Math.Round(total, 2)


    End Sub

    'Sub find_detalis()
    '    Dim con As New OleDb.OleDbConnection
    '    Dim ss As String
    '    ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '    con.ConnectionString = ss
    '    con.Open()



    '    sql2 = "select No_Item,Name,rtrim(Item_Discription) as nameitem,Quntity,Unit,Count_item,price_unit,Stores,Code_ItemOrder,NameItem_Order,Seril_No,Quntity_Protactive,TotalPriceItem from Vw_FindAznSarf where Compny_Code = '" & VarCodeCompny & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'  "

    '    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)
    '    GridControl3.DataSource = ds.Tables(0)
    '    GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
    '    GridView6.Appearance.Row.Options.UseFont = True

    '    GridView6.Columns(0).Caption = "كود الصنف"
    '    GridView6.Columns(1).Caption = "الصنف الفعلى"
    '    GridView6.Columns(2).Caption = "اسم الصنف البديل"
    '    GridView6.Columns(3).Caption = "الكمية"
    '    GridView6.Columns(4).Caption = "الوحدة"
    '    GridView6.Columns(5).Caption = "عدد"
    '    GridView6.Columns(6).Caption = "السعر"
    '    GridView6.Columns(7).Caption = "أسم المخزن"

    '    GridView6.Columns(8).Caption = "رقم صنف التوريد"
    '    GridView6.Columns(9).Caption = "صنف التوريد"
    '    GridView6.Columns(10).Caption = "م"
    '    GridView6.Columns(11).Caption = " برتكتيف"
    '    GridView6.Columns(12).Caption = "القيمة"

    '    GridView6.Columns(10).Visible = False
    '    GridView6.Columns(11).Visible = False

    '    GridView6.Columns(7).Visible = False
    '    GridView6.Columns(8).Visible = False
    '    GridView6.Columns(9).Visible = False
    '    GridView6.BestFitColumns()




    '    ds = Nothing
    '    da = Nothing
    '    con.Close()
    '    con.Dispose()

    '    GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

    '    'Mainmune.finwatinoderItem()
    'End Sub
    Sub find_detalis2()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select No_Item,Name,rtrim(Item_Discription) as nameitem,Quntity,Unit,Count_item,price_unit,Stores from Vw_FindAznSarf where Compny_Code = '" & VarCodeCompny & "' and Order_Stores_NO ='" & Com_InvoiceNo.Text & "'  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "اسم الصنف"
        GridView6.Columns(2).Caption = "اسم الصنف البديل"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "عدد"
        GridView6.Columns(6).Caption = "السعر"
        GridView6.Columns(7).Caption = "أسم المخزن"


        GridView6.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'Mainmune.finwatinoderItem()
    End Sub

    Sub find_Fill_Azn()



        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()


        'sql2 = "select * from Vw_All_Order_SarfLast where Compny_Code = '" & VarCodeCompny & "'   and Quntity > 0 "

        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'GridControl2.DataSource = ds.Tables(0)
        'GridView3.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        'GridView3.Appearance.Row.Options.UseFont = True

        'GridView3.Columns(0).AppearanceCell.ForeColor = Color.Red
        'GridView3.Columns(1).AppearanceCell.ForeColor = Color.Red
        'GridView3.Columns(2).AppearanceCell.ForeColor = Color.Red
        'GridView3.Columns(3).AppearanceCell.ForeColor = Color.Red
        'GridView3.Columns(4).AppearanceCell.ForeColor = Color.Red
        'GridView3.Columns(5).AppearanceCell.ForeColor = Color.Red

        'GridView3.Columns(0).Caption = "رقم التوريد"
        'GridView3.Columns(1).Caption = "اسم العميل"
        'GridView3.Columns(2).Caption = "رقم الصنف"
        'GridView3.Columns(3).Caption = "أسم الصنف"
        'GridView3.Columns(4).Caption = "الكمية"
        'GridView3.Columns(5).Caption = "الوحدة"
        'GridView3.Columns(6).Caption = "النوع"

        'GridView3.Columns(7).Visible = False
        ''GridView3.Columns(8).Visible = False

        ''GridView3.Columns(9).Visible = False   ''Flag Update امر الشغل / امر التوريد


        'GridView3.BestFitColumns()




        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()

        'GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub
    Private Sub Frm_AznSarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Stores()
        'last_Data()
        Com_TypeAzn.Items.Add("أمر توريد")
        Com_TypeAzn.Items.Add("مرتد")
        fill_all_data2()
        fill_Unit()
    End Sub

    Sub fill_Unit()
        'txt_unit.Items.Clear()
        'sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    txt_unit.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop
    End Sub
    Sub fill_all_data()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select * from Vw_All_AznEstlamStoresData "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "امر التوريد"
        GridView1.Columns(4).Caption = "كود الصنف"
        GridView1.Columns(5).Caption = "اسم الصنف"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "الكمية"
        GridView1.Columns(8).Caption = "السعر"
        GridView1.Columns(9).Caption = "الاجمالى"
        GridView1.Columns(10).Caption = "المخزن"
        GridView1.Columns(11).Caption = "رقم الفاتورة"
        'GridView3.Columns(11).Caption = "حالة الخروج"

        'GridView1.Columns(11).Visible = False
        'GridView1.Columns(12).Visible = False
        'GridView1.Columns(13).Visible = False
        GridView1.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub

    Sub fill_all_data2()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql = "select * from Vw_All_AznEstlamStoresData_Hedar where Compny_Code = '" & VarCodeCompny & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "أسم العميل"
        GridView1.Columns(3).Caption = "نوع الاذن"


        GridView1.Columns(4).Visible = False
        GridView1.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
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
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Qty.Text) = 0 Then MsgBox("من ادخل  الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Price.Text) = 0 Then MsgBox("من ادخل  السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        fin_qyt_avalible()
    End Sub


    Sub saveGl()
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

    Private Sub Cmd_RtInvoice_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_FindOrder_Click(sender As Object, e As EventArgs) Handles Cmd_FindOrder.Click

        vartable = "Vw_Lookup_AznItem"
        VarOpenlookup = 26
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        'clear_detils()
        find_hedar()
        'find_Order_detalis()
        'find_detalis()
        find_itemOrder()
        find_detalis()
        find_itemOrder()
        'Total_Sum()
        'SimpleButton4.Enabled = True
        'Cmd_OpenItem.Enabled = True
    End Sub

    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select No_Item, Name, Quntity, Unit, Price_Unit, Stores,No_Invoice from Vw_FindAznSarf where Compny_Code = '" & VarCodeCompny & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الصنف"
        GridView6.Columns(2).Caption = "الكمية"
        GridView6.Columns(3).Caption = "الوحدة"
        GridView6.Columns(4).Caption = "السعر"
        GridView6.Columns(5).Caption = "أسم المخزن"
        GridView7.Columns(7).Caption = "رقم الفاتورة"

        'GridView6.Columns(8).Caption = "رقم صنف التوريد"
        'GridView6.Columns(9).Caption = "صنف التوريد"
        'GridView6.Columns(10).Caption = "م"
        'GridView6.Columns(11).Caption = " برتكتيف"


        GridView6.Columns(4).Visible = False
        'GridView6.Columns(6).Visible = False
        ''GridView6.Columns(11).Visible = False
        ''GridView6.Columns(8).Visible = False
        ''GridView6.Columns(9).Visible = False
        ''GridView6.Columns(10).Visible = False
        'GridView6.Columns(2).Visible = False

        'If rs.EOF = False Then Com_Stores.Text = rs("Stores").Value

        GridView6.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'Mainmune.finwatinoderItem()
    End Sub




    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

        'sql2 = "select * from TB_Detils_AznItem_Stores where Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'and Order_NO  = '" & Trim(txt_NoOredr.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        'rs2 = Cnn.Execute(sql2)

        'If rs2.EOF = False Then
        'find_Fill_Azn()
        'Else
        '    MsgBox("من فضلك رقم امر التوريد موجود على اذن استلام  من قبل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        'End If


    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)

    End Sub


    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        If varcodeitem = 0 Then Exit Sub

        If Val(Txt_QytStores2.Text) < Val(txt_Qty.Text) Then MsgBox("الكمية غير متوفره بالمخزن", MsgBoxStyle.Critical, "Css") : Exit Sub
        save_data()
        find_itemOrder()
        find_detalis()
    End Sub



    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        clear_detils()
        txt_OrderSal.Text = ""
        last_Data()
        find_itemOrder()
        find_detalis()
        Com_Stores.Text = ""
        'SimpleButton4.Enabled = True
        'Cmd_OpenItem.Enabled = True
        Cmd_save.Enabled = True
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        'On Error Resume Next
        'sql2 = "select * from TB_Detils_AznItem_Stores where Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'and Order_NO  = '" & Trim(txt_NoOredr.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        'rs2 = Cnn.Execute(sql2)

        'If rs2.EOF = False Then
        '    MsgBox("من فضلك رقم امر التوريد موجود على اذن استلام  من قبل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        'Else

        'If txt_OrderSal.Text <> "" Then
        '    If txt_OrderSal.Text <> txt_NoOredr.Text Then MsgBox("من فضلك لايمكن اضافة الصنف لانة من رقم أمر توريد مختلف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub
        'End If

        'Qyt_rem()

        'If Val(txt_Qty.Text) > Val(txt_Qyt_rem.Text) Then MsgBox("الكمية المنصرفة اكبر من الكمية المتبقية من صنف التوريد", MsgBoxStyle.Critical, "CSS") : Exit Sub

        If Val(Txt_QytStores2.Text) < Val(txt_Qty.Text) Then MsgBox("الكمية غير متوفره بالمخزن", MsgBoxStyle.Critical, "Css") : Exit Sub


        save_data()
        'End If
        'Total_Sum()
        find_hedar()
        'find_Order_detalis()
        'find_detalis()
        find_itemOrder()
        find_detalis()
    End Sub
    Sub save_data()
        sql2 = "select * from TB_Header_AznItem_Stores where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo2.Text) & "' and Order_NO ='" & txt_OrderSal.Text & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If varcodeitem = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Stores.Text) = 0 Then MsgBox("من  فضلك ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Com_TypeAzn.Text = "" Then MsgBox("من فضلك أختار نوع الاذن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        If txt_OrderSal.Text = "" Then MsgBox("من فضلك ادخل رقم امر التوريد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        'fin_qyt_avalible()

        'If Val(txt_Qyt_avalible.Text) < Val(txt_Qty.Text) Then MsgBox("من فضلك الكمية المنصرفة اكبر من الكمية المتاحة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        save_Order_H()
        find_hedar()
        'find_detalis()
        'find_Fill_Azn()
        fill_all_data()
    End Sub

    Private Sub Cmd_DeleteLine_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteLine.Click
        On Error Resume Next

        ''=============================================معرفة الصنف على فاتورة ام لا
        'sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("الصنف موجود على فاتورة لايمكن حذفة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''===============================================
        '=============================================معرفة ااذن على فاتورة ام لا
        sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الصنف الاذن موجود على فاتورة لايمكن حذفة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '===============================================


        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_AznItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)



                '===================================حذف من المخزن
                sql = "Delete Statement_OfItem  WHERE NoItem = '" & varcodeitem & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
                rs = Cnn.Execute(sql)




                '=================================================تعديل رقم الاذن فى امر التوريد
                'Dim sql2 As String
                'sql2 = "UPDATE  TB_Detils_OrderItem  SET No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Order_NO ='" & txt_OrderSal.Text & "' "
                'rs = Cnn.Execute(sql2)

                ''=========================================Flag امر التوريد
                'sql = "SELECT        Compny_Code, No_Azn, Order_NO, No_Item               FROM dbo.TB_Detils_OrderItem " & _
                '" WHERE        (Compny_Code =  '" & VarCodeCompny & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Order_NO = '" & txt_OrderSal.Text & "')"
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then varflagItem = 1
                '================================================Flag أمر الشغل
                'sql = " SELECT        JOB_Order, No_Matril, Compny_Code              FROM dbo.TB_Detils_JOB_Order WHERE        (JOB_Order = '" & txt_OrderSal.Text & "') AND (No_Matril = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then varflagItem = 3



                Dim sql2 As String
                'If varflagItem = 1 Then '===============================فى حالة أمر التوريد
                '    sql2 = "UPDATE  TB_Detils_OrderItem  SET Quntity2='" & txt_Qty.Text & "' and No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Item ='" & txt_CodeItem.Text & "'  and Order_NO ='" & txt_OrderSal.Text & "' "
                '    rs = Cnn.Execute(sql2)
                'End If

                'If varflagItem = 3 Then '========================================فى حالة أمر شغل الانتاج
                '    sql2 = "UPDATE  TB_Detils_JOB_Order  SET No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "  and No_Matril ='" & txt_CodeItem.Text & "'  and JOB_Order ='" & txt_OrderSal.Text & "' "
                '    rs = Cnn.Execute(sql2)
                'End If

                'find_detalis()
                clear_detils()

                find_Fill_Azn()
                fill_all_data()

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','23','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_itemOrder()
                find_detalis()
        End Select
    End Sub

    Private Sub Cmd_DeletFinsh_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_DeletFinsh_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeletFinsh.Click
        On Error Resume Next


        '=============================================معرفة ااذن على فاتورة ام لا
        sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الاذن موجود على فاتورة لايمكن حذفة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '===============================================




        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_AznItem_Stores  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete TB_Header_AznItem_Stores  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '===================================حذف من المخزن
                sql = "Delete Statement_OfItem  WHERE TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
                rs = Cnn.Execute(sql)



                'Dim sql2 As String
                'sql2 = "UPDATE  TB_Detils_OrderItem  SET No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "    and Order_NO ='" & txt_OrderSal.Text & "' "
                'rs = Cnn.Execute(sql2)

                sql2 = "UPDATE  TB_Detils_OrderItem  SET  Quntity2 ='" & 0 & "' , No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "    and Order_NO ='" & txt_OrderSal.Text & "' "
                rs = Cnn.Execute(sql2)

                sql2 = "UPDATE  TB_Detils_JOB_Order  SET No_Azn='" & 0 & "'  WHERE Compny_Code = " & VarCodeCompny & "    and JOB_Order ='" & txt_OrderSal.Text & "' "
                rs = Cnn.Execute(sql2)


                'find_detalis()
                clear_detils()
                find_Fill_Azn()
                find_hedar()
                'find_Order_detalis()
                find_detalis()
                find_itemOrder()
                clear_detils()
                last_Data()
                'find_detalis()
                Cmd_save.Enabled = True

                fill_all_data()

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','23','11','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton3_Click_2(sender As Object, e As EventArgs)
        Frm_OrderData.Close()
        Frm_OrderData.MdiParent = Mainmune
        Frm_OrderData.Show()
    End Sub

   
    Sub find_Order_qty()
        On Error Resume Next
        sql2 = "     SELECT dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Detils_OrderItem.No_Item, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name as unit " & _
            " FROM     dbo.TB_Detils_OrderItem INNER JOIN " & _
            "                  dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
            " WHERE  (dbo.TB_Detils_OrderItem.Order_NO = '" & txt_OrderSal.Text & "' ) AND (dbo.TB_Detils_OrderItem.No_Item = '" & txt_CodeItem.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') "

        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
            txt_Qty.Text = rs2("Quntity").Value : txt_unit.Text = rs2("Unit").Value
        Else
            txt_Qty.Text = "0" : txt_unit.Text = ""

        End If
    End Sub
    Sub Qyt_rem()
        '  On Error Resume Next
        '  sql2 = "      SELECT dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Detils_OrderItem.No_Item, dbo.TB_Detils_OrderItem.Quntity, SUM(dbo.TB_Detils_AznItem_Stores.Quntity) AS Quntity_azn, dbo.BD_Unit.Name AS unit, " & _
        '"                  dbo.TB_Detils_OrderItem.Quntity - SUM(dbo.TB_Detils_AznItem_Stores.Quntity) AS rem_Qyt " & _
        '" FROM     dbo.TB_Detils_OrderItem INNER JOIN " & _
        '"                  dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                  dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_AznItem_Stores.Order_NO AND dbo.TB_Detils_OrderItem.No_Item = dbo.TB_Detils_AznItem_Stores.Code_ItemOrder " & _
        '"        WHERE(dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
        '" GROUP BY dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Detils_OrderItem.No_Item, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name " & _
        '" HAVING (dbo.TB_Detils_OrderItem.Order_NO = '" & txt_OrderSal.Text & "') AND (dbo.TB_Detils_OrderItem.No_Item = '" & txt_CodeItem2.Text & "') "
        '  rs2 = Cnn.Execute(sql2)
        '  If rs2.EOF = False Then
        '      txt_Qyt_rem.Text = rs2("rem_Qyt").Value
        '  Else
        '      txt_Qyt_rem.Text = txt_Qty2.Text

        '  End If
    End Sub


    Private Sub Cmd_OpenItem_Click_1(sender As Object, e As EventArgs)

    End Sub





    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs)
        Frm_SalseInvoice.Close()
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()
    End Sub



    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        On Error Resume Next
        If Com_TypeAzn.Text = "" Then MsgBox("من فضلك أختار نوع الاذن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        '=============================================معرفة ااذن على فاتورة ام لا
        sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن تعديلة الاذن موجود على فاتورة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '===============================================
        If txt_OrderSal.Text = "" Then MsgBox("من فضلك ادخل رقم امر التوريد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Dim varstatus2 As Integer
        If OP1.Checked = True Then varstatus2 = 0
        If Op2.Checked = True Then varstatus2 = 1

        Dim varTypeAzn As Integer

        If Com_TypeAzn.Text = "أمر توريد" Then varTypeAzn = 0
        If Com_TypeAzn.Text = "مرتد" Then varTypeAzn = 1

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================رقم الوحدة 

        'sql = "   SELECT *    FROM BD_unit   WHERE(Name = '" & txt_unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_unit = rs("Code").Value


        '===============================================تعديل Hedare
        sql2 = "UPDATE  TB_Header_AznItem_Stores  SET Order_Date_stores ='" & vardateoder & "', Type_Azn='" & varTypeAzn & "', Status_Order_Stores='" & varstatus2 & "',notes='" & txt_Notes.Text & "',notes2='" & txt_Notes2.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)
        '===================================================تعديل سطر
        'sql = "UPDATE TB_Detils_AznItem_Stores set Quntity_Protactive ='" & txt_QtyProtaktiv.Text & "', Order_NO ='" & txt_OrderSal.Text & "', Code_Unit ='" & varcode_unit & "', Item_Discription ='" & txt_NameNewItem.Text & "', Quntity ='" & txt_Qty.Text & "',Code_Stores ='" & varcodStores & "',Price_Unit='" & txt_price.Text & "',Count_item='" & txt_Count.Text & "'  WHERE Item_Discription ='" & varnameDiscription & "'and  No_Item = '" & txt_CodeItem.Text & "' and Code_ItemOrder ='" & txt_CodeItem2.Text & "' and Seril_No = '" & varserial_Update & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        '===================================تعديل فى حركة المخازن

        'If txt_QtyProtaktiv.Text >= 0 And txt_QtyProtaktiv.Visible = True Then
        '    sql = "update Statement_OfItem set Import ='" & txt_QtyProtaktiv.Text & "' WHERE NoItem = '" & txt_CodeItem.Text & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
        '    rs = Cnn.Execute(sql)
        'Else
        '    sql = "update Statement_OfItem set Import ='" & txt_Qty.Text & "' WHERE NoItem = '" & txt_CodeItem.Text & "' and TypeD ='" & 1 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
        '    rs = Cnn.Execute(sql)


        'End If


        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','23','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================


        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'find_detalis()
        fill_all_data()
        'clear_detils()
        'find_Fill_Azn()
    End Sub


    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Com_InvoiceNo2.Text = "" Then MsgBox("من فضلك أختار رقم الاذن", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        'Report_AznStores.Show()

        If Op2.Checked = True Then var_recived_Stores = 1
        If OP1.Checked = True Then var_recived_Stores = 2
        Rpt_ResivedStores_Print.Close()
        Rpt_ResivedStores_Print.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        find_hedar()
        find_detalis()
        find_itemOrder()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        fill_all_data2()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        fill_all_data()
    End Sub


    Private Sub Cmd_OpenItem_Click(sender As Object, e As EventArgs)
        'If RadioButton4.Checked = True Then

        'End If
        If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub


        'If RadioButton3.Checked = True Then
        vartable = "vw_allItemOrder"
        VarOpenlookup = 11112
        frm_LookupNewOrder.txt_OrderSal.Visible = False
        frm_LookupNewOrder.LabelX7.Visible = False
        frm_LookupNewOrder.Cmd_Print.Visible = False
        frm_LookupNewOrder.MdiParent = Mainmune
        frm_LookupNewOrder.Show()
        'End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        'If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub
        ''==================================رقم التوريد سريال

        'sql = "  SELECT TOP (100) PERCENT Ser_Order_Stores, Compny_Code       FROM dbo.TB_Header_AznItem_Stores WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then

        '    VarSerTwred = 0
        '    sql2 = "      SELECT Order_NO, Order_Ser, Compny_Code        FROM dbo.TB_Header_OrderItem " & _
        '        " WHERE  (Order_NO = '" & txt_OrderSal.Text & "') AND (Compny_Code = '" & VarCodeCompny & "' ) "
        '    rs = Cnn.Execute(sql2)
        '    If rs.EOF = False Then VarSerTwred = rs("Order_Ser").Value : frm_LookupNewOrder.txt_OrderSal.Text = VarSerTwred
        '    '=================================================================
        '    vartable = "vw_All_OrderSalse_New"
        '    VarOpenlookup = 11111
        '    frm_LookupNewOrder.MdiParent = Mainmune
        '    frm_LookupNewOrder.Show()
        '    'frm_LookupNewOrder.ShowDialog()
        '    Qyt_rem()
        'Else

        '    vartable = "vw_All_OrderSalse_New"
        '    VarOpenlookup = 11111
        '    frm_LookupNewOrder.MdiParent = Mainmune
        '    frm_LookupNewOrder.Show()
        '    Qyt_rem()


        'End If

    End Sub

    'Sub fill_item_grid(orderCode)

    '    GridControl3.DataSource = Nothing
    '    GridView6.Columns.Clear()
    '    Dim con As New OleDb.OleDbConnection
    '    Dim ss As String
    '    ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '    con.ConnectionString = ss
    '    con.Open()



    '    sql2 = "SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
    '            "                        dbo.TB_Detils_OrderItem.Price_Unit, dbo.TB_Detils_OrderItem.TotalItem " & _
    '            " FROM            dbo.TB_Detils_OrderItem INNER JOIN  " & _
    '            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
    '            "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN  " & _
    '            "                         dbo.BD_Currency ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.TB_Detils_OrderItem.Rat_Cur = dbo.BD_Currency.Code  " & _
    '            " WHERE        (dbo.TB_Detils_OrderItem.Order_Ser = '" & orderCode & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "')  "


    '    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)
    '    GridControl3.DataSource = ds.Tables(0)


    '    GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
    '    GridView6.Appearance.Row.Options.UseFont = True

    '    GridView6.Columns(0).Caption = "كود الصنف"
    '    GridView6.Columns(2).Caption = "الصنف"
    '    GridView6.Columns(3).Caption = "الكمية"
    '    GridView6.Columns(4).Caption = "الوحدة"
    '    GridView6.Columns(5).Caption = "سعر الوحدة"
    '    GridView6.Columns(6).Caption = "الاجمالى"


    '    GridView6.BestFitColumns()


    '    'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
    '    ds = Nothing
    '    da = Nothing
    '    con.Close()
    '    con.Dispose()
    'End Sub
    Sub find_codeGroup_Item()
        'On Error Resume Next
        ''==============================كود المجموعة
        'sql = "SELECT CodeGroupItemMain, Name, Code, Compny_Code        FROM dbo.BD_Item WHERE  (Code = '" & txt_CodeItem2.Text & "') AND (Compny_Code = 2) "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        '    VarcodeGroupItem = rs("CodeGroupItemMain").Value
        'End If
        'If VarcodeGroupItem = 7 Or VarcodeGroupItem = 11 Or VarcodeGroupItem = 5 Then Lab_Protactive.Visible = True : txt_QtyProtaktiv.Text = txt_Qty.Text : txt_Qty.Text = "" : txt_QtyProtaktiv.Visible = True Else Lab_Protactive.Visible = False : txt_QtyProtaktiv.Visible = False
        ''===================================================================
    End Sub

    Private Sub txt_OrderSal_TextChanged(sender As Object, e As EventArgs)
        'find_CondationOrder()
    End Sub




    Sub find_Gard2()
        'On Error Resume Next
        ''==========================================رقم المخزن
        'sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodStores = rs("Code").Value
        ''============================================================


        'sql2 = "SELECT dbo.Statement_OfItem.NoItem, ROUND(SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import), 2) AS Balance, dbo.BD_Item.Name, dbo.BD_Unit.Name AS Unit " & _
        '" FROM     dbo.Statement_OfItem INNER JOIN " & _
        '"                  dbo.BD_Item ON dbo.Statement_OfItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_Item.Code INNER JOIN " & _
        '"                  dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
        '" WHERE  (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Statement_OfItem.Code_Stores = '" & varcodStores & "') " & _
        '" GROUP BY dbo.Statement_OfItem.NoItem, dbo.BD_Item.Name, dbo.BD_Unit.Name " & _
        '"        HAVING(dbo.Statement_OfItem.NoItem = '" & txt_CodeItem.Text & "') "

        'rs2 = Cnn.Execute(sql2)
        'If rs2.EOF = False Then
        '    Txt_QytStores1.Text = rs2("Balance").Value : Txt_UnitQyt1.Text = rs2("Unit").Value
        'Else
        '    Txt_QytStores1.Text = "0" : Txt_UnitQyt1.Text = ""

        'End If
    End Sub
    Sub find_CondationOrder()
        On Error Resume Next
        sql = " SELECT dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Notes, dbo.TB_CondationOrderTslem.Discrption AS Discrption_tslem, dbo.Tb_CondationOrder.Discrption AS Discrption_Dfa " & _
                " FROM     dbo.TB_Header_OrderItem LEFT OUTER JOIN " & _
                "                  dbo.TB_CondationOrderTslem ON dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_CondationOrderTslem.Compny_Code AND  " & _
                "                  dbo.TB_Header_OrderItem.Order_NO = dbo.TB_CondationOrderTslem.Order_NO LEFT OUTER JOIN " & _
                "                  dbo.Tb_CondationOrder ON dbo.TB_Header_OrderItem.Compny_Code = dbo.Tb_CondationOrder.Compny_Code AND dbo.TB_Header_OrderItem.Order_NO = dbo.Tb_CondationOrder.Order_NO " & _
                " WHERE  (dbo.TB_Header_OrderItem.Order_NO = '" & txt_OrderSal.Text & "') AND (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Notes2.Text = rs("Discrption_Dfa").Value
        Else
            txt_Notes.Text = "" : txt_Notes2.Text = ""

        End If
    End Sub

    Sub find_NotesItem()
        On Error Resume Next
        'sql = " SELECT dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Notes, dbo.TB_CondationOrderTslem.Discrption AS Discrption_tslem, dbo.Tb_CondationOrder.Discrption AS Discrption_Dfa " & _
        '        " FROM     dbo.TB_Header_OrderItem LEFT OUTER JOIN " & _
        '        "                  dbo.TB_CondationOrderTslem ON dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_CondationOrderTslem.Compny_Code AND  " & _
        '        "                  dbo.TB_Header_OrderItem.Order_NO = dbo.TB_CondationOrderTslem.Order_NO LEFT OUTER JOIN " & _
        '        "                  dbo.Tb_CondationOrder ON dbo.TB_Header_OrderItem.Compny_Code = dbo.Tb_CondationOrder.Compny_Code AND dbo.TB_Header_OrderItem.Order_NO = dbo.Tb_CondationOrder.Order_NO " & _
        '        " WHERE  (dbo.TB_Header_OrderItem.Order_NO = '" & txt_OrderSal.Text & "') AND (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') "
        sql = "       SELECT Order_NO, No_Item, Notes        FROM dbo.TB_Detils_OrderItem WHERE  (Order_NO = '" & txt_OrderSal.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') AND (No_Item = '" & txt_CodeItem.Text & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Notes.Text = rs("Notes").Value
        Else
            txt_Notes.Text = ""

        End If
    End Sub

    Private Sub GridControl3_DragEnter(sender As Object, e As DragEventArgs) Handles GridControl3.DragEnter

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
        On Error Resume Next
        If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub

        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '==========================================================================

        Frm_Card_Item.txt_CodeItem2.Text = txt_CodeItem.Text
        Frm_Card_Item.txt_NameItem2.Text = txt_NameItem.Text
        Frm_Card_Item.find_gard()
        Frm_Card_Item.Total_Sum()
        Frm_Card_Item.ShowDialog()
    End Sub

    Private Sub Com_Stores_SelectedIndexChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton3_Click_3(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub SimpleButton3_Click_4(sender As Object, e As EventArgs)
        On Error Resume Next
        If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub

        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '==========================================================================

        'Frm_Card_Item.txt_CodeItem2.Text = txt_CodeItem.Text
        'Frm_Card_Item.txt_NameItem2.Text = txt_NameItem.Text
        Frm_Card_Item.find_gard()
        Frm_Card_Item.Total_Sum()
        Frm_Card_Item.ShowDialog()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub
    Sub find_Order_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
                "                        dbo.TB_Detils_OrderItem.Price_Unit, dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detils_OrderItem.Rat_Cur, dbo.TB_Detils_OrderItem.TotalItem , dbo.TB_Detils_OrderItem.Notes  " & _
                " FROM            dbo.TB_Detils_OrderItem INNER JOIN  " & _
                "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
                "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN  " & _
                "                         dbo.BD_Currency ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.TB_Detils_OrderItem.Rat_Cur = dbo.BD_Currency.Code  " & _
                " WHERE        (dbo.TB_Detils_OrderItem.Order_NO = '" & txt_OrderSal.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "')  "


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
        GridView6.Columns(5).Caption = "السعر الحالى"
        GridView6.Columns(6).Caption = "العملة"
        GridView6.Columns(7).Caption = "معامل التحويل"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "ملاحظات"

        'GridView6.Columns(6).Visible = False
        'GridView6.Columns(7).Visible = False

        GridView6.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Private Sub Cmd_Save2_PriceList_Click(sender As Object, e As EventArgs)
        find_Order_detalis()
    End Sub

    Private Sub Com_TypeAzn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_TypeAzn.SelectedIndexChanged

    End Sub

    Private Sub Cmd_OpenPriceList_Click(sender As Object, e As EventArgs)
        If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub
        '==================================رقم التوريد سريال

        sql = "  SELECT TOP (100) PERCENT Ser_Order_Stores, Compny_Code       FROM dbo.TB_Header_AznItem_Stores WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Ser_Order_Stores = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            VarSerTwred = 0
            sql2 = "      SELECT Order_NO, Order_Ser, Compny_Code        FROM dbo.TB_Header_OrderItem " & _
                " WHERE  (Order_NO = '" & txt_OrderSal.Text & "') AND (Compny_Code = '" & VarCodeCompny & "' ) "
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then VarSerTwred = rs("Order_Ser").Value : frm_LookupNewOrder.txt_OrderSal.Text = VarSerTwred
            '=================================================================
            vartable = "vw_All_OrderSalse_New"
            VarOpenlookup = 11111
            frm_LookupNewOrder.MdiParent = Mainmune
            frm_LookupNewOrder.Show()
            'frm_LookupNewOrder.ShowDialog()
            Qyt_rem()
        Else

            vartable = "vw_All_OrderSalse_New"
            VarOpenlookup = 11111
            frm_LookupNewOrder.MdiParent = Mainmune
            frm_LookupNewOrder.Show()
            Qyt_rem()


        End If

    End Sub

    Private Sub Cmd_OpenPriceList_Click_1(sender As Object, e As EventArgs) Handles Cmd_OpenPriceList.Click

        If Com_Stores.Text = "" Then MsgBox("من فضلك اختار مخزن الصرف", MsgBoxStyle.Critical, "Css") : Exit Sub

        sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن فتح امر توريد جديد الاذن يوجد علية فاتورة بيع", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub





        vartable = "Vw_Lookup_SalseOrder"
        VarOpenlookup = 24024
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_itemOrder()
    End Sub
    Sub find_itemOrder()

        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        'sql2 = "SELECT        dbo.BD_Item.Ex_Item, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_OrderItem.Quntity - dbo.vw_allAznSarf.Q2 AS rem, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_OrderItem.Price_Unit " & _
        '" FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
        '"                         dbo.BD_Item ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_Item.Code INNER JOIN " & _
        '"                         dbo.vw_allAznSarf ON dbo.TB_Detils_OrderItem.No_Item = dbo.vw_allAznSarf.No_Item AND dbo.TB_Detils_OrderItem.Order_NO = dbo.vw_allAznSarf.Order_NO INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code " & _
        '" WHERE        (dbo.TB_Detils_OrderItem.Quntity - iif(  dbo.vw_allAznSarf.Q2 is null ,0,    dbo.vw_allAznSarf.Q2 ) > 0 ) AND (dbo.TB_Detils_OrderItem.Order_NO = '" & txt_OrderSal.Text & "') "


        sql2 = "      SELECT        dbo.BD_Item.Ex_Item, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_OrderItem.Quntity - iif(  dbo.vw_allAznSarf.Q2 is null ,0,    dbo.vw_allAznSarf.Q2 ) AS rem, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_OrderItem.Price_Unit " & _
      " FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
      "                         dbo.BD_Item ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_Item.Code INNER JOIN " & _
      "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code LEFT OUTER JOIN " & _
      "                         dbo.vw_allAznSarf ON dbo.TB_Detils_OrderItem.No_Item = dbo.vw_allAznSarf.No_Item AND dbo.TB_Detils_OrderItem.Order_NO = dbo.vw_allAznSarf.Order_NO " & _
      " WHERE        (dbo.TB_Detils_OrderItem.Quntity - iif(  dbo.vw_allAznSarf.Q2 is null ,0,    iif(  dbo.vw_allAznSarf.Q2 is null ,0,    dbo.vw_allAznSarf.Q2 ) ) > 0 ) AND (dbo.TB_Detils_OrderItem.Order_NO =  '" & txt_OrderSal.Text & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)


        GridView3.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "الرقم التوصيفى"
        GridView3.Columns(1).Caption = "كود الصنف "

        GridView3.Columns(2).Caption = "الصنف"
        GridView3.Columns(3).Caption = "الكمية"
        GridView3.Columns(4).Caption = "الوحدة"
        GridView3.Columns(5).Caption = "سعر الوحدة"
        'GridView3.Columns(8).Caption = "حالة الصنف"

        'GridView3.Columns(2).Visible = False
        'GridView3.Columns(3).Visible = False
        'GridView3.Columns(7).Visible = False

        GridView3.BestFitColumns()

        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        varcodeitem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))

        sql = "    SELECT dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.Code_Stores, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance, dbo.BD_Stores.Name " & _
    " FROM     dbo.Statement_OfItem INNER JOIN " & _
    "                  dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
    " GROUP BY dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.Code_Stores, dbo.BD_Stores.Name " & _
    " HAVING (dbo.BD_Stores.Name ='" & Com_Stores.Text & "') AND (dbo.Statement_OfItem.NoItem = '" & varcodeitem & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Txt_QytStores2.Text = rs("Balance").Value Else Txt_QytStores2.Text = "0"
        '=====================================================


        txt_CodeItem.Text = varcodeitem
        txt_NameItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        txt_unit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        txt_Qty.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        txt_price.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))



    End Sub


    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        If Com_Stores.Text = "" Then MsgBox("من فضلك أختار المخزن", MsgBoxStyle.Critical, "css") : Exit Sub

        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_Stores.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '==========================================================================

        Frm_GardItem2.txt_codeItem.Text = txt_CodeItem.Text
        Frm_GardItem2.txt_NameItem.Text = txt_NameItem.Text
        Frm_GardItem2.FindBalance()
        Frm_GardItem2.Com_Stores.Text = Com_Stores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub GridControl3_Click_1(sender As Object, e As EventArgs) Handles GridControl3.Click
        On Error Resume Next
        varnameDiscription = ""
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Com_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_InvoiceNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        '=============================================
        varnameDiscription = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        '=======================================

        'txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        'txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        'txt_Count.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_price.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))

        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        varserial_Update = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))

        'txt_QtyProtaktiv.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))

        '======================================================================بيانات صنف التوريد
        find_Order_qty()
        find_Gard2()
        Qyt_rem()
        '=============================================
        Cmd_DeletFinsh.Enabled = True
        Cmd_save.Enabled = True
        Cmd_DeleteLine.Enabled = True

        'SimpleButton4.Enabled = True
        'Cmd_OpenItem.Enabled = True
        '============================================




        sql = "    SELECT dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.Code_Stores, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance, dbo.BD_Stores.Name " & _
    " FROM     dbo.Statement_OfItem INNER JOIN " & _
    "                  dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
    " GROUP BY dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.Code_Stores, dbo.BD_Stores.Name " & _
    " HAVING (dbo.BD_Stores.Name ='" & Com_Stores.Text & "') AND (dbo.Statement_OfItem.NoItem = '" & varcodeitem & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Txt_QytStores2.Text = rs("Balance").Value Else Txt_QytStores2.Text = "0"
        '=====================================================

    End Sub

  

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub Com_InvoiceNo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_InvoiceNo2.SelectedIndexChanged
      
    End Sub

    Private Sub cmd_OpenInvoice_Click(sender As Object, e As EventArgs) Handles cmd_OpenInvoice.Click
        If txt_InvoiceNo.Text = "" Then MsgBox("من فضلك اختار رقم الفاتورة", MsgBoxStyle.Critical, "css") : Exit Sub
        If txt_InvoiceNo.Text = "0" Then MsgBox("من فضلك اختار رقم الفاتورة", MsgBoxStyle.Critical, "css") : Exit Sub

        Frm_SalseInvoice.Com_InvoiceNo2.Text = txt_InvoiceNo.Text
        Frm_SalseInvoice.find_hedar()
        Frm_SalseInvoice.find_detalis()
        Frm_SalseInvoice.find_Invoice_Condation()
        Frm_SalseInvoice.Total_Sum()
        Frm_SalseInvoice.sum_tax()
        Frm_SalseInvoice.MdiParent = Mainmune
        Frm_SalseInvoice.Show()
    End Sub

    Private Sub Com_Stores_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles Com_Stores.SelectedIndexChanged

    End Sub

   
End Class