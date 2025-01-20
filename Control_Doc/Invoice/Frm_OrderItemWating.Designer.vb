<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OrderItemWating
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OrderItemWating))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Op3 = New System.Windows.Forms.RadioButton()
        Me.Op2 = New System.Windows.Forms.RadioButton()
        Me.Op1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_OpenOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.Lab_Order = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_CreateOrder = New DevExpress.XtraEditors.SimpleButton()
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
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Op3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Op2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Op1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_OpenOrder)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Lab_Order)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_CreateOrder)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControl3)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1055, 464)
        Me.SplitContainerControl1.SplitterPosition = 76
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Op3
        '
        Me.Op3.AutoSize = True
        Me.Op3.Location = New System.Drawing.Point(31, 17)
        Me.Op3.Name = "Op3"
        Me.Op3.Size = New System.Drawing.Size(112, 17)
        Me.Op3.TabIndex = 782
        Me.Op3.Text = "جميع طلبات الصرف"
        Me.Op3.UseVisualStyleBackColor = True
        '
        'Op2
        '
        Me.Op2.AutoSize = True
        Me.Op2.Location = New System.Drawing.Point(176, 17)
        Me.Op2.Name = "Op2"
        Me.Op2.Size = New System.Drawing.Size(133, 17)
        Me.Op2.TabIndex = 781
        Me.Op2.Text = "طلبات صرف فى الانتظار"
        Me.Op2.UseVisualStyleBackColor = True
        '
        'Op1
        '
        Me.Op1.AutoSize = True
        Me.Op1.Location = New System.Drawing.Point(330, 17)
        Me.Op1.Name = "Op1"
        Me.Op1.Size = New System.Drawing.Size(102, 17)
        Me.Op1.TabIndex = 780
        Me.Op1.Text = "طلبات صرف تمت"
        Me.Op1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(432, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 13)
        Me.Label1.TabIndex = 779
        Me.Label1.Text = "أضغط مرتين بالماوس لأظهار الاصناف المطلوب صرفها من المخزن"
        '
        'Cmd_OpenOrder
        '
        Me.Cmd_OpenOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_OpenOrder.Appearance.Options.UseFont = True
        Me.Cmd_OpenOrder.Enabled = False
        Me.Cmd_OpenOrder.Image = CType(resources.GetObject("Cmd_OpenOrder.Image"), System.Drawing.Image)
        Me.Cmd_OpenOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_OpenOrder.Location = New System.Drawing.Point(481, 9)
        Me.Cmd_OpenOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_OpenOrder.Name = "Cmd_OpenOrder"
        Me.Cmd_OpenOrder.Size = New System.Drawing.Size(108, 34)
        Me.Cmd_OpenOrder.TabIndex = 778
        Me.Cmd_OpenOrder.Text = "فتح الطلبية"
        '
        'Lab_Order
        '
        Me.Lab_Order.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        '
        '
        '
        Me.Lab_Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lab_Order.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Order.ForeColor = System.Drawing.Color.Red
        Me.Lab_Order.Location = New System.Drawing.Point(772, 12)
        Me.Lab_Order.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Lab_Order.Name = "Lab_Order"
        Me.Lab_Order.SingleLineColor = System.Drawing.SystemColors.Control
        Me.Lab_Order.Size = New System.Drawing.Size(141, 34)
        Me.Lab_Order.TabIndex = 777
        Me.Lab_Order.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Cmd_CreateOrder
        '
        Me.Cmd_CreateOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_CreateOrder.Appearance.Options.UseFont = True
        Me.Cmd_CreateOrder.Enabled = False
        Me.Cmd_CreateOrder.Image = CType(resources.GetObject("Cmd_CreateOrder.Image"), System.Drawing.Image)
        Me.Cmd_CreateOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_CreateOrder.Location = New System.Drawing.Point(595, 9)
        Me.Cmd_CreateOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_CreateOrder.Name = "Cmd_CreateOrder"
        Me.Cmd_CreateOrder.Size = New System.Drawing.Size(171, 34)
        Me.Cmd_CreateOrder.TabIndex = 775
        Me.Cmd_CreateOrder.Text = "أنشاء طلب صرف من المخازن"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView6
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1055, 383)
        Me.GridControl3.TabIndex = 768
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6, Me.BandedGridView5, Me.CardView5, Me.GridView7, Me.BandedGridView6, Me.WinExplorerView5, Me.TileView3, Me.WinExplorerView6, Me.AdvBandedGridView3, Me.CardView6})
        '
        'GridView6
        '
        Me.GridView6.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.Appearance.FixedLine.Options.UseFont = True
        Me.GridView6.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView6.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Silver
        Me.GridView6.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Silver
        Me.GridView6.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView6.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView6.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView6.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView6.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView6.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView6.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView6.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView6.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView6.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView6.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView6.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView6.GridControl = Me.GridControl3
        Me.GridView6.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", Nothing, "(Name: Count={0})")})
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.Editable = False
        Me.GridView6.OptionsFind.AlwaysVisible = True
        Me.GridView6.OptionsFind.FindNullPrompt = "ادخل كلمة البحث"
        Me.GridView6.OptionsView.ColumnAutoWidth = False
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
        'Frm_OrderItemWating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 464)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "Frm_OrderItemWating"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طلبات صرف من المخزن فى الانتظار"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Cmd_CreateOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lab_Order As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_OpenOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Op3 As System.Windows.Forms.RadioButton
    Friend WithEvents Op2 As System.Windows.Forms.RadioButton
    Friend WithEvents Op1 As System.Windows.Forms.RadioButton
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
End Class
