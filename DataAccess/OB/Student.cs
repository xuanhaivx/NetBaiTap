﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OB
{
    public class Student
    {
        public string TenHocSinh { get; set; }
        public DateTime NgaySinhHocSinh { get; set; }

        public Student(string tenHocSinh, DateTime ngaySinhHocSinh)
        {
            TenHocSinh = tenHocSinh;
            NgaySinhHocSinh = ngaySinhHocSinh;
        }
    }

}
