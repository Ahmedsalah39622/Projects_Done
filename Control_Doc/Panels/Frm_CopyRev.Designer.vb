<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CopyRev
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CopyRev))
        Me.SplitContainerControl8 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txt_Rev = New System.Windows.Forms.TextBox()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.txt_ProjectName = New System.Windows.Forms.TextBox()
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
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.txt_Rev)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.LabelX10)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.txt_ProjectName)
        Me.SplitContainerControl8.Panel1.Controls.Add(Me.LabelX24)
        Me.SplitContainerControl8.Panel1.Text = "Panel1"
        Me.SplitContainerControl8.Panel2.Controls.Add(Me.SimpleButton3)
        Me.SplitContainerControl8.Panel2.Text = "Panel2"
        Me.SplitContainerControl8.Size = New System.Drawing.Size(707, 78)
        Me.SplitContainerControl8.SplitterPosition = 23
        Me.SplitContainerControl8.TabIndex = 989
        Me.SplitContainerControl8.Text = "SplitContainerControl8"
        '
        'txt_Rev
        '
        Me.txt_Rev.BackColor = System.Drawing.Color.White
        Me.txt_Rev.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_Rev.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Rev.Location = New System.Drawing.Point(477, 0)
        Me.txt_Rev.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_Rev.Name = "txt_Rev"
        Me.txt_Rev.Size = New System.Drawing.Size(115, 23)
        Me.txt_Rev.TabIndex = 1194
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.White
        Me.LabelX10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX10.Location = New System.Drawing.Point(397, 0)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 23)
        Me.LabelX10.TabIndex = 1193
        Me.LabelX10.Text = "Rev"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txt_ProjectName
        '
        Me.txt_ProjectName.BackColor = System.Drawing.Color.White
        Me.txt_ProjectName.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_ProjectName.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProjectName.Location = New System.Drawing.Point(123, 0)
        Me.txt_ProjectName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_ProjectName.Name = "txt_ProjectName"
        Me.txt_ProjectName.Size = New System.Drawing.Size(274, 23)
        Me.txt_ProjectName.TabIndex = 1192
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.SteelBlue
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
        Me.LabelX24.Size = New System.Drawing.Size(123, 23)
        Me.LabelX24.TabIndex = 1191
        Me.LabelX24.Text = "Project Name"
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
        Me.SimpleButton3.Size = New System.Drawing.Size(176, 49)
        Me.SimpleButton3.TabIndex = 1149
        Me.SimpleButton3.Text = "Cerate Rev"
        Me.SimpleButton3.ToolTip = "Save"
        '
        'Frm_CopyRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 78)
        Me.Controls.Add(Me.SplitContainerControl8)
        Me.Name = "Frm_CopyRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cerate Rev"
        CType(Me.SplitContainerControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl8 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents txt_Rev As System.Windows.Forms.TextBox
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_ProjectName As System.Windows.Forms.TextBox
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
End Class
