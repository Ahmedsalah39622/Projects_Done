Imports System.Data.OleDb

Public Class Frm_VactionDtat

    Dim valueDir As String
    Dim varcodedisc As Integer
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Dim report As New HR_LeveRequest
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        'report.X_Date1.Text = com_month.Text
        'report.X_Date2.Text = com_year.Text
        report.FilterString = "[No_Order] = '" & txt_NoOrder.Text & "'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click

        vartable = "BD_vactionLookup"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الاجازة"
        Frm_GenralData.ShowDialog()
    End Sub
    Sub Find_Dir()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " SELECT Name FROM     dbo.BD_DIRCTORAY "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl3.DataSource = ds.Tables(0)


        GridView4.Columns(0).Caption = "أسم الادارة"


        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True

        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub



    Sub Find_All()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "SELECT dbo.TB_HR_VactionData.No_Order, dbo.TB_HR_VactionData.Date_Entry, dbo.TB_HR_VactionData.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.BD_VactionLookup.Name, dbo.TB_HR_VactionData.FromDate, " & _
        "                  dbo.TB_HR_VactionData.EndDate, iif(dbo.TB_HR_VactionData.Flag_Vaction=1,'معتمد','غير معتمد') as Status, dbo.TB_HR_VactionData.Resone_Vaction " & _
        " FROM     dbo.TB_HR_VactionData INNER JOIN " & _
        "                  dbo.Emp_employees ON dbo.TB_HR_VactionData.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
        "                  dbo.BD_VactionLookup ON dbo.TB_HR_VactionData.Code_vaction = dbo.BD_VactionLookup.Code "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl1.DataSource = ds.Tables(0)


        GridView1.Columns(0).Caption = "رقم الطلب"
        GridView1.Columns(1).Caption = "تاريخ الطلب"
        GridView1.Columns(2).Caption = "رقم الموظف"
        GridView1.Columns(3).Caption = "أسم الموظف"
        GridView1.Columns(4).Caption = "نوع الاجازة"
        GridView1.Columns(5).Caption = "من فترة "
        GridView1.Columns(6).Caption = "الى فترة"
        GridView1.Columns(7).Caption = "الحالة"
        GridView1.Columns(8).Caption = "سبب الاجازة"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub



    Private Sub frm_DiscountSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_DiscountSalary()
        Find_Dir()
        clear()
        last_Data()
        Find_All()
    End Sub

    Sub fill_DiscountSalary()
        Com_DiscountType.Items.Clear()

        sql = "SELECT     Name " & _
        " FROM         BD_vactionLookup where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_DiscountType.Items.Add(rs("Name").Value)

            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_DiscountType_GotFocus(sender As Object, e As EventArgs) Handles Com_DiscountType.GotFocus
        fill_DiscountSalary()
    End Sub

    Private Sub Com_DiscountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_DiscountType.SelectedIndexChanged

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        valueDir = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        Com_Dir.Text = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql2 = "     Select G1_Item     FROM dbo.VW_FINDDATAITEM2 WHERE  (MG_Item = '" & valueG1 & "') GROUP BY G1_Item   HAVING(G1_Item Is Not NULL)"


        sql2 = " SELECT  dbo.BD_DEPARTMENTS.Name AS Deprt " & _
                " FROM     dbo.BD_DEPARTMENTS INNER JOIN " & _
                "                  dbo.Emp_employees ON dbo.BD_DEPARTMENTS.Code = dbo.Emp_employees.Emp_Code_Department LEFT OUTER JOIN " & _
                "                  dbo.BD_DIRCTORAY ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code " & _
                " where (dbo.BD_DIRCTORAY.Name like '%" & valueDir & "%') " & _
                  " GROUP BY  dbo.BD_DEPARTMENTS.Name "


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Columns(0).Caption = "القسم"
        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.BestFitColumns()
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '====================================================
        valueDir = ""
        'Search()
    End Sub

    Private Sub cmd_New_Click(sender As Object, e As EventArgs) Handles cmd_New.Click
        clear()
        last_Data()
    End Sub

    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(No_Order) AS MaxmamNo  FROM   dbo.TB_HR_VactionData   HAVING(MAX(No_Order) Is Not NULL)  "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_NoOrder.Text = rs3("MaxmamNo").Value + 1
        Else
            txt_NoOrder.Text = 1
            clear()

        End If
    End Sub
    Sub clear()
        txt_EmpNo.Text = ""
        'txt_DiscountValue.Text = ""
        Txt_EmpName.Text = ""
        Com_DiscountType.Text = ""
        'txt_NoOrder.Text = ""
        txt_Notes.Text = ""
        'txt_DiscountValue.Text = ""
        txt_JopName.Text = ""
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        valueDir = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Com_Deprt.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
    End Sub

    Private Sub Txt_EmpName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Txt_EmpName.ButtonClick
        'Vw_EmpCode
        'If Len(Com_Dir.Text) = 0 Then MsgBox("من فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Com_Deprt.Text) = 0 Then MsgBox("من فضلك ادخل القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        'vardir = Com_Dir.Text
        'vardeprt = Com_Deprt.Text


        vartable = "Vw_EmpCode"
        VarOpenlookup = 1115
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        Find_emp()

    End Sub
    Sub Find_emp()
        On Error Resume Next
        sql2 = "   SELECT dbo.Emp_employees.Emp_Code AS code, dbo.Emp_employees.Emp_Name AS Name, dbo.BD_JOBNAMES.Name AS NameJop " & _
             " FROM     dbo.Emp_employees INNER JOIN " & _
             "                  dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
             "        WHERE(dbo.Emp_employees.Emp_Code = '" & txt_EmpNo.Text & "') "

        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then txt_JopName.Text = rs("NameJop").Value
    End Sub




    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click

        If Len(Com_Dir.Text) = 0 Then MsgBox("من فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Deprt.Text) = 0 Then MsgBox("من فضلك ادخل القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_EmpName.Text) = 0 Then MsgBox("من فضلك ادخل اسم الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_DiscountType.Text) = 0 Then MsgBox("من فضلك ادخل نوع الخصم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim dd7 As DateTime = txt_Date.Text
        Dim vardate7 As String
        vardate7 = dd7.ToString("MM-d-yyyy")



        Dim dd8 As DateTime = txt_date1.Text
        Dim vardate8 As String
        vardate8 = dd8.ToString("MM-d-yyyy")


        Dim dd9 As DateTime = txt_date2.Text
        Dim vardate9 As String
        vardate9 = dd9.ToString("MM-d-yyyy")


        sql = "SELECT *  FROM BD_VactionLookup where Name ='" & Com_DiscountType.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodedisc = rs3("code").Value


        sql = "SELECT *  FROM TB_HR_VactionData where No_Order =" & txt_NoOrder.Text & "  "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then MsgBox("رقم تم تكرار", MsgBoxStyle.Critical, "Cerative Smart Software") : Exit Sub





        sql = "INSERT INTO TB_HR_VactionData (No_Order, Code_Emp,Date_Entry,Code_vaction,FromDate,EndDate,Resone_Vaction) " & _
            " values  (" & txt_NoOrder.Text & " ,N'" & txt_EmpNo.Text & "',N'" & vardate7 & "',N'" & varcodedisc & "',N'" & vardate8 & "',N'" & vardate9 & "',N'" & txt_Notes.Text & "'  )"
        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_All()
        add_payment()
    End Sub
    Sub add_payment()



        ''==================================================date From
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim oldmonth As Integer
        Dim oldyear As Integer
        ' Assign a date using standard short format.
        oldDate = txt_date1.Value

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
            Dim dd As DateTime = txt_date1.Value
            Dim vardateStart As String
            vardateStart = dd.ToString("MM-d-yyyy")

            '==============================================نهاية الفترة
            Dim dd2 As DateTime = txt_date2.Value
            Dim vardateEnd As String
            vardateEnd = dd2.ToString("MM-d-yyyy")

            'and Compny_Code ='" & VarCodeCompny & "'
            sql = "INSERT INTO TB_Vaction_Day (OrderNo, Date_Vaction,Code_Emp) " & _
            " values  ('" & txt_NoOrder.Text & "' ,'" & vardayrent3 & "','" & txt_EmpNo.Text & "' )"
            Cnn.Execute(sql)

            i = i + 1
            'varaddpayment = CurrD
        End While




    End Sub
   

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        find_All_Name()
    End Sub
    Sub find_All_Name()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


        sql2 = "SELECT dbo.TB_HR_VactionData.No_Order, dbo.TB_HR_VactionData.Date_Entry, dbo.TB_HR_VactionData.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.BD_VactionLookup.Name, dbo.TB_HR_VactionData.FromDate, " & _
        "                  dbo.TB_HR_VactionData.EndDate, dbo.TB_HR_VactionData.Resone_Vaction, dbo.BD_DIRCTORAY.Name AS Dir, dbo.BD_DEPARTMENTS.Name AS Deprt, dbo.BD_JOBNAMES.Name AS jopname, iif(dbo.TB_HR_VactionData.Flag_Vaction=1,'معتمد','غير معتمد') as Status " & _
        " FROM     dbo.TB_HR_VactionData INNER JOIN " & _
        "                  dbo.Emp_employees ON dbo.TB_HR_VactionData.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
        "                  dbo.BD_VactionLookup ON dbo.TB_HR_VactionData.Code_vaction = dbo.BD_VactionLookup.Code INNER JOIN " & _
        "                  dbo.BD_DIRCTORAY ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
        "                  dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code INNER JOIN " & _
        "                  dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code where  TB_HR_VactionData.No_Order ='" & GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) & "' "

        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then

            txt_NoOrder.Text = rs("No_Order").Value
            txt_EmpNo.Text = rs("Code_Emp").Value
            Txt_EmpName.Text = rs("Emp_Name").Value
            txt_Date.Text = rs("Date_Entry").Value
            Com_DiscountType.Text = rs("Name").Value
            txt_status.Text = rs("status").Value
            txt_Notes.Text = rs("Resone_Vaction").Value
            Com_Dir.Text = rs("dir").Value
            Com_Deprt.Text = rs("deprt").Value
            txt_JopName.Text = rs("jopname").Value

            txt_date1.Text = rs("FromDate").Value
            txt_date2.Text = rs("EndDate").Value

        End If

    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        find_All_Name()
    End Sub

    Private Sub txt_JopName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_JopName.EditValueChanged

    End Sub

    Private Sub Txt_EmpName_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_EmpName.EditValueChanged

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click

        sql = "select * from  TB_HR_VactionData WHERE No_Order = '" & txt_NoOrder.Text & "' and Flag_Vaction = 1 "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الطلب تم اعتمادة لايمكن حذف الا بعد الغاء الاعتماد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Dim x As String
        x = MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select x
            Case vbNo

            Case vbYes
                sql = "Delete TB_HR_VactionData  WHERE No_Order = '" & txt_NoOrder.Text & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
                clear()
                Find_All()
        End Select
    End Sub

    Private Sub cmd_update_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_EmpNo_TextChanged(sender As Object, e As EventArgs) Handles txt_EmpNo.TextChanged
        On Error Resume Next
        sql = "  SELECT Emp_Code, Emp_Name, NameDir, NameDeprt, JopName       FROM dbo.Vw_Emp WHERE(Emp_Code = '" & txt_EmpNo.Text & "')"
        rs = Cnn.Execute(sql)

        If rs.EOF = False Then
            Com_Dir.Text = rs("NameDir").Value
            Com_Deprt.Text = rs("NameDeprt").Value
            txt_JopName.Text = rs("JopName").Value

        End If
    End Sub
End Class