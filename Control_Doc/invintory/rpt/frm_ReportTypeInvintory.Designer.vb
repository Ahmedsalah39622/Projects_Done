<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReportTypeInvintory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ReportTypeInvintory))
        Me.txt_date2 = New System.Windows.Forms.DateTimePicker()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date = New System.Windows.Forms.DateTimePicker()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Com_type = New System.Windows.Forms.ComboBox()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Cmd_Print = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'txt_date2
        '
        Me.txt_date2.Location = New System.Drawing.Point(241, 49)
        Me.txt_date2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date2.Name = "txt_date2"
        Me.txt_date2.Size = New System.Drawing.Size(128, 24)
        Me.txt_date2.TabIndex = 1124
        Me.txt_date2.Value = New Date(2022, 12, 31, 0, 0, 0, 0)
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(369, 49)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 25)
        Me.LabelX1.TabIndex = 1123
        Me.LabelX1.Text = "الى تاريخ"
        '
        'txt_date
        '
        Me.txt_date.Location = New System.Drawing.Point(441, 48)
        Me.txt_date.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(144, 24)
        Me.txt_date.TabIndex = 1122
        Me.txt_date.Value = New Date(2022, 1, 1, 0, 0, 0, 0)
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(591, 48)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 25)
        Me.LabelX2.TabIndex = 1121
        Me.LabelX2.Text = "من تاريخ"
        '
        'Com_type
        '
        Me.Com_type.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Com_type.ForeColor = System.Drawing.Color.Black
        Me.Com_type.FormattingEnabled = True
        Me.Com_type.Location = New System.Drawing.Point(241, 96)
        Me.Com_type.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_type.Name = "Com_type"
        Me.Com_type.Size = New System.Drawing.Size(344, 24)
        Me.Com_type.TabIndex = 1120
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(591, 96)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(87, 26)
        Me.LabelX10.TabIndex = 1119
        Me.LabelX10.Text = "نوع الحركة"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Appearance.Options.UseFont = True
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(505, 155)
        Me.Cmd_Print.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(168, 32)
        Me.Cmd_Print.TabIndex = 1125
        Me.Cmd_Print.Text = "معاينة قبل الطباعة"
        '
        'frm_ReportTypeInvintory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 226)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.txt_date2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txt_date)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Com_type)
        Me.Controls.Add(Me.LabelX10)
        Me.Name = "frm_ReportTypeInvintory"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير نوع حركة المخازن"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cmd_Print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Com_type As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
End Class
