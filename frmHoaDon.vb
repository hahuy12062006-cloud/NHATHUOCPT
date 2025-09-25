Imports System.Data.SqlClient
Imports System.Data

Public Class frmXemHoaDonBanHang
    Private ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"

    'Hàm này sẽ được gọi khi form được load.
    Private Sub frmXemHoaDonBanHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tải danh sách hóa đơn bán hàng ban đầu
        LoadSalesInvoices()
    End Sub

    ' Tải danh sách các hóa đơn từ bảng BanHang và hiển thị lên dgvHoaDon
    Private Sub LoadSalesInvoices(Optional searchTerm As String = "")
        Using con As New SqlConnection(ConString)
            Try
                ' Tạo câu truy vấn SQL ban đầu
                Dim query As String = "SELECT BH.MaBanHang, BH.NgayBan, BH.TongTien, KH.TenKhachHang " &
                                     "FROM BanHang BH JOIN KhachHang KH ON BH.MaKhachHang = KH.MaKhachHang"

                ' Kiểm tra nếu có từ khóa tìm kiếm thì thêm điều kiện WHERE vào câu truy vấn
                If Not String.IsNullOrEmpty(searchTerm) Then
                    query &= " WHERE KH.TenKhachHang LIKE @searchTerm OR BH.MaBanHang LIKE @searchTerm OR KH.MaKhachHang LIKE @searchTerm"
                End If

                query &= " ORDER BY BH.NgayBan DESC"

                Dim da As New SqlDataAdapter(query, con)

                ' Thêm tham số tìm kiếm để tránh SQL Injection
                If Not String.IsNullOrEmpty(searchTerm) Then
                    da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")
                End If

                Dim dt As New DataTable()
                da.Fill(dt)

                ' Hiển thị dữ liệu lên DataGridView
                dgvHoaDon.DataSource = dt
                ' Đặt tên cột tiếng Việt dễ nhìn hơn
                dgvHoaDon.Columns("MaBanHang").HeaderText = "Mã Hóa Đơn"
                dgvHoaDon.Columns("NgayBan").HeaderText = "Ngày Bán"
                dgvHoaDon.Columns("TongTien").HeaderText = "Tổng Tiền"
                dgvHoaDon.Columns("TenKhachHang").HeaderText = "Tên Khách Hàng"

                ' Định dạng các cột
                dgvHoaDon.Columns("TongTien").DefaultCellStyle.Format = "N0" ' Định dạng tiền tệ
                dgvHoaDon.Columns("NgayBan").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss" ' Định dạng ngày giờ

            Catch ex As Exception
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Sự kiện xảy ra khi người dùng chọn một dòng trên dgvHoaDon
    Private Sub dgvHoaDon_SelectionChanged(sender As Object, e As EventArgs) Handles dgvHoaDon.SelectionChanged
        If dgvHoaDon.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvHoaDon.SelectedRows(0)
            Dim maHoaDon As Integer = CInt(selectedRow.Cells("MaBanHang").Value)
            ' Tải chi tiết của hóa đơn đã chọn
            LoadInvoiceDetails(maHoaDon)
        Else
            ' Nếu không có dòng nào được chọn, xóa dữ liệu trên dgvChiTiet
            dgvChiTiet.DataSource = Nothing
        End If
    End Sub

    ' Tải chi tiết của một hóa đơn cụ thể từ bảng ChiTietBanHang
    Private Sub LoadInvoiceDetails(maHoaDon As Integer)
        Using con As New SqlConnection(ConString)
            Try
                Dim query As String = "SELECT CTBH.SoLuongBan, CTBH.DonGiaBanTaiThoiDiem, T.TenThuoc, (CTBH.SoLuongBan * CTBH.DonGiaBanTaiThoiDiem) AS ThanhTien " &
                                     "FROM ChiTietBanHang CTBH JOIN Thuoc T ON CTBH.MaThuoc = T.MaThuoc " &
                                     "WHERE CTBH.MaBanHang = @MaHoaDon"

                Dim da As New SqlDataAdapter(query, con)
                da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon)
                Dim dt As New DataTable()
                da.Fill(dt)

                ' Hiển thị dữ liệu lên DataGridView chi tiết
                dgvChiTiet.DataSource = dt
                ' Đặt tên cột tiếng Việt dễ nhìn hơn
                dgvChiTiet.Columns("TenThuoc").HeaderText = "Tên Thuốc"
                dgvChiTiet.Columns("SoLuongBan").HeaderText = "Số Lượng Bán"
                dgvChiTiet.Columns("DonGiaBanTaiThoiDiem").HeaderText = "Đơn Giá Bán"
                dgvChiTiet.Columns("ThanhTien").HeaderText = "Thành Tiền"

                ' Định dạng tiền tệ cho các cột liên quan
                dgvChiTiet.Columns("DonGiaBanTaiThoiDiem").DefaultCellStyle.Format = "N0"
                dgvChiTiet.Columns("ThanhTien").DefaultCellStyle.Format = "N0"

            Catch ex As Exception
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Sự kiện khi người dùng bấm nút "Lọc"
    Private Sub btnLoc_Click(sender As Object, e As EventArgs) Handles btnLoc.Click
        Dim searchTerm As String = txtMaKhachHang.Text.Trim()
        LoadSalesInvoices(searchTerm)
    End Sub

    ' Sự kiện khi giá trị của ô txtMaKhachHang thay đổi
    Private Sub txtMaKhachHang_TextChanged(sender As Object, e As EventArgs) Handles txtMaKhachHang.TextChanged
        Dim maKH As String = txtMaKhachHang.Text.Trim()

        ' Nếu ô rỗng, xóa tên khách hàng
        If String.IsNullOrEmpty(maKH) Then
            txtTenKhachHang.Text = ""
            Return
        End If

        Using con As New SqlConnection(ConString)
            Try
                con.Open()
                ' Tìm tên khách hàng dựa trên mã khách hàng
                Dim query As String = "SELECT TenKhachHang FROM KhachHang WHERE MaKhachHang = @MaKH"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@MaKH", maKH)

                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        ' Nếu tìm thấy, hiển thị tên khách hàng
                        txtTenKhachHang.Text = result.ToString()
                    Else
                        ' Nếu không tìm thấy, để trống ô tên
                        txtTenKhachHang.Text = ""
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTenKhachHang.Text = ""
            End Try
        End Using
    End Sub

End Class
