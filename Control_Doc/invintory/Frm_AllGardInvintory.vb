Public Class Frm_AllGardInvintory

    Private Sub Frm_AllGardInvintory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_KAISSY_NewDataSet.vw_all_Gard2' table. You can move, or remove it, as needed.
        'Me.Vw_all_Gard2TableAdapter.Fill(Me.DB_KAISSY_NewDataSet.vw_all_Gard2)

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        PivotGridControl1.ShowRibbonPrintPreview()

    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub
End Class