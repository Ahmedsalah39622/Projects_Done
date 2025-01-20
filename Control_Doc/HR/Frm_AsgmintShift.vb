Imports System.Data.OleDb

Public Class Frm_AsgmintShift

    Dim VarcodeDir, Varcodedeprt, varcode_jop, Varcode_emp, VarcodeShift As Integer

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Dir.ButtonClick
        Com_dept.Items.Clear()
        Com_JopName.Items.Clear()
        Com_NameEmp.Items.Clear()

        vartable = "BD_DIRCTORAY"
        VarOpenlookup = 43
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub Com_dept_GotFocus(sender As Object, e As EventArgs) Handles Com_dept.GotFocus
        Com_dept.Items.Clear()
        Com_JopName.Items.Clear()
        Com_NameEmp.Items.Clear()

        sql = " SELECT        TOP (100) PERCENT dbo.BD_DEPARTMENTS.Code, dbo.BD_DEPARTMENTS.Name " & _
             " FROM            dbo.BD_DIRCTORAY INNER JOIN " & _
             "                         dbo.Emp_employees ON dbo.BD_DIRCTORAY.Code = dbo.Emp_employees.Emp_Code_Dirctorat INNER JOIN " & _
             "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code " & _
             " GROUP BY dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DEPARTMENTS.Code " & _
             " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') " & _
             " ORDER BY dbo.BD_DEPARTMENTS.Code "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_dept.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop

    End Sub

    Private Sub Com_JopName_GotFocus(sender As Object, e As EventArgs) Handles Com_JopName.GotFocus
        Com_JopName.Items.Clear()
        Com_NameEmp.Items.Clear()

        sql = "     SELECT        TOP (100) PERCENT dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name AS NameJop " & _
            " FROM            dbo.BD_DIRCTORAY INNER JOIN " & _
            "                         dbo.Emp_employees ON dbo.BD_DIRCTORAY.Code = dbo.Emp_employees.Emp_Code_Dirctorat INNER JOIN " & _
            "                         dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code INNER JOIN " & _
            "                         dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
            " GROUP BY dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name " & _
            " HAVING        (dbo.BD_DIRCTORAY.Name = '" & Com_Dir.Text & "') AND (dbo.BD_DEPARTMENTS.Name ='" & Com_dept.Text & "') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_JopName.Items.Add(rs("NameJop").Value)
            rs.MoveNext()
        Loop
    End Sub



    Private Sub Com_NameEmp_GotFocus(sender As Object, e As EventArgs) Handles Com_NameEmp.GotFocus
        Com_NameEmp.Items.Clear()
        sql = "Select dbo.Emp_employees.Emp_Name " & _
       " FROM            dbo.Emp_employees INNER JOIN " & _
       "                          dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
       " GROUP BY dbo.BD_JOBNAMES.Name, dbo.Emp_employees.Emp_Name " & _
       " HAVING        (dbo.BD_JOBNAMES.Name = '" & Com_JopName.Text & "') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_NameEmp.Items.Add(rs("Emp_Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_NameEmp.SelectedIndexChanged

    End Sub

    Private Sub Com_dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_dept.SelectedIndexChanged

    End Sub

    Private Sub txt_ShiftName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_ShiftName.ButtonClick
        vartable = "Vw_DataShift"
        VarOpenlookup = 42
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_ShiftName_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_ShiftName.EditValueChanged

    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_ShiftName.Text) = 0 Then MsgBox("من فضلك أختار الوردية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Dir.Text) = 0 Then MsgBox("من فضلك أختار الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_dept.Text) = 0 Then MsgBox("من فضلك أختار القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_JopName.Text) = 0 Then MsgBox("من فضلك أختار المسمى الوظيفى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_NameEmp.Text) = 0 Then MsgBox("من فضلك أختار أسم العامل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        '=================================================بدايةالفترة
        Dim dd As DateTime = txt_date.Value
        Dim vardateStart As String
        vardateStart = dd.ToString("MM-d-yyyy")

        '==============================================نهاية الفترة
        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateEnd As String
        vardateEnd = dd2.ToString("MM-d-yyyy")

        '========================================================رقم الوردية
        sql = "  SELECT *    FROM TB_Shift where   Name_Shift ='" & txt_ShiftName.Text & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarcodeShift = rs("Code_Shift").Value
        '========================================================رقم الادارة
        sql = "  SELECT *    FROM BD_DIRCTORAY where   Name ='" & Com_Dir.Text & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarcodeDir = rs("code").Value
        '========================================================رقم القسم
        sql = "  SELECT *    FROM BD_DEPARTMENTS where   Name ='" & Com_dept.Text & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Varcodedeprt = rs("code").Value
        '========================================================رقم الوظيفة
        sql = "  SELECT *    FROM BD_JOBNAMES where   Name ='" & Com_JopName.Text & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_jop = rs("code").Value
        '==================================================
        sql = "  SELECT *    FROM Emp_employees where   Emp_Name ='" & Com_NameEmp.Text & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Varcode_emp = rs("Emp_Code").Value


        sql2 = "INSERT INTO TB_AisgmentShift (Code_Aisgment, Code_Shift,Str_Date,End_Date,Compny_Code,Code_Dir,Code_Deprt,Code_JopName,Code_Emp) " & _
          " values  ('" & com_asigmentCode.Text & "' ,'" & VarcodeShift & "','" & vardateStart & "' ,'" & vardateEnd & "','" & VarCodeCompny & "','" & VarcodeDir & "','" & Varcodedeprt & "','" & varcode_jop & "','" & Varcode_emp & "')"
        rs = Cnn.Execute(sql2)

        add_payment()


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

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
        If oldDay = 1 Then oldDay = 2 Else oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate) - 1

        oldmonth = Microsoft.VisualBasic.DateAndTime.Month(oldDate)
        oldyear = Microsoft.VisualBasic.DateAndTime.Year(oldDate)
        Dim vardayrent As Date
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

            '=================================================بدايةالفترة
            Dim dd As DateTime = txt_date.Value
            Dim vardateStart As String
            vardateStart = dd.ToString("MM-d-yyyy")

            '==============================================نهاية الفترة
            Dim dd2 As DateTime = txt_date2.Value
            Dim vardateEnd As String
            vardateEnd = dd2.ToString("MM-d-yyyy")

            'and Compny_Code ='" & VarCodeCompny & "'
            sql = "INSERT INTO TB_ShiftDays (Code_AsigmentShift, Date_Shift,Code_Emp,Date_Start,Date_End,Compny_Code) " & _
            " values  ('" & com_asigmentCode.Text & "' ,'" & vardayrent3 & "','" & Varcode_emp & "','" & vardateStart & "','" & vardateEnd & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

            i = i + 1
            'varaddpayment = CurrD
        End While




    End Sub


    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_detalis()
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(Code_Aisgment) AS MaxMaim,Compny_Code FROM            TB_AisgmentShift    GROUP BY Compny_Code  HAVING        (MAX(Code_Aisgment) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            com_asigmentCode.Text = rs("MaxMaim").Value + 1

        Else
            com_asigmentCode.Text = 1


        End If
    End Sub

    Private Sub Com_Dir_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Dir.EditValueChanged

    End Sub

    Private Sub Com_JopName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_JopName.SelectedIndexChanged

    End Sub

    Private Sub com_asigmentCode_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_asigmentCode.ButtonClick
        vartable = "Vw_AsigmentLookUp"
        VarOpenlookup = 44
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_detalis()
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        '     sql2 = "   SELECT        dbo.TB_AisgmentShift.Str_Date, dbo.TB_AisgmentShift.End_Date, dbo.TB_AisgmentShift.Code_Emp, dbo.Emp_employees.Emp_Name,  " & _
        '              "           dbo.BD_DIRCTORAY.Name AS DirName, dbo.BD_DEPARTMENTS.Name AS DeprtNmae, dbo.BD_JOBNAMES.Name AS JopName  " & _
        '" FROM           dbo.TB_AisgmentShift INNER JOIN  " & _
        '             "            dbo.TB_Shift ON dbo.TB_AisgmentShift.Code_Shift = dbo.TB_Shift.Code_Shift AND dbo.TB_AisgmentShift.Compny_Code = dbo.TB_Shift.Compny_Code INNER JOIN  " & _
        '              "           dbo.BD_DIRCTORAY ON dbo.TB_AisgmentShift.Code_Dir = dbo.BD_DIRCTORAY.Code INNER JOIN  " & _
        '              "           dbo.BD_DEPARTMENTS ON dbo.TB_AisgmentShift.Code_Deprt = dbo.BD_DEPARTMENTS.Code INNER JOIN  " & _
        '             "            dbo.BD_JOBNAMES ON dbo.TB_AisgmentShift.Code_JopName = dbo.BD_JOBNAMES.Code INNER JOIN  " & _
        '              "           dbo.Emp_employees ON dbo.TB_AisgmentShift.Code_Emp = dbo.Emp_employees.Emp_Code  " & _
        '" WHERE         (dbo.TB_AisgmentShift.Code_Aisgment = '" & com_asigmentCode.Text & "') AND (dbo.TB_AisgmentShift.Compny_Code = '" & VarCodeCompny & "') "


        sql2 = "SELECT        dbo.TB_AisgmentShift.Str_Date, dbo.TB_AisgmentShift.End_Date, dbo.TB_AisgmentShift.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.BD_DIRCTORAY.Name AS DirName, " & _
        "                         dbo.BD_DEPARTMENTS.Name AS DeprtNmae, dbo.BD_JOBNAMES.Name AS JopName " & _
        " FROM            dbo.TB_AisgmentShift INNER JOIN " & _
        "                         dbo.TB_Shift ON dbo.TB_AisgmentShift.Code_Shift = dbo.TB_Shift.Code_Shift AND dbo.TB_AisgmentShift.Compny_Code = dbo.TB_Shift.Compny_Code INNER JOIN " & _
        "                         dbo.BD_DIRCTORAY ON dbo.TB_AisgmentShift.Code_Dir = dbo.BD_DIRCTORAY.Code AND dbo.TB_AisgmentShift.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code INNER JOIN " & _
        "                         dbo.BD_DEPARTMENTS ON dbo.TB_AisgmentShift.Code_Deprt = dbo.BD_DEPARTMENTS.Code AND dbo.TB_AisgmentShift.Compny_Code = dbo.BD_DEPARTMENTS.Compny_Code INNER JOIN " & _
        "                         dbo.BD_JOBNAMES ON dbo.TB_AisgmentShift.Code_JopName = dbo.BD_JOBNAMES.Code AND dbo.TB_AisgmentShift.Compny_Code = dbo.BD_JOBNAMES.Compny_Code INNER JOIN " & _
        "                         dbo.Emp_employees ON dbo.TB_AisgmentShift.Code_Emp = dbo.Emp_employees.Emp_Code AND dbo.TB_AisgmentShift.Compny_Code = dbo.Emp_employees.Compny_Code " & _
        " WHERE        (dbo.TB_AisgmentShift.Code_Aisgment ='" & com_asigmentCode.Text & "') AND (dbo.TB_AisgmentShift.Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "100"
        GridView6.Columns(3).Width = "250"
        GridView6.Columns(4).Width = "150"
        GridView6.Columns(5).Width = "150"
        GridView6.Columns(6).Width = "150"

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "من فترة"
        GridView6.Columns(1).Caption = "الى فترة "
        GridView6.Columns(2).Caption = "كود العامل"
        GridView6.Columns(3).Caption = "أسم العامل"
        GridView6.Columns(4).Caption = "الادارة"
        GridView6.Columns(5).Caption = "القسم"
        GridView6.Columns(6).Caption = "المسمى الوظيفى"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Private Sub com_asigmentCode_EditValueChanged(sender As Object, e As EventArgs) Handles com_asigmentCode.EditValueChanged

    End Sub

    Private Sub Frm_AsgmintShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class