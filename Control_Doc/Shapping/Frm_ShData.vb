Imports System.Data.OleDb
Imports ADODB

Public Class Frm_ShData

    Private Sub Frm_ShData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_DervilyTerms.Items.Add("CIF")
        Com_DervilyTerms.Items.Add("EX-Work")
        Com_DervilyTerms.Items.Add("FOB")
        Com_DervilyTerms.Items.Add("CFR")
        Com_DervilyTerms.Items.Add("FAS")
        Com_DervilyTerms.Items.Add("FCA")
        fill_bank()
        'vw_ShappingData
        Find_all_Data()
        GridView1.BestFitColumns()
    End Sub
    Sub Find_all_Data()
        On Error Resume Next


        sql = " select * FROM dbo.vw_ShappingData where Compny_Code ='" & VarCodeCompny & "' "


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
        GridView1.Columns(0).Caption = "رقم البوليصة"
        GridView1.Columns(1).Caption = "تاريخ البوليصة"
        GridView1.Columns(2).Caption = "اسم المورد"
        GridView1.Columns(3).Caption = "اسم البنك"
        GridView1.Columns(4).Caption = "قيمة الشحنه"
        GridView1.Columns(5).Caption = "ميناء المغادرة"
        GridView1.Columns(6).Caption = "ميناء الوصول"
        GridView1.Columns(7).Caption = "تاريخ المغادرة"
        GridView1.Columns(8).Caption = "تاريخ الوصول"
        GridView1.Columns(9).Caption = "Free Time"
        GridView1.Columns(10).Caption = "امر الشراء PO"
        GridView1.Columns(11).Caption = "طريقة الدفع"
        GridView1.Columns(12).Caption = "طريقة التسليم"
        GridView1.Columns(13).Caption = "المبلغ المدفوع"
        GridView1.Columns(14).Caption = "المبلغ المستحق"

        GridView1.Columns(15).Caption = "بلد المنشأ"
        GridView1.Columns(16).Caption = "شركة الشحن"
        GridView1.Columns(17).Caption = "قيمة الشحن"
        GridView1.Columns(18).Caption = "المدفوع"
        GridView1.Columns(19).Caption = "المستحق"
        GridView1.Columns(20).Caption = "رقم الشهادة"

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
    Sub fill_bank()
        Com_BankName.Items.Clear()
        sql = "select rtrim(AccountName) as AccountName from TB_BankDetils  where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_BankName.Items.Add(rs("AccountName").Value)
            rs.MoveNext()
        Loop
    End Sub


    Private Sub Com_SuppliserName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_SuppliserName.ButtonClick
        'Vw_SupliserCur()

        'vartable = "Vw_SupliserCur"
        'VarOpenlookup = 12021
        ''Frm_Lookup.MdiParent = Me
        'Frm_Lookup.Text = "بحث"
        'Frm_Lookup.ShowDialog()
    End Sub
    Sub find_curSupliser()
        sql = "    SELECT Name, Compny_Code, Code       FROM dbo.Vw_SupliserCur       WHERE(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then TXt_CurName.Text = rs("Code").Value
    End Sub
    Private Sub Com_SuppliserName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_SuppliserName.EditValueChanged

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'Frm_BankDetils.MdiParent = Mainmune
        Frm_BankDetils.ShowDialog()
    End Sub

    Private Sub Com_BankName_GotFocus(sender As Object, e As EventArgs) Handles Com_BankName.GotFocus
        fill_bank()
    End Sub


    Private Sub Com_NameShipping_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_NameShipping.ButtonClick
        vartable = "TB_ShippingCompny"
        VarOpenlookup = 12022
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        vartable = "TB_ShippingCompny"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Mainmune
        Frm_GenralData.Text = "شركات الشحن"
        Frm_GenralData.Show()
    End Sub



    Private Sub Com_CountryOfOrigin_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_CountryOfOrigin.ButtonClick
        vartable = "BD_CITIES"
        VarOpenlookup = 12023
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Frm_LookupPO.MdiParent = Mainmune
        Frm_LookupPO.Show()
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        vartable = "BD_CITIES"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Mainmune
        Frm_GenralData.Text = "أكواد البلد"
        Frm_GenralData.Show()
    End Sub


    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(Com_NoPolicsa.Text) = 0 Then MsgBox("من فضلك ادخل رقم البوليصة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_date.Text) = 0 Then MsgBox("من فضلك ادخل تاريخ البوليصة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(TXt_PONO.Text) = 0 Then MsgBox("من فضلك اختار رقم امر الشراء PO ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_SuppliserName.Text) = 0 Then MsgBox("من فضلك ادخل  المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_BankName.Text) = 0 Then MsgBox("من فضلك اختار حساب البنك ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_ValueSh.Text) = 0 Then MsgBox("من فضلك ادخل قيمة الشحن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MenaDeprt.Text) = 0 Then MsgBox("من فضلك ادخل ميناء الوصول ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MenaAriver.Text) = 0 Then MsgBox("من فضلك ادخل ميناء المغادرة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MethodTerms.Text) = 0 Then MsgBox("من فضلك ادخل طريقة الدفع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Date_Dep.Value) = 0 Then MsgBox("من فضلك ادخل تاريخ المغادرة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Date_Ariv.Value) = 0 Then MsgBox("من فضلك ادخل تاريخ الوصول ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_FreeTime.Text) = 0 Then MsgBox("من فضلك ادخل عدد ايام  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        If Date_Dep.Value > Date_Ariv.Value Then MsgBox("تاريخ المغادرة اكبر من تاريخ الوصول", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '============================================تاريخ الميلاد
        Dim dd As DateTime = txt_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================تاريخ الالتحاق
        Dim dd2 As DateTime = Date_Dep.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================تاريخ الاستقالة
        Dim dd3 As DateTime = Date_Ariv.Value
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")

        '=================================المورد
        sql = " SELECT Supliser_Name, Supliser_Code, Compny_Code       FROM dbo.St_SuppliserData " & _
            " WHERE  (Supliser_Name = '" & Com_SuppliserName.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodeSupliser = rs3("Supliser_Code").Value
        '============================================================ city
        sql = "SELECT *  FROM BD_CITIES where Name ='" & Com_CountryOfOrigin.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodecity = rs3("code").Value
        '==============================================================================Shapping
        sql = "SELECT *  FROM TB_ShippingCompny where Name ='" & Com_NameShipping.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodeshippingCo = rs3("code").Value


        sql = "INSERT INTO TB_ShappingData (Policynumber, PolicyDate,Code_Supplier,AccountBankName,Shipping_value,Departure_port,Arrival_Port,Arrival_Date,Departure_Date,FreeTime,PO_NO,Payment_method,terms_of_delivery,amount_paid,deserved_amount,code_City,Code_ShipaingCO,Shippingvalue,Paid_UP,Due,Compny_Code,No_Certifect) " & _
            " values  (N'" & Com_NoPolicsa.Text & "' ,N'" & vardate1 & "',N'" & varcodeSupliser & "',N'" & Com_BankName.Text & "',N'" & txt_ValueSh.Text & "',N'" & txt_MenaDeprt.Text & "'  " & _
            " ,N'" & txt_MenaAriver.Text & "',N'" & vardate2 & "',N'" & vardate3 & "',N'" & txt_FreeTime.Text & "',N'" & TXt_PONO.Text & "',N'" & txt_MethodTerms.Text & "',N'" & Com_DervilyTerms.Text & "',N'" & txt_Paid1.Text & "',N'" & txt_ManyMsthk.Text & "','" & varcodecity & "',N'" & varcodeshippingCo & "',N'" & txt_ValueShip.Text & "',N'" & txt_Paid2.Text & "',N'" & txt_MshkValue.Text & "',N'" & VarCodeCompny & "',N'" & txt_NoCerti.Text & "')"
        Cnn.Execute(sql)




        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_all_Data()
        ''Find()
        'Find_all_EMP()
        'last_Data()
        'clear()

    End Sub

    Private Sub GridControl1_DockChanged(sender As Object, e As EventArgs) Handles GridControl1.DockChanged

    End Sub



    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        'clear()
        sql = " select * From vw_ShappingData where Policynumber = '" & value2 & "' and Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_NoPolicsa.Text = rs("Policynumber").Value
            txt_date.Text = rs("PolicyDate").Value
            Com_SuppliserName.Text = rs("Supliser_Name").Value
            Com_BankName.Text = rs("AccountBankName").Value
            txt_ValueSh.Text = rs("Shipping_value").Value
            txt_ValueSH2.Text = rs("Shipping_value").Value
            txt_MenaDeprt.Text = rs("Departure_port").Value
            txt_MenaAriver.Text = rs("Arrival_Port").Value
            Date_Ariv.Text = rs("Arrival_Date").Value
            Date_Dep.Text = rs("Departure_Date").Value
            txt_FreeTime.Text = rs("FreeTime").Value
            TXt_PONO.Text = rs("PO_NO").Value
            txt_MethodTerms.Text = rs("Payment_method").Value
            Com_DervilyTerms.Text = rs("terms_of_delivery").Value
            txt_Paid1.Text = rs("amount_paid").Value
            txt_ManyMsthk.Text = rs("deserved_amount").Value
            Com_CountryOfOrigin.Text = rs("Name").Value
            Com_NameShipping.Text = rs("ShappingName").Value
            txt_ValueShip.Text = rs("Shippingvalue").Value
            txt_Paid2.Text = rs("Paid_UP").Value
            txt_MshkValue.Text = rs("DUe").Value
            txt_NoCerti.Text = Trim(rs("No_Certifect").Value)
            txt_Nocerti2.Text = Trim(rs("No_Certifect").Value)
        End If
        TabPane1.SelectedPageIndex = 0
        Cmd_Save.Enabled = False
        SimpleButton5.Enabled = True
        SimpleButton8.Enabled = True

        'sum_TaxTogary()
        'sum_TaxSal()
        'Sum_colume_Cost()
        'Sum_colume_All()
        find_data_ExPensses()
        find_data_Cost_Prcheses()
        sum_TaxTogary()
        sum_TaxSal()
        Sum_colume_All()
        Sum_colume_Cost()


        find_data_ExPensses()
        find_data_Cost_Prcheses()
        sum_TaxTogary()
        sum_TaxSal()

        Sum_colume_All()
        Sum_colume_Cost()
        Sum_colume_All()
        'find_data_ExPensses()
        'find_data_Cost_Prcheses()
        'sum_TaxTogary()
        'sum_TaxSal()
        'Sum_colume_All()
        'Sum_colume_Cost()
        'find_data_ExPensses2()
    End Sub

    Sub sum_TaxTogary()
        sql = "  SELECT dbo.TB_Expensess_SH.Account_No, dbo.TB_Expensess_SH.Value_cash " & _
          " FROM     dbo.TB_Expensess_SH INNER JOIN " & _
          "                  dbo.Tb_TaxInvoice ON dbo.TB_Expensess_SH.Account_No = dbo.Tb_TaxInvoice.Account_Tax2 " & _
          " WHERE  (dbo.TB_Expensess_SH.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Expensess_SH.No_Certifect = '" & txt_NoCerti.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_TotalTaxTogary.Text = rs("Value_cash").Value Else txt_TotalTaxTogary.Text = "0"

    End Sub

    Sub sum_TaxSal()
        sql = "  SELECT dbo.TB_Expensess_SH.Account_No, dbo.TB_Expensess_SH.Value_cash " & _
          " FROM     dbo.TB_Expensess_SH INNER JOIN " & _
          "                  dbo.Tb_TaxInvoice ON dbo.TB_Expensess_SH.Account_No = dbo.Tb_TaxInvoice.Account_Tax " & _
          " WHERE  (dbo.TB_Expensess_SH.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Expensess_SH.No_Certifect = '" & txt_NoCerti.Text & "') "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Total_TaxSal.Text = rs("Value_cash").Value Else txt_Total_TaxSal.Text = "0"

    End Sub
    Private Sub txt_MenaDeprt_TextChanged(sender As Object, e As EventArgs) Handles txt_MenaDeprt.TextChanged
        On Error Resume Next
        txt_ManyMsthk.Text = Val(txt_ValueSh.Text) - Val(txt_Paid1.Text)
    End Sub

    Private Sub txt_Paid1_TextChanged(sender As Object, e As EventArgs) Handles txt_Paid1.TextChanged
        On Error Resume Next
        txt_ManyMsthk.Text = Val(txt_ValueSh.Text) - Val(txt_Paid1.Text)

    End Sub

    Private Sub txt_ValueShip_TextChanged(sender As Object, e As EventArgs) Handles txt_ValueShip.TextChanged
        On Error Resume Next
        txt_MshkValue.Text = Val(txt_ValueShip.Text) - Val(txt_Paid2.Text)

    End Sub

    Private Sub txt_Paid2_TextChanged(sender As Object, e As EventArgs) Handles txt_Paid2.TextChanged
        On Error Resume Next
        txt_MshkValue.Text = Val(txt_ValueShip.Text) - Val(txt_Paid2.Text)
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Frm_suppliersInfo.MdiParent = Mainmune
        Frm_suppliersInfo.Show()
    End Sub

    Private Sub Date_Ariv_ValueChanged(sender As Object, e As EventArgs) Handles Date_Ariv.ValueChanged
        Dim days As Long = DateDiff(DateInterval.Day, Date_Dep.Value, Date_Ariv.Value)
        txt_FreeTime.Text = days
    End Sub

    Private Sub Date_Dep_ValueChanged(sender As Object, e As EventArgs) Handles Date_Dep.ValueChanged
        Dim days As Long = DateDiff(DateInterval.Day, Date_Dep.Value, Date_Ariv.Value)
        txt_FreeTime.Text = days
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        clear()
    End Sub
    Sub clear()
        Com_NoPolicsa.Text = ""
        txt_date.Text = ""
        Com_SuppliserName.Text = ""
        Com_BankName.Text = ""
        txt_ValueSh.Text = ""
        txt_MenaDeprt.Text = ""
        txt_MenaAriver.Text = ""
        Date_Ariv.Text = ""
        Date_Dep.Text = ""
        txt_FreeTime.Text = ""
        TXt_PONO.Text = ""
        txt_MethodTerms.Text = ""
        Com_DervilyTerms.Text = ""
        txt_Paid1.Text = ""
        txt_ManyMsthk.Text = ""
        Com_CountryOfOrigin.Text = ""
        Com_NameShipping.Text = ""
        txt_ValueShip.Text = ""
        txt_Paid2.Text = ""
        txt_MshkValue.Text = ""
        txt_NoCerti.Text = ""
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete TB_ShappingData  WHERE Policynumber = " & Com_NoPolicsa.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")

                clear()
                'Find()
                'Fill_Data()

                Find_all_Data()

        End Select
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If Len(Com_NoPolicsa.Text) = 0 Then MsgBox("من فضلك ادخل رقم البوليصة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_date.Text) = 0 Then MsgBox("من فضلك ادخل تاريخ البوليصة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(TXt_PONO.Text) = 0 Then MsgBox("من فضلك اختار رقم امر الشراء PO ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_SuppliserName.Text) = 0 Then MsgBox("من فضلك ادخل  المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_BankName.Text) = 0 Then MsgBox("من فضلك اختار حساب البنك ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_ValueSh.Text) = 0 Then MsgBox("من فضلك ادخل قيمة الشحن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MenaDeprt.Text) = 0 Then MsgBox("من فضلك ادخل ميناء الوصول ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MenaAriver.Text) = 0 Then MsgBox("من فضلك ادخل ميناء المغادرة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_MethodTerms.Text) = 0 Then MsgBox("من فضلك ادخل طريقة الدفع ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Date_Dep.Value) = 0 Then MsgBox("من فضلك ادخل تاريخ المغادرة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Date_Ariv.Value) = 0 Then MsgBox("من فضلك ادخل تاريخ الوصول ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_FreeTime.Text) = 0 Then MsgBox("من فضلك ادخل عدد ايام  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '============================================د
        Dim dd As DateTime = txt_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================
        Dim dd2 As DateTime = Date_Dep.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================
        Dim dd3 As DateTime = Date_Ariv.Value
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")

        '=================================المورد
        sql = " SELECT Supliser_Name, Supliser_Code, Compny_Code       FROM dbo.St_SuppliserData " & _
            " WHERE  (Supliser_Name = '" & Com_SuppliserName.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodeSupliser = rs3("Supliser_Code").Value
        '============================================================ city
        sql = "SELECT *  FROM BD_CITIES where Name ='" & Com_CountryOfOrigin.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodecity = rs3("code").Value
        '==============================================================================Shapping
        sql = "SELECT *  FROM TB_ShippingCompny where Name ='" & Com_NameShipping.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodeshippingCo = rs3("code").Value


        Dim sql2 As String
        sql2 = "UPDATE  TB_ShappingData  SET  No_Certifect ='" & txt_NoCerti.Text & "', Policynumber ='" & Com_NoPolicsa.Text & "',PolicyDate ='" & vardate1 & "', Code_Supplier ='" & varcodeSupliser & "',AccountBankName ='" & Com_BankName.Text & "',  Shipping_value='" & txt_ValueSh.Text & "' , Departure_port = '" & txt_MenaDeprt.Text & "',Arrival_Port ='" & txt_MenaAriver.Text & "',Arrival_Date ='" & vardate3 & "',Departure_Date ='" & vardate2 & "',FreeTime ='" & txt_FreeTime.Text & "',PO_NO ='" & TXt_PONO.Text & "',Payment_method ='" & txt_MethodTerms.Text & "',terms_of_delivery ='" & Com_DervilyTerms.Text & "',amount_paid ='" & txt_Paid1.Text & "',deserved_amount ='" & txt_ManyMsthk.Text & "',code_City ='" & varcodecity & "',Code_ShipaingCO ='" & varcodeshippingCo & "',Shippingvalue ='" & txt_ValueShip.Text & "',Paid_UP ='" & txt_Paid2.Text & "',DUe ='" & txt_MshkValue.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Policynumber ='" & Com_NoPolicsa.Text & "'   "
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_all_Data()

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        varopenRptprsheses = 3
        Frm_Report_Pr.Show()
    End Sub



    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        On Error Resume Next
        Dim ro, mt As Integer

        ro = DataGridView2.CurrentRow.Index
        mt = ro

        rowindex = mt

        If DataGridView2.Item(0, mt).Value = "" Then

            vartable = "Vw_ExpensessShaping"
            VarOpenlookup = 13013
            Frm_Lookup.Text = "بحث"
            Frm_Lookup.ShowDialog()
        End If



        varaccountNo = DataGridView2.Item(0, mt).Value



        ''============================================كود الادارة
        'sql = "select * from BD_DIRCTORAY where Name  = '" & DataGridView2.Item(0, mt).Value & "' and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_deprt = rs("code").Value
        ''============================================================== كود بند التكلفة
        'sql = "select * from BD_BanCostingNoneDiract where Name  = '" & DataGridView2.Item(1, mt).Value & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcodebandCostNoneDiract = rs("code").Value
        ''======================================================
    End Sub

    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        DataGridView2.RowCount = DataGridView2.RowCount + 1
        For i = 1 To DataGridView2.RowCount - 1
            DataGridView2.Item(0, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(1, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(2, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(3, DataGridView2.RowCount - 2).Value = ""
            DataGridView2.Item(4, DataGridView2.RowCount - 2).Value = ""

        Next i
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs)
        DataGridViewX1.RowCount = DataGridViewX1.RowCount + 1
        For i = 1 To DataGridViewX1.RowCount - 1
            DataGridViewX1.Item(0, DataGridViewX1.RowCount - 2).Value = ""
            DataGridViewX1.Item(1, DataGridViewX1.RowCount - 2).Value = ""
            DataGridViewX1.Item(2, DataGridViewX1.RowCount - 2).Value = ""
            DataGridViewX1.Item(3, DataGridViewX1.RowCount - 2).Value = ""
            DataGridViewX1.Item(4, DataGridViewX1.RowCount - 2).Value = ""


        Next i
    End Sub

    Private Sub DataGridViewX1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
      
    End Sub
    Sub find_data_ExPensses()

        On Error Resume Next

        sql = " SELECT dbo.TB_Expensess_SH.No_Certifect, dbo.TB_Expensess_SH.Compny_Code, RTRIM(dbo.TB_Expensess_SH.Account_No) AS Account_No, RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, " & _
        "                  dbo.TB_Expensess_SH.Value_cash, RTRIM(dbo.TB_Expensess_SH.No_Esal) AS No_Esal, dbo.TB_Expensess_SH.Notes,dbo.TB_Expensess_SH.FlagTax " & _
        " FROM     dbo.TB_Expensess_SH LEFT OUTER JOIN " & _
        "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expensess_SH.Account_No = dbo.ST_CHARTOFACCOUNT.Account_No_Update AND " & _
        "        dbo.TB_Expensess_SH.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
        " WHERE  (dbo.TB_Expensess_SH.No_Certifect = '" & txt_Nocerti2.Text & "' ) AND (dbo.TB_Expensess_SH.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Expensess_SH.Falg = 0) "


        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridView2.RowCount = 1
            DataGridView2.Item(0, 0).Value = ""
            DataGridView2.Item(1, 0).Value = ""
            DataGridView2.Item(2, 0).Value = ""
            DataGridView2.Item(3, 0).Value = ""
            DataGridView2.Item(4, 0).Value = ""


        Else
            DataGridView2.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridView2.RowCount = rs.RecordCount

                For i = 0 To DataGridView2.RowCount - 1


                    DataGridView2.Item(0, i).Value = Trim(rs("Account_No").Value)
                    DataGridView2.Item(1, i).Value = Trim(rs("AccountName").Value)
                    DataGridView2.Item(2, i).Value = Trim(rs("Value_cash").Value)
                    DataGridView2.Item(3, i).Value = Trim(rs("No_Esal").Value)
                    DataGridView2.Item(4, i).Value = Trim(rs("Notes").Value)

                    If rs("FlagTax").Value = 0 Then DataGridView2.Item(6, i).Value = False
                    If rs("FlagTax").Value = 1 Then DataGridView2.Item(6, i).Value = True

                    rs.MoveNext()


                Next i

                Sum_colume_Expenses_Direct()


                Exit Sub
            Next T
            rs.Close()
        End If


    End Sub


    Sub find_data_Cost_Prcheses()

        On Error Resume Next
        sql = "SELECT dbo.Vw_All_POBankName.No_Item, dbo.Vw_All_POBankName.Name, dbo.Vw_All_POBankName.Quntity2, dbo.Vw_All_POBankName.unit, dbo.Vw_All_POBankName.Price_Item, dbo.Vw_All_POBankName.Cur, " & _
        "                  dbo.Vw_All_POBankName.Rat, dbo.Vw_All_POBankName.Quntity2 * dbo.Vw_All_POBankName.Price_Item AS Value_Cur, dbo.Vw_All_POBankName.Total_Item, RTRIM(dbo.Vw_All_POBankName.No_Certifect) " & _
        "                  AS No_Certifect, dbo.Vw_All_POBankName.Compny_Code " & _
        " FROM     dbo.BD_Item INNER JOIN " & _
        "                  dbo.Vw_All_POBankName ON dbo.BD_Item.Compny_Code = dbo.Vw_All_POBankName.Compny_Code AND dbo.BD_Item.Code = dbo.Vw_All_POBankName.No_Item " & _
        " WHERE  (dbo.Vw_All_POBankName.No_Certifect = '" & txt_Nocerti2.Text & "' ) AND (dbo.Vw_All_POBankName.Compny_Code = '" & VarCodeCompny & "') "


        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX1.RowCount = 1
            DataGridViewX1.Item(0, 0).Value = ""
            DataGridViewX1.Item(1, 0).Value = ""
            DataGridViewX1.Item(2, 0).Value = ""
            DataGridViewX1.Item(3, 0).Value = ""
            DataGridViewX1.Item(4, 0).Value = ""
            DataGridViewX1.Item(5, 0).Value = ""
            DataGridViewX1.Item(6, 0).Value = ""
            DataGridViewX1.Item(7, 0).Value = ""
            DataGridViewX1.Item(8, 0).Value = ""

        Else
            DataGridViewX1.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX1.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX1.RowCount - 1


                    DataGridViewX1.Item(0, i).Value = Trim(rs("No_Item").Value)
                    DataGridViewX1.Item(1, i).Value = Trim(rs("Name").Value)
                    DataGridViewX1.Item(2, i).Value = Trim(rs("Quntity2").Value)
                    DataGridViewX1.Item(3, i).Value = Trim(rs("unit").Value)
                    DataGridViewX1.Item(4, i).Value = Trim(rs("Price_Item").Value)
                    DataGridViewX1.Item(5, i).Value = Trim(rs("Cur").Value)
                    DataGridViewX1.Item(6, i).Value = Trim(rs("Rat").Value)
                    DataGridViewX1.Item(7, i).Value = Trim(rs("Value_Cur").Value)
                    DataGridViewX1.Item(8, i).Value = Trim(rs("Total_Item").Value)



                    rs.MoveNext()


                Next i



                'Sum_colume_Cost()
                'Sum_colume_All()
                'Sum_colume_Tax()
                Exit Sub
            Next T
            rs.Close()
        End If


    End Sub

    Sub Sum_colume_Expenses_Direct()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            If DataGridView2.Item(6, i).Value = False Then total += Val(DataGridView2.Rows(i).Cells(2).Value)

        Next
        txt_totalExpenses.Text = total

    End Sub

    Sub Sum_colume_Tax()
        Dim total As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1

            If DataGridView2.Item(6, i).Value = True Then total += Val(DataGridView2.Rows(i).Cells(2).Value)

        Next
        txt_TotalTax.Text = total

    End Sub


    Sub Sum_colume_All()
        Dim total As String = 0
        For i As Integer = 0 To DataGridViewX1.RowCount - 1
            Sum_colume_Cost()
            'If DataGridView2.Item(6, i).Value = True Then total += Val(DataGridView2.Rows(i).Cells(2).Value)

            DataGridViewX1.Item(9, i).Value = Math.Round(Val(txt_Total_Expenses.Text) / Val(txt_Total3.Text) * Val(DataGridViewX1.Item(8, i).Value), 2)
            DataGridViewX1.Item(10, i).Value = Math.Round(Val(DataGridViewX1.Item(9, i).Value) + Val(DataGridViewX1.Item(8, i).Value), 2)  'الاجمالى

            DataGridViewX1.Item(11, i).Value = Math.Round(Val(DataGridViewX1.Item(10, i).Value) / Val(DataGridViewX1.Item(2, i).Value), 2)  'تكلفة الوحدة غير شامل
            DataGridViewX1.Item(12, i).Value = Math.Round(Val(txt_TotalTaxTogary.Text) / Val(txt_Totalall.Text) * Val(DataGridViewX1.Item(10, i).Value), 2)   ' ضريبة ارباح تجارية
            DataGridViewX1.Item(13, i).Value = Math.Round(Val(txt_Total_TaxSal.Text) / Val(txt_Totalall.Text) * Val(DataGridViewX1.Item(10, i).Value), 2)   ' ضريبة مبيعات
            DataGridViewX1.Item(14, i).Value = Math.Round(Val(DataGridViewX1.Item(10, i).Value) + Val(DataGridViewX1.Item(12, i).Value) + Val(DataGridViewX1.Item(13, i).Value), 2)   'الاجمالى
            DataGridViewX1.Item(15, i).Value = Math.Round(Val(DataGridViewX1.Item(14, i).Value) / Val(DataGridViewX1.Item(2, i).Value), 2)   'تكلفة الوحدة شامل 


        Next


    End Sub


    Sub Sum_colume_Cost()
        Dim total As String = 0
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        Dim total5 As String = 0
        Dim total6 As String = 0
        Dim total7 As String = 0
        Dim total8 As String = 0


        For i As Integer = 0 To DataGridViewX1.RowCount - 1
            total += Val(DataGridViewX1.Rows(i).Cells(2).Value)
            total2 += Val(DataGridViewX1.Rows(i).Cells(7).Value)
            total3 += Val(DataGridViewX1.Rows(i).Cells(8).Value)

            total4 += Val(DataGridViewX1.Rows(i).Cells(10).Value)
            total5 += Val(DataGridViewX1.Rows(i).Cells(11).Value)
            'total6 += Val(DataGridViewX1.Rows(i).Cells(12).Value)
            'total7 += Val(DataGridViewX1.Rows(i).Cells(13).Value)
            total8 += Val(DataGridViewX1.Rows(i).Cells(14).Value)


        Next
        txt_Total1.Text = total
        txt_Total2.Text = total2
        txt_Total3.Text = total3

        txt_Totalall.Text = total4
        txt_totalUnitNoneDirect.Text = total5
        'txt_TotalTaxTogary.Text = total6
        'txt_Total_TaxSal.Text = total7
        txt_TotalAll2.Text = total8


    End Sub

    Sub find_data_ExPensses2()

        On Error Resume Next

        sql = " SELECT        dbo.TB_Expensess_SH.No_Certifect, dbo.TB_Expensess_SH.Compny_Code, dbo.TB_Expensess_SH.Account_No, dbo.ST_CHARTOFACCOUNT.AccountName, dbo.TB_Expensess_SH.Value_cash, " & _
 "                         dbo.TB_Expensess_SH.No_Esal, dbo.TB_Expensess_SH.Notes " & _
 " FROM            dbo.TB_Expensess_SH INNER JOIN " & _
 "                         dbo.ST_CHARTOFACCOUNT ON dbo.TB_Expensess_SH.Account_No = dbo.ST_CHARTOFACCOUNT.Account_No AND dbo.TB_Expensess_SH.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code " & _
 " WHERE        (dbo.TB_Expensess_SH.No_Certifect = '" & txt_Nocerti2.Text & "' ) AND TB_Expensess_SH.Compny_Code = '" & VarCodeCompny & "' and falg = 1 "





        rs = New ADODB.Recordset
        rs.Open(sql, Cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 0 Then
            DataGridViewX1.RowCount = 1
            DataGridViewX1.Item(0, 0).Value = ""
            DataGridViewX1.Item(1, 0).Value = ""
            DataGridViewX1.Item(2, 0).Value = ""
            DataGridViewX1.Item(3, 0).Value = ""
            DataGridViewX1.Item(4, 0).Value = ""


        Else
            DataGridViewX1.RowCount = 1
            rs.MoveLast() : rs.MoveFirst()

            Dim T
            For T = 0 To rs.RecordCount - 1
                DataGridViewX1.RowCount = rs.RecordCount

                For i = 0 To DataGridViewX1.RowCount - 1


                    DataGridViewX1.Item(0, i).Value = Trim(rs("Account_No").Value)
                    DataGridViewX1.Item(1, i).Value = Trim(rs("AccountName").Value)
                    DataGridViewX1.Item(2, i).Value = Trim(rs("Value_cash").Value)
                    DataGridViewX1.Item(3, i).Value = Trim(rs("No_Esal").Value)
                    DataGridViewX1.Item(4, i).Value = Trim(rs("Notes").Value)




                    rs.MoveNext()


                Next i




                Exit Sub
            Next T
            rs.Close()
        End If


    End Sub
    Private Sub Cmd_Saveall_Click(sender As Object, e As EventArgs) Handles Cmd_Saveall.Click

        On Error Resume Next
        sql = "Delete TB_Expensess_SH  WHERE No_Certifect ='" & txt_Nocerti2.Text & "' and  Compny_Code ='" & VarCodeCompny & "' and falg =0 "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridView2.Rows.Count - 1


            If DataGridView2.Item(6, x).Value = True Then varflagTax = 1
            If DataGridView2.Item(6, x).Value = False Then varflagTax = 0


            sql = "INSERT INTO TB_Expensess_SH (No_Certifect, Policynumber,Account_No,Value_cash,No_Esal,Notes,Falg,Compny_Code,FlagTax) " & _
                    " values  (N'" & Trim(txt_Nocerti2.Text) & "' ,N'" & Trim(Com_NoPolicsa.Text) & "',N'" & Trim(DataGridView2.Item(0, x).Value) & "',N'" & Trim(DataGridView2.Item(2, x).Value) & "',N'" & Trim(DataGridView2.Item(3, x).Value) & "',N'" & Trim(DataGridView2.Item(4, x).Value) & "',N'" & 0 & "' ,'" & VarCodeCompny & "' ,'" & varflagTax & "')"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Sum_colume_All()
        sum_TaxTogary()
        sum_TaxSal()
        Sum_colume_All()
        Sum_colume_Cost()


        save_cost()
    End Sub
    Sub save_cost()
        On Error Resume Next

        sql = "Delete TB_CostingItem  WHERE No_Certifect ='" & txt_Nocerti2.Text & "' and  Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridViewX1.Rows.Count - 1


         

            sql = "INSERT INTO TB_CostingItem (No_Certifect, No_Item,Expenses,Total_Exp_Value,Cost_noneDirect,Tax_Togry,Tax_sal,TotalAll,Cost_ItemTax,Compny_Code) " & _
                    " values  (N'" & Trim(txt_Nocerti2.Text) & "' ,N'" & Trim(DataGridViewX1.Item(0, x).Value) & "',N'" & Trim(DataGridViewX1.Item(9, x).Value) & "',N'" & Trim(DataGridViewX1.Item(10, x).Value) & "',N'" & Trim(DataGridViewX1.Item(11, x).Value) & "',N'" & Trim(DataGridViewX1.Item(12, x).Value) & "',N'" & Trim(DataGridViewX1.Item(13, x).Value) & "' ,N'" & Trim(DataGridViewX1.Item(14, x).Value) & "' ,N'" & Trim(DataGridViewX1.Item(15, x).Value) & "',N'" & VarCodeCompny & "')"
            Cnn.Execute(sql)


        Next

        'MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete TB_Expensess_SH  WHERE  No_Certifect ='" & txt_Nocerti2.Text & "' and Account_No ='" & varaccountNo & "' and  Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        ' Fill_Find()
        find_data_ExPensses()
        Sum_colume_Expenses_Direct()
        Sum_colume_Tax()

        Sum_colume_All()
        sum_TaxTogary()
        sum_TaxSal()
        Sum_colume_All()
        Sum_colume_Cost()
    End Sub

  

    Private Sub DataGridViewX1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellDoubleClick
        On Error Resume Next
        Dim ro2, mt2 As Integer

        ro2 = DataGridViewX1.CurrentRow.Index
        mt2 = ro2

        rowindex2 = mt2

        If DataGridViewX1.Item(0, mt2).Value = "" Then

            vartable = "Vw_ExpensessShaping"
            VarOpenlookup = 13014
            Frm_Lookup.Text = "بحث"
            Frm_Lookup.ShowDialog()
        End If

        varaccountNo2 = DataGridViewX1.Item(0, mt2).Value

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        sql = "Delete TB_Expensess_SH  WHERE No_Certifect ='" & txt_Nocerti2.Text & "' and  Compny_Code ='" & VarCodeCompny & "' and flag =1 "
        rs = Cnn.Execute(sql)


        For x As Integer = 0 To DataGridViewX1.Rows.Count - 1





            sql = "INSERT INTO TB_Expensess_SH (No_Certifect, Policynumber,Account_No,Value_cash,No_Esal,Notes,Falg,Compny_Code) " & _
                    " values  (N'" & Trim(txt_Nocerti2.Text) & "' ,N'" & Trim(Com_NoPolicsa.Text) & "',N'" & Trim(DataGridViewX1.Item(0, x).Value) & "',N'" & Trim(DataGridViewX1.Item(2, x).Value) & "',N'" & Trim(DataGridViewX1.Item(3, x).Value) & "',N'" & Trim(DataGridViewX1.Item(4, x).Value) & "',N'" & 1 & "' ,'" & VarCodeCompny & "' )"
            Cnn.Execute(sql)


        Next

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        sql = "Delete TB_Expensess_SH  WHERE  No_Certifect ='" & txt_Nocerti2.Text & "' and Account_No ='" & varaccountNo2 & "' and falg = 1 and  Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        find_data_ExPensses2()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        Sum_colume_Expenses_Direct()
        Sum_colume_Tax()
        'Sum_colume_All()
    End Sub

    Private Sub txt_TotalTax_TextChanged(sender As Object, e As EventArgs) Handles txt_TotalTax.TextChanged
        On Error Resume Next
        Txt_Cost_Masg.Text = Val(txt_totalExpenses.Text) + Val(txt_TotalTax.Text)
        txt_Total_Expenses.Text = Val(txt_totalExpenses.Text)
    End Sub

   

    Private Sub txt_totalExpenses_TextChanged(sender As Object, e As EventArgs) Handles txt_totalExpenses.TextChanged
        On Error Resume Next
        Txt_Cost_Masg.Text = Val(txt_totalExpenses.Text) + Val(txt_TotalTax.Text)
        txt_Total_Expenses.Text = Val(txt_totalExpenses.Text)
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        varprintEx = 1
        Frm_RptShipping.Show()
    End Sub

    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        varprintEx = 2
        Frm_RptShipping.Show()
    End Sub

    Private Sub Com_NameShipping_EditValueChanged(sender As Object, e As EventArgs) Handles Com_NameShipping.EditValueChanged

    End Sub

    Private Sub Com_CountryOfOrigin_EditValueChanged(sender As Object, e As EventArgs) Handles Com_CountryOfOrigin.EditValueChanged

    End Sub
End Class