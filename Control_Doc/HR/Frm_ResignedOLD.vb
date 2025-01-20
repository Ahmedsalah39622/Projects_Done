Imports System.Data.OleDb


Public Class Frm_ResignedOLD


    Private Sub Frm_ScanData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_ERP2.DataItem' table. You can move, or remove it, as needed.
        'Me.DataItemTableAdapter.Fill(Me.DB_ERP2.DataItem)
        'TODO: This line of code loads data into the 'DB_ERP_CssDataSet.DataItem' table. You can move, or remove it, as needed.
        'Me.DataItemTableAdapter.Fill(Me.DB_ERP_CssDataSet.DataItem)
        Search()
        Search2()
    End Sub
    Sub Search()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql = "SELECT  code,name FROM  " & vartable & "   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else
        'sql = "SELECT  code,name FROM  " & vartable & "   "

        sql = "SELECT GroupItemMain.Name AS NameGroup, GroupItem1.Name AS Model, DataItem.Name AS NameItem " & _
        " FROM     GroupItemMain INNER JOIN " & _
        "                  GroupItem1 ON GroupItemMain.Code = GroupItem1.CodeMainGroup INNER JOIN " & _
        "                  DataItem ON GroupItemMain.Code = DataItem.CodeGroupItemMain AND GroupItem1.Code = DataItem.CodeGroupItem1 "



        'End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl1.DataSource = ds.Tables(0)



        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "المجموعة الرئيسية"
        GridView1.Columns(1).Caption = "الموديل"
        GridView1.Columns(2).Caption = "أسم الصنف"

        GridView1.Columns(0).Width = "50"
        GridView1.Columns(1).Width = "150"
        GridView1.Columns(2).Width = "150"




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub



    Sub Search2()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        'sql = "SELECT  code,name FROM  " & vartable & "   "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else
        'sql = "SELECT  code,name FROM  " & vartable & "   "

        sql = " SELECT NoItem, DateMoveM, Export, Import     FROM Statement_OfItem  WHERE(NoItem = 3)"

        'End If


        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl1.DataSource = ds.Tables(0)



        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم الصنف"
        GridView1.Columns(1).Caption = "التاريخ"
        GridView1.Columns(2).Caption = "وارد"
        GridView1.Columns(3).Caption = "منصرف"

        GridView1.Columns(0).Width = "50"
        GridView1.Columns(1).Width = "150"
        GridView1.Columns(2).Width = "150"
        GridView1.Columns(3).Width = "150"




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub




    Private Sub SplitContainerControl4_Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelX4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelX5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelX30_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelX31_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub LabelX32_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_CodeG_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker5_ValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub LabelX18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker4_ValueChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker5_ValueChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabNavigationPage1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class