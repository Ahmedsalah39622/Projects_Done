Public Class Frm_ReportProdact

    Private Sub Frm_ReportProdact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New Report_ProdactDay
        report.X_Date1.Text = frm_ReportProduction.txt_date.Value
        report.X_Date2.Text = frm_ReportProduction.txt_date2.Value
        report.Txt_Titel.Text = frm_ReportProduction.LabelX1.Text
        If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
      report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class