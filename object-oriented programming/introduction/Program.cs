using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę kontaktów");
            int numOfContacts = int.Parse(Console.ReadLine());

            Osoba osoba1 = new Osoba();

            string[,] osoby = new string[numOfContacts, 9];

            for (int i = 0; i < numOfContacts; i++)
            {
                osoba1.UstawDane(i, osoby);
                osoba1.PrzedstawSie();
                Console.WriteLine("\n\n");
            }

            Console.WriteLine("\n\n\n------------------\n\n\n");
            for (int i = 0; i < numOfContacts; i++)
            {
                Console.WriteLine($"{osoby[i, 1]} {osoby[i, 2]}");
            }


            Console.ReadKey();
        }
    }
}
