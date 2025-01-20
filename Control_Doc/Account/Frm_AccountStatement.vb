Imports System.Data.OleDb
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils


Public Class Frm_AccountStatement
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim oldDate2 As Date
    Dim oldDay2 As Integer
    Sub find_Acc()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
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


        '==================================

        sql = " DROP VIEW dbo.vw_over"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_over AS  SELECT    id,NumberBill,  DateMoveM, Discription, Debit, Cridit, AccountNo,CostCenterNo,CruunceyNo,Rat_Cur,code_sub, SUM(Debit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur, Debit_EGP, Cridit_EGP, SUM(Debit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur_EGP, TypeBill, No_Sand, Compny_Code " & _
        "        FROM dbo.MovmentStatement " & _
        "        where Compny_Code = '" & VarCodeCompny & "' And AccountNo ='" & txt_codeAcc.Text & "' AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
        "                         (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))  "
        rs = Cnn.Execute(sql2)


        '====================================

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        sql2 = " SELECT        dbo.vw_over.No_Sand, dbo.vw_over.DateMoveM, dbo.vw_over.Discription, dbo.BD_Currency.Name, dbo.vw_over.Rat_Cur, dbo.vw_over.Debit, dbo.vw_over.Cridit, dbo.vw_over.Balance_Cur,  " & _
 "                         dbo.vw_over.Debit_EGP, dbo.vw_over.Cridit_EGP, dbo.vw_over.Balance_Cur_EGP, dbo.TB_TypeBill.Type_Bill, dbo.vw_over.CostCenterNo, dbo.Vw_CostcenterAll.Name AS CostCenterName, dbo.TB_TypeBill.Code " & _
 " FROM            dbo.vw_over INNER JOIN " & _
 "                         dbo.BD_Currency ON dbo.vw_over.CruunceyNo = dbo.BD_Currency.Code AND dbo.vw_over.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
 "                         dbo.Vw_CostcenterAll ON dbo.vw_over.CostCenterNo = dbo.Vw_CostcenterAll.Code AND dbo.vw_over.Compny_Code = dbo.Vw_CostcenterAll.Compny_Code LEFT OUTER JOIN " & _
 "                         dbo.TB_TypeBill ON dbo.vw_over.TypeBill = dbo.TB_TypeBill.Code " & _
 " WHERE        (dbo.vw_over.Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_over.AccountNo = '" & txt_codeAcc.Text & "') AND (dbo.vw_over.DateMoveM >= CONVERT(DATETIME,  '" & vardate & "', 102)) AND  " & _
 "                         (dbo.vw_over.DateMoveM <= CONVERT(DATETIME,  '" & vardate2 & "', 102))  AND (dbo.vw_over.CostCenterNo like '%" & Com_CostCenter.Text & "%') AND (dbo.BD_Currency.Name like '%" & Com_Cruuncy.Text & "%') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "100"
        'GridView1.Columns(2).Width = "150"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"
        'GridView1.Columns(11).Width = "130"
        'GridView1.Columns(12).Width = "100"
        'GridView1.Columns(13).Width = "130"

        GridView1.BestFitColumns()

        'GridView1.Columns(6).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(6).AppearanceCell.ForeColor = Color.Red

        'GridView1.Columns(7).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(7).AppearanceCell.ForeColor = Color.Red


        'GridView1.Columns(9).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(9).AppearanceCell.ForeColor = Color.Red

        'GridView1.Columns(10).AppearanceCell.BackColor = Color.DarkGray
        'GridView1.Columns(10).AppearanceCell.ForeColor = Color.Red


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحركة"
        GridView1.Columns(1).Caption = "ناريخ الحركة "
        GridView1.Columns(2).Caption = "البيان"
        GridView1.Columns(3).Caption = "العملة"
        GridView1.Columns(4).Caption = "معامل التحويل"
        GridView1.Columns(5).Caption = "مدين عملة اجنبية"
        GridView1.Columns(6).Caption = "دائن عملة اجنبية"
        'GridView1.Columns(7).Caption = "رصيد عملة اجنبية"
        GridView1.Columns(8).Caption = "مدين جنية مصرى"
        GridView1.Columns(9).Caption = "دائن جنية مصرى"
        'GridView1.Columns(10).Caption = "رصيد جنية مصرى"
        GridView1.Columns(11).Caption = "نوع السند"
        GridView1.Columns(12).Caption = "رقم مركز التكلفة"
        GridView1.Columns(13).Caption = "أسم مركز التكلفة"
        GridView1.Columns(14).Caption = "رقم نوع السند"


        GridView1.Columns(14).Visible = False


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'balance_Rased()
    End Sub


    Sub balance_Rased()
        'Dim vardebit, varCridit, varbalance As Single
        'Dim result As Integer = 0
        'For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        '    vardebit = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3)))
        '    varCridit = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4)))
        '    varbalance = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5)))


        '    If vardebit > 0 Then GridView1.Columns(5).Caption = varbalance + vardebit


        'Next rowHandle
    End Sub
    Sub find_Acc2()


        On Error Resume Next


        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
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

        '==================================
        varstatment1 = 1
        sql = " DROP VIEW dbo.vw_over"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_over AS  SELECT    id,NumberBill,  DateMoveM, Discription, Debit, Cridit, AccountNo,CostCenterNo,CruunceyNo,Rat_Cur,code_sub, SUM(Debit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur, Debit_EGP, Cridit_EGP, SUM(Debit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur_EGP, TypeBill, No_Sand, Compny_Code " & _
        "        FROM dbo.MovmentStatement " & _
        "        where Compny_Code = '" & VarCodeCompny & "' And AccountNo ='" & txt_codeAcc.Text & "' AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
        "                         (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))  "
        rs = Cnn.Execute(sql2)


        '====================================

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "   SELECT        dbo.vw_over.No_Sand, dbo.vw_over.DateMoveM, dbo.vw_over.Discription, ROUND(dbo.vw_over.Debit_EGP, 2) AS DE, ROUND(dbo.vw_over.Cridit_EGP, 2) AS Cr, ROUND(dbo.vw_over.Balance_Cur_EGP, 2) " & _
   "                         AS R, dbo.TB_TypeBill.Type_Bill, dbo.TB_TypeBill.Code " & _
   " FROM            dbo.vw_over INNER JOIN " & _
   "                         dbo.BD_Currency ON dbo.vw_over.CruunceyNo = dbo.BD_Currency.Code AND dbo.vw_over.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
   "                         dbo.Vw_CostcenterAll ON dbo.vw_over.CostCenterNo = dbo.Vw_CostcenterAll.Code AND dbo.vw_over.Compny_Code = dbo.Vw_CostcenterAll.Compny_Code LEFT OUTER JOIN " & _
   "                         dbo.TB_TypeBill ON dbo.vw_over.TypeBill = dbo.TB_TypeBill.Code " & _
   " WHERE        (dbo.vw_over.Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_over.AccountNo ='" & txt_codeAcc.Text & "') AND (dbo.vw_over.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
   "                         (dbo.vw_over.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "






        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)




        GridView1.BestFitColumns()


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم الحركة"
        GridView1.Columns(1).Caption = "ناريخ الحركة "
        GridView1.Columns(2).Caption = "البيان"
        GridView1.Columns(3).Caption = "مدين"
        GridView1.Columns(4).Caption = "دائن"
        GridView1.Columns(5).Caption = "رصيد"
        GridView1.Columns(6).Caption = "نوع الحركة"
        GridView1.Columns(7).Caption = "رقم نوع السند "

        GridView1.Columns(7).Visible = False


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'balance_Rased()

    End Sub


    Sub find_Acc3()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date1.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date1.Value, d)
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



        '==================================

        sql = " DROP VIEW dbo.vw_over"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_over AS  SELECT    id,NumberBill,  DateMoveM, Discription, Debit, Cridit, AccountNo,CostCenterNo,CruunceyNo,Rat_Cur,code_sub, SUM(Debit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur, Debit_EGP, Cridit_EGP, SUM(Debit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) - SUM(Cridit_EGP) OVER (PARTITION BY AccountNo " & _
        " ORDER BY DateMoveM, id) AS Balance_Cur_EGP, TypeBill, No_Sand, Compny_Code " & _
        "        FROM dbo.MovmentStatement " & _
        "        where Compny_Code = '" & VarCodeCompny & "' And AccountNo ='" & txt_codeAcc.Text & "' AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
        "                         (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102))  "
        rs = Cnn.Execute(sql2)


        '====================================





        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "   SELECT        TOP (100) PERCENT DateMoveM, Discription, No_Sand, Debit, Cridit, ROUND(Balance_Cur, 2) AS balance, NameItem, Unit, Qyt, Price, TotalItem,typebill " & _
   " FROM            dbo.Vw_All_InvoiceStatment4 " & _
   " WHERE        (AccountNo = '" & txt_codeAcc.Text & "') AND (Compny_Code = '" & VarCodeCompny & "') AND (DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
   " ORDER BY DateMoveM, typebill, NumberBill, flag "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "250"
        'GridView1.Columns(2).Width = "100"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "220"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"



        'GridView1.Columns(6).AppearanceCell.BackColor = Color.Silver
        'GridView1.Columns(6).AppearanceCell.ForeColor = Color.Red
        'GridView1.Columns(7).AppearanceCell.BackColor = Color.Silver
        'GridView1.Columns(7).AppearanceCell.ForeColor = Color.Red
        'GridView1.Columns(8).AppearanceCell.BackColor = Color.Silver
        'GridView1.Columns(8).AppearanceCell.ForeColor = Color.Red
        'GridView1.Columns(9).AppearanceCell.BackColor = Color.Silver
        'GridView1.Columns(9).AppearanceCell.ForeColor = Color.Red
        GridView1.Columns(10).AppearanceCell.BackColor = Color.DarkOliveGreen
        GridView1.Columns(10).AppearanceCell.ForeColor = Color.White


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "التاريخ"
        GridView1.Columns(1).Caption = "البيان"
        GridView1.Columns(2).Caption = "رقم المستند"
        GridView1.Columns(3).Caption = "مدين"
        GridView1.Columns(4).Caption = "دائن"
        GridView1.Columns(5).Caption = "رصيد"
        GridView1.Columns(6).Caption = "الصنف"
        GridView1.Columns(7).Caption = "الوحدة"
        GridView1.Columns(8).Caption = "الكمية"
        GridView1.Columns(9).Caption = "السعر"
        GridView1.Columns(10).Caption = "الاجمالى"

        GridView1.Columns(11).Caption = "رقم نوع السند"

        GridView1.Columns(11).Visible = False


        GridView1.BestFitColumns()
        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub





    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)

        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1


        'End If
    End Sub

    Private Sub Frm_AccountStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'find_Acc()
        find_Acc2()
        fill_CostCenter()
        fill_Cru()
        CustomDrawRowIndicator(GridControl1, GridView1)
    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 25
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
    End Sub
    Sub fill_Cru()
        Com_Cruuncy.Items.Clear()
        sql = "    SELECT  Name  FROM BD_Currency where Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Cruuncy.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub fill_CostCenter()
        Com_CostCenter.Items.Clear()
        sql = "      Select rtrim(dbo.ST_CHARTCOSTCENTER.AccountName) as AccountName " & _
      " FROM            dbo.Vw_NoCostCenter INNER JOIN " & _
      "                         dbo.ST_CHARTCOSTCENTER ON dbo.Vw_NoCostCenter.Compny_Code = dbo.ST_CHARTCOSTCENTER.Compny_Code AND  " & _
      "        dbo.Vw_NoCostCenter.Account_NoCostCenter = dbo.ST_CHARTCOSTCENTER.Account_No " & _
      " WHERE        (dbo.Vw_NoCostCenter.Compny_Code = '" & VarCodeCompny & "') " & _
      " GROUP BY dbo.ST_CHARTCOSTCENTER.AccountName "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_CostCenter.Items.Add(rs("AccountName").Value)
            rs.MoveNext()
        Loop
    End Sub



    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If OP2.Checked = True Then varstatment1 = 2 : find_Acc()
        If OP1.Checked = True Then varstatment1 = 1 : find_Acc2()
        If OP3.Checked = True Then varstatment1 = 3 : find_Acc3()
    End Sub



    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        'GridView1.ShowPrintPreview()
        If OP2.Checked = True Or OP3.Checked = True Then
            sql = "Delete TB_TempReport1   "
            rs = Cnn.Execute(sql)
            If OP3.Checked = True Then
                Dim result As Integer = 0
                For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
                    sql = "insert into TB_TempReport1  (Date_M,Discrption,No_Sand" & _
                        " ,Debit,Crdit,Balance,NameItem,Unit,Qty,Price,TotalItem) " & _
                        " values (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' " & _
                        " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "', N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "'  ) "
                    Cnn.Execute(sql)

                Next rowHandle
            End If

        End If

        'vardisplayReport = 0
        'If OP3.Checked = True Then vardisplayReport = 8
        If OP2.Checked = True Then Report_Statment.Show()
        If OP3.Checked = True Then Report_Statment.Show()
        varstatment1 = 1
        If OP1.Checked = True Then rpt_Statment.Show()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VARTBNAME = "vw_AccountData"
        varcode_form = 30
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)
        

    End Sub

    Private Sub OP1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged

    End Sub

    Private Sub OP1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        If OP2.Checked = True Then find_Acc()
        If OP1.Checked = True Then find_Acc2()
        If OP3.Checked = True Then find_Acc3()
    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs) Handles OP2.CheckedChanged

    End Sub

    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        If OP2.Checked = True Then find_Acc()
        If OP1.Checked = True Then find_Acc2()
        If OP3.Checked = True Then find_Acc3()
    End Sub

    Private Sub OP3_CheckedChanged(sender As Object, e As EventArgs) Handles OP3.CheckedChanged

    End Sub

    Private Sub OP3_Click(sender As Object, e As EventArgs) Handles OP3.Click
        If OP2.Checked = True Then find_Acc()
        If OP1.Checked = True Then find_Acc2()
        If OP3.Checked = True Then find_Acc3()
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'If RadioButton1.Checked = True Then
        Dim Varcodetype As Integer
        Dim VarNoMove As String

        '==============================================1
        If OP1.Checked = True Then
            Varcodetype = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
            VarNoMove = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            If Varcodetype = "8" Then Frm_Gl4.Com_GL_No.Text = VarNoMove : Frm_Gl4.find_hedar() : Frm_Gl4.find_detalis() : Frm_Gl4.Total_Sum() : Frm_Gl4.Show() : Frm_Gl4.MdiParent = Mainmune
            If Varcodetype = "2" Then Frm_SalseInvoice.Com_InvoiceNo2.Text = VarNoMove : Frm_SalseInvoice.find_hedar() : Frm_SalseInvoice.find_detalis() : Frm_SalseInvoice.find_Invoice_Condation() : Frm_SalseInvoice.Total_Sum() : Frm_SalseInvoice.sum_tax() : Frm_SalseInvoice.Show() : Frm_SalseInvoice.MdiParent = Mainmune
            If Varcodetype = "3" Then Frm_ReciptCash2.Com_Exp_No.Text = VarNoMove : Frm_ReciptCash2.find_hedar() : Frm_ReciptCash2.find_detalis() : Frm_ReciptCash2.Show() : Frm_ReciptCash2.MdiParent = Mainmune
            If Varcodetype = "4" Then Frm_Expenses2.Com_Exp_No.Text = VarNoMove : Frm_Expenses2.find_hedar() : Frm_Expenses2.find_detalis() : Frm_Expenses2.Show() : Frm_Expenses2.MdiParent = Mainmune
        End If


        If OP2.Checked = True Then
            Varcodetype = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(14))
            VarNoMove = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            If Varcodetype = "8" Then Frm_Gl4.Com_GL_No.Text = VarNoMove : Frm_Gl4.find_hedar() : Frm_Gl4.find_detalis() : Frm_Gl4.Total_Sum() : Frm_Gl4.Show() : Frm_Gl4.MdiParent = Mainmune
            If Varcodetype = "2" Then Frm_SalseInvoice.Com_InvoiceNo2.Text = VarNoMove : Frm_SalseInvoice.find_hedar() : Frm_SalseInvoice.find_detalis() : Frm_SalseInvoice.find_Invoice_Condation() : Frm_SalseInvoice.Total_Sum() : Frm_SalseInvoice.sum_tax() : Frm_SalseInvoice.Show() : Frm_SalseInvoice.MdiParent = Mainmune
            If Varcodetype = "3" Then Frm_ReciptCash2.Com_Exp_No.Text = VarNoMove : Frm_ReciptCash2.find_hedar() : Frm_ReciptCash2.find_detalis() : Frm_ReciptCash2.Show() : Frm_ReciptCash2.MdiParent = Mainmune
            If Varcodetype = "4" Then Frm_Expenses2.Com_Exp_No.Text = VarNoMove : Frm_Expenses2.find_hedar() : Frm_Expenses2.find_detalis() : Frm_Expenses2.Show() : Frm_Expenses2.MdiParent = Mainmune
        End If


        If OP3.Checked = True Then
            Varcodetype = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(11))
            VarNoMove = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
            'If Varcodetype = "8" Then Frm_Gl4.Com_GL_No.Text = VarNoMove : Frm_Gl4.find_hedar() : Frm_Gl4.find_detalis() : Frm_Gl4.Total_Sum() : Frm_Gl4.Close() : Frm_Gl4.Show() : Frm_Gl4.MdiParent = Mainmune
            If Varcodetype = "2" Then Frm_SalseInvoice.Com_InvoiceNo2.Text = VarNoMove : Frm_SalseInvoice.find_hedar() : Frm_SalseInvoice.find_detalis() : Frm_SalseInvoice.find_Invoice_Condation() : Frm_SalseInvoice.Total_Sum() : Frm_SalseInvoice.sum_tax() : Frm_SalseInvoice.Show() : Frm_SalseInvoice.MdiParent = Mainmune
            If Varcodetype = "3" Then Frm_ReciptCash2.Com_Exp_No.Text = VarNoMove : Frm_ReciptCash2.find_hedar() : Frm_ReciptCash2.find_detalis() : Frm_ReciptCash2.Show() : Frm_ReciptCash2.MdiParent = Mainmune
            'If Varcodetype = "4" Then Frm_Expenses2.Com_Exp_No.Text = VarNoMove : Frm_Expenses2.find_hedar() : Frm_Expenses2.find_detalis() : Frm_Expenses2.Close() : Frm_Expenses2.Show() : Frm_Expenses2.MdiParent = Mainmune
        End If
    End Sub
End Class