using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication37
{
    class Program
    {
        static void Main(string[] args)
        {
            long suma = 0;
            int n = 0;
            int m = 2;

            while (n < 500)
            {
                if (CzyPierwsza(m))
                {
                    suma += m;
                    n++;
                }
                m++;
            }
            Console.WriteLine("suma pierwszych 500 liczb pierwszych: " + suma.ToString());

            Console.ReadKey();
        }
        public static bool CzyPierwsza(int a)
        {
            double b = (int)Math.Floor(Math.Sqrt(a));
            if (a == 1) return false;
            if (a == 2) return true;

            for (int i = 2; i <= b; ++i)
            {
                if (a % i == 0)
                {
                    return false;
                }

            }
            return true;

        }

    }
}

