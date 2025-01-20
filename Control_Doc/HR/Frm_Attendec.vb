Imports System.Data.OleDb
Imports System.Globalization

Public Class Frm_Attendec
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        'Com_dept.Items.Clear()
        'Com_JopName.Items.Clear()
        'Com_NameEmp.Items.Clear()

        vartable = "BD_DIRCTORAY"
        VarOpenlookup = 54
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        Find_Data()
    End Sub


    Private Sub Com_dept_GotFocus(sender As Object, e As EventArgs)
        'Com_dept.Items.Clear()
        'Com_JopName.Items.Clear()
        'Com_NameEmp.Items.Clear()

        'sql = " SELECT        TOP (100) PERCENT dbo.BD_DEPARTMENTS.Code, dbo.BD_DEPARTMENTS.Name " & _
        '     " FROM            dbo.BD_DIRCTORAY INNER JOIN " & _
        '     "                         dbo.Emp_employees ON dbo.BD_DIRCTORAY.Code = dbo.Emp_employees.Emp_Code_Dirctorat INNER JOIN " & _
        '     "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code " & _
        '     " GROUP BY dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DEPARTMENTS.Code " & _
        '     " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') " & _
        '     " ORDER BY dbo.BD_DEPARTMENTS.Code "

        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    Com_dept.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop

    End Sub

    Private Sub Com_JopName_GotFocus(sender As Object, e As EventArgs)
        'Com_JopName.Items.Clear()
        'Com_NameEmp.Items.Clear()

        'sql = "     SELECT        TOP (100) PERCENT dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name AS NameJop " & _
        '    " FROM            dbo.BD_DIRCTORAY INNER JOIN " & _
        '    "                         dbo.Emp_employees ON dbo.BD_DIRCTORAY.Code = dbo.Emp_employees.Emp_Code_Dirctorat INNER JOIN " & _
        '    "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code INNER JOIN " & _
        '    "                         dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
        '    " GROUP BY dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name " & _
        '    " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') AND (dbo.BD_DEPARTMENTS.Name ='" & Com_dept.Text & "') "

        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    Com_JopName.Items.Add(rs("NameJop").Value)
        '    rs.MoveNext()
        'Loop
    End Sub



    Private Sub Com_NameEmp_GotFocus(sender As Object, e As EventArgs)
        ' Com_NameEmp.Items.Clear()
        ' sql = "Select dbo.Emp_employees.Emp_Name " & _
        '" FROM            dbo.Emp_employees INNER JOIN " & _
        '"                          dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
        '" GROUP BY dbo.BD_JOBNAMES.Name, dbo.Emp_employees.Emp_Name " & _
        '" HAVING        (dbo.BD_JOBNAMES.Name = '" & Com_JopName.Text & "') "

        ' rs = Cnn.Execute(sql)
        ' Do While Not rs.EOF
        '     Com_NameEmp.Items.Add(rs("Emp_Name").Value)
        '     rs.MoveNext()
        ' Loop
    End Sub
    Sub Find_Data()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql2 = "       SELECT        IDGenral, DateM, CodeLevel4, AccountName, DisTable, Debit_EGP, Cridit_EGP, NameCruuncey, rat, Debit, Cridit, CostCenterNo, RTRIM(NameContcenter) AS NameContcenter, Type_Bill      FROM dbo.Vw_All_GL_Data" & _
        '    " where  (DateM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and  (Compny_Code = '" & VarCodeCompny & "') "

        'sql2 = "SELECT        Date_Day, DayEmp, TimeIN, TimeOut, Emp_Name, NameDirctorat, NameDeprt, NameJop " & _
        '" FROM            dbo.Vw_All_Att " & _
        '" WHERE        (Date_Day >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Date_Day <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and NameDirctorat like N'%" & Com_Dir.Text & "%' and  NameDeprt like N'%" & Com_dept.Text & "%' and  NameJop like N'%" & Com_JopName.Text & "%' and  Emp_Name like N'%" & Com_NameEmp.Text & "%'  and (dbo.Vw_All_Att.Compny_Code = '" & VarCodeCompny & "') "

        '        sql2 = "SELECT        TOP (100) PERCENT dbo.Vw_AMEmp.Date_User AS Date_Day, format(dbo.Vw_AMEmp.Date_User, 'ddd') AS DayEmp, dbo.Vw_AMEmp.TimeData AS TimeIN, dbo.Vw_PM_EMP.TimeData AS TimeOut,  " & _
        '"                         dbo.Vw_Emp.Emp_Name, dbo.Vw_Emp.NameDir AS NameDirctorat, dbo.Vw_Emp.NameDeprt, dbo.Vw_Emp.JopName AS NameJop " & _
        '" FROM            dbo.Vw_AMEmp LEFT OUTER JOIN " & _
        '"                         dbo.Vw_Emp ON dbo.Vw_AMEmp.Code = dbo.Vw_Emp.Emp_Code LEFT OUTER JOIN " & _
        '"                         dbo.Vw_PM_EMP ON dbo.Vw_AMEmp.Code = dbo.Vw_PM_EMP.Code AND dbo.Vw_AMEmp.Date_User = dbo.Vw_PM_EMP.Date_User " & _
        '"       WHERE        (dbo.Vw_AMEmp.Date_User >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Vw_AMEmp.Date_User <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and Vw_Emp.NameDir like N'%" & Com_Dir.Text & "%' and  Vw_Emp.NameDeprt like N'%" & Com_dept.Text & "%' and  dbo.Vw_Emp.JopName like N'%" & Com_JopName.Text & "%' and  Vw_Emp.Emp_Name like N'%" & Com_NameEmp.Text & "%'  and (dbo.Vw_Emp.Compny_Code = '" & VarCodeCompny & "')  order by dbo.Vw_AMEmp.Date_User "

        sql2 = "      SELECT        dbo.Vw_AM_PM.Date_Day, dbo.Vw_AM_PM.DayEmp, dbo.Vw_AM_PM.TimeIN, dbo.Vw_AM_PM.TimeOut, dbo.Vw_Emp.Emp_Name, dbo.Vw_Emp.NameDir, dbo.Vw_Emp.NameDeprt, dbo.Vw_Emp.JopName " & _
              " FROM            dbo.Vw_AM_PM INNER JOIN " & _
              "                         dbo.Vw_Emp ON dbo.Vw_AM_PM.Code = dbo.Vw_Emp.Emp_Code " & _
              "       WHERE(dbo.Vw_Emp.Compny_Code = '" & VarCodeCompny & "') and (Vw_AM_PM.Date_Day >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Vw_AM_PM.Date_Day <= CONVERT(DATETIME, '" & vardate2 & "', 102)) order by   dbo.Vw_AM_PM.Date_Day  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "70"
        GridView6.Columns(2).Width = "170"
        GridView6.Columns(3).Width = "170"
        GridView6.Columns(4).Width = "200"
        GridView6.Columns(5).Width = "170"
        GridView6.Columns(6).Width = "170"
        GridView6.Columns(7).Width = "170"




        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "التاريخ"
        GridView6.Columns(1).Caption = "اليوم"
        GridView6.Columns(2).Caption = "دخول"
        GridView6.Columns(3).Caption = "خروج"
        GridView6.Columns(4).Caption = "أسم الموظف"
        GridView6.Columns(5).Caption = "الادارة"
        GridView6.Columns(6).Caption = "القسم"
        GridView6.Columns(7).Caption = "المسمى الوظيفى"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count




    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Find_Data()
    End Sub

    Private Sub Com_Dir_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Com_dept_SelectedIndexChanged(sender As Object, e As EventArgs)
        Find_Data()
    End Sub

    Private Sub Com_JopName_SelectedIndexChanged(sender As Object, e As EventArgs)
        Find_Data()
    End Sub

    Private Sub Com_NameEmp_SelectedIndexChanged(sender As Object, e As EventArgs)
        Find_Data()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView6.ShowRibbonPrintPreview()

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)

        'On Error Resume Next
        'Dim sql3 As String
        'Dim vartimeOut, vartimeOut2 As String
        'sql = "Delete TB_TempReport1   "
        'rs = Cnn.Execute(sql)

        'Dim result As Integer = 0
        'For rowHandle As Integer = 0 To GridView6.DataRowCount - 1

        '    Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        '    vartimeOut2 = ""
        '    vartimeOut = ""
        '    vartimeOut = Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(3)))
        '    If vartimeOut = "" Then vartimeOut2 = " " Else vartimeOut2 = vartimeOut
        '    sql3 = "insert into TB_TempReport1  (DateAtt,dayatt,TimeIn,TimeOut,NameEmp,NameDir,NameDeprt,Compny_Code)  values ('" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(0))) & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(1))) & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(2))) & "','" & vartimeOut2 & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(4))) & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(5))) & "','" & Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(6))) & "','" & VarCodeCompny & "' )"
        '    rs2 = Cnn.Execute(sql3)

        'Next rowHandle
        'Frm_reportAtt.Show()

    End Sub

    Private Sub Frm_Attendec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    
    Private Sub Cmd_ReportOpen_Click(sender As Object, e As EventArgs) Handles Cmd_ReportOpen.Click
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim vardate As String
        Dim vardate2, vardatetest1, vardatetest2 As String
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = Txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(Txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"


        Dim report As New Att
        report.lab_Deprt.Text = Com_Dir.Text
        report.lab_Dir.Text = Com_Deprt.Text
        report.lab_JopName.Text = Com_JopName.Text
        report.lab_EmpName.Text = Com_Emp.Text
        report.X_Date1.Text = txt_date.Value
        report.X_Date2.Text = txt_date2.Value

        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = " [Date_Day] Between(" & vardatetest1 & ", " & vardatetest2 & ") and [NameDirctorat] like '%" & Com_Dir.Text & "%' and [NameDeprt] like '%" & Com_Deprt.Text & "%' and  [NameJop] like '%" & Com_JopName.Text & "%'  and  [Emp_Name] like '%" & Com_Emp.Text & "%' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
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

    Private Sub DocumentViewer1_Load(sender As Object, e As EventArgs) Handles DocumentViewer1.Load

    End Sub

    Private Sub Com_JopName_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_JopName.SelectedIndexChanged
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

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        varnoform = 5
        Frm_FindEmp.ShowDialog()
    End Sub
End Class