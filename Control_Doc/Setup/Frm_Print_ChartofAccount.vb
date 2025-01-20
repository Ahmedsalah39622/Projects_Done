Public Class Frm_Print_ChartofAccount

    Private Sub Frm_Print_ChartofAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New ChartOfAccount   'شجرة الحسابات
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

        'report.X_Date1.Text = txt_date.Value
        'report.X_Date2.Text = txt_date2.Value
        'report.XrLabel1.Text = txt_NameCustomer.Text
        'report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%' and [Emp_Name] Like '%" & txt_NameSalse.Text & "%'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class