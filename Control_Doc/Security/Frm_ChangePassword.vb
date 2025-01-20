Public Class Frm_ChangePassword

   

    Private Sub cmd_Entry_Click(sender As Object, e As EventArgs) Handles cmd_Entry.Click
        sql = "UPDATE Users_Department " & " set User_Name ='" & txt_UserName.Text & "' ,Se_Password ='" & txt_Password.Text & "' " & _
"  " & " Where Code_Emp = '" & txt_Code.Text & "'   "
        Cnn.Execute(sql)

        MsgBox("تم تغير كلمة المرور", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Renal Solution Software Module")
    End Sub

    Private Sub cmd_Cancle_Click(sender As Object, e As EventArgs) Handles cmd_Cancle.Click
        Me.Close()
    End Sub
End Class