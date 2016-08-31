

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary

Module GlobalVariables
    Public WithEvents UTClient As New UniversalTicket.UTicketClient("127.0.0.1", 78, "3290fja39j%§(§&_SERVER-PASSWORD_§=JDf9", MainForm)
    Public WaitingForInvite As Boolean = False
    Public LobbyLeader As String
    Public DemoLocation As String
    Public specPos As String

    Private Sub UTClient_NoConnection() Handles UTClient.ConnectionNotPossible
        MainForm.MainPanel.Visible = True
        MainForm.MainPanel.Enabled = True

        MainForm.LobbyPanel.Visible = False
        MainForm.LobbyPanel.Enabled = False


        MainForm.lblDemoDownload.Visible = True

        MainForm.tbPlayerInvite.Visible = False
        MainForm.tbPlayerInvite.Enabled = False
        MainForm.btnPlayerInvite.Visible = False
        MainForm.btnPlayerInvite.Enabled = False
        MainForm.btnSelectDemo.Visible = False
        MainForm.btnSelectDemo.Enabled = False

        MetroMsgBox.label = "A connection with the main server could not be established!"
        MetroMsgBox.ShowDialog()
    End Sub

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
                    MainForm.lvPlayers.Items.Clear()
                    For Each i In oUserData
                        MainForm.lvPlayers.Items.Add(i)
                    Next


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

                demoArray = Nothing

                For Each lvItem As ListViewItem In MainForm.lvPlayers.Items
                    If lvItem.Text = sSenderID Then
                        lvItem.ImageIndex = 2
                    End If
                Next

                Sleep(10)
                sendPlayers()

            Case "DemoTransmission"
                MainForm.lblDemoDownload.Text = "Downloading Demo"
                File.WriteAllBytes(My.Settings.csgoDirectory & "\csgo\replays\csgodemolobby.dem", ObjectToByteArray(oUserData(0)))
                oUserData = Nothing
                MainForm.lblDemoDownload.Text = "The demo has been downloaded"
                UTClient.sendUTicket(LobbyLeader, "DemoTransComplete")

            Case "DemoTransComplete"
                For Each lvItem As ListViewItem In MainForm.lvPlayers.Items
                    If lvItem.Text = sSenderID Then
                        lvItem.ImageIndex = 1
                    End If
                Next

                sendPlayers()

            Case "ChatMsg"
                MainForm.rtbChat.Text &= oUserData(0)

            Case "LobbyPlayers"
                MainForm.lvPlayers.Items.Clear()
                For Each i In oUserData
                    MainForm.lvPlayers.Items.Add(i)
                Next

            Case "SpecInfoPos"
                SendKeys.Send("spec_goto " & oUserData(0))
                SendKeys.Send("{ENTER}")

            Case "SpecInfoTick"
                SendKeys.Send("demo_pause")
                SendKeys.Send("{ENTER}")
                SendKeys.Send("demo_gototick " & oUserData(0))
                SendKeys.Send("{ENTER}")

            Case "SpecInfoPause"
                SendKeys.Send("demo_pause")
                SendKeys.Send("{ENTER}")

            Case "SpecInfoResume"
                SendKeys.Send("demo_resume")
                SendKeys.Send("{ENTER}")


        End Select
    End Sub

    Public Sub sendPlayers()
        Dim oUserData As New List(Of Object)
        For Each lvItem As ListViewItem In MainForm.lvPlayers.Items
            oUserData.Add(lvItem)
        Next
        For Each lvItem As ListViewItem In MainForm.lvPlayers.Items
            UTClient.sendUTicket(lvItem.Text, "LobbyPlayers", oUserData)
        Next
    End Sub

    <DllImport("user32.dll")>
    Public Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    Public Const KeyDown As Integer = &H8000
End Module
