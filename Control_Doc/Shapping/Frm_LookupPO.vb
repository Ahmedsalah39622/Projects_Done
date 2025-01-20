Imports System.Data.OleDb

Public Class Frm_LookupPO

    Private Sub Frm_LookupPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_all_Order()
    End Sub

    Sub Find_all_Order()
        On Error Resume Next


        sql = "select * from vw_all_po where vw_all_po.Compny_Code = '" & VarCodeCompny & "' and Type='" & "خارجى" & "' "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم امر الشراء"
        GridView1.Columns(1).Caption = "التاريخ"
        GridView1.Columns(2).Caption = "أسم المورد"
        GridView1.Columns(3).Caption = "رقم الصنف"
        GridView1.Columns(4).Caption = "أسم الصنف"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "نوع الطلب"
        GridView1.Columns(8).Caption = "رقم طلب الشراء"
        GridView1.Columns(9).Caption = "سعر الوحدة"
        GridView1.Columns(10).Caption = "العملة"
        GridView1.Columns(11).Caption = "معامل التحويل"
        GridView1.Columns(12).Caption = "الاجمالى"
        GridView1.Columns(13).Caption = "تاريخ التوريد"

        GridView1.Columns(14).Caption = "الايميل"
        GridView1.Columns(15).Caption = "ميعاد التسليم"
        GridView1.Columns(16).Caption = "طريقة الدفع"
        GridView1.Columns(17).Caption = "الضريبة"
        GridView1.Columns(18).Caption = "الحالة"

        GridView1.Columns(14).Visible = False
        GridView1.Columns(15).Visible = False
        GridView1.Columns(16).Visible = False
        GridView1.Columns(17).Visible = False

        GridView1.Columns(8).Visible = False
        GridView1.Columns(9).Visible = False
        GridView1.Columns(10).Visible = False
        GridView1.Columns(11).Visible = False

        GridView1.Columns(19).Visible = False
        GridView1.Columns(20).Visible = False
        GridView1.Columns(21).Visible = False
        GridView1.Columns(22).Visible = False


        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_PONO.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Frm_ShData.TXt_PONO.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_ShData.Com_SuppliserName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_ShData.find_curSupliser()
        Me.Close()
    End Sub
End Class