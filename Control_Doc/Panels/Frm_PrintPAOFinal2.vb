Public Class Frm_PrintPAOFinal2

    Private Sub Frm_PrintPAOFinal2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vardisplayReport = 322 Then
            Dim report2 As New PAO_Final2
            'report2.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report2.Lab_designed.Text = Frm_OrderData.txt_Designed.Text
            report2.lab_Approved.Text = Frm_OrderData.txt_Approved.Text

            report2.FilterString = "[Order_NO] = '" & Frm_OrderData.Com_InvoiceNo2.Text & "'    "
            report2.CreateDocument()
            DocumentViewer1.DocumentSource = report2

        End If
    End Sub
End Class