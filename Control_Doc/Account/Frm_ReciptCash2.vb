Imports System.Data.OleDb
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class Frm_ReciptCash2
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim varhfza, varid, varflag1 As Integer
    Dim category, Varaccount1, Varaccount2 As String
    Dim varcodeCostCenter1, varcodeCostCenter2, varaccounChekanBank1, varaccounChekanBank2 As String
    Dim varseril_No, varshowuserall As Long
    Dim VarvalueCash As Single
    Dim vardate5, Varacc1, Varacc2 As String
    Dim vardate6, varchekNo As String
    Dim varflag_TypeCust, varnohafza, varchooseAcc As Integer
    Dim vardateColected As String
    Dim vardateEda, varstatsuschek As String
    Private Sub Frm_ReciptCash2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F10 Then clear_data() : last_Data() : find_detalis()
        If e.KeyCode = Keys.F5 Then save_data()


        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 0 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 1 'الصفحة التالية
        If e.KeyCode = Keys.F3 Then TabPane1.SelectedPageIndex = 2 'الصفحة التالية
        If e.KeyCode = Keys.F4 Then TabPane1.SelectedPageIndex = 3 'الصفحة التالية


        If e.KeyCode = Keys.F12 Then  'بحث
            find_Exp()
        End If
    End Sub


    Sub get_BoxCash()
        sql = "    SELECT dbo.St_SetupBox.Account_No, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName FROM     dbo.St_SetupBox INNER JOIN    dbo.ST_CHARTOFACCOUNT ON dbo.St_SetupBox.Account_No = dbo.ST_CHARTOFACCOUNT.Account_No " & _
         " WHERE (dbo.St_SetupBox.Code_Branch = '" & varCodeBranch & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Txt_AccountNo2.Text = rs("Account_No").Value : Txt_AccountName2.Text = rs("AccountName").Value
    End Sub
    Private Sub Frm_ReciptCash2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Cru()
        fill_StatusCheck()
        'fill_Bank()
        'last_Data()
        Com_PayType.Items.Add("نقدى")
        Com_PayType.Items.Add("شيك")
        Com_PayType.Items.Add("تحويل بنكى")

        '=================================
        com_Type.Items.Add("دفعة مقدمة")
        com_Type.Items.Add("فاتورة")
        com_Type.Items.Add("اخرى")

        Com_typestatus.Items.Add("غير ملغى")
        Com_typestatus.Items.Add("ملغى")

        get_BoxCash()
        'txt_Cash.Text = Format(txt_Cash.Text, "#,##0.00")
        txt_Receipt_Date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        'last_Data()
        'clear_data()
        cmd_Save.Enabled = True : Cmd_Update.Enabled = False : Cmd_Cancle.Enabled = False : Cmd_delete.Enabled = False
    End Sub
    Sub check_data()
        'For x As Integer = 0 To GridView1.RowCount

        'For i = 0 To GridView1.RowCount
        'intRow = GridView1.GetVisibleRowHandle(x)
        'strQuantity = GridView1.GetRowCellValue(intRow, "دفعة مقدمة")

        'If strQuantity < 0 Then
        '    ' color row in red, or cell in red
        'Else
        '    ' color row in light green
        'End If
        'txt_Cash.Text = GridView1.GetRowCellValue(1, 1)
        'If GridView1.GetFocusedDisplayText = "نقدى" Then
        'Next i
    End Sub
    Sub ColorColum()
        'For x As Integer = 0 To GridView1.RowCount
        '    intRow = GridView1.GetVisibleRowHandle(x)
        '    strQuantity = GridView1.GetRowCellValue(intRow, "دفعة مقدمة")

        '    If strQuantity < 0 Then
        '        ' color row in red, or cell in red
        '    Else
        '        ' color row in light green
        '    End If

        'Next x


        'For x = 0 To GridView1.RowCount - 1
        '    category = GridView1.GetRowCellValue(x, GridView1.Columns(3))
        '    'If category Is System.DBNull.Value Then Exit Sub
        '    If category = "شيك" Then
        '        'GridView1.Appearance.FocusedRow.BackColor = Color.Green
        '        'GridView1.Appearance.FocusedRow.BackColor2 = Color.Green
        '        'GridView1.Appearance.FocusedRow.ForeColor = Color.White
        '        'GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        '        'GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        '        'GridView1.GetFocusedRow()
        '        'GridView1.Columns(3).AppearanceCell.BackColor = Color.DarkGray
        '        'GridView1.Columns(3).AppearanceCell.ForeColor = Color.Red
        '        GridView1.Appearance.SelectedRow.BackColor = Color.Black
        '        'GridView1.Appearance.FocusedRow.BackColor = Color.AliceBlue
        '    Else
        '        GridView1.Appearance.FocusedRow.BackColor = Color.White
        '        GridView1.Appearance.FocusedRow.BackColor2 = Color.White
        '        GridView1.Appearance.FocusedRow.ForeColor = Color.Black
        '        GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        '        GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        '    End If
        'Next
    End Sub
    Sub fill_Cru()
        Com_Cur.Items.Clear()
        sql = "    SELECT  Name  FROM BD_Currency where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Cur.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_StatusCheck()
        Com_status.Items.Clear()
        sql = "    SELECT  Name  FROM TB_StatusChack where flg=1 "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_status.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_StatusCheck2()
        Com_EdaStatus.Items.Clear()
        sql = "    SELECT  Name  FROM TB_StatusChack_EdA "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_EdaStatus.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

   

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VarOpenlookup3 = 25
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        If OP1.Checked = True Then
            varcode_form = 25
            VarOpenlookup2 = 25
            Frm_LookUpCustomer.Find_Customer()
            Frm_LookUpCustomer.ShowDialog()
        ElseIf OP2.Checked = True Then
            varcode_form = 41
            varchooseAcc = 0
            Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

            Frm_LookUpAccount.Show()


        ElseIf OP3.Checked = True Then
            varcode_form = 26026
            VarOpenlookup2 = 26026
            Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
            Frm_LookUpCustomer.Find_Suppliser()
            Frm_LookUpCustomer.ShowDialog()
        End If

        txt_Name.Text = txt_nameaccount.Text
       


    End Sub

    Private Sub Com_PayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_PayType.SelectedIndexChanged
        If Com_PayType.Text = "نقدى" Then
            LabelX4.Enabled = False
            Txt_CheckNo.Enabled = False
            LabelX14.Enabled = False
            txt_BankeIN.Enabled = False
            LabelX15.Enabled = False
            DateTimePicker1.Enabled = False

        ElseIf Com_PayType.Text = "تحويل بنكى" Then
            LabelX4.Enabled = False
            Txt_CheckNo.Enabled = False
            LabelX14.Enabled = False
            txt_BankeIN.Enabled = False
            LabelX15.Enabled = False
            DateTimePicker1.Enabled = False

        ElseIf Com_PayType.Text = "شيك" Then

            LabelX4.Enabled = True
            Txt_CheckNo.Enabled = True
            LabelX14.Enabled = True
            txt_BankeIN.Enabled = True
            LabelX15.Enabled = True
            DateTimePicker1.Enabled = True


        End If

        Txt_AccountNo2.Text = ""
        Txt_AccountName2.Text = ""
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Com_PayType.Text = "" Then MsgBox("من فضلك ادخل نوع الدفع  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "نقدى" Then
            varcode_form = 43
            Frm_LookUpAccount.Fill_AccBox()
            Frm_LookUpAccount.Show()

        ElseIf Com_PayType.Text = "شيك" Then
            varcode_form = 44
            Frm_LookUpAccount.Fill_AccKabd()
            Frm_LookUpAccount.Show()

        ElseIf Com_PayType.Text = "تحويل بنكى" Then
            varcode_form = 444
            Frm_LookUpAccount.Fill_ConvertBank()
            Frm_LookUpAccount.Show()


            'Vw_LookupBank()
        End If

        'varcode_form = 42
        'Frm_LookUpAccount.Fill_Acc()
        'Frm_LookUpAccount.Show()
    End Sub

    Sub lastSeril_No()
        sql = "SELECT        MAX(Serail_lNo) AS MaxmamNo FROM dbo.TB_Receipt where Compny_Code = '" & VarCodeCompny & "' and  Receipt_No='" & Com_Exp_No.Text & "' HAVING(MAX(Serail_lNo) Is Not NULL) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varseril_No = rs("MaxmamNo").Value + 1 Else varseril_No = 1
    End Sub

    Sub last_Data()
        On Error Resume Next
        If com_Type.Text = "دفعة مقدمة" Then varflag_TypeCust = 0
        If com_Type.Text = "فاتورة" Then varflag_TypeCust = 1 Else varflag_TypeCust = 0

        If Com_Exp_No.Text = "" Then Com_Exp_No.Text = 0
        sql2 = "   SELECT Receipt_No, Code_Branch      FROM dbo.TB_Receipt GROUP BY Receipt_No, Code_Branch HAVING (Receipt_No = '" & Com_Exp_No.Text & "') AND (Code_Branch = '" & varcodebranch & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
            Var_Code_Esal2 = Com_Exp_No.Text
        Else




            sql = "SELECT        MAX(Receipt_No) AS MaxmamNo FROM dbo.TB_Receipt where Compny_Code = '" & VarCodeCompny & "' AND (Code_Branch = '" & varcodebranch & "')  HAVING(MAX(Receipt_No) Is Not NULL)  "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
                Com_Exp_No.Text = rs("MaxmamNo").Value + 1
                Var_Code_Esal2 = rs("MaxmamNo").Value + 1
                'find_detalis()
            Else
                Com_Exp_No.Text = 1
                Var_Code_Esal2 = 1

            End If

        End If

        sql = "   SELECT        MAX(Hfza_No) + 1 AS MaxHfza           FROM dbo.TB_Receipt GROUP BY Receipt_No HAVING        (MAX(Hfza_No) IS NOT NULL) AND (Code_Branch = '" & varcodebranch & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varhfza = rs("MaxHfza").Value
            Var_Code_Esal2 = rs("MaxHfza").Value
        Else
            varhfza = 1
            'clear_data()

        End If

        '==================================================New

    End Sub

    Private Sub com_Type_Click(sender As Object, e As EventArgs) Handles com_Type.Click
        'last_Data()
        'LabelX16.Visible = False
        'Com_InvoiceNo.Visible = False
        'Cmd_FindInvoice.Visible = False

        If com_Type.Text = "فاتورة" Then

            'LabelX16.Visible = True
            Com_InvoiceNo.Visible = True
            Cmd_FindInvoice.Visible = True
        Else
            Com_InvoiceNo.Visible = False
            Cmd_FindInvoice.Visible = False
        End If
    End Sub







    Sub clear_data()
        Com_Exp_No.Text = ""
        txt_No_Salse.Text = ""
        txt_Receipt_Date.Text = DateTime.Now.ToString("yyyy/MM/dd")

        txt_Name_Salse.Text = ""
        txt_Cash.Text = ""
        Txt_AccountNo2.Text = ""
        Txt_AccountName2.Text = ""
        txt_Cash.Text = ""
        'txt_rat.Text = ""
        Txt_TotalBound.Text = ""
        Txt_CheckNo.Text = ""
        txt_BankeIN.Text = ""
        txt_Notes.Text = ""
        txt_Name.Text = ""
        Com_Cur.Text = "جنية مصرى"
        com_Type.Text = "دفعة مقدمة"
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        Com_InvoiceNo.Text = ""
        'com_Type.Text = ""
        txt_No_Salse.Text = varcode_User
        txt_Name_Salse.Text = varnameuser

        txt_Name.Text = txt_nameaccount.Text



    End Sub

    Private Sub Com_Cur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Cur.SelectedIndexChanged
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

        Txt_TotalBound.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 3)

    End Sub


    Private Sub Com_Exp_No_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Exp_No.ButtonClick
        find_exp()
        Cmd_delete.Enabled = False
        Cmd_Update.Enabled = False
        cmd_Save.Enabled = True
    End Sub
    Sub find_exp()
        vartable = "Vw_Lookup_Recipt"
        VarOpenlookup = 45
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        'clear_detils()
        'find_hedar()
        clear_data()
        find_hedar()
        find_detalis()
        find_all_Detils()

        Total_Sum()
    End Sub
    Private Sub Com_Exp_No_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Exp_No.EditValueChanged

    End Sub

    Sub find_hedar()
        On Error Resume Next

        sql = "SELECT      TB_Receipt.flg,TB_Receipt.Invoice_No,TB_Receipt.flg,TB_Receipt.Name, TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Receipt.AccountNo1, dbo.TB_Receipt.Code_Salse, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Type_Invoice, dbo.TB_Receipt.Notes,iif(Type_Invoice=0,'دفعة مقدمة','فاتورة') as TypeInvoice, TB_Receipt.Code_Branch " & _
        " FROM            dbo.TB_Receipt INNER JOIN  " & _
        "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN  " & _
        "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code  " & _
        " WHERE        (dbo.TB_Receipt.Receipt_No = '" & Com_Exp_No.Text & "') AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Code_Branch = '" & varcodebranch & "')  " & _
        " GROUP BY   TB_Receipt.flg,TB_Receipt.Invoice_No,TB_Receipt.flg,TB_Receipt.Name,TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName), dbo.TB_Receipt.AccountNo1, dbo.TB_Receipt.Code_Salse, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Type_Invoice, dbo.TB_Receipt.Notes, TB_Receipt.Code_Branch  "




        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Varaccount1 = Trim(rs("AccountNo1").Value)
            txt_Receipt_Date.Value = Trim(rs("Receipt_Date").Value)
            txt_nameaccount.Text = Trim(rs("AccountName").Value)
            txt_AccountNo.Text = Trim(rs("AccountNo1").Value)
            txt_No_Salse.Text = Trim(rs("Code_Salse").Value)
            txt_Name_Salse.Text = Trim(rs("Emp_Name").Value)
            com_Type.Text = Trim(rs("TypeInvoice").Value)
            txt_Notes.Text = Trim(rs("notes").Value)
            txt_Name.Text = Trim(rs("Name").Value)
            Com_InvoiceNo.Text = Trim(rs("Invoice_No").Value)

            If com_Type.Text = "دفعة مقدمة" Then Com_InvoiceNo.Visible = False : Cmd_FindInvoice.Visible = False Else Com_InvoiceNo.Visible = True : Cmd_FindInvoice.Visible = True

            'If Trim(rs("Invoice_No").Value) <> "" Then Com_InvoiceNo.Visible = True : Cmd_FindInvoice.Visible = True Else Com_InvoiceNo.Visible = False : Cmd_FindInvoice.Visible = False
            If rs("flg").Value = 0 Then Lab_flg.Text = "غير ملغى" : Lab_flg.BackColor = Color.Green
            If rs("flg").Value = 1 Then Lab_flg.Text = " ملغى" : Lab_flg.BackColor = Color.Yellow

        Else
            txt_nameaccount.Text = ""
            txt_AccountNo.Text = ""
            txt_No_Salse.Text = ""
            txt_Name_Salse.Text = ""
            com_Type.Text = ""
            txt_Name.Text = ""
        End If



    End Sub
    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If Com_Exp_No.Text = "" Then Com_Exp_No.Text = 0

        'sql2 = "SELECT       dbo.TB_Receipt.Serail_lNo, dbo.TB_Receipt.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat,                           dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA,iif( dbo.TB_Receipt.TypePay=0,'نقدى','شيك') as stutas " & _
        ' "   FROM            dbo.TB_Receipt INNER JOIN                          dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN                          dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code  " & _
        ' " WHERE        (dbo.TB_Receipt.Receipt_No = '" & Com_Exp_No.Text & "') AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "')"

        '        sql2 = " SELECT        dbo.TB_Receipt.Serail_lNo, dbo.TB_Receipt.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, " & _
        '"                         dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2 ,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay " & _
        '" FROM            dbo.TB_Receipt INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '"                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
        '"                         dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code " & _
        '" WHERE        (dbo.TB_Receipt.Compny_Code =  '" & VarCodeCompny & "') and   (dbo.TB_Receipt.Code_Branch =  '" & varcodebranch & "') AND (dbo.TB_Receipt.Receipt_No =  '" & Com_Exp_No.Text & "') "



        sql2 = "   SELECT dbo.TB_Receipt.Serail_lNo, dbo.TB_Receipt.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, " & _
   "                  dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2 ,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay, dbo.TB_Receipt.Code_CostCenter,  " & _
   "                  dbo.ST_CHARTCOSTCENTER.AccountName AS NameCostcenter " & _
   " FROM     dbo.TB_Receipt INNER JOIN " & _
   "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No_Update INNER JOIN " & _
   "                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
   "                  dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code LEFT OUTER JOIN " & _
   "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Receipt.Code_CostCenter =  dbo.ST_CHARTCOSTCENTER.Account_No_Update " & _
   " WHERE  (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Code_Branch = '" & varCodeBranch & "') AND (dbo.TB_Receipt.Receipt_No = '" & Com_Exp_No.Text & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)



        GridView6.BestFitColumns()

        GridView6.Columns(9).AppearanceCell.BackColor = Color.DarkGray
        GridView6.Columns(9).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "م"
        GridView6.Columns(1).Caption = "رقم الحساب"
        GridView6.Columns(2).Caption = "أسم الحساب "
        GridView6.Columns(3).Caption = "المبلغ"
        GridView6.Columns(4).Caption = "العملة"
        GridView6.Columns(5).Caption = "معامل التحويل"
        GridView6.Columns(6).Caption = "المبلغ بالجنية"
        GridView6.Columns(7).Caption = "رقم الشيك"
        GridView6.Columns(8).Caption = "البنك المسحوب"
        GridView6.Columns(9).Caption = "أستحقاق بتاريخ"
        GridView6.Columns(10).Caption = "نوع الدفع"
        GridView6.Columns(11).Caption = "كود مركز التكلفة"
        GridView6.Columns(12).Caption = "اسم مركز التكلفة"

        'GridView6.Columns(11).Visible = False




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Sub Total_Sum()
        'On Error Resume Next
        'Dim total As String = 0
        'For i As Integer = 0 To GridView6.RowCount - 1
        '    total += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(6)))
        'Next
        'txt_TotalEsal.Text = total
        ''txt_Tax.Text = Math.Round(Val(txt_totalPrice.Text) * vartaxinvoice / 100, 2)
        ''Txt_TotalAll.Text = total + Val(txt_Tax.Text)
    End Sub



    Sub Find_Data()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
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



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "     SELECT        dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, iif(dbo.TB_Receipt.TypePay=0,'نقدى','شيك') as Type, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, " & _
    "                         dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN, dbo.TB_Receipt.Date_Asthkak, dbo.Emp_employees.Emp_Name, dbo.TB_Receipt.Notes, iif(dbo.TB_Receipt.Type_Invoice=2,'فاتورة','دفعة مقدمة') as Type2,dbo.TB_Receipt.UserID " & _
    " FROM            dbo.TB_Receipt INNER JOIN " & _
    "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
    "                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
    "                         dbo.Emp_employees ON dbo.TB_Receipt.Code_Salse = dbo.Emp_employees.Emp_Code " & _
    " WHERE        (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) and   (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and  (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "')  and TB_Receipt.Code_Branch = '" & varCodeBranch & "' and dbo.TB_Receipt.UserID ='" & varcode_User & "' "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "70"
        'GridView1.Columns(2).Width = "100"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"
        'GridView1.Columns(11).Width = "130"
        'GridView1.Columns(12).Width = "150"
        'GridView1.Columns(13).Width = "130"

        GridView6.BestFitColumns()

        'GridView6.Columns(6).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(6).AppearanceCell.ForeColor = Color.Red

        'GridView6.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(7).AppearanceCell.ForeColor = Color.Red


        'GridView6.Columns(9).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(9).AppearanceCell.ForeColor = Color.Red

        'GridView6.Columns(10).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(10).AppearanceCell.ForeColor = Color.Red


        GridView1.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم السند"
        GridView1.Columns(1).Caption = "ناريخ السند "
        GridView1.Columns(2).Caption = "أسم الحساب"
        GridView1.Columns(3).Caption = "نوع الدفع"
        GridView1.Columns(4).Caption = "المبلغ"
        GridView1.Columns(5).Caption = "العملة"
        GridView1.Columns(6).Caption = "معامل التحويل"
        GridView1.Columns(7).Caption = "الاجمالى"
        GridView1.Columns(8).Caption = "رقم الشيك"
        GridView1.Columns(9).Caption = "مسحوب على"
        GridView1.Columns(10).Caption = "أستحقاق"
        GridView1.Columns(11).Caption = "أسم المندوب"
        GridView1.Columns(12).Caption = "البيان"
        GridView1.Columns(13).Caption = "نوع الدفعة"
        GridView1.Columns(14).Caption = "رقم المستخدم"




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Sub Find_Hafza()
        On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date3.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date3.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date4.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date4.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        ''      sql2 = "  SELECT dbo.TB_HafzaRecipt.Hfza_No, dbo.TB_HafzaRecipt.Receipt_No, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Bank_IN, dbo.TB_Receipt.Date_Asthkak, iif(dbo.TB_HafzaRecipt.Date_Colacted='1900-01-01',dbo.TB_HafzaRecipt.Date_Colacted2,dbo.TB_HafzaRecipt.Date_Colacted) as datecolected, " & _
        '"                  ST_CHARTOFACCOUNT_1.AccountName, dbo.TB_StatusChack.Name,  iif(dbo.TB_HafzaRecipt.Date_Ada='1900-01-01',dbo.TB_HafzaRecipt.Date_Ada2,dbo.TB_HafzaRecipt.Date_Ada) as dateada, dbo.ST_CHARTOFACCOUNT.AccountName AS NameAccountCheck,dbo.TB_HafzaRecipt.AccountNoChek,dbo.TB_HafzaRecipt.AccountNoBank " & _
        '" FROM     dbo.TB_Receipt INNER JOIN " & _
        '"                  dbo.TB_HafzaRecipt ON dbo.TB_Receipt.Hfza_No = dbo.TB_HafzaRecipt.Hfza_No AND dbo.TB_Receipt.Receipt_No = dbo.TB_HafzaRecipt.Receipt_No AND dbo.TB_Receipt.Compny_Code = dbo.TB_HafzaRecipt.Compny_Code AND  " & _
        '"                  dbo.TB_Receipt.Check_No = dbo.TB_HafzaRecipt.Check_No AND dbo.TB_Receipt.Code_Branch = dbo.TB_HafzaRecipt.code_branch INNER JOIN " & _
        '"                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_HafzaRecipt.AccountNoChek = ST_CHARTOFACCOUNT.Account_No_Update  LEFT OUTER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_HafzaRecipt.AccountNoBank = ST_CHARTOFACCOUNT_1.Account_No_Update AND  " & _
        '"                  dbo.TB_HafzaRecipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code LEFT OUTER JOIN " & _
        '"                  dbo.TB_StatusChack ON dbo.TB_HafzaRecipt.Flg_Stutascheck = dbo.TB_StatusChack.Code LEFT OUTER JOIN " & _
        '"                  dbo.TB_StatusChack_EdA ON dbo.TB_HafzaRecipt.Flg_Stutas = dbo.TB_StatusChack_EdA.Code " & _
        '" WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaRecipt.Compny_Code = '" & VarCodeCompny & "')  "

        sql2 = "  SELECT dbo.TB_HafzaRecipt.Hfza_No, dbo.TB_HafzaRecipt.Receipt_No, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Bank_IN, dbo.TB_Receipt.Date_Asthkak,  iif(dbo.TB_HafzaRecipt.Date_Colacted='1900-01-01',dbo.TB_HafzaRecipt.Date_Colacted2,dbo.TB_HafzaRecipt.Date_Colacted) as datecolected,                   ST_CHARTOFACCOUNT_1.AccountName, dbo.TB_StatusChack.Name,  iif(dbo.TB_HafzaRecipt.Date_Ada='1900-01-01',dbo.TB_HafzaRecipt.Date_Ada2,dbo.TB_HafzaRecipt.Date_Ada) as dateada " & _
  "                 , ST_CHARTOFACCOUNT_2.AccountName AS NameAccountCheck, dbo.TB_HafzaRecipt.AccountNoChek, dbo.TB_HafzaRecipt.AccountNoBank, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS acc3 " & _
  " FROM     dbo.TB_Receipt INNER JOIN " & _
  "                  dbo.TB_HafzaRecipt ON dbo.TB_Receipt.Hfza_No = dbo.TB_HafzaRecipt.Hfza_No AND dbo.TB_Receipt.Receipt_No = dbo.TB_HafzaRecipt.Receipt_No AND dbo.TB_Receipt.Compny_Code = dbo.TB_HafzaRecipt.Compny_Code AND  " & _
  "                  dbo.TB_Receipt.Check_No = dbo.TB_HafzaRecipt.Check_No AND dbo.TB_Receipt.Code_Branch = dbo.TB_HafzaRecipt.Code_Branch INNER JOIN " & _
  "                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No_Update LEFT OUTER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_2 ON dbo.TB_HafzaRecipt.AccountNoChek = ST_CHARTOFACCOUNT_2.Account_No_Update LEFT OUTER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_HafzaRecipt.AccountNoBank = ST_CHARTOFACCOUNT_1.Account_No_Update AND  " & _
  "                  dbo.TB_HafzaRecipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code LEFT OUTER JOIN " & _
  "                  dbo.TB_StatusChack ON dbo.TB_HafzaRecipt.Flg_Stutascheck = dbo.TB_StatusChack.Code LEFT OUTER JOIN " & _
  "                  dbo.TB_StatusChack_EdA ON dbo.TB_HafzaRecipt.Flg_Stutas = dbo.TB_StatusChack_EdA.Code " & _
  " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaRecipt.Compny_Code = '1') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)




        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.BestFitColumns()

        GridView3.Columns(0).Caption = "رقم الحافظة"
        GridView3.Columns(1).Caption = "رقم السند "
        GridView3.Columns(2).Caption = "المبلغ "
        GridView3.Columns(3).Caption = "رقم الشيك"
        GridView3.Columns(4).Caption = "تاريخ الاستلام"
        GridView3.Columns(5).Caption = "البنك المسحوب عليه"
        GridView3.Columns(6).Caption = "تاريخ الاستحقاق"
        GridView3.Columns(7).Caption = "تاريخ التحصيل"
        GridView3.Columns(8).Caption = "أسم الحساب"
        GridView3.Columns(9).Caption = "نوع الحركة"
        GridView3.Columns(10).Caption = "تاريخ الايداع"
        GridView3.Columns(11).Caption = "أسم الحساب"
        GridView3.Columns(12).Caption = "رقم الحساب"
        GridView3.Columns(13).Caption = "أسم الحساب الاخر"
        GridView3.Columns(14).Caption = "اسم الحساب"

        'GridView3.Columns(12).Visible = False
        'GridView3.Columns(13).Visible = False



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub


    Sub find_all_Data()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
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




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If Com_typestatus.Text = "غير ملغى" Then
            'sql2 = "     SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, SUM(dbo.TB_Receipt.Receipt_Value_EGP) AS SumEgp, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName,iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg, dbo.TB_Receipt.UserID, " & _
            '      "                 dbo.Genralledger.IDGenral, dbo.ST_CHARTCOSTCENTER.AccountName AS NameCostCenter " & _
            '     " FROM     dbo.TB_Receipt INNER JOIN " & _
            '     "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
            '     "                  dbo.Genralledger ON dbo.TB_Receipt.Receipt_No = dbo.Genralledger.No_Sand AND dbo.TB_Receipt.Code_Branch = dbo.Genralledger.Code_Sub LEFT OUTER JOIN " & _
            '     "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Receipt.Code_CostCenter = dbo.ST_CHARTCOSTCENTER.Account_No_Update " & _
            '     " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Code_Branch = '" & varCodeBranch & "')  and TB_Receipt.flg = 0  " & _
            '     "                  AND (dbo.Genralledger.Typebill = 3) AND (dbo.Genralledger.flgcancle = 0) " & _
            '     " GROUP BY dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.ST_CHARTOFACCOUNT.AccountName,dbo.TB_Receipt.flg, dbo.TB_Receipt.UserID, dbo.Genralledger.IDGenral, dbo.ST_CHARTCOSTCENTER.AccountName "


            sql2 = "      SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Receipt_Value_EGP AS SumEgp, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName,iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg, dbo.TB_Receipt.UserID, dbo.Genralledger.IDGenral, " & _
      "                  dbo.ST_CHARTCOSTCENTER.AccountName AS NameCostCenter " & _
      " FROM     dbo.TB_Receipt INNER JOIN " & _
      "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
      "                  dbo.Genralledger ON dbo.TB_Receipt.Receipt_No = dbo.Genralledger.No_Sand AND dbo.TB_Receipt.Code_Branch = dbo.Genralledger.Code_Sub AND dbo.TB_Receipt.AccountNo1 = dbo.Genralledger.CodeLevel4 LEFT OUTER JOIN " & _
      "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Receipt.Code_CostCenter = dbo.ST_CHARTCOSTCENTER.Account_No_Update " & _
      " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Code_Branch = '" & varCodeBranch & "') " & _
      "                  AND (dbo.TB_Receipt.flg = 0) AND (dbo.Genralledger.Typebill = 3) AND (dbo.Genralledger.flgcancle = 0)  "
        End If

        If Com_typestatus.Text = "ملغى" Then
            sql2 = "      SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Receipt_Value_EGP AS SumEgp, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName,iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg, dbo.TB_Receipt.UserID, dbo.Genralledger.IDGenral, " & _
  "                  dbo.ST_CHARTCOSTCENTER.AccountName AS NameCostCenter " & _
  " FROM     dbo.TB_Receipt INNER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
  "                  dbo.Genralledger ON dbo.TB_Receipt.Receipt_No = dbo.Genralledger.No_Sand AND dbo.TB_Receipt.Code_Branch = dbo.Genralledger.Code_Sub AND dbo.TB_Receipt.AccountNo1 = dbo.Genralledger.CodeLevel4 LEFT OUTER JOIN " & _
  "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Receipt.Code_CostCenter = dbo.ST_CHARTCOSTCENTER.Account_No_Update " & _
  " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_Receipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Code_Branch = '" & varCodeBranch & "') " & _
  "                  AND (dbo.TB_Receipt.flg = 1) AND (dbo.Genralledger.Typebill = 3) AND (dbo.Genralledger.flgcancle = 0)  "

        End If



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        'GridView1.Columns(4).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(4).AppearanceCell.ForeColor = Color.Red

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم الايصال"
        GridView1.Columns(1).Caption = "تاريخ الايصال"
        GridView1.Columns(2).Caption = "إجمالى الايصال"
        GridView1.Columns(3).Caption = "أسم الحساب "
        GridView1.Columns(4).Caption = "الحالة"
        GridView1.Columns(5).Caption = "رقم المستخدم"
        GridView1.Columns(6).Caption = "رقم القيد"
        GridView1.Columns(7).Caption = "مركز التكلفة"


        GridView1.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Sub chekUser()
        'sql = "  SELECT  Code_Branch, Compny_Code, Account_No        FROM dbo.St_SetupBox     "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varshowuserall = rs("ShowAllUser").Value
    End Sub
    Sub find_all_Detils()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
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


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        ' sql = "   SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, RTRIM(ST_CHARTOFACCOUNT_1.AccountName) AS AccountName2,  " & _
        '"                  dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No, dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay, iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg ,dbo.TB_Receipt.UserID " & _
        '" FROM     dbo.TB_Receipt INNER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '"                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
        '"                  dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code INNER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Receipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code AND dbo.TB_Receipt.AccountNo1 = ST_CHARTOFACCOUNT_1.Account_No " & _
        '" WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME,'" & vardate2 & "', 102)) AND (dbo.TB_Receipt.Compny_Code = '1')  "
 

        If Com_typestatus.Text = "غير ملغى" Then

            sql = "    SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, RTRIM(dbo.TB_Receipt.AccountNo1) AS AccountNo1, RTRIM(ST_CHARTOFACCOUNT_1.AccountName)  " & _
        "                  AS AccountName2, RTRIM(ST_CHARTOFACCOUNT_2.AccountName) AS Type_Customer, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No,   " & _
        "                  dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay, iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg, dbo.TB_Receipt.UserID  " & _
        " FROM     dbo.TB_Receipt INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN  " & _
        "                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN  " & _
        "                  dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Receipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code AND dbo.TB_Receipt.AccountNo1 = ST_CHARTOFACCOUNT_1.Account_No INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_2 ON ST_CHARTOFACCOUNT_1.Level_No2 = ST_CHARTOFACCOUNT_2.Account_No_Update  " & _
        " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and TB_Receipt.flg=0  "


        End If

        If Com_typestatus.Text = "ملغى" Then

            sql = "    SELECT dbo.TB_Receipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, RTRIM(dbo.TB_Receipt.AccountNo1) AS AccountNo1, RTRIM(ST_CHARTOFACCOUNT_1.AccountName)  " & _
        "                  AS AccountName2, RTRIM(ST_CHARTOFACCOUNT_2.AccountName) AS Type_Customer, dbo.TB_Receipt.Receipt_Value, dbo.BD_Currency.Name, dbo.TB_Receipt.rat, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_Receipt.Check_No,   " & _
        "                  dbo.TB_Receipt.Bank_IN,iif( dbo.TB_Receipt.TypePay=0 or dbo.TB_Receipt.TypePay=2,dbo.TB_Receipt.Date_Asthkak2,dbo.TB_Receipt.Date_Asthkak) as DateA, dbo.TB_Type_Pay.Name AS Type_pay, iif( dbo.TB_Receipt.flg=1,'ملغى','غير ملغى') as Flg, dbo.TB_Receipt.UserID  " & _
        " FROM     dbo.TB_Receipt INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN  " & _
        "                  dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN  " & _
        "                  dbo.TB_Type_Pay ON dbo.TB_Receipt.TypePay = dbo.TB_Type_Pay.Code INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Receipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code AND dbo.TB_Receipt.AccountNo1 = ST_CHARTOFACCOUNT_1.Account_No INNER JOIN  " & _
        "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_2 ON ST_CHARTOFACCOUNT_1.Level_No2 = ST_CHARTOFACCOUNT_2.Account_No_Update  " & _
        " WHERE  (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and TB_Receipt.flg=1  "


        End If



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم السند"
        GridView1.Columns(1).Caption = "تاريخ السند"
        GridView1.Columns(2).Caption = "من حساب"
        GridView1.Columns(3).Caption = "رقم حساب"
        GridView1.Columns(4).Caption = "الى الحساب "
        GridView1.Columns(5).Caption = "الحساب الرئيسى"
        GridView1.Columns(6).Caption = "المبلغ"
        GridView1.Columns(7).Caption = "العملة"
        GridView1.Columns(8).Caption = "معامل التحويل"
        GridView1.Columns(9).Caption = "المبلغ بالجنية"
        GridView1.Columns(10).Caption = "رقم الشيك"
        GridView1.Columns(11).Caption = "البنك المسحوب"
        GridView1.Columns(12).Caption = "أستحقاق بتاريخ"
        GridView1.Columns(13).Caption = "نوع الدفع"
        GridView1.Columns(14).Caption = "الحالة"
        GridView1.Columns(15).Caption = "رقم المستخدم"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Find_Hafza()
    End Sub



    Private Sub cmd_Save_Click(sender As Object, e As EventArgs)
        save_data()
    End Sub
    Sub save_data()
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If



        '============================================تاريخ السند
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '==================================تاريخ الاستحقاق
        Dim dd2 As DateTime = DateTimePicker1.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================


        Dim VarType, VarType2 As Integer
        If com_Type.Text = "فاتورة" Then VarType = 0
        If com_Type.Text = "دفعة مقدمة" Then VarType = 1
        If Com_PayType.Text = "نقدى" Then VarType2 = 0
        If Com_PayType.Text = "شيك" Then VarType2 = 1


        '=================================================ChekSerilNo
        sql2 = "select * from TB_Receipt WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then MsgBox("من فضلك هذة الدفعة مضافه من قبل على نفس الايصال من فضلك تأكد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        '============================CheckNoRecipt
        sql2 = "select * from TB_Receipt where Receipt_No='" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
        Else
            last_Data()
        End If


        lastSeril_No()

        If Com_PayType.Text = "نقدى" Then
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay) " & _
            " values  ('" & varseril_No & "'," & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "')"
            Cnn.Execute(sql)
        Else
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Hfza_No) " & _
            " values  ('" & varseril_No & "'," & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & varhfza & "')"
            Cnn.Execute(sql)
            '====================================================save Hafza

            sql = "INSERT INTO TB_HafzaRecipt (Serail_lNo,Hfza_No,Receipt_No, Check_No,Compny_Code) " & _
            " values  ('" & varseril_No & "'," & varhfza & ",'" & Com_Exp_No.Text & "','" & Txt_CheckNo.Text & "' ,'" & VarCodeCompny & "')"
            Cnn.Execute(sql)
            '====================================================================
        End If


        save_Statment()

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'last_Data()
        clear_data()
        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub
    Sub save_File()
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If



        '============================================تاريخ السند
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '==================================تاريخ الاستحقاق
        Dim dd2 As DateTime = DateTimePicker1.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")





        Dim VarType, VarType2 As Integer
        If com_Type.Text = "فاتورة" Then VarType = 0
        If com_Type.Text = "دفعة مقدمة" Then VarType = 1
        If Com_PayType.Text = "نقدى" Then VarType2 = 0
        If Com_PayType.Text = "شيك" Then VarType2 = 1



        '============================CheckNoRecipt
        sql2 = "select * from TB_Receipt where Receipt_No='" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
        Else
            last_Data()
        End If


        lastSeril_No()

        If Com_PayType.Text = "نقدى" Then
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay) " & _
            " values  ('" & varseril_No & "'," & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "')"
            Cnn.Execute(sql)
        Else
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Hfza_No) " & _
            " values  ('" & varseril_No & "'," & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & varhfza & "')"
            Cnn.Execute(sql)
            '====================================================save Hafza

            sql = "INSERT INTO TB_HafzaRecipt (Serail_lNo,Hfza_No,Receipt_No, Check_No,Compny_Code) " & _
            " values  ('" & varseril_No & "'," & varhfza & ",'" & Com_Exp_No.Text & "','" & Txt_CheckNo.Text & "' ,'" & VarCodeCompny & "')"
            Cnn.Execute(sql)
            '====================================================================
        End If


        save_Statment()

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'last_Data()
        clear_data()
        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub


    Sub save_Update()
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Name.Text) = 0 Then MsgBox("من فضلك ادخل اسم المستلم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If

        If Txt_CheckNo.Text = "" Then
        Else
            'sql = "  SELECT        Hfza_No , Receipt_No, Check_No   FROM dbo.TB_HafzaRecipt WHERE       (Check_No = '" & Txt_CheckNo.Text & "') and code_branch ='" & varCodeBranch & "' "
            'rs = Cnn.Execute(sql)
            'If rs.EOF = False Then MsgBox("رقم الشيك متكرر  على ايصال سابقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        End If



        'sql = "  SELECT        Hfza_No , Receipt_No, Check_No   FROM dbo.TB_HafzaRecipt WHERE        (Hfza_No = '" & varseril_No & "') AND (Receipt_No = " & Com_Exp_No.Text & ") AND (Check_No = '" & varchekNo & "') and code_branch ='" & varCodeBranch & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("رقم الشيك متكرر على نفس الايصال من فضلك تاكد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub



        '============================================تاريخ السند
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '==================================تاريخ الاستحقاق
        Dim dd2 As DateTime = DateTimePicker1.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")





        Dim VarType, VarType2 As Integer


        '============================CheckNoRecipt
        'sql2 = "select * from TB_Receipt where Receipt_No='" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs2 = Cnn.Execute(sql2)
        'If rs2.EOF = False Then
        'Else
        last_Data()
        'End If
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================

        lastSeril_No()


        'If Lable_Type.Text = "عملاء محلية 1" Then varflag_TypeCust = 0
        'If Lable_Type.Text = "عملاء محلية 2" Then varflag_TypeCust = 1
        'If Lable_Type.Text = "" Then varflag_TypeCust = 1

        If com_Type.Text = "فاتورة" Then VarType = 1
        If com_Type.Text = "دفعة مقدمة" Then VarType = 0
        If com_Type.Text = "اخرى" Then VarType = 2
        '===================================================================
        If Com_PayType.Text = "نقدى" Then VarType2 = 0
        If Com_PayType.Text = "شيك" Then VarType2 = 1
        If Com_PayType.Text = "تحويل بنكى" Then VarType2 = 2






        If Com_PayType.Text = "نقدى" Or Com_PayType.Text = "تحويل بنكى" Then
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Name,UserID,Code_Branch,Code_CostCenter) " & _
            " values  ('" & varseril_No & "'," & Var_Code_Esal2 & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & txt_Name.Text & "','" & varcode_User & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "')"
            Cnn.Execute(sql)



            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','3','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Var_Code_Esal2 & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================
        Else
            sql = "INSERT INTO TB_Receipt (Serail_lNo,Receipt_No, Receipt_Date,Id_User,Receipt_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Receipt_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Hfza_No,Name,UserID,Code_Branch,Code_CostCenter) " & _
            " values  ('" & varseril_No & "'," & Var_Code_Esal2 & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & Com_Exp_No.Text & "','" & txt_Name.Text & "','" & varcode_User & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "')"
            Cnn.Execute(sql)
            '====================================================save Hafza

            sql = "INSERT INTO TB_HafzaRecipt (Serail_lNo,Hfza_No,Receipt_No, Check_No,Compny_Code,Code_Branch) " & _
            " values  ('" & varseril_No & "'," & Com_Exp_No.Text & ",'" & Var_Code_Esal2 & "','" & Txt_CheckNo.Text & "' ,'" & VarCodeCompny & "','" & varcodebranch & "')"
            Cnn.Execute(sql)
            '====================================================================

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','3','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Var_Code_Esal2 & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================
        End If


        save_Statment()




        MsgBox("تم الحفظ " + "برقم سند " & " " & Var_Code_Esal2, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


        'last_Data()
        clear_data()
        Com_Exp_No.Text = Var_Code_Esal2
        find_hedar()
        find_detalis()
        Total_Sum()

    End Sub
    Sub save_Statment()
        lastgl()
        Dim dd As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '=================================Account1

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value


        '=======================================================GL المدين
        sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Txt_AccountNo2.Text & "','" & txt_Notes.Text & "','" & txt_Cash.Text & "' ,'" & 0 & "','" & 3 & "','" & Var_Code_Esal2 & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & Txt_TotalBound.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)
        '=======================================================GL الدائن
        sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo.Text & "','" & txt_Notes.Text & "','" & 0 & "' ,'" & txt_Cash.Text & "','" & 3 & "','" & Var_Code_Esal2 & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Txt_TotalBound.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)



        sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
            " values  (N'" & varseril_No & "',N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & Txt_AccountNo2.Text & "',N'" & txt_Notes.Text & "',N'" & txt_Cash.Text & "',N'" & 0 & "',N'" & "3" & "',N'" & "0" & "','" & Var_Code_Esal2 & "','" & varcodebranch & "','" & varcode_Cru & "','" & Txt_TotalBound.Text & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
        Cnn.Execute(sql)

        '=================================الدائن

        sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
      " values  (N'" & varseril_No & "',N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo.Text & "',N'" & txt_Notes.Text & "',N'" & 0 & "',N'" & txt_Cash.Text & "',N'" & "3" & "',N'" & "0" & "','" & Var_Code_Esal2 & "','" & varcodebranch & "','" & varcode_Cru & "','" & 0 & "','" & Txt_TotalBound.Text & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
        Cnn.Execute(sql)



    End Sub


    Sub lastgl()
        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM  dbo.Genralledger where Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' HAVING(MAX(IDGenral) Is Not Null) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub



    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'GridView3.ShowPrintPreview()


        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView3.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle


            Dim var7, var8, var9, var10 As String
            var7 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(7))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(7))))
            var8 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(8))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(8))))
            var9 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(9))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(9))))
            var10 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(10))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(10))))


            sql2 = "insert into TB_TempReport1  (No_Hfza,No_Sand,Value_cash" & _
                " ,No_Check,Date_M,BankMshob,DateAtt,Date_Collect,AccountName,TypeMove,DateEda3) " & _
                " values ('" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(0))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(1))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(2))) & "' " & _
                " ,'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(3))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(4))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(5))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(6))) & "','" & var7 & "','" & var8 & "','" & var9 & "','" & var10 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Recipt = 3
        Rpt_Recipt1.Show()
    End Sub






    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ColorColum()

    End Sub








    Private Sub Cmd_delete_Click(sender As Object, e As EventArgs)

    End Sub
    Sub delete_File()

        'Dim varcount As Integer

        'If GridView1.RowCount = 1 Then MsgBox("سيتم الغاء الايصال فقط", MsgBoxStyle.Information, "Css Solution Software Module")



        sql = "Delete TB_Receipt  WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Branch ='" & varcode_Branch & "' "
        rs = Cnn.Execute(sql)




        'sql = "UPDATE   Genralledger   SET flgcancle = '" & 1 & "' WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varcode_Branch & "'  "
        'rs = Cnn.Execute(sql)


        sql = "Delete Genralledger  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "'  and  No_serail ='" & varid & "'  "
        rs = Cnn.Execute(sql)



        sql = "Delete MovmentStatement  WHERE Typebill ='" & 3 & "' and No_Sand = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varcode_Branch & "' and  Serail_lNo ='" & varid & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete TB_HafzaRecipt  WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Check_No ='" & Txt_CheckNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Code_Branch ='" & varcode_Branch & "' "
        rs = Cnn.Execute(sql)

        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','3','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        'save_all_GL()

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        find_hedar()
        find_detalis()
        Total_Sum()

    End Sub
    Sub delete_Update()

        'Dim varcount As Integer

        'If GridView1.RowCount = 1 Then MsgBox("سيتم الغاء الايصال فقط", MsgBoxStyle.Information, "Css Solution Software Module")



        sql = "Delete TB_Receipt  WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Branch ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete Genralledger  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete MovmentStatement  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)



        find_detalis()
        Total_Sum()

    End Sub

    Private Sub txt_Cash_TextChanged(sender As Object, e As EventArgs) Handles txt_Cash.TextChanged
        On Error Resume Next
        Txt_TotalBound.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 3)

    End Sub



    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        check_data()
    End Sub



    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'If RadioButton1.Checked = True Then
        clear_data()
        Com_Exp_No.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        find_hedar()
        find_detalis()
        Total_Sum()
        TabPane1.SelectedPageIndex = 0
        'End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click


        If Com_status.Text = "" Then MsgBox("من فضلك ادخل حركة الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_status.Text = "ايداع بالبنك" Then
            varcode_form = 51
            Frm_LookUpAccount.Fill_AccChek()
            Frm_LookUpAccount.Show()

        ElseIf Com_status.Text = "تحصيل" Then
            varcode_form = 50
            Frm_LookUpAccount.Fill_Acc()
            Frm_LookUpAccount.Show()

        ElseIf Com_status.Text = "ايداع للمورد" Then
            varcode_form = 5001
            Frm_LookUpAccount.Fill_Acc()
            Frm_LookUpAccount.Show()

        ElseIf Com_status.Text = "ارتجاع شيك" Then
            varcode_form = 500
            Frm_LookUpAccount.Fill_Customer()
            Frm_LookUpAccount.Show()
        End If


    End Sub


    Private Sub Com_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_status.SelectedIndexChanged
        Txt_AccountNoBank.Text = ""
        Txt_AccountNameBank.Text = ""

        If varstatsuschek = "تحصيل" And Com_status.Text = "ارتجاع شيك" Then MsgBox("غير متاح اختيار ارتجاع الشيك حالة الشيك تحصيل", MsgBoxStyle.Critical, "Cerative smart software") : Exit Sub

        If Com_status.Text = "تحصيل" Then txt_EdaDate.Enabled = False : txt_TahselDate.Enabled = True Else txt_EdaDate.Enabled = True : txt_TahselDate.Enabled = False
        If Com_status.Text = "ايداع بالبنك" Then txt_EdaDate.Enabled = True : txt_TahselDate.Enabled = False : fill_StatusCheck2() Else txt_EdaDate.Enabled = False : txt_TahselDate.Enabled = True

    End Sub

    Private Sub TextBox2_DoubleClick(sender As Object, e As EventArgs) Handles txt_EdaDate.DoubleClick
        'CalendarControl1.Visible = True

    End Sub




    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        txt_AccountNo.Text = ""
        Txt_AccountNameBank.Text = ""
        txt_EdaDate.Text = ""
        txt_TahselDate.Text = ""

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle


        If GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9)) <> "" Then varstatsuschek = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))



        If txt_TahselDate.Text <> "" Then txt_TahselDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))
        If txt_EdaDate.Text <> "" Then txt_EdaDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))
        varnohafza = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        VarvalueCash = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))

        txt_FindCheck.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        Txt_AccountNameBank.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))
        Com_status.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))

        If Com_status.Text = "ايداع بالبنك" Then
            Txt_AccountNoBank.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(12))
            Txt_AccountNameBank.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(11))
            If GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10)) <> "" Then txt_EdaDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))
        Else
            Txt_AccountNoBank.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(13))
            Txt_AccountNameBank.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))
            txt_TahselDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))
            If GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10)) <> "" Then txt_EdaDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))

        End If

        If txt_EdaDate.Text <> "" Then txt_EdaDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))
        If txt_TahselDate.Text <> "" Then txt_TahselDate.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))





        clear_data()
        Com_Exp_No.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))

        find_hedar()
        find_detalis()
        Total_Sum()
        TabPane1.SelectedPageIndex = 0

        Find_StatusCheck()
    End Sub




    Private Sub txt_TahselDate_DoubleClick(sender As Object, e As EventArgs)
        'CalendarControl2.Visible = True

    End Sub



    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        'CalendarControl1.Visible = False
        'CalendarControl2.Visible = False
    End Sub


    Sub Find_StatusCheck()
        sql = "   SELECT        Check_No, Flg_Stutascheck        FROM dbo.TB_HafzaRecipt WHERE        (Flg_Stutascheck = 1) AND (Check_No = '" & txt_FindCheck.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            Com_status.Enabled = False : SimpleButton5.Enabled = False : txt_EdaDate.Enabled = False : Com_EdaStatus.Enabled = False : Cmd_SaveChek.Enabled = False
        Else
            Com_status.Enabled = True : SimpleButton5.Enabled = True : txt_EdaDate.Enabled = True : Com_EdaStatus.Enabled = True : Cmd_SaveChek.Enabled = True
        End If
    End Sub

    Private Sub CalendarControl1_OkClick(sender As Object, e As EventArgs)
        'txt_EdaDate.Text = CalendarControl1.EditValue
        'CalendarControl1.Visible = False
    End Sub

    Private Sub CalendarControl2_OkClick(sender As Object, e As EventArgs)
        'txt_TahselDate.Text = CalendarControl1.EditValue
        'CalendarControl2.Visible = False
    End Sub

    Private Sub GridControl3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmd_Save_Click_1(sender As Object, e As EventArgs) Handles cmd_Save.Click
        'Dim dd As DateTime = txt_Receipt_Date.Value
        'Dim vardate As String
        'vardate = dd.ToString("dd/MM/yyyy")

        'Dim dd2 As DateTime = var_GetDateLive
        'Dim vardate2 As String
        'vardate2 = dd2.ToString("MM/dd/yyyy")
        'If vardate2 <> vardate Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub


        save_Update()
    End Sub
    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & _
            "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function
    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        On Error Resume Next


        'last_Data()
        clear_data()
        get_BoxCash()
        find_detalis()

        cmd_Save.Enabled = True : Cmd_Update.Enabled = False : Cmd_Cancle.Enabled = False : Cmd_delete.Enabled = False
        'lastSeril_No()

        'txt_Notes.Text = ""
        'txt_AccountNo.Text = ""
        'txt_nameaccount.Text = ""

        'Total_Sum()
        'sql2 = "select * from TB_Receipt WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "'  "
        'rs2 = Cnn.Execute(sql2)
        'If rs2.EOF = True Then cmd_Save.Enabled = True : Cmd_delete.Enabled = False : Cmd_Cancle.Enabled = False
    End Sub

    Private Sub Cmd_Edit_Click(sender As Object, e As EventArgs)
        'Dim VarTypepay As Integer
        'If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'If varid = 0 Then MsgBox("من فضلك أختار سطر التعديل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        'Dim dd As DateTime = txt_Receipt_Date.Value
        'Dim vardate As String
        'vardate = dd.ToString("MM-d-yyyy")


        'Dim dd2 As DateTime = DateTimePicker1.Value
        'Dim vardate2 As String
        'vardate2 = dd2.ToString("MM-d-yyyy")

        ''========================================================رقم العملة
        'sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_Cru = rs("code").Value

        'If Com_PayType.Text = "نقدى" Then VarTypepay = 0
        'If Com_PayType.Text = "شيك" Then VarTypepay = 1

        'sql = "UPDATE  TB_Receipt  SET Receipt_Date ='" & vardate & "', AccountNo2 ='" & Txt_AccountNo2.Text & "',Notes ='" & txt_Notes.Text & "',Receipt_Value ='" & txt_Cash.Text & "' , Receipt_Value_EGP ='" & Txt_TotalBound.Text & "',CruunceyNo ='" & varcode_Cru & "' , rat ='" & txt_rat.Text & "',Bank_IN ='" & txt_BankeIN.Text & "',Date_Asthkak ='" & vardate2 & "' ,TypePay ='" & VarTypepay & "',Check_No ='" & Txt_CheckNo.Text & "',AccountNo1 ='" & txt_AccountNo.Text & "' WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)


        ''=============رقم مركز التكلفة1
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & txt_AccountNo.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================

        ''=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & Txt_AccountNo2.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        ''=============================


        ''======================================تعديل رقم القيد
        'sql = "UPDATE  Genralledger  SET CostCenterNo ='" & varcodeCostCenter1 & "', DateM ='" & vardate & "', CodeLevel4 ='" & Txt_AccountNo2.Text & "',DisTable ='" & txt_Notes.Text & "',Debit ='" & Txt_TotalBound.Text & "' , Cridit ='" & 0 & "',CruunceyNo ='" & varcode_Cru & "' , rat ='" & txt_rat.Text & "' WHERE No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 3 & "' and CodeLevel4 ='" & Varaccount2 & "' "
        'rs = Cnn.Execute(sql)

        'sql = "UPDATE  Genralledger  SET CostCenterNo ='" & varcodeCostCenter2 & "', DateM ='" & vardate & "', CodeLevel4 ='" & txt_AccountNo.Text & "',DisTable ='" & txt_Notes.Text & "',Debit ='" & 0 & "' , Cridit ='" & Txt_TotalBound.Text & "',CruunceyNo ='" & varcode_Cru & "' , rat ='" & txt_rat.Text & "' WHERE No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 3 & "' and CodeLevel4 ='" & Varaccount1 & "' "
        'rs = Cnn.Execute(sql)
        ''========================================================= كشف الحساب

        'sql = "UPDATE  MovmentStatement  SET CostCenterNo ='" & varcodeCostCenter1 & "', DateMoveM ='" & vardate & "', AccountNo ='" & Txt_AccountNo2.Text & "',Discription ='" & txt_Notes.Text & "',Debit ='" & Txt_TotalBound.Text & "' , Cridit ='" & 0 & "',CruunceyNo ='" & varcode_Cru & "' , Rat_Cur ='" & txt_rat.Text & "' WHERE No_Sand = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 3 & "' and AccountNo ='" & Varaccount2 & "' "
        'rs = Cnn.Execute(sql)

        'sql = "UPDATE  MovmentStatement  SET CostCenterNo ='" & varcodeCostCenter2 & "', DateMoveM ='" & vardate & "', AccountNo ='" & txt_AccountNo.Text & "',Discription ='" & txt_Notes.Text & "',Debit ='" & 0 & "' , Cridit ='" & Txt_TotalBound.Text & "',CruunceyNo ='" & varcode_Cru & "' , Rat_Cur ='" & txt_rat.Text & "' WHERE No_Sand = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 3 & "' and AccountNo ='" & Varaccount1 & "' "
        'rs = Cnn.Execute(sql)

        ''========================================================================================

        'MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")




        ''delete_Update()
        ''save_Update()
        'find_detalis()
        'Total_Sum()
    End Sub

    Private Sub Cmd_PrintE_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        On Error Resume Next
        find_hedar()
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        varid = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))

        Txt_AccountNo2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Varaccount2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Txt_AccountName2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Cash.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        Com_Cur.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Txt_TotalBound.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        Txt_CheckNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        varchekNo = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_BankeIN.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        DateTimePicker1.Value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        Com_PayType.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))

        txt_Code_Costcenter.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        txt_Name_Costcenter.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))


        sql2 = "select * from TB_Receipt WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "'  and Code_Branch ='" & varCodeBranch & "' "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then cmd_Save.Enabled = True : Cmd_Update.Enabled = True : Cmd_Cancle.Enabled = True : Cmd_delete.Enabled = True Else cmd_Save.Enabled = True : Cmd_delete.Enabled = False : Cmd_Cancle.Enabled = False

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        find_hedar()
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle

        varid = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))

        Txt_AccountNo2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Varaccount2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Txt_AccountName2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Cash.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        Com_Cur.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        Txt_TotalBound.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        Txt_CheckNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        varchekNo = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_BankeIN.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        DateTimePicker1.Value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        Com_PayType.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))

        sql2 = "select * from TB_Receipt WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "'  and Code_Branch ='" & varCodeBranch & "' "
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then cmd_Save.Enabled = True : Cmd_Update.Enabled = True : Cmd_Cancle.Enabled = True : Cmd_delete.Enabled = True Else cmd_Save.Enabled = True : Cmd_delete.Enabled = False : Cmd_Cancle.Enabled = False

    End Sub






    Private Sub Cmd_deleteall_Click(sender As Object, e As EventArgs)
        'On Error Resume Next
        'Dim x As String
        ''Dim varcount As Integer
        'x = MsgBox("هل تريد الحذف ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'Select Case x
        '    Case vbNo

        '    Case vbYes
        '        sql = "Delete TB_Receipt  WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        '        rs = Cnn.Execute(sql)

        '        sql = "Delete Genralledger  WHERE No_Sand = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Typebill='" & 3 & "' "
        '        rs = Cnn.Execute(sql)

        '        sql = "Delete MovmentStatement  WHERE NumberBill = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Typebill='" & 3 & "' "
        '        rs = Cnn.Execute(sql)


        '        MsgBox(" تم الحذف نهائى", MsgBoxStyle.Information, "Css Solution Software Module")

        '        last_Data()
        '        clear_data()
        '        find_detalis()
        '        'Total_Sum()
        'End Select
    End Sub

    Private Sub Cmd_delete_Click_1(sender As Object, e As EventArgs) Handles Cmd_delete.Click
        'Dim dd As DateTime = txt_Receipt_Date.Value
        'Dim vardate As String
        'vardate = dd.ToString("dd/MM/yyyy")

        'Dim dd2 As DateTime = var_GetDateLive
        'Dim vardate2 As String
        'vardate2 = dd2.ToString("MM/dd/yyyy")
        'If vardate2 <> vardate Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        deleteLine()
        find_detalis()
    End Sub
    Sub deleteLine()
        On Error Resume Next

        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If varid = 0 Then MsgBox("من فضلك أختار سطر الحذف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                delete_File()
        End Select
    End Sub

    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        'delete_File()


        'Dim dd As DateTime = txt_Receipt_Date.Value
        'Dim vardate As String
        'vardate = dd.ToString("dd/MM/yyyy")

        'Dim dd2 As DateTime = var_GetDateLive
        'Dim vardate2 As String
        'vardate2 = dd2.ToString("MM/dd/yyyy")
        'If vardate2 <> vardate Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Name.Text) = 0 Then MsgBox("من فضلك ادخل اسم المستلم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql = "Delete TB_Receipt  WHERE Receipt_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete TB_HafzaRecipt  WHERE  Receipt_No  = '" & Com_Exp_No.Text & "' AND (Check_No = '" & varchekNo & "') and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        sql = "Delete Genralledger  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete MovmentStatement  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)



        'sql = "UPDATE   TB_Receipt   SET flg = '" & 0 & "' where  Receipt_No = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Code_Branch ='" & varCodeBranch & "' "
        'rs = Cnn.Execute(sql)


        'sql = "UPDATE   Genralledger   SET flg = '" & 1 & "' WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varcodebranch & "'  "
        'rs = Cnn.Execute(sql)




        save_Update()

        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','3','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================
    End Sub

    Private Sub Cmd_PrintE_Click_2(sender As Object, e As EventArgs)
        Report_Recipt.Show()
    End Sub

    Private Sub txt_Name_Salse_TextChanged(sender As Object, e As EventArgs) Handles txt_Name_Salse.TextChanged

    End Sub

    Private Sub txt_BankeIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_BankeIN.SelectedIndexChanged

    End Sub
    Sub Total_Sum2()
        On Error Resume Next
        Dim total As Single
        Dim total2 As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(6))

        Next
        txt_TotalEsal.Text = Math.Round(total, 2)

    End Sub
    Private Sub Cmd_PrintE_Click(sender As Object, e As EventArgs) Handles Cmd_PrintE.Click
        Total_Sum2()
        'Report_Recipt.Show()
        varesal_Type = 0
        Var_TF_Amount = NoToTxt(txt_TotalEsal.Text, "جنيها مصريا", "قرش")
        'sql = "update TB_Expenses set tt2='" & Var_TF_Amount & "'  WHERE Expenses_No = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        Rpt_Sarf.Show()
    End Sub


    Private Sub Cmd_Cancle_Click(sender As Object, e As EventArgs) Handles Cmd_Cancle.Click

        'Dim dd As DateTime = txt_Receipt_Date.Value
        'Dim vardate As String
        'vardate = dd.ToString("dd/MM/yyyy")

        'Dim dd2 As DateTime = var_GetDateLive
        'Dim vardate2 As String
        'vardate2 = dd2.ToString("MM/dd/yyyy")
        'If vardate2 <> vardate Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim x As String
        x = MsgBox("هل تريد الغاء الايصال", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "UPDATE   TB_Receipt   SET flg = '" & 1 & "' where  Receipt_No = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "'  and  Code_Branch ='" & varcode_Branch & "' "
                rs = Cnn.Execute(sql)


                sql = "UPDATE   Genralledger   SET flgcancle ='" & 1 & "', flg = '" & 0 & "'WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "'     "
                rs = Cnn.Execute(sql)


                'sql = "Delete Genralledger  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varcode_Branch & "' "
                'rs = Cnn.Execute(sql)

                sql = "Delete MovmentStatement  WHERE Typebill ='" & 3 & "'and No_Sand = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' and   Code_sub ='" & varcode_Branch & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','3','3','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                'clear_data()
                find_hedar()
                find_detalis()
                find_all_Detils()
                Cmd_delete.Enabled = False
                Cmd_Update.Enabled = False
                cmd_Save.Enabled = True
        End Select





    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        'If RadioButton2.Checked = True Then find_all_Detils()
        'If RadioButton1.Checked = True Then find_all_Data()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        If RadioButton2.Checked = True Then find_all_Detils()
        If RadioButton1.Checked = True Then find_all_Data()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        'If RadioButton2.Checked = True Then find_all_Detils()
        'If RadioButton1.Checked = True Then find_all_Data()

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)
        If RadioButton2.Checked = True Then find_all_Detils()
        If RadioButton1.Checked = True Then find_all_Data()
    End Sub


    Private Sub Cmd_FinAcc_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_FindInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_FindInvoice.Click
        If txt_AccountNo.Text <> "" Then
            varaccountCustomer = txt_AccountNo.Text
            Frm_LookupInvoiceRecipt.Find_Invoice()
            Frm_LookupInvoiceRecipt.ShowDialog()
        Else
            MsgBox("من فضلك اختار اسم العميل", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If

    End Sub

    Private Sub com_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Type.SelectedIndexChanged

    End Sub

    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles OP3.CheckedChanged


    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles OP3.Click
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub OP2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OP2_CheckedChanged_1(sender As Object, e As EventArgs)
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
    End Sub



    Private Sub Cmd_FinAcc_Click_1(sender As Object, e As EventArgs) Handles Cmd_FinAcc.Click
        Frm_AccountStatement2.Close()
        Frm_AccountStatement2.txt_codeAcc.Text = txt_AccountNo.Text
        Frm_AccountStatement2.txt_NameAcc.Text = txt_nameaccount.Text
        Frm_AccountStatement2.MdiParent = Mainmune
        Frm_AccountStatement2.FindBalance()
        Frm_AccountStatement2.find_data()
        Frm_AccountStatement2.count_colume()
        Frm_AccountStatement2.count_colume2()
        Frm_AccountStatement2.final_sum()
        Frm_AccountStatement2.Show()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub cmd_Find_Click_1(sender As Object, e As EventArgs) Handles cmd_Find.Click
        'Find_Data()
        chekUser()
        If RadioButton2.Checked = True Then find_all_Detils()
        If RadioButton1.Checked = True Then find_all_Data()
    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'GridView1.ShowPrintPreview()
        On Error Resume Next
        'sql = "Delete TB_TempReport1   "
        'rs = Cnn.Execute(sql)
        'If RadioButton1.Checked = True Then   ''مجمع
        '    Dim result As Integer = 0
        '    For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

        '        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        '        sql2 = "insert into TB_TempReport1  (No_Sand,Date_M" & _
        '            " ,TotalAll_Invoice,AccountName,NameDir) " & _
        '            " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
        '            " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "') "
        '        Cnn.Execute(sql2)


        '    Next rowHandle
        '    var_open_Recipt = 2

        'End If


        'If RadioButton2.Checked = True Then '====تفصيلى
        '    Dim result As Integer = 0
        '    For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

        '        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        '        Dim var8, var9, var10 As String

        '        var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
        '        var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
        '        var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))

        '        sql2 = "insert into TB_TempReport1  (No_Sand,Date_M" & _
        '            " ,AccountName,Value_cash,Cur,Qty,Tax_Value,No_Check,BankMshob,DateAtt,TypeMove,NameDir) " & _
        '            " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "' " & _
        '            " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "','" & var8 & "','" & var9 & "','" & var10 & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) & "') "
        '        Cnn.Execute(sql2)


        '    Next rowHandle
        '    var_open_Recipt = 3

        'End If






        Rpt_Recipt1.Show()
    End Sub

    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs) Handles Cmd_OpenFile.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click

    End Sub

    Private Sub Cmd_OpenCostcenter_Click(sender As Object, e As EventArgs) Handles Cmd_OpenCostcenter.Click
        vartable = "Vw_CostcenterAll"
        VarOpenlookup = 3024
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Com_GL.Text = ""
        Com_GL.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 3) AND (Code_Sub = '" & varcodebranch & "') AND (No_Sand = '" & Com_Exp_No.Text & "') and flgcancle = '" & 0 & "'  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_GL.Items.Add(rs("IDGenral").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_GL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_GL.SelectedIndexChanged
        Frm_Gl4.Com_GL_No.Text = Com_GL.Text

        statusopen = 1
        Frm_Gl4.find_hedar()
        Frm_Gl4.find_detalis()
        Frm_Gl4.Total_Sum()
        Frm_Gl4.MdiParent = Mainmune
        Frm_Gl4.Show()
    End Sub

    Private Sub Cmd_SaveChek_Click(sender As Object, e As EventArgs) Handles Cmd_SaveChek.Click
        If varstatsuschek = "تحصيل" And Com_status.Text = "ارتجاع شيك" Then MsgBox("غير متاح اختيار ارتجاع الشيك حالة الشيك تحصيل", MsgBoxStyle.Critical, "Cerative smart software") : Exit Sub

        '==================================الاختيار
        sql2 = "SELECT Name, Code    FROM dbo.TB_StatusChack WHERE  (Name = '" & Com_status.Text & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varstatus = rs("code").Value
        '============================================================تعديل الحالة 

        '============================================تاريخ الايداع
        If varstatus = 2 Then
            If Com_status.Text = "ايداع بالبنك" And txt_EdaDate.Text = "" Then MsgBox("من فضلك ادخل تاريخ الايداع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Com_status.Text = "ايداع بالبنك" And IsDate(txt_EdaDate.Text) = False Then MsgBox("من فضلك ادخل تاريخ الايداع بصورة صحيحة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

            Dim dd As DateTime = txt_EdaDate.Text

            vardateEda = dd.ToString("MM-d-yyyy")
        End If

        If varstatus = 1 Then
            If Com_status.Text = "تحصيل" And txt_TahselDate.Text = "" Then MsgBox("من فضلك ادخل تاريخ التحصيل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Com_status.Text = "تحصيل" And IsDate(txt_TahselDate.Text) = False Then MsgBox("من فضلك ادخل تاريخ التحصيل بصورة صحيحة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

            Dim dd2 As DateTime = txt_TahselDate.Text

            vardateColected = dd2.ToString("MM-d-yyyy")
        End If

        '==========================================================================================================================الحافظة

        If Com_status.Text = "ايداع بالبنك" Then 'من حساب شيكات تحت التحصيل الى اوراق القبض
            sql = "UPDATE   TB_HafzaRecipt   SET AccountNoChek ='" & Txt_AccountNoBank.Text & "', Flg_Stutascheck = '" & varstatus & "' , Date_Ada ='" & vardateEda & "', Date_Colacted ='" & vardateColected & "' where  Hfza_No = '" & varnohafza & "' and Check_No = '" & txt_FindCheck.Text & "' and   Code_Branch ='" & varCodeBranch & "' "
            Cnn.Execute(sql)
        ElseIf Com_status.Text = "تحصيل" Then 'من حساب البنك الى شيكات تحت التحصيل
            sql = "UPDATE   TB_HafzaRecipt   SET AccountNoBank ='" & Txt_AccountNoBank.Text & "', Flg_Stutascheck = '" & varstatus & "' , Date_Colacted ='" & vardateColected & "' where  Hfza_No = '" & varnohafza & "' and Check_No = '" & txt_FindCheck.Text & "' and   Code_Branch ='" & varCodeBranch & "' "
            Cnn.Execute(sql)

        ElseIf Com_status.Text = "ارتجاع شيك" Then ' من حساب العميل الى اوراق القبض
            sql = "UPDATE   TB_HafzaRecipt   SET AccountNoChek ='" & Txt_AccountNoBank.Text & "', Flg_Stutascheck = '" & varstatus & "' , Date_Colacted ='" & vardateColected & "' where  Hfza_No = '" & varnohafza & "' and Check_No = '" & txt_FindCheck.Text & "' and   Code_Branch ='" & varCodeBranch & "' "
            Cnn.Execute(sql)

        End If
        '=======================================================================================

        '======================================================== اوراق القبض حساب
        sql3 = " SELECT Check_No, AccountNo2       FROM dbo.TB_Receipt WHERE  (Check_No = '" & txt_FindCheck.Text & "') and   Code_Branch ='" & varCodeBranch & "'"
        rs3 = Cnn.Execute(sql3)
        If rs3.EOF = False Then Varacc1 = rs3("AccountNo2").Value


        lastgl()
        Dim dd3 As DateTime = txt_Receipt_Date.Value
        Dim vardate As String
        vardate = dd3.ToString("MM-d-yyyy")
        '=================================Account1

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value



        '================================================== حساب شيكات تحت التحصيل
        sql3 = "   SELECT Account_No, Compny_Code FROM     dbo.St_SetupChekThsel where Code_Branch ='" & varCodeBranch & "' "
        rs3 = Cnn.Execute(sql3)
        If rs3.EOF = False Then Varacc2 = rs3("Account_No").Value
        '============================================

        If varstatus = 2 Then  'الايداع







            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 13 & "' and No_Sand = '" & txt_FindCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)

            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & txt_FindCheck.Text & "'  and Typebill ='" & 13 & "'  and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)


            '=======================================================GL المدين
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc2 & "','" & "ايداع شيك " + "  " + txt_FindCheck.Text & "','" & VarvalueCash & "' ,'" & 0 & "','" & 13 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & VarvalueCash & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
            '=======================================================GL الدائن
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc1 & "','" & "ايداع شيك " + "  " + txt_FindCheck.Text & "','" & 0 & "' ,'" & VarvalueCash & "','" & 13 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & VarvalueCash & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)



            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
                " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Varacc2 & "',N'" & "ايداع شيك " + "  " + txt_FindCheck.Text & "',N'" & VarvalueCash & "',N'" & 0 & "',N'" & "13" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & VarvalueCash & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            '=================================الدائن

            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
          " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Varacc1 & "',N'" & "ايداع شيك " + "  " + txt_FindCheck.Text & "',N'" & 0 & "',N'" & VarvalueCash & "',N'" & "13" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & 0 & "','" & VarvalueCash & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)


            MsgBox("تم الحفظ " + "برقم شيك " & " " & txt_FindCheck.Text, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
            Find_Hafza()

        End If



        If varstatus = 1 Then  'التحصيل


            ''================================================== حساب شيكات تحت التحصيل
            sql3 = "   SELECT * FROM     dbo.St_SetupChekThsel"
            rs3 = Cnn.Execute(sql3)
            If rs3.EOF = False Then Varacc2 = rs3("Account_No").Value
            ''============================================


            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 14 & "' and No_Sand = '" & txt_FindCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)

            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & txt_FindCheck.Text & "'  and Typebill ='" & 14 & "'  and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)




            '=======================================================GL المدين
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Txt_AccountNoBank.Text & "','" & "تحصيل شيك " + "  " + txt_FindCheck.Text & "','" & VarvalueCash & "' ,'" & 0 & "','" & 14 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & VarvalueCash & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
            '=======================================================GL الدائن
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc2 & "','" & "تحصيل شيك " + "  " + txt_FindCheck.Text & "','" & 0 & "' ,'" & VarvalueCash & "','" & 14 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & VarvalueCash & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)



            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
                " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Txt_AccountNoBank.Text & "',N'" & "تحصيل شيك " + "  " + txt_FindCheck.Text & "',N'" & VarvalueCash & "',N'" & 0 & "',N'" & "14" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & VarvalueCash & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            '=================================الدائن

            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
          " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Varacc2 & "',N'" & "تحصيل شيك " + "  " + txt_FindCheck.Text & "',N'" & 0 & "',N'" & VarvalueCash & "',N'" & "14" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & 0 & "','" & VarvalueCash & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            MsgBox("تم الحفظ " + "برقم شيك " & " " & txt_FindCheck.Text, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
            Find_Hafza()

        End If




        If varstatus = 3 Then  'ارتجاع الشيك




            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 15 & "' and No_Sand = '" & txt_FindCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)

            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & txt_FindCheck.Text & "'  and Typebill ='" & 15 & "'  and Compny_Code ='" & VarCodeCompny & "' and code_sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)




            '=======================================================GL المدين
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Txt_AccountNoBank.Text & "','" & "ارتجاع شيك " + "  " + txt_FindCheck.Text & "','" & VarvalueCash & "' ,'" & 0 & "','" & 15 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & VarvalueCash & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
            '=======================================================GL الدائن
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc1 & "','" & "ارتجاع شيك " + "  " + txt_FindCheck.Text & "','" & 0 & "' ,'" & VarvalueCash & "','" & 15 & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & VarvalueCash & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)



            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
                " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Txt_AccountNoBank.Text & "',N'" & "ارتجاع شيك " + "  " + txt_FindCheck.Text & "',N'" & VarvalueCash & "',N'" & 0 & "',N'" & "15" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & VarvalueCash & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            '=================================الدائن

            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
          " values  (N'" & varseril_No & "',N'" & txt_FindCheck.Text & "' ,N'" & vardate & "',N'" & Varacc1 & "',N'" & "ارتجاع شيك " + "  " + txt_FindCheck.Text & "',N'" & 0 & "',N'" & VarvalueCash & "',N'" & "15" & "',N'" & "0" & "','" & txt_FindCheck.Text & "','" & varcodebranch & "','" & varcode_Cru & "','" & 0 & "','" & VarvalueCash & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            MsgBox("تم الحفظ " + "برقم شيك " & " " & txt_FindCheck.Text, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
            Find_Hafza()

        End If

    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Com_GLNo.Text = ""
        Com_GLNo.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger where   (Code_Sub = '1') AND (No_Sand = '" & txt_FindCheck.Text & "') and  code_sub ='" & varCodeBranch & "' AND (flgcancle = '0') GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING  (Typebill = 13) or (Typebill = 14)  or (Typebill = 15)   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_GLNo.Items.Add(rs("IDGenral").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_GLNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_GLNo.SelectedIndexChanged
        Frm_Gl4.Com_GL_No.Text = Com_GLNo.Text

        statusopen = 1
        Frm_Gl4.find_hedar()
        Frm_Gl4.find_detalis()
        Frm_Gl4.Total_Sum()
        Frm_Gl4.MdiParent = Mainmune
        Frm_Gl4.Show()
    End Sub



    Private Sub Cmd_DeleteChek_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteChek.Click
        Dim x As String

        If txt_FindCheck.Text = "" Then MsgBox("من فضلك اختار رقم الشيك", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        x = MsgBox("هل تريد حذف حركة الشيكات", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Genralledger  WHERE Typebill ='" & 13 & "'and No_Sand = '" & txt_FindCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete MovmentStatement  WHERE Typebill ='" & 13 & "'and No_Sand = '" & txt_FindCheck.Text & "' and  Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete Genralledger  WHERE Typebill ='" & 14 & "'and No_Sand = '" & txt_FindCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete MovmentStatement  WHERE Typebill ='" & 14 & "'and No_Sand = '" & txt_FindCheck.Text & "' and  Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "' "
                rs = Cnn.Execute(sql)


                sql = "UPDATE   TB_HafzaRecipt   SET  AccountNoChek ='" & "" & "' , Date_Ada ='" & "" & "', Date_Colacted ='" & "" & "' , Flg_Stutascheck = '" & 0 & "'   where  Hfza_No = '" & varnohafza & "' and Check_No = '" & txt_FindCheck.Text & "' and   Code_Branch ='" & varCodeBranch & "' "
                Cnn.Execute(sql)



                Find_Hafza()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        End Select





    End Sub
End Class