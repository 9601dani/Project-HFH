Public Class Form5

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Afiliado' Puede moverla o quitarla según sea necesario.
        Me.AfiliadoTableAdapter.Fill(Me.BasexelaDataSet.Afiliado)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet.Puesto' Puede moverla o quitarla según sea necesario.
        Me.PuestoTableAdapter.Fill(Me.BasexelaDataSet.Puesto)
        Button3.Enabled = False
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

        'REPORTE
        Dim Dataset As New DataSet
        Dim ListarSql As String

        ListarSql = "SELECT em.primernom as Primer_Nombre, em.segundonom as Segundo_Nombre, em.tercernom as Tercer_Nombre, em.primerape as Primer_Apellido, em.segundoape as Segundo_Apellido, em.apellidocas as Apellido_Casada, af.descripcionafiliado as Descripcion_Afiliado, puest.nombrepuesto as Puesto FROM Empleado as em, Afiliado as af, Puesto as puest WHERE em.id_afiliado= af.id_afiliado and em.id_puesto= puest.id_puesto "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaEmpleado")
        adaptador.Fill(Dataset.Tables("tablaEmpleado"))
        DataGridView1.DataSource = Dataset.Tables("tablaEmpleado")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Button2.Enabled = True
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        

        If (ComboBox2.Text = "" Or ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Existen campos requeridos")
        Else
            primernom = TextBox1.Text
            segundonom = TextBox2.Text
            tercernom = TextBox3.Text
            primerape = TextBox4.Text
            segundoape = TextBox5.Text
            apellidocas = TextBox6.Text
            id_puesto = Convert.ToDouble(ComboBox1.SelectedValue())
            id_afiliado = Convert.ToDouble(ComboBox2.SelectedValue())
            comando.Connection = conexion
            comando.CommandText = "INSERT INTO Empleado (primernom, segundonom, tercernom, primerape, segundoape,apellidocas, id_puesto, id_afiliado) values ('" & primernom & "','" & segundonom & "','" & tercernom & "','" & primerape & "','" & segundoape & "','" & apellidocas & "'," & id_puesto & ", " & id_afiliado & ")"


            Try
                comando.ExecuteNonQuery()
                MsgBox("Datos ingresados", vbInformation, "Agregar")
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        Dim Dataset As New DataSet
        Dim ListarSql As String

        ListarSql = "SELECT em.primernom as Primer_Nombre, em.segundonom as Segundo_Nombre, em.tercernom as Tercer_Nombre, em.primerape as Primer_Apellido, em.segundoape as Segundo_Apellido, em.apellidocas as Apellido_Casada, af.descripcionafiliado as Descripcion_Afiliado, puest.nombrepuesto as Puesto FROM Empleado as em, Afiliado as af, Puesto as puest WHERE em.id_afiliado= af.id_afiliado and em.id_puesto= puest.id_puesto "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaEmpleado")
        adaptador.Fill(Dataset.Tables("tablaEmpleado"))
        DataGridView1.DataSource = Dataset.Tables("tablaEmpleado")


    End Sub

    

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

        Dim Dataset As New DataSet
        Dim ListarSql As String
        id_afiliado = Convert.ToDouble(ComboBox3.SelectedValue())
        ListarSql = "SELECT em.primernom as Primer_Nombre, em.segundonom as Segundo_Nombre, em.tercernom as Tercer_Nombre, em.primerape as Primer_Apellido, em.segundoape as Segundo_Apellido, em.apellidocas as Apellido_Casada, af.descripcionafiliado as Descripcion_Afiliado, puest.nombrepuesto as Puesto FROM Empleado as em, Afiliado as af, Puesto as puest WHERE em.id_afiliado= af.id_afiliado and em.id_puesto= puest.id_puesto and af.id_afiliado= " & id_afiliado & ""
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaEmpleado")
        adaptador.Fill(Dataset.Tables("tablaEmpleado"))
        DataGridView1.DataSource = Dataset.Tables("tablaEmpleado")
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Primer_Nombre").Value())
        TextBox2.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Segundo_Nombre").Value())
        TextBox3.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Tercer_Nombre").Value())
        TextBox4.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Primer_Apellido").Value())
        TextBox5.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Segundo_Apellido").Value())
        TextBox6.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Apellido_casada").Value())
        ComboBox1.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Puesto").Value())
        ComboBox2.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Descripcion_Afiliado").Value())
        Button2.Enabled = False
        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        primernom = TextBox1.Text
        segundonom = TextBox2.Text
        tercernom = TextBox3.Text
        primerape = TextBox4.Text
        segundoape = TextBox5.Text
        apellidocas = TextBox6.Text
        id_puesto = Convert.ToDouble(ComboBox1.SelectedValue())
        id_afiliado = Convert.ToDouble(ComboBox2.SelectedValue())
        comando.Connection = conexion
        comando.CommandText = "UPDATE Empleado SET  segundonom= '" & segundonom & "', tercernom= '" & tercernom & "', segundoape= '" & segundoape & "', apellidocas= '" & apellidocas & "', id_puesto= " & id_puesto & ", id_afiliado= " & id_afiliado & " WHERE primernom= '" & primernom & "' and primerape= '" & primerape & "' "
        Try
            comando.ExecuteNonQuery()
            MsgBox("Datos actualizados exitosamente", MsgBoxStyle.Information, "Actualizar")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Dim Dataset As New DataSet
        Dim ListarSql As String

        ListarSql = "SELECT em.primernom as Primer_Nombre, em.segundonom as Segundo_Nombre, em.tercernom as Tercer_Nombre, em.primerape as Primer_Apellido, em.segundoape as Segundo_Apellido, em.apellidocas as Apellido_Casada, af.descripcionafiliado as Descripcion_Afiliado, puest.nombrepuesto as Puesto FROM Empleado as em, Afiliado as af, Puesto as puest WHERE em.id_afiliado= af.id_afiliado and em.id_puesto= puest.id_puesto "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaEmpleado")
        adaptador.Fill(Dataset.Tables("tablaEmpleado"))
        DataGridView1.DataSource = Dataset.Tables("tablaEmpleado")

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Button2.Enabled = True
        Button3.Enabled = False
    End Sub
End Class