Public Class Frm_BankDetils

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If Len(Com_AccountName.Text) = 0 Then MsgBox("Plaes Entry Account Name", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(TXt_NoAccountBank.Text) = 0 Then MsgBox("Plaes Entry Account Number", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_SwiftCode.Text) = 0 Then MsgBox("Plaes Entry SwiftCode", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_OurBank.Text) = 0 Then MsgBox("Plaes Entry OurBank", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Address.Text) = 0 Then MsgBox("Plaes Entry Address", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

       
        sql = "INSERT INTO TB_BankDetils (AccountName, AccountNumber,SwiftCode,NameOfOurBank,Address,Compny_Code) " & _
            " values  (N'" & Com_AccountName.Text & "' ,N'" & TXt_NoAccountBank.Text & "',N'" & Txt_SwiftCode.Text & "',N'" & txt_OurBank.Text & "',N'" & txt_Address.Text & "',N'" & VarCodeCompny & "' )"
        Cnn.Execute(sql)

        MsgBox("Saved Data", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        fill_Account()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_BankDetils  WHERE AccountName = '" & Com_AccountName.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("Delete Data", MsgBoxStyle.Information, "Css Solution Software Module")
                fill_Account()

        End Select
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        sql = "UPDATE   TB_BankDetils   SET AccountNumber = '" & TXt_NoAccountBank.Text & "',SwiftCode = '" & Txt_SwiftCode.Text & "',NameOfOurBank = '" & txt_OurBank.Text & "',Address = '" & txt_Address.Text & "' WHERE AccountName = '" & Com_AccountName.Text & "' and Compny_Code =" & VarCodeCompny & " "
        rs = Cnn.Execute(sql)
        MsgBox("Updated data", MsgBoxStyle.Information, "Css Solution Software Module")
        fill_Account()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        clear()
    End Sub
    Sub clear()
        Com_AccountName.Text = ""
        txt_Address.Text = ""
        txt_OurBank.Text = ""
        Txt_SwiftCode.Text = ""
        TXt_NoAccountBank.Text = ""
    End Sub

    Private Sub Frm_BankDetils_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Account()
    End Sub
    Sub fill_Account()
        Com_AccountName.Items.Clear()
        sql = "SELECT      rtrim(AccountName) as AccountName FROM            dbo.TB_BankDetils  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_AccountName.Items.Add(rs("AccountName").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_AccountName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_AccountName.SelectedIndexChanged
        sql = "select * from TB_BankDetils where AccountName ='" & Com_AccountName.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            TXt_NoAccountBank.Text = rs("AccountNumber").Value
            Txt_SwiftCode.Text = rs("SwiftCode").Value
            txt_OurBank.Text = rs("NameOfOurBank").Value
            txt_Address.Text = rs("Address").Value
        Else
            clear()
        End If
    End Sub
End Class