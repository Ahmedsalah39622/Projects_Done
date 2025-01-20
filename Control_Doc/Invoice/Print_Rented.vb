Public Class Print_Rented

    Private Sub Print_Rented_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vardisplayReport = 250 Then 'مرتجع بيع عربى
            Dim report As New Rented_Invoice_eng
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.XrLabel26.Text = Frm_InvoiceRented.txt_Tax.Text
            report.XrLabel35.Text = Frm_InvoiceRented.Txt_TotalAll.Text

            report.FilterString = "[Ser_InvoiceNo] = '" & Frm_InvoiceRented.Com_InvoiceNo.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport = 251 And Frm_PriceList_sal.CheckEng.Checked = False Then 'عرض سعر عربى
            'Dim report As New PriceList_sal
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'report.XrLabel35.Text = Frm_PriceList_sal.txt_totalPrice.Text
            'report.lab_Notes3.Text = varNotesCompny
            'report.lab_Box.Text = varTaxcardCompny
            'report.Lab_SB.Text = varCommercialCompny
            'report.lab_Fotter.Text = varAddressCompny
            'report.FilterString = "[Ext_InvoiceNo] = '" & Frm_PriceList_sal.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            'report.CreateDocument()
            'DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 2510 Then 'عرض سعر عربى
            'Dim report As New PriceList_sal
            ''report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'report.XrLabel35.Text = Frm_PriceList_sal.txt_totalPrice.Text
            'report.lab_Notes3.Text = varNotesCompny
            'report.lab_Box.Text = varTaxcardCompny
            'report.Lab_SB.Text = varCommercialCompny
            'report.lab_Fotter.Text = varAddressCompny
            'report.lab_Fotter.Visible = False
            'report.FilterString = "[Ext_InvoiceNo] = '" & Frm_PriceList_sal.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            'report.CreateDocument()
            'DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport = 25100 And Frm_PriceList_sal.CheckEng.Checked = True Then 'عرض سعر انجليزى
            Dim report As New InvoiceEng2
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.XrLabel26.Text = vartaxinvoice2
            'report.XrLabel35.Text = Frm_PriceList_sal.txt_totalPrice.Text
            report.lab_Notes3.Text = varNotesCompny
            report.lab_Box.Text = varTaxcardCompny
            report.Lab_SB.Text = varCommercialCompny
            'report.lab_Fotter.Text = varAddressCompny
            report.FilterString = "[Ext_InvoiceNo] = '" & Frm_PriceList_sal.Com_InvoiceNo2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If





        If vardisplayReport = 2700 Then 'Offer
            Dim report As New OfferMain
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          
            report.FilterString = "[Ext_InvoiceNo] = '" & Frm_PriceList_sal.Com_InvoiceNo2.Text & "'    "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report


        

        End If
    End Sub
End Class