Imports System.Data.OleDb

Public Class Frm_Invintory_FirstItem
    Dim valueG1, valueG2 As String
    Dim varExserail As String
    Dim varcodunit, varclick As Integer
    Dim varAccountNo_Invintory, varAccountNo_CostInvintory, varNameUnit As String

    Private Sub Frm_Invintory_FirstItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Group()
        find_allData()
    End Sub
    Sub find_allData()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = " SELECT dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, RTRIM(dbo.BD_Stores.Name) AS NameStores " & _
 " FROM     dbo.Hedar_FirstStoresItem INNER JOIN " & _
 "                  dbo.BD_Stores ON dbo.Hedar_FirstStoresItem.Code_Stores = dbo.BD_Stores.Code " & _
 "        WHERE(dbo.Hedar_FirstStoresItem.Compny_Code = 1) "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl4.DataSource = ds.Tables(0)


        GridView7.Columns(0).Caption = "رقم الاذن"
        GridView7.Columns(1).Caption = "التاريخ"
        GridView7.Columns(2).Caption = "المخزن"


        GridView7.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView7.Appearance.Row.Options.UseFont = True

        GridView7.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub
    Sub Find_Group()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = " SELECT Name FROM     dbo.BD_GROUPITEMMAIN "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        Dim ds As New DataSet()

        da.Fill(ds)

        GridControl3.DataSource = ds.Tables(0)


        GridView4.Columns(0).Caption = "أسم الصنف"


        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True

        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

   

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        valueG2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Search()

        If varclick = 1 Then
            add_col()
        Else
            add_col()
            'add_col2()
        End If
    End Sub
    Sub add_col()
        Dim cmb As New DataGridViewComboBoxColumn()

        cmb.HeaderText = "الوحدة"
        cmb.Name = "cmb"
        cmb.MaxDropDownItems = 2


        sql = "SELECT Name FROM     dbo.BD_Unit"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            cmb.Items.Add(rs("Name").Value)
            varclick = 1

            rs.MoveNext()
        Loop

        DataGridView2.Columns.Add(cmb)


        'DataGridView2.Columns.Remove(cmb)
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        valueG1 = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "     Select G1_Item     FROM dbo.VW_FINDDATAITEM2 WHERE  (MG_Item = '" & valueG1 & "') GROUP BY G1_Item   HAVING(G1_Item Is Not NULL)"

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Columns(0).Caption = "المجموعة 2"
        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.BestFitColumns()
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '====================================================
        valueG2 = ""
        Search()

        If varclick = 1 Then
            add_col()
        Else
            add_col()
            'add_col2()
        End If
    End Sub

    Sub Search()
        On Error Resume Next

        'DataGridView2.

        DataGridView2.DataSource = Nothing
        DataGridView2.Columns.Clear()

        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
        'con.ConnectionString = ss
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        sql = " SELECT        Code,rtrim(EX_Item) as ex_item, rtrim(Name) as name FROM            dbo.VW_FINDDATAITEM2  WHERE    (MG_Item LIKE '%" & valueG1 & "%') AND (G1_Item LIKE '%" & valueG2 & "%')  and    EX_Item like '%" & txt_Ref_Find.Text & "%' and  Name like '%" & txt_Name.Text & "%' and  (Compny_Code = '" & VarCodeCompny & "')  "

        'sql = "SELECT  code,name FROM  BD_ITEM   "
        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)




        DataGridView2.Columns(0).HeaderText = "كود الصنف"
        DataGridView2.Columns(2).HeaderText = "أسم الصنف"
        DataGridView2.Columns(1).HeaderText = "Ref No"

        DataGridView2.Columns(0).Width = "75"
        DataGridView2.Columns(1).Width = "100"
        DataGridView2.Columns(2).Width = "200"


        DataGridView2.Columns(0).Visible = False

        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.BestFitColumns()
        'GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        callNew()
    End Sub
    Sub clear()
        On Error Resume Next
        'Cmd_Save.Enabled = True
        Com_InvoiceNo2.Text = ""
        Com_InvoiceNo.Text = ""
        Cmd_Print.Enabled = True
        Com_InvoiceNo.Enabled = False
        txt_codestores.Text = ""
        txt_Notes.Text = ""
        txt_codestores.Text = ""
        txt_namestores.Text = ""
        txt_Notes.Text = ""
        'ButtonX6.Enabled = True
        'ButtonX3.Enabled = True
        Cmd_save.Enabled = True

    End Sub
    Sub last_Data()
        Dim varseril As Integer
        '============================================بضاعة اول المدة
        sql = "SELECT ExSerail_FirstStores, NoSerail_FirstStores     FROM TB_SerailAcc where Compny_Code ='" & VarCodeCompny & "'"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varseril = rs2("NoSerail_FirstStores").Value : varExserail = Trim(rs2("ExSerail_FirstStores").Value)


        Dim x As String
        x = varExserail
        sql = "SELECT MAX(NumberBill) AS MaxmamNo, Code_Sub,Flag_status FROM     Hedar_FirstStoresItem where Compny_Code ='" & VarCodeCompny & "'  GROUP BY Code_Sub,Flag_status HAVING  Flag_status ='" & varflagstatus & "'  and Code_Sub = '" & varCodeBranch & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxmamNo").Value + 1
            Com_InvoiceNo2.Text = Val(Com_InvoiceNo.Text) + Val(varseril)
            Com_InvoiceNo2.Text = x + "" + Com_InvoiceNo2.Text
        Else
            Com_InvoiceNo.Text = 1

            Com_InvoiceNo2.Text = 1 + varseril
            x = varExserail + Com_InvoiceNo2.Text
            Com_InvoiceNo2.Text = x
            'clear()

        End If
        find_gridItem()
    End Sub
    Sub callNew()
        clear()
        last_Data()
        'varflagstatus = 0
        'find_gridItem()


        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        ButtonX1.Enabled = True

        Cmd_Delete.Enabled = False
        Cmd_save.Enabled = True
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        varcode_form = 0
        VARTBNAME2 = ""
        VARTBNAME2 = "BD_Stores"
        varcode_form = 77
        Frm_LookUpAccount.Fill_Stores()
        Frm_LookUpAccount.ShowDialog()
        'clear_data()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        On Error Resume Next
        delete_Item()
        '============================Hedar

        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        sql = "select * from Hedar_FirstStoresItem where NumberBill  = " & Com_InvoiceNo.Text & " and Code_Sub ='" & varcode_Branch & "' and Flag_status='" & 0 & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            sql = "INSERT INTO Hedar_FirstStoresItem (NumberBill, Code_Sub,Co_ID,NumYear,DateBill,Sat,Hid,DisHdaer,Code_Stores,Flag_status,Ex_No,Compny_Code) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & varcode_Branch & "','" & 1 & "','" & 1 & "','" & vardateinvoice & "','0','0','" & txt_Notes.Text & "','" & txt_codestores.Text & "','" & varflagstatus & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)


        End If

        '===============================

        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(x).Cells(0).Value = Nothing Then
            Else

                '============================================================ وحدة البيع
                sql = "   SELECT Unit1, Code    FROM BD_ITEM    WHERE(code = '" & DataGridView1.Rows(x).Cells(0).Value & "') and Compny_Code ='" & VarCodeCompny & "'"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcodunit = rs("Unit1").Value : varcodeitem = rs("code").Value

                '========================الاذن
                sql = "INSERT INTO Detalis_FirstStoreItem (NumberBill,Code_Sub,Co_ID,NumYear,NoItem,CodeUnit,Ex_NumberBill,FlagAzn,Compny_Code,Quntity,Price,Total_Item) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & varcode_Branch & "','" & 1 & "','" & 1 & "','" & DataGridView1.Rows(x).Cells(0).Value & "','" & varcodunit & "','" & Com_InvoiceNo2.Text & "','" & 0 & "','" & VarCodeCompny & "','" & DataGridView1.Rows(x).Cells(4).Value & "','" & DataGridView1.Rows(x).Cells(5).Value & "','" & DataGridView1.Rows(x).Cells(6).Value & "')"
                Cnn.Execute(sql)

               
                '====================================حركة الصنف
                sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
               " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,TypeItem,Ex_No,FlagAzn,Compny_Code,Price_Unit) " & _
               " values ('" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & " ' " & _
               " ,'" & DataGridView1.Rows(x).Cells(0).Value & " ', '" & varcodunit & "','" & txt_codestores.Text & "','" & 0 & "' " & _
               " ,'" & vardateinvoice & "','" & "بضاعة اول المدة" + Com_InvoiceNo.Text & "', '" & DataGridView1.Rows(x).Cells(4).Value & "','" & varcode_Branch & "','" & vartypeItem & "','" & Com_InvoiceNo2.Text & "','" & 0 & "','" & VarCodeCompny & "','" & DataGridView1.Rows(x).Cells(5).Value & "' ) "
                Cnn.Execute(sql)
            End If
        Next x
        Sum_Total()
        'Save_GL()
        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, " Solution Software Module")
        Fill_INVOICE2()
        find_allData()
        Sum_Total()
    End Sub
    Sub FillAccountNo_Setting()
        sql2 = "SELECT AccountNoGroup, AccountNoGroup2 FROM     dbo.TB_SettingGroup1 WHERE  (Code_Stores = '" & txt_codestores.Text & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then varAccountNo_Invintory = rs2("AccountNoGroup").Value : varAccountNo_CostInvintory = rs2("AccountNoGroup2").Value
    End Sub
    Sub lastgl()

        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM  dbo.Genralledger where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(IDGenral) Is Not Null) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub
    Sub Save_GL()
        sql = "UPDATE  Genralledger  SET flgcancle = '" & 1 & "',flg = '" & 0 & "' ,UserID= '" & varcode_User & "' WHERE No_Sand = '" & Com_InvoiceNo.Text & "'  and Typebill ='" & 0 & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)



        sql = "Delete MovmentStatement  WHERE TypeBill ='" & 0 & "' and No_Sand = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        If txt_SumTotal.Text = 0 Then Exit Sub

        FillAccountNo_Setting()
        lastgl()
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '=======================================================المدين  
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varNoGL & "' ,'" & vardateinvoice & "','" & varAccountNo_Invintory & "','" & "بضاعة اول المدة" + Com_InvoiceNo.Text & "','" & txt_SumTotal.Text & "' ,'" & 0 & "','" & 0 & "','" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & "' ,'" & 1 & "','" & txt_SumTotal.Text & "' ,'" & 0 & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardateinvoice & "',N'" & varAccountNo_Invintory & "'  ,N'" & "بضاعة اول المدة " + Com_InvoiceNo.Text & "',N'" & txt_SumTotal.Text & "',N'" & 0 & "',N'" & "0" & "',N'" & Com_InvoiceNo.Text & "','" & 1 & "' ,'" & 1 & "' ,'" & txt_SumTotal.Text & "','" & 0 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)




        '=======================================================المدين  
        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,No_serail,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,flg,UserID) " & _
        " values  ('" & varNoGL & "' ,'" & vardateinvoice & "','" & varAccountNo_CostInvintory & "','" & "بضاعة اول المدة" + Com_InvoiceNo.Text & "','" & 0 & "' ,'" & txt_SumTotal.Text & "','" & 0 & "','" & Com_InvoiceNo.Text & "','" & 1 & "','" & 1 & "' ,'" & 1 & "','" & 0 & "' ,'" & txt_SumTotal.Text & "','" & VarCodeCompny & "','" & 1 & "','" & varcode_User & "')"
        Cnn.Execute(sql)

        '================================================================
        sql = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,No_Sand,Code_Sub,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code) " & _
        " values  (N'" & Com_InvoiceNo.Text & "' ,N'" & vardateinvoice & "',N'" & varAccountNo_CostInvintory & "'  ,N'" & "بضاعة اول المدة " + Com_InvoiceNo.Text & "',N'" & 0 & "',N'" & txt_SumTotal.Text & "',N'" & "0" & "',N'" & Com_InvoiceNo.Text & "','" & 1 & "' ,'" & 1 & "' ,'" & 0 & "','" & txt_SumTotal.Text & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)
    End Sub
    Sub Delete_GL()
        sql = "Delete MovmentStatement  WHERE TypeBill ='" & 0 & "' and No_Sand = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        sql = "Delete Genralledger  WHERE TypeBill ='" & 0 & "' and No_Sand = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

    End Sub
    Sub Sum_Total()
        'sql = "  SELECT NumberBill, SUM(Total_Item) AS SumTotal      FROM dbo.Detalis_FirstStoreItem GROUP BY NumberBill   HAVING(NumberBill = '" & Com_InvoiceNo.Text & "')"
        sql = "  SELECT NumberBill, SUM(Total_Item) AS Total2      FROM dbo.Detalis_FirstStoreItem GROUP BY NumberBill  HAVING(NumberBill = '" & Com_InvoiceNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_SumTotal.Text = rs("Total2").Value Else txt_SumTotal.Text = "0"
        '===================================
        sql2 = " SELECT NumberBill, COUNT(NoItem) AS CountItem       FROM dbo.Detalis_FirstStoreItem GROUP BY NumberBill HAVING(NumberBill = '" & Com_InvoiceNo.Text & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then txt_Count.Text = rs("CountItem").Value Else txt_Count.Text = "0"
        '==================================


    End Sub
    Sub delete_Item()
        sql = "Delete Detalis_FirstStoreItem  where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '===================================حذف من المخزن
        sql = "Delete Hedar_FirstStoresItem   where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        sql = "Delete Statement_OfItem  WHERE  (TypeD = '" & 0 & "') AND (NumberBill = '" & Com_InvoiceNo.Text & "')   "
        rs = Cnn.Execute(sql)
        'MsgBox("تم حذف الاذن", MsgBoxStyle.Information, "Css Solution Software Module")
    End Sub

    Sub save_data()
        On Error Resume Next

        Dim varinvoicesss As Integer
        If Com_InvoiceNo.Text = "" Then varinvoicesss = 0 Else varinvoicesss = Com_InvoiceNo.Text
        sql2 = "select * from Hedar_FirstStoresItem where NumberBill  = '" & Trim(varinvoicesss) & "' and Flag_status =  '" & 0 & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()
        End If



        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_codestores.Text) = 0 Then MsgBox("من ادخل المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_invoice_H()
        Fill_INVOICE2()

    End Sub
    Sub Fill_INVOICE2()
        On Error Resume Next

        sql = "  SELECT        TOP (100) PERCENT dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, dbo.Hedar_FirstStoresItem.DisHdaer, dbo.Hedar_FirstStoresItem.Code_Stores, " & _
"                        dbo.Hedar_FirstStoresItem.Code_Sub, dbo.Hedar_FirstStoresItem.Code_Stores2, dbo.Hedar_FirstStoresItem.FlagAzn, dbo.Hedar_FirstStoresItem.Ex_No, dbo.Hedar_FirstStoresItem.Status_AznSarf,  " & _
"                        dbo.Hedar_FirstStoresItem.AccountNo_Customer, dbo.BD_Stores.Name AS NameStores, BD_Stores_1.Name AS NameStores2, dbo.BD_SUBMAIN.Name AS Namesub,  " & _
"           dbo.Hedar_FirstStoresItem.Compny_Code " & _
" FROM            dbo.Hedar_FirstStoresItem LEFT OUTER JOIN " & _
"                         dbo.BD_Stores ON dbo.Hedar_FirstStoresItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Hedar_FirstStoresItem.Compny_Code = dbo.BD_Stores.Compny_Code LEFT OUTER JOIN " & _
"                         dbo.BD_Stores AS BD_Stores_1 ON dbo.Hedar_FirstStoresItem.Compny_Code = BD_Stores_1.Compny_Code AND dbo.Hedar_FirstStoresItem.Code_Stores2 = BD_Stores_1.Code LEFT OUTER JOIN " & _
"                         dbo.BD_SUBMAIN ON dbo.Hedar_FirstStoresItem.Compny_Code = dbo.BD_SUBMAIN.Compny_Code AND dbo.Hedar_FirstStoresItem.Code_Sub = dbo.BD_SUBMAIN.Code " & _
" WHERE      (dbo.Hedar_FirstStoresItem.Compny_Code = '" & VarCodeCompny & "') " & _
" GROUP BY dbo.Hedar_FirstStoresItem.NumberBill, dbo.Hedar_FirstStoresItem.DateBill, dbo.Hedar_FirstStoresItem.DisHdaer, dbo.Hedar_FirstStoresItem.Code_Stores, dbo.Hedar_FirstStoresItem.Code_Sub,  " & _
"            dbo.Hedar_FirstStoresItem.Code_Stores2, dbo.Hedar_FirstStoresItem.FlagAzn, dbo.Hedar_FirstStoresItem.Ex_No, dbo.Hedar_FirstStoresItem.Status_AznSarf, dbo.Hedar_FirstStoresItem.AccountNo_Customer, " & _
"            dbo.BD_Stores.Name, BD_Stores_1.Name, dbo.BD_SUBMAIN.Name, dbo.Hedar_FirstStoresItem.Compny_Code  HAVING(Hedar_FirstStoresItem.NumberBill = '" & Com_InvoiceNo.Text & "')" & _
" ORDER BY dbo.Hedar_FirstStoresItem.NumberBill "



        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then

            '=====================================================Hedares
            txt_date.Value = rs3("DateBill").Value
            txt_codestores.Text = rs3("Code_Stores").Value
            txt_namestores.Text = rs3("NameStores").Value
            Com_InvoiceNo2.Text = rs3("Ex_No").Value
            txt_Notes.Text = rs3("DisHdaer").Value


        End If
        find_gridItem()
        'Total_Qty1()
    End Sub

    Sub find_gridItem()
        'On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        Dim VARCODE_AZN As Integer
        If Com_InvoiceNo.Text = "" Then VARCODE_AZN = 0 Else VARCODE_AZN = Com_InvoiceNo.Text




        sql2 = "  SELECT dbo.Detalis_FirstStoreItem.NoItem, RTRIM(dbo.BD_Item.Ex_Item) AS ExItem, RTRIM(dbo.BD_Item.Name) AS NameItem, dbo.BD_Unit.Name AS Unit, dbo.Detalis_FirstStoreItem.Quntity, dbo.Detalis_FirstStoreItem.Price, " & _
"                  dbo.Detalis_FirstStoreItem.Total_Item " & _
" FROM     dbo.Detalis_FirstStoreItem LEFT OUTER JOIN " & _
"                  dbo.BD_Item ON dbo.Detalis_FirstStoreItem.NoItem = dbo.BD_Item.Code LEFT OUTER JOIN " & _
"                  dbo.BD_Unit ON dbo.Detalis_FirstStoreItem.CodeUnit = dbo.BD_Unit.Code " & _
"        WHERE(dbo.Detalis_FirstStoreItem.NumberBill = '" & VARCODE_AZN & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)



        DataGridView1.Columns(0).HeaderText = "كود الصنف"
        DataGridView1.Columns(1).HeaderText = "Ref NO"
        DataGridView1.Columns(2).HeaderText = "الصنف"
        DataGridView1.Columns(3).HeaderText = "الوحدة"
        DataGridView1.Columns(4).HeaderText = "الكمية"
        DataGridView1.Columns(5).HeaderText = "سعر الوحدة"
        DataGridView1.Columns(6).HeaderText = "الاجمالى"

        DataGridView1.Columns(2).Width = "250"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()
        Sum_Total()

    End Sub
    Sub save_invoice_H()
        'On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")

        sql = "select * from Hedar_FirstStoresItem where NumberBill  = " & Com_InvoiceNo.Text & " and Code_Sub ='" & varcode_Branch & "' and Flag_status='" & 0 & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            sql = "INSERT INTO Hedar_FirstStoresItem (NumberBill, Code_Sub,Co_ID,NumYear,DateBill,Sat,Hid,DisHdaer,Code_Stores,Flag_status,Ex_No,Compny_Code) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & varcode_Branch & "','" & 1 & "','" & 1 & "','" & vardateinvoice & "','0','0','" & txt_Notes.Text & "','" & txt_codestores.Text & "','" & varflagstatus & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)


        End If
        'Next
        save_invoice_D()

    End Sub
    Sub save_invoice_D()
        'On Error Resume Next
  

        '============================================================ وحدة البيع
        sql = "   SELECT Unit1, Code    FROM BD_ITEM    WHERE(code = '" & varcode_item & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = rs("code").Value
        '=====================================================الوحدة
        'varcodunit = rs("Unit1").Value :
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & varNameUnit & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value
        '================================================رقم المسلسل


        sql = "INSERT INTO Detalis_FirstStoreItem (NumberBill,Code_Sub,Co_ID,NumYear,NoItem,CodeUnit,Ex_NumberBill,FlagAzn,Compny_Code) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & varcode_Branch & "','" & 1 & "','" & 1 & "','" & varcodeitem & "','" & varcodunit & "','" & Com_InvoiceNo2.Text & "','" & 0 & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)



        '====================================================
        'MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "basicwork  Solution Software Module")
    End Sub


    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView7.FocusedRowHandle
        Com_InvoiceNo.Text = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(0))
        Fill_INVOICE2()
        TabPane1.SelectedPageIndex = 0
    End Sub

   

    Private Sub DataGridView1_CellStyleChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellStyleChanged
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        On Error Resume Next
        Dim ro, mt As Integer

        ro = DataGridView1.CurrentRow.Index
        mt = ro
        DataGridView1.Item(6, mt).Value = Val(DataGridView1.Item(4, mt).Value) * Val(DataGridView1.Item(5, mt).Value)

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Dim ro, mt As Integer

        ro = DataGridView1.CurrentRow.Index
        mt = ro
        varcodeitem = DataGridView1.Item(0, mt).Value
        Cmd_Delete.Enabled = True
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        'sql = "Delete Detalis_FirstStoreItem  WHERE NoItem = '" & varcodeitem & "'   and Compny_Code='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)

        'sql = "Delete Statement_OfItem  WHERE NoItem = '" & varcodeitem & "' and  (TypeD = 0) AND (NumberBill = '" & Com_InvoiceNo.Text & "')  and Compny_Code='" & VarCodeCompny & "'     "
        'rs = Cnn.Execute(sql)

        'Fill_INVOICE2()
        'MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
    End Sub

   
    Private Sub cmd_DeleteAll_Click(sender As Object, e As EventArgs) Handles cmd_DeleteAll.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        If Com_InvoiceNo.Text.Trim = "" Then Exit Sub

        x = MsgBox("هل تريد حذف الاذن", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Detalis_FirstStoreItem  where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '===================================حذف من المخزن
                sql = "Delete Hedar_FirstStoresItem   where NumberBill = '" & Com_InvoiceNo.Text & "'  and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)


                sql = "Delete Statement_OfItem  WHERE  (TypeD = '" & 0 & "') AND (NumberBill = '" & Com_InvoiceNo.Text & "')   "
                rs = Cnn.Execute(sql)

                Delete_GL()
                MsgBox("تم حذف الاذن", MsgBoxStyle.Information, "Css Solution Software Module")

        End Select
        find_gridItem()
        find_allData()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Dim report As New DevReport_FristItem
        report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        report.FilterString = "[NumberBill] Like '%" & Com_InvoiceNo.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
        TabPane1.SelectedPageIndex = 2
        'DevReport_FristItem
    End Sub

   

    Private Sub Com_GL_Click(sender As Object, e As EventArgs)

    End Sub

  

   
    Private Sub Cmd_OpenGL_Click(sender As Object, e As EventArgs) Handles Cmd_OpenGL.Click
        Com_GL.Text = ""
        Com_GL.Items.Clear()
        sql = " Select IDGenral      FROM dbo.Genralledger GROUP BY IDGenral, Code_Sub, Typebill, No_Sand, flgcancle HAVING (Typebill = 0) AND (Code_Sub = '" & varcode_Branch & "') AND (No_Sand = '" & Com_InvoiceNo.Text & "') and flgcancle = '" & 0 & "'  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_GL.Items.Add(rs("IDGenral").Value)
            rs.MoveNext()
        Loop
    End Sub

  
    Private Sub Com_GL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_GL.SelectedIndexChanged
        Frm_Gl4.Com_GL_No.Text = Com_GL.Text
        'varcodegl = Com_InvoiceNo.Text
        statusopen = 1
        Frm_Gl4.find_hedar()
        Frm_Gl4.find_detalis()
        Frm_Gl4.Total_Sum()
        Frm_Gl4.MdiParent = Mainmune
        Frm_Gl4.Show()
    End Sub

    

    

    Private Sub txt_Ref_Find_TextChanged(sender As Object, e As EventArgs) Handles txt_Ref_Find.TextChanged
        Search()
        add_col()
    End Sub

    Private Sub Cmd_FindRefNo_Click(sender As Object, e As EventArgs)
     
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro

        If DataGridView2.Item(3, mt).Value = "" Then MsgBox("من فضلك ادخل الوحدة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub


        ro = DataGridView2.CurrentRow.Index
        mt = ro
        varcode_item = DataGridView2.Item(0, mt).Value
        varNameUnit = DataGridView2.Item(3, mt).Value



        save_data()
        Fill_INVOICE2()
        find_allData()
    End Sub

    Private Sub Cmd_FindRefNo_Click_1(sender As Object, e As EventArgs) Handles Cmd_FindRefNo.Click
        Search()
        add_col()
    End Sub

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged
        Search()
        add_col()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub
End Class