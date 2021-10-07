using System;
using System.Collections.Generic;
using System.Text;

namespace zajecia_1
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

        public void PrzedstawSie()
        {
            Console.WriteLine($"Nazywam się {this._imie} {this.nazwisko}.");
        }

        public void UstawDane(string imie, string nazwisko)
        {
            this._imie = imie;
            this.nazwisko = nazwisko;
        }

        Adres adres1 = new Adres();
    }
}
