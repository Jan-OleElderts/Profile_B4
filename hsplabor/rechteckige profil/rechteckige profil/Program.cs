using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rechteckige_profil
{
    class Program
    {
        static void Main(string[] args)
        {
 Console.WriteLine("Tiefe bitte:");
                string Tiefe = Console.ReadLine();
                double t = Convert.ToDouble(Tiefe);
                Console.WriteLine("Breite bitte:");
                string Breite = Console.ReadLine();
                double b = Convert.ToDouble(Breite);
                Console.WriteLine("Hoehe bitte:");
                string Hoehe = Console.ReadLine();
                double h = Convert.ToDouble(Tiefe);
                Console.WriteLine("Dichte bitte:");
                string Dichte = Console.ReadLine();
                double d = Convert.ToDouble(Dichte);
                double s = h * b;
                double v = s*t;
                double m = v * d;
                double Ix = b * h * h * h / 12;
                double Iy = h * b * b * b / 12;
                Console.WriteLine("");
                Console.WriteLine("   Querschnittsflache:   "+s);
                Console.WriteLine("   volumen:              " + v);
                Console.WriteLine("   Gewichte:             " + m);
                Console.WriteLine("   Ix:                   "+Ix );
                Console.WriteLine("   Iy:                   " + Iy);
                Console.ReadKey();
        }
    }
}
