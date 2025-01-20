

Public Class Frm_printBarcode

   
    Private Sub Frm_printBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New Rpt2

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

    End Sub
End Class