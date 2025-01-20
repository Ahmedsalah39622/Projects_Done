Imports System.Data.OleDb
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class Frm_LookupMatril
    Sub Search()



        If varCodeConnaction = 1 Then '======Sql

            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
                   "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()


            sql2 = "select No_Matril,Name,Batch_No,TypeMatril,Balance,unit,Stores  from Vw_MatrilAll where Compny_Code ='" & VarCodeCompny & "' "


            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"

            GridView1.Columns(0).Caption = "رقم المادة"
            GridView1.Columns(1).Caption = "أسم المادة"
            GridView1.Columns(2).Caption = "رقم الباتش"
            GridView1.Columns(3).Caption = "نوع المادة الخام"
            GridView1.Columns(4).Caption = "الرصيد"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "المخزن"

            GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
            GridView1.Appearance.Row.Options.UseFont = True

            GridView1.Columns(0).Width = "100"
            GridView1.Columns(1).Width = "200"
            GridView1.Columns(2).Width = "100"
            GridView1.Columns(3).Width = "150"
            GridView1.Columns(4).Width = "100"
            GridView1.Columns(5).Width = "100"
            GridView1.Columns(6).Width = "150"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If

        If varCodeConnaction = 2 Then '======Oracle
            Dim ss As String
            Dim con As New OleDb.OleDbConnection
            ss = " Provider=OraOLEDB.Oracle;Data Source=test;User Id=" & varusername2 & ";Password=" & varPassword & ";"
            con.ConnectionString = ss
            con.Open()

            sql2 = "select No_Matril,Name,Batch_No,TypeMatril,Balance,unit,Stores  from Vw_MatrilAll where Compny_Code ='" & VarCodeCompny & "' "


            rs = Cnn.Execute(sql2)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql2, con)
            'create a new dataset
            Dim ds As New DataSet()
            'fill the datset
            da.Fill(ds)
            GridControl1.DataSource = ds.Tables(0)
            'GridColumn1.Caption = "d"

            GridView1.Columns(0).Caption = "رقم المادة"
            GridView1.Columns(1).Caption = "أسم المادة"
            GridView1.Columns(2).Caption = "رقم الباتش"
            GridView1.Columns(3).Caption = "نوع المادة الخام"
            GridView1.Columns(4).Caption = "الرصيد"
            GridView1.Columns(5).Caption = "الوحدة"
            GridView1.Columns(6).Caption = "المخزن"


            GridView1.Columns(0).Width = "100"
            GridView1.Columns(1).Width = "100"
            GridView1.Columns(2).Width = "100"
            GridView1.Columns(3).Width = "200"
            GridView1.Columns(4).Width = "70"
            GridView1.Columns(5).Width = "100"

            ds = Nothing
            da = Nothing
            con.Close()
            con.Dispose()
        End If
    End Sub
    Private Sub GridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs) Handles GridView1.CalcRowHeight
        'Dim view As GridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.RowHandle >= 0 Then
        '    e.RowHeight = view.GetDataRow(e.RowHandle)("RowHeight")
        GridView1.RowHeight = 20
        GridView1.GroupRowHeight = 1
        GridView1.RowSeparatorHeight = 1
        'GridView1.GroupRowHeight = 1

        'End If
    End Sub
    Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As GridView)
        Dim visibleRowHandle As Integer = gridView.FocusedRowHandle


        gridView.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually 
        AddHandler gridView.CustomDrawRowIndicator, Sub(s, e)
                                                        If Not e.Info.IsRowIndicator Then
                                                            Return
                                                        End If
                                                        Dim view As GridView = TryCast(s, GridView)
                                                        e.Handled = True

                                                        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
                                                        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
                                                        If e.Info.ImageIndex < 0 Then
                                                            Return
                                                        End If
                                                        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
                                                        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
                                                        'e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
                                                    End Sub
    End Sub

    Private Sub Frm_LookupMatril_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub


    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim visibleRowHandle As Integer = GridView1.FocusedRowHandle

        Frm_ProudactionOrder.txt_MatrilName.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(1))
        Frm_ProudactionOrder.txt_Unit2.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(5))
        Frm_ProudactionOrder.txt_QtyAvalibl.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(4))
        Frm_ProudactionOrder.txt_NameStores.Text = GridView1.GetRowCellValue(visibleRowHandle, GridView1.Columns(6))

        Me.Close()
    End Sub
End Class