Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_Recipt

    Private Sub Report_Recipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument

        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Recipt_Report_I3.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Recipt_Report_M3.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Recipt_Report_F3.rpt")

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

        'Var_TF_Amount = NoToTxt(Frm_ReciptCash2.txt_TotalEsal.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "
        'cryRpt.DataDefinition.FormulaFields("Tafket").Text = " '" & Var_TF_Amount & "' "
        'cryRpt.DataDefinition.FormulaFields("Name").Text = " '" & Frm_ReciptCash2.txt_nameaccount.Text & "' "
        ''cryRpt2.DataDefinition.FormulaFields("Name").Text = " '" & Frm_ReciptCash2.txt_nameaccount.Text & "' "
        'cryRpt2.DataDefinition.FormulaFields("Tafket").Text = " '" & Var_TF_Amount & "' "

        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptRecipt.Receipt_No} = " & Frm_ReciptCash2.Com_Exp_No.Text & " and  {Vw_RptRecipt.Compny_Code} = " & VarCodeCompny & " "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class