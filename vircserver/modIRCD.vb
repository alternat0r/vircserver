Module modIRCD

    Public nickname(0 To 250) As String
    Public Channels(0 To 250, 0 To 10) As String
    Public Connected(0 To 250) As Boolean

    Public ServerName As String
    Public ServerDay As String
    Public ServerTime As String
    Public intMax As Integer

    Sub OP(channel As String, nickname As String, index As Integer)
        frmMain.tcpServer.Send(":" & "ADMIN!general@services.friends.nuclearbomb.com MODE " & channel & "+o " & nickname & vbCrLf)
    End Sub

    Sub MODE(target As String, modes As String, index As Integer)
        If LCase(target) = LCase(nickname(index)) Then
            frmMain.tcpServer.Send(":" & UCase(target) & Chr(32) & "MODE" & Chr(32) & UCase(target) & " :" & modes & vbCrLf)
        End If
    End Sub
End Module
