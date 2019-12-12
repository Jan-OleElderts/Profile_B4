using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4_Profilberechnung_Obj
{
     public class CatiaControl
    {
        public CatiaControl()
        {
            try
            {
                CatiaConnection cc = new CatiaConnection();

                //finde den Catia Prozess
                if (cc.CATIALaeuft())
                {
                    // Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere ein Profil
                    cc.ErzeugeProfilSkizze();

                    // Extrudiere 3D Objekt
                    double Tiefe = 300;
                    cc.ErzeugePad(Tiefe);
                }
                else
                {
                    MessageBox.Show("Catia läuft nicht!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }
        }
    }
}