Imports System.Data.OleDb
Public Class Form4


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then MsgBox("PLEASE ENTER USER NAME ") : TextBox1.Focus() : Exit Sub
        If TextBox2.Text = "" Then MsgBox("PLEASE ENTER OLD PASSWORD ") : TextBox2.Focus() : Exit Sub
        If TextBox3.Text = "" Then MsgBox("PLEASE ENTER NEW PASSWORD ") : TextBox3.Focus() : Exit Sub
        If TextBox4.Text = "" Then MsgBox("PLEASE ENTER CONFIRM PASSWORD ") : TextBox4.Focus() : Exit Sub
        If TextBox3.Text <> TextBox4.Text Then MsgBox("CONFIRM PASSWORD IS NOT CORRECT") : TextBox4.Clear() : TextBox4.Focus() : Exit Sub

        Dim cmd1 As New OleDbCommand
        cmd1.CommandText = "select Password from Login where UserName = '" & TextBox1.Text & "'"
        cmd1.Connection = Form1.cn
        Dim pass As String = cmd1.ExecuteScalar

        If pass = "" Then MsgBox("YOUR USER NAME IS NOT FOUND") : Exit Sub

        If pass <> TextBox2.Text Then
            MsgBox("YOUR OLD PASSWORD IS WRONG")
            TextBox2.Clear()
            TextBox2.Focus()
            Exit Sub
        End If

        Dim NewPass As String = TextBox4.Text
        MsgBox(NewPass)
        Dim cmd2 As New OleDbCommand
        cmd2.CommandText = "UPDATE Login SET Password = '" & NewPass & "' WHERE UserName = '" & TextBox1.Text & "'"
        cmd2.Connection = Form1.cn
        cmd2.ExecuteNonQuery()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class