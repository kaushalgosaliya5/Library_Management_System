Imports System.Data.OleDb
Public Class Form5

    Dim pos As Integer
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter("select * from Member", Form1.cn)
    Dim cmdbldr1 As New OleDbCommandBuilder(da)
    Dim admode As Boolean

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        da.Fill(ds, "Member")
        ShowDetail()

        Dim dr As OleDbDataReader
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select distinct(MCity) from Member"
        cmd.Connection = Form1.cn
        dr = cmd.ExecuteReader

        While dr.Read()
            ComboBox1.Items.Add(dr.Item(0))
        End While

    End Sub
    Sub ShowDetail()
        TextBox1.Text = "M" & ds.Tables(0).Rows(pos).Item(0)
        TextBox2.Text = ds.Tables(0).Rows(pos).Item(1)
        TextBox3.Text = ds.Tables(0).Rows(pos).Item(2)
        ComboBox1.Text = ds.Tables(0).Rows(pos).Item(3)
        TextBox4.Text = ds.Tables(0).Rows(pos).Item(4)
        DateTimePicker1.Value = ds.Tables(0).Rows(pos).Item(5)
        TextBox5.Text = ds.Tables(0).Rows(pos).Item(6)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim dt As Date = Now
        Label2.Text = dt.ToString("D")
        Label3.Text = dt.ToString("t")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pos = 0
        ShowDetail()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pos = ds.Tables(0).Rows.Count - 1

        ShowDetail()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If pos > 0 Then
            pos -= 1
            ShowDetail()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If pos < ds.Tables(0).Rows.Count - 1 Then
            pos += 1
            ShowDetail()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        admode = True

        Dim cmd As New OleDbCommand
        cmd.CommandText = "select max(MCode) from Member"
        cmd.Connection = Form1.cn
        Dim mcode As Integer = cmd.ExecuteScalar + 1

        If mcode < 10 Then
            TextBox1.Text = "M000" & mcode
        ElseIf mcode < 100 Then
            TextBox1.Text = "M00" & mcode
        ElseIf mcode < 1000 Then
            TextBox1.Text = "M0" & mcode
        Else
            TextBox1.Text = "" & mcode
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        If TextBox2.Text = "" Then MsgBox("NAME IS NOT ENTER ") : TextBox2.Focus() : Exit Sub
        If TextBox3.Text = "" Then MsgBox("ADDRESS IS NOT ENTER ") : TextBox3.Focus() : Exit Sub
        If TextBox4.Text = "" Then MsgBox("EMAIL ID IS NOT ENTER ") : TextBox4.Focus() : Exit Sub
        If TextBox5.Text = "" Then MsgBox("AMOUNT IS NOT ENTER ") : TextBox5.Focus() : Exit Sub

        If admode = True Then
            Dim dtrow As DataRow = ds.Tables(0).NewRow
            dtrow.Item(0) = TextBox1.Text.Replace("M", "")
            dtrow.Item(1) = TextBox2.Text
            dtrow.Item(2) = TextBox3.Text
            dtrow.Item(3) = ComboBox1.Text
            dtrow.Item(4) = TextBox4.Text
            dtrow.Item(5) = DateTimePicker1.Value
            dtrow.Item(6) = Val(TextBox5.Text)
            ds.Tables(0).Rows.Add(dtrow)
            da.Update(ds, "Member")
            admode = False
        Else
            Dim dtrow As DataRow = ds.Tables(0).Rows(pos)

            dtrow.Item(1) = TextBox2.Text
            dtrow.Item(2) = TextBox3.Text
            dtrow.Item(3) = ComboBox1.Text
            dtrow.Item(4) = TextBox4.Text
            dtrow.Item(5) = DateTimePicker1.Value
            dtrow.Item(6) = Val(TextBox5.Text)
            da.Update(ds, "Member")
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim m As MsgBoxResult = MsgBox("YOU ARE SURE DELETE THIS MEMEBER ", MsgBoxStyle.YesNo, "CONFIRM")

        If m = MsgBoxResult.Yes Then
            ds.Tables(0).Rows(pos).Delete()
            da.Update(ds, "Member")
            pos = 0
            ShowDetail()
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class