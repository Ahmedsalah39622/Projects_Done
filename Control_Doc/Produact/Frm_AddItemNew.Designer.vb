<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddItemNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AddItemNew))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.Com_NameItem = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CardView7 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView7 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView4 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView8 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView4 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridView8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView8 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.Com_NameItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_Delete)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Com_NameItem)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX5)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(543, 475)
        Me.SplitContainerControl1.SplitterPosition = 22
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(13, 0)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(39, 22)
        Me.Cmd_Delete.TabIndex = 1178
        Me.Cmd_Delete.ToolTip = "حذف"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton3.Location = New System.Drawing.Point(52, 0)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(41, 22)
        Me.SimpleButton3.TabIndex = 1171
        Me.SimpleButton3.ToolTip = "اضافة"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton4.Location = New System.Drawing.Point(93, 0)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(43, 22)
        Me.SimpleButton4.TabIndex = 1170
        Me.SimpleButton4.ToolTip = "بحث"
        '
        'Com_NameItem
        '
        Me.Com_NameItem.Dock = System.Windows.Forms.DockStyle.Right
        Me.Com_NameItem.Location = New System.Drawing.Point(136, 0)
        Me.Com_NameItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_NameItem.Name = "Com_NameItem"
        Me.Com_NameItem.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Com_NameItem.Properties.Appearance.Options.UseFont = True
        Me.Com_NameItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Com_NameItem.Size = New System.Drawing.Size(316, 24)
        Me.Com_NameItem.TabIndex = 0
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(452, 0)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(91, 22)
        Me.LabelX5.TabIndex = 1168
        Me.LabelX5.Text = "أسم المنتج"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.GridControl4)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SimpleButton2)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(543, 447)
        Me.SplitContainerControl2.SplitterPosition = 388
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl4.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl4.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.MainView = Me.GridView5
        Me.GridControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(543, 388)
        Me.GridControl4.TabIndex = 864
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5, Me.CardView7, Me.GridView8, Me.BandedGridView7, Me.WinExplorerView7, Me.TileView4, Me.WinExplorerView8, Me.AdvBandedGridView4, Me.BandedGridView8, Me.CardView8, Me.GridView1})
        '
        'GridView5
        '
        Me.GridView5.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView5.Appearance.FixedLine.Options.UseFont = True
        Me.GridView5.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView5.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.FocusedCell.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView5.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView5.Appearance.FocusedCell.Options.UseBorderColor = True
        Me.GridView5.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView5.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Silver
        Me.GridView5.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView5.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView5.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView5.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView5.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView5.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView5.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView5.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView5.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView5.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView5.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView5.GridControl = Me.GridControl4
        Me.GridView5.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", Nothing, "(Name: Count={0})")})
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.Editable = False
        Me.GridView5.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView5.OptionsPrint.PrintPreview = True
        Me.GridView5.OptionsView.ColumnAutoWidth = False
        Me.GridView5.OptionsView.ShowFooter = True
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'CardView7
        '
        Me.CardView7.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8})
        Me.CardView7.FocusedCardTopFieldIndex = 0
        Me.CardView7.GridControl = Me.GridControl4
        Me.CardView7.Name = "CardView7"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "aa"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "bb"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridView8
        '
        Me.GridView8.GridControl = Me.GridControl4
        Me.GridView8.Name = "GridView8"
        Me.GridView8.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView7
        '
        Me.BandedGridView7.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand10})
        Me.BandedGridView7.GridControl = Me.GridControl4
        Me.BandedGridView7.Name = "BandedGridView7"
        '
        'GridBand10
        '
        Me.GridBand10.Caption = "GridBand1"
        Me.GridBand10.Name = "GridBand10"
        Me.GridBand10.VisibleIndex = 0
        '
        'WinExplorerView7
        '
        Me.WinExplorerView7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.WinExplorerView7.GridControl = Me.GridControl4
        Me.WinExplorerView7.Name = "WinExplorerView7"
        '
        'TileView4
        '
        Me.TileView4.GridControl = Me.GridControl4
        Me.TileView4.Name = "TileView4"
        '
        'WinExplorerView8
        '
        Me.WinExplorerView8.GridControl = Me.GridControl4
        Me.WinExplorerView8.Name = "WinExplorerView8"
        '
        'AdvBandedGridView4
        '
        Me.AdvBandedGridView4.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand11})
        Me.AdvBandedGridView4.GridControl = Me.GridControl4
        Me.AdvBandedGridView4.Name = "AdvBandedGridView4"
        '
        'GridBand11
        '
        Me.GridBand11.Caption = "GridBand3"
        Me.GridBand11.Name = "GridBand11"
        Me.GridBand11.VisibleIndex = 0
        '
        'BandedGridView8
        '
        Me.BandedGridView8.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand12})
        Me.BandedGridView8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView8.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn7, Me.BandedGridColumn8})
        Me.BandedGridView8.GridControl = Me.GridControl4
        Me.BandedGridView8.Name = "BandedGridView8"
        Me.BandedGridView8.OptionsView.ShowGroupPanel = False
        '
        'GridBand12
        '
        Me.GridBand12.Caption = "GridBand2"
        Me.GridBand12.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand12.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand12.Name = "GridBand12"
        Me.GridBand12.VisibleIndex = 0
        Me.GridBand12.Width = 150
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "aa"
        Me.BandedGridColumn7.FieldName = "Name"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.FieldName = "Description"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        '
        'CardView8
        '
        Me.CardView8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView8.FocusedCardTopFieldIndex = 0
        Me.CardView8.GridControl = Me.GridControl4
        Me.CardView8.Name = "CardView8"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl4
        Me.GridView1.Name = "GridView1"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton2.Location = New System.Drawing.Point(255, 0)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(144, 53)
        Me.SimpleButton2.TabIndex = 1173
        Me.SimpleButton2.Text = "اغلاق"
        Me.SimpleButton2.ToolTip = "اضافة"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton1.Location = New System.Drawing.Point(399, 0)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(144, 53)
        Me.SimpleButton1.TabIndex = 1172
        Me.SimpleButton1.Text = "اضافة"
        Me.SimpleButton1.ToolTip = "اضافة"
        '
        'Frm_AddItemNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 475)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.MaximizeBox = False
        Me.Name = "Frm_AddItemNew"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "اضافة منتج جديد"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.Com_NameItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Com_NameItem As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_Delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CardView7 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView7 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView4 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView8 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView4 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridView8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView8 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
