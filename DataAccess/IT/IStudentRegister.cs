using DataAccess.OB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IT
{
    public interface IStudentRegister
    {
        ReturnData AddKhoaHoc();
        ReturnData DangKyKhoaHoc();
    }
}
