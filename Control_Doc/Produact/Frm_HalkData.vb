Imports System.Data.OleDb

Public Class Frm_HalkData
    Dim varcodunit1, varmachinNo, varcodestores2, varcodeshift As Integer

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs)
        'cmd_FindItem.Enabled = True
    End Sub

    Private Sub Cmd_NewJobOrder_Click(sender As Object, e As EventArgs)
        'If Op1.Checked = True Or Op2.Checked = True Then
        '    cmd_FindItem.Enabled = True
        'Else
        '    cmd_FindItem.Enabled = False
        'End If
    End Sub

    Private Sub cmd_FindItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Frm_Azn_AddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F1 Then TabPane1.SelectedPageIndex = 1 ' الصفحة السابقة
        If e.KeyCode = Keys.F2 Then TabPane1.SelectedPageIndex = 0 'الصفحة التالية


    End Sub

    Private Sub Frm_Azn_AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
        Search()
        fill_Unit()
    End Sub
    Sub fill_Unit()
        txt_unit.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Unit  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_unit.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub clear_detils()
        'txt_MachinName.Text = ""
        txt_QytItem.Text = ""
        txt_MachinName.Text = ""
        txt_unit.Text = ""
        Com_StoresNo.Text = ""
        txt_notes.Text = ""
        com_Shift.Text = ""
        txt_date.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub cmd_FindItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Sub find_hedar()
        On Error Resume Next

        sql = "    SELECT        Code_H, Date_Halek, Compny_Code FROM dbo.TB_HalekData WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Code_H = '" & Com_InvoiceNo2.Text & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = Trim(rs("Code_H").Value)
            txt_date.Text = Trim(rs("Date_Halek").Value)

        End If
    End Sub
    Sub save_Order_H()
        On Error Resume Next
        Dim dd As DateTime = txt_date.Value
        Dim vardateorder As String
        vardateorder = dd.ToString("MM-d-yyyy")



      

            '=====================================================
            sql = "    SELECT        *         FROM dbo.BD_Unit WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_unit.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodunit1 = rs("Code").Value
            '====================================================
            sql = "    SELECT        *         FROM dbo.TB_MachineName WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_MachinName.Text & "')"
            rs2 = Cnn.Execute(sql)
            If rs2.EOF = False Then varmachinNo = rs2("Code").Value
            '=========================================================
            sql = "    SELECT        *         FROM dbo.BD_Stores WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & Com_StoresNo.Text & "')"
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then varcodestores2 = rs3("Code").Value
            '=========================================================
        sql = "    SELECT        *         FROM dbo.TB_Shift WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & com_Shift.Text & "')"
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodeshift = rs3("Code").Value
        '=========================================================


        sql2 = "INSERT INTO TB_HalekData (Code_H, Compny_Code,Date_Halek,Machine_No,Qty_H,Code_Unit,Code_Stores,Notes,shift_No) " & _
                      " values  ('" & Com_InvoiceNo2.Text & "' ,'" & VarCodeCompny & "','" & vardateorder & "','" & varmachinNo & "','" & txt_QytItem.Text & "','" & varcodunit1 & "','" & varcodestores2 & "','" & txt_notes.Text & "','" & varcodeshift & "')"
            Cnn.Execute(sql2)




        'Next

    End Sub
   
    Sub last_Data()

        sql = "  SELECT        MAX(Code_H) AS MaxMaim,Compny_Code FROM            TB_HalekData    GROUP BY Compny_Code  HAVING        (MAX(Code_H) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo2.Text = rs("MaxMaim").Value + 1


        Else
            Com_InvoiceNo2.Text = 1



        End If
    End Sub
    Sub find_detalis()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = " SELECT        dbo.TB_MachineName.Name, dbo.TB_HalekData.Qty_H, dbo.BD_Unit.Name AS Unit, dbo.BD_Stores.Name AS Stores, dbo.TB_Shift.Name_Shift, dbo.TB_HalekData.Notes " & _
 " FROM            dbo.TB_HalekData INNER JOIN " & _
 "                         dbo.TB_MachineName ON dbo.TB_HalekData.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_HalekData.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN " & _
 "                         dbo.BD_Unit ON dbo.TB_HalekData.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_HalekData.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
 "                         dbo.TB_Shift ON dbo.TB_HalekData.Shift_No = dbo.TB_Shift.Code_Shift LEFT OUTER JOIN " & _
 "                         dbo.BD_Stores ON dbo.TB_HalekData.Compny_Code = dbo.BD_Stores.Compny_Code AND dbo.TB_HalekData.Code_Stores = dbo.BD_Stores.Code " & _
 " WHERE        (dbo.TB_HalekData.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_HalekData.Code_H = '" & Com_InvoiceNo2.Text & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)



        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "الماكينة"
        GridView3.Columns(1).Caption = " الكمية"
        GridView3.Columns(2).Caption = "الوحدة"
        GridView3.Columns(3).Caption = "المخزن"
        GridView3.Columns(4).Caption = "الوردية"
        GridView3.Columns(5).Caption = "ملاحظات"



        GridView3.BestFitColumns()



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

    Sub Search()
        'On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "      SELECT        dbo.TB_HalekData.Code_H, dbo.TB_HalekData.Date_Halek, dbo.TB_MachineName.Name, dbo.TB_HalekData.Qty_H, dbo.BD_Unit.Name AS Unit, dbo.BD_Stores.Name AS Expr2, dbo.TB_Shift.Name_Shift,  " & _
                "                         dbo.TB_HalekData.Notes  " & _
                " FROM            dbo.TB_HalekData INNER JOIN  " & _
                "                         dbo.TB_MachineName ON dbo.TB_HalekData.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_HalekData.Compny_Code = dbo.TB_MachineName.Compny_Code INNER JOIN  " & _
                "                         dbo.BD_Unit ON dbo.TB_HalekData.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_HalekData.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN  " & _
                "                         dbo.TB_Shift ON dbo.TB_HalekData.Shift_No = dbo.TB_Shift.Code_Shift LEFT OUTER JOIN  " & _
                "                         dbo.BD_Stores ON dbo.TB_HalekData.Compny_Code = dbo.BD_Stores.Compny_Code AND dbo.TB_HalekData.Code_Stores = dbo.BD_Stores.Code  " & _
                " WHERE        (dbo.TB_HalekData.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = " التاريخ"
        GridView1.Columns(2).Caption = "الماكينة"
        GridView1.Columns(3).Caption = " الكمية"
        GridView1.Columns(4).Caption = "الوحدة"
        GridView1.Columns(5).Caption = "المخزن"
        GridView1.Columns(6).Caption = "الوردية"
        GridView1.Columns(7).Caption = "ملاحظات"

        GridView1.BestFitColumns()


        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub
    Sub save_itemStores()
        Dim varcodunit, varcodunit2, varcodStores, varcode_Item As Integer
        Dim dd As DateTime = txt_date.Value
        Dim vardateinvoice As String
        vardateinvoice = dd.ToString("MM-d-yyyy")
        '======================================================تحديد رقم الوحدة
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & txt_unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("code").Value
        '===================================================================رقم المخزن
        sql = "   SELECT *    FROM BD_Stores   WHERE(Name = '" & Com_StoresNo.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodStores = rs("Code").Value
        '=================================================
        '============================Item






        sql = "insert into Statement_OfItem  (NumberBill,Co_ID,NumYear" & _
            " ,NoItem,Code_Unit,Code_Stores,TypeD,DateMoveM,Dis,Export,Code_Sub,Compny_Code,Order_AddStores_NO,Count_exp,Count_imp,Code_Unit2) " & _
            " values ('" & Com_InvoiceNo2.Text & "','" & 1 & "','" & 1 & " ' " & _
            " ,'" & varcode_Item & " ', '" & varcodunit & "','" & varcodStores & "','" & 20 & "' " & _
            " ,'" & vardateinvoice & "','" & "أذن اضافة الى مخزن الهالك" + Com_InvoiceNo2.Text & "','" & txt_QytItem.Text & "','" & 1 & "','" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & txt_QytItem.Text & "','" & 0 & "','" & varcodunit2 & "') "
        Cnn.Execute(sql)

    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        If Len(varJopOrder) = 0 Then MsgBox("من  فضلك أختار الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Frm_ProudactionOrder.Com_InvoiceNo2.Text = varJopOrder

        Frm_ProudactionOrder.find_hedar()
        Frm_ProudactionOrder.find_detalis()
        Frm_ProudactionOrder.MdiParent = Mainmune
        Frm_ProudactionOrder.Show()
    End Sub

   

    Private Sub Com_StoresNo_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "BD_Stores"
        VarOpenlookup = 61
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_StoresNo_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GridView3.ShowPrintPreview()
    End Sub

  


    Private Sub txt_MachinName_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachinName.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 633
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

   

   
   

    Private Sub Cmd_DeleteLine_Click(sender As Object, e As EventArgs)
        
    End Sub

   

   
    Private Sub Com_StoresNo_ButtonClick2(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_StoresNo.ButtonClick
        vartable = "BD_Stores"
        VarOpenlookup = 610
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_StoresNo_EditValueChanged_1(sender As Object, e As EventArgs) Handles Com_StoresNo.EditValueChanged

    End Sub

   
   

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        clear_detils()
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        txt_MachinName.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        txt_QytItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        txt_unit.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
        Com_StoresNo.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        txt_notes.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        com_Shift.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Com_InvoiceNo2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        clear_detils()
        find_hedar()
        find_detalis()
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاذن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MachinName.Text) = 0 Then MsgBox("من  فضلك ادخل أسم الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_QytItem.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unit.Text) = 0 Then MsgBox("من  فضلك ادخل  الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_StoresNo.Text) = 0 Then MsgBox("من  فضلك ادخل أسم المخزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Shift.Text) = 0 Then MsgBox("من  فضلك ادخل أسم الوردية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        sql2 = "select * from TB_HalekData where Code_H  = '" & Trim(Com_InvoiceNo2.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo2.Text) = 0 Then MsgBox("من فضلك ادخل رقم اذن الاضافة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        save_Order_H()



        clear_detils()
        find_detalis()
        Search()

        GridView3.BestFitColumns()
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        find_hedar()
        find_detalis()
        clear_detils()

        GridView3.BestFitColumns()
    End Sub

    Private Sub Cmd_DeleteLine_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeleteLine.Click
        On Error Resume Next

        '====================================================
        sql = "    SELECT        *         FROM dbo.TB_MachineName WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Name = '" & txt_MachinName.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then varmachinNo = rs2("Code").Value


        Dim x As String
        x = MsgBox("هل تريد حذف السطر", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_HalekData  WHERE Code_H = '" & Com_InvoiceNo2.Text & "' and Machine_No ='" & varmachinNo & "' and Compny_Code ='" & VarCodeCompny & "'  "
                rs = Cnn.Execute(sql)


                find_detalis()
                clear_detils()
                Search()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

                GridView3.BestFitColumns()
        End Select
    End Sub

    Private Sub Cmd_DeletFinsh_Click_1(sender As Object, e As EventArgs) Handles Cmd_DeletFinsh.Click
        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_HalekData  WHERE  Code_H ='" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)




                find_hedar()
                find_detalis()
                Search()

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

                GridView3.BestFitColumns()
        End Select
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub com_Shift_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_Shift.ButtonClick
        vartable = "vw_Shift"
        VarOpenlookup = 640
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub com_Shift_EditValueChanged(sender As Object, e As EventArgs) Handles com_Shift.EditValueChanged

    End Sub
End Class