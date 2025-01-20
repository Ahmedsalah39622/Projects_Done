Imports System.Data.OleDb

Public Class Frm_LookupOrderItemPr
    Sub Search()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()




            '        sql2 = "    SELECT        TB_Detils_OrderItem_Stores2.Order_NO, TB_Detils_OrderItem_Stores2.No_Item, rtrim(TB_Detils_OrderItem_Stores2.Ex_Item)  as Ex_Item, BD_ITEM.Name AS NameItem, TB_Detils_OrderItem_Stores2.Quntity,  " & _
            '"                         BD_Unit.Name AS Unit, TB_Detils_OrderItem_Stores2.Order_Stores_NO, BD_GROUPITEMMAIN.Name " & _
            '" FROM            TB_Detils_OrderItem_Stores2 INNER JOIN " & _
            '"                         TB_Header_OrderItem_Stores2 ON TB_Detils_OrderItem_Stores2.Ser_Order_Stores = TB_Header_OrderItem_Stores2.Ser_Order_Stores AND  " & _
            '"                         TB_Detils_OrderItem_Stores2.Compny_Code = TB_Header_OrderItem_Stores2.Compny_Code INNER JOIN " & _
            '"                         BD_ITEM ON TB_Detils_OrderItem_Stores2.No_Item = BD_ITEM.Code INNER JOIN " & _
            '"                         BD_GROUPITEMMAIN ON BD_ITEM.CodeGroupItemMain = BD_GROUPITEMMAIN.code INNER JOIN " & _
            '"                         BD_Unit ON TB_Detils_OrderItem_Stores2.Code_Unit = BD_Unit.Code " & _
            '"            WHERE(TB_Detils_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') "
            sql2 = "SELECT        dbo.TB_Detils_OrderItem_Stores2.Order_NO, dbo.TB_Detils_OrderItem_Stores2.No_Item, RTRIM(dbo.TB_Detils_OrderItem_Stores2.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, " & _
            "                         dbo.TB_Detils_OrderItem_Stores2.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO, dbo.BD_GROUPITEMMAIN.Name " & _
            " FROM            dbo.TB_Detils_OrderItem_Stores2 INNER JOIN " & _
            "                         dbo.TB_Header_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem_Stores2.Ser_Order_Stores = dbo.TB_Header_OrderItem_Stores2.Ser_Order_Stores AND  " & _
            "                         dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.TB_Header_OrderItem_Stores2.Compny_Code INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem_Stores2.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem_Stores2.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
            "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_ITEM.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem_Stores2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_OrderItem_Stores2.Compny_Code = dbo.BD_Unit.Compny_Code " & _
            " WHERE        (dbo.TB_Detils_OrderItem_Stores2.Compny_Code = '" & VarCodeCompny & "') "





            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"

            GridView1.Columns(0).Caption = "رقم الطلبية"
            GridView1.Columns(1).Caption = "رقم الصنف"
            GridView1.Columns(2).Caption = "رقم التوصيفى"
            GridView1.Columns(3).Caption = "أسم الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "رقم طلب الشراء"
            GridView1.Columns(7).Caption = "مجموعة الصنف"


            GridView1.Columns(0).Width = "100"
            GridView1.Columns(1).Width = "100"
            GridView1.Columns(2).Width = "100"
            GridView1.Columns(3).Width = "200"
            GridView1.Columns(4).Width = "70"
            GridView1.Columns(5).Width = "100"
            GridView1.Columns(6).Width = "100"
            GridView1.Columns(7).Width = "100"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))

        Frm_PrshessesOrder.txt_CodeItem.Text = value2
        Frm_PrshessesOrder.txt_NameItem.Text = value4
        Frm_PrshessesOrder.txt_Qty.Text = value5
        Frm_PrshessesOrder.txt_unit.Text = value6
        Frm_PrshessesOrder.Txt_Order_Stores_No.Text = value7
        Me.Close()
    End Sub

    Private Sub Frm_LookupOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub
End Class