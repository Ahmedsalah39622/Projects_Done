Imports System.Data.OleDb

Public Class Frm_Gaza
    Dim varid As Integer
    Private Sub txt_CurrencyName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_gazaName.ButtonClick
        vartable = "BD_gaza"
        VarOpenlookup = 68
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        find_Gaza()
    End Sub

    Private Sub txt_CurrencyName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_gazaName.EditValueChanged

    End Sub

   

    Sub find_Gaza()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " SELECT        dbo.TB_Takherat2.ID, dbo.BD_Gaza.Name, dbo.TB_Takherat2.Time_Takher, dbo.TB_Takherat2.N_Discount " & _
        " FROM            dbo.TB_Takherat2 INNER JOIN " & _
        "                         dbo.BD_Gaza ON dbo.TB_Takherat2.Code_Gaza = dbo.BD_Gaza.Code " & _
        " WHERE        (dbo.BD_Gaza.Name = '" & txt_gazaName.Text & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "100"
        GridView6.Columns(3).Width = "100"


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "الكود"
        GridView6.Columns(1).Caption = "أسم الجزاء "
        GridView6.Columns(2).Caption = "وقت التأخير "
        GridView6.Columns(3).Caption = "نسبة الجزاء"



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.BestFitColumns()

    End Sub

    Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_gazaName.Text) = 0 Then MsgBox("من فضلك أختار اسم التاخير ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub





        '========================================================رقم الجزاء
        sql = "  SELECT *    FROM BD_gaza where   Name ='" & txt_gazaName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================


        sql2 = "INSERT INTO TB_Takherat2 (Code_Gaza, Time_Takher,N_Discount) " & _
          " values  ('" & varcode_Cru & "' ,'" & txt_TimeT.Text & "','" & txt_discountDay.Text & "')"
        rs = Cnn.Execute(sql2)




        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_Gaza()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
       
    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick


        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        varid = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_TimeT.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_discountDay.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))


       
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete TB_Takherat2  WHERE id = " & varid & "  "
        rs = Cnn.Execute(sql)



        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        find_Gaza()
    End Sub
End Class