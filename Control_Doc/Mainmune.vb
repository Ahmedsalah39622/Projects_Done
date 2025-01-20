Imports System.Windows.Forms

Public Class Mainmune
    Dim RanNum As New Random            ' Random number generator
    Dim DistMove As Integer = 10        ' The distance the label moves each time
    Dim fileContents As String
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'varCodeConnaction = 1
        'If varCodeConnaction = 1 Then Connaction_Sql()
        'If varCodeConnaction = 2 Then Connaction_Oracle()

        'Try
        '    fileContents = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\ConnString.txt")
        '    My.Settings.RunTimeConnectionString = fileContents
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'LoginFrm.ShowDialog()


        FrmLogin.MdiParent = Me
        FrmLogin.Show()
        'frm_SplashScreen.Timer1.Interval = 0
        'frm_SplashScreen.Visible = False

        
    End Sub

    Sub finwatinoderItem()
        sql = "    SELECT        COUNT(Order_Ser) AS CountWating, Compny_Code       FROM dbo.vw_Oder_TalpSarf GROUP BY Compny_Code  HAVING(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_WatingOrderItem.Text = rs("CountWating").Value Else txt_WatingOrderItem.Text = "0"

    End Sub


    Sub finwatinoderItem2()
        sql = "    SELECT        COUNT(Order_Ser) AS CountWating, Compny_Code       FROM dbo.vw_Oder_TalpPrcheses GROUP BY Compny_Code  HAVING(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_WatingOrderItem2.Text = rs("CountWating").Value Else txt_WatingOrderItem2.Text = "0"

    End Sub
    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Frm_DataItem.Show()
        Frm_DataItem.MdiParent = Me
    End Sub

    Private Sub BarButtonItem44_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem44.ItemClick
        Frm_dataitem2.Close()

        Frm_dataitem2.MdiParent = Me
        Frm_dataitem2.Show()

    End Sub

    Private Sub BarButtonItem33_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick

        vartable = "BD_Stores"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المخازن"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem34_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        vartable = "BD_SUBMAIN"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الفروع"
        Frm_GenralData.Show()
    End Sub



    Private Sub BarButtonItem41_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        vartable = "BD_GROUPITEMMAIN"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الرئيسية"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        vartable = "BD_GroupItem1"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الاولى"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem43_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        vartable = "BD_GroupItem2"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الثانية"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        'Frm_FristItem.Close()
        'Frm_FristItem.MdiParent = Me
        'Frm_FristItem.LabelX14.Visible = False
        'Frm_FristItem.Com_Type.Visible = False
        'Frm_FristItem.txt_QtyAvalabil.Visible = False
        'Frm_FristItem.com_typeSnd.Text = "بضاعة اول المدة"

        'varflagstatus = 0
        'Frm_FristItem.Show()

        varflagstatus = 0
        Frm_Invintory_FirstItem.MdiParent = Me
        Frm_Invintory_FirstItem.Show()
    End Sub

    Private Sub BarButtonItem45_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem45.ItemClick
        Frm_SalseInvoice.Close()
        Frm_SalseInvoice.MdiParent = Me
        Frm_SalseInvoice.Show()
        'varChooseInvoice = 2
        'Frm_SalseInvoice.CheckBox3.Visible = True
        'Frm_SalseInvoice.CheckBox4.Visible = True
        'Frm_SalseInvoice.CheckEng.Visible = True
        'Frm_SalseInvoice.CheckNewwithoutlogo.Visible = True
        'Frm_SalseInvoice.CheckNewArbLogo.Visible = True
        'Frm_SalseInvoice.SimpleButton3.Visible = True
        'Frm_SalseInvoice.SimpleButton1.Visible = True
        'Frm_SalseInvoice.SimpleButton7.Visible = True
        'Frm_SalseInvoice.SimpleButton5.Visible = True
        'Frm_SalseInvoice.SimpleButton2.Visible = True
        'Frm_SalseInvoice.Cmd_PrintInvoice.Visible = True

        'Frm_SalseInvoice.Com_NoAzn.Visible = True
        'Frm_SalseInvoice.LabelX31.Visible = True
        'Frm_SalseInvoice.txt_SalseOrder.Visible = True
        'Frm_SalseInvoice.LabelX9.Visible = True
        'Frm_SalseInvoice.txt_OpenGl.Visible = True
        'Frm_SalseInvoice.cmd_OpenGl.Visible = True
        'Frm_SalseInvoice.LabelX33.Visible = True
        'Frm_SalseInvoice.Cmd_DeleteInv.Visible = True
        'Frm_SalseInvoice.LabelX25.Visible = True
        'Frm_SalseInvoice.txt_Typeinv.Visible = True
        'Frm_SalseInvoice.RadioButton2.Visible = True
        'Frm_SalseInvoice.RadioButton1.Visible = True
        'Frm_SalseInvoice.Com_Group_Item.Visible = True
        'Frm_SalseInvoice.Cmd_DeleteInv.Visible = True
        'Frm_SalseInvoice.Cmd_RtInvoice.Visible = True

        'Frm_SalseInvoice.Cmd_Delete.Visible = True
        'Frm_SalseInvoice.cmd_Edit.Visible = True
        'Frm_SalseInvoice.cmd_FindItem.Visible = True
        'Frm_SalseInvoice.LabelX28.Visible = True
        'Frm_SalseInvoice.LabelX1.Visible = True
        'Frm_SalseInvoice.LabelX35.Visible = True
        'Frm_SalseInvoice.LabelX29.Visible = True
        'Frm_SalseInvoice.LabelX6.Visible = True
        'Frm_SalseInvoice.LabelX8.Visible = True
        'Frm_SalseInvoice.LabelX34.Visible = True
        'Frm_SalseInvoice.LabelX23.Visible = True
        'Frm_SalseInvoice.txt_Dis.Visible = True
        'Frm_SalseInvoice.txt_Dis2.Visible = True
        'Frm_SalseInvoice.txt_Ntax2.Visible = True
        'Frm_SalseInvoice.txt_OtherDiscount.Visible = True
        'Frm_SalseInvoice.txt_Ntax3.Visible = True
        'Frm_SalseInvoice.LabelX10.Visible = True
        'Frm_SalseInvoice.txt_Notes.Visible = True
        'Frm_SalseInvoice.txt_Ntax.Visible = True
        'Frm_SalseInvoice.txt_Tax.Visible = True
        'Frm_SalseInvoice.Txt_TotalAll.Visible = True
        'Frm_SalseInvoice.Cmd_LookupSalse.Visible = True

        'Frm_SalseInvoice.txt_AccountNo.Visible = True
        'Frm_SalseInvoice.txt_walletCode.Visible = True
        'Frm_SalseInvoice.LabelX40.Visible = True
        'Frm_SalseInvoice.Com_Stores.Visible = True



        'Frm_SalseInvoice.LabelX38.Visible = False
        'Frm_SalseInvoice.txt_Barcode.Visible = False
        'Frm_SalseInvoice.LabelX39.Visible = False
        'Frm_SalseInvoice.txt_walletCode.Visible = False
        'Frm_SalseInvoice.txt_walletName.Visible = False
        'Frm_SalseInvoice.Com_Stores.Visible = False
        'Frm_SalseInvoice.LabelX40.Visible = False


        'Frm_SalseInvoice.lb_branchName.Text = varNameBranch
        'Frm_SalseInvoice.show_Groups()
        'Frm_SalseInvoice.fill_TypeInvoice()

    End Sub


    

   

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Frm_CompnyInfo2.Close()
        Frm_CompnyInfo2.MdiParent = Me
        Frm_CompnyInfo2.Show()

    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Frm_ChartOfAccount2.Close()
        Frm_ChartOfAccount2.MdiParent = Me
        NavBarControl2.Visible = False
        Frm_ChartOfAccount2.TabPane1.SelectedPageIndex = 0
        Frm_ChartOfAccount2.Show()

        'Frm_ChartOfAccount()
    End Sub

    Private Sub BarButtonItem58_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem58.ItemClick
        Frm_SalseInvoice2.Close()
        Frm_SalseInvoice2.MdiParent = Me
        Frm_SalseInvoice2.Show()
    End Sub

    Private Sub BarButtonItem59_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem59.ItemClick
        Frm_SalseInvoice2.Close()
        Frm_SalseInvoice2.MdiParent = Me
        Frm_SalseInvoice2.Show()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Frm_SetupGenral.Close()
        Frm_SetupGenral.MdiParent = Me
        Frm_SetupGenral.Show()
    End Sub

    Private Sub BarButtonItem70_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem70.ItemClick
        'Frm_ReportCustomer.Close()
        'vardisplayReport = 1
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.LabelX1.Text = "تقرير يومية المبيعات للعملاء خلال فترة"
        'Frm_ReportCustomer.Find_TotalInvoice()
        'Frm_ReportCustomer.Show()


        vardisplayReport = 1
      
        Frm_ReportCustomer.Close()
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Find_TotalInvoice()
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.Lab_NameReport.Text = "تقرير يومية المبيعات والعملاء بدون الاصناف - خلال فترة"
        Frm_ReportCustomer2.LabelX2.Enabled = False
        Frm_ReportCustomer2.txt_nameitem.Enabled = False
        Frm_ReportCustomer2.cmd_all.Enabled = False
        Frm_ReportCustomer2.SimpleButton7.Enabled = True
        Frm_ReportCustomer2.txt_NameCustomer.Enabled = True
        Frm_ReportCustomer2.txt_NameSalse.Enabled = True
        NavBarControl2.Visible = False
    End Sub

    Private Sub BarButtonItem95_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem95.ItemClick
        'Frm_NewReport.Close()
        'Frm_NewReport.MdiParent = Me
        'Frm_NewReport.Show()
        DashboarSalse.Show()
    End Sub

    Private Sub BarButtonItem96_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem96.ItemClick
        Frm_ClanderData.Close()
        Frm_ClanderData.MdiParent = Me
        Frm_ClanderData.Show()

    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Frm_Financial_Period.Close()
        Frm_Financial_Period.MdiParent = Me
        Frm_Financial_Period.Show()
    End Sub

    Private Sub BarButtonItem61_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem61.ItemClick
        Frm_ReciptCash2.Close()
        Frm_ReciptCash2.MdiParent = Me
        Frm_ReciptCash2.Show()
    End Sub

    Private Sub BarButtonItem63_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles Button_Exp.ItemClick
        Frm_Expenses2.Close()
        Frm_Expenses2.MdiParent = Me
        Frm_Expenses2.Show()
    End Sub

    Private Sub BarButtonItem97_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem97.ItemClick
        Frm_Gl4.Close()
        Frm_Gl4.MdiParent = Me
        statusopen = 0
        Frm_Gl4.Show()
    End Sub

    Private Sub BarButtonItem98_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem98.ItemClick
        Frm_AccountStatement2.Close()
        Frm_AccountStatement2.MdiParent = Me
        Frm_AccountStatement2.Show()
    End Sub

    Private Sub BarButtonItem48_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem48.ItemClick
        Frm_suppliersInfo.Close()
        Frm_suppliersInfo.MdiParent = Me
        Frm_suppliersInfo.Show()

    End Sub





    Private Sub BarButtonItem104_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem104.ItemClick
        Frm_resource.Close()

        Frm_resource.MdiParent = Me
        Frm_resource.Show()
    End Sub

    Private Sub BarButtonItem116_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem116.ItemClick

        'Frm_ExEmployee.Close()

        'Frm_ExEmployee.MdiParent = Me
        'Frm_ExEmployee.Show()
    End Sub


    Private Sub BarButtonItem114_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem114.ItemClick
     
    End Sub

    Private Sub BarButtonItem111_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem111.ItemClick

    End Sub

    Private Sub BarButtonItem113_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem113.ItemClick
      
    End Sub

    Private Sub BarButtonItem110_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem110.ItemClick
       
    End Sub

    Private Sub BarButtonItem105_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem105.ItemClick
        vartable = "BD_JOBNAMES"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المسمى الوظيفى"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem115_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem115.ItemClick
        Frm_CurrentEmployee.Close()

        Frm_CurrentEmployee.MdiParent = Me
        Frm_CurrentEmployee.Show()
    End Sub

    Private Sub BarButtonItem125_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem125.ItemClick
        Frm_Attendec.Close()

        Frm_Attendec.MdiParent = Me
        Frm_Attendec.Show()
    End Sub

    Private Sub BarButtonItem138_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem138.ItemClick
        Frm_SpecialTimes.Close()

        Frm_SpecialTimes.MdiParent = Me
        Frm_SpecialTimes.Show()
    End Sub

    Private Sub BarButtonItem121_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem121.ItemClick

        Frm_Vaction.Close()

        Frm_Vaction.MdiParent = Me
        Frm_Vaction.Show()
    End Sub



    Private Sub BarButtonItem140_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem140.ItemClick

        Frm_ResignedOLD.Close()

        Frm_ResignedOLD.MdiParent = Me
        Frm_ResignedOLD.Show()
    End Sub

    Private Sub BarButtonItem141_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem141.ItemClick

        Frm_MattersOfIndividuals.Close()

        Frm_MattersOfIndividuals.MdiParent = Me
        Frm_MattersOfIndividuals.Show()
    End Sub

    Private Sub BarButtonItem137_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem137.ItemClick

        Frm_SpeicalIncrement.Close()

        Frm_SpeicalIncrement.MdiParent = Me
        Frm_SpeicalIncrement.Show()
    End Sub



    Private Sub BarButtonItem133_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem133.ItemClick

        frm_Estkta4.Close()

        frm_Estkta4.MdiParent = Me
        frm_Estkta4.Show()
    End Sub

    Private Sub BarButtonItem134_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem134.ItemClick

        Frm_Payroll_Data.Close()
        Frm_Payroll_Data.MdiParent = Me
        Frm_Payroll_Data.Show()
    End Sub

    Private Sub BarButtonItem143_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem143.ItemClick

        Frm_MatterOLD.Close()

        Frm_MatterOLD.MdiParent = Me
        Frm_MatterOLD.Show()
    End Sub

    Private Sub BarButtonItem35_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        vartable = "BD_REGION"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المحافظات"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem36_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick
        vartable = "BD_SUB_REGIONS"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المناطق"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem37_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        vartable = "BD_CITIES"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الدول"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick

    End Sub

    Private Sub BarButtonItem106_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem106.ItemClick
        

    End Sub



    Private Sub BarButtonItem107_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem107.ItemClick
        
    End Sub




    Private Sub BarButtonItem146_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem146.ItemClick
        frm_CostCenter.Close()
        frm_CostCenter.MdiParent = Me
        frm_CostCenter.Show()
    End Sub

    Private Sub BarButtonItem54_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem54.ItemClick
        Frm_Cust.Close()
        Frm_Cust.MdiParent = Me
        Frm_Cust.Show()
        'Frm_DataCustomer.Close()
        'Frm_DataCustomer.MdiParent = Me
        'Frm_DataCustomer.Show()
    End Sub

    Private Sub BarButtonItem147_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem147.ItemClick
        Frm_SetupYear.Close()
        Frm_SetupYear.MdiParent = Me
        Frm_SetupYear.Show()

    End Sub

    Private Sub BarButtonItem55_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem55.ItemClick
        Frm_delegatesInfo.Close()
        Frm_delegatesInfo.MdiParent = Me
        Frm_delegatesInfo.Show()
    End Sub

    Private Sub BarButtonItem67_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem67.ItemClick
        Frm_FristItem.Close()
        Frm_FristItem.MdiParent = Me
        Frm_FristItem.com_typeSnd.Text = "تحويل من المخازن"
        Frm_FristItem.Com_Type.Text = "تحويل مخزن اخر"

        If Frm_FristItem.Com_Type.Text = "تحويل مخزن اخر" Then Frm_FristItem.LabelX13.Visible = True : Frm_FristItem.txt_namestores2.Visible = True : Frm_FristItem.txt_codestores2.Visible = True : Frm_FristItem.Cmd_LookUpStores.Visible = True



        'Frm_FristItem.ButtonX3.Visible = False
        Frm_FristItem.txt_Barcode.Visible = True
        Frm_FristItem.LabelX6.Visible = True
        Frm_FristItem.txt_QtyAvalabil.Visible = True
        Frm_FristItem.Cmd_Save.Visible = True
        varflagstatus = 1
        Frm_FristItem.Show()

    End Sub

    'Private Sub BarButtonItem68_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem68.ItemClick
    '    Frm_FristItem.Close()
    '    Frm_FristItem.MdiParent = Me
    '    Frm_FristItem.com_typeSnd.Text = "اذن صرف من المخزن"
    '    Frm_FristItem.Com_Type.Text = "اذن صرف من المخزن"

    '    'Frm_FristItem.ButtonX3.Visible = False
    '    Frm_FristItem.txt_Barcode.Visible = True
    '    Frm_FristItem.LabelX6.Visible = True
    '    Frm_FristItem.txt_QtyAvalabil.Visible = True
    '    Frm_FristItem.LabelX21.Visible = True
    '    Frm_FristItem.Cmd_Save.Visible = True

    '    Frm_FristItem.txt_nameaccount.Visible = True
    '    Frm_FristItem.cmd_Lookup1.Visible = True
    '    Frm_FristItem.LabelX18.Visible = True
    '    Frm_FristItem.txt_AccountNo.Visible = True
    '    Frm_FristItem.txt_Barcode.Visible = False
    '    Frm_FristItem.LabelX6.Visible = False
    '    Frm_FristItem.txt_Typeinv.Visible = True
    '    Frm_FristItem.LabelX25.Visible = True
    '    'Frm_FristItem.ButtonX6.Visible = True
    '    varflagstatus = 2
    '    Frm_FristItem.Show()
    'End Sub

    Private Sub BarButtonItem181_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem181.ItemClick
        'SplashDashbord.Close()
        'SplashDashbord.MdiParent = Me
        'SplashDashbord.Show()

    End Sub



    Private Sub BarButtonItem52_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem52.ItemClick

        'Frm_OrderSal.Close()
        'Frm_OrderSal.MdiParent = Me
        'Frm_OrderSal.Show()
        Frm_OrderData.Close()
        Frm_OrderData.MdiParent = Me
        Frm_OrderData.Show()
    End Sub

    Private Sub BarButtonItem51_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem51.ItemClick
        Frm_OrderPrcheses.Close()
        Frm_OrderPrcheses.MdiParent = Me
        Frm_OrderPrcheses.Show()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '' Add distance to label
        'Label1.Top += DistMove
        '' Check if label has reach the right side of window
        'If Label1.Top + Label1.Width > Me.ClientRectangle.Width Then
        '    ' If so make sure none is hidden
        '    Label1.Top = Me.ClientRectangle.Width - Label1.Width
        '    ' Reverse the direction - if positive make negative, if negative make positive
        '    DistMove = Not DistMove
        'ElseIf Label1.Top < 0 Then
        '    ' If label is less than zero make it zero
        '    Label1.Top = 0
        '    ' Reverse the direction
        '    DistMove = Not DistMove
        'End If
        '' Change the forecolor of the label. The RanNum.Next gives a number between 0 and 255
        'Me.Label1.ForeColor = Color.FromArgb(255, RanNum.Next(0, 100), RanNum.Next(0, 255), RanNum.Next(0, 50))

        'Label1.top += 10
        '' Check if label has reach the right side of window
        'If Label1.Left + Label1.Width > Me.ClientRectangle.Width Then
        '    ' If so make sure none is hidden
        '    Label1.Left = 0
        '    ' Reverse the direction - if positive make negative, if negative make positive
        'ElseIf Label1.Left < 0 Then
        '    ' If label is less than zero make it zero
        '    Label1.Left = 0
        '    ' Reverse the direction
        'End If
        '' Change the forecolor of the label. The RanNum.Next gives a number between 0 and 255
        'Me.Label1.ForeColor = Color.FromArgb(255, RanNum.Next(0, 255), RanNum.Next(0, 255), RanNum.Next(0, 255))


        Label1.Left = Label1.Left - 200



        Dim bottomValue As Integer = Label1.Left + Label1.Height



        ' Check if the bottom of the label has hit the bottom of our form

        ' If so, stop the timer.

        If bottomValue >= Me.ClientRectangle.Height Then

            Timer1.Stop()

        End If




    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Label1.Left = Label1.Left + 200



        Dim bottomValue2 As Integer = Label1.Left + Label1.Height



        ' Check if the bottom of the label has hit the bottom of our form

        ' If so, stop the timer.

        If bottomValue2 >= Me.ClientRectangle.Height Then

            Timer1.Start()
        End If
        Timer1.Stop()
    End Sub


    Private Sub ToolStripStatusLabel_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel.Click
        'Frm_Main.Close()
        'Frm_Main.MdiParent = Me
        'Frm_Main.Show()
        NavBarControl2.Visible = False
        Frm_newMune2.Close()
        Frm_newMune2.MdiParent = Me

        Frm_newMune2.Show()

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        Frm_Report_SalesRequest.find_StutasOrderItem_New()
        Frm_Report_SalesRequest.MdiParent = Me
        Frm_Report_SalesRequest.Show()
    End Sub


    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Frm_OrderItemWating.find_Watingorder()
        Frm_OrderItemWating.MdiParent = Me
        Frm_OrderItemWating.Show()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        NavBarControl2.Visible = True

    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel3.Click
        NavBarControl2.Visible = False
    End Sub

    Private Sub NavBarItem4_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        'بيع الماكينات اليومى
        'statusInvoice = 1


        'Status_Nataction.Close()
        'Status_Nataction.MdiParent = Me
        'Status_Nataction.Show()
        Frm_ReciptCash2.Close()
        Frm_ReciptCash2.MdiParent = Me
        Frm_ReciptCash2.Show()
    End Sub



    Sub Invoice_Count0() ' اجمالى عدد بيع الماكينات

        'sql = "      SELECT        COUNT(TypeItem) AS CountInvoice1    FROM dbo.Vw_AllInvoice where      (Compny_Code = '" & VarCodeCompny & "') AND (Code = 0)"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then NavBarItem4.Caption = "إجمالى بيع الماكينات" & " " & rs("CountInvoice1").Value
    End Sub

    Sub Invoice_Count1() ' اجمالى عدد بيع قطع غيار
        'AllDate_Invoice()
        sql = "      SELECT        COUNT(TypeItem) AS CountInvoice1    FROM dbo.Vw_AllInvoice where     (Compny_Code = '" & VarCodeCompny & "') AND (Code = 1)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then NavBarItem5.Caption = "إجمالى بيع قطع الغيار" & " " & rs("CountInvoice1").Value
    End Sub
    Sub Invoice_Count2() ' اجمالى عدد بيع خام
        'AllDate_Invoice()
        sql = "      SELECT        COUNT(TypeItem) AS CountInvoice1    FROM dbo.Vw_AllInvoice  where    (Compny_Code = '" & VarCodeCompny & "') AND (Code =2)"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then NavBarItem6.Caption = "إجمالى بيع الخام" & " " & rs("CountInvoice1").Value
    End Sub

    Private Sub NavBarItem5_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        'بيع قطع الغيار اليومى 
        'statusInvoice = 2
        ''Status_Nataction.Fill_AllInvoice()
        'Status_Nataction.Close()
        'Status_Nataction.MdiParent = Me
        'Status_Nataction.Show()


        Frm_Expenses2.Close()
        Frm_Expenses2.MdiParent = Me
        Frm_Expenses2.Show()
    End Sub

    Private Sub NavBarItem6_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem6.LinkClicked
        'بيع الخام اليومى 
        'statusInvoice = 3
        ''Status_Nataction.Fill_AllInvoice()
        'Status_Nataction.Close()
        'Status_Nataction.MdiParent = Me
        'Status_Nataction.Show()
        Frm_AccountStatement2.Close()
        Frm_AccountStatement2.MdiParent = Me
        Frm_AccountStatement2.Show()

    End Sub



    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click
        Invoice_Count0()
        Invoice_Count1()
        Invoice_Count2()

    End Sub

    Private Sub BarButtonItem62_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem64_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub LabelItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Frm_OrderItemWating2.find_Watingorder()
        Frm_OrderItemWating2.MdiParent = Me
        Frm_OrderItemWating2.Show()
    End Sub



    Private Sub BarButtonItem60_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem60.ItemClick
        DashboarSalse.Close()
        DashboarSalse.MdiParent = Me
        DashboarSalse.Show()



    End Sub

    Private Sub BarButtonItem62_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem62.ItemClick
        Frm_ChartSal.Close()
        Frm_ChartSal.MdiParent = Me
        Frm_ChartSal.Show()
    End Sub



    Private Sub BarButtonItem38_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        Frm_SetupCruuncy.Close()
        Frm_SetupCruuncy.MdiParent = Me
        Frm_SetupCruuncy.Show()

    End Sub

    Private Sub BarButtonItem63_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem63.ItemClick
        vartable = "BD_Currency"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد العملات"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem172_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem172.ItemClick

        'Frm_ReportInventory.Close()
        'Frm_ReportInventory.MdiParent = Me
        'Frm_ReportInventory.Show()
        'Frm_ReportInventory.find_Gard()
        'Frm_ReportInventory.Lab_Name.Text = "تقرير تقييم المخزون"
        'NavBarControl2.Visible = False

        Frm_Report_Invintory.Close()
        vardisplayReport4 = 1
        Frm_Report_Invintory.MdiParent = Me
        Frm_Report_Invintory.Show()
    End Sub

    Private Sub BarButtonItem64_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem64.ItemClick
     
    End Sub



    Private Sub BarButtonItem71_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem71.ItemClick
        vartable = "TB_InvoiceType"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع فواتير البيع"
        Frm_GenralData.Show()
    End Sub



    Private Sub BarButtonItem188_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem188.ItemClick
        NavBarControl2.Visible = False
        Frm_ProudactionOrder.Close()
        Frm_ProudactionOrder.MdiParent = Me
        Frm_ProudactionOrder.Show()
    End Sub

    Private Sub BarButtonItem189_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem189.ItemClick
        NavBarControl2.Visible = False
        Frm_AznEstlamItem.Close()
        Frm_AznEstlamItem.MdiParent = Me
        Frm_AznEstlamItem.Show()

    End Sub

    Private Sub BarButtonItem187_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem187.ItemClick
        vartable = "TB_MachineName"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أسم الماكينة"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem191_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem191.ItemClick
        vartable = "TB_TypeMatril"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع المواد الخام"
        Frm_GenralData.Show()

    End Sub

    Private Sub BarButtonItem183_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem183.ItemClick
        Frm_Security2.Close()
        Frm_Security2.Show()
        Frm_Security2.MdiParent = Me
    End Sub

    Private Sub Button_ChooesCompny_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles Button_ChooesCompny.ItemClick
        FrmLogin.Close()
        FrmLogin.MdiParent = Me
        FrmLogin.Show()
    End Sub

    Private Sub Button_Close_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles Button_Close.ItemClick
        End
    End Sub

    Private Sub Button_unit_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles Button_unit.ItemClick
        vartable = "BD_Unit"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الوحدات"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem1880_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles ا.ItemClick
        NavBarControl2.Visible = False
        Frm_PlayandStopeJopOrder.Close()
        Frm_PlayandStopeJopOrder.MdiParent = Me
        Frm_PlayandStopeJopOrder.Show()
    End Sub

    Private Sub BarButtonItem193_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem193.ItemClick
        NavBarControl2.Visible = False
        Frm_ProductFinsh.Close()
        Frm_ProductFinsh.MdiParent = Me
        Frm_ProductFinsh.Show()
    End Sub

    Private Sub BarButtonItem148_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem148.ItemClick
        Frm_TrialBalnce3.Close()
        Frm_TrialBalnce3.MdiParent = Me
        Frm_TrialBalnce3.Show()

    End Sub

    Private Sub NavBarItem7_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem7.LinkClicked
        'frm_gard.Close()
        'frm_gard.MdiParent = Me
        'frm_gard.Show()
        'NavBarControl2.Visible = False
        'Frm_AznSarf2.Close()
        'Frm_AznSarf2.MdiParent = Me
        'Frm_AznSarf2.Show()
    End Sub



    Private Sub BarButtonItem196_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem196.ItemClick
        vartable = "BD_CondationOrder"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "شروط الدفع"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem197_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem197.ItemClick
        vartable = "BD_CondationTaslem"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "شروط التسليم"
        Frm_GenralData.Show()
    End Sub


    Private Sub BarSubItem133_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarSubItem133.ItemClick
        Frm_ShiftEmp.Close()
        Frm_ShiftEmp.MdiParent = Me
        Frm_ShiftEmp.Show()
    End Sub

    Private Sub BarButtonItem198_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem198.ItemClick
        Frm_AsgmintShift.Close()
        Frm_AsgmintShift.MdiParent = Me
        Frm_AsgmintShift.Show()
    End Sub

    Private Sub BarButtonItem199_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem199.ItemClick

        Frm_SetupBoxandBank.Close()
        Frm_SetupBoxandBank.MdiParent = Me
        Frm_SetupBoxandBank.Show()

    End Sub

    Private Sub BarButtonItem200_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem200.ItemClick
        vartable = "BD_CatograySuppliser"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "تصنيف الموردين"
        Frm_GenralData.Show()
    End Sub



    Private Sub BarButtonItem87_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem87.ItemClick



    End Sub

    Private Sub NavBarItem16_LinkClicked1(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem16.LinkClicked
        'الشيكات الواردة


        Frm_ReportChek.Close()
        Frm_ReportChek.MdiParent = Me
        Frm_ReportChek.TabPane1.SelectedPageIndex = 0
        Frm_ReportChek.Wared_Bank()
        Frm_ReportChek.Show()
    End Sub

    Private Sub NavBarItem17_LinkClicked1(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem17.LinkClicked
        'الشيكات المنصرفة
        Frm_ReportChek.Close()
        Frm_ReportChek.MdiParent = Me
        Frm_ReportChek.TabPane1.SelectedPageIndex = 1
        Frm_ReportChek.Mnsrf_Bank()
        Frm_ReportChek.Show()
    End Sub

    Private Sub NavBarItem18_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem18.LinkClicked
        'الشيكات المستحقة
        Frm_ReportChek.Close()
        Frm_ReportChek.MdiParent = Me
        Frm_ReportChek.TabPane1.SelectedPageIndex = 2
        Frm_ReportChek.Asthkak_Bank()
        Frm_ReportChek.Show()
    End Sub

    Private Sub NavBarItem19_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem19.LinkClicked
        'الشيكات المستلمة
        Frm_ReportChek.Close()
        Frm_ReportChek.MdiParent = Me
        Frm_ReportChek.TabPane1.SelectedPageIndex = 3
        Frm_ReportChek.Find_Hafza_Estlam()
        Frm_ReportChek.Show()
    End Sub

    Private Sub NavBarItem20_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs)

    End Sub

    Private Sub NavBarItem23_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem23.LinkClicked
        'الشيكات المحصلة
        Frm_ReportChek.Close()
        Frm_ReportChek.MdiParent = Me
        Frm_ReportChek.TabPane1.SelectedPageIndex = 4
        Frm_ReportChek.Find_Hafza_Mohsal()
        Frm_ReportChek.Show()
    End Sub



    Private Sub BarButtonItem201_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem201.ItemClick

        'Frm_ReportCustomer.Close()
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.Find_CustomerFill()
        'vardisplayReport = 0
        'Frm_ReportCustomer.LabelX1.Text = "مديونية العملاء خلال فترة"



        'Frm_ReportCustomer.Close()
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Cerate_FillCustomer()
        Frm_ReportCustomer2.Find_CustomerFill()
        vardisplayReport = 0
        Frm_ReportCustomer2.Lab_NameReport.Text = "تقرير مديونية خلال فترة"
        Frm_ReportCustomer2.run_report()


        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.LabelX2.Enabled = False
        Frm_ReportCustomer2.txt_nameitem.Enabled = False
        Frm_ReportCustomer2.cmd_all.Enabled = False
        NavBarControl2.Visible = False

    End Sub

    Private Sub BarButtonItem75_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem75.ItemClick
        'Frm_ReportCustomer.Close()
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.LabelX1.Text = "تقرير إجمالى الفواتير للعملاء - خلال فترة"
        'Frm_ReportCustomer.All_invoice()
        'vardisplayReport = 9
        'Frm_ReportCustomer.Show()
        'NavBarControl2.Visible = False




        Frm_ReportCustomer.Close()
        Frm_ReportCustomer2.MdiParent = Me
        vardisplayReport = 9
        Frm_ReportCustomer2.All_invoice()
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.Lab_NameReport.Text = "تقرير إجمالى العملاء بالاصناف - خلال فترة"
        Frm_ReportCustomer2.LabelX2.Enabled = True
        Frm_ReportCustomer2.txt_nameitem.Enabled = True
        Frm_ReportCustomer2.cmd_all.Enabled = True
        NavBarControl2.Visible = False

    End Sub



    Private Sub BarButtonItem204_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem204.ItemClick
        'Frm_ReportCustomer.Close()
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.LabelX1.Text = "تقرير متحصلات العملاء خلال فترة"
        'Frm_ReportCustomer.Find_SumCrdit()
        'vardisplayReport = 3
        'Frm_ReportCustomer.Show()
        'NavBarControl2.Visible = False


        'vardisplayReport = 3
        'LabelX1.Text = "تقرير متحصلات العملاء خلال فترة"
        'Find_SumCrdit()
        'GridView1.BestFitColumns()

        vardisplayReport = 3



        Frm_ReportCustomer2.Find_SumCrdit()
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Lab_NameReport.Text = " متحصلات العملاء - خلال فترة"
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.LabelX2.Enabled = True
        Frm_ReportCustomer2.txt_nameitem.Enabled = True
        Frm_ReportCustomer2.cmd_all.Enabled = True
        NavBarControl2.Visible = False
    End Sub

    Private Sub BarButtonItem203_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem203.ItemClick
        'Frm_ReportCustomer.Close()
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.LabelX1.Text = "اذون استلام البضاعة العملاء من المخازن"
        'Frm_ReportCustomer.Find_EstlamCustomer()
        'NavBarControl2.Visible = False
        'vardisplayReport = 6
        'Frm_ReportCustomer.Show()
        'NavBarControl2.Visible = False


        vardisplayReport = 6



        Frm_ReportCustomer2.Find_EstlamCustomer()
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.Lab_NameReport.Text = "اذون استلام البضاعة العملاء من المخازن - خلال فترة"
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.LabelX2.Enabled = True
        Frm_ReportCustomer2.txt_nameitem.Enabled = True
        Frm_ReportCustomer2.cmd_all.Enabled = True
        NavBarControl2.Visible = False
    End Sub

    Private Sub BarButtonItem205_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem205.ItemClick
        vartable = "TB_Phases"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "تعريف مراحل الانتاج"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem190_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem190.ItemClick
        NavBarControl2.Visible = False

        Frm_Azn_AddItem.Close()
        Frm_Azn_AddItem.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        '      Find_NewSalseorder() 'أوامر توريد جديدة
        '      orderNew_JopOrder() 'الاصناف الجديدة المطلوبة للانتاج

    End Sub

    Sub orderNew_JopOrder()
        On Error Resume Next
        Dim varcountnewjoporder As Integer
        sql = "   SELECT        COUNT(Order_NO) AS CountOrder, Compny_Code       FROM dbo.Vw_JopOrderNew GROUP BY Compny_Code   HAVING(Compny_Code = '" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcountnewjoporder = rs("CountOrder").Value : NavBarItem22.Caption = "الاصناف الجديدة المطلوبة " & " " & varcountnewjoporder : NavBarItem22.Appearance.ForeColor = Color.Red Else NavBarItem22.Caption = "الاصناف الجديدة المطلوبة " & " " & "0" : NavBarItem22.Appearance.ForeColor = Color.Black

    End Sub
    Sub Find_NewSalseorder()
        On Error Resume Next
        Dim varordercount As Integer
        sql = "  SELECT  *    from  Vw_CountOrder"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varordercount = rs("CountRequestOrder").Value : NavBarItem1.Caption = "أوامر التوريد فى الانتظار" & " " & varordercount : NavBarItem1.Appearance.ForeColor = Color.Red Else NavBarItem1.Caption = "أوامر التوريد الانتظار" & " " & "0" : NavBarItem1.Appearance.ForeColor = Color.Black
    End Sub

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        'Frm_AznSarf2.OP1.Checked = True
        'Frm_AznSarf2.find_SalseOrder()
        Frm_RequestOrderNoAvilabel.MdiParent = Me
        Frm_RequestOrderNoAvilabel.Show()
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs)
        Frm_OrderNew.Op2.Checked = True
        Frm_OrderNew.find_SalseOrder()
        Frm_OrderNew.MdiParent = Me
        Frm_OrderNew.Show()
    End Sub

    Private Sub NavBarItem26_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs)
        Frm_OrderNew.Op3.Checked = True
        Frm_OrderNew.find_SalseOrder()
        Frm_OrderNew.MdiParent = Me
        Frm_OrderNew.Show()
    End Sub

    Private Sub BarButtonItem206_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem206.ItemClick
        DashboarSalse.MdiParent = Me
        DashboarSalse.Show()



    End Sub

    Private Sub NavBarItem22_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem22.LinkClicked
        Frm_ItemNewProduct.MdiParent = Me
        Frm_ItemNewProduct.Show()
    End Sub

    Private Sub BarButtonItem215_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem215.ItemClick

        'Frm_ReportChek.Close()
        'Frm_ReportChek.MdiParent = Me
        'Frm_ReportChek.Wared_Bank()
        'Frm_ReportChek.Show()
        'Frm_ReportChek.TabPane1.SelectedPageIndex = 0


        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 4
        Frm_Check_Report.Wared_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()

    End Sub

    Private Sub BarButtonItem222_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem222.ItemClick


        Frm_Report_Produact.Close()
        vardisplayReport = 102
        Frm_Report_Produact.Find_Jop_Fill()
        Frm_Report_Produact.MdiParent = Me
        Frm_Report_Produact.Show()



    End Sub

    Private Sub BarButtonItem230_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem230.ItemClick
        Frm_ExportAtt.Close()
        Frm_ExportAtt.MdiParent = Me
        Frm_ExportAtt.Show()
    End Sub

    Private Sub BarButtonItem231_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem231.ItemClick
        NavBarControl2.Visible = False
        Frm_WorkingFllow.Close()
        Frm_WorkingFllow.MdiParent = Me
        Frm_WorkingFllow.Show()
    End Sub

    Private Sub BarButtonItem122_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem122.ItemClick
        Frm_TimeDeprtment.Close()
        Frm_TimeDeprtment.MdiParent = Me
        Frm_TimeDeprtment.Show()
    End Sub

    Private Sub BarButtonItem232_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem232.ItemClick
        vartable = "BD_Vaction"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد نوع التعاقد"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem49_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem49.ItemClick
        NavBarControl2.Visible = False

        Frm_Azn_AddItem.Close()
        Frm_Azn_AddItem.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem.Show()
    End Sub

    Private Sub BarButtonItem126_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem126.ItemClick
        Frm_Att2.Close()
        Frm_Att2.MdiParent = Me
        Frm_Att2.Show()
    End Sub

    Private Sub BarButtonItem235_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem235.ItemClick
      

    End Sub

    Private Sub BarButtonItem236_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem236.ItemClick
        Frm_Gaza.Close()
        Frm_Gaza.MdiParent = Me
        Frm_Gaza.Show()
    End Sub

    Private Sub BarButtonItem237_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem237.ItemClick
        vartable = "BD_TypeMintes"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الصيانة"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem238_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem238.ItemClick


    End Sub

    Private Sub BarButtonItem240_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem240.ItemClick


        frm_MachineAndItem.Close()
        frm_MachineAndItem.MdiParent = Me
        frm_MachineAndItem.Show()
    End Sub

    Private Sub BarButtonItem241_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem241.ItemClick
        Frm_CustomerAndMachine.Close()
        Frm_CustomerAndMachine.MdiParent = Me
        Frm_CustomerAndMachine.Show()
    End Sub

    Private Sub BarButtonItem242_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem242.ItemClick
        vartable = "BD_statusMachine"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "حالات الماكينة"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem248_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem248.ItemClick
        Frm_MentinenceOrder.Close()
        Frm_MentinenceOrder.MdiParent = Me
        Frm_MentinenceOrder.Show()
    End Sub

    Private Sub BarButtonItem245_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem245.ItemClick

        Frm_Contract_M.Close()
        Frm_Contract_M.MdiParent = Me
        Frm_Contract_M.Show()

    End Sub

    Private Sub BarButtonItem246_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem246.ItemClick
        Frm_Order_M.Close()
        Frm_Order_M.MdiParent = Me
        Frm_Order_M.Show()
    End Sub

    Private Sub BarButtonItem249_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem249.ItemClick
        NavBarControl2.Visible = False
        Frm_MveingDriver.Close()
        Frm_MveingDriver.MdiParent = Me
        Frm_MveingDriver.Show()
        NavBarControl2.Visible = False
    End Sub

    Private Sub BarButtonItem251_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem251.ItemClick
        Frm_PriceList.Close()
        Frm_PriceList.MdiParent = Me
        Frm_PriceList.Show()
    End Sub

    Private Sub BarButtonItem253_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem253.ItemClick
        Frm_Bdalat_Emp.Close()
        Frm_Bdalat_Emp.MdiParent = Me
        Frm_Bdalat_Emp.Show()
    End Sub

    Private Sub BarButtonItem254_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem254.ItemClick
        NavBarControl2.Visible = False
        Frm_AznEstlamItem.Close()
        Frm_AznEstlamItem.MdiParent = Me
        Frm_AznEstlamItem.Show()
    End Sub

    Private Sub BarButtonItem255_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem255.ItemClick


        Frm_OpenE3tmad.Close()
        Frm_OpenE3tmad.MdiParent = Me
        Frm_OpenE3tmad.Show()
    End Sub

    Private Sub BarButtonItem258_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem258.ItemClick
        vartable = "TB_TypeEtmad"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أنواع الاعتمادات المستندية"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem257_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem257.ItemClick
        Frm_ShippingData.Close()
        Frm_ShippingData.MdiParent = Me
        Frm_ShippingData.Show()
    End Sub

    Private Sub BarButtonItem260_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem260.ItemClick
        vartable = "TB_TypeExpensess"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أنواع المصاريف"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem256_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem256.ItemClick
        Frm_ExpensessShapping.Close()
        Frm_ExpensessShapping.MdiParent = Me
        Frm_ExpensessShapping.Show()
    End Sub

    Private Sub BarButtonItem261_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem261.ItemClick
        Frm_OpenReport.Close()
        Frm_OpenReport.MdiParent = Me
        Frm_OpenReport.Show()
    End Sub

    Private Sub BarButtonItem262_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem262.ItemClick
        'Form3.Show()
    End Sub

    Private Sub BarButtonItem182_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem182.ItemClick
        Frm_Prcheses_Invoice.Close()
        Frm_Prcheses_Invoice.MdiParent = Me
        Frm_Prcheses_Invoice.Show()
    End Sub

    Private Sub NavBarItem8_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem8.LinkClicked
        'Frm_FristItem.Close()
        'Frm_FristItem.MdiParent = Me
        'Frm_FristItem.com_typeSnd.Text = "تحويل من المخازن"
        'Frm_FristItem.Com_Type.Text = "تحويل مخزن اخر"

        'If Frm_FristItem.Com_Type.Text = "تحويل مخزن اخر" Then Frm_FristItem.LabelX13.Visible = True : Frm_FristItem.txt_namestores2.Visible = True : Frm_FristItem.txt_codestores2.Visible = True : Frm_FristItem.Cmd_LookUpStores.Visible = True



        ''Frm_FristItem.ButtonX3.Visible = False
        'Frm_FristItem.txt_Barcode.Visible = True
        'Frm_FristItem.LabelX6.Visible = True
        'Frm_FristItem.txt_QtyAvalabil.Visible = True
        'Frm_FristItem.Cmd_Save.Visible = True
        'varflagstatus = 1
        'Frm_FristItem.Show()

        FrmGard3.Show()
        FrmGard3.MdiParent = Me
    End Sub

    Private Sub NavBarItem9_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem9.LinkClicked
        ''NavBarControl2.Visible = False

        'Frm_Azn_AddItem2.Close()
        'Frm_Azn_AddItem2.MdiParent = Me
        ''Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        'Frm_Azn_AddItem2.Show()
    End Sub

    Private Sub NavBarItem10_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem10.LinkClicked
        NavBarControl2.Visible = False

        Frm_Azn_AddItem2.Close()
        Frm_Azn_AddItem2.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem2.Show()
    End Sub

    Private Sub NavBarItem11_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs)


        Frm_Azn_AddItem2.Close()
        Frm_Azn_AddItem2.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem2.Show()
    End Sub

    Private Sub BarButtonItem263_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem263.ItemClick
        NavBarControl2.Visible = False
        Frm_AznSarf2.Close()
        Frm_AznSarf2.MdiParent = Me
        Frm_AznSarf2.Show()

    End Sub

    Private Sub BarButtonItem264_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem264.ItemClick
        Frm_Azn_AddItem.Close()
        Frm_Azn_AddItem.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem.Show()
    End Sub



    Private Sub BarButtonItem216_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem216.ItemClick
        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 5
        Frm_Check_Report.Mnsrf_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem217_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem217.ItemClick


        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 7
        Frm_Check_Report.Find_Hafza_Estlam()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()

    End Sub

    Private Sub BarButtonItem267_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem267.ItemClick
        'Frm_ReportChek.Close()
        'Frm_ReportChek.MdiParent = Me
        'Frm_ReportChek.Asthkak_Bank()
        'Frm_ReportChek.Show()
        'Frm_ReportChek.TabPane1.SelectedPageIndex = 2

        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 6
        Frm_Check_Report.Asthkak_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem271_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem271.ItemClick


        Frm_Report_Salse.Close()
        Frm_Report_Salse.MdiParent = Me
        vardisplayReport = 10
        Frm_Report_Salse.Colected_data()
        Frm_Report_Salse.run_report()
        Frm_Report_Salse.Show()

    End Sub

    Private Sub BarButtonItem274_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem274.ItemClick


        Frm_Report_Salse.Close()
        Frm_Report_Salse.MdiParent = Me
        vardisplayReport = 12
        Frm_Report_Salse.All_Salase_Invoice()
        Frm_Report_Salse.Cerate_Invoice_salse()
        Frm_Report_Salse.run_report()
        Frm_Report_Salse.Show()
    End Sub

    Private Sub BarButtonItem273_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem273.ItemClick
        'frm_SaleReport.Close()
        'frm_SaleReport.MdiParent = Me
        ''frm_SaleReport.Asthkak_Bank()

        'frm_SaleReport.Show()
        'frm_SaleReport.TabPane1.SelectedPageIndex = 2


        Frm_Report_Salse.Close()
        Frm_Report_Salse.MdiParent = Me
        vardisplayReport = 11
        Frm_Report_Salse.All_Salase_data()
        Frm_Report_Salse.Cerate_ComitionSalse()
        Frm_Report_Salse.run_report()
        Frm_Report_Salse.Show()
        frm_SaleReport.TabPane1.SelectedPageIndex = 2
    End Sub

    Private Sub BarButtonItem73_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem73.ItemClick
        'Frm_ReportCustomer.Close()
        'vardisplayReport = 7
        'Frm_ReportCustomer.MdiParent = Me
        'Frm_ReportCustomer.LabelX1.Text = "تقرير اعمار المديونية للعملاء - خلال فترة"
        'Frm_ReportCustomer.Custome_Date()
        'NavBarControl2.Visible = False
        'Frm_ReportCustomer.Show()


        vardisplayReport = 7

        Frm_ReportCustomer.Close()
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Custome_Date_Amar()
        Frm_ReportCustomer2.Lab_NameReport.Text = "تقرير أعمار المديونية للعملاء - خلال فترة"
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.LabelX2.Enabled = False
        Frm_ReportCustomer2.txt_nameitem.Enabled = False
        Frm_ReportCustomer2.cmd_all.Enabled = False
        Frm_ReportCustomer2.SimpleButton7.Enabled = True
        Frm_ReportCustomer2.txt_NameCustomer.Enabled = True
        Frm_ReportCustomer2.txt_NameSalse.Enabled = True
        NavBarControl2.Visible = False


    End Sub

    Private Sub BarButtonItem163_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem163.ItemClick
        'Frm_ReportSuppliser.Close()
        'Frm_ReportSuppliser.MdiParent = Me
        'Frm_ReportSuppliser.LabelX1.Text = "تقرير يومية المشتريات - خلال فترة"
        'Frm_ReportSuppliser.Find_SuplisserFill()
        'vardisplayReport3 = 0
        'Frm_ReportSuppliser.Show()



        ReportPrsheses_New.Close()
        vardisplayReport3 = 1
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.SimpleButton5.Enabled = False
        ReportPrsheses_New.SimpleButton4.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem164_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem164.ItemClick
        'Frm_ReportSuppliser.Close()
        'Frm_ReportSuppliser.MdiParent = Me
        'Frm_ReportSuppliser.LabelX1.Text = "تقرير يومية المشتريات من الاصناف  - خلال فترة"
        'Frm_ReportSuppliser.Find_TotalInvoice()
        'vardisplayReport3 = 2
        'Frm_ReportSuppliser.Show()
        ReportPrsheses_New.Close()
        vardisplayReport3 = 2
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = True
        ReportPrsheses_New.SimpleButton5.Enabled = True
        ReportPrsheses_New.SimpleButton4.Enabled = True
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem166_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem166.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 4
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.SimpleButton5.Enabled = False
        ReportPrsheses_New.SimpleButton4.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem169_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem169.ItemClick

        'Frm_ReportSuppliser.Close()
        'Frm_ReportSuppliser.MdiParent = Me
        'Frm_ReportSuppliser.LabelX1.Text = "تقرير اخر سعر شراء من الاصناف للموردين"

        'Frm_ReportSuppliser.Find_SalCustomer()
        'vardisplayReport3 = 5
        'Frm_ReportSuppliser.Show()

        'Frm_ReportSuppliser.GridView1.BestFitColumns()


        ReportPrsheses_New.Close()
        vardisplayReport3 = 5
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.SimpleButton5.Enabled = False
        ReportPrsheses_New.SimpleButton4.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem275_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles خامات.ItemClick

        Frm_AznSarf.Close()
        Frm_AznSarf.MdiParent = Me
        Frm_AznSarf.Show()
    End Sub

    Private Sub BarButtonItem275_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem275.ItemClick

        Frm_HalkData.Close()
        Frm_HalkData.MdiParent = Me
        Frm_HalkData.Show()
    End Sub

    Private Sub BarButtonItem277_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem277.ItemClick
        Frm_PriceListSuppliser.Close()
        Frm_PriceListSuppliser.MdiParent = Me
        Frm_PriceListSuppliser.Show()
    End Sub

    Private Sub BarButtonItem278_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem278.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 3
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = True
        ReportPrsheses_New.SimpleButton5.Enabled = True
        ReportPrsheses_New.SimpleButton4.Enabled = True
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem279_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem279.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 6
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.SimpleButton5.Enabled = False
        ReportPrsheses_New.SimpleButton4.Enabled = False
        ReportPrsheses_New.Show()
    End Sub



    Private Sub BarButtonItem207_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem207.ItemClick
        Frm_Report_Invintory.Close()
        vardisplayReport4 = 2
        Frm_Report_Invintory.MdiParent = Me
        Frm_Report_Invintory.Show()
    End Sub

    Private Sub BarButtonItem208_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem208.ItemClick
        Frm_Report_Invintory.Close()
        vardisplayReport4 = 3
        Frm_Report_Invintory.MdiParent = Me
        Frm_Report_Invintory.Show()
    End Sub

    Private Sub BarButtonItem210_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem210.ItemClick
        Frm_Report_Invintory.Close()
        vardisplayReport4 = 4
        Frm_Report_Invintory.MdiParent = Me
        Frm_Report_Invintory.Show()
    End Sub

    Private Sub BarButtonItem212_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem212.ItemClick
        Frm_Report_Invintory.Close()
        vardisplayReport4 = 5
        Frm_Report_Invintory.MdiParent = Me
        Frm_Report_Invintory.Show()
    End Sub

    Private Sub BarButtonItem281_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem281.ItemClick
        Frm_Status_Amn.Close()
        Frm_Status_Amn.MdiParent = Me
        NavBarControl2.Visible = False
        Frm_Status_Amn.Show()


    End Sub

    Private Sub BarButtonItem192_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem192.ItemClick
        Frm_InvoiceRented.Close()
        Frm_InvoiceRented.MdiParent = Me
        NavBarControl2.Visible = False
        vardisplayReport = 250
        Frm_InvoiceRented.Show()
    End Sub

    Private Sub BarButtonItem282_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem282.ItemClick
        Frm_PriceList_sal.Close()
        vardisplayReport = 251
        Frm_PriceList_sal.MdiParent = Me
        Frm_PriceList_sal.Show()

    End Sub

    Private Sub BarButtonItem283_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem283.ItemClick
        'Audit_Owner.Close()
        Frm_Audit_Owner2.MdiParent = Me
        Frm_Audit_Owner2.Show()



    End Sub

    Private Sub BarButtonItem80_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem80.ItemClick
        vardisplayReport = 8

        Frm_ReportCustomer2.Find_rentedInvoice()
        Frm_ReportCustomer2.run_report()
        Frm_ReportCustomer2.Lab_NameReport.Text = "تقرير مردوادات المبيعات خلال فترة"
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Show()
        Frm_ReportCustomer2.LabelX2.Enabled = True
        Frm_ReportCustomer2.txt_nameitem.Enabled = True
        Frm_ReportCustomer2.cmd_all.Enabled = True
        NavBarControl2.Visible = False
    End Sub

   
    Private Sub BarButtonItem223_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem223.ItemClick
        Frm_Report_Produact.Close()
        vardisplayReport = 101
        Frm_Report_Produact.Find_DayProdact()
        Frm_Report_Produact.MdiParent = Me
        Frm_Report_Produact.Show()
    End Sub

    Private Sub BarButtonItem284_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem284.ItemClick

    End Sub

    Private Sub BarButtonItem224_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem224.ItemClick
        Frm_Report_Produact.Close()
        vardisplayReport = 103
        Frm_Report_Produact.Find_Day()
        Frm_Report_Produact.MdiParent = Me
        Frm_Report_Produact.Show()
    End Sub

  
    Private Sub BarButtonItem218_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem218.ItemClick

    End Sub

    Private Sub BarButtonItem285_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem285.ItemClick
        'Frm_AccountStatement.Close()
        'Frm_AccountStatement.MdiParent = Me
        'Frm_AccountStatement.Show()
    End Sub

    Private Sub BarButtonItem286_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem286.ItemClick
      
    End Sub

    Private Sub BarButtonItem287_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem287.ItemClick
        Frm_ReportSarf.Close()
        Frm_ReportSarf.MdiParent = Me
        Frm_ReportSarf.Show()
    End Sub

    Private Sub BarButtonItem288_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem288.ItemClick
        Frm_Report_Produact.Close()
        vardisplayReport = 104
        Frm_Report_Produact.run_report()
        Frm_Report_Produact.MdiParent = Me
        Frm_Report_Produact.Show()
    End Sub

    Private Sub BarButtonItem289_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem289.ItemClick
        NavBarControl2.Visible = False
        Frm_LookupOrderItem3.Close()
        Frm_LookupOrderItem3.MdiParent = Me
        Frm_LookupOrderItem3.Show()
    End Sub

    Private Sub BarButtonItem290_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem290.ItemClick
        NavBarControl2.Visible = False
        Frm_ProudactionOrder.Close()
        Frm_ProudactionOrder.MdiParent = Me
        Frm_ProudactionOrder.Show()
    End Sub

    Private Sub BarButtonItem291_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem291.ItemClick
        NavBarControl2.Visible = False
        Frm_ProudactionChoose2.Close()
        Frm_ProudactionChoose2.MdiParent = Me
        Frm_ProudactionChoose2.Show()
    End Sub

    Private Sub BarButtonItem292_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem292.ItemClick
        NavBarControl2.Visible = False
        Frm_ProudactionOrder2.Close()
        Frm_ProudactionOrder2.MdiParent = Me
        Frm_ProudactionOrder2.Show()
    End Sub

    Private Sub BarButtonItem300_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem300.ItemClick
        Frm_SettingCostNoneDiract.Close()
        Frm_SettingCostNoneDiract.MdiParent = Me
        Frm_SettingCostNoneDiract.Show()
    End Sub

    Private Sub BarButtonItem306_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem306.ItemClick
        vartable = "BD_BanCostingNoneDiract"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد بنود التكاليف الغير مباشرة"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem304_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem304.ItemClick
        Frm_ShData.Close()
        Frm_ShData.MdiParent = Me
        Frm_ShData.Show()
    End Sub

    Private Sub BarButtonItem307_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem307.ItemClick
        Frm_BankDetils.Close()
        Frm_BankDetils.MdiParent = Me
        Frm_BankDetils.Show()
    End Sub

    Private Sub BarButtonItem308_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem308.ItemClick
        vartable = "TB_ShippingCompny"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "شركات الشحن"
        Frm_GenralData.Show()

    End Sub

    Private Sub BarButtonItem309_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem309.ItemClick
        Frm_PrchesesPO.Close()
        Frm_PrchesesPO.MdiParent = Me
        Frm_PrchesesPO.Show()
    End Sub

    Private Sub BarButtonItem310_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem310.ItemClick
        Frm_ConfirmationOrder.Close()
        Frm_ConfirmationOrder.MdiParent = Me
        Frm_ConfirmationOrder.Show()
    End Sub

    Private Sub BarButtonItem324_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem324.ItemClick

        Frm_ReportExpSh.Close()
        Frm_ReportExpSh.MdiParent = Me
        varcodeBand = 2
        Frm_ReportExpSh.Text = "تقرير بنود المصاريف الاستيرادية"
        Frm_ReportExpSh.Show()

    End Sub

    Private Sub BarButtonItem325_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem325.ItemClick
        Frm_ReportCost.Close()
        Frm_ReportCost.MdiParent = Me
        Frm_ReportCost.Show()
    End Sub

    Private Sub BarButtonItem322_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem322.ItemClick
        Frm_ReportCost.Close()
        Frm_ReportCost.MdiParent = Me
        Frm_ReportCost.Show()
    End Sub

    Private Sub BarButtonItem323_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem323.ItemClick
     
        Frm_ReportExpSh.Close()
        Frm_ReportExpSh.MdiParent = Me
        varcodeBand = 1
        Frm_ReportExpSh.Text = "تقرير تكاليف الضرائب"
        Frm_ReportExpSh.Show()
    End Sub

    Private Sub BarButtonItem326_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem326.ItemClick
      
        Frm_ReportCostItem.Close()
        Frm_ReportCostItem.MdiParent = Me
        Frm_ReportCostItem.Show()
    End Sub

    Private Sub BarButtonItem312_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem312.ItemClick
     
        Frm_ReportDaily.Close()
        Frm_ReportDaily.MdiParent = Me
        Frm_ReportDaily.Show()
    End Sub

    Private Sub BarButtonItem327_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem327.ItemClick

        Frm_PriceList_sal.Close()
        Frm_PriceList_sal.MdiParent = Me
        Frm_PriceList_sal.Show()
    End Sub

    Private Sub BarButtonItem328_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem328.ItemClick
       
    End Sub

    Private Sub BarButtonItem329_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem329.ItemClick
        Frm_ReportCustomer2.Close()
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Show()
    End Sub

    Private Sub BarButtonItem330_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem330.ItemClick
        'analysis_Salse.Show()

        analysis_Salse.MdiParent = Me
        analysis_Salse.Show()
    End Sub

    Private Sub BarButtonItem331_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem331.ItemClick
        'Frm_SalseInvoice.Close()
        'Frm_SalseInvoice.MdiParent = Me
        'Frm_SalseInvoice.Show()
        'varChooseInvoice = 22
        'Frm_SalseInvoice.clear_Groups()
        'Frm_SalseInvoice.press_new()
        'Frm_SalseInvoice.CheckBox3.Visible = False
        'Frm_SalseInvoice.CheckBox4.Visible = False
        'Frm_SalseInvoice.CheckEng.Visible = False
        'Frm_SalseInvoice.CheckNewwithoutlogo.Visible = False
        'Frm_SalseInvoice.CheckNewArbLogo.Visible = False
        'Frm_SalseInvoice.SimpleButton3.Visible = False
        'Frm_SalseInvoice.SimpleButton1.Visible = False
        'Frm_SalseInvoice.SimpleButton7.Visible = False
        'Frm_SalseInvoice.SimpleButton5.Visible = False
        'Frm_SalseInvoice.SimpleButton2.Visible = False
        'Frm_SalseInvoice.Com_NoAzn.Visible = False
        'Frm_SalseInvoice.LabelX31.Visible = False
        'Frm_SalseInvoice.Cmd_PrintInvoice.Visible = False
        'Frm_SalseInvoice.txt_SalseOrder.Visible = False
        'Frm_SalseInvoice.LabelX9.Visible = False
        'Frm_SalseInvoice.txt_OpenGl.Visible = False
        'Frm_SalseInvoice.cmd_OpenGl.Visible = False
        'Frm_SalseInvoice.LabelX33.Visible = False
        'Frm_SalseInvoice.Cmd_DeleteInv.Visible = False
        'Frm_SalseInvoice.RadioButton2.Visible = False
        'Frm_SalseInvoice.RadioButton1.Visible = False
        'Frm_SalseInvoice.Com_Group_Item.Visible = False
        'Frm_SalseInvoice.LabelX25.Visible = False
        'Frm_SalseInvoice.txt_Typeinv.Visible = False
        'Frm_SalseInvoice.LabelX28.Visible = False

        'Frm_SalseInvoice.Cmd_DeleteInv.Visible = False
        'Frm_SalseInvoice.Cmd_RtInvoice.Visible = False
        'Frm_SalseInvoice.Cmd_Delete.Visible = False
        'Frm_SalseInvoice.cmd_Edit.Visible = False
        'Frm_SalseInvoice.cmd_FindItem.Visible = False

        'Frm_SalseInvoice.LabelX1.Visible = False
        'Frm_SalseInvoice.LabelX35.Visible = False
        'Frm_SalseInvoice.LabelX29.Visible = False
        'Frm_SalseInvoice.LabelX6.Visible = False
        'Frm_SalseInvoice.LabelX8.Visible = False
        'Frm_SalseInvoice.LabelX34.Visible = False
        'Frm_SalseInvoice.LabelX23.Visible = False
        'Frm_SalseInvoice.txt_Dis.Visible = False
        'Frm_SalseInvoice.txt_Dis2.Visible = False
        'Frm_SalseInvoice.txt_Ntax2.Visible = False
        'Frm_SalseInvoice.txt_OtherDiscount.Visible = False
        'Frm_SalseInvoice.txt_Ntax3.Visible = False
        'Frm_SalseInvoice.Cmd_LookupSalse.Visible = False

        'Frm_SalseInvoice.txt_AccountNo.Visible = False
        'Frm_SalseInvoice.txt_walletCode.Visible = False
        'Frm_SalseInvoice.LabelX40.Visible = False
        'Frm_SalseInvoice.Com_Stores.Visible = False



        'Frm_SalseInvoice.TabNavigationPage1.PageVisible = False


        'Frm_SalseInvoice.txt_Ntax.Visible = False
        'Frm_SalseInvoice.txt_Tax.Visible = False
        'Frm_SalseInvoice.Txt_TotalAll.Visible = False
        'Frm_SalseInvoice.LabelX10.Visible = False
        'Frm_SalseInvoice.txt_Notes.Visible = False
        'Frm_SalseInvoice.txt_Barcode.Select()


        'Frm_SalseInvoice.LabelX38.Visible = True
        'Frm_SalseInvoice.txt_Barcode.Visible = True
        'Frm_SalseInvoice.LabelX39.Visible = True
        'Frm_SalseInvoice.txt_walletCode.Visible = True
        'Frm_SalseInvoice.txt_walletName.Visible = True
        'Frm_SalseInvoice.Com_Stores.Visible = True
        'Frm_SalseInvoice.LabelX40.Visible = True



        'Frm_SalseInvoice.txt_NameSalse.Text = varnameuser
        'Frm_SalseInvoice.txt_CodeSalse.Text = varcode_User
        'Frm_SalseInvoice.lb_branchName.Text = varNameBranch

        'Frm_InvoiceCashir()

        Frm_InvoiceCashir.MdiParent = Me
        Frm_InvoiceCashir.Show()
    End Sub

    Private Sub BarButtonItem332_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem332.ItemClick
        'Frm_OrderItem.MdiParent = Me
        'Frm_OrderItem.Show()

        Frm_OrderInvintory.MdiParent = Me
        Frm_OrderInvintory.Show()
    End Sub

    Private Sub BarButtonItem334_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem334.ItemClick
        vartable = "BD_TypeSarfStores"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الصرف من المخازن / نوع الاضافة الى المخازن"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem333_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem333.ItemClick
        Frm_AznSarf.MdiParent = Me
        Frm_AznSarf.Show()
        'FrmSarfInvintory_Item.MdiParent = Me
        'FrmSarfInvintory_Item.Show()
    End Sub

    Private Sub BarButtonItem335_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem335.ItemClick
        Frm_ReportStores.Close()
        Frm_ReportStores.MdiParent = Me
        Frm_ReportStores.Show()
    End Sub

    Private Sub BarButtonItem336_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles مرتجع.ItemClick
        Frm_InvoiceCasherRented.MdiParent = Me
        Frm_InvoiceCasherRented.Show()
    End Sub

    Private Sub BarButtonItem337_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem337.ItemClick
        Frm_GardItem2.Close()
        Frm_GardItem2.MdiParent = Me
        Frm_GardItem2.Show()
    End Sub

    Private Sub BarButtonItem338_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem338.ItemClick
        Frm_TransactionHistory.Close()
        Frm_TransactionHistory.Show()
        Frm_TransactionHistory.MdiParent = Me
    End Sub

    Private Sub BarButtonItem339_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem339.ItemClick
        Frm_Prcheses_Invoice_Rented.Close()
        Frm_Prcheses_Invoice_Rented.MdiParent = Me
        Frm_Prcheses_Invoice_Rented.Show()
    End Sub

   

    Private Sub BarButtonItem346_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem346.ItemClick

        'Frm_dataitem2.Close()
        'Frm_dataitem2.MdiParent = Me
        'Frm_dataitem2.Show()



        Frm_ItemDataConfacrtion.Close()
        'Frm_ItemDataConfacrtion.MdiParent = Me
        Frm_ItemDataConfacrtion.Show()

    End Sub

    Private Sub BarButtonItem344_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem344.ItemClick
        'Frm_PanelsTechnicalspecifications.Close()
        'Frm_PanelsTechnicalspecifications.MdiParent = Me
        Frm_PanelsTechnicalspecifications.Show()
    End Sub

    Private Sub BarButtonItem343_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem343.ItemClick

    End Sub

    Private Sub BarButtonItem347_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem347.ItemClick
        Frm_Panels_Price.Show()
    End Sub

    Private Sub BarButtonItem348_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem348.ItemClick
        Frm_addTimevalue.MdiParent = Me
        Frm_addTimevalue.Show()
    End Sub

    Private Sub BarButtonItem349_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem349.ItemClick
        Frm_ExportAtt.Close()
        Frm_ExportAtt.MdiParent = Me
        Frm_ExportAtt.Show()
    End Sub

    Private Sub BarButtonItem234_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem234.ItemClick
        Frm_openmonth.MdiParent = Me
        Frm_openmonth.Show()
    End Sub

    Private Sub BarButtonItem350_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem350.ItemClick
       
    End Sub

    Private Sub BarButtonItem352_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem352.ItemClick
     
    End Sub

    Private Sub BarButtonItem353_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem353.ItemClick
      
    End Sub

    Private Sub BarButtonItem355_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem355.ItemClick
        
    End Sub

    Private Sub BarButtonItem354_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem354.ItemClick
       
    End Sub

    Private Sub BarButtonItem351_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem351.ItemClick
       
    End Sub

    Private Sub BarButtonItem356_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem356.ItemClick
    
    End Sub

    Private Sub BarButtonItem357_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem357.ItemClick
       
    End Sub

    Private Sub BarButtonItem361_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem361.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 4
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المضافة خلال فترة"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem362_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem362.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 5
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المنصرفة خلال فترة"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem363_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem363.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 3
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير مجمع المخازن بالارصدة بتحويلات معامل التحويل"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem365_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem365.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 1
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف السالبة"
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem364_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem364.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 7
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المشتراة فى المخازن شاملة فواتير الشراء"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem366_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem366.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 8
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المشتراة فى المخازن غير شاملة فواتير الشراء"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem367_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem367.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 6
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف تعدت حد الطلب "
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem368_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem368.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 9
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المرتجعة غير شاملة فواتير الارتجاع"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem382_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem382.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 10
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المرتجعة شاملة فواتير الارتجاع"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem383_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem383.ItemClick
        Frm_GardItem2.Close()
        Frm_GardItem2.MdiParent = Me
        Frm_GardItem2.Show()
    End Sub

    Private Sub BarButtonItem379_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem379.ItemClick
        Frm_AllGardInvintory.MdiParent = Me
        Frm_AllGardInvintory.Show()
    End Sub

    Private Sub BarButtonItem384_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem384.ItemClick
        vartable = "BD_JOBNAMES"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المسمى الوظيفى"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem385_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem385.ItemClick
        vartable = "BD_SOCIALSTATUS"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الحالة الاجتماعية"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem386_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem386.ItemClick
        vartable = "BD_QUALIFICATIONS"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المؤهلات"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem387_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem387.ItemClick
        vartable = "BD_DIRCTORAY"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الادارات"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem388_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem388.ItemClick

        vartable = "BD_DEPARTMENTS"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد الاقسام"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem389_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem389.ItemClick
        vartable = "BD_BUILDINGS"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكوادالهناجر"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem390_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem390.ItemClick
        vartable = "BD_TYPEOFCNTRACT"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد نوع التعاقد"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem392_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem392.ItemClick
        vartable = "BD_Gaza"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع الجزاءت"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem393_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem393.ItemClick
        frm_DiscountSalary.MdiParent = Me
        frm_DiscountSalary.Show()
    End Sub

    Private Sub BarButtonItem394_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem394.ItemClick
        Frm_VactionDtat.MdiParent = Me
        Frm_VactionDtat.Show()
    End Sub

    Private Sub BarButtonItem395_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem395.ItemClick
        frm_SalfaHR.MdiParent = Me
        frm_SalfaHR.Show()
    End Sub

    Private Sub BarButtonItem396_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem396.ItemClick
        Frm_FollwUP_HR.MdiParent = Me
        Frm_FollwUP_HR.Show()
        Frm_FollwUP_HR.TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub BarButtonItem397_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem397.ItemClick
        Frm_FollwUP_HR.MdiParent = Me
        Frm_FollwUP_HR.Show()
        Frm_FollwUP_HR.TabPane1.SelectedPageIndex = 2
    End Sub

    Private Sub BarButtonItem398_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem398.ItemClick
        Frm_FollwUP_HR.MdiParent = Me
        Frm_FollwUP_HR.Show()
        Frm_FollwUP_HR.TabPane1.SelectedPageIndex = 1
    End Sub

    Private Sub BarButtonItem399_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem399.ItemClick
        Frm_FollwUP_HR.MdiParent = Me
        Frm_FollwUP_HR.Show()
        Frm_FollwUP_HR.TabPane1.SelectedPageIndex = 3
    End Sub

    Private Sub BarButtonItem400_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem400.ItemClick
        Frm_FollwUP_HR.MdiParent = Me
        Frm_FollwUP_HR.Show()
        Frm_FollwUP_HR.TabPane1.SelectedPageIndex = 4
    End Sub

    Private Sub BarButtonItem404_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem404.ItemClick

        Frm_OrderPrcheses.Show()
    End Sub

    Private Sub BarButtonItem412_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem412.ItemClick
        Frm_ReportCustomer2.MdiParent = Me
        Frm_ReportCustomer2.Show()
    End Sub

    Private Sub BarButtonItem340_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem340.ItemClick

    End Sub

    Private Sub BarButtonItem417_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem417.ItemClick
        'Frm_CustomerFiles.MdiParent = Me
        Frm_CustomerFiles.Show()
    End Sub

    Private Sub BarButtonItem403_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem403.ItemClick
        Frm_ProdctionWork.Show()
    End Sub

    Private Sub BarButtonItem406_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem406.ItemClick
        NavBarControl2.Visible = False

        Frm_Azn_AddItem.Close()
        Frm_Azn_AddItem.MdiParent = Me
        'Frm_Azn_AddItem.Text = "تعريف مراحل الانتاج"
        Frm_Azn_AddItem.Show()
    End Sub

    Private Sub BarButtonItem418_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem418.ItemClick
        Frm_ReportStores.Close()
        Frm_ReportStores.MdiParent = Me
        Frm_ReportStores.Show()
    End Sub

    Private Sub BarButtonItem419_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem419.ItemClick
        ReportPrsheses_New.Close()
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem423_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem423.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 4
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المضافة خلال فترة"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem424_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem424.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 3
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير مجمع المخازن بالارصدة بتحويلات معامل التحويل"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem425_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem425.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 5
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المنصرفة خلال فترة"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem426_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem426.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 1
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف السالبة"
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem427_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem427.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 7
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المشتراة فى المخازن شاملة فواتير الشراء"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem428_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem428.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 8
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المشتراة فى المخازن غير شاملة فواتير الشراء"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem429_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem429.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 6
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف تعدت حد الطلب "
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem430_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem430.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 9
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المرتجعة غير شاملة فواتير الارتجاع"
        Frm_Report_Invintory2021.Show()
    End Sub

    Private Sub BarButtonItem431_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem431.ItemClick
        Frm_Report_Invintory2021.MdiParent = Me
        vardisplayReport4 = 10
        Frm_Report_Invintory2021.GridControl1.DataSource = Nothing
        Frm_Report_Invintory2021.GridView1.Columns.Clear()
        Frm_Report_Invintory2021.Lab_Titil.Text = "تقرير الاصناف المرتجعة شاملة فواتير الارتجاع"
        Frm_Report_Invintory2021.Show()

    End Sub

    Private Sub BarButtonItem432_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem432.ItemClick
        Frm_GardItem2.Close()
        Frm_GardItem2.MdiParent = Me
        Frm_GardItem2.Show()

    End Sub

    Private Sub BarButtonItem433_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem433.ItemClick
        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 4
        Frm_Check_Report.Wared_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem434_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem434.ItemClick
        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 5
        Frm_Check_Report.Mnsrf_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem436_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem436.ItemClick

        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 7
        Frm_Check_Report.Find_Hafza_Estlam()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem435_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem435.ItemClick
        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 6
        Frm_Check_Report.Asthkak_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem437_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem437.ItemClick
        Frm_Check_Report.Close()
        Frm_Check_Report.MdiParent = Me
        var_open_Recipt = 6
        Frm_Check_Report.Asthkak_Bank()
        Frm_Check_Report.Run_report()
        Frm_Check_Report.Show()
    End Sub

    Private Sub BarButtonItem438_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem438.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 1
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem439_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem439.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 2
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = True
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem440_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem440.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 4
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem441_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem441.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 5
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem442_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem442.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 3
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = True
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem443_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem443.ItemClick
        ReportPrsheses_New.Close()
        vardisplayReport3 = 6
        ReportPrsheses_New.MdiParent = Me
        ReportPrsheses_New.txt_nameitem.Enabled = False
        ReportPrsheses_New.Show()
    End Sub

    Private Sub BarButtonItem391_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem391.ItemClick
        vartable = "BD_Vaction"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع الجزاءت"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem444_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem444.ItemClick
        Frm_CashRased.MdiParent = Me
        Frm_CashRased.Show()
    End Sub

    Private Sub BarButtonItem445_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem445.ItemClick
        Frm_ReportStores2.MdiParent = Me
        Frm_ReportStores2.Show()
    End Sub

    Private Sub BarButtonItem446_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem446.ItemClick
        Frm_DashBoardAcc.Close()
        Frm_DashBoardAcc.MdiParent = Me
        Frm_DashBoardAcc.Show()
    End Sub

    Private Sub BarButtonItem447_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem447.ItemClick
        FrmDashBordAll.Close()
        FrmDashBordAll.MdiParent = Me
        FrmDashBordAll.Show()
    End Sub

    Private Sub BarButtonItem449_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem449.ItemClick
        vartable = "Tb_BandHR"
        Frm_GenralData.Close()
        Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "بنود تقيم العاملين"
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem448_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem448.ItemClick
        Frm_BandEmp.Close()
        Frm_BandEmp.MdiParent = Me
        Frm_BandEmp.Show()
    End Sub

    Private Sub BarButtonItem408_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem408.ItemClick
        Frm_FllowUpPriceList.Close()
        Frm_FllowUpPriceList.MdiParent = Me
        Frm_FllowUpPriceList.Show()

    End Sub

    Private Sub BarButtonItem450_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem450.ItemClick
        frm_ReportTypeInvintory.MdiParent = Me
        frm_ReportTypeInvintory.Show()
    End Sub

    Private Sub BarButtonItem451_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem451.ItemClick
        Frm_Cust.MdiParent = Me
        Frm_Cust.Show()
    End Sub

    Private Sub BarButtonItem452_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem452.ItemClick
        Frm_Car.MdiParent = Me
        Frm_Car.Show()
    End Sub

    Private Sub BarButtonItem454_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem454.ItemClick
        Frm_Petrol.MdiParent = Me
        Frm_Petrol.Show()
    End Sub

    Private Sub BarButtonItem453_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem453.ItemClick
        'Frm_Health()

        'Mainmune2.MdiParent = Me
        Mainmune2.Show()
    End Sub

    Private Sub BarButtonItem455_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem455.ItemClick
        DatabaseName = "DB_ECG"
        ServerName = "192.168.1.10" '"osama"
        'ServerName = "192.168.1.3"
        varusername2 = "css"
        varPassword = "omar2007"



        Cnn = New Global.ADODB.Connection
        Cnn.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        Dim cnStr As String = "Provider=SQLOLEDB;Initial Catalog=" & DatabaseName & ";Data Source=" & ServerName & ";" & _
                     "User ID=" & varPassword & ";Password=" & varPassword & ";"
        Try
            Cnn.Open("PROVIDER=MSDASQL;driver={SQL Server};server=" & ServerName & ";uid=" & varusername2 & ";pwd=" & varPassword & ";database=" & DatabaseName & ";")

            MsgBox("تم الاتصال بنجاح", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub BarButtonItem149_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem149.ItemClick
        'Frm_IncomStatment2024()
        Frm_IncomStatment2024.MdiParent = Me
        Frm_IncomStatment2024.Show()
    End Sub

    Private Sub BarButtonItem150_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem150.ItemClick
        'Frm_balnceSheet2024()
        Frm_balnceSheet2024.MdiParent = Me
        Frm_balnceSheet2024.Show()
    End Sub

    Private Sub BarButtonItem457_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem457.ItemClick
        Frm_Upload.Show()

    End Sub

    Private Sub btn_bank_codes_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btn_bank_codes.ItemClick
        vartable = "BD_Bank"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Mef
        Frm_GenralData.Text = "أكواد البنك "
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem460_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem460.ItemClick
        vartable = "BD_Mother_company_name"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = " اسماءالشركات الام "
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem459_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem459.ItemClick
        vartable = "BD_Insurnce_Company_name"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "اسماء الشركات "
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem461_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem461.ItemClick
        vartable = "BD_wasyt"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "اسماء الوسطاء "
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem463_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem463.ItemClick
        vartable = "BD_T7amol_types"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع التحملات "
        Frm_GenralData.Show()
    End Sub

    Private Sub BarButtonItem462_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem462.ItemClick
        vartable = "BD_tghtyat_types"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "انواع التغطيات "
        Frm_GenralData.Show()
    End Sub
End Class
