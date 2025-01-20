<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ChekTest
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ChekTest))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.DBInterpakDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        'Me.DB_InterpakDataSet1 = New Control_Doc.DB_InterpakDataSet1()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView1 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView1 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView2 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CardView2 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        'Me.DataTable1TableAdapter = New Control_Doc.DB_InterpakDataSet1TableAdapters.DataTable1TableAdapter()
        Me.colReceipt_No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSerail_lNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReceipt_Date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReceipt_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCheck_No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBank_IN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDate_Asthkak = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridSplitContainer1 = New DevExpress.XtraGrid.GridSplitContainer()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBInterpakDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.DB_InterpakDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GridSplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.DataTable1BindingSource
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        GridLevelNode2.RelationName = "Level2"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1, GridLevelNode2})
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(825, 423)
        Me.GridControl1.TabIndex = 771
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.BandedGridView1, Me.CardView1, Me.GridView2, Me.BandedGridView2, Me.WinExplorerView1, Me.TileView1, Me.WinExplorerView2, Me.AdvBandedGridView1, Me.CardView2})
        '
        'DBInterpakDataSet1BindingSource
        '
        'Me.DBInterpakDataSet1BindingSource.DataSource = Me.DB_InterpakDataSet1
        Me.DBInterpakDataSet1BindingSource.Position = 0
        '
        'DB_InterpakDataSet1
        '
        'Me.DB_InterpakDataSet1.DataSetName = "DB_InterpakDataSet1"
        'Me.DB_InterpakDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        ''
        'GridView1
        '
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.FixedLine.Options.UseFont = True
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colReceipt_No, Me.colSerail_lNo, Me.colReceipt_Date, Me.colReceipt_Value, Me.colAccountName, Me.colCheck_No, Me.colBank_IN, Me.colDate_Asthkak})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Receipt_Value", Me.colReceipt_Value, "(Name: Count={0})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Me.colAccountName, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.BandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.BandedGridView1.GridControl = Me.GridControl1
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand2"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
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
        'CardView1
        '
        Me.CardView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.GridControl1
        Me.CardView1.Name = "CardView1"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "aa"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "bb"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView2
        '
        Me.BandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.BandedGridView2.GridControl = Me.GridControl1
        Me.BandedGridView2.Name = "BandedGridView2"
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "GridBand1"
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        '
        'WinExplorerView1
        '
        Me.WinExplorerView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.WinExplorerView1.GridControl = Me.GridControl1
        Me.WinExplorerView1.Name = "WinExplorerView1"
        '
        'TileView1
        '
        Me.TileView1.GridControl = Me.GridControl1
        Me.TileView1.Name = "TileView1"
        '
        'WinExplorerView2
        '
        Me.WinExplorerView2.GridControl = Me.GridControl1
        Me.WinExplorerView2.Name = "WinExplorerView2"
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        '
        'GridBand3
        '
        Me.GridBand3.Caption = "GridBand3"
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        '
        'CardView2
        '
        Me.CardView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView2.FocusedCardTopFieldIndex = 0
        Me.CardView2.GridControl = Me.GridControl1
        Me.CardView2.Name = "CardView2"
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DBInterpakDataSet1BindingSource
        '
        'DataTable1TableAdapter
        '
        'Me.DataTable1TableAdapter.ClearBeforeFill = True
        '
        'colReceipt_No
        '
        Me.colReceipt_No.FieldName = "Receipt_No"
        Me.colReceipt_No.Name = "colReceipt_No"
        Me.colReceipt_No.Visible = True
        Me.colReceipt_No.VisibleIndex = 0
        '
        'colSerail_lNo
        '
        Me.colSerail_lNo.FieldName = "Serail_lNo"
        Me.colSerail_lNo.Name = "colSerail_lNo"
        Me.colSerail_lNo.Visible = True
        Me.colSerail_lNo.VisibleIndex = 1
        '
        'colReceipt_Date
        '
        Me.colReceipt_Date.FieldName = "Receipt_Date"
        Me.colReceipt_Date.Name = "colReceipt_Date"
        Me.colReceipt_Date.Visible = True
        Me.colReceipt_Date.VisibleIndex = 2
        Me.colReceipt_Date.Width = 124
        '
        'colReceipt_Value
        '
        Me.colReceipt_Value.FieldName = "Receipt_Value"
        Me.colReceipt_Value.Name = "colReceipt_Value"
        Me.colReceipt_Value.Visible = True
        Me.colReceipt_Value.VisibleIndex = 3
        Me.colReceipt_Value.Width = 147
        '
        'colAccountName
        '
        Me.colAccountName.FieldName = "AccountName"
        Me.colAccountName.Image = CType(resources.GetObject("colAccountName.Image"), System.Drawing.Image)
        Me.colAccountName.Name = "colAccountName"
        Me.colAccountName.Visible = True
        Me.colAccountName.VisibleIndex = 4
        '
        'colCheck_No
        '
        Me.colCheck_No.FieldName = "Check_No"
        Me.colCheck_No.Name = "colCheck_No"
        Me.colCheck_No.Visible = True
        Me.colCheck_No.VisibleIndex = 5
        '
        'colBank_IN
        '
        Me.colBank_IN.FieldName = "Bank_IN"
        Me.colBank_IN.Name = "colBank_IN"
        Me.colBank_IN.Visible = True
        Me.colBank_IN.VisibleIndex = 6
        '
        'colDate_Asthkak
        '
        Me.colDate_Asthkak.FieldName = "Date_Asthkak"
        Me.colDate_Asthkak.Name = "colDate_Asthkak"
        Me.colDate_Asthkak.Visible = True
        Me.colDate_Asthkak.VisibleIndex = 7
        Me.colDate_Asthkak.Width = 101
        '
        'GridSplitContainer1
        '
        Me.GridSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSplitContainer1.Grid = Me.GridControl1
        Me.GridSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.GridSplitContainer1.Name = "GridSplitContainer1"
        Me.GridSplitContainer1.Panel1.Controls.Add(Me.GridControl1)
        Me.GridSplitContainer1.Size = New System.Drawing.Size(825, 423)
        Me.GridSplitContainer1.TabIndex = 0
        '
        'Frm_ChekTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 423)
        Me.Controls.Add(Me.GridSplitContainer1)
        Me.Name = "Frm_ChekTest"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "Frm_ChekTest"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBInterpakDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.DB_InterpakDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GridSplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents DBInterpakDataSet1BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents DB_InterpakDataSet1 As Control_Doc.DB_InterpakDataSet1
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView1 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView1 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView2 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CardView2 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents DataTable1TableAdapter As Control_Doc.DB_InterpakDataSet1TableAdapters.DataTable1TableAdapter
    Friend WithEvents colReceipt_No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSerail_lNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceipt_Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceipt_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCheck_No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBank_IN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDate_Asthkak As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridSplitContainer1 As DevExpress.XtraGrid.GridSplitContainer
End Class
