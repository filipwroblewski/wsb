using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    [Serializable]
    public class Prostokat
    {
        //private Punkt LewyDolny, PrawyGorny;
        public Punkt LewyDolny, PrawyGorny;

        public Prostokat(double x1, double y1, double x2, double y2)
        {
            this.LewyDolny = new Punkt(x1, y1);
            this.PrawyGorny = new Punkt(x2, y2);
        }

        public Prostokat() : this(0, 0, 0, 0) { }

        public double Pole()
        {
            return Math.Abs((PrawyGorny.X - LewyDolny.X) * (PrawyGorny.Y - LewyDolny.Y));
        }

        public void Info()
        {
            Console.WriteLine($"Wspolrzedne wierzcholkow prostokata ({LewyDolny.X}, {LewyDolny.Y}), ({PrawyGorny.X}, {PrawyGorny.Y})");
            Console.WriteLine($"Pole prostokata {this.Pole()}");
        }
    }
}
