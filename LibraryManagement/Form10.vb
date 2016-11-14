Imports System.Data.OleDb
Public Class Form10

    Dim dr As OleDbDataReader
    Dim cmd As New OleDbCommand

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        cmd.CommandText = "select MCode,MName from Member"
        cmd.Connection = Form1.cn
        dr = cmd.ExecuteReader()

        While dr.Read
            ComboBox1.Items.Add("M" & dr.Item(0) & "      " & dr.Item(1))
        End While

        dr.Close()

        cmd.CommandText = "select BCode,BTital from Books where BCode not in (select BCode from Tranjection where TReturn is NULL)"
        cmd.Connection = Form1.cn
        dr = cmd.ExecuteReader()

        While dr.Read
            ComboBox2.Items.Add("B" & dr.Item(0) & "      " & dr.Item(1))
        End While

        dr.Close()

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim dt As Date = Now
        Label2.Text = dt.ToString("D")
        Label3.Text = dt.ToString("t")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label5.Text = ComboBox1.Text.Remove(5)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label6.Text = ComboBox2.Text.Remove(5)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Then MsgBox("PLEASE SELECT MEMBER CODE") : ComboBox1.Focus() : Exit Sub
        If ComboBox2.Text = "" Then MsgBox("PLEASE SELECT BOOK CODE") : ComboBox2.Focus() : Exit Sub

        Dim cmd3 As New OleDbCommand
        cmd3.CommandText = "select count(MCode) from Tranjection where MCode = '" & Label5.Text.Replace("M", "") & "'"
        cmd3.Connection = Form1.cn
        MsgBox(cmd3.ExecuteScalar)
        Dim cnt As Integer = cmd3.ExecuteScalar()

        If cnt = 3 Then
            MsgBox("YOU HAVE PURCHASE 3 BOOKS NOT ANY AGAIN")
            Exit Sub
        End If

        Dim cmd1 As New OleDbCommand

        cmd1.CommandText = "select max(TCode) from Tranjection"
        cmd1.Connection = Form1.cn
        MsgBox(cmd1.ExecuteScalar)
        Dim LastCode As String = cmd1.ExecuteScalar.ToString.Replace("T", "") + 1

        If LastCode < 10 Then
            LastCode = "T000" & LastCode
        ElseIf LastCode < 100 Then
            LastCode = "T00" & LastCode
        ElseIf LastCode < 1000 Then
            LastCode = "T0" & LastCode
        Else
            LastCode = "T" & LastCode
        End If

        MsgBox(LastCode & " " & Label5.Text.Replace("M", "") & "  " & Label6.Text.Replace("B", "") & "  " & Format(DateTimePicker1.Value, "dd-MM-yyyy"))

        Dim cmd2 As New OleDbCommand
        cmd2.CommandText = "insert into Tranjection(TCode,MCode,BCode,TDate) values ('" & LastCode & "','" & Label5.Text.Replace("M", "") & "','" & Label6.Text.Replace("B", "") & "', #" & Format(DateTimePicker1.Value, "dd-MM-yyyy") & "#)"
        cmd2.Connection = Form1.cn
        cmd2.ExecuteNonQuery()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        MsgBox(LastCode)
    End Sub
End Class