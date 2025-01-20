Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_suppliersInfo
    Dim varcodeaccountgroup As String
    Public varcodecur As Decimal

    Dim valueNoSuppliser As Integer
    Dim varcodeItem As Integer
    'Sub last_Data()

    'Dim varcodeaccountgroup As String
  
    Sub clear()
        txt_name.Text = ""
        'txt_Code.Text = ""
        txt_AccountNo.Text = ""
       
        txt_NationalID.Text = ""
        txt_Addres.Text = ""
        txt_Phone1.Text = ""
        txt_Phone2.Text = ""
        txt_Website.Text = ""
        txt_Email.Text = ""
        txt_Notes.Text = ""
        txt_cur.Text = ""
        txt_catogry_cust.Text = ""
        txt_FileNo_Tax.Text = ""
        txt_NoReg_Tax.Text = ""
        txt_NoFileTogary.Text = ""
        txt_NameM.Text = ""
        txt_Creditlimit.Text = ""
        txt_Region.Text = ""
        txt_Creditlimit.Text = ""
    End Sub
   




    Private Sub Cmd_New_Click(sender As Object, e As EventArgs) Handles Cmd_New.Click
        If Cmd_AccountNoGroup.Text = "" Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        '=========================================GroupAccount
        clear()
        last_Data()
        lastAccounno()
    End Sub
    Sub lastAccounno()
        'clear()
        sql = "SELECT     * " & _
           " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

        '===========================================
        'sql = " SELECT MAX(Supliser_AccountNo)  AS Maxmaim      FROM dbo.St_SuppliserData WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Supliser_AccountNoGroup = '" & varcodeaccountgroup & "') HAVING (MAX(Supliser_AccountNo) IS NOT NULL) "

        sql = "  SELECT MAX(Supliser_AccountNo) AS Maxmaim       FROM dbo.St_SuppliserData WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Supliser_AccountNoGroup = '" & varcodeaccountgroup & "')" & _
       " HAVING(MAX(Supliser_AccountNo) Is Not NULL)"

        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_AccountNo.Text = rs3("Maxmaim").Value + 1
        Else
            txt_AccountNo.Text = Str(varcodeaccountgroup) + "001"
        End If

    End Sub
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Supliser_Code) AS MaxmamNo FROM St_SuppliserData where Compny_Code ='" & VarCodeCompny & "' HAVING (MAX(Supliser_Code) IS NOT NULL) "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txt_Code.Text = rs3("MaxmamNo").Value + 1
        Else
            txt_Code.Text = 1
            clear()

        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        On Error Resume Next
        If Len(Cmd_AccountNoGroup.Text) = 0 Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "SELECT     * " & _
        " FROM         St_SuppliserData  WHERE     (Supliser_Code = " & txt_Code.Text & ") and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        Else

            '=========================================GroupAccount

            sql = "SELECT     * " & _
               " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

            '======================================Region
            Dim varcodeRegion As Integer
            sql = "SELECT     * " & _
            " FROM         BD_REGION WHERE     (Name = '" & txt_Region.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodeRegion = rs("Code").Value
            '===============================================
            Dim varcodecur As Integer
            sql = "SELECT     * " & _
            " FROM         BD_Currency WHERE     (Name = '" & txt_cur.Text & "')"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcodecur = rs("Code").Value
            '====================================================
            Dim varstatus As Integer
            If Radio_Stop.Checked = True Then varstatus = 1
            If Radio_Avalible.Checked = True Then varstatus = 0

            lastAccounno()
            Dim sql2 As String
            sql2 = "INSERT INTO St_SuppliserData (Compny_Code, Supliser_Code,Supliser_AccountNo,Supliser_AccountNoGroup,Supliser_Name,Supliser_NationalID,Supliser_Address,Supliser_Phon1,Supliser_Phon2,Supliser_Website,Supliser_Email,Supliser_Notes,Code_Region,Supliser_Creditlimit,Supliser_Flag,Supliser_FileNoTax,Cur_Code,supliser_regfile,supliser_trade,supliser_response,Supliser_Type) " & _
              " values  ('" & VarCodeCompny & "' ,'" & txt_Code.Text & "','" & txt_AccountNo.Text & "','" & varcodeaccountgroup & "','" & txt_name.Text & "','" & txt_NationalID.Text & "','" & txt_Addres.Text & "','" & txt_Phone1.Text & "','" & txt_Phone2.Text & "','" & txt_Website.Text & "','" & txt_Email.Text & "','" & txt_Notes.Text & "','" & varcodeRegion & "','" & txt_Creditlimit.Text & "','" & varstatus & "','" & txt_FileNo_Tax.Text & "','" & varcodecur & "','" & txt_NoReg_Tax.Text & "' , '" & txt_NoFileTogary.Text & "','" & txt_NameM.Text & "','" & txt_catogry_cust.Text & "' )"
            rs = Cnn.Execute(sql2)

            '============================AddChartOfAccount

            sql = "INSERT INTO ST_CHARTOFACCOUNT (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
        " values  (N'" & 3 & "' ,N'" & txt_AccountNo.Text & "',N'" & txt_AccountNo.Text & "',N'" & varcodeaccountgroup & "',N'" & txt_name.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_AccountNo.Text + "-" + txt_name.Text & "',N'" & txt_AccountNo.Text & "','" & VarCodeCompny & "')"
            rs =Cnn.Execute(sql)




            MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            clear()
            last_Data()
            lastAccounno()

            find_SupliserAll()
            'Search()
            'Find()
        End If
    End Sub

    Sub find_SupliserAll()
        Dim sql2 As String


        'sql2 = "SELECT      dbo.St_SuppliserData.Supliser_Code, dbo.St_SuppliserData.Supliser_Name, dbo.Vw_LookupAccountLv2.name AS NameGroup,  " & _
        '"                          dbo.St_SuppliserData.Supliser_NationalID, dbo.St_SuppliserData.Supliser_Address, dbo.St_SuppliserData.Supliser_Phon1, dbo.St_SuppliserData.Supliser_Phon2,   " & _
        '"                         dbo.St_SuppliserData.Supliser_Website, dbo.St_SuppliserData.Supliser_Email, dbo.St_SuppliserData.Supliser_Notes, dbo.BD_REGION.Name, dbo.St_SuppliserData.Supliser_Creditlimit,                   IIF( St_SuppliserData.Supliser_Flag=0,'سارى','متوقف') as Status  " & _
        '" FROM            dbo.St_SuppliserData LEFT OUTER JOIN  " & _
        '"                         dbo.BD_REGION ON dbo.St_SuppliserData.Compny_Code = dbo.BD_REGION.Compny_Code AND dbo.St_SuppliserData.Code_Region = dbo.BD_REGION.Code LEFT OUTER JOIN  " & _
        '"                         dbo.Vw_LookupAccountLv2 ON dbo.St_SuppliserData.Compny_Code = dbo.Vw_LookupAccountLv2.Compny_Code AND dbo.St_SuppliserData.Supliser_AccountNoGroup = dbo.Vw_LookupAccountLv2.code  " & _
        '" WHERE        (dbo.St_SuppliserData.Compny_Code = '" & VarCodeCompny & "')  " & _
        '" ORDER BY dbo.St_SuppliserData.Supliser_Code "

        sql2 = " SELECT TOP (100) PERCENT dbo.St_SuppliserData.Supliser_Code, dbo.St_SuppliserData.Supliser_Name, dbo.Vw_LookupAccountLv2.name AS NameGroup, dbo.St_SuppliserData.Supliser_NationalID,  " & _
 "                  dbo.St_SuppliserData.Supliser_Address, dbo.St_SuppliserData.Supliser_Phon1, dbo.St_SuppliserData.Supliser_Phon2, dbo.St_SuppliserData.Supliser_Website, dbo.St_SuppliserData.Supliser_Email,  " & _
 "                  dbo.St_SuppliserData.Supliser_Notes, dbo.BD_REGION.Name, dbo.St_SuppliserData.Supliser_Creditlimit,            IIF( St_SuppliserData.Supliser_Flag=0,'سارى','متوقف') as Status, dbo.BD_Currency.Name AS Cur_Name  " & _
 "FROM     dbo.St_SuppliserData LEFT OUTER JOIN  " & _
 "                  dbo.BD_Currency ON dbo.St_SuppliserData.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.St_SuppliserData.Cur_Code = dbo.BD_Currency.Code LEFT OUTER JOIN  " & _
 "                  dbo.BD_REGION ON dbo.St_SuppliserData.Compny_Code = dbo.BD_REGION.Compny_Code AND dbo.St_SuppliserData.Code_Region = dbo.BD_REGION.Code LEFT OUTER JOIN  " & _
 "                  dbo.Vw_LookupAccountLv2 ON dbo.St_SuppliserData.Compny_Code = dbo.Vw_LookupAccountLv2.Compny_Code AND dbo.St_SuppliserData.Supliser_AccountNoGroup = dbo.Vw_LookupAccountLv2.code  " & _
 " WHERE  (dbo.St_SuppliserData.Compny_Code =  '" & VarCodeCompny & "')  " & _
 " ORDER BY dbo.St_SuppliserData.Supliser_Code "



        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "كود المورد"
        GridView1.Columns(1).Caption = "أسم المورد"
        GridView1.Columns(2).Caption = "أسم الحساب الرئيسى"
        GridView1.Columns(3).Caption = "الرقم القومى"
        GridView1.Columns(4).Caption = "العنوان"
        GridView1.Columns(5).Caption = "تليفون 1"
        GridView1.Columns(6).Caption = "تليفون 2"
        GridView1.Columns(7).Caption = "الموقع الالكترونى "
        GridView1.Columns(8).Caption = "Email"
        GridView1.Columns(9).Caption = "ملاحظات"
        GridView1.Columns(10).Caption = "المنطقة"
        GridView1.Columns(11).Caption = "الحالة"
        GridView1.Columns(12).Caption = "العملة"

        GridView1.Columns(3).Visible = False
        GridView1.BestFitColumns()

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "200"
        'GridView1.Columns(2).Width = "100"
        'GridView1.Columns(3).Width = "100"
        'GridView1.Columns(4).Width = "100"
        'GridView1.Columns(5).Width = "100"
        'GridView1.Columns(6).Width = "100"
        'GridView1.Columns(7).Width = "100"
        'GridView1.Columns(8).Width = "100"
        'GridView1.Columns(9).Width = "100"
        'GridView1.Columns(10).Width = "100"
        'GridView1.Columns(11).Width = "100"

        'Dim dt As DataTable = New DataTable()
        'dt.Rows.Add(New Object() {Image.FromFile("E:\Source2\interpaknational2\ico\Finance_Icon_Set.jpg"), "test1"})


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub




    Sub find_Item()
        Dim sql2 As String

        sql2 = "   SELECT        dbo.TB_SuppliserOnItem.Code_Item, RTRIM(dbo.BD_ITEM.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.Tb_TypeItemList.Name AS TypeItem " & _
   " FROM            dbo.TB_SuppliserOnItem INNER JOIN " & _
   "                         dbo.St_SuppliserData ON dbo.TB_SuppliserOnItem.Compny_Code = dbo.St_SuppliserData.Compny_Code AND dbo.TB_SuppliserOnItem.Supliser_Code = dbo.St_SuppliserData.Supliser_Code INNER JOIN " & _
   "                         dbo.BD_ITEM ON dbo.TB_SuppliserOnItem.Code_Item = dbo.BD_ITEM.Code AND dbo.TB_SuppliserOnItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
   "                         dbo.Tb_TypeItemList ON dbo.BD_ITEM.TypeItemList2 = dbo.Tb_TypeItemList.Code " & _
   " WHERE        (dbo.TB_SuppliserOnItem.Supliser_Code = '" & valueNoSuppliser & "') AND (dbo.TB_SuppliserOnItem.Compny_Code = '" & VarCodeCompny & "') "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView3.Columns(0).Caption = "كود الصنف"
        GridView3.Columns(1).Caption = "رقم التوصيفى"
        GridView3.Columns(2).Caption = "أسم الصنف"
        GridView3.Columns(3).Caption = "نوع الصنف"


        GridView3.Columns(0).Width = "100"
        GridView3.Columns(1).Width = "100"
        GridView3.Columns(2).Width = "300"
        GridView3.Columns(3).Width = "200"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Len(Cmd_AccountNoGroup.Text) = 0 Then MsgBox("من فضلك ادخل الحساب الرئيسى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_AccountNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الحساب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_cur.Text) = 0 Then MsgBox("من فضلك عملة المورد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        '=========================================GroupAccount
        'Dim varcodeaccountgroup As String
        sql = "SELECT     * " & _
           " FROM         ST_CHARTOFACCOUNT  WHERE     (AccountName = '" & Trim(Cmd_AccountNoGroup.Text) & "') and Compny_Code = '" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeaccountgroup = rs("Account_No").Value

        '======================================Region
        Dim varcodeRegion As Integer
        sql = "SELECT     * " & _
        " FROM         BD_REGION WHERE     (Name = '" & txt_Region.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeRegion = rs("Code").Value
        '===============================================
        Dim varcodecur As Integer
        sql = "SELECT     * " & _
        " FROM         BD_Currency WHERE     (Name = '" & txt_cur.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodecur = rs("Code").Value

        Dim varstatus As Integer
        If Radio_Stop.Checked = True Then varstatus = 1
        If Radio_Avalible.Checked = True Then varstatus = 0


        Dim sql2 As String
        sql2 = "UPDATE  St_SuppliserData  SET Cur_Code ='" & varcodecur & "',  Supliser_AccountNoGroup='" & varcodeaccountgroup & "' , Supliser_Name = '" & txt_name.Text & "',Supliser_NationalID ='" & txt_NationalID.Text & "',Supliser_Address ='" & txt_Addres.Text & "',Supliser_Phon1 ='" & txt_Phone1.Text & "',Supliser_Phon2 ='" & txt_Phone2.Text & "',Supliser_Website ='" & txt_Website.Text & "',Supliser_Email ='" & txt_Email.Text & "',Supliser_Notes ='" & txt_Notes.Text & "' ,Code_Region ='" & varcodeRegion & "',Supliser_Creditlimit='" & txt_Creditlimit.Text & "',Supliser_Flag = " & varstatus & " , Supliser_FileNoTax ='" & txt_FileNo_Tax.Text & "', supliser_regfile ='" & txt_NoReg_Tax.Text & "' , supliser_trade ='" & txt_NoFileTogary.Text & "', supliser_response = '" & txt_NameM.Text & "',Supliser_Type = '" & txt_catogry_cust.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Supliser_Code ='" & txt_Code.Text & "'  "
        rs = Cnn.Execute(sql2)



        sql = "UPDATE  St_SuppliserData  SET Account_No = '" & txt_AccountNo.Text & "' WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'    "
        rs = Cnn.Execute(sql2)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")

        clear()
        last_Data()
        lastAccounno()
        find_SupliserAll()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        sql = "Delete St_SuppliserData  WHERE Compny_Code = " & VarCodeCompny & " and Supliser_Code ='" & txt_Code.Text & "'  "
        rs = Cnn.Execute(sql)

        sql = "Delete ST_CHARTOFACCOUNT  WHERE Compny_Code = " & VarCodeCompny & " and Account_No ='" & txt_AccountNo.Text & "'  "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        clear()
        last_Data()
        lastAccounno()
        find_SupliserAll()
    End Sub

    Private Sub Cmd_AccountNoGroup_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Cmd_AccountNoGroup.ButtonClick
        vartable = "Vw_LookupAccountLv2"
        VarOpenlookup = 32
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

        clear()
        'last_Data()
        'lastAccounno()
        'txt_name.Select()
    End Sub

    Private Sub Cmd_AccountNoGroup_EditValueChanged(sender As Object, e As EventArgs) Handles Cmd_AccountNoGroup.EditValueChanged

    End Sub

    Private Sub Frm_suppliersInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        find_SupliserAll()

        'find_Supliser_Card()
        'sum_total()
    End Sub

    Private Sub txt_Region_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Region.ButtonClick
        vartable = "BD_REGION"
        VarOpenlookup = 33
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub







    Private Sub txt_ItemName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameItem.ButtonClick
        varcode_form = 255
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
    End Sub

    Private Sub txt_ItemName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameItem.EditValueChanged

    End Sub



    Private Sub Cmd_SaveAcc_Click(sender As Object, e As EventArgs) Handles Cmd_SaveAcc.Click

        ''=============================================Item
        sql = "  SELECT        Code, Name       FROM dbo.BD_ITEM WHERE        (Name = '" & txt_NameItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeItem = rs("code").Value


        sql = "INSERT INTO TB_SuppliserOnItem (Supliser_Code, Code_Item,Compny_Code) " & _
            " values  ('" & valueNoSuppliser & "' ,'" & varcodeItem & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)


        MsgBox("تم الحفظ ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_Item()
    End Sub

    Private Sub Cmd_DeleteAcc_Click(sender As Object, e As EventArgs) Handles Cmd_DeleteAcc.Click
        ''=============================================Item
        sql = "  SELECT        Code, Name       FROM dbo.BD_ITEM WHERE        (Name = '" & txt_NameItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeItem = rs("code").Value

        ''==================================================delete
        sql = "Delete TB_SuppliserOnItem  WHERE Supliser_Code = " & valueNoSuppliser & " and Code_Item  = " & varcodeItem & " and Compny_Code  = " & VarCodeCompny & "  "
        rs = Cnn.Execute(sql)

        ''==========================================
        MsgBox("تم الحذف ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_Item()

    End Sub

   

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub txt_cur_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_cur.ButtonClick
        vartable = "BD_Currency"
        VarOpenlookup = 50
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_cur_EditValueChanged(sender As Object, e As EventArgs) Handles txt_cur.EditValueChanged

    End Sub

    Private Sub txt_catogry_cust_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_catogry_cust.ButtonClick
        vartable = "BD_CatograySuppliser"
        VarOpenlookup = 51
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.ShowDialog()
    End Sub

  
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick1(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))



        '===================================Find

        '  sql = " SELECT St_SuppliserData.Supliser_Code, St_SuppliserData.Compny_Code, St_SuppliserData.Supliser_AccountNo, St_SuppliserData.Supliser_AccountNoGroup, " & _
        '"              RTRIM(ST_CHARTOFACCOUNT.AccountName) AS AccountName, St_SuppliserData.Supliser_Name, St_SuppliserData.Supliser_Type, St_SuppliserData.Supliser_Religion,  " & _
        '"    St_SuppliserData.Supliser_NationalID, St_SuppliserData.Supliser_Address, St_SuppliserData.Supliser_Phon1, St_SuppliserData.Supliser_Phon2, St_SuppliserData.Supliser_Website, " & _
        '"                St_SuppliserData.Supliser_Email, St_SuppliserData.Supliser_Notes, BD_REGION.Name As NameRejon,IIF(St_SuppliserData.Supliser_Flag=0,'سارى','متوقف') as Status, St_SuppliserData.Supliser_Creditlimit " & _
        '" FROM     St_SuppliserData INNER JOIN " & _
        '"                  ST_CHARTOFACCOUNT ON St_SuppliserData.Supliser_AccountNoGroup = ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN " & _
        '"                  BD_REGION ON St_SuppliserData.Code_Region = BD_REGION.Code " & _
        '"       where St_SuppliserData.Supliser_Code = '" & value & "' And St_SuppliserData.Compny_Code = '" & VarCodeCompny & "' "

        sql = "  SELECT dbo.St_SuppliserData.Supliser_Code, dbo.St_SuppliserData.Compny_Code, dbo.St_SuppliserData.Supliser_AccountNo, dbo.St_SuppliserData.Supliser_AccountNoGroup, " & _
  "                  RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS AccountName, dbo.St_SuppliserData.Supliser_Name, dbo.St_SuppliserData.Supliser_Type, dbo.St_SuppliserData.Supliser_Religion,  " & _
  "        dbo.St_SuppliserData.Supliser_NationalID, dbo.St_SuppliserData.Supliser_Address, dbo.St_SuppliserData.Supliser_Phon1, dbo.St_SuppliserData.Supliser_Phon2, dbo.St_SuppliserData.Supliser_Website, " & _
  "                  dbo.St_SuppliserData.Supliser_Email, dbo.St_SuppliserData.Supliser_Notes, dbo.BD_REGION.Name AS NameRejon, dbo.St_SuppliserData.Supliser_Creditlimit, dbo.BD_Currency.Name AS NameCur,  dbo.St_SuppliserData.supliser_regfile, dbo.St_SuppliserData.supliser_trade, dbo.St_SuppliserData.supliser_response,dbo.St_SuppliserData.Supliser_FileNoTax " & _
  " FROM     dbo.St_SuppliserData INNER JOIN " & _
  "                  dbo.ST_CHARTOFACCOUNT ON dbo.St_SuppliserData.Supliser_AccountNoGroup = dbo.ST_CHARTOFACCOUNT.Account_No LEFT OUTER JOIN " & _
  "                  dbo.BD_Currency ON dbo.St_SuppliserData.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.St_SuppliserData.Cur_Code = dbo.BD_Currency.Code LEFT OUTER JOIN " & _
  "                  dbo.BD_REGION ON dbo.St_SuppliserData.Code_Region = dbo.BD_REGION.Code " & _
  " WHERE  (dbo.St_SuppliserData.Supliser_Code = '" & value & "') AND (dbo.St_SuppliserData.Compny_Code =  '" & VarCodeCompny & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Code.Text = rs("Supliser_Code").Value
            txt_name.Text = rs("Supliser_Name").Value
            Cmd_AccountNoGroup.Text = rs("AccountName").Value
            txt_AccountNo.Text = rs("Supliser_AccountNo").Value
            txt_Region.Text = rs("NameRejon").Value
            txt_Creditlimit.Text = rs("Supliser_Creditlimit").Value
            txt_Phone1.Text = rs("Supliser_Phon1").Value
            txt_Phone2.Text = rs("Supliser_Phon2").Value
            txt_Website.Text = rs("Supliser_Website").Value
            txt_Email.Text = rs("Supliser_Email").Value
            txt_Notes.Text = rs("Supliser_Notes").Value
            txt_Addres.Text = rs("Supliser_Address").Value
            txt_NationalID.Text = rs("Supliser_NationalID").Value
            txt_NationalID.Text = rs("Supliser_NationalID").Value
            txt_cur.Text = rs("NameCur").Value
            txt_catogry_cust.Text = rs("Supliser_Type").Value
            txt_FileNo_Tax.Text = rs("Supliser_FileNoTax").Value
            txt_NoReg_Tax.Text = rs("supliser_regfile").Value
            txt_NoFileTogary.Text = rs("supliser_trade").Value
            txt_NameM.Text = rs("supliser_response").Value
            If rs("Supliser_Flag").Value = 0 Then
                Radio_Avalible.Checked = True
            Else
                Radio_Stop.Checked = True
            End If

        Else
            clear()
        End If
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        txt_NameItem.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))
    End Sub

    Private Sub txt_catogry_cust_EditValueChanged(sender As Object, e As EventArgs) Handles txt_catogry_cust.EditValueChanged

    End Sub
End Class