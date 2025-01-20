Imports System.Data.OleDb

Public Class Frm_PlayandStopeJopOrder
    Dim varJopOrder As String
    Dim Value2 As String
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()



        sql2 = "SELECT        dbo.TB_Header_JOB_Order.JOB_Order, dbo.TB_MachineName.Name AS NameMachin, dbo.TB_Header_JOB_Order.JOBOrder_Date, dbo.TB_Header_JOB_Order.Qyt_Requrid, dbo.BD_Unit.Name AS unit, " & _
         "                        dbo.BD_ITEM.Name AS NameItem, dbo.TB_Header_JOB_Order.Order_NO, dbo.TB_Header_JOB_Order.Delivery_date, dbo.TB_TypeOrderRun.Name, dbo.Tb_Phases.Name AS Phases, " & _
         "                        BD_ITEM_1.Name AS NameFirstItem, dbo.TB_Header_JOB_Order.Qyt_FristItem, BD_Unit_1.Name AS NameUnitFirst " & _
        " FROM            dbo.TB_Header_JOB_Order INNER JOIN " & _
        "                         dbo.TB_MachineName ON dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_MachineName.Code INNER JOIN " & _
        "                         dbo.BD_ITEM ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_ITEM.Compny_Code AND dbo.TB_Header_JOB_Order.No_Item = dbo.BD_ITEM.Code INNER JOIN " & _
        "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code AND dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code LEFT OUTER JOIN " & _
        "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Header_JOB_Order.Item_No = BD_ITEM_1.Code LEFT OUTER JOIN " & _
        "                         dbo.Tb_Phases ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.Tb_Phases.Compny_Code AND dbo.TB_Header_JOB_Order.Phas_No = dbo.Tb_Phases.Code LEFT OUTER JOIN " & _
        "                         dbo.TB_TypeOrderRun ON dbo.TB_Header_JOB_Order.Flg_Run_JopOrder = dbo.TB_TypeOrderRun.Code " & _
        " WHERE        (dbo.TB_Header_JOB_Order.Flg_JopOrder = 1) AND (dbo.TB_Header_JOB_Order.Compny_Code = '" & VarCodeCompny & "') "



        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "100"
        GridView5.Columns(3).Width = "100"
        GridView5.Columns(4).Width = "200"
        GridView5.Columns(5).Width = "100"
        GridView5.Columns(6).Width = "100"
        GridView5.Columns(7).Width = "100"
        GridView5.Columns(8).Width = "100"
        GridView5.Columns(9).Width = "100"
        GridView5.Columns(10).Width = "100"
        GridView5.Columns(11).Width = "100"
        GridView5.Columns(12).Width = "100"


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم امر الانتاج "
        GridView5.Columns(1).Caption = "رقم الماكينة "
        GridView5.Columns(2).Caption = "تاريخ امر الانتاج"
        GridView5.Columns(3).Caption = "الكمية المطلوبة"
        GridView5.Columns(4).Caption = "الوحدة"
        GridView5.Columns(5).Caption = "المنتج المطلوب"
        GridView5.Columns(6).Caption = "رقم الطلبية"
        GridView5.Columns(7).Caption = "تاريخ التسليم"
        GridView5.Columns(8).Caption = "حالة امر الانتاج"
        GridView5.Columns(9).Caption = "مرحلة الانتاج"
        GridView5.Columns(10).Caption = "المنتج الاولى"
        GridView5.Columns(11).Caption = "الكمية"
        GridView5.Columns(12).Caption = "الوحدة"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

    Private Sub Frm_PlayandStopeJopOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_detalis()
        Timer1.Interval = 1000
        Timer1.Start() 'Timer starts functioning
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click
    
    End Sub
    Sub find_Total_TimeOrder()
        On Error Resume Next
        txt_time.Text = "0"
        sql = "select * from Vw_TotalTimeOrder where JOB_Order = '" & Com_NoOrderJob.Text & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_time.Text = rs("rem").Value Else txt_time.Text = "0"
    End Sub
    Sub find_Matril()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "select JOB_Order,Ex_Item,Name,TypeMatril,Batch_No,Quntity_Matril,Unit,Order_Stores_NO from Vw_FindMatrilOnJopOrder where Compny_Code ='" & VarCodeCompny & "' and JOB_Order ='" & varJopOrder & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "200"
        GridView1.Columns(2).Width = "200"
        GridView1.Columns(3).Width = "100"
        GridView1.Columns(4).Width = "100"
        GridView1.Columns(5).Width = "100"
        GridView1.Columns(6).Width = "100"
        GridView1.Columns(7).Width = "100"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم امر الانتاج "
        GridView1.Columns(1).Caption = "رقم المادة الخام "
        GridView1.Columns(2).Caption = "أسم المادة الخام"
        GridView1.Columns(3).Caption = "نوع الخام"
        GridView1.Columns(4).Caption = "رقم الباتش"
        GridView1.Columns(5).Caption = "الكمية"
        GridView1.Columns(6).Caption = "الوحدة"
        GridView1.Columns(7).Caption = "رقم اذن الصرف"

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        varJopOrder = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Com_NoOrderJob.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))

        Dim Value2 = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(8))

        If Value2 = "تم الانتهاء" Then Cmd_Delete.Enabled = False : Cmd_save.Enabled = False Else Cmd_Delete.Enabled = True : Cmd_save.Enabled = True
        find_Matril()
        find_Total_TimeOrder()
    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        Dim varStartTime As String
        Dim dd As DateTime = Now '=====================================وقت البدء
        varStartTime = dd.ToString("MM/dd/yyyy h:mm:ss")


        '=================تعديل حالة امر الانتاج
        sql2 = "UPDATE  TB_Header_JOB_Order  SET Flg_Run_JopOrder = '" & 1 & "' WHERE Compny_Code = " & VarCodeCompny & " and JOB_Order ='" & Com_NoOrderJob.Text & "'    "
        rs = Cnn.Execute(sql2)
        '==============================================اضافة وقت البدء الجديد

        sql = "INSERT INTO   TB_OrderJopTime  (JOB_Order, Start_Order) " & _
            " values  ('" & Com_NoOrderJob.Text & "' ,'" & varStartTime & "')"
        Cnn.Execute(sql)


        MsgBox("تم تشغيل أمر الانتاج", MsgBoxStyle.Information, "Css Solution Software Module")
        '================================================
        find_detalis()
        'Dim datTim1 As Date = "2019-07-06 06:09:17"
        'Dim datTim2 As Date = "2019-07-06 13:10:50"

        'Dim wD As Long = DateDiff(DateInterval.Minute, datTim1, datTim2)
       
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dd As DateTime = Now '=====================================الوقت الحالى
        txt_CurentTime.Text = dd.ToString("MM/dd/yyyy h:mm:ss")

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim varStartTime As String
        Dim dd As DateTime = Now '=====================================وقت الايقاف
        varStartTime = dd.ToString("MM/dd/yyyy h:mm:ss")


        '=================تعديل حالة امر الانتاج
        sql2 = "UPDATE  TB_Header_JOB_Order  SET Flg_Run_JopOrder = '" & 2 & "' WHERE Compny_Code = " & VarCodeCompny & " and JOB_Order ='" & Com_NoOrderJob.Text & "'    "
        rs = Cnn.Execute(sql2)
        '==============================================اضافة وقت الايقاف الجديد


        sql2 = "UPDATE  TB_OrderJopTime  SET Stop_Order = '" & varStartTime & "'  WHERE  JOB_Order ='" & Com_NoOrderJob.Text & "' and (Stop_Order IS NULL)    "
        rs = Cnn.Execute(sql2)

        'sql = "INSERT INTO   TB_OrderJopTime  (JOB_Order, Start_Order) " & _
        '    " values  ('" & Com_NoOrderJob.Text & "' ,'" & varStartTime & "')"
        'Cnn.Execute(sql)


        MsgBox("تم ايقاف امر الانتاج ", MsgBoxStyle.Information, "Css Solution Software Module")
        find_detalis()
    End Sub

    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click
        '=================تعديل حالة امر الانتاج
        sql2 = "UPDATE  TB_Header_JOB_Order  SET Flg_Run_JopOrder = '" & 3 & "' WHERE Compny_Code = " & VarCodeCompny & " and JOB_Order ='" & Com_NoOrderJob.Text & "'    "
        rs = Cnn.Execute(sql2)
        MsgBox("تم الانتهاء امر الانتاج ", MsgBoxStyle.Information, "Css Solution Software Module") : Cmd_save.Enabled = False : Cmd_Delete.Enabled = False
        find_detalis()
    End Sub

    Private Sub Cmd_OpenJobOrder_Click(sender As Object, e As EventArgs) Handles Cmd_OpenJobOrder.Click

    End Sub
End Class