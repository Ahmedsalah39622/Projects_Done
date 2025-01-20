Imports System.Data.OleDb

Public Class Frm_OrderInvintory
    Dim valueG1, valueG2, varcodeExitem, varNameUnit As String
    Dim varcodunit, varcode_TypeStores, varclick As Integer
    Private Sub Frm_OrderInvintory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Group()
        fill_Type_Stores()
        'find_allData()
        find_AllData2()
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

    Sub find_AllData2()
        GridControl4.DataSource = Nothing
        GridView7.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        SQL4 = "   SELECT TOP (100) PERCENT dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, dbo.BD_TypeSarfStores.Name AS TypeStores, " & _
   "                  dbo.TB_Detils_OrderItem_Stores.No_Item, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.Quntity AS QytAzn,  iif(dbo.TB_Detils_AznItem_Stores.Order_NO is null,'غير منصرف','منصرف') as dd,  " & _
   "                  dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AS NoAznsarf, dbo.TB_Detils_AznItem_Stores.Quntity,dbo.TB_Header_OrderItem_Stores.PAO " & _
   " FROM     dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
   "                  dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores AND  " & _
   "                  dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item AND dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Order_NO " & _
   " ORDER BY dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(SQL4, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)


        GridView7.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        GridView7.Columns(7).AppearanceCell.ForeColor = Color.Red

        GridView7.Appearance.Row.Font = New Font(GridView7.Appearance.Row.Font, FontStyle.Bold)
        GridView7.Appearance.Row.Options.UseFont = True

        GridView7.Columns(0).Caption = "رقم الطلب"
        GridView7.Columns(1).Caption = "رقم الطلب "
        GridView7.Columns(2).Caption = "تاريخ الطلب"
        GridView7.Columns(3).Caption = "نوع طلب الصرف"
        GridView7.Columns(4).Caption = "رقم الصنف"
        GridView7.Columns(5).Caption = "RefNo"
        GridView7.Columns(6).Caption = "اسم الصنف"
        GridView7.Columns(7).Caption = "الكمية"
        GridView7.Columns(8).Caption = "حالة الصنف بالمخزن"
        GridView7.Columns(9).Caption = "رقم اذن الصرف "
        GridView7.Columns(10).Caption = "الكمية المنصرفة"
        GridView7.Columns(11).Caption = "PAO"

        GridView7.Columns(0).Visible = False
        'GridView6.Columns(6).Visible = False
        'GridView6.Columns(7).Visible = False
        'GridView6.Columns(1).Visible = False

        GridView7.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub
    Sub find_allData()
        '       Dim con As New OleDb.OleDbConnection
        '       Dim ss As String
        '       ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        '       con.ConnectionString = ss
        '       con.Open()

        '       sql2 = " SELECT dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, RTRIM(dbo.BD_Stores.Name) AS NameStores " & _
        '" FROM     dbo.Hedar_FirstStoresItem INNER JOIN " & _
        '"                  dbo.BD_Stores ON dbo.Hedar_FirstStoresItem.Code_Stores = dbo.BD_Stores.Code " & _
        '"        WHERE(dbo.Hedar_FirstStoresItem.Compny_Code = 1) "

        '       Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)

        '       Dim ds As New DataSet()

        '       da.Fill(ds)

        '       GridControl4.DataSource = ds.Tables(0)


        '       GridView7.Columns(0).Caption = "رقم الاذن"
        '       GridView7.Columns(1).Caption = "التاريخ"
        '       GridView7.Columns(2).Caption = "المخزن"


        '       GridView7.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        '       GridView7.Appearance.Row.Options.UseFont = True

        '       GridView7.BestFitColumns()

        '       ds = Nothing
        '       da = Nothing
        '       con.Close()
        '       con.Dispose()

    End Sub
    Sub Find_Group()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " SELECT Name FROM     dbo.BD_GROUPITEMMAIN "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl3.DataSource = ds.Tables(0)


        GridView4.Columns(0).Caption = "أسم الصنف"


        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True

        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        valueG1 = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "     Select G1_Item     FROM dbo.VW_FINDDATAITEM2 WHERE  (MG_Item = '" & valueG1 & "') GROUP BY G1_Item   HAVING(G1_Item Is Not NULL)"

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Columns(0).Caption = "المجموعة 2"
        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.BestFitColumns()
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '====================================================
        valueG2 = ""
        Search()

        If varclick = 1 Then
            add_col()
        Else
            add_col()
        End If
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        'Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        'valueG2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        'Search()

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        valueG2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Search()

        If varclick = 1 Then
            add_col()
        Else
            add_col()
        End If
    End Sub

    Sub add_col()
        Dim cmb As New DataGridViewComboBoxColumn()

        cmb.HeaderText = "الوحدة"
        cmb.Name = "cmb"
        cmb.MaxDropDownItems = 2


        sql = "SELECT Name FROM     dbo.BD_Unit"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            cmb.Items.Add(rs("Name").Value)
            varclick = 1

            rs.MoveNext()
        Loop

        DataGridView2.Columns.Add(cmb)


        'DataGridView2.Columns.Remove(cmb)
    End Sub
    Sub Search()
        On Error Resume Next

        'DataGridView2.

        DataGridView2.DataSource = Nothing
        DataGridView2.Columns.Clear()
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        'sql = " SELECT        Code,rtrim(EX_Item) as ex_item, rtrim(Name) as name FROM            dbo.VW_FINDDATAITEM2  WHERE    (MG_Item LIKE '%" & valueG1 & "%') AND (G1_Item LIKE '%" & valueG2 & "%')  and    EX_Item like '%" & txt_Ref_Find.Text & "%' and   (Compny_Code = '" & VarCodeCompny & "')  "


        sql = " SELECT dbo.VW_FINDDATAITEM2.Code, RTRIM(dbo.VW_FINDDATAITEM2.Ex_Item) AS ex_item, RTRIM(dbo.VW_FINDDATAITEM2.Name) AS name, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance " & _
" FROM     dbo.VW_FINDDATAITEM2 LEFT OUTER JOIN " & _
"                  dbo.Statement_OfItem ON dbo.VW_FINDDATAITEM2.Code = dbo.Statement_OfItem.NoItem " & _
" WHERE  (dbo.VW_FINDDATAITEM2.MG_Item LIKE '%" & valueG1 & "%') AND (dbo.VW_FINDDATAITEM2.G1_Item LIKE '%" & valueG2 & "%') AND (dbo.VW_FINDDATAITEM2.Ex_Item LIKE '%" & txt_Ref_Find.Text & "%') and dbo.VW_FINDDATAITEM2.Name LIKE '%" & txt_Name.Text & "%' " & _
" GROUP BY dbo.VW_FINDDATAITEM2.Code, RTRIM(dbo.VW_FINDDATAITEM2.Ex_Item), RTRIM(dbo.VW_FINDDATAITEM2.Name) "




        'sql = "SELECT  code,name FROM  BD_ITEM   "
        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)




        DataGridView2.Columns(0).HeaderText = "كود الصنف"
        DataGridView2.Columns(2).HeaderText = "أسم الصنف"
        DataGridView2.Columns(1).HeaderText = "Ref No"
        DataGridView2.Columns(3).HeaderText = "الرصيد المتاح"

        DataGridView2.Columns(0).Width = "75"
        DataGridView2.Columns(1).Width = "100"
        DataGridView2.Columns(2).Width = "200"


        DataGridView2.Columns(0).Visible = False

        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.BestFitColumns()
        'GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    

    Sub save_data()
        On Error Resume Next

        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & var_codeItem & "') AND (Compny_Code = '" & VarCodeCompny & "')"
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
        If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك ادخل نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        save_Order_H()
        find_hedar()
        find_detalis()
        find_AllData2()

    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "  SELECT dbo.TB_Detils_OrderItem_Stores.No_Item, RTRIM(dbo.BD_Item.Ex_Item) AS exitem, RTRIM(dbo.BD_Item.Name) AS nameItem, dbo.BD_Unit.Name AS unit, dbo.TB_Detils_OrderItem_Stores.Quntity, " & _
  "                  RTRIM(dbo.TB_Detils_OrderItem_Stores.Order_NO) AS PAONO, dbo.TB_Detils_OrderItem_Stores.JOB_Order " & _
  " FROM     dbo.TB_Detils_OrderItem_Stores LEFT OUTER JOIN " & _
  "                  dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code LEFT OUTER JOIN " & _
  "                  dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores.Code_Unit = dbo.BD_Unit.Code " & _
  " GROUP BY dbo.TB_Detils_OrderItem_Stores.No_Item, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.BD_Unit.Name, dbo.TB_Detils_OrderItem_Stores.Quntity, dbo.TB_Detils_OrderItem_Stores.Order_NO, " & _
  "        dbo.TB_Detils_OrderItem_Stores.JOB_Order, dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores " & _
  "        HAVING(dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores = '" & Com_InvoiceNo.Text & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

        DataGridView1.Columns(0).HeaderText = "كود الصنف"
        DataGridView1.Columns(1).HeaderText = "RefNO "
        DataGridView1.Columns(2).HeaderText = "الصنف"
        DataGridView1.Columns(3).HeaderText = "الوحدة"
        DataGridView1.Columns(4).HeaderText = "الكمية"
        DataGridView1.Columns(5).HeaderText = "الطلبية"
        DataGridView1.Columns(6).HeaderText = "رقم امر الشغل"
        DataGridView1.Columns(2).Width = 300
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Sub find_hedar()
        On Error Resume Next

        sql = "   SELECT TB_Header_OrderItem_Stores.PAO,dbo.TB_Header_OrderItem_Stores.Notes, dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores, dbo.TB_Header_OrderItem_Stores.Order_Stores_NO, dbo.TB_Header_OrderItem_Stores.Compny_Code, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, " & _
   "                  dbo.TB_Header_OrderItem_Stores.Status_Order_Stores, dbo.BD_TypeSarfStores.Name AS type  " & _
   " FROM     dbo.TB_Header_OrderItem_Stores LEFT OUTER JOIN  " & _
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
            Txt_PAO.Text = Trim(rs("PAO").Value)
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


            sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Status_Order_Stores,Notes,Code_Tpye_Stores,PAO) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & 0 & "','" & txt_Notes.Text & "','" & varcode_TypeStores & "','" & Txt_PAO.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        'clear_detils()

        find_detalis()

    End Sub
    Sub save_oderDetils()
        'sql = "   SELECT Code   FROM BD_item    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit = rs("code").Value


        '============================
        sql = "   SELECT *    FROM BD_ITEM    WHERE(code = '" & varcode_item & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)
        '==================================
        '=====================================================الوحدة
        'varcodunit = rs("Unit1").Value :
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & varNameUnit & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value



        sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Flag_Item) " & _
              " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & varcode_item & "','" & 0 & "','" & varcodunit & "','" & VarCodeCompny & "','0')"
        Cnn.Execute(sql)



    End Sub
    Sub save_oderDetils_Button()


        sql = "  SELECT         Compny_Code, Order_Stores_NO FROM            dbo.TB_Header_AznItem_Stores  WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND  (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن الحفظ الطلب علية حركة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '=====================================================

        Dim sql2 As String
        sql2 = "UPDATE  TB_Header_OrderItem_Stores  SET PAO ='" & Txt_PAO.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Ser_Order_Stores ='" & Com_InvoiceNo.Text & "'   "
        rs = Cnn.Execute(sql2)
        '==========================================================================



        sql = "Delete TB_Detils_OrderItem_Stores  where Ser_Order_Stores = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(x).Cells(0).Value = Nothing Then
            Else

                sql = "   SELECT Code   FROM BD_Unit    WHERE(Name = '" & DataGridView1.Rows(x).Cells(3).Value & "') and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcodunit = rs("code").Value


                '============================================================ وحدة البيع
                sql = "   SELECT *    FROM BD_ITEM    WHERE(code = '" & DataGridView1.Rows(x).Cells(0).Value & "') and Compny_Code ='" & VarCodeCompny & "'"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcodunit = rs("Unit1").Value : varcodeitem = rs("code").Value : varcodeExitem = Trim(rs("Ex_Item").Value)

                '========================الاذن
                sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Flag_Item) " & _
                      " values  ('" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & varcodeitem & "','" & DataGridView1.Rows(x).Cells(4).Value & "','" & varcodunit & "','" & VarCodeCompny & "','0')"
                Cnn.Execute(sql)
            End If
        Next x
        countItem()

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, " Solution Software Module")

        find_detalis()
        find_AllData2()

    End Sub
    Sub countItem()
        'sql2 = " SELECT Ser_Order_Stores, COUNT(NoItem) AS CountItem       FROM dbo.TB_Detils_OrderItem_Stores GROUP BY Ser_Order_Stores HAVING(Ser_Order_Stores = '" & Com_InvoiceNo.Text & "') "
        sql2 = "  SELECT COUNT(Order_Stores_NO) AS CountItem FROM     dbo.TB_Detils_OrderItem_Stores GROUP BY Ser_Order_Stores HAVING (Ser_Order_Stores = 1)"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then txt_Count.Text = rs("CountItem").Value Else txt_Count.Text = "0"

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
        save_oderDetils_Button()
    End Sub

  

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView7.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(1))
        txt_type.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(3))
        txt_Notes.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(7))
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        last_Data()
        find_detalis()


     
        Cmd_save.Enabled = True
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click

        Dim report As New RptTalabSarf
        report.FilterString = " [Order_Stores_NO] = '" & Trim(Com_InvoiceNo2.Text) & "'   "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 2
    End Sub

    Private Sub txt_Ref_Find_TextChanged(sender As Object, e As EventArgs) Handles txt_Ref_Find.TextChanged
        Search()
    End Sub

  

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro

        If DataGridView2.Item(4, mt).Value = "" Then MsgBox("من فضلك اختار الوحدة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If txt_type.Text = "" Then MsgBox("من فضلك اختار نوع الصرف", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub


        ro = DataGridView2.CurrentRow.Index
        mt = ro
        varcode_item = DataGridView2.Item(0, mt).Value
        varNameUnit = DataGridView2.Item(4, mt).Value



        save_data()
        'find_hedar()
        'find_detalis()
        'Fill_INVOICE2()
        'find_allData()
    End Sub

    Private Sub Cmd_FindRefNo_Click_1(sender As Object, e As EventArgs) Handles Cmd_FindRefNo.Click
        Search()
    End Sub

    Private Sub cmd_DeleteAll_Click(sender As Object, e As EventArgs) Handles cmd_DeleteAll.Click
        On Error Resume Next

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If varstatus = "منصرف" Then MsgBox("هذا الاذن تم صرفة ولا يمكن حذفه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لايمكن حذف الاذن علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
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
                'clear_detils()
                find_allData()
                find_AllData2()
        End Select
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        VarOpenlookup2 = 24004
        Frm_LookUpCustomer.fill_Project()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged
        Search()
        If varclick = 1 Then
            add_col()
        Else
            add_col()
        End If
    End Sub
End Class