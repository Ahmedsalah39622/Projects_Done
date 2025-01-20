Imports System.Data.OleDb

Public Class Frm_ReportStores
    Dim oldDate As Date
    Dim oldDay As Integer

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub txt_nameitem_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 25555
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub


    Private Sub Com_GM_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM.ButtonClick
        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 101010
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub Com_GM1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM1.ButtonClick
        vartable = "BD_GroupItem1"
        VarOpenlookup = 202010
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub Com_GM2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GM2.ButtonClick
        vartable = "BD_GroupItem2"
        VarOpenlookup = 202012
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub txt_NameBranch_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameBranch.ButtonClick
        VarOpenlookup = 66060
        vartable = " BD_SUBMAIN"
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub txt_NameStore_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameStore.ButtonClick
        VarOpenlookup = 66062
        vartable = " BD_Stores"
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
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
               "                         iif(dbo.Statement_OfItem.Code_Unit <> dbo.BD_ITEM.Unit2, ROUND(SUM(dbo.Statement_OfItem.Import), 2) * dbo.BD_ITEM.ValueUnit1, ROUND(SUM(dbo.Statement_OfItem.Import), 2)) AS Mnsr2 " & _
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

        sql2 = "  SELECT        Name, NoItem, NameItem, Unit_2, SUM(ward2) AS WardR, SUM(Mnsr2) AS MnsrfR, SUM(ward2) - SUM(Mnsr2) AS balnce     FROM dbo.vw_all_Gard GROUP BY Name, NoItem, NameItem, Unit_2 having NameItem like '%" & txt_nameitem.Text & "%' "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أسم المخزن"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "وارد"
        GridView1.Columns(5).Caption = "منصرف"
        GridView1.Columns(6).Caption = "رصيد"


        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub Action_RetraveData()
        If vardisplayReport4 = 1 Then

            'Cerate_FillCustomer()
            'Find_CustomerFill()
            'run_report()
            find_Gard()
            TabPane1.SelectedPageIndex = 0
            GridView1.BestFitColumns()
        End If

    End Sub
    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        Lab_NameReport.Text = NavBarItem1.Caption
        vardisplayReport4 = 1
        Action_RetraveData()
        run_report()
    End Sub


    Sub run_report()
        If vardisplayReport4 = 1 Then
            Dim report As New Gard_ItemAll
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameStore.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 2 Then
            Dim report As New Invintory_Day2_Additem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameStore.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 3 Then
            Dim report As New Report_Test
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameStore.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 4 Then
            Dim report As New Prodauct_Rol
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameStore.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 5 Then
            Dim report As New Invintory_MinItem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameStore.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        'If vardisplayReport4 = 6 Then
        '    Dim report As New Prshesses_DateDeliver
        '    If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        '  report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        '    If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        '    If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        '    If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        '    If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        '    report.X_Date1.Text = txt_date.Value
        '    report.X_Date2.Text = txt_date2.Value
        '    report.XrLabel29.Text = txt_NameSuppliser.Text
        '    'report.XrLabel11.Text = txt_nameitem.Text
        '    report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  and [Compny_Code] = '" & VarCodeCompny & "'  "
        '    report.CreateDocument()
        '    DocumentViewer1.DocumentSource = report

        'End If

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))


        If vardisplayReport4 = 1 Then
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

    Private Sub txt_NameStore_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameStore.EditValueChanged

    End Sub

    Private Sub txt_nameitem_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameitem.EditValueChanged

    End Sub

    Private Sub Com_GM_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM.EditValueChanged

    End Sub

    Private Sub Com_GM1_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM1.EditValueChanged

    End Sub

    Private Sub Com_GM2_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GM2.EditValueChanged

    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        run_report()
    End Sub

    Private Sub Frm_ReportStores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

    End Sub

    Private Sub NavBarItem5_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        Lab_NameReport.Text = NavBarItem5.Caption
        vardisplayReport4 = 2
        'Action_RetraveData()
        run_report()
    End Sub
End Class