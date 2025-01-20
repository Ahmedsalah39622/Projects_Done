Public Class Frm_ExpensessShapping

    Private Sub Frm_ExpensessShapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Exp()
        fill_cru()
    End Sub
    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Exp()
        com_GroupExpensses.Items.Clear()
        sql = "SELECT        Name FROM            dbo.TB_TypeExpensess  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_GroupExpensses.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub com_GroupExpensses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_GroupExpensses.SelectedIndexChanged
        Com_Exp.Items.Clear()
        sql = "   SELECT        dbo.TB_TypeExpensess.Name, dbo.TB_GroupExpeness.AccountNoExspensess, dbo.ST_CHARTOFACCOUNT.AccountName " & _
    " FROM           dbo.TB_GroupExpeness LEFT OUTER JOIN " & _
"                 dbo.TB_TypeExpensess ON dbo.TB_GroupExpeness.Group1No = dbo.TB_TypeExpensess.Code AND dbo.TB_GroupExpeness.Compny_Code = dbo.TB_TypeExpensess.Compny_Code LEFT OUTER JOIN " & _
"                 dbo.ST_CHARTOFACCOUNT ON dbo.TB_GroupExpeness.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
" dbo.TB_GroupExpeness.AccountNoExspensess = dbo.ST_CHARTOFACCOUNT.Account_No " & _
" WHERE(dbo.TB_GroupExpeness.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_TypeExpensess.Name LIKE '%" & com_GroupExpensses.Text & "%') "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Exp.Items.Add(rs("AccountName").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub txtcode_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txtcode.ButtonClick
        Frm_Lookup_Etmad.ShowDialog()
    End Sub

    Private Sub txtcode_EditValueChanged(sender As Object, e As EventArgs) Handles txtcode.EditValueChanged

    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        Cmd_save.Enabled = True
        Cmd_Edit.Enabled = True
        Cmd_Delete.Enabled = True
    End Sub
End Class