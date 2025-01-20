Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_SalseOrder

    Private Sub Report_SalseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Order_Stores_Inter.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Order_Stores_F.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Order_Stores_M.rpt")

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
        cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_SalseOrder.Order_NO} = '" & Frm_OrderData.Com_InvoiceNo2.Text & "' and  {Rpt_SalseOrder.Compny_Code} = " & VarCodeCompny & " "
        'cryRpt.DataDefinition.RecordSelectionFormula = " {Tb_CondationOrder.Order_NO} = '" & Frm_OrderData.Com_InvoiceNo2.Text & "' and  {Tb_CondationOrder.Compny_Code} = " & VarCodeCompny & " "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class