using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Student : Osoba
    {
        public int NrIndeksu { get; set; }
        //public Osoba os { get; set; }

        //public Student(string imie, string nazwisko) : base(imie, nazwisko) { }

        public Student(string imie, string nazwisko, int nrIndeksu) : base(imie, nazwisko)
        {
            this.NrIndeksu = nrIndeksu;
        }

        public Student(Osoba os, int nrIndeksu) : base(os.Imie, os.Nazwisko)
        {
            this.NrIndeksu = nrIndeksu;
        }

        new public string ToString()
        {
            base.ToString();
            Console.Write($" [{this.NrIndeksu}]");
            return "";
        }
    }
}
