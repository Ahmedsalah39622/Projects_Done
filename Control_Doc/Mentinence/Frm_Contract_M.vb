Imports System.Data.OleDb

Public Class Frm_Contract_M

    Dim value2 As Integer
    Sub last_Data()

        sql = "  SELECT        MAX(Contract_Code) AS MaxMaim,Compny_Code FROM            TB_Header_Contract  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(Contract_Code) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_ContractNo.Text = rs("MaxMaim").Value + 1


        Else
            Com_ContractNo.Text = 1



        End If
    End Sub



    Sub clear()

        txt_AddressCustomer.Text = ""
        Com_CustomeName.Text = ""
        txt_Notes.Text = ""
        txt_CountVisit.Text = ""
        txt_MachineName.Text = ""
        Com_CountMonth.Text = ""
        txt_datestr.Text = ""
        txt_DateEnd.Text = ""
        txt_discription.Text = ""
    End Sub

    Private Sub Com_CustomeName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_CustomeName.ButtonClick
        VarOpenlookup2 = 32
        varcode_form = 32
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        find_customer2()
    End Sub
    Sub find_customer2()
        On Error Resume Next
        sql = "  SELECT        Compny_Code, Customer_Code, Customer_Name, Customer_Address, Customer_Phon1      FROM dbo.St_CustomerData WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Customer_Name = '" & Com_CustomeName.Text & "')"
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then txt_AddressCustomer.Text = rs2("Customer_Address").Value : txt_Phone.Text = rs2("Customer_Phon1").Value Else txt_AddressCustomer.Text = "" : txt_Phone.Text = ""

    End Sub


    



    Sub save_oderDetils()

        '============================EXitem
        sql = "   SELECT *     FROM BD_ITEM    WHERE(name = '" & txt_MachineName.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeitem = Trim(rs("code").Value)




        sql = "INSERT INTO TB_Detils_Contract (Contract_Code,Compny_Code,Code_Item,Discription_Machine) " & _
              " values  ('" & Com_ContractNo.Text & "' ,'" & VarCodeCompny & "','" & varcodeitem & "','" & txt_discription.Text & "')"
        Cnn.Execute(sql)



    End Sub

    Private Sub Cmd_New_Click_1(sender As Object, e As EventArgs) Handles Cmd_New.Click
        last_Data()
        clear()
        find_detalis()
    End Sub

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs) Handles Cmd_save.Click
        On Error Resume Next
        If CDate(txt_datestr.Text) > CDate(txt_DateEnd.Text) Then MsgBox("من فضلك تاريخ بداية التعاقد اكبر من نهاية التعاقد انتبة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_datestr.Select() : Exit Sub
        If IsDate(txt_datestr.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_datestr.Select() : Exit Sub
        If IsDate(txt_DateEnd.Text) = False Then MsgBox("من فضلك ادخل التاريخ بشكل صحيح ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_DateEnd.Select() : Exit Sub
        If Len(Com_ContractNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم العقد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "CSS Solution Software Module") : Exit Sub
        If Com_CustomeName.Text = "" Then MsgBox("من فضلك اختار العميل", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_CountVisit.Text = "" Then MsgBox("من فضلك أدخل عدد الزيارات", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If Com_CountMonth.Text = "" Then MsgBox("من فضلك أدخل كل كام شهر", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        If txt_MachineName.Text = "" Then MsgBox("من فضلك ادخل الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_datestr.Select() : Exit Sub
        If txt_discription.Text = "" Then MsgBox("من فضلك ادخل وصف الماكينة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : txt_DateEnd.Select() : Exit Sub

        If Op1.Checked = False And Op2.Checked = False Then MsgBox("من فضلك اختار نوع التعاقد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '=========================تاريخ البداية
        Dim dd As DateTime = txt_datestr.Text
        Dim vardatStr As String
        vardatStr = dd.ToString("MM-d-yyyy")

        '=========================تاريخ البداية
        Dim dd2 As DateTime = txt_DateEnd.Text
        Dim vardatend As String
        vardatend = dd2.ToString("MM-d-yyyy")
        '=======================================


        sql = "select * from TB_Header_Contract where Contract_Code  = " & Com_ContractNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

        Else

            If Op1.Checked = True Then varstatus = 1
            If Op2.Checked = True Then varstatus = 0

            Dim varcodecoustomer As Integer
            '========================================================رقم العميل
            sql = "SELECT *  FROM St_CustomerData where Customer_Name ='" & Com_CustomeName.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
            rs3 = Cnn.Execute(sql)
            If rs3.EOF = False Then varcodecoustomer = rs3("Customer_Code").Value
            '============================================================

            sql = "INSERT INTO TB_Header_Contract (Contract_Code, Compny_Code,Customer_Code,Contract_StrDate,Contract_EndDate,Contract_Type,Visit_Count,Contract_MonthCount,Notes) " & _
                      " values  ('" & Com_ContractNo.Text & "' ,'" & VarCodeCompny & "','" & varcodecoustomer & "','" & vardatStr & "','" & vardatend & "','" & varstatus & "','" & txt_CountVisit.Text & "','" & Com_CountMonth.Text & "','" & txt_Notes.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        find_detalis()
        'clear_detils()
        'find_detalis()
    End Sub


    Sub find_detalis()


        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "    SELECT        dbo.TB_Detils_Contract.Code_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_Contract.Discription_Machine " & _
        " FROM            dbo.TB_Detils_Contract INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.TB_Detils_Contract.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_Contract.Code_Item = dbo.BD_ITEM.Code " & _
        " WHERE        (dbo.TB_Detils_Contract.Contract_Code = '" & Com_ContractNo.Text & "') AND (dbo.TB_Detils_Contract.Compny_Code ='" & VarCodeCompny & "') "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "75"
        GridView5.Columns(1).Width = "200"
        GridView5.Columns(2).Width = "200"



        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "كود الصنف"
        GridView5.Columns(1).Caption = "الماكينة "
        GridView5.Columns(2).Caption = "وصف الماكينة"


        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub


    Sub find_All()
        'On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        '     sql2 = "   SELECT        dbo.TB_Header_Contract.Contract_Code, dbo.St_CustomerData.Customer_Name, dbo.St_CustomerData.Customer_Address, dbo.St_CustomerData.Customer_Phon1, dbo.TB_Header_Contract.Contract_StrDate,  " & _
        '"                         dbo.TB_Header_Contract.Contract_EndDate, dbo.TB_Header_Contract.Visit_Count, dbo.TB_Header_Contract.Contract_MonthCount,, iif(dbo.TB_Header_Contract.Contract_Type =0 ,'غير شامل قطع الغيار','شامل قطع الغيار') as Status,dbo.TB_Header_Contract.Notes  " & _
        '" FROM            dbo.TB_Header_Contract INNER JOIN  " & _
        '"                         dbo.St_CustomerData ON dbo.TB_Header_Contract.Customer_Code = dbo.St_CustomerData.Customer_Code AND dbo.TB_Header_Contract.Compny_Code = dbo.St_CustomerData.Compny_Code  " & _
        '" WHERE        (dbo.TB_Header_Contract.Compny_Code = '" & VarCodeCompny & "') "

        sql2 = "select * from vw_AllContractM where Compny_Code = '" & VarCodeCompny & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl6.DataSource = ds.Tables(0)

        GridView11.Columns(0).Width = "75"
        GridView11.Columns(1).Width = "200"
        GridView11.Columns(2).Width = "200"
        GridView11.Columns(3).Width = "100"
        GridView11.Columns(4).Width = "100"
        GridView11.Columns(5).Width = "100"
        GridView11.Columns(6).Width = "100"
        GridView11.Columns(7).Width = "100"
        GridView11.Columns(8).Width = "200"
        GridView11.Columns(9).Width = "100"



        GridView11.Appearance.Row.Font = New Font(GridView11.Appearance.Row.Font, FontStyle.Bold)
        GridView11.Appearance.Row.Options.UseFont = True

        GridView11.Columns(0).Caption = "رقم العقد"
        GridView11.Columns(1).Caption = "اسم العميل "
        GridView11.Columns(2).Caption = "عنوان العميل"
        GridView11.Columns(3).Caption = "تليفون العميل"
        GridView11.Columns(4).Caption = "بداية التعاقد"
        GridView11.Columns(5).Caption = "نهاية التعاقد"
        GridView11.Columns(6).Caption = "عدد الزيارات"
        GridView11.Columns(7).Caption = "الشهور"
        GridView11.Columns(8).Caption = "حالة قطع الغيار"
        GridView11.Columns(9).Caption = "ملاحظات"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub


    Private Sub txt_MachineName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_MachineName.ButtonClick
        vartable = "Vw_listItem"
        VarOpenlookup = 74
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_MachineName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_MachineName.EditValueChanged

    End Sub

    Private Sub Frm_Contract_M_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 12
            Com_CountMonth.Items.Add(i)
        Next
        find_All()
    End Sub

    Private Sub GridControl6_Click(sender As Object, e As EventArgs) Handles GridControl6.Click

    End Sub

    Private Sub GridControl6_DoubleClick(sender As Object, e As EventArgs) Handles GridControl6.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView11.FocusedRowHandle
        value2 = GridView11.GetRowCellValue(visibleRowHandle, GridView11.Columns(0))
        clear()
        sql = " select * From vw_AllContractM where Contract_Code='" & value2 & "' and   Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_ContractNo.Text = rs("Contract_Code").Value
            Com_CustomeName.Text = rs("Customer_Name").Value
            txt_AddressCustomer.Text = rs("Customer_Address").Value
            txt_Phone.Text = rs("Customer_Phon1").Value
            txt_datestr.Text = rs("Contract_StrDate").Value
            txt_DateEnd.Text = rs("Contract_EndDate").Value
            txt_CountVisit.Text = rs("Visit_Count").Value
            txt_Notes.Text = rs("Notes").Value
            Com_CountMonth = rs("Contract_MonthCount").Value
            If rs("aa").Value = "شامل قطع الغيار" Then Op1.Checked = True : Op2.Checked = False
            If rs("aa").Value <> "شامل قطع الغيار" Then Op2.Checked = True : Op1.Checked = False
        End If
        TabPane1.SelectedPageIndex = 0
        detils_find()
    End Sub


    Sub detils_find()




        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "    SELECT        dbo.BD_ITEM.Code, dbo.BD_ITEM.Name, dbo.TB_Detils_Contract.Discription_Machine " & _
    " FROM            dbo.TB_Detils_Contract INNER JOIN " & _
    "                         dbo.BD_ITEM ON dbo.TB_Detils_Contract.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Detils_Contract.Code_Item = dbo.BD_ITEM.Code " & _
    " WHERE        (dbo.TB_Detils_Contract.Contract_Code = '" & value2 & "') AND (dbo.TB_Detils_Contract.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "75"
        GridView5.Columns(1).Width = "200"
        GridView5.Columns(2).Width = "200"
       


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم الصنف"
        GridView5.Columns(1).Caption = "اسم الماكينة "
        GridView5.Columns(2).Caption = "وصف الماكينة"
       

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub
End Class