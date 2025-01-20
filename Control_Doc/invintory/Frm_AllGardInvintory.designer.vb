<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AllGardInvintory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AllGardInvintory))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Lab_Titil = New DevComponents.DotNetBar.LabelX()
        Me.SplitContainerControl5 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl8 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Cmd_Close = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.VwallGard2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        'Me.DB_KAISSY_NewDataSet = New Control_Doc.DB_KAISSY_NewDataSet()
        Me.fieldName1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldNameItem1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldUnit21 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldBalance21 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldBalance11 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField()
        'Me.Vw_all_Gard2TableAdapter = New Control_Doc.DB_KAISSY_NewDataSetTableAdapters.vw_all_Gard2TableAdapter()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl5.SuspendLayout()
        CType(Me.SplitContainerControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl8.SuspendLayout()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwallGard2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.DB_KAISSY_NewDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitContainerControl1.Panel1.Appearance.Options.UseBackColor = True
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Lab_Titil)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl5)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1547, 872)
        Me.SplitContainerControl1.SplitterPosition = 43
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Lab_Titil
        '
        Me.Lab_Titil.BackColor = System.Drawing.Color.Silver
        '
        '
        '
        Me.Lab_Titil.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lab_Titil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lab_Titil.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Titil.ForeColor = System.Drawing.Color.Black
        Me.Lab_Titil.Location = New System.Drawing.Point(0, 0)
        Me.Lab_Titil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Lab_Titil.Name = "Lab_Titil"
        Me.Lab_Titil.Size = New System.Drawing.Size(1547, 43)
        Me.Lab_Titil.TabIndex = 1056
        Me.Lab_Titil.Text = "جرد مجمع المخازن"
        Me.Lab_Titil.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'SplitContainerControl5
        '
        Me.SplitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl5.Horizontal = False
        Me.SplitContainerControl5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl5.Name = "SplitContainerControl5"
        Me.SplitContainerControl5.Panel1.Text = "Panel1"
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.SplitContainerControl8)
        Me.SplitContainerControl5.Panel2.Text = "Panel2"
        Me.SplitContainerControl5.Size = New System.Drawing.Size(1547, 823)
        Me.SplitContainerControl5.SplitterPosition = 37
        Me.SplitContainerControl5.TabIndex = 1
        Me.SplitContainerControl5.Text = "SplitContainerControl5"
        '
        'SplitContainerControl8
        '
        Me.SplitContainerControl8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl8.Horizontal = False
        Me.SplitContainerControl8.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl8.Name = "SplitContainerControl8"
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.Cmd_Close)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.SimpleButton4)
        Me.SplitContainerControl8.Panel1.Text = "Panel1"
        Me.SplitContainerControl8.Panel2.Controls.Add(Me.TabPane1)
        Me.SplitContainerControl8.Panel2.Text = "Panel2"
        Me.SplitContainerControl8.Size = New System.Drawing.Size(1547, 780)
        Me.SplitContainerControl8.SplitterPosition = 54
        Me.SplitContainerControl8.TabIndex = 0
        Me.SplitContainerControl8.Text = "SplitContainerControl8"
        '
        'Cmd_Close
        '
        Me.Cmd_Close.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Close.Appearance.Options.UseFont = True
        Me.Cmd_Close.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Close.Image = CType(resources.GetObject("Cmd_Close.Image"), System.Drawing.Image)
        Me.Cmd_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Close.Location = New System.Drawing.Point(1205, 0)
        Me.Cmd_Close.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(146, 54)
        Me.Cmd_Close.TabIndex = 1125
        Me.Cmd_Close.Text = "إغلاق"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton4.Appearance.Options.UseFont = True
        Me.SimpleButton4.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton4.Location = New System.Drawing.Point(1351, 0)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(196, 54)
        Me.SimpleButton4.TabIndex = 1124
        Me.SimpleButton4.Text = "طباعة معاينة الجدول"
        '
        'TabPane1
        '
        Me.TabPane1.AppearanceButton.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPane1.AppearanceButton.Normal.Options.UseFont = True
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPane1.Location = New System.Drawing.Point(0, 0)
        Me.TabPane1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1547, 720)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.SelectedPageIndex = 0
        Me.TabPane1.Size = New System.Drawing.Size(1547, 720)
        Me.TabPane1.TabIndex = 5
        Me.TabPane1.TransitionType = DevExpress.Utils.Animation.Transitions.Clock
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.AutoScroll = True
        Me.TabNavigationPage1.Caption = "معاينة جدول"
        Me.TabNavigationPage1.Controls.Add(Me.Panel3)
        Me.TabNavigationPage1.Image = CType(resources.GetObject("TabNavigationPage1.Image"), System.Drawing.Image)
        Me.TabNavigationPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1525, 648)
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.PivotGridControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1525, 648)
        Me.Panel3.TabIndex = 0
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Appearance.FilterHeaderArea.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = True
        Me.PivotGridControl1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.FocusedCell.Options.UseFont = True
        Me.PivotGridControl1.Appearance.GrandTotalCell.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = True
        Me.PivotGridControl1.AppearancePrint.Cell.BackColor = System.Drawing.Color.PaleTurquoise
        Me.PivotGridControl1.AppearancePrint.Cell.Options.UseBackColor = True
        Me.PivotGridControl1.AppearancePrint.FieldHeader.BackColor = System.Drawing.Color.LightBlue
        Me.PivotGridControl1.AppearancePrint.FieldHeader.Options.UseBackColor = True
        Me.PivotGridControl1.AppearancePrint.FieldValue.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.PivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = True
        Me.PivotGridControl1.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.PivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = True
        Me.PivotGridControl1.AppearancePrint.GrandTotalCell.BackColor = System.Drawing.Color.Black
        Me.PivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseBackColor = True
        Me.PivotGridControl1.DataSource = Me.VwallGard2BindingSource
        Me.PivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldName1, Me.fieldNameItem1, Me.fieldUnit21, Me.fieldBalance21, Me.fieldBalance11, Me.PivotGridField1})
        Me.PivotGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.OptionsBehavior.ApplyBestFitOnFieldDragging = True
        Me.PivotGridControl1.OptionsBehavior.BestFitConsiderCustomAppearance = True
        Me.PivotGridControl1.OptionsBehavior.SortBySummaryDefaultOrder = DevExpress.XtraPivotGrid.PivotSortBySummaryOrder.Ascending
        Me.PivotGridControl1.OptionsPrint.PageSettings.Landscape = True
        Me.PivotGridControl1.Size = New System.Drawing.Size(1525, 648)
        Me.PivotGridControl1.TabIndex = 0
        '
        'VwallGard2BindingSource
        '
        Me.VwallGard2BindingSource.DataMember = "vw_all_Gard2"
        'Me.VwallGard2BindingSource.DataSource = Me.DB_KAISSY_NewDataSet
        '
        'DB_KAISSY_NewDataSet
        '
        'Me.DB_KAISSY_NewDataSet.DataSetName = "DB_KAISSY_NewDataSet"
        'Me.DB_KAISSY_NewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'fieldName1
        '
        Me.fieldName1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fieldName1.Appearance.Header.Options.UseFont = True
        Me.fieldName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldName1.AreaIndex = 0
        Me.fieldName1.Caption = "المخزن"
        Me.fieldName1.FieldName = "Name"
        Me.fieldName1.Name = "fieldName1"
        '
        'fieldNameItem1
        '
        Me.fieldNameItem1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fieldNameItem1.Appearance.Header.Options.UseFont = True
        Me.fieldNameItem1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldNameItem1.AreaIndex = 0
        Me.fieldNameItem1.Caption = "الصنف"
        Me.fieldNameItem1.FieldName = "NameItem"
        Me.fieldNameItem1.Name = "fieldNameItem1"
        Me.fieldNameItem1.Width = 151
        '
        'fieldUnit21
        '
        Me.fieldUnit21.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fieldUnit21.Appearance.Header.Options.UseFont = True
        Me.fieldUnit21.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldUnit21.AreaIndex = 1
        Me.fieldUnit21.Caption = "وحدة 1"
        Me.fieldUnit21.FieldName = "Unit_2"
        Me.fieldUnit21.Name = "fieldUnit21"
        '
        'fieldBalance21
        '
        Me.fieldBalance21.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fieldBalance21.Appearance.Header.Options.UseFont = True
        Me.fieldBalance21.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldBalance21.AreaIndex = 0
        Me.fieldBalance21.Caption = "رصيد وحدة2"
        Me.fieldBalance21.FieldName = "Balance2"
        Me.fieldBalance21.Name = "fieldBalance21"
        Me.fieldBalance21.Width = 117
        '
        'fieldBalance11
        '
        Me.fieldBalance11.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fieldBalance11.Appearance.Header.Options.UseFont = True
        Me.fieldBalance11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldBalance11.AreaIndex = 1
        Me.fieldBalance11.Caption = "رصيد وحدة 1"
        Me.fieldBalance11.FieldName = "Balance1"
        Me.fieldBalance11.Name = "fieldBalance11"
        '
        'PivotGridField1
        '
        Me.PivotGridField1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridField1.Appearance.Header.Options.UseFont = True
        Me.PivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField1.AreaIndex = 2
        Me.PivotGridField1.Caption = "وحدة 2"
        Me.PivotGridField1.FieldName = "NameUnit2"
        Me.PivotGridField1.Name = "PivotGridField1"
        '
        'Vw_all_Gard2TableAdapter
        '
        'Me.Vw_all_Gard2TableAdapter.ClearBeforeFill = True
        '
        'Frm_AllGardInvintory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1547, 872)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "Frm_AllGardInvintory"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "جرد مجمع المخازن"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl5.ResumeLayout(False)
        CType(Me.SplitContainerControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl8.ResumeLayout(False)
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        Me.TabNavigationPage1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwallGard2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.DB_KAISSY_NewDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Lab_Titil As DevComponents.DotNetBar.LabelX
    Friend WithEvents SplitContainerControl5 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl8 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    'Friend WithEvents DB_KAISSY_NewDataSet As Control_Doc.DB_KAISSY_NewDataSet
    Friend WithEvents VwallGard2BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents Vw_all_Gard2TableAdapter As Control_Doc.DB_KAISSY_NewDataSetTableAdapters.vw_all_Gard2TableAdapter
    Friend WithEvents Cmd_Close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents fieldName1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldNameItem1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldUnit21 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldBalance21 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldBalance11 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
End Class
