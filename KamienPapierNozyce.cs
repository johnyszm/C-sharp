using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kamieńPapier
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPlayer, inputPC;
            int randomInt;
            
            bool playAgain = true;

            while (playAgain)
            {
                int scorePlayer = 0;
                int scorePC = 0;

                while (scorePlayer < 3 && scorePC < 3)
                {
                    Console.WriteLine("Wybierz kamien, papier lub nozyce");
                    inputPlayer = Console.ReadLine();

                    inputPlayer = inputPlayer.ToUpper();

                    Random rnd = new Random();

                    randomInt = rnd.Next(1, 4);

                    switch (randomInt)
                    {
                        case 1:
                            inputPC = "KAMIEN";
                            Console.WriteLine("Komputer wybrał kamien");
                            if (inputPlayer == "KAMIEN")
                            {
                                Console.WriteLine("REMIS");
                            }
                            if (inputPlayer == "PAPIER")
                            {
                                Console.WriteLine("PLAYER WYGRAL");
                                scorePlayer++;
                            }

                            if (inputPlayer == "NOZYCE")
                            {
                                Console.WriteLine("KOMPUTER WYGRAL");
                                scorePC++;
                            }

                            break;

                        case 2:
                            inputPC = "PAPIER";
                            Console.WriteLine("Komputer wybrał papier");
                            if (inputPlayer == "PAPIER")
                            {
                                Console.WriteLine("REMIS");
                            }
                            if (inputPlayer == "KAMIEN")
                            {
                                Console.WriteLine("KOMPUTER WYGRAL");
                                scorePC++;
                            }
                            if (inputPlayer == "NOZYCE")
                            {
                                Console.WriteLine("PLAYER WYGRAL");
                                scorePlayer++;
                            }

                            break;

                        case 3:
                            inputPC = "NOZYCE";
                            Console.WriteLine("Komputer wybrał nozyce");
                            if (inputPlayer == "NOZYCE")
                            {
                                Console.WriteLine("REMIS");
                            }
                            if (inputPlayer == "PAPIER")
                            {
                                Console.WriteLine("KOMPUTER WYGRAL");
                                scorePC++;
                            }
                            if (inputPlayer == "KAMIEN")
                            {
                                Console.WriteLine("PLAYER WYGRAL");
                                scorePlayer++;
                            }

                            break;

                    }
                    Console.WriteLine("Komputer uzyskał {0} punktów, player uzyskał {1} punktów",scorePC,scorePlayer);
                }
                if (scorePC == 3)
                {
                    Console.WriteLine("KOMPUTER WYGRAŁ");
                }
                if (scorePlayer == 3)
                {
                    Console.WriteLine("PLAYER WYGRAŁ");
                }
                Console.WriteLine("Grasz jeszcze raz?(y/n)");
                string loop = Console.ReadLine();
                if(loop == "y")
                {
                    playAgain = true;
                    Console.Clear();
                }
                if (loop == "n")
                {
                    playAgain = false;
                }
            }

            Console.ReadKey();

        }
    }
}
