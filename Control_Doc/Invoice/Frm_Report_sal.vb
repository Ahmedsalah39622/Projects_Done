Public Class Frm_Report_sal

    Private Sub Frm_Report_sal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New RPT_Order_Sal
        If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
      report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        'report.X_Date1.Text = txt_date.Value
        'report.X_Date2.Text = txt_date2.Value
        'report.XrLabel29.Text = txt_NameSuppliser.Text
        report.FilterString = " [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class