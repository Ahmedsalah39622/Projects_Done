Imports DevExpress.XtraReports.Wizards

Public Class Mainmune2




    'Private Sub Mainmune2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Connaction_Sql()
    '    FrmLogin.MdiParent = Me
    '    FrmLogin.Show()
    '    Count_Type0()
    '    Count_Type1()
    '    Count_Type2()
    '    Count_Type3()
    '    Count_Type4()
    'End Sub

    'Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
    '    vartable = "BD_TypeLicnse"
    '    Frm_GenralData.Close()
    '    Frm_GenralData.MdiParent = Me
    '    'Frm_GenralData.ck1.Visible = True
    '    'Frm_GenralData.ck2.Visible = True
    '    'Frm_GenralData.ck3.Visible = True
    '    'Frm_GenralData.ck4.Visible = True
    '    'Frm_GenralData.ck5.Visible = True
    '    'Frm_GenralData.ck6.Visible = True
    '    'Frm_GenralData.ck7.Visible = True
    '    'Frm_GenralData.txt_SinName1.Visible = True
    '    'Frm_GenralData.txt_SinName2.Visible = True
    '    'Frm_GenralData.txt_SinName3.Visible = True
    '    'Frm_GenralData.txt_SinName4.Visible = True
    '    'Frm_GenralData.txt_SinName5.Visible = True
    '    'Frm_GenralData.txt_SinName6.Visible = True


    '    'Frm_GenralData.Lab_Dis.Visible = True
    '    'Frm_GenralData.txt_Dis.Visible = True

    '    Frm_GenralData.Text = "اكواد نوع التصريح"
    '    Frm_GenralData.Show()
    'End Sub
    'Sub Count_Type0()
    '    'txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")

    '    sql2 = "SELECT        COUNT(NameExport) AS CountType, NameExport FROM            dbo.Vw_All_PermitData GROUP BY NameExport HAVING        (NameExport = N'تصريح مؤقت')  "
    '    rs = Cnn.Execute(sql2)
    '    If rs.EOF = False Then dashboardTileBarItem.Elements(1).Text = rs("CountType").Value Else dashboardTileBarItem.Elements(1).Text = "0"

    'End Sub
    'Sub Count_Type1()
    '    'txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")

    '    sql2 = "SELECT        COUNT(NameExport) AS CountType, NameExport FROM            dbo.Vw_All_PermitData GROUP BY NameExport HAVING        (NameExport = N'تصريح سيارة')  "
    '    rs = Cnn.Execute(sql2)
    '    If rs.EOF = False Then tasksTileBarItem.Elements(1).Text = rs("CountType").Value Else tasksTileBarItem.Elements(1).Text = "0"

    'End Sub
    'Sub Count_Type2()
    '    'txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")

    '    sql2 = "SELECT        COUNT(NameExport) AS CountType, NameExport FROM            dbo.Vw_All_PermitData GROUP BY NameExport HAVING        (NameExport = N'تصريح صعود الطائرة')  "
    '    rs = Cnn.Execute(sql2)
    '    If rs.EOF = False Then employeesTileBarItem.Elements(1).Text = rs("CountType").Value Else employeesTileBarItem.Elements(1).Text = "0"

    'End Sub

    'Sub Count_Type3()
    '    'txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")

    '    sql2 = "SELECT        COUNT(NameExport) AS CountType, NameExport FROM            dbo.Vw_All_PermitData GROUP BY NameExport HAVING        (NameExport = N'كارت التعارف')  "
    '    rs = Cnn.Execute(sql2)
    '    If rs.EOF = False Then opportunitiesTileBarItem.Elements(1).Text = rs("CountType").Value Else opportunitiesTileBarItem.Elements(1).Text = "0"

    'End Sub


    'Sub Count_Type4()
    '    'txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd")

    '    sql2 = "SELECT        COUNT(dbo.Vw_All_PermitData.NameExport) AS CountType, dbo.Vw_All_PermitData.NameExport, dbo.BD_TypeLicnse.Code FROM            dbo.Vw_All_PermitData INNER JOIN                        dbo.BD_TypeLicnse ON dbo.Vw_All_PermitData.NameExport = dbo.BD_TypeLicnse.Name GROUP BY dbo.Vw_All_PermitData.NameExport, dbo.BD_TypeLicnse.Code HAVING        (dbo.BD_TypeLicnse.Code > 4) "
    '    rs = Cnn.Execute(sql2)
    '    If rs.EOF = False Then productsTileBarItem.Elements(1).Text = rs("CountType").Value Else productsTileBarItem.Elements(1).Text = "0"

    'End Sub

    'Private Sub AccordionControlElement3_Click(sender As Object, e As EventArgs)

    'End Sub



    'Private Sub AccordionControlElement36_Click(sender As Object, e As EventArgs)
    '    'Frm_InvoiceNew.Close() : Frm_InvoiceNew.MdiParent = Me : Frm_InvoiceNew.Show()
    'End Sub

    'Private Sub AccordionControlElement23_Click(sender As Object, e As EventArgs)
    '    'Frm_ItemDataConfacrtion.Close()
    '    'Frm_ItemDataConfacrtion.MdiParent = Me
    '    'Frm_ItemDataConfacrtion.Show()

    'End Sub

    'Private Sub AccordionControlElement25_Click(sender As Object, e As EventArgs)
    '    'Frm_Invintory_FirstItem.Close()
    '    'Frm_Invintory_FirstItem.MdiParent = Me
    '    'Frm_Invintory_FirstItem.Show()
    'End Sub

    'Private Sub AccordionControlElement28_Click(sender As Object, e As EventArgs)
    '    'Frm_BarcodePrint.Close()
    '    'Frm_BarcodePrint.MdiParent = Me
    '    'Frm_BarcodePrint.Show()
    'End Sub

    'Private Sub AccordionControlElement27_Click(sender As Object, e As EventArgs)
    '    'Frm_TaswyaGardya2.Close()
    '    'Frm_TaswyaGardya2.MdiParent = Me
    '    'Frm_TaswyaGardya2.Show()
    'End Sub

    'Private Sub AccordionControlElement37_Click(sender As Object, e As EventArgs)
    '    'Frm_InvoiceRented.Close()
    '    'Frm_InvoiceRented.MdiParent = Me
    '    ''NavBarControl2.Visible = False
    '    'vardisplayReport = 250
    '    'Frm_InvoiceRented.Show()
    'End Sub

    'Private Sub AccordionControlElement38_Click(sender As Object, e As EventArgs)
    '    'vardisplayReport = 0
    '    'FrmReportCustomer4.Lab_Titil.Text = "تقرير مديونية العملاء خلال فترة"
    '    'FrmReportCustomer4.MdiParent = Me
    '    'FrmReportCustomer4.Show()
    'End Sub


    'Private Sub AccordionControlElement9_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub AccordionControlElement20_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub AccordionControlElement48_Click(sender As Object, e As EventArgs)
    'End Sub

    'Private Sub AccordionControlElement5_Click(sender As Object, e As EventArgs)
    '    Frm_CurrentEmployee.Close()
    '    Frm_CurrentEmployee.MdiParent = Me
    '    Frm_CurrentEmployee.Show()
    'End Sub

    'Private Sub AccordionControlElement44_Click(sender As Object, e As EventArgs) Handles AccordionControlElement44.Click
    '    vartypeExport = 0
    '    Frm_LicensData.Close()
    '    Frm_LicensData.MdiParent = Me
    '    Frm_LicensData.TabPane1.SelectedPageIndex = 0
    '    Frm_LicensData.Show()
    'End Sub

    'Private Sub AccordionControlElement35_Click(sender As Object, e As EventArgs) Handles AccordionControlElement35.Click
    '    Frm_CurrentEmployee.Close()
    '    Frm_CurrentEmployee.MdiParent = Me
    '    Frm_CurrentEmployee.Show()
    'End Sub

    'Private Sub AccordionControlElement62_Click(sender As Object, e As EventArgs) Handles AccordionControlElement62.Click
    '    Frm_Security2.MdiParent = Me
    '    Frm_Security2.Show()
    'End Sub

    'Private Sub AccordionControlElement63_Click(sender As Object, e As EventArgs) Handles AccordionControlElement63.Click
    '    Frm_TransactionHistory.Close()
    '    Frm_TransactionHistory.MdiParent = Me
    '    Frm_TransactionHistory.Show()
    'End Sub

    'Private Sub NavButton3_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavButton3.ElementClick
    '    AccordionControlElement1.Expanded = True
    '    AccordionControlElement2.Expanded = True
    '    AccordionControlElement18.Expanded = True
    '    AccordionControlElement43.Expanded = True
    '    AccordionControlElement19.Expanded = True
    '    AccordionControlElement22.Expanded = True

    'End Sub

    'Private Sub NavButton4_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavButton4.ElementClick
    '    AccordionControlElement1.Expanded = False
    '    AccordionControlElement2.Expanded = False
    '    AccordionControlElement18.Expanded = False
    '    AccordionControlElement43.Expanded = False
    '    AccordionControlElement19.Expanded = False
    '    AccordionControlElement22.Expanded = False
    'End Sub

    'Private Sub navButtonClose_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles navButtonClose.ElementClick
    '    Me.Close()
    'End Sub

    'Private Sub AccordionControlElement3_Click_1(sender As Object, e As EventArgs) Handles AccordionControlElement3.Click
    '    vartable = "BD_HeaderReport"
    '    Frm_GenralData.Close()
    '    Frm_GenralData.MdiParent = Me
    '    Frm_GenralData.Lab_Dis.Visible = True
    '    Frm_GenralData.txt_Dis.Visible = True


    '    Frm_GenralData.ck1.Visible = True
    '    Frm_GenralData.ck2.Visible = True
    '    Frm_GenralData.ck3.Visible = True
    '    Frm_GenralData.ck4.Visible = True
    '    Frm_GenralData.ck5.Visible = True
    '    Frm_GenralData.ck6.Visible = True
    '    Frm_GenralData.ck7.Visible = True


    '    Frm_GenralData.txt_SinName1.Visible = True
    '    Frm_GenralData.txt_SinName2.Visible = True
    '    Frm_GenralData.txt_SinName3.Visible = True
    '    Frm_GenralData.txt_SinName4.Visible = True
    '    Frm_GenralData.txt_SinName5.Visible = True
    '    Frm_GenralData.txt_SinName6.Visible = True


    '    Frm_GenralData.Text = "بيان طباعة التصاريح"
    '    Frm_GenralData.Show()
    'End Sub

    'Private Sub AccordionControlElement47_Click(sender As Object, e As EventArgs) Handles AccordionControlElement47.Click

    '    'DashBard1.Show()
    '    Frm_ReportData1.Close()
    '    Frm_ReportData1.MdiParent = Me
    '    Frm_ReportData1.Show()
    'End Sub

    'Private Sub AccordionControlElement6_Click(sender As Object, e As EventArgs) Handles AccordionControlElement6.Click
    '    Frm_ReporFinsh1.Close()
    '    Frm_ReporFinsh1.MdiParent = Me
    '    vadashboar = 0
    '    Frm_ReporFinsh1.Show()
    'End Sub

    'Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) Handles AccordionControlElement8.Click
    '    vartypeExport = 0
    '    Frm_LicensData.Close()
    '    Frm_LicensData.MdiParent = Me
    '    Frm_LicensData.TabPane1.SelectedPageIndex = 2
    '    Frm_LicensData.Show()
    'End Sub

    'Private Sub NavButton5_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)

    'End Sub

    'Private Sub AccordionControlElement7_Click(sender As Object, e As EventArgs) Handles AccordionControlElement7.Click

    'End Sub

    'Private Sub AccordionControlElement9_Click_1(sender As Object, e As EventArgs) Handles AccordionControlElement9.Click
    '    DashBard1.Show()
    'End Sub

    'Private Sub AccordionControlElement10_Click(sender As Object, e As EventArgs) Handles AccordionControlElement10.Click
    '    Frm_ReporFinsh1.Close()
    '    Frm_ReporFinsh1.MdiParent = Me
    '    vadashboar = 1
    '    Frm_ReporFinsh1.Show()
    'End Sub

    'Private Sub AccordionControlElement11_Click(sender As Object, e As EventArgs) Handles AccordionControlElement11.Click
    '    Frm_CostLic.Close()
    '    Frm_CostLic.MdiParent = Me
    '    Frm_CostLic.Show()
    'End Sub

    'Private Sub AccordionControlElement12_Click(sender As Object, e As EventArgs) Handles AccordionControlElement12.Click
    '    'find_Lic()
    '    find_Lic.Close()
    '    find_Lic.MdiParent = Me
    '    find_Lic.Show()
    'End Sub

    Private Sub AccordionControlElement35_Click(sender As Object, e As EventArgs) Handles AccordionControlElement35.Click

        Frm_Cust.Close()
        Frm_Cust.MdiParent = Me
        Frm_Cust.Show()
    End Sub


    Public Sub openCustomerFrm()
        Frm_Cust.Close()
        Frm_Cust.MdiParent = Me
        Frm_Cust.Show()
    End Sub

    Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) Handles AccordionControlElement8.Click
        Frm_Car.Close()
        Frm_Car.MdiParent = Me
        Frm_Car.Show()
        Frm_Car.TabPane1.SelectedPageIndex = 2
    End Sub



    Private Sub NavButton3_ElementClick(sender As Object, e As XtraBars.Navigation.NavElementEventArgs) Handles NavButton3.ElementClick
        AccordionControlElement1.Expanded = True
        AccordionControlElement2.Expanded = True
        AccordionControlElement18.Expanded = True
        AccordionControlElement43.Expanded = True
        AccordionControlElement19.Expanded = True
        AccordionControlElement22.Expanded = True
    End Sub

    Private Sub NavButton4_ElementClick(sender As Object, e As XtraBars.Navigation.NavElementEventArgs) Handles NavButton4.ElementClick
        AccordionControlElement1.Expanded = False
        AccordionControlElement2.Expanded = False
        AccordionControlElement18.Expanded = False
        AccordionControlElement43.Expanded = False
        AccordionControlElement19.Expanded = False
        AccordionControlElement22.Expanded = False
    End Sub

    Private Sub AccordionControlElement44_Click(sender As Object, e As EventArgs) Handles AccordionControlElement44.Click
        Frm_Car.Close()
        Frm_Car.MdiParent = Me
        Frm_Car.Show()
    End Sub

    Public Sub openCarFrm()
        Frm_Car.Close()
        Frm_Car.MdiParent = Me
        Frm_Car.Show()
    End Sub

    Private Sub AccordionControlElement47_Click(sender As Object, e As EventArgs) Handles AccordionControlElement47.Click
        'Frm_Doucument()

        Frm_Doucument.Close()
        Frm_Doucument.MdiParent = Me
        Frm_Doucument.Show()
    End Sub

    Private Sub AccordionControlElement43_Click(sender As Object, e As EventArgs) Handles AccordionControlElement43.Click

    End Sub

    Private Sub AccordionControlElement3_Click(sender As Object, e As EventArgs) Handles AccordionControlElement3.Click
        vartable = "BD_REGION"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المناطق"
        Frm_GenralData.Show()
    End Sub

    Private Sub AccordionControlElement13_Click(sender As Object, e As EventArgs) Handles AccordionControlElement13.Click
        vartable = "BD_Bank"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "البنوك المتعامل معها"
        Frm_GenralData.Show()
    End Sub

    Private Sub AccordionControlElement14_Click(sender As Object, e As EventArgs) Handles AccordionControlElement14.Click
        vartable = "BD_EDARAT_ELMROR"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "ادارة المرور"
        Frm_GenralData.Show()
    End Sub

    Private Sub AccordionControlElement15_Click(sender As Object, e As EventArgs) Handles AccordionControlElement15.Click
        vartable = "BD_Trakhes"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "التراخيص"
        Frm_GenralData.Show()
    End Sub

    Private Sub AccordionControlElement20_Click(sender As Object, e As EventArgs) Handles AccordionControlElement20.Click

        vartable = "BD_Insurnce_Company_name"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "شركات التأمين"
        Frm_GenralData.Show()

    End Sub

    Private Sub AccordionControlElement12_Click(sender As Object, e As EventArgs) Handles AccordionControlElement12.Click
        Frm_Doucument.Close()
        Frm_Doucument.MdiParent = Me
        Frm_Doucument.Show()
        Frm_Doucument.TabPane1.SelectedPageIndex = 2
    End Sub

    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        vartable = "BD_car_brands"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "موديلات السيارات"
        Frm_GenralData.Show()
    End Sub



    Private Sub AccordionControlElement10_Click(sender As Object, e As EventArgs) Handles AccordionControlElement10.Click
        Frm_Doucument.Close()
        Frm_Doucument.MdiParent = Me
        Frm_Doucument.Show()
        Frm_Doucument.find_document(sqll:="select * FROM BD_insurance_doucument 
WHERE insurance_end_date BETWEEN GETDATE() AND DATEADD(day, 60, GETDATE())")
        Frm_Doucument.TabPane1.SelectedPageIndex = 2
    End Sub

    Private Sub AccordionControlElement21_Click_1(sender As Object, e As EventArgs) Handles AccordionControlElement21.Click
        vartable = "BD_Mother_company_name"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "موديلات السيارات"
        Frm_GenralData.Show()
    End Sub

    Private Sub Mainmune2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dashboardTileBarItem.Text = Frm_Cust.count_in_customer(" select count(*) as numbers from BD_personal_license_info
  where license_end_date < GETDATE()")
        productsTileBarItem.Text = Frm_Doucument.doucument_ended()

    End Sub

    Private Sub show_info_frm_Click(sender As Object, e As EventArgs) Handles show_info_frm.Click
        Frm_expired_dates.Close()
        Frm_expired_dates.MdiParent = Me
        Frm_expired_dates.Show()

    End Sub

    Private Sub AccordionControlElement62_Click(sender As Object, e As EventArgs) Handles AccordionControlElement62.Click

        Insurance_reports.ShowReport(5)
        Insurance_reports.Show()
    End Sub

    Private Sub AccordionControl1_Click(sender As Object, e As EventArgs) Handles AccordionControl1.Click

    End Sub

    Private Sub AccordionControlElement63_Click(sender As Object, e As EventArgs) Handles AccordionControlElement63.Click

    End Sub

    Private Sub AccordionControlElement7_Click(sender As Object, e As EventArgs) Handles AccordionControlElement7.Click

    End Sub
End Class