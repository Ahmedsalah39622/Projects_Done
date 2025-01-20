Public Class Frm_ReportCostItem

    Private Sub com_GroupItemName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_GroupItemName.ButtonClick
        vartable = "BD_GROUPITEMMAIN"
        VarOpenlookup = 100015
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_SuppliserName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_SuppliserName.ButtonClick
        VarOpenlookup2 = 25252
        varcode_form = 25252
        Frm_LookUpSuppliser.Find_Suppliser()
        Frm_LookUpSuppliser.ShowDialog()
    End Sub

    Private Sub Com_SuppliserName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_SuppliserName.EditValueChanged

    End Sub

    Private Sub Com_Shipping_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shipping.ButtonClick
        vartable = "TB_ShippingCompny"
        VarOpenlookup = 12031
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shipping_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Shipping.EditValueChanged

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Com_Shipping.Text = ""
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Com_SuppliserName.Text = ""
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        com_ItemName.Text = ""
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        com_GroupItemName.Text = ""
    End Sub

    Private Sub com_GroupItemName_EditValueChanged(sender As Object, e As EventArgs) Handles com_GroupItemName.EditValueChanged

    End Sub

    Private Sub com_ItemName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles com_ItemName.ButtonClick
        If com_GroupItemName.Text = "" Then
            'VarOpenlookup = 100015
            'Frm_Lookup.Text = "بحث"
            'Frm_Lookup.ShowDialog()
        End If

        If com_GroupItemName.Text <> "" Then
            VarOpenlookup = 100016
            Frm_Lookup.Text = "بحث"
            Frm_Lookup.ShowDialog()
        End If
    End Sub

    Private Sub com_ItemName_EditValueChanged(sender As Object, e As EventArgs) Handles com_ItemName.EditValueChanged

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        varprintEx = 6
        Frm_RptShipping.Show()
    End Sub
End Class