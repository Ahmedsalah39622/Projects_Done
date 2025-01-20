Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_Financial_Period
    Dim varcodeyear As Integer
  
    Private Sub Frm_Financial_Period_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_status.Items.Add("مفتوحة")
        Com_status.Items.Add("مغلقة")

        txt_Code.Text = VarCodeCompny
        txt_nameCompny.Text = VarNameCompny
        find_allyear()
        find_PeriodAll()
    End Sub
    Sub find_allyear()
        sql = "Select YearName       FROM dbo.St_SetupYear order by YearName  "
        find_AllData()
    End Sub
    Sub find_AllData()
        If varCodeConnaction = 1 Then '======Sql

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
            GridView1.Columns(0).Caption = "السنوات المفتوحة الحالية"

            GridView1.Columns(0).Width = "150"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
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
              GridView1.Columns(0).Caption = "السنوات المفتوحة الحالية"

            GridView1.Columns(0).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Sub find_PeriodAll()


        sql = "SELECT dbo.St_Period.Compny_Code,St_CompnyInfo.Compny_Name, dbo.St_SetupYear.YearName, dbo.St_Period.Code_Period, dbo.St_Period.Start_Period, dbo.St_Period.End_Period,IIF(dbo.St_Period.Flag_Period=1,'مفتوحة','مغلقة') as Status, dbo.St_Period.Notes " & _
        " FROM     dbo.St_Period INNER JOIN " & _
        "                  dbo.St_CompnyInfo ON dbo.St_Period.Compny_Code = dbo.St_CompnyInfo.Compny_Code INNER JOIN " & _
        "                  dbo.St_SetupYear ON dbo.St_Period.Code_Year = dbo.St_SetupYear.Code_Year where dbo.St_SetupYear.YearName like '%" & txt_Year.Text & "%' and dbo.St_Period.Compny_Code ='" & VarCodeCompny & "' order by dbo.St_SetupYear.YearName,dbo.St_Period.Code_Period "


        If varCodeConnaction = 1 Then '======Sql

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
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "كود الشركة"
            GridView6.Columns(1).Caption = "أسم الشركة"
            GridView6.Columns(2).Caption = "السنة المالية"
            GridView6.Columns(3).Caption = "كود الفترة"
            GridView6.Columns(4).Caption = "بداية الفترة"
            GridView6.Columns(5).Caption = "نهاية الفترة"
            GridView6.Columns(6).Caption = "الحالة"
            GridView6.Columns(7).Caption = "ملاحظات"

            GridView6.Columns(0).Width = "10"
            GridView6.Columns(1).Width = "10"
            GridView6.Columns(2).Width = "10"
            GridView6.Columns(3).Width = "10"
            GridView6.Columns(4).Width = "10"
            GridView6.Columns(5).Width = "10"
            GridView6.Columns(6).Width = "10"
            GridView6.Columns(7).Width = "10"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "كود الشركة"
            GridView6.Columns(1).Caption = "أسم الشركة"
            GridView6.Columns(2).Caption = "السنة المالية"
            GridView6.Columns(3).Caption = "كود الفترة"
            GridView6.Columns(4).Caption = "بداية الفترة"
            GridView6.Columns(5).Caption = "نهاية الفترة"
            GridView6.Columns(6).Caption = "الحالة"
            GridView6.Columns(7).Caption = "ملاحظات"

            GridView6.Columns(0).Width = "10"
            GridView6.Columns(1).Width = "50"
            GridView6.Columns(2).Width = "15"
            GridView6.Columns(3).Width = "15"
            GridView6.Columns(4).Width = "15"
            GridView6.Columns(5).Width = "15"
            GridView6.Columns(6).Width = "15"
            GridView6.Columns(7).Width = "50"


            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)

        clear()
    End Sub

   
    Sub clear()
        'txt_nameCompny.Text = ""
        txt_Notes.Text = ""
    End Sub

   

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_CodePeriod.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub
        If Len(Com_status.Text) = 0 Then MsgBox("من فضلك ادخل الحالة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        Dim dd3 As DateTime = txt_DateStart.Value
        Dim varteststart, varteststart2 As String
        varteststart = dd3.ToString("yyyy")
        varteststart2 = dd3.ToString("MM-d-yyyy")
        '================================
        Dim dd4 As DateTime = txt_DateEnd.Value
        Dim vartestEnd, vartestEnd2 As String
        vartestEnd = dd4.ToString("yyyy")
        vartestEnd2 = dd4.ToString("MM-d-yyyy")
        Dim varflag As Integer

        If varteststart <> txt_Year.Text Then MsgBox("تاريخ بداية الفترة ليس موجود فى سنة  " & txt_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub
        If vartestEnd <> txt_Year.Text Then MsgBox("تاريخ نهاية الفترة ليس موجود فى سنة  " & txt_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        If Com_status.Text = "مفتوحة" Then varflag = 1
        If Com_status.Text <> "مفتوحة" Then varflag = 2


        sql = "    SELECT YearName, Code_Year      FROM dbo.St_SetupYear GROUP BY YearName, Code_Year HAVING (YearName = '" & txt_Year.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeyear = rs("Code_Year").Value

        Dim sql2 As String
        sql2 = "INSERT INTO St_Period (Compny_Code, Code_Period,Start_Period,End_Period,Flag_Period,Notes,Code_Year) " & _
          " values  ('" & VarCodeCompny & "' ,'" & txt_CodePeriod.Text & "','" & varteststart2 & "','" & vartestEnd2 & "','" & varflag & "',N'" & txt_Notes.Text & "','" & varcodeyear & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")


    End Sub




    Sub last_Period()
        '========================================CodeYear

        sql = "    SELECT YearName, Code_Year      FROM dbo.St_SetupYear GROUP BY YearName, Code_Year HAVING (YearName = '" & txt_Year.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeyear = rs("Code_Year").Value
        '===================================================================

        sql = "  SELECT MAX(Code_Period) AS MaxmimNo    FROM dbo.St_Period GROUP BY Compny_Code, Code_Year HAVING (Compny_Code = '" & VarCodeCompny & "') AND (Code_Year = '" & varcodeyear & "')"

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_CodePeriod.Text = rs3("MaxmimNo").Value + 1
        Else
            txt_CodePeriod.Text = 1
            clear()

        End If
    End Sub



    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        txt_Year.Text = value
        last_Period()
        find_PeriodAll()
    End Sub

    Private Sub SimpleButton10_Click_1(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Frm_SetupYear.ShowDialog()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        Dim value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        Dim value2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))


        '===================================Find
        sql = "    SELECT dbo.St_Period.Compny_Code,St_CompnyInfo.Compny_Name, dbo.St_SetupYear.YearName, dbo.St_Period.Code_Period, dbo.St_Period.Start_Period, dbo.St_Period.End_Period,IIF(dbo.St_Period.Flag_Period=1,'مفتوحة','مغلقة') as Status, dbo.St_Period.Notes " & _
            " FROM     dbo.St_Period INNER JOIN " & _
            "                  dbo.St_CompnyInfo ON dbo.St_Period.Compny_Code = dbo.St_CompnyInfo.Compny_Code INNER JOIN " & _
            "                  dbo.St_SetupYear ON dbo.St_Period.Code_Year = dbo.St_SetupYear.Code_Year where dbo.St_SetupYear.YearName ='" & value & "' and code_period = '" & value2 & "' and dbo.St_Period.Compny_Code = '" & VarCodeCompny & "' order by dbo.St_SetupYear.YearName,dbo.St_Period.Code_Period "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Code.Text = rs("Compny_Code").Value
            txt_nameCompny.Text = rs("Compny_Name").Value
            txt_Year.Text = rs("YearName").Value
            txt_CodePeriod.Text = rs("code_period").Value
            txt_DateStart.Text = rs("Start_Period").Value
            txt_DateEnd.Text = rs("End_Period").Value
            Com_status.Text = rs("Status").Value
            txt_Notes.Text = rs("Notes").Value

        Else
            clear()
        End If
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        If Len(txt_CodePeriod.Text) = 0 Then MsgBox("من فضلك ادخل كود الفترة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        '===========================================Startdate
        Dim dd3 As DateTime = txt_DateStart.Value
        Dim varteststart, varteststart2 As String
        varteststart2 = dd3.ToString("MM-d-yyyy")
        varteststart = dd3.ToString("yyyy")
        '=============================================Enddate
        Dim dd4 As DateTime = txt_DateEnd.Value
        Dim vartestEnd, vartestEnd2 As String
        vartestEnd2 = dd4.ToString("MM-d-yyyy")
        vartestEnd = dd4.ToString("yyyy")
        Dim varflag As Integer

        If varteststart <> txt_Year.Text Then MsgBox("تاريخ بداية الفترة ليس موجود فى سنة  " & txt_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub
        If vartestEnd <> txt_Year.Text Then MsgBox("تاريخ نهاية الفترة ليس موجود فى سنة  " & txt_Year.Text, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        If Com_status.Text = "مفتوحة" Then varflag = 1
        If Com_status.Text <> "مفتوحة" Then varflag = 2


        sql = "    SELECT YearName, Code_Year      FROM dbo.St_SetupYear GROUP BY YearName, Code_Year HAVING (YearName = '" & txt_Year.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeyear = rs("Code_Year").Value

        Dim sql2 As String
        sql2 = "UPDATE  St_Period  SET Start_Period='" & varteststart2 & "' , End_Period = '" & vartestEnd2 & "',Flag_Period ='" & varflag & "',Notes ='" & txt_Notes.Text & "' WHERE Compny_Code = '" & txt_Code.Text & "' and Code_Period = '" & txt_CodePeriod.Text & "' and Code_Year = '" & varcodeyear & "'    "
        rs = Cnn.Execute(sql2)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "ERP Solution Software Module")
        txt_Year.Text = ""
        txt_CodePeriod.Text = ""
        find_allyear()
        find_PeriodAll()
    End Sub

  
   
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim x As String
        x = MsgBox("هل تريد الحذف ؟", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql = "    SELECT YearName, Code_Year      FROM dbo.St_SetupYear GROUP BY YearName, Code_Year HAVING (YearName = '" & txt_Year.Text & "')"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcodeyear = rs("Code_Year").Value

                sql = "Delete  St_Period  WHERE Compny_Code = '" & txt_Code.Text & "' and Code_Period = '" & txt_CodePeriod.Text & "' and Code_Year = '" & varcodeyear & "'     "
                rs = Cnn.Execute(sql)
                MsgBox("تم الحذف", MsgBoxStyle.Information, "ERP Solution Software Module")

                txt_Year.Text = ""
                txt_CodePeriod.Text = ""
                find_allyear()
                find_PeriodAll()


        End Select
    End Sub
End Class