Public Class Rpt_ResivedStores_Print

    Private Sub Rpt_ResivedStores_Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If var_recived_Stores = 1 Then

            Dim report As New Rpt_ResivedStores
            report.FilterString = "[Order_Stores_NO] = '" & Frm_AznSarf2.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If var_recived_Stores = 2 Then

            Dim report As New Rpt_ResivedStores2
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[Order_Stores_NO] = '" & Frm_AznSarf2.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If var_recived_Stores = 3 Then

            Dim report As New Rpt_ResivedStores
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[Order_Stores_NO] = '" & Frm_AznSarf2.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

    End Sub
End Class