Public Class Rpt_Reqest_Order

    Private Sub Rpt_Reqest_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vardisplayReport = 320 Then
            Dim report As New RPT_RequstOrder
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.FilterString = "[Order_NO] = '" & Frm_OrderData.Com_InvoiceNo2.Text & "'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 322 Then


            sql = "  SELECT Order_NO, PAO_NO, AccountName           FROM dbo.PAO_Report WHERE  (Order_NO = '" & Frm_OrderData.Com_InvoiceNo2.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then VarPAO_NO = rs("pao_no").Value : varNameProject = rs("accountName").Value



            Dim report As New PAO
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If Frm_OrderData.CheckBox3.Checked = True Then report.XrCheckBox1.Checked = True : report.XrCheckBox2.Checked = False
            If Frm_OrderData.CheckBox4.Checked = True Then report.XrCheckBox1.Checked = False : report.XrCheckBox2.Checked = True

            report.lab_pao.Text = VarPAO_NO
            report.lab_Customer.Text = Frm_OrderData.txt_nameaccount.Text
            report.lab_order.Text = Frm_OrderData.Com_InvoiceNo2.Text
            report.lab_day.Text = Frm_OrderData.txt_countDay.Text
            report.lab_project.Text = varNameProject

            'report.FilterString = "[Order_NO] = '" & Frm_OrderData.Com_InvoiceNo2.Text & "'    "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


    End Sub
End Class