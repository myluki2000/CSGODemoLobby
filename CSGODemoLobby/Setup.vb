Public Class Setup
    Public Shared Sub CreateConfig()
        Dim fs As IO.FileStream = IO.File.Create(My.Settings.cfgDirectory & "\CSGODemoLobby.cfg")

        ' Add text to the file.
        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes("bind F13 demo_resume" & vbNewLine &
                                                                         "bind F14 demo_pause")
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
End Class
