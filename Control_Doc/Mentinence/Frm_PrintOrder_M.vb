Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Frm_PrintOrder_M

    Private Sub Frm_PrintOrder_M_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Order_M.rpt")
      

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

        'cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_GL_Data.IDGenral} = " & Frm_Gl4.Com_GL_No.Text & " and  {Vw_All_GL_Data.Compny_Code} = " & VarCodeCompny & " "


        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class