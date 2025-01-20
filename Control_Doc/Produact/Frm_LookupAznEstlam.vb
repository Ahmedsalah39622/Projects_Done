Imports System.Data.OleDb

Public Class Frm_LookupAznEstlam

    Private Sub Frm_LookupAznEstlam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

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


                sql2 = "select * from Vw_AllEstlamItemProdect "
            End If

            If OP2.Checked = True Then

                sql2 = "SELECT        dbo.TB_Detils_AznEstlam.JOB_Order, dbo.TB_Header_AznEstlam.Order_Azn_Estlam_NO, dbo.TB_Header_AznEstlam.Order_Date_Azn_Estlam, iif(dbo.TB_Header_AznEstlam.Flg_Azn_Estlam=2,'تصنيع','امر شراء') as typeazn, " & _
                        "                         dbo.TB_Detils_AznEstlam.Order_NO, dbo.TB_Detils_AznEstlam.No_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_AznEstlam.Quntity, dbo.BD_Unit.Name AS Unit " & _
                        " FROM            dbo.TB_Header_AznEstlam INNER JOIN " & _
                        "                         dbo.TB_Detils_AznEstlam ON dbo.TB_Header_AznEstlam.Ser_Azn_Estlam = dbo.TB_Detils_AznEstlam.Ser_Azn_Estlam AND  " & _
                        "                         dbo.TB_Header_AznEstlam.Compny_Code = dbo.TB_Detils_AznEstlam.Compny_Code INNER JOIN " & _
                        "                         dbo.BD_ITEM ON dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_AznEstlam.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
                        "                         dbo.BD_Unit ON dbo.TB_Detils_AznEstlam.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_Unit.Compny_Code  where dbo.TB_Header_AznEstlam.Flg_Azn_Estlam=2 "

            End If

            If OP3.Checked = True Then
                sql2 = "SELECT        dbo.TB_Detils_AznEstlam.JOB_Order, dbo.TB_Header_AznEstlam.Order_Azn_Estlam_NO, dbo.TB_Header_AznEstlam.Order_Date_Azn_Estlam, iif(dbo.TB_Header_AznEstlam.Flg_Azn_Estlam=1,'تصنيع','امر شراء') as typeazn, " & _
                "                         dbo.TB_Detils_AznEstlam.Order_NO, dbo.TB_Detils_AznEstlam.No_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_AznEstlam.Quntity, dbo.BD_Unit.Name AS Unit " & _
                " FROM            dbo.TB_Header_AznEstlam INNER JOIN " & _
                "                         dbo.TB_Detils_AznEstlam ON dbo.TB_Header_AznEstlam.Ser_Azn_Estlam = dbo.TB_Detils_AznEstlam.Ser_Azn_Estlam AND  " & _
                "                         dbo.TB_Header_AznEstlam.Compny_Code = dbo.TB_Detils_AznEstlam.Compny_Code INNER JOIN " & _
                "                         dbo.BD_ITEM ON dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_AznEstlam.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
                "                         dbo.BD_Unit ON dbo.TB_Detils_AznEstlam.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_AznEstlam.Compny_Code = dbo.BD_Unit.Compny_Code "


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
            GridView1.Columns(0).Caption = "رقم أمر الشغل"
            GridView1.Columns(1).Caption = "رقم اذن الاستلام"
            GridView1.Columns(2).Caption = "تاريخ اذن الاستلام"
            GridView1.Columns(3).Caption = "رقم الطلبية"
            GridView1.Columns(4).Caption = "رقم الصنف"
            GridView1.Columns(5).Caption = "أسم الصنف"
            GridView1.Columns(6).Caption = "عدد الرولات"
            GridView1.Columns(7).Caption = "الوحدة"
            GridView1.Columns(8).Caption = "الكمية بالكيلو"
            GridView1.Columns(9).Caption = "الوحدة بالكيلو"
            GridView1.Columns(10).Caption = "الماكينة"
            GridView1.Columns(11).Caption = "نوع الصنف"

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True

            GridView1.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()


            GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        End If





        'GridView1.OptionsSelection.
    End Sub

  

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        Search()
    End Sub

   

    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        Search()
    End Sub

  

    Private Sub OP3_Click(sender As Object, e As EventArgs) Handles OP3.Click
        Search()
    End Sub

    

    
   
    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        fill_Detials_JopOrder()
        'Total_Sum1()
        txt_Unit_Kilo1.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        txt_QtyRequird2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        txt_Unit_Kilo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        Total_Sum2()
    End Sub
    Sub Total_Sum1()
        ''find_tax()
        'Dim total As Single
        'For i As Integer = 0 To GridView1.RowCount - 1
        '    total += GridView1.GetRowCellValue(i, GridView1.Columns(8))

        'Next
        'txt_QtyRequird2.Text = Math.Round(total, 2)

    End Sub
    Sub Total_Sum2()
        'find_tax()
        On Error Resume Next
        Dim total2 As Single
        For i As Integer = 0 To GridView3.RowCount - 1
            total2 += GridView3.GetRowCellValue(i, GridView3.Columns(4))

        Next
        txt_QtyRequird3.Text = Math.Round(total2, 2)

    End Sub
    Sub fill_Detials_JopOrder()


        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "    SELECT        JOB_Order, SerialNo, LIGHT_ROLL, WIGHT_ROLL, NET_KG_ROLL, Thickness, Notes        FROM dbo.TB_Detils_QualityAprove WHERE        (JOB_Order = '" & GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) & "') AND (Compny_Code = '" & VarCodeCompny & "')"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "100"
        GridView3.Columns(2).Width = "50"
        GridView3.Columns(3).Width = "50"
        GridView3.Columns(4).Width = "50"
        GridView3.Columns(5).Width = "50"
        GridView3.Columns(6).Width = "200"

        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "رقم امر الشغل "
        GridView3.Columns(1).Caption = "رقم Searil"
        GridView3.Columns(2).Caption = "الطول"
        GridView3.Columns(3).Caption = "العرض"
        GridView3.Columns(4).Caption = "الوزن"
        GridView3.Columns(5).Caption = "السمك"
        GridView3.Columns(6).Caption = "ملاحظات"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        'Frm_Azn_AddItem.txt_NoJopOrder.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        'Frm_Azn_AddItem.txt_ِAznno.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        'Frm_Azn_AddItem.Com_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        'Frm_Azn_AddItem.txt_QytItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        'Frm_Azn_AddItem.Txt_UnitItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))

        'Frm_Azn_AddItem.txt_QytItem2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        'Frm_Azn_AddItem.Txt_UnitItem2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        'Frm_Azn_AddItem.txt_MachinName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(10))
        Frm_Azn_AddItem.Com_TypeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))

    

        Me.Close()
    End Sub
End Class