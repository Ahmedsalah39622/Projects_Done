Public Class Frm_CashRased
    Dim varcodeAccountNo As String
    Dim varSumWared, varSumMnsrf, varTotalBalance As Single
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        If Len(Com_AccountName.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        FindBalance()
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim vardate As String
        Dim vardate2, vardatetest1, vardatetest2 As String
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



        Dim report As New CashBox
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.X_Date1.Text = txt_date.Value
        report.X_Date2.Text = txt_date2.Value

        report.Lab_Branch.Text = varNameBranch
        report.Lab_NameAcc.Text = Com_AccountName.Text
        report.Lab_BalancePrv.Text = txt_Balance.Text
        report.Lab_BalanceAll.Text = varTotalBalance

        report.FilterString = "  [Receipt_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ")   "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
   
    Sub FindBalance()
        On Error Resume Next
        Dim oldDate As Date
        Dim oldDay As Integer
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

        varcodeAccountNo = 0


        sql = "SELECT Account_No, AccountName  FROM dbo.ST_CHARTOFACCOUNT WHERE  (AccountName = '" & Com_AccountName.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeAccountNo = Math.Round(rs("Account_No").Value, 2)


        sql = "   SELECT AccountNo, SUM(Debit) - SUM(Cridit) AS Bl     FROM dbo.MovmentStatement WHERE  (DateMoveM < CONVERT(DATETIME, '" & vardate & "', 102)) and AccountNo ='" & varcodeAccountNo & "' and  Compny_Code ='" & VarCodeCompny & "' GROUP BY AccountNo"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Balance.Text = Math.Round(rs("Bl").Value, 2) Else txt_Balance.Text = "0"


        '=====================================رصيد الوارد والمنصرف
        varSumWared = 0
        varSumMnsrf = 0
        sql = "    SELECT SUM(waredCash) AS SumWared, SUM(MnsrfCash) AS SumMnsrf     FROM dbo.Rpt_CashBox " & _
      " WHERE  (AccountNo = '" & varcodeAccountNo & "') AND (Receipt_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Receipt_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102))  HAVING (SUM(MnsrfCash) IS NOT NULL) AND (SUM(waredCash) IS NOT NULL) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varSumWared = Math.Round(rs("SumWared").Value, 2) : varSumMnsrf = Math.Round(rs("SumMnsrf").Value, 2)

        varTotalBalance = Val((txt_Balance.Text) + Val(varSumWared) - Val(varSumMnsrf))

    End Sub
    Private Sub Frm_CashRased_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Branch()
        fill_Box()
        Com_BranchName.Text = varNameBranch
    End Sub
    Sub fill_Box()
        Com_AccountName.Items.Clear()
        sql = "SELECT  rtrim( Name) as NameAcc " & _
            " FROM      Vw_AccountBox   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_AccountName.Items.Add(rs("NameAcc").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Branch()
        Com_BranchName.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_SUBMAIN  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_BranchName.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
End Class