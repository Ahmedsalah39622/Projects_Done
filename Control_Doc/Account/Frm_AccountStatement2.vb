Imports ADODB

Public Class Frm_AccountStatement2
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Dim varbalnce, varFinalBalance As Single
    Dim xx As Single
    Dim varFlagD, varFlagC As Integer


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
        'sql = "      SELECT NumberBill, DateMoveM, Discription, Debit, Cridit, Rat_Cur, Debit_EGP, Cridit_EGP, TypeBill, AccountNo " & _
        '  " FROM     dbo.MovmentStatement " & _
        '  "  " & _
        '  " where   (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and AccountNo ='" & txt_codeAcc.Text & "' and Compny_Code ='" & VarCodeCompny & "' order by DateMoveM "

        'If Rbb2.Checked = True Then
        '    sql = "SELECT         dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.MovmentStatement.Discription, dbo.MovmentStatement.Debit, dbo.MovmentStatement.Cridit, dbo.MovmentStatement.Rat_Cur, " & _
        '          "               dbo.MovmentStatement.Debit_EGP, dbo.MovmentStatement.Cridit_EGP, dbo.MovmentStatement.TypeBill, dbo.MovmentStatement.AccountNo, dbo.BD_Currency.Name AS Currency " & _
        '          " FROM            dbo.MovmentStatement LEFT OUTER JOIN " & _
        '          "                         dbo.BD_Currency ON dbo.MovmentStatement.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.MovmentStatement.CruunceyNo = dbo.BD_Currency.Code " & _
        '          " where   (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and dbo.MovmentStatement.AccountNo ='" & txt_codeAcc.Text & "' and dbo.MovmentStatement.Compny_Code ='" & VarCodeCompny & "' order by  dbo.MovmentStatement.NumberBill "
        'End If

        'If Rbb1.Checked = True Then
        sql = "SELECT         dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.MovmentStatement.Discription, dbo.MovmentStatement.Debit, dbo.MovmentStatement.Cridit, dbo.MovmentStatement.Rat_Cur, " & _
              "               dbo.MovmentStatement.Debit_EGP, dbo.MovmentStatement.Cridit_EGP, dbo.MovmentStatement.TypeBill, dbo.MovmentStatement.AccountNo, dbo.BD_Currency.Name AS Currency " & _
              " FROM            dbo.MovmentStatement LEFT OUTER JOIN " & _
              "                         dbo.BD_Currency ON dbo.MovmentStatement.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.MovmentStatement.CruunceyNo = dbo.BD_Currency.Code " & _
              " where   (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and dbo.MovmentStatement.AccountNo ='" & txt_codeAcc.Text & "' and dbo.MovmentStatement.Compny_Code ='" & VarCodeCompny & "' and dbo.MovmentStatement.Discription like '%" & txt_Notes.Text & "%'  order by  dbo.MovmentStatement.DateMoveM "
        'End If



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
            DataGridView2.Item(11, 0).Value = ""
            DataGridView2.Item(12, 0).Value = ""
            DataGridView2.Item(13, 0).Value = ""

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("NumberBill").Value
                    DataGridView2.Item(1, i).Value = rs("DateMoveM").Value
                    DataGridView2.Item(2, i).Value = rs("Discription").Value
                    DataGridView2.Item(10, i).Value = Math.Round(rs("Debit").Value, 2)
                    DataGridView2.Item(11, i).Value = Math.Round(rs("Cridit").Value, 2)
                    DataGridView2.Item(12, i).Value = Math.Round(rs("Rat_Cur").Value, 2)
                    DataGridView2.Item(13, i).Value = rs("Currency").Value
                    DataGridView2.Item(3, i).Value = Math.Round(rs("Debit_EGP").Value, 2)
                    DataGridView2.Item(4, i).Value = Math.Round(rs("Cridit_EGP").Value, 2)

                    DataGridView2.Item(8, i).Value = Math.Round(rs("Cridit_EGP").Value, 2)

                    If Val(DataGridView2.Item(4, i).Value) > 0 And Val(DataGridView2.Item(3, i).Value) = 0 Then varbalnce = Val(varFinalBalance) - Val(DataGridView2.Item(4, i).Value) : DataGridView2.Item(7, i).Value = "دائن"
                    If Val(DataGridView2.Item(3, i).Value) > 0 And Val(DataGridView2.Item(3, i).Value) > 0 Then varbalnce = Val(varFinalBalance) + Val(DataGridView2.Item(3, i).Value) : DataGridView2.Item(7, i).Value = "مدين"
                    'If rs("TypeBill").Value = 1 Then DataGridView2.Item(6, i).Value = "سند قبض" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.LightYellow
                    If rs("TypeBill").Value = 2 Then DataGridView2.Item(6, i).Value = "فاتورة مبيعات" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Azure
                    If rs("TypeBill").Value = 5 Then DataGridView2.Item(6, i).Value = "فاتورة مرتجع" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Cyan
                    If rs("TypeBill").Value = 6 Then DataGridView2.Item(6, i).Value = "فاتورة شراء" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.LightYellow
                    If rs("TypeBill").Value = 3 Then DataGridView2.Item(6, i).Value = "سند قبض" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.LimeGreen
                    If rs("TypeBill").Value = 8 Then DataGridView2.Item(6, i).Value = "قيد يومية" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Gray
                    If rs("TypeBill").Value = 4 Then DataGridView2.Item(6, i).Value = "سند صرف" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Cyan
                    If rs("TypeBill").Value = 25 Then DataGridView2.Item(6, i).Value = "فاتورة مرتد شراء" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Azure
                    If rs("TypeBill").Value = 21 Then DataGridView2.Item(6, i).Value = "اذن صرف المخزن" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Azure

                    If rs("TypeBill").Value = 13 Then DataGridView2.Item(6, i).Value = "ايداع شيك" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Linen
                    If rs("TypeBill").Value = 14 Then DataGridView2.Item(6, i).Value = "تحصيل شيك" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.CadetBlue
                    If rs("TypeBill").Value = 15 Then DataGridView2.Item(6, i).Value = "ارتجاع شيك" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.DarkOrange

                    If rs("TypeBill").Value = 17 Then DataGridView2.Item(6, i).Value = "صرف شيك" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.CadetBlue
                    If rs("TypeBill").Value = 18 Then DataGridView2.Item(6, i).Value = "ارتداد شيك" : DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.DarkOrange




                    xx = Val(txt_Balance.Text)

                    varFinalBalance = varbalnce
                    DataGridView2.Item(5, i).Value = Math.Round(Math.Round(varFinalBalance, 2) + Math.Round(xx, 2), 2)

                    DataGridView2.Item(9, i).Value = Math.Round(Math.Round(varFinalBalance, 2) + Math.Round(xx, 2), 2)
                    '================================================================vardate1
                    If Val(DataGridView2.Item(5, i).Value) < 0 Then
                        Dim yy As String
                        DataGridView2.Item(5, i).Value = Math.Round(Val(DataGridView2.Item(5, i).Value) * (-1), 2)
                        yy = DataGridView2.Item(5, i).Value
                        DataGridView2.Item(5, i).Value = yy
                    End If


                    '==============================================
                    sql = "DROP VIEW View_2 "
                    Cnn.Execute(sql)
                    sql2 = " CREATE VIEW View_2 AS SELECT NumberBill, AccountNo  FROM dbo.MovmentStatement WHERE  (AccountNo = '" & txt_codeAcc.Text & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))"
                    Cnn.Execute(sql2)
                    '==================================================

                    '===================================الحساب الاخر
                    sql2 = "   SELECT TOP (100) PERCENT dbo.View_2.NumberBill, dbo.MovmentStatement.TypeBill, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAccountOther " & _
                   " FROM     dbo.View_2 INNER JOIN " & _
                   "                  dbo.MovmentStatement ON dbo.View_2.NumberBill = dbo.MovmentStatement.NumberBill INNER JOIN " & _
                   "                  dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No " & _
                   " WHERE  (dbo.MovmentStatement.AccountNo <> '" & txt_codeAcc.Text & "') AND (dbo.View_2.NumberBill = '" & rs("NumberBill").Value & "') AND (dbo.MovmentStatement.TypeBill = '" & rs("TypeBill").Value & "') " & _
                   " ORDER BY dbo.View_2.NumberBill "

                    rs2 = Cnn.Execute(sql2)
                    If rs2.EOF = False Then DataGridView2.Item(14, i).Value = rs2("NameAccountOther").Value Else DataGridView2.Item(14, i).Value = ""
                    '============================================


                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub
    Sub cerate_AccountOther()

    End Sub
    Sub count_colume()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(3).Value)
        Next
        txt_De.Text = total
        txt_total.Text = Math.Round(Val(txt_Balance.Text) + Val(txt_De.Text) - Val(txt_Cr.Text), 2)
    End Sub
    Sub count_colume2()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            total += Val(DataGridView2.Rows(i).Cells(4).Value)
        Next
        txt_Cr.Text = total
        txt_total.Text = Val(txt_De.Text) - Val(txt_Cr.Text)
        txt_total.Text = Math.Round(Val(txt_Balance.Text) + Val(txt_De.Text) - Val(txt_Cr.Text), 2)

    End Sub
    Sub final_sum()


        sql = "   SELECT AccountType, AccountPh, Account_No        FROM dbo.ST_CHARTOFACCOUNT  WHERE(Account_No = '" & txt_codeAcc.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varFlagD = rs("AccountType").Value
            varFlagC = rs("AccountPh").Value
        End If

        '=============================================================================حالة ميزانية دائن اقل من الصفر

        If Val(txt_total.Text) < 0 And varFlagD = 1 And varFlagC = 1 Then
            Dim yy As String
            txt_total.Text = Val(txt_total.Text) * (-1)
            yy = txt_total.Text
            txt_total.Text = "" + yy + ""
            Exit Sub
        End If

        '========================================================================= حالة ميزانية دائن اكبر من الصفر

        If Val(txt_total.Text) > 0 And varFlagD = 1 And varFlagC = 1 Then
            Dim yy As String
            txt_total.Text = Val(txt_total.Text)
            yy = txt_total.Text
            txt_total.Text = "(" + yy + ")"
            Exit Sub
        End If





        '=============================================================================حالة ميزانية مدين اقل من الصفر

        If Val(txt_total.Text) < 0 And varFlagD = 1 And varFlagC = 0 Then
            Dim yy As String
            txt_total.Text = Val(txt_total.Text) * (-1)
            yy = txt_total.Text
            txt_total.Text = "(" + yy + ")"
            Exit Sub
        End If

        '========================================================================= حالة ميزانية مدين اكبر من الصفر

        If Val(txt_total.Text) > 0 And varFlagD = 1 And varFlagC = 0 Then
            Dim yy As String
            txt_total.Text = Val(txt_total.Text)
            yy = txt_total.Text
            txt_total.Text = "" + yy + ""
            Exit Sub
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FindBalance()
        find_data()
        count_colume()
        count_colume2()
        final_sum()
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




        sql = "   SELECT AccountNo, SUM(Debit) - SUM(Cridit) AS Bl     FROM dbo.MovmentStatement WHERE  (DateMoveM < CONVERT(DATETIME, '" & vardate & "', 102)) and AccountNo ='" & txt_codeAcc.Text & "' and  Compny_Code ='" & VarCodeCompny & "' GROUP BY AccountNo"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Balance.Text = Math.Round(rs("Bl").Value, 2) Else txt_Balance.Text = "0"
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click




        If Op_status1.Checked = True Then
            varcode_form = 25100
            VarOpenlookup2 = 25100
            Frm_LookUpCustomer.Find_Customer()
            Frm_LookUpCustomer.ShowDialog()
        ElseIf Op_status2.Checked = True Then
            'varcode_form = 41100
            'Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

            'Frm_LookUpAccount.Show()

            varcode_form = 26100
            VarOpenlookup2 = 26100
            Frm_LookUpCustomer.Find_Suppliser()
            Frm_LookUpCustomer.ShowDialog()

        ElseIf Op_status3.Checked = True Then

            'VARTBNAME = "vw_AccountData"
            'varcode_form = 3011
            ''Frm_LookUpAccount.Fill_Acc()
            'Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()
            'Frm_LookUpAccount.ShowDialog()

            varcode_form = 3011

            Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

            Frm_LookUpAccount.Show()
        End If
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Len(txt_codeAcc.Text) = 0 Then MsgBox("من فضلك اختار الحساب المراد  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Renal Solution Software Module") : Exit Sub

        'sql = "Delete Temp_Statment   "
        'rs = Cnn.Execute(sql)
        'save_temp()
        'rpt_Statment.Show()


        If Rbb2.Checked = True Then
            sql = "Delete Temp_Statment   "
            rs = Cnn.Execute(sql)
            save_temp()
            rpt_Statment.Show()
        ElseIf Rbb1.Checked = True Then
            sql = "Delete Temp_Statment   "
            rs = Cnn.Execute(sql)
            save_temp()
            rpt_StatmentSortDate.Show()
        End If
    End Sub

    Sub save_temp()

        On Error Resume Next

        For x As Integer = 0 To DataGridView2.Rows.Count - 1

            Dim dd As DateTime = DataGridView2.Item(1, x).Value
            Dim vardate As String
            vardate = dd.ToString("MM-d-yyyy")

            '============================
            sql = "INSERT INTO Temp_Statment (No_Move,Date_Move,Dis,Debit,Crdite,Balance,Type,Type_Account,DebitOrignal,CrditeOrignal,Rat_Cur,Currency,NameAccount) " & _
                  " values  ('" & DataGridView2.Item(0, x).Value & "' ,'" & vardate & "','" & DataGridView2.Item(2, x).Value & "','" & DataGridView2.Item(3, x).Value & "','" & DataGridView2.Item(8, x).Value & "','" & DataGridView2.Item(5, x).Value & "','" & DataGridView2.Item(6, x).Value & "','" & DataGridView2.Item(7, x).Value & "','" & DataGridView2.Item(10, x).Value & "','" & DataGridView2.Item(11, x).Value & "','" & DataGridView2.Item(12, x).Value & "','" & DataGridView2.Item(13, x).Value & "','" & DataGridView2.Item(14, x).Value & "')"
            Cnn.Execute(sql)

        Next x
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick



        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro
        'varinvoice_type2 = 0
        'If ro = 0 Then Exit Sub

        If DataGridView2.Item(6, mt).Value = "فاتورة مبيعات" Then

            sql = " SELECT *      FROM dbo.TB_Header_InvoiceSal WHERE  (Ser_InvoiceNo = '" & DataGridView2.Item(0, mt).Value & "')"
            rs = Cnn.Execute(sql)

            Frm_SalseInvoice.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            'Frm_All_Invoice.Enabled = True
            Frm_SalseInvoice.Show()
        End If


        If DataGridView2.Item(6, mt).Value = "فاتورة شراء" Then

            sql = " SELECT Ext_InvoiceNo FROM dbo.TB_Header_InvoicePrcheses WHERE  (Ser_InvoiceNo = '" & DataGridView2.Item(0, mt).Value & "')"
            rs = Cnn.Execute(sql)

            Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_Prcheses_Invoice.find_hedar()
            Frm_Prcheses_Invoice.find_detalis()
            Frm_Prcheses_Invoice.Total_Sum()
            Frm_Prcheses_Invoice.sum_tax()
            'Frm_All_Invoice.Enabled = True
            Frm_Prcheses_Invoice.MdiParent = Mainmune
            Frm_Prcheses_Invoice.Show()
            Frm_Prcheses_Invoice.find_hedar()
        End If


        If DataGridView2.Item(6, mt).Value = "فاتورة مرتد شراء" Then

            sql = " SELECT Ext_InvoiceNo FROM dbo.TB_Header_InvoicePrcheses_Rented WHERE  (Ser_InvoiceNo = '" & DataGridView2.Item(0, mt).Value & "')"
            rs = Cnn.Execute(sql)

            Frm_Prcheses_Invoice_Rented.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_Prcheses_Invoice_Rented.MdiParent = Mainmune
            Frm_Prcheses_Invoice_Rented.Show()
            Frm_Prcheses_Invoice_Rented.find_hedar()
            Frm_Prcheses_Invoice_Rented.find_detalis()
            Frm_Prcheses_Invoice_Rented.Total_Sum()
            Frm_Prcheses_Invoice_Rented.sum_tax()
           
        End If


        If DataGridView2.Item(6, mt).Value = "اذن صرف المخزن" Then

            'sql = " SELECT Ext_InvoiceNo FROM dbo.TB_Header_InvoicePrcheses_Rented WHERE  (Ser_InvoiceNo = '" & DataGridView2.Item(0, mt).Value & "')"
            'rs = Cnn.Execute(sql)

            'Frm_Prcheses_Invoice_Rented.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
          
            Frm_AznSarf.Com_InvoiceNo2.Text = DataGridView2.Item(0, mt).Value
            Frm_AznSarf.find_hedar()
            Frm_AznSarf.find_detalis()
            Frm_AznSarf.Total_Sum()
            Frm_AznSarf.MdiParent = Mainmune
            Frm_AznSarf.Show()

        End If


        If DataGridView2.Item(6, mt).Value = "سند قبض" Then
            Frm_ReciptCash2.Com_Exp_No.Text = DataGridView2.Item(0, mt).Value
            Frm_ReciptCash2.find_hedar()
            Frm_ReciptCash2.find_detalis()

            Frm_ReciptCash2.find_all_Detils()

            Frm_ReciptCash2.Total_Sum()
            Frm_ReciptCash2.MdiParent = Mainmune
            'Frm_Receipt.Enabled = True
            Frm_ReciptCash2.Show()
        End If

        If DataGridView2.Item(6, mt).Value = "سند صرف" Then
            Frm_Expenses2.Com_Exp_No.Text = DataGridView2.Item(0, mt).Value
            Frm_Expenses2.find_hedar()
            Frm_Expenses2.find_detalis()

            'Frm_Expenses2.find_all_Detils()

            Frm_Expenses2.Total_Sum2()

            Frm_Expenses2.MdiParent = Mainmune
            'Frm_Receipt.Enabled = True
            Frm_Expenses2.Show()
        End If

        If DataGridView2.Item(6, mt).Value = "قيد يومية" Then
            'varinvoice_type2 = 10
            Frm_Gl4.Com_GL_No.Text = DataGridView2.Item(0, mt).Value

            Frm_Gl4.find_hedar()
            Frm_Gl4.find_detalis()

            statusopen = 1

            Frm_Gl4.Total_Sum()
            Frm_Gl4.TabPane1.SelectedPageIndex = 0
            Frm_Gl4.MdiParent = Mainmune
            'Frm_Receipt.Enabled = True
            Frm_Gl4.Show()

        End If



        'If DataGridView2.Item(6, mt).Value = "فاتورة مشتريات" Then
        '    Frm_Invoice_Prcheses.Com_InvoiceNo2.Text = DataGridView2.Item(0, mt).Value
        '    sql = " SELECT Ex_No, NumberBill      FROM dbo.BillBrchsesHder WHERE  (NumberBill = '" & DataGridView2.Item(0, mt).Value & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then Frm_Invoice_Prcheses.Com_InvoiceNo.Text = rs("NumberBill").Value
        '    varinvoice_type2 = 4
        '    Frm_Invoice_Prcheses.Fill_INVOICE2()
        '    Frm_Invoice_Prcheses.MdiParent = Mainmune
        '    'Frm_All_Invoice.Enabled = True
        '    Frm_Invoice_Prcheses.Show()
        'End If

        If DataGridView2.Item(6, mt).Value = "فاتورة مرتجع" Then
            Frm_InvoiceRented.Com_InvoiceNo2.Text = DataGridView2.Item(0, mt).Value
            Frm_InvoiceRented.Com_InvoiceNo.Text = DataGridView2.Item(0, mt).Value
            Frm_InvoiceRented.find_hedar()
            Frm_InvoiceRented.find_detalis()
            Frm_InvoiceRented.sum_tax()
            Frm_InvoiceRented.Total_Sum()
            Frm_InvoiceRented.MdiParent = Mainmune
            'Frm_All_Invoice.Enabled = True
            Frm_InvoiceRented.Show()
        End If


    End Sub

    Private Sub Op_status1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Op_status1_Click(sender As Object, e As EventArgs)
        txt_NameAcc.Text = ""
        txt_codeAcc.Text = ""
    End Sub



    Private Sub Op_status2_Click(sender As Object, e As EventArgs)
        txt_NameAcc.Text = ""
        txt_codeAcc.Text = ""
    End Sub



    Private Sub Op_status3_Click(sender As Object, e As EventArgs)
        txt_NameAcc.Text = ""
        txt_codeAcc.Text = ""
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        If Len(txt_codeAcc.Text) = 0 Then MsgBox("من فضلك اختار الحساب المراد  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Renal Solution Software Module") : Exit Sub

        sql = "Delete Temp_Statment   "
        rs = Cnn.Execute(sql)
        save_temp()
        rpt_StatmentSortDate.Show()
    End Sub

    Private Sub Frm_AccountStatement2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class