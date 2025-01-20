Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Rpt_CartItem

    Private Sub Rpt_CartItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 1 Then cryRpt.Load(Path2 + "Kart_item1.rpt")
        If VarCodeCompny = 3 Then cryRpt.Load(Path2 + "Kart_item3.rpt")
        If VarCodeCompny = 2 Then cryRpt.Load(Path2 + "Kart_item2.rpt")

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
        '=======================================Date 1
        oldDate = frm_gard.txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(frm_gard.txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year

        '=====================================================================date2

        oldDate2 = frm_gard.txt_date2.Value
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)


        Dim d2 As Date
        Date.TryParse(frm_gard.txt_date2.Value, d2)
        var_Month_no2 = d2.Month
        var_Year_no2 = d2.Year



        cryRpt.DataDefinition.FormulaFields("date1").Text = " '" & frm_gard.txt_date.Text & "' "
        cryRpt.DataDefinition.FormulaFields("date2").Text = " '" & frm_gard.txt_date2.Text & "' "
        'cryRpt.DataDefinition.FormulaFields("Name").Text = " '" & frm_gard.txt_NameItemCart.Text & "' "
        cryRpt.DataDefinition.FormulaFields("NameItem").Text = " '" & frm_gard.txt_NameItemCart.Text & "' "
        cryRpt.DataDefinition.FormulaFields("NameStores").Text = " '" & frm_gard.txt_NamestoresCart.Text & "' "


        'Varbalnce, Varbalnce_De, Varbalnce_Cr
        If frm_gard.txt_NamestoresCart.Text <> "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_CartItem.DateMoveM} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00) and  {Rpt_CartItem.Compny_Code} = " & VarCodeCompny & " and  {Rpt_CartItem.NameItem} = '" & frm_gard.txt_NameItemCart.Text & "' and  {Rpt_CartItem.NameStores} = '" & frm_gard.txt_NamestoresCart.Text & "' "
        If frm_gard.txt_NamestoresCart.Text = "" Then cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_CartItem.DateMoveM} in DateTime (" & var_Year_no & ", " & var_Month_no & ", " & oldDay & ", 00, 00, 00) to DateTime (" & var_Year_no2 & ", " & var_Month_no2 & ", " & oldDay2 & ", 00, 00, 00) and  {Rpt_CartItem.Compny_Code} = " & VarCodeCompny & "  and  {Rpt_CartItem.NameItem} = '" & frm_gard.txt_NameItemCart.Text & "'   "


        'cryRpt.DataDefinition.RecordSelectionFormula = " {Tb_CondationOrder.Order_NO} = '" & Frm_OrderData.Com_InvoiceNo2.Text & "' and  {Tb_CondationOrder.Compny_Code} = " & VarCodeCompny & " "



        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class