using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;

namespace B4_Profilberechnung_Obj
{
    class CatiaConnection
    {       
        
            INFITF.Application hsp_catiaApp;
            MECMOD.PartDocument hsp_catiaPart;
            MECMOD.Sketch hsp_catiaProfil;

          
        public bool CATIALaeuft()
        {
                
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
               
            catch (Exception)
            {                   
                return false;
            }

        }
               
        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }
        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;

            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }
        internal void ErzeugeSkizzeRechteck(double Hoehe, double Breite)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(Hoehe / 2, Breite / 2);
            Point2D p2 = catFactory2D1.CreatePoint(Hoehe / 2, -Breite / 2);
            Point2D p3 = catFactory2D1.CreatePoint(-Hoehe / 2, -Breite / 2);
            Point2D p4 = catFactory2D1.CreatePoint(-Hoehe / 2, Breite / 2);

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(Hoehe / 2, Breite / 2, Hoehe / 2, -Breite / 2);
            L1.StartPoint = p1;
            L1.EndPoint = p2;
            Line2D L2 = catFactory2D1.CreateLine(Hoehe / 2, -Breite / 2, -Hoehe / 2, -Breite / 2);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(-Hoehe / 2, -Breite / 2, -Hoehe / 2, Breite / 2);
            L3.StartPoint = p3;
            L3.EndPoint = p4;
            Line2D L4 = catFactory2D1.CreateLine(-Hoehe / 2, Breite / 2, Hoehe / 2, Breite / 2);
            L4.StartPoint = p4;
            L4.EndPoint = p1;

            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        internal void ErzeugeSkizzeDreieck(double Hoehe, double Breite)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(Hoehe, 0);
            Point2D p2 = catFactory2D1.CreatePoint(0, Breite / 2);
            Point2D p3 = catFactory2D1.CreatePoint(0, -Breite / 2);
            

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(Hoehe, 0, 0, Breite / 2);
            L1.StartPoint = p1;
            L1.EndPoint = p2;
            Line2D L2 = catFactory2D1.CreateLine(0, Breite / 2, 0, -Breite / 2);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(0, -Breite / 2, Hoehe , 0);
            L3.StartPoint = p3;
            L3.EndPoint = p1;
            

            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        internal void ErzeugeSkizzeKasten(double HoeheGroß,double HoeheKlein, double BreiteGroß, double BreiteKlein)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();            

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(HoeheGroß / 2, BreiteGroß / 2);
            Point2D p2 = catFactory2D1.CreatePoint(HoeheGroß / 2, -BreiteGroß / 2);
            Point2D p3 = catFactory2D1.CreatePoint(-HoeheGroß / 2, -BreiteGroß / 2);
            Point2D p4 = catFactory2D1.CreatePoint(-HoeheGroß / 2, BreiteGroß / 2);
            Point2D p5 = catFactory2D1.CreatePoint(HoeheKlein / 2, BreiteKlein / 2);
            Point2D p6 = catFactory2D1.CreatePoint(HoeheKlein / 2, -BreiteKlein / 2);
            Point2D p7 = catFactory2D1.CreatePoint(-HoeheKlein / 2, -BreiteKlein / 2);
            Point2D p8 = catFactory2D1.CreatePoint(-HoeheKlein / 2, BreiteKlein / 2);

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(HoeheGroß / 2, BreiteGroß / 2, HoeheGroß / 2, -BreiteGroß / 2);
            L1.StartPoint = p1;
            L1.EndPoint = p2;
            Line2D L2 = catFactory2D1.CreateLine(HoeheGroß / 2, -BreiteGroß / 2, -HoeheGroß / 2, -BreiteGroß / 2);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(-HoeheGroß / 2, -BreiteGroß / 2, -HoeheGroß / 2, BreiteGroß / 2);
            L3.StartPoint = p3;
            L3.EndPoint = p4;
            Line2D L4 = catFactory2D1.CreateLine(-HoeheGroß / 2, BreiteGroß / 2, HoeheGroß / 2, BreiteGroß / 2);
            L4.StartPoint = p4;
            L4.EndPoint = p1;
            Line2D L5 = catFactory2D1.CreateLine(HoeheKlein / 2, BreiteKlein / 2, HoeheKlein / 2, -BreiteKlein / 2);
            L5.StartPoint = p5;
            L5.EndPoint = p6;
            Line2D L6 = catFactory2D1.CreateLine(HoeheKlein / 2, -BreiteKlein / 2, -HoeheKlein / 2, -BreiteKlein / 2);
            L6.StartPoint = p6;
            L6.EndPoint = p7;
            Line2D L7 = catFactory2D1.CreateLine(-HoeheKlein / 2, -BreiteKlein / 2, -HoeheKlein / 2, BreiteKlein / 2);
            L7.StartPoint = p7;
            L7.EndPoint = p8;
            Line2D L8 = catFactory2D1.CreateLine(-HoeheKlein / 2, BreiteKlein / 2, HoeheKlein / 2, BreiteKlein / 2);
            L8.StartPoint = p8;
            L8.EndPoint = p5;

            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        internal void ErzeugeSkizzeKreisring(double RadiusGroß, double RadiusKlein)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Kreise
            double iEndParam = 2 * Math.PI;
            Circle2D K1 = catFactory2D1.CreateCircle(0, 0, RadiusKlein, 0,iEndParam );
            Circle2D K2 = catFactory2D1.CreateCircle(0, 0, RadiusGroß, 0, iEndParam );


            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }        
        internal void ErzeugeSkizzeUProfil(double HoeheGroß,double HoeheKlein, double BreiteGroß, double BreiteKlein)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(0,0);
            Point2D p2 = catFactory2D1.CreatePoint(0,HoeheGroß);
            Point2D p3 = catFactory2D1.CreatePoint(BreiteGroß,HoeheGroß);
            Point2D p4 = catFactory2D1.CreatePoint(BreiteGroß,((HoeheGroß-HoeheKlein)/2)+HoeheKlein);
            Point2D p5 = catFactory2D1.CreatePoint(BreiteGroß-BreiteKlein, (HoeheGroß - HoeheKlein) / 2 + HoeheGroß);
            Point2D p6 = catFactory2D1.CreatePoint(BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            Point2D p7 = catFactory2D1.CreatePoint(BreiteGroß, (HoeheGroß - HoeheKlein) / 2);
            Point2D p8 = catFactory2D1.CreatePoint(BreiteGroß,0);

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(0,0, 0, HoeheGroß);
            L1.StartPoint = p1;
            L1.EndPoint = p2;
            Line2D L2 = catFactory2D1.CreateLine(0, HoeheGroß, BreiteGroß, HoeheGroß);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(BreiteGroß, HoeheGroß, BreiteGroß,(HoeheGroß - HoeheKlein) / 2 + HoeheKlein) ; 
            L3.StartPoint = p3;
            L3.EndPoint = p4;
            Line2D L4 = catFactory2D1.CreateLine(BreiteGroß,(HoeheGroß - HoeheKlein) / 2 + HoeheKlein, BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2 + HoeheKlein) ;
            L4.StartPoint = p4;
            L4.EndPoint = p5;
            Line2D L5 = catFactory2D1.CreateLine(BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2 + HoeheKlein, BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            L5.StartPoint = p5;
            L5.EndPoint = p6;
            Line2D L6 = catFactory2D1.CreateLine(BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2, BreiteGroß, (HoeheGroß - HoeheKlein) / 2);
            L6.StartPoint = p6;
            L6.EndPoint = p7;
            Line2D L7 = catFactory2D1.CreateLine(BreiteGroß, (HoeheGroß - HoeheKlein) / 2, BreiteGroß, 0);
            L7.StartPoint = p7;
            L7.EndPoint = p8;
            Line2D L8 = catFactory2D1.CreateLine(BreiteGroß,0,0,0);
            L8.StartPoint = p8;
            L8.EndPoint = p1;

            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        internal void ErzeugeSkizzeIProfil(double HoeheGroß, double HoeheKlein, double BreiteGroß, double BreiteKlein)
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(0, 0);
            Point2D p2 = catFactory2D1.CreatePoint(0,(HoeheGroß-HoeheKlein)/2);
            Point2D p3 = catFactory2D1.CreatePoint(BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            Point2D p4 = catFactory2D1.CreatePoint(BreiteKlein,((HoeheGroß - HoeheKlein) / 2)+HoeheKlein);
            Point2D p5 = catFactory2D1.CreatePoint(0,((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            Point2D p6 = catFactory2D1.CreatePoint(0,HoeheGroß);
            Point2D p7 = catFactory2D1.CreatePoint(BreiteGroß,HoeheGroß);
            Point2D p8 = catFactory2D1.CreatePoint(BreiteGroß, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            Point2D p9 = catFactory2D1.CreatePoint(BreiteGroß-BreiteKlein, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            Point2D p10 = catFactory2D1.CreatePoint(BreiteGroß-BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            Point2D p11 = catFactory2D1.CreatePoint(BreiteGroß, (HoeheGroß - HoeheKlein) / 2);
            Point2D p12 = catFactory2D1.CreatePoint(BreiteGroß,0);

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(0, 0, 0, (HoeheGroß - HoeheKlein) / 2);
            L1.StartPoint = p1;
            L1.EndPoint = p2;
            Line2D L2 = catFactory2D1.CreateLine(0, (HoeheGroß - HoeheKlein) / 2, BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(BreiteKlein, (HoeheGroß - HoeheKlein) / 2, BreiteKlein, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            L3.StartPoint = p3;
            L3.EndPoint = p4;
            Line2D L4 = catFactory2D1.CreateLine(BreiteKlein, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein, 0, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            L4.StartPoint = p4;
            L4.EndPoint = p5;
            Line2D L5 = catFactory2D1.CreateLine(0, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein, 0, HoeheGroß);
            L5.StartPoint = p5;
            L5.EndPoint = p6;
            Line2D L6 = catFactory2D1.CreateLine(0, HoeheGroß, BreiteGroß, HoeheGroß);
            L6.StartPoint = p6;
            L6.EndPoint = p7;
            Line2D L7 = catFactory2D1.CreateLine(BreiteGroß, HoeheGroß, BreiteGroß, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            L7.StartPoint = p7;
            L7.EndPoint = p8;
            Line2D L8 = catFactory2D1.CreateLine(BreiteGroß, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein, BreiteGroß - BreiteKlein, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein);
            L8.StartPoint = p8;
            L8.EndPoint = p9;
            Line2D L9 = catFactory2D1.CreateLine(BreiteGroß - BreiteKlein, ((HoeheGroß - HoeheKlein) / 2) + HoeheKlein, BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2);
            L9.StartPoint = p9;
            L9.EndPoint = p10;
            Line2D L10 = catFactory2D1.CreateLine(BreiteGroß - BreiteKlein, (HoeheGroß - HoeheKlein) / 2, BreiteGroß, (HoeheGroß - HoeheKlein) / 2);
            L10.StartPoint = p10;
            L10.EndPoint = p11;
            Line2D L11 = catFactory2D1.CreateLine(BreiteGroß, (HoeheGroß - HoeheKlein) / 2, BreiteGroß, 0);
            L11.StartPoint = p11;
            L11.EndPoint = p12;
            Line2D L12 = catFactory2D1.CreateLine(BreiteGroß, 0,0,0);
            L12.StartPoint = p12;
            L12.EndPoint = p1;

            //Edition schließen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        internal void ErzeugePad(double Tiefe)
        {
            //Hauptkörper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            //Block erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;

            Pad pad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, Tiefe);

            pad1.set_Name("TEST");

            //Part aktualisieren
            hsp_catiaPart.Part.Update();

        }
    }
}