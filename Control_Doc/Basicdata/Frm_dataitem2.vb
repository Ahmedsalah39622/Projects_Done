Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports System.Windows.Controls

Public Class Frm_dataitem2
    Dim varunit1, varunit2, varunit3, varopphzigalItem, varopphzigalItem2, varcode_Matril As Integer
    Dim VarTypeofsize, varcityCode, varcodeVendor, varcodeIndusrty As Integer

    Private Sub Frm_ScanData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'On Error Resume Next
        'TODO: This line of code loads data into the 'DataSet1.VW_FINDDATAITEM2' table. You can move, or remove it, as needed.
        'Me.VW_FINDDATAITEM2TableAdapter.Fill(Me.DataSet1.VW_FINDDATAITEM2)
        'TODO: This line of code loads data into the 'DB_ERP2.BD_ITEM' table. You can move, or remove it, as needed.
        'Me.BD_ITEMTableAdapter.Fill(Me.DB_ERP2.BD_ITEM)
        'TODO: This line of code loads data into the 'DB_ERP_CssDataSet.BD_ITEM' table. You can move, or remove it, as needed.
        'Me.BD_ITEMTableAdapter.Fill(Me.DB_ERP_CssDataSet.BD_ITEM)
        Search()
        'Search2()
        Find_data()
        fill_listunit()
        fill_listCity()
        fill_listTypeOfSize()
        fill_Indusrty()
        txt_TypeItem.Items.Add("مستورد")
        txt_TypeItem.Items.Add("محلى")

        'txt_CityItem.Items.Add("Turkey")
        'txt_CityItem.Items.Add("Egypt")
        'txt_CityItem.Items.Add("مصر")
        'txt_CityItem.Items.Add("هند")

        
    End Sub
  
    Sub fill_listunit()
        Com_Unit1.Items.Clear()
        Com_Unit2.Items.Clear()
        Com_Unit3.Items.Clear()
        sql = "SELECT     Name " & _
        " FROM         BD_Unit where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit1.Items.Add(rs("Name").Value)
            Com_Unit2.Items.Add(rs("Name").Value)
            Com_Unit3.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub


    Sub fill_listCity()
        txt_CityItem.Items.Clear()

        sql = "SELECT     Name " & _
        " FROM         BD_CITIES where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_CityItem.Items.Add(rs("Name").Value)

            rs.MoveNext()
        Loop
    End Sub


    Sub fill_listTypeOfSize()
        txt_TypeItem.Items.Clear()

        sql = "SELECT     Name " & _
        " FROM         BD_TypeOfSize where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_TypeItem.Items.Add(rs("Name").Value)

            rs.MoveNext()
        Loop
    End Sub
    Sub Find_data()
        'On Error Resume Next

        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
        '            "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        'con.ConnectionString = ss
        'con.Open()

        'sql = "SELECT        BD_ITEM.Code, BD_ITEM.Name AS NameItem, BD_GROUPITEMMAIN.Name AS Name_Group, BD_GroupItem1.Name AS Name_Group2 " & _
        '   " FROM            BD_ITEM LEFT OUTER JOIN " & _
        '   "                         BD_GroupItem1 ON BD_ITEM.CodeGroupItem1 = BD_GroupItem1.Code LEFT OUTER JOIN " & _
        '   "                         BD_GROUPITEMMAIN ON BD_ITEM.CodeGroupItemMain = BD_GROUPITEMMAIN.code "

        'Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)

        'Dim ds As New DataSet()

        'da.Fill(ds)

        'GridControl1.DataSource = ds.Tables(0)

        'GridView1.Columns(0).Caption = "الكود"
        'GridView1.Columns(1).Caption = "أسم الصنف"
        'GridView1.Columns(2).Caption = "المجموعة الرئيسية"
        'GridView1.Columns(3).Caption = "الموديل"
        'GridView1.Columns(0).Width = "50"
        'GridView1.Columns(1).Width = "150"
        'GridView1.Columns(2).Width = "50"
        'GridView1.Columns(3).Width = "50"



        'ds = Nothing
        'da = Nothing
        'con.Close()
        'con.Dispose()
    End Sub






    Private Sub txt_CodeG_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)

        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 1
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_CodeG1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "BD_GROUPITEM1"
        VarOpenlookup = 2
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_CodeG2_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "BD_GROUPITEM2"
        VarOpenlookup = 3
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Exitem.Text) = 0 Then MsgBox("من فضلك ادخل رقم التوصيف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_CodeG.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة الرئيسية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG1.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG2.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(Com_Unit1.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit2.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit3.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount1.Text) = 0 Then MsgBox("من فضلك ادخل محتوى الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount2.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount3.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        If Len(txt_TypeItem.Text) = 0 Then MsgBox("من فضلك ادخل نوع الصنف  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "SELECT     * " & _
        " FROM         BD_ITEM WHERE     (code = " & txt_Code.Text & ")"
        'Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        Else





            '======================================Unit1
            sql = "SELECT     * " & _
            " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit1.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varunit1 = rs("Code").Value

            '======================================Unit2
            sql = "SELECT     * " & _
            " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit2.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varunit2 = rs("Code").Value

            '======================================Unit3
            sql = "SELECT     * " & _
            " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit3.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varunit3 = rs("Code").Value

            'Dim sql2 As String

            '       sql2 = "INSERT INTO BD_ITEM (Code, Name,CodeGroupItemMain,CodeGroupItem1,CodeGroupItem2,Unit1,ValueUnit1,Unit2,ValueUnit2,Unit3,ValueUnit3,MinOrderItem,TypeItem,PricePrcheses,PriceSal,Discount_Item,taxItem,PriceG,PriceA,CityName,NameCompny,Ex_Item) " & _
            '" values  ('" & txt_Code.Text & "' ,'" & txt_name.Text & "','" & txt_CodeG.Text & "','" & txt_CodeG1.Text & "','" & txt_CodeG2.Text & "','" & varunit1 & "','" & txt_unitcount1.Text & "','" & varunit2 & "','" & txt_unitcount2.Text & "','" & varunit3 & "','" & txt_unitcount3.Text & "','" & txt_MinOrder.Text & "','" & txt_TypeItem.Text & "','" & txt_pric_Prcheses.Text & "','" & txt_pric_Sal.Text & "','" & txt_DiscountItem.Text & "','" & txt_taxItem.Text & "','" & txt_priceG.Text & "','" & txt_priceA.Text & "','" & txt_CityItem.Text & "','" & txt_CompnyItem.Text & "','" & txt_Exitem.Text & "')"
            '       rs = Cnn.Execute(sql2)
            '       MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Erp")
            '       'Fill_Data()

            clear()
            last_Data()

        End If
    End Sub
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Code) AS MaxmamNo  FROM  BD_ITEM  where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(Code) Is Not NULL)  "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_Code.Text = rs3("MaxmamNo").Value + 1
        Else
            txt_Code.Text = 1
            clear()

        End If
    End Sub
    Sub clear()
        txt_name.Text = ""
        txt_CodeG.Text = ""
        txt_CodeG1.Text = ""
        txt_CodeG2.Text = ""
        txt_NameMain.Text = ""
        txt_NameG1.Text = ""
        txt_NameG2.Text = ""
        txt_CityItem.Text = ""
        txt_CompnyItem.Text = ""
        txt_MinOrder.Text = ""
        txt_DiscountItem.Text = ""
        txt_pric_Prcheses.Text = ""
        txt_pric_Sal.Text = ""
        'txt_priceA.Text = ""
        'txt_priceG.Text = ""
        txt_TypeItem.Text = ""
        txt_unitcount1.Text = ""
        txt_unitcount2.Text = ""
        txt_unitcount3.Text = ""
        txt_taxItem.Text = ""
        txt_Exitem.Text = ""
        txt_serilNo.Text = ""
        txt_Indusrty.Text = ""
        Txt_Barcode.Text = ""
        'txt_dateF.Text = ""
        txt_Pressure.Text = ""
        Cmd_save.Enabled = True
        Cmd_Delete.Enabled = False
        cmd_update.Enabled = False
        'Com_Unit1.Items.Clear()
        'Com_Unit2.Items.Clear()
        'Com_Unit3.Items.Clear()
        txt_TypeItem.Items.Clear()
        txt_CityItem.Items.Clear()

        txt_TypeItem.Items.Add("مستورد")
        txt_TypeItem.Items.Add("محلى")

        'txt_CityItem.Items.Add("تركيا")
        'txt_CityItem.Items.Add("صين")
        'txt_CityItem.Items.Add("مصر")
        'txt_CityItem.Items.Add("هند")
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
        last_Data()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Exitem.Text) = 0 Then MsgBox("من فضلك ادخل رقم التوصيف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_CodeG.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة الرئيسية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG1.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG2.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(Com_Unit1.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit2.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit3.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount1.Text) = 0 Then MsgBox("من فضلك ادخل محتوى الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount2.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount3.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub




        If Len(txt_TypeItem.Text) = 0 Then MsgBox("من فضلك ادخل نوع الصنف  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '======================================Unit1
        sql = "SELECT     * " & _
        " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit1.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit1 = rs("Code").Value

        '======================================Unit2
        sql = "SELECT     * " & _
        " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit2.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit2 = rs("Code").Value

        '======================================Unit3
        sql = "SELECT     * " & _
        " FROM         BD_UNIT WHERE     (Name = '" & Com_Unit3.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit3 = rs("Code").Value


        'sql = "UPDATE  BD_ITEM  SET Ex_Item ='" & txt_Exitem.Text & "',Name='" & txt_name.Text & "' , CodeGroupItemMain = '" & txt_CodeG.Text & "',CodeGroupItem1 ='" & txt_CodeG1.Text & "',CodeGroupItem2 ='" & txt_CodeG2.Text & "' ,Unit1='" & varunit1 & "',Unit2='" & varunit2 & "',Unit3='" & varunit3 & "' ,MinOrderItem ='" & txt_MinOrder.Text & "' , TypeItem ='" & txt_TypeItem.Text & "',PricePrcheses ='" & txt_pric_Prcheses.Text & "',PriceSal='" & txt_pric_Sal.Text & "',Discount_Item='" & txt_DiscountItem.Text & "',taxItem ='" & txt_taxItem.Text & "',CityName='" & txt_CityItem.Text & "',NameCompny='" & txt_CompnyItem.Text & "',PriceG='" & txt_priceG.Text & "',PriceA='" & txt_priceA.Text & "',ValueUnit1='" & txt_unitcount1.Text & "',ValueUnit2='" & txt_unitcount2.Text & "',ValueUnit3='" & txt_unitcount3.Text & "' WHERE code = " & txt_Code.Text & ""
        'rs = Cnn.Execute(sql)


        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

        'Fill_Data()
    End Sub




    Sub Search()
        'On Error Resume Next



        'Dim con As New OleDb.OleDbConnection
        'Dim ss As String
        'ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
        'con.ConnectionString = ss
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()





        sql = " SELECT        Code, Name, MG_Item, G1_Item, G2_Item, PriceSal, PricePrcheses, Indusrty,Color,Size,CityName,NameCompny,Barcode_No FROM            dbo.VW_FINDDATAITEM2  WHERE        (Compny_Code = '" & VarCodeCompny & "') and Name Like '%" & Txt_NameItemFind.Text & "%' "

        'sql = "SELECT  code,name FROM  BD_ITEM   "
        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "أسم الصنف"
        GridView1.Columns(2).Caption = "المجموعة الرئيسية"
        GridView1.Columns(3).Caption = "مجموعة 1"
        GridView1.Columns(4).Caption = "المجموعة 2"
        GridView1.Columns(5).Caption = "سعر البيع"
        GridView1.Columns(6).Caption = "سعر الشراء"
        GridView1.Columns(7).Caption = "المواصفات"
        GridView1.Columns(8).Caption = "اللون"
        GridView1.Columns(9).Caption = "المقاس"
        GridView1.Columns(10).Caption = "بلد المنشأ"
        GridView1.Columns(11).Caption = "الماركة / المورد"
        GridView1.Columns(12).Caption = "الباركود"


        'GridView1.Columns(7).Visible = False
        ''GridView1.Columns(8).Visible = False

        'GridView1.Columns(9).Visible = False
        ''GridView1.Columns(10).Visible = False
        ''GridView1.Columns(11).Visible = False
        'GridView1.Columns(12).Visible = False
        GridView1.Columns(2).GroupIndex = 1
        GridView1.Columns(3).GroupIndex = 2
        GridView1.Columns(4).GroupIndex = 3

        GridView1.ExpandAllGroups()

        'GridView6.Columns(2).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(2).AppearanceCell.ForeColor = Color.Red
        'GridView6.Columns(2).AppearanceCell.Font.FontFamily

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.BestFitColumns()


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            'Me.VW_FINDDATAITEM2TableAdapter.FillBy(Me.DataSet1.VW_FINDDATAITEM2)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Exitem.Text) = 0 Then MsgBox("من فضلك ادخل رقم التوصيف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_CodeG.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة الرئيسية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG1.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG2.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(Com_Unit1.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit2.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit3.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount1.Text) = 0 Then MsgBox("من فضلك ادخل محتوى الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount2.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount3.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'If Op1.Checked = True Then
        '    If Len(txt_serilNo.Text) = 0 Then MsgBox("من فضلك ادخل SerailNo ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Indusrty.Text) = 0 Then MsgBox("من فضلك ادخل نوع الصناعة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        'End If


        If Len(txt_TypeItem.Text) = 0 Then MsgBox("من فضلك ادخل نوع الصنف  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "SELECT     * " & _
        " FROM         dbo.BD_ITEM WHERE     (code = " & txt_Code.Text & ") and Compny_Code ='" & VarCodeCompny & "' "
        Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        Else





            '======================================Unit1
            sql = "SELECT     * " & _
            " FROM         BD_Unit WHERE     (Name = '" & Com_Unit1.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varunit1 = rs("Code").Value

            ''======================================نوع المقاس
            sql = "SELECT     * " & _
            " FROM         BD_TypeOfSize WHERE     (Name = '" & txt_TypeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then VarTypeofsize = rs("Code").Value

            ''======================================بلد المنشا
            sql = "SELECT     * " & _
            " FROM         BD_CITIES WHERE     (Name = '" & txt_CityItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcityCode = rs("Code").Value


            ''======================================الشركة المصنعة
            sql = "SELECT     * " & _
            " FROM         BD_Vendor WHERE     (Name = '" & txt_CompnyItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeVendor = rs("Code").Value

            ''======================================نوع الصناعة
            sql = "SELECT     * " & _
            " FROM         BD_Indusrty WHERE     (Name = '" & txt_Indusrty.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeIndusrty = rs("Code").Value




            varunit2 = 1
            varunit3 = 1
           

            'Dim var_barcode As String
            'varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & txt_Pressure.Text & "-" & "000")

            ''varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & "000")
            'VarName_Item2 = Trim(txt_CompnyItem.Text & "-" & "PN" & txt_Pressure.Text & "-" & txt_NameG1.Text & "-" & txt_NameG2.Text & txt_TypeItem.Text & "-" & txt_NameMain.Text)

            '    var_barcode = Trim(txt_Code.Text & "" & txt_CodeG.Text & "" & txt_CodeG1.Text & "" & txt_CodeG2.Text & "" & "00")
            '    Txt_Barcode.Text = var_barcode
            '    sql = "INSERT INTO BD_ITEM (Code, Name,CodeGroupItemMain,CodeGroupItem1,CodeGroupItem2,Unit1,ValueUnit1,Unit2,ValueUnit2,Unit3,ValueUnit3,MinOrderItem,TypeItem,PricePrcheses,PriceSal,Discount_Item,taxItem,PriceG,PriceA,Ex_Item,TypeItemList,TypeItemList2,Compny_Code,Kilo_Item,Barcode_No,Code_TypeMatril,Batch_No,CodeVendor,codeIndusrty,Code_City,Code_TypeOfSize) " & _
            '" values  (N'" & txt_Code.Text & "' ,N'" & txt_name.Text & "',N'" & txt_CodeG.Text & "',N'" & txt_CodeG1.Text & "',N'" & txt_CodeG2.Text & "',N'" & varunit1 & "',N'" & txt_unitcount1.Text & "',N'" & varunit2 & "',N'" & txt_unitcount2.Text & "',N'" & varunit3 & "',N'" & txt_unitcount3.Text & "',N'" & txt_MinOrder.Text & "',N'" & txt_TypeItem.Text & "',N'" & txt_pric_Prcheses.Text & "',N'" & txt_pric_Sal.Text & "',N'" & txt_DiscountItem.Text & "',N'" & txt_taxItem.Text & "',N'" & txt_priceG.Text & "',N'" & txt_priceA.Text & "',N'" & txt_Exitem.Text & "',N'" & varopphzigalItem & "',N'" & varopphzigalItem2 & "',N'" & VarCodeCompny & "',N'" & txt_serilNo.Text & "',N'" & var_barcode & "',N'" & varcode_Matril & "',N'" & Txt_BatchNo.Text & "',  N'" & varcodeVendor & "', N'" & varcodeIndusrty & "', N'" & varcityCode & "',N'" & VarTypeofsize & "')"
            '    Cnn.Execute(sql)
            '    MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Erp")

            Search()
            'Search2()
            Find_data()
        End If

    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        clear()
        last_Data()
        ''If CheckBox1.Checked = True Then
        'Dim varSerilExt_Item, VarName_Item2 As String
        'varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & txt_Pressure.Text & "-" & "000")

        ''varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & "000")
        'VarName_Item2 = Trim(txt_CompnyItem.Text & "-" & "PN" & txt_Pressure.Text & "-" & txt_NameG1.Text & "-" & txt_NameG2.Text & txt_TypeItem.Text & "-" & txt_NameMain.Text)

        'txt_Exitem.Text = varSerilExt_Item
        'txt_name.Text = VarName_Item2
        'Else
        'txt_Exitem.Text = ""
        'txt_name.Text = ""
        'End If

    End Sub


    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        sql = "     Select No_Item       FROM dbo.TB_Detalis_PriceListCustomer       WHERE(No_Item = " & txt_Code.Text & ")"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف عليه حركة", MsgBoxStyle.Critical, "css") : Exit Sub

        sql = "     Select No_Item       FROM dbo.TB_Detils_OrderItem_Stores       WHERE(No_Item = " & txt_Code.Text & ")"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("الصنف عليه حركة", MsgBoxStyle.Critical, "css") : Exit Sub


        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete BD_ITEM  WHERE code = " & txt_Code.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
                clear()
                Search()
                'Fill_Data()


        End Select
    End Sub

    Private Sub txt_CodeG_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CodeG.ButtonClick
        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 1
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_CodeG_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CodeG.EditValueChanged

    End Sub

    Private Sub txt_CodeG1_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CodeG1.ButtonClick
        vartable = "BD_GroupItem1"
        VarOpenlookup = 2
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_CodeG1_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CodeG1.EditValueChanged

    End Sub

    Private Sub txt_CodeG2_ButtonClick1(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CodeG2.ButtonClick
        vartable = "BD_GroupItem2"
        VarOpenlookup = 3
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_CodeG2_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CodeG2.EditValueChanged

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        vartable = "BD_GROUPITEMMAIN"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الرئيسية"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        vartable = "BD_GroupItem1"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الاولى"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        vartable = "BD_GroupItem2"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد المجموعة الثانية"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridView6_RowCellStyle1(sender As Object, e As XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'If e.Column.FieldName = "PackageType" Then
        'Dim view As GridView = TryCast(sender, GridView)
        'Dim isDefaulType As Integer = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "IsDefaultPackageType"))
        'If isDefaulType = 0 Then
        'e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        'End If
        'End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        Frm_MatrilPlan.ShowDialog()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Frm_BarcodeQr.ShowDialog()
    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Sub find_item()
        sql = "   SELECT        Code, Ex_Item, Compny_Code, Name, MG_Item, G1_Item, G2_Item, Unit1, ValueUnit1, Unit2, ValueUnit2, Unit3, ValueUnit3, MinOrderItem, TypeItem, PricePrcheses, PriceSal, Discount_Item, taxItem, PriceG, " & _
             "                       PriceA, CityName, NameCompny, TypeItemList, TypeItem2, SiralNo, CatalogNo, Barcode_No, Width_item, Length_Item, Kilo_Item, No_of_join, CodeGroupItemMain, CodeGroupItem1, CodeGroupItem2,NameMatril,Batch_No " & _
            "       FROM dbo.VW_FINDDATAITEM2 " & _
           " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (code = '" & varcodeitem & "')"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Code.Text = rs("Code").Value
            txt_name.Text = rs("Name").Value
            txt_Exitem.Text = rs("Ex_Item").Value
            txt_CodeG.Text = rs("CodeGroupItemMain").Value
            txt_CodeG1.Text = rs("CodeGroupItem1").Value
            txt_CodeG2.Text = rs("CodeGroupItem2").Value
            txt_NameMain.Text = rs("MG_Item").Value
            txt_NameG1.Text = rs("G1_Item").Value
            txt_NameG2.Text = rs("G2_Item").Value
            txt_CityItem.Text = rs("CityName").Value
            txt_CompnyItem.Text = rs("NameCompny").Value
            txt_MinOrder.Text = rs("MinOrderItem").Value
            txt_DiscountItem.Text = rs("Discount_Item").Value
            txt_pric_Prcheses.Text = rs("PricePrcheses").Value
            txt_pric_Sal.Text = rs("PriceSal").Value
            'txt_priceA.Text = rs("PriceG").Value
            'txt_priceG.Text = rs("PriceA").Value
            txt_TypeItem.Text = rs("TypeItem").Value
            txt_unitcount1.Text = rs("ValueUnit1").Value
            txt_unitcount2.Text = rs("ValueUnit2").Value
            txt_unitcount3.Text = rs("ValueUnit3").Value
            txt_taxItem.Text = rs("taxItem").Value
            txt_serilNo.Text = rs("SiralNo").Value
            txt_Indusrty.Text = rs("CatalogNo").Value
            Txt_Barcode.Text = rs("Barcode_No").Value
            Com_Unit1.Text = rs("Unit1").Value
            Com_Unit2.Text = rs("Unit2").Value
            Com_Unit3.Text = rs("Unit3").Value
            txt_unitcount1.Text = rs("ValueUnit1").Value
            txt_unitcount2.Text = rs("ValueUnit2").Value
            txt_unitcount3.Text = rs("ValueUnit3").Value
            'txt_TypeMatril.Text = rs("NameMatril").Value
            'Txt_BatchNo.Text = rs("Batch_No").Value


            'If rs("TypeItemList").Value = 0 Then op3.Checked = True
            'If rs("TypeItemList").Value = 1 Then OP4.Checked = True
            'If rs("TypeItemList").Value = 2 Then OP5.Checked = True



            If rs("TypeItemList2").Value = 0 Then Op1.Checked = True
            If rs("TypeItemList2").Value = 1 Then Op2.Checked = True
            If rs("TypeItemList2").Value = 2 Then OP7.Checked = True


            Cmd_Delete.Enabled = True
            cmd_update.Enabled = True
            'Com_Unit1.Items.Clear()
        Else
            clear()
        End If
        TabPane1.SelectedPageIndex = 0
    End Sub









    Private Sub OP4_Click(sender As Object, e As EventArgs)
        'If OP4.Checked = True Then Lab_TypeM.Enabled = True : txt_TypeMatril.Enabled = True : txt_TypeMatril.Enabled = True : Lab_batch.Enabled = True : Txt_BatchNo.Enabled = True

    End Sub


    Private Sub op3_Click(sender As Object, e As EventArgs)
        'If op3.Checked = True Then Lab_TypeM.Enabled = False : txt_TypeMatril.Enabled = False : txt_TypeMatril.Enabled = False : Lab_batch.Enabled = False : Lab_batch.Enabled = False : txt_TypeMatril.Text = "" : Txt_BatchNo.Text = ""

    End Sub


    Private Sub OP5_Click(sender As Object, e As EventArgs)
        'If OP5.Checked = True Then Lab_TypeM.Enabled = True : txt_TypeMatril.Enabled = True : txt_TypeMatril.Enabled = True : Lab_batch.Enabled = True : Lab_batch.Enabled = True : txt_TypeMatril.Text = "" : Txt_BatchNo.Text = ""

    End Sub

    Private Sub txt_TypeMatril_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs)
        vartable = "TB_TypeMatril"
        VarOpenlookup = 37
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_TypeMatril_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub op3_CheckedChanged(sender As Object, e As EventArgs)
        'If op3.Checked = True Then Lab_TypeM.Enabled = False : txt_TypeMatril.Enabled = False : txt_TypeMatril.Enabled = False : Lab_batch.Enabled = False : Lab_batch.Enabled = False : txt_TypeMatril.Text = "" : Txt_BatchNo.Text = ""

    End Sub

    Private Sub OP4_CheckedChanged(sender As Object, e As EventArgs)
        'If OP4.Checked = True Then Lab_TypeM.Enabled = True : txt_TypeMatril.Enabled = True : txt_TypeMatril.Enabled = True : Lab_batch.Enabled = True : Txt_BatchNo.Enabled = True

    End Sub

    Private Sub OP5_CheckedChanged(sender As Object, e As EventArgs)
        'If OP5.Checked = True Then Lab_TypeM.Enabled = True : txt_TypeMatril.Enabled = True : txt_TypeMatril.Enabled = True : Lab_batch.Enabled = True : Lab_batch.Enabled = True : txt_TypeMatril.Text = "" : Txt_BatchNo.Text = ""

    End Sub


    Private Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click
        On Error Resume Next
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Exitem.Text) = 0 Then MsgBox("من فضلك ادخل رقم التوصيف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(txt_CodeG.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة الرئيسية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG1.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CodeG2.Text) = 0 Then MsgBox("من فضلك ادخل المجموعة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        If Len(Com_Unit1.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit2.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Unit3.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount1.Text) = 0 Then MsgBox("من فضلك ادخل محتوى الوحدة 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount2.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_unitcount3.Text) = 0 Then MsgBox("من فضلك محتوى الوحدة 3 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        '======================================Unit1
        sql = "SELECT     * " & _
        " FROM         BD_Unit WHERE     (Name = '" & Com_Unit1.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit1 = rs("Code").Value

        ''======================================Unit2
        'sql = "SELECT     * " & _
        '" FROM         BD_Unit WHERE     (Name = '" & Com_Unit2.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varunit2 = rs("Code").Value

        ''======================================Unit3
        'sql = "SELECT     * " & _
        '" FROM         BD_Unit WHERE     (Name = '" & Com_Unit3.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varunit3 = rs("Code").Value


        varunit2 = 1
        varunit3 = 1

        If Op1.Checked = True Then varopphzigalItem2 = 0 'ماكينات
        If Op2.Checked = True Then varopphzigalItem2 = 1 'قطع غيار
        If OP7.Checked = True Then varopphzigalItem2 = 2 'خام


        'If op3.Checked = True Then varopphzigalItem = 0 'منتج نهائى
        'If OP4.Checked = True Then varopphzigalItem = 1 'مادة خام
        'If OP5.Checked = True Then varopphzigalItem = 2 'منتج أولى

        Dim varbarcode As String
        '======================================نوع المادة الخام
        'sql = "SELECT     * " & _
        '" FROM         TB_TypeMatril WHERE     (Name = '" & txt_TypeMatril.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then varcode_Matril = rs("Code").Value

        'varbarcode = "0000" + txt_Code.Text + txt_CodeG.Text + txt_CodeG1.Text + txt_CodeG2.Text


        '======================================Unit1
        sql = "SELECT     * " & _
        " FROM         BD_Unit WHERE     (Name = '" & Com_Unit1.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit1 = rs("Code").Value
        '=====================================Unit2


        '======================================Unit2
        sql = "SELECT     * " & _
        " FROM         BD_Unit WHERE     (Name = '" & Com_Unit2.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit2 = rs("Code").Value


        '======================================Unit3
        sql = "SELECT     * " & _
        " FROM         BD_Unit WHERE     (Name = '" & Com_Unit3.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varunit3 = rs("Code").Value

        ''======================================نوع المقاس
        sql = "SELECT     * " & _
        " FROM         BD_TypeOfSize WHERE     (Name = '" & txt_TypeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then VarTypeofsize = rs("Code").Value

        ''======================================بلد المنشا
        sql = "SELECT     * " & _
        " FROM         BD_CITIES WHERE     (Name = '" & txt_CityItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcityCode = rs("Code").Value


        ''======================================الشركة المصنعة
        sql = "SELECT     * " & _
        " FROM         BD_Vendor WHERE     (Name = '" & txt_CompnyItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeVendor = rs("Code").Value

        ''======================================نوع الصناعة
        sql = "SELECT     * " & _
        " FROM         BD_Indusrty WHERE     (Name = '" & txt_Indusrty.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeIndusrty = rs("Code").Value




        'varunit2 = 1
        'varunit3 = 1


        'Dim varSerilExt_Item, VarName_Item2 As String

        'varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & txt_Pressure.Text & "-" & "000")
        'VarName_Item2 = Trim(txt_CompnyItem.Text & "-" & "PN" & txt_Pressure.Text & "-" & txt_NameG1.Text & "-" & txt_NameG2.Text & txt_TypeItem.Text & "-" & txt_NameMain.Text)


        'sql2 = "UPDATE  BD_ITEM  SET Pressure ='" & txt_Pressure.Text & "' , Ex_Item = '" & txt_Exitem.Text & "',Name = '" & txt_name.Text & "' ,CodeGroupItemMain = '" & txt_CodeG.Text & "',CodeGroupItem1 = '" & txt_CodeG1.Text & "',CodeGroupItem2 = '" & txt_CodeG2.Text & "',Unit1 ='" & varunit1 & "',Unit2 ='" & varunit2 & "',Unit3 ='" & varunit3 & "',ValueUnit1='" & txt_unitcount1.Text & "',ValueUnit2='" & txt_unitcount2.Text & "',ValueUnit3='" & txt_unitcount3.Text & "',PricePrcheses ='" & txt_pric_Prcheses.Text & "',PriceSal ='" & txt_pric_Sal.Text & "',MinOrderItem ='" & txt_MinOrder.Text & "',Code_TypeMatril ='" & varcode_Matril & "',Batch_No ='" & Txt_BatchNo.Text & "',TypeItemList ='" & varopphzigalItem & "',TypeItemList2 ='" & varopphzigalItem2 & "',date_f='" & txt_dateF.Text & "',Kilo_Item ='" & txt_serilNo.Text & "' WHERE Compny_Code = " & VarCodeCompny & " and code ='" & txt_Code.Text & "'    "
        'rs = Cnn.Execute(sql2)




        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        Search()
    End Sub



   
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click
        Search()
    End Sub

    Private Sub Txt_NameItemFind_TextChanged(sender As Object, e As EventArgs) Handles Txt_NameItemFind.TextChanged
        Search()
    End Sub

    Private Sub txt_CityItem_GotFocus(sender As Object, e As EventArgs) Handles txt_CityItem.GotFocus
        fill_listCity()
    End Sub

 

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        vartable = "BD_CITIES"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكواد بلد المنشأة"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        vartable = "BD_Unit"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "أكوادالوحدات"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click

        vartable = "BD_TypeOfSize"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الصنف"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub Com_Unit1_GotFocus(sender As Object, e As EventArgs) Handles Com_Unit1.GotFocus
        fill_listunit()
    End Sub

    Private Sub Com_Unit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Unit1.SelectedIndexChanged

    End Sub

    Private Sub txt_TypeItem_GotFocus(sender As Object, e As EventArgs) Handles txt_TypeItem.GotFocus
        fill_listTypeOfSize()
    End Sub

    Private Sub txt_TypeItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_TypeItem.SelectedIndexChanged

    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        vartable = "BD_Indusrty"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "نوع الصناعة"
        Frm_GenralData.ShowDialog()

    End Sub

    Sub fill_Indusrty()
        txt_Indusrty.Items.Clear()

        sql = "SELECT     Name " & _
        " FROM         BD_Indusrty where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_Indusrty.Items.Add(rs("Name").Value)

            rs.MoveNext()
        Loop
    End Sub

    Sub fill_Vendor()
        txt_CompnyItem.Items.Clear()

        sql = "SELECT     Name " & _
        " FROM         BD_Vendor where Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            txt_CompnyItem.Items.Add(rs("Name").Value)

            rs.MoveNext()
        Loop
    End Sub
    Private Sub txt_Indusrty_GotFocus(sender As Object, e As EventArgs) Handles txt_Indusrty.GotFocus
        fill_Indusrty()
    End Sub

    Private Sub txt_Indusrty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_Indusrty.SelectedIndexChanged

    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        vartable = "BD_Vendor"
        Frm_GenralData.Close()
        'Frm_GenralData.MdiParent = Me
        Frm_GenralData.Text = "الشركات المصنعة"
        Frm_GenralData.ShowDialog()
    End Sub

    Private Sub txt_CompnyItem_GotFocus(sender As Object, e As EventArgs) Handles txt_CompnyItem.GotFocus
        fill_Vendor()
    End Sub

    Private Sub txt_CompnyItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_CompnyItem.SelectedIndexChanged

    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        For i = 1 To 541

            sql = "   SELECT        Code, Ex_Item, Compny_Code, Name, MG_Item, G1_Item, G2_Item, Unit1, ValueUnit1, Unit2, ValueUnit2, Unit3, ValueUnit3, MinOrderItem, TypeItem, PricePrcheses, PriceSal, Discount_Item, taxItem, PriceG, " & _
                 "                       PriceA, CityName, NameCompny, TypeItemList, TypeItem2, SiralNo, Indusrty, Barcode_No, Width_item, Pressure, Kilo_Item, No_of_join, CodeGroupItemMain, CodeGroupItem1, CodeGroupItem2,NameMatril,Pressure,NameTypeOfSize " & _
                "       FROM dbo.VW_FINDDATAITEM2 " & _
               " WHERE        (Code = '" & i & "')  "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then
                txt_Code.Text = rs("Code").Value
                txt_name.Text = rs("Name").Value
                txt_Exitem.Text = rs("Ex_Item").Value
                txt_CodeG.Text = rs("CodeGroupItemMain").Value
                txt_CodeG1.Text = rs("CodeGroupItem1").Value
                txt_CodeG2.Text = rs("CodeGroupItem2").Value
                txt_NameMain.Text = rs("MG_Item").Value
                txt_NameG1.Text = rs("G1_Item").Value
                txt_NameG2.Text = rs("G2_Item").Value
                txt_CityItem.Text = rs("CityName").Value
                txt_CompnyItem.Text = rs("NameCompny").Value
                txt_MinOrder.Text = rs("MinOrderItem").Value
                txt_DiscountItem.Text = rs("Discount_Item").Value
                txt_pric_Prcheses.Text = rs("PricePrcheses").Value
                txt_pric_Sal.Text = rs("PriceSal").Value
                'txt_priceA.Text = rs("PriceG").Value
                'txt_priceG.Text = rs("PriceA").Value
                txt_TypeItem.Text = rs("TypeItem").Value
                txt_unitcount1.Text = rs("ValueUnit1").Value
                txt_unitcount2.Text = rs("ValueUnit2").Value
                txt_unitcount3.Text = rs("ValueUnit3").Value
                txt_taxItem.Text = rs("taxItem").Value
                txt_serilNo.Text = rs("Kilo_Item").Value
                txt_Indusrty.Text = rs("Indusrty").Value
                Txt_Barcode.Text = rs("Barcode_No").Value
                Com_Unit1.Text = rs("Unit1").Value
                Com_Unit2.Text = rs("Unit2").Value
                Com_Unit3.Text = rs("Unit3").Value
                txt_unitcount1.Text = rs("ValueUnit1").Value
                txt_unitcount2.Text = rs("ValueUnit2").Value
                txt_unitcount3.Text = rs("ValueUnit3").Value
                'txt_TypeMatril.Text = rs("NameMatril").Value
                txt_Pressure.Text = rs("Pressure").Value
                txt_TypeItem.Text = rs("NameTypeOfSize").Value


                'If rs("TypeItemList").Value = 0 Then op3.Checked = True
                'If rs("TypeItemList").Value = 1 Then OP4.Checked = True
                'If rs("TypeItemList").Value = 2 Then OP5.Checked = True



                'If rs("TypeItemList2").Value = 0 Then Op1.Checked = True
                'If rs("TypeItemList2").Value = 1 Then Op2.Checked = True
                'If rs("TypeItemList2").Value = 2 Then OP7.Checked = True


                Cmd_Delete.Enabled = True
                cmd_update.Enabled = True
                'Com_Unit1.Items.Clear()
            Else
                clear()
            End If

            '==============================

            Dim varbarcode As String
            '======================================نوع المادة الخام
            'sql = "SELECT     * " & _
            ''" FROM         TB_TypeMatril WHERE     (Name = '" & txt_TypeMatril.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            'rs = Cnn.Execute(sql)
            'If rs.EOF = False Then varcode_Matril = rs("Code").Value

            varbarcode = "0000" + txt_Code.Text + txt_CodeG.Text + txt_CodeG1.Text + txt_CodeG2.Text


            '======================================Unit1
            sql = "SELECT     * " & _
            " FROM         BD_Unit WHERE     (Name = '" & Com_Unit1.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varunit1 = rs("Code").Value

            ''======================================نوع المقاس
            sql = "SELECT     * " & _
            " FROM         BD_TypeOfSize WHERE     (Name = '" & txt_TypeItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then VarTypeofsize = rs("Code").Value

            ''======================================بلد المنشا
            sql = "SELECT     * " & _
            " FROM         BD_CITIES WHERE     (Name = '" & txt_CityItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcityCode = rs("Code").Value


            ''======================================الشركة المصنعة
            sql = "SELECT     * " & _
            " FROM         BD_Vendor WHERE     (Name = '" & txt_CompnyItem.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeVendor = rs("Code").Value

            ''======================================نوع الصناعة
            sql = "SELECT     * " & _
            " FROM         BD_Indusrty WHERE     (Name = '" & txt_Indusrty.Text & "') and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeIndusrty = rs("Code").Value




            varunit2 = 1
            varunit3 = 1


            Dim varSerilExt_Item, VarName_Item2 As String

            varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & txt_Pressure.Text & "-" & "000")

            'varSerilExt_Item = Trim(varcodeIndusrty & "-" & varcityCode & "-" & varcodeVendor & "-" & txt_CodeG1.Text & "-" & txt_CodeG.Text & "-" & txt_NameG2.Text & "-" & "000")
            VarName_Item2 = Trim(txt_CompnyItem.Text & "-" & "PN" & txt_Pressure.Text & "-" & txt_NameG1.Text & "-" & txt_NameG2.Text & txt_TypeItem.Text & "-" & txt_NameMain.Text)


            'sql2 = "UPDATE  BD_ITEM  SET Pressure ='" & txt_Pressure.Text & "' , Ex_Item = '" & varSerilExt_Item & "',Name = '" & VarName_Item2 & "' ,CodeGroupItemMain = '" & txt_CodeG.Text & "',CodeGroupItem1 = '" & txt_CodeG1.Text & "',CodeGroupItem2 = '" & txt_CodeG2.Text & "',Unit1 ='" & varunit1 & "',Unit2 ='" & varunit2 & "',Unit3 ='" & varunit3 & "',ValueUnit1='" & txt_unitcount1.Text & "',ValueUnit2='" & txt_unitcount2.Text & "',ValueUnit3='" & txt_unitcount3.Text & "',PricePrcheses ='" & txt_pric_Prcheses.Text & "',PriceSal ='" & txt_pric_Sal.Text & "',MinOrderItem ='" & txt_MinOrder.Text & "',Code_TypeMatril ='" & varcode_Matril & "',Batch_No ='" & Txt_BatchNo.Text & "',TypeItemList ='" & varopphzigalItem & "',TypeItemList2 ='" & varopphzigalItem2 & "',date_f='" & txt_dateF.Text & "',Kilo_Item ='" & txt_serilNo.Text & "' WHERE Compny_Code = " & VarCodeCompny & " and code ='" & txt_Code.Text & "'    "
            rs = Cnn.Execute(sql2)




            'MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

        Next
        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
    End Sub

    
   

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        GridView1.ExpandAllGroups()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))

        sql = "   SELECT        Code, Ex_Item, Compny_Code, Name, MG_Item, G1_Item, G2_Item, Unit1, ValueUnit1, Unit2, ValueUnit2, Unit3, ValueUnit3, MinOrderItem, PricePrcheses, PriceSal, Discount_Item, taxItem, PriceG, " & _
             "                       PriceA, CityName, NameCompny, Indusrty, Barcode_No, CodeGroupItemMain, CodeGroupItem1, CodeGroupItem2,Barcode_No " & _
            "       FROM dbo.VW_FINDDATAITEM2 " & _
           " WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Code = '" & value & "')  "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Code.Text = rs("Code").Value
            txt_name.Text = rs("Name").Value
            txt_Exitem.Text = rs("Ex_Item").Value
            txt_CodeG.Text = rs("CodeGroupItemMain").Value
            txt_CodeG1.Text = rs("CodeGroupItem1").Value
            txt_CodeG2.Text = rs("CodeGroupItem2").Value
            txt_NameMain.Text = rs("MG_Item").Value
            txt_NameG1.Text = rs("G1_Item").Value
            txt_NameG2.Text = rs("G2_Item").Value
            txt_CityItem.Text = rs("CityName").Value
            txt_CompnyItem.Text = rs("NameCompny").Value
            txt_MinOrder.Text = rs("MinOrderItem").Value
            'txt_DiscountItem.Text = rs("Discount_Item").Value
            txt_pric_Prcheses.Text = rs("PricePrcheses").Value
            txt_pric_Sal.Text = rs("PriceSal").Value
            txt_unitcount1.Text = rs("ValueUnit1").Value
            txt_unitcount2.Text = rs("ValueUnit2").Value
            txt_unitcount3.Text = rs("ValueUnit3").Value
            txt_Indusrty.Text = rs("Indusrty").Value
            'Txt_Barcode.Text = rs("Barcode_No").Value
            Com_Unit1.Text = rs("Unit1").Value
            Com_Unit2.Text = rs("Unit2").Value
            Com_Unit3.Text = rs("Unit3").Value
            txt_unitcount1.Text = rs("ValueUnit1").Value
            txt_unitcount2.Text = rs("ValueUnit2").Value
            txt_unitcount3.Text = rs("ValueUnit3").Value
            'txt_TypeMatril.Text = rs("NameMatril").Value
            'txt_Pressure.Text = rs("Pressure").Value
            'Txt_Barcode.Text = rs("Barcode_No").Value


            'If rs("TypeItemList").Value = 0 Then op3.Checked = True
            'If rs("TypeItemList").Value = 1 Then OP4.Checked = True
            'If rs("TypeItemList").Value = 2 Then OP5.Checked = True



            'If rs("TypeItemList2").Value = 0 Then Op1.Checked = True
            'If rs("TypeItemList2").Value = 1 Then Op2.Checked = True
            'If rs("TypeItemList2").Value = 2 Then OP7.Checked = True


            Cmd_Delete.Enabled = True
            cmd_update.Enabled = True
            'Com_Unit1.Items.Clear()
        Else
            clear()
        End If
        TabPane1.SelectedPageIndex = 0
    End Sub
End Class