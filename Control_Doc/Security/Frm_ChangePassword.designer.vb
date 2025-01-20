<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ChangePassword))
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Password = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txt_UserName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Code = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmd_Cancle = New DevExpress.XtraEditors.SimpleButton()
        Me.cmd_Entry = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(449, 72)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(88, 19)
        Me.LabelX3.TabIndex = 262
        Me.LabelX3.Text = "كلمة المرور"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(449, 47)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(88, 19)
        Me.LabelX2.TabIndex = 261
        Me.LabelX2.Text = "أسم المستخدم"
        '
        'txt_Password
        '
        '
        '
        '
        Me.txt_Password.Border.Class = "TextBoxBorder"
        Me.txt_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_Password.ButtonCustom.Tooltip = ""
        Me.txt_Password.ButtonCustom2.Tooltip = ""
        Me.txt_Password.Location = New System.Drawing.Point(312, 70)
        Me.txt_Password.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.PreventEnterBeep = True
        Me.txt_Password.Size = New System.Drawing.Size(102, 20)
        Me.txt_Password.TabIndex = 260
        Me.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_UserName
        '
        '
        '
        '
        Me.txt_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_UserName.ButtonCustom.Tooltip = ""
        Me.txt_UserName.ButtonCustom2.Tooltip = ""
        Me.txt_UserName.Location = New System.Drawing.Point(312, 47)
        Me.txt_UserName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_UserName.Name = "txt_UserName"
        Me.txt_UserName.PreventEnterBeep = True
        Me.txt_UserName.Size = New System.Drawing.Size(102, 14)
        Me.txt_UserName.TabIndex = 259
        Me.txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(449, 25)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 19)
        Me.LabelX1.TabIndex = 264
        Me.LabelX1.Text = "الكود"
        '
        'txt_Code
        '
        '
        '
        '
        Me.txt_Code.Border.Class = "TextBoxBorder"
        Me.txt_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txt_Code.ButtonCustom.Tooltip = ""
        Me.txt_Code.ButtonCustom2.Tooltip = ""
        Me.txt_Code.Location = New System.Drawing.Point(312, 21)
        Me.txt_Code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Code.Name = "txt_Code"
        Me.txt_Code.PreventEnterBeep = True
        Me.txt_Code.ReadOnly = True
        Me.txt_Code.Size = New System.Drawing.Size(102, 20)
        Me.txt_Code.TabIndex = 265
        Me.txt_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmd_Cancle
        '
        Me.cmd_Cancle.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancle.Appearance.Options.UseFont = True
        Me.cmd_Cancle.Image = CType(resources.GetObject("cmd_Cancle.Image"), System.Drawing.Image)
        Me.cmd_Cancle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Cancle.Location = New System.Drawing.Point(174, 103)
        Me.cmd_Cancle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Cancle.Name = "cmd_Cancle"
        Me.cmd_Cancle.Size = New System.Drawing.Size(119, 34)
        Me.cmd_Cancle.TabIndex = 339
        Me.cmd_Cancle.Text = "إغلاق"
        '
        'cmd_Entry
        '
        Me.cmd_Entry.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Entry.Appearance.Options.UseFont = True
        Me.cmd_Entry.Image = CType(resources.GetObject("cmd_Entry.Image"), System.Drawing.Image)
        Me.cmd_Entry.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Entry.Location = New System.Drawing.Point(299, 103)
        Me.cmd_Entry.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Entry.Name = "cmd_Entry"
        Me.cmd_Entry.Size = New System.Drawing.Size(119, 34)
        Me.cmd_Entry.TabIndex = 338
        Me.cmd_Entry.Text = "موافق"
        '
        'txt_Name
        '
        Me.txt_Name.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txt_Name.Location = New System.Drawing.Point(83, 20)
        Me.txt_Name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(223, 20)
        Me.txt_Name.TabIndex = 608
        '
        'Frm_ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(588, 193)
        Me.Controls.Add(Me.txt_Name)
        Me.Controls.Add(Me.cmd_Cancle)
        Me.Controls.Add(Me.cmd_Entry)
        Me.Controls.Add(Me.txt_Code)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.txt_UserName)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Frm_ChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تغير كلمة المرور"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Password As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txt_UserName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Code As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmd_Cancle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Entry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
End Class
