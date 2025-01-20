Imports System.Data.OleDb

Public Class Frm_Report_Invintory2021
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If vardisplayReport4 = 1 Then Create_rased() : find_Rased_N() : OpenReport() : GridView1.BestFitColumns() 'الاصناف السالبة
        If vardisplayReport4 = 2 Then find_ValueInvintory() : OpenReport() : GridView1.BestFitColumns() 'المخزون كمية وقيمة بالارصدة
        If vardisplayReport4 = 3 Then find_Gard() : OpenReport() : GridView1.BestFitColumns() 'تقرير مجمع المخازن بالارصدة بتحويلات معامل التحويل
        If vardisplayReport4 = 4 Then Create_rased() : find_Add_Invintory() : OpenReport() : GridView1.BestFitColumns() 'تقرير الاصناف المضافة
        If vardisplayReport4 = 5 Then Create_rased() : find_sarf_Invintory() : OpenReport() : GridView1.BestFitColumns() 'تقرير الاصناف المنصرفة
        If vardisplayReport4 = 6 Then Create_rased() : find_Invintory_MinItem() : OpenReport() : GridView1.BestFitColumns() 'تقرير الاصناف حد الطلب
        If vardisplayReport4 = 7 Then find_Invintory_Prcheses() : OpenReport() : GridView1.BestFitColumns() 'تقرير الاصناف المشتراةشاملة الفواتير
        If vardisplayReport4 = 8 Then find_Invintory_Prcheses2() : OpenReport() : GridView1.BestFitColumns() ' غير شاملة تقرير الاصناف المشتراة
        If vardisplayReport4 = 9 Then find_Invintory_rented() : OpenReport() : GridView1.BestFitColumns() ' تقرير الاصناف المرتجعة غير شاملة الفواتير
        If vardisplayReport4 = 10 Then find_Invintory_rented_2() : OpenReport() : GridView1.BestFitColumns() ' تقرير الاصناف المرتجعة  شاملة الفواتير

    End Sub
    Sub Cerate_Day_Invintory()
        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=============================================
        sql = " DROP VIEW dbo.vw_Day_Invintory"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = " CREATE VIEW vw_Day_Invintory AS SELECT        dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name AS NameItem, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1, " & _
                "                         dbo.BD_Unit.Name AS UnitName, SUM(dbo.Statement_OfItem.Export) AS Wared, SUM(dbo.Statement_OfItem.Import) AS Mnsrf, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import)  " & _
                "                         AS balance, dbo.Statement_OfItem.Compny_Code, dbo.BD_Item.MinOrderItem " & _
                " FROM            dbo.Statement_OfItem INNER JOIN " & _
                "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Item ON dbo.Statement_OfItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_Item.Code INNER JOIN " & _
                "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
                "                         dbo.BD_GroupItem1 ON dbo.BD_Item.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_Item.Compny_Code = dbo.BD_GroupItem1.Compny_Code INNER JOIN " & _
                "                         dbo.TB_TypeBill ON dbo.Statement_OfItem.TypeD = dbo.TB_TypeBill.Code INNER JOIN " & _
                "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
                " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                " GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name, dbo.BD_Unit.Name,  " & _
                "        dbo.Statement_OfItem.Compny_Code, dbo.BD_Item.MinOrderItem " & _
                "        HAVING(dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql2)


    End Sub

    Sub find_Gard()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        sql = " DROP VIEW dbo.vw_all_Gard"
        rs = Cnn.Execute(sql)


        sql2 = " CREATE VIEW vw_all_Gard AS  SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
               "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem,  " & _
               "                         dbo.BD_GROUPITEMMAIN.Name AS NG, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2, BD_Unit_1.Name AS Unit_2, dbo.Statement_OfItem.NoItem,  " & _
               "                         iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) AS ward2,  " & _
               "                         iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Mnsr2, " & _
               "  iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) -  iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2))  as Balance2, " & _
               " iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) -  iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) * dbo.BD_ITEM.ValueUnit1 as Balanc1 " & _
               " FROM            dbo.Statement_OfItem INNER JOIN " & _
               "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
               "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
               "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
               "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.BD_ITEM.Unit2 = BD_Unit_1.Code LEFT OUTER JOIN " & _
               "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
               " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME,  '" & vardate2 & "', 102)) and BD_ITEM.Name like '%" & txt_nameitem.Text & "%' " & _
               " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2,  " & _
               " BD_Unit_1.Name, dbo.Statement_OfItem.NoItem "
        rs = Cnn.Execute(sql2)

        'sql2 = "  SELECT        Name, NoItem, NameItem, Unit_2, SUM(ward2) AS WardR, SUM(Mnsr2) AS MnsrfR, SUM(ward2) - SUM(Mnsr2) AS balnce     FROM dbo.vw_all_Gard GROUP BY Name, NoItem, NameItem, Unit_2 having NameItem like '%" & txt_nameitem.Text & "%' "

        sql2 = "     SELECT dbo.vw_all_Gard.Name, dbo.vw_all_Gard.Ex_Item, dbo.vw_all_Gard.NameItem, dbo.vw_all_Gard.Unit_2, SUM(dbo.vw_all_Gard.ward2) AS WardR, SUM(dbo.vw_all_Gard.Mnsr2) AS MnsrfR, SUM(dbo.vw_all_Gard.ward2) " & _
     "                  - SUM(dbo.vw_all_Gard.Mnsr2) AS balnce, BD_Unit_1.Name AS Unit1, dbo.BD_Item.ValueUnit1, round( (SUM(dbo.vw_all_Gard.ward2) - SUM(dbo.vw_all_Gard.Mnsr2)) / dbo.BD_Item.ValueUnit1,2) AS Balance2, dbo.vw_all_Gard.NG,dbo.vw_all_Gard.NoItem " & _
     " FROM     dbo.vw_all_Gard INNER JOIN " & _
     "                  dbo.BD_Item ON dbo.vw_all_Gard.NoItem = dbo.BD_Item.Code INNER JOIN " & _
     "                  dbo.BD_Unit AS BD_Unit_1 ON dbo.BD_Item.Unit1 = BD_Unit_1.Code " & _
     " where rem > 0 " & _
     " GROUP BY dbo.vw_all_Gard.Name, dbo.vw_all_Gard.Ex_Item, dbo.vw_all_Gard.NameItem, dbo.vw_all_Gard.Unit_2, BD_Unit_1.Name, dbo.BD_Item.ValueUnit1, dbo.vw_all_Gard.NG,dbo.vw_all_Gard.NoItem " & _
     " HAVING (dbo.vw_all_Gard.NameItem LIKE '%" & Trim(txt_nameitem.Text) & "%') and (dbo.vw_all_Gard.Name LIKE '%" & Trim(Com_Stores.Text) & "%') and (dbo.vw_all_Gard.NG LIKE '%" & Trim(Com_GM.Text) & "%')  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        ProgressPanel1.Visible = True
        LodingShow()

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم Ref"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة2"
        GridView1.Columns(4).Caption = "وارد"
        GridView1.Columns(5).Caption = "منصرف"
        GridView1.Columns(6).Caption = "الرصيد بالوحدة 2"
        GridView1.Columns(7).Caption = "الوحدة1"
        GridView1.Columns(8).Caption = "معامل التحويل"
        GridView1.Columns(9).Caption = "الرصيد بالوحدة 1"

        GridView1.Columns(10).Visible = False
        GridView1.Columns(11).Visible = False


        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        ProgressPanel1.Visible = False
    End Sub
    Sub fill_Stores()
        Com_Stores.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Stores  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Stores.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub fill_Branch()
        Com_Branch.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_SUBMAIN  "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Branch.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub OpenReport()

        Dim oldDate As Date
        Dim oldDay As Integer
        Dim vardate As String
        Dim vardate2, vardatetest1, vardatetest2 As String
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"




        If vardisplayReport4 = 1 Then 'الاصناف السالبة
            Dim report As New Rased_N
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Name] Like '%" & Trim(Com_Stores.Text) & "%'  and [NameItem] Like '%" & Trim(txt_nameitem.Text) & "%'  and [NG] Like '%" & Trim(Com_GM.Text) & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If
        If vardisplayReport4 = 2 Then 'قيمة المخزون
            'Dim report As New ValueStores2
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'report.X_Date1.Text = txt_date.Value
            'report.X_Date2.Text = txt_date2.Value
            'report.XrLabel29.Text = Com_Stores.Text
            'report.FilterString = "[Name] Like '%" & Trim(Com_Stores.Text) & "%'  and [NameItem] Like '%" & Trim(txt_nameitem.Text) & "%'  and [NG] Like '%" & Trim(Com_GM.Text) & "%'  "
            'report.CreateDocument()
            'DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 3 Then

            Dim report As New Gard_Item
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[NameItem] Like '%" & Trim(txt_nameitem.Text) & "%'  and [Name] Like '%" & Trim(Com_Stores.Text) & "%' and [NG] Like '%" & Trim(Com_GM.Text) & "%'    "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If vardisplayReport4 = 4 Then
            Dim report As New Invintory_Day2_Additem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Name] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' and [NG] like  '%" & Trim(Com_GM.Text) & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 5 Then
            Dim report As New Report_Test
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Name] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' and [NG] like  '%" & Trim(Com_GM.Text) & "%' and Mnsr2 <> 0  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 6 Then
            Dim report As New Invintory_MinItem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Name] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' and [NG] like  '%" & Trim(Com_GM.Text) & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 7 Then
            Dim report As New Invintory_Prcheses1
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Stores] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' and Ser_InvoiceNo IS NOT NULL  and  [Date_StoresAdd] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 8 Then
            Dim report As New Invintory_Prcheses1
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[Stores] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' AND (Ser_InvoiceNo IS NULL) and  [Date_StoresAdd] Between(" & vardatetest1 & ", " & vardatetest2 & ")   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 9 Then
            Dim report As New Invintory_RentedItem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[NameStores] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' AND (Ser_InvoiceNo IS NULL) and  [DateMoveM] Between(" & vardatetest1 & ", " & vardatetest2 & ")   "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 10 Then
            Dim report As New Invintory_RentedItem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            report.FilterString = "[NameStores] Like '%" & Trim(Com_Stores.Text) & "%'   and [NameItem] like '%" & Trim(txt_nameitem.Text) & "%' AND (Ser_InvoiceNo IS NOT NULL) and  [DateMoveM] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If
    End Sub
    Sub LodingShow()
        ''ProgressPanel ProgressPanel1 = New ProgressPanel()
        ProgressPanel1.Caption = "Loading"
        ProgressPanel1.Description = "Please wait..."
        ProgressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Default
        ProgressPanel1.Parent = Me
        'ProgressPanel1.Top = 100
        'ProgressPanel1.Left = 100
        Me.Controls.Add(ProgressPanel1)
        ProgressPanel1.Show()
        ProgressPanel1.BringToFront()
    End Sub
    Sub Create_rased()
        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        sql = " DROP VIEW dbo.vw_all_Gard"
        rs = Cnn.Execute(sql)




        sql2 = " CREATE VIEW vw_all_Gard AS  SELECT dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
    "                 ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem, dbo.BD_GROUPITEMMAIN.Name AS NG, " & _
   "                  dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2, BD_Unit_1.Name AS Unit_2, dbo.Statement_OfItem.NoItem, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2,  " & _
   "                  ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) AS ward2, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2,  " & _
   "                  ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Mnsr2, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2,  " & _
   "                  ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) - iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2)  " & _
   "                  * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Balance2, iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, " & _
   "                  ROUND(SUM(dbo.Statement_OfItem.Export), 2)) - iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2))  " & _
   "                  * dbo.BD_ITEM.ValueUnit1 AS Balanc1 " & _
   " FROM     dbo.Statement_OfItem INNER JOIN " & _
   "                  dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
   "                  dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
    "                 dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                  dbo.BD_Unit AS BD_Unit_1 ON dbo.BD_ITEM.Unit2 = BD_Unit_1.Code LEFT OUTER JOIN " & _
   "                  dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
   " WHERE  (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND BD_ITEM.Name LIKE '%%' " & _
   " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2, BD_Unit_1.Name, " & _
   "        dbo.Statement_OfItem.NoItem "



        rs = Cnn.Execute(sql2)
    End Sub
    Sub find_Rased_N()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _



        'sql2 = "  SELECT        Name, NoItem, NameItem, Unit_2, SUM(ward2) AS WardR, SUM(Mnsr2) AS MnsrfR, SUM(ward2) - SUM(Mnsr2) AS balnce     FROM dbo.vw_all_Gard GROUP BY Name, NoItem, NameItem, Unit_2 having NameItem like '%" & txt_nameitem.Text & "%' "

        sql2 = "   SELECT Name, NoItem, NG, NameItem, Unit_2, SUM(ward2) AS WardR, SUM(Mnsr2) AS MnsrfR, SUM(ward2) - SUM(Mnsr2) AS balnce " & _
   " FROM     dbo.vw_all_Gard " & _
   " GROUP BY Name, NoItem, NameItem, Unit_2, NG HAVING (SUM(ward2) - SUM(Mnsr2) < 0)  AND (Name like '%" & Com_Stores.Text & "%') AND (NameItem  like '%" & txt_nameitem.Text & "%')  AND (NG  like '%" & Com_GM.Text & "%') "



        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "المجموعة الرئيسية"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "وارد"
        GridView1.Columns(6).Caption = "منصرف"
        GridView1.Columns(7).Caption = "رصيد"

        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub find_ValueInvintory()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.TB_ChartOfAccount.Account_No_Update) as Account_No_Update , rtrim(dbo.TB_ChartOfAccount.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        sql = " DROP VIEW dbo.vw_all_Gard"
        rs = Cnn.Execute(sql)


        sql2 = " CREATE VIEW vw_all_Gard AS  SELECT        dbo.BD_Stores.Name, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, RTRIM(dbo.BD_ITEM.Name) AS NameItem, dbo.BD_Unit.Name AS UnitName, ROUND(SUM(dbo.Statement_OfItem.Export), 2) AS ward, " & _
               "                         ROUND(SUM(dbo.Statement_OfItem.Import), 2) AS Mnsrf, ROUND(ROUND(SUM(dbo.Statement_OfItem.Export), 2) - ROUND(SUM(dbo.Statement_OfItem.Import), 2), 2) AS Rem,  " & _
               "                         dbo.BD_GROUPITEMMAIN.Name AS NG, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2, BD_Unit_1.Name AS Unit_2, dbo.Statement_OfItem.NoItem,  " & _
               "                         iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Export), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Export), 2)) AS ward2,  " & _
               "                         iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Mnsr2 " & _
               " FROM            dbo.Statement_OfItem INNER JOIN " & _
               "                         dbo.BD_ITEM ON dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
               "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_ITEM.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
               "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
               "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.BD_ITEM.Unit2 = BD_Unit_1.Code LEFT OUTER JOIN " & _
               "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code " & _
               " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME,  '" & vardate2 & "', 102)) and BD_ITEM.Name like '%" & Trim(txt_nameitem.Text) & "%' " & _
               " GROUP BY dbo.BD_Stores.Name, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_Unit.Name, dbo.BD_ITEM.ValueUnit1, dbo.Statement_OfItem.Code_Unit, dbo.BD_ITEM.Unit2,  " & _
               " BD_Unit_1.Name, dbo.Statement_OfItem.NoItem "
        rs = Cnn.Execute(sql2)


        sql2 = "   SELECT * " & _
   " FROM     dbo.Vw_ValueInvintory " & _
   " where (Name like '%" & Com_Stores.Text & "%') AND (NameItem  like '%" & txt_nameitem.Text & "%')  AND (NG  like '%" & Com_GM.Text & "%') "

        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "رقم التوصيف"
        GridView1.Columns(3).Caption = "المجموعة الرئيسية"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "وارد"
        GridView1.Columns(7).Caption = "منصرف"
        GridView1.Columns(8).Caption = "رصيد"
        GridView1.Columns(9).Caption = "متوسط سعر"
        GridView1.Columns(10).Caption = "قيمة المخزون"


        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub find_Add_Invintory()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select Name,Ex_Item,NameItem,Unit_2,ward2,ValueUnit1,RasedWared,NameUnit2 from vw_all_Gard2 " & _
            " where (NameItem LIKE '%" & Trim(txt_nameitem.Text) & "%') and (Name LIKE '%" & Trim(Com_Stores.Text) & "%') and (NG LIKE '%" & Trim(Com_GM.Text) & "%')"


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        ProgressPanel1.Visible = True
        LodingShow()

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة2"
        'GridView1.Columns(4).Caption = "وارد"
        GridView1.Columns(4).Caption = "وارد"
        GridView1.Columns(5).Caption = "معامل التحويل"
        'GridView1.Columns(6).Caption = "الرصيد بالوحدة 2"
        GridView1.Columns(6).Caption = "الكمية الواردة / م التحويل"

        GridView1.Columns(7).Caption = "الوحدة 1"

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        ProgressPanel1.Visible = False
    End Sub
    Sub find_sarf_Invintory()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select Name,Ex_Item,NameItem,Unit_2,Mnsr2,ValueUnit1,RasedMnsrf,NameUnit2 from vw_all_Gard2 " & _
            " where (NameItem LIKE '%" & Trim(txt_nameitem.Text) & "%') and (Name LIKE '%" & Trim(Com_Stores.Text) & "%') and (NG LIKE '%" & Trim(Com_GM.Text) & "%') and Mnsr2 <> 0 "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        ProgressPanel1.Visible = True
        LodingShow()

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم Ref"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة2"
        GridView1.Columns(4).Caption = "منصرف"
        GridView1.Columns(5).Caption = "معامل التحويل"
        GridView1.Columns(6).Caption = "الكمية المنصرفة / م التحويل"

        GridView1.Columns(7).Caption = "الوحدة 1"




        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        ProgressPanel1.Visible = False
    End Sub
    Sub find_Invintory_Prcheses()
        'On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = " SELECT Ser_NO_StoresAdd, Date_StoresAdd, Ex_Item, NameItem, Qyt, Unit, Ser_InvoiceNo, Stores, AccountName " & _
             " FROM     dbo.Vw_OrderPrcheses_Item " & _
             " WHERE  (Date_StoresAdd >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Date_StoresAdd <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ser_InvoiceNo IS NOT NULL) and (Stores like '%" & Trim(Com_Stores.Text) & "%') AND (NameItem  like '%" & Trim(txt_nameitem.Text) & "%') "


        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الكمية المشتراة"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "فاتورة الشراء"
        GridView1.Columns(7).Caption = "المخزن"
        GridView1.Columns(8).Caption = "المورد"

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub find_Invintory_Prcheses2()
        'On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = " SELECT Ser_NO_StoresAdd, Date_StoresAdd, Ex_Item, NameItem, Qyt, Unit, Ser_InvoiceNo, Stores, AccountName " & _
             " FROM     dbo.Vw_OrderPrcheses_Item " & _
             " WHERE  (Date_StoresAdd >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Date_StoresAdd <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  (Stores like '%" & Trim(Com_Stores.Text) & "%') AND (NameItem  like '%" & Trim(txt_nameitem.Text) & "%')  AND (Ser_InvoiceNo IS NULL) "


        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الكمية المشتراة"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "فاتورة الشراء"
        GridView1.Columns(7).Caption = "المخزن"
        GridView1.Columns(8).Caption = "المورد"

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub find_Invintory_rented()
        'On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT Ser_NO_StoresAdd, DateMoveM, NameStores, Ex_Item, NameItem, Unit, Export, Ser_InvoiceNo, Name " & _
       " FROM     dbo.Vw_Rented_ItemAll " & _
       " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))   AND (Ser_InvoiceNo IS NULL)"

        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "المخزن"
        GridView1.Columns(3).Caption = "رقم Ref"
        GridView1.Columns(4).Caption = "اسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "الكمية المرتجعة"
        GridView1.Columns(7).Caption = "فاتورة المرتجع"
        GridView1.Columns(8).Caption = "العميل"

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub find_Invintory_rented_2()
        'On Error Resume Next

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "   SELECT Ser_NO_StoresAdd, DateMoveM, NameStores, NoItem, NameItem, Unit, Export, Ser_InvoiceNo, Name " & _
       " FROM     dbo.Vw_Rented_ItemAll " & _
       " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND (Ser_InvoiceNo IS NOT NULL)   "

        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الاذن"
        GridView1.Columns(1).Caption = "تاريخ الاذن"
        GridView1.Columns(2).Caption = "المخزن"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "اسم الصنف"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "الكمية المرتجعة"
        GridView1.Columns(7).Caption = "فاتورة المرتجع"
        GridView1.Columns(8).Caption = "العميل"

        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub find_Invintory_MinItem()
        'On Error Resume Next



        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        sql2 = "   SELECT NG,name,Ex_Item,NameItem,Unit_2,Balance2,NameUnit2,Balance1,MinOrderItem " & _
   " FROM     dbo.Vw_MinOrderItem " & _
   " where (Name like '%" & Com_Stores.Text & "%') AND (NameItem  like '%" & Trim(txt_nameitem.Text) & "%')  AND (NG  like '%" & Trim(Com_GM.Text) & "%') "

        rs = Cnn.Execute(sql2)

        ProgressPanel1.Visible = True
        LodingShow()


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "المجموعة"
        GridView1.Columns(1).Caption = "المخزن"
        GridView1.Columns(2).Caption = "رقم Ref"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "الوحدة 1"
        GridView1.Columns(5).Caption = "رصيد 1"
        GridView1.Columns(6).Caption = "الوحدة 2"
        GridView1.Columns(7).Caption = "رصيد 2"
        GridView1.Columns(8).Caption = "حد الطلب"



        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        ProgressPanel1.Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub Frm_Report_Invintory2021_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressPanel1.Visible = False
        fill_Branch()
        fill_Stores()
    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Com_GM_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM.ButtonClick
        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 10101022
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_GM_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM.EditValueChanged

    End Sub

    Private Sub Com_GM1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM1.ButtonClick
        vartable = "BD_GroupItem1"
        VarOpenlookup = 2020102
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_GM1_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM1.EditValueChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))


        If vardisplayReport4 = 3 Then
            varcode_item = value3 : varnamestores = value
            Frm_GardDetils.Close()
            Frm_GardDetils.txt_stores.Text = value
            Frm_GardDetils.txt_NameItem.Text = value2
            Frm_GardDetils.find_Gard_detils()
            Frm_GardDetils.find_balance()
            Frm_GardDetils.MdiParent = Mainmune
            Frm_GardDetils.Show()
        End If
    End Sub

    Private Sub txt_nameitem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 2555525
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub txt_nameitem_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameitem.EditValueChanged

    End Sub
End Class