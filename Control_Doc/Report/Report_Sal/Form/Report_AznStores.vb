﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_AznStores

    Private Sub Report_AznStores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        cryRpt.Load(Path2 + "Azn_Stores_Inter.rpt")
        'If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Azn_Stores_F.rpt")
        'If VarCodeCompny = 2 And Frm_AznSarf2.OP1.Checked = True Then cryRpt.Load(Path2 + "Azn_Stores_M.rpt")
        'If VarCodeCompny = 2 And Frm_AznSarf2.Op2.Checked = True Then cryRpt.Load(Path2 + "Azn_Stores_M2.rpt")

        'If VarCodeCompny = 2 And Frm_AznSarf.txt_Tax.Text = "شامل ضريبة" Then cryRpt.Load(Path2 + "Azn_Stores_M.rpt")
        'If VarCodeCompny = 2 And Frm_AznSarf.txt_Tax.Text = "غير شامل ضريبة" Then cryRpt.Load(Path2 + "Azn_Stores_M2.rpt")

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

        'Var_TF_Amount = NoToTxt(Frm_Recipt_Cash.txt_Amount.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "


        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_AznStores.Order_Stores_NO} = '" & Frm_AznSarf.Com_InvoiceNo2.Text & "' and  {Rpt_AznStores.Compny_Code} = " & VarCodeCompny & " "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class