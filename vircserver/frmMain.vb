Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Intmax = 0
        ServerDay = Today.TimeOfDay.Ticks
        ServerTime = TimeOfDay
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        frmOptions.ShowDialog()
        Application.DoEvents()
    End Sub
End Class
