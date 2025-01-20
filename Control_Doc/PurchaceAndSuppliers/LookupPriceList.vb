Imports System.Data.OleDb

Public Class LookupPriceList

    Private Sub LookupPriceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub Find_LookupPriceList()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "select * from Vw_Lookup_PriceList where Compny_Code = '" & VarCodeCompny & "' "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)




        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم العرض"
        GridView1.Columns(1).Caption = "المورد"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "الوحدة"

        GridView1.Columns(6).Visible = False

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Frm_OrderPrcheses.txt_NoPriceList.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_OrderPrcheses.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_OrderPrcheses.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Frm_OrderPrcheses.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_OrderPrcheses.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))

        Me.Close()
    End Sub
End Class