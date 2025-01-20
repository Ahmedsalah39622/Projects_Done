Public Class Frm_ReportCost

    Private Sub cmd_All2_Click(sender As Object, e As EventArgs) Handles cmd_All2.Click
        Com_SuppliserName.Text = ""
    End Sub

    Private Sub cmd_All4_Click(sender As Object, e As EventArgs) Handles cmd_All4.Click
        Com_CityName.Text = ""
    End Sub

    Private Sub cmd_All3_Click(sender As Object, e As EventArgs) Handles cmd_All3.Click
        Com_Shipping.Text = ""
    End Sub

    Private Sub Com_SuppliserName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_SuppliserName.ButtonClick
        VarOpenlookup2 = 25250
        varcode_form = 25250
        Frm_LookUpSuppliser.Find_Suppliser()
        Frm_LookUpSuppliser.ShowDialog()
    End Sub

    Private Sub Com_SuppliserName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_SuppliserName.EditValueChanged

    End Sub

    Private Sub Com_Shipping_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_Shipping.ButtonClick
        vartable = "TB_ShippingCompny"
        VarOpenlookup = 12023
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_Shipping_EditValueChanged(sender As Object, e As EventArgs) Handles Com_Shipping.EditValueChanged

    End Sub

    Private Sub Com_CityName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles Com_CityName.ButtonClick
        vartable = "BD_CITIES"
        VarOpenlookup = 12025
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub Com_CityName_EditValueChanged(sender As Object, e As EventArgs) Handles Com_CityName.EditValueChanged

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        varprintEx = 3
        Frm_RptShipping.Show()
    End Sub

    Private Sub Frm_ReportCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class