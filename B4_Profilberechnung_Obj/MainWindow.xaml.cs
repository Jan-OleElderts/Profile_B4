using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PARTITF;
using MECMOD;
using INFITF;
using MessageBox = System.Windows.MessageBox;

namespace B4_Profilberechnung_Obj
{

    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            Hide();
        }

        private void Button_Click_Ende(object sender, RoutedEventArgs e)
        {
            //schließt die Anwendung nach erneuter Abfrage in einer Messagebox
            MessageBoxResult msgAbfrage = MessageBox.Show("Wirklich Beenden?", "Wirklich Beenden?",
                                                          MessageBoxButton.YesNo);

            if (msgAbfrage == MessageBoxResult.Yes)
            {
                //Schließen der Anwendung
                Close();
            }

        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            //setzt die Parameter in den Textboxen zurück
            txtParameter1.Text = "";
            txtParameter2.Text = "";
            txtParameter3.Text = "";
            txtParameter4.Text = "";
            txtParameter5.Text = "";
            txtParameter6.Text = "";
            txtVolumen.Text = "";
            txtDichte.Text = "";
            txtGeld.Text = "";
            txtFlaeche.Text = "";
            txtMasse.Text = "";

            //Sichtbarkeit auf Hidden
            txtVolumen.Visibility = Visibility.Hidden;
            txtPreis.Visibility = Visibility.Hidden;
            txtFlaeche.Visibility = Visibility.Hidden;
            txtMasse.Visibility = Visibility.Hidden;
            lblVolumen.Visibility = Visibility.Hidden;
            lblPreis.Visibility = Visibility.Hidden;
            lblFlaeche.Visibility = Visibility.Hidden;
            lblMasse.Visibility = Visibility.Hidden;

            btnCatia.IsEnabled = false;
        }
        private void Button_Click_Berechne(object sender, RoutedEventArgs e)
        {
            TreeViewItem auswahlItem = (TreeViewItem)trvFigur.SelectedItem;
            string Variable = auswahlItem.Name;

            //Abfrage von Fallunterscheidung, mit dem Aufruf zum jeweiligen Fall
            switch (Variable)
            {
                case ("itmRechteck"):
                    PruefeRechteck();
                    break;
                case ("itmDreieck"):
                    PruefeDreieck();
                    break;
                case ("itmKasten"):
                    PruefeKasten();
                    break;
                case ("itmKreisring"):
                    PruefeKreisring();
                    break;
                case ("itmUProfil"):
                    PruefeUProfil();
                    break;
                case ("itmIProfil"):
                    PruefeIProfil();
                    break;
            }
        }
        public void btnCatia_Click(object sender, RoutedEventArgs e)
        {
            new CatiaControl();          
        }

        private void PruefeIProfil()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double IProfilH;
            double IProfilh;
            double IProfilB;
            double IProfilb;
            double IProfilT;
            double Volumen;
            double Dichte;
            double Preis;
            double Masse;
            double Flaeche;

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                IProfilH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (IProfilH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                IProfilh = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (IProfilh <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (IProfilh >= IProfilH)
            {
                MessageBox.Show("Unmögliche Wertepaare bei 'H und h', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                IProfilB = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (IProfilB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {

                IProfilb = Convert.ToDouble(txtParameter4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (IProfilb <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if ((2*IProfilb) >= IProfilB)
            {
                MessageBox.Show("Unmögliche Wertepaare bei 'B und b/2', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                IProfilT = Convert.ToDouble(txtParameter5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (IProfilT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;
                lblMasse.Visibility = Visibility.Visible;
                lblFlaeche.Visibility = Visibility.Visible;
                lblPreis.Visibility = Visibility.Visible;

                btnCatia.IsEnabled = true;

                Flaeche = (IProfilB * IProfilH - IProfilb * 2 * IProfilh);
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen = Flaeche * IProfilT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Volumen * Preis;
                txtPreis.Text = Convert.ToString(Preis);
            }
            
        }
        private void PruefeUProfil()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double UProfilH;
            double UProfilh;
            double UProfilB;
            double UProfilb;
            double UProfilT;
            double Volumen;
            double Dichte;
            double Preis;
            double Masse;
            double Flaeche;

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                UProfilH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (UProfilH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                UProfilh = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (UProfilh <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (UProfilh >= UProfilH)
            {
                MessageBox.Show("Unmögliche Wertepaare bei 'H und h', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                UProfilB = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (UProfilB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {

                UProfilb = Convert.ToDouble(txtParameter4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (UProfilb <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (UProfilb >= UProfilB)
            {
                MessageBox.Show("Unmögliche Wertepaare bei 'B und b', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                UProfilT = Convert.ToDouble(txtParameter5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (UProfilT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;
                lblMasse.Visibility = Visibility.Visible;
                lblFlaeche.Visibility = Visibility.Visible;
                lblPreis.Visibility = Visibility.Visible;

                btnCatia.IsEnabled = true;

                Flaeche = (UProfilB * UProfilH - UProfilb * UProfilh);
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen = Flaeche * UProfilT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Volumen * Preis;
                txtPreis.Text = Convert.ToString(Preis);
            }
        }
        private void PruefeKreisring()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double KreisringR;
            double Kreisringr;
            double KreisringT;
            double Volumen;
            double Dichte;
            double Preis;
            double Masse;
            double Flaeche;

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                KreisringR = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (KreisringR <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                Kreisringr = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Kreisringr <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (Kreisringr >= KreisringR)
            {
                MessageBox.Show("Unmögliche Wertepaare bei 'R und r', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                KreisringT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (KreisringT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;
                lblMasse.Visibility = Visibility.Visible;
                lblFlaeche.Visibility = Visibility.Visible;
                lblPreis.Visibility = Visibility.Visible;


                btnCatia.IsEnabled = true;

                Flaeche = (Math.Pow(KreisringR, 2) - Math.Pow(Kreisringr, 2)) * Math.PI;
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen = Flaeche * KreisringT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Volumen * Preis;
                txtPreis.Text = Convert.ToString(Preis);
            }
        }
        private void PruefeKasten()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double KastenH;
            double Kastenh;
            double KastenB;
            double Kastenb;
            double KastenT;
            double Volumen;
            double Dichte;
            double Preis;
            double Flaeche;
            double Masse;

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                KastenH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (KastenH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                Kastenh = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Kastenh <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (Kastenh >= KastenH)
            {
                MessageBox.Show("Unmögliche Wertepaare bei dem Feld 'H und h', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                KastenB = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (KastenB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {

                Kastenb = Convert.ToDouble(txtParameter4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Kastenb <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (Kastenb >= KastenB)
            {
                MessageBox.Show("Unmögliche Wertepaare bei dem Feld 'B und b', bitte Eingaben erneut prüfen!");
                EingabeOK = false;
                return;
            }
            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                KastenT = Convert.ToDouble(txtParameter5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (KastenT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;
                lblMasse.Visibility = Visibility.Visible;
                lblFlaeche.Visibility = Visibility.Visible;
                lblPreis.Visibility = Visibility.Visible;

                btnCatia.IsEnabled = true;

                Flaeche = (KastenB * KastenH - Kastenb * Kastenh);
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen = Flaeche * KastenT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Volumen * Preis;
                txtPreis.Text = Convert.ToString(Preis);

            }
        }
        private void PruefeDreieck()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double DreieckH;
            double DreieckA;
            double DreieckT;
            double Volumen;
            double Dichte;
            double Preis;
            double Masse;
            double Flaeche;

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                DreieckH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (DreieckH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                DreieckA = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (DreieckA <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                DreieckT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (DreieckT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;                
                lblFlaeche.Visibility = Visibility.Visible;                
                lblMasse.Visibility = Visibility.Visible;                
                lblPreis.Visibility = Visibility.Visible;                

                btnCatia.IsEnabled = true;

                Flaeche = DreieckH * 1 / 2 * DreieckA;
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen = Flaeche * DreieckT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Volumen * Preis;
                txtPreis.Text = Convert.ToString(Preis);
            }
        }
        private void PruefeRechteck()
        {
            //Definieren von Variablen
            Boolean EingabeOK = true;
            double RechteckH;
            double RechteckB;
            double RechteckT;
            double Volumen;
            double Flaeche;
            double Masse;
            double Preis;
            double Dichte;

           //Prüfen, ob eingegebener Parameter i.O. ist.
           //Wenn Parameter i.O., dann wird der Wert so abgespeichert
           //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                RechteckH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (RechteckH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                RechteckB = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (RechteckB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Prüfen, ob eingegebener Parameter i.O. ist.
            //Wenn Parameter i.O., dann wird der Wert so abgespeichert
            //Wenn Parameter n.i.O., dann Fehleranzeige
            try
            {
                RechteckT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (RechteckT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                Dichte = Convert.ToDouble(txtDichte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Dichte<=0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            try
            {
                Preis = Convert.ToDouble(txtGeld.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Preis <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            //Wenn alle Eingaben i.O., dann Berechnung durchführen
            if (EingabeOK)
            {
                txtVolumen.Visibility = Visibility.Visible;
                txtFlaeche.Visibility = Visibility.Visible;
                txtMasse.Visibility = Visibility.Visible;
                txtPreis.Visibility = Visibility.Visible;

                lblVolumen.Visibility = Visibility.Visible;               
                lblFlaeche.Visibility = Visibility.Visible;
                lblMasse.Visibility = Visibility.Visible;                
                lblPreis.Visibility = Visibility.Visible;               

                btnCatia.IsEnabled = true;

                Flaeche = RechteckH * RechteckB;
                txtFlaeche.Text = Convert.ToString(Flaeche);
                Volumen =  Flaeche * RechteckT;
                txtVolumen.Text = Convert.ToString(Volumen);
                Masse = Volumen * Dichte;
                txtMasse.Text = Convert.ToString(Masse);
                Preis = Masse * Preis;
                txtPreis.Text = Convert.ToString(Preis);

            }
            
        }
        private new void Hide()
        {
            // versteckt alle Textfelder und Parameterboxen und Bilder
            imRechteck.Visibility = Visibility.Hidden;
            imKasten.Visibility = Visibility.Hidden;
            imDreieck.Visibility = Visibility.Hidden;
            imKreisring.Visibility = Visibility.Hidden;
            imUProfil.Visibility = Visibility.Hidden;
            imIProfil.Visibility = Visibility.Hidden;

            lblParameter1.Visibility = Visibility.Hidden;
            lblParameter2.Visibility = Visibility.Hidden;
            lblParameter3.Visibility = Visibility.Hidden;
            lblParameter4.Visibility = Visibility.Hidden;
            lblParameter5.Visibility = Visibility.Hidden;
            lblParameter6.Visibility = Visibility.Hidden;
            lblHeader.Visibility = Visibility.Hidden;
            lblVolumen.Visibility = Visibility.Hidden;
            lblFlaeche.Visibility = Visibility.Hidden;
            lblMasse.Visibility = Visibility.Hidden;
            lblPreis.Visibility = Visibility.Hidden;
            lblVolumen.Visibility = Visibility.Hidden;
            lblGeld.Visibility = Visibility.Hidden;
            lblDichte.Visibility = Visibility.Hidden;

            txtParameter1.Visibility = Visibility.Hidden;
            txtParameter2.Visibility = Visibility.Hidden;
            txtParameter3.Visibility = Visibility.Hidden;
            txtParameter4.Visibility = Visibility.Hidden;
            txtParameter5.Visibility = Visibility.Hidden;
            txtParameter6.Visibility = Visibility.Hidden;
            txtVolumen.Visibility = Visibility.Hidden;
            txtFlaeche.Visibility = Visibility.Hidden;
            txtMasse.Visibility = Visibility.Hidden;
            txtPreis.Visibility = Visibility.Hidden;
            txtVolumen.Visibility = Visibility.Hidden;
            txtGeld.Visibility = Visibility.Hidden;
            txtDichte.Visibility = Visibility.Hidden;

            btnBerechne.IsEnabled = false;
            btnCatia.IsEnabled = false;

        }        
        public void ShowRechteck()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imRechteck.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "h:";
            lblParameter2.Content = "b:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Rechteck";       
                   
            btnBerechne.IsEnabled = true;
            
        }
        public void ShowDreieck()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imDreieck.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "h:";
            lblParameter2.Content = "a:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Dreieck";

            btnBerechne.IsEnabled = true;
            
        }
        public void ShowKasten()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imKasten.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "Kasten";

            btnBerechne.IsEnabled = true;
           
        }
        public void ShowKreisring()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imKreisring.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "R:";
            lblParameter2.Content = "r:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Kreisring";

            btnBerechne.IsEnabled = true;
           
        }
        public void ShowUProfil()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imUProfil.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "U-Profil";

            btnBerechne.IsEnabled = true;
            
        }
        public void ShowIProfil()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            lblGeld.Visibility = Visibility.Visible;
            lblDichte.Visibility = Visibility.Visible;

            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            txtGeld.Visibility = Visibility.Visible;
            txtDichte.Visibility = Visibility.Visible;
            imIProfil.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b/2:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "I-Profil";

            btnBerechne.IsEnabled = true;
            
        }


        private void trvFigur_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Hide();

            // Test um mit dem Debugger zu testen, was denn überhaupt für ein Typ übergeben wir
            // Mit einem "object" kann man nicht wirklich arbeiten - var kann alles aufnehmen was kommt
            //    var eventargs = e.NewValue;
            //    var send = sender;

            // Variante 2
            //  TreeViewItem myE = (TreeViewItem) e.NewValue  ;
            //   string Variable = myE.Name;

            // Variante 3
            TreeViewItem auswahlItem = (TreeViewItem)trvFigur.SelectedItem;
            string Variable = auswahlItem.Name;

            switch (Variable)
            {
                case ("itmRechteck"):
                    ShowRechteck();
                    break;
                case ("itmDreieck"):
                    ShowDreieck();
                    break;
                case ("itmKasten"):
                    ShowKasten();
                    break;
                case ("itmKreisring"):
                    ShowKreisring();
                    break;
                case ("itmUProfil"):
                    ShowUProfil();
                    break;
                case ("itmIProfil"):
                    ShowIProfil();
                    break;
            }
        }

       
    }

       // private void itmRechteck_Selected(object sender, RoutedEventArgs e)
       //  {
            //  Variante 1
            //  var ev = e.Source;
            //  string auswahl1 = ((TreeViewItem)e.Source).Name.ToString();

            // Variante 4 
            //   var send = sender;
            //   string auswahl2 = ((TreeViewItem)sender).Name.ToString();

            // hier brauchen Sie die switch/case Abfrage nicht, denn sie wissen schon, dass itmRechteck die Quelle ist
            // Danke für die Fingerübung!
       //  }

    }    

