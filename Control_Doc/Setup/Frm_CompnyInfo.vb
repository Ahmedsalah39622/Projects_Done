Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_CompnyInfo
    Dim varcodecity, varcodeRegion As Integer
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        last_Data()
        clear()
    End Sub
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Compny_Code) AS MaxmamNo FROM St_CompnyInfo HAVING(MAX(Compny_Code) Is Not NULL) "

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
        txt_CityName.Text = ""
        txt_Activety.Text = ""
        txt_Phone1.Text = ""
        txt_Phone2.Text = ""
        txt_fax.Text = ""
        txt_Box.Text = ""
        txt_Website.Text = ""
        txt_Address.Text = ""
        txt_Email.Text = ""
        txt_picpath.Text = ""
        txt_Notes.Text = ""
        txt_Reigon.Text = ""
    End Sub

    Private Sub txt_CityName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CityName.ButtonClick
        vartable = "BD_CITIES"
        VarOpenlookup = 4
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

   

    

    Private Sub ButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Reigon.ButtonClick
        vartable = "BD_REGION"
        VarOpenlookup = 5
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub



    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        vartable = "BD_REGION"
        Frm_GenralData.Close()
        Frm_GenralData.Text = "أكواد المناطق"
        Frm_GenralData.ShowDialog()
    End Sub


    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CityName.Text) = 0 Then MsgBox("من فضلك ادخل أسم المدينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Reigon.Text) = 0 Then MsgBox("من فضلك ادخل أسم المنطقة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone2.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


        sql = "SELECT     * " & _
        " FROM         St_CompnyInfo WHERE     (Compny_Code = " & txt_Code.Text & ")"
        'Cnn.Execute(sql)
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            MsgBox("الرقم تكرر لايمكن حفظه مرة اخرى", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module")
        Else

            CheckRegion_CITIES()


            Dim sql2 As String
            sql2 = "INSERT INTO St_CompnyInfo (Compny_Code, Compny_Name,Code_City,Code_Regione,Activity,Compny_Address,Compny_Logo,Compny_Phone1,Compny_Phone2,Compny_Fax,Compny_Box,Compny_Website,Compny_Email,Notes) " & _
              " values  ('" & txt_Code.Text & "' ,'" & txt_name.Text & "','" & varcodecity & "','" & varcodeRegion & "','" & txt_Activety.Text & "','" & txt_Address.Text & "','" & txt_picpath.Text & "','" & txt_Phone1.Text & "','" & txt_Phone2.Text & "','" & txt_fax.Text & "','" & txt_Box.Text & "','" & txt_Website.Text & "','" & txt_Email.Text & "','" & txt_Notes.Text & "')"
            rs = Cnn.Execute(sql2)
            MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

            clear()
            last_Data()
            Search()
            Find()
        End If
    End Sub


    Sub Search()
        'On Error Resume Next

        sql = "  SELECT St_CompnyInfo.Compny_Code, St_CompnyInfo.Compny_Name, BD_CITIES.Name AS NameCity, BD_REGION.Name AS NameRegion, St_CompnyInfo.Activity, St_CompnyInfo.Compny_Address  " & _
            "         , St_CompnyInfo.Compny_Phone1, St_CompnyInfo.Compny_Fax, St_CompnyInfo.Compny_Website, St_CompnyInfo.Compny_Email,   " & _
            "   St_CompnyInfo.Compny_Phone2, St_CompnyInfo.Compny_Box, St_CompnyInfo.Notes  " & _
            " FROM     BD_REGION INNER JOIN  " & _
            "                 BD_CITIES ON BD_REGION.Code = BD_CITIES.Code INNER JOIN  " & _
            "                 St_CompnyInfo ON BD_CITIES.Code = St_CompnyInfo.Code_City  "

        find_AllData()
    End Sub
    Sub Find()
        'On Error Resume Next


        sql = "  SELECT St_CompnyInfo.Compny_Code, St_CompnyInfo.Compny_Name From St_CompnyInfo "

        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView2.Columns(0).Caption = "الكود"
            GridView2.Columns(1).Caption = "الاسم"
            GridView2.Columns(0).Width = "20"
            GridView2.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView2.Columns(0).Caption = "الكود"
            GridView2.Columns(1).Caption = "الاسم"
            GridView2.Columns(0).Width = "20"
            GridView2.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub Frm_CompnyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
        Find()
    End Sub

    
    Sub find_AllData()
        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl2.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(2).Caption = " المدينة"
            GridView1.Columns(3).Caption = "المنطقة"
            GridView1.Columns(4).Caption = "النشاط"
            GridView1.Columns(5).Caption = "العنوان"
            GridView1.Columns(6).Caption = "تليفون 1"
            GridView1.Columns(7).Caption = "الفاكس"
            GridView1.Columns(8).Caption = "الموقع الالكترونى"
            GridView1.Columns(9).Caption = "الايميل"
            GridView1.Columns(10).Caption = "تليفون 2"
            GridView1.Columns(11).Caption = "صندوق بريد"
            GridView1.Columns(12).Caption = "ملاحظات"


            GridView1.Columns(0).Width = "50"
            GridView1.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl2.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(2).Caption = " المدينة"
            GridView1.Columns(3).Caption = "المنطقة"
            GridView1.Columns(4).Caption = "النشاط"
            GridView1.Columns(5).Caption = "العنوان"
            GridView1.Columns(6).Caption = "تليفون 1"
            GridView1.Columns(7).Caption = "الفاكس"
            GridView1.Columns(8).Caption = "الموقع الالكترونى"
            GridView1.Columns(9).Caption = "الايميل"
            GridView1.Columns(10).Caption = "تليفون 2"
            GridView1.Columns(11).Caption = "صندوق بريد"
            GridView1.Columns(12).Caption = "ملاحظات"
            GridView1.Columns(0).Width = "50"
            GridView1.Columns(1).Width = "150"
            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub

    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        If Len(txt_Code.Text) = 0 Then MsgBox("من فضلك ادخل الكود ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_name.Text) = 0 Then MsgBox("من فضلك ادخل الاسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_CityName.Text) = 0 Then MsgBox("من فضلك ادخل أسم المدينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Reigon.Text) = 0 Then MsgBox("من فضلك ادخل أسم المنطقة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone1.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 1 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Phone2.Text) = 0 Then MsgBox("من فضلك ادخل تليفون 2 ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

       
        CheckRegion_CITIES()
        Dim sql2 As String
        sql2 = "UPDATE  St_CompnyInfo  SET Compny_Name='" & txt_name.Text & "' , Code_City = '" & varcodecity & "',Code_Regione ='" & varcodeRegion & "',Activity ='" & txt_Activety.Text & "',Compny_Address ='" & txt_Address.Text & "',Compny_Phone1 ='" & txt_Phone1.Text & "',Compny_Phone2 ='" & txt_Phone2.Text & "',Compny_Fax ='" & txt_fax.Text & "',Compny_Website ='" & txt_Website.Text & "',Compny_Email ='" & txt_Email.Text & "',Compny_Box ='" & txt_Box.Text & "' ,Notes ='" & txt_Notes.Text & "'  WHERE Compny_Code = " & txt_Code.Text & "   "
        rs = Cnn.Execute(sql2)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        Search()
        Find()


    End Sub
    Sub CheckRegion_CITIES()

        '======================================City
        sql = "SELECT     * " & _
        " FROM         BD_CITIES WHERE     (Name = '" & txt_CityName.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodecity = rs("Code").Value

        '======================================Region
        sql = "SELECT     * " & _
        " FROM         BD_REGION WHERE     (Name = '" & txt_Reigon.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeRegion = rs("Code").Value
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        sql = "Delete St_CompnyInfo  WHERE Compny_Code = " & txt_Code.Text & " "
        rs = Cnn.Execute(sql)

        MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        Search()
        Find()
        clear()
    End Sub

    
   

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim visibleRowHandle As Integer = GridView2.FocusedRowHandle
        Dim value = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(0))
        Dim value2 = GridView2.GetRowCellValue(visibleRowHandle, GridView2.Columns(1))


        '===================================Find
        sql = "  SELECT St_CompnyInfo.Compny_Code, St_CompnyInfo.Compny_Name, BD_CITIES.Name AS NameCity, BD_REGION.Name AS NameRegion, St_CompnyInfo.Activity, St_CompnyInfo.Compny_Address  " & _
        "         , St_CompnyInfo.Compny_Phone1, St_CompnyInfo.Compny_Fax, St_CompnyInfo.Compny_Website, St_CompnyInfo.Compny_Email,   " & _
        "   St_CompnyInfo.Compny_Phone2, St_CompnyInfo.Compny_Box, St_CompnyInfo.Notes  " & _
        " FROM     BD_REGION INNER JOIN  " & _
        "                 BD_CITIES ON BD_REGION.Code = BD_CITIES.Code INNER JOIN  " & _
        "                 St_CompnyInfo ON BD_CITIES.Code = St_CompnyInfo.Code_City where St_CompnyInfo.Compny_Code ='" & value & "' "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txt_Code.Text = rs("Compny_Code").Value
            txt_name.Text = rs("Compny_Name").Value
            txt_CityName.Text = rs("NameCity").Value
            txt_Reigon.Text = rs("NameRegion").Value
            txt_Activety.Text = rs("Activity").Value
            txt_Address.Text = rs("Compny_Address").Value
            txt_Phone1.Text = rs("Compny_Phone1").Value
            txt_Phone2.Text = rs("Compny_Phone2").Value
            txt_fax.Text = rs("Compny_Fax").Value
            txt_Website.Text = rs("Compny_Website").Value
            txt_Email.Text = rs("Compny_Email").Value
            txt_Box.Text = rs("Compny_Box").Value
            txt_Notes.Text = rs("Notes").Value
            Label2.Text = rs("Compny_Code").Value
            Label3.Text = rs("Compny_Name").Value
        Else
            clear()
        End If
    End Sub

    Private Sub txt_CityName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CityName.EditValueChanged

    End Sub
End Class