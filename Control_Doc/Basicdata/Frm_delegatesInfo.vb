Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_delegatesInfo

    'Sub last_Data()


    '    'On Error Resume Next
    '    sql = "SELECT        MAX(Customer_Code) AS MaxmamNo FROM St_CustomerData where Compny_Code ='" & VarCodeCompny & "' HAVING (MAX(Customer_Code) IS NOT NULL) "

    '    'Cnn.Execute(sql)
    '    rs3 = Cnn.Execute(sql)
    '    If rs3.EOF = False Then
    '        txt_Code.Text = rs3("MaxmamNo").Value + 1
    '    Else
    '        txt_Code.Text = 1
    '        clear()

    '    End If
    'End Sub
    Sub clear()
        'txt_name.Text = ""

    End Sub
    Sub find_PeriodAll()
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

            GridView6.Columns(0).Width = "100"
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
    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs)
        'If Len(Cmd_AccountNoGroup.Text) = 0 Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(com_type.Text) = 0 Then MsgBox("من فضلك ادخل النوع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        'sql = "SELECT     * " & _
        ''" FROM         St_CustomerData  WHERE     (Customer_Code = " & txt_Code.Text & ") and Compny_Code = '" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        '    MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        'Else

        '=========================================GroupAccount
        Dim varcodeaccountgroup As Integer
        'sql = "SELECT     * " & _
        '" FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

        '======================================Region
        Dim varcodeRegion As Integer
        'sql = "SELECT     * " & _
        '" FROM         BD_REGION WHERE     (Name = '" & txt_Region.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeRegion = rs("Code").Value
        '===============================================
        'Dim varstatus As Integer
        ''If Radio_Stop.Checked = True Then varstatus = 1
        'If Radio_Avalible.Checked = True Then varstatus = 2


        'Dim sql2 As String
        '    sql2 = "INSERT INTO St_CustomerData (Compny_Code, Customer_Code,Customer_AccountNo,Customer_AccountNoGroup,Customer_Name,Customer_Type,Customer_Religion,Customer_NationalID,Customer_Address,Customer_Phon1,Customer_Phon2,Customer_Website,Customer_Email,Customer_Notes,Code_Region,Customer_Creditlimit,Customer_Flag) " & _
        '      '" values  ('" & VarCodeCompny & "' ,'" & txt_Code.Text & "','" & txt_AccountNo.Text & "','" & varcodeaccountgroup & "','" & txt_name.Text & "','" & com_type.Text & "','" & com_Religion.Text & "','" & txt_NationalID.Text & "','" & txt_Addres.Text & "','" & txt_Phone1.Text & "','" & txt_Phone2.Text & "','" & txt_Website.Text & "','" & txt_Email.Text & "','" & txt_Notes.Text & "','" & varcodeRegion & "','" & txt_Creditlimit.Text & "','" & varstatus & "')"
        'rs = Cnn.Execute(sql2)
        'MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'clear()
        'last_Data()
        'Search()
        'Find()
        'End If
    End Sub
    Sub Find()
        'On Error Resume Next


        ''sql = "  SELECT TOP (100) PERCENT Customer_Code, Customer_Name FROM     St_CustomerData WHERE  (Compny_Code = '" & VarCodeCompny & "') ORDER BY Customer_Code "

        'sql = "SELECT        Vw_Emp.Emp_Code, Vw_Emp.Emp_Name " & _
        '" FROM            Emp_employees INNER JOIN " & _
        '"                         Vw_Emp ON Emp_employees.Emp_Code = Vw_Emp.Emp_Code INNER JOIN " & _
        ' "                        St_CostCenterLv3Link_Salse ON Emp_employees.Emp_Code_Dirctorat = St_CostCenterLv3Link_Salse.Code_Diractorat "

        sql = "  SELECT        dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name FROM            dbo.Emp_employees INNER JOIN " & _
      "              dbo.St_CostCenterLv3Link_Salse ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.St_CostCenterLv3Link_Salse.Code_Diractorat AND " & _
       "  dbo.Emp_employees.Compny_Code = dbo.St_CostCenterLv3Link_Salse.Compny_Code "

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
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(0).Width = "20"
            GridView1.Columns(1).Width = "150"
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
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(0).Width = "20"
            GridView1.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        clear()
        ''End If
    End Sub

    Sub Find_ONCustomer()
        'On Error Resume Next


        sql = "  SELECT         St_CustomerData.Customer_Code, St_CustomerData.Customer_Name, BD_REGION.Name, St_SalseOnCustomer.DateAdd" & _
" FROM            St_CustomerData INNER JOIN " & _
  "                       St_SalseOnCustomer ON St_CustomerData.Customer_Code = St_SalseOnCustomer.Code_Customer INNER JOIN " & _
   "                      BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
    "    WHERE(St_SalseOnCustomer.CodeSalse = '" & txt_SalseNo.Text & "')  "



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
            GridView3.Columns(0).Caption = "كود العميل"
            GridView3.Columns(1).Caption = "أسم العميل"
            GridView3.Columns(2).Caption = "المنطقة"
            GridView3.Columns(3).Caption = "تاريخ الاضافة"
            GridView3.Columns(0).Width = "20"
            GridView3.Columns(1).Width = "150"
            GridView3.Columns(2).Width = "150"
            GridView3.Columns(3).Width = "100"
            GridView3.Columns(2).AppearanceCell.BackColor = Color.DarkGray
            GridView3.Columns(2).AppearanceCell.ForeColor = Color.Red

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
            GridView3.Columns(0).Caption = "كود العميل"
            GridView3.Columns(1).Caption = "أسم العميل"
            GridView3.Columns(2).Caption = "المنطقة"
            GridView3.Columns(3).Caption = "تاريخ الاضافة"
            GridView3.Columns(0).Width = "20"
            GridView3.Columns(1).Width = "150"
            GridView3.Columns(2).Width = "150"
            GridView3.Columns(3).Width = "100"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        clear()
        ''End If
    End Sub
    Private Sub Frm_delegatesInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_CustomerAll()
        Find()
    End Sub
    Sub find_CustomerAll()
        Dim sql2 As String
        '     sql2 = "select    St_CustomerData.Customer_Code, St_CustomerData.Customer_Name,BD_REGION.Name " & _
        '"                 " & _
        '" FROM     St_CustomerData LEFT OUTER JOIN " & _
        '"                  Vw_LookupAccountLv2 ON St_CustomerData.Customer_AccountNoGroup = Vw_LookupAccountLv2.code LEFT OUTER JOIN " & _
        '"                  BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
        '"        WHERE(St_CustomerData.Compny_Code = '" & VarCodeCompny & "') " & _
        '" ORDER BY St_CustomerData.Customer_Code "


        sql2 = "    SELECT        TOP (100) PERCENT dbo.St_CustomerData.Customer_Code, dbo.St_CustomerData.Customer_Name, dbo.BD_REGION.Name " & _
    " FROM            dbo.St_CustomerData INNER JOIN " & _
    "                         dbo.BD_REGION ON dbo.St_CustomerData.Code_Region = dbo.BD_REGION.Code AND dbo.St_CustomerData.Compny_Code = dbo.BD_REGION.Compny_Code " & _
    " WHERE        (dbo.St_CustomerData.Compny_Code = '" & VarCodeCompny & "') " & _
    " ORDER BY dbo.St_CustomerData.Customer_Code "


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
            GridControl4.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView4.Columns(0).Caption = "كود العميل"
            GridView4.Columns(1).Caption = "أسم العميل"
            GridView4.Columns(2).Caption = "المنطقة"


            GridView4.Columns(0).Width = "25"
            GridView4.Columns(1).Width = "150"
            GridView4.Columns(2).Width = "100"



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
            GridControl4.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView4.Columns(0).Caption = "كود العميل"
            GridView4.Columns(1).Caption = "أسم العميل"
            GridView4.Columns(2).Caption = "المنطقة"


            GridView4.Columns(0).Width = "50"
            GridView4.Columns(1).Width = "200"
            GridView4.Columns(2).Width = "100"





            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_SalseNo.Text = value
        txt_name.Text = value2
        Find_ONCustomer()
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        If Len(txt_SalseNo.Text) = 0 Then MsgBox("من فضلك ادخل المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        Dim value = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))


        Dim dd As DateTime = Now
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")


        sql = "INSERT INTO St_SalseOnCustomer (CodeSalse, Code_Customer,DateAdd,Compny_Code) " & _
    " values  (N'" & txt_SalseNo.Text & "' ,N'" & value & "',N'" & vardate1 & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)


        Find_ONCustomer()

        'MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub
End Class