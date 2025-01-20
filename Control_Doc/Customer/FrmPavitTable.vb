Public Class FrmPavitTable

    Private Sub FrmPavitTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_EpslonDataSet.vw_Sal_CustomerYear' table. You can move, or remove it, as needed.
        Me.Vw_Sal_CustomerYearTableAdapter.Fill(Me.DB_EpslonDataSet.vw_Sal_CustomerYear)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'PivotGridControl1.Sho()
        PivotGridControl1.ShowRibbonPrintPreview()
        PivotGridControl1.ShowPrintPreview()
        'PivotGridControl1.Scale =fit to

    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub
End Class