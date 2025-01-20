Public Class Frm_ReportDaily

    Private Sub Com_SuppliserName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_SuppliserName.ButtonClick
        VarOpenlookup2 = 25253
        varcode_form = 25253
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

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub
End Class