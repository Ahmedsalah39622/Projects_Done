<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ReportDaily
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ReportDaily))
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Com_Shipping = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Com_SuppliserName = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date = New System.Windows.Forms.DateTimePicker()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_date2 = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.Com_Shipping.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Com_SuppliserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton1.Location = New System.Drawing.Point(120, 135)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(34, 27)
        Me.SimpleButton1.TabIndex = 1072
        Me.SimpleButton1.Text = "الكل"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton2.Location = New System.Drawing.Point(120, 102)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(34, 27)
        Me.SimpleButton2.TabIndex = 1071
        Me.SimpleButton2.Text = "الكل"
        '
        'Com_Shipping
        '
        Me.Com_Shipping.Location = New System.Drawing.Point(160, 132)
        Me.Com_Shipping.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_Shipping.Name = "Com_Shipping"
        Me.Com_Shipping.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Com_Shipping.Properties.Appearance.Options.UseFont = True
        Me.Com_Shipping.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Com_Shipping.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Com_Shipping.Size = New System.Drawing.Size(345, 24)
        Me.Com_Shipping.TabIndex = 1068
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
        Me.LabelX3.Location = New System.Drawing.Point(525, 135)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(110, 23)
        Me.LabelX3.TabIndex = 1067
        Me.LabelX3.Text = "شركة الشحن"
        '
        'Com_SuppliserName
        '
        Me.Com_SuppliserName.Location = New System.Drawing.Point(160, 104)
        Me.Com_SuppliserName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Com_SuppliserName.Name = "Com_SuppliserName"
        Me.Com_SuppliserName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Com_SuppliserName.Properties.Appearance.Options.UseFont = True
        Me.Com_SuppliserName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Com_SuppliserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Com_SuppliserName.Size = New System.Drawing.Size(345, 24)
        Me.Com_SuppliserName.TabIndex = 1066
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
        Me.LabelX2.Location = New System.Drawing.Point(525, 107)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(94, 23)
        Me.LabelX2.TabIndex = 1065
        Me.LabelX2.Text = "اسم المورد"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX16.Location = New System.Drawing.Point(526, 29)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(64, 23)
        Me.LabelX16.TabIndex = 1059
        Me.LabelX16.Text = "من فترة"
        '
        'txt_date
        '
        Me.txt_date.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date.Location = New System.Drawing.Point(322, 29)
        Me.txt_date.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(184, 24)
        Me.txt_date.TabIndex = 1060
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
        Me.LabelX1.Location = New System.Drawing.Point(526, 70)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 23)
        Me.LabelX1.TabIndex = 1061
        Me.LabelX1.Text = "الى فترة"
        '
        'txt_date2
        '
        Me.txt_date2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_date2.Location = New System.Drawing.Point(322, 70)
        Me.txt_date2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_date2.Name = "txt_date2"
        Me.txt_date2.Size = New System.Drawing.Size(184, 24)
        Me.txt_date2.TabIndex = 1062
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Image = CType(resources.GetObject("SimpleButton8.Image"), System.Drawing.Image)
        Me.SimpleButton8.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton8.Location = New System.Drawing.Point(447, 204)
        Me.SimpleButton8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(171, 39)
        Me.SimpleButton8.TabIndex = 1064
        Me.SimpleButton8.Text = "معاينة قبل الطباعة"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Image = CType(resources.GetObject("SimpleButton5.Image"), System.Drawing.Image)
        Me.SimpleButton5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton5.Location = New System.Drawing.Point(311, 204)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(131, 39)
        Me.SimpleButton5.TabIndex = 1063
        Me.SimpleButton5.Text = "اغلاق"
        '
        'Frm_ReportDaily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 269)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.Com_Shipping)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Com_SuppliserName)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.SimpleButton8)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.txt_date2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txt_date)
        Me.Controls.Add(Me.LabelX16)
        Me.MaximizeBox = False
        Me.Name = "Frm_ReportDaily"
        Me.Text = "تقرير الشحنات المتأخرة"
        CType(Me.Com_Shipping.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Com_SuppliserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Com_Shipping As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Com_SuppliserName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_date2 As System.Windows.Forms.DateTimePicker
End Class
