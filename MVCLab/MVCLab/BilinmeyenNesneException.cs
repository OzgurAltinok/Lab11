using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab
{
    class BilinmeyenNesneException : Exception
    {
        internal BilinmeyenNesneException(String message) : base(message)
        {
            this.Log(this);
        }

        internal void Log(BilinmeyenNesneException ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
