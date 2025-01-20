Imports System.Data.OleDb

Public Class Frm_GL2

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        vartable = "Vw_LookupGL"
        VarOpenlookup = 28
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_hedar()
        find_detalis()
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "    SELECT        CodeLevel4, AccountName, DisTable, Debit_EGP, Cridit_EGP, NameCruuncey, No_Sand, Type_Bill, CostCenterNo, RTRIM(NameContcenter) AS NameContcenter " & _
    " FROM            dbo.Vw_All_GL_Data " & _
    " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (IDGenral = '" & Com_GL_No.Text & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "200"
        GridView6.Columns(2).Width = "170"
        GridView6.Columns(3).Width = "70"
        GridView6.Columns(4).Width = "70"
        GridView6.Columns(5).Width = "100"
        GridView6.Columns(6).Width = "80"
        GridView6.Columns(7).Width = "80"
        GridView6.Columns(8).Width = "120"
        GridView6.Columns(9).Width = "120"
      


        'GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red

        'GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        'GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "رقم الحساب"
        GridView6.Columns(1).Caption = "أسم الحساب "
        GridView6.Columns(2).Caption = "البيان"
        GridView6.Columns(3).Caption = "مدين"
        GridView6.Columns(4).Caption = "دائن"
        GridView6.Columns(5).Caption = "العملة"
        GridView6.Columns(6).Caption = "رقم السند"
        GridView6.Columns(7).Caption = "نوع السند"
        GridView6.Columns(8).Caption = "رقم مركز التكلفة"
        GridView6.Columns(9).Caption = "أسم مركز التكلفة"
      





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Total_Sum()
    End Sub
    Sub Total_Sum()

        Dim total As String = 0
        Dim total2 As String = 0
        For i As Integer = 0 To GridView6.RowCount - 1
            total += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(3)))
            total2 += CInt(GridView6.GetRowCellValue(i, GridView6.Columns(4)))
        Next
        txt_De.Text = total
        txt_Cr.Text = total2

    End Sub
    Sub find_hedar()
        On Error Resume Next
        sql = " SELECT        IDGenral, DateM, flg, Compny_Code,DisTable   FROM dbo.Vw_All_GL_Data   WHERE  (IDGenral = '" & Com_GL_No.Text & "')  and (Compny_Code = '" & VarCodeCompny & "')"



        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            Com_GL_No.Text = Trim(rs3("IDGenral").Value)

            txt_date.Text = Trim(rs3("DateM").Value)
            'txt_Notes.Text = Trim(rs3("DisTable").Value)


            If Trim(rs3("flg").Value) = "0" Then txt_Typeinv.Text = "غير ملغى" : txt_Typeinv.BackColor = Color.Gray
            If Trim(rs3("flg").Value) = "1" Then txt_Typeinv.Text = "ملغى" : txt_Typeinv.BackColor = Color.Red

        End If

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Report_GL.Show()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click

    End Sub
End Class