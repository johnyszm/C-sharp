using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Threadlocking
{
    class Department
    {
        private Object thisLock = new Object();
        private Object thatLock = new object();
        int stanPiwa;
        Random r = new Random();
        public Department(int initial)
        {
            stanPiwa = initial;
        }
        int ZuzywaniePiwa(int wypijanePiwo)
        {
            
            if (stanPiwa < 0)
            {
                throw new Exception("Czekamy na dostawe");
            }
            
            lock (thisLock)
            {
                if (stanPiwa >= wypijanePiwo)
                {
                    Console.WriteLine("Klienci właśnie wypili {0} litrów piwa  ", wypijanePiwo);
                    stanPiwa = stanPiwa - wypijanePiwo;
                    Console.WriteLine("Ilość litrów piwa w zbiorniku po aktualizacji :  " + stanPiwa);
                    return wypijanePiwo;
                }
                else
                {
                    return 0; 
                }
            }
        }
        int DolewaniePiwa(int dolewanePiwo)
        {
            if (stanPiwa < 0)
            {
                throw new Exception("Czekamy na dostawe");
            }
            lock (thatLock)
            {
                if (stanPiwa > 0)
                {
                    Console.WriteLine("Zostało wyprodukowane i dolane do zbiornika {0} litrów piwa ", dolewanePiwo);
                    stanPiwa = stanPiwa + dolewanePiwo;
                    Console.WriteLine("Ilość litrów piwa w zbiorniku po aktualizacji : " + stanPiwa);
                    return dolewanePiwo;
                }
                else
                {
                    return 0;
                }
            }
        }
        public void Nalewanie()
        {
            for (int i = 0; i < 10; i++)
            {

                ZuzywaniePiwa(r.Next(20, 30));

            }
        }
        public void Wytwarzanie()
        {
            
            if (stanPiwa > 300)
            {
               
            }
            else if (stanPiwa > 100 && stanPiwa < 300)
            {

                DolewaniePiwa(r.Next(75, 100));
                Thread.Sleep(6000);
            }
            else if (stanPiwa > 50 && stanPiwa < 100)
            {
                DolewaniePiwa(r.Next(75, 100));
                Thread.Sleep(3000);
            }
            else if (stanPiwa <50)
            {
                DolewaniePiwa(r.Next(75, 100));
            }    
        }
    }
    class Process
    {
        static void Main()
        {
            Console.WriteLine("Ilość piwa w zbiorniku w trakcie otwierania baru : 200" );
            Thread[] threads = new Thread[1000];
            Thread[] thread2 = new Thread[1000];
            Department dep = new Department(200);
            for (int i = 0; i < 1000; i++)
            {
                Thread t = new Thread(new ThreadStart(dep.Nalewanie));
                threads[i] = t;
            }

            for (int i = 0; i < 1000; i++)
            {
                Thread p = new Thread(new ThreadStart(dep.Wytwarzanie));

                thread2[i] = p;
            
            }
            for (int i = 0; i < 1000; i++)
            {
                threads[i].Start();
                thread2[i].Start();                     
            }
            Console.Read();

        }
    }
}