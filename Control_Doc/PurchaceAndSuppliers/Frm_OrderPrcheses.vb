Imports System.Data.OleDb

Public Class Frm_OrderPrcheses
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varcodeExitem As String
    Dim var_noazn, varcodeser As Integer
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String
    Private Sub Frm_OrderPrcheses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com_order_type.Items.Add("خارجى")
        com_order_type.Items.Add("داخلى")
        com_order_type.Items.Add("مناطق حرة")
        Find_all_Order()
        fill_unit()
        fill_Department()

        last_Data()
        Cmd_save.Enabled = True
        clear_detils()
    End Sub
    Sub fill_unit()
 
        On Error Resume Next
        txt_unit.Items.Clear()
        sql = " Select Name       FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Department()

        On Error Resume Next
        Com_Department.Items.Clear()
        sql = " Select Name       FROM dbo.BD_DIRCTORAY WHERE        (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Department.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
        last_Data()
        Cmd_save.Enabled = True
        Cmd_Delete.Enabled = True
        cmd_Print.Enabled = True
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem_Stores2    GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "RPO000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "RPO000" + "1"


        End If
    End Sub


    Sub save_Order_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_OrderItem_Stores2 where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            Dim vartype_pr, varflagpr As Integer
            '=============================نوع طلب الشراء

            If com_order_type.Text = "داخلى" Then vartype_pr = 0
            If com_order_type.Text = "خارجى" Then vartype_pr = 1
            If com_order_type.Text = "مناطق حرة" Then vartype_pr = 2


            '================================================


            If Op1.Checked = True Then varflagpr = 0
            If Op2.Checked = True Then varflagpr = 1


            If OP6.Checked = True Then varaproiv = 0
            If OP5.Checked = True Then varaproiv = 1



            '=======================================الادارة الطالبة
            sql = "   SELECT *   FROM BD_DIRCTORAY    WHERE(Name = '" & Com_Department.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_deprt = rs("code").Value

            '===================================================

            sql = "INSERT INTO TB_Header_OrderItem_Stores2 (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,Type_OrderPrcheses,Flag_Pr,No_PriceList,Code_Deprt) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_NoPriceList.Text & "','" & varaproiv & "','" & vartype_pr & "','" & varflagpr & "','" & txt_NoPriceList.Text & "','" & varcode_deprt & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()



        clear_detils()

        find_detalis()
        Find_all_Order()
    End Sub

    Sub save_oderDetils()
        '===============================تكرار الصنف
        sql = "     SELECT        No_Item, Order_Stores_NO, Compny_Code        FROM dbo.TB_Detils_OrderItem_Stores2 " & _
            " WHERE        (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "' ) AND (No_Item = '" & txt_CodeItem.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف تم تكراره لايمكن اضافتة مرة اخرى", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        '===============================================================



        sql = "   SELECT *   FROM BD_unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        sql = "INSERT INTO TB_Detils_OrderItem_Stores2 (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_NoPriceList.Text & "','0')"
        Cnn.Execute(sql)

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        Com_Department.Text = ""
        'com_order_type.Text = ""
        txt_NoPriceList.Text = ""
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub

    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Detils_OrderItem_Stores2.No_Item, dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name, dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
                " FROM            dbo.TB_Detils_OrderItem_Stores2 INNER JOIN  " & _
                "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
                "                         dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_Item.Code  AND   " & _
                "        dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Item.Compny_Code  " & _
                " WHERE        (dbo.TB_Detils_OrderItem_Stores2.Compny_Code =  '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.BestFitColumns()


        GridView3.Columns(0).Caption = "كود الصنف"
        GridView3.Columns(1).Caption = "الصنف"
        GridView3.Columns(2).Caption = "الكمية"
        GridView3.Columns(3).Caption = "الوحدة"
        GridView3.Columns(4).Caption = "رقم العرض"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Sub find_hedar()
        sql = "SELECT        dbo.TB_Header_OrderItem_Stores2.No_PriceList, dbo.TB_Header_OrderItem_Stores2.Type_OrderPrcheses, dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores, " & _
        "        dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores2.Order_NO, dbo.TB_Header_OrderItem_Stores2.Compny_Code, dbo.TB_Header_OrderItem_Stores2.Order_Date_stores, " & _
        "        dbo.TB_Header_OrderItem_Stores2.Notes, dbo.BD_DIRCTORAY.Name " & _
        " FROM            dbo.TB_Header_OrderItem_Stores2 INNER JOIN " & _
        "                         dbo.BD_DIRCTORAY ON dbo.TB_Header_OrderItem_Stores2.Code_Deprt = dbo.BD_DIRCTORAY.Code AND dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code " & _
        " WHERE        (dbo.TB_Header_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "



        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_NoPriceList.Text = Trim(rs("No_PriceList").Value)
            Com_Department.Text = Trim(rs("Name").Value)
            If Trim(rs("Type_OrderPrcheses").Value) = 1 Then OP6.Checked = True
            If Trim(rs("Type_OrderPrcheses").Value) = 0 Then OP5.Checked = True

        End If

    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        Cmd_save.Enabled = True
        'Cmd_Delete.Enabled = False
        'cmd_Print.Enabled = False
        'Cmd_Edit.Enabled = False
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_OrderItem_Stores2 where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الطلب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_order_type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الطلب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_unit.Text) = 0 Then MsgBox("من  فضلك ادخل الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Department.Text) = 0 Then MsgBox("من  فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()
    End Sub



    

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem_Stores2  WHERE No_Item = '" & txt_CodeItem.Text & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                Find_all_Order()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select


    End Sub


    Private Sub Cmd_Edit_Click(sender As Object, e As EventArgs)
       
    End Sub



    Sub Find_all_Order()
        On Error Resume Next

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        If OPFind2.Checked = True Then

            sql = "SELECT        dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores2.Order_Date_stores, dbo.TB_Detils_OrderItem_Stores2.No_Item, dbo.BD_Item.Name,  " & _
            "                         dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name AS unit, dbo.Tb_TypePO.Name AS Type, iif(dbo.TB_Header_OrderItem_Stores2.Status_Order_Stores=0,'غير موافق','موافق') as stutas ,dbo.TB_Header_OrderItem_Stores2.No_PriceList " & _
            " FROM            dbo.TB_Header_OrderItem_Stores2 INNER JOIN  " & _
            "                         dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores2.Ser_Order_Stores AND   " & _
            "                         dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO = dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO INNER JOIN  " & _
            "                         dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_Item.Code INNER JOIN  " & _
            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
            "                         dbo.Tb_TypePO ON dbo.TB_Header_OrderItem_Stores2.Type_OrderPrcheses = dbo.Tb_TypePO.Code  AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.Tb_TypePO.Compny_Code  " & _
            "        WHERE(dbo.TB_Header_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') "
        End If

        If OPFind1.Checked = True Then


            sql = "       SELECT        dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores2.Order_Date_stores, iif(dbo.TB_Header_OrderItem_Stores2.Status_Order_Stores=0,'غير موافق','موافق') as stutas, dbo.Tb_TypePO.Name AS Type, dbo.BD_DIRCTORAY.Name, " & _
       "                         dbo.TB_Header_OrderItem_Stores2.No_PriceList, dbo.TB_Header_OrderItem_Stores2.Status_Order_Stores " & _
       " FROM            dbo.TB_Header_OrderItem_Stores2 INNER JOIN " & _
       "                         dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores2.Ser_Order_Stores AND  " & _
       "                         dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO = dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO and  dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.TB_Detils_OrderItem_Stores2.Compny_Code INNER JOIN  " & _
       "                         dbo.Tb_TypePO ON dbo.TB_Header_OrderItem_Stores2.Type_OrderPrcheses = dbo.Tb_TypePO.Code INNER JOIN " & _
       "                         dbo.BD_DIRCTORAY ON dbo.TB_Header_OrderItem_Stores2.Code_Deprt = dbo.BD_DIRCTORAY.Code AND dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code " & _
       " WHERE        (dbo.TB_Header_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') " & _
       " GROUP BY dbo.TB_Header_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores2.Order_Date_stores, dbo.Tb_TypePO.Name, dbo.BD_DIRCTORAY.Name, " & _
       "                  dbo.TB_Header_OrderItem_Stores2.No_PriceList, dbo.TB_Header_OrderItem_Stores2.Status_Order_Stores"

        End If

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.BestFitColumns()
        'GridColumn1.Caption = "d"
        If OPFind2.Checked = True Then
            GridView1.Columns(0).Caption = "رقم الطلب"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "رقم الصنف"
            GridView1.Columns(3).Caption = "أسم الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "نوع الطلب"
            GridView1.Columns(7).Caption = "الحالة"
            GridView1.Columns(8).Caption = "رقم العرض"
        End If

        If OPFind1.Checked = True Then
            GridView1.Columns(0).Caption = "رقم الطلب"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "الحالة"
            GridView1.Columns(3).Caption = "نوع الطلب"
            GridView1.Columns(4).Caption = "الادارة الطالبة"
            GridView1.Columns(5).Caption = "رقم عرض السعر"

            GridView1.Columns(6).Visible = False
        End If


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub

    Private Sub GridControl6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs)
    
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        com_order_type.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        txt_NoPriceList.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        com_order_type.Text = "داخلى"
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        txt_CodeItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        txt_NameItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_Qty.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        txt_unit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        txt_NoPriceList.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        com_order_type.Text = "داخلى"
        Cmd_save.Enabled = False
        Cmd_Delete.Enabled = True
        cmd_Print.Enabled = True
        Cmd_Edit.Enabled = True
    End Sub

   

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Cmd_OrderItem_Click_1(sender As Object, e As EventArgs) Handles Cmd_OrderItem.Click
        If Op1.Checked = True Then

            varcode_form = 2560
            VARTBNAME = " Vw_AllDataItem"
            Lookupitem.Fill_Alldata()
            Lookupitem.ShowDialog()
        End If




        If Op2.Checked = True Then

            LookupPriceList.Find_LookupPriceList()

            LookupPriceList.ShowDialog()
        End If



        fill_unit()
    End Sub

    Private Sub Cmd_Edit_Click_1(sender As Object, e As EventArgs) Handles Cmd_Edit.Click

        On Error Resume Next

        'If txt_CodeItem.Text = "" Then MsgBox("من فضلك اختار الصنف", MsgBoxStyle.Critical, "Css") : Exit Sub
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الطلب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_order_type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الطلب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_unit.Text) = 0 Then MsgBox("من  فضلك ادخل الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Department.Text) = 0 Then MsgBox("من  فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        sql = "   SELECT *   FROM BD_unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value

        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)

        '=========================================
        If OP6.Checked = True Then varaproiv = 0
        If OP5.Checked = True Then varaproiv = 1
        '============================================

        '=======================================الادارة الطالبة
        sql = "   SELECT *   FROM BD_DIRCTORAY    WHERE(Name = '" & Com_Department.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_deprt = rs("code").Value
        '======================================



        sql = "UPDATE  TB_Header_OrderItem_Stores2  SET Code_Deprt ='" & varcode_deprt & "', Status_Order_Stores ='" & varaproiv & "'  WHERE  Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '=====================================

        sql = "UPDATE  TB_Detils_OrderItem_Stores2  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "'  WHERE No_Item = '" & txt_CodeItem.Text & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        clear_detils()
        find_detalis()
        Find_all_Order()
    End Sub

    Private Sub cmd_Print_Click_1(sender As Object, e As EventArgs) Handles cmd_Print.Click
        varopenRptprsheses = 0
        Frm_Report_Pr.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف نهائى", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem_Stores2  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete TB_Header_OrderItem_Stores2  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                find_detalis()
                Find_all_Order()
                clear_detils()

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
        End Select
    End Sub

    Private Sub OPFind1_CheckedChanged(sender As Object, e As EventArgs) Handles OPFind1.CheckedChanged

    End Sub

    Private Sub OPFind1_Click(sender As Object, e As EventArgs) Handles OPFind1.Click
        Find_all_Order()
    End Sub

    Private Sub OPFind2_CheckedChanged(sender As Object, e As EventArgs) Handles OPFind2.CheckedChanged
        Find_all_Order()
    End Sub

    Private Sub Com_InvoiceNo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Com_InvoiceNo2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            var_noazn = Com_InvoiceNo2.Text
            Com_InvoiceNo2.Text = "RPO000" & var_noazn
            find_hedar()
            find_detalis()

        End If
    End Sub

    Private Sub Com_InvoiceNo2_TextChanged(sender As Object, e As EventArgs) Handles Com_InvoiceNo2.TextChanged
     
    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        sql = "  SELECT        Min(Ser_Order_Stores) AS Min   FROM dbo.TB_Header_OrderItem_Stores2 GROUP BY Compny_Code  HAVING(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = "RPO000" & rs("Min").Value
            find_hedar()
            find_detalis()
        End If
    End Sub

    Private Sub SimpleButton22_Click(sender As Object, e As EventArgs) Handles SimpleButton22.Click
        sql = "  SELECT        MAX(Ser_Order_Stores) AS MAX   FROM dbo.TB_Header_OrderItem_Stores2 GROUP BY Compny_Code  HAVING(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = "RPO000" & rs("MAX").Value
            find_hedar()
            find_detalis()
        End If
    End Sub

    Private Sub SimpleButton21_Click(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        On Error Resume Next
        clear_detils()
        varcodeser = Mid(Com_InvoiceNo2.Text, 6, 10)

        Com_InvoiceNo2.Text = "RPO000" & varcodeser - 1
        find_hedar()
        find_detalis()
    End Sub

    Private Sub SimpleButton20_Click(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        clear_detils()
        varcodeser = Mid(Com_InvoiceNo2.Text, 6, 10)
        Com_InvoiceNo2.Text = "RPO000" & varcodeser + 1
        find_hedar()
        find_detalis()
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Frm_PrintProcurementVoucher.Show()
    End Sub
End Class