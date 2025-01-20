Public Class Frm_InvoicePrintPrchesess

    Private Sub Frm_InvoicePrintPrchesess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New Invoice_Prchesess
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

        Var_TF_Amount = NoToTxt(Frm_Prcheses_Invoice.Txt_TotalAll.Text, "جنيها مصريا", "قرش")



        report.lab_Box.Text = varTaxcardCompny
        report.Lab_SB.Text = varCommercialCompny
        report.lab_Fotter.Text = varAddressCompny

        report.XrLabel26.Text = Frm_Prcheses_Invoice.txt_Tax.Text
        report.XrLabel35.Text = Frm_Prcheses_Invoice.Txt_TotalAll.Text
        report.LabTfket.Text = Var_TF_Amount
        report.lab_discount.Text = Frm_Prcheses_Invoice.txt_Dis2.Text

        report.Lab_Codation1.Text = varcondation1
        report.Lab_Codation2.Text = varcondation2

        report.FilterString = "[Ext_InvoiceNo] = '" & Frm_Prcheses_Invoice.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class