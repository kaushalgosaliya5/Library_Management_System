Imports System.Data.OleDb
Public Class Form11

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        DateTimePicker1.Value = Now

        Dim dr1 As OleDbDataReader
        Dim cmd1 As New OleDbCommand

        cmd1.CommandText = "select MCode,MName from Member where MCode in (select distinct(MCode) from Tranjection where TReturn is NULL)"
        cmd1.Connection = Form1.cn
        dr1 = cmd1.ExecuteReader

        While dr1.Read
            ComboBox1.Items.Add("M" & dr1.Item(0) & "      " & dr1.Item(1))
        End While

        dr1.Close()
        TextBox1.Text = ""
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim dt As Date = Now
        Label2.Text = dt.ToString("D")
        Label3.Text = dt.ToString("t")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label5.Text = ComboBox1.Text.Remove(5)

        Dim dr2 As OleDbDataReader
        Dim cmd2 As New OleDbCommand
       
        cmd2.CommandText = "select BCode,BTital from Books where BCode in (select BCode from Tranjection where MCode = '" & Label5.Text.Replace("M", "") & "' and TReturn is NULL)"
        cmd2.Connection = Form1.cn
        dr2 = cmd2.ExecuteReader

        ComboBox2.Items.Clear()
        While dr2.Read
            ComboBox2.Items.Add("B" & dr2.Item(0) & "      " & dr2.Item(1))
        End While

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label6.Text = ComboBox2.Text.Remove(5)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        If ComboBox1.Text = "" Then MsgBox("PLEASE SELECT MEMBER CODE") : ComboBox1.Focus() : Exit Sub
        If ComboBox2.Text = "" Then MsgBox("PLEASE SELECT BOOK CODE") : ComboBox2.Focus() : Exit Sub

        Dim cmd3 As New OleDbCommand
        cmd3.CommandText = "update Tranjection set TReturn = #" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "# , Find = " & CInt(TextBox1.Text) & " where MCode = '" & Label5.Text.Replace("M", "") & "' and BCode = '" & Label6.Text.Replace("B", "") & "'"
        cmd3.Connection = Form1.cn
        cmd3.ExecuteNonQuery()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        Label5.Text = "MCode"
        Label6.Text = "BCode"
        DateTimePicker1.Value = Now
        TextBox1.Text = "0"
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        Dim cmd4 As New OleDbCommand
        cmd4.CommandText = "select TDate from Tranjection where MCode = '" & Label5.Text.Replace("M", "") & "' and BCode = '" & Label6.Text.Replace("B", "") & "'"
        cmd4.Connection = Form1.cn

        Dim dt1 As Date = CDate(cmd4.ExecuteScalar)
        Dim dt2 As Date = CDate(Format(DateTimePicker1.Value, "dd-MM-yyyy"))

        Dim DayDiff As Integer = DateDiff(DateInterval.Day, dt1, dt2)

        TextBox1.Text = "0"
        If DayDiff > 7 Then
            TextBox1.Text = (DayDiff - 7) * 10
        End If
        
    End Sub
End Class