Public Class Frm_ReportGlAll2

    Private Sub Frm_InvoicePrintPrchesess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New ReportGlAll2
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        'report.FilterString = "[Compny_Code] = '" & VarCodeCompny & "' and [DateM] Between('" & Frm_Gl4.txt_date.Text & "', '" & Frm_Gl4.txt_date2.Text & "')"
        report.FilterString = "[Compny_Code] = '" & VarCodeCompny & "' and [DateM] Between(#" & Frm_Gl4.txt_date.Text & "#, #" & Frm_Gl4.txt_date2.Text & "#)"
        report.XrLabel15.Text = Frm_Gl4.txt_date.Text
        report.XrLabel16.Text = Frm_Gl4.txt_date2.Text
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class