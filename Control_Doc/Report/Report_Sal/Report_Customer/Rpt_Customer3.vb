Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Rpt_Customer3

    Private Sub Rpt_Customer3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()



        '===================================================المديونية
        If VarCodeCompny = 1 And vardisplayReport = 0 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerM3.rpt")
        If VarCodeCompny = 3 And vardisplayReport = 0 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerM3.rpt")
        If VarCodeCompny = 2 And vardisplayReport = 0 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerM3.rpt")
        '=========================================================================== تقرير اجمالى الفواتير
        If VarCodeCompny = 1 And vardisplayReport = 1 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceSum.rpt")
        If VarCodeCompny = 3 And vardisplayReport = 1 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceSum.rpt")
        If VarCodeCompny = 2 And vardisplayReport = 1 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceSum.rpt")
        '===================================================================================  تقرير تحصيلات العملاء
        If VarCodeCompny = 1 And vardisplayReport = 3 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerCridit.rpt")
        If VarCodeCompny = 3 And vardisplayReport = 3 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerCridit.rpt")
        If VarCodeCompny = 2 And vardisplayReport = 3 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerCridit.rpt")
        '===================================================================================  تقريرمبيعات العملاء من الاصناف
        If VarCodeCompny = 1 And vardisplayReport = 5 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceItem.rpt")
        If VarCodeCompny = 3 And vardisplayReport = 5 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceItem.rpt")
        If VarCodeCompny = 2 And vardisplayReport = 5 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_CustomerInvoiceItem.rpt")

        '===================================================================================  تقريرالعملاء تعدت حد الائتمان
        If VarCodeCompny = 1 And vardisplayReport = 7 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_Customer_Limited.rpt")
        If VarCodeCompny = 3 And vardisplayReport = 7 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_Customer_Limited.rpt")
        If VarCodeCompny = 2 And vardisplayReport = 7 Then cryRpt.Load(Path2 + "\Report_Customer\Rpt_Customer_Limited.rpt")
        '====================================================================================================


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
        'cryRpt.SetParameterValue("ImageID", "\\server\css2021\logo\Master.jpg")
        'Dim rptdoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptdoc = New cr
        cryRpt.DataDefinition.FormulaFields("date1").Text = " '" & Frm_ReportCustomer.txt_date.Value & "' "
        cryRpt.DataDefinition.FormulaFields("date2").Text = " '" & Frm_ReportCustomer.txt_date2.Value & "' "
        'cryRpt.SetDataSource(CrTables)


        CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Show()
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class