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
            int yourAge = 35;

            Console.Write(yourAge++ + "-" + (++yourAge * 2));

            Console.WriteLine(12 + 08 + "BE_2204_EXAMP" + 44 + 02);

            //B9B1v3 b9B1V3 = new B9B1v3();
            //b9B1V3.B9Bai1v3();
            B9B2 b9B2 = new B9B2();
            b9B2.B9Bai2();
            
            
            
            
            
            
            
            Console.ReadKey();

        }
    }
}
