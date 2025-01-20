Imports System.Data.OleDb

Public Class Frm_Lookup_Etmad

    Private Sub Frm_Lookup_Etmad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Find_all()
    End Sub
    Sub Find_all()
        On Error Resume Next


        'sql = " select Code_Etmad,NoDftr_Etmad,StrDate_Etmad,EndDate_Etmad,Date_Ariver,NameSuppliser,AccountNoBank_Suppliser,AccountName,NoShipping,NotesShipping from  Vw_EatmadData where Compny_Code ='" & VarCodeCompny & "' "


        sql = "  SELECT        dbo.Vw_EatmadData.Code_Etmad, dbo.Vw_EatmadData.NoDftr_Etmad, dbo.Vw_EatmadData.StrDate_Etmad, dbo.Vw_EatmadData.NameSuppliser, dbo.Vw_EatmadData.AccountNoBank_Suppliser, dbo.Vw_EatmadData.AccountName, " & _
  "                         dbo.Vw_EatmadData.NoShipping, dbo.TB_Detils_PO2.No_Item, dbo.BD_Item.Name, dbo.TB_Detils_PO2.Quntity, dbo.BD_Unit.Name AS Unit, dbo.TB_Detils_PO2.Price_Item, dbo.BD_Currency.Name AS Cru, " & _
  "        dbo.TB_Detils_PO2.Rat, dbo.TB_Detils_PO2.Total_Item " & _
  " FROM            dbo.Vw_EatmadData INNER JOIN " & _
  "                         dbo.TB_Detils_PO2 ON dbo.Vw_EatmadData.Code_Etmad = dbo.TB_Detils_PO2.Code_Etmad AND dbo.Vw_EatmadData.Compny_Code = dbo.TB_Detils_PO2.Compny_Code INNER JOIN " & _
  "                         dbo.BD_Item ON dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Item.Compny_Code AND dbo.TB_Detils_PO2.No_Item = dbo.BD_Item.Code INNER JOIN " & _
  "                         dbo.BD_Unit ON dbo.TB_Detils_PO2.Code_Unit = dbo.BD_Unit.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Unit.Compny_Code INNER JOIN " & _
  "                         dbo.BD_Currency ON dbo.TB_Detils_PO2.Code_Cur = dbo.BD_Currency.Code AND dbo.TB_Detils_PO2.Compny_Code = dbo.BD_Currency.Compny_Code " & _
  " WHERE        (dbo.Vw_EatmadData.Compny_Code = '" & VarCodeCompny & "') "




        Dim ss As String
        Dim con As New OleDb.OleDbConnection
        ss = "Provider=SQLOLEDB;Initial Catalog= " & DatabaseName & " ;Data Source=" & ServerName & ";" & _
               "User ID=" & varusername2 & " ;Password=" & varPassword & ";"
        con.ConnectionString = ss
        con.Open()

        rs = Cnn.Execute(sql)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, con)
        'create a new dataset
        Dim ds As New DataSet()
        'fill the datset
        da.Fill(ds)
        GridControl1.DataSource = ds.Tables(0)
        'GridColumn1.Caption = "d"
        GridView1.Columns(0).Caption = "رقم الاعتماد"
        GridView1.Columns(1).Caption = "الرقم الدفترى"
        GridView1.Columns(2).Caption = "تاريخ الاعتماد"   
        GridView1.Columns(3).Caption = "المورد"
        GridView1.Columns(4).Caption = "بنك المورد"
        GridView1.Columns(5).Caption = "بنك الاعتماد"
        GridView1.Columns(6).Caption = "رقم الشحنة"
        GridView1.Columns(7).Caption = "رقم الصنف"
        GridView1.Columns(8).Caption = "أسم الصنف"
        GridView1.Columns(9).Caption = "الكمية"
        GridView1.Columns(10).Caption = "الوحدة"
        GridView1.Columns(11).Caption = "السعر"
        GridView1.Columns(12).Caption = "العملة"
        GridView1.Columns(13).Caption = "معامل التحويل"
        GridView1.Columns(14).Caption = "الاجمالى"






        GridView1.Columns(6).AppearanceCell.BackColor = Color.DarkGray
        GridView1.Columns(6).AppearanceCell.ForeColor = Color.Red

       

        GridView1.Appearance.Row.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns(0).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        GridView1.BestFitColumns()

        ds = Nothing
        da = Nothing
        con.Close()
        con.Dispose()





    End Sub
End Class