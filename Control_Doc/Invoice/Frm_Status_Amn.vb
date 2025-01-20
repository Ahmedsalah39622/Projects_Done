Imports System.Data.OleDb

Public Class Frm_Status_Amn
    Dim oldDate As Date
    Dim oldDay As Integer

    Private Sub Frm_Status_Amn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_all_data()
    End Sub

    Sub fill_all_data()
        On Error Resume Next
        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()


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

        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "select * from Vw_All_AznEstlamStoresData   where name ='" & vardate & "' and Compny_Code = '" & VarCodeCompny & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True


        GridView3.Columns(0).Caption = "رقم الاذن"
        GridView3.Columns(1).Caption = "تاريخ الاذن"
        GridView3.Columns(2).Caption = "أسم العميل"
        GridView3.Columns(3).Caption = "كود الصنف"
        GridView3.Columns(4).Caption = "اسم الصنف"
        GridView3.Columns(5).Caption = "الكمية"
        GridView3.Columns(6).Caption = "الوحدة"
        GridView3.Columns(7).Caption = "السعر"
        GridView3.Columns(8).Caption = "الاجمالى"
        GridView3.Columns(9).Caption = "نوع الاذن"
        GridView3.Columns(10).Caption = "أسم المخزن"
        GridView3.Columns(12).Caption = "حالة الخروج"
        GridView3.Columns(13).Caption = "اسم المسئول"

        GridView3.Columns(11).Visible = False
        GridView3.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim varstatusamin As String
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        varcodeitem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        LabelX5.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        txt_NameUser.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(13))

        varstatusamin = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(12))

        If varstatusamin = "لم يخروج من المصنع" Then Op2.Checked = True Else OP1.Checked = True

    End Sub

    Private Sub Cmd_OpenCustomer_Click(sender As Object, e As EventArgs) Handles Cmd_OpenCustomer.Click
        '===============================================تعديل Hedare
        Dim varflaginout As Integer
        If OP1.Checked = True Then varflaginout = 1
        If Op2.Checked = True Then varflaginout = 0

        If txt_NameUser.Text = "" Then MsgBox("من فضلك ادخل الاسم", MsgBoxStyle.Critical, "Css") : Exit Sub


        sql2 = "UPDATE  TB_Header_AznItem_Stores  SET InOut ='" & varflaginout & "',NameUserAmn='" & txt_NameUser.Text & "' WHERE Compny_Code = " & VarCodeCompny & "  and Order_Stores_NO ='" & LabelX5.Text & "'  "
        rs = Cnn.Execute(sql2)
        If OP1.Checked = True Then MsgBox("موافق على خروج البضاعة ", MsgBoxStyle.Information, "CSS")
        If Op2.Checked = True Then MsgBox("غير موافق على خروج البضاعة", MsgBoxStyle.Information, "CSS")
        fill_all_data()
    End Sub

    Private Sub txt_date_ValueChanged(sender As Object, e As EventArgs) Handles txt_date.ValueChanged
        fill_all_data()
    End Sub
End Class