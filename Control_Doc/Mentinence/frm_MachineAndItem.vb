Imports System.Data.OleDb

Public Class frm_MachineAndItem
    Dim varcode_Item, varcode_Item2 As Integer
    Private Sub Com_CustomeName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachineName.ButtonClick
        vartable = "Vw_listItem"
        VarOpenlookup = 72
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        Find_Data()
    End Sub

    Private Sub Com_CustomeName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachineName.EditValueChanged

    End Sub

    Private Sub txt_MachineName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Component.ButtonClick
        vartable = "Vw_listItem2"
        VarOpenlookup = 73
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachineName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Component.EditValueChanged

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If Len(txt_MachineName.Text) = 0 Then MsgBox("من فضلك أختار أسم الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Component.Text) = 0 Then MsgBox("من فضلك أختار أسم قطعة الغيار ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '===================================================== الماكينة
        sql = "  SELECT *    FROM vw_listItem where   Name ='" & txt_MachineName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = rs("code").Value
        '================================
        sql = "  SELECT *    FROM vw_listItem2 where   Name ='" & txt_Component.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item2 = rs("code").Value

        '=============================
        sql = "  SELECT *    FROM TB_ItemComponent where   Code_Item ='" & varcode_Item & "' and  Code_Item2 ='" & varcode_Item2 & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("قطعة الغيار موجودة سابقا على الماكينة", MsgBoxStyle.Critical, "Css") : Exit Sub
        sql2 = "INSERT INTO TB_ItemComponent (Code_Item, Code_Item2,Notes,Compny_Code) " & _
          " values  ('" & varcode_Item & "' ,'" & varcode_Item2 & "','" & txt_Notes.Text & "','" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_Data()
    End Sub


    Sub Find_Data()
        On Error Resume Next
        varcode_Item = 0
        '===================================================== الماكينة
        sql = "  SELECT *    FROM vw_listItem where   Name ='" & txt_MachineName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = rs("code").Value
        '================================
        sql = "   SELECT        dbo.Vw_ListItem.Name AS NameMachine, dbo.Vw_ListItem2.Name AS NameComponent " & _
           " FROM            dbo.TB_ItemComponent INNER JOIN " & _
           "                         dbo.Vw_ListItem ON dbo.TB_ItemComponent.Code_Item = dbo.Vw_ListItem.Code AND dbo.TB_ItemComponent.Compny_Code = dbo.Vw_ListItem.Compny_Code INNER JOIN " & _
           "                         dbo.Vw_ListItem2 ON dbo.TB_ItemComponent.Code_Item2 = dbo.Vw_ListItem2.Code AND dbo.TB_ItemComponent.Compny_Code = dbo.Vw_ListItem2.Compny_Code " & _
           " WHERE        (dbo.TB_ItemComponent.Code_Item = '" & varcode_Item & "') AND (dbo.TB_ItemComponent.Compny_Code = '" & VarCodeCompny & "') "



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
        GridView5.Columns(1).Caption = "قطع الغيار"
        'GridView5.Columns(2).Caption = "ملاحظات"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Width = "250"
        GridView5.Columns(1).Width = "250"
        'GridView5.Columns(2).Width = "200"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView5.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle

        txt_MachineName.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        txt_Component.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        'txt_Notes.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        If Len(txt_MachineName.Text) = 0 Then MsgBox("من فضلك أختار أسم الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Component.Text) = 0 Then MsgBox("من فضلك أختار أسم قطعة الغيار ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '===================================================== الماكينة
        sql = "  SELECT *    FROM vw_listItem where   Name ='" & txt_MachineName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item = rs("code").Value
        '================================
        sql = "  SELECT *    FROM vw_listItem2 where   Name ='" & txt_Component.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Item2 = rs("code").Value

        '=============================



        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes




                sql = "Delete TB_ItemComponent  WHERE Code_Item  = " & varcode_Item & " and Code_Item2 ='" & varcode_Item2 & "' and Compny_Code = '" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)




                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                txt_MachineName.Text = ""
                txt_Component.Text = ""
                txt_Notes.Text = ""
                Find_Data()
        End Select

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        txt_MachineName.Text = ""
        txt_Component.Text = ""
        txt_Notes.Text = ""
        Find_Data()
    End Sub
End Class