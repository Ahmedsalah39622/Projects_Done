Option Infer On

Imports System.Data.OleDb
Imports System.Data



'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports System.Windows.Controls
Imports CrystalDecisions.[Shared].Json





Public Class Frm_Cust
    Dim varcodestat, varcoderegion1, vartype_customer, varcoderegion2, vardirctoratcode, varcodedeprt, varcodecontract, VARCODEQUALIFICATIONS, VARCODEJOBNAMES, VARCODEBUILDINGS, varcitycode As Integer
    Dim var_accountCustomer As String




    Private Sub txt_NameDiractorat_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_City.ButtonClick
        vartable = "BD_CITIES"
        VarOpenlookup = 180
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        vartable = "BD_CITIES"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Mef
        Frm_GenralData.Text = "أكواد البلد "
        Frm_GenralData.Show()
    End Sub
    Private Sub Txt_RegionM_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Txt_RegionM.ButtonClick
        vartable = "BD_REGION"
        VarOpenlookup = 190
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        vartable = "BD_REGION"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Mef
        Frm_GenralData.Text = "أكواد المحافظة "
        Frm_GenralData.Show()
    End Sub

    Private Sub Txt_RegionF_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Txt_RegionF.ButtonClick
        vartable = "BD_SUB_REGIONS"
        VarOpenlookup = 1900
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        vartable = "BD_SUB_REGIONS"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المناطق "
        Frm_GenralData.Show()
    End Sub




    Private Sub Frm_Cust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_ECGDataSet2.View_9' table. You can move, or remove it, as needed.

        find_custmer()
        'finance_info()
        'passport_info()
        'customer_license_info()
        TabPane2.SelectedPageIndex = 0
        ended_license.Text = count_in_customer("  select count(*) as numbers from BD_personal_license_info
  where license_end_date < GETDATE()")
        all_customer_number.Text = count_in_customer("select count(*) as numbers from St_CustomerData2")
        ended_national_id.Text = count_in_customer("select count(*) as numbers from St_CustomerData2
where National_ID_End < GETDATE()")
        ended_passport.Text = count_in_customer("select count(*) as numbers from BD_passport_info 
where end_date < GETDATE()")


    End Sub
    Sub find_custmer()

        'On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()






        '        sql2 = "select	   dbo.St_CustomerData2.Customer_Code, dbo.St_CustomerData2.Customer_Name, dbo.St_CustomerData2.Customer_AccountNo, iif(Customer_Type=0,'عميل','شركة') as Type , dbo.BD_CITIES.Name, dbo.BD_REGION.Name AS Expr1, 
        '                         dbo.BD_SUB_REGIONS.Name AS Expr2, dbo.St_CustomerData2.Al_Akar, dbo.St_CustomerData2.Al_Dor, dbo.St_CustomerData2.Al_Shak, dbo.St_CustomerData2.Customer_Phon1, dbo.St_CustomerData2.Customer_Phon2, 
        '                         dbo.St_CustomerData2.Customer_Mobil1, dbo.St_CustomerData2.Customer_Mobil2, dbo.St_CustomerData2.Customer_Email_Work, dbo.St_CustomerData2.Customer_Email_Persone, dbo.St_CustomerData2.Customer_Website, 
        '                         dbo.St_CustomerData2.Customer_Type_sex, dbo.St_CustomerData2.Customer_NationalID, dbo.St_CustomerData2.National_ID_Start, dbo.St_CustomerData2.National_ID_End, 
        '                         dbo.St_CustomerData2.Print_No, dbo.St_CustomerData2.Birthday, dbo.BD_SOCIALSTATUS.Name AS Expr3, dbo.St_CustomerData2.Customer_FileNoTax, dbo.St_CustomerData2.Customer_NoReg_Tax, dbo.St_CustomerData2.Customer_NoFileTogary, 
        '						 dbo.St_CustomerData2.Customer_NameM,
        '                         dbo.BD_JOBNAMES.Name AS Expr4, dbo.BD_Customer_work_info.company_name, dbo.BD_Customer_work_info.work_address, dbo.BD_Customer_work_info.work_phone1, dbo.BD_Customer_work_info.work_phone2, 
        '                         dbo.BD_Customer_work_info.no_inside
        'FROM            dbo.St_CustomerData2 full JOIN
        '                         dbo.BD_CITIES ON dbo.St_CustomerData2.Code_City = dbo.BD_CITIES.Code inner JOIN
        '                         dbo.BD_REGION ON dbo.St_CustomerData2.Code_Region_M = dbo.BD_REGION.Code inner JOIN
        '                         dbo.BD_SUB_REGIONS ON dbo.St_CustomerData2.Code_Region2 = dbo.BD_SUB_REGIONS.Code full JOIN
        '                         dbo.BD_SOCIALSTATUS ON dbo.St_CustomerData2.Customer_State = dbo.BD_SOCIALSTATUS.code LEFT OUTER JOIN
        '                         dbo.BD_JOBNAMES full JOIN
        '                         dbo.BD_Customer_work_info ON dbo.BD_JOBNAMES.Code = dbo.BD_Customer_work_info.job_code ON dbo.St_CustomerData2.Customer_Code = dbo.BD_Customer_work_info.customer_code"


        sql2 = "select * from vw_all_customer_data"


        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)



        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)




        GridView3.Appearance.Row.Options.UseFont = True

        GridView3.Columns(0).Caption = "كود العميل"
        GridView3.Columns(1).Caption = "اسم العميل"
        GridView3.Columns(2).Caption = "رقم الحساب"
        GridView3.Columns(3).Caption = "نوع العميل"
        GridView3.Columns(4).Caption = "البلد"
        GridView3.Columns(5).Caption = "المحافظة"
        GridView3.Columns(6).Caption = "المنطقة"
        GridView3.Columns(7).Caption = "العقار"
        GridView3.Columns(8).Caption = "الدور"
        GridView3.Columns(9).Caption = "الشقة"
        GridView3.Columns(10).Caption = "هاتف 1"
        GridView3.Columns(11).Caption = "هاتف 2"
        GridView3.Columns(12).Caption = "محمول 1"
        GridView3.Columns(13).Caption = "محمول 2"
        GridView3.Columns(14).Caption = "ايميل العمل"
        GridView3.Columns(15).Caption = "ايميل شخصي"
        GridView3.Columns(16).Caption = "الموقع"
        GridView3.Columns(17).Caption = "النوع"
        GridView3.Columns(18).Caption = "رقم البطاقة"
        GridView3.Columns(19).Caption = "اصدار البطاقة"
        GridView3.Columns(20).Caption = "انتهاء البطاقة"
        GridView3.Columns(21).Caption = "الرقم المطبوع"
        GridView3.Columns(22).Caption = " تاريخ الميلاد"
        GridView3.Columns(23).Caption = "الحالة الاجتماعية"
        GridView3.Columns(24).Caption = "الملف الضريبي"
        GridView3.Columns(25).Caption = "السجل الضريبي"
        GridView3.Columns(26).Caption = "السجل التجاري"
        GridView3.Columns(27).Caption = "المسئول"

        GridView3.Columns(28).Caption = "الوظيفة"
        GridView3.Columns(29).Caption = "اسم الشركة"
        GridView3.Columns(30).Caption = "عنوان الوظيفة"
        GridView3.Columns(31).Caption = "هاتف العمل1"
        GridView3.Columns(32).Caption = "هاتف العمل2"
        GridView3.Columns(33).Caption = "الرقم الداخلي"
        'GridView3.Columns(34).Caption = "اسم القريب"
        'GridView3.Columns(35).Caption = "صلة القرابة"
        'GridView3.Columns(36).Caption = "رقم الموبيل 1"
        'GridView3.Columns(37).Caption = "رقم الموبيل 2"
        'GridView3.Columns(38).Caption = "الرقم القومي"
        'GridView3.Columns(39).Caption = "تاريخ الميلاد"
        'GridView3.Columns(40).Caption = "الايميل"


        GridView3.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub customer_license_info(customer_code)
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "select * from BD_personal_license_info where customer_code = '" & customer_code & "'"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)

        GridView5.Columns(0).Caption = "كود"
        GridView5.Columns(1).Caption = "كود العميل"
        GridView5.Columns(2).Caption = "رقم الرخصة"
        GridView5.Columns(3).Caption = "وحدةالمرور"
        GridView5.Columns(4).Caption = "نوع الرخصة"
        GridView5.Columns(5).Caption = "تاريخ الاصدار"
        GridView5.Columns(6).Caption = "تاريخ الاتهاء"
        GridView5.Columns(7).Caption = "الرقم المطبوع"


        GridView5.Appearance.Row.Options.UseFont = True
        GridView5.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub


    Sub finance_info(code)

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "SELECT        dbo.BD_customer_finance_info.customer_code, dbo.BD_Bank.Name AS [Bank Name], dbo.BD_customer_finance_info.account_number, dbo.BD_customer_finance_info.swift_code, dbo.BD_customer_finance_info.IBAN, 
                         dbo.BD_customer_finance_info.currency
FROM            dbo.BD_customer_finance_info full JOIN
                         dbo.BD_Bank ON dbo.BD_customer_finance_info.bank_name = dbo.BD_Bank.Code where customer_code = '" & code & "'"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)

        GridView1.Columns(0).Caption = "كود العميل"
        GridView1.Columns(1).Caption = "اسم البنك"
        GridView1.Columns(2).Caption = "رقم الحساب"
        GridView1.Columns(3).Caption = "السوفت كود"
        GridView1.Columns(4).Caption = "IBAN"
        GridView1.Columns(5).Caption = "العملة"


        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Dim customer_code = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        Dim name = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        'acc no haven't a text to put in
        Dim customer_type = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))
        Dim city = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        Dim region = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))
        Dim sub_region = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(6))
        Dim akar = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))
        Dim shaka = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))
        Dim dor = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))


        Dim phone1 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10))
        Dim phone2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(11))
        Dim mobile1 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(12))
        Dim mobile2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(13))
        Dim email_work = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(14))
        Dim email_personal = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(15))
        Dim web_page = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(16))
        Dim sex = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(17))
        Dim nID = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(18))
        Dim nID_start = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(19))
        Dim nID_end = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(20))
        Dim print_no = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(21))
        Dim birthday = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(22))
        Dim social_state = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(23))

        Dim main_company = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(24))
        Dim sub_copmany = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(25))



        Dim file_tax = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(26))
        Dim no_reg_tax = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(27))
        Dim no_file_togary = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(28))
        Dim nameM = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(29))

        Dim job_name = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(30))
        Dim company_name = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(31))
        Dim work_address = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(32))
        Dim work_phone1 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(33))
        Dim work_phone2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(34))
        Dim no_inside = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(35))

        'Dim relative_name = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(34))
        'Dim relative_type = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(35))
        'Dim relative_phone1 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(36))
        'Dim relative_phone2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(37))
        'Dim relative_national_id = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(38))
        'Dim relative_birthdate = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(39))
        'Dim relative_email = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(40))

        viewCustomerRelatives(customer_code)


        If (customer_type.Equals("عميل")) Then
            Op2.Show()
            Op2.Select()
        ElseIf (customer_type.Equals("شركة")) Then
            Op1.Show()
            Op1.Select()
        End If


        txt_Code.Text = customer_code


        If Not IsDBNull(city) Then
            txt_City.Text = city

        End If
        If Not IsDBNull(region) Then
            Txt_RegionM.Text = region

        End If

        If Not IsDBNull(sub_region) Then
            Txt_RegionF.Text = sub_region

        End If
        ' Dim akarString As String = akar.ToString()
        If Not IsDBNull(akar) Then
            txt_Alkar.Text = akar

        End If
        ' Dim shakaString As String = shaka.ToString()
        If Not IsDBNull(shaka) Then
            txt_AlShka.Text = shaka

        End If


        If Not IsDBNull(dor) Then
            txt_alDor.Text = dor

        End If


        If Not IsDBNull(email_personal) Then
            txt_Email_Persone.Text = email_personal

        End If

        If Not IsDBNull(email_work) Then
            txt_Email_Work.Text = email_work

        End If

        If Not IsDBNull(mobile1) Then
            txt_Mobil1.Text = mobile1

        End If


        If Not IsDBNull(mobile2) Then
            txt_Mobil2.Text = mobile2

        End If


        If Not IsDBNull(name) Then
            txt_Name.Text = name

        End If
        If Not IsDBNull(nID) Then
            txt_NationalID.Text = nID

        End If


        If Not IsDBNull(phone1) Then
            txt_Phone1.Text = phone1

        End If


        If Not IsDBNull(phone2) Then
            txt_Phone2.Text = phone2

        End If


        If Not IsDBNull(web_page) Then
            txt_Website.Text = web_page

        End If


        If Not IsDBNull(sex) Then
            Com_Type.Text = sex

        End If



        If Not IsDBNull(print_no) Then
            txt_PrintNo.Text = print_no
        End If



        If Not IsDBNull(nID_start) Then
            txt_National_ID_Start.Value = nID_start

        End If




        If Not IsDBNull(nID_end) Then
            Txt_National_ID_End.Value = nID_end

        End If


        If Not IsDBNull(social_state) Then
            txt_state.Text = social_state

        End If


        If Not IsDBNull(birthday) Then
            txt_Birthdate.Value = birthday
        End If

        If Not IsDBNull(main_company) Then
            txt_btn_main_customer_company.Text = main_company
        End If

        If Not IsDBNull(sub_copmany) Then
            txt_btn_sub_customer_company.Text = sub_copmany
        End If





        If Not IsDBNull(job_name) Then

            cmd_JopName.Text = job_name
            txt_address_Work.Text = work_address
            txt_company_name.Text = company_name
            txt_PhoneWork1.Text = work_phone1
            If Not IsDBNull(work_phone2) Then
                txt_PhoneWork2.Text = work_phone2
            End If
            txt_NoInsied.Text = no_inside
            TabPane2.SelectedPageIndex = 0

        End If


        If Not IsDBNull(file_tax) Then

            txt_FileNo_Tax.Text = file_tax
            txt_NoFileTogary.Text = no_file_togary
            txt_NoReg_Tax.Text = no_reg_tax
            txt_responsible_NameM.Text = nameM
            TabPane2.SelectedPageIndex = 4
        End If

        finance_info(customer_code)
        passport_info(customer_code)
        customer_license_info(customer_code)
        'If Not IsDBNull(relative_name) Then
        '    txt_relative_name.Text = relative_name
        'End If
        'If Not IsDBNull(relative_type) Then
        '    txt_relative_types.Text = relative_type
        'End If
        'If Not IsDBNull(relative_phone1) Then
        '    txt_relative_phone1.Text = relative_phone1
        'End If
        'If Not IsDBNull(relative_phone2) Then
        '    txt_relative_phone2.Text = relative_phone2

        'End If
        'If Not IsDBNull(relative_national_id) Then
        '    txt_relative_national_id.Text = relative_national_id
        'End If
        'If Not IsDBNull(relative_email) Then
        '    txt_relative_email.Text = relative_email
        'End If
        'If Not IsDBNull(relative_birthdate) Then
        '    relative_birthDate_txt.Value = relative_birthdate
        'End If






        TabPane1.SelectedPageIndex = 0



    End Sub





    Private Sub cmd_Update_Click(sender As Object, e As EventArgs) Handles cmd_Update.Click

        update_customer()
        clear()

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click

        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "select * from BD_insurance_doucument where customer_name LIke  N'%" & txt_Name.Text & "%'"
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("هذا العميل مرتبط بوثيقة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql2 = "Delete From St_CustomerData2
Where Customer_Code = '" & txt_Code.Text & "'
"
        Cnn.Execute(sql2)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_custmer()


    End Sub

    Private Sub SimpleButton23_Click(sender As Object, e As EventArgs) Handles SimpleButton23.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "SELECT * FROM BD_JOBNAMES where Name ='" & cmd_JopName.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then var_codeItem = rs3("code").Value


        sql2 = "insert into BD_Customer_work_info values

                ('" & txt_Code.Text & "' , '" & var_codeItem & "' , '" & txt_company_name.Text & "' , '" & txt_address_Work.Text & "' , '" & txt_PhoneWork1.Text & "' , '" & txt_PhoneWork2.Text & "' , '" & txt_NoInsied.Text & "')"

        Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")


    End Sub

    Private Sub btn_save_finance_Click(sender As Object, e As EventArgs) Handles btn_save_finance.Click

        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "Select *  FROM BD_Bank where Name ='" & txt_state.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcode_item = rs3("code").Value

        sql = "insert into BD_customer_finance_info values ('" & txt_Code.Text & "','" & varcode_item & "' , '" & txt_NoAccountBank.Text & "' , '" & txt_SoftCode.Text & "' , '" & txt_Iban.Text & "','" & txt_curr.Text & "')"
        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        'clear()
        finance_info(txt_Code.Text)
    End Sub

    Private Sub Cmd_BankName_EditValueChanged(sender As Object, e As EventArgs) Handles Cmd_BankName.ButtonClick
        vartable = "BD_Bank"
        VarOpenlookup = 194
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

    End Sub

    Private Sub btn_add_bank_name_Click(sender As Object, e As EventArgs) Handles btn_add_bank_name.Click
        vartable = "BD_Bank"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Mef
        Frm_GenralData.Text = "أكواد البنك "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_delete_finance_info_Click(sender As Object, e As EventArgs) Handles btn_delete_finance_info.Click
        If Len(txt_NoAccountBank.Text) = 0 Then MsgBox("من فضلك اختار حساب من الاسفل  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "delete  from BD_customer_finance_info where account_number = '" & txt_NoAccountBank.Text & "'"
        Cnn.Execute(sql)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        If Len(txt_Code.Text) <> 0 Then
            finance_info(txt_Code.Text)
        End If
        clear()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim customer_code = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim bank_name = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim account_no = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim soft_code = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim iban = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Dim cuurency = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))

        txt_Code.Text = customer_code
        txt_NoAccountBank.Text = account_no
        Cmd_BankName.Text = bank_name
        txt_SoftCode.Text = soft_code
        txt_Iban.Text = iban
        txt_curr.Text = cuurency

    End Sub



    Private Sub txt_wehdet_mror_EditValueChanged(sender As Object, e As EventArgs) Handles txt_wehdet_mror1.ButtonClick
        vartable = "BD_WAHDT_MROR"
        VarOpenlookup = 191
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_wehdt_mror_Click(sender As Object, e As EventArgs) Handles btn_new_wehdt_mror.Click
        vartable = "BD_WAHDT_MROR"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد وحدات المرور "
        Frm_GenralData.Show()
    End Sub

    Private Sub cmd_save2_Click(sender As Object, e As EventArgs) Handles cmd_save2.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "Update St_CustomerData2 set Customer_FileNoTax = '" & txt_FileNo_Tax.Text & "' , 
            Customer_NoReg_Tax = '" & txt_NoReg_Tax.Text & "' ,  Customer_NoFileTogary = '" & txt_NoFileTogary.Text & "' ,  Customer_NameM =  '" & txt_responsible_NameM.Text & "' 
              where Customer_Code = '" & txt_Code.Text & "'  "

        Cnn.Execute(sql)

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        clear()
        find_custmer()
    End Sub



    Private Sub btn_save_passport_Click(sender As Object, e As EventArgs) Handles btn_save_passport.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        Dim dd As DateTime = txt_start_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================
        Dim dd2 As DateTime = txt_end_date.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")

        Dim dd3 As DateTime = passport_stayed_end_date.Value
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")
        sql = "insert into BD_passport_info values('" & txt_Code.Text & "' , '" & txt_passport_no.Text & "' , '" & txt_country_code.Text & "' , '" & txt_passport_type.Text & "' , '" & vardate1 & "' , '" & vardate2 & "' , '" & txt_military_service.Text & "' , '" & txt_fesh_paper.Text & "','" & vardate3 & "')"

        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        If Len(txt_Code.Text) <> 0 Then
            passport_info(txt_Code.Text)

        End If
        clear()

    End Sub

    Private Sub btn_delete_passport_Click(sender As Object, e As EventArgs) Handles btn_delete_passport.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار حساب من الاسفل  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "delete  from BD_passport_info where customer_code = '" & txt_Code.Text & "'"
        Cnn.Execute(sql)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        If Len(txt_Code.Text) <> 0 Then
            passport_info(txt_Code.Text)

        End If
        clear()
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView7.FocusedRowHandle
        Dim id = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(0))
        Dim customer_code = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(1))
        Dim passport_no = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(2))
        Dim country_code = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(3))
        Dim passport_type = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(4))
        Dim start_date = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(5))
        Dim end_date = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(6))
        Dim military_service = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(7))
        Dim fesh_paper = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(8))
        Dim stayed_end = GridView7.GetRowCellValue(visibleRowHandle, GridView7.Columns(9))


        'txt_Code.Text = customer_code
        'txt_passport_no.Text = passport_no
        'txt_country_code.Text = country_code
        'txt_passport_type.Text = passport_type
        'txt_start_date.Text = start_date

        'txt_end_date.Value = end_date
        'txt_military_service.Text = military_service
        'txt_fesh_paper.Text = fesh_paper
        'passport_stayed_end_date.Value = stayed_end
        If Not IsDBNull(customer_code) Then
            txt_Code.Text = customer_code
        End If

        If Not IsDBNull(passport_no) Then
            txt_passport_no.Text = passport_no
        End If

        If Not IsDBNull(country_code) Then
            txt_country_code.Text = country_code
        End If

        If Not IsDBNull(passport_type) Then
            txt_passport_type.Text = passport_type
        End If

        If Not IsDBNull(start_date) Then
            txt_start_date.Text = start_date
        End If

        If Not IsDBNull(end_date) Then
            txt_end_date.Value = end_date
        End If

        If Not IsDBNull(military_service) Then
            txt_military_service.Text = military_service
        End If

        If Not IsDBNull(fesh_paper) Then
            txt_fesh_paper.Text = fesh_paper
        End If

        If Not IsDBNull(stayed_end) Then
            passport_stayed_end_date.Value = stayed_end
        End If

    End Sub



    Private Sub passport_info(code)

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "	 select * from BD_passport_info where customer_code = '" & code & "'"


        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)



        GridView7.Appearance.Row.Font = New Font(GridView7.Appearance.Row.Font, FontStyle.Bold)




        GridView7.Appearance.Row.Options.UseFont = True

        GridView7.Columns(1).Caption = "كود العميل"
        GridView7.Columns(2).Caption = "رقم الباسبور"
        GridView7.Columns(3).Caption = "كود البلد"
        GridView7.Columns(4).Caption = "نوع الباسبور"
        GridView7.Columns(5).Caption = "تاريخ الاصدار"
        GridView7.Columns(6).Caption = "تاريخ الانتهاء"
        GridView7.Columns(7).Caption = "الخدمة العسكرية"
        GridView7.Columns(8).Caption = "الحالة الجنائية"
        GridView7.Columns(9).Caption = "تاريخ الانتهاء الاقامة"




        GridView7.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub btn_save_license_Click_1(sender As Object, e As EventArgs) Handles btn_save_license.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As Date = txt_license_start_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd3 As Date = txt_license_end_date.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-dd-yyyy")



        sql = "select * from BD_personal_license_info where Customer_Code ='" & txt_Code.Text & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("من فضلك تكرار الرخصة لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "insert into BD_personal_license_info values('" & txt_Code.Text & "','" & txt_license_no.Text & "' ,'" & txt_wehdet_mror1.Text & "' , '" & txt_license_type.Text & "' , 
            '" & vardate & "' ,'" & vardate2 & "' , '" & txt_print_no_license.Text & "')"

        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        clear()
        If Len(txt_Code.Text) <> 0 Then
            customer_license_info(txt_Code.Text)

        End If

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        Dim id = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Dim customer_code = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        Dim license_no = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        Dim wehdt_mror = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))
        Dim license_type = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(4))
        Dim start_date = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(5))
        Dim end_date = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(6))
        Dim print_no = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(7))


        'txt_Code.Text = customer_code
        'txt_license_no.Text = license_no
        'txt_license_type.Text = license_type
        'txt_wehdet_mror1.Text = wehdt_mror
        'txt_license_start_date.Value = start_date
        'txt_license_end_date.Text = end_date
        'txt_print_no_license.Text = print_no
        If Not IsDBNull(customer_code) Then
            txt_Code.Text = customer_code
        End If

        If Not IsDBNull(license_no) Then
            txt_license_no.Text = license_no
        End If

        If Not IsDBNull(license_type) Then
            txt_license_type.Text = license_type
        End If

        If Not IsDBNull(wehdt_mror) Then
            txt_wehdet_mror1.Text = wehdt_mror
        End If

        If Not IsDBNull(start_date) Then
            txt_license_start_date.Value = start_date
        End If

        If Not IsDBNull(end_date) Then
            txt_license_end_date.Text = end_date
        End If

        If Not IsDBNull(print_no) Then
            txt_print_no_license.Text = print_no
        End If





    End Sub

    Private Sub btn_delete_license_Click(sender As Object, e As EventArgs) Handles btn_delete_license.Click
        If Len(txt_license_no.Text) = 0 Then MsgBox("من فضلك اختر رقم رخصة العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "delete from BD_personal_license_info where license_no = '" & txt_license_no.Text & "'"

        Cnn.Execute(sql)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        If Len(txt_Code.Text) <> 0 Then
            customer_license_info(txt_Code.Text)

        End If
        clear()

    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged
        TabNavigationPage4.Enabled = False
    End Sub

    Private Sub Op1_CheckedChanged(sender As Object, e As EventArgs) Handles Op1.CheckedChanged
        TabNavigationPage4.Enabled = True

    End Sub


    Private Sub cmd_JopName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles cmd_JopName.ButtonClick
        vartable = "BD_JOBNAMES"
        VarOpenlookup = 192
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged

    End Sub

    Private Sub LabelX25_Click(sender As Object, e As EventArgs) Handles LabelX25.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txt_relative_phone2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txt_relative_email.TextChanged

    End Sub

    Private Sub btn_save_relatives_Click(sender As Object, e As EventArgs) Handles btn_save_relatives.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_relative_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_relative_types.Text) = 0 Then MsgBox("من فضلك ادخل صلة القرابة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'sql = "select * from BD_Customer_Relative where customer_code = '" & txt_Code.Text & "'"
        'rs3 = Cnn.Execute(sql)
        'If rs3.EOF = False Then MsgBox(" هذاالعميل موجود بالفعل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        Dim dd As DateTime = relative_birthDate_txt.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")

        sql = "insert into BD_Customer_Relative
            values('" & txt_Code.Text & "' , '" & txt_relative_name.Text & "' , '" & txt_relative_types.Text & "' , '" & txt_relative_phone1.Text & "','" & txt_relative_phone2.Text & "','" & txt_relative_national_id.Text & "','" & vardate1 & "','" & txt_relative_email.Text & "')"

        Cnn.Execute(sql)



        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        last_Data()
        clear()
        find_custmer()
    End Sub

    Private Sub btn_edit_relative_Click(sender As Object, e As EventArgs) Handles btn_edit_relative.Click

        Dim dd As DateTime = relative_birthDate_txt.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")

        sql = "update BD_Customer_Relative set name = '" & txt_relative_name.Text & "' , relative_type = '" & txt_relative_types.Text & "' , phone1 = '" & txt_relative_phone1.Text & "',
                phone2 = '" & txt_relative_phone2.Text & "' , national_id = '" & txt_relative_national_id.Text & "' ,birthdate = '" & vardate1 & "',email = '" & txt_relative_email.Text & "'
                where customer_code ='" & txt_Code.Text & "'"


        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        Cnn.Execute(sql)

        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_custmer()
    End Sub

    Private Sub btn_delete_relative_Click(sender As Object, e As EventArgs) Handles btn_delete_relative.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql2 = "Delete From BD_Customer_Relative
Where Customer_Code = '" & txt_Code.Text & "'
"
        Cnn.Execute(sql2)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_custmer()
    End Sub

    Private Sub Txt_RegionM_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_RegionM.EditValueChanged

    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick
        Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle

        Dim relative_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(2))
        Dim relative_type = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(3))
        Dim relative_phone1 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(4))
        Dim relative_phone2 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(5))
        Dim relative_national_id = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(6))
        Dim relative_birthdate = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(7))
        Dim relative_email = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(8))

        If Not IsDBNull(relative_name) Then
            txt_relative_name.Text = relative_name
        End If
        If Not IsDBNull(relative_type) Then
            txt_relative_types.Text = relative_type
        End If
        If Not IsDBNull(relative_phone1) Then
            txt_relative_phone1.Text = relative_phone1
        End If
        If Not IsDBNull(relative_phone2) Then
            txt_relative_phone2.Text = relative_phone2

        End If
        If Not IsDBNull(relative_national_id) Then
            txt_relative_national_id.Text = relative_national_id
        End If
        If Not IsDBNull(relative_email) Then
            txt_relative_email.Text = relative_email
        End If
        If Not IsDBNull(relative_birthdate) Then
            relative_birthDate_txt.Value = relative_birthdate
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        vartable = "BD_SOCIALSTATUS"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الحالة الاجتماعية "
        Frm_GenralData.Show()
    End Sub

    Private Sub txt_btn_main_customer_company_EditValueChanged(sender As Object, e As EventArgs) Handles txt_btn_main_customer_company.Click
        vartable = "BD_customer_main_company"
        VarOpenlookup = 205
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_btn_sub_customer_company_EditValueChanged(sender As Object, e As EventArgs) Handles txt_btn_sub_customer_company.Click
        vartable = "BD_customer_sub_company"
        VarOpenlookup = 206
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_main_company_Click(sender As Object, e As EventArgs) Handles btn_new_main_company.Click
        vartable = "BD_customer_main_company"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "الشركات الرئيسية "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_new_sub_company_Click(sender As Object, e As EventArgs) Handles btn_new_sub_company.Click
        vartable = "BD_customer_sub_company"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " الشركات الفرعية "
        Frm_GenralData.Show()
    End Sub

    Private Sub txt_curr_EditValueChanged(sender As Object, e As EventArgs) Handles txt_curr.ButtonClick
        vartable = "BD_Currency"
        VarOpenlookup = 208
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        vartable = "BD_JOBNAMES"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الوظيفة "
        Frm_GenralData.Show()
    End Sub

    Private Sub txt_state_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_state.ButtonClick
        vartable = "BD_SOCIALSTATUS"
        VarOpenlookup = 1920
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_state_EditValueChanged(sender As Object, e As EventArgs) Handles txt_state.EditValueChanged
        'BD_SOCIALSTATUS()

    End Sub

    Private Sub cmd_New_Click_1(sender As Object, e As EventArgs) Handles cmd_New.Click
        clear()
        last_Data()
        Op1.Show()
        Op2.Show()

    End Sub
    Sub clear()
        txt_Code.Text = ""
        txt_address_Work.Text = ""
        txt_alDor.Text = ""
        txt_Alkar.Text = ""
        txt_AlShka.Text = ""
        txt_City.Text = ""
        txt_codeEmp2.Text = ""
        txt_Email_Persone.Text = ""
        txt_Email_Work.Text = ""
        txt_FileNo_Tax.Text = ""
        txt_Iban.Text = ""
        txt_Mobil1.Text = ""
        txt_Mobil2.Text = ""
        txt_Name.Text = ""
        txt_state.Text = ""
        txt_NationalID.Text = ""
        txt_NoAccountBank.Text = ""
        txt_NoFileTogary.Text = ""
        txt_NoInsied.Text = ""
        txt_NoReg_Tax.Text = ""
        txt_Phone1.Text = ""
        txt_Phone2.Text = ""
        txt_PrintNo.Text = ""
        Txt_RegionF.Text = ""
        Txt_RegionM.Text = ""
        txt_SoftCode.Text = ""
        txt_Website.Text = ""
        'Com_Code.Text = ""
        Com_Type.Text = ""
        Cmd_BankName.Text = ""
        txt_Iban.Text = ""
        txt_SoftCode.Text = ""
        txt_NoAccountBank.Text = ""
        txt_curr.Text = ""
        txt_license_no.Text = ""
        txt_license_type.Text = ""
        txt_wehdet_mror1.Text = ""
        txt_print_no_license.Text = ""
        txt_responsible_NameM.Text = ""

    End Sub
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Customer_Code) AS MaxmamNo FROM  St_CustomerData2    HAVING (MAX(Customer_Code) IS NOT NULL) "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_Code.Text = rs3("MaxmamNo").Value + 1
        Else
            txt_Code.Text = 1
            clear()

        End If
    End Sub

    Private Sub cmd_Save_Click(sender As Object, e As EventArgs) Handles cmd_Save.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اضغط جديد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Name.Text) = 0 Then MsgBox("من فضلك ادخل أسم العميل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_City.Text) = 0 Then MsgBox("من فضلك ادخل البلد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_RegionM.Text) = 0 Then MsgBox("من فضلك المحافظة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_RegionM.Text) = 0 Then MsgBox("من فضلك ادخل  المنطقة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_NationalID.Text) = 0 Then MsgBox("من فضلك ادخل  رقم البطاقة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_Mobil1.Text) = 0 Then MsgBox("من فضلك ادخل  رقم الهاتف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '============================================
        Dim dd As DateTime = txt_National_ID_Start.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================
        Dim dd2 As DateTime = Txt_National_ID_End.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================
        Dim dd3 As DateTime = txt_Birthdate.Value
        Dim vardate3 As String
        vardate3 = dd3.ToString("MM-d-yyyy")


        '==================================================================================Stats
        sql = "Select *  FROM BD_SOCIALSTATUS where Name ='" & txt_state.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodestat = rs3("code").Value
        '===================================================================================== city
        sql = "SELECT *  FROM BD_CITIES where Name ='" & txt_City.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcitycode = rs3("code").Value
        '========================================================Region
        sql = "SELECT *  FROM BD_REGION where Name ='" & Txt_RegionM.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcoderegion1 = rs3("code").Value
        '================================================================Region2
        sql = "SELECT *  FROM BD_SUB_REGIONS where Name ='" & Txt_RegionF.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcoderegion2 = rs3("code").Value


        '======================================================jopname
        'sql = "SELECT *  FROM BD_JOBNAMES where Name ='" & cmd_JopName.Text & "'   "
        'rs3 = Cnn.Execute(sql)
        'If rs3.EOF = False Then VARCODEJOBNAMES = rs3("code").Value




        sql = "select * from St_CustomerData2 where Customer_Code ='" & txt_Code.Text & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("من فضلك أسم العميل تكرار لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        If Op1.Checked = True Then vartype_customer = 1 ' company
        If Op2.Checked = True Then vartype_customer = 0 'customer
        'If Op1.Checked = True Then vartype_customer = 3
        'If Op2.Checked = True Then vartype_customer = 4
        'If Op1.Checked = True Then vartype_customer = 5
        'If Op2.Checked = True Then vartype_customer = 6

        'Reson_trmention='" & Txt_reson.Text   & "'

        sql = "INSERT INTO St_CustomerData2 (Customer_Code,Customer_Name,Customer_Type,Code_City,Code_Region_M,Code_Region2,Al_Akar,Al_Dor,Al_Shak,Customer_Phon1,Customer_Phon2,Customer_Mobil1,Customer_Mobil2,Customer_Email_Work,Customer_Email_Persone,Customer_Website,Customer_Type_sex,Customer_State,Customer_NationalID,National_ID_Start,National_ID_End,Print_No,Birthday,Customer_FileNoTax,Customer_NoReg_Tax,Customer_NoFileTogary,Customer_NameM , main_company , sub_company) " &
            " values  (" & txt_Code.Text & " ,N'" & txt_Name.Text & "',N'" & vartype_customer & "',N'" & varcitycode & "',N'" & varcoderegion1 & "'  " &
            " ,N'" & varcoderegion2 & "',N'" & txt_Alkar.Text & "',N'" & txt_alDor.Text & "',N'" & txt_AlShka.Text & "',N'" & txt_Phone1.Text & "','" & txt_Phone2.Text & "',N'" & txt_Mobil1.Text & "',N'" & txt_Mobil2.Text & "',N'" & txt_Email_Work.Text & "',N'" & txt_Email_Persone.Text & "',N'" & txt_Website.Text & "',N'" & Com_Type.Text & "',N'" & varcodestat & "',N'" & txt_NationalID.Text & "',N'" & vardate1 & "',N'" & vardate2 & "',N'" & txt_PrintNo.Text & "',N'" & vardate3 & "',N'" & txt_FileNo_Tax.Text & "',N'" & txt_NoReg_Tax.Text & "',N'" & txt_NoFileTogary.Text & "',N'" & txt_responsible_NameM.Text & "' , '" & txt_btn_main_customer_company.Text & "' , '" & txt_btn_sub_customer_company.Text & "')"
        Cnn.Execute(sql)


        '==========================insertChartofaccount
        '        sql = "INSERT INTO ST_CHARTOFACCOUNT (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
        '" values  (N'" & 3 & "' ,N'" & txt_accountNo.Text & "',N'" & txt_accountNo.Text & "',N'" & varaccountnomain & "',N'" & Txt_EmpName.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_accountNo.Text + "-" + Txt_EmpName.Text & "',N'" & txt_accountNo.Text & "','" & VarCodeCompny & "')"
        '        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'Find()
        'Find_all_EMP()
        last_Data()
        clear()
        find_custmer()
        End Sub

    Private Sub update_customer()


        '==================================================================================Stats
        sql = "Select *  FROM BD_SOCIALSTATUS where Name ='" & txt_state.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodestat = rs3("code").Value
        '===================================================================================== city
        sql = "SELECT *  FROM BD_CITIES where Name ='" & txt_City.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcitycode = rs3("code").Value
        '========================================================Region
        sql = "SELECT *  FROM BD_REGION where Name ='" & Txt_RegionM.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcoderegion1 = rs3("code").Value
        '================================================================Region2
        sql = "SELECT *  FROM BD_SUB_REGIONS where Name ='" & Txt_RegionF.Text & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcoderegion2 = rs3("code").Value

        If Op1.Checked = True Then vartype_customer = 1 ' company
        If Op2.Checked = True Then vartype_customer = 0 'customer

        sql = "

        update St_CustomerData2
        set Customer_Name = '" & txt_Name.Text & "' , Customer_Type = '" & vartype_customer & "' , Code_City = '" & varcitycode & "' , Code_Region_M = '" & varcoderegion1 & "' , Code_Region2 = '" & varcoderegion2 & "' ,
        Al_Akar = '" & txt_Alkar.Text & "' , Al_Dor = '" & txt_alDor.Text & "' , Al_Shak = '" & txt_AlShka.Text & "' , Customer_Phon1 = '" & txt_Phone1.Text & "' , Customer_Phon2 = '" & txt_Phone2.Text & "' , Customer_Mobil1 = '" & txt_Mobil1.Text & "' ,
        Customer_Mobil2 = '" & txt_Mobil2.Text & "' , Customer_Email_Work = '" & txt_Email_Work.Text & "' , Customer_Email_Persone = '" & txt_Email_Persone.Text & "' , Customer_Website = '" & txt_Website.Text & "' , 
        Customer_State = '" & varcodestat & "' , Print_No = '" & txt_PrintNo.Text & "' , main_company = '" & txt_btn_main_customer_company.Text & "' , sub_company = '" & txt_btn_sub_customer_company.Text & "'
        where Customer_Code = '" & txt_Code.Text & "'


"

        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك اختار عميل من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        Cnn.Execute(sql)

        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_custmer()
    End Sub

    Function count_in_customer(sqll)
        Dim no As Int32 = 0
        sql = sqll

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then no = rs3("numbers").Value

        Return no

    End Function

    Private Sub viewCustomerRelatives(cust_code)
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql = "select * from vw_all_customer_relatives where [كود العميل] = '" & cust_code & "'"
        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)



        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)




        GridView9.Appearance.Row.Options.UseFont = True






        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

End Class