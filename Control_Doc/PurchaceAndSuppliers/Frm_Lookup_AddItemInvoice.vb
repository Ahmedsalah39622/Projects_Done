Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
'Imports DevExpress.XtraGrid.Columns.GridColumn
Imports System.Windows.Forms.DataGridViewCheckBoxColumn
Imports System.Windows.Forms
Public Class Frm_Lookup_AddItemInvoice
    Dim value As String
    Dim valueCustomerNo As String
    Dim valueSalseNo As Integer
    Sub Search()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            'sql2 = "select   Order_Stores_NO, Order_NO, NO_OrderSal, No_Item, Ex_Item,NameItem,TypeItem, Quntity, Unit, AccountName,  Emp_Name,Price_Unit,Name,Rat_Cur,TotalItem,NameStores from Vw_Lookup_AznSarf where Compny_Code ='" & VarCodeCompny & "' "
            If OP1.Checked = True Then
                'sql2 = "select * from Vw_All_AznAddItem where Compny_Code = '" & VarCodeCompny & "' and FlagItemType ='" & 1 & "'  "

                sql2 = "   SELECT        Ser_NO_StoresAdd, NO_FahsEstlamOrder, Date_StoresAdd, Code_Supliser, Name, No_Item, NameItem, Quntity, Unit, Price_Item, Rat, Cur, Total_Item, Stores, Compny_Code, Ext_InvoiceNo " & _
   " FROM            dbo.Vw_All_AznAddItem " & _
   " WHERE        (Ext_InvoiceNo IS NULL) AND (Compny_Code = '" & VarCodeCompny & "') "
            End If

            If OP2.Checked = True Then
                sql2 = "   SELECT        Ser_NO_StoresAdd, NO_FahsEstlamOrder, Date_StoresAdd, Code_Supliser, Name, No_Item, NameItem, Quntity, Unit, Price_Item, Rat, Cur, Total_Item, Stores, Compny_Code, Ext_InvoiceNo " & _
   " FROM            dbo.Vw_All_AznAddItem " & _
   " WHERE        (Ext_InvoiceNo IS NOT NULL) AND (Compny_Code = '" & VarCodeCompny & "') "


            End If

            If OP3.Checked = True Then
                sql2 = "   SELECT        Ser_NO_StoresAdd, NO_FahsEstlamOrder, Date_StoresAdd, Code_Supliser, Name, No_Item, NameItem, Quntity, Unit, Price_Item, Rat, Cur, Total_Item, Stores, Compny_Code, Ext_InvoiceNo " & _
   " FROM            dbo.Vw_All_AznAddItem " & _
   " WHERE       (Compny_Code = '" & VarCodeCompny & "') "


            End If
            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            'GridView1.Columns(0).ColumnEdit = CheckBox.CheckBoxAccessibleObject
            GridView1.Columns(0).Caption = " اذن الاضافة"
            GridView1.Columns(1).Caption = "رقم أمر الشراء"
            GridView1.Columns(2).Caption = "التاريخ"
            GridView1.Columns(3).Caption = "رقم الحساب"
            GridView1.Columns(4).Caption = "المورد"
            GridView1.Columns(5).Caption = "رقم الصنف"
            GridView1.Columns(6).Caption = "أسم الصنف"
            GridView1.Columns(7).Caption = "الكمية"
            GridView1.Columns(8).Caption = "الوحدة"
            GridView1.Columns(9).Caption = "السعر"
            GridView1.Columns(10).Caption = "معامل التحويل"
            GridView1.Columns(11).Caption = "العملة"
            GridView1.Columns(12).Caption = "الاجمالى"
            GridView1.Columns(13).Caption = "المخزن"
         

            GridView1.Columns(14).Visible = False
            GridView1.Columns(15).Visible = False

            'GridView1.Columns(1).Visible = False
            'GridView1.Columns(6).Visible = False
            'GridView1.Columns(4).Visible = False
            'GridView1.Columns(12).Visible = False
            'GridView1.Columns(13).Visible = False
            'GridView1.Columns(17).Visible = False
            'GridView1.Columns(18).Visible = False


            'GridView1.Columns(19).Visible = False
            'GridView1.Columns(20).Visible = False
            'GridView1.Columns(21).Visible = False

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True


            'GridView1.Columns(16).AppearanceCell.BackColor = Color.DarkGray
            'GridView1.Columns(16).AppearanceCell.ForeColor = Color.Red


            'GridView1.Columns(0).Width = "100"
            'GridView1.Columns(1).Width = "100"
            'GridView1.Columns(2).Width = "75"
            'GridView1.Columns(3).Width = "75"
            'GridView1.Columns(4).Width = "100"
            'GridView1.Columns(5).Width = "200"
            'GridView1.Columns(6).Width = "100"
            'GridView1.Columns(7).Width = "70"
            'GridView1.Columns(8).Width = "75"
            'GridView1.Columns(9).Width = "150"
            'GridView1.Columns(10).Width = "150"
            'GridView1.Columns(11).Width = "75"
            'GridView1.Columns(12).Width = "100"
            'GridView1.Columns(13).Width = "100"
            'GridView1.Columns(14).Width = "160"
            'GridView1.Columns(15).Width = "100"
            'GridView1.Columns(16).Width = "100"
            'GridView1.Columns(17).Width = "100"
            'GridView1.Columns(18).Width = "100"
            GridView1.BestFitColumns()
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()

            GridView1.Columns(14).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            'GridView1.Columns(15).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        End If



        'GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        'GridView1.Columns.ColumnByFieldName("IsSelected").Visible = False
        'GridView1.OptionsSelection.CheckBoxSelectorField = "IsSelected"

        'GridView1.OptionsSelection.
    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)

        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1

    End Sub


    Sub Search2()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql2 = "SELECT        dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) AS RemBalance,  " & _
            "                         dbo.BD_Stores.Name AS NameStores, dbo.BD_Unit.Name AS NameUnit, dbo.Statement_OfItem.Barcode_No, dbo.Tb_TypeItemList.Name AS TypeItem, dbo.BD_ITEM.PriceSal, dbo.BD_ITEM.Discount_Item " & _
            " FROM            dbo.Statement_OfItem INNER JOIN " & _
            "                         dbo.BD_ITEM ON dbo.Statement_OfItem.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_ITEM.Code INNER JOIN " & _
            "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code INNER JOIN " & _
            "                         dbo.Tb_TypeItemList ON dbo.BD_ITEM.TypeItemList2 = dbo.Tb_TypeItemList.Code INNER JOIN " & _
            "                         dbo.BD_Unit ON dbo.BD_ITEM.Unit1 = dbo.BD_Unit.Code " & _
            " GROUP BY dbo.Statement_OfItem.NoItem, RTRIM(dbo.BD_ITEM.Ex_Item), dbo.BD_ITEM.Name, dbo.BD_Stores.Name, dbo.Statement_OfItem.Barcode_No, dbo.Tb_TypeItemList.Name, dbo.BD_ITEM.PriceSal,  " & _
            "            dbo.BD_ITEM.Discount_Item, dbo.BD_Unit.Name " & _
            "            HAVING(SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import) > 0) "


            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"


            GridView1.Columns(0).Caption = "رقم الصنف"
            GridView1.Columns(1).Caption = "الرقم التوصيفى"
            GridView1.Columns(2).Caption = "أسم الصنف"
            GridView1.Columns(3).Caption = "الكمية المتاحة"
            GridView1.Columns(4).Caption = "أسم المخزن"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "الباركود"
            GridView1.Columns(7).Caption = " نوع الصنف"
            GridView1.Columns(8).Caption = "سعر الصنف"
            GridView1.Columns(9).Caption = "نسبة الخصم"

            GridView1.Columns(0).Width = "100"
            GridView1.Columns(1).Width = "100"
            GridView1.Columns(2).Width = "250"
            GridView1.Columns(3).Width = "100"
            GridView1.Columns(4).Width = "150"
            GridView1.Columns(5).Width = "100"
            GridView1.Columns(6).Width = "100"
            GridView1.Columns(7).Width = "100"
            GridView1.Columns(8).Width = "100"
            GridView1.Columns(9).Width = "100"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub


    Private Sub Frm_Lookup_AznSarf_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub


    'Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    Dim view As GridView = TryCast(sender, GridView)
    '    Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
    '    If hitInfo.HitTest = GridHitTest.ColumnButton Then
    '        view.SelectAll()
    '    End If
    'End Sub
    Private Sub GridView1_RowStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        'If GridView1.IsRowSelected(e.RowHandle) Then
        '    e.Appearance.Assign(GridView1.PaintAppearance.SelectedRow)
        '    e.HighPriority = True

        'End If


        'If GridView1.IsRowSelected(e.RowHandle) = True Then
        'Else
        'End If
    End Sub

    Private Sub Frm_Lookup_AznSarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Search()
        CustomDrawRowIndicator(GridControl1, GridView1)
        'find_detalis()
        'GridView1.OptionsSelection.MultiSelect = True
    End Sub
    'Sub select_rows()
    '    Dim Rows As New ArrayList()

    '    ' Add the selected rows to the list. 
    '    Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
    '    Dim I As Integer
    '    For I = 0 To selectedRowHandles.Length - 1
    '        Dim selectedRowHandle As Int32 = selectedRowHandles(I)
    '        If (selectedRowHandle >= 0) Then
    '            Rows.Add(GridView1.GetDataRow(selectedRowHandle))
    '        End If
    '    Next
    '    Try
    '        GridView1.BeginUpdate()
    '        For I = 0 To Rows.Count - 1
    '            Dim Row As DataRow = CType(Rows(I), DataRow)
    '            ' Change the field value. 
    '            Row("Discontinued") = True
    '        Next
    '    Finally
    '        GridView1.EndUpdate()
    '    End Try
    'End Sub

    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
    End Sub




    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        Search()
    End Sub

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        Search()
    End Sub

    Private Sub OP3_Click(sender As Object, e As EventArgs) Handles OP3.Click
        Search()
    End Sub






    Private Sub GridControl1_DoubleClick2(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick


        '    If value9 <> "" Then MsgBox("الصنف  يوجد علية فاتورة لايمكن اضافة مرة اخرى", MsgBoxStyle.Critical, "Css") : Exit Sub

        '    Frm_Prcheses_Invoice.Com_NoAzn.Text = value
        '    Frm_Prcheses_Invoice.txt_CodeItem.Text = value3
        '    Frm_Prcheses_Invoice.txt_NameItem.Text = value4
        '    Frm_Prcheses_Invoice.txt_Qty.Text = value5
        '    Frm_Prcheses_Invoice.txt_nameaccount.Text = value6
        '    Frm_Prcheses_Invoice.txt_NameSalse.Text = value7
        '    Frm_Prcheses_Invoice.txt_unit.Text = value8



        '    Frm_Prcheses_Invoice.txt_Price.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        '    Frm_Prcheses_Invoice.com_Cru.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        '    Frm_Prcheses_Invoice.txt_rat.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(13))
        '    Frm_Prcheses_Invoice.Txt_Total.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(14))
        '    Frm_Prcheses_Invoice.txt_Stores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(15))


        '    Me.Close()

        'End If


        'If typeInvoice = 2 Then
        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        '    Frm_Prcheses_Invoice.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        '    Frm_Prcheses_Invoice.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        '    Frm_Prcheses_Invoice.txt_AvQty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        '    Frm_Prcheses_Invoice.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        '    Frm_Prcheses_Invoice.txt_Stores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        '    'Frm_Prcheses_Invoice.txt_unit.Text = value8
        '    Me.Close()

        'End If

        Select_data()
        Search()
    End Sub
    Sub Select_data()
        On Error Resume Next
        'If typeInvoice = 1 Then
        Dim value9 As String
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim value33 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(21))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(10))
        Dim value8 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        Dim value88 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        valueCustomerNo = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        valueSalseNo = "1"

        value9 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(16))

        Dim value19 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(19))
        Dim value20 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(20))
        Dim value11 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
        Dim value13 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(13))

        '==============================================SaveInvoice

        Dim dd As DateTime = Frm_Prcheses_Invoice.txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_InvoicePrcheses where Ser_InvoiceNo  = " & varNoInvoice & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            last_Data()

            sql = "INSERT INTO TB_Header_InvoicePrcheses (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status) " & _
                      " values  ('" & varNoInvoice & "' ,'" & VarCodeCompny & "','" & varNoInvoice2 & "','" & vardateoder & "','" & valueCustomerNo & "','" & valueSalseNo & "','" & 0 & "','" & 0 & "')"
            Cnn.Execute(sql)

        End If

        '==================savedetils

        sql = "select * from TB_Detalis_InvoicePrcheses where Ser_InvoiceNo  = " & varNoInvoice & "  and Compny_Code ='" & VarCodeCompny & "' and No_Item ='" & value4 & "' and Order_Stores_No ='" & value & "'   "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else
            Dim totalItem_var As Single
            'totalItem_var = Math.Round(Val(value5) * Val(value11), 2)
            sql2 = "INSERT INTO TB_Detalis_InvoicePrcheses (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Code_cur,Rat_Invoice,Total_Item) " & _
          " values  ('" & value & "','" & varNoInvoice & "','" & varNoInvoice2 & "','" & VarCodeCompny & "','" & value4 & "','" & value5 & "','" & 1 & "','" & 0 & "','" & 1 & "','" & value6 & "','" & 1 & "','" & value7 & "','" & value88 & "')"
            Cnn.Execute(sql2)
        End If

        'GridView1.Columns(0).Caption = " اذن الاضافة"
        'GridView1.Columns(1).Caption = "رقم أمر الشراء"
        'GridView1.Columns(2).Caption = "التاريخ"
        'GridView1.Columns(3).Caption = "رقم الحساب"
        'GridView1.Columns(4).Caption = "المورد"
        'GridView1.Columns(5).Caption = "رقم الصنف"
        'GridView1.Columns(6).Caption = "أسم الصنف"
        'GridView1.Columns(7).Caption = "الكمية"
        'GridView1.Columns(8).Caption = "الوحدة"
        'GridView1.Columns(9).Caption = "السعر"
        'GridView1.Columns(10).Caption = "معامل التحويل"
        'GridView1.Columns(11).Caption = "العملة"
        'GridView1.Columns(12).Caption = "الاجمالى"
        'GridView1.Columns(13).Caption = "المخزن"


        find_detalis()
    End Sub


    Sub last_Data()

        sql = "  SELECT        MAX(Ser_InvoiceNo) AS MaxMaim,Compny_Code FROM            TB_Header_InvoicePrcheses    GROUP BY Compny_Code  HAVING        (MAX(Ser_InvoiceNo) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varNoInvoice = rs("MaxMaim").Value + 1
            varNoInvoice2 = "INV000" + Frm_Prcheses_Invoice.Com_InvoiceNo.Text

        Else
            varNoInvoice = 1
            varNoInvoice2 = "INV000" + "1"


        End If



    End Sub
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click




        '  sql = "INSERT INTO TB_Header_InvoicePrcheses (Ser_InvoiceNo, Compny_Code,Ext_InvoiceNo,InvoiceDate,Customer_No,Salse_No,Invoice_Type,Invoice_Status,Notes) " & _
        '    " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','" & 0 & "','" & 0 & "','" & txt_Notes.Text & "')"
        '  Cnn.Execute(sql)


        '  sql = "INSERT INTO TB_Detalis_InvoicePrcheses (Order_Stores_No,Ser_InvoiceNo,Ext_InvoiceNo,Compny_Code,No_Item,Ex_Item,Quntity,Code_Unit,Flag_Item,Code_Stores,Price_Item,Discount_Item,Value_Discount,Total_Item,Code_cur,Rat_Invoice) " & _
        '" values  ('" & Com_NoAzn.Text & "','" & Com_InvoiceNo.Text & "','" & Com_InvoiceNo2.Text & "','" & VarCodeCompny & "','" & txt_CodeItem.Text & "','" & varcodeExitem & "','" & txt_Qty.Text & "','" & varcodunit & "','" & 0 & "','" & varcodStores & "','" & txt_Price.Text & "','" & Txt_Discount.Text & "','" & txt_valuediscount.Text & "','" & Txt_Total.Text & "','" & varcode_Cru & "','" & txt_rat.Text & "')"
        '  Cnn.Execute(sql)
        'GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        'GridView1.SelectRow(0)


        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'For i As Integer = 0 To GridView1.RowCount - 1
        '    If GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) = True Then
        'rows.Add(gridView1.GetRow(i))  
        'GridView1.SelectRow(i)
        'If GridView1.IsRowSelected(i) = False Then
        '    Select_data()
        'End If
        '    End If
        'Next i

        'If GridView1.se = True Then
        '    Select_data()
        'Else
        'End If
        'Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        'checkCol.HeaderText = "CheckBox Column"

        '' Add this column to the DataGridView
        'GridView1.Columns.Add(checkCol)



        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        '' ''For i As Integer = 0 To GridView1.RowCount - 1
        'If GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) = True Then


        '    Select_data()

        '    '    'If GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect = True Then

        'Else

        'End If
        'Next i

        'If Then
        'Else

        'End If
        'GridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = False
        'Dim xx As String
        'xx = GridView1.GetSelectedRows(0)

        'GridView1.GetSelectedRows(0) = True
        'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        'checkBoxColumn.Name = "DiscontinuedColumn"
        ''checkBoxColumn.f = "Discontinued"
        'checkBoxColumn.HeaderText = "Discontinued?"
        'GridView1.Columns.Add()

        'If checkBoxColumn.Selected = True Then
        'Else
        'End If
        'Dim edit As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()  
        'Dim trueValue As Int64 = 1
        'Dim falseValue As Int64 = 0
        'edit.ValueChecked = trueValue
        'edit.ValueUnchecked = falseValue
        'GridView1.Columns("TickMark").ColumnEdit = edit
        'GridView1.RepositoryItems.Add(edit)
        'Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        ''Dim visibleRowHandle2 As Integer = GridView1.FocusedColumnChanged
        'If GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) = True Then

        'End If
        'GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect

        'Dim visarep = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        'visarep.ValueChecked = True
        ''visarep.ValueUnchecked = 0
        'visarep.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard

        'Me.GridView1.Columns(0).ColumnEdit = visarep
        ''Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        ''GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) = True
        'CBool(GridView.GetRowCellValue(iRow, "ColumnsName")) = True




        'Dim Rows As New ArrayList()
        'Dim I As Integer
        'For I = 0 To GridView1.SelectedRowsCount() - 1
        'If (GridView1.GetSelectedRows()(I) >= 0) Then
        '        Rows.Add(GridView1.GetDataRow(GridView1.GetSelectedRows()(I)))
        '    Else

        '    End If
        'Next


        'For I = 0 To Rows.Count - 1
        '    '    Dim Row As DataRow = CType(Rows(I), DataRow)

        '    Dim CellValue As String
        '    CellValue = GridView1.GetRowCellValue(Row(I), "name")

        'Next
    End Sub
    'Private Sub GridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridView1.CellContentClick

    '    MsgBox("Estado: " & GridView1.GetSelectedRows(e.RowIndex)).

    'End Sub

    'Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim view = TryCast(sender, GridView)
    '    If view.FocusedRowHandle = GridControl.AutoFilterRowHandle AndAlso view.FocusedColumn.FieldName = "Var1" Then
    '    (TryCast(view.ActiveEditor, CheckEdit)).Properties.AllowGrayed = False  
    '    End If
    'End Sub




    'Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
    '    Dim view As GridView = TryCast(sender, GridView)
    '    GridView3.SetRowCellValue(e.RowHandle, GridView1.Columns(0), 1)
    '    GridView3.SetRowCellValue(e.RowHandle, GridView1.Columns(1), 2)
    '    GridView3.SetRowCellValue(e.RowHandle, GridView1.Columns(2), 3)
    'End Sub


    Private Sub Cmd_AddInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_AddInvoice.Click
        Frm_Prcheses_Invoice.find_hedar()
        Frm_Prcheses_Invoice.find_detalis()
        Frm_Prcheses_Invoice.find_Invoice_Condation()
        Frm_Prcheses_Invoice.Total_Sum()
        Me.Close()

    End Sub

    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT       Order_Stores_No, No_Item, Ex_Item, Name, Quntity, Unit, NameStores, Price_Item,Name_Cru,Rat_Invoice, Discount_Item, Value_Discount, Total_Item, TypeItem, Order_Stores_No, SalseOrder_No     FROM dbo.Vw_DetilsInvoice2" & _
            " where  (dbo.Vw_DetilsInvoice2.Ext_InvoiceNo = '" & varNoInvoice3 & "') AND (dbo.Vw_DetilsInvoice2.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "100"
        GridView3.Columns(2).Width = "100"
        GridView3.Columns(3).Width = "200"
        GridView3.Columns(4).Width = "70"
        GridView3.Columns(5).Width = "120"
        GridView3.Columns(6).Width = "120"
        GridView3.Columns(7).Width = "70"
        GridView3.Columns(8).Width = "60"
        GridView3.Columns(9).Width = "100"
        GridView3.Columns(10).Width = "50"
        GridView3.Columns(11).Width = "100"
        GridView3.Columns(12).Width = "120"
        GridView3.Columns(13).Width = "70"


        'GridView3.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView3.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True


        GridView3.Columns(0).Caption = "رقم اذن الاضافة"
        GridView3.Columns(1).Caption = "رقم الصنف"
        GridView3.Columns(2).Caption = "الرقم التوصيفى "
        GridView3.Columns(3).Caption = "الصنف"
        GridView3.Columns(4).Caption = "الكمية"
        GridView3.Columns(5).Caption = "الوحدة"
        GridView3.Columns(6).Caption = "المخزن"
        GridView3.Columns(7).Caption = "سعر الوحدة"
        GridView3.Columns(8).Caption = "العملة"
        GridView3.Columns(9).Caption = "م التحويل"
        GridView3.Columns(10).Caption = "نسبة الخصم"
        GridView3.Columns(11).Caption = "قيمة الخصم"
        GridView3.Columns(12).Caption = "الاجمالى"
        'GridView3.Columns(12).Caption = "نوع الصنف"
        GridView3.Columns(14).Caption = "رقم الاذن"
        GridView3.Columns(15).Caption = "رقم الطلبية"


        GridView3.Columns(15).Visible = False
        GridView3.Columns(14).Visible = False
        GridView3.Columns(13).Visible = False
        GridView3.Columns(10).Visible = False
        GridView3.Columns(11).Visible = False
        GridView3.Columns(9).Visible = False

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView3.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'Mainmune.finwatinoderItem()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Frm_Prcheses_Invoice.find_hedar()
        Frm_Prcheses_Invoice.find_detalis()
        Frm_Prcheses_Invoice.find_Invoice_Condation()
        Frm_Prcheses_Invoice.Total_Sum()

        Me.Close()
    End Sub



    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim x As String
        x = MsgBox("هل تريد مسح الصنف", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
                Dim Value_ItemNo = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
                Dim Value_Aznno = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))


                sql = "Delete TB_Detalis_InvoicePrcheses  WHERE Ext_InvoiceNo ='" & varNoInvoice2 & "' and No_Item ='" & Value_ItemNo & "' and Order_Stores_No ='" & Value_Aznno & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم مسح الصنف  ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
                find_detalis()
                Search()
        End Select

    End Sub





    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs) Handles OP2.CheckedChanged

    End Sub
End Class