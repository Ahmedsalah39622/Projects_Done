Public Class frm_BadelReport

    Private Sub frm_BadelReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If varEmpReport = 1 Then
            Dim report As New Salaryallowances
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[Emp_Month] = '" & Frm_Bdalat_Emp.com_month.Text & "' and [emp_year] = '" & Frm_Bdalat_Emp.com_year.Text & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub
End Class