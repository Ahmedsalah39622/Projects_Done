Public Class Expenses
    Dim varcodeCostCenter1, varcodeCostCenter2 As String
    Private Sub cmd_New_Click(sender As Object, e As EventArgs) Handles cmd_New.Click
        Com_Expenses_No.Enabled = True
        txt_Expenses_Date.Value = Date.Now
        txt_flg.BackColor = Color.FloralWhite
        cmd_Save.Enabled = True
        txt_flg.Text = ""
        last_Data()
        clear_data()

    End Sub

    Sub fill_Expenses()
        Com_Expenses_No.Items.Clear()

        sql = " SELECT Expenses_No FROM     dbo.TB_Expenses"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Expenses_No.Items.Add(rs("Expenses_No").Value)
            rs.MoveNext()
        Loop
    End Sub


    Sub fill_OrderNo()
        Com_OrderNo.Items.Clear()
        sql = "    SELECT        Order_NO         FROM dbo.TB_Header_OrderItem"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_OrderNo.Items.Add(rs("Order_NO").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub fill_Cru()
        Com_Cur.Items.Clear()
        sql = "    SELECT  Name  FROM BD_Currency where Compny_Code = '" & VarCodeCompny & "' "
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



        sql = "SELECT        MAX(Expenses_No) AS MaxmamNo FROM dbo.TB_Expenses HAVING(MAX(Expenses_No) Is Not NULL) "

        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_Expenses_No.Text = rs("MaxmamNo").Value + 1
        Else
            Com_Expenses_No.Text = 1
            clear_data()

        End If
    End Sub
    Sub clear_data()
        'Com_Expenses_No.Text = ""
        'Com_ProjectName.Text = ""
        'Com_UnitNumber.Text = ""
        'Com_DeprtName.Text = ""
        txt_Expenses_Date.Text = ""
        txt_Name.Text = ""
        Txt_ExpValue.Text = ""
        txt_AccountNo1.Text = ""
        txt_AccountNo2.Text = ""
        txt_NameAccount1.Text = ""
        txt_NameAccount2.Text = ""
        txt_Notes.Text = ""


    End Sub

    Private Sub Frm_ReceiptCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        fill_Expenses()
        fill_CostCenterMain()
        fill_Cru()
        fill_OrderNo()
    End Sub



    Private Sub cmd_Save_Click(sender As Object, e As EventArgs) Handles cmd_Save.Click
        If Len(Com_Expenses_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_ExpValue.Text) = 0 Then MsgBox("من فضللك ادخل القيمة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo1.Text) = 0 Then MsgBox("من فضللك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo2.Text) = 0 Then MsgBox("من فضللك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '============================================
        Dim dd As DateTime = txt_Expenses_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")


        sql = "INSERT INTO TB_Expenses (Expenses_No, Expenses_Date,Id_User,Expenses_Value,Notes,AccountNo1,AccountNo2,Name,CruunceyNo,Compny_Code,Code_Salse,Order_NO) " & _
        " values  (" & Com_Expenses_No.Text & " ,'" & vardate & "','" & 1 & "','" & Txt_ExpValue.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo1.Text & "','" & txt_AccountNo2.Text & "','" & txt_Name.Text & "','" & 1 & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & Com_OrderNo.Text & "')"
        Cnn.Execute(sql)

        save_Statment()

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        last_Data()
        clear_data()
        fill_Expenses()

    End Sub
    Sub save_Statment()
        lastgl()
        Dim dd As DateTime = txt_Expenses_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '=================================Account1
        '=============رقم مركز التكلفة1
        sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo1.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        '=============================

        '=============رقم مركز التكلفة2
        sql = "  SELECT        Account_No, Account_NoCostCenter      FROM dbo.Vw_NoCostCenter    WHERE(Account_No = '" & txt_AccountNo2.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        '=============================





        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo) " & _
       " values  (N'" & Com_Expenses_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo1.Text & "',N'" & txt_Notes.Text & "',N'" & Txt_ExpValue.Text & "',N'" & 0 & "',N'" & "4" & "',N'" & "0" & "','" & Com_Expenses_No.Text & "','" & 1 & "','" & 1 & "','" & Txt_ExpValue.Text & "','" & 0 & "','" & VarCodeCompny & "','" & varcodeCostCenter1 & "' )"
        Cnn.Execute(sql)



        '=======================================================GL المدين
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  ('" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo1.Text & "','" & txt_Notes.Text & "','" & Txt_ExpValue.Text & "' ,'" & 0 & "','" & 4 & "','" & Com_Expenses_No.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter1 & "' ,'" & 1 & "','" & Txt_ExpValue.Text & "' ,'" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)



        '=================================الدائن

        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo) " & _
      " values  (N'" & Com_Expenses_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo2.Text & "',N'" & txt_Notes.Text & "',N'" & 0 & "',N'" & Txt_ExpValue.Text & "',N'" & "4" & "',N'" & "0" & "','" & Com_Expenses_No.Text & "','" & 1 & "','" & 1 & "','" & 0 & "','" & Txt_ExpValue.Text & "','" & VarCodeCompny & "','" & varcodeCostCenter2 & "' )"
        Cnn.Execute(sql)



        '=======================================================GL الدائن
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  ('" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo2.Text & "','" & txt_Notes.Text & "','" & 0 & "' ,'" & Txt_ExpValue.Text & "','" & 4 & "','" & Com_Expenses_No.Text & "','" & 1 & "','" & 1 & "','" & varcodeCostCenter2 & "' ,'" & 1 & "','" & 0 & "' ,'" & Txt_ExpValue.Text & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)




    End Sub


    Sub lastgl()
        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM dbo.Genralledger HAVING(MAX(IDGenral) Is Not Null)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub
    Private Sub Com_Expenses_No_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Expenses_No.SelectedIndexChanged

        find_data()

    End Sub
    Sub find_data()
        On Error Resume Next



        sql = "   SELECT        dbo.TB_Expenses.flg, dbo.TB_Expenses.Name, dbo.TB_Expenses.Expenses_No, dbo.TB_Expenses.Expenses_Date, dbo.TB_Expenses.Id_User, dbo.TB_Expenses.Notes, dbo.TB_Expenses.AccountNo1,  " & _
   "                         dbo.TB_Expenses.AccountNo2, dbo.TB_Expenses.Expenses_Value, dbo.ST_CHARTOFACCOUNT.AccountName, ST_CHARTOFACCOUNT_1.AccountName AS AccountName2, dbo.TB_Expenses.Compny_Code,  " & _
   "        dbo.TB_Expenses.Code_Salse, dbo.Emp_employees.Emp_Name, dbo.TB_Expenses.Order_NO, dbo.BD_Currency.Name " & _
   "FROM            dbo.TB_Expenses INNER JOIN " & _
   "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
   "                         dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Expenses.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code AND  " & _
   "                         dbo.TB_Expenses.AccountNo2 = ST_CHARTOFACCOUNT_1.Account_No LEFT OUTER JOIN " & _
   "                         dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code LEFT OUTER JOIN " & _
   "                         dbo.Emp_employees ON dbo.TB_Expenses.Code_Salse = dbo.Emp_employees.Emp_Code " & _
   " GROUP BY dbo.TB_Expenses.flg, dbo.TB_Expenses.Name, dbo.TB_Expenses.Expenses_No, dbo.TB_Expenses.Expenses_Date, dbo.TB_Expenses.Id_User, dbo.TB_Expenses.Notes, dbo.TB_Expenses.AccountNo1,  " & _
   "        dbo.TB_Expenses.AccountNo2, dbo.TB_Expenses.Expenses_Value, dbo.ST_CHARTOFACCOUNT.AccountName, ST_CHARTOFACCOUNT_1.AccountName, dbo.TB_Expenses.Compny_Code, dbo.TB_Expenses.Code_Salse, " & _
   "        dbo.Emp_employees.Emp_Name, dbo.TB_Expenses.Order_NO, dbo.BD_Currency.Name " & _
   " HAVING        (dbo.TB_Expenses.Expenses_No = '" & Com_Expenses_No.Text & "') AND (dbo.TB_Expenses.Compny_Code = '" & VarCodeCompny & "') "


        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            If rs2("flg").Value = 1 Then txt_flg.Text = "ملغى" : txt_flg.BackColor = Color.LightYellow : cmd_Save.Enabled = False
            If rs2("flg").Value = 0 Then txt_flg.Text = "مرحل" : txt_flg.BackColor = Color.FloralWhite : cmd_Save.Enabled = True

            txt_Expenses_Date.Value = rs2("Expenses_Date").Value
            Txt_ExpValue.Text = rs2("Expenses_Value").Value
            txt_Notes.Text = rs2("Notes").Value
            txt_AccountNo1.Text = rs2("AccountNo1").Value
            txt_AccountNo2.Text = rs2("AccountNo2").Value
            txt_NameAccount1.Text = rs2("AccountName").Value
            txt_NameAccount2.Text = rs2("AccountName2").Value
            txt_Name.Text = rs2("Name").Value
            Com_Cur.Text = rs2("NameCruuncey").Value
            txt_No_Salse.Text = rs2("Code_Salse").Value
            txt_Name_Salse.Text = rs2("Emp_Name").Value
            Com_OrderNo.Text = rs2("Order_NO").Value


        End If

    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click



        Dim x As String
        x = MsgBox("هل تريد الغاء السند", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Rental Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql = "UPDATE  TB_Expenses  SET flg = '" & 1 & "'  WHERE Expenses_No = " & Com_Expenses_No.Text & "  and flg ='0' and Compny_Code = '" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)



                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 4 & "' and NumberBill = " & Com_Expenses_No.Text & " and Compny_Code = '" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)

                MsgBox("تم الغاء السند ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


        End Select
    End Sub





    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        'VARTBNAME = "vw_AccountData"
        varcode_form = 36
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.Show()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        'VARTBNAME = "vw_AccountData"
        varcode_form = 37
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.Show()
    End Sub





    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'Frm_Recipt_Report.Show()
        'Frm_Recipt_Report.MdiParent = Me
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        VarOpenlookup3 = 26
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub
  
    Private Sub Com_OrderNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_OrderNo.SelectedIndexChanged

    End Sub

    Private Sub Com_GlNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_GlNo.SelectedIndexChanged

    End Sub
End Class