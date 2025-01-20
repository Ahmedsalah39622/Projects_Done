Public Class Frm_OpenReport

   

    Private Sub Frm_OpenReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Sub fill_Dir()
        Com_Dir.Items.Clear()
        sql = " SELECT     Name  from BD_DIRCTORAY where Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Dir.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_Dir_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub Com_Deprt_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub Com_JopName_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Cmd_Delete_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Cmd_Delete_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_Print_Click_2(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Dim report As New salary3   '

        report.FilterString = "[Emp_Month] = '" & com_month.Text & "' and [emp_year] = '" & com_year.Text & "'  and [NameDirctorat] like '%" & Com_Dir.Text & "%' and [NameDeprt] like '%" & Com_Deprt.Text & "%' and  [NameJop] like '%" & Com_JopName.Text & "%'  and  [Emp_Name] like '%" & Com_Emp.Text & "%' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub

    Private Sub Cmd_Delete_Click_3(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Me.Close()
    End Sub

    Private Sub com_year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_year.SelectedIndexChanged

    End Sub

    Private Sub DocumentViewer1_Load(sender As Object, e As EventArgs) Handles DocumentViewer1.Load

    End Sub

    Private Sub Com_Dir_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_Dir.SelectedIndexChanged
        fill_deprt()
    End Sub

    Private Sub Com_Deprt_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_Deprt.SelectedIndexChanged
        fill_JopName()
    End Sub

    Private Sub Com_JopName_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_JopName.SelectedIndexChanged
        fill_Emp()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        varnoform = 2
        Frm_FindEmp.ShowDialog()
    End Sub
End Class