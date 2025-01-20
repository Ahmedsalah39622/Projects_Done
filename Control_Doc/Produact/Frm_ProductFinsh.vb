Imports System.Data.OleDb
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_ProductFinsh
    Dim ValueNOItem, ValueNOOrder As String


    Private Sub Frm_ProductFinsh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_detalis()
    End Sub
    Sub find_detalis()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "    SELECT        dbo.TB_Header_JOB_Order.JOB_Order, dbo.TB_Header_JOB_Order.JOBOrder_Date, dbo.BD_ITEM.Ex_Item, dbo.BD_ITEM.Name, dbo.TB_Header_JOB_Order.Qyt_Requrid, dbo.BD_Unit.Name AS unit,  " & _
    "                         dbo.TB_Header_JOB_Order.Order_NO, dbo.Vw_TotalTimeOrder.rem, RTRIM(dbo.TB_Phases.Name) AS NamePhases, BD_ITEM_1.Name AS NameItem, dbo.TB_Header_JOB_Order.Qyt_FristItem,  " & _
    "                         BD_Unit_1.Name AS UnitName, dbo.TB_MachineName.Name AS MachineName " & _
    "FROM            dbo.BD_ITEM INNER JOIN " & _
    "                         dbo.TB_Header_JOB_Order ON dbo.BD_ITEM.Compny_Code = dbo.TB_Header_JOB_Order.Compny_Code AND dbo.BD_ITEM.Code = dbo.TB_Header_JOB_Order.No_Item INNER JOIN " & _
    "                         dbo.BD_Unit ON dbo.TB_Header_JOB_Order.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
    "                         dbo.TB_MachineName ON dbo.TB_Header_JOB_Order.Machine_No = dbo.TB_MachineName.Code AND dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_MachineName.Compny_Code LEFT OUTER JOIN " & _
    "                         dbo.Vw_TotalTimeOrder ON dbo.TB_Header_JOB_Order.JOB_Order = dbo.Vw_TotalTimeOrder.JOB_Order LEFT OUTER JOIN " & _
    "                         dbo.BD_Unit AS BD_Unit_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_Unit_1.Compny_Code AND dbo.TB_Header_JOB_Order.Code_Unit_FirstItem = BD_Unit_1.Code LEFT OUTER JOIN " & _
    "                         dbo.BD_ITEM AS BD_ITEM_1 ON dbo.TB_Header_JOB_Order.Compny_Code = BD_ITEM_1.Compny_Code AND dbo.TB_Header_JOB_Order.Item_No = BD_ITEM_1.Code LEFT OUTER JOIN " & _
    "                         dbo.TB_Phases ON dbo.TB_Header_JOB_Order.Compny_Code = dbo.TB_Phases.Compny_Code AND dbo.TB_Header_JOB_Order.Phas_No = dbo.TB_Phases.Code " & _
    " WHERE        (dbo.TB_Header_JOB_Order.Flg_Run_JopOrder = 3) AND (dbo.TB_Header_JOB_Order.Compny_Code = '" & VarCodeCompny & "') "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl4.DataSource = ds.Tables(0)

        GridView5.Columns(0).Width = "100"
        GridView5.Columns(1).Width = "100"
        GridView5.Columns(2).Width = "100"
        GridView5.Columns(3).Width = "200"
        GridView5.Columns(4).Width = "100"
        GridView5.Columns(5).Width = "100"
        GridView5.Columns(6).Width = "100"
        GridView5.Columns(7).Width = "100"
        GridView5.Columns(8).Width = "100"
        GridView5.Columns(9).Width = "150"
        GridView5.Columns(10).Width = "50"
        GridView5.Columns(11).Width = "100"
        GridView5.Columns(12).Width = "100"

        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True

        GridView5.Columns(0).Caption = "رقم امر الانتاج "
        GridView5.Columns(1).Caption = "تاريخ امر الانتاج"
        GridView5.Columns(2).Caption = "رقم الصنف"
        GridView5.Columns(3).Caption = "اسم الصنف"
        GridView5.Columns(4).Caption = "الكمية"
        GridView5.Columns(5).Caption = "الوحدة"
        GridView5.Columns(6).Caption = "رقم الطلبية"
        GridView5.Columns(7).Caption = "الوقت المستغرق "
        GridView5.Columns(8).Caption = "مرحلة الانتاج"
        GridView5.Columns(9).Caption = "المنتج الاولى"
        GridView5.Columns(10).Caption = "الكمية"
        GridView5.Columns(11).Caption = "الوحدة"
        GridView5.Columns(12).Caption = "الماكينة"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()




    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs)
       
    End Sub
    Sub print_Label()
        On Error Resume Next
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim path As String = Application.StartupPath()

        If VarCodeCompny = 3 And varlable = 4 Then cryRpt.Load(Path2 + "LableQR.rpt")
        If VarCodeCompny = 3 And varlable = 1 Then cryRpt.Load(Path2 + "LableA.rpt")
        If VarCodeCompny = 3 And varlable = 2 Then cryRpt.Load(Path2 + "LableA.rpt")
        If VarCodeCompny = 3 And varlable = 3 Then cryRpt.Load(Path2 + "LableA.rpt")
        If VarCodeCompny = 3 And varlable = 5 Then cryRpt.Load(Path2 + "LableQR2.rpt")
        'cryRpt.Load("F:\source\ERP_System2\WindowsApplication1\Report\First_Stores.rpt")
        'cryRpt.Load("F:\bakup_code\Northcost\WindowsApplication1\WindowsApplication1\Rental_Invoice.rpt")

        With crConnectionInfo
            .ServerName = ServerName
            .DatabaseName = DatabaseName
            .UserID = varusername2
            .Password = varPassword

        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        cryRpt.DataDefinition.FormulaFields("TitalCompny").Text = " '" & txt_TitalCompny.Text & "' "


        If varlable = 4 Then
            cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_LabelPrint.SerialNo} = '" & txt_SerialNo.Text & "' and  {Rpt_LabelPrint.Compny_Code} = " & VarCodeCompny & "  "

        Else
            If OP6.Checked = True Then cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_LabelPrint.JOB_Order} = '" & Com_NoOrderJob.Text & "' and  {Rpt_LabelPrint.Compny_Code} = " & VarCodeCompny & "  "
            If OP7.Checked = True Then cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_LabelPrint.SerialNo} = '" & txt_SerialNo.Text & "' and  {Rpt_LabelPrint.Compny_Code} = " & VarCodeCompny & "  "
            If OP5.Checked = True Then cryRpt.DataDefinition.RecordSelectionFormula = " {Rpt_LabelPrint.SerialNo} = '" & txt_SerialNo.Text & "' and  {Rpt_LabelPrint.Compny_Code} = " & VarCodeCompny & "  "

        End If

        '
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub

    

   

    Private Sub Cmd_save_Click_1(sender As Object, e As EventArgs)
       

    End Sub
    Sub save_detils()
        If Len(Com_NoOrderJob.Text) = 0 Then MsgBox("من فضلك ادخل رقم امر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        '==============================================Hedar
        sql = "Delete TB_QualityAprove  WHERE JOB_Order = '" & Com_NoOrderJob.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)

        txt_ROLL_NO.Text = Com_NoOrderJob.Text & "-" & Trim(ValueNOItem) & "-" & Trim(ValueNOOrder)
        sql = "INSERT INTO TB_QualityAprove (JOB_Order, Compny_Code,ROLL_NO) " & _
          " values  ('" & Com_NoOrderJob.Text & "' ,'" & VarCodeCompny & "','" & txt_ROLL_NO.Text & "')"
        Cnn.Execute(sql)

        '=================================================================detils

        sql = "Delete TB_Detils_QualityAprove  WHERE JOB_Order = '" & Com_NoOrderJob.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        rs = Cnn.Execute(sql)
        Dim value As Integer
        Dim result As Integer = 0
        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        value = Trim(GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(10)))

        For rowHandle As Integer = 0 To value - 1
            last_SerialJopOrder()
            Dim varserilanjoporder As String
            varserilanjoporder = Com_NoOrderJob.Text & "-" & varserial
            sql = "INSERT INTO TB_Detils_QualityAprove (JOB_Order, Compny_Code,Ser,NameItem,Machine,SerialNo) " & _
              " values  ('" & Com_NoOrderJob.Text & "' ,'" & VarCodeCompny & "','" & varserial & "','" & txt_NameItem.Text & "','" & Txt_Machine.Text & "','" & varserilanjoporder & "' )"
            Cnn.Execute(sql)

        Next rowHandle
        MsgBox("تم ادخال عدد السريال", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Account Solution Software Module")
        fill_Detials_JopOrder()
        '=============================================================================================================
    End Sub
    Sub last_SerialJopOrder()
        On Error Resume Next
        sql = " SELECT        MAX(ser) AS MaxSer      FROM dbo.TB_Detils_QualityAprove GROUP BY JOB_Order, Compny_Code HAVING        (Compny_Code = 3) AND (JOB_Order = '" & Com_NoOrderJob.Text & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
            varserial = rs("MaxSer").Value + 1

        Else
            varserial = 1


        End If
    End Sub

    Private Sub GridControl4_Click_1(sender As Object, e As EventArgs)

    End Sub
    Sub fill_Detials_JopOrder()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "    SELECT        JOB_Order, SerialNo, LIGHT_ROLL, WIGHT_ROLL, NET_KG_ROLL, Thickness, Notes        FROM dbo.TB_Detils_QualityAprove WHERE        (JOB_Order = '" & Com_NoOrderJob.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)

        GridView1.Columns(0).Width = "100"
        GridView1.Columns(1).Width = "100"
        GridView1.Columns(2).Width = "50"
        GridView1.Columns(3).Width = "50"
        GridView1.Columns(4).Width = "50"
        GridView1.Columns(5).Width = "50"
        GridView1.Columns(6).Width = "200"

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True

        GridView1.Columns(0).Caption = "رقم امر الشغل "
        GridView1.Columns(1).Caption = "رقم Searil"
        GridView1.Columns(2).Caption = "الطول"
        GridView1.Columns(3).Caption = "العرض"
        GridView1.Columns(4).Caption = "الوزن"
        GridView1.Columns(5).Caption = "السمك"
        GridView1.Columns(6).Caption = "ملاحظات"





        'If varcode_form = 11 Or varcode_form = 5 Or varcode_form = 9 Or varcode_form = 4 Or varcode_form = 7 Then DataGridView2.Columns(2).Visible = False
        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
    Sub clear()
        txt_SerialNo.Text = ""
        txt_WIGHT_ROLL.Text = ""
        txt_LIGHT_ROLL.Text = ""
        txt_NET_KG_ROLL.Text = ""
        txt_Thickness.Text = ""

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs)
        'If OP1.Checked = True Then
        'If Len(Com_NoOrderJob.Text) = 0 Then MsgBox("من فضلك ادخل رقم امر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        'sql = "Delete TB_QualityAprove  WHERE JOB_Order = '" & Com_NoOrderJob.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        'rs = Cnn.Execute(sql)

        'txt_ROLL_NO.Text = Com_NoOrderJob.Text & "-" & Trim(ValueNOItem) & "-" & Trim(ValueNOOrder)
        'sql = "INSERT INTO TB_QualityAprove (JOB_Order, Compny_Code,ROLL_NO) " & _
        '  " values  ('" & Com_NoOrderJob.Text & "' ,'" & VarCodeCompny & "','" & txt_LIGHT_ROLL.Text & "')"
        'Cnn.Execute(sql)


        'MsgBox("تم ادخال بيانات المنتج التام بنجاح جاهز للطباعة", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Account Solution Software Module")
        'End If


        'If OP2.Checked = True Then
        '    If Len(Com_NoOrderJob.Text) = 0 Then MsgBox("من فضلك ادخل رقم امر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '    If Len(txt_LIGHT_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل الطول ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '    If Len(txt_WIGHT_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل رقم العرض ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        '    If Len(txt_NET_KG_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل رقم الوزن ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub

        '    sql = "Delete TB_QualityAprove  WHERE JOB_Order = '" & Com_NoOrderJob.Text & "' and Compny_Code ='" & VarCodeCompny & "' "
        '    rs = Cnn.Execute(sql)

        '    txt_ROLL_NO.Text = Com_NoOrderJob.Text & "-" & Trim(ValueNOItem) & "-" & Trim(ValueNOOrder)
        '    sql = "INSERT INTO TB_QualityAprove (JOB_Order, Compny_Code,LIGHT_ROLL,WIGHT_ROLL,NET_KG_ROLL,ROLL_NO,OUTSIDE_DLAM,INSIDE_DLAM,Shift) " & _
        '      " values  ('" & Com_NoOrderJob.Text & "' ,'" & VarCodeCompny & "','" & txt_LIGHT_ROLL.Text & "','" & txt_WIGHT_ROLL.Text & "','" & txt_NET_KG_ROLL.Text & "','" & txt_ROLL_NO.Text & "','" & txt_OUTSIDE_DLAM.Text & "','" & txt_INSIDE_DLAM.Text & "','" & txt_shift.Text & "')"
        '    Cnn.Execute(sql)


        '    MsgBox("تم ادخال بيانات المنتج التام بنجاح جاهز للطباعة", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Account Solution Software Module")
        'End If
    End Sub



    Private Sub GridControl4_Click_2(sender As Object, e As EventArgs) Handles GridControl4.Click
        On Error Resume Next
        clear()

        Dim visibleRowHandle As Integer = GridView5.FocusedRowHandle
        'varJopOrder = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        Com_NoOrderJob.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        lab_LableQR.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(9))
        ValueNOItem = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(2))
        ValueNOOrder = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(6))
        Txt_Machine.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(12))
        txt_NameItem.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))
        txt_date.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))

        If OP1.Checked = True Then varlable = 1
        If OP2.Checked = True Then varlable = 2
        If OP3.Checked = True Then varlable = 3
        If OP4.Checked = True Then varlable = 4

        txt_datechange.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(1))
        txt_name.Text = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(3))


        sql = "select * from TB_QualityAprove  WHERE JOB_Order = '" & Com_NoOrderJob.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then

            '    Com_NoOrderJob.Text = rs2("JOB_Order").Value
            '    txt_LIGHT_ROLL.Text = rs2("LIGHT_ROLL").Value
            '    txt_WIGHT_ROLL.Text = rs2("WIGHT_ROLL").Value
            '    txt_NET_KG_ROLL.Text = rs2("NET_KG_ROLL").Value
            txt_ROLL_NO.Text = rs2("ROLL_NO").Value
            '    txt_OUTSIDE_DLAM.Text = rs2("OUTSIDE_DLAM").Value
            '    txt_INSIDE_DLAM.Text = rs2("INSIDE_DLAM").Value
        End If   '    txt_shift.Text = rs2("shift").Value



        sql2 = "    SELECT     *       FROM dbo.TB_Detils_QualityAprove WHERE        (JOB_Order = '" & Com_NoOrderJob.Text & "') AND (Compny_Code = '" & VarCodeCompny & "')"
        rs2 = Cnn.Execute(sql2)
        If rs2.EOF = False Then SimpleButton1.Enabled = False : SimpleButton2.Enabled = True Else SimpleButton1.Enabled = True : SimpleButton2.Enabled = False




        fill_Detials_JopOrder()
        'print_Label()
        'Else
        'txt_LIGHT_ROLL.Text = ""
        'txt_NET_KG_ROLL.Text = ""
        'txt_ROLL_NO.Text = ""
        'txt_WIGHT_ROLL.Text = ""
        'txt_OUTSIDE_DLAM.Text = ""
        'txt_INSIDE_DLAM.Text = ""
        'txt_shift.Text = ""
        'print_Label()
        'End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        save_detils()
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Len(Com_NoOrderJob.Text) = 0 Then MsgBox("من فضلك ادخل رقم امر الشغل ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_LIGHT_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل طول المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_WIGHT_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل العرض المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_NET_KG_ROLL.Text) = 0 Then MsgBox("من فضلك ادخل الوزن المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub
        'If Len(txt_Thickness.Text) = 0 Then MsgBox("من فضلك ادخل السمك المنتج ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Account Solution Software Module") : Exit Sub


        sql2 = "UPDATE  TB_Detils_QualityAprove  SET LIGHT_ROLL='" & txt_LIGHT_ROLL.Text & "' , WIGHT_ROLL = '" & txt_WIGHT_ROLL.Text & "',NET_KG_ROLL ='" & txt_NET_KG_ROLL.Text & "',Thickness ='" & txt_Thickness.Text & "',Notes ='" & txt_Notes.Text & "' WHERE Compny_Code = " & VarCodeCompny & "  and SerialNo ='" & txt_SerialNo.Text & "' and JOB_Order ='" & Com_NoOrderJob.Text & "'  "
        rs = Cnn.Execute(sql2)

        MsgBox("تم اضافة المواصفات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Account Solution Software Module")
        fill_Detials_JopOrder()



    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        clear()
        'fill_Detials_JopOrder()

        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        'varJopOrder = GridView5.GetRowCellValue(visibleRowHandle, GridView5.Columns(0))
        txt_SerialNo.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        txt_LIGHT_ROLL.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        txt_WIGHT_ROLL.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(3))
        txt_NET_KG_ROLL.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        txt_Thickness.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))

        If txt_LIGHT_ROLL.Text <> "" Then SimpleButton1.Enabled = False : SimpleButton2.Enabled = True Else SimpleButton2.Enabled = True : SimpleButton1.Enabled = False
        If OP4.Checked = True Then varlable = 4
        If OP1.Checked = True Then varlable = 1
        If OP2.Checked = True Then varlable = 2
        If OP3.Checked = True Then varlable = 3

        If OP5.Checked = True Then varlable = 5
        print_Label()
    End Sub



    Private Sub OP6_Click(sender As Object, e As EventArgs) Handles OP6.Click
        print_Label()
    End Sub



    Private Sub OP7_Click(sender As Object, e As EventArgs) Handles OP7.Click
        print_Label()
    End Sub


    Private Sub Cmd_Update_Click(sender As Object, e As EventArgs) Handles Cmd_Update.Click
        On Error Resume Next
        sql2 = "UPDATE  TB_Detils_QualityAprove  SET Oprator ='" & txt_Oprator.Text & "', Exp_Date ='" & txt_ExpDate.Text & "', Shift ='" & txt_Shift2.Text & "' , NameItem ='" & txt_name.Text & "'  WHERE Compny_Code = " & VarCodeCompny & "  and SerialNo ='" & txt_SerialNo.Text & "' and JOB_Order ='" & Com_NoOrderJob.Text & "'  "
        rs = Cnn.Execute(sql2)

        '========================================================
        Dim dd As DateTime = txt_datechange.Text
        Dim vardateoder As String
        vardateoder = dd.ToString("MM-d-yyyy")

        sql2 = "UPDATE  TB_Header_JOB_Order  SET JOBOrder_Date ='" & vardateoder & "'  WHERE Compny_Code = " & VarCodeCompny & "   and JOB_Order ='" & Com_NoOrderJob.Text & "'  "
        rs = Cnn.Execute(sql2)

        MsgBox("تم اتعديل", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Account Solution Software Module")
        fill_Detials_JopOrder()
    End Sub
End Class