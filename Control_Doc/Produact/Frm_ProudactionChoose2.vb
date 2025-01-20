Imports System.Data.OleDb

Public Class Frm_ProudactionChoose2
    Dim varmaxmim As Integer
    Dim VarProdactName As String
    Private Sub Frm_ProudactionChoose2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Phases()
    End Sub

    Sub fill_Phases()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select * from vw_All_Phases2 "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

       

        GridView2.Appearance.Row.Font = New Font(GridView2.Appearance.Row.Font, FontStyle.Bold)
        GridView2.Appearance.Row.Options.UseFont = True

        GridView2.Columns(0).Caption = "رقم العملية "
        GridView2.Columns(1).Caption = "امر الشغل"
        GridView2.Columns(2).Caption = "منتج مرحلة 1"
        GridView2.Columns(3).Caption = "الكمية"
        GridView2.Columns(4).Caption = "الوحدة"
        GridView2.Columns(5).Caption = "الكمية"
        GridView2.Columns(6).Caption = "الوحدة"

        GridView2.Columns(7).Caption = "المنتج المطلوب"
        GridView2.Columns(8).Caption = "رقم الطلبية"
        GridView2.Columns(9).Caption = "الكمية"
        GridView2.Columns(10).Caption = "الوحدة"
        GridView2.Columns(11).Caption = "الكمية"
        GridView2.Columns(12).Caption = "الوحدة"

        GridView2.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub

   

    Sub fill_Detials_JopOrder()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "    SELECT        JOB_Order, SerialNo, LIGHT_ROLL, WIGHT_ROLL, NET_KG_ROLL, Thickness, Notes        FROM dbo.TB_Detils_QualityAprove WHERE        (JOB_Order = '" & varJopOrder & "') AND (Compny_Code = '" & VarCodeCompny & "')"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "50"
        GridView5.Columns(3).Width = "50"
        GridView5.Columns(4).Width = "50"
        GridView5.Columns(5).Width = "50"
        GridView5.Columns(6).Width = "200"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم امر الشغل "
        GridView5.Columns(1).Caption = "رقم Searil"
        GridView5.Columns(2).Caption = "الطول"
        GridView5.Columns(3).Caption = "العرض"
        GridView5.Columns(4).Caption = "الوزن"
        GridView5.Columns(5).Caption = "السمك"
        GridView5.Columns(6).Caption = "ملاحظات"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

   
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        txt_Ref.Text = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        varJopOrder = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(1))
        VarProdactName = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(7))
        fill_Detials_JopOrder()
    End Sub

    Private Sub txt_MachinName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachinName.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 380
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachinName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachinName.EditValueChanged

    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_NewJobOrder.Click
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        last_Data()

        'Com_InvoiceNo2.Text=

        MsgBox("تم انشاء رقم امر شغل جديد على مرحلة 2 " & Com_InvoiceNo2.Text & "على عملية انتاج  " & txt_Ref.Text & "  للمنتج المطلوب " & VarProdactName, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module")
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(JOB_Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_JOB_Order    GROUP BY Compny_Code  HAVING        (MAX(JOB_Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varmaxmim = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = Trim(txt_MachinName.Text) + Str(varmaxmim)
            Com_InvoiceNo2.Text = Trim(Com_InvoiceNo2.Text)
        Else
            varmaxmim = 1
            Com_InvoiceNo2.Text = Trim(txt_MachinName.Text) + "1"


        End If
    End Sub


    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        var_ref_prodact = txt_Ref.Text
        Frm_ProudactionOrder2.txt_Ref.Text = Trim(var_ref_prodact)
        Frm_ProudactionOrder2.txt_MachinName.Text = txt_MachinName.Text
        Frm_ProudactionOrder2.Com_InvoiceNo2.Text = Com_InvoiceNo2.Text
        Frm_ProudactionOrder2.MdiParent = Mainmune
        Frm_ProudactionOrder2.find_ref_prodact()
        Frm_ProudactionOrder2.fill_Detials_JopOrder()
        Frm_ProudactionOrder2.find_Produactphaze1()
        Frm_ProudactionOrder2.find_ProduactActive()

        'Frm_ProudactionOrder2.fill_Detials_Prodact_Reqired()
        Frm_ProudactionOrder2.Show()


        Me.Close()

    End Sub
End Class