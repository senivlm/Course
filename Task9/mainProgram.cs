using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task9
{
    class mainProgram
    {
        public static void start()
        {
            string a = @"../../../Task9/Prices.txt";
            string b = @"../../../Task9/Menu.txt";
            var s = new CafeInfo(a, b);
            var c = s.GetPriceOfIngridients(Currency.Dollar);
            var d = s.GetWeightOfIngridients();
            s.WriteInfoToFile(@"../../../Task9/result.txt", Currency.Dollar);
        }
    }
}