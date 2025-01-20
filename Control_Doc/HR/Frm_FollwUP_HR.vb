Imports ADODB

Public Class Frm_FollwUP_HR
    Dim Var_typeInvoice, vartextcolume4, vartextcolume5, vartextcolume6, vartextcolume7, vartextcolume8, vartextcolume9, vartextcolume14, vartextcolume15 As String
    Dim Var_NoOrder As Integer
    Private Sub Frm_FollwUP_HR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        com_month.Text = Format(Today.Date, "MM")
        com_year.Text = Format(Today.Date, "yyyy")
        com_month2.Text = Format(Today.Date, "MM")
        com_year2.Text = Format(Today.Date, "yyyy")
        com_Month3.Text = Format(Today.Date, "MM")
        com_year3.Text = Format(Today.Date, "yyyy")
        com_Month4.Text = Format(Today.Date, "MM")
        com_year4.Text = Format(Today.Date, "yyyy")
        com_Month5.Text = Format(Today.Date, "MM")
        com_year5.Text = Format(Today.Date, "yyyy")




        For i = 1 To 12
            com_month.Items.Add(i)
            com_month2.Items.Add(i)
            com_Month3.Items.Add(i)
            com_Month4.Items.Add(i)
            com_Month5.Items.Add(i)

        Next


        For P = 2020 To 2050

            com_year.Items.Add(P)
            com_year2.Items.Add(P)
            com_year3.Items.Add(P)
            com_year4.Items.Add(P)
            com_year5.Items.Add(P)

        Next

    End Sub
    Sub find_DiscountSalary() 'اعتماد الخصومات
        sql = " SELECT dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount, " & _
"                iif( dbo.TB_HR_DiscountSalary.Flag_Discount=0,'غير معتمد','معتمد') as status, dbo.TB_HR_DiscountSalary.Resone_Discount " & _
" FROM     dbo.TB_HR_DiscountSalary INNER JOIN " & _
"                  dbo.Emp_employees ON dbo.TB_HR_DiscountSalary.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
"                  dbo.BD_DiscountSalary ON dbo.TB_HR_DiscountSalary.Code_DiscountSalary = dbo.BD_DiscountSalary.Code " & _
" WHERE  (MONTH(dbo.TB_HR_DiscountSalary.Date_Entry) = '" & com_month.Text & "') AND (YEAR(dbo.TB_HR_DiscountSalary.Date_Entry) =  '" & com_year.Text & "') " & _
" GROUP BY dbo.TB_HR_DiscountSalary.No_Order, dbo.TB_HR_DiscountSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_DiscountSalary.Date_Entry, dbo.BD_DiscountSalary.Name, dbo.TB_HR_DiscountSalary.Value_Discount,  " & _
"        dbo.TB_HR_DiscountSalary.Flag_Discount, dbo.TB_HR_DiscountSalary.Resone_Discount "


        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""
            DataGridView2.Item(7, 0).Value = ""



        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1


                    DataGridView2.Item(0, i).Value = rs("No_Order").Value
                    DataGridView2.Item(1, i).Value = rs("Code_Emp").Value
                    DataGridView2.Item(2, i).Value = rs("Emp_Name").Value
                    DataGridView2.Item(3, i).Value = rs("Date_Entry").Value
                    DataGridView2.Item(4, i).Value = rs("Name").Value
                    DataGridView2.Item(5, i).Value = rs("Value_Discount").Value
                    DataGridView2.Item(6, i).Value = rs("Resone_Discount").Value
                    DataGridView2.Item(7, i).Value = rs("status").Value

                    If rs("status").Value = "معتمد" Then DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Green
                    If rs("status").Value = "غير معتمد" Then DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Yellow


                    rs.MoveNext()


                Next i
                button_List()
                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub

    Sub find_SalfSalary() 'اعتماد السلف
        sql = " SELECT dbo.TB_HR_SalfSalary.No_Order, dbo.TB_HR_SalfSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_SalfSalary.Date_Entry, dbo.TB_HR_SalfSalary.Value_Discount, " & _
  "                iif( dbo.TB_HR_SalfSalary.Flag_Discount=0,'غير معتمد','معتمد') as status, dbo.TB_HR_SalfSalary.Resone_Discount " & _
 " FROM     dbo.TB_HR_SalfSalary INNER JOIN " & _
 "                  dbo.Emp_employees ON dbo.TB_HR_SalfSalary.Code_Emp = dbo.Emp_employees.Emp_Code " & _
 "                " & _
 " GROUP BY dbo.TB_HR_SalfSalary.No_Order, dbo.TB_HR_SalfSalary.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.TB_HR_SalfSalary.Date_Entry, dbo.TB_HR_SalfSalary.Value_Discount,  " & _
 "        dbo.TB_HR_SalfSalary.Flag_Discount, dbo.TB_HR_SalfSalary.Resone_Discount "



        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX1.RowCount = 1
            DataGridViewX1.Item(0, 0).Value = ""
            DataGridViewX1.Item(1, 0).Value = ""
            DataGridViewX1.Item(2, 0).Value = ""
            DataGridViewX1.Item(3, 0).Value = ""
            DataGridViewX1.Item(4, 0).Value = ""
            DataGridViewX1.Item(5, 0).Value = ""
            DataGridViewX1.Item(6, 0).Value = ""



        Else
            DataGridViewX1.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX1.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX1.RowCount - 1


                    DataGridViewX1.Item(0, i).Value = rs("No_Order").Value
                    DataGridViewX1.Item(1, i).Value = rs("Code_Emp").Value
                    DataGridViewX1.Item(2, i).Value = rs("Emp_Name").Value
                    DataGridViewX1.Item(3, i).Value = rs("Date_Entry").Value
                    DataGridViewX1.Item(4, i).Value = rs("Value_Discount").Value
                    DataGridViewX1.Item(5, i).Value = rs("Resone_Discount").Value
                    DataGridViewX1.Item(6, i).Value = rs("status").Value

                    If rs("status").Value = "معتمد" Then DataGridViewX1.Rows(i).Cells(6).Style.BackColor = Color.Green
                    If rs("status").Value = "غير معتمد" Then DataGridViewX1.Rows(i).Cells(6).Style.BackColor = Color.Yellow


                    rs.MoveNext()


                Next i
                button_List2()
                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub
    Sub button_List() 'خصومات من الراتب



        Dim btn3 As New DataGridViewButtonColumn()

        If vartextcolume4 = "موافق" Then
        Else
            DataGridView2.Columns.Add(btn3)
            btn3.HeaderText = ""
            btn3.Text = "موافق"
            vartextcolume4 = "موافق"
            btn3.Name = "btn2"
            btn3.UseColumnTextForButtonValue = True

        End If

        Dim btn4 As New DataGridViewButtonColumn()
        If vartextcolume5 = "غير موافق" Then
        Else
            DataGridView2.Columns.Add(btn4)
            btn4.HeaderText = ""
            btn4.Text = "غير موافق"
            vartextcolume5 = "غير موافق"
            btn4.Name = "btn2"
            btn4.UseColumnTextForButtonValue = True
        End If



    End Sub

    Sub button_List2() 'سلف من الراتب



        Dim btn5 As New DataGridViewButtonColumn()

        If vartextcolume6 = "موافق" Then
        Else
            DataGridViewX1.Columns.Add(btn5)
            btn5.HeaderText = ""
            btn5.Text = "موافق"
            vartextcolume6 = "موافق"
            btn5.Name = "btn5"
            btn5.UseColumnTextForButtonValue = True

        End If

        Dim btn6 As New DataGridViewButtonColumn()
        If vartextcolume7 = "غير موافق" Then
        Else
            DataGridViewX1.Columns.Add(btn6)
            btn6.HeaderText = ""
            btn6.Text = "غير موافق"
            vartextcolume7 = "غير موافق"
            btn6.Name = "btn6"
            btn6.UseColumnTextForButtonValue = True
        End If



    End Sub

    Sub button_List3() 'الاجازة



        Dim btn8 As New DataGridViewButtonColumn()

        If vartextcolume8 = "موافق" Then
        Else
            DataGridViewX2.Columns.Add(btn8)
            btn8.HeaderText = ""
            btn8.Text = "موافق"
            vartextcolume8 = "موافق"
            btn8.Name = "btn8"
            btn8.UseColumnTextForButtonValue = True

        End If

        Dim btn9 As New DataGridViewButtonColumn()
        If vartextcolume9 = "غير موافق" Then
        Else
            DataGridViewX2.Columns.Add(btn9)
            btn9.HeaderText = ""
            btn9.Text = "غير موافق"
            vartextcolume9 = "غير موافق"
            btn9.Name = "btn9"
            btn9.UseColumnTextForButtonValue = True
        End If



    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        find_DiscountSalary()
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        On Error Resume Next
       
        If e.ColumnIndex = 8 Then

            Dim ro2, mt2 As Integer
            ro2 = DataGridView2.CurrentRow.Index
            mt2 = ro2
            Var_NoOrder = DataGridView2.Item(0, mt2).Value
                    '=======================================الموافقة على الاعتماد
                    sql2 = "UPDATE  TB_HR_DiscountSalary  SET Flag_Discount ='" & 1 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_DiscountSalary()
            MsgBox("موافق على اعتماد الخصم ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        End If

        If e.ColumnIndex = 9 Then

            Dim ro, mt As Integer
            ro = DataGridView2.CurrentRow.Index
            mt = ro
            Var_NoOrder = DataGridView2.Item(0, mt).Value

            sql2 = "UPDATE  TB_HR_DiscountSalary  SET Flag_Discount ='" & 0 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_DiscountSalary()
            MsgBox("غير موافق على اعتماد الخصم ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End If
    End Sub

   
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        find_SalfSalary()
    End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        On Error Resume Next
       
        If e.ColumnIndex = 7 Then

            Dim ro2, mt2 As Integer
            ro2 = DataGridViewX1.CurrentRow.Index
            mt2 = ro2
            Var_NoOrder = DataGridViewX1.Item(0, mt2).Value
            '=======================================الموافقة على الاعتماد
            sql2 = "UPDATE  TB_HR_SalfSalary  SET Flag_Discount ='" & 1 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_SalfSalary()

            MsgBox("موافق على اعتماد السلفة ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        End If

        If e.ColumnIndex = 8 Then

            Dim ro, mt As Integer
            ro = DataGridViewX1.CurrentRow.Index
            mt = ro
            Var_NoOrder = DataGridViewX1.Item(0, mt).Value

            sql2 = "UPDATE  TB_HR_SalfSalary  SET Flag_Discount ='" & 0 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_SalfSalary()
            MsgBox("غير موافق على اعتماد السلفة ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End If
    End Sub

    Private Sub DataGridViewX1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        varApproved = 1
        Report_Approved.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        varApproved = 2
        Report_Approved.Show()
    End Sub

    
    Private Sub cmd_find3_Click(sender As Object, e As EventArgs) Handles cmd_find3.Click
    
        Find_Vaction()

    End Sub
    Sub Find_Vaction()
        sql = "   SELECT dbo.TB_HR_VactionData.No_Order, dbo.TB_HR_VactionData.Date_Entry, dbo.TB_HR_VactionData.Code_Emp, dbo.Emp_employees.Emp_Name, dbo.BD_VactionLookup.Name, dbo.TB_HR_VactionData.FromDate,  " & _
"                  dbo.TB_HR_VactionData.EndDate, dbo.TB_HR_VactionData.Resone_Vaction, dbo.BD_DIRCTORAY.Name AS Dir, dbo.BD_DEPARTMENTS.Name AS Deprt, dbo.BD_JOBNAMES.Name AS jopname, iif(dbo.TB_HR_VactionData.Flag_Vaction=1,'معتمد','غير معتمد') as Status " & _
" FROM     dbo.TB_HR_VactionData INNER JOIN " & _
"                  dbo.Emp_employees ON dbo.TB_HR_VactionData.Code_Emp = dbo.Emp_employees.Emp_Code INNER JOIN " & _
"                  dbo.BD_VactionLookup ON dbo.TB_HR_VactionData.Code_vaction = dbo.BD_VactionLookup.Code INNER JOIN " & _
"                  dbo.BD_DIRCTORAY ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
"                  dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code INNER JOIN " & _
"                  dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code " & _
"       where Month(dbo.TB_HR_VactionData.Date_Entry) = '" & com_Month3.Text & "' And Year(dbo.TB_HR_VactionData.Date_Entry) = '" & com_year3.Text & "' "


        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX2.RowCount = 1
            DataGridViewX2.Item(0, 0).Value = ""
            DataGridViewX2.Item(1, 0).Value = ""
            DataGridViewX2.Item(2, 0).Value = ""
            DataGridViewX2.Item(3, 0).Value = ""
            DataGridViewX2.Item(4, 0).Value = ""
            DataGridViewX2.Item(5, 0).Value = ""
            DataGridViewX2.Item(6, 0).Value = ""



        Else
            DataGridViewX2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX2.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX2.RowCount - 1


                    DataGridViewX2.Item(0, i).Value = rs("No_Order").Value
                    DataGridViewX2.Item(1, i).Value = rs("Code_Emp").Value
                    DataGridViewX2.Item(2, i).Value = rs("Emp_Name").Value
                    DataGridViewX2.Item(3, i).Value = rs("jopname").Value
                    DataGridViewX2.Item(4, i).Value = rs("Deprt").Value
                    DataGridViewX2.Item(5, i).Value = rs("Name").Value
                    DataGridViewX2.Item(6, i).Value = rs("FromDate").Value
                    DataGridViewX2.Item(7, i).Value = rs("EndDate").Value
                    DataGridViewX2.Item(8, i).Value = DateDiff(DateInterval.Day, rs("FromDate").Value, rs("EndDate").Value) + 1
                    DataGridViewX2.Item(9, i).Value = rs("Resone_Vaction").Value
                    DataGridViewX2.Item(10, i).Value = rs("status").Value


                    If rs("status").Value = "معتمد" Then DataGridViewX2.Rows(i).Cells(10).Style.BackColor = Color.Green
                    If rs("status").Value = "غير معتمد" Then DataGridViewX2.Rows(i).Cells(10).Style.BackColor = Color.Yellow


                    rs.MoveNext()


                Next i
                button_List3()
                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub
    Private Sub DataGridViewX2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX2.CellClick
        On Error Resume Next
        
        If e.ColumnIndex = 11 Then
            Dim ro2, mt2 As Integer
            ro2 = DataGridViewX2.CurrentRow.Index
            mt2 = ro2
            Var_NoOrder = DataGridViewX2.Item(0, mt2).Value
            '=======================================الموافقة على الاعتماد
            sql2 = "UPDATE  TB_HR_VactionData  SET Flag_Vaction ='" & 1 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_SalfSalary()

            MsgBox("موافق على اعتماد الاجازة ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        End If

        If e.ColumnIndex = 12 Then

            Dim ro3, mt3 As Integer
            ro3 = DataGridViewX2.CurrentRow.Index
            mt3 = ro3
            Var_NoOrder = DataGridViewX2.Item(0, mt3).Value

            sql2 = "UPDATE  TB_HR_VactionData  SET Flag_Vaction ='" & 0 & "'   WHERE  No_Order ='" & Var_NoOrder & "'  "
            rs = Cnn.Execute(sql2)
            find_SalfSalary()
            MsgBox("غير موافق على اعتماد الاجازة ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End If
        Find_Vaction()
    End Sub


    
    Private Sub DataGridViewX2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        varApproved = 3
        Report_Approved.Show()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Fill_Find_Badel()

    End Sub
    Sub button_List4() 'البدل



        Dim btn10 As New DataGridViewButtonColumn()

        If vartextcolume8 = "موافق" Then
        Else
            DataGridViewX3.Columns.Add(btn10)
            btn10.HeaderText = "موافق"
            btn10.Text = "موافق"
            vartextcolume8 = "موافق"
            btn10.Name = "btn8"
            btn10.UseColumnTextForButtonValue = True

        End If

        Dim btn11 As New DataGridViewButtonColumn()
        If vartextcolume9 = "غير موافق" Then
        Else
            DataGridViewX3.Columns.Add(btn11)
            btn11.HeaderText = "غير موافق"
            btn11.Text = "غير موافق"
            vartextcolume9 = "غير موافق"
            btn11.Name = "btn9"
            btn11.UseColumnTextForButtonValue = True
        End If



    End Sub

    Sub button_List5() 'الاستقطاعات 



        Dim btn14 As New DataGridViewButtonColumn()

        If vartextcolume14 = "موافق" Then
        Else
            DataGridViewX4.Columns.Add(btn14)
            btn14.HeaderText = "موافق"
            btn14.Text = "موافق"
            vartextcolume14 = "موافق"
            btn14.Name = "btn14"
            btn14.UseColumnTextForButtonValue = True

        End If

        Dim btn15 As New DataGridViewButtonColumn()
        If vartextcolume15 = "غير موافق" Then
        Else
            DataGridViewX4.Columns.Add(btn15)
            btn15.HeaderText = "غير موافق"
            btn15.Text = "غير موافق"
            vartextcolume15 = "غير موافق"
            btn15.Name = "btn15"
            btn15.UseColumnTextForButtonValue = True
        End If



    End Sub

    Sub Fill_Find_Badel()

        On Error Resume Next

        sql = "  SELECT        dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Motagher.Motgher, dbo.TB_Motagher.Edafy, dbo.TB_Motagher.BdelSfr, dbo.TB_Motagher.Bdelbnzen, dbo.TB_Motagher.Aghor,  " & _
  "                         dbo.TB_Motagher.TotalBdel, dbo.TB_Motagher.Notes, dbo.TB_Motagher.emp_year, dbo.TB_Motagher.Emp_Month, dbo.TB_Motagher.BdelAnkal, dbo.TB_Motagher.BounseProduction,iif(Flag_Bdel=0,'غير معتمد','معتمد') as status " & _
  " FROM            dbo.TB_Motagher LEFT OUTER JOIN " & _
  "                         dbo.Emp_employees ON dbo.TB_Motagher.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Motagher.Emp_Code = dbo.Emp_employees.Emp_Code WHERE   dbo.TB_Motagher.emp_year ='" & com_year4.Text & "' and dbo.TB_Motagher.Emp_Month ='" & com_Month4.Text & "' and      (dbo.TB_Motagher.Compny_Code = '" & VarCodeCompny & "') and TotalBdel > 0 "



        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX3.RowCount = 1
            DataGridViewX3.Item(0, 0).Value = ""
            DataGridViewX3.Item(1, 0).Value = ""
            DataGridViewX3.Item(2, 0).Value = ""
            DataGridViewX3.Item(3, 0).Value = ""
            DataGridViewX3.Item(4, 0).Value = ""
            DataGridViewX3.Item(5, 0).Value = ""
            DataGridViewX3.Item(6, 0).Value = ""
            DataGridViewX3.Item(7, 0).Value = ""
            DataGridViewX3.Item(8, 0).Value = ""
            DataGridViewX3.Item(9, 0).Value = ""
            DataGridViewX3.Item(10, 0).Value = ""

            MsgBox("لا يوجد بدلات شهرية مسجلة", MsgBoxStyle.Critical, "Css") : Exit Sub

            'find_alldata()
        Else
            DataGridViewX3.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX3.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX3.RowCount - 1


                    DataGridViewX3.Item(0, i).Value = rs("Emp_Code").Value
                    DataGridViewX3.Item(1, i).Value = rs("Emp_Name").Value



                    'DataGridView2.Item(2, i).Value = rs("Motgher").Value
                    DataGridViewX3.Item(3, i).Value = rs("Edafy").Value
                    'DataGridViewX3.Item(4, i).Value = rs("BdelSfr").Value
                    DataGridViewX3.Item(5, i).Value = rs("BdelSfr").Value
                    DataGridViewX3.Item(6, i).Value = rs("Aghor").Value
                    DataGridViewX3.Item(9, i).Value = rs("TotalBdel").Value
                    'DataGridView2.Item(8, i).Value = rs("Notes").Value
                    DataGridViewX3.Item(7, i).Value = rs("BounseProduction").Value
                    DataGridViewX3.Item(8, i).Value = rs("BdelAnkal").Value
                    DataGridViewX3.Item(11, i).Value = rs("status").Value

                    If rs("status").Value = "معتمد" Then DataGridViewX3.Rows(i).Cells(11).Style.BackColor = Color.Green
                    If rs("status").Value = "غير معتمد" Then DataGridViewX3.Rows(i).Cells(11).Style.BackColor = Color.Yellow



                    rs.MoveNext()


                Next i
                button_List4()
                'Total_Sum2()
                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub


    Sub find_alldata()

        'On Error Resume Next


        'sql = "   SELECT        Emp_Code, Emp_Name    FROM dbo.Emp_employees    WHERE(Compny_Code = '" & VarCodeCompny & "')"

        '      sql = "  SELECT        dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Motagher.Motgher, dbo.TB_Motagher.Edafy, dbo.TB_Motagher.BdelSfr, dbo.TB_Motagher.Bdelbnzen, dbo.TB_Motagher.Aghor,  " & _
        '"                         dbo.TB_Motagher.TotalBdel, dbo.TB_Motagher.Notes, dbo.TB_Motagher.emp_year, dbo.TB_Motagher.Emp_Month " & _
        '" FROM            dbo.TB_Motagher LEFT OUTER JOIN " & _
        '"                         dbo.Emp_employees ON dbo.TB_Motagher.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Motagher.Emp_Code = dbo.Emp_employees.Emp_Code WHERE        (dbo.TB_Motagher.Compny_Code = '" & VarCodeCompny & "') "

        sql = " select * from Emp_employees  where  dbo.Emp_employees.Compny_Code = '" & VarCodeCompny & "' "





        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX3.RowCount = 1
            DataGridViewX3.Item(0, 0).Value = ""
            DataGridViewX3.Item(1, 0).Value = ""
            DataGridViewX3.Item(2, 0).Value = "0"
            DataGridViewX3.Item(3, 0).Value = "0"
            DataGridViewX3.Item(4, 0).Value = "0"
            DataGridViewX3.Item(5, 0).Value = "0"
            DataGridViewX3.Item(6, 0).Value = "0"
            DataGridViewX3.Item(7, 0).Value = "0"
            DataGridViewX3.Item(8, 0).Value = "0"
            DataGridViewX3.Item(9, 0).Value = "0"


        Else
            DataGridViewX3.Item(2, 0).Value = "0"
            DataGridViewX3.Item(3, 0).Value = "0"
            DataGridViewX3.Item(4, 0).Value = "0"
            DataGridViewX3.Item(5, 0).Value = "0"
            DataGridViewX3.Item(6, 0).Value = "0"
            DataGridViewX3.Item(7, 0).Value = "0"
            DataGridViewX3.Item(8, 0).Value = "0"
            DataGridViewX3.Item(9, 0).Value = "0"
            DataGridViewX3.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX3.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX3.RowCount - 1

                    DataGridViewX3.Item(0, i).Value = rs("Emp_Code").Value
                    DataGridViewX3.Item(1, i).Value = rs("Emp_Name").Value


                    '==============================اضافى الساعات
                    sql2 = "   SELECT dbo.vw_TotalHoure.Emp_code, dbo.vw_TotalHoure.Emp_att_Month, dbo.vw_TotalHoure.Emp_att_year, dbo.vw_TotalHoure.TotalAdd_M, dbo.Seting_TimeValue.ValueTime, dbo.vw_TotalHoure.TotalHoure, " & _
                    "             ROUND(dbo.Seting_TimeValue.ValueTime * dbo.vw_TotalHoure.TotalHoure, 2) AS Total_T " & _
                   " FROM     dbo.vw_TotalHoure INNER JOIN " & _
                   "                  dbo.Seting_TimeValue ON dbo.vw_TotalHoure.Emp_code = dbo.Seting_TimeValue.emp_code " & _
                   " GROUP BY dbo.Seting_TimeValue.ValueTime, dbo.vw_TotalHoure.Emp_code, dbo.vw_TotalHoure.Emp_att_Month, dbo.vw_TotalHoure.Emp_att_year, dbo.vw_TotalHoure.TotalAdd_M, dbo.vw_TotalHoure.TotalHoure " & _
                   " HAVING (dbo.vw_TotalHoure.Emp_att_Month = '" & com_Month4.Text & "') AND (dbo.vw_TotalHoure.Emp_att_year = '" & com_year4.Text & "') AND (dbo.vw_TotalHoure.Emp_code = '" & rs("Emp_Code").Value & "') "
                    rs2 = Cnn.Execute(sql2)
                    If rs2.EOF = False Then DataGridViewX3.Item(3, i).Value = rs2("Total_T").Value Else DataGridViewX3.Item(3, i).Value = 0
                    '======================================================


                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub

    Private Sub DataGridViewX3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX3.CellClick
        If e.ColumnIndex = 12 Then
            Dim ro2, mt2 As Integer
            ro2 = DataGridViewX3.CurrentRow.Index
            mt2 = ro2
            Var_EmpCode = DataGridViewX3.Item(0, mt2).Value
            '=======================================الموافقة على الاعتماد
            sql2 = "UPDATE  TB_Motagher  SET Flag_Bdel ='" & 1 & "'   WHERE  Emp_Code ='" & Var_EmpCode & "' and Emp_Month ='" & com_Month4.Text & "' and emp_year ='" & com_year4.Text & "'  "
            rs = Cnn.Execute(sql2)

            MsgBox("موافق على اعتماد البدل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        End If

        If e.ColumnIndex = 13 Then

            Dim ro3, mt3 As Integer
            ro3 = DataGridViewX3.CurrentRow.Index
            mt3 = ro3
            Var_EmpCode = DataGridViewX3.Item(0, mt3).Value
            sql2 = "UPDATE  TB_Motagher  SET Flag_Bdel ='" & 0 & "'   WHERE  Emp_Code ='" & Var_EmpCode & "' and Emp_Month ='" & com_Month4.Text & "' and emp_year ='" & com_year4.Text & "'  "
            rs = Cnn.Execute(sql2)
            MsgBox("غير موافق على اعتماد البدل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End If
        Fill_Find_Badel()
    End Sub

    Private Sub DataGridViewX3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX3.CellContentClick

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        varApproved = 4
        Report_Approved.Show()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        find_Estkt()
    End Sub
    Sub find_Estkt()

        'On Error Resume Next


        sql = "   SELECT dbo.TB_Eskta.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Eskta.tswahd, dbo.TB_Eskta.slaf, dbo.TB_Eskta.Taekhrat, dbo.TB_Eskta.Ghuab, dbo.TB_Eskta.Ghzat, dbo.TB_Eskta.TotalEstkta, dbo.TB_Eskta.Notes,dbo.TB_Eskta.Flag_Est " & _
   " FROM     dbo.TB_Eskta INNER JOIN " & _
   "                  dbo.Emp_employees ON dbo.TB_Eskta.Emp_Code = dbo.Emp_employees.Emp_Code " & _
   " WHERE  (dbo.TB_Eskta.Emp_Month = '" & com_Month5.Text & "') AND (dbo.TB_Eskta.emp_year = '" & com_year5.Text & "') "

        rs2 = New ADODB.Recordset
        rs2.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs2.RecordCount = 0 Then
            DataGridViewX4.RowCount = 1
            DataGridViewX4.Item(0, 0).Value = ""
            DataGridViewX4.Item(1, 0).Value = ""
            DataGridViewX4.Item(2, 0).Value = ""
            DataGridViewX4.Item(3, 0).Value = ""
            DataGridViewX4.Item(4, 0).Value = ""
            DataGridViewX4.Item(5, 0).Value = ""
            DataGridViewX4.Item(6, 0).Value = ""
            DataGridViewX4.Item(7, 0).Value = ""
            'DataGridView2.Item(8, 0).Value = ""
            MsgBox("لا يوجد استقطاعات شهرية مسجلة", MsgBoxStyle.Critical, "Css") : Exit Sub
            'find_alldata()
        Else

            'txt_Status.Text = "تم المراجعة" : txt_Status.BackColor = Color.Gray
            DataGridViewX4.RowCount = 1
            rs2.MoveLast() : rs2.MoveFirst()

            Dim T
            For T = 0 To rs2.RecordCount - 1
                DataGridViewX4.RowCount = rs2.RecordCount

                For i = 0 To DataGridViewX4.RowCount - 1


                    DataGridViewX4.Item(0, i).Value = rs2("Emp_Code").Value
                    DataGridViewX4.Item(1, i).Value = rs2("Emp_Name").Value
                    DataGridViewX4.Item(2, i).Value = rs2("tswahd").Value
                    DataGridViewX4.Item(3, i).Value = rs2("slaf").Value
                    DataGridViewX4.Item(4, i).Value = rs2("Taekhrat").Value
                    DataGridViewX4.Item(5, i).Value = rs2("Ghuab").Value
                    DataGridViewX4.Item(6, i).Value = rs2("Ghzat").Value
                    DataGridViewX4.Item(7, i).Value = rs2("TotalEstkta").Value
                    'DataGridView2.Item(8, i).Value = rs2("Notes").Value

                    If rs2("Flag_Est").Value = 1 Then DataGridViewX4.Item(8, i).Value = "معتمد" : DataGridViewX4.Rows(i).Cells(8).Style.BackColor = Color.Green
                    If rs2("Flag_Est").Value = 0 Then DataGridViewX4.Item(8, i).Value = "غير معتمد" : DataGridViewX4.Rows(i).Cells(8).Style.BackColor = Color.Yellow


                    rs2.MoveNext()


                Next i
                button_List5()
                'sum_estk()
                Exit Sub
            Next T
            rs2.Close()
        End If


    End Sub

    Private Sub DataGridViewX4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX4.CellClick
        If e.ColumnIndex = 9 Then
            Dim ro2, mt2 As Integer
            ro2 = DataGridViewX4.CurrentRow.Index
            mt2 = ro2
            Var_EmpCode = DataGridViewX4.Item(0, mt2).Value
            '=======================================الموافقة على الاعتماد
            sql2 = "UPDATE  TB_Eskta  SET Flag_Est ='" & 1 & "'   WHERE  Emp_Code ='" & Var_EmpCode & "' and Emp_Month ='" & com_Month5.Text & "' and emp_year ='" & com_year5.Text & "'  "
            rs = Cnn.Execute(sql2)

            MsgBox("موافق على اعتماد الاستقطاعات ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        End If

        If e.ColumnIndex = 10 Then

            Dim ro3, mt3 As Integer
            ro3 = DataGridViewX4.CurrentRow.Index
            mt3 = ro3
            Var_EmpCode = DataGridViewX4.Item(0, mt3).Value
            sql2 = "UPDATE  TB_Eskta  SET Flag_Est ='" & 0 & "'   WHERE  Emp_Code ='" & Var_EmpCode & "' and Emp_Month ='" & com_Month5.Text & "' and emp_year ='" & com_year5.Text & "'  "
            rs = Cnn.Execute(sql2)
            MsgBox("غير موافق على اعتماد الاستقطاعات ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End If

        find_Estkt()
    End Sub

    Private Sub DataGridViewX4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX4.CellContentClick

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click

    End Sub
End Class