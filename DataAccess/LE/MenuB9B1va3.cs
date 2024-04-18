using DataAccess.OB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.LE
{
    public class MenuB9B1va3
    {
        public ReturnData MenuB9Bai13()

        {
            ReturnData returnData = new ReturnData();
            ProductManager manager = new ProductManager();
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
                            manager.AddProduct();break;
                        case 2:
                            manager.DisplayProducts();break;
                            case 3:
                                manager.BuyProduct();break;
                            case 4:
                            Console.WriteLine("Đang thoát chương trình...");
                            Environment.Exit(0);
                            break;


                        default:
                            returnData.ReturnCode = -1;
                            returnData.ReturnMsg = "Bạn nhập không đúng. Vui lòng nhập lại!";
                            return returnData;
                            
                    }


                }
                catch (Exception)
                {

                    returnData.ReturnCode = -99;
                    returnData.ReturnMsg = "Lỗi không xác định";
                    return returnData;
                }
            }
        }
    }
}
