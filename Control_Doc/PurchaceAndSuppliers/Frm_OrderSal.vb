
Imports System.Data.OleDb
Imports ADODB
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_OrderSal
    Public varExserail As String
    Dim Varitem, varGM, VarG1, VarG2, varNoBarcode, varNoBarcode2 As String
    Dim varSubStores As Integer
    Dim vartypeinvoice, varmaxcount, varmaxser, varmaxline, varcountbarcode As Integer
    Dim varcodeitem As Integer
    Dim varcodunit As Integer
    Dim varflagazn As Integer
    Dim varcodeExitem As String

    Dim xx As String
    Dim VarItem_EX As String
    Dim x As String
    
    Sub fill_listunit()
        Com_Unit.Items.Clear()  
        sql = "SELECT     Name " & _
        " FROM         BD_Unit where Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            Com_Unit.Items.Add(rs("Name").Value)           
            rs.MoveNext()
        Loop
    End Sub

    
   
    Sub last_Data()
    
        sql = "  SELECT        MAX(Order_Ser) AS MaxMaim,Compny_Code FROM            TB_Header_OrderItem  where Compny_Code = '" & VarCodeCompny & "'   GROUP BY Compny_Code  HAVING        (MAX(Order_Ser) IS NOT NULL) and (Compny_Code = '" & VarCodeCompny & "')  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = rs("MaxMaim").Value + 1
            Com_InvoiceNo2.Text = "RO0000" + Com_InvoiceNo.Text

        Else
            Com_InvoiceNo.Text = 1
            Com_InvoiceNo2.Text = "RO0000" + "1"


        End If
    End Sub



    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        last_Data()
        clear()
        clear_detils()
        'find_hedar()
        find_detalis()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click

        VarOpenlookup2 = 23
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        VarOpenlookup3 = 24
        Frm_LookUpSalse.Find_Salse()
        Frm_LookUpSalse.ShowDialog()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click

        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من ادخل فضلك المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        varcode_form = 25
        VARTBNAME = " Vw_AllDataItem"
        Lookupitem.Fill_Alldata()
        Lookupitem.ShowDialog()
        fin_qyt_avalible()

    End Sub
    Sub fin_qyt_avalible()
        On Error Resume Next
        sql = "     SELECT        *       FROM dbo.vw_Gard WHERE        (Compny_Code = '" & VarCodeCompny & "') AND (NoItem = '" & txt_CodeItem.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Qyt_avalible.Text = Math.Round(rs("Balance").Value, 2)


    End Sub

    Private Sub Frm_OrderSal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        fill_listunit()
        'fill_listStores()
        Com_StatusOrder.Items.Add("جديد")
        Com_StatusOrder.Items.Add("تحت التشغيل")
        Com_StatusOrder.Items.Add("مغلقة")


       
        last_Data()
        fill_cru()
    End Sub

    Sub fill_cru()
        com_Cru.Items.Clear()
        sql = "SELECT        Name FROM            dbo.BD_Currency"
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Cru.Items.Add(rs("Name").Value)
            rs.MoveNext()
        Loop
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        sql2 = "select * from TB_Header_OrderItem where Order_Ser  = '" & Trim(Com_InvoiceNo.Text) & "' and Compny_Code =  '" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql2)

        If rs2.EOF = False Then

        Else
            last_Data()

        End If


        If Len(Com_InvoiceNo.Text) = 0 Then MsgBox("من فضلك ادخل رقم الفاتورة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeSalse.Text) = 0 Then MsgBox("من ادخل فضلك المندوب ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_CodeItem.Text) = 0 Then MsgBox("من فضلك ادخل  الصنف ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(txt_Qty.Text) = 0 Then MsgBox("من  فضلك ادخل الكمية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        If Len(Com_Unit.Text) = 0 Then MsgBox("من فضلك ادخل الوحدة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub



        save_Order_H()

    End Sub

    Sub save_Order_H()
        On Error Resume Next

        Dim dd As DateTime = txt_date.Value
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql = "select * from TB_Header_OrderItem where Order_Ser  = " & Com_InvoiceNo.Text & "  and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then

            '    sql = "UPDATE  BillBrchsesHder  SET NumberBill = '" & vardateinvoice & "',AccountNumberSu ='" & txt_AccountNo.Text & "' WHERE NumberBill = " & Com_InvoiceNo.Text & " "
            '    rs = Cnn.Execute(sql)
        Else


            sql = "INSERT INTO TB_Header_OrderItem (Order_Ser, Compny_Code,Order_NO,Order_Date,Customer_No,Salse_No,Status_Order,Notes,FileCustomer) " & _
                      " values  ('" & Com_InvoiceNo.Text & "' ,'" & VarCodeCompny & "','" & Com_InvoiceNo2.Text & "','" & vardateoder & "','" & txt_AccountNo.Text & "','" & txt_CodeSalse.Text & "','0','" & txt_Notes.Text & "','" & txt_OpenFile.Text & "')"
            Cnn.Execute(sql)



        End If
        'Next
        save_oderDetils()
        clear_detils()
        find_detalis()

    End Sub
    Sub save_oderDetils()
        sql = "   SELECT *    FROM BD_Unit    WHERE(Name = '" & Com_Unit.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Code").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)


        sql = "INSERT INTO TB_Detils_OrderItem (Order_Ser,Order_NO,Ex_Item,No_Item,Quntity,Code_Unit,Notes,Compny_Code) " & _
              " values  ('" & Com_InvoiceNo.Text & "' ,'" & Com_InvoiceNo2.Text & "','" & varcodeExitem & "','" & txt_CodeItem.Text & "','" & txt_Qty.Text & "','" & varcodunit & "','" & txt_Notes.Text & "','" & VarCodeCompny & "')"
        Cnn.Execute(sql)



    End Sub
    Sub find_hedar()
        On Error Resume Next
        Dim varstatus As String
        sql = "   SELECT       dbo.TB_Header_OrderItem.FileCustomer, dbo.TB_Header_OrderItem.Order_Ser, dbo.TB_Header_OrderItem.Order_NO, dbo.St_CustomerData.Customer_Name, dbo.Emp_employees.Emp_Name, dbo.TB_Header_OrderItem.Customer_No, " & _
    "                        dbo.TB_Header_OrderItem.Salse_No, dbo.TB_Header_OrderItem.Order_Date, dbo.TB_Header_OrderItem.Compny_Code, dbo.TB_Header_OrderItem.Notes, dbo.TB_Header_OrderItem.Status_Order,dbo.TB_Header_OrderItem.Abrove_Customer " & _
   " FROM            dbo.TB_Header_OrderItem INNER JOIN " & _
   "                         dbo.St_CustomerData ON dbo.TB_Header_OrderItem.Compny_Code = dbo.St_CustomerData.Compny_Code AND dbo.TB_Header_OrderItem.Customer_No = dbo.St_CustomerData.Customer_AccountNo INNER JOIN " & _
   "                         dbo.Emp_employees ON dbo.TB_Header_OrderItem.Salse_No = dbo.Emp_employees.Emp_Code " & _
   " WHERE        (dbo.TB_Header_OrderItem.Compny_Code = '" & VarCodeCompny & "') AND (dbo.TB_Header_OrderItem.Order_NO = '" & Com_InvoiceNo2.Text & "') "

        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            Com_InvoiceNo.Text = Trim(rs("Order_Ser").Value)
            Com_InvoiceNo2.Text = Trim(rs("Order_NO").Value)
            txt_date.Text = Trim(rs("Order_Date").Value)
            txt_AccountNo.Text = Trim(rs("Customer_No").Value)
            txt_nameaccount.Text = Trim(rs("Customer_Name").Value)
            txt_CodeSalse.Text = Trim(rs("Salse_No").Value)
            txt_NameSalse.Text = Trim(rs("Emp_Name").Value)
            txt_Notes.Text = Trim(rs("Notes").Value)
            varstatus = Trim(rs("Status_Order").Value)
            If varstatus = 0 Then Com_StatusOrder.Text = "جديد"
            If varstatus = 1 Then Com_StatusOrder.Text = "تحت التشغيل"
            If varstatus = 2 Then Com_StatusOrder.Text = "مغلق"


            If rs("Abrove_Customer").Value = 0 Then RadioButton4.Checked = True
            If rs("Abrove_Customer").Value = 1 Then RadioButton5.Checked = True

            txt_OpenFile.Text = Trim(rs("FileCustomer").Value)
        End If



    End Sub
    Sub clear()

        txt_AccountNo.Text = ""
        txt_nameaccount.Text = ""
        txt_CodeSalse.Text = ""
        txt_NameSalse.Text = ""
        txt_Notes.Text = ""
        txt_OpenFile.Text = ""
    End Sub
    Sub clear_detils()
        txt_CodeItem.Text = ""
        txt_NameItem.Text = ""
        txt_Qty.Text = ""
        Com_Unit.Text = ""
        txt_Qyt_avalible.Text = ""
        txt_OpenFile.Text = ""
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "  SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName, " & _
"        dbo.TB_Detils_OrderItem.Price_Unit  " & _
" FROM            dbo.TB_Detils_OrderItem LEFT OUTER JOIN  " & _
"                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.No_Item = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code LEFT OUTER JOIN  " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code  " & _
" WHERE        (dbo.TB_Detils_OrderItem.Order_NO ='" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') "




        sql2 = "  SELECT        dbo.TB_Detils_OrderItem.No_Item, RTRIM(dbo.TB_Detils_OrderItem.Ex_Item) AS Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Detils_OrderItem.Quntity, dbo.BD_Unit.Name AS UnitName,  " & _
"                         dbo.TB_Detils_OrderItem.Price_Unit, dbo.BD_Currency.Name AS Name_Cru, dbo.TB_Detils_OrderItem.Rat_Cur, dbo.TB_Detils_OrderItem.TotalItem  " & _
" FROM            dbo.TB_Detils_OrderItem INNER JOIN " & _
"                         dbo.BD_ITEM ON dbo.TB_Detils_OrderItem.Order_Ser = dbo.BD_ITEM.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_ITEM.Compny_Code INNER JOIN " & _
"                         dbo.BD_Unit ON dbo.TB_Detils_OrderItem.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
"                         dbo.BD_Currency ON dbo.TB_Detils_OrderItem.Compny_Code = dbo.BD_Currency.Compny_Code AND dbo.TB_Detils_OrderItem.Rat_Cur = dbo.BD_Currency.Code " & _
" WHERE        (dbo.TB_Detils_OrderItem.Order_NO = '" & Com_InvoiceNo2.Text & "') AND (dbo.TB_Detils_OrderItem.Compny_Code = '" & VarCodeCompny & "') "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "75"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "200"
        GridView6.Columns(3).Width = "50"
        GridView6.Columns(4).Width = "50"
        GridView6.Columns(5).Width = "100"
        GridView6.Columns(6).Width = "100"
        GridView6.Columns(7).Width = "100"
        GridView6.Columns(8).Width = "100"

        'GridView6.Columns(5).AppearanceCell.BackColor = Color.DarkGray
        'GridView6.Columns(5).AppearanceCell.ForeColor = Color.Red

        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "كود الصنف"
        GridView6.Columns(1).Caption = "الرقم التوصيفى "
        GridView6.Columns(2).Caption = "الصنف"
        GridView6.Columns(3).Caption = "الكمية"
        GridView6.Columns(4).Caption = "الوحدة"
        GridView6.Columns(5).Caption = "السعر الحالى"
        GridView6.Columns(6).Caption = "العملة"
        GridView6.Columns(7).Caption = "معامل التحويل"
        GridView6.Columns(8).Caption = "الاجمالى"






        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        Mainmune.Find_NewSalseorder()


    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click

        vartable = "Vw_Lookup_SalseOrder"
        VarOpenlookup = 24
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        clear_detils()
        find_hedar()
        find_detalis()

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
      


        'Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        'varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        'txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        'txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        'txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        'Com_Unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        ''txt_Notes.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))

        On Error Resume Next

        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        varcodeitem = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CodeItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_NameItem.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_Qty.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        Com_Unit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))
        txt_PriceUnit.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(5))
        com_Cru.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(6))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(7))
        txt_total.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(8))
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        On Error Resume Next
        '========================================Check طلب صرف المخازن
        sql = "select * from TB_Header_OrderItem_Stores where Order_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه طلب صرف من المخازن لايمكن تعديلة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '=============================================================== Check أمر الانتاج
        sql = "select * from TB_Header_JOB_Order where Order_NO = '" & Com_InvoiceNo2.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه أمر انتاج  لايمكن تعديلة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '============================================================

        sql = "   SELECT Unit1, Ex_Item    FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodunit = rs("Unit1").Value


        '============================EXitem
        sql = "   SELECT Unit1, rtrim(Ex_Item) as Ex_Item     FROM BD_ITEM    WHERE(code = '" & txt_CodeItem.Text & "') and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcodeExitem = Trim(rs("Ex_Item").Value)

        '===================================تعديل Hedar
        sql = "UPDATE  TB_Header_OrderItem  SET FileCustomer ='" & txt_OpenFile.Text & "',Customer_No ='" & txt_AccountNo.Text & "',Salse_No ='" & txt_CodeSalse.Text & "'  WHERE  Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        '==============================================================تعديل Detils
        'sql = "UPDATE  TB_Detils_OrderItem  SET No_Item ='" & txt_CodeItem.Text & "',Quntity ='" & txt_Qty.Text & "',Ex_Item ='" & varcodeExitem & "' , Code_Unit ='" & varcodunit & "',Notes ='" & txt_Notes.Text & "'  WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)
        ''======================================================================







        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & com_Cru.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '============================================================

        sql = "UPDATE  TB_Detils_OrderItem  SET No_Item ='" & txt_CodeItem.Text & "' ,Price_Unit ='" & txt_PriceUnit.Text & "',Code_Cur ='" & varcode_Cru & "' , Rat_Cur ='" & txt_rat.Text & "',TotalItem ='" & Math.Round(Val(txt_PriceUnit.Text) * Val(txt_rat.Text) * Val(txt_Qty.Text), 2) & "'    WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)





        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        clear_detils()
        find_hedar()
        find_detalis()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        On Error Resume Next


        '========================================Check طلب صرف المخازن
        sql = "select * from TB_Header_OrderItem_Stores where Order_NO = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه طلب صرف من المخازن لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '=============================================================== Check أمر الانتاج
        sql = "select * from TB_Header_JOB_Order where Order_NO = '" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then MsgBox("من فضلك رقم الطلبية تم اصدار عليه أمر انتاج  لايمكن حذف اى صنف عليه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '============================================================




        Dim x As String
        'Dim varcount As Integer
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select x
            Case vbNo

            Case vbYes
                sql = "Delete TB_Detils_OrderItem  WHERE No_Item = '" & varcodeitem & "' and Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)

                find_detalis()
                clear_detils()
                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
        End Select

    End Sub

    
    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Report_SalseOrder.Show()
    End Sub


   
    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs) Handles Cmd_OpenFile.Click
        Dim OpenFileDialog As New OpenFileDialog

        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "PDF Files (*.pdf) |*.pdf|All Files (*.*)|*.*"

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            txt_OpenFile.Text = OpenFileDialog.FileName
            Process.Start(OpenFileDialog.FileName)

        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Process.Start(txt_OpenFile.Text)
    End Sub

  
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'sql = "    SELECT        Order_NO, Price_Unit       FROM dbo.TB_Detils_OrderItem WHERE        (Order_NO = '" & Com_InvoiceNo2.Text & "') AND (Price_Unit IS NULL) AND (Compny_Code = '" & VarCodeCompny & "')"
        'rs2 = Cnn.Execute(sql)
        'If rs2.EOF = False Then MsgBox("أسعار اصناف الطلبية غير مكتملة من فضلك تأكد", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub



        sql = "UPDATE  TB_Header_OrderItem  SET Abrove_Customer  ='" & 1 & "'   WHERE  Order_Ser ='" & Com_InvoiceNo.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        MsgBox("تم موافقة العميل على الطلبية", MsgBoxStyle.Information, "Css Solution Software Module")

    End Sub

    Private Sub Com_Unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_Unit.SelectedIndexChanged

    End Sub
End Class