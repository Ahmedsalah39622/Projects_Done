Public Class Frm_SetupYear

    Private Sub Frm_SetupYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_Year.Items.Add("2018")
        Com_Year.Items.Add("2019")
        Com_Year.Items.Add("2020")
        Com_Year.Items.Add("2021")
        Com_Year.Items.Add("2022")
        Com_Year.Items.Add("2023")
        Com_Year.Items.Add("2024")
        Com_Year.Items.Add("2025")

    End Sub
    Sub find_year()
        sql = "  SELECT YearName, StartDate, EndDate, Code_Year       FROM dbo.St_SetupYear WHERE  (YearName = '" & Com_Year.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_CodeYear.Text = rs("Code_Year").Value
            txt_DateStart.Text = rs("StartDate").Value
            txt_DateEnd.Text = rs("EndDate").Value
        Else
            MsgBox("السنة المالية غير موجود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
            Dim x
            x = MsgBox("هل تريد فتح سنة مالية جديدة ؟ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Css Solution Software Module")

            Select Case x

                Case vbYes
                    last_Data()
                    'clear()

                Case vbNo

            End Select
        End If

    End Sub
    
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Code_Year) AS MaxmamNo FROM St_SetupYear HAVING(MAX(Code_Year) Is Not NULL) "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_CodeYear.Text = rs3("MaxmamNo").Value + 1
        Else
            txt_CodeYear.Text = 1
            clear()

        End If
    End Sub
    Sub clear()
        Com_Year.Items.Clear()
        Com_Year.Items.Add("2019")
        Com_Year.Items.Add("2018")
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click

        Dim dd3 As DateTime = txt_DateStart.Value
        Dim varteststart As String
        varteststart = dd3.ToString("yyyy")
        '================================
        Dim dd4 As DateTime = txt_DateEnd.Value
        Dim vartestEnd As String
        vartestEnd = dd4.ToString("yyyy")



        If varteststart <> Com_Year.Text Then MsgBox("تاريخ بداية السنة ليس موجود فى سنة  " & Com_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If vartestEnd <> Com_Year.Text Then MsgBox("تاريخ نهاية السنة ليس موجود فى سنة  " & Com_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql = "Delete St_SetupYear  WHERE YearName = '" & Com_Year.Text & "' "
        rs = Cnn.Execute(sql)



        Dim dd As DateTime = txt_DateStart.Value
        Dim vardatestart As String
        vardatestart = dd.ToString("MM-d-yyyy")

        '======================

        Dim dd2 As DateTime = txt_DateEnd.Value
        Dim vardateend As String
        vardateend = dd2.ToString("MM-d-yyyy")
        Dim sql2 As String
        sql2 = "INSERT INTO St_SetupYear (Code_Year, StartDate,EndDate,YearName) " & _
          " values  ('" & txt_CodeYear.Text & "' ,'" & vardatestart & "','" & vardateend & "','" & Com_Year.Text & "')"
        rs = Cnn.Execute(sql2)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub

    Private Sub Com_Year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Year.SelectedIndexChanged
        find_year()
    End Sub
End Class