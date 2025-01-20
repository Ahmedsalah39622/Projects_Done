Public Class Frm_RptRequestStores

    Private Sub Frm_RptRequestStores_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Dim report As New RptTalabSarf
        report.FilterString = " [Order_Stores_NO] = '" & Trim(Frm_OrderItem.Com_InvoiceNo2.Text) & "'   "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class