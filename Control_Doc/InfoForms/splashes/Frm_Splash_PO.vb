Public Class Frm_Splash_PO

    Private Sub TileItem16_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick
        Frm_Main.Close()
        Frm_Main.Show()

        ' Frm_Splash_Sales.Close()

    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem17.ItemClick
        TileControl4.Visible = True

    End Sub

    Private Sub TileItem25_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem26_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem27_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem28_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem29_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem30_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem31_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileControl2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TileItem6_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem7_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)


    End Sub

    Private Sub TileItem4_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem23_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem23.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem19_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem19.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem8_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem8.ItemClick
        TileControl4.Visible = False

    End Sub

    Private Sub TileItem9_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        Frm_Report_PO.Show()
        Frm_Report_PO.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_PO.RawmateialsPO()
        Frm_Report_PO.ButtonItem61.ForeColor = Color.Blue
        Frm_Report_PO.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        Frm_Report_PO.Show()
        Frm_Report_PO.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_PO.RawmateialsPO()
        Frm_Report_PO.ButtonItem1.ForeColor = Color.Blue
        Frm_Report_PO.ButtonItem1.FontBold = True
   
    End Sub

    Private Sub TileItem13_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem11_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem12_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem12.ItemClick
        Frm_Report_PO.Show()
        Frm_Report_PO.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_PO.RawmateialsPO()
        Frm_Report_PO.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_PO.ButtonItem2.FontBold = True
 
    End Sub

    Private Sub TileItem14_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem15_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem15.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileControl4_Click(sender As Object, e As EventArgs) Handles TileControl4.Click

    End Sub
End Class