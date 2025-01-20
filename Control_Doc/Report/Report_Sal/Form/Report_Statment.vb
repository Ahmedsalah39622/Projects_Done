Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_Statment
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Private Sub Report_Statment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 And Frm_AccountStatement.OP2.Checked = True Then cryRpt.Load(Path2 + "Rpt_Statment_Inter.rpt")
        If VarCodeCompny = 2 And Frm_AccountStatement.OP2.Checked = True Then cryRpt.Load(Path2 + "Rpt_Statment_M.rpt")
        If VarCodeCompny = 3 And Frm_AccountStatement.OP2.Checked = True Then cryRpt.Load(Path2 + "Rpt_Statment_F.rpt")

        'If VarCodeCompny = 1 And Frm_AccountStatement.OP1.Checked = True Then cryRpt.Load(Path2 + "Rpt_StatmentSum_Inter.rpt")
        'If VarCodeCompny = 2 And Frm_AccountStatement.OP1.Checked = True Then cryRpt.Load(Path2 + "Rpt_StatmentSum_M.rpt")
        'If VarCodeCompny = 3 And Frm_AccountStatement.OP1.Checked = True Then cryRpt.Load(Path2 + "Rpt_StatmentSum_F.rpt")


        If VarCodeCompny = 1 And Frm_AccountStatement.OP3.Checked = True Then cryRpt.Load(Path2 + "Report_Customer\Rpt_StatmentItem_Inter.rpt")
        If VarCodeCompny = 2 And Frm_AccountStatement.OP3.Checked = True Then cryRpt.Load(Path2 + "Report_Customer\Rpt_StatmentItem_M.rpt")
        If VarCodeCompny = 3 And Frm_AccountStatement.OP3.Checked = True Then cryRpt.Load(Path2 + "Report_Customer\Rpt_StatmentItem_F.rpt")


        'vardisplayReport()

        'cryRpt.Load("F:\source\ERP_System2\WindowsApplication1\Report\First_Stores.rpt")
        'cryRpt.Load("F:\bakup_code\Northcost\WindowsApplication1\WindowsApplication1\Rental_Invoice.rpt")

        With crConnectionInfo
            .ServerName = ServerName
            .DatabaseName = DatabaseName
            .UserID = varusername2
            .Password = varPassword

        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = Frm_AccountStatement.txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(Frm_AccountStatement.txt_date1.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate2 = Frm_AccountStatement.txt_date2.Value
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)


        Dim d2 As Date
        Date.TryParse(Frm_AccountStatement.txt_date2.Value, d2)
        var_Month_no2 = d2.Month
        var_Year_no2 = d2.Year

        vardate2 = var_Year_no2 & "-" & var_Month_no2 & "-" & oldDay2


        'Var_TF_Amount = NoToTxt(Frm_Recipt_Cash.txt_Amount.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "

        cryRpt.DataDefinition.FormulaFields("date1").Text = " '" & vardate & "' "
        cryRpt.DataDefinition.FormulaFields("date2").Text = " '" & vardate2 & "' "

        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        'If vardisplayReport <> 8 Then
        '    cryRpt.DataDefinition.RecordSelectionFormula = "{Vw_StatmentAccount.DateMoveM} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00) and   {Vw_StatmentAccount.AccountNo} = '" & Frm_AccountStatement.txt_codeAcc.Text & "' and  {Vw_StatmentAccount.Compny_Code} = " & VarCodeCompny & " "
        'Else
        'End If
        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class