<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FindEmp
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
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.VwEmpBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DB_ECGDataSet = New Control_Doc.DB_ECGDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEmp_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNameDir = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNameDeprt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJopName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmp_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView3 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView3 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView2 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView4 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CardView4 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.Vw_EmpTableAdapter = New Control_Doc.DB_ECGDataSetTableAdapters.Vw_EmpTableAdapter()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwEmpBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_ECGDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.VwEmpBindingSource
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView1
        Me.GridControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1426, 658)
        Me.GridControl2.TabIndex = 775
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.BandedGridView3, Me.CardView3, Me.GridView4, Me.BandedGridView4, Me.WinExplorerView3, Me.TileView2, Me.WinExplorerView4, Me.AdvBandedGridView2, Me.CardView4})
        '
        'VwEmpBindingSource
        '
        Me.VwEmpBindingSource.DataMember = "Vw_Emp"
        Me.VwEmpBindingSource.DataSource = Me.DB_ECGDataSet
        '
        'DB_ECGDataSet
        '
        Me.DB_ECGDataSet.DataSetName = "DB_ECGDataSet"
        Me.DB_ECGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 826.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FixedLine.FontSizeDelta = 5
        Me.GridView1.Appearance.FixedLine.Options.UseFont = True
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.GroupRow.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEmp_Code, Me.colNameDir, Me.colNameDeprt, Me.colJopName, Me.colEmp_Name})
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", Nothing, "(Name: Count={0})")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEmp_Code
        '
        Me.colEmp_Code.Caption = "رقم الموظف"
        Me.colEmp_Code.FieldName = "Emp_Code"
        Me.colEmp_Code.Name = "colEmp_Code"
        Me.colEmp_Code.Width = 98
        '
        'colNameDir
        '
        Me.colNameDir.Caption = "الادارة"
        Me.colNameDir.FieldName = "NameDir"
        Me.colNameDir.Name = "colNameDir"
        Me.colNameDir.Visible = True
        Me.colNameDir.VisibleIndex = 0
        Me.colNameDir.Width = 182
        '
        'colNameDeprt
        '
        Me.colNameDeprt.Caption = "القسم"
        Me.colNameDeprt.FieldName = "NameDeprt"
        Me.colNameDeprt.Name = "colNameDeprt"
        Me.colNameDeprt.Visible = True
        Me.colNameDeprt.VisibleIndex = 1
        Me.colNameDeprt.Width = 193
        '
        'colJopName
        '
        Me.colJopName.Caption = "المسمى الوظيفى"
        Me.colJopName.FieldName = "JopName"
        Me.colJopName.Name = "colJopName"
        Me.colJopName.Visible = True
        Me.colJopName.VisibleIndex = 2
        Me.colJopName.Width = 248
        '
        'colEmp_Name
        '
        Me.colEmp_Name.Caption = "اسم الموظف"
        Me.colEmp_Name.FieldName = "Emp_Name"
        Me.colEmp_Name.Name = "colEmp_Name"
        Me.colEmp_Name.Visible = True
        Me.colEmp_Name.VisibleIndex = 3
        Me.colEmp_Name.Width = 293
        '
        'BandedGridView3
        '
        Me.BandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand4})
        Me.BandedGridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView3.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn3, Me.BandedGridColumn4})
        Me.BandedGridView3.GridControl = Me.GridControl2
        Me.BandedGridView3.Name = "BandedGridView3"
        Me.BandedGridView3.OptionsView.ShowGroupPanel = False
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "GridBand2"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 0
        Me.GridBand4.Width = 150
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
        'CardView3
        '
        Me.CardView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.CardView3.FocusedCardTopFieldIndex = 0
        Me.CardView3.GridControl = Me.GridControl2
        Me.CardView3.Name = "CardView3"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "aa"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "bb"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl2
        Me.GridView4.Name = "GridView4"
        Me.GridView4.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView4
        '
        Me.BandedGridView4.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5})
        Me.BandedGridView4.GridControl = Me.GridControl2
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
        Me.WinExplorerView3.GridControl = Me.GridControl2
        Me.WinExplorerView3.Name = "WinExplorerView3"
        '
        'TileView2
        '
        Me.TileView2.GridControl = Me.GridControl2
        Me.TileView2.Name = "TileView2"
        '
        'WinExplorerView4
        '
        Me.WinExplorerView4.GridControl = Me.GridControl2
        Me.WinExplorerView4.Name = "WinExplorerView4"
        '
        'AdvBandedGridView2
        '
        Me.AdvBandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand6})
        Me.AdvBandedGridView2.GridControl = Me.GridControl2
        Me.AdvBandedGridView2.Name = "AdvBandedGridView2"
        '
        'GridBand6
        '
        Me.GridBand6.Caption = "GridBand3"
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.VisibleIndex = 0
        '
        'CardView4
        '
        Me.CardView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView4.FocusedCardTopFieldIndex = 0
        Me.CardView4.GridControl = Me.GridControl2
        Me.CardView4.Name = "CardView4"
        '
        'Vw_EmpTableAdapter
        '
        Me.Vw_EmpTableAdapter.ClearBeforeFill = True
        '
        'Frm_FindEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1426, 658)
        Me.Controls.Add(Me.GridControl2)
        Me.MaximizeBox = False
        Me.Name = "Frm_FindEmp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث"
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwEmpBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_ECGDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView3 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView3 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView2 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView4 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CardView4 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents DB_ECGDataSet As Control_Doc.DB_ECGDataSet
    Friend WithEvents VwEmpBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Vw_EmpTableAdapter As Control_Doc.DB_ECGDataSetTableAdapters.Vw_EmpTableAdapter
    Friend WithEvents colEmp_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmp_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNameDir As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNameDeprt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJopName As DevExpress.XtraGrid.Columns.GridColumn
End Class
