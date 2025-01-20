Imports System.Data.OleDb

Public Class Frm_PrshessesOrder
    Dim varcodeitem, varcode_Cru As Integer
    Dim varcodunit, varcodStores As Integer
    Dim varcodeExitem, varcodeCostCenter1, varcodeCostCenter2 As String

    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

  

    Private Sub Frm_PrshessesOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com_orderPruType.Items.Add("خارجى")
        com_orderPruType.Items.Add("داخلى")
        com_orderPruType.Items.Add("مناطق حرة")
        fill_cru()
    End Sub
    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency where (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub
 

   
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""

    End Sub


    Sub last_Data()

        sql = "  SELECT        MAX(Ser_PO) AS MaxMaim,Compny_Code FROM            TB_Header_PO    GROUP BY Compny_Code  HAVING        (MAX(Ser_PO) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "PO000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "PO000" + "1"


        End If



    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub
        If Len(com_Cru.Text) = 0 Then MsgBox("من  فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub
        If Len(txt_price.Text) = 0 Then MsgBox("من  فضلك ادخل السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub
        If Len(txt_Date_DeliverDate.Value) = 0 Then MsgBox("من  فضلك ادخل تاريخ التوريد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module Software Module") : Exit Sub


        sql2 = "select * from TB_Header_PO where Ser_PO  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If





        save_Invoice_H()
    End Sub

    Sub save_Invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim VarDate_PO As String
        VarDate_PO = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_PO where Ser_PO  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_PO (Ser_PO, Compny_Code,Ext_PONo,PO_Date,Suppliser_No,PO_Type,PO_Status,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & VarDate_PO & "','" & txt_AccountNo.Text & "','" & 0 & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        'save_oderDetils()
        save_InvoiceDetils()
        'save_itemStores()
        clear_detils()
        'find_hedar()
        'find_detalis()

    End Sub

    Sub save_InvoiceDetils()
        sql = "   SELECT Unit1, Ex_Item    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and  Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================

        '===================================================تاريخ وصول الصنف
        Dim dd As DateTime = txt_date.Value
        Dim VarDeliverDate_PO As String
        VarDeliverDate_PO = dd.ToString("MM-d-yyyy")
        '======================================================نوع امر الشراء للنف الواحد

        If com_orderPruType.Text = "خارجى" Then vartypeItem = 1
        If com_orderPruType.Text = "داخلى" Then vartypeItem = 2
        If com_orderPruType.Text = "مناطق حرة" Then vartypeItem = 3
        '==================================================
        sql = "INSERT INTO TB_Detalis_PO (Order_Stores_No2,Ser_PO,Ext_PONo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Price_Item,PO_Type,PO_Deliver_Date,Rat,Code_Cur,Total_Item) " & _
              " values  ('" & Txt_Order_Stores_No.Text & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & txt_price.Text & "','" & vartypeItem & "','" & VarDeliverDate_PO & "','" & txt_rat.Text & "','" & varcode_Cru & "','" & txt_totalAll.Text & "')"
        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VarOpenlookup2 = 25
        Frm_LookUpSuppliser.Find_Suppliser()
        Frm_LookUpSuppliser.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Frm_LookupOrderItemPr.ShowDialog()
        'Lookup_OrderItem_Prshesses()
    End Sub

    Private Sub com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Cru.SelectedIndexChanged
        On Error Resume Next
        sql = "   SELECT        dbo.BD_Currency.Name, dbo.Setup_Currency.Rat FROM            dbo.BD_Currency INNER JOIN           dbo.Setup_Currency ON dbo.BD_Currency.Code = dbo.Setup_Currency.Code_Currency " & _
" WHERE        (dbo.BD_Currency.Name = '" & com_Cru.Text & "') and (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat").Value


        txt_totalAll.Text = Math.Round(Val(txt_price.Text) * Val(txt_rat.Text), 2)
    End Sub

    Private Sub txt_rat_TextChanged(sender As Object, e As EventArgs) Handles txt_rat.TextChanged
        txt_totalAll.Text = Math.Round(Val(txt_rat.Text) * Val(txt_price.Text) * Val(txt_Qty.Text), 2)
    End Sub

    Private Sub txt_price_TextChanged(sender As Object, e As EventArgs) Handles txt_price.TextChanged
        txt_totalAll.Text = Math.Round(Val(txt_rat.Text) * Val(txt_price.Text) * Val(txt_Qty.Text), 2)
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        vartable = "Vw_Lookup_PO"
        VarOpenlookup = 34
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
    End Sub


    Sub find_hedar()
        sql = "   SELECT        dbo.TB_Header_PO.Ser_PO, dbo.TB_Header_PO.Ext_PONo, dbo.TB_Header_PO.PO_Date, dbo.TB_Header_PO.Suppliser_No, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Header_PO.Notes " & _
               " FROM            dbo.TB_Header_PO INNER JOIN " & _
               "                         dbo.St_SuppliserData ON dbo.TB_Header_PO.Compny_Code = dbo.St_SuppliserData.Compny_Code AND dbo.TB_Header_PO.Suppliser_No = dbo.St_SuppliserData.Supliser_AccountNo " & _
               " WHERE        (dbo.TB_Header_PO.Ext_PONo = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_PO.Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_PO").Value)
            Com_InvoiceNo2.Text = Trim(rs("Ext_PONo").Value)
            txt_date.Text = Trim(rs("PO_Date").Value)
            txt_AccountNo.Text = Trim(rs("Suppliser_No").Value)
            txt_nameaccount.Text = Trim(rs("Supliser_Name").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
        End If



    End Sub

    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        'sql2 = "SELECT        dbo.TB_Detalis_PO.No_Item, RTRIM(dbo.TB_Detalis_PO.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detalis_PO.Quntity, dbo.BD_Unit.Name, dbo.TB_Detalis_PO.Price_Item, dbo.TB_Detalis_PO.Rat,  " & _
        '"                         dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detalis_PO.Total_Item, dbo.Tb_TypePO.Name AS Type_PO, dbo.TB_Detalis_PO.Order_Stores_No2 " & _
        '"FROM            dbo.TB_Header_PO INNER JOIN " & _
        '"                         dbo.TB_Detalis_PO ON dbo.TB_Header_PO.Ser_PO = dbo.TB_Detalis_PO.Ser_PO AND dbo.TB_Header_PO.Compny_Code = dbo.TB_Detalis_PO.Compny_Code INNER JOIN " & _
        '"                         dbo.St_SuppliserData ON dbo.TB_Header_PO.Compny_Code = dbo.St_SuppliserData.Compny_Code AND dbo.TB_Header_PO.Suppliser_No = dbo.St_SuppliserData.Supliser_AccountNo INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detalis_PO.Code_Unit = dbo.BD_Unit.Code INNER JOIN " & _
        '"                         dbo.BD_Currency ON dbo.TB_Detalis_PO.Code_Cur = dbo.BD_Currency.Code INNER JOIN " & _
        '"                         dbo.Tb_TypePO ON dbo.TB_Detalis_PO.PO_Type = dbo.Tb_TypePO.Code INNER JOIN " & _
        '"                         dbo.BD_ITEM ON dbo.TB_Detalis_PO.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detalis_PO.Ex_Item = dbo.BD_ITEM.Ex_Item " & _
        '" WHERE        (dbo.TB_Header_PO.Ext_PONo = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_PO.Compny_Code = '" & VarCodeCompny & "') "

        sql2 = "SELECT        dbo.TB_Detalis_PO.No_Item, RTRIM(dbo.TB_Detalis_PO.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detalis_PO.Quntity, dbo.BD_Unit.Name, dbo.TB_Detalis_PO.Price_Item,  " & _
        "                         dbo.TB_Detalis_PO.Rat, dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detalis_PO.Total_Item, dbo.Tb_TypePO.Name AS Type_PO, dbo.TB_Detalis_PO.Order_Stores_No2 " & _
        " FROM            dbo.TB_Header_PO INNER JOIN " & _
        "                         dbo.TB_Detalis_PO ON dbo.TB_Header_PO.Ser_PO = dbo.TB_Detalis_PO.Ser_PO AND dbo.TB_Header_PO.Compny_Code = dbo.TB_Detalis_PO.Compny_Code INNER JOIN " & _
        "                         dbo.St_SuppliserData ON dbo.TB_Header_PO.Compny_Code = dbo.St_SuppliserData.Compny_Code AND dbo.TB_Header_PO.Suppliser_No = dbo.St_SuppliserData.Supliser_AccountNo INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Detalis_PO.Compny_Code = dbo.BD_Unit.Compny_Code AND dbo.TB_Detalis_PO.Code_Unit = dbo.BD_Unit.Code INNER JOIN " & _
        "                         dbo.BD_Currency ON dbo.TB_Detalis_PO.Code_Cur = dbo.BD_Currency.Code AND dbo.TB_Detalis_PO.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
        "                         dbo.Tb_TypePO ON dbo.TB_Detalis_PO.PO_Type = dbo.Tb_TypePO.Code INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.TB_Detalis_PO.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detalis_PO.No_Item = dbo.BD_ITEM.Code " & _
        " WHERE        (dbo.TB_Header_PO.Ext_PONo = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_PO.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "200"
        GridView6.Columns(3).Width = "50"
        GridView6.Columns(4).Width = "50"
        GridView6.Columns(5).Width = "100"
        GridView6.Columns(6).Width = "100"
        GridView6.Columns(7).Width = "100"
        GridView6.Columns(8).Width = "100"
        GridView6.Columns(9).Width = "100"
        GridView6.Columns(10).Width = "100"



        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True


        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "سعر الوحدة"
        GridView6.Columns(6).Caption = "معامل التحويل"
        GridView6.Columns(7).Caption = "العملة"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "نوع امر الشراء"
        GridView6.Columns(10).Caption = "رقم طلب الشراء"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click

    End Sub
End Class