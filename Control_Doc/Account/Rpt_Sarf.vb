Public Class Rpt_Sarf

    Private Sub Rpt_Sarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If varesal_Type = 1 Then
            Dim report As New Rpt_esalsarf
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.lab_TF.Text = Var_TF_Amount
            report.FilterString = "[Expenses_No] = '" & Frm_Expenses2.Com_Exp_No.Text & "' and [Code_Branch] = '" & varcode_Branch & "'   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        ElseIf varesal_Type = 0 Then

            Dim report As New Rpt_esalEstlam2
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.lab_TF.Text = Var_TF_Amount
            report.FilterString = "[Receipt_No] = '" & Frm_ReciptCash2.Com_Exp_No.Text & "' and [Code_Branch] = '" & varcode_Branch & "'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

    End Sub
End Class