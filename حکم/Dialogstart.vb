Imports System.Windows.Forms

Public Class Dialogstart

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Timerstart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerstart.Tick
        Timerstart.Stop()
        Me.Close()

    End Sub

    Private Sub Dialogstart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timerstart.Start()
        Me.Width = BackgroundImage.Width
        Me.Height = BackgroundImage.Height
    End Sub
End Class
