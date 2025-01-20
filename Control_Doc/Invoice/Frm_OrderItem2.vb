Imports System.Data.OleDb

Public Class Frm_OrderItem2
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varcodeExitem As String

    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

   



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

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_OrderItem_Stores2 where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            sql = "INSERT INTO TB_Header_OrderItem_Stores2 (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderSal.Text & "','" & 0 & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        clear_detils()

        find_detalis()

    End Sub

    Sub find_hedar()
        sql = "     SELECT        Ser_Order_Stores, Order_Stores_NO, Order_NO, Compny_Code, Order_Date_stores, Notes, " & _
     " FROM            dbo.TB_Header_OrderItem_Stores2 " & _
     " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO ='" & Com_InvoiceNo2.Text & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            txt_OrderSal.Text = Trim(rs("Order_NO").Value)
        End If

    End Sub
    Sub save_oderDetils()
        sql = "   SELECT Unit1, Ex_Item    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        sql = "INSERT INTO TB_Detils_OrderItem_Stores2 (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','" & txt_OrderSal.Text & "','0')"
        Cnn.Execute(sql)



    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        txt_OrderSal.Text = ""
    End Sub

   

   
    Private Sub GridControl3_Click(sender As Object, e As EventArgs)
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))

    End Sub



    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Frm_Gard2.ShowDialog()
    End Sub

    


    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql2 = "   SELECT        dbo.TB_Detils_OrderItem_Stores2.No_Item, RTRIM(dbo.TB_Detils_OrderItem_Stores2.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name,dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
        '       " FROM            dbo.TB_Detils_OrderItem_Stores2 INNER JOIN " & _
        '       "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code INNER JOIN " & _
        '       "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem_Stores2.Ex_Item = dbo.BD_ITEM.Ex_Item " & _
        '       " WHERE        (dbo.TB_Detils_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "

        sql2 = "SELECT        dbo.TB_Detils_OrderItem_Stores2.No_Item, RTRIM(dbo.TB_Detils_OrderItem_Stores2.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name,  " & _
"                         dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
" FROM            dbo.TB_Detils_OrderItem_Stores2 INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
"                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem_Stores2.Ex_Item = dbo.BD_ITEM.Ex_Item " & _
" WHERE        (dbo.TB_Detils_OrderItem_Stores2.Compny_Code =  '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "200"
        GridView6.Columns(3).Width = "50"
        GridView6.Columns(4).Width = "50"
        GridView6.Columns(5).Width = "150"

        GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "رقم الطلبية"





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

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_OrderItem_Stores2 where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
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

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem_Stores2  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click
       
    End Sub

    
    Private Sub Cmd_OrderItem_Click(sender As Object, e As EventArgs) Handles Cmd_OrderItem.Click
        Frm_LookupOrderItem2.ShowDialog()
    End Sub

   
    Private Sub Cmd_FindOrder_Click(sender As Object, e As EventArgs) Handles Cmd_FindOrder.Click
        vartable = "Vw_Lookup_OrderItem2"
        VarOpenlookup = 29
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click

    End Sub
End Class