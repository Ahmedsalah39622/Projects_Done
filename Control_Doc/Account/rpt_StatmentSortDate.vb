Public Class rpt_StatmentSortDate

    Private Sub rpt_Statment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If varstatment1 = 1 Then
        Dim report As New Account_StatmentSortDate
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.X_Date1.Text = Frm_AccountStatement2.txt_date1.Value
        report.X_Date2.Text = Frm_AccountStatement2.txt_date2.Value
        report.XrLabel29.Text = Frm_AccountStatement2.txt_NameAcc.Text

        report.XrLabel23.Text = Frm_AccountStatement2.txt_Balance.Text
        report.XrLabel24.Text = Frm_AccountStatement2.txt_total.Text

        'report.FilterString = "[AccountNo] Like '%" & Frm_AccountStatement.txt_codeAcc.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        'End If

    End Sub
End Class