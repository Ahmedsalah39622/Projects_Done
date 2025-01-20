Imports System.Data.OleDb
Imports ADODB
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_FristItem
    Public varExserail As String
    Dim Varitem, varGM, VarG1, VarG2, varNoBarcode, varNoBarcode2, var_codeItem22 As String
    Dim varSubStores As Integer
    Dim vartypeinvoice, varmaxcount, varmaxser, varmaxline, varcountbarcode As Integer
    Dim varcodeitem As Integer
    Dim varcodunit, varcodunit2 As Integer
    Dim varflagazn As Integer
    Dim xx As String
    Dim VarItem_EX As String
    Dim vartotalitem As Single


    Dim varbarcode As String
    Dim varprice2 As Single
    Dim varGroup1 As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'clear()
        'last_Data()

        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        'Fill_invoiceNo()
        txt_CodeSub.Text = varcodesub
        txt_NameSub.Text = VarNameSub

        'Com_Type.Items.Add("اذن صرف من المخزن")
        'Com_Type.Items.Add("تحويل من المخازن")
        find_gridItem()

        fill_Unit()
        'Dim AddCategory As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        'Me.GridView1.Columns(5).ColumnEdit = AddCategory
        'AddCategory.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        'sum_total()
    End Sub
    Private Sub repositoryItemButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        'If e.Button.Tag IsNot Nothing Then 'determine a button
        '    MessageBox.Show("Button clicked")
        'End If
    End Sub
    Sub fill_Unit()
        com_Unit.Items.Clear()
        'com_Unit2.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Unit where Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Unit.Items.Add(rs("Name").Value)
            'com_Unit2.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub sum_total()
        'GridView1.Columns(3).Summary.Add(DevExpress.Data.SummaryItemType.Sum, "0", "{{0:n2}")
        'GridView1.Columns(2).Group()
        'GridView1.Columns(3).Group()
        'GridView6.Columns(3).
        'GridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        'Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item.FieldName = "النوع"
        'item.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView1.GroupSummary.Add(item)


        'Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item1.FieldName = "النوع"
        'item1.SummaryType = DevExpress.Data.SummaryItemType.Count
        'item1.DisplayFormat = "Total {0:c2}"
        'item1.ShowInGroupColumnFooter = GridView6.Columns("النوع")
        'GridView6.GroupSummary.Add(item1)

    End Sub

    Sub last_Data()
        Dim varseril As Integer
        '============================================بضاعة اول المدة
        sql = "SELECT ExSerail_FirstStores, NoSerail_FirstStores     FROM TB_SerailAcc where Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varseril = rs2("NoSerail_FirstStores").Value : varExserail = Trim(rs2("ExSerail_FirstStores").Value)
 

        Dim x As String
        x = varExserail
        sql = "SELECT MAX(NumberBill) AS MaxmamNo, Code_Sub,Flag_status FROM     Hedar_FirstStoresItem where Compny_Code ='" & VarCodeCompny & "'  GROUP BY Code_Sub,Flag_status HAVING  Flag_status ='" & varflagstatus & "'  and Code_Sub = '" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxmamNo").Value + 1
            Com_InvoiceNo2.Text = Val(Com_InvoiceNo.Text) + Val(varseril)
            Com_InvoiceNo2.Text = x + "" + Com_InvoiceNo2.Text
        Else
            Com_InvoiceNo.Text = 1

            Com_InvoiceNo2.Text = 1 + varseril
            x = varExserail + Com_InvoiceNo2.Text
            Com_InvoiceNo2.Text = x
            'clear()

        End If
        find_gridItem()
    End Sub

    Sub last_SerBarcode()



        sql = "    SELECT MAX(No_ser_Barcode) AS MaxmamNoBarcode, NoItem " & _
            " FROM Detalis_FirstStoreItem " & _
            " GROUP BY NoItem " & _
            " HAVING (MAX(No_ser_Barcode) IS NOT NULL) AND (NoItem = '" & txt_CodeItem.Text & "')"

        'Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varcountbarcode = rs("MaxmamNoBarcode").Value + 1
        Else
            varcountbarcode = 1
            'clear()

        End If
    End Sub
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        callNew()
        ''DataGridView2.RowCount = 0
        'DataGridView2.Item(0, 0).Value = ""
        'DataGridView2.Item(1, 0).Value = ""
        'DataGridView2.Item(2, 0).Value = ""
        'DataGridView2.Item(3, 0).Value = ""
        'DataGridView2.Item(4, 0).Value = ""
        'DataGridView2.Item(5, 0).Value = ""

    End Sub
    Sub callNew()
        clear()
        last_Data()
        'varflagstatus = 0
        'find_gridItem()


        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        txt_CodeSub.Text = 1
        txt_NameSub.Text = VarNameSub

        ButtonX1.Enabled = True

        ButtonX4.Enabled = True
        cmd_Delete.Enabled = False
        Cmd_Update.Enabled = False
        Cmd_Save.Enabled = True
    End Sub
    Sub clear()
        On Error Resume Next
        'Cmd_Save.Enabled = True
        Com_InvoiceNo2.Text = ""
        Com_InvoiceNo.Text = ""
        Cmd_Print.Enabled = True
        Com_InvoiceNo.Enabled = False
        txt_codestores.Text = ""
        txt_Notes.Text = ""
        txt_codestores.Text = ""
        txt_namestores.Text = ""
        txt_CodeSub.Text = ""
        txt_NameSub.Text = ""
        txt_Notes.Text = ""
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        'Txt_TotalCount.Text = ""
        txt_Price.Text = ""
        txt_total.Text = ""
        txt_codestores2.Text = ""
        txt_namestores2.Text = ""
        'Com_Type .Text =""
        '  Txt_Count2.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_Barcode.Text = ""
        txt_Typeinv.Text = "مفتوحة"
        txt_Typeinv.BackColor = Color.GreenYellow
        'ButtonX6.Enabled = True
        'ButtonX3.Enabled = True
        Cmd_Update.Enabled = True
        Cmd_Save.Enabled = True
        ButtonX4.Enabled = True
        Cmd_Update.Enabled = True
        txt_QtyAvalabil.Text = ""
        com_Unit.Text = ""
        txt_priccUnit.Text = ""
        'DataGridView2.RowCount = 1
        'DataGridView2.Item(0, 0).Value = ""
        'DataGridView2.Item(1, 0).Value = ""
        'DataGridView2.Item(2, 0).Value = ""
        'DataGridView2.Item(3, 0).Value = ""
        'DataGridView2.Item(4, 0).Value = ""
        'DataGridView2.Item(5, 0).Value = ""
        'DataGridView2.Item(6, 0).Value = ""
        'DataGridView2.Item(7, 0).Value = ""
        'DataGridView2.Item(8, 0).Value = ""
        'DataGridView2.Item(9, 0).Value = ""
        'DataGridView2.Item(10, 0).Value = ""
        'DataGridView2.Item(11, 0).Value = ""

    End Sub

    Private Sub Com_InvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs)


        Fill_INVOICE2()


    End Sub


    Sub Fill_INVOICE2()
        On Error Resume Next
        'If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagstatus = 2
        'If com_typeSnd.Text = "تحويل من المخازن" Then varflagstatus = 1

        If com_typeSnd.Text = "بضاعة اول المدة" Then varflagstatus = 0







        sql = "  SELECT        TOP (100) PERCENT dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, dbo.Hedar_FirstStoresItem.DisHdaer, dbo.Hedar_FirstStoresItem.Code_Stores, " & _
"                        dbo.Hedar_FirstStoresItem.Code_Sub, dbo.Hedar_FirstStoresItem.Code_Stores2, dbo.Hedar_FirstStoresItem.FlagAzn, dbo.Hedar_FirstStoresItem.Ex_No, dbo.Hedar_FirstStoresItem.Status_AznSarf,  " & _
"                        dbo.Hedar_FirstStoresItem.AccountNo_Customer, dbo.BD_Stores.Name AS NameStores, BD_Stores_1.Name AS NameStores2, dbo.BD_SUBMAIN.Name AS Namesub,  " & _
"           dbo.Hedar_FirstStoresItem.Compny_Code " & _
" FROM            dbo.Hedar_FirstStoresItem LEFT OUTER JOIN " & _
"                         dbo.BD_Stores ON dbo.Hedar_FirstStoresItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Hedar_FirstStoresItem.Compny_Code = dbo.BD_Stores.Compny_Code LEFT OUTER JOIN " & _
"                         dbo.BD_Stores AS BD_Stores_1 ON dbo.Hedar_FirstStoresItem.Compny_Code = BD_Stores_1.Compny_Code AND dbo.Hedar_FirstStoresItem.Code_Stores2 = BD_Stores_1.Code LEFT OUTER JOIN " & _
"                         dbo.BD_SUBMAIN ON dbo.Hedar_FirstStoresItem.Compny_Code = dbo.BD_SUBMAIN.Compny_Code AND dbo.Hedar_FirstStoresItem.Code_Sub = dbo.BD_SUBMAIN.Code " & _
" WHERE      (dbo.Hedar_FirstStoresItem.Compny_Code = '" & VarCodeCompny & "') " & _
" GROUP BY dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, dbo.Hedar_FirstStoresItem.DisHdaer, dbo.Hedar_FirstStoresItem.Code_Stores, dbo.Hedar_FirstStoresItem.Code_Sub,  " & _
"            dbo.Hedar_FirstStoresItem.Code_Stores2, dbo.Hedar_FirstStoresItem.FlagAzn, dbo.Hedar_FirstStoresItem.Ex_No, dbo.Hedar_FirstStoresItem.Status_AznSarf, dbo.Hedar_FirstStoresItem.AccountNo_Customer, " & _
"            dbo.BD_Stores.Name, BD_Stores_1.Name, dbo.BD_SUBMAIN.Name, dbo.Hedar_FirstStoresItem.Compny_Code  HAVING(Hedar_FirstStoresItem.NumberBill = '" & Com_InvoiceNo.Text & "')" & _
" ORDER BY dbo.Hedar_FirstStoresItem.NumberBill "



        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then

            'If rs3("FlagAzn").Value = 1 Then com_typeSnd.Text = "تحويل من المخازن"
            'If rs3("FlagAzn").Value = 2 Then com_typeSnd.Text = "اذن صرف من المخزن"

            '=====================================================Hedares
            txt_date.Value = rs3("DateBill").Value
            txt_codestores.Text = rs3("Code_Stores").Value
            txt_namestores.Text = rs3("NameStores").Value
            Com_InvoiceNo2.Text = rs3("Ex_No").Value
            txt_codestores2.Text = rs3("Code_Stores2").Value
            If varflagstatus = 1 Then txt_namestores2.Text = rs3("NameStores2").Value
            txt_CodeSub.Text = rs3("Code_Sub").Value
            txt_NameSub.Text = rs3("NameSub").Value
            txt_Notes.Text = rs3("DisHdaer").Value
            txt_AccountNo.Text = rs3("AccountNo_Customer").Value
          

        End If
        find_gridItem()
        'Total_Qty1()
    End Sub

    Sub find_gridItem()
        'On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        Dim VARCODE_AZN As Integer
        If Com_InvoiceNo.Text = "" Then VARCODE_AZN = 0 Else VARCODE_AZN = Com_InvoiceNo.Text
     

     


        sql2 = "   SELECT        dbo.Detalis_FirstStoreItem.NoItem, dbo.BD_Item.Name, dbo.Detalis_FirstStoreItem.Quntity, dbo.BD_Unit.Name AS Unit2, dbo.Detalis_FirstStoreItem.Price, dbo.Detalis_FirstStoreItem.Total_Item " & _
" FROM            dbo.BD_Item RIGHT OUTER JOIN " & _
"                         dbo.Detalis_FirstStoreItem LEFT OUTER JOIN " & _
"                         dbo.BD_Unit ON dbo.Detalis_FirstStoreItem.CodeUnit = dbo.BD_Unit.Code AND dbo.Detalis_FirstStoreItem.Compny_Code = dbo.BD_Unit.Compny_Code ON  " & _
"            dbo.BD_Item.Compny_Code = dbo.Detalis_FirstStoreItem.Compny_Code And dbo.BD_Item.Code = dbo.Detalis_FirstStoreItem.NoItem " & _
" WHERE        (dbo.Detalis_FirstStoreItem.NumberBill = '" & VARCODE_AZN & "') AND (dbo.Detalis_FirstStoreItem.Compny_Code = '" & VarCodeCompny & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

     

        GridView1.Columns(0).Caption = "كود الصنف"
        GridView1.Columns(1).Caption = "أسم الصنف"

        GridView1.Columns(2).Caption = "الكمية"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "سعر الوحدة"
        GridView1.Columns(5).Caption = "الاجمالى"




        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        GridView1.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()


    End Sub





    Sub save_data()
        On Error Resume Next

        Dim varinvoicesss As Integer
        If Com_InvoiceNo.Text = "" Then varinvoicesss = 0 Else varinvoicesss = Com_InvoiceNo.Text
        sql2 = "select * from Hedar_FirstStoresItem where NumberBill  = '" & Trim(varinvoicesss) & "' and Flag_status =  '" & varflagstatus & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()
            'newInvoice()
        End If



        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_codestores.Text) = 0 Then MsgBox("من ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        '================================================== To date
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من ادخل  الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Price.Text) = 0 Then MsgBox("من ادخل  السعر ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub






        save_invoice_H()
        Fill_INVOICE2()

        'Total_Qty1()

    End Sub
    Sub genrat_Barcode()
        'Dim Varitem, varGM, VarG1, VarG2 As String

        sql = "  SELECT Code, CodeGroupItemMain, CodeGroupItem1, CodeGroupItem2  FROM BD_ITEM " & _
       " WHERE(Code = '" & txt_CodeItem.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Varitem = rs("Code").Value
            varGM = rs("CodeGroupItemMain").Value
            VarG1 = rs("CodeGroupItem1").Value
            VarG2 = rs("CodeGroupItem2").Value

            varNoBarcode = Varitem + varGM + VarG1 + VarG2
            varNoBarcode2 = varNoBarcode + varcountbarcode
        End If
    End Sub
    Sub save_itemStores() 'بضاعة اول المدة
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        sql = "   SELECT Unit1    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value
        '===================================================================
        '===================================الوحد 2
        'sql = "select * from BD_Unit where Name = '" & com_Unit2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit2 = rs("code").Value

        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Barcode_No,Code_Sub,TypeItem,Ser_Item,Line_Item,Ex_No,AccountNo_Stores,Ex_Item,FlagAzn,Compny_Code,Price_Unit) " & _
            " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & txt_CodeItem.Text & " ', '" & varcodunit & "','" & txt_codestores.Text & "','" & 0 & "' " & _
            " ,'" & vardateinvoice & "','" & "بضاعة اول المدة" + Com_InvoiceNo.Text & "','" & txt_Qty.Text & "','" & varNoBarcode2 & "','" & txt_CodeSub.Text & "','" & vartypeItem & "','" & varmaxser & "','" & varmaxline & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & xx & "','" & varflagazn & "','" & VarCodeCompny & "','" & txt_priccUnit.Text & "') "
        Cnn.Execute(sql)

    End Sub


    Sub save_itemStores2() 'اذن صرف من المخزن
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")


        '=====تحديد نوع المخزن
        'sql = "   SELECT Name, Code, Code_typeItem, Code_Sub  FROM BD_Stores  WHERE(Code = '" & txt_codestores.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then vartypeItem = rs("Code_typeItem").Value
        '=============================================================================== صرف من مخزن الفرع
        If com_typeSnd.Text = "تحويل فاتورة" Then varflagazn = 2
        If com_typeSnd.Text = "تحويل من المخازن" Then varflagazn = 1



        sql = "select * from BD_Unit where Name = '" & com_Unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value

        '===================================الوحد 2
        'sql = "select * from BD_Unit where Name = '" & com_Unit2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit2 = rs("code").Value

        'sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
        '    " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Barcode_No,Code_Sub,Ser_Item,Line_Item,Ex_No,AccountNo_Stores,Ex_Item,Price_Unit,PriceItem,FlagAzn,Compny_Code,Price_Unit,Count_Unit,Code_Unit2) " & _
        '    " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
        '    " ,'" & varcodeitem & " ', '" & varcodunit & "','" & txt_codestores.Text & "','" & 1 & "' " & _
        '    " ,'" & vardateinvoice & "','" & "صرف من " + " " + txt_namestores.Text + "   " + "الى  " + " " + txt_namestores2.Text & "','" & txt_Qty.Text & "','" & txt_Barcode.Text & "','" & txt_CodeSub.Text & "','" & varmaxser & "','" & varmaxline & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & txt_CodeItem.Text & "','" & txt_priccUnit.Text & "','" & txt_total.Text & "','" & varflagazn & "','" & VarCodeCompny & "','" & txt_priccUnit.Text & "','" & Txt_CountUnit.Text & "','" & varcodunit2 & "') "
        'Cnn.Execute(sql)

        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
    " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Barcode_No,Code_Sub,TypeItem,Ser_Item,Line_Item,Ex_No,AccountNo_Stores,Ex_Item,FlagAzn,Compny_Code,Price_Unit,Code_Unit2) " & _
    " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
    " ,'" & txt_CodeItem.Text & " ', '" & varcodunit & "','" & txt_codestores.Text & "','" & 0 & "' " & _
    " ,'" & vardateinvoice & "','" & "تحويل من " + " " + txt_namestores.Text + "   " + "الى  " + " " + txt_namestores2.Text & "','" & txt_Qty.Text & "','" & varNoBarcode2 & "','" & txt_CodeSub.Text & "','" & vartypeItem & "','" & varmaxser & "','" & varmaxline & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & xx & "','" & varflagazn & "','" & VarCodeCompny & "','" & txt_priccUnit.Text & "','" & varcodunit2 & "') "
        Cnn.Execute(sql)



        '=============================================================================اضافة الى مخزن اخر

        'sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
        '   " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Barcode_No,Code_Sub,Ser_Item,Line_Item,Price_Unit,PriceItem,Ex_No,AccountNo_Stores,Ex_Item,FlagAzn,Compny_Code,Price_Unit,Count_Unit,Code_Unit2) " & _
        '   " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
        '   " ,'" & varcodeitem & " ', '" & varcodunit & "','" & txt_codestores2.Text & "','" & 1 & "' " & _
        '   " ,'" & vardateinvoice & "','" & "صرف من " + txt_namestores.Text + "الى  " + txt_namestores2.Text & "','" & txt_Qty.Text & "','" & txt_Barcode.Text & "','" & 1 & "','" & varmaxser & "','" & varmaxline & "','" & txt_priccUnit.Text & "','" & txt_total.Text & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & txt_CodeItem.Text & "','" & varflagazn & "','" & VarCodeCompny & "','" & txt_priccUnit.Text & "','" & Txt_CountUnit.Text & "','" & varcodunit2 & "') "

        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
" ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Barcode_No,Code_Sub,TypeItem,Ser_Item,Line_Item,Ex_No,AccountNo_Stores,Ex_Item,FlagAzn,Compny_Code,Price_Unit,Code_Unit2) " & _
" values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
" ,'" & txt_CodeItem.Text & " ', '" & varcodunit & "','" & txt_codestores2.Text & "','" & 1 & "' " & _
" ,'" & vardateinvoice & "','" & "تحويل من  " + " " + txt_namestores.Text + "   " + "الى  " + " " + txt_namestores2.Text & "','" & txt_Qty.Text & "','" & varNoBarcode2 & "','" & txt_CodeSub.Text & "','" & vartypeItem & "','" & varmaxser & "','" & varmaxline & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & xx & "','" & varflagazn & "','" & VarCodeCompny & "','" & txt_priccUnit.Text & "','" & varcodunit2 & "') "


        Cnn.Execute(sql)

    End Sub
    Sub save_itemStores3() 'اذن صرف من المخزن
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")


        '=====تحديد نوع المخزن
        'sql = "   SELECT Name, Code, Code_typeItem, Code_Sub  FROM Stores  WHERE(Code = '" & txt_codestores.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then vartypeItem = rs("Code_typeItem").Value
        '=============================================================================== صرف من مخزن الفرع
        If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagazn = 2
        If com_typeSnd.Text = "تحويل من المخازن" Then varflagazn = 1


        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Import,Barcode_No,Code_Sub,Ser_Item,Line_Item,Ex_No,AccountNo_Stores,Ex_Item,Price_Unit,PriceItem,FlagAzn,Compny_Code) " & _
            " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & varcodeitem & " ', '" & 1 & "','" & txt_codestores.Text & "','" & 10 & "' " & _
            " ,'" & vardateinvoice & "','" & "صرف من " + txt_namestores.Text & "','" & txt_Qty.Text & "','" & txt_Barcode.Text & "','" & txt_CodeSub.Text & "','" & varmaxser & "','" & varmaxline & "','" & Com_InvoiceNo2.Text & "','" & varSubStores & "','" & txt_CodeItem.Text & "','" & txt_Price.Text & "','" & txt_total.Text & "','" & varflagazn & "','" & VarCodeCompny & "') "
        Cnn.Execute(sql)




    End Sub
    Sub save_invoice_H()
        'On Error Resume Next
        'Dim x As String
        'Dim vardiscountmax As Integer
        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        '============================MaxDiscount Condation
        'For x As Integer = 0 To GridView1.RowCount - 1

        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        sql = "select * from Hedar_FirstStoresItem where NumberBill  = " & Com_InvoiceNo.Text & " and Code_Sub ='" & txt_CodeSub.Text & "' and Flag_status='" & varflagstatus & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            '    sql = "UPDATE  BillBrchsesHder  SET NumberBill = '" & vardateinvoice & "',AccountNumberSu ='" & txt_AccountNo.Text & "' WHERE NumberBill = " & Com_InvoiceNo.Text & " "
            '    rs = Cnn.Execute(sql)
        Else




            If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagazn = 2
            If com_typeSnd.Text = "تحويل من المخازن" Then varflagazn = 1

            If com_typeSnd.Text = "بضاعة اول المدة" Then varflagazn = 0


            'AccountNo_Customer
            If varflagazn = 0 Or varflagazn = 1 Then
                sql = "INSERT INTO Hedar_FirstStoresItem (NumberBill, Code_Sub,Co_ID,NumYear,DateBill,Sat,Hid,DisHdaer,Code_Stores,Flag_status,Ex_No,FlagAzn,Code_Stores2,Status_AznSarf,Compny_Code) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & txt_CodeSub.Text & "','" & 1 & "','" & 1 & "','" & vardateinvoice & "','0','0','" & txt_Notes.Text & "','" & txt_codestores.Text & "','" & varflagstatus & "','" & Com_InvoiceNo2.Text & "','" & varflagazn & "','" & txt_codestores2.Text & "','" & varflagazn & "','" & VarCodeCompny & "' )"
                Cnn.Execute(sql)
            End If
            If varflagazn = 2 Then
                sql = "INSERT INTO Hedar_FirstStoresItem (NumberBill, Code_Sub,Co_ID,NumYear,DateBill,Sat,Hid,DisHdaer,Code_Stores,Flag_status,Ex_No,FlagAzn,Code_Stores2,AccountNo_Customer,Status_AznSarf,Compny_Code) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & txt_CodeSub.Text & "','" & 1 & "','" & 1 & "','" & vardateinvoice & "','0','0','" & txt_Notes.Text & "','" & txt_codestores.Text & "','" & varflagstatus & "','" & Com_InvoiceNo2.Text & "','" & varflagazn & "','" & txt_codestores2.Text & "','" & txt_AccountNo.Text & "','" & varflagazn & "','" & VarCodeCompny & "' )"
                Cnn.Execute(sql)
            End If



        End If
        'Next
        save_invoice_D()

    End Sub
    Sub save_invoice_D()
        'On Error Resume Next
        If varflagstatus = 0 Then
            'last_SerBarcode() 'اخر رقم للصنف للباركود
            'genrat_Barcode() 'انشاء الباركود
        End If
        lastser_item()

        Ser_item()
        If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagazn = 2
        If com_typeSnd.Text = "تحويل من المخازن" Then varflagazn = 1

        If com_typeSnd.Text = "بضاعة اول المدة" Then varflagazn = 0

        '============================================================ وحدة البيع
        sql = "   SELECT Unit1, Code    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value : varcodeitem = rs("code").Value



        vartotalitem = Val(txt_priccUnit.Text) * Val(txt_Qty.Text) 'الاجمالى الصنف 


        If varflagstatus = 1 Then

            '==========================================الوحدات

            'sql = "select * from BD_Unit where Name = '" & com_Unit2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            'rs = Cnn.Execute(sql)
            'If rs.EOF = False Then varcodunit2 = rs("code").Value
            '=================
            sql = "select * from BD_Unit where Name = '" & com_Unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit = rs("code").Value


            sql = "INSERT INTO Detalis_FirstStoreItem (NumberBill,Code_Sub,Co_ID,NumYear,NoItem,CodeUnit,Quntity,Barcode,No_ser_Barcode,Flag_status,price,AccountNo_Stores,Ex_NumberBill,FlagAzn,Ser_Item,Line_Item,Ex_Item,Compny_Code,Total_Item,CodeUnit2) " & _
                  " values  ('" & Com_InvoiceNo.Text & "' ,'" & txt_CodeSub.Text & "','" & 1 & "','" & 1 & "','" & txt_CodeItem.Text & "','" & varcodunit & "','" & txt_Qty.Text & "','" & varNoBarcode2 & "','" & varcountbarcode & "','" & varflagstatus & "','" & txt_priccUnit.Text & "','" & varSubStores & "','" & Com_InvoiceNo2.Text & "','" & varflagazn & "','" & varmaxser & "','" & varmaxline & "' ,'" & txt_CodeItem.Text & "','" & VarCodeCompny & "','" & vartotalitem & "','" & varcodunit2 & "')"
            Cnn.Execute(sql)
        End If

        If varflagstatus = 2 Then
            sql = "INSERT INTO Detalis_FirstStoreItem (NumberBill,Code_Sub,Co_ID,NumYear,NoItem,CodeUnit,Quntity,Barcode,No_ser_Barcode,Flag_status,price,AccountNo_Stores,Ex_NumberBill,FlagAzn,Ser_Item,Line_Item,Ex_Item,Compny_Code,Total_Item,CodeUnit2) " & _
                 " values  ('" & Com_InvoiceNo.Text & "' ,'" & txt_CodeSub.Text & "','" & 1 & "','" & 1 & "','" & txt_CodeItem.Text & "','" & varcodunit & "','" & txt_Qty.Text & "','" & varNoBarcode2 & "','" & varcountbarcode & "','" & varflagstatus & "','" & txt_priccUnit.Text & "','" & varSubStores & "','" & Com_InvoiceNo2.Text & "','" & varflagazn & "','" & varmaxser & "','" & varmaxline & "' ,'" & txt_CodeItem.Text & "','" & VarCodeCompny & "','" & vartotalitem & "','" & varcodunit2 & "')"
            Cnn.Execute(sql)
        End If

        If varflagstatus = 0 Then

            ''==========================================الوحدات
            'sql = "select * from BD_Unit where Name = '" & com_Unit2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            'rs = Cnn.Execute(sql)
            'If rs.EOF = False Then varcodunit2 = rs("code").Value
            '=================
            sql = "select * from BD_Unit where Name = '" & com_Unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit = rs("code").Value


            sql = "INSERT INTO Detalis_FirstStoreItem (NumberBill,Code_Sub,Co_ID,NumYear,NoItem,CodeUnit,Quntity,No_ser_Barcode,Flag_status,price,Ex_NumberBill,FlagAzn,Ser_Item,Line_Item,Ex_Item,Compny_Code,Total_Item,CodeUnit2) " & _
                  " values  ('" & Com_InvoiceNo.Text & "' ,'" & txt_CodeSub.Text & "','" & 1 & "','" & 1 & "','" & txt_CodeItem.Text & "','" & varcodunit & "','" & txt_Qty.Text & "','" & varcountbarcode & "','" & varflagstatus & "','" & txt_priccUnit.Text & "','" & Com_InvoiceNo2.Text & "','" & varflagazn & "','" & varmaxser & "','" & varmaxline & "','" & VarItem_EX & "','" & VarCodeCompny & "','" & vartotalitem & "','" & varcodunit2 & "')"
            Cnn.Execute(sql)
            'End If
            'varmaxline()
            'varmaxser()
        End If

        If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagazn = 2 : varflagstatus = 2
        If com_typeSnd.Text = "تحويل من المخازن" Then varflagazn = 1 : varflagstatus = 1
        If com_typeSnd.Text = "بضاعة اول المدة" Then varflagazn = 0 : varflagstatus = 0



        If varflagstatus = 0 Then save_itemStores() 'بضاعة اول المدة
        If varflagstatus = 1 Then save_itemStores2() 'تحويل الى مخزن اخر عن طريق الصرف من المخزن
        If varflagstatus = 2 Then save_itemStores3() ' الصرف من المخزن


        txt_Qty.Text = ""


        '====================================================
        'MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "basicwork  Solution Software Module")
    End Sub
    Sub lastser_item()
        'sql = " SELECT     NumberBill, MAX(Ser_Count) AS MaxSer_Count, NoItem ,Flag_status  FROM Detalis_FirstStoreItem GROUP BY NumberBill, NoItem,Flag_status,code_sub HAVING     (NumberBill = '" & Com_InvoiceNo.Text & "') AND (NoItem = '" & txt_CodeItem.Text & "')  and Flag_status ='" & varflagstatus & "' and code_sub ='" & varcodesub & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        '    varmaxcount = rs("MaxSer_Count").Value + 1
        'Else
        '    varmaxcount = 1
        '    'clear()

        'End If
    End Sub
    Sub clear_data()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""

    End Sub


    Sub find_Availebl()
        On Error Resume Next
        'If com_Unit.Text <> "" Then
        sql = "  SELECT        dbo.Statement_OfItem.Compny_Code, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance, dbo.Statement_OfItem.NoItem, dbo.BD_Unit.Name  , dbo.Statement_OfItem.Code_Stores " & _
" FROM            dbo.Statement_OfItem INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
" GROUP BY dbo.Statement_OfItem.Compny_Code, dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.Code_Unit, dbo.BD_Unit.Name, dbo.Statement_OfItem.Code_Stores " & _
" HAVING        (dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Statement_OfItem.NoItem = '" & txt_CodeItem.Text & "') and (dbo.Statement_OfItem.Code_Stores = '" & txt_codestores.Text & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            txt_QtyAvalabil.Text = Math.Round(rs("Balance").Value, 2)

        Else
            txt_QtyAvalabil.Text = "0"
        End If


        'End If

    End Sub








    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        varcode_form = 0
        VARTBNAME2 = ""
        VARTBNAME2 = "BD_Stores"
        varcode_form = 7
        Frm_LookUpAccount.Fill_Stores()
        Frm_LookUpAccount.ShowDialog()
        clear_data()
    End Sub




    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        'clear()
        VARTBNAME = "Vw_LookUp_FirstItem"
        varcode_form = 9


        'If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagstatus = 2
        'If com_typeSnd.Text = "تحويل من المخازن" Then varflagstatus = 1

        If com_typeSnd.Text = "بضاعة اول المدة" Then varflagstatus = 0

        Frm_LookUpAccount.Fill_NoAzn()
        Frm_LookUpAccount.ShowDialog()
        txt_CodeSub.Text = varcodesub
        txt_NameSub.Text = VarNameSub

        Fill_INVOICE2()

        'GridView1.AlwaysVisible = False
        sum_total()
        cmd_Delete.Enabled = True
        'Cmd_Save.Enabled = False
        Cmd_Update.Enabled = True

        'Total_All()
        'Total_Qty1()
        'Fill_InvoiceNew()
        'Fill_Data()
        find_gridItem()
    End Sub



    Private Sub txt_Price_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Price.KeyDown
        If e.KeyCode = Keys.Enter Then
            If varflagstatus = 0 Then
                last_SerBarcode()
                genrat_Barcode()
            End If

            save_data()
            txt_Qty.Text = ""
            txt_Price.Text = ""
            txt_Qty.TabIndex = 0
            'Total_All()
            'Total_Qty1()
        End If
    End Sub



    Private Sub txt_Price_TextChanged(sender As Object, e As EventArgs) Handles txt_Price.TextChanged
        txt_total.Text = Val(txt_Qty.Text) * Val(txt_Price.Text)
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        On Error Resume Next
        'Dim ro, mt As Integer


        'ro = GridView1.CurrentRow.Index
        'mt = ro
        'txt_NameItem.Text = DataGridView2.Item(1, mt).Value
        'txt_Qty.Text = DataGridView2.Item(3, mt).Value
        ''===============================================رقم السطر
        'varmaxser = DataGridView2.Item(8, mt).Value
        ''=======================================================
        'If varflagstatus = 1 Or varflagstatus = 2 Then
        '    sql = "  SELECT *       FROM BD_ITEM   WHERE(Code = '" & DataGridView2.Item(0, mt).Value & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then txt_CodeItem.Text = rs("Ex_Item").Value
        'Else
        '    txt_CodeItem.Text = DataGridView2.Item(0, mt).Value

        'End If

        find_Availebl()
    End Sub





    Private Sub ButtonX6_Click(sender As Object, e As EventArgs)
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Detalis_FirstStoreItem  WHERE NoItem = " & txt_CodeItem.Text & " and Code_Sub ='" & varcodesub & "' and Flag_status = '" & varflagstatus & "'  "
                rs = Cnn.Execute(sql)

                If varflagstatus = 0 Then
                    sql = "Delete Statement_OfItem  WHERE NoItem = " & txt_CodeItem.Text & "  and Code_Sub ='" & varcodesub & "' and  (TypeD = 0) AND (NumberBill = '" & Com_InvoiceNo.Text & "')  "
                    rs = Cnn.Execute(sql)
                End If

                If varflagstatus = 1 Then
                    sql = "Delete Statement_OfItem  WHERE NoItem = " & txt_CodeItem.Text & "  and Code_Sub ='" & varcodesub & "' and  (TypeD = '1') AND (NumberBill = '" & Com_InvoiceNo.Text & "')  "
                    rs = Cnn.Execute(sql)
                End If

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

                Fill_INVOICE2()

                'varflagstatus = 0
        End Select
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'Report_FirstItem.Show()
        'Frm_Report_FristItem.Show()
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub Com_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Type.SelectedIndexChanged
        If com_typeSnd.Text = "تحويل من المخازن" Then LabelX13.Visible = True : txt_namestores2.Visible = True : txt_codestores2.Visible = True : Cmd_LookUpStores.Visible = True : varflagazn = 1
        If com_typeSnd.Text = "اذن صرف من المخزن" Then LabelX13.Visible = False : txt_namestores2.Visible = False : txt_codestores2.Visible = False : Cmd_LookUpStores.Visible = False : varflagazn = 2

    End Sub

    Private Sub Cmd_LookUpStores_Click(sender As Object, e As EventArgs) Handles Cmd_LookUpStores.Click
        VARTBNAME2 = ""
        VARTBNAME2 = "BD_Stores"
        varcode_form = 17
        Frm_LookUpAccount.Fill_Alldata()
        Frm_LookUpAccount.ShowDialog()
        clear_data()
    End Sub

    Private Sub txt_CodeItem_TextChanged(sender As Object, e As EventArgs) Handles txt_CodeItem.TextChanged
        find_Availebl()
    End Sub
    Sub Ser_item()



        If varflagstatus = 0 Then sql = " SELECT     NumberBill, MAX(Line_Item) AS MaxLine_Item, NoItem, Ex_Item,FlagAzn   FROM Detalis_FirstStoreItem GROUP BY NumberBill, NoItem, Ex_Item,FlagAzn HAVING     (NumberBill = '" & Com_InvoiceNo.Text & "') AND (NoItem = '" & txt_CodeItem.Text & "')  and FlagAzn ='" & varflagstatus & "' "
        If varflagstatus <> 0 Then sql = " SELECT     NumberBill, MAX(Line_Item) AS MaxLine_Item, NoItem, Ex_Item,FlagAzn   FROM Detalis_FirstStoreItem GROUP BY NumberBill, NoItem, Ex_Item,FlagAzn HAVING     (NumberBill = '" & Com_InvoiceNo.Text & "') AND (Ex_Item = '" & txt_CodeItem.Text & "')  and FlagAzn ='" & varflagstatus & "' "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            If varmaxcount = 6 Or varmaxcount = 11 Or varmaxcount = 16 Or varmaxcount = 21 Or varmaxcount = 26 Or varmaxcount = 31 Then varmaxline = rs("MaxLine_Item").Value + 1 Else varmaxline = rs("MaxLine_Item").Value

        Else
            varmaxline = 1
            'clear()

        End If




        If varflagstatus = 0 Then sql = " SELECT     NumberBill, MAX(Ser_Item) AS MaxSer_Item, Ex_Item,FlagAzn,NoItem   FROM Detalis_FirstStoreItem GROUP BY NumberBill, Ex_Item,Line_Item,FlagAzn,NoItem HAVING     (NumberBill = '" & Com_InvoiceNo.Text & "') AND (NoItem = '" & txt_CodeItem.Text & "') and Line_Item ='" & varmaxline & "' and FlagAzn ='" & varflagstatus & "'  "
        If varflagstatus <> 0 Then sql = " SELECT     NumberBill, MAX(Ser_Item) AS MaxSer_Item, Ex_Item,FlagAzn,NoItem   FROM Detalis_FirstStoreItem GROUP BY NumberBill, Ex_Item,Line_Item,FlagAzn,NoItem HAVING     (NumberBill = '" & Com_InvoiceNo.Text & "') AND (Ex_Item = '" & txt_CodeItem.Text & "') and Line_Item ='" & varmaxline & "' and FlagAzn ='" & varflagstatus & "'  "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varmaxser = rs("MaxSer_Item").Value + 1
        Else
            varmaxser = 1
            'clear()

        End If
    End Sub
    Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        'On Error Resume Next



        If varflagazn = 1 And txt_codestores2.Text = "" Then MsgBox("من فضلك اختار المخزن المحول الية", MsgBoxStyle.Critical, "Css") : Exit Sub

        sql = "select * from Detalis_FirstStoreItem where NumberBill = '" & Com_InvoiceNo.Text & "' and NoItem = '" & txt_CodeItem.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("هذا العنصر مسجل مسبقا ", MsgBoxStyle.Critical, "Css") : Exit Sub
        last_SerBarcode()
        genrat_Barcode()




        'If varflagstatus = 1 Then
        '    If Val(txt_Qty.Text) > Val(txt_QtyAvalabil.Text) Then MsgBox("من فضلك  ادخل كمية اقل او تساوى  الكمية المتاحة " + " " + " " + txt_namestores.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "css Solution Software Module") : Exit Sub
        '    sql = "select * from Detalis_FirstStoreItem where NumberBill = '" & Com_InvoiceNo.Text & "' and NoItem = '" & txt_CodeItem.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then MsgBox("هذا العنصر مسجل مسبقا ", MsgBoxStyle.Critical, "Css") : Exit Sub
        '    save_data()
        '    find_Availebl()
        'End If

        'If varflagstatus = 2 Then
        '    If Val(txt_Qty.Text) > Val(txt_QtyAvalabil.Text) Then MsgBox("من فضلك  ادخل كمية اقل او تساوى  الكمية المتاحة " + " " + " " + txt_namestores.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "css Solution Software Module") : Exit Sub

        'End If

        'If varflagstatus = 2 And txt_AccountNo.Text = "" Then MsgBox("من فضلك  ادخل العميل  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "css Solution Software Module") : Exit Sub

        'find_Availebl()
        save_data()
        clear_line()
        txt_Qty.Text = ""
        txt_Price.Text = ""
        txt_Qty.TabIndex = 0
        'Total_All()
        'Total_Qty1()
    End Sub

   

    Private Sub ButtonX4_Click_1(sender As Object, e As EventArgs) Handles ButtonX4.Click
        'If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSub.Text) = 0 Then MsgBox("من فضلك ادخل الفرع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_codestores.Text) = 0 Then MsgBox("من ادخل  فضلك المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        clear_data()
        varcodestores = txt_codestores.Text
        If varflagstatus = 0 Then
            VARTBNAME = "Vw_AllDataItem"
            varcode_form = 19
            Lookupitem.Text = "بحث"
            Lookupitem.ShowDialog()
        End If

        If varflagstatus = 1 Then


            VARTBNAME = "Vw_AllDataItem"
            varcode_form = 19
            Lookupitem.Text = "بحث"
            Lookupitem.ShowDialog()
        End If


        If varflagstatus = 2 Then

            VARTBNAME = "Vw_AllDataItem"
            varcode_form = 19
            Lookupitem.Text = "بحث"
            Lookupitem.ShowDialog()
            find_Availebl()
        End If

        find_Availebl()
        txt_Qty.Select()
    End Sub

    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        If com_typeSnd.Text = "اذن صرف من المخزن" Then varflagstatus = 2
        If com_typeSnd.Text = "تحويل من المخازن" Then varflagstatus = 1

        If com_typeSnd.Text = "بضاعة اول المدة" Then varflagstatus = 0


        If varflagstatus <> 0 Then sql = "UPDATE  Detalis_FirstStoreItem  SET Quntity = '" & txt_Qty.Text & "',Price = '" & txt_priccUnit.Text & "',Total_Item = '" & txt_TotalAll.Text & "'  WHERE  NoItem = '" & txt_CodeItem.Text & "' and  NumberBill = '" & Com_InvoiceNo.Text & "'  and FlagAzn = '" & varflagstatus & "'  "
        If varflagstatus = 0 Then sql = "UPDATE  Detalis_FirstStoreItem  SET Quntity = '" & txt_Qty.Text & "',Price = '" & txt_priccUnit.Text & "',Total_Item = '" & txt_TotalAll.Text & "'  WHERE NoItem = '" & txt_CodeItem.Text & "'  and NumberBill = '" & Com_InvoiceNo.Text & "'  and FlagAzn = '" & varflagstatus & "' "
        rs = Cnn.Execute(sql)


        '===========================================

        If varflagstatus = 1 Then
            If Val(txt_Qty.Text) > Val(txt_QtyAvalabil.Text) Then MsgBox("من فضلك  ادخل كمية اقل او تساوى  الكمية المتاحة " + " " + " " + txt_namestores.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "css Solution Software Module") : Exit Sub
            save_data()
            find_Availebl()
            txt_Qty.Text = ""
            txt_Price.Text = ""
            txt_Qty.TabIndex = 0
            'Total_All()
            'Total_Qty1()
        End If

        sql = "select * from BD_Unit where Name = '" & com_Unit.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value



        If varflagstatus = 0 Then sql = "UPDATE  Statement_OfItem  SET Code_Unit ='" & varcodunit & "', Export = '" & txt_Qty.Text & "',Price_Unit = '" & txt_priccUnit.Text & "',Import = '" & 0 & "' WHERE NoItem = '" & txt_CodeItem.Text & "' and  NumberBill = '" & Com_InvoiceNo.Text & "' and TypeD ='0'  "

        If varflagstatus = 2 Then sql = "UPDATE  Statement_OfItem  SET Code_Unit ='" & varcodunit & "', Export = '" & 0 & "',Price_Unit = '" & txt_priccUnit.Text & "',Import = '" & txt_Qty.Text & "' WHERE NoItem = '" & txt_CodeItem.Text & "'  and NumberBill = '" & Com_InvoiceNo.Text & "' and TypeD ='10'  "
        rs = Cnn.Execute(sql)
        Fill_INVOICE2()
        find_Availebl()
        MsgBox("تم التعديل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "CSS Solution Software Module")

    End Sub

    Private Sub Com_InvoiceNo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_InvoiceNo.SelectedIndexChanged

    End Sub

    Private Sub cmd_Lookup1_Click(sender As Object, e As EventArgs) Handles cmd_Lookup1.Click

        'VARTBNAME2 = ""
        'VARTBNAME2 = "FindCustomer"
        'varcode_form = 49
        varcode_form = 49
        Frm_LookUpAccount.Fill_Customer()
        Frm_LookUpAccount.ShowDialog()
    End Sub



    Private Sub DataGridView2_CellDoubleClick1(sender As Object, e As DataGridViewCellEventArgs)
        ''On Error Resume Next
        ''Dim ro, mt As Integer
        ''clear_data()

        ''ro = DataGridView2.CurrentRow.Index
        ''mt = ro



        ''txt_NameItem.Text = DataGridView2.Item(1, mt).Value
        ''txt_Qty.Text = DataGridView2.Item(3, mt).Value
        ''varmaxser = DataGridView2.Item(5, mt).Value

        'find_Availebl()


        'sql = "   SELECT  Ex_Item    FROM BD_ITEM    WHERE(code = '" & DataGridView2.Item(0, mt).Value & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_CodeItem.Text = Trim(rs("Ex_Item").Value)


        '=================================حذف السطر اولا
        'If Com_Type.Text = "اذن صرف من المخزن" Then varflagstatus = 2
        'If Com_Type.Text = "تحويل من المخازن" Then varflagstatus = 1


        If varflagstatus = 1 Then
            '    sql = "Delete Detalis_FirstStoreItem  WHERE Ex_Item = '" & Trim(txt_CodeItem.Text) & "' and Code_Sub ='" & varcodesub & "' and Flag_status = '" & varflagstatus & "' and Ser_Item ='" & varmaxser & "'"
            '    rs = Cnn.Execute(sql)
            '    sql = "Delete Statement_OfItem  WHERE Ex_Item = '" & txt_CodeItem.Text & "'  and Code_Sub ='" & varcodesub & "' and  (TypeD = '1') AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and Ser_Item ='" & varmaxser & "' and FlagAzn ='" & 1 & "' "
            '    rs = Cnn.Execute(sql)
            '    '=====================================================
            '    find_Availebl()
            '    Fill_INVOICE2()
            Cmd_Update.Enabled = False
        End If
    End Sub

    Private Sub com_Unit_GotFocus(sender As Object, e As EventArgs) Handles com_Unit.GotFocus
        fill_Unit2()
    End Sub
    Sub fill_Unit2()
        'If Com_NameItem.Text = "" Then MsgBox("أختار الصنف من فضلك", MsgBoxStyle.Critical) : Exit Sub
        sql = "   SELECT *    FROM BD_Item   WHERE(Name = '" & txt_NameItem.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '==================================================

        com_Unit.Items.Clear()

        sql = " SELECT Name FROM     vw_AllUnit where  code ='" & varcodeitem & "'   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub com_Unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Unit.SelectedIndexChanged
        pric_item()
        find_Availebl()
    End Sub
    Sub pric_item()
        'sql = "   SELECT      *  FROM dbo.Vw_ItemPrice WHERE        (Code = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') AND (Unit = '" & com_Unit.Text & "' )"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_priccUnit.Text = rs("PriceUnit").Value

    End Sub

    Private Sub cmd_Delete_Click_1(sender As Object, e As EventArgs) Handles cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                If varflagstatus = 0 Then sql = "Delete Detalis_FirstStoreItem  WHERE NoItem = '" & txt_CodeItem.Text & "'  and Flag_status = '" & varflagstatus & "' and Compny_Code='" & VarCodeCompny & "'  "
                If varflagstatus <> 0 Then sql = "Delete Detalis_FirstStoreItem  WHERE NoItem = '" & Trim(txt_CodeItem.Text) & "'  and Flag_status = '" & varflagstatus & "'  and Compny_Code='" & VarCodeCompny & "'   "

                rs = Cnn.Execute(sql)

                If varflagstatus = 0 Then
                    sql = "Delete Statement_OfItem  WHERE NoItem = '" & txt_CodeItem.Text & "' and  (TypeD = 0) AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and Compny_Code='" & VarCodeCompny & "' and FlagAzn ='" & 0 & "'    "
                    rs = Cnn.Execute(sql)
                    clear_line()
                End If

                If varflagstatus = 1 Then
                    sql = "Delete Statement_OfItem  WHERE NoItem = '" & txt_CodeItem.Text & "'  and  (TypeD = '1') AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and FlagAzn ='" & 1 & "' "
                    rs = Cnn.Execute(sql)
                    Cmd_Update.Enabled = True
                End If

                'If varflagstatus = 2 Then
                '    sql = "Delete Statement_OfItem  WHERE Ex_Item = '" & txt_CodeItem.Text & "'  and Code_Sub ='" & varcodesub & "' and  (TypeD = '10') AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and Ser_Item ='" & varmaxser & "' and FlagAzn ='" & 2 & "' "
                '    rs = Cnn.Execute(sql)
                'End If

                Fill_INVOICE2()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_Availebl()
                'Fill_INVOICE2()

                'varflagstatus = 0
        End Select
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        varcodeitem = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        com_Unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        txt_priccUnit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))



    End Sub

    

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        On Error Resume Next


        'sql = "Delete Tb_BarcodePrint  WHERE  Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)

        ''For i = 0 To DataGridView2.RowCount - 1
        'Dim result As Integer = 0
        'For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


        '    '===========================================بيانات الصنف
        '    'If DataGridView2.Item(0, i).Value = "" Then Exit Sub
        '    sql = "   SELECT  *    FROM dbo.BD_Item    WHERE(code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then varGroup1 = Trim(rs("CodeGroupItemMain").Value) : varbarcode = Trim(rs("Barcode_No").Value)
        '    '=========================================================================================



        '    varcountbarcode = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2)))

        '    For w = 0 To varcountbarcode - 1

        '        sql = "INSERT INTO Tb_BarcodePrint (Number_Azn, Code_Item,Barcode_No,Code_Group1,Compny_Code) " & _
        '           " values  ('" & Com_InvoiceNo.Text & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & varbarcode & "','" & varGroup1 & "','" & VarCodeCompny & "')"
        '        Cnn.Execute(sql)

        '    Next

        'Next rowHandle
        'Frm_printBarcode.Show()

        'On Error Resume Next
        '=============================حذف جدول Barcode
        sql = "Delete Tb_BarcodePrint "
        rs = Cnn.Execute(sql)
        '=====================================================




        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


            '=========================================الصنف
            Dim i
            sql = "   SELECT  *    FROM dbo.BD_ITEM    WHERE(code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varprice2 = Trim(rs("PriceSal").Value) : varGroup1 = Trim(rs("CodeGroupItemMain").Value) : varbarcode = Trim(rs("Barcode_No").Value)
            '=========================================================================

            varcountbarcode = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2)))
            'i = 1
            For w = 0 To varcountbarcode - 1


                sql = "INSERT INTO Tb_BarcodePrint (Number_Azn, Code_Item,Barcode_No,Price,Code_Group1) " & _
             " values  ('" & Com_InvoiceNo.Text & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & varbarcode & "','" & varprice2 & "','" & varGroup1 & "')"
                Cnn.Execute(sql)
                'i = i + 1
            Next


        Next rowHandle


        Frm_printBarcode.Close()
        'Frm_PrintBarcode.MdiParent = Mainmune
        Frm_printBarcode.Show()
    End Sub

    Private Sub clear_line()
        On Error Resume Next
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
  
        txt_Qty.Text = ""
        com_Unit.Text = ""
        txt_priccUnit.Text = ""
    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))

        txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        com_Unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        txt_priccUnit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        If txt_CodeItem.Text <> "" Then
            cmd_Delete.Enabled = True
            'Cmd_Save.Enabled = False
            Cmd_Update.Enabled = True
        End If
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

        x = MsgBox("هل تريد حذف الاذن", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()

        'Dim sql = "select * from TB_Header_OrderItem where No_PriceList = " & Com_InvoiceNo.Text & ""
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'Dim dt = ds.Tables(0)
        'MsgBox("عدد النتائج هو :" & dt.Rows.Count, MsgBoxStyle.Critical, "خطا")

        'If dt.Rows.Count <> 0 Then
        '    MsgBox("لا يمكن حذف عرض السعر لانه مستخدم فى امر توريد", MsgBoxStyle.Critical, "خطا")
        '    Exit Sub
        'End If




        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Detalis_FirstStoreItem  where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '===================================حذف من المخزن
                sql = "Delete Hedar_FirstStoresItem   where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)


                If varflagstatus = 0 Then
                    sql = "Delete Statement_OfItem  WHERE  (TypeD = '" & varflagstatus & "') AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and FlagAzn ='" & 0 & "' "
                    rs = Cnn.Execute(sql)
                End If
                MsgBox("تم حذف الاذن", MsgBoxStyle.Information, "Css Solution Software Module")

        End Select
        find_gridItem()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Frm_GardItem2.txt_codeItem.Text = txt_CodeItem.Text
        Frm_GardItem2.txt_NameItem.Text = txt_NameItem.Text
        Frm_GardItem2.FindBalance()
        Frm_GardItem2.Com_Stores.Text = txt_namestores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub txt_priccUnit_TextChanged(sender As Object, e As EventArgs) Handles txt_priccUnit.TextChanged
        On Error Resume Next
        txt_TotalAll.Text = Math.Round(Val(txt_Qty.Text) * Val(txt_priccUnit.Text), 2)
    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs) Handles txt_Qty.TextChanged
        txt_TotalAll.Text = Math.Round(Val(txt_Qty.Text) * Val(txt_priccUnit.Text), 2)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & Com_InvoiceNo.Text & "' and TypeD =0  "
        rs = Cnn.Execute(sql)
        '==============================================================================================================
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Dim varcodunit2 As Integer
            '=======================================================
            var_codeItem = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0)))
            sql = "   SELECT *    FROM dbo.BD_Item    WHERE(Code = '" & var_codeItem & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit2 = rs("Unit1").Value : var_codeItem = rs("code").Value : var_codeItem22 = rs("Ex_Item").Value
            '===========================================================



            sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
    " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Compny_Code,Price_Unit) " & _
    " values (N'" & Com_InvoiceNo.Text & "',N'" & 1 & "',N'" & 1 & " ' " & _
    " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "', N'" & varcodunit & "',N'" & txt_codestores.Text & "',N'" & 0 & "' " & _
    " ,N'" & vardateinvoice & "',N'" & "بضاعة اول المدة" + Com_InvoiceNo.Text & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "',N'" & VarCodeCompny & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "') "
            Cnn.Execute(sql)


        Next rowHandle
        MsgBox("تم الحفظ  ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
    End Sub
End Class