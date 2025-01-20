Imports System.Data.OleDb

Public Class Frm_LookupOrderItem
    Sub Search()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            
            sql2 = "select   Order_NO, No_Item, Ex_Item, NameItem, Quntity, Unit,Price_Unit,Name,Tax,Notes from Vw_LookupOrderItem10 where Compny_Code ='" & VarCodeCompny & "' "


            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"

            GridView1.Columns(0).Caption = "رقم الطلبية"
            GridView1.Columns(1).Caption = "رقم الصنف"
            GridView1.Columns(2).Caption = "رقم التوصيفى"
            GridView1.Columns(3).Caption = "أسم الصنف"
            GridView1.Columns(4).Caption = "الكمية"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "سعر الوحدة"
            GridView1.Columns(7).Caption = "العميل"
            GridView1.Columns(8).Caption = "الموافقة"
            GridView1.Columns(9).Caption = "الملاحظات"

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True
            GridView1.BestFitColumns()
           

            GridView1.Columns(2).Visible = False
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        
    End Sub

    

  

    Private Sub Frm_LookupOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

   
   
    
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        Dim value8 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
        Dim value9 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(9))

        'Frm_OrderItem.txt_OrderSal.Text = value
        Frm_OrderItem.txt_CodeItem.Text = value2
        'Frm_OrderItem.txt_OrderSal.Text = value3
        Frm_OrderItem.txt_NameItem.Text = value4
        Frm_OrderItem.txt_Qty.Text = value5
        Frm_OrderItem.txt_unit.Text = value6

        'Frm_OrderItem.txt_NameCustomer.Text = value7
        'Frm_OrderItem.txt_StatusTax.Text = value8
        Frm_OrderItem.txt_Notes.Text = value9
        Me.Close()
        'Else
        'MsgBox("الصنف غير مسعر يجب تسعير الصنف لتنفيذ طلب الصرف", MsgBoxStyle.Critical, "Creative Smart Software") : Exit Sub

        'End If
    End Sub
End Class