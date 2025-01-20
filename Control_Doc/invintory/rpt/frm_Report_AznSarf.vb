Public Class frm_Report_AznSarf
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim vardate As String
    Dim vardate2, vardatetest1, vardatetest2 As String
    Private Sub frm_Report_AznSarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = Frm_ReportSarf.txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        Dim d As Date
        Date.TryParse(Frm_ReportSarf.txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2
        oldDate = Frm_ReportSarf.txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        Dim d2 As Date
        Date.TryParse(Frm_ReportSarf.txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay




        Dim report As New AznSarfReport
        If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
      report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

        report.X_Date1.Text = Frm_ReportSarf.txt_date.Value
        report.X_Date2.Text = Frm_ReportSarf.txt_date2.Value

        If Frm_ReportSarf.OP1.Checked = True Then report.labStatus.Text = "بدون فاتورة"
        If Frm_ReportSarf.OP2.Checked = True Then report.labStatus.Text = " فاتورة"
        If Frm_ReportSarf.OP3.Checked = True Then report.labStatus.Text = " الكل"

        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"

        If Frm_ReportSarf.OP1.Checked = True Then report.FilterString = "[No_Invoice] = '" & 0 & "'   and [Compny_Code] = '" & VarCodeCompny & "'  and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
        If Frm_ReportSarf.OP2.Checked = True Then report.FilterString = "[No_Invoice] <> '" & 0 & "'   and [Compny_Code] = '" & VarCodeCompny & "' and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
        If Frm_ReportSarf.OP3.Checked = True Then report.FilterString = " [Compny_Code] = '" & VarCodeCompny & "' and [Order_Date_stores] Between(" & vardatetest1 & ", " & vardatetest2 & ") "

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        'End If
    End Sub
End Class