Imports System.Data.OleDb

Public Class Frm_Order_M
    Dim value2, ValueOrderNo, varcodunit, varflagorder, varcode_Compontent, varcode_Compontent2, varcodeitem2, varcodunit2 As Integer
    Sub last_Data()

        sql = "  SELECT        MAX(OrderNo_Code) AS MaxMaim,Compny_Code FROM            TB_Header_Order_Mentinence  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(OrderNo_Code) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_OrderM_No.Text = rs("MaxMaim").Value + 1


        Else
            Com_OrderM_No.Text = 1



        End If
    End Sub



    Sub clear()
        txt_date.Text = Now
        txt_AddressCustomer.Text = ""
        Com_CustomeName.Text = ""
        txt_Notes.Text = ""
        txt_Phone.Text = ""
        txt_discription.Text = ""
    End Sub

    Private Sub Com_CustomeName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_CustomeName.ButtonClick
        VarOpenlookup2 = 33
        varcode_form = 33
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        find_customer2()
    End Sub
    Sub find_customer2()
        On Error Resume Next
        sql = "  SELECT        Compny_Code, Customer_Code, Customer_Name, Customer_Address, Customer_Phon1,Customer_Flag_M      FROM dbo.St_CustomerData WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Customer_Name = '" & Com_CustomeName.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            txt_AddressCustomer.Text = rs2("Customer_Address").Value : txt_Phone.Text = rs2("Customer_Phon1").Value

            If rs2("Customer_Flag_M").Value = 0 Then Op1.Checked = True : Op2.Checked = True
            If rs2("Customer_Flag_M").Value = 1 Then Op2.Checked = True : Op1.Checked = False
        Else
            txt_AddressCustomer.Text = "" : txt_Phone.Text = ""

        End If

    End Sub






    Sub save_oderDetils()

        sql = "   SELECT *     FROM BD_ITEM    WHERE(name = '" & txt_MachineName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = Trim(rs("code").Value)




        sql = "INSERT INTO TB_Detils_TypeMentince (OrderNo_Code,Compny_Code,Code_Item,Dis) " & _
              " values  ('" & Com_OrderM_No.Text & "' ,'" & VarCodeCompny & "','" & varcodeitem & "','" & txt_discription.Text & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs)
    
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs)
        
    End Sub
    Sub fill_TypM()
        Com_Type.Items.Clear()
        sql = " SELECT     Name  from BD_TypeMintes where Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Type.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub find_detalis()

        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = " SELECT        dbo.TB_Detils_TypeMentince.Code_Item, dbo.BD_ITEM.Name,dbo.TB_Detils_TypeMentince.dis " & _
                 " FROM            dbo.TB_Detils_TypeMentince INNER JOIN " & _
                 "                         dbo.BD_ITEM ON dbo.TB_Detils_TypeMentince.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_TypeMentince.Code_Item = dbo.BD_ITEM.Code " & _
                 " WHERE        (dbo.TB_Detils_TypeMentince.OrderNo_Code = '" & Com_OrderM_No.Text & "') AND (dbo.BD_ITEM.Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "75"
        GridView5.Columns(1).Width = "200"
        GridView5.Columns(2).Width = "200"


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "كود الصنف"
        GridView5.Columns(1).Caption = "الماكينة "
        GridView5.Columns(2).Caption = "وصف العطل "


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub


    Sub find_All()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = " SELECT        dbo.TB_Header_Order_Mentinence.OrderNo_Code, dbo.TB_Header_Order_Mentinence.Order_Date, dbo.TB_Detils_TypeMentince.Code_Item, dbo.BD_ITEM.Name AS NameItem, dbo.St_CustomerData.Customer_Name, dbo.BD_TypeMintes.Name,  " & _
 "                        dbo.TB_Header_Order_Mentinence.Notes " & _
" FROM            dbo.TB_Header_Order_Mentinence INNER JOIN " & _
"                         dbo.St_CustomerData ON dbo.TB_Header_Order_Mentinence.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
"                         dbo.TB_Header_Order_Mentinence.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
"                         dbo.BD_TypeMintes ON dbo.TB_Header_Order_Mentinence.Mentinence_Type = dbo.BD_TypeMintes.Code AND  " & _
"                         dbo.TB_Header_Order_Mentinence.Compny_Code = dbo.BD_TypeMintes.Compny_Code INNER JOIN " & _
"                         dbo.TB_Detils_TypeMentince ON dbo.TB_Header_Order_Mentinence.Compny_Code = dbo.TB_Detils_TypeMentince.Compny_Code AND  " & _
"                         dbo.TB_Header_Order_Mentinence.OrderNo_Code = dbo.TB_Detils_TypeMentince.OrderNo_Code INNER JOIN " & _
"                         dbo.BD_ITEM ON dbo.TB_Detils_TypeMentince.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_TypeMentince.Code_Item = dbo.BD_ITEM.Code " & _
" WHERE        (dbo.TB_Header_Order_Mentinence.Compny_Code = '" & VarCodeCompny & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)

        GridView11.Columns(0).Width = "75"
        GridView11.Columns(1).Width = "100"
        GridView11.Columns(2).Width = "70"
        GridView11.Columns(3).Width = "200"
        GridView11.Columns(4).Width = "100"
        GridView11.Columns(5).Width = "100"
        GridView11.Columns(6).Width = "200"



        GridView11.Appearance.Row.Font = New Font(GridView11.Appearance.Row.Font, FontStyle.Bold)
        GridView11.Appearance.Row.Options.UseFont = True

        GridView11.Columns(0).Caption = "رقم الطلب"
        GridView11.Columns(1).Caption = "تاريخ الطلب "
        GridView11.Columns(2).Caption = "رقم الصنف "
        GridView11.Columns(3).Caption = "أسم الماكينة"
        GridView11.Columns(4).Caption = "أسم العميل"
        GridView11.Columns(5).Caption = "نوع الصيانة"
        GridView11.Columns(6).Caption = "ملاحظات"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub


    Private Sub txt_MachineName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachineName.ButtonClick
        vartable = "Vw_listItem"
        VarOpenlookup = 75
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachineName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachineName.EditValueChanged

    End Sub

    Private Sub Frm_Contract_M_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_TypM()
        find_All()
        fill_Unit()
        com_Fahs.Items.Add("طلب شراء")
        com_Fahs.Items.Add("طلب صرف")

        com_fahs2.Items.Add("طلب شراء")
        com_fahs2.Items.Add("طلب صرف")
    End Sub
    Sub fill_Unit()
        Com_Unit.Items.Clear()
        com_unit2.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit.Items.Add(rs("Name").Value)
            com_unit2.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Private Sub GridControl6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs)
       
    End Sub


    Sub Find()




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "    SELECT        dbo.BD_ITEM.Code, dbo.BD_ITEM.Name, dbo.TB_Detils_Contract.Discription_Machine " & _
    " FROM            dbo.TB_Detils_Contract INNER JOIN " & _
    "                         dbo.BD_ITEM ON dbo.TB_Detils_Contract.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_Contract.Code_Item = dbo.BD_ITEM.Code " & _
    " WHERE        (dbo.TB_Detils_Contract.Contract_Code = '" & value2 & "') AND (dbo.TB_Detils_Contract.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "75"
        GridView5.Columns(1).Width = "200"
        GridView5.Columns(2).Width = "200"



        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم الصنف"
        GridView5.Columns(1).Caption = "اسم الماكينة "
        GridView5.Columns(2).Caption = "وصف الماكينة"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

  

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear()
        find_detalis()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        On Error Resume Next
        If IsDate(txt_date.Text) = False Then MsgBox("من فضلك أدخل التاريخ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Com_CustomeName.Text = "" Then MsgBox("من فضلك اختار العميل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub


        '=========================تاريخ البداية
        Dim dd As DateTime = txt_date.Text
        Dim vardateOrder As String
        vardateOrder = dd.ToString("MM-d-yyyy")




        sql = "select * from TB_Header_Order_Mentinence where OrderNo_Code  = " & Com_OrderM_No.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

        Else

            Dim varcodecoustomer, varcodetypeM As Integer
            '========================================================رقم العميل
            sql = "SELECT *  FROM St_CustomerData where Customer_Name ='" & Com_CustomeName.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then varcodecoustomer = rs3("Customer_Code").Value
            '============================================================ نوع الصيانة

            sql = "SELECT *  FROM BD_TypeMintes where Name ='" & Com_Type.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then varcodetypeM = rs3("Code").Value




            sql = "INSERT INTO TB_Header_Order_Mentinence (OrderNo_Code, Compny_Code,Customer_Code,Order_Date,Mentinence_Type,Notes) " & _
                      " values  ('" & Com_OrderM_No.Text & "' ,'" & VarCodeCompny & "','" & varcodecoustomer & "','" & vardateOrder & "','" & varcodetypeM & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        find_detalis()
        'clear_detils()
        'find_detalis()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        varcustomername = Com_CustomeName.Text
        Frm_Cust.MdiParent = Mainmune
        'Frm_Cust.find_cust2()
        Frm_Cust.Show()
    End Sub

    Private Sub GridControl6_Click_3(sender As Object, e As EventArgs) Handles GridControl6.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        value2 = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(2))
        ValueOrderNo = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(0))


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "SELECT        dbo.Vw_ListItem2.Code, dbo.Vw_ListItem2.Name AS CompontentName, dbo.BD_ITEM.SiralNo, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS Balance, dbo.BD_Stores.Name " & _
            " FROM            dbo.BD_Stores INNER JOIN " & _
            "                         dbo.Statement_OfItem ON dbo.BD_Stores.Code = dbo.Statement_OfItem.Code_Stores AND dbo.BD_Stores.Compny_Code = dbo.Statement_OfItem.Compny_Code RIGHT OUTER JOIN " & _
            "                         dbo.TB_ItemComponent INNER JOIN " & _
            "                         dbo.Vw_ListItem ON dbo.TB_ItemComponent.Code_Item = dbo.Vw_ListItem.Code AND dbo.TB_ItemComponent.Compny_Code = dbo.Vw_ListItem.Compny_Code INNER JOIN " & _
            "                         dbo.Vw_ListItem2 ON dbo.TB_ItemComponent.Code_Item2 = dbo.Vw_ListItem2.Code AND dbo.TB_ItemComponent.Compny_Code = dbo.Vw_ListItem2.Compny_Code INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Vw_ListItem2.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Vw_ListItem2.Code = dbo.BD_ITEM.Code ON dbo.Statement_OfItem.NoItem = dbo.Vw_ListItem2.Code AND  " & _
            "        dbo.Statement_OfItem.Compny_Code = dbo.Vw_ListItem2.Compny_Code " & _
            " GROUP BY dbo.TB_ItemComponent.Code_Item, dbo.Vw_ListItem2.Name, dbo.BD_ITEM.SiralNo, dbo.Vw_ListItem2.Code, dbo.BD_Stores.Name, dbo.TB_ItemComponent.Compny_Code " & _
            " HAVING        (dbo.TB_ItemComponent.Code_Item = '" & value2 & "') AND (dbo.TB_ItemComponent.Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "120"
        GridView6.Columns(2).Width = "100"
        GridView6.Columns(3).Width = "100"
        GridView6.Columns(4).Width = "100"

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الصنف"
        GridView6.Columns(1).Caption = "اسم قطعة الغيار "
        GridView6.Columns(2).Caption = "السريال "
        GridView6.Columns(3).Caption = "الرصيد "
        GridView6.Columns(4).Caption = "المخزن "


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        find_component()
        find_component2()
    End Sub

    Private Sub GridControl6_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl6.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        value2 = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(0))
        clear()


        sql = "SELECT        dbo.TB_Header_Order_Mentinence.OrderNo_Code, dbo.TB_Header_Order_Mentinence.Order_Date, dbo.St_CustomerData.Customer_Name, dbo.St_CustomerData.Customer_Address,  " & _
                "                         dbo.St_CustomerData.Customer_Phon1, dbo.BD_TypeMintes.Name, dbo.TB_Header_Order_Mentinence.Notes " & _
                " FROM            dbo.TB_Header_Order_Mentinence INNER JOIN " & _
                "                         dbo.St_CustomerData ON dbo.TB_Header_Order_Mentinence.Compny_Code = dbo.St_CustomerData.Compny_Code AND  " & _
                "                         dbo.TB_Header_Order_Mentinence.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
                "                         dbo.BD_TypeMintes ON dbo.TB_Header_Order_Mentinence.Mentinence_Type = dbo.BD_TypeMintes.Code AND dbo.TB_Header_Order_Mentinence.Compny_Code = dbo.BD_TypeMintes.Compny_Code " & _
                "        WHERE(dbo.TB_Header_Order_Mentinence.Compny_Code = '" & VarCodeCompny & "') and  dbo.TB_Header_Order_Mentinence.OrderNo_Code ='" & value2 & "' "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_OrderM_No.Text = rs("OrderNo_Code").Value
            txt_date.Text = rs("Order_Date").Value
            Com_CustomeName.Text = rs("Customer_Name").Value
            txt_AddressCustomer.Text = rs("Customer_Address").Value
            txt_Phone.Text = rs("Customer_Phon1").Value
            txt_Notes.Text = rs("Notes").Value
            Com_Type.Text = rs("Name").Value
        End If
        find_customer2()
        TabPane1.SelectedPageIndex = 0
        find_detalis()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        txt_NameComponent.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))



    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        If txt_NameComponent.Text = "" Then MsgBox("من فضلك اختار قطعة الغيار", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_Qty.Text = "" Then MsgBox("من فضلك ادخل الكمية", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_Unit.Text = "" Then MsgBox("من فضلك اختار الوحدة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If com_Fahs.Text = "" Then MsgBox("من فضلك اختار نوع الاجراء", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub


        save_Component()
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_component()
    End Sub

    Sub save_Component()
        sql = "   SELECT *     FROM BD_ITEM    WHERE(name = '" & txt_NameComponent.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = Trim(rs("code").Value)

        sql = "   SELECT *    FROM BD_Unit    WHERE(name = '" & Com_Unit.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Code").Value




        If com_Fahs.Text = "طلب شراء" Then varflagorder = 2
        If com_Fahs.Text = "طلب صرف" Then varflagorder = 1

        sql = "INSERT INTO Tb_ComponentOrder_M (OrderNo_Code,Compny_Code,Code_Item,Qyt_Component,Code_Unit,Flag_Item_order,Code_ItemComponent) " & _
              " values  ('" & ValueOrderNo & "' ,'" & VarCodeCompny & "','" & value2 & "','" & txt_Qty.Text & "','" & varcodunit & "' ,'" & varflagorder & "','" & varcodeitem & "' )"
        Cnn.Execute(sql)


    End Sub

    Sub save_Tools()
        sql = "   SELECT *     FROM BD_ITEM    WHERE(name = '" & com_ToolsName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem2 = Trim(rs("code").Value)

        sql = "   SELECT *    FROM BD_Unit    WHERE(name = '" & com_unit2.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit2 = rs("Code").Value




        If com_fahs2.Text = "طلب شراء" Then varflagorder = 2
        If com_fahs2.Text = "طلب صرف" Then varflagorder = 1

        sql = "INSERT INTO Tb_ComponentOrder_M2 (OrderNo_Code,Compny_Code,Code_Item,Qyt_Component,Code_Unit,Flag_Item_order,Code_ItemComponent) " & _
              " values  ('" & ValueOrderNo & "' ,'" & VarCodeCompny & "','" & value2 & "','" & txt_qyt2.Text & "','" & varcodunit2 & "' ,'" & varflagorder & "','" & varcodeitem2 & "' )"
        Cnn.Execute(sql)


    End Sub

    Sub find_component()
        On Error Resume Next
    


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT     dbo.Tb_ComponentOrder_M.Code_ItemComponent, BD_ITEM_1.Name AS NameComponent, dbo.Tb_ComponentOrder_M.Qyt_Component, dbo.BD_Unit.Name AS UnitName, iif(dbo.Tb_ComponentOrder_M.Flag_Item_order=2,'طلب شراء','طلب صرف') as flag " & _
   " FROM            dbo.Tb_ComponentOrder_M INNER JOIN  " & _
   "                         dbo.BD_ITEM ON dbo.Tb_ComponentOrder_M.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Tb_ComponentOrder_M.Code_Item = dbo.BD_ITEM.Code INNER JOIN  " & _
   "                         dbo.BD_Unit ON dbo.Tb_ComponentOrder_M.Code_Unit = dbo.BD_Unit.Code AND dbo.Tb_ComponentOrder_M.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
   "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.Tb_ComponentOrder_M.Code_ItemComponent = BD_ITEM_1.Code AND dbo.Tb_ComponentOrder_M.Compny_Code = BD_ITEM_1.Compny_Code  " & _
   " WHERE        (dbo.Tb_ComponentOrder_M.OrderNo_Code = '" & ValueOrderNo & "') AND (dbo.Tb_ComponentOrder_M.Code_Item = '" & value2 & "') AND (dbo.Tb_ComponentOrder_M.Compny_Code = '" & VarCodeCompny & "')  "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Columns(0).Width = "100"
        GridView9.Columns(1).Width = "150"
        GridView9.Columns(2).Width = "70"
        GridView9.Columns(3).Width = "100"
        GridView9.Columns(4).Width = "100"

        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "رقم الصنف"
        GridView9.Columns(1).Caption = "اسم قطعة الغيار "
        GridView9.Columns(2).Caption = "الكمية "
        GridView9.Columns(3).Caption = "الوحدة "
        GridView9.Columns(4).Caption = "نوع الفحص "

        GridView9.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub find_component2()
        On Error Resume Next



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT     dbo.Tb_ComponentOrder_M2.Code_ItemComponent, BD_ITEM_1.Name AS NameComponent, dbo.Tb_ComponentOrder_M2.Qyt_Component, dbo.BD_Unit.Name AS UnitName, iif(dbo.Tb_ComponentOrder_M2.Flag_Item_order=2,'طلب شراء','طلب صرف') as flag " & _
   " FROM            dbo.Tb_ComponentOrder_M2 INNER JOIN  " & _
   "                         dbo.BD_ITEM ON dbo.Tb_ComponentOrder_M2.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Tb_ComponentOrder_M2.Code_Item = dbo.BD_ITEM.Code INNER JOIN  " & _
   "                         dbo.BD_Unit ON dbo.Tb_ComponentOrder_M2.Code_Unit = dbo.BD_Unit.Code AND dbo.Tb_ComponentOrder_M2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
   "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.Tb_ComponentOrder_M2.Code_ItemComponent = BD_ITEM_1.Code AND dbo.Tb_ComponentOrder_M2.Compny_Code = BD_ITEM_1.Compny_Code  " & _
   " WHERE        (dbo.Tb_ComponentOrder_M2.OrderNo_Code = '" & ValueOrderNo & "') AND (dbo.Tb_ComponentOrder_M2.Code_Item = '" & value2 & "') AND (dbo.Tb_ComponentOrder_M2.Compny_Code = '" & VarCodeCompny & "')  "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "150"
        GridView1.Columns(2).Width = "70"
        GridView1.Columns(3).Width = "100"
        GridView1.Columns(4).Width = "100"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "اسم الصنف "
        GridView1.Columns(2).Caption = "الكمية "
        GridView1.Columns(3).Caption = "الوحدة "
        GridView1.Columns(4).Caption = "نوع الفحص "

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_ComponentOrder_M  WHERE Code_ItemComponent = '" & varcode_Compontent & "' and OrderNo_Code ='" & ValueOrderNo & "' and Code_Item ='" & value2 & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_component()

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        varcode_Compontent = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(0))

        txt_NameComponent.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(1))
        txt_Qty.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(2))
        Com_Unit.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(3))
        com_Fahs.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(4))

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If com_ToolsName.Text = "" Then MsgBox("من فضلك اختار الادوات", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_qyt2.Text = "" Then MsgBox("من فضلك ادخل الكمية", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If com_unit2.Text = "" Then MsgBox("من فضلك اختار الوحدة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If com_fahs2.Text = "" Then MsgBox("من فضلك اختار نوع الاجراء", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub


        save_Tools()
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_component2()

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_ComponentOrder_M2  WHERE Code_ItemComponent = '" & varcode_Compontent2 & "' and OrderNo_Code ='" & ValueOrderNo & "' and Code_Item ='" & value2 & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_component2()

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        varcode_Compontent2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        com_ToolsName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_qyt2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        com_unit2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        com_fahs2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
    End Sub

    Private Sub com_ToolsName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_ToolsName.ButtonClick
        varcode_form = 2520
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub com_ToolsName_EditValueChanged(sender As Object, e As EventArgs) Handles com_ToolsName.EditValueChanged

    End Sub
End Class