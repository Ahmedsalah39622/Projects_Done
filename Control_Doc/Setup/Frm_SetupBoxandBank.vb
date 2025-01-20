Imports System.Data.OleDb

Public Class Frm_SetupBoxandBank

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        Dim sql2 As String

        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_SetupBox  where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_SetupBox (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find()
        txt_AccountNo.Text = ""
        txt_AccountName.Text = ""
    End Sub
    Sub Find()
        'On Error Resume Next


        sql = "  SELECT St_SetupBox.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_SetupBox INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_SetupBox.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_SetupBox.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl2.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView4.Columns(0).Caption = "الكود"
            GridView4.Columns(1).Caption = "الاسم"
            'GridView4.Columns(0).Width = "20"
            'GridView4.Columns(1).Width = "50"
            GridView4.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView4.Appearance.Row.Options.UseFont = True
            GridView4.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub
    Sub Find2()
        'On Error Resume Next


        sql = "  SELECT St_SetupBank.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_SetupBank INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_SetupBank.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_SetupBank.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True
            GridView1.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub
    Sub Find3()
        'On Error Resume Next


        sql = "  SELECT St_SetupKabd.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_SetupKabd INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_SetupKabd.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_SetupKabd.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView2.Columns(0).Caption = "الكود"
            GridView2.Columns(1).Caption = "الاسم"

            GridView2.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView2.Appearance.Row.Options.UseFont = True
            GridView2.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub

    Sub Find4()
        'On Error Resume Next


        sql = "  SELECT St_Setupdfa.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_Setupdfa INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_Setupdfa.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_Setupdfa.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl4.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView3.Columns(0).Caption = "الكود"
            GridView3.Columns(1).Caption = "الاسم"

            GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView3.Appearance.Row.Options.UseFont = True
            GridView3.BestFitColumns()

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub


    Sub Find6()
        On Error Resume Next


        'sql = "  SELECT St_Setupdfa.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
        '        " FROM     St_Setupdfa INNER JOIN " & _
        '        "                  ST_CHARTOFACCOUNT ON St_Setupdfa.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
        '        "        St_Setupdfa.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "
        sql = "   SELECT        dbo.TB_TypeExpensess.Name, dbo.TB_GroupExpeness.AccountNoExspensess, dbo.ST_CHARTOFACCOUNT.AccountName " & _
            " FROM           dbo.TB_GroupExpeness LEFT OUTER JOIN " & _
        "                 dbo.TB_TypeExpensess ON dbo.TB_GroupExpeness.Group1No = dbo.TB_TypeExpensess.Code AND dbo.TB_GroupExpeness.Compny_Code = dbo.TB_TypeExpensess.Compny_Code LEFT OUTER JOIN " & _
        "                 dbo.ST_CHARTOFACCOUNT ON dbo.TB_GroupExpeness.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
        " dbo.TB_GroupExpeness.AccountNoExspensess = dbo.ST_CHARTOFACCOUNT.Account_No " & _
        " WHERE(dbo.TB_GroupExpeness.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_TypeExpensess.Name LIKE '%" & com_GroupExpensses.Text & "%') "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView6.Columns(0).Caption = "نوع المصروف"
        GridView6.Columns(1).Caption = "رقم الحساب"
        GridView6.Columns(2).Caption = "اسم الحساب"

        GridView6.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True
        GridView6.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Sub Find5()
        'On Error Resume Next


        sql = "  SELECT St_SetupChekThsel.Account_No, ST_CHARTOFACCOUNT.AccountName " & _
                " FROM     St_SetupChekThsel INNER JOIN " & _
                "                  ST_CHARTOFACCOUNT ON St_SetupChekThsel.Account_No = ST_CHARTOFACCOUNT.Account_No AND  " & _
                "        St_SetupChekThsel.Compny_Code = ST_CHARTOFACCOUNT.Compny_Code  WHERE        (dbo.ST_CHARTOFACCOUNT.Compny_Code = '" & VarCodeCompny & "')  "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl5.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView5.Columns(0).Caption = "الكود"
            GridView5.Columns(1).Caption = "الاسم"

            GridView5.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView5.Appearance.Row.Options.UseFont = True
            GridView5.BestFitColumns()


            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete St_SetupBox  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find()
        txt_AccountNo.Text = ""
        txt_AccountName.Text = ""

    End Sub

  

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        Dim value = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        Dim value2 = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(1))
        txt_AccountNo.Text = value
        txt_AccountName.Text = value2

    End Sub

    Private Sub txt_AccountName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 46
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

   

    Private Sub Cmd_Save2_Click(sender As Object, e As EventArgs) Handles Cmd_Save2.Click
        Dim sql2 As String

        If Len(txt_AccountNo1.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName1.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_SetupBank  where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo1.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_SetupBank (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo1.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find2()
        txt_AccountNo1.Text = ""
        txt_AccountName1.Text = ""

    End Sub

    
    Private Sub Cmd_Delete2_Click(sender As Object, e As EventArgs) Handles Cmd_Delete2.Click
        sql = "Delete St_SetupBank  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo1.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find2()
        txt_AccountNo1.Text = ""
        txt_AccountName1.Text = ""

    End Sub

   

    Private Sub txt_AccountName2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName1.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 47
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

  

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_AccountNo1.Text = value
        txt_AccountName1.Text = value2
    End Sub

    Private Sub Cmd_Delete3_Click(sender As Object, e As EventArgs) Handles Cmd_Delete3.Click
        sql = "Delete St_SetupKabd  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo2.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find2()
        txt_AccountNo.Text = ""
        txt_AccountName.Text = ""

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        Dim value = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        Dim value2 = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(1))
        txt_AccountNo2.Text = value
        txt_AccountName2.Text = value2
    End Sub

    Private Sub Cmd_Save3_Click(sender As Object, e As EventArgs) Handles Cmd_Save3.Click
        Dim sql2 As String

        If Len(txt_AccountNo2.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName2.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_Setupkabd  where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo2.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_Setupkabd (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo2.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find3()
        txt_AccountNo2.Text = ""
        txt_AccountName2.Text = ""

    End Sub

    Private Sub txt_AccountName2_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName2.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 48
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    

    Private Sub Frm_SetupBoxandBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find()
        Find2()
        Find3()
        Find4()
        Find5()
        Find6()
        fill_Exp()
    End Sub
    Sub fill_Exp()
        com_GroupExpensses.Items.Clear()
        sql = "SELECT        Name FROM            dbo.TB_TypeExpensess  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_GroupExpensses.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub Cmd_Save4_Click(sender As Object, e As EventArgs) Handles Cmd_Save4.Click
        Dim sql2 As String

        If Len(txt_AccountNo3.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName3.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_SetupDfa  where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo3.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_SetupDfa (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo3.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find4()
        txt_AccountNo3.Text = ""
        txt_AccountName3.Text = ""

    End Sub

    Private Sub Cmd_Delete4_Click(sender As Object, e As EventArgs) Handles Cmd_Delete4.Click
        sql = "Delete St_Setupdfa  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo3.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find4()
        txt_AccountNo3.Text = ""
        txt_AccountName3.Text = ""

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Dim value = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Dim value2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_AccountNo3.Text = value
        txt_AccountName3.Text = value2
    End Sub

    Private Sub txt_AccountName2_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountName2.EditValueChanged

    End Sub

    Private Sub txt_AccountName3_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName3.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 49
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_AccountName3_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountName3.EditValueChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub cmd_Save5_Click(sender As Object, e As EventArgs) Handles cmd_Save5.Click
        Dim sql2 As String

        If Len(txt_AccountNo4.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName4.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT Account_No, Compny_Code      FROM St_SetupChekThsel  where Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo4.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("رقم الحساب موجود من قبل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "INSERT INTO St_SetupChekThsel (Account_No, Compny_Code) " & _
          " values  ('" & txt_AccountNo4.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find5()
        txt_AccountNo4.Text = ""
        txt_AccountName4.Text = ""
    End Sub

    Private Sub Cmd_Delete5_Click(sender As Object, e As EventArgs) Handles Cmd_Delete5.Click
        sql = "Delete St_SetupChekThsel  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo4.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find5()
        txt_AccountNo4.Text = ""
        txt_AccountName4.Text = ""
    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.Click

    End Sub

    Private Sub GridControl5_DoubleClick(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        Dim value = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Dim value2 = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        txt_AccountNo4.Text = value
        txt_AccountName4.Text = value2
    End Sub

    Private Sub txt_AccountName4_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName4.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 55
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_AccountName4_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountName4.EditValueChanged

    End Sub

    Private Sub txt_AccountName5_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_AccountName5.ButtonClick
        vartable = "vw_AccountData"
        VarOpenlookup = 555
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_AccountName5_EditValueChanged(sender As Object, e As EventArgs) Handles txt_AccountName5.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sql2 As String
        Dim varcodegroupExp As Integer
        If Len(com_GroupExpensses.Text) = 0 Then MsgBox("من فضلك نوع المصاريف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_AccountNo5.Text) = 0 Then MsgBox("من فضلك ادخل الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountName5.Text) = 0 Then MsgBox("من فضلك ادخل أسم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "  SELECT *     FROM TB_TypeExpensess  where Compny_Code = " & VarCodeCompny & " and Name ='" & com_GroupExpensses.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodegroupExp = rs("code").Value



        sql2 = "INSERT INTO TB_GroupExpeness (Group1No,AccountNoExspensess, Compny_Code) " & _
          " values  ('" & varcodegroupExp & "','" & txt_AccountNo5.Text & "' ,'" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        txt_AccountNo5.Text = ""
        txt_AccountName5.Text = ""
        Find6()
    End Sub

    Private Sub com_GroupExpensses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_GroupExpensses.SelectedIndexChanged
        Find6()
    End Sub

   

    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs) Handles GridControl6.DoubleClick
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        Dim value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        Dim value2 = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_AccountNo5.Text = value
        txt_AccountName5.Text = value2
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        sql = "Delete TB_GroupExpeness  WHERE Compny_Code = " & VarCodeCompny & " and AccountNoExspensess ='" & txt_AccountNo5.Text & "' "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

        Find6()
        txt_AccountNo5.Text = ""
        txt_AccountName5.Text = ""

    End Sub

    Private Sub GridControl6_Click(sender As Object, e As EventArgs) Handles GridControl6.Click

    End Sub
End Class