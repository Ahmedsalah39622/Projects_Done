<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_expired_dates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_expired_dates))
        Me.btn_ended_license = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ended_national_id = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ended_passport = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ended_document = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_doc_to_end = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ended_car_license = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CardView9 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridView10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand14 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.WinExplorerView9 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.TileView5 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.WinExplorerView10 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.AdvBandedGridView5 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand15 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CardView10 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.btn_show_report = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_ended_license
        '
        Me.btn_ended_license.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ended_license.Appearance.Options.UseFont = True
        Me.btn_ended_license.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ended_license.Location = New System.Drawing.Point(865, 12)
        Me.btn_ended_license.Name = "btn_ended_license"
        Me.btn_ended_license.Size = New System.Drawing.Size(128, 47)
        Me.btn_ended_license.TabIndex = 1
        Me.btn_ended_license.Text = "الرخص المنتهية"
        '
        'btn_ended_national_id
        '
        Me.btn_ended_national_id.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ended_national_id.Appearance.Options.UseFont = True
        Me.btn_ended_national_id.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ended_national_id.Location = New System.Drawing.Point(731, 12)
        Me.btn_ended_national_id.Name = "btn_ended_national_id"
        Me.btn_ended_national_id.Size = New System.Drawing.Size(128, 47)
        Me.btn_ended_national_id.TabIndex = 2
        Me.btn_ended_national_id.Text = "البطاقات المنتهية"
        '
        'btn_ended_passport
        '
        Me.btn_ended_passport.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ended_passport.Appearance.Options.UseFont = True
        Me.btn_ended_passport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ended_passport.Location = New System.Drawing.Point(597, 12)
        Me.btn_ended_passport.Name = "btn_ended_passport"
        Me.btn_ended_passport.Size = New System.Drawing.Size(128, 47)
        Me.btn_ended_passport.TabIndex = 3
        Me.btn_ended_passport.Text = "الجوازات المنتهية"
        '
        'btn_ended_document
        '
        Me.btn_ended_document.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ended_document.Appearance.Options.UseFont = True
        Me.btn_ended_document.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ended_document.Location = New System.Drawing.Point(463, 12)
        Me.btn_ended_document.Name = "btn_ended_document"
        Me.btn_ended_document.Size = New System.Drawing.Size(128, 47)
        Me.btn_ended_document.TabIndex = 4
        Me.btn_ended_document.Text = "الوثائق المنتهية"
        '
        'btn_doc_to_end
        '
        Me.btn_doc_to_end.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_doc_to_end.Appearance.Options.UseFont = True
        Me.btn_doc_to_end.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_doc_to_end.Location = New System.Drawing.Point(183, 12)
        Me.btn_doc_to_end.Name = "btn_doc_to_end"
        Me.btn_doc_to_end.Size = New System.Drawing.Size(140, 47)
        Me.btn_doc_to_end.TabIndex = 5
        Me.btn_doc_to_end.Text = "الوثائق قاربت على الانتهاء"
        '
        'btn_ended_car_license
        '
        Me.btn_ended_car_license.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ended_car_license.Appearance.Options.UseFont = True
        Me.btn_ended_car_license.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ended_car_license.Location = New System.Drawing.Point(329, 12)
        Me.btn_ended_car_license.Name = "btn_ended_car_license"
        Me.btn_ended_car_license.Size = New System.Drawing.Size(128, 47)
        Me.btn_ended_car_license.TabIndex = 6
        Me.btn_ended_car_license.Text = "السيارات المنتهية"
        '
        'GridControl5
        '
        Me.GridControl5.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl5.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl5.Location = New System.Drawing.Point(12, 78)
        Me.GridControl5.MainView = Me.GridView9
        Me.GridControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.Size = New System.Drawing.Size(1176, 497)
        Me.GridControl5.TabIndex = 777
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView9, Me.BandedGridView9, Me.CardView9, Me.GridView10, Me.BandedGridView10, Me.WinExplorerView9, Me.TileView5, Me.WinExplorerView10, Me.AdvBandedGridView5, Me.CardView10})
        '
        'GridView9
        '
        Me.GridView9.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridView9.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView9.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 916.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView9.Appearance.FixedLine.Options.UseFont = True
        Me.GridView9.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView9.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView9.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView9.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView9.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridView9.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView9.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView9.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView9.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView9.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView9.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView9.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView9.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView9.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView9.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView9.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView9.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView9.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView9.DetailHeight = 284
        Me.GridView9.GridControl = Me.GridControl5
        Me.GridView9.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", Nothing, "(Name: Count={0})")})
        Me.GridView9.Name = "GridView9"
        Me.GridView9.OptionsBehavior.Editable = False
        Me.GridView9.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView9.OptionsFind.AlwaysVisible = True
        Me.GridView9.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView9.OptionsView.ColumnAutoWidth = False
        Me.GridView9.OptionsView.ShowAutoFilterRow = True
        Me.GridView9.OptionsView.ShowFooter = True
        Me.GridView9.OptionsView.ShowGroupPanel = False
        '
        'BandedGridView9
        '
        Me.BandedGridView9.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand13})
        Me.BandedGridView9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BandedGridView9.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn9, Me.BandedGridColumn10})
        Me.BandedGridView9.DetailHeight = 284
        Me.BandedGridView9.GridControl = Me.GridControl5
        Me.BandedGridView9.Name = "BandedGridView9"
        Me.BandedGridView9.OptionsEditForm.PopupEditFormWidth = 686
        Me.BandedGridView9.OptionsView.ShowGroupPanel = False
        '
        'GridBand13
        '
        Me.GridBand13.Caption = "GridBand2"
        Me.GridBand13.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand13.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand13.Name = "GridBand13"
        Me.GridBand13.VisibleIndex = 0
        Me.GridBand13.Width = 129
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "aa"
        Me.BandedGridColumn9.FieldName = "Name"
        Me.BandedGridColumn9.MinWidth = 17
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 64
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.FieldName = "Description"
        Me.BandedGridColumn10.MinWidth = 17
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 64
        '
        'CardView9
        '
        Me.CardView9.CardWidth = 171
        Me.CardView9.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10})
        Me.CardView9.DetailHeight = 284
        Me.CardView9.GridControl = Me.GridControl5
        Me.CardView9.Name = "CardView9"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "aa"
        Me.GridColumn9.MinWidth = 17
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 64
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "bb"
        Me.GridColumn10.MinWidth = 17
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        Me.GridColumn10.Width = 64
        '
        'GridView10
        '
        Me.GridView10.DetailHeight = 284
        Me.GridView10.GridControl = Me.GridControl5
        Me.GridView10.Name = "GridView10"
        Me.GridView10.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView10.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        '
        'BandedGridView10
        '
        Me.BandedGridView10.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand14})
        Me.BandedGridView10.DetailHeight = 284
        Me.BandedGridView10.GridControl = Me.GridControl5
        Me.BandedGridView10.Name = "BandedGridView10"
        Me.BandedGridView10.OptionsEditForm.PopupEditFormWidth = 686
        '
        'GridBand14
        '
        Me.GridBand14.Caption = "GridBand1"
        Me.GridBand14.Name = "GridBand14"
        Me.GridBand14.VisibleIndex = 0
        Me.GridBand14.Width = 60
        '
        'WinExplorerView9
        '
        Me.WinExplorerView9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.WinExplorerView9.GridControl = Me.GridControl5
        Me.WinExplorerView9.Name = "WinExplorerView9"
        '
        'TileView5
        '
        Me.TileView5.DetailHeight = 284
        Me.TileView5.GridControl = Me.GridControl5
        Me.TileView5.Name = "TileView5"
        '
        'WinExplorerView10
        '
        Me.WinExplorerView10.GridControl = Me.GridControl5
        Me.WinExplorerView10.Name = "WinExplorerView10"
        '
        'AdvBandedGridView5
        '
        Me.AdvBandedGridView5.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand15})
        Me.AdvBandedGridView5.DetailHeight = 284
        Me.AdvBandedGridView5.GridControl = Me.GridControl5
        Me.AdvBandedGridView5.Name = "AdvBandedGridView5"
        Me.AdvBandedGridView5.OptionsEditForm.PopupEditFormWidth = 686
        '
        'GridBand15
        '
        Me.GridBand15.Caption = "GridBand3"
        Me.GridBand15.Name = "GridBand15"
        Me.GridBand15.VisibleIndex = 0
        Me.GridBand15.Width = 60
        '
        'CardView10
        '
        Me.CardView10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView10.CardWidth = 171
        Me.CardView10.DetailHeight = 284
        Me.CardView10.GridControl = Me.GridControl5
        Me.CardView10.Name = "CardView10"
        '
        'btn_show_report
        '
        Me.btn_show_report.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_show_report.Appearance.Options.UseFont = True
        Me.btn_show_report.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_show_report.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_show_report.Location = New System.Drawing.Point(12, 18)
        Me.btn_show_report.Name = "btn_show_report"
        Me.btn_show_report.Size = New System.Drawing.Size(113, 35)
        Me.btn_show_report.TabIndex = 778
        Me.btn_show_report.Text = "معاينة التقرير"
        '
        'Frm_expired_dates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 572)
        Me.Controls.Add(Me.btn_show_report)
        Me.Controls.Add(Me.GridControl5)
        Me.Controls.Add(Me.btn_ended_car_license)
        Me.Controls.Add(Me.btn_doc_to_end)
        Me.Controls.Add(Me.btn_ended_document)
        Me.Controls.Add(Me.btn_ended_passport)
        Me.Controls.Add(Me.btn_ended_national_id)
        Me.Controls.Add(Me.btn_ended_license)
        Me.Name = "Frm_expired_dates"
        Me.Text = "Frm_expired_dates"
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_ended_license As XtraEditors.SimpleButton
    Friend WithEvents btn_ended_national_id As XtraEditors.SimpleButton
    Friend WithEvents btn_ended_passport As XtraEditors.SimpleButton
    Friend WithEvents btn_ended_document As XtraEditors.SimpleButton
    Friend WithEvents btn_doc_to_end As XtraEditors.SimpleButton
    Friend WithEvents btn_ended_car_license As XtraEditors.SimpleButton
    Friend WithEvents GridControl5 As XtraGrid.GridControl
    Friend WithEvents GridView9 As XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView9 As XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand13 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn9 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CardView9 As XtraGrid.Views.Card.CardView
    Friend WithEvents GridColumn9 As XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As XtraGrid.Columns.GridColumn
    Friend WithEvents GridView10 As XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridView10 As XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand14 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents WinExplorerView9 As XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents TileView5 As XtraGrid.Views.Tile.TileView
    Friend WithEvents WinExplorerView10 As XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents AdvBandedGridView5 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand15 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CardView10 As XtraGrid.Views.Card.CardView
    Friend WithEvents btn_show_report As XtraEditors.SimpleButton
End Class
