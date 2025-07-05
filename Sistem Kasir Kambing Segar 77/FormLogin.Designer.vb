<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblUsername = New Label()
        lblPassword = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        btnBatal = New Button()
        SuspendLayout()
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 12F)
        lblUsername.Location = New Point(53, 56)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(99, 28)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 12F)
        lblPassword.Location = New Point(53, 108)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(93, 28)
        lblPassword.TabIndex = 1
        lblPassword.Text = "Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 12F)
        txtUsername.Location = New Point(181, 53)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(164, 34)
        txtUsername.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 12F)
        txtPassword.Location = New Point(181, 108)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(164, 34)
        txtPassword.TabIndex = 3
        ' 
        ' btnLogin
        ' 
        btnLogin.Font = New Font("Segoe UI", 12F)
        btnLogin.Location = New Point(64, 204)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(94, 43)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Font = New Font("Segoe UI", 12F)
        btnBatal.Location = New Point(206, 204)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(94, 43)
        btnBatal.TabIndex = 5
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(439, 321)
        Controls.Add(btnBatal)
        Controls.Add(btnLogin)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        MaximizeBox = False
        Name = "FormLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormLogin"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnBatal As Button

End Class
