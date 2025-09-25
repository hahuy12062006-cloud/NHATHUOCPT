<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmXemHoaDonBanHang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvChiTiet = New System.Windows.Forms.DataGridView()
        Me.btnLoc = New System.Windows.Forms.Button()
        Me.dtpNgayBan = New System.Windows.Forms.DateTimePicker()
        Me.dgvHoaDon = New System.Windows.Forms.DataGridView()
        Me.txtMaKhachHang = New System.Windows.Forms.TextBox()
        Me.txtTenKhachHang = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHoaDon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Mã khách hàng"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Ngày lập phiếu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Chi tiết hóa đơn bán hàng"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Danh sách hóa đơn bán hàng"
        '
        'dgvChiTiet
        '
        Me.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChiTiet.Location = New System.Drawing.Point(12, 280)
        Me.dgvChiTiet.Name = "dgvChiTiet"
        Me.dgvChiTiet.RowTemplate.Height = 27
        Me.dgvChiTiet.Size = New System.Drawing.Size(644, 150)
        Me.dgvChiTiet.TabIndex = 13
        '
        'btnLoc
        '
        Me.btnLoc.Location = New System.Drawing.Point(276, 62)
        Me.btnLoc.Name = "btnLoc"
        Me.btnLoc.Size = New System.Drawing.Size(88, 27)
        Me.btnLoc.TabIndex = 11
        Me.btnLoc.Text = "Lọc"
        Me.btnLoc.UseVisualStyleBackColor = True
        '
        'dtpNgayBan
        '
        Me.dtpNgayBan.Location = New System.Drawing.Point(344, 12)
        Me.dtpNgayBan.Name = "dtpNgayBan"
        Me.dtpNgayBan.Size = New System.Drawing.Size(200, 25)
        Me.dtpNgayBan.TabIndex = 10
        '
        'dgvHoaDon
        '
        Me.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHoaDon.Location = New System.Drawing.Point(11, 95)
        Me.dgvHoaDon.Name = "dgvHoaDon"
        Me.dgvHoaDon.RowTemplate.Height = 27
        Me.dgvHoaDon.Size = New System.Drawing.Size(645, 164)
        Me.dgvHoaDon.TabIndex = 9
        '
        'txtMaKhachHang
        '
        Me.txtMaKhachHang.Location = New System.Drawing.Point(122, 12)
        Me.txtMaKhachHang.Name = "txtMaKhachHang"
        Me.txtMaKhachHang.Size = New System.Drawing.Size(100, 25)
        Me.txtMaKhachHang.TabIndex = 18
        '
        'txtTenKhachHang
        '
        Me.txtTenKhachHang.Location = New System.Drawing.Point(122, 48)
        Me.txtTenKhachHang.Name = "txtTenKhachHang"
        Me.txtTenKhachHang.Size = New System.Drawing.Size(100, 25)
        Me.txtTenKhachHang.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Tên khách hàng"
        '
        'frmXemHoaDonBanHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(657, 432)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTenKhachHang)
        Me.Controls.Add(Me.txtMaKhachHang)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvChiTiet)
        Me.Controls.Add(Me.btnLoc)
        Me.Controls.Add(Me.dtpNgayBan)
        Me.Controls.Add(Me.dgvHoaDon)
        Me.Name = "frmXemHoaDonBanHang"
        Me.Text = "frmHoaDon"
        CType(Me.dgvChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHoaDon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvChiTiet As DataGridView
    Friend WithEvents btnLoc As Button
    Friend WithEvents dtpNgayBan As DateTimePicker
    Friend WithEvents dgvHoaDon As DataGridView
    Friend WithEvents txtMaKhachHang As TextBox
    Friend WithEvents txtTenKhachHang As TextBox
    Friend WithEvents Label5 As Label
End Class
