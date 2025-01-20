Public Class Frm_Rest

    Private Sub Frm_Rest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New Rpt_Rest
        varinv_Ext_Invoice = Frm_InvoiceCashir.Com_InvoiceNo2.Text
        report.lab_Deposit.Text = Frm_InvoiceCashir.lb_totalInv.Text
        report.lab_Rem.Text = Frm_InvoiceCashir.txt_rest.Text
        report.XrLabel7.Text = Frm_InvoiceCashir.txt_date.Text
        report.XrLabel6.Text = Frm_InvoiceCashir.txt_NameSalse.Text
        report.XrLabel29.Text = Frm_InvoiceCashir.txt_nameaccount.Text


        report.FilterString = "[Ext_InvoiceNo] = '" & varinv_Ext_Invoice & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub
End Class