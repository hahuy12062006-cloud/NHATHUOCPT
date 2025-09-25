Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class frmXemHoaDonDaNhap
    Private Sub frmXemHoaDonDaNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tải danh sách nhà cung cấp để lọc
        LoadNhaCungCap()

        ' Tải toàn bộ danh sách phiếu nhập khi form khởi động
        LoadDanhSachHoaDon()
    End Sub
    Private Sub LoadNhaCungCap()
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            Dim query As String = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap"
            Using adapter As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Thêm mục "Tất cả" vào ComboBox
                Dim allRow As DataRow = dt.NewRow()
                allRow("MaNhaCungCap") = 0
                allRow("TenNhaCungCap") = "Tất cả"
                dt.Rows.InsertAt(allRow, 0)

                cboNhaCungCap.DataSource = dt
                cboNhaCungCap.DisplayMember = "TenNhaCungCap"
                cboNhaCungCap.ValueMember = "MaNhaCungCap"
            End Using
        End Using
    End Sub

    ' Tải danh sách các phiếu nhập hàng
    Private Sub LoadDanhSachHoaDon(Optional ngayNhap As DateTime? = Nothing, Optional maNhaCungCap As Integer? = Nothing)
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            Dim query As String = "SELECT NH.MaNhapHang, NH.NgayNhap, NCC.TenNhaCungCap, NH.TongTien FROM NhapHang AS NH INNER JOIN NhaCungCap AS NCC ON NH.MaNhaCungCap = NCC.MaNhaCungCap WHERE 1=1 "
            Dim cmd As New SqlCommand()

            ' Thêm điều kiện lọc nếu có
            If ngayNhap.HasValue Then
                query &= " AND CAST(NH.NgayNhap AS DATE) = @NgayNhap"
                cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap.Value.Date)
            End If

            If maNhaCungCap.HasValue AndAlso maNhaCungCap.Value <> 0 Then
                query &= " AND NH.MaNhaCungCap = @MaNhaCungCap"
                cmd.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap.Value)
            End If

            cmd.CommandText = query
            cmd.Connection = con
            con.Open()

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvDanhSachHoaDon.DataSource = dt
        End Using
    End Sub

    ' Lọc danh sách hóa đơn khi người dùng thay đổi ngày hoặc nhà cung cấp
    Private Sub btnLoc_Click(sender As Object, e As EventArgs) Handles btnLoc.Click
        Dim selectedDate As DateTime = dtpNgayNhap.Value
        Dim selectedNcc As Integer = CInt(cboNhaCungCap.SelectedValue)

        LoadDanhSachHoaDon(selectedDate, selectedNcc)
    End Sub

    ' Hiển thị chi tiết của hóa đơn được chọn
    Private Sub dgvDanhSachHoaDon_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDanhSachHoaDon.CellClick
        If e.RowIndex >= 0 Then
            Dim maNhapHang As Integer = CInt(dgvDanhSachHoaDon.Rows(e.RowIndex).Cells("MaNhapHang").Value)
            LoadChiTietHoaDon(maNhapHang)
        End If
    End Sub

    ' Tải chi tiết của một hóa đơn cụ thể
    Private Sub LoadChiTietHoaDon(ByVal maNhapHang As Integer)
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            Dim query As String = "SELECT CT.MaThuoc, T.TenThuoc, CT.SoLuongNhap, CT.DonGiaNhapTaiThoiDiem, CT.SoLuongNhap * CT.DonGiaNhapTaiThoiDiem AS ThanhTien FROM ChiTietNhapHang AS CT INNER JOIN Thuoc AS T ON CT.MaThuoc = T.MaThuoc WHERE CT.MaNhapHang = @MaNhapHang"
            Using adapter As New SqlDataAdapter(query, con)
                adapter.SelectCommand.Parameters.AddWithValue("@MaNhapHang", maNhapHang)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvChiTietHoaDon.DataSource = dt
            End Using
        End Using
    End Sub
End Class