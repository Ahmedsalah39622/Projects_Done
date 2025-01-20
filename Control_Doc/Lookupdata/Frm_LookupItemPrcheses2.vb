Imports System.Data.OleDb

Public Class Frm_LookupItemPrcheses2


    Sub Find_Order()





        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If varopenItemSuppliser = 1 Then
            sql2 = "SELECT * FROM vw_itemprcheses2_Rented WHERE Compny_Code ='" & VarCodeCompny & "' "
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
            GridView1.Columns(0).Caption = "اذن الصرف"
            GridView1.Columns(1).Caption = "رقم الصنف"
            GridView1.Columns(2).Caption = "أسم الصنف"
            GridView1.Columns(3).Caption = "الكمية"
            GridView1.Columns(4).Caption = "الوحدة"
            GridView1.Columns(5).Caption = "المخزن"

            GridView1.Columns(6).Visible = False
            GridView1.Columns(7).Visible = False
        Else
            GridView1.Columns(0).Caption = "اذن الاضافة"
            GridView1.Columns(1).Caption = "رقم الصنف"
            GridView1.Columns(2).Caption = "أسم الصنف"
            GridView1.Columns(3).Caption = "بيان الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "المخزن"

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

        If varopenItemSuppliser = 1 Then
            Frm_Prcheses_Invoice_Rented.Com_NoAzn.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_Prcheses_Invoice_Rented.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_Prcheses_Invoice_Rented.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Frm_Prcheses_Invoice_Rented.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_Prcheses_Invoice_Rented.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
            Frm_Prcheses_Invoice_Rented.txt_Stores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
            Me.Close()
        End If

        If varopenItemSuppliser = 2 Then
            Frm_PriceListSuppliser.txt_CodeItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_PriceListSuppliser.txt_NameItem.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
            Frm_PriceListSuppliser.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
            Frm_PriceListSuppliser.txt_unit.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
            Me.Close()
        End If
    End Sub

    Private Sub Frm_LookupItemPrcheses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_Order()
    End Sub
End Class