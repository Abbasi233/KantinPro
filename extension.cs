using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantinPro
{
    public static class extension
    {
        public static string Format(this decimal value)
        {
            return value.ToString("0.00");
        }
    }
}
