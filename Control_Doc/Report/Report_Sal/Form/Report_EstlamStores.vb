Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_EstlamStores

    Private Sub Report_EstlamStores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Estlam_Stores_Inter.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Estlam_Stores_F.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Estlam_Stores_M.rpt")

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

        cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_AznEstlam.Order_Azn_Estlam_NO} = '" & Frm_AznEstlamItem.Com_InvoiceNo2.Text & "' and  {Rpt_AznEstlam.Compny_Code} = " & VarCodeCompny & " "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class