<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPavitTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPavitTable))
        Me.DB_EpslonDataSet = New Control_Doc.DB_EpslonDataSet()
        Me.VwSalCustomerYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_Sal_CustomerYearTableAdapter = New Control_Doc.DB_EpslonDataSetTableAdapters.vw_Sal_CustomerYearTableAdapter()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Cmd_Close = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.fieldName1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldTotalSal1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldmm1 = New DevExpress.XtraPivotGrid.PivotGridField()
        CType(Me.DB_EpslonDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwSalCustomerYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DB_EpslonDataSet
        '
        Me.DB_EpslonDataSet.DataSetName = "DB_EpslonDataSet"
        Me.DB_EpslonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VwSalCustomerYearBindingSource
        '
        Me.VwSalCustomerYearBindingSource.DataMember = "vw_Sal_CustomerYear"
        Me.VwSalCustomerYearBindingSource.DataSource = Me.DB_EpslonDataSet
        '
        'Vw_Sal_CustomerYearTableAdapter
        '
        Me.Vw_Sal_CustomerYearTableAdapter.ClearBeforeFill = True
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_Close)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PivotGridControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1310, 512)
        Me.SplitContainerControl1.SplitterPosition = 48
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Cmd_Close
        '
        Me.Cmd_Close.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Close.Image = CType(resources.GetObject("Cmd_Close.Image"), System.Drawing.Image)
        Me.Cmd_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Close.Location = New System.Drawing.Point(979, 0)
        Me.Cmd_Close.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(146, 48)
        Me.Cmd_Close.TabIndex = 1048
        Me.Cmd_Close.Text = "إغلاق"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton1.Location = New System.Drawing.Point(1125, 0)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(185, 48)
        Me.SimpleButton1.TabIndex = 1047
        Me.SimpleButton1.Text = "معاينة قبل الطباعة"
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Appearance.Cell.BackColor = System.Drawing.Color.White
        Me.PivotGridControl1.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.Cell.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.Cell.Options.UseFont = True
        Me.PivotGridControl1.Appearance.ColumnHeaderArea.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PivotGridControl1.Appearance.FieldHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PivotGridControl1.Appearance.FieldHeader.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.FieldHeader.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.FieldHeader.Options.UseFont = True
        Me.PivotGridControl1.Appearance.FieldValue.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.FieldValue.Options.UseFont = True
        Me.PivotGridControl1.Appearance.FieldValue.Options.UseTextOptions = True
        Me.PivotGridControl1.Appearance.FieldValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Font = New System.Drawing.Font("Tahoma", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.FontStyleDelta = System.Drawing.FontStyle.Underline
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = True
        Me.PivotGridControl1.DataSource = Me.VwSalCustomerYearBindingSource
        Me.PivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldName1, Me.fieldTotalSal1, Me.fieldmm1})
        Me.PivotGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.OptionsBehavior.BestFitConsiderCustomAppearance = True
        Me.PivotGridControl1.Size = New System.Drawing.Size(1310, 458)
        Me.PivotGridControl1.TabIndex = 1
        '
        'fieldName1
        '
        Me.fieldName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldName1.AreaIndex = 0
        Me.fieldName1.Caption = "اسم العميل"
        Me.fieldName1.FieldName = "Name"
        Me.fieldName1.Name = "fieldName1"
        Me.fieldName1.Width = 312
        '
        'fieldTotalSal1
        '
        Me.fieldTotalSal1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldTotalSal1.AreaIndex = 0
        Me.fieldTotalSal1.Caption = "المبيعات"
        Me.fieldTotalSal1.FieldName = "Total_Sal"
        Me.fieldTotalSal1.Name = "fieldTotalSal1"
        '
        'fieldmm1
        '
        Me.fieldmm1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldmm1.AreaIndex = 0
        Me.fieldmm1.Caption = "الشهور"
        Me.fieldmm1.FieldName = "mm"
        Me.fieldmm1.Name = "fieldmm1"
        '
        'FrmPavitTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1310, 512)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmPavitTable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير مبيعات العملاء شهرى"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DB_EpslonDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwSalCustomerYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DB_EpslonDataSet As Control_Doc.DB_EpslonDataSet
    Friend WithEvents VwSalCustomerYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Vw_Sal_CustomerYearTableAdapter As Control_Doc.DB_EpslonDataSetTableAdapters.vw_Sal_CustomerYearTableAdapter
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents fieldName1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldTotalSal1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldmm1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents Cmd_Close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
