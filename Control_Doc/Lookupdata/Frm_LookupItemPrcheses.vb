Imports System.Data.OleDb

Public Class Frm_LookupItemPrcheses


    Sub Find_Order()





        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If varopenItemSuppliser = 1 Then
            sql2 = "select * from vw_itemprcheses2 where  NOT EXISTS(SELECT Order_Stores_No ,No_Item FROM TB_Detalis_InvoicePrcheses WHERE CAST(TB_Detalis_InvoicePrcheses.Order_Stores_No AS nVARCHAR(100))=CAST(vw_itemprcheses2.Ser_NO_StoresAdd AS nVARCHAR(100) )and TB_Detalis_InvoicePrcheses.No_Item = vw_itemprcheses2.No_item ) and Compny_Code ='" & VarCodeCompny & "' "
        Else
            sql2 = "select * from vw_itemprcheses where Compny_Code ='" & VarCodeCompny & "' "
        End If

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        If varopenItemSuppliser = 1 Then
            GridView1.Columns(0).Caption = "اذن الاضافة"
            GridView1.Columns(1).Caption = "Ref"
            GridView1.Columns(2).Caption = "رقم الصنف"
            GridView1.Columns(3).Caption = "أسم الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "المخزن"

            'GridView1.Columns(7).Visible = False
            'GridView1.Columns(8).Visible = False
        Else
            GridView1.Columns(0).Caption = "اذن الاضافة"
            GridView1.Columns(1).Caption = "رقم الصنف"
            GridView1.Columns(2).Caption = "أسم الصنف"
            GridView1.Columns(3).Caption = "بيان الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "المخزن"
            GridView1.Columns(8).Caption = "رقم الحساب"
            GridView1.Columns(9).Caption = "اسم المورد"

            GridView1.Columns(7).Visible = False
        End If

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick


        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        'If varopenItemSuppliser = 1 Then
        Frm_Prcheses_Invoice.Com_NoAzn.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        varNo_Azn = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_Prcheses_Invoice.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_Prcheses_Invoice.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Frm_Prcheses_Invoice.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_Prcheses_Invoice.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Frm_Prcheses_Invoice.txt_Stores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        Frm_Prcheses_Invoice.txt_AccountNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))

        Frm_Prcheses_Invoice.txt_nameaccount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        Me.Close()
        'End If

        'If varopenItemSuppliser = 2 Then
        '    Frm_PriceListSuppliser.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        '    Frm_PriceListSuppliser.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        '    Frm_PriceListSuppliser.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        '    Frm_PriceListSuppliser.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        '    Frm_Prcheses_Invoice.txt_AccountNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        '    varNo_Azn = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        '    Frm_Prcheses_Invoice.txt_nameaccount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))

        '    Me.Close()
        'End If
    End Sub

    Private Sub Frm_LookupItemPrcheses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Order()
    End Sub
End Class