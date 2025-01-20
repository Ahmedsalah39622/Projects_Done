Public Class Frm_Main
    Private Sub TileItem7_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem2_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem15_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem18_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem2_ItemClick_2(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem2.ItemClick, TileItem25.ItemClick
        Frm_Splash_Procurement.Close()
        Frm_Splash_Procurement.MdiParent = Mainmune
        Frm_Splash_Procurement.Show()

    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick, TileItem26.ItemClick
        Frm_Splash_Sales.Close()
        Frm_Splash_Sales.MdiParent = Mainmune
        Frm_Splash_Sales.Show()


        'Form2.Close()
        'Form2.TileControl3.Show()

    End Sub

    Private Sub TileControl1_Click(sender As Object, e As EventArgs) Handles TileControl10.Click, TileControl5.Click

    End Sub

    Private Sub TileItem12_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem12.ItemClick, TileItem30.ItemClick
        TileControl4.Visible = True

    End Sub

    Private Sub TileItem7_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem7.ItemClick, TileItem10.ItemClick
        TileControl2.Visible = False
    End Sub

    Private Sub TileItem16_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        '   TileControl3.Visible = False
    End Sub

    Private Sub TileControl3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TileItem18_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem18.ItemClick, TileItem6.ItemClick
        TileControl4.Visible = False
    End Sub

    Private Sub TileControl2_Click(sender As Object, e As EventArgs) Handles TileControl2.Click, TileControl3.Click

    End Sub

    Private Sub TileItem16_ItemClick_1(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem17.ItemClick, TileItem28.ItemClick
        Frm_Splash_SalesRequest.Close()
        Frm_Splash_SalesRequest.MdiParent = Mainmune
        Frm_Splash_SalesRequest.Show()

    End Sub

    Private Sub TileItem16_ItemClick_2(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick, TileItem27.ItemClick
        Frm_Splash_PO.Close()
        Frm_Splash_PO.MdiParent = Mainmune

        Frm_Splash_PO.Show()

    End Sub

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TileItem6_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem3.ItemClick, TileItem29.ItemClick
        SplashDashbord.Close()
        'SplashDashbord.MdiParent = Me
        SplashDashbord.Show()

    End Sub
End Class