Imports System.Data.OleDb

Public Class Frm_PrchesesPO
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varcodeExitem As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String
    Private Sub Frm_OrderPrcheses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com_order_type.Items.Add("خارجى")
        com_order_type.Items.Add("داخلى")
        com_order_type.Items.Add("مناطق حرة")
        Find_all_Order()
        fill_cru()
        fill_unit()
    End Sub
    Sub Total_Sum()
        'find_tax()
        Dim total As Single
        For i As Integer = 0 To GridView3.RowCount - 1
            total += GridView3.GetRowCellValue(i, GridView3.Columns(11))

        Next
        txt_totalPrice.Text = Math.Round(total, 2)
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
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
        last_Data()
        Cmd_save.Enabled = True
        Cmd_Delete.Enabled = True
        cmd_Print.Enabled = True
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_PO2    GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "PO000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "PO000" + "1"


        End If
    End Sub


    Sub save_Order_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_PO2 where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            Dim vartype_pr As Integer
            '=============================نوع طلب الشراء

            If com_order_type.Text = "داخلى" Then vartype_pr = 0
            If com_order_type.Text = "خارجى" Then vartype_pr = 1
            If com_order_type.Text = "مناطق حرة" Then vartype_pr = 2


            '================================================


            If Op4.Checked = True Then varcodationTaslem = 0
            If Op3.Checked = True Then varcodationTaslem = 1

            If OP5.Checked = True Then varcodationprice = 0
            If OP6.Checked = True Then varcodationprice = 1

            Dim dd2 As DateTime = txt_date2.Value
            Dim vardateoder2 As String
            vardateoder2 = dd2.ToString("MM-d-yyyy")



            sql = "INSERT INTO TB_Header_PO2 (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,Type_OrderPrcheses,PO_Deliver_Date,Code_Supliser,Order_Prcheses,CountDay_T,Condation_Taslem,Condation_Pric,Paid_Type,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderSal.Text & "','" & 0 & "','" & vartype_pr & "','" & vardateoder2 & "','" & txt_AccountNo.Text & "','" & txt_OrderSal.Text & "','" & txt_day.Text & "','" & varcodationTaslem & "','" & varcodationprice & "','" & txt_PaidType.Text & "','" & txt_Notes.Text & "')"
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
        'sql = "     SELECT        No_Item, Order_Stores_NO, Compny_Code        FROM dbo.TB_Detils_PO2 " & _
        '    " WHERE        (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "' ) AND (No_Item = '" & txt_CodeItem.Text & "') "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("الصنف تم تكراره لايمكن اضافتة مرة اخرى", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        '===============================================================



        sql = "   SELECT *    FROM BD_Unit   WHERE(name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '===================================================================

        sql = "INSERT INTO TB_Detils_PO2 (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item,Rat,Code_Cur,Total_Item,Price_Item,Quntity2) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "','0','" & txt_rat.Text & "','" & varcode_Cru & "' , '" & txt_total.Text & "','" & txt_PriceUnit.Text & "','" & txt_Qty.Text & "')"
        Cnn.Execute(sql)

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_day.Text = ""
        txt_PaidType.Text = ""
        'com_order_type.Text = ""
        txt_OrderSal.Text = ""
        txt_Notes.Text = ""
        txt_unit.Text = ""
        txt_PriceUnit.Text = ""
        com_Cru.Text = ""
        txt_rat.Text = ""
        txt_unit.Text = ""
        txt_total.Text = ""
    End Sub

    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Header_PO2.Order_Stores_NO, dbo.TB_Header_PO2.Order_Date_stores, dbo.TB_Detils_PO2.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_PO2.Quntity, dbo.BD_Unit.Name AS unit, " & _
"                         dbo.Tb_TypePO.Name AS Type, dbo.TB_Header_PO2.Order_NO, dbo.TB_Detils_PO2.Price_Item, dbo.BD_Currency.Name AS Cur, dbo.TB_Detils_PO2.Rat, dbo.TB_Detils_PO2.Total_Item " & _
" FROM            dbo.TB_Header_PO2 INNER JOIN " & _
"                         dbo.TB_Detils_PO2 ON dbo.TB_Header_PO2.Ser_Order_Stores = dbo.TB_Detils_PO2.Ser_Order_Stores AND dbo.TB_Header_PO2.Order_Stores_NO = dbo.TB_Detils_PO2.Order_Stores_NO and    dbo.TB_Header_PO2.Compny_Code = dbo.TB_Detils_PO2.Compny_Code INNER JOIN " & _
"                         dbo.BD_Item ON dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_PO2.No_Item = dbo.BD_Item.Code INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_PO2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
"                         dbo.Tb_TypePO ON dbo.TB_Header_PO2.Type_OrderPrcheses = dbo.Tb_TypePO.Code LEFT OUTER JOIN " & _
"                         dbo.BD_Currency ON dbo.TB_Detils_PO2.Code_Cur = dbo.BD_Currency.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Currency.Compny_Code " & _
" WHERE        (dbo.TB_Header_PO2.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_PO2.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.BestFitColumns()


        GridView3.Columns(0).Caption = "رقم الطلب"
        GridView3.Columns(1).Caption = "التاريخ"
        GridView3.Columns(2).Caption = "رقم الصنف"
        GridView3.Columns(3).Caption = "أسم الصنف"
        GridView3.Columns(4).Caption = "الكمية"
        GridView3.Columns(5).Caption = "الوحدة"
        GridView3.Columns(6).Caption = "نوع الطلب"
        GridView3.Columns(7).Caption = "رقم طلب الشراء"
        GridView3.Columns(8).Caption = "سعر الوحدة"
        GridView3.Columns(9).Caption = "العملة"
        GridView3.Columns(10).Caption = "معامل التحويل"
        GridView3.Columns(11).Caption = "الاجمالى"



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Sub find_hedar()
        sql = "     SELECT        * " & _
     " FROM            dbo.TB_Header_PO2 " & _
     " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO ='" & Com_InvoiceNo2.Text & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
            txt_date2.Text = Trim(rs("PO_Deliver_Date").Value)
            txt_AccountNo.Text = Trim(rs("Code_Supliser").Value)

            txt_day.Text = Trim(rs("CountDay_T").Value)
            txt_PaidType.Text = Trim(rs("Paid_Type").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)

            If Trim(rs("Condation_Taslem").Value) = 0 Then Op4.Checked = True
            If Trim(rs("Condation_Taslem").Value) = 1 Then Op3.Checked = True

            If Trim(rs("Condation_Pric").Value) = 0 Then OP5.Checked = True
            If Trim(rs("Condation_Pric").Value) = 1 Then OP6.Checked = True


        End If

    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        Cmd_save.Enabled = True
        Cmd_Delete.Enabled = False
        cmd_Print.Enabled = False
        Cmd_Edit.Enabled = False
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_PO2 where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم أمر الشراء ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_order_type.Text) = 0 Then MsgBox("من فضلك ادخل نوع أمر الشراء ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_unit.Text) = 0 Then MsgBox("من  فضلك ادخل الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_PriceUnit.Text) = 0 Then MsgBox("من  فضلك سعر الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_OrderSal.Text) = 0 Then MsgBox("من  فضلك أختار طلب الشراء ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من  فضلك أختار حساب المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()
    End Sub



    Private Sub Cmd_OrderItem_Click(sender As Object, e As EventArgs)


      
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_PO2  WHERE No_Item = '" & txt_CodeItem.Text & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                Find_all_Order()
                clear_detils()
                MsgBox("تم الحذف السطر", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select


    End Sub


    Private Sub Cmd_Edit_Click(sender As Object, e As EventArgs)
      
    End Sub



    Sub Find_all_Order()
        On Error Resume Next


        sql = "select * from vw_all_po where vw_all_po.Compny_Code = '" & VarCodeCompny & "' "

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


        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم امر الشراء"
        GridView1.Columns(1).Caption = "التاريخ"
        GridView1.Columns(2).Caption = "أسم المورد"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "نوع الطلب"
        GridView1.Columns(8).Caption = "رقم طلب الشراء"
        GridView1.Columns(9).Caption = "سعر الوحدة"
        GridView1.Columns(10).Caption = "العملة"
        GridView1.Columns(11).Caption = "معامل التحويل"
        GridView1.Columns(12).Caption = "الاجمالى"
        GridView1.Columns(13).Caption = "تاريخ التوريد"

        GridView1.Columns(14).Caption = "الايميل"
        GridView1.Columns(15).Caption = "ميعاد التسليم"
        GridView1.Columns(16).Caption = "طريقة الدفع"
        GridView1.Columns(17).Caption = "الضريبة"
        GridView1.Columns(18).Caption = "الحالة"

        GridView1.Columns(14).Visible = False
        GridView1.Columns(15).Visible = False
        GridView1.Columns(16).Visible = False
        GridView1.Columns(17).Visible = False

        GridView1.Columns(19).Visible = False
        GridView1.Columns(20).Visible = False
        GridView1.Columns(21).Visible = False
        GridView1.Columns(22).Visible = False


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


    End Sub

    Private Sub GridControl1_DockChanged(sender As Object, e As EventArgs) Handles GridControl1.DockChanged

    End Sub

    

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        clear_detils()
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        com_order_type.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        txt_nameaccount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))

        find_hedar()
        find_detalis()
        Total_Sum()

        TabPane1.SelectedPageIndex = 0
    End Sub

  
    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        txt_CodeItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        txt_NameItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        txt_Qty.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        txt_unit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        txt_PriceUnit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))
        com_Cru.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))
        txt_rat.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))
        txt_unit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        txt_total.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(11))



        GridView3.Columns(0).Caption = "رقم الطلب"
        GridView3.Columns(1).Caption = "التاريخ"
        GridView3.Columns(2).Caption = "رقم الصنف"
        GridView3.Columns(3).Caption = "أسم الصنف"
        GridView3.Columns(4).Caption = "الكمية"
        GridView3.Columns(5).Caption = "الوحدة"
        GridView3.Columns(6).Caption = "نوع الطلب"
        GridView3.Columns(7).Caption = "رقم طلب الشراء"
        GridView3.Columns(8).Caption = "سعر الوحدة"
        GridView3.Columns(9).Caption = "العملة"
        GridView3.Columns(10).Caption = "معامل التحويل"
        GridView3.Columns(11).Caption = "الاجمالى"




        find_hedar()
        find_detalis()
        Total_Sum()
        Cmd_save.Enabled = False
        Cmd_Delete.Enabled = True
        cmd_Print.Enabled = True
        Cmd_Edit.Enabled = True
    End Sub

    

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VarOpenlookup2 = 2525
        varcode_form = 2525
        Frm_LookUpSuppliser.Find_Suppliser()
        Frm_LookUpSuppliser.ShowDialog()
    End Sub

    Private Sub Cmd_OrderItem_Click_1(sender As Object, e As EventArgs)
        VarOpenlookup2 = 230
        Frm_LookUp_OrderPrcheses.ShowDialog()
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


    Sub calcalator_invoice()
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single
        varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_PriceUnit.Text) * Val(txt_rat.Text), 2)
        'varDiscount = varTotalInvoice * Val(Txt_Discount) / 100

        txt_total.Text = varTotalInvoice
    End Sub

  

    Private Sub txt_PriceUnit_TextChanged(sender As Object, e As EventArgs) Handles txt_PriceUnit.TextChanged
        On Error Resume Next
        Dim varTotalInvoice, varDiscount As Single
        varTotalInvoice = Math.Round(Val(txt_Qty.Text) * Val(txt_PriceUnit.Text) * Val(txt_rat.Text), 2)
        'varDiscount = varTotalInvoice * Val(Txt_Discount) / 100

        txt_total.Text = varTotalInvoice
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
     

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Frm_AccountStatement.Close()
        Frm_AccountStatement.txt_codeAcc.Text = txt_AccountNo.Text
        Frm_AccountStatement.txt_NameAcc.Text = txt_nameaccount.Text
        Frm_AccountStatement.MdiParent = Mainmune
        Frm_AccountStatement.find_Acc2()
        Frm_AccountStatement.Show()
    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql = "Delete TB_Header_PO2  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete TB_Detils_PO2  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                Find_all_Order()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select


    End Sub

    Private Sub Cmd_Edit_Click_1(sender As Object, e As EventArgs) Handles Cmd_Edit.Click
        sql = "   SELECT *    FROM BD_unit   WHERE(name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '===================================================================

        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateoder2 As String
        vardateoder2 = dd2.ToString("MM-d-yyyy")



        If Op4.Checked = True Then varcodationTaslem = 0
        If Op3.Checked = True Then varcodationTaslem = 1

        If OP5.Checked = True Then varcodationprice = 0
        If OP6.Checked = True Then varcodationprice = 1


        sql = "UPDATE  TB_Header_PO2  SET Code_Supliser ='" & txt_AccountNo.Text & "',PO_Deliver_Date ='" & vardateoder2 & "',CountDay_T='" & txt_day.Text & "', Paid_Type='" & txt_PaidType.Text & "' , Condation_Taslem='" & varcodationTaslem & "' , Condation_Pric='" & varcodationprice & "',Notes ='" & txt_Notes.Text & "'  WHERE   Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)



        sql = "UPDATE  TB_Detils_PO2  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Quntity2 ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Rat ='" & txt_rat.Text & "',Code_Cur='" & varcode_Cru & "',Total_Item='" & txt_total.Text & "',Price_Item='" & txt_PriceUnit.Text & "'  WHERE No_Item = '" & txt_CodeItem.Text & "' and Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        clear_detils()
        find_detalis()
        Find_all_Order()
    End Sub

    Private Sub cmd_Print_Click_1(sender As Object, e As EventArgs) Handles cmd_Print.Click
        varopenRptprsheses = 1
        'Frm_Report_Pr.Close()
        'Frm_Report_Pr.MdiParent = Mainmune
        Total_Sum()
        vartaxinvoice2 = Math.Round(Val(txt_totalPrice.Text) * 14 / 100, 2)
        vartalinvoice = Val(txt_totalPrice.Text)
        Frm_Report_Pr.Text = "أمر شراء"
        Frm_Report_Pr.Show()
    End Sub

    Private Sub Cmd_OrderItem_Click_2(sender As Object, e As EventArgs) Handles Cmd_OrderItem.Click
        'varcode_form = 2560
        'VARTBNAME = " Vw_AllDataItem"
        'Lookupitem.Fill_Alldata()
        'Lookupitem.ShowDialog()

        Frm_LookUp_OrderPrcheses.ShowDialog()
        fill_unit()
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txt_NameItem.Text = "" Then MsgBox("من فضلك اختار اسم الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_nameaccount.Text = "" Then MsgBox("من فضلك اختار اسم المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Frm_LastPriceList.txt_nameItem.Text = txt_NameItem.Text
        Frm_LastPriceList.txt_NameSuppliser.Text = txt_nameaccount.Text
        Frm_LastPriceList.Find_lastPriceList_Suppliser()
        Frm_LastPriceList.MdiParent = Mainmune

        Frm_LastPriceList.Show()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

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