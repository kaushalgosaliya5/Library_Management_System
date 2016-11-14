Imports System.Data.OleDb
Public Class Form9

    Dim da As New OleDbDataAdapter("select * from Query1", Form1.cn)

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        da.Fill(DataSet1, "Query1")

        Dim x As New CrystalReport3
        x.SetDataSource(DataSet1.Tables(0))
        CrystalReportViewer1.ReportSource = x

    End Sub
End Class