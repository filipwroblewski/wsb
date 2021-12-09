using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    [Serializable]
    class Kolo : Punkt
    {
        private double r;

        public Kolo(double nowyX, double nowyY, double nowyR) : base(nowyX, nowyY)
        {
            this.r = nowyR;
        }

        public void Info()
        {
            Console.WriteLine($"Wspolrzedne srodka kola ({this.X}, {this.Y}) r = {this.r}");
            Console.WriteLine($"Pole kola {Pole()}");
        }

        public double Pole()
        {
            return Math.PI * Math.Sqrt(this.r);
        }
    }
}
