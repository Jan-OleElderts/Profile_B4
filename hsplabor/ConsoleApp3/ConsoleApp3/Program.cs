using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1:rechteckige Profil");
            Console.WriteLine("2:kreisfroemige Profil");
            Console.WriteLine("3:rechteckige Hohlprofil mit konstanter Dicke");
            Console.WriteLine("4:kreisfoermige Hohlprofil mit konstanter Dicke");
            Console.WriteLine("");
            Console.WriteLine("Bitte eintippen die zahl 1,2,3,4");
            string Art = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Eingabe in mm ");
            double a = Convert.ToDouble(Art);
            if (a == 1)
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
            if(a == 2)
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
                double s = 3.14*D*D/4;
                double v = s* t;
                double m = v* d;
                double Ib = 3.14 * D * D * D * D /64;
                double It = 3.14 * D * D * D * D /32;
                Console.WriteLine("");
                Console.WriteLine("   Querschnittsflache:   " + s);
                Console.WriteLine("   volumen:              " + v);
                Console.WriteLine("   Gewichte:             " + m);
                Console.WriteLine("   Ib:                   " + Ib);
                Console.WriteLine("   It:                   " + It);
                Console.ReadKey();
            }
            if(a==3)
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
                Console.WriteLine("Dicke bitte:");
                string Dicke = Console.ReadLine();
                double w = Convert.ToDouble(Dicke);
                double s = h*b-(h-2*w)*(b-2*w);
                double v = s * t;
                double m = v * d;
                double Ix =( b * h * h * h -(b-2*w)*(h-2*w)*(h-2*w)*(h-2*w))/12;
                double Iy = (h * b * b * b - (h - 2 * w) * (b - 2 * w) * (b - 2 * w) * (b - 2 * w)) / 12;
                Console.WriteLine("");
                Console.WriteLine("   Querschnittsflache:   " + s);
                Console.WriteLine("   volumen:              " + v);
                Console.WriteLine("   Gewichte:             " + m);
                Console.WriteLine("   Ix:                   " + Ix);
                Console.WriteLine("   Iy:                   " + Iy);
                Console.ReadKey();
            }
            if(a==4)
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
                double s = (3.14 * D*D-3.14*(D-2*w)*(D-2*w))/4 ;
                double v = s * t;
                double m = v * d;
                double Ib = 3.14 * (D * D * D * D - (D - 2 * w) * (D - 2 * w) * (D - 2 * w) * (D - 2 * w)) / 64;
                double It = 3.14 * (D * D * D * D - (D - 2 * w) * (D - 2 * w) * (D - 2 * w) * (D - 2 * w)) / 32;
            }
            Console.WriteLine("come on !  come on !");
        }
    }
}
