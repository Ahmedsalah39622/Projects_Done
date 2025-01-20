Imports System.Data.OleDb

Public Class Frm_OrderData
    Public sizeItem As Double

    Dim Varitem, varGM, VarG1, VarG2, varNoBarcode, varNoBarcode2 As String
    Dim varSubStores As Integer
    Dim vartypeinvoice, varmaxcount, varmaxser, varmaxline, varcountbarcode As Integer
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varflagazn, VarMove1 As Integer
    Dim varcodeExitem As String

    Dim txflg As Integer
    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim VarCustomerName As String
    Dim varID, varID2 As Integer

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        vartable = "Vw_Lookup_SalseOrder22"
        VarOpenlookup = 24
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_detils()
        find_hedar()

        find_detalis()
        find_OrderNo_Condation()
        find_OrderNo_Condation_Tslem()


     
        
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "RO0000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "RO0000" + "1"


        End If
    End Sub


    Sub find_hedar()
        On Error Resume Next
        Dim varstatus As String

        sql = " SELECT       dbo.TB_Header_OrderItem.Flag_tax, dbo.TB_Header_OrderItem.CountDay, dbo.TB_Header_OrderItem.FileCustomer, dbo.TB_Header_OrderItem.Order_Ser, dbo.TB_Header_OrderItem.Order_NO, dbo.St_CustomerData.Customer_Name, " & _
        "                         dbo.Emp_employees.Emp_Name, dbo.TB_Header_OrderItem.Customer_No, dbo.TB_Header_OrderItem.Salse_No, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Header_OrderItem.Compny_Code,  " & _
        "        dbo.TB_Header_OrderItem.Status_Order, dbo.TB_Header_OrderItem.Abrove_Customer, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.TB_Header_OrderItem.No_PriceList , dbo.TB_Header_OrderItem.Notes, dbo.TB_Header_OrderItem.PAO_NO " & _
        " FROM            dbo.TB_Header_OrderItem LEFT OUTER JOIN " & _
        "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
        "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo " & _
        " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Order_NO = '" & Com_InvoiceNo2.Text & "') "





        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            VarPAO_NO = Trim(rs("PAO_NO").Value)
            Com_InvoiceNo.Text = Trim(rs("Order_Ser").Value)
            VarMove1 = Trim(rs("Order_Ser").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_NO").Value)
            txt_NoOrder2.Text = Trim(rs("Order_NO").Value)
            txt_NoOrder3.Text = Trim(rs("Order_NO").Value)
            txt_date.Text = Trim(rs("Order_Date").Value)
            txt_AccountNo.Text = Trim(rs("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs("Customer_Name").Value)
            txt_CodeSalse.Text = Trim(rs("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs("Emp_Name").Value)
            txt_NoPrice.Text = Trim(rs("No_PriceList").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            varstatus = Trim(rs("Status_Order").Value)
            txt_countDay.Text = Trim(rs("CountDay").Value)
            If Trim(rs("flag_tax").Value) = 0 Then RadioButton2.Checked = True
            If Trim(rs("flag_tax").Value) = 1 Then RadioButton6.Checked = True
            If Trim(rs("flag_tax").Value) = 2 Then RadioButton7.Checked = True

            txt_nameCustomerCompny.Text = Trim(rs("NameCustomer_Compny").Value)
            If rs("Abrove_Customer").Value = 0 Then RadioButton4.Checked = True
            If rs("Abrove_Customer").Value = 1 Then RadioButton5.Checked = True

            'txt_OpenFile.Text = Trim(rs("FileCustomer").Value)
        End If

        If txt_NoPrice.Text <> "" Then
            txt_Qty.Enabled = False : Com_Unit.Enabled = False : txt_PriceUnit.Enabled = False : txt_total.Enabled = False
            SimpleButton5.Enabled = False
            SimpleButton8.Enabled = False
            SimpleButton7.Enabled = False
            SimpleButton9.Enabled = False
            RadioButton2.Enabled = False
            RadioButton6.Enabled = False
            RadioButton7.Enabled = False
        End If
        If txt_NoPrice.Text = "" Then
            txt_Qty.Enabled = True : Com_Unit.Enabled = True : txt_PriceUnit.Enabled = True : txt_total.Enabled = True
            SimpleButton5.Enabled = True
            SimpleButton8.Enabled = True
            SimpleButton7.Enabled = True
            SimpleButton9.Enabled = True
            RadioButton2.Enabled = True
            RadioButton6.Enabled = True
            RadioButton7.Enabled = True
        End If



    End Sub
    Sub find_hedar2()
        On Error Resume Next
        Dim varstatus As String

        sql = " SELECT       dbo.TB_Header_OrderItem.Flag_tax, dbo.TB_Header_OrderItem.CountDay, dbo.TB_Header_OrderItem.FileCustomer, dbo.TB_Header_OrderItem.Order_Ser, dbo.TB_Header_OrderItem.Order_NO, dbo.St_CustomerData.Customer_Name, " & _
        "                         dbo.Emp_employees.Emp_Name, dbo.TB_Header_OrderItem.Customer_No, dbo.TB_Header_OrderItem.Salse_No, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Header_OrderItem.Compny_Code,  " & _
        "        dbo.TB_Header_OrderItem.Status_Order, dbo.TB_Header_OrderItem.Abrove_Customer, dbo.TB_Header_OrderItem.NameCustomer_Compny " & _
        " FROM            dbo.TB_Header_OrderItem LEFT OUTER JOIN " & _
        "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code LEFT OUTER JOIN " & _
        "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo " & _
        " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Order_Ser = '" & Com_InvoiceNo.Text & "') "





        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Order_Ser").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_NO").Value)
            txt_NoOrder2.Text = Trim(rs("Order_NO").Value)
            txt_NoOrder3.Text = Trim(rs("Order_NO").Value)
            txt_date.Text = Trim(rs("Order_Date").Value)
            txt_AccountNo.Text = Trim(rs("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs("Customer_Name").Value)
            txt_CodeSalse.Text = Trim(rs("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs("Emp_Name").Value)
            'txt_Notes.Text = Trim(rs("Notes").Value)
            varstatus = Trim(rs("Status_Order").Value)
            txt_countDay.Text = Trim(rs("CountDay").Value)
            If Trim(rs("flag_tax").Value) = 0 Then RadioButton2.Checked = True
            If Trim(rs("flag_tax").Value) = 1 Then RadioButton6.Checked = True
            If Trim(rs("flag_tax").Value) = 2 Then RadioButton7.Checked = True

            txt_nameCustomerCompny.Text = Trim(rs("NameCustomer_Compny").Value)
            If rs("Abrove_Customer").Value = 0 Then RadioButton4.Checked = True
            If rs("Abrove_Customer").Value = 1 Then RadioButton5.Checked = True

            txt_OpenFile.Text = Trim(rs("FileCustomer").Value)
        End If



    End Sub
    Sub clear()
        txt_NoPrice.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")
        txt_CodeSalse.Text = ""
        txt_NameSalse.Text = ""
        txt_Notes.Text = ""
        txt_OpenFile.Text = ""
    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        Com_Unit.Text = ""
        txt_Qyt_avalible.Text = ""
        txt_OpenFile.Text = ""
        txt_countDay.Text = ""
        txt_PriceUnit.Text = ""
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
                "                       dbo.TB_Detils_OrderItem.Price_Unit , dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detils_OrderItem.Rat_Cur, dbo.TB_Detils_OrderItem.TotalItem , dbo.TB_Detils_OrderItem.Notes  " & _
                " FROM            dbo.TB_Detils_OrderItem INNER JOIN  " & _
                "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
                "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN  " & _
                "                         dbo.BD_Currency ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.TB_Detils_OrderItem.Rat_Cur = dbo.BD_Currency.Code  " & _
                " WHERE        (dbo.TB_Detils_OrderItem.Order_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "')  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "السعر الحالى"
        GridView6.Columns(6).Caption = "العملة"
        GridView6.Columns(7).Caption = "معامل التحويل"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "ملاحظات"

        GridView6.Columns(6).Visible = False
        GridView6.Columns(7).Visible = False

        GridView6.BestFitColumns()

        GridView6.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Mainmune.Find_NewSalseorder()


    End Sub
    Sub find_detalis2()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
                "                        dbo.TB_Detils_OrderItem.Price_Unit, dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detils_OrderItem.Rat_Cur, dbo.TB_Detils_OrderItem.TotalItem , dbo.TB_Detils_OrderItem.Notes  " & _
                " FROM            dbo.TB_Detils_OrderItem INNER JOIN  " & _
                "                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN  " & _
                "                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN  " & _
                "                         dbo.BD_Currency ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.TB_Detils_OrderItem.Rat_Cur = dbo.BD_Currency.Code  " & _
                " WHERE        (dbo.TB_Detils_OrderItem.Order_Ser = '" & Com_InvoiceNo.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "')  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "السعر الحالى"
        GridView6.Columns(6).Caption = "العملة"
        GridView6.Columns(7).Caption = "معامل التحويل"
        GridView6.Columns(8).Caption = "الاجمالى"
        GridView6.Columns(9).Caption = "ملاحظات"

        GridView6.Columns(6).Visible = False
        GridView6.Columns(7).Visible = False

        GridView6.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Mainmune.Find_NewSalseorder()


    End Sub
    Sub find_OrderDate()
        On Error Resume Next

        GridControl6.DataSource = Nothing
        GridView11.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select * from vw_FindOrderData"
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)



        GridView11.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView11.Appearance.Row.Options.UseFont = True

        GridView11.Columns(0).Caption = "رقم امر التوريد"
        GridView11.Columns(1).Caption = "التاريخ"
        GridView11.Columns(2).Caption = "اسم العميل"
        GridView11.Columns(3).Caption = "اجمالى امر التوريد"
        GridView11.Columns(4).Caption = "المندوب"
        GridView11.Columns(5).Caption = "رقم عرض السعر"
        GridView11.Columns(6).Caption = "رقم اذن الصرف"
        GridView11.Columns(7).Caption = "تاريخ الصرف"
        GridView11.Columns(8).Caption = "الموقف الضريبي"
        GridView11.Columns(9).Caption = "PAO No"


        GridView11.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub


    Sub find_Customer()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql2 = " SELECT        RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameCustomer " & _
        '" FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
        '"                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_OrderItem.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND " & _
        ' "       dbo.TB_Header_OrderItem.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        ' "       WHERE(dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') " & _
        '" GROUP BY dbo.ST_CHARTOFACCOUNT.AccountName "


        sql2 = "Select dbo.FindCustomer.Name " & _
" FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
"                         dbo.FindCustomer ON dbo.TB_Header_OrderItem.Customer_No = dbo.FindCustomer.code AND dbo.TB_Header_OrderItem.Compny_Code = dbo.FindCustomer.Compny_Code " & _
" WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '3') " & _
" GROUP BY dbo.FindCustomer.Name "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "250"


        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم العميل"

        GridView1.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'Mainmune.Find_NewSalseorder()


    End Sub


    Sub find_OrderNoByCustomer()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "  Select dbo.TB_Header_OrderItem.Order_NO, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Header_OrderItem.CountDay, dbo.TB_Header_OrderItem.Order_Ser " & _
              " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
              "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Header_OrderItem.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
              "        dbo.TB_Header_OrderItem.Customer_No = dbo.ST_CHARTOFACCOUNT.Account_No " & _
              " WHERE        (dbo.TB_Header_OrderItem.Compny_Code ='" & VarCodeCompny & "') AND (dbo.ST_CHARTOFACCOUNT.AccountName = '" & VarCustomerName & "') " & _
              " GROUP BY dbo.TB_Header_OrderItem.Order_NO , dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Header_OrderItem.CountDay, dbo.TB_Header_OrderItem.Order_Ser ORDER BY dbo.TB_Header_OrderItem.Order_Ser"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Columns(0).Width = "120"
        GridView3.Columns(1).Width = "120"
        GridView3.Columns(2).Width = "70"

        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "أمر التوريد"
        GridView3.Columns(1).Caption = "تاريخ التوريد"
        GridView3.Columns(2).Caption = "مدة التوريد"

        GridView3.Columns(3).Visible = False
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'Mainmune.Find_NewSalseorder()


    End Sub

    Sub find_OrderNo_Condation()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "   SELECT         ID ,Order_NO, Discrption     FROM dbo.Tb_CondationOrder WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & txt_NoOrder2.Text & "')"


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "350"
        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True
        GridView5.Columns(0).Caption = "م"
        GridView5.Columns(1).Caption = "أمر التوريد"
        GridView5.Columns(2).Caption = "شروط الدفع"


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Sub find_OrderNo_Condation_Tslem()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "   SELECT        NO,Order_NO, Discrption       FROM dbo.TB_CondationOrderTslem WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & txt_NoOrder3.Text & "')"


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)

        GridView9.Columns(0).Width = "100"
        GridView9.Columns(1).Width = "100"
        GridView9.Columns(2).Width = "350"

        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)
        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "م"
        GridView9.Columns(1).Caption = "أمر التوريد"
        GridView9.Columns(2).Caption = "شروط التسليم"



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VarOpenlookup2 = 23
        varcode_form = 23
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        find_customer2()
        If txt_NoPrice.Text.Trim = "" Then
            find_salseByCustomer()
        End If
    End Sub


    Sub find_salseByPriceList()
        sql = "SELECT        dbo.Emp_employees.Emp_Code, dbo.Emp_employees.Emp_Name, dbo.TB_Header_PriceListCustomer.Salse_No, dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo" & _
" FROM            dbo.Emp_employees INNER JOIN " & _
"                         dbo.TB_Header_PriceListCustomer ON dbo.Emp_employees.Emp_Code = dbo.TB_Header_PriceListCustomer.Salse_No AND dbo.Emp_employees.Compny_Code = dbo.TB_Header_PriceListCustomer.Compny_Code" & _
" WHERE        (dbo.TB_Header_PriceListCustomer.Ser_InvoiceNo =" & txt_NoPrice.Text & ")"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_CodeSalse.Text = rs("Salse_No").Value : txt_NameSalse.Text = rs("Emp_Name").Value

    End Sub
    Sub find_taxFlg()
        sql = "SELECT        flagtax, Ser_InvoiceNo FROM            dbo.TB_Header_PriceListCustomer WHERE        (Ser_InvoiceNo = '" & txt_NoPrice.Text & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txflg = rs("flagtax").Value
            If txflg = 0 Then
                RadioButton6.Checked = False
                RadioButton2.Checked = True
            Else
                RadioButton6.Checked = True
                RadioButton2.Checked = False
            End If
        End If

    End Sub
    Sub find_salseByCustomer()
        If txt_AccountNo.Text = "" Then Exit Sub
        sql = "      SELECT        dbo.St_CustomerData.Customer_AccountNo, dbo.St_CustomerData.Salse_No, dbo.Emp_employees.Emp_Name " & _
      "FROM            dbo.St_CustomerData INNER JOIN " & _
      "                         dbo.Emp_employees ON dbo.St_CustomerData.Compny_Code = dbo.Emp_employees.Compny_Code AND dbo.St_CustomerData.Salse_No = dbo.Emp_employees.Emp_Code " & _
      "        WHERE(dbo.St_CustomerData.Customer_AccountNo = '" & txt_AccountNo.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_CodeSalse.Text = rs("Salse_No").Value : txt_NameSalse.Text = rs("Emp_Name").Value

    End Sub
    Sub find_customer2()
        On Error Resume Next
        sql = "  SELECT        Compny_Code, Customer_Code, Customer_Name, Customer_Address, Customer_Phon1      FROM dbo.St_CustomerData WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Customer_AccountNo = '" & txt_AccountNo.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then txt_AddressCustomer.Text = rs2("Customer_Address").Value : txt_Phone.Text = rs2("Customer_Phon1").Value Else txt_AddressCustomer.Text = "" : txt_Phone.Text = ""

    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VarOpenlookup3 = 24
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من ادخل فضلك المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من ادخل فضلك العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        varcode_form = 25
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
        fin_qyt_avalible()
        'Else
        'vartable = "Vw_LookupPriceList"
        'VarOpenlookup = 240
        ''Frm_Lookup.MdiParent = Me
        'Frm_Lookup.Text = "بحث"
        'Frm_Lookup.ShowDialog()
        'End If

    End Sub
    Sub fin_qyt_avalible()
        On Error Resume Next
        sql = "     SELECT        *       FROM dbo.vw_Gard WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (NoItem = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance").Value, 2) Else txt_Qyt_avalible.Text = ""


    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        On Error Resume Next


        '========================================Check طلب صرف المخازن
        sql = "select * from TB_Header_OrderItem_Stores where Order_NO = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه طلب صرف من المخازن لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '=============================================================== Check أمر الانتاج
        sql = "select * from TB_Header_JOB_Order where Order_NO = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه أمر انتاج  لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '============================================================

        '==============================================التاكد من صرف المخازن
        sql2 = " SELECT        No_Item, Compny_Code, Order_NO     FROM dbo.TB_Detils_AznItem_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item ='" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then MsgBox("الصنف تم صرفة من المخازن لايمكن حذفه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '========================================================================


        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem  WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','22','2','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                find_detalis()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")


        End Select


        find_OrderDate()

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        On Error Resume Next
        '========================================Check طلب صرف المخازن
        'sql = "select * from TB_Header_OrderItem_Stores where Order_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه طلب صرف من المخازن لايمكن تعديلة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '=============================================================== Check أمر الانتاج
        sql = "select * from TB_Header_JOB_Order where Order_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه أمر انتاج  لايمكن تعديلة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '============================================================

        sql = "   SELECT *  FROM BD_unit    WHERE(Name = '" & Com_Unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)

        '===================================تعديل Hedar
        sql = "UPDATE  TB_Header_OrderItem  SET Notes= '" & txt_Notes.Text & "',CountDay='" & txt_countDay.Text & "', FileCustomer ='" & txt_OpenFile.Text & "',Customer_No ='" & txt_AccountNo.Text & "',Salse_No ='" & txt_CodeSalse.Text & "'  WHERE  Order_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        '==============================================================تعديل Detils
        'sql = "UPDATE  TB_Detils_OrderItem  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Notes ='" & txt_Notes.Text & "'  WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        ''======================================================================


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '============================================================

        If RadioButton2.Checked = True Then varstatus = 0
        If RadioButton6.Checked = True Then varstatus = 1
        If RadioButton7.Checked = True Then varstatus = 2

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "UPDATE  TB_Header_OrderItem   SET CountDay= '" & txt_countDay.Text & "', Customer_No ='" & txt_AccountNo.Text & "',Salse_No='" & txt_CodeSalse.Text & "', Order_Date ='" & vardateoder & "', Notes= '" & txt_Notes.Text & "', Status_Order ='" & varstatus & "'  WHERE   Order_NO ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        'sql = "INSERT INTO TB_Header_OrderItem (Order_Ser, Compny_Code,Order_NO,Order_Date,Customer_No,Salse_No,Status_Order,FileCustomer,CountDay,flag_tax) " & _
        '    " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & txt_OpenFile.Text & "','" & txt_countDay.Text & "','" & varstatus & "')"
        'Cnn.Execute(sql)



        '==============================================التاكد من صرف المخازن
        sql2 = " SELECT        No_Item, Compny_Code, Order_NO     FROM dbo.TB_Detils_AznItem_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (No_Item ='" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then MsgBox("الصنف تم صرفة من المخازن لايمكن تعديل الكميات او السعر", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        '========================================================================

        sql = "UPDATE  TB_Detils_OrderItem  SET Code_Unit = '" & varcodunit & "', No_Item ='" & txt_CodeItem.Text & "' ,Price_Unit ='" & txt_PriceUnit.Text & "',Code_Cur ='" & varcode_Cru & "',Quntity ='" & txt_Qty.Text & "',Notes ='" & txt_Notes.Text & "' , Rat_Cur ='" & txt_rat.Text & "',TotalItem ='" & Math.Round(Val(txt_PriceUnit.Text) * Val(txt_rat.Text) * Val(txt_Qty.Text), 2) & "'    WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','22','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================


        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        clear_detils()
        find_hedar()
        find_detalis()
        find_OrderDate()

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If Trim(Com_InvoiceNo.Text) = "" Then Exit Sub
        sql2 = "select * from TB_Header_OrderItem where Order_Ser  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If




        save_Order_H()
        find_Customer()

        find_hedar()

        find_detalis()
        find_OrderNo_Condation()
        find_OrderNo_Condation_Tslem()
        find_OrderDate()
        RadioButton2.Enabled = False
        RadioButton6.Enabled = False
        RadioButton7.Enabled = False
    End Sub

    Sub save_Order_H()
        On Error Resume Next

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك أختار رقم أمر التوريد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        If txt_AccountNo.Text = "" Then MsgBox("من فضلك اختار العميل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        'If txt_countDay.Text = "" Then MsgBox("من فضلك أدخل مدة التوريد بعدد الايام", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_CodeItem.Text = "" Then MsgBox("من فضلك أختار الصنف", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_Qty.Text = "" Then MsgBox("من فضلك أدخل الكمية المراد انتاجها", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_Unit.Text = "" Then MsgBox("من فضلك أختار الوحدة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_PriceUnit.Text = "" Then MsgBox("من فضلك أدخل السعر", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If com_Cru.Text = "" Then MsgBox("من فضلك أدخل العملة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub





        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")


        sql = "select * from TB_Header_OrderItem where Order_Ser  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            '    sql = "UPDATE  BillBrchsesHder  SET NumberBill = '" & vardateinvoice & "',AccountNumberSu ='" & txt_AccountNo.Text & "' WHERE NumberBill = " & Com_InvoiceNo.Text & " "
            '    rs = Cnn.Execute(sql)
        Else

            If RadioButton2.Checked = True Then varstatus = 0
            If RadioButton6.Checked = True Then varstatus = 1
            If RadioButton7.Checked = True Then varstatus = 2


            sql = "INSERT INTO TB_Header_OrderItem (Order_Ser, Compny_Code,Order_NO,Order_Date,Customer_No,Salse_No,Status_Order,FileCustomer,CountDay,flag_tax, No_PriceList,Notes) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & txt_OpenFile.Text & "','" & txt_countDay.Text & "','" & varstatus & "' , '" & txt_NoPrice.Text & "', '" & txt_Notes.Text & "')"
            Cnn.Execute(sql)

            '============================== TransactionHistoryCode
            sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','22','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
            rs2 = Cnn.Execute(sql2)
            '==============================

        End If
        'Next
        save_oderDetils()
        clear_detils()
        find_detalis()

    End Sub
    Sub save_oderDetils()
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Com_Unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '============================================================عدم تكرار الصنف على الطلبية

        sql = "Select * from TB_Detils_OrderItem  WHERE  No_Item='" & txt_CodeItem.Text & "' and   Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف موجود بنفس الرقم على الطلبية لايمكن اضافتة", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sql = "INSERT INTO TB_Detils_OrderItem (Order_Ser,Order_NO,Ex_Item,No_Item,Quntity,Code_Unit,Notes,Compny_Code,Code_Cur,Rat_Cur,TotalItem,Price_Unit,no_pricelist) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & txt_Notes.Text & "','" & VarCodeCompny & "','" & varcode_Cru & "','" & txt_rat.Text & "','" & txt_total.Text & "','" & txt_PriceUnit.Text & "','" & txt_NoPrice.Text & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        last_Data()
        clear()
        clear_detils()
        'find_hedar()
        find_detalis()
        find_OrderNo_Condation()
        find_OrderNo_Condation_Tslem()


        SimpleButton5.Enabled = True
        SimpleButton8.Enabled = True
        SimpleButton7.Enabled = True
        SimpleButton9.Enabled = True

        RadioButton2.Enabled = True
        RadioButton6.Enabled = True
        RadioButton7.Enabled = True


    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs)
        Report_SalseOrder.Show()
    End Sub



    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        Com_Unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_PriceUnit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        com_Cru.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))



        If txt_NoPrice.Text <> "" Then txt_Qty.Enabled = False : Com_Unit.Enabled = False : txt_PriceUnit.Enabled = False : txt_total.Enabled = False
        If txt_NoPrice.Text = "" Then txt_Qty.Enabled = False : Com_Unit.Enabled = True : txt_PriceUnit.Enabled = True : txt_total.Enabled = True

    End Sub

    Private Sub Frm_OrderData_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 0 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 1 'الصفحة التالية
        If e.KeyCode = Keys.F3 Then TabPane1.SelectedPageIndex = 2 'الصفحة التالية
        If e.KeyCode = Keys.F4 Then TabPane1.SelectedPageIndex = 3 'الصفحة التالية


    End Sub

    Private Sub Frm_OrderData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        fill_listunit()
        'last_Data()
        clear()
        clear_detils()

        fill_cru()
        find_Customer()
        find_OrderDate()

        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub


    Sub fill_listunit()
        Com_Unit.Items.Clear()
        sql = "SELECT     Name " & _
        " FROM         BD_Unit where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub


    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency  where Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub PdfViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Cru.SelectedIndexChanged
        Dim vardate As String


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================

        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102))"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"

        '=====================================

        txt_total.Text = Math.Round(Val(txt_Qty.Text) * Val(txt_PriceUnit.Text) * Val(txt_rat.Text) * sizeItem, 2)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Frm_Cust.MdiParent = Mainmune
        Frm_Cust.Show()
    End Sub

    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs) Handles Cmd_OpenFile.Click
        Dim OpenFileDialog As New OpenFileDialog

        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "PDF Files (*.pdf) |*.pdf|All Files (*.*)|*.*"

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

            If txt_OpenFile.Text = "" Then
                MessageBox.Show("قم بأختيار PAO")
            Else
                ' Directions For Upload Solution
                Dim Dir As String = "C:"
                Dim Dir1 As String = Dir + "\" + "UploadFiles"
                Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
                Dim Dir3 As String = Dir2 + "\" + txt_OpenFile.Text
                ' Get Folder Path UploadFiles
                If (Not System.IO.Directory.Exists(Dir1)) Then
                    System.IO.Directory.CreateDirectory(Dir1)
                End If
                ' Get Folder Path أوامر التوريد
                If (Not System.IO.Directory.Exists(Dir2)) Then
                    System.IO.Directory.CreateDirectory(Dir2)
                End If
                ' Get Folder Path كود أمر التوريد
                If (Not System.IO.Directory.Exists(Dir3)) Then
                    System.IO.Directory.CreateDirectory(Dir3)
                End If
                ' Copy File To New Path
                My.Computer.FileSystem.CopyFile(OpenFileDialog.FileName, Dir3 + "\" + OpenFileDialog.SafeFileName, overwrite:=False)
                MessageBox.Show("تم حفظ الملف بنجاح")
            End If

            'Dim FileName As String = OpenFileDialog.FileName
            'MessageBox.Show(OpenFileDialog.FileName)
            'txt_OpenFile.Text = OpenFileDialog.FileName
            'Process.Start(OpenFileDialog.FileName)
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'Process.Start(txt_OpenFile.Text)
        If txt_OpenFile.Text = "" Then
            MessageBox.Show("قم بأختيار PAO ")
        Else
            ' Directions For Upload Solution
            Dim Dir As String = "C:"
            Dim Dir1 As String = Dir + "\" + "UploadFiles"
            Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
            Dim Dir3 As String = Dir2 + "\" + txt_OpenFile.Text
            ' Get Folder Path UploadFiles
            If (Not System.IO.Directory.Exists(Dir1)) Then
                System.IO.Directory.CreateDirectory(Dir1)
            End If
            ' Get Folder Path أوامر التوريد
            If (Not System.IO.Directory.Exists(Dir2)) Then
                System.IO.Directory.CreateDirectory(Dir2)
            End If
            ' Get Folder Path كود أمر التوريد
            If (Not System.IO.Directory.Exists(Dir3)) Then
                System.IO.Directory.CreateDirectory(Dir3)
            End If
            Process.Start(Dir3 + "\")
            loadlistbox()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        sql = "UPDATE  TB_Header_OrderItem  SET Abrove_Customer  ='" & 1 & "'   WHERE  Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        MsgBox("تم موافقة العميل على الطلبية", MsgBoxStyle.Information, "Css Solution Software Module")

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        VarCustomerName = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        find_OrderNoByCustomer()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

        clear_detils()

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        find_hedar()
        find_detalis()
        find_OrderNo_Condation()
        find_OrderNo_Condation_Tslem()
    End Sub





    Private Sub cmd_Print_Click_1(sender As Object, e As EventArgs) Handles cmd_Print.Click
        'Report_SalseOrder.Show()
        Rpt_Reqest_Order.Close()
        'Rpt_Reqest_Order.MdiParent = Mainmune
        If CheckBox2.Checked = True Then vardisplayReport = 320
        If CheckBox1.Checked = True Then vardisplayReport = 321

        Rpt_Reqest_Order.Text = "أمر توريد"
        Rpt_Reqest_Order.Show()
    End Sub

    Private Sub txt_PriceUnit_TextChanged(sender As Object, e As EventArgs) Handles txt_PriceUnit.TextChanged
        txt_total.Text = Math.Round(Val(txt_Qty.Text) * Val(txt_PriceUnit.Text) * Val(txt_rat.Text) * sizeItem, 2)
    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs) Handles txt_Qty.TextChanged
        txt_total.Text = Math.Round(Val(txt_Qty.Text) * Val(txt_PriceUnit.Text) * Val(txt_rat.Text) * sizeItem, 2)

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        vartable = "BD_CondationOrder"
        VarOpenlookup = 41
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()


    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        vartable = "BD_CondationTaslem"
        VarOpenlookup = 42
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        txt_NoOrder2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        txt_Discrption2.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        varID = GridView5.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
    End Sub

    Private Sub SimpleButton17_Click(sender As Object, e As EventArgs) Handles SimpleButton17.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Tb_CondationOrder  WHERE Order_NO = '" & txt_NoOrder2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_OrderNo_Condation()

        End Select
    End Sub



    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_CondationOrderTslem  WHERE Order_NO = '" & txt_NoOrder3.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_OrderNo_Condation_Tslem()

        End Select
    End Sub

    Private Sub GridControl5_DoubleClick(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle
        txt_NoOrder3.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(1))
        txt_Discrption3.Text = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(2))
        varID2 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(0))
    End Sub


    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        If Len(txt_NoOrder3.Text) = 0 Then MsgBox("من فضلك أختار رقم أمر التوريد من أختيار أمر التوريد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        sql = "INSERT INTO TB_CondationOrderTslem (Order_NO, Compny_Code,Discrption) " & _
        " values  ('" & txt_NoOrder3.Text & "' ,'" & VarCodeCompny & "','" & txt_Discrption3.Text & "')"
        Cnn.Execute(sql)
        MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        txt_Discrption3.Text = ""

        find_OrderNo_Condation_Tslem()

    End Sub


    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        If Len(txt_NoOrder2.Text) = 0 Then MsgBox("من فضلك أختار رقم أمر التوريد من أختيار أمر التوريد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        sql = "INSERT INTO Tb_CondationOrder (Order_NO, Compny_Code,Discrption) " & _
          " values  ('" & txt_NoOrder2.Text & "' ,'" & VarCodeCompny & "','" & txt_Discrption2.Text & "')"
        Cnn.Execute(sql)
        MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        txt_Discrption2.Text = ""
        find_OrderNo_Condation()
    End Sub



    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click



        '========================================Check طلب صرف المخازن
        sql = "select * from TB_Header_AznItem_Stores where Order_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه اذن صرف من المخازن لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '=============================================================== Check أمر الانتاج
        'sql = "select * from TB_Header_JOB_Order where Order_NO = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه أمر انتاج  لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '============================================================





        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes




                sql = "Delete TB_Detils_OrderItem  WHERE    Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                sql = "Delete TB_Header_OrderItem  WHERE    Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','22','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
                clear()

                find_hedar()

                find_detalis()

        End Select
    End Sub





    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs)

       
    End Sub



    Private Sub SimpleButton19_Click_2(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        sql = "  SELECT        Min(Order_Ser) AS Min   FROM dbo.TB_Header_OrderItem GROUP BY Compny_Code  HAVING(Compny_Code = 2)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarMove1 = rs("Min").Value
        Com_InvoiceNo.Text = VarMove1
        find_hedar2()
        find_detalis2()

    End Sub

    Private Sub SimpleButton21_Click_1(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        clear_detils()
        VarMove1 = VarMove1 - 1
        Com_InvoiceNo.Text = VarMove1
        find_hedar2()
        find_detalis2()
    End Sub

    Private Sub SimpleButton20_Click_1(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        clear_detils()
        VarMove1 = VarMove1 + 1
        Com_InvoiceNo.Text = VarMove1
        find_hedar2()
        find_detalis2()
    End Sub

    Private Sub SimpleButton22_Click_1(sender As Object, e As EventArgs) Handles SimpleButton22.Click
        sql = "  SELECT        MAX(Order_Ser) AS Max   FROM dbo.TB_Header_OrderItem GROUP BY Compny_Code  HAVING(Compny_Code = 2)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarMove1 = rs("max").Value
        Com_InvoiceNo.Text = VarMove1
        find_hedar2()
        find_detalis2()
    End Sub


    Private Sub SimpleButton24_Click(sender As Object, e As EventArgs) Handles SimpleButton24.Click
        'Find_All()
        'GridView11.BestFitColumns()

        GridView11.ShowPrintPreview()
    End Sub



    Private Sub Cmd_Save2_PriceList_Click(sender As Object, e As EventArgs) Handles Cmd_Save2_PriceList.Click



        '================================اضافة فى امر التوريد
        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك أختار رقم أمر التوريد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub
        If txt_AccountNo.Text = "" Then MsgBox("من فضلك اختار العميل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        If RadioButton2.Checked = True Then varstatus = 0
        If RadioButton6.Checked = True Then varstatus = 1
        If RadioButton7.Checked = True Then varstatus = 2

        'sql2 = " select No_PriceList from TB_Header_OrderItem where No_PriceList = '" & txt_NoPrice.Text & "'  "
        'Cnn.Execute(sql2)
        'If rs2.EOF = False Then MsgBox("من فضلك عرض السعر موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub

        sql = "Select * from TB_Header_OrderItem     "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            sql = "   SELECT MAX(PAO_NO) AS PAO_Max          FROM dbo.TB_Header_OrderItem HAVING (MAX(PAO_NO) IS NOT NULL)"
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then VarPAO_NO = rs3("PAO_Max").Value + 1
        Else
            last_PAO()
        End If



        sql = "INSERT INTO TB_Header_OrderItem (Order_Ser, Compny_Code,Order_NO,Order_Date,Customer_No,Salse_No,Status_Order,FileCustomer,CountDay,flag_tax , No_PriceList, Notes,PAO_NO) " & _
                  " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & txt_OpenFile.Text & "','" & txt_countDay.Text & "','" & varstatus & "' , '" & txt_NoPrice.Text & "' , '" & txt_Notes.Text & "','" & VarPAO_NO & "')"
        Cnn.Execute(sql)

        '=============================================== اضافة تفصيلى فى امر التوريد


        sql = "SELECT  *  FROM            dbo.TB_Detalis_PriceListCustomer  where Ser_InvoiceNo ='" & txt_NoPrice.Text & "' and  Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        Do While Not rs.EOF

            sql2 = "INSERT INTO TB_Detils_OrderItem (Order_Ser,Order_NO,Ex_Item,No_Item,Quntity,Code_Unit,Notes,Compny_Code,Code_Cur,Rat_Cur,TotalItem,Price_Unit,No_PriceList,PAO_NO) " & _
      " values  ('" & Com_InvoiceNo.Text & "' ,'" & Com_InvoiceNo2.Text & "','" & rs("Ex_Item").Value & "','" & rs("No_Item").Value & "','" & rs("Quntity").Value & "','" & rs("Code_Unit").Value & "','" & txt_Notes.Text & "','" & VarCodeCompny & "','" & rs("Code_cur").Value & "','" & rs("Rat_Invoice").Value & "','" & rs("Total_Item").Value & "','" & rs("Price_Item").Value & "','" & txt_NoPrice.Text & "','" & VarPAO_NO & "')"
            Cnn.Execute(sql2)



            rs.MoveNext()
        Loop
        MsgBox("تم انشاء رقم PAO  " + " " + Str(VarPAO_NO), MsgBoxStyle.Information)
        '============================== TransactionHistoryCode
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','22','13','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_InvoiceNo2.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        find_hedar()

        find_detalis()
        find_OrderDate()

        SimpleButton5.Enabled = False
        SimpleButton8.Enabled = False
        SimpleButton7.Enabled = False
        SimpleButton9.Enabled = False

        RadioButton2.Enabled = False
        RadioButton6.Enabled = False
        RadioButton7.Enabled = False

    End Sub
    Sub last_PAO()
        sql = " SELECT MAX(PAONO_SN) AS PAO_Max FROM     dbo.SettingNo_PAO"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarPAO_NO = rs("PAO_Max").Value
    End Sub
    Private Sub Cmd_OpenPriceList_Click(sender As Object, e As EventArgs) Handles Cmd_OpenPriceList.Click
        'vw_PriceListLookup

        vartable = "vw_PriceListLookup"
        VarOpenlookup = 1616
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        If txt_NoPrice.Text.Trim = "" Then Exit Sub
        find_salseByPriceList()
    End Sub

    Private Sub GridControl6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl6_Click_1(sender As Object, e As EventArgs) Handles GridControl6.Click

    End Sub

    Private Sub GridControl6_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl6.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        Dim value2 = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(0))

        Com_InvoiceNo2.Text = value2
        txt_OpenFile.Text = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(9))
        find_hedar()
        find_detalis()
        loadlistbox()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then CheckBox2.Checked = False
    End Sub

    Private Sub Com_Unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Unit.SelectedIndexChanged

    End Sub

    Private Sub Com_Unit_TabIndexChanged(sender As Object, e As EventArgs) Handles Com_Unit.TabIndexChanged
        fill_Unit2()
    End Sub
    Sub fill_Unit2()
        'If Com_NameItem.Text = "" Then MsgBox("أختار الصنف من فضلك", MsgBoxStyle.Critical) : Exit Sub
        sql = "   SELECT *    FROM BD_Item   WHERE(Name = '" & txt_NameItem.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = rs("Code").Value
        '==================================================

        Com_Unit.Items.Clear()

        sql = " SELECT Name FROM     vw_AllUnit where  code ='" & varcodeitem & "'   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    
    Private Sub Cmd_PrintPAO_Click(sender As Object, e As EventArgs) Handles Cmd_PrintPAO.Click
        vardisplayReport = 322
        Rpt_Reqest_Order.Text = "PAO"
        Rpt_Reqest_Order.Show()
        Frm_PrintPAOFinal.Show()
        Frm_PrintPAOFinal2.Show()
    End Sub

    Private Sub ListBoxControl1_Click(sender As Object, e As EventArgs) Handles ListBoxControl1.Click
      
    End Sub

    Private Sub ListBoxControl1_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxControl1.DoubleClick
        Dim Dir As String = "C:"
        Dim Dir1 As String = Dir + "\" + "UploadFiles"
        Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
        Dim Dir3 As String = Dir2 + "\" + txt_OpenFile.Text
        Dim Dir4 As String = Trim(Dir3) + "\" + ListBoxControl1.Text
        Me.PdfViewer1.LoadDocument(Dir4)
    End Sub

    Private Sub ListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl1.SelectedIndexChanged

    End Sub
    Sub loadlistbox()
        Dim Dir As String = "C:"
        Dim Dir1 As String = Dir + "\" + "UploadFiles"
        Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
        Dim Dir3 As String = Dir2 + "\" + txt_OpenFile.Text
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Dir3)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        ListBoxControl1.Items.Clear()
        For Each dra In diar1
            ListBoxControl1.Items.Add(dra)
        Next
    End Sub

    
   
    Private Sub cmd_Delete_Click(sender As Object, e As EventArgs) Handles cmd_Delete.Click
        On Error Resume Next
        Dim Dir As String = "C:"
        Dim Dir1 As String = Dir + "\" + "UploadFiles"
        Dim Dir2 As String = Dir1 + "\" + "SupplyOrders"
        Dim Dir3 As String = Dir2 + "\" + txt_OpenFile.Text + "\" + ListBoxControl1.Text

        System.IO.File.Delete(Dir3)

        MessageBox.Show("تم حذف الملف بنجاح")
        loadlistbox()
    End Sub
End Class