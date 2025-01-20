<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MainmuneGriph
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
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.TileControl2 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem1 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem3 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem5 = New DevExpress.XtraEditors.TileItem()
        Me.SuspendLayout()
        '
        'TileControl2
        '
        Me.TileControl2.BackgroundImage = Global.Control_Doc.My.Resources.Resources.Hd7S83Q
        Me.TileControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileControl2.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl2.Groups.Add(Me.TileGroup2)
        Me.TileControl2.Location = New System.Drawing.Point(0, 0)
        Me.TileControl2.MaxId = 5
        Me.TileControl2.Name = "TileControl2"
        Me.TileControl2.ShowGroupText = True
        Me.TileControl2.ShowText = True
        Me.TileControl2.Size = New System.Drawing.Size(1506, 945)
        Me.TileControl2.TabIndex = 5
        Me.TileControl2.Text = "مندوبين البيع"
        Me.TileControl2.Visible = False
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileItem1)
        Me.TileGroup2.Items.Add(Me.TileItem3)
        Me.TileGroup2.Items.Add(Me.TileItem4)
        Me.TileGroup2.Items.Add(Me.TileItem5)
        Me.TileGroup2.Name = "TileGroup2"
        Me.TileGroup2.Text = "حركة الخزينة"
        '
        'TileItem1
        '
        Me.TileItem1.BackgroundImage = Global.Control_Doc.My.Resources.Resources.imagesDOY34FIB1
        TileItemElement1.Image = Global.Control_Doc.My.Resources.Resources._24_hours_active_1_766936
        TileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight
        TileItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement1.Text = ""
        Me.TileItem1.Elements.Add(TileItemElement1)
        Me.TileItem1.Id = 0
        Me.TileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem1.Name = "TileItem1"
        '
        'TileItem3
        '
        TileItemElement2.Text = "TileItem3"
        Me.TileItem3.Elements.Add(TileItemElement2)
        Me.TileItem3.Id = 2
        Me.TileItem3.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem3.Name = "TileItem3"
        '
        'TileItem4
        '
        TileItemElement3.Text = "TileItem4"
        Me.TileItem4.Elements.Add(TileItemElement3)
        Me.TileItem4.Id = 3
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem4.Name = "TileItem4"
        '
        'TileItem5
        '
        TileItemElement4.Text = "TileItem5"
        Me.TileItem5.Elements.Add(TileItemElement4)
        Me.TileItem5.Id = 4
        Me.TileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem5.Name = "TileItem5"
        '
        'Frm_MainmuneGriph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1506, 945)
        Me.Controls.Add(Me.TileControl2)
        Me.Name = "Frm_MainmuneGriph"
        Me.Text = "Frm_MainmuneGriph"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TileControl2 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem1 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem3 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem5 As DevExpress.XtraEditors.TileItem
End Class
