Imports System.Data.OleDb

Public Class Frm_ShiftEmp

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Cmd_Save_Click_1(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        If Len(txt_ShiftName.Text) = 0 Then MsgBox("من فضلك أدخل  الوردية ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

        ''=================================================بدايةالفترة
        'Dim dd As DateTime = txt_date.Value
        'Dim vardateStart As String
        'vardateStart = dd.ToString("HH:MM:SS")

        ''==============================================نهاية الفترة
        'Dim dd2 As DateTime = txt_date2.Value
        'Dim vardateEnd As String
        'vardateEnd = dd2.ToString("HH:MM:SS")

        '========================================================رقم العملة
        sql = "  SELECT *    FROM BD_Currency where   Name ='" & txt_ShiftName.Text & "' and Compny_Code ='" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then varcode_Cru = rs("code").Value
        '=====================================================


        sql2 = "INSERT INTO TB_Shift (Code_Shift, Name_Shift,Str_Time,End_Time,Compny_Code) " & _
          " values  ('" & txt_shiftNo.Text & "' ,'" & txt_ShiftName.Text & "','" & TimeEdit1.Text & "' ,'" & TimeEdit2.Text & "','" & VarCodeCompny & "')"
        rs = Cnn.Execute(sql2)


        MsgBox("تم حفظ البيانات", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "Css Solution Software Module")
        find_Shift()
    End Sub

    
    Sub find_Shift()
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql2 = "   SELECT        Name_Shift, Str_Time, End_Time       FROM dbo.TB_Shift    WHERE(Compny_Code = '" & VarCodeCompny & "')"


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)

        GridView6.Columns(0).Width = "100"
        GridView6.Columns(1).Width = "100"
        GridView6.Columns(2).Width = "100"
     


        GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
        GridView6.Appearance.Row.Options.UseFont = True

        GridView6.Columns(0).Caption = "أسم الوردية"
        GridView6.Columns(1).Caption = "ميعاد بداية الوردية "
        GridView6.Columns(2).Caption = "ميعاد نهاية الوردية "



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()



    End Sub

    Private Sub Frm_ShiftEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        find_Shift()
    End Sub
End Class