Public Class MetroMsgBox

    Public Shared label As String

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Me.Close()
    End Sub

    Private Sub MetroMsgBox_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        lblText.Text = label
    End Sub
End Class