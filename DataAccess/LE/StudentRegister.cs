using DataAccess.IT;
using DataAccess.OB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.LE
{
    public class StudentRegister : IStudentRegister
    {
        private List<KhoaHoc> khoaHocs = new List<KhoaHoc>();
        private List<DangKyHoc> dangKyHocs = new List<DangKyHoc>();
        public ReturnData AddKhoaHoc()
        {
            ReturnData rtdata = new ReturnData();
            
            try
            {
                while (true)
                {
                    
                    
                        Console.WriteLine("Nhập Tên Khóa Học");
                    string nhapTenKhoaHoc;
                    do
                    {
                        nhapTenKhoaHoc = Console.ReadLine();

                        if (!CML.ValiDateProduct.KiemTraInputChuTrong(nhapTenKhoaHoc))
                        {
                            rtdata.ReturnCode = -1;
                            rtdata.ReturnMsg = "Nhập Tên Bị Lỗi. Vui lòng nhập lại";
                            Console.WriteLine(rtdata.ReturnMsg);
                        }
                    } while (!CML.ValiDateProduct.KiemTraInputChuTrong(nhapTenKhoaHoc));


                    Console.WriteLine("Mô Tả Khóa Học");
                    string motaKhoaHoc;
                    do
                    {
                        motaKhoaHoc = Console.ReadLine();
                        if (!CML.ValiDateProduct.KiemTraInputChuTrong(motaKhoaHoc))
                        {
                            rtdata.ReturnCode = -2;
                            rtdata.ReturnMsg = "Lỗi khi nhập mô tả của khóa học";
                            Console.WriteLine(rtdata.ReturnMsg);
                        
                        }
                    } while (!CML.ValiDateProduct.KiemTraInputChuTrong(motaKhoaHoc));
                    Console.WriteLine("Học Phí Khóa Học");
                    decimal nhapHocPhiKhoaHoc;
                    string hocPhiInput;
                    do
                    {
                        hocPhiInput = Console.ReadLine();
                        if (!CML.ValiDateProduct.CheckTienVNInput(hocPhiInput, out nhapHocPhiKhoaHoc))
                        {
                            rtdata.ReturnCode = -3;
                            rtdata.ReturnMsg = "Nhập Học Phí Vào Không Đúng! Vui Lòng Nhập Lại Học Phí";
                            Console.WriteLine(rtdata.ReturnMsg);
                        }

                    } while (!CML.ValiDateProduct.CheckTienVNInput(hocPhiInput, out nhapHocPhiKhoaHoc));
                    
                    Console.WriteLine("Nhập Ngày Khai Giảng (dd/MM/yyyy)");
                    DateTime ngayKhaiGiang;
                    string ngayKhaiGiangInput;
                    do
                    {
                        ngayKhaiGiangInput = Console.ReadLine();
                        if (!CML.ValiDateProduct.CheckDateTimeInput(ngayKhaiGiangInput, out ngayKhaiGiang))
                        {
                            Console.WriteLine("Ngày Khai Giảng Bị Lỗi. Vui Lòng Nhập Lại");
                        }
                        else if (ngayKhaiGiang < DateTime.Now)
                        {
                            Console.WriteLine("Bạn Đã Nhập Ngày Khai Giảng Ở Quá Khứ. Hãy Nhập Lại");
                        }

                    } while (!CML.ValiDateProduct.CheckDateTimeInput(ngayKhaiGiangInput, out ngayKhaiGiang) || ngayKhaiGiang < DateTime.Now);


                    khoaHocs.Add(new KhoaHoc(nhapTenKhoaHoc,motaKhoaHoc,nhapHocPhiKhoaHoc,ngayKhaiGiang));
                    
                    Console.WriteLine("Bạn Có Muốn Nhập Thêm Khóa Học Không. Nếu Có (Nhấn 1). Nếu không (Nhấn Enter)");
                    if (!int.TryParse(Console.ReadLine(), out int nhapNuaKhong) || nhapNuaKhong != 1)
                    {
                        break;
                    }
                }
                rtdata.ReturnCode = 0;
                rtdata.ReturnMsg = "Thêm Khóa Học thành công";
                Console.WriteLine(rtdata.ReturnMsg);
            }
            catch (Exception)
            {
                rtdata.ReturnCode = -99;
                rtdata.ReturnMsg = "Lỗi không xác định";
                Console.WriteLine(rtdata.ReturnMsg);
            }
            return rtdata;
        }

        public ReturnData DangKyKhoaHoc()
        {
            ReturnData rtdata = new ReturnData();
            

            try
            {
                while (true)
                {


                    Console.WriteLine("Nhập Tên Học Sinh");
                    string nhapTenHocSinh;

                    do
                    {
                        nhapTenHocSinh = Console.ReadLine();
                        if (!CML.ValiDateProduct.KiemTraInputChuTrong(nhapTenHocSinh))
                        {
                            rtdata.ReturnCode = -1;
                            rtdata.ReturnMsg = "Nhập Tên Bị Lỗi. Vui lòng nhập lại";
                            Console.WriteLine(rtdata.ReturnMsg);
                        }
                    } while (!CML.ValiDateProduct.KiemTraInputChuTrong(nhapTenHocSinh));
                    Console.WriteLine("Nhập Ngày Ngày Sinh Học Sinh (Ngày/ Tháng/ năm)");
                    string inputNgaySinh;
                    DateTime ngayKhaiSinh;

                    do
                    {
                        inputNgaySinh = Console.ReadLine();

                        if (!CML.ValiDateProduct.CheckDateTimeInput(inputNgaySinh, out ngayKhaiSinh))
                        {
                            Console.WriteLine("Ngày Khai Giảng Bị Lỗi Định Dạng (Ngày/ Tháng/ năm). Vui Lòng Nhập Lại");
                        }
                        else if (ngayKhaiSinh > DateTime.Now)
                        {

                            Console.WriteLine("Bạn Đã Nhập Ngày Khai Sinh Ở Tương Lai. Hãy Nhập Lại");
                        }

                    } while (!CML.ValiDateProduct.CheckDateTimeInput(inputNgaySinh, out ngayKhaiSinh)|| ngayKhaiSinh > DateTime.Now);

                    Student hocSinhNew = new Student(nhapTenHocSinh, ngayKhaiSinh);
                    // Hiển thị danh sách khóa học trước khi nhập tên khóa học muốn đăng ký
                    DanhSachKhoaHoc();
                    Console.WriteLine("Nhập Tên Khóa Học Muốn Đăng Ký");
                    string nhapTenKhoaHoc;
                    KhoaHoc tenTimKiemKhoaHoc;
                    do {
                        nhapTenKhoaHoc = Console.ReadLine();
                        tenTimKiemKhoaHoc = timKiemKhoaHoc(nhapTenKhoaHoc);
                        if (tenTimKiemKhoaHoc == null)
                        {
                            rtdata.ReturnCode = -2;
                            rtdata.ReturnMsg = "Tên Khóa Học Không Chính Xác. Hãy Nhập lại";
                            Console.WriteLine(rtdata.ReturnMsg);
                        }
                    } while (tenTimKiemKhoaHoc == null);
                    
                    dangKyHocs.Add(new DangKyHoc(hocSinhNew, tenTimKiemKhoaHoc, DateTime.Now));

                    Console.WriteLine("Bạn Có Muốn Đăng Ký Thêm Khóa Học Không. Nếu Có (Nhấn 1). Nếu không (Nhấn Enter)");
                    if (!int.TryParse(Console.ReadLine(), out int nhapNuaKhong) || nhapNuaKhong != 1)
                    {
                        break;
                    }
                }
                rtdata.ReturnCode = 0;
                rtdata.ReturnMsg = "Thêm Khóa Học thành công";
                Console.WriteLine(rtdata.ReturnMsg);
            }
            catch (Exception ex)
            {
                rtdata.ReturnCode = -99;
                rtdata.ReturnMsg = "Lỗi không xác định" +ex;
                Console.WriteLine(rtdata.ReturnMsg);
            }
            return rtdata;
        }
        public KhoaHoc timKiemKhoaHoc(string name)
        {
            return khoaHocs.FirstOrDefault(s => s.TenKhoaHoc.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public void DanhSachDKKhoaHoc()
        {
            Console.WriteLine("Danh sách Học Sinh Đăng Ký Khóa Học:");
            dangKyHocs.Sort((p1, p2) => p2.HocPhiChietKhau.CompareTo(p1.HocPhiChietKhau));
            foreach (var khoahoc in dangKyHocs)
            {
                Console.WriteLine(khoahoc);
            }
        }
        public void DanhSachKhoaHoc()
        {
            Console.WriteLine("Danh sách Khóa Học:");
            foreach (var khoahoc in khoaHocs)
            {
                Console.WriteLine(khoahoc);
            }
        }
    }
}
