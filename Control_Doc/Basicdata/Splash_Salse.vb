Imports DevExpress.XtraBars.Navigation

Public Class Splash_Salse

    Private Sub AccordionControlElement5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AccordionControlElement6_Click(sender As Object, e As EventArgs) Handles AccordionControlElement6.Click
        'AccordionControlElement6.
    End Sub
    Private Function AddGroup(ByVal accrodionCtrl As AccordionControl, ByVal txt As String) As AccordionControlElement
        Dim group As New AccordionControlElement() With {.Text = txt}
        accrodionCtrl.Elements.Add(group)
        Return group
    End Function
    Private Function AddItem(ByVal gp As AccordionControlElement, ByVal txt As String) As AccordionControlElement
        Dim item As New AccordionControlElement() With {.Text = txt, .Style = ElementStyle.Item}
        gp.Elements.Add(item)
        Return item
    End Function

    Private Sub Splash_Salse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddItem(AccordionControlElement6, "sss")
    End Sub
End Class