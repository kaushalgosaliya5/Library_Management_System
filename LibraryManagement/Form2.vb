Public Class Form2

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim m As MsgBoxResult = MsgBox("YOU ARE SURE CLOSING FORM", MsgBoxStyle.YesNo, "CONFIRMATION")

        If m = MsgBoxResult.No Then
            e.Cancel = True
        Else
            Application.Exit()
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterToolStripMenuItem.Click

    End Sub

    Private Sub NotepadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotepadeToolStripMenuItem.Click
        Shell("notepad.exe")
    End Sub

    Private Sub CalculaterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculaterToolStripMenuItem.Click

        Dim frm As New Form3
        frm.MdiParent = Me
        frm.Show()

    End Sub

  
    Private Sub EXITToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem1.Click
        Dim m As MsgBoxResult = MsgBox("YOU ARE SURE EXIT THIS APPLICATION", MsgBoxStyle.YesNo)

        If m = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ChengPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChengPasswordToolStripMenuItem.Click
        Dim frm As New Form4
        frm.Show()
    End Sub

    Private Sub MemberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberToolStripMenuItem.Click
        Dim frm As New Form5
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookToolStripMenuItem.Click
        Dim frm As New Form6
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub MemberReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberReportToolStripMenuItem.Click

        Dim frm As New Form7
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub BooksReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BooksReportToolStripMenuItem.Click
        Dim frm As New Form8
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub IssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueToolStripMenuItem.Click
        Dim frm As New Form10
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnToolStripMenuItem.Click
        Dim frm As New Form11
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub IssueReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueReportToolStripMenuItem.Click
        Dim frm As New Form9
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FindReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindReportToolStripMenuItem.Click
        Dim frm As New Form12
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class