Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Public Class Frm_ProudactionOrder
    Dim varflagorder As Integer
    Dim varcode_Orderstores, varcodeshift, varcodeEmp, varcodeEmp2, varcodeUnitKilo2, varcodeUnitKilo_First As Integer
    Dim varcode_Orderstores2 As String
    Dim varcodeExitem As String
    Dim ValueOrderNo As String
    Sub last_Data()

        sql = "  SELECT        MAX(JOB_Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_JOB_Order    GROUP BY Compny_Code  HAVING        (MAX(JOB_Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = txt_MachinName.Text + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = txt_MachinName.Text + "1"


        End If
    End Sub

    Private Sub txt_MachinName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachinName.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 38
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub








    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'txt_time_Order.Text = DateTime.Now.ToString
    End Sub


    Sub find_hedar()
        On Error Resume Next


        sql = "  Select * from Vw_AllJopOrder where JOB_Order = '" & Com_InvoiceNo2.Text & "' "
        varflagorder = 0


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("JOB_Order_Ser").Value)
            Com_InvoiceNo2.Text = Trim(rs("JOB_Order").Value)
            txt_date.Text = Trim(rs("JOBOrder_Date").Value)
            txt_OrderNo.Text = Trim(rs("Order_NO").Value)
            txt_ItemRequird.Text = Trim(rs("Name").Value)
            txt_QtyRequird.Text = Trim(rs("Qyt_Requrid").Value)
            txt_Unit.Text = Trim(rs("Unit").Value)
            txt_MachinName.Text = Trim(rs("machineName").Value)
            varflagorder = Trim(rs("Flg_JopOrder").Value)
            com_phases.Text = Trim(rs("Phases").Value)
            com_FirstItem.Text = Trim(rs("FirstName").Value)
            txt_QytFirst.Text = Trim(rs("Qyt_FristItem").Value)
            com_unitFirstItem.Text = Trim(rs("NameUnitFirst").Value)
            txt_EmpName.Text = Trim(rs("nameEmp").Value)
            txt_EmpName2.Text = Trim(rs("Emp_Name2").Value)
            Com_Shift.Text = Trim(rs("shiftName").Value)

            txt_customerName.Text = Trim(rs("Customer_No").Value)
            txt_Ref.Text = Trim(rs("Ref_JOBOrder").Value)

            txt_QtyRequird2.Text = Trim(rs("Qyt_Requrid2").Value)
            txt_Unit_Kilo1.Text = Trim(rs("UnitKilo1").Value)
            txt_Kilo_QytFirst.Text = Trim(rs("Qyt_FristItem2").Value)
            com_Kilo_unitFirstItem.Text = Trim(rs("UnitFirstKilo2").Value)




            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green
        Else
            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green

        End If



    End Sub
    Private Sub GridView5_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        GridView5.RowHeight = 20
        GridView5.GroupRowHeight = 1
        GridView5.RowSeparatorHeight = 1
        'GridView1.GroupRowHeight = 1


        'End If
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        BD_ITEM_1.Code AS Code_Matril, BD_ITEM_1.Name AS NameMatril, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name AS Unit2, dbo.BD_Stores.Name AS StoresName, " & _
        "                         dbo.TB_TypeMatril.Name AS TypeMatril " & _
        " FROM            dbo.TB_Detils_JOB_Order INNER JOIN " & _
        "                         dbo.TB_Header_JOB_Order ON dbo.TB_Detils_JOB_Order.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND  " & _
        "                         dbo.TB_Detils_JOB_Order.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Detils_JOB_Order.No_Matril = BD_ITEM_1.Code INNER JOIN " & _
        "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Detils_JOB_Order.Code_Unit = BD_Unit_1.Code INNER JOIN " & _
        "                         dbo.BD_Stores ON dbo.TB_Detils_JOB_Order.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_JOB_Order.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
        "                         dbo.TB_MachineName ON dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN " & _
        "                         dbo.TB_TypeMatril ON BD_ITEM_1.Code_TypeMatril = dbo.TB_TypeMatril.Code AND BD_ITEM_1.Compny_Code = dbo.TB_TypeMatril.Compny_Code " & _
        " WHERE        (dbo.TB_Detils_JOB_Order.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_JOB_Order.JOB_Order = '" & Com_InvoiceNo2.Text & "') " & _
        " GROUP BY BD_ITEM_1.Code, BD_ITEM_1.Name, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name, dbo.BD_Stores.Name, dbo.TB_TypeMatril.Name "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "250"
        GridView5.Columns(2).Width = "50"
        GridView5.Columns(3).Width = "100"
        GridView5.Columns(4).Width = "150"
        GridView5.Columns(5).Width = "100"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "كود المادة "
        GridView5.Columns(1).Caption = "أسم المادة الخام "
        GridView5.Columns(2).Caption = "الكمية"
        GridView5.Columns(3).Caption = "الوحدة"
        GridView5.Columns(4).Caption = "أسم المخزن"
        GridView5.Columns(5).Caption = "نوع الخام"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Sub clear_detils()
        txt_MatrilName.Text = ""
        txt_Qty.Text = ""
        txt_Unit2.Text = ""
        txt_NameStores.Text = ""
        txt_QtyAvalibl.Text = ""

    End Sub
    Sub save_Order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        '============================================DeleviryDate
        Dim dd2 As DateTime = Com_DateDelivery.Value
        Dim vardateoder2 As String
        vardateoder2 = dd2.ToString("MM-d-yyyy")



        sql = "select * from TB_Header_JOB_Order where JOB_Order_Ser  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then


        Else

            '====================================رقم الصنف
            Dim varcodeitem, varcodeitem2, varcodeMachin, varcodeUnit, varcodeUnitFirst As Integer
            sql = "    SELECT        Name, Compny_Code, Code           FROM dbo.BD_ITEM WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_ItemRequird.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeitem = rs("code").Value
            '=============================

            '=====================================رقم الماكينة
            sql = "    SELECT     *           FROM dbo.TB_MachineName WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_MachinName.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeMachin = rs("code").Value

            '============================
            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeUnit = rs("code").Value

            '===========================رقم الوحدة المنتج التام
            '
            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & com_unitFirstItem.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeUnitFirst = rs("code").Value

            '================================================المنتج الاولى

            sql2 = "   SELECT        Name, Compny_Code, Code FROM            dbo.BD_ITEM WHERE        (Name ='" & com_FirstItem.Text & "') AND (Compny_Code ='" & VarCodeCompny & "')"
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeitem2 = rs("Code").Value

            '=======================================================مرحلة الانتاج
            sql2 = "   SELECT        Name, Code FROM            dbo.TB_Phases WHERE        (Name ='" & Trim(com_phases.Text) & "') "
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodePhases = rs("Code").Value
            '================================================= shift
            sql2 = "   SELECT        Name, Code FROM            dbo.Vw_Shift WHERE        (Name ='" & Trim(Com_Shift.Text) & "') AND (Compny_Code ='" & VarCodeCompny & "') "
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeshift = rs("Code").Value
            '============================================================================= emp
            sql2 = "   SELECT        Name, Code FROM            dbo.vw_lookupEmp WHERE        (Name ='" & Trim(txt_EmpName.Text) & "') AND (Compny_Code ='" & VarCodeCompny & "') "
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeEmp = rs("Code").Value


            '============================================================================= emp
            sql2 = "   SELECT        Name, Code FROM            dbo.vw_lookupEmp WHERE        (Name ='" & Trim(txt_EmpName2.Text) & "') AND (Compny_Code ='" & VarCodeCompny & "') "
            rs2 = Cnn.Execute(sql2)
            If rs2.EOF = False Then varcodeEmp2 = rs2("Code").Value


            '=============================================unitKilo1
            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit_Kilo1.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeUnitKilo2 = rs("code").Value


            '==============================================unitkilo2

            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & com_Kilo_unitFirstItem.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeUnitKilo_First = rs("code").Value






            sql = "INSERT INTO TB_Header_JOB_Order (JOB_Order_Ser, Compny_Code,JOB_Order,JOBOrder_Date,Order_NO,No_Item,Qyt_Requrid,Code_Unit,Machine_No,Delivery_date,Phas_No,Item_No,Code_Unit_FirstItem,Qyt_FristItem,shift_No,Code_Emp,Qyt_Requrid2,Code_Unit2,Qyt_FristItem2,Code_Unit_FirstItem2,Code_Emp2,Ref_JOBOrder) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderNo.Text & "','" & varcodeitem & "','" & txt_QtyRequird.Text & "','" & varcodeUnit & "','" & varcodeMachin & "','" & vardateoder2 & "','" & varcodePhases & "','" & varcodeitem2 & "','" & varcodeUnitFirst & "','" & txt_QytFirst.Text & "','" & varcodeshift & "','" & varcodeEmp & "','" & txt_QtyRequird2.Text & "','" & varcodeUnitKilo2 & "','" & txt_Kilo_QytFirst.Text & "','" & varcodeUnitKilo_First & "','" & varcodeEmp2 & "','" & txt_Ref.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next

    End Sub
    Sub save_oderDetils()
        Dim varcode_Matril, varcodunit2, varcodestores As Integer

        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit2 = rs("Code").Value


        '============================Matril

        sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Name = '" & txt_MatrilName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Matril = Trim(rs("code").Value)

        '===============================stores\
        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_NameStores.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value


        sql = "INSERT INTO TB_Detils_JOB_Order (JOB_Order_Ser,JOB_Order,No_Matril,Quntity_Matril,Code_Unit,Compny_Code,Code_Stores,Ref_JOBOrder) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & Com_InvoiceNo2.Text & "','" & varcode_Matril & "','" & txt_Qty.Text & "','" & varcodunit2 & "','" & VarCodeCompny & "','" & varcodestores & "','" & txt_Ref.Text & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub Frm_ProudactionOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
   
    Private Sub Frm_ProudactionOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_date.Text = DateTime.Now.ToString
        Com_DateDelivery.Text = DateTime.Now.ToString
        Fill_SalseOrder()
        'Fill_Data()
    End Sub


    Sub Fill_Data()
        '    'On Error Resume Next

        '    Dim con As New OleDb.OleDbConnection
        '    Dim ss As String
        '    ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        '    con.ConnectionString = ss
        '    con.Open()

        '    'sql = "select * From Vw_JobOrder_AllStatus "

        '    sql = "    SELECT        dbo.vw_JobOrderEstlam.JOB_Order, dbo.vw_JobOrderEstlam.JOBOrder_Date,  " & _
        '"                          dbo.vw_JobOrderEstlam.Machin, dbo.vw_JobOrderEstlam.Delivery_date, dbo.vw_JobOrderEstlam.PhasesName,  " & _
        ' "       dbo.vw_JobOrderEstlam.NameItemFirst, dbo.vw_JobOrderEstlam.Qyt_FristItem, dbo.vw_JobOrderEstlam.UnitNameFirst, dbo.vw_JobOrderEstlam.statusJopOrder, dbo.vw_JobOrderEstlam.status, " & _
        '"                         iif(dbo.TB_Detils_AznAddItem.No_JopOrder IS NULL, 'غير مضاف', 'تم الاضافة') AS StoresStatus " & _
        '" FROM            dbo.vw_JobOrderEstlam LEFT OUTER JOIN " & _
        '"                         dbo.TB_Detils_AznAddItem ON dbo.vw_JobOrderEstlam.JOB_Order = dbo.TB_Detils_AznAddItem.No_JopOrder AND dbo.vw_JobOrderEstlam.ItemProduact = dbo.TB_Detils_AznAddItem.No_item " & _
        '" Where dbo.vw_JobOrderEstlam.Order_NO ='" & ValueOrderNo & "' "



        '    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        '    Dim ds As New DataSet()
        '    da.Fill(ds)
        '    GridControl1.DataSource = ds.Tables(0)

        '    'GridView2.Columns(0).Width = "100"
        '    'GridView2.Columns(1).Width = "100"
        '    'GridView2.Columns(2).Width = "100"
        '    'GridView2.Columns(3).Width = "100"
        '    'GridView2.Columns(4).Width = "100"
        '    'GridView2.Columns(5).Width = "100"
        '    'GridView2.Columns(6).Width = "100"
        '    'GridView2.Columns(7).Width = "100"
        '    'GridView2.Columns(8).Width = "100"
        '    'GridView2.Columns(9).Width = "100"
        '    'GridView2.Columns(10).Width = "100"


        '    GridView2.Appearance.Row.Font = New Font(GridView2.Appearance.Row.Font, FontStyle.Bold)
        '    GridView2.Appearance.Row.Options.UseFont = True


        '    GridView2.Columns(0).Caption = "رقم أمر الشغل"
        '    GridView2.Columns(1).Caption = "تاريخ أمر الشغل"
        '    GridView2.Columns(2).Caption = "الماكينة"
        '    GridView2.Columns(3).Caption = "تاريخ التسليم"
        '    GridView2.Columns(4).Caption = "المرحلة"
        '    GridView2.Columns(5).Caption = "أسم المنتج"
        '    GridView2.Columns(6).Caption = "الكمية"
        '    GridView2.Columns(7).Caption = ("الوحدة")
        '    GridView2.Columns(8).Caption = "حالة أمر الشغل"
        '    GridView2.Columns(9).Caption = "حالة الفحص"
        '    GridView2.Columns(10).Caption = "حالة المخزن"

        '    GridView2.BestFitColumns()
        '    ds = Nothing
        '    da = Nothing
        '    con.Close()
        '    con.Dispose()



    End Sub

    Sub Fill_SalseOrder()
        '        'On Error Resume Next

        '        Dim con As New OleDb.OleDbConnection
        '        Dim ss As String
        '        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        '        con.ConnectionString = ss
        '        con.Open()

        '        sql = " SELECT        dbo.vw_JobOrderEstlam.Order_NO, dbo.vw_JobOrderEstlam.No_Item, dbo.vw_JobOrderEstlam.Name, dbo.vw_JobOrderEstlam.Qyt_Requrid, dbo.vw_JobOrderEstlam.UnitRequird, " & _
        '"                         dbo.vw_JobOrderEstlam.NameCustomer " & _
        '"FROM            dbo.vw_JobOrderEstlam LEFT OUTER JOIN " & _
        '"                         dbo.TB_Detils_AznAddItem ON dbo.vw_JobOrderEstlam.JOB_Order = dbo.TB_Detils_AznAddItem.No_JopOrder AND dbo.vw_JobOrderEstlam.ItemProduact = dbo.TB_Detils_AznAddItem.No_item " & _
        '"GROUP BY dbo.vw_JobOrderEstlam.Order_NO, dbo.vw_JobOrderEstlam.No_Item, dbo.vw_JobOrderEstlam.Name, dbo.vw_JobOrderEstlam.Qyt_Requrid, dbo.vw_JobOrderEstlam.UnitRequird,  " & _
        '"        dbo.vw_JobOrderEstlam.NameCustomer "

        '        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        '        Dim ds As New DataSet()
        '        da.Fill(ds)
        '        GridControl2.DataSource = ds.Tables(0)



        '        'GridView1.Columns(0).Width = "75"
        '        'GridView4.Columns(0).Width = "100"
        '        'GridView4.Columns(1).Width = "120"
        '        'GridView4.Columns(2).Width = "270"
        '        'GridView4.Columns(3).Width = "100"
        '        'GridView4.Columns(4).Width = "100"
        '        'GridView4.Columns(5).Width = "150"



        '        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        '        GridView4.Appearance.Row.Options.UseFont = True


        '        GridView4.Columns(0).Caption = "رقم الطلبية"
        '        GridView4.Columns(1).Caption = "رقم الصنف المطلوب"
        '        GridView4.Columns(2).Caption = "أسم الصنف المطلوب"
        '        GridView4.Columns(3).Caption = "الكمية المطلوبة"
        '        GridView4.Columns(4).Caption = "الوحدة"
        '        GridView4.Columns(5).Caption = "أسم العميل"

        '        GridView4.BestFitColumns()

        '        ds = Nothing
        '        da = Nothing
        '        con.Close()
        '        con.Dispose()



    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
        'GridView1.GroupRowHeight = 1

        'End If
    End Sub

    Private Sub Cmd_OpenJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click
        vartable = "Lookup_JopOrder"
        VarOpenlookup = 39
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_heder()
        find_hedar()
        find_detalis()
        find_OrderSarf()
    End Sub
    Sub clear_heder()
        'txt_MachinName.Text = ""
        txt_customerName.Text = ""
        txt_ItemRequird.Text = ""
        txt_QtyRequird.Text = ""
        txt_Qty.Text = ""
        txt_OrderNo.Text = ""
        txt_MatrilName.Text = ""
        txt_Qty.Text = ""
        txt_NameStores.Text = ""
        com_phases.Text = ""
        com_FirstItem.Text = ""
        txt_QytFirst.Text = ""
        com_unitFirstItem.Text = ""
        txt_Unit2.Text = ""
        txt_Unit.Text = ""
        txt_OrderSarf.Text = ""
        txt_EmpName.Text = ""
        txt_EmpName2.Text = ""
        Com_Shift.Text = ""
        txt_QtyRequird2.Text = ""
        txt_Unit_Kilo1.Text = ""
        txt_Kilo_QytFirst.Text = ""
        com_Kilo_unitFirstItem.Text = ""
        txt_MachinName.Text = ""
        txt_date.Value = DateTime.Now
        'Dim vardateoder As String
        'txt_date.Value = dd.ToString("MM-d-yyyy")
    End Sub


    Sub find_OrderSarf()
        sql = "   Select Order_Stores_NO      FROM dbo.TB_Header_OrderItem_Stores WHERE        (JOB_Order ='" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_OrderSarf.Text = rs("Order_Stores_NO").Value Else txt_OrderSarf.Text = ""
    End Sub
    Sub Save_order_Stores()
        last_Data_orderStores()
        '==============================================SaveOrderStores

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")
        '====================================================
        sql = "INSERT INTO TB_Header_OrderItem_Stores (Ser_Order_Stores, Compny_Code,Order_Stores_NO,Order_Date_stores,Order_NO,Status_Order_Stores,JOB_Order) " & _
          " values  ('" & varcode_Orderstores & "' ,'" & VarCodeCompny & "','" & varcode_Orderstores2 & "','" & vardateoder & "','" & txt_OrderNo.Text & "','" & 1 & "','" & Com_InvoiceNo2.Text & "')"
        Cnn.Execute(sql)
        '=========================================
        sql2 = "SELECT        BD_ITEM_1.Code AS Code_Matril, BD_ITEM_1.Name AS NameMatril, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name AS Unit2, dbo.BD_Stores.Name AS StoresName, " & _
            "                         dbo.TB_TypeMatril.Name AS TypeMatril " & _
            " FROM            dbo.TB_Detils_JOB_Order INNER JOIN " & _
            "                         dbo.TB_Header_JOB_Order ON dbo.TB_Detils_JOB_Order.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND  " & _
            "                         dbo.TB_Detils_JOB_Order.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
            "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Detils_JOB_Order.No_Matril = BD_ITEM_1.Code INNER JOIN " & _
            "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Detils_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Detils_JOB_Order.Code_Unit = BD_Unit_1.Code INNER JOIN " & _
            "                         dbo.BD_Stores ON dbo.TB_Detils_JOB_Order.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_JOB_Order.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
            "                         dbo.TB_MachineName ON dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN " & _
            "                         dbo.TB_TypeMatril ON BD_ITEM_1.Code_TypeMatril = dbo.TB_TypeMatril.Code AND BD_ITEM_1.Compny_Code = dbo.TB_TypeMatril.Compny_Code " & _
            " WHERE        (dbo.TB_Detils_JOB_Order.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Detils_JOB_Order.JOB_Order = '" & Com_InvoiceNo2.Text & "') " & _
            " GROUP BY BD_ITEM_1.Code, BD_ITEM_1.Name, dbo.TB_Detils_JOB_Order.Quntity_Matril, BD_Unit_1.Name, dbo.BD_Stores.Name, dbo.TB_TypeMatril.Name "


        rs2 = Cnn.Execute(sql2)
        Do While Not rs2.EOF


            Dim varcode_Matril, varcodunit2 As Integer

            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & rs2("Unit2").Value & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit2 = rs("Code").Value


            '============================Matril

            sql = "   SELECT *  FROM BD_ITEM    WHERE(Name = '" & rs2("NameMatril").Value & "') and Compny_Code = '" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_Matril = Trim(rs("code").Value) : varcodeExitem = rs("Ex_Item").Value




            sql = "INSERT INTO TB_Detils_OrderItem_Stores (Ser_Order_Stores,Order_Stores_NO,Ex_Item,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,Flag_Item,JOB_Order) " & _
          " values  ('" & varcode_Orderstores & "','" & varcode_Orderstores2 & "','" & varcodeExitem & "','" & varcode_Matril & "','" & rs2("Quntity_Matril").Value & "','" & varcodunit2 & "','" & VarCodeCompny & "','" & txt_OrderNo.Text & "','1','" & Com_InvoiceNo2.Text & "')"
            Cnn.Execute(sql)


            rs2.MoveNext()
        Loop

        MsgBox("تم أنشاء طلب صرف رقم " + " " + Trim(Str(varcode_Orderstores)), MsgBoxStyle.Information)

    End Sub

    Sub last_Data_orderStores()

        sql = "  SELECT        MAX(Ser_Order_Stores) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem_Stores    GROUP BY Compny_Code  HAVING        (MAX(Ser_Order_Stores) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varcode_Orderstores = rs("MaxMaim").Value + 1
            varcode_Orderstores2 = "OS000" + Trim(Str(varcode_Orderstores))

        Else
            varcode_Orderstores = 1
            varcode_Orderstores2 = "OS000" + "1"


        End If
    End Sub








    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_JOB_Order where JOB_Order_Ser  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If

        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم أمر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم أمر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من  فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_ItemRequird.Text) = 0 Then MsgBox("من فضلك أختار المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_FirstItem.Text) = 0 Then MsgBox("من فضلك أختار المنتج الاولى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(com_unitFirstItem.Text) = 0 Then MsgBox("من فضلك أختار وحدةالمنتج الاولى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_QytFirst.Text) = 0 Then MsgBox("من فضلك أختار كمية المنتج الاولى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()

        save_oderDetils()
        clear_detils()
        find_detalis()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("  هل تريد حذف  أمر الشغل", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql2 = "    Select *            FROM dbo.TB_Header_AznItem_Stores WHERE  (Order_Stores_NO = '" & txt_OrderSarf.Text & "')"
                rs2 = Cnn.Execute(sql2)
                If rs2.EOF = False Then

                    MsgBox("المواد الخام تم صرفه على امر الشغل لايمكن حذفة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
                Else
                    sql = "Delete TB_Detils_JOB_Order  WHERE  JOB_Order ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)


                    sql = "Delete TB_Header_JOB_Order  WHERE JOB_Order ='" & Com_InvoiceNo2.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)


                    sql = "Delete TB_Detils_OrderItem_Stores  WHERE  JOB_Order ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)



                    sql = "Delete TB_Header_OrderItem_Stores  WHERE  JOB_Order ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                    rs = Cnn.Execute(sql)

                    find_detalis()
                    clear_detils()
                    MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module") : Exit Sub
                End If


              
        End Select
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Save_order_Stores()
        sql = "UPDATE   TB_Header_JOB_Order   SET Flg_JopOrder = 1 WHERE Flg_JopOrder = 0 and Compny_Code ='" & VarCodeCompny & "' and JOB_Order = '" & Com_InvoiceNo2.Text & "' "
        rs = Cnn.Execute(sql)
        find_hedar()
        find_OrderSarf()

    End Sub

    Private Sub Cmd_NewJobOrder_Click_1(sender As Object, e As EventArgs) Handles Cmd_NewJobOrder.Click
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        last_Data()
        find_hedar()
        find_detalis()
        clear_heder()

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Frm_OrderItem.Com_InvoiceNo2.Text = txt_OrderSarf.Text
        Frm_OrderItem.find_hedar()
        Frm_OrderItem.find_detalis()
        Frm_OrderItem.MdiParent = Mainmune
        Frm_OrderItem.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Frm_AznSarf.MdiParent = Mainmune
        Frm_AznSarf.Show()
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        If Len(txt_MatrilName.Text) = 0 Then MsgBox("من فضلك أختار أسم الخام ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '===================================CodeItem
        sql2 = "   SELECT        Name, Compny_Code, Code FROM            dbo.BD_ITEM WHERE        (Name ='" & txt_MatrilName.Text & "') AND (Compny_Code ='" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '============================================
        Frm_LookUpGardItem.Search()
        Frm_LookUpGardItem.MdiParent = Mainmune
        Frm_LookUpGardItem.Show()
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs)
        If Len(txt_ItemRequird.Text) = 0 Then MsgBox("من فضلك أختار أسم الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '===================================CodeItem
        sql2 = "   SELECT        Name, Compny_Code, Code FROM            dbo.BD_ITEM WHERE        (Name ='" & txt_ItemRequird.Text & "') AND (Compny_Code ='" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '============================================
        Frm_LookUpGardItem.Search()
        Frm_LookUpGardItem.MdiParent = Mainmune
        Frm_LookUpGardItem.Show()

    End Sub

    Private Sub txt_ItemRequird_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_ItemRequird.ButtonClick
        Frm_LookupOrderItem3.Close()
        Frm_LookupOrderItem3.MdiParent = Mainmune
        Frm_LookupOrderItem3.Show()
    End Sub

    Private Sub txt_ItemRequird_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_ItemRequird.EditValueChanged

    End Sub

    Private Sub txt_MatrilName_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MatrilName.ButtonClick
        Frm_LookupMatril.Close()
        Frm_LookupMatril.MdiParent = Mainmune
        Frm_LookupMatril.Show()
    End Sub

    Private Sub txt_MatrilName_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_MatrilName.EditValueChanged

    End Sub

    Private Sub txt_MachinName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachinName.EditValueChanged

    End Sub

    Private Sub ButtonEdit2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_FirstItem.ButtonClick
        vartable = "Vw_Item"
        VarOpenlookup = 57
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_phases.ButtonClick
        vartable = "Tb_Phases"
        VarOpenlookup = 58
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles com_phases.EditValueChanged

    End Sub

    Private Sub ButtonEdit2_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_unitFirstItem.ButtonClick
        vartable = "BD_Unit"
        VarOpenlookup = 59
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit2_EditValueChanged_1(sender As Object, e As EventArgs) Handles com_unitFirstItem.EditValueChanged

    End Sub

  
   
    Private Sub GridControl2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs)
        'Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        'ValueOrderNo = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        'Fill_Data()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)
        If Len(com_FirstItem.Text) = 0 Then MsgBox("من فضلك أختار أسم المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '===================================CodeItem
        sql2 = "   SELECT        Name, Compny_Code, Code FROM            dbo.BD_ITEM WHERE        (Name ='" & com_FirstItem.Text & "') AND (Compny_Code ='" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '============================================
        Frm_LookUpGardItem.Search()
        Frm_LookUpGardItem.MdiParent = Mainmune
        Frm_LookUpGardItem.Show()

    End Sub

   

   
    
    Private Sub Com_Shift_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub com_Kilo_unitFirstItem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_Kilo_unitFirstItem.ButtonClick
        vartable = "BD_Unit"
        VarOpenlookup = 66
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub com_Kilo_unitFirstItem_EditValueChanged(sender As Object, e As EventArgs) Handles com_Kilo_unitFirstItem.EditValueChanged

    End Sub

    Private Sub Com_Shift_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shift.ButtonClick
        vartable = "vw_Shift"
        VarOpenlookup = 64
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shift_EditValueChanged_1(sender As Object, e As EventArgs) Handles Com_Shift.EditValueChanged

    End Sub

    Private Sub txt_Unit2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Unit2.ButtonClick
        vartable = "BD_Unit"
        VarOpenlookup = 660
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_Unit2_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Unit2.EditValueChanged

    End Sub

    Private Sub txt_EmpName_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_EmpName2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_EmpName2.ButtonClick
        vartable = "vw_lookupEmp"
        VarOpenlookup = 650
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_EmpName2_EditValueChanged(sender As Object, e As EventArgs) Handles txt_EmpName2.EditValueChanged

    End Sub

    Private Sub com_FirstItem_EditValueChanged(sender As Object, e As EventArgs) Handles com_FirstItem.EditValueChanged

    End Sub

    Private Sub txt_EmpName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_EmpName.ButtonClick
        vartable = "vw_lookupEmp"
        VarOpenlookup = 65
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_EmpName_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_EmpName.EditValueChanged

    End Sub

    Private Sub LabelX21_Click(sender As Object, e As EventArgs) Handles LabelX21.Click

    End Sub
End Class