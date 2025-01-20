Imports DevExpress.XtraReports.UI
Imports System.IO

Public Class Frm_Report_all

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rep As XtraReport = XtraReport.FromFile(Path.Combine("E:\16-12-2019\", "Report1.repx"), True)
        'DocumentViewer1.DocumentSource = rep

        If vardisplayReport = 0 Then
            Dim report As New Customer1
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 1 Then
            Dim report As New Rpt_TotalInvoice
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport = 3 Then
            Dim report As New CustomerMthslat
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport = 7 Then
            Dim report As New AmarDuon
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 5 Then
            Dim report As New Rpt_Customer_Item
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 6 Then
            Dim report As New Rpt_Azn_Estlam_Customer
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            'report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If vardisplayReport = 9 Then
            Dim report As New Report_RentedInvoice
            report.X_Date1.Text = Frm_ReportCustomer.txt_date.Value
            report.X_Date2.Text = Frm_ReportCustomer.txt_date2.Value
            report.Txt_Titel.Text = Frm_ReportCustomer.LabelX1.Text
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")


            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub

    'Private Function LoadDataTable(ByVal tableName As String) As DataTable

    '    'Dim cmd As New OleDb.OleDbCommand("SELECT * FROM " & tableName, Cnn)
    '    'Dim dt As New DataTable(tableName)

    '    'Cnn.Open()
    '    'dt.Load(cmd.ExecuteReader)
    '    'Cnn.Close()
    '    'Return dt

    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim report As New DevExpress.XtraReports.UI.XtraReport()
        'report.LoadLayout("E:\16-12-2019\Report1.repx")
        'Dim reportDataSet As DataSet = TryCast(report.DataSource, DataSet)
        'Dim newDataSet As New DataSet(reportDataSet.DataSetName)


        '' Load DataTables from current Connection
        'For Each dt As DataTable In reportDataSet.Tables()
        '    Dim newDataTable As DataTable = LoadDataTable(dt.TableName())
        '    newDataSet.Tables.Add(newDataTable)
        'Next


        '' Set New DataSource
        'report.DataSource = newDataSet


        'Show(report)
        'PrintControl1.PrintingSystem = report.PrintingSystem
        'report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, DevExpress.XtraPrinting.CommandVisibility.None)
        'report.CreateDocument(True)
        'Dim report As New XtraReport
        'Dim filePath As String = "E:\16-12-2019\Report1.repx"
        '' Save a report's layout to the file.  
        'report.SaveLayout(filePath)
        '' Restore a report's layout from the specified file.  
        'report.LoadLayout(filePath)
        ''Create a report designer.  
        'Dim dt As New ReportDesignTool(report)
        '' Invoke the standard End-User Designer form.  
        'dt.



        'Dim Report As New XtraReport
        'Dim FilePath As String = "E:\16-12-2019\Report1.repx"

        'Report.LoadLayout(FilePath)

        'ReportDesigner1.OpenReport(Report) '<<-- OPEN THE REPORT IN THE REPORT DESIGNER  
    End Sub
End Class