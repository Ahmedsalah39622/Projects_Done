Imports System.Data.OleDb

Public Class Frm_LookupItem

    Private Sub Frm_LookupItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_data()
    End Sub
    Sub find_data()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT     code,rtrim(Ex_Item) asEx_Item ,rtrim(name) as name,MG,G2,balance " & _
" FROM        Vw_AllDataItem where Compny_Code ='" & VarCodeCompny & "' and  Ex_Item like '%" & txt_FindRef.Text & "%' and name like '%" & txt_Name.Text & "%'  "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)



        DataGridView1.Columns(0).HeaderText = "كود الصنف"
        DataGridView1.Columns(1).HeaderText = "رقم Ref"
        DataGridView1.Columns(2).HeaderText = "الصنف"
        DataGridView1.Columns(3).HeaderText = "المجموعة الرئيسية"
        DataGridView1.Columns(4).HeaderText = "مجموعة 1"
        'DataGridView1.Columns(5).HeaderText = "مجموعة 2"
        DataGridView1.Columns(5).HeaderText = "الرصيد"

        DataGridView1.Columns(2).Width = "200"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()
    End Sub

   
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Dim ro, mt As Integer

        ro = DataGridView1.CurrentRow.Index
        mt = ro
        If varcode_form = 25500 Then
            Frm_Azn_AddItem.varItemCode = DataGridView1.Item(0, mt).Value
            'Frm_Azn_AddItem.Com_NameItem.Text = DataGridView1.Item(2, mt).Value
        End If
        Me.Close()
    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs)
        find_data()
    End Sub

    Private Sub txt_FindRef_TextChanged(sender As Object, e As EventArgs) Handles txt_FindRef.TextChanged
        find_data()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Cmd_Find_Click_1(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        find_data()
    End Sub

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged
        find_data()
    End Sub
End Class