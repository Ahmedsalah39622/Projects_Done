Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Lookup_Panel

    Private Sub Frm_Lookup_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Sub Search()

        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()



        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()


        If VarOpenlookup = 8080 Then
            sql2 = "SELECT  RefNO,DescripionItem,Brand,Type,Price,discount,totalM,code  FROM     Vw_Item_SCHNEIDER  "




        End If



        rs = Cnn.Execute(sql2)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"


        If VarOpenlookup = 8080 Then

            GridView1.Columns(0).Caption = "REF.NO"
            GridView1.Columns(1).Caption = "Descripion"
            GridView1.Columns(2).Caption = "Brand"
            GridView1.Columns(3).Caption = "Type"
            GridView1.Columns(4).Caption = "Price"
            GridView1.Columns(5).Caption = "discount"
            GridView1.Columns(6).Caption = "Total"
            GridView1.Columns(7).Caption = "CodeItem"
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(7).Visible = False
        End If

        GridView1.Columns(2).AppearanceCell.BackColor = Color.Black
        GridView1.Columns(2).AppearanceCell.ForeColor = Color.White

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True


        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()


    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle
        Dim value = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(0))
        Dim value2 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Dim value3 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Dim value4 = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))

        Frm_PanelsTechnicalspecifications.txt_RefNo.Text = value
        Frm_PanelsTechnicalspecifications.txt_Description.Text = value3
        Frm_PanelsTechnicalspecifications.txt_price.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_PanelsTechnicalspecifications.txt_Discount.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Frm_PanelsTechnicalspecifications.txt_total.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))
        varcode_item = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(7))
        varBrand = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(2))
        Me.Close()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        'For x As Integer = 0 To GridView1.RowCount



        '    Dim ststus_Stores As String
        '    Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        '    'حركة البيع
        '    '=======================================================================
        '    ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(3))
        '    If ststus_Stores = "SCHNEIDER" Then
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.SkyBlue
        '        End If
        '    Else
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.Gray
        '        End If
        '    End If
        '    '======================================================================================

        '    ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(3))
        '    If ststus_Stores = "ENCLOSURE" Then
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.GreenYellow
        '        End If
        '    Else
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.White
        '        End If
        '    End If
        '    '==============================================================

        '    ststus_Stores = GridView1.GetRowCellValue(x, GridView1.Columns(3))
        '    If ststus_Stores = "CONTROL" Then
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.Green
        '        End If
        '    Else
        '        If e.Column.AbsoluteIndex = 3 AndAlso e.RowHandle = x Then
        '            e.Appearance.BackColor = Color.Red
        '        End If
        '    End If
        'Next x





    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class