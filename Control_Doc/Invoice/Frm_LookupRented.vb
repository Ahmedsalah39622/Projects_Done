Imports System.Data.OleDb

Public Class Frm_LookupRented

    Private Sub Frm_LookupRented_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_ItemRented()
    End Sub

    Sub Fill_ItemRented()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select  * from Vw_rentedItem where  nameitem Like '%" & txt_Item.Text & "%'   "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الاذن"
        GridView6.Columns(1).Caption = "تاريخ الاذن"
        GridView6.Columns(2).Caption = "رقم الصنف"
        GridView6.Columns(3).Caption = "اسم الصنف"
        GridView6.Columns(4).Caption = "الكمية"
        GridView6.Columns(5).Caption = "الوحدة1"
        GridView6.Columns(6).Caption = "أسم المخزن"
        GridView6.Columns(7).Visible = False
        '  GridView6.Columns(10).Caption = "رقم الحساب"
        '  GridView6.Columns(11).Caption = "أسم العميل"
        GridView6.BestFitColumns()

        'GridView6.Columns(4).Visible = False
        'GridView6.Columns(5).Visible = False
        ' GridView6.Columns(9).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'Mainmune.finwatinoderItem()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        varnameDiscription = ""
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        'Frm_InvoiceRented.txt_AccountNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))
        'Frm_InvoiceRented.txt_nameaccount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        Frm_InvoiceRented.txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        Frm_InvoiceRented.txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        Frm_InvoiceRented.txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        Frm_InvoiceRented.txt_unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Frm_InvoiceRented.txt_Stores.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        Frm_InvoiceRented.Com_NoAzn.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))

        Me.Close()
    End Sub

    Private Sub txt_Item_TextChanged(sender As Object, e As EventArgs) Handles txt_Item.TextChanged
        Fill_ItemRented()
    End Sub

    Private Sub txt_CustomerName_TextChanged(sender As Object, e As EventArgs)
        Fill_ItemRented()
    End Sub
End Class