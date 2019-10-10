/* Erste Version von dem Profilberechnungssystem.
 * Erstellt am 10.10.2019 von Jan-Ole Elderts
 * Letztes Update 10.10.2019 von Jan-Ole Elderts
 * Einbau von mehreren Auswahlmöglichkeiten und deren Berechnungen
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
            Console.WriteLine("Willkommen zu Ihrem persöhnlichen Profilberechnungssystem.");
            Console.WriteLine("Bitte geben Sie eine der folgenden Profile ein: Rechteck, Dreieck, Kreisring, Kastenprofil, T-Träger, I-Träger, U-Profil");

            string Auswahl = Console.ReadLine();

            switch (Auswahl)
            {
                case ("Rechteck"):
                    Rechteck();
                    break;
                case ("Dreieck"):
                    Dreieck();
                    break;
                case ("Kreisring"):
                    Kreisring();
                    break;
                case ("Kastenprofil"):
                    Kastenprofil();
                    break;
                case ("T-Träger"):
                    TTräger();
                    break;
                case ("I-Träger"):
                    ITräger();
                    break;
                case ("U-Profil"):
                    UProfil();
                    break;
            }
            Console.ReadKey();
        }

        static void Rechteck() 
        {
            //Abfrage der Werte und umwandeln von String in Double 
            Console.WriteLine("Bitte geben Sie die Höhe des Rechteckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
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

            //Berechnungen aus Eingabe
            Double Querschnitt = RechteckH * RechteckB;
            Double Volumen = Querschnitt * RechteckT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = Querschnitt * (Math.Sqrt(RechteckH) / 12);
            Double Flaechentraegheitsmomentz = Querschnitt * (Math.Sqrt(RechteckB) / 12);

            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
            Console.WriteLine($"Flächenträgheitsmoment in Z-Richtung: {Flaechentraegheitsmomentz} m^4");
        }

        static void Dreieck( ) 
        {
            //Abfrage der Werte und umwandeln von String in Double 
            Console.WriteLine("Bitte geben Sie die Höhe des Dreieckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringDreieckH = Console.ReadLine();
            Double DreieckH = Convert.ToDouble(StringDreieckH);

            Console.WriteLine("Bitte geben Sie die Grundfläche des Dreiteckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringDreieckG = Console.ReadLine();
            Double DreieckG = Convert.ToDouble(StringDreieckG);

            Console.WriteLine("Bitte geben Sie die Tiefe des Dreieckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringDreieckT = Console.ReadLine();
            Double DreieckT = Convert.ToDouble(StringDreieckT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des Dreieckprofils in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            //Berechnungen aus Eingabe
            Double Querschnitt = DreieckH * DreieckG /2;
            Double Volumen = Querschnitt * DreieckT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = Querschnitt * (Math.Sqrt(DreieckH) / 18);
            Double Flaechentraegheitsmomentz = Querschnitt * (Math.Sqrt(DreieckG) / 24);

            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
            Console.WriteLine($"Flächenträgheitsmoment in Z-Richtung: {Flaechentraegheitsmomentz} m^4");
        }

        static void Kreisring( ) 
        {
            //Abfrage der Werte und umwandeln von String in Double 
            Console.WriteLine("Bitte geben Sie den Radius des äußeren Kreisrings in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKreisringRa = Console.ReadLine();
            Double KreisringRa = Convert.ToDouble(StringKreisringRa);

            Console.WriteLine("Bitte geben Sie die Größe des äußeren Kreisrings in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKreisringRi = Console.ReadLine();
            Double KreisringRi = Convert.ToDouble(StringKreisringRi);

            Console.WriteLine("Bitte geben Sie die Tiefe des Kreisrings in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKreisringT = Console.ReadLine();
            Double KreisringT = Convert.ToDouble(StringKreisringT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des Kreisrings in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            //Berechnungen aus Eingabe
            Double Querschnitt = Math.PI * (Math.Sqrt(KreisringRa) - Math.Sqrt(KreisringRi));
            Double Volumen = Querschnitt * KreisringT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmoment = Querschnitt/4 * (Math.Sqrt(KreisringRa) + Math.Sqrt(KreisringRi));
            

            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment: {Flaechentraegheitsmoment} m^4");
            
        }          
                
        static void Kastenprofil( ) 
        {
            Console.WriteLine("Bitte geben Sie die Höhe des äußeren Kastenprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKastenHa = Console.ReadLine();
            Double KastenHa = Convert.ToDouble(StringKastenHa);

            Console.WriteLine("Bitte geben Sie die Breite des äußeren Kastenprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKastenBa = Console.ReadLine();
            Double KastenBa = Convert.ToDouble(StringKastenBa);

            Console.WriteLine("Bitte geben Sie die Höhe des inneren Kastenprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKastenHi = Console.ReadLine();
            Double KastenHi = Convert.ToDouble(StringKastenHi);

            Console.WriteLine("Bitte geben Sie die Breite des inneren Kastenprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKastenBi = Console.ReadLine();
            Double KastenBi = Convert.ToDouble(StringKastenBi);

            Console.WriteLine("Bitte geben Sie die Tiefe des Kastenprofils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringKastenT = Console.ReadLine();
            Double KastenT = Convert.ToDouble(StringKastenT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des Kastenprofils in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            //Berechnungen aus Eingabe
            Double Querschnitt = KastenHa * KastenBa - KastenHi * KastenBi;
            Double Volumen = Querschnitt * KastenT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = (KastenBa * Math.Sqrt(KastenHa)*KastenHa - KastenBi * Math.Sqrt(KastenHi) * KastenHi)/12;
            Double Flaechentraegheitsmomentz = (KastenHa * Math.Sqrt(KastenBa) * KastenBa - KastenHi * Math.Sqrt(KastenBi) * KastenBi) / 12;

            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
            Console.WriteLine($"Flächenträgheitsmoment in Z-Richtung: {Flaechentraegheitsmomentz} m^4");
        }

        static void TTräger( ) 
        {
            Console.WriteLine("Bitte geben Sie die Höhe des Rechteckprofils in Metern ein und bestätigen Sie mit 'Enter'.");
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

            //Berechnungen aus Eingabe
            Double Querschnitt = RechteckH * RechteckB;
            Double Volumen = RechteckH * RechteckB * RechteckT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = Querschnitt * (Math.Sqrt(RechteckH) / 12);
            Double Flaechentraegheitsmomentz = Querschnitt * (Math.Sqrt(RechteckB) / 12);

            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
            Console.WriteLine($"Flächenträgheitsmoment in Z-Richtung: {Flaechentraegheitsmomentz} m^4");
        }
        
        static void ITräger( ) 
        {
            Console.WriteLine("Bitte geben Sie die Höhe des I-Trägers in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringITrägerHa = Console.ReadLine();
            Double ITrägerHa = Convert.ToDouble(StringITrägerHa);

            Console.WriteLine("Bitte geben Sie die Breite des I-Trägers in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringITrägerBa = Console.ReadLine();
            Double ITrägerBa = Convert.ToDouble(StringITrägerBa);

            Console.WriteLine("Bitte geben Sie die Höhe der Aussparung des I-Trägers in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringITrägerHi = Console.ReadLine();
            Double ITrägerHi = Convert.ToDouble(StringITrägerHi);

            Console.WriteLine("Bitte geben Sie die Breite Aussparung des I-Trägers in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringITrägerBi = Console.ReadLine();
            Double ITrägerBi = Convert.ToDouble(StringITrägerBi);

            Console.WriteLine("Bitte geben Sie die Tiefe des I-Trägers in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringITrägerT = Console.ReadLine();
            Double ITrägerT = Convert.ToDouble(StringITrägerT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des I-Trägers in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            //Berechnungen aus Eingabe
            Double Querschnitt = ITrägerHa * ITrägerBa - ITrägerHi * ITrägerBi;
            Double Volumen = Querschnitt * ITrägerT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = (ITrägerBa * Math.Sqrt(ITrägerHa) * ITrägerHa - ITrägerBi * Math.Sqrt(ITrägerHi) * ITrägerHi) / 12;
            
            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
        }

        static void UProfil( ) 
        {
            Console.WriteLine("Bitte geben Sie die Höhe des U-Profils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringUProfilHa = Console.ReadLine();
            Double UProfilHa = Convert.ToDouble(StringUProfilHa);

            Console.WriteLine("Bitte geben Sie die Breite des U-Profils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringUProfilBa = Console.ReadLine();
            Double UProfilBa = Convert.ToDouble(StringUProfilBa);

            Console.WriteLine("Bitte geben Sie die Höhe der Aussparung des U-Profils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringUProfilHi = Console.ReadLine();
            Double UProfilHi = Convert.ToDouble(StringUProfilHi);

            Console.WriteLine("Bitte geben Sie die Breite der Aussparung des U-Profils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringUProfilBi = Console.ReadLine();
            Double UProfilBi = Convert.ToDouble(StringUProfilBi);

            Console.WriteLine("Bitte geben Sie die Tiefe des U-Profils in Metern ein und bestätigen Sie mit 'Enter'.");
            String StringUProfilT = Console.ReadLine();
            Double UProfilT = Convert.ToDouble(StringUProfilT);

            Console.WriteLine("Bitte geben Sie die Dichte des gewünschten Materials des U-Profils in Kg/m^3 ein und bestätigen Sie mit 'Enter'.");
            String StringDichte = Console.ReadLine();
            Double Dichte = Convert.ToDouble(StringDichte);

            //Berechnungen aus Eingabe
            Double Querschnitt = UProfilHa * UProfilBa - UProfilHi * UProfilBi;
            Double Volumen = Querschnitt * UProfilT;
            Double Gewicht = Volumen * Dichte;
            Double Flaechentraegheitsmomenty = (UProfilBa * Math.Sqrt(UProfilHa) * UProfilHa - UProfilBi * Math.Sqrt(UProfilHi) * UProfilHi) / 12;
            
            // Ausgabe der Berechneten Werte
            Console.WriteLine($"Querschnitt:  {Querschnitt} m^2");
            Console.WriteLine($"Volumen: {Volumen} m^3");
            Console.WriteLine($"Gewicht: {Gewicht} Kg");
            Console.WriteLine($"Flächenträgheitsmoment in Y-Richtung: {Flaechentraegheitsmomenty} m^4");
            
        }

    }
}
