using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Osoba(string imie, string nazwisko) {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        public override string ToString()
        {
            Console.Write($"{this.Imie} {this.Nazwisko}");
            return "";
        }
    }
}
