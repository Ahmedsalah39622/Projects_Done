Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_InvintoryValue

    Private Sub Rpt_InvintoryValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "InvintoryValue1.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "InvintoryValue3.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "InvintoryValue2.rpt")

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


        'Dim oldDate As Date
        'Dim oldDay As Integer
        'Dim oldDate2 As Date
        'Dim oldDay2 As Integer
        ''=======================================Date 1
        'oldDate = frm_gard.txt_date.Value
        'oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        'Dim d As Date
        'Date.TryParse(frm_gard.txt_date.Value, d)
        'var_Month_no = d.Month
        'var_Year_no = d.Year

        ''=====================================================================date2

        'oldDate2 = frm_gard.txt_date2.Value
        'oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)


        'Dim d2 As Date
        'Date.TryParse(frm_gard.txt_date2.Value, d2)
        'var_Month_no2 = d2.Month
        'var_Year_no2 = d2.Year



        cryRpt.DataDefinition.FormulaFields("date1").Text = " '" & Frm_ReportInventory.txt_date.Text & "' "
        cryRpt.DataDefinition.FormulaFields("date2").Text = " '" & Frm_ReportInventory.txt_date2.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("Name").Text = " '" & frm_gard.txt_NameItemCart.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("NameItem").Text = " '" & frm_gard.txt_NameItemCart.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("NameStores").Text = " '" & frm_gard.txt_NamestoresCart.Text & "' "


        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_InvintoryValue.Compny_Code} = " & VarCodeCompny & "  "


        'cryRpt.DataDefinition.RecordSelectionFormula = " {Tb_CondationOrder.Order_NO} = '" & Frm_OrderData.Com_InvoiceNo2.Text & "' and  {Tb_CondationOrder.Compny_Code} = " & VarCodeCompny & " "



        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class