Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Report_Invoice

    Dim vartypinvoice As String
    Private Sub Report_Invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Invoce_New_Inter.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Invoce_New_F.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Invoce_New_Master.rpt")

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

        Var_TF_Amount = NoToTxt(Frm_SalseInvoice.Txt_TotalAll.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "

        If Frm_SalseInvoice.RadioButton1.Checked = True Then vartypinvoice = "اجل"
        If Frm_SalseInvoice.RadioButton2.Checked = True Then vartypinvoice = "نقدى"

        cryRpt.DataDefinition.FormulaFields("TypeInvoice").Text = " '" & vartypinvoice & "' "
        cryRpt.DataDefinition.FormulaFields("StatusInvoice").Text = " '" & Frm_SalseInvoice.txt_Typeinv.Text & "' "
        cryRpt.DataDefinition.FormulaFields("Tafket").Text = " '" & Var_TF_Amount & "' "

        cryRpt.DataDefinition.FormulaFields("Total_Inv").Text = " '" & Frm_SalseInvoice.txt_totalPrice.Text & "' "
        cryRpt.DataDefinition.FormulaFields("N_Discount").Text = " '" & Frm_SalseInvoice.txt_Ndis.Text & "' "
        cryRpt.DataDefinition.FormulaFields("Discount").Text = " '" & Frm_SalseInvoice.Txt_Discount.Text & "' "

        cryRpt.DataDefinition.FormulaFields("N_Tax").Text = " '" & Frm_SalseInvoice.txt_Ntax.Text & "' "
        cryRpt.DataDefinition.FormulaFields("Value_Tax").Text = " '" & Frm_SalseInvoice.txt_Tax.Text & "' "
        cryRpt.DataDefinition.FormulaFields("Total_All").Text = " '" & Frm_SalseInvoice.Txt_TotalAll.Text & "' "

       




        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_Invoice.Ext_InvoiceNo} = '" & Frm_SalseInvoice.Com_InvoiceNo2.Text & "' and  {Rpt_Invoice.Compny_Code} = " & VarCodeCompny & " "

        'Dim pic = CType(cryRpt.ReportDefinition.ReportObjects("\\server\css2021\logo\IPPILOGO.jpg"), PictureObject)
        'pic.ObjectFormat.EnableSuppress = True
        ''
        If Frm_SalseInvoice.CheckBox3.Checked = True Then
            cryRpt.DataDefinition.FormulaFields("type_Print").Text = " '" & "أصل" & "' "
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.PrintReport()
        End If

        If Frm_SalseInvoice.CheckBox4.Checked = True Then
            cryRpt.DataDefinition.FormulaFields("type_Print").Text = " '" & "صورة" & "' "
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.RefreshReport()
            'CrystalReportViewer1.Show()
            CrystalReportViewer1.PrintReport()
        End If

        'If Frm_SalseInvoice.CheckBox4.Checked = True And Frm_SalseInvoice.CheckBox3.Checked = True Then
        '    cryRpt.DataDefinition.FormulaFields("type_Print").Text = " '" & "أصل" & "' "
        '    CrystalReportViewer1.ReportSource = cryRpt
        '    CrystalReportViewer1.RefreshReport()

        '    cryRpt.DataDefinition.FormulaFields("type_Print").Text = " '" & "صورة" & "' "
        '    CrystalReportViewer1.ReportSource = cryRpt
        '    CrystalReportViewer1.RefreshReport()
        'End If

    End Sub
End Class