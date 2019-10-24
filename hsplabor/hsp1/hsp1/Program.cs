using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsp1
{
   
        class rechteckigeProfilmitdicke
        {
            public double t;
            public double h;
            public double b;
            public double d;
            public double w;

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
                Console.WriteLine("Dicke bitte:");
                string Dicke = Console.ReadLine();
                w = Convert.ToDouble(Dicke);

        }
            public double v()
            {
                return h * b - (h - 2 * w) * (b - 2 * w)*t;
        }
            public double s()
            {
            return h* b-(h - 2 * w) * (b - 2 * w);
        }
            public double m()
            {
                return h * b - (h - 2 * w) * (b - 2 * w) * t*d;
        }
            public double Ix()
            {
                return (b * h * h * h - (b - 2 * w) * (h - 2 * w) * (h - 2 * w) * (h - 2 * w)) / 12;
        }
            public double Iy()
            {
                return (h * b * b * b - (h - 2 * w) * (b - 2 * w) * (b - 2 * w) * (b - 2 * w)) / 12;
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
                rechteckigeProfilmitdicke r = new rechteckigeProfilmitdicke();
                    r.Acceptdetail();
                    r.Ergebnis();
                    Console.ReadLine();

                }

            }

        }
    }
