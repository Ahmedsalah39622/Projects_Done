Public Class Rpt_Recipt1

    Private Sub Rpt_Recipt1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If var_open_Recipt = 1 Then
            Dim report As New Gl4
            report.X_Date1.Text = Frm_ReciptCash2.txt_date3.Value
            report.X_Date2.Text = Frm_ReciptCash2.txt_date4.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If



        If var_open_Recipt = 3 Then
            Dim report As New Recipt1_D
            report.X_Date1.Text = Frm_ReciptCash2.txt_date.Value
            report.X_Date2.Text = Frm_ReciptCash2.txt_date2.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If



        If var_open_Recipt = 2 Then
            Dim report As New GL
            report.X_Date1.Text = Frm_ReciptCash2.txt_date.Value
            report.X_Date2.Text = Frm_ReciptCash2.txt_date2.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If var_open_Recipt = 4 Then
            Dim report As New estlam_Check3
            report.X_Date1.Text = Frm_ReportChek.txt_date.Value
            report.X_Date2.Text = Frm_ReportChek.txt_date2.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If var_open_Recipt = 5 Then
            Dim report As New Mnsrf_Check
            report.X_Date1.Text = Frm_ReportChek.txt_date.Value
            report.X_Date2.Text = Frm_ReportChek.txt_date2.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub
End Class