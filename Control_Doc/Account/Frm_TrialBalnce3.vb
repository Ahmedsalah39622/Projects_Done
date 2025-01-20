Imports System.Data.OleDb
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Windows.Forms.ImageList

Imports DevExpress.XtraPrinting
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class Frm_TrialBalnce3

    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Dim varbalnce, varFinalBalance, vardebite, varcrdit As Single

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        ''End If
        ''If e.RowHandle >= 0 Then
        ''    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        'GridView1.RowHeight = 20
        'GridView1.GroupRowHeight = 1
        'GridView1.RowSeparatorHeight = 1
        ''GridView1.GroupRowHeight = 1

        'End If
    End Sub
    Sub Ceratea_sql()
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


        'If RadioButton1.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel"
        rs = Cnn.Execute(sql)


        sql2 = " CREATE VIEW Trial_Balance_AllLevel AS   SELECT SUBSTRING(AccountNo, 1, 1) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                " FROM     dbo.MovmentStatement " & _
                " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If


        'If RadioButton2.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel2"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel2 AS  SELECT SUBSTRING(AccountNo, 1,3) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If
        'End If


        'If RadioButton3.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel3"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel3 AS  SELECT SUBSTRING(AccountNo, 1, 6) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If


        'If RadioButton4.Checked = True Then
        sql = " DROP VIEW dbo.Trial_Balance_AllLevel4"
        rs = Cnn.Execute(sql)

        sql2 = " CREATE VIEW Trial_Balance_AllLevel4 AS  SELECT SUBSTRING(AccountNo, 1, 15) AS acc, AccountNo, '0' AS OpenD, '0' AS OpenC, ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC " & _
                  " FROM     dbo.MovmentStatement " & _
                  " WHERE  (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                  " GROUP BY AccountNo "
        rs = Cnn.Execute(sql2)
        'End If

    End Sub
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs)
        
    End Sub

    Sub find_data()

        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        Ceratea_sql()
        If RadioButton1.Checked = True Then sql2 = "SELECT   *  FROM            dbo.Vw_TralBalanceall_L1"
        If RadioButton2.Checked = True Then sql2 = "SELECT   *  FROM            dbo.Vw_TralBalanceall_L2"
        If RadioButton3.Checked = True Then sql2 = "SELECT   *  FROM            dbo.Vw_TralBalanceall_L3_Final2"
        If RadioButton4.Checked = True Then sql2 = "SELECT   *  FROM            dbo.Vw_TralBalanceall_L4"
        If RadioButton6.Checked = True Then sql2 = "SELECT   *  FROM            dbo.Vw_TralBalanceall_L5"

        If RadioButton5.Checked = True Then sql2 = "SELECT   acc, AccountName, OpenD, OpenC, SumMoveD, SumMoveC, DebitSum, CriditSum  FROM            dbo.Vw_TralBalanceall_LAll"



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "أسم الحساب"
        GridView1.Columns(2).Caption = "مدين"
        GridView1.Columns(3).Caption = "دائن"
        GridView1.Columns(4).Caption = "مدين"
        GridView1.Columns(5).Caption = "دائن"
        GridView1.Columns(6).Caption = "مدين"
        GridView1.Columns(7).Caption = "دائن"



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum


        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
   
    
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs)
        If (e.Info.SummaryItem.SummaryType = SummaryItemType.Custom And IsNumeric(e.Info.SummaryItem.SummaryValue)) Then e.Column.SummaryItem.DisplayFormat = "Total: {0:c0}"
    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)
       
    End Sub

  
    
    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub
    Sub find_detils()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        'Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        If RadioButton2.Checked = True Then
            Frm_AccDetils2.txt_Code.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            Frm_AccDetils2.txt_Name.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
            Frm_AccDetils2.txt_date.Text = txt_date.Text
            Frm_AccDetils2.txt_date2.Text = txt_date2.Text
            Frm_AccDetils2.find_level1()
            Frm_AccDetils2.balance_all()
            Frm_AccDetils2.GridView3.BestFitColumns()
            Frm_AccDetils2.GridControl2.Select()
            Frm_AccDetils2.MdiParent = Mainmune
            Frm_AccDetils2.Show()
        End If
    End Sub

   
    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            find_detils()
        End If
    End Sub

    Private Sub Frm_TrialBalnce3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

   

    

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
    Sub find_data_Detils2()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

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

        varbalnce = 0
        varFinalBalance = 0


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        sql2 = "SELECT        Account_No2, AccountName,'0' as Open_BalanceDB,'0' as Open_BalanceCD, SUMDB, SUMCD,round(iif(SUMDB>SUMCD,SUMDB-SUMCD,0),2) as SumMoveBD,round(iif(SUMCD>SUMDB,SUMCD-SUMDB,0),2) as SumMoveCD " & _
        " FROM            dbo.Tril_BalanceFinal " & _
        "        where Compny_Code = '" & VarCodeCompny & "'  " & _
        "  "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns(0)
        GridView1.BestFitColumns(1)
        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "200"
        GridView1.Columns(2).Width = "150"
        GridView1.Columns(3).Width = "150"
        GridView1.Columns(4).Width = "150"
        GridView1.Columns(5).Width = "150"
        GridView1.Columns(6).Width = "150"
        GridView1.Columns(7).Width = "150"



        GridView1.Columns(0).Caption = "رقم الحساب"
        GridView1.Columns(1).Caption = "أسم الحساب"
        GridView1.Columns(2).Caption = "مدين"
        GridView1.Columns(3).Caption = "دائن"
        GridView1.Columns(4).Caption = "مدين"
        GridView1.Columns(5).Caption = "دائن"
        GridView1.Columns(6).Caption = "مدين"
        GridView1.Columns(7).Caption = "دائن"
        'GridView1.Columns(8).Caption = "مدين"
        'GridView1.Columns(9).Caption = "دائن"


        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

   
    

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)
        find_data()
    End Sub

   

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        find_data()
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs)
        find_data()
    End Sub

   

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs)
        find_data()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton1_Click1(sender As Object, e As EventArgs) Handles RadioButton1.Click
        find_data()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton2_Click1(sender As Object, e As EventArgs) Handles RadioButton2.Click
        find_data()
    End Sub

    Private Sub RadioButton3_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        find_data()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub RadioButton4_Click1(sender As Object, e As EventArgs) Handles RadioButton4.Click
        find_data()
    End Sub

    Private Sub RadioButton5_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged

    End Sub

    Private Sub RadioButton5_Click1(sender As Object, e As EventArgs) Handles RadioButton5.Click
        find_data()
    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        find_data()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        On Error Resume Next


        sql = "Delete TB_TempReport1   "
        rs = Cnn.Execute(sql)

        Dim result As Integer = 0
        For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle


            Dim var7 As String
            var7 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))))
            'var8 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))))
            'var9 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))))
            'var10 = IIf(Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) Is Nothing, "", Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))))


            sql2 = "insert into TB_TempReport1  (Account_No,Account_Name,OpenDeipt" & _
                " ,OprnCridit,BalanceDeipt,BalanceCridit,FinalDeit,FinalCridit) " & _
                " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                " ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "','" & var7 & "') "
            Cnn.Execute(sql2)


        Next rowHandle
        If RadioButton1.Checked = True Then var_open_TrilBalance = 1
        If RadioButton2.Checked = True Then var_open_TrilBalance = 2
        If RadioButton3.Checked = True Then var_open_TrilBalance = 3
        If RadioButton4.Checked = True Then var_open_TrilBalance = 5
        If RadioButton5.Checked = True Then var_open_TrilBalance = 6

        Frm_TrilBalanceRpt.Show()
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        find_detils()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If RadioButton5.Checked = True Then

            For x As Integer = 0 To GridView1.RowCount



                Dim ststus_Stores As String
                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

                'حركة البيع
                '=======================================================================
                ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(0))
                If Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "1" Then
                    If e.Column.AbsoluteIndex >= 0 And Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "1" AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.SkyBlue
                    End If
                Else
                    If e.Column.AbsoluteIndex >= 0 And Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "1" AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.White
                    End If
                End If
                '======================================================================================

                'ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(13))
                If Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "3" Then
                    If e.Column.AbsoluteIndex >= 0 And Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "3" AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.LightGray
                    End If
                Else
                    If e.Column.AbsoluteIndex >= 0 And Len(GridView1.GetRowCellValue(x, GridView1.Columns(0))) = "3" AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.White
                    End If
                End If


            Next x


        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged

    End Sub

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click
        find_data()
    End Sub
End Class