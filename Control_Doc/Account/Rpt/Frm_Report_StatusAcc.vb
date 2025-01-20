Public Class Frm_Report_StatusAcc

    Private Sub Frm_Report_StatusAcc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vardisplayReport2 = 0 Then
            Dim report As New Report_RentedInvoice
            report.X_Date1.Text = DateTime.Now.ToString("d ddd MMM yyyy")
            'report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            'report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport2 = 1 Then
            Dim report As New Daily_Thselat
            report.X_Date1.Text = DateTime.Now.ToString("d ddd MMM yyyy")
            'report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            'report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
       
    End Sub
End Class