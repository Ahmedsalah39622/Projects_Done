Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_ExpensesReport

    Private Sub Frm_ExpensesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim cryRpt2 As New ReportDocument

        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Expenses_Report_Inter.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Expenses_Report_M.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Expenses_Report_F.rpt") : cryRpt2.Load(Path2 + "Expenses_Report_F2.rpt")

        'cryRpt.Load("F:\source\ERP_System2\WindowsApplication1\Report\First_Stores.rpt")
        'cryRpt.Load("F:\bakup_code\Northcost\WindowsApplication1\WindowsApplication1\Rental_Invoice.rpt")

        With crConnectionInfo
            .ServerName = ServerName
            .DatabaseName = DatabaseName
            .UserID = varusername2
            .Password = varPassword

        End With

        CrTables = cryRpt2.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next


        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

       

        Var_TF_Amount = NoToTxt(Frm_Expenses2.txt_TotalEsal.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "
        cryRpt.DataDefinition.FormulaFields("Tafket").Text = " '" & Var_TF_Amount & "' "
        cryRpt2.DataDefinition.FormulaFields("Tafket").Text = " '" & Var_TF_Amount & "' "
        'cryRpt.DataDefinition.FormulaFields("Name").Text = " '" & Frm_Expenses2.txt_nameaccount.Text & "' "

        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptExpenses.Expenses_No} = " & Frm_Expenses2.Com_Exp_No.Text & " and  {Vw_RptExpenses.Compny_Code} = " & VarCodeCompny & " "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class