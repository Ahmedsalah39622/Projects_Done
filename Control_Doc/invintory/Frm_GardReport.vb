Public Class Frm_GardReport

    Private Sub Frm_GardReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New CartItemRpt
        'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
      report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        report.X_Date1.Text = Frm_GardItem2.txt_date1.Value
        report.X_Date2.Text = Frm_GardItem2.txt_date2.Value
        report.XrLabel29.Text = Frm_GardItem2.txt_NameItem.Text

        report.Lab_Ref.Text = var_ref_prodact

        report.XrLabel23.Text = Frm_GardItem2.txt_Balance.Text
        report.XrLabel24.Text = Frm_GardItem2.txt_total.Text

        'report.FilterString = "[AccountNo] Like '%" & Frm_AccountStatement.txt_codeAcc.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        'End If
    End Sub
End Class