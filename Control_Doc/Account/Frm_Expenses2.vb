Imports System.Data.OleDb
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class Frm_Expenses2
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim varhfza, valueSerilNo As Integer
    Dim category, varcodeCostCenter1, varcodeCostCenter2 As String
    Dim varseril_No, varid, varchooseAcc As Integer
    Dim vardate5, Varacc1, Varacc2, varstatsuschek, varcur As String
    Dim VarvalueCash As Single

    Sub find_Exp()
        vartable = "Vw_Lookup_Expnses"
        VarOpenlookup = 52
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        'clear_detils()
        'find_hedar()
        find_hedar()
        find_detalis()
        'Total_Sum()

    End Sub

    Private Sub Frm_Expenses2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        'txt_Expenses_Date.Select()
        fill_Cru()
        fill_StatusCheck()
        'fill_Bank()
        'last_Data()
        Com_PayType.Items.Add("نقدى")
        Com_PayType.Items.Add("شيك")
        Com_PayType.Items.Add("تحويل بنكى")
        '=================================
        com_Type.Items.Add("اخرى")
        com_Type.Items.Add("دفعة مقدمة")
        com_Type.Items.Add("فاتورة")

        get_BoxCash()
        'txt_Cash.Text = Format(txt_Cash.Text, "#,##0.00")
        'last_Data()
        'clear_data()
        'last_Data()
        'clear_data()
        fill_Bank()
        cmd_Save.Enabled = True
        Cmd_DeleteLine.Enabled = False
        Cmd_Update.Enabled = False
        CustomDrawRowIndicator(GridControl1, GridView1)
        CustomDrawRowIndicator(GridControl3, GridView6)
        TabPane1.SelectedPageIndex = 0
        Com_Exp_No.Select()
    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight

        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1

    End Sub
    Private Sub GridView6_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)


        GridView6.RowHeight = 20
        GridView6.GroupRowHeight = 1
        GridView6.RowSeparatorHeight = 1
        'End If
    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
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
        sql = "    SELECT  Name  FROM TB_StatusChack where flg=2 "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_status.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub fill_Bank()
        txt_BankeIN.Items.Clear()
        'txt_BankeIN.Items.Clear()
        sql = "    SELECT  AccountName  FROM Vw_BankName "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_BankeIN.Items.Add(rs("AccountName").Value)
            'txt_BankeIN.Items.Add(rs("AccountName").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Com_PayType_KeyDown(sender As Object, e As KeyEventArgs) Handles Com_PayType.KeyDown
        If e.KeyCode = Keys.Tab Then
            Txt_AccountName2.Select()

        End If
    End Sub


    Private Sub Com_PayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_PayType.SelectedIndexChanged
        If Com_PayType.Text = "نقدى" Then
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

   



    Sub last_Data()
        On Error Resume Next
        If Com_Exp_No.Text = "" Then Com_Exp_No.Text = 0
        sql2 = "   SELECT Expenses_No, Code_Branch      FROM dbo.TB_Expenses GROUP BY Expenses_No, Code_Branch HAVING (Expenses_No = '" & Com_Exp_No.Text & "') AND (Code_Branch = '" & varCodeBranch & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then
            Var_Code_Esal = Com_Exp_No.Text
        Else


            sql = "SELECT        MAX(Expenses_No) AS MaxmamNo FROM dbo.TB_Expenses where Compny_Code = '" & VarCodeCompny & "' and Code_Branch ='" & varCodeBranch & "' HAVING(MAX(Expenses_No) Is Not NULL) "

            Cnn.Execute(sql)
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
                Com_Exp_No.Text = rs("MaxmamNo").Value + 1
                Var_Code_Esal = rs("MaxmamNo").Value + 1
            Else
                Com_Exp_No.Text = 1
                Var_Code_Esal = 1

                'clear_data()

            End If

            sql = "   SELECT        MAX(Hfza_No) + 1 AS MaxHfza           FROM   dbo.TB_Expenses where Compny_Code = '" & VarCodeCompny & "' and Code_Branch ='" & varCodeBranch & "' GROUP BY Expenses_No HAVING        (MAX(Hfza_No) IS NOT NULL) "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
                varhfza = rs("MaxHfza").Value
            Else
                varhfza = 1
                'clear_data()

            End If
        End If
    End Sub

    Private Sub com_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Type.SelectedIndexChanged


        If com_Type.Text = "دفعة مقدمة" Then
            'LabelX16.Visible = False
            'Com_InvoiceNo.Visible = False
            'Cmd_FindInvoice.Visible = False
        ElseIf com_Type.Text = "فاتورة" Then
            'LabelX16.Visible = True
            'Com_InvoiceNo.Visible = True
            'Cmd_FindInvoice.Visible = True
        End If
    End Sub





    Sub clear_data()
        Com_Exp_No.Text = ""
        txt_Expenses_Date.Text = ""
        txt_Expenses_Date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        txt_Expenses_Date.Select()
        txt_No_Salse.Text = ""
        txt_Name_Salse.Text = ""
        txt_Cash.Text = ""
        Txt_AccountNo2.Text = ""
        Txt_AccountName2.Text = ""
        txt_Cash.Text = ""
        'txt_rat.Text = ""
        Txt_TotalBound.Text = ""
        Txt_CheckNo.Text = ""
        txt_BankeIN.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_Notes.Text = ""
        txt_Name.Text = ""
        'txt_TotalEsal.Text = ""
        'txt_Notes.Text = ""
        'Com_Cur.Text = "جنية مصرى"
        Com_Cur.Text = "جنية مصرى"
        com_Type.Text = "دفعة مقدمة"
        'com_Type.Text = ""
        txt_TotalEsal.Text = ""
        Txt_NoDftr.Text = ""
        Com_GL.Text = ""
        txt_No_Salse.Text = varcode_User
        txt_Name_Salse.Text = varnameuser
        txt_Name.Text = txt_nameaccount.Text

        'GridControl1.DataSource = Nothing
        'GridView1.Columns.Clear()
    End Sub

    Private Sub Com_Cur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Cur.SelectedIndexChanged
        '========================================================رقم العملة
        Fill_Cur()

    End Sub
    Sub Fill_Cur()
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        If txt_Expenses_Date.Text = "" Then Exit Sub
        oldDate = txt_Expenses_Date.Text
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_Expenses_Date.Text, d)
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
        find_Exp()
        Cmd_DeleteLine.Enabled = False
        Cmd_Update.Enabled = False
        cmd_Save.Enabled = True
        txt_TotalEsal.Text = ""
        Total_Sum2()
    End Sub

    Private Sub Com_Exp_No_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Exp_No.EditValueChanged

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
    Sub find_hedar()
        On Error Resume Next


        sql = "SELECT    dbo.TB_Expenses.flg,   dbo.TB_Expenses.No_Dftr,dbo.TB_Expenses.Name, dbo.TB_Expenses.Expenses_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Expenses.AccountNo1, dbo.TB_Expenses.Code_Salse,  " & _
"                         dbo.Emp_employees.Emp_Name, dbo.TB_Expenses.Type_Invoice, dbo.TB_Expenses.Notes  " & _
" FROM            dbo.TB_Expenses LEFT OUTER JOIN  " & _
"                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN  " & _
"                         dbo.Emp_employees ON dbo.TB_Expenses.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Expenses.Compny_Code = dbo.Emp_employees.Compny_Code  " & _
" WHERE        (dbo.TB_Expenses.Expenses_No = '" & Com_Exp_No.Text & "') AND (dbo.TB_Expenses.Compny_Code = '" & VarCodeCompny & "') and Code_Branch = '" & varCodeBranch & "'  " & _
" GROUP BY  dbo.TB_Expenses.flg, dbo.TB_Expenses.No_Dftr,dbo.TB_Expenses.Name, dbo.TB_Expenses.Expenses_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName), dbo.TB_Expenses.AccountNo1, dbo.TB_Expenses.Code_Salse,   " & _
"        dbo.Emp_employees.Emp_Name, dbo.TB_Expenses.Type_Invoice, dbo.TB_Expenses.Notes "


        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_nameaccount.Text = Trim(rs("AccountName").Value)
            txt_AccountNo.Text = Trim(rs("AccountNo1").Value)
            txt_No_Salse.Text = Trim(rs("Code_Salse").Value)
            txt_Name_Salse.Text = Trim(rs("Emp_Name").Value)
            com_Type.Text = Trim(rs("TypeInvoice").Value)
            'txt_Notes.Text = Trim(rs("notes").Value)
            txt_Name.Text = Trim(rs("Name").Value)
            Txt_NoDftr.Text = Trim(rs("No_Dftr").Value)

            'txt_nameaccount.Text = Trim(rs("AccountName").Value)
            'txt_AccountNo.Text = Trim(rs("AccountNo1").Value)

            Dim dd As DateTime = rs("Expenses_Date").Value
            Dim vardate As String
            vardate = dd.ToString("dd/MM/yyyy")

            txt_Expenses_Date.Text = vardate



            'rs = Cnn.Execute(sql2)
            If rs("flg").Value = 0 Then txt_stutas.Text = "غير ملغى" : txt_stutas.BackColor = Color.Gray
            If rs("flg").Value = 1 Then txt_stutas.Text = "ملغى" : txt_stutas.BackColor = Color.Yellow

        Else
            txt_nameaccount.Text = ""
            txt_AccountNo.Text = ""
            txt_No_Salse.Text = ""
            txt_Name_Salse.Text = ""
            com_Type.Text = ""
            Txt_NoDftr.Text = ""
        End If



    End Sub
    Sub find_detalis()
        On Error Resume Next

        If Com_Exp_No.Text = "" Then Com_Exp_No.Text = 0
        'GridControl3.DataSource = Nothing
        'GridView6.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        'sql2 = "SELECT       dbo.TB_Expenses.Serail_lNo,  dbo.TB_Expenses.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Expenses.Expenses_Value, dbo.BD_Currency.Name, dbo.TB_Expenses.rat,  " & _
        '"                         dbo.TB_Expenses.Expenses_Value_EGP, dbo.TB_Expenses.Check_No, dbo.TB_Expenses.Bank_IN ,iif( dbo.TB_Expenses.TypePay=0,dbo.TB_Expenses.Date_Asthkak2,TB_Expenses.Date_Asthkak) as Date_Asthkak,iif( dbo.TB_Expenses.TypePay=0,'نقدى','شيك') as stutas, TB_Expenses.Notes, dbo.TB_Expenses.AccountNo1 " & _
        '" FROM            dbo.TB_Expenses INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Expenses.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '"                         dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Expenses.Compny_Code = dbo.BD_Currency.Compny_Code " & _
        '" WHERE        (dbo.TB_Expenses.Expenses_No = '" & Com_Exp_No.Text & "') AND (dbo.TB_Expenses.Compny_Code = '" & VarCodeCompny & "') "

        sql2 = "  SELECT dbo.TB_Expenses.Serail_lNo, dbo.TB_Expenses.AccountNo2, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Expenses.Expenses_Value, dbo.BD_Currency.Name, dbo.TB_Expenses.rat, " & _
  "                  dbo.TB_Expenses.Expenses_Value_EGP, dbo.TB_Expenses.Check_No, dbo.TB_Expenses.Bank_IN,iif( dbo.TB_Expenses.TypePay=0,dbo.TB_Expenses.Date_Asthkak2,TB_Expenses.Date_Asthkak) as Date_Asthkak, dbo.TB_Type_Pay.Name AS stutas, dbo.TB_Expenses.Notes, dbo.TB_Expenses.AccountNo1, dbo.TB_Expenses.TypePay " & _
  " FROM     dbo.TB_Expenses INNER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Expenses.AccountNo2 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
  "                  dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Expenses.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
  "                  dbo.TB_Type_Pay ON dbo.TB_Expenses.TypePay = dbo.TB_Type_Pay.Code " & _
  " WHERE  (dbo.TB_Expenses.Expenses_No ='" & Com_Exp_No.Text & "') AND (dbo.TB_Expenses.Compny_Code ='" & VarCodeCompny & "') and Code_Branch = '" & varCodeBranch & "' "


        'rs = Cnn.Execute(sql2)
        'If rs("flg").Value = 0 Then txt_stutas.Text = "غير ملغى" : txt_stutas.BackColor = Color.Transparent
        'If rs("flg").Value = 1 Then txt_stutas.Text = "ملغى" : txt_stutas.BackColor = Color.Yellow

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)



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
        GridView6.Columns(11).Caption = "ملاحظات"

        GridView6.Columns(12).Caption = "رقم الحساب الاخر"

        GridView6.Columns(13).Visible = False
        GridView6.Columns(4).Visible = False
        GridView6.Columns(5).Visible = False
        GridView6.Columns(6).Visible = False

        GridView6.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


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


        sql2 = "     SELECT        dbo.TB_Expenses.Expenses_No, dbo.TB_Expenses.No_Dftr, dbo.TB_Expenses.Expenses_Date, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.TB_Type_Pay.Name as Type, dbo.TB_Expenses.Expenses_Value, dbo.BD_Currency.Name, dbo.TB_Expenses.rat, " & _
        "                         dbo.TB_Expenses.Expenses_Value_EGP, dbo.TB_Expenses.Check_No, dbo.TB_Expenses.Bank_IN, dbo.TB_Expenses.Date_Asthkak, dbo.Emp_employees.Emp_Name, dbo.TB_Expenses.Notes, iif(dbo.TB_Expenses.Type_Invoice=2,'فاتورة','دفعة مقدمة') as Type2, dbo.TB_Expenses.Serail_lNo,  iif(dbo.TB_Expenses.flg=0,'غير ملغى','ملغى') as stutas, dbo.TB_Expenses.UserID " & _
" FROM     dbo.TB_Expenses INNER JOIN " & _
"                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
"                  dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Expenses.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
"                  dbo.Emp_employees ON dbo.TB_Expenses.Code_Salse = dbo.Emp_employees.Emp_Code AND dbo.TB_Expenses.Compny_Code = dbo.Emp_employees.Compny_Code INNER JOIN " & _
    "    dbo.TB_Type_Pay ON dbo.TB_Expenses.TypePay = dbo.TB_Type_Pay.Code " & _
        " WHERE        (dbo.TB_Expenses.Expenses_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) and   (dbo.TB_Expenses.Expenses_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and  (dbo.TB_Expenses.Compny_Code = '" & VarCodeCompny & "')  "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)





        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم السند"
        GridView1.Columns(1).Caption = "رقم الدفترى"
        GridView1.Columns(2).Caption = "ناريخ السند "
        GridView1.Columns(3).Caption = "أسم الحساب"
        GridView1.Columns(4).Caption = "نوع الدفع"
        GridView1.Columns(5).Caption = "المبلغ"
        GridView1.Columns(6).Caption = "العملة"
        GridView1.Columns(7).Caption = "معامل التحويل"
        GridView1.Columns(8).Caption = "الاجمالى"
        GridView1.Columns(9).Caption = "رقم الشيك"
        GridView1.Columns(10).Caption = "مسحوب على"
        GridView1.Columns(11).Caption = "أستحقاق"
        GridView1.Columns(12).Caption = "أسم المندوب"
        GridView1.Columns(13).Caption = "البيان"
        GridView1.Columns(14).Caption = "نوع الدفعة"
        GridView1.Columns(16).Caption = "حالة الايصال"
        GridView1.Columns(17).Caption = "رقم المستخدم"

        GridView1.Columns(6).Visible = False
        GridView1.Columns(7).Visible = False

        GridView1.Columns(9).Visible = False
        GridView1.Columns(10).Visible = False
        GridView1.Columns(11).Visible = False
        GridView1.Columns(12).Visible = False
        'GridView1.Columns(12).Visible = False
        GridView1.Columns(14).Visible = False

        GridView1.Columns(15).Visible = False


        GridView1.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Sub Find_Hafza()


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




        '     sql2 = "   SELECT dbo.TB_HafzaExpenses.Hfza_No, dbo.TB_HafzaExpenses.Expenses_No, dbo.TB_Expenses.Expenses_Value, dbo.BD_Currency.Name AS NameCur, dbo.TB_Expenses.rat, dbo.TB_Expenses.Expenses_Value_EGP, " & _
        '"                  dbo.TB_HafzaExpenses.Check_No, dbo.TB_Expenses.Expenses_Date, dbo.TB_Expenses.Bank_IN, dbo.TB_Expenses.Date_Asthkak, dbo.TB_HafzaExpenses.Date_Ada, dbo.TB_HafzaExpenses.Date_Colacted, dbo.TB_StatusChack.Name,  " & _
        '"                  dbo.TB_HafzaExpenses.Code_Branch, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS Acc1, RTRIM(ST_CHARTOFACCOUNT_1.AccountName) AS acc2 " & _
        '" FROM     dbo.TB_Expenses INNER JOIN " & _
        '"                  dbo.TB_HafzaExpenses ON dbo.TB_Expenses.Expenses_No = dbo.TB_HafzaExpenses.Expenses_No AND dbo.TB_Expenses.Compny_Code = dbo.TB_HafzaExpenses.Compny_Code AND  " & _
        '"                  dbo.TB_Expenses.Check_No = dbo.TB_HafzaExpenses.Check_No AND dbo.TB_Expenses.Expenses_No = dbo.TB_HafzaExpenses.Hfza_No INNER JOIN " & _
        '"                  dbo.TB_StatusChack ON dbo.TB_HafzaExpenses.Status = dbo.TB_StatusChack.Code INNER JOIN " & _
        '"                  dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Expenses.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
        '"                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Expenses.AccountNo2 = ST_CHARTOFACCOUNT_1.Account_No " & _
        '" WHERE  (dbo.TB_Expenses.Expenses_Date >= CONVERT(DATETIME, ''" & vardate & "', 102)) AND (dbo.TB_Expenses.Expenses_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaExpenses.Compny_Code = '1')   "

        sql2 = "   SELECT dbo.TB_HafzaExpenses.Hfza_No, dbo.TB_HafzaExpenses.Expenses_No, dbo.TB_Expenses.Expenses_Value, dbo.BD_Currency.Name AS NameCur, dbo.TB_Expenses.rat, dbo.TB_Expenses.Expenses_Value_EGP,  " & _
   "                  dbo.TB_HafzaExpenses.Check_No, dbo.TB_Expenses.Expenses_Date, dbo.TB_Expenses.Bank_IN, dbo.TB_Expenses.Date_Asthkak, dbo.TB_HafzaExpenses.Date_Ada, dbo.TB_HafzaExpenses.Date_Colacted, dbo.TB_StatusChack.Name,  " & _
   "                  dbo.TB_HafzaExpenses.Code_Branch, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS Acc1, RTRIM(ST_CHARTOFACCOUNT_1.AccountName) AS acc2 " & _
   " FROM     dbo.TB_Expenses INNER JOIN " & _
   "                  dbo.TB_HafzaExpenses ON dbo.TB_Expenses.Expenses_No = dbo.TB_HafzaExpenses.Expenses_No AND dbo.TB_Expenses.Compny_Code = dbo.TB_HafzaExpenses.Compny_Code AND  " & _
   "                  dbo.TB_Expenses.Check_No = dbo.TB_HafzaExpenses.Check_No AND dbo.TB_Expenses.Expenses_No = dbo.TB_HafzaExpenses.Hfza_No INNER JOIN " & _
   "                  dbo.TB_StatusChack ON dbo.TB_HafzaExpenses.Status = dbo.TB_StatusChack.Code INNER JOIN " & _
   "                  dbo.BD_Currency ON dbo.TB_Expenses.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Expenses.Compny_Code = dbo.BD_Currency.Compny_Code INNER JOIN " & _
   "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
   "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_Expenses.AccountNo2 = ST_CHARTOFACCOUNT_1.Account_No " & _
   "WHERE  (dbo.TB_Expenses.Expenses_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Expenses.Expenses_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaExpenses.Compny_Code = '1') AND  " & _
             "        (dbo.TB_HafzaExpenses.Code_Branch = '1') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)




        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "رقم الحافظة"
        GridView3.Columns(1).Caption = "رقم السند "
        GridView3.Columns(2).Caption = "المبلغ "
        GridView3.Columns(3).Caption = "العملة "
        GridView3.Columns(4).Caption = "معامل التحويل "
        GridView3.Columns(5).Caption = "الاجمالى "
        GridView3.Columns(6).Caption = "رقم الشيك"
        GridView3.Columns(7).Caption = "تاريخ الاستلام"
        GridView3.Columns(8).Caption = "البنك المسحوب عليه"
        GridView3.Columns(9).Caption = "تاريخ الاستحقاق"
        GridView3.Columns(10).Caption = "تاريخ الايداع"
        GridView3.Columns(11).Caption = "تاريخ التحصيل"
        GridView3.Columns(12).Caption = "حالة الشيك"
        GridView3.Columns(13).Caption = "رقم الفرع"
        GridView3.Columns(14).Caption = "اسم الحساب"
        GridView3.Columns(15).Caption = "اسم البنك"

        'GridView3.Columns(10).Visible = False
        'GridView3.Columns(11).Visible = False
        'GridView3.Columns(9).Visible = False
        'GridView3.Columns(8).Visible = False

        GridView3.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub

    Private Sub cmd_Find_Click(sender As Object, e As EventArgs) Handles cmd_Find.Click
        Find_Data()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Find_Hafza()
    End Sub


    Sub lastSeril_No()
        sql = "SELECT        MAX(Serail_lNo) AS MaxmamNo FROM dbo.TB_Expenses where Compny_Code = '" & VarCodeCompny & "' and Code_Branch ='" & varCodeBranch & "' and  Expenses_No='" & Var_Code_Esal & "' HAVING(MAX(Serail_lNo) Is Not NULL) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varseril_No = rs("MaxmamNo").Value + 1 Else varseril_No = 1
    End Sub

    Sub save_Statment()
        lastgl()
        Dim dd As DateTime = txt_Expenses_Date.Text
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '=================================Account1
        ''=============رقم مركز التكلفة1
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & Txt_AccountNo2.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================
        'If VarCodeCompny = 3 Then varcodeCostCenter1 = "101002"
        ''=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & Txt_AccountNo2.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        ''=============================

        'If VarCodeCompny = 3 Then varcodeCostCenter2 = "101002"


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value


        '=======================================================GL المدين
        sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & txt_AccountNo.Text & "','" & txt_Notes.Text & "','" & txt_Cash.Text & "' ,'" & 0 & "','" & 4 & "','" & Var_Code_Esal & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & Txt_TotalBound.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)
        '=======================================================GL الدائن
        sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Txt_AccountNo2.Text & "','" & txt_Notes.Text & "','" & 0 & "' ,'" & txt_Cash.Text & "','" & 4 & "','" & Var_Code_Esal & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & Txt_TotalBound.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)



        sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
            " values  (N'" & varseril_No & "',N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & txt_AccountNo.Text & "',N'" & txt_Notes.Text & "',N'" & txt_Cash.Text & "',N'" & 0 & "',N'" & "4" & "',N'" & "0" & "','" & Var_Code_Esal & "','" & varCodeBranch & "','" & varcode_Cru & "','" & Txt_TotalBound.Text & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
        Cnn.Execute(sql)

        '=================================الدائن

        sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
      " values  (N'" & varseril_No & "',N'" & Com_Exp_No.Text & "' ,N'" & vardate & "',N'" & Txt_AccountNo2.Text & "',N'" & txt_Notes.Text & "',N'" & 0 & "',N'" & txt_Cash.Text & "',N'" & "4" & "',N'" & "0" & "','" & Var_Code_Esal & "','" & varCodeBranch & "','" & varcode_Cru & "','" & 0 & "','" & Txt_TotalBound.Text & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
        Cnn.Execute(sql)



    End Sub
    Sub save_data()
        'If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل التاريخ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If IsDate(txt_Expenses_Date.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_No_Salse.Text) = 0 Then MsgBox("من فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Txt_NoDftr.Text) = 0 Then MsgBox("من فضلك ادخل رقم الدفترى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If
        'If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_Notes.Select() : Exit Sub


        If txt_Expenses_Date.Text = "" Then Exit Sub
        '============================================تاريخ السند
        Dim dd As DateTime = txt_Expenses_Date.Text
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        '==================================تاريخ الاستحقاق
        Dim dd2 As DateTime = DateTimePicker1.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")


        last_Data() 'اخر رقم ايصال
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================

        Dim VarType, VarType2 As Integer
        If com_Type.Text = "فاتورة" Then VarType = 0
        If com_Type.Text = "دفعة مقدمة" Then VarType = 1
        If com_Type.Text = "اخرى" Then VarType = 2

        If Com_PayType.Text = "نقدى" Then VarType2 = 0
        If Com_PayType.Text = "شيك" Then VarType2 = 1
        If Com_PayType.Text = "تحويل بنكى" Then VarType2 = 2

        lastSeril_No()
        If Com_PayType.Text = "نقدى" Then
            sql = "INSERT INTO TB_Expenses (Expenses_No, Expenses_Date,Id_User,Expenses_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Expenses_Value_EGP,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Serail_lNo,Name,No_Dftr,UserID,Code_CostCenter,Code_Branch) " & _
            " values  ( " & Var_Code_Esal & " ,N'" & vardate & "',N'" & 1 & "',N'" & txt_Cash.Text & "',N'" & txt_Notes.Text & "',N'" & txt_AccountNo.Text & "',N'" & Txt_AccountNo2.Text & "',N'" & varcode_Cru & "',N'" & VarCodeCompny & "',N'" & txt_No_Salse.Text & "',N'" & txt_rat.Text & "', N'" & Txt_TotalBound.Text & "' ,N'" & VarType & "',N'" & Txt_CheckNo.Text & "',N'" & txt_BankeIN.Text & "',N'" & vardate2 & "',N'" & VarType2 & "',N'" & varseril_No & "',N'" & txt_Name.Text & "',N'" & Txt_NoDftr.Text & "',N'" & varcode_User & "',N'" & txt_Code_Costcenter.Text & "',N'" & varCodeBranch & "')"
            Cnn.Execute(sql)



            '============================== TransactionHistoryCode SaveBtn
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Var_Code_Esal & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        ElseIf Com_PayType.Text = "تحويل بنكى" Then
            sql = "INSERT INTO TB_Expenses (Expenses_No, Expenses_Date,Id_User,Expenses_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Expenses_Value_EGP,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Serail_lNo,Name,No_Dftr,UserID,Code_CostCenter,Code_Branch) " & _
                " values  (" & Var_Code_Esal & " ,N'" & vardate & "',N'" & 1 & "',N'" & txt_Cash.Text & "',N'" & txt_Notes.Text & "',N'" & txt_AccountNo.Text & "',N'" & Txt_AccountNo2.Text & "',N'" & varcode_Cru & "',N'" & VarCodeCompny & "',N'" & txt_No_Salse.Text & "',N'" & txt_rat.Text & "', N'" & Txt_TotalBound.Text & "' ,N'" & VarType & "',N'" & Txt_CheckNo.Text & "',N'" & txt_BankeIN.Text & "',N'" & vardate2 & "',N'" & VarType2 & "',N'" & varseril_No & "',N'" & txt_Name.Text & "',N'" & Txt_NoDftr.Text & "',N'" & varcode_User & "',N'" & txt_Code_Costcenter.Text & "',N'" & varCodeBranch & "')"
            Cnn.Execute(sql)



            '============================== TransactionHistoryCode SaveBtn
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Var_Code_Esal & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================



        Else
            sql = "INSERT INTO TB_Expenses (Expenses_No, Expenses_Date,Id_User,Expenses_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Expenses_Value_EGP,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Hfza_No,Serail_lNo,Name,No_Dftr,UserID,Code_CostCenter,Code_Branch) " & _
            " values  (" & Var_Code_Esal & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' ,'" & VarType & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & varhfza & "','" & varseril_No & "','" & txt_Name.Text & "','" & Txt_NoDftr.Text & "','" & varcode_User & "','" & txt_Code_Costcenter.Text & "','" & varCodeBranch & "')"
            Cnn.Execute(sql)
            '====================================================save Hafza
            sql = " delete TB_HafzaExpenses where Hfza_No = " & Var_Code_Esal & "  "
            Cnn.Execute(sql)
            '=========================================================
            sql = "INSERT INTO TB_HafzaExpenses (Hfza_No,Expenses_No, Check_No,Compny_Code,Code_Branch) " & _
            " values  (" & Var_Code_Esal & ",'" & Var_Code_Esal & "','" & Txt_CheckNo.Text & "' ,'" & VarCodeCompny & "','" & varCodeBranch & "')"
            Cnn.Execute(sql)
            '====================================================================


            '============================== TransactionHistoryCode SaveBtn
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================
        End If


        'save_Statment()
        save_Statment()
        MsgBox("تم الحفظ " + "برقم سند " & " " & Var_Code_Esal, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


        'last_Data()
        clear_data()
        Com_Exp_No.Text = Var_Code_Esal
        find_hedar()
        find_detalis()
        'Total_Sum()
    End Sub




    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'GridView1.ShowPrintPreview()
        'On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)
        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            sql2 = "insert into TB_TempReport1  (No_Sand,No_Hfza,Date_M" & _
                " ,AccountName,TypeMove,Value_cash,Discrption) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))) & "') "
            Cnn.Execute(sql2)


        Next rowHandle

        var_open_Expensses = 1
        Rpt_Expenses.Show()
        ' ''GridView1.Columns(0).Caption = "رقم السند"
        ' ''GridView1.Columns(1).Caption = "رقم الدفترى"
        ' ''GridView1.Columns(2).Caption = "ناريخ السند "
        ' ''GridView1.Columns(3).Caption = "أسم الحساب"
        ' ''GridView1.Columns(4).Caption = "نوع الدفع"
        ' ''GridView1.Columns(5).Caption = "المبلغ"
        'GridView1.Columns(6).Caption = "العملة"
        'GridView1.Columns(7).Caption = "معامل التحويل"
        'GridView1.Columns(8).Caption = "الاجمالى"
        'GridView1.Columns(9).Caption = "رقم الشيك"
        'GridView1.Columns(10).Caption = "مسحوب على"
        'GridView1.Columns(11).Caption = "أستحقاق"
        'GridView1.Columns(12).Caption = "أسم المندوب"
        ' ''GridView1.Columns(13).Caption = "البيان"
        'GridView1.Columns(14).Caption = "نوع الدفعة"

        'GridView1.Columns(6).Visible = False
        'GridView1.Columns(7).Visible = False

        'GridView1.Columns(9).Visible = False
        'GridView1.Columns(10).Visible = False
        'GridView1.Columns(11).Visible = False
        'GridView1.Columns(12).Visible = False
        ''GridView1.Columns(12).Visible = False
        'GridView1.Columns(14).Visible = False

        'GridView1.Columns(15).Visible = False

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'GridView3.ShowPrintPreview()

        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView3.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle


            Dim var7, var8, var9, var10, var11 As String
            var7 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(7))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(7))))
            var8 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(8))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(8))))
            var9 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(9))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(9))))
            var10 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(10))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(10))))
            var11 = IIf(Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(11))) Is Nothing, "", Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(11))))


            sql2 = "insert into TB_TempReport1  (No_Hfza,No_Sand,Value_cash" & _
                " ,Cur,Tax_Value,TotalInvoice,No_Check,Date_M,BankMshob,DateAtt,DateEda3,Date_Collect) " & _
                " values (N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(0))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(1))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(3))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(4))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(5))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(6))) & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "',N'" & var10 & "',N'" & var11 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Expensses = 2
        Rpt_Expenses.Show()


    End Sub

    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt_TotalBound_GotFocus(sender As Object, e As EventArgs) Handles Txt_TotalBound.GotFocus
        'Dim testNumber As Integer
        'testNumber = Txt_TotalBound.Text
        'Dim testString As String = FormatNumber(testNumber, 2, , , TriState.True)
    End Sub

    Private Sub Txt_TotalBound_TextChanged(sender As Object, e As EventArgs) Handles Txt_TotalBound.TextChanged
        'Dim testNumber As Single
        'testNumber = Txt_TotalBound.Text
        'Dim testString As String = FormatNumber(testNumber, 2, , TriState.True)
        'Txt_TotalBound.Text = testString

        'testNumber = Format(Txt_TotalBound.Text, "#,##0.00")
        'Txt_TotalBound.Text = testNumber
    End Sub

    Private Sub txt_Cash_TextChanged(sender As Object, e As EventArgs) Handles txt_Cash.TextChanged
        On Error Resume Next
        'Dim testNumber As Single
        'testNumber = txt_Cash.Text
        'Dim testString As String = FormatNumber(testNumber, 2, , , TriState.True)
        'txt_Cash.Text = testString

        'testNumber = Format(txt_Cash.Text, "#,##0.00")
        'txt_Cash.Text = testNumber

        ''Txt_TotalBound.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 2)
        'Dim value As Decimal
        'value = txt_Cash.Text
        'Dim formattedValue As String = String.Format("{0:n}", value)
        'txt_Cash.Text = formattedValue
        Fill_Cur()
        'Txt_TotalBound.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 3)
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ColorColum()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'If RadioButton1.Checked = True Then
        clear_data()

        Com_Exp_No.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        valueSerilNo = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(15))
        find_hedar()
        find_detalis()
        'Total_Sum()
        Total_Sum2()


        Cmd_DeleteLine.Enabled = False
        Cmd_Update.Enabled = False
        cmd_Save.Enabled = False
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            'If RadioButton1.Checked = True Then
            Com_Exp_No.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            find_hedar()
            find_detalis()
            'Total_Sum()
            TabPane1.SelectedPageIndex = 0
        End If
    End Sub







    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VarOpenlookup3 = 28
        varlikename = txt_Name_Salse.Text
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()

    End Sub


    Private Sub SimpleButton11_Click_1(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        If OP1.Checked = True Then
            varcode_form = 26
            VarOpenlookup2 = 26
            Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
            Frm_LookUpCustomer.Find_Suppliser()
            Frm_LookUpCustomer.ShowDialog()

        ElseIf OP3.Checked = True Then
            varcode_form = 26
            VarOpenlookup2 = 26
            Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
            Frm_LookUpCustomer.Find_Customer()
            Frm_LookUpCustomer.ShowDialog()

        ElseIf OP2.Checked = True Then
            varcode_form = 45
            Frm_LookUpAccount.txt_AccountName.Text = txt_nameaccount.Text
            varchooseAcc = 0
            Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

            Frm_LookUpAccount.Show()
        End If
        txt_Name.Text = txt_nameaccount.Text
    End Sub

    Private Sub txt_nameaccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nameaccount.KeyDown
        If e.KeyCode = Keys.Tab Then
            Com_PayType.Select()

        End If
    End Sub

    Private Sub txt_nameaccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nameaccount.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            If OP1.Checked = True Then
                varcode_form = 26
                VarOpenlookup2 = 26
                Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
                Frm_LookUpCustomer.Find_Suppliser()
                Frm_LookUpCustomer.ShowDialog()

            ElseIf OP3.Checked = True Then
                varcode_form = 26
                VarOpenlookup2 = 26
                Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
                Frm_LookUpCustomer.Find_Customer()
                Frm_LookUpCustomer.ShowDialog()

            ElseIf OP2.Checked = True Then
                varcode_form = 45
                Frm_LookUpAccount.txt_AccountName.Text = txt_nameaccount.Text
                Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

                Frm_LookUpAccount.Show()
            End If

        End If
    End Sub






    Private Sub txt_Name_Salse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Name_Salse.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            VarOpenlookup3 = 28
            varlikename = txt_Name_Salse.Text
            Frm_LookUpSalse.Find_Salse()
            Frm_LookUpSalse.ShowDialog()

        End If
    End Sub

    Private Sub txt_Name_Salse_TextChanged(sender As Object, e As EventArgs) Handles txt_Name_Salse.TextChanged

    End Sub



    Private Sub txt_Expenses_Date_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Expenses_Date.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            txt_Name_Salse.Select()
        End If


    End Sub



    Private Sub Com_Exp_No_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Com_Exp_No.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            txt_Expenses_Date.Select()
        End If
    End Sub

    Private Sub txt_Expenses_Date_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_Expenses_Date.MaskInputRejected

    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs) Handles txt_nameaccount.TextChanged

    End Sub

    Private Sub Txt_AccountName2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_AccountName2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If Com_PayType.Text = "" Then MsgBox("من فضلك ادخل نوع الدفع  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

            If Com_PayType.Text = "نقدى" Then
                varcode_form = 46
                Frm_LookUpAccount.Fill_AccBox()
                Frm_LookUpAccount.Show()

            ElseIf Com_PayType.Text = "شيك" Then
                varcode_form = 47
                Frm_LookUpAccount.Fill_AccDfa()
                Frm_LookUpAccount.Show()

            End If
        End If
    End Sub


    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        'last_Data()
        clear_data()
        get_BoxCash()
        find_detalis()
        cmd_Save.Enabled = True
        Cmd_DeleteLine.Enabled = False
        Cmd_Update.Enabled = False

    End Sub

    Private Sub cmd_Save_Click_1(sender As Object, e As EventArgs) Handles cmd_Save.Click
        'Dim dd4 As DateTime = txt_Expenses_Date.Text
        'Dim vardate4 As String
        'vardate4 = dd4.ToString("dd/MM/yyyy")
        ''=======================================================
        'Dim dd3 As DateTime = var_GetDateLive
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM/dd/yyyy")
        'If vardate3 <> vardate4 Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=========================================================

        save_data()
        Total_Sum2()
    End Sub

    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs)
        '========================================================رقم العملة
        'sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_Cru = rs("code").Value
        ''=====================================================
        ''=============رقم مركز التكلفة1
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & Txt_AccountNo2.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter1 = rs2("Account_NoCostCenter").Value
        ''=============================

        ''=============رقم مركز التكلفة2
        'sql = "  SELECT     *     FROM dbo.Vw_AllCostCenterAccount    WHERE(Account_No = '" & Txt_AccountNo2.Text & "')  and Compny_Code ='" & VarCodeCompny & "'"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then varcodeCostCenter2 = rs2("Account_NoCostCenter").Value
        ''=============================

        ''============================================تاريخ السند
        'Dim dd As DateTime = txt_Expenses_Date.Text
        'Dim vardate As String
        'vardate = dd.ToString("MM-d-yyyy")
        'sql = "UPDATE  TB_Expenses  SET AccountNo1 ='" & txt_AccountNo.Text & "',AccountNo2 ='" & Txt_AccountNo2.Text & "',Notes ='" & txt_Notes.Text & "',Expenses_Date ='" & vardate & "',Expenses_Value ='" & txt_Cash.Text & "',Debit ='" & txt_Cash.Text & "' WHERE Expenses_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)


        ''===================================UpdateGL
        'sql = "UPDATE  Genralledger  SET CodeLevel4 ='" & txt_AccountNo.Text & "',Debit ='" & txt_Cash.Text & "',  DateM ='" & vardate & "',CostCenterNo ='" & varcodeCostCenter1 & "',CruunceyNo ='" & varcode_Cru & "',Debit_EGP='" & Txt_TotalBound.Text & "',rat='" & txt_rat.Text & "',DisTable='" & txt_Notes.Text & "'  WHERE IDGenral = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' and Typebill ='" & 4 & "' and No_serail ='" & varid & "'  "
        'rs = Cnn.Execute(sql)
        'sql = "UPDATE  Genralledger  SET CodeLevel4 ='" & Txt_AccountNo2.Text & "',Cridit ='" & txt_Cash.Text & "',  DateM ='" & vardate & "',CostCenterNo ='" & varcodeCostCenter2 & "',CruunceyNo ='" & varcode_Cru & "',Debit_EGP='" & Txt_TotalBound.Text & "',rat='" & txt_rat.Text & "',DisTable='" & txt_Notes.Text & "'  WHERE IDGenral = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' and Typebill ='" & 4 & "' and No_serail ='" & varid & "'  "
        'rs = Cnn.Execute(sql)
        ''=====================================================


        ''===================================UpdateStatmentMove
        'sql = "UPDATE  MovmentStatement  SET AccountNo ='" & txt_AccountNo.Text & "',Debit ='" & txt_Cash.Text & "',  DateMoveM ='" & vardate & "',CostCenterNo ='" & varcodeCostCenter1 & "',CruunceyNo ='" & varcode_Cru & "',Debit_EGP='" & Txt_TotalBound.Text & "',Rat_Cur='" & txt_rat.Text & "',Discription='" & txt_Notes.Text & "'  WHERE NumberBill = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 4 & "' and Serail_lNo ='" & varid & "'  "
        'rs = Cnn.Execute(sql)
        'sql = "UPDATE  MovmentStatement  SET AccountNo ='" & Txt_AccountNo2.Text & "',Cridit ='" & txt_Cash.Text & "',  DateMoveM ='" & vardate & "',CostCenterNo ='" & varcodeCostCenter2 & "',CruunceyNo ='" & varcode_Cru & "',Debit_EGP='" & Txt_TotalBound.Text & "',Rat_Cur='" & txt_rat.Text & "',Discription='" & txt_Notes.Text & "'  WHERE NumberBill = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' and TypeBill ='" & 4 & "' and Serail_lNo ='" & varid & "'  "
        'rs = Cnn.Execute(sql)
        ''=====================================================



        'MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        'find_detalis()
    End Sub



    Sub delete_Recored()
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد الحذف ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Expenses  WHERE Expenses_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)

                sql = "UPDATE   Genralledger   SET flgcancle = '" & 1 & "' WHERE Typebill ='" & 4 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "'   "
                rs = Cnn.Execute(sql)


                sql = "Delete MovmentStatement  WHERE NumberBill = '" & Com_Exp_No.Text & "' and TypeBill = '" & 4 & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "'  "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode DeleteRowBtn
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                'Total_Sum()
        End Select
    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        txt_NoSeril.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        Txt_AccountNo2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Txt_AccountName2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        'txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))
        txt_Cash.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))

        txt_BankeIN.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        Txt_CheckNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        DateTimePicker1.Value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        Com_PayType.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(10))
        txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        find_hedar()
        txt_AccountNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))

        varid = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        varseril_No = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))


        '==============================================اظهار الحساب
        txt_AccountNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(12))
        sql = "Select AccountName    FROM dbo.ST_CHARTOFACCOUNT WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Account_No = '" & txt_AccountNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_nameaccount.Text = rs("AccountName").Value Else txt_nameaccount.Text = ""
        '=====================================================

        Cmd_DeleteLine.Enabled = True
        Cmd_Update.Enabled = True
        cmd_Save.Enabled = True

    End Sub




    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next


        'Dim dd4 As DateTime = txt_Expenses_Date.Text
        'Dim vardate4 As String
        'vardate4 = dd4.ToString("dd/MM/yyyy")
        ''=======================================================
        'Dim dd3 As DateTime = var_GetDateLive
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM/dd/yyyy")
        'If vardate3 <> vardate4 Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=========================================================





        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد الغاء الاذن ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                'sql = "Delete TB_Expenses  WHERE Expenses_No = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                'rs = Cnn.Execute(sql)

                sql = "UPDATE  TB_Expenses  SET flg = '" & 1 & "'  WHERE Expenses_No = " & Com_Exp_No.Text & "  and Code_Branch ='" & varCodeBranch & "'   "
                rs = Cnn.Execute(sql)

                sql = "UPDATE   Genralledger   SET flg = '" & 0 & "'WHERE Typebill ='" & 4 & "'and No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "'  and Compny_Code ='" & VarCodeCompny & "' and  code_sub ='" & varCodeBranch & "'  "
                rs = Cnn.Execute(sql)

                'sql = "Delete Genralledger  WHERE No_Sand = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Typebill='" & 4 & "' "
                'rs = Cnn.Execute(sql)

                sql = "Delete MovmentStatement  WHERE NumberBill = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' and Typebill='" & 4 & "' and  code_sub ='" & varCodeBranch & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode CancelBtn
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','5','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================


                MsgBox(" تم الغاء الاذن", MsgBoxStyle.Information, "Css Solution Software Module")

                'last_Data()
                Find_Data()
                'clear_data()
                'find_detalis()
                Total_Sum2()
                'Total_Sum()
        End Select
    End Sub


    Private Sub Cmd_printPreview_Click(sender As Object, e As EventArgs) Handles Cmd_printPreview.Click
        varesal_Type = 1
        'Total_Sum2()
        Var_TF_Amount = NoToTxt(txt_TotalEsal.Text, "جنيها مصريا", "قرش")
        'sql = "update TB_Expenses set tt2='" & Var_TF_Amount & "'  WHERE Expenses_No = '" & Com_Exp_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        Rpt_Sarf.Show()


    End Sub


    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        'delete_Recored()

        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل التاريخ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If IsDate(txt_Expenses_Date.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_No_Salse.Text) = 0 Then MsgBox("من فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_Notes.Select() : Exit Sub



        'sql = "Delete TB_Expenses  WHERE Expenses_No = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        'sql = "Delete Genralledger  WHERE No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        'sql = "Delete MovmentStatement  WHERE NumberBill = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        'Dim dd4 As DateTime = txt_Expenses_Date.Text
        'Dim vardate4 As String
        'vardate4 = dd4.ToString("dd/MM/yyyy")
        ''=======================================================
        'Dim dd3 As DateTime = var_GetDateLive
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM/dd/yyyy")
        'If vardate3 <> vardate4 Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=========================================================


        ''=======================================================

        '============================================تاريخ السند
        Dim dd As DateTime = txt_Expenses_Date.Text
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

        '        sql = "INSERT INTO TB_Expenses (Expenses_No, Expenses_Date,Id_User,Expenses_Value,Notes,AccountNo1,AccountNo2,CruunceyNo,Compny_Code,Code_Salse,rat,Expenses_Value_EGP,Invoice_No,Type_Invoice,Check_No,Bank_IN,Date_Asthkak,TypePay,Hfza_No,Serail_lNo,Name) " & _
        '" values  (" & Com_Exp_No.Text & " ,'" & vardate & "','" & 1 & "','" & txt_Cash.Text & "','" & txt_Notes.Text & "','" & txt_AccountNo.Text & "','" & Txt_AccountNo2.Text & "','" & varcode_Cru & "','" & VarCodeCompny & "','" & txt_No_Salse.Text & "','" & txt_rat.Text & "', '" & Txt_TotalBound.Text & "' , '" & Com_InvoiceNo.Text & "','" & VarType() & "','" & Txt_CheckNo.Text & "','" & txt_BankeIN.Text & "','" & vardate2 & "','" & VarType2 & "','" & varhfza & "','" & varseril_No & "','" & txt_Name.Text & "')"
        '        Cnn.Execute(sql)
        '        '====================================================save Hafza

        '        sql = "INSERT INTO TB_HafzaExpenses (Hfza_No,Expenses_No, Check_No,Compny_Code) " & _
        '        " values  (" & varhfza & ",'" & Com_Exp_No.Text & "','" & Txt_CheckNo.Text & "' ,'" & VarCodeCompny & "')"



        Dim VarType, VarType2 As Integer
        If com_Type.Text = "فاتورة" Then VarType = 0
        If com_Type.Text = "دفعة مقدمة" Then VarType = 1

        If Com_PayType.Text = "نقدى" Then VarType2 = 0
        If Com_PayType.Text = "شيك" Then VarType2 = 1
        '=======================================التعديل على الملف
        sql = "UPDATE  TB_Expenses  SET flg=0,  No_Dftr='" & Txt_NoDftr.Text & "', Expenses_Date ='" & vardate & "' , Expenses_Value ='" & txt_Cash.Text & "' ,Notes ='" & txt_Notes.Text & "',AccountNo2 ='" & Txt_AccountNo2.Text & "',AccountNo1='" & txt_AccountNo.Text & "',CruunceyNo ='" & varcode_Cru & "',Debit = '" & txt_Cash.Text & "',Code_Salse='" & txt_No_Salse.Text & "',rat ='" & txt_rat.Text & "',Expenses_Value_EGP ='" & Txt_TotalBound.Text & "',Type_Invoice ='" & VarType & "' ,Check_No ='" & Txt_CheckNo.Text & "',Date_Asthkak ='" & vardate2 & "',TypePay ='" & VarType2 & "',Bank_IN ='" & txt_BankeIN.Text & "',Name ='" & txt_Name.Text & "'  WHERE Expenses_No = '" & Com_Exp_No.Text & "' and Compny_Code ='" & VarCodeCompny & "'  and Serail_lNo ='" & txt_NoSeril.Text & "' and  Code_Branch ='" & varCodeBranch & "'"
        rs = Cnn.Execute(sql)
        '=================================================


        '============================== TransactionHistoryCode EditRowBtn
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','4','3','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_Exp_No.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================


        find_hedar()
        find_detalis()


        sql = "Delete Genralledger  WHERE No_Sand = '" & Com_Exp_No.Text & "' and No_serail ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete MovmentStatement  WHERE NumberBill = '" & Com_Exp_No.Text & "' and Serail_lNo ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)

        save_Statment()
        Total_Sum2()

        MsgBox("تم التعديل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

    End Sub

    Private Sub Cmd_DeleteLine_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteLine.Click
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم السند ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Exp_No.Text) = 0 Then MsgBox("من فضلك ادخل التاريخ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If IsDate(txt_Expenses_Date.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_No_Salse.Text) = 0 Then MsgBox("من فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Type.Text) = 0 Then MsgBox("من فضلك ادخل نوع الدفعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "شيك" Then
            If Len(Txt_CheckNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشيك  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
            If Len(txt_BankeIN.Text) = 0 Then MsgBox("من فضلك ادخل البنك المسحوب عليه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        End If
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_Notes.Select() : Exit Sub


        'Dim dd4 As DateTime = txt_Expenses_Date.Text
        'Dim vardate4 As String
        'vardate4 = dd4.ToString("dd/MM/yyyy")
        ''=======================================================
        'Dim dd3 As DateTime = var_GetDateLive
        'Dim vardate3 As String
        'vardate3 = dd3.ToString("MM/dd/yyyy")
        'If vardate3 <> vardate4 Then MsgBox("الاذن فى تاريخ مختلف غير تاريخ اليوم لايمكن تنفيذ اى أجراء عليه  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=========================================================

        delete_Recored()
        find_detalis()
        Total_Sum2()
    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Com_PayType.Text = "" Then MsgBox("من فضلك ادخل نوع الدفع  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Com_PayType.Text = "نقدى" Then
            varcode_form = 46
            Frm_LookUpAccount.Fill_AccBox()
            Frm_LookUpAccount.Show()

        ElseIf Com_PayType.Text = "شيك" Then
            varcode_form = 47
            Frm_LookUpAccount.Fill_AccDfa()
            Frm_LookUpAccount.Show()

        ElseIf Com_PayType.Text = "تحويل بنكى" Then
            varcode_form = 47047
            Frm_LookUpAccount.Fill_AccBank()
            Frm_LookUpAccount.Show()

        End If
    End Sub

    Private Sub Cmd_OpenCostcenter_Click(sender As Object, e As EventArgs) Handles Cmd_OpenCostcenter.Click
        vartable = "Vw_CostcenterAll"
        VarOpenlookup = 3023
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton5_Click_2(sender As Object, e As EventArgs) Handles SimpleButton5.Click
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

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Com_GL.Text = ""
        Com_GL.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 4) AND (Code_Sub = '" & varCodeBranch & "') AND (No_Sand = '" & Com_Exp_No.Text & "') and flgcancle = '" & 0 & "'  "
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



    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle

        txt_FinCheck.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(6))
        VarvalueCash = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        DateTimePicker4.Value = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))
        Com_status.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(12))
        varcur = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))



        'If RadioButton1.Checked = True Then
        clear_data()

        Com_Exp_No.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        'valueSerilNo = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(15))
        find_hedar()
        find_detalis()
        'Total_Sum()
        Total_Sum2()


        Cmd_DeleteLine.Enabled = False
        Cmd_Update.Enabled = False
        cmd_Save.Enabled = False
        TabPane1.SelectedPageIndex = 0
    End Sub



    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        If Com_status.Text = "صرف الشيك" Then
            varcode_form = 5005
            Frm_LookUpAccount.Fill_AccBank()
            Frm_LookUpAccount.Show()
        End If
    End Sub


    Private Sub Cmd_save2_Click(sender As Object, e As EventArgs) Handles Cmd_save2.Click
        'If varstatsuschek = "صرف الشيك" And Com_status.Text = "ارتجاع شيك" Then MsgBox("غير متاح اختيار ارتجاع الشيك حالة الشيك تحصيل", MsgBoxStyle.Critical, "Cerative smart software") : Exit Sub
        If Com_Bank.Text = "" Then MsgBox("من فضلك اختار اسم البنك", MsgBoxStyle.Critical, "Cerative smart software") : Exit Sub

        '==================================الاختيار
        sql2 = "SELECT Name, Code    FROM dbo.TB_StatusChack WHERE  (Name = '" & Com_status.Text & "') and flg = '2' "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varstatus = rs("code").Value
        '============================================================تعديل الحالة 



        '======================================================== اوراق الدفع حساب
        sql3 = " SELECT Check_No, AccountNo2       FROM dbo.TB_Expenses WHERE  (Check_No = '" & txt_FinCheck.Text & "') and code_branch ='" & varCodeBranch & "'"
        rs3 = Cnn.Execute(sql3)
        If rs3.EOF = False Then Varacc1 = rs3("AccountNo2").Value


        lastgl()
        Dim dd3 As DateTime = DateTimePicker4.Value
        Dim vardate As String
        vardate = dd3.ToString("MM-d-yyyy")
        '=================================Account1

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & varcur & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value




        '=======================================التعديل على تاريخ صرف الشيك
        sql = "UPDATE  TB_Expenses  SET Date_Asthkak ='" & vardate & "'  WHERE Check_No = '" & txt_FinCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        '=================================================



        If Com_status.Text = "صرف الشيك" Then 'من حساب اوراق الدفع الى حساب البنك 
            sql = "UPDATE   TB_HafzaExpenses   SET AccountNoBank ='" & Txt_AccountNoBank.Text & "', Status = '" & varstatus & "'  where   Check_No = '" & txt_FinCheck.Text & "' and code_branch ='" & varCodeBranch & "' "
            Cnn.Execute(sql)

        ElseIf Com_status.Text = "ارتداد شيك" Then ' من حساب المورد الى اوراق الدفع
            sql = "UPDATE   TB_HafzaExpenses   SET  Status = '" & varstatus & "'  where   Check_No = '" & txt_FinCheck.Text & "' and code_branch ='" & varCodeBranch & "' "
            Cnn.Execute(sql)

        End If




        If varstatus = 4 Then  'صرف شيك


            ''================================================== حساب شيكات تحت التحصيل
            'sql3 = "   SELECT * FROM     dbo.ST_CHARTOFACCOUNT"
            'rs3 = Cnn.Execute(sql3)
            'If rs3.EOF = False Then Varacc2 = rs3("Account_No").Value
            ''============================================


            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 17 & "' and No_Sand = '" & txt_FinCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)

            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & txt_FinCheck.Text & "'  and Typebill ='" & 17 & "'  and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)




            '=======================================================GL المدين
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc1 & "','" & "صرف شيك " + "  " + txt_FinCheck.Text & "','" & VarvalueCash & "' ,'" & 0 & "','" & 17 & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & VarvalueCash & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
            '=======================================================GL الدائن
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Txt_AccountNoBank.Text & "','" & "صرف شيك " + "  " + txt_FinCheck.Text & "','" & 0 & "' ,'" & VarvalueCash & "','" & 17 & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & VarvalueCash & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)



            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
                " values  (N'" & varseril_No & "',N'" & txt_FinCheck.Text & "' ,N'" & vardate & "',N'" & Varacc1 & "',N'" & "صرف شيك " + "  " + txt_FinCheck.Text & "',N'" & VarvalueCash & "',N'" & 0 & "',N'" & "17" & "',N'" & "0" & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & varcode_Cru & "','" & VarvalueCash & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            '=================================الدائن

            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
          " values  (N'" & varseril_No & "',N'" & txt_FinCheck.Text & "' ,N'" & vardate & "',N'" & Txt_AccountNoBank.Text & "',N'" & "صرف شيك " + "  " + txt_FinCheck.Text & "',N'" & 0 & "',N'" & VarvalueCash & "',N'" & "17" & "',N'" & "0" & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & varcode_Cru & "','" & 0 & "','" & VarvalueCash & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            MsgBox("تم الحفظ " + "برقم شيك " & " " & txt_FinCheck.Text, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
            Find_Hafza()

        End If




        If varstatus = 5 Then  'ارتداد شيك


            ''================================================== حساب المرد او الخزينة
            'sql3 = "   SELECT * FROM     dbo.ST_CHARTOFACCOUNT"
            sql3 = "  SELECT Check_No, AccountNo1         FROM dbo.TB_Expenses WHERE  (Check_No = '" & txt_FinCheck.Text & "') AND (Code_Branch = '" & varCodeBranch & "')"
            rs3 = Cnn.Execute(sql3)
            If rs3.EOF = False Then Varacc2 = rs3("AccountNo1").Value
            ''============================================


            sql = "Delete MovmentStatement  WHERE TypeBill ='" & 18 & "' and No_Sand = '" & txt_FinCheck.Text & "' and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)

            sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & txt_FinCheck.Text & "'  and Typebill ='" & 18 & "'  and Compny_Code ='" & VarCodeCompny & "' and Code_Sub ='" & varCodeBranch & "' "
            rs = Cnn.Execute(sql)




            '=======================================================GL المدين
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc1 & "','" & "ارتداد شيك " + "  " + txt_FinCheck.Text & "','" & VarvalueCash & "' ,'" & 0 & "','" & 18 & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & VarvalueCash & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)
            '=======================================================GL الدائن
            sql = "INSERT INTO Genralledger (No_serail,IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
            " values  ('" & varseril_No & "','" & varNoGL & "' ,'" & vardate & "','" & Varacc2 & "','" & "ارتداد شيك " + "  " + txt_FinCheck.Text & "','" & 0 & "' ,'" & VarvalueCash & "','" & 18 & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & txt_Code_Costcenter.Text & "' ,'" & varcode_Cru & "','" & 0 & "' ,'" & VarvalueCash & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
            Cnn.Execute(sql)



            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
                " values  (N'" & varseril_No & "',N'" & txt_FinCheck.Text & "' ,N'" & vardate & "',N'" & Varacc1 & "',N'" & "ارتداد شيك " + "  " + txt_FinCheck.Text & "',N'" & VarvalueCash & "',N'" & 0 & "',N'" & "18" & "',N'" & "0" & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & varcode_Cru & "','" & VarvalueCash & "','" & 0 & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            '=================================الدائن

            sql = "INSERT INTO MovmentStatement (Serail_lNo,NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,Stat,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,CostCenterNo,Rat_Cur) " & _
          " values  (N'" & varseril_No & "',N'" & txt_FinCheck.Text & "' ,N'" & vardate & "',N'" & Varacc2 & "',N'" & "ارتداد شيك " + "  " + txt_FinCheck.Text & "',N'" & 0 & "',N'" & VarvalueCash & "',N'" & "18" & "',N'" & "0" & "','" & txt_FinCheck.Text & "','" & varCodeBranch & "','" & varcode_Cru & "','" & 0 & "','" & VarvalueCash & "','" & VarCodeCompny & "','" & txt_Code_Costcenter.Text & "','" & txt_rat.Text & "' )"
            Cnn.Execute(sql)

            MsgBox("تم الحفظ " + "برقم شيك " & " " & txt_FinCheck.Text, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
            Find_Hafza()

        End If
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Com_GLNo.Text = ""
        Com_GLNo.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger where   (Code_Sub = '" & varCodeBranch & "') AND (No_Sand = '" & txt_FinCheck.Text & "') AND (flgcancle = '0') GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 17)  or (Typebill = 18)    "
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
        Frm_Gl4.TabPane1.SelectedPageIndex = 0
        Frm_Gl4.Show()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub Com_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_status.SelectedIndexChanged
        If Com_status.Text = "صرف الشيك" Then SimpleButton9.Enabled = True Else SimpleButton9.Enabled = False
        Txt_AccountNoBank.Text = ""
        Com_Bank.Text = ""
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub txt_BankeIN_GotFocus(sender As Object, e As EventArgs) Handles txt_BankeIN.GotFocus

        fill_Bank()



    End Sub

    Private Sub txt_BankeIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_BankeIN.SelectedIndexChanged

    End Sub

    Private Sub Txt_NoDftr_Click(sender As Object, e As EventArgs) Handles Txt_NoDftr.Click
        fill_Bank()
    End Sub

    Private Sub Txt_NoDftr_TextChanged(sender As Object, e As EventArgs) Handles Txt_NoDftr.TextChanged

    End Sub
End Class