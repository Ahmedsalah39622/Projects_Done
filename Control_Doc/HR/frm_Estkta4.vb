Imports ADODB
Public Class frm_Estkta4


    Sub Fill_Find()

        'On Error Resume Next

        sql = "   SELECT dbo.TB_Eskta.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Eskta.Salary, dbo.TB_Eskta.behavior, dbo.TB_Eskta.ruin, dbo.TB_Eskta.breach, dbo.TB_Eskta.slaf, dbo.TB_Eskta.Social_insurance, dbo.TB_Eskta.Medical_insurances, dbo.TB_Eskta.late_arrival, dbo.TB_Eskta.Early_departure, dbo.TB_Eskta.Taekhrat, dbo.TB_Eskta.Ghuab, dbo.TB_Eskta.tswahd, dbo.TB_Eskta.Ghzat , dbo.TB_Eskta.TotalEstkta  " & _
   " FROM     dbo.TB_Eskta INNER JOIN " & _
   "                  dbo.Emp_employees ON dbo.TB_Eskta.Emp_Code = dbo.Emp_employees.Emp_Code " & _
   " WHERE  (dbo.TB_Eskta.Emp_Month = '" & com_month.Text & "') AND (dbo.TB_Eskta.emp_year = '" & com_year.Text & "') "

        rs2 = New ADODB.Recordset
        rs2.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs2.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""
            DataGridView2.Item(8, 0).Value = ""
            DataGridView2.Item(9, 0).Value = ""
            DataGridView2.Item(10, 0).Value = ""
            DataGridView2.Item(11, 0).Value = ""
            DataGridView2.Item(12, 0).Value = ""
            DataGridView2.Item(13, 0).Value = ""
            DataGridView2.Item(14, 0).Value = ""
            DataGridView2.Item(15, 0).Value = ""

            'DataGridView2.Item(8, 0).Value = ""

            find_alldata()
        Else

            txt_Status.Text = "تم المراجعة" : txt_Status.BackColor = Color.Gray
            DataGridView2.RowCount = 1
            rs2.MoveLast() : rs2.MoveFirst()

            Dim T
            For T = 0 To rs2.RecordCount - 1
                DataGridView2.RowCount = rs2.RecordCount

                For i = 0 To DataGridView2.RowCount - 1


                    DataGridView2.Item(0, i).Value = rs2("Emp_Code").Value
                    DataGridView2.Item(1, i).Value = rs2("Emp_Name").Value
                    DataGridView2.Item(2, i).Value = rs2("Salary").Value
                    DataGridView2.Item(3, i).Value = rs2("behavior").Value
                    DataGridView2.Item(4, i).Value = rs2("ruin").Value
                    DataGridView2.Item(5, i).Value = rs2("breach").Value
                    DataGridView2.Item(6, i).Value = rs2("slaf").Value
                    DataGridView2.Item(7, i).Value = rs2("Social_insurance").Value
                    DataGridView2.Item(8, i).Value = rs2("Medical_insurances").Value
                    DataGridView2.Item(9, i).Value = rs2("late_arrival").Value
                    DataGridView2.Item(10, i).Value = rs2("Early_departure").Value
                    DataGridView2.Item(11, i).Value = rs2("Taekhrat").Value
                    DataGridView2.Item(12, i).Value = rs2("Ghuab").Value
                    DataGridView2.Item(13, i).Value = rs2("tswahd").Value
                    DataGridView2.Item(14, i).Value = rs2("Ghzat").Value
                    DataGridView2.Item(15, i).Value = rs2("TotalEstkta").Value

                    'DataGridView2.Item(8, i).Value = rs2("Notes").Value



                    rs2.MoveNext()


                Next i
                'sum_estk()
                Exit Sub
            Next T
            rs2.Close()
        End If

    End Sub
    Sub find_alldata()

        'On Error Resume Next


        sql = " select * from Emp_employees  where  dbo.Emp_employees.Compny_Code = '" & VarCodeCompny & "'"

        rs3 = New ADODB.Recordset
        rs3.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs3.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""
            DataGridView2.Item(8, 0).Value = ""
            DataGridView2.Item(9, 0).Value = ""
            DataGridView2.Item(10, 0).Value = ""
            DataGridView2.Item(11, 0).Value = ""
            DataGridView2.Item(12, 0).Value = ""
            DataGridView2.Item(13, 0).Value = ""
            DataGridView2.Item(14, 0).Value = ""
            DataGridView2.Item(15, 0).Value = ""


        Else
            txt_Status.Text = "غير مراجع" : txt_Status.BackColor = Color.Yellow
        End If
        DataGridView2.RowCount = 1
        rs3.MoveLast() : rs3.MoveFirst()

        Dim T
        For T = 0 To rs3.RecordCount - 1
            DataGridView2.RowCount = rs3.RecordCount

            For i = 0 To DataGridView2.RowCount - 1
                DataGridView2.Item(0, i).Value = rs3("Emp_Code").Value
                DataGridView2.Item(1, i).Value = rs3("Emp_Name").Value
                DataGridView2.Item(2, i).Value = 0
                DataGridView2.Item(3, i).Value = 0
                DataGridView2.Item(4, i).Value = 0
                DataGridView2.Item(5, i).Value = 0
                DataGridView2.Item(7, i).Value = 0
                DataGridView2.Item(8, i).Value = 0
                DataGridView2.Item(9, i).Value = 0
                DataGridView2.Item(10, i).Value = 0
                DataGridView2.Item(11, i).Value = 0
                DataGridView2.Item(12, i).Value = 0
                DataGridView2.Item(13, i).Value = 0
                DataGridView2.Item(14, i).Value = 0
                DataGridView2.Item(15, i).Value = 0
                DataGridView2.Item(6, i).Value = 0

                '=========================================================الراتب
                SQL3 = "  SELECT Emp_Code, TotSalary               FROM dbo.Emp_employees     WHERE(Emp_Code = '" & rs3("Emp_Code").Value & "')"
                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(2, i).Value = rs4("TotSalary").Value Else DataGridView2.Item(2, i).Value = "0"


                '===========================================================تأخيرات
                sql2 = "     SELECT        ROUND(dbo.Emp_employees.TotSalary / 30, 2) AS ValueDaySalary, ROUND(ROUND(SUM(dbo.Emp_TimeAtt2.Total_Miniut), 2) * ROUND(dbo.Emp_employees.TotSalary / 30, 2), 2) AS TotalTaekher  ,ROUND(ROUND(SUM(dbo.Emp_TimeAtt2.time_in2), 2) * ROUND(dbo.Emp_employees.TotSalary / 30, 2), 2) AS Totaltime_in2  ,ROUND(ROUND(SUM(dbo.Emp_TimeAtt2.time_out2), 2) * ROUND(dbo.Emp_employees.TotSalary / 30, 2), 2) AS Totaltime_out2  " & _
                 " FROM            dbo.Emp_employees INNER JOIN " & _
                 "                         dbo.Emp_TimeAtt2 ON dbo.Emp_employees.Emp_Code = dbo.Emp_TimeAtt2.Emp_code " & _
                 " GROUP BY dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Compny_Code, ROUND(dbo.Emp_employees.TotSalary / 30, 2), dbo.Emp_TimeAtt2.Emp_att_Month, dbo.Emp_TimeAtt2.Emp_att_year " & _
                 " HAVING        (dbo.Emp_employees.Emp_Code = '" & rs3("Emp_Code").Value & "') AND (dbo.Emp_employees.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Emp_TimeAtt2.Emp_att_Month = '" & com_month.Text & "') AND (dbo.Emp_TimeAtt2.Emp_att_year = '" & com_year.Text & "') "
                rs2 = Cnn.Execute(sql2)
                If rs2.EOF = False Then DataGridView2.Item(11, i).Value = rs2("TotalTaekher").Value Else DataGridView2.Item(11, i).Value = "0"
                If rs2.EOF = False Then DataGridView2.Item(9, i).Value = rs2("Totaltime_in2").Value Else DataGridView2.Item(9, i).Value = "0"
                If rs2.EOF = False Then DataGridView2.Item(10, i).Value = rs2("Totaltime_out2").Value Else DataGridView2.Item(10, i).Value = "0"

                '========================================================================== خصم من غياب
                SQL3 = "      SELECT Code_Emp, sum(Value_Discount) as SumDiscount  FROM dbo.TB_HR_DiscountSalary" & _
                " WHERE(Code_Emp = '" & rs3("Emp_Code").Value & "') And (Month(Date_Entry) = '" & com_month.Text & "') And (Year(Date_Entry) = '" & com_year.Text & "') And (Flag_Discount = 1) and Code_DiscountSalary ='2' group by Code_Emp"
                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(12, i).Value = rs4("SumDiscount").Value Else DataGridView2.Item(12, i).Value = "0"
                '============================================================================خصم عادى
                SQL3 = "      SELECT Code_Emp, sum(Value_Discount) as SumDiscount  FROM dbo.TB_HR_DiscountSalary" & _
                " WHERE(Code_Emp = '" & rs3("Emp_Code").Value & "') And (Month(Date_Entry) = '" & com_month.Text & "') And (Year(Date_Entry) = '" & com_year.Text & "') And (Flag_Discount = 1) and Code_DiscountSalary ='1' group by Code_Emp"
                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(13, i).Value = rs4("SumDiscount").Value Else DataGridView2.Item(13, i).Value = "0"

                '============================================================================خصم سلوك
                SQL3 = "      SELECT Code_Emp, sum(Value_Discount) as SumDiscount  FROM dbo.TB_HR_DiscountSalary" & _
                " WHERE(Code_Emp = '" & rs3("Emp_Code").Value & "') And (Month(Date_Entry) = '" & com_month.Text & "') And (Year(Date_Entry) = '" & com_year.Text & "') And (Flag_Discount = 1) and Code_DiscountSalary ='4' group by Code_Emp"
                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(3, i).Value = rs4("SumDiscount").Value Else DataGridView2.Item(3, i).Value = "0"
                '============================================================================خصم اخلال
                SQL3 = "      SELECT Code_Emp, sum(Value_Discount) as SumDiscount  FROM dbo.TB_HR_DiscountSalary" & _
                " WHERE(Code_Emp = '" & rs3("Emp_Code").Value & "') And (Month(Date_Entry) = '" & com_month.Text & "') And (Year(Date_Entry) = '" & com_year.Text & "') And (Flag_Discount = 1) and Code_DiscountSalary ='3' group by Code_Emp"
                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(5, i).Value = rs4("SumDiscount").Value Else DataGridView2.Item(5, i).Value = "0"







                '================================================================================ سلفة من الراتب
                'SQL3 = "      SELECT Code_Emp, Value_Discount  FROM dbo.TB_HR_SalfSalary" & _
                '" WHERE(Code_Emp = '" & rs3("Emp_Code").Value & "') And (Month(Date_Entry) = '" & com_month.Text & "') And (Year(Date_Entry) = '" & com_year.Text & "') And (Flag_Discount = 1)"

                SQL3 = "   SELECT Code_Emp, SUM(Value_Discount) AS SumSalf              FROM dbo.TB_HR_SalfSalary WHERE  (MONTH(Date_Entry) = '" & com_month.Text & "') AND (YEAR(Date_Entry) = '" & com_year.Text & "') AND (Flag_Discount = 1) " & _
               " GROUP BY Code_Emp HAVING (Code_Emp = '" & rs3("Emp_Code").Value & "')"

                rs4 = Cnn.Execute(SQL3)
                If rs4.EOF = False Then DataGridView2.Item(6, i).Value = rs4("SumSalf").Value Else DataGridView2.Item(6, i).Value = "0"
                '===================================================================

                'DataGridView2.Item(7, i).Value = Val(DataGridView2.Item(2, i).Value) + Val(DataGridView2.Item(3, i).Value) + Val(DataGridView2.Item(4, i).Value) + Val(DataGridView2.Item(5, i).Value) + Val(DataGridView2.Item(6, i).Value)
                'sum_estk()
                DataGridView2.Item(11, i).Value = Val(DataGridView2.Item(9, i).Value) + Val(DataGridView2.Item(10, i).Value)

                DataGridView2.Item(15, i).Value = Val(DataGridView2.Item(3, i).Value) + Val(DataGridView2.Item(4, i).Value) + Val(DataGridView2.Item(5, i).Value) + Val(DataGridView2.Item(6, i).Value) + Val(DataGridView2.Item(7, i).Value) + Val(DataGridView2.Item(8, i).Value) + Val(DataGridView2.Item(11, i).Value) + Val(DataGridView2.Item(12, i).Value) + Val(DataGridView2.Item(13, i).Value) + Val(DataGridView2.Item(14, i).Value)

                rs3.MoveNext()


            Next i

            Exit Sub
        Next T
        rs.Close()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Fill_Find()
    End Sub

    Private Sub cmd_save_Click_1(sender As Object, e As EventArgs) Handles cmd_save.Click

        sql = "Delete TB_Eskta  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1


            sql = "INSERT INTO TB_Eskta (Emp_Code,Emp_Month,emp_year,Compny_Code,Salary, behavior,ruin,breach,slaf,Social_insurance,Medical_insurances,late_arrival,Early_departure,Taekhrat,Ghuab,tswahd,Ghzat,TotalEstkta) " & _
                    " values  (" & DataGridView2.Item(0, x).Value & " ,N'" & com_month.Text & "',N'" & com_year.Text & "',N'" & VarCodeCompny & "',N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(3, x).Value & "','" & DataGridView2.Item(4, x).Value & "','" & DataGridView2.Item(5, x).Value & "' ,'" & DataGridView2.Item(6, x).Value & "',N'" & DataGridView2.Item(7, x).Value & "',N'" & DataGridView2.Item(8, x).Value & "',N'" & DataGridView2.Item(9, x).Value & "',N'" & DataGridView2.Item(10, x).Value & "',N'" & DataGridView2.Item(11, x).Value & "',N'" & DataGridView2.Item(12, x).Value & "',N'" & DataGridView2.Item(13, x).Value & "',N'" & DataGridView2.Item(14, x).Value & "',N'" & DataGridView2.Item(15, x).Value & "' )"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'sum_estk()

    End Sub



    Private Sub Frm_Bdalat_Emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        fill_Dir()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Fill_Find()
        Total_Sum()
    End Sub
    Sub Total_Sum()
        On Error Resume Next
        Dim total As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        Dim total5 As String = 0
        Dim total6 As String = 0

        Dim total7 As String = 0
        Dim total8 As String = 0
        Dim total9 As String = 0
        Dim total10 As String = 0
        Dim total11 As String = 0
        Dim total12 As String = 0
        Dim total13 As String = 0
        Dim total14 As String = 0


        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += DataGridView2.Rows(i).Cells(2).Value

            total2 += DataGridView2.Rows(i).Cells(3).Value
            total3 += DataGridView2.Rows(i).Cells(4).Value
            total4 += DataGridView2.Rows(i).Cells(5).Value

            total5 += Val(DataGridView2.Rows(i).Cells(6).Value)
            total6 += Val(DataGridView2.Rows(i).Cells(7).Value)

            total7 += Val(DataGridView2.Rows(i).Cells(8).Value)
            total8 += Val(DataGridView2.Rows(i).Cells(9).Value)
            total9 += Val(DataGridView2.Rows(i).Cells(10).Value)
            total10 += Val(DataGridView2.Rows(i).Cells(11).Value)
            total11 += Val(DataGridView2.Rows(i).Cells(12).Value)
            total12 += Val(DataGridView2.Rows(i).Cells(13).Value)
            total13 += Val(DataGridView2.Rows(i).Cells(14).Value)
            total14 += Val(DataGridView2.Rows(i).Cells(15).Value)


        Next
        txt_SalaryTotal.Text = total
        txt_behavior.Text = total2
        txt_ruinTotal.Text = total3
        txt_Totalbreach.Text = total4
        txt_Totalslaf.Text = total5
        txt_totalSocial_insurance.Text = total6

        txt_totalMedical_insurances.Text = total7
        txt_late_arrivalTotal.Text = total8
        txt_Early_departureTotal.Text = total9

        txt_TaekhratTotal.Text = total10
        txt_GhuabTotal.Text = total11
        txt_tswahdTotal.Text = total12
        txt_GhzatTotal.Text = total13
        txt_TotalEstkta.Text = total14




    End Sub

    Sub fill_Dir()
        Com_Dir.Items.Clear()
        sql = " SELECT     Name  from BD_DIRCTORAY where Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Dir.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        sql = "Delete TB_Eskta  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '=========================================================
        sql = "select * from  TB_Eskta  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            Fill_Find()

        Else
            find_alldata()
        End If

        MsgBox("تم ارجاع الشهر", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'sum_estk()
    End Sub



    Private Sub DataGridView2_CellValueChanged1(sender As Object, e As DataGridViewCellEventArgs)
 

    End Sub

  

    

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Dim report As New Rpt_Estk
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.X_Date1.Text = com_month.Text
        report.X_Date2.Text = com_year.Text
        report.FilterString = "[Emp_Month] = '" & com_month.Text & "' and [emp_year] = '" & com_year.Text & "' and  [NameDIR] like '%" & Com_Dir.Text & "%'  and  [NameDeprt] like '%" & Com_Deprt.Text & "%' and  [JopName] like '%" & Com_JopName.Text & "%' and  [Emp_Name] like '%" & Com_Emp.Text & "%'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub Com_Dir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Dir.SelectedIndexChanged
        fill_deprt()
    End Sub
    Sub fill_deprt()
        Com_Deprt.Text = ""
        Com_JopName.Text = ""
        Com_JopName.Text = ""
        Com_Deprt.Items.Clear()
        Com_JopName.Items.Clear()
        Com_Emp.Items.Clear()
        sql = "  SELECT        dbo.BD_DIRCTORAY.Name AS NameDir, dbo.BD_DEPARTMENTS.Name AS NameDeprt " & _
          " FROM            dbo.Emp_employees INNER JOIN " & _
          "                         dbo.BD_DIRCTORAY ON dbo.Emp_employees.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code AND dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
          "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_DEPARTMENTS.Compny_Code " & _
          " GROUP BY dbo.Emp_employees.Emp_Code_Department, dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DIRCTORAY.Compny_Code " & _
          " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') AND (dbo.BD_DIRCTORAY.Compny_Code = '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Deprt.Items.Add(rs("NameDeprt").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_Deprt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Deprt.SelectedIndexChanged
        fill_JopName()
    End Sub
    Sub fill_JopName()
        Com_JopName.Items.Clear()
        Com_Emp.Items.Clear()
        sql = "  SELECT        dbo.BD_DIRCTORAY.Name AS NameDir, dbo.BD_DEPARTMENTS.Name AS NameDeprt, dbo.BD_JOBNAMES.Name " & _
  " FROM            dbo.Emp_employees INNER JOIN " & _
  "                         dbo.BD_DIRCTORAY ON dbo.Emp_employees.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code AND dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
  "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_DEPARTMENTS.Compny_Code INNER JOIN " & _
  "                         dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_JOBNAMES.Compny_Code " & _
  " GROUP BY dbo.Emp_employees.Emp_Code_Department, dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DIRCTORAY.Compny_Code, dbo.BD_JOBNAMES.Name " & _
  " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') AND (dbo.BD_DIRCTORAY.Compny_Code = '" & VarCodeCompny & "') AND (dbo.BD_DEPARTMENTS.Name = '" & Com_Deprt.Text & "') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_JopName.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop

    End Sub

    Private Sub Com_JopName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_JopName.SelectedIndexChanged
        fill_Emp()
    End Sub
    Sub fill_Emp()
        Com_Emp.Items.Clear()
        sql = "  SELECT        dbo.BD_DIRCTORAY.Name AS NameDir, dbo.BD_DEPARTMENTS.Name AS NameDeprt, dbo.BD_JOBNAMES.Name, dbo.Emp_employees.Emp_Name " & _
  " FROM            dbo.Emp_employees INNER JOIN " & _
  "                         dbo.BD_DIRCTORAY ON dbo.Emp_employees.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code AND dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
  "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_DEPARTMENTS.Compny_Code INNER JOIN " & _
  "                         dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code AND dbo.Emp_employees.Compny_Code = dbo.BD_JOBNAMES.Compny_Code " & _
  " GROUP BY dbo.Emp_employees.Emp_Code_Department, dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DIRCTORAY.Compny_Code, dbo.BD_JOBNAMES.Name, dbo.Emp_employees.Emp_Name " & _
  " HAVING        (dbo.BD_DIRCTORAY.Name like '%" & Com_Dir.Text & "%') AND (dbo.BD_DIRCTORAY.Compny_Code = '" & VarCodeCompny & "') AND (dbo.BD_DEPARTMENTS.Name like '%" & Com_Deprt.Text & "%')  AND (dbo.BD_JOBNAMES.Name like '%" & Com_JopName.Text & "%') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Emp.Items.Add(rs("Emp_Name").Value)
            rs.MoveNext()
        Loop

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
      

    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        On Error Resume Next
        Dim ro, mt As Integer
        ro = DataGridView2.CurrentRow.Index
        mt = ro
        DataGridView2.Item(11, mt).Value = Val(DataGridView2.Item(9, mt).Value) + Val(DataGridView2.Item(10, mt).Value)
        DataGridView2.Item(15, mt).Value = Val(DataGridView2.Item(3, mt).Value) + Val(DataGridView2.Item(4, mt).Value) + Val(DataGridView2.Item(5, mt).Value) + Val(DataGridView2.Item(6, mt).Value) + Val(DataGridView2.Item(7, mt).Value) + Val(DataGridView2.Item(8, mt).Value) + Val(DataGridView2.Item(11, mt).Value) + Val(DataGridView2.Item(12, mt).Value) + Val(DataGridView2.Item(13, mt).Value) + Val(DataGridView2.Item(14, mt).Value)
        'sum_estk()

    End Sub

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Dim report As New Salarydeductions
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = "[Emp_Month] = '" & com_month.Text & "' and [emp_year] = '" & com_year.Text & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim report As New Salarydeductions
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        'report.X_Date1.Text = com_month.Text
        'report.X_Date2.Text = com_year.Text
        report.FilterString = "[Emp_Month] = '" & com_month.Text & "' and [emp_year] = '" & com_year.Text & "' and  [NameDIR] like '%" & Com_Dir.Text & "%'  and  [NameDeprt] like '%" & Com_Deprt.Text & "%' and  [JopName] like '%" & Com_JopName.Text & "%' and  [Emp_Name] like '%" & Com_Emp.Text & "%'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        varnoform = 1
        Frm_FindEmp.ShowDialog()

    End Sub
End Class