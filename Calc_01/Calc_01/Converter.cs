using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calc_01
{
    public class Converter
    {
        public static int from8to10(int oct)
        {
            int dec = 0;
            int sign = (oct >= 0) ? +1 : -1;
            oct = Math.Abs(oct);
            int k = 1;
            while (oct > 0)
            {
                dec += (oct % 10) * k;
                k *= 8;
                oct /= 10;
            }
            return dec * sign;
        }

        public static int from10to8(int dec)
        {
            int oct = 0;
            int sign = (dec >= 0) ? +1 : -1;
            dec = Math.Abs(dec);
            int k = 1;
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
