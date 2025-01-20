Imports System.Data.OleDb

Public Class Frm_ShippingData

    Private Sub Frm_ShippingData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_all()
    End Sub

    Sub Find_all()
        On Error Resume Next


        sql = " select Code_Etmad,NoDftr_Etmad,StrDate_Etmad,EndDate_Etmad,Date_Ariver,NameSuppliser,AccountNoBank_Suppliser,AccountName,NoShipping,NotesShipping from  Vw_EatmadData where Compny_Code ='" & VarCodeCompny & "' "

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
        GridView5.Columns(0).Caption = "رقم الاعتماد"
        GridView5.Columns(1).Caption = "الرقم الدفترى"
        GridView5.Columns(2).Caption = "تاريخ الاعتماد"
        GridView5.Columns(3).Caption = "تاريخ نهاية الاعتماد"
        GridView5.Columns(4).Caption = "تاريخ الوصول"
        GridView5.Columns(5).Caption = "المورد"
        GridView5.Columns(6).Caption = "بنك المورد"
        GridView5.Columns(7).Caption = "بنك الاعتماد"

        GridView5.Columns(8).Caption = "رقم الشحنة"
        GridView5.Columns(9).Caption = "ملاحظات"

        GridView5.Columns(8).AppearanceCell.BackColor = Color.DarkGray
        GridView5.Columns(8).AppearanceCell.ForeColor = Color.Red

        GridView5.Columns(9).AppearanceCell.BackColor = Color.DarkGray
        GridView5.Columns(9).AppearanceCell.ForeColor = Color.Red

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True
        GridView5.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView5.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub
    Sub clear()
        txt_No_Manual.Text = ""
        txt_NameSuppliser.Text = ""
        txt_BankSupplisser.Text = ""
        txt_BankEtmad.Text = ""
        txt_notes.Text = ""
    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        Dim value = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))

        varcode_etmad = value



        clear()


        sql = " select * from  Vw_EatmadData where Compny_Code ='" & VarCodeCompny & "' and Code_Etmad ='" & value & "' "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            txtCode.Text = rs2("Code_Etmad").Value
            txt_No_Manual.Text = rs2("NoDftr_Etmad").Value
            txt_DateStr.Text = rs2("StrDate_Etmad").Value
            txt_DateEnd.Text = rs2("EndDate_Etmad").Value
            txt_dateArriver.Text = rs2("Date_Ariver").Value
            txt_NameSuppliser.Text = rs2("NameSuppliser").Value
            txt_BankSupplisser.Text = rs2("AccountNoBank_Suppliser").Value
            txt_BankEtmad.Text = rs2("AccountName").Value
            txt_notes.Text = rs2("Notes").Value

            '=====================================================
            txt_NoShipping.Text = rs2("NoShipping").Value
            txt_notes.Text = rs2("NotesShipping").Value
            '====================================================================
            If rs2("Flag_Shiping2").Value = 0 Then Op3.Checked = True
            If rs2("Flag_Shiping2").Value = 1 Then Op4.Checked = True
            If rs2("Flag_Shiping2").Value = 2 Then Op5.Checked = True
            If rs2("Flag_Shiping2").Value = 3 Then Op6.Checked = True
            '======================================================================
            If rs2("Falg_Type_Shiping2").Value = 0 Then Op7.Checked = True
            If rs2("Falg_Type_Shiping2").Value = 1 Then Op8.Checked = True

            '=====================================================

            Cmd_save.Enabled = True
            If txtCode.Text <> "" Then cmd_Expensess.Enabled = True
        End If

    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        clear()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql = "UPDATE  TB_Documentary_Credit  SET NoShipping ='" & txt_NoShipping.Text & "',NotesShipping ='" & txt_notes.Text & "'  WHERE   Code_Etmad ='" & txtCode.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)




        MsgBox("تم الحفظ", MsgBoxStyle.Information, "Css Solution Software Module")
        Find_all()
    End Sub

    Private Sub cmd_Expensess_Click(sender As Object, e As EventArgs) Handles cmd_Expensess.Click
        'Frm_ExpensessShapping.Show()
        Frm_ExpensessShapping.Close()
        Frm_ExpensessShapping.MdiParent = Mainmune
        Frm_ExpensessShapping.Show()
    End Sub
End Class