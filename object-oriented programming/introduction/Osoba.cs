using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Osoba
    {
        private string _imie;
        private string _nazwisko;

        public string imie
        {
            get => _imie;
            set => _imie = value;
        }

        public string nazwisko
        {
            get => _nazwisko;
            set => _nazwisko = value;
        }

        Adres adres1 = new Adres();

        public void PrzedstawSie()
        {
            Console.WriteLine($"Nazywam się {this._imie} {this.nazwisko}.");
            this.adres1.OdczytDanych();
        }

        public void UstawDane(int i, string[,] osoby)
        {
            Console.WriteLine("--- Dane osobowe ---");
            osoby[i, 0] = Convert.ToString(i);

            Console.Write("Imie: ");
            this._imie = Console.ReadLine();
            osoby[i, 1] = this.imie;



            Console.Write("Nazwisko: ");
            this.nazwisko = Console.ReadLine();
            osoby[i, 2] = this.nazwisko;

            this.adres1.SetUpAddress(i, osoby);
        }

        
    }
}
