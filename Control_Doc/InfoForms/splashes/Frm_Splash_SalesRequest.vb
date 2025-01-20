Imports System.Data.OleDb

Public Class Frm_Splash_SalesRequest

    Private Sub TileItem16_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick
        TileControl3.Visible = False
        TileControl4.Visible = True
        ' Frm_Splash_Sales.Close()

    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem17.ItemClick
        Frm_Report_SalesRequest.Show()
        Frm_Report_SalesRequest.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Report_SalesRequest.find_StutasOrderItem_New()
        'Frm_Report_SalesRequest.PartsRequests()
        Frm_Report_SalesRequest.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_SalesRequest.ButtonItem2.FontBold = True

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

  
    Private Sub TileItem12_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem12.ItemClick

        TileControl3.Visible = True
        TileControl4.Visible = False

       
    End Sub

    Private Sub TileItem14_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem15_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem15.ItemClick
        Frm_Report_SalesRequest.Show()
        Frm_Report_SalesRequest.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Report_SalesRequest.find_StutasOrderItem_New()
        'Frm_Report_SalesRequest.PartsRequests()
        Frm_Report_SalesRequest.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_SalesRequest.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem19_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem19.ItemClick
        Frm_Report_SalesRequest.Show()
        Frm_Report_SalesRequest.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Report_SalesRequest.find_StutasOrderItem_New()
        'Frm_Report_SalesRequest.PartsRequests()
        Frm_Report_SalesRequest.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_SalesRequest.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem23_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem23.ItemClick
        Frm_Report_SalesRequest.Show()
        Frm_Report_SalesRequest.MdiParent = Mainmune ''To make it under the mainmenue page 
        Frm_Report_SalesRequest.find_StutasOrderItem_New()
        'Frm_Report_SalesRequest.PartsRequests()
        Frm_Report_SalesRequest.ButtonItem2.ForeColor = Color.Blue
        Frm_Report_SalesRequest.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        TileControl3.Visible = True
        TileControl4.Visible = False
    End Sub

    Private Sub TileItem9_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        TileControl3.Visible = True
        TileControl4.Visible = False
    End Sub

    Private Sub TileItem8_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem8.ItemClick

        Frm_Main.MdiParent = Mainmune
        Frm_Main.Show()
        Me.Close()
    End Sub
End Class