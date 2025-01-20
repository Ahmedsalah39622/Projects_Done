Imports System.Data.OleDb
Imports System.IO

Public Class Frm_CustomerFiles
    Dim Varcode_Customer As Integer
    Dim VarName_Customer As String
    Private Sub Frm_CustomerFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Customer()
    End Sub
    Sub fill_Customer()
        sql2 = "   SELECT dbo.tb_CustomerProjects.Customer_Code, dbo.St_CustomerData.Customer_Name " & _
   " FROM     dbo.tb_CustomerProjects INNER JOIN " & _
   "                  dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code " & _
   " GROUP BY dbo.tb_CustomerProjects.Customer_Code, dbo.St_CustomerData.Customer_Name "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl3.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView4.Columns(0).Caption = "Customer Code"
        GridView4.Columns(1).Caption = "Customer Name"


        GridView4.Appearance.Row.Font = New Font(GridView4.Appearance.Row.Font, FontStyle.Bold)
        GridView4.Appearance.Row.Options.UseFont = True
        GridView4.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        GridView4.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'End If

    End Sub

    Sub fill_ProjectCustomer()
        sql2 = " SELECT dbo.ST_CHARTCOSTCENTER.Account_No, RTRIM(dbo.ST_CHARTCOSTCENTER.AccountName) AS Project_Name " & _
 "FROM     dbo.tb_CustomerProjects INNER JOIN " & _
 "                  dbo.St_CustomerData ON dbo.tb_CustomerProjects.Customer_Code = dbo.St_CustomerData.Customer_Code INNER JOIN " & _
 "                  dbo.ST_CHARTCOSTCENTER ON dbo.tb_CustomerProjects.CostCenter_MainCode = dbo.ST_CHARTCOSTCENTER.Account_No " & _
 " GROUP BY dbo.tb_CustomerProjects.Customer_Code, dbo.St_CustomerData.Customer_Name, dbo.ST_CHARTCOSTCENTER.AccountName, dbo.ST_CHARTCOSTCENTER.Account_No " & _
 "        HAVING(dbo.tb_CustomerProjects.Customer_Code = '" & Varcode_Customer & "') "

        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl2.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView3.Columns(0).Caption = "Project Code"
        GridView3.Columns(1).Caption = "Project Name"


        GridView3.Appearance.Row.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count



        GridView3.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
        'End If
    End Sub



    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Dim visibleRowHandle As Integer = GridView4.FocusedRowHandle
        Varcode_Customer = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(0))
        VarName_Customer = GridView4.GetRowCellValue(visibleRowHandle, GridView4.Columns(1))
        Lab_Customer.Text = VarName_Customer
        fill_ProjectCustomer()
    End Sub



    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Dim visibleRowHandle As Integer = GridView3.FocusedRowHandle
        Lab_Project.Text = GridView3.GetRowCellValue(visibleRowHandle, GridView3.Columns(1))
        loadlistbox()
    End Sub

    Private Sub Cmd_OpenFile_Click(sender As Object, e As EventArgs)
      
        'Dim FileName As String = OpenFileDialog.FileName
        'MessageBox.Show(OpenFileDialog.FileName)
        'txt_OpenFile.Text = OpenFileDialog.FileName
        'Process.Start(OpenFileDialog.FileName)
        'End If
    End Sub


    Private Sub Cmd_OpenFilsPdf_Click(sender As Object, e As EventArgs)

     

    End Sub
    Sub loadlistbox()
        On Error Resume Next
        ListBoxControl1.Items.Clear()
        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text
        '=======================================================================
        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + VarName_Customer
        Dim Dir2 As String = Dir1 + "\" + Lab_Project.Text + "\" + varcaption
        Dim Dir3 As String = Dir2
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Dir3)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory

        For Each dra In diar1
            ListBoxControl1.Items.Add(dra)
        Next
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub




    Private Sub ListBoxControl1_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxControl1.DoubleClick
        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text
        '=======================================================================


        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + VarName_Customer
        Dim Dir2 As String = Dir1 + "\" + Lab_Project.Text + "\" + varcaption
        Dim Dir3 As String = Dir2
        Dim Dir4 As String = Trim(Dir3) + "\" + ListBoxControl1.Text
        Me.PdfViewer1.LoadDocument(Dir4)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_OpenFile_Click_1(sender As Object, e As EventArgs) Handles Cmd_OpenFile.Click
        Dim OpenFileDialog As New OpenFileDialog

        If Op1.Checked = False And Op2.Checked = False And Op3.Checked = False Then MsgBox("من فضلك أختار نوع الملف", MsgBoxStyle.Critical, "CSS") : Exit Sub


        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "PDF Files (*.pdf) |*.pdf|All Files (*.*)|*.*"

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

            'If txt_OpenFile.Text = "" Then
            '    MessageBox.Show("قم بأختيار PAO")
            'Else
            ' Directions For Upload Solution

            If Op1.Checked = True Then varcaption = Op1.Text
            If Op2.Checked = True Then varcaption = Op2.Text
            If Op3.Checked = True Then varcaption = Op3.Text


            Dim Dir As String = "\\server\CSS2021"
            Dim Dir1 As String = Dir + "\" + VarName_Customer
            Dim Dir2 As String = Dir1 + "\" + Lab_Project.Text + "\" + varcaption
            Dim Dir3 As String = Dir2
            ' Get Folder Path UploadFiles
            If (Not System.IO.Directory.Exists(Dir1)) Then
                System.IO.Directory.CreateDirectory(Dir1)
            End If
            ' Get Folder Path أوامر التوريد
            If (Not System.IO.Directory.Exists(Dir2)) Then
                System.IO.Directory.CreateDirectory(Dir2)
            End If
            ' Get Folder Path كود أمر التوريد
            If (Not System.IO.Directory.Exists(Dir3)) Then
                System.IO.Directory.CreateDirectory(Dir3)
            End If
            ' Copy File To New Path
            My.Computer.FileSystem.CopyFile(OpenFileDialog.FileName, Dir3 + "\" + OpenFileDialog.SafeFileName, overwrite:=False)
            MessageBox.Show("تم حفظ الملف بنجاح")
        End If

    End Sub

    Private Sub Cmd_OpenFilsPdf_Click_1(sender As Object, e As EventArgs) Handles Cmd_OpenFilsPdf.Click
        '' Directions For Upload Solution
        'Dim Dir As String = "\\192.168.1.7"
        'Dim Dir1 As String = Dir + "\" + VarName_Customer
        'Dim Dir2 As String = Dir1 + "\" + Lab_Project.Text
        'Dim Dir3 As String = Dir2
        '' Get Folder Path UploadFiles
        'If (Not System.IO.Directory.Exists(Dir1)) Then
        '    System.IO.Directory.CreateDirectory(Dir1)
        'End If
        '' Get Folder Path أوامر التوريد
        'If (Not System.IO.Directory.Exists(Dir2)) Then
        '    System.IO.Directory.CreateDirectory(Dir2)
        'End If
        '' Get Folder Path كود أمر التوريد
        'If (Not System.IO.Directory.Exists(Dir3)) Then
        '    System.IO.Directory.CreateDirectory(Dir3)
        'End If
        'Process.Start(Dir3 + "\")
        loadlistbox()
    End Sub

    Private Sub Cmd_Delete_Click_1(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        On Error Resume Next


        If Op1.Checked = True Then varcaption = Op1.Text
        If Op2.Checked = True Then varcaption = Op2.Text
        If Op3.Checked = True Then varcaption = Op3.Text
        '=======================================================================


        Dim Dir As String = "\\server\CSS2021"
        Dim Dir1 As String = Dir + "\" + VarName_Customer
        Dim Dir2 As String = Dir1 + "\" + Lab_Project.Text + "\" + varcaption
        Dim Dir3 As String = Dir2 + "\" + ListBoxControl1.Text


        System.IO.File.Delete(Dir3)

        MessageBox.Show("تم حذف الملف بنجاح")
        loadlistbox()
    End Sub

    Private Sub ListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl1.SelectedIndexChanged

    End Sub

    Private Sub Op1_CheckedChanged(sender As Object, e As EventArgs) Handles Op1.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub Op3_CheckedChanged(sender As Object, e As EventArgs) Handles Op3.CheckedChanged
        loadlistbox()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub
End Class