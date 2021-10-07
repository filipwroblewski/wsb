using System;

namespace zajecia_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba1 = new Osoba();

            //osoba1.Imie = "MojeImie"; // must be public string Imie
            //osoba1.Nazwisko = "MojeNazwisko";

            //Console.WriteLine($"Nazywam się {osoba1.Imie} {osoba1.Nazwisko}.");

            osoba1.UstawDane("Jan", "Nowak");
            osoba1.PrzedstawSie();

            //Adres adres1 = new Adres();
            //adres1.OdczytDanych();
        }
    }
}
