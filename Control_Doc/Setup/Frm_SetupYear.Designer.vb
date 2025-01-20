<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SetupYear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SetupYear))
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_DateStart = New System.Windows.Forms.DateTimePicker()
        Me.txt_DateEnd = New System.Windows.Forms.DateTimePicker()
        Me.Com_Year = New System.Windows.Forms.ComboBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txt_CodeYear = New System.Windows.Forms.TextBox()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX2.Location = New System.Drawing.Point(206, 62)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(91, 23)
        Me.LabelX2.TabIndex = 613
        Me.LabelX2.Text = "تاريخ النهاية"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX1.Location = New System.Drawing.Point(479, 62)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(91, 23)
        Me.LabelX1.TabIndex = 612
        Me.LabelX1.Text = "تاريخ البداية"
        '
        'txt_DateStart
        '
        Me.txt_DateStart.Location = New System.Drawing.Point(297, 60)
        Me.txt_DateStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_DateStart.Name = "txt_DateStart"
        Me.txt_DateStart.Size = New System.Drawing.Size(145, 24)
        Me.txt_DateStart.TabIndex = 611
        '
        'txt_DateEnd
        '
        Me.txt_DateEnd.Location = New System.Drawing.Point(42, 60)
        Me.txt_DateEnd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_DateEnd.Name = "txt_DateEnd"
        Me.txt_DateEnd.Size = New System.Drawing.Size(145, 24)
        Me.txt_DateEnd.TabIndex = 610
        '
        'Com_Year
        '
        Me.Com_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Com_Year.FormattingEnabled = True
        Me.Com_Year.Location = New System.Drawing.Point(42, 14)
        Me.Com_Year.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Com_Year.Name = "Com_Year"
        Me.Com_Year.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Com_Year.Size = New System.Drawing.Size(350, 24)
        Me.Com_Year.TabIndex = 615
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX3.Location = New System.Drawing.Point(471, 12)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(101, 23)
        Me.LabelX3.TabIndex = 614
        Me.LabelX3.Text = "السنة المالية"
        '
        'txt_CodeYear
        '
        Me.txt_CodeYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_CodeYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CodeYear.Location = New System.Drawing.Point(398, 14)
        Me.txt_CodeYear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_CodeYear.Name = "txt_CodeYear"
        Me.txt_CodeYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_CodeYear.Size = New System.Drawing.Size(46, 24)
        Me.txt_CodeYear.TabIndex = 621
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(297, 119)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(119, 39)
        Me.Cmd_Delete.TabIndex = 618
        Me.Cmd_Delete.Text = "حذف"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Image = CType(resources.GetObject("Cmd_Save.Image"), System.Drawing.Image)
        Me.Cmd_Save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Save.Location = New System.Drawing.Point(422, 119)
        Me.Cmd_Save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(119, 39)
        Me.Cmd_Save.TabIndex = 617
        Me.Cmd_Save.Text = "حفظ"
        '
        'Frm_SetupYear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(629, 217)
        Me.Controls.Add(Me.txt_CodeYear)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.Com_Year)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txt_DateStart)
        Me.Controls.Add(Me.txt_DateEnd)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Frm_SetupYear"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "السنة المالية"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_DateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_DateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Com_Year As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmd_Delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmd_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_CodeYear As System.Windows.Forms.TextBox
End Class
