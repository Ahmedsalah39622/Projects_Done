Imports ADODB
Imports System.Data.OleDb

Public Class Frm_Security2
    Dim varcodeform_scurity As Integer
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "SELECT * FROM dbo.Mune_Form "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "250"


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم القائمة"
        GridView6.Columns(1).Caption = "أسم القائمة "






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

    Private Sub Frm_Security2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_User()
        Fill_Dept()
        find_detalis()
    End Sub
    Sub Fill_User()
        Com_Code.Items.Clear()
        sql = "  Select Emp_Code   FROM dbo.Vw_Emp where Compny_Code ='" & VarCodeCompny & "'  GROUP BY Emp_Code  order by Emp_Code "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Code.Items.Add(rs("Emp_Code").Value)
            rs.MoveNext()
        Loop


    End Sub
    Sub Fill_Dept()
        Com_dept.Items.Clear()
        sql = "  Select Name   FROM dbo.BD_DIRCTORAY where Compny_Code ='" & VarCodeCompny & "'  GROUP BY Name   order by Name "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_dept.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop


    End Sub





    Sub FindGenralData()

        sql = "     SELECT dbo.Mune_Form.FormCode, dbo.Mainmune_Genral.FormNo, dbo.Mainmune_Genral.Form_Name, dbo.Mainmune_Genral.Stutas " & _
      " FROM     dbo.Mune_Form INNER JOIN " & _
       "                 dbo.Mainmune_Genral ON dbo.Mune_Form.FormCode = dbo.Mainmune_Genral.MainFomNo " & _
        "      WHERE(dbo.Mune_Form.FormCode = '" & varcodeform2 & "' )"



        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = 1
                DataGridView2.Item(0, 0).Value = ""
                DataGridView2.Item(1, 0).Value = ""
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("FormNo").Value
                    DataGridView2.Item(1, i).Value = rs("Form_Name").Value



                    rs.MoveNext()


                Next i


                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub



   
    

    Sub savedata_mune()


        '================================================
        sql = "delete from " & " Mainmune_security where MainFomNo = " & varcodeform2 & " and Code_Emp = '" & Com_Code.Text & "' "
        rs = Cnn.Execute(sql)

        For x As Integer = 0 To DataGridView2.Rows.Count - 1
            Dim xx As String
            xx = DataGridView2.Item(0, x).Value
            If xx = "" Then
            Else

                If DataGridView2.Rows(x).Cells(2).Value = True Then varstatus = 1 Else varstatus = 0
                If DataGridView2.Rows(x).Cells(3).Value = True Then var_flagedit = 1 Else var_flagedit = 0
                If DataGridView2.Rows(x).Cells(4).Value = True Then var_flagsave = 1 Else var_flagsave = 0
                If DataGridView2.Rows(x).Cells(5).Value = True Then var_flagdel = 1 Else var_flagdel = 0
                If DataGridView2.Rows(x).Cells(6).Value = True Then var_flagserch = 1 Else var_flagserch = 0
                If DataGridView2.Rows(x).Cells(7).Value = True Then var_flagprint = 1 Else var_flagprint = 0

                sql = "INSERT INTO Mainmune_security (MainFomNo,FormNo,Form_Name,Stutas,Code_Emp,flag_save,flag_Edit,flag_Del,flag_Serch,flag_Print) " & _
                " values  ('" & varcodeform2 & "','" & DataGridView2.Item(0, x).Value & "' ,'" & DataGridView2.Item(1, x).Value & "','" & varstatus & "','" & Com_Code.Text & "','" & var_flagsave & "','" & var_flagedit & "','" & var_flagdel & "','" & var_flagserch & "','" & var_flagprint & "' )"
                rs = Cnn.Execute(sql)
            End If
        Next x

    End Sub

    Sub last_data()
        sql = "  SELECT        MAX(Code_Emp) AS Maxmam FROM            dbo.Users_Department  where  Compny_Code = '" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then Com_Code.Text = rs2("Maxmam").Value + 1
    End Sub


    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        varcodeform_scurity = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        sql = "SELECT dbo.Mainmune_security.MainFomNo, dbo.Mainmune_security.FormNo, dbo.Mainmune_security.Form_Name, dbo.Mainmune_security.Stutas, dbo.Mainmune_security.Code_Emp, dbo.Mainmune_security.flag_save, dbo.Mainmune_security.flag_Edit, dbo.Mainmune_security.flag_Del, dbo.Mainmune_security.flag_Serch, dbo.Mainmune_security.flag_Print " & _
       " FROM     dbo.Mainmune_security INNER JOIN " & _
       "                  dbo.Mune_Form ON dbo.Mainmune_security.MainFomNo = dbo.Mune_Form.FormCode " & _
       " WHERE  (dbo.Mainmune_security.Code_Emp = '" & Com_Code.Text & "') AND (dbo.Mainmune_security.MainFomNo = '" & varcodeform_scurity & "') "


        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.Rows(1).Cells(2).Value = False
            DataGridView2.Rows(1).Cells(3).Value = False
            DataGridView2.Rows(1).Cells(4).Value = False
            DataGridView2.Rows(1).Cells(5).Value = False
            DataGridView2.Rows(1).Cells(6).Value = False
            DataGridView2.Rows(1).Cells(7).Value = False
            'DataGridView2.RowCount = 1
            varcodeform2 = varcodeform_scurity
            FindGenralData()
        Else
            varcodeform2 = varcodeform_scurity
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = 1
                DataGridView2.Item(0, 0).Value = ""
                DataGridView2.Item(1, 0).Value = ""
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("FormNo").Value
                    DataGridView2.Item(1, i).Value = rs("Form_Name").Value

                    DataGridView2.Rows(i).Cells(2).Value = False
                    DataGridView2.Rows(i).Cells(3).Value = False
                    DataGridView2.Rows(i).Cells(4).Value = False
                    DataGridView2.Rows(i).Cells(5).Value = False
                    DataGridView2.Rows(i).Cells(6).Value = False
                    DataGridView2.Rows(i).Cells(7).Value = False



                    If rs("Stutas").Value = 1 Then DataGridView2.Rows(i).Cells(2).Value = True
                    If rs("Stutas").Value = 0 Then DataGridView2.Rows(i).Cells(2).Value = False

                    If rs("flag_save").Value = 1 Then DataGridView2.Rows(i).Cells(3).Value = True
                    If rs("flag_save").Value = 0 Then DataGridView2.Rows(i).Cells(3).Value = False

                    If rs("flag_Edit").Value = 1 Then DataGridView2.Rows(i).Cells(4).Value = True
                    If rs("flag_Edit").Value = 0 Then DataGridView2.Rows(i).Cells(4).Value = False

                    If rs("flag_Del").Value = 1 Then DataGridView2.Rows(i).Cells(5).Value = True
                    If rs("flag_Del").Value = 0 Then DataGridView2.Rows(i).Cells(5).Value = False

                    If rs("flag_Serch").Value = 1 Then DataGridView2.Rows(i).Cells(6).Value = True
                    If rs("flag_Serch").Value = 0 Then DataGridView2.Rows(i).Cells(6).Value = False

                    If rs("flag_Print").Value = 1 Then DataGridView2.Rows(i).Cells(7).Value = True
                    If rs("flag_Print").Value = 0 Then DataGridView2.Rows(i).Cells(7).Value = False






                    rs.MoveNext()


                Next i


                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click
        On Error Resume Next
        txt_Name.Text = ""
        txt_Password.Text = ""
        txt_UserName.Text = ""
        Fill_Dept()
        DataGridView2.RowCount = 1
        DataGridView2.Item(0, 0).Value = ""
        DataGridView2.Item(1, 0).Value = ""
        DataGridView2.Rows(0).Cells(2).Value = False
        'last_data()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        '========================================insertUserName
        Cnn.Execute("delete from Users_Department where Code_Emp='" & Com_Code.Text & "'  and Compny_Code ='" & VarCodeCompny & "' ")
        'find_user
        sql = "INSERT INTO Users_Department (Code_Emp,Se_Password,flg,User_Name,Code_Sub,Compny_Code) " & _
        " values  ('" & Com_Code.Text & "' , '" & txt_Password.Text & "','" & 0 & "','" & txt_Name.Text & "','" & 1 & "','" & VarCodeCompny & "' )"
        rs = Cnn.Execute(sql)




        Cnn.Execute("delete from Security where Code_Emp='" & Com_Code.Text & "' and Compny_Code ='" & VarCodeCompny & "' ")


        For x As Integer = 0 To DataGridView2.Rows.Count - 1
            Dim varflgadd, varadmin As Integer
            If DataGridView2.Rows(x).Cells(2).Value = True Then varflgadd = 1
            If RadioButton3.Checked = True Then varadmin = 1 Else varadmin = 0

            Dim xx As String
            xx = DataGridView2.Item(0, x).Value
            If xx = "" Then
            Else

                sql = "INSERT INTO Security (Code_Emp,codeform,Flag_Add,FlagAdminOrUser,Compny_Code) " & _
                " values  ('" & Com_Code.Text & "','" & DataGridView2.Item(0, x).Value & "' ,'" & varflgadd & "','" & varadmin & "','" & VarCodeCompny & "' )"
                rs = Cnn.Execute(sql)
            End If
        Next x

        savedata_mune()
        'Add_Data
        MsgBox("Ok Save", vbInformation, "Css") : Exit Sub
    End Sub

    Private Sub Com_dept_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_dept.SelectedIndexChanged
        txt_Name.Text = ""
        txt_UserName.Text = ""
        txt_Password.Text = ""
        Com_Code.Items.Clear()

        sql = " SELECT        dbo.BD_DIRCTORAY.Name, dbo.Emp_employees.Emp_Code " & _
        " FROM            dbo.BD_DIRCTORAY INNER JOIN " & _
        "                         dbo.Emp_employees ON dbo.BD_DIRCTORAY.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.BD_DIRCTORAY.Code = dbo.Emp_employees.Emp_Code_Dirctorat " & _
        " WHERE        (dbo.BD_DIRCTORAY.Compny_Code = '" & VarCodeCompny & "') AND (dbo.BD_DIRCTORAY.Name = '" & Com_dept.Text & "') "

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Code.Items.Add(rs("Emp_Code").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_Code_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Code.SelectedIndexChanged
        On Error Resume Next

        txt_Name.Text = ""
        txt_UserName.Text = ""
        txt_Password.Text = ""

        sql = "  SELECT        dbo.Vw_Emp.Emp_Name, dbo.Users_Department.Se_Password, dbo.Users_Department.User_Name, dbo.Users_Department.flg " & _
                " FROM            dbo.Vw_Emp LEFT OUTER JOIN " & _
                "                         dbo.Users_Department ON dbo.Vw_Emp.Compny_Code = dbo.Users_Department.Compny_Code AND dbo.Vw_Emp.Emp_Code = dbo.Users_Department.Code_Emp " & _
              " WHERE        (dbo.Vw_Emp.Emp_Code = '" & Com_Code.Text & "') AND (dbo.Vw_Emp.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_Emp.NameDir = '" & Com_dept.Text & "' ) "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Name.Text = rs("Emp_Name").Value
            txt_UserName.Text = rs("User_Name").Value
            txt_Password.Text = rs("Se_Password").Value
            If rs("flg").Value = 1 Then RadioButton3.Checked = True : RadioButton4.Checked = False
            If rs("flg").Value = 0 Then RadioButton3.Checked = False : RadioButton4.Checked = True
        Else

            txt_Name.Text = ""
            txt_UserName.Text = ""
            txt_Password.Text = ""
        End If
    End Sub
End Class