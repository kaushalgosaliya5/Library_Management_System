Imports System.Data.OleDb
Public Class Form1

    Public Shared cn As New OleDbConnection
    Public Shared cmd As New OleDbCommand

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cn.ConnectionString = "provider = microsoft.jet.oledb.4.0;data source = Library.mdb"
        cn.Open()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then MsgBox("PLEASE ENTER USER NAME ") : TextBox1.Focus() : Exit Sub
        If TextBox2.Text = "" Then MsgBox("PLEASE ENTER PASSWORD ") : TextBox2.Focus() : Exit Sub

        cmd.CommandText = "select Password from Login where UserName = '" & TextBox1.Text & "'"
        cmd.Connection = cn
        Dim pass As String = cmd.ExecuteScalar

        If pass = TextBox2.Text Then
            Dim frm As New Form2
            frm.Show()
            Me.Hide()
        Else
            MsgBox("YOUR USERNAME OR PASSWORD IS INCORRECT")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
