Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_TransactionHistory
    Dim varFromDate, VarToDate As String
    Sub find_UsersAll()
        Dim dd3 As DateTime = txt_From_Date.Value
        varFromDate = dd3.ToString("yyyy-MM-dd")
        txt_From_Date.Value = varFromDate

        Dim dd4 As DateTime = Txt_To_Date.Value
        VarToDate = dd4.ToString("yyyy-MM-dd")
        Txt_To_Date.Value = VarToDate

        sql = "SELECT        dbo.UserTransactionHistory.ID, dbo.Users_Department.User_Name, dbo.UserTransactionHistory.Date, dbo.UserTransactionHistory.Time, dbo.TB_TypeBill.Type_Bill, dbo.BtnsNames.BtnName,dbo.St_CompnyInfo.Compny_Name, dbo.UserTransactionHistory.PcUserName, dbo.UserTransactionHistory.BillCode " & _
              " FROM            dbo.UserTransactionHistory INNER JOIN " & _
              " dbo.BtnsNames ON dbo.UserTransactionHistory.BtnCode = dbo.BtnsNames.ID INNER JOIN " & _
              " dbo.TB_TypeBill ON dbo.UserTransactionHistory.TypeBillCode = dbo.TB_TypeBill.Code INNER JOIN " & _
              " dbo.St_CompnyInfo ON dbo.UserTransactionHistory.CompanyCode = dbo.St_CompnyInfo.Compny_Code INNER JOIN " & _
              " dbo.Users_Department ON dbo.UserTransactionHistory.UserID = dbo.Users_Department.Code_Emp " & _
              "WHERE dbo.UserTransactionHistory.Date BETWEEN N'" & varFromDate & "' AND N'" & VarToDate & "' " & _
              "ORDER BY dbo.UserTransactionHistory.ID ASC"
        'sql = "SELECT  * FROM dbo.UserTransactionHistory"
        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()
        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        GridView1.Columns(0).Caption = "الرقم"
        GridView1.Columns(1).Caption = "أسم المستخدم"
        GridView1.Columns(2).Caption = "التاريح"
        GridView1.Columns(3).Caption = "الوقت"
        GridView1.Columns(4).Caption = "نوع المستند"
        GridView1.Columns(5).Caption = "العملية"
        GridView1.Columns(6).Caption = "أسم الشركة"
        GridView1.Columns(7).Caption = "أسم الجهاز"
        GridView1.Columns(8).Caption = "كود المستند"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)

        ' GridView Time AM and PM 
        Dim ri As New RepositoryItemDateEdit()
        ri.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        ri.Mask.EditMask = "hh:mm tt"
        ri.Mask.UseMaskAsDisplayFormat = True
        GridControl1.RepositoryItems.Add(ri)
        GridView1.Columns(3).ColumnEdit = ri

        GridView1.BestFitColumns()
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub Frm_DataCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_From_Date.Text = DateTime.Now.ToString("yyyy-MM-dd")
        Txt_To_Date.Text = DateTime.Now.ToString("yyyy-MM-dd")
    End Sub
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        find_UsersAll()
    End Sub
End Class