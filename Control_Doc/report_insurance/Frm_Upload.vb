Imports System.Data.OleDb
Imports System.Data
'Imports Oracle.ManagedDataAccess.Client ' ODP.NET Oracle managed provider
'Imports Oracle.ManagedDataAccess.Types
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.DataAccess.Excel

Public Class Frm_Upload
    Dim varGM, varG1, varG2 As Integer

    Dim VarExcelFileName, VarTableName, VarLookupTableName, VarLookupIdValue, VarUpTypeName, VarRowRange As String
    Dim VarSelectNumber, VarUpTypeId, VarUpTransformID As Integer
    Sub fill_Data()
        If IsNothing(TextBox2.Text) Then MsgBox("برجاء اختيار قاعدة البيانات", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If VarSelectNumber = 1 Then
            ComboBox4.Items.Clear()
            ComboBox7.Items.Clear()
            sql = "Select TABLE_NAME from INFORMATION_SCHEMA.TABLES Where TABLE_TYPE = 'BASE TABLE'"
        End If
        If VarSelectNumber = 2 Then
            ComboBox5.Items.Clear()
            ComboBox11.Items.Clear()
            sql = "Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = '" & VarTableName & "'"
        End If
        If VarSelectNumber = 22 Then
            ComboBox9.Items.Clear()
            ComboBox10.Items.Clear()
            sql = "Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = '" & VarLookupTableName & "'"
        End If
        If VarSelectNumber = 3 Then
            GridControl3.DataSource = Nothing
            GridView5.Columns.Clear()
            sql = "Select * from " & VarTableName & ""
        End If
        If VarSelectNumber = 4 Then
            ComboBox3.Items.Clear()
            sql = "Select Up_TypeName from UploadType"
        End If
        If VarSelectNumber = 5 Then
            sql = "Select * from UploadTransfer Where Up_TypeID = '" & VarUpTypeId & "'"
        End If

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
        Dim items = ds.Tables(0).AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()

        If VarSelectNumber = 1 Then
            ComboBox4.Items.AddRange(items)
            ComboBox7.Items.AddRange(items)
        End If
        If VarSelectNumber = 2 Then
            ComboBox5.Items.AddRange(items)
            ComboBox11.Items.AddRange(items)
        End If
        If VarSelectNumber = 22 Then
            ComboBox9.Items.AddRange(items)
            ComboBox10.Items.AddRange(items)
        End If
        If VarSelectNumber = 3 Then
            GridControl3.DataSource = ds.Tables(0)
            GridView5.BestFitColumns()
        End If
        If VarSelectNumber = 4 Then
            ComboBox3.Items.AddRange(items)
        End If
        If VarSelectNumber = 5 Then
            GridControl2.DataSource = ds.Tables(0)
            GridView3.BestFitColumns()
        End If

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub

    Private Sub Frm_DataCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "5000"
        TextBox2.Text = DatabaseName
    End Sub
    Sub GetExcelData()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        ComboBox2.Items.Clear()
        ComboBox8.Items.Clear()
        Dim myExcelSource As New DevExpress.DataAccess.Excel.ExcelDataSource()
        myExcelSource.FileName = VarExcelFileName
        myExcelSource.SourceOptions = New CsvSourceOptions() With {.CellRange = "A1:AZ" & VarRowRange & ""}
        myExcelSource.SourceOptions.SkipEmptyRows = False
        myExcelSource.SourceOptions.UseFirstRowAsHeader = True
        myExcelSource.Fill()
        GridControl1.DataSource = myExcelSource
        GridView1.BestFitColumns()

        If VarSelectNumber = 555 Then
            For i = 0 To GridView1.Columns.Count - 1
                ComboBox2.Items.Add(GridView1.Columns(i).FieldName)
                ComboBox8.Items.Add(GridView1.Columns(i).FieldName)
            Next
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        'Test result.
        If result = Windows.Forms.DialogResult.OK Then
            ' Do something.
            VarExcelFileName = OpenFileDialog1.FileName
            LabelX2.Text = "أختر شيت الأكسيل (" & System.IO.Path.GetFileName(OpenFileDialog1.FileName) & ") :"
        Else
            LabelX2.Text = "أختر شيت الأكسيل (ExcelName) :"
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        VarRowRange = ComboBox1.SelectedItem
    End Sub

    Private Sub ComboBox4_GotFocus(sender As Object, e As EventArgs) Handles ComboBox4.GotFocus
        If TextBox2.Text = "" Then MsgBox("لم يتم تحديد قاعدة البيانات", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 1
        fill_Data()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        VarTableName = ComboBox4.SelectedItem

        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox11.Text = ""
        AddItemsCombo()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        If IsNothing(VarTableName) Then MsgBox("برجاء اختيار أسم الجدول", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        find_Data()

        'VarSelectNumber = 3
        'fill_Data()
    End Sub

    Private Sub ComboBox5_GotFocus(sender As Object, e As EventArgs) Handles ComboBox5.GotFocus
        VarSelectNumber = 2
        fill_Data()
    End Sub

    Private Sub ComboBox3_GotFocus(sender As Object, e As EventArgs) Handles ComboBox3.GotFocus
        VarSelectNumber = 4
        fill_Data()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If IsNothing(ComboBox3.SelectedItem) Then
        Else
            sql = "Select Up_TypeID from UploadType Where Up_TypeName = '" & ComboBox3.SelectedItem & "'"
            rs = Cnn.Execute(sql)
            VarUpTypeId = rs("Up_TypeID").Value
        End If

        VarSelectNumber = 5
        fill_Data()
    End Sub

    Private Sub ComboBox2_GotFocus(sender As Object, e As EventArgs) Handles ComboBox2.GotFocus
        If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 555
        GetExcelData()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        TextBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        ComboBox11.Text = ""
        AddItemsCombo()
    End Sub
    Sub Clear()
        TextBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        AddItemsCombo()
    End Sub
    Sub AddItemsCombo()
        ComboBox6.Items.Clear()
        ComboBox6.Items.Add("Field")
        ComboBox6.Items.Add("PrimaryKey")
        ComboBox6.Items.Add("Lookup")

        'ComboBox1.Items.Clear()
        'ComboBox1.Items.Add("200")
        'ComboBox1.Items.Add("500")
        'ComboBox1.Items.Add("2000")
        'ComboBox1.Items.Add("5000")
        'ComboBox1.Items.Add("20000")
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        If IsNothing(ComboBox3.Text) Then
        Else
            sql = "SELECT MAX(Up_TypeID) AS MaxmamNo FROM dbo.UploadType HAVING(MAX(Up_TypeID) Is Not NULL) "
            rs = Cnn.Execute(sql)
            Dim TypeID As Integer
            If rs.EOF = False Then
                TypeID = rs("MaxmamNo").Value + 1
            Else
                TypeID = 1
            End If

            sql = "INSERT INTO [dbo].[UploadType] ([Up_TypeID] ,[Up_TypeName])  VALUES ('" & TypeID & "','" & ComboBox3.Text & "')"
            rs = Cnn.Execute(sql)
            ComboBox3.Text = ""
        End If
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        If IsNothing(ComboBox3.SelectedItem) And IsNothing(ComboBox3.Text) Then
        Else

            sql = "Select Up_TypeID from UploadTransfer Where Up_TypeID = '" & VarUpTypeId & "'"
            rs = Cnn.Execute(sql)

            If rs("Up_TypeID").Value IsNot Nothing Then MsgBox("لا يمكن حذف نوع عملية تم انشاء ترحيل عليها من قبل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

            sql = "DELETE FROM [dbo].[UploadType] WHERE [Up_TypeName] = '" & ComboBox3.SelectedItem & "'"
            rs = Cnn.Execute(sql)
            ComboBox3.SelectedIndex = -1
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If IsNothing(VarUpTransformID) Or TextBox1.Text = "" Then MsgBox("برجاء أختيار الصف قبل الحذف", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        sql = "DELETE FROM [dbo].[UploadTransfer] WHERE [Up_ID] = '" & VarUpTransformID & "'"
        rs = Cnn.Execute(sql)

        Clear()
        VarSelectNumber = 5
        fill_Data()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If IsNothing(VarUpTransformID) Or TextBox1.Text = "" Then MsgBox("برجاء أختيار الصف قبل التعديل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If IsNothing(ComboBox3.SelectedItem) Then
        Else
            sql = "Select Up_TypeID from UploadType Where Up_TypeName = '" & ComboBox3.SelectedItem & "'"
            rs = Cnn.Execute(sql)
            VarUpTypeId = rs("Up_TypeID").Value
        End If

        If IsNothing(VarUpTypeId) And IsNothing(ComboBox3.Text) Then MsgBox("برجاء أختيار نوع العملية قبل التعديل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        If ComboBox1.SelectedItem = "Lookup" Then
            If ComboBox2.Items.Contains(ComboBox2.Text) And ComboBox3.Items.Contains(ComboBox3.Text) And ComboBox4.Items.Contains(ComboBox4.Text) And ComboBox5.Items.Contains(ComboBox5.Text) And ComboBox6.Items.Contains(ComboBox6.Text) And ComboBox8.Items.Contains(ComboBox8.Text) And ComboBox11.Items.Contains(ComboBox11.Text) And ComboBox7.Items.Contains(ComboBox7.Text) And ComboBox9.Items.Contains(ComboBox9.Text) And ComboBox10.Items.Contains(ComboBox10.Text) Then

                sql = "UPDATE [dbo].[UploadTransfer] SET [Excel_PkColumnName] = '" & ComboBox8.Text & "',[Excel_ColumnName] = '" & ComboBox2.Text & "' ,[DB_TableName] = '" & ComboBox4.Text & "',[DB_TablePkColumnName] = '" & ComboBox11.Text & "' ,[DB_TableColumnName] = '" & ComboBox5.Text & "' ,[DB_LookupTableName] = '" & ComboBox7.Text & "',[DB_LookupColumnName] = '" & ComboBox9.Text & "',[DB_LookupColumnID] = '" & ComboBox10.Text & "',[CoumnType] = '" & ComboBox6.Text & "',[Up_TypeID] = '" & VarUpTypeId & "' WHERE [Up_ID] = '" & VarUpTransformID & "'"
                rs = Cnn.Execute(sql)

                Clear()
                VarSelectNumber = 5
                fill_Data()
            Else
                MsgBox("برجاء أختيار نوع العملية قبل التعديل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
            End If
        Else
            If ComboBox2.Items.Contains(ComboBox2.Text) And ComboBox3.Items.Contains(ComboBox3.Text) And ComboBox4.Items.Contains(ComboBox4.Text) And ComboBox5.Items.Contains(ComboBox5.Text) And ComboBox6.Items.Contains(ComboBox6.Text) And ComboBox8.Items.Contains(ComboBox8.Text) And ComboBox11.Items.Contains(ComboBox11.Text) Then

                sql = "UPDATE [dbo].[UploadTransfer] SET [Excel_PkColumnName] = '" & ComboBox8.Text & "',[Excel_ColumnName] = '" & ComboBox2.Text & "' ,[DB_TableName] = '" & ComboBox4.Text & "',[DB_TablePkColumnName] = '" & ComboBox11.Text & "' ,[DB_TableColumnName] = '" & ComboBox5.Text & "' ,[DB_LookupTableName] = '" & ComboBox7.Text & "',[DB_LookupColumnName] = '" & ComboBox9.Text & "',[DB_LookupColumnID] = '" & ComboBox10.Text & "',[CoumnType] = '" & ComboBox6.Text & "',[Up_TypeID] = '" & VarUpTypeId & "' WHERE [Up_ID] = '" & VarUpTransformID & "'"
                rs = Cnn.Execute(sql)

                Clear()
                VarSelectNumber = 5
                fill_Data()
            Else
                MsgBox("برجاء أختيار نوع العملية قبل التعديل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
            End If
        End If



    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If IsNothing(ComboBox3.SelectedItem) Then
        Else
            sql = "Select Up_TypeID from UploadType Where Up_TypeName = '" & ComboBox3.SelectedItem & "'"
            rs = Cnn.Execute(sql)
            VarUpTypeId = rs("Up_TypeID").Value
        End If

        If IsNothing(ComboBox2.SelectedItem) And IsNothing(ComboBox4.SelectedItem) And IsNothing(ComboBox5.SelectedItem) And IsNothing(ComboBox3.SelectedItem) And IsNothing(ComboBox6.SelectedItem) Then MsgBox("برجاء ملئ البيانات قبل الأضافة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        sql = "SELECT MAX(Up_ID) AS MaxmamNo FROM dbo.UploadTransfer HAVING(MAX(Up_ID) Is Not NULL) "
        rs = Cnn.Execute(sql)
        Dim TypeID As Integer
        If rs.EOF = False Then
            TypeID = rs("MaxmamNo").Value + 1
        Else
            TypeID = 1
        End If

        If ComboBox1.SelectedItem = "Lookup" Then
            If ComboBox2.Items.Contains(ComboBox2.Text) And ComboBox3.Items.Contains(ComboBox3.Text) And ComboBox4.Items.Contains(ComboBox4.Text) And ComboBox5.Items.Contains(ComboBox5.Text) And ComboBox6.Items.Contains(ComboBox6.Text) And ComboBox8.Items.Contains(ComboBox8.Text) And ComboBox11.Items.Contains(ComboBox11.Text) And ComboBox7.Items.Contains(ComboBox7.Text) And ComboBox9.Items.Contains(ComboBox9.Text) And ComboBox10.Items.Contains(ComboBox10.Text) Then
                sql = "INSERT INTO [dbo].[UploadTransfer] ([Up_ID],[Excel_PkColumnName],[Excel_ColumnName],[DB_TableName],[DB_TablePkColumnName],[DB_TableColumnName],[DB_LookupTableName],[DB_LookupColumnName],[DB_LookupColumnID],[CoumnType],[Up_TypeID]) VALUES ('" & TypeID & "','" & ComboBox8.Text & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox11.Text & "','" & ComboBox5.Text & "','" & ComboBox7.Text & "','" & ComboBox9.Text & "','" & ComboBox10.Text & "','" & ComboBox6.Text & "','" & VarUpTypeId & "')"
                rs = Cnn.Execute(sql)
                Clear()
                VarSelectNumber = 5
                fill_Data()
            Else
                MsgBox("برجاء ملئ البيانات قبل الأضافة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
            End If
        Else
            If ComboBox2.Items.Contains(ComboBox2.Text) And ComboBox3.Items.Contains(ComboBox3.Text) And ComboBox4.Items.Contains(ComboBox4.Text) And ComboBox5.Items.Contains(ComboBox5.Text) And ComboBox6.Items.Contains(ComboBox6.Text) And ComboBox8.Items.Contains(ComboBox8.Text) And ComboBox11.Items.Contains(ComboBox11.Text) Then
                sql = "INSERT INTO [dbo].[UploadTransfer] ([Up_ID],[Excel_PkColumnName],[Excel_ColumnName],[DB_TableName],[DB_TablePkColumnName],[DB_TableColumnName],[DB_LookupTableName],[DB_LookupColumnName],[DB_LookupColumnID],[CoumnType],[Up_TypeID]) VALUES ('" & TypeID & "','" & ComboBox8.Text & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox11.Text & "','" & ComboBox5.Text & "','" & ComboBox7.Text & "','" & ComboBox9.Text & "','" & ComboBox10.Text & "','" & ComboBox6.Text & "','" & VarUpTypeId & "')"
                rs = Cnn.Execute(sql)
                Clear()
                VarSelectNumber = 5
                fill_Data()
            Else
                MsgBox("برجاء ملئ البيانات قبل الأضافة", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
            End If
        End If



    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 555
        GetExcelData()

        If TextBox2.Text = "" Then MsgBox("لم يتم تحديد قاعدة البيانات", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 1
        fill_Data()

        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        TextBox1.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(0))
        VarUpTransformID = TextBox1.Text

        ComboBox8.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        ComboBox2.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(2))

        ComboBox4.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(3))

        VarSelectNumber = 2
        fill_Data()

        ComboBox11.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(4))
        ComboBox5.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(5))

        ComboBox7.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(6))

        VarSelectNumber = 22
        fill_Data()

        ComboBox9.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(7))
        ComboBox10.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(8))
        ComboBox6.SelectedItem = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(9))

        sql = "Select Up_TypeName from UploadType Where Up_TypeID = '" & GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(10)) & "'"
        rs = Cnn.Execute(sql)
        VarUpTypeName = rs("Up_TypeName").Value
        ComboBox3.SelectedItem = VarUpTypeName

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub
        If IsNothing(VarUpTypeId) And IsNothing(ComboBox3.Text) Then MsgBox("برجاء أختيار نوع العملية", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        Try
            GetExcelData()

            sql = "Select * from UploadTransfer Where Up_TypeID = '" & VarUpTypeId & "' Order By CoumnType DESC"

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
            Dim items = ds.Tables(0).AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()

            'For Each row in UploadTransfer
            For i = 0 To ds.Tables(0).Rows.Count - 1

                'For Each row in ExcelSheet
                For ii As Integer = 0 To GridView1.RowCount - 1

                    If ds.Tables(0).Rows(i)("CoumnType").ToString() = "PrimaryKey" Then
                        'insert

                        'check if ID at TABLE BEFOR INSERT
                        sql2 = "Select " & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & " from " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " Where " & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & " = '" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()).ToString() & "'"
                        rs2 = Cnn.Execute(sql2)

                        If rs2.EOF = False Then
                            If rs2(ds.Tables(0).Rows(i)("DB_TableColumnName").ToString()).Value = GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()).ToString() Then
                                MsgBox("لا يمكن استكمال العملية لآن الكود موجود مسبقا " + ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() + " " + GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()).ToString(), MsgBoxStyle.Critical, "Css Solution Software Module")
                                Exit Sub
                            Else
                                'insert
                                If GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()) IsNot Nothing Then
                                    sql = "INSERT INTO " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " (" & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & ") VALUES ('" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName")).ToString() & "')"
                                    rs = Cnn.Execute(sql)
                                End If
                            End If
                        Else
                            'insert
                            If GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()) IsNot Nothing Then
                                sql = "INSERT INTO " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " (" & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & ") VALUES ('" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName")).ToString() & "')"
                                rs = Cnn.Execute(sql)
                            End If
                        End If



                        'sql2 = "Select " & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & " from " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & ""

                        'Dim sss As String
                        'Dim conn As New OleDb.OleDbConnection
                        'sss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                        '        "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
                        'conn.ConnectionString = sss
                        'conn.Open()
                        'rs2 = Cnn.Execute(sql2)
                        'Dim daa As OleDbDataAdapter = New OleDbDataAdapter(sql2, conn)
                        'Dim dss As New DataSet()
                        'daa.Fill(dss)



                        'dss = Nothing
                        'daa = Nothing
                        'conn.Close()
                        'conn.Dispose()

                        'insert
                        'If GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()) IsNot Nothing Then
                        '    sql = "INSERT INTO " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " (" & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & ") VALUES ('" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName")).ToString() & "')"
                        '    rs = Cnn.Execute(sql)
                        'End If
                    Else
                        'update
                        If ds.Tables(0).Rows(i)("CoumnType").ToString() = "Lookup" Then
                            'search for lookup id value at lookup table
                            If GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()) IsNot Nothing Then

                                sql2 = "Select " & ds.Tables(0).Rows(i)("DB_LookupColumnID").ToString() & " from " & ds.Tables(0).Rows(i)("DB_LookupTableName").ToString() & " Where " & ds.Tables(0).Rows(i)("DB_LookupColumnName").ToString() & " Like '%" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName")).ToString() & "%'"
                                rs2 = Cnn.Execute(sql2)

                                'VarLookupIdValue = rs2(ds.Tables(0).Rows(i)("DB_LookupColumnID").ToString()).Value

                                If rs2.EOF = False Then
                                    VarLookupIdValue = rs2(ds.Tables(0).Rows(i)("DB_LookupColumnID").ToString()).Value
                                Else
                                    MessageBox.Show("ال Lookup غير موجود لا يمكن استكمال العملية")
                                    Exit Sub
                                End If

                                sql = "UPDATE " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " SET " & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & " = '" & VarLookupIdValue & "' WHERE " & ds.Tables(0).Rows(i)("DB_TablePkColumnName").ToString() & " = '" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_PkColumnName")).ToString() & "'"
                                rs = Cnn.Execute(sql)
                            End If
                        Else
                            If GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName").ToString()) IsNot Nothing Then
                                sql = "UPDATE " & ds.Tables(0).Rows(i)("DB_TableName").ToString() & " SET " & ds.Tables(0).Rows(i)("DB_TableColumnName").ToString() & " = '" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_ColumnName")).ToString() & "' WHERE " & ds.Tables(0).Rows(i)("DB_TablePkColumnName").ToString() & " = '" & GridView1.GetRowCellValue(ii, ds.Tables(0).Rows(i)("Excel_PkColumnName")).ToString() & "'"
                                rs = Cnn.Execute(sql)
                            End If
                        End If
                    End If
                Next



            Next

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
            MessageBox.Show("تم حفظ البيانات بنجاح")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub ComboBox7_GotFocus(sender As Object, e As EventArgs) Handles ComboBox7.GotFocus
        If TextBox2.Text = "" Then MsgBox("لم يتم تحديد قاعدة البيانات", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 1
        fill_Data()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        VarLookupTableName = ComboBox7.SelectedItem

        ComboBox6.Text = ""
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        AddItemsCombo()
    End Sub

    Private Sub ComboBox9_GotFocus(sender As Object, e As EventArgs) Handles ComboBox9.GotFocus
        VarSelectNumber = 22
        fill_Data()
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged

    End Sub

    Private Sub ComboBox10_GotFocus(sender As Object, e As EventArgs) Handles ComboBox10.GotFocus
        VarSelectNumber = 22
        fill_Data()
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged

    End Sub

    Private Sub ComboBox8_GotFocus(sender As Object, e As EventArgs) Handles ComboBox8.GotFocus
        If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        VarSelectNumber = 555
        GetExcelData()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged

    End Sub

    Private Sub ComboBox11_GotFocus(sender As Object, e As EventArgs) Handles ComboBox11.GotFocus
        VarSelectNumber = 2
        fill_Data()
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.SelectedItem = "PrimaryKey" Then
            If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

            VarSelectNumber = 555
            GetExcelData()

            VarSelectNumber = 2
            fill_Data()

            ComboBox8.SelectedItem = ComboBox2.SelectedItem
            ComboBox11.SelectedItem = ComboBox5.SelectedItem
        End If
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click

        Dim result As DialogResult = MessageBox.Show("هل انت متأكد من حذف البيانات ؟", "حذف البيانات", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            If IsNothing(VarTableName) And IsNothing(ComboBox4.Text) Then
                MessageBox.Show("لم يتم تحديد اسم الجدول")
            Else
                sql = "DELETE FROM " & VarTableName & ""
                rs = Cnn.Execute(sql)
                ComboBox4.Text = ""
                MessageBox.Show("تم حذف البيانات من الجدول بنجاح")
            End If
        End If
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click

        Dim result As DialogResult = MessageBox.Show("هل انت متأكد من حذف البيانات ؟", "حذف البيانات", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            If IsNothing(VarLookupTableName) And IsNothing(ComboBox7.Text) Then
                MessageBox.Show("لم يتم تحديد اسم الجدول")
            Else
                sql = "DELETE FROM " & VarLookupTableName & ""
                rs = Cnn.Execute(sql)
                ComboBox7.Text = ""
                MessageBox.Show("تم حذف البيانات من الجدول اللوك اب بنجاح")
            End If
        End If
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        'Test result.
        If result = Windows.Forms.DialogResult.OK Then
            ' Do something.
            VarExcelFileName = OpenFileDialog1.FileName
            LabelX2.Text = "أختر شيت الأكسيل (" & System.IO.Path.GetFileName(OpenFileDialog1.FileName) & ") :"
        Else
            LabelX2.Text = "أختر شيت الأكسيل (ExcelName) :"
        End If
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs)


    End Sub


    Sub find_Data()
        On Error Resume Next
        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If OP1.Checked = True Then
            sql2 = "select * from BD_union_data "
        End If

        If OP2.Checked = True Then
            sql2 = "select * from St_CustomerData2 "
        End If

        If OP3.Checked = True Then
            sql2 = "select * from BD_cars_info "
        End If


        If op4.Checked = True Then
            sql2 = "select * from BD_insurance_doucument "
        End If
        If op5.Checked = True Then
            sql2 = "select * from platinum_main_items "
        End If

        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)


        GridView5.Appearance.Row.Font = New Font(GridView5.Appearance.Row.Font, FontStyle.Bold)
        GridView5.Appearance.Row.Options.UseFont = True



        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()

        GridView5.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If IsNothing(VarExcelFileName) Then MsgBox("برجاء اختيار شيت الأكسيل", MsgBoxStyle.Critical, "Css Solution Software Module") : Exit Sub

        GetExcelData()
    End Sub

    Private Sub SimpleButton14_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub SimpleButton14_Click_2(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        On Error Resume Next

        Dim dd3 As DateTime = DateTime.Now.ToString("yyyy-MM-dd")
        Dim vardate3 As String
        vardate3 = dd3.ToString("dd/MM/yyyy")

        '==============================ALL

        If OP1.Checked = True Then
            Dim result As Integer = 0
            For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

                'If Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(16))) = "" Then MsgBox("من فضلك أختار حساب الايراد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

                'sql = "select * from BD_GROUPITEMMAIN where Code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' "
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then MsgBox("الكود مكرر لايمكن ادخاله ", MsgBoxStyle.Critical, "Css") : Exit Sub


                Dim dd As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(16)))
                Dim vardate1 As String
                vardate1 = dd.ToString("MM-d-yyyy")
                Dim dd2 As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(17)))
                Dim vardate2 As String
                vardate2 = dd.ToString("MM-d-yyyy")
                Dim dd4 As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(18)))
                Dim vardate4 As String
                vardate4 = dd.ToString("MM-d-yyyy")

                'sql = "INSERT INTO BD_GROUPITEMMAIN  " &
                '  " values  ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "' ,'" & VarCodeCompny & "')"

                sql = "INSERT INTO BD_union_data " &
                     " values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',
                      '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "' , " &
            "    '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "' ," &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "' ,  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(14))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(15))) & "',  " &
            "  '" & vardate1 & "',  " & 'date
            "  '" & vardate2 & "',  " & 'date
            "  '" & vardate4 & "',  " & 'date
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(19))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(20))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(21))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(22))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(23))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(24))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(25))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(26))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(27))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(28))) & "',  " &
            "  '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(29))) & "')"
                'sql = "INSERT INTO BD_union_data values ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(2))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(14))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(15))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(16))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(17))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(18))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(19))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(20))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(21))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(22))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(23))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(24))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(25))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(26))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(27))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(28))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(29))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(30))) & "')"

                Cnn.Execute(sql)



            Next rowHandle
            find_Data()
            MsgBox("تم تحميل البيانات بنجاح", MsgBoxStyle.Information, "Css") : find_Data() : Exit Sub
        End If

        '==============================CUSTOMER

        If OP2.Checked = True Then
            Dim result As Integer = 0
            For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

                'If Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(16))) = "" Then MsgBox("من فضلك أختار حساب الايراد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub

                'sql = "select * from BD_GroupItem1 where Code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' "
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then MsgBox("الكود مكرر لايمكن ادخاله ", MsgBoxStyle.Critical, "Css") : Exit Sub

                sql2 = "SELECT        MAX(Customer_Code) AS MaxmamNo FROM  St_CustomerData2    HAVING (MAX(Customer_Code) IS NOT NULL) "

                Dim code As Int32 = 0

                rs3 = Cnn.Execute(sql2)
                If rs3.EOF = False Then
                    code = rs3("MaxmamNo").Value + 1

                End If

                sql = "INSERT INTO St_CustomerData2 (Customer_Code,Customer_Name,Customer_Type,Code_City,Code_Region_M,Code_Region2,Al_Akar,Al_Dor,Al_Shak,Customer_Phon1,Customer_Phon2,Customer_Mobil1,Customer_Mobil2,Customer_Email_Work,Customer_Email_Persone,Customer_Website,Customer_Type_sex,Customer_State,Customer_NationalID,National_ID_Start,National_ID_End,Print_No,Birthday,Customer_FileNoTax,Customer_NoReg_Tax,Customer_NoFileTogary,Customer_NameM) " &
            " values  (" & ++code & " ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "',N'" & 0 & "',N'" & 1 & "',N'" & 1 & "'  " &
            " ,N'" & 1 & "',N'" & 1 & "',N'" & 1 & "',N'" & 1 & "',N'" & "123" & "','" & "123" & "',N'" & "123" & "',N'" & "123" & "',N'" & "a" & "',N'" & "a" & "',N'" & "a" & "',N'" & "a" & "',N'" & 1 & "',N'" & "52258" & "',N'" & "12-12-2020" & "',N'" & "12-12-2020" & "',N'" & "123" & "',N'" & "12-12-2020" & "',N'" & "" & "',N'" & "" & "',N'" & "" & "',N'" & "" & "')"
                Cnn.Execute(sql)


            Next rowHandle
            find_Data()
            MsgBox("تم تحميل البيانات بنجاج", MsgBoxStyle.Information, "Css") : find_Data() : Exit Sub
        End If


        '========================== CARS
        If OP3.Checked = True Then
            Dim result As Integer = 0
            For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle



                sql = "insert into BD_cars_info (car_brand , car_model, car_model_year , motor_no ,plate_no,shasyeh_no , wasyka_no,Permissions) " &
                  " values  ('" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(20))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(21))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(22))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(23))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(24))) & "','" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(25))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "' ,'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(19))) & "')"
                Cnn.Execute(sql)

            Next rowHandle

            MsgBox("تم تحميل البيانات بنجاح", MsgBoxStyle.Information, "Css") : find_Data() : Exit Sub
        End If



        'الوثائق
        If op4.Checked = True Then
            Dim result As Integer = 0
            For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

                'If Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(16))) = "" Then MsgBox("من فضلك أختار حساب الايراد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub
                '==================================GM
                'sql = "select * from BD_GROUPITEMMAIN where Name ='" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "' "
                'rs = Cnn.Execute(sql)
                'If rs.EOF = False Then varGM = rs("code").Value
                ''======================================
                'sql = "select * from BD_GroupItem1 where Name ='" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "' "
                'rs = Cnn.Execute(sql)
                'If rs.EOF = False Then varG1 = rs("code").Value
                ''===============================
                'sql = "select * from BD_GroupItem2 where Name ='" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "' "
                'rs = Cnn.Execute(sql)
                'If rs.EOF = False Then varG2 = rs("code").Value
                '===================================== الوحدة

                'sql = "select * from BD_Unit where Name ='" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(7))) & "' "
                'rs = Cnn.Execute(sql)
                'If rs.EOF = False Then varcodeunit = rs("code").Value


                'sql = "select * from BD_Item where Code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' "
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then MsgBox("الكود الصنف مكرر لايمكن ادخالة ", MsgBoxStyle.Critical, "Css") : Exit Sub


                Dim dd As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(16)))
                Dim vardate1 As String
                vardate1 = dd.ToString("MM-d-yyyy")
                Dim dd2 As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(17)))
                Dim vardate2 As String
                vardate2 = dd.ToString("MM-d-yyyy")
                Dim dd4 As Date = Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(18)))
                Dim vardate4 As String
                vardate4 = dd.ToString("MM-d-yyyy")

                sql = "insert into BD_insurance_doucument  (insurance_company_name,mother_company_name , wasyka_state,wallet,wasyka_no , customer_name , coverage_cost , net_cost , total_cost , insurance_start_date , insurance_end_date ,wasyka_start_date , shasyeh_no , tehmol_twkel , tehmol_egpary) " &
                  " values  (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(5))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(6))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(8))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(9))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(10))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(11))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(12))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(13))) & "',N'" & vardate1 & "' ,N'" & vardate2 & "',N'" & vardate4 & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(25))) & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(28))) & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(27))) & "')"
                Cnn.Execute(sql)


            Next rowHandle

            MsgBox("تم تحميل البيانات بنجاح", MsgBoxStyle.Information, "Css") : find_Data() : Exit Sub
        End If



        If op5.Checked = True Then

            sql = "UPDATE   Statement_OfItem   SET Export = '" & 0 & "',Import = '" & 0 & "' "
            rs = Cnn.Execute(sql)

            Dim result As Integer = 0
            For rowHandle As Integer = 0 To GridView1.DataRowCount - 1

                Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

                'If Trim(GridView6.GetRowCellValue(rowHandle, GridView6.Columns(16))) = "" Then MsgBox("من فضلك أختار حساب الايراد ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Css Solution Software Module") : Exit Sub


                'sql = "select * from BD_Unit where Name ='" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(3))) & "' "
                'rs = Cnn.Execute(sql)
                'If rs.EOF = False Then varcodeunit = rs("code").Value


                'sql = "select * from BD_Item where Code = '" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' "
                'rs2 = Cnn.Execute(sql)
                'If rs2.EOF = False Then MsgBox("الكود الصنف مكرر لايمكن ادخالة ", MsgBoxStyle.Critical, "Css") : Exit Sub

                Dim dd4 As DateTime = DateTime.Now.ToString("yyyy-MM-dd")
                Dim vardate4 As String
                vardate4 = dd4.ToString("MM/dd/yyyy")

                'sql = "INSERT INTO Statement_OfItem (NumberBill,Compny_Code, NoItem,Code_Unit,Code_Stores,DateMoveM,Dis,TypeD,Export,Import,Code_Sub) " &
                '  " values  (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(0))) & "' ,N'" & VarCodeCompny & "' ,N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(1))) & "',N'" & varcodeunit & "',N'" & 1 & "',N'" & vardate4 & "',N'" & "تسوية جردية جديدة" & "',N'" & 23 & "',N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "',N'" & 0 & "',N'" & 1 & "')"
                'Cnn.Execute(sql)


                sql = "INSERT INTO platinum_main_items  " &
                 " values  (N'" & Trim(GridView1.GetRowCellValue(rowHandle, GridView1.Columns(4))) & "')"
                Cnn.Execute(sql)


            Next rowHandle

            MsgBox("تم تحميل البيانات بنجاج", MsgBoxStyle.Information, "Css") : find_Data() : Exit Sub
        End If

    End Sub

    Private Sub SimpleButton16_Click_1(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        If OP1.Checked = True Then
            sql = "delete from BD_GROUPITEMMAIN "
        End If

        If OP2.Checked = True Then
            sql = "delete from BD_GroupItem1 "
        End If

        If OP3.Checked = True Then
            sql = "delete from BD_GroupItem2 "
        End If


        If op4.Checked = True Then
            sql = "delete from BD_Item "
        End If


        If op5.Checked = True Then
            sql = "delete from Statement_OfItem where TypeD =23 "
        End If

        rs = Cnn.Execute(sql)
        MsgBox("تم الحذف", MsgBoxStyle.Information, "css") : find_Data() : Exit Sub


    End Sub
End Class