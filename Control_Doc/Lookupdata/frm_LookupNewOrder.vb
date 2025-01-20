Imports System.Data.OleDb

Public Class frm_LookupNewOrder

    Private Sub frm_LookupNewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Sub Search()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()



        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If VarOpenlookup = 11111 Then

            'If op1.Checked = True Then
            '    sql2 = "SELECT  * FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'  and Order_NO_chek IS NOT NULL order by Order_Ser "

            'End If

            'If op2.Checked = True Then
            '    sql2 = "SELECT  * FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'  and Order_NO_chek IS NULL order by Order_Ser "

            'End If


            sql2 = "SELECT  * FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'  and Order_Ser like '" & txt_OrderSal.Text & "%'  order by Order_Ser "

        End If

        If VarOpenlookup = 11112 Then

            sql2 = "SELECT Code,Name,GM FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'  "

        End If

        If VarOpenlookup = 111123 Then

            sql2 = "SELECT Code,Name,GM FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'  "

        End If

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        If VarOpenlookup = 11111 Then
            GridView1.Columns(0).Caption = "رقم التوريد"
            GridView1.Columns(1).Caption = "أمر التوريد"
            GridView1.Columns(2).Caption = "التاريخ"
            GridView1.Columns(3).Caption = "اسم العميل"
            GridView1.Columns(4).Caption = "المندوب"
            GridView1.Columns(5).Caption = "رقم الصنف"
            GridView1.Columns(6).Caption = "اسم الصنف"
            GridView1.Columns(7).Caption = "الكمية"
            GridView1.Columns(8).Caption = "الوحدة"
            GridView1.Columns(10).Caption = "سعر الوحدة"

            GridView1.Columns(11).Caption = "الكمية المنصرفة"
            GridView1.Columns(12).Caption = "وحدة الصرف"
            GridView1.Columns(13).Caption = "اذن الصرف"
            GridView1.Columns(14).Caption = "نوع الحركة"





            GridView1.Columns(9).Visible = False
            'GridView1.Columns(11).Visible = False
            GridView1.Columns(10).Visible = False
            GridView1.Columns(1).Visible = False
        End If

        If VarOpenlookup = 11112 Then
            GridView1.Columns(0).Caption = "رقم الصنف"
            GridView1.Columns(1).Caption = "اسم الصنف"
            GridView1.Columns(2).Caption = "مجموعة الصنف"


        End If

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
      
    End Sub


    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If VarOpenlookup = 11111 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            Dim value1 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3)) 'أسم العميل
            Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4)) 'المندوب
            Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5)) 'رقم الصنف
            Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6)) 'أسم الصنف
            Dim value8 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7)) 'الكمية
            Dim value9 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8)) 'الوحدة
            Dim value10 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(10)) 'السعر
            Dim value14 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(14))

            If value14 = "منصرف" Then
                MsgBox("لقد تم صرف امر التوريد مسبقا ", MsgBoxStyle.Critical, "امر التوريد")
                Exit Sub
            End If


            'Frm_AznSarf2.txt_OrderSal.Text = value1
            Frm_AznSarf2.txt_OrderSal.Text = value2
            'Frm_AznSarf2.txt_CodeItem.Text = value6
            'Frm_AznSarf2.txt_NameItem.Text = value7
            'Frm_AznSarf2.txt_NameNewItem.Text = value7
            'Frm_AznSarf2.txt_Qty.Text = value8
            'Frm_AznSarf2.txt_unit.Text = value9
            Frm_AznSarf2.txt_NameCustomer.Text = value4
            Frm_AznSarf2.txt_price.Text = value10
            '=======================================================الفعلى
            Frm_AznSarf2.txt_CodeItem.Text = value6
            Frm_AznSarf2.txt_NameItem.Text = value7
            Frm_AznSarf2.txt_Qty.Text = value8
            Frm_AznSarf2.txt_unit.Text = value9
            '===============================================================
            Frm_AznSarf2.find_codeGroup_Item()
        End If

        If VarOpenlookup = 11112 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) 'رقم الصنف
            Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1)) 'أسم الصنف


            'Frm_AznSarf2.txt_CodeItem.Text = value6
            'Frm_AznSarf2.txt_NameItem.Text = value7
            'Frm_AznSarf2.txt_NameNewItem.Text = value7

        End If


        If VarOpenlookup = 111123 Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

            Dim value6 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0)) 'رقم الصنف
            Dim value7 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1)) 'أسم الصنف


            Frm_Azn_AddItem2.txt_codeItem.Text = value6
            Frm_Azn_AddItem2.Com_NameItem.Text = value7
            Frm_Azn_AddItem2.Txt_New_NameItem.Text = value7

        End If
        Frm_AznSarf2.find_NotesItem()
        Frm_AznSarf2.find_CondationOrder()
        'Frm_AznSarf2.find_Gard1()
        Frm_AznSarf2.find_Gard2()
        'Frm_AznSarf2.Qyt_rem()
        Me.Close()
    End Sub

    Private Sub op1_CheckedChanged(sender As Object, e As EventArgs)
        'Search()
    End Sub

    Private Sub op2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub op2_Click(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub op3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub op3_Click(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub op1_Click(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'If op2.Checked = True Then
        'Frm_Report_sal.Close()
        'Frm_Report_sal.MdiParent = Mainmune
        Frm_Report_sal.Show()
        'End If
    End Sub

    Private Sub txt_OrderSal_TextChanged(sender As Object, e As EventArgs) Handles txt_OrderSal.TextChanged
        On Error Resume Next
        Search()
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class