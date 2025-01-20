Imports ADODB

Public Class Frm_Payroll_Data

    Sub fill_Dir()
        Com_Dir.Items.Clear()
        sql = " SELECT     Name  from BD_DIRCTORAY where Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Dir.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
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

    Private Sub Frm_Payroll_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Sub Fill_PayroolData()

       
        On Error Resume Next


        'sql = "   SELECT        Emp_Code, Emp_Name, basicsalary    FROM dbo.Emp_employees    WHERE(Compny_Code = '" & VarCodeCompny & "')"

        sql = "select * from Vw_AllSalary_FinshM where Compny_Code = '" & VarCodeCompny & "' and   (dbo.Vw_AllSalary_FinshM.emp_year = '" & com_year.Text & "') and  (dbo.Vw_AllSalary_FinshM.Emp_Month = '" & com_month.Text & "') "

        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""


        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("Emp_Code").Value
                    DataGridView2.Item(1, i).Value = rs("Emp_Name").Value
                    DataGridView2.Item(2, i).Value = rs("basicsalary").Value
                    DataGridView2.Item(3, i).Value = rs("Motgher").Value
                    DataGridView2.Item(4, i).Value = rs("TotalBdel").Value
                    DataGridView2.Item(5, i).Value = rs("Total_agr").Value
                    DataGridView2.Item(6, i).Value = rs("N_Basic").Value
                    DataGridView2.Item(7, i).Value = rs("Nesbet_M").Value
                    DataGridView2.Item(8, i).Value = rs("Mnsha").Value
                    DataGridView2.Item(9, i).Value = rs("N_Basic2").Value
                    DataGridView2.Item(10, i).Value = rs("Nesbet_M2").Value
                    DataGridView2.Item(11, i).Value = rs("Total_hstAmel").Value

                    DataGridView2.Item(12, i).Value = rs("cost_emp").Value
                    DataGridView2.Item(13, i).Value = rs("efa").Value
                    DataGridView2.Item(14, i).Value = rs("Total_TM").Value

                    DataGridView2.Item(15, i).Value = rs("w3a").Value
                    DataGridView2.Item(16, i).Value = rs("sd").Value

                    DataGridView2.Item(17, i).Value = rs("safyratb").Value
                    DataGridView2.Item(18, i).Value = rs("TotalEstkta").Value
                    DataGridView2.Item(19, i).Value = rs("totalall").Value


                    DataGridView2.Item(20, i).Value = rs("Total_agr").Value - rs("TotalEstkta").Value
                    '==============================================المتغير
                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Fill_PayroolData()
    End Sub

    Private Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click
        On Error Resume Next
        sql = "Delete TB_SalaryAll  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1


            sql = "INSERT INTO TB_SalaryAll (Emp_Code, BasicSalary,TotalAgorBdalat,TotalAgr,TotalEstk,TotalSalary,emp_year,Emp_Month,Compny_Code) " & _
                    " values  (" & DataGridView2.Item(0, x).Value & " ,N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(4, x).Value & "',N'" & DataGridView2.Item(5, x).Value & "',N'" & DataGridView2.Item(18, x).Value & "',N'" & DataGridView2.Item(20, x).Value & "','" & com_year.Text & "','" & com_month.Text & "' ,'" & VarCodeCompny & "' )"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'sum_estk()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        sql = "Delete TB_SalaryAll  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim report As New Rpt_Salary2
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.X_Date1.Text = com_month.Text
        report.X_Date2.Text = com_year.Text
        report.FilterString = "[Emp_Month] = '" & com_month.Text & "' and [emp_year] = '" & com_year.Text & "' and  [NameDeprt] like '%" & Com_Dir.Text & "%'  and  [name] like '%" & Com_Deprt.Text & "%' and  [jopname] like '%" & Com_JopName.Text & "%' and  [Emp_Name] like '%" & Com_Emp.Text & "%'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub TabNavigationPage3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TabNavigationPage1_Paint(sender As Object, e As PaintEventArgs) Handles TabNavigationPage1.Paint

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        varnoform = 6
        Frm_FindEmp.ShowDialog()
    End Sub
End Class