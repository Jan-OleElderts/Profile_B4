using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsp3
{
    class kreisfroemigeProfilmitdicke
    {
        public double t;
        public double D;
        public double d;
        public double w;
        public void Acceptdetail()
        {
            Console.WriteLine("Tiefe bitte:");
            string Tiefe = Console.ReadLine();
            double t = Convert.ToDouble(Tiefe);
            Console.WriteLine("Durchmesser bitte:");
            string Durchmesser = Console.ReadLine();
            double D = Convert.ToDouble(Durchmesser);
            Console.WriteLine("Dichte bitte:");
            string Dichte = Console.ReadLine();
            double d = Convert.ToDouble(Dichte);
            Console.WriteLine("Dicke bitte:");
            string Dicke = Console.ReadLine();
            double w = Convert.ToDouble(Dicke);

        }
        public double v()
        {
            return (3.14 * D * D - 3.14 * (D - 2 * w) * (D - 2 * w)) / 4 * t;
        }
        public double s()
        {
            return (3.14 * D * D - 3.14 * (D - 2 * w) * (D - 2 * w)) / 4;
        }
        public double m()
        {
            return 3.14 * D * D / 4 * t*(3.14 * D * D - 3.14 * (D - 2 * w) * (D - 2 * w)) / 4 * t * d;
        }
        public double Ib()
        {
            return 3.14 * (D * D * D * D - (D - 2 * w) * (D - 2 * w) * (D - 2 * w) * (D - 2 * w)) / 64;
        }
        public double It()
        {
            return 3.14 * (D * D * D * D - (D - 2 * w) * (D - 2 * w) * (D - 2 * w) * (D - 2 * w)) / 32;
        }
        public void Ergebnis()
        {
            Console.WriteLine("");
            Console.WriteLine("   Querschnittsflache:   " + s());
            Console.WriteLine("   volumen:              " + v());
            Console.WriteLine("   Gewichte:             " + m());
            Console.WriteLine("   Ib:                   " + Ib());
            Console.WriteLine("   It:                   " + It());
            Console.ReadKey();
        }
        class Summen
        {
            static void Main(string[] args)
            {
                kreisfroemigeProfilmitdicke r = new kreisfroemigeProfilmitdicke();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();

            }

        }

    }
}

