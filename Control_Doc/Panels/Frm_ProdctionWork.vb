Imports System.Data.OleDb

Public Class Frm_ProdctionWork
    Dim varcodeshift As Integer
    Dim varcode_Orderstores, varcodeEmp, varcodeEmp2, varcodeUnitKilo2, varcodeUnitKilo_First, varflagorder As Integer
    Dim varcode_Orderstores2, varcodeExitem As String

    Private Sub Frm_ProdctionWork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Project()
        all_find()
    End Sub
    Sub all_find()
        sql2 = " SELECT dbo.TB_Header_JOB_Order.JOB_Order_Ser, dbo.TB_Header_JOB_Order.JOBOrder_Date, dbo.TB_Header_JOB_Order.Order_NO, dbo.BD_Item.Ex_Item AS RefNo, dbo.BD_Item.Name AS Discription, " & _
  "                 dbo.TB_Header_JOB_Order.Qyt_Requrid, dbo.BD_Unit.Name, iif(dbo.TB_Header_JOB_Order.Flg_JopOrder=0,'Open','Close') as Status " & _
 " FROM     dbo.TB_Header_JOB_Order INNER JOIN " & _
 "                  dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code INNER JOIN " & _
 "                  dbo.BD_Item ON dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView7.Columns(0).Caption = "PAO"
        GridView7.Columns(1).Caption = "Project Name"
        GridView7.Columns(2).Caption = "Customer Name"


        GridView7.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView7.Appearance.Row.Options.UseFont = True
        GridView7.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        GridView7.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'End If
    End Sub
    Sub fill_Project()

        sql2 = "SELECT LTRIM(dbo.TB_Header_OrderItem.PAO_NO) AS PAONO, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS ProjectName, dbo.ST_CHARTOFACCOUNT.AccountName AS CustomerNAme " & _
" FROM     dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
"                  dbo.TB_Header_PriceListCustomer ON dbo.ST_CHARTCOSTCENTER.Account_No = dbo.TB_Header_PriceListCustomer.Code_Project INNER JOIN " & _
"                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_PriceListCustomer.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No RIGHT OUTER JOIN " & _
"                  dbo.TB_Header_OrderItem ON dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Header_OrderItem.No_PriceList " & _
" GROUP BY dbo.TB_Header_OrderItem.PAO_NO, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTOFACCOUNT.AccountName "


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView4.Columns(0).Caption = "PAO"
        GridView4.Columns(1).Caption = "Project Name"
        GridView4.Columns(2).Caption = "Customer Name"


        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True
        GridView4.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'End If

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub
    Sub loadlistbox()
        'Dim Dir As String = "\\server\CSS2021"
        'Dim Dir1 As String = Dir + "\" + "UploadFiles"
        'Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
        'Dim x = Trim(VarPAO_NO2)
        'Dim Dir3 As String = Dir2 + "\" + x
        '' make a reference to a directory
        'Dim di As New IO.DirectoryInfo(Trim(Dir3))
        'Dim diar1 As IO.FileInfo() = di.GetFiles()
        'Dim dra As IO.FileInfo

        ''list the names of all files in the specified directory
        'ListBoxControl1.Items.Clear()
        'For Each dra In diar1
        '    ListBoxControl1.Items.Add(dra)
        'Next
    End Sub
    Sub find_Panal()
        On Error Resume Next

        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "    SELECT dbo.TB_Hader_Technical_Specifications.PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, dbo.TB_Hader_Technical_Specifications.PanelType " & _
" FROM     dbo.TB_Hader_Technical_Specifications INNER JOIN " & _
"                  dbo.TB_Detalis_PriceListCustomer ON dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.TB_Detalis_PriceListCustomer.Sub_Project AND  " & _
"                  dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.TB_Detalis_PriceListCustomer.Code_Project INNER JOIN " & _
"                  dbo.TB_Header_PriceListCustomer ON dbo.TB_Detalis_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo INNER JOIN " & _
"                  dbo.TB_Detils_OrderItem ON dbo.TB_Detalis_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Detils_OrderItem.no_pricelist " & _
" GROUP BY dbo.TB_Hader_Technical_Specifications.PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, dbo.TB_Hader_Technical_Specifications.CostCenter_account1, dbo.TB_Hader_Technical_Specifications.CostCenter_account2, " & _
"        dbo.TB_Header_PriceListCustomer.Invoice_Type, dbo.TB_Detils_OrderItem.PAO_NO, dbo.TB_Hader_Technical_Specifications.PanelType " & _
" HAVING (dbo.TB_Header_PriceListCustomer.Invoice_Type = 1) AND (dbo.TB_Detils_OrderItem.PAO_NO = '" & VarPAO_NO2 & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "PanelName"
        GridView3.Columns(1).Caption = "Quantity"
        GridView3.Columns(2).Caption = "PanelType"

        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView3.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick

        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        VarPAO_NO2 = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))

        find_Panal()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs)

    End Sub
    Sub find_Detils_Panal()
        On Error Resume Next

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "  SELECT dbo.TB_Detalis_Technical_Specifications.Categorize, dbo.TB_Detalis_Technical_Specifications.Ref_No, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name AS Brand, " & _
  "                  dbo.TB_Detalis_Technical_Specifications.Qty_Technical_Specifications AS Qty,iif( dbo.Vw_BalanceItem.BalanceItem is null,'0',Vw_BalanceItem.BalanceItem) as QtyBalance,iif(iif( dbo.Vw_BalanceItem.BalanceItem is null,'0',Vw_BalanceItem.BalanceItem)=0,'Not available','available') as stutas " & _
  "FROM     dbo.TB_Hader_Technical_Specifications INNER JOIN " & _
  "                  dbo.TB_Detalis_PriceListCustomer ON dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.TB_Detalis_PriceListCustomer.Sub_Project AND  " & _
  "                  dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.TB_Detalis_PriceListCustomer.Code_Project INNER JOIN " & _
  "                  dbo.TB_Header_PriceListCustomer ON dbo.TB_Detalis_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo INNER JOIN " & _
  "                  dbo.TB_Detils_OrderItem ON dbo.TB_Detalis_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Detils_OrderItem.no_pricelist INNER JOIN " & _
  "                  dbo.TB_Detalis_Technical_Specifications ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.TB_Detalis_Technical_Specifications.CostCenter_account1 AND  " & _
  "                  dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.TB_Detalis_Technical_Specifications.CostCenter_account2 INNER JOIN " & _
  "                  dbo.BD_Item ON dbo.TB_Detalis_Technical_Specifications.No_Item = dbo.BD_Item.Code INNER JOIN " & _
  "                  dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code LEFT OUTER JOIN " & _
  "                  dbo.Vw_BalanceItem ON dbo.TB_Detalis_Technical_Specifications.No_Item = dbo.Vw_BalanceItem.NoItem " & _
  " GROUP BY dbo.TB_Hader_Technical_Specifications.PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, dbo.TB_Hader_Technical_Specifications.CostCenter_account1, dbo.TB_Hader_Technical_Specifications.CostCenter_account2, " & _
  "        dbo.TB_Header_PriceListCustomer.Invoice_Type, dbo.TB_Detils_OrderItem.PAO_NO, dbo.TB_Hader_Technical_Specifications.PanelType, dbo.TB_Detalis_Technical_Specifications.Categorize, " & _
  "        dbo.TB_Detalis_Technical_Specifications.Ref_No, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.TB_Detalis_Technical_Specifications.Qty_Technical_Specifications, dbo.Vw_BalanceItem.BalanceItem " & _
  " HAVING (dbo.TB_Header_PriceListCustomer.Invoice_Type = 1) AND (dbo.TB_Detils_OrderItem.PAO_NO = '" & VarPAO_NO2 & "') AND (dbo.TB_Hader_Technical_Specifications.PanelName = '" & VarPanalName & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "Categorize"
        GridView1.Columns(1).Caption = "Ref_No"
        GridView1.Columns(2).Caption = "Name"
        GridView1.Columns(3).Caption = "Brand"
        GridView1.Columns(4).Caption = "Qty"
        GridView1.Columns(5).Caption = "BalanceItem"
        GridView1.Columns(6).Caption = "Status"

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub




    Private Sub ListBoxControl1_Click(sender As Object, e As EventArgs) Handles ListBoxControl1.Click
        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + "UploadFiles"
        Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
        Dim x = Trim(VarPAO_NO2)
        Dim Dir3 As String = Dir2 + "\" + x
        Dim Dir4 As String = Trim(Dir3) + "\" + ListBoxControl1.Text
        Me.PdfViewer1.LoadDocument(Dir4)
    End Sub

    Private Sub ListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl1.SelectedIndexChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        For x As Integer = 0 To GridView1.RowCount



            Dim ststus_Stores As String
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            'الكمية المتاحة المخزن
            '=======================================================================
            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(6))
            If ststus_Stores = "Not available" Then
                If e.Column.AbsoluteIndex = 6 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Red
                End If
            Else
                If e.Column.AbsoluteIndex = 6 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Green
                End If
            End If
            '======================================================================================


        Next x
    End Sub

    Private Sub GridControl2_Click_1(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        VarPanalName = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        loadlistbox()
        find_Detils_Panal()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_NewJobOrder.Click
        'If Len(txt_MachinName.Text) = 0 Then MsgBox("من فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        last_Data()
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(JOB_Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_JOB_Order    GROUP BY Compny_Code  HAVING        (MAX(JOB_Order_Ser) IS NOT NULL)   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            'Com_InvoiceNo2.Text = txt_MachinName.Text + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            'Com_InvoiceNo2.Text = txt_MachinName.Text + "1"


        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_RefNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        txt_Unit2.Text = "عدد"

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_JOB_Order where JOB_Order_Ser  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم أمر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()

        save_oderDetils()
        clear_detils()
        find_detalis()
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " SELECT RTRIM(dbo.BD_Item.Ex_Item) AS RefNo, dbo.BD_Item.Name AS NameItem, dbo.BD_GROUPITEMMAIN.Name AS Brand, dbo.TB_Detils_JOB_Order.Quntity_Matril, dbo.BD_Unit.Name, RTRIM(dbo.TB_Detils_JOB_Order.Ref_JOBOrder) AS PAO " & _
 " FROM     dbo.TB_Header_JOB_Order INNER JOIN " & _
 "                  dbo.TB_Detils_JOB_Order ON dbo.TB_Header_JOB_Order.JOB_Order_Ser = dbo.TB_Detils_JOB_Order.JOB_Order_Ser INNER JOIN " & _
 "                  dbo.BD_Unit ON dbo.TB_Detils_JOB_Order.Code_Unit = dbo.BD_Unit.Code INNER JOIN " & _
 "                  dbo.BD_Item ON dbo.TB_Detils_JOB_Order.No_Matril = dbo.BD_Item.Code INNER JOIN " & _
 "                  dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code " & _
 "        WHERE(dbo.TB_Detils_JOB_Order.JOB_Order_Ser = '" & Com_InvoiceNo.Text & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)


        GridView9.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "Ref No"
        GridView9.Columns(1).Caption = "Discription"
        GridView9.Columns(2).Caption = "Brand"
        GridView9.Columns(3).Caption = "Qty"
        GridView9.Columns(4).Caption = "Unit"
        GridView9.Columns(5).Caption = "PAO"

        GridView9.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Sub clear_detils()
        txt_RefNo.Text = ""
        txt_Qty.Text = ""
        txt_Unit2.Text = ""
        txt_QtyAvalibl.Text = ""
    End Sub
    Sub save_order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")



        sql = "select * from TB_Header_JOB_Order where JOB_Order_Ser  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then


        Else

            '====================================رقم الصنف
            Dim varcodeitem, varcodeitem2 As Integer
            sql = "    SELECT   *           FROM dbo.BD_ITEM WHERE  Name = '" & VarPanalName & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeitem = rs("code").Value
            '=============================

            '================================================= shift
            sql2 = "   SELECT        Name, Code FROM            dbo.Vw_Shift WHERE        (Name ='" & Trim(Com_Shift.Text) & "') AND (Compny_Code ='" & VarCodeCompny & "') "
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeshift = rs("Code").Value
            '==================================================================save hedar



            sql = "INSERT INTO TB_Header_JOB_Order (JOB_Order_Ser, Compny_Code,JOBOrder_Date,Order_NO,No_Item,Qyt_Requrid,Code_Unit) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & vardateoder & "','" & VarPAO_NO2 & "','" & varcodeitem & "','" & 1 & "','" & 2 & "')"
            Cnn.Execute(sql)



        End If
    End Sub

    Sub save_oderDetils()
        Dim varcode_Matril As Integer


        '============================Matril

        sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Ex_Item = '" & txt_RefNo.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Matril = Trim(rs("code").Value)

        '===============================stores\
        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value


        sql = "INSERT INTO TB_Detils_JOB_Order (JOB_Order_Ser,No_Matril,Quntity_Matril,Code_Unit,Compny_Code,Ref_JOBOrder) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & varcode_Matril & "','" & txt_Qty.Text & "','" & 2 & "','" & VarCodeCompny & "','" & VarPAO_NO2 & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Frm_OrderPrcheses.Show()
    End Sub

    Private Sub Com_Shift_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shift.ButtonClick
        vartable = "vw_Shift"
        VarOpenlookup = 65
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shift_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Shift.EditValueChanged

    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView7.FocusedRowHandle
        Com_InvoiceNo.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(0))
        txt_date.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(1))
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Save_order_Stores()
        sql = "UPDATE   TB_Header_JOB_Order   SET Flg_JopOrder = 1 WHERE Flg_JopOrder = 0 and Compny_Code ='" & VarCodeCompny & "' and JOB_Order_Ser  = '" & Com_InvoiceNo.Text & "' "
        rs = Cnn.Execute(sql)
        find_hedar()
        find_OrderSarf()
    End Sub
    Sub find_OrderSarf()
        sql = "   Select Order_Stores_NO      FROM dbo.TB_Header_OrderItem_Stores WHERE        (JOB_Order ='" & Com_InvoiceNo.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_OrderSarf.Text = rs("Order_Stores_NO").Value Else txt_OrderSarf.Text = ""
    End Sub
    Sub find_hedar()
        On Error Resume Next


        sql = "  Select * from Vw_AllJopOrder where JOB_Order = '" & Com_InvoiceNo.Text & "' "
        varflagorder = 0


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("JOB_Order_Ser").Value)
            Com_InvoiceNo.Text = Trim(rs("JOB_Order").Value)
            txt_date.Text = Trim(rs("JOBOrder_Date").Value)
            varflagorder = rs("Flg_JopOrder").Value
            'txt_OrderNo.Text = Trim(rs("Order_NO").Value)
            'txt_ItemRequird.Text = Trim(rs("Name").Value)
            'txt_QtyRequird.Text = Trim(rs("Qyt_Requrid").Value)
            'txt_Unit.Text = Trim(rs("Unit").Value)
            'txt_MachinName.Text = Trim(rs("machineName").Value)
            'varflagorder = Trim(rs("Flg_JopOrder").Value)
            'com_phases.Text = Trim(rs("Phases").Value)
            'com_FirstItem.Text = Trim(rs("FirstName").Value)
            'txt_QytFirst.Text = Trim(rs("Qyt_FristItem").Value)
            'com_unitFirstItem.Text = Trim(rs("NameUnitFirst").Value)
            'txt_EmpName.Text = Trim(rs("nameEmp").Value)
            'txt_EmpName2.Text = Trim(rs("Emp_Name2").Value)
            Com_Shift.Text = Trim(rs("shiftName").Value)

            'txt_customerName.Text = Trim(rs("Customer_No").Value)
            'txt_Ref.Text = Trim(rs("Ref_JOBOrder").Value)

            'txt_QtyRequird2.Text = Trim(rs("Qyt_Requrid2").Value)
            'txt_Unit_Kilo1.Text = Trim(rs("UnitKilo1").Value)
            'txt_Kilo_QytFirst.Text = Trim(rs("Qyt_FristItem2").Value)
            'com_Kilo_unitFirstItem.Text = Trim(rs("UnitFirstKilo2").Value)




            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green
        Else
            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green

        End If



    End Sub
    Sub last_Data_orderStores()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem_Stores    GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varcode_Orderstores = rs("MaxMaim").Value + 1
            varcode_Orderstores2 = "OS000" + Trim(Str(varcode_Orderstores))

        Else
            varcode_Orderstores = 1
            varcode_Orderstores2 = "OS000" + "1"


        End If
    End Sub
    Sub Save_order_Stores()
        last_Data_orderStores()
        '==============================================SaveOrderStores

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")
        '====================================================
        sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,JOB_Order) " & _
          " values  ('" & varcode_Orderstores & "' ,'" & VarCodeCompny & "','" & varcode_Orderstores2 & "','" & vardateoder & "','" & VarPAO_NO2 & "','" & 1 & "','" & Com_InvoiceNo.Text & "')"
        Cnn.Execute(sql)
        '=========================================
        'sql2 = "SELECT        BD_ITEM_1.Code AS Code_Matril, BD_ITEM_1.Name AS NameMatril, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name AS Unit2, dbo.BD_Stores.Name AS StoresName, " & _
        '    "                         dbo.TB_TypeMatril.Name AS TypeMatril " & _
        '    " FROM            dbo.TB_Detils_JOB_Order INNER JOIN " & _
        '    "                         dbo.TB_Header_JOB_Order ON dbo.TB_Detils_JOB_Order.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND  " & _
        '    "                         dbo.TB_Detils_JOB_Order.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
        '    "                         dbo.BD_ITEM ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
        '    "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '    "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Detils_JOB_Order.No_Matril = BD_ITEM_1.Code INNER JOIN " & _
        '    "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Detils_JOB_Order.Code_Unit = BD_Unit_1.Code INNER JOIN " & _
        '    "                         dbo.BD_Stores ON dbo.TB_Detils_JOB_Order.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_JOB_Order.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
        '    "                         dbo.TB_MachineName ON dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN " & _
        '    "                         dbo.TB_TypeMatril ON BD_ITEM_1.Code_TypeMatril = dbo.TB_TypeMatril.Code AND BD_ITEM_1.Compny_Code = dbo.TB_TypeMatril.Compny_Code " & _
        '    " WHERE        (dbo.TB_Detils_JOB_Order.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_JOB_Order.JOB_Order = '" & Com_InvoiceNo.Text & "') " & _
        '    " GROUP BY BD_ITEM_1.Code, BD_ITEM_1.Name, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name, dbo.BD_Stores.Name, dbo.TB_TypeMatril.Name "

        sql2 = " SELECT BD_ITEM_1.Code AS Code_Matril, BD_ITEM_1.Name AS NameMatril, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name AS Unit2 " & _
        "FROM     dbo.TB_Detils_JOB_Order INNER JOIN " & _
        "                  dbo.TB_Header_JOB_Order ON dbo.TB_Detils_JOB_Order.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND dbo.TB_Detils_JOB_Order.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
        "                  dbo.BD_Item ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code INNER JOIN " & _
        "                  dbo.BD_Item AS BD_ITEM_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Detils_JOB_Order.No_Matril = BD_ITEM_1.Code LEFT OUTER JOIN " & _
        "                  dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Detils_JOB_Order.Code_Unit = BD_Unit_1.Code LEFT OUTER JOIN " & _
        "                  dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code " & _
        " WHERE  (dbo.TB_Detils_JOB_Order.JOB_Order = '" & Com_InvoiceNo.Text & "') " & _
        " GROUP BY BD_ITEM_1.Code, BD_ITEM_1.Name, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name "

        rs2 = Cnn.Execute(sql2)
        Do While Not rs2.EOF


            Dim varcode_Matril, varcodunit2 As Integer

            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & rs2("Unit2").Value & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit2 = rs("Code").Value


            '============================Matril

            sql = "   SELECT *  FROM BD_ITEM    WHERE(Name = '" & rs2("NameMatril").Value & "') and Compny_Code = '" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_Matril = Trim(rs("code").Value) : varcodeExitem = rs("Ex_Item").Value




            sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item,JOB_Order) " & _
          " values  ('" & varcode_Orderstores & "','" & varcode_Orderstores2 & "','" & varcodeExitem & "','" & varcode_Matril & "','" & rs2("Quntity_Matril").Value & "','" & varcodunit2 & "','" & VarCodeCompny & "','" & VarPAO_NO2 & "','1','" & Com_InvoiceNo.Text & "')"
            Cnn.Execute(sql)


            rs2.MoveNext()
        Loop

        MsgBox("تم أنشاء طلب صرف رقم " + " " + Trim(Str(varcode_Orderstores)), MsgBoxStyle.Information)

    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Frm_OrderItem.Com_InvoiceNo2.Text = txt_OrderSarf.Text
        Frm_OrderItem.find_hedar()
        Frm_OrderItem.find_detalis()
        Frm_OrderItem.MdiParent = Mainmune
        Frm_OrderItem.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Frm_AznSarf.MdiParent = Mainmune
        Frm_AznSarf.Show()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Rpt_BOOMPrint.Show()
    End Sub
End Class