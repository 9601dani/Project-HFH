Public Class Form2
    Private Sub INGRESODECELULARESToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESODECELULARESToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub INGRESODEASIGNACIONESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESODEASIGNACIONESToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub INGRESODEEMPLEADOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESODEEMPLEADOSToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub INGRESODEUSUARIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESODEUSUARIOSToolStripMenuItem.Click
        If id_usuario2 = "1" Then
            MsgBox("BIENVENIDO", MsgBoxStyle.Information)
            Form6.Show()
        Else
            MsgBox(" NO TIENE PERMISOS PARA ESTA OPCION", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub INFORMEDECELULARESToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INFORMEDECELULARESToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub INFORMEDEASIGNACIONESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INFORMEDEASIGNACIONESToolStripMenuItem.Click
        Form8.Show()
    End Sub

    Private Sub INFORMEDEEMPLEADOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INFORMEDEEMPLEADOSToolStripMenuItem.Click
        Form9.Show()
    End Sub

    Private Sub INFORMEDEUSUARIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INFORMEDEUSUARIOSToolStripMenuItem.Click
        Form10.Show()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub JhghgToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JhghgToolStripMenuItem.Click
        Form10.Close()
        Form9.Close()
        Form8.Close()
        Form7.Close()
        Form6.Close()
        Form5.Close()
        Form4.Close()
        Form3.Close()
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub CREDENCIALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDENCIALESToolStripMenuItem.Click
        Form11.Show()
    End Sub
End Class