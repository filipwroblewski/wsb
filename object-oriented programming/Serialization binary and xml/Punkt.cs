using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    [Serializable]
    public class Punkt
    {
        //private double x, y;
        public double X, Y;
        public Punkt(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Punkt() : this (0, 0) { }

        //bo sa pola public, wiec nie potrzeba tworzyc
        /*public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }*/
    }
}
