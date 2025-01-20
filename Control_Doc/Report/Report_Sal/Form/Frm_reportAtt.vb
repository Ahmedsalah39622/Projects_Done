Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization

Public Class Frm_reportAtt

    Private Sub Frm_reportAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        cryRpt.Load(Path2 + "attendance3.rpt")
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



        Dim oldDate As Date
        Dim oldDay As Integer
        Dim oldDate2 As Date
        Dim oldDay2 As Integer
        ''=======================================Date 1
        'oldDate = Frm_Attendec.txt_date.Value
        'oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        'Dim d As Date
        'Date.TryParse(Frm_Attendec.txt_date.Value, d)
        'var_Month_no = d.Month
        'var_Year_no = d.Year

        ''=====================================================================date2

        'oldDate2 = Frm_Attendec.txt_date2.Value
        'oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)


        'Dim d2 As Date
        'Date.TryParse(Frm_Attendec.txt_date2.Value, d2)
        'var_Month_no2 = d2.Month
        'var_Year_no2 = d2.Year

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = Frm_Attendec.txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(Frm_Attendec.txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay


        Dim varin, varout As String

        Dim MyDate As DateTime = New DateTime(var_Year_no, var_Month_no, oldDay)
        varin = MyDate.ToString("yyyy-MM-dd")
        '=====================================================================date2

        oldDate = Frm_Attendec.txt_date2.Value
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(Frm_Attendec.txt_date2.Value, d2)
        var_Month_no2 = d2.Month
        var_Year_no2 = d2.Year

        vardate2 = var_Year_no2 & "-" & var_Month_no2 & "-" & oldDay2



        Dim MyDate2 As DateTime = New DateTime(var_Year_no, var_Month_no, oldDay)
        varout = MyDate2.ToString("yyyy-MM-dd")


        cryRpt.DataDefinition.FormulaFields("date_From").Text = " '" & Frm_Attendec.txt_date.Text & "' "
        cryRpt.DataDefinition.FormulaFields("Date_TO").Text = " '" & Frm_Attendec.txt_date2.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("NameDir").Text = " '" & Frm_Attendec.Com_Dir.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("NameDeprt").Text = " '" & Frm_Attendec.Com_dept.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("NameEmp").Text = " '" & Frm_Attendec.Com_NameEmp.Text & "' "



        'Var_TF_Amount = NoToTxt(Frm_Recipt_Cash.txt_Amount.Text, "جنيها مصريا", "قرش")
        'If varflagstatus = 0 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "بضاعة اول المدة" & "' "
        'If varflagstatus = 1 Then cryRpt.DataDefinition.FormulaFields("Tital").Text = " '" & "تحويل من مخزن لأخر" & "' "

    

        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        'If Frm_Attendec.Com_Dir.Text = "" And Frm_Attendec.Com_Dir.Text = "" And Frm_Attendec.Com_JopName.Text = "" And Frm_Attendec.Com_NameEmp.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_Att.Date_Day} in '" & varin & "' to  '" & varout & "'  "
        'If Frm_Attendec.Com_Dir.Text <> "" And Frm_Attendec.Com_dept.Text = "" And Frm_Attendec.Com_JopName.Text = "" And Frm_Attendec.Com_NameEmp.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_Att.NameDirctorat} = '" & Frm_Attendec.Com_Dir.Text & "' and   {Vw_All_Att.Date_Day} in DateTime ('" & var_Year_no & "', '" & var_Month_no & "','" & oldDay & "', 00, 00, 00) to DateTime ('" & var_Year_no2 & "', '" & var_Month_no2 & "','" & oldDay2 & "', 00, 00, 00)"
        'If Frm_Attendec.Com_Dir.Text <> "" And Frm_Attendec.Com_dept.Text <> "" And Frm_Attendec.Com_JopName.Text = "" And Frm_Attendec.Com_NameEmp.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_Att.NameDirctorat} = '" & Frm_Attendec.Com_Dir.Text & "' and {Vw_All_Att.NameDeprt} = '" & Frm_Attendec.Com_dept.Text & "' and  {Vw_All_Att.Date_Day} in DateTime ('" & var_Year_no & "', '" & var_Month_no & "','" & oldDay & "', 00, 00, 00) to DateTime ('" & var_Year_no2 & "', '" & var_Month_no2 & "','" & oldDay2 & "', 00, 00, 00) "
        'If Frm_Attendec.Com_Dir.Text <> "" And Frm_Attendec.Com_dept.Text <> "" And Frm_Attendec.Com_JopName.Text <> "" And Frm_Attendec.Com_NameEmp.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_Att.NameDirctorat} = '" & Frm_Attendec.Com_Dir.Text & "' and {Vw_All_Att.NameDeprt} = '" & Frm_Attendec.Com_dept.Text & "' and  {Vw_All_Att.NameJop} = '" & Frm_Attendec.Com_JopName.Text & "' and {Vw_All_Att.Date_Day} in '" & varin & "' to  '" & varout & "' "
        'If Frm_Attendec.Com_Dir.Text <> "" And Frm_Attendec.Com_dept.Text <> "" And Frm_Attendec.Com_JopName.Text <> "" And Frm_Attendec.Com_NameEmp.Text <> "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Vw_All_Att.NameDirctorat} = '" & Frm_Attendec.Com_Dir.Text & "' and {Vw_All_Att.NameDeprt} = '" & Frm_Attendec.Com_dept.Text & "' and  {Vw_All_Att.NameJop} = '" & Frm_Attendec.Com_JopName.Text & "' and  {Vw_All_Att.Emp_Name} = '" & Frm_Attendec.Com_NameEmp.Text & "' and {Vw_All_Att.Date_Day} in '" & varin & "' to  '" & varout & "' "

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class