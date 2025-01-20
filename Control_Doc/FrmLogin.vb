Imports System.Data.OleDb
Public Class FrmLogin



    Private Sub cmd_Entry_Click(sender As Object, e As EventArgs) Handles cmd_Entry.Click
        open_password()
        If varcode_User <> 7 Then Mainmune.RibbonPage7.Visible = False Else Mainmune.RibbonPage7.Visible = True
        If varcode_User <> 7 Then Mainmune.RibbonPage12.Visible = False Else Mainmune.RibbonPage12.Visible = True
        'If varcode_User = 19 Then Mainmune.RibbonPage12.Visible = True Else Mainmune.RibbonPage12.Visible = False
        If varcode_User = 19 Then Mainmune.RibbonPage7.Visible = True : Mainmune.RibbonPage12.Visible = True
        If varcode_User = 20 Then Mainmune.BarButtonItem444.Enabled = True Else Mainmune.BarButtonItem444.Enabled = False
        'Warnty_Status()
        'Mainmune.Find_NewSalseorder()
    End Sub
    Sub Warnty_Status()
        sql = "select * from TB_SettingGroup1 "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then var_warnty = rs("FlgPrint_Warnty").Value
    End Sub

    Sub open_password()
        'On Error Resume Next

        If txt_Password.Text = "" And txt_UserCode.Text = "" Then
        Else
            sql = "SELECT dbo.Mainmune_security.MainFomNo, dbo.Mainmune_security.FormNo, dbo.Mainmune_security.Form_Name, dbo.Mainmune_security.Stutas, dbo.Mainmune_security.Code_Emp, dbo.Users_Department.Se_Password,  " & _
            "                  dbo.Vw_Emp.Emp_Name, dbo.Mainmune_security.flag_save, dbo.Mainmune_security.flag_Edit, dbo.Mainmune_security.flag_Del, dbo.Mainmune_security.flag_Serch, dbo.Mainmune_security.flag_Print, dbo.Vw_Emp.Em_BranchCode, dbo.Vw_Emp.BranchName " & _
            " FROM     dbo.Mainmune_security INNER JOIN " & _
            "                dbo.Users_Department ON dbo.Mainmune_security.Code_Emp = dbo.Users_Department.Code_Emp INNER JOIN " & _
            "                 dbo.Vw_Emp ON dbo.Mainmune_security.Code_Emp = dbo.Vw_Emp.Emp_Code LEFT OUTER JOIN " & _
            "                 dbo.Mune_Form ON dbo.Mainmune_security.MainFomNo = dbo.Mune_Form.FormCode " & _
            " WHERE  (dbo.Users_Department.Se_Password = '" & txt_Password.Text & "') AND (dbo.Mainmune_security.Code_Emp = '" & txt_UserCode.Text & "') "


            rs = Cnn.Execute(sql)
            Do While Not rs.EOF
                varCodeConnaction = 1
                varMainForm = rs("MainFomNo").Value
                Varscrren = rs("FormNo").Value
                var_flagsave = rs("flag_save").Value
                var_flagedit = rs("flag_Edit").Value
                var_flagdel = rs("flag_Del").Value
                var_flagserch = rs("flag_Serch").Value
                var_flagprint = rs("flag_Print").Value
                varCodeBranch = rs("Em_BranchCode").Value
                varNameBranch = rs("BranchName").Value

                '==================================================قائمة اعدادات

                If varMainForm = 1 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem7.Enabled = True
                If varMainForm = 1 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem199.Enabled = True
                If varMainForm = 1 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem9.Enabled = True
                If varMainForm = 1 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem146.Enabled = True
                If varMainForm = 1 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem147.Enabled = True
                If varMainForm = 1 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem38.Enabled = True
                If varMainForm = 1 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem71.Enabled = True
                If varMainForm = 1 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem10.Enabled = True
                If varMainForm = 1 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.Button_ChooesCompny.Enabled = True
                If varMainForm = 1 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem8.Enabled = True
                If varMainForm = 1 And Varscrren = 11 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem260.Enabled = True
                If varMainForm = 1 And Varscrren = 12 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem230.Enabled = True


                '================================================ قائمة البيانات الاساسية


                If varMainForm = 2 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem34.Enabled = True
                If varMainForm = 2 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem35.Enabled = True
                If varMainForm = 2 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem36.Enabled = True
                If varMainForm = 2 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem37.Enabled = True
                If varMainForm = 2 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem63.Enabled = True
                'If varMainForm = 2 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.Button_unit.Enabled = True
                'If varMainForm = 2 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem63.Enabled = True
                'If varMainForm = 2 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem41.Enabled = True
                'If varMainForm = 2 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem42.Enabled = True
                'If varMainForm = 2 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem43.Enabled = True
                'If varMainForm = 2 And Varscrren = 11 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem44.Enabled = True



                '=========================================== قائمة التأمين


                If varMainForm = 3 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem453.Enabled = True
                If varMainForm = 3 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem454.Enabled = True
                'If varMainForm = 3 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem332.Enabled = True
                'If varMainForm = 3 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem333.Enabled = True
                'If varMainForm = 3 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem264.Enabled = True

                '================================================= فائمة المدفوعات و المقبوضات


                If varMainForm = 4 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem61.Enabled = True
                If varMainForm = 4 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.Button_Exp.Enabled = True
                If varMainForm = 4 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem97.Enabled = True
                If varMainForm = 4 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem98.Enabled = True
                If varMainForm = 4 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem444.Enabled = True
                'If varMainForm = 4 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem52.Enabled = True
                'If varMainForm = 4 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem263.Enabled = True
                'If varMainForm = 4 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem45.Enabled = True
                'If varMainForm = 4 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem192.Enabled = True
                'If varMainForm = 4 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem327.Enabled = True
                '===================================================== قائمة شئون العاملين و المرتبات



                If varMainForm = 5 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem31.Enabled = True
                If varMainForm = 5 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem234.Enabled = True
                If varMainForm = 5 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem349.Enabled = True
                If varMainForm = 5 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem236.Enabled = True
                If varMainForm = 5 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem348.Enabled = True
                If varMainForm = 5 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem32.Enabled = True
                If varMainForm = 5 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem115.Enabled = True
                If varMainForm = 5 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem5.Enabled = True
                If varMainForm = 5 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem6.Enabled = True
                If varMainForm = 5 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem253.Enabled = True
                If varMainForm = 5 And Varscrren = 11 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem7.Enabled = True
                If varMainForm = 5 And Varscrren = 12 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem448.Enabled = True
                If varMainForm = 5 And Varscrren = 13 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem134.Enabled = True
                If varMainForm = 5 And Varscrren = 14 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem261.Enabled = True

                '========================================= قائمة اعتمادات مدير النظام


                If varMainForm = 6 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem33.Enabled = True
                'If varMainForm = 6 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.Button_Exp.Enabled = True
                'If varMainForm = 6 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem97.Enabled = True
                'If varMainForm = 6 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem98.Enabled = True

                '========================================================= قائمة الحسابات الختامية


                If varMainForm = 7 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem148.Enabled = True
                If varMainForm = 7 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem149.Enabled = True
                If varMainForm = 7 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem150.Enabled = True
                'If varMainForm = 7 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem387.Enabled = True
                'If varMainForm = 7 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem388.Enabled = True
                'If varMainForm = 7 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem389.Enabled = True
                'If varMainForm = 7 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem390.Enabled = True
                'If varMainForm = 7 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem391.Enabled = True
                'If varMainForm = 7 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem115.Enabled = True
                'If varMainForm = 7 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem115.Enabled = True
                'If varMainForm = 7 And Varscrren = 11 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem121.Enabled = True
                'If varMainForm = 7 And Varscrren = 12 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem122.Enabled = True

                ''If varMainForm = 7 And Varscrren = 13 And rs("Stutas").Value = 1 Then Mainmune.RibbonPage12.Visible = False
                'If varMainForm = 7 And Varscrren = 14 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem236.Enabled = True
                'If varMainForm = 7 And Varscrren = 15 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem125.Enabled = True
                'If varMainForm = 7 And Varscrren = 16 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem126.Enabled = True
                'If varMainForm = 7 And Varscrren = 17 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem253.Enabled = True
                'If varMainForm = 7 And Varscrren = 18 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem32.Enabled = True
                'If varMainForm = 7 And Varscrren = 19 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem234.Enabled = True
                'If varMainForm = 7 And Varscrren = 20 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem348.Enabled = True
                'If varMainForm = 7 And Varscrren = 21 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem133.Enabled = True
                'If varMainForm = 7 And Varscrren = 22 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem134.Enabled = True
                'If varMainForm = 7 And Varscrren = 23 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem261.Enabled = True


                '==================================================== قائمة التقارير


                If varMainForm = 8 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem412.Enabled = True
                If varMainForm = 8 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem39.Enabled = True
                If varMainForm = 8 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem44.Enabled = True
                'If varMainForm = 8 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.ا.Enabled = True
                'If varMainForm = 8 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem189.Enabled = True
                'If varMainForm = 8 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem190.Enabled = True

                '=================================================== قائمة الحسابات الختامية
                'If varMainForm = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem7.Enabled = True


                'If varMainForm = 9 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem148.Enabled = True
                'If varMainForm = 9 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem149.Enabled = True
                'If varMainForm = 9 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem150.Enabled = True




                '======================================================= صلاحيات المستخدمين


                If varMainForm = 9 And Varscrren = 1 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem183.Enabled = True
                If varMainForm = 9 And Varscrren = 2 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem338.Enabled = True
                'If varMainForm = 10 And Varscrren = 3 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem337.Enabled = True
                'If varMainForm = 10 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem12.Enabled = True
                'If varMainForm = 10 And Varscrren = 4 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem335.Enabled = True

                'If varMainForm = 10 And Varscrren = 5 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem10.Enabled = True
                'If varMainForm = 10 And Varscrren = 6 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem21.Enabled = True
                'If varMainForm = 10 And Varscrren = 7 And rs("Stutas").Value = 1 Then Mainmune.BarSubItem22.Enabled = True
                'If varMainForm = 10 And Varscrren = 8 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem87.Enabled = True
                'If varMainForm = 10 And Varscrren = 9 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem92.Enabled = True
                'If varMainForm = 10 And Varscrren = 10 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem9.Enabled = True
                'If varMainForm = 10 And Varscrren = 11 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem94.Enabled = True
                'If varMainForm = 10 And Varscrren = 12 And rs("Stutas").Value = 1 Then Mainmune.BarButtonItem95.Enabled = True
                '=======================================================




                rs.MoveNext()

            Loop



            '=================================
            'If VarCodeCompny = 3 Then Mainmune.RibbonPage12.Visible = False : Mainmune.RibbonPage11.Visible = True
            'If VarCodeCompny = 1 Or VarCodeCompny = 2 Then Mainmune.RibbonPage11.Visible = False : Mainmune.RibbonPage12.Visible = True



            sql = "SELECT dbo.Mainmune_security.MainFomNo, dbo.Mainmune_security.FormNo, dbo.Mainmune_security.Form_Name, dbo.Mainmune_security.Stutas, dbo.Mainmune_security.Code_Emp, dbo.Users_Department.Se_Password,  " & _
    "                  dbo.vw_Emp.Emp_Name " & _
    " FROM     dbo.Mainmune_security INNER JOIN " & _
    "                dbo.Users_Department ON dbo.Mainmune_security.Code_Emp = dbo.Users_Department.Code_Emp INNER JOIN " & _
    "                 dbo.vw_Emp ON dbo.Mainmune_security.Code_Emp = dbo.vw_Emp.Emp_Code LEFT OUTER JOIN " & _
    "                 dbo.Mune_Form ON dbo.Mainmune_security.MainFomNo = dbo.Mune_Form.FormCode " & _
    " WHERE  (dbo.Users_Department.Se_Password = '" & txt_Password.Text & "') AND (dbo.Mainmune_security.Code_Emp = '" & txt_UserCode.Text & "') "



            rs2 = Cnn.Execute(sql)


            If rs2.EOF = True Then

                MsgBox("Invalid User Namr Or Password, try again!", vbCritical, "Login") : Exit Sub
            Else
                varpassworduser = txt_Password.Text
                varcode_User = txt_UserCode.Text
                varnameuser = txt_UserName.Text
                Dim today = Date.Today
                Mainmune.ToolStripStatusLabel5.Text = "أسم المستخدم    " + ":  " + txt_UserName.Text
                'Frm_MainMune.ToolStripStatusLabel2.Text = "أسم الفرع   " + ":  " + txt_SubName.Text
                Mainmune.ToolStripStatusLabel6.Text = "التاريخ    " + ":  " + today
                'Frm_MainMune.Show()
                VarCodeCompny = txt_CodeCompny.Text
                VarNameCompny = txt_NameCompny.Text
                Mainmune.ToolStripStatusLabel1.Text = VarNameCompny
                'Mainmune.Find_NewSalseorder()
                'Mainmune.finwatinoderItem()
                'Mainmune.finwatinoderItem2()
                'Mainmune.Invoice_Count0()
                'Mainmune.Invoice_Count1()
                'Mainmune.Invoice_Count2()
                find_Compny()
                varcode_Branch = 1
                GetPCUserName()
                Me.Close()



            End If
        End If
    End Sub
    Sub GetPCUserName()
        '=========================== GetPCUserName
        Dim sql2 As String
        sql2 = "Select SERVERPROPERTY('MachineName') as 'MachineName'"
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("PC UserName Not Get")
        Else
            PcUserName = ds.Tables(0).Rows(0)(0).ToString
        End If
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '===========================
    End Sub
    Sub find_Compny()
        On Error Resume Next
        sql = "select * from St_CompnyInfo"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNotesCompny = rs("Notes").Value : varCommercialCompny = rs("Compny_CommercialRegister").Value : varTaxcardCompny = rs("Compny_Taxcard").Value : varAddressCompny = rs("Compny_Address").Value
    End Sub



    Private Sub cmd_Cancle_Click(sender As Object, e As EventArgs) Handles cmd_Cancle.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txt_UserCode.Text = "" Then MsgBox("من فضلك اختار الكود ", vbCritical, "Login") : Exit Sub


        sql = "SELECT     dbo.Users_Department.Code_Emp, dbo.Users_Department.User_Name, dbo.Users_Department.Se_Password, dbo.Security.CodeForm, dbo.Security.Flag_Add, " & _
        "                      dbo.Security.FlagAdminOrUser " & _
        " FROM         dbo.Users_Department INNER JOIN " & _
        "                      dbo.Security ON dbo.Users_Department.Code_Emp = dbo.Security.Code_Emp " & _
        " WHERE     (dbo.Users_Department.Code_Emp = '" & txt_UserCode.Text & "') AND (dbo.Users_Department.User_Name = '" & txt_UserName.Text & "') AND (dbo.Users_Department.Se_Password = '" & txt_Password.Text & "')"



        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Frm_ChangePassword.txt_Code.Text = txt_UserCode.Text
            Frm_ChangePassword.txt_Name.Text = txt_UserName.Text
            Frm_ChangePassword.txt_Password.Text = txt_Password.Text
            Frm_ChangePassword.txt_UserName.Text = txt_UserName.Text

            Frm_ChangePassword.MdiParent = Mainmune
            Frm_ChangePassword.Show()
            'Frm_ChangePassword.ShowDialog()

        Else

            MsgBox("Invalid User Namr Or Password, try again!", vbCritical, "Login")
            txt_Password.Select()
            'SendKeys "{Home}+{End}"

        End If
    End Sub

    Private Sub txt_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Password.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            open_password()
            If varcode_User <> 7 Then Mainmune.RibbonPage7.Visible = False Else Mainmune.RibbonPage7.Visible = True
            If varcode_User <> 7 Then Mainmune.RibbonPage12.Visible = False Else Mainmune.RibbonPage12.Visible = True
            If varcode_User <> 20 Then Mainmune.BarButtonItem444.Enabled = False Else Mainmune.BarButtonItem444.Enabled = True
            If varcode_User = 19 Then Mainmune.RibbonPage7.Visible = True : Mainmune.RibbonPage12.Visible = True

        End If
    End Sub

    Private Sub txt_Password_TextChanged(sender As Object, e As EventArgs) Handles txt_Password.TextChanged

    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connaction_Sql()
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        vartable = "Vw_CompnyLookup"
        VarOpenlookup = 6
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        VarCodeCompny = txt_CodeCompny.Text
        Frm_LookupUser.Show()
    End Sub
End Class