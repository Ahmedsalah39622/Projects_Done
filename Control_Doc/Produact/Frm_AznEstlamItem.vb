Imports System.Data.OleDb

Public Class Frm_AznEstlamItem

    Private Sub txt_MatrilName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_ItemName.ButtonClick
        If RadioButton1.Checked = True Then

            Frm_LookupFinshItem.MdiParent = Mainmune
            Frm_LookupFinshItem.find_data()
            Frm_LookupFinshItem.Show()

        End If

        If RadioButton2.Checked = True Then

            Frm_LookupFinshItem.MdiParent = Mainmune
            Frm_LookupFinshItem.find_data2()
            Frm_LookupFinshItem.Show()

        End If

    End Sub


    Private Sub txt_MatrilName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_ItemName.EditValueChanged

    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_NewJobOrder.Click
        'If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        last_Data()
        find_hedar()
        find_detalis()
        clear_detils()
    End Sub
    Sub find_hedar()
        sql = "  SELECT       Ser_Azn_Estlam, Order_Azn_Estlam_NO, Order_Date_Azn_Estlam, Flg_Azn_Estlam     FROM dbo.TB_Header_AznEstlam " & _
        " WHERE        (Order_Azn_Estlam_NO = '" & Com_InvoiceNo2.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Ser_Azn_Estlam").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_Azn_Estlam_NO").Value)
            txt_date.Text = Trim(rs("Order_Date_Azn_Estlam").Value)


            If rs("Flg_Azn_Estlam").Value = 1 Then RadioButton1.Checked = True
            If rs("Flg_Azn_Estlam").Value = 2 Then RadioButton2.Checked = True

        End If
    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Ser_Azn_Estlam) AS MaxMaim,Compny_Code FROM            TB_Header_AznEstlam    GROUP BY Compny_Code  HAVING        (MAX(Ser_Azn_Estlam) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "ES" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "ES" + "1"


        End If
    End Sub

   
    Sub clear_detils()
        'txt_MachinName.Text = ""
        txt_ItemName.Text = ""
        txt_Qty.Text = ""
        txt_OrderNo.Text = ""
        txt_NoJopOrder.Text = ""
        txt_Unit2.Text = ""
    End Sub
    Sub save_Order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")




        sql = "select * from TB_Header_AznEstlam where Ser_Azn_Estlam  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then


        Else
            Dim VarOp As Integer
            If RadioButton1.Checked = True Then VarOp = 1
            If RadioButton2.Checked = True Then VarOp = 2

            sql = "INSERT INTO TB_Header_AznEstlam (Ser_Azn_Estlam, Compny_Code,Order_Azn_Estlam_NO,Order_Date_Azn_Estlam,Flg_Azn_Estlam) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & VarOp & "')"
            Cnn.Execute(sql)



        End If
        'Next

    End Sub
    Sub save_oderDetils()
        Dim varcode_Item, varcodunit2 As Integer

        sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_Unit2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit2 = rs("Code").Value


        '============================Matril

        sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Name = '" & txt_ItemName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = Trim(rs("code").Value)

        ''===============================stores\
        'sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_NameStores.Text & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodestores = rs("Code").Value



        sql = "INSERT INTO TB_Detils_AznEstlam (Ser_Azn_Estlam,Order_Azn_Estlam_NO,No_Item,Quntity,Code_Unit,Compny_Code,Order_NO,JOB_Order) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & Com_InvoiceNo2.Text & "','" & varcode_Item & "','" & txt_Qty.Text & "','" & varcodunit2 & "','" & VarCodeCompny & "','" & txt_OrderNo.Text & "','" & txt_NoJopOrder.Text & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub Frm_AznEstlamItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dd As DateTime = Now '=====================================الوقت الحالى
        'txt_date.Text = dd.ToString("mm/dd/yyyy")

    End Sub

    Private Sub Cmd_OpenJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click
        vartable = "Lookup_AznEstlamItem"
        VarOpenlookup = 40
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        '        sql2 = "  SELECT        dbo.BD_ITEM.Name, dbo.TB_Detils_AznEstlam.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_1.Name AS Unit2, dbo.TB_Detils_AznEstlam.Order_NO, " & _
        '"                         dbo.TB_Detils_AznEstlam.JOB_Order " & _
        '" FROM            dbo.TB_Header_AznEstlam INNER JOIN " & _
        '"                         dbo.TB_Detils_AznEstlam ON dbo.TB_Header_AznEstlam.Ser_Azn_Estlam = dbo.TB_Detils_AznEstlam.Ser_Azn_Estlam AND  " & _
        '"                         dbo.TB_Header_AznEstlam.Compny_Code = dbo.TB_Detils_AznEstlam.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_ITEM ON dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_AznEstlam.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
        '"                         dbo.BD_Unit ON dbo.TB_Detils_AznEstlam.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                         dbo.TB_Header_JOB_Order ON dbo.TB_Detils_AznEstlam.No_Item = dbo.TB_Header_JOB_Order.Item_No AND dbo.TB_Detils_AznEstlam.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order AND  " & _
        '"                         dbo.TB_Detils_AznEstlam.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code INNER JOIN " & _
        '"                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 = BD_Unit_1.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code " & _
        '" WHERE        (dbo.TB_Header_AznEstlam.Order_Azn_Estlam_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_AznEstlam.Compny_Code = '" & VarCodeCompny & "') "

        sql2 = "  SELECT        dbo.BD_Item.Name, dbo.TB_Detils_AznEstlam.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Header_JOB_Order.Qyt_FristItem2, BD_Unit_1.Name AS Unit2, dbo.TB_Detils_AznEstlam.Order_NO,  " & _
         "                dbo.TB_Detils_AznEstlam.JOB_Order " & _
         " FROM           dbo.BD_Unit AS BD_Unit_1 INNER JOIN " & _
         "                dbo.TB_Header_JOB_Order ON BD_Unit_1.Code = dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 AND BD_Unit_1.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code RIGHT OUTER JOIN " & _
         "                dbo.BD_Item INNER JOIN " & _
         "                 dbo.TB_Detils_AznEstlam ON dbo.BD_Item.Compny_Code = dbo.TB_Detils_AznEstlam.Compny_Code AND dbo.BD_Item.Code = dbo.TB_Detils_AznEstlam.No_Item INNER JOIN " & _
         "                 dbo.BD_Unit ON dbo.TB_Detils_AznEstlam.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_Unit.Compny_Code RIGHT OUTER JOIN " & _
         "                 dbo.TB_Header_AznEstlam ON dbo.TB_Detils_AznEstlam.Ser_Azn_Estlam = dbo.TB_Header_AznEstlam.Ser_Azn_Estlam AND  " & _
         "                 dbo.TB_Detils_AznEstlam.Compny_Code = dbo.TB_Header_AznEstlam.Compny_Code ON dbo.TB_Header_JOB_Order.Item_No = dbo.TB_Detils_AznEstlam.No_Item AND  " & _
         " dbo.TB_Header_JOB_Order.JOB_Order = dbo.TB_Detils_AznEstlam.JOB_Order And dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Detils_AznEstlam.Compny_Code " & _
         " WHERE        (dbo.TB_Header_AznEstlam.Order_Azn_Estlam_NO =  '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_AznEstlam.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "200"
        GridView5.Columns(1).Width = "75"
        GridView5.Columns(2).Width = "75"
        GridView5.Columns(3).Width = "100"
        GridView5.Columns(4).Width = "100"
        GridView5.Columns(5).Width = "100"
        GridView5.Columns(6).Width = "100"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "أسم الصنف "
        GridView5.Columns(1).Caption = "عدد الرولات"
        GridView5.Columns(2).Caption = "الوحدة"

        GridView5.Columns(3).Caption = "الكمية بالكيلو"
        GridView5.Columns(4).Caption = "الوحدة بالكيلو"

        GridView5.Columns(5).Caption = "رقم الطلبية"
        GridView5.Columns(6).Caption = "رقم التشغيلة"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub


    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Header_AznEstlam where Ser_Azn_Estlam  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم اذن الاستلام ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()

        save_oderDetils()
        clear_detils()
        find_detalis()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Report_EstlamStores.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Frm_ProductFinsh.MdiParent = Mainmune
        Frm_ProductFinsh.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        SimpleButton1.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        SimpleButton1.Enabled = True
    End Sub
End Class