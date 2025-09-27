Imports System.Data.SqlClient

Public Class frmNhaCungCap
    Private connString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True;"

    Private Sub frmNhaCungCap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub

    Private Sub LoadSuppliers()
        Using conn As New SqlConnection(connString)
            Dim sql As String = "SELECT MaNhaCungCap, TenNhaCungCap, NguoiLienHe, SoDienThoai, Email FROM NhaCungCap;"
            Dim adapter As New SqlDataAdapter(sql, conn)
            Dim dt As New DataTable()

            Try
                conn.Open()
                adapter.Fill(dt)
                dgvNhaCungCap.DataSource = dt
                dgvSoLuongTon.DataSource = Nothing
                dgvHoaDon.DataSource = Nothing
            Catch ex As Exception
                MessageBox.Show("Error loading suppliers: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub dgvNhaCungCap_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNhaCungCap.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvNhaCungCap.Rows(e.RowIndex)
            Dim maNhaCungCap As Integer = CInt(row.Cells("MaNhaCungCap").Value)
            LoadInventory(maNhaCungCap)
            LoadInvoices(maNhaCungCap)
        End If
    End Sub
    Private Sub LoadInventory(ByVal maNhaCungCap As Integer)
        Using conn As New SqlConnection(connString)
            Dim sql As String = "SELECT T.MaThuoc, T.TenThuoc, T.NhaSanXuat, T.DangBaoChe, T.HamLuong, T.DonGia, T.NgayHetHan, SUM(CTNH.SoLuongNhap) AS TongSoLuongNhap " &
                                "FROM ChiTietNhapHang CTNH " &
                                "JOIN NhapHang NH ON CTNH.MaNhapHang = NH.MaNhapHang " &
                                "JOIN Thuoc T ON CTNH.MaThuoc = T.MaThuoc " &
                                "WHERE NH.MaNhaCungCap = @MaNhaCungCap " &
                                "GROUP BY T.MaThuoc, T.TenThuoc, T.NhaSanXuat, T.DangBaoChe, T.HamLuong, T.DonGia, T.NgayHetHan;"

            Dim adapter As New SqlDataAdapter(sql, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap)

            Dim dt As New DataTable()

            Try
                conn.Open()
                adapter.Fill(dt)
                dgvSoLuongTon.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error loading inventory: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub LoadInvoices(ByVal maNhaCungCap As Integer)
        Using conn As New SqlConnection(connString)
            Dim sql As String = "SELECT MaNhapHang, NgayNhap, TongTien FROM NhapHang WHERE MaNhaCungCap = @MaNhaCungCap;"

            Dim adapter As New SqlDataAdapter(sql, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap)

            Dim dt As New DataTable()

            Try
                conn.Open()
                adapter.Fill(dt)
                dgvHoaDon.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error loading invoices: " & ex.Message)
            End Try
        End Using
    End Sub

End Class