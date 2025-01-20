<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_openmonth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_openmonth))
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date2 = New System.Windows.Forms.DateTimePicker()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date = New System.Windows.Forms.DateTimePicker()
        Me.cmd_Cancle = New DevExpress.XtraEditors.SimpleButton()
        Me.cmd_Entry = New DevExpress.XtraEditors.SimpleButton()
        Me.com_year = New System.Windows.Forms.ComboBox()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.com_month = New System.Windows.Forms.ComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(458, 80)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(59, 33)
        Me.LabelX4.TabIndex = 977
        Me.LabelX4.Text = "من فترة"
        '
        'txt_date2
        '
        Me.txt_date2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txt_date2.Location = New System.Drawing.Point(130, 81)
        Me.txt_date2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date2.Name = "txt_date2"
        Me.txt_date2.Size = New System.Drawing.Size(112, 27)
        Me.txt_date2.TabIndex = 976
        Me.txt_date2.Value = New Date(2021, 6, 6, 0, 0, 0, 0)
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(250, 80)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(59, 33)
        Me.LabelX3.TabIndex = 974
        Me.LabelX3.Text = "الى فترة"
        '
        'txt_date
        '
        Me.txt_date.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txt_date.Location = New System.Drawing.Point(328, 81)
        Me.txt_date.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(109, 27)
        Me.txt_date.TabIndex = 975
        Me.txt_date.Value = New Date(2021, 6, 6, 0, 0, 0, 0)
        '
        'cmd_Cancle
        '
        Me.cmd_Cancle.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancle.Appearance.Options.UseFont = True
        Me.cmd_Cancle.Image = CType(resources.GetObject("cmd_Cancle.Image"), System.Drawing.Image)
        Me.cmd_Cancle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Cancle.Location = New System.Drawing.Point(250, 130)
        Me.cmd_Cancle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Cancle.Name = "cmd_Cancle"
        Me.cmd_Cancle.Size = New System.Drawing.Size(111, 42)
        Me.cmd_Cancle.TabIndex = 979
        Me.cmd_Cancle.Text = "إغلاق"
        '
        'cmd_Entry
        '
        Me.cmd_Entry.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Entry.Appearance.Options.UseFont = True
        Me.cmd_Entry.Image = CType(resources.GetObject("cmd_Entry.Image"), System.Drawing.Image)
        Me.cmd_Entry.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Entry.Location = New System.Drawing.Point(368, 130)
        Me.cmd_Entry.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Entry.Name = "cmd_Entry"
        Me.cmd_Entry.Size = New System.Drawing.Size(133, 42)
        Me.cmd_Entry.TabIndex = 978
        Me.cmd_Entry.Text = "فتح الشهر"
        '
        'com_year
        '
        Me.com_year.FormattingEnabled = True
        Me.com_year.Location = New System.Drawing.Point(130, 40)
        Me.com_year.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.com_year.Name = "com_year"
        Me.com_year.Size = New System.Drawing.Size(112, 24)
        Me.com_year.TabIndex = 1105
        Me.com_year.Text = "2021"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX6.Location = New System.Drawing.Point(263, 35)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(59, 30)
        Me.LabelX6.TabIndex = 1104
        Me.LabelX6.Text = "سنة"
        '
        'com_month
        '
        Me.com_month.FormattingEnabled = True
        Me.com_month.Location = New System.Drawing.Point(328, 40)
        Me.com_month.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.com_month.Name = "com_month"
        Me.com_month.Size = New System.Drawing.Size(109, 24)
        Me.com_month.TabIndex = 1103
        Me.com_month.Text = "4"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX1.Location = New System.Drawing.Point(458, 34)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(59, 30)
        Me.LabelX1.TabIndex = 1106
        Me.LabelX1.Text = "شهر"
        '
        'Frm_openmonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 200)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.com_year)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.com_month)
        Me.Controls.Add(Me.cmd_Cancle)
        Me.Controls.Add(Me.cmd_Entry)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txt_date2)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txt_date)
        Me.MaximizeBox = False
        Me.Name = "Frm_openmonth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فتح شهر القبض"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_Cancle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Entry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents com_year As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents com_month As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
