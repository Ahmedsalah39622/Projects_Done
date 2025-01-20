Imports System.Data.OleDb

Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Windows.Controls
Imports DevExpress.XtraGrid.Columns

Public Class Frm_Lookup

    Sub Search()
        On Error Resume Next

        Dim con As New OleDb.OleDbConnection
        Dim ss As String
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                    "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        sql = "SELECT  Name,Description FROM  " & vartable & "   "




        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        'attach dataset to the datagrid


        GridControl3.DataSource = ds.Tables(0)




        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()
    End Sub
   
    Private Sub Frm_Lookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
      
    End Sub

    Private Sub GridControl3_ControlAdded(sender As Object, e As ControlEventArgs) Handles GridControl3.ControlAdded
      
    End Sub



    Private Sub GridControl3_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl3.MouseClick
        'On Error Resume Next
        'Dim con As New SqlConnection("Data Source= osama ; Initial Catalog= DB_MP ; user id=sa ; password= omar2007")
        'Dim com As SqlCommand
        'Dim datatable As New DataTable
        'con.Open()
        'com = New SqlCommand("SELECT  Name,Description FROM  " & vartable & "", con)
        'datatable.Load(com.ExecuteReader)
        'GridControl3.DataSource = datatable
        'GridControl3.DataMember = datatable.TableName
        'con.Close()


        'If NoForm = 1 Then
        '    Frm_AircraftConfacrtion.txt_AcType.DataBindings.Clear()
        '    Frm_AircraftConfacrtion.txt_AC_Discraption.DataBindings.Clear()
        '    Frm_AircraftConfacrtion.txt_AcType.DataBindings.Add(New Binding("text", datatable, "Name"))
        '    Frm_AircraftConfacrtion.txt_AC_Discraption.DataBindings.Add(New Binding("text", datatable, "Description"))
        'End If

        'If NoForm = 2 Then
        '    Frm_AircraftConfacrtion.txt_APU.DataBindings.Clear()
        '    Frm_AircraftConfacrtion.txt_APU_Discraption.DataBindings.Clear()
        '    Frm_AircraftConfacrtion.txt_APU.DataBindings.(New Binding("text", datatable, "Name"))
        '    Frm_AircraftConfacrtion.txt_APU_Discraption.DataBindings.Add(New Binding("text", datatable, "Description"))
        'End If
        ''GridControl3.Select(DataColumn)
        'Me.Close()

        'Dim con As New SqlConnection("Data Source= osama ; Initial Catalog= DB_MP ; user id=sa ; password= omar2007")
        'Dim com As SqlCommand
        'Dim datatable As New DataTable
        'con.Open()
        'com = New SqlCommand("SELECT  Name,Description FROM  " & vartable & "", con)
        'datatable.Load(com.ExecuteReader)
        'GridControl3.DataSource = datatable
        'GridControl3.DataMember = datatable.TableName
        'con.Close()


        'Frm_AircraftConfacrtion.txt_AcType.DataBindings.Clear()
        'Frm_AircraftConfacrtion.txt_AC_Discraption.DataBindings.Clear()

        ''Com_Code.DataBindings.Add(New Binding("text", datatable, "Code"))
        ''Frm_AircraftConfacrtion.txt_AcType.DataBindings.Item = datatable.Clear
        'Frm_AircraftConfacrtion.txt_AC_Discraption.DataBindings.Add(New Binding("text", datatable, "Description"))
        'Me.GridControl3.FocusedRowHandle = 2
        'Me.GridControl3.SelectRow(2)
        'Me.Close()
        'Dim x As String
        'x = GridView4.ro
    End Sub

   

   


    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        If NoSerailcolume = 1 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_DataItem.txt_AcType.Text = value
            'Frm_DataItem.txt_AC_Discraption.Text = value2
        End If

        If NoSerailcolume = 2 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_DataItem.txt_ACModel.Text = value
            'Frm_DataItem.txt_Dis_AC_model.Text = value2
        End If

        If NoSerailcolume = 3 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_DataItem.txt_NameEnginetype.Text = value
            'Frm_DataItem.txt_Dis_EngineType.Text = value2
        End If

        If NoSerailcolume = 4 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.txt_APU.Text = value
            'Frm_DataItem.txt_APU_Discraption.Text = value2
        End If


        If NoSerailcolume = 5 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.txt_ownerName.Text = value
            'Frm_ScanData.txt_Dis_ownar.Text = value2
        End If

        If NoSerailcolume = 6 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.txt_opertorName.Text = value
            'Frm_ScanData.txt_operatorDis.Text = value2
        End If

        If NoSerailcolume = 7 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.TXT_AUTHIORTYNAME.Text = value
            'Frm_ScanData.TXT_AUTHIORTYNAME_DIS.Text = value2
        End If

        If NoSerailcolume = 8 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.txt_nameManufacture.Text = value
            'Frm_ScanData.txt_ManufactuerDis.Text = value2
        End If

        If NoSerailcolume = 9 Then
            Dim value As String = GridView4.GetFocusedRowCellValue("Name").ToString()
            Dim value2 As String = GridView4.GetFocusedRowCellValue("Description").ToString()
            'Frm_ScanData.txt_objectType.Text = value
            'Frm_ScanData.TextBox24.Text = value2
        End If


        Me.Close()
    End Sub

  
    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub
End Class