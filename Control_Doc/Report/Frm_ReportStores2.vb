Public Class Frm_ReportStores2

    Private Sub Frm_ReportStores2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Stores()
    End Sub
    Sub fill_Stores()
        Com_StoresNo.Items.Clear()

        sql = " SELECT Name FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_StoresNo.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        varStores1 = 2
        Frm_RptAll2.Show()
    End Sub
End Class