Public Class Frm_PrintPAOFinal

    Private Sub Frm_PrintPAOFinal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vardisplayReport = 322 Then
            Dim report2 As New PAO_Final
            'report2.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report2.FilterString = "[Order_NO] = '" & Frm_OrderData.Com_InvoiceNo2.Text & "'    "
            report2.CreateDocument()
            DocumentViewer1.DocumentSource = report2

        End If

    End Sub
End Class