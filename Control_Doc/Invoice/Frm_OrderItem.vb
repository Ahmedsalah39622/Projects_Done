Imports System.Data.OleDb
Imports DevExpress.XtraEditors.Repository
Public Class Frm_OrderItem
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varcodeExitem As String
    Dim varcode_TypeStores As Integer
    Dim varstatus As String
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Frm_LookupOrderItem.Close()
        Frm_LookupOrderItem.MdiParent = Mainmune
        Frm_LookupOrderItem.Show()

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


    

    Sub save_Order_H()
        'On Error Resume Next


        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_OrderItem_Stores where Ser_Order_Stores  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else

            '============================================================== نوع الصرف
            sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & txt_type.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_TypeStores = rs("code").Value
            '==================================================================


            sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Status_Order_Stores,Notes,Code_Tpye_Stores) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & 0 & "','" & txt_Notes.Text & "','" & varcode_TypeStores & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        clear_detils()

        find_detalis()

    End Sub

    Sub find_hedar()
        'On Error Resume Next

        sql = "   SELECT dbo.TB_Header_OrderItem_Stores.Notes, dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Compny_Code, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, " & _
   "                  dbo.TB_Header_OrderItem_Stores.Status_Order_Stores, dbo.BD_TypeSarfStores.Name AS type  " & _
   " FROM     dbo.TB_Header_OrderItem_Stores INNER JOIN  " & _
   "                  dbo.TB_Header_OrderItem ON dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code AND   " & _
   "                  dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Header_OrderItem.Order_Ser LEFT OUTER JOIN  " & _
   "                  dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND   " & _
   "        dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code  " & _
   " WHERE  (dbo.TB_Header_OrderItem_Stores.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Order_Stores").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Stores_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_stores").Value)
            vartypeItem2 = Trim(rs("Status_Order_Stores").Value)
            txt_type.Text = Trim(rs("type").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
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



        sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Flag_Item) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & VarCodeCompny & "','0')"
        Cnn.Execute(sql)



    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        txt_unit.Text = ""
        txt_Notes.Text = ""
        txt_type.Text = ""
        txt_Notes.Text = ""
        txt_type.SelectedIndex = -1
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

        If vartypeItem2 = 0 Then


            sql2 = "    SELECT        dbo.TB_Detils_OrderItem_Stores.No_Item, RTRIM(dbo.BD_Item.Ex_Item) AS Ex_Item, dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.NameItem_New, " & _
     "                        dbo.TB_Detils_OrderItem_Stores.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_OrderItem_Stores.Order_NO, dbo.TB_Detils_OrderItem.Notes " & _
    " FROM            dbo.BD_Currency INNER JOIN " & _
    "                         dbo.TB_Detils_OrderItem AS TB_Detils_OrderItem_1 ON dbo.BD_Currency.Code = TB_Detils_OrderItem_1.Code_Cur AND dbo.BD_Currency.Compny_Code = TB_Detils_OrderItem_1.Compny_Code INNER JOIN " & _
    "                         dbo.TB_Detils_OrderItem ON dbo.BD_Currency.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code RIGHT OUTER JOIN " & _
    "                         dbo.BD_Unit INNER JOIN " & _
    "                         dbo.TB_Detils_OrderItem_Stores ON dbo.BD_Unit.Code = dbo.TB_Detils_OrderItem_Stores.Code_Unit AND dbo.BD_Unit.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code ON  " & _
                " dbo.TB_Detils_OrderItem.No_Item = dbo.TB_Detils_OrderItem_Stores.No_Item And dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code And " & _
    "        dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_OrderItem_Stores.Order_NO And TB_Detils_OrderItem_1.No_Item = dbo.TB_Detils_OrderItem_Stores.No_Item And " & _
    "                     TB_Detils_OrderItem_1.Order_NO = dbo.TB_Detils_OrderItem_Stores.Order_NO LEFT OUTER JOIN " & _
   "                      dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code " & _
" WHERE        (dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem_Stores.Compny_Code = '" & VarCodeCompny & "') "




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
        GridView6.Columns(2).Width = "250"
        GridView6.Columns(3).Width = "250"
        GridView6.Columns(4).Width = "100"
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

        GridView6.Columns(3).Visible = False
        GridView6.Columns(6).Visible = False
        GridView6.Columns(7).Visible = False
        GridView6.Columns(1).Visible = False

        GridView6.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        'Mainmune.finwatinoderItem()
    End Sub

  


    Private Sub Frm_OrderItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_OrderItem3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Unit()
        fill_Type_Stores()
        find_AllData()
        Cmd_New_Click_1(Nothing, Nothing)
        'fill_Stores()
    End Sub
    Sub find_AllData()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        '  sql2 = "      SELECT        dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, dbo.BD_TypeSarfStores.Name AS TypeStores,  " & _
        '"                         dbo.TB_Detils_OrderItem_Stores.No_Item, dbo.BD_Item.Name AS NameItem,dbo.TB_Header_OrderItem_Stores.Notes, iif(dbo.TB_Detils_AznItem_Stores.Order_NO is null,'غير منصرف','منصرف') as dd " & _
        '" FROM            dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
        '"                         dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code INNER JOIN " & _
        '"                         dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores AND  " & _
        '"                         dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
        '"                         dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item AND dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Order_NO where  dbo.TB_Header_OrderItem_Stores.Compny_Code ='" & VarCodeCompny & "' order by  dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores "


        sql2 = "   SELECT TOP (100) PERCENT dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, dbo.BD_TypeSarfStores.Name AS TypeStores,  " & _
   "                  dbo.TB_Detils_OrderItem_Stores.No_Item, dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.Quntity AS QytAzn, dbo.TB_Header_OrderItem_Stores.Notes,  iif(dbo.TB_Detils_AznItem_Stores.Order_NO is null,'غير منصرف','منصرف') as dd, " & _
   "                  dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AS NoAznsarf, dbo.TB_Detils_AznItem_Stores.Quntity " & _
   " FROM     dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
   "                  dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code INNER JOIN " & _
   "                  dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores AND  " & _
   "                  dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item AND dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Order_NO " & _
   " WHERE  (dbo.TB_Header_OrderItem_Stores.Compny_Code = '1') " & _
   " ORDER BY dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        'GridView6.Columns(8).Width = "100"
        'GridView6.Columns(9).Width = "150"

        GridView2.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        GridView2.Columns(7).AppearanceCell.ForeColor = Color.Red

        GridView2.Appearance.Row.Font = New Font(GridView2.Appearance.Row.Font, FontStyle.Bold)
        GridView2.Appearance.Row.Options.UseFont = True

        GridView2.Columns(0).Caption = "رقم الطلب"
        GridView2.Columns(1).Caption = "رقم الطلب "
        GridView2.Columns(2).Caption = "تاريخ الطلب"
        GridView2.Columns(3).Caption = "نوع طلب الصرف"
        GridView2.Columns(4).Caption = "رقم الصنف"
        GridView2.Columns(5).Caption = "اسم الصنف"
        GridView2.Columns(6).Caption = "الكمية"

        GridView2.Columns(7).Caption = "ملاحظات"
        GridView2.Columns(8).Caption = "حالة الصنف بالمخزن"

        GridView2.Columns(9).Caption = "رقم الاذن "
        GridView2.Columns(10).Caption = "الكمية المنصرفة"

        GridView2.Columns(0).Visible = False
        'GridView6.Columns(6).Visible = False
        'GridView6.Columns(7).Visible = False
        'GridView6.Columns(1).Visible = False

        GridView2.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

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
        'com_stores.Items.Clear()
        'sql = "SELECT        Name FROM            dbo.BD_Stores  where Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    com_stores.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop
    End Sub
    Sub fill_Type_Stores()
        txt_type.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_TypeSarfStores  where Compny_Code ='" & VarCodeCompny & "' and flag = 0 "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_type.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_detalis()
        clear_detils()

        Cmd_Delete.Enabled = False
        cmd_DeleteLine.Enabled = False
        cmd_update.Enabled = False
        Cmd_save.Enabled = True
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click

        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '=====================================================




        sql2 = "select * from TB_Header_OrderItem_Stores where Ser_Order_Stores  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك ادخل نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()
        find_hedar()
        find_detalis()
        find_AllData()
    End Sub

    Private Sub Cmd_Delete_Click_1(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If varstatus = "منصرف" Then MsgBox("هذا الاذن تم صرفة ولا يمكن حذفه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '=====================================================



        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاذن", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                
                sql = "Delete TB_Detils_OrderItem_Stores  WHERE  Order_Stores_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete TB_Header_OrderItem_Stores  WHERE Order_Stores_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

            
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                clear_detils()
                find_AllData()
        End Select
    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs)
        Frm_Order_ItemStores.Show()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        VARTBNAME = "Vw_AllDataItem"
        varcode_form = 190
        Lookupitem.Text = "بحث"
        Lookupitem.ShowDialog()
    End Sub

    Private Sub Cmd_FindOrder_Click_1(sender As Object, e As EventArgs) Handles Cmd_FindOrder.Click
        vartable = "Vw_Lookup_OrderItem"
        VarOpenlookup = 25
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub GridControl3_Click_1(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))

        If txt_CodeItem.Text.Length = 0 Then Exit Sub
        Cmd_Delete.Enabled = True
        cmd_DeleteLine.Enabled = True
        cmd_update.Enabled = True
        Cmd_save.Enabled = False


    End Sub

  
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Frm_GardItem2.txt_codeItem.Text = txt_CodeItem.Text
        Frm_GardItem2.txt_NameItem.Text = txt_NameItem.Text
        Frm_GardItem2.FindBalance()
        'Frm_GardItem2.Com_Stores.Text = txt_namestores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub cmd_DeleteLine_Click(sender As Object, e As EventArgs) Handles cmd_DeleteLine.Click
        On Error Resume Next
        '====================================

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '=====================================================



        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "Delete TB_Detils_OrderItem_Stores  WHERE No_Item = '" & varcodeitem & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

           
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                find_AllData()
        End Select
    End Sub

    Private Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن تعديل الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '=====================================================


        '======================================No Unit
        sql = "   SELECT Code   FROM BD_Unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value
        '=================================================
        '============================================================== نوع الصرف
        sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & txt_type.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_TypeStores = rs("code").Value
        '==================================================================

        sql = "UPDATE  TB_Header_OrderItem_Stores  SET Code_Tpye_Stores = '" & varcode_TypeStores & "',Notes ='" & txt_Notes.Text & "'  WHERE   Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        sql = "UPDATE  TB_Detils_OrderItem_Stores  SET Quntity = '" & txt_Qty.Text & "',Code_Unit = '" & varcodunit & "'  WHERE  No_Item = '" & txt_CodeItem.Text & "' and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        MsgBox("تم التعديل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "CSS Solution Software Module")
        find_hedar()
        find_detalis()
        find_AllData()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Com_InvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_InvoiceNo.SelectedIndexChanged

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Frm_RptRequestStores.Show()
    End Sub

    Private Sub SimpleButton24_Click(sender As Object, e As EventArgs) Handles SimpleButton24.Click
        GridView2.ShowRibbonPrintPreview()

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(1))
        txt_type.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(3))
        txt_Notes.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(7))
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

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