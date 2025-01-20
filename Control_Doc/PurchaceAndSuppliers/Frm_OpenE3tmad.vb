Imports System.Data.OleDb

Public Class Frm_OpenE3tmad
    Dim varcodesuppliser, varcodePayment, varcodeShipping, varcodeShipping_Type, varcode_typeEtmad As Integer
    Dim varAccountBankEtmad As String
    Dim oldDate As Date
    Dim oldDay As Integer
    Sub last_Data()

        sql = "  SELECT        MAX(Code_Etmad) AS MaxMaim,Compny_Code FROM            TB_Documentary_Credit    GROUP BY Compny_Code  HAVING        (MAX(Code_Etmad) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txtCode.Text = rs("MaxMaim").Value + 1

        Else
            txtCode.Text = 1



        End If
    End Sub
    Sub clear()
        txt_No_Manual.Text = ""
        txt_NameSuppliser.Text = ""
        txt_BankSupplisser.Text = ""
        txt_ValueEtmad.Text = ""
        txt_BankEtmad.Text = ""
        Com_Cru.Text = ""
        txt_notes.Text = ""
        txt_NGH.Text = ""
        txt_ValueGh.Text = ""
        txt_rat.Text = ""
        Com_TypeEtmad.Text = ""
    End Sub
    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click

        Cmd_save.Enabled = True
        Cmd_Delete.Enabled = False
        Cmd_Edit.Enabled = False
        'clear_detils()
        'find_hedar()
        'find_detalis()
        clear()
        last_Data()
        varcode_etmad = txtCode.Text
        Cmd_OrderPO.Enabled = False
        Find_Detils_PO_Etmad()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        sql2 = "select * from TB_Documentary_Credit where Code_Etmad  = '" & Trim(txtCode.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(txtCode.Text) = 0 Then MsgBox("من فضلك ادخل رقم الاعتماد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_DateStr.Text) = 0 Then MsgBox("من فضلك ادخل نوع تاريخ الاعتماد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_DateEnd.Text) = 0 Then MsgBox("من فضلك ادخل  تاريخ نهاية الاعتماد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_dateArriver.Text) = 0 Then MsgBox("من  فضلك ادخل تاريخ الوصول للشحنة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_BankSupplisser.Text) = 0 Then MsgBox("من  فضلك ادخل بنك المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_BankEtmad.Text) = 0 Then MsgBox("من  فضلك ادخل بنك الاعتماد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_NameSuppliser.Text) = 0 Then MsgBox("من  فضلك أختار أسم المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_ValueEtmad.Text) = 0 Then MsgBox("من  فضلك ادخل قيم الاعتماد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()
    End Sub
    Sub save_Order_H()
        'On Error Resume Next
        '===================================================تاريخ الاعتماد
        Dim dd As DateTime = txt_DateStr.Value
        Dim vardateEtmad As String
        vardateEtmad = dd.ToString("MM-d-yyyy")
        '===================================================تاريخ نهاية
        Dim dd2 As DateTime = txt_DateEnd.Value
        Dim vardateEtmad2 As String
        vardateEtmad2 = dd2.ToString("MM-d-yyyy")
        '===================================================تاريخ وصول الشحنة
        Dim dd3 As DateTime = txt_dateArriver.Value
        Dim vardateEtmad3 As String
        vardateEtmad3 = dd3.ToString("MM-d-yyyy")

        '=============================================رقم المورد
       

        sql = "   Select Supliser_Code       FROM dbo.St_SuppliserData WHERE        (Compny_Code ='" & VarCodeCompny & "') AND (Supliser_Name = '" & txt_NameSuppliser.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodesuppliser = rs("Supliser_Code").Value
        '========================================================================================= حساب بنك الاعتماد
        sql = "SELECT        Account_No, RTRIM(AccountName) AS NameSuppliser, Compny_Code       FROM dbo.ST_CHARTOFACCOUNT WHERE        (RTRIM(AccountName) ='" & txt_BankEtmad.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varAccountBankEtmad = rs("Account_No").Value
        '============================================================================
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=================================================================== طريقة السداد

        If Op1.Checked = True Then varcodePayment = 0
        If Op2.Checked = True Then varcodePayment = 1

        '===========================================================سياسة الشحن

        If Op3.Checked = True Then varcodeShipping = 0
        If Op4.Checked = True Then varcodeShipping = 1
        If Op5.Checked = True Then varcodeShipping = 2
        If Op6.Checked = True Then varcodeShipping = 3

        '===============================================================نوع الشحن
        If Op7.Checked = True Then varcodeShipping_Type = 0
        If Op8.Checked = True Then varcodeShipping_Type = 1
        '============================================================= hنوع الاعتماد 

        sql = "  SELECT *    FROM TB_TypeEtmad where   Name ='" & Com_TypeEtmad.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_typeEtmad = rs("code").Value
        '=============================================================================


        sql = "INSERT INTO TB_Documentary_Credit (Code_Etmad, StrDate_Etmad,Status_Etmad,EndDate_Etmad,NoDftr_Etmad,AccountNo_Suppliser,AccountNoBank_Suppliser,Value_Etmad,AccountNoBank_Etmad,CodeCru_Etmad,Type_Payment,Flag_Shiping,Falg_Type_Shiping,Date_Ariver,N_Ghta,Value_Ghta,Rat,Code_Type_Etmad,Notes,Compny_Code) " & _
                  " values  (N'" & txtCode.Text & "' ,N'" & vardateEtmad & "',N'" & 0 & "',N'" & vardateEtmad2 & "',N'" & txt_No_Manual.Text & "',N'" & varcodesuppliser & "',N'" & txt_BankSupplisser.Text & "',N'" & txt_ValueEtmad.Text & "',N'" & varAccountBankEtmad & "',N'" & varcode_Cru & "',N'" & varcodePayment & "',N'" & varcodeShipping & "',N'" & varcodeShipping_Type & "',N'" & vardateEtmad3 & "',N'" & txt_NGH.Text & "',N'" & txt_ValueGh.Text & "',N'" & txt_rat.Text & "',N'" & varcode_typeEtmad & "',N'" & txt_notes.Text & "',N'" & VarCodeCompny & "')"
        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")






    End Sub

    Private Sub Frm_OpenE3tmad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_EtmadType()
        fill_cru()
        Find_all()
        'Vw_EatmadData
    End Sub

    Sub Find_Detils_PO_Etmad()
        On Error Resume Next


        GridControl3.DataSource = Nothing
        GridView5.Columns.Clear()

        sql2 = " select * from  Vw_ALL_PO2 where Compny_Code ='" & VarCodeCompny & "'  and (dbo.Vw_ALL_PO2.Code_Etmad ='" & varcode_etmad & "') "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView5.Columns(0).Caption = "رقم أمر الشراء"
        GridView5.Columns(1).Caption = "التاريخ "
        GridView5.Columns(2).Caption = "نوع أمر الشراء"
        GridView5.Columns(3).Caption = "أسم المورد"
        GridView5.Columns(4).Caption = "رقم الصنف"
        GridView5.Columns(5).Caption = "أسم الصنف"
        GridView5.Columns(6).Caption = "الوحدة"
        GridView5.Columns(7).Caption = "الكمية"
        GridView5.Columns(8).Caption = "سعر الوحدة"
        GridView5.Columns(9).Caption = "العملة"
        GridView5.Columns(10).Caption = "معامل التحويل"
        GridView5.Columns(11).Caption = "الاجمالى"


        GridView5.Columns(12).Visible = False
        GridView5.Columns(13).Visible = False
        GridView5.Columns(14).Visible = False



        GridView5.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True
        GridView5.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView5.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub
    Sub fill_EtmadType()
        Com_TypeEtmad.Items.Clear()
        sql = " SELECT     Name  from TB_TypeEtmad where Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_TypeEtmad.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub txt_BankEtmad_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_BankEtmad.ButtonClick
        VARTBNAME = "vw_AccountData"
        varcode_form = 301
        Frm_LookUpAccount.Fill_Acc()
        Frm_LookUpAccount.ShowDialog()
    End Sub

    Private Sub txt_BankEtmad_EditValueChanged(sender As Object, e As EventArgs) Handles txt_BankEtmad.EditValueChanged

    End Sub
    Sub Find_all()
        On Error Resume Next


        sql = " select * from  Vw_EatmadData where Compny_Code ='" & VarCodeCompny & "' "

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
        GridView1.Columns(0).Caption = "رقم الاعتماد"
        GridView1.Columns(1).Caption = "الرقم الدفترى"
        GridView1.Columns(2).Caption = "تاريخ الاعتماد"
        GridView1.Columns(3).Caption = "تاريخ نهاية الاعتماد"
        GridView1.Columns(4).Caption = "تاريخ الوصول"
        GridView1.Columns(5).Caption = "المورد"
        GridView1.Columns(6).Caption = "بنك المورد"
        GridView1.Columns(7).Caption = "قيمة الاعتماد"
        GridView1.Columns(8).Caption = "بنك الاعتماد"
        GridView1.Columns(9).Caption = "العملة"
        GridView1.Columns(10).Caption = "نوع السداد"
        GridView1.Columns(11).Caption = "سياسة الشحن"
        GridView1.Columns(12).Caption = "نوع الشحن"
        GridView1.Columns(13).Caption = "نسبة الغطاء"
        GridView1.Columns(14).Caption = "قيمة الغطاء"
        GridView1.Columns(15).Caption = "نوع الاعتماد"
        GridView1.Columns(16).Caption = "معامل التحويل"
        GridView1.Columns(17).Caption = "ملاحظات"
        GridView1.Columns(18).Visible = False
        GridView1.Columns(19).Visible = False
        GridView1.Columns(20).Visible = False
        GridView1.Columns(21).Visible = False




        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub
    Private Sub txt_NameSuppliser_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameSuppliser.ButtonClick
        vartable = "Find_Suppliser"
        VarOpenlookup = 120
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_NameSuppliser_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameSuppliser.EditValueChanged

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))

        varcode_etmad = value



        clear()


        sql = " select * from  Vw_EatmadData where Compny_Code ='" & VarCodeCompny & "' and Code_Etmad ='" & value & "' "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            txtCode.Text = rs2("Code_Etmad").Value
            txt_No_Manual.Text = rs2("NoDftr_Etmad").Value
            txt_DateStr.Value = rs2("StrDate_Etmad").Value
            txt_DateEnd.Value = rs2("EndDate_Etmad").Value
            txt_dateArriver.Value = rs2("Date_Ariver").Value

            txt_NameSuppliser.Text = rs2("NameSuppliser").Value
            txt_BankSupplisser.Text = rs2("AccountNoBank_Suppliser").Value
            txt_ValueEtmad.Text = rs2("Value_Etmad").Value
            txt_BankEtmad.Text = rs2("AccountName").Value
            Com_Cru.Text = rs2("Name").Value
            txt_notes.Text = rs2("Notes").Value
            txt_NGH.Text = rs2("N_Ghta").Value
            txt_ValueGh.Text = rs2("Value_Ghta").Value
            txt_rat.Text = rs2("Rat").Value
            Com_TypeEtmad.Text = rs2("TypeEtmad").Value

            '=====================================================
            If rs2("Type_Payment2").Value = 0 Then Op1.Checked = True Else Op2.Checked = True
            '====================================================================
            If rs2("Flag_Shiping2").Value = 0 Then Op3.Checked = True
            If rs2("Flag_Shiping2").Value = 1 Then Op4.Checked = True
            If rs2("Flag_Shiping2").Value = 2 Then Op5.Checked = True
            If rs2("Flag_Shiping2").Value = 3 Then Op6.Checked = True
            '======================================================================
            If rs2("Falg_Type_Shiping2").Value = 0 Then Op7.Checked = True
            If rs2("Falg_Type_Shiping2").Value = 1 Then Op8.Checked = True

            '=====================================================





            Cmd_OrderPO.Enabled = True
            Cmd_save.Enabled = False
            Cmd_Edit.Enabled = True
            Cmd_Delete.Enabled = True
        End If
        TabPane1.SelectedPageIndex = 0
        Find_Detils_PO_Etmad()

    End Sub

    Private Sub Cmd_OrderPO_Click(sender As Object, e As EventArgs) Handles Cmd_OrderPO.Click
        varcode_etmad = txtCode.Text
        Frm_Lookup_Add_PO_Etmad.txt_No_Etmad2.Text = txtCode.Text
        Frm_Lookup_Add_PO_Etmad.Close()
        Frm_Lookup_Add_PO_Etmad.MdiParent = Mainmune
        Frm_Lookup_Add_PO_Etmad.Show()
    End Sub

    
    Private Sub Com_Cru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Cru.SelectedIndexChanged
        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & Com_Cru.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================
        Dim vardate As String

        '=======================================Date 1
        oldDate = txt_DateStr.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_DateStr.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay

        '================================================Rat
        sql = "    SELECT        Code_Cur, Date_Cru, Rat_cru      FROM dbo.TB_Cru_Day WHERE        (Code_Cur = '" & varcode_Cru & "') AND (Date_Cru = CONVERT(DATETIME, '" & vardate & "', 102))  and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_rat.Text = rs("Rat_cru").Value Else txt_rat.Text = "0"
    End Sub

    Private Sub Cmd_Edit_Click(sender As Object, e As EventArgs) Handles Cmd_Edit.Click

    End Sub
End Class