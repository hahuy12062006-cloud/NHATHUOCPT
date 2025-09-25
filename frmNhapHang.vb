Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class frmNhapHang
    'LƯU DATA NHẬP HÀNG
    Private dtChiTietNhapHang As DataTable
    'BIẾN LƯU LOẠI THUỐC ĐUỌC CHỌN
    Private maThuocVuaChon As Integer
    'BIẾN LƯU MÃ NHẬP HÀNG ĐỂ IN
    Private currentMaNhapHangToPrint As Integer
    'BIẾN TOÀN CỤC ĐỂ LƯU DŨ LIỆU KHI IN
    Private dtPrintHeaderNhapHang As DataTable
    Private dtPrintDetailsNhapHang As DataTable
    Private _userName As String
    Public Sub New(ByVal user As String)
        InitializeComponent()
        Me._userName = user
    End Sub

    Private Sub frmNhapHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtChiTietNhapHang = New DataTable()
        dtChiTietNhapHang.Columns.Add("MaThuoc", GetType(Integer))
        dtChiTietNhapHang.Columns.Add("TenThuoc", GetType(String))
        dtChiTietNhapHang.Columns.Add("SoLuongNhap", GetType(Integer))
        dtChiTietNhapHang.Columns.Add("DonGiaNhapTaiThoiDiem", GetType(Decimal))
        dtChiTietNhapHang.Columns.Add("ThanhTien", GetType(Decimal))
        dgvChiTietNhapHang.DataSource = dtChiTietNhapHang
        LoadNhaCungCap()
        btnInHoaDon.Enabled = False
        CapNhatTongTien()
    End Sub

    'TẢI DỮ LIỆU CÁC NHÀ CUNG CẤP Ở SQL LÊN COMBOBOX
    Private Sub LoadNhaCungCap()
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            Dim query As String = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap"
            Using adapter As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                cboNhaCungCap.DataSource = dt
                cboNhaCungCap.DisplayMember = "TenNhaCungCap"
                cboNhaCungCap.ValueMember = "MaNhaCungCap"
            End Using
        End Using
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        Dim frm As New frmTimThuocNhap()
        AddHandler frm.DrugSelected, AddressOf frmTimThuocNhap_DrugSelected
        frm.ShowDialog()
    End Sub

    Private Sub frmTimThuocNhap_DrugSelected(ByVal maThuoc As Integer, ByVal tenThuoc As String, ByVal donGia As Decimal)
        'GÁN ĐƠN GIÁ NHẬP
        txtDonGiaNhap.Text = donGia.ToString()
        ' CHECK THUÓC ĐÃ ĐUỌC NHẬP CHƯA
        Dim existingRow As DataRow = dtChiTietNhapHang.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of Integer)("MaThuoc") = maThuoc)
        If existingRow Is Nothing Then
            'NẾU CHUA THÌ THÊM  1 HÀNG MỚI VÀO DataTable.
            Dim newRow As DataRow = dtChiTietNhapHang.NewRow()
            newRow("MaThuoc") = maThuoc
            newRow("TenThuoc") = tenThuoc
            newRow("SoLuongNhap") = 1
            newRow("DonGiaNhapTaiThoiDiem") = donGia
            newRow("ThanhTien") = 1 * donGia
            dtChiTietNhapHang.Rows.Add(newRow)

            maThuocVuaChon = maThuoc
            txtSoLuongNhap.Focus()
            CapNhatTongTien()
        Else
            MessageBox.Show("Thuốc này đã có trong danh sách nhập hàng. Vui lòng cập nhật trực tiếp số lượng và đơn giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtSoLuongNhap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSoLuongNhap.KeyDown
        'SỬ LÝ NÚT ENTER
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'KIỂM TA THUỐC ĐÃ NHẬP VÀ SL
            If maThuocVuaChon <> 0 AndAlso Not String.IsNullOrWhiteSpace(txtSoLuongNhap.Text) Then
                Dim soLuong As Integer = 0
                If Integer.TryParse(txtSoLuongNhap.Text, soLuong) Then
                    If soLuong > 0 Then
                        'TÌM THUỐC TRONG DataTable CÓ TƯƠNG ƯỚC VÓI THUỐC VÙA NHẬP KO
                        Dim rowToUpdate As DataRow = dtChiTietNhapHang.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of Integer)("MaThuoc") = maThuocVuaChon)

                        If rowToUpdate IsNot Nothing Then
                            rowToUpdate("SoLuongNhap") = soLuong
                            Dim donGia As Decimal = CDec(rowToUpdate("DonGiaNhapTaiThoiDiem"))
                            rowToUpdate("ThanhTien") = soLuong * donGia

                            CapNhatTongTien()
                        End If
                    Else
                        MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Vui lòng nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'XÓA GIÁ TRỊ TRÊN TXT
            txtSoLuongNhap.Text = ""
            maThuocVuaChon = 0
        End If
    End Sub

    Private Sub dgvChiTietNhapHang_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChiTietNhapHang.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvChiTietNhapHang.Rows(e.RowIndex)
            'UPDATE DỮ LIỆU KHI CÓ SỰ THAY ĐỔI VỀ SL CÀ ĐƠN GIÁ
            If e.ColumnIndex = dgvChiTietNhapHang.Columns("SoLuongNhap").Index OrElse e.ColumnIndex = dgvChiTietNhapHang.Columns("DonGiaNhapTaiThoiDiem").Index Then
                Dim soLuong As Integer = 0
                Dim donGia As Decimal = 0

                If Not String.IsNullOrWhiteSpace(row.Cells("SoLuongNhap").Value?.ToString()) Then
                    Integer.TryParse(row.Cells("SoLuongNhap").Value.ToString(), soLuong)
                End If
                If Not String.IsNullOrWhiteSpace(row.Cells("DonGiaNhapTaiThoiDiem").Value?.ToString()) Then
                    Decimal.TryParse(row.Cells("DonGiaNhapTaiThoiDiem").Value.ToString(), donGia)
                End If

                row.Cells("ThanhTien").Value = soLuong * donGia
                CapNhatTongTien()
            End If
        End If
    End Sub
    Private Sub CapNhatTongTien()
        Dim tongTien As Decimal = 0
        For Each row As DataRow In dtChiTietNhapHang.Rows
            tongTien += CDec(row("ThanhTien"))
        Next
        lblTongTien.Text = tongTien.ToString("N0") & " VNĐ"
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If dtChiTietNhapHang.Rows.Count = 0 Then
            MessageBox.Show("Vui lòng thêm sản phẩm vào danh sách nhập hàng trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            con.Open()
            'SỬ DỤNG Transaction ĐỂ CÁC THAO TÁC CÙNG NHAU
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                'CHÈN VÀO TABLE NhapHang.
                Dim maNhaCungCap As Integer = CInt(cboNhaCungCap.SelectedValue)
                Dim tongTien As Decimal = 0
                For Each row As DataRow In dtChiTietNhapHang.Rows
                    tongTien += CDec(row("ThanhTien"))
                Next

                Dim insertNhapHangQuery As String = "INSERT INTO NhapHang (MaNhaCungCap, NgayNhap, TongTien) VALUES (@MaNhaCungCap, GETDATE(), @TongTien); SELECT SCOPE_IDENTITY();"
                Dim cmdNhapHang As New SqlCommand(insertNhapHangQuery, con, transaction)
                cmdNhapHang.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap)
                cmdNhapHang.Parameters.AddWithValue("@TongTien", tongTien)

                currentMaNhapHangToPrint = CInt(cmdNhapHang.ExecuteScalar())

                'CHÈN VÀO ChiTietNhapHang VÀ UPDATE TỒN.
                Dim insertChiTietQuery As String = "INSERT INTO ChiTietNhapHang (MaNhapHang, MaThuoc, SoLuongNhap, DonGiaNhapTaiThoiDiem) VALUES (@MaNhapHang, @MaThuoc, @SoLuongNhap, @DonGiaNhap)"
                Dim updateThuocQuery As String = "UPDATE Thuoc SET SoLuongTonKho = SoLuongTonKho + @SoLuongNhap WHERE MaThuoc = @MaThuoc"

                For Each row As DataRow In dtChiTietNhapHang.Rows
                    ' CHÈN VÀO ChiTietNhapHang.
                    Dim cmdChiTiet As New SqlCommand(insertChiTietQuery, con, transaction)
                    cmdChiTiet.Parameters.AddWithValue("@MaNhapHang", currentMaNhapHangToPrint)
                    cmdChiTiet.Parameters.AddWithValue("@MaThuoc", CInt(row("MaThuoc")))
                    cmdChiTiet.Parameters.AddWithValue("@SoLuongNhap", CInt(row("SoLuongNhap")))
                    cmdChiTiet.Parameters.AddWithValue("@DonGiaNhap", CDec(row("DonGiaNhapTaiThoiDiem")))
                    cmdChiTiet.ExecuteNonQuery()

                    'UPDAET TỒN
                    Dim cmdUpdateThuoc As New SqlCommand(updateThuocQuery, con, transaction)
                    cmdUpdateThuoc.Parameters.AddWithValue("@SoLuongNhap", CInt(row("SoLuongNhap")))
                    cmdUpdateThuoc.Parameters.AddWithValue("@MaThuoc", CInt(row("MaThuoc")))
                    cmdUpdateThuoc.ExecuteNonQuery()
                Next

                ' Commit Transaction NẾU CÁC THAO TÁC THÀNH CÔNG
                transaction.Commit()
                MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                btnInHoaDon.Enabled = True

            Catch ex As Exception
                'Rollback Transaction NẾU CÓ LỖI
                transaction.Rollback()
                MessageBox.Show($"Đã xảy ra lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvChiTietNhapHang.SelectedRows.Count > 0 Then
            Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa các mặt hàng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirmResult = DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvChiTietNhapHang.SelectedRows
                    'XÓA THUỐC ĐÃ NHẬP TỪ DataTable
                    dtChiTietNhapHang.Rows.RemoveAt(row.Index)
                Next
                CapNhatTongTien()
                MessageBox.Show("Đã xóa các mặt hàng đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Vui lòng chọn ít nhất một mặt hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu nhập mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult = DialogResult.Yes Then
            dtChiTietNhapHang.Clear()
            CapNhatTongTien()
            btnInHoaDon.Enabled = False
            MessageBox.Show("Hóa đơn đã được lưu. Bạn có thể tạo phiếu nhập mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function LoadImportInvoiceData(maNhapHang As Integer) As Boolean
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"

        dtPrintHeaderNhapHang = New DataTable()
        dtPrintDetailsNhapHang = New DataTable()

        Using con As New SqlConnection(ConString)
            Try
                con.Open()

                Dim queryHeader As String = "SELECT NH.MaNhapHang, NH.NgayNhap, NH.TongTien, NCC.TenNhaCungCap " &
                                             "FROM NhapHang NH JOIN NhaCungCap NCC ON NH.MaNhaCungCap = NCC.MaNhaCungCap " &
                                             "WHERE NH.MaNhapHang = @MaNhapHang"
                Using cmdHeader As New SqlCommand(queryHeader, con)
                    cmdHeader.Parameters.AddWithValue("@MaNhapHang", maNhapHang)
                    Dim adapterHeader As New SqlDataAdapter(cmdHeader)
                    adapterHeader.Fill(dtPrintHeaderNhapHang)
                End Using

                Dim queryDetails As String = "SELECT T.TenThuoc, CTNH.SoLuongNhap, CTNH.DonGiaNhapTaiThoiDiem, " &
                                             "(CTNH.SoLuongNhap * CTNH.DonGiaNhapTaiThoiDiem) AS ThanhTien " &
                                             "FROM ChiTietNhapHang CTNH JOIN Thuoc T ON CTNH.MaThuoc = T.MaThuoc " &
                                             "WHERE CTNH.MaNhapHang = @MaNhapHang"
                Using cmdDetails As New SqlCommand(queryDetails, con)
                    cmdDetails.Parameters.AddWithValue("@MaNhapHang", maNhapHang)
                    Dim adapterDetails As New SqlDataAdapter(cmdDetails)
                    adapterDetails.Fill(dtPrintDetailsNhapHang)
                End Using

                Return dtPrintHeaderNhapHang.Rows.Count > 0
            Catch ex As Exception
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn nhập hàng để in: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Sub PrintDocumentNhapHang_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim yPos As Single = 100
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim rightMargin As Single = e.MarginBounds.Right

        Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fontHeader As New Font("Arial", 12, FontStyle.Bold)
        Dim fontNormal As New Font("Arial", 10, FontStyle.Regular)
        Dim fontBold As New Font("Arial", 10, FontStyle.Bold)

        g.DrawString("NHÀ THUỐC PT", fontTitle, Brushes.Black, leftMargin, yPos)
        yPos += fontTitle.GetHeight(g) + 5
        g.DrawString("Địa chỉ: 505 Minh Khai,phường Vĩnh Tuy,quận Hai Bà Trưng,thành phố Hà Nội", fontNormal, Brushes.Black, leftMargin, yPos)
        yPos += fontNormal.GetHeight(g) + 5
        g.DrawString("Điện thoại: 0987.654.321", fontNormal, Brushes.Black, leftMargin, yPos)
        yPos += fontNormal.GetHeight(g) + 30

        Dim titleString As String = "HÓA ĐƠN NHẬP HÀNG"
        Dim titleSize As SizeF = g.MeasureString(titleString, fontTitle)
        g.DrawString(titleString, fontTitle, Brushes.Black, (e.PageBounds.Width / 2) - (titleSize.Width / 2), yPos)
        yPos += fontTitle.GetHeight(g) + 20

        If dtPrintHeaderNhapHang.Rows.Count > 0 Then
            Dim headerRow As DataRow = dtPrintHeaderNhapHang.Rows(0)
            g.DrawString($"Mã HĐ: {headerRow("MaNhapHang")}", fontHeader, Brushes.Black, leftMargin, yPos)
            yPos += fontHeader.GetHeight(g) + 5
            g.DrawString($"Ngày nhập: {CType(headerRow("NgayNhap"), DateTime).ToString("dd/MM/yyyy HH:mm")}", fontHeader, Brushes.Black, leftMargin, yPos)
            yPos += fontHeader.GetHeight(g) + 5
            Dim tenNhaCungCap As String = If(Not IsDBNull(headerRow("TenNhaCungCap")), headerRow("TenNhaCungCap").ToString(), "Chưa xác định")
            g.DrawString($"Nhà cung cấp: {tenNhaCungCap}", fontHeader, Brushes.Black, leftMargin, yPos)
            yPos += fontHeader.GetHeight(g) + 20
        End If

        Dim colTenThuocX As Single = leftMargin
        Dim colSoLuongX As Single = colTenThuocX + 250
        Dim colDonGiaX As Single = colSoLuongX + 100
        Dim colThanhTienX As Single = colDonGiaX + 100

        g.DrawString("Tên thuốc", fontBold, Brushes.Black, colTenThuocX, yPos)
        g.DrawString("SL", fontBold, Brushes.Black, colSoLuongX, yPos)
        g.DrawString("Đơn giá", fontBold, Brushes.Black, colDonGiaX, yPos)
        g.DrawString("Thành tiền", fontBold, Brushes.Black, colThanhTienX, yPos)
        yPos += fontBold.GetHeight(g) + 5
        g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos)
        yPos += 5

        For Each row As DataRow In dtPrintDetailsNhapHang.Rows
            g.DrawString(row("TenThuoc").ToString(), fontNormal, Brushes.Black, colTenThuocX, yPos)
            g.DrawString(row("SoLuongNhap").ToString(), fontNormal, Brushes.Black, colSoLuongX, yPos)
            g.DrawString(CDec(row("DonGiaNhapTaiThoiDiem")).ToString("N0"), fontNormal, Brushes.Black, colDonGiaX, yPos)
            g.DrawString(CDec(row("ThanhTien")).ToString("N0"), fontNormal, Brushes.Black, colThanhTienX, yPos)
            yPos += fontNormal.GetHeight(g) + 5
        Next

        yPos += 10
        g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos)
        yPos += 5

        If dtPrintHeaderNhapHang.Rows.Count > 0 Then
            Dim tongTien As Decimal = CDec(dtPrintHeaderNhapHang.Rows(0)("TongTien"))
            Dim tongTienString As String = $"TỔNG TIỀN: {tongTien:N0} VNĐ"
            Dim tongTienSize As SizeF = g.MeasureString(tongTienString, fontHeader)
            g.DrawString(tongTienString, fontHeader, Brushes.Black, rightMargin - tongTienSize.Width, yPos)
            yPos += fontHeader.GetHeight(g) + 30
        End If

        g.DrawString("Người lập phiếu", fontNormal, Brushes.Black, leftMargin, yPos)
        g.DrawString("Người nhận hàng", fontNormal, Brushes.Black, rightMargin - g.MeasureString("Người nhận hàng", fontNormal).Width, yPos)
        yPos += fontNormal.GetHeight(g) + 50
        g.DrawString("(Ký, ghi rõ họ tên)", fontNormal, Brushes.Black, leftMargin, yPos)
        g.DrawString("(Ký, ghi rõ họ tên)", fontNormal, Brushes.Black, rightMargin - g.MeasureString("(Ký, ghi rõ họ tên)", fontNormal).Width, yPos)

        e.HasMorePages = False
    End Sub

    ' Chức năng in hóa đơn nhập hàng.
    Private Sub btnInHoaDon_Click(sender As Object, e As EventArgs) Handles btnInHoaDon.Click
        ' Chỉ thực hiện in nếu có dữ liệu đã được lưu
        If currentMaNhapHangToPrint = 0 Then
            MessageBox.Show("Không có hóa đơn nhập hàng nào để in. Vui lòng hoàn tất một đơn nhập hàng trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Tải dữ liệu hóa đơn nhập hàng
        If Not LoadImportInvoiceData(currentMaNhapHangToPrint) Then
            MessageBox.Show("Không thể tải dữ liệu hóa đơn nhập hàng để in. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf Me.PrintDocumentNhapHang_PrintPage

        Dim pdi As New PrintPreviewDialog()
        pdi.Document = pd

        Try
            pdi.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi hiển thị bản xem trước hoặc khi in hóa đơn nhập hàng: " & ex.Message, "Lỗi In", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Reset lại form sau khi người dùng đóng cửa sổ xem trước
        Me.btnReset_Click(sender, e)
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
        Dim mainForm As New frmMain(_userName) ' Truyền tên người dùng vào đây
        mainForm.Show()
    End Sub
End Class
