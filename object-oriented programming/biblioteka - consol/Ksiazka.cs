using System;

namespace ConsoleApp7
{
    class Ksiazka
    {
        private string tytul;
        private int dataWydania;
        private Osoba autor;

        public Ksiazka(string tytul, int dataWydania, Osoba autor)
        {
            this.tytul = tytul;
            this.dataWydania = dataWydania;
            this.autor = autor;
        }

        public string Tytul { get => tytul; }
        public int DataWydania { get => dataWydania; }
        public Osoba Autor { get => autor; }

        public void Wypisz()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{this.autor.Imie} {this.autor.Nazwisko} \"{this.tytul}\" ({this.dataWydania})";
        }
    }
}
