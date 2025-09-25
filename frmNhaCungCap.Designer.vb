<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhaCungCap
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
        Me.dgvNhaCungCap = New System.Windows.Forms.DataGridView()
        Me.dgvSoLuongTon = New System.Windows.Forms.DataGridView()
        Me.dgvHoaDon = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvNhaCungCap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSoLuongTon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHoaDon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNhaCungCap
        '
        Me.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNhaCungCap.Location = New System.Drawing.Point(0, 27)
        Me.dgvNhaCungCap.Name = "dgvNhaCungCap"
        Me.dgvNhaCungCap.RowTemplate.Height = 27
        Me.dgvNhaCungCap.Size = New System.Drawing.Size(771, 150)
        Me.dgvNhaCungCap.TabIndex = 0
        '
        'dgvSoLuongTon
        '
        Me.dgvSoLuongTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSoLuongTon.Location = New System.Drawing.Point(12, 368)
        Me.dgvSoLuongTon.Name = "dgvSoLuongTon"
        Me.dgvSoLuongTon.RowTemplate.Height = 27
        Me.dgvSoLuongTon.Size = New System.Drawing.Size(759, 120)
        Me.dgvSoLuongTon.TabIndex = 1
        '
        'dgvHoaDon
        '
        Me.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHoaDon.Location = New System.Drawing.Point(190, 203)
        Me.dgvHoaDon.Name = "dgvHoaDon"
        Me.dgvHoaDon.RowTemplate.Height = 27
        Me.dgvHoaDon.Size = New System.Drawing.Size(581, 131)
        Me.dgvHoaDon.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Danh sách nhà cung cấp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tồn kho"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 350)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nhập"
        '
        'frmNhaCungCap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(783, 518)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvHoaDon)
        Me.Controls.Add(Me.dgvSoLuongTon)
        Me.Controls.Add(Me.dgvNhaCungCap)
        Me.Name = "frmNhaCungCap"
        Me.Text = "frmNhaCungCap"
        CType(Me.dgvNhaCungCap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSoLuongTon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHoaDon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvNhaCungCap As DataGridView
    Friend WithEvents dgvSoLuongTon As DataGridView
    Friend WithEvents dgvHoaDon As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
