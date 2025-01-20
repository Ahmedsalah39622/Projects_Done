Public Class frmPrintGL

    Private Sub frmPrintGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New Gl4
       
        'report.XAccountName.Text = Frm_AccDetils2.txt_Name.Text
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = "[IDGenral] = '" & Frm_Gl4.Com_GL_No.Text & "' "

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class