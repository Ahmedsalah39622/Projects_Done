Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Frm_reportsal

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        'On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        cryRpt.Load("E:\Source2\IntrpakNational_Project\ScanProject\Control_Doc\Control_Doc\Report\Report_Sal\sal.rpt")
        'cryRpt.Load("F:\source\ERP_System2\WindowsApplication1\Report\Day_sal.rpt")
        'cryRpt.Load("\\192.168.1.45\CSS_Css\Report\Rpt_Statment.rpt")
        'cryRpt.Load("F:\bakup_code\Northcost\WindowsApplication1\WindowsApplication1\CSS_Invoice.rpt")

        With crConnectionInfo
            .ServerName = "test"
            .DatabaseName = "CSS"
            .UserID = "CSS"
            .Password = "CSS"

        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'Var_TF_Amount = NoToTxt(Frm_Recipt_Cash.txt_Amount.Text, "جنيها مصريا", "قرش")

        '==================================================date From
        'Dim oldDate As Date
        'Dim oldDay As Integer
        'Dim oldDate2 As Date
        'Dim oldDay2 As Integer



        ''=======================================Date 1
        'oldDate = Frm_CustomerReports.txt_date.Value
        'oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        'Dim d As Date
        'Date.TryParse(Frm_CustomerReports.txt_date.Value, d)
        'var_Month_no = d.Month
        'var_Year_no = d.Year

        ''=====================================================================date2

        'oldDate2 = Frm_CustomerReports.txt_date2.Value
        'oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)


        'Dim d2 As Date
        'Date.TryParse(Frm_CustomerReports.txt_date2.Value, d2)
        'var_Month_no2 = d2.Month
        'var_Year_no2 = d2.Year





        'Dim xx As String

        'cryRpt.DataDefinition.FormulaFields("date1").Text = " '" & Frm_CustomerReports.txt_date.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("date2").Text = " '" & Frm_CustomerReports.txt_date2.Text & "' "

        'If Frm_CustomerReports.txt_Stores.Text <> "" And Frm_CustomerReports.Txt_Customer.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptSalData.DateBill} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00)  and {Vw_RptSalData.NameStores} = '" & Frm_CustomerReports.txt_Stores.Text & "'  "
        'If Frm_CustomerReports.txt_Stores.Text = "" And Frm_CustomerReports.Txt_Customer.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptSalData.DateBill} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00)   "
        'If Frm_CustomerReports.txt_Stores.Text <> "" And Frm_CustomerReports.Txt_Customer.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptSalData.DateBill} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00)  and {Vw_RptSalData.NameStores} = '" & Frm_CustomerReports.txt_Stores.Text & "'  "
        'If Frm_CustomerReports.txt_Stores.Text <> "" And Frm_CustomerReports.Txt_Customer.Text <> "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_RptSalData.DateBill} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00)  and {Vw_RptSalData.NameStores} = '" & Frm_CustomerReports.txt_Stores.Text & "'  and   {Vw_RptSalData.AccountName} = '" & Frm_CustomerReports.Txt_Customer.Text & "'  "

        'cryRpt.DataDefinition.FormulaFields("code").Text = 1"

        cryRpt.DataDefinition.RecordSelectionFormula = "{stores.code} = " & 2 & ""
        '{Vw_RptSalData.DateBill} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00) and
        '"    "
        'and {Vw_RptSalData.Name} like '%" & Frm_CustomerReports.txt_sub.Text & "%'  and {Vw_RptSalData.NameStores} like '%" & Frm_CustomerReports.txt_Stores.Text & "%' 
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
        'CrystalReportViewer1.RefreshReport()
    End Sub
End Class