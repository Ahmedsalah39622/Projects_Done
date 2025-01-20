Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Report_Produact
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim vardate As String
    Dim vardate2, vardatetest1, vardatetest2 As String
    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click

    End Sub

    Private Sub Frm_Report_Produact_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub Find_DayProdact()
        vardisplayReport = 101
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "select * from vw_MachinProdact where (dbo.vw_MachinProdact.JOBOrder_Date >= CONVERT(DATETIME,'" & vardate & "', 102)) AND (dbo.vw_MachinProdact.JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102))"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "الماكينة"
        GridView1.Columns(1).Caption = "الصنف"
        GridView1.Columns(2).Caption = "الكمية المنتجة"
        GridView1.Columns(3).Caption = "الوحدة"
        GridView1.Columns(4).Caption = "المرحلة"
        GridView1.Columns(5).Caption = "اسم العامل"
        GridView1.Columns(6).Caption = "الورية"

        GridView1.BestFitColumns()
        GridView1.Columns(7).Visible = False
        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(2).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
    Sub Find_Jop_Fill()
        vardisplayReport = 102
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()


        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "    SELECT        TOP (100) PERCENT dbo.TB_Header_JOB_Order.Order_NO, dbo.vw_AllJopOrderDatastatus.JOB_Order, dbo.vw_AllJopOrderDatastatus.JOBOrder_Date, dbo.TB_Header_OrderItem.NameCustomer_Compny, " & _
    "                         dbo.BD_Item.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid2, dbo.BD_Unit.Name AS Unit1, dbo.TB_Header_JOB_Order.Qyt_Requrid, BD_Unit_1.Name AS Unit2, dbo.vw_AllJopOrderDatastatus.Machin, " & _
    "                         dbo.vw_AllJopOrderDatastatus.NameItemFirst, dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_2.Name AS Unit3, dbo.vw_AllJopOrderDatastatus.statusJopOrder, " & _
    "        dbo.vw_AllJopOrderDatastatus.status, dbo.vw_AllJopOrderDatastatus.StoresStatus, dbo.vw_AllJopOrderDatastatus.PhasesName " & _
    " FROM            dbo.vw_AllJopOrderDatastatus INNER JOIN " & _
    "                         dbo.TB_Header_JOB_Order ON dbo.vw_AllJopOrderDatastatus.JOB_Order = dbo.TB_Header_JOB_Order.JOB_Order INNER JOIN " & _
    "                         dbo.BD_Item ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_Item.Code INNER JOIN " & _
    "                         dbo.TB_Header_OrderItem ON dbo.TB_Header_JOB_Order.Order_NO = dbo.TB_Header_OrderItem.Order_NO AND  " & _
    "                         dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Header_OrderItem.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit2 = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
    "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code INNER JOIN " & _
    "                         dbo.BD_Unit AS BD_Unit_2 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_2.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_2.Compny_Code " & _
    " GROUP BY dbo.TB_Header_JOB_Order.Order_NO, dbo.vw_AllJopOrderDatastatus.JOB_Order, dbo.vw_AllJopOrderDatastatus.JOBOrder_Date, dbo.TB_Header_OrderItem.NameCustomer_Compny, dbo.BD_Item.Name,  " & _
    "        dbo.TB_Header_JOB_Order.Qyt_Requrid2, dbo.BD_Unit.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid, BD_Unit_1.Name, dbo.vw_AllJopOrderDatastatus.Machin, dbo.vw_AllJopOrderDatastatus.NameItemFirst, " & _
    "        dbo.TB_Header_JOB_Order.Qyt_FristItem2, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_2.Name, dbo.vw_AllJopOrderDatastatus.statusJopOrder, dbo.vw_AllJopOrderDatastatus.status, " & _
    "        dbo.vw_AllJopOrderDatastatus.StoresStatus, dbo.vw_AllJopOrderDatastatus.PhasesName " & _
    " HAVING        (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.vw_AllJopOrderDatastatus.JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
    " ORDER BY dbo.vw_AllJopOrderDatastatus.JOBOrder_Date "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "أمر التوريد"
        GridView1.Columns(1).Caption = "أمر الشغل "
        GridView1.Columns(2).Caption = "تاريخ امر الشغل"
        GridView1.Columns(3).Caption = "العميل"
        GridView1.Columns(4).Caption = "اسم الصنف المطلوب"
        GridView1.Columns(5).Caption = "الكمية المطلوبة"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "الكمية المنتجة"
        GridView1.Columns(8).Caption = "الوحدة"
        GridView1.Columns(9).Caption = "الماكينة"
        GridView1.Columns(10).Caption = "اسم الصنف المنتج"
        GridView1.Columns(11).Caption = "الكمية "

        GridView1.Columns(14).Caption = "حالة امر الشغل"
        GridView1.Columns(15).Caption = "الفحص "
        GridView1.Columns(16).Caption = "المخزن "
        GridView1.Columns(17).Caption = "مرحلة الانتاج"


        GridView1.Columns(11).Visible = False
        GridView1.Columns(12).Visible = False


        GridView1.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        'GridView1.Columns(3).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Sub run_report()
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay
        vardatetest1 = "#" + vardate + "#"
        vardatetest2 = "#" + vardate2 + "#"

        If vardisplayReport = 103 Then 'الانتاج اليومى
            Dim report As New Report_ProdactDay
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel10.Text = txt_NameMachine.Text
            report.XrLabel35.Text = txt_NameShift.Text
            report.FilterString = "[Machine] Like '%" & txt_NameMachine.Text & "%' and [Shift] Like '%" & txt_NameShift.Text & "%'  and [JOBOrder_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 105 Then 'الفحص اليومي
            Dim report As New Produact_rol2
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            'report.XrLabel1.Text = txt_NameCustomer.Text
            'report.FilterString = "[Name] Like '%" & txt_NameCustomer.Text & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport = 101 Then 'الانتاج اليومى
            Dim report As New Daily_Prodaction
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel5.Text = txt_NameMachine.Text
            report.XrLabel32.Text = txt_NameShift.Text
            report.FilterString = "[Machin] Like '%" & txt_NameMachine.Text & "%' and [wardya] Like '%" & txt_NameShift.Text & "%'  and [JOBOrder_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport = 104 Then 'الانتاج اليومى
        


            Dim report As New Day_Prodact_Matiral
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            'report.XrLabel5.Text = txt_NameStores.Text
            'report.XrLabel32.Text = txt_nameItem.Text

            report.FilterString = " [JOBOrder_Date] Between(" & vardatetest1 & ", " & vardatetest2 & ")  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If
    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        vardisplayReport = 105
        run_report()

    End Sub

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        Find_Jop_Fill()
        vardisplayReport = 102
        run_report()
    End Sub

    

 

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        Find_Day()
        vardisplayReport = 103
        run_report()
        vardisplayReport = 103
    End Sub


    Sub Find_Day()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        vardisplayReport = 103
        Dim vardate As String
        Dim vardate2 As String
        '=======================================Date 1
        oldDate = txt_date.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

        Dim d As Date
        Date.TryParse(txt_date.Value, d)
        var_Month_no = d.Month
        var_Year_no = d.Year
        vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
        '=====================================================================date2

        oldDate = txt_date2.Value
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


        Dim d2 As Date
        Date.TryParse(txt_date2.Value, d2)
        var_Month_no = d2.Month
        var_Year_no = d2.Year

        vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay



        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = " Select * From vw_Dailyproduction where (JOBOrder_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) and  (JOBOrder_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102))   "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "التاريخ"
        GridView1.Columns(1).Caption = "الماكينة"
        GridView1.Columns(2).Caption = "الوردية"
        GridView1.Columns(3).Caption = "الفنى"
        GridView1.Columns(4).Caption = "العامل"
        GridView1.Columns(5).Caption = "الكمية المنتجة"
        GridView1.Columns(6).Caption = "الهالك"
        GridView1.Columns(7).Caption = "نسبة الهالك %"
        GridView1.Columns(8).Caption = "ملاحظات"

        GridView1.BestFitColumns()

        'GridView1.Columns(0).AppearanceCell.ForeColor = Color.Red

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



        GridView1.Columns(5).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns(6).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        'On Error Resume Next
        For x As Integer = 0 To GridView1.RowCount


            'Dim quantity As Single
            Dim status_P As String


            If vardisplayReport = 102 Then '
                status_P = GridView1.GetRowCellValue(x, GridView1.Columns(14))
                If status_P = "تشغيل" Then
                    If e.Column.AbsoluteIndex = 14 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Green

                    End If
                Else
                End If
            End If


            If vardisplayReport = 102 Then '
                status_P = GridView1.GetRowCellValue(x, GridView1.Columns(15))
                If status_P = "تم الفحص" Then
                    If e.Column.AbsoluteIndex = 15 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Yellow

                    End If
                Else
                End If
            End If


            If vardisplayReport = 102 Then '
                status_P = GridView1.GetRowCellValue(x, GridView1.Columns(16))
                If status_P = "تم الاضافة" Then
                    If e.Column.AbsoluteIndex = 16 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.Tomato

                    End If
                Else
                End If
            End If



            If vardisplayReport = 102 Then '
                status_P = GridView1.GetRowCellValue(x, GridView1.Columns(17))
                If status_P = "مرحلة النهائية" Then
                    If e.Column.AbsoluteIndex = 17 AndAlso e.RowHandle = x Then
                        e.Appearance.BackColor = Color.SlateBlue

                    End If
                Else
                End If
            End If




        Next x
    End Sub

    Private Sub NavBarItem7_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem7.LinkClicked
        Find_DayProdact()
        vardisplayReport = 101
        run_report()
    End Sub

    Private Sub txt_NameMachine_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameMachine.ButtonClick
        vartable = "TB_MachineName"
        VarOpenlookup = 380
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_NameMachine_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameMachine.EditValueChanged

    End Sub

    Private Sub txt_NameShift_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameShift.ButtonClick
        vartable = "vw_Shift"
        VarOpenlookup = 640
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_NameShift_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameShift.EditValueChanged

    End Sub

    Private Sub txt_nameEmp1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameEmp1.ButtonClick
        vartable = "vw_lookupEmp"
        VarOpenlookup = 650
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_nameEmp1_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameEmp1.EditValueChanged

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If vardisplayReport = 101 Then
            Find_DayProdact()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If

        If vardisplayReport = 102 Then
            Find_Jop_Fill()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If

        If vardisplayReport = 103 Then
            Find_Day()
            GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If

        If vardisplayReport = 104 Then
            'Find_Day()
            'GridView1.BestFitColumns()
            run_report()
            TabPane1.SelectedPageIndex = 1
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txt_NameMachine.Text = ""
        If vardisplayReport = 101 Then Find_DayProdact() : run_report()
        If vardisplayReport = 102 Then Find_Jop_Fill() : run_report()
        If vardisplayReport = 103 Then Find_Day() : run_report()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        txt_nameEmp1.Text = ""
        If vardisplayReport = 101 Then Find_DayProdact() : run_report()
        If vardisplayReport = 102 Then Find_Jop_Fill() : run_report()
        If vardisplayReport = 103 Then Find_Day() : run_report()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        txt_NameShift.Text = ""
        If vardisplayReport = 101 Then Find_DayProdact() : run_report()
        If vardisplayReport = 102 Then Find_Jop_Fill() : run_report()
        If vardisplayReport = 103 Then Find_Day() : run_report()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub
End Class