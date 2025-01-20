Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types

Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Lookup
    Sub Search()
        On Error Resume Next
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()



        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If VarOpenlookup = 23 Then
            sql2 = "      SELECT        Account_No AS Code, AccountName AS Name        FROM dbo.ST_CHARTOFACCOUNT WHERE        (Level_No2 = 102001) AND (Compny_Code = '" & VarCodeCompny & "') and AccountName like  '%" & txt_FindName.Text & "%'"
        ElseIf VarOpenlookup = 6 Then
            sql2 = "SELECT  code,name FROM  " & vartable & " where Name like  '%" & txt_FindName.Text & "%'    "
        ElseIf VarOpenlookup = 24 Then
            sql2 = "SELECT  code,name,NameCustomer FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and  NameCustomer like '%" & txt_FindName.Text & "%'   "

        ElseIf VarOpenlookup = 24024 Then
            sql2 = "SELECT  code,name,NameCustomer FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and  NameCustomer like '%" & txt_FindName.Text & "%'   "



        ElseIf VarOpenlookup = 240 Then
            sql2 = "SELECT  code,name,Acc FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and  Acc like '%" & txt_FindName.Text & "%'   "


        ElseIf VarOpenlookup = 26 Then
            sql2 = "SELECT  code,name,Order_NO FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'   "

        ElseIf VarOpenlookup = 260 Then
            sql2 = "SELECT  code,name,Type,Namecustomer,Ser_InvoiceNo FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'   "



        ElseIf VarOpenlookup = 27 Then
            sql2 = "SELECT  code,name,NameCustomer,Type FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameCustomer like  '%" & txt_FindName.Text & "%'    "

            'VarOpenlookup = 27912
        ElseIf VarOpenlookup = 27912 Then
            sql2 = "SELECT  code,name,NameCustomer FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameCustomer like  '%" & txt_FindName.Text & "%'    "


        ElseIf VarOpenlookup = 272700 Then
            sql2 = "SELECT  code,name,NameCustomer FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameCustomer like  '%" & txt_FindName.Text & "%'    "

        ElseIf VarOpenlookup = 1616 Then
            sql2 = "SELECT  code,Account_No,name,InvoiceDate,tax_a FROM  " & vartable & "  where     not  EXISTS (select No_PriceList  from TB_Header_OrderItem where vw_PriceListLookup.Code = TB_Header_OrderItem.No_PriceList) and name like '%" & txt_FindName.Text & "%'   "
            'MsgBox(vartable)

        ElseIf VarOpenlookup = 2727 Then
            sql2 = "SELECT  code,name,NameSu,Type FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameSu like  '%" & txt_FindName.Text & "%'    "

        ElseIf VarOpenlookup = 27270 Then
            sql2 = "SELECT  code,name,NameSu FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameSu like  '%" & txt_FindName.Text & "%'    "
        ElseIf VarOpenlookup = 2727002 Then
            sql2 = "SELECT  code,Ser_InvoiceNo,name,NameSu,NameProject FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and NameSu like  '%" & txt_FindName.Text & "%'    "

        ElseIf VarOpenlookup = 62 Then
            sql2 = "SELECT  code,name,Type FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and Type like  '%" & txt_FindName.Text & "%'  order by code  "


        ElseIf VarOpenlookup = 45 Or VarOpenlookup = 52 Then
            sql2 = "SELECT  code,name,AccountName FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and AccountName like  '%" & txt_FindName.Text & "%'    "

        ElseIf VarOpenlookup = 100016 Then
            'sql2 = "SELECT  code,name,AccountName FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and AccountName like  '%" & txt_FindName.Text & "%'    "
            sql2 = "SELECT dbo.BD_Item.Code, dbo.BD_Item.Name " &
            " FROM     dbo.BD_Item INNER JOIN " &
            "                  dbo.BD_GROUPITEMMAIN ON dbo.BD_Item.CodeGroupItemMain = dbo.BD_GROUPITEMMAIN.code AND dbo.BD_Item.Compny_Code = dbo.BD_GROUPITEMMAIN.Compny_Code " &
            " WHERE  (dbo.BD_GROUPITEMMAIN.Name = '" & Frm_ReportCostItem.com_GroupItemName.Text & "') AND (dbo.BD_Item.Compny_Code = '" & VarCodeCompny & "') "

        ElseIf VarOpenlookup = 8080 Then
            sql2 = "SELECT Categorize, Ex_Item,DescripionItem,Brand,Type,Price,discount,totalM,code  FROM     Vw_Item_SCHNEIDER  "


        ElseIf VarOpenlookup = 39 Then
            sql2 = "SELECT  code,name,Ref_JOBOrder FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "'   "

        ElseIf VarOpenlookup = 50256 Or VarOpenlookup = 502566 Or VarOpenlookup = 502567 Then
            sql2 = "SELECT  CustomerName, MainCostCenter,LoctionCostCenter,Account_No,Code_SubCostcenter FROM  " & vartable & " "



        ElseIf VarOpenlookup = 39000000 Then
            sql2 = "SELECT  code,name FROM  " & vartable & "   "

        ElseIf VarOpenlookup = 49000000 Then
            sql2 = "SELECT  code,name FROM  " & vartable & "   "

        ElseIf VarOpenlookup = 19000000 Then
            sql2 = "SELECT  code,name FROM  " & vartable & " where Compny_Code =" & VarCodeCompny & "   "
        ElseIf VarOpenlookup = 25 Then
            sql2 = "SELECT        dbo.Vw_Lookup_OrderItem.Code, dbo.Vw_Lookup_OrderItem.Name, dbo.BD_TypeSarfStores.Name AS Expr1, dbo.TB_Detils_AznItem_Stores.Ser_Order_Stores " &
                    " FROM            dbo.BD_TypeSarfStores LEFT OUTER JOIN " &
                    "                         dbo.Vw_Lookup_OrderItem INNER JOIN " &
                    "                         dbo.TB_Header_OrderItem_Stores ON dbo.Vw_Lookup_OrderItem.Code = dbo.TB_Header_OrderItem_Stores.Order_Stores_NO AND " &
                    "                         dbo.Vw_Lookup_OrderItem.Compny_Code = dbo.TB_Header_OrderItem_Stores.Compny_Code INNER JOIN " &
                    "                         dbo.TB_Detils_OrderItem_Stores LEFT OUTER JOIN " &
                    "                         dbo.TB_Detils_AznItem_Stores ON dbo.TB_Detils_OrderItem_Stores.Order_Stores_NO = dbo.TB_Detils_AznItem_Stores.Order_NO AND dbo.TB_Detils_OrderItem_Stores.No_Item = dbo.TB_Detils_AznItem_Stores.No_Item ON " &
                    "                         dbo.TB_Header_OrderItem_Stores.Ser_Order_Stores = dbo.TB_Detils_OrderItem_Stores.Ser_Order_Stores AND dbo.TB_Header_OrderItem_Stores.Compny_Code = dbo.TB_Detils_OrderItem_Stores.Compny_Code ON " &
                    "            dbo.BD_TypeSarfStores.Code = dbo.TB_Header_OrderItem_Stores.Code_Tpye_Stores " &
                    " WHERE(dbo.Vw_Lookup_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.Vw_Lookup_OrderItem.Name like  '%" & txt_FindName.Text & "%') "


        ElseIf VarOpenlookup = 1114 Or VarOpenlookup = 11114 Or VarOpenlookup = 1115 Then

            sql2 = "    SELECT dbo.Emp_employees.Emp_Code AS code, dbo.Emp_employees.Emp_Name AS Name " &
    " FROM     dbo.Emp_employees INNER JOIN " &
    "                  dbo.BD_JOBNAMES ON dbo.Emp_employees.Emp_Code_JopName = dbo.BD_JOBNAMES.Code INNER JOIN " &
    "                  dbo.BD_DIRCTORAY ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.BD_DIRCTORAY.Code INNER JOIN " &
    "                  dbo.BD_DEPARTMENTS ON dbo.Emp_employees.Emp_Code_Department = dbo.BD_DEPARTMENTS.Code " &
    "  "



        ElseIf VarOpenlookup = 180 Then
            sql2 = "SELECT  code,name
  FROM BD_CITIES"

        ElseIf VarOpenlookup = 193 Then
            sql2 = "SELECT  code,name
  FROM BD_EDARAT_ELMROR"

        ElseIf VarOpenlookup = 194 Then
            sql2 = "SELECT  code,name
  FROM BD_Bank

"
        ElseIf VarOpenlookup = 191 Then
            sql2 = "SELECT  code,name 
  FROM BD_WAHDT_MROR 
"
        ElseIf VarOpenlookup = 190 Then
            sql2 = "SELECT  code,name 
  FROM BD_REGION 
"
        ElseIf VarOpenlookup = 195 Then
            sql2 = "Select car_brand,car_model,shasyeh_no,plate_no
From BD_cars_info 
where wasyka_no = '0'"
        ElseIf VarOpenlookup = 196 Then
            sql2 = "SELECT code,name 
from BD_Insurnce_Company_name"
        ElseIf VarOpenlookup = 197 Then
            sql2 = "SELECT Customer_Code,customer_name 
from St_CustomerData2"
        ElseIf VarOpenlookup = 198 Then
            sql2 = "SELECT Code,name 
from BD_Mother_company_name"

        ElseIf VarOpenlookup = 199 Then
            sql2 = "SELECT Code,name 
from BD_car_brands"
        ElseIf VarOpenlookup = 200 Then
            sql2 = "SELECT  name
from BD_cars_brand_model where car_brand = '" & Frm_Car.txt_car_brand_btn.Text & "' "

        ElseIf VarOpenlookup = 201 Then
            sql2 = "select wasyka_no from BD_insurance_doucument"

        ElseIf VarOpenlookup = 202 Then
            sql2 = "SELECT Code,name 
from BD_T7amol_types"
        ElseIf VarOpenlookup = 203 Then
            sql2 = "SELECT Code,name 
from BD_tghtyat_types"
        ElseIf VarOpenlookup = 204 Then
            sql2 = "SELECT Code,name 
from BD_document_types"
        ElseIf VarOpenlookup = 205 Then
            sql2 = "SELECT Code,name 
from BD_customer_main_company"
        ElseIf VarOpenlookup = 206 Then
            sql2 = "SELECT Code,name 
from BD_customer_sub_company where main_company = '" & Frm_Cust.txt_btn_main_customer_company.Text & "'"


            '        ElseIf VarOpenlookup = 207 Then
            '            sql2 = "SELECT Code,name 
            'from BD_car_design"


        ElseIf VarOpenlookup = 1900 Then
            sql2 = "Select code, Name
From BD_SUB_REGIONS
"
        Else

            sql2 = "SELECT  code,name FROM  " & vartable & "  where Compny_Code = '" & VarCodeCompny & "' and Name like  '%" & txt_FindName.Text & "%'  "

        End If



        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        If VarOpenlookup = 27 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "العميل"
            GridView1.Columns(3).Caption = "النوع"

        ElseIf VarOpenlookup = 27912 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "الحساب"

        ElseIf VarOpenlookup = 24 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "العميل"

        ElseIf VarOpenlookup = 240 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "العميل"

        ElseIf VarOpenlookup = 260 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "نوع الاذن"
            GridView1.Columns(3).Caption = "الحساب"
            GridView1.Columns(4).Caption = "رقم فاتورة"

        ElseIf VarOpenlookup = 24024 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "العميل"

        ElseIf VarOpenlookup = 502566 Then
            GridView1.Columns(0).Caption = "Customer Name"

            GridView1.Columns(1).Caption = "Project Name"
            GridView1.Columns(2).Caption = "Loaction Project"
            GridView1.Columns(3).Visible = False
            GridView1.Columns(4).Visible = False

        ElseIf VarOpenlookup = 502567 Then

            GridView1.Columns(0).Caption = "Customer Name"
            GridView1.Columns(1).Caption = "Project Name"
            GridView1.Columns(2).Caption = "Loaction Project"
            GridView1.Columns(3).Visible = False
            GridView1.Columns(4).Visible = False


        ElseIf VarOpenlookup = 272700 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "العميل"

        ElseIf VarOpenlookup = 2727 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "المورد"
            GridView1.Columns(3).Caption = "النوع"

        ElseIf VarOpenlookup = 27270 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "المورد"

        ElseIf VarOpenlookup = 2727002 Then
            GridView1.Columns(0).Caption = "رقم الاذن"
            GridView1.Columns(1).Caption = "الكود"
            GridView1.Columns(2).Caption = "التاريخ"
            GridView1.Columns(3).Caption = "العميل"
            GridView1.Columns(4).Caption = "المشروع"

        ElseIf VarOpenlookup = 26 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "امر التوريد"
            'GridView1.Columns(3).Caption = "امر التوريد"

        ElseIf VarOpenlookup = 45 Or VarOpenlookup = 52 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "أسم الحساب"


        ElseIf VarOpenlookup = 62 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "نوع"

        ElseIf VarOpenlookup = 1616 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "رقم الحساب"
            GridView1.Columns(2).Caption = "الاسم"
            GridView1.Columns(3).Caption = "التاريخ"
            GridView1.Columns(4).Caption = "حالة الضريبة"

        ElseIf VarOpenlookup = 8080 Then
            GridView1.Columns(0).Caption = "Categorize"
            GridView1.Columns(1).Caption = "REF.NO"
            GridView1.Columns(2).Caption = "Descripion"
            GridView1.Columns(3).Caption = "Brand"
            GridView1.Columns(4).Caption = "Type"
            GridView1.Columns(5).Caption = "Price"
            GridView1.Columns(6).Caption = "discount"
            GridView1.Columns(7).Caption = "Total"
            GridView1.Columns(8).Caption = "CodeItem"
            GridView1.Columns(0).Visible = False





        ElseIf VarOpenlookup = 39 Then
            GridView1.Columns(0).Caption = "امر الشغل"
            GridView1.Columns(1).Caption = "التاريخ"
            GridView1.Columns(2).Caption = "رقم العملية"
            'ElseIf VarOpenlookup = 206 Then
            '    GridView1.Columns(0).Caption = "كود"
            '    GridView1.Columns(1).Caption = "الشركة الفرعية"
            '    GridView1.Columns(2).Caption = "الشركة الرئيسية"
        ElseIf VarOpenlookup = 25 Then
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
            GridView1.Columns(2).Caption = "نوع الصرف"
            GridView1.Columns(3).Caption = "رقم الأذن"
            GridView1.Columns(2).Visible = False
            GridView1.Columns(3).Visible = False
        ElseIf VarOpenlookup = 200 Then
            GridView1.Columns(0).Caption = "نوع السيارة"
            GridView1.Columns(1).Caption = "الماركة"
        ElseIf VarOpenlookup = 201 Then
            GridView1.Columns(0).Caption = "رقم الوثيقة"


        Else
            GridView1.Columns(0).Caption = "الكود"
            GridView1.Columns(1).Caption = "الاسم"
        End If



        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        'GridView1.Columns(0).Width = "100"
        'GridView1.Columns(1).Width = "300"
        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub

    Private Sub Frm_Lookup_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

    Private Sub Frm_Lookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
    End Sub


    Sub Chooes_Find()
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        Dim value5 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        'If value = "" Then Exit Sub
        'If value2 = "" Then Exit Sub
        'If value3 = "" Then Exit Sub
        'If value4 = "" Then Exit Sub
        If VarOpenlookup = 50800 Then

            'Frm_Cust.txt_MainCodePrj.Text = value
            'Frm_Cust.txt_MainNamePrj.Text = value2

        End If

        If VarOpenlookup = 502566 Then

            Frm_PanelsTechnicalspecifications.txt_CustName.Text = value
            Frm_PanelsTechnicalspecifications.txt_ProjectName.Text = value2
            Frm_PanelsTechnicalspecifications.cb_SubNamePrj.Text = value3
            VarName_Customer = value
            varcode_project = value4
            varcodeaccountSubProject = value5


        End If

        If VarOpenlookup = 502567 Then

            ''Frm_PanelsTechnicalspecifications.txt_MainCodePrj.Text = value
            'Frm_Panels_Price.txt_ProjectName.Text = value2


            Frm_Panels_Price.txt_CustName.Text = value
            Frm_Panels_Price.txt_ProjectName.Text = value2
            Frm_Panels_Price.cb_SubNamePrj.Text = value3
            varcode_project = value4
            varcodeaccountSubProject = value5
        End If
        
        If VarOpenlookup = 100015 Then

            Frm_ReportCostItem.com_GroupItemName.Text = value2
        End If


        If VarOpenlookup = 100016 Then

            Frm_ReportCostItem.com_ItemName.Text = value2
        End If
        '===================================GroupM

        If VarOpenlookup = 1 Then
            Frm_ItemDataConfacrtion.txt_CodeG.Text = value
            Frm_ItemDataConfacrtion.txt_NameMain.Text = value2
        End If

        If VarOpenlookup = 11 Then
            frm_DiscountSalary.txt_JopName.Text = value2

        End If

        If VarOpenlookup = 2020102 Then
            Frm_Report_Invintory2021.Com_GM1.Text = value2

        End If


        If VarOpenlookup = 10101 Then

            Frm_ReportCustomer2.Com_GM.Text = value2
        End If
        '===================================Group1
        If VarOpenlookup = 2 Then
            Frm_ItemDataConfacrtion.txt_CodeG1.Text = value
            Frm_ItemDataConfacrtion.txt_NameG1.Text = value2
        End If
        '=================================================Group2

        If VarOpenlookup = 20201 Then
            'Frm_dataitem2.txt_CodeG1.Text = value
            Frm_ReportCustomer2.Com_GM1.Text = value2
        End If


        If VarOpenlookup = 1010102 Then
            Frm_ReportCustomer2.Com_GM1.Text = value2
        End If

        If VarOpenlookup = 10101022 Then
            Frm_Report_Invintory2021.Com_GM1.Text = value2
        End If

        If VarOpenlookup = 3024 Then
            Frm_ReciptCash2.txt_Code_Costcenter.Text = value
            Frm_ReciptCash2.txt_Name_Costcenter.Text = value2
        End If



        If VarOpenlookup = 3023 Then
            Frm_Expenses2.txt_Code_Costcenter.Text = value
            Frm_Expenses2.txt_Name_Costcenter.Text = value2
        End If

        If VarOpenlookup = 101010 Then
            Frm_Report_Invintory2021.Com_GM.Text = value2
        End If

        If VarOpenlookup = 202010 Then
            'Frm_dataitem2.txt_CodeG1.Text = value
            Frm_ReportStores.Com_GM1.Text = value2
        End If

        If VarOpenlookup = 202012 Then
            'Frm_dataitem2.txt_CodeG1.Text = value
            Frm_ReportStores.Com_GM2.Text = value2
        End If


        If VarOpenlookup = 3 Then
            Frm_ItemDataConfacrtion.txt_CodeG2.Text = value
            Frm_ItemDataConfacrtion.txt_NameG2.Text = value2
        End If

        If VarOpenlookup = 4 Then
            Frm_CompnyInfo2.txt_CityName.Text = value2
        End If
        If VarOpenlookup = 5 Then
            Frm_CompnyInfo2.txt_Reigon.Text = value2
        End If

        If VarOpenlookup = 6 Then
            FrmLogin.txt_CodeCompny.Text = value
            FrmLogin.txt_NameCompny.Text = value2
        End If

        If VarOpenlookup = 7 Then
            Frm_SetupGenral.txt_AccountNo.Text = value
            Frm_SetupGenral.txt_AccountName.Text = value2
        End If

        If VarOpenlookup = 200003 Then
            Frm_SetupGenral.txt_CashCode.Text = value
            Frm_SetupGenral.txt_CashName.Text = value2
        End If


        If VarOpenlookup = 8080 Then
            Frm_PanelsTechnicalspecifications.txt_RefNo.Text = value
            Frm_PanelsTechnicalspecifications.txt_Description.Text = value3
            Frm_PanelsTechnicalspecifications.txt_price.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
            Frm_PanelsTechnicalspecifications.txt_Discount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
            Frm_PanelsTechnicalspecifications.txt_total.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
            varcode_item = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(8))

        End If
        

        If VarOpenlookup = 200004 Then
            Frm_SetupGenral.TextBox1.Text = value
            Frm_SetupGenral.ButtonEdit1.Text = value2
        End If

        If VarOpenlookup = 200005 Then
            Frm_SetupGenral.TextBox4.Text = value
            Frm_SetupGenral.ButtonEdit4.Text = value2
        End If

        If VarOpenlookup = 200020 Then
            Frm_SetupGenral.txt_accCode.Text = value
            Frm_SetupGenral.txt_accName.Text = value2
        End If

        If VarOpenlookup = 200021 Then
            Frm_SetupGenral.txt_disAccCode.Text = value
            Frm_SetupGenral.txt_discAccName.Text = value2
        End If

        If VarOpenlookup = 8 Then

            Frm_Cust.txt_Alkar.Text = value2
        End If

        If VarOpenlookup = 9 Then

            'Frm_Cust.Cmd_AccountNoGroup.Text = value2
        End If

        If VarOpenlookup = 10 Then
            Frm_SetupGenral.txt_AccountNoCostCenter.Text = value
            Frm_SetupGenral.txt_AccountNameCostCenter.Text = value2
        End If

        If VarOpenlookup = 11 Then
            Frm_SetupGenral.txt_CodeDeprt.Text = value
            Frm_SetupGenral.txt_NameDeprt.Text = value2
        End If


        If VarOpenlookup = 12 Then
            Frm_CurrentEmployee.txt_NameDiractorat.Text = value2

        End If

        If VarOpenlookup = 12021 Then
            Frm_ShData.Com_SuppliserName.Text = value2
            Frm_ShData.TXt_CurName.Text = value

        End If

        If VarOpenlookup = 66062 Then
            Frm_ReportStores.txt_NameStore.Text = value2

        End If



        If VarOpenlookup = 12022 Then
            Frm_ShData.Com_NameShipping.Text = Trim(value2)

        End If

        If VarOpenlookup = 12024 Then
            Frm_ReportCost.Com_Shipping.Text = Trim(value2)

        End If

        If VarOpenlookup = 12025 Then
            Frm_ReportCost.Com_CityName.Text = Trim(value2)

        End If

        If VarOpenlookup = 39000000 Then
            Frm_SetupGenral.txt_BranchCode.Text = Trim(value)
            Frm_SetupGenral.txt_BranchName.Text = Trim(value2)
        End If

        If VarOpenlookup = 49000000 Then
            Frm_CurrentEmployee.txt_BranchCode.Text = Trim(value)
            Frm_CurrentEmployee.txt_BranchName.Text = Trim(value2)
        End If

        If VarOpenlookup = 19000000 Then

            Frm_SetupGenral.ButtonEdit2.Text = Trim(value2)
            Frm_SetupGenral.storeCode = Trim(value)
        End If

        If VarOpenlookup = 1616 Then
            Frm_OrderData.txt_NoPrice.Text = Trim(value)
            Frm_OrderData.txt_AccountNo.Text = Trim(value2)
            Frm_OrderData.txt_nameaccount.Text = Trim(value3)
            Frm_OrderData.find_taxFlg()
            Frm_OrderData.SimpleButton5.Enabled = False
            Frm_OrderData.SimpleButton8.Enabled = False
            Frm_OrderData.SimpleButton7.Enabled = False
            Frm_OrderData.SimpleButton9.Enabled = False

            Frm_OrderData.RadioButton2.Enabled = False
            Frm_OrderData.RadioButton6.Enabled = False
            Frm_OrderData.RadioButton7.Enabled = False

        End If


        If VarOpenlookup = 12030 Then
            Frm_ReportExpSh.Com_Shipping.Text = Trim(value2)

        End If

        If VarOpenlookup = 12035 Then
            Frm_ReportExpSh.Com_Shipping.Text = Trim(value2)

        End If

        If VarOpenlookup = 12031 Then
            Frm_ReportDaily.Com_Shipping.Text = Trim(value2)

        End If


        If VarOpenlookup = 12023 Then
            Frm_ShData.Com_CountryOfOrigin.Text = Trim(value2)

        End If

        If VarOpenlookup = 13 Then
            Frm_CurrentEmployee.txt_NameDept.Text = value2

        End If

        If VarOpenlookup = 14 Then
            Frm_CurrentEmployee.txt_Nametypjop.Text = value2

        End If


        If VarOpenlookup = 1114 Then
            frm_DiscountSalary.txt_EmpNo.Text = value
            frm_DiscountSalary.Txt_EmpName.Text = value2

        End If

        If VarOpenlookup = 1115 Then
            Frm_VactionDtat.txt_EmpNo.Text = value
            Frm_VactionDtat.Txt_EmpName.Text = value2

        End If


        If VarOpenlookup = 11114 Then
            frm_SalfaHR.txt_EmpNo.Text = value
            frm_SalfaHR.Txt_EmpName.Text = value2

        End If

        If VarOpenlookup = 15 Then
            Frm_CurrentEmployee.txt_NameTy.Text = value2

        End If

        If VarOpenlookup = 16 Then
            Frm_CurrentEmployee.txt_NameMohel.Text = value2

        End If

        If VarOpenlookup = 17 Then
            Frm_CurrentEmployee.Com_Bulidno.Text = value2

        End If

        If VarOpenlookup = 18 Then
            Frm_CurrentEmployee.Txt_NameSt.Text = value2

        End If


        If VarOpenlookup = 180 Then
            Frm_Cust.txt_City.Text = value2

        End If


        If VarOpenlookup = 190 Then
            Frm_Cust.Txt_RegionM.Text = value2


        End If
        If VarOpenlookup = 191 Then
            Frm_Car.btn_edit_wehdet_mror.Text = value2
            Frm_Cust.txt_wehdet_mror1.Text = value2

        End If


        If VarOpenlookup = 192 Then
            Frm_Cust.cmd_JopName.Text = value2

        End If
        If VarOpenlookup = 193 Then
            Frm_Car.btn_edart_mror_txt.Text = value2

        End If
        If VarOpenlookup = 194 Then
            Frm_Cust.Cmd_BankName.Text = value2

        End If

        If VarOpenlookup = 195 Then
            Frm_Doucument.btn_shaseh_txt.Text = value3

        End If
        If VarOpenlookup = 196 Then
            Frm_Doucument.btn_insurance_company_name_txt.Text = value2

        End If
        If VarOpenlookup = 197 Then
            Frm_Doucument.btn_customer_name_txt.Text = value2
            Frm_Car.btn_customer_name_txt.Text = value2

        End If
        If VarOpenlookup = 198 Then
            Frm_Doucument.btn_insurance_Mother_company_name_txt.Text = value2

        End If

        If VarOpenlookup = 199 Then
            Frm_Car.txt_car_brand_btn.Text = value2

        End If
        If VarOpenlookup = 200 Then
            Frm_Car.txt_car_model.Text = value

        End If
        If VarOpenlookup = 201 Then
            Frm_Car.txt_wasyka_no.Text = value

        End If
        If VarOpenlookup = 202 Then
            Frm_Doucument.txt_ta7mol_types.Text = Frm_Doucument.txt_ta7mol_types.Text + value2 + " , "

        End If
        If VarOpenlookup = 203 Then
            Frm_Doucument.txt_taghtyat_types.Text = Frm_Doucument.txt_taghtyat_types.Text + value2 + " , "

        End If
        If VarOpenlookup = 204 Then
            Frm_Doucument.btn_wasyka_type_txt.Text = value2

        End If
        If VarOpenlookup = 205 Then
            Frm_Cust.txt_btn_main_customer_company.Text = value2

        End If
        If VarOpenlookup = 206 Then
            Frm_Cust.txt_btn_sub_customer_company.Text = value2

        End If

        If VarOpenlookup = 207 Then
            Frm_Car.txt_car_design.Text = value2

        End If

        If VarOpenlookup = 208 Then
            Frm_Cust.txt_curr.Text = value2

        End If

        If VarOpenlookup = 209 Then
            'Frm_Doucument.txt_wallet.Text = value2
            Frm_Doucument.txt_wasyt_names.Text = Frm_Doucument.txt_wasyt_names.Text + value2 + " , "

        End If
        If VarOpenlookup = 1900 Then
            Frm_Cust.Txt_RegionF.Text = value2
            ' Frm_Cust.Txt_RegionF.Text = value2

        End If

        If VarOpenlookup = 1920 Then
            Frm_Cust.txt_state.Text = value2

        End If

        If VarOpenlookup = 19 Or VarOpenlookup = 20 Or VarOpenlookup = 21 Then
            Frm_FristItem.txt_CodeItem.Text = value
            Frm_FristItem.txt_NameItem.Text = value2
        End If


        If VarOpenlookup = 22 Then
            Frm_SetupGenral.txt_AccountNoMain.Text = value
            Frm_SetupGenral.txt_AccountNameMain.Text = value2
        End If


        'If VarOpenlookup = 23 Then
        '    Frm_OrderSal.txt_AccountNo.Text = value
        '    Frm_OrderSal.txt_nameaccount.Text = value2
        'End If



        If VarOpenlookup = 24 Then
            Frm_OrderData.Com_InvoiceNo2.Text = value

        End If


        If VarOpenlookup = 24024 Then
            Frm_AznSarf2.txt_OrderSal.Text = value
            Frm_AznSarf2.txt_NameCustomer.Text = value3
        End If

        If VarOpenlookup = 240 Then
            Frm_OrderData.txt_NoPrice.Text = value

        End If

        If VarOpenlookup = 25 Then
            Frm_OrderItem.Com_InvoiceNo2.Text = value
            Frm_OrderItem.txt_type.SelectedItem = value3
            Frm_OrderItem.txt_No_Aznsarf.Text = value4
        End If

        If VarOpenlookup = 26 Then
            Frm_AznSarf2.Com_InvoiceNo2.Text = value
            Frm_AznSarf2.txt_date.Value = value2
            Frm_AznSarf2.txt_NameCustomer.Text = value3
            Frm_AznSarf2.txt_OrderSal.Text = value4
            Frm_AznSarf2.Com_TypeAzn.Text = "أمر توريد"
        End If


        If VarOpenlookup = 260 Then
            Frm_AznSarf.Com_InvoiceNo2.Text = value
            Frm_AznSarf.txt_InvoiceNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
            'Frm_AznSarf.txt_NameCustomer.Text = value3
            'Frm_AznSarf.txt_OrderSal.Text = value4
            'Frm_AznSarf.Com_TypeAzn.Text = "أمر توريد"
        End If

        If VarOpenlookup = 27 Then
            Frm_SalseInvoice.Com_InvoiceNo2.Text = value

        End If
        If VarOpenlookup = 27912 Then
            Frm_SalseInvoice.Com_InvoiceNo2.Text = value

        End If

        If VarOpenlookup = 272700 Then
            Frm_InvoiceRented.Com_InvoiceNo2.Text = value

        End If




        If VarOpenlookup = 2727 Then
            Frm_Prcheses_Invoice.Com_InvoiceNo2.Text = value

        End If

        If VarOpenlookup = 2728 Then
            Frm_Prcheses_Invoice_Rented.Com_InvoiceNo2.Text = value
        End If

        If VarOpenlookup = 27270 Then
            Frm_PriceListSuppliser.Com_InvoiceNo2.Text = value

        End If


        If VarOpenlookup = 2727002 Then
            Frm_PriceList_sal.Com_InvoiceNo2.Text = value
            Frm_PriceList_sal.Com_InvoiceNo.Text = value2
        End If

        If VarOpenlookup = 28 Then
            Frm_Gl4.Com_GL_No.Text = value
            Frm_Gl4.txt_GL_Date.Text = value2
        End If


        If VarOpenlookup = 29 Then
            Frm_OrderItem2.Com_InvoiceNo2.Text = value

        End If





        If VarOpenlookup = 31 Then
            Frm_SetupCruuncy.txt_CurrencyName.Text = value2

        End If

        If VarOpenlookup = 32 Then

            Frm_suppliersInfo.Cmd_AccountNoGroup.Text = value2
        End If


        If VarOpenlookup = 33 Then

            Frm_suppliersInfo.txt_Region.Text = value2
        End If


        If VarOpenlookup = 34 Then
            Frm_PrshessesOrder.Com_InvoiceNo2.Text = value

        End If

        If VarOpenlookup = 35 Then
            Frm_Cust.txt_Email_Persone.Text = value2

        End If
        If VarOpenlookup = 36 Then
            'Frm_Cust.txt_catogry_cust.Text = value2

        End If

        If VarOpenlookup = 37 Then
            'Frm_dataitem2.txt_TypeMatril.Text = value2

        End If


        If VarOpenlookup = 38 Then
            Frm_ProudactionOrder.txt_MachinName.Text = value2

        End If

        If VarOpenlookup = 380 Then
            Frm_ProudactionChoose2.txt_MachinName.Text = value2

        End If
        If VarOpenlookup = 380 Then
            Frm_LookupOrderItem3.txt_MachinName.Text = value2

        End If

        If VarOpenlookup = 380 Then
            Frm_Report_Produact.txt_NameMachine.Text = value2

        End If

        If VarOpenlookup = 39 Then
            Frm_ProudactionOrder.Com_InvoiceNo2.Text = value
        End If
        If VarOpenlookup = 40 Then
            Frm_AznEstlamItem.Com_InvoiceNo2.Text = value
        End If


        If VarOpenlookup = 41 Then
            'Frm_OrderData.txt_NoOrder2.Text = value
            Frm_OrderData.txt_Discrption2.Text = value2
        End If

        If VarOpenlookup = 42 Then
            'Frm_OrderData.txt_NoOrder3.Text = value
            Frm_OrderData.txt_Discrption3.Text = value2
        End If


        If VarOpenlookup = 42 Then
            Frm_AsgmintShift.txt_ShiftName.Text = value2
        End If

        If VarOpenlookup = 43 Then
            Frm_AsgmintShift.Com_Dir.Text = value2
        End If

        If VarOpenlookup = 44 Then
            Frm_AsgmintShift.com_asigmentCode.Text = value
            Frm_AsgmintShift.txt_ShiftName.Text = value2
        End If


        If VarOpenlookup = 45 Then
            Frm_ReciptCash2.Com_Exp_No.Text = value
        End If



        If VarOpenlookup = 46 Then
            Frm_SetupBoxandBank.txt_AccountNo.Text = value
            Frm_SetupBoxandBank.txt_AccountName.Text = value2
        End If

        If VarOpenlookup = 47 Then
            Frm_SetupBoxandBank.txt_AccountNo1.Text = value
            Frm_SetupBoxandBank.txt_AccountName1.Text = value2
        End If



        If VarOpenlookup = 48 Then
            Frm_SetupBoxandBank.txt_AccountNo2.Text = value
            Frm_SetupBoxandBank.txt_AccountName2.Text = value2
        End If

        If VarOpenlookup = 49 Then
            Frm_SetupBoxandBank.txt_AccountNo3.Text = value
            Frm_SetupBoxandBank.txt_AccountName3.Text = value2
        End If



        If VarOpenlookup = 50 Then
            Frm_suppliersInfo.varcodecur = value
            Frm_suppliersInfo.txt_cur.Text = value2

        End If

        If VarOpenlookup = 51 Then

            Frm_suppliersInfo.txt_catogry_cust.Text = value2

        End If

        If VarOpenlookup = 502568 Then
            Frm_Azn_AddItem.txt_CodeProject.Text = value
            Frm_Azn_AddItem.txt_NameProject.Text = value2
        End If

        If VarOpenlookup = 52 Then
            Frm_Expenses2.Com_Exp_No.Text = value
            'Frm_Expenses2.find_hedar()
        End If

        If VarOpenlookup = 53 Then
            Frm_Gl4.txt_CostCenter.Text = value
            Frm_Gl4.txt_CostCenterName.Text = value2
        End If


        If VarOpenlookup = 54 Then
            'Frm_Attendec.Com_Dir.Text = value2
        End If


        If VarOpenlookup = 55 Then
            Frm_SetupBoxandBank.txt_AccountNo4.Text = value
            Frm_SetupBoxandBank.txt_AccountName4.Text = value2
        End If

        If VarOpenlookup = 56 Then
            varcode_Condation = value
            Frm_SalseInvoice.txt_Discrption2.Text = value2
        End If


        If VarOpenlookup = 561 Then
            varcode_Condation2 = value
            Frm_PriceList_sal.txt_Discrption2.Text = value2
        End If

        If VarOpenlookup = 57 Then
            Frm_ProudactionOrder.com_FirstItem.Text = value2
        End If

        If VarOpenlookup = 58 Then
            Frm_ProudactionOrder.com_phases.Text = value2
        End If

        If VarOpenlookup = 59 Then
            Frm_ProudactionOrder.com_unitFirstItem.Text = value2
        End If

        If VarOpenlookup = 61 Then
            'Frm_OrderData.txt_NoOrder2.Text = value
            Frm_Azn_AddItem2.Com_StoresNo.Text = value2
        End If


        If VarOpenlookup = 610 Then
            'Frm_OrderData.txt_NoOrder2.Text = value
            Frm_HalkData.Com_StoresNo.Text = value2
        End If

        If VarOpenlookup = 62 Then
            Frm_Azn_AddItem.Com_InvoiceNo2.Text = value
            varaznAddItem = value
        End If

        If VarOpenlookup = 63 Then
            Frm_Azn_AddItem2.txt_MachinName.Text = value2

        End If

        If VarOpenlookup = 633 Then
            Frm_HalkData.txt_MachinName.Text = value2

        End If

        If VarOpenlookup = 64 Then
            Frm_ProudactionOrder.Com_Shift.Text = value2
        End If

        If VarOpenlookup = 65 Then
            Frm_ProdctionWork.Com_Shift.Text = value2
        End If

        If VarOpenlookup = 6400 Then
            Frm_ProudactionOrder2.Com_Shift.Text = value2
        End If

        If VarOpenlookup = 5001 Then
            Frm_ProudactionOrder2.Com_InvoiceNo2.Text = value
        End If


        If VarOpenlookup = 640 Then
            Frm_Report_Produact.txt_NameShift.Text = value2
        End If

        If VarOpenlookup = 640 Then
            Frm_HalkData.com_Shift.Text = value2
        End If
        If VarOpenlookup = 65 Then
            Frm_ProudactionOrder.txt_EmpName.Text = value2
        End If

        If VarOpenlookup = 650 Then
            Frm_Report_Produact.txt_nameEmp1.Text = value2
        End If




        If VarOpenlookup = 650 Then
            Frm_ProudactionOrder.txt_EmpName2.Text = value2
        End If


        If VarOpenlookup = 6501 Then
            Frm_ProudactionOrder2.com_EmpName.Text = value2
        End If


        If VarOpenlookup = 66 Then
            Frm_ProudactionOrder.com_Kilo_unitFirstItem.Text = value2
        End If


        If VarOpenlookup = 660 Then
            Frm_ProudactionOrder.txt_Unit2.Text = value2
        End If


        If VarOpenlookup = 67 Then
            Frm_Vaction.Com_Vaction.Text = value2
        End If

        If VarOpenlookup = 68 Then
            Frm_Gaza.txt_gazaName.Text = value2
        End If

        If VarOpenlookup = 69 Then
            Frm_MentinenceOrder.txt_Type.Text = value2
        End If

        If VarOpenlookup = 70 Then
            Frm_CustomerAndMachine.txt_MachineName.Text = value2
        End If

        If VarOpenlookup = 71 Then
            Frm_CustomerAndMachine.Com_Status.Text = value2
        End If

        If VarOpenlookup = 72 Then
            frm_MachineAndItem.txt_MachineName.Text = value2
        End If

        If VarOpenlookup = 73 Then
            frm_MachineAndItem.txt_Component.Text = value2
        End If

        If VarOpenlookup = 74 Then
            Frm_Contract_M.txt_MachineName.Text = value2
        End If

        If VarOpenlookup = 75 Then
            Frm_Order_M.txt_MachineName.Text = value2
        End If



        If VarOpenlookup = 120 Then
            Frm_OpenE3tmad.txt_NameSuppliser.Text = value2

        End If

        If VarOpenlookup = 12012 Then
            Frm_SettingCostNoneDiract.DataGridView2.Item(0, rowindex).Value = value2


        End If


        If VarOpenlookup = 13013 Then
            Frm_ShData.DataGridView2.Item(0, rowindex).Value = value
            Frm_ShData.DataGridView2.Item(1, rowindex).Value = value2


        End If


        If VarOpenlookup = 13014 Then
            Frm_ShData.DataGridViewX1.Item(0, rowindex2).Value = value
            Frm_ShData.DataGridViewX1.Item(1, rowindex2).Value = value2


        End If

        If VarOpenlookup = 12013 Then
            Frm_SettingCostNoneDiract.DataGridView2.Item(1, rowindex).Value = value2


        End If

        If VarOpenlookup = 555 Then
            Frm_SetupBoxandBank.txt_AccountNo5.Text = value
            Frm_SetupBoxandBank.txt_AccountName5.Text = value2
        End If
        Me.Close()
    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Chooes_Find()

    End Sub


    Private Sub GridControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Chooes_Find()
        End If
    End Sub

    Private Sub txt_FindName_TextChanged(sender As Object, e As EventArgs) Handles txt_FindName.TextChanged
        On Error Resume Next
        Search()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class