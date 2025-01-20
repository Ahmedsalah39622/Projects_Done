Public Class frm_CostCenter
    Dim VarLevel_No, VarLevel_No2, VarLevel_No3, VarNo_Serail As Integer
    Dim varcodetype, varmaxlevel As Integer
    Dim varlevel, varsavelevel1 As Integer
    Public Data As New DataTable

    Public Data2 As New DataTable


    Private Sub Frm_ChartofAccount3_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next


        Data.Columns.Add("Id")
        Data.Columns.Add("Name")
        Data.Columns.Add("Node_Id")

        rs = New ADODB.Recordset
        sql = "select  * from ST_CHARTCOSTCENTER  where Compny_Code = '" & VarCodeCompny & "'   order by Level_No ,No_Serail,Account_No   "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF


            If rs("Level_No").Value = 0 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), 0) 'المستوى الاول
            If rs("Level_No").Value = 1 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى
            If rs("Level_No").Value = 2 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى
            If rs("Level_No").Value = 3 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى




            rs.MoveNext()
        Loop
        rs.Close()


        Dim Node As TreeNode
        For Each Row As DataRow In Data.Rows
            Node = New TreeNode(Row("Name"))
            Node.Name = Row("Id")

            If Row("Node_Id") <> 0 Then
                TreeView1.Nodes.Find(Row("Node_Id"), True)(0).Nodes.Add(Node)
            Else
                TreeView1.Nodes.Add(Node)
            End If

        Next

        'TreeView1.ExpandAll()
        TreeView1.CollapseAll()



    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        select_Tree()

    End Sub


    Sub select_Tree()
        On Error Resume Next
        txt_AccountNo2.Text = ""
        txt_NameAccount2.Text = ""
        varsavelevel1 = 0
        '===================================Select Account
        sql = "    SELECT * FROM ST_CHARTCOSTCENTER WHERE  (AccountNo_Name = '" & Trim(TreeView1.SelectedNode.Text.ToString()) & "')  and Compny_Code = '" & VarCodeCompny & "' "
        rs3 = Cnn.Execute(sql)
        If rs3.EOF = False Then
            varlevel = rs3("Level_No").Value
            txt_AccountNo1.Text = Trim(rs3("Account_No").Value)
            VarLevel_No = Trim(rs3("Level_No2").Value)
            VarNo_Serail = Trim(rs3("NO_SERAIL").Value)
            txt_NameAccount1.Text = Trim(rs3("AccountName").Value)

            If Trim(rs3("AccountType").Value) = 0 Then Chek1.Checked = True
            If Trim(rs3("AccountType").Value) = 1 Then Chek2.Checked = True

            If Trim(rs3("AccountPh").Value) = 0 Then Chek3.Checked = True
            If Trim(rs3("AccountPh").Value) = 1 Then Chek4.Checked = True

        End If
        If varlevel = 3 Then txt_AccountNo2.Visible = False : txt_NameAccount2.Visible = False : LabelX1.Visible = False Else txt_AccountNo2.Visible = True : txt_NameAccount2.Visible = True : LabelX1.Visible = True
        '==========================================================

        'sql = "  SELECT  Level_No2, MAX(Account_No) + 1 AS SumMaxLevel FROM ST_CHARTCOSTCENTER GROUP BY Level_No2" & _
        '" HAVING(Level_No2 = '" & VarNo_Serail & "') "
        If varlevel = 0 Then
            sql = "SELECT Level_No2, MAX(Account_No) + 1 AS SumMaxLevel, Level_No " & _
            " FROM     ST_CHARTCOSTCENTER " & _
            " where Compny_Code = '" & VarCodeCompny & "'  " & _
            " GROUP BY Level_No2, Level_No " & _
            " HAVING (Level_No2 = '" & VarNo_Serail & "') AND (Level_No = '" & 1 & "') "
        Else

            sql = "SELECT Level_No2, MAX(Account_No) + 1 AS SumMaxLevel, Level_No " & _
                      " FROM     ST_CHARTCOSTCENTER " & _
                      " where Compny_Code = '" & VarCodeCompny & "'  " & _
                      " GROUP BY Level_No2, Level_No " & _
                      " HAVING (Level_No2 = '" & VarNo_Serail & "')  "
        End If


        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            txt_AccountNo2.Text = Trim(rs2("SumMaxLevel").Value)
            txt_AccountNo2.Visible = True : txt_NameAccount2.Visible = True : LabelX1.Visible = True

        Else
            If Len(Trim(VarNo_Serail)) = 6 Then txt_AccountNo2.Text = Trim(Str(VarNo_Serail)) + "001"
            If Len(Trim(VarNo_Serail)) = 3 Then txt_AccountNo2.Text = Trim(Str(VarNo_Serail)) + "001"
            If Len(Trim(VarNo_Serail)) = 1 Then txt_AccountNo2.Text = Trim(Str(VarNo_Serail)) + "01"

        End If

        txt_NameAccount2.Select()
    End Sub



    Sub save_tree()
        On Error Resume Next
        If Len(txt_NameAccount1.Text) = 0 Then MsgBox("من فضلك اختار الحساب  ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub

        If varsavelevel1 <> 1 Then
            If txt_NameAccount2.Text = "" Then MsgBox("من فضلك ادخل اسم الحساب", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module") : Exit Sub
        End If


        If Len(Trim(txt_AccountNo2.Text)) = 9 Then VarLevel_No = 3
        If Len(Trim(txt_AccountNo2.Text)) = 6 Then VarLevel_No = 2
        If Len(Trim(txt_AccountNo2.Text)) = 3 Then VarLevel_No = 1

        If varsavelevel1 <> 1 Then
            sql = "INSERT INTO ST_CHARTCOSTCENTER (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
               " values  (N'" & VarLevel_No & "' ,N'" & txt_AccountNo2.Text & "',N'" & txt_AccountNo2.Text & "',N'" & txt_AccountNo1.Text & "',N'" & txt_NameAccount2.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_AccountNo2.Text + "-" + txt_NameAccount2.Text & "','" & txt_AccountNo2.Text & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)
            txt_NameAccount2.Text = ""
        Else
            sql = "INSERT INTO ST_CHARTCOSTCENTER (Level_No, No_Serail,Account_No,Level_No2,AccountName,AccountType,AccountPh,AccountNo_Name,Account_No_Update,Compny_Code) " & _
         " values  (N'" & 0 & "' ,N'" & txt_AccountNo1.Text & "',N'" & txt_AccountNo1.Text & "',N'" & txt_AccountNo1.Text & "',N'" & txt_NameAccount1.Text & "',N'" & 0 & "',N'" & 0 & "',N'" & txt_AccountNo1.Text + "-" + txt_NameAccount1.Text & "',N'" & txt_AccountNo1.Text & "','" & VarCodeCompny & "')"
            Cnn.Execute(sql)
            txt_NameAccount1.Text = ""
        End If




        MsgBox("Save Data ", MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight, "ERP Solution Software Module")

        find_tree()
        TreeView1.Refresh()
        'TreeView1.Nodes.Clear()
        'Find_Node()
    End Sub






    Sub find_tree()
        'On Error Resume Next

        'TreeView1.Nodes.RemoveAt()
        Dim Data2 As New DataTable
        Data2.Columns.Add("Id")
        Data2.Columns.Add("Name")
        Data2.Columns.Add("Node_Id")

        rs = New ADODB.Recordset
        sql = "select  * from ST_CHARTCOSTCENTER   order by Level_No ,No_Serail,Account_No  where Compny_Code = '" & VarCodeCompny & "'    "
        rs = Cnn.Execute(sql)
        Do While Not rs.EOF


            If rs("Level_No").Value = 0 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), 0) 'المستوى الاول
            If rs("Level_No").Value = 1 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى
            If rs("Level_No").Value = 2 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى
            If rs("Level_No").Value = 3 Then Data.Rows.Add(rs("Account_No").Value, Trim(rs("AccountNo_Name").Value), rs("Level_No2").Value) 'المستوى الثانى




            rs.MoveNext()
        Loop
        rs.Close()


        Dim Node As TreeNode
        For Each Row As DataRow In Data2.Rows
            Node = New TreeNode(Row("Name"))
            Node.Name = Row("Id")

            If Row("Node_Id") <> 0 Then
                TreeView1.Nodes.Find(Row("Node_Id"), True)(0).Nodes.Add(Node)
            Else
                TreeView1.Nodes.Add(Node)
            End If

        Next

        TreeView1.ExpandAll()
        'TreeView1.CollapseAll()
    End Sub

    Private Sub txt_NameAccount2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_NameAccount2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            save_tree()
            select_Tree()
        End If
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        save_tree()
        select_Tree()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'On Error Resume Next
        Dim VarType, VarType2 As Integer

        If Len(txt_NameAccount1.Text) = 0 Then MsgBox("من فضلك اختار الحساب المراد تعديلة ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub


        If Chek1.Checked = True Then VarType = 0
        If Chek2.Checked = True Then VarType = 1

        If Chek3.Checked = True Then VarType2 = 0
        If Chek4.Checked = True Then VarType2 = 1

        sql = "    update      ST_CHARTCOSTCENTER set  AccountType='" & VarType & "' ,accountph= '" & VarType2 & "' " & _
        " WHERE  (Account_No_Update LIKE '" & Trim(txt_AccountNo1.Text) & "%') and  Compny_Code = '" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)


        sql = "UPDATE  ST_CHARTCOSTCENTER  SET AccountName = '" & txt_NameAccount1.Text & "',AccountNo_Name = '" & txt_AccountNo1.Text + "-" + txt_NameAccount1.Text & "'  WHERE Account_No = '" & txt_AccountNo1.Text & "' and Compny_Code = '" & VarCodeCompny & "'  "
        rs = Cnn.Execute(sql)
        MsgBox("تم التعديل", MsgBoxStyle.Information, "CSS Solution Software Module")
        'find_tree()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        On Error Resume Next
        If Len(txt_NameAccount1.Text) = 0 Then MsgBox("من فضلك اختار الحساب المراد حذفه ", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRtlReading, "ERP Solution Software Module") : Exit Sub



        If varlevel = 2 Then
            sql = "select * from Vw_AllAccountBalane where level3 ='" & txt_AccountNo1.Text & "' and Account_No ='" & txt_AccountNo1.Text & "' "
            rs2 = Cnn.Execute(sql)
            If rs2.EOF = False Then MsgBox("الحساب يوجد ارقام حسابات بداخلة لايمكن الحذف", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        End If

        If varlevel = 1 Then
            sql = "select * from Vw_AllAccountBalane where level2 ='" & txt_AccountNo1.Text & "' and level3 ='" & txt_AccountNo1.Text & "'"
            rs2 = Cnn.Execute(sql)
            If rs2.EOF = False Then MsgBox("الحساب يوجد ارقام حسابات بداخلة لايمكن الحذف", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        End If


        If varlevel = 0 Then
            sql = "select * from Vw_AllAccountBalane where level1 ='" & txt_AccountNo1.Text & "' and level2 ='" & txt_AccountNo1.Text & "' "
            rs2 = Cnn.Execute(sql)
            If rs2.EOF = False Then MsgBox("الحساب يوجد ارقام حسابات بداخلة لايمكن الحذف", MsgBoxStyle.Critical, "CSS Solution Software Module") : Exit Sub
        End If


        Dim x As String
        x = MsgBox("هل تريد حذف الحساب", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.MsgBoxRight, "CSS Solution Software Module")

        Select Case x
            Case vbNo

            Case vbYes


                sql = "Delete ST_CHARTCOSTCENTER  WHERE Account_No = " & txt_AccountNo1.Text & "   "
                rs = Cnn.Execute(sql)

                MsgBox("تم الحذف", MsgBoxStyle.Information, "CSS Solution Software Module")

                TreeView1.SelectedNode.Remove()
                'find_tree()
        End Select
        'find_tree()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        sql = " SELECT Level_No, MAX(Account_No) + 1 AS SumMaxLevel " & _
      " FROM    ST_CHARTCOSTCENTER " & _
      " where Compny_Code = '" & VarCodeCompny & "'  " & _
      " GROUP BY Level_No " & _
      " HAVING (Level_No = '0') "

        rs2 = Cnn.Execute(sql)
        If rs2.EOF = False Then
            txt_AccountNo1.Text = Trim(rs2("SumMaxLevel").Value)
            txt_AccountNo2.Visible = False : txt_NameAccount2.Visible = False : LabelX1.Visible = False
            txt_NameAccount1.Text = ""
            varsavelevel1 = 1
        Else
            txt_AccountNo1.Text = "1"
            txt_AccountNo2.Visible = False : txt_NameAccount2.Visible = False : LabelX1.Visible = False
            txt_NameAccount1.Text = ""
            varsavelevel1 = 1
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        TreeView1.ExpandAll()

    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        TreeView1.CollapseAll()
    End Sub
End Class