Public Class Frm_CopyRev
    Sub last_Rev()
        On Error Resume Next
        sql = "  SELECT MAX(Rev) + 1 AS LastRev, CostCenter_account1        FROM dbo.TB_Hader_Technical_Specifications GROUP BY CostCenter_account1 HAVING (CostCenter_account1 = '" & varcode_project & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_Rev.Text = rs("LastRev").Value Else txt_Rev.Text = "0"



    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Len(txt_ProjectName.Text) = 0 Then MsgBox("Pleas Insert ProjectName ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Rev.Text) = 0 Then MsgBox("Pleas Entry Rev ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        'If Len(txt_NamePanel.Text) = 0 Then MsgBox("Pleas Insert Name Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub




        'sql = "select * from TB_Hader_Technical_Specifications where ItemSn  = '" & txt_ProjectName.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' "
        'rs = Cnn.Execute(sql)
        'If rs.EOF = False Then
        'Else


        '    '=========================رقم Location
        '    sql2 = "   SELECT Level_No2, AccountName, Account_No          FROM dbo.ST_CHARTCOSTCENTER WHERE  (AccountName = '" & Trim(Frm_PanelsTechnicalspecifications.cb_SubNamePrj.Text) & "')"
        '    rs = Cnn.Execute(sql2)
        '    If rs.EOF = False Then varcodeaccountSubProject = rs("Account_No").Value
        '    '================================================Open or close
        '    'If Radio_Open.Checked = True Then varsutasorder = 0
        '    'If Radio_Close.Checked = True Then varsutasorder = 1
        '    '=========================================================
        '    'sql = "INSERT INTO TB_Hader_Technical_Specifications (CostCenter_account1, CostCenter_account2,ItemSn,PanelName,Quantity,PanelType,INCOMING,OUTGOING,MOUNTING,Color,Separation,Protection,BUSBAR1,BUSBAR2,Status_Approval,size,H,W,D) " & _
        '    '          " values  (N'" & varcode_project & "' ,N'" & varcodeaccountSubProject & "',N'" & txt_ItemSn.Text & "',N'" & txt_NamePanel.Text & "',N'" & txt_Quantity.Text & "',N'" & Frm_PanelsTechnicalspecifications.Com_TypePanel.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_INCOMING.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_OutGoing2.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Mounting.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Color.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Separation.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Protection.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_BUSBAR1.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_BUSBAR2.Text & "',N'" & 0 & "','" & Frm_PanelsTechnicalspecifications.txt_size.Text & "','" & Frm_PanelsTechnicalspecifications.txt_H.Text & "','" & Frm_PanelsTechnicalspecifications.txt_W.Text & "','" & Frm_PanelsTechnicalspecifications.txt_D.Text & "')"
        '    'Cnn.Execute(sql)
        '===================================================Hedar
        sql2 = "select * from TB_Hader_Technical_Specifications where   CostCenter_account1 ='" & varcode_project & "'   and Rev  = '" & Val(txt_Rev.Text) - 1 & "'  "
        rs = Cnn.Execute(sql2)
        Do While Not rs.EOF

            sql = "INSERT INTO TB_Hader_Technical_Specifications (CostCenter_account1,CostCenter_account2,ItemSn,rev,PanelName,Quantity,PanelType,INCOMING,OUTGOING,MOUNTING,Color,Separation,Protection,BUSBAR1,BUSBAR2,Status_Approval,Size,H,W,D,Status_Approval_Admin,GrandTotal,MANPOWER,N_Indirct,IndirctCost,N_TAX,GrandTAX,N_Profit,GrandTotalProfit) " & _
                " values  ('" & varcode_project & "','" & varcodeaccountSubProject & "','" & rs("ItemSn").Value & "','" & txt_Rev.Text & "','" & rs("PanelName").Value & "','" & rs("Quantity").Value & "','" & rs("PanelType").Value & "','" & rs("INCOMING").Value & "','" & rs("OUTGOING").Value & "','" & rs("MOUNTING").Value & "','" & rs("Color").Value & "','" & rs("Separation").Value & "','" & rs("Protection").Value & "','" & rs("BUSBAR1").Value & "','" & rs("BUSBAR2").Value & "','" & rs("Status_Approval").Value & "','" & rs("Size").Value & "','" & rs("H").Value & "','" & rs("W").Value & "','" & rs("D").Value & "','" & rs("Status_Approval_Admin").Value & "','" & rs("GrandTotal").Value & "','" & rs("MANPOWER").Value & "','" & rs("N_Indirct").Value & "','" & rs("IndirctCost").Value & "','" & rs("N_TAX").Value & "','" & rs("GrandTAX").Value & "','" & rs("N_Profit").Value & "','" & rs("GrandTotalProfit").Value & "')"
            Cnn.Execute(sql)

            rs.MoveNext()
        Loop

        '=================================


        '==================================================================================
        sql2 = "select * from TB_Detalis_Technical_Specifications where   CostCenter_account1 ='" & varcode_project & "' and rev ='" & Val(txt_Rev.Text) - 1 & "'     "
        rs = Cnn.Execute(sql2)
        Do While Not rs.EOF

            sql = "INSERT INTO TB_Detalis_Technical_Specifications (CostCenter_account1,CostCenter_account2,ItemSn,No_Item,Qty_Technical_Specifications,price_Technical_Specifications,discount_Technical_Specifications,Total_Technical_Specifications,Ref_No,Categorize,rev) " & _
                " values  ('" & varcode_project & "','" & varcodeaccountSubProject & "','" & rs("ItemSn").Value & "','" & rs("No_Item").Value & "','" & rs("Qty_Technical_Specifications").Value & "','" & rs("price_Technical_Specifications").Value & "','" & rs("discount_Technical_Specifications").Value & "','" & rs("Total_Technical_Specifications").Value & "','" & rs("Ref_No").Value & "','" & rs("Categorize").Value & "','" & txt_Rev.Text & "')"
            Cnn.Execute(sql)

            rs.MoveNext()
        Loop


        MsgBox("تم النسخ", MsgBoxStyle.Information, "Css Solution Software Module")
        Frm_PanelsTechnicalspecifications.find_hedar()
        Frm_PanelsTechnicalspecifications.find_detalis()
        Frm_PanelsTechnicalspecifications.Fill_DataPanal()
    End Sub

    Private Sub Frm_CopyRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        last_Rev()
    End Sub
End Class