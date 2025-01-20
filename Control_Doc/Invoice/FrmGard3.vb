Imports System.Data.OleDb

Public Class FrmGard3
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub FrmGard3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_Date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        find_item()
        'txt_CodeModel.Select()
    End Sub

    Sub find_item()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_Date.Text
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_Date.Text, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        'oldDate = Frm_ReportStores.txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_Date.Text, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay
  
        sql2 = "   SELECT dbo.Statement_OfItem.DateMoveM, dbo.Statement_OfItem.Import, dbo.Statement_OfItem.Dis, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.BD_Stores.Name AS Stores " & _
   " FROM     dbo.Statement_OfItem INNER JOIN " & _
   "                  dbo.TB_Detils_AznItem_Stores ON dbo.Statement_OfItem.NumberBill = dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores AND dbo.Statement_OfItem.NoItem = dbo.TB_Detils_AznItem_Stores.No_Item INNER JOIN " & _
   "                  dbo.BD_Item ON dbo.TB_Detils_AznItem_Stores.No_Item = dbo.BD_Item.Code INNER JOIN " & _
   "                  dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
    "                 dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code " & _
   " WHERE  (dbo.Statement_OfItem.DateMoveM = CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.Import > 0) AND (dbo.Statement_OfItem.TypeD = 1) "


        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "التاريخ"
        GridView1.Columns(1).Caption = "الكمية المنصرفة"
        GridView1.Columns(2).Caption = "البيان"
        GridView1.Columns(3).Caption = "اسم الصنف"
        GridView1.Columns(4).Caption = "المجموعة"
        GridView1.Columns(5).Caption = "المخزن"
        'GridView1.Columns(6).Caption = "الوارد"
        'GridView1.Columns(7).Caption = "المنصرف"
        'GridView1.Columns(8).Caption = "الرصيد"
        'GridView1.Columns(9).Caption = "المخزن"



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        GridView1.BestFitColumns()

    End Sub

    Private Sub txt_CodeModel_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            find_item()
        End If
    End Sub

    Private Sub txt_CodeModel_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        GridView1.ShowPrintPreview()
    End Sub
End Class