using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication41
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Jaki rozmiar tablicy proponujesz?");
            int c = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[c];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(1, 30);
            }
            Console.Write("nasza tablica: ");
            foreach (int item in a)
                Console.Write(item + " ");
            Console.ReadKey();

            int b = Math.Abs(a[a.Length - 1] - a[0]) - 1;
            Console.WriteLine();
            Console.WriteLine("tyle liczb znajduje się w przedziale pomiędzy pierwszą, a ostatnią wartością: " + b);
            int d = 0;

            for (int i = 1; i < a.Length - 1; i++)
            {
                if (a[0] < a[a.Length - 1])
                {
                    if ((a[i] < a[a.Length - 1]) && (a[i] > a[0]))
                    {
                        d++;
                    }

                }
                else if (a[0] > a[a.Length - 1])
                {
                    if ((a[i] > a[a.Length - 1]) && (a[i] < a[0]))
                    {
                        d++;
                    }
                }
                else
                    Console.WriteLine("są równe");
            }
            Console.WriteLine("tyle jest liczb z przedziału pomiędzy pierwszą, a ostatnią wartością, nieznajdujących się w tablicy: " + (b - d));
            Console.ReadKey();

        }

    }

}