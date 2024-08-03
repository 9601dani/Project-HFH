Module Module1
    
    Public conexion As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Basexela.accdb")
    Public comando As New OleDb.OleDbCommand
    Public datareader As OleDb.OleDbDataReader
    Public datareader1 As OleDb.OleDbDataReader
    Public id_usuario2 As String


    'Historial
    Public fecha As Date
    'Modelo
    Public id_modelo As Double

    'Estado
    Public id_estado As Double

    'Usuarios
    Public usuario, contraseña, nombre As String
    Public id_usuarios As Double
    'Marca
    Public id_marca As Double

    'InventarioCelulares
    Public afiliado, minutos, estado, notelefonico As String
    Public id_celulares As Double
    Public fechasignacion As Date
    Public numrepo As String
    Public imei As String
    'Historial
    Public id_solicitud, id_motivo, id_empleado, id_caso As Double

    'Empleado
    Public primernom, segundonom, tercernom, primerape, segundoape, apellidocas As String
    Public id_puesto As String
    Public id_afiliado As Double





    Public Sub conectarse()
        Try
            conexion.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module
