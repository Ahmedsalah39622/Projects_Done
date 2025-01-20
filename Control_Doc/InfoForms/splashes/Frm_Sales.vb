Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Sales
    ' Dim varcodeaccountgroup As Integer
    ' Sub last_Data()


    '     'On Error Resume Next
    '     sql = "SELECT        MAX(Customer_Code) AS MaxmamNo FROM St_CustomerData where Compny_Code ='" & VarCodeCompny & "' HAVING (MAX(Customer_Code) IS NOT NULL) "

    '     'Cnn.Execute(sql)
    '     rs3 = Cnn.Execute(sql)
    '     If rs3.EOF = False Then
    '         txt_Code.Text = rs3("MaxmamNo").Value + 1
    '     Else
    '         txt_Code.Text = 1
    '         clear()

    '     End If
    ' End Sub
    ' Sub clear()
    '     txt_name.Text = ""
    '     txt_Code.Text = ""
    '     txt_AccountNo.Text = ""
    '     com_type.Text = ""
    '     com_Religion.Text = ""
    '     txt_NationalID.Text = ""
    '     txt_Addres.Text = ""
    '     txt_Phone1.Text = ""
    '     txt_Phone2.Text = ""
    '     txt_Website.Text = ""
    '     txt_Email.Text = ""
    '     txt_Notes.Text = ""
    '     txt_Creditlimit.Text = ""



    ' End Sub
    ' Sub find_CustomerAll()
    '     Dim sql2 As String
    '     sql2 = "select    St_CustomerData.Customer_Code, St_CustomerData.Customer_Name, Vw_LookupAccountLv2.name AS NameGroup, St_CustomerData.Customer_Type, " & _
    '"                  St_CustomerData.Customer_Religion, St_CustomerData.Customer_NationalID, St_CustomerData.Customer_Address, St_CustomerData.Customer_Phon1, St_CustomerData.Customer_Phon2,  " & _
    '"        St_CustomerData.Customer_Website, St_CustomerData.Customer_Email, St_CustomerData.Customer_Notes, BD_REGION.Name, St_CustomerData.Customer_Creditlimit, " & _
    '"                  IIF( St_CustomerData.Customer_Flag=0,'سارى','متوقف') as Status " & _
    '" FROM     St_CustomerData LEFT OUTER JOIN " & _
    '"                  Vw_LookupAccountLv2 ON St_CustomerData.Customer_AccountNoGroup = Vw_LookupAccountLv2.code LEFT OUTER JOIN " & _
    '"                  BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
    '"        WHERE(St_CustomerData.Compny_Code = '" & VarCodeCompny & "') " & _
    '" ORDER BY St_CustomerData.Customer_Code "

    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql2)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = "كود العميل"
    '         GridView6.Columns(1).Caption = "أسم العميل"
    '         GridView6.Columns(2).Caption = "أسم الحساب الرئيسى"
    '         GridView6.Columns(3).Caption = "النوع"
    '         GridView6.Columns(4).Caption = "الديانة"
    '         GridView6.Columns(5).Caption = "الرقم القومى"
    '         GridView6.Columns(6).Caption = "العنوان"
    '         GridView6.Columns(7).Caption = "تليفون 1"
    '         GridView6.Columns(8).Caption = "تليفون 2"
    '         GridView6.Columns(9).Caption = "الموقع الالكترونى "
    '         GridView6.Columns(10).Caption = "Email"
    '         GridView6.Columns(11).Caption = "ملاحظات"
    '         GridView6.Columns(12).Caption = "المنطقة"
    '         GridView6.Columns(13).Caption = "الحالة"

    '         GridView6.Columns(0).Width = "200"
    '         GridView6.Columns(1).Width = "500"
    '         GridView6.Columns(2).Width = "100"
    '         GridView6.Columns(3).Width = "100"
    '         GridView6.Columns(4).Width = "100"
    '         GridView6.Columns(5).Width = "100"
    '         GridView6.Columns(6).Width = "100"
    '         GridView6.Columns(7).Width = "100"
    '         GridView6.Columns(8).Width = "100"
    '         GridView6.Columns(9).Width = "100"
    '         GridView6.Columns(10).Width = "100"
    '         GridView6.Columns(11).Width = "100"
    '         GridView6.Columns(12).Width = "100"
    '         GridView6.Columns(13).Width = "100"

    '         'Dim dt As DataTable = New DataTable()
    '         'dt.Rows.Add(New Object() {Image.FromFile("E:\Source2\interpaknational2\ico\Finance_Icon_Set.jpg"), "test1"})


    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If

    '     If varCodeConnaction = 2 Then '======Oracle
    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()
    '         rs = Cnn.Execute(sql2)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = "كود العميل"
    '         GridView6.Columns(1).Caption = "أسم العميل"
    '         GridView6.Columns(2).Caption = "أسم الحساب الرئيسى"
    '         GridView6.Columns(3).Caption = "النوع"
    '         GridView6.Columns(4).Caption = "الديانة"
    '         GridView6.Columns(5).Caption = "الرقم القومى"
    '         GridView6.Columns(6).Caption = "العنوان"
    '         GridView6.Columns(7).Caption = "تليفون 1"
    '         GridView6.Columns(8).Caption = "تليفون 2"
    '         GridView6.Columns(9).Caption = "الموقع الالكترونى "
    '         GridView6.Columns(10).Caption = "Email"
    '         GridView6.Columns(11).Caption = "ملاحظات"
    '         GridView6.Columns(12).Caption = "المنطقة"
    '         GridView6.Columns(13).Caption = "الحالة"

    '         GridView6.Columns(0).Width = "50"
    '         GridView6.Columns(1).Width = "200"
    '         GridView6.Columns(2).Width = "100"
    '         GridView6.Columns(3).Width = "100"
    '         GridView6.Columns(4).Width = "100"
    '         GridView6.Columns(5).Width = "100"
    '         GridView6.Columns(6).Width = "100"
    '         GridView6.Columns(7).Width = "100"
    '         GridView6.Columns(8).Width = "100"
    '         GridView6.Columns(9).Width = "100"
    '         GridView6.Columns(10).Width = "100"
    '         GridView6.Columns(11).Width = "100"
    '         GridView6.Columns(12).Width = "100"
    '         GridView6.Columns(13).Width = "100"



    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub

    ' Sub Find()
    '     'On Error Resume Next


    '     sql = "  SELECT  Customer_Code, Customer_Name FROM     St_CustomerData WHERE  (Compny_Code = '" & VarCodeCompny & "') ORDER BY Customer_Code "

    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl1.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView1.Columns(0).Caption = "الكود"
    '         GridView1.Columns(1).Caption = "الاسم"
    '         GridView1.Columns(0).Width = "20"
    '         GridView1.Columns(1).Width = "150"
    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If

    '     If varCodeConnaction = 2 Then '======Oracle
    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()
    '         rs = Cnn.Execute(sql)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl1.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView1.Columns(0).Caption = "الكود"
    '         GridView1.Columns(1).Caption = "الاسم"
    '         GridView1.Columns(0).Width = "20"
    '         GridView1.Columns(1).Width = "150"
    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub
    ' Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
    '     last_Data()
    ' End Sub




    ' Private Sub Frm_DataCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '     'com_type.Items.Add("ذكر")
    '     'com_type.Items.Add("انثى")
    '     'com_Religion.Items.Add("مسلم")
    '     'com_Religion.Items.Add("مسيحى")
    '     'Find()
    '     'find_CustomerAll()
    '     'sum_total()

    '     ''Dim edit As RepositoryItemCheckEdit = New RepositoryItemCheckEdit
    '     ' ''Dim trueValue As Int64 = 1
    '     '' ''Dim falseValue As Int64 = 0
    '     ' ''edit.ValueChecked = trueValue
    '     ' ''edit.ValueUnchecked = falseValue
    '     ''Me.GridView1.Columns(0).ColumnEdit = edit
    '     ''Me.GridView6.RepositoryItems.Add(edit)
    ' End Sub
    ' Sub sum_total()
    '     GridView6.Columns(0).Summary.Add(DevExpress.Data.SummaryItemType.Count, "0", "Count={0:n2}")
    '     GridView6.Columns(2).Group()
    '     GridView6.Columns(3).Group()
    '     'GridView6.Columns(3).
    '     'GridView6.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
    '     'Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
    '     'item.FieldName = "النوع"
    '     'item.SummaryType = DevExpress.Data.SummaryItemType.Count
    '     'GridView6.GroupSummary.Add(item)


    '     'Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
    '     'item1.FieldName = "النوع"
    '     'item1.SummaryType = DevExpress.Data.SummaryItemType.Count
    '     'item1.DisplayFormat = "Total {0:c2}"
    '     'item1.ShowInGroupColumnFooter = GridView6.Columns("النوع")
    '     'GridView6.GroupSummary.Add(item1)

    ' End Sub



    ' Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs)
    '     If Len(Cmd_AccountNoGroup.Text) = 0 Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(com_type.Text) = 0 Then MsgBox("من فضلك ادخل النوع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


    '     sql = "SELECT     * " & _
    '     " FROM         St_CustomerData  WHERE     (Customer_Code = " & txt_Code.Text & ") and Compny_Code = '" & VarCodeCompny & "' "
    '     rs = Cnn.Execute(sql)
    '     If rs.EOF = False Then
    '         MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
    '     Else

    '         '=========================================GroupAccount
    '         Dim varcodeaccountgroup As Integer
    '         sql = "SELECT     * " & _
    '            " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
    '         rs = Cnn.Execute(sql)
    '         If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

    '         '======================================Region
    '         Dim varcodeRegion As Integer
    '         sql = "SELECT     * " & _
    '         " FROM         BD_REGION WHERE     (Name = '" & txt_Region.Text & "')"
    '         rs = Cnn.Execute(sql)
    '         If rs.EOF = False Then varcodeRegion = rs("Code").Value
    '         '===============================================
    '         Dim varstatus As Integer
    '         If Radio_Stop.Checked = True Then varstatus = 1
    '         If Radio_Avalible.Checked = True Then varstatus = 0

    '         lastAccounno()
    '         Dim sql2 As String
    '         sql2 = "INSERT INTO St_CustomerData (Compny_Code, Customer_Code,Customer_AccountNo,Customer_AccountNoGroup,Customer_Name,Customer_Type,Customer_Religion,Customer_NationalID,Customer_Address,Customer_Phon1,Customer_Phon2,Customer_Website,Customer_Email,Customer_Notes,Code_Region,Customer_Creditlimit,Customer_Flag) " & _
    '           " values  ('" & VarCodeCompny & "' ,'" & txt_Code.Text & "','" & txt_AccountNo.Text & "','" & varcodeaccountgroup & "','" & txt_name.Text & "','" & com_type.Text & "','" & com_Religion.Text & "','" & txt_NationalID.Text & "','" & txt_Addres.Text & "','" & txt_Phone1.Text & "','" & txt_Phone2.Text & "','" & txt_Website.Text & "','" & txt_Email.Text & "','" & txt_Notes.Text & "','" & varcodeRegion & "','" & txt_Creditlimit.Text & "','" & varstatus & "')"
    '         rs = Cnn.Execute(sql2)

    '         '============================AddChartOfAccount

    '         sql = "INSERT INTO ST_CHARTOFACCOUNT (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
    '     " values  (N'" & 3 & "' ,N'" & txt_AccountNo.Text & "',N'" & txt_AccountNo.Text & "',N'" & varcodeaccountgroup & "',N'" & txt_name.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_AccountNo.Text + "-" + txt_name.Text & "',N'" & txt_AccountNo.Text & "','" & VarCodeCompny & "')"
    '         Cnn.Execute(sql)




    '         MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    '         clear()
    '         last_Data()
    '         lastAccounno()
    '         Find()
    '         find_CustomerAll()
    '         'Search()
    '         'Find()
    '     End If
    ' End Sub

    ' Private Sub Cmd_AccountNoGroup_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
    '     vartable = "Vw_LookupAccountLv2"
    '     VarOpenlookup = 9
    '     'Frm_Lookup.MdiParent = Me
    '     Frm_Lookup.Text = "بحث"
    '     Frm_Lookup.ShowDialog()

    '     clear()
    '     last_Data()
    '     lastAccounno()
    '     txt_name.Select()
    ' End Sub

    ' Private Sub txt_Region_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
    '     vartable = "BD_REGION"
    '     VarOpenlookup = 8
    '     'Frm_Lookup.MdiParent = Me
    '     Frm_Lookup.Text = "بحث"
    '     Frm_Lookup.ShowDialog()
    ' End Sub


    ' Private Sub Cmd_Update_Click(sender As Object, e As EventArgs)
    '     If Len(Cmd_AccountNoGroup.Text) = 0 Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(com_type.Text) = 0 Then MsgBox("من فضلك ادخل النوع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


    '     '=========================================GroupAccount
    '     Dim varcodeaccountgroup As Integer
    '     sql = "SELECT     * " & _
    '        " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
    '     rs = Cnn.Execute(sql)
    '     If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

    '     '======================================Region
    '     Dim varcodeRegion As Integer
    '     sql = "SELECT     * " & _
    '     " FROM         BD_REGION WHERE     (Name = '" & txt_Region.Text & "')"
    '     rs = Cnn.Execute(sql)
    '     If rs.EOF = False Then varcodeRegion = rs("Code").Value
    '     '===============================================
    '     Dim varstatus As Integer
    '     If Radio_Stop.Checked = True Then varstatus = 1
    '     If Radio_Avalible.Checked = True Then varstatus = 0


    '     Dim sql2 As String
    '     sql2 = "UPDATE  St_CustomerData  SET Customer_AccountNoGroup='" & varcodeaccountgroup & "' , Customer_Name = '" & txt_name.Text & "',Customer_Type ='" & com_type.Text & "',Customer_Religion ='" & com_Religion.Text & "',Customer_NationalID ='" & txt_NationalID.Text & "',Customer_Address ='" & txt_Addres.Text & "',Customer_Phon1 ='" & txt_Phone1.Text & "',Customer_Phon2 ='" & txt_Phone2.Text & "',Customer_Website ='" & txt_Website.Text & "',Customer_Email ='" & txt_Email.Text & "',Customer_Notes ='" & txt_Notes.Text & "' ,Code_Region ='" & varcodeRegion & "',Customer_Creditlimit='" & txt_Creditlimit.Text & "',Customer_Flag = " & varstatus & "  WHERE Compny_Code = " & VarCodeCompny & "  and Customer_Code ='" & txt_Code.Text & "'  "
    '     rs = Cnn.Execute(sql2)



    '     sql = "UPDATE  St_CustomerData  SET Account_No = '" & txt_AccountNo.Text & "' WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'    "
    '     rs = Cnn.Execute(sql2)
    '     MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

    '     clear()
    '     last_Data()
    '     lastAccounno()
    '     find_CustomerAll()
    '     Find()
    ' End Sub

    ' Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
    '     On Error Resume Next
    '     Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
    '     Dim value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))



    '     '===================================Find

    '     sql = " SELECT St_CustomerData.Customer_Code, St_CustomerData.Compny_Code, St_CustomerData.Customer_AccountNo, St_CustomerData.Customer_AccountNoGroup, " & _
    '   "              RTRIM(ST_CHARTOFACCOUNT.AccountName) AS AccountName, St_CustomerData.Customer_Name, St_CustomerData.Customer_Type, St_CustomerData.Customer_Religion,  " & _
    '   "    St_CustomerData.Customer_NationalID, St_CustomerData.Customer_Address, St_CustomerData.Customer_Phon1, St_CustomerData.Customer_Phon2, St_CustomerData.Customer_Website, " & _
    '   "                St_CustomerData.Customer_Email, St_CustomerData.Customer_Notes, BD_REGION.Name As NameRejon,IIF(St_CustomerData.Customer_Flag=0,'سارى','متوقف') as Status, St_CustomerData.Customer_Creditlimit " & _
    '   " FROM     St_CustomerData INNER JOIN " & _
    '   "                  ST_CHARTOFACCOUNT ON St_CustomerData.Customer_AccountNoGroup = ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN " & _
    '   "                  BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
    '   "       where St_CustomerData.Customer_Code = '" & value & "' And St_CustomerData.Compny_Code = '" & VarCodeCompny & "' "


    '     rs = Cnn.Execute(sql)
    '     If rs.EOF = False Then
    '         txt_Code.Text = rs("Customer_Code").Value
    '         txt_name.Text = rs("Customer_Name").Value
    '         Cmd_AccountNoGroup.Text = rs("AccountName").Value
    '         txt_AccountNo.Text = rs("Customer_AccountNo").Value
    '         txt_Region.Text = rs("Name").Value
    '         txt_Creditlimit.Text = rs("Customer_Creditlimit").Value
    '         txt_Phone1.Text = rs("Customer_Phon1").Value
    '         txt_Phone2.Text = rs("Customer_Phon2").Value
    '         com_type.Text = rs("Customer_Type").Value
    '         txt_Website.Text = rs("Customer_Website").Value
    '         txt_Email.Text = rs("Customer_Email").Value
    '         txt_Notes.Text = rs("Customer_Notes").Value
    '         txt_Addres.Text = rs("Customer_Address").Value
    '         txt_NationalID.Text = rs("Customer_NationalID").Value
    '         com_Religion.Text = rs("Customer_Religion").Value
    '         txt_NationalID.Text = rs("Customer_NationalID").Value

    '         If rs("Customer_Flag").Value = 0 Then
    '             Radio_Avalible.Checked = True
    '         Else
    '             Radio_Stop.Checked = True
    '         End If

    '     Else
    '         clear()
    '     End If
    '     TabPane1.SelectedPageIndex = 0
    ' End Sub

    ' Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs)
    '     If Cmd_AccountNoGroup.Text = "" Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
    '     '=========================================GroupAccount
    '     clear()
    '     last_Data()
    '     lastAccounno()



    '     'Dim item As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
    '     'GridControl1.RepositoryItems.Add(item)
    '     'GridView6.Columns(2).ColumnEdit = item
    '     'Dim dt As DataTable = New DataTable()
    '     'dt.Columns.Add("Photo")
    '     'dt.Columns.Add("Test")
    '     'dt.Rows.Add(New Object() {Image.FromFile("E:\Source2\interpaknational2\ico\invoice3.ico"), "test1"})
    '     'dt.Rows.Add(New Object() {Image.FromFile("..\openWell.jpg"), "test2"})
    '     'dt.Rows.Add(New Object() {Image.FromFile("..\openWell.jpg"), "test3"})

    '     'GridControl1.DataSource = dt
    ' End Sub
    ' Sub lastAccounno()
    '     'clear()
    '     sql = "SELECT     * " & _
    '        " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
    '     rs = Cnn.Execute(sql)
    '     If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

    '     '===========================================
    '     'sql = " SELECT MAX(Customer_AccountNo)  AS Maxmaim      FROM dbo.St_CustomerData WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Customer_AccountNoGroup = '" & varcodeaccountgroup & "') HAVING (MAX(Customer_AccountNo) IS NOT NULL) "

    '     sql = "  SELECT MAX(Customer_AccountNo) AS Maxmaim       FROM dbo.St_CustomerData WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Customer_AccountNoGroup = '" & varcodeaccountgroup & "')" & _
    '    " HAVING(MAX(Customer_AccountNo) Is Not NULL)"

    '     rs3 = Cnn.Execute(sql)
    '     If rs3.EOF = False Then
    '         txt_AccountNo.Text = rs3("Maxmaim").Value + 1
    '     Else
    '         txt_AccountNo.Text = Str(varcodeaccountgroup) + "001"
    '     End If

    ' End Sub

    ' Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs)

    '     sql = "Delete St_CustomerData  WHERE Compny_Code = " & VarCodeCompny & " and Customer_Code ='" & txt_Code.Text & "'  "
    '     rs = Cnn.Execute(sql)

    '     sql = "Delete ST_CHARTOFACCOUNT  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'  "
    '     rs = Cnn.Execute(sql)

    '     MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
    '     clear()
    '     last_Data()
    '     lastAccounno()
    '     Find()
    '     find_CustomerAll()
    ' End Sub

    ' Private Sub Cmd_AccountNoGroup_EditValueChanged(sender As Object, e As EventArgs)

    ' End Sub

    Private Sub ButtonItem60_Click(sender As Object, e As EventArgs) Handles ButtonItem60.Click
        saleswithcompanyname()

    End Sub
    Sub saleswithcompanyname()
        On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        sql3 = ""

        sql3 = " SELECT '' as NoVisit,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4,'' as NoVisit5,'' as NoVisit6,'' as NoVisit7,'' as NoVisit8,'' as NoVisit9,Customer_Name as DelName   from St_CustomerData "




        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "رقم الزيارة"
            GridView6.Columns(1).Caption = " أسم المندوب"
            GridView6.Columns(2).Caption = "التاريخ"
            GridView6.Columns(3).Caption = "اليوم"
            GridView6.Columns(4).Caption = "رقم الزيارة"
            GridView6.Columns(5).Caption = "وقت البدء"
            GridView6.Columns(6).Caption = " وقت الانتهاء"
            GridView6.Columns(7).Caption = "المستغرق"
            GridView6.Columns(8).Caption = "أسم العميل"
            GridView6.Columns(9).Caption = "نوع العميل"
            GridView6.Columns(10).Caption = "نوع المكالمة"


            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    ' Private Sub txt_Region_CustomDisplayText(sender As Object, e As XtraEditors.Controls.CustomDisplayTextEventArgs)

    ' End Sub

    ' Private Sub txt_Region_EditValueChanged(sender As Object, e As EventArgs)

    ' End Sub

    ' Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    ' End Sub

    ' Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    ' End Sub

    Private Sub ButtonItem61_Click(sender As Object, e As EventArgs) Handles ButtonItem61.Click
        soldMaterials()


    End Sub
    Sub soldMaterials()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4,'' as NoVisit5,'' as NoVisit6,'' as NoVisit7,'' as NoVisit8,'' as NoVisit9,'' as NoVisit10 ,'' as NoVisit11,'' as NoVisit12  from St_CustomerData "



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "رقم الفاتورة"
            GridView6.Columns(1).Caption = "تاريخ الفاتورة"
            GridView6.Columns(2).Caption = "اجمالي الفاتورة"
            GridView6.Columns(3).Caption = "خصم"
            GridView6.Columns(4).Caption = "ضريبة"
            GridView6.Columns(5).Caption = "الصافي "
            GridView6.Columns(6).Caption = " أسم العميل "
            GridView6.Columns(7).Caption = "المنطقة"
            GridView6.Columns(8).Caption = "نوع العميل"
            GridView6.Columns(9).Caption = "المجموعة1"
            GridView6.Columns(10).Caption = "المجموعة2 "
            GridView6.Columns(11).Caption = "اسم الصنف "
            'GridView6.Appearance .

            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ButtonItem1_Click_1(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        TopsellingMaterials()

    End Sub
    Sub TopsellingMaterials()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4,'' as NoVisit5,'' as NoVisit6,'' as NoVisit7,'' as NoVisit8,'' as NoVisit9,'' as NoVisit10 ,'' as NoVisit11,'' as NoVisit12  from St_CustomerData "



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "رقم الفاتورة"
            GridView6.Columns(1).Caption = "تاريخ الفاتورة"
            GridView6.Columns(2).Caption = "اجمالي الفاتورة"
            GridView6.Columns(3).Caption = "خصم"
            GridView6.Columns(4).Caption = "ضريبة"
            GridView6.Columns(5).Caption = "الصافي "
            GridView6.Columns(6).Caption = " أسم العميل "
            GridView6.Columns(7).Caption = "المنطقة"
            GridView6.Columns(8).Caption = "نوع العميل"
            GridView6.Columns(9).Caption = "المجموعة1"
            GridView6.Columns(10).Caption = "المجموعة2 "
            GridView6.Columns(11).Caption = "اسم الصنف "
            'GridView6.Appearance .

            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        MaterialsReturnedFromSales()

    End Sub
    Sub MaterialsReturnedFromSales()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4   from St_CustomerData "



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = " أسم العميل"
            GridView6.Columns(1).Caption = "العنوان "
            GridView6.Columns(2).Caption = "اسم المندوب "
            GridView6.Columns(3).Caption = "منطقة العميل"

            'GridView6.Appearance .

            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        billsofsalesformaterials()

    End Sub
    Sub billsofsalesformaterials()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5,'' as NoVisit6   from St_CustomerData "



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = " رقم المصروف "
            GridView6.Columns(1).Caption = "اسم المصروف "
            GridView6.Columns(2).Caption = "قيمة المصروف"
            GridView6.Columns(3).Caption = "التاريخ "
            GridView6.Columns(4).Caption = "الاجمالي "
            GridView6.Columns(5).Caption = "اسم المندوب "
            'GridView6.Appearance .

            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub


    ' Sub totalbills()
    '     'On Error Resume Next
    '     'GridControl3.DataSource = NullValue
    '     GridControl3.DataSource = Nothing
    '     'GridControl3.Refresh()
    '     'GridControl3.RefreshEdit()
    '     GridView6.Columns.Clear()

    '     Dim sql3 As String
    '     'sql3 = ""

    '     sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5  from St_CustomerData "



    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql3)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = " رقم المندوب "
    '         GridView6.Columns(1).Caption = "اسم المندوب "
    '         GridView6.Columns(2).Caption = " تاريخ الفاتورة "
    '         GridView6.Columns(3).Caption = "رقم الفاتورة "
    '         GridView6.Columns(4).Caption = "الاجمالي "

    '         'GridView6.Appearance .

    '         'GridView6.Columns(0).BestFit = "50"
    '         'GridView6.Columns(1).Width = "100"
    '         'GridView6.Columns(2).Width = "50"
    '         'GridView6.Columns(3).Width = "50"
    '         'GridView6.Columns(4).Width = "50"
    '         'GridView6.Columns(5).Width = "50"
    '         'GridView6.Columns(6).Width = "50"

    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub


    ' Sub returned()
    '     'On Error Resume Next
    '     'GridControl3.DataSource = NullValue
    '     GridControl3.DataSource = Nothing
    '     'GridControl3.Refresh()
    '     'GridControl3.RefreshEdit()
    '     GridView6.Columns.Clear()

    '     Dim sql3 As String
    '     'sql3 = ""

    '     sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6,'' as NoVisit7,'' as NoVisit8 from St_CustomerData "



    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql3)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = "رقم فاتورة المرتجع"
    '         GridView6.Columns(1).Caption = "تاريخ الفاتورة"
    '         GridView6.Columns(2).Caption = " اجمالي الفاتورة "
    '         GridView6.Columns(3).Caption = "ضريبة "
    '         GridView6.Columns(4).Caption = "خصم "
    '         GridView6.Columns(5).Caption = " اجمالي  "
    '         GridView6.Columns(6).Caption = "صافي "
    '         GridView6.Columns(7).Caption = "اسم المندوب "

    '         'GridView6.Appearance .

    '         'GridView6.Columns(0).BestFit = "50"
    '         'GridView6.Columns(1).Width = "100"
    '         'GridView6.Columns(2).Width = "50"
    '         'GridView6.Columns(3).Width = "50"
    '         'GridView6.Columns(4).Width = "50"
    '         'GridView6.Columns(5).Width = "50"
    '         'GridView6.Columns(6).Width = "50"

    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub

    ' Private Sub ButtonItem8_Click(sender As Object, e As EventArgs)
    '     PO()
    '     'ButtonItem8.ForeColor = Color.Blue
    '     'ButtonItem8.FontBold = True
    ' End Sub
    ' Sub PO()
    '     'On Error Resume Next
    '     'GridControl3.DataSource = NullValue
    '     GridControl3.DataSource = Nothing
    '     'GridControl3.Refresh()
    '     'GridControl3.RefreshEdit()
    '     GridView6.Columns.Clear()

    '     Dim sql3 As String
    '     'sql3 = ""

    '     sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6,'' as NoVisit7 from St_CustomerData "



    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql3)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = "رقم الطلبية"
    '         GridView6.Columns(1).Caption = "العميل"
    '         GridView6.Columns(2).Caption = "التاريخ "
    '         GridView6.Columns(3).Caption = "اسم الصنف "
    '         GridView6.Columns(4).Caption = "الكمية"
    '         GridView6.Columns(5).Caption = "السعر  "
    '         GridView6.Columns(6).Caption = "الاجمالي"


    '         'GridView6.Appearance .

    '         'GridView6.Columns(0).BestFit = "50"
    '         'GridView6.Columns(1).Width = "100"
    '         'GridView6.Columns(2).Width = "50"
    '         'GridView6.Columns(3).Width = "50"
    '         'GridView6.Columns(4).Width = "50"
    '         'GridView6.Columns(5).Width = "50"
    '         'GridView6.Columns(6).Width = "50"

    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub

    ' Private Sub ButtonItem9_Click(sender As Object, e As EventArgs)
    '     collectionOfDelegate()
    ' End Sub
    ' Sub collectionOfDelegate()
    '     'On Error Resume Next
    '     'GridControl3.DataSource = NullValue
    '     GridControl3.DataSource = Nothing
    '     'GridControl3.Refresh()
    '     'GridControl3.RefreshEdit()
    '     GridView6.Columns.Clear()

    '     Dim sql3 As String
    '     'sql3 = ""

    '     sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6 ,'' as NoVisit7 from St_CustomerData "



    '     If varCodeConnaction = 1 Then '======Sql

    '         Dim ss As String
    '         Dim con As New OleDb.OleDbConnection
    '         ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
    '                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
    '         con.ConnectionString = ss
    '         con.Open()

    '         rs = Cnn.Execute(sql3)
    '         Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
    '         'create a new dataset
    '         Dim ds As New DataSet()
    '         'fill the datset
    '         da.Fill(ds)
    '         GridControl3.DataSource = ds.Tables(0)
    '         'GridColumn1.Caption = "d"
    '         GridView6.Columns(0).Caption = "رقم المندوب "
    '         GridView6.Columns(1).Caption = "اسم المندوب"
    '         GridView6.Columns(2).Caption = "رقم السند "
    '         GridView6.Columns(3).Caption = "مبلغ التحصيل"
    '         GridView6.Columns(4).Caption = "تاريخ التحصيل"
    '         GridView6.Columns(5).Caption = "اسم العميل"
    '         GridView6.Columns(6).Caption = "المنطقة"


    '         'GridView6.Appearance .

    '         'GridView6.Columns(0).BestFit = "50"
    '         'GridView6.Columns(1).Width = "100"
    '         'GridView6.Columns(2).Width = "50"
    '         'GridView6.Columns(3).Width = "50"
    '         'GridView6.Columns(4).Width = "50"
    '         'GridView6.Columns(5).Width = "50"
    '         'GridView6.Columns(6).Width = "50"

    '         ds = Nothing
    '         da = Nothing
    '         con.Close()
    '         con.Dispose()
    '     End If
    ' End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Salesreturns()

    End Sub
    Sub Salesreturns()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 from St_CustomerData "



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql3)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql3, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "عدد الكيلو مترات"
            GridView6.Columns(1).Caption = "من منطقة"
            GridView6.Columns(2).Caption = "الي منطقة "
            GridView6.Columns(3).Caption = "اجمالي الكيلو مترات"



            'GridView6.Appearance .

            'GridView6.Columns(0).BestFit = "50"
            'GridView6.Columns(1).Width = "100"
            'GridView6.Columns(2).Width = "50"
            'GridView6.Columns(3).Width = "50"
            'GridView6.Columns(4).Width = "50"
            'GridView6.Columns(5).Width = "50"
            'GridView6.Columns(6).Width = "50"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub





End Class