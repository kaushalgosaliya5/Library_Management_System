Imports System.Data.OleDb
Public Class Form7

    Dim da As New OleDbDataAdapter("select * from Member", Form1.cn)

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        da.Fill(DataSet1, "Member")

        Dim x As New CrystalReport1
        x.SetDataSource(DataSet1.Tables(0))
        CrystalReportViewer1.ReportSource = x

    End Sub
End Class