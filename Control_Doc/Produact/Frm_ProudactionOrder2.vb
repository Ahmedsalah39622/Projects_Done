Imports System.Data.OleDb

Public Class Frm_ProudactionOrder2
    Dim varmaxno As Integer
    Private Sub Frm_ProudactionOrder2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub find_ref_prodact()
        sql2 = "     SELECT dbo.TB_Header_JOB_Order.Ref_JOBOrder, dbo.TB_Header_JOB_Order.Order_NO, dbo.BD_Item.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid, dbo.BD_Unit.Name AS Unit1, " & _
     "                  dbo.TB_Header_JOB_Order.Qyt_Requrid2, BD_Unit_1.Name AS Unit2, dbo.TB_Header_JOB_Order.Compny_Code " & _
     " FROM     dbo.TB_Header_JOB_Order INNER JOIN " & _
     "                  dbo.BD_Item ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code INNER JOIN " & _
     "                  dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
     "                  dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Code_Unit2 = BD_Unit_1.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code " & _
     " WHERE  (dbo.TB_Header_JOB_Order.Ref_JOBOrder ='" & txt_Ref.Text & "') AND (dbo.TB_Header_JOB_Order.Compny_Code = '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            txt_OrderNo.Text = rs("Order_NO").Value
            txt_ItemRequird.Text = rs("Name").Value
            txt_QtyRequird.Text = rs("Qyt_Requrid").Value
            txt_Unit.Text = rs("Unit1").Value
            txt_QtyRequird2.Text = rs("Qyt_Requrid2").Value
            txt_Unit_Kilo1.Text = rs("Unit2").Value
        Else
            txt_OrderNo.Text = ""
            txt_ItemRequird.Text = ""
            txt_QtyRequird.Text = ""
            txt_Unit.Text = ""
            txt_QtyRequird2.Text = ""
            txt_Unit_Kilo1.Text = ""
        End If

    End Sub

    Private Sub txt_Ref_TextChanged(sender As Object, e As EventArgs) Handles txt_Ref.TextChanged

    End Sub
    Sub find_Produactphaze1()
        sql = "  SELECT Ref_JOBOrder, JOB_Order, Name, Qyt, Unit, Qyt_FristItem2, UnitFinsh        FROM dbo.vw_All_Phases2 WHERE  (Ref_JOBOrder = '" & txt_Ref.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_ProdactPhaze2.Text = rs("Name").Value
            txt_countPhaze2.Text = rs("Qyt").Value
            txt_WhightPhaze2.Text = rs("Qyt_FristItem2").Value
           
        End If
    End Sub

    Sub find_ProduactActive()
        On Error Resume Next
        sql = "SELECT dbo.TB_Detils_QualityAprove.JOB_Order, SUM(dbo.TB_Detils_QualityAprove.NET_KG_ROLL) AS WActive, dbo.TB_Header_JOB_Order.Ref_JOBOrder, dbo.TB_Detils_QualityAprove.Compny_Code " & _
        " FROM     dbo.TB_Detils_QualityAprove INNER JOIN " & _
        "                  dbo.TB_Header_JOB_Order ON dbo.TB_Detils_QualityAprove.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND  " & _
        "        dbo.TB_Detils_QualityAprove.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code " & _
        " GROUP BY dbo.TB_Detils_QualityAprove.JOB_Order, dbo.TB_Header_JOB_Order.Ref_JOBOrder, dbo.TB_Detils_QualityAprove.Compny_Code " & _
        " HAVING (dbo.TB_Detils_QualityAprove.JOB_Order = '" & varJopOrder & "') AND (dbo.TB_Detils_QualityAprove.Compny_Code = '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_WActive.Text = rs("WActive").Value
            txt_Alhalek.Text = Val(txt_WhightPhaze2.Text) - rs("WActive").Value
            txt_NHalek.Text = Val(txt_Alhalek.Text) * 100 / Val(txt_WhightPhaze2.Text)

        End If
    End Sub
    Sub fill_Detials_JopOrder()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " SELECT dbo.TB_Header_JOB_Order.JOB_Order, dbo.TB_Detils_QualityAprove.SerialNo, dbo.TB_Detils_QualityAprove.LIGHT_ROLL, dbo.TB_Detils_QualityAprove.WIGHT_ROLL,  " & _
         "                  dbo.TB_Detils_QualityAprove.NET_KG_ROLL, dbo.TB_Detils_QualityAprove.Thickness, dbo.TB_Detils_QualityAprove.Notes " & _
         " FROM     dbo.TB_Header_JOB_Order INNER JOIN " & _
         "                  dbo.TB_Detils_QualityAprove ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Detils_QualityAprove.Compny_Code AND  " & _
         "        dbo.TB_Header_JOB_Order.JOB_Order = dbo.TB_Detils_QualityAprove.JOB_Order " & _
         " WHERE  (dbo.TB_Header_JOB_Order.Ref_JOBOrder ='" & txt_Ref.Text & "') AND (dbo.TB_Header_JOB_Order.Phas_No = 1) "






        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "50"
        GridView6.Columns(3).Width = "50"
        GridView6.Columns(4).Width = "50"
        GridView6.Columns(5).Width = "50"
        GridView6.Columns(6).Width = "200"

        GridView6.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم امر الشغل "
        GridView6.Columns(1).Caption = "رقم Searil"
        GridView6.Columns(2).Caption = "الطول"
        GridView6.Columns(3).Caption = "العرض"
        GridView6.Columns(4).Caption = "الوزن"
        GridView6.Columns(5).Caption = "السمك"
        GridView6.Columns(6).Caption = "ملاحظات"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub



    Sub fill_Detials_Prodact_Reqired()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "  SELECT dbo.TB_Header_JOB_Order.Item_No, dbo.BD_Item.Name, dbo.TB_Header_JOB_Order.Qyt_FristItem, dbo.TB_Header_JOB_Order.Qyt_FristItem2 " & _
            " FROM     dbo.TB_Header_JOB_Order INNER JOIN " & _
            "                  dbo.BD_Item ON dbo.TB_Header_JOB_Order.Item_No = dbo.BD_Item.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code " & _
            " WHERE  (dbo.TB_Header_JOB_Order.JOB_Order = '" & Com_InvoiceNo2.Text & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم المنتج"
        GridView5.Columns(1).Caption = "اسم المنتج"
        GridView5.Columns(2).Caption = "الكمية رول"
        GridView5.Columns(3).Caption = "الكمية الكيلو"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub




    Private Sub Com_NameItem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_NameItem.ButtonClick
        varcode_form = 25060
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub Com_NameItem_EditValueChanged(sender As Object, e As EventArgs) Handles Com_NameItem.EditValueChanged

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
       
        'last_Data()



        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم أمر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من  فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_ItemRequird.Text) = 0 Then MsgBox("من فضلك أختار المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        save_Order_H()

    End Sub
    Sub save_Order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        '============================================DeleviryDate
        Dim dd2 As DateTime = txt_date.Value
        Dim vardateoder2 As String
        vardateoder2 = dd2.ToString("MM-d-yyyy")



            '====================================رقم الصنف
        Dim varcodeitem, varcodeitem2, varcodeMachin, varcodeUnit, varcodeUnitFirst, varcodeshift, varcodeUnit2 As Integer

        sql = "    SELECT        Name, Compny_Code, Code           FROM dbo.BD_ITEM WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_ItemRequird.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeitem = rs("code").Value
            '=============================

            '=====================================رقم الماكينة
            sql = "    SELECT     *           FROM dbo.TB_MachineName WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_MachinName.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeMachin = rs("code").Value

        ''============================ الوحدة الاولى للمنتج المطلوب
        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeUnit = rs("code").Value


        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit_Kilo1.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeUnit2 = rs("code").Value

        '===============================

        sql = "    SELECT        Name, Compny_Code, Code           FROM dbo.BD_ITEM WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_NameItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem2 = rs("code").Value
        '=============================




            ''===========================رقم الوحدة المنتج التام
            ''
            'sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & com_unitFirstItem.Text & "')"
            'rs = Cnn.Execute(sql)
            'If rs.EOF = False Then varcodeUnitFirst = rs("code").Value

            ''================================================المنتج الاولى

            'sql2 = "   SELECT        Name, Compny_Code, Code FROM            dbo.BD_ITEM WHERE        (Name ='" & com_FirstItem.Text & "') AND (Compny_Code ='" & VarCodeCompny & "')"
            'rs = Cnn.Execute(sql2)
            'If rs.EOF = False Then varcodeitem2 = rs("Code").Value

            ''=======================================================مرحلة الانتاج
        sql2 = "   SELECT        Name, Code FROM            dbo.TB_Phases WHERE        (Name ='" & Trim("مرحلة انتاج 2") & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodePhases = rs("Code").Value
            ''================================================= shift
        sql2 = "   SELECT        Name, Code FROM            dbo.Vw_Shift WHERE        (Name ='" & Trim(Com_Shift.Text) & "') AND (Compny_Code ='" & VarCodeCompny & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcodeshift = rs("Code").Value
        



        last_Data()

        sql = "INSERT INTO TB_Header_JOB_Order (JOB_Order_Ser, Compny_Code,JOB_Order,JOBOrder_Date,Order_NO,No_Item,Qyt_Requrid,Code_Unit,Machine_No,Delivery_date,Phas_No,Item_No,Code_Unit_FirstItem,Qyt_FristItem,shift_No,Qyt_Requrid2,Code_Unit2,Qyt_FristItem2,Code_Unit_FirstItem2,Ref_JOBOrder) " & _
                  " values  ( '" & varmaxno & "','" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_OrderNo.Text & "','" & varcodeitem & "','" & txt_QtyRequird.Text & "','" & varcodeUnit & "','" & varcodeMachin & "','" & vardateoder2 & "','" & varcodePhases & "','" & varcodeitem2 & "','" & 2 & "','" & txt_QytRol2.Text & "','" & varcodeshift & "','" & txt_QtyRequird2.Text & "','" & 3 & "','" & txt_QytKilo2.Text & "','" & varcodeUnit2 & "','" & txt_Ref.Text & "')"
        Cnn.Execute(sql)




        'Next

    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(JOB_Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_JOB_Order    GROUP BY Compny_Code  HAVING        (MAX(JOB_Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varmaxno = rs("MaxMaim").Value + 1

  
        End If
    End Sub
    Private Sub Com_Shift_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shift.ButtonClick
        vartable = "vw_Shift"
        VarOpenlookup = 6400
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shift_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Shift.EditValueChanged

    End Sub

    Private Sub Cmd_OpenJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click
        vartable = "vw_Phases2"
        VarOpenlookup = 5001
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
       
        find_hedar()
        fill_Detials_Prodact_Reqired()

        find_ref_prodact()
        fill_Detials_JopOrder()
        find_Produactphaze1()
        varJopOrder = Com_InvoiceNo2.Text
        find_ProduactActive()
    End Sub


    Sub find_hedar()
        On Error Resume Next
        Dim varflagorder As Integer


        sql = "  Select * from Vw_AllJopOrder where JOB_Order = '" & Com_InvoiceNo2.Text & "' "
        varflagorder = 0


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = Trim(rs("JOB_Order").Value)
            txt_date.Text = Trim(rs("JOBOrder_Date").Value)
            txt_OrderNo.Text = Trim(rs("Order_NO").Value)
            txt_ItemRequird.Text = Trim(rs("Name").Value)
            txt_QtyRequird.Text = Trim(rs("Qyt_Requrid").Value)
            txt_Unit.Text = Trim(rs("Unit").Value)
            txt_MachinName.Text = Trim(rs("machineName").Value)
          
            Com_Shift.Text = Trim(rs("shiftName").Value)


            txt_Ref.Text = Trim(rs("Ref_JOBOrder").Value)

            txt_QtyRequird2.Text = Trim(rs("Qyt_Requrid2").Value)
            txt_Unit_Kilo1.Text = Trim(rs("UnitKilo1").Value)
        



            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green
        Else
            If varflagorder = 0 Then txt_flgOrder.Text = "مفتوح" : txt_flgOrder.BackColor = Color.White
            If varflagorder = 1 Then txt_flgOrder.Text = "مغلق" : txt_flgOrder.BackColor = Color.Green

        End If



    End Sub

    Private Sub com_EmpName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_EmpName.ButtonClick
        vartable = "vw_lookupEmp"
        VarOpenlookup = 6501
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles com_EmpName.EditValueChanged

    End Sub
End Class