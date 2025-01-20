Imports System.Data.OleDb

Public Class Frm_TimeDeprtment
    Dim VarcodeDir, Varcodedeprt, varcode_jop, Varcode_emp, Varcode_Vaction As Integer
    Dim value2 As String

    Private Sub Frm_Vaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Dir()
        Find_all()
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
    Sub Find_all()
        On Error Resume Next

        'sql = "SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn, " & _
        '"                         dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out  " & _
        '" FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN " & _
        '"                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code " & _
        '"        WHERE(dbo.Vw_TimeSeting1.Compny_Code = '" & VarCodeCompny & "') "

        sql = " SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn, " & _
  "                        dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out " & _
 " FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN " & _
 "                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code " & _
 " GROUP BY dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn,  " & _
 "        dbo.Vw_TimeSeting2.DateIn, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out " & _
 " "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView2.Columns(0).Caption = "الكود"
        GridView2.Columns(1).Caption = "الادارة"
        GridView2.Columns(2).Caption = "القسم"
        GridView2.Columns(3).Caption = "المسمى الوظيفى"
        GridView2.Columns(4).Caption = "أسم الموظف"
        GridView2.Columns(5).Caption = "من فترة"
        GridView2.Columns(6).Caption = "الى فترة"
        GridView2.Columns(7).Caption = "وقت الدخول"
        GridView2.Columns(8).Caption = "وقت الخروج"

        GridView2.Appearance.Row.Font = New Font(GridView2.Appearance.Row.Font, FontStyle.Bold)
        GridView2.Appearance.Row.Options.UseFont = True

        GridView2.Columns(0).Width = "100"
        GridView2.Columns(1).Width = "100"
        GridView2.Columns(2).Width = "150"
        GridView2.Columns(3).Width = "120"
        GridView2.Columns(4).Width = "120"
        GridView2.Columns(5).Width = "120"
        GridView2.Columns(6).Width = "120"
        GridView2.Columns(7).Width = "120"
        GridView2.Columns(8).Width = "120"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView2.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

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



    Sub last_Data()

        sql = "  SELECT        MAX(Code_Move) AS MaxMaim,Compny_Code FROM            Seting_Time    GROUP BY Compny_Code  HAVING        (MAX(Code_Move) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            com_Code.Text = rs("MaxMaim").Value + 1

        Else
            com_Code.Text = 1


        End If
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear()
        find_data()
    End Sub
    Sub clear()
        Com_Dir.Text = ""
        Com_Emp.Text = ""
        Com_Deprt.Text = ""
        Com_JopName.Text = ""
        cmd_save.Enabled = True
        Cmd_Delete.Enabled = False
    End Sub



    Private Sub Com_JopName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_JopName.SelectedIndexChanged
        fill_Emp()
    End Sub

    Private Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click
        If Len(com_Code.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        add_payment()
        clear()

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_all()
        find_data()
    End Sub

    Sub add_payment()



        ''==================================================date From
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim oldmonth As Integer
        Dim oldyear As Integer
        ' Assign a date using standard short format.
        oldDate = txt_date.Value

        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        'If oldDay = 1 Then oldDay = 2 Else oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        oldmonth = Microsoft.VisualBasic.DateAndTime.Month(oldDate)
        oldyear = Microsoft.VisualBasic.DateAndTime.Year(oldDate)
        Dim vardayrent, vardayrent2 As Date
        'Dim vardayrent2 As Date
        vardayrent = CDate(oldDay & "/" & oldmonth & "/" & oldyear)

        'If Com_TypeContract.Text = "يومى" Then txt_date.Value = DateAdd("d", Val(txt_CountPayment.Text), vardayrent)
        Dim i As Integer
        i = 1
        Dim oldDate2 As Date
        Dim oldDay2 As Integer
        Dim oldmonth2 As Integer
        Dim oldyear2 As Integer


        oldDate2 = txt_date2.Value
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)
        oldmonth2 = Microsoft.VisualBasic.DateAndTime.Month(oldDate2)
        oldyear2 = Microsoft.VisualBasic.DateAndTime.Year(oldDate2)

        vardayrent2 = CDate(oldDay2 & "/" & oldmonth2 & "/" & oldyear2)


        If vardayrent = vardayrent2 Then oldDay = oldDay
        If vardayrent <> vardayrent2 And oldDay <> 1 Then oldDay = oldDay


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
            If oldDay3 = 1 Then oldDay3 = 2
            vardayrent3 = oldmonth3 & "/" & oldDay3 - 1 & "/" & oldyear3
            'vardayrent3 = CDate(oldDay3 & "/" & oldmonth3 & "/" & oldyear3)
            '========================================================رقم الادارة
            sql = "  SELECT *    FROM BD_DIRCTORAY where   Name ='" & Com_Dir.Text & "'   "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then VarcodeDir = rs("code").Value
            '========================================================رقم القسم
            sql = "  SELECT *    FROM BD_DEPARTMENTS where   Name ='" & Com_Deprt.Text & "'   "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then Varcodedeprt = rs("code").Value
            '========================================================رقم الوظيفة
            sql = "  SELECT *    FROM BD_JOBNAMES where   Name ='" & Com_JopName.Text & "'   "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_jop = rs("code").Value
            '==================================================
            sql = "  SELECT *    FROM Emp_employees where   Emp_Name ='" & Com_Emp.Text & "'   "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then Varcode_emp = rs("Emp_Code").Value

            '=================================================بدايةالفترة
            Dim dd As DateTime = txt_date.Value
            Dim vardateStart As String
            vardateStart = dd.ToString("MM-d-yyyy")

            '==============================================نهاية الفترة
            Dim dd2 As DateTime = txt_date2.Value
            Dim vardateEnd As String
            vardateEnd = dd2.ToString("MM-d-yyyy")

            'and Compny_Code ='" & VarCodeCompny & "'
            sql = "INSERT INTO Seting_Time (Code_Move, Date_From,code_dir,code_deprt,code_jop,emp_code,Time_in,Time_out,Compny_Code) " & _
            " values  ('" & com_Code.Text & "' ,'" & vardayrent3 & "','" & VarcodeDir & "','" & Varcodedeprt & "','" & varcode_jop & "','" & Varcode_emp & "','" & TimeEdit1.Text & "','" & TimeEdit2.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

            i = i + 1
            'varaddpayment = CurrD
        End While




    End Sub

    Private Sub Com_Dir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Dir.SelectedIndexChanged
        fill_deprt()
    End Sub

    Private Sub Com_Deprt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Deprt.SelectedIndexChanged
        fill_JopName()
    End Sub

    
    Sub find_data()

        sql = "SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn, " & _
"                         dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out  " & _
" FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN " & _
"                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code " & _
"        WHERE(dbo.Vw_TimeSeting1.Compny_Code = '" & VarCodeCompny & "') and Vw_TimeSeting1.Code_Move ='" & com_Code.Text & "'  "




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الادارة"
        GridView1.Columns(2).Caption = "القسم"
        GridView1.Columns(3).Caption = "المسمى الوظيفى"
        GridView1.Columns(4).Caption = "أسم الموظف"
        GridView1.Columns(5).Caption = "من فترة"
        GridView1.Columns(6).Caption = "الى فترة"
        GridView1.Columns(7).Caption = "وقت الدخول"
        GridView1.Columns(8).Caption = "وقت الخروج"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "150"
        GridView1.Columns(3).Width = "120"
        GridView1.Columns(4).Width = "120"
        GridView1.Columns(5).Width = "120"
        GridView1.Columns(6).Width = "120"
        GridView1.Columns(7).Width = "120"
        GridView1.Columns(8).Width = "120"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub

    Sub fill_data()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        Dim value2 = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        sql = "SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn,  " & _
        "                         dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out  " & _
        " FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN  " & _
        "                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code  " & _
        " WHERE        (dbo.Vw_TimeSeting1.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_TimeSeting1.Code_Move = '" & value2 & "')  "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            com_Code.Text = rs("Code_Move").Value
            txt_date.Text = rs("DateIn").Value
            txt_date2.Text = rs("DateOut").Value
            TimeEdit1.Time = rs("Time_in").Value
            TimeEdit2.Time = rs("Time_out").Value

        End If
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Seting_Time  WHERE Code_Move = " & com_Code.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

                clear()

                Find_all()
                find_data()
                last_Data()

        End Select
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView2.ShowPrintPreview()

    End Sub

  
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'On Error Resume Next
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        Dim value2 = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))

        fill_data()

        'sql = "SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn,  " & _
        '"                         dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out  " & _
        '" FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN  " & _
        '"                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code  " & _
        '" WHERE        (dbo.Vw_TimeSeting1.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_TimeSeting1.Code_Move = '" & value2 & "')  "


        sql = " SELECT        dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn, " & _
 "                         dbo.Vw_TimeSeting2.DateIn AS DateOut, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out " & _
 " FROM            dbo.Vw_TimeSeting1 LEFT OUTER JOIN " & _
 "                         dbo.Vw_TimeSeting2 ON dbo.Vw_TimeSeting1.Code_Move = dbo.Vw_TimeSeting2.Code_Move AND dbo.Vw_TimeSeting1.Compny_Code = dbo.Vw_TimeSeting2.Compny_Code " & _
 "        WHERE(dbo.Vw_TimeSeting1.Compny_Code = '" & VarCodeCompny & "') " & _
 " GROUP BY dbo.Vw_TimeSeting1.Code_Move, dbo.Vw_TimeSeting1.NameDir, dbo.Vw_TimeSeting1.NameDeprt, dbo.Vw_TimeSeting1.Name, dbo.Vw_TimeSeting1.Emp_Name, dbo.Vw_TimeSeting1.DateIn, " & _
 "        dbo.Vw_TimeSeting2.DateIn, dbo.Vw_TimeSeting1.Time_in, dbo.Vw_TimeSeting1.Time_out " & _
 "        HAVING(dbo.Vw_TimeSeting1.Code_Move =  '" & value2 & "') "




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الادارة"
        GridView1.Columns(2).Caption = "القسم"
        GridView1.Columns(3).Caption = "المسمى الوظيفى"
        GridView1.Columns(4).Caption = "أسم الموظف"
        GridView1.Columns(5).Caption = "من فترة"
        GridView1.Columns(6).Caption = "الى فترة"
        GridView1.Columns(7).Caption = "وقت الدخول"
        GridView1.Columns(8).Caption = "وقت الخروج"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "150"
        GridView1.Columns(3).Width = "120"
        GridView1.Columns(4).Width = "120"
        GridView1.Columns(5).Width = "120"
        GridView1.Columns(6).Width = "120"
        GridView1.Columns(7).Width = "120"
        GridView1.Columns(8).Width = "120"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        TabPane1.SelectedPageIndex = 0

        cmd_save.Enabled = False
        Cmd_Delete.Enabled = True
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        varnoform = 4
        Frm_FindEmp.ShowDialog()
    End Sub
End Class