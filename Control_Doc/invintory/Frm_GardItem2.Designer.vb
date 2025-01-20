<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GardItem2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GardItem2))
        Me.DataGridView2 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_Balance = New System.Windows.Forms.TextBox()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Cr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txt_De = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txt_total = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl5 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txt_NameItem = New System.Windows.Forms.TextBox()
        Me.txt_codeItem = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date2 = New System.Windows.Forms.DateTimePicker()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date1 = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Com_Stores = New System.Windows.Forms.ComboBox()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.SimpleButton11 = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Print = New DevExpress.XtraEditors.SimpleButton()
        Me.cmd_Find = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl5.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column3, Me.Column1, Me.Column11, Me.Column2, Me.Column4, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.Size = New System.Drawing.Size(1428, 433)
        Me.DataGridView2.TabIndex = 475
        '
        'Column5
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "رقم الحركة"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 80
        '
        'Column3
        '
        '
        '
        '
        Me.Column3.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Column3.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.Column3.ButtonClear.Tooltip = ""
        Me.Column3.ButtonCustom.Tooltip = ""
        Me.Column3.ButtonCustom2.Tooltip = ""
        Me.Column3.ButtonDropDown.Tooltip = ""
        Me.Column3.ButtonFreeText.Tooltip = ""
        Me.Column3.CustomFormat = """dd/mm/yyyy"""
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column3.HeaderText = "التاريخ"
        Me.Column3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        '
        '
        '
        Me.Column3.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Column3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.Column3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.Column3.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Column3.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Column3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "البيان"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 300
        '
        'Column11
        '
        Me.Column11.HeaderText = "الوحدة"
        Me.Column11.Name = "Column11"
        '
        'Column2
        '
        Me.Column2.HeaderText = "وارد"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "منصرف"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "الرصيد"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "النوع"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "طبيعة الحساب"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "دائن رقم"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "رصيد بديل"
        Me.Column10.Name = "Column10"
        Me.Column10.Visible = False
        '
        'txt_Balance
        '
        Me.txt_Balance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Balance.Location = New System.Drawing.Point(462, 7)
        Me.txt_Balance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Balance.Name = "txt_Balance"
        Me.txt_Balance.ReadOnly = True
        Me.txt_Balance.Size = New System.Drawing.Size(144, 24)
        Me.txt_Balance.TabIndex = 1056
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(612, 7)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(105, 22)
        Me.LabelX7.TabIndex = 1055
        Me.LabelX7.Text = "الرصيد السابق"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Green
        Me.LabelX1.Location = New System.Drawing.Point(1164, 0)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(264, 33)
        Me.LabelX1.TabIndex = 1052
        Me.LabelX1.Text = "أضغط مرتين بالماوس لفتح المستند"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(572, 7)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 505
        Me.LabelX9.Text = "الرصيد"
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
        Me.txt_Cr.Location = New System.Drawing.Point(653, 6)
        Me.txt_Cr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Cr.Name = "txt_Cr"
        Me.txt_Cr.PreventEnterBeep = True
        Me.txt_Cr.ReadOnly = True
        Me.txt_Cr.Size = New System.Drawing.Size(118, 26)
        Me.txt_Cr.TabIndex = 504
        Me.txt_Cr.Text = "0"
        Me.txt_Cr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(777, 6)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 23)
        Me.LabelX2.TabIndex = 503
        Me.LabelX2.Text = "إجمالى المنصرف"
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
        Me.txt_De.Location = New System.Drawing.Point(898, 7)
        Me.txt_De.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_De.MaxLength = 3
        Me.txt_De.Name = "txt_De"
        Me.txt_De.PreventEnterBeep = True
        Me.txt_De.ReadOnly = True
        Me.txt_De.Size = New System.Drawing.Size(118, 26)
        Me.txt_De.TabIndex = 502
        Me.txt_De.Text = "0"
        Me.txt_De.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_De.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.ScrollBar
        '
        '
        '
        Me.txt_total.Border.Class = "TextBoxBorder"
        Me.txt_total.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_total.ButtonCustom.Tooltip = ""
        Me.txt_total.ButtonCustom2.Tooltip = ""
        Me.txt_total.DisabledBackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(451, 6)
        Me.txt_total.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.PreventEnterBeep = True
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(115, 26)
        Me.txt_total.TabIndex = 500
        Me.txt_total.Text = "0"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.Horizontal = False
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.SplitContainerControl5)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(1428, 795)
        Me.SplitContainerControl3.SplitterPosition = 633
        Me.SplitContainerControl3.TabIndex = 0
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'SplitContainerControl5
        '
        Me.SplitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl5.Horizontal = False
        Me.SplitContainerControl5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl5.Name = "SplitContainerControl5"
        Me.SplitContainerControl5.Panel1.Controls.Add(Me.DataGridView2)
        Me.SplitContainerControl5.Panel1.Text = "Panel1"
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.LabelX9)
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.txt_Cr)
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.LabelX2)
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.txt_De)
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.LabelX3)
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.txt_total)
        Me.SplitContainerControl5.Panel2.Text = "Panel2"
        Me.SplitContainerControl5.Size = New System.Drawing.Size(1428, 633)
        Me.SplitContainerControl5.SplitterPosition = 433
        Me.SplitContainerControl5.TabIndex = 0
        Me.SplitContainerControl5.Text = "SplitContainerControl5"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(1022, 7)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(101, 23)
        Me.LabelX3.TabIndex = 501
        Me.LabelX3.Text = "إجمالى الوارد"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.txt_Balance)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelX7)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SplitContainerControl3)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1428, 834)
        Me.SplitContainerControl2.SplitterPosition = 33
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'txt_NameItem
        '
        Me.txt_NameItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NameItem.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_NameItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NameItem.Location = New System.Drawing.Point(450, 0)
        Me.txt_NameItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_NameItem.Name = "txt_NameItem"
        Me.txt_NameItem.ReadOnly = True
        Me.txt_NameItem.Size = New System.Drawing.Size(284, 24)
        Me.txt_NameItem.TabIndex = 1012
        Me.txt_NameItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_codeItem
        '
        Me.txt_codeItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codeItem.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_codeItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codeItem.Location = New System.Drawing.Point(734, 0)
        Me.txt_codeItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_codeItem.Name = "txt_codeItem"
        Me.txt_codeItem.ReadOnly = True
        Me.txt_codeItem.Size = New System.Drawing.Size(60, 24)
        Me.txt_codeItem.TabIndex = 1011
        Me.txt_codeItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(794, 0)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(85, 25)
        Me.LabelX5.TabIndex = 1010
        Me.LabelX5.Text = "اسم الصنف"
        '
        'txt_date2
        '
        Me.txt_date2.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_date2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txt_date2.Location = New System.Drawing.Point(1127, 0)
        Me.txt_date2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date2.Name = "txt_date2"
        Me.txt_date2.Size = New System.Drawing.Size(112, 24)
        Me.txt_date2.TabIndex = 964
        Me.txt_date2.Value = New Date(2021, 12, 31, 0, 0, 0, 0)
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(1239, 0)
        Me.LabelX18.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(80, 25)
        Me.LabelX18.TabIndex = 962
        Me.LabelX18.Text = "الى فترة"
        '
        'txt_date1
        '
        Me.txt_date1.Dock = System.Windows.Forms.DockStyle.Right
        Me.txt_date1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txt_date1.Location = New System.Drawing.Point(1319, 0)
        Me.txt_date1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date1.Name = "txt_date1"
        Me.txt_date1.Size = New System.Drawing.Size(109, 24)
        Me.txt_date1.TabIndex = 963
        Me.txt_date1.Value = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Com_Stores)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX12)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton11)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_NameItem)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_codeItem)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Cmd_Print)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmd_Find)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_date2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelX18)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txt_date1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1428, 865)
        Me.SplitContainerControl1.SplitterPosition = 25
        Me.SplitContainerControl1.TabIndex = 879
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Com_Stores
        '
        Me.Com_Stores.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Com_Stores.Dock = System.Windows.Forms.DockStyle.Right
        Me.Com_Stores.ForeColor = System.Drawing.Color.Black
        Me.Com_Stores.FormattingEnabled = True
        Me.Com_Stores.Location = New System.Drawing.Point(181, 0)
        Me.Com_Stores.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_Stores.Name = "Com_Stores"
        Me.Com_Stores.Size = New System.Drawing.Size(164, 24)
        Me.Com_Stores.TabIndex = 1077
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(345, 0)
        Me.LabelX12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(65, 25)
        Me.LabelX12.TabIndex = 1076
        Me.LabelX12.Text = "المخزن"
        '
        'SimpleButton11
        '
        Me.SimpleButton11.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton11.Image = CType(resources.GetObject("SimpleButton11.Image"), System.Drawing.Image)
        Me.SimpleButton11.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton11.Location = New System.Drawing.Point(410, 0)
        Me.SimpleButton11.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton11.Name = "SimpleButton11"
        Me.SimpleButton11.Size = New System.Drawing.Size(40, 25)
        Me.SimpleButton11.TabIndex = 1013
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Appearance.Options.UseFont = True
        Me.Cmd_Print.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(879, 0)
        Me.Cmd_Print.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(154, 25)
        Me.Cmd_Print.TabIndex = 966
        Me.Cmd_Print.Text = "معاينة قبل الطباعة"
        '
        'cmd_Find
        '
        Me.cmd_Find.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Find.Appearance.Options.UseFont = True
        Me.cmd_Find.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmd_Find.Image = CType(resources.GetObject("cmd_Find.Image"), System.Drawing.Image)
        Me.cmd_Find.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Find.Location = New System.Drawing.Point(1033, 0)
        Me.cmd_Find.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Find.Name = "cmd_Find"
        Me.cmd_Find.Size = New System.Drawing.Size(94, 25)
        Me.cmd_Find.TabIndex = 965
        Me.cmd_Find.Text = "بحث"
        '
        'Frm_GardItem2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 865)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Frm_GardItem2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "كارت الصنف"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl3.ResumeLayout(False)
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl5.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView2 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txt_Balance As System.Windows.Forms.TextBox
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Cr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_De As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txt_total As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl5 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SimpleButton11 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_NameItem As System.Windows.Forms.TextBox
    Friend WithEvents txt_codeItem As System.Windows.Forms.TextBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_Print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Find As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Com_Stores As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
