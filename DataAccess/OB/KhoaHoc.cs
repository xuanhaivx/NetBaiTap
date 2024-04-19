using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OB
{
    public class KhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public string MotaKhoaHoc { get; set; }
        public decimal HocPhiKhoaHoc { get; set; }
        public DateTime NgayKhaiGiang { get; set; }

        public KhoaHoc(string tenKhoaHoc,string motaKhoaHoc,decimal hocPhiKhoaHoc,DateTime ngayKhaiGiang) 
        { 
            TenKhoaHoc = tenKhoaHoc;
            MotaKhoaHoc= motaKhoaHoc;
            HocPhiKhoaHoc = hocPhiKhoaHoc;
            NgayKhaiGiang = ngayKhaiGiang;
        }
        public KhoaHoc(string tenKhoaHoc) 
        { 
            TenKhoaHoc = tenKhoaHoc;
        }

        public override string ToString()
        {
            return $"Ten Khóa Học : {TenKhoaHoc}\n +" +
                $" Mô Tả Khóa Học :{MotaKhoaHoc}\n +" +
                $"Học Phí :  {HocPhiKhoaHoc.ToString("N2")} \n +" +
                $"Ngày Khai Giảng: {NgayKhaiGiang.ToString("dd/MM/yyyy")} ";
        }

    }
}
