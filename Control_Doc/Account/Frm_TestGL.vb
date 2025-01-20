Public Class Frm_TestGL

    Private Sub Frm_TestGL_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Escape Then
        '    Me.Close()

        'End If
    End Sub
    Private Sub DataTable_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        
    End Sub


    Private Sub Frm_TestGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_InterpakDataSet2.Vw_All_GL_Data' table. You can move, or remove it, as needed.
        'Me.Vw_All_GL_DataTableAdapter.Fill(Me.DB_InterpakDataSet2.Vw_All_GL_Data)

    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs) Handles FillByToolStripButton.Click
        Try
            'Me.Vw_All_GL_DataTableAdapter.FillBy(Me.DB_InterpakDataSet2.Vw_All_GL_Data)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl3.KeyDown
       
    End Sub
End Class