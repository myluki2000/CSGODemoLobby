Public Class Setup
    Public Shared Sub CreateConfig()
        Dim fs As IO.FileStream = IO.File.Create(My.Settings.csgoDirectory & "\csgo\cfg\CSGODemoLobby.cfg")

        ' Add text to the file.
        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes("bind kp_leftarrow ""demo_timescale 0.5""" & vbNewLine &
                                                                         "bind kp_5 ""demo_timescale 1""" & vbNewLine &
                                                                         "bind kp_rightarrow ""demo_timescale 2""" & vbNewLine &
                                                                         "bindtoggle kp_ins demo_timescale")
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
End Class
