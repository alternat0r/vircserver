
Imports System.Net.Sockets

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intMax = 0
        ServerDay = Today.TimeOfDay.Ticks
        ServerTime = TimeOfDay
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        frmOptions.ShowDialog()
        Application.DoEvents()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub tcpServer_ConnectionRequest(sender As Object, e As Winsock_Orcas.WinsockConnectionRequestEventArgs) Handles tcpServer.ConnectionRequest
        If sender = 0 Then
            Dim i As Integer
            For i = 1 To 250
                If nickname(i) = "" Then
                    intMax = i
                    Exit For
                End If
            Next
            'Load(tcpServer(intMax))
            tcpServer.LocalPort = 0
            tcpServer.Accept(e.Client)

            lstData.Items.Add(Date.Today & ": " & intMax & " user request " & tcpServer.RemoteHost)

            tcpServer.Send(":" & ServerName & " NOTICE AUTH :*** Creating your hostname..." & vbCrLf)
            tcpServer.Send(":" & ServerName & " NOTICE AUTH :*** Creating your identd..." & vbCrLf)
            tcpServer.Send(":" & ServerName & " NOTICE AUTH :*** Creating your hostname..." & vbCrLf)
            tcpServer.Send(":" & ServerName & " NOTICE +AUTH :*** Creating your identd..." & vbCrLf)
        End If
    End Sub

    Private Sub tcpServer_Disconnected(sender As Object, e As EventArgs) Handles tcpServer.Disconnected
        nickname(sender) = ""
        tcpServer.Close()

        Dim i As Integer

        For i = 1 To 10
            Channels(sender, i) = ""
        Next

        Connected(sender) = False

    End Sub

    Private Sub tcpServer_ErrorReceived(sender As Object, e As Winsock_Orcas.WinsockErrorReceivedEventArgs) Handles tcpServer.ErrorReceived

    End Sub


End Class
