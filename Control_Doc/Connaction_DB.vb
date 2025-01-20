Imports System.Data.SqlClient
Imports System.Data.OleDb

Module Connaction_DB
    Public con, varCodeConnaction, varcondation1, varcondation2, varaccountNo, varaccountNo2, varinv_Ext_Invoice, varnamestores As String
    Public DatabaseName, ServerName, varusername, varusername2, varPassword, database2, varnamesals, varNotesCompny, varCommercialCompny, varTaxcardCompny, varAddressCompny As String
    Public vartable, varBrand As String
    Public varcaption As String
    Public VarPAO_NO2 As String
    Public varAccountNo_Invintory, varAccountNo_CostInvintory As String

    Public Var_EmpCode, varcodeitem2, VarPAO_NO, varStores1, varnoform As Integer
    Public varChooseInvoice, varcode_item, varNo_Azn, vartypeinvoice, statusopen, varaznAddItem As Integer
    Public varprice, vardiscount As Double
    Public varTotalItemPOS As Double
    Public varItCode, varItExCode, varItemName, varName, VarPanalName, varNameProject As String
    Public PcUserName As String
    Public vardir, vardeprt As String
    Public VarOpenlookup, varcode_Condation, vardisplayReport, varcode_etmad, rowindex, rowindex2 As Integer
    Public sql, sql2, var_rem, var_txt, varcustomername, varcodecustomer, varpathConn As String
    Public count_lenth, varcode_deprt, varstatment1, varcodebandCostNoneDiract As Integer
    Public varusertype, var_serilNO, var_serilNO_inv, varcodecity, varcodeBand, varcode_Condation2 As Integer
    Public VarCodeCompny, vardisplayReport2, VarSerTwred, varcodeshippingCo, varflagTax, varprintEx As Integer
    Public VarNameCompny As String
    Public varCodeBranch, varNameBranch As String
    Public varcodesub, varcodStores, varcodeitem3, varcodeunit As Integer
    Public varApproved As Integer
    Public Cnn As New ADODB.Connection
    Public Cnn3 As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public rs2 As New ADODB.Recordset
    Public rs3 As New ADODB.Recordset
    Public rs4 As New ADODB.Recordset
    Public Cnn2 As New ADODB.Connection
    Public rsRpt As ADODB.Recordset
    Public DBConnection As New SqlConnection
    Public DBCom As New SqlCommand
    Public NoSerailcolume As Integer
    Public Path2, varnameDiscription As String
    Public VarNameSub, varnameuser, vartablename, varNoInvoice3 As String
    Public varinv_No, varcodeform, varlevel1_statment As Long
    Public var_lineitem, var_codeItem, varcodestores As Integer
    Public varflagstatus, varflagsarf As Integer
    Public var_Month_no, var_Day_no, var_Year_no, var_Month_no2, var_Day_no2, var_Year_no2, var_taskNo, Var_Code_Esal, Var_Code_Esal2, varcode_Branch As Integer
    Public Varbalnce, Varbalnce_De, Varbalnce_Cr, vartalinvoice, vartaxinvoice2 As Single
    Public statusInvoice As Integer
    Public Var_TF_Amount, varlikename, varaccountCustomer As String
    Public print_Invoice As Integer
    Public flag_customer As Integer
    Public Nopricelist As Integer
    Public vartypeItem, VarindexForm, varabroveCustomer, varcodationTaslem, varcodationprice As Integer
    Public VARTBNAME, VARTBNAME2 As String
    Public varcode_form, varcode_form2, VarOpenlookup2, VarOpenlookup3, varesal_Type As Integer
    Public varNoGL As Integer
    Public typeInvoice, vardisplayReport4 As Integer
    Public varcode_Cru, varcode_Catogray, varcode_User, var_recived_Stores As Integer
    Public var_flagsave, var_flagedit, var_flagdel, var_flagserch, var_flagprint
    Public varstatus, Varscrren, varMainForm, varcodeform2 As Integer
    Public varNoInvoice2, varaccountNo_Customer, varcodesuppliser, varpassworduser As String
    Public varNoInvoice, varcodeitem, varcodePhases, varlable, VarTypePriceList As Integer
    Public varJopOrder, varcodeSupliser, var_ref_prodact As String
    Public vartypeItem2, varserial, varcode_emp, varcode_unit, varaproiv, varopenRptprsheses As Integer
    Public var_open_Recipt, var_open_Expensses, var_open_TrilBalance, vardisplayReport3, varopenItemSuppliser, var_warnty As Integer
    Public varcode_project, varcodeaccountSubProject, varitemSn As Integer
    Public SQL4, SQL3 As String
    Public VarName_Customer As String
    Public varEmpReport As Integer



    Sub Connaction_Oracle()
        'varusername2 = "css"
        'varPassword = "css"
        'Cnn = New ADODB.Connection
        'Cnn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Cnn.Open("Provider=OraOLEDB.Oracle;Data Source=prodcss;User Id=" & varusername2 & ";Password=" & varPassword & ";")

    End Sub

    Sub Connaction_Att()
        'On Error Resume Next


        'Dim cnn4 As OleDbConnectionE:\interpak03-05-2019\Control_Doc\Connaction_DB.vb
        'Dim connetionString As String

        'connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\interpak03-05-2019\att\att2000.mdb;"
        'cnn4 = New OleDbConnection(connetionString)
        'cnn4.Open()

        'Conn3.CursorLocation =
        'Conn2.Open "Provider=MSDASQL.1;Persist Security Info=False;Extended Properties=DBQ=" + "\\Heba-azam\ÊÓÌíá ÇáæÞÊ\time.mdb;DefaultDir=" + ";Driver={Driver do Microsoft Access (*.mdb)};DriverId=25;FIL=MS Access;FILEDSN=" + "\\Heba-azam\ÊÓÌíá ÇáæÞÊ\time.dsn;MaxBufferSize=2048;MaxScanRows=8;PageTimeout=5;SafeTransactions=0;Threads=3;UID=;UserCommitSync=Yes;Initial Catalog=" + App.Path + "\\Heba-azam\ÊÓÌíá ÇáæÞÊ\time.mdb;PWD=nira"

        'Cnn3 = New ADODB.Connection
        Cnn3.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\interpak03-05-2019\att\att2000.mdb;")

        'If ServerName = "192.168.1.7" Then Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\att2022\att2000.mdb;")
        'If ServerName = "osama" Then Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\att2022\att2000.mdb;")


        'If ServerName = "osama" Then Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\192.168.1.7\DBBakup\att2000.mdb;")
        'If ServerName = "pc1" Then Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\kaiis10-03-2021\att\att2000.mdb;")
        'ServerName = "pc1"
        'If ServerName = "pc1" Then Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\SourceCode2021\Kaissy\Data\att2000.mdb;")








        'varpathConn = "E:\1-12-2020\FOUCS_ERP\DBConaction\DB_Conn1.mdb"
        'Cnn3.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & varpathConn & ";")
        'sql = "select * from TB_Connaction"
        'rs3 = Cnn3.Execute(sql)
        'If rs3.EOF = False Then
        '    DatabaseName = rs3("Name_DB").Value
        '    ServerName = "192.168.1.116"
        '    varusername2 = rs3("User_Name").Value
        '    varPassword = rs3("Passwored_Name").Value
        'Else

        'End If
        'Cnn3.Close()
    End Sub
    Sub lastgl()
        '================================= رقم قيد جديد
        sql = "  SELECT MAX(IDGenral) + 1 AS MaxGl   FROM  dbo.Genralledger where Compny_Code ='" & VarCodeCompny & "' HAVING(MAX(IDGenral) Is Not Null) "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varNoGL = rs("MaxGl").Value Else varNoGL = 1
    End Sub


    Sub Connaction_Sql()
        '192.168.92.150

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        On Error Resume Next
        Connaction_Att()



        DatabaseName = "DB_ECG"
        'ServerName = "CSS-SERVER2"
        ServerName = "AHMED_MAHMOUD" ' "192.168.1.10" "osama"
        'ServerName = "osama\css"
        varusername2 = "ahmed"
        varPassword = "omar2007"

        'DatabaseName = "DB_KAISSY_New"
        ''ServerName = "css-server\css"
        'ServerName = "server"
        'varusername2 = "css"
        'varPassword = "omar2007"


        'DatabaseName = GetSetting(AppName:="FoucseERP", Section:="Settings", Key:="DatabaseName", Default:=True)
        'ServerName = GetSetting("FoucseERP", "Settings", "ServerName", True)
        'varusername2 = GetSetting("FoucseERP", "Settings", "varusername2", True)
        'varPassword = GetSetting("FoucseERP", "Settings", "varPassword", True)


        Cnn = New Global.ADODB.Connection
        Cnn.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        Dim cnStr As String = "Provider=SQLOLEDB;Initial Catalog=" & DatabaseName & ";Data Source=" & ServerName & ";" &
                     "User ID=" & varPassword & ";Password=" & varPassword & ";"

        Cnn.Open("PROVIDER=MSDASQL;driver={SQL Server};server=" & ServerName & ";uid=" & varusername2 & ";pwd=" & varPassword & ";database=" & DatabaseName & ";")



        'Path2 = "\\192.168.1.7\Report\Report_Sal\"

        'If ServerName = "osama\omar" Then Path2 = "E:\source\24-05-2020\Control_Doc\Report\Report_Sal\"
        'If ServerName = "css-server" Then Path2 = "\\192.168.92.150\css2019\Report\Report_Sal\"

    End Sub




End Module
