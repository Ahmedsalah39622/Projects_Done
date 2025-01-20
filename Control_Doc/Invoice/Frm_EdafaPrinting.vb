Public Class Frm_EdafaPrinting

    Private Sub Frm_EdafaPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        Dim report As New RptEdafaPr
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.XrLabel29.Text = Frm_Azn_AddItem.Com_InvoiceNo2.Text
        report.XrLabel34.Text = Frm_Azn_AddItem.txt_date.Text
        report.LabInvoice_Type.Text = Frm_Azn_AddItem.Com_TypeItem.SelectedItem
        report.FilterString = " [Ser_NO_StoresAdd] = '" & Trim(Frm_Azn_AddItem.Com_InvoiceNo2.Text) & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class