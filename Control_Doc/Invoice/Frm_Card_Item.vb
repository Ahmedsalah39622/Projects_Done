Imports System.Data.OleDb

Public Class Frm_Card_Item

    Private Sub Frm_Card_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_gard()
        Total_Sum()
    End Sub

    Sub find_gard()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "SELECT dbo.vw_overItem.NumberBill, dbo.vw_overItem.DateMoveM, dbo.vw_overItem.Export, dbo.vw_overItem.Import, dbo.vw_overItem.Balance, dbo.vw_overItem.Discription, dbo.TB_TypeBill.Type_Bill " & _
        " FROM     dbo.vw_overItem INNER JOIN " & _
        "                  dbo.TB_TypeBill ON dbo.vw_overItem.TypeD = dbo.TB_TypeBill.Code " & _
        " WHERE  (dbo.vw_overItem.NoItem = '" & txt_CodeItem2.Text & "') AND (dbo.vw_overItem.Code_Stores = '" & varcodStores & "') AND (dbo.vw_overItem.Compny_Code = '" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رفم المستند"
        GridView6.Columns(1).Caption = "التاريخ"
        GridView6.Columns(2).Caption = "الكمية الواردة"
        GridView6.Columns(3).Caption = "الكمية المنصرفة"
        GridView6.Columns(4).Caption = "الرصيد"
        GridView6.Columns(5).Caption = "البيان"
        GridView6.Columns(6).Caption = "نوع المستند"

        GridView6.BestFitColumns()




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView6.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        'Mainmune.finwatinoderItem()
    End Sub

    Sub Total_Sum()
        On Error Resume Next
        Dim total As Single
        Dim total2 As Single
        Dim total3 As Single
        For i As Integer = 0 To GridView6.RowCount - 1
            total += GridView6.GetRowCellValue(i, GridView6.Columns(2))
            total2 += GridView6.GetRowCellValue(i, GridView6.Columns(3))
            total3 += GridView6.GetRowCellValue(i, GridView6.Columns(3))
        Next
        Txt_wared.Text = Math.Round(total, 2)
        txt_Mnsrf.Text = Math.Round(total2, 2)
        txt_Balance.Text = Val(Txt_wared.Text) - Val(txt_Mnsrf.Text)
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click

    End Sub
End Class