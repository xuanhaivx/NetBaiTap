using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OB
{
    public class DangKyHoc :Student
    {
        public DateTime ThoiGianDangKy {  get; set; }
        public decimal HocPhiChietKhau { get; set; }
        public DangKyHoc(string tenHocSinh,DateTime ngaySinhHocSinh,DateTime thoiGianDangKy, string tenKhoaHoc) :base(tenHocSinh,ngaySinhHocSinh,tenKhoaHoc)
        {
            ThoiGianDangKy = thoiGianDangKy;
            HocPhiChietKhau = tinhChietKhauHocPhi();
        }
        public override string ToString()
        {
            return $"Tên : {TenHocSinh}| Ngày Sinh : {NgaySinhHocSinh.ToString("dd/MM/yyyy")}|Ngày Đăng Ký : {ThoiGianDangKy.ToString("dd/MM/yyyy")}|Học Phí : {HocPhiKhoaHoc.ToString("N2")}| Học Phí Sau Chiết Khấu : {HocPhiChietKhau.ToString("N2")}";
        }
        public decimal tinhChietKhauHocPhi()

        {
            TimeSpan cachNgayKhaiGiang = NgayKhaiGiang - ThoiGianDangKy;
            if (cachNgayKhaiGiang.TotalDays > 10 && cachNgayKhaiGiang.TotalDays < 30)
            {
                return HocPhiKhoaHoc * (1m - 0.1m);
            }
            else if (cachNgayKhaiGiang.TotalDays > 30)
            {
                return HocPhiKhoaHoc * (1m - 0.15m);

            }

            return HocPhiKhoaHoc;
        }
    }
}
