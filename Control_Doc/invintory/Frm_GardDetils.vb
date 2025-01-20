Imports System.Data.OleDb

Public Class Frm_GardDetils
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub Frm_GardDetils_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub find_balance()


        sql = "SELECT        dbo.vw_all_gard_detils.NoItem, dbo.vw_all_gard_detils.NameItem, dbo.vw_all_gard_detils.Unit_2, SUM(dbo.vw_all_gard_detils.ward2) - SUM(dbo.vw_all_gard_detils.Mnsr2) AS Balance, " & _
"                         dbo.vw_all_gard_detils.Name,SUM(dbo.vw_all_gard_detils.ward2) as ward,SUM(dbo.vw_all_gard_detils.Mnsr2) as mnsrf  " & _
 " FROM            dbo.BD_ITEM INNER JOIN " & _
"                         dbo.vw_all_gard_detils ON dbo.BD_ITEM.Code = dbo.vw_all_gard_detils.NoItem INNER JOIN " & _
"                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code " & _
" GROUP BY dbo.vw_all_gard_detils.NoItem, dbo.vw_all_gard_detils.NameItem, dbo.vw_all_gard_detils.Unit_2, dbo.vw_all_gard_detils.Name " & _
" HAVING        (dbo.vw_all_gard_detils.NoItem = '" & varcode_item & "') AND (dbo.vw_all_gard_detils.Name ='" & varnamestores & "') "




        rs = Cnn.Execute(sql)

        If rs.EOF = False Then
            txt_NameItem.Text = rs("NameItem").Value
            txt_Balance.Text = rs("Balance").Value
            Txt_unit.Text = rs("Unit_2").Value
            txt_wared.Text = rs("ward").Value
            txt_mnsrf.Text = rs("mnsrf").Value

        End If
        find_Item2()
    End Sub
    Sub find_Gard_detils()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = Frm_ReportStores.txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(Frm_ReportStores.txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = Frm_ReportStores.txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(Frm_ReportStores.txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay






        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " DROP VIEW dbo.vw_all_gard_detils"
        rs = Cnn.Execute(sql)



        '===================================================================

        sql2 = " CREATE VIEW vw_all_gard_detils AS  SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
  "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem, " & _
  "                         dbo.BD_GROUPITEMMAIN.Name AS NG, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2, BD_Unit_1.Name AS Unit_2, dbo.Statement_OfItem.NoItem,  " & _
  "                         dbo.Statement_OfItem.DateMoveM, dbo.Statement_OfItem.Dis, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1,  " & _
  "                         ROUND(SUM(dbo.Statement_OfItem.Export), 2)) AS ward2, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1,  " & _
  "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Mnsr2, dbo.Statement_OfItem.NumberBill, dbo.TB_TypeBill.Type_Bill " & _
  " FROM            dbo.Statement_OfItem INNER JOIN " & _
  "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
  "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
  "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
  "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.BD_ITEM.Unit2 = BD_Unit_1.Code INNER JOIN " & _
  "                         dbo.TB_TypeBill ON dbo.Statement_OfItem.TypeD = dbo.TB_TypeBill.Code LEFT OUTER JOIN " & _
  "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
  " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2,  " & _
  "        BD_Unit_1.Name, dbo.Statement_OfItem.NoItem, dbo.Statement_OfItem.DateMoveM, dbo.Statement_OfItem.Dis, dbo.Statement_OfItem.NumberBill, dbo.Statement_OfItem.TypeD, " & _
  "        dbo.TB_TypeBill.Type_Bill " & _
  " HAVING        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        rs = Cnn.Execute(sql2)

        '=========================================================================
        sql2 = " SELECT        dbo.vw_all_gard_detils.DateMoveM, dbo.BD_GROUPITEMMAIN.Name, dbo.vw_all_gard_detils.NoItem, dbo.vw_all_gard_detils.NameItem, dbo.vw_all_gard_detils.UnitName, dbo.vw_all_gard_detils.ward, " & _
 "                         dbo.vw_all_gard_detils.Mnsrf, dbo.vw_all_gard_detils.ValueUnit1, dbo.vw_all_gard_detils.Unit_2, dbo.vw_all_gard_detils.ward2, dbo.vw_all_gard_detils.Mnsr2, dbo.vw_all_gard_detils.Dis,NumberBill,Type_Bill " & _
 " FROM            dbo.BD_ITEM INNER JOIN " & _
 "                         dbo.vw_all_gard_detils ON dbo.BD_ITEM.Code = dbo.vw_all_gard_detils.NoItem INNER JOIN " & _
 "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code " & _
 "        WHERE(dbo.vw_all_gard_detils.NoItem = '" & varcode_item & "') and (dbo.vw_all_gard_detils.Name = '" & varnamestores & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "تاريخ الحركة"
        GridView1.Columns(1).Caption = "اسم المجموعة"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "وارد"
        GridView1.Columns(6).Caption = "منصرف"
        GridView1.Columns(7).Caption = "معامل تحويل"

        GridView1.Columns(8).Caption = "وحدة 2"
        GridView1.Columns(9).Caption = "الوارد بالوحدة 2"
        GridView1.Columns(10).Caption = "المنصرف بالوحدة 2"
        GridView1.Columns(11).Caption = "البيان"
        GridView1.Columns(12).Caption = "رقم الحركة"
        GridView1.Columns(13).Caption = "نوع الحركة"


        GridView1.BestFitColumns()



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        '================================================



    End Sub
    Sub find_Item2()
        On Error Resume Next
        sql = " SELECT dbo.BD_Item.ValueUnit1, dbo.BD_Unit.Name FROM     dbo.BD_Item INNER JOIN                dbo.BD_Unit ON dbo.BD_Item.Unit1 = dbo.BD_Unit.Code    WHERE(dbo.BD_Item.Code = '" & varcode_item & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Rased2.Text = Val(txt_Balance.Text) / rs("ValueUnit1").Value : Lab_unit.Text = rs("Name").Value

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)


    End Sub

   

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
    
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(13))

        If value2 = "بضاعة اول المدة" Then Frm_FristItem.Com_InvoiceNo.Text = value : Frm_FristItem.Fill_INVOICE2() : Frm_FristItem.MdiParent = Mainmune : Frm_FristItem.Show()
        If value2 = "اذن اضافة مخازن" Then Frm_Azn_AddItem.Com_InvoiceNo2.Text = value : Frm_Azn_AddItem.find_hedar() : Frm_Azn_AddItem.find_detalis() : Frm_Azn_AddItem.MdiParent = Mainmune : Frm_Azn_AddItem.Show()
        If value2 = "اذن صرف مخازن" Then Frm_AznSarf.Com_InvoiceNo2.Text = value : Frm_AznSarf.find_hedar() : Frm_AznSarf.find_detalis() : Frm_AznSarf.MdiParent = Mainmune : Frm_AznSarf.Show()
        If value2 = "فاتورة بيع" Then Frm_SalseInvoice.Com_InvoiceNo.Text = value : Frm_SalseInvoice.find_hedar() : Frm_SalseInvoice.find_detalis() : Frm_SalseInvoice.Total_Sum() : Frm_SalseInvoice.sum_tax() : Frm_SalseInvoice.MdiParent = Mainmune : Frm_SalseInvoice.TabPane1.SelectedPageIndex = 0 : Frm_SalseInvoice.Show()

    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        find_Gard_detils()
        find_balance()
    End Sub

    Private Sub Cmd_Print_Click_2(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub
End Class