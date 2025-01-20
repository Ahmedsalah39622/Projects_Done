Public Class Frm_TrilBalanceRpt

    Private Sub Frm_TrilBalanceRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If var_open_TrilBalance <> 4 Then
            Dim report As New TrilBalance2
            report.X_Date1.Text = Frm_TrialBalnce3.txt_date.Value
            report.X_Date2.Text = Frm_TrialBalnce3.txt_date2.Value

            If var_open_TrilBalance = 1 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 1"
            If var_open_TrilBalance = 2 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 2"
            If var_open_TrilBalance = 3 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 3"
            If var_open_TrilBalance = 5 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 4"
            If var_open_TrilBalance = 6 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة تفصيلى"

            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If



        If var_open_TrilBalance = 4 Then
            Dim report As New SubReportAccount1
            report.X_Date1.Text = Frm_AccDetils2.txt_date.Value
            report.X_Date2.Text = Frm_AccDetils2.txt_date2.Value

            report.XAccountName.Text = Frm_AccDetils2.txt_Name.Text

            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If var_open_TrilBalance = 6 Then
            Dim report As New TrilBalanceall
            report.X_Date1.Text = Frm_TrialBalnce3.txt_date.Value
            report.X_Date2.Text = Frm_TrialBalnce3.txt_date2.Value
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If var_open_TrilBalance = 1 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 1"
            'If var_open_TrilBalance = 2 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 2"
            'If var_open_TrilBalance = 3 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 3"
            'If var_open_TrilBalance = 5 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة مستوى 4"
            If var_open_TrilBalance = 6 Then report.Txt_Titel.Text = "ميزان مراجعة خلال فترة تفصيلى"

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If





    End Sub
End Class