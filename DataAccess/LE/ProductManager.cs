using DataAccess.IT;
using DataAccess.OB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    string nhapTenSanPham;
                    while (true)
                    {
                        Console.WriteLine("Nhập Tên Sản Phẩm");
                        nhapTenSanPham = Console.ReadLine();

                        if (nhapTenSanPham == null || !CML.ValiDateProduct.KiemTraInputChu(nhapTenSanPham) || !CML.ValiDateProduct.CheckXSSInput(nhapTenSanPham))
                        {
                            rtdata.ReturnCode = -1;
                            rtdata.ReturnMsg = "Nhập Tên Bị Lỗi. Vui lòng nhập lại";
                            Console.WriteLine(rtdata.ReturnMsg);
                        }
                        else
                        {
                            break; // Thoát vòng lặp khi tên sản phẩm hợp lệ
                        }
                    }

                    Console.WriteLine("Nhập Giá Sản Phẩm");
                    string inputGia = Console.ReadLine();
                    decimal nhapGiaSanPham;
                    while (!decimal.TryParse(inputGia, out nhapGiaSanPham))
                    {
                        rtdata.ReturnCode = -2;
                        rtdata.ReturnMsg = "Giá Nhập Vào Không Đúng! Vui Lòng Nhập Lại Giá Sản Phẩm";
                        Console.WriteLine(rtdata.ReturnMsg);
                        inputGia = Console.ReadLine();
                    }

                    Console.WriteLine("Nhập Số Lượng Sản Phẩm");
                    string inputSoL = Console.ReadLine();
                    int soLuongSanPham;
                    while (!int.TryParse(inputSoL, out soLuongSanPham))
                    {
                        rtdata.ReturnCode = -3;
                        rtdata.ReturnMsg = "Vui lòng nhập số vào";
                        Console.WriteLine(rtdata.ReturnMsg);
                        inputSoL = Console.ReadLine();
                    }

                    products.Add(new Product(nextProductId, nhapTenSanPham, nhapGiaSanPham, soLuongSanPham));
                    nextProductId++;
                    Console.WriteLine("Bạn Có Muốn Nhập Thêm Sản Phẩm Không. Nếu Có (Nhấn 1). Nếu không (Nhấn Enter)");
                    if (!int.TryParse(Console.ReadLine(), out int nhapNuaKhong) || nhapNuaKhong != 1)
                    {
                        break;
                    }
                }
                rtdata.ReturnCode = 0;
                rtdata.ReturnMsg = "Thêm sản phẩm thành công";
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
            Console.WriteLine("(Nhấn 1)Mua Hàng Theo ID/ (Nhấn Enter) Mua Hàng Theo Tên");
            int chonMua = Convert.ToInt32(Console.ReadLine());
            if (chonMua == 1) {
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
                else
                if (soLuongMua > product.SoLuongProduct)
                {
                    rtdata.ReturnCode = -3;
                    rtdata.ReturnMsg = "Số Lượng Sản Phẩm Không Đủ";
                    return rtdata;
                } else
                if (soLuongMua <= 5 && soLuongMua > 0)
                {
                    decimal donThanhToan = product.GiaSauGiamGia * soLuongMua;
                    decimal donChietKhau = (donThanhToan * 5) / 100;
                    decimal tongThanhToan = donThanhToan - donChietKhau;
                    Console.WriteLine($"Đơn Hàng");
                    Console.WriteLine($"TÊN :{product.TenProduct}| Giá : {product.GiaProduct}|Số Lượng :{soLuongMua}|Đơn Giá:{donThanhToan}|Thành Tiền : {donThanhToan}| Chiết Khấu :0.");
                }
                else
                    if (soLuongMua > 5)
                {
                    decimal donThanhToan = product.GiaSauGiamGia * soLuongMua;
                    decimal donChietKhau = (donThanhToan * 5) / 100;
                    decimal tongThanhToan = donThanhToan - donChietKhau;
                    Console.WriteLine($"Đơn Hàng");
                    Console.WriteLine($"TÊN :{product.TenProduct}| Giá : {product.GiaProduct}|Số Lượng :{soLuongMua}|Đơn Giá:{donThanhToan}|Thành Tiền : {tongThanhToan}| Chiết Khấu :{donChietKhau}.");
                }
            }
            else
            {

                Console.WriteLine("Vui lòng nhập ID của sản phẩm bạn muốn mua:");
                string nhapTenTimKiem = Console.ReadLine();


                Console.WriteLine("Nhập số lượng sản phẩm bạn muốn mua:");
                int soLuongMua;
                while (!int.TryParse(Console.ReadLine(), out soLuongMua) || soLuongMua <= 0)
                {
                    rtdata.ReturnCode = -4;
                    rtdata.ReturnMsg = "Số lượng không hợp lệ, vui lòng nhập lại:";
                    Console.WriteLine(rtdata.ReturnMsg);
                }
                Product tenTimKiem = timKiemProduct(nhapTenTimKiem);
                if (tenTimKiem == null)
                {
                    rtdata.ReturnCode = -1;
                    rtdata.ReturnMsg = "Sản Phẩm Không Tồn Tại";
                    Console.WriteLine(rtdata.ReturnMsg);
                }
                else
                    if (soLuongMua > tenTimKiem.SoLuongProduct)
                {
                    rtdata.ReturnCode = -3;
                    rtdata.ReturnMsg = "Số Lượng Sản Phẩm Không Đủ";
                    Console.WriteLine(rtdata.ReturnMsg);
                }
                else
                    if (soLuongMua <= 5 && soLuongMua > 0)
                {
                    decimal donThanhToan = tenTimKiem.GiaSauGiamGia * soLuongMua;
                    decimal donChietKhau = (donThanhToan * 5) / 100;
                    decimal tongThanhToan = donThanhToan - donChietKhau;
                    Console.WriteLine($"Đơn Hàng");
                    Console.WriteLine($"TÊN :{tenTimKiem.TenProduct}| Giá : {tenTimKiem.GiaProduct}|Số Lượng :{soLuongMua}|Đơn Giá:{donThanhToan}|Thành Tiền : {donThanhToan}| Chiết Khấu :0.");
                }
                else
                        if (soLuongMua > 5)
                {
                    decimal donThanhToan = tenTimKiem.GiaSauGiamGia * soLuongMua;
                    decimal donChietKhau = (donThanhToan * 5) / 100;
                    decimal tongThanhToan = donThanhToan - donChietKhau;
                    Console.WriteLine($"Đơn Hàng");
                    Console.WriteLine($"TÊN :{tenTimKiem.TenProduct}| Giá : {tenTimKiem.GiaProduct}|Số Lượng :{soLuongMua}|Đơn Giá:{donThanhToan}|Thành Tiền : {tongThanhToan}| Chiết Khấu :{donChietKhau}.");
                }
            }



            rtdata.ReturnCode = 0;
            rtdata.ReturnMsg = "Mua Hàng Thành Công";
            return rtdata;
        }

        public void xapXepProduc()
        {
            products.Sort((p1, p2) => p2.LoaiGiamGia.CompareTo(p1.LoaiGiamGia));
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.IDProduct}, Tên: {product.TenProduct}, Giá: {product.GiaProduct}, Số Lượng: {product.SoLuongProduct}, Giảm Giá : {product.LoaiGiamGia}");
            }
        }
        public Product timKiemProduct(string name)
        {
            return products.FirstOrDefault(s => s.TenProduct.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
