Imports System.Data.OleDb
Public Class Form8

    Dim da As New OleDbDataAdapter("select * from Books", Form1.cn)

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        da.Fill(DataSet1, "Books")

        Dim x As New CrystalReport2
        x.SetDataSource(DataSet1.Tables(0))
        CrystalReportViewer1.ReportSource = x

    End Sub
End Class