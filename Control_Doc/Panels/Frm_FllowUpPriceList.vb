Imports ADODB

Public Class Frm_FllowUpPriceList
    Dim vartextcolume4 As String
    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        find_PriceList()
    End Sub
    Sub find_PriceList() 'اعتماد عرض السعر
        On Error Resume Next
        sql = "select * from vw_FollwUpPriceList "

        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""
            DataGridView2.Item(5, 0).Value = ""
            DataGridView2.Item(6, 0).Value = ""



        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1


                    DataGridView2.Item(0, i).Value = rs("Ser_InvoiceNo").Value
                    DataGridView2.Item(1, i).Value = rs("InvoiceDate").Value
                    DataGridView2.Item(2, i).Value = rs("Customer_Name").Value
                    DataGridView2.Item(3, i).Value = rs("AccountName").Value
                    DataGridView2.Item(4, i).Value = rs("Sum_Discount").Value
                    DataGridView2.Item(5, i).Value = rs("Sum_Total").Value
                    DataGridView2.Item(6, i).Value = rs("Invoice_Status2").Value

                    If rs("status").Value = "معتمد" Then DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Green
                    If rs("status").Value = "غير معتمد" Then DataGridView2.Rows(i).Cells(7).Style.BackColor = Color.Yellow


                    rs.MoveNext()


                Next i
                button_List()
                Exit Sub
            Next T
            rs.Close()
        End If
    End Sub
    Sub button_List() 'خصومات من الراتب



        Dim btn3 As New DataGridViewButtonColumn()

        If vartextcolume4 = "موافق" Then
        Else
            DataGridView2.Columns.Add(btn3)
            btn3.HeaderText = ""
            btn3.Text = "موافق"
            vartextcolume4 = "موافق"
            btn3.Name = "btn2"
            btn3.UseColumnTextForButtonValue = True

        End If

    


    End Sub
End Class