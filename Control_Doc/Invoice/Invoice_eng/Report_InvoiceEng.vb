Public Class Report_InvoiceEng
    Dim vartext As String
    Private Sub Report_InvoiceEng_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If vardisplayReport = 255 Then
            Dim report As New PriceList_Eng
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.XrLabel26.Text = Frm_SalseInvoice.txt_Tax.Text
            report.XrLabel35.Text = Frm_SalseInvoice.Txt_TotalAll.Text


            report.FilterString = "[Ext_InvoiceNo] = '" & Frm_SalseInvoice.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 260 Then



            Dim report As New Invoice_Change
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            Var_TF_Amount = NoToTxt(Frm_SalseInvoice.Txt_TotalAll.Text, "جنيها مصريا", "قرش")

            If var_warnty = 0 Then report.Txt_Warnty.Visible = False : report.Lab_Warnty.Visible = False
            If var_warnty = 1 Then report.Txt_Warnty.Visible = True : report.Lab_Warnty.Visible = True

            report.lab_Box.Text = varTaxcardCompny
            report.Lab_SB.Text = varCommercialCompny
            report.lab_Fotter.Text = varAddressCompny


            If Frm_SalseInvoice.RadioButton1.Checked = True Then vartext = "أجل"
            If Frm_SalseInvoice.RadioButton2.Checked = True Then vartext = "نقدى"

            report.LabInvoice_Type.Text = vartext

            report.XrLabel26.Text = Frm_SalseInvoice.txt_Tax.Text
            report.XrLabel35.Text = Frm_SalseInvoice.Txt_TotalAll.Text
            report.LabTfket.Text = Var_TF_Amount
            report.lab_discount.Text = Frm_SalseInvoice.Txt_Discount.Text

            report.Lab_Codation1.Text = varcondation1
            report.Lab_Codation2.Text = varcondation2

            report.FilterString = "[Ext_InvoiceNo] = '" & Frm_SalseInvoice.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 261 Then



            Dim report As New Invoice_Change
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 1 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")


            Var_TF_Amount = NoToTxt(Frm_SalseInvoice.Txt_TotalAll.Text, "جنيها مصريا", "قرش")

            If var_warnty = 0 Then report.Txt_Warnty.Visible = False : report.Lab_Warnty.Visible = False
            If var_warnty = 1 Then report.Txt_Warnty.Visible = True : report.Lab_Warnty.Visible = True

            If Frm_SalseInvoice.RadioButton1.Checked = True Then vartext = "أجل"
            If Frm_SalseInvoice.RadioButton2.Checked = True Then vartext = "نقدى"

            report.LabInvoice_Type.Text = vartext
            report.XrPictureBox1.Visible = False
            'report.Lab_CompnyName.Visible = False
            report.lab_Box.Text = varTaxcardCompny
            report.Lab_SB.Text = varCommercialCompny
            'report.lab_Fotter.Text = varAddressCompny

            report.lab_Fotter.Visible = False

            report.XrLabel26.Text = Frm_SalseInvoice.txt_Tax.Text
            report.XrLabel35.Text = Frm_SalseInvoice.Txt_TotalAll.Text
            report.LabTfket.Text = Var_TF_Amount
            report.lab_discount.Text = Frm_SalseInvoice.Txt_Discount.Text

            report.Lab_Codation1.Text = varcondation1
            report.Lab_Codation2.Text = varcondation2

            report.FilterString = "[Ext_InvoiceNo] = '" & Frm_SalseInvoice.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub
End Class