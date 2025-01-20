Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_LookUpSuppliser
    Sub Find_Suppliser()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql2 = " SELECT       Supliser_AccountNo AS code, Supliser_Name AS Name FROM            dbo.St_SuppliserData WHERE        (Compny_Code ='" & VarCodeCompny & "') and Supliser_Name like '%" & txt_FindName.Text & "%' "





            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True

            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"

            GridView1.BestFitColumns()



            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

       
    End Sub

    Private Sub Frm_LookUpSuppliser_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub




    Private Sub Frm_LookUpCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Search()
    End Sub

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub


    Sub chooes_data()
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))




        If VarOpenlookup2 = 2525 Then
            Frm_PrchesesPO.txt_AccountNo.Text = value
            Frm_PrchesesPO.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 25250 Then
            'Frm_PrchesesPO.txt_AccountNo.Text = value
            Frm_ReportCost.Com_SuppliserName.Text = value2
        End If


        If VarOpenlookup2 = 25251 Then
            'Frm_PrchesesPO.txt_AccountNo.Text = value
            Frm_ReportExpSh.Com_SuppliserName.Text = value2
        End If


        If VarOpenlookup2 = 25252 Then
            'Frm_PrchesesPO.txt_AccountNo.Text = value
            Frm_ReportCostItem.Com_SuppliserName.Text = value2
        End If

        If VarOpenlookup2 = 25253 Then
            'Frm_PrchesesPO.txt_AccountNo.Text = value
            Frm_ReportDaily.Com_SuppliserName.Text = value2
        End If
        Me.Close()
    End Sub


    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        chooes_data()
    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            chooes_data()
        End If
    End Sub

    Private Sub txt_FindName_TextChanged(sender As Object, e As EventArgs) Handles txt_FindName.TextChanged
        On Error Resume Next
        Find_Suppliser()
    End Sub
End Class