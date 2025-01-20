Imports System.Data.OleDb

Public Class Frm_LastPriceList

    Private Sub Frm_LastPriceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_lastPriceList_Suppliser()
    End Sub

    Sub Find_lastPriceList_Suppliser()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        '============================رقم الصنف

        sql = "   SELECT *    FROM BD_ITEM    WHERE(Name = '" & txt_nameItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = Trim(rs("Code").Value)

        '==================================

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "    SELECT        dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, dbo.BD_Unit.Name AS unit, dbo.TB_Detalis_InvoicePrcheses.Price_Item, MAX(dbo.TB_Header_InvoicePrcheses.InvoiceDate) AS Dateprcheses, " & _
    "                         dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.St_SuppliserData.Supliser_Name " & _
    " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
    "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo AND  " & _
    "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.TB_Detalis_InvoicePrcheses.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
    "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
    "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND " & _
    "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.St_SuppliserData.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Unit.Compny_Code " & _
    "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) and dbo.TB_Detalis_InvoicePrcheses.No_Item ='" & varcodeitem & "' and dbo.St_SuppliserData.Supliser_Name ='" & txt_NameSuppliser.Text & "' and (dbo.St_SuppliserData.Compny_Code = '" & VarCodeCompny & "')  " & _
    " GROUP BY dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.St_SuppliserData.Supliser_Name, dbo.BD_Unit.Name "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)




        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "اسم الصنف"
        GridView1.Columns(2).Caption = "الوحدة"
        GridView1.Columns(3).Caption = "اخر سعر شراء"
        GridView1.Columns(4).Caption = "تاريخ اخر سعر"
        GridView1.Columns(5).Caption = "مجموعة الصنف"
        GridView1.Columns(6).Caption = "اسم المورد"


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Private Sub txt_NameSuppliser_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameSuppliser.ButtonClick
        VarOpenlookup2 = 24241
        Frm_LookUpCustomer.Find_Suppliser()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_NameSuppliser_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameSuppliser.EditValueChanged

    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameItem.ButtonClick
        varcode_form = 2571
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    

    Private Sub Cmd_OrderItem_Click(sender As Object, e As EventArgs) Handles Cmd_OrderItem.Click
        If txt_nameItem.Text = "" Then MsgBox("من فضلك اختار اسم الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If txt_NameSuppliser.Text = "" Then MsgBox("من فضلك اختار اسم المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Find_lastPriceList_Suppliser()
    End Sub

    
    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        On Error Resume Next
        '===============================رقم المورد
        sql = "   SELECT *    FROM Find_Suppliser2    WHERE(Name = '" & txt_NameSuppliser.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeSupliser = Trim(rs("Code").Value)



        Frm_AccountStatement.Close()
        Frm_AccountStatement.txt_codeAcc.Text = varcodeSupliser
        Frm_AccountStatement.txt_NameAcc.Text = txt_NameSuppliser.Text
        Frm_AccountStatement.MdiParent = Mainmune
        Frm_AccountStatement.find_Acc2()
        Frm_AccountStatement.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Frm_suppliersInfo.Close()
        Frm_suppliersInfo.MdiParent = Mainmune
        Frm_suppliersInfo.Show()

    End Sub
End Class