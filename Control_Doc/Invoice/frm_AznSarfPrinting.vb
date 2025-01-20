Public Class frm_AznSarfPrinting

    Private Sub frm_AznSarfPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Dim report As New RptAznSarfPr
        
        report.XrLabel29.Text = Frm_AznSarf.Com_InvoiceNo2.Text
        report.XrLabel34.Text = Frm_AznSarf.txt_date.Value
        'report.LabInvoice_Type.Text = Frm_AznSarf.Com_Type.Text

        'report.XrLabel26.Text = Frm_SalseInvoice.txt_Tax.Text
        'report.XrLabel35.Text = Frm_SalseInvoice.Txt_TotalAll.Text
        'report.LabTfket.Text = Var_TF_Amount
        'report.lab_discount.Text = Frm_SalseInvoice.Txt_Discount.Text

        'report.Lab_Codation1.Text = varcondation1
        'report.Lab_Codation2.Text = varcondation2
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = " [Ser_Order_Stores] = '" & Trim(Frm_AznSarf.Com_InvoiceNo2.Text) & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

    End Sub
End Class