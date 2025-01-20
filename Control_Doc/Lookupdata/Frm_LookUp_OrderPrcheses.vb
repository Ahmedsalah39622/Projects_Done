Imports System.Data.OleDb

Public Class Frm_LookUp_OrderPrcheses

    Private Sub Frm_LookUp_OrderPrcheses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Order()
    End Sub
    Sub Find_Order()





        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        'sql2 = "  SELECT        dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Detils_OrderItem_Stores2.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name AS unit,  " & _
        '      "                         dbo.Tb_TypePO.Name AS Type , dbo.TB_Header_OrderItem_Stores2.No_PriceList " & _
        '      " FROM            dbo.TB_Detils_OrderItem_Stores2 INNER JOIN  " & _
        '      "                         dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_Item.Code INNER JOIN  " & _
        '      "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
        '      "                         dbo.TB_Header_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem_Stores2.Ser_Order_Stores = dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores AND   " & _
        '      "                         dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.TB_Header_OrderItem_Stores2.Compny_Code LEFT OUTER JOIN  " & _
        '      "                         dbo.Tb_TypePO ON dbo.TB_Header_OrderItem_Stores2.Type_OrderPrcheses = dbo.Tb_TypePO.Code AND dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.Tb_TypePO.Compny_Code  " & _
        '      " WHERE        (dbo.TB_Detils_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores2.Flag_Item = 0)  and TB_Header_OrderItem_Stores2.Status_Order_Stores = 1 "


        sql2 = "      SELECT dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO, dbo.TB_Detils_OrderItem_Stores2.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name AS unit,  " & _
      "                  dbo.Tb_TypePO.Name AS Type, dbo.TB_Header_OrderItem_Stores2.No_PriceList, dbo.TB_Detils_PO2.Order_NO  " & _
      "FROM     dbo.TB_Detils_OrderItem_Stores2 INNER JOIN  " & _
      "                  dbo.BD_Item ON dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_Item.Code INNER JOIN  " & _
      "                  dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
      "                  dbo.TB_Header_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem_Stores2.Ser_Order_Stores = dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores AND   " & _
      "                  dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.TB_Header_OrderItem_Stores2.Compny_Code LEFT OUTER JOIN  " & _
      "                  dbo.TB_Detils_PO2 ON dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.TB_Detils_PO2.No_Item AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.TB_Detils_PO2.Compny_Code AND  " & _
      "                  dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO = dbo.TB_Detils_PO2.Order_NO LEFT OUTER JOIN  " & _
      "                  dbo.Tb_TypePO ON dbo.TB_Header_OrderItem_Stores2.Type_OrderPrcheses = dbo.Tb_TypePO.Code AND dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.Tb_TypePO.Compny_Code  " & _
      " WHERE  (dbo.TB_Detils_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem_Stores2.Flag_Item = 0)  AND   " & _
      "                  (dbo.TB_Detils_PO2.Order_NO IS NULL) "


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(0).Caption = "طلب الشراء"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الكمية"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "نوع طلب الشراء"
        GridView1.Columns(6).Caption = "رقم عرض السعر"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

   

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Frm_PrchesesPO.txt_OrderSal.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_PrchesesPO.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Frm_PrchesesPO.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_PrchesesPO.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Frm_PrchesesPO.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        'Frm_PrchesesPO.com_order_type.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Me.Close()

    End Sub
End Class