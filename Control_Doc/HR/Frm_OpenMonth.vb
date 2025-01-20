Public Class Frm_openmonth

    Private Sub Frm_openmonth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 12
            com_month.Items.Add(i)
        Next i
        '================================================================
        For y = 2019 To 2030
            com_year.Items.Add(y)
        Next y

        Dim today = Date.Today

        com_month.Text = today.Month
        com_year.Text = today.Year

        find_Kbd()
    End Sub
    Sub find_Kbd()
        sql = "  SELECT Month_Kbd, Year_Kbd, Datein_kbd, Dateout_kbd       FROM dbo.Seting_kbd WHERE  (Month_Kbd = '" & com_month.Text & "') AND (Year_Kbd = '" & com_year.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_date.Text = rs("Datein_kbd").Value
            txt_date2.Text = rs("Dateout_kbd").Value
        Else
            txt_date.Text = ""
            txt_date2.Text = ""
        End If
    End Sub

    Private Sub com_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_month.SelectedIndexChanged
        find_Kbd()
    End Sub

    Private Sub com_year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_year.SelectedIndexChanged
        find_Kbd()
    End Sub

    Private Sub cmd_Entry_Click(sender As Object, e As EventArgs) Handles cmd_Entry.Click
        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM/dd/yyyy")

        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateoder2 As String
        vardateoder2 = dd2.ToString("MM/dd/yyyy")

        sql = "Delete Seting_kbd where Month_Kbd='" & com_month.Text & "' and  Year_Kbd='" & com_year.Text & "'  "
        rs = Cnn.Execute(sql)


        sql2 = "INSERT INTO Seting_kbd (Month_Kbd, Year_Kbd,Datein_kbd,Dateout_kbd) " & _
                  " values  ('" & com_month.Text & "' ,'" & com_year.Text & "','" & vardateoder & "','" & vardateoder2 & "')"
        rs = Cnn.Execute(sql2)

        MsgBox("تم فتح شهر القبض", MsgBoxStyle.Information, "Cerative smart soft") : Exit Sub

    End Sub

    Private Sub cmd_Cancle_Click(sender As Object, e As EventArgs) Handles cmd_Cancle.Click
        Me.Close()
    End Sub
End Class