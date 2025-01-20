Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class Frm_Gl4
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim varvaluecash1, varvaluecash2 As String
    Dim SQl3 As String
    Dim varid, vartypeGl As Long
    Dim vardebit, varcridit As String

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
        'GridView1.GroupRowHeight = 1


        GridView6.RowHeight = 20
        GridView6.GroupRowHeight = 1
        GridView6.RowSeparatorHeight = 1
        'End If
    End Sub


   
    Sub clear_data()
        'Com_GL_No.Text = ""
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_Cash.Text = ""
        'txt_CostCenter.Text = ""
        'txt_CostCenterName.Text = ""
        txt_GL_Date.Text = DateTime.Now.ToString("yyyy/MM/dd")
        txt_Cash.Text = ""
        txt_rat.Text = ""
        Txt_ValueCash.Text = ""
        'Com_Cur.Text = ""
        'Com_Type.Text = ""
    End Sub
    Sub last_Data()



        sql = "SELECT        MAX(IDGenral) AS MaxmamNo FROM dbo.Genralledger where Compny_Code = '" & VarCodeCompny & "' HAVING(MAX(IDGenral) Is Not NULL) "

        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_GL_No.Text = rs("MaxmamNo").Value + 1
        Else
            Com_GL_No.Text = 1

        End If



    End Sub




    Sub save_gl()
        On Error Resume Next
        'If Len(Com_GL_No.Text) = 0 Then MsgBox("من فضلك ادخل رقم القيد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : SimpleButton11.Select() : Exit Sub
        If Len(Com_Cur.Text) = 0 Then MsgBox("من فضلك ادخل العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_CostCenter.Text) = 0 Then MsgBox("من فضلك ادخل مركز التكلفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Notes.Text) = 0 Then MsgBox("من فضلك ادخل البيان ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Type.Text) = 0 Then MsgBox("من فضلك أختار نوع الحركة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Cash.Text) = 0 Then MsgBox("من فضلك ادخل المبلغ ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "  SELECT        IDGenral, Typebill, Compny_Code      FROM dbo.Genralledger WHERE        (IDGenral = '" & Com_GL_No.Text & "') AND (Typebill <> 8) AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then last_Data()
        '============================================تاريخ السند
        Dim dd As DateTime = txt_GL_Date.text
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")
        Dim varcodegl As Integer
        If Com_GL_No.Text = "" Then varcodegl = 0 Else varcodegl = Com_GL_No.Text

        sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & varcodegl & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & varcodegl & "' and DateM ='" & vardate & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
            Else
                MsgBox("  من فضلك رقم القيد تم تكرارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

            End If

        Else
            last_Data()
        End If

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value


        If Com_Type.Text = "مدين" And txt_Cash.Text <> "" Then varvaluecash1 = txt_Cash.Text Else varvaluecash1 = 0
        If Com_Type.Text = "دائن" And txt_Cash.Text <> "" Then varvaluecash2 = txt_Cash.Text Else varvaluecash2 = 0


        sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & Com_GL_No.Text & "' and  flg =1  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("  من فضلك القيد تم ترحيله ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub






        sql = "INSERT INTO Genralledger (IDGenral, DateM,CodeLevel4,DisTable,Debit,Cridit,Typebill,No_Sand,Code_Sub,CostCenterNo,CruunceyNo,rat,Debit_EGP,Cridit_EGP,Compny_Code,UserID) " & _
        " values  ('" & Com_GL_No.Text & "' ,'" & vardate & "','" & txt_AccountNo.Text & "','" & txt_Notes.Text & "','" & varvaluecash1 & "','" & varvaluecash2 & "' ,'" & 8 & "','" & Com_GL_No.Text & "','" & 1 & "','" & txt_CostCenter.Text & "','" & varcode_Cru & "','" & txt_rat.Text & "','" & Val(varvaluecash1) * Val(txt_rat.Text) & "' ,'" & Val(varvaluecash2) * Val(txt_rat.Text) & "' ,'" & VarCodeCompny & "','" & varcode_User & "' )  "
        Cnn.Execute(sql)

        '============================== TransactionHistoryCode SaveBtn
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','8','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_GL_No.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_Cash.Text = ""
        txt_Cash.Text = ""
        txt_rat.Text = ""
        Txt_ValueCash.Text = ""

        find_hedar()
        find_detalis()
        Total_Sum()
    End Sub
    Sub Total_Sum()
        On Error Resume Next
        'Dim total As Single
        'Dim total2 As Single
        'For i As Integer = 0 To GridView6.RowCount - 1
        '    total += GridView6.GetRowCellValue(i, GridView6.Columns(6))
        '    total2 += GridView6.GetRowCellValue(i, GridView6.Columns(7))
        'Next
        'txt_TotalDebit.Text = Math.Round(total, 2)
        'txt_TotalCridit.Text = Math.Round(total2, 2)


        sql = "    SELECT        ROUND(SUM(Debit), 2) AS SumD, ROUND(SUM(Cridit), 2) AS SumC        FROM dbo.Genralledger GROUP BY IDGenral   HAVING(IDGenral = '" & Com_GL_No.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_TotalDebit.Text = rs("SumD").Value : txt_TotalCridit.Text = rs("SumC").Value

    End Sub

    Sub find_hedar()
        On Error Resume Next

        Dim varcodegl As Integer
        If Com_GL_No.Text = "" Then varcodegl = 0 Else varcodegl = Com_GL_No.Text


        sql = " SELECT       flgcancle, IDGenral, DateM, flg, Compny_Code,DisTable,Typebill    FROM dbo.Vw_All_GL_Data   WHERE  (IDGenral = '" & varcodegl & "')  and (Compny_Code = '" & VarCodeCompny & "')"



        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            Com_GL_No.Text = Trim(rs3("IDGenral").Value)



            'Dim dd As DateTime = Trim(rs3("DateM").Value)
            'Dim vardate As String
            'vardate = dd.ToString("yyyy/MM/dd")

            txt_GL_Date.Text = Trim(rs3("DateM").Value)

            If Trim(rs3("flg").Value) = "0" Then txt_Typeinv.Text = "غير مرحل" : txt_Typeinv.BackColor = Color.Gray
            If Trim(rs3("flg").Value) = "1" Then txt_Typeinv.Text = "مرحل" : txt_Typeinv.BackColor = Color.Green

            If Trim(rs3("flgcancle").Value) = "0" Then txt_status.Text = "غير ملغى" : txt_status.BackColor = Color.Gray
            If Trim(rs3("flgcancle").Value) = "1" Then txt_status.Text = "ملغى" : txt_status.BackColor = Color.Yellow

            vartypeGl = Trim(rs3("Typebill").Value)
        Else
            txt_Typeinv.Text = "غير مرحل" : txt_Typeinv.BackColor = Color.Gray
        End If

    End Sub

    Sub find_detalis()
        'If Com_GL_No.Text = "" Then Exit Sub
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        Dim varcodegl As Integer
        If Com_GL_No.Text = "" Then varcodegl = 0 Else varcodegl = Com_GL_No.Text


        sql = "    SELECT        CodeLevel4, rtrim(AccountName), rtrim(DisTable) as teble, Debit,Cridit , NameCruuncey,Debit_EGP, Cridit_EGP,CostCenterNo, RTRIM(NameContcenter) AS NameContcenter,'0' as aa,ID " & _
        " FROM            dbo.Vw_All_GL_Data " & _
        " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (IDGenral = '" & varcodegl & "') order by Cridit"



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        'GridView6.Columns(0).Width = "100"
        'GridView6.Columns(1).Width = "200"
        'GridView6.Columns(2).Width = "270"
        'GridView6.Columns(3).Width = "70"
        'GridView6.Columns(4).Width = "70"
        'GridView6.Columns(5).Width = "100"
        'GridView6.Columns(6).Width = "80"
        'GridView6.Columns(7).Width = "80"
        'GridView6.Columns(8).Width = "150"
        ''GridView6.Columns(9).Width = "200"
        'GridView6.Columns(10).Width = "150"




        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الحساب"
        GridView6.Columns(1).Caption = "أسم الحساب "
        GridView6.Columns(2).Caption = "البيان"
        GridView6.Columns(3).Caption = "مدين بالعملة"
        GridView6.Columns(4).Caption = "دائن بالعملة"
        GridView6.Columns(5).Caption = "العملة"
        GridView6.Columns(6).Caption = "مدين بالجنية"
        GridView6.Columns(7).Caption = "دائن بالجنية"
        GridView6.Columns(8).Caption = " رقم م التكلفة"
        GridView6.Columns(9).Caption = " مركز التكلفة"
        GridView6.Columns(10).Caption = ""
        GridView6.Columns(11).Caption = "م"
        GridView6.Columns(10).Visible = False
        GridView6.Columns(11).Visible = False

        GridView6.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView6.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

        GridView6.BestFitColumns()

        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Total_Sum()
    End Sub

    Private Sub Com_Cur_SelectedIndexChanged(sender As Object, e As EventArgs)
        '========================================================رقم العملة
        Cru_all()
    End Sub
    Sub Cru_all()
        On Error Resume Next
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_GL_Date.Text
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_GL_Date.Text, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102)) and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"
        '============================

        Txt_ValueCash.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 3)
    End Sub

    Private Sub txt_rat_TextChanged(sender As Object, e As EventArgs)
        Txt_ValueCash.Text = Math.Round(Val(txt_Cash.Text) * Val(txt_rat.Text), 3)

    End Sub



    Private Sub Frm_Gl4_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 1 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 0 'الصفحة التالية
        If e.KeyCode = Keys.F5 Then Cru_all() : save_gl() 'حفظ


        If e.KeyCode = Keys.F12 Then  'بحث
            find_gl()
        End If


    End Sub
    Sub find_gl()
        vartable = "Vw_LookupGL"
        VarOpenlookup = 28
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
    End Sub



    Private Sub Frm_Gl4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Cru()
        Com_Type.Items.Add("مدين")
        Com_Type.Items.Add("دائن")
        If statusopen = 0 Then
            clear_data()
            last_Data()
        End If

        CustomDrawRowIndicator(GridControl1, GridView1)
    End Sub
    Sub fill_Cru()
        Com_Cur.Items.Clear()
        sql = "    SELECT  Name  FROM BD_Currency where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Cur.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim x As String

        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub

        sql = "SELECT        IDGenral, Typebill, No_Sand        FROM dbo.Genralledger WHERE        (Typebill = 2) AND (IDGenral =  '" & Com_GL_No.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الغاء الترحيل القيد لانه مرتبط بفاتورة", MsgBoxStyle.Critical, "Css") : Exit Sub
        '==============================================================================



        x = MsgBox("هل تريد الغاء السند", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes



                sql = "UPDATE  Genralledger  SET flg = '" & 0 & "'  WHERE IDGenral = " & Com_GL_No.Text & "  and flg ='1' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                sql = "Delete MovmentStatement  WHERE TypeBill ='" & 8 & "' and NumberBill = " & Com_GL_No.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                MsgBox("تم الغاء الترحيل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End Select
        find_hedar()
        find_detalis()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub

        If Val(txt_TotalDebit.Text) <> Val(txt_TotalCridit.Text) Then MsgBox("القيد غير متساوى ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module") : Exit Sub
        save_Statment()
        MsgBox("تم الترحيل ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_hedar()
        find_detalis()
    End Sub

    Sub save_Statment()
        'On Error Resume Next
        sql = "Delete MovmentStatement  WHERE TypeBill ='" & 8 & "' and NumberBill = " & Com_GL_No.Text & " "
        rs = Cnn.Execute(sql)

        '================================================كشف الحساب
        Dim dd As DateTime = txt_GL_Date.text
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")

        sql = "UPDATE  Genralledger  SET flg = '" & 1 & "'  WHERE IDGenral = " & Com_GL_No.Text & "  and flg ='0' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        sql = "    SELECT  *  FROM Genralledger where IDGenral ='" & Com_GL_No.Text & "'and  Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF


            '================================================ترحيل الى كشف الحساب
            SQl3 = "INSERT INTO MovmentStatement (NumberBill, DateMoveM,AccountNo,Discription,Debit,Cridit,TypeBill,CostCenterNo,CruunceyNo,Debit_EGP,Cridit_EGP,Compny_Code,Rat_Cur,No_Sand) " & _
           " values  (N'" & Com_GL_No.Text & "' ,N'" & vardate & "',N'" & rs("CodeLevel4").Value & "'  ,N'" & rs("DisTable").Value & "',N'" & rs("Debit").Value & "',N'" & rs("Cridit").Value & "',N'" & "8" & "',N'" & rs("CostCenterNo").Value & "',N'" & rs("CruunceyNo").Value & "',N'" & rs("Debit_EGP").Value & "',N'" & rs("Cridit_EGP").Value & "',N'" & rs("Compny_Code").Value & "',N'" & rs("Rat").Value & "',N'" & Com_GL_No.Text & "'   )"
            rs2 = Cnn.Execute(SQl3)




            rs.MoveNext()
        Loop



    End Sub

    Private Sub cmd_Find_Click(sender As Object, e As EventArgs)


    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
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
    Sub Find_Data()

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



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        If CheckBox1.Checked = True Then
            sql2 = "       SELECT        IDGenral, DateM, CodeLevel4, rtrim(AccountName) as aa , DisTable, Debit, Cridit, NameCruuncey, rat, Debit_EGP, Cridit_EGP, LTRIM(NameContcenter) AS NameContcenter, Type_Bill ,status2, UserID,No_Sand     FROM dbo.Vw_All_GL_Data" & _
                " where   flg=1 and  (DateM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and  (Compny_Code = '" & VarCodeCompny & "') order by IDGenral "
        End If

        If CheckBox1.Checked = False Then
            sql2 = "       SELECT        IDGenral, DateM, CodeLevel4, rtrim(AccountName) as aa , DisTable, Debit, Cridit, NameCruuncey, rat, Debit_EGP, Cridit_EGP, LTRIM(NameContcenter) AS NameContcenter, Type_Bill ,status2, UserID,No_Sand     FROM dbo.Vw_All_GL_Data" & _
                " where   flg=0 and  (DateM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) and  (Compny_Code = '" & VarCodeCompny & "') order by IDGenral "
        End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

      


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم القيد"
        GridView1.Columns(1).Caption = "ناريخ القيد "
        GridView1.Columns(2).Caption = "رقم الحساب"
        GridView1.Columns(3).Caption = "أسم الحساب"
        GridView1.Columns(4).Caption = "البيان"
        GridView1.Columns(5).Caption = "مدين بالعملة"
        GridView1.Columns(6).Caption = "دائن بالعملة"
        GridView1.Columns(7).Caption = "العملة"
        GridView1.Columns(8).Caption = "م التحويل"
        GridView1.Columns(9).Caption = "مدين بالجنية"
        GridView1.Columns(10).Caption = "دائن بالجنية"
        GridView1.Columns(11).Caption = "أسم م التكلفة"
        GridView1.Columns(12).Caption = "نوع القيد"
        GridView1.Columns(13).Caption = "حالة القيد"
        GridView1.Columns(14).Caption = "رقم المستخدم"
        GridView1.Columns(15).Caption = "رقم السند"
        GridView1.BestFitColumns()



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum




    End Sub

    Sub Find_Data2()

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



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        If CheckBox1.Checked = True Then
            sql2 = "    SELECT        IDGenral, DateM, SUM(Debit_Egp) AS Debit, SUM(Cridit_Egp) AS Cridit,status,Type_Bill,status2, UserID, No_Sand " & _
                    " FROM            dbo.Vw_All_GL_Data " & _
                    " where flg=1 " & _
                    " GROUP BY IDGenral, DateM, flg,status,Type_Bill, Compny_Code,status2, UserID, No_Sand " & _
                    " HAVING         (Compny_Code = '" & VarCodeCompny & "' )  and (DateM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) order by IDGenral "
        End If



        If CheckBox1.Checked = False Then
            sql2 = "    SELECT        IDGenral, DateM, SUM(Debit_Egp) AS Debit, SUM(Cridit_Egp) AS Cridit,status,Type_Bill,status2, UserID, No_Sand " & _
                    " FROM            dbo.Vw_All_GL_Data " & _
                    " where flg=0" & _
                    " GROUP BY IDGenral, DateM, flg,status,Type_Bill, Compny_Code,status2, UserID, No_Sand " & _
                    " HAVING         (Compny_Code = '" & VarCodeCompny & "' )  and (DateM >= CONVERT(DATETIME, '" & vardate & "', 102)) and (DateM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) order by IDGenral "
        End If

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).Caption = "رقم القيد"
        GridView1.Columns(1).Caption = "ناريخ القيد "
        GridView1.Columns(2).Caption = "مدين"
        GridView1.Columns(3).Caption = "دائن"
        GridView1.Columns(4).Caption = "حالة القيد"
        GridView1.Columns(5).Caption = "نوع القيد"
        GridView1.Columns(6).Caption = "حالة القيد"
        GridView1.Columns(7).Caption = "رقم المستخدم"
        GridView1.Columns(8).Caption = "رقم السند"

        GridView1.BestFitColumns()
        'If GridView1.Columns(3).GetDescription.ToString = 0 Then GridView1.Columns(3).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(6).AppearanceCell.ForeColor = Color.Red



        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub




    Private Sub txt_Cash_EditValueChanged(sender As Object, e As EventArgs)
        Cru_all()
    End Sub

    Private Sub txt_Cash_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F5 Then
            Cru_all()
            save_gl()
        End If
    End Sub

    Private Sub txt_Cash_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            Cru_all()
            save_gl()

        End If



    End Sub



    Private Sub Com_GL_No_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_GL_No.ButtonClick
        vartable = "Vw_LookupGL"
        VarOpenlookup = 28
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
        GridView6.BestFitColumns()
        Total_Sum()
    End Sub

    Private Sub Com_GL_No_EditValueChanged(sender As Object, e As EventArgs) Handles Com_GL_No.EditValueChanged

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        txt_AccountNo.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_nameaccount.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))

        vardebit = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        varcridit = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        If vardebit > 0 Then txt_Cash.Text = vardebit : Txt_ValueCash.Text = vardebit : Com_Type.Text = "مدين"
        If varcridit > 0 Then txt_Cash.Text = varcridit : Txt_ValueCash.Text = varcridit : Com_Type.Text = "دائن"

        Com_Cur.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        txt_CostCenter.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
        txt_CostCenterName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(9))
        varid = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(11))
        find_hedar()
    End Sub

   

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_GL_No.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_Cash.Text = ""
        txt_Cash.Text = ""
        txt_rat.Text = ""
        Txt_ValueCash.Text = ""
        find_hedar()
        find_detalis()
        Total_Sum()
        GridView6.BestFitColumns()

        TabPane1.SelectedPageIndex = 0
    End Sub


    Private Sub GridControl3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl3.KeyDown
        If e.KeyCode = Keys.F5 Then
            Cru_all()
            save_gl()
        End If

        If e.KeyCode = Keys.F1 Then
            varcode_form = 48
            Frm_LookUpAccount.Fill_Acc()
            Frm_LookUpAccount.GridControl1.Select()
            Frm_LookUpAccount.Show()
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

   
    Private Sub Cmd_DeleteGl_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteGl.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub

        sql = "SELECT        IDGenral, Typebill, No_Sand        FROM dbo.Genralledger WHERE        (Typebill = 2) AND (IDGenral =  '" & Com_GL_No.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("لا يمكن الغاء القيد لانه مرتبط بفاتورة", MsgBoxStyle.Critical, "Css") : Exit Sub
        '==============================================================================


        sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & Com_GL_No.Text & "' and  flg =1  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("  من فضلك القيد تم ترحيله ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        x = MsgBox("هل تريد الغاء القيد", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                'sql = "Delete Genralledger  WHERE IDGenral = '" & Com_GL_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                'rs = Cnn.Execute(sql)

                sql = "UPDATE   Genralledger   SET flgcancle = '" & 1 & "' where  IDGenral = '" & Com_GL_No.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الالغاء", MsgBoxStyle.Information, "Css Solution Software Module")
                txt_status.Text = "ملغى" : txt_status.BackColor = Color.Yellow
                'clear_data()
                'last_Data()
        End Select
    End Sub

    Private Sub txt_nameaccount_KeyPress(sender As Object, e As KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(13) Then

            If OP3.Checked = True Then
                VarOpenlookup2 = 27
                varcode_form = 27
                txt_AccountNo.Text = ""
                Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
                Frm_LookUpCustomer.Find_Customer()
                Frm_LookUpCustomer.ShowDialog()
            ElseIf OP4.Checked = True Then
                VarOpenlookup2 = 28
                varcode_form = 28
                txt_AccountNo.Text = ""
                Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
                Frm_LookUpCustomer.Find_Suppliser()
                Frm_LookUpCustomer.ShowDialog()

            ElseIf OP5.Checked = True Then
                varcode_form = 48
                Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()
                Frm_LookUpAccount.GridControl1.Select()
                Frm_LookUpAccount.Show()
            End If

        End If

    End Sub

    Private Sub txt_nameaccount_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_EditorKeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.EditorKeyPress
      
    End Sub

    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
            'If RadioButton1.Checked = True Then
            Com_GL_No.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
            find_hedar()
            find_detalis()
            Total_Sum()
            TabPane1.SelectedPageIndex = 0
        End If

       
    End Sub

    Private Sub cmd_Find_Click_1(sender As Object, e As EventArgs) Handles cmd_Find.Click
        If OP2.Checked = True Then Find_Data() : GridView6.BestFitColumns()
        If OP1.Checked = True Then Find_Data2() : GridView6.BestFitColumns()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'Frm_ReportGlAll.Show()
        Frm_ReportGlAll2.Show()
    End Sub

   
    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        If OP2.Checked = True Then Find_Data()
        If OP1.Checked = True Then Find_Data2()
    End Sub

  

    Private Sub SimpleButton11_KeyDown(sender As Object, e As KeyEventArgs) Handles SimpleButton11.KeyDown
        If e.KeyCode = Keys.F5 Then
            Cru_all()
            save_gl()
        End If
    End Sub

    Private Sub SimpleButton11_Click_1(sender As Object, e As EventArgs) Handles SimpleButton11.Click



        If OP3.Checked = True Then
            VarOpenlookup2 = 27
            varcode_form = 27
            Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
            Frm_LookUpCustomer.Find_Customer()
            Frm_LookUpCustomer.ShowDialog()
        ElseIf OP4.Checked = True Then
            VarOpenlookup2 = 28
            varcode_form = 28
            Frm_LookUpCustomer.txt_AccountName.Text = txt_nameaccount.Text
            Frm_LookUpCustomer.Find_Suppliser()
            Frm_LookUpCustomer.ShowDialog()

        ElseIf OP5.Checked = True Then
            varcode_form = 48
            Frm_LookUpAccount.Fill_Acc_Withount_CustomerSupliser()

            Frm_LookUpAccount.GridControl1.Select()
            Frm_LookUpAccount.Show()
        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        vartable = "Vw_CostcenterAll"
        VarOpenlookup = 53
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        clear_data()
        last_Data()
        find_hedar()
        find_detalis()
        Total_Sum()
        vartypeGl = 8
    End Sub

    Private Sub cmd_Save_Click_1(sender As Object, e As EventArgs) Handles cmd_Save.Click
        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub

        Cru_all()
        save_gl()
    End Sub

    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub

        Dim dd As DateTime = txt_GL_Date.Text
        Dim vardate As String
        vardate = dd.ToString("MM-d-yyyy")

        sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & Com_GL_No.Text & "' and  flg =1  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("  من فضلك القيد تم ترحيله ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cur.Text & "' and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value


        If Com_Type.Text = "مدين" And txt_Cash.Text <> "" Then varvaluecash1 = txt_Cash.Text Else varvaluecash1 = 0
        If Com_Type.Text = "دائن" And txt_Cash.Text <> "" Then varvaluecash2 = txt_Cash.Text Else varvaluecash2 = 0

        sql = "UPDATE  Genralledger  SET DateM ='" & vardate & "' WHERE IDGenral = '" & Com_GL_No.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)


        sql = "UPDATE  Genralledger  SET CodeLevel4 ='" & txt_AccountNo.Text & "',DisTable ='" & txt_Notes.Text & "',Debit ='" & varvaluecash1 & "' , Cridit ='" & varvaluecash2 & "',Debit_EGP ='" & Val(varvaluecash1) * Val(txt_rat.Text) & "' , Cridit_EGP ='" & Val(varvaluecash2) * Val(txt_rat.Text) & "',CruunceyNo ='" & varcode_Cru & "',CostCenterNo ='" & txt_CostCenter.Text & "' WHERE IDGenral = '" & Com_GL_No.Text & "' and ID ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        '============================== TransactionHistoryCode EditRowBtn
        sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','8','6','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_GL_No.Text & "')"
        rs2 = Cnn.Execute(sql2)
        '==============================

        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

        find_detalis()
        Total_Sum()
    End Sub

    Private Sub SimpleButton8_Click_1(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        On Error Resume Next
        Dim x As String
        'Dim varcount As Integer
        If vartypeGl <> 8 Then MsgBox("لا يمكن الغاء الترحيل القيد حركة", MsgBoxStyle.Critical, "Css") : Exit Sub


        sql = "  SELECT *    FROM Genralledger where    Compny_Code = '" & VarCodeCompny & "' and  IDGenral  ='" & Com_GL_No.Text & "' and  flg =1  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("  من فضلك القيد تم ترحيله ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Genralledger  WHERE IDGenral = '" & Com_GL_No.Text & "' and ID ='" & varid & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                '============================== TransactionHistoryCode CancelBtn
                sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','8','7','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & Com_GL_No.Text & "')"
                rs2 = Cnn.Execute(sql2)
                '==============================


                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_detalis()
                Total_Sum()
        End Select
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        frmPrintGL.Show()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        If OP2.Checked = True Then
            txt_NoSnad.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(15))
            txt_Type.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(12))
        End If



        If OP1.Checked = True Then
            txt_NoSnad.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))
            txt_Type.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        End If

    End Sub

    Private Sub Com_Cur_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Com_Cur.SelectedIndexChanged
        Cru_all()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        If txt_Type.Text = "فاتورة مبيعات" Then

            sql = " SELECT *      FROM dbo.TB_Header_InvoiceSal WHERE  (Ser_InvoiceNo = '" & txt_NoSnad.Text & "')"
            rs = Cnn.Execute(sql)

            Frm_SalseInvoice.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_SalseInvoice.find_hedar()
            Frm_SalseInvoice.find_detalis()
            Frm_SalseInvoice.MdiParent = Mainmune
            Frm_SalseInvoice.Total_Sum()
            Frm_SalseInvoice.sum_tax()
            'Frm_All_Invoice.Enabled = True
            Frm_SalseInvoice.Show()
        End If


        If txt_Type.Text = "فاتورة شراء" Then

            sql = " SELECT Ext_InvoiceNo FROM dbo.TB_Header_InvoicePrcheses WHERE  (Ser_InvoiceNo = '" & txt_NoSnad.Text & "')"
            rs = Cnn.Execute(sql)

            Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_Prcheses_Invoice.find_hedar()
            Frm_Prcheses_Invoice.find_detalis()
            Frm_Prcheses_Invoice.Total_Sum()
            Frm_Prcheses_Invoice.sum_tax()
            'Frm_All_Invoice.Enabled = True
            Frm_Prcheses_Invoice.MdiParent = Mainmune
            Frm_Prcheses_Invoice.Show()
            Frm_Prcheses_Invoice.find_hedar()
        End If


        If txt_Type.Text = "فاتورة مرتد شراء" Then

            sql = " SELECT Ext_InvoiceNo FROM dbo.TB_Header_InvoicePrcheses_Rented WHERE  (Ser_InvoiceNo = '" & txt_NoSnad.Text & "')"
            rs = Cnn.Execute(sql)

            Frm_Prcheses_Invoice_Rented.Com_InvoiceNo2.Text = rs("Ext_InvoiceNo").Value

            'varinvoice_type2 = 1
            'Frm_All_Invoice.Fill_INVOICE2()
            Frm_Prcheses_Invoice_Rented.MdiParent = Mainmune
            Frm_Prcheses_Invoice_Rented.Show()
            Frm_Prcheses_Invoice_Rented.find_hedar()
            Frm_Prcheses_Invoice_Rented.find_detalis()
            Frm_Prcheses_Invoice_Rented.Total_Sum()
            Frm_Prcheses_Invoice_Rented.sum_tax()

        End If





        If txt_Type.Text = "سند قبض" Then
            Frm_ReciptCash2.Com_Exp_No.Text = txt_NoSnad.Text
            Frm_ReciptCash2.find_hedar()
            Frm_ReciptCash2.find_detalis()

            Frm_ReciptCash2.find_all_Detils()

            Frm_ReciptCash2.Total_Sum()
            Frm_ReciptCash2.MdiParent = Mainmune
            'Frm_Receipt.Enabled = True
            Frm_ReciptCash2.Show()
        End If

        If txt_Type.Text = "سند صرف" Then
            Frm_Expenses2.Com_Exp_No.Text = txt_NoSnad.Text
            Frm_Expenses2.find_hedar()
            Frm_Expenses2.find_detalis()

            'Frm_Expenses2.find_all_Detils()

            Frm_Expenses2.Total_Sum2()

            Frm_Expenses2.MdiParent = Mainmune
            'Frm_Receipt.Enabled = True
            Frm_Expenses2.Show()
        End If

        'If txt_Type.Text = "قيد يومية" Then
        '    'varinvoice_type2 = 10
        '    Frm_Gl4.Com_GL_No.Text = txt_NoSnad.Text
        '    Frm_Gl4.find_hedar()
        '    Frm_Gl4.find_detalis()


        '    Frm_Gl4.Total_Sum()
        '    Frm_Gl4.MdiParent = Mainmune
        '    'Frm_Receipt.Enabled = True
        '    Frm_Gl4.Show()
        'End If



        'If DataGridView2.Item(6, mt).Value = "فاتورة مشتريات" Then
        '    Frm_Invoice_Prcheses.Com_InvoiceNo2.Text = DataGridView2.Item(0, mt).Value
        '    sql = " SELECT Ex_No, NumberBill      FROM dbo.BillBrchsesHder WHERE  (NumberBill = '" & DataGridView2.Item(0, mt).Value & "')"
        '    rs = Cnn.Execute(sql)
        '    If rs.EOF = False Then Frm_Invoice_Prcheses.Com_InvoiceNo.Text = rs("NumberBill").Value
        '    varinvoice_type2 = 4
        '    Frm_Invoice_Prcheses.Fill_INVOICE2()
        '    Frm_Invoice_Prcheses.MdiParent = Mainmune
        '    'Frm_All_Invoice.Enabled = True
        '    Frm_Invoice_Prcheses.Show()
        'End If

        If txt_Type.Text = "فاتورة مرتجع" Then
            'Frm_InvoiceRented.Com_InvoiceNo2.Text = DataGridView2.Item(0, mt).Value
            Frm_InvoiceRented.Com_InvoiceNo.Text = txt_NoSnad.Text
            Frm_InvoiceRented.find_hedar()
            Frm_InvoiceRented.find_detalis()
            Frm_InvoiceRented.sum_tax()
            Frm_InvoiceRented.Total_Sum()
            Frm_InvoiceRented.MdiParent = Mainmune
            'Frm_All_Invoice.Enabled = True
            Frm_InvoiceRented.Show()
        End If
    End Sub
End Class