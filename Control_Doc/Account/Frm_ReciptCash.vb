Public Class Frm_ReciptCash
    Dim varcodeCostCenter1, varcodeCostCenter2 As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub cmd_New_Click(sender As Object, e As EventArgs)
        Com_Exp_No.Enabled = True
        txt_Receipt_Date.Value = Date.Now
        txt_flg.BackColor = Color.FloralWhite
        cmd_Save.Enabled = True
        txt_flg.Text = ""
        last_Data()
        clear_data()

    End Sub

    Sub fill_Expenses()
        Com_Exp_No.Items.Clear()

        sql = " SELECT Receipt_No FROM     dbo.TB_Receipt where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Exp_No.Items.Add(rs("Receipt_No").Value)
            rs.MoveNext()
        Loop
    End Sub


    'Sub fill_OrderNo()
    '    Com_OrderNo.Items.Clear()

    '    sql = "    SELECT        Order_NO         FROM dbo.TB_Header_OrderItem where Compny_Code ='" & VarCodeCompny & "' "


    '    rs = Cnn.Execute(sql)
    '    Do While Not rs.EOF
    '        Com_OrderNo.Items.Add(rs("Order_NO").Value)
    '        rs.MoveNext()
    '    Loop
    'End Sub

    Sub fill_Cru()
        Com_Cur.Items.Clear()

        sql = "    SELECT  Name  FROM BD_Currency where Compny_Code ='" & VarCodeCompny & "'"


        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Cur.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_CostCenterMain()
        'com_CostcenterMain.Items.Clear()

        'sql = "SELECT Account_No, AccountName FROM     dbo.TB_ChartOfCostCenter WHERE  (Level_No = 0)"
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    com_CostcenterMain.Items.Add(Trim(rs("AccountName").Value))
        '    rs.MoveNext()
        'Loop
    End Sub


    Sub last_Data()



        sql = "SELECT        MAX(Receipt_No) AS MaxmamNo FROM dbo.TB_Receipt where Compny_Code = '" & VarCodeCompny & "' HAVING(MAX(Receipt_No) Is Not NULL) "

        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_Exp_No.Text = rs("MaxmamNo").Value + 1
        Else
            Com_Exp_No.Text = 1
            clear_data()

        End If
    End Sub
    Sub clear_data()
        'Com_Receipt_No.Text = ""
        'Com_ProjectName.Text = ""
        'Com_UnitNumber.Text = ""
        'Com_DeprtName.Text = ""
        txt_Receipt_Date.Text = ""
        txt_Name.Text = ""
        Txt_ExpValue.Text = ""
        txt_AccountNo1.Text = ""
        txt_AccountNo2.Text = ""
        txt_NameAccount1.Text = ""
        txt_NameAccount2.Text = ""
        txt_Notes.Text = ""
        com_Type.Text = ""
        Cmd_OpenInvoice.Visible = False
        LabelX16.Visible = False
        Com_InvoiceNo.Visible = False
        lab_Invoice.Visible = False

        Cmd_Delete.Enabled = False
        cmd_Save.Enabled = True
        Cmd_Print.Enabled = False
    End Sub

    Private Sub Frm_ReceiptCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        fill_Expenses()
        fill_CostCenterMain()
        fill_Cru()
        'fill_OrderNo()

        com_Type.Items.Add("دفعة مقدمة")
        com_Type.Items.Add("فاتورة")
    End Sub



    Private Sub cmd_Save_Click(sender As Object, e As EventArgs)
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_ExpValue.Text) = 0 Then MsgBox("من فضللك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo1.Text) = 0 Then MsgBox("من فضللك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo2.Text) = 0 Then MsgBox("من فضللك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_ExpValue.Text) = 0 Then MsgBox("من فضللك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضللك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_ExpValue_EGP.Text) = 0 Then MsgBox("من فضللك ادخل المبلغ بالجنية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضللك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضللك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        '============================================
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")

        Dim VarType As Integer
        If com_Type.Text = "فاتورة" Then VarType = 0
        If com_Type.Text = "دفعة مقدمة" Then VarType = 1




        sql = "INSERT INTO TB_Receipt (Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,Name,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice) " & _
        " values  (" & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & Txt_ExpValue.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo1.Text & "','" & txt_AccountNo2.Text & "','" & txt_Name.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_ExpValue_EGP.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "')"
        Cnn.Execute(sql)

        save_Statment()

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        last_Data()
        clear_data()
        fill_Expenses()

    End Sub
    Sub save_Statment()
        lastgl()
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '=================================Account1
        '=============رقم مركز التكلفة1
        sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo1.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================

        '=============رقم مركز التكلفة2
        sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo2.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================





        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo) " & _
       " values  (N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo1.Text & "',N'" & txt_Notes.Text & "',N'" & Txt_ExpValue.Text & "',N'" & 0 & "',N'" & "3" & "',N'" & "0" & "','" & Com_Exp_No.Text & "','" & 1 & "','" & 1 & "','" & Txt_ExpValue.Text & "','" & 0 & "','" & VarCodeCompny & "','" & varcodeCostCenter1 & "' )"
        Cnn.Execute(sql)



        '=======================================================GL المدين
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  ('" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo1.Text & "','" & txt_Notes.Text & "','" & Txt_ExpValue.Text & "' ,'" & 0 & "','" & 3 & "','" & Com_Exp_No.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Txt_ExpValue.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)



        '=================================الدائن

        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo) " & _
      " values  (N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo2.Text & "',N'" & txt_Notes.Text & "',N'" & 0 & "',N'" & Txt_ExpValue.Text & "',N'" & "3" & "',N'" & "0" & "','" & Com_Exp_No.Text & "','" & 1 & "','" & 1 & "','" & 0 & "','" & Txt_ExpValue.Text & "','" & VarCodeCompny & "','" & varcodeCostCenter2 & "' )"
        Cnn.Execute(sql)



        '=======================================================GL الدائن
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  ('" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo2.Text & "','" & txt_Notes.Text & "','" & 0 & "' ,'" & Txt_ExpValue.Text & "','" & 3 & "','" & Com_Exp_No.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & Txt_ExpValue.Text & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)




    End Sub


    Sub lastgl()
        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM  dbo.Genralledger where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(IDGenral) Is Not Null) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub
    Private Sub Com_Receipt_No_SelectedIndexChanged(sender As Object, e As EventArgs)

        find_data()

    End Sub
    Sub find_data()
        On Error Resume Next



        sql = "   SELECT        dbo.TB_Receipt.flg, dbo.TB_Receipt.Name, dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Id_User, dbo.TB_Receipt.Notes, dbo.TB_Receipt.AccountNo1,  " & _
   "                         dbo.TB_Receipt.AccountNo2, dbo.TB_Receipt.Receipt_Value, dbo.ST_CHARTOFACCOUNT.AccountName, ST_CHARTOFACCOUNT_1.AccountName AS AccountName2, dbo.TB_Receipt.Compny_Code,  " & _
   "        dbo.TB_Receipt.Code_Salse, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Order_NO,dbo.TB_Receipt.rat,dbo.TB_Receipt.Receipt_Value_EGP,dbo.TB_Receipt.Invoice_No,dbo.TB_Receipt.Type_Invoice, dbo.BD_Currency.name " & _
   "FROM            dbo.TB_Receipt INNER JOIN " & _
   "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
   "                         dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Receipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code AND  " & _
   "                         dbo.TB_Receipt.AccountNo2 = ST_CHARTOFACCOUNT_1.Account_No LEFT OUTER JOIN " & _
   "                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.code LEFT OUTER JOIN " & _
   "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code " & _
   " GROUP BY dbo.TB_Receipt.flg, dbo.TB_Receipt.Name, dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Id_User, dbo.TB_Receipt.Notes, dbo.TB_Receipt.AccountNo1,  " & _
   "        dbo.TB_Receipt.AccountNo2, dbo.TB_Receipt.Receipt_Value, dbo.ST_CHARTOFACCOUNT.AccountName, ST_CHARTOFACCOUNT_1.AccountName, dbo.TB_Receipt.Compny_Code, dbo.TB_Receipt.Code_Salse, " & _
   "        dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Order_NO,dbo.TB_Receipt.rat,dbo.TB_Receipt.Receipt_Value_EGP,dbo.TB_Receipt.Invoice_No,dbo.TB_Receipt.Type_Invoice, dbo.BD_Currency.name " & _
   " HAVING        (dbo.TB_Receipt.Receipt_No = '" & Com_Exp_No.Text & "') AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') "


        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            If rs2("flg").Value = 1 Then txt_flg.Text = "ملغى" : txt_flg.BackColor = Color.LightYellow : cmd_Save.Enabled = False
            If rs2("flg").Value = 0 Then txt_flg.Text = "مرحل" : txt_flg.BackColor = Color.FloralWhite : cmd_Save.Enabled = True

            txt_Receipt_Date.Value = rs2("Receipt_Date").Value
            Txt_ExpValue.Text = rs2("Receipt_Value").Value
            txt_Notes.Text = rs2("Notes").Value
            txt_AccountNo1.Text = rs2("AccountNo1").Value
            txt_AccountNo2.Text = rs2("AccountNo2").Value
            txt_NameAccount1.Text = rs2("AccountName").Value
            txt_NameAccount2.Text = rs2("AccountName2").Value
            txt_Name.Text = rs2("Name").Value
            Com_Cur.Text = rs2("NameCruuncey").Value
            txt_No_Salse.Text = rs2("Code_Salse").Value
            txt_Name_Salse.Text = rs2("Emp_Name").Value
            'Com_OrderNo.Text = rs2("Order_NO").Value
            txt_rat.Text = rs2("rat").Value
            Txt_ExpValue_EGP.Text = rs2("Receipt_Value_EGP").Value
            Com_InvoiceNo.Text = rs2("Invoice_No").Value

            If rs2("Type_Invoice").Value = 0 Then com_Type.Text = "فاتورة"
            If rs2("Type_Invoice").Value = 1 Then com_Type.Text = "دفعة مقدمة"

            Cmd_Delete.Enabled = True
            cmd_Save.Enabled = False
            Cmd_Print.Enabled = True
        End If

    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)



        Dim x As String
        x = MsgBox("هل تريد الغاء السند", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Rental Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql = "UPDATE  TB_Receipt  SET flg = '" & 1 & "'  WHERE Receipt_No = " & Com_Exp_No.Text & "  and flg ='0' and Compny_Code = '" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)



                sql = "Delete Genralledger  WHERE TypeBill ='" & 3 & "' and No_Sand = " & Com_Exp_No.Text & " and Compny_Code = '" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)




                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 3 & "' and NumberBill = " & Com_Exp_No.Text & " and Compny_Code = '" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)

                MsgBox("تم الغاء السند ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


        End Select
    End Sub





    

    

    Sub Fill_invoice()
        If txt_AccountNo2.Text = "" Then Exit Sub
        Com_InvoiceNo.Items.Clear()
        sql = "   SELECT        dbo.ST_CHARTOFACCOUNT.Account_No AS Code, dbo.ST_CHARTOFACCOUNT.AccountName AS Name, dbo.ST_CHARTOFACCOUNT.Compny_Code, dbo.MovmentStatement.TypeBill,  " & _
   "                         dbo.MovmentStatement.Debit_EGP, dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo " & _
   " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
   "                         dbo.MovmentStatement ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.MovmentStatement.Compny_Code AND  " & _
   "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.MovmentStatement.AccountNo LEFT OUTER JOIN " & _
   "                         dbo.TB_Header_InvoiceSal ON dbo.MovmentStatement.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.MovmentStatement.NumberBill = dbo.TB_Header_InvoiceSal.Ser_InvoiceNo " & _
   " WHERE      (dbo.MovmentStatement.TypeBill = 2) AND (dbo.ST_CHARTOFACCOUNT.Account_No = '" & txt_AccountNo2.Text & "') and  (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')"

        rs = Cnn.Execute(sql)

        Do While Not rs.EOF
            Com_InvoiceNo.Items.Add(rs("Ext_InvoiceNo").Value)
            rs.MoveNext()
        Loop
    End Sub



    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs)
        Report_Recipt.Show()
        'Frm_Recipt_Report.MdiParent = Me
    End Sub

   
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Com_OrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Com_Cur_SelectedIndexChanged(sender As Object, e As EventArgs)
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_Receipt_Date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_Receipt_Date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102)) and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"
        '============================

        Txt_ExpValue_EGP.Text = Math.Round(Val(Txt_ExpValue.Text) * Val(txt_rat.Text), 2)

    End Sub

    Private Sub Txt_ExpValue_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        Txt_ExpValue_EGP.Text = Math.Round(Val(Txt_ExpValue.Text) * Val(txt_rat.Text), 2)
    End Sub

    Private Sub com_Type_SelectedIndexChanged(sender As Object, e As EventArgs)
        If com_Type.Text = "دفعة مقدمة" Then LabelX16.Visible = False : Com_InvoiceNo.Visible = False : Cmd_OpenInvoice.Visible = False Else LabelX16.Visible = True : Com_InvoiceNo.Visible = True : Cmd_OpenInvoice.Visible = True
    End Sub

    Private Sub Com_InvoiceNo_GotFocus(sender As Object, e As EventArgs)
        Fill_invoice()
    End Sub

   
    Private Sub Com_InvoiceNo_SelectedIndexChanged(sender As Object, e As EventArgs)
        sql = "   SELECT        dbo.ST_CHARTOFACCOUNT.Account_No AS Code, dbo.ST_CHARTOFACCOUNT.AccountName AS Name, dbo.ST_CHARTOFACCOUNT.Compny_Code, dbo.MovmentStatement.TypeBill,  " & _
                "                         dbo.MovmentStatement.Debit_EGP, dbo.MovmentStatement.NumberBill, dbo.MovmentStatement.DateMoveM, dbo.TB_Header_InvoiceSal.Ext_InvoiceNo " & _
                " FROM            dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
                "                         dbo.MovmentStatement ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.MovmentStatement.Compny_Code AND  " & _
                "                         dbo.ST_CHARTOFACCOUNT.Account_No = dbo.MovmentStatement.AccountNo LEFT OUTER JOIN " & _
                "                         dbo.TB_Header_InvoiceSal ON dbo.MovmentStatement.Compny_Code = dbo.TB_Header_InvoiceSal.Compny_Code AND dbo.MovmentStatement.NumberBill = dbo.TB_Header_InvoiceSal.Ser_InvoiceNo " & _
                " WHERE        (dbo.MovmentStatement.TypeBill = 2) AND (dbo.ST_CHARTOFACCOUNT.Account_No = '" & txt_AccountNo2.Text & "') and  (dbo.TB_Header_InvoiceSal.Ext_InvoiceNo = '" & Com_InvoiceNo.Text & "') and (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "') "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then lab_Invoice.Visible = True : lab_Invoice.Text = "مبلغ الفاتورة    " & rs2("Debit_EGP").Value
    End Sub

    Private Sub Cmd_OpenInvoice_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        varcode_form = 34
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.Show()
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        varcode_form = 35
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.Show()
        Fill_invoice()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        VarOpenlookup3 = 25
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub cmd_New_Click_1(sender As Object, e As EventArgs) Handles cmd_New.Click

    End Sub

    Private Sub Com_Cur_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_Cur.SelectedIndexChanged

    End Sub

    Private Sub cmd_Save_Click_1(sender As Object, e As EventArgs) Handles cmd_Save.Click

    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click

    End Sub
End Class