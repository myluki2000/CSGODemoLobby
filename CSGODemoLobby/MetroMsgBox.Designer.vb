<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MetroMsgBox
    Inherits MetroSuite.MetroForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim MainColorScheme2 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Me.btnAccept = New MetroSuite.MetroButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAccept
        '
        MainColorScheme2.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme2.FillColor = System.Drawing.Color.White
        MainColorScheme2.HoverFillColor = System.Drawing.Color.White
        MainColorScheme2.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme2.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.btnAccept.ColorScheme = MainColorScheme2
        Me.btnAccept.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAccept.ForeColor = System.Drawing.Color.Black
        Me.btnAccept.Location = New System.Drawing.Point(439, 161)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(99, 27)
        Me.btnAccept.TabIndex = 0
        Me.btnAccept.Text = "Ok"
        '
        'lblText
        '
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.Location = New System.Drawing.Point(12, 29)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(526, 129)
        Me.lblText.TabIndex = 1
        Me.lblText.Text = "Label1"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MetroMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 200)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.btnAccept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(550, 200)
        Me.MinimumSize = New System.Drawing.Size(550, 200)
        Me.Name = "MetroMsgBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.State = MetroSuite.MetroForm.FormState.Normal
        Me.Style = MetroSuite.Design.FormStyle.Light
        Me.Text = "Message"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAccept As MetroSuite.MetroButton
    Friend WithEvents lblText As Label
End Class
