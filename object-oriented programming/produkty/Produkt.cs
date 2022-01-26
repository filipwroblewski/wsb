using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Produkt
    {
        private string nazwaProduktu;
        private float cenaNetto;
        private float podatek; // procent opodatkowania
        private int liczbaDostepnych;

        public Produkt(string nazwaProduktu, float cenaNetto, float podatek, int liczbaDostepnych)
        {
            this.nazwaProduktu = nazwaProduktu;
            this.cenaNetto = cenaNetto;
            this.podatek = podatek;
            this.liczbaDostepnych = liczbaDostepnych;
        }

        public Produkt() : this("Plakat", (float)12.99, (float)0.01, 10){}

        public string NazwaProduktu { get => nazwaProduktu; set => nazwaProduktu = value; }
        public float CenaNetto { get => cenaNetto; set => cenaNetto = value; }
        public float Podatek { get => podatek; set => podatek = value; }
        public int LiczbaDostepnych { get => liczbaDostepnych; set => liczbaDostepnych = value; }

        public float PodajCene()
        {
            return this.cenaNetto + (this.cenaNetto * this.podatek);
        }

        public float PodajCene(int liczba)
        {
            return this.PodajCene() * liczba;
        }

        public virtual void Wyswietl()
        {
            Console.WriteLine($"Nazwa produktu: {this.nazwaProduktu},\nCena netto: {this.cenaNetto},\nCena z podatkiem: {this.PodajCene()},\nLiczba dostepnych: {this.liczbaDostepnych},\nCena dostepnych z podatkiem: {this.PodajCene(this.liczbaDostepnych)}");
        }
    }
}
