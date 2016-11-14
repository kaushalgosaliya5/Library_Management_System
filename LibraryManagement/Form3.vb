Public Class Form3

    Dim operand As Single
    Dim op As String            ' Char
    Dim clrdisp As Boolean

    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B0.Click, B1.Click, B2.Click, B3.Click, B4.Click, B5.Click, B6.Click, B7.Click, B8.Click, B9.Click, BDOT.Click

        If clrdisp = True Then   ' if number button click that time chack ' clrdisp ' is true or false 
            TextBox1.Clear()
            clrdisp = False
        End If

        If sender.text = "." And TextBox1.Text.IndexOf(".") > -1 Then Exit Sub ' dot('.') only single time to add in textbox

        TextBox1.Text = TextBox1.Text & sender.TEXT

    End Sub

    Private Sub BPLUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPLUS.Click, BMINUS.Click, BMULTI.Click, BDIV.Click, BPOWER.Click

        If op <> "" Then BEQUAL.PerformClick()

        operand = Val(TextBox1.Text)
        op = sender.text

        clrdisp = True     ' TextBox1.Clear()
    End Sub

    Private Sub BEQUAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEQUAL.Click
        If op = "+" Then TextBox1.Text = operand + Val(TextBox1.Text)
        If op = "-" Then TextBox1.Text = operand - Val(TextBox1.Text)
        If op = "*" Then TextBox1.Text = operand * Val(TextBox1.Text)
        If op = "/" Then TextBox1.Text = operand / Val(TextBox1.Text)

        If op = "X^N" Then TextBox1.Text = Math.Pow(operand, Val(TextBox1.Text)) ' WHEN EQUAL CLICK THAT TIME MATH.POWER PERFORM AND 'OP' STORE X^N 

        op = ""

    End Sub

    Private Sub BSQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSQR.Click
        TextBox1.Text = Val(TextBox1.Text) * Val(TextBox1.Text)
    End Sub

    Private Sub BQUIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BQUIB.Click
        TextBox1.Text = Val(TextBox1.Text) * Val(TextBox1.Text) * Val(TextBox1.Text)
    End Sub

    Private Sub BSQRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSQRT.Click
        TextBox1.Text = Math.Sqrt(Val(TextBox1.Text))
    End Sub
End Class
