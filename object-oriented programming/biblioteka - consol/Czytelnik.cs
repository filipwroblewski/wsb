using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Czytelnik : Osoba
    {
        protected List<Ksiazka> przeczytaneKsiazski;

        public Czytelnik(string name, string surname, int age) : base(name, surname, age)
        {
            przeczytaneKsiazski = new List<Ksiazka>();
        }

        public void DodajKsiaze(Ksiazka book)
        {
            this.przeczytaneKsiazski.Add(book);
        }

        public List<Ksiazka> PrzeczytaneKsiazski { get => przeczytaneKsiazski; }

        /*public string WypiszKsiazki()
        {
            string info = "";
            foreach (Ksiazka book in this.przeczytaneKsiazski)
            {
                info+=$"{book.Autor.Imie} {book.Autor.Nazwisko} \"{book.Tytul}\"\n";
            }
            return info;
        }*/

        public void WypiszKsiazki()
        {
            foreach (Ksiazka book in this.przeczytaneKsiazski)
            {
                book.Wypisz();
            }
            Console.WriteLine();
        }

        public override void Wypisz()
        {
            Console.Write("Przeczytane ksiazki przez: ");
            base.Wypisz();
            WypiszKsiazki();
        }

    }
}
