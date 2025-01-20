<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ChartOfAccount
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ChartOfAccount))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_AccountNo1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_NameAccount1 = New System.Windows.Forms.TextBox()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txt_NameAccount2 = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txt_AccountNo2 = New System.Windows.Forms.TextBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Chek2 = New System.Windows.Forms.RadioButton()
        Me.Chek1 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Chek4 = New System.Windows.Forms.RadioButton()
        Me.Chek3 = New System.Windows.Forms.RadioButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Windows 7 (17).png")
        Me.ImageList1.Images.SetKeyName(1, "Windows 7 (169).png")
        '
        'txt_AccountNo1
        '
        Me.txt_AccountNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AccountNo1.Location = New System.Drawing.Point(899, 101)
        Me.txt_AccountNo1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_AccountNo1.Name = "txt_AccountNo1"
        Me.txt_AccountNo1.ReadOnly = True
        Me.txt_AccountNo1.Size = New System.Drawing.Size(105, 24)
        Me.txt_AccountNo1.TabIndex = 456
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SimpleButton7)
        Me.Panel1.Controls.Add(Me.SimpleButton5)
        Me.Panel1.Controls.Add(Me.SimpleButton4)
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Location = New System.Drawing.Point(12, 34)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(589, 460)
        Me.Panel1.TabIndex = 455
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Image = CType(resources.GetObject("SimpleButton7.Image"), System.Drawing.Image)
        Me.SimpleButton7.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton7.Location = New System.Drawing.Point(3, 5)
        Me.SimpleButton7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(185, 39)
        Me.SimpleButton7.TabIndex = 608
        Me.SimpleButton7.Text = "طى دليل الحسابات"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Image = CType(resources.GetObject("SimpleButton5.Image"), System.Drawing.Image)
        Me.SimpleButton5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton5.Location = New System.Drawing.Point(195, 5)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(177, 39)
        Me.SimpleButton5.TabIndex = 607
        Me.SimpleButton5.Text = "فتح دليل الحسابات"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton4.Location = New System.Drawing.Point(378, 5)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(208, 39)
        Me.SimpleButton4.TabIndex = 606
        Me.SimpleButton4.Text = "اضافة حساب رئيسى جديد"
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Tahoma", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList2
        Me.TreeView1.Location = New System.Drawing.Point(0, 66)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(586, 390)
        Me.TreeView1.TabIndex = 3
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Browse 3.ico")
        Me.ImageList2.Images.SetKeyName(1, "Write.ico")
        '
        'txt_NameAccount1
        '
        Me.txt_NameAccount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NameAccount1.Location = New System.Drawing.Point(633, 101)
        Me.txt_NameAccount1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_NameAccount1.Name = "txt_NameAccount1"
        Me.txt_NameAccount1.Size = New System.Drawing.Size(261, 24)
        Me.txt_NameAccount1.TabIndex = 458
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(1015, 101)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(136, 27)
        Me.LabelX8.TabIndex = 457
        Me.LabelX8.Text = "الحساب الرئيسى"
        '
        'txt_NameAccount2
        '
        Me.txt_NameAccount2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NameAccount2.Location = New System.Drawing.Point(633, 144)
        Me.txt_NameAccount2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_NameAccount2.Name = "txt_NameAccount2"
        Me.txt_NameAccount2.Size = New System.Drawing.Size(261, 24)
        Me.txt_NameAccount2.TabIndex = 464
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(1015, 144)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(136, 27)
        Me.LabelX1.TabIndex = 463
        Me.LabelX1.Text = "أسم الحساب الفرعى"
        '
        'txt_AccountNo2
        '
        Me.txt_AccountNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AccountNo2.Location = New System.Drawing.Point(899, 144)
        Me.txt_AccountNo2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_AccountNo2.Name = "txt_AccountNo2"
        Me.txt_AccountNo2.ReadOnly = True
        Me.txt_AccountNo2.Size = New System.Drawing.Size(105, 24)
        Me.txt_AccountNo2.TabIndex = 462
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(1018, 193)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 27)
        Me.LabelX2.TabIndex = 466
        Me.LabelX2.Text = "نوع الحساب"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(1015, 238)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(110, 27)
        Me.LabelX3.TabIndex = 467
        Me.LabelX3.Text = "طبيعة الحساب"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Chek2)
        Me.Panel2.Controls.Add(Me.Chek1)
        Me.Panel2.Location = New System.Drawing.Point(633, 182)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(371, 41)
        Me.Panel2.TabIndex = 468
        '
        'Chek2
        '
        Me.Chek2.AutoSize = True
        Me.Chek2.Location = New System.Drawing.Point(181, 10)
        Me.Chek2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chek2.Name = "Chek2"
        Me.Chek2.Size = New System.Drawing.Size(67, 21)
        Me.Chek2.TabIndex = 312
        Me.Chek2.Text = "ميزانية"
        Me.Chek2.UseVisualStyleBackColor = True
        '
        'Chek1
        '
        Me.Chek1.AutoSize = True
        Me.Chek1.Checked = True
        Me.Chek1.Location = New System.Drawing.Point(265, 10)
        Me.Chek1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chek1.Name = "Chek1"
        Me.Chek1.Size = New System.Drawing.Size(90, 21)
        Me.Chek1.TabIndex = 311
        Me.Chek1.TabStop = True
        Me.Chek1.Text = "قائمة دخل"
        Me.Chek1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Chek4)
        Me.Panel3.Controls.Add(Me.Chek3)
        Me.Panel3.Location = New System.Drawing.Point(633, 230)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(371, 41)
        Me.Panel3.TabIndex = 469
        '
        'Chek4
        '
        Me.Chek4.AutoSize = True
        Me.Chek4.Location = New System.Drawing.Point(181, 7)
        Me.Chek4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chek4.Name = "Chek4"
        Me.Chek4.Size = New System.Drawing.Size(54, 21)
        Me.Chek4.TabIndex = 312
        Me.Chek4.Text = "دائن"
        Me.Chek4.UseVisualStyleBackColor = True
        '
        'Chek3
        '
        Me.Chek3.AutoSize = True
        Me.Chek3.Checked = True
        Me.Chek3.Location = New System.Drawing.Point(265, 7)
        Me.Chek3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chek3.Name = "Chek3"
        Me.Chek3.Size = New System.Drawing.Size(59, 21)
        Me.Chek3.TabIndex = 311
        Me.Chek3.TabStop = True
        Me.Chek3.Text = "مدين"
        Me.Chek3.UseVisualStyleBackColor = True
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton3.Location = New System.Drawing.Point(800, 386)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(108, 39)
        Me.SimpleButton3.TabIndex = 584
        Me.SimpleButton3.Text = "حذف"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton2.Location = New System.Drawing.Point(1031, 386)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(105, 39)
        Me.SimpleButton2.TabIndex = 583
        Me.SimpleButton2.Text = "حفظ"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton1.Location = New System.Drawing.Point(915, 386)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(110, 39)
        Me.SimpleButton1.TabIndex = 582
        Me.SimpleButton1.Text = "تعديل"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Image = CType(resources.GetObject("SimpleButton6.Image"), System.Drawing.Image)
        Me.SimpleButton6.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton6.Location = New System.Drawing.Point(633, 386)
        Me.SimpleButton6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(161, 39)
        Me.SimpleButton6.TabIndex = 585
        Me.SimpleButton6.Text = "معاينة قبل الطباعة"
        '
        'Frm_ChartOfAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1183, 580)
        Me.Controls.Add(Me.SimpleButton6)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txt_AccountNo1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_NameAccount1)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.txt_NameAccount2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txt_AccountNo2)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Frm_ChartOfAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "دليل الحسابات"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txt_AccountNo1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents txt_NameAccount1 As System.Windows.Forms.TextBox
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_NameAccount2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txt_AccountNo2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Chek2 As System.Windows.Forms.RadioButton
    Friend WithEvents Chek1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Chek4 As System.Windows.Forms.RadioButton
    Friend WithEvents Chek3 As System.Windows.Forms.RadioButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    'Friend WithEvents DB_InterpakDataSet4 As Control_Doc.DB_InterpakDataSet4
    'Friend WithEvents Vw_treelistTableAdapter As Control_Doc.DB_InterpakDataSet4TableAdapters.vw_treelistTableAdapter
    'Friend WithEvents DB_InterpakDataSet41 As Control_Doc.DB_InterpakDataSet4
    'Friend WithEvents Vw_treelistTableAdapter1 As Control_Doc.DB_InterpakDataSet4TableAdapters.vw_treelistTableAdapter
End Class
