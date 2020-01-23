<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gravity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.massChoice_txt = New System.Windows.Forms.TextBox()
        Me.ConfirmMass = New System.Windows.Forms.Button()
        Me.WorldTime = New System.Windows.Forms.Timer(Me.components)
        Me.ConfirmRadius = New System.Windows.Forms.Button()
        Me.RadiusChoice_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ConfirmMult = New System.Windows.Forms.Button()
        Me.MultiplierChoice_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mass"
        '
        'massChoice_txt
        '
        Me.massChoice_txt.Location = New System.Drawing.Point(15, 25)
        Me.massChoice_txt.Name = "massChoice_txt"
        Me.massChoice_txt.Size = New System.Drawing.Size(100, 20)
        Me.massChoice_txt.TabIndex = 1
        '
        'ConfirmMass
        '
        Me.ConfirmMass.Location = New System.Drawing.Point(52, 5)
        Me.ConfirmMass.Name = "ConfirmMass"
        Me.ConfirmMass.Size = New System.Drawing.Size(64, 20)
        Me.ConfirmMass.TabIndex = 2
        Me.ConfirmMass.Text = "Confirm"
        Me.ConfirmMass.UseVisualStyleBackColor = True
        '
        'WorldTime
        '
        Me.WorldTime.Enabled = True
        Me.WorldTime.Interval = 50
        '
        'ConfirmRadius
        '
        Me.ConfirmRadius.Location = New System.Drawing.Point(172, 5)
        Me.ConfirmRadius.Name = "ConfirmRadius"
        Me.ConfirmRadius.Size = New System.Drawing.Size(64, 20)
        Me.ConfirmRadius.TabIndex = 5
        Me.ConfirmRadius.Text = "Confirm"
        Me.ConfirmRadius.UseVisualStyleBackColor = True
        '
        'RadiusChoice_txt
        '
        Me.RadiusChoice_txt.Location = New System.Drawing.Point(135, 25)
        Me.RadiusChoice_txt.Name = "RadiusChoice_txt"
        Me.RadiusChoice_txt.Size = New System.Drawing.Size(100, 20)
        Me.RadiusChoice_txt.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Radius"
        '
        'ConfirmMult
        '
        Me.ConfirmMult.Location = New System.Drawing.Point(291, 5)
        Me.ConfirmMult.Name = "ConfirmMult"
        Me.ConfirmMult.Size = New System.Drawing.Size(64, 20)
        Me.ConfirmMult.TabIndex = 8
        Me.ConfirmMult.Text = "Confirm"
        Me.ConfirmMult.UseVisualStyleBackColor = True
        '
        'MultiplierChoice_txt
        '
        Me.MultiplierChoice_txt.Location = New System.Drawing.Point(254, 25)
        Me.MultiplierChoice_txt.Name = "MultiplierChoice_txt"
        Me.MultiplierChoice_txt.Size = New System.Drawing.Size(100, 20)
        Me.MultiplierChoice_txt.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "mult"
        '
        'Gravity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ConfirmMult)
        Me.Controls.Add(Me.MultiplierChoice_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ConfirmRadius)
        Me.Controls.Add(Me.RadiusChoice_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ConfirmMass)
        Me.Controls.Add(Me.massChoice_txt)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "Gravity"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents massChoice_txt As TextBox
    Friend WithEvents ConfirmMass As Button
    Friend WithEvents WorldTime As Timer
    Friend WithEvents ConfirmRadius As Button
    Friend WithEvents RadiusChoice_txt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ConfirmMult As Button
    Friend WithEvents MultiplierChoice_txt As TextBox
    Friend WithEvents Label3 As Label
End Class
