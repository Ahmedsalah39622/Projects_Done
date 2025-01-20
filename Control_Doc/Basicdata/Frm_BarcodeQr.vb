Public Class Frm_BarcodeQr
  
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtQRCode As System.Windows.Forms.TextBox
    Friend WithEvents printDocument4 As System.Drawing.Printing.PrintDocument
    Friend WithEvents cbxMask As System.Windows.Forms.ComboBox
    Friend WithEvents lblMask As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents printDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocument3 As System.Drawing.Printing.PrintDocument
    Friend WithEvents cbxFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents PrintDocument5 As System.Drawing.Printing.PrintDocument
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents cbxVersion As System.Windows.Forms.ComboBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents cbxLevel As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BarcodeQr))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.txtQRCode = New System.Windows.Forms.TextBox()
        Me.printDocument4 = New System.Drawing.Printing.PrintDocument()
        Me.cbxMask = New System.Windows.Forms.ComboBox()
        Me.lblMask = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.printDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        Me.cbxFontSize = New System.Windows.Forms.ComboBox()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.PrintDocument5 = New System.Drawing.Printing.PrintDocument()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.cbxVersion = New System.Windows.Forms.ComboBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.cbxLevel = New System.Windows.Forms.ComboBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_save = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Delete = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'txtQRCode
        '
        Me.txtQRCode.Location = New System.Drawing.Point(290, 165)
        Me.txtQRCode.Multiline = True
        Me.txtQRCode.Name = "txtQRCode"
        Me.txtQRCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQRCode.Size = New System.Drawing.Size(332, 146)
        Me.txtQRCode.TabIndex = 8
        Me.txtQRCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxMask
        '
        Me.cbxMask.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMask.Items.AddRange(New Object() {"Auto", "0", "1", "2", "3", "4", "5", "6", "7"})
        Me.cbxMask.Location = New System.Drawing.Point(450, 100)
        Me.cbxMask.Name = "cbxMask"
        Me.cbxMask.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxMask.Size = New System.Drawing.Size(168, 24)
        Me.cbxMask.TabIndex = 3
        '
        'lblMask
        '
        Me.lblMask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMask.Location = New System.Drawing.Point(633, 101)
        Me.lblMask.Name = "lblMask"
        Me.lblMask.Size = New System.Drawing.Size(85, 20)
        Me.lblMask.TabIndex = 76
        Me.lblMask.Text = "Mask"
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(290, 13)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(328, 23)
        Me.txtMessage.TabIndex = 0
        Me.txtMessage.Text = "1234"
        Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(633, 13)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(77, 20)
        Me.lblMessage.TabIndex = 72
        Me.lblMessage.Text = "رقم الباركود"
        '
        'cbxFontSize
        '
        Me.cbxFontSize.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFontSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22"})
        Me.cbxFontSize.Location = New System.Drawing.Point(450, 130)
        Me.cbxFontSize.Name = "cbxFontSize"
        Me.cbxFontSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxFontSize.Size = New System.Drawing.Size(168, 24)
        Me.cbxFontSize.TabIndex = 4
        '
        'lblFontSize
        '
        Me.lblFontSize.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontSize.Location = New System.Drawing.Point(633, 133)
        Me.lblFontSize.Name = "lblFontSize"
        Me.lblFontSize.Size = New System.Drawing.Size(77, 20)
        Me.lblFontSize.TabIndex = 75
        Me.lblFontSize.Text = "حجم الخط"
        '
        'lblLevel
        '
        Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.Location = New System.Drawing.Point(633, 69)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(90, 20)
        Me.lblLevel.TabIndex = 74
        Me.lblLevel.Text = "مستوى الخط"
        '
        'cbxVersion
        '
        Me.cbxVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVersion.Items.AddRange(New Object() {"Auto", "1 - 21x21", "2 - 25x25", "3 - 29x29", "4 - 33x33", "5 - 37x37", "6 - 41x41", "7 - 45x45", "8 - 49x49", "9 - 53x53", "10 - 57x57", "11 - 61x61", "12 - 65x65", "13 - 69x69", "14 - 73x73", "15 - 77x77", "16 - 81x81", "17 - 85x85", "18 - 89x89", "19 - 93x93", "20 - 97x97", "21 - 101x101", "22 - 105x105", "23 - 109x109", "24 - 113x113", "25 - 117x117", "26 - 121x121", "27 - 125x125", "28 - 129x129", "29 - 133x133", "30 - 137x137", "31 - 141x141", "32 - 145x145", "33 - 149x149", "34 - 153x153", "35 - 157x157", "36 - 161x161", "37 - 165x165", "38 - 169x169", "39 - 173x173", "40 - 177x177"})
        Me.cbxVersion.Location = New System.Drawing.Point(450, 42)
        Me.cbxVersion.Name = "cbxVersion"
        Me.cbxVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxVersion.Size = New System.Drawing.Size(168, 24)
        Me.cbxVersion.TabIndex = 1
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(633, 37)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(77, 20)
        Me.lblVersion.TabIndex = 73
        Me.lblVersion.Text = "الاصدار"
        '
        'cbxLevel
        '
        Me.cbxLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLevel.Items.AddRange(New Object() {"Level L", "Level M", "Level Q", "Level H"})
        Me.cbxLevel.Location = New System.Drawing.Point(450, 69)
        Me.cbxLevel.Name = "cbxLevel"
        Me.cbxLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxLevel.Size = New System.Drawing.Size(168, 24)
        Me.cbxLevel.TabIndex = 2
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.SimpleButton2.Location = New System.Drawing.Point(25, 13)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(185, 43)
        Me.SimpleButton2.TabIndex = 822
        Me.SimpleButton2.Text = "اظهار الباركود QR"
        '
        'Cmd_save
        '
        Me.Cmd_save.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_save.Appearance.Options.UseFont = True
        Me.Cmd_save.Image = CType(resources.GetObject("Cmd_save.Image"), System.Drawing.Image)
        Me.Cmd_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_save.Location = New System.Drawing.Point(25, 69)
        Me.Cmd_save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_save.Name = "Cmd_save"
        Me.Cmd_save.Size = New System.Drawing.Size(185, 41)
        Me.Cmd_save.TabIndex = 821
        Me.Cmd_save.Text = "طباعة باركود QR"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Appearance.Options.UseFont = True
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(25, 119)
        Me.Cmd_Delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(185, 44)
        Me.Cmd_Delete.TabIndex = 823
        Me.Cmd_Delete.Text = "إغلاق"
        '
        'Frm_BarcodeQr
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(745, 358)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.Cmd_save)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.cbxFontSize)
        Me.Controls.Add(Me.lblFontSize)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.cbxVersion)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.cbxLevel)
        Me.Controls.Add(Me.txtQRCode)
        Me.Controls.Add(Me.cbxMask)
        Me.Controls.Add(Me.lblMask)
        Me.MaximizeBox = False
        Me.Name = "Frm_BarcodeQr"
        Me.Text = "QR باركود"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private QRCodeFontObj As MW6QRCode.Font = New MW6QRCode.Font()

    Private Sub InitGUI()
        Me.cbxFontSize.SelectedIndex = 6
        Me.cbxLevel.SelectedIndex = 0
        Me.cbxVersion.SelectedIndex = 0
        Me.cbxMask.SelectedIndex = 0
    End Sub

    

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim RowCount As Integer
        Dim ColCount As Integer
        Dim I As Integer
        Dim sb As SolidBrush
        Dim fn As Font
        'Dim FontSize As Integer

        ' How many rows?
        RowCount = QRCodeFontObj.GetRows()

        ' How many characters in one row?
        ColCount = QRCodeFontObj.GetCols()

        sb = New SolidBrush(Color.Black)

        fn = New Font("MW6 Matrix", System.Convert.ToInt16(cbxFontSize.Text), GraphicsUnit.Pixel)
        For I = 0 To (RowCount - 1)
            ' print one line using QRCode font
            e.Graphics.DrawString(QRCodeFontObj.GetRowStringAt(I), fn, sb, 10, 10 + I * fn.GetHeight)
        Next I

        sb.Dispose()
        fn.Dispose()
    End Sub

   

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim Message As String
        Dim Version As Integer
        Dim Level As Integer
        Dim Mask As Integer
        Dim RowCount As Integer
        Dim ColCount As Integer
        Dim I As Integer
        Dim FontSize As Integer
        Dim EncodedMsg As String

        ' Message
        Message = txtMessage.Text

        ' Version
        Version = cbxVersion.SelectedIndex

        ' Level:
        '  0: L - recovery rate 7%
        '  1: M - recovery rate 15%
        '  2: Q - recovery rate 25%
        '  3: H - recovery rate 30%
        Level = cbxLevel.SelectedIndex

        ' Mask
        Mask = cbxMask.SelectedIndex

        ' Encode data using QRCode
        QRCodeFontObj.Encode(Message, Version, Level, Mask)

        ' How many rows?
        RowCount = QRCodeFontObj.GetRows()

        ' How many characters in one row?
        ColCount = QRCodeFontObj.GetCols()

        ' Produce string for QRCode font
        EncodedMsg = "" & vbCrLf
        For I = 0 To (RowCount - 1)
            EncodedMsg = EncodedMsg & QRCodeFontObj.GetRowStringAt(I)
            EncodedMsg = EncodedMsg + vbCrLf
        Next I

        txtQRCode.Text = ""
        FontSize = System.Convert.ToInt16(cbxFontSize.Text)
        txtQRCode.Font = New Font("MW6 Matrix", FontSize, GraphicsUnit.Pixel)
        txtQRCode.Text = EncodedMsg

    End Sub

    Private Sub Cmd_save_Click(sender As Object, e As EventArgs) Handles Cmd_save.Click
        Dim Message As String
        Dim Version As Integer
        Dim Level As Integer
        Dim Mask As Integer

        ' Message
        Message = txtMessage.Text

        ' Version
        Version = cbxVersion.SelectedIndex

        ' Level:
        '  0: L - recovery rate 7%
        '  1: M - recovery rate 15%
        '  2: Q - recovery rate 25%
        '  3: H - recovery rate 30%
        Level = cbxLevel.SelectedIndex

        ' Mask
        Mask = cbxMask.SelectedIndex

        ' Encode data using QRCode
        QRCodeFontObj.Encode(Message, Version, Level, Mask)

        ' Print QRCode barcode using QRCode font
        PrintDocument1.Print()
    End Sub

   
End Class