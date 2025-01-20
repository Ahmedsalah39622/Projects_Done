Public Class Frm_Report_Invintory
    Dim oldDate As Date
    Dim oldDay As Integer
    Private Sub ReportPrsheses_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cerate_data()
        run_report()
    End Sub
    Sub fill_Stores()
        Com_Stores.Items.Clear()

        sql = " SELECT Name FROM     BD_Stores where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Stores.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub
    Sub run_report()
        If vardisplayReport4 = 1 Then
            Dim report As New Gard_ItemAll
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
       
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 2 Then
            Dim report As New Invintory_Day2_Additem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
         
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 3 Then
            'Dim report As New Invintory_Day2_Sarfitem
            'report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")

            'report.X_Date1.Text = txt_date.Value
            'report.X_Date2.Text = txt_date2.Value
            'report.XrLabel29.Text = Com_Stores.Text
            ''report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            'report.CreateDocument()
            'DocumentViewer1.DocumentSource = report

        End If

        If vardisplayReport4 = 4 Then
            Dim report As New Prodauct_Rol
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
            report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If


        If vardisplayReport4 = 5 Then
            Dim report As New Invintory_MinItem
            report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
              report.X_Date1.Text = txt_date.Value
            report.X_Date2.Text = txt_date2.Value
            report.XrLabel29.Text = Com_Stores.Text
            'report.FilterString = "[Supliser_Name] Like '%" & txt_NameSuppliser.Text & "%'   and [Compny_Code] = '" & VarCodeCompny & "' "
            report.CreateDocument()
            DocumentViewer1.DocumentSource = report

        End If

        'If vardisplayReport4 = 6 Then
        '    Dim report As New Prshesses_DateDeliver
        '    If VarCodeCompny = 1 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        '  report.XrPictureBox1.Image = Image.FromFile("c:\logo\1.jpg")
        '    If VarCodeCompny = 2 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        '    If VarCodeCompny = 2 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\2.jpg")
        '    If VarCodeCompny = 3 And ServerName = "server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        '    If VarCodeCompny = 3 And ServerName = "css-server\css" Then report.XrPictureBox1.Image = Image.FromFile("\\server\css2021\logo\3.jpg")
        '    report.X_Date1.Text = txt_date.Value
        '    report.X_Date2.Text = txt_date2.Value
        '    report.XrLabel29.Text = txt_NameSuppliser.Text
        '    'report.XrLabel11.Text = txt_nameitem.Text
        '    report.FilterString = "[Name] Like '%" & txt_NameSuppliser.Text & "%'  and [Compny_Code] = '" & VarCodeCompny & "'  "
        '    report.CreateDocument()
        '    DocumentViewer1.DocumentSource = report

        'End If

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
       

        cerate_data()

        'If vardisplayReport4 = 6 Then
        '    Cerate_Prsheses_DateDelivery()
        '    run_report()
        'End If

    End Sub
    Sub cerate_data()
        If vardisplayReport4 = 1 Then
            Cerate_Day_Invintory()
            run_report()
        End If

        If vardisplayReport4 = 2 Then
            Cerate_Day_Invintory()
            run_report()
        End If

        If vardisplayReport4 = 3 Then
            Cerate_Day_Invintory()
            run_report()
        End If
    End Sub

    Sub Cerate_Day_Invintory()
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
        sql = " DROP VIEW dbo.vw_Day_Invintory"
        rs = Cnn.Execute(sql)
        '=======================================

        sql2 = " CREATE VIEW vw_Day_Invintory AS SELECT        dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name AS NameItem, dbo.BD_GROUPITEMMAIN.Name AS MG, dbo.BD_GroupItem1.Name AS G1, " & _
                "                         dbo.BD_Unit.Name AS UnitName, SUM(dbo.Statement_OfItem.Export) AS Wared, SUM(dbo.Statement_OfItem.Import) AS Mnsrf, SUM(dbo.Statement_OfItem.Export) - SUM(dbo.Statement_OfItem.Import)  " & _
                "                         AS balance, dbo.Statement_OfItem.Compny_Code, dbo.BD_Item.MinOrderItem " & _
                " FROM            dbo.Statement_OfItem INNER JOIN " & _
                "                         dbo.BD_Stores ON dbo.Statement_OfItem.Code_Stores = dbo.BD_Stores.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Stores.Compny_Code INNER JOIN " & _
                "                         dbo.BD_Item ON dbo.Statement_OfItem.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.Statement_OfItem.NoItem = dbo.BD_Item.Code INNER JOIN " & _
                "                         dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code AND dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code INNER JOIN " & _
                "                         dbo.BD_GroupItem1 ON dbo.BD_Item.CodeGroupItem1 = dbo.BD_GroupItem1.Code AND dbo.BD_Item.Compny_Code = dbo.BD_GroupItem1.Compny_Code INNER JOIN " & _
                "                         dbo.TB_TypeBill ON dbo.Statement_OfItem.TypeD = dbo.TB_TypeBill.Code INNER JOIN " & _
                "                         dbo.BD_Unit ON dbo.Statement_OfItem.Code_Unit = dbo.BD_Unit.Code AND dbo.Statement_OfItem.Compny_Code = dbo.BD_Unit.Compny_Code " & _
                " WHERE        (dbo.Statement_OfItem.DateMoveM >= CONVERT(DATETIME, '" & vardate & "', 102)) AND (dbo.Statement_OfItem.DateMoveM <= CONVERT(DATETIME, '" & vardate2 & "', 102)) " & _
                " GROUP BY dbo.BD_Stores.Name, dbo.Statement_OfItem.NoItem, dbo.BD_Item.Ex_Item, dbo.BD_Item.Name, dbo.BD_GROUPITEMMAIN.Name, dbo.BD_GroupItem1.Name, dbo.BD_Unit.Name,  " & _
                "        dbo.Statement_OfItem.Compny_Code, dbo.BD_Item.MinOrderItem " & _
                "        HAVING(dbo.Statement_OfItem.Compny_Code = '" & VarCodeCompny & "') "



        rs = Cnn.Execute(sql2)


    End Sub


    
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub txt_NameSuppliser_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        VarOpenlookup2 = 242401
        varcode_form = 242401
        Frm_LookUpCustomer.Find_Suppliser()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub txt_NameSuppliser_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Com_Stores.Text = ""
        run_report()
    End Sub

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_nameitem.ButtonClick
        varcode_form = 25011
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

 
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        txt_nameitem.Text = ""
        run_report()
    End Sub

  
    Private Sub txt_nameitem_EditValueChanged(sender As Object, e As EventArgs) Handles txt_nameitem.EditValueChanged

    End Sub
End Class