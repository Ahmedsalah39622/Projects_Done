Public Class Frm_Report_Pr

    Private Sub Frm_Report_Pr_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If varopenRptprsheses = 0 Then

            Dim report As New Rpt_OrderPrsheses
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[Order_Stores_NO] = '" & Frm_OrderPrcheses.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If varopenRptprsheses = 1 And Frm_PrchesesPO.CheckEng.Checked = False Then

            Dim report As New RPT_PO
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.XrLabel43.Text = vartaxinvoice2
            report.XrLabel53.Text = vartalinvoice + vartaxinvoice2

            report.FilterString = "[Order_Stores_NO] = '" & Frm_PrchesesPO.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If varopenRptprsheses = 1 And Frm_PrchesesPO.CheckEng.Checked = True Then

            Dim report As New RPT_PO_Eng
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.XrLabel43.Text = vartaxinvoice2
            report.XrLabel33.Text = vartalinvoice + vartaxinvoice2

            report.FilterString = "[Order_Stores_NO] = '" & Frm_PrchesesPO.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If



        If varopenRptprsheses = 3 Then

            Dim report As New RPT_PO_Eng
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.FilterString = "[Order_Stores_NO] = '" & Frm_ShData.TXt_PONO.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub
End Class