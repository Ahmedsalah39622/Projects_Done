Public Class Frm_PrintProcurementVoucher

    Private Sub Frm_InvoicePrintPrchesess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New ProcurementVoucher
        'report.XrPictureBox1.Image = Image.FromFile("c:\logo\4.png")
        'report.XrPictureBox2.Image = Image.FromFile("c:\logo\3.png")
        report.FilterString = "[Order_Stores_NO] = '" & Frm_OrderPrcheses.Com_InvoiceNo2.Text & "'  "

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class