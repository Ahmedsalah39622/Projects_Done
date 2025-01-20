Imports System.Data.OleDb
Imports DevExpress.XtraEditors.Repository

Public Class Frm_OrderItem_old
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varcodeExitem As String

    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Frm_LookupOrderItem.ShowDialog()
    End Sub



    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem_Stores    GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "OS000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "OS000" + "1"


        End If
    End Sub


    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_OrderItem_Stores where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()
    End Sub

    Sub save_Order_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_OrderItem_Stores where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderSal.Text & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        clear_detils()

        find_detalis()

    End Sub

    Sub find_hedar()
        'On Error Resume Next

        sql = "SELECT        dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Order_NO, dbo.TB_Header_OrderItem_Stores.Compny_Code,  " & _
        "                         dbo.TB_Header_OrderItem_Stores.Order_Date_stores, dbo.Tb_AprovedCustomer.Name as TaxStatus, dbo.FindCustomer.Name AS NameCustomer,dbo.TB_Header_OrderItem_Stores.Status_Order_Stores " & _
        " FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
        "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code AND  " & _
        "                         dbo.TB_Header_OrderItem_Stores.Order_NO = dbo.TB_Header_OrderItem.Order_NO INNER JOIN " & _
        "                         dbo.Tb_AprovedCustomer ON dbo.TB_Header_OrderItem.Abrove_Customer = dbo.Tb_AprovedCustomer.Code INNER JOIN " & _
        "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code " & _
        " WHERE        (dbo.TB_Header_OrderItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
            txt_NameCustomer.Text = Trim(rs("NameCustomer").Value)
            txt_StatusTax.Text = Trim(rs("TaxStatus").Value)
            vartypeItem2 = Trim(rs("Status_Order_Stores").Value)

        End If

    End Sub
    Sub save_oderDetils()
        sql = "   SELECT Code   FROM BD_Unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)
        '==================================



        sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item,NameItem_New) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "','0','" & txt_NameItem_New.Text & "')"
        Cnn.Execute(sql)



    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        txt_OrderSal.Text = ""
        txt_NameItem_New.Text = ""
        txt_Notes.Text = ""
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click
        sql = "   SELECT Unit1, Ex_Item    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        sql = "UPDATE  TB_Detils_OrderItem_Stores  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "'  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        clear_detils()
        find_detalis()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_NameItem_New.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))

    End Sub



    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Frm_Gard2.ShowDialog()
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        vartable = "Vw_Lookup_OrderItem"
        VarOpenlookup = 25
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()

    End Sub


    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If vartypeItem2 = 0 Then


            sql2 = "   SELECT        dbo.TB_Detils_OrderItem_Stores.No_Item, RTRIM(dbo.BD_ITEM.Ex_Item) as Ex_Item , dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.NameItem_New, dbo.TB_Detils_OrderItem_Stores.Quntity,  " & _
                   "                         dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_OrderItem_Stores.Order_NO, dbo.TB_Detils_OrderItem.Notes " & _
                   " FROM            dbo.BD_Unit INNER JOIN " & _
                   "                         dbo.TB_Detils_OrderItem_Stores ON dbo.BD_Unit.Code = dbo.TB_Detils_OrderItem_Stores.Code_Unit AND dbo.BD_Unit.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code INNER JOIN " & _
                   "                         dbo.TB_Detils_OrderItem ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_OrderItem.No_Item AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code AND  " & _
                   "                         dbo.TB_Detils_OrderItem_Stores.Order_NO = dbo.TB_Detils_OrderItem.Order_NO LEFT OUTER JOIN " & _
                   "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_ITEM.Code LEFT OUTER JOIN " & _
                   "                         dbo.BD_Currency INNER JOIN " & _
                   "                         dbo.TB_Detils_OrderItem AS TB_Detils_OrderItem_1 ON dbo.BD_Currency.Code = TB_Detils_OrderItem_1.Code_Cur AND dbo.BD_Currency.Compny_Code = TB_Detils_OrderItem_1.Compny_Code ON  " & _
                   "        dbo.TB_Detils_OrderItem_Stores.No_Item = TB_Detils_OrderItem_1.No_Item  And " & _
                   "     dbo.TB_Detils_OrderItem_Stores.Order_NO = TB_Detils_OrderItem_1.Order_NO " & _
                   " WHERE        (dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem_Stores.Compny_Code ='" & VarCodeCompny & "') "

        End If


        If vartypeItem2 = 1 Then

            sql2 = "SELECT        dbo.TB_Detils_OrderItem_Stores.No_Item, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.NameItem_New,  " & _
            "                         dbo.TB_Detils_OrderItem_Stores.Quntity, dbo.BD_Unit.Name, dbo.TB_Detils_OrderItem_Stores.Order_NO, dbo.TB_Detils_OrderItem_Stores.Notes " & _
            " FROM            dbo.TB_Detils_OrderItem_Stores INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_ITEM.Code " & _
            " WHERE        (dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores.Flag_Item = 1) "



        End If



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "150"
        GridView6.Columns(3).Width = "150"
        GridView6.Columns(4).Width = "50"
        GridView6.Columns(5).Width = "100"
        GridView6.Columns(6).Width = "100"
        GridView6.Columns(7).Width = "200"
        'GridView6.Columns(8).Width = "100"
        'GridView6.Columns(9).Width = "150"

        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الصنف الجديد"
        GridView6.Columns(4).Caption = "الكمية"
        GridView6.Columns(5).Caption = "الوحدة"
        GridView6.Columns(6).Caption = "رقم الطلبية"
        GridView6.Columns(7).Caption = "ملاحظات الصنف"

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Mainmune.finwatinoderItem()
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_detalis()
        clear_detils()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Frm_Order_ItemStores.Show()
    End Sub
End Class