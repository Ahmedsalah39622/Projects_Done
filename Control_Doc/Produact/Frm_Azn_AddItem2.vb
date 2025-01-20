Imports System.Data.OleDb

Public Class Frm_Azn_AddItem2



    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = True
    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs)
        'If Op1.Checked = True Or Op2.Checked = True Then
        '    cmd_FindItem.Enabled = True
        'Else
        '    cmd_FindItem.Enabled = False
        'End If
    End Sub

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Frm_Azn_AddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 1 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 0 'الصفحة التالية


    End Sub

    Private Sub Frm_Azn_AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_TypeItem.Items.Add("منتج تصنيع")
        Com_TypeItem.Items.Add("منتج أمر شراء")
        Com_TypeItem.Items.Add("مرتجع")
        Com_TypeItem.Items.Add("هالك")
        Search()
        fill_Unit()
    End Sub
    Sub fill_Unit()
        txt_unit.Items.Clear()
        txt_unit2.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_unit.Items.Add(rs("Name").Value)
            txt_unit2.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub clear_detils()
        'txt_MachinName.Text = ""
        Com_NameItem.Text = ""
        txt_QytItem.Text = ""
        Txt_New_NameItem.Text = ""
        txt_MachinName.Text = ""
        txt_unit.Text = ""
        txt_unit2.Text = ""
        txt_Customer.Text = ""
    End Sub

    Private Sub cmd_FindItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Sub find_hedar()
        On Error Resume Next
        '      sql = "  SELECT        dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AS Code, dbo.TB_Header_AznAddItem.Date_StoresAdd AS Date_StoresAdd, dbo.TB_Header_AznAddItem.NO_FahsEstlamOrder, dbo.Vw_Emp.Emp_Name,  " & _
        '"                     dbo.TB_Header_AznAddItem.FlagItemType, dbo.TB_Header_AznAddItem.TypeAdd,dbo.TB_Header_AznAddItem.Notes " & _
        '" FROM            dbo.TB_Header_AznAddItem INNER JOIN " & _
        '"                         dbo.Vw_Emp ON dbo.TB_Header_AznAddItem.Code_AminStores = dbo.Vw_Emp.Emp_Code  WHERE        ( dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_AznAddItem.Compny_Code = '" & VarCodeCompny & "')  "

        sql = "     SELECT        dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AS Code, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.NO_FahsEstlamOrder, dbo.Vw_Emp.Emp_Name, " & _
     "                         dbo.TB_Header_AznAddItem.FlagItemType, dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Header_AznAddItem.Notes, dbo.FindCustomer.Name " & _
     " FROM            dbo.TB_Header_AznAddItem INNER JOIN " & _
     "                         dbo.Vw_Emp ON dbo.TB_Header_AznAddItem.Code_AminStores = dbo.Vw_Emp.Emp_Code LEFT OUTER JOIN " & _
     "                         dbo.FindCustomer ON dbo.TB_Header_AznAddItem.Code_Customer = dbo.FindCustomer.code AND dbo.TB_Header_AznAddItem.Compny_Code = dbo.FindCustomer.Compny_Code " & _
     " WHERE        (dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_AznAddItem.Compny_Code ='" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = Trim(rs("Code").Value)
            txt_date.Text = Trim(rs("Date_StoresAdd").Value)
            'txt_ِAznno.Text = Trim(rs("NO_FahsEstlamOrder").Value)
            txt_AminStores.Text = Trim(rs("Emp_Name").Value)
            Com_TypeItem.Text = Trim(rs("TypeAdd").Value)
            txt_Customer.Text = Trim(rs("Name").Value)
            'If rs("FlagItemType").Value = 1 Then Op1.Checked = True
            'If rs("FlagItemType").Value = 2 Then Op2.Checked = True

        End If
    End Sub
    Sub save_Order_H()
        'On Error Resume Next
        Dim varcodeamin, varflagtype As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateorder As String
        vardateorder = dd.ToString("MM-d-yyyy")

        'If Op1.Checked = True Then varflagtype = 1
        'If Op2.Checked = True Then varflagtype = 2
        'If Op3.Checked = True Then varflagtype = 3


        sql = "select * from TB_Header_AznAddItem where Ser_NO_StoresAdd  = " & Com_InvoiceNo2.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then


        Else

            '=============================================
            sql = "SELECT        Emp_Code, Emp_Name          FROM dbo.Vw_Emp WHERE        (Emp_Name = '" & txt_AminStores.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeamin = rs("Emp_Code").Value
            '========================================================
            sql = "SELECT      *         FROM dbo.FindCustomer WHERE         Compny_Code ='" & VarCodeCompny & "' and Name = '" & txt_Customer.Text & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodecustomer = rs("code").Value
            '===============================================================

            sql2 = "INSERT INTO TB_Header_AznAddItem (Ser_NO_StoresAdd, Compny_Code,Date_StoresAdd,Code_AminStores,FlagItemType,TypeAdd,Notes,NO_FahsEstlamOrder,Code_Customer) " & _
                      " values  ('" & Com_InvoiceNo2.Text & "' ,'" & VarCodeCompny & "','" & vardateorder & "','" & varcodeamin & "','" & varflagtype & "','" & Com_TypeItem.Text & "','" & Txt_Notes.Text & "','" & Com_InvoiceNo2.Text & "','" & varcodecustomer & "')"
            Cnn.Execute(sql2)



        End If
        'Next

    End Sub
    Sub save_oderDetils()
        Dim varcode_Item, varcodunit1, varcodunit2 As Integer

        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_unit.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit1 = rs("Code").Value

        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_unit2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit2 = rs("Code").Value

        '============================Item

        sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Name = '" & Com_NameItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = Trim(rs("code").Value)

        ''===============================stores\
        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_StoresNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value



        sql = "INSERT INTO TB_Detils_AznAddItem (Ser_NO_StoresAdd,No_item,Qyt,Code_Unit,Compny_Code,Code_Stores,Code_Unit2,Qyt2,Item_Discription) " & _
              " values  ('" & Com_InvoiceNo2.Text & "' ,'" & varcode_Item & "','" & txt_QytItem.Text & "','" & varcodunit1 & "','" & VarCodeCompny & "','" & varcodestores & "','" & varcodunit2 & "','" & txt_QytItem2.Text & "','" & Txt_New_NameItem.Text & "')"
        Cnn.Execute(sql)



    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(Ser_NO_StoresAdd) AS MaxMaim,Compny_Code FROM            TB_Header_AznAddItem    GROUP BY Compny_Code  HAVING        (MAX(Ser_NO_StoresAdd) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = rs("MaxMaim").Value + 1


        Else
            Com_InvoiceNo2.Text = 1



        End If
    End Sub
    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        'sql2 = "SELECT        dbo.TB_Detils_AznAddItem.No_item, dbo.BD_ITEM.Name, dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS UnitName, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_1.Name AS Unit2, " & _
        '"                         dbo.TB_Detils_AznAddItem.No_JopOrder, dbo.BD_Stores.Name AS NameStores, dbo.TB_Header_JOB_Order.Order_NO " & _
        '" FROM            dbo.TB_Detils_AznAddItem INNER JOIN " & _
        '"                         dbo.BD_ITEM ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_AznAddItem.No_item = dbo.BD_ITEM.Code INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
        '"                         dbo.TB_Header_JOB_Order ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code AND  " & _
        '"                         dbo.TB_Detils_AznAddItem.No_JopOrder = dbo.TB_Header_JOB_Order.JOB_Order AND dbo.TB_Detils_AznAddItem.No_item = dbo.TB_Header_JOB_Order.Item_No INNER JOIN " & _
        '"                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 = BD_Unit_1.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code " & _
        '" WHERE        (dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_AznAddItem.Compny_Code = '" & VarCodeCompny & "') "

        'sql2 = "SELECT        dbo.TB_Detils_AznAddItem.No_item, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS UnitName, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_1.Name AS Unit2, " & _
        '"                         dbo.TB_Detils_AznAddItem.No_JopOrder, dbo.BD_Stores.Name AS NameStores, dbo.TB_Header_JOB_Order.Order_NO  " & _
        '" FROM            dbo.BD_Unit AS BD_Unit_1 INNER JOIN " & _
        '"                         dbo.TB_Header_JOB_Order ON BD_Unit_1.Code = dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 AND BD_Unit_1.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code RIGHT OUTER JOIN " & _
        '"                         dbo.TB_Detils_AznAddItem INNER JOIN " & _
        '"                         dbo.BD_Item ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code ON  " & _
        '"         dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Detils_AznAddItem.Compny_Code And dbo.TB_Header_JOB_Order.JOB_Order = dbo.TB_Detils_AznAddItem.No_JopOrder And " & _
        '"  dbo.TB_Header_JOB_Order.Item_No = dbo.TB_Detils_AznAddItem.No_item " & _
        '" WHERE        (dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_AznAddItem.Compny_Code = '" & VarCodeCompny & "') "

        sql2 = "  SELECT        dbo.TB_Detils_AznAddItem.No_item, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Item_Discription, dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS UnitName,dbo.TB_Detils_AznAddItem.Qyt2, BD_Unit_1.Name AS Unit2, " & _
  "        dbo.BD_Stores.Name AS NameStores " & _
  " FROM            dbo.BD_Unit AS BD_Unit_1 INNER JOIN " & _
  "                         dbo.TB_Detils_AznAddItem INNER JOIN " & _
  "                         dbo.BD_Item ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code INNER JOIN " & _
  "                         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
  "                         dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code ON  " & _
  "        BD_Unit_1.Code = dbo.TB_Detils_AznAddItem.Code_Unit2 And BD_Unit_1.Compny_Code = dbo.TB_Detils_AznAddItem.Compny_Code " & _
  " WHERE        (dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_AznAddItem.Compny_Code ='" & VarCodeCompny & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        'GridView5.Columns(0).Width = "100"
        'GridView5.Columns(1).Width = "250"
        'GridView5.Columns(2).Width = "75"
        'GridView5.Columns(3).Width = "100"
        'GridView5.Columns(4).Width = "100"
        'GridView5.Columns(5).Width = "100"
        'GridView5.Columns(6).Width = "100"
        'GridView5.Columns(7).Width = "100"
        'GridView5.Columns(8).Width = "100"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم الصنف "
        GridView5.Columns(1).Caption = "أسم الصنف "
        GridView5.Columns(2).Caption = "بيان الصنف "
        GridView5.Columns(3).Caption = "عدد الرولات"
        GridView5.Columns(4).Caption = "الوحدة1"
        GridView5.Columns(5).Caption = "الكمية بالكيلو"
        GridView5.Columns(6).Caption = "الوحدة2"

        GridView5.Columns(7).Caption = "أسم المخزن"


        GridView5.BestFitColumns()



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

    Sub Search()
        'On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        '       sql2 = " SELECT        dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.NO_FahsEstlamOrder, dbo.TB_Header_AznAddItem.TypeAdd, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Qyt, " & _
        '"                         dbo.BD_Unit.Name AS UnitName, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_1.Name AS UnitName2, dbo.TB_Detils_AznAddItem.No_JopOrder, dbo.BD_Stores.Name AS NameStores " & _
        '" FROM            dbo.BD_Unit AS BD_Unit_1 INNER JOIN " & _
        '"                         dbo.TB_Header_JOB_Order ON BD_Unit_1.Code = dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 AND BD_Unit_1.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code RIGHT OUTER JOIN " & _
        '"                         dbo.TB_Detils_AznAddItem INNER JOIN " & _
        '"                         dbo.BD_Item ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                         dbo.TB_Header_AznAddItem ON dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AND  " & _
        '"                         dbo.TB_Detils_AznAddItem.Compny_Code = dbo.TB_Header_AznAddItem.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code ON  " & _
        '"        dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Detils_AznAddItem.Compny_Code And dbo.TB_Header_JOB_Order.JOB_Order = dbo.TB_Detils_AznAddItem.No_JopOrder " & _
        '" WHERE        (dbo.TB_Detils_AznAddItem.Compny_Code = '" & VarCodeCompny & "')"

        sql2 = "select * from vw_Aznadditem_data where Compny_Code = '" & VarCodeCompny & "' "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

     

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن "
        GridView1.Columns(1).Caption = "رقم اذن الاستلام "
        GridView1.Columns(2).Caption = "نوع الاضافة"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الكمية بالرول"
        GridView1.Columns(5).Caption = "الوحدة1"
        GridView1.Columns(6).Caption = "الكمية بالكيلو"
        GridView1.Columns(7).Caption = "الوحدة2"
        GridView1.Columns(8).Caption = "رقم التشغيلة"
        GridView1.Columns(9).Caption = "أسم المخزن"
        GridView1.Columns(10).Caption = "أسم العميل"
        GridView1.BestFitColumns()

        GridView1.Columns(11).Visible = False
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Sub save_itemStores()
        Dim varcodunit, varcodunit2, varcodStores, varcode_Item As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & txt_unit2.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value
        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_StoresNo.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        '============================Item

        sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Name = '" & Com_NameItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = Trim(rs("code").Value)

        '====================================================وحدة الرول
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Txt_New_NameItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit2 = rs("code").Value





        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,Compny_Code,Order_AddStores_NO,Count_exp,Count_imp,Code_Unit2) " & _
            " values ('" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & varcode_Item & " ', '" & varcodunit & "','" & varcodStores & "','" & 20 & "' " & _
            " ,'" & vardateinvoice & "','" & "أذن اضافة الى المخزن" + Com_InvoiceNo2.Text & "','" & txt_QytItem.Text & "','" & 1 & "','" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & txt_QytItem.Text & "','" & 0 & "','" & varcodunit2 & "') "
        Cnn.Execute(sql)

    End Sub



    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_NameItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_QytItem.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_TypeItem.Text) = 0 Then MsgBox("من  فضلك ادخل  نوع الاضافة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_StoresNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AminStores.Text) = 0 Then MsgBox("من  فضلك ادخل أسم أمين المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "select * from TB_Header_AznAddItem where Ser_NO_StoresAdd  = '" & Trim(Com_InvoiceNo2.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم اذن الاضافة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        save_Order_H()

        save_oderDetils()
        save_itemStores()

        clear_detils()
        find_detalis()
    End Sub

    Private Sub Cmd_OpenJobOrder_Click_1(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click
        vartable = "vw_Lookup_AznAddItem"
        VarOpenlookup = 62
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_OpenJobOrder_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.ContextMenuStripChanged

    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_hedar()
        find_detalis()
        clear_detils()
    End Sub

   

   

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        clear_detils()
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        If Len(varJopOrder) = 0 Then MsgBox("من  فضلك أختار الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Frm_ProudactionOrder.Com_InvoiceNo2.Text = varJopOrder

        Frm_ProudactionOrder.find_hedar()
        Frm_ProudactionOrder.find_detalis()
        Frm_ProudactionOrder.MdiParent = Mainmune
        Frm_ProudactionOrder.Show()
    End Sub

    Private Sub Com_StoresNo_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub

    Private Sub txt_MachinName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
       
    End Sub




    Private Sub txt_MachinName_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Com_StoresNo_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "BD_Stores"
        VarOpenlookup = 61
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_StoresNo_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GridView5.ShowPrintPreview()
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub Com_NameItem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_NameItem.ButtonClick
        vartable = "vw_allItemOrder"
        VarOpenlookup = 111123
        frm_LookupNewOrder.ShowDialog()
    End Sub

   
    Private Sub Com_NameItem_EditValueChanged(sender As Object, e As EventArgs) Handles Com_NameItem.EditValueChanged

    End Sub

    Private Sub txt_AminStores_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AminStores.ButtonClick
        VarOpenlookup2 = 60
        Frm_LookupUser.ShowDialog()
    End Sub

    Private Sub txt_AminStores_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AminStores.EditValueChanged

    End Sub

    Private Sub txt_MachinName_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachinName.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 63
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachinName_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_MachinName.EditValueChanged

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Com_StoresNo_ButtonClick2(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_StoresNo.ButtonClick
        vartable = "BD_Stores"
        VarOpenlookup = 61
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_StoresNo_EditValueChanged_1(sender As Object, e As EventArgs) Handles Com_StoresNo.EditValueChanged

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        varcodeitem = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        txt_codeItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Com_NameItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        Txt_New_NameItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        varnameDiscription = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        txt_QytItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))
        txt_unit.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(4))

        txt_QytItem2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(5))
        txt_unit2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(6))

        Com_StoresNo.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(7))

      

        'If txt_codeItem.Text <> "" Then cmd_Edit.Enabled = True
        'If txt_codeItem.Text <> "" Then Cmd_Delete.Enabled = True
    End Sub

    Private Sub Cmd_DeleteLine_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteLine.Click
        On Error Resume Next

        '=============================================معرفة الصنف على فاتورة ام لا
        sql = " SELECT        No_Item, Ext_InvoiceNo, Order_Stores_NO, Compny_Code      FROM dbo.Vw_DetilsInvoice WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_Stores_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item = '" & txt_codeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف موجود على فاتورة لايمكن حذفة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '===============================================


        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_AznAddItem  WHERE No_Item = '" & varcodeitem & "' and Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "'  and Item_Discription ='" & varnameDiscription & "' "
                rs = Cnn.Execute(sql)



                '===================================حذف من المخزن
                sql = "Delete Statement_OfItem  WHERE NoItem = '" & varcodeitem & "' and TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
                rs = Cnn.Execute(sql)




               




                find_detalis()
                clear_detils()
               
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        On Error Resume Next
     

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        '===================================================================رقم المخزن
        ''===============================stores\
        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_StoresNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value

        '=================================================رقم الوحدة 

        sql = "   SELECT *    FROM BD_unit   WHERE(Name = '" & txt_unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_unit = rs("Code").Value

        '========================================================
        sql = "SELECT      *         FROM dbo.FindCustomer WHERE         Compny_Code ='" & VarCodeCompny & "' and Name = '" & txt_Customer.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodecustomer = rs("code").Value
        '===============================================================

        ''===============================================تعديل Hedare
        sql2 = "UPDATE  TB_Header_AznAddItem  SET Date_StoresAdd ='" & vardateoder & "', TypeAdd='" & Com_TypeItem.Text & "', Code_Customer ='" & varcodecustomer & "',notes='" & Txt_Notes.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql2)
        ''===================================================تعديل سطر
        sql = "UPDATE TB_Detils_AznAddItem set Qyt ='" & txt_QytItem.Text & "', Code_Unit ='" & varcode_unit & "' , Item_Discription ='" & Trim(Txt_New_NameItem.Text) & "', Qyt2 ='" & txt_QytItem2.Text & "',Code_Stores ='" & varcodestores & "'  WHERE   No_Item = '" & txt_codeItem.Text & "' and Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '===================================تعديل فى حركة المخازن
        sql = "update Statement_OfItem set Import ='" & txt_QytItem2.Text & "' WHERE NoItem = '" & txt_codeItem.Text & "' and TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
        rs = Cnn.Execute(sql)

        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_DeletFinsh_Click(sender As Object, e As EventArgs) Handles Cmd_DeletFinsh.Click
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_AznAddItem  WHERE  Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete TB_Header_AznAddItem  WHERE  Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '===================================حذف من المخزن
                sql = "Delete Statement_OfItem  WHERE TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "' and NumberBill ='" & Com_InvoiceNo2.Text & "'  "
                rs = Cnn.Execute(sql)



              

                find_hedar()
                find_detalis()
              

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub txt_Customer_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Customer.ButtonClick
        VarOpenlookup2 = 240240
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_Customer_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Customer.EditValueChanged

    End Sub
End Class