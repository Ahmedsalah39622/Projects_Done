Imports System.Data.OleDb

Public Class Frm_expired_dates

    Dim reportcode As Int16 = 0
    Private Sub btn_ended_license_Click(sender As Object, e As EventArgs) Handles btn_ended_license.Click
        GridView9.Columns.Clear()
        reportcode = 1
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        GridView9.Appearance.Reset()

        sql = " select * from [vw_ended_personal_license]"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)


        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)

        GridView9.Columns(0).Caption = "كود العميل"
        GridView9.Columns(1).Caption = "اسم العميل"
        GridView9.Columns(2).Caption = "رقم الرخصة"
        GridView9.Columns(3).Caption = "وحدةالمرور"
        GridView9.Columns(4).Caption = "نوع الرخصة"
        GridView9.Columns(5).Caption = "تاريخ الاصدار"
        GridView9.Columns(6).Caption = "تاريخ الاتهاء"
        GridView9.Columns(7).Caption = "الرقم المطبوع"


        GridView9.Appearance.Row.Options.UseFont = True
        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing

        'GridView9.Appearance.Reset()
        con.Close()
        con.Dispose()

    End Sub

    Private Sub btn_ended_national_id_Click(sender As Object, e As EventArgs) Handles btn_ended_national_id.Click
        GridView9.Columns.Clear()
        reportcode = 2

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        'GridView9.Appearance.Reset()

        sql2 = "select * from [vw_ended_national_id]"



        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset 
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)


        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)

        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(0).Caption = "كود العميل"
        GridView9.Columns(1).Caption = "اسم العميل"
        GridView9.Columns(3).Caption = "رقم الحساب"
        GridView9.Columns(2).Caption = "نوع العميل"
        GridView9.Columns(4).Caption = "البلد"
        GridView9.Columns(5).Caption = "المحافظة"
        GridView9.Columns(6).Caption = "المنطقة"
        GridView9.Columns(7).Caption = "العقار"
        GridView9.Columns(8).Caption = "الدور"
        GridView9.Columns(9).Caption = "الشقة"
        GridView9.Columns(10).Caption = "هاتف 1"
        GridView9.Columns(11).Caption = "هاتف 2"
        GridView9.Columns(12).Caption = "محمول 1"
        GridView9.Columns(13).Caption = "محمول 2"
        GridView9.Columns(14).Caption = "ايميل العمل"
        GridView9.Columns(15).Caption = "ايميل شخصي"
        GridView9.Columns(16).Caption = "الموقع"
        GridView9.Columns(17).Caption = "النوع"
        GridView9.Columns(18).Caption = "رقم البطاقة"
        GridView9.Columns(19).Caption = "اصدار البطاقة"
        GridView9.Columns(20).Caption = "انتهاء البطاقة"
        GridView9.Columns(21).Caption = "الرقم المطبوع"
        GridView9.Columns(22).Caption = " تاريخ الميلاد"
        GridView9.Columns(26).Caption = "الحالة الاجتماعية"
        GridView9.Columns(24).Caption = "الملف الضريبي"
        GridView9.Columns(25).Caption = "السجل الضريبي"
        GridView9.Columns(23).Caption = "السجل التجاري"
        'GridView9.Columns(27).Caption = "المسئول"

        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub btn_ended_passport_Click(sender As Object, e As EventArgs) Handles btn_ended_passport.Click
        GridView9.Columns.Clear()
        reportcode = 3

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "select * from [vw_ended_passport]"


        'rs2 = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl5.DataSource = ds.Tables(0)



        GridView9.Appearance.Row.Font = New Font(GridView9.Appearance.Row.Font, FontStyle.Bold)

        GridView9.Appearance.Row.Options.UseFont = True

        GridView9.Columns(1).Caption = "كود العميل"
        GridView9.Columns(2).Caption = "رقم الباسبور"
        GridView9.Columns(3).Caption = "كود البلد"
        GridView9.Columns(4).Caption = "نوع الباسبور"
        GridView9.Columns(5).Caption = "تاريخ الاصدار"
        GridView9.Columns(6).Caption = "تاريخ الانتهاء"
        GridView9.Columns(7).Caption = "الخدمة العسكرية"
        GridView9.Columns(8).Caption = "الحالة الجنائية"

        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub btn_ended_document_Click(sender As Object, e As EventArgs) Handles btn_ended_document.Click
        reportcode = 4

        GridView9.Columns.Clear()

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = " select * from vw_ended_insurance_document"


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
        'GridView9.Columns(4).Caption = "تاريخ تحديد الوثيقة"
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
        'GridView9.Columns(16).Caption = "تحمل توكيل"
        'GridView9.Columns(17).Caption = "تحمل اجباري"
        'GridView9.Columns(18).Caption = "الحيازة"




        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub btn_ended_car_license_Click(sender As Object, e As EventArgs) Handles btn_ended_car_license.Click
        GridView9.Columns.Clear()
        reportcode = 5

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "select * from BD_cars_info 
where license_end_date <= GETDATE()"


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
        GridView9.Columns(10).Caption = " وحدةالمرور"
        GridView9.Columns(11).Caption = "اصدار الرخصة"
        GridView9.Columns(12).Caption = "انتهاء الرخصة"
        GridView9.Columns(13).Caption = "تامين اجباري"
        GridView9.Columns(14).Caption = "رقم الوثيقة"
        GridView9.Columns(15).Caption = "السعة اللترية"
        GridView9.Columns(16).Caption = "نوع الوقود"
        GridView9.Columns(17).Caption = "عدد السليندرات"
        GridView9.Columns(18).Caption = "عدد الركاب"
        GridView9.Columns(19).Caption = "الصلاحية"


        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub btn_doc_to_end_Click(sender As Object, e As EventArgs) Handles btn_doc_to_end.Click
        GridView9.Columns.Clear()
        reportcode = 6

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" &
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()




        sql2 = "select * FROM vw_document_goingTo_end"


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
        'GridView9.Columns(4).Caption = "تاريخ تحديد الوثيقة"
        'GridView9.Columns(5).Caption = "حالة الوثيقة"
        'GridView9.Columns(6).Caption = "المحفظة"
        'GridView9.Columns(7).Caption = "اسم شركة التأمين "
        'GridView9.Columns(8).Caption = "اسم العميل"
        'GridView9.Columns(9).Caption = "اسم الشركة الام"
        'GridView9.Columns(10).Caption = "مبلغ التغطية"
        'GridView9.Columns(11).Caption = " الصافي"
        'GridView9.Columns(12).Caption = "الاجمالي"
        'GridView9.Columns(13).Caption = "رقم الشاسيه"
        'GridView9.Columns(14).Caption = "تاريخ بدء التأمين"
        'GridView9.Columns(15).Caption = "تاريخ انتهاء التأمين"
        'GridView9.Columns(16).Caption = "تحمل توكيل"
        'GridView9.Columns(17).Caption = "تحمل اجباري"
        'GridView9.Columns(18).Caption = "الحيازة"


        GridView9.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btn_show_report.Click

        If reportcode = 0 Then
            MsgBox("من فضلك اختر التقرير  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")

            Exit Sub
        End If
        Insurance_reports.ShowReport(reportcode)
        Insurance_reports.Show()
    End Sub
End Class