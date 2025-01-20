Imports System.Data.OleDb

Public Class Frm_Check_Report
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim vardate As String
    Dim vardate2, vardatetest1, vardatetest2 As String
    Private Sub Frm_Check_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub Mnsrf_Bank()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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

        sql2 = " select * from Vw_MansrfCheck where  name like '%" & txt_NameCustomer.Text & "%'  and (Compny_Code = '" & VarCodeCompny & "') AND (Expenses_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Expenses_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102))   "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
      


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
        GridView1.Columns(10).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Sub Find_Hafza_Estlam()
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


        sql2 = "select * from vw_mstalmCheck WHERE        (Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)





        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()


        GridView1.Columns(0).Caption = "رقم الحافظة"
        GridView1.Columns(1).Caption = "رقم السند "
        GridView1.Columns(2).Caption = "المبلغ "
        GridView1.Columns(3).Caption = "رقم الشيك"
        GridView1.Columns(4).Caption = "تاريخ الاستلام"
        GridView1.Columns(5).Caption = "البنك المسحوب عليه"
        GridView1.Columns(6).Caption = "تاريخ الاستحقاق"
        GridView1.Columns(7).Caption = "نوع الحركة"

        GridView1.Columns(8).Visible = False




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub
    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        Wared_Bank()
        var_open_Recipt = 4
        Run_report()
    End Sub
    Sub Run_report()

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


        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"


        If var_open_Recipt = 4 Then
            Dim report As New Ward_Check
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 1 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel32.Text = txt_NameCustomer.Text
            report.FilterString = "[Customer] Like '%" & txt_NameCustomer.Text & "%'   and Compny_Code ='" & VarCodeCompny & "' and [Receipt_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If var_open_Recipt = 5 Then
            Dim report As New Mnsrf_Check
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel32.Text = txt_NameCustomer.Text
            report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%'   and Compny_Code ='" & VarCodeCompny & "' and [Expenses_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If var_open_Recipt = 6 Then
            Dim report As New Ashkak_Check2
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel32.Text = txt_NameCustomer.Text
            report.FilterString = "[Customer] Like '%" & txt_NameCustomer.Text & "%'   and Compny_Code ='" & VarCodeCompny & "' and [Date_Asthkak] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If var_open_Recipt = 7 Then
            Dim report As New estlam_Check3
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            'report.XrLabel32.Text = txt_NameCustomer.Text
            report.FilterString = " Compny_Code ='" & VarCodeCompny & "' and [Receipt_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If
    End Sub
    Sub Wared_Bank()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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


        sql2 = " select * from Vw_WaredCheck WHERE  Customer like '%" & txt_NameCustomer.Text & "%' and       (Compny_Code = '" & VarCodeCompny & "') AND (Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Receipt_Date <= CONVERT(DATETIME,'" & vardate2 & "', 102))  "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



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

        GridView1.Columns(10).Visible = False

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If var_open_Recipt = 4 Then
            GridView1.BestFitColumns()
            Wared_Bank()
            Run_report()

        End If

        If var_open_Recipt = 5 Then
            GridView1.BestFitColumns()
            Mnsrf_Bank()
            Run_report()

        End If


        If var_open_Recipt = 6 Then
            GridView1.BestFitColumns()
            Asthkak_Bank()
            Run_report()

        End If

        If var_open_Recipt = 7 Then
            GridView1.BestFitColumns()
            Find_Hafza_Estlam()
            Run_report()

        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txt_NameCustomer.Text = ""
        If var_open_Recipt = 4 Then Wared_Bank() : Run_report() : TabPane1.SelectedPageIndex = 1
        If var_open_Recipt = 5 Then Mnsrf_Bank() : Run_report() : TabPane1.SelectedPageIndex = 1
        If var_open_Recipt = 6 Then Asthkak_Bank() : Run_report() : TabPane1.SelectedPageIndex = 1
        If var_open_Recipt = 7 Then Find_Hafza_Estlam() : Run_report() : TabPane1.SelectedPageIndex = 1

    End Sub
    Sub Asthkak_Bank()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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

        sql2 = "Select * from Vw_MsthkCheck where   (Compny_Code = '" & VarCodeCompny & "') AND (Date_Asthkak >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Date_Asthkak <= CONVERT(DATETIME,  '" & vardate2 & "', 102))  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()

        GridView1.Columns(0).Caption = "رقم الشيك"
        GridView1.Columns(1).Caption = "تاريخ الاستحقاق"
        GridView1.Columns(2).Caption = "البنك المسحوب عليه"
        GridView1.Columns(3).Caption = "المبلغ"
        GridView1.Columns(4).Caption = "أسم الحساب"
        GridView1.Columns(5).Caption = "المندوب"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

    End Sub
    Private Sub txt_NameCustomer_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameCustomer.ButtonClick
        'varcode_form = 2510
        'VarOpenlookup2 = 2510
        'Frm_LookUpCustomer.Find_Customer()
        'Frm_LookUpCustomer.ShowDialog()


        VARTBNAME = "vw_AccountData"
        varcode_form = 300
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()


    End Sub

    Private Sub txt_NameCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameCustomer.EditValueChanged

    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        Mnsrf_Bank()
        var_open_Recipt = 5
        Run_report()
    End Sub

    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        Asthkak_Bank()
        var_open_Recipt = 6
        Run_report()
    End Sub

    Private Sub NavBarItem4_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        Find_Hafza_Estlam()
        var_open_Recipt = 7
        Run_report()
    End Sub
End Class