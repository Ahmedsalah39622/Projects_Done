Imports System.Data.OleDb

Public Class Frm_Gard2

    Private Sub Frm_Gard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Sub Search()
        'On Error Resume Next
        If varCodeConnaction = 2 Then '======Oracle

            Dim con As New OleDb.OleDbConnection
            Dim ss As String
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql = "    SELECT        NoItem, Ex_item, NameItem, NameGroup,NGM, Name, Balance, TypeItem           FROM dbo.vw_Gard      WHERE(Compny_Code = '" & VarCodeCompny & "')"

            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "رقم الصنف"
            GridView6.Columns(1).Caption = " رقم التوصيفى "
            GridView6.Columns(2).Caption = "أسم الصنف"
            GridView6.Columns(3).Caption = "المجموعة الرئيسية"
            GridView6.Columns(4).Caption = "الموديل"
            GridView6.Columns(5).Caption = "الوحدة"
            GridView6.Columns(6).Caption = "الكمية المتاحة"
            GridView6.Columns(7).Caption = "نوع الصنف"


            GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
            GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red
            'GridView6.Columns(2).AppearanceCell.Font.FontFamily

            'GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
            'GridView6.Appearance.Row.Options.UseFont = True

            GridView6.Columns(0).Width = "50"
            GridView6.Columns(1).Width = "75"
            GridView6.Columns(2).Width = "50"
            GridView6.Columns(3).Width = "100"
            GridView6.Columns(4).Width = "100"
            GridView6.Columns(5).Width = "100"
            GridView6.Columns(6).Width = "75"
            GridView6.Columns(7).Width = "100"
            'GridView6.Columns(8).Width = "100"




            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If


        If varCodeConnaction = 1 Then '======Sql

            'Dim con As New OleDb.OleDbConnection
            'Dim ss As String
            'ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            'con.ConnectionString = ss
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()





            sql = "    SELECT        NoItem, Ex_item, NameItem, NameGroup,NGM, Nunit, Balance, TypeItem           FROM dbo.vw_Gard      WHERE(Compny_Code = '" & VarCodeCompny & "')"

            'sql = "SELECT  code,name FROM  BD_ITEM   "
            rs = Cnn.Execute(sql)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl3.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"
            GridView6.Columns(0).Caption = "رقم الصنف"
            GridView6.Columns(1).Caption = " رقم التوصيفى "
            GridView6.Columns(2).Caption = "أسم الصنف"
            GridView6.Columns(3).Caption = "المجموعة الرئيسية"
            GridView6.Columns(4).Caption = "المجموعة 1"
            GridView6.Columns(5).Caption = "الوحدة"
            GridView6.Columns(6).Caption = "الكمية المتاحة"
            GridView6.Columns(7).Caption = "نوع الصنف"



            GridView6.Columns(1).AppearanceCell.BackColor = Color.DarkGray
            GridView6.Columns(1).AppearanceCell.ForeColor = Color.Red
            'GridView6.Columns(2).AppearanceCell.Font.FontFamily

            'GridView6.Appearance.Row.Font = New Font(GridView6.Appearance.Row.Font, FontStyle.Bold)
            'GridView6.Appearance.Row.Options.UseFont = True

            GridView6.Columns(0).Width = "100"
            GridView6.Columns(1).Width = "100"
            GridView6.Columns(2).Width = "150"
            GridView6.Columns(3).Width = "100"
            GridView6.Columns(4).Width = "100"
            GridView6.Columns(5).Width = "100"
            GridView6.Columns(6).Width = "75"
            GridView6.Columns(7).Width = "100"
            'GridView6.Columns(8).Width = "100"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub
End Class