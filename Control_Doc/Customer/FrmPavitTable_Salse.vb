Public Class FrmPavitTable_Salse

    Private Sub FrmPavitTable_Salse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''TODO: This line of code loads data into the 'DB_EpslonDataSet3.Vw_allSalse_Pivet' table. You can move, or remove it, as needed.
        'Me.Vw_allSalse_PivetTableAdapter2.Fill(Me.DB_EpslonDataSet3.Vw_allSalse_Pivet)
        ''TODO: This line of code loads data into the 'DB_EpslonDataSet2.Vw_allSalse_Pivet' table. You can move, or remove it, as needed.
        'Me.Vw_allSalse_PivetTableAdapter1.Fill(Me.DB_EpslonDataSet2.Vw_allSalse_Pivet)
        ''TODO: This line of code loads data into the 'DB_EpslonDataSet1.Vw_allSalse_Pivet' table. You can move, or remove it, as needed.
        'Me.Vw_allSalse_PivetTableAdapter.Fill(Me.DB_EpslonDataSet1.Vw_allSalse_Pivet)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

        'PivotGridControl1.
    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
   

    End Sub

   

    Private Sub Cmd_Close_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PivotGridControl1.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'TODO: This line of code loads data into the 'DB_EpslonDataSet2.Vw_allSalse_Pivet' table. You can move, or remove it, as needed.
        Me.Vw_allSalse_PivetTableAdapter1.Fill(Me.DB_EpslonDataSet2.Vw_allSalse_Pivet)
        'TODO: This line of code loads data into the 'DB_EpslonDataSet1.Vw_allSalse_Pivet' table. You can move, or remove it, as needed.
        Me.Vw_allSalse_PivetTableAdapter.Fill(Me.DB_EpslonDataSet1.Vw_allSalse_Pivet)
    End Sub

    Private Sub Cmd_Close_Click_2(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub
End Class