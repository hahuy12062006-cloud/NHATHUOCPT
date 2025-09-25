Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmBanHang
    Private currentMaBanHangToPrint As Integer = 0
    Private dtPrintHeaderBanHang As DataTable
    Private dtPrintDetailsBanHang As DataTable
    Private ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
    Private dtChiTietHoaDon As New DataTable()
    Private Sub BanHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TẠO KHUÔN CHO dtChiTietHoaDon
        dtChiTietHoaDon.Columns.Add("MaThuoc", GetType(Integer))
        dtChiTietHoaDon.Columns.Add("TenThuoc", GetType(String))
        dtChiTietHoaDon.Columns.Add("SoLuongBan", GetType(Integer))
        dtChiTietHoaDon.Columns.Add("DonGiaBan", GetType(Decimal))
        dtChiTietHoaDon.Columns.Add("ThanhTien", GetType(Decimal))

        ' GÁN DataTable ĐỂ HIỂN THỊ DATA TRÊN DGV
        dgvChiTietHoaDon.DataSource = dtChiTietHoaDon
        dgvChiTietHoaDon.Columns("MaThuoc").Visible = False
        dgvChiTietHoaDon.Columns("TenThuoc").HeaderText = "Tên Thuốc"
        dgvChiTietHoaDon.Columns("SoLuongBan").HeaderText = "Số Lượng Bán"
        dgvChiTietHoaDon.Columns("DonGiaBan").HeaderText = "Đơn Giá Bán"
        dgvChiTietHoaDon.Columns("ThanhTien").HeaderText = "Thành Tiền"

        ' Tải dữ liệu khách hàng vào ComboBox
        LoadKhachHangToComboBox()

        CapNhatTongTien()

        If Not IsNothing(btnIN) Then
            btnIN.Enabled = False
        End If
        currentMaBanHangToPrint = 0
    End Sub

    Private Sub LoadKhachHangToComboBox()
        Using con As New SqlConnection(ConString)
            Try
                con.Open()
                Dim query As String = "SELECT MaKhachHang, TenKhachHang FROM KhachHang"
                Dim da As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                da.Fill(dt)

                If Not IsNothing(cboMaKhachHang) Then
                    cboMaKhachHang.DataSource = dt
                    cboMaKhachHang.DisplayMember = "TenKhachHang"
                    cboMaKhachHang.ValueMember = "MaKhachHang"
                    cboMaKhachHang.SelectedIndex = -1 ' Không chọn mặc định
                End If

            Catch ex As Exception
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub cboMaKhachHang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMaKhachHang.SelectedIndexChanged
        If cboMaKhachHang.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboMaKhachHang.SelectedValue.ToString()) Then
            txtTenKhachHang.Text = cboMaKhachHang.Text
        Else
            txtTenKhachHang.Text = ""
        End If
    End Sub

    Private Sub CapNhatTongTien()
        Dim tong As Decimal = 0
        For Each row As DataRow In dtChiTietHoaDon.Rows
            tong += CDec(row("ThanhTien"))
        Next
        lblTongTien.Text = $"Tổng tiền: {tong:N0} VNĐ"
    End Sub

    ' XÓA DATA TRÊN CÁC Ô ĐÃ NHẬP
    Private Sub ClearCurrentCartAndInputs()
        dtChiTietHoaDon.Clear()
        CapNhatTongTien()
        If Not IsNothing(txtTenKhachHang) Then
            txtTenKhachHang.Clear()
        End If
        If Not IsNothing(txtSoLuong) Then
            txtSoLuong.Clear()
        End If
        If Not IsNothing(cboMaKhachHang) Then
            cboMaKhachHang.SelectedIndex = -1
        End If
    End Sub

    ' RESET FORM
    Private Sub ResetFormForNewSale()
        ClearCurrentCartAndInputs()
        If Not IsNothing(btnIN) Then
            btnIN.Enabled = False
        End If
        currentMaBanHangToPrint = 0
    End Sub

    ' THÊM THUỐC
    Public Sub AddSelectedDrugToCart(maThuoc As Integer, tenThuoc As String, donGiaBan As Decimal, soLuongTonKho As Integer)
        ' CHECK THUỐC ĐÃ CÓ CHƯA
        Dim existingRow As DataRow = dtChiTietHoaDon.Select($"MaThuoc = {maThuoc}").FirstOrDefault()
        If existingRow Is Nothing Then
            If soLuongTonKho >= 1 Then
                Dim newRow As DataRow = dtChiTietHoaDon.NewRow()
                newRow("MaThuoc") = maThuoc
                newRow("TenThuoc") = tenThuoc
                newRow("SoLuongBan") = 1
                newRow("DonGiaBan") = donGiaBan
                newRow("ThanhTien") = 1 * donGiaBan
                dtChiTietHoaDon.Rows.Add(newRow)
            Else
                MessageBox.Show("Sản phẩm đã hết hàng tồn kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            ' TĂNG SL KHI THÊM THUỐC
            Dim oldSoLuongBan As Integer = CInt(existingRow("SoLuongBan"))
            Dim newTotalSoLuongBan As Integer = oldSoLuongBan + 1
            ' CHECK TỒN KHI TĂNG
            If newTotalSoLuongBan <= soLuongTonKho Then
                existingRow("SoLuongBan") = newTotalSoLuongBan
                existingRow("ThanhTien") = newTotalSoLuongBan * donGiaBan
            Else
                MessageBox.Show($"Tổng số lượng bán của thuốc {tenThuoc} đã vượt quá số lượng tồn kho hiện có ({soLuongTonKho}).", "Không đủ hàng tồn", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        CapNhatTongTien()
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        Dim frmTimThuoc As New frmTimThuoc()
        AddHandler frmTimThuoc.DrugSelected, AddressOf frmTimThuoc_DrugSelected
        frmTimThuoc.ShowDialog()
    End Sub

    Private Sub frmTimThuoc_DrugSelected(ByVal maThuoc As Integer, ByVal tenThuoc As String, ByVal donGiaBan As Decimal, ByVal soLuongTonKho As Integer)
        AddSelectedDrugToCart(maThuoc, tenThuoc, donGiaBan, soLuongTonKho)
    End Sub

    Private Sub txtSoLuong_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSoLuong.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If dgvChiTietHoaDon.SelectedRows.Count = 0 Then
                MessageBox.Show("Vui lòng chọn một dòng thuốc để cập nhật số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim soLuongMoi As Integer
            If Not Integer.TryParse(txtSoLuong.Text, soLuongMoi) OrElse soLuongMoi <= 0 Then
                MessageBox.Show("Số lượng nhập không hợp lệ. Vui lòng nhập một số nguyên dương.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim selectedRow As DataGridViewRow = dgvChiTietHoaDon.SelectedRows(0)
            Dim maThuoc As Integer = CInt(selectedRow.Cells("MaThuoc").Value)
            Dim soLuongTonKho As Integer

            Using con As New SqlConnection(ConString)
                Try
                    con.Open()
                    Dim query As String = "SELECT SoLuongTonKho FROM Thuoc WHERE MaThuoc = @MaThuoc"
                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@MaThuoc", maThuoc)
                        soLuongTonKho = CInt(cmd.ExecuteScalar())
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi lấy số lượng tồn kho: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using

            If soLuongMoi > soLuongTonKho Then
                Dim tenThuoc As String = selectedRow.Cells("TenThuoc").Value.ToString()
                MessageBox.Show($"Số lượng muốn bán ({soLuongMoi}) vượt quá số lượng tồn kho hiện có ({soLuongTonKho}).", "Không đủ hàng tồn", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' CẬP NHẬT SL VÀ TỔNG TIỀN
            Dim rowToUpdate As DataRow = DirectCast(selectedRow.DataBoundItem, DataRowView).Row
            Dim donGiaBan As Decimal = CDec(rowToUpdate("DonGiaBan"))
            rowToUpdate("SoLuongBan") = soLuongMoi
            rowToUpdate("ThanhTien") = soLuongMoi * donGiaBan
            CapNhatTongTien()
            MessageBox.Show("Đã cập nhật số lượng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvChiTietHoaDon_SelectionChanged(sender As Object, e As EventArgs) Handles dgvChiTietHoaDon.SelectionChanged
        If dgvChiTietHoaDon.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvChiTietHoaDon.SelectedRows(0)
            txtSoLuong.Text = selectedRow.Cells("SoLuongBan").Value.ToString()
        End If
    End Sub

    Private Sub btnHoanThanh_Click(sender As Object, e As EventArgs) Handles btnHoanThanh.Click
        If dtChiTietHoaDon.Rows.Count = 0 Then
            MessageBox.Show("Danh sách hóa đơn trống. Vui lòng thêm thuốc vào trước khi hoàn tất.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim tenKhachHangNhap As String = If(Not IsNothing(txtTenKhachHang), txtTenKhachHang.Text.Trim(), "")
        Dim maKhachHang As Integer
        Try
            maKhachHang = GetOrCreateKhachHangId(tenKhachHangNhap)
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xử lý thông tin khách hàng: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If MessageBox.Show("Bạn có chắc chắn muốn hoàn tất hóa đơn này?", "Xác nhận Hoàn Tất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using con As New SqlConnection(ConString)
                con.Open()
                Dim transaction As SqlTransaction = con.BeginTransaction()
                Dim salesID As Integer = 0

                Try
                    Dim tongTienBanString As String = lblTongTien.Text.Replace("Tổng tiền: ", "").Replace(" VNĐ", "").Replace(".", "").Trim()
                    Dim tongTienBan As Decimal
                    If Not Decimal.TryParse(tongTienBanString, NumberStyles.Number, CultureInfo.InvariantCulture, tongTienBan) Then
                        MessageBox.Show("Định dạng tổng tiền không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        transaction.Rollback()
                        Return
                    End If

                    Dim insertSalesQuery As String = "INSERT INTO BanHang (MaKhachHang, NgayBan, TongTien) OUTPUT INSERTED.MaBanHang VALUES (@MaKhachHang, @NgayBan, @TongTien)"
                    Using cmdSales As New SqlCommand(insertSalesQuery, con, transaction)
                        cmdSales.Parameters.AddWithValue("@MaKhachHang", maKhachHang)
                        cmdSales.Parameters.AddWithValue("@NgayBan", DateTime.Now)
                        cmdSales.Parameters.AddWithValue("@TongTien", tongTienBan)
                        salesID = CInt(cmdSales.ExecuteScalar())
                    End Using

                    For Each itemRow As DataRow In dtChiTietHoaDon.Rows
                        Dim maThuoc As Integer = CInt(itemRow("MaThuoc"))
                        Dim soLuongBan As Integer = CInt(itemRow("SoLuongBan"))
                        Dim donGiaBan As Decimal = CDec(itemRow("DonGiaBan"))

                        Dim insertSaleItemQuery As String = "INSERT INTO ChiTietBanHang (MaBanHang, MaThuoc, SoLuongBan, DonGiaBanTaiThoiDiem) VALUES (@MaBanHang, @MaThuoc, @SoLuongBan, @DonGiaBanTaiThoiDiem)"
                        Using cmdSaleItem As New SqlCommand(insertSaleItemQuery, con, transaction)
                            cmdSaleItem.Parameters.AddWithValue("@MaBanHang", salesID)
                            cmdSaleItem.Parameters.AddWithValue("@MaThuoc", maThuoc)
                            cmdSaleItem.Parameters.AddWithValue("@SoLuongBan", soLuongBan)
                            cmdSaleItem.Parameters.AddWithValue("@DonGiaBanTaiThoiDiem", donGiaBan)
                            cmdSaleItem.ExecuteNonQuery()
                        End Using

                        Dim updateStockQuery As String = "UPDATE Thuoc SET SoLuongTonKho = SoLuongTonKho - @SoLuongBan WHERE MaThuoc = @MaThuoc"
                        Using cmdUpdateStock As New SqlCommand(updateStockQuery, con, transaction)
                            cmdUpdateStock.Parameters.AddWithValue("@SoLuongBan", soLuongBan)
                            cmdUpdateStock.Parameters.AddWithValue("@MaThuoc", maThuoc)
                            cmdUpdateStock.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()
                    MessageBox.Show($"Hóa đơn {salesID} đã được hoàn tất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    currentMaBanHangToPrint = salesID
                    If Not IsNothing(btnIN) Then
                        btnIN.Enabled = True
                    End If

                    ClearCurrentCartAndInputs()
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Lỗi khi hoàn tất hóa đơn: " & ex.Message & vbCrLf & "Giao dịch đã được hủy bỏ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If MessageBox.Show("Bạn có muốn tạo hóa đơn mới và xóa trắng danh sách hiện tại?", "Xác nhận Tạo Mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ResetFormForNewSale()
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvChiTietHoaDon.SelectedRows.Count > 0 Then
            Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc đã chọn khỏi hóa đơn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmResult = DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvChiTietHoaDon.SelectedRows
                    If Not row.IsNewRow Then
                        Dim rowToRemove As DataRow = DirectCast(row.DataBoundItem, DataRowView).Row
                        dtChiTietHoaDon.Rows.Remove(rowToRemove)
                    End If
                Next
                CapNhatTongTien()
            End If
        Else
            MessageBox.Show("Vui lòng chọn một hoặc nhiều dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function GetOrCreateKhachHangId(tenKhachHang As String) As Integer
        If String.IsNullOrWhiteSpace(tenKhachHang) Then
            Return 1
        End If
        Using con As New SqlConnection(ConString)
            con.Open()
            Dim queryCheck As String = "SELECT MaKhachHang FROM KhachHang WHERE TenKhachHang = @TenKhachHang"
            Using cmdCheck As New SqlCommand(queryCheck, con)
                cmdCheck.Parameters.AddWithValue("@TenKhachHang", tenKhachHang)
                Dim result As Object = cmdCheck.ExecuteScalar()

                If result IsNot Nothing Then
                    Return CInt(result)
                Else
                    Dim queryInsert As String = "INSERT INTO KhachHang (TenKhachHang) OUTPUT INSERTED.MaKhachHang VALUES (@TenKhachHang)"
                    Using cmdInsert As New SqlCommand(queryInsert, con)
                        cmdInsert.Parameters.AddWithValue("@TenKhachHang", tenKhachHang)
                        Return CInt(cmdInsert.ExecuteScalar())
                    End Using
                End If
            End Using
        End Using
    End Function

    Private Function LoadSalesInvoiceData(maBanHang As Integer) As Boolean
        dtPrintHeaderBanHang = New DataTable()
        dtPrintDetailsBanHang = New DataTable()
        Using con As New SqlConnection(ConString)
            Try
                con.Open()

                Dim queryHeader As String = "SELECT BH.MaBanHang, BH.NgayBan, BH.TongTien, KH.TenKhachHang " &
                                             "FROM BanHang BH JOIN KhachHang KH ON BH.MaKhachHang = KH.MaKhachHang " &
                                             "WHERE BH.MaBanHang = @MaBanHang"
                Using cmdHeader As New SqlCommand(queryHeader, con)
                    cmdHeader.Parameters.AddWithValue("@MaBanHang", maBanHang)
                    Dim adapterHeader As New SqlDataAdapter(cmdHeader)
                    adapterHeader.Fill(dtPrintHeaderBanHang)
                End Using

                Dim queryDetails As String = "SELECT T.TenThuoc, CTBH.SoLuongBan, CTBH.DonGiaBanTaiThoiDiem, " &
                                             "(CTBH.SoLuongBan * CTBH.DonGiaBanTaiThoiDiem) AS ThanhTien " &
                                             "FROM ChiTietBanHang CTBH JOIN Thuoc T ON CTBH.MaThuoc = T.MaThuoc " &
                                             "WHERE CTBH.MaBanHang = @MaBanHang"
                Using cmdDetails As New SqlCommand(queryDetails, con)
                    cmdDetails.Parameters.AddWithValue("@MaBanHang", maBanHang)
                    Dim adapterDetails As New SqlDataAdapter(cmdDetails)
                    adapterDetails.Fill(dtPrintDetailsBanHang)
                End Using

                Return dtPrintHeaderBanHang.Rows.Count > 0
            Catch ex As Exception
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn bán hàng để in: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Sub PrintDocumentBanHang_PrintPage(sender As Object, e As PrintPageEventArgs)
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
        g.DrawString("Địa chỉ: 505 Minh Khai, phường Vĩnh Tuy, quận Hai Bà Trưng, thành phố Hà Nội", fontNormal, Brushes.Black, leftMargin, yPos)
        yPos += fontNormal.GetHeight(g) + 5
        g.DrawString("Điện thoại: 0987.654.321", fontNormal, Brushes.Black, leftMargin, yPos)
        yPos += fontNormal.GetHeight(g) + 30

        Dim titleString As String = "HÓA ĐƠN BÁN HÀNG"
        Dim titleSize As SizeF = g.MeasureString(titleString, fontTitle)
        g.DrawString(titleString, fontTitle, Brushes.Black, (e.PageBounds.Width / 2) - (titleSize.Width / 2), yPos)
        yPos += fontTitle.GetHeight(g) + 20

        If dtPrintHeaderBanHang.Rows.Count > 0 Then
            Dim headerRow As DataRow = dtPrintHeaderBanHang.Rows(0)
            g.DrawString($"Mã HĐ: {headerRow("MaBanHang")}", fontHeader, Brushes.Black, leftMargin, yPos)
            yPos += fontHeader.GetHeight(g) + 5
            g.DrawString($"Ngày bán: {CType(headerRow("NgayBan"), DateTime).ToString("dd/MM/yyyy HH:mm")}", fontHeader, Brushes.Black, leftMargin, yPos)
            yPos += fontHeader.GetHeight(g) + 5
            Dim tenKhachHang As String = If(Not IsDBNull(headerRow("TenKhachHang")), headerRow("TenKhachHang").ToString(), "Khách lẻ")
            g.DrawString($"Khách hàng: {tenKhachHang}", fontHeader, Brushes.Black, leftMargin, yPos)
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

        For Each row As DataRow In dtPrintDetailsBanHang.Rows
            g.DrawString(row("TenThuoc").ToString(), fontNormal, Brushes.Black, colTenThuocX, yPos)
            g.DrawString(row("SoLuongBan").ToString(), fontNormal, Brushes.Black, colSoLuongX, yPos)
            g.DrawString(CDec(row("DonGiaBanTaiThoiDiem")).ToString("N0"), fontNormal, Brushes.Black, colDonGiaX, yPos)
            g.DrawString(CDec(row("ThanhTien")).ToString("N0"), fontNormal, Brushes.Black, colThanhTienX, yPos)
            yPos += fontNormal.GetHeight(g) + 5
        Next

        yPos += 10
        g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos)
        yPos += 5

        If dtPrintHeaderBanHang.Rows.Count > 0 Then
            Dim tongTien As Decimal = CDec(dtPrintHeaderBanHang.Rows(0)("TongTien"))
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

    Private Sub btnIN_Click(sender As Object, e As EventArgs) Handles btnIN.Click
        If currentMaBanHangToPrint = 0 Then
            MessageBox.Show("Không có hóa đơn bán hàng nào để in. Vui lòng hoàn tất một đơn bán hàng trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not LoadSalesInvoiceData(currentMaBanHangToPrint) Then
            MessageBox.Show("Không thể tải dữ liệu hóa đơn bán hàng để in. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim printDoc As New PrintDocument()
        AddHandler printDoc.PrintPage, AddressOf Me.PrintDocumentBanHang_PrintPage

        Dim printPreviewDlg As New PrintPreviewDialog()
        printPreviewDlg.Document = printDoc
        Try
            printPreviewDlg.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi hiển thị bản xem trước hoặc khi in hóa đơn bán hàng: " & ex.Message, "Lỗi In", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
