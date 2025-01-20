Imports System.Data.OleDb

Public Class Frm_LookupReciptCustomer

    Private Sub Frm_LookupInvoiceRecipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_CustomerName.Text = ""
        txt_SandNo.Text = ""
    End Sub

    Sub find_all_Detils()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " SELECT        dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Receipt.Receipt_Value, " & _
 "                         dbo.BD_Currency.Name, dbo.TB_Receipt.rat, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay, iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg  " & _
 " FROM            dbo.TB_Receipt INNER JOIN " & _
 "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
 "                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
 "                         dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code " & _
 " WHERE        (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') and dbo.TB_Receipt.AccountNo1 ='" & varaccountNo_Customer & "' "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم السند"
        GridView1.Columns(1).Caption = "تاريخ السند"
        GridView1.Columns(2).Caption = "رقم الحساب"
        GridView1.Columns(3).Caption = "أسم الحساب "
        GridView1.Columns(4).Caption = "المبلغ"
        GridView1.Columns(5).Caption = "العملة"
        GridView1.Columns(6).Caption = "معامل التحويل"
        GridView1.Columns(7).Caption = "المبلغ بالجنية"
        GridView1.Columns(8).Caption = "رقم الشيك"
        GridView1.Columns(9).Caption = "البنك المسحوب"
        GridView1.Columns(10).Caption = "أستحقاق بتاريخ"
        GridView1.Columns(11).Caption = "نوع الدفع"
        GridView1.Columns(12).Caption = "الحالة"

        GridView1.Columns(2).Visible = False

        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        If GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3)) = "" Then Exit Sub
        txt_CustomerName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        txt_SandNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Cmd_OpenInvoice.Enabled = True
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'Frm_ReciptCash2.Com_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        'Me.Close()
    End Sub

    Private Sub Cmd_OpenInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_OpenInvoice.Click
        Frm_ReciptCash2.Com_Exp_No.Text = txt_SandNo.Text
        Frm_ReciptCash2.find_hedar()
        Frm_ReciptCash2.find_detalis()
        Frm_ReciptCash2.TabPane1.SelectedPageIndex = 0
        Frm_ReciptCash2.MdiParent = Mainmune
        Frm_ReciptCash2.Show()

    End Sub
End Class