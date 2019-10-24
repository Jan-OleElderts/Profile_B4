using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsp3
{
    class kreisfroemigeProfil
    {
        public double t;
        public double D;
        public double d;

        public void Acceptdetail()
        {
            Console.WriteLine("Tiefe bitte:");
            string Tiefe = Console.ReadLine();
             t = Convert.ToDouble(Tiefe);
            Console.WriteLine("Durchmesser bitte:");
            string Durchmesser = Console.ReadLine();
             D = Convert.ToDouble(Durchmesser);
            Console.WriteLine("Dichte bitte:");
            string Dichte = Console.ReadLine();
             d = Convert.ToDouble(Dichte);

        }
        public double v()
        {
            return 3.14 * D * D / 4*t;
        }
        public double s()
        {
            return 3.14 * D * D / 4;
        }
        public double m()
        {
            return 3.14 * D * D / 4 * t*d;
        }
        public double Ib()
        {
            return 3.14 * D * D * D * D / 64;
        }
        public double It()
        {
            return 3.14 * D * D * D * D / 32;
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
                kreisfroemigeProfil r = new kreisfroemigeProfil();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();

            }

        }

    }
}
