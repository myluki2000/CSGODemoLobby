Module GlobalVariables
    Public WithEvents UTClient As New UniversalTicket.UTicketClient("127.0.0.1", 78, "3290fja39j%§(§&_SERVER-PASSWORD_§=JDf9", MainForm)
    Public WaitingForInvite As Boolean = False
    Public LobbyLeader As String

    Public Sub Sleep(time As Integer)
        While time > 0
            Threading.Thread.Sleep(10)
            time -= 10
            Application.DoEvents()
        End While
    End Sub

    Public Sub UTClient_TicketArrived(sSenderID As String, bSentToAll As Boolean, sCommand As String, oUserData As List(Of Object)) Handles UTClient.UTicketArrived
        Select Case sCommand
            Case "JoinLobby"
                If WaitingForInvite Then
                    WaitingForInvite = False
                    LobbyLeader = sSenderID
                    MainForm.lblInvitedBy.Text = sSenderID & " has invited you to their lobby."
                    MainForm.btnLobbyInviteJoin.Enabled = True
                    MainForm.btnLobbyInviteJoin.Visible = True

                    MainForm.btnLobbyInviteCancel.Enabled = True
                    MainForm.btnLobbyInviteCancel.Visible = True

                    MainForm.WaitingCircleInvite.Visible = False
                End If

            Case "JoinLobbyCancel"
                MainForm.rtbChat.Text &= vbNewLine & sSenderID & " has denied your invitation."

                For Each item As ListViewItem In MainForm.lvPlayers.Items
                    If item.Text = sSenderID Then
                        MainForm.lvPlayers.Items.Remove(item)
                    End If
                Next

            Case "JoinLobbyAccept"
        End Select
    End Sub
End Module
