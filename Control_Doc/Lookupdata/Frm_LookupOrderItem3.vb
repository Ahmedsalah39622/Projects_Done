Imports System.Data.OleDb

Public Class Frm_LookupOrderItem3
    Dim varmaxmim, VarQty As Integer
    Dim VarProdactName, varunit As String
    Sub Search()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql2 = "select   * from Vw_LookupOrderItem3 "


            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"

            GridView1.Columns(0).Caption = "رقم الطلبية"
            GridView1.Columns(1).Caption = "تاريخ الطلبية"
            GridView1.Columns(2).Caption = "رقم الصنف"
            GridView1.Columns(3).Caption = "أسم الصنف"
            GridView1.Columns(4).Caption = "الكمية "
            GridView1.Columns(5).Caption = "الوحدة"
            'GridView1.Columns(6).Caption = "الكمية بالرولات"
            'GridView1.Columns(7).Caption = "الوحدة2"
            GridView1.Columns(6).Caption = "أسم العميل"

            GridView1.Columns(6).Visible = False

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True
            GridView1.BestFitColumns()
            'GridView1.Columns(0).Width = "100"
            'GridView1.Columns(1).Width = "100"
            'GridView1.Columns(2).Width = "100"
            'GridView1.Columns(3).Width = "200"
            'GridView1.Columns(4).Width = "100"
            'GridView1.Columns(5).Width = "100"
            'GridView1.Columns(6).Width = "100"
            'GridView1.Columns(7).Width = "100"
            'GridView1.Columns(8).Width = "200"


            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


    End Sub

    Private Sub Frm_LookupOrderItem3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Me.Close()


    End Sub

    Private Sub Frm_LookupOrderItem3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
        Fill_Phases()
    End Sub





    Private Sub GridControl1_DoubleClick2(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

 
        txt_OrderNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        VarProdactName = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        VarQty = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Varunit = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))


    End Sub
    Sub Fill_Phases()
        sql = "  SELECT Code, RTRIM(Name) AS Name       FROM dbo.TB_Phases    WHERE(Code = 1)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_phazes.Text = rs("name").Value
    End Sub

    Private Sub txt_MachinName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachinName.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 380
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachinName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachinName.EditValueChanged

    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_NewJobOrder.Click
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من فضلك أختار الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        last_Data()

        txt_Ref.Text = txt_OrderNo.Text + "-" + "C"

        MsgBox("تم انشاء رقم امر شغل جديد " & Com_InvoiceNo2.Text & "على عملية انتاج  " & txt_Ref.Text & "  للمنتج المطلوب " & VarProdactName, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module")
    End Sub
    Sub last_Data()

        sql = "  SELECT        MAX(JOB_Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_JOB_Order    GROUP BY Compny_Code  HAVING        (MAX(JOB_Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varmaxmim = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = Trim(txt_MachinName.Text) + Str(varmaxmim)

        Else
            varmaxmim = 1
            Com_InvoiceNo2.Text = Trim(txt_MachinName.Text) + "1"


        End If
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        Frm_ProudactionOrder.txt_Ref.Text = txt_Ref.Text
        Frm_ProudactionOrder.txt_OrderNo.Text = txt_OrderNo.Text
        Frm_ProudactionOrder.Com_InvoiceNo.Text = varmaxmim
        Frm_ProudactionOrder.Com_InvoiceNo2.Text = Com_InvoiceNo2.Text
        Frm_ProudactionOrder.txt_MachinName.Text = txt_MachinName.Text
        Frm_ProudactionOrder.com_phases.Text = txt_phazes.Text
        Frm_ProudactionOrder.txt_ItemRequird.Text = VarProdactName
        Frm_ProudactionOrder.txt_QtyRequird2.Text = VarQty
        Frm_ProudactionOrder.txt_Unit_Kilo1.Text = varunit

        Dim x
        x = MsgBox("سيتم تفعيل أمر الشغل وفتح شاشة امر الشغل الجديد", MsgBoxStyle.YesNo + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module")

        Select Case x
            Case vbYes

                Frm_ProudactionOrder.MdiParent = Mainmune
                Frm_ProudactionOrder.Show()
                Me.Close()
            Case vbNo

        End Select
     



    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class