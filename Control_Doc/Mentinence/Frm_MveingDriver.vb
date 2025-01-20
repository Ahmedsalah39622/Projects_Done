Imports ADODB

Public Class Frm_MveingDriver
    Dim vartime1, vartime2 As String
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dd As DateTime = Now '=====================================الوقت الحالى
        txt_CurentTime.Text = dd.ToString("h:mm:ss")
    End Sub

    Private Sub Frm_MveingDriver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Start() 'Timer starts functioning


        Com_InOut.Items.Add("دخول")
        Com_InOut.Items.Add("خروج")


        Dim varStartTime As String
        Dim dd As DateTime = Now '=====================================وقت البدء
        varStartTime = dd.ToString("dd/MM/yyyy")
        txt_Date_Day.Text = varStartTime
        find()
    End Sub

    Private Sub cmd_New_Click(sender As Object, e As EventArgs) Handles cmd_New.Click

        last_Data()
        clear()
        'find_detalis()

    End Sub

    Sub last_Data()

        sql = "  SELECT        MAX(Code_Move) AS MaxMaim,Compny_Code FROM            TB_MovingCars2  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(Code_Move) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_No.Text = rs("MaxMaim").Value + 1

        Else
            Com_No.Text = 1

        End If
    End Sub



    Sub clear()
        'txt_Date_Day.Text = Now

        Dim varStartTime As String
        Dim dd As DateTime = Now '=====================================وقت البدء
        varStartTime = dd.ToString("dd/MM/yyyy")
        txt_Date_Day.Text = varStartTime
        txt_invoiceNo.Text = ""
        txt_NoCar.Text = ""
        Txt_Twsel.Text = ""
        txt_TypeCar.Text = ""
        txt_Moamla.Text = ""
        txt_NameDeriver.Text = ""
        Com_InOut.Text = ""
        txt_notes.Text = ""
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        If IsDate(txt_Date_Day.Text) = False Then MsgBox("من فضلك أدخل التاريخ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Txt_Twsel.Text = "" Then MsgBox("من فضلك ادخل جهة التوصيل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_InOut.Text = "" Then MsgBox("من فضلك ادخل الدخول والخروج", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_invoiceNo.Text = "" Then MsgBox("من فضلك ادخل رقم الفاتورة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_NameDeriver.Text = "" Then MsgBox("من فضلك ادخل أسم السائق", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_NoCar.Text = "" Then MsgBox("من فضلك ادخل رقم السيارة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_TypeCar.Text = "" Then MsgBox("من فضلك ادخل نوع السيارة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_Moamla.Text = "" Then MsgBox("من فضلك ادخل نوع المعاملة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub


        '=========================تاريخ البداية
        Dim dd As DateTime = txt_Date_Day.Text
        Dim vardateOrder As String
        vardateOrder = dd.ToString("MM-d-yyyy")






        'sql = "SELECT *  FROM BD_TypeMintes where Name ='" & Com_Type.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs3 = Cnn.Execute(sql)
        'If rs3.EOF = False Then varcodetypeM = rs3("Code").Value


        If Com_InOut.Text = "دخول" Then vartime2 = txt_CurentTime.Text : vartime1 = "00:00"
        If Com_InOut.Text = "خروج" Then vartime1 = txt_CurentTime.Text : vartime2 = "00:00"

        sql = "INSERT INTO TB_MovingCars2 (Code_Move, Compny_Code,Date_Day,Status,Time_in,Time_Out,Invoice_No,Name_Deriver,Car_No,Car_type,Type_Mamla,Twsel,Notes) " & _
                      " values  (N'" & Com_No.Text & "' ,N'" & VarCodeCompny & "',N'" & vardateOrder & "',N'" & Com_InOut.Text & "',N'" & vartime2 & "',N'" & vartime1 & "',N'" & txt_invoiceNo.Text & "',N'" & txt_NameDeriver.Text & "',N'" & txt_NoCar.Text & "',N'" & txt_TypeCar.Text & "',N'" & txt_Moamla.Text & "',N'" & Txt_Twsel.Text & "',N'" & txt_notes.Text & "')"
        Cnn.Execute(sql)




        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find()
        'find_detalis()
    End Sub

   

    Sub find()

        '=========================تاريخ البداية
        Dim dd As DateTime = txt_Date_Day.Text
        Dim vardateOrder As String
        vardateOrder = dd.ToString("MM-d-yyyy")

        sql = "      SELECT        Code_Move, Date_Day, Status, Time_in, Time_Out, Invoice_No, Name_Deriver, Car_No, Car_type, Type_Mamla, Twsel, notes " & _
      " FROM            dbo.TB_MovingCars2 " & _
      " WHERE        (Date_Day = CONVERT(DATETIME, '" & vardateOrder & "', 102)) "

        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""
            DataGridView2.Item(7, 0).Value = ""
            DataGridView2.Item(8, 0).Value = ""
            DataGridView2.Item(9, 0).Value = ""
        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1

                    Com_No.Text = rs("Code_Move").Value
                    DataGridView2.Item(0, i).Value = i + 1
                    DataGridView2.Item(1, i).Value = rs("Time_in").Value
                    DataGridView2.Item(2, i).Value = rs("Time_Out").Value
                    DataGridView2.Item(3, i).Value = rs("Twsel").Value
                    DataGridView2.Item(4, i).Value = rs("Invoice_No").Value
                    DataGridView2.Item(5, i).Value = rs("Name_Deriver").Value
                    DataGridView2.Item(6, i).Value = rs("Car_No").Value
                    DataGridView2.Item(7, i).Value = rs("Car_type").Value
                    DataGridView2.Item(8, i).Value = rs("Type_Mamla").Value
                    DataGridView2.Item(9, i).Value = rs("Notes").Value





                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub
End Class