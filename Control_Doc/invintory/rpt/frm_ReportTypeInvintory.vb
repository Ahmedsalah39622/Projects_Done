Public Class frm_ReportTypeInvintory

    Private Sub frm_ReportTypeInvintory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Type_Stores()
    End Sub
    Sub fill_Type_Stores()
        Com_type.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_TypeSarfStores  where Compny_Code ='" & VarCodeCompny & "' and flag = 0 "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_type.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        varStores1 = 1
        Frm_RptAll2.Show()
    End Sub
End Class