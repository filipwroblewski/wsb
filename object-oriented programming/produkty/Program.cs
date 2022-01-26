using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Produkt p1 = new Produkt();
            Produkt p2 = new Produkt("Ulotka", (float)1.99, (float)0.2, 20);

            Komputer k1 = new Komputer("Acer", (float)4749.99, (float)0.05, 3, "Intel", 6, 8, "Windows");
            Komputer k2 = new Komputer();

            List<Produkt> produkty = new List<Produkt>();
            produkty.Add(p1);
            produkty.Add(p2);
            produkty.Add(k1);
            produkty.Add(k2);
            foreach (Produkt produkt in produkty)
            {
                produkt.Wyswietl();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
