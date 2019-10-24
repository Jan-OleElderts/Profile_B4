using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsp2
{
    class rechteckigeProfil
    {
        public double t;
        public double h;
        public double b;
        public double d;

        public void Acceptdetail()
        {
            Console.WriteLine("Tiefe bitte:");
            string Tiefe = Console.ReadLine();
            t = Convert.ToDouble(Tiefe);
            Console.WriteLine("Breite bitte:");
            string Breite = Console.ReadLine();
            b = Convert.ToDouble(Breite);
            Console.WriteLine("Hoehe bitte:");
            string Hoehe = Console.ReadLine();
            h = Convert.ToDouble(Tiefe);
            Console.WriteLine("Dichte bitte:");
            string Dichte = Console.ReadLine();
            d = Convert.ToDouble(Dichte);

        }
        public double v()
        {
            return h * b * t;
        }
        public double s()
        {
            return h * b;
        }
        public double m()
        {
            return h * b * t * d;
        }
        public double Ix()
        {
            return b * h * h * h / 12;
        }
        public double Iy()
        {
            return h * b * b * b / 12;
        }
        public void Ergebnis()
        {
            Console.WriteLine("");
            Console.WriteLine("   Querschnittsflache:   " + s());
            Console.WriteLine("   volumen:              " + v());
            Console.WriteLine("   Gewichte:             " + m());
            Console.WriteLine("   Ix:                   " + Ix());
            Console.WriteLine("   Iy:                   " + Iy());
            Console.ReadKey();
        }
        class Summen
        {
            static void Main(string[] args)
            {
                rechteckigeProfil r = new rechteckigeProfil();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadLine();

            }

        }

    }
}
