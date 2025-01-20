Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Public Class Frm_CurrentEmployee
    Dim varcodestat, vardirctoratcode, varcodedeprt, varcodecontract, VARCODEQUALIFICATIONS, VARCODEJOBNAMES, VARCODEBUILDINGS As Integer
    Dim varDel As Integer
    Dim varaccountnomain As String
    Sub clear()
        'txtCode.Text = ""
        Txt_EmpName.Text = ""
        Com_EmpSex.Text = ""
        com_Relajan.Text = ""
        txt_date.Text = ""
        txt_National_ID.Text = ""
        txt_address.Text = ""
        txt_NameDept.Text = ""
        txt_NameDiractorat.Text = ""
        txt_NameTy.Text = ""
        Txt_NameSt.Text = ""
        txt_NameMohel.Text = ""
        txt_Nametypjop.Text = ""
        Com_Bulidno.Text = ""
        Com_TypeKbd.Text = ""
        txt_tel1.Text = ""
        txt_tel2.Text = ""
        txt_notameny.Text = ""
        txt_BasicSalary.Text = ""
        txt_TotSalary.Text = ""
        DateTimePicker3.Text = ""
        txt_BranchCode.Text = ""
        txt_BranchName.Text = ""
        TXt_NoAccountBank.Text = ""
        Txt_reson.Text = ""
        SimpleButton7.Enabled = True
        SimpleButton5.Enabled = False
        SimpleButton8.Enabled = False
    End Sub
    Sub find_PeriodAll()
        Dim sql2 As String
        sql2 = "select    St_CustomerData.Customer_Code, St_CustomerData.Customer_Name, Vw_LookupAccountLv2.name AS NameGroup, St_CustomerData.Customer_Type, " & _
   "                  St_CustomerData.Customer_Religion, St_CustomerData.Customer_NationalID, St_CustomerData.Customer_Address, St_CustomerData.Customer_Phon1, St_CustomerData.Customer_Phon2,  " & _
   "        St_CustomerData.Customer_Website, St_CustomerData.Customer_Email, St_CustomerData.Customer_Notes, BD_REGION.Name, St_CustomerData.Customer_Creditlimit, " & _
   "                  IIF( St_CustomerData.Customer_Flag=0,'سارى','متوقف') as Status " & _
   " FROM     St_CustomerData LEFT OUTER JOIN " & _
   "                  Vw_LookupAccountLv2 ON St_CustomerData.Customer_AccountNoGroup = Vw_LookupAccountLv2.code LEFT OUTER JOIN " & _
   "                  BD_REGION ON St_CustomerData.Code_Region = BD_REGION.Code " & _
   "        WHERE(St_CustomerData.Compny_Code = '" & VarCodeCompny & "') " & _
   " ORDER BY St_CustomerData.Customer_Code "

        If varCodeConnaction = 1 Then '======Sql

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
            GridView1.Columns(0).Caption = "كود العميل"
            GridView1.Columns(1).Caption = "أسم العميل"
            GridView1.Columns(2).Caption = "أسم الحساب الرئيسى"
            GridView1.Columns(3).Caption = "النوع"
            GridView1.Columns(4).Caption = "الديانة"
            GridView1.Columns(5).Caption = "الرقم القومى"
            GridView1.Columns(6).Caption = "العنوان"
            GridView1.Columns(7).Caption = "تليفون 1"
            GridView1.Columns(8).Caption = "تليفون 2"
            GridView1.Columns(9).Caption = "الموقع الالكترونى "
            GridView1.Columns(10).Caption = "Email"
            GridView1.Columns(11).Caption = "ملاحظات"
            GridView1.Columns(12).Caption = "المنطقة"
            GridView1.Columns(13).Caption = "الحالة"

            GridView1.Columns(0).Width = "100"
            GridView1.Columns(1).Width = "500"
            GridView1.Columns(2).Width = "100"
            GridView1.Columns(3).Width = "100"
            GridView1.Columns(4).Width = "100"
            GridView1.Columns(5).Width = "100"
            GridView1.Columns(6).Width = "100"
            GridView1.Columns(7).Width = "100"
            GridView1.Columns(8).Width = "100"
            GridView1.Columns(9).Width = "100"
            GridView1.Columns(10).Width = "100"
            GridView1.Columns(11).Width = "100"
            GridView1.Columns(12).Width = "100"
            GridView1.Columns(13).Width = "100"

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
            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView1.Columns(0).Caption = "كود العميل"
            GridView1.Columns(1).Caption = "أسم العميل"
            GridView1.Columns(2).Caption = "أسم الحساب الرئيسى"
            GridView1.Columns(3).Caption = "النوع"
            GridView1.Columns(4).Caption = "الديانة"
            GridView1.Columns(5).Caption = "الرقم القومى"
            GridView1.Columns(6).Caption = "العنوان"
            GridView1.Columns(7).Caption = "تليفون 1"
            GridView1.Columns(8).Caption = "تليفون 2"
            GridView1.Columns(9).Caption = "الموقع الالكترونى "
            GridView1.Columns(10).Caption = "Email"
            GridView1.Columns(11).Caption = "ملاحظات"
            GridView1.Columns(12).Caption = "المنطقة"
            GridView1.Columns(13).Caption = "الحالة"

            GridView1.Columns(0).Width = "50"
            GridView1.Columns(1).Width = "200"
            GridView1.Columns(2).Width = "100"
            GridView1.Columns(3).Width = "100"
            GridView1.Columns(4).Width = "100"
            GridView1.Columns(5).Width = "100"
            GridView1.Columns(6).Width = "100"
            GridView1.Columns(7).Width = "100"
            GridView1.Columns(8).Width = "100"
            GridView1.Columns(9).Width = "100"
            GridView1.Columns(10).Width = "100"
            GridView1.Columns(11).Width = "100"
            GridView1.Columns(12).Width = "100"
            GridView1.Columns(13).Width = "100"


            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub








    Private Sub txt_NameDept_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameDept.ButtonClick
        vartable = "BD_DEPARTMENTS"
        VarOpenlookup = 13
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_Nametypjop_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Nametypjop.ButtonClick
        vartable = "BD_JOBNAMES"
        VarOpenlookup = 14
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub




    Private Sub txt_NameTy_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameTy.ButtonClick
        vartable = "BD_TYPEOFCNTRACT"
        VarOpenlookup = 15
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_NameMohel_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameMohel.ButtonClick
        vartable = "BD_QUALIFICATIONS"
        VarOpenlookup = 16
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Bulidno_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Bulidno.ButtonClick


        vartable = "BD_BUILDINGS"
        VarOpenlookup = 17
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub


    Private Sub Com_Bulidno_DoubleClick(sender As Object, e As EventArgs) Handles Com_Bulidno.DoubleClick

        vartable = "BD_BUILDINGS"
        VarOpenlookup = 8
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()

    End Sub

    Private Sub Frm_CurrentEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_TypeKbd.Items.Add("معيينين")
        Com_TypeKbd.Items.Add("مكافأة")
        Com_TypeKbd.Items.Add("معار")

        Com_EmpSex.Items.Add("ذكر")
        Com_EmpSex.Items.Add("انثى")

        com_Relajan.Items.Add("مسلم")
        com_Relajan.Items.Add("مسيحى")

        'Find()
        Find_all_EMP()
        Find_all_EMP_H()
    End Sub



    Private Sub Txt_NameSt_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Txt_NameSt.ButtonClick
        vartable = "BD_SOCIALSTATUS"
        VarOpenlookup = 18
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub
    Sub last_Data()


        'On Error Resume Next
        sql = "SELECT        MAX(Emp_Code) AS MaxmamNo FROM  Emp_employees where Compny_Code ='" & VarCodeCompny & "'   HAVING (MAX(Emp_Code) IS NOT NULL) "

        'Cnn.Execute(sql)
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            txtCode.Text = rs3("MaxmamNo").Value + 1
        Else
            txtCode.Text = 1
            clear()

        End If
    End Sub
    Sub lastAccounno()
        'clear()
        On Error Resume Next
        ' '' ''txt_accountNo.Text = ""
        ' '' ''sql = "  SELECT        dbo.St_CostCenterLv3Link_Salse.Account_NoMain, dbo.St_CostCenterLv3Link_Salse.Code_Diractorat, dbo.BD_DIRCTORAY.Name " & _
        ' '' ''      " FROM            dbo.St_CostCenterLv3Link_Salse INNER JOIN " & _
        ' '' ''      "                         dbo.BD_DIRCTORAY ON dbo.St_CostCenterLv3Link_Salse.Code_Diractorat = dbo.BD_DIRCTORAY.Code " & _
        ' '' ''      " WHERE        (dbo.BD_DIRCTORAY.Name = '" & Trim(txt_NameDiractorat.Text) & "') and  St_CostCenterLv3Link_Salse.Compny_Code ='" & VarCodeCompny & "' "
        ' '' ''rs = Cnn.Execute(sql)
        ' '' ''If rs.EOF = False Then varaccountnomain = rs("Account_NoMain").Value Else MsgBox("الادارة ليس لها مركز تكلفة من فضلك ادخل مركز تكلفة اولا للادارة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        '===========================================
        'sql = " SELECT MAX(Customer_AccountNo)  AS Maxmaim      FROM dbo.St_CustomerData WHERE  (Compny_Code = '" & VarCodeCompny & "') AND (Customer_AccountNoGroup = '" & varcodeaccountgroup & "') HAVING (MAX(Customer_AccountNo) IS NOT NULL) "
        'txt_accountNo.Text = ""

        'sql = "SELECT        Account_No_Update FROM            dbo.ST_CHARTOFACCOUNT GROUP BY Account_No, Account_No_Update  HAVING        (Account_No_Update LIKE '% " & Trim(varaccountnomain) & " %')"
        'sql = " SELECT        MAX(Account_No) AS MaxAcountNo FROM            dbo.ST_CHARTOFACCOUNT WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (Account_No  ='" & varaccountnomain & "')"

        ' '' ''sql = " SELECT        MAX(Account_No) AS MaxAcountNo, Level_No2 FROM            dbo.ST_CHARTOFACCOUNT GROUP BY Level_No2 HAVING        (Level_No2 = ' " & Trim(varaccountnomain) & " ')"

        ' '' ''rs3 = Cnn.Execute(sql)
        ' '' ''If rs3.EOF = False Then
        ' '' ''    txt_accountNo.Text = rs3("MaxAcountNo").Value + 1
        ' '' ''Else
        ' '' ''    txt_accountNo.Text = Str(varaccountnomain) + "001"
        ' '' ''End If

    End Sub
    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click


        If Len(Txt_EmpName.Text) = 0 Then MsgBox("من فضلك ادخل أسم الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_EmpSex.Text) = 0 Then MsgBox("من فضلك ادخل نوع الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Relajan.Text) = 0 Then MsgBox("من فضلك ادخل الديانة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_NameSt.Text) = 0 Then MsgBox("من فضلك ادخل  الحالة الاجتماعية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDiractorat.Text) = 0 Then MsgBox("من فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDept.Text) = 0 Then MsgBox("من فضلك ادخل القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Nametypjop.Text) = 0 Then MsgBox("من فضلك ادخل نوع الوظيفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameTy.Text) = 0 Then MsgBox("من فضلك ادخل نوع التعاقد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Bulidno.Text) = 0 Then MsgBox("من فضلك رقم المبنى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameMohel.Text) = 0 Then MsgBox("من فضلك أسم المؤهل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_accountNo.Text) = 0 Then MsgBox("من فضلك ادخل مركز التكلفة للأدارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(DateTimePicker3.Text) = 0 Then MsgBox("من فضلك تاريخ استلام العمل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub






        '============================================تاريخ الميلاد
        Dim dd As DateTime = txt_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================تاريخ الالتحاق
        Dim dd2 As DateTime = txt_datetamen.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================تاريخ الاستقالة
        Dim dd3 As DateTime = txt_DateAstkala.Value
        Dim vardate3 As String
        vardate3 = dd2.ToString("MM-d-yyyy")
        '================================================================تاريخ التحويل للتعيين
        Dim dd4 As DateTime = txt_Convert_t3yen.Value
        Dim vardate4 As String
        vardate4 = dd4.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd5 As DateTime = Txt_DateThwel.Value
        Dim vardate5 As String
        vardate5 = dd5.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd6 As DateTime = txt_datetamen.Value
        Dim vardate6 As String
        vardate6 = dd6.ToString("MM-d-yyyy")

        '==================================================================================Stats
        sql = "SELECT *  FROM BD_SOCIALSTATUS where Name ='" & Txt_NameSt.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodestat = rs3("code").Value
        '===================================================================================== الادارة
        sql = "SELECT *  FROM BD_DIRCTORAY where Name ='" & txt_NameDiractorat.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then vardirctoratcode = rs3("code").Value
        '========================================================القسم
        sql = "SELECT *  FROM BD_DEPARTMENTS where Name ='" & txt_NameDept.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodedeprt = rs3("code").Value
        '================================================================نوع العقد
        sql = "SELECT *  FROM BD_TYPEOFCNTRACT where Name ='" & txt_NameTy.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodecontract = rs3("code").Value
        '======================================================نوع المؤهل
        sql = "SELECT *  FROM BD_QUALIFICATIONS where Name ='" & txt_NameMohel.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEQUALIFICATIONS = rs3("code").Value
        '=================================نوع الوظيفة
        sql = "SELECT *  FROM BD_JOBNAMES where Name ='" & txt_Nametypjop.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEJOBNAMES = rs3("code").Value
        '========================================أسم المبنى
        sql = "SELECT *  FROM BD_BUILDINGS where Name ='" & Com_Bulidno.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEBUILDINGS = rs3("code").Value
        '============================================== الباص
        sql = "select * from Emp_employees where Emp_Code ='" & txtCode.Text & "' and  Compny_Code ='" & VarCodeCompny & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("من فضلك أسم الموظف تكرار لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim varcodebus As Integer
        If CheckBus.Checked = True Then
            varcodebus = 1
        Else
            varcodebus = 0
        End If
        '===========================================البصمة
        Dim varcodeCheck_SafySalary As Integer
        If Check_SafySalary.Checked = True Then
            varcodeCheck_SafySalary = 1
        Else
            varcodeCheck_SafySalary = 0
        End If

        Dim dd7 As DateTime = DateTimePicker3.Text
        Dim vardate7 As String
        vardate7 = dd7.ToString("MM-d-yyyy")

        If OP1.Checked = True Then varDel = 1
        If OP2.Checked = True Then varDel = 2
        If OP3.Checked = True Then varDel = 3


        'Reson_trmention='" & Txt_reson.Text   & "'

        sql = "INSERT INTO Emp_employees (Emp_Code, Emp_Name,Emp_Sex,Emp_Rejent,Emp_BirthDay,Emp_National_ID,Emp_Address,Emp_Tel1,Emp_Tel2,Emp_Code_State,Emp_NoTameny,Emp_Code_Dirctorat,Emp_Code_Department,Emp_Code_Contract,Emp_Code_Mohlat,Emp_Code_JopName,Bulid_No,NoAcount_Bank,Date_Trmention,Reson_trmention,Type_Kbd,Date_Convert_Tayen,TotSalary,basicsalary,Convert_t3yenDate,Flgbus,sig,Date_tament,Em_AccountNo,Compny_Code,Emp_DateAlthg,Em_BranchCode,Flg_emp) " & _
            " values  (" & txtCode.Text & " ,N'" & Txt_EmpName.Text & "',N'" & Com_EmpSex.Text & "',N'" & com_Relajan.Text & "',N'" & vardate1 & "',N'" & txt_National_ID.Text & "'  " & _
            " ,N'" & txt_address.Text & "',N'" & txt_tel1.Text & "',N'" & txt_tel2.Text & "',N'" & varcodestat & "',N'" & txt_notameny.Text & "'," & vardirctoratcode & "," & varcodedeprt & "," & varcodecontract & "," & VARCODEQUALIFICATIONS & ",'" & VARCODEJOBNAMES & "','" & VARCODEBUILDINGS & "',N'" & TXt_NoAccountBank.Text & "','" & vardate3 & "',N'" & Txt_reson.Text & "',N'" & Com_TypeKbd.Text & "','" & vardate4 & "',N'" & txt_TotSalary.Text & "',N'" & txt_BasicSalary.Text & "',N'" & vardate5 & "',N'" & varcodebus & "',N'" & varcodeCheck_SafySalary & "',N'" & vardate6 & "',N'" & txt_accountNo.Text & "',N'" & VarCodeCompny & "',N'" & vardate7 & "',N'" & txt_BranchCode.Text & "',N'" & varDel & "')"
        Cnn.Execute(sql)


        '==========================insertChartofaccount
        '        sql = "INSERT INTO ST_CHARTOFACCOUNT (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
        '" values  (N'" & 3 & "' ,N'" & txt_accountNo.Text & "',N'" & txt_accountNo.Text & "',N'" & varaccountnomain & "',N'" & Txt_EmpName.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_accountNo.Text + "-" + Txt_EmpName.Text & "',N'" & txt_accountNo.Text & "','" & VarCodeCompny & "')"
        '        Cnn.Execute(sql)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'Find()
        Find_all_EMP()
        last_Data()
        clear()

    End Sub
    Sub Save_Emp_History()


        If Len(Txt_EmpName.Text) = 0 Then MsgBox("من فضلك ادخل أسم الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_EmpSex.Text) = 0 Then MsgBox("من فضلك ادخل نوع الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Relajan.Text) = 0 Then MsgBox("من فضلك ادخل الديانة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_NameSt.Text) = 0 Then MsgBox("من فضلك ادخل  الحالة الاجتماعية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDiractorat.Text) = 0 Then MsgBox("من فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDept.Text) = 0 Then MsgBox("من فضلك ادخل القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Nametypjop.Text) = 0 Then MsgBox("من فضلك ادخل نوع الوظيفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameTy.Text) = 0 Then MsgBox("من فضلك ادخل نوع التعاقد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Bulidno.Text) = 0 Then MsgBox("من فضلك رقم المبنى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameMohel.Text) = 0 Then MsgBox("من فضلك أسم المؤهل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_accountNo.Text) = 0 Then MsgBox("من فضلك ادخل مركز التكلفة للأدارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(DateTimePicker3.Text) = 0 Then MsgBox("من فضلك تاريخ استلام العمل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub






        '============================================تاريخ الميلاد
        Dim dd As DateTime = txt_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================تاريخ الالتحاق
        Dim dd2 As DateTime = txt_datetamen.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================تاريخ الاستقالة
        Dim dd3 As DateTime = txt_DateAstkala.Value
        Dim vardate3 As String
        vardate3 = dd2.ToString("MM-d-yyyy")
        '================================================================تاريخ التحويل للتعيين
        Dim dd4 As DateTime = txt_Convert_t3yen.Value
        Dim vardate4 As String
        vardate4 = dd4.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd5 As DateTime = Txt_DateThwel.Value
        Dim vardate5 As String
        vardate5 = dd5.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd6 As DateTime = txt_datetamen.Value
        Dim vardate6 As String
        vardate6 = dd6.ToString("MM-d-yyyy")

        '==================================================================================Stats
        sql = "SELECT *  FROM BD_SOCIALSTATUS where Name ='" & Txt_NameSt.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodestat = rs3("code").Value
        '===================================================================================== الادارة
        sql = "SELECT *  FROM BD_DIRCTORAY where Name ='" & txt_NameDiractorat.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then vardirctoratcode = rs3("code").Value
        '========================================================القسم
        sql = "SELECT *  FROM BD_DEPARTMENTS where Name ='" & txt_NameDept.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodedeprt = rs3("code").Value
        '================================================================نوع العقد
        sql = "SELECT *  FROM BD_TYPEOFCNTRACT where Name ='" & txt_NameTy.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodecontract = rs3("code").Value
        '======================================================نوع المؤهل
        sql = "SELECT *  FROM BD_QUALIFICATIONS where Name ='" & txt_NameMohel.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEQUALIFICATIONS = rs3("code").Value
        '=================================نوع الوظيفة
        sql = "SELECT *  FROM BD_JOBNAMES where Name ='" & txt_Nametypjop.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEJOBNAMES = rs3("code").Value
        '========================================أسم المبنى
        sql = "SELECT *  FROM BD_BUILDINGS where Name ='" & Com_Bulidno.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEBUILDINGS = rs3("code").Value
        '============================================== الباص
        sql = "select * from Emp_employees where Emp_Code ='" & txtCode.Text & "' and  Compny_Code ='" & VarCodeCompny & "'  "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then MsgBox("من فضلك أسم الموظف تكرار لايمكن الحفظ مرة اخرى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub



        Dim varcodebus As Integer
        If CheckBus.Checked = True Then
            varcodebus = 1
        Else
            varcodebus = 0
        End If
        '===========================================البصمة
        Dim varcodeCheck_SafySalary As Integer
        If Check_SafySalary.Checked = True Then
            varcodeCheck_SafySalary = 1
        Else
            varcodeCheck_SafySalary = 0
        End If

        Dim dd7 As DateTime = DateTimePicker3.Text
        Dim vardate7 As String
        vardate7 = dd7.ToString("MM-d-yyyy")

        If OP1.Checked = True Then varDel = 1
        If OP2.Checked = True Then varDel = 2
        If OP3.Checked = True Then varDel = 3


        'Reson_trmention='" & Txt_reson.Text   & "'

        sql = "INSERT INTO Emp_employees_H (Emp_Code, Emp_Name,Emp_Sex,Emp_Rejent,Emp_BirthDay,Emp_National_ID,Emp_Address,Emp_Tel1,Emp_Tel2,Emp_Code_State,Emp_NoTameny,Emp_Code_Dirctorat,Emp_Code_Department,Emp_Code_Contract,Emp_Code_Mohlat,Emp_Code_JopName,Bulid_No,NoAcount_Bank,Date_Trmention,Reson_trmention,Type_Kbd,Date_Convert_Tayen,TotSalary,basicsalary,Convert_t3yenDate,Flgbus,sig,Date_tament,Em_AccountNo,Compny_Code,Emp_DateAlthg,Em_BranchCode,Flg_emp) " & _
            " values  (" & txtCode.Text & " ,N'" & Txt_EmpName.Text & "',N'" & Com_EmpSex.Text & "',N'" & com_Relajan.Text & "',N'" & vardate1 & "',N'" & txt_National_ID.Text & "'  " & _
            " ,N'" & txt_address.Text & "',N'" & txt_tel1.Text & "',N'" & txt_tel2.Text & "',N'" & varcodestat & "',N'" & txt_notameny.Text & "'," & vardirctoratcode & "," & varcodedeprt & "," & varcodecontract & "," & VARCODEQUALIFICATIONS & ",'" & VARCODEJOBNAMES & "','" & VARCODEBUILDINGS & "',N'" & TXt_NoAccountBank.Text & "','" & vardate3 & "',N'" & Txt_reson.Text & "',N'" & Com_TypeKbd.Text & "','" & vardate4 & "',N'" & txt_TotSalary.Text & "',N'" & txt_BasicSalary.Text & "',N'" & vardate5 & "',N'" & varcodebus & "',N'" & varcodeCheck_SafySalary & "',N'" & vardate6 & "','" & txt_accountNo.Text & "','" & VarCodeCompny & "',N'" & vardate7 & "',N'" & txt_BranchCode.Text & "',N'" & varDel & "')"
        Cnn.Execute(sql)


        '==========================insertChartofaccount
        '        sql = "INSERT INTO ST_CHARTOFACCOUNT (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
        '" values  (N'" & 3 & "' ,N'" & txt_accountNo.Text & "',N'" & txt_accountNo.Text & "',N'" & varaccountnomain & "',N'" & Txt_EmpName.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_accountNo.Text + "-" + Txt_EmpName.Text & "',N'" & txt_accountNo.Text & "','" & VarCodeCompny & "')"
        '        Cnn.Execute(sql)


        'MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        'Find()
        Find_all_EMP()
        last_Data()
        clear()

    End Sub

    Sub Find_all_EMP()
        On Error Resume Next


        'sql = " SELECT Emp_Code AS Code, Emp_Name AS Name      FROM dbo.Emp_employees where Compny_Code ='" & VarCodeCompny & "'"
        sql = "   SELECT        Emp_Code, Emp_Name, NameDir, NameDeprt, JopName, NameMohel,Emp_DateAlthg,  " & _
       "                     Emp_BirthDay, Emp_Tel1, Emp_Tel2 , Em_BranchCode, BranchName " & _
       " FROM dbo.Vw_Emp where Compny_Code ='" & VarCodeCompny & "' "


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
        GridView1.Columns(0).Caption = "الكود"
        GridView1.Columns(1).Caption = "الاسم"
        GridView1.Columns(2).Caption = "الادارة"
        GridView1.Columns(3).Caption = "القسم"
        GridView1.Columns(4).Caption = "المسمى الوظيفى"
        GridView1.Columns(5).Caption = "المؤهل"
        GridView1.Columns(6).Caption = "تاريخ التعيين"
        GridView1.Columns(7).Caption = "تاريخ الميلاد"
        GridView1.Columns(8).Caption = "تليفون1"
        GridView1.Columns(9).Caption = "تليفون 2"
        GridView1.Columns(10).Caption = "رقم الفرع"
        GridView1.Columns(11).Caption = "اسم الفرع"


        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




       
    End Sub
    Sub Find_all_EMP_H()
        On Error Resume Next


        'sql = " SELECT Emp_Code AS Code, Emp_Name AS Name      FROM dbo.Emp_employees where Compny_Code ='" & VarCodeCompny & "'"
        sql = "   SELECT        Emp_Code, Emp_Name, NameDir, NameDeprt, JopName, NameMohel,Emp_DateAlthg,  " & _
       "                     Emp_BirthDay, Emp_Tel1, Emp_Tel2 , Em_BranchCode, BranchName " & _
       " FROM dbo.Vw_Emp_H where Compny_Code ='" & VarCodeCompny & "' "


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
        GridView3.Columns(0).Caption = "الكود"
        GridView3.Columns(1).Caption = "الاسم"
        GridView3.Columns(2).Caption = "الادارة"
        GridView3.Columns(3).Caption = "القسم"
        GridView3.Columns(4).Caption = "المسمى الوظيفى"
        GridView3.Columns(5).Caption = "المؤهل"
        GridView3.Columns(6).Caption = "تاريخ التعيين"
        GridView3.Columns(7).Caption = "تاريخ الميلاد"
        GridView3.Columns(8).Caption = "تليفون1"
        GridView3.Columns(9).Caption = "تليفون 2"
        GridView3.Columns(10).Caption = "رقم الفرع"
        GridView3.Columns(11).Caption = "اسم الفرع"


        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub
    Private Sub txt_NameDiractorat_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_NameDiractorat.ButtonClick
        vartable = "BD_DIRCTORAY"
        VarOpenlookup = 12
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        lastAccounno()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        last_Data()
        clear()
    End Sub





    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes
                sql = "Delete Emp_employees  WHERE Emp_Code = " & txtCode.Text & " and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                Save_Emp_History()

                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                last_Data()
                clear()
                'Find()
                'Fill_Data()

                Find_all_EMP()
                Find_all_EMP_H()

        End Select
    End Sub

  

    

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If Len(Txt_EmpName.Text) = 0 Then MsgBox("من فضلك ادخل أسم الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_EmpSex.Text) = 0 Then MsgBox("من فضلك ادخل نوع الموظف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(com_Relajan.Text) = 0 Then MsgBox("من فضلك ادخل الديانة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Txt_NameSt.Text) = 0 Then MsgBox("من فضلك ادخل  الحالة الاجتماعية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDiractorat.Text) = 0 Then MsgBox("من فضلك ادخل الادارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameDept.Text) = 0 Then MsgBox("من فضلك ادخل القسم ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_Nametypjop.Text) = 0 Then MsgBox("من فضلك ادخل نوع الوظيفة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameTy.Text) = 0 Then MsgBox("من فضلك ادخل نوع التعاقد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(Com_Bulidno.Text) = 0 Then MsgBox("من فضلك رقم المبنى ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        If Len(txt_NameMohel.Text) = 0 Then MsgBox("من فضلك أسم المؤهل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
        'If Len(txt_accountNo.Text) = 0 Then MsgBox("من فضلك ادخل مركز التكلفة للأدارة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub






        '============================================تاريخ الميلاد
        Dim dd As DateTime = txt_date.Value
        Dim vardate1 As String
        vardate1 = dd.ToString("MM-d-yyyy")
        '======================================تاريخ الالتحاق
        Dim dd2 As DateTime = txt_datetamen.Value
        Dim vardate2 As String
        vardate2 = dd2.ToString("MM-d-yyyy")
        '==============================================تاريخ الاستقالة
        Dim dd3 As DateTime = txt_DateAstkala.Value
        Dim vardate3 As String
        vardate3 = dd2.ToString("MM-d-yyyy")
        '================================================================تاريخ التحويل للتعيين
        Dim dd4 As DateTime = txt_Convert_t3yen.Value
        Dim vardate4 As String
        vardate4 = dd4.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd5 As DateTime = Txt_DateThwel.Value
        Dim vardate5 As String
        vardate5 = dd5.ToString("MM-d-yyyy")

        '================================================================تاريخ التحويل للمكافاة
        Dim dd6 As DateTime = txt_datetamen.Value
        Dim vardate6 As String
        vardate6 = dd6.ToString("MM-d-yyyy")

        '==================================================================================Stats
        sql = "SELECT *  FROM BD_SOCIALSTATUS where Name ='" & Txt_NameSt.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodestat = rs3("code").Value
        '===================================================================================== الادارة
        sql = "SELECT *  FROM BD_DIRCTORAY where Name ='" & txt_NameDiractorat.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then vardirctoratcode = rs3("code").Value
        '========================================================القسم
        sql = "SELECT *  FROM BD_DEPARTMENTS where Name ='" & txt_NameDept.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodedeprt = rs3("code").Value
        '================================================================نوع العقد
        sql = "SELECT *  FROM BD_TYPEOFCNTRACT where Name ='" & txt_NameTy.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then varcodecontract = rs3("code").Value
        '======================================================نوع المؤهل
        sql = "SELECT *  FROM BD_QUALIFICATIONS where Name ='" & txt_NameMohel.Text & "'  and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEQUALIFICATIONS = rs3("code").Value
        '=================================نوع الوظيفة
        sql = "SELECT *  FROM BD_JOBNAMES where Name ='" & txt_Nametypjop.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEJOBNAMES = rs3("code").Value
        '========================================أسم المبنى
        sql = "SELECT *  FROM BD_BUILDINGS where Name ='" & Com_Bulidno.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then VARCODEBUILDINGS = rs3("code").Value
        '============================================== الباص
        Dim varcodebus As Integer
        If CheckBus.Checked = True Then
            varcodebus = 1
        Else
            varcodebus = 0
        End If
        '=========================================================تاريخ أستلام العمل
        Dim dd7 As DateTime = DateTimePicker3.Text
        Dim vardate7 As String
        vardate7 = dd7.ToString("MM-d-yyyy")
        '================================================

        If OP1.Checked = True Then varDel = 1
        If OP2.Checked = True Then varDel = 2
        If OP3.Checked = True Then varDel = 3



        Dim sql2 As String
        sql2 = "UPDATE  Emp_employees  SET Emp_Address ='" & txt_address.Text & "',Em_BranchCode ='" & txt_BranchCode.Text & "', basicsalary ='" & txt_BasicSalary.Text & "',TotSalary ='" & txt_TotSalary.Text & "',  Emp_Name='" & Txt_EmpName.Text & "' , Emp_DateAlthg = '" & vardate7 & "',Emp_Code_JopName ='" & VARCODEJOBNAMES & "',Emp_BirthDay ='" & vardate1 & "',Emp_Code_Dirctorat ='" & vardirctoratcode & "',Emp_Code_Department ='" & varcodedeprt & "',Emp_Code_Mohlat ='" & VARCODEQUALIFICATIONS & "',Emp_Tel1 ='" & txt_tel1.Text & "',Emp_Tel2 ='" & txt_tel1.Text & "',Emp_National_ID ='" & txt_National_ID.Text & "',Emp_Sex ='" & Com_EmpSex.Text & "',Emp_Rejent ='" & com_Relajan.Text & "',Emp_Code_State ='" & varcodestat & "',Emp_Code_Contract ='" & varcodecontract & "',Bulid_No ='" & VARCODEBUILDINGS & "',Flgbus='" & varcodebus & "',Flg_emp ='" & varDel & "',Em_AccountNo='" & TXt_NoAccountBank.Text & "',Reson_trmention='" & Txt_reson.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and Emp_Code ='" & txtCode.Text & "'   "
        rs = Cnn.Execute(sql2)
        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        Find_all_EMP()


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
       
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        clear()
        sql = " select * From Vw_Emp where Emp_Code = '" & value2 & "' and Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txtCode.Text = rs("Emp_Code").Value
            Txt_EmpName.Text = rs("Emp_Name").Value
            Com_EmpSex.Text = rs("Emp_Sex").Value
            com_Relajan.Text = rs("Emp_Rejent").Value
            txt_date.Text = rs("Emp_BirthDay").Value
            txt_National_ID.Text = rs("Emp_National_ID").Value
            txt_address.Text = rs("Emp_Address").Value
            txt_NameDept.Text = rs("NameDeprt").Value
            txt_NameDiractorat.Text = rs("NameDir").Value
            txt_NameTy.Text = rs("NameContract").Value
            Txt_NameSt.Text = rs("Namestat").Value
            txt_NameMohel.Text = rs("NameMohel").Value
            txt_Nametypjop.Text = rs("JopName").Value
            Com_Bulidno.Text = rs("NameBulid").Value
            Com_TypeKbd.Text = rs("Type_Kbd").Value
            txt_tel1.Text = rs("Emp_Tel1").Value
            txt_tel2.Text = rs("Emp_Tel2").Value
            txt_notameny.Text = rs("Emp_NoTameny").Value
            txt_BasicSalary.Text = rs("basicsalary").Value
            txt_TotSalary.Text = rs("TotSalary").Value
            DateTimePicker3.Text = rs("Emp_DateAlthg").Value

            txt_BranchCode.Text = rs("Em_BranchCode").Value
            txt_BranchName.Text = rs("BranchName").Value
            TXt_NoAccountBank.Text = rs("Em_AccountNo").Value

            Txt_reson.Text = rs("Reson_trmention").Value

            If rs("Flgbus").Value = 1 Then CheckBus.Checked = True
            If rs("Flgbus").Value = 0 Then CheckBus.Checked = False



            If rs("Flg_emp").Value = 1 Then OP1.Checked = True
            If rs("Flg_emp").Value = 2 Then OP2.Checked = True
            If rs("Flg_emp").Value = 3 Then OP3.Checked = True

       

        End If
        TabPane1.SelectedPageIndex = 0
        SimpleButton7.Enabled = False
        SimpleButton5.Enabled = True
        SimpleButton8.Enabled = True
    End Sub
    Sub find_dateEmp()
        On Error Resume Next
        sql = " select * From Vw_Emp where Emp_Code = '" & varcode_emp & "' and Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txtCode.Text = rs("Emp_Code").Value
            Txt_EmpName.Text = rs("Emp_Name").Value
            Com_EmpSex.Text = rs("Emp_Sex").Value
            com_Relajan.Text = rs("Emp_Rejent").Value
            txt_date.Text = rs("Emp_BirthDay").Value
            txt_National_ID.Text = rs("Emp_National_ID").Value
            txt_address.Text = rs("Emp_Address").Value
            txt_NameDept.Text = rs("NameDeprt").Value
            txt_NameDiractorat.Text = rs("NameDir").Value
            txt_NameTy.Text = rs("NameContract").Value
            Txt_NameSt.Text = rs("Namestat").Value
            txt_NameMohel.Text = rs("NameMohel").Value
            txt_Nametypjop.Text = rs("JopName").Value
            Com_Bulidno.Text = rs("NameBulid").Value
            Com_TypeKbd.Text = rs("Type_Kbd").Value
            txt_tel1.Text = rs("Emp_Tel1").Value
            txt_tel2.Text = rs("Emp_Tel2").Value
            txt_notameny.Text = rs("Emp_NoTameny").Value
            txt_BasicSalary.Text = rs("basicsalary").Value
            txt_TotSalary.Text = rs("TotSalary").Value
            DateTimePicker3.Text = rs("Emp_DateAlthg").Value


        End If
        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowPrintPreview()

    End Sub

    Private Sub txt_NameDiractorat_EditValueChanged(sender As Object, e As EventArgs) Handles txt_NameDiractorat.EditValueChanged

    End Sub

    Private Sub txt_BranchName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_BranchName.ButtonClick
        vartable = "BD_SUBMAIN"
        VarOpenlookup = 49000000
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_BranchName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_BranchName.EditValueChanged

    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick

        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Dim value2 = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        clear()
        sql = " select * From Vw_Emp_H where Emp_Code = '" & value2 & "' and Compny_Code ='" & VarCodeCompny & "'"

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            txtCode.Text = rs("Emp_Code").Value
            Txt_EmpName.Text = rs("Emp_Name").Value
            Com_EmpSex.Text = rs("Emp_Sex").Value
            com_Relajan.Text = rs("Emp_Rejent").Value
            txt_date.Text = rs("Emp_BirthDay").Value
            txt_National_ID.Text = rs("Emp_National_ID").Value
            txt_address.Text = rs("Emp_Address").Value
            txt_NameDept.Text = rs("NameDeprt").Value
            txt_NameDiractorat.Text = rs("NameDir").Value
            txt_NameTy.Text = rs("NameContract").Value
            Txt_NameSt.Text = rs("Namestat").Value
            txt_NameMohel.Text = rs("NameMohel").Value
            txt_Nametypjop.Text = rs("JopName").Value
            Com_Bulidno.Text = rs("NameBulid").Value
            Com_TypeKbd.Text = rs("Type_Kbd").Value
            txt_tel1.Text = rs("Emp_Tel1").Value
            txt_tel2.Text = rs("Emp_Tel2").Value
            txt_notameny.Text = rs("Emp_NoTameny").Value
            txt_BasicSalary.Text = rs("basicsalary").Value
            txt_TotSalary.Text = rs("TotSalary").Value
            DateTimePicker3.Text = rs("Emp_DateAlthg").Value

            txt_BranchCode.Text = rs("Em_BranchCode").Value
            txt_BranchName.Text = rs("BranchName").Value
            TXt_NoAccountBank.Text = rs("Em_AccountNo").Value

            Txt_reson.Text = rs("Reson_trmention").Value

            If rs("Flgbus").Value = 1 Then CheckBus.Checked = True
            If rs("Flgbus").Value = 0 Then CheckBus.Checked = False



            If rs("Flg_emp").Value = 1 Then OP1.Checked = True
            If rs("Flg_emp").Value = 2 Then OP2.Checked = True
            If rs("Flg_emp").Value = 3 Then OP3.Checked = True



        End If
        TabPane1.SelectedPageIndex = 0
        SimpleButton7.Enabled = False
        SimpleButton5.Enabled = True
        SimpleButton8.Enabled = True
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView3.ShowPrintPreview()
    End Sub

    Private Sub Txt_NameSt_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_NameSt.EditValueChanged

    End Sub
End Class