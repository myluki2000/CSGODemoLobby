Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary

Module GlobalVariables
    Public WithEvents UTClient As New UniversalTicket.UTicketClient("127.0.0.1", 78, "3290fja39j%§(§&_SERVER-PASSWORD_§=JDf9", MainForm)
    Public WaitingForInvite As Boolean = False
    Public LobbyLeader As String
    Public DemoLocation As String

    Public Sub Sleep(time As Integer)
        While time > 0
            Threading.Thread.Sleep(10)
            time -= 10
            Application.DoEvents()
        End While
    End Sub

    ' Convert an object to a byte array
    Public Function ObjectToByteArray(obj As [Object]) As Byte()
        Dim bf As New BinaryFormatter()
        Using ms = New MemoryStream()
            bf.Serialize(ms, obj)
            Return ms.ToArray()
        End Using
    End Function

    Public Sub ShowMsg(text As String)
        MetroMsgBox.label = text
        MetroMsgBox.ShowDialog()
    End Sub

    Public Sub UTClient_TicketArrived(sSenderID As String, bSentToAll As Boolean, sCommand As String, oUserData As List(Of Object)) Handles UTClient.UTicketArrived
        Select Case sCommand
            Case "JoinLobby"
                If WaitingForInvite Then
                    Console.Beep()
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
                MainForm.rtbChat.Text &= sSenderID & " did not accept your invitation." & vbNewLine

                For Each item As ListViewItem In MainForm.lvPlayers.Items
                    If item.Text = sSenderID Then
                        MainForm.lvPlayers.Items.Remove(item)
                    End If
                Next

            Case "JoinLobbyAccept"
                MainForm.rtbChat.Text &= sSenderID & " has accepted your invitation." & vbNewLine

                Dim demoArray() As Byte

                demoArray = File.ReadAllBytes(DemoLocation)

                UTClient.sendUTicket(sSenderID, "DemoTransmission", demoArray)

            Case "DemoTransmission"
                MainForm.lblDemoDownload.Text = "The demo has been downlaoded."
                File.WriteAllBytes(My.Settings.csgoDirectory & "\csgo\replays\csgodemolobby.dem", ObjectToByteArray(oUserData(0)))

            Case "SpecInfo"
                SendKeys.Send("spec_goto " & oUserData(0))
                SendKeys.Send("{ENTER}")
                MsgBox("kden")
        End Select
    End Sub

    <DllImport("user32.dll")>
    Public Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    Public Const KeyDown As Integer = &H8000
End Module
