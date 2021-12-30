using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba os1 = new Osoba("Adam", "Mickiewicz", 45);
            Osoba os2 = new Osoba("Henryk", "Sienkiewicz", 56);
            
            Ksiazka k1 = new Ksiazka("Pan Tadeusz", 2021, os1);
            Ksiazka k2 = new Ksiazka("Potop", 2019, os2);
            Ksiazka k3 = new Ksiazka("Quo Vadis", 2017, os2);
            Ksiazka k4 = new Ksiazka("W pustyni i w puszczy", 2018, os2);

            Czytelnik cz1 = new Czytelnik("Bob", "Bobson", 39);
            Czytelnik cz2 = new Czytelnik("Ben", "Benson", 25);

            cz1.DodajKsiaze(k1);
            cz1.DodajKsiaze(k2);
            
            cz2.DodajKsiaze(k2);
            cz2.DodajKsiaze(k3);
            cz2.DodajKsiaze(k4);

            Recenzent r1 = new Recenzent("Jan", "Kowalski", 33);
            Recenzent r2 = new Recenzent("Maciej", "Konieczny", 28);

            r1.DodajKsiaze(k1);
            r1.DodajKsiaze(k2);
            r1.DodajKsiaze(k3);

            r2.DodajKsiaze(k2);
            r2.DodajKsiaze(k3);
            r2.DodajKsiaze(k4);

            List<Osoba> osoby = new List<Osoba>();
            osoby.Add(cz1);
            osoby.Add(cz2);
            osoby.Add(r1);
            osoby.Add(r2);
            Console.WriteLine("List<Osoba>");
            foreach (Osoba os in osoby)
            {
                os.Wypisz();
            }

            Console.ReadKey();
        }
    }
}
