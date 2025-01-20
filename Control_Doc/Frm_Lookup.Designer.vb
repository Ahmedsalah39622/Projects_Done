<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Lookup
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Lookup))
        Me.CardView3 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView4 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView3 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView2 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView4 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.CardView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CardView3
        '
        Me.CardView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView3.FocusedCardTopFieldIndex = 0
        Me.CardView3.GridControl = Me.GridControl3
        Me.CardView3.Name = "CardView3"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.CardView3
        GridLevelNode1.RelationName = "Level1"
        GridLevelNode2.RelationName = "Level2"
        GridLevelNode3.RelationName = "Level3"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1, GridLevelNode2, GridLevelNode3})
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView4
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(478, 494)
        Me.GridControl3.TabIndex = 4
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4, Me.BandedGridView3, Me.CardView4, Me.GridView5, Me.BandedGridView4, Me.WinExplorerView3, Me.TileView2, Me.WinExplorerView4, Me.AdvBandedGridView2, Me.CardView3})
        '
        'GridView4
        '
        Me.GridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6})
        Me.GridView4.GridControl = Me.GridControl3
        Me.GridView4.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", Nothing, "(Name: Count={0})")})
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsFind.AlwaysVisible = True
        Me.GridView4.OptionsView.ShowGroupPanel = False
        Me.GridView4.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn6, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Name"
        Me.GridColumn5.FieldName = "Name"
        Me.GridColumn5.Image = CType(resources.GetObject("GridColumn5.Image"), System.Drawing.Image)
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 87
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "Description"
        Me.GridColumn6.Image = CType(resources.GetObject("GridColumn6.Image"), System.Drawing.Image)
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 110
        '
        'BandedGridView3
        '
        Me.BandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand4})
        Me.BandedGridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView3.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.BandedGridView3.GridControl = Me.GridControl3
        Me.BandedGridView3.Name = "BandedGridView3"
        Me.BandedGridView3.OptionsView.ShowGroupPanel = False
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "GridBand2"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 0
        Me.GridBand4.Width = 150
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "aa"
        Me.BandedGridColumn1.FieldName = "Name"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.FieldName = "Description"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'CardView4
        '
        Me.CardView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8})
        Me.CardView4.FocusedCardTopFieldIndex = 0
        Me.CardView4.GridControl = Me.GridControl3
        Me.CardView4.Name = "CardView4"
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
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl3
        Me.GridView5.Name = "GridView5"
        Me.GridView5.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView4
        '
        Me.BandedGridView4.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5})
        Me.BandedGridView4.GridControl = Me.GridControl3
        Me.BandedGridView4.Name = "BandedGridView4"
        '
        'GridBand5
        '
        Me.GridBand5.Caption = "GridBand1"
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 0
        '
        'WinExplorerView3
        '
        Me.WinExplorerView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.WinExplorerView3.GridControl = Me.GridControl3
        Me.WinExplorerView3.Name = "WinExplorerView3"
        '
        'TileView2
        '
        Me.TileView2.GridControl = Me.GridControl3
        Me.TileView2.Name = "TileView2"
        '
        'WinExplorerView4
        '
        Me.WinExplorerView4.GridControl = Me.GridControl3
        Me.WinExplorerView4.Name = "WinExplorerView4"
        '
        'AdvBandedGridView2
        '
        Me.AdvBandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand6})
        Me.AdvBandedGridView2.GridControl = Me.GridControl3
        Me.AdvBandedGridView2.Name = "AdvBandedGridView2"
        '
        'GridBand6
        '
        Me.GridBand6.Caption = "GridBand3"
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.VisibleIndex = 0
        '
        'Frm_Lookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 494)
        Me.Controls.Add(Me.GridControl3)
        Me.MaximizeBox = False
        Me.Name = "Frm_Lookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lookup"
        CType(Me.CardView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CardView3 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView4 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView3 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView2 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView4 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
