/* Erste Version von dem Profilberechnungssystem.
 * Erstellt am 10.10.2019 von Jan-Ole Elderts
 * Letztes Update 10.10.2019 von Jan-Ole Elderts
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace profile_system_v20191010
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vorgeplänkel und Eingabeabfrage zum Recheckprofil
            Console.WriteLine("Wilkommen zu Ihrem persöhnlichem Profilgenerierungssystem.");

            Console.WriteLine("Bitte geben Sie die Höhe des Rechteckprofils im Metern ein und bestätigen Sie mit 'Enter'.");
            String StringRechteckH = Console.ReadLine();
            Double RechteckH = Convert.ToDouble(StringRechteckH);

            Console.WriteLine("Bitte geben Sie die Breite des Rechteckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringRechteckB = Console.ReadLine();
            Double RechteckB = Convert.ToDouble(StringRechteckB);

            Console.WriteLine("Bitte geben Sie die Tiefe des Rechteckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringRechteckT = Console.ReadLine();
            Double RechteckT = Convert.ToDouble(StringRechteckT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des Rechteckprofils in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            // Berechnungen aus Eingabe
            Double Querschnitt = RechteckH * RechteckB;
            Double Volumen = RechteckH * RechteckB * RechteckT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = Querschnitt * (Math.Sqrt(RechteckH) / 12);
            Double Flaechentraegheitsmomentz = Querschnitt * (Math.Sqrt(RechteckB) / 12);

            // Ausgabe der Berechneten Werte
            Console.WriteLine("Querschnitt: " + Querschnitt + "m^2");
            Console.WriteLine("Volumen: " + Volumen + "m^3");
            Console.WriteLine("Gewicht: " + Gewicht + "Kg");
            Console.WriteLine("Flächenträgheitsmoment in Y-Richtung: " + Flaechentraegheitsmomenty + "m^4");
            Console.WriteLine("Flächenträgheitsmoment in Z-Richtung: " + Flaechentraegheitsmomentz + "m^4");

            Console.ReadKey();
        }
    }
}
