<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXemHoaDonDaNhap
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
        Me.dgvDanhSachHoaDon = New System.Windows.Forms.DataGridView()
        Me.dtpNgayNhap = New System.Windows.Forms.DateTimePicker()
        Me.btnLoc = New System.Windows.Forms.Button()
        Me.cboNhaCungCap = New System.Windows.Forms.ComboBox()
        Me.dgvChiTietHoaDon = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvDanhSachHoaDon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvChiTietHoaDon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDanhSachHoaDon
        '
        Me.dgvDanhSachHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachHoaDon.Location = New System.Drawing.Point(1, 97)
        Me.dgvDanhSachHoaDon.Name = "dgvDanhSachHoaDon"
        Me.dgvDanhSachHoaDon.RowTemplate.Height = 27
        Me.dgvDanhSachHoaDon.Size = New System.Drawing.Size(645, 164)
        Me.dgvDanhSachHoaDon.TabIndex = 0
        '
        'dtpNgayNhap
        '
        Me.dtpNgayNhap.Location = New System.Drawing.Point(104, 2)
        Me.dtpNgayNhap.Name = "dtpNgayNhap"
        Me.dtpNgayNhap.Size = New System.Drawing.Size(200, 25)
        Me.dtpNgayNhap.TabIndex = 1
        '
        'btnLoc
        '
        Me.btnLoc.Location = New System.Drawing.Point(360, 35)
        Me.btnLoc.Name = "btnLoc"
        Me.btnLoc.Size = New System.Drawing.Size(88, 27)
        Me.btnLoc.TabIndex = 2
        Me.btnLoc.Text = "Lọc"
        Me.btnLoc.UseVisualStyleBackColor = True
        '
        'cboNhaCungCap
        '
        Me.cboNhaCungCap.FormattingEnabled = True
        Me.cboNhaCungCap.Location = New System.Drawing.Point(104, 39)
        Me.cboNhaCungCap.Name = "cboNhaCungCap"
        Me.cboNhaCungCap.Size = New System.Drawing.Size(200, 23)
        Me.cboNhaCungCap.TabIndex = 3
        '
        'dgvChiTietHoaDon
        '
        Me.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChiTietHoaDon.Location = New System.Drawing.Point(1, 282)
        Me.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon"
        Me.dgvChiTietHoaDon.RowTemplate.Height = 27
        Me.dgvChiTietHoaDon.Size = New System.Drawing.Size(644, 150)
        Me.dgvChiTietHoaDon.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-2, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Danh sách hóa đơn nhập"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-2, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Chi tiết hóa đơn nhập" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-2, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ngày lập phiếu"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-2, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nhà cung cấp"
        '
        'frmXemHoaDonDaNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(646, 435)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvChiTietHoaDon)
        Me.Controls.Add(Me.cboNhaCungCap)
        Me.Controls.Add(Me.btnLoc)
        Me.Controls.Add(Me.dtpNgayNhap)
        Me.Controls.Add(Me.dgvDanhSachHoaDon)
        Me.Name = "frmXemHoaDonDaNhap"
        Me.Text = "frmXemHoaDonDaNhap"
        CType(Me.dgvDanhSachHoaDon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvChiTietHoaDon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDanhSachHoaDon As DataGridView
    Friend WithEvents dtpNgayNhap As DateTimePicker
    Friend WithEvents btnLoc As Button
    Friend WithEvents cboNhaCungCap As ComboBox
    Friend WithEvents dgvChiTietHoaDon As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
