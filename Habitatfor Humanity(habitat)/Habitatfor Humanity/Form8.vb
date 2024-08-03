Public Class Form8

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'basexelaDataSet1.ConAsignacion' Puede moverla o quitarla según sea necesario.
        Me.ConAsignacionTableAdapter.Fill(Me.basexelaDataSet1.ConAsignacion)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class