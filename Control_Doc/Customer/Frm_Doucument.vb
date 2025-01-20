Imports System.Data.OleDb

Public Class Frm_Doucument
    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles btn_shaseh_txt.ButtonClick

        vartable = "BD_cars_info"
        VarOpenlookup = 195
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles btn_shaseh_txt.ButtonClick

    End Sub

    Private Sub btn_insurance_company_name_txt_EditValueChanged(sender As Object, e As EventArgs) Handles btn_insurance_company_name_txt.ButtonClick
        vartable = "BD_Insurnce_Company_name"
        VarOpenlookup = 196
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_customer_name_txt_EditValueChanged(sender As Object, e As EventArgs) Handles btn_customer_name_txt.ButtonClick
        vartable = "St_CustomerData2"
        VarOpenlookup = 197
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_insurance_Mother_company_name_txt_EditValueChanged(sender As Object, e As EventArgs) Handles btn_insurance_Mother_company_name_txt.ButtonClick
        vartable = "BD_Mother_company_name"
        VarOpenlookup = 198
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_company_name_Click(sender As Object, e As EventArgs) Handles btn_new_company_name.Click
        vartable = "BD_Insurnce_Company_name"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "اسماء الشركات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_new_Mother_company_name_Click(sender As Object, e As EventArgs) Handles btn_new_Mother_company_name.Click
        vartable = "BD_Mother_company_name"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " اسماءالشركات الام "
        Frm_GenralData.Show()
    End Sub




    Private Sub btn_save_wasyka_Click(sender As Object, e As EventArgs) Handles btn_save_wasyka.Click
        If Len(txt_wasyka_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الوثيقة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_ta7mol_types.Text) = 0 Then MsgBox("من فضلك اختار التحملات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_taghtyat_types.Text) = 0 Then MsgBox("من فضلك اختار التغطيات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(btn_customer_name_txt.Text) = 0 Then MsgBox("من فضلك اختار اسم العميل  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(btn_insurance_company_name_txt.Text) = 0 Then MsgBox("من فضلك اختار شركة التامين  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_ta7mol_types.Text) = 0 Then MsgBox("من فضلك اختار التحملات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_taghtyat_types.Text) = 0 Then MsgBox("من فضلك اختار الغطيات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_exceptions.Text) = 0 Then MsgBox("من فضلك اختار الاستثناءات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As Date = txt_wasyka_start_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd3 As Date = txt_wasyka_renew_date.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-dd-yyyy")

        Dim dd4 As Date = txt_insurance_start_date.Value
        Dim vardate3 As String
        vardate3 = dd4.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd5 As Date = txt_insurance_end_date.Value
        Dim vardate4 As String
        vardate4 = dd5.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd6 As Date = txt_wasyka_enter_date.Value
        Dim vardate5 As String
        vardate5 = dd5.ToString("MM-dd-yyyy")


        'sql = "select * from BD_insurance_doucument where wasyka_no = '" & txt_wasyka_no.Text & "' "
        'rs3 = Cnn.Execute(sql)
        'If rs3.EOF = False Then MsgBox("من فضلك رقم الوثيقة تكرر لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "insert into  BD_insurance_doucument values('" & txt_wasyka_no.Text & "','" & btn_wasyka_type_txt.Text & "' ,'" & vardate & "' , '" & "" & "','" & vardate2 & "' , 
'" & txt_wasyka_state.Text & "' , '" & txt_wasyt_names.Text & "' , '" & btn_insurance_company_name_txt.Text & "', '" & btn_customer_name_txt.Text & "' , 
'" & btn_insurance_Mother_company_name_txt.Text & "' , '" & txt_coverage_cost.Text & "' , '" & txt_net_cost.Text & "', ' " & txt_total_cost.Text & "' , '" & btn_shaseh_txt.Text & "' , '" & vardate3 & "' , '" & vardate4 & "' , '" & t7amol_tawkeel_txt.Text & "' , '" & t7amol_akhtyary_txt.Text & "','" & txt_heaza.Text & "','" & txt_mostfed.Text & "' , '" & vardate5 & "')"


        SQL3 = "insert into BD_conditions values ('" & txt_wasyka_no.Text & "' , '" & txt_ta7mol_types.Text & "' , '" & txt_taghtyat_types.Text & "' , '" & txt_exceptions.Text & "' , '" & txt_coments.Text & "')"

        Cnn.Execute(sql)
        Cnn.Execute(SQL3)

        sql2 = "update BD_cars_info set wasyka_no = '" & txt_wasyka_no.Text & "'
        where shasyeh_no = '" & btn_shaseh_txt.Text & "'"
        Cnn.Execute(sql2)

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_document(sqll:="select * from vw_insurance_document_data")
        clear()

    End Sub

    Sub find_document(sqll)

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = sqll


        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)


        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)




        GridView9.Appearance.Row.Options.UseFont = True

        'GridView9.Columns(0).Caption = "رقم الوثيقة"
        'GridView9.Columns(1).Caption = "نوع الوثيقة"
        'GridView9.Columns(2).Caption = "تاريخ بدء الوثيقة"
        'GridView9.Columns(3).Caption = " وثيقة التأمين"
        'GridView9.Columns(4).Caption = "تاريخ تجديد الوثيقة"
        'GridView9.Columns(5).Caption = "حالة الوثيقة"
        'GridView9.Columns(6).Caption = "الوسيط"
        'GridView9.Columns(7).Caption = "اسم شركة التأمين "
        'GridView9.Columns(8).Caption = "اسم العميل"
        'GridView9.Columns(9).Caption = "اسم الشركة الام"
        'GridView9.Columns(10).Caption = "مبلغ التغطية"
        'GridView9.Columns(11).Caption = " الصافي"
        'GridView9.Columns(12).Caption = "الاجمالي"
        'GridView9.Columns(13).Caption = "رقم الشاسيه"
        'GridView9.Columns(14).Caption = "تاريخ بدء التأمين"
        'GridView9.Columns(15).Caption = "تاريخ انتهاء التأمين"
        'GridView9.Columns(16).Caption = "اصلاح بالتوكيل"
        'GridView9.Columns(17).Caption = "تحمل اجباري"
        'GridView9.Columns(18).Caption = "الحيازة"
        'GridView9.Columns(16).Caption = "السعة اللترية"
        'GridView9.Columns(17).Caption = "نوع الوقود"



        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick

        clear()

        Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle
        Dim wasyka_no = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(0))
        Dim wasyka_type = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(1))
        Dim wasyka_start_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(2))
        ' Dim insurance = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(3))
        Dim wasyka_renew_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(3))
        Dim state = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(4))
        Dim wallet = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(5))
        Dim insurance_company_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(6))
        Dim customer_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(7))
        Dim insurance_Mother_company_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(8))


        Dim coverage_cost = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(9))
        Dim net_cost = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(10))
        Dim total_cost = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(11))
        Dim shaseh = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(12))
        Dim insurance_start_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(13))
        Dim insurence_end_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(14))
        Dim t7amol1 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(15))
        Dim t7amol2 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(16))
        Dim heaza = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(17))
        Dim ta7molat = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(18))
        Dim taghtyat = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(19))
        Dim exceptions = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(20))
        Dim comments = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(21))
        Dim mostfed = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(22))
        Dim enter_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(23))

        cars_in_document(wasyka_no)


        'txt_wasyka_no.Text = wasyka_no

        'txt_wasyka_start_date.Value = wasyka_start_date

        '' Dim shakaString As String = shaka.ToString()
        'txt_wasyka_state.Text = state
        'txt_wasyt_names.Text = wallet
        'btn_insurance_company_name_txt.Text = insurance_company_name
        'btn_customer_name_txt.Text = customer_name

        'txt_coverage_cost.Text = coverage_cost
        'txt_net_cost.Text = net_cost
        'txt_total_cost.Text = total_cost
        'btn_shaseh_txt.Text = shaseh
        'txt_insurance_start_date.Value = insurance_start_date

        'txt_insurance_end_date.Value = insurence_end_date

        't7amol_tawkeel_txt.Text = t7amol1
        't7amol_akhtyary_txt.Text = t7amol2


        If Not IsDBNull(wasyka_no) Then
            txt_wasyka_no.Text = wasyka_no
        End If

        If Not IsDBNull(wasyka_start_date) Then
            txt_wasyka_start_date.Value = wasyka_start_date
        End If

        If Not IsDBNull(state) Then
            txt_wasyka_state.Text = state
        End If

        If Not IsDBNull(wallet) Then
            txt_wasyt_names.Text = wallet
        End If

        If Not IsDBNull(insurance_company_name) Then
            btn_insurance_company_name_txt.Text = insurance_company_name
        End If

        If Not IsDBNull(customer_name) Then
            btn_customer_name_txt.Text = customer_name
        End If

        If Not IsDBNull(coverage_cost) Then
            txt_coverage_cost.Text = coverage_cost
        End If

        If Not IsDBNull(net_cost) Then
            txt_net_cost.Text = net_cost
        End If

        If Not IsDBNull(total_cost) Then
            txt_total_cost.Text = total_cost
        End If

        If Not IsDBNull(shaseh) Then
            btn_shaseh_txt.Text = shaseh
        End If

        If Not IsDBNull(insurance_start_date) Then
            txt_insurance_start_date.Value = insurance_start_date
        End If

        If Not IsDBNull(insurence_end_date) Then
            txt_insurance_end_date.Value = insurence_end_date
        End If

        If Not IsDBNull(t7amol1) Then
            t7amol_tawkeel_txt.Text = t7amol1
        End If

        If Not IsDBNull(t7amol2) Then
            t7amol_akhtyary_txt.Text = t7amol2
        End If





        If Not IsDBNull(wasyka_type) Then
            btn_wasyka_type_txt.Text = wasyka_type

        End If

        '  t7amol_akhtyary_txt.Text = insurance
        If Not IsDBNull(wasyka_renew_date) Then
            txt_wasyka_renew_date.Value = wasyka_renew_date

        End If




        If Not IsDBNull(insurance_Mother_company_name) Then
            btn_insurance_Mother_company_name_txt.Text = insurance_Mother_company_name

        End If

        If Not IsDBNull(heaza) Then
            txt_heaza.Text = heaza

        End If

        If Not IsDBNull(ta7molat) Then
            txt_ta7mol_types.Text = ta7molat
        End If




        If Not IsDBNull(taghtyat) Then
            txt_taghtyat_types.Text = taghtyat

        End If

        If Not IsDBNull(exceptions) Then
            txt_exceptions.Text = exceptions

        End If

        If Not IsDBNull(comments) Then
            txt_coments.Text = exceptions

        End If
        If Not IsDBNull(mostfed) Then
            txt_mostfed.Text = mostfed

        End If

        If Not IsDBNull(enter_date) Then
            txt_wasyka_enter_date.Value = enter_date

        End If

        TabPane1.SelectedPageIndex = 0

    End Sub

    Private Sub Frm_Doucument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_document(sqll:="select * from vw_insurance_document_data")
        ended_wasyka_txt.Text = doucument_ended()
        wasyka_close_toEnd.Text = document_close_toEnd()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btn_delete_wasyka_Click(sender As Object, e As EventArgs) Handles btn_delete_wasyka.Click
        If Len(txt_wasyka_no.Text) = 0 Then MsgBox("من فضلك اختار رقم الوثيقة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim x As String
        x = MsgBox("هل تريد الحذف ؟", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes

                sql = "Delete From BD_insurance_doucument where wasyka_no = '" & txt_wasyka_no.Text & "'"
                SQL3 = "Delete From BD_conditions where wasyka_no = '" & txt_wasyka_no.Text & "'"
                Cnn.Execute(sql)
                Cnn.Execute(SQL3)

                sql2 = "update BD_cars_info set wasyka_no = '" & 0 & "'
 where shasyeh_no = '" & btn_shaseh_txt.Text & "'"
                Cnn.Execute(sql2)

                MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        End Select

        find_document(sqll:="select * from vw_insurance_document_data")
        clear()
    End Sub

    Private Sub clear()

        txt_coverage_cost.Text = ""
        t7amol_akhtyary_txt.Text = ""
        txt_net_cost.Text = ""
        txt_total_cost.Text = ""
        txt_wasyt_names.Text = ""
        txt_wasyka_no.Text = ""
        txt_wasyka_state.Text = ""
        'txt_wasyka_type.Text = ""
        t7amol_akhtyary_txt.Text = ""
        t7amol_tawkeel_txt.Text = ""
        btn_customer_name_txt.Text = ""
        btn_insurance_company_name_txt.Text = ""
        btn_insurance_Mother_company_name_txt.Text = ""
        btn_shaseh_txt.Text = ""
        txt_coments.Text = ""
        txt_exceptions.Text = ""
        txt_heaza.Text = ""
        txt_taghtyat_types.Text = ""
        txt_ta7mol_types.Text = ""
        txt_wallet.Text = ""
        txt_mostfed.Text = ""
        txt_wasyt_names.Text = ""


    End Sub

    Private Sub btn_update_wasyka_Click(sender As Object, e As EventArgs) Handles btn_update_wasyka.Click
        If Len(txt_wasyka_no.Text) = 0 Then MsgBox("من فضلك اختار رقم الوثيقة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        If Len(txt_ta7mol_types.Text) = 0 Then MsgBox("من فضلك اختار التحملات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_taghtyat_types.Text) = 0 Then MsgBox("من فضلك اختار التغطيات  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(btn_customer_name_txt.Text) = 0 Then MsgBox("من فضلك اختار اسم العميل  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(btn_insurance_company_name_txt.Text) = 0 Then MsgBox("من فضلك اختار شركة التامين  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        Dim dd2 As Date = txt_wasyka_start_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd3 As Date = txt_wasyka_renew_date.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-dd-yyyy")

        Dim dd4 As Date = txt_insurance_start_date.Value
        Dim vardate3 As String
        vardate3 = dd4.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd5 As Date = txt_insurance_end_date.Value
        Dim vardate4 As String
        vardate4 = dd5.ToString("MM-dd-yyyy")

        '==============================================
        Dim dd6 As Date = txt_wasyka_enter_date.Value
        Dim vardate5 As String
        vardate5 = dd5.ToString("MM-dd-yyyy")



        sql = "update BD_insurance_doucument set wasyka_type = '" & btn_wasyka_type_txt.Text & "'  , wasyka_start_date = '" & vardate & "' , insurance = ' " & "" & "' ,
        wasyka_renew_date = '" & vardate2 & "' , wallet = '" & txt_wasyt_names.Text & "' , insurance_company_name = ' " & btn_insurance_company_name_txt.Text & "' , customer_name = ' " & btn_customer_name_txt.Text & "',
        mother_company_name = '" & btn_insurance_Mother_company_name_txt.Text & "' , coverage_cost = ' " & txt_coverage_cost.Text & "' , net_cost = '" & txt_net_cost.Text & "' , total_cost = '" & txt_total_cost.Text & "' , shasyeh_no ='" & btn_shaseh_txt.Text & "' ,
        insurance_start_date = '" & vardate3 & "' , insurance_end_date = '" & vardate4 & "', tehmol_twkel = '" & t7amol_tawkeel_txt.Text & "' , tehmol_egpary = '" & t7amol_akhtyary_txt.Text & "' , heaza = '" & txt_heaza.Text & "' , mostfed = '" & txt_mostfed.Text & "' , enter_date = '" & vardate5 & "'
       
        where wasyka_no = '" & txt_wasyka_no.Text & "' "

        Cnn.Execute(sql)

        sql2 = "select * from BD_conditions where wasyka_no = '" & txt_wasyka_no.Text & "' "
        rs3 = Cnn.Execute(sql2)
        If rs3.EOF = False Then
            SQL3 = "update BD_conditions set ta7molat = '" & txt_ta7mol_types.Text & "' , taghtyat = '" & txt_taghtyat_types.Text & "' , exceptions = '" & txt_exceptions.Text & "' , comments = '" & txt_coments.Text & "' 
                    where wasyka_no = '" & txt_wasyka_no.Text & "'"
        Else
            SQL3 = "insert into BD_conditions values ('" & txt_wasyka_no.Text & "' , '" & txt_ta7mol_types.Text & "' , '" & txt_taghtyat_types.Text & "' , '" & txt_exceptions.Text & "' , '" & txt_coments.Text & "')"

        End If

        Cnn.Execute(SQL3)

        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_document(sqll:="select * from vw_insurance_document_data")
    End Sub


    Private Sub cars_in_document(wasyka)
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql = "select * from BD_cars_info where wasyka_no = '" & wasyka & "'"


        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)




        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "كود السيارة"
        GridView5.Columns(1).Caption = "الماركة"
        GridView5.Columns(2).Caption = "الموديل"
        GridView5.Columns(3).Caption = "سنة الصنع"
        GridView5.Columns(4).Caption = "اللون"
        GridView5.Columns(5).Caption = "رقم الشاسيه"
        GridView5.Columns(6).Caption = "رقم الموتور "
        GridView5.Columns(7).Caption = "رقم اللوحة"
        GridView5.Columns(8).Caption = "الشكل"
        GridView5.Columns(9).Caption = "ادارة المرور"
        GridView5.Columns(10).Caption = " وحدةالمرور"
        GridView5.Columns(11).Caption = "اصدار الرخصة"
        GridView5.Columns(12).Caption = "انتهاء الرخصة"
        GridView5.Columns(13).Caption = "تامين اجباري"
        GridView5.Columns(14).Caption = "رقم الوثيقة"
        GridView5.Columns(15).Caption = "السعة اللترية"
        GridView5.Columns(16).Caption = "نوع الوقود"
        GridView5.Columns(17).Caption = "عدد السليندرات"
        GridView5.Columns(18).Caption = "عدد الركاب"




        GridView5.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick



    End Sub

    Function doucument_ended()
        Dim no As Int32 = 0
        sql = " select count(*) as numbers from BD_insurance_doucument 
where insurance_end_date < GETDATE()"

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then no = rs3("numbers").Value

        Return no

    End Function
    Function document_close_toEnd()
        Dim no As Int32 = 0
        sql = " select count(*) as numbers FROM BD_insurance_doucument 
WHERE insurance_end_date BETWEEN GETDATE() AND DATEADD(day, 60, GETDATE())"

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then no = rs3("numbers").Value

        Return no
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles t7amol_tawkeel_txt.TextChanged

    End Sub

    Private Sub LabelX7_Click(sender As Object, e As EventArgs) Handles LabelX7.Click

    End Sub

    Private Sub btn_insurance_Mother_company_name_txt_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles btn_insurance_Mother_company_name_txt.ButtonClick

    End Sub

    Private Sub ButtonEdit_t7amol_types_EditValueChanged(sender As Object, e As EventArgs) Handles ButtonEdit_t7amol_types.ButtonClick
        vartable = "BD_T7amol_types"
        VarOpenlookup = 202
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub ButtonEdit_t7amol_types_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit_t7amol_types.ButtonClick

    End Sub

    Private Sub btn_new_t7amol_Click(sender As Object, e As EventArgs) Handles btn_new_t7amol.Click
        vartable = "BD_T7amol_types"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع التحملات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_delete_t7amolat_Click(sender As Object, e As EventArgs) Handles btn_delete_t7amolat.Click
        txt_ta7mol_types.Text = ""
    End Sub

    Private Sub ButtonEdit1_EditValueChanged_1(sender As Object, e As EventArgs) Handles ButtonEdit1.ButtonClick
        vartable = "BD_tghtyat_types"
        VarOpenlookup = 203

        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_delete_tghtyat_Click(sender As Object, e As EventArgs) Handles btn_delete_tghtyat.Click
        txt_taghtyat_types.Text = ""
    End Sub

    Private Sub btn_new_tghtyat_Click(sender As Object, e As EventArgs) Handles btn_new_tghtyat.Click
        vartable = "BD_tghtyat_types"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع التغطيات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_new_customer_Click(sender As Object, e As EventArgs) Handles btn_new_customer.Click
        Mainmune2.openCustomerFrm()

    End Sub

    Private Sub btn_new_car_Click(sender As Object, e As EventArgs) Handles btn_new_car.Click
        Mainmune2.openCarFrm()

    End Sub

    Private Sub btn_wasyka_type_txt_EditValueChanged(sender As Object, e As EventArgs) Handles btn_wasyka_type_txt.ButtonClick
        vartable = "BD_document_types"
        VarOpenlookup = 204

        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_wasyka_type_Click(sender As Object, e As EventArgs) Handles btn_new_wasyka_type.Click
        vartable = "BD_document_types"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع التغطيات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_customer_name_txt_EditValueChanged_1(sender As Object, e As EventArgs) Handles btn_customer_name_txt.EditValueChanged

    End Sub

    Private Sub btn_wasyka_type_txt_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles btn_wasyka_type_txt.ButtonClick

    End Sub

    Private Sub txt_wallet_EditValueChanged(sender As Object, e As EventArgs) Handles txt_wallet.ButtonClick
        vartable = "BD_wasyt"
        VarOpenlookup = 209

        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_wasyt_Click(sender As Object, e As EventArgs) Handles btn_new_wasyt.Click
        vartable = "BD_wasyt"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "اسماء الوسطاء "
        Frm_GenralData.Show()
    End Sub

    Private Sub txt_net_cost_TextChanged(sender As Object, e As EventArgs) Handles txt_net_cost.TextChanged
        If Len(txt_net_cost.Text) <> 0 Then
            If Len(txt_coverage_cost.Text) <> 0 Then
                txt_safy_percent.Text = (txt_net_cost.Text / txt_coverage_cost.Text) * 100

            End If
        End If


    End Sub

    Private Sub btn_delete_wasyt_names_Click(sender As Object, e As EventArgs) Handles btn_delete_wasyt_names.Click
        txt_wasyt_names.Text = ""
    End Sub

    Private Sub txt_total_cost_TextChanged(sender As Object, e As EventArgs) Handles txt_total_cost.TextChanged
        If Len(txt_total_cost.Text) <> 0 Then
            If Len(txt_coverage_cost.Text) <> 0 Then
                txt_total_percent.Text = (txt_total_cost.Text / txt_coverage_cost.Text) * 100

            End If
        End If
    End Sub

    Private Sub CheckBox_total_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_total.CheckedChanged
        If CheckBox_total.Checked = True Then
            CheckBox_partial.Checked = False
        End If
    End Sub

    Private Sub CheckBox_partial_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_partial.CheckedChanged
        If CheckBox_partial.Checked = True Then
            CheckBox_total.Checked = False
        End If
    End Sub
End Class