Imports System.Data.OleDb

Public Class Lookupitem
    Sub Fill_Alldata()
        'On Error Resume Next


        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        If varcode_form = 25701 Or varcode_form = 2560 Or varcode_form = 2501 Or varcode_form = 190 Or varcode_form = 2555525 Or varcode_form = 25500 Or varcode_form = 19 Then
            sql2 = "SELECT     code,name,Ex_Item,MG,G2,PriceSal,Price_withTax,balance " & _
           " FROM        " & VARTBNAME & " where Compny_Code ='" & VarCodeCompny & "'  "
        Else
            sql2 = "SELECT TOP (100) PERCENT dbo.BD_Item.Code, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.BD_Unit.Name AS UnitName, dbo.Vw_PricePanal.GrandTotalProfit / dbo.Vw_PricePanal.Quantity AS PriceUnit, " & _
     "                 dbo.Vw_PricePanal.Quantity, dbo.Vw_PricePanal.GrandTotalProfit AS TotalFinal, dbo.ST_CHARTCOSTCENTER.AccountName , dbo.ST_CHARTCOSTCENTER.Account_No " & _
    " FROM     dbo.Vw_PricePanal INNER JOIN " & _
    "                  dbo.BD_Item ON dbo.Vw_PricePanal.CostCenter_account1 = dbo.BD_Item.Code_project AND dbo.Vw_PricePanal.CostCenter_account2 = dbo.BD_Item.Code_SubProject AND  " & _
    "                  dbo.Vw_PricePanal.PanelName = dbo.BD_Item.Name INNER JOIN " & _
    "                  dbo.BD_Unit ON dbo.BD_Item.Unit1 = dbo.BD_Unit.Code INNER JOIN " & _
    "                  dbo.ST_CHARTCOSTCENTER ON dbo.Vw_PricePanal.CostCenter_account2 = dbo.ST_CHARTCOSTCENTER.Account_No " & _
    " WHERE  (dbo.Vw_PricePanal.Status_Approval = 1) AND (dbo.Vw_PricePanal.CostCenter_account1 ='" & varcode_project & "') " & _
    " GROUP BY dbo.Vw_PricePanal.ItemSn, dbo.Vw_PricePanal.Quantity, dbo.BD_Item.Name, dbo.BD_Item.Code, dbo.BD_Item.Ex_Item, dbo.BD_Unit.Name, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTCOSTCENTER.Account_No,dbo.Vw_PricePanal.GrandTotalProfit " & _
    " ORDER BY dbo.Vw_PricePanal.ItemSn "
        End If

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        If varcode_form = 25701 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(2).Caption = "المجموعة الرئيسية"
            GridView1.Columns(3).Caption = "المجموعة 1"
            GridView1.Columns(4).Caption = "السعر ضريبى"
            GridView1.Columns(5).Caption = "السعر غير الضريبى"
            GridView1.Columns(6).Caption = "وزن"
            GridView1.Columns(7).Caption = "رصيد الصنف"
        ElseIf varcode_form = 2560 Or varcode_form = 19 Or varcode_form = 2501 Or varcode_form = 190 Or varcode_form = 2555525 Or varcode_form = 25500 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(2).Caption = "Ref_No"
            GridView1.Columns(3).Caption = "المجموعة الرئيسية"
            GridView1.Columns(4).Caption = "المجموعة 1"
            GridView1.Columns(5).Caption = "السعر ضريبى"
            GridView1.Columns(6).Caption = "السعر غير الضريبى"
            GridView1.Columns(7).Caption = "الرصيد"

            GridView1.Columns(4).Visible = False
            GridView1.Columns(5).Visible = False

        Else
            GridView1.Columns(0).Caption = "Code"
            GridView1.Columns(1).Caption = "Ref_No"
            GridView1.Columns(2).Caption = "Name Item"
            GridView1.Columns(3).Caption = "Unit"
            GridView1.Columns(4).Caption = "Price Unit"
            GridView1.Columns(5).Caption = "Qty"
            GridView1.Columns(6).Caption = "Total"
            GridView1.Columns(7).Caption = "Sub Project"
            GridView1.Columns(8).Visible = False
        End If
       

        GridView1.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'ds.Clear()

    End Sub

    Private Sub Lookupitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Alldata()
    End Sub

  

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2)) ' elmgmo3a elr2esya 3shan lw mwaser ngeb elwzn 
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))

        If varcode_form = 49 Then
            Frm_FristItem.txt_AccountNo.Text = value
            Frm_FristItem.txt_nameaccount.Text = value2

        End If

        If varcode_form = 19 Then
            Frm_FristItem.txt_CodeItem.Text = value
            Frm_FristItem.txt_NameItem.Text = value2

        End If

        If varcode_form = 190 Then
            Frm_OrderItem.txt_CodeItem.Text = value
            Frm_OrderItem.txt_NameItem.Text = value2

        End If

        If varcode_form = 25 Then

            Frm_OrderData.sizeItem = 0
            Frm_OrderData.txt_CodeItem.Text = value
            For i = 0 To Frm_OrderData.GridView6.RowCount - 1
                If Frm_OrderData.GridView6.GetRowCellValue(i, Frm_OrderData.GridView6.Columns(0)) = value Then
                    MsgBox("هذا العنصر تمت اضافتة مسبقا الى الفاتورة", MsgBoxStyle.Critical, "عنصر")
                    Exit Sub
                End If
            Next
            Frm_OrderData.txt_NameItem.Text = value2
            If value5 = "ماسورة" Then
                Frm_OrderData.sizeItem = value6 ' كده عينا الوزن فى حالة وجود ماسورة
            End If
            If Frm_OrderData.RadioButton2.Checked = True Then Frm_OrderData.txt_PriceUnit.Text = value3 'سعر ضريبى
            If Frm_OrderData.RadioButton6.Checked = True Then Frm_OrderData.txt_PriceUnit.Text = value4 ' سعر بدون ضريبى

        End If

        If varcode_form = 2501 Then
            Frm_GardItem2.txt_codeItem.Text = value
            Frm_GardItem2.txt_NameItem.Text = value2

        End If

        If varcode_form = 25060 Then
            'Frm_ProudactionOrder2.txt_codeItem.Text = value
            Frm_ProudactionOrder2.Com_NameItem.Text = value2

        End If



        If varcode_form = 2555 Then
            'Frm_OrderData.txt_CodeItem.Text = value
            Frm_ReportCustomer2.txt_nameitem.Text = value2

        End If

        'If varcode_form = 25500 Then
        '    Frm_Azn_AddItem.varItemCode = value
        '    Frm_Azn_AddItem.Com_NameItem.Text = value2

        'End If

        If varcode_form = 2556 Then
            'Frm_OrderData.txt_CodeItem.Text = value
            Frm_Report_Salse.txt_nameitem.Text = value2

        End If


        If varcode_form = 25555 Then
            'Frm_OrderData.txt_CodeItem.Text = value
            Frm_ReportStores.txt_nameitem.Text = value2

        End If

        If varcode_form = 250 Then
            'Frm_OrderData.txt_CodeItem.Text = value
            ReportPrsheses_New.txt_nameitem.Text = value2

        End If

        If varcode_form = 25011 Then
            'Frm_OrderData.txt_CodeItem.Text = value
            Frm_Report_Invintory.txt_nameitem.Text = value2

        End If

        If varcode_form = 2626 Then
            Frm_ItemNewProduct.txt_CustomerName.Text = value2

        End If

        If varcode_form = 255 Then

            Frm_suppliersInfo.txt_NameItem.Text = value2

        End If


        If varcode_form = 2555525 Then

            Frm_Report_Invintory2021.txt_nameitem.Text = value2

        End If






        If varcode_form = 2520 Then
            'Frm_Order_M.txt_CodeItem.Text = value
            Frm_Order_M.com_ToolsName.Text = value2

        End If

        If varcode_form = 2560 Then
            Frm_OrderPrcheses.txt_CodeItem.Text = value
            Frm_OrderPrcheses.txt_NameItem.Text = value2

        End If

        If varcode_form = 2570 Then
            Frm_PriceListSuppliser.txt_CodeItem.Text = value
            Frm_PriceListSuppliser.txt_NameItem.Text = value2

        End If

        If varcode_form = 25701 Then
            Frm_PriceList_sal.sizeItem = 0
            Frm_PriceList_sal.txt_CodeItem.Text = value
            For i = 0 To Frm_PriceList_sal.GridView6.RowCount - 1
                If Frm_PriceList_sal.GridView6.GetRowCellValue(i, Frm_PriceList_sal.GridView6.Columns(0)) = value Then
                    MsgBox("هذا العنصر تمت اضافتة مسبقا الى الفاتورة", MsgBoxStyle.Critical, "عنصر")
                    Exit Sub
                End If
            Next
            Frm_PriceList_sal.txt_NameItem.Text = value2
            If value5 = "ماسورة" Then
                Frm_PriceList_sal.sizeItem = value6 ' كده عينا الوزن فى حالة وجود ماسورة
            End If
            If Frm_PriceList_sal.chekPrice.Checked = True Then Frm_PriceList_sal.txt_Price.Text = value3 'سعر ضريبى
            If Frm_PriceList_sal.chekPrice.Checked = False Then Frm_PriceList_sal.txt_Price.Text = value4 ' سعر بدون ضريبى

            'Frm_PriceList_sal.getTaxingData()

        End If

        If varcode_form = 25702 Then
            Frm_PriceList_sal.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_PriceList_sal.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_PriceList_sal.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_PriceList_sal.txt_Price.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
            Frm_PriceList_sal.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
            varcodeaccountSubProject = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        End If

        If varcode_form = 2571 Then

            Frm_LastPriceList.txt_nameItem.Text = value2

        End If
        Me.Close()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class