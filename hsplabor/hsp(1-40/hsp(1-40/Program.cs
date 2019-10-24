using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
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
    }
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
            return h * b - (h - 2 * w) * (b - 2 * w) * t;
        }
        public double s()
        {
            return h * b - (h - 2 * w) * (b - 2 * w);
        }
        public double m()
        {
            return h * b - (h - 2 * w) * (b - 2 * w) * t * d;
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
    }
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
            return 3.14 * D * D / 4 * t;
        }
        public double s()
        {
            return 3.14 * D * D / 4;
        }
        public double m()
        {
            return 3.14 * D * D / 4 * t * d;
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
    }
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
            return 3.14 * D * D / 4 * t * (3.14 * D * D - 3.14 * (D - 2 * w) * (D - 2 * w)) / 4 * t * d;
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
    }
        class Summen
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
                rechteckigeProfil r = new rechteckigeProfil();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();
            }
            if (a == 2)
            {
                kreisfroemigeProfil r = new kreisfroemigeProfil();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();
            }
            if (a == 3)
            {
                rechteckigeProfilmitdicke r = new rechteckigeProfilmitdicke();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();
            }
            if (a == 4)
            {
                kreisfroemigeProfilmitdicke r = new kreisfroemigeProfilmitdicke();
                r.Acceptdetail();
                r.Ergebnis();
                Console.ReadKey();
            }

        }

    }

}




