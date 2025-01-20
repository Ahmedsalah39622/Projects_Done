Imports System.Data.OleDb

Public Class Frm_ItemNewProduct
    Dim varserOrder, varCount_Twred, varcodeUnit, varcodeItem, vallastcodeitem As Integer
    Dim varSerOrderEX, varcustomeNO, varunit, varcodeExitem2, varOrderCompny As String
    Dim varQty, varPrice As Single
    Private Sub Frm_ItemNewProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_Order()
        Fill_Unit()
    End Sub

    Sub find_Order()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If OP1.Checked = True Then
            sql2 = "SELECT        dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_ITEM.Name, dbo.BD_Unit.Name AS UnitName, dbo.TB_Detils_OrderItem.Quntity, " & _
            "                         dbo.TB_Detils_OrderItem.Price_Unit, dbo.FindCustomer.Name AS NameCustomer, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.TB_Header_OrderItem.CountDay, DATEADD(day,  " & _
            "                         dbo.TB_Header_OrderItem.CountDay, dbo.TB_Header_OrderItem.Order_Date) AS dd " & _
            " FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
            "                         dbo.TB_Header_OrderItem ON dbo.TB_Detils_OrderItem.Order_Ser = dbo.TB_Header_OrderItem.Order_Ser AND dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
            "                         dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
            "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.TB_Header_JOB_Order ON dbo.TB_Header_OrderItem.Order_NO = dbo.TB_Header_JOB_Order.Order_NO AND  " & _
            "                         dbo.TB_Header_OrderItem.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.Tb_Flag_Item ON dbo.TB_Detils_OrderItem.Flag_Item = dbo.Tb_Flag_Item.Code " & _
            " WHERE        (dbo.Tb_Flag_Item.Code = '3') AND (dbo.TB_Header_JOB_Order.JOB_Order IS NULL) AND (dbo.TB_Detils_OrderItem.Compny_Code = 3) " & _
            " GROUP BY dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_ITEM.Name, dbo.BD_Unit.Name, dbo.TB_Detils_OrderItem.Quntity,  " & _
            "            dbo.TB_Detils_OrderItem.Price_Unit, dbo.FindCustomer.Name, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.TB_Header_OrderItem.CountDay "





        End If

        If OP2.Checked = True Then


            sql2 = "SELECT        dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_ITEM.Name, dbo.BD_Unit.Name AS UnitName, dbo.TB_Detils_OrderItem.Quntity, " & _
            "                         dbo.TB_Detils_OrderItem.Price_Unit, dbo.FindCustomer.Name AS NameCustomer, 'ماستر باك' AS Co, dbo.TB_Header_OrderItem.CountDay, DATEADD(day, dbo.TB_Header_OrderItem.CountDay, " & _
            "                         dbo.TB_Header_OrderItem.Order_Date) AS dd " & _
            " FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
            "                         dbo.TB_Header_OrderItem ON dbo.TB_Detils_OrderItem.Order_Ser = dbo.TB_Header_OrderItem.Order_Ser AND dbo.TB_Detils_OrderItem.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
            "                         dbo.TB_Detils_OrderItem.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
            "                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.TB_Header_OrderItem AS TB_Header_OrderItem_1 ON dbo.TB_Header_OrderItem.Order_NO = TB_Header_OrderItem_1.Order_NO_Compny LEFT OUTER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
            "                         dbo.Tb_Flag_Item ON dbo.TB_Detils_OrderItem.Flag_Item = dbo.Tb_Flag_Item.Code " & _
            " WHERE        (dbo.Tb_Flag_Item.Code = '3') AND (dbo.TB_Detils_OrderItem.Compny_Code = 2) " & _
            " GROUP BY dbo.TB_Detils_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Detils_OrderItem.No_Item, dbo.BD_ITEM.Name, dbo.BD_Unit.Name, dbo.TB_Detils_OrderItem.Quntity,  " & _
            "            dbo.TB_Detils_OrderItem.Price_Unit, dbo.FindCustomer.Name, dbo.TB_Header_OrderItem.CountDay, TB_Header_OrderItem_1.Order_NO_Compny " & _
            "            HAVING(TB_Header_OrderItem_1.Order_NO_Compny Is NULL) "



        End If



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "100"
        GridView1.Columns(3).Width = "150"
        GridView1.Columns(4).Width = "70"
        GridView1.Columns(5).Width = "70"
        GridView1.Columns(6).Width = "70"
        GridView1.Columns(7).Width = "150"
        GridView1.Columns(8).Width = "170"
        GridView1.Columns(9).Width = "100"
        GridView1.Columns(10).Width = "100"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        If OP2.Checked = True Then GridView1.Columns(0).Caption = "رقم أمر التوريد شركات أخرى " Else GridView1.Columns(0).Caption = "رقم أمر التوريد  "
        If OP2.Checked = True Then GridView1.Columns(1).Caption = "تاريخ أمر التوريد شركات اخرى" Else GridView1.Columns(1).Caption = "تاريخ أمر التوريد"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "السعر"
        GridView1.Columns(7).Caption = "أسم العميل "
        GridView1.Columns(8).Caption = "أسم العميل من شركات اخرى"
        GridView1.Columns(9).Caption = "مدة التوريد"
        GridView1.Columns(10).Caption = "تاريخ التسليم"

        'GridView1.Columns(7).Visible = False

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

   

   

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        find_Order()
    End Sub

   

    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        find_Order()
    End Sub

   
    Sub SaveItemNew()
        sql = "   SELECT *    FROM BD_ITEM    WHERE(Name = '" & Com_ItemName.Text & "') and Compny_Code = '" & 2 & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            sql2 = "   SELECT *    FROM BD_ITEM    WHERE(name = '" & Com_ItemName.Text & "') and Compny_Code =  '" & VarCodeCompny & "'"
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then
            Else

                last_Data2()
                sql = "INSERT INTO BD_ITEM (Code, Name,CodeGroupItemMain,CodeGroupItem1,CodeGroupItem2,Unit1,ValueUnit1,Unit2,ValueUnit2,Unit3,ValueUnit3,Ex_Item,Compny_Code) " & _
    " values  (N'" & vallastcodeitem & "' ,N'" & rs("Name").Value & "',N'" & rs("CodeGroupItemMain").Value & "',N'" & rs("CodeGroupItem1").Value & "',N'" & rs("CodeGroupItem2").Value & "',N'" & rs("Unit1").Value & "',N'" & rs("ValueUnit1").Value & "',N'" & rs("Unit2").Value & "',N'" & rs("ValueUnit2").Value & "',N'" & rs("Unit3").Value & "',N'" & rs("ValueUnit3").Value & "','" & rs("Ex_Item").Value & "','" & VarCodeCompny & "')"
                Cnn.Execute(sql)
            End If
            varcodeItem = vallastcodeitem
        End If

    End Sub

    Sub last_Data2()


        On Error Resume Next
        sql = "SELECT        MAX(Code) AS MaxmamNo FROM  BD_ITEM  where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(Code) Is Not NULL)  "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            vallastcodeitem = rs3("MaxmamNo").Value + 1
        Else
            vallastcodeitem = 1


        End If
    End Sub

   
    Sub save_Order_H()
        'On Error Resume Next




        last_Data()

        Dim dd As DateTime = DateTime.Now
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        '=======================================CustomerNo
   
        varcustomeNO = "105001001001"

        '=====================================================================HederOrder
        sql = "INSERT INTO TB_Header_OrderItem (Order_Ser, Compny_Code,Order_NO,Order_Date,Customer_No,Salse_No,Status_Order,CountDay,NameCustomer_Compny,Code_Compny2,Order_NO_Compny) " & _
                  " values  ('" & varserOrder & "' ,'" & VarCodeCompny & "','" & varSerOrderEX & "','" & vardateoder & "','" & varcustomeNO & "','" & varcode_User & "','0','" & varCount_Twred & "','" & txt_CustomerName.Text & "','" & 2 & "','" & varOrderCompny & "')"
        Cnn.Execute(sql)

        '===================================================================== Detils order


    End Sub


    Sub save_oderDetils()
        '===========================================كود الوحدة
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Com_Unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeUnit = rs("Code").Value
        '=============================================================

        '============================EXitem
        sql = "   SELECT Code, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(name = '" & Com_ItemName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem2 = Trim(rs("Ex_Item").Value) : varcodeItem = Trim(rs("Code").Value)

     



        sql = "INSERT INTO TB_Detils_OrderItem (Order_Ser,Order_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Code_Cur,Rat_Cur,TotalItem,Price_Unit,Flag_Item,Code_Compny2,Order_NO_Compny) " & _
              " values  ('" & varserOrder & "' ,'" & varSerOrderEX & "','" & varcodeExitem2 & "','" & varcodeItem & "','" & txt_CountRoll.Text & "','" & varcodeUnit & "','" & VarCodeCompny & "','" & 1 & "','" & 1 & "','" & Math.Round(varPrice * varQty, 2) & "','" & varPrice & "','" & 3 & "','" & 2 & "','" & varOrderCompny & "')"
        Cnn.Execute(sql)

        MsgBox("تم الحفظ", MsgBoxStyle.Information, "CSS Solution Software Module") : Exit Sub

    End Sub


    Sub last_Data()
        sql = "  SELECT        MAX(Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varserOrder = rs("MaxMaim").Value + 1
            varSerOrderEX = "ROC000" & varserOrder

        Else
            varserOrder = 1
            varSerOrderEX = "ROC000" + "1"


        End If
    End Sub

    Sub Fill_Unit()
        Com_Unit.Items.Clear()
        sql = "   SELECT Name     FROM BD_Unit  where  Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        varCount_Twred = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        txt_ComUnit2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4)) 'الوحدة
        txt_Qty2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5)) ' الكمية
        varPrice = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6)) ' السعر
        txt_CustomerName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7)) ' العميل
        Com_ItemName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3)) ' الصنف
        varOrderCompny = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) 'رقم توريد الشركة

    End Sub

    Private Sub Com_ItemName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_ItemName.ButtonClick
        'varcode_form = 2626
        'VARTBNAME = " Vw_AllDataItem"
        'Lookupitem.Fill_Alldata()
        'Lookupitem.ShowDialog()
    End Sub

    Private Sub Com_ItemName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_ItemName.EditValueChanged

    End Sub

   

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If txt_CustomerName.Text = "" Then MsgBox("من فضلك اختار العميل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_ItemName.Text = "" Then MsgBox("من فضلك أختار الصنف", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_Unit.Text = "" Then MsgBox("من فضلك أختار الوحدة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_CountRoll.Text = "" Then MsgBox("من فضلك أدخل عدد الرولات", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub

        '===============================================ChekItem
        sql = "   SELECT *    FROM BD_ITEM    WHERE(Name = '" & Com_ItemName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varcodeItem = rs("Code").Value
        Else
            SaveItemNew()
        End If

        save_Order_H()
        save_oderDetils()
        find_Order()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs) Handles OP2.CheckedChanged

    End Sub

    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub
End Class