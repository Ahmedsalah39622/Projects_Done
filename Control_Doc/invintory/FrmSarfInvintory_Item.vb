Imports System.Data.OleDb

Public Class FrmSarfInvintory_Item
    Dim varstatusorder, Var_CodeOrder As Integer

    Private Sub FrmSarfInvintory_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_OrderNew()
    End Sub

    Sub Find_OrderNew()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " SELECT Ser_Order_Stores, Order_Stores_NO, Order_Date_stores, iif(Status_Order_Stores=0,'جديد','غير مكتمل') as status " & _
    " FROM     dbo.TB_Header_OrderItem_Stores       WHERE(Status_Order_Stores = '" & varstatusorder & "')"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl3.DataSource = ds.Tables(0)


        GridView4.Columns(0).Caption = "رقم الطلب"
        GridView4.Columns(1).Caption = "رقم الطلب"
        GridView4.Columns(2).Caption = "التاريخ"
        GridView4.Columns(3).Caption = "الحالة"

        GridView4.Columns(0).Visible = False

        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True

        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then varstatusorder = 0 : Find_OrderNew()
        'find_ItemOrder()
        'If RadioButton3.Checked = True Then varstatusorder = 2 : Find_OrderNew()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then varstatusorder = 1 : Find_OrderNew()
        'find_ItemOrder()

    End Sub

    Sub find_ItemOrder()
        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        SQL4 = "   SELECT TOP (100) PERCENT dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores,dbo.BD_Item.Ex_Item As RefNo, dbo.TB_Header_OrderItem_Stores.Order_Date_stores, dbo.BD_TypeSarfStores.Name AS TypeStores, " & _
   "                  dbo.TB_Detils_OrderItem_Stores.No_Item, dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_OrderItem_Stores.Quntity AS QytAzn,  iif(dbo.TB_Detils_AznItem_Stores.Order_NO is null,'غير منصرف','منصرف') as dd,  " & _
   "                  dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AS NoAznsarf, dbo.TB_Detils_AznItem_Stores.Quntity " & _
   " FROM     dbo.TB_Header_OrderItem_Stores INNER JOIN " & _
   "                  dbo.TB_Detils_OrderItem_Stores ON dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores AND  " & _
   "                  dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_OrderItem_Stores.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.BD_TypeSarfStores ON dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores = dbo.BD_TypeSarfStores.Code AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.BD_TypeSarfStores.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item AND dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Order_NO where dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores ='" & Var_CodeOrder & "' " & _
   " ORDER BY dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores     "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(SQL4, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        GridView3.Columns(7).AppearanceCell.ForeColor = Color.Red

        GridView3.Appearance.Row.Font = New Font(GridView7.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "رقم الطلب"
        GridView3.Columns(1).Caption = "رقم التوصيف "
        GridView3.Columns(2).Caption = "تاريخ الطلب"
        GridView3.Columns(3).Caption = "نوع طلب الصرف"
        GridView3.Columns(4).Caption = "رقم الصنف"
        GridView3.Columns(5).Caption = "اسم الصنف"
        GridView3.Columns(6).Caption = "الكمية"

        GridView3.Columns(7).Caption = "الحالة"

        GridView3.Columns(8).Caption = "رقم اذن الصرف "
        GridView3.Columns(9).Caption = "الكمية منصرفة"

        GridView3.Columns(0).Visible = False
        GridView3.Columns(2).Visible = False
        GridView3.Columns(3).Visible = False
        GridView3.Columns(4).Visible = False
        GridView3.Columns(8).Visible = False


        GridView3.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        Var_CodeOrder = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        LabOrderRequest.Text = "رقم الطلب" + " " + GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        find_ItemOrder()
    End Sub
End Class