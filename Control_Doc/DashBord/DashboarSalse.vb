Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class DashboarSalse

    Private Sub DashboardDesigner1_Load(sender As Object, e As EventArgs)

        'DashboardDesigner1.CalculateHiddenTotals = True
    End Sub

    Private Sub DashboarSalse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DashboardDesigner1.LoadDashboard("E:\interpak03-05-2019\XMLSalse\Reigon.xml")
        'Dim AppDash As Dashboard = New Dashboard
        'AppDash.LoadFromXml("E:\interpak03-05-2019\XMLSalse\Expenses.xml")
        'DashboardDesigner1.Dashboard = AppDash

        DashboardDesigner1.LoadDashboard("E:\interpak03-05-2019\XMLSalse\Expenses.xml")

    End Sub

    Private Sub Applications_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim AppDash As Dashboard = New Dashboard
        'AppDash.LoadFromXml(Application.StartupPath & "\XMLSalse\Reigon.xml")
        'DashboardDesigner1.Dashboard = AppDash
    End Sub

    Private Sub DashboardViewer1_ConfigureDataConnection(sender As Object, e As ConfigureDataConnectionEventArgs) Handles DashboardDesigner1.ConfigureDataConnection
        'Dim pcp As MsSqlConnectionParameters = TryCast(e.ConnectionParameters, MsSqlConnectionParameters)
        'pcp.Password = "omar2007"
        'pcp.UserName = "css"
        'pcp.AuthorizationType = MsSqlAuthorizationType.SqlServer
    End Sub
End Class