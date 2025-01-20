Public Class Frm_DashBoardAcc

    Private Sub Frm_DashBoardAcc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DashboardDesigner1.Dashboard
        DashboardDesigner1.LoadDashboard("\\192.168.1.7\ecg files\xml\Account\CashBox.xml")
        'DashboardDesigner1



    End Sub
End Class