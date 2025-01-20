<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SettingCostNoneDiract
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SettingCostNoneDiract))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_save = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_New = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.DataGridView2 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txt_TotalDay = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txt_TotalLoading = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txt_totalHoure = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_Delete)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_save)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_New)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1906, 591)
        Me.SplitContainerControl1.SplitterPosition = 37
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Green
        Me.LabelX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX4.Location = New System.Drawing.Point(1206, 0)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(344, 37)
        Me.LabelX4.TabIndex = 909
        Me.LabelX4.Text = "اضغط مرتين بالماوس لأختيار البند المطلوب حذفه"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Appearance.Options.UseFont = True
        Me.Cmd_Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(1550, 0)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(118, 37)
        Me.Cmd_Delete.TabIndex = 891
        Me.Cmd_Delete.Text = "حذف سطر"
        Me.Cmd_Delete.ToolTip = "حذف"
        '
        'Cmd_save
        '
        Me.Cmd_save.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_save.Appearance.Options.UseFont = True
        Me.Cmd_save.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_save.Image = CType(resources.GetObject("Cmd_save.Image"), System.Drawing.Image)
        Me.Cmd_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_save.Location = New System.Drawing.Point(1668, 0)
        Me.Cmd_save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_save.Name = "Cmd_save"
        Me.Cmd_save.Size = New System.Drawing.Size(116, 37)
        Me.Cmd_save.TabIndex = 890
        Me.Cmd_save.Text = "حفظ الكل"
        Me.Cmd_save.ToolTip = "حفظ"
        '
        'Cmd_New
        '
        Me.Cmd_New.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_New.Appearance.Options.UseFont = True
        Me.Cmd_New.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_New.Image = CType(resources.GetObject("Cmd_New.Image"), System.Drawing.Image)
        Me.Cmd_New.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_New.Location = New System.Drawing.Point(1784, 0)
        Me.Cmd_New.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_New.Name = "Cmd_New"
        Me.Cmd_New.Size = New System.Drawing.Size(122, 37)
        Me.Cmd_New.TabIndex = 889
        Me.Cmd_New.Text = "بند جديد"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.DataGridView2)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.TextBoxX1)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelX1)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelX9)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.txt_TotalDay)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelX2)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.txt_TotalLoading)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelX3)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.txt_totalHoure)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1906, 548)
        Me.SplitContainerControl2.SplitterPosition = 452
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'DataGridView2
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11, Me.Column1, Me.Column2, Me.Column6, Me.Column7, Me.Column3, Me.Column4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.Size = New System.Drawing.Size(1906, 452)
        Me.DataGridView2.TabIndex = 390
        '
        'Column11
        '
        Me.Column11.HeaderText = "الادارة"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 250
        '
        'Column1
        '
        Me.Column1.FillWeight = 50.0!
        Me.Column1.HeaderText = "بند التكاليف الغير مباشرة"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 200
        '
        'Column2
        '
        Me.Column2.FillWeight = 75.0!
        Me.Column2.HeaderText = "التكلفة الشهرية"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "نسبة التحميل"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 50
        '
        'Column7
        '
        Me.Column7.HeaderText = "القيمة بعد التحميل"
        Me.Column7.Name = "Column7"
        '
        'Column3
        '
        Me.Column3.HeaderText = "تكلفة اليوم"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "تكلفة الساعة"
        Me.Column4.Name = "Column4"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.ButtonCustom.Tooltip = ""
        Me.TextBoxX1.ButtonCustom2.Tooltip = ""
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(1152, 14)
        Me.TextBoxX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxX1.MaxLength = 3
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ReadOnly = True
        Me.TextBoxX1.Size = New System.Drawing.Size(118, 26)
        Me.TextBoxX1.TabIndex = 513
        Me.TextBoxX1.Text = "0"
        Me.TextBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxX1.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(1276, 14)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(170, 25)
        Me.LabelX1.TabIndex = 512
        Me.LabelX1.Text = "اجمالى التكلفة الشهرية"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(380, 17)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(147, 23)
        Me.LabelX9.TabIndex = 511
        Me.LabelX9.Text = "اجمالى تكلفة الساعة"
        '
        'txt_TotalDay
        '
        Me.txt_TotalDay.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txt_TotalDay.Border.Class = "TextBoxBorder"
        Me.txt_TotalDay.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_TotalDay.ButtonCustom.Tooltip = ""
        Me.txt_TotalDay.ButtonCustom2.Tooltip = ""
        Me.txt_TotalDay.DisabledBackColor = System.Drawing.Color.White
        Me.txt_TotalDay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalDay.ForeColor = System.Drawing.Color.Black
        Me.txt_TotalDay.Location = New System.Drawing.Point(547, 14)
        Me.txt_TotalDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TotalDay.Name = "txt_TotalDay"
        Me.txt_TotalDay.PreventEnterBeep = True
        Me.txt_TotalDay.ReadOnly = True
        Me.txt_TotalDay.Size = New System.Drawing.Size(118, 26)
        Me.txt_TotalDay.TabIndex = 510
        Me.txt_TotalDay.Text = "0"
        Me.txt_TotalDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(683, 17)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(136, 23)
        Me.LabelX2.TabIndex = 509
        Me.LabelX2.Text = "اجمالى تكلفة اليوم"
        '
        'txt_TotalLoading
        '
        Me.txt_TotalLoading.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txt_TotalLoading.Border.Class = "TextBoxBorder"
        Me.txt_TotalLoading.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_TotalLoading.ButtonCustom.Tooltip = ""
        Me.txt_TotalLoading.ButtonCustom2.Tooltip = ""
        Me.txt_TotalLoading.DisabledBackColor = System.Drawing.Color.White
        Me.txt_TotalLoading.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalLoading.ForeColor = System.Drawing.Color.Black
        Me.txt_TotalLoading.Location = New System.Drawing.Point(843, 14)
        Me.txt_TotalLoading.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TotalLoading.MaxLength = 3
        Me.txt_TotalLoading.Name = "txt_TotalLoading"
        Me.txt_TotalLoading.PreventEnterBeep = True
        Me.txt_TotalLoading.ReadOnly = True
        Me.txt_TotalLoading.Size = New System.Drawing.Size(118, 26)
        Me.txt_TotalLoading.TabIndex = 508
        Me.txt_TotalLoading.Text = "0"
        Me.txt_TotalLoading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_TotalLoading.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(980, 20)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(146, 23)
        Me.LabelX3.TabIndex = 507
        Me.LabelX3.Text = "اجمالى قيمة التحميل"
        '
        'txt_totalHoure
        '
        Me.txt_totalHoure.BackColor = System.Drawing.SystemColors.ScrollBar
        '
        '
        '
        Me.txt_totalHoure.Border.Class = "TextBoxBorder"
        Me.txt_totalHoure.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_totalHoure.ButtonCustom.Tooltip = ""
        Me.txt_totalHoure.ButtonCustom2.Tooltip = ""
        Me.txt_totalHoure.DisabledBackColor = System.Drawing.Color.White
        Me.txt_totalHoure.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalHoure.ForeColor = System.Drawing.Color.Black
        Me.txt_totalHoure.Location = New System.Drawing.Point(248, 17)
        Me.txt_totalHoure.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_totalHoure.Name = "txt_totalHoure"
        Me.txt_totalHoure.PreventEnterBeep = True
        Me.txt_totalHoure.ReadOnly = True
        Me.txt_totalHoure.Size = New System.Drawing.Size(115, 26)
        Me.txt_totalHoure.TabIndex = 506
        Me.txt_totalHoure.Text = "0"
        Me.txt_totalHoure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_SettingCostNoneDiract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1906, 591)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "Frm_SettingCostNoneDiract"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "بنود التكاليف الغير مباشرة"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Cmd_Delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_New As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents DataGridView2 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_TotalDay As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_TotalLoading As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_totalHoure As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
