Imports System.Data.OleDb

Public Class Frm_CustomerAndMachine
    Dim varcode_Item, varcode_StatusMachine, varcode_customer As Integer
    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_CustomeName.ButtonClick
        VarOpenlookup2 = 30
        varcode_form = 30
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        Find_Data()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles Com_CustomeName.EditValueChanged

    End Sub

    Private Sub txt_Type_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachineName.ButtonClick
        vartable = "Vw_listItem"
        VarOpenlookup = 70
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If Len(Com_CustomeName.Text) = 0 Then MsgBox("من فضلك أختار أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MachineName.Text) = 0 Then MsgBox("من فضلك أختار أسم الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Status.Text) = 0 Then MsgBox("من فضلك أختار حالة الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_N.Text) = 0 Then MsgBox("من فضلك ادخل نسبة الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '========================================================رقم العميل
        sql = "  SELECT *    FROM FindCustomer where   Name ='" & Com_CustomeName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_customer = rs("Customer_Code").Value
        '===================================================== الماكينة
        sql = "  SELECT *    FROM vw_listItem where   Name ='" & txt_MachineName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = rs("code").Value
        '================================
        sql = "  SELECT *    FROM BD_StatusMachine where   Name ='" & Com_Status.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_StatusMachine = rs("code").Value
        '=============================

        sql2 = "INSERT INTO TB_CustomerAndMachine (Code_Customer, Code_Item,Code_Status,Notes,Compny_Code,N_Machine) " & _
          " values  ('" & varcode_customer & "' ,'" & varcode_Item & "','" & varcode_StatusMachine & "' ,'" & txt_Notes.Text & "','" & VarCodeCompny & "','" & Txt_N.Text & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_Data()

    End Sub

    Private Sub Com_Status_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Status.ButtonClick
        vartable = "BD_StatusMachine"
        VarOpenlookup = 71
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub
    Sub Find_Data()
        On Error Resume Next

        sql = "SELECT        dbo.BD_ITEM.Name AS NameMachine, dbo.BD_StatusMachine.Name AS StatusMachines,dbo.TB_CustomerAndMachine.N_Machine, dbo.TB_CustomerAndMachine.Notes " & _
        " FROM            dbo.TB_CustomerAndMachine INNER JOIN " & _
        "                         dbo.FindCustomer ON dbo.TB_CustomerAndMachine.Code_Customer = dbo.FindCustomer.Customer_Code AND dbo.TB_CustomerAndMachine.Compny_Code = dbo.FindCustomer.Compny_Code INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.TB_CustomerAndMachine.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_CustomerAndMachine.Code_Item = dbo.BD_ITEM.Code INNER JOIN " & _
        "                         dbo.BD_StatusMachine ON dbo.TB_CustomerAndMachine.Code_Status = dbo.BD_StatusMachine.Code AND dbo.TB_CustomerAndMachine.Compny_Code = dbo.BD_StatusMachine.Compny_Code " & _
        " WHERE        (dbo.FindCustomer.Name = '" & Com_CustomeName.Text & "') AND (dbo.TB_CustomerAndMachine.Compny_Code = '" & VarCodeCompny & "') "





        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView5.Columns(0).Caption = "الماكينة"
        GridView5.Columns(1).Caption = "حالة الماكينة"
        GridView5.Columns(2).Caption = "نسبة كفاءة الماكينة"
        GridView5.Columns(3).Caption = "ملاحظات"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Width = "250"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "120"
        GridView5.Columns(3).Width = "200"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView5.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


    End Sub

    Private Sub Com_Status_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Status.EditValueChanged

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Com_CustomeName.Text = ""
        Txt_N.Text = ""
        txt_MachineName.Text = ""
        Com_Status.Text = ""
        txt_Notes.Text = ""
        Find_Data()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next

        If Len(Com_CustomeName.Text) = 0 Then MsgBox("من فضلك أختار أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MachineName.Text) = 0 Then MsgBox("من فضلك أختار أسم الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Status.Text) = 0 Then MsgBox("من فضلك أختار حالة الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                '========================================================رقم الصنف
                sql = "  SELECT *    FROM vw_listItem where   Name ='" & txt_MachineName.Text & "' and Compny_Code = '" & VarCodeCompny & "'"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcode_Item = rs("code").Value
                '=====================================================
                '========================================================رقم العميل
                sql = "  SELECT *    FROM FindCustomer where   Name ='" & Com_CustomeName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcode_customer = rs("Customer_Code").Value


                sql = "Delete TB_CustomerAndMachine  WHERE Code_Customer  = " & varcode_customer & " and Code_Item ='" & varcode_Item & "' and Compny_Code = '" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)






                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                txt_MachineName.Text = ""
                Com_Status.Text = ""
                Find_Data()
        End Select
    End Sub

   

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        If Len(txt_MachineName.Text) = 0 Then MsgBox("من فضلك أختار اختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

    End Sub

    Private Sub txt_MachineName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachineName.EditValueChanged

    End Sub

    Private Sub GridControl4_Click_1(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle

        txt_MachineName.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Com_Status.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        Txt_N.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        txt_Notes.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))
    End Sub
End Class