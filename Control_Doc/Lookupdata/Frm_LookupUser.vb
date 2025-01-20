Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_LookupUser

    Private Sub Frm_LookupUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Sub Search()



        '   If varCodeConnaction = 1 Then '======Sql

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        'sql2 = "      SELECT        dbo.Users_Department.Code_Emp AS Code, dbo.Vw_Emp.Emp_Name AS Name FROM            dbo.Users_Department INNER JOIN       dbo.Vw_Emp ON dbo.Users_Department.Code_Emp = dbo.Vw_Emp.Emp_Code AND dbo.Users_Department.Compny_Code = dbo.Vw_Emp.Compny_Code " & _
        '" WHERE(dbo.Users_Department.Compny_Code = '" & VarCodeCompny & "')"

        sql2 = "      SELECT        dbo.Users_Department.Code_Emp AS Code, dbo.Vw_Emp.Emp_Name AS Name FROM            dbo.Users_Department INNER JOIN       dbo.Vw_Emp ON dbo.Users_Department.Code_Emp = dbo.Vw_Emp.Emp_Code AND dbo.Users_Department.Compny_Code = dbo.Vw_Emp.Compny_Code " & _
        " "

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).BestFit()
        GridView1.Columns(1).BestFit()
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "200"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '  End If


    End Sub



    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        choess_data()
    End Sub
    Sub choess_data()
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

      
        If VarOpenlookup2 = 600 Then
            Frm_Azn_AddItem.txt_AminStores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Else
            FrmLogin.txt_UserCode.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            FrmLogin.txt_UserName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        End If
        Me.Close()

    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            choess_data()
        End If
    End Sub

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub

End Class