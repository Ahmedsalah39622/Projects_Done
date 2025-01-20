<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ShiftEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ShiftEmp))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Cmd_NewJobOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_ShiftName = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txt_shiftNo = New System.Windows.Forms.TextBox()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cmd_Edit = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.TimeEdit2 = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TimeEdit1 = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
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
        CType(Me.txt_ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.TimeEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_NewJobOrder)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_ShiftName)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_shiftNo)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX10)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1319, 523)
        Me.SplitContainerControl1.SplitterPosition = 21
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Cmd_NewJobOrder
        '
        Me.Cmd_NewJobOrder.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_NewJobOrder.Image = CType(resources.GetObject("Cmd_NewJobOrder.Image"), System.Drawing.Image)
        Me.Cmd_NewJobOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_NewJobOrder.Location = New System.Drawing.Point(801, 0)
        Me.Cmd_NewJobOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_NewJobOrder.Name = "Cmd_NewJobOrder"
        Me.Cmd_NewJobOrder.Size = New System.Drawing.Size(35, 24)
        Me.Cmd_NewJobOrder.TabIndex = 1051
        Me.Cmd_NewJobOrder.ToolTip = "أمر شغل جديد"
        '
        'txt_ShiftName
        '
        Me.txt_ShiftName.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_ShiftName.Location = New System.Drawing.Point(836, 0)
        Me.txt_ShiftName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_ShiftName.Name = "txt_ShiftName"
        Me.txt_ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txt_ShiftName.Size = New System.Drawing.Size(181, 22)
        Me.txt_ShiftName.TabIndex = 850
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX4.Location = New System.Drawing.Point(1017, 0)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(87, 24)
        Me.LabelX4.TabIndex = 849
        Me.LabelX4.Text = "أسم الوردية"
        '
        'txt_shiftNo
        '
        Me.txt_shiftNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_shiftNo.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_shiftNo.Location = New System.Drawing.Point(1104, 0)
        Me.txt_shiftNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_shiftNo.Name = "txt_shiftNo"
        Me.txt_shiftNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_shiftNo.Size = New System.Drawing.Size(98, 24)
        Me.txt_shiftNo.TabIndex = 848
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX10.Location = New System.Drawing.Point(1202, 0)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(117, 24)
        Me.LabelX10.TabIndex = 844
        Me.LabelX10.Text = "رقم الوردية"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.cmd_Edit)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.Cmd_Delete)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.Cmd_Save)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.TimeEdit2)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelX3)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.TimeEdit1)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelX2)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.GridControl3)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1319, 493)
        Me.SplitContainerControl2.SplitterPosition = 22
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'cmd_Edit
        '
        Me.cmd_Edit.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmd_Edit.Image = CType(resources.GetObject("cmd_Edit.Image"), System.Drawing.Image)
        Me.cmd_Edit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Edit.Location = New System.Drawing.Point(743, 0)
        Me.cmd_Edit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Edit.Name = "cmd_Edit"
        Me.cmd_Edit.Size = New System.Drawing.Size(37, 26)
        Me.cmd_Edit.TabIndex = 875
        Me.cmd_Edit.ToolTip = "تعديل"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Cmd_Delete.Location = New System.Drawing.Point(780, 0)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(41, 26)
        Me.Cmd_Delete.TabIndex = 874
        Me.Cmd_Delete.ToolTip = "حدف"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Save.Image = CType(resources.GetObject("Cmd_Save.Image"), System.Drawing.Image)
        Me.Cmd_Save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Cmd_Save.Location = New System.Drawing.Point(821, 0)
        Me.Cmd_Save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(44, 26)
        Me.Cmd_Save.TabIndex = 873
        Me.Cmd_Save.ToolTip = "حفظ"
        '
        'TimeEdit2
        '
        Me.TimeEdit2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TimeEdit2.EditValue = New Date(2019, 7, 26, 0, 0, 0, 0)
        Me.TimeEdit2.Location = New System.Drawing.Point(865, 0)
        Me.TimeEdit2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TimeEdit2.Name = "TimeEdit2"
        Me.TimeEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeEdit2.Size = New System.Drawing.Size(103, 22)
        Me.TimeEdit2.TabIndex = 871
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX3.Location = New System.Drawing.Point(968, 0)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(131, 26)
        Me.LabelX3.TabIndex = 866
        Me.LabelX3.Text = "ميعاد نهاية الوردية"
        '
        'TimeEdit1
        '
        Me.TimeEdit1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TimeEdit1.EditValue = New Date(2019, 7, 26, 0, 0, 0, 0)
        Me.TimeEdit1.Location = New System.Drawing.Point(1099, 0)
        Me.TimeEdit1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TimeEdit1.Name = "TimeEdit1"
        Me.TimeEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeEdit1.Size = New System.Drawing.Size(103, 22)
        Me.TimeEdit1.TabIndex = 865
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX2.Location = New System.Drawing.Point(1202, 0)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 26)
        Me.LabelX2.TabIndex = 848
        Me.LabelX2.Text = "ميعاد بداية الوردية"
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
        Me.GridControl3.Size = New System.Drawing.Size(1319, 461)
        Me.GridControl3.TabIndex = 767
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6, Me.BandedGridView5, Me.CardView5, Me.GridView7, Me.BandedGridView6, Me.WinExplorerView5, Me.TileView3, Me.WinExplorerView6, Me.AdvBandedGridView3, Me.CardView6})
        '
        'GridView6
        '
        Me.GridView6.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.Appearance.FixedLine.Options.UseFont = True
        Me.GridView6.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView6.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue
        Me.GridView6.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView6.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
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
        Me.GridView6.OptionsView.ShowFooter = True
        Me.GridView6.OptionsView.ShowGroupPanel = False
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
        'Frm_ShiftEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1319, 523)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Frm_ShiftEmp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "أكواد الورديات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txt_ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.TimeEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txt_ShiftName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_shiftNo As System.Windows.Forms.TextBox
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
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
    Friend WithEvents Cmd_NewJobOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Edit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_Delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TimeEdit2 As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TimeEdit1 As DevExpress.XtraEditors.TimeEdit
End Class
