Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.DataAccess.Excel

Public Class Frm_PanelsTechnicalspecifications
    Dim Varcode_Customer As Integer
    Dim var_Rev As Integer
    Dim varsutasorder As Integer
    Dim varchk, varindx As Integer

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        vartable = "Vw_CostCenterAll2"
        VarOpenlookup = 502566
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        fill_Location()
        last_itemSn()
        Fill_DataPanal()
        find_hedar()
        find_detalis()

        'loadlistbox()
    End Sub



    Sub loadlistbox()
        On Error Resume Next
        ListBoxControl1.Items.Clear()
        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text
        '=======================================================================
        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + VarName_Customer
        Dim Dir2 As String = Dir1 + "\" + txt_ProjectName.Text + "\" + varcaption
        Dim Dir3 As String = Dir2
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Dir3)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory

        For Each dra In diar1
            ListBoxControl1.Items.Add(dra)
        Next

    End Sub
    Sub Fill_DataPanal()

        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "    SELECT RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS SubProjectName, dbo.TB_Hader_Technical_Specifications.ItemSn, rtrim(dbo.TB_Hader_Technical_Specifications.PanelName) as PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, " & _
           "           RTRIM(dbo.TB_Hader_Technical_Specifications.PanelType) AS typePanel, rtrim(dbo.TB_Hader_Technical_Specifications.INCOMING) as INCOMING, rtrim(dbo.TB_Hader_Technical_Specifications.OUTGOING) as OUTGOING, rtrim(dbo.TB_Hader_Technical_Specifications.MOUNTING) as MOUNTING,  " & _
          "  rtrim(dbo.TB_Hader_Technical_Specifications.Color) as Color, rtrim(dbo.TB_Hader_Technical_Specifications.Separation) as Separation, rtrim(dbo.TB_Hader_Technical_Specifications.Protection) as Protection, dbo.TB_Hader_Technical_Specifications.CostCenter_account1, " & _
          "  dbo.TB_Hader_Technical_Specifications.CostCenter_account2,iif(Status_Approval=0,'Open','Close') as Stutas,iif(Status_Approval_Admin=0,'Open','Close') as Status_Approval_Admin,TB_Hader_Technical_Specifications.Rev " & _
          "  FROM     dbo.TB_Hader_Technical_Specifications INNER JOIN " & _
                 "             dbo.tb_CustomerProjects ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.tb_CustomerProjects.CostCenter_MainCode AND  " & _
                 "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.tb_CustomerProjects.CostCenter_SubCode INNER JOIN " & _
                 "             dbo.ST_CHARTCOSTCENTER ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.ST_CHARTCOSTCENTER.Level_No2 AND  " & _
                 "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.ST_CHARTCOSTCENTER.Account_No INNER JOIN " & _
                 "             dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
                 "             dbo.ST_CHARTCOSTCENTER AS ST_CHARTCOSTCENTER_1 ON dbo.tb_CustomerProjects.CostCenter_MainCode = ST_CHARTCOSTCENTER_1.Account_No " & _
            " WHERE  (dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = '" & varcode_project & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "Sub Project Name"
        GridView1.Columns(1).Caption = "ItemSn"
        GridView1.Columns(2).Caption = "Name Panel"
        GridView1.Columns(3).Caption = "Quantity"
        GridView1.Columns(4).Caption = "Type Panel"
        GridView1.Columns(5).Caption = "INCOMING"
        GridView1.Columns(6).Caption = "OUTGOING"
        GridView1.Columns(7).Caption = "MOUNTING"
        GridView1.Columns(8).Caption = "Color"
        GridView1.Columns(9).Caption = "Separation"
        GridView1.Columns(10).Caption = "Protection"
        GridView1.Columns(13).Caption = "Status"
        GridView1.Columns(14).Caption = "Status Costing"
        GridView1.Columns(15).Caption = "Rev"

        GridView1.Columns(11).Visible = False
        GridView1.Columns(12).Visible = False

        GridView1.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        'On Error Resume Next

    End Sub

    Sub last_itemSn()
        On Error Resume Next
        sql = "  SELECT MAX(ItemSn) AS MaxItemSn, CostCenter_account1        FROM dbo.TB_Hader_Technical_Specifications GROUP BY CostCenter_account1 HAVING (CostCenter_account1 = '" & varcode_project & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_ItemSn.Text = rs("MaxItemSn").Value + 1 Else txt_ItemSn.Text = "1"



    End Sub
    Sub fill_Location()
        If txt_ProjectName.Text = "" Then Exit Sub
        '=======================================استعلام رقم المشروع

        sql2 = " SELECT dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTCOSTCENTER.Account_No, dbo.St_CustomerData.Customer_Name " & _
                 " FROM     dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
                 "                  dbo.tb_CustomerProjects ON dbo.ST_CHARTCOSTCENTER.Account_No = dbo.tb_CustomerProjects.CostCenter_MainCode INNER JOIN " & _
                 "                  dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code " & _
                 " WHERE  (dbo.ST_CHARTCOSTCENTER.AccountName = '" & Trim(txt_ProjectName.Text) & "') "

        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then varcode_project = rs("Account_No").Value : txt_CustName.Text = rs("Customer_Name").Value : txt_CustName2.Text = rs("Customer_Name").Value : txt_ProjectName2.Text = txt_ProjectName.Text Else MsgBox("المشروع غير مرتبط بعميل من فضلك ادخل اسم العميل على المشروع", MsgBoxStyle.Critical, "Cerative smar software") : Exit Sub

        '========================================

        'If cb_SubNamePrj.Text.Trim = "" Then Exit Sub
        'cb_SubNamePrj.Items.Clear()
        'sql = "SELECT  Account_No, AccountName FROM  ST_CHARTCOSTCENTER WHERE        (Level_No2 = '" & varcode_project & "') "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    cb_SubNamePrj.Items.Add(Trim(rs("AccountName").Value))
        '    rs.MoveNext()
        'Loop
    End Sub


    Private Sub Frm_PanelsTechnicalspecifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Com()
        fill_Categorize()

    End Sub
    Sub fill_Categorize()
        Com_Categorize.Items.Clear()
        sql = "SELECT        Name FROM            dbo.TB_Categorize "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Categorize.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_Com()
        Com_TypePanel.Items.Add("Spacial")
        Com_TypePanel.Items.Add("LOCAL")
        Com_TypePanel.Items.Add("ACTI9")
        Com_TypePanel.Items.Add("Prisma-L")
        Com_TypePanel.Items.Add("Prisma-M")

        '==============================Mounting
        txt_Mounting.Items.Add("WALL MOUNTED")
        txt_Mounting.Items.Add("FLUSH MOUNTE")
        txt_Mounting.Items.Add("FLOOR STAND")
        '======================================Color
        txt_Color.Items.Add("RAL 7035")
        txt_Color.Items.Add("RAL 7047")
        '=============================outgonig

        txt_OutGoing2.Items.Add("TOP")
        txt_OutGoing2.Items.Add("Buttom")
        'txt_OutGoing2.Items.Add("Busway")
        '========================================
        txt_INCOMING.Items.Add("TOP")
        txt_INCOMING.Items.Add("Buttom")
        'txt_INCOMING.Items.Add("Busway")
        '======================================
        txt_Separation.Items.Add("Form-1")
        txt_Separation.Items.Add("Form-2A")
        txt_Separation.Items.Add("Form-2B")
        txt_Separation.Items.Add("Form-3A")
        txt_Separation.Items.Add("Form-3B")
        txt_Separation.Items.Add("Form-4A")
        txt_Separation.Items.Add("Form-4B")
        '==================================

        'Com_Categorize.Items.Add("INCOMING")
        'Com_Categorize.Items.Add("OUTGOING")
        'Com_Categorize.Items.Add("MCB CONTROL")
        'Com_Categorize.Items.Add("NDICATION")
        'Com_Categorize.Items.Add("BREAKER")

    End Sub

    Sub save_orderHedare()
        If Trim(txt_ItemSn.Text) = "" Then Exit Sub
        sql2 = "select * from TB_Hader_Technical_Specifications where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            'last_Data()

        End If

        '================================Header
        If Len(txt_ItemSn.Text) = 0 Then MsgBox("Pleas Insert Item sn ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_ProjectName.Text) = 0 Then MsgBox("Pleas Choose Project Name ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(cb_SubNamePrj.Text) = 0 Then MsgBox("Pleas Choose Project Location  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_NamePanel.Text) = 0 Then MsgBox("Pleas Insert Name Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(Com_TypePanel.Text) = 0 Then MsgBox("Pleas Insert Type Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_INCOMING.Text) = 0 Then MsgBox("Pleas Insert INCOMING ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_OutGoing2.Text) = 0 Then MsgBox("Pleas Insert OUTGOING  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Protection.Text) = 0 Then MsgBox("Pleas Insert Protection ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Color.Text) = 0 Then MsgBox("Pleas Insert Color ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Mounting.Text) = 0 Then MsgBox("Pleas Insert Mounting ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_BUSBAR1.Text) = 0 Then MsgBox("Pleas Insert BUSBAR ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        '=============================================
        If Len(txt_RefNo.Text) = 0 Then MsgBox("Pleas Insert Categorize ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Description.Text) = 0 Then MsgBox("Pleas Insert Description ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("Pleas Insert Qty ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_price.Text) = 0 Then MsgBox("Pleas Insert Price ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub




        save_Technical_Specifications_Header()

    End Sub


    Sub save_Technical_Specifications_Header()
        'On Error Resume Next


        sql = "select * from TB_Hader_Technical_Specifications where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            '=========================رقم Location
            sql2 = "   SELECT Level_No2, AccountName, Account_No          FROM dbo.ST_CHARTCOSTCENTER WHERE  (AccountName = '" & Trim(cb_SubNamePrj.Text) & "')"
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeaccountSubProject = rs("Account_No").Value
            '================================================Open or close
            If Radio_Open.Checked = True Then varsutasorder = 0
            If Radio_Close.Checked = True Then varsutasorder = 1
            '=========================================================
            sql = "INSERT INTO TB_Hader_Technical_Specifications (CostCenter_account1, CostCenter_account2,ItemSn,PanelName,Quantity,PanelType,INCOMING,OUTGOING,MOUNTING,Color,Separation,Protection,BUSBAR1,BUSBAR2,Status_Approval,size,H,W,D,Rev) " & _
                      " values  (N'" & varcode_project & "' ,N'" & varcodeaccountSubProject & "',N'" & txt_ItemSn.Text & "',N'" & txt_NamePanel.Text & "',N'" & txt_Quantity.Text & "',N'" & Com_TypePanel.Text & "',N'" & txt_INCOMING.Text & "',N'" & txt_OutGoing2.Text & "',N'" & txt_Mounting.Text & "',N'" & txt_Color.Text & "',N'" & txt_Separation.Text & "',N'" & txt_Protection.Text & "',N'" & txt_BUSBAR1.Text & "',N'" & txt_BUSBAR2.Text & "',N'" & varsutasorder & "','" & txt_size.Text & "','" & txt_H.Text & "','" & txt_W.Text & "','" & txt_D.Text & "','" & txt_Rev.Text & "')"
            Cnn.Execute(sql)

            ''============================== TransactionHistoryCode
            'sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & txt_ItemSn.Text & "')"
            'rs2 = Cnn.Execute(sql2)
            ''==============================

        End If
        'Next
        'save_oderDetils()
        save_InvoiceDetils()
        ''save_itemStores()
        'clear_detils()
        'find_hedar()
        'find_detalis()
        'Total_Sum()
    End Sub
    Sub save_InvoiceDetils()



        'sql = "  SELECT *    FROM TB_Detalis_Technical_Specifications where   No_Item ='" & varcode_item & "' and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then MsgBox("duplicat Item", MsgBoxStyle.Critical, "Cerative Smart Software") : Exit Sub


        If CheckHide.Checked = False Then varchk = 0
        If CheckHide.Checked = True Then varchk = 1

        sql = "INSERT INTO TB_Detalis_Technical_Specifications (CostCenter_account1,CostCenter_account2,ItemSn,No_Item,Qty_Technical_Specifications,price_Technical_Specifications,discount_Technical_Specifications,Total_Technical_Specifications,Ref_No,Categorize,FlagHide,Rev) " & _
              " values  ('" & varcode_project & "','" & varcodeaccountSubProject & "','" & txt_ItemSn.Text & "','" & varcode_item & "','" & txt_Qty.Text & "','" & txt_price.Text & "','" & txt_Discount.Text & "','" & txt_total.Text & "','" & txt_RefNo.Text & "','" & Com_Categorize.Text & "','" & varchk & "','" & txt_Rev.Text & "')"
        Cnn.Execute(sql)



    End Sub



    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        cb_SubNamePrj.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        varitemSn = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_ItemSn.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        varcode_project = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        varcodeaccountSubProject = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        var_Rev = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(15))
        'clear_Hdear()
        clear_line()
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0

    End Sub
    Sub find_detalis()
        On Error Resume Next

        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "    SELECT dbo.TB_Detalis_Technical_Specifications.Categorize, dbo.TB_Detalis_Technical_Specifications.Ref_No, dbo.BD_Item.Name AS Description, dbo.BD_GROUPITEMMAIN.Name AS Brand, dbo.BD_Typeofsize.name AS Type,  " & _
    "                  dbo.TB_Detalis_Technical_Specifications.Qty_Technical_Specifications, dbo.TB_Detalis_Technical_Specifications.price_Technical_Specifications, dbo.TB_Detalis_Technical_Specifications.discount_Technical_Specifications, " & _
    "                  dbo.TB_Detalis_Technical_Specifications.Qty_Technical_Specifications * dbo.TB_Detalis_Technical_Specifications.price_Technical_Specifications * dbo.TB_Detalis_Technical_Specifications.discount_Technical_Specifications AS FinalPrice, " & _
    "        dbo.TB_Hader_Technical_Specifications.Quantity, " & _
    "       dbo.TB_Detalis_Technical_Specifications.Qty_Technical_Specifications * dbo.TB_Detalis_Technical_Specifications.price_Technical_Specifications * dbo.TB_Detalis_Technical_Specifications.discount_Technical_Specifications * dbo.TB_Hader_Technical_Specifications.Quantity " & _
    "                   AS TotalAll, dbo.TB_Detalis_Technical_Specifications.FlagHide, dbo.TB_Detalis_Technical_Specifications.Rev, dbo.TB_Detalis_Technical_Specifications.indx " & _
    " FROM     dbo.BD_Typeofsize RIGHT OUTER JOIN " & _
    "                  dbo.TB_Detalis_Technical_Specifications INNER JOIN " & _
    "                  dbo.BD_Item ON dbo.TB_Detalis_Technical_Specifications.No_Item = dbo.BD_Item.Code INNER JOIN " & _
    "                  dbo.TB_Hader_Technical_Specifications ON dbo.TB_Detalis_Technical_Specifications.CostCenter_account1 = dbo.TB_Hader_Technical_Specifications.CostCenter_account1 AND  " & _
    "        dbo.TB_Detalis_Technical_Specifications.CostCenter_account2 = dbo.TB_Hader_Technical_Specifications.CostCenter_account2 And " & _
    "                  dbo.TB_Detalis_Technical_Specifications.ItemSn = dbo.TB_Hader_Technical_Specifications.ItemSn AND dbo.TB_Detalis_Technical_Specifications.Rev = dbo.TB_Hader_Technical_Specifications.Rev ON  " & _
    "                  dbo.BD_Typeofsize.code = dbo.BD_Item.Code_TypeOfSize LEFT OUTER JOIN " & _
    "                  dbo.Tb_BandIncomeStatment INNER JOIN " & _
    "                  dbo.BD_GROUPITEMMAIN ON dbo.Tb_BandIncomeStatment.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code LEFT OUTER JOIN " & _
    "                  dbo.BD_Vendor ON dbo.BD_Item.CodeVendor = dbo.BD_Vendor.Code " & _
    " WHERE  (dbo.TB_Detalis_Technical_Specifications.CostCenter_account1 = '" & varcode_project & "') AND (dbo.TB_Detalis_Technical_Specifications.CostCenter_account2 = '" & varcodeaccountSubProject & "') AND (dbo.TB_Detalis_Technical_Specifications.Rev = " & var_Rev & ") and TB_Detalis_Technical_Specifications.ItemSn  = '" & txt_ItemSn.Text & "'  "

        'varitemSn



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)



        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "Categorize"
        GridView3.Columns(1).Caption = "REF.NO"
        GridView3.Columns(2).Caption = "Description"
        GridView3.Columns(3).Caption = "Brand"
        GridView3.Columns(4).Caption = "Type"
        GridView3.Columns(5).Caption = "Qty"
        GridView3.Columns(6).Caption = "Price"
        GridView3.Columns(7).Caption = "Discount"
        GridView3.Columns(8).Caption = "Final Price"
        GridView3.Columns(9).Caption = "Quantity"
        GridView3.Columns(10).Caption = "Total"
        GridView3.Columns(11).Caption = "Hide"
        GridView3.Columns(12).Caption = "Rev"
        GridView3.Columns(13).Caption = "indx"

        GridView3.Columns(13).Visible = False


        GridView3.Columns(8).AppearanceCell.BackColor = Color.Black
        GridView3.Columns(8).AppearanceCell.ForeColor = Color.White


        GridView3.Columns(10).AppearanceCell.BackColor = Color.Gray
        GridView3.Columns(10).AppearanceCell.ForeColor = Color.Red

        'GridView3.Columns(11).Visible = False
        'GridView3.Appearance.FocusedRow.BackColor = Color.White
        'GridView3.Appearance.FocusedRow.BackColor2 = Color.White
        'GridView3.Appearance.FocusedRow.ForeColor = Color.Black

        GridView3.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView3.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView3.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub find_hedar()
        On Error Resume Next
        sql2 = "    SELECT RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS SubProjectName, dbo.TB_Hader_Technical_Specifications.ItemSn, dbo.TB_Hader_Technical_Specifications.PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, " & _
   "           RTRIM(dbo.TB_Hader_Technical_Specifications.PanelType) AS typePanel, dbo.TB_Hader_Technical_Specifications.INCOMING, dbo.TB_Hader_Technical_Specifications.OUTGOING, dbo.TB_Hader_Technical_Specifications.MOUNTING,  " & _
  "  dbo.TB_Hader_Technical_Specifications.Color, dbo.TB_Hader_Technical_Specifications.Separation, dbo.TB_Hader_Technical_Specifications.Protection, dbo.TB_Hader_Technical_Specifications.CostCenter_account1, " & _
  "  dbo.TB_Hader_Technical_Specifications.CostCenter_account2, dbo.TB_Hader_Technical_Specifications.BUSBAR1, dbo.TB_Hader_Technical_Specifications.BUSBAR2,dbo.TB_Hader_Technical_Specifications.Status_Approval,dbo.TB_Hader_Technical_Specifications.Size,dbo.TB_Hader_Technical_Specifications.H,dbo.TB_Hader_Technical_Specifications.W,dbo.TB_Hader_Technical_Specifications.D,dbo.TB_Hader_Technical_Specifications.Rev " & _
  "  FROM     dbo.TB_Hader_Technical_Specifications INNER JOIN " & _
         "             dbo.tb_CustomerProjects ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.tb_CustomerProjects.CostCenter_MainCode AND  " & _
         "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.tb_CustomerProjects.CostCenter_SubCode INNER JOIN " & _
         "             dbo.ST_CHARTCOSTCENTER ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.ST_CHARTCOSTCENTER.Level_No2 AND  " & _
         "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.ST_CHARTCOSTCENTER.Account_No INNER JOIN " & _
         "             dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
         "             dbo.ST_CHARTCOSTCENTER AS ST_CHARTCOSTCENTER_1 ON dbo.tb_CustomerProjects.CostCenter_MainCode = ST_CHARTCOSTCENTER_1.Account_No " & _
    " WHERE  (dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = '" & varcode_project & "') AND (dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = '" & varcodeaccountSubProject & "') and ItemSn ='" & txt_ItemSn.Text & "' and rev ='" & var_Rev & "' "

        rs = Cnn.Execute(sql2)
        If rs.EOF = False Then

            txt_ItemSn.Text = rs("ItemSn").Value
            txt_NamePanel.Text = rs("PanelName").Value
            txt_Quantity.Text = rs("Quantity").Value
            Com_TypePanel.Text = rs("typePanel").Value
            txt_INCOMING.Text = rs("INCOMING").Value
            txt_OutGoing2.Text = rs("OUTGOING").Value
            txt_Mounting.Text = rs("MOUNTING").Value
            txt_Color.Text = rs("Color").Value
            txt_Separation.Text = rs("Separation").Value
            txt_Protection.Text = rs("Protection").Value
            txt_BUSBAR1.Text = rs("BUSBAR1").Value
            txt_BUSBAR2.Text = rs("BUSBAR2").Value
            txt_size.Text = rs("size").Value
            txt_H.Text = rs("H").Value
            txt_W.Text = rs("W").Value
            txt_D.Text = rs("D").Value
            txt_Rev.Text = rs("rev").Value

            If rs("Status_Approval").Value = 0 Then Radio_Open.Checked = True : varsutasorder = 0
            If rs("Status_Approval").Value = 1 Then Radio_Close.Checked = True : varsutasorder = 1



        End If
    End Sub


    Sub clear_Hdear()
        txt_ItemSn.Text = ""
        txt_NamePanel.Text = ""
        txt_Quantity.Text = ""
        Com_TypePanel.Items.Clear()
        txt_INCOMING.Items.Clear()
        txt_OutGoing2.Items.Clear()
        txt_Mounting.Items.Clear()
        Com_Categorize.Items.Clear()
        txt_Color.Items.Clear()
        txt_Separation.Items.Clear()
        txt_Protection.Text = ""
        txt_OutGoing2.Text = ""
        txt_BUSBAR1.Text = ""
        txt_BUSBAR2.Text = ""
        Com_TypePanel.Text = ""
        txt_INCOMING.Text = ""
        txt_Protection.Text = ""
        txt_Separation.Text = ""
        txt_Color.Text = ""
        txt_Mounting.Text = ""
        txt_size.Text = ""
        txt_H.Text = ""
        txt_W.Text = ""
        txt_D.Text = ""
        fill_Com()
    End Sub

    Private Sub cmd_New_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        txt_total.Text = Val(txt_Qty.Text) * (Val(txt_price.Text) * Val(txt_Discount.Text))

    End Sub

    Private Sub txt_Quantity_TextChanged(sender As Object, e As EventArgs) Handles txt_Quantity.TextChanged
        On Error Resume Next
        txt_total.Text = Val(txt_Qty.Text) * (Val(txt_price.Text) * Val(txt_Discount.Text))

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        clear_Hdear()
        clear_line()
        'fill_Location()
        last_itemSn()
        Fill_DataPanal()
        find_hedar()
        find_detalis()
    End Sub





    Private Sub txt_RefNo_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub








    Sub clear_line()
        Com_Categorize.Text = ""
        txt_RefNo.Text = ""
        txt_Qty.Text = ""
        txt_Description.Text = ""
        txt_price.Text = ""
        txt_total.Text = ""
        txt_Discount.Text = ""
    End Sub

    Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs)

    End Sub







    Private Sub txt_price_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        txt_total.Text = Val(txt_Qty.Text) * (Val(txt_price.Text) * Val(txt_Discount.Text))
    End Sub


    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Frm_CopyPanal.ShowDialog()
    End Sub


    Private Sub GridControl2_Click_1(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Com_Categorize.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        txt_RefNo.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_Description.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        txt_Qty.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        txt_price.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(6))
        txt_Discount.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))
        txt_total.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))

        varindx = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(13))

        If GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(11)) = 0 Then
            CheckHide.Checked = False
        Else
            CheckHide.Checked = True
        End If
    End Sub

    Private Sub cmd_New_Click_2(sender As Object, e As EventArgs) Handles cmd_New.Click
        clear_line()
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin ,ItemSn      FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin,ItemSn HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval_Admin =1"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("المشروع تم اعتمادة لايمكن تغير القيم علية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else

            sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' and Status_Approval =1"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
                MsgBox("اللوحة تم اغلاقة لا يمكن الحفظ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

            Else
                save_orderHedare()
                find_hedar()
                find_detalis()
            End If
        End If
        find_hedar()
        find_detalis()
    End Sub

    Private Sub Cmd_DeleteLine_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteLine.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval_Admin =1"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("المشروع تم اعتمادة لايمكن تغير القيم علية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else

            x = MsgBox("هل تريد حذف ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            Select Case x
                Case vbNo

                Case vbYes

                    sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' and Status_Approval =1"
                    rs = Cnn.Execute(sql)
                    If rs.EOF = False Then
                        MsgBox("اللوحة تم اغلاقة لا يمكن حذف صنف عليه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

                    Else




                        sql = "Delete TB_Detalis_Technical_Specifications  WHERE  ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and Ref_No ='" & txt_RefNo.Text & "' and rev ='" & txt_Rev.Text & "' and indx ='" & varindx & "' "
                        rs = Cnn.Execute(sql)


                        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                        find_detalis()
                        Fill_DataPanal()
                    End If
            End Select

        End If
    End Sub

    Private Sub Cmd_DeleteAll_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteAll.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer

        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval_Admin =1 and  rev = '" & txt_Rev.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("المشروع تم اعتمادة لايمكن تغير القيم علية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else

            x = MsgBox("هل تريد حذف اللوحة ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            Select Case x
                Case vbNo

                Case vbYes


                    sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval ,ItemSn      FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' and Status_Approval =1"
                    rs = Cnn.Execute(sql)
                    If rs.EOF = False Then
                        MsgBox("اللوحة تم اغلاقة لا يمكن حذف  ", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

                    Else
                        sql = "Delete TB_Detalis_Technical_Specifications  WHERE CostCenter_account1 = '" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' and rev = '" & txt_Rev.Text & "' "
                        rs = Cnn.Execute(sql)



                        sql = "Delete TB_Hader_Technical_Specifications  WHERE CostCenter_account1 = '" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "'  and Status_Approval ='" & 0 & "' and ItemSn ='" & txt_ItemSn.Text & "' and rev = '" & txt_Rev.Text & "' "
                        rs = Cnn.Execute(sql)


                        MsgBox(" تم حذف المشروع", MsgBoxStyle.Information, "Css Solution Software Module")
                        find_detalis()
                        Fill_DataPanal()

                    End If
            End Select


        End If
    End Sub

    Private Sub cmd_Print_Click_1(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Dim report As New Offer
        If CheckBox1.Checked = True Then report.FilterString = "[CostCenter_account1] = '" & varcode_project & "' and [CostCenter_account2] = '" & varcodeaccountSubProject & "'  and [Rev] = '" & RTrim(txt_Rev.Text) & "'  "
        If CheckBox1.Checked = False Then report.FilterString = "[CostCenter_account1] = '" & varcode_project & "' and [CostCenter_account2] = '" & varcodeaccountSubProject & "' and [PanelName] = '" & RTrim(txt_NamePanel.Text) & "' and [Rev] = '" & RTrim(txt_Rev.Text) & "' and ItemSn2 ='" & varitemSn & "'  "

        report.CreateDocument()
        DocumentViewer2.DocumentSource = report
    End Sub

    Private Sub Cmd_Print2_Click_1(sender As Object, e As EventArgs) Handles Cmd_Print2.Click
        GridView3.ShowRibbonPrintPreview()
    End Sub

    Private Sub cmd_Edit_Click_1(sender As Object, e As EventArgs) Handles cmd_Edit.Click
        If Len(txt_ItemSn.Text) = 0 Then MsgBox("Pleas Insert Item sn ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_ProjectName.Text) = 0 Then MsgBox("Pleas Choose Project Name ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(cb_SubNamePrj.Text) = 0 Then MsgBox("Pleas Choose Project Location  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_NamePanel.Text) = 0 Then MsgBox("Pleas Insert Name Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(Com_TypePanel.Text) = 0 Then MsgBox("Pleas Insert Type Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_INCOMING.Text) = 0 Then MsgBox("Pleas Insert INCOMING ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_OutGoing2.Text) = 0 Then MsgBox("Pleas Insert OUTGOING  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Protection.Text) = 0 Then MsgBox("Pleas Insert Protection ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Color.Text) = 0 Then MsgBox("Pleas Insert Color ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Mounting.Text) = 0 Then MsgBox("Pleas Insert Mounting ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_BUSBAR1.Text) = 0 Then MsgBox("Pleas Insert BUSBAR ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        '=============================================
        If Len(txt_RefNo.Text) = 0 Then MsgBox("Pleas Insert Categorize ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Description.Text) = 0 Then MsgBox("Pleas Insert Description ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("Pleas Insert Qty ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_price.Text) = 0 Then MsgBox("Pleas Insert Price ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub


        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval,ItemSn HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "' and Status_Approval =1"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("اللوحة تم اغلاقة لا يمكن تعديل صنف عليه", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else






            '===================================Update Hedar

            sql2 = "UPDATE    TB_Hader_Technical_Specifications  set PanelName ='" & txt_NamePanel.Text & "', Quantity ='" & txt_Quantity.Text & "',PanelType ='" & Com_TypePanel.Text & "',INCOMING='" & txt_INCOMING.Text & "',OUTGOING='" & txt_OutGoing2.Text & "',MOUNTING ='" & txt_Mounting.Text & "',Color = '" & txt_Color.Text & "',Separation='" & txt_Separation.Text & "',Protection='" & txt_Protection.Text & "',BUSBAR1='" & txt_BUSBAR1.Text & "',BUSBAR2='" & txt_BUSBAR2.Text & "' ,Size ='" & txt_size.Text & "',H ='" & txt_H.Text & "',W ='" & txt_W.Text & "',D ='" & txt_D.Text & "'     where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' "
            rs = Cnn.Execute(sql2)


            '============================================= كود الصنف 
            sql = "   SELECT Ex_Item, Code        FROM dbo.BD_Item WHERE  (Ex_Item = '" & txt_RefNo.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeitem2 = rs("code").Value
            '============================================= detils 
            If CheckHide.Checked = False Then varchk = 0
            If CheckHide.Checked = True Then varchk = 1

            sql2 = "UPDATE    TB_Detalis_Technical_Specifications  set No_Item ='" & varcodeitem2 & "', Qty_Technical_Specifications ='" & txt_Qty.Text & "',price_Technical_Specifications ='" & txt_price.Text & "',discount_Technical_Specifications='" & txt_Discount.Text & "',Total_Technical_Specifications='" & txt_total.Text & "',Categorize ='" & Com_Categorize.Text & "',FlagHide ='" & varchk & "'  where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and Ref_No ='" & txt_RefNo.Text & "' and indx ='" & varindx & "' and rev ='" & txt_Rev.Text & "' "
            rs = Cnn.Execute(sql2)

            MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

            find_hedar()
            find_detalis()

        End If
    End Sub

    Private Sub cmd_OK_Click_1(sender As Object, e As EventArgs) Handles cmd_OK.Click
        Dim varcodeflag As Integer

        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval_Admin =1"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("المشروع تم اعتمادة لايمكن تغير القيم علية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else

            If Radio_Open.Checked = True Then varcodeflag = 0
            If Radio_Close.Checked = True Then varcodeflag = 1

            sql2 = "UPDATE  TB_Hader_Technical_Specifications  SET Status_Approval ='" & varcodeflag & "' WHERE  CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "'  "
            rs = Cnn.Execute(sql2)

            If Radio_Open.Checked = True Then MsgBox("تم فتح", MsgBoxStyle.Information, "Css Solution Software Module")
            If Radio_Close.Checked = True Then MsgBox("تم الاغلاق", MsgBoxStyle.Information, "Css Solution Software Module")

        End If
        Fill_DataPanal()
    End Sub


    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView3.RowCellStyle

    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        For x As Integer = 0 To GridView1.RowCount



            Dim ststus_Stores As String
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            'حركة البيع
            '=======================================================================
            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(13))
            If ststus_Stores = "Open" Then
                If e.Column.AbsoluteIndex = 13 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.White
                End If
            Else
                If e.Column.AbsoluteIndex = 13 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Green
                End If
            End If
            '======================================================================================

            ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(14))
            If ststus_Stores = "Close" Then
                If e.Column.AbsoluteIndex = 14 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Green
                End If
            Else
                If e.Column.AbsoluteIndex = 14 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.White
                End If
            End If


        Next x
    End Sub

    Private Sub ListBoxControl1_Click(sender As Object, e As EventArgs) Handles ListBoxControl1.Click


        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text

        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + Trim(txt_CustName.Text)
        Dim Dir2 As String = Dir1 + "\" + Trim(txt_ProjectName.Text) + "\" + varcaption
        Dim Dir3 As String = Dir2
        Dim Dir4 As String = Trim(Dir3) + "\" + ListBoxControl1.Text
        Me.PdfViewer1.LoadDocument(Dir4)
    End Sub

    Private Sub ListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl1.SelectedIndexChanged

    End Sub

    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_OpenFile_Click_1(sender As Object, e As EventArgs) Handles Cmd_OpenFile.Click
        Dim OpenFileDialog As New OpenFileDialog

        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "PDF Files (*.pdf) |*.pdf|All Files (*.*)|*.*"

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

            'If txt_OpenFile.Text = "" Then
            '    MessageBox.Show("قم بأختيار PAO")
            'Else
            ' Directions For Upload Solution


            Dim Dir As String = "\\server\CSS2021"
            Dim Dir1 As String = Dir + "\" + txt_CustName.Text
            Dim Dir2 As String = Dir1 + "\" + txt_ProjectName.Text + "\" + varcaption
            Dim Dir3 As String = Dir2
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
        'End If
    End Sub

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub Op1_CheckedChanged(sender As Object, e As EventArgs) Handles Op1.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub txt_RefNo_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelX6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_RefNo_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_RefNo.ButtonClick
        txt_RefNo.Text = ""
        txt_Qty.Text = ""
        txt_Description.Text = ""
        txt_price.Text = ""
        txt_total.Text = ""
        txt_Discount.Text = ""
        vartable = "Vw_Item_SCHNEIDER"
        VarOpenlookup = 8080
        Frm_Lookup_Panel.ShowDialog()
    End Sub

    Private Sub txt_RefNo_EditValueChanged_1(sender As Object, e As EventArgs) Handles txt_RefNo.EditValueChanged

    End Sub

    Private Sub txt_Qty_TextChanged_2(sender As Object, e As EventArgs) Handles txt_Qty.TextChanged
        On Error Resume Next
        txt_total.Text = Val(txt_Qty.Text) * (Val(txt_price.Text) * Val(txt_Discount.Text))

    End Sub

    Private Sub txt_price_TextChanged_1(sender As Object, e As EventArgs) Handles txt_price.TextChanged
        On Error Resume Next
        txt_total.Text = Val(txt_Qty.Text) * (Val(txt_price.Text) * Val(txt_Discount.Text))

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        vartable = "TB_Categorize"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " Categorize"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub Com_Categorize_GotFocus(sender As Object, e As EventArgs) Handles Com_Categorize.GotFocus
        fill_Categorize()
    End Sub

    Private Sub Com_Categorize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Categorize.SelectedIndexChanged

    End Sub

   
    Private Sub Cmd_CerateRev_Click(sender As Object, e As EventArgs) Handles Cmd_CerateRev.Click
        Frm_CopyRev.txt_ProjectName.Text = Trim(txt_ProjectName.Text)
        Frm_CopyRev.ShowDialog()
    End Sub
End Class