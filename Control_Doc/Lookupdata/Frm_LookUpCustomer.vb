Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_LookUpCustomer

    Sub Find_Customer()


        On Error Resume Next

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "      SELECT       Code, Name,GroupName        FROM dbo.Vw_AllCustomerAndSuppliser WHERE      Name like N'%" & txt_AccountName.Text & "%'  "


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
        GridView1.Columns(2).Caption = "النوع"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "150"
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    

    End Sub

    Sub fill_Project()
        On Error Resume Next
        sql2 = "SELECT LTRIM(dbo.TB_Header_OrderItem.PAO_NO) AS PAONO, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS ProjectName, dbo.ST_CHARTOFACCOUNT.AccountName AS CustomerNAme " & _
            " FROM     dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
            "                  dbo.TB_Header_PriceListCustomer ON dbo.ST_CHARTCOSTCENTER.Account_No = dbo.TB_Header_PriceListCustomer.Code_Project INNER JOIN " & _
            "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_PriceListCustomer.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No RIGHT OUTER JOIN " & _
            "                  dbo.TB_Header_OrderItem ON dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo = dbo.TB_Header_OrderItem.No_PriceList " & _
            " GROUP BY dbo.TB_Header_OrderItem.PAO_NO, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTOFACCOUNT.AccountName "


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "PAO"
        GridView1.Columns(1).Caption = "Project Name"
        GridView1.Columns(2).Caption = "Customer Name"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'End If

    End Sub
    Sub Find_Suppliser()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql2 = "      SELECT       Code, Name,GroupName        FROM dbo.Vw_AllCustomerAndSuppliser  WHERE       Name like '%" & txt_AccountName.Text & "%'  "






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
            GridView1.Columns(2).Caption = "الفرعى"

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True

            'GridView1.Columns(0).Width = "50"
            'GridView1.Columns(1).Width = "150"

            GridView1.BestFitColumns()
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub


    'Sub find_sales(cust_code)



    '    'If varCodeConnaction = 1 Then '======Sql

    '    Dim ss As String
    '    Dim con As New OleDb.OleDbConnection
    '    ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '           "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '    con.ConnectionString = ss
    '    con.Open()


    '    sql2 = "select * from vw_find_sal where Customer_AccountNo = '" & cust_code & "' "

    '    'rs = Cnn.Execute(sql)
    '    'If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"

    '    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)
    '    Dim dt = ds.Tables(0)
    '    Dim dr = dt.Rows(0)

    '    dr!Emp_Code = Val(Frm_PriceList_sal.txt_salesNo.Text)
    '    dr!Emp_Name = Frm_PriceList_sal.txt_sales.Text


    '    'rs = Cnn.Execute(sql2)
    '    'Frm_PriceList_sal.txt_salesNo.Text = rs("Emp_employees.Emp_Code")
    '    'Frm_PriceList_sal.txt_sales.Text = rs("Emp_employees.Emp_Name")

    '    con.Close()
    '    con.Dispose()
    '    'End If


    'End Sub

    Private Sub Frm_LookUpCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

    Private Sub Frm_LookUpCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GridView1.MakeRowVisible(rowKey)
        'GridView1.FocusedRowIndex = GridView1.FindVisibleIndexByKeyValue(rowKey)
    End Sub


    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub


    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs)


    End Sub
    Sub Chooes_Find()
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        'Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))

        If Len(value) = 0 Then Exit Sub
        If Len(value2) = 0 Then Exit Sub


        If VarOpenlookup2 = 23 Then
            Frm_OrderData.txt_AccountNo.Text = value
            Frm_OrderData.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 24 Then
            Frm_SalseInvoice.txt_AccountNo.Text = value
            Frm_SalseInvoice.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 2400 Then
            'Frm_SalseInvoice.txt_AccountNo.Text = value
            Frm_AznSarf.Txt_Customer.Text = value2
        End If

        If VarOpenlookup2 = 24004 Then
            Frm_OrderInvintory.Txt_PAO.Text = value
        End If


        If VarOpenlookup2 = 240240 Then

            Frm_Azn_AddItem2.txt_Customer.Text = value2
        End If

        If VarOpenlookup2 = 2400 Then
            Frm_InvoiceRented.txt_AccountNo.Text = value
            Frm_InvoiceRented.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 2424 Then
            Frm_Prcheses_Invoice.txt_AccountNo.Text = value
            Frm_Prcheses_Invoice.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 2425 Then
            Frm_Prcheses_Invoice_Rented.txt_AccountNo.Text = value
            Frm_Prcheses_Invoice_Rented.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 24240 Then
            Frm_PriceListSuppliser.txt_AccountNo.Text = value
            Frm_PriceListSuppliser.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 242404 Then
            Frm_Azn_AddItem.txt_CodeSuppliser.Text = value
            Frm_Azn_AddItem.txt_NameSuppliser.Text = value2
        End If

        If VarOpenlookup2 = 242401 Then
            'Frm_PriceListSuppliser.txt_AccountNo.Text = value
            ReportPrsheses_New.txt_NameSuppliser.Text = value2
        End If



        If VarOpenlookup2 = 500 Then
            Frm_PriceList_sal.txt_AccountNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            'find_sales(GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)))
            Frm_PriceList_sal.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 242401 Then
            varcodesuppliser = value
            ReportPrsheses_New.txt_NameSuppliser.Text = value2
        End If

        If VarOpenlookup2 = 24241 Then
            varcodesuppliser = value
            Frm_LastPriceList.txt_NameSuppliser.Text = value2
        End If

        If VarOpenlookup2 = 25 Then
            Frm_ReciptCash2.txt_AccountNo.Text = value
            Frm_ReciptCash2.txt_nameaccount.Text = value2
            'Frm_ReciptCash2.Lable_Type.Text = value3
        End If

        If VarOpenlookup2 = 25100 Then
            Frm_AccountStatement2.txt_codeAcc.Text = value
            Frm_AccountStatement2.txt_NameAcc.Text = value2
            'Frm_ReciptCash2.Lable_Type.Text = value3
        End If



        If VarOpenlookup2 = 2500 Then
            varcodecustomer = value
            Frm_ReportCustomer2.txt_NameCustomer.Text = value2
        End If

        If VarOpenlookup2 = 2510 Then
            varcodecustomer = value
            Frm_Check_Report.txt_NameCustomer.Text = value2
        End If

        If VarOpenlookup2 = 2505 Then
            varcodecustomer = value
            Frm_Report_Salse.txt_NameCustomer.Text = value2
        End If


        If VarOpenlookup2 = 26 Then
            Frm_Expenses2.txt_AccountNo.Text = value
            Frm_Expenses2.txt_nameaccount.Text = value2
        End If


        If VarOpenlookup2 = 26026 Then
            Frm_ReciptCash2.txt_AccountNo.Text = value
            Frm_ReciptCash2.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 26100 Then
            Frm_AccountStatement2.txt_codeAcc.Text = value
            Frm_AccountStatement2.txt_NameAcc.Text = value2
        End If

        If VarOpenlookup2 = 27 Then
            Frm_Gl4.txt_AccountNo.Text = value
            Frm_Gl4.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 28 Then
            Frm_Gl4.txt_AccountNo.Text = value
            Frm_Gl4.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 29 Then

            Frm_MentinenceOrder.txt_nameaccount.Text = value2
        End If

        If VarOpenlookup2 = 30 Then

            Frm_CustomerAndMachine.Com_CustomeName.Text = value2
        End If
        If VarOpenlookup2 = 31 Then

            frm_MachineAndItem.txt_MachineName.Text = value2
        End If

        If VarOpenlookup2 = 32 Then

            Frm_Contract_M.Com_CustomeName.Text = value2
        End If

        If VarOpenlookup2 = 33 Then

            Frm_Order_M.Com_CustomeName.Text = value2
        End If
        Me.Close()
    End Sub
    Private Sub txt_AccountName_KeyPress(sender As Object, e As KeyPressEventArgs)
        'GridView1.ShowFilterEditor()
    End Sub






    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            Chooes_Find()
        End If
    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Chooes_Find()
    End Sub

    Private Sub txt_AccountName_TextChanged_1(sender As Object, e As EventArgs) Handles txt_AccountName.TextChanged
        'On Error Resume Next
        If varcode_form = 27 Then Find_Customer()
        If varcode_form = 28 Then Find_Suppliser()
        If varcode_form = 25 Then Find_Customer()
        If varcode_form = 26 Then Find_Suppliser()
        If varcode_form = 26100 Then Find_Suppliser()
        If varcode_form = 23 Then Find_Customer()
        If varcode_form = 25100 Then Find_Customer()
        If varcode_form = 242401 Then Find_Suppliser()
        If varcode_form = 500 Then Find_Customer()


        If varcode_form = 2510 Then Find_Customer()
        If varcode_form = 2500 Then Find_Customer()
        If varcode_form = 2505 Then Find_Customer()

    End Sub
End Class