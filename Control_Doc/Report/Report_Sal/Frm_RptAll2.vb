Public Class Frm_RptAll2

    Private Sub Frm_RptAll2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If varStores1 = 2 Then
            Dim report As New Gard_ItemAll
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.XrLabel29.Text = Frm_ReportStores2.Com_StoresNo.Text
            report.X_Date1.Text = Frm_ReportStores2.txt_date.Value
            report.X_Date2.Text = Frm_ReportStores2.txt_date2.Value
            report.FilterString = "[Stores] Like '%" & Frm_ReportStores2.Com_StoresNo.Text & "%'    "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If varStores1 = 1 Then
            Dim report As New Invintory_Type
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.XrLabel5.Text = frm_ReportTypeInvintory.Com_type.Text
            report.X_Date1.Text = frm_ReportTypeInvintory.txt_date.Value
            report.X_Date2.Text = frm_ReportTypeInvintory.txt_date2.Value
            report.FilterString = "[Name] Like '%" & frm_ReportTypeInvintory.Com_type.Text & "%'    "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

    End Sub
End Class