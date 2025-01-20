Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Drawing.Animation
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing

Public Class SplashDashbord
    Dim grp As New DevExpress.XtraEditors.TileGroup
    Dim aa As String

    Private Sub TileItem7_ItemClick(sender As Object, e As XtraEditors.TileItemEventArgs) Handles TileItem7.ItemClick
        'Frm_DashbordForCast.Show()
        'Frm_DashbordForCast.Close()
        'Frm_DashbordForCast.MdiParent = Me
        Frm_DashbordForCast.Show()
    End Sub

    


    
    Private Sub TileItem4_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem4.ItemClick
        TileControl2.Visible = True
        salseinfo()
    End Sub

    Sub salseinfo()

        sql = "   Select dbo.Emp_employees.Emp_Name, dbo.Emp_employees.Flg_emp " & _
            " FROM            dbo.Emp_employees INNER JOIN " & _
            "             dbo.St_CostCenterLv3Link_Salse ON dbo.Emp_employees.Emp_Code_Dirctorat = dbo.St_CostCenterLv3Link_Salse.Code_Diractorat "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF

            ''For i As Integer = 0 To 20
            Dim tile As New TileItem
            tile.Name = "tile_" & 1
            tile.AppearanceItem.Normal.BackColor = Color.DarkGray
            tile.AppearanceItem.Normal.ForeColor = Color.AntiqueWhite
            tile.AppearanceItem.Normal.Font = New Font("Verdana", 8, FontStyle.Bold)
            'tile.BackgroundImage = "F:\source\Base Maintenance\Personnel_Pic"

            tile.TextAlignment = TileItemContentAlignment.BottomCenter
            'tile.Text = "مندوب بيع " & i + 1
            'If tile.Text = "مندوب بيع 2" Then tile.AppearanceItem.Normal.BackColor = Color.DarkOrange
            'If tile.Text = "مندوب بيع 12" Then tile.AppearanceItem.Normal.BackColor = Color.Blue
            'If tile.Text = "مندوب بيع 15" Then tile.AppearanceItem.Normal.BackColor = Color.Brown
            'If tile.Text = "مندوب بيع 17" Then tile.AppearanceItem.Normal.BackColor = Color.Crimson
            'If tile.Text = "مندوب بيع 18" Then tile.AppearanceItem.Normal.BackColor = Color.Cornsilk
            'If tile.Text = "مندوب بيع 4" Then tile.AppearanceItem.Normal.BackColor = Color.ForestGreen
            If rs("Flg_emp").Value = 1 Then tile.AppearanceItem.Normal.BackColor = Color.ForestGreen
            tile.Text = rs("Emp_Name").Value

            'grp.Text = "osama"
            tile.ItemSize = TileItemSize.Default

            tile.ImageScaleMode = TileItemImageScaleMode.ZoomOutside
            tile.Image = Image.FromFile("E:\icon\179684.png")

            'tile.Image
            'tile.AppearanceItem
            'Dim bb As Integer
            'bb = tile.Id
            grp.Items.Add(tile)
            'aa = grp.Tag.GetType
            'aa = tile.Text
            'aa = TileControl1.Groups.Item(i + 1).Name + "aaa"
            'Dim myView As TileGroupViewInfo = (TryCast(TileControl1, ITileControl)).ViewInfo.Groups(0)
            'Dim myViewX As Integer = tile.Text
            'Dim myViewY As Integer = myView.TextBounds.Location.Y

            'aa = grp.Name

            'grp.Name = i & 1
            'Next
            Me.TileControl2.Groups.Add(grp)


            rs.MoveNext()
        Loop
    End Sub
    Public Sub New()
        InitializeComponent()
        TileControl2.ItemCheckMode = TileItemCheckMode.None
    End Sub
    Private Sub tileControl2_ItemClick(ByVal sender As Object, ByVal e As TileItemEventArgs) Handles TileControl2.ItemClick
        If e.Item.Checked = False Then
            Dim tileControl As TileControl = (TryCast(sender, TileControl))
            For g As Integer = 0 To tileControl.Groups.Count - 1
                For t As Integer = 0 To tileControl.Groups(g).Items.Count - 1
                    tileControl.Groups(g).Items(t).Checked = False
                Next t
            Next g
            e.Item.Checked = True
            'MsgBox(e.Item.Text)
            varnamesals = e.Item.Text
            Frm_ReportDelegate.txt_Name.Text = e.Item.Text
            TileControl3.Visible = True
            TileControl2.Visible = False
            'PictureBox1.Visible = True
        Else
            e.Item.Checked = False
        End If

        TileControl2.ItemCheckMode = TileItemCheckMode.None
    End Sub

    Private Sub TileItem10_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem10.ItemClick

    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As TileItemEventArgs)

    End Sub

    Private Sub TileControl3_Click(sender As Object, e As EventArgs) Handles TileControl3.Click

    End Sub

    Private Sub TileItem12_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem12.ItemClick
        TileControl4.Visible = True
        TileControl3.Visible = False
    End Sub

    Private Sub TileItem13_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem13.ItemClick
        TileControl4.Visible = False
        TileControl3.Visible = False
        TileControl2.Visible = False
        TileControl1.Visible = False
        TileControl5.Visible = True
    End Sub

    Private Sub TileItem19_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem19.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.visit()
        Frm_ReportDelegate.ButtonItem60.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem60.FontBold = True
        'SplashDashbord.MdiChildren
    End Sub

    Private Sub TileItem21_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem21.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.expenses()
        Frm_ReportDelegate.ButtonItem5.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem5.FontBold = True
    End Sub

    Private Sub TileItem22_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem22.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.regions()
        Frm_ReportDelegate.ButtonItem4.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem4.FontBold = True
    End Sub

    Private Sub TileItem20_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem20.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.KM()
        Frm_ReportDelegate.ButtonItem2.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem2.FontBold = True
    End Sub

    Private Sub TileItem17_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem17.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.totalbills()
        Frm_ReportDelegate.ButtonItem6.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem6.FontBold = True
    End Sub

    Private Sub TileControl6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TileItem24_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem24.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.salesMachine()
        Frm_ReportDelegate.ButtonItem61.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem61.FontBold = True
    End Sub

    Private Sub TileItem23_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem23.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.salesPart()
        Frm_ReportDelegate.ButtonItem1.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem1.FontBold = True
    End Sub

    Private Sub TileItem25_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem25.ItemClick

        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.returned()
        Frm_ReportDelegate.ButtonItem7.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem7.FontBold = True
    End Sub

    Private Sub TileItem26_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem26.ItemClick

        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.PO()
        Frm_ReportDelegate.ButtonItem8.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem8.FontBold = True
    End Sub

    Private Sub TileItem27_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem27.ItemClick
        Frm_ReportDelegate.Show()
        Frm_ReportDelegate.collectionOfDelegate()
        Frm_ReportDelegate.ButtonItem9.ForeColor = Color.Blue
        Frm_ReportDelegate.ButtonItem9.FontBold = True
    End Sub
End Class