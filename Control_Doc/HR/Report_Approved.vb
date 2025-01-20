Public Class Report_Approved

    Private Sub Report_Approved_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If varApproved = 1 Then
            Dim report As New HR_ApprovalDiscoundSalary
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[mm] = '" & Frm_FollwUP_HR.com_month.Text & "'  and [yy] = '" & Frm_FollwUP_HR.com_year.Text & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If varApproved = 2 Then
            Dim report As New HR_ApprovalAdvanceRequset
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[mm] = '" & Frm_FollwUP_HR.com_month2.Text & "'  and [yy] = '" & Frm_FollwUP_HR.com_year2.Text & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If varApproved = 3 Then
            Dim report As New HR_ApprovalLeaveRequest
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[mm] = '" & Frm_FollwUP_HR.com_Month3.Text & "'  and [yy] = '" & Frm_FollwUP_HR.com_year3.Text & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If varApproved = 4 Then
            Dim report As New HR_ApprovalAllowances
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[Emp_Month] = '" & Frm_FollwUP_HR.com_Month4.Text & "'  and [emp_year] = '" & Frm_FollwUP_HR.com_year4.Text & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


    End Sub
End Class