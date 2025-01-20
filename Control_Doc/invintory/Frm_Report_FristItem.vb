Public Class Frm_Report_FristItem

    Private Sub Frm_InvoicePrintPrchesess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New DevReport_FristItem
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = "[NumberBill] = '" & Frm_FristItem.Com_InvoiceNo.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class