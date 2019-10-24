using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie bitte die Hoehe des Rechteckprofils ein:");
            String Hoehe = Console.ReadLine();
            double H = Convert.ToDouble(Hoehe);
            Console.WriteLine("Geben Sie bitte die Breite des Rechteckprofils ein:");
            String Breite = Console.ReadLine();
            double B = Convert.ToDouble(Breite);
            Console.WriteLine("Geben Sie bitte die Tiefe des Rechteckprofils ein:");
            String Tiefe = Console.ReadLine();
            double T = Convert.ToDouble(Tiefe);
            Console.WriteLine("Geben Sie bitte die Dichte des Rechteckprofils ein:");
            String Dichte = Console.ReadLine();
            double D = Convert.ToDouble(Dichte);
            Console.WriteLine();
            String m = Console.ReadLine();
            String Kg = Console.ReadLine();
            double Querschnittsflaeche1= H * B;
            Console.WriteLine("Ausgabe der Querschnittsflaeche fuer y-z-Achse");
            Console.WriteLine(": " + Querschnittsflaeche1 + "m^2");
            double Querschnittsflaeche2 = T * B;
            Console.WriteLine("Ausgabe der Querschnittsflaeche fuer x-y-Achse");
            Console.WriteLine(": " + Querschnittsflaeche2 + "m^2");
            double Querschnittsflaeche3 = H * T;
            Console.WriteLine("Ausgabe der Querschnittsflaeche fuer x-z-Achse");
            Console.WriteLine(": " + Querschnittsflaeche3 + "m^2");
            double Volumen = H * B * T;
            Console.WriteLine("Ausgabe des Volumens");
            Console.WriteLine(": " + Volumen + "m^3");
            double Gewicht = H * B * T * D;
            Console.WriteLine("Ausgabe des Gewichts");
            Console.WriteLine(": " + Gewicht + "Kg");
            double Flaechentraegheitsmoment1 = H * Math.Pow(B, 3) / 12;
            Console.WriteLine("Ausgabe des Flaechentraegheitsmoments fuer z-Achse");
            Console.WriteLine(": " + Flaechentraegheitsmoment1+"m^4");
            double Flaechentraegheitsmoment2 = B * Math.Pow(H, 3) / 12;
            Console.WriteLine("Ausgabe des Flaechentraegheitsmoments fuer y-Achse");
            Console.WriteLine(": " + Flaechentraegheitsmoment2+"m^4");
            Console.ReadKey();
        }
    }
}
