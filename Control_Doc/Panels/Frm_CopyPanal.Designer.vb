<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CopyPanal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CopyPanal))
        Me.SplitContainerControl8 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txt_NamePanel = New System.Windows.Forms.TextBox()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.txt_Quantity = New System.Windows.Forms.TextBox()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.txt_ItemSn = New System.Windows.Forms.TextBox()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl8.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl8
        '
        Me.SplitContainerControl8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl8.Horizontal = False
        Me.SplitContainerControl8.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl8.Name = "SplitContainerControl8"
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.txt_NamePanel)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.LabelX13)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.txt_Quantity)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.LabelX10)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.txt_ItemSn)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.LabelX24)
        Me.SplitContainerControl8.Panel1.Text = "Panel1"
        Me.SplitContainerControl8.Panel2.Controls.Add(Me.SimpleButton3)
        Me.SplitContainerControl8.Panel2.Text = "Panel2"
        Me.SplitContainerControl8.Size = New System.Drawing.Size(714, 89)
        Me.SplitContainerControl8.SplitterPosition = 23
        Me.SplitContainerControl8.TabIndex = 988
        Me.SplitContainerControl8.Text = "SplitContainerControl8"
        '
        'txt_NamePanel
        '
        Me.txt_NamePanel.BackColor = System.Drawing.Color.White
        Me.txt_NamePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_NamePanel.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NamePanel.Location = New System.Drawing.Point(424, 0)
        Me.txt_NamePanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_NamePanel.Name = "txt_NamePanel"
        Me.txt_NamePanel.Size = New System.Drawing.Size(279, 23)
        Me.txt_NamePanel.TabIndex = 1196
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Teal
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.White
        Me.LabelX13.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX13.Location = New System.Drawing.Point(326, 0)
        Me.LabelX13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(98, 23)
        Me.LabelX13.TabIndex = 1195
        Me.LabelX13.Text = "Panel Name "
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txt_Quantity
        '
        Me.txt_Quantity.BackColor = System.Drawing.Color.White
        Me.txt_Quantity.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_Quantity.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Quantity.Location = New System.Drawing.Point(251, 0)
        Me.txt_Quantity.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Quantity.Name = "txt_Quantity"
        Me.txt_Quantity.Size = New System.Drawing.Size(75, 23)
        Me.txt_Quantity.TabIndex = 1194
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Teal
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.White
        Me.LabelX10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX10.Location = New System.Drawing.Point(171, 0)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 23)
        Me.LabelX10.TabIndex = 1193
        Me.LabelX10.Text = "Quantity"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txt_ItemSn
        '
        Me.txt_ItemSn.BackColor = System.Drawing.Color.White
        Me.txt_ItemSn.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_ItemSn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ItemSn.Location = New System.Drawing.Point(93, 0)
        Me.txt_ItemSn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_ItemSn.Name = "txt_ItemSn"
        Me.txt_ItemSn.Size = New System.Drawing.Size(78, 23)
        Me.txt_ItemSn.TabIndex = 1192
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Teal
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.White
        Me.LabelX24.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX24.Location = New System.Drawing.Point(0, 0)
        Me.LabelX24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(93, 23)
        Me.LabelX24.TabIndex = 1191
        Me.LabelX24.Text = "Item Sn"
        Me.LabelX24.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton3.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightBottom
        Me.SimpleButton3.Location = New System.Drawing.Point(0, 0)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(155, 60)
        Me.SimpleButton3.TabIndex = 1149
        Me.SimpleButton3.Text = "Save Panal Copy"
        Me.SimpleButton3.ToolTip = "Save"
        '
        'Frm_CopyPanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 89)
        Me.Controls.Add(Me.SplitContainerControl8)
        Me.MaximizeBox = False
        Me.Name = "Frm_CopyPanal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy Panal"
        CType(Me.SplitContainerControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl8 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents txt_ItemSn As System.Windows.Forms.TextBox
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_Quantity As System.Windows.Forms.TextBox
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_NamePanel As System.Windows.Forms.TextBox
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
End Class
