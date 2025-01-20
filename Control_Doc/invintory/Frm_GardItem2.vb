Imports ADODB

Public Class Frm_GardItem2
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Dim varbalnce, varFinalBalance As Single
    Dim xx As Single

    Private Sub cmd_Find_Click(sender As Object, e As EventArgs) Handles cmd_Find.Click

        If Len(Com_Stores.Text) = 0 Then MsgBox("من فضلك أختار المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_codeItem.Text) = 0 Then MsgBox("من فضلك اختار الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        sql = " SELECT * FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "' and Name ='" & Com_Stores.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("code").Value
        '=====================================================================
        FindBalance()
        find_data()
        count_colume()
        count_colume2()
        final_sum()
    End Sub

    Sub find_data()
        On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        varbalnce = 0
        varFinalBalance = 0

        xx = 0
        sql = " select    * " & _
          " FROM     Vw_GarItem_Final " & _
          "  " & _
          " where   (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and NoItem ='" & txt_codeItem.Text & "' and Compny_Code ='" & VarCodeCompny & "' and  Code_Stores= '" & varcodestores & "' order by DateMoveM "

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
            DataGridView2.Item(10, 0).Value = ""

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("NumberBill").Value
                    DataGridView2.Item(1, i).Value = rs("DateMoveM").Value
                    DataGridView2.Item(2, i).Value = rs("Dis").Value
                    DataGridView2.Item(3, i).Value = rs("Unit").Value
                    DataGridView2.Item(4, i).Value = Math.Round(rs("Export").Value, 2)
                    DataGridView2.Item(5, i).Value = Math.Round(rs("Import").Value, 2)

                    DataGridView2.Item(9, i).Value = Math.Round(rs("Import").Value, 2)

                    If Val(DataGridView2.Item(5, i).Value) > 0 And Val(DataGridView2.Item(4, i).Value) = 0 Then varbalnce = Val(varFinalBalance) - Val(DataGridView2.Item(5, i).Value)
                    If Val(DataGridView2.Item(4, i).Value) > 0 And Val(DataGridView2.Item(4, i).Value) > 0 Then varbalnce = Val(varFinalBalance) + Val(DataGridView2.Item(4, i).Value)
                    If rs("TypeD").Value = 1 Then DataGridView2.Item(7, i).Value = "اذن صرف مخازن" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.LightYellow
                    'If rs("Type_Bill").Value = 2 Then DataGridView2.Item(7, i).Value = "فاتورة مبيعات" : DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Azure
                    'If rs("Type_Bill").Value = 5 Then DataGridView2.Item(7, i).Value = "فاتورة مرتجع" : DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Cyan
                    'If rs("Type_Bill").Value = 6 Then DataGridView2.Item(7, i).Value = "فاتورة شراء" : DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.LightYellow
                    If rs("TypeD").Value = 20 Then DataGridView2.Item(7, i).Value = "اذن اضافة مخازن" : DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.LimeGreen
                    'If rs("TypeBill").Value = 7 Then DataGridView2.Item(6, i).Value = "مرتجع مبيعات" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Cyan
                    If rs("TypeD").Value = 0 Then DataGridView2.Item(7, i).Value = "بضاعة اول المدة" : DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Cyan






                    xx = Val(txt_Balance.Text)

                    varFinalBalance = varbalnce
                    DataGridView2.Item(6, i).Value = Math.Round(Math.Round(varFinalBalance, 2) + Math.Round(xx, 2), 2)

                    DataGridView2.Item(10, i).Value = Math.Round(Math.Round(varFinalBalance, 2) + Math.Round(xx, 2), 2)
                    '================================================================vardate1
                    If Val(DataGridView2.Item(6, i).Value) < 0 Then
                        Dim yy As String
                        DataGridView2.Item(6, i).Value = Math.Round(Val(DataGridView2.Item(6, i).Value) * (-1), 2)
                        yy = DataGridView2.Item(6, i).Value
                        DataGridView2.Item(6, i).Value = yy * -1
                    End If


                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub

    Sub FindBalance()

        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2




        sql = "   SELECT NoItem, SUM(Export) - SUM(Import) AS Bl     FROM dbo.Vw_GarItem_Final WHERE  (DateMoveM < CONVERT(DATETIME, '" & vardate & "', 102)) and NoItem ='" & txt_codeItem.Text & "' and  Compny_Code ='" & VarCodeCompny & "' and  Code_Stores= '" & varcodestores & "' GROUP BY NoItem "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Balance.Text = Math.Round(rs("Bl").Value, 2) Else txt_Balance.Text = "0"
    End Sub

    Sub count_colume()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(4).Value)
        Next
        txt_De.Text = total
        txt_total.Text = Math.Round(Val(txt_Balance.Text) + Val(txt_De.Text) - Val(txt_Cr.Text), 2)
    End Sub
    Sub count_colume2()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(5).Value)
        Next
        txt_Cr.Text = total
        txt_total.Text = Val(txt_De.Text) - Val(txt_Cr.Text)
        txt_total.Text = Math.Round(Val(txt_Balance.Text) + Val(txt_De.Text) - Val(txt_Cr.Text), 2)

    End Sub
    Sub final_sum()
        If Val(txt_total.Text) < 0 Then
            Dim yy As String
            txt_total.Text = Val(txt_total.Text) * (-1)
            yy = txt_total.Text
            txt_total.Text = "(" + yy + ")"
        End If
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        varcode_form = 2501
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub Frm_GardItem2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Stores()
    End Sub

    Sub fill_Stores()
        Com_Stores.Items.Clear()

        sql = " SELECT Name FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Stores.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Len(Com_Stores.Text) = 0 Then MsgBox("من فضلك أختار المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_codeItem.Text) = 0 Then MsgBox("من فضلك اختار الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        '===================================Ref
        sql = " SELECT Code, RTRIM(Ex_Item) AS ref FROM     dbo.BD_Item WHERE  (Code = '" & txt_codeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then var_ref_prodact = rs("ref").Value

        sql = "Delete Temp_Statment   "
        rs = Cnn.Execute(sql)
        save_temp()
        Frm_GardReport.Show()
    End Sub
    Sub save_temp()

        On Error Resume Next

        For x As Integer = 0 To DataGridView2.Rows.Count - 1

            Dim dd As DateTime = DataGridView2.Item(1, x).Value
            Dim vardate As String
            vardate = dd.ToString("MM-d-yyyy")

            '============================
            sql = "INSERT INTO Temp_Statment (No_Move,Date_Move,Dis,Type_Account,Debit,Crdite,Balance,Type) " & _
                  " values  (N'" & DataGridView2.Item(0, x).Value & "' ,N'" & vardate & "',N'" & DataGridView2.Item(2, x).Value & "',N'" & DataGridView2.Item(3, x).Value & "',N'" & DataGridView2.Item(4, x).Value & "',N'" & DataGridView2.Item(9, x).Value & "',N'" & DataGridView2.Item(6, x).Value & "',N'" & DataGridView2.Item(7, x).Value & "')"
            Cnn.Execute(sql)

        Next x
    End Sub
End Class