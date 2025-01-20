Imports ADODB

Public Class Frm_Bdalat_Emp

    Dim var_valueday As Single


    Sub Fill_Find()

        On Error Resume Next

        sql = "  SELECT dbo.TB_Motagher.BdelbSfr, dbo.TB_Motagher.Bdel_Agzua, dbo.TB_Motagher.Bdel_Wagba, dbo.TB_Motagher.TotalBdel,dbo.TB_Motagher.Value_Overtime,dbo.TB_Motagher.BdelWagba_OverTime,dbo.TB_Motagher.BdelAnkal_OverTime,dbo.TB_Motagher.BdelAnkal_Fexied,dbo.TB_Motagher.BdelAnkal_Motgher,   dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Motagher.Motgher, dbo.TB_Motagher.Edafy, dbo.TB_Motagher.Aghor,  " & _
  "                         dbo.TB_Motagher.TotalBdel, dbo.TB_Motagher.Notes, dbo.TB_Motagher.emp_year, dbo.TB_Motagher.Emp_Month, dbo.TB_Motagher.BdelAnkal, dbo.TB_Motagher.BounseProduction " & _
  " FROM            dbo.TB_Motagher LEFT OUTER JOIN " & _
  "                         dbo.Emp_employees ON dbo.TB_Motagher.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Motagher.Emp_Code = dbo.Emp_employees.Emp_Code WHERE   dbo.TB_Motagher.emp_year ='" & com_year.Text & "' and dbo.TB_Motagher.Emp_Month ='" & com_month.Text & "' and      (dbo.TB_Motagher.Compny_Code = '" & VarCodeCompny & "') "



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
            DataGridView2.Item(8, 0).Value = ""
            DataGridView2.Item(9, 0).Value = ""

            find_alldata()
        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                   

                    DataGridView2.Item(0, i).Value = rs("Emp_Code").Value
                    DataGridView2.Item(1, i).Value = rs("Emp_Name").Value
                    DataGridView2.Item(2, i).Value = rs("Edafy").Value
                    DataGridView2.Item(3, i).Value = rs("Bdel_Agzua").Value
                    DataGridView2.Item(4, i).Value = rs("Bdel_Wagba").Value
                    DataGridView2.Item(5, i).Value = rs("BdelbSfr").Value
                    DataGridView2.Item(6, i).Value = rs("BdelAnkal").Value
                    DataGridView2.Item(7, i).Value = rs("Value_Overtime").Value
                    DataGridView2.Item(8, i).Value = rs("BdelWagba_OverTime").Value
                    DataGridView2.Item(9, i).Value = rs("BdelAnkal_OverTime").Value
                    DataGridView2.Item(10, i).Value = rs("BdelAnkal_Fexied").Value
                    DataGridView2.Item(11, i).Value = rs("BdelAnkal_Motgher").Value
                    DataGridView2.Item(12, i).Value = rs("BounseProduction").Value
                    DataGridView2.Item(13, i).Value = rs("TotalBdel").Value




                    rs.MoveNext()


                Next i
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
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = "0"
            DataGridView2.Item(3, 0).Value = "0"
            DataGridView2.Item(4, 0).Value = "0"
            DataGridView2.Item(5, 0).Value = "0"
            DataGridView2.Item(6, 0).Value = "0"
            DataGridView2.Item(7, 0).Value = "0"
            DataGridView2.Item(8, 0).Value = "0"
            DataGridView2.Item(9, 0).Value = "0"


        Else
            DataGridView2.Item(2, 0).Value = "0"
            DataGridView2.Item(3, 0).Value = "0"
            DataGridView2.Item(4, 0).Value = "0"
            DataGridView2.Item(5, 0).Value = "0"
            DataGridView2.Item(6, 0).Value = "0"
            DataGridView2.Item(7, 0).Value = "0"
            DataGridView2.Item(8, 0).Value = "0"
            DataGridView2.Item(9, 0).Value = "0"
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1

                    DataGridView2.Item(0, i).Value = rs("Emp_Code").Value
                    DataGridView2.Item(1, i).Value = rs("Emp_Name").Value

                    '================================================قيمة الساعة


                    sql2 = "  SELECT Emp_Code, basicsalary / 30 / 8 AS value_day             FROM dbo.Emp_employees  WHERE(Emp_Code = '" & rs("Emp_Code").Value & "')"
                    rs2 = Cnn.Execute(sql2)
                    If rs2.EOF = False Then var_valueday = rs2("value_day").Value Else var_valueday = 0




                    '==============================اضافى الساعات
                    sql2 = "   SELECT dbo.vw_TotalHoure.Emp_code, dbo.vw_TotalHoure.Emp_att_Month, dbo.vw_TotalHoure.Emp_att_year, dbo.vw_TotalHoure.TotalAdd_M, dbo.Seting_TimeValue.ValueTime, dbo.vw_TotalHoure.TotalHoure, " & _
                    "             ROUND( dbo.vw_TotalHoure.TotalHoure, 2) AS Total_T " & _
                   " FROM     dbo.vw_TotalHoure INNER JOIN " & _
                   "                  dbo.Seting_TimeValue ON dbo.vw_TotalHoure.Emp_code = dbo.Seting_TimeValue.emp_code " & _
                   " GROUP BY dbo.Seting_TimeValue.ValueTime, dbo.vw_TotalHoure.Emp_code, dbo.vw_TotalHoure.Emp_att_Month, dbo.vw_TotalHoure.Emp_att_year, dbo.vw_TotalHoure.TotalAdd_M, dbo.vw_TotalHoure.TotalHoure " & _
                   " HAVING (dbo.vw_TotalHoure.Emp_att_Month = '" & com_month.Text & "') AND (dbo.vw_TotalHoure.Emp_att_year = '" & com_year.Text & "') AND (dbo.vw_TotalHoure.Emp_code = '" & rs("Emp_Code").Value & "') "
                    rs2 = Cnn.Execute(sql2)
                    If rs2.EOF = False Then DataGridView2.Item(2, i).Value = rs2("Total_T").Value * var_valueday Else DataGridView2.Item(2, i).Value = 0
                    '======================================================


                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Fill_Find()
    End Sub

    Private Sub cmd_save_Click_1(sender As Object, e As EventArgs) Handles cmd_save.Click
        On Error Resume Next
        sql = "Delete TB_Motagher  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "'  "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1


            sql = "INSERT INTO TB_Motagher (Emp_Code,Edafy,Bdel_Agzua,Bdel_Wagba,emp_year,Emp_Month,Compny_Code,BdelbSfr,BdelAnkal,Value_Overtime,BdelWagba_OverTime,BdelAnkal_OverTime,BdelAnkal_Fexied,BdelAnkal_Motgher,BounseProduction,TotalBdel) " & _
                    " values  (" & DataGridView2.Item(0, x).Value & " ,N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(3, x).Value & "',N'" & DataGridView2.Item(4, x).Value & "','" & com_year.Text & "','" & com_month.Text & "' ,'" & VarCodeCompny & "',N'" & DataGridView2.Item(5, x).Value & "' ,N'" & DataGridView2.Item(6, x).Value & "' ,N'" & DataGridView2.Item(7, x).Value & "' ,N'" & DataGridView2.Item(8, x).Value & "',N'" & DataGridView2.Item(9, x).Value & "',N'" & DataGridView2.Item(10, x).Value & "',N'" & DataGridView2.Item(11, x).Value & "',N'" & DataGridView2.Item(12, x).Value & "',N'" & DataGridView2.Item(13, x).Value & "')"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


    End Sub

    Private Sub Frm_Bdalat_Emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 12
            com_month.Items.Add(i)
        Next i
        '================================================================
        For y = 2019 To 2030
            com_year.Items.Add(y)
        Next y

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
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        Fill_Find()
        Total_Sum()
    End Sub
    Sub Total_Sum()

        Dim total As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        Dim total5 As String = 0
        Dim total6 As String = 0
        Dim total7 As String = 0
        Dim total8 As String = 0
        Dim total9 As String = 0
        Dim total10 As String = 0
        Dim total11 As String = 0
        Dim total12 As String = 0


        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += DataGridView2.Rows(i).Cells(2).Value
            total2 += DataGridView2.Rows(i).Cells(3).Value
            total3 += DataGridView2.Rows(i).Cells(4).Value
            total4 += DataGridView2.Rows(i).Cells(5).Value
            total5 += DataGridView2.Rows(i).Cells(6).Value
            total6 += DataGridView2.Rows(i).Cells(7).Value
            total7 += DataGridView2.Rows(i).Cells(8).Value
            total8 += DataGridView2.Rows(i).Cells(9).Value
            total9 += DataGridView2.Rows(i).Cells(10).Value
            total10 += DataGridView2.Rows(i).Cells(11).Value
            total11 += DataGridView2.Rows(i).Cells(12).Value
            total12 += DataGridView2.Rows(i).Cells(13).Value


        Next
        txt_TotalEdafy.Text = total
        txt_Bdelagza.Text = total2
        txt_Totalwagba.Text = total3
        txt_safr.Text = total4
        txt_TotalAntkal.Text = total5
        txt_ValueOvertime.Text = total6

        txt_WagbaOvertime.Text = total7
        txt_AntkalOvertime.Text = total8
        txt_tnkFeixed.Text = total9
        txt_tnklMotgher.Text = total10
        txt_produaction.Text = total11
        txt_TotalBdel.Text = total12

    End Sub
    Sub Total_Sum2()


        '     sql = "   SELECT Emp_Month, emp_year, SUM(Edafy) AS TotalEdafy, SUM(BdelSfr) AS TotalBdel, SUM(Aghor) AS TotalAghor, SUM(TotalBdel) AS TotalBdelAll, SUM(BounseProduction) AS TotalBounseProduction, SUM(BdelAnkal) AS TotalBdelAnkal " & _
        '" FROM     dbo.TB_Motagher " & _
        '" GROUP BY Emp_Month, emp_year " & _
        '" HAVING (Emp_Month = '" & com_month.Text & "') AND (emp_year = '" & com_year.Text & "') "
        '     rs = Cnn.Execute(sql)
        '     If rs.EOF = False Then
        '         txt_TotalEdafy.Text = rs("TotalEdafy").Value
        '         txt_BdelSfr.Text = rs("TotalBdel").Value
        '         txt_TotalAgor.Text = rs("TotalAghor").Value
        '         txt_TotalBdel.Text = rs("TotalBdelAll").Value

        '         txt_TotalProudact.Text = rs("TotalBounseProduction").Value
        '         txt_TotalAntkal.Text = rs("TotalBdelAnkal").Value
        '     Else
        '         txt_TotalEdafy.Text = "0"
        '         txt_BdelSfr.Text = "0"
        '         txt_TotalAgor.Text = "0"
        '         txt_TotalBdel.Text = "0"


        '     End If

    End Sub
   

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        sql = "Delete TB_Motagher  WHERE Emp_Month = '" & com_month.Text & "' and emp_year ='" & com_year.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)




        MsgBox("تم ارجاع الشهر", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Fill_Find()
    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellValueChanged1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        On Error Resume Next
        Dim varfloat, varfloat1, varfloat2, varfloat3, varfloat4, varfloat5, varfloat6, varfloat7, varfloat8, varfloat9, varfloat10 As Single
        Dim ro, mt As Integer
        ro = DataGridView2.CurrentRow.Index
        mt = ro
        varfloat = DataGridView2.Item(2, mt).Value
        varfloat1 = DataGridView2.Item(3, mt).Value
        varfloat2 = DataGridView2.Item(4, mt).Value
        varfloat3 = DataGridView2.Item(5, mt).Value
        varfloat4 = DataGridView2.Item(6, mt).Value
        varfloat5 = DataGridView2.Item(7, mt).Value
        varfloat6 = DataGridView2.Item(8, mt).Value
        varfloat7 = DataGridView2.Item(9, mt).Value
        varfloat8 = DataGridView2.Item(10, mt).Value
        varfloat9 = DataGridView2.Item(11, mt).Value
        varfloat10 = DataGridView2.Item(12, mt).Value



        DataGridView2.Item(13, mt).Value = varfloat + varfloat1 + varfloat2 + varfloat3 + varfloat4 + varfloat5 + varfloat6 + varfloat7 + varfloat8 + varfloat9 + varfloat10

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        varEmpReport = 1
        frm_BadelReport.Show()
    End Sub
End Class