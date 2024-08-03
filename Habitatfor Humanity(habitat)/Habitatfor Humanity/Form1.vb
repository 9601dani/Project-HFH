Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Ingrese Campos requeridos", MsgBoxStyle.Information)
        Else



            usuario = TextBox1.Text
            contraseña = TextBox2.Text
            comando.Connection = conexion
            comando.CommandText = "SELECT * FROM Usuarios WHERE usuario= '" & usuario & "' and contraseña  = '" & contraseña & "'"

            Try
                comando.CommandText = ("SELECT id_usuarios from Usuarios where  usuario= '" & usuario & "' and contraseña  = '" & contraseña & "' ")


                datareader = comando.ExecuteReader()
                If datareader.HasRows Then
                    While datareader.Read
                        id_usuario2 = datareader.Item(0)

                    End While
                    MsgBox("Bienvenido a Habitat para la Humanidad", MsgBoxStyle.Information)
                    Form2.Show()
                    Me.Hide()


                    TextBox1.Clear()
                    TextBox2.Clear()


                Else
                    MsgBox("Revise su usuario y contraseña", MsgBoxStyle.Critical, "Consultar")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Select()
                End If
                datareader.Close()
            Catch ex As Exception

                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarse()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub BunifuImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
    End Sub
End Class
