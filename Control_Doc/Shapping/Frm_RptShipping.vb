Public Class Frm_RptShipping
    Dim oldDate As Date
    Dim oldDay As Integer
    Dim vardate As String
    Dim vardate2, vardatetest1, vardatetest2 As String
    Private Sub Frm_RptShipping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

     

        If varprintEx = 1 Then
            Dim report As New Rpt_Exp_Ship
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.Lab_Total.Text = Frm_ShData.txt_totalExpenses.Text
            report.Lab_Tax.Text = Frm_ShData.txt_TotalTax.Text
            report.Lab_CostMasg.Text = Frm_ShData.Txt_Cost_Masg.Text

            report.FilterString = "[No_Certifect] = '" & Frm_ShData.txt_Nocerti2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If

        If varprintEx = 2 Then
            Dim report As New Rpt_CostItemShip
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

           

            report.FilterString = "[No_Certifect] = '" & Frm_ShData.txt_Nocerti2.Text & "'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If




        If varprintEx = 3 Then
            oldDate = Frm_ReportCost.txt_date.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

            Dim d As Date
            Date.TryParse(Frm_ReportCost.txt_date.Value, d)
            var_Month_no = d.Month
            var_Year_no = d.Year
            vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
            '=====================================================================date2

            oldDate = Frm_ReportCost.txt_date2.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


            Dim d2 As Date
            Date.TryParse(Frm_ReportCost.txt_date2.Value, d2)
            var_Month_no = d2.Month
            var_Year_no = d2.Year

            vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay


            vardatetest1 = "#" + vardate + "#"
            vardatetest2 = "#" + vardate2 + "#"
            Dim report As New Rpt_CostItemShip_Date
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.lab_date1.Text = Frm_ReportCost.txt_date.Text
            report.lab_date2.Text = Frm_ReportCost.txt_date2.Text

            report.FilterString = "[Supliser_Name] Like '%" & Frm_ReportCost.Com_SuppliserName.Text & "%'  and [NameShiping] Like '%" & Frm_ReportCost.Com_Shipping.Text & "%'  and [City] Like '%" & Frm_ReportCost.Com_CityName.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "'  and [PolicyDate] Between(" & vardatetest1 & ", " & vardatetest2 & ") "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If varprintEx = 4 Then
            oldDate = Frm_ReportExpSh.txt_date.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

            Dim d As Date
            Date.TryParse(Frm_ReportExpSh.txt_date.Value, d)
            var_Month_no = d.Month
            var_Year_no = d.Year
            vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
            '=====================================================================date2

            oldDate = Frm_ReportExpSh.txt_date2.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


            Dim d2 As Date
            Date.TryParse(Frm_ReportExpSh.txt_date2.Value, d2)
            var_Month_no = d2.Month
            var_Year_no = d2.Year

            vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay


            vardatetest1 = "#" + vardate + "#"
            vardatetest2 = "#" + vardate2 + "#"
            Dim report As New Rpt_Expensses_Date
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.lab_date1.Text = Frm_ReportExpSh.txt_date.Text
            report.lab_date2.Text = Frm_ReportExpSh.txt_date2.Text
            report.Lab_Suppliser.Text = Frm_ReportExpSh.Com_SuppliserName.Text
            report.Lab_ShName.Text = Frm_ReportExpSh.Com_Shipping.Text
            report.Lab_Terms.Text = Frm_ReportExpSh.Com_DervilyTerms.Text


            report.FilterString = " [Acc] Like '%" & Frm_ReportExpSh.com_Exp.Text & "%' and [supplisername] Like '%" & Frm_ReportExpSh.Com_SuppliserName.Text & "%'  and [NameShipping] Like '%" & Frm_ReportExpSh.Com_Shipping.Text & "%'     and [Compny_Code] = '" & VarCodeCompny & "' and terms_of_delivery like '%" & Frm_ReportExpSh.Com_DervilyTerms.Text & "%' and [PolicyDate] Between(" & vardatetest1 & ", " & vardatetest2 & ") "

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If




        If varprintEx = 5 Then
            oldDate = Frm_ReportExpSh.txt_date.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

            Dim d As Date
            Date.TryParse(Frm_ReportExpSh.txt_date.Value, d)
            var_Month_no = d.Month
            var_Year_no = d.Year
            vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
            '=====================================================================date2

            oldDate = Frm_ReportExpSh.txt_date2.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


            Dim d2 As Date
            Date.TryParse(Frm_ReportExpSh.txt_date2.Value, d2)
            var_Month_no = d2.Month
            var_Year_no = d2.Year

            vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay


            vardatetest1 = "#" + vardate + "#"
            vardatetest2 = "#" + vardate2 + "#"
            Dim report As New Rpt_Expensses_Date2
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.lab_date1.Text = Frm_ReportExpSh.txt_date.Text
            report.lab_date2.Text = Frm_ReportExpSh.txt_date2.Text
            report.Lab_Suppliser.Text = Frm_ReportExpSh.Com_SuppliserName.Text
            report.Lab_ShName.Text = Frm_ReportExpSh.Com_Shipping.Text
            report.Lab_Terms.Text = Frm_ReportExpSh.Com_DervilyTerms.Text


            report.FilterString = " [Acc] Like '%" & Frm_ReportExpSh.com_Exp.Text & "%' and [supplisername] Like '%" & Frm_ReportExpSh.Com_SuppliserName.Text & "%'  and [NameShipping] Like '%" & Frm_ReportExpSh.Com_Shipping.Text & "%'     and [Compny_Code] = '" & VarCodeCompny & "' and terms_of_delivery like '%" & Frm_ReportExpSh.Com_DervilyTerms.Text & "%' and [PolicyDate] Between(" & vardatetest1 & ", " & vardatetest2 & ") "

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


        If varprintEx = 6 Then
            oldDate = Frm_ReportCostItem.txt_date.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)

            Dim d As Date
            Date.TryParse(Frm_ReportCostItem.txt_date.Value, d)
            var_Month_no = d.Month
            var_Year_no = d.Year
            vardate = var_Year_no & "-" & var_Month_no & "-" & oldDay
            '=====================================================================date2

            oldDate = Frm_ReportCostItem.txt_date2.Value
            oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)


            Dim d2 As Date
            Date.TryParse(Frm_ReportCostItem.txt_date2.Value, d2)
            var_Month_no = d2.Month
            var_Year_no = d2.Year

            vardate2 = var_Year_no & "-" & var_Month_no & "-" & oldDay


            vardatetest1 = "#" + vardate + "#"
            vardatetest2 = "#" + vardate2 + "#"
            Dim report As New Rpt_CostItem
            If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")

            report.lab_date1.Text = Frm_ReportCostItem.txt_date.Text
            report.lab_date2.Text = Frm_ReportCostItem.txt_date2.Text
            report.Lab_Suppliser.Text = Frm_ReportCostItem.Com_SuppliserName.Text
            report.Lab_ShName.Text = Frm_ReportCostItem.Com_Shipping.Text


            report.FilterString = "   [NGroup] Like '%" & Trim(Frm_ReportCostItem.com_GroupItemName.Text) & "%' and  [Name] Like '%" & Frm_ReportCostItem.com_ItemName.Text & "%'  and [NameShiping] Like '%" & Frm_ReportCostItem.Com_Shipping.Text & "%'     and [Compny_Code] = '" & VarCodeCompny & "' and [PolicyDate] Between(" & vardatetest1 & ", " & vardatetest2 & ") "

            report.CreateDocument()
            DocumentViewer1.DocumentSource = report
        End If


    End Sub
End Class