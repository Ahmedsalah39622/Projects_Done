<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GL2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GL2))
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Cmd_Print = New DevExpress.XtraEditors.SimpleButton()
        Me.CardView6 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.BandedGridView5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Cmd_New = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date = New System.Windows.Forms.DateTimePicker()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Cridit = New System.Windows.Forms.TextBox()
        Me.Com_CostCenter = New System.Windows.Forms.ComboBox()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txt_NameAccount1 = New System.Windows.Forms.TextBox()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.txt_AccountNo1 = New System.Windows.Forms.TextBox()
        Me.txt_Notes = New System.Windows.Forms.TextBox()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Debit = New System.Windows.Forms.TextBox()
        Me.SimpleButton14 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton15 = New DevExpress.XtraEditors.SimpleButton()
        Me.Com_GL_No = New System.Windows.Forms.ComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Typeinv = New System.Windows.Forms.TextBox()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Cr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txt_De = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Appearance.Options.UseFont = True
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(533, 450)
        Me.Cmd_Print.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 32)
        Me.Cmd_Print.TabIndex = 892
        Me.Cmd_Print.Text = "معاينة قبل الطباعة"
        '
        'CardView6
        '
        Me.CardView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView6.FocusedCardTopFieldIndex = 0
        Me.CardView6.GridControl = Me.GridControl3
        Me.CardView6.Name = "CardView6"
        '
        'GridControl3
        '
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode2.RelationName = "Level1"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.GridControl3.Location = New System.Drawing.Point(90, 129)
        Me.GridControl3.MainView = Me.GridView6
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(947, 307)
        Me.GridControl3.TabIndex = 891
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6, Me.CardView5, Me.GridView7, Me.BandedGridView6, Me.WinExplorerView5, Me.TileView3, Me.WinExplorerView6, Me.AdvBandedGridView3, Me.BandedGridView5, Me.CardView6})
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
        Me.GridView6.OptionsView.ShowGroupPanel = False
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
        'Cmd_New
        '
        Me.Cmd_New.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_New.Appearance.Options.UseFont = True
        Me.Cmd_New.Image = CType(resources.GetObject("Cmd_New.Image"), System.Drawing.Image)
        Me.Cmd_New.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_New.Location = New System.Drawing.Point(932, 450)
        Me.Cmd_New.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_New.Name = "Cmd_New"
        Me.Cmd_New.Size = New System.Drawing.Size(103, 32)
        Me.Cmd_New.TabIndex = 893
        Me.Cmd_New.Text = "جديد"
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(974, 43)
        Me.LabelX24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(58, 19)
        Me.LabelX24.TabIndex = 880
        Me.LabelX24.Text = "من تاريخ"
        '
        'txt_date
        '
        Me.txt_date.Location = New System.Drawing.Point(815, 42)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(130, 20)
        Me.txt_date.TabIndex = 879
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(974, 20)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 19)
        Me.LabelX2.TabIndex = 885
        Me.LabelX2.Text = "رقم القيد"
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Image = CType(resources.GetObject("SimpleButton9.Image"), System.Drawing.Image)
        Me.SimpleButton9.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton9.Location = New System.Drawing.Point(196, 105)
        Me.SimpleButton9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(35, 18)
        Me.SimpleButton9.TabIndex = 897
        Me.SimpleButton9.ToolTip = "بحث"
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Image = CType(resources.GetObject("SimpleButton8.Image"), System.Drawing.Image)
        Me.SimpleButton8.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton8.Location = New System.Drawing.Point(160, 105)
        Me.SimpleButton8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(35, 17)
        Me.SimpleButton8.TabIndex = 896
        Me.SimpleButton8.ToolTip = "حذف"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Image = CType(resources.GetObject("SimpleButton7.Image"), System.Drawing.Image)
        Me.SimpleButton7.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton7.Location = New System.Drawing.Point(123, 105)
        Me.SimpleButton7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(32, 17)
        Me.SimpleButton7.TabIndex = 895
        Me.SimpleButton7.ToolTip = "تعديل"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Image = CType(resources.GetObject("SimpleButton5.Image"), System.Drawing.Image)
        Me.SimpleButton5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton5.Location = New System.Drawing.Point(90, 105)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(28, 20)
        Me.SimpleButton5.TabIndex = 894
        Me.SimpleButton5.ToolTip = "حفظ"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(433, 75)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(57, 19)
        Me.LabelX10.TabIndex = 908
        Me.LabelX10.Text = "دائن"
        '
        'txt_Cridit
        '
        Me.txt_Cridit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cridit.Location = New System.Drawing.Point(407, 99)
        Me.txt_Cridit.Name = "txt_Cridit"
        Me.txt_Cridit.Size = New System.Drawing.Size(83, 22)
        Me.txt_Cridit.TabIndex = 907
        '
        'Com_CostCenter
        '
        Me.Com_CostCenter.ForeColor = System.Drawing.Color.Black
        Me.Com_CostCenter.FormattingEnabled = True
        Me.Com_CostCenter.Location = New System.Drawing.Point(250, 101)
        Me.Com_CostCenter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_CostCenter.Name = "Com_CostCenter"
        Me.Com_CostCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Com_CostCenter.Size = New System.Drawing.Size(151, 21)
        Me.Com_CostCenter.TabIndex = 906
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(791, 76)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(88, 22)
        Me.LabelX9.TabIndex = 905
        Me.LabelX9.Text = "اسم الحساب"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(326, 74)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 22)
        Me.LabelX8.TabIndex = 904
        Me.LabelX8.Text = "مركز التكلفة"
        '
        'txt_NameAccount1
        '
        Me.txt_NameAccount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NameAccount1.Location = New System.Drawing.Point(771, 101)
        Me.txt_NameAccount1.Name = "txt_NameAccount1"
        Me.txt_NameAccount1.ReadOnly = True
        Me.txt_NameAccount1.Size = New System.Drawing.Size(130, 20)
        Me.txt_NameAccount1.TabIndex = 903
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(907, 73)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(74, 22)
        Me.LabelX11.TabIndex = 902
        Me.LabelX11.Text = "رقم الحساب"
        '
        'txt_AccountNo1
        '
        Me.txt_AccountNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AccountNo1.Location = New System.Drawing.Point(907, 102)
        Me.txt_AccountNo1.Name = "txt_AccountNo1"
        Me.txt_AccountNo1.ReadOnly = True
        Me.txt_AccountNo1.Size = New System.Drawing.Size(74, 20)
        Me.txt_AccountNo1.TabIndex = 901
        '
        'txt_Notes
        '
        Me.txt_Notes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Notes.Location = New System.Drawing.Point(585, 101)
        Me.txt_Notes.Multiline = True
        Me.txt_Notes.Name = "txt_Notes"
        Me.txt_Notes.Size = New System.Drawing.Size(180, 21)
        Me.txt_Notes.TabIndex = 900
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(522, 76)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(57, 19)
        Me.LabelX7.TabIndex = 899
        Me.LabelX7.Text = "مدين"
        '
        'txt_Debit
        '
        Me.txt_Debit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Debit.Location = New System.Drawing.Point(496, 100)
        Me.txt_Debit.Name = "txt_Debit"
        Me.txt_Debit.Size = New System.Drawing.Size(83, 22)
        Me.txt_Debit.TabIndex = 898
        '
        'SimpleButton14
        '
        Me.SimpleButton14.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton14.Appearance.Options.UseFont = True
        Me.SimpleButton14.Image = CType(resources.GetObject("SimpleButton14.Image"), System.Drawing.Image)
        Me.SimpleButton14.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton14.Location = New System.Drawing.Point(806, 450)
        Me.SimpleButton14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton14.Name = "SimpleButton14"
        Me.SimpleButton14.Size = New System.Drawing.Size(120, 32)
        Me.SimpleButton14.TabIndex = 910
        Me.SimpleButton14.Text = "إغلاق  القيد"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton3.Location = New System.Drawing.Point(683, 450)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(117, 32)
        Me.SimpleButton3.TabIndex = 909
        Me.SimpleButton3.Text = "ارجاع القيد"
        '
        'SimpleButton15
        '
        Me.SimpleButton15.Image = CType(resources.GetObject("SimpleButton15.Image"), System.Drawing.Image)
        Me.SimpleButton15.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton15.Location = New System.Drawing.Point(771, 17)
        Me.SimpleButton15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton15.Name = "SimpleButton15"
        Me.SimpleButton15.Size = New System.Drawing.Size(40, 22)
        Me.SimpleButton15.TabIndex = 913
        '
        'Com_GL_No
        '
        Me.Com_GL_No.ForeColor = System.Drawing.Color.Red
        Me.Com_GL_No.FormattingEnabled = True
        Me.Com_GL_No.Location = New System.Drawing.Point(815, 15)
        Me.Com_GL_No.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_GL_No.Name = "Com_GL_No"
        Me.Com_GL_No.Size = New System.Drawing.Size(130, 21)
        Me.Com_GL_No.TabIndex = 912
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(585, 77)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(180, 19)
        Me.LabelX1.TabIndex = 914
        Me.LabelX1.Text = "البيـــــــــــــــــــــــــــــان"
        '
        'txt_Typeinv
        '
        Me.txt_Typeinv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Typeinv.Location = New System.Drawing.Point(90, 21)
        Me.txt_Typeinv.Name = "txt_Typeinv"
        Me.txt_Typeinv.ReadOnly = True
        Me.txt_Typeinv.Size = New System.Drawing.Size(106, 20)
        Me.txt_Typeinv.TabIndex = 916
        Me.txt_Typeinv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.Location = New System.Drawing.Point(202, 20)
        Me.LabelX25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(68, 20)
        Me.LabelX25.TabIndex = 915
        Me.LabelX25.Text = "حالة القيد"
        '
        'txt_Cr
        '
        Me.txt_Cr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txt_Cr.Border.Class = "TextBoxBorder"
        Me.txt_Cr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_Cr.ButtonCustom.Tooltip = ""
        Me.txt_Cr.ButtonCustom2.Tooltip = ""
        Me.txt_Cr.DisabledBackColor = System.Drawing.Color.White
        Me.txt_Cr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Cr.ForeColor = System.Drawing.Color.Black
        Me.txt_Cr.Location = New System.Drawing.Point(95, 456)
        Me.txt_Cr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Cr.Name = "txt_Cr"
        Me.txt_Cr.PreventEnterBeep = True
        Me.txt_Cr.ReadOnly = True
        Me.txt_Cr.Size = New System.Drawing.Size(101, 22)
        Me.txt_Cr.TabIndex = 920
        Me.txt_Cr.Text = "0"
        Me.txt_Cr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(204, 456)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(81, 19)
        Me.LabelX3.TabIndex = 919
        Me.LabelX3.Text = "إجمالى الدائن"
        '
        'txt_De
        '
        Me.txt_De.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txt_De.Border.Class = "TextBoxBorder"
        Me.txt_De.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_De.ButtonCustom.Tooltip = ""
        Me.txt_De.ButtonCustom2.Tooltip = ""
        Me.txt_De.DisabledBackColor = System.Drawing.Color.White
        Me.txt_De.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_De.ForeColor = System.Drawing.Color.Black
        Me.txt_De.Location = New System.Drawing.Point(288, 457)
        Me.txt_De.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_De.MaxLength = 3
        Me.txt_De.Name = "txt_De"
        Me.txt_De.PreventEnterBeep = True
        Me.txt_De.ReadOnly = True
        Me.txt_De.Size = New System.Drawing.Size(101, 22)
        Me.txt_De.TabIndex = 918
        Me.txt_De.Text = "0"
        Me.txt_De.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_De.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(394, 457)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(87, 19)
        Me.LabelX4.TabIndex = 917
        Me.LabelX4.Text = "اجمالى المدين"
        '
        'Frm_GL2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 533)
        Me.Controls.Add(Me.txt_Cr)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txt_De)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txt_Typeinv)
        Me.Controls.Add(Me.LabelX25)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.SimpleButton15)
        Me.Controls.Add(Me.Com_GL_No)
        Me.Controls.Add(Me.SimpleButton14)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.txt_Cridit)
        Me.Controls.Add(Me.Com_CostCenter)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.txt_NameAccount1)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.txt_AccountNo1)
        Me.Controls.Add(Me.txt_Notes)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.txt_Debit)
        Me.Controls.Add(Me.SimpleButton9)
        Me.Controls.Add(Me.SimpleButton8)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_New)
        Me.Controls.Add(Me.GridControl3)
        Me.Controls.Add(Me.LabelX24)
        Me.Controls.Add(Me.txt_date)
        Me.Controls.Add(Me.LabelX2)
        Me.Name = "Frm_GL2"
        Me.Text = "قيود اليومية"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_Print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CardView6 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents BandedGridView5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Cmd_New As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Cridit As System.Windows.Forms.TextBox
    Friend WithEvents Com_CostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_NameAccount1 As System.Windows.Forms.TextBox
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_AccountNo1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Notes As System.Windows.Forms.TextBox
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Debit As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton14 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton15 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Com_GL_No As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Typeinv As System.Windows.Forms.TextBox
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Cr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_De As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
