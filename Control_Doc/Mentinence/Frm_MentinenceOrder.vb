Public Class Frm_MentinenceOrder

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        VarOpenlookup2 = 29
        varcode_form = 29
        Frm_LookUpCustomer.Find_Customer()
        Frm_LookUpCustomer.ShowDialog()
        find_customer2()
    End Sub
    Sub find_customer2()
        On Error Resume Next
        sql = "  SELECT        Compny_Code, Customer_Code, Customer_Name, Customer_Address, Customer_Phon1      FROM dbo.St_CustomerData WHERE        (Compny_Code = '" & VarCodeCompny & "') "
        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then txt_AddressCustomer.Text = rs2("Customer_Address").Value : txt_Phone.Text = rs2("Customer_Phon1").Value Else txt_AddressCustomer.Text = "" : txt_Phone.Text = ""

    End Sub

    Private Sub txt_Type_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txt_Type.ButtonClick
        vartable = "BD_TypeMintes"
        VarOpenlookup = 69
        'Frm_Lookup.MdiParent = Me
        Frm_Lookup.Text = "بحث"
        Frm_Lookup.ShowDialog()
    End Sub

    Private Sub txt_NameDiractorat_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Type.EditValueChanged

    End Sub

    Private Sub Frm_MentinenceOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Com_status.Items.Add("مفتوح")
        Com_status.Items.Add("تحت التنفيذ")
        Com_status.Items.Add("مغلق")

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Frm_PrintOrder_M.Show()
    End Sub
End Class