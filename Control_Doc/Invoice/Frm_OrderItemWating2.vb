Imports System.Data.OleDb

Public Class Frm_OrderItemWating2
    Dim varlastcode As Long
    Dim varcodeOrder_Item, varcode_Item As String

    Private Sub Frm_OrderItemWating_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_Watingorder()
    End Sub


    Sub find_Watingorder()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "  SELECT        dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.FindCustomer.Name AS NameCustomer, dbo.Emp_employees.Emp_Name, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) " & _
"                  AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem.Quntity, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
" FROM           dbo.TB_Header_OrderItem INNER JOIN " & _
"                   dbo.TB_Detils_OrderItem ON dbo.TB_Header_OrderItem.Order_Ser = dbo.TB_Detils_OrderItem.Order_Ser AND dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Detils_OrderItem.Order_NO AND  " & _
"                   dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code INNER JOIN " & _
"                    dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.Code INNER JOIN " & _
"                    dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
"                    dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem.Ex_Item = dbo.BD_ITEM.Ex_Item LEFT OUTER JOIN " & _
"                    dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem_Stores2.Compny_Code AND  " & _
"        dbo.TB_Detils_OrderItem.Ex_Item = dbo.TB_Detils_OrderItem_Stores2.Ex_Item And dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
" WHERE        (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
" GROUP BY dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.Flag_Item, dbo.FindCustomer.Name, dbo.Emp_employees.Emp_Name, dbo.TB_Detils_OrderItem.Ex_Item,  " & _
"        dbo.TB_Detils_OrderItem.Quntity, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
"        HAVING(dbo.TB_Detils_OrderItem.Flag_Item = 2) "



        If Op3.Checked = True Then
            sql2 = "  SELECT        dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.FindCustomer.Name AS NameCustomer, dbo.Emp_employees.Emp_Name, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) " & _
           "                  AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem.Quntity, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            " FROM           dbo.TB_Header_OrderItem INNER JOIN " & _
              "                   dbo.TB_Detils_OrderItem ON dbo.TB_Header_OrderItem.Order_Ser = dbo.TB_Detils_OrderItem.Order_Ser AND dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Detils_OrderItem.Order_NO AND  " & _
              "                   dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code INNER JOIN " & _
             "                    dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.Code INNER JOIN " & _
             "                    dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
             "                    dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem.Ex_Item = dbo.BD_ITEM.Ex_Item LEFT OUTER JOIN " & _
             "                    dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem_Stores2.Compny_Code AND  " & _
            "        dbo.TB_Detils_OrderItem.Ex_Item = dbo.TB_Detils_OrderItem_Stores2.Ex_Item And dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
            " WHERE        (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.Flag_Item, dbo.FindCustomer.Name, dbo.Emp_employees.Emp_Name, dbo.TB_Detils_OrderItem.Ex_Item,  " & _
            "        dbo.TB_Detils_OrderItem.Quntity, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            "        HAVING(dbo.TB_Detils_OrderItem.Flag_Item = 2) "
        End If

        If Op2.Checked = True Then
            sql2 = "  SELECT        dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.FindCustomer.Name AS NameCustomer, dbo.Emp_employees.Emp_Name, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) " & _
           "                  AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem.Quntity, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            " FROM           dbo.TB_Header_OrderItem INNER JOIN " & _
              "                   dbo.TB_Detils_OrderItem ON dbo.TB_Header_OrderItem.Order_Ser = dbo.TB_Detils_OrderItem.Order_Ser AND dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Detils_OrderItem.Order_NO AND  " & _
              "                   dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code INNER JOIN " & _
             "                    dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.Code INNER JOIN " & _
             "                    dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
             "                    dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem.Ex_Item = dbo.BD_ITEM.Ex_Item LEFT OUTER JOIN " & _
             "                    dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem_Stores2.Compny_Code AND  " & _
            "        dbo.TB_Detils_OrderItem.Ex_Item = dbo.TB_Detils_OrderItem_Stores2.Ex_Item And dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
            " WHERE        (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.Flag_Item, dbo.FindCustomer.Name, dbo.Emp_employees.Emp_Name, dbo.TB_Detils_OrderItem.Ex_Item,  " & _
            "        dbo.TB_Detils_OrderItem.Quntity, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            "        HAVING(dbo.TB_Detils_OrderItem.Flag_Item = 2) AND (dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO IS NULL) "
        End If


        If Op1.Checked = True Then
            sql2 = "  SELECT        dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.FindCustomer.Name AS NameCustomer, dbo.Emp_employees.Emp_Name, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) " & _
           "                  AS Ex_Item, dbo.BD_ITEM.Name AS NameItem, dbo.TB_Detils_OrderItem.Quntity, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            " FROM           dbo.TB_Header_OrderItem INNER JOIN " & _
              "                   dbo.TB_Detils_OrderItem ON dbo.TB_Header_OrderItem.Order_Ser = dbo.TB_Detils_OrderItem.Order_Ser AND dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Detils_OrderItem.Order_NO AND  " & _
              "                   dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem.Compny_Code INNER JOIN " & _
             "                    dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.Code INNER JOIN " & _
             "                    dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code INNER JOIN " & _
             "                    dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_OrderItem.Ex_Item = dbo.BD_ITEM.Ex_Item LEFT OUTER JOIN " & _
             "                    dbo.TB_Detils_OrderItem_Stores2 ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Detils_OrderItem_Stores2.Compny_Code AND  " & _
            "        dbo.TB_Detils_OrderItem.Ex_Item = dbo.TB_Detils_OrderItem_Stores2.Ex_Item And dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Detils_OrderItem_Stores2.Order_NO " & _
            " WHERE        (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
            " GROUP BY dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.Flag_Item, dbo.FindCustomer.Name, dbo.Emp_employees.Emp_Name, dbo.TB_Detils_OrderItem.Ex_Item,  " & _
            "        dbo.TB_Detils_OrderItem.Quntity, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO " & _
            "        HAVING(dbo.TB_Detils_OrderItem.Flag_Item = 2) AND (dbo.TB_Detils_OrderItem_Stores2.Order_Stores_NO IS NOT NULL) "



        End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)




        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "200"
        GridView6.Columns(3).Width = "200"
        GridView6.Columns(4).Width = "150"
        GridView6.Columns(5).Width = "200"
        GridView6.Columns(6).Width = "75"
        GridView6.Columns(7).Width = "120"





        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        'GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        'GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الطلبية"
        GridView6.Columns(1).Caption = "تاريخ الطلبية "
        GridView6.Columns(2).Caption = "أسم العميل"
        GridView6.Columns(3).Caption = "أسم المندوب"
        GridView6.Columns(4).Caption = "رقم الصنف"
        GridView6.Columns(5).Caption = "أسم الصنف"
        GridView6.Columns(6).Caption = "الكمية"
        GridView6.Columns(7).Caption = "رقم طلب الصرف"




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        color_data()
        Mainmune.Find_NewSalseorder()
    End Sub
    Sub color_data()
        'Dim total As String = 0
        'For i As Integer = 0 To GridView6.RowCount - 1
        '    Dim value55 As String = GridView6.GetRowCellValue(0, GridView6.Columns(7))
        'Next


        'For x As Integer = 0 To GridView6.RowCount
        '    Dim intRow = GridView6.GetVisibleRowHandle(x)
        '    Dim strQuantity = GridView6.GetRowCellValue(intRow, "OS0001")

        '    If strQuantity < 0 Then
        '        ' color row in red, or cell in red
        '        'GridView6.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        '        GridView6.Appearance.SelectedRow.BackColor = Color.Black
        '    Else
        '        ' color row in light green
        '    End If

        'Next x

    End Sub
    Sub lastNo_orderItem()
        sql = "SELECT        MAX(Ser_Order_Stores) AS Maxmaim       FROM dbo.TB_Header_OrderItem_Stores  HAVING(MAX(Ser_Order_Stores) Is Not NULL)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varlastcode = rs("Maxmaim").Value + 1 Else varlastcode = 1

    End Sub
    Sub Save_DetilsOrderItem_Stores()
        lastNo_orderItem() '=================================أخر رقم طلب صرف 

        '========================================البحث عن الاصناف المطلوبة لطلب الصرف
        sql = "  SELECT        dbo.TB_Detils_OrderItem.Flag_Item, dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.TB_Detils_OrderItem.Quntity, dbo.TB_Detils_OrderItem.Code_Unit, " & _
                "                         dbo.TB_Detils_OrderItem.Notes, dbo.TB_Detils_OrderItem.Compny_Code, dbo.TB_Header_OrderItem.Customer_No,  " & _
                "        dbo.TB_Header_OrderItem.Salse_No " & _
                " FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
                "                         dbo.TB_Header_OrderItem ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code AND dbo.TB_Detils_OrderItem.Order_Ser = dbo.TB_Header_OrderItem.Order_Ser " & _
                " WHERE        (dbo.TB_Detils_OrderItem.Flag_Item = 1) AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_OrderItem.Order_NO = '" & varcodeOrder_Item & "')  "
        rs = Cnn.Execute(sql)
        '========================================================================اضافة طلب الصرف من خلال البحث فى الطلبية
        Dim dd As DateTime = Now
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy") '=======================تاريخ طلب الصرف تاريخ الاضافة اليوم

        sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO, Compny_Code,Order_Date_stores,Customer_No,Salse_No,Status_Order_Stores,Order_NO) " & _
          " values  ('" & varlastcode & "','" & Trim("OS000" & varlastcode) & "' ,'" & VarCodeCompny & "','" & vardateoder & "','" & rs("Customer_No").Value & "','" & rs("Salse_No").Value & "','0','" & varcodeOrder_Item & "')"
        Cnn.Execute(sql)


        '===========================================================================================
        Do While Not rs.EOF
            '=============================اضافة اصناف طلب الصرف
            sql = "INSERT INTO TB_Detils_OrderItem_Stores2 (Order_Stores_NO,Ex_Item, No_Item,Quntity,Code_Unit,Compny_Code,Flag_Item,Order_NO,Ser_Order_Stores) " & _
          " values  ('" & Trim("OS000" & varlastcode) & "' ,'" & rs("Ex_Item").Value & "','" & rs("No_Item").Value & "','" & rs("Quntity").Value & "','" & rs("Code_Unit").Value & "','" & VarCodeCompny & "','0','" & varcodeOrder_Item & "','" & varlastcode & "')"
            Cnn.Execute(sql)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_CreateOrder_Click(sender As Object, e As EventArgs) Handles Cmd_CreateOrder.Click
        'Save_DetilsOrderItem_Stores()
        Frm_OrderItem2.last_Data()

        Frm_OrderItem2.MdiParent = Mainmune
        Frm_OrderItem2.Show()
    End Sub



    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged
        find_Watingorder()
    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged
        find_Watingorder()
    End Sub

    Private Sub Op1_CheckedChanged(sender As Object, e As EventArgs) Handles Op1.CheckedChanged
        find_Watingorder()
    End Sub



    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeOrder_Item = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))

        'varcode_Item = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        Lab_Order.Text = "رقم طلبية" & ": " & varcodeOrder_Item
        Cmd_CreateOrder.Enabled = True
        'Cmd_CancleOrder.Enabled = True
        Cmd_OpenOrder.Enabled = True
    End Sub

    Private Sub Cmd_OpenOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenOrder.Click

    End Sub
End Class