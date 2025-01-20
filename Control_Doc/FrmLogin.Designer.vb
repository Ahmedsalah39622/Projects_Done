<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.txt_UserName = New System.Windows.Forms.TextBox()
        Me.txt_NameCompny = New System.Windows.Forms.TextBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmd_Cancle = New DevExpress.XtraEditors.SimpleButton()
        Me.cmd_Entry = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_CodeCompny = New System.Windows.Forms.TextBox()
        Me.txt_UserCode = New System.Windows.Forms.TextBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_UserName
        '
        Me.txt_UserName.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txt_UserName.Location = New System.Drawing.Point(141, 45)
        Me.txt_UserName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_UserName.Name = "txt_UserName"
        Me.txt_UserName.Size = New System.Drawing.Size(180, 20)
        Me.txt_UserName.TabIndex = 607
        '
        'txt_NameCompny
        '
        Me.txt_NameCompny.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txt_NameCompny.Location = New System.Drawing.Point(141, 20)
        Me.txt_NameCompny.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_NameCompny.Name = "txt_NameCompny"
        Me.txt_NameCompny.Size = New System.Drawing.Size(180, 20)
        Me.txt_NameCompny.TabIndex = 605
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX2.Location = New System.Drawing.Point(446, 44)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(87, 19)
        Me.LabelX2.TabIndex = 604
        Me.LabelX2.Text = "أسم المستخدم"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX1.Location = New System.Drawing.Point(446, 69)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(95, 19)
        Me.LabelX1.TabIndex = 603
        Me.LabelX1.Text = "كلمة المرور"
        '
        'txt_Password
        '
        Me.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Password.Location = New System.Drawing.Point(325, 68)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Password.Size = New System.Drawing.Size(108, 20)
        Me.txt_Password.TabIndex = 602
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX5.Location = New System.Drawing.Point(446, 18)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(78, 19)
        Me.LabelX5.TabIndex = 601
        Me.LabelX5.Text = "أسم الشركة"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton1.Location = New System.Drawing.Point(141, 93)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(292, 33)
        Me.SimpleButton1.TabIndex = 610
        Me.SimpleButton1.Text = "تغير كلمة المرور"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 609
        Me.PictureBox1.TabStop = False
        '
        'cmd_Cancle
        '
        Me.cmd_Cancle.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancle.Appearance.Options.UseFont = True
        Me.cmd_Cancle.ImageOptions.Image = CType(resources.GetObject("cmd_Cancle.ImageOptions.Image"), System.Drawing.Image)
        Me.cmd_Cancle.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Cancle.Location = New System.Drawing.Point(141, 142)
        Me.cmd_Cancle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Cancle.Name = "cmd_Cancle"
        Me.cmd_Cancle.Size = New System.Drawing.Size(119, 34)
        Me.cmd_Cancle.TabIndex = 337
        Me.cmd_Cancle.Text = "تراجع"
        '
        'cmd_Entry
        '
        Me.cmd_Entry.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Entry.Appearance.Options.UseFont = True
        Me.cmd_Entry.ImageOptions.Image = CType(resources.GetObject("cmd_Entry.ImageOptions.Image"), System.Drawing.Image)
        Me.cmd_Entry.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmd_Entry.Location = New System.Drawing.Point(314, 142)
        Me.cmd_Entry.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Entry.Name = "cmd_Entry"
        Me.cmd_Entry.Size = New System.Drawing.Size(119, 34)
        Me.cmd_Entry.TabIndex = 335
        Me.cmd_Entry.Text = "دخول"
        '
        'txt_CodeCompny
        '
        Me.txt_CodeCompny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CodeCompny.Enabled = False
        Me.txt_CodeCompny.Location = New System.Drawing.Point(325, 20)
        Me.txt_CodeCompny.Name = "txt_CodeCompny"
        Me.txt_CodeCompny.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_CodeCompny.Size = New System.Drawing.Size(108, 20)
        Me.txt_CodeCompny.TabIndex = 611
        '
        'txt_UserCode
        '
        Me.txt_UserCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UserCode.Enabled = False
        Me.txt_UserCode.Location = New System.Drawing.Point(325, 44)
        Me.txt_UserCode.Name = "txt_UserCode"
        Me.txt_UserCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_UserCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_UserCode.Size = New System.Drawing.Size(108, 20)
        Me.txt_UserCode.TabIndex = 612
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton2.Location = New System.Drawing.Point(105, 16)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(30, 21)
        Me.SimpleButton2.TabIndex = 613
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.BackgroundImage = Global.Control_Doc.My.Resources.Resources.Browse_1
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton3.Location = New System.Drawing.Point(105, 45)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(30, 21)
        Me.SimpleButton3.TabIndex = 614
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 196)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.txt_UserCode)
        Me.Controls.Add(Me.txt_CodeCompny)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txt_UserName)
        Me.Controls.Add(Me.txt_NameCompny)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.cmd_Cancle)
        Me.Controls.Add(Me.cmd_Entry)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "كلمة المرور"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_Entry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmd_Cancle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_UserName As System.Windows.Forms.TextBox
    Friend WithEvents txt_NameCompny As System.Windows.Forms.TextBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_CodeCompny As System.Windows.Forms.TextBox
    Friend WithEvents txt_UserCode As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
End Class
