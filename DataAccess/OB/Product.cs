using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.OB
{
    public class Product
    {
        
        public int IDProduct {  get; set; }
        public string TenProduct {  get; set; }
        
        public decimal GiaProduct { get; set; }
        public int SoLuongProduct { get; set; }
        public int LoaiGiamGia {  get; private set; }
        
        public decimal GiaSauGiamGia { get; private set; }
        public Product(int idProduct, string tenProduct, decimal giaProduct, int soLuongProduct)
        {
            IDProduct = idProduct;
            TenProduct = tenProduct;
            GiaProduct = giaProduct;
            SoLuongProduct = soLuongProduct;
            LoaiGiamGia = TinhLoaiGiamGia();
            GiaSauGiamGia = CalculateDiscount();
        }

        

        private decimal CalculateDiscount()
        {
            return GiaProduct - LoaiGiamGia;
        }
        private int TinhLoaiGiamGia()
        {
            if (GiaProduct>=10000 &&GiaProduct<100000)
            {
                Console.WriteLine("Sản Phẩm Được Giảm Giá 1K. Nếu mua cùng lúc 5 Sản phẩm được giảm thêm 5%");
                return 1000;

            }else if (GiaProduct>=100000)
            {
                Console.WriteLine("Sản Phẩm Được Giảm Giá 10K. Nếu mua cùng lúc 5 Sản phẩm được giảm thêm 5%");
                return 10000;
            }else
            {
                Console.WriteLine("Sản Phẩm Không Được Giảm Giá");
                return 0;
            }    
        }
       

    }
}
