Public Class Frm_FindEmp

    Private Sub Frm_FindEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_ECGDataSet.Vw_Emp' table. You can move, or remove it, as needed.
        Me.Vw_EmpTableAdapter.Fill(Me.DB_ECGDataSet.Vw_Emp)

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click


        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        If varnoform = 1 Then
            frm_Estkta4.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            frm_Estkta4.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            frm_Estkta4.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            frm_Estkta4.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If


        If varnoform = 2 Then
            Frm_OpenReport.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_OpenReport.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_OpenReport.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_OpenReport.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If

        If varnoform = 3 Then
            Frm_Vaction.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_Vaction.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_Vaction.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_Vaction.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If

        If varnoform = 4 Then
            Frm_TimeDeprtment.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_TimeDeprtment.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_TimeDeprtment.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_TimeDeprtment.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If

        If varnoform = 5 Then
            Frm_Attendec.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_Attendec.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_Attendec.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_Attendec.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If


        If varnoform = 6 Then
            Frm_Payroll_Data.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_Payroll_Data.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_Payroll_Data.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_Payroll_Data.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If


        If varnoform = 7 Then
            Frm_addTimevalue.Com_Dir.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_addTimevalue.Com_Deprt.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_addTimevalue.Com_JopName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_addTimevalue.Com_Emp.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        End If
        Me.Close()
    End Sub
End Class