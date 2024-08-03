Public Class Form6

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Existen Campos Requeridos")
        Else



            usuario = TextBox1.Text
            contraseña = TextBox2.Text
            nombre = TextBox3.Text

            comando.Connection = conexion
            comando.CommandText = "INSERT INTO Usuarios ( usuario, contraseña, nombre) values ('" & usuario & "', '" & contraseña & "', '" & nombre & "')"
            Try
                comando.ExecuteNonQuery()
                MsgBox("Usuario Ingresado Exitosamente", vbInformation, "Agregar")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'Reporte
            Dim Dataset As New DataSet
            Dim ListarSql As String
            ListarSql = "SELECT usuario,nombre FROM Usuarios "
            Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
            Dataset.Tables.Add("tablaUsuarios")
            adaptador.Fill(Dataset.Tables("tablaUsuarios"))
            DataGridView1.DataSource = Dataset.Tables("tablaUsuarios")
        End If
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        nombre = InputBox("Ingrese nombre a buscar", "Busqueda")
        comando.Connection = conexion
        comando.CommandText = "SELECT * FROM Usuarios WHERE nombre  = '" & nombre & "'"

        Try
            datareader = comando.ExecuteReader()
            If datareader.HasRows Then
                While datareader.Read
                    TextBox1.Text = datareader.Item(1)
                    TextBox2.Text = datareader.Item(2)
                    TextBox3.Text = datareader.Item(3)

                End While
            Else
                MsgBox("No existe nombre en la base de datos", MsgBoxStyle.Critical, "Consultar")
                TextBox1.Clear()
                TextBox1.Select()
            End If
            datareader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Campos Requeridos Vacios", MsgBoxStyle.Information, "PROBLEMA")
        Else

            usuario = TextBox1.Text
            contraseña = TextBox2.Text
            nombre = TextBox3.Text

            comando.Connection = conexion
            comando.CommandText = "UPDATE Usuarios SET usuario = '" & usuario & "',contraseña = '" & contraseña & "' WHERE nombre = '" & nombre & "'"
            Try
                comando.ExecuteNonQuery()
                MsgBox("Datos actualizados exitosamente", MsgBoxStyle.Information, "Actualizar")

            Catch ex As Exception
                MsgBox("Aun existen campos requeridos")
            End Try
        End If

        'Reporte
        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT usuario,nombre FROM Usuarios "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaUsuarios")
        adaptador.Fill(Dataset.Tables("tablaUsuarios"))
        DataGridView1.DataSource = Dataset.Tables("tablaUsuarios")

        Button4.Enabled = False
        Button2.Enabled = True
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If MsgBox("Está seguro de eliminar este dato?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cuidado") = MsgBoxResult.Yes Then
            nombre = TextBox3.Text
            comando.Connection = conexion
            comando.CommandText = "DELETE FROM Usuarios WHERE nombre = '" & nombre & "'"
            Try
                comando.ExecuteNonQuery()
                MsgBox("Datos eliminados exitosamente", MsgBoxStyle.Critical, "Eliminar")

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()


            TextBox1.Select()
        Else
            MsgBox("El dato no fue eliminado", MsgBoxStyle.Information, "Eliminar")

        End If
        'Reporte
        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT usuario,nombre FROM Usuarios "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaUsuarios")
        adaptador.Fill(Dataset.Tables("tablaUsuarios"))
        DataGridView1.DataSource = Dataset.Tables("tablaUsuarios")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Dataset As New DataSet
        Dim ListarSql As String
        ListarSql = "SELECT usuario,nombre FROM Usuarios "
        Dim adaptador As New OleDb.OleDbDataAdapter(ListarSql, conexion)
        Dataset.Tables.Add("tablaUsuarios")
        adaptador.Fill(Dataset.Tables("tablaUsuarios"))
        DataGridView1.DataSource = Dataset.Tables("tablaUsuarios")

        Button4.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Usuario").Value())
        TextBox3.Text = Convert.ToString(DataGridView1.CurrentRow.Cells("Nombre").Value())
        Button4.Enabled = True
        Button2.Enabled = False
    End Sub
End Class