Imports ADODB

Public Class Frm_WorkingFllow

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TabPane1.SelectedPageIndex = 1
        Timer1.Stop()
        Timer3.Stop()
        Timer4.Stop()
        Timer2.Start()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        TabPane1.SelectedPageIndex = 2
        Timer1.Stop()
        Timer2.Stop()
        Timer4.Stop()
        Timer3.Start()

    End Sub

    Private Sub Frm_WorkingFllow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_JopOrder1()
        TabPane1.SelectedPageIndex = 0
        'Timer4.Start()
        'Timer3.Stop()
        'Timer2.Stop()
        'Timer1.Stop()
    End Sub
    Sub Fill_JopOrder1()
        sql2 = "   SELECT        dbo.TB_Header_JOB_Order.Order_NO, dbo.vw_AllJopOrderDatastatus.JOB_Order, dbo.vw_AllJopOrderDatastatus.JOBOrder_Date, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.BD_ITEM.Name,  " & _
   "                         dbo.TB_Header_JOB_Order.Qyt_Requrid2, dbo.BD_Unit.Name AS Unit1, dbo.TB_Header_JOB_Order.Qyt_Requrid, BD_Unit_1.Name AS Unit2, dbo.vw_AllJopOrderDatastatus.Machin,  " & _
   "                         dbo.vw_AllJopOrderDatastatus.NameItemFirst, dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_2.Name AS Unit3, dbo.vw_AllJopOrderDatastatus.statusJopOrder,  " & _
   "        dbo.vw_AllJopOrderDatastatus.status, dbo.vw_AllJopOrderDatastatus.StoresStatus " & _
   " FROM            dbo.vw_AllJopOrderDatastatus INNER JOIN " & _
   "                         dbo.TB_Header_JOB_Order ON dbo.vw_AllJopOrderDatastatus.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order INNER JOIN " & _
   "                         dbo.BD_ITEM ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
   "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_JOB_Order.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
   "                         dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
   "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit2 = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code INNER JOIN " & _
   "                         dbo.BD_Unit AS BD_Unit_2 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_2.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_2.Compny_Code "

        rs = New ADODB.Recordset
        rs.Open(sql2, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""
            DataGridView2.Item(7, 0).Value = ""
            DataGridView2.Item(8, 0).Value = ""
            DataGridView2.Item(9, 0).Value = ""
            DataGridView2.Item(10, 0).Value = ""
            DataGridView2.Item(11, 0).Value = ""
            DataGridView2.Item(12, 0).Value = ""
            DataGridView2.Item(13, 0).Value = ""

        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Item(0, i).Value = rs("Order_NO").Value
                    DataGridView2.Item(1, i).Value = rs("NameCustomer_Compny").Value
                    DataGridView2.Item(2, i).Value = rs("JOB_Order").Value
                    DataGridView2.Item(3, i).Value = rs("JOBOrder_Date").Value
                    DataGridView2.Item(4, i).Value = rs("Name").Value
                    DataGridView2.Item(5, i).Value = rs("Qyt_Requrid2").Value
                    DataGridView2.Item(6, i).Value = rs("Qyt_Requrid").Value
                    DataGridView2.Item(7, i).Value = rs("Machin").Value

                    DataGridView2.Item(8, i).Value = rs("NameItemFirst").Value
                    DataGridView2.Item(9, i).Value = rs("Qyt_FristItem2").Value
                    DataGridView2.Item(10, i).Value = rs("Qyt_FristItem").Value

                    DataGridView2.Item(11, i).Value = rs("statusJopOrder").Value
                    DataGridView2.Item(12, i).Value = rs("status").Value
                    DataGridView2.Item(13, i).Value = rs("StoresStatus").Value


                    If rs("statusJopOrder").Value = "جديد" Then DataGridView2.Rows(i).Cells(11).Style.BackColor = Color.Yellow Else DataGridView2.Rows(i).Cells(11).Style.BackColor = Color.Green
                    If rs("status").Value = "تم الفحص" Then DataGridView2.Rows(i).Cells(12).Style.BackColor = Color.Orange Else DataGridView2.Rows(i).Cells(12).Style.BackColor = Color.White
                    If rs("StoresStatus").Value = "مضاف" Then DataGridView2.Rows(i).Cells(13).Style.BackColor = Color.Gray Else DataGridView2.Rows(i).Cells(13).Style.BackColor = Color.GreenYellow


                    rs.MoveNext()


                Next i

                Exit Sub
            Next T
            rs.Close()
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        TabPane1.SelectedPageIndex = 3
        Timer2.Stop()
        Timer3.Stop()
        Timer1.Stop()
        Timer4.Start()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        TabPane1.SelectedPageIndex = 0
        Timer4.Stop()
        Timer2.Stop()
        Timer3.Stop()
        Timer1.Start()
        Fill_JopOrder1()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class