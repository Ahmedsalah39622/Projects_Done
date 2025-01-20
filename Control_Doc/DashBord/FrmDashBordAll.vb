
Public Class FrmDashBordAll
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Private Sub FrmDashBordAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   DashboardViewer1.LoadDashboard("\\10.0.0.51\xml\Dashbord\CashBox.xml")
        'DashboardViewer1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\CashBox.xml")
        fill_Branch()
    End Sub

    Sub fill_Branch()
        sql = " Select Name       FROM dbo.BD_SUBMAIN"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then Com_Branch.Text = rs("name").Value
    End Sub
    Private Sub NavBarItem26_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem26.LinkClicked
        '  DashboardViewer1.LoadDashboard("\\10.0.0.51\xml\Dashbord\CashBox.xml")
        DashboardViewer1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\CashBox.xml")
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        '   DashboardViewer1.LoadDashboard("\\10.0.0.51\xml\Dashbord\Revenues.xml")
        Ceratea_sql()
        DashboardViewer1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\Revenues.xml")
    End Sub
    Sub Ceratea_sql()
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


        'If RadioButton1.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel AS  SELECT SUBSTRING(AccountNo, 1, 1) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If


        'If RadioButton2.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel2"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel2 AS  SELECT SUBSTRING(AccountNo, 1, 4) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If


        'If RadioButton3.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel3"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel3 AS  SELECT SUBSTRING(AccountNo, 1, 7) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If


        'If RadioButton4.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel4"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel4 AS  SELECT SUBSTRING(AccountNo, 1, 15) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If

    End Sub
    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        Ceratea_sql()
        DashboardViewer1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\Expenses.xml")

    End Sub

    Private Sub NavBarItem11_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem11.LinkClicked
        DashboardViewer1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\Expenses_date.xml")
    End Sub
End Class