Module GlobalVariables
    Public Sub Sleep(time As Integer)
        While time > 0
            Threading.Thread.Sleep(10)
            time -= 10
            Application.DoEvents()
        End While
    End Sub
End Module
