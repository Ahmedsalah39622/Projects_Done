Imports ADODB
Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_LookUpAccount

    Dim varnameteble As String



    Sub Fill_Alldata()
        ''On Error Resume Next


        'sql = ""

        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()



        'If varcode_form = 4 Or varcode_form = 7 Then
        '    sql = "SELECT     code,name " & _
        '    " FROM        " & VARTBNAME2 & "  "

        'ElseIf varcode_form = 9 Then

        '    sql = "SELECT     code,name " & _
        '    " FROM        " & VARTBNAME2 & " where  Flag_status ='" & varflagstatus & "'  "

        'ElseIf varcode_form = 14 Then

        '    sql = "SELECT     code,name " & _
        '    " FROM        " & VARTBNAME2 & " where code_sub <> '" & varcodesub & "'  "

        'ElseIf varcode_form = 5 Then

        '    sql = "SELECT     code,name " & _
        '    " FROM        " & VARTBNAME2 & " "

        'ElseIf varcode_form = 47 Then

        '    sql = "SELECT     Code,name " & _
        '    " FROM        " & VARTBNAME2 & ""





        'End If


        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        ''create a new dataset
        'Dim ds As New DataSet()
        ''fill the datset
        'da.Fill(ds)
        ''attach dataset to the datagrid


        'GridControl1.DataSource = ds.Tables(0)


        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"


        'GridView1.Columns(0).Caption = "الكود"
        'GridView1.Columns(1).Caption = "الاسم"




        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()
        ''ds.Clear()

    End Sub



    Sub Fill_Customer()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      FindCustomer where Compny_Code ='" & VarCodeCompny & "' and name like '%" & txt_AccountName.Text & "%'  "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
      

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_Stores()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      BD_Stores where Compny_Code ='" & VarCodeCompny & "' and name like '%" & txt_AccountName.Text & "%'   "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_Acc()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      vw_AccountData  where   (Compny_Code = '" & VarCodeCompny & "') and name like '%" & txt_FindName.Text & "%'   "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
      

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_Acc_Withount_CustomerSupliser()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)
        'If VarCodeCompny = 2 Then varnameteble = "Vw_AccountCompny2"
        If VarCodeCompny = 1 Then varnameteble = "Vw_AccountCompny1"
        'If VarCodeCompny = 3 Then varnameteble = "Vw_AccountCompny3"

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      " & varnameteble & "  where   (Compny_Code = '" & VarCodeCompny & "')  and name like '%" & txt_FindName.Text & "%' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "300"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_AccBox()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_AccountBox  where   (Compny_Code = '" & VarCodeCompny & "') and name like '%" & txt_AccountName.Text & "%'  "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_AccKabd()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_Accountkabd  where   (Compny_Code = '" & VarCodeCompny & "') and name like '%" & txt_AccountName.Text & "%' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_ConvertBank()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_LookupBank  where   (Compny_Code = '" & VarCodeCompny & "') and name like '%" & txt_AccountName.Text & "%'  "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_AccBank()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_AccountBank  where   (Compny_Code = '" & VarCodeCompny & "')  and name like '%" & txt_AccountName.Text & "%' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_AccChek()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_ChekThsel  where   (Compny_Code = '" & VarCodeCompny & "')  and name like '%" & txt_AccountName.Text & "%' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_AccDfa()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_AccDfa  where   (Compny_Code = '" & VarCodeCompny & "') and name like '%" & txt_AccountName.Text & "%' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub
    Sub Fill_NoAzn()
        'On Error Resume Next
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter("", con)

        GridView1.Columns.Clear()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql = "SELECT     Code,name " & _
        " FROM      Vw_LookUp_FirstItem where Compny_Code ='" & VarCodeCompny & "' and Flag_status ='" & varflagstatus & "' and name like '%" & txt_AccountName.Text & "%'    "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid
        GridControl1.DataSource = ds.Tables(0)
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub



    Sub all_data()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))




        If varcode_form = 7 Then


            Frm_FristItem.txt_codestores.Text = value
            Frm_FristItem.txt_namestores.Text = value2
        End If


        If varcode_form = 77 Then


            Frm_Invintory_FirstItem.txt_codestores.Text = value
            Frm_Invintory_FirstItem.txt_namestores.Text = value2
        End If

        If varcode_form = 770 Then


            Frm_SetupGenral.txt_CodeStores.Text = value
            Frm_SetupGenral.txt_NameStores.Text = value2
        End If

        If varcode_form = 17 Then

            Frm_FristItem.txt_codestores2.Text = value
            Frm_FristItem.txt_namestores2.Text = value2
        End If

        'If varcode_form = 27 Then
        '    Seting_Acc.txt_AccountNo6.Text = DataGridView2.Item(0, mt).Value
        '    Seting_Acc.txt_nameaccount6.Text = DataGridView2.Item(1, mt).Value
        'End If

        If varcode_form = 8 Then

            Frm_FristItem.txt_CodeItem.Text = value
            Frm_FristItem.txt_NameItem.Text = value2
        End If


        If varcode_form = 9 Then
            Frm_FristItem.Com_InvoiceNo.Text = value


        End If



        If varcode_form = 410410 Then
            Frm_Prcheses_Invoice.txt_AccountNo2.Text = value
            Frm_Prcheses_Invoice.txt_nameaccount2.Text = value2
        End If


        If varcode_form = 19 Then
            Frm_FristItem.txt_CodeItem.Text = value
            Frm_FristItem.txt_NameItem.Text = value2

        End If


        If varcode_form = 20 Then
            Frm_SetupGenral.txt_AccountNosal.Text = value
            Frm_SetupGenral.txt_nameaccount.Text = value2

        End If

        If varcode_form = 21 Then
            Frm_SetupGenral.txt_AccountNo2.Text = value
            Frm_SetupGenral.txt_nameaccount2.Text = value2

        End If


        If varcode_form = 22 Then
            Frm_SetupGenral.txt_AccountNo3.Text = value
            Frm_SetupGenral.txt_nameaccount3.Text = value2

        End If



        If varcode_form = 23 Then
            Frm_SetupGenral.txt_AccountNo4.Text = value
            Frm_SetupGenral.txt_nameaccount4.Text = value2

        End If

        If varcode_form = 24 Then
            Frm_SetupGenral.txt_AccountNo7.Text = value
            Frm_SetupGenral.txt_nameaccount7.Text = value2

        End If

        If varcode_form = 25 Then
            Frm_SetupGenral.txt_AccountNo8.Text = value
            Frm_SetupGenral.txt_nameaccount8.Text = value2

        End If


        If varcode_form = 26 Then
            Frm_SetupGenral.txt_AccountNo5.Text = value
            Frm_SetupGenral.txt_nameaccount5.Text = value2

        End If


        If varcode_form = 27 Then
            Frm_SetupGenral.txt_AccountNo6.Text = value
            Frm_SetupGenral.txt_nameaccount6.Text = value2

        End If

        If varcode_form = 28 Then
            Frm_SetupGenral.txt_AccountNo9.Text = value
            Frm_SetupGenral.txt_nameaccount9.Text = value2

        End If

        If varcode_form = 29 Then
            Frm_SetupGenral.txt_AccountNo10.Text = value
            Frm_SetupGenral.txt_nameaccount10.Text = value2

        End If


        If varcode_form = 30 Then
            Frm_AccountStatement.txt_codeAcc.Text = value
            Frm_AccountStatement.txt_NameAcc.Text = value2

        End If

        If varcode_form = 3011 Then
            Frm_AccountStatement2.txt_codeAcc.Text = value
            Frm_AccountStatement2.txt_NameAcc.Text = value2

        End If

        If varcode_form = 300 Then
            'Frm_AccountStatement.txt_codeAcc.Text = value
            Frm_Check_Report.txt_NameCustomer.Text = value2

        End If

        If varcode_form = 3001 Then
            Frm_ChartOfAccount2.txt_accno1.Text = value
            Frm_ChartOfAccount2.txt_AccName1.Text = value2

        End If

        If varcode_form = 34 Then
            Frm_ReciptCash.txt_AccountNo1.Text = value
            Frm_ReciptCash.txt_NameAccount1.Text = value2
        End If


        If varcode_form = 35 Then
            Frm_ReciptCash.txt_AccountNo2.Text = value
            Frm_ReciptCash.txt_NameAccount2.Text = value2
        End If



        If varcode_form = 36 Then
            Expenses.txt_AccountNo1.Text = value
            Expenses.txt_NameAccount1.Text = value2
        End If


        If varcode_form = 37 Then
            Expenses.txt_AccountNo2.Text = value
            Expenses.txt_NameAccount2.Text = value2
        End If



        If varcode_form = 38 Then
            Frm_SetupGenral.txt_accTax.Text = value
            Frm_SetupGenral.txt_NameAccTax.Text = value2
        End If

        If varcode_form = 380 Then
            Frm_SetupGenral.txt_accTax2.Text = value
            Frm_SetupGenral.txt_NameAccTax2.Text = value2
        End If

        If varcode_form = 39 Then
            Frm_SetupGenral.txt_AccountNo_Stores.Text = value
            Frm_SetupGenral.txt_AccountName_Stores.Text = value2
        End If

        If varcode_form = 40 Then
            Frm_SetupGenral.txt_AccountNoStore.Text = value
            Frm_SetupGenral.txt_AccountNameStore.Text = value2
        End If

        If varcode_form = 404 Then
            Frm_SetupGenral.txt_AccountCostStore.Text = value
            Frm_SetupGenral.txt_AccountNameCostStore.Text = value2
        End If

        If varcode_form = 41 Then
            Frm_ReciptCash2.txt_AccountNo.Text = value
            Frm_ReciptCash2.txt_nameaccount.Text = value2
        End If


        If varcode_form = 41100 Then
            Frm_AccountStatement2.txt_codeAcc.Text = value
            Frm_AccountStatement2.txt_NameAcc.Text = value2
        End If


        If varcode_form = 42 Then
            Frm_ReciptCash2.Txt_AccountNo2.Text = value
            Frm_ReciptCash2.Txt_AccountName2.Text = value2
        End If

        If varcode_form = 49 Then
            Frm_FristItem.txt_AccountNo.Text = value
            Frm_FristItem.txt_nameaccount.Text = value2

        End If



        If varcode_form = 43 Then
            Frm_ReciptCash2.Txt_AccountNo2.Text = value
            Frm_ReciptCash2.Txt_AccountName2.Text = value2
        End If


        If varcode_form = 444 Then
            Frm_ReciptCash2.Txt_AccountNo2.Text = value
            Frm_ReciptCash2.Txt_AccountName2.Text = value2
        End If

        If varcode_form = 44 Then
            Frm_ReciptCash2.Txt_AccountNo2.Text = value
            Frm_ReciptCash2.Txt_AccountName2.Text = value2
        End If


        If varcode_form = 45 Then
            Frm_Expenses2.txt_AccountNo.Text = value
            Frm_Expenses2.txt_nameaccount.Text = value2
        End If




        If varcode_form = 46 Then
            Frm_Expenses2.Txt_AccountNo2.Text = value
            Frm_Expenses2.Txt_AccountName2.Text = RTrim(value2)
        End If

        If varcode_form = 47 Then
            Frm_Expenses2.Txt_AccountNo2.Text = value
            Frm_Expenses2.Txt_AccountName2.Text = RTrim(value2)
        End If

        If varcode_form = 47047 Then
            Frm_Expenses2.Txt_AccountNo2.Text = value
            Frm_Expenses2.Txt_AccountName2.Text = RTrim(value2)
        End If

        If varcode_form = 48 Then
            Frm_Gl4.txt_AccountNo.Text = value
            Frm_Gl4.txt_nameaccount.Text = value2
        End If


        If varcode_form = 49 Then
            Frm_ReciptCash2.Txt_AccountNoBank.Text = value
            Frm_ReciptCash2.Txt_AccountNameBank.Text = value2
        End If


        If varcode_form = 50 Then
            Frm_ReciptCash2.Txt_AccountNoBank.Text = value
            Frm_ReciptCash2.Txt_AccountNameBank.Text = value2
        End If

        If varcode_form = 5005 Then
            Frm_Expenses2.Txt_AccountNoBank.Text = value
            Frm_Expenses2.Com_Bank.Text = value2
        End If
        If varcode_form = 51 Then
            Frm_ReciptCash2.Txt_AccountNoBank.Text = value
            Frm_ReciptCash2.Txt_AccountNameBank.Text = value2
        End If


        If varcode_form = 301 Then
            Frm_OpenE3tmad.txt_BankEtmad.Text = value2
        End If
        Me.Close()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs)
       
    End Sub

    Private Sub txt_AccountName_TextChanged(sender As Object, e As EventArgs)
        'If varcode_form = 48 Then Fill_Acc()
        'If varcode_form = 41 Then Fill_Acc()
        'If varcode_form = 43 Then Fill_AccBox()
        'If varcode_form = 44 Then Fill_AccKabd()
        'If varcode_form = 30 Then Fill_Acc()
        'If varcode_form = 45 Then Fill_Acc()
        'If varcode_form = 50 Then Fill_AccBank()
        'If varcode_form = 51 Then Fill_AccChek()

    End Sub

    Private Sub txt_AccountNo_TextChanged(sender As Object, e As EventArgs)
        'If varcode_form = 48 Then Fill_Acc()
        'If varcode_form = 41 Then Fill_Acc()
        'If varcode_form = 43 Then Fill_AccBox()
        'If varcode_form = 44 Then Fill_AccKabd()
        'If varcode_form = 30 Then Fill_Acc()
        'If varcode_form = 45 Then Fill_Acc()
        'If varcode_form = 51 Then Fill_AccChek()
        'If varcode_form = 50 Then Fill_AccBank()

    End Sub

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub


   
    Private Sub Frm_LookUpAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

   
   

    Private Sub GridControl1_KeyPress1(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            all_data()
        End If
    End Sub

    Private Sub Frm_LookUpAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_FindName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_2(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        all_data()
    End Sub

    Private Sub GridControl1_KeyPress2(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            all_data()

        End If
    End Sub

    Private Sub txt_FindName_TextChanged_1(sender As Object, e As EventArgs) Handles txt_FindName.TextChanged
        If varcode_form = 48 Then Fill_Acc_Withount_CustomerSupliser()
        If varcode_form = 41 Then Fill_Acc_Withount_CustomerSupliser()
        If varcode_form = 41100 Then Fill_Acc_Withount_CustomerSupliser()
        'If varcode_form = 43 Then Fill_AccBox()
        'If varcode_form = 44 Then Fill_AccKabd()
        If varcode_form = 30 Then Fill_Acc()
        If varcode_form = 3011 Then Fill_Acc_Withount_CustomerSupliser()
        If varcode_form = 45 Then Fill_Acc()
        'If varcode_form = 50 Then Fill_AccBank()
        'If varcode_form = 51 Then Fill_AccChek()


        If varcode_form = 300 Then Fill_Acc()

    End Sub

    Private Sub LabelX2_Click(sender As Object, e As EventArgs) Handles LabelX2.Click

    End Sub
End Class