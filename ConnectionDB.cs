using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    internal class ConnectionDB
    {
        public string GetConnection()
        {
            string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\Desktop\backup\BloodBank\bin\Debug\BloodBank.accdb";
            return con;
        }
    }
}
