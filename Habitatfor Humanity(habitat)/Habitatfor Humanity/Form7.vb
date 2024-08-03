Public Class Form7

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'basexelaDataSet1.ConCelulares' Puede moverla o quitarla según sea necesario.
        Me.ConCelularesTableAdapter.Fill(Me.basexelaDataSet1.ConCelulares)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class