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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var mng = new ProductManager();
            while (true)
            {
                Console.WriteLine("Menu Bài Tập");
                Console.WriteLine("Chọn 1 - Thêm Sản Phẩm");
                Console.WriteLine("Chọn 2 - Hiển Thị Danh Sách Sản Phẩm");
                Console.WriteLine("Chọn 3 - Mua Sản Phẩm");
                Console.WriteLine("Chọn 4 - Thoát Chương Trình!");

                try
                {
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            mng.AddProduct(); break;
                        case 2:
                            mng.DisplayProducts(); break;
                        case 3:
                            mng.BuyProduct(); break;
                        case 4:
                            Console.WriteLine("Đang thoát chương trình...");
                            Environment.Exit(0);
                            break;


                        default:

                            Console.WriteLine("Bạn nhập không đúng. Vui lòng nhập lại!"); break;


                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Lỗi không xác định");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
