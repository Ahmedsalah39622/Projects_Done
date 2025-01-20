Imports System.Data.OleDb

Public Class frm_DiscountSalary
    Dim valueDir As String
    Dim varcodedisc As Integer
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Dim report As New HR_DiscoundSalary
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        'report.X_Date1.Text = com_month.Text
        'report.X_Date2.Text = com_year.Text
        report.FilterString = "[No_Order] = '" & txt_NoOrder.Text & "'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click

        vartable = "BD_DiscountSalary"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الخصم"
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



        sql = " SELECT dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount, " & _
  "                iif( dbo.TB_HR_DiscountSalary.Flag_Discount=0,'غير معتمد','معتمد') as status, dbo.TB_HR_DiscountSalary.Resone_Discount " & _
 " FROM     dbo.TB_HR_DiscountSalary INNER JOIN " & _
 "                  dbo.Emp_employees ON dbo.TB_HR_DiscountSalary.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
 "                  dbo.BD_DiscountSalary ON dbo.TB_HR_DiscountSalary.Code_DiscountSalary = dbo.BD_DiscountSalary.Code " & _
 " GROUP BY dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount,  " & _
 "        dbo.TB_HR_DiscountSalary.Flag_Discount, dbo.TB_HR_DiscountSalary.Resone_Discount "





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl1.DataSource = ds.Tables(0)


        GridView1.Columns(0).Caption = "رقم الطلب"
        GridView1.Columns(1).Caption = "رقم الموظف"
        GridView1.Columns(2).Caption = "أسم الموظف"
        GridView1.Columns(3).Caption = "تاريخ الخصم"
        GridView1.Columns(4).Caption = "نوع الخصم"
        GridView1.Columns(5).Caption = "قيمة الخصم"
        GridView1.Columns(6).Caption = "الحالة"
        GridView1.Columns(7).Caption = "سبب الخصم"


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
        " FROM         BD_DiscountSalary where Compny_Code ='" & VarCodeCompny & "' "
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
        sql = "SELECT        MAX(No_Order) AS MaxmamNo  FROM   dbo.TB_HR_DiscountSalary   HAVING(MAX(No_Order) Is Not NULL)  "

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
        txt_DiscountValue.Text = ""
        Txt_EmpName.Text = ""
        Com_DiscountType.Text = ""
        'txt_NoOrder.Text = ""
        txt_Notes.Text = ""
        txt_DiscountValue.Text = ""
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


        vardir = Com_Dir.Text
        vardeprt = Com_Deprt.Text


        vartable = "Vw_EmpCode"
        VarOpenlookup = 1114
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
        If Len(txt_DiscountValue.Text) = 0 Then MsgBox("من فضلك ادخل قيمة الخصم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_DiscountType.Text) = 0 Then MsgBox("من فضلك ادخل نوع الخصم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim dd7 As DateTime = txt_Date.Text
        Dim vardate7 As String
        vardate7 = dd7.ToString("MM-d-yyyy")


        sql = "SELECT *  FROM BD_DiscountSalary where Name ='" & Com_DiscountType.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodedisc = rs3("code").Value
        '======================================

        sql = "SELECT *  FROM TB_HR_DiscountSalary where No_Order =" & txt_NoOrder.Text & "  "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then MsgBox("رقم تم تكرار", MsgBoxStyle.Critical, "Cerative Smart Software") : Exit Sub

        sql = "INSERT INTO TB_HR_DiscountSalary (No_Order, Code_Emp,Date_Entry,Code_DiscountSalary,Value_Discount,Resone_Discount) " & _
            " values  (" & txt_NoOrder.Text & " ,N'" & txt_EmpNo.Text & "',N'" & vardate7 & "',N'" & varcodedisc & "',N'" & txt_DiscountValue.Text & "',N'" & txt_Notes.Text & "'  )"
        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_All()
    End Sub

    Private Sub Txt_EmpName_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_EmpName.EditValueChanged
      

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        find_All_Name()
    End Sub
    Sub find_All_Name()
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        '    sql2 = "    SELECT dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount, " & _
        ' "                iif( dbo.TB_HR_DiscountSalary.Flag_Discount=0,'غير معتمد','معتمد') as status, dbo.TB_HR_DiscountSalary.Resone_Discount " & _
        '" FROM     dbo.TB_HR_DiscountSalary INNER JOIN " & _
        '"                  dbo.Emp_employees ON dbo.TB_HR_DiscountSalary.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
        '"                  dbo.BD_DiscountSalary ON dbo.TB_HR_DiscountSalary.Code_DiscountSalary = dbo.BD_DiscountSalary.Code " & _
        '" GROUP BY dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount,  " & _
        '"        dbo.TB_HR_DiscountSalary.Flag_Discount, dbo.TB_HR_DiscountSalary.Resone_Discount having dbo.TB_HR_DiscountSalary.No_Order ='" & GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) & "' "



        sql2 = "  SELECT dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount, " & _
  "                 iif( dbo.TB_HR_DiscountSalary.Flag_Discount=1,'معتمد','غير معتمد') as status, dbo.TB_HR_DiscountSalary.Resone_Discount, dbo.BD_DIRCTORAY.Name AS Dir, dbo.BD_DEPARTMENTS.Name AS Deprt, dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name as jopnmae " & _
  " FROM     dbo.TB_HR_DiscountSalary INNER JOIN " & _
  "                  dbo.Emp_employees ON dbo.TB_HR_DiscountSalary.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
  "                  dbo.BD_DiscountSalary ON dbo.TB_HR_DiscountSalary.Code_DiscountSalary = dbo.BD_DiscountSalary.Code INNER JOIN " & _
  "                  dbo.BD_DIRCTORAY ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
  "                  dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code  INNER JOIN " & _
  "                dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
  " GROUP BY dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount,  " & _
  "        dbo.TB_HR_DiscountSalary.Flag_Discount, dbo.TB_HR_DiscountSalary.Resone_Discount, dbo.BD_DIRCTORAY.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_DEPARTMENTS.Name, dbo.BD_JOBNAMES.Name having dbo.TB_HR_DiscountSalary.No_Order ='" & GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) & "' "




        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then

            txt_NoOrder.Text = rs("No_Order").Value
            txt_EmpNo.Text = rs("Code_Emp").Value
            Txt_EmpName.Text = rs("Emp_Name").Value
            txt_Date.Text = rs("Date_Entry").Value
            Com_DiscountType.Text = rs("Name").Value
            txt_DiscountValue.Text = rs("Value_Discount").Value
            txt_status.Text = rs("status").Value
            txt_Notes.Text = rs("Resone_Discount").Value
            Com_Dir.Text = rs("dir").Value
            Com_Deprt.Text = rs("deprt").Value
            txt_JopName.Text = rs("jopnmae").Value



        End If

    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        find_All_Name()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click

        sql = "select * from  TB_HR_DiscountSalary WHERE No_Order = '" & txt_NoOrder.Text & "' and Flag_Discount = 1 "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الطلب تم اعتمادة لايمكن حذف الا بعد الغاء الاعتماد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Dim x As String
        x = MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_HR_DiscountSalary  WHERE No_Order = '" & txt_NoOrder.Text & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
                clear()
                Find_All()

                'Find()
                'Fill_Data()



        End Select
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

    Private Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click

    End Sub
End Class