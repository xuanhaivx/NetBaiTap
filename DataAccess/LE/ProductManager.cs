using DataAccess.IT;
using DataAccess.OB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.LE
{
    public class ProductManager : IProductMng
    {
        private List<Product> products = new List<Product>();
        private int nextProductId = 1;
        public ReturnData AddProduct()
        {
            ReturnData rtdata = new ReturnData();

            try
            {
                while (true)
                {
                    Console.WriteLine("Nhập Tên Sản Phẩm");
                    string nhapTenSanPham = Console.ReadLine();
                    if (nhapTenSanPham == null || !CML.ValiDateProduct.KiemTraInputChu(nhapTenSanPham)|| !CML.ValiDateProduct.CheckXSSInput(nhapTenSanPham))
                    {
                        rtdata.ReturnCode = -1;
                        rtdata.ReturnMsg = "Nhập Tên Bị Lỗi. Vui lòng nhập lại";
                        return rtdata;
                    }
                    Console.WriteLine("Nhập Giá Sản Phẩm");
                    string inputGia = Console.ReadLine();
                    decimal nhapGiaSanPham;

                    if (!decimal.TryParse(inputGia, out nhapGiaSanPham))
                    {
                        rtdata.ReturnCode = -2;
                        rtdata.ReturnMsg = "Giá Nhập Vào Không Đúng! Vui Lòng Nhập Lại Giá Sản Phẩm";
                        return rtdata;

                    }
                    Console.WriteLine("Nhập Số Lương Sản Phẩm");
                    string inputSoL = Console.ReadLine();
                    int soLuongSanPham;
                    if (!int.TryParse(inputSoL, out soLuongSanPham))
                    {
                        rtdata.ReturnCode = -3;
                        rtdata.ReturnMsg = "Vui lòng nhập số vào";
                        return rtdata;

                    }
                    products.Add(new Product(nextProductId,nhapTenSanPham, nhapGiaSanPham, soLuongSanPham));
                    nextProductId++;
                    Console.WriteLine("Bạn Có Muốn Nhập Thêm Sản Phẩm Không. Nếu Có (Nhấn 1). Nếu không (Nhấn Enter)");
                    if (!int.TryParse(Console.ReadLine(), out int nhapNuaKhong) || nhapNuaKhong != 1)
                    {
                        break;
                    }
                }
                rtdata.ReturnCode = 0;
                rtdata.ReturnMsg = "Thêm sản phẩm thành công";
                

            }
            catch (Exception)
            {

                rtdata.ReturnCode = -99;
                rtdata.ReturnMsg = "Lỗi không xác định";
                
            }
            return rtdata;
        }
        public void DisplayProducts()
        {
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public ReturnData BuyProduct()
        {
            ReturnData rtdata = new ReturnData();
            DisplayProducts();
            
            Console.WriteLine("Vui lòng nhập ID của sản phẩm bạn muốn mua:");
            int productId;
            while (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("ID không đúng, vui lòng nhập lại:");
            }

            Console.WriteLine("Nhập số lượng sản phẩm bạn muốn mua:");
            int soLuongMua;
            while (!int.TryParse(Console.ReadLine(), out soLuongMua) || soLuongMua <= 0)
            {
                Console.WriteLine("Số lượng không hợp lệ, vui lòng nhập lại:");
            }

            var product = products.FirstOrDefault(p => p.IDProduct == productId);
            if (product == null)
            {
                rtdata.ReturnCode = -1;
                rtdata.ReturnMsg = "Sản Phẩm Không Tồn Tại";
                return rtdata;
            }
            if (soLuongMua <= 0)
            {
                rtdata.ReturnCode = -2;
                rtdata.ReturnMsg = "Số lượng mua phải lớn hơn 0." ;
                return rtdata;
            }
            if (soLuongMua>product.SoLuongProduct)
            {
                rtdata.ReturnCode = -3;
                rtdata.ReturnMsg = "Số Lượng Sản Phẩm Không Đủ";
                return rtdata;
            }
            if (soLuongMua<=5&& soLuongMua>0)
            {
                decimal tongThanhToan = product.GiaSauGiamGia * soLuongMua;
                Console.WriteLine($"Bạn đã mua {soLuongMua} {product.TenProduct} với tổng giá là: {tongThanhToan}.");
            }
            if (soLuongMua>5)
            {
                decimal tongThanhToan = product.GiaSauGiamGia * soLuongMua - (product.GiaSauGiamGia * soLuongMua*5)/100;
                Console.WriteLine($"Bạn đã mua {soLuongMua} {product.TenProduct} với tổng giá là: {tongThanhToan}.");
            }
            
            

            rtdata.ReturnCode = 0;
            rtdata.ReturnMsg = "Mua Hàng Thành Công";
            return rtdata;
        }

        
        
    

       
    }
}
