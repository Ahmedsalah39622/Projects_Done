Imports System.Data.OleDb
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class Frm_AccDetils2
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer


    Sub find_level1()
        On Error Resume Next




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'sql = "    SELECT TOP (100) PERCENT rtrim(dbo.ST_CHARTOFACCOUNT.Account_No_Update) as Account_No_Update , rtrim(dbo.ST_CHARTOFACCOUNT.AccountName) as AccountName , round(dbo.vw_sumlevel4.Debit,2) as Debit ,  " & _

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



        'sql2 = " SELECT dbo.ST_CHARTOFACCOUNT.Account_No, Rtrim(dbo.ST_CHARTOFACCOUNT.AccountName) as AccountName, round(SUM(dbo.MovmentStatement.Debit),2) AS SumDe, round(SUM(dbo.MovmentStatement.Cridit),2) AS SumCr2 ,round(round(SUM(dbo.MovmentStatement.Debit),2) - round(SUM(dbo.MovmentStatement.Cridit),2),2) as Balance " & _
        '     " FROM     dbo.ST_CHARTOFACCOUNT INNER JOIN " & _
        '     "                                     dbo.MovmentStatement ON dbo.ST_CHARTOFACCOUNT.Account_No = dbo.MovmentStatement.AccountNo AND dbo.ST_CHARTOFACCOUNT.Compny_Code = dbo.MovmentStatement.Compny_Code " & _
        '     " WHERE  (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) AND  " & _
        '     "                  (dbo.ST_CHARTOFACCOUNT.Level_No2 = '" & txt_Code.Text & "') and   dbo.ST_CHARTOFACCOUNT.Compny_Code ='" & VarCodeCompny & "' " & _
        '     " GROUP BY dbo.ST_CHARTOFACCOUNT.Account_No, dbo.ST_CHARTOFACCOUNT.AccountName "

        'sql2 = "  SELECT        Account_No2, AccountName, SUMDB, SUMCD, balance       FROM dbo.Tril_Sub_level2 WHERE        (Account_No3 = '" & txt_Code.Text & "')"

        sql2 = " SELECT acc, AccountName, SumMoveD, SumMoveC, DebitSum, CriditSum      FROM dbo.Vw_TralBalanceall_L3_Final2 WHERE  (acc LIKE '" & txt_Code.Text & "%')"



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)

        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.BestFitColumns(0)
        GridView3.BestFitColumns(1)
        GridView3.Columns(0).Caption = "رقم الحساب"
        GridView3.Columns(1).Caption = "أسم الحساب"
        GridView3.Columns(2).Caption = "مدين"
        GridView3.Columns(3).Caption = "دائن"
        GridView3.Columns(4).Caption = "رصيد مدين"
        GridView3.Columns(5).Caption = "رصيد دائن"



        GridView3.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()






    End Sub


    Sub Total_Sum_Account()
        Dim total2 As Single
        Dim total3 As Single

        For i As Integer = 0 To GridView1.RowCount - 1
            total2 += Math.Round(GridView1.GetRowCellValue(i, GridView1.Columns(3)), 2)
            total3 += Math.Round(GridView1.GetRowCellValue(i, GridView1.Columns(4)), 2)


        Next
        'txt_sumde.Text = Math.Round(total2, 2)
        'txt_sumcr.Text = Math.Round(total3, 2)
        'txt_sumBalanceAcc.Text = Math.Round(Val(txt_BalancePrev.Text) + Math.Round(total2 - total3, 2), 2)
    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        find_level1()
        GridView3.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView3.BestFitColumns()
        balance_all()


    End Sub
    Sub balance_all()
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
        '===========================================الرصيد السابق


        'sql = "   SELECT        dbo.ST_CHARTOFACCOUNT.Level_No2, SUM(dbo.vw_OverAccount.Debit) - SUM(dbo.vw_OverAccount.Cridit) AS prviousBalance " & _
        '       " FROM            dbo.vw_OverAccount INNER JOIN " & _
        '       "                         dbo.ST_CHARTOFACCOUNT ON dbo.vw_OverAccount.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        '       " WHERE        (dbo.ST_CHARTOFACCOUNT.Level_No2 = '" & txt_Code.Text & "') AND (dbo.vw_OverAccount.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_OverAccount.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and ST_CHARTOFACCOUNT.Compny_Code ='" & VarCodeCompny & "' " & _
        '       " GROUP BY dbo.ST_CHARTOFACCOUNT.Level_No2 "


        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_SumBalance.Text = Math.Round(rs("prviousBalance").Value, 2) Else txt_BalancePrev.Text = "0"
        '=============================
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next


        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView3.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle


            'Dim var7 As String
            'var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            ''var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
            ''var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
            ''var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))


            sql2 = "insert into TB_TempReport1  (Account_No,AccountName,Debit" & _
                " ,Crdit,Balance) " & _
                " values ('" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(0))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(1))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(2))) & "' " & _
                " ,'" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(3))) & "','" & Trim(GridView3.GetRowCellValue(rowHandle, GridView3.Columns(4))) & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        var_open_TrilBalance = 4
        Frm_TrilBalanceRpt.Show()
    End Sub





    Sub find_Acc()


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

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Dim value = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Dim value2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_NameAccount.Text = value2
        '===========================================الرصيد السابق
        'sql = "     SELECT        ROUND(SUM(Debit) - SUM(Cridit), 2) AS prviousBalance    FROM dbo.vw_OverAccount WHERE        (AccountNo = '" & value & "') AND (DateMoveM < CONVERT(DATETIME, '" & vardate & "', 102)) HAVING        (ROUND(SUM(Debit) - SUM(Cridit), 2) IS NOT NULL)"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then txt_BalancePrev.Text = rs("prviousBalance").Value Else txt_BalancePrev.Text = "0"
        '=============================


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql2 = "SELECT        dbo.vw_OverAccount.NumberBill, dbo.vw_OverAccount.DateMoveM, dbo.vw_OverAccount.Discription, dbo.vw_OverAccount.Debit, dbo.vw_OverAccount.Cridit, dbo.vw_OverAccount.Balance_Cur, " & _
        '        "                         dbo.TB_TypeBill.Type_Bill " & _
        '        " FROM            dbo.vw_OverAccount INNER JOIN " & _
        '        "                         dbo.TB_TypeBill ON dbo.vw_OverAccount.TypeBill = dbo.TB_TypeBill.Code " & _
        '        " WHERE        (dbo.vw_OverAccount.AccountNo = '" & value & "') AND (dbo.vw_OverAccount.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_OverAccount.DateMoveM <= CONVERT(DATETIME,   '" & vardate2 & "', 102)) and Compny_Code ='" & VarCodeCompny & "' "

        '        sql2 = " SELECT        dbo.MovmentStatement.AccountNo, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS name, SUM(dbo.MovmentStatement.Debit) AS SumDe, SUM(dbo.MovmentStatement.Cridit) AS SumCr, " & _
        ' "                         SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit) AS balance " & _
        ' " FROM            dbo.MovmentStatement INNER JOIN " & _
        ' "  " & _
        ' "                         dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        '" where (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME,   '" & vardate2 & "', 102)) and Compny_Code ='" & VarCodeCompny & "' " & _
        ' " GROUP BY dbo.MovmentStatement.AccountNo, dbo.ST_CHARTOFACCOUNT.AccountName " & _
        ' " HAVING        (dbo.MovmentStatement.AccountNo LIKE '" & value & "')  "

        sql2 = "  SELECT        dbo.MovmentStatement.AccountNo, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS name, ROUND(SUM(dbo.MovmentStatement.Debit), 2) AS SumDe, ROUND(SUM(dbo.MovmentStatement.Cridit), 2) AS SumCr, " & _
  "                         ROUND(SUM(dbo.MovmentStatement.Debit) - SUM(dbo.MovmentStatement.Cridit), 2) AS balance " & _
  " FROM            dbo.MovmentStatement INNER JOIN " & _
  "                         dbo.ST_CHARTOFACCOUNT ON dbo.MovmentStatement.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND dbo.MovmentStatement.AccountNo = dbo.ST_CHARTOFACCOUNT.Account_No " & _
  " WHERE        (dbo.MovmentStatement.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.MovmentStatement.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
  " GROUP BY dbo.MovmentStatement.AccountNo, dbo.ST_CHARTOFACCOUNT.AccountName " & _
  " HAVING        (dbo.MovmentStatement.AccountNo LIKE '%" & value & "%') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "اسم الحساب "
        GridView1.Columns(2).Caption = "مدين"
        GridView1.Columns(3).Caption = "دائن"
        GridView1.Columns(4).Caption = "رصيد"



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

   

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'ShowGridPreview(GridControl3)
        GridView1.OptionsPrint.UsePrintStyles = True
        ' Enable the AppearancePrint.EvenRow property's settings. 
        GridView1.OptionsPrint.EnableAppearanceEvenRow = True
        ' Set the background color of the even rows. 
        GridView1.AppearancePrint.EvenRow.BackColor = Color.LightYellow

        GridView1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub Frm_AccDetils2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        ''    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        'GridView1.RowHeight = 20
        'GridView1.GroupRowHeight = 1
        'GridView1.RowSeparatorHeight = 2
        ''GridView1.GroupRowHeight = 1

        'GridView3.RowHeight = 20
        'GridView3.GroupRowHeight = 1
        'GridView3.RowSeparatorHeight = 2
       
        'End If
    End Sub
    
    Private Sub GridView3_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        'GridView3.RowHeight = 20
        'GridView3.GroupRowHeight = 1
        'GridView3.RowSeparatorHeight = 2
        'GridView1.GroupRowHeight = 1



        'End If
    End Sub
    Private Sub Frm_AccDetils2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CustomDrawRowIndicator(GridControl2, GridView3)
        'CustomDrawRowIndicator(GridControl1, GridView1)
    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        'Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        'gridView.IndicatorWidth = 50
        '' Handle this event to paint RowIndicator manually 
        'AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
        '                                                If Not e.Info.IsRowIndicator Then
        '                                                    Return
        '                                                End If
        '                                                Dim view As GridView = TryCast(s, GridView)
        '                                                e.Handled = True

        '                                                e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
        '                                                e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
        '                                                If e.Info.ImageIndex < 0 Then
        '                                                    Return
        '                                                End If
        '                                                Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
        '                                                Dim indicator As Image = ic.Images(e.Info.ImageIndex)
        '                                                'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
        '                                            End Sub
    End Sub

   

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        find_Acc()
        Total_Sum_Account()
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.BestFitColumns()
    End Sub

   

    Private Sub GridControl2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            find_Acc()
            Total_Sum_Account()
            GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim valueAcc = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Frm_AccountStatement2.txt_codeAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        Frm_AccountStatement2.txt_NameAcc.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))

        Frm_AccountStatement2.FindBalance()
        Frm_AccountStatement2.find_data()
        Frm_AccountStatement2.count_colume()
        Frm_AccountStatement2.count_colume2()
        Frm_AccountStatement2.final_sum()

        Frm_AccountStatement2.MdiParent = Mainmune
        Frm_AccountStatement2.Show()

    End Sub
End Class