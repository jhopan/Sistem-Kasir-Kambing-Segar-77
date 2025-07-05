<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManajemenPengguna
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
        dgvPengguna = New DataGridView()
        grpDetail = New GroupBox()
        cmbRole = New ComboBox()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        txtNamaLengkap = New TextBox()
        btnHapus = New Button()
        btnBatal = New Button()
        btnEdit = New Button()
        btnSimpan = New Button()
        lblUserId = New Label()
        lblRole = New Label()
        lblUsername = New Label()
        lblPassword = New Label()
        lblNamaLengkap = New Label()
        CType(dgvPengguna, ComponentModel.ISupportInitialize).BeginInit()
        grpDetail.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvPengguna
        ' 
        dgvPengguna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPengguna.Dock = DockStyle.Left
        dgvPengguna.Location = New Point(0, 0)
        dgvPengguna.Name = "dgvPengguna"
        dgvPengguna.RowHeadersWidth = 51
        dgvPengguna.Size = New Size(706, 733)
        dgvPengguna.TabIndex = 0
        ' 
        ' grpDetail
        ' 
        grpDetail.Controls.Add(cmbRole)
        grpDetail.Controls.Add(txtUsername)
        grpDetail.Controls.Add(txtPassword)
        grpDetail.Controls.Add(txtNamaLengkap)
        grpDetail.Controls.Add(btnHapus)
        grpDetail.Controls.Add(btnBatal)
        grpDetail.Controls.Add(btnEdit)
        grpDetail.Controls.Add(btnSimpan)
        grpDetail.Controls.Add(lblUserId)
        grpDetail.Controls.Add(lblRole)
        grpDetail.Controls.Add(lblUsername)
        grpDetail.Controls.Add(lblPassword)
        grpDetail.Controls.Add(lblNamaLengkap)
        grpDetail.Dock = DockStyle.Fill
        grpDetail.Location = New Point(706, 0)
        grpDetail.Name = "grpDetail"
        grpDetail.Size = New Size(756, 733)
        grpDetail.TabIndex = 1
        grpDetail.TabStop = False
        ' 
        ' cmbRole
        ' 
        cmbRole.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbRole.FormattingEnabled = True
        cmbRole.Items.AddRange(New Object() {"admin", "kasir"})
        cmbRole.Location = New Point(175, 156)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(310, 33)
        cmbRole.TabIndex = 12
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 10.8F)
        txtUsername.Location = New Point(175, 79)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(310, 31)
        txtUsername.TabIndex = 11
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 10.8F)
        txtPassword.Location = New Point(175, 116)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(310, 31)
        txtPassword.TabIndex = 10
        ' 
        ' txtNamaLengkap
        ' 
        txtNamaLengkap.Font = New Font("Segoe UI", 10.8F)
        txtNamaLengkap.Location = New Point(175, 39)
        txtNamaLengkap.Name = "txtNamaLengkap"
        txtNamaLengkap.Size = New Size(310, 31)
        txtNamaLengkap.TabIndex = 9
        ' 
        ' btnHapus
        ' 
        btnHapus.Font = New Font("Segoe UI", 10.8F)
        btnHapus.Location = New Point(281, 233)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(94, 43)
        btnHapus.TabIndex = 8
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Font = New Font("Segoe UI", 10.8F)
        btnBatal.Location = New Point(410, 233)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(94, 43)
        btnBatal.TabIndex = 7
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Font = New Font("Segoe UI", 10.8F)
        btnEdit.Location = New Point(148, 233)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(94, 43)
        btnEdit.TabIndex = 6
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Font = New Font("Segoe UI", 10.8F)
        btnSimpan.Location = New Point(21, 233)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(94, 43)
        btnSimpan.TabIndex = 5
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' lblUserId
        ' 
        lblUserId.AutoSize = True
        lblUserId.Location = New Point(395, 23)
        lblUserId.Name = "lblUserId"
        lblUserId.Size = New Size(22, 20)
        lblUserId.TabIndex = 4
        lblUserId.Text = "Id"
        lblUserId.Visible = False
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 10.8F)
        lblRole.Location = New Point(21, 159)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(46, 25)
        lblRole.TabIndex = 3
        lblRole.Text = "Role"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10.8F)
        lblUsername.Location = New Point(21, 79)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(91, 25)
        lblUsername.TabIndex = 2
        lblUsername.Text = "Username"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 10.8F)
        lblPassword.Location = New Point(21, 119)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(87, 25)
        lblPassword.TabIndex = 1
        lblPassword.Text = "Password"
        ' 
        ' lblNamaLengkap
        ' 
        lblNamaLengkap.AutoSize = True
        lblNamaLengkap.Font = New Font("Segoe UI", 10.8F)
        lblNamaLengkap.Location = New Point(21, 37)
        lblNamaLengkap.Name = "lblNamaLengkap"
        lblNamaLengkap.Size = New Size(131, 25)
        lblNamaLengkap.TabIndex = 0
        lblNamaLengkap.Text = "Nama Lengkap"
        ' 
        ' FormManajemenPengguna
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 733)
        Controls.Add(grpDetail)
        Controls.Add(dgvPengguna)
        Name = "FormManajemenPengguna"
        Text = "FormManajemenPengguna"
        CType(dgvPengguna, ComponentModel.ISupportInitialize).EndInit()
        grpDetail.ResumeLayout(False)
        grpDetail.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvPengguna As DataGridView
    Friend WithEvents grpDetail As GroupBox
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblUserId As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblNamaLengkap As Label
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtNamaLengkap As TextBox
End Class
