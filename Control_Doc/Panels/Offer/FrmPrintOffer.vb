Public Class FrmPrintOffer

    Private Sub FrmPrintOffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report2 As New Offer
        'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

        report2.FilterString = "[CostCenter_account1] = '" & varcode_project & "'    "
        report2.CreateDocument()
        DocumentViewer1.DocumentSource = report2
    End Sub
End Class