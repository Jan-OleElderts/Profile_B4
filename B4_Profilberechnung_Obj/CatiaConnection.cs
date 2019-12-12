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

        public void ErzeugeProfilSkizze()
        {
            //Part zugreifen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //Erzeuge Punkte
            Point2D p1 = catFactory2D1.CreatePoint(50,50);
            Point2D p2 = catFactory2D1.CreatePoint(50,-50);
            Point2D p3 = catFactory2D1.CreatePoint(-50,-50);
            Point2D p4 = catFactory2D1.CreatePoint(-50,50);

            //Erzeuge Linien und deren Start- und Endpunkte
            Line2D L1 = catFactory2D1.CreateLine(50, 50, 50, -50);
            L1.StartPoint =p1;
            L1.EndPoint =p2;
            Line2D L2 = catFactory2D1.CreateLine(50, -50, -50, -50);
            L2.StartPoint = p2;
            L2.EndPoint = p3;
            Line2D L3 = catFactory2D1.CreateLine(-50, -50, -50, 50);
            L3.StartPoint = p3;
            L3.EndPoint = p4;
            Line2D L4 = catFactory2D1.CreateLine(-50, 50, 50, 50);
            L4.StartPoint = p4;
            L4.EndPoint = p1;

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