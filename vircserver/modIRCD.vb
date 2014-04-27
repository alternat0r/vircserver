Module modIRCD

    Public nickname(0 To 250) As String
    Public Channels(0 To 250, 0 To 10) As String
    Public Connected(0 To 250) As Boolean

    Public ServerName As String
    Public ServerDay As String
    Public ServerTime As String
    Public intMax As Integer

    Public SendMOTD(0 To 50) As String

    Sub OP(channel As String, nickname As String, index As Integer)
        frmMain.tcpServer.Send(":" & "ADMIN!general@services.friends.nuclearbomb.com MODE " & channel & "+o " & nickname & vbCrLf)
    End Sub

    Sub MODE(target As String, modes As String, index As Integer)
        If LCase(target) = LCase(nickname(index)) Then
            frmMain.tcpServer.Send(":" & UCase(target) & Chr(32) & "MODE" & Chr(32) & UCase(target) & " :" & modes & vbCrLf)
        End If
    End Sub

    Sub MOTD(nickname As String, index As Integer)
        frmMain.tcpServer.Send(":" & ServerName & " 375 " & nickname & " :- " & ServerName & " Message of the Day -" & vbCrLf)
        Dim i As Integer
        For i = 1 To 50
            frmMain.tcpServer.Send(":" & ServerName & " 372 " & nickname & " :-" & SendMOTD(i) & vbCrLf)
        Next i
        frmMain.tcpServer.Send(":" & ServerName & " 376 " & nickname & " :End of Message of the Day" & vbCrLf)
    End Sub
End Module
