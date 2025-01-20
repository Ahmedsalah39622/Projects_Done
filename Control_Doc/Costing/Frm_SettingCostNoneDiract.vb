Imports ADODB

Public Class Frm_SettingCostNoneDiract

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
      

    End Sub

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
  

    End Sub
    Sub Fill_Find()

        On Error Resume Next
        sql = "     SELECT dbo.BD_DIRCTORAY.Name AS NameDepart, dbo.BD_BanCostingNoneDiract.Name AS NameBandCost, dbo.TB_CostNoneDirect.Cost_Month, dbo.TB_CostNoneDirect.NCost_Month,  " & _
     "                  dbo.TB_CostNoneDirect.ValueLoadCost, dbo.TB_CostNoneDirect.CostDay, dbo.TB_CostNoneDirect.CostHoure " & _
     " FROM     dbo.TB_CostNoneDirect INNER JOIN " & _
     "                  dbo.BD_DIRCTORAY ON dbo.TB_CostNoneDirect.Code_Depart = dbo.BD_DIRCTORAY.Code AND dbo.TB_CostNoneDirect.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code INNER JOIN " & _
     "                  dbo.BD_BanCostingNoneDiract ON dbo.TB_CostNoneDirect.Code_BandNoneDirect = dbo.BD_BanCostingNoneDiract.Code AND  " & _
     "        dbo.TB_CostNoneDirect.Compny_Code = dbo.BD_BanCostingNoneDiract.Compny_Code " & _
     " WHERE  (dbo.TB_CostNoneDirect.Compny_Code = '" & VarCodeCompny & "') "


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

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1


                    DataGridView2.Item(0, i).Value = rs("NameDepart").Value
                    DataGridView2.Item(1, i).Value = rs("NameBandCost").Value
                    DataGridView2.Item(2, i).Value = rs("Cost_Month").Value
                    DataGridView2.Item(3, i).Value = rs("NCost_Month").Value
                    DataGridView2.Item(4, i).Value = rs("ValueLoadCost").Value
                    DataGridView2.Item(5, i).Value = rs("CostDay").Value
                    DataGridView2.Item(6, i).Value = rs("CostHoure").Value
                   



                    rs.MoveNext()


                Next i
                count_colume4()
                count_colume()
                count_colume2()
                count_colume3()

                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub
    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        'TB_CostNoneDirect
        On Error Resume Next
        sql = "Delete TB_CostNoneDirect  WHERE  Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1


            '============================================كود الادارة
            sql = "select * from BD_DIRCTORAY where Name  = '" & DataGridView2.Item(0, x).Value & "' and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_deprt = rs("code").Value
            '============================================================== كود بند التكلفة
            sql = "select * from BD_BanCostingNoneDiract where Name  = '" & DataGridView2.Item(1, x).Value & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodebandCostNoneDiract = rs("code").Value
            '======================================================


            sql = "INSERT INTO TB_CostNoneDirect (Code_Depart, Code_BandNoneDirect,Cost_Month,NCost_Month,ValueLoadCost,CostDay,CostHoure,Compny_Code) " & _
                    " values  (" & varcode_deprt & " ,N'" & varcodebandCostNoneDiract & "',N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(3, x).Value & "',N'" & DataGridView2.Item(4, x).Value & "',N'" & DataGridView2.Item(5, x).Value & "',N'" & DataGridView2.Item(6, x).Value & "' ,'" & VarCodeCompny & "' )"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub Frm_SettingCostNoneDiract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Find()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete TB_CostNoneDirect  WHERE  Code_Depart ='" & varcode_deprt & "' and Code_BandNoneDirect ='" & varcodebandCostNoneDiract & "' and  Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Fill_Find()
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        DataGridView2.RowCount = DataGridView2.RowCount + 1
        For i = 1 To DataGridView2.RowCount - 1
            DataGridView2.Item(0, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(1, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(2, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(3, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(4, DataGridView2.RowCount - 2).Value = ""
        


        Next i
    End Sub

    Sub count_colume()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            total += Val(DataGridView2.Rows(i).Cells(4).Value)

        Next
        txt_TotalLoading.Text = total

    End Sub

    Sub count_colume2()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            total += Val(DataGridView2.Rows(i).Cells(5).Value)

        Next
        txt_TotalDay.Text = total

    End Sub

    Sub count_colume3()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            total += Val(DataGridView2.Rows(i).Cells(6).Value)

        Next
        txt_totalHoure.Text = total

    End Sub

    Sub count_colume4()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            total += Val(DataGridView2.Rows(i).Cells(2).Value)

        Next
        TextBoxX1.Text = total

    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellDoubleClick1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        On Error Resume Next
        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro

        rowindex = mt

        If DataGridView2.Item(0, mt).Value = "" Then

            vartable = "BD_DIRCTORAY"
            VarOpenlookup = 12012
            Frm_Lookup.Text = "بحث"
            Frm_Lookup.ShowDialog()
        End If


        If DataGridView2.Item(1, mt).Value = "" Then

            vartable = "BD_BanCostingNoneDiract"
            VarOpenlookup = 12013
            Frm_Lookup.Text = "بحث"
            Frm_Lookup.ShowDialog()
        End If

        '============================================كود الادارة
        sql = "select * from BD_DIRCTORAY where Name  = '" & DataGridView2.Item(0, mt).Value & "' and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_deprt = rs("code").Value
        '============================================================== كود بند التكلفة
        sql = "select * from BD_BanCostingNoneDiract where Name  = '" & DataGridView2.Item(1, mt).Value & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodebandCostNoneDiract = rs("code").Value
        '======================================================
    End Sub

    Private Sub DataGridView2_CellValueChanged1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        On Error Resume Next
        Dim ro, mt As Integer
        ro = DataGridView2.CurrentRow.Index
        mt = ro
        DataGridView2.Item(4, mt).Value = Math.Round(Val(DataGridView2.Item(2, mt).Value) * Val(DataGridView2.Item(3, mt).Value) / 100, 2)
        DataGridView2.Item(5, mt).Value = Math.Round(Val(DataGridView2.Item(4, mt).Value) / 30, 2)
        DataGridView2.Item(6, mt).Value = Math.Round(Val(DataGridView2.Item(5, mt).Value) / 8, 2)
    End Sub
End Class