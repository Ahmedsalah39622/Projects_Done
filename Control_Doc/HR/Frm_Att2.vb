Imports System.Globalization
Imports ADODB

Public Class Frm_Att2
    Dim var_datein, var_dateoutn, vardate_d As String
    Dim vartakher As Single
    Private Sub Com_Emp_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Sub find_att()
        On Error Resume Next
        sql = "SELECT        Datein_kbd, Dateout_kbd     FROM dbo.Seting_Kbd WHERE        (Month_Kbd = '" & com_month.Text & "') AND (Year_Kbd = '" & com_year.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            var_datein = rs("Datein_kbd").Value
            var_dateoutn = rs("Dateout_kbd").Value


        End If

        sql = "Delete Tb_EmpAtt2  WHERE Emp_att_Month = " & com_month.Text & " and  Emp_att_year = " & com_year.Text & " and  Emp_code = " & txt_codeEmp.Text & " and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        add_payment()
    End Sub




    Sub add_payment()

        ''==================================================date From
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim oldmonth As Integer
        Dim oldyear As Integer
        ' Assign a date using standard short format.
        oldDate = var_datein
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        oldmonth = Microsoft.VisualBasic.DateAndTime.Month(oldDate)
        oldyear = Microsoft.VisualBasic.DateAndTime.Year(oldDate)
        Dim vardayrent As Date
        'Dim vardayrent2 As Date
        vardayrent = CDate(oldDay & "/" & oldmonth & "/" & oldyear)
        '====
        vardate_d = DateAdd("d", Val(0), vardayrent)
        'If Com_TypeContract.Text = "شهرى" Then txt_date_Start_rent.Value = DateAdd("m", Val(txt_Duration.Text * Com_add.Text), vardayrent)
        'If Com_TypeContract.Text = "سنوى" Then DateTimePicker3.Value = DateAdd("Y", Val(txt_CountPayment.Text), vardayrent)

        Dim i As Integer
        i = 1
        Dim oldDate2 As Date
        Dim oldDay2 As Integer
        Dim oldmonth2 As Integer
        Dim oldyear2 As Integer
        oldDate2 = var_dateoutn
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)
        oldmonth2 = Microsoft.VisualBasic.DateAndTime.Month(oldDate2)
        oldyear2 = Microsoft.VisualBasic.DateAndTime.Year(oldDate2)


        Dim startP As DateTime = New DateTime(oldyear, oldmonth, oldDay)
        Dim endP As DateTime = New DateTime(oldyear2, oldmonth2, oldDay2)
        Dim CurrD As DateTime = startP

        While (CurrD < endP)
            'ProcessData(CurrD)
            Console.WriteLine(CurrD.ToShortDateString)
            CurrD = CurrD.AddDays(1)


            Dim oldDate3 As Date
            Dim oldDay3 As Integer
            Dim oldmonth3 As Integer
            Dim oldyear3 As Integer
            oldDate3 = CurrD
            oldDay3 = Microsoft.VisualBasic.DateAndTime.Day(oldDate3)
            oldmonth3 = Microsoft.VisualBasic.DateAndTime.Month(oldDate3)
            oldyear3 = Microsoft.VisualBasic.DateAndTime.Year(oldDate3)

            Dim vardayrent3 As String

            vardayrent3 = oldmonth3 & "/" & oldDay3 & "/" & oldyear3
            'vardayrent3 = CDate(oldDay3 & "/" & oldmonth3 & "/" & oldyear3)

            Dim day_No = oldDay3
            'Dim formattedDate As String = Format(vardayrent3, "DDD")
            'Dim vardate As Date
            Dim str As String = vardayrent3
            Dim dDate As DateTime = DateTime.Parse(str, CultureInfo.InvariantCulture)
            Dim strDayFirst As String = Format(dDate, "ddd")
            ''=======================================الزيادة السنوية

            Dim vardayrent33 As String
            ''==========================================
            vardayrent33 = oldDay3 & "/" & oldmonth3 & "/" & oldyear3
            '============================================تاريخ الميلاد
            Dim dd As DateTime = vardayrent33
            Dim vardate1 As String
            vardate1 = dd.ToString("MM-d-yyyy")

            'varcodecontract2 = txt_cleint2.Text

            sql = "INSERT INTO Tb_EmpAtt2 (Emp_att_Month, Emp_att_year,Emp_code,Date_att,No_Day,Name_Day,Compny_Code) " & _
            " values  (N'" & com_month.Text & "' ,N'" & com_year.Text & "',N'" & txt_codeEmp.Text & "',N'" & vardate1 & "',N'" & day_No & "',N'" & strDayFirst & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

            i = i + 1
            'varaddpayment = CurrD
        End While




        'Dim x As Integer
        'For x = oldDay & "/" & oldmonth & "/" & oldyear To oldDay2 & "/" & oldmonth2 & "/" & oldyear2




        'Next x
    End Sub

    Sub Fill_Att2()

        On Error Resume Next

        sql = "SELECT       dbo.Tb_EmpAtt2.flag, dbo.Tb_EmpAtt2.Emp_att_Month, dbo.Tb_EmpAtt2.Emp_att_year, dbo.Tb_EmpAtt2.Emp_code, dbo.Tb_EmpAtt2.Date_att, dbo.Tb_EmpAtt2.No_Day, dbo.Tb_EmpAtt2.Name_Day,  " & _
        "                         dbo.Vw_AM_PM.TimeIN, dbo.Vw_AM_PM.TimeOut, dbo.Tb_EmpAtt2.Miniut_1, dbo.Tb_EmpAtt2.Miniut_2, dbo.Tb_EmpAtt2.Total_Miniut, dbo.Tb_EmpAtt2.N_Gza, dbo.Tb_EmpAtt2.Wasf_gza,  " & _
        "        dbo.Emp_employees.Emp_Code_Dirctorat, dbo.Emp_employees.Emp_Code_Department, dbo.Emp_employees.Emp_Code_JopName, dbo.SetingAtt.Att_IN, dbo.SetingAtt.Att_Out, " & _
        " iif(DATEDIFF(MINUTE, dbo.SetingAtt.Att_IN, dbo.Vw_AM_PM.TimeIN) is null ,'0',DATEDIFF(MINUTE, dbo.SetingAtt.Att_IN, dbo.Vw_AM_PM.TimeIN)) AS MinuteDiff_IN,    iif(  DATEDIFF(MINUTE, dbo.SetingAtt.Att_Out, dbo.Vw_AM_PM.TimeOut) is null,'0', DATEDIFF(MINUTE, dbo.SetingAtt.Att_Out, dbo.Vw_AM_PM.TimeOut) ) AS MinuteDiff_Out " & _
        " FROM            dbo.Emp_employees INNER JOIN " & _
        "                         dbo.Tb_EmpAtt2 ON dbo.Emp_employees.Emp_Code = dbo.Tb_EmpAtt2.Emp_code AND dbo.Emp_employees.Compny_Code = dbo.Tb_EmpAtt2.Compny_Code INNER JOIN " & _
        "                         dbo.SetingAtt ON dbo.Emp_employees.Compny_Code = dbo.SetingAtt.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.Vw_AM_PM ON dbo.Tb_EmpAtt2.Emp_code = dbo.Vw_AM_PM.Code AND dbo.Tb_EmpAtt2.Date_att = dbo.Vw_AM_PM.Date_Day " & _
        " WHERE        (dbo.Tb_EmpAtt2.Emp_att_Month = '" & com_month.Text & "') AND (dbo.Tb_EmpAtt2.Emp_att_year = '" & com_year.Text & "') AND (dbo.Tb_EmpAtt2.Emp_code = '" & txt_codeEmp.Text & "') and Tb_EmpAtt2.Compny_Code ='" & VarCodeCompny & "' " & _
        " ORDER BY dbo.Tb_EmpAtt2.Date_att "


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

            DataGridView2.Item(10, 0).Value = ""
            DataGridView2.Item(11, 0).Value = ""
            'find_alldata()
        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1

                    txt_Status.Text = "غير مراجع" : txt_Status.BackColor = Color.Yellow
                    'DataGridView2.Item(4, i).Value = ""
                    DataGridView2.Item(10, i).Value = rs("Att_IN").Value
                    DataGridView2.Item(11, i).Value = rs("Att_Out").Value

                    DataGridView2.Item(0, i).Value = rs("No_Day").Value
                    DataGridView2.Item(1, i).Value = rs("Name_Day").Value
                    DataGridView2.Item(2, i).Value = rs("TimeIN").Value
                    DataGridView2.Item(3, i).Value = rs("TimeOut").Value

                    Dim vardir, vardeprt, varjop As Integer
                    vardir = rs("Emp_Code_Dirctorat").Value
                    vardeprt = rs("Emp_Code_Department").Value
                    varjop = rs("Emp_Code_JopName").Value



                    ''=================================مواعيد الادارات
                    Dim dd As DateTime = rs("Date_att").Value
                    Dim vardate1 As String
                    vardate1 = dd.ToString("MM-d-yyyy")
                    sql2 = " SELECT        code_dir, Time_in, Time_out, code_deprt, code_jop, emp_code, Date_From                  FROM dbo.Seting_Time " & _
                    " WHERE        (code_dir = '" & vardir & "') AND (Date_From = CONVERT(DATETIME, '" & vardate1 & "', 102)) and emp_code like '" & txt_codeEmp.Text & "'   "
                    rs2 = Cnn.Execute(sql2)
                    If rs2.EOF = False Then
                        DataGridView2.Item(10, i).Value = rs2("Time_in").Value
                        DataGridView2.Item(11, i).Value = rs2("Time_out").Value

                    End If
                    ''===============================================





                    DataGridView2.Item(4, i).Value = DateDiff(DateInterval.Minute, DataGridView2.Item(10, i).Value, rs("TimeIN").Value)
                    If DateDiff(DateInterval.Minute, DataGridView2.Item(10, i).Value, rs("TimeIN").Value) < 0 Then DataGridView2.Item(4, i).Value = 0

                    DataGridView2.Item(5, i).Value = DateDiff(DateInterval.Minute, DataGridView2.Item(11, i).Value, rs("TimeOut").Value)
                    If DateDiff(DateInterval.Minute, DataGridView2.Item(11, i).Value, rs("TimeOut").Value) < 0 Then DataGridView2.Item(5, i).Value = 0

                    'DataGridView2.Item(6, i).Value = rs("Total_Miniut").Value
                    'DataGridView2.Item(7, i).Value = rs("N_Gza").Value
                    'DataGridView2.Item(8, i).Value = rs("Wasf_gza").Value


                    'DataGridView2.Item(12, i).Value = "يوم عمل"



                    ''=================================مواعيد الادارات
                    'Dim dd As DateTime = rs("Date_att").Value
                    'Dim vardate1 As String
                    'vardate1 = dd.ToString("MM-d-yyyy")
                    'sql2 = " SELECT        code_dir, Time_in, Time_out, code_deprt, code_jop, emp_code, Date_From                  FROM dbo.Seting_Time " & _
                    '" WHERE        (code_dir = '" & vardir & "') AND (Date_From = CONVERT(DATETIME, '" & vardate1 & "', 102)) and emp_code like '" & txt_codeEmp.Text & "'   "
                    'rs2 = Cnn.Execute(sql2)
                    'If rs2.EOF = False Then
                    '    DataGridView2.Item(10, i).Value = rs2("Time_in").Value
                    '    DataGridView2.Item(11, i).Value = rs2("Time_out").Value

                    'End If
                    ''==============================================نوع الاجازة

                    'sql = "          SELECT        dbo.Seting_Vaction.code_dir, dbo.BD_Vaction.Name, dbo.Seting_Vaction.Date_From " & _
                    '  " FROM            dbo.Seting_Vaction INNER JOIN " & _
                    '  "                         dbo.BD_Vaction ON dbo.Seting_Vaction.Compny_Code = dbo.BD_Vaction.Compny_Code AND dbo.Seting_Vaction.vaction_Code = dbo.BD_Vaction.Code " & _
                    '  " WHERE        (dbo.Seting_Vaction.Date_From = CONVERT(DATETIME, '" & vardate1 & "', 102)) AND (dbo.Seting_Vaction.code_dir = '" & vardir & "') "

                    'rs3 = Cnn.Execute(sql)
                    'If rs3.EOF = False Then
                    '    DataGridView2.Item(12, i).Value = rs3("Name").Value

                    '    'DataGridView2.Item(4, i).Value = "0"

                    'End If


                    '================================اجازات العاملين


                    'sql = "SELECT dbo.TB_Vaction_Day.OrderNo, dbo.TB_Vaction_Day.Date_Vaction, dbo.TB_Vaction_Day.Code_Emp, dbo.TB_HR_VactionData.Flag_Vaction, dbo.BD_VactionLookup.Name " & _
                    '" FROM     dbo.TB_HR_VactionData INNER JOIN " & _
                    '"                  dbo.TB_Vaction_Day ON dbo.TB_HR_VactionData.No_Order = dbo.TB_Vaction_Day.OrderNo AND dbo.TB_HR_VactionData.Code_Emp = dbo.TB_Vaction_Day.Code_Emp INNER JOIN " & _
                    '"                  dbo.BD_VactionLookup ON dbo.TB_HR_VactionData.Code_vaction = dbo.BD_VactionLookup.Code " & _
                    '" WHERE  (dbo.TB_Vaction_Day.Date_Vaction = CONVERT(DATETIME, '" & vardate1 & "', 102)) AND (dbo.TB_HR_VactionData.Flag_Vaction = 1) and dbo.TB_Vaction_Day.Code_Emp = '" & txt_codeEmp.Text & "'  "

                    'rs3 = Cnn.Execute(sql)
                    'If rs3.EOF = False Then
                    '    DataGridView2.Item(12, i).Value = rs3("Name").Value


                    'End If
                    '=====================================






                    ''If rs("MinuteDiff_IN").Value < 0 Then vartakher = 0 Else vartakher = Val(DataGridView2.Item(4, i).Value)

                    ''========================================التاخيرات عن مواعيد العمل
                    sql = "   SELECT        dbo.TB_Takherat2.ID, dbo.BD_Gaza.Name, dbo.TB_Takherat2.Time_Takher, dbo.TB_Takherat2.N_Discount, dbo.TB_Takherat2.Code_Gaza " & _
                           " FROM            dbo.TB_Takherat2 INNER JOIN " & _
                           "                         dbo.BD_Gaza ON dbo.TB_Takherat2.Code_Gaza = dbo.BD_Gaza.Code " & _
                           "                    WHERE(dbo.TB_Takherat2.Code_Gaza = 1) "
                    rs2 = Cnn.Execute(sql)
                    'Do While Not rs2.EOF
                    If DateDiff(DateInterval.Minute, DataGridView2.Item(10, i).Value, rs("TimeIN").Value) <= "0" Then
                    Else

                        Dim var_N_Gza_Ensraf_M As Single
                        var_N_Gza_Ensraf_M = 0
                        If DateDiff(DateInterval.Minute, DataGridView2.Item(10, i).Value, rs("TimeIN").Value) > rs2("Time_Takher").Value Then DataGridView2.Item(8, i).Value = rs2("N_Discount").Value / 100 : DataGridView2.Item(9, i).Value = rs2("Name").Value Else DataGridView2.Item(9, i).Value = ""

                        DataGridView2.Item(6, i).Value = DateDiff(DateInterval.Minute, rs("TimeOut").Value, DataGridView2.Item(11, i).Value)

                        If DateDiff(DateInterval.Minute, rs("TimeOut").Value, DataGridView2.Item(11, i).Value) > rs2("Time_Takher").Value Then var_N_Gza_Ensraf_M = rs2("N_Discount").Value / 100 : DataGridView2.Item(9, i).Value = rs2("Name").Value Else DataGridView2.Item(9, i).Value = ""

                        DataGridView2.Item(7, i).Value = Val(DataGridView2.Item(6, i).Value) + Val(DataGridView2.Item(4, i).Value)


                        DataGridView2.Item(14, i).Value = DataGridView2.Item(8, i).Value
                        DataGridView2.Item(15, i).Value = var_N_Gza_Ensraf_M



                        DataGridView2.Item(8, i).Value = Math.Round(Val(DataGridView2.Item(8, i).Value) + var_N_Gza_Ensraf_M, 2)


                    End If

                    ''rs2.MoveNext()
                    ''Loop
                    ''===================================================
                    'DataGridView2.Item(13, i).Value = vardate1


                    rs.MoveNext()

                Next i
                'Exit Sub

                Total_Minite()
                Total_Takher()
                Total_Minite_Add()
                Total_add()
                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub


    Sub Total_Minite()
        On Error Resume Next
        txt_Miniet.Text = 0
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(7).Value)
        Next
        txt_Miniet.Text = total

    End Sub

    Sub Total_Minite_Add()
        On Error Resume Next
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(5).Value)
        Next
        txt_Miniet_Add.Text = total

    End Sub
    Sub Total_Takher()
        'On Error Resume Next
        txt_totalTakher.Text = 0
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += DataGridView2.Rows(i).Cells(8).Value
        Next
        txt_totalTakher.Text = total

    End Sub

    Sub Total_add()
        On Error Resume Next
        'Dim total As String = 0
        'For i As Integer = 0 To DataGridView2.RowCount - 1
        '    total += DataGridView2.Rows(i).Cells(8).Value
        'Next
        txt_totalAdd.Text = Math.Round(Val(txt_Miniet_Add.Text) / 60, 2)

    End Sub
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
     
    End Sub

    Private Sub Frm_Att2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com_month.Items.Clear()
        com_year.Items.Clear()

        fill_Emp()

        For i = 1 To 12
            com_month.Items.Add(i)
        Next


        For P = 2019 To 2050

            com_year.Items.Add(P)
        Next


        Dim today = Date.Today

        com_month.Text = today.Month
        com_year.Text = today.Year
    End Sub
    Sub fill_Emp()
        Com_EmpName.Items.Clear()
        sql = " SELECT     Emp_Name  from Emp_employees where Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_EmpName.Items.Add(rs("Emp_Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_EmpName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_EmpName.SelectedIndexChanged
        txt_Miniet.Text = ""
        txt_totalTakher.Text = ""
        sql = "SELECT   *     FROM dbo.Emp_employees  WHERE        (Emp_Name = '" & Com_EmpName.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_codeEmp.Text = rs("Emp_Code").Value


        End If

     
        sql = "   SELECT        dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name AS NameDeprt, dbo.BD_JOBNAMES.Name AS NameJop " & _
           " FROM            dbo.Emp_employees INNER JOIN " & _
           "                         dbo.BD_DIRCTORAY ON dbo.Emp_employees.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code AND dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
           "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_DEPARTMENTS.Compny_Code INNER JOIN " & _
           "                         dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_JOBNAMES.Compny_Code " & _
           "       WHERE(dbo.Emp_employees.Emp_Code = '" & txt_codeEmp.Text & "')   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_dir.Text = rs("Name").Value
            txt_deprt.Text = rs("NameDeprt").Value
            txt_jopName.Text = rs("NameJop").Value
        End If





        sql = "select * from  Emp_TimeAtt2  WHERE Emp_att_Month = '" & com_month.Text & "' and Emp_att_year ='" & com_year.Text & "' and Emp_code = '" & txt_codeEmp.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            find_alldata()
        Else
            Fill_Att2()
        End If


        Total_Minite()
        Total_Takher()
        Total_Minite_Add()
        Total_add()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)
        Dim x
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_EmpAtt2  WHERE Emp_att_Month = " & com_month.Text & " and  Emp_att_year = " & com_year.Text & " and  Emp_code = " & txt_codeEmp.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)
        End Select
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        txt_dir.Text = ""
        txt_deprt.Text = ""
        txt_jopName.Text = ""
        txt_codeEmp.Text = ""
        Com_EmpName.Text = ""
        txt_Miniet.Text = ""
        txt_totalTakher.Text = ""
        txt_Miniet_Add.Text = ""
        txt_totalAdd.Text = ""
        Fill_Att2()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        find_att()
        Fill_Att2()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        'Total_Minite()
        'Total_Takher()
        Total_Minite()
        Total_Takher()
        Total_Minite_Add()
        Total_add()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        varcode_emp = txt_codeEmp.Text
     
        Frm_CurrentEmployee.Close()
        Frm_CurrentEmployee.MdiParent = Mainmune
        Frm_CurrentEmployee.find_dateEmp()
        Frm_CurrentEmployee.Show()
    End Sub

    Private Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click



        sql = "Delete Emp_TimeAtt2  WHERE Emp_att_Month = '" & com_month.Text & "' and Emp_att_year ='" & com_year.Text & "' and Emp_code = '" & txt_codeEmp.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1

            sql = " insert into Emp_TimeAtt2  (Emp_att_Month,Emp_att_year,Emp_code,Date_att " & _
            " ,No_Day,Name_Day,Time_in,Time_out,Miniut_1,Miniut_2,time_in2,time_out2,Total_Miniut,Hala,Compny_Code) " & _
            " values (N'" & com_month.Text & "'  ,N'" & com_year.Text & "'  " & _
            " ,N'" & txt_codeEmp.Text & " ',N'" & DataGridView2.Item(13, x).Value & "' " & _
            " ,N'" & DataGridView2.Item(0, x).Value & "',N'" & DataGridView2.Item(1, x).Value & "' " & _
            " ,N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(3, x).Value & "',N'" & DataGridView2.Item(4, x).Value & "',N'" & DataGridView2.Item(5, x).Value & "',N'" & DataGridView2.Item(14, x).Value & "',N'" & DataGridView2.Item(15, x).Value & "',N'" & DataGridView2.Item(8, x).Value & "',N'" & DataGridView2.Item(9, x).Value & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)

        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



       find_alldata
        'Fill_Att2()
    End Sub



    Sub find_alldata()

        On Error Resume Next



        sql = "    SELECT        Emp_att_Month, Emp_att_year, Emp_code, No_Day, Name_Day, Time_in, Time_out, Miniut_1, Miniut_2,time_in2,time_out2, Total_Miniut, Hala, Date_att, Compny_Code " & _
    " FROM            dbo.Emp_TimeAtt2 " & _
    " WHERE        (Emp_code = '" & txt_codeEmp.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') AND (Emp_att_Month = '" & com_month.Text & "') AND (Emp_att_year = '" & com_year.Text & "') "


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

            DataGridView2.Item(10, 0).Value = ""
            DataGridView2.Item(11, 0).Value = ""

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1

                    txt_Status.Text = "تم المراجعة" : txt_Status.BackColor = Color.Gray

                    DataGridView2.Item(0, i).Value = rs("No_Day").Value
                    DataGridView2.Item(1, i).Value = rs("Name_Day").Value
                    DataGridView2.Item(2, i).Value = rs("Time_in").Value
                    DataGridView2.Item(3, i).Value = rs("Time_out").Value
                    DataGridView2.Item(4, i).Value = rs("Miniut_1").Value
                    DataGridView2.Item(5, i).Value = rs("Miniut_2").Value
                    DataGridView2.Item(6, i).Value = rs("time_in2").Value
                    DataGridView2.Item(7, i).Value = rs("time_out2").Value
                    DataGridView2.Item(8, i).Value = rs("Total_Miniut").Value
                    DataGridView2.Item(9, i).Value = rs("Hala").Value
                    DataGridView2.Item(13, i).Value = rs("Date_att").Value
               


                    Dim dd As DateTime = rs("Date_att").Value
                    Dim vardate1 As String
                    vardate1 = dd.ToString("MM-d-yyyy")




                    '==============================================نوع الاجازة

                    sql = "          SELECT        dbo.Seting_Vaction.code_dir, dbo.BD_Vaction.Name, dbo.Seting_Vaction.Date_From " & _
                      " FROM            dbo.Seting_Vaction INNER JOIN " & _
                      "                         dbo.BD_Vaction ON dbo.Seting_Vaction.Compny_Code = dbo.BD_Vaction.Compny_Code AND dbo.Seting_Vaction.vaction_Code = dbo.BD_Vaction.Code " & _
                      " WHERE        (dbo.Seting_Vaction.Date_From = CONVERT(DATETIME, '" & vardate1 & "', 102)) AND (dbo.Seting_Vaction.code_dir = '" & vardir & "') "

                    rs3 = Cnn.Execute(sql)
                    If rs3.EOF = False Then
                        DataGridView2.Item(12, i).Value = rs3("Name").Value

                        'DataGridView2.Item(4, i).Value = "0"

                    End If


                    '================================اجازات العاملين


                    sql = "SELECT dbo.TB_Vaction_Day.OrderNo, dbo.TB_Vaction_Day.Date_Vaction, dbo.TB_Vaction_Day.Code_Emp, dbo.TB_HR_VactionData.Flag_Vaction, dbo.BD_VactionLookup.Name " & _
                    " FROM     dbo.TB_HR_VactionData INNER JOIN " & _
                    "                  dbo.TB_Vaction_Day ON dbo.TB_HR_VactionData.No_Order = dbo.TB_Vaction_Day.OrderNo AND dbo.TB_HR_VactionData.Code_Emp = dbo.TB_Vaction_Day.Code_Emp INNER JOIN " & _
                    "                  dbo.BD_VactionLookup ON dbo.TB_HR_VactionData.Code_vaction = dbo.BD_VactionLookup.Code " & _
                    " WHERE  (dbo.TB_Vaction_Day.Date_Vaction = CONVERT(DATETIME, '" & vardate1 & "', 102)) AND (dbo.TB_HR_VactionData.Flag_Vaction = 1) and dbo.TB_Vaction_Day.Code_Emp = '" & txt_codeEmp.Text & "' "

                    rs3 = Cnn.Execute(sql)
                    If rs3.EOF = False Then
                        DataGridView2.Item(12, i).Value = rs3("Name").Value


                    End If
                    '=====================================
















                    rs.MoveNext()


                Next i
                Total_Minite()
                Total_Takher()
                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub

  
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        sql = "Delete Emp_TimeAtt2  WHERE Emp_att_Month = '" & com_month.Text & "' and Emp_att_year ='" & com_year.Text & "' and Emp_code = '" & txt_codeEmp.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '=========================================================
        sql = "select * from  Emp_TimeAtt2  WHERE Emp_att_Month = '" & com_month.Text & "' and Emp_att_year ='" & com_year.Text & "' and Emp_code = '" & txt_codeEmp.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            find_alldata()
        Else
            Fill_Att2()
        End If
        MsgBox("تم ارجاع الشهر", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub

   
End Class