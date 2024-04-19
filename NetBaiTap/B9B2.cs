using DataAccess.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBaiTap
{
    internal class B9B2
    {
        public void B9Bai2()
        {
            var sdr = new StudentRegister();
            while (true)
            {
                Console.WriteLine("Menu Bài Tập");
                Console.WriteLine("Chọn 1 - Thêm Khóa Học");
                Console.WriteLine("Chọn 2 - Đăng Ký Khóa Học");
                Console.WriteLine("Chọn 3 - Danh Sách Khóa Học");
                Console.WriteLine("Chọn 4 - Danh Sách Học Viên Đăng Ký");
                Console.WriteLine("Chọn 5 - Thoát Chương Trình!");

                try
                {
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            sdr.AddKhoaHoc(); break;
                        case 2:
                            sdr.DangKyKhoaHoc(); break;
                        case 3:
                            sdr.DanhSachKhoaHoc(); break;
                        case 4:
                            sdr.DanhSachDKKhoaHoc(); break;
                        case 5:
                            Console.WriteLine("Đang thoát chương trình...");
                            Environment.Exit(0);
                            break;


                        default:

                            Console.WriteLine("Bạn nhập không đúng. Vui lòng nhập lại!"); break;


                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi không xác định" + ex);
                    break;
                }
            }
        }
    }
}
