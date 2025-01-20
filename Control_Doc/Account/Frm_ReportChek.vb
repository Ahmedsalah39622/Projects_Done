Imports System.Data.OleDb

Public Class Frm_ReportChek
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        Wared_Bank()
    End Sub
    Sub Find_Hafza_Estlam()


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






        sql2 = "SELECT        dbo.TB_HafzaRecipt.Hfza_No, dbo.TB_HafzaRecipt.Receipt_No, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Bank_IN,  " & _
        "                         dbo.TB_Receipt.Date_Asthkak, dbo.TB_StatusChack.Name  " & _
        " FROM            dbo.TB_Receipt INNER JOIN " & _
        "                         dbo.TB_HafzaRecipt ON dbo.TB_Receipt.Hfza_No = dbo.TB_HafzaRecipt.Hfza_No AND dbo.TB_Receipt.Receipt_No = dbo.TB_HafzaRecipt.Receipt_No AND  " & _
        "                         dbo.TB_Receipt.Compny_Code = dbo.TB_HafzaRecipt.Compny_Code AND dbo.TB_Receipt.Check_No = dbo.TB_HafzaRecipt.Check_No INNER JOIN " & _
        "                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_HafzaRecipt.AccountNoBank = ST_CHARTOFACCOUNT_1.Account_No_Update AND  " & _
        "                         dbo.TB_HafzaRecipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.TB_StatusChack ON dbo.TB_HafzaRecipt.Flg_Stutascheck = dbo.TB_StatusChack.Code LEFT OUTER JOIN " & _
        "                         dbo.TB_StatusChack_EdA ON dbo.TB_HafzaRecipt.Flg_Stutas = dbo.TB_StatusChack_EdA.Code " & _
        " WHERE        (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaRecipt.Compny_Code = '" & VarCodeCompny & "') and TB_HafzaRecipt.Status= 0   and TB_HafzaRecipt.Flg_Stutascheck= 0 "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)





        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.BestFitColumns()


        GridView9.Columns(0).Caption = "رقم الحافظة"
        GridView9.Columns(1).Caption = "رقم السند "
        GridView9.Columns(2).Caption = "المبلغ "
        GridView9.Columns(3).Caption = "رقم الشيك"
        GridView9.Columns(4).Caption = "تاريخ الاستلام"
        GridView9.Columns(5).Caption = "البنك المسحوب عليه"
        GridView9.Columns(6).Caption = "تاريخ الاستحقاق"
        GridView9.Columns(7).Caption = "نوع الحركة"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView9.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub

    Sub Find_Hafza_Mohsal()


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






        sql2 = "SELECT        dbo.TB_HafzaRecipt.Hfza_No, dbo.TB_HafzaRecipt.Receipt_No, dbo.TB_Receipt.Receipt_Value_EGP, dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_Receipt.Bank_IN,  " & _
        "                         dbo.TB_Receipt.Date_Asthkak, dbo.TB_StatusChack.Name  " & _
        " FROM            dbo.TB_Receipt INNER JOIN " & _
        "                         dbo.TB_HafzaRecipt ON dbo.TB_Receipt.Hfza_No = dbo.TB_HafzaRecipt.Hfza_No AND dbo.TB_Receipt.Receipt_No = dbo.TB_HafzaRecipt.Receipt_No AND  " & _
        "                         dbo.TB_Receipt.Compny_Code = dbo.TB_HafzaRecipt.Compny_Code AND dbo.TB_Receipt.Check_No = dbo.TB_HafzaRecipt.Check_No INNER JOIN " & _
        "                         dbo.BD_Currency ON dbo.TB_Receipt.CruunceyNo = dbo.BD_Currency.Code AND dbo.TB_Receipt.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_HafzaRecipt.AccountNoBank = ST_CHARTOFACCOUNT_1.Account_No_Update AND  " & _
        "                         dbo.TB_HafzaRecipt.Compny_Code = ST_CHARTOFACCOUNT_1.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.TB_StatusChack ON dbo.TB_HafzaRecipt.Flg_Stutascheck = dbo.TB_StatusChack.Code LEFT OUTER JOIN " & _
        "                         dbo.TB_StatusChack_EdA ON dbo.TB_HafzaRecipt.Flg_Stutas = dbo.TB_StatusChack_EdA.Code " & _
        " WHERE        (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (dbo.TB_HafzaRecipt.Compny_Code = '" & VarCodeCompny & "') and TB_HafzaRecipt.Status= 1   and TB_HafzaRecipt.Flg_Stutascheck= 1 "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)

        'GridView11.Columns(0).Width = "50"
        'GridView11.Columns(1).Width = "70"
        'GridView11.Columns(2).Width = "100"
        'GridView11.Columns(3).Width = "100"
        'GridView11.Columns(4).Width = "100"
        'GridView11.Columns(5).Width = "200"
        'GridView11.Columns(6).Width = "100"
        'GridView11.Columns(7).Width = "100"





        GridView11.Appearance.Row.Font = New Font(GridView11.Appearance.Row.Font, FontStyle.Bold)
        GridView11.Appearance.Row.Options.UseFont = True

        GridView11.BestFitColumns()

        GridView11.Columns(0).Caption = "رقم الحافظة"
        GridView11.Columns(1).Caption = "رقم السند "
        GridView11.Columns(2).Caption = "المبلغ "
        GridView11.Columns(3).Caption = "رقم الشيك"
        GridView11.Columns(4).Caption = "تاريخ الاستلام"
        GridView11.Columns(5).Caption = "البنك المسحوب عليه"
        GridView11.Columns(6).Caption = "تاريخ الاستحقاق"
        GridView11.Columns(7).Caption = "نوع الحركة"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView11.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub
    Sub Wared_Bank()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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



        sql2 = " SELECT        dbo.TB_HafzaRecipt.Hfza_No, dbo.TB_HafzaRecipt.Receipt_No, dbo.TB_Receipt.Receipt_Date, dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Date_Asthkak, dbo.TB_Receipt.Bank_IN, dbo.TB_Receipt.Notes, " & _
            "                         dbo.TB_Receipt.Receipt_Value_EGP, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS Customer, RTRIM(dbo.Vw_Emp.Emp_Name) AS Salse " & _
 " FROM            dbo.TB_HafzaRecipt INNER JOIN " & _
 "                        dbo.TB_Receipt ON dbo.TB_HafzaRecipt.Receipt_No = dbo.TB_Receipt.Receipt_No AND dbo.TB_HafzaRecipt.Compny_Code = dbo.TB_Receipt.Compny_Code AND  " & _
 "                        dbo.TB_HafzaRecipt.Hfza_No = dbo.TB_Receipt.Hfza_No INNER JOIN " & _
 "                        dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No INNER JOIN " & _
 "                        dbo.Vw_Emp ON dbo.TB_Receipt.Code_Salse = dbo.Vw_Emp.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Vw_Emp.Compny_Code " & _
            " WHERE        (dbo.TB_HafzaRecipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Receipt_Date <= CONVERT(DATETIME,'" & vardate2 & "', 102)) "





        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "100"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "200"
        'GridView1.Columns(6).Width = "200"
        'GridView1.Columns(7).Width = "150"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم الحافظة"
        GridView1.Columns(1).Caption = "رقم السند "
        GridView1.Columns(2).Caption = "تاريخ السند"
        GridView1.Columns(3).Caption = "رقم الشيك"
        GridView1.Columns(4).Caption = "تاريخ الاستحقاق"
        GridView1.Columns(5).Caption = "البنك المسحوب عليه"
        GridView1.Columns(6).Caption = "البيان"
        GridView1.Columns(7).Caption = "المبلغ"
        GridView1.Columns(8).Caption = "أسم الحساب"
        GridView1.Columns(9).Caption = "المندوب"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub



    Sub Mnsrf_Bank()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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


        sql2 = "      SELECT        dbo.TB_HafzaExpenses.Hfza_No, dbo.TB_HafzaExpenses.Expenses_No, dbo.TB_Expenses.Expenses_Date, dbo.TB_HafzaExpenses.Check_No, dbo.TB_Expenses.Date_Asthkak, dbo.TB_Expenses.Bank_IN,  " & _
      "                         dbo.TB_Expenses.Notes, dbo.TB_Expenses.Expenses_Value_EGP, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS Customer, RTRIM(dbo.Vw_Emp.Emp_Name) AS Salse " & _
      " FROM            dbo.TB_HafzaExpenses INNER JOIN " & _
      "                         dbo.TB_Expenses ON dbo.TB_HafzaExpenses.Expenses_No = dbo.TB_Expenses.Expenses_No AND dbo.TB_HafzaExpenses.Compny_Code = dbo.TB_Expenses.Compny_Code AND  " & _
      "                         dbo.TB_HafzaExpenses.Hfza_No = dbo.TB_Expenses.Hfza_No INNER JOIN " & _
      "                         dbo.Vw_Emp ON dbo.TB_Expenses.Code_Salse = dbo.Vw_Emp.Emp_Code AND dbo.TB_Expenses.Compny_Code = dbo.Vw_Emp.Compny_Code LEFT OUTER JOIN " & _
      "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expenses.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.TB_Expenses.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
      " WHERE        (dbo.TB_HafzaExpenses.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Expenses.Expenses_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Expenses.Expenses_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridView3.Columns(0).Width = "100"
        'GridView3.Columns(1).Width = "100"
        'GridView3.Columns(2).Width = "100"
        'GridView3.Columns(3).Width = "100"
        'GridView3.Columns(4).Width = "100"
        'GridView3.Columns(5).Width = "200"
        'GridView3.Columns(6).Width = "200"
        'GridView3.Columns(7).Width = "150"
        'GridView3.Columns(8).Width = "100"
        'GridView3.Columns(9).Width = "100"


        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.BestFitColumns()


        GridView3.Columns(0).Caption = "رقم الحافظة"
        GridView3.Columns(1).Caption = "رقم السند "
        GridView3.Columns(2).Caption = "تاريخ السند"
        GridView3.Columns(3).Caption = "رقم الشيك"
        GridView3.Columns(4).Caption = "تاريخ الاستحقاق"
        GridView3.Columns(5).Caption = "البنك المسحوب عليه"
        GridView3.Columns(6).Caption = "البيان"
        GridView3.Columns(7).Caption = "المبلغ"
        GridView3.Columns(8).Caption = "أسم الحساب"
        GridView3.Columns(9).Caption = "المندوب"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView3.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Sub Asthkak_Bank()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
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




        sql2 = " SELECT        dbo.TB_HafzaRecipt.Check_No, dbo.TB_Receipt.Date_Asthkak, dbo.TB_Receipt.Bank_IN, dbo.TB_Receipt.Receipt_Value_EGP, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS Customer,  " & _
             "                         RTRIM(dbo.Vw_Emp.Emp_Name) AS Salse " & _
             " FROM            dbo.TB_HafzaRecipt INNER JOIN " & _
             "                         dbo.TB_Receipt ON dbo.TB_HafzaRecipt.Receipt_No = dbo.TB_Receipt.Receipt_No AND dbo.TB_HafzaRecipt.Compny_Code = dbo.TB_Receipt.Compny_Code AND  " & _
             "                         dbo.TB_HafzaRecipt.Hfza_No = dbo.TB_Receipt.Hfza_No INNER JOIN " & _
             "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Receipt.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.TB_Receipt.AccountNo1 = dbo.ST_CHARTOFACCOUNT.Account_No_Update INNER JOIN " & _
             "                          dbo.Vw_Emp ON dbo.TB_Receipt.Code_Salse = dbo.Vw_Emp.Emp_Code AND dbo.TB_Receipt.Compny_Code = dbo.Vw_Emp.Compny_Code " & _
             " WHERE        (dbo.TB_HafzaRecipt.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Receipt.Date_Asthkak >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Receipt.Date_Asthkak <= CONVERT(DATETIME,  '" & vardate2 & "', 102)) "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)
        'GridView5.Columns(0).Width = "100"
        'GridView5.Columns(1).Width = "100"
        'GridView5.Columns(2).Width = "200"
        'GridView5.Columns(3).Width = "100"
        'GridView5.Columns(4).Width = "200"
        'GridView5.Columns(5).Width = "200"


        GridView5.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.BestFitColumns()

        GridView5.Columns(0).Caption = "رقم الشيك"
        GridView5.Columns(1).Caption = "تاريخ الاستحقاق"
        GridView5.Columns(2).Caption = "البنك المسحوب عليه"
        GridView5.Columns(3).Caption = "المبلغ"
        GridView5.Columns(4).Caption = "أسم الحساب"
        GridView5.Columns(5).Caption = "المندوب"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView5.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Mnsrf_Bank()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Asthkak_Bank()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Find_Hafza_Estlam()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Find_Hafza_Mohsal()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'GridView1.ShowPrintPreview()
        On Error Resume Next
        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


            Dim var7, var8, var9, var10 As String
            var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
            var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))


            sql2 = "insert into TB_TempReport1  (No_Hfza,No_Sand,Date_M" & _
                " ,No_Check,DateAtt,BankMshob,Discrption,Value_cash,AccountName,NameEmp) " & _
                " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Recipt = 4

     


        Rpt_Recipt1.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
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


            sql2 = "insert into TB_TempReport1  (No_Hfza,No_Sand,Date_M" & _
                " ,No_Check,DateAtt,BankMshob,Discrption,Value_cash,AccountName,NameEmp) " & _
                " values (N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(0))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(1))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(2))) & "' " & _
                " ,N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(3))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(4))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(5))) & "',N'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(6))) & "',N'" & var7 & "',N'" & var8 & "',N'" & var9 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_Recipt = 5




        Rpt_Recipt1.Show()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GridView5.ShowPrintPreview()

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        GridView9.ShowPrintPreview()

    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        GridView11.ShowPrintPreview()

    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        GridView13.ShowPrintPreview()

    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        GridView15.ShowPrintPreview()

    End Sub
End Class