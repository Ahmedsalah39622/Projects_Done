Public Class Frm_Splash_Sales

    Private Sub TileItem16_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick
        Frm_Main.Close()
        Frm_Main.Show()

        ' Frm_Splash_Sales.Close()

    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem17.ItemClick

        TileControl1.Visible = True


    End Sub

    Private Sub TileItem25_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem25.ItemClick
        TileControl1.Visible = False
    End Sub

    Private Sub TileItem26_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem26.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.saleswithcompanyname()
        Frm_Sales.ButtonItem60.ForeColor = Color.Blue
        Frm_Sales.ButtonItem60.FontBold = True
    End Sub

    Private Sub TileItem27_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem27.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.soldMaterials()
        Frm_Sales.ButtonItem61.ForeColor = Color.Blue
        Frm_Sales.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem28_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem28.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.TopsellingMaterials()
        Frm_Sales.ButtonItem1.ForeColor = Color.Blue
        Frm_Sales.ButtonItem1.FontBold = True
    End Sub

    Private Sub TileItem29_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem29.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.Salesreturns()
        Frm_Sales.ButtonItem2.ForeColor = Color.Blue
        Frm_Sales.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem30_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem30.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.MaterialsReturnedFromSales()
        Frm_Sales.ButtonItem4.ForeColor = Color.Blue
        Frm_Sales.ButtonItem4.FontBold = True
    End Sub

    Private Sub TileItem31_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem31.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.billsofsalesformaterials()
        Frm_Sales.ButtonItem5.ForeColor = Color.Blue
        Frm_Sales.ButtonItem5.FontBold = True
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem2.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.MaterialsReturnedFromSales()
        Frm_Sales.ButtonItem4.ForeColor = Color.Blue
        Frm_Sales.ButtonItem4.FontBold = True
    End Sub

    Private Sub TileControl2_Click(sender As Object, e As EventArgs) Handles TileControl2.Click

    End Sub

    Private Sub TileItem6_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem6.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.saleswithcompanyname()
        Frm_Sales.ButtonItem60.ForeColor = Color.Blue
        Frm_Sales.ButtonItem60.FontBold = True
    End Sub

    Private Sub TileItem7_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem7.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.billsofsalesformaterials()
        Frm_Sales.ButtonItem5.ForeColor = Color.Blue
        Frm_Sales.ButtonItem5.FontBold = True
    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem3.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.TopsellingMaterials()
        Frm_Sales.ButtonItem1.ForeColor = Color.Blue
        Frm_Sales.ButtonItem1.FontBold = True
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick
        TileControl2.Visible = False

    End Sub

    Private Sub TileItem4_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem4.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Sales.soldMaterials()
        Frm_Sales.ButtonItem61.ForeColor = Color.Blue
        Frm_Sales.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem5.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.Salesreturns()
        Frm_Sales.ButtonItem2.ForeColor = Color.Blue
        Frm_Sales.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem23_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem23.ItemClick
        TileControl2.Visible = True
    End Sub

    Private Sub TileItem19_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem19.ItemClick
        TileControl4.Visible = True
    End Sub

    Private Sub TileItem8_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem8.ItemClick
        TileControl4.Visible = False

    End Sub

    Private Sub TileItem9_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.MaterialsReturnedFromSales()
        Frm_Sales.ButtonItem4.ForeColor = Color.Blue
        Frm_Sales.ButtonItem4.FontBold = True
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.TopsellingMaterials()
        Frm_Sales.ButtonItem1.ForeColor = Color.Blue
        Frm_Sales.ButtonItem1.FontBold = True
    End Sub

    Private Sub TileItem13_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem13.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.saleswithcompanyname()
        Frm_Sales.ButtonItem60.ForeColor = Color.Blue
        Frm_Sales.ButtonItem60.FontBold = True
    End Sub

    Private Sub TileItem11_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem11.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.soldMaterials()
        Frm_Sales.ButtonItem61.ForeColor = Color.Blue
        Frm_Sales.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem12_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem12.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.Salesreturns()
        Frm_Sales.ButtonItem2.ForeColor = Color.Blue
        Frm_Sales.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem14_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem14.ItemClick
        Frm_Sales.Show()
        Frm_Sales.MdiParent = Mainmune ''To make it under the mainmenue page 

        Frm_Sales.billsofsalesformaterials()
        Frm_Sales.ButtonItem5.ForeColor = Color.Blue
        Frm_Sales.ButtonItem5.FontBold = True
    End Sub
End Class