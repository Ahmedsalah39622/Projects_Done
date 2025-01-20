Imports System.Data.OleDb
Public Class Frm_Azn_AddItem

    Public varAmineCode, varItemCode As Integer
    Dim valueG1, valueG2 As String
    Dim varExserail As String
    Dim varcodunit, varclick As Integer
    Dim varAccountNo_Invintory, varAccountNo_CostInvintory, varNameUnit As String


    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = True
    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs)
        'If Op1.Checked = True Or Op2.Checked = True Then
        '    cmd_FindItem.Enabled = True
        'Else
        '    cmd_FindItem.Enabled = False
        'End If
    End Sub

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Frm_Azn_AddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 1 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 0 'الصفحة التالية


    End Sub
    Sub fill_Unit()
        'Txt_UnitItem2.Items.Clear()
        'sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    Txt_UnitItem2.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop
    End Sub
    Private Sub Frm_Azn_AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Com_TypeItem.Items.Add("منتج تصنيع")
        'Com_TypeItem.Items.Add("منتج أمر شراء")
        'Com_TypeItem.Items.Add(" بيعمرتجع")
        'Cmd_New_Click_1(Nothing, Nothing)
        Find_Group()
        Search()
        fill_Stores()
        fill_Type_Stores()
        fill_Unit()
        'txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")

        'last_Data()
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

    Sub fill_Type_Stores()
        Com_TypeItem.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_TypeSarfStores  where Compny_Code ='" & VarCodeCompny & "' and flag=1 "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_TypeItem.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Stores()
        Com_StoresNo.Items.Clear()

        sql = " SELECT Name FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_StoresNo.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub clear_detils()
        'txt_MachinName.Text = ""
        'Com_NameItem.Text = ""
        Com_TypeItem.SelectedIndex = -1
        txt_AminStores.Text = ""
        'txt_QytItem2.Text = ""
        'Txt_UnitItem2.SelectedIndex = -1
        Com_StoresNo.SelectedIndex = -1
        txt_Qyt_avalible.Text = ""
        Txt_Notes.Text = ""
        txt_CodeProject.Text = ""
        txt_NameProject.Text = ""
        txt_CodeSuppliser.Text = ""
        txt_NameSuppliser.Text = ""
        cmd_update.Enabled = False
        cmd_DeleteLine.Enabled = False
        Cmd_Delete.Enabled = True
        Cmd_save.Enabled = True
        'GridControl4.DataSource = Nothing
    End Sub


    Sub find_hedar()
        On Error Resume Next

        sql = "  SELECT dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AS Code, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.NO_FahsEstlamOrder, dbo.Vw_Emp.Emp_Name, dbo.TB_Header_AznAddItem.FlagItemType, " & _
  "                  dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Header_AznAddItem.Notes, dbo.TB_Header_AznAddItem.Code_Project, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.TB_Header_AznAddItem.Code_Customer, " & _
  "                  dbo.ST_CHARTOFACCOUNT.AccountName AS SupliserName " & _
  " FROM     dbo.TB_Header_AznAddItem INNER JOIN " & _
  "                  dbo.Vw_Emp ON dbo.TB_Header_AznAddItem.Code_AminStores = dbo.Vw_Emp.Emp_Code LEFT OUTER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_AznAddItem.Code_Customer = dbo.ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN " & _
  "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Header_AznAddItem.Code_Project = dbo.ST_CHARTCOSTCENTER.Account_No " & _
  " WHERE  (dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Header_AznAddItem.Compny_Code = '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = Trim(rs("Code").Value)
            txt_date.Text = Trim(rs("Date_StoresAdd").Value)

            txt_AminStores.Text = Trim(rs("Emp_Name").Value)
            Com_TypeItem.Text = Trim(rs("TypeAdd").Value)
            Txt_Notes.Text = Trim(rs("Notes").Value)
            txt_CodeProject.Text = Trim(rs("Code_Project").Value)
            txt_NameProject.Text = Trim(rs("AccountName").Value)

            txt_CodeSuppliser.Text = Trim(rs("Code_Customer").Value)
            txt_NameSuppliser.Text = Trim(rs("SupliserName").Value)

            'If rs("FlagItemType").Value = 1 Then Op1.Checked = True
            'If rs("FlagItemType").Value = 2 Then Op2.Checked = True

        End If
    End Sub
    Sub save_Order_H()
        'On Error Resume Next
        Dim varcodeamin As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateorder As String
        vardateorder = dd.ToString("MM-d-yyyy")

        'If Op1.Checked = True Then varflagtype = 1
        'If Op2.Checked = True Then varflagtype = 2
        'If Op3.Checked = True Then varflagtype = 3


        sql = "select * from TB_Header_AznAddItem where Ser_NO_StoresAdd  = " & Com_InvoiceNo2.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then


        Else


            sql = "SELECT        Emp_Code, Emp_Name          FROM dbo.Vw_Emp WHERE        (Emp_Name = '" & txt_AminStores.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeamin = rs("Emp_Code").Value

            ' FlagItemType, '" & varflagtype & "', =====> دى مش عارف هى خاصه بايه عشان اعملها insert مظبوط
            sql2 = "INSERT INTO TB_Header_AznAddItem (Ser_NO_StoresAdd, Compny_Code,Date_StoresAdd,Code_AminStores,TypeAdd,Notes,Code_Project,Code_Customer) " & _
                      " values  ('" & Com_InvoiceNo2.Text & "' ,'" & VarCodeCompny & "','" & vardateorder & "','" & varcodeamin & "','" & Com_TypeItem.Text & "','" & Txt_Notes.Text & "','" & txt_CodeProject.Text & "','" & txt_CodeSuppliser.Text & "')"
            Cnn.Execute(sql2)

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','20','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        End If
        'Next

        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_StoresNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value

        '============================================================ وحدة البيع
        sql = "   SELECT *    FROM BD_Unit    WHERE(name = '" & varNameUnit & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value

        '========================اضافة الاذن
        sql = "INSERT INTO TB_Detils_AznAddItem (Ser_NO_StoresAdd,No_item,Qyt,Code_Unit,Compny_Code,Code_Stores) " & _
             " values  ('" & Com_InvoiceNo2.Text & "' ,'" & varcode_item & "','" & 0 & "','" & varcodunit & "','" & VarCodeCompny & "','" & varcodestores & "')"
        Cnn.Execute(sql)

    End Sub
    Sub save_oderDetils()
        'Dim varcode_Item, varcodunit2 As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateorder As String
        vardateorder = dd.ToString("MM-d-yyyy")
     
        ''===============================stores\
        sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_StoresNo.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodestores = rs("Code").Value


        ''sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & Com_TypeItem.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        ''rs = Cnn.Execute(sql)
        ''If rs.EOF = False Then varcode_TypeStores = rs("code").Value
        'تعديل
        sql = "UPDATE  TB_Header_AznAddItem  SET TypeAdd ='" & Com_TypeItem.Text & "', Code_Customer ='" & txt_CodeSuppliser.Text & "', Code_Project ='" & txt_CodeProject.Text & "', Notes = '" & Txt_Notes.Text & "'  WHERE   Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(x).Cells(0).Value = Nothing Then
            Else

                '============================================================ وحدة البيع
                sql = "   SELECT *    FROM BD_Unit    WHERE(name = '" & Trim(DataGridView1.Rows(x).Cells(4).Value) & "') and Compny_Code ='" & VarCodeCompny & "'"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcodunit = rs("code").Value

                '========================الاذن
                sql = "INSERT INTO TB_Detils_AznAddItem (Ser_NO_StoresAdd,No_item,Qyt,Code_Unit,Compny_Code,Code_Stores) " & _
                     " values  (N'" & Com_InvoiceNo2.Text & "' ,N'" & Trim(DataGridView1.Rows(x).Cells(0).Value) & "',N'" & DataGridView1.Rows(x).Cells(3).Value & "',N'" & varcodunit & "',N'" & VarCodeCompny & "',N'" & varcodestores & "')"
                Cnn.Execute(sql)


                '====================================حركة الصنف
                sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
                    " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,Compny_Code,Order_AddStores_NO,Count_exp,Count_imp,Code_Unit2) " & _
                    " values (N'" & Com_InvoiceNo2.Text & "',N'" & 1 & "',N'" & 1 & " ' " & _
                    " ,N'" & Trim(DataGridView1.Rows(x).Cells(0).Value) & " ', N'" & varcodunit & "',N'" & varcodestores & "',N'" & 20 & "' " & _
                    " ,N'" & vardateorder & "',N'" & "أذن اضافة الى المخزن" + Com_InvoiceNo2.Text & "',N'" & DataGridView1.Rows(x).Cells(3).Value & "',N'" & 1 & "',N'" & VarCodeCompny & "',N'" & Com_InvoiceNo2.Text & "',N'" & DataGridView1.Rows(x).Cells(3).Value & "',N'" & 0 & "',N'" & varcodunit & "') "
                Cnn.Execute(sql)
            End If
        Next x

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(Ser_NO_StoresAdd) AS MaxMaim,Compny_Code FROM            TB_Header_AznAddItem    GROUP BY Compny_Code  HAVING        (MAX(Ser_NO_StoresAdd) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = rs("MaxMaim").Value + 1


        Else
            Com_InvoiceNo2.Text = 1



        End If
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")

    End Sub
    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "SELECT       dbo.TB_Detils_AznAddItem.No_item, RTRIM(dbo.BD_Item.Ex_Item) AS Ex_Item, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS UnitName, dbo.BD_Stores.Name AS NameStores,    RTRIM(dbo.TB_Detils_AznAddItem.No_Invoice) AS Inv_No " & _
" FROM            dbo.BD_Unit AS BD_Unit_1 INNER JOIN" & _
             "            dbo.TB_Header_JOB_Order ON BD_Unit_1.Code = dbo.TB_Header_JOB_Order.Code_Unit_FirstItem2 AND BD_Unit_1.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code RIGHT OUTER JOIN" & _
              "           dbo.TB_Detils_AznAddItem INNER JOIN" & _
               "          dbo.BD_Item ON dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code INNER JOIN" & _
                "         dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN" & _
                 "        dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code ON " & _
                  "       dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Detils_AznAddItem.Compny_Code AND dbo.TB_Header_JOB_Order.JOB_Order = dbo.TB_Detils_AznAddItem.No_JopOrder AND " & _
                   "      dbo.TB_Header_JOB_Order.Item_No = dbo.TB_Detils_AznAddItem.No_item " & _
        " WHERE        (dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_AznAddItem.Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)



        DataGridView1.Columns(0).HeaderText = "كود الصنف"
        DataGridView1.Columns(1).HeaderText = "Ref NO"
        DataGridView1.Columns(2).HeaderText = "الصنف"
        DataGridView1.Columns(3).HeaderText = "الكمية"
        DataGridView1.Columns(4).HeaderText = "الوحدة"
        DataGridView1.Columns(5).HeaderText = "اسم المخزن"
        DataGridView1.Columns(6).HeaderText = "رقم الفاتورة"


        DataGridView1.Columns(0).Width = "75"
        DataGridView1.Columns(1).Width = "100"
        DataGridView1.Columns(2).Width = "250"
        DataGridView1.Columns(3).Width = "75"
        DataGridView1.Columns(4).Width = "75"
        DataGridView1.Columns(5).Width = "200"
        DataGridView1.Columns(6).Width = "75"

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()
        Sum_Total()


    End Sub
    Sub Sum_Total()
        sql = "  SELECT Ser_NO_StoresAdd, SUM(Qyt) AS SumTotal      FROM dbo.TB_Detils_AznAddItem GROUP BY Ser_NO_StoresAdd   HAVING(Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_SumTotal.Text = rs("sumTotal").Value Else txt_SumTotal.Text = "0"
        '===================================
        sql2 = " SELECT Ser_NO_StoresAdd, COUNT(No_item) AS CountItem       FROM dbo.TB_Detils_AznAddItem GROUP BY Ser_NO_StoresAdd HAVING(Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "') "
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then txt_Count.Text = rs("CountItem").Value Else txt_Count.Text = "0"
        '==================================


    End Sub

    Sub Search()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        '        sql2 = "   SELECT TOP (100) PERCENT dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Detils_AznAddItem.No_item,rtrim(dbo.BD_Item.Ex_Item) as EX_Item, dbo.BD_Item.Name, " & _
        '"                  dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS Unit, dbo.BD_Stores.Name AS Stores, dbo.ST_CHARTCOSTCENTER.AccountName AS NameProject " & _
        '" FROM     dbo.TB_Detils_AznAddItem INNER JOIN " & _
        '"                  dbo.TB_Header_AznAddItem ON dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AND  " & _
        '"                  dbo.TB_Detils_AznAddItem.Compny_Code = dbo.TB_Header_AznAddItem.Compny_Code INNER JOIN " & _
        '"                  dbo.BD_Item ON dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
        '"                  dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        '"                  dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code LEFT OUTER JOIN " & _
        '"                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Header_AznAddItem.Code_Project = dbo.ST_CHARTCOSTCENTER.Account_No " & _
        '" GROUP BY dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Detils_AznAddItem.No_item,BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Qyt,  " & _
        '"        dbo.BD_Unit.Name, dbo.BD_Stores.Name, dbo.TB_Detils_AznAddItem.Compny_Code, dbo.ST_CHARTCOSTCENTER.AccountName " & _
        '" HAVING (dbo.TB_Detils_AznAddItem.Compny_Code =  '" & VarCodeCompny & "') " & _
        '" ORDER BY dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd "


        sql2 = "   SELECT TOP (100) PERCENT dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Detils_AznAddItem.No_item, RTRIM(dbo.BD_Item.Ex_Item) AS EX_Item, " & _
   "                  dbo.BD_Item.Name, dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name AS Unit, dbo.BD_Stores.Name AS Stores, dbo.ST_CHARTCOSTCENTER.AccountName AS NameProject,  " & _
   "                  dbo.ST_CHARTOFACCOUNT.AccountName AS NameSupliser " & _
   " FROM     dbo.TB_Detils_AznAddItem INNER JOIN " & _
   "                  dbo.TB_Header_AznAddItem ON dbo.TB_Detils_AznAddItem.Ser_NO_StoresAdd = dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd AND  " & _
   "                  dbo.TB_Detils_AznAddItem.Compny_Code = dbo.TB_Header_AznAddItem.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Item ON dbo.TB_Detils_AznAddItem.No_item = dbo.BD_Item.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Unit ON dbo.TB_Detils_AznAddItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Stores ON dbo.TB_Detils_AznAddItem.Code_Stores = dbo.BD_Stores.Code AND dbo.TB_Detils_AznAddItem.Compny_Code = dbo.BD_Stores.Compny_Code LEFT OUTER JOIN " & _
   "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_AznAddItem.Code_Customer = dbo.ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN " & _
   "                  dbo.ST_CHARTCOSTCENTER ON dbo.TB_Header_AznAddItem.Code_Project = dbo.ST_CHARTCOSTCENTER.Account_No " & _
   " GROUP BY dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd, dbo.TB_Header_AznAddItem.TypeAdd, dbo.TB_Detils_AznAddItem.No_item, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name,  " & _
   "        dbo.TB_Detils_AznAddItem.Qyt, dbo.BD_Unit.Name, dbo.BD_Stores.Name, dbo.TB_Detils_AznAddItem.Compny_Code, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTOFACCOUNT.AccountName " & _
   " HAVING (dbo.TB_Detils_AznAddItem.Compny_Code ='" & VarCodeCompny & "') " & _
   " ORDER BY dbo.TB_Header_AznAddItem.Ser_NO_StoresAdd, dbo.TB_Header_AznAddItem.Date_StoresAdd "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن "
        GridView1.Columns(1).Caption = "تاريخ الاذن "
        GridView1.Columns(2).Caption = "نوع الاضافة"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "RefNo"
        GridView1.Columns(5).Caption = "اسم الصنف "
        GridView1.Columns(6).Caption = "الكمية"
        GridView1.Columns(7).Caption = "الوحدة"
        GridView1.Columns(8).Caption = "المخزن"
        GridView1.Columns(9).Caption = "المشروع"
        GridView1.Columns(10).Caption = "المورد"


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Sub save_itemStores()
        'Dim varcodunit, varcodunit2, varcodStores, varcode_Item As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        'sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Txt_UnitItem2.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit = rs("code").Value
        ''===================================================================رقم المخزن
        'sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_StoresNo.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        '============================Item

        'sql = "   SELECT Unit1, code   FROM BD_ITEM    WHERE(Name = '" & Com_NameItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_Item = Trim(rs("code").Value)

        '====================================================وحدة الرول
        'sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Txt_UnitItem2.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit2 = rs("code").Value





        'sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
        '    " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,Compny_Code,Order_AddStores_NO,Count_exp,Count_imp,Code_Unit2) " & _
        '    " values ('" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & " ' " & _
        '    " ,'" & varcode_Item & " ', '" & varcodunit & "','" & varcodStores & "','" & 20 & "' " & _
        '    " ,'" & vardateinvoice & "','" & "أذن اضافة الى المخزن" + Com_InvoiceNo2.Text & "','" & txt_QytItem2.Text & "','" & 1 & "','" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & txt_QytItem2.Text & "','" & 0 & "','" & varcodunit2 & "') "
        'Cnn.Execute(sql)

    End Sub
 
  
   


    Private Sub cmd_FindItem_Click_2(sender As Object, e As EventArgs)
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        Frm_LookupAznEstlam.MdiParent = Mainmune
        Frm_LookupAznEstlam.Show()
    End Sub



    Private Sub txt_MachinName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "TB_MachineName"
        VarOpenlookup = 63
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

   

   
   

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub Com_NameItem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        varcode_form = 25500
        'VARTBNAME = " Vw_AllDataItem"
        'Lookupitem.Fill_Alldata()
        'Lookupitem.ShowDialog()
        Frm_LookupItem.ShowDialog()
    End Sub

    Private Sub txt_AminStores_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        VarOpenlookup3 = 2700
        Frm_LookUpSalse.Find_Salse_amin()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    
   
    

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)
        
    End Sub

  

    

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs)
        On Error Resume Next
        'Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        'varcode_item = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        'varItemCode = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        ''Com_NameItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        ''txt_QytItem2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))
        ''Txt_UnitItem2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(4))
        'Com_StoresNo.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(5))
        'txt_InvoiceNo.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(6))

        ''If Com_NameItem.Text.Length = 0 Then Exit Sub

        cmd_update.Enabled = True
        cmd_DeleteLine.Enabled = True
        Cmd_Delete.Enabled = True
        Cmd_save.Enabled = False

    End Sub


    Private Sub Txt_UnitItem2_GotFocus(sender As Object, e As EventArgs)
        fill_Unit2()
    End Sub
    Sub fill_Unit2()
        'If Com_NameItem.Text = "" Then MsgBox("أختار الصنف من فضلك", MsgBoxStyle.Critical) : Exit Sub
        'sql = "   SELECT *    FROM BD_Item   WHERE(Name = '" & Com_NameItem.Text & "') "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodeitem = rs("Code").Value
        '==================================================

        'Txt_UnitItem2.Items.Clear()

        'sql = " SELECT Name FROM     vw_AllUnit where  code ='" & varcodeitem & "'   "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    Txt_UnitItem2.Items.Add(rs("Name").Value)
        '    rs.MoveNext()
        'Loop
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
    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        valueG2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        Search2()

        'If varclick = 1 Then
        '    add_col()
        'Else
        '    add_col()
        '    'add_col2()
        'End If
    End Sub
    Sub Search2()
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



        If varclick = 1 Then
            add_col()
        Else
            add_col()
            'add_col2()
        End If
    End Sub

    Private Sub txt_Ref_Find_TextChanged(sender As Object, e As EventArgs) Handles txt_Ref_Find.TextChanged
        Search2()
    End Sub

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged
        Search2()
    End Sub

    Private Sub Cmd_FindRefNo_Click(sender As Object, e As EventArgs) Handles Cmd_FindRefNo.Click
        Search2()
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
        GridView6.Columns(0).Caption = "المجموعة 2"
        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True
        GridView6.BestFitColumns()
        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        '====================================================
        valueG2 = ""
        Search2()


        If varclick = 1 Then
            add_col()
        Else
            add_col()
            'add_col2()
        End If
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_hedar()
        find_detalis()
        clear_detils()
    End Sub

    Private Sub Cmd_OpenJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click
        vartable = "vw_Lookup_AznAddItem"
        VarOpenlookup = 62
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub txt_AminStores_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AminStores.ButtonClick
        VarOpenlookup2 = 600
        Frm_LookupUser.ShowDialog()
    End Sub

    Private Sub txt_AminStores_EditValueChanged_2(sender As Object, e As EventArgs) Handles txt_AminStores.EditValueChanged

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs)
        'If Len(Com_NameItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        Frm_GardItem2.txt_codeItem.Text = varcode_item
        'Frm_GardItem2.txt_NameItem.Text = Com_NameItem.Text
        Frm_GardItem2.Com_Stores.Text = Com_StoresNo.Text
        Frm_GardItem2.FindBalance()
        'Frm_GardItem2.Com_Stores.Text = txt_namestores.Text
        Frm_GardItem2.find_data()
        Frm_GardItem2.count_colume()
        Frm_GardItem2.count_colume2()
        Frm_GardItem2.final_sum()
        Frm_GardItem2.MdiParent = Mainmune
        Frm_GardItem2.Show()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
        varcode_item = varcode_item : varnamestores = Com_StoresNo.Text
        Frm_GardDetils.Close()
        Frm_GardDetils.txt_stores.Text = Com_StoresNo.Text
        'Frm_GardDetils.txt_NameItem.Text = Com_NameItem.Text
        Frm_GardDetils.find_Gard_detils()
        Frm_GardDetils.find_balance()
        Frm_GardDetils.MdiParent = Mainmune
        Frm_GardDetils.Show()
    End Sub

    Private Sub Cmd_findProject_Click_1(sender As Object, e As EventArgs) Handles Cmd_findProject.Click
        vartable = "Vw_AllProject"
        VarOpenlookup = 502568
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        VarOpenlookup2 = 242404
        Frm_LookUpCustomer.Find_Suppliser()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Frm_suppliersInfo.MdiParent = Mainmune
        Frm_suppliersInfo.Show()
        'Frm_ShippingData.Show()
    End Sub

   

    Private Sub cmd_DeleteLine_Click_1(sender As Object, e As EventArgs) Handles cmd_DeleteLine.Click
        On Error Resume Next
        '====================================
        sql = " Select Order_Stores_No      FROM dbo.TB_Detalis_InvoicePrcheses WHERE  (Order_Stores_No = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحذف الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub

        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(Com_NameItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        'sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_Stores_NO = '" & Com_InvoiceNo.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=====================================================



        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "Delete TB_Detils_AznAddItem  WHERE No_item = '" & varItemCode & "' and Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete Statement_OfItem  WHERE NoItem = '" & varItemCode & "' and NumberBill ='" & Com_InvoiceNo2.Text & "' and TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','20','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                Search()
        End Select

    End Sub

    Private Sub cmd_update_Click_1(sender As Object, e As EventArgs) Handles cmd_update.Click
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(Com_NameItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        sql = " Select Order_Stores_No      FROM dbo.TB_Detalis_InvoicePrcheses WHERE  (Order_Stores_No = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن التعديل الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub

        'Dim varcodunit As Integer
        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_StoresNo.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================

        '======================================No Unit
        'sql = "   SELECT Code   FROM BD_Unit    WHERE(Name = '" & Txt_UnitItem2.Text & "') and Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodunit = rs("code").Value
        ''=================================================
        ''============================================================== نوع الصرف
        'sql = "SELECT  * FROM   BD_TypeSarfStores  where Name = '" & txt_type.Text & "' and Compny_Code ='" & VarCodeCompny & "'   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_TypeStores = rs("code").Value
        ''==================================================================

        sql = "UPDATE  TB_Header_AznAddItem  SET Code_Customer ='" & txt_CodeSuppliser.Text & "', Code_Project ='" & txt_CodeProject.Text & "', Notes = '" & Txt_Notes.Text & "'  WHERE   Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        'sql = "UPDATE  TB_Detils_AznAddItem  SET Qyt = '" & txt_QytItem2.Text & "',Code_Unit = '" & varcodunit & "', Code_Stores ='" & varcodStores & "'  WHERE  No_item = '" & varItemCode & "' and Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)


        'sql = "UPDATE  Statement_OfItem  SET Export = '" & txt_QytItem2.Text & "',Code_Unit = '" & varcodunit & "', Code_Stores ='" & varcodStores & "'  WHERE  NoItem = '" & varItemCode & "' and NumberBill ='" & Com_InvoiceNo2.Text & "' and TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)

        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','20','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        MsgBox("تم التعديل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "CSS Solution Software Module")
        find_hedar()
        find_detalis()
        Search()
    End Sub

    Private Sub Cmd_Print_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Frm_EdafaPrinting.Show()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        varaznAddItem = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        clear_detils()
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro

        If DataGridView2.Item(3, mt).Value = "" Then MsgBox("من فضلك ادخل الوحدة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        If Com_TypeItem.Text = "" Then MsgBox("من فضلك ادخل نوع الاضافة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        If Com_StoresNo.Text = "" Then MsgBox("من فضلك ادخل المخزن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        If txt_AminStores.Text = "" Then MsgBox("من فضلك ادخل أمين المخزن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        'If Com_StoresNo.Text = "" Then MsgBox("من فضلك ادخل المخزن", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub


        ro = DataGridView2.CurrentRow.Index
        mt = ro
        varcode_item = DataGridView2.Item(0, mt).Value
        varNameUnit = DataGridView2.Item(3, mt).Value



        save_data()
        find_detalis()

    End Sub


    Sub save_data()
        On Error Resume Next

        Dim varinvoicesss As Integer
        If Com_InvoiceNo2.Text = "" Then varinvoicesss = 0 Else varinvoicesss = Com_InvoiceNo2.Text
        sql2 = "select * from TB_Header_AznAddItem where NumberBill  = '" & Trim(varinvoicesss) & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()
        End If



        save_Order_H()
        'Fill_INVOICE2()

   
    End Sub
    Sub delete_Item()
        sql = "Delete TB_Detils_AznAddItem  where Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '===================================حذف من المخزن
        'sql = "Delete TB_Header_AznAddItem   where Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "'  and Compny_Code ='" & VarCodeCompny & "'  "
        'rs = Cnn.Execute(sql)


        sql = "Delete Statement_OfItem  WHERE  (TypeD = '" & 20 & "') AND (NumberBill = '" & Com_InvoiceNo2.Text & "')   "
        rs = Cnn.Execute(sql)
        'MsgBox("تم حذف الاذن", MsgBoxStyle.Information, "Css Solution Software Module")
    End Sub
    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(Com_NameItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_QytItem2.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_TypeItem.Text) = 0 Then MsgBox("من  فضلك ادخل  نوع الاضافة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_StoresNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AminStores.Text) = 0 Then MsgBox("من  فضلك ادخل أسم أمين المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = " Select Order_Stores_No      FROM dbo.TB_Detalis_InvoicePrcheses WHERE  (Order_Stores_No = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحفظ الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub


        sql2 = "select * from TB_Header_AznAddItem where Ser_NO_StoresAdd  = '" & Trim(Com_InvoiceNo2.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم اذن الاضافة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        delete_Item()
        save_oderDetils()

        'clear_detils()
        find_hedar()
        find_detalis()
        Search()
    End Sub

    Private Sub cmd_OpenInvoice_Click(sender As Object, e As EventArgs) Handles cmd_OpenInvoice.Click
        If txt_InvoiceNo.Text = "" Then MsgBox("من فضلك اختار رقم الفاتورة", MsgBoxStyle.Critical, "css") : Exit Sub

        Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = txt_InvoiceNo.Text
        Frm_Prcheses_Invoice.find_hedar()
        Frm_Prcheses_Invoice.find_detalis()
        'Frm_Prcheses_Invoice.find_Invoice_Condation()
        Frm_Prcheses_Invoice.Total_Sum()
        Frm_Prcheses_Invoice.sum_tax()
        Frm_Prcheses_Invoice.MdiParent = Mainmune
        Frm_Prcheses_Invoice.Show()
    End Sub

    Private Sub Cmd_Delete_Click_1(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next

        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك اختار رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك اختار  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_type.Text) = 0 Then MsgBox("من  فضلك اختار نوع الطلب الصرف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If varstatus = "منصرف" Then MsgBox("هذا الاذن تم صرفة ولا يمكن حذفه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        'sql = "  SELECT        No_Item, Compny_Code, Order_Stores_NO FROM            dbo.TB_Detils_AznItem_Stores WHERE        (Order_Stores_NO = '" & Com_InvoiceNo.Text & "') AND (No_Item = '" & txt_CodeItem.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("لايمكن حذف الصنف علية حركة مسبقا", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        ''=====================================================
        '==========================CheckInvoice
        'sql = "   SELECT        Code, Ser_InvoiceNo        FROM dbo.Vw_Lookup_AznItem2 WHERE        (Code = '" & Com_InvoiceNo2.Text & "') AND (Ser_InvoiceNo IS NOT NULL)"

        sql = " Select Order_Stores_No      FROM dbo.TB_Detalis_InvoicePrcheses WHERE  (Order_Stores_No = '" & Com_InvoiceNo2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الحذف الاذن يوجد عليه فاتورة ", MsgBoxStyle.Critical, "Account Solution Software Module") : Exit Sub
        '=============================



        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاذن", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                sql = "Delete TB_Detils_AznAddItem  WHERE  Ser_NO_StoresAdd ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete TB_Header_AznAddItem  WHERE Ser_NO_StoresAdd = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                sql = "Delete Statement_OfItem  WHERE  NumberBill ='" & Com_InvoiceNo2.Text & "' and TypeD ='" & 20 & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','20','11','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_hedar()
                find_detalis()
                clear_detils()
                Search()
        End Select
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub
End Class