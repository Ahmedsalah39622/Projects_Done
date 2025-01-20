Imports System.Data.OleDb

Public Class Frm_SetupCruuncy
    Dim varcode_Cru, varcode_ID As Integer
    Dim value, value2 As String


    Private Sub txt_AccountNameCostCenter_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_CurrencyName.ButtonClick
        vartable = "BD_Currency"
        VarOpenlookup = 31
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
        find_Cur()
    End Sub



    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_CurrencyName.Text) = 0 Then MsgBox("من فضلك أختار العملة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        '=================================================بدايةالفترة
        Dim dd As DateTime = txt_date.Value
        Dim vardateStart As String
        vardateStart = dd.ToString("MM-d-yyyy")

        '==============================================نهاية الفترة
        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateEnd As String
        vardateEnd = dd2.ToString("MM-d-yyyy")

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_CurrencyName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================


        sql2 = "INSERT INTO Setup_Currency (Code_Currency, Rat,Date_Start,Date_End,Compny_Code) " & _
          " values  ('" & varcode_Cru & "' ,'" & txt_rat.Text & "','" & vardateStart & "' ,'" & vardateEnd & "','" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)

        '================================saveAllDayCru
        delete_insert()
        add_payment()
       

        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_Cur()
    End Sub
    Sub delete_insert()
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_CurrencyName.Text & "' and Compny_Code ='" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=================================================بدايةالفترة
        Dim dd As DateTime = txt_date.Value
        Dim vardateStart As String
        vardateStart = dd.ToString("MM-d-yyyy")

        '==============================================نهاية الفترة
        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateEnd As String
        vardateEnd = dd2.ToString("MM-d-yyyy")

        '============================================حذف
        sql = "Delete TB_Cru_Day  WHERE          (Date_Cru >= CONVERT(DATETIME, '" & vardateStart & "', 102))  AND (Date_Cru <= CONVERT(DATETIME, '" & vardateEnd & "', 102))  AND (Code_Cur = '" & varcode_Cru & "' ) and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        '====================================================================
    End Sub


    Sub add_payment()
       


        ''==================================================date From
        Dim oldDate As Date
        Dim oldDay As Integer
        Dim oldmonth As Integer
        Dim oldyear As Integer
        ' Assign a date using standard short format.
        oldDate = txt_date.Value

        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        If oldDay = 1 Then oldDay = 2 Else oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate) - 1

        oldmonth = Microsoft.VisualBasic.DateAndTime.Month(oldDate)
        oldyear = Microsoft.VisualBasic.DateAndTime.Year(oldDate)
        Dim vardayrent As Date
        'Dim vardayrent2 As Date
        vardayrent = CDate(oldDay & "/" & oldmonth & "/" & oldyear)

        'If Com_TypeContract.Text = "يومى" Then txt_date.Value = DateAdd("d", Val(txt_CountPayment.Text), vardayrent)
        Dim i As Integer
        i = 1
        Dim oldDate2 As Date
        Dim oldDay2 As Integer
        Dim oldmonth2 As Integer
        Dim oldyear2 As Integer
        oldDate2 = txt_date2.Value
        oldDay2 = Microsoft.VisualBasic.DateAndTime.Day(oldDate2)
        oldmonth2 = Microsoft.VisualBasic.DateAndTime.Month(oldDate2)
        oldyear2 = Microsoft.VisualBasic.DateAndTime.Year(oldDate2)


        Dim startP As DateTime = New DateTime(oldyear, oldmonth, oldDay)
        Dim endP As DateTime = New DateTime(oldyear2, oldmonth2, oldDay2)
        Dim CurrD As DateTime = startP

        While (CurrD < endP)
            'ProcessData(CurrD)
            Console.WriteLine(CurrD.ToShortDateString)
            CurrD = CurrD.AddDays(1)



            Dim oldDate3 As Date
            Dim oldDay3 As Integer
            Dim oldmonth3 As Integer
            Dim oldyear3 As Integer
            oldDate3 = CurrD
            oldDay3 = Microsoft.VisualBasic.DateAndTime.Day(oldDate3)
            oldmonth3 = Microsoft.VisualBasic.DateAndTime.Month(oldDate3)
            oldyear3 = Microsoft.VisualBasic.DateAndTime.Year(oldDate3)

            Dim vardayrent3 As String

            vardayrent3 = oldmonth3 & "/" & oldDay3 & "/" & oldyear3
            'vardayrent3 = CDate(oldDay3 & "/" & oldmonth3 & "/" & oldyear3)

            '========================================================رقم العملة
            sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_CurrencyName.Text & "' and Compny_Code ='" & VarCodeCompny & "'"
            rs = Cnn.Execute(sql)
            If rs.EOF = False Then varcode_Cru = rs("code").Value
            '=================================================بدايةالفترة
            Dim dd As DateTime = txt_date.Value
            Dim vardateStart As String
            vardateStart = dd.ToString("MM-d-yyyy")

            '==============================================نهاية الفترة
            Dim dd2 As DateTime = txt_date2.Value
            Dim vardateEnd As String
            vardateEnd = dd2.ToString("MM-d-yyyy")

            'and Compny_Code ='" & VarCodeCompny & "'
            sql = "INSERT INTO TB_Cru_Day (Code_Cur, Date_Cru,Rat_cru,Date_Start,Date_End,Compny_Code) " & _
            " values  ('" & varcode_Cru & "' ,'" & vardayrent3 & "','" & txt_rat.Text & "','" & vardateStart & "','" & vardateEnd & "','" & VarCodeCompny & "' )"
            Cnn.Execute(sql)

            i = i + 1
            'varaddpayment = CurrD
        End While




    End Sub
    Sub find_Cur()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        sql2 = "SELECT        dbo.Setup_Currency.ID, dbo.BD_Currency.Name, dbo.Setup_Currency.Rat, dbo.Setup_Currency.Date_Start, dbo.Setup_Currency.Date_End " & _
        " FROM            dbo.Setup_Currency INNER JOIN " & _
        "                         dbo.BD_Currency ON dbo.Setup_Currency.Code_Currency = dbo.BD_Currency.Code AND dbo.Setup_Currency.Compny_Code = dbo.BD_Currency.Compny_Code " & _
        " WHERE        (dbo.BD_Currency.Name = '" & txt_CurrencyName.Text & "') and Setup_Currency.Compny_Code = '" & VarCodeCompny & "' "

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "100"
        GridView6.Columns(3).Width = "100"
        GridView6.Columns(3).Width = "100"


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "الكود"
        GridView6.Columns(1).Caption = "أسم العملة "
        GridView6.Columns(2).Caption = "معامل التحويل "
        GridView6.Columns(3).Caption = "من فترة"
        GridView6.Columns(4).Caption = "الى فترة"



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub
    Private Sub cmd_Edit_Click(sender As Object, e As EventArgs) Handles cmd_Edit.Click

        '=================================================بدايةالفترة
        Dim dd As DateTime = txt_date.Value
        Dim vardateStart As String
        vardateStart = dd.ToString("MM-d-yyyy")

        '==============================================نهاية الفترة
        Dim dd2 As DateTime = txt_date2.Value
        Dim vardateEnd As String
        vardateEnd = dd2.ToString("MM-d-yyyy")


        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_CurrencyName.Text & "' and Compny_Code = '" & VarCodeCompny & "'"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================



        sql = "UPDATE  Setup_Currency  SET Rat ='" & txt_rat.Text & "',Date_Start ='" & vardateStart & "',Date_End ='" & vardateEnd & "'  WHERE ID = " & value & " and Code_Currency ='" & varcode_Cru & "' and Compny_Code = '" & VarCodeCompny & "'   "
        rs = Cnn.Execute(sql)

        delete_insert()
        add_payment()
        MsgBox("تم التعديل", MsgBoxStyle.Information, "Css Solution Software Module")
        find_Cur()
    End Sub



    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView6.FocusedRowHandle
        value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(0))
        txt_CurrencyName.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(1))
        txt_rat.Text = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(2))
        txt_date.Value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(3))
        txt_date2.Value = GridView6.GetRowCellValue(visibleRowHandle, GridView6.Columns(4))

    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next
        Dim x As String
        x = MsgBox("هل تريد حذف الاسم", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                '========================================================رقم العملة
                sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_CurrencyName.Text & "' and Compny_Code = '" & VarCodeCompny & "'"
                rs = Cnn.Execute(sql)
                If rs.EOF = False Then varcode_Cru = rs("code").Value
                '=====================================================


                sql = "Delete Setup_Currency  WHERE ID = " & value & " and Code_Currency ='" & varcode_Cru & "' and Compny_Code = '" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)




                '=================================================بدايةالفترة
                Dim dd As DateTime = txt_date.Value
                Dim vardateStart As String
                vardateStart = dd.ToString("MM-d-yyyy")

                '==============================================نهاية الفترة
                Dim dd2 As DateTime = txt_date2.Value
                Dim vardateEnd As String
                vardateEnd = dd2.ToString("MM-d-yyyy")

                '============================================حذف
                sql = "Delete TB_Cru_Day  WHERE          (Date_Cru >= CONVERT(DATETIME, '" & vardateStart & "', 102))  AND (Date_Cru <= CONVERT(DATETIME, '" & vardateEnd & "', 102))  AND (Code_Cur = '" & varcode_Cru & "' )  and Compny_Code = '" & VarCodeCompny & "' "
                rs = Cnn.Execute(sql)
                '====================================================================



                MsgBox("تم الحذف", MsgBoxStyle.Information, "Css Solution Software Module")
                find_Cur()
        End Select
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView6.ShowPrintPreview()

    End Sub

    Private Sub txt_CurrencyName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_CurrencyName.EditValueChanged

    End Sub
End Class