Public Class Frm_CopyPanal

    Private Sub Frm_CopyPanal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        last_itemSn()
    End Sub
    Sub last_itemSn()
        On Error Resume Next
        sql = "  SELECT MAX(ItemSn) AS MaxItemSn, CostCenter_account1        FROM dbo.TB_Hader_Technical_Specifications GROUP BY CostCenter_account1 HAVING (CostCenter_account1 = '" & varcode_project & "')"
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then txt_ItemSn.Text = rs("MaxItemSn").Value + 1 Else txt_ItemSn.Text = "1"



    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'Frm_PanelsTechnicalspecifications.save_Technical_Specifications_Header()

        If Len(txt_ItemSn.Text) = 0 Then MsgBox("Pleas Insert Item sn ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_Quantity.Text) = 0 Then MsgBox("Pleas Entry Quantity ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub
        If Len(txt_NamePanel.Text) = 0 Then MsgBox("Pleas Insert Name Panel ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "Cerative Smart Software ") : Exit Sub




        sql = "select * from TB_Hader_Technical_Specifications where ItemSn  = '" & txt_ItemSn.Text & "'  and CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "' "
        rs = Cnn.Execute(sql)
        If rs.EOF = False Then
        Else


            '=========================رقم Location
            sql2 = "   SELECT Level_No2, AccountName, Account_No          FROM dbo.ST_CHARTCOSTCENTER WHERE  (AccountName = '" & Trim(Frm_PanelsTechnicalspecifications.cb_SubNamePrj.Text) & "')"
            rs = Cnn.Execute(sql2)
            If rs.EOF = False Then varcodeaccountSubProject = rs("Account_No").Value
            '================================================Open or close
            'If Radio_Open.Checked = True Then varsutasorder = 0
            'If Radio_Close.Checked = True Then varsutasorder = 1
            '=========================================================
            sql = "INSERT INTO TB_Hader_Technical_Specifications (CostCenter_account1, CostCenter_account2,ItemSn,PanelName,Quantity,PanelType,INCOMING,OUTGOING,MOUNTING,Color,Separation,Protection,BUSBAR1,BUSBAR2,Status_Approval,size,H,W,D) " & _
                      " values  (N'" & varcode_project & "' ,N'" & varcodeaccountSubProject & "',N'" & txt_ItemSn.Text & "',N'" & txt_NamePanel.Text & "',N'" & txt_Quantity.Text & "',N'" & Frm_PanelsTechnicalspecifications.Com_TypePanel.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_INCOMING.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_OutGoing2.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Mounting.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Color.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Separation.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_Protection.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_BUSBAR1.Text & "',N'" & Frm_PanelsTechnicalspecifications.txt_BUSBAR2.Text & "',N'" & 0 & "','" & Frm_PanelsTechnicalspecifications.txt_size.Text & "','" & Frm_PanelsTechnicalspecifications.txt_H.Text & "','" & Frm_PanelsTechnicalspecifications.txt_W.Text & "','" & Frm_PanelsTechnicalspecifications.txt_D.Text & "')"
            Cnn.Execute(sql)

            ''============================== TransactionHistoryCode
            'sql2 = "INSERT INTO [dbo].[UserTransactionHistory]([UserID],[Date],[Time],[TypeBillCode],[BtnCode],[CompanyCode],[PcUserName],[BillCode]) VALUES ('" & varcode_User & "',N'" & DateTime.Now.ToString("yyyy/MM/dd") & "',N'" & DateTime.Now.ToString("HH:mm:ss") & "','21','1','" & VarCodeCompny & "',N'" & PcUserName & "',N'" & txt_ItemSn.Text & "')"
            'rs2 = Cnn.Execute(sql2)
            ''==============================

        End If

        '==================================================================================
        sql2 = "select * from TB_Detalis_Technical_Specifications where   CostCenter_account1 ='" & varcode_project & "' and CostCenter_account2 ='" & varcodeaccountSubProject & "'  and ItemSn  = '" & Frm_PanelsTechnicalspecifications.txt_ItemSn.Text & "'  "
        'rs = Cnn.Execute(sql2)
        rs = Cnn.Execute(sql2)
        Do While Not rs.EOF

            sql = "INSERT INTO TB_Detalis_Technical_Specifications (CostCenter_account1,CostCenter_account2,ItemSn,No_Item,Qty_Technical_Specifications,price_Technical_Specifications,discount_Technical_Specifications,Total_Technical_Specifications,Ref_No,Categorize) " & _
                " values  ('" & varcode_project & "','" & varcodeaccountSubProject & "','" & txt_ItemSn.Text & "','" & rs("No_Item").Value & "','" & rs("Qty_Technical_Specifications").Value & "','" & rs("price_Technical_Specifications").Value & "','" & rs("discount_Technical_Specifications").Value & "','" & rs("Total_Technical_Specifications").Value & "','" & rs("Ref_No").Value & "','" & rs("Categorize").Value & "')"
            Cnn.Execute(sql)

            rs.MoveNext()
        Loop


        MsgBox("تم النسخ", MsgBoxStyle.Information, "Css Solution Software Module")

    End Sub
End Class