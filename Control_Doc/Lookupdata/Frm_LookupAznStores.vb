Imports System.Data.OleDb

Public Class Frm_LookupAznStores
    Sub Search()




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "select   * from Vw_LookupOrderStores "


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(0).Caption = "رقم الطلب"
        GridView1.Columns(1).Caption = "رقم الصنف"
        GridView1.Columns(2).Caption = "أسم الصنف"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "نوع الصرف"
        GridView1.Columns(6).Caption = "RefNo"
        'GridView1.Columns(8).Caption = "كود نوع الصرف"

        GridView1.Columns(6).Visible = False
        GridView1.Columns(7).Visible = False
        'GridView1.Columns(8).Visible = False

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

   
    Sub chooes_data()

        On Error Resume Next


        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))

        'Dim value11 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))

        'Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        'Dim value8 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))
        'Dim value9 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        'Dim value10 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        'If value7 = "مادة خام" Then
        Frm_AznSarf.txt_OrderSal.Text = value
        Frm_AznSarf.txt_CodeItem.Text = value2
        Frm_AznSarf.txt_NameItem.Text = value3
        Frm_AznSarf.txt_type.Text = value6
        'Frm_AznSarf.txt_NameItem2.Text = value4
        Frm_AznSarf.txt_Qty.Text = value5
        Frm_AznSarf.txt_unit.Text = value4
        Frm_AznSarf.fin_qyt_avalible()
        'Frm_AznSarf.txt_OrderSal.Text = value6
        'Frm_AznSarf.txt_type.Text = value7
        'Frm_AznSarf.txt_Tax.Text = value8
        'Frm_AznSarf.txt_Notes.Text = value7
        'Frm_AznSarf.txt_PriceUnit.Text = value9
        'Frm_AznSarf.txt_NameCustomer.Text = value10
        Me.Close()
        'Else
        'If GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6)) > 0 Then
        '    'Frm_AznSarf.txt_OrderSal.Text = value
        '    Frm_AznSarf.txt_CodeItem.Text = value2
        '    Frm_AznSarf.txt_NameItem.Text = value3
        '    'Frm_AznSarf.txt_NameItem2.Text = value4
        '    Frm_AznSarf.txt_Qty.Text = value5
        '    Frm_AznSarf.txt_unit.Text = value6
        '    'Frm_AznSarf.txt_Tax.Text = value8
        '    Frm_AznSarf.txt_Notes.Text = value7
        '    'Frm_AznSarf.txt_PriceUnit.Text = value9
        '    Frm_AznSarf.txt_NameCustomer.Text = value10

        '    Me.Close()

        'Else
        '    MsgBox("الصنف غير مسعر يجب تسعير الصنف لتنفيذ اذن الصرف", MsgBoxStyle.Critical, "Creative Smart Software") : Exit Sub

        'End If
        'End If
    End Sub

    Private Sub Frm_LookupOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

   

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            chooes_data()
        End If
    End Sub

   
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        chooes_data()
    End Sub
End Class