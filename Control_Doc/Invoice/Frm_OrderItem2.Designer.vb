<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OrderItem2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OrderItem2))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_New = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_OrderItem = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_unit = New System.Windows.Forms.TextBox()
        Me.txt_PONO = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.cmd_Edit = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_save = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.txt_CodeItem = New System.Windows.Forms.TextBox()
        Me.txt_Qty = New System.Windows.Forms.TextBox()
        Me.txt_NameItem = New System.Windows.Forms.TextBox()
        Me.Cmd_Cancle = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_OrderSal = New System.Windows.Forms.TextBox()
        Me.Cmd_FindOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.Com_InvoiceNo = New System.Windows.Forms.ComboBox()
        Me.Cmd_Print = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
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
        Me.CardView6 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.Com_InvoiceNo2 = New System.Windows.Forms.ComboBox()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Notes = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date = New System.Windows.Forms.DateTimePicker()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
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
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "رقم الصنف"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 70
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.HeaderText = "رقم الصنف"
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn3.Width = 70
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "رقم الصنف"
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 70
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.Cmd_New)
        Me.Panel1.Controls.Add(Me.Cmd_OrderItem)
        Me.Panel1.Controls.Add(Me.txt_unit)
        Me.Panel1.Controls.Add(Me.txt_PONO)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.Cmd_Delete)
        Me.Panel1.Controls.Add(Me.cmd_Edit)
        Me.Panel1.Controls.Add(Me.Cmd_save)
        Me.Panel1.Controls.Add(Me.LabelX17)
        Me.Panel1.Controls.Add(Me.LabelX16)
        Me.Panel1.Controls.Add(Me.LabelX15)
        Me.Panel1.Controls.Add(Me.txt_CodeItem)
        Me.Panel1.Controls.Add(Me.txt_Qty)
        Me.Panel1.Controls.Add(Me.txt_NameItem)
        Me.Panel1.Controls.Add(Me.Cmd_Cancle)
        Me.Panel1.Controls.Add(Me.txt_OrderSal)
        Me.Panel1.Controls.Add(Me.Cmd_FindOrder)
        Me.Panel1.Controls.Add(Me.Com_InvoiceNo)
        Me.Panel1.Controls.Add(Me.Cmd_Print)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.GridControl3)
        Me.Panel1.Controls.Add(Me.Com_InvoiceNo2)
        Me.Panel1.Controls.Add(Me.LabelX24)
        Me.Panel1.Controls.Add(Me.txt_Notes)
        Me.Panel1.Controls.Add(Me.LabelX10)
        Me.Panel1.Controls.Add(Me.txt_date)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1223, 464)
        Me.Panel1.TabIndex = 0
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Green
        Me.LabelX5.Location = New System.Drawing.Point(135, 383)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(205, 19)
        Me.LabelX5.TabIndex = 898
        Me.LabelX5.Text = "اضغط مرتين بالماوس لفتح الطلبية"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(370, 59)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(84, 19)
        Me.LabelX3.TabIndex = 897
        Me.LabelX3.Text = "رقم أمر الشراء"
        '
        'Cmd_New
        '
        Me.Cmd_New.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_New.Appearance.Options.UseFont = True
        Me.Cmd_New.Image = CType(resources.GetObject("Cmd_New.Image"), System.Drawing.Image)
        Me.Cmd_New.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_New.Location = New System.Drawing.Point(980, 392)
        Me.Cmd_New.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_New.Name = "Cmd_New"
        Me.Cmd_New.Size = New System.Drawing.Size(140, 32)
        Me.Cmd_New.TabIndex = 895
        Me.Cmd_New.Text = "طلب شراء جديد"
        '
        'Cmd_OrderItem
        '
        Me.Cmd_OrderItem.Image = CType(resources.GetObject("Cmd_OrderItem.Image"), System.Drawing.Image)
        Me.Cmd_OrderItem.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_OrderItem.Location = New System.Drawing.Point(284, 146)
        Me.Cmd_OrderItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_OrderItem.Name = "Cmd_OrderItem"
        Me.Cmd_OrderItem.Size = New System.Drawing.Size(292, 22)
        Me.Cmd_OrderItem.TabIndex = 894
        Me.Cmd_OrderItem.Text = "الاصناف المطلوب لها طلب شراء"
        '
        'txt_unit
        '
        Me.txt_unit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_unit.Location = New System.Drawing.Point(582, 147)
        Me.txt_unit.Name = "txt_unit"
        Me.txt_unit.Size = New System.Drawing.Size(53, 20)
        Me.txt_unit.TabIndex = 893
        Me.txt_unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_PONO
        '
        Me.txt_PONO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_PONO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PONO.Enabled = False
        Me.txt_PONO.Location = New System.Drawing.Point(267, 57)
        Me.txt_PONO.Name = "txt_PONO"
        Me.txt_PONO.Size = New System.Drawing.Size(97, 20)
        Me.txt_PONO.TabIndex = 896
        Me.txt_PONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(563, 59)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(84, 19)
        Me.LabelX1.TabIndex = 892
        Me.LabelX1.Text = "رقم الطلبية"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(171, 150)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(35, 17)
        Me.Cmd_Delete.TabIndex = 889
        Me.Cmd_Delete.ToolTip = "حذف"
        '
        'cmd_Edit
        '
        Me.cmd_Edit.Image = CType(resources.GetObject("cmd_Edit.Image"), System.Drawing.Image)
        Me.cmd_Edit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Edit.Location = New System.Drawing.Point(212, 149)
        Me.cmd_Edit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Edit.Name = "cmd_Edit"
        Me.cmd_Edit.Size = New System.Drawing.Size(32, 17)
        Me.cmd_Edit.TabIndex = 888
        Me.cmd_Edit.ToolTip = "تعديل"
        '
        'Cmd_save
        '
        Me.Cmd_save.Image = CType(resources.GetObject("Cmd_save.Image"), System.Drawing.Image)
        Me.Cmd_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_save.Location = New System.Drawing.Point(250, 148)
        Me.Cmd_save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_save.Name = "Cmd_save"
        Me.Cmd_save.Size = New System.Drawing.Size(28, 20)
        Me.Cmd_save.TabIndex = 887
        Me.Cmd_save.ToolTip = "حفظ"
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(641, 124)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(53, 19)
        Me.LabelX17.TabIndex = 886
        Me.LabelX17.Text = "الكمية"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(820, 124)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(190, 19)
        Me.LabelX16.TabIndex = 885
        Me.LabelX16.Text = "أسم الصنف"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(1020, 124)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(111, 19)
        Me.LabelX15.TabIndex = 884
        Me.LabelX15.Text = "رقم الصنف"
        '
        'txt_CodeItem
        '
        Me.txt_CodeItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CodeItem.Enabled = False
        Me.txt_CodeItem.Location = New System.Drawing.Point(1016, 148)
        Me.txt_CodeItem.Name = "txt_CodeItem"
        Me.txt_CodeItem.Size = New System.Drawing.Size(115, 20)
        Me.txt_CodeItem.TabIndex = 883
        Me.txt_CodeItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Qty
        '
        Me.txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Qty.Location = New System.Drawing.Point(641, 148)
        Me.txt_Qty.Name = "txt_Qty"
        Me.txt_Qty.Size = New System.Drawing.Size(53, 20)
        Me.txt_Qty.TabIndex = 882
        Me.txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_NameItem
        '
        Me.txt_NameItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NameItem.Enabled = False
        Me.txt_NameItem.Location = New System.Drawing.Point(700, 148)
        Me.txt_NameItem.Name = "txt_NameItem"
        Me.txt_NameItem.Size = New System.Drawing.Size(310, 20)
        Me.txt_NameItem.TabIndex = 881
        Me.txt_NameItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cmd_Cancle
        '
        Me.Cmd_Cancle.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Cancle.Appearance.Options.UseFont = True
        Me.Cmd_Cancle.Image = CType(resources.GetObject("Cmd_Cancle.Image"), System.Drawing.Image)
        Me.Cmd_Cancle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Cancle.Location = New System.Drawing.Point(832, 392)
        Me.Cmd_Cancle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Cancle.Name = "Cmd_Cancle"
        Me.Cmd_Cancle.Size = New System.Drawing.Size(142, 32)
        Me.Cmd_Cancle.TabIndex = 880
        Me.Cmd_Cancle.Text = "الغاء طلب الشراء"
        '
        'txt_OrderSal
        '
        Me.txt_OrderSal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_OrderSal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_OrderSal.Enabled = False
        Me.txt_OrderSal.Location = New System.Drawing.Point(460, 57)
        Me.txt_OrderSal.Name = "txt_OrderSal"
        Me.txt_OrderSal.Size = New System.Drawing.Size(97, 20)
        Me.txt_OrderSal.TabIndex = 891
        Me.txt_OrderSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cmd_FindOrder
        '
        Me.Cmd_FindOrder.Image = CType(resources.GetObject("Cmd_FindOrder.Image"), System.Drawing.Image)
        Me.Cmd_FindOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_FindOrder.Location = New System.Drawing.Point(868, 59)
        Me.Cmd_FindOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_FindOrder.Name = "Cmd_FindOrder"
        Me.Cmd_FindOrder.Size = New System.Drawing.Size(40, 22)
        Me.Cmd_FindOrder.TabIndex = 879
        '
        'Com_InvoiceNo
        '
        Me.Com_InvoiceNo.FormattingEnabled = True
        Me.Com_InvoiceNo.Location = New System.Drawing.Point(913, 33)
        Me.Com_InvoiceNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_InvoiceNo.Name = "Com_InvoiceNo"
        Me.Com_InvoiceNo.Size = New System.Drawing.Size(130, 21)
        Me.Com_InvoiceNo.TabIndex = 877
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Appearance.Options.UseFont = True
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(682, 392)
        Me.Cmd_Print.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 32)
        Me.Cmd_Print.TabIndex = 876
        Me.Cmd_Print.Text = "معاينة قبل الطباعة"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(582, 124)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(53, 19)
        Me.LabelX2.TabIndex = 890
        Me.LabelX2.Text = "الوحدة"
        '
        'GridControl3
        '
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl3.Location = New System.Drawing.Point(135, 173)
        Me.GridControl3.MainView = Me.GridView6
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(996, 206)
        Me.GridControl3.TabIndex = 878
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
        'CardView6
        '
        Me.CardView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.CardView6.FocusedCardTopFieldIndex = 0
        Me.CardView6.GridControl = Me.GridControl3
        Me.CardView6.Name = "CardView6"
        '
        'Com_InvoiceNo2
        '
        Me.Com_InvoiceNo2.ForeColor = System.Drawing.Color.Red
        Me.Com_InvoiceNo2.FormattingEnabled = True
        Me.Com_InvoiceNo2.Location = New System.Drawing.Point(912, 57)
        Me.Com_InvoiceNo2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_InvoiceNo2.Name = "Com_InvoiceNo2"
        Me.Com_InvoiceNo2.Size = New System.Drawing.Size(130, 21)
        Me.Com_InvoiceNo2.TabIndex = 875
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(1057, 58)
        Me.LabelX24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(74, 19)
        Me.LabelX24.TabIndex = 874
        Me.LabelX24.Text = "رقم الطلب"
        '
        'txt_Notes
        '
        Me.txt_Notes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txt_Notes.Border.Class = "TextBoxBorder"
        Me.txt_Notes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_Notes.ButtonCustom.Tooltip = ""
        Me.txt_Notes.ButtonCustom2.Tooltip = ""
        Me.txt_Notes.DisabledBackColor = System.Drawing.Color.White
        Me.txt_Notes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Notes.ForeColor = System.Drawing.Color.Black
        Me.txt_Notes.Location = New System.Drawing.Point(267, 85)
        Me.txt_Notes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Notes.Name = "txt_Notes"
        Me.txt_Notes.PreventEnterBeep = True
        Me.txt_Notes.Size = New System.Drawing.Size(775, 22)
        Me.txt_Notes.TabIndex = 873
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(1047, 88)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(84, 19)
        Me.LabelX10.TabIndex = 872
        Me.LabelX10.Text = "ملاحظات"
        '
        'txt_date
        '
        Me.txt_date.Location = New System.Drawing.Point(664, 60)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(115, 20)
        Me.txt_date.TabIndex = 871
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(785, 60)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(77, 19)
        Me.LabelX4.TabIndex = 870
        Me.LabelX4.Text = "تاريخ الطلب"
        '
        'Frm_OrderItem2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 464)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_OrderItem2"
        Me.Text = "طلب شراء"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        CType(Me.CardView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_New As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_OrderItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_unit As System.Windows.Forms.TextBox
    Friend WithEvents txt_PONO As System.Windows.Forms.TextBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_Delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Edit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_CodeItem As System.Windows.Forms.TextBox
    Friend WithEvents txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents txt_NameItem As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Cancle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_OrderSal As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_FindOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Com_InvoiceNo As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
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
    Friend WithEvents CardView6 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents Com_InvoiceNo2 As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Notes As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
