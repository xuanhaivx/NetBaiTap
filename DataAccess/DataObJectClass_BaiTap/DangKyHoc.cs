using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OB
{
    public class DangKyHoc
    {
        public Student Student { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
        public decimal HocPhiChietKhau { get; set; }

        public DangKyHoc(Student student, KhoaHoc khoaHoc, DateTime thoiGianDangKy)
        {
            Student = student;
            KhoaHoc = khoaHoc;
            ThoiGianDangKy = thoiGianDangKy;
            HocPhiChietKhau = tinhChietKhauHocPhi();
        }

        public decimal tinhChietKhauHocPhi()
        {
            TimeSpan cachNgayKhaiGiang = KhoaHoc.NgayKhaiGiang - ThoiGianDangKy;
            if (cachNgayKhaiGiang.TotalDays > 10 && cachNgayKhaiGiang.TotalDays < 30)
            {
                return KhoaHoc.HocPhiKhoaHoc * (1m - 0.1m);
            }
            else if (cachNgayKhaiGiang.TotalDays > 30)
            {
                return KhoaHoc.HocPhiKhoaHoc * (1m - 0.15m);
            }
            return KhoaHoc.HocPhiKhoaHoc;
        }

        public override string ToString()
        {
            return $"Tên: {Student.TenHocSinh}| Ngày Sinh: {Student.NgaySinhHocSinh.ToString("dd/MM/yyyy")}| Ngày Đăng Ký: {ThoiGianDangKy.ToString("dd/MM/yyyy")}| Học Phí: {KhoaHoc.HocPhiKhoaHoc.ToString("N2")}| Học Phí Sau Chiết Khấu: {HocPhiChietKhau.ToString("N2")}";
        }
    }
}
