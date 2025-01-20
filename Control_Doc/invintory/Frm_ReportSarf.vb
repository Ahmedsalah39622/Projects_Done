Imports System.Data.OleDb

Public Class Frm_ReportSarf
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Private Sub Frm_ReportSarf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Sub Search()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If OP1.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' and dbo.Vw_All_AZN_Sarf3.No_Invoice = '0'  and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102))   "

        End If

        If OP2.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' AND  dbo.Vw_All_AZN_Sarf3.No_Invoice <> '0'  and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        End If

        If OP3.Checked = True Then
            sql2 = "select * from Vw_All_AZN_Sarf3 where Compny_Code = '" & VarCodeCompny & "' and (Order_Date_stores >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (Order_Date_stores <= CONVERT(DATETIME, '" & vardate2 & "', 102))  "

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
        GridView1.Columns(0).Caption = " اذن الصرف"
        GridView1.Columns(1).Caption = "رقم الطلبية"
        GridView1.Columns(2).Caption = "رقم الصنف"
        GridView1.Columns(3).Caption = "أسم الصنف"
        GridView1.Columns(4).Caption = "الكمية"
        GridView1.Columns(5).Caption = "الوحدة"
        GridView1.Columns(6).Caption = "أسم العميل"
        GridView1.Columns(7).Caption = "أسم المندوب"

        GridView1.Columns(8).Caption = "سعر الوحدة"
        GridView1.Columns(9).Caption = "الاجمالى"
        GridView1.Columns(10).Caption = "المخزن"

        GridView1.Columns(11).Caption = "رقم الفاتورة"


        '================================================================
        GridView1.Columns(12).Visible = False 'Code Compny
        GridView1.Columns(13).Visible = False 'CodeCustomer
        GridView1.Columns(14).Visible = False 'Codesalse
        GridView1.Columns(15).Visible = False 'codeUnit
        GridView1.Columns(16).Visible = False 'Codestores
        GridView1.Columns(17).Visible = False 'code Cur
        GridView1.Columns(18).Visible = False 'ExtItem
        GridView1.Columns(19).Visible = False 'Rat
        GridView1.Columns(20).Visible = False
        GridView1.Columns(1).Visible = False
        GridView1.Columns(2).Visible = False


        '=================================================================
        'GridView1.Columns(20).Caption = "نوع الاذن"
        GridView1.Columns(20).Caption = "م"
        GridView1.Columns(21).Visible = False

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()
        'GridView1.Columns(16).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(16).AppearanceCell.ForeColor = Color.Red




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.BestFitColumns()



    End Sub

   

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
 
    End Sub

   
    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        Search()
    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs) Handles OP2.CheckedChanged

    End Sub

    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        Search()
    End Sub

    Private Sub OP3_CheckedChanged(sender As Object, e As EventArgs) Handles OP3.CheckedChanged

    End Sub

    Private Sub OP3_Click(sender As Object, e As EventArgs) Handles OP3.Click
        Search()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'sql = " SELECT *      FROM dbo.TB_Header_InvoiceSal WHERE  (Ser_InvoiceNo = '" & txt_invoiceNo.Text & "')"
        'rs = Cnn.Execute(sql)
        If Len(txt_invoiceNo.Text) = 0 Then MsgBox("من فضلك أختار الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        Frm_SalseInvoice.Com_InvoiceNo2.Text = txt_invoiceNo.Text

        'varinvoice_type2 = 1
        'Frm_All_Invoice.Fill_INVOICE2()
        Frm_SalseInvoice.find_hedar()
        Frm_SalseInvoice.find_detalis()
        Frm_SalseInvoice.MdiParent = Mainmune
        'Frm_All_Invoice.Enabled = True
        Frm_SalseInvoice.Show()
    End Sub

    Private Sub Cmd_PrintInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_PrintInvoice.Click
        frm_Report_AznSarf.Show()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        txt_invoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))

    End Sub
End Class