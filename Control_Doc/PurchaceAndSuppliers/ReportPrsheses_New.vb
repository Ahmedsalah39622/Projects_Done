Public Class ReportPrsheses_New
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub ReportPrsheses_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        run_report()
    End Sub
    Sub run_report()
        If vardisplayReport3 = 1 Then
            Dim report As New Prshesses_Day2
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport3 = 2 Then
            Dim report As New Invintory_Item
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            report.XrLabel11.Text = txt_nameitem.Text
            report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'  and [Name] Like '%" & txt_nameitem.Text & "%'  and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport3 = 3 Then
            Dim report As New Prshesses_PO
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            report.XrLabel11.Text = txt_nameitem.Text
            report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  and [NameItem] Like '%" & txt_nameitem.Text & "%'  and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport3 = 4 Then
            Dim report As New Prshesses_SumCredit
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            'report.XrLabel11.Text = txt_nameitem.Text
            report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If



        If vardisplayReport3 = 5 Then
            Dim report As New Prshesses_LastPrice
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            'report.XrLabel11.Text = txt_nameitem.Text
            report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  and [NameItem] Like '%" & txt_nameitem.Text & "%'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport3 = 6 Then
            Dim report As New Prshesses_DateDeliver
            'If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
          report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            'If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
            'If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            'If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = txt_NameSuppliser.Text
            'report.XrLabel11.Text = txt_nameitem.Text
            report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  and [Compny_Code] = '" & VarCodeCompny & "'  "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If vardisplayReport3 = 1 Then
            Cerate_DayPrsheses()
            run_report()
        End If

        If vardisplayReport3 = 2 Then
            Cerate_DayPrsheses_item()
            run_report()
        End If

        If vardisplayReport3 = 3 Then
            Cerate_PO()
            run_report()
        End If

        If vardisplayReport3 = 4 Then
            Cerate_SumCridit()
            run_report()
        End If



        If vardisplayReport3 = 5 Then
            Cerate_LastPrice()
            run_report()
        End If

        If vardisplayReport3 = 6 Then
            Cerate_Prsheses_DateDelivery()
            run_report()
        End If

    End Sub


    Sub Cerate_SumCridit()

        sql = " DROP VIEW dbo.vw_Day_SumCredit"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = "  CREATE VIEW vw_Day_SumCredit AS SELECT        dbo.vw_suppliser_invoice.Customer_No, dbo.St_SuppliserData.Supliser_Name  as name, dbo.vw_suppliser_invoice.aa, iif(dbo.TB_Expenses.Expenses_Value_EGP is null,'0',dbo.TB_Expenses.Expenses_Value_EGP ) as value,dbo.vw_suppliser_invoice.aa -  iif(dbo.TB_Expenses.Expenses_Value_EGP is null,'0',dbo.TB_Expenses.Expenses_Value_EGP )  as rem " & _
                " FROM            dbo.vw_suppliser_invoice INNER JOIN " & _
                "                         dbo.St_SuppliserData ON dbo.vw_suppliser_invoice.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND  " & _
                "                         dbo.vw_suppliser_invoice.Compny_Code = dbo.St_SuppliserData.Compny_Code LEFT OUTER JOIN " & _
                "                         dbo.TB_Expenses ON dbo.St_SuppliserData.Supliser_AccountNo = dbo.TB_Expenses.AccountNo1 "

        rs = Cnn.Execute(sql2)


    End Sub


    Sub Cerate_LastPrice()

        sql = " DROP VIEW dbo.vw_Day_LastPrice"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = "  CREATE VIEW vw_Day_LastPrice AS  SELECT        dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name as NameItem, dbo.BD_Unit.Name AS unit, dbo.TB_Detalis_InvoicePrcheses.Price_Item, MAX(dbo.TB_Header_InvoicePrcheses.InvoiceDate) AS Dateprcheses, " & _
                "                         dbo.BD_GROUPITEMMAIN.Name AS GM, dbo.St_SuppliserData.Supliser_Name as Name " & _
                " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
                "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo AND  " & _
                "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.TB_Detalis_InvoicePrcheses.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
                "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code INNER JOIN " & _
                "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND " & _
                "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.St_SuppliserData.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Unit.Compny_Code " & _
                "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) and (dbo.St_SuppliserData.Compny_Code = '" & VarCodeCompny & "') " & _
                " GROUP BY dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.St_SuppliserData.Supliser_Name, dbo.BD_Unit.Name "



        rs = Cnn.Execute(sql2)


    End Sub



    Sub Cerate_DayPrsheses()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_Day_Prsheses"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = "  CREATE VIEW vw_Day_Prsheses AS  SELECT        dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Header_InvoicePrcheses.InvoiceDate, SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) AS Total_Ivoice, " & _
        "                         SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) * tax_n / 100 AS tax, SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) + SUM(dbo.TB_Detalis_InvoicePrcheses.Total_Item) * 14 / 100 AS totalpr, " & _
        " dbo.St_SuppliserData.Supliser_FileNoTax, dbo.TB_Header_InvoicePrcheses.tax_n, dbo.TB_Header_InvoicePrcheses.Compny_Code " & _
        " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
        "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo INNER JOIN " & _
        "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo " & _
        "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) " & _
        " GROUP BY dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.St_SuppliserData.Supliser_FileNoTax, dbo.TB_Header_InvoicePrcheses.tax_n, dbo.TB_Header_InvoicePrcheses.Compny_Code " & _
        " HAVING        (dbo.TB_Header_InvoicePrcheses.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoicePrcheses.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        rs = Cnn.Execute(sql2)


    End Sub


    Sub Cerate_StatmentAcc()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_StatmentAcc"
        rs = Cnn.Execute(sql)
        '=======================================
        sql2 = " CREATE VIEW vw_StatmentAcc AS   SELECT        dbo.vw_over.No_Sand, dbo.vw_over.DateMoveM, dbo.vw_over.Discription, ROUND(dbo.vw_over.Debit_EGP, 2) AS DE, ROUND(dbo.vw_over.Cridit_EGP, 2) AS Cr, ROUND(dbo.vw_over.Balance_Cur_EGP, 2) " & _
                "                         AS R, dbo.TB_TypeBill.Type_Bill, dbo.TB_TypeBill.Code " & _
                " FROM            dbo.vw_over INNER JOIN " & _
                "                         dbo.BD_Currency ON dbo.vw_over.CruunceyNo = dbo.BD_Currency.Code AND dbo.vw_over.Compny_Code = dbo.BD_Currency.Compny_Code LEFT OUTER JOIN " & _
                "                         dbo.Vw_CostcenterAll ON dbo.vw_over.CostCenterNo = dbo.Vw_CostcenterAll.Code AND dbo.vw_over.Compny_Code = dbo.Vw_CostcenterAll.Compny_Code LEFT OUTER JOIN " & _
                "                         dbo.TB_TypeBill ON dbo.vw_over.TypeBill = dbo.TB_TypeBill.Code " & _
                " WHERE        (dbo.vw_over.Compny_Code = '" & VarCodeCompny & "') AND (dbo.vw_over.AccountNo ='" & varcodesuppliser & "') AND (dbo.vw_over.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND  " & _
                "                         (dbo.vw_over.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        rs = Cnn.Execute(sql2)


    End Sub
    Sub Cerate_Prsheses_DateDelivery()
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
        '=============================================
        sql = " DROP VIEW dbo.Vw_PO_DateDelivery"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = " CREATE VIEW Vw_PO_DateDelivery AS  SELECT        dbo.TB_Header_PO2.Order_Stores_NO, dbo.TB_Header_PO2.Order_Prcheses, dbo.Find_Suppliser2.Name, dbo.TB_Header_PO2.Order_Date_stores, dbo.TB_Header_PO2.PO_Deliver_Date, " & _
               "                         dbo.TB_Header_PO2.CountDay_T, dbo.TB_Header_PO2.Paid_Type, dbo.TB_Header_PO2.Compny_Code, iif(dbo.TB_Header_PO2.Type_OrderPrcheses=0,'داخلى','خارجى') as type " & _
               " FROM            dbo.TB_Header_PO2 INNER JOIN " & _
               "                         dbo.Find_Suppliser2 ON dbo.TB_Header_PO2.Compny_Code = dbo.Find_Suppliser2.Compny_Code AND dbo.TB_Header_PO2.Code_Supliser = dbo.Find_Suppliser2.Code " & _
               " WHERE        (dbo.TB_Header_PO2.Order_Date_stores >= CONVERT(DATETIME,  '" & vardate & "', 102)) and   (dbo.TB_Header_PO2.Order_Date_stores <= CONVERT(DATETIME,  '" & vardate2 & "', 102)) "



        rs = Cnn.Execute(sql2)


    End Sub
    Sub Cerate_DayPrsheses_item()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_Day_Prsheses_item"
        rs = Cnn.Execute(sql)
        '======================================================

        sql2 = " CREATE VIEW vw_Day_Prsheses_item AS  SELECT        dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name, " & _
        "                         dbo.TB_Detalis_InvoicePrcheses.Quntity, dbo.BD_Unit.Name AS unit, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.TB_Detalis_InvoicePrcheses.Total_Item, dbo.BD_GROUPITEMMAIN.Name AS GM,dbo.TB_Header_InvoicePrcheses.Compny_Code " & _
        " FROM            dbo.TB_Header_InvoicePrcheses INNER JOIN " & _
        "                         dbo.TB_Detalis_InvoicePrcheses ON dbo.TB_Header_InvoicePrcheses.Ser_InvoiceNo = dbo.TB_Detalis_InvoicePrcheses.Ser_InvoiceNo AND " & _
        "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.TB_Detalis_InvoicePrcheses.Compny_Code INNER JOIN " & _
        "                         dbo.St_SuppliserData ON dbo.TB_Header_InvoicePrcheses.Customer_No = dbo.St_SuppliserData.Supliser_AccountNo AND  " & _
        "                         dbo.TB_Header_InvoicePrcheses.Compny_Code = dbo.St_SuppliserData.Compny_Code INNER JOIN " & _
        "                         dbo.BD_Item ON dbo.TB_Detalis_InvoicePrcheses.No_Item = dbo.BD_Item.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Item.Compny_Code INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Detalis_InvoicePrcheses.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detalis_InvoicePrcheses.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
        "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code " & _
        "        WHERE(dbo.TB_Header_InvoicePrcheses.Invoice_Status = 1) " & _
        " GROUP BY dbo.TB_Header_InvoicePrcheses.Ext_InvoiceNo, dbo.TB_Header_InvoicePrcheses.InvoiceDate, dbo.St_SuppliserData.Supliser_Name, dbo.TB_Detalis_InvoicePrcheses.No_Item, dbo.BD_Item.Name,  " & _
        "        dbo.TB_Detalis_InvoicePrcheses.Quntity, dbo.BD_Unit.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.TB_Detalis_InvoicePrcheses.Price_Item, dbo.TB_Detalis_InvoicePrcheses.Total_Item,dbo.TB_Header_InvoicePrcheses.Compny_Code " & _
        " HAVING        (dbo.TB_Header_InvoicePrcheses.InvoiceDate >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_InvoicePrcheses.InvoiceDate <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "
        rs = Cnn.Execute(sql2)


    End Sub

    Sub Cerate_PO()
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
        '=============================================
        sql = " DROP VIEW dbo.vw_PO_Detils"
        rs = Cnn.Execute(sql)
        '======================================================


        sql2 = " CREATE VIEW vw_PO_Detils AS  SELECT        dbo.TB_Header_PO2.Order_Stores_NO, dbo.TB_Header_PO2.Order_NO, dbo.TB_Header_PO2.Type_OrderPrcheses, dbo.TB_Header_PO2.PO_Deliver_Date, dbo.TB_Header_PO2.Compny_Code, " & _
   "                         dbo.TB_Header_PO2.Code_Supliser, dbo.Find_Suppliser2.Name, dbo.TB_Header_PO2.Notes, dbo.TB_Header_PO2.CountDay_T, dbo.TB_Header_PO2.Paid_Type, dbo.TB_Detils_PO2.No_Item,  " & _
   "                         dbo.BD_Item.Name AS NameItem, dbo.TB_Detils_PO2.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_PO2.Price_Item, dbo.TB_Detils_PO2.Total_Item, dbo.BD_Currency.Name AS Cur,  " & _
   "        dbo.TB_Detils_PO2.Rat " & _
   " FROM            dbo.TB_Header_PO2 INNER JOIN " & _
   "                         dbo.TB_Detils_PO2 ON dbo.TB_Header_PO2.Ser_Order_Stores = dbo.TB_Detils_PO2.Ser_Order_Stores AND dbo.TB_Header_PO2.Compny_Code = dbo.TB_Detils_PO2.Compny_Code INNER JOIN " & _
   "                         dbo.Find_Suppliser2 ON dbo.TB_Header_PO2.Compny_Code = dbo.Find_Suppliser2.Compny_Code AND dbo.TB_Header_PO2.Code_Supliser = dbo.Find_Suppliser2.Code INNER JOIN " & _
   "                         dbo.BD_Item ON dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_PO2.No_Item = dbo.BD_Item.Code INNER JOIN " & _
   "                         dbo.BD_Unit ON dbo.TB_Detils_PO2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
   "                         dbo.BD_Currency ON dbo.TB_Detils_PO2.Code_Cur = dbo.BD_Currency.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Currency.Compny_Code " & _
   " GROUP BY dbo.TB_Header_PO2.Order_Stores_NO, dbo.TB_Header_PO2.Type_OrderPrcheses, dbo.TB_Header_PO2.PO_Deliver_Date, dbo.TB_Header_PO2.Compny_Code, dbo.TB_Header_PO2.Code_Supliser,  " & _
   "        dbo.Find_Suppliser2.Name, dbo.TB_Header_PO2.Notes, dbo.TB_Header_PO2.CountDay_T, dbo.TB_Header_PO2.Paid_Type, dbo.TB_Header_PO2.Order_NO, dbo.TB_Detils_PO2.No_Item, dbo.BD_Item.Name, " & _
   "        dbo.TB_Detils_PO2.Quntity, dbo.BD_Unit.Name, dbo.TB_Detils_PO2.Price_Item, dbo.TB_Detils_PO2.Total_Item, dbo.BD_Currency.Name, dbo.TB_Detils_PO2.Rat " & _
   " HAVING        (dbo.TB_Header_PO2.PO_Deliver_Date >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.TB_Header_PO2.PO_Deliver_Date <= CONVERT(DATETIME, '" & vardate2 & "', 102)) "

        rs = Cnn.Execute(sql2)


    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub txt_NameSuppliser_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameSuppliser.ButtonClick
        VarOpenlookup2 = 242401
        varcode_form = 242401
        Frm_LookUpCustomer.Find_Suppliser()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_NameSuppliser_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameSuppliser.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txt_NameSuppliser.Text = ""
        run_report()
    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 250
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameitem.EditValueChanged

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        txt_nameitem.Text = ""
        run_report()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click


        Cerate_StatmentAcc()

        Dim report As New CartItemRpt
        If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
      report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        report.X_Date1.Text = txt_date.Value
        report.X_Date2.Text = txt_date2.Value
        report.XrLabel29.Text = txt_NameSuppliser.Text
        'report.XrLabel11.Text = txt_nameitem.Text
        report.FilterString = "[AccountNo] = '" & varcodesuppliser & "'  and [Compny_Code] = '" & VarCodeCompny & "'  "
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

    End Sub

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked

        vardisplayReport3 = 1

        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        SimpleButton4.Enabled = False
        run_report()
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        vardisplayReport3 = 2

        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        SimpleButton4.Enabled = False
        run_report()
    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        vardisplayReport3 = 4

        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        SimpleButton4.Enabled = False
        run_report()
    End Sub

    Private Sub NavBarItem4_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
      

        vardisplayReport3 = 5

        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        SimpleButton4.Enabled = False
        run_report()
    End Sub

    Private Sub NavBarItem5_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
   

        vardisplayReport3 = 3

        txt_nameitem.Enabled = True
        SimpleButton5.Enabled = True
        SimpleButton4.Enabled = True
        run_report()
    End Sub

    Private Sub NavBarItem6_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem6.LinkClicked
     


        vardisplayReport3 = 6

        txt_nameitem.Enabled = False
        SimpleButton5.Enabled = False
        SimpleButton4.Enabled = False
        run_report()
    End Sub
End Class