Public Class Rpt_BOOMPrint

    Private Sub Rpt_BOOMPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New BOOM
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = "[PAO_NO] = '" & VarPAO_NO2 & "'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

    End Sub
End Class