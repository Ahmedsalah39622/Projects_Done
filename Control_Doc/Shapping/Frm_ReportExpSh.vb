Public Class Frm_ReportExpSh

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub

    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click

    End Sub

    Private Sub Frm_ReportExpSh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_Exp()

        Com_DervilyTerms.Items.Add("CIF")
        Com_DervilyTerms.Items.Add("EX-Work")
        Com_DervilyTerms.Items.Add("FOB")
        Com_DervilyTerms.Items.Add("CFR")
        Com_DervilyTerms.Items.Add("FAS")
        Com_DervilyTerms.Items.Add("FCA")
    End Sub

    Sub fill_Exp()
        com_Exp.Items.Clear()
        If varcodeBand = 2 Then
            sql = "SELECT RTRIM(dbo.ST_CHARTOFACCOUNT.AccountName) AS NameAcc " & _
            " FROM     dbo.TB_GroupExpeness INNER JOIN " & _
            "                  dbo.ST_CHARTOFACCOUNT ON dbo.TB_GroupExpeness.Compny_Code = dbo.ST_CHARTOFACCOUNT.Compny_Code AND  " & _
            "        dbo.TB_GroupExpeness.AccountNoExspensess = dbo.ST_CHARTOFACCOUNT.Account_No " & _
            "        WHERE(dbo.TB_GroupExpeness.Compny_Code = '" & VarCodeCompny & "') "

        End If

        If varcodeBand = 1 Then
            sql = "select * from Vw_AllTaxName where Compny_Code = '" & VarCodeCompny & "' "
        End If

        rs = Cnn.Execute(sql)
        Do While Not rs.EOF
            com_Exp.Items.Add(rs("NameAcc").Value)
            rs.MoveNext()
        Loop
    End Sub



   

    Private Sub Com_SuppliserName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_SuppliserName.ButtonClick
        VarOpenlookup2 = 25251
        varcode_form = 25251
        Frm_LookUpSuppliser.Find_Suppliser()
        Frm_LookUpSuppliser.ShowDialog()
    End Sub

    Private Sub Com_SuppliserName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_SuppliserName.EditValueChanged

    End Sub

    Private Sub Com_Shipping_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shipping.ButtonClick
        vartable = "TB_ShippingCompny"
        VarOpenlookup = 12030
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shipping_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Shipping.EditValueChanged

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        If varcodeBand = 2 Then varprintEx = 4
        If varcodeBand = 1 Then varprintEx = 5
        Frm_RptShipping.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Com_SuppliserName.Text = ""
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Com_Shipping.Text = ""
    End Sub
End Class