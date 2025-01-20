Imports System.Data.OleDb

Public Class Frm_Lookup_Add_PO_Etmad
    Sub Find_all()
        On Error Resume Next

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        If OP1.Checked = True Then sql = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "' and (Vw_All_PO2.Code_Etmad IS NOT NULL) "
        If OP2.Checked = True Then sql = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "' and (Vw_All_PO2.Code_Etmad IS NULL) "
        If OP3.Checked = True Then sql = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "'  "

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
        GridView1.Columns(0).Caption = "رقم أمر الشراء"
        GridView1.Columns(1).Caption = "التاريخ "
        GridView1.Columns(2).Caption = "نوع أمر الشراء"
        GridView1.Columns(3).Caption = "أسم المورد"
        GridView1.Columns(4).Caption = "رقم الصنف"
        GridView1.Columns(5).Caption = "أسم الصنف"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "الكمية"
        GridView1.Columns(8).Caption = "سعر الوحدة"
        GridView1.Columns(9).Caption = "العملة"
        GridView1.Columns(10).Caption = "معامل التحويل"
        GridView1.Columns(11).Caption = "الاجمالى"


        GridView1.Columns(12).Visible = False
        GridView1.Columns(13).Visible = False
        GridView1.Columns(14).Visible = False



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub



    Sub Find_Detils()
        On Error Resume Next

        GridControl2.DataSource = Nothing
        GridView3.Columns.Clear()

        'If OP1.Checked = True Then sql2 = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "'  and (Vw_All_PO2.Code_Etmad ='" & varcode_etmad & "') "
        If OP2.Checked = True Then sql2 = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "'  and (Vw_All_PO2.Code_Etmad ='" & varcode_etmad & "') "

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
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView3.Columns(0).Caption = "رقم أمر الشراء"
        GridView3.Columns(1).Caption = "التاريخ "
        GridView3.Columns(2).Caption = "نوع أمر الشراء"
        GridView3.Columns(3).Caption = "أسم المورد"
        GridView3.Columns(4).Caption = "رقم الصنف"
        GridView3.Columns(5).Caption = "أسم الصنف"
        GridView3.Columns(6).Caption = "الوحدة"
        GridView3.Columns(7).Caption = "الكمية"
        GridView3.Columns(8).Caption = "سعر الوحدة"
        GridView3.Columns(9).Caption = "العملة"
        GridView3.Columns(10).Caption = "معامل التحويل"
        GridView3.Columns(11).Caption = "الاجمالى"


        GridView3.Columns(12).Visible = False
        GridView3.Columns(13).Visible = False
        GridView3.Columns(14).Visible = False



        GridView3.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView3.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub

    Private Sub Frm_Lookup_Add_PO_Etmad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_all()
        Find_Detils()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles OP1.CheckedChanged
        'Find_all()
        'Find_Detils()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles OP1.Click
        Find_all()
        Find_Detils()
    End Sub

   

   
    Private Sub OP2_Click(sender As Object, e As EventArgs) Handles OP2.Click
        Find_all()
        Find_Detils()
    End Sub

    Private Sub Cmd_AddInvoice_Click(sender As Object, e As EventArgs) Handles Cmd_AddInvoice.Click
        Me.Close()
        Frm_OpenE3tmad.Find_Detils_PO_Etmad()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
        Frm_OpenE3tmad.Find_Detils_PO_Etmad()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        'If typeInvoice = 1 Then
        Dim value9 As String
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        sql = "UPDATE  TB_Detils_PO2  SET Code_Etmad ='" & varcode_etmad & "' WHERE No_Item = '" & value2 & "' and Order_Stores_NO ='" & value & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Find_all()
        Find_Detils()
    End Sub

    Private Sub OP2_CheckedChanged(sender As Object, e As EventArgs) Handles OP2.CheckedChanged
        'Find_all()
        'Find_Detils()
    End Sub

    Private Sub OP3_CheckedChanged(sender As Object, e As EventArgs) Handles OP3.CheckedChanged
        'Find_all()
        'Find_Detils()
    End Sub
End Class