using System;

namespace ConsoleApp7
{
    class Osoba
    {
        private string imie, nazwisko;
        private int wiek;

        public Osoba(string imie, string surname, int age)
        {
            this.imie = imie;
            this.nazwisko = surname;
            this.wiek = age;
        }

        public string Imie { get => imie; }
        public string Nazwisko { get => nazwisko; }
        public int Wiek { get => wiek; }

        public virtual void Wypisz()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{this.Imie} {this.nazwisko} ({this.wiek})";
        }
    }
}
