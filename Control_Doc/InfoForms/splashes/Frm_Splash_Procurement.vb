Public Class Frm_Splash_Procurement

    Private Sub TileItem8_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem8.ItemClick
        TileControl4.Visible = False

    End Sub

    Private Sub TileItem9_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.DayliyProcurement()
        Frm_Report_Procurement.ButtonItem60.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem60.FontBold = True
    End Sub

    Private Sub TileItem16_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick
        Frm_Main.Close()
        Frm_Main.Show()
    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem17.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem23_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem23.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem19_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem19.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.DailyPO()
        Frm_Report_Procurement.ButtonItem61.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem11_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem11.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.ItemToPurchase()
        Frm_Report_Procurement.ButtonItem1.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem1.FontBold = True
    End Sub

    Private Sub TileItem12_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem12.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.Supplierpayments()
        Frm_Report_Procurement.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem13_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem13.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.PoAndDeliveryTime()
        Frm_Report_Procurement.ButtonItem4.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem4.FontBold = True
    End Sub

    Private Sub TileItem14_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem14.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.OrdersOfDeligates()
        Frm_Report_Procurement.ButtonItem5.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem5.FontBold = True
    End Sub

   

   
    Private Sub TileItem4_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem4.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Report_Procurement.RelatedItemsWithSupplier()
        Frm_Report_Procurement.ButtonItem7.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem7.FontBold = True
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick
        Frm_Report_Procurement.Show()
        Frm_Report_Procurement.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Report_Procurement.OrderOfGM()
        Frm_Report_Procurement.ButtonItem6.ForeColor = Color.Blue
        Frm_Report_Procurement.ButtonItem6.FontBold = True
    End Sub

    Private Sub TileControl3_Click(sender As Object, e As EventArgs) Handles TileControl3.Click

    End Sub
End Class