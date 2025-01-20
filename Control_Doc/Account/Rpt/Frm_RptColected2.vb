Public Class Frm_RptColected2

    Private Sub Frm_RptColected2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     

        If var_open_Recipt = 5 Then
            Dim report2 As New Daily_production2
            report2.X_Date1.Text = frm_SaleReport.txt_date3.Value
            report2.X_Date2.Text = frm_SaleReport.txt_date4.Value
            If VarCodeCompny = 1 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 1 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2020\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report2.CreateDocument()
            DocumentViewer1.DocumentSource = report2
        End If

        If var_open_Recipt = 6 Then
            Dim report2 As New Colected_Salse3
            report2.X_Date1.Text = frm_SaleReport.txt_date1.Value
            report2.X_Date2.Text = frm_SaleReport.txt_date2.Value
            If VarCodeCompny = 1 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 1 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2020\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report2.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report2.CreateDocument()
            DocumentViewer1.DocumentSource = report2
        End If



    End Sub
End Class