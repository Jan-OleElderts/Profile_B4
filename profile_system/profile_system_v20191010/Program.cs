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
            Console.WriteLine("Willkommen zu Ihrem persöhnlichen Profilgenerierungssystem.");

            Console.WriteLine("Bitte geben Sie die Höhe des Rechteckprofils ein.");
            String StringRechteckH = Console.ReadLine();
            Double RechteckH = Convert.ToDouble(StringRechteckH);

            Console.WriteLine("Bitte geben Sie die Breite des Rechteckprofils ein.");
            String  StringRechteckB = Console.ReadLine();
            Double RechteckB = Convert.ToDouble(StringRechteckB);

            Console.WriteLine("Bitte geben Sie die Tiefe des Rechteckprofils ein.");
            String StringRechteckT = Console.ReadLine();
            Double RechteckT = Convert.ToDouble(StringRechteckT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des Rechteckprofils ein.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            // Berechnungen aus Eingabe
            Double Querschnitt = RechteckH * RechteckB;
            Double Volumen = RechteckH * RechteckB * RechteckT ;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = Querschnitt * (Math.Sqrt(RechteckH)/12);
            Double Flaechentraegheitsmomentz = Querschnitt * (Math.Sqrt(RechteckB)/12);

            // Ausgabe der Berechneten Werte
            Console.WriteLine("Querschnitt: " + Querschnitt);
            Console.WriteLine("Volumen: " + Volumen);
            Console.WriteLine("Gewicht: " + Gewicht);
            Console.WriteLine("Flächenträgheitsmoment in Y-Richtung: " + Flaechentraegheitsmomenty);
            Console.WriteLine("Flächenträgheitsmoment in Z-Richtung: " + Flaechentraegheitsmomentz);

            Console.ReadKey();
        }
    }
}
