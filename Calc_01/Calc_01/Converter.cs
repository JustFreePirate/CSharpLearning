using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calc_01
{
    public class Converter
    {
        public static Int64 from8to10(Int64 oct)
        {
            Int64 dec = 0;
            Int64 sign = (oct >= 0) ? +1 : -1;
            oct = Math.Abs(oct);
            Int64 k = 1;
            while (oct > 0)
            {
                dec += (oct % 10) * k;
                k *= 8;
                oct /= 10;
            }
            return dec * sign;
        }

        public static Int64 from10to8(Int64 dec)
        {
            Int64 oct = 0;
            Int64 sign = (dec >= 0) ? +1 : -1;
            dec = Math.Abs(dec);
            Int64 k = 1;
            while (dec > 0)
            {
                oct += (dec % 8) * k;
                k *= 10;
                dec /= 8;
            }
            return oct * sign;
        }

    }
}
