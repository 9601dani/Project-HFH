Public Class Form4
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim cadena As String = "SELECT inb.notelefonico as Numero_Telefonico, m.nombremarca + ' ' + mn.nombremodelo as Modelo , es.estado as Estado, inb.id_celulares, m.nombremarca, mn.nombremodelo, inb.imei FROM InventarioCelulares as inb, Marca as m, Estado as es,Modelo as mn where inb.id_marca= m.id_marca and inb.id_modelo= mn.id_modelo and inb.id_estado= es.id_estado and inb.id_estado= 1"
    Dim conn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Basexela.accdb"






    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Motivo' Puede moverla o quitarla según sea necesario.
        Me.MotivoTableAdapter.Fill(Me.BasexelaDataSet.Motivo)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Caso' Puede moverla o quitarla según sea necesario.
        Me.CasoTableAdapter.Fill(Me.BasexelaDataSet.Caso)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Empleado' Puede moverla o quitarla según sea necesario.
        Me.EmpleadoTableAdapter.Fill(Me.BasexelaDataSet.Empleado)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Estado' Puede moverla o quitarla según sea necesario.
        Me.EstadoTableAdapter.Fill(Me.BasexelaDataSet.Estado)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.InventarioCelulares' Puede moverla o quitarla según sea necesario.

        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet1.InventarioCelulares' Puede moverla o quitarla según sea necesario.
        Me.InventarioCelularesTableAdapter.Fill(Me.BasexelaDataSet.InventarioCelulares)

        Button1.Enabled = False
        'REPORTE
        Dim Dataset As New DataSet
        
        Dim ListarSql As String
        ListarSql = "SELECT  hist.fecha as Fecha_Asignacion,hist.id_celulares as Codigo_Celular, em.primernom + ' ' + em.segundonom  + ' ' + em.primerape + ' ' + em.segundoape as  nombres, cas.descripcioncaso as Caso, mot.nombremotivo as Motivo FROM Historial as hist, Empleado as em, Caso as cas, Motivo as mot, Estado as es, InventarioCelulares as inb  Where hist.id_empleado= em.id_empleado and hist.id_caso= cas.id_caso and hist.id_motivo= mot.id_motivo and inb.id_estado = " & "1" & " and inb.id_usuarios=hist.id_usuarios Group by inb.id_estado , hist.fecha,hist.id_celulares, em.primernom  ,em.segundonom, em.primerape , em.segundoape , cas.descripcioncaso , mot.nombremotivo"




        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaHistorial")
        adaptador.Fill(Dataset.Tables("tablaHistorial"))
        DataGridView1.DataSource = Dataset.Tables("tablaHistorial")

        Try
            da = New OleDb.OleDbDataAdapter(cadena, conn)
            da.Fill(ds)
            With ComboBox1
                .DataSource = ds.Tables(0)
                .DisplayMember = "Modelo"
                .ValueMember = "id_celulares"


            End With
        Catch ex As Exception

        End Try

       


        comando.Connection = conexion
        Dim ListarSql3 As String
        ListarSql3 = "SELECT id_empleado, primernom + ' ' + primerape as nombre from Empleado  "
        Dim ds3
        Dim adaptador3 As New OleDb.OleDbDataAdapter(ListarSql3, conexion)
        Try
            '  datareader = comando.ExecuteReader()
            ds3 = New DataSet()
            adaptador3.Fill(ds3)
            ComboBox3.DataSource = ds3.Tables(0)
            ComboBox3.DisplayMember = "nombre"
            ComboBox3.ValueMember = "id_empleado"
            '  datareader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        TextBox4.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox6.Enabled = False
        ComboBox7.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim indx As String = ComboBox1.SelectedIndex.ToString()
        TextBox3.Text = ds.Tables(0).Rows(indx)(0).ToString
        ComboBox6.Text = ds.Tables(0).Rows(indx)(4).ToString
        ComboBox7.Text = ds.Tables(0).Rows(indx)(5).ToString
        ComboBox2.Text = ds.Tables(0).Rows(indx)(2).ToString
        TextBox4.Text = ds.Tables(0).Rows(indx)(6).ToString

    End Sub
    Dim id_estados, id_marcas, id_modelos, notelefonicos As Double
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Falta llenar campos requeridos")
            Else
            id_usuarios = id_usuario2
            id_celulares = Convert.ToDouble(ComboBox1.SelectedValue())
            fecha = DateTimePicker1.Text
            id_empleado = Convert.ToDouble(ComboBox3.SelectedValue())
            id_caso = Convert.ToDouble(ComboBox4.SelectedValue())
            id_motivo = Convert.ToDouble(ComboBox5.SelectedValue())
            notelefonico = (TextBox3.Text)
            'ACTUALIZAR
            id_estado = Convert.ToDouble(ComboBox2.SelectedValue().ToString)

            If ComboBox4.SelectedValue = "1" Then
                numrepo = numrepo + 1
            Else

            End If
            'Actualizar
            comando.Connection = conexion
            comando.CommandText = "UPDATE InventarioCelulares set numrepo= " & numrepo & ", id_estado = " & id_estado & ", notelefonico= '" & notelefonico & "' where id_celulares = " & id_celulares & ""
            Try
                comando.ExecuteNonQuery()


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            'Guardar

            comando.CommandText = "INSERT INTO Historial (id_usuarios,id_celulares, fecha, id_empleado, id_caso, id_motivo) values (" & id_usuarios & ", " & id_celulares & ",'" & fecha & "'," & id_empleado & "," & id_caso & "," & id_motivo & ") "


            Try
                comando.ExecuteNonQuery()
                MsgBox("Datos ingresados", vbInformation, "Agregar")
                TextBox3.Clear()
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        'REPORTE
        Dim Dataset As New DataSet

        Dim ListarSql As String
        ListarSql = "SELECT  hist.fecha as Fecha_Asignacion,hist.id_celulares as Codigo_Celular, em.primernom + ' ' + em.segundonom  + ' ' + em.primerape + ' ' + em.segundoape as nombres, cas.descripcioncaso as Caso, mot.nombremotivo as Motivo FROM Historial as hist, Empleado as em, Caso as cas, Motivo as mot, Estado as es, InventarioCelulares as inb  Where hist.id_empleado= em.id_empleado and hist.id_caso= cas.id_caso and hist.id_motivo= mot.id_motivo and inb.id_estado = " & "1" & " and inb.id_usuarios=hist.id_usuarios Group by inb.id_estado , hist.fecha,hist.id_celulares, em.primernom  ,em.segundonom, em.primerape , em.segundoape , cas.descripcioncaso , mot.nombremotivo"

        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaHistorial")
        adaptador.Fill(Dataset.Tables("tablaHistorial"))
        DataGridView1.DataSource = Dataset.Tables("tablaHistorial")

       
    End Sub

    
    
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
       
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.EmpleadoTableAdapter.Fill(Me.BasexelaDataSet.Empleado)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button2.Enabled = False
        Button1.Enabled = True
        ComboBox3.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("nombres").Value())
        ComboBox4.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Caso").Value())
        ComboBox5.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Motivo").Value())
        
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        id_empleado = Convert.ToDouble(ComboBox3.SelectedValue())
        id_caso = Convert.ToDouble(ComboBox4.SelectedValue())
        id_motivo = Convert.ToDouble(ComboBox5.SelectedValue())
        comando.Connection = conexion
        comando.CommandText = "UPDATE Historial SET id_caso = " & id_caso & ", id_motivo = " & id_motivo & "  WHERE id_empleado = " & id_empleado & ""
        Try
            comando.ExecuteNonQuery()
            MsgBox("Datos actualizados exitosamente", MsgBoxStyle.Information, "Actualizar")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class