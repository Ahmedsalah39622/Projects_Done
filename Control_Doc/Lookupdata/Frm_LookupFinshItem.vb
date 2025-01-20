Imports System.Data.OleDb

Public Class Frm_LookupFinshItem

    Private Sub Frm_LookupFinshItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'find_data()
    End Sub
    Sub find_data()
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select Ex_Item,Name,Qyt_Requrid,unit,Qyt_FristItem2,UnitKilo,Order_NO,JOB_Order  from Vw_ItmeFinshLookup where Compny_Code ='" & VarCodeCompny & "' "


        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "أسم الصنف"
        GridView1.Columns(2).Caption = "عدد الرولات"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "الكمية بالكيلو"
        GridView1.Columns(5).Caption = "الوحدة بالكيلو"
        GridView1.Columns(6).Caption = "الطلبية"
        GridView1.Columns(7).Caption = "رقم امر الانتاج"


       

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Sub find_data2()
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select *  from vw_POALL where Compny_Code ='" & VarCodeCompny & "' "



        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"

     
            GridView1.Columns(0).Caption = "رقم الصنف"
            GridView1.Columns(1).Caption = "أسم الصنف"
            GridView1.Columns(2).Caption = "الكمية1"
            GridView1.Columns(3).Caption = "الوحدة1"
            GridView1.Columns(4).Caption = "الكمية2"
            GridView1.Columns(5).Caption = "الوحدة2"
            GridView1.Columns(6).Caption = "رقم أمر الشراء"
            GridView1.Columns(7).Caption = "رقم طلبية الشراء"
            GridView1.Columns(8).Caption = "نوع أمر الشراء"
        GridView1.Columns(9).Visible = False



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs)
      
    End Sub

   
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        Frm_AznEstlamItem.txt_ItemName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Frm_AznEstlamItem.txt_Unit2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Frm_AznEstlamItem.txt_Qty.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Frm_AznEstlamItem.txt_OrderNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        Frm_AznEstlamItem.txt_NoJopOrder.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))


        Frm_AznEstlamItem.txt_Qty2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_AznEstlamItem.txt_Unit_Kilo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Me.Close()
    End Sub
End Class