Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_LookUpSalse
    Sub Find_Salse()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        'sql2 = "     SELECT        dbo.Vw_Emp.Emp_Code, dbo.Vw_Emp.Emp_Name " & _
        '         " FROM            dbo.Emp_employees INNER JOIN " & _
        '         "                         dbo.Vw_Emp ON dbo.Emp_employees.Emp_Code = dbo.Vw_Emp.Emp_Code AND dbo.Emp_employees.Compny_Code = dbo.Vw_Emp.Compny_Code INNER JOIN " & _
        '         "                         dbo.St_CostCenterLv3Link_Salse ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.St_CostCenterLv3Link_Salse.Code_Diractorat " & _
        '         " where  Emp_employees.Compny_Code ='" & VarCodeCompny & "'  " & _
        '         " GROUP BY dbo.Vw_Emp.Emp_Code, dbo.Vw_Emp.Emp_Name having Vw_Emp.Emp_Name like '%" & varlikename & "%' "

        sql2 = "  SELECT Emp_Code AS Code, Emp_Name AS Name          FROM dbo.Emp_employees      WHERE(Emp_Code_Dirctorat = 12)"



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

        GridView1.Columns(0).Width = "50"
        GridView1.Columns(1).Width = "150"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Sub Find_Salse_amin()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "  SELECT Emp_Code AS Code, Emp_Name AS Name          FROM dbo.Emp_employees      WHERE(Emp_Code_Dirctorat = 16)"



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

        GridView1.Columns(0).Width = "50"
        GridView1.Columns(1).Width = "150"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub


    Sub chooes_data()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))


        'If value = "" Then Exit Sub
        'If value2 = "" Then Exit Sub

        If VarOpenlookup3 = 24 Then
            Frm_OrderData.txt_CodeSalse.Text = value
            Frm_OrderData.txt_NameSalse.Text = value2
        End If

        If VarOpenlookup3 = 2020 Then
            Frm_PriceList_sal.txt_salesNo.Text = value
            Frm_PriceList_sal.txt_sales.Text = value2
        End If

        If VarOpenlookup3 = 24024 Then

            'Frm_Cust.txt_namesalse.Text = value2
        End If

        If VarOpenlookup3 = 25 Then
            Frm_ReciptCash2.txt_No_Salse.Text = value
            Frm_ReciptCash2.txt_Name_Salse.Text = value2
        End If

        If VarOpenlookup3 = 2700 Then
            Frm_Azn_AddItem.varAmineCode = value
            Frm_Azn_AddItem.txt_AminStores.Text = value2
        End If

        If VarOpenlookup3 = 25250 Then
            Frm_ReportCustomer2.txt_NameSalse.Text = value2
        End If

        If VarOpenlookup3 = 25251 Then
            Frm_Report_Salse.txt_NameSalse.Text = value2
        End If

        If VarOpenlookup3 = 26 Then
            Expenses.txt_No_Salse.Text = value
            Expenses.txt_Name_Salse.Text = value2
        End If


        If VarOpenlookup3 = 27 Then
            Frm_SalseInvoice.txt_CodeSalse.Text = value
            Frm_SalseInvoice.txt_NameSalse.Text = value2
        End If

        If VarOpenlookup3 = 270 Then
            Frm_InvoiceRented.txt_CodeSalse.Text = value
            Frm_InvoiceRented.txt_NameSalse.Text = value2
        End If

        If VarOpenlookup3 = 28 Then
            Frm_Expenses2.txt_No_Salse.Text = value
            Frm_Expenses2.txt_Name_Salse.Text = value2
        End If
        Me.Close()
    End Sub



   

   

    Private Sub Frm_LookUpSalse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

   
  
    

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        chooes_data()
    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            chooes_data()
        End If
    End Sub


    Private Sub Frm_LookUpSalse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class