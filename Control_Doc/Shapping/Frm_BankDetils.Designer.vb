<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BankDetils
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BankDetils))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TXt_NoAccountBank = New System.Windows.Forms.TextBox()
        Me.Txt_SwiftCode = New System.Windows.Forms.TextBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txt_OurBank = New System.Windows.Forms.TextBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Address = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Com_AccountName = New System.Windows.Forms.ComboBox()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
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
        Me.LabelX1.Location = New System.Drawing.Point(25, 48)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(125, 23)
        Me.LabelX1.TabIndex = 951
        Me.LabelX1.Text = "Account Name "
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
        Me.LabelX2.Location = New System.Drawing.Point(25, 90)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(125, 23)
        Me.LabelX2.TabIndex = 952
        Me.LabelX2.Text = "Account Number"
        '
        'TXt_NoAccountBank
        '
        Me.TXt_NoAccountBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXt_NoAccountBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXt_NoAccountBank.Location = New System.Drawing.Point(194, 87)
        Me.TXt_NoAccountBank.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXt_NoAccountBank.Name = "TXt_NoAccountBank"
        Me.TXt_NoAccountBank.Size = New System.Drawing.Size(327, 24)
        Me.TXt_NoAccountBank.TabIndex = 953
        Me.TXt_NoAccountBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_SwiftCode
        '
        Me.Txt_SwiftCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_SwiftCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SwiftCode.Location = New System.Drawing.Point(194, 132)
        Me.Txt_SwiftCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_SwiftCode.Name = "Txt_SwiftCode"
        Me.Txt_SwiftCode.Size = New System.Drawing.Size(327, 24)
        Me.Txt_SwiftCode.TabIndex = 955
        Me.Txt_SwiftCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX3.Location = New System.Drawing.Point(25, 135)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(125, 23)
        Me.LabelX3.TabIndex = 954
        Me.LabelX3.Text = "Swift Code"
        '
        'txt_OurBank
        '
        Me.txt_OurBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_OurBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_OurBank.Location = New System.Drawing.Point(194, 177)
        Me.txt_OurBank.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_OurBank.Name = "txt_OurBank"
        Me.txt_OurBank.Size = New System.Drawing.Size(327, 24)
        Me.txt_OurBank.TabIndex = 957
        Me.txt_OurBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX4.Location = New System.Drawing.Point(25, 178)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(163, 23)
        Me.LabelX4.TabIndex = 956
        Me.LabelX4.Text = "Name Of Our Bank Is"
        '
        'txt_Address
        '
        Me.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Address.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address.Location = New System.Drawing.Point(194, 220)
        Me.txt_Address.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Address.Multiline = True
        Me.txt_Address.Name = "txt_Address"
        Me.txt_Address.Size = New System.Drawing.Size(569, 59)
        Me.txt_Address.TabIndex = 959
        Me.txt_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.LabelX5.Location = New System.Drawing.Point(25, 221)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(163, 23)
        Me.LabelX5.TabIndex = 958
        Me.LabelX5.Text = "Address"
        '
        'Com_AccountName
        '
        Me.Com_AccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Com_AccountName.FormattingEnabled = True
        Me.Com_AccountName.Location = New System.Drawing.Point(194, 48)
        Me.Com_AccountName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Com_AccountName.Name = "Com_AccountName"
        Me.Com_AccountName.Size = New System.Drawing.Size(327, 25)
        Me.Com_AccountName.TabIndex = 964
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Image = CType(resources.GetObject("SimpleButton8.Image"), System.Drawing.Image)
        Me.SimpleButton8.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton8.Location = New System.Drawing.Point(440, 315)
        Me.SimpleButton8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(117, 32)
        Me.SimpleButton8.TabIndex = 963
        Me.SimpleButton8.Text = "Update"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton4.Location = New System.Drawing.Point(194, 315)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(117, 32)
        Me.SimpleButton4.TabIndex = 962
        Me.SimpleButton4.Text = "New"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Image = CType(resources.GetObject("SimpleButton5.Image"), System.Drawing.Image)
        Me.SimpleButton5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton5.Location = New System.Drawing.Point(563, 315)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(117, 32)
        Me.SimpleButton5.TabIndex = 961
        Me.SimpleButton5.Text = "Delete"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Image = CType(resources.GetObject("SimpleButton7.Image"), System.Drawing.Image)
        Me.SimpleButton7.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton7.Location = New System.Drawing.Point(317, 315)
        Me.SimpleButton7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(117, 32)
        Me.SimpleButton7.TabIndex = 960
        Me.SimpleButton7.Text = "Save"
        '
        'Frm_BankDetils
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 387)
        Me.Controls.Add(Me.Com_AccountName)
        Me.Controls.Add(Me.SimpleButton8)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.txt_Address)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txt_OurBank)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_SwiftCode)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.TXt_NoAccountBank)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.MaximizeBox = False
        Me.Name = "Frm_BankDetils"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Details \ بيانات البنك"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TXt_NoAccountBank As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SwiftCode As System.Windows.Forms.TextBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_OurBank As System.Windows.Forms.TextBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Address As System.Windows.Forms.TextBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Com_AccountName As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
End Class
