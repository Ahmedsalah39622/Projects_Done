Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_SetupGenral
    Dim varck1, varck2, varck3, varck4, varck5, varck6, varck7 As Integer
    Public storeCode As Integer
    Dim varcodeGroup1 As Integer
    Sub Find()
        'On Error Resume Next


        sql = "  SELECT St_AccountLv3LinkCustomer.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_AccountLv3LinkCustomer INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_AccountLv3LinkCustomer.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_AccountLv3LinkCustomer.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl2.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView4.Columns(0).Caption = "الكود"
            GridView4.Columns(1).Caption = "الاسم"
            GridView4.Columns(0).Width = "20"
            GridView4.Columns(1).Width = "50"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl2.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView4.Columns(0).Caption = "الكود"
            GridView4.Columns(1).Caption = "الاسم"
            GridView4.Columns(0).Width = "20"
            GridView4.Columns(1).Width = "50"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Sub FindBranchSetting()
        'On Error Resume Next


        '        sql = "  SELECT         dbo.BD_SUBMAIN.Name AS Branch, " & _
        '               "          dbo.ST_CHARTOFACCOUNT2.AccountName AS Cash, ST_CHARTOFACCOUNT2_1.AccountName AS Visa, ST_CHARTOFACCOUNT2_2.AccountName AS wallet, dbo.BD_Stores.Name AS Store " & _
        '" FROM            dbo.BD_POS_Setting INNER JOIN " & _
        '            "             dbo.BD_SUBMAIN ON dbo.BD_POS_Setting.branch_Code = dbo.BD_SUBMAIN.Code AND dbo.BD_POS_Setting.company_code = dbo.BD_SUBMAIN.Compny_Code INNER JOIN " & _
        '             "            dbo.BD_Stores ON dbo.BD_POS_Setting.store_Code = dbo.BD_Stores.Code AND dbo.BD_POS_Setting.company_code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
        '              "           dbo.ST_CHARTOFACCOUNT2 ON dbo.BD_POS_Setting.cash_Account = dbo.ST_CHARTOFACCOUNT2.Account_No AND dbo.BD_POS_Setting.company_code = dbo.ST_CHARTOFACCOUNT2.Compny_Code INNER JOIN " & _
        '               "          dbo.ST_CHARTOFACCOUNT2 AS ST_CHARTOFACCOUNT2_1 ON dbo.BD_POS_Setting.visa_Account = ST_CHARTOFACCOUNT2_1.Account_No AND " & _
        '                "         dbo.BD_POS_Setting.company_code = ST_CHARTOFACCOUNT2_1.Compny_Code INNER JOIN " & _
        '                 "        dbo.ST_CHARTOFACCOUNT2 AS ST_CHARTOFACCOUNT2_2 ON dbo.ST_CHARTOFACCOUNT2.Account_No = ST_CHARTOFACCOUNT2_2.Account_No AND " & _
        '                  "       dbo.BD_POS_Setting.wallet_Code = ST_CHARTOFACCOUNT2_2.Account_No AND dbo.BD_POS_Setting.company_code = ST_CHARTOFACCOUNT2_2.Compny_Code WHERE        (dbo.BD_POS_Setting.company_code = '" & VarCodeCompny & "')  "
        sql = "select * from vw_setting_Pos"
        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl6.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "الفرع"
            GridView6.Columns(1).Caption = "الخزينه"
            GridView6.Columns(2).Caption = "الكاش"
            GridView6.Columns(3).Caption = "الفيزا"
            GridView6.Columns(4).Caption = "المخزن"
            GridView6.Columns(5).Caption = "حساب المبيعات"
            GridView6.Columns(6).Caption = "حساب الخصم"


            GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
            GridView6.Appearance.Row.Options.UseFont = True

            GridView6.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

      
    End Sub

    Sub find_BranchData()
        sql2 = "SELECT         dbo.BD_POS_Setting.branch_Code, dbo.BD_POS_Setting.wallet_Code, dbo.BD_POS_Setting.cash_Account, dbo.BD_POS_Setting.visa_Account, dbo.BD_POS_Setting.store_Code , dbo.BD_POS_Setting.sale_AccCode,dbo.BD_POS_Setting.disc_AccCode, dbo.BD_POS_Setting.inv_serial" & _
" FROM            dbo.BD_POS_Setting INNER JOIN " & _
  "                       dbo.BD_SUBMAIN ON dbo.BD_POS_Setting.branch_Code = dbo.BD_SUBMAIN.Code AND dbo.BD_POS_Setting.company_code = dbo.BD_SUBMAIN.Compny_Code " & _
" WHERE        (dbo.BD_POS_Setting.company_code = '" & VarCodeCompny & "') AND (dbo.BD_SUBMAIN.Name = N'" & txt_BranchName.Text & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then
            'sizeItem = rs("Kilo_Item").Value Else sizeItem = 0.0
            txt_BranchCode.Text = rs("branch_Code").Value
            txt_CashCode.Text = rs("wallet_Code").Value
            TextBox1.Text = rs("cash_Account").Value
            TextBox4.Text = rs("visa_Account").Value
            storeCode = rs("store_Code").Value
            txt_accCode.Text = rs("sale_AccCode").Value
            txt_disAccCode.Text = rs("disc_AccCode").Value
            txt_invSerial.Text = rs("inv_serial").Value

        End If


    End Sub

    Sub Find_CostCenterSalse()
        On Error Resume Next
 
   
        'sql = "SELECT        dbo.ST_CHARTCOSTCENTER.Account_No, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS AccountName, dbo.BD_DIRCTORAY.Name AS NameDirector, dbo.St_CostCenterLv3Link_Salse.Account_NoMain,  " & _
        '"                         dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameMain " & _
        '" FROM            dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
        '"                         dbo.St_CostCenterLv3Link_Salse ON dbo.ST_CHARTCOSTCENTER.Compny_Code = dbo.St_CostCenterLv3Link_Salse.Compny_Code AND  " & _
        '"                         dbo.ST_CHARTCOSTCENTER.Account_No = dbo.St_CostCenterLv3Link_Salse.Account_NoCostCenter INNER JOIN " & _
        '"                         dbo.BD_DIRCTORAY ON dbo.St_CostCenterLv3Link_Salse.Code_Diractorat = dbo.BD_DIRCTORAY.Code INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.St_CostCenterLv3Link_Salse.Account_NoMain = dbo.ST_CHARTOFACCOUNT.Account_No where dbo.ST_CHARTCOSTCENTER.Compny_Code ='" & VarCodeCompny & "'  "

        sql = "SELECT        dbo.ST_CHARTCOSTCENTER.Account_No, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS AccountName, dbo.BD_DIRCTORAY.Name AS NameDirector, dbo.St_CostCenterLv3Link_Salse.Account_NoMain,  " & _
"                         dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameMain " & _
"FROM            dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
"                         dbo.St_CostCenterLv3Link_Salse ON dbo.ST_CHARTCOSTCENTER.Compny_Code = dbo.St_CostCenterLv3Link_Salse.Compny_Code AND  " & _
"                         dbo.ST_CHARTCOSTCENTER.Account_No = dbo.St_CostCenterLv3Link_Salse.Account_NoCostCenter INNER JOIN " & _
"                         dbo.BD_DIRCTORAY ON dbo.St_CostCenterLv3Link_Salse.Code_Diractorat = dbo.BD_DIRCTORAY.Code AND dbo.St_CostCenterLv3Link_Salse.Compny_Code = dbo.BD_DIRCTORAY.Compny_Code INNER JOIN " & _
"                         dbo.ST_CHARTOFACCOUNT ON dbo.St_CostCenterLv3Link_Salse.Account_NoMain = dbo.ST_CHARTOFACCOUNT.Account_No AND  " & _
"        dbo.St_CostCenterLv3Link_Salse.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
" WHERE        (dbo.ST_CHARTCOSTCENTER.Compny_Code = '" & VarCodeCompny & "') "
        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "أسم مركز التكلفة"
            GridView1.Columns(2).Caption = "أسم الادارة"
            GridView1.Columns(3).Caption = "رقم الحساب الرئيسى"
            GridView1.Columns(4).Caption = "أسم الحساب الرئيسى"

            GridView1.Columns(0).Width = "20"
            GridView1.Columns(1).Width = "50"
            GridView1.Columns(2).Width = "50"
            GridView1.Columns(3).Width = "50"
            GridView1.Columns(4).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "أسم مركز التكلفة"
            GridView1.Columns(2).Caption = "أسم الادارة"
            GridView1.Columns(3).Caption = "رقم الحساب الرئيسى"
            GridView1.Columns(4).Caption = "أسم الحساب الرئيسى"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub
    Private Sub txt_AccountName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 7
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        Dim sql2 As String

        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_AccountLv3LinkCustomer where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_AccountLv3LinkCustomer (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find()
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete St_AccountLv3LinkCustomer  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find()
    End Sub

    

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        Dim value = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        Dim value2 = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(1))
        txt_AccountNo.Text = value
        txt_AccountName.Text = value2
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sql2 As String
        Dim varcodedept As Integer
        If Len(txt_AccountNoCostCenter.Text) = 0 Then MsgBox("من فضلك ادخل رقم مركز التكلفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNameCostCenter.Text) = 0 Then MsgBox("من فضلك ادخل أسم مركز التكلفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql2 = "  SELECT Account_NoCostCenter, Compny_Code      FROM St_CostCenterLv3Link_Salse where Compny_Code = " & VarCodeCompny & " and Account_NoCostCenter ='" & txt_AccountNoCostCenter.Text & "' and Account_NoMain ='" & txt_AccountNoMain.Text & "'"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '================
        sql = "  SELECT        Name, Code       FROM dbo.BD_DIRCTORAY WHERE        (Name = '" & txt_NameDeprt.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodedept = rs("code").Value


        sql2 = "INSERT INTO St_CostCenterLv3Link_Salse (Account_NoCostCenter, Compny_Code,Account_NoMain,Code_Diractorat) " & _
          " values  ('" & txt_AccountNoCostCenter.Text & "' ,'" & VarCodeCompny & "','" & txt_AccountNoMain.Text & "','" & varcodedept & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_CostCenterSalse()
    End Sub

    
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        txt_AccountNoCostCenter.Text = value
        txt_AccountNameCostCenter.Text = value2
        txt_NameDeprt.Text = value3
    End Sub

    Private Sub txt_AccountNameCostCenter_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountNameCostCenter.ButtonClick
        vartable = "Vw_LookupAccountLv2_CostCenter"
        VarOpenlookup = 10
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()


    End Sub

  

    Private Sub Frm_SetupGenral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FindBranchSetting()
        fill_TypeInvoice()
        Find()
        Find_CostCenterSalse()
        find_settingItem()
        find_tax()
        fill_group1()
    End Sub
    Sub fill_group1()
        com_NameGroup1.Items.Clear()
        sql = " Select Name    FROM dbo.BD_GROUPITEMMAIN where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_NameGroup1.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop


    End Sub
    Sub fill_TypeInvoice()
        Com_Group_Item.Items.Clear()
        sql = "SELECT        Name FROM            dbo.TB_InvoiceType where Compny_Code  = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Group_Item.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub


    Private Sub txt_NameDeprt_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameDeprt.ButtonClick
        vartable = "BD_DIRCTORAY"
        VarOpenlookup = 11
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub txt_AccountNameMain_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountNameMain.ButtonClick
        vartable = "Vw_AccountMain"
        VarOpenlookup = 22
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Sub find_acc()
        On Error Resume Next
        sql = " select * from vw_All_SetingAcc where Name ='" & Com_Group_Item.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_AccountNosal.Text = rs("AccountNo_Sal").Value
            txt_AccountNo2.Text = rs("AccountNo_SalRented").Value
            txt_AccountNo3.Text = rs("AccountNo_Prcheses").Value
            txt_AccountNo4.Text = rs("AccountNo_PrchesesRented").Value
            txt_AccountNo5.Text = rs("AccountNo_Cash").Value
            txt_AccountNo6.Text = rs("AccountNo_Stores").Value
            txt_AccountNo7.Text = rs("AccountNo_Discount1").Value
            txt_AccountNo8.Text = rs("AccountNo_Discount2").Value
            txt_AccountNo9.Text = rs("AccountNo_CostSal").Value
            '========================================
            txt_nameaccount.Text = rs("AccountName").Value
            txt_nameaccount2.Text = rs("Rentsal").Value
            txt_nameaccount3.Text = rs("Acc_Prcheses").Value
            txt_nameaccount4.Text = rs("Acc_PrchesesRented").Value
            txt_nameaccount5.Text = rs("Acc_Cash").Value
            'txt_nameaccount6.Text = rs("Namestores").Value
            'txt_nameaccount7.Text = rs("Acc_discount").Value
            'txt_nameaccount8.Text = rs("Acc_Discount2").Value
            'txt_nameaccount9.Text = rs("AccountNameCost").Value
        Else
            txt_AccountNosal.Text = ""
            txt_AccountNo2.Text = ""
            txt_AccountNo3.Text = ""
            txt_AccountNo4.Text = ""
            txt_AccountNo5.Text = ""
            txt_AccountNo6.Text = ""
            txt_AccountNo7.Text = ""
            txt_AccountNo8.Text = ""
            txt_AccountNo9.Text = ""
            '========================================
            txt_nameaccount.Text = ""
            txt_nameaccount2.Text = ""
            txt_nameaccount3.Text = ""
            txt_nameaccount4.Text = ""
            txt_nameaccount5.Text = ""
            txt_nameaccount6.Text = ""
            txt_nameaccount7.Text = ""
            txt_nameaccount8.Text = ""
            txt_nameaccount9.Text = ""
        End If
    End Sub








    Private Sub Com_Group_Item_SelectedIndexChanged(sender As Object, e As EventArgs)
        find_acc()
    End Sub



    Private Sub SimpleButton15_Click_1(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 20
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 21
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 22
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 23
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 24
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 25
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub


    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 29
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 26
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 27
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 28
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub


    Private Sub Cmd_SaveAcc_Click(sender As Object, e As EventArgs) Handles Cmd_SaveAcc.Click
        Dim varcodeGroup As Integer

        If Len(txt_AccountNosal.Text) = 0 Then MsgBox("من فضلك ادخل حساب المبيعات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل حساب مرتجع المبيعات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo3.Text) = 0 Then MsgBox("من فضلك ادخل حساب المشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo4.Text) = 0 Then MsgBox("من فضلك ادخل حساب مرتجع المشتريات ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_AccountNo9.Text) = 0 Then MsgBox("من فضلك ادخل حساب المخزون ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        '=============================================Group
        sql = "  SELECT        Code, Name       FROM dbo.TB_InvoiceType WHERE        (Name = '" & Com_Group_Item.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeGroup = rs("code").Value
        '==================================================delete
        sql = "Delete Setup_Acc_Group  WHERE Code_Group = " & varcodeGroup & " and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '==========================================



        sql = "INSERT INTO Setup_Acc_Group (Code_Group, AccountNo_Sal,AccountNo_SalRented,AccountNo_Prcheses,AccountNo_PrchesesRented,AccountNo_Cash,AccountNo_Stores,AccountNo_Discount1,AccountNo_Discount2,AccountNo_CostSal,Compny_Code) " & _
            " values  ('" & varcodeGroup & "' ,'" & txt_AccountNosal.Text & "','" & txt_AccountNo2.Text & "','" & txt_AccountNo3.Text & "','" & txt_AccountNo4.Text & "','" & txt_AccountNo5.Text & "','" & txt_AccountNo6.Text & "','" & txt_AccountNo7.Text & "','" & txt_AccountNo8.Text & "','" & txt_AccountNo9.Text & "','" & VarCodeCompny & "' )"
        Cnn.Execute(sql)


        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub Cmd_DeleteAcc_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteAcc.Click
        sql = "Delete St_CostCenterLv3Link_Salse  WHERE Compny_Code = " & VarCodeCompny & " and Account_NoCostCenter ='" & txt_AccountNoCostCenter.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find()

    End Sub




    Sub find_settingItem()
        sql = "  SELECT        Balance_Item, Auto_ItemNo, Exp_Item, Stores_User, PostAuto_Inv, Cru_Active, Atue_DateExp   FROM dbo.S_Genral_Setting where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varck1 = rs("Balance_Item").Value
            varck2 = rs("Auto_ItemNo").Value
            varck3 = rs("Exp_Item").Value
            varck4 = rs("Stores_User").Value
            varck5 = rs("PostAuto_Inv").Value
            varck6 = rs("Cru_Active").Value
            varck7 = rs("Atue_DateExp").Value

        End If

        'If varck1 = 1 Then CK1.Checked = True Else CK1.Checked = False
        'If varck2 = 1 Then CK2.Checked = True Else CK2.Checked = False
        'If varck3 = 1 Then CK3.Checked = True Else CK3.Checked = False
        'If varck4 = 1 Then CK4.Checked = True Else CK4.Checked = False
        'If varck5 = 1 Then CK5.Checked = True Else CK5.Checked = False
        'If varck6 = 1 Then CK6.Checked = True Else CK6.Checked = False
        'If varck7 = 1 Then CK7.Checked = True Else CK7.Checked = False


    End Sub

    Private Sub Com_Group_Item_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_Group_Item.SelectedIndexChanged
        find_acc()
    End Sub


    Private Sub Cmd_saveTax_Click(sender As Object, e As EventArgs)

    End Sub
    Sub find_tax()
        On Error Resume Next
        '        sql = "SELECT        dbo.Tb_TaxInvoice.Tax_Sal, dbo.Tb_TaxInvoice.Account_Tax, ST_CHARTOFACCOUNT_1.AccountName, dbo.Tb_TaxInvoice.Account_Stores, dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameStores, " & _
        '"                         dbo.Tb_TaxInvoice.Compny_Code " & _
        '" FROM            dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON ST_CHARTOFACCOUNT_1.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code RIGHT OUTER JOIN " & _
        '"                         dbo.Tb_TaxInvoice ON dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.Tb_TaxInvoice.Compny_Code AND dbo.ST_CHARTOFACCOUNT.Account_No = dbo.Tb_TaxInvoice.Account_Stores AND  " & _
        '"        ST_CHARTOFACCOUNT_1.Account_No = dbo.Tb_TaxInvoice.Account_Tax " & _
        ' "       WHERE(dbo.Tb_TaxInvoice.Compny_Code = '" & VarCodeCompny & "') "


        sql = " SELECT dbo.Tb_TaxInvoice.Tax_Sal, dbo.Tb_TaxInvoice.Account_Tax, ST_CHARTOFACCOUNT_1.AccountName, dbo.Tb_TaxInvoice.Account_Stores, dbo.ST_CHARTOFACCOUNT.AccountName AS AccountNameStores, " & _
 "                  dbo.Tb_TaxInvoice.Compny_Code, dbo.Tb_TaxInvoice.Account_Tax2, ST_CHARTOFACCOUNT_2.AccountName AS Account_NameTax2 " & _
 " FROM     dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_2 RIGHT OUTER JOIN " & _
 "                  dbo.Tb_TaxInvoice ON ST_CHARTOFACCOUNT_2.Account_No = dbo.Tb_TaxInvoice.Account_Tax2 AND ST_CHARTOFACCOUNT_2.Compny_Code = dbo.Tb_TaxInvoice.Compny_Code LEFT OUTER JOIN " & _
 "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 INNER JOIN " & _
 "                  dbo.ST_CHARTOFACCOUNT ON ST_CHARTOFACCOUNT_1.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code ON dbo.Tb_TaxInvoice.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
 "        dbo.Tb_TaxInvoice.Account_Stores = dbo.ST_CHARTOFACCOUNT.Account_No And dbo.Tb_TaxInvoice.Account_Tax = ST_CHARTOFACCOUNT_1.Account_No " & _
 " WHERE  (dbo.Tb_TaxInvoice.Compny_Code = '" & VarCodeCompny & "') "



        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_tax.Text = rs("Tax_Sal").Value : txt_accTax.Text = rs("Account_Tax").Value : txt_NameAccTax.Text = rs("AccountName").Value
            txt_AccountNo_Stores.Text = rs("Account_Stores").Value : txt_AccountName_Stores.Text = rs("AccountNameStores").Value
            txt_accTax2.Text = rs("Account_Tax2").Value : txt_NameAccTax2.Text = rs("AccountName").Value

        Else
            txt_tax.Text = "0"

        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Cmd_saveTax_Click_1(sender As Object, e As EventArgs) Handles Cmd_saveTax.Click
        sql = "Delete Tb_TaxInvoice where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        sql = "INSERT INTO Tb_TaxInvoice (Tax_Sal,Account_Tax,Account_Stores,Compny_Code,Account_Tax2) " & _
    " values  ('" & txt_tax.Text & "','" & txt_accTax.Text & "','" & txt_AccountNo_Stores.Text & "','" & VarCodeCompny & "','" & txt_accTax2.Text & "')"
        Cnn.Execute(sql)


        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_tax()
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 38
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton16_Click_1(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 39
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub txt_AccountNameCostCenter_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountNameCostCenter.EditValueChanged

    End Sub

    Private Sub txt_AccountNameMain_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountNameMain.EditValueChanged

    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        'VARTBNAME = "vw_AccountData"
        varcode_form = 40
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        If Len(com_NameGroup1.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNoStore.Text) = 0 Then MsgBox("من فضلك ادخل حساب  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If CheckWarnty.Checked = True Then var_warnty = 1
        If CheckWarnty.Checked = False Then var_warnty = 0



        '=============================================Group1
        sql = "SELECT        Name, Code     FROM dbo.BD_GROUPITEMMAIN WHERE        (Name = '" & com_NameGroup1.Text & "') and Compny_Code='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeGroup1 = rs("code").Value
        '==================================================delete
        sql = "Delete TB_SettingGroup1  WHERE Group1No = " & varcodeGroup1 & " and Compny_Code='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        '==========================================



        sql = "INSERT INTO TB_SettingGroup1 (Group1No, AccountNoGroup,warnty,Compny_Code,FlgPrint_Warnty,AccountNoGroup2,Code_Stores) " & _
            " values  ('" & varcodeGroup1 & "' ,'" & txt_AccountNoStore.Text & "','" & txt_Warantey.Text & "','" & VarCodeCompny & "','" & var_warnty & "','" & txt_AccountCostStore.Text & "','" & txt_CodeStores.Text & "')"
        Cnn.Execute(sql)


        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub com_NameGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_NameGroup1.SelectedIndexChanged
        On Error Resume Next

        txt_AccountNoStore.Text = "" : txt_AccountNameStore.Text = "" : txt_Warantey.Text = "" : txt_AccountCostStore.Text = "" : txt_AccountNameCostStore.Text = ""
        txt_CodeStores.Text = ""
        txt_NameStores.Text = ""

        sql = "   SELECT dbo.BD_GROUPITEMMAIN.Name, dbo.TB_SettingGroup1.AccountNoGroup, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.TB_SettingGroup1.Compny_Code, dbo.TB_SettingGroup1.warnty, dbo.TB_SettingGroup1.FlgPrint_Warnty, " & _
   "                  dbo.TB_SettingGroup1.AccountNoGroup2, ST_CHARTOFACCOUNT_1.AccountName AS AccountName2, dbo.TB_SettingGroup1.Code_Stores, dbo.BD_Stores.Name AS NameStors  " & _
   " FROM     dbo.TB_SettingGroup1 INNER JOIN  " & _
   "                  dbo.BD_GROUPITEMMAIN ON dbo.TB_SettingGroup1.Group1No = dbo.BD_GROUPITEMMAIN.code AND dbo.TB_SettingGroup1.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code LEFT OUTER JOIN  " & _
   "                  dbo.BD_Stores ON dbo.TB_SettingGroup1.Code_Stores = dbo.BD_Stores.Code LEFT OUTER JOIN  " & _
   "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_SettingGroup1.AccountNoGroup = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.TB_SettingGroup1.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code LEFT OUTER JOIN  " & _
   "                  dbo.ST_CHARTOFACCOUNT AS ST_CHARTOFACCOUNT_1 ON dbo.TB_SettingGroup1.AccountNoGroup2 = ST_CHARTOFACCOUNT_1.Account_No  " & _
   " WHERE  (dbo.TB_SettingGroup1.Compny_Code = '" & VarCodeCompny & "') AND (dbo.BD_GROUPITEMMAIN.Name = '" & com_NameGroup1.Text & "') "
        rs = Cnn.Execute(sql)

        If rs.EOF = False Then
            txt_AccountNoStore.Text = rs("AccountNoGroup").Value
            txt_AccountNameStore.Text = rs("AccountName").Value
            txt_Warantey.Text = rs("warnty").Value : txt_AccountCostStore.Text = rs("AccountNoGroup2").Value
            txt_AccountNameCostStore.Text = rs("AccountName2").Value
            txt_CodeStores.Text = rs("Code_Stores").Value
            txt_NameStores.Text = rs("NameStors").Value
            If rs("FlgPrint_Warnty").Value = 1 Then CheckWarnty.Checked = True Else CheckWarnty.Checked = False

        Else
            txt_AccountNoStore.Text = "" : txt_AccountNameStore.Text = "" : txt_Warantey.Text = "" : txt_AccountCostStore.Text = "" : txt_AccountNameCostStore.Text = "" : txt_CodeStores.Text = " : txt_NameStores.Text = """
        End If
    End Sub

  
   

    Private Sub SimpleButton20_Click(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        Dim sql2 As String

        If Len(txt_AccountNoBank.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNameBank.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_AccountLv3LinkCustomer where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_AccountLv3LinkCustomer (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNoBank.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 380
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

   

    Private Sub txt_CashName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CashName.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 200003
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 200004
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub ButtonEdit4_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit4.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 200005
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_BranchName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_BranchName.ButtonClick
        vartable = "BD_SUBMAIN"
        VarOpenlookup = 39000000
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit2.ButtonClick

        vartable = "BD_Stores"
        VarOpenlookup = 19000000
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles ButtonEdit2.EditValueChanged

    End Sub

    Private Sub SimpleButton22_Click(sender As Object, e As EventArgs) Handles SimpleButton22.Click
        If Len(txt_BranchName.Text) = 0 Then MsgBox("من فضلك ادخل الفرع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CashName.Text) = 0 Then MsgBox("من فضلك ادخل اسم الخزينه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(ButtonEdit1.Text) = 0 Then MsgBox("من فضلك ادخل الحساب النقدى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(ButtonEdit4.Text) = 0 Then MsgBox("من فضلك ادخل الحساب بالفيزا  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(ButtonEdit2.Text) = 0 Then MsgBox("من فضلك ادخل المخزن  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_accCode.Text) = 0 Then MsgBox("من فضلك ادخل حساب المبيعات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_disAccCode.Text) = 0 Then MsgBox("من فضلك ادخل حساب الخصومات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "Delete bd_pos_setting  WHERE branch_Code = '" & txt_BranchCode.Text & "'  "
        rs = Cnn.Execute(sql)


        sql = "INSERT INTO BD_POS_Setting (branch_Code, wallet_Code, cash_Account, visa_Account, store_Code,company_code,sale_AccCode,disc_AccCode,inv_serial) " & _
            " values  ('" & txt_BranchCode.Text & "' ,'" & txt_CashCode.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & storeCode & "', '" & VarCodeCompny & "','" & txt_accCode.Text & "', '" & txt_disAccCode.Text & "', '" & txt_invSerial.Text & "')"
        Cnn.Execute(sql)


        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        FindBranchSetting()
    End Sub

    Private Sub txt_CashName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CashName.EditValueChanged

    End Sub

    Private Sub SimpleButton21_Click(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        sql = "Delete bd_pos_setting  WHERE branch_Code = '" & txt_BranchCode.Text & "' and wallet_Code = '" & txt_CashCode.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        FindBranchSetting()
    End Sub

   
    Private Sub GridControl4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub txt_BranchName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_BranchName.EditValueChanged

    End Sub

    Private Sub GridControl6_Click(sender As Object, e As EventArgs) Handles GridControl6.Click

    End Sub

    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs) Handles GridControl6.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        txt_BranchName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CashName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        ButtonEdit1.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        ButtonEdit4.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        ButtonEdit2.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_accName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_discAccName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))

        find_BranchData()
    End Sub

    Private Sub ButtonEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles ButtonEdit4.EditValueChanged

    End Sub

    Private Sub txt_accName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_accName.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 200020
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_accName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_accName.EditValueChanged

    End Sub

    Private Sub txt_discAccName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_discAccName.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 200021
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_discAccName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_discAccName.EditValueChanged
        
    End Sub

    Private Sub SimpleButton23_Click(sender As Object, e As EventArgs) Handles SimpleButton23.Click
        varcode_form = 404
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub LabelX34_Click(sender As Object, e As EventArgs) Handles LabelX34.Click

    End Sub

   

    Private Sub txt_AccountNoStore_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNoStore.TextChanged

    End Sub

    Private Sub txt_AccountNameStore_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNameStore.TextChanged

    End Sub

    Private Sub LabelX33_Click(sender As Object, e As EventArgs) Handles LabelX33.Click

    End Sub

    Private Sub txt_AccountCostStore_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountCostStore.TextChanged

    End Sub

    Private Sub txt_AccountNameCostStore_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNameCostStore.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txt_CodeStores.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txt_NameStores.TextChanged

    End Sub

    Private Sub LabelX22_Click(sender As Object, e As EventArgs) Handles LabelX22.Click

    End Sub

    Private Sub cmd_LookupStores_Click(sender As Object, e As EventArgs) Handles cmd_LookupStores.Click
        varcode_form = 0
        VARTBNAME2 = ""
        VARTBNAME2 = "BD_Stores"
        varcode_form = 770
        Frm_LookUpAccount.Fill_Stores()
        Frm_LookUpAccount.ShowDialog()
    End Sub
End Class