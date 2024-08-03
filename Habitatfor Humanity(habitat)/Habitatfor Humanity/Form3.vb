Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Modelo' Puede moverla o quitarla según sea necesario.
        Me.ModeloTableAdapter.Fill(Me.BasexelaDataSet2.Modelo)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Marca' Puede moverla o quitarla según sea necesario.
        Me.MarcaTableAdapter.Fill(Me.BasexelaDataSet2.Marca)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Estado' Puede moverla o quitarla según sea necesario.
        Me.EstadoTableAdapter.Fill(Me.BasexelaDataSet2.Estado)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Modelo' Puede moverla o quitarla según sea necesario.
        Me.ModeloTableAdapter.Fill(Me.BasexelaDataSet2.Modelo)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Marca' Puede moverla o quitarla según sea necesario.
        Me.MarcaTableAdapter.Fill(Me.BasexelaDataSet2.Marca)
        'TODO: esta línea de código carga datos en la tabla 'BasexelaDataSet2.Estado' Puede moverla o quitarla según sea necesario.
        Me.EstadoTableAdapter.Fill(Me.BasexelaDataSet2.Estado)
        
       
        Button3.Enabled = False


        ' Limpieza de Combobox

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox4.Clear()

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""

        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT inb.fechasignacion as Fecha_Registro , inb.minutos as Minutos, inb.numrepo as Numero_Reposiciones, inb.notelefonico as Numero_Telefonico, m.nombremarca as Marca, mn.nombremodelo as Modelo , es.estado as Estado, inb.imei as Imei FROM InventarioCelulares as inb, Marca as m, Estado as es,Modelo as mn where inb.id_marca= m.id_marca and inb.id_modelo= mn.id_modelo and inb.id_estado= es.id_estado"
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaInventarioCelulares")
        adaptador.Fill(Dataset.Tables("tablaInventarioCelulares"))
        DataGridView1.DataSource = Dataset.Tables("tablaInventarioCelulares")

    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        imei = TextBox5.Text

        id_usuarios = id_usuario2
        fechasignacion = DateTimePicker1.Text
        minutos = TextBox1.Text
        numrepo = TextBox2.Text

        If (ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or TextBox5.Text = "") Then
            MsgBox("Existen campos requeridos")
        Else
            id_estado = Convert.ToDouble(ComboBox2.SelectedValue())
            notelefonico = TextBox3.Text
            id_marca = Convert.ToDouble(ComboBox3.SelectedValue())
            id_modelo = Convert.ToDouble(ComboBox4.SelectedValue())

            comando.Connection = conexion
            comando.CommandText = "INSERT INTO InventarioCelulares ( fechasignacion, minutos, numrepo, id_estado, notelefonico, id_modelo, id_marca,id_usuarios, imei) values ('" & fechasignacion & "','" & minutos & "','" & numrepo & "'," & id_estado & ",'" & notelefonico & "'," & id_modelo & "," & id_marca & "," & id_usuarios & ", '" & imei & "')"


            Try
                comando.ExecuteNonQuery()
                MsgBox("Datos ingresados", vbInformation, "Agregar")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT inb.fechasignacion as Fecha_Registro , inb.minutos as Minutos, inb.numrepo as Numero_Reposiciones, inb.notelefonico as Numero_Telefonico, m.nombremarca as Marca, mn.nombremodelo as Modelo , es.estado as Estado, inb.imei as Imei FROM InventarioCelulares as inb, Marca as m, Estado as es,Modelo as mn where inb.id_marca= m.id_marca and inb.id_modelo= mn.id_modelo and inb.id_estado= es.id_estado"
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaInventarioCelulares")
        adaptador.Fill(Dataset.Tables("tablaInventarioCelulares"))
        DataGridView1.DataSource = Dataset.Tables("tablaInventarioCelulares")

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox4.Clear()

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox4.Clear()

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""

    End Sub

    

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
       
        imei = TextBox4.Text
        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT inb.fechasignacion as Fecha_Registro , inb.minutos as Minutos, inb.numrepo as Numero_Reposiciones, inb.notelefonico as Numero_Telefonico, m.nombremarca as Marca, mn.nombremodelo as Modelo , es.estado as Estado, inb.imei as Imei FROM InventarioCelulares as inb, Marca as m, Estado as es,Modelo as mn where inb.id_marca= m.id_marca and inb.id_modelo= mn.id_modelo and inb.id_estado= es.id_estado and imei like '%" & imei & "%'"
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaInventarioCelulares")
        adaptador.Fill(Dataset.Tables("tablaInventarioCelulares"))
        DataGridView1.DataSource = Dataset.Tables("tablaInventarioCelulares")

     

    End Sub

   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button3.Enabled = True
        ComboBox3.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Marca").Value())
        TextBox1.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Minutos").Value())
        TextBox2.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Numero_Reposiciones").Value())
        ComboBox2.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Estado").Value())
        TextBox3.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Numero_Telefonico").Value())
        ComboBox4.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Modelo").Value())
        DateTimePicker1.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Fecha_Registro").Value())
        TextBox5.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Imei").Value())
        Button2.Enabled = False
    End Sub

    

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        id_usuarios = id_usuario2
        fechasignacion = DateTimePicker1.Text
        minutos = TextBox1.Text
        numrepo = TextBox2.Text
        id_estado = Convert.ToDouble(ComboBox2.SelectedValue())
        notelefonico = TextBox3.Text
        id_marca = Convert.ToDouble(ComboBox3.SelectedValue())
        id_modelo = Convert.ToDouble(ComboBox4.SelectedValue())
        imei = TextBox5.Text

        comando.Connection = conexion
        comando.CommandText = "UPDATE InventarioCelulares SET id_usuarios = " & id_usuarios & ",fechasignacion= '" & fechasignacion & "', minutos= '" & minutos & "', numrepo= '" & numrepo & "', notelefonico= '" & notelefonico & "', id_estado= " & id_estado & ", id_marca= " & id_marca & ", id_modelo= " & id_modelo & "  WHERE imei= '" & imei & "'"
        Try
            comando.ExecuteNonQuery()
            MsgBox("Datos actualizados exitosamente", MsgBoxStyle.Information, "Actualizar")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT inb.fechasignacion as Fecha_Registro , inb.minutos as Minutos, inb.numrepo as Numero_Reposiciones, inb.notelefonico as Numero_Telefonico, m.nombremarca as Marca, mn.nombremodelo as Modelo , es.estado as Estado, inb.imei as Imei FROM InventarioCelulares as inb, Marca as m, Estado as es,Modelo as mn where inb.id_marca= m.id_marca and inb.id_modelo= mn.id_modelo and inb.id_estado= es.id_estado"
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaInventarioCelulares")
        adaptador.Fill(Dataset.Tables("tablaInventarioCelulares"))
        DataGridView1.DataSource = Dataset.Tables("tablaInventarioCelulares")

        Button2.Enabled = True
        Button3.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox4.Clear()

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
    End Sub

   
End Class