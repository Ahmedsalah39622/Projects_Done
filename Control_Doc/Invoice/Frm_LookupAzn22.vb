Imports System.Data.OleDb

Public Class Frm_LookupAzn22

    Private Sub Frm_LookupAzn20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub
    Sub Search()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql2 = "select   * from Vw_all_azn22 "

        sql2 = "SELECT dbo.TB_Detils_AznItem_Stores.Order_Stores_NO, dbo.TB_Detils_AznItem_Stores.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_AznItem_Stores.Quntity, dbo.BD_Unit.Name AS Unit, dbo.BD_Stores.Name AS Stores, " & _
               " dbo.TB_Header_AznItem_Stores.Ser_Order_Stores, dbo.TB_Detils_AznItem_Stores.No_Invoice " & _
                " FROM     dbo.TB_Detils_AznItem_Stores INNER JOIN " & _
                "                  dbo.BD_Item ON dbo.TB_Detils_AznItem_Stores.No_Item = dbo.BD_Item.Code INNER JOIN " & _
                "                  dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Detils_AznItem_Stores.Order_NO = dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO AND dbo.TB_Detils_AznItem_Stores.No_Item = dbo.TB_Detils_OrderItem_Stores.No_Item INNER JOIN " & _
                "                  dbo.BD_Unit ON dbo.TB_Detils_AznItem_Stores.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
                "                  dbo.BD_Stores ON dbo.TB_Detils_AznItem_Stores.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
                "                  dbo.TB_Header_AznItem_Stores ON dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores = dbo.TB_Header_AznItem_Stores.Ser_Order_Stores AND " & _
                "                  dbo.TB_Detils_AznItem_Stores.Compny_Code = dbo.TB_Header_AznItem_Stores.Compny_Code INNER JOIN " & _
                "                  dbo.TB_Header_OrderItem_Stores ON dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores " & _
                "WHERE(dbo.TB_Detils_AznItem_Stores.No_Invoice = N'0')AND(dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = 2) "


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "المخزن"
        GridView1.Columns(7).Caption = "رقم الاذن"
        GridView1.Columns(8).Caption = "رقم"


        GridView1.Columns(8).Visible = False

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Frm_SalseInvoice.txt_AccountNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_SalseInvoice.txt_nameaccount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Frm_SalseInvoice.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_SalseInvoice.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Frm_SalseInvoice.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_SalseInvoice.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Frm_SalseInvoice.txt_Stores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        varNo_Azn = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        Frm_SalseInvoice.Show()
        Me.Close()
    End Sub
End Class