Imports System.Data.OleDb

Public Class Status_Nataction

 

    
    Sub Fill_AllInvoice()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        If statusInvoice = 1 Then sql2 = " SELECT Ext_InvoiceNo, InvoiceDate, TotalInv, Customer_No, Name, Emp_Name, TypeItem, Order_Stores_No, Ex_Item, NameItem ,stutasInvoice from  Vw_AllInvoice  where           (code= 0)  "
        If statusInvoice = 2 Then sql2 = " SELECT Ext_InvoiceNo, InvoiceDate, TotalInv, Customer_No, Name, Emp_Name, TypeItem, Order_Stores_No, Ex_Item, NameItem ,stutasInvoice from  Vw_AllInvoice  where       (code = 1)  "
        If statusInvoice = 3 Then sql2 = " SELECT Ext_InvoiceNo, InvoiceDate, TotalInv, Customer_No, Name, Emp_Name, TypeItem, Order_Stores_No, Ex_Item, NameItem,stutasInvoice from  Vw_AllInvoice  where       (code= 2)  "


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "100"
        GridView6.Columns(3).Width = "100"
        GridView6.Columns(4).Width = "200"
        GridView6.Columns(5).Width = "200"
        GridView6.Columns(6).Width = "100"
        GridView6.Columns(7).Width = "100"
        GridView6.Columns(8).Width = "100"
        GridView6.Columns(9).Width = "100"
        GridView6.Columns(10).Width = "100"


        GridView6.Columns(0).Caption = "رقم الفاتورة"
        GridView6.Columns(1).Caption = "تاريخ الفاتورة"
        GridView6.Columns(2).Caption = "قيمة الفاتورة"
        GridView6.Columns(3).Caption = "حساب العميل"
        GridView6.Columns(4).Caption = "أسم العميل"
        GridView6.Columns(5).Caption = "أسم المندوب"
        GridView6.Columns(6).Caption = "نوع الصنف"
        GridView6.Columns(7).Caption = "رقم اذن الصرف"
        GridView6.Columns(8).Caption = "رقم الصنف"
        GridView6.Columns(9).Caption = "أسم الصنف"
        GridView6.Columns(10).Caption = "حالة الفاتورة"




        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub
   
    Private Sub Status_Nataction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_AllInvoice()
    End Sub

    
    Private Sub Cmd_SaveAcc_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To GridView6.RowCount - 1
            Dim Head0 As String = GridView6.Columns(0).GetTextCaption
            Dim Head1 As String = GridView6.Columns(1).GetTextCaption
            Dim Head2 As String = GridView6.Columns(2).GetTextCaption
            Dim Head3 As String = GridView6.Columns(3).GetTextCaption
            Dim Head4 As String = GridView6.Columns(4).GetTextCaption
            Dim Head5 As String = GridView6.Columns(5).GetTextCaption
            Dim Head6 As String = GridView6.Columns(6).GetTextCaption
            Dim Head7 As String = GridView6.Columns(7).GetTextCaption
            Dim Head8 As String = GridView6.Columns(8).GetTextCaption
            Dim Head9 As String = GridView6.Columns(9).GetTextCaption
            Dim Head10 As String = GridView6.Columns(10).GetTextCaption

            Dim value0 As String = GridView6.GetRowCellValue(i, GridView6.Columns(0))
            Dim value1 As String = GridView6.GetRowCellValue(i, GridView6.Columns(1))
            Dim value2 As String = GridView6.GetRowCellValue(i, GridView6.Columns(2))
            Dim value3 As String = GridView6.GetRowCellValue(i, GridView6.Columns(3))
            Dim value4 As String = GridView6.GetRowCellValue(i, GridView6.Columns(4))
            Dim value5 As String = GridView6.GetRowCellValue(i, GridView6.Columns(5))
            Dim value6 As String = GridView6.GetRowCellValue(i, GridView6.Columns(6))
            Dim value7 As String = GridView6.GetRowCellValue(i, GridView6.Columns(7))
            Dim value8 As String = GridView6.GetRowCellValue(i, GridView6.Columns(8))
            Dim value9 As String = GridView6.GetRowCellValue(i, GridView6.Columns(9))
            Dim value10 As String = GridView6.GetRowCellValue(i, GridView6.Columns(10))
        Next
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView6.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

    End Sub
End Class