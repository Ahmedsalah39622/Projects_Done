Imports CrystalDecisions.Shared.Json

Public Class Insurance_reports
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub ShowReport(reportCode)

        Dim report
        Select Case (reportCode)
            Case 1
                report = New ended_personal_license_Report
            Case 2
                report = New ended_nationalId_report
            Case 3
                report = New ended_passport_report
            Case 4
                report = New ended_insurance_document_report
            Case 5
                report = New ended_car_license_report
            Case 6
                report = New doc_going_to_end
            Case 7
                report = New Lisence_going_to_end_report

        End Select

        Try
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



End Class