using DataAccess.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBaiTap
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            B9B1v3 b9B1V3 = new B9B1v3();
            b9B1V3.B9Bai1v3();
            //var mng = new ProductManager();
            //while (true)
            //{
            //    Console.WriteLine("Menu Bài Tập");
            //    Console.WriteLine("Chọn 1 - Thêm Sản Phẩm");
            //    Console.WriteLine("Chọn 2 - Hiển Thị Danh Sách Sản Phẩm");
            //    Console.WriteLine("Chọn 3 - Mua Sản Phẩm");
            //    Console.WriteLine("Chọn 4 - Thoát Chương Trình!");

            //    try
            //    {
            //        int menu = Convert.ToInt32(Console.ReadLine());

            //        switch (menu)
            //        {
            //            case 1:
            //                mng.AddProduct(); break;
            //            case 2:
            //                mng.DisplayProducts(); break;
            //            case 3:
            //                mng.BuyProduct(); break;
            //            case 4:
            //                Console.WriteLine("Đang thoát chương trình...");
            //                Environment.Exit(0);
            //                break;


            //            default:

            //                Console.WriteLine("Bạn nhập không đúng. Vui lòng nhập lại!"); break;


            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Lỗi không xác định" + ex);
            //        break;
            //    }
            //}
            Console.ReadKey();

        }
    }
}
