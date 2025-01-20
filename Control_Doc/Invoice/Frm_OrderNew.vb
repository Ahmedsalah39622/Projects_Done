Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class Frm_OrderNew
    Dim value As String
    Dim varflagitem As Integer

    Private Sub Frm_OrderNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub
    Private Sub Frm_OrderNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_SalseOrder()
        Com_Type.Items.Add("طلب صرف")
        Com_Type.Items.Add("طلب شراء")
        Com_Type.Items.Add("أمرأنتاج")

        CustomDrawRowIndicator(GridControl1, GridView1)
        CustomDrawRowIndicator(GridControl3, GridView6)
    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
    End Sub
    Private Sub GridView6_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)


        GridView6.RowHeight = 20
        GridView6.GroupRowHeight = 1
        GridView6.RowSeparatorHeight = 1
        'End If
    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)


        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
        'End If
    End Sub

    Sub find_SalseOrder()

        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If OP1.Checked = True Then

            sql2 = "SELECT        TOP (100) PERCENT dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name,  " & _
            "                         dbo.TB_StatusSalseOrder.Name AS Stutas " & _
            " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
            "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
            "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
            "                         dbo.TB_StatusSalseOrder ON dbo.TB_Header_OrderItem.Status_Order = dbo.TB_StatusSalseOrder.Code " & _
            " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Status_Order = 0)  " & _
            " ORDER BY dbo.TB_Header_OrderItem.Order_Ser "



        End If

        If OP2.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name,  " & _
            "                         dbo.TB_StatusSalseOrder.Name AS Stutas " & _
            " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
            "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
            "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
            "                         dbo.TB_StatusSalseOrder ON dbo.TB_Header_OrderItem.Status_Order = dbo.TB_StatusSalseOrder.Code " & _
            " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Status_Order = 1)  " & _
            " ORDER BY dbo.TB_Header_OrderItem.Order_Ser "
        End If

        If OP3.Checked = True Then
            sql2 = "SELECT        TOP (100) PERCENT dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name,  " & _
            "                         dbo.TB_StatusSalseOrder.Name AS Stutas " & _
            " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
            "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
            "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
            "                         dbo.TB_StatusSalseOrder ON dbo.TB_Header_OrderItem.Status_Order = dbo.TB_StatusSalseOrder.Code " & _
            " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Status_Order = 2)  " & _
            " ORDER BY dbo.TB_Header_OrderItem.Order_Ser "
        End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "105"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "250"
        GridView6.Columns(3).Width = "250"
        GridView6.Columns(4).Width = "200"


        GridView6.Columns(0).AppearanceCell.BackColor = Color.DarkGray
        GridView6.Columns(0).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الطلبية "
        GridView6.Columns(1).Caption = "تاريخ الطلبية"
        GridView6.Columns(2).Caption = "أسم العميل"
        GridView6.Columns(3).Caption = "أسم المندوب"
        GridView6.Columns(4).Caption = "حالة الطلبية"




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub






    Sub find_detalisOrder()
        On Error Resume Next
        'Dim varss As String
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_Item.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
        "                         dbo.Tb_Flag_Item.Name AS Flag_Item, dbo.TB_Detils_OrderItem.Price_Unit, dbo.Tb_CondationTax.Name AS TaxName,dbo.TB_Detils_OrderItem.Notes " & _
        " FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
        "                         dbo.TB_Header_OrderItem ON dbo.TB_Detils_OrderItem.Order_Ser = dbo.TB_Header_OrderItem.Order_Ser AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code AND  " & _
        "                         dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Header_OrderItem.Order_NO INNER JOIN " & _
        "                         dbo.Tb_CondationTax ON dbo.TB_Header_OrderItem.flag_tax = dbo.Tb_CondationTax.Code LEFT OUTER JOIN " & _
        "                         dbo.BD_Item ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_Item.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Item.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.Tb_Flag_Item ON dbo.TB_Detils_OrderItem.Flag_Item = dbo.Tb_Flag_Item.Code " & _
        " WHERE        (dbo.TB_Detils_OrderItem.Order_NO = '" & value & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "كود الصنف"
        GridView1.Columns(1).Caption = "الرقم التوصيفى "
        GridView1.Columns(2).Caption = "الصنف"
        GridView1.Columns(3).Caption = "الكمية"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "حالة الصنف"
        GridView1.Columns(6).Caption = "سعر الوحدة"
        GridView1.Columns(7).Caption = "النوع"
        GridView1.Columns(8).Caption = "ملاحظات"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
       

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If txt_CodeItem.Text = "" Then MsgBox("من فضلك اختار الصنف", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub

        'sql = "select * from TB_Header_OrderItem where Order_NO = '" & value & "' and Compny_Code ='" & VarCodeCompny & "' and Abrove_Customer ='" & 1 & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = True Then MsgBox("من فضلك رقم الطلبية غير موافق عليها من قبل العميل من فضلك تأكد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub




        If Com_Type.Text = "طلب صرف" Then varflagitem = 1
        If Com_Type.Text = "طلب شراء" Then varflagitem = 2
        If Com_Type.Text = "أمرأنتاج" Then varflagitem = 3




        sql2 = "UPDATE  TB_Detils_OrderItem  SET Flag_Item='" & varflagitem & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Ex_Item ='" & txt_CodeItem.Text & "' and Order_NO ='" & value & "'  "
        rs = Cnn.Execute(sql2)

        sql2 = "UPDATE  TB_Header_OrderItem  SET Status_Order='" & 1 & "'  WHERE Compny_Code = " & VarCodeCompny & "   and Order_NO ='" & value & "'  "
        rs = Cnn.Execute(sql2)

        MsgBox("تم الموافقة", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_detalisOrder()
        find_SalseOrder()
        Mainmune.finwatinoderItem()

        Mainmune.finwatinoderItem2()
    End Sub

    

   

    Private Sub GridControl3_KeyDown(sender As Object, e As KeyEventArgs)
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        Lab_Order.Text = "رقم الطلبية :" + " " + value
        find_detalisOrder()
    End Sub

    Private Sub GridControl3_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
            value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
            Lab_Order.Text = "رقم الطلبية :" + " " + value
            find_detalisOrder()
        End If
    End Sub

   
    Sub Search()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT        dbo.Statement_OfItem.NoItem, dbo.BD_ITEM.Name AS NameItem, SUM(dbo.Statement_OfItem.Export) AS Wared, ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, " & _
"                         ROUND(SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import), 2) AS Balance, dbo.BD_Stores.Name  " & _
" FROM            dbo.Statement_OfItem INNER JOIN  " & _
"                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN  " & _
"                         dbo.BD_ITEM ON dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code  " & _
" GROUP BY dbo.Statement_OfItem.NoItem, dbo.BD_Stores.Name, dbo.BD_ITEM.Name  " & _
"            HAVING(dbo.Statement_OfItem.NoItem = '" & var_codeItem & "') "

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView3.Columns(0).Caption = "رقم الصنف"
        GridView3.Columns(1).Caption = "أسم الصنف"
        GridView3.Columns(2).Caption = "الوارد"
        GridView3.Columns(3).Caption = "المنصرف"
        GridView3.Columns(4).Caption = "رصيد"
        GridView3.Columns(5).Caption = "المخزن"

        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True


        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "250"
        GridView3.Columns(2).Width = "100"
        GridView3.Columns(3).Width = "100"
        GridView3.Columns(4).Width = "120"
        GridView3.Columns(5).Width = "200"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub GridControl1_Click_2(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        var_codeItem = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        txt_UnitName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Search()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        value = 0
        find_detalisOrder()
        var_codeItem = 0
        Search()
    End Sub

   

    Private Sub GridControl3_Click_1(sender As Object, e As EventArgs) Handles GridControl3.Click
        value = ""
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        Lab_Order.Text = "رقم الطلبية :" + " " + value
        find_detalisOrder()
    End Sub

    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        value = ""
        find_SalseOrder()
        find_detalisOrder()
    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged

    End Sub

    Private Sub Op2_Click(sender As Object, e As EventArgs) Handles Op2.Click
        value = ""
        find_SalseOrder()
        find_detalisOrder()
    End Sub

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged

    End Sub

    Private Sub Op3_Click(sender As Object, e As EventArgs) Handles Op3.Click
        find_SalseOrder()
        value = ""
        find_detalisOrder()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        'On Error Resume Next
        'If txt_CodeItem.Text = "" Then MsgBox("من فضلك أختار الصنف", MsgBoxStyle.Information, "Css Solution Software Module") : Exit Sub


        ''sql = "UPDATE  TB_Header_OrderItem  SET  Status_Order ='" & 0 & "'     WHERE  Order_NO ='" & value & "' and Compny_Code ='" & VarCodeCompny & "' "
        ''rs = Cnn.Execute(sql)


        'sql = "UPDATE  TB_Detils_OrderItem  SET  Flag_Item ='" & 0 & "'     WHERE No_Item = '" & txt_CodeItem.Text & "' and Order_NO ='" & value & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        'MsgBox("تم تغير  حالة الصنف الى جديد", MsgBoxStyle.Information, "Css Solution Software Module")
        'find_detalisOrder()
        ''find_SalseOrder()
    End Sub
End Class