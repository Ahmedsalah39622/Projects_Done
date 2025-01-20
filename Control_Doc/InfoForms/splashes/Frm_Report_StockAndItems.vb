Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Report_StockAndItems
    Dim varcodeaccountgroup As Integer
   
    Sub find_CustomerAll()
        Dim sql2 As String
        sql2 = "select    St_CustomerData.Customer_Code, St_CustomerData.Customer_Name, Vw_LookupAccountLv2.name AS NameGroup, St_CustomerData.Customer_Type, " & _
   "                  St_CustomerData.Customer_Religion, St_CustomerData.Customer_NationalID, St_CustomerData.Customer_Address, St_CustomerData.Customer_Phon1, St_CustomerData.Customer_Phon2,  " & _
   "        St_CustomerData.Customer_Website, St_CustomerData.Customer_Email, St_CustomerData.Customer_Notes, BD_REGION.Name, St_CustomerData.Customer_Creditlimit, " & _
   "                  IIF( St_CustomerData.Customer_Flag=0,'سارى','متوقف') as Status " & _
   " FROM     St_CustomerData LEFT OUTER JOIN " & _
   "                  Vw_LookupAccountLv2 ON St_CustomerData.Customer_AccountNoGroup = Vw_LookupAccountLv2.code LEFT OUTER JOIN " & _
   "                  BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
   "        WHERE(St_CustomerData.Compny_Code = '" & VarCodeCompny & "') " & _
   " ORDER BY St_CustomerData.Customer_Code "

        If varCodeConnaction = 1 Then '======Sql

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
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "كود العميل"
            GridView6.Columns(1).Caption = "أسم العميل"
            GridView6.Columns(2).Caption = "أسم الحساب الرئيسى"
            GridView6.Columns(3).Caption = "النوع"
            GridView6.Columns(4).Caption = "الديانة"
            GridView6.Columns(5).Caption = "الرقم القومى"
            GridView6.Columns(6).Caption = "العنوان"
            GridView6.Columns(7).Caption = "تليفون 1"
            GridView6.Columns(8).Caption = "تليفون 2"
            GridView6.Columns(9).Caption = "الموقع الالكترونى "
            GridView6.Columns(10).Caption = "Email"
            GridView6.Columns(11).Caption = "ملاحظات"
            GridView6.Columns(12).Caption = "المنطقة"
            GridView6.Columns(13).Caption = "الحالة"

            GridView6.Columns(0).Width = "200"
            GridView6.Columns(1).Width = "500"
            GridView6.Columns(2).Width = "100"
            GridView6.Columns(3).Width = "100"
            GridView6.Columns(4).Width = "100"
            GridView6.Columns(5).Width = "100"
            GridView6.Columns(6).Width = "100"
            GridView6.Columns(7).Width = "100"
            GridView6.Columns(8).Width = "100"
            GridView6.Columns(9).Width = "100"
            GridView6.Columns(10).Width = "100"
            GridView6.Columns(11).Width = "100"
            GridView6.Columns(12).Width = "100"
            GridView6.Columns(13).Width = "100"

            'Dim dt As DataTable = New DataTable()
            'dt.Rows.Add(New Object() {Image.FromFile("E:\Source2\interpaknational2\ico\Finance_Icon_Set.jpg"), "test1"})


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
            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "كود العميل"
            GridView6.Columns(1).Caption = "أسم العميل"
            GridView6.Columns(2).Caption = "أسم الحساب الرئيسى"
            GridView6.Columns(3).Caption = "النوع"
            GridView6.Columns(4).Caption = "الديانة"
            GridView6.Columns(5).Caption = "الرقم القومى"
            GridView6.Columns(6).Caption = "العنوان"
            GridView6.Columns(7).Caption = "تليفون 1"
            GridView6.Columns(8).Caption = "تليفون 2"
            GridView6.Columns(9).Caption = "الموقع الالكترونى "
            GridView6.Columns(10).Caption = "Email"
            GridView6.Columns(11).Caption = "ملاحظات"
            GridView6.Columns(12).Caption = "المنطقة"
            GridView6.Columns(13).Caption = "الحالة"

            GridView6.Columns(0).Width = "50"
            GridView6.Columns(1).Width = "200"
            GridView6.Columns(2).Width = "100"
            GridView6.Columns(3).Width = "100"
            GridView6.Columns(4).Width = "100"
            GridView6.Columns(5).Width = "100"
            GridView6.Columns(6).Width = "100"
            GridView6.Columns(7).Width = "100"
            GridView6.Columns(8).Width = "100"
            GridView6.Columns(9).Width = "100"
            GridView6.Columns(10).Width = "100"
            GridView6.Columns(11).Width = "100"
            GridView6.Columns(12).Width = "100"
            GridView6.Columns(13).Width = "100"



            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    
    




    Private Sub Frm_DataCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'com_type.Items.Add("ذكر")
        'com_type.Items.Add("انثى")
        'com_Religion.Items.Add("مسلم")
        'com_Religion.Items.Add("مسيحى")
        'Find()
        'find_CustomerAll()
        'sum_total()

        ''Dim edit As RepositoryItemCheckEdit = New RepositoryItemCheckEdit
        ' ''Dim trueValue As Int64 = 1
        '' ''Dim falseValue As Int64 = 0
        ' ''edit.ValueChecked = trueValue
        ' ''edit.ValueUnchecked = falseValue
        ''Me.GridView1.Columns(0).ColumnEdit = edit
        ''Me.GridView6.RepositoryItems.Add(edit)
    End Sub
    Sub sum_total()
        GridView6.Columns(0).Summary.Add(DevExpress.Data.SummaryItemType.Count, "0", "Count={0:n2}")
        GridView6.Columns(2).Group()
        GridView6.Columns(3).Group()
        'GridView6.Columns(3).
        'GridView6.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        'Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item.FieldName = "النوع"
        'item.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView6.GroupSummary.Add(item)


        'Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item1.FieldName = "النوع"
        'item1.SummaryType = DevExpress.Data.SummaryItemType.Count
        'item1.DisplayFormat = "Total {0:c2}"
        'item1.ShowInGroupColumnFooter = GridView6.Columns("النوع")
        'GridView6.GroupSummary.Add(item1)

    End Sub



    

   
    Private Sub txt_Region_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "BD_REGION"
        VarOpenlookup = 8
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


   
    
   

   
  

    Private Sub ButtonItem60_Click(sender As Object, e As EventArgs) Handles ButtonItem60.Click
        visit()
        ButtonItem60.ForeColor = Color.Blue
        ButtonItem60.FontBold = True
    End Sub
    Sub visit()
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

    Private Sub txt_Region_CustomDisplayText(sender As Object, e As XtraEditors.Controls.CustomDisplayTextEventArgs)

    End Sub

    Private Sub txt_Region_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub ButtonItem61_Click(sender As Object, e As EventArgs) Handles ButtonItem61.Click
        salesMachine()
        ButtonItem61.ForeColor = Color.Blue
        ButtonItem61.FontBold = True

    End Sub
    Sub salesMachine()
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
        salesPart()
        ButtonItem1.ForeColor = Color.Blue
        ButtonItem1.FontBold = True
    End Sub
    Sub salesPart()
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
        regions()
        ButtonItem4.ForeColor = Color.Blue
        ButtonItem4.FontBold = True
    End Sub
    Sub regions()
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
        expenses()
        ButtonItem5.ForeColor = Color.Blue
        ButtonItem5.FontBold = True
    End Sub
    Sub expenses()
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

    Private Sub ExplorerBar1_Click(sender As Object, e As EventArgs) Handles ExplorerBar1.Click

    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        totalbills()
        ButtonItem6.ForeColor = Color.Blue
        ButtonItem6.FontBold = True
    End Sub
    Sub totalbills()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5  from St_CustomerData "



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
            GridView6.Columns(0).Caption = " رقم المندوب "
            GridView6.Columns(1).Caption = "اسم المندوب "
            GridView6.Columns(2).Caption = " تاريخ الفاتورة "
            GridView6.Columns(3).Caption = "رقم الفاتورة "
            GridView6.Columns(4).Caption = "الاجمالي "

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

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        returned()
        ButtonItem7.ForeColor = Color.Blue
        ButtonItem7.FontBold = True
    End Sub
    Sub returned()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6,'' as NoVisit7,'' as NoVisit8 from St_CustomerData "



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
            GridView6.Columns(0).Caption = "رقم فاتورة المرتجع"
            GridView6.Columns(1).Caption = "تاريخ الفاتورة"
            GridView6.Columns(2).Caption = " اجمالي الفاتورة "
            GridView6.Columns(3).Caption = "ضريبة "
            GridView6.Columns(4).Caption = "خصم "
            GridView6.Columns(5).Caption = " اجمالي  "
            GridView6.Columns(6).Caption = "صافي "
            GridView6.Columns(7).Caption = "اسم المندوب "

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

    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        PO()
        ButtonItem8.ForeColor = Color.Blue
        ButtonItem8.FontBold = True
    End Sub
    Sub PO()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6,'' as NoVisit7 from St_CustomerData "



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
            GridView6.Columns(0).Caption = "رقم الطلبية"
            GridView6.Columns(1).Caption = "العميل"
            GridView6.Columns(2).Caption = "التاريخ "
            GridView6.Columns(3).Caption = "اسم الصنف "
            GridView6.Columns(4).Caption = "الكمية"
            GridView6.Columns(5).Caption = "السعر  "
            GridView6.Columns(6).Caption = "الاجمالي"


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

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs)
        collectionOfDelegate()
    End Sub
    Sub collectionOfDelegate()
        'On Error Resume Next
        'GridControl3.DataSource = NullValue
        GridControl3.DataSource = Nothing
        'GridControl3.Refresh()
        'GridControl3.RefreshEdit()
        GridView6.Columns.Clear()

        Dim sql3 As String
        'sql3 = ""

        sql3 = " SELECT '' as NoVisit1,'' as NoVisit2,'' as NoVisit3,'' as NoVisit4 ,'' as NoVisit5 ,'' as NoVisit6 ,'' as NoVisit7 from St_CustomerData "



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
            GridView6.Columns(0).Caption = "رقم المندوب "
            GridView6.Columns(1).Caption = "اسم المندوب"
            GridView6.Columns(2).Caption = "رقم السند "
            GridView6.Columns(3).Caption = "مبلغ التحصيل"
            GridView6.Columns(4).Caption = "تاريخ التحصيل"
            GridView6.Columns(5).Caption = "اسم العميل"
            GridView6.Columns(6).Caption = "المنطقة"


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

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        KM()
        ButtonItem2.ForeColor = Color.Blue
        ButtonItem2.FontBold = True
    End Sub
    Sub KM()
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