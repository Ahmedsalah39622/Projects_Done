Option Infer On

Imports System.Data.OleDb
Imports System.Data



'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.CodeParser
Imports CrystalDecisions.[Shared].Json





Public Class Frm_Car

    Private Sub btn_edart_mror_Click(sender As Object, e As EventArgs) Handles btn_edart_mror.Click
        vartable = "BD_EDARAT_ELMROR"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد ادارات المرور"
        Frm_GenralData.Show()
    End Sub

    Private Sub ButtonEdit_edart_mror_EditValueChanged(sender As Object, e As EventArgs) Handles btn_edart_mror_txt.ButtonClick
        vartable = "BD_EDARAT_ELMROR"
        VarOpenlookup = 193
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        vartable = "BD_WAHDT_MROR"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد وحدات المرور "
        Frm_GenralData.Show()
    End Sub

    Private Sub ButtonEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles btn_edit_wehdet_mror.ButtonClick
        vartable = "BD_WAHDT_MROR"
        VarOpenlookup = 191
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        insert_data(txt_wasyka_no.Text)

    End Sub


    Private Sub insert_data(wasyka)

        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشاسيه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_plate_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم رقم اللوحة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_car_model.Text) = 0 Then MsgBox("من فضلك ادخل موديل السيارة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_car_brand_btn.Text) = 0 Then MsgBox("من فضلك ادخل ماركة السيارة  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_model_year.Text) = 0 Then MsgBox("من فضلك ادخل سنة الصنع  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_motor_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الموتور  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As Date = liesence_start_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-dd-yyyy")
        '==============================================
        Dim dd3 As Date = lisence_end_date.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-dd-yyyy")

        sql = "select * from BD_cars_info where shasyeh_no = '" & txt_shaseh_no.Text & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("من فضلك رقم الشاسيه تكرر لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "
            insert into BD_cars_info values('" & txt_car_brand_btn.Text & "','" & txt_car_model.Text & "','" & txt_model_year.Text & "','" & txt_color.Text & "','" & txt_shaseh_no.Text & "' ,
            '" & txt_motor_no.Text & "','" & txt_plate_no.Text & "', '" & txt_car_design.Text & "','" & btn_edart_mror_txt.Text & "', '" & btn_edit_wehdet_mror.Text & "' , 
            '" & vardate & "','" & vardate2 & "' , '" & txt_t2men_egbary.Text & "' , '" & wasyka & "','" & txt_liter_capacity.Text & "' , '" & fuel_type.Text & "' , '" & cylinders_no.Text & "' , '" & txt_passengers_no.Text & "' , '" & sla7ya_txt.Text & "', '" & btn_customer_name_txt.Text & "' , '" & txt_more_info.Text & "')     
        "

        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()
        clear()
    End Sub

    Private Sub btn_edit_wehdet_mror_EditValueChanged(sender As Object, e As EventArgs) Handles btn_edit_wehdet_mror.EditValueChanged
    End Sub

    Private Sub save_inspection_info()
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشاسيه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As Date = txt_inspection_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-d-yyyy")

        sql = "insert into BD_inspection_info values('" & vardate & "','" & txt_eng_name.Text & "' , '" & txt_exceptions.Text & "',
        '" & txt_homola.Text & "' , '" & txt_additional_service.Text & "' , '" & txt_state.Text & "' , '" & txt_service_provider.Text & "', '" & txt_inspection_report.Text & "' , '" & txt_box.Text & "' , '" & txt_fridge.Text & "' , '" & txt_shaseh_no.Text & "' , '" & txt_other_mol7k.Text & "')"

        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()

        clear()

    End Sub

    Private Sub btn_save_inspection_info_Click(sender As Object, e As EventArgs) Handles btn_save_inspection_info.Click
        save_inspection_info()

    End Sub

    Private Sub btn_update_inspection_info_Click(sender As Object, e As EventArgs) Handles btn_update_inspection_info.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشاسيه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As DateTime = txt_inspection_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-d-yyyy")

        sql = "update BD_inspection_info set inspction_date = '" & vardate & "' , eng_name = '" & txt_eng_name.Text & "', exceptions = '" & txt_exceptions.Text & "',
                homola = '" & txt_homola.Text & "' , additional_service = '" & txt_additional_service.Text & "' , state = '" & txt_state.Text & "' , service_provider = '" & txt_service_provider.Text & "' , 
                inspection_report = '" & txt_inspection_report.Text & "' , box = '" & txt_box.Text & "' , fridge = '" & txt_fridge.Text & "' , ohters = '" & txt_other_mol7k.Text & "'
                where shasyeh_no = '" & txt_shaseh_no.Text & "'"

        Cnn.Execute(sql)
        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()
        clear()
    End Sub

    Private Sub carSearch()


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        '        sql2 = "	SELECT        dbo.BD_cars_info.ID, dbo.BD_cars_info.car_brand, dbo.BD_cars_info.car_model, dbo.BD_cars_info.car_model_year, dbo.BD_cars_info.color, dbo.BD_cars_info.shasyeh_no, dbo.BD_cars_info.motor_no, 
        '                         dbo.BD_cars_info.plate_no, dbo.BD_cars_info.car_design, dbo.BD_cars_info.edart_mror, dbo.BD_cars_info.wehdet_mror, dbo.BD_cars_info.license_start_date, dbo.BD_cars_info.license_end_date, 
        '                         dbo.BD_cars_info.t2men_egbary, dbo.BD_cars_info.liter_capacity, dbo.BD_cars_info.fuel_type, dbo.BD_cars_info.cyliner_no, dbo.BD_cars_info.passengers_no, 
        '                         dbo.BD_inspection_info.id AS inspection_id, dbo.BD_inspection_info.inspction_date, dbo.BD_inspection_info.eng_name, dbo.BD_inspection_info.exceptions, dbo.BD_inspection_info.homola, 
        '                         dbo.BD_inspection_info.additional_service, dbo.BD_inspection_info.state, dbo.BD_inspection_info.service_provider, dbo.BD_inspection_info.inspection_report, dbo.BD_inspection_info.box, dbo.BD_inspection_info.fridge, dbo.BD_cars_info.wasyka_no, dbo.BD_cars_info.Permissions
        'FROM            dbo.BD_cars_info LEFT OUTER JOIN
        '                         dbo.BD_inspection_info ON dbo.BD_cars_info.shasyeh_no = dbo.BD_inspection_info.shasyeh_no"

        sql2 = "select * from vw_all_cars_info"

        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)



        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)




        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "كود السيارة"
        GridView9.Columns(1).Caption = "الماركة"
        GridView9.Columns(2).Caption = "الموديل"
        GridView9.Columns(3).Caption = "سنة الصنع"
        GridView9.Columns(4).Caption = "اللون"
        GridView9.Columns(5).Caption = "رقم الشاسيه"
        GridView9.Columns(6).Caption = "رقم الموتور "
        GridView9.Columns(7).Caption = "رقم اللوحة"
        GridView9.Columns(8).Caption = "الشكل"
        GridView9.Columns(9).Caption = "ادارة المرور"
        GridView9.Columns(10).Caption = " وحدة المرور"
        GridView9.Columns(11).Caption = "اصدار الرخصة"
        GridView9.Columns(12).Caption = "انتهاء الرخصة"
        GridView9.Columns(13).Caption = "تامين اجباري"
        GridView9.Columns(14).Caption = "السعة اللترية"
        GridView9.Columns(15).Caption = "نوع الوقود"
        GridView9.Columns(16).Caption = "عدد السليندرات"
        GridView9.Columns(17).Caption = "عدد الركاب"
        GridView9.Columns(18).Caption = "كود المعاينة"
        GridView9.Columns(19).Caption = "تاريخ المعاينة"
        GridView9.Columns(20).Caption = "القائم على المعاينة"
        GridView9.Columns(21).Caption = "استثناءات"
        GridView9.Columns(22).Caption = " الحمولة"
        GridView9.Columns(23).Caption = "خدمات اضافية"
        GridView9.Columns(24).Caption = "الحالة"
        GridView9.Columns(25).Caption = "مقدم الخدمة"
        GridView9.Columns(26).Caption = "تقرير المعاينة"
        GridView9.Columns(27).Caption = "الصندوق"
        GridView9.Columns(28).Caption = "ثلالجة"
        GridView9.Columns(29).Caption = "رقم الوثيقة"
        GridView9.Columns(30).Caption = "الصلاحية"
        'GridView9.Columns(31).Caption = "اسم العميل"



        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub Frm_Car_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carSearch()

        license_ended_count.Text = cars_count("select count(*) as numbers from BD_cars_info 
            where license_end_date <= GETDATE()")
        all_cars_count.Text = cars_count("select count(*) as numbers from BD_cars_info ")
    End Sub

    Private Sub GridControl5_Click(sender As Object, e As EventArgs) Handles GridControl5.DoubleClick

        Dim visibleRowHandle As Integer = GridView9.FocusedRowHandle
        Dim car_brand = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(1))
        Dim car_model = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(2))
        Dim year = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(3))
        Dim color = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(4))
        Dim shaseh = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(5))
        Dim motor = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(6))
        Dim plate = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(7))
        Dim design = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(8))
        Dim edart_mror = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(9))
        Dim whdet_mror = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(10))


        Dim start_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(11))
        Dim end_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(12))
        Dim t2men = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(13))
        Dim liter = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(14))
        Dim fuel_type1 = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(15))
        Dim cylinder = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(16))
        Dim passenger_no = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(17))
        Dim inspection_date = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(19))
        Dim eng_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(20))
        Dim exception = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(21))
        Dim homola = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(22))
        Dim additional_services = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(23))
        Dim state = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(24))
        Dim provider = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(25))
        Dim report = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(26))
        Dim box = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(27))
        Dim fridge = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(28))
        Dim wasyka = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(29))
        Dim sla7ya = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(30))
        Dim customer_name = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(31))
        Dim more_info = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(32))
        Dim other_mol7k = GridView9.GetRowCellValue(visibleRowHandle, GridView9.Columns(33))



        tires_search(shaseh)


        'txt_car_brand_btn.Text = car_brand
        'txt_car_model.Text = car_model
        'txt_model_year.Text = year
        'txt_shaseh_no.Text = shaseh
        'txt_motor_no.Text = motor
        'txt_plate_no.Text = plate
        'txt_wasyka_no.Text = wasyka
        'sla7ya_txt.Text = sla7ya

        If Not IsDBNull(car_brand) Then
            txt_car_brand_btn.Text = car_brand
        End If

        If Not IsDBNull(car_model) Then
            txt_car_model.Text = car_model
        End If

        If Not IsDBNull(year) Then
            txt_model_year.Text = year
        End If

        If Not IsDBNull(shaseh) Then
            txt_shaseh_no.Text = shaseh
        End If

        If Not IsDBNull(motor) Then
            txt_motor_no.Text = motor
        End If

        If Not IsDBNull(plate) Then
            txt_plate_no.Text = plate
        End If

        If Not IsDBNull(wasyka) Then
            txt_wasyka_no.Text = wasyka
        End If

        If Not IsDBNull(sla7ya) Then
            sla7ya_txt.Text = sla7ya
        End If




        If Not IsDBNull(color) Then
            txt_color.Text = color


        End If
        If Not IsDBNull(design) Then
            txt_car_design.Text = design


        End If

        If Not IsDBNull(edart_mror) Then
            btn_edart_mror_txt.Text = edart_mror


        End If

        If Not IsDBNull(whdet_mror) Then
            btn_edit_wehdet_mror.Text = whdet_mror


        End If
        If Not IsDBNull(start_date) Then
            liesence_start_date.Value = start_date

        End If
        If Not IsDBNull(end_date) Then
            lisence_end_date.Value = end_date

        End If
        If Not IsDBNull(t2men) Then
            txt_t2men_egbary.Text = t2men

        End If
        If Not IsDBNull(liter) Then
            txt_liter_capacity.Text = liter

        End If

        If Not IsDBNull(fuel_type1) Then
            fuel_type.Text = fuel_type1

        End If
        If Not IsDBNull(cylinder) Then
            cylinders_no.Text = cylinder

        End If
        If Not IsDBNull(passenger_no) Then
            txt_passengers_no.Text = passenger_no

        End If
        If Not IsDBNull(customer_name) Then
            btn_customer_name_txt.Text = customer_name

        End If

        'If IsDBNull(report) Then
        '    TabPane1.SelectedPageIndex = 0
        '    Exit Sub

        'End If


        If Not IsDBNull(inspection_date) Then
            txt_inspection_date.Text = inspection_date
        End If

        If Not IsDBNull(eng_name) Then
            txt_eng_name.Text = eng_name
        End If

        If Not IsDBNull(state) Then
            txt_state.Text = state
        End If

        If Not IsDBNull(exception) Then
            txt_exceptions.Text = exception
        End If

        If Not IsDBNull(homola) Then
            txt_homola.Text = homola
        End If

        If Not IsDBNull(additional_services) Then
            txt_additional_service.Text = additional_services
        End If

        If Not IsDBNull(provider) Then
            txt_service_provider.Text = provider
        End If

        If Not IsDBNull(box) Then
            txt_box.Text = box
        End If

        If Not IsDBNull(fridge) Then
            txt_fridge.Text = fridge
        End If

        If Not IsDBNull(report) Then
            txt_inspection_report.Text = report
        End If

        If Not IsDBNull(more_info) Then
            txt_more_info.Text = more_info
        End If
        If Not IsDBNull(other_mol7k) Then
            txt_other_mol7k.Text = other_mol7k
        End If


        'txt_inspection_date.Text = inspection_date
        'txt_eng_name.Text = eng_name
        'txt_state.Text = state
        'txt_exceptions.Text = exception
        'txt_homola.Text = homola
        'txt_additional_service.Text = additional_services
        'txt_service_provider.Text = provider
        'txt_box.Text = box
        'txt_fridge.Text = fridge
        'txt_inspection_report.Text = report






        TabPane1.SelectedPageIndex = 0

    End Sub
    Private Sub clear()

        txt_car_brand_btn.Text = ""
        txt_car_model.Text = ""
        txt_model_year.Text = ""
        txt_color.Text = ""
        ' Dim akarString As String = akar.ToString()
        txt_shaseh_no.Text = ""
        ' Dim shakaString As String = shaka.ToString()
        txt_motor_no.Text = ""
        txt_plate_no.Text = ""
        txt_car_design.Text = ""
        btn_edart_mror_txt.Text = ""
        btn_edit_wehdet_mror.Text = ""
        liesence_start_date.Text = ""
        lisence_end_date.Text = ""
        txt_t2men_egbary.Text = ""
        txt_inspection_report.Text = ""
        ' txt_wasyka_no.Text = ""
        txt_liter_capacity.Text = ""
        fuel_type.Text = ""
        cylinders_no.Text = ""
        txt_passengers_no.Text = ""
        txt_inspection_date.Text = ""
        txt_eng_name.Text = ""
        txt_state.Text = ""
        txt_exceptions.Text = ""
        txt_homola.Text = ""
        txt_additional_service.Text = ""
        txt_service_provider.Text = ""
        txt_box.Text = ""
        txt_fridge.Text = ""
        txt_other_mol7k.Text = ""
        btn_customer_name_txt.Text = ""
        txt_more_info.Text = ""
        sla7ya_txt.Text = ""



    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If txt_wasyka_no.Text = "0" Then
            sql2 = "Delete From BD_cars_info
                Where shasyeh_no = '" & txt_shaseh_no.Text & "'"
            Cnn.Execute(sql2)
            MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Else
            MsgBox("هذه السيارة مرتبطة بوثيقة لا يمكن حذفها ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        End If
        carSearch()
        clear()

    End Sub

    Private Sub btn_delete_inspection_info_Click(sender As Object, e As EventArgs) Handles btn_delete_inspection_info.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql2 = "Delete From BD_inspection_info
Where shasyeh_no = '" & txt_shaseh_no.Text & "'
"
        Cnn.Execute(sql2)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()
        clear()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_plate_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As DateTime = liesence_start_date.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-d-yyyy")
        '==============================================
        Dim dd3 As DateTime = lisence_end_date.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-d-yyyy")


        sql = "update BD_cars_info set
            color = '" & txt_color.Text & "' , motor_no = '" & txt_motor_no.Text & "' , edart_mror = '" & btn_edart_mror_txt.Text & "' , wehdet_mror = '" & btn_edit_wehdet_mror.Text & "',
            license_start_date = '" & vardate & "' , license_end_date = '" & vardate2 & "', t2men_egbary = '" & txt_t2men_egbary.Text & "' , wasyka_no = '" & txt_wasyka_no.Text & "' , Permissions = '" & sla7ya_txt.Text & "' , customer_name = '" & btn_customer_name_txt.Text & "' , more_info = '" & txt_more_info.Text & "'
                where shasyeh_no = '" & txt_shaseh_no.Text & "' "

        Cnn.Execute(sql)
        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()
    End Sub

    Private Sub ButtonEdit_edart_mror_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles btn_edart_mror_txt.ButtonClick

    End Sub

    Private Sub txt_car_brand_btn_EditValueChanged(sender As Object, e As EventArgs) Handles txt_car_brand_btn.ButtonClick
        vartable = "BD_car_brands"
        VarOpenlookup = 199
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_car_brand_btn_EditValueChanged(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_car_brand_btn.ButtonClick

    End Sub

    Private Sub txt_car_model_EditValueChanged(sender As Object, e As EventArgs) Handles txt_car_model.ButtonClick
        vartable = "BD_cars_brand_model"
        VarOpenlookup = 200
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_car_brand_Click(sender As Object, e As EventArgs) Handles btn_new_car_brand.Click
        vartable = "BD_car_brands"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد انواع السيارات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_new_car_model_Click(sender As Object, e As EventArgs) Handles btn_new_car_model.Click
        vartable = " BD_cars_brand_model"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " مركات السيارات "
        Frm_GenralData.Show()
    End Sub

    Private Sub txt_wasyka_no_EditValueChanged(sender As Object, e As EventArgs) Handles txt_wasyka_no.ButtonClick
        vartable = "BD_insurance_doucument"
        VarOpenlookup = 201
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_move_to_document_Click(sender As Object, e As EventArgs) Handles btn_move_to_document.Click
        If txt_wasyka_no.Text = "0" Then MsgBox("من فضلك اختار وثيقة   ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Me.Close()
        Frm_Doucument.MdiParent = Mainmune2
        Frm_Doucument.Show()
        Frm_Doucument.find_document("select * from BD_insurance_doucument  where wasyka_no = '" & txt_wasyka_no.Text & "'")
        Frm_Doucument.TabPane1.SelectedPageIndex = 2

    End Sub


    Function cars_count(sqll)
        Dim no As Int32 = 0
        sql = sqll

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then no = rs3("numbers").Value

        Return no

    End Function

    Private Sub lisence_end_date_ValueChanged(sender As Object, e As EventArgs) Handles lisence_end_date.ValueChanged

    End Sub

    Private Sub liesence_start_date_ValueChanged(sender As Object, e As EventArgs) Handles liesence_start_date.ValueChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles prod_time.ValueChanged

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub save_button_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub save_button_Click_1(sender As Object, e As EventArgs) Handles save_button.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك ادخل رقم الشاسيه  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd4 As Date = prod_time.Value
        Dim vardate1 As String
        vardate1 = dd4.ToString("MM-d-yyyy")
        Dim dd5 As Date = end_time.Value
        Dim vardate2 As String
        vardate2 = dd5.ToString("MM-d-yyyy")

        sql = "insert into BD_tires values('" & tiretype.Text & "' , '" & vardate1 & "','" & vardate2 & "' , '" & Kilometer_number.Text & "','" & txt_shaseh_no.Text & "')"

        Cnn.Execute(sql)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        carSearch()

        clear()
    End Sub

    Private Sub tires_update_Click(sender As Object, e As EventArgs) Handles tires_update.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        Dim dd2 As DateTime = prod_time.Value
        Dim vardate As String
        vardate = dd2.ToString("MM-d-yyyy")
        '==============================================
        Dim dd3 As DateTime = end_time.Value
        Dim vardate2 As String
        vardate2 = dd3.ToString("MM-d-yyyy")


        sql = "update BD_tires
           set tires_type = '" & tiretype.Text & "' , product_date = '" & vardate & "' , end_date = '" & vardate2 & "' ,
            kilometer_number = '" & Kilometer_number.Text & "' 
                where shasyeh_no = '" & txt_shaseh_no.Text & "' "

        Cnn.Execute(sql)
        MsgBox("تم تعديل البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
    End Sub

    Private Sub GridControl5_Click_1(sender As Object, e As EventArgs) Handles GridControl5.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles delete_button.Click
        If Len(txt_shaseh_no.Text) = 0 Then MsgBox("من فضلك اختار سيارة من البحث  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        sql2 = "Delete From BD_tires
                Where shasyeh_no = '" & txt_shaseh_no.Text & "'"
        Cnn.Execute(sql2)
        MsgBox("تم حذف البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")



        clear()
    End Sub

    Private Sub tires_search(shasyeh)
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                  "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select * from vw_tires_info where vw_tires_info.[رقم الشاسيه] = '" & shasyeh & "'"



        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)



        GridView1.Appearance.Row.Options.UseFont = True






        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim tires_type = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim product_date = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim end_date = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim kilometerNumber = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))

        'tiretype.Text = tires_type
        'prod_time.Text = product_date
        'end_time.Text = end_date
        'Kilometer_number.Text = kilometerNumber

        If Not IsDBNull(tires_type) Then
            tiretype.Text = tires_type
        End If

        If Not IsDBNull(product_date) Then
            prod_time.Text = product_date
        End If

        If Not IsDBNull(end_date) Then
            end_time.Text = end_date
        End If

        If Not IsDBNull(kilometerNumber) Then
            Kilometer_number.Text = kilometerNumber
        End If


    End Sub

    Private Sub txt_car_design_EditValueChanged(sender As Object, e As EventArgs) Handles txt_car_design.ButtonClick
        vartable = "BD_car_design"
        VarOpenlookup = 207
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_new_design_Click(sender As Object, e As EventArgs) Handles btn_new_design.Click
        vartable = " BD_car_design"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " اشكال السيارات "
        Frm_GenralData.Show()
    End Sub

    Private Sub btn_customer_name_txt_EditValueChanged(sender As Object, e As EventArgs) Handles btn_customer_name_txt.ButtonClick
        vartable = "St_CustomerData2"
        VarOpenlookup = 197
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub btn_clear_all_Click(sender As Object, e As EventArgs) Handles btn_clear_all.Click
        clear()
    End Sub
End Class