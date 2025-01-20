Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.DataAccess.Excel
Public Class Frm_Panels_Price
    Dim varprcinch As Single
    'Dim varcode_project, varsutasorder As Integer
    'Dim varcodeaccountSubProject, varitemSn As Integer


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        vartable = "Vw_CostCenterAll3"
        VarOpenlookup = 502567
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        fill_Location()
        last_itemSn()
        Fill_DataPanal()
        find_detalis()
        find_Approval()
    End Sub

    Sub Total_Sum()
        'find_tax()
        Dim total As Single
        For i As Integer = 0 To GridView3.RowCount - 1
            total += GridView3.GetRowCellValue(i, GridView3.Columns(8))

        Next
        txt_GrandTotal.Text = Math.Round(total, 2) + Math.Round(Val(Txt_ManPower.Text), 2)

    End Sub
    Sub find_Approval()
        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            If rs("Status_Approval_Admin").Value = 0 Then Radio_Open.Checked = True : Radio_Close.Checked = False
            If rs("Status_Approval_Admin").Value = 1 Then Radio_Close.Checked = True : Radio_Open.Checked = False

        End If
    End Sub
    Sub Fill_DataPanal()

        'On Error Resume Next
        'GridControl1.DataSource = Nothing
        'GridView1.Columns.Clear()


        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()



        'sql2 = "    SELECT RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS SubProjectName, dbo.TB_Hader_Technical_Specifications.ItemSn, dbo.TB_Hader_Technical_Specifications.PanelName, dbo.TB_Hader_Technical_Specifications.Quantity, " & _
        '   "           RTRIM(dbo.TB_Hader_Technical_Specifications.PanelType) AS typePanel, dbo.TB_Hader_Technical_Specifications.INCOMING, dbo.TB_Hader_Technical_Specifications.OUTGOING, dbo.TB_Hader_Technical_Specifications.MOUNTING,  " & _
        '  "  dbo.TB_Hader_Technical_Specifications.Color, dbo.TB_Hader_Technical_Specifications.Separation, dbo.TB_Hader_Technical_Specifications.Protection, dbo.TB_Hader_Technical_Specifications.CostCenter_account1, " & _
        '  "  dbo.TB_Hader_Technical_Specifications.CostCenter_account2 " & _
        '  "  FROM     dbo.TB_Hader_Technical_Specifications INNER JOIN " & _
        '         "             dbo.tb_CustomerProjects ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.tb_CustomerProjects.CostCenter_MainCode AND  " & _
        '         "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.tb_CustomerProjects.CostCenter_SubCode INNER JOIN " & _
        '         "             dbo.ST_CHARTCOSTCENTER ON dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = dbo.ST_CHARTCOSTCENTER.Level_No2 AND  " & _
        '         "             dbo.TB_Hader_Technical_Specifications.CostCenter_account2 = dbo.ST_CHARTCOSTCENTER.Account_No INNER JOIN " & _
        '         "             dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
        '         "             dbo.ST_CHARTCOSTCENTER AS ST_CHARTCOSTCENTER_1 ON dbo.tb_CustomerProjects.CostCenter_MainCode = ST_CHARTCOSTCENTER_1.Account_No " & _
        '    " WHERE  (dbo.TB_Hader_Technical_Specifications.CostCenter_account1 = '" & varcode_project & "') "

        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'Dim ds As New DataSet()
        'da.Fill(ds)
        'GridControl1.DataSource = ds.Tables(0)



        'GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        'GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).Caption = "Sub Project Name"
        'GridView1.Columns(1).Caption = "ItemSn"
        'GridView1.Columns(2).Caption = "Name Panel"
        'GridView1.Columns(3).Caption = "Quantity"
        'GridView1.Columns(4).Caption = "Type Panel"
        'GridView1.Columns(5).Caption = "INCOMING"
        'GridView1.Columns(6).Caption = "OUTGOING"
        'GridView1.Columns(7).Caption = "MOUNTING"
        'GridView1.Columns(8).Caption = "Color"
        'GridView1.Columns(9).Caption = "Separation"
        'GridView1.Columns(10).Caption = "Protection"

        'GridView1.Columns(11).Visible = False
        'GridView1.Columns(12).Visible = False

        'GridView1.BestFitColumns()
        ''If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()


        'On Error Resume Next

    End Sub

    Sub last_itemSn()
        'On Error Resume Next
        'sql = "  SELECT MAX(ItemSn) AS MaxItemSn, CostCenter_account1        FROM dbo.TB_Hader_Technical_Specifications GROUP BY CostCenter_account1 HAVING (CostCenter_account1 = '" & varcode_project & "')"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_ItemSn.Text = rs("MaxItemSn").Value + 1 Else txt_ItemSn.Text = "1"



    End Sub
    Sub fill_Location()
        'If txt_ProjectName.Text = "" Then Exit Sub
        ''=======================================استعلام رقم المشروع

        'sql2 = " SELECT dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTCOSTCENTER.Account_No, dbo.St_CustomerData.Customer_Name " & _
        '         " FROM     dbo.ST_CHARTCOSTCENTER INNER JOIN " & _
        '         "                  dbo.tb_CustomerProjects ON dbo.ST_CHARTCOSTCENTER.Account_No = dbo.tb_CustomerProjects.CostCenter_MainCode INNER JOIN " & _
        '         "                  dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code " & _
        '         " WHERE  (dbo.ST_CHARTCOSTCENTER.AccountName = '" & Trim(txt_ProjectName.Text) & "') "

        'rs = Cnn.Execute(sql2)
        'If rs.EOF = False Then varcode_project = rs("Account_No").Value : txt_CustName.Text = rs("Customer_Name").Value Else MsgBox("المشروع غير مرتبط بعميل من فضلك ادخل اسم العميل على المشروع", MsgBoxStyle.Critical, "Cerative smar software") : Exit Sub

        ''========================================

        ''If cb_SubNamePrj.Text.Trim = "" Then Exit Sub
        'cb_SubNamePrj.Items.Clear()
        'sql = "SELECT  Account_No, AccountName FROM  ST_CHARTCOSTCENTER WHERE        (Level_No2 = '" & varcode_project & "') "
        'rs = Cnn.Execute(sql)
        'Do While Not rs.EOF
        '    cb_SubNamePrj.Items.Add(Trim(rs("AccountName").Value))
        '    rs.MoveNext()
        'Loop
    End Sub


    Private Sub Frm_PanelsTechnicalspecifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub


    Sub save_orderHedare()
        'If Trim(txt_ItemSn.Text) = "" Then Exit Sub
        'sql2 = "select * from TB_Hader_Technical_Specifications where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "'  "
        'rs2 = Cnn.Execute(sql2)

        'If rs2.EOF = False Then

        'Else
        '    'last_Data()

        'End If

        ''================================Header

        'If Len(txt_Categorize.Text) = 0 Then MsgBox("Pleas Insert Categorize ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        'If Len(txt_Description.Text) = 0 Then MsgBox("Pleas Insert Description ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        'If Len(txt_Qty.Text) = 0 Then MsgBox("Pleas Insert Qty ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        'If Len(txt_price.Text) = 0 Then MsgBox("Pleas Insert Price ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub





    End Sub




    Private Sub cmd_New_Click(sender As Object, e As EventArgs)
        txt_Brand.Text = ""
        txt_ItemSn.Text = ""
        txt_PanalName.Text = ""
        txt_FinalPrice.Text = ""
        txt_total.Text = ""
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs)
        save_orderHedare()

        find_detalis()
    End Sub

    Private Sub txt_Categorize_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "Vw_Item_SCHNEIDER"
        VarOpenlookup = 8080
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_Categorize_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
        'On Error Resume Next
        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'cb_SubNamePrj.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        'varitemSn = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        'varcode_project = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        'varcodeaccountSubProject = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        'find_detalis()
        'TabPane1.SelectedPageIndex = 0

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



        sql2 = "   SELECT Brand, PanelName, PanelType, ItemSn, FinalPrice, Quantity, TotalAll, Percent_Price, ROUND(TotalAll * Percent_Price / 100 + TotalAll, 2) AS TotalFinal,iif(Status_Approval=0,'Open','Close') as StatusPricing, " & _
            "GrandTotal,MANPOWER,N_Indirct,IndirctCost,N_TAX,GrandTAX,N_Profit,GrandTotalProfit " & _
   " FROM     dbo.Vw_PricePanal " & _
   " WHERE  (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' "

        'varcode_project = value4
        'varcodeaccountSubProject = value5
        rs = Cnn.Execute(sql2)

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)



        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "Brand"
        GridView3.Columns(1).Caption = "PanelName"
        GridView3.Columns(2).Caption = "PanelType"
        GridView3.Columns(3).Caption = "ItemSn"
        GridView3.Columns(4).Caption = "FinalPrice"
        GridView3.Columns(5).Caption = "Quantity"
        GridView3.Columns(6).Caption = "TotalAll"
        GridView3.Columns(7).Caption = "Percent"
        GridView3.Columns(8).Caption = "TotalFinal"
        GridView3.Columns(9).Caption = "Stutas Technical Pricing"

        '=====================================================total
        txt_GrandTotal.Text = rs("GrandTotal").Value
        Txt_ManPower.Text = rs("MANPOWER").Value
        txt_NIndirctCost.Text = rs("N_Indirct").Value
        txt_Value_NIndirctCost.Text = rs("IndirctCost").Value
        txt_NTaxTotal.Text = rs("N_TAX").Value
        txt_TAX_Total.Text = rs("GrandTAX").Value
        txt_ProfilN.Text = rs("N_Profit").Value
        txt_Profil_Value.Text = rs("GrandTotalProfit").Value
        '===============================================
        GridView3.Columns(10).Visible = False
        GridView3.Columns(11).Visible = False
        GridView3.Columns(12).Visible = False
        GridView3.Columns(13).Visible = False
        GridView3.Columns(14).Visible = False
        GridView3.Columns(15).Visible = False
        GridView3.Columns(16).Visible = False
        GridView3.Columns(17).Visible = False



        GridView3.Columns(0).AppearanceCell.BackColor = Color.Black
        GridView3.Columns(0).AppearanceCell.ForeColor = Color.White



        'GridView3.Appearance.FocusedRow.BackColor = Color.White
        'GridView3.Appearance.FocusedRow.BackColor2 = Color.White
        'GridView3.Appearance.FocusedRow.ForeColor = Color.Black

        GridView3.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView3.BestFitColumns()
        Total_Sum()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub





    Private Sub cmd_New_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_Qty_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        txt_total.Text = Val(txt_ItemSn.Text) * (Val(txt_FinalPrice.Text) * Val(Txt_qyt.Text))
    End Sub

    Private Sub txt_Quantity_TextChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        txt_total.Text = Val(txt_ItemSn.Text) * (Val(txt_FinalPrice.Text) * Val(Txt_qyt.Text))

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'fill_Location()
        last_itemSn()
        Fill_DataPanal()
        find_detalis()
    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs)
        Dim report As New Offer
        report.FilterString = "[CostCenter_account1] = '" & varcode_project & "' and [CostCenter_account2] = '" & varcodeaccountSubProject & "'  "

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        GridView3.ShowRibbonPrintPreview()
    End Sub

    Private Sub txt_price_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub txt_Prcintich_TextChanged(sender As Object, e As EventArgs) Handles txt_Prcintich.TextChanged
        On Error Resume Next
        varprcinch = Math.Round(Val(txt_total.Text) * Val(txt_Prcintich.Text) / 100, 2)
        txt_TotalFinal.Text = Math.Round(varprcinch + Val(txt_total.Text), 2)
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        'Dim varref_no As String


        sql = "SELECT CostCenter_account1, CostCenter_account2, Status_Approval_Admin       FROM dbo.Vw_PricePanal GROUP BY CostCenter_account1, CostCenter_account2, Status_Approval_Admin HAVING   (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval_Admin =1"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("المشروع تم اعتمادة لايمكن تغير القيم علية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Else

            sql2 = "    SELECT  dbo.TB_Detalis_Technical_Specifications.Ref_No, dbo.BD_Item.CodeGroupItemMain, dbo.TB_Detalis_Technical_Specifications.CostCenter_account1, dbo.TB_Detalis_Technical_Specifications.CostCenter_account2, dbo.BD_GROUPITEMMAIN.Name AS Brand, " & _
"                  dbo.TB_Detalis_Technical_Specifications.Percent_Price " & _
" FROM     dbo.BD_Item INNER JOIN " & _
"                  dbo.TB_Detalis_Technical_Specifications ON dbo.BD_Item.Code = dbo.TB_Detalis_Technical_Specifications.No_Item INNER JOIN " & _
"                  dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code " & _
" WHERE  (dbo.TB_Detalis_Technical_Specifications.CostCenter_account1 = '" & varcode_project & "') AND (dbo.BD_GROUPITEMMAIN.Name = '" & txt_Brand.Text & "') "

            rs = Cnn.Execute(sql2)
            'If rs.EOF = False Then varref_no = rs("Ref_No").Value
            Do While Not rs.EOF


                '==================================التاكد من غلق تسعير اللوحة

                sql = "   SELECT CostCenter_account1, CostCenter_account2, ItemSn, Status_Approval         FROM dbo.TB_Hader_Technical_Specifications WHERE  (CostCenter_account1 = '" & varcode_project & "') AND (CostCenter_account2 = '" & varcodeaccountSubProject & "') AND (ItemSn = '" & txt_ItemSn.Text & "') AND (Status_Approval = 1)"
                rs3 = Cnn.Execute(sql)
                If rs3.EOF = False Then
                    '====================================



                    sql = "UPDATE    TB_Detalis_Technical_Specifications  set Percent_Price ='" & txt_Prcintich.Text & "'  where  CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' and ItemSn ='" & txt_ItemSn.Text & "'  and Ref_No ='" & rs("Ref_No").Value & "' "
                    rs2 = Cnn.Execute(sql)
                Else
                    find_detalis()
                    MsgBox("لم يتم غلق تسعير اللوحة بالكامل لايمكن ادخال النسبة", MsgBoxStyle.Critical, "Cerative smar software") : Exit Sub
                End If
                rs.MoveNext()
            Loop





            MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
            find_detalis()

        End If






   
    End Sub

    Private Sub cmd_OK_Click(sender As Object, e As EventArgs) Handles cmd_OK.Click
        Dim varcodeflag As Integer
        If Radio_Open.Checked = True Then varcodeflag = 0
        If Radio_Close.Checked = True Then varcodeflag = 1


        sql = "select * from TB_Hader_Technical_Specifications where Status_Approval = 0 and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لم يتم غلق تسعير اللوحات بالكامل لايمكن اعتماده", MsgBoxStyle.Critical, "Cerative smar software") : Exit Sub

        sql2 = "UPDATE  TB_Hader_Technical_Specifications  SET   GrandTotal = '" & txt_GrandTotal.Text & "',MANPOWER = '" & Txt_ManPower.Text & "',N_Indirct = '" & txt_NIndirctCost.Text & "' ,IndirctCost ='" & txt_Value_NIndirctCost.Text & "',N_TAX ='" & txt_NTaxTotal.Text & "',GrandTAX='" & txt_TAX_Total.Text & "',N_Profit='" & txt_ProfilN.Text & "',GrandTotalProfit='" & txt_Profil_Value.Text & "', Status_Approval_Admin ='" & varcodeflag & "' WHERE  CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "'   "
        rs = Cnn.Execute(sql2)
        Add_item()

        If Radio_Open.Checked = True Then MsgBox("تم فتح", MsgBoxStyle.Information, "Css Solution Software Module")
        If Radio_Close.Checked = True Then MsgBox("تم أغلاق ", MsgBoxStyle.Information, "Css Solution Software Module")
    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As RowCellStyleEventArgs)
        For x As Integer = 0 To GridView3.RowCount



            Dim ststus_Stores As String
            Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle

            '=======================================================================
            ststus_Stores = GridView3.GetRowCellValue(x, GridView3.Columns(9))
            If ststus_Stores = "Open" Then
                If e.Column.AbsoluteIndex = 9 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.White
                End If
            Else
                If e.Column.AbsoluteIndex = 9 AndAlso e.RowHandle = x Then
                    e.Appearance.BackColor = Color.Green
                End If
            End If


        Next x
    End Sub

   

    Sub Add_item()
        sql2 = "   SELECT Brand, PanelName, PanelType, ItemSn, FinalPrice, Quantity, TotalAll, Percent_Price, ROUND(TotalAll * Percent_Price / 100 + TotalAll, 2) AS TotalFinal,iif(Status_Approval=0,'Open','Close') as StatusPricing " & _
" FROM     dbo.Vw_PricePanal " & _
" WHERE  (CostCenter_account1 = '" & varcode_project & "') and  CostCenter_account2 ='" & varcodeaccountSubProject & "' and Status_Approval =1 "
        rs4 = Cnn.Execute(sql2)
        Do While Not rs4.EOF


            '=========================lastItem
            Dim varPanalRef As String
            sql = "SELECT        MAX(Code) AS MaxmamNo  FROM  BD_ITEM  where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(Code) Is Not NULL)  "
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then varcodeitem3 = rs3("MaxmamNo").Value + 1         
            varPanalRef = Str(varcodeitem3) + "-" + "Panal"
            '=========================================item Dublict
            sql = "select * from BD_ITEM where Name ='" & rs4("PanelName").Value & "'  "
            rs2 = Cnn.Execute(sql)
            If rs2.EOF = False Then

            Else
                sql = "INSERT INTO BD_ITEM (Code,Ex_Item, Name,CodeGroupItemMain,CodeGroupItem1,CodeGroupItem2,Unit1,ValueUnit1,Unit2,ValueUnit2,Unit3,ValueUnit3,MinOrderItem,TypeItem,Compny_Code,Code_project,Code_SubProject) " & _
     " values  (N'" & varcodeitem3 & "' ,N'" & varPanalRef & "','" & Trim(rs4("PanelName").Value) & "',N'" & 6 & "',N'" & 0 & "',N'" & 0 & "',N'" & 2 & "',N'" & 1 & "',N'" & 2 & "',N'" & 1 & "',N'" & 2 & "',N'" & 1 & "',N'" & 10 & "',N'" & 0 & "',N'" & VarCodeCompny & "','" & varcode_project & "','" & varcodeaccountSubProject & "' )"
                Cnn.Execute(sql)
                MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            End If


            rs4.MoveNext()
        Loop
    End Sub

    Private Sub GridControl2_Click_1(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim varnumberPrcint As Single
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle

        txt_Brand.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        txt_PanalName.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_ItemSn.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        txt_FinalPrice.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        Txt_qyt.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        txt_Prcintich.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))


        txt_total.Text = Math.Round(Val(txt_FinalPrice.Text) * Val(Txt_qyt.Text), 2)
        varnumberPrcint = Math.Round(Val(txt_total.Text) * Val(txt_Prcintich.Text) / 100, 2)
        txt_TotalFinal.Text = Math.Round(varnumberPrcint + Val(txt_total.Text), 2)
    End Sub

    Private Sub Txt_ManPower_TextChanged(sender As Object, e As EventArgs) Handles Txt_ManPower.TextChanged
        Total_Sum()
    End Sub

    Private Sub txt_NIndirctCost_TextChanged(sender As Object, e As EventArgs) Handles txt_NIndirctCost.TextChanged
        Dim vardirctcost As Single
        vardirctcost = Val(txt_GrandTotal.Text) * (Val(txt_NIndirctCost.Text) / 100)
        txt_Value_NIndirctCost.Text = Math.Round(Val(txt_GrandTotal.Text) + Val(vardirctcost), 2)

    End Sub

    Private Sub txt_NTaxTotal_TextChanged(sender As Object, e As EventArgs) Handles txt_NTaxTotal.TextChanged
        Dim vartax As Single
        vartax = Math.Round(Val(txt_Value_NIndirctCost.Text) * Val(txt_NTaxTotal.Text) / 100, 2)
        txt_TAX_Total.Text = Math.Round(Val(txt_Value_NIndirctCost.Text) + Val(vartax), 2)

    End Sub

    Private Sub txt_ProfilN_TextChanged(sender As Object, e As EventArgs) Handles txt_ProfilN.TextChanged
        Dim varprofit As Single
        varprofit = Math.Round(Val(txt_TAX_Total.Text) * Val(txt_ProfilN.Text) / 100, 2)
        txt_Profil_Value.Text = Math.Round(Val(txt_TAX_Total.Text) + Val(varprofit), 2)

    End Sub

    Private Sub cmd_Print_Click_1(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Dim report As New Offer_Cost
        'report.FilterString = "[CostCenter_account1] = '" & varcode_project & "' and [CostCenter_account2] = '" & varcodeaccountSubProject & "'  "

        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

    End Sub
End Class