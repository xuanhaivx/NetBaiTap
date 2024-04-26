using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CML
{
    public class ValiDate_BaiTap
    {
        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool KiemTraInputChuTrong(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            if (CheckXSSInput(input) == false)
            {
                return false;
            }
            return true;
        }
        public static bool KiemTraInputChuToiDa(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                return false;
            }
            
            return true;
        }
        public static bool KiemTraInputChuKoSo(string input)
        {
            if (!input.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }
        public static bool CheckEMail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return false;
            }

            return true;
        }
        public static bool CheckIntInput(string input, out int result)
        {
            // Sử dụng int.TryParse để kiểm tra đầu vào có phải là số nguyên hợp lệ
            bool isValid = int.TryParse(input, out result);

            // Thêm bất kỳ kiểm tra nâng cao nào ở đây (ví dụ: kiểm tra giới hạn)
            // Ví dụ: kiểm tra số nguyên không được âm
            if (isValid)
            {
                if (result < 0)
                {
                    Console.WriteLine("Lỗi: Số nguyên không được âm.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Lỗi: Đầu vào không phải là số nguyên hợp lệ.");
                return false;
            }

            return true;
        }
        public static bool CheckDateTimeInput(string input, out DateTime dateValue)
        {
            // Định dạng ngày tháng cụ thể
            string dateFormat = "dd/MM/yyyy";
            // CultureInfo.InvariantCulture để đảm bảo rằng phân tích cú pháp không phụ thuộc vào cài đặt của máy
            bool isValid = DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);

            if (!isValid)
            {
                return false;
            }


            return true;
        }
        public static bool CheckTienVNInput(string input, out decimal amount)
        {
            // Sử dụng NumberStyles để cho phép dấu thập phân và các nhóm số
            var styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");  // Giả sử định dạng tiền tệ theo chuẩn Mỹ

            bool isValid = decimal.TryParse(input, styles, culture, out amount);

            if (!isValid)
            {
                return false;
            }
            

            return true;
        }


    }
}
