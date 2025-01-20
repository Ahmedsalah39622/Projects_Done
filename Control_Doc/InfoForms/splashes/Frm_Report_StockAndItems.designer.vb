<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Report_StockAndItems
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Report_StockAndItems))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView5 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView5 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView3 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView6 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CardView6 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ExplorerBar1 = New DevComponents.DotNetBar.ExplorerBar()
        Me.ExplorerBarGroupItem2 = New DevComponents.DotNetBar.ExplorerBarGroupItem()
        Me.ButtonItem60 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem61 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ExplorerBarGroupItem3 = New DevComponents.DotNetBar.ExplorerBarGroupItem()
        Me.ButtonItem50 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem56 = New DevComponents.DotNetBar.ButtonItem()
        Me.ExplorerBarGroupItem1 = New DevComponents.DotNetBar.ExplorerBarGroupItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TabPane1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.AutoScroll = True
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1362, 606)
        Me.SplitContainerControl1.SplitterPosition = 1061
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPane1.Location = New System.Drawing.Point(0, 0)
        Me.TabPane1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1061, 606)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.SelectedPageIndex = 0
        Me.TabPane1.Size = New System.Drawing.Size(1061, 606)
        Me.TabPane1.TabIndex = 4
        Me.TabPane1.TransitionType = DevExpress.Utils.Animation.Transitions.Clock
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.AutoScroll = True
        Me.TabNavigationPage1.Caption = "بحث"
        Me.TabNavigationPage1.Controls.Add(Me.Panel2)
        Me.TabNavigationPage1.Image = CType(resources.GetObject("TabNavigationPage1.Image"), System.Drawing.Image)
        Me.TabNavigationPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1043, 558)
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.GridControl3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1043, 558)
        Me.Panel2.TabIndex = 0
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        GridLevelNode2.RelationName = "Level2"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1, GridLevelNode2})
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView6
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1043, 558)
        Me.GridControl3.TabIndex = 6
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6, Me.BandedGridView5, Me.CardView5, Me.GridView7, Me.BandedGridView6, Me.WinExplorerView5, Me.TileView3, Me.WinExplorerView6, Me.AdvBandedGridView3, Me.CardView6})
        '
        'GridView6
        '
        Me.GridView6.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GridView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView6.GridControl = Me.GridControl3
        Me.GridView6.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, Nothing, Nothing, "(Name: Count={0})")})
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView6.OptionsBehavior.Editable = False
        Me.GridView6.OptionsBehavior.ReadOnly = True
        Me.GridView6.OptionsFilter.AllowColumnMRUFilterList = False
        Me.GridView6.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.GridView6.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.TextAndVisual
        Me.GridView6.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView6.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView6.OptionsFind.AlwaysVisible = True
        Me.GridView6.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView6.OptionsView.ShowFooter = True
        '
        'BandedGridView5
        '
        Me.BandedGridView5.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand7})
        Me.BandedGridView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView5.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn3, Me.BandedGridColumn4})
        Me.BandedGridView5.GridControl = Me.GridControl3
        Me.BandedGridView5.Name = "BandedGridView5"
        Me.BandedGridView5.OptionsView.ShowGroupPanel = False
        '
        'GridBand7
        '
        Me.GridBand7.Caption = "GridBand2"
        Me.GridBand7.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand7.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand7.Name = "GridBand7"
        Me.GridBand7.VisibleIndex = 0
        Me.GridBand7.Width = 150
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "aa"
        Me.BandedGridColumn3.FieldName = "Name"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.FieldName = "Description"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'CardView5
        '
        Me.CardView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6})
        Me.CardView5.FocusedCardTopFieldIndex = 0
        Me.CardView5.GridControl = Me.GridControl3
        Me.CardView5.Name = "CardView5"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "aa"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "bb"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.GridControl3
        Me.GridView7.Name = "GridView7"
        Me.GridView7.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView6
        '
        Me.BandedGridView6.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand8})
        Me.BandedGridView6.GridControl = Me.GridControl3
        Me.BandedGridView6.Name = "BandedGridView6"
        '
        'GridBand8
        '
        Me.GridBand8.Caption = "GridBand1"
        Me.GridBand8.Name = "GridBand8"
        Me.GridBand8.VisibleIndex = 0
        '
        'WinExplorerView5
        '
        Me.WinExplorerView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.WinExplorerView5.GridControl = Me.GridControl3
        Me.WinExplorerView5.Name = "WinExplorerView5"
        '
        'TileView3
        '
        Me.TileView3.GridControl = Me.GridControl3
        Me.TileView3.Name = "TileView3"
        '
        'WinExplorerView6
        '
        Me.WinExplorerView6.GridControl = Me.GridControl3
        Me.WinExplorerView6.Name = "WinExplorerView6"
        '
        'AdvBandedGridView3
        '
        Me.AdvBandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand9})
        Me.AdvBandedGridView3.GridControl = Me.GridControl3
        Me.AdvBandedGridView3.Name = "AdvBandedGridView3"
        '
        'GridBand9
        '
        Me.GridBand9.Caption = "GridBand3"
        Me.GridBand9.Name = "GridBand9"
        Me.GridBand9.VisibleIndex = 0
        '
        'CardView6
        '
        Me.CardView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView6.FocusedCardTopFieldIndex = 0
        Me.CardView6.GridControl = Me.GridControl3
        Me.CardView6.Name = "CardView6"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ExplorerBar1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(296, 606)
        Me.Panel4.TabIndex = 0
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.ExplorerBar1.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.ExplorerBar1.BackStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ExplorerBar1.BackStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ExplorerBar1.BackStyle.BackColorGradientAngle = 90
        Me.ExplorerBar1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBar1.ColorScheme.BarBackground = System.Drawing.Color.LightGray
        Me.ExplorerBar1.ColorScheme.BarBackground2 = System.Drawing.Color.SkyBlue
        Me.ExplorerBar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.GroupImages = Nothing
        Me.ExplorerBar1.Groups.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ExplorerBarGroupItem2, Me.ExplorerBarGroupItem3, Me.ExplorerBarGroupItem1})
        Me.ExplorerBar1.Images = Nothing
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(296, 606)
        Me.ExplorerBar1.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SilverSpecial
        Me.ExplorerBar1.TabIndex = 13
        Me.ExplorerBar1.Text = "ExplorerBar1"
        '
        'ExplorerBarGroupItem2
        '
        '
        '
        '
        Me.ExplorerBarGroupItem2.BackStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ExplorerBarGroupItem2.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem2.BackStyle.BorderBottomWidth = 1
        Me.ExplorerBarGroupItem2.BackStyle.BorderColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem2.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem2.BackStyle.BorderLeftWidth = 1
        Me.ExplorerBarGroupItem2.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem2.BackStyle.BorderRightWidth = 1
        Me.ExplorerBarGroupItem2.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem2.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExplorerBarGroupItem2.Expanded = True
        Me.ExplorerBarGroupItem2.Name = "ExplorerBarGroupItem2"
        Me.ExplorerBarGroupItem2.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SilverSpecial
        Me.ExplorerBarGroupItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem60, Me.ButtonItem61, Me.ButtonItem1, Me.ButtonItem2, Me.ButtonItem4, Me.ButtonItem5, Me.ButtonItem6, Me.ButtonItem7, Me.ButtonItem8})
        Me.ExplorerBarGroupItem2.Text = "تنبيهات هامة"
        '
        '
        '
        Me.ExplorerBarGroupItem2.TitleHotStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem2.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem2.TitleHotStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem2.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem2.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem2.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem2.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        '
        '
        '
        Me.ExplorerBarGroupItem2.TitleStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem2.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem2.TitleStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem2.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem2.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem2.TitleStyle.TextColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem2.XPSpecialGroup = True
        '
        'ButtonItem60
        '
        Me.ButtonItem60.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem60.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem60.HotFontUnderline = True
        Me.ButtonItem60.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem60.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem60.Image = Global.Control_Doc.My.Resources.Resources.Copy1
        Me.ButtonItem60.Name = "ButtonItem60"
        Me.ButtonItem60.Text = "جرد المخازن مجمعة"
        '
        'ButtonItem61
        '
        Me.ButtonItem61.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem61.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem61.HotFontUnderline = True
        Me.ButtonItem61.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem61.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem61.Image = Global.Control_Doc.My.Resources.Resources.Email_App_Icon
        Me.ButtonItem61.Name = "ButtonItem61"
        Me.ButtonItem61.Text = "جرد المخازن كمية وقيمة"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem1.HotFontUnderline = True
        Me.ButtonItem1.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem1.Image = Global.Control_Doc.My.Resources.Resources.deletelist_16x16
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "جرد المخازن مواد خام واصناف"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem2.HotFontUnderline = True
        Me.ButtonItem2.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem2.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem2.Image = Global.Control_Doc.My.Resources.Resources.Dreamweaver_MX
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "جرد مجموعة الاصناف كمية وقيمة"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem4.HotFontUnderline = True
        Me.ButtonItem4.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem4.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem4.Image = Global.Control_Doc.My.Resources.Resources.Browse_1
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "تقييم المخزن"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem5.HotFontUnderline = True
        Me.ButtonItem5.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem5.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem5.Image = Global.Control_Doc.My.Resources.Resources.seo_successful_planning_checkmark_32
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "اذونات الصرف للمخازن"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem6.HotFontUnderline = True
        Me.ButtonItem6.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem6.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem6.Image = Global.Control_Doc.My.Resources.Resources.Email_App_Icon
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "باركود للمخازن"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem7.HotFontUnderline = True
        Me.ButtonItem7.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem7.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem7.Image = Global.Control_Doc.My.Resources.Resources.Download
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Text = "الاصناف المضافة والمنصرفة من المخازن خلال فترة"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem8.HotFontUnderline = True
        Me.ButtonItem8.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem8.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem8.Image = Global.Control_Doc.My.Resources.Resources.File
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Text = "الاصناف المرتجعة في المخازن خلال فترة"
        '
        'ExplorerBarGroupItem3
        '
        '
        '
        '
        Me.ExplorerBarGroupItem3.BackStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ExplorerBarGroupItem3.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem3.BackStyle.BorderBottomWidth = 1
        Me.ExplorerBarGroupItem3.BackStyle.BorderColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem3.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem3.BackStyle.BorderLeftWidth = 1
        Me.ExplorerBarGroupItem3.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem3.BackStyle.BorderRightWidth = 1
        Me.ExplorerBarGroupItem3.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem3.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExplorerBarGroupItem3.Name = "ExplorerBarGroupItem3"
        Me.ExplorerBarGroupItem3.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SilverSpecial
        Me.ExplorerBarGroupItem3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem50, Me.ButtonItem56})
        Me.ExplorerBarGroupItem3.Text = "تنبيهات المبيعات"
        '
        '
        '
        Me.ExplorerBarGroupItem3.TitleHotStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem3.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem3.TitleHotStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem3.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem3.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem3.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem3.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        '
        '
        '
        Me.ExplorerBarGroupItem3.TitleStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem3.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem3.TitleStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem3.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem3.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem3.TitleStyle.TextColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem3.XPSpecialGroup = True
        '
        'ButtonItem50
        '
        Me.ButtonItem50.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem50.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem50.HotFontUnderline = True
        Me.ButtonItem50.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem50.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem50.Name = "ButtonItem50"
        Me.ButtonItem50.Text = "متحصلات العميل"
        '
        'ButtonItem56
        '
        Me.ButtonItem56.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem56.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem56.HotFontUnderline = True
        Me.ButtonItem56.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem56.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem56.Name = "ButtonItem56"
        Me.ButtonItem56.Text = "متأخرات العميل"
        '
        'ExplorerBarGroupItem1
        '
        '
        '
        '
        Me.ExplorerBarGroupItem1.BackStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ExplorerBarGroupItem1.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem1.BackStyle.BorderBottomWidth = 1
        Me.ExplorerBarGroupItem1.BackStyle.BorderColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem1.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem1.BackStyle.BorderLeftWidth = 1
        Me.ExplorerBarGroupItem1.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ExplorerBarGroupItem1.BackStyle.BorderRightWidth = 1
        Me.ExplorerBarGroupItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExplorerBarGroupItem1.Expanded = True
        Me.ExplorerBarGroupItem1.Name = "ExplorerBarGroupItem1"
        Me.ExplorerBarGroupItem1.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SilverSpecial
        Me.ExplorerBarGroupItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        Me.ExplorerBarGroupItem1.Text = "الطباعة"
        '
        '
        '
        Me.ExplorerBarGroupItem1.TitleHotStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem1.TitleHotStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem1.TitleHotStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem1.TitleHotStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem1.TitleHotStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem1.TitleHotStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem1.TitleHotStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        '
        '
        '
        Me.ExplorerBarGroupItem1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.ExplorerBarGroupItem1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ExplorerBarGroupItem1.TitleStyle.CornerDiameter = 3
        Me.ExplorerBarGroupItem1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExplorerBarGroupItem1.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem1.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ExplorerBarGroupItem1.TitleStyle.TextColor = System.Drawing.Color.White
        Me.ExplorerBarGroupItem1.XPSpecialGroup = True
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ButtonItem3.HotFontUnderline = True
        Me.ButtonItem3.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonItem3.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None
        Me.ButtonItem3.Image = Global.Control_Doc.My.Resources.Resources.printarea_16x16
        Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "معاينة قبل الطباعة"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
        '
        'Frm_Report_StockAndItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 606)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Frm_Report_StockAndItems"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "بيانات المخازن الاصناف"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        Me.TabNavigationPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView5 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView5 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView3 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView6 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CardView6 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ExplorerBar1 As DevComponents.DotNetBar.ExplorerBar
    Friend WithEvents ExplorerBarGroupItem2 As DevComponents.DotNetBar.ExplorerBarGroupItem
    Friend WithEvents ButtonItem60 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem61 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExplorerBarGroupItem3 As DevComponents.DotNetBar.ExplorerBarGroupItem
    Friend WithEvents ButtonItem50 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem56 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExplorerBarGroupItem1 As DevComponents.DotNetBar.ExplorerBarGroupItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
