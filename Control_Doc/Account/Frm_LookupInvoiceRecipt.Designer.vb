﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LookupInvoiceRecipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LookupInvoiceRecipt))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_OpenInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_InvoiceNo = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_CustomerName = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
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
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX40)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_OpenInvoice)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_InvoiceNo)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_CustomerName)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX5)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1242, 478)
        Me.SplitContainerControl1.SplitterPosition = 38
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelX40
        '
        '
        '
        '
        Me.LabelX40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX40.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX40.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX40.ForeColor = System.Drawing.Color.Green
        Me.LabelX40.Location = New System.Drawing.Point(173, 0)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabelX40.Size = New System.Drawing.Size(308, 38)
        Me.LabelX40.TabIndex = 1001
        Me.LabelX40.Text = "اضغط مرتين بالماوس لفتح بيانات الفاتورة"
        '
        'Cmd_OpenInvoice
        '
        Me.Cmd_OpenInvoice.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_OpenInvoice.Appearance.Options.UseFont = True
        Me.Cmd_OpenInvoice.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_OpenInvoice.Enabled = False
        Me.Cmd_OpenInvoice.Image = CType(resources.GetObject("Cmd_OpenInvoice.Image"), System.Drawing.Image)
        Me.Cmd_OpenInvoice.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_OpenInvoice.Location = New System.Drawing.Point(481, 0)
        Me.Cmd_OpenInvoice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_OpenInvoice.Name = "Cmd_OpenInvoice"
        Me.Cmd_OpenInvoice.Size = New System.Drawing.Size(154, 38)
        Me.Cmd_OpenInvoice.TabIndex = 1000
        Me.Cmd_OpenInvoice.Text = "فتح بيانات الفاتورة"
        '
        'txt_InvoiceNo
        '
        Me.txt_InvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_InvoiceNo.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_InvoiceNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_InvoiceNo.Location = New System.Drawing.Point(635, 0)
        Me.txt_InvoiceNo.Multiline = True
        Me.txt_InvoiceNo.Name = "txt_InvoiceNo"
        Me.txt_InvoiceNo.Size = New System.Drawing.Size(105, 38)
        Me.txt_InvoiceNo.TabIndex = 999
        Me.txt_InvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(740, 0)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabelX1.Size = New System.Drawing.Size(88, 38)
        Me.LabelX1.TabIndex = 998
        Me.LabelX1.Text = "رقم الفاتورة"
        '
        'txt_CustomerName
        '
        Me.txt_CustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CustomerName.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_CustomerName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CustomerName.Location = New System.Drawing.Point(828, 0)
        Me.txt_CustomerName.Multiline = True
        Me.txt_CustomerName.Name = "txt_CustomerName"
        Me.txt_CustomerName.Size = New System.Drawing.Size(298, 38)
        Me.txt_CustomerName.TabIndex = 997
        Me.txt_CustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(1126, 0)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabelX5.Size = New System.Drawing.Size(116, 38)
        Me.LabelX5.TabIndex = 996
        Me.LabelX5.Text = "اسم العميل"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1242, 435)
        Me.GridControl1.TabIndex = 775
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.BandedGridView1, Me.CardView1, Me.GridView2, Me.BandedGridView2, Me.WinExplorerView1, Me.TileView1, Me.WinExplorerView2, Me.AdvBandedGridView1, Me.CardView2})
        '
        'GridView1
        '
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 781.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FixedLine.FontSizeDelta = 5
        Me.GridView1.Appearance.FixedLine.Options.UseFont = True
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GridView1.GridControl = Me.GridControl1
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
        'Frm_LookupInvoiceRecipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 478)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "Frm_LookupInvoiceRecipt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فواتير العميل"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
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
    Friend WithEvents txt_InvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_CustomerName As System.Windows.Forms.TextBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_OpenInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
End Class
