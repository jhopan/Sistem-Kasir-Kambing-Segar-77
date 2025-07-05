<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporan
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
        dgvLaporan = New DataGridView()
        grpLaporan = New GroupBox()
        numTahun = New NumericUpDown()
        lblTotalPendapatan = New Label()
        btnTampilkan = New Button()
        cmbBulan = New ComboBox()
        lblTotalTransaksi = New Label()
        lblTahun = New Label()
        lblBulan = New Label()
        CType(dgvLaporan, ComponentModel.ISupportInitialize).BeginInit()
        grpLaporan.SuspendLayout()
        CType(numTahun, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvLaporan
        ' 
        dgvLaporan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLaporan.Dock = DockStyle.Left
        dgvLaporan.Location = New Point(0, 0)
        dgvLaporan.Margin = New Padding(3, 4, 3, 4)
        dgvLaporan.Name = "dgvLaporan"
        dgvLaporan.RowHeadersWidth = 51
        dgvLaporan.RowTemplate.Height = 24
        dgvLaporan.Size = New Size(706, 916)
        dgvLaporan.TabIndex = 1
        ' 
        ' grpLaporan
        ' 
        grpLaporan.Controls.Add(numTahun)
        grpLaporan.Controls.Add(lblTotalPendapatan)
        grpLaporan.Controls.Add(btnTampilkan)
        grpLaporan.Controls.Add(cmbBulan)
        grpLaporan.Controls.Add(lblTotalTransaksi)
        grpLaporan.Controls.Add(lblTahun)
        grpLaporan.Controls.Add(lblBulan)
        grpLaporan.Dock = DockStyle.Fill
        grpLaporan.Location = New Point(706, 0)
        grpLaporan.Margin = New Padding(3, 4, 3, 4)
        grpLaporan.Name = "grpLaporan"
        grpLaporan.Padding = New Padding(3, 4, 3, 4)
        grpLaporan.Size = New Size(756, 916)
        grpLaporan.TabIndex = 2
        grpLaporan.TabStop = False
        ' 
        ' numTahun
        ' 
        numTahun.Location = New Point(180, 90)
        numTahun.Name = "numTahun"
        numTahun.Size = New Size(230, 27)
        numTahun.TabIndex = 20
        ' 
        ' lblTotalPendapatan
        ' 
        lblTotalPendapatan.AutoSize = True
        lblTotalPendapatan.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalPendapatan.Location = New Point(32, 206)
        lblTotalPendapatan.Name = "lblTotalPendapatan"
        lblTotalPendapatan.Size = New Size(178, 25)
        lblTotalPendapatan.TabIndex = 19
        lblTotalPendapatan.Text = "Total Pendapatan :"
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnTampilkan.Location = New Point(208, 268)
        btnTampilkan.Margin = New Padding(3, 4, 3, 4)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(121, 44)
        btnTampilkan.TabIndex = 18
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' cmbBulan
        ' 
        cmbBulan.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbBulan.FormattingEnabled = True
        cmbBulan.Location = New Point(180, 28)
        cmbBulan.Margin = New Padding(3, 4, 3, 4)
        cmbBulan.Name = "cmbBulan"
        cmbBulan.Size = New Size(230, 33)
        cmbBulan.TabIndex = 15
        ' 
        ' lblTotalTransaksi
        ' 
        lblTotalTransaksi.AutoSize = True
        lblTotalTransaksi.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalTransaksi.Location = New Point(32, 154)
        lblTotalTransaksi.Name = "lblTotalTransaksi"
        lblTotalTransaksi.Size = New Size(158, 25)
        lblTotalTransaksi.TabIndex = 14
        lblTotalTransaksi.Text = "Total Transaksi :"
        ' 
        ' lblTahun
        ' 
        lblTahun.AutoSize = True
        lblTahun.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTahun.Location = New Point(32, 92)
        lblTahun.Name = "lblTahun"
        lblTahun.Size = New Size(69, 25)
        lblTahun.TabIndex = 12
        lblTahun.Text = "Tahun"
        ' 
        ' lblBulan
        ' 
        lblBulan.AutoSize = True
        lblBulan.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblBulan.Location = New Point(32, 31)
        lblBulan.Name = "lblBulan"
        lblBulan.Size = New Size(62, 25)
        lblBulan.TabIndex = 11
        lblBulan.Text = "Bulan"
        ' 
        ' FormLaporan
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 916)
        Controls.Add(grpLaporan)
        Controls.Add(dgvLaporan)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FormLaporan"
        Text = "Laporan - Kost Elite JY"
        CType(dgvLaporan, ComponentModel.ISupportInitialize).EndInit()
        grpLaporan.ResumeLayout(False)
        grpLaporan.PerformLayout()
        CType(numTahun, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLaporan As DataGridView
    Friend WithEvents grpLaporan As GroupBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents cmbBulan As ComboBox
    Friend WithEvents lblTotalTransaksi As Label
    Friend WithEvents lblTahun As Label
    Friend WithEvents lblBulan As Label
    Friend WithEvents numTahun As NumericUpDown
    Friend WithEvents lblTotalPendapatan As Label
End Class
